<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T19:26:02+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "bg"
}
-->
# Създаване на клиент с LLM

Досега видяхте как да създадете сървър и клиент. Клиентът можеше да извиква сървъра директно, за да изброи неговите инструменти, ресурси и подсказки. Въпреки това, това не е много практичен подход. Вашият потребител живее в ерата на агентите и очаква да използва подсказки и да комуникира с LLM, за да го направи. За вашия потребител няма значение дали използвате MCP за съхранение на възможностите си, но те очакват да използват естествен език за взаимодействие. Как да решим това? Решението е да добавим LLM към клиента.

## Преглед

В този урок ще се фокусираме върху добавянето на LLM към вашия клиент и ще покажем как това осигурява много по-добро изживяване за вашия потребител.

## Цели на обучението

До края на този урок ще можете:

- Да създадете клиент с LLM.
- Безпроблемно да взаимодействате със сървър MCP чрез LLM.
- Да осигурите по-добро потребителско изживяване от страна на клиента.

## Подход

Нека се опитаме да разберем подхода, който трябва да предприемем. Добавянето на LLM звучи просто, но дали наистина е така?

Ето как клиентът ще взаимодейства със сървъра:

1. Установяване на връзка със сървъра.

1. Изброяване на възможности, подсказки, ресурси и инструменти и запазване на техните схеми.

1. Добавяне на LLM и предаване на запазените възможности и техните схеми във формат, който LLM разбира.

1. Обработка на потребителска подсказка чрез предаване към LLM заедно с инструментите, изброени от клиента.

Чудесно, сега разбираме как можем да направим това на високо ниво, нека го изпробваме в упражнението по-долу.

## Упражнение: Създаване на клиент с LLM

В това упражнение ще научим как да добавим LLM към нашия клиент.

### Автентикация с GitHub Personal Access Token

Създаването на GitHub токен е лесен процес. Ето как можете да го направите:

- Отидете в GitHub Settings – Кликнете върху вашата профилна снимка в горния десен ъгъл и изберете Settings.
- Навигирайте до Developer Settings – Превъртете надолу и кликнете върху Developer Settings.
- Изберете Personal Access Tokens – Кликнете върху Personal access tokens и след това Generate new token.
- Конфигурирайте вашия токен – Добавете бележка за справка, задайте дата на изтичане и изберете необходимите обхвати (permissions).
- Генерирайте и копирайте токена – Кликнете Generate token и се уверете, че го копирате веднага, тъй като няма да можете да го видите отново.

### -1- Свързване със сървъра

Нека първо създадем нашия клиент:

#### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MCPClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", 
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }
}
```

В горния код сме:

- Импортирахме необходимите библиотеки
- Създадохме клас с два члена, `client` и `openai`, които ще ни помогнат да управляваме клиента и да взаимодействаме с LLM съответно.
- Конфигурирахме нашия LLM екземпляр да използва GitHub Models, като зададохме `baseUrl` да сочи към inference API.

#### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)


async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()


if __name__ == "__main__":
    import asyncio

    asyncio.run(run())

```

В горния код сме:

- Импортирали необходимите библиотеки за MCP.
- Създали клиент.

#### .NET

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

#### Java

Първо, трябва да добавите зависимостите на LangChain4j във вашия `pom.xml` файл. Добавете тези зависимости, за да активирате интеграцията с MCP и поддръжката на GitHub Models:

```xml
<properties>
    <langchain4j.version>1.0.0-beta3</langchain4j.version>
</properties>

<dependencies>
    <!-- LangChain4j MCP Integration -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-mcp</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- OpenAI Official API Client -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-open-ai-official</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- GitHub Models Support -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-github-models</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- Spring Boot Starter (optional, for production apps) -->
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-actuator</artifactId>
    </dependency>
</dependencies>
```

След това създайте вашия Java клиентски клас:

```java
import dev.langchain4j.mcp.McpToolProvider;
import dev.langchain4j.mcp.client.DefaultMcpClient;
import dev.langchain4j.mcp.client.McpClient;
import dev.langchain4j.mcp.client.transport.McpTransport;
import dev.langchain4j.mcp.client.transport.http.HttpMcpTransport;
import dev.langchain4j.model.chat.ChatLanguageModel;
import dev.langchain4j.model.openaiofficial.OpenAiOfficialChatModel;
import dev.langchain4j.service.AiServices;
import dev.langchain4j.service.tool.ToolProvider;

import java.time.Duration;
import java.util.List;

public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        // Configure the LLM to use GitHub Models
        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .build();

        // Create MCP transport for connecting to server
        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        // Create MCP client
        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();
    }
}
```

В горния код сме:

- **Добавихме зависимости на LangChain4j**: Необходими за интеграция с MCP, официалния OpenAI клиент и поддръжка на GitHub Models
- **Импортирахме библиотеките на LangChain4j**: За интеграция с MCP и функционалност на OpenAI чат модел
- **Създадохме `ChatLanguageModel`**: Конфигуриран да използва GitHub Models с вашия GitHub токен
- **Настроихме HTTP транспорт**: Използвайки Server-Sent Events (SSE) за връзка със сървъра MCP
- **Създадохме MCP клиент**: Който ще обработва комуникацията със сървъра
- **Използвахме вградената поддръжка на MCP в LangChain4j**: Което опростява интеграцията между LLM и MCP сървъри

Страхотно, за следващата стъпка нека изброим възможностите на сървъра.

### -2- Изброяване на възможностите на сървъра

Сега ще се свържем със сървъра и ще поискаме неговите възможности:

#### TypeScript

```typescript
async connectToServer(transport: Transport) {
     await this.client.connect(transport);
     this.run();
     console.error("MCPClient started on stdin/stdout");
}

async run() {
    console.log("Asking server for available tools");

    // listing tools
    const toolsResult = await this.client.listTools();
}
```

В горния код сме:

- Добавихме код за свързване със сървъра, `connectToServer`.
- Създадохме метод `run`, отговорен за управлението на потока на приложението. Досега той само изброява инструментите, но скоро ще добавим още.

#### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
    print("Tool", tool.inputSchema["properties"])
```

Ето какво добавихме:

- Изброяване на ресурси и инструменти и ги отпечатахме. За инструментите също изброяваме `inputSchema`, който ще използваме по-късно.

#### .NET

```csharp
async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        // TODO: convert tool definition from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

В горния код сме:

- Изброихме инструментите, налични на MCP сървъра
- За всеки инструмент изброихме име, описание и неговата схема. Последното е нещо, което ще използваме скоро, за да извикаме инструментите.

#### Java

```java
// Create a tool provider that automatically discovers MCP tools
ToolProvider toolProvider = McpToolProvider.builder()
        .mcpClients(List.of(mcpClient))
        .build();

// The MCP tool provider automatically handles:
// - Listing available tools from the MCP server
// - Converting MCP tool schemas to LangChain4j format
// - Managing tool execution and responses
```

В горния код сме:

- Създали `McpToolProvider`, който автоматично открива и регистрира всички инструменти от MCP сървъра.
- Провайдърът на инструменти обработва конверсията между схемите на MCP инструментите и формата на инструментите на LangChain4j вътрешно.
- Този подход абстрахира ръчния процес на изброяване и конверсия на инструменти.

#### Rust

Извличането на инструменти от MCP сървъра се извършва чрез метода `list_tools`. Във вашата функция `main`, след настройката на MCP клиента, добавете следния код:

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- Конвертиране на възможностите на сървъра в инструменти за LLM

Следващата стъпка след изброяването на възможностите на сървъра е да ги конвертираме във формат, който LLM разбира. След като направим това, можем да предоставим тези възможности като инструменти на LLM.

#### TypeScript

