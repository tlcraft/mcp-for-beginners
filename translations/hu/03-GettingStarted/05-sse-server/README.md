<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T19:15:42+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hu"
}
-->
# SSE Szerver

Az SSE (Server Sent Events) egy szabvány a szerver-kliens közötti adatfolyamra, amely lehetővé teszi, hogy a szerverek valós idejű frissítéseket küldjenek a klienseknek HTTP-n keresztül. Ez különösen hasznos olyan alkalmazásoknál, amelyek élő frissítéseket igényelnek, például csevegőalkalmazások, értesítések vagy valós idejű adatfolyamok esetén. Emellett a szerveredet egyszerre több kliens is használhatja, mivel a szerver bárhol, például a felhőben is futtatható.

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
- Mivel ez egy szerver, ami bárhol élhet, ezt tükröznie kell annak, ahogyan az Inspectorral és a Visual Studio Code-dal dolgozol. Ez azt jelenti, hogy nem azt mutatjuk meg, hogyan indítsd el a szervert, hanem azt az végpontot adod meg, ahol a kapcsolat létrejöhet. Lásd az alábbi példakódot:

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
- A `/messages` az az útvonal, amely kezeli a bejövő üzeneteket.

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

  A háttérben a `/sse` és a `/messages` útvonalak vannak beállítva, hogy kezeljék a kapcsolatokat és az üzeneteket. A többi funkció, például eszközök hozzáadása, ugyanúgy működik, mint a stdio szervereknél.

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
    - `MapMcp`, ez hozzáadja az olyan útvonalakat, mint a `/SSE` és a `/messages`.
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

// TODO: add routes 
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
    """Add two numbers"""
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

// MCP szerver létrehozása
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

server.tool("random-joke", "A chuck norris API által visszaadott vicc", {}, async () => {
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
    """Két szám összeadása"""
    return a + b

# Az SSE szerver felcsatolása a meglévő ASGI szerverre
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

      [McpServerTool, Description("Két szám összeadása.")]
      public async Task<string> AddNumbers(
          [Description("Az első szám")] int a,
          [Description("A második szám")] int b)
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

    Az inspector futtatása minden környezetben ugyanúgy néz ki. Figyeld meg, hogy ahelyett, hogy a szerver elindításához parancsot adnánk meg, most a szerver URL-jét adjuk meg, és megadjuk a `/sse` útvonalat.

### -2- Az eszköz kipróbálása

Csatlakozz a szerverhez az SSE kiválasztásával a legördülő menüből, és írd be a szervered URL-jét, például http:localhost:4321/sse. Ezután kattints a "Connect" gombra. Ahogy korábban, válaszd ki az eszközök listázását, válassz egy eszközt, és adj meg bemeneti értékeket. Az eredmény a következőhöz hasonló lesz:

![SSE szerver fut az inspectorban](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hu.png)

Remek, sikerült az inspectorral dolgoznod, nézzük meg, hogyan használhatod a Visual Studio Code-ot.

## Feladat

Próbáld meg továbbfejleszteni a szerveredet több funkcióval. Nézd meg [ezt az oldalt](https://api.chucknorris.io/), hogy például hozzáadj egy olyan eszközt, ami egy API-t hív meg. Te döntöd el, hogyan nézzen ki a szerver. Jó szórakozást :)

## Megoldás

[Megoldás](./solution/README.md) Itt egy lehetséges megoldás működő kóddal.

## Főbb tanulságok

A fejezet legfontosabb tanulságai:

- Az SSE a második támogatott adatátviteli mód a stdio mellett.
- Az SSE támogatásához kezelni kell a bejövő kapcsolatokat és üzeneteket egy webes keretrendszer segítségével.
- Az SSE szervert ugyanúgy használhatod Inspectorral és Visual Studio Code-dal, mint a stdio szervereket. Figyeld meg, hogy a stdio és az SSE között van némi különbség: az SSE esetén külön kell indítani a szervert, majd futtatni az inspector eszközt. Az inspector esetén meg kell adni az URL-t is.

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
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.