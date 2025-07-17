<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:04:44+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "no"
}
-->
# Lage en klient

Klienter er tilpassede applikasjoner eller skript som kommuniserer direkte med en MCP-server for å be om ressurser, verktøy og prompts. I motsetning til å bruke inspektørverktøyet, som gir et grafisk grensesnitt for å samhandle med serveren, gir det å skrive din egen klient mulighet for programmerbar og automatisert interaksjon. Dette gjør det mulig for utviklere å integrere MCP-funksjonalitet i egne arbeidsflyter, automatisere oppgaver og bygge skreddersydde løsninger tilpasset spesifikke behov.

## Oversikt

Denne leksjonen introduserer konseptet klienter innenfor Model Context Protocol (MCP)-økosystemet. Du vil lære hvordan du skriver din egen klient og får den til å koble seg til en MCP-server.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Forstå hva en klient kan gjøre.
- Skrive din egen klient.
- Koble til og teste klienten med en MCP-server for å sikre at den fungerer som forventet.

## Hva kreves for å skrive en klient?

For å skrive en klient må du gjøre følgende:

- **Importere riktige biblioteker**. Du vil bruke det samme biblioteket som før, men med andre konstruksjoner.
- **Opprette en klientinstans**. Dette innebærer å lage en klientinstans og koble den til valgt transportmetode.
- **Bestemme hvilke ressurser som skal listes**. MCP-serveren din har ressurser, verktøy og prompts, og du må bestemme hvilke som skal listes.
- **Integrere klienten i en vertsapplikasjon**. Når du kjenner til serverens funksjonalitet, må du integrere dette i vertsapplikasjonen slik at når en bruker skriver en prompt eller annen kommando, blir tilsvarende serverfunksjon kalt.

Nå som vi har en overordnet forståelse av hva vi skal gjøre, la oss se på et eksempel.

### Et eksempel på en klient

La oss se på dette eksempelklientet:

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

I koden over har vi:

- Importert bibliotekene
- Opprettet en klientinstans og koblet den til ved hjelp av stdio som transport.
- Listet prompts, ressurser og verktøy, og kalt dem alle.

Der har du det, en klient som kan kommunisere med en MCP-server.

La oss ta oss tid i neste øvelse til å gå gjennom hver kodebit og forklare hva som skjer.

## Øvelse: Skrive en klient

Som nevnt over, la oss bruke tid på å forklare koden, og føl gjerne med og skriv kode samtidig om du vil.

### -1- Importere bibliotekene

La oss importere bibliotekene vi trenger. Vi trenger referanser til en klient og til valgt transportprotokoll, stdio. stdio er en protokoll for ting som skal kjøre på din lokale maskin. SSE er en annen transportprotokoll vi vil vise i fremtidige kapitler, men det er et annet alternativ. For nå fortsetter vi med stdio.

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

For Java skal du lage en klient som kobler til MCP-serveren fra forrige øvelse. Bruk samme Java Spring Boot-prosjektstruktur fra [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), opprett en ny Java-klasse kalt `SDKClient` i mappen `src/main/java/com/microsoft/mcp/sample/client/` og legg til følgende imports:

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

La oss gå videre til instansiering.

### -2- Instansiere klient og transport

Vi må opprette en instans av transporten og en av klienten:

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

I koden over har vi:

- Opprettet en stdio transportinstans. Merk hvordan den spesifiserer kommando og argumenter for hvordan serveren skal startes, noe vi trenger når vi lager klienten.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instansiert en klient ved å gi den navn og versjon.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Knyttet klienten til valgt transport.

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

I koden over har vi:

- Importert nødvendige biblioteker
- Instansiert et serverparametere-objekt som vi bruker for å kjøre serveren slik at vi kan koble til den med klienten.
- Definert en metode `run` som kaller `stdio_client` som starter en klientøkt.
- Opprettet et inngangspunkt hvor vi gir `run`-metoden til `asyncio.run`.

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

I koden over har vi:

- Importert nødvendige biblioteker.
- Opprettet en stdio transport og en klient `mcpClient`. Denne bruker vi for å liste og kalle funksjoner på MCP-serveren.

