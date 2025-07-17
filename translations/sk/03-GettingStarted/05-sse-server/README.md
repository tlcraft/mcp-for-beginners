<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T11:05:00+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sk"
}
-->
# SSE Server

SSE (Server Sent Events) je štandard pre streamovanie zo servera na klienta, ktorý umožňuje serverom posielať klientom aktualizácie v reálnom čase cez HTTP. Je to obzvlášť užitočné pre aplikácie, ktoré potrebujú živé aktualizácie, ako sú chatové aplikácie, notifikácie alebo dátové toky v reálnom čase. Navyše váš server môže súčasne používať viac klientov, keďže beží na serveri, ktorý môže byť napríklad umiestnený v cloude.

## Prehľad

Táto lekcia pokrýva, ako vytvoriť a používať SSE servery.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Vytvoriť SSE server.
- Ladenie SSE servera pomocou Inspectoru.
- Používať SSE server vo Visual Studio Code.

## SSE, ako to funguje

SSE je jeden z dvoch podporovaných typov transportu. Prvý ste už videli v predchádzajúcich lekciách, kde sa používalo stdio. Rozdiel je nasledovný:

- SSE vyžaduje, aby ste riešili dve veci: pripojenie a správy.
- Keďže ide o server, ktorý môže bežať kdekoľvek, musíte to zohľadniť pri práci s nástrojmi ako Inspector a Visual Studio Code. To znamená, že namiesto toho, aby ste ukazovali, ako spustiť server, ukazujete na endpoint, kde sa môže nadviazať pripojenie. Pozrite si príklad kódu nižšie:

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

V predchádzajúcom kóde:

- `/sse` je nastavená ako trasa. Keď príde požiadavka na túto trasu, vytvorí sa nová inštancia transportu a server sa pomocou tohto transportu *pripojí*.
- `/messages` je trasa, ktorá spracováva prichádzajúce správy.

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

V predchádzajúcom kóde:

- Vytvoríme inštanciu ASGI servera (konkrétne pomocou Starlette) a pripojíme predvolenú trasu `/`.

  Za scénou sa nastavia trasy `/sse` a `/messages` na spracovanie pripojení a správ. Zvyšok aplikácie, ako pridávanie funkcií, nástrojov, prebieha rovnako ako pri stdio serveroch.

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

    Existujú dve metódy, ktoré nám pomáhajú prejsť z webového servera na webový server podporujúci SSE:

    - `AddMcpServer`, táto metóda pridáva potrebné schopnosti.
    - `MapMcp`, táto pridáva trasy ako `/SSE` a `/messages`.

Teraz, keď už vieme o SSE trochu viac, poďme si vytvoriť SSE server.

## Cvičenie: Vytvorenie SSE servera

Pri vytváraní servera musíme mať na pamäti dve veci:

- Potrebujeme použiť webový server na sprístupnenie endpointov pre pripojenie a správy.
- Server postavíme tak, ako sme zvyknutí pri stdio, s nástrojmi, zdrojmi a promptami.

### -1- Vytvorenie inštancie servera

Na vytvorenie servera použijeme rovnaké typy ako pri stdio, avšak pre transport zvolíme SSE.

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

V predchádzajúcom kóde sme:

- Vytvorili inštanciu servera.
- Definovali aplikáciu pomocou webového frameworku express.
- Vytvorili premennú transports, kde budeme ukladať prichádzajúce pripojenia.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

V predchádzajúcom kóde sme:

- Naimportovali knižnice, ktoré budeme potrebovať, vrátane Starlette (ASGI framework).
- Vytvorili inštanciu MCP servera `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

V tomto bode sme:

- Vytvorili webovú aplikáciu.
- Pridali podporu pre MCP funkcie cez `AddMcpServer`.

Teraz pridajme potrebné trasy.

### -2- Pridanie trás

Pridajme trasy, ktoré budú spracovávať pripojenie a prichádzajúce správy:

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

V predchádzajúcom kóde sme definovali:

- Trasou `/sse`, ktorá vytvára transport typu SSE a nakoniec volá `connect` na MCP serveri.
- Trasou `/messages`, ktorá spracováva prichádzajúce správy.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

V predchádzajúcom kóde sme:

- Vytvorili ASGI aplikáciu pomocou frameworku Starlette. Pri tom sme do zoznamu trás pridali `mcp.sse_app()`, čo pripojí trasy `/sse` a `/messages` k aplikácii.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Pridali sme na konci riadok `add.MapMcp()`, čo znamená, že teraz máme trasy `/SSE` a `/messages`.

Teraz pridajme serveru schopnosti.

### -3- Pridanie schopností servera

Keď už máme všetko špecifické pre SSE definované, pridajme schopnosti servera ako nástroje, prompty a zdroje.

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

Tu je príklad, ako pridať nástroj. Tento konkrétny nástroj vytvára nástroj s názvom "random-joke", ktorý volá Chuck Norris API a vracia JSON odpoveď.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Teraz má váš server jeden nástroj.

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

1. Najprv si vytvorme nejaké nástroje, na to vytvoríme súbor *Tools.cs* s nasledujúcim obsahom:

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

  Tu sme pridali:

  - Vytvorili triedu `Tools` s dekorátorom `McpServerToolType`.
  - Definovali nástroj `AddNumbers` pomocou dekorátora `McpServerTool`. Tiež sme poskytli parametre a implementáciu.

1. Teraz využijeme triedu `Tools`, ktorú sme práve vytvorili:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Pridali sme volanie `WithTools`, ktoré špecifikuje triedu `Tools` ako obsahujúcu nástroje. To je všetko, sme pripravení.

Skvelé, máme server používajúci SSE, poďme si ho teraz vyskúšať.

## Cvičenie: Ladenie SSE servera pomocou Inspectoru

Inspector je skvelý nástroj, ktorý sme videli v predchádzajúcej lekcii [Creating your first server](/03-GettingStarted/01-first-server/README.md). Pozrime sa, či ho môžeme použiť aj tu:

### -1- Spustenie Inspectoru

Na spustenie Inspectoru musíte mať najprv bežiaci SSE server, tak ho spustíme:

1. Spustite server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Všimnite si, že používame spustiteľný súbor `uvicorn`, ktorý sa nainštaluje po zadaní `pip install "mcp[cli]"`. Zadanie `server:app` znamená, že sa snažíme spustiť súbor `server.py` a použiť v ňom inštanciu Starlette s názvom `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Toto by malo spustiť server. Na komunikáciu s ním potrebujete nový terminál.

1. Spustite Inspector

    > ![NOTE]
    > Spustite to v inom terminálovom okne, než kde beží server. Tiež si upravte príkaz nižšie podľa URL, kde váš server beží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Spustenie Inspectoru vyzerá rovnako vo všetkých runtime. Všimnite si, že namiesto zadania cesty k serveru a príkazu na jeho spustenie zadávame URL, kde server beží, a tiež špecifikujeme trasu `/sse`.

### -2- Vyskúšanie nástroja

Pripojte sa k serveru výberom SSE v rozbaľovacom zozname a vyplňte pole URL, kde váš server beží, napríklad http:localhost:4321/sse. Potom kliknite na tlačidlo "Connect". Ako predtým, vyberte možnosť zobraziť nástroje, vyberte nástroj a zadajte vstupné hodnoty. Mali by ste vidieť výsledok ako na obrázku nižšie:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sk.png)

Skvelé, dokážete pracovať s Inspectorom, poďme sa pozrieť, ako pracovať s Visual Studio Code.

## Zadanie

Skúste rozšíriť svoj server o ďalšie schopnosti. Pozrite si [túto stránku](https://api.chucknorris.io/), kde môžete napríklad pridať nástroj, ktorý volá API. Vy rozhodnete, ako bude server vyzerať. Prajeme veľa zábavy :)

## Riešenie

[Riešenie](./solution/README.md) Tu je možné riešenie s funkčným kódom.

## Kľúčové poznatky

Hlavné poznatky z tejto kapitoly sú:

- SSE je druhý podporovaný transport vedľa stdio.
- Na podporu SSE musíte spravovať prichádzajúce pripojenia a správy pomocou webového frameworku.
- Na používanie SSE servera môžete použiť Inspector aj Visual Studio Code, rovnako ako pri stdio serveroch. Všimnite si však rozdiely medzi stdio a SSE. Pri SSE musíte server spustiť samostatne a potom spustiť Inspector. Pri Inspectorovi je tiež potrebné špecifikovať URL.

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Dodatočné zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Čo ďalej

- Ďalej: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.