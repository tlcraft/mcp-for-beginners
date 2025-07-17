<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:04:01+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "da"
}
-->
# Oprettelse af en klient

Klienter er brugerdefinerede applikationer eller scripts, der kommunikerer direkte med en MCP Server for at anmode om ressourcer, værktøjer og prompts. I modsætning til at bruge inspektørværktøjet, som giver en grafisk grænseflade til at interagere med serveren, giver det at skrive din egen klient mulighed for programmatisk og automatiseret interaktion. Dette gør det muligt for udviklere at integrere MCP-funktioner i deres egne arbejdsgange, automatisere opgaver og bygge skræddersyede løsninger til specifikke behov.

## Oversigt

Denne lektion introducerer konceptet klienter inden for Model Context Protocol (MCP) økosystemet. Du vil lære, hvordan du skriver din egen klient og får den til at oprette forbindelse til en MCP Server.

## Læringsmål

Når du er færdig med denne lektion, vil du kunne:

- Forstå, hvad en klient kan gøre.
- Skrive din egen klient.
- Oprette forbindelse til og teste klienten med en MCP-server for at sikre, at den fungerer som forventet.

## Hvad indebærer det at skrive en klient?

For at skrive en klient skal du gøre følgende:

- **Importere de korrekte biblioteker**. Du vil bruge det samme bibliotek som før, blot med forskellige konstruktioner.
- **Instantierer en klient**. Dette indebærer at oprette en klientinstans og forbinde den til den valgte transportmetode.
- **Bestemme hvilke ressourcer der skal listes**. Din MCP-server har ressourcer, værktøjer og prompts, og du skal beslutte, hvilke der skal listes.
- **Integrere klienten i en vært-applikation**. Når du kender serverens kapaciteter, skal du integrere dette i din vært-applikation, så hvis en bruger skriver en prompt eller en anden kommando, bliver den tilsvarende serverfunktion kaldt.

Nu hvor vi på et overordnet plan forstår, hvad vi skal gøre, lad os se på et eksempel.

### Et eksempel på en klient

Lad os kigge på dette eksempel på en klient:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

I den foregående kode har vi:

- Importeret bibliotekerne
- Oprettet en instans af en klient og forbundet den ved hjælp af stdio som transport.
- Listet prompts, ressourcer og værktøjer og kaldt dem alle.

Der har du det, en klient der kan kommunikere med en MCP Server.

Lad os tage os god tid i næste øvelsesafsnit til at gennemgå hver kodebid og forklare, hvad der sker.

## Øvelse: Skrive en klient

Som nævnt ovenfor, lad os tage os tid til at forklare koden, og du er meget velkommen til at kode med, hvis du vil.

### -1- Importer bibliotekerne

Lad os importere de biblioteker, vi har brug for. Vi skal bruge referencer til en klient og til vores valgte transportprotokol, stdio. stdio er en protokol til ting, der skal køre på din lokale maskine. SSE er en anden transportprotokol, som vi vil vise i fremtidige kapitler, men det er dit andet valg. For nu fortsætter vi med stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

For Java skal du oprette en klient, der opretter forbindelse til MCP-serveren fra den tidligere øvelse. Brug den samme Java Spring Boot projektstruktur fra [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), opret en ny Java-klasse kaldet `SDKClient` i mappen `src/main/java/com/microsoft/mcp/sample/client/` og tilføj følgende imports:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

Lad os gå videre til instantiering.

### -2- Instantiering af klient og transport

Vi skal oprette en instans af transporten og en af vores klient:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

I den foregående kode har vi:

- Oprettet en stdio transportinstans. Bemærk, hvordan den specificerer kommando og argumenter for, hvordan serveren findes og startes, da det er noget, vi skal gøre, når vi opretter klienten.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instantieret en klient ved at give den et navn og en version.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Forbundet klienten til den valgte transport.

    ```typescript
    await client.connect(transport);
    ```

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

I den foregående kode har vi:

- Importeret de nødvendige biblioteker
- Instantieret et serverparametre-objekt, da vi vil bruge dette til at køre serveren, så vi kan forbinde til den med vores klient.
- Defineret en metode `run`, som igen kalder `stdio_client`, der starter en klient-session.
- Oprettet et entry point, hvor vi giver `run`-metoden til `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

I den foregående kode har vi:

- Importeret de nødvendige biblioteker.
- Oprettet en stdio transport og oprettet en klient `mcpClient`. Sidstnævnte bruger vi til at liste og kalde funktioner på MCP Serveren.

Bemærk, i "Arguments" kan du enten pege på *.csproj* eller på den eksekverbare fil.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

I den foregående kode har vi:

- Oprettet en main-metode, der sætter en SSE transport op, som peger på `http://localhost:8080`, hvor vores MCP-server kører.
- Oprettet en klientklasse, der tager transporten som konstruktørparameter.
- I `run`-metoden opretter vi en synkron MCP-klient ved hjælp af transporten og initialiserer forbindelsen.
- Brugte SSE (Server-Sent Events) transport, som er velegnet til HTTP-baseret kommunikation med Java Spring Boot MCP-servere.

### -3- Liste serverfunktionerne

Nu har vi en klient, der kan oprette forbindelse, hvis programmet køres. Men den lister ikke faktisk funktionerne, så lad os gøre det næste:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

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
```

Her lister vi de tilgængelige ressourcer, `list_resources()` og værktøjer, `list_tools` og printer dem ud.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Ovenfor er et eksempel på, hvordan vi kan liste værktøjerne på serveren. For hvert værktøj printer vi derefter dets navn ud.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

I den foregående kode har vi:

- Kaldt `listTools()` for at hente alle tilgængelige værktøjer fra MCP-serveren.
- Brugte `ping()` for at bekræfte, at forbindelsen til serveren fungerer.
- `ListToolsResult` indeholder information om alle værktøjer, inklusive deres navne, beskrivelser og inputskemaer.

Fint, nu har vi fanget alle funktionerne. Nu er spørgsmålet, hvornår bruger vi dem? Denne klient er ret simpel, simpel i den forstand, at vi eksplicit skal kalde funktionerne, når vi vil bruge dem. I næste kapitel vil vi oprette en mere avanceret klient, der har adgang til sin egen store sprogmodel, LLM. For nu, lad os se, hvordan vi kan kalde funktionerne på serveren:

### -4- Kald funktioner

For at kalde funktionerne skal vi sikre, at vi angiver de korrekte argumenter og i nogle tilfælde navnet på det, vi prøver at kalde.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

I den foregående kode har vi:

- Læst en ressource, vi kalder ressourcen ved at kalde `readResource()` og angive `uri`. Sådan ser det sandsynligvis ud på serversiden:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Værdien af vores `uri` `file://example.txt` matcher `file://{name}` på serveren. `example.txt` bliver mappet til `name`.

- Kaldt et værktøj, vi kalder det ved at angive dets `name` og dets `arguments` sådan her:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Hentet prompt, for at hente en prompt kalder du `getPrompt()` med `name` og `arguments`. Serverkoden ser sådan ud:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    og din resulterende klientkode ser derfor sådan ud for at matche det, der er deklareret på serveren:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

I den foregående kode har vi:

- Kaldt en ressource kaldet `greeting` ved hjælp af `read_resource`.
- Kaldt et værktøj kaldet `add` ved hjælp af `call_tool`.

### .NET

1. Lad os tilføje noget kode til at kalde et værktøj:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. For at udskrive resultatet, her er noget kode til at håndtere det:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

I den foregående kode har vi:

- Kaldt flere regneværktøjer ved hjælp af `callTool()` metoden med `CallToolRequest` objekter.
- Hver værktøjskald specificerer værktøjets navn og et `Map` af argumenter, som værktøjet kræver.
- Serverværktøjerne forventer specifikke parameternavne (som "a", "b" til matematiske operationer).
- Resultater returneres som `CallToolResult` objekter, der indeholder svaret fra serveren.

### -5- Kør klienten

For at køre klienten, skriv følgende kommando i terminalen:

### TypeScript