Merk at i "Arguments" kan du peke enten til *.csproj* eller til den kjørbare filen.

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

I koden over har vi:

- Opprettet en main-metode som setter opp en SSE-transport som peker til `http://localhost:8080` hvor MCP-serveren kjører.
- Opprettet en klientklasse som tar transporten som konstruktørparameter.
- I `run`-metoden oppretter vi en synkron MCP-klient med transporten og initialiserer tilkoblingen.
- Brukt SSE (Server-Sent Events) transport som passer for HTTP-basert kommunikasjon med Java Spring Boot MCP-servere.

### -3- Liste serverfunksjonene

Nå har vi en klient som kan koble til når programmet kjøres. Men den lister ikke funksjonene, så la oss gjøre det nå:

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

Her lister vi tilgjengelige ressurser med `list_resources()` og verktøy med `list_tools` og skriver dem ut.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Ovenfor er et eksempel på hvordan vi kan liste verktøyene på serveren. For hvert verktøy skriver vi ut navnet.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

I koden over har vi:

- Kalt `listTools()` for å hente alle tilgjengelige verktøy fra MCP-serveren.
- Brukt `ping()` for å verifisere at tilkoblingen til serveren fungerer.
- `ListToolsResult` inneholder informasjon om alle verktøy, inkludert navn, beskrivelser og input-skjemaer.

Flott, nå har vi hentet alle funksjonene. Spørsmålet er når bruker vi dem? Denne klienten er ganske enkel, i den forstand at vi må eksplisitt kalle funksjonene når vi ønsker det. I neste kapittel lager vi en mer avansert klient som har tilgang til sin egen store språkmodell, LLM. For nå, la oss se hvordan vi kan kalle funksjonene på serveren:

### -4- Kalle funksjoner

For å kalle funksjonene må vi sørge for å spesifisere riktige argumenter og i noen tilfeller navnet på det vi prøver å kalle.

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

I koden over har vi:

- Lest en ressurs ved å kalle `readResource()` med `uri`. Slik ser det mest sannsynlig ut på serversiden:

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

    Vår `uri`-verdi `file://example.txt` matcher `file://{name}` på serveren. `example.txt` blir mappet til `name`.

- Kalt et verktøy ved å spesifisere `name` og `arguments` slik:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Hentet en prompt ved å kalle `getPrompt()` med `name` og `arguments`. Serverkoden ser slik ut:

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

    Og klientkoden din ser derfor slik ut for å matche det som er deklarert på serveren:

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

I koden over har vi:

- Kalt en ressurs kalt `greeting` med `read_resource`.
- Kalt et verktøy kalt `add` med `call_tool`.

### .NET

1. La oss legge til kode for å kalle et verktøy:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. For å skrive ut resultatet, her er kode for det:

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

I koden over har vi:

- Kalt flere kalkulatorverktøy med `callTool()`-metoden og `CallToolRequest`-objekter.
- Hver verktøykall spesifiserer verktøynavn og et `Map` med argumenter som kreves av verktøyet.
- Serververktøyene forventer spesifikke parameter-navn (som "a", "b" for matematiske operasjoner).
- Resultatene returneres som `CallToolResult`-objekter som inneholder svar fra serveren.

### -5- Kjøre klienten

For å kjøre klienten, skriv følgende kommando i terminalen:

### TypeScript

