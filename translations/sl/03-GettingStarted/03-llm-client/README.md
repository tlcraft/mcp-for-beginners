<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T12:26:01+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
# Ustvarjanje odjemalca z LLM

Do zdaj ste videli, kako ustvariti strežnik in odjemalca. Odjemalec je lahko izrecno poklical strežnik, da je naštel njegove orodja, vire in pozive. Vendar to ni najbolj praktičen pristop. Vaš uporabnik živi v dobi agentov in pričakuje, da bo uporabljal pozive ter komuniciral z LLM. Za vašega uporabnika ni pomembno, ali uporabljate MCP za shranjevanje svojih zmogljivosti, pričakuje pa, da bo lahko komuniciral v naravnem jeziku. Kako torej to rešimo? Rešitev je dodajanje LLM v odjemalca.

## Pregled

V tej lekciji se osredotočamo na dodajanje LLM v vaš odjemalec in pokažemo, kako to uporabniku omogoča veliko boljšo izkušnjo.

## Cilji učenja

Do konca te lekcije boste znali:

- Ustvariti odjemalca z LLM.
- Brezhibno komunicirati z MCP strežnikom z uporabo LLM.
- Zagotoviti boljšo uporabniško izkušnjo na strani odjemalca.

## Pristop

Poskusimo razumeti pristop, ki ga moramo uporabiti. Dodajanje LLM se sliši preprosto, a ali bomo to res naredili?

Tako bo odjemalec komuniciral s strežnikom:

1. Vzpostavi povezavo s strežnikom.

1. Našteje zmogljivosti, pozive, vire in orodja ter shrani njihov shematski opis.

1. Doda LLM in posreduje shranjene zmogljivosti in njihov shematski opis v obliki, ki jo LLM razume.

1. Obdeluje uporabniški poziv tako, da ga posreduje LLM skupaj z orodji, ki jih je odjemalec naštel.

Odlično, zdaj ko razumemo, kako to narediti na visoki ravni, poskusimo v spodnji vaji.

## Vaja: Ustvarjanje odjemalca z LLM

V tej vaji se bomo naučili, kako dodati LLM v naš odjemalec.

## Avtentikacija z GitHub osebni dostopni žeton

Ustvarjanje GitHub žetona je preprost postopek. Tako ga lahko naredite:

- Pojdite v GitHub Nastavitve – Kliknite na svojo profilno sliko v zgornjem desnem kotu in izberite Nastavitve.
- Pomaknite se do Nastavitve razvijalca – Pomaknite se navzdol in kliknite na Nastavitve razvijalca.
- Izberite Osebne dostopne žetone – Kliknite na Osebni dostopni žetoni in nato Ustvari nov žeton.
- Konfigurirajte svoj žeton – Dodajte opombo za referenco, nastavite datum poteka in izberite potrebne obsege (dovoljenja).
- Ustvarite in kopirajte žeton – Kliknite Ustvari žeton in ga takoj kopirajte, saj ga kasneje ne boste mogli več videti.

### -1- Povezava s strežnikom

Najprej ustvarimo našega odjemalca:

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

V zgornji kodi smo:

- Uvozili potrebne knjižnice
- Ustvarili razred z dvema članoma, `client` in `openai`, ki nam pomagata upravljati odjemalca in komunicirati z LLM.
- Konfigurirali naš LLM primerek, da uporablja GitHub modele tako, da smo nastavili `baseUrl` na inference API.

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

V zgornji kodi smo:

- Uvozili potrebne knjižnice za MCP
- Ustvarili odjemalca

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

Najprej morate v datoteko `pom.xml` dodati odvisnosti LangChain4j. Dodajte te odvisnosti za omogočanje integracije MCP in podpore GitHub modelom:

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

Nato ustvarite svojo Java odjemalsko razredno datoteko:

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

V zgornji kodi smo:

- **Dodali odvisnosti LangChain4j**: Potrebne za integracijo MCP, uradni OpenAI odjemalec in podporo GitHub modelom
- **Uvozili knjižnice LangChain4j**: Za integracijo MCP in funkcionalnost OpenAI klepetalnega modela
- **Ustvarili `ChatLanguageModel`**: Konfiguriran za uporabo GitHub modelov z vašim GitHub žetonom
- **Nastavili HTTP transport**: Z uporabo Server-Sent Events (SSE) za povezavo s MCP strežnikom
- **Ustvarili MCP odjemalca**: Ki bo upravljal komunikacijo s strežnikom
- **Uporabili vgrajeno podporo MCP v LangChain4j**: Kar poenostavi integracijo med LLM in MCP strežniki

