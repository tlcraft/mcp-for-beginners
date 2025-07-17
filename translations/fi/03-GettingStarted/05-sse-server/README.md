<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T07:00:21+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fi"
}
-->
# SSE-palvelin

SSE (Server Sent Events) on standardi palvelimelta asiakkaalle tapahtuvaan suoratoistoon, joka mahdollistaa palvelimien lähettää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli. Tämä on erityisen hyödyllistä sovelluksissa, jotka tarvitsevat live-päivityksiä, kuten chat-sovellukset, ilmoitukset tai reaaliaikaiset tietovirrat. Lisäksi palvelintasi voi käyttää useampi asiakas samanaikaisesti, koska se toimii palvelimella, joka voi sijaita esimerkiksi pilvessä.

## Yleiskatsaus

Tässä oppitunnissa käydään läpi, miten rakentaa ja käyttää SSE-palvelimia.

## Oppimistavoitteet

Oppitunnin lopussa osaat:

- Rakentaa SSE-palvelimen.
- Debugata SSE-palvelinta Inspectorilla.
- Käyttää SSE-palvelinta Visual Studio Codella.

## SSE, miten se toimii

SSE on yksi kahdesta tuetusta siirtotavasta. Olet jo nähnyt ensimmäisen, stdio:n, käytön aiemmissa oppitunneissa. Erot ovat seuraavat:

- SSE vaatii, että hallitset kahta asiaa: yhteyden ja viestit.
- Koska kyseessä on palvelin, joka voi sijaita missä tahansa, tämä täytyy ottaa huomioon työskennellessäsi työkalujen, kuten Inspectorin ja Visual Studio Coden, kanssa. Tämä tarkoittaa, että sen sijaan, että kerrot miten palvelin käynnistetään, osoitat sen sijainnin, johon yhteys voidaan muodostaa. Katso alla oleva esimerkkikoodi:

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

Edellisessä koodissa:

- `/sse` on määritelty reitiksi. Kun tähän reittiin tehdään pyyntö, luodaan uusi siirto-instanssi ja palvelin *yhdistää* tämän siirron avulla.
- `/messages` on reitti, joka käsittelee saapuvat viestit.

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

Edellisessä koodissa:

- Luodaan ASGI-palvelimen instanssi (käytetään erityisesti Starlettea) ja liitetään oletusreitti `/`.

  Taustalla reitit `/sse` ja `/messages` on määritelty käsittelemään yhteyksiä ja viestejä vastaavasti. Loput sovelluksesta, kuten työkalujen lisääminen, tapahtuu kuten stdio-palvelimissa.

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

    On kaksi metodia, jotka auttavat siirtymään web-palvelimesta SSE:tä tukevaksi web-palvelimeksi:

    - `AddMcpServer`, tämä metodi lisää ominaisuuksia.
    - `MapMcp`, tämä lisää reitit kuten `/SSE` ja `/messages`.

Nyt kun tiedämme hieman enemmän SSE:stä, rakennetaan seuraavaksi SSE-palvelin.

## Harjoitus: SSE-palvelimen luominen

Palvelinta luodessamme on pidettävä mielessä kaksi asiaa:

- Tarvitsemme web-palvelimen, joka tarjoaa päätepisteet yhteyksille ja viesteille.
- Rakennamme palvelimen kuten tavallisesti käyttäen työkaluja, resursseja ja kehotteita, kuten stdio-palvelimissa.

### -1- Luo palvelininstanssi

Palvelimen luomiseksi käytämme samoja tyyppejä kuin stdio:ssa. Siirron osalta valitsemme kuitenkin SSE:n.

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

Edellisessä koodissa olemme:

- Luoneet palvelininstanssin.
- Määritelleet sovelluksen käyttäen web-kehystä express.
- Luoneet muuttujan transports, johon tallennamme saapuvat yhteydet.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Edellisessä koodissa olemme:

- Tuoneet tarvittavat kirjastot, mukaan lukien Starlette (ASGI-kehys).
- Luoneet MCP-palvelininstanssin `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Tässä vaiheessa olemme:

- Luoneet web-sovelluksen.
- Lisänneet tuen MCP-ominaisuuksille `AddMcpServer`-metodilla.

Lisätään seuraavaksi tarvittavat reitit.

### -2- Lisää reitit

Lisätään reitit, jotka käsittelevät yhteyden ja saapuvat viestit:

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

Edellisessä koodissa olemme määritelleet:

- `/sse`-reitin, joka luo SSE-tyyppisen siirron ja kutsuu MCP-palvelimen `connect`-metodia.
- `/messages`-reitin, joka huolehtii saapuvista viesteistä.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Edellisessä koodissa olemme:

- Luoneet ASGI-sovellusinstanssin Starlette-kehyksellä. Osana tätä välitämme `mcp.sse_app()` reittilistalle, mikä liittää `/sse` ja `/messages` reitit sovellusinstanssiin.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Olemme lisänneet lopussa rivin `add.MapMcp()`, mikä tarkoittaa, että meillä on nyt reitit `/SSE` ja `/messages`.

Lisätään seuraavaksi palvelimen ominaisuuksia.

### -3- Palvelimen ominaisuuksien lisääminen

Nyt kun SSE-spesifiset asiat on määritelty, lisätään palvelimelle ominaisuuksia kuten työkaluja, kehotteita ja resursseja.

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

Näin voit lisätä esimerkiksi työkalun. Tämä tietty työkalu luo työkalun nimeltä "random-joke", joka kutsuu Chuck Norris -API:a ja palauttaa JSON-vastauksen.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Nyt palvelimellasi on yksi työkalu.

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

1. Luodaan ensin työkaluja, tähän luomme tiedoston *Tools.cs* seuraavalla sisällöllä:

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

  Tässä olemme lisänneet:

  - Luoneet luokan `Tools`, jossa on `McpServerToolType`-koriste.
  - Määritelleet työkalun `AddNumbers` koristellen metodin `McpServerTool`-attribuutilla. Olemme myös määritelleet parametrit ja toteutuksen.

1. Hyödynnetään juuri luotua `Tools`-luokkaa:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Olemme lisänneet kutsun `WithTools`, joka määrittelee `Tools`-luokan sisältämään työkalut. Siinä kaikki, olemme valmiita.

Hienoa, meillä on SSE-palvelin, kokeillaan sitä seuraavaksi.

## Harjoitus: SSE-palvelimen debuggaus Inspectorilla

Inspector on loistava työkalu, jonka näimme aiemmassa oppitunnissa [Ensimmäisen palvelimen luominen](/03-GettingStarted/01-first-server/README.md). Katsotaan, voimmeko käyttää Inspector-työkalua myös tässä:

### -1- Inspectorin käynnistäminen

Inspectorin käynnistämiseksi sinun täytyy ensin saada SSE-palvelin käyntiin, tehdään se ensin:

1. Käynnistä palvelin

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Huomaa, että käytämme suoritettavaa tiedostoa `uvicorn`, joka asennetaan, kun kirjoitit `pip install "mcp[cli]"`. Kirjoittamalla `server:app` tarkoitetaan, että yritämme ajaa tiedostoa `server.py`, jossa on Starlette-instanssi nimeltä `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Tämä käynnistää palvelimen. Palvelimen kanssa kommunikointiin tarvitset uuden terminaalin.

1. Käynnistä inspector

    > ![NOTE]
    > Käynnistä tämä eri terminaalissa kuin missä palvelin on käynnissä. Huomaa myös, että sinun täytyy muokata alla olevaa komentoa vastaamaan URL-osoitetta, jossa palvelimesi toimii.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspectorin käynnistäminen näyttää samalta kaikissa ympäristöissä. Huomaa, että sen sijaan, että antaisit polun palvelimeen ja komennon palvelimen käynnistämiseksi, annat URL-osoitteen, jossa palvelin toimii, ja määrität myös `/sse`-reitin.

### -2- Työkalun kokeilu

Yhdistä palvelimeen valitsemalla pudotusvalikosta SSE ja täytä URL-kenttään palvelimesi osoite, esimerkiksi http:localhost:4321/sse. Klikkaa "Connect"-painiketta. Valitse kuten ennenkin listaa työkaluja, valitse työkalu ja anna syötteet. Näet tuloksen kuten alla:

![SSE-palvelin käynnissä inspectorissa](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fi.png)

Hienoa, pystyt työskentelemään inspectorin kanssa, katsotaan seuraavaksi miten voit työskennellä Visual Studio Coden kanssa.

## Tehtävä

Yritä rakentaa palvelimesi lisäämällä siihen enemmän ominaisuuksia. Katso [tästä sivusta](https://api.chucknorris.io/) esimerkiksi, miten lisäät työkalun, joka kutsuu API:a. Sinä päätät, miltä palvelimen tulisi näyttää. Hauskaa tekemistä :)

## Ratkaisu

[Ratkaisu](./solution/README.md) Tässä on mahdollinen ratkaisu toimivalla koodilla.

## Tärkeimmät opit

Tämän luvun tärkeimmät opit ovat:

- SSE on toinen stdio:n rinnalla tuetuista siirtotavoista.
- SSE:n tukemiseksi sinun täytyy hallita saapuvia yhteyksiä ja viestejä web-kehyksen avulla.
- Voit käyttää sekä Inspectoria että Visual Studio Codea SSE-palvelimen kuluttamiseen, aivan kuten stdio-palvelimissa. Huomaa, että stdio:n ja SSE:n välillä on pieniä eroja. SSE:n kanssa palvelin täytyy käynnistää erikseen ja sen jälkeen käynnistää inspector-työkalu. Inspector-työkalussa on myös eroavaisuuksia, sillä sinun täytyy määrittää URL-osoite.

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mitä seuraavaksi

- Seuraavaksi: [HTTP Streaming MCP:llä (Streamable HTTP)](../06-http-streaming/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.