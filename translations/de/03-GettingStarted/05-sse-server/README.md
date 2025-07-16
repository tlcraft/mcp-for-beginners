<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T22:18:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "de"
}
-->
# SSE Server

SSE (Server Sent Events) ist ein Standard für serverseitiges Streaming zum Client, der es Servern ermöglicht, Echtzeit-Updates über HTTP an Clients zu senden. Das ist besonders nützlich für Anwendungen, die Live-Updates benötigen, wie Chat-Anwendungen, Benachrichtigungen oder Echtzeit-Datenfeeds. Außerdem kann dein Server von mehreren Clients gleichzeitig genutzt werden, da er auf einem Server läuft, der zum Beispiel in der Cloud betrieben werden kann.

## Überblick

Diese Lektion behandelt, wie man SSE-Server erstellt und nutzt.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Einen SSE-Server zu erstellen.
- Einen SSE-Server mit dem Inspector zu debuggen.
- Einen SSE-Server mit Visual Studio Code zu nutzen.

## SSE, wie es funktioniert

SSE ist einer von zwei unterstützten Transporttypen. Den ersten, stdio, hast du bereits in vorherigen Lektionen gesehen. Der Unterschied ist folgender:

- SSE erfordert, dass du zwei Dinge verwaltest: Verbindung und Nachrichten.
- Da dieser Server überall laufen kann, muss sich das auch in der Arbeit mit Tools wie dem Inspector und Visual Studio Code widerspiegeln. Das bedeutet, dass du nicht angibst, wie der Server gestartet wird, sondern stattdessen auf den Endpunkt verweist, an dem die Verbindung hergestellt wird. Siehe Beispielcode unten:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

Im obigen Code:

- `/sse` ist als Route eingerichtet. Wenn eine Anfrage an diese Route gestellt wird, wird eine neue Transport-Instanz erstellt und der Server *verbindet* sich über diesen Transport.
- `/messages` ist die Route, die eingehende Nachrichten verarbeitet.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

Im obigen Code:

- Erstellen wir eine Instanz eines ASGI-Servers (speziell mit Starlette) und mounten die Standardroute `/`.

  Im Hintergrund werden die Routen `/sse` und `/messages` eingerichtet, um Verbindungen bzw. Nachrichten zu handhaben. Der Rest der App, wie das Hinzufügen von Features wie Tools, funktioniert wie bei stdio-Servern.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Es gibt zwei Methoden, die uns helfen, von einem Webserver zu einem Webserver mit SSE-Unterstützung zu kommen:

    - `AddMcpServer`, diese Methode fügt die nötigen Fähigkeiten hinzu.
    - `MapMcp`, diese fügt Routen wie `/SSE` und `/messages` hinzu.

Jetzt, wo wir etwas mehr über SSE wissen, bauen wir als Nächstes einen SSE-Server.

## Übung: Einen SSE-Server erstellen

Um unseren Server zu erstellen, müssen wir zwei Dinge beachten:

- Wir brauchen einen Webserver, der Endpunkte für Verbindung und Nachrichten bereitstellt.
- Wir bauen unseren Server wie gewohnt mit Tools, Ressourcen und Prompts, wie wir es bei stdio gemacht haben.

### -1- Erstellen einer Server-Instanz

Für unseren Server verwenden wir dieselben Typen wie bei stdio. Für den Transport wählen wir jedoch SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

Im obigen Code haben wir:

- Eine Server-Instanz erstellt.
- Eine App mit dem Webframework express definiert.
- Eine Variable `transports` erstellt, in der wir eingehende Verbindungen speichern.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Im obigen Code haben wir:

- Die benötigten Bibliotheken importiert, darunter Starlette (ein ASGI-Framework).
- Eine MCP-Server-Instanz `mcp` erstellt.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

An diesem Punkt haben wir:

- Eine Web-App erstellt.
- Unterstützung für MCP-Funktionen über `AddMcpServer` hinzugefügt.

Als Nächstes fügen wir die benötigten Routen hinzu.

### -2- Routen hinzufügen

Fügen wir nun Routen hinzu, die die Verbindung und eingehende Nachrichten verwalten:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

Im obigen Code haben wir definiert:

- Eine `/sse`-Route, die einen Transport vom Typ SSE instanziiert und schließlich `connect` auf dem MCP-Server aufruft.
- Eine `/messages`-Route, die sich um eingehende Nachrichten kümmert.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Im obigen Code haben wir:

- Eine ASGI-App-Instanz mit dem Starlette-Framework erstellt. Dabei übergeben wir `mcp.sse_app()` an die Liste der Routen. Das mountet die Routen `/sse` und `/messages` auf der App-Instanz.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Wir haben am Ende eine Zeile `add.MapMcp()` hinzugefügt, was bedeutet, dass wir jetzt die Routen `/SSE` und `/messages` haben.

