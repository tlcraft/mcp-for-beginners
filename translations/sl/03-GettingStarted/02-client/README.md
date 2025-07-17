<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T12:24:33+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sl"
}
-->
# Ustvarjanje odjemalca

Odjemalci so prilagojene aplikacije ali skripte, ki neposredno komunicirajo z MCP strežnikom za zahtevanje virov, orodij in pozivov. Za razliko od uporabe orodja inspector, ki ponuja grafični vmesnik za interakcijo s strežnikom, pisanje lastnega odjemalca omogoča programirane in avtomatizirane interakcije. To razvijalcem omogoča, da integrirajo zmogljivosti MCP v svoje delovne procese, avtomatizirajo naloge in ustvarijo prilagojene rešitve, prilagojene specifičnim potrebam.

## Pregled

Ta lekcija uvaja koncept odjemalcev znotraj ekosistema Model Context Protocol (MCP). Naučili se boste, kako napisati svojega odjemalca in ga povezati z MCP strežnikom.

## Cilji učenja

Do konca te lekcije boste znali:

- Razumeti, kaj odjemalec zmore.
- Napisati svojega odjemalca.
- Povezati in preizkusiti odjemalca z MCP strežnikom, da zagotovite, da strežnik deluje kot pričakovano.

## Kaj je potrebno za pisanje odjemalca?

Za pisanje odjemalca boste morali narediti naslednje:

- **Uvoziti pravilne knjižnice**. Uporabljali boste isto knjižnico kot prej, le drugačne konstrukte.
- **Ustvariti instanco odjemalca**. To vključuje ustvarjanje odjemalčeve instance in povezavo z izbranim transportnim načinom.
- **Odločiti se, katere vire boste našteli**. Vaš MCP strežnik ima vire, orodja in pozive, odločiti se morate, katere boste prikazali.
- **Integrirati odjemalca v gostujočo aplikacijo**. Ko poznate zmogljivosti strežnika, morate to integrirati v svojo gostujočo aplikacijo, tako da se ob vnosu poziva ali drugega ukaza uporabnika sproži ustrezna funkcija strežnika.

Zdaj, ko na visoki ravni razumemo, kaj bomo naredili, si poglejmo primer.

### Primer odjemalca

Poglejmo si ta primer odjemalca:

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

V zgornji kodi smo:

- Uvozili knjižnice
- Ustvarili instanco odjemalca in ga povezali z uporabo stdio za transport.
- Našteli pozive, vire in orodja ter jih vse poklicali.

Tako, imate odjemalca, ki lahko komunicira z MCP strežnikom.

V naslednjem delu vaje si bomo vzeli čas, da razčlenimo vsak del kode in razložimo, kaj se dogaja.

## Vaja: Pisanje odjemalca

Kot smo že omenili, si bomo vzeli čas za razlago kode, in seveda, če želite, lahko kodo pišete skupaj z nami.

### -1- Uvoz knjižnic

Uvozimo potrebne knjižnice, potrebovali bomo reference na odjemalca in na izbrani transportni protokol, stdio. stdio je protokol za stvari, ki naj bi tekle na lokalnem računalniku. SSE je drug transportni protokol, ki ga bomo pokazali v prihodnjih poglavjih, a to je vaša druga možnost. Za zdaj pa nadaljujmo s stdio.

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

Za Javo boste ustvarili odjemalca, ki se poveže z MCP strežnikom iz prejšnje vaje. Uporabite isto strukturo projekta Java Spring Boot iz [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), ustvarite novo Java razred `SDKClient` v mapi `src/main/java/com/microsoft/mcp/sample/client/` in dodajte naslednje uvoze:

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

Pojdimo naprej k instanciranju.

### -2- Instanciranje odjemalca in transporta

Ustvariti moramo instanco transporta in instanco odjemalca:

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

V zgornji kodi smo:

- Ustvarili instanco stdio transporta. Opazite, kako so določeni ukaz in argumenti za iskanje in zagon strežnika, saj bomo to potrebovali pri ustvarjanju odjemalca.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instancirali odjemalca z imenom in verzijo.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Povezali odjemalca z izbranim transportom.

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

V zgornji kodi smo:

- Uvozili potrebne knjižnice
- Instancirali objekt parametrov strežnika, saj ga bomo uporabili za zagon strežnika, da se lahko povežemo z odjemalcem.
- Definirali metodo `run`, ki kliče `stdio_client`, ki zažene odjemalčevo sejo.
- Ustvarili vstopno točko, kjer podamo metodo `run` funkciji `asyncio.run`.

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

V zgornji kodi smo:

- Uvozili potrebne knjižnice.
- Ustvarili stdio transport in odjemalca `mcpClient`. To bomo uporabili za naštetje in klic funkcij na MCP strežniku.

Opomba: v "Arguments" lahko navedete bodisi *.csproj* bodisi izvršljivo datoteko.

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

V zgornji kodi smo:

- Ustvarili glavno metodo, ki nastavi SSE transport, usmerjen na `http://localhost:8080`, kjer bo tekel naš MCP strežnik.
- Ustvarili razred odjemalca, ki kot parameter konstruktorja prejme transport.
- V metodi `run` ustvarili sinhroni MCP odjemalec z uporabo transporta in inicializirali povezavo.
- Uporabili SSE (Server-Sent Events) transport, ki je primeren za HTTP komunikacijo z MCP strežniki Java Spring Boot.

### -3- Naštevanje funkcij strežnika

Zdaj imamo odjemalca, ki se lahko poveže, če program zaženemo. Vendar pa še ne našteje funkcij, zato to naredimo zdaj:

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

Tukaj naštetemo razpoložljive vire, `list_resources()` in orodja, `list_tools` ter jih izpišemo.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Zgoraj je primer, kako lahko naštetemo orodja na strežniku. Za vsako orodje nato izpišemo njegovo ime.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

V zgornji kodi smo:

- Poklicali `listTools()`, da pridobimo vsa razpoložljiva orodja z MCP strežnika.
- Uporabili `ping()`, da preverimo, ali povezava s strežnikom deluje.
- `ListToolsResult` vsebuje informacije o vseh orodjih, vključno z njihovimi imeni, opisi in vhodnimi shemami.

Odlično, zdaj smo zajeli vse funkcije. Zdaj pa vprašanje, kdaj jih uporabimo? Ta odjemalec je precej preprost, kar pomeni, da moramo funkcije izrecno poklicati, ko jih želimo uporabiti. V naslednjem poglavju bomo ustvarili bolj naprednega odjemalca, ki bo imel dostop do lastnega velikega jezikovnega modela (LLM). Za zdaj pa poglejmo, kako lahko pokličemo funkcije na strežniku:

### -4- Klic funkcij

Za klic funkcij moramo zagotoviti pravilne argumente in v nekaterih primerih ime tistega, kar želimo poklicati.

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

V zgornji kodi smo:

- Prebrali vir, kličemo vir z `readResource()`, kjer določimo `uri`. Tako naj bi izgledalo na strežniški strani:

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

    Naša vrednost `uri` `file://example.txt` ustreza `file://{name}` na strežniku. `example.txt` bo preslikan v `name`.

- Poklicali orodje, ki ga kličemo z določitvijo njegovega `name` in `arguments` tako:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Pridobili poziv, za to pokličemo `getPrompt()` z `name` in `arguments`. Strežniška koda izgleda takole:

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

    in vaša odjemalčeva koda zato izgleda takole, da ustreza tistemu, kar je deklarirano na strežniku:

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

V zgornji kodi smo:

- Poklicali vir z imenom `greeting` z uporabo `read_resource`.
- Poklicali orodje z imenom `add` z uporabo `call_tool`.

### .NET

1. Dodajmo kodo za klic orodja:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Za izpis rezultata, tukaj je koda za to:

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

V zgornji kodi smo:

- Poklicali več orodij kalkulatorja z metodo `callTool()` in objekti `CallToolRequest`.
- Vsak klic orodja določa ime orodja in `Map` argumentov, ki jih orodje zahteva.
- Strežniška orodja pričakujejo specifična imena parametrov (kot "a", "b" za matematične operacije).
- Rezultati so vrnjeni kot objekti `CallToolResult`, ki vsebujejo odgovor strežnika.

### -5- Zagon odjemalca

Za zagon odjemalca v terminal vpišite naslednji ukaz:

### TypeScript

