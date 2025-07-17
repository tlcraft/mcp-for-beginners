<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T19:15:13+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
# Ügyfél létrehozása LLM-mel

Eddig láttad, hogyan lehet szervert és ügyfelet létrehozni. Az ügyfél képes volt explicit módon hívni a szervert, hogy listázza az eszközeit, erőforrásait és promptjait. Ez azonban nem túl praktikus megközelítés. A felhasználód az ügynöki korszakban él, és azt várja el, hogy promptokat használjon, és természetes nyelven kommunikáljon egy LLM-mel. A felhasználónak nem számít, hogy MCP-t használsz-e a képességek tárolására, de azt elvárja, hogy természetes nyelven tudjon interakcióba lépni. Hogyan oldjuk meg ezt? A megoldás, hogy LLM-et adunk az ügyfélhez.

## Áttekintés

Ebben a leckében arra fókuszálunk, hogyan adjunk LLM-et az ügyfélhez, és megmutatjuk, hogyan nyújt ez sokkal jobb élményt a felhasználónak.

## Tanulási célok

A lecke végére képes leszel:

- LLM-mel rendelkező ügyfelet létrehozni.
- Zökkenőmentesen kommunikálni egy MCP szerverrel LLM segítségével.
- Jobb végfelhasználói élményt biztosítani az ügyfél oldalon.

## Megközelítés

Próbáljuk megérteni, milyen lépéseket kell tennünk. Egy LLM hozzáadása egyszerűnek hangzik, de tényleg meg is valósítjuk?

Így fog az ügyfél kommunikálni a szerverrel:

1. Kapcsolat létrehozása a szerverrel.

1. A képességek, promptok, erőforrások és eszközök listázása, majd ezek sémájának elmentése.

1. LLM hozzáadása, és a mentett képességek és sémájuk átadása az LLM számára érthető formátumban.

1. Felhasználói prompt kezelése úgy, hogy azt az LLM-nek továbbítjuk az ügyfél által listázott eszközökkel együtt.

Remek, most, hogy nagy vonalakban értjük, hogyan csináljuk, próbáljuk ki a következő gyakorlatban.

## Gyakorlat: Ügyfél létrehozása LLM-mel

Ebben a gyakorlatban megtanuljuk, hogyan adjunk LLM-et az ügyfelünkhöz.

## Hitelesítés GitHub személyes hozzáférési tokennel

GitHub token létrehozása egyszerű folyamat. Így csinálhatod:

- Menj a GitHub Beállításokhoz – Kattints a profilképedre a jobb felső sarokban, majd válaszd a Beállításokat.
- Navigálj a Fejlesztői beállításokhoz – Görgess le és kattints a Fejlesztői beállításokra.
- Válaszd a Személyes hozzáférési tokeneket – Kattints a Személyes hozzáférési tokenekre, majd az Új token generálása gombra.
- Állítsd be a tokent – Adj meg egy megjegyzést, állíts be lejárati dátumot, és válaszd ki a szükséges jogosultságokat.
- Generáld és másold ki a tokent – Kattints a Token generálása gombra, és azonnal másold ki, mert később nem fogod látni újra.

### -1- Kapcsolódás a szerverhez

Először hozzuk létre az ügyfelünket:

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

A fenti kódban:

- Betöltöttük a szükséges könyvtárakat
- Létrehoztunk egy osztályt két taggal, `client` és `openai`, amelyek segítenek az ügyfél kezelésében és az LLM-mel való kommunikációban.
- Beállítottuk az LLM példányunkat, hogy GitHub Modelleket használjon, a `baseUrl`-t az inference API-ra mutatva.

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

A fenti kódban:

- Betöltöttük az MCP-hez szükséges könyvtárakat
- Létrehoztunk egy ügyfelet

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

Először add hozzá a LangChain4j függőségeket a `pom.xml` fájlodhoz. Ezek engedélyezik az MCP integrációt és a GitHub Modellek támogatását:

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

Ezután hozd létre a Java ügyfél osztályodat:

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

A fenti kódban:

- **Hozzáadtuk a LangChain4j függőségeket**: Szükségesek az MCP integrációhoz, az OpenAI hivatalos klienshez és a GitHub Modellek támogatásához
- **Betöltöttük a LangChain4j könyvtárakat**: MCP integrációhoz és OpenAI chat modell funkciókhoz
- **Létrehoztunk egy `ChatLanguageModel`-t**: Beállítva, hogy GitHub Modelleket használjon a GitHub tokeneddel
- **Beállítottuk az HTTP kapcsolatot**: Server-Sent Events (SSE) használatával az MCP szerverhez való kapcsolódáshoz
- **Létrehoztunk egy MCP ügyfelet**: Ami kezeli a kommunikációt a szerverrel
- **Használtuk a LangChain4j beépített MCP támogatását**: Ami leegyszerűsíti az LLM-ek és MCP szerverek közötti integrációt

