<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a656dbc7648e07da08eb4d1ffde4938e",
  "translation_date": "2025-07-22T08:13:18+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pt"
}
-->
# Criar um cliente com LLM

Até agora, vimos como criar um servidor e um cliente. O cliente foi capaz de chamar o servidor explicitamente para listar as suas ferramentas, recursos e prompts. No entanto, essa abordagem não é muito prática. O seu utilizador vive na era dos agentes e espera usar prompts e comunicar com um LLM para realizar tarefas. Para o utilizador, não importa se utiliza MCP ou não para armazenar as suas capacidades, mas espera interagir usando linguagem natural. Então, como resolvemos isso? A solução passa por adicionar um LLM ao cliente.

## Visão Geral

Nesta lição, focamo-nos em adicionar um LLM ao cliente e mostramos como isso proporciona uma experiência muito melhor para o utilizador.

## Objetivos de Aprendizagem

No final desta lição, será capaz de:

- Criar um cliente com um LLM.
- Interagir de forma fluida com um servidor MCP usando um LLM.
- Proporcionar uma melhor experiência ao utilizador no lado do cliente.

## Abordagem

Vamos tentar entender a abordagem que precisamos adotar. Adicionar um LLM parece simples, mas como realmente fazemos isso?

Aqui está como o cliente irá interagir com o servidor:

1. Estabelecer conexão com o servidor.

1. Listar capacidades, prompts, recursos e ferramentas, e guardar os seus esquemas.

1. Adicionar um LLM e passar as capacidades guardadas e os seus esquemas num formato que o LLM entenda.

1. Processar um prompt do utilizador, passando-o para o LLM juntamente com as ferramentas listadas pelo cliente.

Ótimo, agora entendemos como podemos fazer isso a um nível elevado. Vamos experimentar no exercício abaixo.

## Exercício: Criar um cliente com um LLM

Neste exercício, vamos aprender a adicionar um LLM ao nosso cliente.

### Autenticação usando GitHub Personal Access Token

Criar um token do GitHub é um processo simples. Veja como pode fazê-lo:

- Aceda às Definições do GitHub – Clique na sua foto de perfil no canto superior direito e selecione Definições.
- Navegue até às Definições de Programador – Desça até encontrar e clique em Definições de Programador.
- Selecione Personal Access Tokens – Clique em Personal access tokens e depois em Generate new token.
- Configure o Seu Token – Adicione uma nota para referência, defina uma data de expiração e selecione os escopos (permissões) necessários.
- Gere e Copie o Token – Clique em Generate token e certifique-se de copiá-lo imediatamente, pois não poderá vê-lo novamente.

### -1- Conectar ao servidor

Vamos criar o nosso cliente primeiro:

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

No código acima, fizemos:

- A importação das bibliotecas necessárias.
- Criámos uma classe com dois membros, `client` e `openai`, que nos ajudarão a gerir um cliente e interagir com um LLM, respetivamente.
- Configurámos a instância do LLM para usar GitHub Models, definindo `baseUrl` para apontar para a API de inferência.

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

No código acima, fizemos:

- A importação das bibliotecas necessárias para MCP.
- Criámos um cliente.

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

Primeiro, será necessário adicionar as dependências do LangChain4j ao seu ficheiro `pom.xml`. Adicione estas dependências para ativar a integração com MCP e suporte a GitHub Models:

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

Depois, crie a sua classe de cliente em Java:

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

No código acima, fizemos:

- **Adicionámos dependências do LangChain4j**: Necessárias para integração com MCP, cliente oficial OpenAI e suporte a GitHub Models.
- **Importámos as bibliotecas do LangChain4j**: Para integração com MCP e funcionalidade de modelo de chat OpenAI.
- **Criámos um `ChatLanguageModel`**: Configurado para usar GitHub Models com o seu token do GitHub.
- **Configurámos transporte HTTP**: Usando Server-Sent Events (SSE) para conectar ao servidor MCP.
- **Criámos um cliente MCP**: Que irá gerir a comunicação com o servidor.
- **Usámos o suporte integrado do LangChain4j para MCP**: Que simplifica a integração entre LLMs e servidores MCP.

