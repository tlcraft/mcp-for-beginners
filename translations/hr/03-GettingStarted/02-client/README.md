<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T12:09:52+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hr"
}
-->
# Kreiranje klijenta

Klijenti su prilagođene aplikacije ili skripte koje izravno komuniciraju s MCP Serverom kako bi zatražili resurse, alate i upite. Za razliku od korištenja alata inspektora koji pruža grafičko sučelje za interakciju sa serverom, pisanje vlastitog klijenta omogućuje programsku i automatiziranu interakciju. To omogućuje programerima da integriraju MCP mogućnosti u vlastite radne tokove, automatiziraju zadatke i izgrade prilagođena rješenja prilagođena specifičnim potrebama.

## Pregled

Ova lekcija uvodi pojam klijenata unutar Model Context Protocol (MCP) ekosustava. Naučit ćete kako napisati vlastitog klijenta i povezati ga s MCP Serverom.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Razumjeti što klijent može raditi.
- Napisati vlastitog klijenta.
- Povezati i testirati klijenta s MCP serverom kako biste osigurali da server radi kako se očekuje.

## Što je potrebno za pisanje klijenta?

Za pisanje klijenta potrebno je sljedeće:

- **Uvesti ispravne biblioteke**. Koristit ćete istu biblioteku kao i prije, samo različite konstrukte.
- **Instancirati klijenta**. To uključuje stvaranje instance klijenta i povezivanje s odabranim transportnim načinom.
- **Odlučiti koje resurse želite prikazati**. Vaš MCP server dolazi s resursima, alatima i upitima, potrebno je odlučiti koje ćete prikazati.
- **Integrirati klijenta u glavnu aplikaciju**. Kad znate mogućnosti servera, trebate integrirati klijenta u glavnu aplikaciju tako da, ako korisnik unese upit ili drugu naredbu, odgovarajuća funkcija servera bude pozvana.

Sad kad smo na visokoj razini razumjeli što ćemo raditi, pogledajmo sljedeći primjer.

### Primjer klijenta

Pogledajmo ovaj primjer klijenta:

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

U prethodnom kodu smo:

- Uvezli biblioteke
- Kreirali instancu klijenta i povezali ga koristeći stdio kao transport.
- Izlistali upite, resurse i alate te ih sve pozvali.

Eto ga, klijent koji može komunicirati s MCP Serverom.

U sljedećem dijelu vježbe detaljno ćemo razložiti svaki dio koda i objasniti što se događa.

## Vježba: Pisanje klijenta

Kao što je rečeno, uzet ćemo si vremena za objašnjenje koda, i svakako slobodno kodirajte zajedno s nama.

### -1- Uvoz biblioteka

Uvezimo potrebne biblioteke, trebat će nam reference na klijenta i na odabrani transportni protokol, stdio. stdio je protokol za stvari koje se izvode na lokalnom računalu. SSE je drugi transportni protokol koji ćemo pokazati u budućim poglavljima, ali to je vaša druga opcija. Za sada nastavljamo sa stdio.

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

Za Javu, kreirat ćete klijenta koji se povezuje na MCP server iz prethodne vježbe. Koristeći istu strukturu Java Spring Boot projekta iz [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), kreirajte novu Java klasu pod nazivom `SDKClient` u mapi `src/main/java/com/microsoft/mcp/sample/client/` i dodajte sljedeće uvoze:

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

Krenimo na instanciranje.

### -2- Instanciranje klijenta i transporta

Trebat ćemo kreirati instancu transporta i instancu našeg klijenta:

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

U prethodnom kodu smo:

- Kreirali instancu stdio transporta. Primijetite kako se specificiraju naredba i argumenti za pronalazak i pokretanje servera jer ćemo to trebati prilikom kreiranja klijenta.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instancirali klijenta dajući mu ime i verziju.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Povezali klijenta s odabranim transportom.

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

U prethodnom kodu smo:

- Uvezli potrebne biblioteke
- Instancirali objekt parametara servera koji ćemo koristiti za pokretanje servera kako bismo se mogli povezati s njim putem klijenta.
- Definirali metodu `run` koja poziva `stdio_client` i pokreće klijentsku sesiju.
- Kreirali ulaznu točku gdje pozivamo `run` metodu preko `asyncio.run`.

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

U prethodnom kodu smo:

- Uvezli potrebne biblioteke.
- Kreirali stdio transport i klijenta `mcpClient`. Ovo ćemo koristiti za listanje i pozivanje funkcija na MCP Serveru.

Napomena, u "Arguments" možete navesti ili *.csproj* ili izvršnu datoteku.

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

U prethodnom kodu smo:

- Kreirali glavnu metodu koja postavlja SSE transport usmjeren na `http://localhost:8080` gdje će naš MCP server biti pokrenut.
- Kreirali klasu klijenta koja prima transport kao parametar konstruktora.
- U metodi `run` kreiramo sinkroni MCP klijent koristeći transport i inicijaliziramo vezu.
- Koristili SSE (Server-Sent Events) transport koji je prikladan za HTTP komunikaciju s Java Spring Boot MCP serverima.

### -3- Izlistavanje značajki servera

Sada imamo klijenta koji se može povezati ako se program pokrene. Međutim, on zapravo ne izlistava njegove značajke, pa to napravimo sada:

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

Ovdje izlistavamo dostupne resurse, `list_resources()` i alate, `list_tools` i ispisujemo ih.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Gore je primjer kako možemo izlistati alate na serveru. Za svaki alat ispisujemo njegovo ime.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

U prethodnom kodu smo:

- Pozvali `listTools()` da dobijemo sve dostupne alate s MCP servera.
- Koristili `ping()` da provjerimo radi li veza sa serverom.
- `ListToolsResult` sadrži informacije o svim alatima uključujući njihova imena, opise i ulazne sheme.

Odlično, sada smo dohvatili sve značajke. Sad se postavlja pitanje kada ih koristiti? Ovaj klijent je prilično jednostavan, u smislu da ćemo morati eksplicitno pozivati značajke kad ih želimo. U sljedećem poglavlju kreirat ćemo naprednijeg klijenta koji ima pristup vlastitom velikom jezičnom modelu, LLM-u. Za sada, pogledajmo kako možemo pozvati značajke na serveru:

### -4- Pozivanje značajki

Za pozivanje značajki moramo osigurati da navedemo ispravne argumente i u nekim slučajevima ime onoga što želimo pozvati.

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

U prethodnom kodu smo:

- Pročitali resurs, pozivamo resurs koristeći `readResource()` i specificiramo `uri`. Evo kako to najvjerojatnije izgleda na strani servera:

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

    Naša vrijednost `uri` `file://example.txt` odgovara `file://{name}` na serveru. `example.txt` će biti mapiran na `name`.

- Pozvali alat, pozivamo ga specificirajući njegovo `name` i `arguments` ovako:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Dohvatili upit, za to pozivamo `getPrompt()` s `name` i `arguments`. Kod servera izgleda ovako:

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

    a vaš klijentski kod izgleda ovako da odgovara onome što je deklarirano na serveru:

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

U prethodnom kodu smo:

- Pozvali resurs nazvan `greeting` koristeći `read_resource`.
- Pozvali alat nazvan `add` koristeći `call_tool`.

### .NET

1. Dodajmo kod za pozivanje alata:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Za ispis rezultata, evo koda za to:

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

U prethodnom kodu smo:

- Pozvali više kalkulatorskih alata koristeći metodu `callTool()` s objektima `CallToolRequest`.
- Svaki poziv alata specificira ime alata i `Map` argumenata potrebnih za taj alat.
- Server alati očekuju specifična imena parametara (kao "a", "b" za matematičke operacije).
- Rezultati se vraćaju kao objekti `CallToolResult` koji sadrže odgovor servera.

### -5- Pokretanje klijenta

Za pokretanje klijenta, upišite sljedeću naredbu u terminal:

### TypeScript

