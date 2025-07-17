<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T10:48:56+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "cs"
}
-->
# SSE Server

SSE (Server Sent Events) je standard pro streamování ze serveru na klienta, který umožňuje serverům posílat klientům aktualizace v reálném čase přes HTTP. To je obzvlášť užitečné pro aplikace vyžadující živé aktualizace, jako jsou chatovací aplikace, notifikace nebo datové toky v reálném čase. Navíc může váš server obsluhovat více klientů současně, protože běží na serveru, který může být například umístěn v cloudu.

## Přehled

Tato lekce pokrývá, jak vytvořit a používat SSE servery.

## Cíle učení

Na konci této lekce budete schopni:

- Vytvořit SSE server.
- Ladit SSE server pomocí Inspectoru.
- Používat SSE server ve Visual Studio Code.

## SSE, jak to funguje

SSE je jeden ze dvou podporovaných typů přenosu. První jste už viděli v předchozích lekcích, kde se používalo stdio. Rozdíl je následující:

- SSE vyžaduje, abyste řešili dvě věci; připojení a zprávy.
- Protože tento server může běžet kdekoli, musíte to zohlednit při práci s nástroji jako Inspector a Visual Studio Code. To znamená, že místo toho, abyste ukazovali, jak server spustit, ukazujete na endpoint, kde lze navázat připojení. Viz příklad níže:

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

V předchozím kódu:

- `/sse` je nastavená jako routa. Když přijde požadavek na tuto routu, vytvoří se nová instance transportu a server se pomocí tohoto transportu *připojí*.
- `/messages` je routa, která zpracovává příchozí zprávy.

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

V předchozím kódu:

- Vytvoříme instanci ASGI serveru (konkrétně pomocí Starlette) a připojíme výchozí routu `/`.

  Co se děje na pozadí je, že routy `/sse` a `/messages` jsou nastaveny pro zpracování připojení a zpráv. Zbytek aplikace, jako přidávání funkcí jako nástroje, probíhá stejně jako u stdio serverů.

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

Existují dvě metody, které nám pomáhají přejít od webového serveru k webovému serveru podporujícímu SSE, a to:

- `AddMcpServer`, tato metoda přidává potřebné schopnosti.
- `MapMcp`, tato přidává routy jako `/SSE` a `/messages`.

Teď, když už víme trochu víc o SSE, pojďme si postavit SSE server.

## Cvičení: Vytvoření SSE serveru

Pro vytvoření našeho serveru musíme mít na paměti dvě věci:

- Musíme použít webový server, který zpřístupní endpointy pro připojení a zprávy.
- Server postavíme stejně jako obvykle s nástroji, zdroji a výzvami, jak jsme to dělali u stdio.

### -1- Vytvoření instance serveru

Pro vytvoření serveru použijeme stejné typy jako u stdio. Pro transport ale musíme zvolit SSE.

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

V předchozím kódu jsme:

- Vytvořili instanci serveru.
- Definovali aplikaci pomocí webového frameworku express.
- Vytvořili proměnnou transports, kterou použijeme k ukládání příchozích připojení.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

V předchozím kódu jsme:

- Naimportovali knihovny, které budeme potřebovat, včetně Starlette (ASGI framework).
- Vytvořili instanci MCP serveru `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

V tomto bodě jsme:

- Vytvořili webovou aplikaci.
- Přidali podporu pro MCP funkce pomocí `AddMcpServer`.

Pojďme teď přidat potřebné routy.

### -2- Přidání rout

Přidáme routy, které budou zpracovávat připojení a příchozí zprávy:

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

V předchozím kódu jsme definovali:

- `/sse` routu, která vytvoří transport typu SSE a zavolá `connect` na MCP serveru.
- `/messages` routu, která se stará o příchozí zprávy.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

V předchozím kódu jsme:

- Vytvořili instanci ASGI aplikace pomocí frameworku Starlette. Součástí je předání `mcp.sse_app()` do seznamu rout, což připojí `/sse` a `/messages` routy k aplikaci.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Přidali jsme na konec řádek `add.MapMcp()`, což znamená, že nyní máme routy `/SSE` a `/messages`.

Pojďme teď přidat schopnosti serveru.

### -3- Přidání schopností serveru

Nyní, když máme definováno vše specifické pro SSE, přidáme schopnosti serveru jako nástroje, výzvy a zdroje.

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

Tady je příklad, jak přidat nástroj. Tento konkrétní nástroj vytvoří nástroj s názvem "random-joke", který volá Chuck Norris API a vrací JSON odpověď.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Teď má váš server jeden nástroj.

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

1. Nejprve vytvoříme nějaké nástroje, pro to vytvoříme soubor *Tools.cs* s následujícím obsahem:

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

  Zde jsme přidali:

  - Vytvořili třídu `Tools` s dekorátorem `McpServerToolType`.
  - Definovali nástroj `AddNumbers` pomocí dekorátoru `McpServerTool` u metody. Také jsme specifikovali parametry a implementaci.

1. Nyní využijeme třídu `Tools`, kterou jsme právě vytvořili:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Přidali jsme volání `WithTools`, které specifikuje třídu `Tools` jako obsahující nástroje. To je vše, jsme připraveni.

Skvěle, máme server používající SSE, pojďme si ho teď vyzkoušet.

## Cvičení: Ladění SSE serveru pomocí Inspectoru

Inspector je skvělý nástroj, který jsme viděli v předchozí lekci [Vytvoření vašeho prvního serveru](/03-GettingStarted/01-first-server/README.md). Podívejme se, jestli ho můžeme použít i zde:

### -1- Spuštění Inspectoru

Pro spuštění Inspectoru musíte mít nejprve spuštěný SSE server, pojďme to tedy udělat:

1. Spusťte server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Všimněte si, že používáme spustitelný soubor `uvicorn`, který se nainstaluje při zadání `pip install "mcp[cli]"`. Zadání `server:app` znamená, že se snažíme spustit soubor `server.py` a že tento soubor obsahuje instanci Starlette s názvem `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Tím by se měl server spustit. Pro komunikaci s ním budete potřebovat nové terminálové okno.

1. Spusťte Inspector

    > ![NOTE]
    > Spusťte tento příkaz v samostatném terminálovém okně, než ve kterém běží server. Také si upravte níže uvedený příkaz tak, aby odpovídal URL, na kterém váš server běží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Spuštění Inspectoru vypadá ve všech runtime stejně. Všimněte si, že místo předání cesty k serveru a příkazu pro jeho spuštění předáváme URL, kde server běží, a také specifikujeme `/sse` routu.

### -2- Vyzkoušení nástroje

Připojte se k serveru výběrem SSE v rozbalovacím seznamu a vyplňte pole URL, kde váš server běží, například http://localhost:4321/sse. Poté klikněte na tlačítko "Connect". Stejně jako dříve vyberte možnost zobrazit nástroje, vyberte nástroj a zadejte vstupní hodnoty. Měli byste vidět výsledek jako níže:

![SSE Server běžící v inspectoru](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.cs.png)

Skvěle, umíte pracovat s Inspector, pojďme se podívat, jak pracovat s Visual Studio Code.

## Zadání

Zkuste rozšířit svůj server o další schopnosti. Podívejte se na [tuto stránku](https://api.chucknorris.io/), kde můžete například přidat nástroj, který volá API. Vy rozhodnete, jak bude server vypadat. Bavte se :)

## Řešení

[Řešení](./solution/README.md) Zde je možné řešení s funkčním kódem.

## Klíčové poznatky

Klíčové poznatky z této kapitoly jsou:

- SSE je druhý podporovaný transport vedle stdio.
- Pro podporu SSE musíte spravovat příchozí připojení a zprávy pomocí webového frameworku.
- Pro konzumaci SSE serveru můžete použít jak Inspector, tak Visual Studio Code, stejně jako u stdio serverů. Všimněte si, že se trochu liší způsob práce mezi stdio a SSE. U SSE musíte server spustit samostatně a pak spustit Inspector. U Inspectoru je také potřeba specifikovat URL.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Další zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dál

- Další: [HTTP Streaming s MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.