<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T07:12:55+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "nl"
}
-->
# Een client maken

Clients zijn aangepaste applicaties of scripts die rechtstreeks communiceren met een MCP Server om resources, tools en prompts op te vragen. In tegenstelling tot het gebruik van de inspector tool, die een grafische interface biedt om met de server te communiceren, maakt het schrijven van je eigen client programmatische en geautomatiseerde interacties mogelijk. Dit stelt ontwikkelaars in staat om MCP-functionaliteiten te integreren in hun eigen workflows, taken te automatiseren en maatwerkoplossingen te bouwen die zijn afgestemd op specifieke behoeften.

## Overzicht

Deze les introduceert het concept van clients binnen het Model Context Protocol (MCP) ecosysteem. Je leert hoe je je eigen client schrijft en deze verbindt met een MCP Server.

## Leerdoelen

Aan het einde van deze les kun je:

- Begrijpen wat een client kan doen.
- Je eigen client schrijven.
- De client verbinden en testen met een MCP server om te controleren of alles werkt zoals verwacht.

## Wat komt er kijken bij het schrijven van een client?

Om een client te schrijven, moet je het volgende doen:

- **De juiste libraries importeren**. Je gebruikt dezelfde library als eerder, maar met andere constructies.
- **Een client instantieren**. Dit houdt in dat je een client instantie maakt en deze verbindt met de gekozen transportmethode.
- **Bepalen welke resources je wilt weergeven**. Je MCP server heeft resources, tools en prompts; je moet beslissen welke je wilt tonen.
- **De client integreren in een hostapplicatie**. Zodra je de mogelijkheden van de server kent, moet je deze integreren in je hostapplicatie zodat wanneer een gebruiker een prompt of ander commando invoert, de bijbehorende serverfunctie wordt aangeroepen.

Nu we op hoofdlijnen begrijpen wat we gaan doen, bekijken we als volgende een voorbeeld.

### Een voorbeeldclient

Laten we eens kijken naar dit voorbeeld van een client:

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

In bovenstaande code:

- Importeren we de libraries
- Maken we een client instantie aan en verbinden deze via stdio als transport.
- Lijsten we prompts, resources en tools en roepen ze allemaal aan.

Daar heb je het, een client die kan communiceren met een MCP Server.

Laten we in de volgende oefening de tijd nemen om elke codefragment te ontleden en uit te leggen wat er gebeurt.

## Oefening: Een client schrijven

Zoals hierboven gezegd, nemen we de tijd om de code uit te leggen, en voel je vrij om mee te coderen als je dat wilt.

### -1- Libraries importeren

Laten we de benodigde libraries importeren. We hebben referenties nodig naar een client en naar ons gekozen transportprotocol, stdio. stdio is een protocol voor toepassingen die lokaal op je machine draaien. SSE is een ander transportprotocol dat we in toekomstige hoofdstukken zullen laten zien, maar dat is je andere optie. Voor nu gaan we verder met stdio.

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

Voor Java maak je een client die verbinding maakt met de MCP server uit de vorige oefening. Gebruik dezelfde Java Spring Boot projectstructuur als in [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), maak een nieuwe Java-klasse genaamd `SDKClient` aan in de map `src/main/java/com/microsoft/mcp/sample/client/` en voeg de volgende imports toe:

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

Laten we doorgaan met het instantieren.

### -2- Client en transport instantieren

We moeten een instantie van het transport maken en een van onze client:

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

In bovenstaande code hebben we:

- Een stdio transport instantie gemaakt. Let op hoe het commando en de argumenten worden gespecificeerd om de server te vinden en op te starten, want dat moeten we doen bij het maken van de client.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Een client geïnstantieerd door een naam en versie mee te geven.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- De client verbonden met het gekozen transport.

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

In bovenstaande code hebben we:

- De benodigde libraries geïmporteerd.
- Een server parameters object geïnstantieerd, dat we gebruiken om de server te starten zodat we er met onze client verbinding mee kunnen maken.
- Een methode `run` gedefinieerd die op zijn beurt `stdio_client` aanroept om een client sessie te starten.
- Een entry point gemaakt waar we de `run` methode aan `asyncio.run` meegeven.

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

In bovenstaande code hebben we:

- De benodigde libraries geïmporteerd.
- Een stdio transport gemaakt en een client `mcpClient` aangemaakt. Deze gebruiken we om features op de MCP Server te lijsten en aan te roepen.

Let op: bij "Arguments" kun je verwijzen naar het *.csproj* bestand of naar de uitvoerbare file.

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

In bovenstaande code hebben we:

- Een main methode gemaakt die een SSE transport opzet dat wijst naar `http://localhost:8080`, waar onze MCP server draait.
- Een client klasse gemaakt die het transport als constructorparameter ontvangt.
- In de `run` methode een synchrone MCP client gemaakt met het transport en de verbinding geïnitialiseerd.
- SSE (Server-Sent Events) transport gebruikt, wat geschikt is voor HTTP-gebaseerde communicatie met Java Spring Boot MCP servers.

### -3- De serverfeatures weergeven

Nu hebben we een client die verbinding kan maken als het programma wordt uitgevoerd. Echter, hij toont nog niet de features, dat doen we nu:

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

Hier lijsten we de beschikbare resources met `list_resources()` en tools met `list_tools` en printen deze uit.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Bovenstaand voorbeeld laat zien hoe we de tools op de server kunnen weergeven. Voor elke tool printen we de naam uit.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

In bovenstaande code hebben we:

- `listTools()` aangeroepen om alle beschikbare tools van de MCP server op te halen.
- `ping()` gebruikt om te verifiëren dat de verbinding met de server werkt.
- `ListToolsResult` bevat informatie over alle tools, inclusief namen, beschrijvingen en input schema’s.

Geweldig, nu hebben we alle features binnengehaald. De vraag is: wanneer gebruiken we ze? Deze client is vrij eenvoudig, in die zin dat we de features expliciet moeten aanroepen wanneer we ze willen gebruiken. In het volgende hoofdstuk maken we een geavanceerdere client die toegang heeft tot een eigen large language model (LLM). Voor nu kijken we hoe we de features op de server kunnen aanroepen:

### -4- Features aanroepen

Om features aan te roepen moeten we de juiste argumenten opgeven en in sommige gevallen de naam van wat we willen aanroepen.

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

In bovenstaande code:

- Lezen we een resource door `readResource()` aan te roepen met `uri`. Zo ziet het er waarschijnlijk uit aan de serverkant:

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

    Onze `uri` waarde `file://example.txt` komt overeen met `file://{name}` op de server. `example.txt` wordt gemapt naar `name`.

- Roepen we een tool aan door de `name` en `arguments` op te geven, zoals:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Haal je een prompt op door `getPrompt()` aan te roepen met `name` en `arguments`. De servercode ziet er zo uit:

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

    En je clientcode ziet er daarom zo uit om overeen te komen met wat op de server is gedeclareerd:

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

In bovenstaande code hebben we:

- Een resource `greeting` aangeroepen met `read_resource`.
- Een tool `add` aangeroepen met `call_tool`.

### C#

1. Laten we wat code toevoegen om een tool aan te roepen:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Om het resultaat te printen, hier wat code om dat te doen:

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

In bovenstaande code hebben we:

- Meerdere calculator tools aangeroepen met de `callTool()` methode en `CallToolRequest` objecten.
- Elke toolaanroep specificeert de toolnaam en een `Map` met argumenten die de tool nodig heeft.
- De servertools verwachten specifieke parameter namen (zoals "a", "b" voor wiskundige bewerkingen).
- Resultaten worden teruggegeven als `CallToolResult` objecten met de respons van de server.

### -5- De client uitvoeren

Om de client uit te voeren, typ je het volgende commando in de terminal:

### TypeScript

Voeg de volgende entry toe aan je "scripts" sectie in *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Roep de client aan met het volgende commando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Zorg eerst dat je MCP server draait op `http://localhost:8080`. Voer daarna de client uit:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Je kunt ook het complete clientproject uitvoeren dat in de solution folder `03-GettingStarted\02-client\solution\java` staat:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Opdracht

In deze opdracht gebruik je wat je geleerd hebt om een client te maken, maar dan een client van jezelf.

Hier is een server die je kunt gebruiken en die je via je clientcode moet aanroepen. Kijk of je meer features aan de server kunt toevoegen om het interessanter te maken.

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

Bekijk dit project om te zien hoe je [prompts en resources kunt toevoegen](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Bekijk ook deze link voor hoe je [prompts en resources kunt aanroepen](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste punten

De belangrijkste punten uit dit hoofdstuk over clients zijn:

- Ze kunnen worden gebruikt om zowel features op de server te ontdekken als aan te roepen.
- Ze kunnen een server starten terwijl ze zelf opstarten (zoals in dit hoofdstuk), maar clients kunnen ook verbinding maken met reeds draaiende servers.
- Ze zijn een uitstekende manier om servermogelijkheden te testen naast alternatieven zoals de Inspector, zoals in het vorige hoofdstuk beschreven.

## Extra bronnen

- [Clients bouwen in MCP](https://modelcontextprotocol.io/quickstart/client)

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Wat volgt

- Volgende: [Een client maken met een LLM](../03-llm-client/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.