Remek, a következő lépésként listázzuk a szerver képességeit.

### -2- Szerver képességek listázása

Most kapcsolódunk a szerverhez, és lekérdezzük a képességeit:

### TypeScript

Ugyanebben az osztályban add hozzá a következő metódusokat:

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

A fenti kódban:

- Hozzáadtuk a szerverhez való kapcsolódás kódját, `connectToServer`.
- Létrehoztunk egy `run` metódust, ami kezeli az alkalmazás folyamatát. Egyelőre csak az eszközöket listázza, de hamarosan bővítjük.

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

Amit hozzáadtunk:

- Listáztuk az erőforrásokat és eszközöket, majd kiírtuk őket. Az eszközöknél az `inputSchema`-t is listázzuk, amit később használunk.

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

A fenti kódban:

- Listáztuk az MCP szerveren elérhető eszközöket
- Minden eszköznél megjelenítettük a nevét, leírását és sémáját. Ez utóbbit később az eszközök hívásához használjuk.

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

A fenti kódban:

- Létrehoztunk egy `McpToolProvider`-t, ami automatikusan felfedezi és regisztrálja az összes eszközt az MCP szerverről
- Az eszköz szolgáltató belsőleg kezeli az MCP eszköz sémák és a LangChain4j eszköz formátum közötti átalakítást
- Ez a megközelítés elrejti az eszközök manuális listázását és átalakítását

### -3- Szerver képességek átalakítása LLM eszközökké

A következő lépés a szerver képességek átalakítása olyan formátumba, amit az LLM megért. Miután ez megvan, ezeket az eszközöket átadhatjuk az LLM-nek.

### TypeScript

1. Add hozzá a következő kódot, hogy az MCP szerver válaszát olyan eszköz formátummá alakítsd, amit az LLM használni tud:

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

    A fenti kód az MCP szerver válaszát átalakítja egy olyan eszköz definícióvá, amit az LLM megért.

1. Frissítsük a `run` metódust, hogy listázza a szerver képességeit:

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

    A fenti kódban frissítettük a `run` metódust, hogy végigmenjen az eredményen, és minden elemre meghívja az `openAiToolAdapter`-t.

### Python

1. Először hozzuk létre a következő konvertáló függvényt:

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

    A `convert_to_llm_tools` függvény az MCP eszköz válaszát olyan formátumba alakítja, amit az LLM megért.

1. Ezután frissítsük az ügyfél kódját, hogy használja ezt a függvényt:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Itt hozzáadtunk egy hívást a `convert_to_llm_tool`-ra, hogy az MCP eszköz válaszát olyan formátumba alakítsuk, amit később az LLM-nek adhatunk.

### .NET

1. Adjunk hozzá kódot, ami az MCP eszköz válaszát olyan formátumba alakítja, amit az LLM megért:

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

A fenti kódban:

- Létrehoztunk egy `ConvertFrom` függvényt, ami nevet, leírást és input sémát fogad.
- Definiáltunk egy funkciót, ami létrehoz egy `FunctionDefinition`-t, amit egy `ChatCompletionsDefinition`-nek ad át. Ez utóbbit az LLM megérti.

1. Nézzük meg, hogyan frissíthetjük a meglévő kódot, hogy kihasználja ezt a függvényt:

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

    A fenti kódban:

    - Frissítettük a függvényt, hogy az MCP eszköz válaszát LLM eszközzé alakítsa. Kiemeljük a hozzáadott kódot:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Az input séma az eszköz válasz része, de a "properties" attribútumban, ezért ki kell nyerni. Ezután meghívjuk a `ConvertFrom`-t az eszköz adataival. Most, hogy elvégeztük a nehezét, nézzük meg, hogyan kezeljük a felhasználói promptot.

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

A fenti kódban:

- Definiáltunk egy egyszerű `Bot` interfészt természetes nyelvű interakciókhoz
- Használtuk a LangChain4j `AiServices`-ét, hogy automatikusan összekösse az LLM-et az MCP eszköz szolgáltatóval
- A keretrendszer automatikusan kezeli az eszköz séma átalakítást és a funkcióhívásokat a háttérben
- Ez a megközelítés megszünteti a manuális eszköz átalakítást – a LangChain4j kezeli az MCP eszközök LLM-kompatibilis formátumba konvertálásának összetettségét