Ótimo, para o próximo passo, vamos listar as capacidades no servidor.

### -2- Listar capacidades do servidor

Agora vamos conectar ao servidor e pedir as suas capacidades:

#### TypeScript

Na mesma classe, adicione os seguintes métodos:

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

No código acima, fizemos:

- Adicionámos código para conectar ao servidor, `connectToServer`.
- Criámos um método `run` responsável por gerir o fluxo da aplicação. Até agora, apenas lista as ferramentas, mas iremos adicionar mais em breve.

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

Aqui está o que adicionámos:

- Listámos recursos e ferramentas e imprimimos. Para as ferramentas, também listamos `inputSchema`, que usaremos mais tarde.

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

No código acima, fizemos:

- Listámos as ferramentas disponíveis no servidor MCP.
- Para cada ferramenta, listámos o nome, descrição e o seu esquema. Este último será usado para chamar as ferramentas em breve.

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

No código acima, fizemos:

- Criámos um `McpToolProvider` que descobre e regista automaticamente todas as ferramentas do servidor MCP.
- O fornecedor de ferramentas gere a conversão entre esquemas de ferramentas MCP e o formato de ferramentas do LangChain4j internamente.
- Esta abordagem abstrai o processo manual de listagem e conversão de ferramentas.

### -3- Converter capacidades do servidor para ferramentas LLM

O próximo passo, após listar as capacidades do servidor, é convertê-las para um formato que o LLM entenda. Assim, podemos fornecer essas capacidades como ferramentas ao LLM.

#### TypeScript

1. Adicione o seguinte código para converter a resposta do servidor MCP para um formato de ferramenta que o LLM possa usar:

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

    O código acima pega na resposta do servidor MCP e converte-a para uma definição de ferramenta que o LLM possa entender.

1. Atualize o método `run` para listar as capacidades do servidor:

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

    No código acima, atualizámos o método `run` para mapear os resultados e, para cada entrada, chamar `openAiToolAdapter`.

#### Python

1. Primeiro, crie a seguinte função de conversão:

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

    Na função acima, `convert_to_llm_tools`, pegamos na resposta de uma ferramenta MCP e convertemo-la para um formato que o LLM possa entender.

1. Atualize o código do cliente para usar esta função:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Aqui, adicionámos uma chamada a `convert_to_llm_tool` para converter a resposta da ferramenta MCP para algo que possamos alimentar ao LLM mais tarde.

#### .NET

1. Adicione código para converter a resposta da ferramenta MCP para algo que o LLM possa entender:

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

No código acima, fizemos:

- Criámos uma função `ConvertFrom` que recebe nome, descrição e esquema de entrada.
- Definimos funcionalidade que cria uma FunctionDefinition que é passada para um ChatCompletionsDefinition. Este último é algo que o LLM pode entender.

1. Atualize o código existente para usar esta função:

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

    No código acima, fizemos:

    - Atualizámos a função para converter a resposta da ferramenta MCP para uma ferramenta LLM. Vamos destacar o código que adicionámos:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        O esquema de entrada faz parte da resposta da ferramenta, mas está no atributo "properties", então precisamos de o extrair. Além disso, agora chamamos `ConvertFrom` com os detalhes da ferramenta. Agora que fizemos o trabalho pesado, vamos ver como tudo se junta ao processar um prompt do utilizador.

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

No código acima, fizemos:

- Definimos uma interface simples `Bot` para interações em linguagem natural.
- Usámos os `AiServices` do LangChain4j para vincular automaticamente o LLM ao fornecedor de ferramentas MCP.
- O framework gere automaticamente a conversão de esquemas de ferramentas e chamadas de funções nos bastidores.
- Esta abordagem elimina a conversão manual de ferramentas - o LangChain4j trata de toda a complexidade de converter ferramentas MCP para um formato compatível com LLM.

