<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-26T19:11:31+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "lt"
}
-->
# Sukurti klientą su LLM

Iki šiol matėte, kaip sukurti serverį ir klientą. Klientas galėjo aiškiai kreiptis į serverį, kad gautų jo įrankių, išteklių ir užklausų sąrašą. Tačiau tai nėra labai praktiškas požiūris. Jūsų vartotojas gyvena agentinėje eroje ir tikisi naudoti užklausas bei bendrauti su LLM, kad tai atliktų. Vartotojui nesvarbu, ar naudojate MCP savo galimybėms saugoti, tačiau jis tikisi natūralios kalbos sąveikos. Taigi, kaip tai išspręsti? Sprendimas yra pridėti LLM prie kliento.

## Apžvalga

Šioje pamokoje mes sutelkiame dėmesį į LLM pridėjimą prie kliento ir parodome, kaip tai suteikia daug geresnę patirtį vartotojui.

## Mokymosi tikslai

Pamokos pabaigoje galėsite:

- Sukurti klientą su LLM.
- Sklandžiai sąveikauti su MCP serveriu naudojant LLM.
- Suteikti geresnę galutinio vartotojo patirtį kliento pusėje.

## Požiūris

Pabandykime suprasti, kokį požiūrį turime taikyti. LLM pridėjimas skamba paprastai, bet ar iš tikrųjų taip yra?

Štai kaip klientas sąveikaus su serveriu:

1. Užmegzti ryšį su serveriu.

1. Išvardyti galimybes, užklausas, išteklius ir įrankius bei išsaugoti jų schemą.

1. Pridėti LLM ir perduoti išsaugotas galimybes bei jų schemą formatu, kurį supranta LLM.

1. Tvarkyti vartotojo užklausą, perduodant ją LLM kartu su įrankiais, kuriuos išvardijo klientas.

Puiku, dabar suprantame, kaip tai galime padaryti aukštu lygiu, išbandykime tai žemiau pateiktoje užduotyje.

## Užduotis: Sukurti klientą su LLM

Šioje užduotyje išmoksime pridėti LLM prie savo kliento.

### Autentifikacija naudojant GitHub asmeninį prieigos raktą

GitHub rakto sukūrimas yra paprastas procesas. Štai kaip tai padaryti:

- Eikite į GitHub nustatymus – Spustelėkite savo profilio paveikslėlį viršutiniame dešiniajame kampe ir pasirinkite „Settings“.
- Pereikite į „Developer Settings“ – Slinkite žemyn ir spustelėkite „Developer Settings“.
- Pasirinkite „Personal Access Tokens“ – Spustelėkite „Personal access tokens“ ir tada „Generate new token“.
- Konfigūruokite savo raktą – Pridėkite pastabą nuorodai, nustatykite galiojimo datą ir pasirinkite reikiamus leidimus (scopes).
- Sukurkite ir nukopijuokite raktą – Spustelėkite „Generate token“ ir įsitikinkite, kad jį iškart nukopijuojate, nes vėliau jo nebematysite.

### -1- Prisijungimas prie serverio

Pirmiausia sukurkime savo klientą:

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

Šiame kode mes:

- Importavome reikalingas bibliotekas.
- Sukūrėme klasę su dviem nariais, `client` ir `openai`, kurie padės mums valdyti klientą ir sąveikauti su LLM.
- Konfigūravome LLM instanciją naudoti GitHub modelius, nustatydami `baseUrl`, kad nukreiptų į API.

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

Šiame kode mes:

- Importavome reikalingas MCP bibliotekas.
- Sukūrėme klientą.

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

Pirmiausia turėsite pridėti „LangChain4j“ priklausomybes į savo `pom.xml` failą. Pridėkite šias priklausomybes, kad įgalintumėte MCP integraciją ir GitHub modelių palaikymą:

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

Tada sukurkite savo Java kliento klasę:

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

Šiame kode mes:

- **Pridėjome „LangChain4j“ priklausomybes**: Reikalingas MCP integracijai, oficialiam OpenAI klientui ir GitHub modelių palaikymui.
- **Importavome „LangChain4j“ bibliotekas**: MCP integracijai ir OpenAI pokalbių modelio funkcionalumui.
- **Sukūrėme `ChatLanguageModel`**: Konfigūruotą naudoti GitHub modelius su jūsų GitHub raktu.
- **Nustatėme HTTP transportą**: Naudojant „Server-Sent Events“ (SSE) prisijungti prie MCP serverio.
- **Sukūrėme MCP klientą**: Kuris tvarkys komunikaciją su serveriu.
- **Naudojome „LangChain4j“ įmontuotą MCP palaikymą**: Kuris supaprastina integraciją tarp LLM ir MCP serverių.

