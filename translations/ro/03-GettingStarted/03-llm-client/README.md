<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T11:18:50+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ro"
}
-->
# Crearea unui client cu LLM

Până acum, ai văzut cum să creezi un server și un client. Clientul a putut apela explicit serverul pentru a lista uneltele, resursele și prompturile sale. Totuși, aceasta nu este o abordare foarte practică. Utilizatorul tău trăiește în era agenților și se așteaptă să folosească prompturi și să comunice cu un LLM pentru a face acest lucru. Pentru utilizatorul tău, nu contează dacă folosești MCP sau nu pentru a stoca capabilitățile, dar se așteaptă să folosească limbaj natural pentru interacțiune. Deci, cum rezolvăm asta? Soluția este să adăugăm un LLM clientului.

## Prezentare generală

În această lecție ne concentrăm pe adăugarea unui LLM la clientul tău și arătăm cum acest lucru oferă o experiență mult mai bună pentru utilizator.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Să creezi un client cu un LLM.
- Să interacționezi fără probleme cu un server MCP folosind un LLM.
- Să oferi o experiență mai bună utilizatorului final pe partea de client.

## Abordare

Să încercăm să înțelegem abordarea pe care trebuie să o urmăm. Adăugarea unui LLM pare simplă, dar chiar o vom face?

Iată cum va interacționa clientul cu serverul:

1. Stabilește conexiunea cu serverul.

1. Listează capabilitățile, prompturile, resursele și uneltele, și salvează schema acestora.

1. Adaugă un LLM și transmite capabilitățile salvate și schema lor într-un format pe care LLM-ul îl înțelege.

1. Gestionează un prompt de la utilizator trimițându-l către LLM împreună cu uneltele listate de client.

Perfect, acum că înțelegem cum putem face asta la nivel înalt, să încercăm în exercițiul de mai jos.

## Exercițiu: Crearea unui client cu un LLM

În acest exercițiu, vom învăța să adăugăm un LLM clientului nostru.

## Autentificare folosind GitHub Personal Access Token

Crearea unui token GitHub este un proces simplu. Iată cum poți face asta:

- Mergi la GitHub Settings – Apasă pe poza ta de profil din colțul din dreapta sus și selectează Settings.
- Navighează la Developer Settings – Derulează în jos și apasă pe Developer Settings.
- Selectează Personal Access Tokens – Apasă pe Personal access tokens și apoi pe Generate new token.
- Configurează tokenul – Adaugă o notă pentru referință, setează o dată de expirare și selectează permisiunile necesare (scopes).
- Generează și copiază tokenul – Apasă pe Generate token și asigură-te că îl copiezi imediat, deoarece nu vei mai putea să-l vezi din nou.

### -1- Conectarea la server

Să creăm mai întâi clientul nostru:

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

În codul de mai sus am:

- Importat bibliotecile necesare
- Creat o clasă cu doi membri, `client` și `openai`, care ne vor ajuta să gestionăm clientul și să interacționăm cu un LLM, respectiv.
- Configurat instanța LLM să folosească GitHub Models setând `baseUrl` către API-ul de inferență.

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

În codul de mai sus am:

- Importat bibliotecile necesare pentru MCP
- Creat un client

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

Mai întâi, trebuie să adaugi dependențele LangChain4j în fișierul tău `pom.xml`. Adaugă aceste dependențe pentru a activa integrarea MCP și suportul pentru GitHub Models:

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

Apoi creează clasa client Java:

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

În codul de mai sus am:

- **Adăugat dependențele LangChain4j**: Necesare pentru integrarea MCP, clientul oficial OpenAI și suportul pentru GitHub Models
- **Importat bibliotecile LangChain4j**: Pentru integrarea MCP și funcționalitatea modelului de chat OpenAI
- **Creat un `ChatLanguageModel`**: Configurat să folosească GitHub Models cu tokenul tău GitHub
- **Setat transport HTTP**: Folosind Server-Sent Events (SSE) pentru a conecta la serverul MCP
- **Creat un client MCP**: Care va gestiona comunicarea cu serverul
- **Folosind suportul încorporat LangChain4j pentru MCP**: Care simplifică integrarea între LLM-uri și serverele MCP

