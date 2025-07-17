<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-16T22:18:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "de"
}
-->
# Erstellen eines Clients mit LLM

Bisher hast du gesehen, wie man einen Server und einen Client erstellt. Der Client konnte den Server explizit aufrufen, um dessen Tools, Ressourcen und Prompts aufzulisten. Das ist jedoch keine sehr praktische Vorgehensweise. Dein Nutzer lebt im Zeitalter der Agenten und erwartet, Prompts zu verwenden und mit einem LLM zu kommunizieren, um dies zu tun. Für deinen Nutzer ist es egal, ob du MCP nutzt, um deine Fähigkeiten zu speichern, aber sie erwarten, natürliche Sprache zur Interaktion zu verwenden. Wie lösen wir das? Die Lösung besteht darin, dem Client ein LLM hinzuzufügen.

## Überblick

In dieser Lektion konzentrieren wir uns darauf, ein LLM zu deinem Client hinzuzufügen und zeigen, wie dies eine deutlich bessere Erfahrung für deinen Nutzer bietet.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Einen Client mit einem LLM zu erstellen.
- Nahtlos mit einem MCP-Server unter Verwendung eines LLM zu interagieren.
- Eine bessere Endnutzererfahrung auf der Client-Seite zu bieten.

## Vorgehensweise

Lass uns verstehen, welchen Ansatz wir verfolgen müssen. Ein LLM hinzuzufügen klingt einfach, aber wie genau machen wir das?

So wird der Client mit dem Server interagieren:

1. Verbindung zum Server herstellen.

1. Fähigkeiten, Prompts, Ressourcen und Tools auflisten und deren Schema speichern.

1. Ein LLM hinzufügen und die gespeicherten Fähigkeiten und deren Schema in einem Format übergeben, das das LLM versteht.

1. Einen Nutzer-Prompt verarbeiten, indem er zusammen mit den vom Client aufgelisteten Tools an das LLM übergeben wird.

Super, jetzt verstehen wir auf hoher Ebene, wie wir das machen können. Lass uns das im folgenden Übungsteil ausprobieren.

## Übung: Einen Client mit einem LLM erstellen

In dieser Übung lernen wir, wie man ein LLM zu unserem Client hinzufügt.

## Authentifizierung mit GitHub Personal Access Token

Das Erstellen eines GitHub-Tokens ist ein einfacher Prozess. So geht’s:

- Gehe zu GitHub Einstellungen – Klicke auf dein Profilbild oben rechts und wähle Einstellungen.
- Navigiere zu Entwickler-Einstellungen – Scrolle nach unten und klicke auf Entwickler-Einstellungen.
- Wähle Personal Access Tokens – Klicke auf Personal Access Tokens und dann auf Neuen Token generieren.
- Konfiguriere deinen Token – Füge eine Notiz zur Referenz hinzu, setze ein Ablaufdatum und wähle die notwendigen Berechtigungen (Scopes) aus.
- Generiere und kopiere den Token – Klicke auf Token generieren und kopiere ihn sofort, da du ihn später nicht mehr sehen kannst.

### -1- Verbindung zum Server herstellen

Lass uns zuerst unseren Client erstellen:

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

Im obigen Code haben wir:

- Die benötigten Bibliotheken importiert
- Eine Klasse mit zwei Mitgliedern `client` und `openai` erstellt, die uns helfen, einen Client zu verwalten und mit einem LLM zu interagieren.
- Unsere LLM-Instanz so konfiguriert, dass GitHub-Modelle verwendet werden, indem `baseUrl` auf die Inference-API zeigt.

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

Im obigen Code haben wir:

- Die benötigten Bibliotheken für MCP importiert
- Einen Client erstellt

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

Zuerst musst du die LangChain4j-Abhängigkeiten zu deiner `pom.xml` hinzufügen. Füge diese Abhängigkeiten hinzu, um MCP-Integration und GitHub-Modelle zu unterstützen:

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

Erstelle dann deine Java-Client-Klasse:

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

Im obigen Code haben wir:

- **LangChain4j-Abhängigkeiten hinzugefügt**: Erforderlich für MCP-Integration, offiziellen OpenAI-Client und GitHub-Modelle
- **LangChain4j-Bibliotheken importiert**: Für MCP-Integration und OpenAI Chat-Modell-Funktionalität
- **Ein `ChatLanguageModel` erstellt**: Konfiguriert zur Nutzung von GitHub-Modellen mit deinem GitHub-Token
- **HTTP-Transport eingerichtet**: Mit Server-Sent Events (SSE) zur Verbindung mit dem MCP-Server
- **Einen MCP-Client erstellt**: Der die Kommunikation mit dem Server übernimmt
- **LangChain4j eingebaute MCP-Unterstützung verwendet**: Die die Integration zwischen LLMs und MCP-Servern vereinfacht

