<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "22afa94e3912cd37af9ff20cf4aebc93",
  "translation_date": "2025-07-22T08:33:53+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "de"
}
-->
# Erstellen eines Clients

Clients sind benutzerdefinierte Anwendungen oder Skripte, die direkt mit einem MCP-Server kommunizieren, um Ressourcen, Tools und Eingabeaufforderungen anzufordern. Im Gegensatz zur Verwendung des Inspektor-Tools, das eine grafische Benutzeroberfläche für die Interaktion mit dem Server bietet, ermöglicht das Schreiben eines eigenen Clients programmatische und automatisierte Interaktionen. Dies ermöglicht Entwicklern, MCP-Funktionen in ihre eigenen Arbeitsabläufe zu integrieren, Aufgaben zu automatisieren und maßgeschneiderte Lösungen für spezifische Anforderungen zu erstellen.

## Überblick

Diese Lektion führt in das Konzept von Clients innerhalb des Model Context Protocol (MCP)-Ökosystems ein. Sie lernen, wie Sie Ihren eigenen Client schreiben und ihn mit einem MCP-Server verbinden.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Verstehen, was ein Client leisten kann.
- Ihren eigenen Client schreiben.
- Den Client mit einem MCP-Server verbinden und testen, um sicherzustellen, dass dieser wie erwartet funktioniert.

## Was gehört zum Schreiben eines Clients?

Um einen Client zu schreiben, müssen Sie Folgendes tun:

- **Die richtigen Bibliotheken importieren**. Sie verwenden dieselbe Bibliothek wie zuvor, nur mit anderen Konstrukten.
- **Einen Client instanziieren**. Dies beinhaltet das Erstellen einer Client-Instanz und deren Verbindung mit der gewählten Transportmethode.
- **Entscheiden, welche Ressourcen aufgelistet werden sollen**. Ihr MCP-Server verfügt über Ressourcen, Tools und Eingabeaufforderungen. Sie müssen entscheiden, welche davon aufgelistet werden sollen.
- **Den Client in eine Host-Anwendung integrieren**. Sobald Sie die Fähigkeiten des Servers kennen, müssen Sie ihn in Ihre Host-Anwendung integrieren, sodass bei Eingabe einer Eingabeaufforderung oder eines anderen Befehls durch den Benutzer die entsprechende Serverfunktion aufgerufen wird.

Nachdem wir nun auf hoher Ebene verstanden haben, was wir tun werden, schauen wir uns als Nächstes ein Beispiel an.

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

- Die Bibliotheken importiert.
- Eine Instanz eines Clients erstellt und ihn über stdio für den Transport verbunden.
- Eingabeaufforderungen, Ressourcen und Tools aufgelistet und alle aufgerufen.

Da haben Sie es, ein Client, der mit einem MCP-Server kommunizieren kann.

Nehmen wir uns Zeit im nächsten Übungsabschnitt und zerlegen jeden Code-Schnipsel, um zu erklären, was vor sich geht.

## Übung: Einen Client schreiben

Wie oben erwähnt, nehmen wir uns Zeit, um den Code zu erklären, und Sie können gerne mitprogrammieren, wenn Sie möchten.

### -1- Die Bibliotheken importieren

Importieren wir die benötigten Bibliotheken. Wir benötigen Referenzen zu einem Client und zu unserem gewählten Transportprotokoll, stdio. stdio ist ein Protokoll für Dinge, die auf Ihrem lokalen Rechner laufen sollen. SSE ist ein weiteres Transportprotokoll, das wir in zukünftigen Kapiteln zeigen werden, aber das ist Ihre andere Option. Für jetzt machen wir jedoch mit stdio weiter.

#### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

#### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

#### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

#### Java