Perfect, pentru pasul următor, să listăm capabilitățile serverului.

### -2 Listarea capabilităților serverului

Acum ne vom conecta la server și îi vom cere capabilitățile:

### TypeScript

În aceeași clasă, adaugă următoarele metode:

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

În codul de mai sus am:

- Adăugat cod pentru conectarea la server, `connectToServer`.
- Creat o metodă `run` responsabilă pentru gestionarea fluxului aplicației noastre. Până acum listează doar uneltele, dar vom adăuga mai multe în curând.

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

Iată ce am adăugat:

- Listarea resurselor și uneltelor și afișarea lor. Pentru unelte listăm și `inputSchema` pe care îl vom folosi mai târziu.

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

În codul de mai sus am:

- Listat uneltele disponibile pe serverul MCP
- Pentru fiecare unealtă, am listat numele, descrierea și schema acesteia. Aceasta din urmă este ceva ce vom folosi pentru a apela uneltele în curând.

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

În codul de mai sus am:

- Creat un `McpToolProvider` care descoperă și înregistrează automat toate uneltele de pe serverul MCP
- Providerul de unelte gestionează conversia între schemele uneltelor MCP și formatul uneltelor LangChain4j intern
- Această abordare elimină procesul manual de listare și conversie a uneltelor

### -3- Convertirea capabilităților serverului în unelte LLM

Următorul pas după listarea capabilităților serverului este să le convertim într-un format pe care LLM-ul îl înțelege. Odată ce facem asta, putem oferi aceste capabilități ca unelte LLM-ului nostru.

### TypeScript

1. Adaugă următorul cod pentru a converti răspunsul de la serverul MCP într-un format de unealtă pe care LLM-ul îl poate folosi:

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

    Codul de mai sus ia un răspuns de la serverul MCP și îl convertește într-un format de definiție a unei unelte pe care LLM-ul îl poate înțelege.

1. Să actualizăm metoda `run` pentru a lista capabilitățile serverului:

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

    În codul de mai sus, am actualizat metoda `run` să parcurgă rezultatul și pentru fiecare intrare să apeleze `openAiToolAdapter`.

### Python

1. Mai întâi, să creăm următoarea funcție convertor:

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

    În funcția `convert_to_llm_tools` de mai sus, luăm un răspuns de la o unealtă MCP și îl convertim într-un format pe care LLM-ul îl poate înțelege.

1. Apoi, să actualizăm codul clientului pentru a folosi această funcție astfel:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Aici, adăugăm un apel la `convert_to_llm_tool` pentru a converti răspunsul uneltei MCP într-un format pe care îl putem transmite LLM-ului mai târziu.

### .NET

1. Să adăugăm cod pentru a converti răspunsul uneltei MCP într-un format pe care LLM-ul îl poate înțelege

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

În codul de mai sus am:

- Creat o funcție `ConvertFrom` care primește numele, descrierea și schema de input.
- Definit funcționalitatea care creează un `FunctionDefinition` ce este transmis unui `ChatCompletionsDefinition`. Acesta din urmă este ceva ce LLM-ul poate înțelege.

1. Să vedem cum putem actualiza codul existent pentru a folosi această funcție:

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

    În codul de mai sus am:

    - Actualizat funcția pentru a converti răspunsul uneltei MCP într-o unealtă LLM. Să evidențiem codul adăugat:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Schema de input face parte din răspunsul uneltei, dar se află în atributul "properties", deci trebuie extrasă. Mai mult, acum apelăm `ConvertFrom` cu detaliile uneltei. Acum că am făcut partea grea, să vedem cum se leagă apelul când gestionăm un prompt de la utilizator.

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

În codul de mai sus am:

- Definit o interfață simplă `Bot` pentru interacțiuni în limbaj natural
- Folosit `AiServices` din LangChain4j pentru a lega automat LLM-ul cu providerul de unelte MCP
- Framework-ul gestionează automat conversia schemei uneltelor și apelarea funcțiilor în fundal
- Această abordare elimină conversia manuală a uneltelor – LangChain4j se ocupă de toată complexitatea conversiei uneltelor MCP în format compatibil cu LLM

