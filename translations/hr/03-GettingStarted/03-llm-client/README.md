<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T19:31:40+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hr"
}
-->
# Kreiranje klijenta s LLM-om

Do sada ste vidjeli kako kreirati server i klijenta. Klijent je mogao eksplicitno pozivati server da bi dobio popis njegovih alata, resursa i promptova. Međutim, to nije baš praktičan pristup. Vaš korisnik živi u eri agenata i očekuje da koristi promptove i komunicira s LLM-om kako bi to postigao. Za vašeg korisnika nije važno koristite li MCP za pohranu svojih mogućnosti, ali očekuju da koriste prirodni jezik za interakciju. Kako to riješiti? Rješenje je dodati LLM klijentu.

## Pregled

U ovoj lekciji fokusiramo se na dodavanje LLM-a vašem klijentu i pokazujemo kako to pruža puno bolje iskustvo za vašeg korisnika.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- Kreirati klijenta s LLM-om.
- Besprijekorno komunicirati s MCP serverom koristeći LLM.
- Pružiti bolje korisničko iskustvo na strani klijenta.

## Pristup

Pokušajmo razumjeti pristup koji trebamo poduzeti. Dodavanje LLM-a zvuči jednostavno, ali kako to zapravo učiniti?

Evo kako će klijent komunicirati sa serverom:

1. Uspostavite vezu sa serverom.

1. Popišite mogućnosti, upite, resurse i alate te spremite njihovu shemu.

1. Dodajte LLM i proslijedite spremljene mogućnosti i njihove sheme u formatu koji LLM razumije.

1. Obraditi korisnički prompt prosljeđujući ga LLM-u zajedno s alatima koje je klijent nabrojao.

Odlično, sada kada razumijemo kako to možemo napraviti na visokoj razini, isprobajmo to u sljedećoj vježbi.

## Vježba: Kreiranje klijenta s LLM-om

U ovoj vježbi naučit ćemo kako dodati LLM našem klijentu.

### Autentifikacija pomoću GitHub osobnog pristupnog tokena

Kreiranje GitHub tokena je jednostavan proces. Evo kako to možete učiniti:

- Idite na GitHub Settings – Kliknite na svoju profilnu sliku u gornjem desnom kutu i odaberite Settings.
- Navigirajte do Developer Settings – Skrolajte dolje i kliknite na Developer Settings.
- Odaberite Personal Access Tokens – Kliknite na Personal access tokens, a zatim Generate new token.
- Konfigurirajte svoj token – Dodajte bilješku za referencu, postavite datum isteka i odaberite potrebne ovlasti (permissions).
- Generirajte i kopirajte token – Kliknite Generate token i odmah ga kopirajte jer ga kasnije nećete moći vidjeti.

### -1- Povezivanje sa serverom

Prvo kreirajmo našeg klijenta:

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

U prethodnom kodu smo:

- Uvezli potrebne biblioteke
- Kreirali klasu s dva člana, `client` i `openai`, koji će nam pomoći upravljati klijentom i komunicirati s LLM-om.
- Konfigurirali naš LLM primjerak da koristi GitHub modele postavljanjem `baseUrl` na inference API.

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

U prethodnom kodu smo:

- Uvezli potrebne biblioteke za MCP.
- Kreirali klijenta.

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

Prvo, trebate dodati LangChain4j ovisnosti u svoj `pom.xml` datoteku. Dodajte ove ovisnosti za omogućavanje MCP integracije i podrške za GitHub modele:

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

Zatim kreirajte svoju Java klijentsku klasu:

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

U prethodnom kodu smo:

- **Dodali LangChain4j ovisnosti**: Potrebne za MCP integraciju, službeni OpenAI klijent i podršku za GitHub modele
- **Uvezli LangChain4j biblioteke**: Za MCP integraciju i funkcionalnost OpenAI chat modela
- **Kreirali `ChatLanguageModel`**: Konfiguriran za korištenje GitHub modela s vašim GitHub tokenom
- **Postavili HTTP transport**: Koristeći Server-Sent Events (SSE) za povezivanje s MCP serverom
- **Kreirali MCP klijenta**: Koji će upravljati komunikacijom sa serverom
- **Iskoristili ugrađenu MCP podršku LangChain4j-a**: Koja pojednostavljuje integraciju između LLM-a i MCP servera

