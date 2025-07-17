<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:03:12+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sv"
}
-->
# Skapa en klient

Klienter är anpassade applikationer eller skript som kommunicerar direkt med en MCP Server för att begära resurser, verktyg och prompts. Till skillnad från att använda inspektörsverktyget, som erbjuder ett grafiskt gränssnitt för att interagera med servern, möjliggör det att skriva en egen klient programmatisk och automatiserad interaktion. Detta gör det möjligt för utvecklare att integrera MCP-funktioner i sina egna arbetsflöden, automatisera uppgifter och bygga skräddarsydda lösningar anpassade efter specifika behov.

## Översikt

Den här lektionen introducerar konceptet klienter inom Model Context Protocol (MCP)-ekosystemet. Du kommer att lära dig hur du skriver din egen klient och får den att ansluta till en MCP Server.

## Lärandemål

I slutet av denna lektion ska du kunna:

- Förstå vad en klient kan göra.
- Skriva din egen klient.
- Ansluta och testa klienten med en MCP-server för att säkerställa att den fungerar som förväntat.

## Vad krävs för att skriva en klient?

För att skriva en klient behöver du göra följande:

- **Importera rätt bibliotek**. Du kommer att använda samma bibliotek som tidigare, men med olika konstruktioner.
- **Instansiera en klient**. Detta innebär att skapa en klientinstans och ansluta den till vald transportmetod.
- **Bestäm vilka resurser som ska listas**. Din MCP-server har resurser, verktyg och prompts, du behöver bestämma vilka som ska listas.
- **Integrera klienten i en värdapplikation**. När du känner till serverns kapabiliteter behöver du integrera detta i din värdapplikation så att om en användare skriver en prompt eller annan kommando anropas motsvarande serverfunktion.

Nu när vi på en övergripande nivå förstår vad vi ska göra, låt oss titta på ett exempel.

### Ett exempel på klient

Låt oss titta på detta exempel på en klient:

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

I koden ovan:

- Importerar vi biblioteken
- Skapar en klientinstans och ansluter den med stdio som transport.
- Listar prompts, resurser och verktyg och anropar dem alla.

Där har du det, en klient som kan kommunicera med en MCP Server.

Låt oss ta god tid i nästa övningsavsnitt och bryta ner varje kodsnutt och förklara vad som händer.

## Övning: Skriva en klient

Som sagt ovan, låt oss ta tid på oss att förklara koden, och koda gärna med om du vill.

### -1- Importera biblioteken

Låt oss importera de bibliotek vi behöver, vi kommer behöva referenser till en klient och till vår valda transportprotokoll, stdio. stdio är ett protokoll för saker som ska köras på din lokala maskin. SSE är ett annat transportprotokoll som vi kommer visa i framtida kapitel men det är ditt andra alternativ. För nu, låt oss fortsätta med stdio.

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

För Java skapar du en klient som ansluter till MCP-servern från föregående övning. Använd samma Java Spring Boot-projektstruktur från [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), skapa en ny Java-klass som heter `SDKClient` i mappen `src/main/java/com/microsoft/mcp/sample/client/` och lägg till följande imports:

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

Låt oss gå vidare till instansiering.

### -2- Instansiera klient och transport

Vi behöver skapa en instans av transporten och en av vår klient:

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

I koden ovan har vi:

- Skapat en stdio transportinstans. Notera hur den specificerar kommando och argument för hur servern ska hittas och startas, eftersom det är något vi behöver göra när vi skapar klienten.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instansierat en klient genom att ge den ett namn och en version.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Anslutit klienten till den valda transporten.

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

I koden ovan har vi:

- Importerat de nödvändiga biblioteken
- Instansierat ett serverparametrar-objekt som vi kommer använda för att köra servern så att vi kan ansluta till den med vår klient.
- Definierat en metod `run` som i sin tur anropar `stdio_client` som startar en klient-session.
- Skapat en ingångspunkt där vi skickar `run`-metoden till `asyncio.run`.

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

I koden ovan har vi:

- Importerat de nödvändiga biblioteken.
- Skapat en stdio transport och en klient `mcpClient`. Den senare använder vi för att lista och anropa funktioner på MCP Servern.

Observera att i "Arguments" kan du antingen peka på *.csproj* eller på den körbara filen.

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

I koden ovan har vi:

- Skapat en main-metod som sätter upp en SSE-transport som pekar på `http://localhost:8080` där vår MCP-server kommer att köras.
- Skapat en klientklass som tar transporten som konstruktörsparameter.
- I `run`-metoden skapar vi en synkron MCP-klient med transporten och initierar anslutningen.
- Använt SSE (Server-Sent Events) transport som är lämplig för HTTP-baserad kommunikation med Java Spring Boot MCP-servrar.

### -3- Lista serverns funktioner

Nu har vi en klient som kan ansluta om programmet körs. Men den listar inte faktiskt dess funktioner, så låt oss göra det nu:

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

Här listar vi tillgängliga resurser, `list_resources()` och verktyg, `list_tools` och skriver ut dem.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Ovan är ett exempel på hur vi kan lista verktygen på servern. För varje verktyg skriver vi sedan ut dess namn.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

I koden ovan har vi:

- Anropat `listTools()` för att hämta alla tillgängliga verktyg från MCP-servern.
- Använt `ping()` för att verifiera att anslutningen till servern fungerar.
- `ListToolsResult` innehåller information om alla verktyg inklusive deras namn, beskrivningar och inmatningsscheman.

Bra, nu har vi fångat alla funktioner. Nu är frågan när använder vi dem? Den här klienten är ganska enkel, enkel i den meningen att vi behöver anropa funktionerna explicit när vi vill använda dem. I nästa kapitel kommer vi skapa en mer avancerad klient som har tillgång till sin egen stora språkmodell, LLM. Men för nu, låt oss se hur vi kan anropa funktionerna på servern:

### -4- Anropa funktioner

För att anropa funktionerna behöver vi säkerställa att vi anger rätt argument och i vissa fall namnet på det vi försöker anropa.

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

I koden ovan:

- Läser vi en resurs, vi anropar resursen genom att kalla `readResource()` och specificera `uri`. Så här ser det troligen ut på serversidan:

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

    Vårt `uri`-värde `file://example.txt` matchar `file://{name}` på servern. `example.txt` mappas till `name`.

- Anropar ett verktyg, vi anropar det genom att specificera dess `name` och dess `arguments` så här:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Hämtar en prompt, för att få en prompt anropar du `getPrompt()` med `name` och `arguments`. Serverkoden ser ut så här:

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

    och din resulterande klientkod ser därför ut så här för att matcha vad som deklarerats på servern:

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

I koden ovan har vi:

- Anropat en resurs som heter `greeting` med `read_resource`.
- Anropat ett verktyg som heter `add` med `call_tool`.

### .NET

1. Låt oss lägga till lite kod för att anropa ett verktyg:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. För att skriva ut resultatet, här är lite kod för att hantera det:

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

I koden ovan har vi:

- Anropat flera kalkylatorverktyg med `callTool()`-metoden och `CallToolRequest`-objekt.
- Varje verktygsanrop specificerar verktygets namn och en `Map` med argument som krävs av verktyget.
- Serververktygen förväntar sig specifika parameternamn (som "a", "b" för matematiska operationer).
- Resultaten returneras som `CallToolResult`-objekt som innehåller svaret från servern.

### -5- Kör klienten

För att köra klienten, skriv följande kommando i terminalen:

### TypeScript

