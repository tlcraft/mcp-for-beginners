<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T18:50:36+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "no"
}
-->
# Lage en klient med LLM

Så langt har du sett hvordan man lager en server og en klient. Klienten har kunnet kalle serveren eksplisitt for å liste opp verktøy, ressurser og prompts. Men dette er ikke en særlig praktisk tilnærming. Brukeren din lever i en agentisk tidsalder og forventer å bruke prompts og kommunisere med en LLM for å gjøre dette. For brukeren din spiller det ingen rolle om du bruker MCP eller ikke for å lagre funksjonalitetene dine, men de forventer å kunne bruke naturlig språk for å samhandle. Hvordan løser vi dette? Løsningen er å legge til en LLM i klienten.

## Oversikt

I denne leksjonen fokuserer vi på å legge til en LLM i klienten og viser hvordan dette gir en mye bedre opplevelse for brukeren.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Lage en klient med en LLM.
- Sømløst samhandle med en MCP-server ved hjelp av en LLM.
- Gi en bedre sluttbrukeropplevelse på klientsiden.

## Tilnærming

La oss prøve å forstå tilnærmingen vi må ta. Å legge til en LLM høres enkelt ut, men hvordan gjør vi det egentlig?

Slik vil klienten samhandle med serveren:

1. Etablere forbindelse med serveren.

1. Liste opp funksjonaliteter, prompts, ressurser og verktøy, og lagre skjemaene deres.

1. Legge til en LLM og sende de lagrede funksjonalitetene og skjemaene i et format som LLM-en forstår.

1. Håndtere en brukerprompt ved å sende den til LLM-en sammen med verktøyene som klienten har listet opp.

Flott, nå som vi forstår hvordan vi kan gjøre dette på et overordnet nivå, la oss prøve det ut i øvelsen nedenfor.

## Øvelse: Lage en klient med en LLM

I denne øvelsen skal vi lære å legge til en LLM i klienten vår.

## Autentisering med GitHub Personal Access Token

Å lage en GitHub-token er en enkel prosess. Slik gjør du det:

- Gå til GitHub Settings – Klikk på profilbildet ditt øverst til høyre og velg Settings.
- Naviger til Developer Settings – Scroll ned og klikk på Developer Settings.
- Velg Personal Access Tokens – Klikk på Personal access tokens og deretter Generate new token.
- Konfigurer tokenen – Legg til en notat for referanse, sett en utløpsdato, og velg nødvendige scopes (tillatelser).
- Generer og kopier tokenen – Klikk Generate token, og sørg for å kopiere den med en gang, siden du ikke får se den igjen.

### -1- Koble til server

La oss først lage klienten vår:

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

I koden over har vi:

- Importert nødvendige biblioteker
- Laget en klasse med to medlemmer, `client` og `openai`, som hjelper oss med å administrere en klient og samhandle med en LLM.
- Konfigurert LLM-instansen vår til å bruke GitHub Models ved å sette `baseUrl` til inferens-APIet.

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

I koden over har vi:

- Importert nødvendige biblioteker for MCP
- Opprettet en klient

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

Først må du legge til LangChain4j-avhengigheter i `pom.xml`-filen din. Legg til disse avhengighetene for å aktivere MCP-integrasjon og støtte for GitHub Models:

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

Deretter lager du Java-klientklassen din:

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

I koden over har vi:

- **Lagt til LangChain4j-avhengigheter**: Nødvendig for MCP-integrasjon, OpenAI offisiell klient og støtte for GitHub Models
- **Importert LangChain4j-bibliotekene**: For MCP-integrasjon og OpenAI chat-modellfunksjonalitet
- **Opprettet en `ChatLanguageModel`**: Konfigurert til å bruke GitHub Models med din GitHub-token
- **Satt opp HTTP-transport**: Ved bruk av Server-Sent Events (SSE) for å koble til MCP-serveren
- **Opprettet en MCP-klient**: Som håndterer kommunikasjon med serveren
- **Brukt LangChain4j sin innebygde MCP-støtte**: Som forenkler integrasjonen mellom LLM-er og MCP-servere

