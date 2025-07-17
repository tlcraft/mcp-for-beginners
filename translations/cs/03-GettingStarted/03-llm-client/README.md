<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T10:48:03+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
# Vytvoření klienta s LLM

Doposud jste viděli, jak vytvořit server a klienta. Klient mohl explicitně volat server, aby vypsal jeho nástroje, zdroje a promptů. Nicméně to není příliš praktický přístup. Váš uživatel žije v agentní éře a očekává, že bude používat prompty a komunikovat s LLM. Pro vašeho uživatele není důležité, zda používáte MCP k ukládání schopností, ale očekává, že bude komunikovat přirozeným jazykem. Jak to tedy vyřešit? Řešením je přidat LLM do klienta.

## Přehled

V této lekci se zaměříme na přidání LLM do vašeho klienta a ukážeme, jak to poskytuje mnohem lepší uživatelský zážitek.

## Cíle učení

Na konci této lekce budete schopni:

- Vytvořit klienta s LLM.
- Plynule komunikovat se serverem MCP pomocí LLM.
- Poskytnout lepší uživatelský zážitek na straně klienta.

## Přístup

Pojďme si nejprve vysvětlit, jaký přístup budeme potřebovat. Přidání LLM zní jednoduše, ale jak to skutečně uděláme?

Takto bude klient komunikovat se serverem:

1. Naváže spojení se serverem.

1. Vylistuje schopnosti, prompty, zdroje a nástroje a uloží jejich schéma.

1. Přidá LLM a předá uložené schopnosti a jejich schéma ve formátu, kterému LLM rozumí.

1. Zpracuje uživatelský prompt tím, že ho předá LLM společně s nástroji, které klient vypsal.

Skvěle, teď když chápeme, jak to udělat na vysoké úrovni, pojďme to vyzkoušet v následujícím cvičení.

## Cvičení: Vytvoření klienta s LLM

V tomto cvičení se naučíme přidat LLM do našeho klienta.

## Autentizace pomocí GitHub Personal Access Token

Vytvoření GitHub tokenu je jednoduchý proces. Zde je návod, jak na to:

- Přejděte do GitHub Nastavení – Klikněte na svůj profilový obrázek v pravém horním rohu a vyberte Nastavení.
- Přejděte do Developer Settings – Sjeďte dolů a klikněte na Developer Settings.
- Vyberte Personal Access Tokens – Klikněte na Personal access tokens a poté na Generate new token.
- Nakonfigurujte svůj token – Přidejte poznámku pro orientaci, nastavte datum vypršení platnosti a vyberte potřebná oprávnění (scopes).
- Vygenerujte a zkopírujte token – Klikněte na Generate token a nezapomeňte ho hned zkopírovat, protože ho už znovu neuvidíte.

### -1- Připojení ke serveru

Nejprve vytvoříme našeho klienta:

### TypeScript

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

V předchozím kódu jsme:

- Importovali potřebné knihovny
- Vytvořili třídu se dvěma členy, `client` a `openai`, které nám pomohou spravovat klienta a komunikovat s LLM.
- Nakonfigurovali instanci LLM tak, aby používala GitHub Models nastavením `baseUrl` na inference API.

### Python

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

V předchozím kódu jsme:

- Importovali potřebné knihovny pro MCP
- Vytvořili klienta

### .NET

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

### Java

Nejprve je potřeba přidat závislosti LangChain4j do souboru `pom.xml`. Přidejte tyto závislosti pro podporu integrace MCP a GitHub Models:

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

Poté vytvořte třídu klienta v Javě:

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

V předchozím kódu jsme:

- **Přidali závislosti LangChain4j**: Potřebné pro integraci MCP, oficiální OpenAI klient a podporu GitHub Models
- **Importovali knihovny LangChain4j**: Pro integraci MCP a funkce OpenAI chat modelu
- **Vytvořili `ChatLanguageModel`**: Nakonfigurovaný pro použití GitHub Models s vaším GitHub tokenem
- **Nastavili HTTP transport**: Pomocí Server-Sent Events (SSE) pro připojení k MCP serveru
- **Vytvořili MCP klienta**: Který bude zajišťovat komunikaci se serverem
- **Použili vestavěnou podporu MCP v LangChain4j**: Což zjednodušuje integraci mezi LLM a MCP servery

