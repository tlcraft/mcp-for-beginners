<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
<<<<<<< HEAD
  "translation_date": "2025-08-18T22:35:59+00:00",
=======
  "translation_date": "2025-08-18T17:56:12+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
# Ustvarjanje odjemalca z LLM

<<<<<<< HEAD
Do sedaj ste videli, kako ustvariti strežnik in odjemalca. Odjemalec je lahko eksplicitno klical strežnik za seznam njegovih orodij, virov in pozivov. Vendar to ni zelo praktičen pristop. Vaš uporabnik živi v agentni dobi in pričakuje, da bo uporabljal pozive in komuniciral z LLM za dosego ciljev. Uporabniku ni pomembno, ali uporabljate MCP za shranjevanje svojih zmožnosti, pričakuje pa, da bo lahko komuniciral v naravnem jeziku. Kako torej to rešimo? Rešitev je v dodajanju LLM odjemalcu.

## Pregled

V tej lekciji se osredotočamo na dodajanje LLM vašemu odjemalcu in prikaz, kako to zagotavlja veliko boljšo izkušnjo za uporabnika.

## Cilji učenja

Do konca te lekcije boste lahko:

- Ustvarili odjemalca z LLM.
- Brezhibno komunicirali z MCP strežnikom z uporabo LLM.
=======
Do sedaj ste videli, kako ustvariti strežnik in odjemalca. Odjemalec je lahko izrecno poklical strežnik, da bi pridobil seznam njegovih orodij, virov in pozivov. Vendar pa to ni zelo praktičen pristop. Vaš uporabnik živi v agentni dobi in pričakuje, da bo uporabljal pozive ter komuniciral z LLM za dosego ciljev. Uporabniku ni pomembno, ali uporabljate MCP za shranjevanje svojih zmogljivosti, pričakuje pa, da bo lahko komuniciral v naravnem jeziku. Kako torej to rešimo? Rešitev je v dodajanju LLM odjemalcu.

## Pregled

V tej lekciji se osredotočamo na dodajanje LLM odjemalcu in prikaz, kako to zagotavlja veliko boljšo izkušnjo za uporabnika.

## Cilji učenja

Na koncu te lekcije boste lahko:

- Ustvarili odjemalca z LLM.
- Brez težav komunicirali z MCP strežnikom prek LLM.
>>>>>>> origin/main
- Zagotovili boljšo uporabniško izkušnjo na strani odjemalca.

## Pristop

<<<<<<< HEAD
Poskusimo razumeti pristop, ki ga moramo uporabiti. Dodajanje LLM se sliši preprosto, vendar kako to dejansko izvedemo?
=======
Poskusimo razumeti pristop, ki ga moramo sprejeti. Dodajanje LLM se sliši preprosto, vendar ali to dejansko storimo?
>>>>>>> origin/main

Tako bo odjemalec komuniciral s strežnikom:

1. Vzpostavite povezavo s strežnikom.

<<<<<<< HEAD
1. Seznam zmožnosti, pozivov, virov in orodij ter shranite njihove sheme.

1. Dodajte LLM in posredujte shranjene zmožnosti in njihove sheme v formatu, ki ga LLM razume.

1. Obravnavajte uporabniški poziv tako, da ga posredujete LLM skupaj z orodji, ki jih je navedel odjemalec.

Odlično, zdaj razumemo, kako to lahko izvedemo na visoki ravni, poskusimo to v spodnji vaji.

## Vaja: Ustvarjanje odjemalca z LLM

V tej vaji se bomo naučili, kako dodati LLM našemu odjemalcu.

### Avtentikacija z uporabo GitHub osebnega dostopnega žetona

Ustvarjanje GitHub žetona je preprost postopek. Tukaj je, kako to storite:

- Pojdite v GitHub nastavitve – Kliknite na svojo profilno sliko v zgornjem desnem kotu in izberite Nastavitve.
=======
1. Pridobi seznam zmogljivosti, pozivov, virov in orodij ter shrani njihovo shemo.

1. Dodaj LLM in posreduj shranjene zmogljivosti ter njihove sheme v formatu, ki ga LLM razume.

1. Obravnavaj uporabniški poziv tako, da ga posreduješ LLM skupaj z orodji, ki jih je navedel odjemalec.

Odlično, zdaj razumemo, kako to lahko storimo na visoki ravni. Poskusimo to v spodnji vaji.