Odlično, za sljedeći korak, nabrojimo mogućnosti na serveru.

### -2- Nabrajanje mogućnosti servera

Sada ćemo se povezati sa serverom i zatražiti njegove mogućnosti:

#### TypeScript

U istoj klasi dodajte sljedeće metode:

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

U prethodnom kodu smo:

- Dodali kod za povezivanje sa serverom, `connectToServer`.
- Kreirali metodu `run` koja upravlja tijekom aplikacije. Do sada samo nabraja alate, ali uskoro ćemo dodati još.

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

Evo što smo dodali:

- Popis resursa i alata te njihovo ispisivanje. Za alate također popisujemo `inputSchema` koji ćemo kasnije koristiti.

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

U prethodnom kodu smo:

- Nabrojali alate dostupne na MCP serveru
- Za svaki alat nabrojali ime, opis i njegovu shemu. Ovo zadnje ćemo koristiti za pozivanje alata uskoro.

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

U prethodnom kodu smo:

- Kreirali `McpToolProvider` koji automatski pronalazi i registrira sve alate s MCP servera
- Provider alata interno upravlja konverzijom između MCP shema alata i LangChain4j formata alata
- Ovaj pristup uklanja potrebu za ručnim nabrajanjem i konverzijom alata

### -3- Pretvaranje mogućnosti servera u LLM alate

Sljedeći korak nakon nabrajanja mogućnosti servera je pretvoriti ih u format koji LLM razumije. Kad to napravimo, možemo te mogućnosti ponuditi kao alate našem LLM-u.

#### TypeScript

1. Dodajte sljedeći kod za konverziju odgovora MCP servera u format alata koji LLM može koristiti:

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

    Gornji kod uzima odgovor MCP servera i konvertira ga u definiciju alata koju LLM može razumjeti.

1. Zatim ažurirajmo metodu `run` da nabroji mogućnosti servera:

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

    U prethodnom kodu smo ažurirali metodu `run` da prolazi kroz rezultat i za svaki unos poziva `openAiToolAdapter`.

#### Python

1. Prvo, kreirajmo sljedeću funkciju za konverziju:

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

    U funkciji `convert_to_llm_tools` uzimamo MCP alat i pretvaramo ga u format koji LLM može razumjeti.

1. Zatim ažurirajmo naš klijentski kod da koristi ovu funkciju ovako:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Ovdje dodajemo poziv funkciji `convert_to_llm_tool` za konverziju MCP odgovora alata u nešto što kasnije možemo proslijediti LLM-u.

#### .NET

1. Dodajmo kod za konverziju MCP odgovora alata u nešto što LLM može razumjeti:

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

U prethodnom kodu smo:

- Kreirali funkciju `ConvertFrom` koja prima ime, opis i ulaznu shemu.
- Definirali funkcionalnost koja kreira `FunctionDefinition` koja se prosljeđuje `ChatCompletionsDefinition`. Ovo zadnje LLM može razumjeti.

1. Pogledajmo kako možemo ažurirati postojeći kod kako bismo iskoristili ovu funkciju:

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

    U prethodnom kodu smo:

    - Ažurirali funkciju da pretvori MCP alat u LLM alat. Istaknimo dodani kod:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Ulazna shema je dio odgovora alata, ali u atributu "properties", pa ju treba izdvojiti. Nadalje, sada pozivamo `ConvertFrom` s detaljima alata. Sad kad smo odradili glavni dio, pogledajmo kako se poziv spaja dok obrađujemo korisnički prompt.

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

U prethodnom kodu smo:

- Definirali jednostavan `Bot` interface za interakcije prirodnim jezikom
- Koristili LangChain4j `AiServices` za automatsko povezivanje LLM-a s MCP providerom alata
- Framework automatski upravlja konverzijom shema alata i pozivima funkcija u pozadini
- Ovaj pristup uklanja ručnu konverziju alata – LangChain4j rješava svu složenost pretvaranja MCP alata u format kompatibilan s LLM-om

