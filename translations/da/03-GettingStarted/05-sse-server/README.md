<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T06:32:23+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "da"
}
-->
# SSE Server

SSE (Server Sent Events) er en standard for server-til-klient streaming, som gør det muligt for servere at sende realtidsopdateringer til klienter over HTTP. Det er især nyttigt for applikationer, der kræver live-opdateringer, såsom chatapplikationer, notifikationer eller realtidsdatafeeds. Din server kan også bruges af flere klienter samtidig, da den kører på en server, som for eksempel kan være placeret i skyen.

## Oversigt

Denne lektion handler om, hvordan man bygger og bruger SSE-servere.

## Læringsmål

Når du er færdig med denne lektion, vil du kunne:

- Bygge en SSE-server.
- Fejlsøge en SSE-server ved hjælp af Inspector.
- Bruge en SSE-server i Visual Studio Code.

## SSE, hvordan det fungerer

SSE er en af to understøttede transporttyper. Du har allerede set den første, stdio, blive brugt i tidligere lektioner. Forskellen er følgende:

- SSE kræver, at du håndterer to ting; forbindelsen og beskederne.
- Da dette er en server, der kan køre hvor som helst, skal det afspejles i, hvordan du arbejder med værktøjer som Inspector og Visual Studio Code. Det betyder, at i stedet for at angive, hvordan man starter serveren, peger du i stedet på det endpoint, hvor forbindelsen kan etableres. Se eksempel nedenfor:

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

I koden ovenfor:

- `/sse` er sat op som en rute. Når der laves en forespørgsel til denne rute, oprettes en ny transportinstans, og serveren *opretter forbindelse* ved hjælp af denne transport.
- `/messages` er ruten, der håndterer indkommende beskeder.

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

I koden ovenfor:

- Opretter vi en instans af en ASGI-server (specifikt med Starlette) og monterer standardruten `/`.

  Bag kulisserne bliver rutene `/sse` og `/messages` sat op til at håndtere henholdsvis forbindelser og beskeder. Resten af appen, som at tilføje funktioner som værktøjer, foregår som med stdio-servere.

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

Der er to metoder, der hjælper os med at gå fra en webserver til en webserver, der understøtter SSE, og det er:

- `AddMcpServer`, denne metode tilføjer funktionalitet.
- `MapMcp`, denne tilføjer ruter som `/SSE` og `/messages`.

Nu hvor vi ved lidt mere om SSE, lad os bygge en SSE-server.

## Øvelse: Oprette en SSE-server

For at oprette vores server skal vi huske to ting:

- Vi skal bruge en webserver til at eksponere endpoints for forbindelse og beskeder.
- Bygge vores server som vi normalt gør med værktøjer, ressourcer og prompts, som vi gjorde med stdio.

### -1- Opret en serverinstans

For at oprette vores server bruger vi de samme typer som med stdio. Men til transporten skal vi vælge SSE.

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

I koden ovenfor har vi:

- Oprettet en serverinstans.
- Defineret en app ved hjælp af webframeworket express.
- Oprettet en variabel transports, som vi bruger til at gemme indkommende forbindelser.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

I koden ovenfor har vi:

- Importeret de biblioteker, vi skal bruge, herunder Starlette (et ASGI-framework).
- Oprettet en MCP-serverinstans `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

På dette tidspunkt har vi:

- Oprettet en webapp.
- Tilføjet understøttelse for MCP-funktioner via `AddMcpServer`.

Lad os tilføje de nødvendige ruter næste.

### -2- Tilføj ruter

Lad os tilføje ruter, der håndterer forbindelsen og indkommende beskeder:

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

I koden ovenfor har vi defineret:

- En `/sse`-rute, der opretter en transport af typen SSE og til sidst kalder `connect` på MCP-serveren.
- En `/messages`-rute, der håndterer indkommende beskeder.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

I koden ovenfor har vi:

- Oprettet en ASGI-appinstans ved hjælp af Starlette-frameworket. Som en del af det sender vi `mcp.sse_app()` til dens liste over ruter. Det resulterer i, at `/sse` og `/messages` ruter monteres på app-instansen.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Vi har tilføjet en linje kode til sidst `add.MapMcp()`, hvilket betyder, at vi nu har ruterne `/SSE` og `/messages`.

Lad os tilføje funktionalitet til serveren næste.

### -3- Tilføj serverfunktioner

Nu hvor vi har defineret alt det, der er specifikt for SSE, lad os tilføje serverfunktioner som værktøjer, prompts og ressourcer.

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

Her kan du se, hvordan du tilføjer et værktøj for eksempel. Dette specifikke værktøj opretter et værktøj kaldet "random-joke", som kalder en Chuck Norris API og returnerer et JSON-svar.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Nu har din server ét værktøj.

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

1. Lad os først oprette nogle værktøjer, til dette opretter vi en fil *Tools.cs* med følgende indhold:

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

  Her har vi tilføjet følgende:

  - Oprettet en klasse `Tools` med dekoratøren `McpServerToolType`.
  - Defineret et værktøj `AddNumbers` ved at dekorere metoden med `McpServerTool`. Vi har også angivet parametre og en implementering.

1. Lad os bruge `Tools`-klassen, vi lige har oprettet:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Vi har tilføjet et kald til `WithTools`, som angiver `Tools` som klassen, der indeholder værktøjerne. Det er det, vi er klar.

Fint, vi har en server, der bruger SSE, lad os prøve den af.

## Øvelse: Fejlsøgning af en SSE-server med Inspector

Inspector er et fantastisk værktøj, som vi så i en tidligere lektion [Creating your first server](/03-GettingStarted/01-first-server/README.md). Lad os se, om vi kan bruge Inspector her også:

### -1- Køre inspector

For at køre inspector skal du først have en SSE-server kørende, så lad os gøre det:

1. Start serveren

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Bemærk, hvordan vi bruger eksekverbaren `uvicorn`, som installeres, når vi skriver `pip install "mcp[cli]"`. At skrive `server:app` betyder, at vi prøver at køre filen `server.py`, som indeholder en Starlette-instans kaldet `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Dette burde starte serveren. For at interagere med den skal du åbne et nyt terminalvindue.

1. Kør inspector

    > ![NOTE]
    > Kør dette i et separat terminalvindue fra det, hvor serveren kører. Bemærk også, at du skal tilpasse kommandoen nedenfor, så den passer til URL’en, hvor din server kører.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    At køre inspector ser ens ud i alle runtime-miljøer. Bemærk, at i stedet for at angive en sti til vores server og en kommando til at starte serveren, angiver vi URL’en, hvor serveren kører, og vi specificerer også `/sse`-ruten.

### -2- Prøv værktøjet

Forbind til serveren ved at vælge SSE i dropdown-menuen og udfyld URL-feltet med adressen, hvor din server kører, for eksempel http:localhost:4321/sse. Klik derefter på "Connect"-knappen. Som før, vælg at liste værktøjer, vælg et værktøj og angiv inputværdier. Du skulle gerne se et resultat som nedenfor:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.da.png)

Fint, du kan arbejde med inspector, lad os se, hvordan vi kan arbejde med Visual Studio Code næste.

## Opgave

Prøv at bygge din server ud med flere funktioner. Se [denne side](https://api.chucknorris.io/) for eksempelvis at tilføje et værktøj, der kalder en API. Du bestemmer, hvordan serveren skal se ud. God fornøjelse :)

## Løsning

[Løsning](./solution/README.md) Her er en mulig løsning med fungerende kode.

## Vigtige pointer

De vigtigste pointer fra dette kapitel er:

- SSE er den anden understøttede transport ved siden af stdio.
- For at understøtte SSE skal du håndtere indkommende forbindelser og beskeder ved hjælp af et webframework.
- Du kan bruge både Inspector og Visual Studio Code til at bruge en SSE-server, ligesom med stdio-servere. Bemærk, at det adskiller sig lidt mellem stdio og SSE. For SSE skal du starte serveren separat og derefter køre dit inspector-værktøj. For inspector-værktøjet er der også forskelle, idet du skal angive URL’en.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Yderligere ressourcer

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Hvad er det næste

- Næste: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.