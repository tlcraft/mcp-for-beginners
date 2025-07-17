<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T10:31:58+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
# SSE Szerver

Az SSE (Server Sent Events) egy szabvány a szerver-kliens közötti adatfolyamra, amely lehetővé teszi, hogy a szerverek valós idejű frissítéseket küldjenek a klienseknek HTTP-n keresztül. Ez különösen hasznos olyan alkalmazásoknál, amelyek élő frissítéseket igényelnek, például csevegőalkalmazások, értesítések vagy valós idejű adatfolyamok esetén. Emellett a szerveredet egyszerre több kliens is használhatja, mivel a szerver bárhol, például a felhőben is futhat.

## Áttekintés

Ebben a leckében azt tanuljuk meg, hogyan építsünk és használjunk SSE szervereket.

## Tanulási célok

A lecke végére képes leszel:

- SSE szervert építeni.
- Hibakeresni egy SSE szervert az Inspector segítségével.
- Használni egy SSE szervert Visual Studio Code-dal.

## SSE, hogyan működik

Az SSE az egyik támogatott adatátviteli típus. Az előző leckékben már láttad az elsőt, a stdio-t. A különbség a következő:

- Az SSE esetén két dolgot kell kezelned: a kapcsolatot és az üzeneteket.
- Mivel ez egy szerver, ami bárhol futhat, ezt tükröznie kell annak, ahogyan az Inspectorral és a Visual Studio Code-dal dolgozol. Ez azt jelenti, hogy nem a szerver indítását mutatod meg, hanem azt az végpontot, ahol a kapcsolat létrejöhet. Lásd az alábbi példakódot:

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

A fenti kódban:

- A `/sse` útvonal van beállítva. Amikor erre az útvonalra érkezik kérés, létrejön egy új transport példány, és a szerver ezen a transporton *kapcsolódik*.
- A `/messages` útvonal kezeli a bejövő üzeneteket.

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

A fenti kódban:

- Létrehozunk egy ASGI szerver példányt (konkrétan Starlette-et használva), és felcsatoljuk az alapértelmezett `/` útvonalat.

  A háttérben a `/sse` és `/messages` útvonalak kezelik a kapcsolatokat és az üzeneteket. A többi funkció, például eszközök hozzáadása, ugyanúgy működik, mint a stdio szervereknél.

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

    Két metódus segít abban, hogy egy web szerverből SSE-t támogató web szervert készítsünk:

    - `AddMcpServer`, ez a metódus hozzáadja a képességeket.
    - `MapMcp`, ez hozzáadja az olyan útvonalakat, mint a `/SSE` és `/messages`.

Most, hogy már többet tudunk az SSE-ről, építsünk egy SSE szervert.

## Gyakorlat: SSE szerver létrehozása

A szerver létrehozásakor két dolgot kell szem előtt tartanunk:

- Web szervert kell használnunk, hogy elérhetővé tegyük a kapcsolat és az üzenetek végpontjait.
- A szervert úgy építsük fel, ahogy azt stdio használatakor tettük, eszközökkel, erőforrásokkal és promptokkal.

### -1- Szerver példány létrehozása

A szerver létrehozásához ugyanazokat a típusokat használjuk, mint stdio esetén, de a transport típusa SSE kell legyen.

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

A fenti kódban:

- Létrehoztunk egy szerver példányt.
- Definiáltunk egy appot az express web keretrendszerrel.
- Létrehoztunk egy transports változót, amiben a bejövő kapcsolatokat tároljuk.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

A fenti kódban:

- Importáltuk a szükséges könyvtárakat, köztük a Starlette-et (egy ASGI keretrendszer).
- Létrehoztunk egy MCP szerver példányt `mcp` néven.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Eddig:

- Létrehoztunk egy web appot.
- Hozzáadtuk az MCP funkciók támogatását az `AddMcpServer` segítségével.

Most adjuk hozzá a szükséges útvonalakat.

### -2- Útvonalak hozzáadása

Adjunk hozzá útvonalakat, amelyek kezelik a kapcsolatot és a bejövő üzeneteket:

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

A fenti kódban definiáltuk:

- Az `/sse` útvonalat, amely létrehoz egy SSE típusú transportot, és meghívja az MCP szerveren a `connect` metódust.
- A `/messages` útvonalat, amely kezeli a bejövő üzeneteket.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

A fenti kódban:

- Létrehoztunk egy ASGI app példányt a Starlette keretrendszerrel. Ennek részeként átadtuk az `mcp.sse_app()`-ot az útvonalak listájának, ami az `/sse` és `/messages` útvonalakat csatolja az apphoz.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Hozzáadtunk egy sort a végén: `add.MapMcp()`, ami azt jelenti, hogy most már elérhetőek a `/SSE` és `/messages` útvonalak.