## Vaja: Ustvarjanje odjemalca z LLM

V tej vaji se bomo naučili dodati LLM našemu odjemalcu.

### Avtentikacija z GitHub osebnim dostopnim žetonom

Ustvarjanje GitHub žetona je preprost proces. Tukaj je, kako to storite:

- Pojdite v GitHub Nastavitve – Kliknite na svojo profilno sliko v zgornjem desnem kotu in izberite Nastavitve.
>>>>>>> origin/main
- Pomaknite se do Nastavitve za razvijalce – Pomaknite se navzdol in kliknite na Nastavitve za razvijalce.
- Izberite Osebni dostopni žetoni – Kliknite na Osebni dostopni žetoni in nato Ustvari nov žeton.
- Konfigurirajte svoj žeton – Dodajte opombo za referenco, nastavite datum poteka in izberite potrebne obsege (dovoljenja).
- Ustvarite in kopirajte žeton – Kliknite Ustvari žeton in ga takoj kopirajte, saj ga kasneje ne boste mogli več videti.

### -1- Povezava s strežnikom

Najprej ustvarimo našega odjemalca:

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

V zgornji kodi smo:

- Uvozili potrebne knjižnice.
- Ustvarili razred z dvema članoma, `client` in `openai`, ki nam bosta pomagala upravljati odjemalca in komunicirati z LLM.
<<<<<<< HEAD
- Konfigurirali našo LLM instanco za uporabo GitHub modelov z nastavitvijo `baseUrl`, ki kaže na API za sklepanje.
=======
- Konfigurirali našo LLM instanco za uporabo GitHub modelov z nastavitvijo `baseUrl`, ki kaže na inferenčni API.
>>>>>>> origin/main

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

V zgornji kodi smo:

- Uvozili potrebne knjižnice za MCP.
- Ustvarili odjemalca.

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

<<<<<<< HEAD
Najprej morate dodati odvisnosti LangChain4j v datoteko `pom.xml`. Dodajte te odvisnosti za omogočanje integracije MCP in podpore za GitHub modele:
=======
Najprej boste morali dodati odvisnosti LangChain4j v datoteko `pom.xml`. Dodajte te odvisnosti za omogočanje integracije MCP in podporo GitHub modelom:
>>>>>>> origin/main

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

<<<<<<< HEAD
Nato ustvarite razred za odjemalca v Javi:
=======
Nato ustvarite razred odjemalca v Javi:
>>>>>>> origin/main

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

<<<<<<< HEAD
- **Dodali odvisnosti LangChain4j**: Potrebne za integracijo MCP, uradni odjemalec OpenAI in podporo za GitHub modele.
- **Uvozili knjižnice LangChain4j**: Za integracijo MCP in funkcionalnost OpenAI modela za klepet.
- **Ustvarili `ChatLanguageModel`**: Konfiguriran za uporabo GitHub modelov z vašim GitHub žetonom.
- **Nastavili HTTP transport**: Z uporabo dogodkov, poslanih s strežnika (SSE), za povezavo z MCP strežnikom.
- **Ustvarili MCP odjemalca**: Ki bo upravljal komunikacijo s strežnikom.
- **Uporabili vgrajeno podporo LangChain4j za MCP**: Kar poenostavi integracijo med LLM in MCP strežniki.

#### Rust

Ta primer predpostavlja, da imate delujoč MCP strežnik, ki temelji na Rustu. Če ga nimate, se vrnite na lekcijo [01-prvi-strežnik](../01-first-server/README.md) za ustvarjanje strežnika.
=======
- **Dodali odvisnosti LangChain4j**: Potrebne za integracijo MCP, uradni odjemalec OpenAI in podporo GitHub modelom.
- **Uvozili knjižnice LangChain4j**: Za integracijo MCP in funkcionalnost OpenAI modela za klepet.
- **Ustvarili `ChatLanguageModel`**: Konfiguriran za uporabo GitHub modelov z vašim GitHub žetonom.
- **Nastavili HTTP transport**: Z uporabo dogodkov, poslanih s strežnikom (SSE), za povezavo z MCP strežnikom.
- **Ustvarili MCP odjemalca**: Ki bo upravljal komunikacijo s strežnikom.
- **Uporabili vgrajeno podporo MCP v LangChain4j**: Ki poenostavi integracijo med LLM in MCP strežniki.

#### Rust