#### Rust

Šis pavyzdys daro prielaidą, kad turite Rust pagrindu sukurtą MCP serverį. Jei jo neturite, grįžkite į pamoką [01-first-server](../01-first-server/README.md), kad sukurtumėte serverį.

Kai turėsite Rust MCP serverį, atidarykite terminalą ir pereikite į tą patį katalogą kaip serveris. Tada paleiskite šią komandą, kad sukurtumėte naują LLM kliento projektą:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Pridėkite šias priklausomybes į savo `Cargo.toml` failą:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Nėra oficialios Rust bibliotekos OpenAI, tačiau `async-openai` yra [bendruomenės palaikoma biblioteka](https://platform.openai.com/docs/libraries/rust#rust), kuri dažnai naudojama.

Atidarykite `src/main.rs` failą ir pakeiskite jo turinį šiuo kodu:

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

Šis kodas nustato pagrindinę Rust programą, kuri prisijungs prie MCP serverio ir GitHub modelių LLM sąveikai.

> [!IMPORTANT]
> Prieš paleisdami programą, įsitikinkite, kad nustatėte aplinkos kintamąjį `OPENAI_API_KEY` su savo GitHub raktu.

Puiku, kitame žingsnyje išvardinsime serverio galimybes.

### -2- Serverio galimybių sąrašas

Dabar prisijungsime prie serverio ir paprašysime jo galimybių:

#### TypeScript

Toje pačioje klasėje pridėkite šiuos metodus:

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

Šiame kode mes:

- Pridėjome kodą prisijungti prie serverio, `connectToServer`.
- Sukūrėme `run` metodą, atsakingą už mūsų programos eigą. Kol kas jis tik išvardija įrankius, bet netrukus pridėsime daugiau.

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

Štai ką pridėjome:

- Išvardijome išteklius ir įrankius bei juos atspausdinome. Įrankiams taip pat išvardijame `inputSchema`, kurį naudosime vėliau.

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

Šiame kode mes:

- Išvardijome įrankius, esančius MCP serveryje.
- Kiekvienam įrankiui išvardijome pavadinimą, aprašymą ir jo schemą. Pastarąją naudosime netrukus, kad galėtume iškviesti įrankius.

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

Šiame kode mes:

- Sukūrėme `McpToolProvider`, kuris automatiškai aptinka ir registruoja visus įrankius iš MCP serverio.
- Įrankių teikėjas viduje tvarko MCP įrankių schemų konvertavimą į „LangChain4j“ įrankių formatą.
- Šis požiūris abstrahuoja rankinį įrankių sąrašą ir konvertavimo procesą.

#### Rust

Įrankių gavimas iš MCP serverio atliekamas naudojant `list_tools` metodą. Savo `main` funkcijoje, po MCP kliento nustatymo, pridėkite šį kodą:

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- Serverio galimybių konvertavimas į LLM įrankius

Kitas žingsnis po serverio galimybių sąrašo yra jų konvertavimas į formatą, kurį supranta LLM. Kai tai padarysime, galėsime pateikti šias galimybes kaip įrankius LLM.

#### TypeScript

1. Pridėkite šį kodą, kad konvertuotumėte MCP serverio atsakymą į įrankio formatą, kurį gali naudoti LLM:

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

    Aukščiau pateiktas kodas paima MCP serverio atsakymą ir konvertuoja jį į įrankio apibrėžimo formatą, kurį supranta LLM.

1. Atnaujinkime `run` metodą, kad išvardytume serverio galimybes:

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

    Šiame kode mes atnaujinome `run` metodą, kad peržvelgtume rezultatą ir kiekvienam įrašui iškviestume `openAiToolAdapter`.

#### Python

1. Pirmiausia sukurkime šią konvertavimo funkciją:

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

    Funkcijoje `convert_to_llm_tools` mes paimame MCP įrankio atsakymą ir konvertuojame jį į formatą, kurį supranta LLM.

1. Tada atnaujinkime savo kliento kodą, kad pasinaudotume šia funkcija:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Čia mes pridedame skambutį į `convert_to_llm_tool`, kad konvertuotume MCP įrankio atsakymą į tai, ką galime perduoti LLM vėliau.

#### .NET

1. Pridėkime kodą, kad konvertuotume MCP įrankio atsakymą į tai, ką supranta LLM:

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

Šiame kode mes:

- Sukūrėme funkciją `ConvertFrom`, kuri paima pavadinimą, aprašymą ir įvesties schemą.
- Apibrėžėme funkcionalumą, kuris sukuria „FunctionDefinition“, perduodamą „ChatCompletionsDefinition“. Pastarasis yra tai, ką supranta LLM.

1. Pažiūrėkime, kaip galime atnaujinti esamą kodą, kad pasinaudotume šia funkcija:

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

    Šiame kode mes:

    - Atnaujinome funkciją, kad konvertuotume MCP įrankio atsakymą į LLM įrankį. Pažymėkime pridėtą kodą:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Įvesties schema yra įrankio atsakymo dalis, tačiau „properties“ atributuose, todėl ją reikia išgauti. Be to, dabar kviečiame `ConvertFrom` su įrankio detalėmis. Dabar atlikome sunkų darbą, pažiūrėkime, kaip viskas susijungia, kai tvarkome vartotojo užklausą.

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

Šiame kode mes:

- Apibrėžėme paprastą `Bot` sąsają natūralios kalbos sąveikai.
- Naudojome „LangChain4j“ `AiServices`, kad automatiškai susietume LLM su MCP įrankių teikėju.
- Framework automatiškai tvarko įrankių schemų konvertavimą ir funkcijų iškvietimą užkulisiuose.
- Šis požiūris pašalina rankinį įrankių konvertavimą – „LangChain4j“ tvarko visą sudėtingumą konvertuojant MCP įrankius į LLM suderinamą formatą.

#### Rust

Norėdami konvertuoti MCP įrankio atsakymą į formatą, kurį supranta LLM, pridėsime pagalbinę funkciją, kuri formatuoja įrankių sąrašą. Pridėkite šį kodą į savo `main.rs` failą po `main` funkcijos. Tai bus iškviesta, kai bus atliekami užklausos LLM:

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

Puiku, dabar esame pasiruošę tvarkyti bet kokius vartotojo užklausimus, todėl pereikime prie to.

### -4- Tvarkyti vartotojo užklausą

Šioje kodo dalyje mes tvarkysime vartotojo užklausas.

#### TypeScript

1. Pridėkite metodą, kuris bus naudojamas LLM iškvietimui:

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

    Šiame kode mes:

    - Pridėjome metodą `callTools`.
    - Metodas paima LLM atsakymą ir patikrina, kokie įrankiai buvo iškviesti, jei tokių yra:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Iškviečia įrankį, jei LLM nurodo, kad jis turėtų būti iškviestas:

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

1. Atnaujinkite `run` metodą, kad įtrauktumėte skambučius į LLM ir `callTools`:

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

Puiku, pateikiame visą kodą:

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

1. Pridėkime importus, reikalingus LLM iškvietimui:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Tada pridėkime funkciją, kuri iškvies LLM:

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

    Šiame kode mes:

    - Perdavėme savo funkcijas, kurias radome MCP serveryje ir konvertavome, LLM.
    - Tada iškvietėme LLM su tomis funkcijomis.
    - Tada tikriname rezultatą, kad pamatytume, kokias funkcijas turėtume iškviesti, jei tokių yra.
    - Galiausiai perduodame funkcijų masyvą iškvietimui.

1. Paskutinis žingsnis, atnaujinkime pagrindinį kodą:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Šiame kode mes:

    - Iškviečiame MCP įrankį per `call_tool` naudodami funkciją, kurią LLM manė, kad turėtume iškviesti pagal mūsų užklausą.
    - Spausdiname įrankio iškvietimo rezultatą MCP serveryje.

#### .NET

1. Pateikiame kodą LLM užklausos iškvietimui:

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

    Šiame kode mes:

    - Pasiėmėme įrankius iš MCP serverio, `var tools = await GetMcpTools()`.
    - Apibrėžėme vartotojo užklausą `userMessage`.
    - Sukūrėme parinkčių objektą, nurodantį modelį ir įrankius.
    - Atlikome užklausą LLM.

1. Paskutinis žingsnis, pažiūrėkime, ar LLM mano, kad turėtume iškviesti funkciją:

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

    Šiame kode mes:

    - Peržvelgėme funkcijų iškvietimų sąrašą.
    - Kiekvienam įrankio iškvietimui išskyrėme pavadinimą ir argumentus bei iškvietėme įrankį MCP serveryje naudodami MCP klientą. Galiausiai spausdiname rezultatus.

Visas kodas:

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

Šiame kode mes:

- Naudojome paprastas natūralios kalbos užklausas sąveikai su MCP serverio įrankiais.
- „LangChain4j“ framework automatiškai tvarko:
  - Vartotojo užklausų konvertavimą į įrankių iškvietimus, kai reikia.
  - Tinkamų MCP įrankių iškvietimą pagal LLM sprendimą.
  - Pokalbio eigą tarp LLM ir MCP serverio.
- `bot.chat()` metodas grąžina natūralios kalbos atsakymus, kurie gali apimti MCP įrankių vykdymo rezultatus.
- Šis požiūris suteikia sklandžią vartotojo patirtį, kur vartotojams nereikia žinoti apie pagrindinę MCP implementaciją.

Pilnas kodo pavyzdys:

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

Čia vyksta didžioji darbo dalis. Mes iškviesime LLM su pradiniu vartotojo užklausimu, tada apdorosime atsakymą, kad pamatytume, ar reikia iškviesti kokius nors įrankius. Jei taip, iškviesime tuos įrankius ir tęsiame pokalbį su LLM, kol nebereikės iškviesti įrankių ir turėsime galutinį atsakymą.
Mes pridėsime funkciją, kuri apdoros LLM užklausas. Pridėkite šią funkciją į savo `main.rs` failą:

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

Ši funkcija priima LLM klientą, žinučių sąrašą (įskaitant vartotojo užklausą), įrankius iš MCP serverio ir siunčia užklausą LLM, grąžindama atsakymą.

LLM atsakymas turės masyvą su `choices`. Reikės apdoroti rezultatą, kad patikrintume, ar yra kokių nors `tool_calls`. Tai leidžia suprasti, ar LLM prašo iškviesti konkretų įrankį su argumentais. Pridėkite šį kodą į savo `main.rs` failo apačią, kad apibrėžtumėte funkciją, kuri apdoros LLM atsakymą:

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

Jei yra `tool_calls`, funkcija ištraukia informaciją apie įrankį, siunčia užklausą MCP serveriui su įrankio prašymu ir prideda rezultatus prie pokalbio žinučių. Tada ji tęsia pokalbį su LLM, o žinutės atnaujinamos su asistento atsakymu ir įrankio iškvietimo rezultatais.

Norėdami išgauti informaciją apie įrankio iškvietimą, kurią LLM grąžina MCP užklausoms, pridėsime dar vieną pagalbinę funkciją, kuri ištrauks viską, kas reikalinga iškvietimui. Pridėkite šį kodą į savo `main.rs` failo apačią:

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

Turėdami visas dalis, dabar galime apdoroti pradinę vartotojo užklausą ir iškviesti LLM. Atnaujinkite savo `main` funkciją, kad įtrauktumėte šį kodą:

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

Tai pateiks užklausą LLM su pradine vartotojo užklausa, prašančia dviejų skaičių sumos, ir apdoros atsakymą, kad dinamiškai valdytų įrankių iškvietimus.

Puiku, jums pavyko!

## Užduotis

Paimkite pratimo kodą ir sukurkite serverį su daugiau įrankių. Tada sukurkite klientą su LLM, kaip parodyta pratime, ir išbandykite jį su skirtingomis užklausomis, kad įsitikintumėte, jog visi jūsų serverio įrankiai yra iškviečiami dinamiškai. Toks kliento kūrimo būdas užtikrina puikią vartotojo patirtį, nes jie gali naudoti užklausas vietoj tikslių kliento komandų ir nežinoti apie MCP serverio iškvietimus.

## Sprendimas

[Sprendimas](/03-GettingStarted/03-llm-client/solution/README.md)

## Pagrindinės įžvalgos

- LLM pridėjimas prie jūsų kliento suteikia geresnį būdą vartotojams sąveikauti su MCP serveriais.
- Reikia konvertuoti MCP serverio atsakymą į formatą, kurį LLM supranta.

## Pavyzdžiai

- [Java Skaičiuotuvas](../samples/java/calculator/README.md)
- [.Net Skaičiuotuvas](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Skaičiuotuvas](../samples/javascript/README.md)
- [TypeScript Skaičiuotuvas](../samples/typescript/README.md)
- [Python Skaičiuotuvas](../../../../03-GettingStarted/samples/python)
- [Rust Skaičiuotuvas](../../../../03-GettingStarted/samples/rust)

## Papildomi ištekliai

## Kas toliau

- Toliau: [Serverio naudojimas su Visual Studio Code](../04-vscode/README.md)

---

**Atsakomybės apribojimas**:  
Šis dokumentas buvo išverstas naudojant dirbtinio intelekto vertimo paslaugą [Co-op Translator](https://github.com/Azure/co-op-translator). Nors siekiame tikslumo, atkreipiame dėmesį, kad automatiniai vertimai gali turėti klaidų ar netikslumų. Originalus dokumentas jo gimtąja kalba turėtų būti laikomas autoritetingu šaltiniu. Kritinei informacijai rekomenduojama naudotis profesionalių vertėjų paslaugomis. Mes neprisiimame atsakomybės už nesusipratimus ar klaidingus aiškinimus, kylančius dėl šio vertimo naudojimo.