Für Java erstellen Sie einen Client, der sich mit dem MCP-Server aus der vorherigen Übung verbindet. Verwenden Sie dieselbe Java Spring Boot-Projektstruktur aus [Erste Schritte mit MCP-Server](../../../../03-GettingStarted/01-first-server/solution/java), erstellen Sie eine neue Java-Klasse namens `SDKClient` im Ordner `src/main/java/com/microsoft/mcp/sample/client/` und fügen Sie die folgenden Importe hinzu:

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

Gehen wir zur Instanziierung über.

### -2- Client und Transport instanziieren

Wir müssen eine Instanz des Transports und eine des Clients erstellen:

#### TypeScript

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

- Eine stdio-Transportinstanz erstellt. Beachten Sie, wie sie Befehl und Argumente angibt, um den Server zu finden und zu starten, da wir dies tun müssen, wenn wir den Client erstellen.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Einen Client instanziiert, indem wir ihm einen Namen und eine Version geben.

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

Im obigen Code haben wir:

- Die benötigten Bibliotheken importiert.
- Ein Server-Parameter-Objekt instanziiert, da wir dies verwenden werden, um den Server zu starten, damit wir uns mit unserem Client verbinden können.
- Eine Methode `run` definiert, die wiederum `stdio_client` aufruft, um eine Client-Sitzung zu starten.
- Einen Einstiegspunkt erstellt, an dem wir die `run`-Methode an `asyncio.run` übergeben.

#### .NET

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
- Einen stdio-Transport erstellt und einen Client `mcpClient` erstellt. Letzterer ist etwas, das wir verwenden werden, um Funktionen auf dem MCP-Server aufzulisten und aufzurufen.

Beachten Sie, dass Sie in "Arguments" entweder auf die *.csproj* oder auf die ausführbare Datei verweisen können.

#### Java

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

- Eine Hauptmethode erstellt, die einen SSE-Transport einrichtet, der auf `http://localhost:8080` verweist, wo unser MCP-Server laufen wird.
- Eine Client-Klasse erstellt, die den Transport als Konstruktorparameter übernimmt.
- In der `run`-Methode einen synchronen MCP-Client mit dem Transport erstellt und die Verbindung initialisiert.
- SSE (Server-Sent Events)-Transport verwendet, der für HTTP-basierte Kommunikation mit Java Spring Boot MCP-Servern geeignet ist.

### -3- Die Serverfunktionen auflisten

Nun haben wir einen Client, der sich verbinden kann, wenn das Programm ausgeführt wird. Allerdings listet er seine Funktionen nicht auf, also machen wir das als Nächstes:

#### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

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
```

Hier listen wir die verfügbaren Ressourcen mit `list_resources()` und Tools mit `list_tools` und geben sie aus.

#### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Oben ist ein Beispiel, wie wir die Tools auf dem Server auflisten können. Für jedes Tool geben wir dann seinen Namen aus.

#### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Im obigen Code haben wir:

- `listTools()` aufgerufen, um alle verfügbaren Tools vom MCP-Server zu erhalten.
- `ping()` verwendet, um zu überprüfen, ob die Verbindung zum Server funktioniert.
- Das `ListToolsResult` enthält Informationen über alle Tools, einschließlich ihrer Namen, Beschreibungen und Eingabeschablonen.

Super, jetzt haben wir alle Funktionen erfasst. Nun stellt sich die Frage, wann wir sie verwenden? Nun, dieser Client ist ziemlich einfach, einfach in dem Sinne, dass wir die Funktionen explizit aufrufen müssen, wenn wir sie verwenden möchten. Im nächsten Kapitel erstellen wir einen fortgeschritteneren Client, der Zugriff auf sein eigenes großes Sprachmodell (LLM) hat. Für jetzt sehen wir uns jedoch an, wie wir die Funktionen auf dem Server aufrufen können:

### -4- Funktionen aufrufen

Um die Funktionen aufzurufen, müssen wir sicherstellen, dass wir die richtigen Argumente und in einigen Fällen den Namen dessen, was wir aufrufen möchten, angeben.

#### TypeScript

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

- Eine Ressource gelesen, indem wir `readResource()` mit `uri` aufgerufen haben. So sieht es höchstwahrscheinlich auf der Serverseite aus:

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

- Ein Tool aufgerufen, indem wir seinen `name` und seine `arguments` wie folgt angegeben haben:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Eine Eingabeaufforderung abgerufen, indem wir `getPrompt()` mit `name` und `arguments` aufgerufen haben. Der Servercode sieht so aus:

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

    und Ihr resultierender Clientcode sieht daher so aus, um das auf dem Server deklarierte zu entsprechen:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

#### Python

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
- Ein Tool namens `add` mit `call_tool` aufgerufen.

#### .NET

1. Fügen wir etwas Code hinzu, um ein Tool aufzurufen:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Um das Ergebnis auszugeben, hier ein Code, um dies zu behandeln:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

#### Java

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

- Mehrere Rechner-Tools mit der Methode `callTool()` und `CallToolRequest`-Objekten aufgerufen.
- Jeder Tool-Aufruf gibt den Tool-Namen und eine `Map` der Argumente an, die von diesem Tool benötigt werden.
- Die Server-Tools erwarten spezifische Parameternamen (wie "a", "b" für mathematische Operationen).
- Ergebnisse werden als `CallToolResult`-Objekte zurückgegeben, die die Antwort vom Server enthalten.

### -5- Den Client ausführen

Um den Client auszuführen, geben Sie den folgenden Befehl im Terminal ein:

#### TypeScript

Fügen Sie den folgenden Eintrag in den Abschnitt "scripts" in *package.json* hinzu:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

#### Python

Rufen Sie den Client mit folgendem Befehl auf:

```sh
python client.py
```

#### .NET

```sh
dotnet run
```

#### Java

Stellen Sie zunächst sicher, dass Ihr MCP-Server unter `http://localhost:8080` läuft. Führen Sie dann den Client aus:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativ können Sie das vollständige Client-Projekt aus dem Lösungsordner `03-GettingStarted\02-client\solution\java` ausführen:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Aufgabe

In dieser Aufgabe verwenden Sie das Gelernte, um einen eigenen Client zu erstellen.

Hier ist ein Server, den Sie verwenden können und den Sie über Ihren Client-Code aufrufen müssen. Versuchen Sie, dem Server weitere Funktionen hinzuzufügen, um ihn interessanter zu machen.

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