Flott, neste steg er å liste opp funksjonalitetene på serveren.

### -2- Liste serverfunksjonaliteter

Nå skal vi koble til serveren og spørre om dens funksjonaliteter:

### TypeScript

I samme klasse, legg til følgende metoder:

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

I koden over har vi:

- Lagt til kode for å koble til serveren, `connectToServer`.
- Opprettet en `run`-metode som håndterer appens flyt. Så langt lister den bare opp verktøy, men vi vil snart legge til mer.

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

Dette har vi lagt til:

- Listet opp ressurser og verktøy og skrevet dem ut. For verktøyene lister vi også `inputSchema` som vi bruker senere.

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

I koden over har vi:

- Listet opp verktøyene som er tilgjengelige på MCP-serveren
- For hvert verktøy listet navn, beskrivelse og skjema. Sistnevnte bruker vi for å kalle verktøyene snart.

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

I koden over har vi:

- Opprettet en `McpToolProvider` som automatisk oppdager og registrerer alle verktøy fra MCP-serveren
- Verktøyleverandøren håndterer konverteringen mellom MCP-verktøyskjemaer og LangChain4j sitt verktøyformat internt
- Denne tilnærmingen skjuler den manuelle prosessen med å liste opp og konvertere verktøy

### -3- Konverter serverfunksjonaliteter til LLM-verktøy

Neste steg etter å ha listet opp serverfunksjonaliteter er å konvertere dem til et format som LLM-en forstår. Når vi har gjort det, kan vi tilby disse funksjonalitetene som verktøy til LLM-en.

### TypeScript

1. Legg til følgende kode for å konvertere responsen fra MCP-serveren til et verktøyformat som LLM-en kan bruke:

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

    Koden over tar en respons fra MCP-serveren og konverterer den til et verktøydefinisjonsformat som LLM-en forstår.

1. La oss oppdatere `run`-metoden for å liste opp serverfunksjonaliteter:

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

    I koden over har vi oppdatert `run`-metoden til å gå gjennom resultatet og for hver oppføring kalle `openAiToolAdapter`.

### Python

1. Først lager vi følgende konverteringsfunksjon:

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

    I funksjonen `convert_to_llm_tools` tar vi en MCP-verktøyrespons og konverterer den til et format som LLM-en kan forstå.

1. Deretter oppdaterer vi klientkoden for å bruke denne funksjonen slik:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Her legger vi til et kall til `convert_to_llm_tool` for å konvertere MCP-verktøyresponsen til noe vi kan sende til LLM-en senere.

### .NET

1. La oss legge til kode for å konvertere MCP-verktøyresponsen til noe LLM-en kan forstå:

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

I koden over har vi:

- Opprettet en funksjon `ConvertFrom` som tar navn, beskrivelse og input-skjema.
- Definert funksjonalitet som lager en FunctionDefinition som sendes til en ChatCompletionsDefinition. Sistnevnte er noe LLM-en kan forstå.

1. La oss se hvordan vi kan oppdatere eksisterende kode for å bruke denne funksjonen:

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

    I koden over har vi:

    - Oppdatert funksjonen for å konvertere MCP-verktøyresponsen til et LLM-verktøy. La oss fremheve koden vi la til:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Input-skjemaet er en del av verktøyresponsen, men ligger under "properties"-attributtet, så vi må hente det ut. Videre kaller vi nå `ConvertFrom` med verktøydetaljene. Nå som vi har gjort det tunge arbeidet, la oss se hvordan dette fungerer når vi håndterer en brukerprompt.

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

I koden over har vi:

- Definert et enkelt `Bot`-grensesnitt for naturlige språkinteraksjoner
- Brukt LangChain4j sin `AiServices` for automatisk å binde LLM med MCP-verktøyleverandøren
- Rammeverket håndterer automatisk konvertering av verktøyskjemaer og funksjonskall i bakgrunnen
- Denne tilnærmingen eliminerer manuell verktøykonvertering – LangChain4j tar seg av all kompleksiteten med å konvertere MCP-verktøy til LLM-kompatibelt format

