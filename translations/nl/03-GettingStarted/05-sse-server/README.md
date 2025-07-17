<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T07:14:54+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "nl"
}
-->
# SSE Server

SSE (Server Sent Events) is een standaard voor server-naar-client streaming, waarmee servers real-time updates naar clients kunnen pushen via HTTP. Dit is vooral handig voor applicaties die live updates nodig hebben, zoals chatapplicaties, notificaties of real-time datafeeds. Bovendien kan je server door meerdere clients tegelijk worden gebruikt, omdat deze op een server draait die bijvoorbeeld ergens in de cloud kan staan.

## Overzicht

Deze les behandelt hoe je SSE-servers bouwt en gebruikt.

## Leerdoelen

Aan het einde van deze les kun je:

- Een SSE-server bouwen.
- Een SSE-server debuggen met de Inspector.
- Een SSE-server gebruiken met Visual Studio Code.

## SSE, hoe het werkt

SSE is een van de twee ondersteunde transporttypes. Je hebt het eerste type, stdio, al gezien in eerdere lessen. Het verschil is het volgende:

- SSE vereist dat je twee dingen afhandelt: verbindingen en berichten.
- Omdat dit een server is die overal kan draaien, moet je dat ook meenemen in hoe je werkt met tools zoals de Inspector en Visual Studio Code. Dit betekent dat je in plaats van aan te geven hoe je de server start, je wijst naar het eindpunt waar de verbinding tot stand kan worden gebracht. Zie het onderstaande voorbeeld:

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

In bovenstaande code:

- `/sse` is ingesteld als route. Wanneer er een verzoek naar deze route wordt gedaan, wordt een nieuwe transportinstantie aangemaakt en maakt de server *verbinding* via dit transport.
- `/messages` is de route die binnenkomende berichten afhandelt.

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

In bovenstaande code:

- Maken we een instantie van een ASGI-server (specifiek met Starlette) en mounten we de standaardroute `/`.

  Wat er achter de schermen gebeurt, is dat de routes `/sse` en `/messages` worden ingesteld om respectievelijk verbindingen en berichten af te handelen. De rest van de app, zoals het toevoegen van functies zoals tools, werkt zoals bij stdio-servers.

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

    Er zijn twee methoden die ons helpen van een webserver naar een webserver met SSE-ondersteuning te gaan, namelijk:

    - `AddMcpServer`, deze methode voegt functionaliteiten toe.
    - `MapMcp`, deze voegt routes toe zoals `/SSE` en `/messages`.

Nu we iets meer weten over SSE, laten we een SSE-server bouwen.

## Oefening: Een SSE-server maken

Om onze server te maken, moeten we twee dingen in gedachten houden:

- We moeten een webserver gebruiken om eindpunten voor verbinding en berichten bloot te stellen.
- We bouwen onze server zoals we normaal doen met tools, resources en prompts, zoals we deden bij stdio.

### -1- Maak een serverinstantie aan

Om onze server te maken, gebruiken we dezelfde types als bij stdio. Voor het transport kiezen we echter SSE.

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

In bovenstaande code hebben we:

- Een serverinstantie aangemaakt.
- Een app gedefinieerd met het webframework express.
- Een transports-variabele gemaakt om binnenkomende verbindingen op te slaan.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In bovenstaande code hebben we:

- De benodigde libraries geïmporteerd, waaronder Starlette (een ASGI-framework).
- Een MCP-serverinstantie `mcp` aangemaakt.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Op dit punt hebben we:

- Een webapp gemaakt.
- Ondersteuning voor MCP-functies toegevoegd via `AddMcpServer`.

Laten we nu de benodigde routes toevoegen.

### -2- Routes toevoegen

Laten we routes toevoegen die de verbinding en binnenkomende berichten afhandelen:

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

In bovenstaande code hebben we:

- Een `/sse` route gedefinieerd die een transport van het type SSE aanmaakt en uiteindelijk `connect` aanroept op de MCP-server.
- Een `/messages` route die binnenkomende berichten afhandelt.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In bovenstaande code hebben we:

- Een ASGI-app instantie gemaakt met het Starlette-framework. Daarbij geven we `mcp.sse_app()` mee aan de lijst met routes. Dit mount uiteindelijk een `/sse` en `/messages` route op de app-instantie.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We hebben één regel code toegevoegd aan het einde: `add.MapMcp()`. Dit betekent dat we nu de routes `/SSE` en `/messages` hebben.

Laten we nu functionaliteiten aan de server toevoegen.

### -3- Serverfunctionaliteiten toevoegen

Nu we alles SSE-specifiek hebben gedefinieerd, voegen we serverfunctionaliteiten toe zoals tools, prompts en resources.

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

Hier zie je hoe je bijvoorbeeld een tool kunt toevoegen. Deze specifieke tool maakt een tool genaamd "random-joke" die een Chuck Norris API aanroept en een JSON-response teruggeeft.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Je server heeft nu één tool.

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

1. Laten we eerst wat tools maken, hiervoor maken we een bestand *Tools.cs* met de volgende inhoud:

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

  Hier hebben we het volgende toegevoegd:

  - Een klasse `Tools` gemaakt met de decorator `McpServerToolType`.
  - Een tool `AddNumbers` gedefinieerd door de methode te decoreren met `McpServerTool`. We hebben ook parameters en een implementatie toegevoegd.

1. Laten we de zojuist gemaakte `Tools` klasse gebruiken:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We hebben een aanroep toegevoegd aan `WithTools` die `Tools` specificeert als de klasse met de tools. Dat is alles, we zijn klaar.

Geweldig, we hebben een server die SSE gebruikt, laten we deze nu uitproberen.

## Oefening: Een SSE-server debuggen met Inspector

Inspector is een geweldige tool die we in een eerdere les [Je eerste server maken](/03-GettingStarted/01-first-server/README.md) hebben gezien. Laten we kijken of we de Inspector ook hier kunnen gebruiken:

### -1- De inspector starten

Om de inspector te starten, moet je eerst een SSE-server draaien, dus laten we dat doen:

1. Start de server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Let op dat we de executable `uvicorn` gebruiken die wordt geïnstalleerd wanneer we `pip install "mcp[cli]"` typen. `server:app` betekent dat we proberen een bestand `server.py` te draaien met een Starlette-instantie genaamd `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Dit zou de server moeten starten. Om ermee te communiceren heb je een nieuw terminalvenster nodig.

1. Start de inspector

    > ![NOTE]
    > Voer dit uit in een apart terminalvenster dan waar de server draait. Let ook op dat je het onderstaande commando moet aanpassen aan de URL waar jouw server draait.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Het starten van de inspector ziet er in alle runtimes hetzelfde uit. Let op dat we in plaats van een pad naar onze server en een commando om de server te starten, nu de URL doorgeven waar de server draait en ook de `/sse` route specificeren.

### -2- De tool uitproberen

Verbind met de server door in de keuzelijst SSE te selecteren en vul het url-veld in waar je server draait, bijvoorbeeld http:localhost:4321/sse. Klik nu op de knop "Connect". Selecteer zoals eerder een tool, geef invoerwaarden op en je zou een resultaat moeten zien zoals hieronder:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.nl.png)

Geweldig, je kunt met de inspector werken, laten we nu kijken hoe je met Visual Studio Code kunt werken.

## Opdracht

Probeer je server uit te breiden met meer functionaliteiten. Bekijk [deze pagina](https://api.chucknorris.io/) om bijvoorbeeld een tool toe te voegen die een API aanroept. Jij bepaalt hoe de server eruit komt te zien. Veel plezier :)

## Oplossing

[Oplossing](./solution/README.md) Hier is een mogelijke oplossing met werkende code.

## Belangrijkste punten

De belangrijkste punten uit dit hoofdstuk zijn:

- SSE is het tweede ondersteunde transport naast stdio.
- Om SSE te ondersteunen, moet je binnenkomende verbindingen en berichten beheren met een webframework.
- Je kunt zowel Inspector als Visual Studio Code gebruiken om een SSE-server te gebruiken, net als bij stdio-servers. Let op dat het iets anders werkt dan bij stdio. Voor SSE moet je de server apart opstarten en daarna de inspector-tool draaien. Voor de inspector-tool moet je ook de URL specificeren.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Extra bronnen

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Wat volgt

- Volgende: [HTTP Streaming met MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.