Sehen Sie sich dieses Projekt an, um zu erfahren, wie Sie [Eingabeaufforderungen und Ressourcen hinzufügen](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Sehen Sie sich auch diesen Link an, um zu erfahren, wie Sie [Eingabeaufforderungen und Ressourcen aufrufen](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Lösung

Der **Lösungsordner** enthält vollständige, einsatzbereite Client-Implementierungen, die alle in diesem Tutorial behandelten Konzepte demonstrieren. Jede Lösung enthält sowohl Client- als auch Server-Code, organisiert in separaten, eigenständigen Projekten.

### 📁 Lösungsstruktur

Das Lösungsverzeichnis ist nach Programmiersprache organisiert:

```text
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

### 🚀 Was jede Lösung enthält

Jede sprachspezifische Lösung bietet:

- **Vollständige Client-Implementierung** mit allen Funktionen aus dem Tutorial
- **Funktionsfähige Projektstruktur** mit den richtigen Abhängigkeiten und Konfigurationen
- **Build- und Ausführungsskripte** für einfache Einrichtung und Ausführung
- **Detaillierte README** mit sprachspezifischen Anweisungen
- **Fehlerbehandlungs- und Ergebnisverarbeitungsbeispiele**

### 📖 Verwendung der Lösungen

1. **Navigieren Sie zu Ihrem bevorzugten Sprachordner**:

   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Befolgen Sie die README-Anweisungen** in jedem Ordner für:
   - Installation der Abhängigkeiten
   - Aufbau des Projekts
   - Ausführung des Clients

3. **Beispielausgabe**, die Sie sehen sollten:

   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Für vollständige Dokumentation und Schritt-für-Schritt-Anweisungen siehe: **[📖 Lösungsdokumentation](./solution/README.md)**

## 🎯 Vollständige Beispiele

Wir haben vollständige, funktionierende Client-Implementierungen für alle in diesem Tutorial behandelten Programmiersprachen bereitgestellt. Diese Beispiele demonstrieren die volle Funktionalität, die oben beschrieben wurde, und können als Referenzimplementierungen oder Ausgangspunkte für Ihre eigenen Projekte verwendet werden.

### Verfügbare vollständige Beispiele

| Sprache | Datei | Beschreibung |
|---------|-------|--------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Vollständiger Java-Client mit SSE-Transport und umfassender Fehlerbehandlung |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Vollständiger C#-Client mit stdio-Transport und automatischem Serverstart |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Vollständiger TypeScript-Client mit vollständiger MCP-Protokollunterstützung |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Vollständiger Python-Client mit async/await-Mustern |

Jedes vollständige Beispiel enthält:

- ✅ **Verbindungsaufbau** und Fehlerbehandlung
- ✅ **Servererkennung** (Tools, Ressourcen, Eingabeaufforderungen, wo zutreffend)
- ✅ **Rechneroperationen** (Addieren, Subtrahieren, Multiplizieren, Dividieren, Hilfe)
- ✅ **Ergebnisverarbeitung** und formatierte Ausgabe
- ✅ **Umfassende Fehlerbehandlung**
- ✅ **Sauberer, dokumentierter Code** mit Schritt-für-Schritt-Kommentaren

### Erste Schritte mit vollständigen Beispielen

1. **Wählen Sie Ihre bevorzugte Sprache** aus der obigen Tabelle.
2. **Überprüfen Sie die vollständige Beispieldatei**, um die vollständige Implementierung zu verstehen.
3. **Führen Sie das Beispiel aus**, indem Sie den Anweisungen in [`complete_examples.md`](./complete_examples.md) folgen.
4. **Modifizieren und erweitern** Sie das Beispiel für Ihren spezifischen Anwendungsfall.

Für detaillierte Dokumentation über das Ausführen und Anpassen dieser Beispiele siehe: **[📖 Dokumentation zu vollständigen Beispielen](./complete_examples.md)**

### 💡 Lösung vs. vollständige Beispiele

| **Lösungsordner** | **Vollständige Beispiele** |
|--------------------|---------------------------|
| Vollständige Projektstruktur mit Build-Dateien | Einzeldatei-Implementierungen |
| Einsatzbereit mit Abhängigkeiten | Fokus auf Code-Beispiele |
| Produktionsähnliche Einrichtung | Pädagogische Referenz |
| Sprachspezifische Tools | Sprachübergreifender Vergleich |
Beide Ansätze sind wertvoll – verwenden Sie den **Lösungsordner** für vollständige Projekte und die **kompletten Beispiele** zum Lernen und als Referenz.

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse für dieses Kapitel über Clients sind folgende:

- Können sowohl zur Entdeckung als auch zur Nutzung von Funktionen auf dem Server verwendet werden.
- Können einen Server starten, während sie selbst starten (wie in diesem Kapitel), aber Clients können sich auch mit laufenden Servern verbinden.
- Sind eine großartige Möglichkeit, Serverfähigkeiten zu testen, neben Alternativen wie dem Inspector, wie im vorherigen Kapitel beschrieben.

## Zusätzliche Ressourcen

- [Clients in MCP erstellen](https://modelcontextprotocol.io/quickstart/client)

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Was kommt als Nächstes?

- Weiter: [Einen Client mit einem LLM erstellen](../03-llm-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die sich aus der Nutzung dieser Übersetzung ergeben.