1. Добавете следния код за конвертиране на отговор от MCP сървъра във формат на инструмент, който LLM може да използва:

    ```typescript
    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
        }) {
        // Create a zod schema based on the input_schema
        const schema = z.object(tool.input_schema);
    
        return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
            name: tool.name,
            description: tool.description,
            parameters: {
            type: "object",
            properties: tool.input_schema.properties,
            required: tool.input_schema.required,
            },
            },
        };
    }

    ```

    Горният код взема отговор от MCP сървъра и го конвертира в дефиниция на инструмент, която LLM може да разбере.

1. Нека актуализираме метода `run`, за да изброим възможностите на сървъра:

    ```typescript
    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
            name: tool.name,
            description: tool.description,
            input_schema: tool.inputSchema,
            });
        });
    }
    ```

    В горния код сме актуализирали метода `run`, за да преминава през резултата и за всяко записване да извиква `openAiToolAdapter`.

#### Python

1. Първо, нека създадем следната функция за конвертиране:

    ```python
    def convert_to_llm_tool(tool):
        tool_schema = {
            "type": "function",
            "function": {
                "name": tool.name,
                "description": tool.description,
                "type": "function",
                "parameters": {
                    "type": "object",
                    "properties": tool.inputSchema["properties"]
                }
            }
        }

        return tool_schema
    ```

    В горната функция `convert_to_llm_tools` вземаме отговор от MCP инструмент и го конвертираме във формат, който LLM може да разбере.

1. След това нека обновим кода на клиента, за да използва тази функция по следния начин:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Тук добавяме извикване към `convert_to_llm_tool`, за да конвертираме отговора от MCP инструмент в нещо, което можем да подадем на LLM по-късно.

#### .NET

1. Нека добавим код за конвертиране на отговора от MCP инструмент в нещо, което LLM може да разбере:

```csharp
ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}
```

В горния код сме:

- Създали функция `ConvertFrom`, която приема име, описание и входна схема.
- Дефинирали функционалност, която създава FunctionDefinition, който се предава на ChatCompletionsDefinition. Последното е нещо, което LLM може да разбере.

1. Нека видим как можем да актуализираме съществуващ код, за да се възползваме от тази функция:

    ```csharp
    async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
    {
        Console.WriteLine("Listing tools");
        var tools = await mcpClient.ListToolsAsync();

        List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

        foreach (var tool in tools)
        {
            Console.WriteLine($"Connected to server with tools: {tool.Name}");
            Console.WriteLine($"Tool description: {tool.Description}");
            Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

            JsonElement propertiesElement;
            tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

            var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
            Console.WriteLine($"Tool definition: {def}");
            toolDefinitions.Add(def);

            Console.WriteLine($"Properties: {propertiesElement}");        
        }

        return toolDefinitions;
    }
    ```

    В горния код сме:

    - Обновихме функцията, за да конвертира отговора от MCP инструмента в LLM инструмент. Нека подчертаем добавения код:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Входната схема е част от отговора на инструмента, но в атрибута "properties", затова трябва да я извлечем. Освен това сега извикваме `ConvertFrom` с детайлите на инструмента. След като свършихме тежката работа, нека видим как се съчетава извикването, докато обработваме потребителска подсказка.

#### Java

```java
// Create a Bot interface for natural language interaction
public interface Bot {
    String chat(String prompt);
}

// Configure the AI service with LLM and MCP tools
Bot bot = AiServices.builder(Bot.class)
        .chatLanguageModel(model)
        .toolProvider(toolProvider)
        .build();
```

В горния код сме:

- Дефинирахме прост интерфейс `Bot` за взаимодействия на естествен език
- Използвахме `AiServices` на LangChain4j, за да свържем автоматично LLM с MCP доставчика на инструменти
- Фреймуъркът автоматично обработва конверсията на инструменталните схеми и извикването на функции зад кулисите
- Този подход премахва ръчната конверсия на инструменти – LangChain4j се грижи за цялата сложност при конвертирането на MCP инструменти във формат, съвместим с LLM

Страхотно, вече сме готови да обработваме потребителски заявки, нека преминем към това.