Super, als nächstes listen wir die Fähigkeiten auf dem Server auf.

### -2- Serverfähigkeiten auflisten

Jetzt verbinden wir uns mit dem Server und fragen nach seinen Fähigkeiten:

### TypeScript

Füge in derselben Klasse die folgenden Methoden hinzu:

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

Im obigen Code haben wir:

- Code zum Verbinden mit dem Server hinzugefügt, `connectToServer`.
- Eine `run`-Methode erstellt, die den Ablauf unserer App steuert. Bisher listet sie nur die Tools auf, aber wir werden bald mehr hinzufügen.

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

Das haben wir hinzugefügt:

- Ressourcen und Tools aufgelistet und ausgegeben. Für Tools listen wir auch das `inputSchema`, das wir später verwenden.

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

Im obigen Code haben wir:

- Die auf dem MCP-Server verfügbaren Tools aufgelistet
- Für jedes Tool Name, Beschreibung und dessen Schema aufgelistet. Letzteres werden wir bald nutzen, um die Tools aufzurufen.

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

Im obigen Code haben wir:

- Einen `McpToolProvider` erstellt, der automatisch alle Tools vom MCP-Server entdeckt und registriert
- Der Tool-Provider übernimmt intern die Umwandlung zwischen MCP-Tool-Schemas und dem LangChain4j-Tool-Format
- Dieser Ansatz erspart die manuelle Auflistung und Umwandlung der Tools

### -3- Serverfähigkeiten in LLM-Tools umwandeln

Der nächste Schritt nach dem Auflisten der Serverfähigkeiten ist, diese in ein Format zu konvertieren, das das LLM versteht. Sobald wir das gemacht haben, können wir diese Fähigkeiten als Tools unserem LLM bereitstellen.

### TypeScript

1. Füge den folgenden Code hinzu, um die Antwort vom MCP-Server in ein Tool-Format zu konvertieren, das das LLM nutzen kann:

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

    Der obige Code nimmt eine Antwort vom MCP-Server und wandelt sie in ein Tool-Definitionsformat um, das das LLM versteht.

1. Aktualisiere als Nächstes die `run`-Methode, um die Serverfähigkeiten aufzulisten:

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

    Im obigen Code haben wir die `run`-Methode aktualisiert, um das Ergebnis zu durchlaufen und für jeden Eintrag `openAiToolAdapter` aufzurufen.

### Python

1. Zuerst erstellen wir die folgende Konverterfunktion:

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

    In der Funktion `convert_to_llm_tools` nehmen wir eine MCP-Tool-Antwort und wandeln sie in ein Format um, das das LLM versteht.

1. Als Nächstes aktualisieren wir unseren Client-Code, um diese Funktion zu nutzen:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Hier fügen wir einen Aufruf zu `convert_to_llm_tool` hinzu, um die MCP-Tool-Antwort in etwas umzuwandeln, das wir später dem LLM übergeben können.

### .NET

1. Fügen wir Code hinzu, um die MCP-Tool-Antwort in etwas umzuwandeln, das das LLM versteht:

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

Im obigen Code haben wir:

- Eine Funktion `ConvertFrom` erstellt, die Name, Beschreibung und Input-Schema entgegennimmt.
- Funktionalität definiert, die eine `FunctionDefinition` erstellt, die an eine `ChatCompletionsDefinition` übergeben wird. Letzteres versteht das LLM.

1. Sehen wir uns an, wie wir bestehenden Code aktualisieren können, um diese Funktion zu nutzen:

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

    Im obigen Code haben wir:

    - Die Funktion aktualisiert, um die MCP-Tool-Antwort in ein LLM-Tool umzuwandeln. Hier der hinzugefügte Code:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Das Input-Schema ist Teil der Tool-Antwort, befindet sich aber im Attribut „properties“, das wir extrahieren müssen. Außerdem rufen wir jetzt `ConvertFrom` mit den Tool-Details auf. Nachdem wir die schwere Arbeit erledigt haben, sehen wir uns an, wie der Aufruf zusammenkommt, wenn wir als Nächstes einen Nutzer-Prompt verarbeiten.

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

Im obigen Code haben wir:

- Ein einfaches `Bot`-Interface für natürliche Sprachinteraktionen definiert
- LangChain4j’s `AiServices` verwendet, um das LLM automatisch mit dem MCP-Tool-Provider zu verbinden
- Das Framework übernimmt automatisch die Tool-Schema-Konvertierung und Funktionsaufrufe im Hintergrund
- Dieser Ansatz eliminiert manuelle Tool-Konvertierung – LangChain4j kümmert sich um die gesamte Komplexität der Umwandlung von MCP-Tools in ein LLM-kompatibles Format