Most adjunk képességeket a szerverhez.

### -3- Szerver képességek hozzáadása

Most, hogy minden SSE specifikus rész megvan, adjunk hozzá szerver képességeket, mint eszközök, promptok és erőforrások.

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

Így adhatsz például hozzá egy eszközt. Ez az eszköz egy "random-joke" nevű eszközt hoz létre, amely egy Chuck Norris API-t hív meg, és JSON választ ad vissza.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Most a szerverednek van egy eszköze.

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

1. Először hozzunk létre néhány eszközt, ehhez készítsünk egy *Tools.cs* fájlt a következő tartalommal:

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

  Itt a következőket tettük:

  - Létrehoztunk egy `Tools` osztályt az `McpServerToolType` dekorátorral.
  - Definiáltunk egy `AddNumbers` eszközt, amelyet a `McpServerTool` dekorátorral láttunk el. Paramétereket és implementációt is megadtunk.

1. Használjuk a most létrehozott `Tools` osztályt:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Hozzáadtunk egy hívást a `WithTools`-hoz, amely megadja, hogy a `Tools` osztály tartalmazza az eszközöket. Ennyi, készen vagyunk.

Szuper, van egy SSE-t használó szerverünk, próbáljuk ki!

## Gyakorlat: SSE szerver hibakeresése Inspectorral

Az Inspector egy nagyszerű eszköz, amit az előző leckében már láttunk [Első szerver létrehozása](/03-GettingStarted/01-first-server/README.md). Nézzük meg, használhatjuk-e itt is:

### -1- Az inspector futtatása

Az inspector futtatásához először egy SSE szervernek kell futnia, csináljuk meg ezt:

1. Indítsd el a szervert

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Figyeld meg, hogy az `uvicorn` futtatható fájlt használjuk, amely települ, amikor beírtuk a `pip install "mcp[cli]"` parancsot. A `server:app` azt jelenti, hogy a `server.py` fájlt futtatjuk, amelyben van egy `app` nevű Starlette példány.

    ### .NET

    ```sh
    dotnet run
    ```

    Ez elindítja a szervert. A szerverrel való kommunikációhoz új terminálra lesz szükséged.

1. Indítsd el az inspectort

    > ![NOTE]
    > Ezt egy külön terminál ablakban futtasd, mint ahol a szerver fut. Ne felejtsd el módosítani az alábbi parancsot, hogy illeszkedjen a szervered URL-jéhez.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Az inspector futtatása minden környezetben ugyanúgy néz ki. Figyeld meg, hogy ahelyett, hogy a szerver elérési útját és indítási parancsát adnánk meg, itt az URL-t adjuk meg, ahol a szerver fut, és megadjuk az `/sse` útvonalat is.

### -2- Az eszköz kipróbálása

Csatlakozz a szerverhez az SSE kiválasztásával a legördülő menüből, és írd be a szervered URL-jét, például http:localhost:4321/sse. Ezután kattints a "Connect" gombra. Ahogy korábban, válaszd ki az eszközök listázását, válassz egy eszközt, és adj meg bemeneti értékeket. Az eredmény valahogy így fog kinézni:

![SSE szerver fut az inspectorban](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hu.png)

Szuper, tudsz dolgozni az inspectorral, nézzük meg, hogyan használhatjuk a Visual Studio Code-ot.

## Feladat

Próbáld meg továbbfejleszteni a szervered több képességgel. Nézd meg [ezt az oldalt](https://api.chucknorris.io/), hogy például hozzáadj egy eszközt, ami egy API-t hív meg. Te döntöd el, hogyan nézzen ki a szervered. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Itt egy lehetséges megoldás működő kóddal.

## Főbb tanulságok

A fejezet legfontosabb tanulságai:

- Az SSE a második támogatott adatátviteli típus a stdio mellett.
- Az SSE támogatásához web keretrendszert kell használnod a bejövő kapcsolatok és üzenetek kezelésére.
- Az SSE szervereket ugyanúgy használhatod Inspectorral és Visual Studio Code-dal, mint a stdio szervereket. Figyeld meg, hogy a stdio és az SSE között van némi különbség: SSE esetén külön kell indítani a szervert, majd az inspector eszközt. Az inspector esetén meg kell adni az URL-t is.

## Minták

- [Java Számológép](../samples/java/calculator/README.md)
- [.Net Számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](../samples/javascript/README.md)
- [TypeScript Számológép](../samples/typescript/README.md)
- [Python Számológép](../../../../03-GettingStarted/samples/python)

## További források

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mi következik

- Következő: [HTTP Streaming MCP-vel (Streamable HTTP)](../06-http-streaming/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.