Als Nächstes fügen wir dem Server Fähigkeiten hinzu.

### -3- Server-Fähigkeiten hinzufügen

Jetzt, wo wir alles SSE-spezifische definiert haben, fügen wir dem Server Fähigkeiten wie Tools, Prompts und Ressourcen hinzu.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

So kannst du zum Beispiel ein Tool hinzufügen. Dieses spezielle Tool erstellt ein Tool namens "random-joke", das eine Chuck Norris API aufruft und eine JSON-Antwort zurückgibt.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Jetzt hat dein Server ein Tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Erstellen wir zuerst einige Tools, dafür legen wir eine Datei *Tools.cs* mit folgendem Inhalt an:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Hier haben wir Folgendes hinzugefügt:

  - Eine Klasse `Tools` mit dem Dekorator `McpServerToolType` erstellt.
  - Ein Tool `AddNumbers` definiert, indem die Methode mit `McpServerTool` dekoriert wurde. Wir haben auch Parameter und eine Implementierung bereitgestellt.

1. Nutzen wir die gerade erstellte `Tools`-Klasse:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Wir haben einen Aufruf zu `WithTools` hinzugefügt, der `Tools` als Klasse mit den Tools angibt. Das war's, wir sind startklar.

Super, wir haben einen Server mit SSE, probieren wir ihn als Nächstes aus.

## Übung: Einen SSE-Server mit Inspector debuggen

Inspector ist ein großartiges Tool, das wir in einer vorherigen Lektion [Creating your first server](/03-GettingStarted/01-first-server/README.md) kennengelernt haben. Schauen wir, ob wir den Inspector auch hier nutzen können:

### -1- Inspector starten

Um den Inspector zu starten, muss zuerst ein SSE-Server laufen, also machen wir das jetzt:

1. Starte den Server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Beachte, dass wir das ausführbare Programm `uvicorn` verwenden, das installiert wird, wenn wir `pip install "mcp[cli]"` eingeben. `server:app` bedeutet, dass wir versuchen, eine Datei `server.py` auszuführen, die eine Starlette-Instanz namens `app` enthält.

    ### .NET

    ```sh
    dotnet run
    ```

    Das sollte den Server starten. Um mit ihm zu interagieren, brauchst du ein neues Terminal.

1. Starte den Inspector

    > ![NOTE]
    > Führe das in einem separaten Terminalfenster aus, als in dem der Server läuft. Beachte außerdem, dass du den untenstehenden Befehl an die URL anpassen musst, unter der dein Server läuft.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Das Starten des Inspectors sieht in allen Laufzeitumgebungen gleich aus. Beachte, dass wir statt eines Pfads zum Server und eines Befehls zum Starten des Servers die URL übergeben, unter der der Server läuft, und außerdem die Route `/sse` angeben.

### -2- Tool ausprobieren

Verbinde den Server, indem du in der Auswahlliste SSE auswählst und das URL-Feld mit der Adresse füllst, unter der dein Server läuft, z.B. http:localhost:4321/sse. Klicke dann auf den Button „Connect“. Wie zuvor kannst du Tools auflisten, ein Tool auswählen und Eingabewerte angeben. Du solltest ein Ergebnis wie unten sehen:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.de.png)

Super, du kannst mit dem Inspector arbeiten, schauen wir uns als Nächstes an, wie du mit Visual Studio Code arbeiten kannst.

## Aufgabe

Versuche, deinen Server mit weiteren Fähigkeiten auszubauen. Sieh dir [diese Seite](https://api.chucknorris.io/) an, um zum Beispiel ein Tool hinzuzufügen, das eine API aufruft. Du entscheidest, wie dein Server aussehen soll. Viel Spaß :)

## Lösung

[Lösung](./solution/README.md) Hier findest du eine mögliche Lösung mit funktionierendem Code.

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse aus diesem Kapitel sind:

- SSE ist der zweite unterstützte Transport neben stdio.
- Um SSE zu unterstützen, musst du eingehende Verbindungen und Nachrichten mit einem Webframework verwalten.
- Du kannst sowohl Inspector als auch Visual Studio Code nutzen, um einen SSE-Server zu verwenden, genau wie bei stdio-Servern. Beachte, dass es kleine Unterschiede zwischen stdio und SSE gibt. Bei SSE musst du den Server separat starten und dann dein Inspector-Tool ausführen. Für den Inspector gibt es außerdem Unterschiede, da du die URL angeben musst.

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Was kommt als Nächstes

- Nächstes Thema: [HTTP Streaming mit MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.