Dodajte naslednji vnos v razdelek "scripts" v *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Odjemalca zaženite z naslednjim ukazom:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Najprej poskrbite, da vaš MCP strežnik teče na `http://localhost:8080`. Nato zaženite odjemalca:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Lahko pa zaženete celoten projekt odjemalca, ki je na voljo v rešitveni mapi `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Naloga

V tej nalogi boste uporabili naučeno za ustvarjanje odjemalca, a boste ustvarili svojega.

Tukaj je strežnik, ki ga lahko uporabite in ga morate klicati preko svoje odjemalčeve kode. Poskusite dodati več funkcij strežniku, da bo bolj zanimiv.

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

Oglejte si ta projekt, da vidite, kako lahko [dodate pozive in vire](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Prav tako preverite ta povezavo za navodila, kako klicati [pozive in vire](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Rešitev

**Mapa z rešitvijo** vsebuje popolne, pripravljene za zagon implementacije odjemalcev, ki prikazujejo vse koncepte, obravnavane v tem vodiču. Vsaka rešitev vključuje tako kodo odjemalca kot strežnika, organizirano v ločene, samostojne projekte.

### 📁 Struktura rešitve

Mapa z rešitvijo je organizirana po programskih jezikih:

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

### 🚀 Kaj vključuje vsaka rešitev

Vsaka rešitev za določen jezik ponuja:

- **Popolno implementacijo odjemalca** z vsemi funkcijami iz vodiča
- **Delujočo strukturo projekta** s pravilnimi odvisnostmi in konfiguracijo
- **Skripte za gradnjo in zagon** za enostavno nastavitev in izvajanje
- **Podroben README** z navodili za posamezen jezik
- **Primeri obravnave napak** in obdelave rezultatov

### 📖 Uporaba rešitev

1. **Pojdite v mapo za želeni programski jezik**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Sledite navodilom v README v vsaki mapi za**:
   - Namestitev odvisnosti
   - Gradnjo projekta
   - Zagon odjemalca

3. **Primer izpisa, ki ga boste videli**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Za popolno dokumentacijo in navodila po korakih glejte: **[📖 Dokumentacija rešitve](./solution/README.md)**

## 🎯 Popolni primeri

Pripravili smo popolne, delujoče implementacije odjemalcev za vse programske jezike, obravnavane v tem vodiču. Ti primeri prikazujejo celotno funkcionalnost, opisano zgoraj, in jih lahko uporabite kot referenčne implementacije ali izhodišča za svoje projekte.

### Na voljo popolni primeri

| Jezik    | Datoteka                      | Opis                                                        |
|----------|-------------------------------|-------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Popoln Java odjemalec z uporabo SSE transporta in obsežno obravnavo napak |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Popoln C# odjemalec z uporabo stdio transporta in samodejnim zagonom strežnika |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Popoln TypeScript odjemalec s polno podporo MCP protokola      |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Popoln Python odjemalec z uporabo async/await vzorcev         |

Vsak popoln primer vključuje:

- ✅ **Vzpostavitev povezave** in obravnavo napak
- ✅ **Odkritje strežnika** (orodja, viri, pozivi, kjer je primerno)
- ✅ **Operacije kalkulatorja** (seštevanje, odštevanje, množenje, deljenje, pomoč)
- ✅ **Obdelavo rezultatov** in formatiran izpis
- ✅ **Obsežno obravnavo napak**
- ✅ **Čisto, dokumentirano kodo** z razlagami po korakih

### Začetek s popolnimi primeri

1. **Izberite želeni programski jezik** iz zgornje tabele
2. **Preglejte datoteko s popolnim primerom**, da razumete celotno implementacijo
3. **Zaženite primer** po navodilih v [`complete_examples.md`](./complete_examples.md)
4. **Prilagodite in razširite** primer za svoj specifičen primer uporabe

Za podrobno dokumentacijo o zagonu in prilagajanju teh primerov glejte: **[📖 Dokumentacija popolnih primerov](./complete_examples.md)**

### 💡 Rešitev proti popolnim primerom

| **Mapa z rešitvijo**          | **Popolni primeri**               |
|------------------------------|----------------------------------|
| Polna struktura projekta z gradbenimi datotekami | Implementacije v eni datoteki       |
| Pripravljeno za zagon z odvisnostmi | Osredotočeni primeri kode          |
| Nastavitev, podobna produkcijskemu okolju | Izobraževalna referenca            |
| Orodja specifična za jezik    | Primerjava med jeziki             |
Oba pristopa sta dragocena – za celovite projekte uporabite **mapo solution**, za učenje in referenco pa **popolne primere**.  
## Ključne ugotovitve

Ključne ugotovitve tega poglavja o klientih so naslednje:

- Uporabljajo se lahko tako za odkrivanje kot za klicanje funkcionalnosti na strežniku.  
- Lahko zaženejo strežnik, medtem ko se sami zaženejo (kot v tem poglavju), vendar se lahko klienti povežejo tudi z že delujočimi strežniki.  
- So odličen način za preizkušanje zmogljivosti strežnika poleg drugih možnosti, kot je Inspector, kot je bilo opisano v prejšnjem poglavju.  

## Dodatni viri

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Primeri

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Kaj sledi

- Naslednje: [Creating a client with an LLM](../03-llm-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.