Flott, nå er vi klare til å håndtere brukerforespørsler, så la oss ta for oss det neste.

### -4- Håndtere brukerprompt-forespørsel

I denne delen av koden skal vi håndtere brukerforespørsler.

### TypeScript

1. Legg til en metode som skal brukes for å kalle LLM-en:

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

    I koden over har vi:

    - Lagt til en metode `callTools`.
    - Metoden tar en LLM-respons og sjekker hvilke verktøy som er kalt, om noen:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Kaller et verktøy hvis LLM-en indikerer at det skal kalles:

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

1. Oppdater `run`-metoden til å inkludere kall til LLM og `callTools`:

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

Flott, her er hele koden samlet:

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

1. La oss legge til noen imports som trengs for å kalle en LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Deretter legger vi til funksjonen som kaller LLM-en:

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

    I koden over har vi:

    - Sendt funksjonene våre, som vi fant på MCP-serveren og konverterte, til LLM-en.
    - Deretter kalt LLM-en med disse funksjonene.
    - Så undersøker vi resultatet for å se hvilke funksjoner vi bør kalle, om noen.
    - Til slutt sender vi en liste med funksjoner som skal kalles.

1. Siste steg, la oss oppdatere hovedkoden:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Der, det var siste steg. I koden over:

    - Kaller vi et MCP-verktøy via `call_tool` ved å bruke en funksjon som LLM-en mente vi burde kalle basert på prompten vår.
    - Skriver ut resultatet av verktøykallet til MCP-serveren.

### .NET

1. La oss vise litt kode for å gjøre en LLM-prompt-forespørsel:

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

    I koden over har vi:

    - Hentet verktøy fra MCP-serveren, `var tools = await GetMcpTools()`.
    - Definert en brukerprompt `userMessage`.
    - Konstruert et options-objekt som spesifiserer modell og verktøy.
    - Gjort en forespørsel til LLM-en.

1. Et siste steg, la oss se om LLM-en mener vi bør kalle en funksjon:

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

    I koden over har vi:

    - Gått gjennom en liste med funksjonskall.
    - For hvert verktøykall, hentet ut navn og argumenter og kalt verktøyet på MCP-serveren ved hjelp av MCP-klienten. Til slutt skriver vi ut resultatene.

Her er koden i sin helhet:

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

I koden over har vi:

- Brukt enkle naturlige språk-prompts for å samhandle med MCP-serververktøyene
- LangChain4j-rammeverket håndterer automatisk:
  - Konvertering av brukerprompts til verktøykall når det trengs
  - Kall til riktige MCP-verktøy basert på LLM-ens avgjørelse
  - Håndtering av samtaleflyten mellom LLM og MCP-server
- `bot.chat()`-metoden returnerer naturlige språk-svar som kan inkludere resultater fra MCP-verktøykjøringer
- Denne tilnærmingen gir en sømløs brukeropplevelse der brukerne ikke trenger å vite om den underliggende MCP-implementasjonen

Fullstendig kodeeksempel:

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

Flott, du klarte det!

## Oppgave

Ta koden fra øvelsen og bygg ut serveren med flere verktøy. Lag deretter en klient med en LLM, som i øvelsen, og test den med ulike prompts for å sikre at alle serververktøyene dine blir kalt dynamisk. Denne måten å bygge en klient på gir sluttbrukeren en god opplevelse, siden de kan bruke naturlige språk-prompts i stedet for eksakte klientkommandoer, og de trenger ikke å vite at en MCP-server blir kalt.

## Løsning

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktige punkter

- Å legge til en LLM i klienten gir en bedre måte for brukere å samhandle med MCP-servere på.
- Du må konvertere MCP-serverens respons til noe LLM-en kan forstå.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ekstra ressurser

## Hva nå

- Neste: [Consuming a server using Visual Studio Code](../04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.