### -4- Обработка на потребителска заявка

В тази част от кода ще обработим потребителските заявки.

#### TypeScript

1. Добавете метод, който ще се използва за извикване на нашия LLM:

    ```typescript
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
    ) {
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);


        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  

        }
    }
    ```

    В горния код сме:

    - Добавили метод `callTools`.
    - Методът приема отговор от LLM и проверява дали има инструменти, които трябва да бъдат извикани:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Извиква инструмент, ако LLM посочи, че трябва да бъде извикан:

        ```typescript
        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  
        ```

1. Актуализирайте метода `run`, за да включва извиквания към LLM и извикване на `callTools`:

    ```typescript

    // 1. Create messages that's input for the LLM
    const prompt = "What is the sum of 2 and 3?"

    const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

    console.log("Querying LLM: ", messages[0].content);

    // 2. Calling the LLM
    let response = this.openai.chat.completions.create({
        model: "gpt-4o-mini",
        max_tokens: 1000,
        messages,
        tools: tools,
    });    

    let results: any[] = [];

    // 3. Go through the LLM response,for each choice, check if it has tool calls 
    (await response).choices.map(async (choice: { message: any; }) => {
        const message = choice.message;
        if (message.tool_calls) {
            console.log("Making tool call")
            await this.callTools(message.tool_calls, results);
        }
    });
    ```

Чудесно, нека изброим кода в пълен вид:

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MyClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", // might need to change to this url in the future: https://models.github.ai/inference
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }

    async connectToServer(transport: Transport) {
        await this.client.connect(transport);
        this.run();
        console.error("MCPClient started on stdin/stdout");
    }

    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
          }) {
          // Create a zod schema based on the input_schema
          const schema = z.object(tool.input_schema);
      
          return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
              name: tool.name,
              description: tool.description,
              parameters: {
              type: "object",
              properties: tool.input_schema.properties,
              required: tool.input_schema.required,
              },
            },
          };
    }
    
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
      ) {
        for (const tool_call of tool_calls) {
          const toolName = tool_call.function.name;
          const args = tool_call.function.arguments;
    
          console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);
    
    
          // 2. Call the server's tool 
          const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
          });
    
          console.log("Tool result: ", toolResult);
    
          // 3. Do something with the result
          // TODO  
    
         }
    }

    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
              name: tool.name,
              description: tool.description,
              input_schema: tool.inputSchema,
            });
        });

        const prompt = "What is the sum of 2 and 3?";
    
        const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

        console.log("Querying LLM: ", messages[0].content);
        let response = this.openai.chat.completions.create({
            model: "gpt-4o-mini",
            max_tokens: 1000,
            messages,
            tools: tools,
        });    

        let results: any[] = [];
    
        // 1. Go through the LLM response,for each choice, check if it has tool calls 
        (await response).choices.map(async (choice: { message: any; }) => {
          const message = choice.message;
          if (message.tool_calls) {
              console.log("Making tool call")
              await this.callTools(message.tool_calls, results);
          }
        });
    }
    
}

let client = new MyClient();
 const transport = new StdioClientTransport({
            command: "node",
            args: ["./build/index.js"]
        });

