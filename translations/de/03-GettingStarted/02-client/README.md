<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T22:17:17+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "de"
}
-->
# Einen Client erstellen

Clients sind benutzerdefinierte Anwendungen oder Skripte, die direkt mit einem MCP-Server kommunizieren, um Ressourcen, Werkzeuge und Prompts anzufordern. Im Gegensatz zum Einsatz des Inspector-Tools, das eine grafische Oberfläche für die Interaktion mit dem Server bietet, ermöglicht das Schreiben eines eigenen Clients programmatische und automatisierte Interaktionen. Dadurch können Entwickler MCP-Funktionen in ihre eigenen Arbeitsabläufe integrieren, Aufgaben automatisieren und maßgeschneiderte Lösungen für spezifische Anforderungen erstellen.

## Überblick

Diese Lektion führt in das Konzept von Clients im Model Context Protocol (MCP)-Ökosystem ein. Du lernst, wie du deinen eigenen Client schreibst und ihn mit einem MCP-Server verbindest.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Zu verstehen, was ein Client leisten kann.
- Deinen eigenen Client zu schreiben.
- Den Client mit einem MCP-Server zu verbinden und zu testen, um sicherzustellen, dass dieser wie erwartet funktioniert.

## Was gehört zum Schreiben eines Clients?

Um einen Client zu schreiben, musst du Folgendes tun:

- **Die richtigen Bibliotheken importieren**. Du verwendest dieselbe Bibliothek wie zuvor, nur mit anderen Konstrukten.
- **Einen Client instanziieren**. Dabei erstellst du eine Client-Instanz und verbindest sie mit der gewählten Transportmethode.
- **Entscheiden, welche Ressourcen aufgelistet werden sollen**. Dein MCP-Server bietet Ressourcen, Werkzeuge und Prompts – du musst entscheiden, welche davon du auflisten möchtest.
- **Den Client in eine Host-Anwendung integrieren**. Sobald du die Fähigkeiten des Servers kennst, musst du den Client in deine Host-Anwendung einbinden, sodass bei Eingabe eines Prompts oder Befehls durch den Nutzer die entsprechende Serverfunktion aufgerufen wird.

Nachdem wir nun auf hoher Ebene verstanden haben, was wir vorhaben, schauen wir uns als Nächstes ein Beispiel an.

### Ein Beispiel-Client

Schauen wir uns diesen Beispiel-Client an:

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

Im obigen Code haben wir:

- Die Bibliotheken importiert
- Eine Client-Instanz erstellt und sie über stdio als Transport verbunden.
- Prompts, Ressourcen und Werkzeuge aufgelistet und alle aufgerufen.

Da hast du es, ein Client, der mit einem MCP-Server kommunizieren kann.

Nehmen wir uns im nächsten Übungsteil Zeit, um jeden Codeabschnitt zu analysieren und zu erklären, was passiert.

## Übung: Einen Client schreiben

Wie oben gesagt, nehmen wir uns Zeit, den Code zu erklären, und du kannst gerne mitprogrammieren.

### -1- Bibliotheken importieren

Lass uns die benötigten Bibliotheken importieren. Wir brauchen Referenzen zu einem Client und zu unserem gewählten Transportprotokoll, stdio. stdio ist ein Protokoll für Anwendungen, die lokal auf deinem Rechner laufen. SSE ist ein weiteres Transportprotokoll, das wir in späteren Kapiteln zeigen werden, aber das ist deine andere Option. Für den Moment machen wir mit stdio weiter.

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

Für Java erstellst du einen Client, der sich mit dem MCP-Server aus der vorherigen Übung verbindet. Verwende die gleiche Java Spring Boot Projektstruktur aus [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), erstelle eine neue Java-Klasse namens `SDKClient` im Ordner `src/main/java/com/microsoft/mcp/sample/client/` und füge folgende Importe hinzu:

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

Kommen wir zur Instanziierung.

### -2- Client und Transport instanziieren

Wir müssen eine Instanz des Transports und des Clients erstellen:

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

Im obigen Code haben wir:

- Eine stdio-Transportinstanz erstellt. Beachte, wie hier Befehl und Argumente angegeben werden, um den Server zu finden und zu starten – das ist notwendig, wenn wir den Client erstellen.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Einen Client instanziiert, indem wir ihm einen Namen und eine Version gegeben haben.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Den Client mit dem gewählten Transport verbunden.

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

Im obigen Code haben wir:

- Die benötigten Bibliotheken importiert
- Ein Server-Parameter-Objekt instanziiert, das wir verwenden, um den Server zu starten, damit wir uns mit unserem Client verbinden können.
- Eine Methode `run` definiert, die wiederum `stdio_client` aufruft, um eine Client-Sitzung zu starten.
- Einen Einstiegspunkt erstellt, an dem wir die `run`-Methode mit `asyncio.run` ausführen.

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

Im obigen Code haben wir:

- Die benötigten Bibliotheken importiert.
- Einen stdio-Transport erstellt und einen Client `mcpClient` erzeugt. Letzteren verwenden wir, um Funktionen auf dem MCP-Server aufzulisten und aufzurufen.

Hinweis: Bei "Arguments" kannst du entweder auf die *.csproj* oder auf die ausführbare Datei verweisen.

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

Im obigen Code haben wir:

- Eine main-Methode erstellt, die einen SSE-Transport einrichtet, der auf `http://localhost:8080` zeigt, wo unser MCP-Server läuft.
- Eine Client-Klasse erstellt, die den Transport als Konstruktorparameter erhält.
- In der `run`-Methode einen synchronen MCP-Client mit dem Transport erzeugt und die Verbindung initialisiert.
- SSE (Server-Sent Events) als Transport verwendet, das sich für HTTP-basierte Kommunikation mit Java Spring Boot MCP-Servern eignet.

### -3- Server-Funktionen auflisten

Jetzt haben wir einen Client, der sich verbinden kann, wenn das Programm ausgeführt wird. Allerdings listet er seine Funktionen noch nicht auf, das machen wir jetzt:

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

Hier listen wir die verfügbaren Ressourcen mit `list_resources()` und Werkzeuge mit `list_tools` auf und geben sie aus.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Oben ein Beispiel, wie wir die Werkzeuge auf dem Server auflisten können. Für jedes Werkzeug geben wir dann den Namen aus.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Im obigen Code haben wir:

- `listTools()` aufgerufen, um alle verfügbaren Werkzeuge vom MCP-Server zu erhalten.
- `ping()` verwendet, um zu überprüfen, ob die Verbindung zum Server funktioniert.
- Das `ListToolsResult` enthält Informationen über alle Werkzeuge, einschließlich ihrer Namen, Beschreibungen und Eingabeschemata.

Super, jetzt haben wir alle Funktionen erfasst. Die Frage ist: Wann verwenden wir sie? Dieser Client ist recht einfach, das heißt, wir müssen die Funktionen explizit aufrufen, wenn wir sie brauchen. Im nächsten Kapitel erstellen wir einen fortgeschritteneren Client, der Zugriff auf ein eigenes großes Sprachmodell (LLM) hat. Für den Moment schauen wir uns an, wie wir die Funktionen auf dem Server aufrufen können:

### -4- Funktionen aufrufen

Um Funktionen aufzurufen, müssen wir sicherstellen, dass wir die richtigen Argumente angeben und in manchen Fällen den Namen der Funktion, die wir aufrufen wollen.

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

Im obigen Code haben wir:

- Eine Ressource gelesen, indem wir `readResource()` mit `uri` aufgerufen haben. So sieht das auf der Serverseite wahrscheinlich aus:

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

    Unser `uri`-Wert `file://example.txt` entspricht `file://{name}` auf dem Server. `example.txt` wird auf `name` abgebildet.

- Ein Werkzeug aufgerufen, indem wir seinen `name` und seine `arguments` so angegeben haben:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Einen Prompt geholt, indem wir `getPrompt()` mit `name` und `arguments` aufgerufen haben. Der Servercode sieht so aus:

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

    Und dein resultierender Client-Code sieht daher so aus, um mit der Serverdeklaration übereinzustimmen:

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

Im obigen Code haben wir:

- Eine Ressource namens `greeting` mit `read_resource` aufgerufen.
- Ein Werkzeug namens `add` mit `call_tool` ausgeführt.

### C#

1. Fügen wir etwas Code hinzu, um ein Werkzeug aufzurufen:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Um das Ergebnis auszugeben, hier etwas Code, der das übernimmt:

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

Im obigen Code haben wir:

- Mehrere Taschenrechner-Werkzeuge mit der Methode `callTool()` und `CallToolRequest`-Objekten aufgerufen.
- Jeder Werkzeugaufruf spezifiziert den Werkzeugnamen und eine `Map` mit den erforderlichen Argumenten.
- Die Server-Werkzeuge erwarten bestimmte Parameternamen (wie "a", "b" für mathematische Operationen).
- Ergebnisse werden als `CallToolResult`-Objekte zurückgegeben, die die Antwort vom Server enthalten.

### -5- Den Client ausführen

Um den Client auszuführen, gib folgenden Befehl im Terminal ein:

### TypeScript

Füge folgenden Eintrag in den Abschnitt "scripts" deiner *package.json* ein:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Rufe den Client mit folgendem Befehl auf:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Stelle zuerst sicher, dass dein MCP-Server auf `http://localhost:8080` läuft. Dann führe den Client aus:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativ kannst du das komplette Client-Projekt aus dem Lösungsordner `03-GettingStarted\02-client\solution\java` ausführen:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Aufgabe

In dieser Aufgabe nutzt du das Gelernte, um einen eigenen Client zu erstellen.

Hier ist ein Server, den du über deinen Client ansprechen kannst. Versuche, dem Server weitere Funktionen hinzuzufügen, um ihn interessanter zu machen.

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

Sieh dir dieses Projekt an, um zu erfahren, wie du [Prompts und Ressourcen hinzufügen kannst](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Schau dir auch diesen Link an, um zu sehen, wie man [Prompts und Ressourcen aufruft](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse dieses Kapitels zu Clients sind:

- Sie können sowohl verwendet werden, um Funktionen auf dem Server zu entdecken als auch aufzurufen.
- Sie können einen Server starten, während sie selbst starten (wie in diesem Kapitel), aber Clients können sich auch mit bereits laufenden Servern verbinden.
- Sie sind eine großartige Möglichkeit, Serverfunktionen zu testen, neben Alternativen wie dem Inspector, wie im vorherigen Kapitel beschrieben.

## Zusätzliche Ressourcen

- [Clients in MCP erstellen](https://modelcontextprotocol.io/quickstart/client)

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Was kommt als Nächstes

- Nächstes Kapitel: [Einen Client mit einem LLM erstellen](../03-llm-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.