Legg til følgende oppføring i "scripts"-seksjonen i *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Kall klienten med følgende kommando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Først, sørg for at MCP-serveren kjører på `http://localhost:8080`. Kjør deretter klienten:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativt kan du kjøre hele klientprosjektet som ligger i løsningsmappen `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Oppgave

I denne oppgaven skal du bruke det du har lært om å lage en klient, men lage din egen klient.

Her er en server du kan bruke som du må kalle via klientkoden din. Se om du kan legge til flere funksjoner på serveren for å gjøre den mer interessant.

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

Se dette prosjektet for å se hvordan du kan [legge til prompts og ressurser](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Sjekk også denne lenken for hvordan du kaller [prompts og ressurser](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Løsning

**Løsningsmappen** inneholder komplette, kjørbare klientimplementasjoner som demonstrerer alle konseptene dekket i denne veiledningen. Hver løsning inkluderer både klient- og serverkode organisert i separate, selvstendige prosjekter.

### 📁 Løsningsstruktur

Løsningsmappen er organisert etter programmeringsspråk:

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

### 🚀 Hva hver løsning inkluderer

Hver språkspesifikke løsning tilbyr:

- **Fullstendig klientimplementasjon** med alle funksjoner fra veiledningen
- **Fungerende prosjektstruktur** med riktige avhengigheter og konfigurasjon
- **Bygge- og kjøre-skript** for enkel oppsett og kjøring
- **Detaljert README** med språkspesifikke instruksjoner
- **Feilhåndtering** og eksempler på resultatbehandling

### 📖 Bruke løsningene

1. **Naviger til ønsket språkmappe**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Følg README-instruksjonene** i hver mappe for:
   - Installere avhengigheter
   - Bygge prosjektet
   - Kjøre klienten

3. **Eksempelutdata** du bør se:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

For full dokumentasjon og steg-for-steg instruksjoner, se: **[📖 Løsningsdokumentasjon](./solution/README.md)**

## 🎯 Fullstendige eksempler

Vi har levert komplette, fungerende klientimplementasjoner for alle programmeringsspråk som dekkes i denne veiledningen. Disse eksemplene demonstrerer full funksjonalitet som beskrevet ovenfor og kan brukes som referanseimplementasjoner eller utgangspunkt for egne prosjekter.

### Tilgjengelige fullstendige eksempler

| Språk    | Fil                          | Beskrivelse                                                      |
|----------|------------------------------|-----------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)         | Komplett Java-klient med SSE-transport og omfattende feilhåndtering |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)         | Komplett C#-klient med stdio-transport og automatisk serverstart |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Komplett TypeScript-klient med full MCP-protokollstøtte          |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)         | Komplett Python-klient med async/await-mønstre                   |

Hvert komplett eksempel inkluderer:

- ✅ **Etablering av tilkobling** og feilhåndtering
- ✅ **Serveroppdagelse** (verktøy, ressurser, prompts der det er aktuelt)
- ✅ **Kalkulatoroperasjoner** (addere, subtrahere, multiplisere, dividere, hjelp)
- ✅ **Resultatbehandling** og formatert utskrift
- ✅ **Omfattende feilhåndtering**
- ✅ **Ren, dokumentert kode** med steg-for-steg kommentarer

### Komme i gang med fullstendige eksempler

1. **Velg ønsket språk** fra tabellen over
2. **Gå gjennom komplett eksempel-fil** for å forstå full implementasjon
3. **Kjør eksempelet** etter instruksjonene i [`complete_examples.md`](./complete_examples.md)
4. **Endre og utvid** eksempelet for ditt spesifikke brukstilfelle

For detaljert dokumentasjon om kjøring og tilpasning av disse eksemplene, se: **[📖 Fullstendige eksempler dokumentasjon](./complete_examples.md)**

### 💡 Løsning vs. fullstendige eksempler

| **Løsningsmappe**           | **Fullstendige eksempler**          |
|-----------------------------|-----------------------------------|
| Full prosjektstruktur med bygge-filer | Enkeltfil-implementasjoner          |
| Klar til kjøring med avhengigheter | Fokusert kodeeksempler             |
| Produksjonslignende oppsett | Pedagogisk referanse               |
| Språkspesifikk verktøykjede | Sammenligning på tvers av språk    |
Begge tilnærmingene er verdifulle – bruk **solution folder** for komplette prosjekter og **complete examples** for læring og referanse.  
## Viktige punkter

De viktigste punktene for dette kapitlet om klienter er følgende:

- Kan brukes både for å oppdage og kalle funksjoner på serveren.  
- Kan starte en server samtidig som den starter seg selv (som i dette kapittelet), men klienter kan også koble seg til allerede kjørende servere.  
- Er en flott måte å teste serverens funksjonalitet på, ved siden av alternativer som Inspector, slik det ble beskrevet i forrige kapittel.  

## Ekstra ressurser

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Hva kommer nå

- Neste: [Creating a client with an LLM](../03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.