Ótimo, estamos prontos para processar pedidos de utilizadores. Vamos tratar disso a seguir.

### -4- Processar pedidos de prompt do utilizador

Nesta parte do código, iremos processar pedidos de utilizadores.

#### TypeScript

1. Adicione um método para chamar o LLM:

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

    No código acima, fizemos:

    - Adicionámos um método `callTools`.
    - O método verifica a resposta do LLM para ver quais ferramentas foram chamadas, se houver:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Chama uma ferramenta, se o LLM indicar que deve ser chamada:

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

1. Atualize o método `run` para incluir chamadas ao LLM e ao `callTools`:

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

Ótimo, aqui está o código completo:

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

1. Adicione as importações necessárias para chamar um LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Adicione a função que chamará o LLM:

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

    No código acima, fizemos:

    - Passámos as nossas funções, encontradas no servidor MCP e convertidas, para o LLM.
    - Chamámos o LLM com essas funções.
    - Inspecionámos o resultado para ver quais funções devem ser chamadas, se houver.
    - Finalmente, passámos um array de funções para chamar.

1. Atualize o código principal:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    No código acima, fizemos:

    - Chamámos uma ferramenta MCP via `call_tool` usando uma função que o LLM achou que deveria ser chamada com base no nosso prompt.
    - Imprimimos o resultado da chamada da ferramenta ao servidor MCP.

#### .NET

1. Mostre o código para fazer um pedido de prompt ao LLM:

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

    No código acima, fizemos:

    - Obtivemos ferramentas do servidor MCP, `var tools = await GetMcpTools()`.
    - Definimos um prompt do utilizador `userMessage`.
    - Construímos um objeto de opções especificando o modelo e as ferramentas.
    - Fizemos um pedido ao LLM.

1. Verifique se o LLM acha que devemos chamar uma função:

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

    No código acima, fizemos:

    - Iterámos por uma lista de chamadas de funções.
    - Para cada chamada de ferramenta, extraímos o nome e os argumentos e chamámos a ferramenta no servidor MCP usando o cliente MCP. Finalmente, imprimimos os resultados.

Aqui está o código completo:

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

No código acima, fizemos:

- Usámos prompts simples em linguagem natural para interagir com as ferramentas do servidor MCP.
- O framework LangChain4j gere automaticamente:
  - Converter prompts de utilizadores em chamadas de ferramentas, quando necessário.
  - Chamar as ferramentas MCP apropriadas com base na decisão do LLM.
  - Gerir o fluxo de conversação entre o LLM e o servidor MCP.
- O método `bot.chat()` retorna respostas em linguagem natural que podem incluir resultados de execuções de ferramentas MCP.
- Esta abordagem proporciona uma experiência fluida ao utilizador, que não precisa de saber sobre a implementação subjacente do MCP.

Exemplo de código completo:

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

Ótimo, conseguiu!

## Tarefa

Pegue no código do exercício e expanda o servidor com mais ferramentas. Depois, crie um cliente com um LLM, como no exercício, e teste-o com diferentes prompts para garantir que todas as ferramentas do servidor são chamadas dinamicamente. Este método de construir um cliente proporciona uma excelente experiência ao utilizador, permitindo-lhe usar prompts em vez de comandos exatos e sem se preocupar com o servidor MCP que está a ser chamado.

## Solução

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais Conclusões

- Adicionar um LLM ao cliente proporciona uma melhor forma de os utilizadores interagirem com servidores MCP.
- É necessário converter a resposta do servidor MCP para algo que o LLM possa entender.

## Exemplos

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

## O que vem a seguir

- Próximo: [Consumir um servidor usando Visual Studio Code](../04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte oficial. Para informações críticas, recomenda-se uma tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas resultantes do uso desta tradução.