Dodajte sljedeći unos u sekciju "scripts" u *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Pokrenite klijenta sljedećom naredbom:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Prvo, provjerite da je vaš MCP server pokrenut na `http://localhost:8080`. Zatim pokrenite klijenta:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativno, možete pokrenuti kompletan klijentski projekt iz mape rješenja `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Zadatak

U ovom zadatku iskoristit ćete ono što ste naučili o kreiranju klijenta, ali napraviti vlastitog klijenta.

Evo servera koji možete koristiti i kojem trebate pristupiti putem svog klijentskog koda, pokušajte dodati više značajki serveru kako bi bio zanimljiviji.

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

Pogledajte ovaj projekt da vidite kako možete [dodati upite i resurse](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Također, provjerite ovaj link za način pozivanja [upita i resursa](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Rješenje

**Mapa rješenja** sadrži kompletne, spremne za pokretanje implementacije klijenata koje demonstriraju sve koncepte obrađene u ovom vodiču. Svako rješenje uključuje i klijentski i serverski kod organiziran u zasebne, samostalne projekte.

### 📁 Struktura rješenja

Direktorij rješenja organiziran je po programskim jezicima:

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

### 🚀 Što svako rješenje uključuje

Svako rješenje specifično za jezik pruža:

- **Potpunu implementaciju klijenta** sa svim značajkama iz vodiča
- **Funkcionalnu strukturu projekta** s ispravnim ovisnostima i konfiguracijom
- **Skripte za izgradnju i pokretanje** za jednostavnu postavu i izvršavanje
- **Detaljan README** s uputama specifičnim za jezik
- **Primjere rukovanja pogreškama** i obrade rezultata

### 📖 Korištenje rješenja

1. **Navigirajte do mape za željeni programski jezik**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Slijedite upute u README datoteci** u svakoj mapi za:
   - Instalaciju ovisnosti
   - Izgradnju projekta
   - Pokretanje klijenta

3. **Primjer izlaza** koji biste trebali vidjeti:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Za kompletnu dokumentaciju i upute korak po korak, pogledajte: **[📖 Dokumentacija rješenja](./solution/README.md)**

## 🎯 Kompletni primjeri

Pripremili smo kompletne, funkcionalne implementacije klijenata za sve programske jezike obrađene u ovom vodiču. Ovi primjeri demonstriraju punu funkcionalnost opisanu gore i mogu se koristiti kao referentne implementacije ili polazne točke za vaše vlastite projekte.

### Dostupni kompletni primjeri

| Jezik    | Datoteka                      | Opis                                                        |
|----------|-------------------------------|-------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Kompletan Java klijent koristeći SSE transport s detaljnim rukovanjem pogreškama |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Kompletan C# klijent koristeći stdio transport s automatskim pokretanjem servera |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Kompletan TypeScript klijent s punom podrškom MCP protokola |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Kompletan Python klijent koristeći async/await obrasce       |

Svaki kompletan primjer uključuje:

- ✅ **Uspostavu veze** i rukovanje pogreškama
- ✅ **Otkrivanje servera** (alati, resursi, upiti gdje je primjenjivo)
- ✅ **Operacije kalkulatora** (zbrajanje, oduzimanje, množenje, dijeljenje, pomoć)
- ✅ **Obradu rezultata** i formatirani ispis
- ✅ **Sveobuhvatno rukovanje pogreškama**
- ✅ **Čist, dokumentiran kod** s komentarima korak po korak

### Početak rada s kompletnim primjerima

1. **Odaberite željeni programski jezik** iz tablice gore
2. **Pregledajte datoteku kompletnog primjera** da razumijete punu implementaciju
3. **Pokrenite primjer** slijedeći upute u [`complete_examples.md`](./complete_examples.md)
4. **Modificirajte i proširite** primjer za svoje specifične potrebe

Za detaljnu dokumentaciju o pokretanju i prilagodbi ovih primjera, pogledajte: **[📖 Dokumentacija kompletnog primjera](./complete_examples.md)**

### 💡 Rješenje vs. Kompletni primjeri

| **Mapa rješenja**           | **Kompletni primjeri**          |
|-----------------------------|--------------------------------|
| Potpuna struktura projekta s build datotekama | Implementacije u jednoj datoteci |
| Spremno za pokretanje s ovisnostima | Fokusirani primjeri koda         |
| Postavka nalik produkcijskoj | Edukativna referenca            |
| Alati specifični za jezik    | Usporedba među jezicima         |
Oba pristupa su vrijedna - koristite **solution folder** za kompletne projekte i **complete examples** za učenje i referencu.  
## Ključne napomene

Ključne napomene za ovo poglavlje o klijentima su sljedeće:

- Mogu se koristiti i za otkrivanje i za pozivanje značajki na serveru.  
- Mogu pokrenuti server dok se sami pokreću (kao u ovom poglavlju), ali klijenti se također mogu povezati s već pokrenutim serverima.  
- Izvrsna su metoda za testiranje mogućnosti servera uz alternative poput Inspectora, kako je opisano u prethodnom poglavlju.  

## Dodatni resursi

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Što slijedi

- Sljedeće: [Creating a client with an LLM](../03-llm-client/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.