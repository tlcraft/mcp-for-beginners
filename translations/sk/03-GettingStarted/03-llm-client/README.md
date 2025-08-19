<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T19:20:11+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sk"
}
-->
# Vytvorenie klienta s LLM

Doteraz ste videli, ako vytvoriť server a klienta. Klient mohol explicitne volať server, aby získal zoznam jeho nástrojov, zdrojov a promptov. Avšak, nie je to veľmi praktický prístup. Váš používateľ žije v agentickej ére a očakáva, že bude používať prompty a komunikovať s LLM. Pre vášho používateľa nie je dôležité, či používate MCP na ukladanie svojich schopností, ale očakáva, že bude komunikovať prirodzeným jazykom. Ako to teda vyriešime? Riešením je pridať LLM do klienta.

## Prehľad

V tejto lekcii sa zameriame na pridanie LLM do vášho klienta a ukážeme, ako to poskytuje oveľa lepší zážitok pre vášho používateľa.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Vytvoriť klienta s LLM.
- Bezproblémovo komunikovať so serverom MCP pomocou LLM.
- Poskytnúť lepší používateľský zážitok na strane klienta.

## Prístup

Poďme si najprv vysvetliť, aký prístup potrebujeme zvoliť. Pridanie LLM znie jednoducho, ale ako to vlastne urobíme?

Takto bude klient komunikovať so serverom:

1. Nadviazanie spojenia so serverom.

1. Získanie zoznamu schopností, výziev, zdrojov a nástrojov a uloženie ich schémy.

1. Pridanie LLM a odovzdanie uložených schopností a ich schémy vo formáte, ktorému LLM rozumie.

1. Spracovanie používateľskej výzvy jej odovzdaním LLM spolu s nástrojmi uvedenými klientom.

Skvelé, teraz rozumieme, ako to môžeme urobiť na vysokej úrovni, poďme si to vyskúšať v nasledujúcom cvičení.

## Cvičenie: Vytvorenie klienta s LLM

V tomto cvičení sa naučíme, ako pridať LLM do nášho klienta.

### Overenie pomocou GitHub Personal Access Token

Vytvorenie GitHub tokenu je jednoduchý proces. Tu je návod, ako na to:

- Prejdite do nastavení GitHubu – Kliknite na svoj profilový obrázok v pravom hornom rohu a vyberte Nastavenia.
- Prejdite do Developer Settings – Posuňte sa nadol a kliknite na Developer Settings.
- Vyberte Personal Access Tokens – Kliknite na Personal access tokens a potom na Generate new token.
- Nakonfigurujte svoj token – Pridajte poznámku pre referenciu, nastavte dátum vypršania platnosti a vyberte potrebné oprávnenia (scopes).
- Generujte a skopírujte token – Kliknite na Generovať token a uistite sa, že ho okamžite skopírujete, pretože ho už nebudete môcť znova zobraziť.

### -1- Pripojenie k serveru

Najprv vytvorme nášho klienta:

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

V predchádzajúcom kóde sme:

- Importovali potrebné knižnice.
- Vytvorili triedu s dvoma členmi, `client` a `openai`, ktoré nám pomôžu spravovať klienta a komunikovať s LLM.
- Nakonfigurovali inštanciu LLM na používanie GitHub Models nastavením `baseUrl`, aby ukazoval na inferenčné API.

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

V predchádzajúcom kóde sme:

- Importovali potrebné knižnice pre MCP.
- Vytvorili klienta.

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

Najprv budete musieť pridať závislosti LangChain4j do vášho súboru `pom.xml`. Pridajte tieto závislosti na umožnenie integrácie MCP a podpory GitHub Models:

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

Potom vytvorte triedu klienta v Jave:

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

V predchádzajúcom kóde sme:

- **Pridali závislosti LangChain4j**: Potrebné pre integráciu MCP, oficiálneho OpenAI klienta a podporu GitHub Models
- **Naimportovali knižnice LangChain4j**: Pre integráciu MCP a funkčnosť OpenAI chat modelu
- **Vytvorili `ChatLanguageModel`**: Nakonfigurovaný na použitie GitHub Models s vaším GitHub tokenom
- **Nastavili HTTP transport**: Použitím Server-Sent Events (SSE) na pripojenie k MCP serveru
- **Vytvorili MCP klienta**: Ktorý bude spravovať komunikáciu so serverom
- **Použili vstavanú podporu MCP v LangChain4j**: Čo zjednodušuje integráciu medzi LLM a MCP servermi

Skvelé, v ďalšom kroku si vypíšeme schopnosti servera.

### -2- Výpis schopností servera

Teraz sa pripojíme k serveru a požiadame o jeho schopnosti:

#### TypeScript

V tej istej triede pridajte nasledujúce metódy:

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

V predchádzajúcom kóde sme:

- Pridali kód na pripojenie k serveru, `connectToServer`.
- Vytvorili metódu `run`, ktorá riadi tok aplikácie. Zatiaľ iba vypisuje nástroje, ale čoskoro pridáme viac.

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

Tu je to, čo sme pridali:

- Výpis zdrojov a nástrojov a ich vytlačenie. Pre nástroje sme tiež vypísali `inputSchema`, ktoré použijeme neskôr.

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

V predchádzajúcom kóde sme:

- Vypísali nástroje dostupné na MCP serveri
- Pre každý nástroj sme vypísali názov, popis a jeho schému. Túto schému použijeme na volanie nástrojov čoskoro.

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

V predchádzajúcom kóde sme:

- Vytvorili `McpToolProvider`, ktorý automaticky objavuje a registruje všetky nástroje zo servera MCP
- Poskytovateľ nástrojov interné spracováva konverziu medzi MCP schémami nástrojov a formátom nástrojov LangChain4j
- Tento prístup abstrahuje manuálny výpis a konverziu nástrojov

### -3- Konverzia schopností servera na nástroje LLM

Ďalším krokom po výpise schopností servera je ich konverzia do formátu, ktorému LLM rozumie. Keď to urobíme, môžeme tieto schopnosti poskytnúť ako nástroje nášmu LLM.

#### TypeScript

1. Pridajte nasledujúci kód na konverziu odpovede zo servera MCP na formát nástroja, ktorý môže LLM použiť:

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

    Tento kód vezme odpoveď z MCP servera a prevedie ju do definície nástroja, ktorej LLM rozumie.

1. Aktualizujme metódu `run`, aby vypísala schopnosti servera:

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

    V predchádzajúcom kóde sme aktualizovali metódu `run`, aby prešla výsledkami a pre každý záznam zavolala `openAiToolAdapter`.

#### Python

1. Najprv vytvorme nasledujúcu konverznú funkciu:

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

    Vo vyššie uvedenej funkcii `convert_to_llm_tools` berieme odpoveď nástroja MCP a konvertujeme ju na formát, ktorému LLM rozumie.

1. Potom aktualizujme kód klienta, aby využíval túto funkciu takto:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Tu pridávame volanie `convert_to_llm_tool`, aby sme konvertovali odpoveď nástroja MCP na niečo, čo môžeme neskôr odovzdať LLM.

#### .NET

1. Pridajme kód na konverziu odpovede MCP nástroja do formátu, ktorému LLM rozumie:

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

V predchádzajúcom kóde sme:

- Vytvorili funkciu `ConvertFrom`, ktorá prijíma názov, popis a vstupnú schému.
- Definovali funkcionalitu, ktorá vytvára `FunctionDefinition`, ktorý sa odovzdáva do `ChatCompletionsDefinition`. To je formát, ktorému LLM rozumie.

1. Pozrime sa, ako môžeme aktualizovať existujúci kód, aby využíval túto funkciu:

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

    V predchádzajúcom kóde sme:

    - Aktualizovali funkciu na konverziu odpovede nástroja MCP na nástroj LLM. Poďme zvýrazniť pridaný kód:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Vstupná schéma je súčasťou odpovede nástroja, ale v atribúte "properties", takže ju musíme extrahovať. Následne voláme `ConvertFrom` s detailmi nástroja. Teraz, keď máme túto ťažkú prácu hotovú, pozrime sa, ako to funguje pri spracovaní používateľského promptu.

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

V predchádzajúcom kóde sme:

- Definovali jednoduché rozhranie `Bot` pre interakcie v prirodzenom jazyku.
- Použili `AiServices` z LangChain4j na automatické prepojenie LLM s poskytovateľom nástrojov MCP.
- Rámec automaticky spracováva konverziu schém nástrojov MCP a volanie funkcií na pozadí.
- Tento prístup eliminuje manuálnu konverziu nástrojov - LangChain4j spracováva všetku zložitosť konverzie nástrojov MCP na formát kompatibilný s LLM.

#### Rust

Na konverziu odpovede nástroja MCP na formát, ktorému LLM rozumie, pridáme pomocnú funkciu, ktorá formátuje zoznam nástrojov. Pridajte nasledujúci kód do vášho súboru `main.rs` pod funkciu `main`. Táto funkcia sa bude volať pri odosielaní požiadaviek na LLM:

```rust
async fn format_tools(tools: &ListToolsResult) -> Result<Vec<Value>, Box<dyn Error>> {
    let tools_json = serde_json::to_value(tools)?;
    let Some(tools_array) = tools_json.get("tools").and_then(|t| t.as_array()) else {
        return Ok(vec![]);
    };

    let formatted_tools = tools_array
        .iter()
        .filter_map(|tool| {
            let name = tool.get("name")?.as_str()?;
            let description = tool.get("description")?.as_str()?;
            let schema = tool.get("inputSchema")?;

            Some(json!({
                "type": "function",
                "function": {
                    "name": name,
                    "description": description,
                    "parameters": {
                        "type": "object",
                        "properties": schema.get("properties").unwrap_or(&json!({})),
                        "required": schema.get("required").unwrap_or(&json!([]))
                    }
                }
            }))
        })
        .collect();

    Ok(formatted_tools)
}
```

Skvelé, teraz sme pripravení spracovať akékoľvek používateľské požiadavky, takže sa na to pozrime ďalej.

### -4- Spracovanie používateľského promptu

V tejto časti kódu budeme spracovávať požiadavky používateľa.

#### TypeScript

1. Pridajte metódu, ktorá sa bude používať na volanie nášho LLM:

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

    V predchádzajúcom kóde sme:

    - Pridali metódu `callTools`.
    - Metóda prijíma odpoveď LLM a kontroluje, ktoré nástroje boli volané, ak vôbec:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Volá nástroj, ak LLM naznačuje, že by mal byť volaný:

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

1. Aktualizujte metódu `run`, aby zahŕňala volania LLM a volanie `callTools`:

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

Skvelé, tu je celý kód:

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

1. Pridajme niektoré importy potrebné na volanie LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Ďalej pridajme funkciu, ktorá bude volať LLM:

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

    V predchádzajúcom kóde sme:

    - Odovzdali funkcie, ktoré sme našli na MCP serveri a konvertovali, LLM.
    - Zavolali LLM s týmito funkciami.
    - Skontrolovali výsledok, aby sme zistili, ktoré funkcie by sme mali volať, ak vôbec.
    - Nakoniec sme odovzdali pole funkcií na volanie.

1. Posledný krok, aktualizujme náš hlavný kód:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Tam, to bol posledný krok, v kóde vyššie:

    - Voláme nástroj MCP cez `call_tool` pomocou funkcie, ktorú LLM považovalo za vhodnú na základe našej výzvy.
    - Tlačíme výsledok volania nástroja na server MCP.

#### .NET

1. Ukážme kód na vykonanie požiadavky na LLM prompt:

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

    V predchádzajúcom kóde sme:

    - Získali nástroje zo servera MCP, `var tools = await GetMcpTools()`.
    - Definovali používateľskú výzvu `userMessage`.
    - Vytvorili objekt možností špecifikujúci model a nástroje.
    - Urobili požiadavku na LLM.

1. Posledný krok, pozrime sa, či LLM navrhuje volať nejakú funkciu:

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

    V predchádzajúcom kóde sme:

    - Prešli zoznam volaní funkcií.
    - Pre každé volanie nástroja sme rozparsovali názov a argumenty a zavolali nástroj na MCP serveri pomocou MCP klienta. Nakoniec sme vytlačili výsledky.

Tu je celý kód:

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

V predchádzajúcom kóde sme:

- Použili jednoduché výzvy v prirodzenom jazyku na interakciu s nástrojmi servera MCP.
- Rámec LangChain4j automaticky spracováva:
  - Konverziu používateľských výziev na volania nástrojov, keď je to potrebné.
  - Volanie príslušných nástrojov MCP na základe rozhodnutia LLM.
  - Správu toku konverzácie medzi LLM a serverom MCP.
- Metóda `bot.chat()` vracia odpovede v prirodzenom jazyku, ktoré môžu obsahovať výsledky vykonania nástrojov MCP.
- Tento prístup poskytuje bezproblémový používateľský zážitok, kde používatelia nemusia vedieť o podkladovej implementácii MCP.

Kompletný príklad kódu:

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

Skvelé, podarilo sa vám to!

## Zadanie

Použite kód z cvičenia a rozšírte server o ďalšie nástroje. Potom vytvorte klienta s LLM, ako v cvičení, a otestujte ho s rôznymi promptmi, aby ste sa uistili, že všetky nástroje servera sa volajú dynamicky. Tento spôsob vytvárania klienta zabezpečí, že koncový používateľ bude mať skvelý zážitok, pretože môže používať prompty namiesto presných príkazov klienta a nebude si musieť uvedomovať, že sa volá MCP server.

## Riešenie

[Riešenie](/03-GettingStarted/03-llm-client/solution/README.md)

## Kľúčové poznatky

- Pridanie LLM do klienta poskytuje lepší spôsob, ako môžu používatelia komunikovať so servermi MCP.
- Je potrebné konvertovať odpoveď MCP servera do formátu, ktorému LLM rozumie.

## Príklady

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)
- [Rust Kalkulačka](../../../../03-GettingStarted/samples/rust)

## Ďalšie zdroje

## Čo ďalej

- Ďalej: [Používanie servera vo Visual Studio Code](../04-vscode/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.