Tilføj følgende entry til din "scripts" sektion i *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Kald klienten med følgende kommando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Sørg først for, at din MCP-server kører på `http://localhost:8080`. Kør derefter klienten:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativt kan du køre det komplette klientprojekt, der findes i løsningsmappen `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Opgave

I denne opgave skal du bruge det, du har lært om at oprette en klient, men lave din egen klient.

Her er en server, du kan bruge, som du skal kalde via din klientkode. Se, om du kan tilføje flere funktioner til serveren for at gøre den mere interessant.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

Se dette projekt for at se, hvordan du kan [tilføje prompts og ressourcer](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Tjek også dette link for, hvordan du kalder [prompts og ressourcer](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Løsning

**Løsningsmappen** indeholder komplette, klar-til-kørsel klientimplementeringer, der demonstrerer alle de koncepter, der er dækket i denne vejledning. Hver løsning inkluderer både klient- og serverkode organiseret i separate, selvstændige projekter.

### 📁 Løsningsstruktur

Løsningsmappen er organiseret efter programmeringssprog:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Hvad hver løsning indeholder

Hver sprog-specifik løsning tilbyder:

- **Komplet klientimplementering** med alle funktioner fra vejledningen
- **Fungerende projektstruktur** med korrekte afhængigheder og konfiguration
- **Build- og kør-scripts** for nem opsætning og eksekvering
- **Detaljeret README** med sprog-specifikke instruktioner
- **Fejlhåndtering** og eksempler på resultatbehandling

### 📖 Brug af løsningerne

1. **Naviger til din foretrukne sprogmappe**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Følg README-instruktionerne** i hver mappe for:
   - Installation af afhængigheder
   - Bygning af projektet
   - Kørsel af klienten

3. **Eksempeloutput**, du bør se:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

For komplet dokumentation og trin-for-trin instruktioner, se: **[📖 Løsningsdokumentation](./solution/README.md)**

## 🎯 Komplette eksempler

Vi har leveret komplette, fungerende klientimplementeringer for alle programmeringssprog, der er dækket i denne vejledning. Disse eksempler demonstrerer den fulde funktionalitet beskrevet ovenfor og kan bruges som referenceimplementeringer eller udgangspunkter for dine egne projekter.

### Tilgængelige komplette eksempler

| Sprog    | Fil                          | Beskrivelse                                                      |
|----------|------------------------------|-----------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Komplett Java-klient med SSE-transport og omfattende fejlhåndtering |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Komplett C# klient med stdio-transport og automatisk serverstart |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Komplett TypeScript klient med fuld MCP protokol support         |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Komplett Python klient med async/await mønstre                   |

Hvert komplet eksempel inkluderer:

- ✅ **Etablering af forbindelse** og fejlhåndtering
- ✅ **Serveropdagelse** (værktøjer, ressourcer, prompts hvor relevant)
- ✅ **Regneoperationer** (add, subtract, multiply, divide, help)
- ✅ **Resultatbehandling** og formateret output
- ✅ **Omfattende fejlhåndtering**
- ✅ **Ren, dokumenteret kode** med trin-for-trin kommentarer

### Kom godt i gang med komplette eksempler

1. **Vælg dit foretrukne sprog** fra tabellen ovenfor
2. **Gennemgå den komplette eksempel-fil** for at forstå den fulde implementering
3. **Kør eksemplet** efter instruktionerne i [`complete_examples.md`](./complete_examples.md)
4. **Tilpas og udvid** eksemplet til dit specifikke brugstilfælde

For detaljeret dokumentation om kørsel og tilpasning af disse eksempler, se: **[📖 Komplette eksempler dokumentation](./complete_examples.md)**

### 💡 Løsning vs. komplette eksempler

| **Løsningsmappe**           | **Komplette eksempler**          |
|----------------------------|---------------------------------|
| Fuld projektstruktur med build-filer | Enkeltfil-implementeringer          |
| Klar til kørsel med afhængigheder | Fokuserede kodeeksempler           |
| Produktion-lignende opsætning | Pædagogisk reference              |
| Sprog-specifikke værktøjer | Tvær-sproglig sammenligning       |
Begge tilgange er værdifulde - brug **solution folder** til komplette projekter og **complete examples** til læring og reference.  
## Vigtige pointer

De vigtigste pointer for dette kapitel om klienter er følgende:

- Kan bruges både til at opdage og aktivere funktioner på serveren.  
- Kan starte en server, mens den selv starter (som i dette kapitel), men klienter kan også forbinde til allerede kørende servere.  
- Er en fremragende måde at teste serverfunktioner på ved siden af alternativer som Inspector, som blev beskrevet i det foregående kapitel.  

## Yderligere ressourcer

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Hvad er det næste

- Næste: [Creating a client with an LLM](../03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.