Lägg till följande post i din "scripts"-sektion i *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Anropa klienten med följande kommando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Först, se till att din MCP-server körs på `http://localhost:8080`. Kör sedan klienten:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativt kan du köra det kompletta klientprojektet som finns i lösningsmappen `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Uppgift

I denna uppgift ska du använda det du lärt dig om att skapa en klient men skapa en egen klient.

Här är en server du kan använda som du behöver anropa via din klientkod, se om du kan lägga till fler funktioner på servern för att göra den mer intressant.

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

Se detta projekt för att se hur du kan [lägga till prompts och resurser](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Kolla även denna länk för hur du anropar [prompts och resurser](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Lösning

**Lösningsmappen** innehåller kompletta, färdiga klientimplementationer som demonstrerar alla koncept som täcks i denna handledning. Varje lösning inkluderar både klient- och serverkod organiserad i separata, självständiga projekt.

### 📁 Lösningsstruktur

Lösningskatalogen är organiserad efter programmeringsspråk:

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

### 🚀 Vad varje lösning innehåller

Varje språk-specifik lösning erbjuder:

- **Fullständig klientimplementation** med alla funktioner från handledningen
- **Fungerande projektstruktur** med korrekta beroenden och konfiguration
- **Bygg- och körskript** för enkel installation och körning
- **Detaljerad README** med språk-specifika instruktioner
- **Felhantering** och exempel på resultatbearbetning

### 📖 Använda lösningarna

1. **Navigera till din föredragna språk-mapp**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Följ README-instruktionerna** i varje mapp för:
   - Installation av beroenden
   - Bygga projektet
   - Köra klienten

3. **Exempelutdata** du bör se:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

För fullständig dokumentation och steg-för-steg-instruktioner, se: **[📖 Lösningsdokumentation](./solution/README.md)**

## 🎯 Kompletta exempel

Vi har tillhandahållit kompletta, fungerande klientimplementationer för alla programmeringsspråk som täcks i denna handledning. Dessa exempel visar hela funktionaliteten som beskrivs ovan och kan användas som referensimplementationer eller startpunkter för dina egna projekt.

### Tillgängliga kompletta exempel

| Språk    | Fil                          | Beskrivning                                                  |
|----------|------------------------------|--------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Komplett Java-klient med SSE-transport och omfattande felhantering |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Komplett C#-klient med stdio-transport och automatisk serverstart |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Komplett TypeScript-klient med full MCP-protokollsupport       |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Komplett Python-klient med async/await-mönster                 |

Varje komplett exempel innehåller:

- ✅ **Anslutningsupprättande** och felhantering
- ✅ **Serverupptäckt** (verktyg, resurser, prompts där tillämpligt)
- ✅ **Kalkylatoroperationer** (addera, subtrahera, multiplicera, dividera, hjälp)
- ✅ **Resultatbearbetning** och formaterad utskrift
- ✅ **Omfattande felhantering**
- ✅ **Ren, dokumenterad kod** med steg-för-steg-kommentarer

### Kom igång med kompletta exempel

1. **Välj ditt föredragna språk** från tabellen ovan
2. **Granska den kompletta exempel-filen** för att förstå hela implementationen
3. **Kör exemplet** enligt instruktionerna i [`complete_examples.md`](./complete_examples.md)
4. **Modifiera och utöka** exemplet för ditt specifika användningsfall

För detaljerad dokumentation om hur du kör och anpassar dessa exempel, se: **[📖 Kompletta exempel-dokumentation](./complete_examples.md)**

### 💡 Lösning vs. Kompletta exempel

| **Lösningsmapp**           | **Kompletta exempel**          |
|---------------------------|-------------------------------|
| Full projektstruktur med byggfiler | Enkelfilsimplementationer          |
| Färdiga att köra med beroenden | Fokuserade kodexempel             |
| Produktionslik setup       | Pedagogisk referens             |
| Språk-specifika verktyg   | Jämförelse mellan språk         |
Båda metoderna är värdefulla – använd **solution folder** för kompletta projekt och **complete examples** för lärande och referens.  
## Viktiga punkter

De viktigaste punkterna för detta kapitel om klienter är följande:

- Kan användas både för att upptäcka och anropa funktioner på servern.  
- Kan starta en server samtidigt som den startar sig själv (som i detta kapitel), men klienter kan också ansluta till redan igångvarande servrar.  
- Är ett utmärkt sätt att testa serverns kapabiliteter jämfört med alternativ som Inspector, som beskrevs i föregående kapitel.  

## Ytterligare resurser

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Exempel

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Vad händer härnäst

- Nästa: [Creating a client with an LLM](../03-llm-client/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.