Skvěle, jako další krok si vylistujeme schopnosti serveru.

### -2 Vypsání schopností serveru

Nyní se připojíme k serveru a požádáme ho o jeho schopnosti:

### TypeScript

Ve stejné třídě přidejte následující metody:

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

V předchozím kódu jsme:

- Přidali kód pro připojení k serveru, `connectToServer`.
- Vytvořili metodu `run`, která řídí tok naší aplikace. Zatím pouze vypisuje nástroje, ale brzy přidáme další funkce.

### Python

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

Co jsme přidali:

- Vypsání zdrojů a nástrojů a jejich vytištění. U nástrojů také vypisujeme `inputSchema`, které později použijeme.

### .NET

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

        // TODO: convert tool defintion from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

V předchozím kódu jsme:

- Vypsali nástroje dostupné na MCP serveru
- Pro každý nástroj vypsali jméno, popis a jeho schéma. To použijeme později pro volání nástrojů.

### Java

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

V předchozím kódu jsme:

- Vytvořili `McpToolProvider`, který automaticky objeví a zaregistruje všechny nástroje z MCP serveru
- Poskytovatel nástrojů interně zajišťuje převod mezi MCP schématy nástrojů a formátem nástrojů LangChain4j
- Tento přístup abstrahuje manuální výpis a převod nástrojů

### -3- Převod schopností serveru na nástroje LLM

Dalším krokem po vypsání schopností serveru je převést je do formátu, kterému LLM rozumí. Jakmile to uděláme, můžeme tyto schopnosti předat jako nástroje našemu LLM.

### TypeScript

1. Přidejte následující kód pro převod odpovědi z MCP serveru do formátu nástroje, který LLM může použít:

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

    Tento kód vezme odpověď z MCP serveru a převede ji do formátu definice nástroje, kterému LLM rozumí.

1. Nyní aktualizujme metodu `run`, aby vypsala schopnosti serveru:

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

    V předchozím kódu jsme aktualizovali metodu `run`, která prochází výsledky a pro každý záznam volá `openAiToolAdapter`.

### Python

1. Nejprve vytvořme následující konverzní funkci:

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

    Ve funkci `convert_to_llm_tools` převedeme odpověď MCP nástroje do formátu, kterému LLM rozumí.

1. Poté aktualizujme kód klienta, aby tuto funkci využíval:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Zde přidáváme volání `convert_to_llm_tool`, které převádí odpověď MCP nástroje na formát, který můžeme později předat LLM.

### .NET

1. Přidejme kód pro převod odpovědi MCP nástroje do formátu, kterému LLM rozumí:

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

V předchozím kódu jsme:

- Vytvořili funkci `ConvertFrom`, která přijímá jméno, popis a vstupní schéma.
- Definovali funkčnost, která vytváří `FunctionDefinition`, jež se předává do `ChatCompletionsDefinition`. To je formát, kterému LLM rozumí.

1. Podívejme se, jak můžeme aktualizovat existující kód, aby využíval tuto funkci:

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

    V předchozím kódu jsme:

    - Aktualizovali funkci pro převod odpovědi MCP nástroje na LLM nástroj. Zvýrazníme přidaný kód:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Vstupní schéma je součástí odpovědi nástroje, ale v atributu "properties", takže ho musíme extrahovat. Dále voláme `ConvertFrom` s detaily nástroje. Nyní, když máme těžkou práci za sebou, podívejme se, jak to funguje při zpracování uživatelského promptu.

### Java

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

V předchozím kódu jsme:

- Definovali jednoduché rozhraní `Bot` pro interakci v přirozeném jazyce
- Použili LangChain4j `AiServices` pro automatické propojení LLM s poskytovatelem nástrojů MCP
- Framework automaticky zajišťuje převod schémat nástrojů a volání funkcí na pozadí
- Tento přístup eliminuje manuální převod nástrojů – LangChain4j zvládá veškerou složitost převodu MCP nástrojů do formátu kompatibilního s LLM

