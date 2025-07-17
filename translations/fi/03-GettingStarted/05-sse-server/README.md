<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:53:43+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fi"
}
-->
# SSE-palvelin

SSE (Server Sent Events) on standardi palvelimelta asiakkaalle tapahtuvaan suoratoistoon, joka mahdollistaa palvelimien työntää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli. Tämä on erityisen hyödyllistä sovelluksissa, jotka tarvitsevat live-päivityksiä, kuten chat-sovellukset, ilmoitukset tai reaaliaikaiset tietovirrat. Lisäksi palvelintasi voi käyttää useampi asiakas samanaikaisesti, koska se toimii palvelimella, joka voi sijaita esimerkiksi pilvessä.

## Yleiskatsaus

Tässä oppitunnissa käydään läpi, miten rakentaa ja käyttää SSE-palvelimia.

## Oppimistavoitteet

Oppitunnin lopussa osaat:

- Rakentaa SSE-palvelimen.
- Debugata SSE-palvelinta Inspectorilla.
- Käyttää SSE-palvelinta Visual Studio Codella.

## SSE, miten se toimii

SSE on yksi kahdesta tuetusta siirtotavasta. Olet jo nähnyt ensimmäisen, stdio:n, käytössä aiemmissa oppitunneissa. Erot ovat seuraavat:

- SSE vaatii, että hallitset kahta asiaa; yhteyden ja viestit.
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

- `/sse` on määritelty reitiksi. Kun tähän reittiin tehdään pyyntö, luodaan uusi siirtotapaus ja palvelin *yhdistää* tämän siirtotavan avulla.
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

- Luodaan ASGI-palvelimen instanssi (tässä käytetään erityisesti Starlettea) ja liitetään oletusreitti `/`

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

    On kaksi metodia, jotka auttavat siirtymään web-palvelimesta SSE:tä tukevaksi web-palvelimeksi, ja ne ovat:

    - `AddMcpServer`, tämä metodi lisää toiminnallisuuksia.
    - `MapMcp`, tämä lisää reitit kuten `/SSE` ja `/messages`.
```

Now that we know a little bit more about SSE, let's build an SSE server next.

## Exercise: Creating an SSE Server

To create our server, we need to keep two things in mind:

- We need to use a web server to expose endpoints for connection and messages.
- Build our server like we normally do with tools, resources and prompts when we were using stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to choose SSE.

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

In the preceding code we've:

- Created a server instance.
- Defined an app using the web framework express.
- Created a transports variable that we will use to store incoming connections.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In the preceding code we've:

- Imported the libraries we're going to need with Starlette (an ASGI framework) being pulled in.
- Created an MCP server instance `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: lisää reitit 
```

At this point, we've:

- Created a web app
- Added support for MCP features through `AddMcpServer`.

Let's add the needed routes next.

### -2- Add routes

Let's add routes next that handle the connection and incoming messages:

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

In the preceding code we've defined:

- An `/sse` route that instantiates a transport of type SSE and ends up calling `connect` on the MCP server.
- A `/messages` route that takes care of incoming messages.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In the preceding code we've:

- Created an ASGI app instance using the Starlette framework. As part of that we passes `mcp.sse_app()` to it's list of routes. That ends up mounting an `/sse` and `/messages` route on the app instance.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We've added one line of code at the end `add.MapMcp()` this means we now have routes `/SSE` and `/messages`. 

Let's add capabilties to the server next.

### -3- Adding server capabilities

Now that we've got everything SSE specific defined, let's add server capabilities like tools, prompts and resources.

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

Here's how you can add a tool for example. This specific tool creates a tool call "random-joke" that calls a Chuck Norris API and returns a JSON response.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Lisää kaksi lukua yhteen"""
    return a + b
```

Now your server has one tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Luo MCP-palvelin
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

server.tool("random-joke", "Chuck Norris -API:n palauttama vitsi", {}, async () => {
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
    """Lisää kaksi lukua yhteen"""
    return a + b

# Liitä SSE-palvelin olemassa olevaan ASGI-palvelimeen
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Let's create some tools first, for this we will create a file *Tools.cs* with the following content:

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

      [McpServerTool, Description("Lisää kaksi lukua yhteen.")]
      public async Task<string> AddNumbers(
          [Description("Ensimmäinen luku")] int a,
          [Description("Toinen luku")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Here we've added the following:

  - Created a class `Tools` with the decorator `McpServerToolType`.
  - Defined a tool `AddNumbers` by decorating the method with `McpServerTool`. We've also provided parameters and an implementation.

1. Let's leverage the `Tools` class we just created:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We've added a call to `WithTools` that specifies `Tools` as the class containing the tools. That's it, we're ready.

Great, we have a server using SSE, let's take it for a spin next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a great tool that we saw in a previous lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's see if we can use the Inspector even here:

### -1- Running the inspector

To run the inspector, you first must have an SSE server running, so let's do that next:

1. Run the server 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note how we use the executable `uvicorn` that's installed when we typed `pip install "mcp[cli]"`. Typing `server:app` means we're trying to run a file `server.py` and for it to have a Starlette instance called `app`. 

    ### .NET

    ```sh
    dotnet run
    ```

    This should start the server. To interface with it you need a new terminal.

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window than the server is running in. Also note, you need to adjust the below command to fit the URL where your server runs.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspectorin käyttö näyttää samalta kaikissa ajoympäristöissä. Huomaa, että sen sijaan, että antaisit polun palvelimelle ja komennon palvelimen käynnistämiseen, annat URL-osoitteen, jossa palvelin on käynnissä, ja määrität myös `/sse`-reititteen.

### -2- Työkalun kokeilu

Yhdistä palvelimeen valitsemalla SSE pudotusvalikosta ja täytä url-kenttään palvelimesi osoite, esimerkiksi http:localhost:4321/sse. Klikkaa sitten "Connect"-painiketta. Valitse kuten aiemmin työkalujen listaaminen, valitse työkalu ja anna syötteet. Näet tuloksen alla olevan kuvan kaltaisena:

![SSE-palvelin käynnissä inspectorissa](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fi.png)

Hienoa, osaat käyttää inspectoria, katsotaan seuraavaksi miten voit työskennellä Visual Studio Coden kanssa.

## Tehtävä

Yritä laajentaa palvelintasi lisäämällä toiminnallisuuksia. Katso [tältä sivulta](https://api.chucknorris.io/) esimerkiksi, miten lisäät työkalun, joka kutsuu API:a. Sinä päätät, miltä palvelimen tulisi näyttää. Hauskaa koodausta :)

## Ratkaisu

[Ratkaisu](./solution/README.md) Tässä on yksi mahdollinen ratkaisu toimivalla koodilla.

## Tärkeimmät opit

Tämän luvun tärkeimmät opit ovat:

- SSE on toinen stdio:n lisäksi tuetuista siirtotavoista.
- SSE:n tukemiseksi sinun täytyy hallita saapuvia yhteyksiä ja viestejä web-kehyksen avulla.
- Voit käyttää sekä Inspectoria että Visual Studio Codea SSE-palvelimen kuluttamiseen, aivan kuten stdio-palvelimissa. Huomaa, että stdio:n ja SSE:n välillä on pieniä eroja. SSE:n kanssa palvelin täytyy käynnistää erikseen ja sen jälkeen suorittaa inspector-työkalu. Inspector-työkalussa on myös eroavaisuuksia, sillä URL-osoite täytyy määrittää.

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Lisäresurssit

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mitä seuraavaksi

- Seuraavaksi: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.