client.connectToServer(transport);
```

#### Python

1. Нека добавим някои импорти, необходими за извикване на LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. След това нека добавим функцията, която ще извиква LLM:

    ```python
    # llm

    def call_llm(prompt, functions):
        token = os.environ["GITHUB_TOKEN"]
        endpoint = "https://models.inference.ai.azure.com"

        model_name = "gpt-4o"

        client = ChatCompletionsClient(
            endpoint=endpoint,
            credential=AzureKeyCredential(token),
        )

        print("CALLING LLM")
        response = client.complete(
            messages=[
                {
                "role": "system",
                "content": "You are a helpful assistant.",
                },
                {
                "role": "user",
                "content": prompt,
                },
            ],
            model=model_name,
            tools = functions,
            # Optional parameters
            temperature=1.,
            max_tokens=1000,
            top_p=1.    
        )

        response_message = response.choices[0].message
        
        functions_to_call = []

        if response_message.tool_calls:
            for tool_call in response_message.tool_calls:
                print("TOOL: ", tool_call)
                name = tool_call.function.name
                args = json.loads(tool_call.function.arguments)
                functions_to_call.append({ "name": name, "args": args })

        return functions_to_call
    ```

    В горния код сме:

    - Предали нашите функции, които намерихме на MCP сървъра и конвертирахме, на LLM.
    - След това извикали LLM с тези функции.
    - След това проверяваме резултата, за да видим какви функции трябва да извикаме, ако има такива.
    - Накрая предаваме масив от функции за извикване.

1. Последна стъпка, нека актуализираме основния код:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Там, това беше последната стъпка, в горния код сме:

    - Извикали MCP инструмент чрез `call_tool`, използвайки функция, която LLM смята, че трябва да бъде извикана въз основа на нашата подсказка.
    - Отпечатали резултата от извикването на инструмента към MCP сървъра.

#### .NET

1. Нека покажем код за извършване на LLM заявка с подсказка:

    ```csharp
    var tools = await GetMcpTools();

    for (int i = 0; i < tools.Count; i++)
    {
        var tool = tools[i];
        Console.WriteLine($"MCP Tools def: {i}: {tool}");
    }

    // 0. Define the chat history and the user message
    var userMessage = "add 2 and 4";

    chatHistory.Add(new ChatRequestUserMessage(userMessage));

    // 1. Define tools
    ChatCompletionsToolDefinition def = CreateToolDefinition();


    // 2. Define options, including the tools
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "gpt-4o-mini",
        Tools = { tools[0] }
    };

    // 3. Call the model  

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;

    ```

    В горния код сме:

    - Извлекли инструменти от MCP сървъра, `var tools = await GetMcpTools()`.
    - Дефинирали потребителска подсказка `userMessage`.
    - Конструирали обект с опции, указващ модела и инструментите.
    - Направили заявка към LLM.

1. Една последна стъпка, нека видим дали LLM смята, че трябва да извика функция:

    ```csharp
    // 4. Check if the response contains a function call
    ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
    for (int i = 0; i < response.ToolCalls.Count; i++)
    {
        var call = response.ToolCalls[i];
        Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
        //Tool call 0: add with arguments {"a":2,"b":4}

        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
        var result = await mcpClient.CallToolAsync(
            call.Name,
            dict!,
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

    }
    ```

    В горния код сме:

    - Прегледали списък с извиквания на функции.
    - За всяко извикване на инструмент, извлекли име и аргументи и извикали инструмента на MCP сървъра, използвайки MCP клиента. Накрая отпечатали резултатите.

Ето кода в пълен вид:

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

Console.WriteLine("Setting up stdio transport");

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}



async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);

        Console.WriteLine($"Properties: {propertiesElement}");        
    }

    return toolDefinitions;
}

// 1. List tools on mcp server

var tools = await GetMcpTools();
for (int i = 0; i < tools.Count; i++)
{
    var tool = tools[i];
    Console.WriteLine($"MCP Tools def: {i}: {tool}");
}

// 2. Define the chat history and the user message
var userMessage = "add 2 and 4";

chatHistory.Add(new ChatRequestUserMessage(userMessage));


// 3. Define options, including the tools
var options = new ChatCompletionsOptions(chatHistory)
{
    Model = "gpt-4o-mini",
    Tools = { tools[0] }
};

// 4. Call the model  

ChatCompletions? response = await client.CompleteAsync(options);
var content = response.Content;

// 5. Check if the response contains a function call
ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
for (int i = 0; i < response.ToolCalls.Count; i++)
{
    var call = response.ToolCalls[i];
    Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
    //Tool call 0: add with arguments {"a":2,"b":4}

    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
    var result = await mcpClient.CallToolAsync(
        call.Name,
        dict!,
        cancellationToken: CancellationToken.None
    );

    Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

}

// 5. Print the generic response
Console.WriteLine($"Assistant response: {content}");
```

#### Java

```java
try {
    // Execute natural language requests that automatically use MCP tools
    String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
    System.out.println(response);

    response = bot.chat("What's the square root of 144?");
    System.out.println(response);

    response = bot.chat("Show me the help for the calculator service");
    System.out.println(response);
} finally {
    mcpClient.close();
}
```

В горния код сме:

- Използвали прости подсказки на естествен език за взаимодействие с инструментите на MCP сървъра.
- Фреймуъркът LangChain4j автоматично обработва:
  - Конвертиране на потребителски подсказки в извиквания на инструменти, когато е необходимо.
  - Извикване на подходящите MCP инструменти въз основа на решението на LLM.
  - Управление на потока на разговора между LLM и MCP сървъра.
- Методът `bot.chat()` връща отговори на естествен език, които могат да включват резултати от изпълнения на MCP инструменти.
- Този подход осигурява безпроблемно потребителско изживяване, при което потребителите не трябва да знаят за основната имплементация на MCP.

Пълен пример за код:

```java
public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .timeout(Duration.ofSeconds(60))
                .build();

        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();

        ToolProvider toolProvider = McpToolProvider.builder()
                .mcpClients(List.of(mcpClient))
                .build();

        Bot bot = AiServices.builder(Bot.class)
                .chatLanguageModel(model)
                .toolProvider(toolProvider)
                .build();

        try {
            String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
            System.out.println(response);

            response = bot.chat("What's the square root of 144?");
            System.out.println(response);

            response = bot.chat("Show me the help for the calculator service");
            System.out.println(response);
        } finally {
            mcpClient.close();
        }
    }
}
```

#### Rust

Тук се случва по-голямата част от работата. Ще извикаме LLM с първоначалната потребителска подсказка, след това ще обработим отговора, за да видим дали трябва да бъдат извикани инструменти. Ако е така, ще извикаме тези инструменти и ще продължим разговора с LLM, докато не се наложи повече извикване на инструменти и не получим окончателен отговор.
Ще направим няколко извиквания към LLM, затова нека дефинираме функция, която ще обработва извикването към LLM. Добавете следната функция във вашия файл `main.rs`:

```rust
async fn call_llm(
    client: &Client<OpenAIConfig>,
    messages: &[Value],
    tools: &ListToolsResult,
) -> Result<Value, Box<dyn Error>> {
    let response = client
        .completions()
        .create_byot(json!({
            "messages": messages,
            "model": "openai/gpt-4.1",
            "tools": format_tools(tools).await?,
        }))
        .await?;
    Ok(response)
}
```

Тази функция приема LLM клиента, списък с съобщения (включително потребителския подканващ текст), инструменти от MCP сървъра и изпраща заявка към LLM, връщайки отговора.

Отговорът от LLM ще съдържа масив от `choices`. Ще трябва да обработим резултата, за да проверим дали има налични `tool_calls`. Това ни показва, че LLM иска да бъде извикан конкретен инструмент с аргументи. Добавете следния код в края на вашия файл `main.rs`, за да дефинирате функция за обработка на отговора от LLM:

```rust
async fn process_llm_response(
    llm_response: &Value,
    mcp_client: &RunningService<RoleClient, ()>,
    openai_client: &Client<OpenAIConfig>,
    mcp_tools: &ListToolsResult,
    messages: &mut Vec<Value>,
) -> Result<(), Box<dyn Error>> {
    let Some(message) = llm_response
        .get("choices")
        .and_then(|c| c.as_array())
        .and_then(|choices| choices.first())
        .and_then(|choice| choice.get("message"))
    else {
        return Ok(());
    };

    // Print content if available
    if let Some(content) = message.get("content").and_then(|c| c.as_str()) {
        println!("🤖 {}", content);
    }

    // Handle tool calls
    if let Some(tool_calls) = message.get("tool_calls").and_then(|tc| tc.as_array()) {
        messages.push(message.clone()); // Add assistant message

        // Execute each tool call
        for tool_call in tool_calls {
            let (tool_id, name, args) = extract_tool_call_info(tool_call)?;
            println!("⚡ Calling tool: {}", name);

            let result = mcp_client
                .call_tool(CallToolRequestParam {
                    name: name.into(),
                    arguments: serde_json::from_str::<Value>(&args)?.as_object().cloned(),
                })
                .await?;

            // Add tool result to messages
            messages.push(json!({
                "role": "tool",
                "tool_call_id": tool_id,
                "content": serde_json::to_string_pretty(&result)?
            }));
        }

        // Continue conversation with tool results
        let response = call_llm(openai_client, messages, mcp_tools).await?;
        Box::pin(process_llm_response(
            &response,
            mcp_client,
            openai_client,
            mcp_tools,
            messages,
        ))
        .await?;
    }
    Ok(())
}
```

Ако има налични `tool_calls`, функцията извлича информацията за инструмента, извиква MCP сървъра със заявката за инструмента и добавя резултатите към съобщенията в разговора. След това продължава разговора с LLM, като съобщенията се актуализират с отговора на асистента и резултатите от извикването на инструмента.

За да извлечем информацията за извикване на инструмент, която LLM връща за MCP извиквания, ще добавим още една помощна функция, която извлича всичко необходимо за извикването. Добавете следния код в края на вашия файл `main.rs`:

```rust
fn extract_tool_call_info(tool_call: &Value) -> Result<(String, String, String), Box<dyn Error>> {
    let tool_id = tool_call
        .get("id")
        .and_then(|id| id.as_str())
        .unwrap_or("")
        .to_string();
    let function = tool_call.get("function").ok_or("Missing function")?;
    let name = function
        .get("name")
        .and_then(|n| n.as_str())
        .unwrap_or("")
        .to_string();
    let args = function
        .get("arguments")
        .and_then(|a| a.as_str())
        .unwrap_or("{}")
        .to_string();
    Ok((tool_id, name, args))
}
```

С всички части на място, сега можем да обработим първоначалния потребителски подканващ текст и да извикаме LLM. Актуализирайте вашата функция `main`, за да включите следния код:

```rust
// LLM conversation with tool calls
let response = call_llm(&openai_client, &messages, &tools).await?;
process_llm_response(
    &response,
    &mcp_client,
    &openai_client,
    &tools,
    &mut messages,
)
.await?;
```

Това ще направи заявка към LLM с първоначалния потребителски подканващ текст, който пита за сумата на две числа, и ще обработи отговора, за да обработи динамично извикванията на инструменти.

Чудесно, справихте се!

## Задача

Вземете кода от упражнението и разширете сървъра с още инструменти. След това създайте клиент с LLM, както в упражнението, и го тествайте с различни подсказки, за да се уверите, че всички инструменти на сървъра се извикват динамично. Този начин на изграждане на клиент осигурява отлично потребителско изживяване, тъй като потребителите могат да използват подсказки, вместо точни клиентски команди, и не се налага да знаят за извикванията към MCP сървъра.

## Решение

[Решение](/03-GettingStarted/03-llm-client/solution/README.md)

## Основни изводи

- Добавянето на LLM към вашия клиент предоставя по-добър начин за потребителите да взаимодействат с MCP сървъри.
- Трябва да преобразувате отговора от MCP сървъра в нещо, което LLM може да разбере.

## Примери

- [Java Калкулатор](../samples/java/calculator/README.md)
- [.Net Калкулатор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Калкулатор](../samples/javascript/README.md)
- [TypeScript Калкулатор](../samples/typescript/README.md)
- [Python Калкулатор](../../../../03-GettingStarted/samples/python)
- [Rust Калкулатор](../../../../03-GettingStarted/samples/rust)

## Допълнителни ресурси

## Какво следва

- Следва: [Използване на сървър с Visual Studio Code](../04-vscode/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия първичен език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.