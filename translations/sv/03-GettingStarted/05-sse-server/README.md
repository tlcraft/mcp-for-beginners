<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T06:19:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sv"
}
-->
# SSE Server

SSE (Server Sent Events) är en standard för server-till-klient streaming, som gör det möjligt för servrar att skicka realtidsuppdateringar till klienter över HTTP. Detta är särskilt användbart för applikationer som kräver liveuppdateringar, som chattapplikationer, notifikationer eller realtidsdataflöden. Dessutom kan din server användas av flera klienter samtidigt eftersom den körs på en server som till exempel kan ligga i molnet.

## Översikt

Den här lektionen handlar om hur man bygger och använder SSE-servrar.

## Lärandemål

I slutet av denna lektion kommer du att kunna:

- Bygga en SSE-server.
- Felsöka en SSE-server med hjälp av Inspector.
- Använda en SSE-server med Visual Studio Code.

## SSE, hur det fungerar

SSE är en av två stödda transporttyper. Du har redan sett den första, stdio, användas i tidigare lektioner. Skillnaden är följande:

- SSE kräver att du hanterar två saker; anslutning och meddelanden.
- Eftersom detta är en server som kan finnas var som helst, behöver du att det speglas i hur du arbetar med verktyg som Inspector och Visual Studio Code. Det innebär att istället för att peka ut hur man startar servern, pekar du istället på den endpoint där anslutningen kan etableras. Se exempel nedan:

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

I koden ovan:

- `/sse` är satt som en route. När en förfrågan görs mot denna route skapas en ny transportinstans och servern *ansluter* med denna transport.
- `/messages` är routen som hanterar inkommande meddelanden.

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

I koden ovan:

- Skapar vi en instans av en ASGI-server (specifikt med Starlette) och monterar standardrouten `/`.

  Vad som händer bakom kulisserna är att routarna `/sse` och `/messages` sätts upp för att hantera anslutningar respektive meddelanden. Resten av appen, som att lägga till funktioner som verktyg, sker som med stdio-servrar.

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

    Det finns två metoder som hjälper oss att gå från en webbserver till en webbserver som stödjer SSE, och det är:

    - `AddMcpServer`, denna metod lägger till funktionalitet.
    - `MapMcp`, detta lägger till routes som `/SSE` och `/messages`.

Nu när vi vet lite mer om SSE, låt oss bygga en SSE-server.

## Övning: Skapa en SSE-server

För att skapa vår server behöver vi ha två saker i åtanke:

- Vi behöver använda en webbserver för att exponera endpoints för anslutning och meddelanden.
- Bygga vår server som vi normalt gör med verktyg, resurser och prompts när vi använde stdio.

### -1- Skapa en serverinstans

För att skapa vår server använder vi samma typer som med stdio. Men för transporten behöver vi välja SSE.

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

I koden ovan har vi:

- Skapat en serverinstans.
- Definierat en app med webbframeworket express.
- Skapat en variabel transports som vi kommer använda för att lagra inkommande anslutningar.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

I koden ovan har vi:

- Importerat de bibliotek vi behöver, där Starlette (ett ASGI-framework) inkluderas.
- Skapat en MCP-serverinstans `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Vid detta tillfälle har vi:

- Skapat en webbapp.
- Lagt till stöd för MCP-funktioner via `AddMcpServer`.

Låt oss lägga till de nödvändiga routarna nästa steg.

### -2- Lägg till routes

Nu lägger vi till routes som hanterar anslutning och inkommande meddelanden:

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

I koden ovan har vi definierat:

- En `/sse` route som instansierar en transport av typen SSE och som i slutändan anropar `connect` på MCP-servern.
- En `/messages` route som tar hand om inkommande meddelanden.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

I koden ovan har vi:

- Skapat en ASGI-appinstans med Starlette-frameworket. Som en del av detta skickar vi `mcp.sse_app()` till dess lista av routes. Det resulterar i att `/sse` och `/messages` routes monteras på appinstansen.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Vi har lagt till en rad kod i slutet `add.MapMcp()`, vilket betyder att vi nu har routes `/SSE` och `/messages`.

Låt oss lägga till funktionalitet till servern nästa steg.

### -3- Lägg till serverfunktioner

Nu när vi har allt SSE-specifikt definierat, låt oss lägga till serverfunktioner som verktyg, prompts och resurser.

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

Så här kan du till exempel lägga till ett verktyg. Detta specifika verktyg skapar ett verktyg som heter "random-joke" som anropar en Chuck Norris API och returnerar ett JSON-svar.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Nu har din server ett verktyg.

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

1. Låt oss först skapa några verktyg, för detta skapar vi en fil *Tools.cs* med följande innehåll:

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

  Här har vi lagt till följande:

  - Skapat en klass `Tools` med dekoratorn `McpServerToolType`.
  - Definierat ett verktyg `AddNumbers` genom att dekorera metoden med `McpServerTool`. Vi har också angett parametrar och en implementation.

1. Låt oss använda `Tools`-klassen vi just skapade:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Vi har lagt till ett anrop till `WithTools` som specificerar `Tools` som klassen som innehåller verktygen. Det är allt, vi är redo.

Bra, vi har en server som använder SSE, låt oss testa den.

## Övning: Felsöka en SSE-server med Inspector

Inspector är ett utmärkt verktyg som vi såg i en tidigare lektion [Creating your first server](/03-GettingStarted/01-first-server/README.md). Låt oss se om vi kan använda Inspector även här:

### -1- Starta inspector

För att köra inspector måste du först ha en SSE-server igång, så låt oss göra det:

1. Starta servern

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Notera hur vi använder exekverbara `uvicorn` som installeras när vi skrev `pip install "mcp[cli]"`. Att skriva `server:app` betyder att vi försöker köra filen `server.py` och att den har en Starlette-instans som heter `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Detta bör starta servern. För att interagera med den behöver du ett nytt terminalfönster.

1. Starta inspector

    > ![NOTE]
    > Kör detta i ett separat terminalfönster från där servern körs. Observera också att du behöver anpassa kommandot nedan för att passa URL:en där din server körs.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Att köra inspector ser likadant ut i alla miljöer. Notera hur vi istället för att skicka en sökväg till vår server och ett kommando för att starta servern, skickar URL:en där servern körs och specificerar `/sse` routen.

### -2- Testa verktyget

Anslut till servern genom att välja SSE i dropdown-menyn och fyll i URL-fältet där din server körs, till exempel http:localhost:4321/sse. Klicka sedan på "Connect"-knappen. Som tidigare, välj att lista verktyg, välj ett verktyg och ange indata. Du bör se ett resultat som nedan:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sv.png)

Bra, du kan arbeta med inspector, låt oss se hur vi kan arbeta med Visual Studio Code nästa.

## Uppgift

Försök bygga ut din server med fler funktioner. Se [den här sidan](https://api.chucknorris.io/) för att till exempel lägga till ett verktyg som anropar en API. Du bestämmer hur servern ska se ut. Ha kul :)

## Lösning

[Lösning](./solution/README.md) Här är en möjlig lösning med fungerande kod.

## Viktiga punkter

De viktigaste punkterna från detta kapitel är:

- SSE är den andra stödda transporten efter stdio.
- För att stödja SSE behöver du hantera inkommande anslutningar och meddelanden med hjälp av ett webbframework.
- Du kan använda både Inspector och Visual Studio Code för att konsumera en SSE-server, precis som med stdio-servrar. Notera att det skiljer sig lite mellan stdio och SSE. För SSE behöver du starta servern separat och sedan köra ditt inspector-verktyg. För inspector-verktyget finns också skillnader i att du behöver specificera URL:en.

## Exempel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ytterligare resurser

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Vad händer härnäst

- Nästa: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.