Odlično, sada smo spremni za obradu korisničkih zahtjeva, pa krenimo na to.

### -4- Obrada korisničkog upita

U ovom dijelu koda obradit ćemo korisničke zahtjeve.

#### TypeScript

1. Dodajte metodu koja će se koristiti za pozivanje našeg LLM-a:

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

    U prethodnom kodu smo:

    - Dodali metodu `callTools`.
    - Metoda prima odgovor LLM-a i provjerava koji su alati pozvani, ako ih ima:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Poziva alat, ako LLM naznači da bi trebao biti pozvan:

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

1. Ažurirajte metodu `run` da uključi pozive LLM-u i pozivanje `callTools`:

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

Odlično, evo koda u cijelosti:

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

1. Dodajmo neke uvoze potrebne za pozivanje LLM-a:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Zatim dodajmo funkciju koja će pozvati LLM:

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

    U prethodnom kodu smo:

    - Proslijedili funkcije koje smo pronašli na MCP serveru i pretvorili LLM-u.
    - Zatim pozvali LLM s tim funkcijama.
    - Pregledavamo rezultat da vidimo koje funkcije treba pozvati, ako ih ima.
    - Na kraju prosljeđujemo niz funkcija za pozivanje.

1. Posljednji korak, ažurirajmo naš glavni kod:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Tamo, to je bio posljednji korak, u gornjem kodu:

    - Pozivamo MCP alat preko `call_tool` koristeći funkciju koju je LLM odlučio pozvati na temelju prompta.
    - Ispisujemo rezultat poziva alata na MCP server.

#### .NET

1. Evo koda za slanje zahtjeva LLM-u:

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

    U prethodnom kodu smo:

    - Dohvatili alate s MCP servera, `var tools = await GetMcpTools()`.
    - Definirali korisnički prompt `userMessage`.
    - Kreirali objekt opcija s modelom i alatima.
    - Poslali zahtjev prema LLM-u.

1. Posljednji korak, provjerimo misli li LLM da trebamo pozvati funkciju:

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

    U prethodnom kodu smo:

    - Prošli kroz listu poziva funkcija.
    - Za svaki poziv alata parsirali ime i argumente te pozvali alat na MCP serveru koristeći MCP klijenta. Na kraju ispisali rezultate.

Evo koda u cijelosti:

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

U prethodnom kodu smo:

- Koristili jednostavne promptove prirodnog jezika za interakciju s MCP alatima servera
- LangChain4j framework automatski upravlja:
  - Pretvaranjem korisničkih promptova u pozive alata kad je potrebno
  - Pozivanjem odgovarajućih MCP alata na temelju odluke LLM-a
  - Upravljanjem tijekom razgovora između LLM-a i MCP servera
- Metoda `bot.chat()` vraća odgovore prirodnim jezikom koji mogu uključivati rezultate izvršenja MCP alata
- Ovaj pristup pruža besprijekorno korisničko iskustvo gdje korisnici ne moraju znati o pozadini MCP implementacije

Kompletan primjer koda:

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

Odlično, uspjeli ste!

## Zadatak

Uzmi kod iz vježbe i proširi server s još nekoliko alata. Zatim kreiraj klijenta s LLM-om, kao u vježbi, i testiraj ga s različitim promptovima kako bi se uvjerio da se svi alati na serveru dinamički pozivaju. Ovaj način izrade klijenta omogućuje izvrsno korisničko iskustvo jer korisnici mogu koristiti promptove umjesto točnih naredbi klijenta i ne moraju znati da se poziva MCP server.

## Rješenje

[Rješenje](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne točke

- Dodavanje LLM-a vašem klijentu pruža bolji način interakcije korisnika s MCP serverima.
- Potrebno je pretvoriti odgovor MCP servera u nešto što LLM može razumjeti.

## Primjeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)
- [Rust Kalkulator](../../../../03-GettingStarted/samples/rust)

## Dodatni resursi

## Što slijedi

- Sljedeće: [Korištenje servera pomoću Visual Studio Code-a](../04-vscode/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za nesporazume ili pogrešna tumačenja koja mogu proizaći iz korištenja ovog prijevoda.