Perfect, acum suntem pregătiți să gestionăm cererile utilizatorilor, așa că să trecem la asta.

### -4- Gestionarea cererii de prompt a utilizatorului

În această parte a codului, vom gestiona cererile utilizatorilor.

### TypeScript

1. Adaugă o metodă care va fi folosită pentru a apela LLM-ul nostru:

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

    În codul de mai sus am:

    - Adăugat o metodă `callTools`.
    - Metoda primește un răspuns de la LLM și verifică ce unelte au fost apelate, dacă există:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Apelează o unealtă, dacă LLM indică că trebuie apelată:

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

1. Actualizează metoda `run` pentru a include apeluri către LLM și apelarea `callTools`:

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

Perfect, să vedem codul complet:

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

1. Să adăugăm importurile necesare pentru a apela un LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Apoi, să adăugăm funcția care va apela LLM-ul:

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

    În codul de mai sus am:

    - Transmis funcțiile găsite pe serverul MCP și convertite către LLM.
    - Apoi am apelat LLM-ul cu aceste funcții.
    - Inspectăm rezultatul pentru a vedea ce funcții ar trebui apelate, dacă există.
    - În final, transmitem un array de funcții de apelat.

1. Pasul final, să actualizăm codul principal:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Asta a fost pasul final, în codul de mai sus:

    - Apelăm o unealtă MCP prin `call_tool` folosind o funcție pe care LLM-ul a considerat că trebuie să o apelăm pe baza promptului.
    - Afișăm rezultatul apelului uneltei către serverul MCP.

### .NET

1. Să arătăm un cod pentru a face o cerere de prompt către LLM:

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

    În codul de mai sus am:

    - Preluat uneltele de pe serverul MCP, `var tools = await GetMcpTools()`.
    - Definit un prompt de utilizator `userMessage`.
    - Creat un obiect de opțiuni specificând modelul și uneltele.
    - Făcut o cerere către LLM.

1. Un ultim pas, să vedem dacă LLM consideră că trebuie să apelăm o funcție:

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

    În codul de mai sus am:

    - Iterat prin lista de apeluri de funcții.
    - Pentru fiecare apel de unealtă, extragem numele și argumentele și apelăm unealta pe serverul MCP folosind clientul MCP. În final afișăm rezultatele.

Iată codul complet:

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

În codul de mai sus am:

- Folosit prompturi simple în limbaj natural pentru a interacționa cu uneltele serverului MCP
- Framework-ul LangChain4j gestionează automat:
  - Conversia prompturilor utilizatorului în apeluri de unelte când este nevoie
  - Apelarea uneltelor MCP corespunzătoare pe baza deciziei LLM
  - Gestionarea fluxului conversației între LLM și serverul MCP
- Metoda `bot.chat()` returnează răspunsuri în limbaj natural care pot include rezultate din execuțiile uneltelor MCP
- Această abordare oferă o experiență fluidă utilizatorului, care nu trebuie să știe despre implementarea MCP din spate

Exemplu complet de cod:

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

Perfect, ai reușit!

## Tema

Ia codul din exercițiu și extinde serverul cu mai multe unelte. Apoi creează un client cu un LLM, ca în exercițiu, și testează-l cu diferite prompturi pentru a te asigura că toate uneltele serverului sunt apelate dinamic. Această metodă de construire a unui client înseamnă că utilizatorul final va avea o experiență excelentă, deoarece poate folosi prompturi în loc de comenzi exacte ale clientului și nu va ști că un server MCP este apelat.

## Soluție

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Concluzii cheie

- Adăugarea unui LLM la client oferă o modalitate mai bună pentru utilizatori de a interacționa cu serverele MCP.
- Trebuie să convertești răspunsul serverului MCP într-un format pe care LLM-ul îl poate înțelege.

## Exemple

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Resurse suplimentare

## Ce urmează

- Următorul pas: [Consumarea unui server folosind Visual Studio Code](../04-vscode/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.