Super, wir sind jetzt bereit, Nutzeranfragen zu bearbeiten. Das machen wir als Nächstes.

### -4- Nutzer-Prompt verarbeiten

In diesem Teil des Codes werden wir Nutzeranfragen bearbeiten.

### TypeScript

1. Füge eine Methode hinzu, die verwendet wird, um unser LLM aufzurufen:

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

    Im obigen Code haben wir:

    - Eine Methode `callTools` hinzugefügt.
    - Die Methode nimmt eine LLM-Antwort und prüft, welche Tools aufgerufen wurden, falls vorhanden:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Ruft ein Tool auf, wenn das LLM angibt, dass es aufgerufen werden soll:

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

1. Aktualisiere die `run`-Methode, um Aufrufe an das LLM und `callTools` einzufügen:

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

Super, hier der vollständige Code:

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

1. Fügen wir einige Importe hinzu, die für den LLM-Aufruf benötigt werden:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Als Nächstes fügen wir die Funktion hinzu, die das LLM aufruft:

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

    Im obigen Code haben wir:

    - Unsere Funktionen, die wir auf dem MCP-Server gefunden und konvertiert haben, an das LLM übergeben.
    - Das LLM mit diesen Funktionen aufgerufen.
    - Das Ergebnis geprüft, um zu sehen, welche Funktionen wir aufrufen sollten, falls vorhanden.
    - Schließlich ein Array von Funktionen zum Aufrufen übergeben.

1. Letzter Schritt, wir aktualisieren unseren Hauptcode:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Das war der letzte Schritt. Im obigen Code:

    - Rufen wir ein MCP-Tool über `call_tool` auf, basierend auf einer Funktion, die das LLM aufgrund unseres Prompts aufrufen wollte.
    - Geben das Ergebnis des Tool-Aufrufs auf dem MCP-Server aus.

### .NET

1. Hier ein Beispielcode für eine LLM-Prompt-Anfrage:

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

    Im obigen Code haben wir:

    - Tools vom MCP-Server abgerufen, `var tools = await GetMcpTools()`.
    - Einen Nutzer-Prompt `userMessage` definiert.
    - Ein Optionsobjekt mit Modell und Tools erstellt.
    - Eine Anfrage an das LLM gestellt.

1. Ein letzter Schritt, prüfen wir, ob das LLM denkt, dass wir eine Funktion aufrufen sollten:

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

    Im obigen Code haben wir:

    - Über eine Liste von Funktionsaufrufen iteriert.
    - Für jeden Tool-Aufruf Name und Argumente geparst und das Tool auf dem MCP-Server mit dem MCP-Client aufgerufen. Zum Schluss die Ergebnisse ausgegeben.

Hier der vollständige Code:

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

Im obigen Code haben wir:

- Einfache natürliche Sprach-Prompts verwendet, um mit den MCP-Server-Tools zu interagieren
- Das LangChain4j-Framework übernimmt automatisch:
  - Die Umwandlung von Nutzer-Prompts in Tool-Aufrufe, wenn nötig
  - Das Aufrufen der passenden MCP-Tools basierend auf der Entscheidung des LLM
  - Die Steuerung des Gesprächsflusses zwischen LLM und MCP-Server
- Die Methode `bot.chat()` liefert natürliche Sprachantworten, die Ergebnisse von MCP-Tool-Ausführungen enthalten können
- Dieser Ansatz bietet eine nahtlose Nutzererfahrung, bei der Nutzer nichts von der zugrundeliegenden MCP-Implementierung wissen müssen

Vollständiges Codebeispiel:

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

Super, du hast es geschafft!

## Aufgabe

Nimm den Code aus der Übung und erweitere den Server um weitere Tools. Erstelle dann einen Client mit einem LLM, wie in der Übung, und teste ihn mit verschiedenen Prompts, um sicherzustellen, dass alle Server-Tools dynamisch aufgerufen werden. Diese Art, einen Client zu bauen, sorgt für eine großartige Nutzererfahrung, da Nutzer Prompts verwenden können, statt exakte Client-Befehle, und nichts von einem MCP-Server mitbekommen.

## Lösung

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Wichtige Erkenntnisse

- Ein LLM zum Client hinzuzufügen bietet eine bessere Möglichkeit für Nutzer, mit MCP-Servern zu interagieren.
- Du musst die MCP-Server-Antwort in ein Format umwandeln, das das LLM versteht.

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

## Was kommt als Nächstes

- Nächstes: [Einen Server mit Visual Studio Code konsumieren](../04-vscode/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.