Skvěle, jsme připraveni zpracovávat uživatelské požadavky, pojďme na to.

### -4- Zpracování uživatelského promptu

V této části kódu budeme zpracovávat uživatelské požadavky.

### TypeScript

1. Přidejte metodu, která bude volat naše LLM:

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

    V předchozím kódu jsme:

    - Přidali metodu `callTools`.
    - Metoda přijímá odpověď LLM a kontroluje, jaké nástroje byly volány, pokud vůbec:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Volá nástroj, pokud LLM naznačí, že by měl být volán:

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

1. Aktualizujte metodu `run`, aby zahrnovala volání LLM a volání `callTools`:

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

Skvěle, zde je kompletní kód:

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

### Python

1. Přidejme potřebné importy pro volání LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Dále přidejme funkci, která bude volat LLM:

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

    V předchozím kódu jsme:

    - Předali funkce, které jsme našli na MCP serveru a převedli, LLM.
    - Poté jsme zavolali LLM s těmito funkcemi.
    - Následně kontrolujeme výsledek, abychom zjistili, které funkce bychom měli volat, pokud nějaké.
    - Nakonec předáváme pole funkcí k volání.

1. Poslední krok, aktualizujme hlavní kód:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Tímto jsme dokončili poslední krok, v kódu výše:

    - Voláme MCP nástroj přes `call_tool` pomocí funkce, kterou LLM vyhodnotilo jako vhodnou k volání na základě promptu.
    - Vypisujeme výsledek volání nástroje na MCP server.

### .NET

1. Ukážeme kód pro provedení LLM promptu:

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

    V předchozím kódu jsme:

    - Získali nástroje z MCP serveru, `var tools = await GetMcpTools()`.
    - Definovali uživatelský prompt `userMessage`.
    - Vytvořili objekt možností s modelem a nástroji.
    - Odeslali požadavek na LLM.

1. Poslední krok, zjistíme, zda LLM navrhuje volání funkce:

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

    V předchozím kódu jsme:

    - Prošli seznam volání funkcí.
    - Pro každé volání nástroje rozparsovali jméno a argumenty a zavolali nástroj na MCP serveru pomocí MCP klienta. Nakonec vypisujeme výsledky.

Zde je kompletní kód:

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

### Java

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

V předchozím kódu jsme:

- Použili jednoduché prompty v přirozeném jazyce pro interakci s nástroji MCP serveru
- Framework LangChain4j automaticky zajišťuje:
  - Převod uživatelských promptů na volání nástrojů, pokud je to potřeba
  - Volání příslušných MCP nástrojů na základě rozhodnutí LLM
  - Řízení konverzačního toku mezi LLM a MCP serverem
- Metoda `bot.chat()` vrací odpovědi v přirozeném jazyce, které mohou obsahovat výsledky z MCP nástrojů
- Tento přístup poskytuje plynulý uživatelský zážitek, kdy uživatelé nemusí znát detaily implementace MCP

Kompletní příklad kódu:

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

Skvěle, zvládli jste to!

## Zadání

Vezměte kód z cvičení a rozšiřte server o další nástroje. Poté vytvořte klienta s LLM, jako v cvičení, a otestujte ho s různými promptami, abyste se ujistili, že všechny nástroje serveru jsou volány dynamicky. Tento způsob vytváření klienta zajistí skvělý uživatelský zážitek, protože uživatelé mohou používat prompty místo přesných příkazů klienta a nemusí vědět o volání MCP serveru.

## Řešení

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Hlavní poznatky

- Přidání LLM do klienta poskytuje lepší způsob, jak uživatelé komunikují s MCP servery.
- Je potřeba převést odpověď MCP serveru do formátu, kterému LLM rozumí.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

## Co dál

- Další: [Použití serveru ve Visual Studio Code](../04-vscode/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.