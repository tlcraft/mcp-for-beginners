<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T06:45:27+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "no"
}
-->
# SSE Server

SSE (Server Sent Events) er en standard for server-til-klient streaming, som lar servere sende sanntidsoppdateringer til klienter over HTTP. Dette er spesielt nyttig for applikasjoner som krever live oppdateringer, som chat-applikasjoner, varsler eller sanntidsdata. I tillegg kan serveren din brukes av flere klienter samtidig, siden den kjører på en server som for eksempel kan være i skyen.

## Oversikt

Denne leksjonen dekker hvordan man bygger og bruker SSE-servere.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Bygge en SSE-server.
- Feilsøke en SSE-server ved hjelp av Inspector.
- Bruke en SSE-server med Visual Studio Code.

## SSE, hvordan det fungerer

SSE er en av to støttede transporttyper. Du har allerede sett den første, stdio, brukt i tidligere leksjoner. Forskjellen er følgende:

- SSE krever at du håndterer to ting; tilkobling og meldinger.
- Siden dette er en server som kan kjøre hvor som helst, må det gjenspeiles i hvordan du jobber med verktøy som Inspector og Visual Studio Code. Det betyr at i stedet for å peke på hvordan du starter serveren, peker du i stedet på endepunktet hvor tilkoblingen kan etableres. Se eksempel under:

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

I koden over:

- `/sse` er satt opp som en rute. Når en forespørsel sendes til denne ruten, opprettes en ny transportinstans og serveren *kobler til* ved hjelp av denne transporten.
- `/messages` er ruten som håndterer innkommende meldinger.

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

I koden over:

- Oppretter vi en instans av en ASGI-server (spesifikt med Starlette) og monterer standardruten `/`.

  Det som skjer i bakgrunnen er at rutene `/sse` og `/messages` settes opp for å håndtere tilkoblinger og meldinger henholdsvis. Resten av appen, som å legge til funksjoner som verktøy, skjer på samme måte som med stdio-servere.

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

    Det finnes to metoder som hjelper oss å gå fra en webserver til en webserver som støtter SSE, og det er:

    - `AddMcpServer`, denne metoden legger til funksjonalitet.
    - `MapMcp`, denne legger til ruter som `/SSE` og `/messages`.

Nå som vi vet litt mer om SSE, la oss bygge en SSE-server.

## Øvelse: Lage en SSE-server

For å lage serveren må vi ha to ting i tankene:

- Vi må bruke en webserver for å eksponere endepunkter for tilkobling og meldinger.
- Bygge serveren som vi vanligvis gjør med verktøy, ressurser og prompts slik vi gjorde med stdio.

### -1- Opprett en serverinstans

For å lage serveren bruker vi de samme typene som med stdio. Men for transporten må vi velge SSE.

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

I koden over har vi:

- Opprettet en serverinstans.
- Definert en app ved hjelp av web-rammeverket express.
- Opprettet en variabel `transports` som vi bruker til å lagre innkommende tilkoblinger.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

I koden over har vi:

- Importert bibliotekene vi trenger, med Starlette (et ASGI-rammeverk) inkludert.
- Opprettet en MCP-serverinstans `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

På dette tidspunktet har vi:

- Opprettet en webapp.
- Lagt til støtte for MCP-funksjoner gjennom `AddMcpServer`.

La oss legge til nødvendige ruter.

### -2- Legg til ruter

Nå legger vi til ruter som håndterer tilkobling og innkommende meldinger:

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

I koden over har vi definert:

- En `/sse`-rute som oppretter en transport av typen SSE og til slutt kaller `connect` på MCP-serveren.
- En `/messages`-rute som tar seg av innkommende meldinger.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

I koden over har vi:

- Opprettet en ASGI-app-instans ved hjelp av Starlette-rammeverket. Som en del av dette sender vi `mcp.sse_app()` til listen over ruter. Dette monterer `/sse` og `/messages`-ruter på app-instansen.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Vi har lagt til én linje kode til slutt `add.MapMcp()`, som betyr at vi nå har rutene `/SSE` og `/messages`.

La oss legge til funksjonalitet til serveren.

### -3- Legge til serverfunksjoner

Nå som vi har definert alt som er spesifikt for SSE, la oss legge til serverfunksjoner som verktøy, prompts og ressurser.

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

Slik kan du for eksempel legge til et verktøy. Dette spesifikke verktøyet lager et verktøy kalt "random-joke" som kaller en Chuck Norris API og returnerer et JSON-svar.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Nå har serveren din ett verktøy.

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

1. La oss først lage noen verktøy, til dette lager vi en fil *Tools.cs* med følgende innhold:

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

  Her har vi lagt til følgende:

  - Opprettet en klasse `Tools` med dekoratøren `McpServerToolType`.
  - Definert et verktøy `AddNumbers` ved å dekorere metoden med `McpServerTool`. Vi har også gitt parametere og implementasjon.

1. La oss bruke `Tools`-klassen vi nettopp laget:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Vi har lagt til et kall til `WithTools` som spesifiserer `Tools` som klassen som inneholder verktøyene. Det er alt, vi er klare.

Flott, vi har en server som bruker SSE, la oss prøve den ut.

## Øvelse: Feilsøke en SSE-server med Inspector

Inspector er et flott verktøy som vi så i en tidligere leksjon [Creating your first server](/03-GettingStarted/01-first-server/README.md). La oss se om vi kan bruke Inspector her også:

### -1- Kjøre inspector

For å kjøre inspector må du først ha en SSE-server som kjører, så la oss gjøre det:

1. Start serveren

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Legg merke til at vi bruker kjørbar fil `uvicorn` som installeres når vi skriver `pip install "mcp[cli]"`. Å skrive `server:app` betyr at vi prøver å kjøre filen `server.py` og at den har en Starlette-instans kalt `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Dette skal starte serveren. For å kommunisere med den trenger du et nytt terminalvindu.

1. Kjør inspector

    > ![NOTE]
    > Kjør dette i et eget terminalvindu enn der serveren kjører. Merk også at du må tilpasse kommandoen under til URL-en der serveren din kjører.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Å kjøre inspector ser likt ut i alle runtime-miljøer. Legg merke til at i stedet for å sende en sti til serveren og en kommando for å starte serveren, sender vi URL-en der serveren kjører, og vi spesifiserer også `/sse`-ruten.

### -2- Prøve ut verktøyet

Koble til serveren ved å velge SSE i nedtrekksmenyen og fyll inn URL-feltet der serveren kjører, for eksempel http:localhost:4321/sse. Klikk deretter på "Connect"-knappen. Som før, velg å liste opp verktøy, velg et verktøy og gi inputverdier. Du bør se et resultat som under:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.no.png)

Flott, du kan jobbe med inspector, la oss se hvordan vi kan jobbe med Visual Studio Code.

## Oppgave

Prøv å bygge ut serveren din med flere funksjoner. Se [denne siden](https://api.chucknorris.io/) for eksempelvis å legge til et verktøy som kaller en API. Du bestemmer hvordan serveren skal se ut. Lykke til :)

## Løsning

[Løsning](./solution/README.md) Her er en mulig løsning med fungerende kode.

## Viktige punkter

De viktigste punktene fra dette kapitlet er:

- SSE er den andre støttede transporttypen ved siden av stdio.
- For å støtte SSE må du håndtere innkommende tilkoblinger og meldinger ved hjelp av et web-rammeverk.
- Du kan bruke både Inspector og Visual Studio Code for å bruke en SSE-server, akkurat som med stdio-servere. Merk at det er noen forskjeller mellom stdio og SSE. For SSE må du starte serveren separat og deretter kjøre inspector-verktøyet. For inspector-verktøyet må du også spesifisere URL-en.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Ekstra ressurser

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Hva skjer videre

- Neste: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.