Ta primer predpostavlja, da imate Rust MCP strežnik, ki deluje. Če ga nimate, se vrnite na lekcijo [01-prvi-strežnik](../01-first-server/README.md) za ustvarjanje strežnika.

Ko imate Rust MCP strežnik, odprite terminal in se pomaknite v isto mapo kot strežnik. Nato zaženite naslednji ukaz za ustvarjanje novega projekta odjemalca LLM:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Dodajte naslednje odvisnosti v datoteko `Cargo.toml`:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Ne obstaja uradna knjižnica za OpenAI v Rustu, vendar je `async-openai` [knjižnica, ki jo vzdržuje skupnost](https://platform.openai.com/docs/libraries/rust#rust) in se pogosto uporablja.

Odprite datoteko `src/main.rs` in zamenjajte njeno vsebino z naslednjo kodo:

```rust
use async_openai::{Client, config::OpenAIConfig};
use rmcp::{
    RmcpError,
    model::{CallToolRequestParam, ListToolsResult},
    service::{RoleClient, RunningService, ServiceExt},
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use serde_json::{Value, json};
use std::error::Error;
use tokio::process::Command;

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    // Initial message
    let mut messages = vec![json!({"role": "user", "content": "What is the sum of 3 and 2?"})];

    // Setup OpenAI client
    let api_key = std::env::var("OPENAI_API_KEY")?;
    let openai_client = Client::with_config(
        OpenAIConfig::new()
            .with_api_base("https://models.github.ai/inference/chat")
            .with_api_key(api_key),
    );

    // Setup MCP client
    let server_dir = std::path::Path::new(env!("CARGO_MANIFEST_DIR"))
        .parent()
        .unwrap()
        .join("calculator-server");

    let mcp_client = ()
        .serve(
            TokioChildProcess::new(Command::new("cargo").configure(|cmd| {
                cmd.arg("run").current_dir(server_dir);
            }))
            .map_err(RmcpError::transport_creation::<TokioChildProcess>)?,
        )
        .await?;

    // TODO: Get MCP tool listing 

    // TODO: LLM conversation with tool calls

    Ok(())
}
```

Ta koda nastavi osnovno aplikacijo v Rustu, ki se bo povezala z MCP strežnikom in GitHub modeli za interakcije z LLM.

> [!IMPORTANT]
> Pred zagonom aplikacije nastavite okoljsko spremenljivko `OPENAI_API_KEY` z vašim GitHub žetonom.

Odlično, za naslednji korak pridobimo seznam zmogljivosti na strežniku.

### -2- Pridobitev zmogljivosti strežnika
>>>>>>> origin/main

Ko imate svoj Rust MCP strežnik, odprite terminal in se pomaknite v isto mapo kot strežnik. Nato zaženite naslednji ukaz za ustvarjanje novega projekta LLM odjemalca:

<<<<<<< HEAD
```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Dodajte naslednje odvisnosti v datoteko `Cargo.toml`:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Uradna knjižnica za OpenAI v Rustu ne obstaja, vendar je `async-openai` [knjižnica, ki jo vzdržuje skupnost](https://platform.openai.com/docs/libraries/rust#rust) in se pogosto uporablja.

Odprite datoteko `src/main.rs` in njeno vsebino zamenjajte z naslednjo kodo:

```rust
use async_openai::{Client, config::OpenAIConfig};
use rmcp::{
    RmcpError,
    model::{CallToolRequestParam, ListToolsResult},
    service::{RoleClient, RunningService, ServiceExt},
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use serde_json::{Value, json};
use std::error::Error;
use tokio::process::Command;

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    // Initial message
    let mut messages = vec![json!({"role": "user", "content": "What is the sum of 3 and 2?"})];

    // Setup OpenAI client
    let api_key = std::env::var("OPENAI_API_KEY")?;
    let openai_client = Client::with_config(
        OpenAIConfig::new()
            .with_api_base("https://models.github.ai/inference/chat")
            .with_api_key(api_key),
    );

    // Setup MCP client
    let server_dir = std::path::Path::new(env!("CARGO_MANIFEST_DIR"))
        .parent()
        .unwrap()
        .join("calculator-server");

    let mcp_client = ()
        .serve(
            TokioChildProcess::new(Command::new("cargo").configure(|cmd| {
                cmd.arg("run").current_dir(server_dir);
            }))
            .map_err(RmcpError::transport_creation::<TokioChildProcess>)?,
        )
        .await?;

    // TODO: Get MCP tool listing 

    // TODO: LLM conversation with tool calls

    Ok(())
}
```

Ta koda nastavi osnovno aplikacijo v Rustu, ki se bo povezala z MCP strežnikom in GitHub modeli za interakcije z LLM.

> [!IMPORTANT]
> Pred zagonom aplikacije nastavite okoljsko spremenljivko `OPENAI_API_KEY` z vašim GitHub žetonom.

Odlično, za naš naslednji korak, poglejmo, kako našteti zmožnosti na strežniku.

### -2- Seznam zmožnosti strežnika

Zdaj se bomo povezali s strežnikom in zahtevali njegove zmožnosti:

=======
>>>>>>> origin/main
#### TypeScript

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
<<<<<<< HEAD
- Ustvarili metodo `run`, ki je odgovorna za upravljanje poteka naše aplikacije. Zaenkrat samo navaja orodja, vendar bomo kmalu dodali več.
=======
- Ustvarili metodo `run`, ki je odgovorna za upravljanje poteka naše aplikacije. Zaenkrat samo pridobi seznam orodij, vendar bomo kmalu dodali več.
>>>>>>> origin/main

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

Tukaj je, kaj smo dodali:

<<<<<<< HEAD
- Seznam virov in orodij ter jih natisnili. Za orodja smo navedli tudi `inputSchema`, ki ga bomo uporabili kasneje.
=======
- Pridobitev virov in orodij ter njihovo izpisovanje. Za orodja prav tako pridobimo `inputSchema`, ki ga uporabimo kasneje.
>>>>>>> origin/main

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

V zgornji kodi smo:

<<<<<<< HEAD
- Našteli orodja, ki so na voljo na MCP strežniku.
- Za vsako orodje navedli ime, opis in njegovo shemo. Slednje bomo uporabili za klicanje orodij kmalu.
=======
- Pridobili seznam orodij, ki so na voljo na MCP strežniku.
- Za vsako orodje pridobili ime, opis in njegovo shemo. Slednje bomo uporabili za klicanje orodij kmalu.
>>>>>>> origin/main

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

V zgornji kodi smo:

<<<<<<< HEAD
- Ustvarili `McpToolProvider`, ki samodejno odkrije in registrira vsa orodja iz MCP strežnika.
- Ponudnik orodij interno upravlja pretvorbo med shemami MCP orodij in formatom orodij LangChain4j.
- Ta pristop abstrahira ročno navajanje in pretvorbo orodij.

#### Rust

Pridobivanje orodij iz MCP strežnika se izvede z metodo `list_tools`. V funkciji `main`, po nastavitvi MCP odjemalca, dodajte naslednjo kodo:
=======
- Ustvarili `McpToolProvider`, ki samodejno odkrije in registrira vsa orodja s MCP strežnika.
- Ponudnik orodij interno upravlja pretvorbo med shemami MCP orodij in formatom orodij LangChain4j.
- Ta pristop abstrahira ročno pridobivanje in pretvorbo orodij.

#### Rust

Pridobivanje orodij s MCP strežnika se izvede z metodo `list_tools`. V funkciji `main`, po nastavitvi MCP odjemalca, dodajte naslednjo kodo:
>>>>>>> origin/main

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

<<<<<<< HEAD
### -3- Pretvorba zmožnosti strežnika v orodja LLM

Naslednji korak po navajanju zmožnosti strežnika je pretvorba teh v format, ki ga LLM razume. Ko to storimo, lahko te zmožnosti zagotovimo kot orodja za naš LLM.
=======
### -3- Pretvorba zmogljivosti strežnika v orodja LLM

Naslednji korak po pridobitvi zmogljivosti strežnika je njihova pretvorba v format, ki ga LLM razume. Ko to storimo, lahko te zmogljivosti posredujemo kot orodja LLM.
>>>>>>> origin/main

#### TypeScript

1. Dodajte naslednjo kodo za pretvorbo odgovora MCP strežnika v format orodja, ki ga LLM lahko uporabi:

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

<<<<<<< HEAD
1. Posodobimo metodo `run`, da vključuje seznam zmožnosti strežnika:
=======
1. Posodobimo metodo `run`, da pridobi zmogljivosti strežnika:
>>>>>>> origin/main

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

<<<<<<< HEAD
    V zgornji kodi smo posodobili metodo `run`, da pregleduje rezultat in za vsak vnos pokliče `openAiToolAdapter`.
=======
    V zgornji kodi smo posodobili metodo `run`, da preslika rezultat in za vsak vnos pokliče `openAiToolAdapter`.
>>>>>>> origin/main

#### Python

1. Najprej ustvarimo naslednjo funkcijo za pretvorbo:

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

    V zgornji funkciji `convert_to_llm_tools` vzamemo odgovor MCP orodja in ga pretvorimo v format, ki ga LLM razume.

<<<<<<< HEAD
1. Nato posodobimo našo kodo odjemalca, da izkoristi to funkcijo, kot sledi:
=======
1. Nato posodobimo našo kodo odjemalca, da izkoristi to funkcijo:
>>>>>>> origin/main

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Tukaj dodajamo klic funkcije `convert_to_llm_tool`, da pretvorimo odgovor MCP orodja v nekaj, kar lahko kasneje posredujemo LLM.

#### .NET

1. Dodajmo kodo za pretvorbo odgovora MCP orodja v nekaj, kar LLM lahko razume:

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

<<<<<<< HEAD
- Ustvarili funkcijo `ConvertFrom`, ki vzame ime, opis in shemo vnosa.
- Določili funkcionalnost, ki ustvari `FunctionDefinition`, ki se posreduje `ChatCompletionsDefinition`. Slednje je nekaj, kar LLM razume.
=======
- Ustvarili funkcijo `ConvertFrom`, ki sprejme ime, opis in vhodno shemo.
- Določili funkcionalnost, ki ustvari FunctionDefinition, ki se posreduje ChatCompletionsDefinition. Slednje je nekaj, kar LLM razume.
>>>>>>> origin/main

1. Poglejmo, kako lahko posodobimo obstoječo kodo, da izkoristimo zgornjo funkcijo:

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

<<<<<<< HEAD
    - Posodobili funkcijo za pretvorbo odgovora MCP orodja v orodje LLM. Izpostavimo dodano kodo:
=======
    - Posodobili funkcijo za pretvorbo odgovora MCP orodja v LLM orodje. Poudarimo dodano kodo:
>>>>>>> origin/main

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

<<<<<<< HEAD
        Shema vnosa je del odgovora orodja, vendar na atributu "properties", zato jo moramo izvleči. Poleg tega zdaj kličemo `ConvertFrom` s podrobnostmi orodja. Zdaj, ko smo opravili težko delo, poglejmo, kako se vse skupaj združi, ko obravnavamo uporabniški poziv.
=======
        Vhodna shema je del odgovora orodja, vendar na atributu "properties", zato jo moramo izvleči. Poleg tega zdaj kličemo `ConvertFrom` z detajli orodja. Zdaj, ko smo opravili težko delo, poglejmo, kako se vse skupaj združi, ko obravnavamo uporabniški poziv.
>>>>>>> origin/main

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

V zgornji kodi smo:

- Določili preprost vmesnik `Bot` za interakcije v naravnem jeziku.
- Uporabili `AiServices` iz LangChain4j za samodejno povezovanje LLM z ponudnikom MCP orodij.
<<<<<<< HEAD
- Okvir samodejno upravlja pretvorbo shem orodij in klicanje funkcij v ozadju.
- Ta pristop odpravlja ročno pretvorbo orodij - LangChain4j upravlja vso kompleksnost pretvorbe MCP orodij v format, združljiv z LLM.

#### Rust

Za pretvorbo odgovora MCP orodja v format, ki ga LLM razume, bomo dodali pomožno funkcijo, ki oblikuje seznam orodij. Dodajte naslednjo kodo v datoteko `main.rs` pod funkcijo `main`. To bo uporabljeno pri pošiljanju zahtev LLM:
=======
- Okvir samodejno upravlja pretvorbo shem orodij MCP in klic funkcij v ozadju.
- Ta pristop odpravi ročno pretvorbo orodij - LangChain4j upravlja vso kompleksnost pretvorbe MCP orodij v format, združljiv z LLM.

#### Rust

Za pretvorbo odgovora MCP orodja v format, ki ga LLM razume, bomo dodali pomožno funkcijo, ki formatira seznam orodij. Dodajte naslednjo kodo v datoteko `main.rs` pod funkcijo `main`. To bo poklicano pri pošiljanju zahtev LLM:
>>>>>>> origin/main

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
<<<<<<< HEAD
=======

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

Odlično, zdaj smo pripravljeni obravnavati uporabniške zahteve, zato se lotimo tega naslednje.

### -4- Obravnava uporabniškega poziva

V tem delu kode bomo obravnavali uporabniške zahteve.

#### TypeScript
>>>>>>> origin/main

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

Odlično, zdaj smo pripravljeni na obravnavo uporabniških zahtev, zato se lotimo tega naslednje.

### -4- Obravnava uporabniškega poziva

V tem delu kode bomo obravnavali uporabniške zahteve.

#### TypeScript

1. Dodajte metodo, ki bo uporabljena za klicanje našega LLM:

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
    - Metoda vzame odgovor LLM in preveri, katera orodja so bila poklicana, če sploh:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

<<<<<<< HEAD
    - Pokliče orodje, če LLM nakaže, da bi ga bilo treba poklicati:
=======
    - Pokliče orodje, če LLM nakaže, da bi ga morali poklicati:
>>>>>>> origin/main

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

Odlično, poglejmo celotno kodo:

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

1. Dodajmo nekaj uvozov, potrebnih za klicanje LLM:

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
    - Nato preverjamo rezultat, da vidimo, katere funkcije bi morali poklicati, če sploh.
<<<<<<< HEAD
    - Na koncu posredujemo seznam funkcij za klicanje.
=======
    - Na koncu posredujemo seznam funkcij za klic.
>>>>>>> origin/main

1. Zadnji korak, posodobimo našo glavno kodo:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

<<<<<<< HEAD
    Tam, to je bil zadnji korak, v zgornji kodi:

    - Kličemo MCP orodje prek `call_tool` z uporabo funkcije, za katero LLM meni, da bi jo morali poklicati na podlagi našega poziva.
    - Tiskamo rezultat klica orodja na MCP strežnik.
=======
    Tam, to je bil zadnji korak. V zgornji kodi:

    - Kličemo MCP orodje prek `call_tool` z uporabo funkcije, za katero LLM meni, da bi jo morali poklicati glede na naš poziv.
    - Izpisujemo rezultat klica orodja na MCP strežnik.
>>>>>>> origin/main

#### .NET

1. Poglejmo kodo za izvedbo zahteve LLM poziva:

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

    - Pridobili orodja iz MCP strežnika, `var tools = await GetMcpTools()`.
    - Določili uporabniški poziv `userMessage`.
<<<<<<< HEAD
    - Sestavili objekt z možnostmi, ki določa model in orodja.
=======
    - Sestavili objekt možnosti, ki določa model in orodja.
>>>>>>> origin/main
    - Poslali zahtevo proti LLM.

1. Še zadnji korak, preverimo, ali LLM meni, da bi morali poklicati funkcijo:

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

    - Zagnali zanko skozi seznam klicev funkcij.
<<<<<<< HEAD
    - Za vsak klic orodja razčlenili ime in argumente ter poklicali orodje na MCP strežniku z uporabo MCP odjemalca. Na koncu smo natisnili rezultate.
=======
    - Za vsak klic orodja razčlenili ime in argumente ter poklicali orodje na MCP strežniku z uporabo MCP odjemalca. Na koncu izpisali rezultate.
>>>>>>> origin/main

Tukaj je celotna koda:

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

V zgornji kodi smo:

- Uporabili preproste pozive v naravnem jeziku za interakcijo z orodji MCP strežnika.
- Okvir LangChain4j samodejno upravlja:
  - Pretvorbo uporabniških pozivov v klice orodij, kadar je to potrebno.
<<<<<<< HEAD
  - Klicanje ustreznih MCP orodij na podlagi odločitve LLM.
=======
  - Klic ustreznih MCP orodij na podlagi odločitve LLM.
>>>>>>> origin/main
  - Upravljanje poteka pogovora med LLM in MCP strežnikom.
- Metoda `bot.chat()` vrne odgovore v naravnem jeziku, ki lahko vključujejo rezultate izvedb MCP orodij.
- Ta pristop zagotavlja brezhibno uporabniško izkušnjo, kjer uporabniki ne potrebujejo vedeti o osnovni implementaciji MCP.

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

#### Rust

<<<<<<< HEAD
Tukaj se zgodi večina dela. Poklicali bomo LLM z začetnim uporabniškim pozivom, nato obdelali odgovor, da vidimo, ali je treba poklicati kakšna orodja. Če je tako, bomo poklicali ta orodja in nadaljevali pogovor z LLM, dokler ne bo več potrebnih klicev orodij in ne bomo imeli končnega odgovora.
=======
Tukaj se zgodi večina dela. Poklicali bomo LLM z začetnim uporabniškim pozivom, nato obdelali odgovor, da vidimo, ali je treba poklicati kakšna orodja. Če je tako, bomo poklicali ta orodja in nadaljevali pogovor z LLM, dokler ni več potrebnih klicev orodij in imamo končni odgovor.
>>>>>>> origin/main
Dodajmo naslednjo funkcijo v datoteko `main.rs`:

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

Ta funkcija sprejme LLM odjemalca, seznam sporočil (vključno z uporabniškim pozivom), orodja iz MCP strežnika in pošlje zahtevo LLM-ju, ki vrne odgovor.

Odgovor LLM-ja bo vseboval polje `choices`. Rezultat bomo morali obdelati, da preverimo, ali so prisotne kakšne `tool_calls`. To nam pove, da LLM zahteva, da se pokliče določeno orodje z argumenti. Na dno datoteke `main.rs` dodajte naslednjo kodo za definiranje funkcije, ki bo obdelala odgovor LLM-ja:

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

Če so prisotne `tool_calls`, funkcija izvleče informacije o orodju, pokliče MCP strežnik z zahtevo za orodje in doda rezultate v sporočila pogovora. Nato nadaljuje pogovor z LLM-jem, pri čemer se sporočila posodobijo z odgovorom asistenta in rezultati klica orodja.

Za izvlečenje informacij o klicu orodja, ki jih LLM vrne za MCP klice, bomo dodali še eno pomožno funkcijo, ki bo izvlekla vse potrebno za izvedbo klica. Na dno datoteke `main.rs` dodajte naslednjo kodo:

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

Ko imamo vse dele na mestu, lahko obdelamo začetni uporabniški poziv in pokličemo LLM. Posodobite svojo funkcijo `main`, da vključuje naslednjo kodo:

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

<<<<<<< HEAD
To bo poizvedovalo LLM z začetnim uporabniškim pozivom, ki zahteva vsoto dveh števil, in obdelalo odgovor za dinamično upravljanje klicev orodij.
=======
To bo poizvedovalo LLM z začetnim uporabniškim pozivom, ki zahteva vsoto dveh številk, in obdelalo odgovor za dinamično upravljanje klicev orodij.
>>>>>>> origin/main

Odlično, uspelo vam je!

## Naloga

<<<<<<< HEAD
Vzemite kodo iz vaje in razširite strežnik z več orodji. Nato ustvarite odjemalca z LLM, kot v vaji, in ga preizkusite z različnimi pozivi, da se prepričate, da se vsa orodja strežnika dinamično pokličejo. Tak način gradnje odjemalca zagotavlja odlično uporabniško izkušnjo, saj uporabniki lahko uporabljajo pozive namesto natančnih ukazov odjemalca in so nevedni glede kakršnih koli MCP strežniških klicev.
=======
Vzemite kodo iz vaje in razširite strežnik z več orodji. Nato ustvarite odjemalca z LLM-jem, kot v vaji, in ga preizkusite z različnimi pozivi, da zagotovite, da se vsa orodja vašega strežnika dinamično pokličejo. Tak način gradnje odjemalca omogoča odlično uporabniško izkušnjo, saj uporabniki lahko uporabljajo pozive namesto natančnih ukazov odjemalca in so nevedni glede kakršnega koli MCP strežnika, ki se kliče.
>>>>>>> origin/main

## Rešitev

[Rešitev](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne točke

- Dodajanje LLM-ja vašemu odjemalcu omogoča boljši način interakcije z MCP strežniki.
- Odgovor MCP strežnika morate pretvoriti v nekaj, kar LLM razume.

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)
- [Rust Kalkulator](../../../../03-GettingStarted/samples/rust)

## Dodatni viri

## Kaj sledi

- Naprej: [Uporaba strežnika z Visual Studio Code](../04-vscode/README.md)

**Omejitev odgovornosti**:  
<<<<<<< HEAD
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovni prevod s strani človeka. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.
=======
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.
>>>>>>> origin/main
