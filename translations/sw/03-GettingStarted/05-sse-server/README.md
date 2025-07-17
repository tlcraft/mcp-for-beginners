<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T10:14:47+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sw"
}
-->
# SSE Server

SSE (Server Sent Events) ni kiwango cha usambazaji wa data kutoka kwa seva kwenda kwa mteja, kinachowezesha seva kusukuma masasisho ya wakati halisi kwa wateja kupitia HTTP. Hii ni muhimu hasa kwa programu zinazohitaji masasisho ya moja kwa moja, kama vile programu za mazungumzo, arifa, au vyanzo vya data vya wakati halisi. Pia, seva yako inaweza kutumika na wateja wengi kwa wakati mmoja kwani inaishi kwenye seva inayoweza kuendeshwa mahali popote, kwa mfano katika wingu.

## Muhtasari

Somo hili linaelezea jinsi ya kujenga na kutumia SSE Servers.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kujenga SSE Server.
- Kutatua matatizo ya SSE Server kwa kutumia Inspector.
- Kutumia SSE Server kwa kutumia Visual Studio Code.

## SSE, jinsi inavyofanya kazi

SSE ni mojawapo ya aina mbili za usafirishaji zinazotegemewa. Tayari umeona aina ya kwanza stdio ikitumika katika masomo yaliyopita. Tofauti ni kama ifuatavyo:

- SSE inahitaji kushughulikia mambo mawili; muunganisho na ujumbe.
- Kwa kuwa hii ni seva inayoweza kuishi mahali popote, unahitaji hilo liakisi jinsi unavyofanya kazi na zana kama Inspector na Visual Studio Code. Hii inamaanisha badala ya kuelekeza jinsi ya kuanzisha seva, unalenga sehemu ya mwisho (endpoint) ambapo inaweza kuanzisha muunganisho. Angalia mfano wa msimbo hapa chini:

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

Katika msimbo uliotangulia:

- `/sse` imewekwa kama njia (route). Wakati ombi linapotumwa kwenye njia hii, mfano mpya wa usafirishaji huundwa na seva *inaunganishwa* kwa kutumia usafirishaji huu.
- `/messages`, hii ni njia inayoshughulikia ujumbe unaoingia.

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

Katika msimbo uliotangulia tumefanya:

- Kuunda mfano wa seva ya ASGI (tukitumia Starlette hasa) na kuweka njia ya kawaida `/`

  Kinachotokea nyuma ya pazia ni kwamba njia `/sse` na `/messages` zimewekwa kushughulikia miunganisho na ujumbe mtawalia. Sehemu nyingine za programu, kama kuongeza vipengele kama zana, hufanyika kama ilivyo kwa seva za stdio.

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

    Kuna njia mbili zinazotusaidia kutoka kwa seva ya wavuti hadi seva ya wavuti inayounga mkono SSE na hizo ni:

    - `AddMcpServer`, njia hii huongeza uwezo.
    - `MapMcp`, hii huongeza njia kama `/SSE` na `/messages`.

Sasa tunapojua kidogo zaidi kuhusu SSE, hebu tujenge seva ya SSE.

## Zoef: Kuunda SSE Server

Ili kuunda seva yetu, tunapaswa kuzingatia mambo mawili:

- Tunahitaji kutumia seva ya wavuti kufungua sehemu za mwisho kwa muunganisho na ujumbe.
- Kujenga seva yetu kama kawaida tunavyofanya kwa kutumia zana, rasilimali na maelekezo tulipokuwa tunatumia stdio.

### -1- Unda mfano wa seva

Ili kuunda seva yetu, tunatumia aina zile zile kama stdio. Hata hivyo, kwa usafirishaji, tunapaswa kuchagua SSE.

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

Katika msimbo uliotangulia tumefanya:

- Kuunda mfano wa seva.
- Kueleza app kwa kutumia fremu ya wavuti express.
- Kuunda variable ya transports ambayo tutatumia kuhifadhi miunganisho inayokuja.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Katika msimbo uliotangulia tumefanya:

- Kuleta maktaba tunazohitaji na Starlette (fremu ya ASGI) imeingizwa.
- Kuunda mfano wa seva ya MCP `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Hadi sasa, tumefanya:

- Kuunda app ya wavuti
- Kuongeza msaada kwa vipengele vya MCP kupitia `AddMcpServer`.

Hebu tuongeze njia zinazohitajika sasa.

### -2- Ongeza njia

Hebu tuongeze njia zinazoshughulikia muunganisho na ujumbe unaoingia:

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

Katika msimbo uliotangulia tumeeleza:

- Njia `/sse` inayounda usafirishaji wa aina SSE na hatimaye kuita `connect` kwenye seva ya MCP.
- Njia `/messages` inayoshughulikia ujumbe unaoingia.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Katika msimbo uliotangulia tumefanya:

- Kuunda mfano wa app ya ASGI kwa kutumia fremu ya Starlette. Kama sehemu ya hilo tumeipatia `mcp.sse_app()` kwenye orodha ya njia zake. Hii husababisha kuwekwa kwa njia `/sse` na `/messages` kwenye mfano wa app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Tumeongeza mstari mmoja wa msimbo mwishoni `add.MapMcp()` hii inamaanisha sasa tuna njia `/SSE` na `/messages`.

Hebu tuongeze uwezo kwa seva sasa.

### -3- Kuongeza uwezo wa seva

Sasa tunapokuwa tumefafanua kila kitu maalum cha SSE, hebu tuongeze uwezo wa seva kama zana, maelekezo na rasilimali.

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

Hivi ndivyo unavyoweza kuongeza zana kwa mfano. Zana hii maalum huunda zana iitwayo "random-joke" inayopiga API ya Chuck Norris na kurudisha jibu la JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Sasa seva yako ina zana moja.

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

1. Hebu tuunde zana kwanza, kwa hili tutaunda faili *Tools.cs* yenye maudhui yafuatayo:

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

  Hapa tumeongeza yafuatayo:

  - Kuunda darasa `Tools` lenye dekoreta `McpServerToolType`.
  - Kueleza zana `AddNumbers` kwa kupamba njia na `McpServerTool`. Pia tumeweka vigezo na utekelezaji.

1. Hebu tumie darasa `Tools` tulilounda hivi karibuni:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Tumeongeza wito wa `WithTools` unaoeleza `Tools` kama darasa lenye zana. Hiyo ni yote, tuko tayari.

Nzuri, tuna seva inayotumia SSE, hebu tujaribu sasa.

## Zoef: Kutatua matatizo ya SSE Server kwa Inspector

Inspector ni zana nzuri tuliyoiona katika somo lililopita [Creating your first server](/03-GettingStarted/01-first-server/README.md). Hebu tuone kama tunaweza kuitumia Inspector hapa pia:

### -1- Kuendesha inspector

Ili kuendesha inspector, kwanza lazima seva ya SSE iwe inafanya kazi, basi tufanye hivyo sasa:

1. Endesha seva

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Angalia jinsi tunavyotumia executable `uvicorn` inayosakinishwa tulipotumia `pip install "mcp[cli]"`. Kuandika `server:app` inamaanisha tunajaribu kuendesha faili `server.py` na kuwa na mfano wa Starlette uitwao `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Hii inapaswa kuanzisha seva. Ili kuingiliana nayo unahitaji terminal mpya.

1. Endesha inspector

    > ![NOTE]
    > Endesha hii katika dirisha tofauti la terminal tofauti na ile seva inayoendeshwa. Pia kumbuka, unahitaji kurekebisha amri hapa chini ili ifae URL ambapo seva yako inaendeshwa.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Kuendesha inspector ni sawa katika mazingira yote. Angalia jinsi badala ya kupitisha njia ya faili ya seva na amri ya kuanzisha seva, tunapita URL ambapo seva inaendeshwa na pia tunaeleza njia `/sse`.

### -2- Jaribu zana

Unganisha seva kwa kuchagua SSE kwenye droplist na jaza sehemu ya url ambapo seva yako inaendeshwa, kwa mfano http:localhost:4321/sse. Sasa bonyeza kitufe cha "Connect". Kama awali, chagua kuorodhesha zana, chagua zana na toa thamani za kuingiza. Unapaswa kuona matokeo kama ifuatavyo:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sw.png)

Nzuri, unaweza kufanya kazi na inspector, hebu tuone jinsi ya kufanya kazi na Visual Studio Code sasa.

## Kazi ya Nyumbani

Jaribu kujenga seva yako na uwezo zaidi. Angalia [ukurasa huu](https://api.chucknorris.io/) kwa mfano, kuongeza zana inayopiga API. Uamuzi ni wako jinsi seva inavyopaswa kuonekana. Furahia :)

## Suluhisho

[Suluhisho](./solution/README.md) Hapa kuna suluhisho linalowezekana lenye msimbo unaofanya kazi.

## Muhimu Kukumbuka

Muhimu kukumbuka kutoka sura hii ni yafuatayo:

- SSE ni usafirishaji wa pili unaotegemewa baada ya stdio.
- Ili kuunga mkono SSE, unahitaji kusimamia miunganisho na ujumbe unaoingia kwa kutumia fremu ya wavuti.
- Unaweza kutumia Inspector na Visual Studio Code kutumia seva ya SSE, kama vile seva za stdio. Kumbuka jinsi inavyotofautiana kidogo kati ya stdio na SSE. Kwa SSE, unahitaji kuanzisha seva kando kisha kuendesha zana yako ya inspector. Kwa zana ya inspector, pia kuna tofauti kidogo kwamba unahitaji kueleza URL.

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Nini Kifuatacho

- Ifuatayo: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.