Remek, most már készen állunk a felhasználói kérések kezelésére, nézzük meg azt.

### -4- Felhasználói prompt kezelése

Ebben a kódrészben a felhasználói kéréseket fogjuk kezelni.

### TypeScript

1. Adjunk hozzá egy metódust, amivel az LLM-et hívjuk:

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

    A fenti kódban:

    - Hozzáadtunk egy `callTools` metódust.
    - A metódus megvizsgálja az LLM válaszát, hogy mely eszközöket hívták meg, ha egyáltalán:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Meghív egy eszközt, ha az LLM jelzi, hogy azt hívni kell:

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

1. Frissítsük a `run` metódust, hogy tartalmazza az LLM hívását és a `callTools` meghívását:

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

Remek, itt a teljes kód:

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

1. Adjunk hozzá néhány importot az LLM híváshoz:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Ezután adjuk hozzá a függvényt, ami az LLM-et hívja:

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

    A fenti kódban:

    - Átadtuk az LLM-nek azokat a függvényeket, amiket az MCP szerveren találtunk és átalakítottunk.
    - Meghívtuk az LLM-et ezekkel a függvényekkel.
    - Megvizsgáltuk az eredményt, hogy mely függvényeket kell meghívni, ha vannak ilyenek.
    - Végül átadtunk egy tömböt a meghívandó függvényekről.

1. Végül frissítsük a fő kódot:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Ez volt az utolsó lépés, a fenti kódban:

    - Meghívunk egy MCP eszközt a `call_tool` segítségével, egy olyan függvénnyel, amit az LLM javasolt a prompt alapján.
    - Kiírjuk az eszköz hívás eredményét az MCP szerverről.

### .NET

1. Mutatunk egy példát LLM prompt kérésre:

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

    A fenti kódban:

    - Lekértük az eszközöket az MCP szerverről, `var tools = await GetMcpTools()`.
    - Definiáltunk egy felhasználói promptot `userMessage`.
    - Létrehoztunk egy opció objektumot, amely megadja a modellt és az eszközöket.
    - Kérést küldtünk az LLM-nek.

1. Egy utolsó lépésként nézzük meg, hogy az LLM szerint kell-e függvényt hívni:

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

    A fenti kódban:

    - Végigiteráltunk a függvényhívások listáján.
    - Minden eszköz hívásnál kinyertük a nevet és az argumentumokat, majd meghívtuk az eszközt az MCP szerveren az MCP kliens segítségével. Végül kiírtuk az eredményt.

Itt a teljes kód:

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

A fenti kódban:

- Egyszerű természetes nyelvű promptokat használtunk az MCP szerver eszközeivel való interakcióhoz
- A LangChain4j keretrendszer automatikusan kezeli:
  - A felhasználói promptok eszköz hívásokká alakítását, ha szükséges
  - A megfelelő MCP eszközök meghívását az LLM döntése alapján
  - A beszélgetés folyamatának kezelését az LLM és az MCP szerver között
- A `bot.chat()` metódus természetes nyelvű válaszokat ad, amelyek tartalmazhatják az MCP eszközök végrehajtásának eredményeit
- Ez a megközelítés zökkenőmentes felhasználói élményt nyújt, ahol a felhasználóknak nem kell tudniuk az MCP mögöttes megvalósításáról

Teljes kód példa:

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

Gratulálok, sikerült!

## Feladat

Vedd elő a gyakorlat kódját, és bővítsd ki a szervert további eszközökkel. Ezután hozz létre egy LLM-mel rendelkező ügyfelet, ahogy a gyakorlatban, és teszteld különböző promptokkal, hogy megbizonyosodj róla, hogy a szerver összes eszköze dinamikusan meghívásra kerül. Ez az ügyfélépítési mód nagyszerű felhasználói élményt biztosít, mert a felhasználók promptokat használhatnak, nem pedig pontos kliens parancsokat, és nem kell tudniuk az MCP szerver hívásairól.

## Megoldás

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Főbb tanulságok

- LLM hozzáadása az ügyfélhez jobb módot kínál a felhasználóknak az MCP szerverekkel való interakcióra.
- Az MCP szerver válaszát olyan formátumba kell alakítani, amit az LLM megért.

## Minták

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## További források

## Mi következik

- Következő: [Szerver használata Visual Studio Code-dal](../04-vscode/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.