Odlično, za naslednji korak pa naštimo zmogljivosti strežnika.

### -2 Naštejmo zmogljivosti strežnika

Zdaj se bomo povezali s strežnikom in povprašali po njegovih zmogljivostih:

### TypeScript

V istem razredu dodajte naslednje metode:

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

V zgornji kodi smo:

- Dodali kodo za povezavo s strežnikom, `connectToServer`.
- Ustvarili metodo `run`, ki upravlja potek aplikacije. Do zdaj samo navaja orodja, kmalu pa bomo dodali še več.

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

Tukaj smo dodali:

- Naštevanje virov in orodij ter njihovo izpisovanje. Za orodja smo prav tako našteli `inputSchema`, ki ga bomo kasneje uporabili.

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

V zgornji kodi smo:

- Našteli orodja, ki so na voljo na MCP strežniku
- Za vsako orodje našteli ime, opis in njegov shematski opis. Ta zadnji je nekaj, kar bomo kmalu uporabili za klic orodij.

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

V zgornji kodi smo:

- Ustvarili `McpToolProvider`, ki samodejno odkrije in registrira vsa orodja s MCP strežnika
- Ponudnik orodij interno upravlja pretvorbo med MCP orodnimi shemami in formatom orodij LangChain4j
- Ta pristop odpravlja ročno naštetje in pretvorbo orodij

### -3- Pretvorba zmogljivosti strežnika v LLM orodja

Naslednji korak po naštetju zmogljivosti strežnika je njihova pretvorba v format, ki ga LLM razume. Ko to naredimo, lahko te zmogljivosti ponudimo kot orodja našemu LLM.

### TypeScript

1. Dodajte naslednjo kodo za pretvorbo odgovora MCP strežnika v format orodja, ki ga LLM lahko uporablja:

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

    Zgornja koda vzame odgovor MCP strežnika in ga pretvori v definicijo orodja, ki jo LLM razume.

1. Posodobimo metodo `run`, da našteje zmogljivosti strežnika:

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

    V zgornji kodi smo posodobili metodo `run`, da prehaja skozi rezultat in za vsak vnos kliče `openAiToolAdapter`.

### Python

1. Najprej ustvarimo naslednjo funkcijo za pretvorbo

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

    V funkciji `convert_to_llm_tools` vzamemo odgovor MCP orodja in ga pretvorimo v format, ki ga LLM razume.

1. Nato posodobimo našo kodo odjemalca, da uporabi to funkcijo:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Tukaj dodajamo klic `convert_to_llm_tool`, da pretvorimo odgovor MCP orodja v nekaj, kar lahko kasneje posredujemo LLM.

### .NET

1. Dodajmo kodo za pretvorbo odgovora MCP orodja v nekaj, kar LLM razume

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

V zgornji kodi smo:

- Ustvarili funkcijo `ConvertFrom`, ki sprejme ime, opis in vhodni shematski opis.
- Določili funkcionalnost, ki ustvari `FunctionDefinition`, ki se posreduje `ChatCompletionsDefinition`. To je nekaj, kar LLM razume.

1. Poglejmo, kako lahko posodobimo obstoječo kodo, da izkoristimo to funkcijo:

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

    V zgornji kodi smo:

    - Posodobili funkcijo, da pretvori odgovor MCP orodja v LLM orodje. Izpostavimo dodano kodo:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Vhodni shematski opis je del odgovora orodja, vendar v atributu "properties", zato ga moramo izvleči. Poleg tega zdaj kličemo `ConvertFrom` z informacijami o orodju. Ko smo opravili to zahtevno delo, poglejmo, kako se klic združi, ko obdelujemo uporabniški poziv.

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

V zgornji kodi smo:

- Določili preprost vmesnik `Bot` za interakcije v naravnem jeziku
- Uporabili LangChain4j `AiServices`, da samodejno povežemo LLM s ponudnikom MCP orodij
- Okvir samodejno upravlja pretvorbo shem orodij in klic funkcij v ozadju
- Ta pristop odpravlja ročno pretvorbo orodij – LangChain4j poskrbi za vso kompleksnost pretvorbe MCP orodij v format, združljiv z LLM

Odlično, zdaj smo pripravljeni za obdelavo uporabniških zahtev, zato se lotimo tega.

### -4- Obdelava uporabniškega poziva

V tem delu kode bomo obdelali uporabniške zahteve.

### TypeScript

1. Dodajte metodo, ki bo uporabljena za klic našega LLM:

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

    V zgornji kodi smo:

    - Dodali metodo `callTools`.
    - Metoda prejme odgovor LLM in preveri, katera orodja so bila klicana, če sploh:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Kliče orodje, če LLM nakazuje, da ga je treba poklicati:

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

1. Posodobite metodo `run`, da vključuje klice LLM in klic `callTools`:

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

Odlično, tukaj je celotna koda:

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

1. Dodajmo nekaj uvozov, potrebnih za klic LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Nato dodajmo funkcijo, ki bo klicala LLM:

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

    V zgornji kodi smo:

    - Posredovali naše funkcije, ki smo jih našli na MCP strežniku in pretvorili, LLM.
    - Nato smo poklicali LLM s temi funkcijami.
    - Nato pregledujemo rezultat, da vidimo, katere funkcije bi morali klicati, če sploh.
    - Na koncu posredujemo seznam funkcij za klic.

1. Zadnji korak, posodobimo glavno kodo:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    To je bil zadnji korak, v zgornji kodi:

    - Kličemo MCP orodje preko `call_tool` z uporabo funkcije, za katero je LLM menil, da jo moramo poklicati glede na naš poziv.
    - Izpisujemo rezultat klica orodja na MCP strežnik.

### .NET

1. Pokažimo kodo za poizvedbo LLM poziva:

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

    V zgornji kodi smo:

    - Pridobili orodja s MCP strežnika, `var tools = await GetMcpTools()`.
    - Določili uporabniški poziv `userMessage`.
    - Ustvarili objekt možnosti, ki določa model in orodja.
    - Izvedli zahtevo do LLM.

1. Zadnji korak, preverimo, ali LLM meni, da moramo poklicati funkcijo:

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

    V zgornji kodi smo:

    - Zanka skozi seznam klicev funkcij.
    - Za vsak klic orodja razčlenimo ime in argumente ter pokličemo orodje na MCP strežniku z uporabo MCP odjemalca. Na koncu izpišemo rezultate.

Tukaj je koda v celoti:

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

V zgornji kodi smo:

- Uporabili preproste pozive v naravnem jeziku za interakcijo z orodji MCP strežnika
- Okvir LangChain4j samodejno upravlja:
  - Pretvorbo uporabniških pozivov v klice orodij, kadar je to potrebno
  - Klic ustreznih MCP orodij na podlagi odločitve LLM
  - Upravljanje poteka pogovora med LLM in MCP strežnikom
- Metoda `bot.chat()` vrača odgovore v naravnem jeziku, ki lahko vključujejo rezultate izvajanja MCP orodij
- Ta pristop omogoča brezhibno uporabniško izkušnjo, kjer uporabniki ne potrebujejo vedeti za podlago MCP implementacije

Celoten primer kode:

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

Odlično, uspelo vam je!

## Naloga

Vzemite kodo iz vaje in razširite strežnik z nekaj dodatnimi orodji. Nato ustvarite odjemalca z LLM, kot v vaji, in ga preizkusite z različnimi pozivi, da zagotovite, da se vsa orodja strežnika dinamično kličejo. Ta način ustvarjanja odjemalca pomeni, da bo končni uporabnik imel odlično uporabniško izkušnjo, saj lahko uporablja pozive namesto natančnih ukazov odjemalca in ne bo vedel, da se kliče MCP strežnik.

## Rešitev

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne ugotovitve

- Dodajanje LLM v vaš odjemalec omogoča boljši način interakcije uporabnikov z MCP strežniki.
- Odgovor MCP strežnika morate pretvoriti v nekaj, kar LLM razume.

## Primeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

## Kaj sledi

- Naslednje: [Uporaba strežnika z Visual Studio Code](../04-vscode/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.