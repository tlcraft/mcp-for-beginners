<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T06:30:17+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "da"
}
-->
# Oprettelse af en klient

Klienter er brugerdefinerede applikationer eller scripts, der kommunikerer direkte med en MCP Server for at anmode om ressourcer, værktøjer og prompts. I modsætning til at bruge inspektørværktøjet, som giver en grafisk grænseflade til at interagere med serveren, giver det at skrive din egen klient mulighed for programmatisk og automatiseret interaktion. Dette gør det muligt for udviklere at integrere MCP-funktioner i deres egne arbejdsgange, automatisere opgaver og bygge skræddersyede løsninger til specifikke behov.

## Oversigt

Denne lektion introducerer konceptet klienter inden for Model Context Protocol (MCP) økosystemet. Du vil lære, hvordan du skriver din egen klient og får den til at oprette forbindelse til en MCP Server.

## Læringsmål

Ved slutningen af denne lektion vil du kunne:

- Forstå, hvad en klient kan gøre.
- Skrive din egen klient.
- Oprette forbindelse til og teste klienten med en MCP-server for at sikre, at den fungerer som forventet.

## Hvad indebærer det at skrive en klient?

For at skrive en klient skal du gøre følgende:

- **Importere de korrekte biblioteker**. Du vil bruge det samme bibliotek som før, blot med forskellige konstruktioner.
- **Instantierer en klient**. Dette indebærer at oprette en klientinstans og forbinde den til den valgte transportmetode.
- **Bestemme hvilke ressourcer der skal listes**. Din MCP-server har ressourcer, værktøjer og prompts, og du skal beslutte, hvilke der skal listes.
- **Integrere klienten i en værtapplikation**. Når du kender serverens kapaciteter, skal du integrere dette i din værtapplikation, så hvis en bruger skriver en prompt eller en anden kommando, bliver den tilsvarende serverfunktion kaldt.

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

I den forrige kode har vi:

- Importeret bibliotekerne
- Oprettet en instans af en klient og forbundet den ved hjælp af stdio som transport.
- Listet prompts, ressourcer og værktøjer og kaldt dem alle.

Der har du det, en klient der kan kommunikere med en MCP Server.

Lad os tage os god tid i næste øvelsesafsnit til at gennemgå hver kodebid og forklare, hvad der sker.

## Øvelse: Skrive en klient

Som nævnt ovenfor, lad os tage os tid til at forklare koden, og du er meget velkommen til at kode med, hvis du vil.

### -1- Importere bibliotekerne

Lad os importere de nødvendige biblioteker. Vi skal bruge referencer til en klient og til vores valgte transportprotokol, stdio. stdio er en protokol til ting, der skal køre på din lokale maskine. SSE er en anden transportprotokol, som vi vil vise i kommende kapitler, men det er dit andet valg. For nu fortsætter vi med stdio.

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

I den forrige kode har vi:

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

I den forrige kode har vi:

- Importeret de nødvendige biblioteker
- Instantieret et serverparametre-objekt, som vi vil bruge til at køre serveren, så vi kan forbinde til den med vores klient.
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

I den forrige kode har vi:

- Importeret de nødvendige biblioteker.
- Oprettet en stdio transport og en klient `mcpClient`. Sidstnævnte bruger vi til at liste og kalde funktioner på MCP Serveren.

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

I den forrige kode har vi:

- Oprettet en main-metode, der sætter en SSE transport op, som peger på `http://localhost:8080`, hvor vores MCP-server kører.
- Oprettet en klientklasse, der tager transporten som konstruktørparameter.
- I `run`-metoden opretter vi en synkron MCP-klient ved hjælp af transporten og initialiserer forbindelsen.
- Brugt SSE (Server-Sent Events) transport, som er velegnet til HTTP-baseret kommunikation med Java Spring Boot MCP-servere.

### -3- Liste serverfunktionerne

Nu har vi en klient, der kan oprette forbindelse, hvis programmet køres. Men den lister ikke sine funktioner, så lad os gøre det næste:

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

Ovenfor er et eksempel på, hvordan vi kan liste værktøjerne på serveren. For hvert værktøj printer vi derefter navnet ud.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

I den forrige kode har vi:

- Kaldt `listTools()` for at hente alle tilgængelige værktøjer fra MCP-serveren.
- Brug `ping()` for at bekræfte, at forbindelsen til serveren fungerer.
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

I den forrige kode har vi:

- Læst en ressource ved at kalde `readResource()` og angive `uri`. Sådan ser det sandsynligvis ud på serversiden:

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

- Kaldt et værktøj ved at angive dets `name` og dets `arguments` sådan her:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Hentet en prompt ved at kalde `getPrompt()` med `name` og `arguments`. Serverkoden ser sådan ud:

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

I den forrige kode har vi:

- Kaldt en ressource kaldet `greeting` ved hjælp af `read_resource`.
- Kaldt et værktøj kaldet `add` ved hjælp af `call_tool`.

### C#

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

I den forrige kode har vi:

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

Her er en server, du kan bruge, som du skal kalde via din klientkode. Se om du kan tilføje flere funktioner til serveren for at gøre den mere interessant.

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

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer for dette kapitel om klienter er:

- Kan bruges både til at opdage og kalde funktioner på serveren.
- Kan starte en server, mens den selv starter (som i dette kapitel), men klienter kan også forbinde til kørende servere.
- Er en god måde at teste serverfunktioner på ved siden af alternativer som Inspector, som blev beskrevet i det foregående kapitel.

## Yderligere ressourcer

- [Bygning af klienter i MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Hvad er det næste

- Næste: [Oprettelse af en klient med en LLM](../03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.