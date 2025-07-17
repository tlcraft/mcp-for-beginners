<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T12:12:00+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hr"
}
-->
# SSE Server

SSE (Server Sent Events) je standard za streaming s poslužitelja na klijenta, koji omogućuje poslužiteljima da šalju ažuriranja u stvarnom vremenu klijentima preko HTTP-a. Ovo je posebno korisno za aplikacije koje zahtijevaju ažuriranja uživo, poput chat aplikacija, obavijesti ili feedova podataka u stvarnom vremenu. Također, vaš poslužitelj može koristiti više klijenata istovremeno jer se nalazi na poslužitelju koji se može pokrenuti negdje u oblaku, na primjer.

## Pregled

Ova lekcija objašnjava kako izgraditi i koristiti SSE poslužitelje.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Izgraditi SSE poslužitelj.
- Otkloniti pogreške na SSE poslužitelju koristeći Inspector.
- Koristiti SSE poslužitelj u Visual Studio Code-u.

## SSE, kako radi

SSE je jedan od dva podržana tipa transporta. Već ste vidjeli prvi, stdio, u prethodnim lekcijama. Razlika je sljedeća:

- SSE zahtijeva da upravljate s dvije stvari; vezom i porukama.
- Budući da je ovo poslužitelj koji može biti bilo gdje, to se mora odraziti u načinu na koji radite s alatima poput Inspectora i Visual Studio Code-a. To znači da umjesto da pokazujete kako pokrenuti poslužitelj, vi pokazujete na endpoint gdje se može uspostaviti veza. Pogledajte primjer koda ispod:

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

U prethodnom kodu:

- `/sse` je postavljena kao ruta. Kada se napravi zahtjev prema toj ruti, stvara se nova instanca transporta i poslužitelj se *povezuje* koristeći taj transport.
- `/messages` je ruta koja obrađuje dolazne poruke.

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

U prethodnom kodu:

- Kreiramo instancu ASGI poslužitelja (konkretno koristeći Starlette) i montiramo zadanu rutu `/`.

  Ono što se događa u pozadini je da su rute `/sse` i `/messages` postavljene za upravljanje vezama i porukama. Ostatak aplikacije, poput dodavanja značajki kao što su alati, radi se kao i kod stdio poslužitelja.

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

    Postoje dvije metode koje nam pomažu da pređemo s web poslužitelja na web poslužitelj koji podržava SSE, a to su:

    - `AddMcpServer`, ova metoda dodaje potrebne mogućnosti.
    - `MapMcp`, ova dodaje rute poput `/SSE` i `/messages`.

Sad kad znamo malo više o SSE, idemo izgraditi SSE poslužitelj.

## Vježba: Kreiranje SSE poslužitelja

Da bismo kreirali naš poslužitelj, moramo imati na umu dvije stvari:

- Moramo koristiti web poslužitelj za izlaganje endpointa za vezu i poruke.
- Izgraditi poslužitelj kao i obično s alatima, resursima i promptovima kao što smo radili sa stdio.

### -1- Kreiranje instance poslužitelja

Za kreiranje poslužitelja koristimo iste tipove kao i kod stdio. Međutim, za transport moramo odabrati SSE.

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

U prethodnom kodu smo:

- Kreirali instancu poslužitelja.
- Definirali aplikaciju koristeći web framework express.
- Kreirali varijablu transports u koju ćemo spremati dolazne veze.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

U prethodnom kodu smo:

- Uvezli potrebne biblioteke, uključujući Starlette (ASGI framework).
- Kreirali MCP poslužitelj instancu `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Do sada smo:

- Kreirali web aplikaciju.
- Dodali podršku za MCP značajke putem `AddMcpServer`.

Sljedeće dodajmo potrebne rute.

### -2- Dodavanje ruta

Dodajmo rute koje upravljaju vezom i dolaznim porukama:

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

U prethodnom kodu definirali smo:

- `/sse` rutu koja instancira transport tipa SSE i poziva `connect` na MCP poslužitelju.
- `/messages` rutu koja obrađuje dolazne poruke.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

U prethodnom kodu smo:

- Kreirali ASGI aplikaciju koristeći Starlette framework. Kao dio toga, proslijedili smo `mcp.sse_app()` u listu ruta. To montira `/sse` i `/messages` rute na aplikaciju.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Dodali smo jednu liniju koda na kraju `add.MapMcp()`, što znači da sada imamo rute `/SSE` i `/messages`.

Sljedeće dodajmo mogućnosti poslužitelju.

### -3- Dodavanje mogućnosti poslužitelju

Sad kad smo definirali sve što je specifično za SSE, dodajmo mogućnosti poslužitelju poput alata, promptova i resursa.

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

Evo kako možete dodati alat, na primjer. Ovaj alat kreira alat pod nazivom "random-joke" koji poziva Chuck Norris API i vraća JSON odgovor.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Sada vaš poslužitelj ima jedan alat.

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

1. Prvo kreirajmo neke alate, za to ćemo napraviti datoteku *Tools.cs* sa sljedećim sadržajem:

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

  Ovdje smo dodali sljedeće:

  - Kreirali klasu `Tools` s dekoratorom `McpServerToolType`.
  - Definirali alat `AddNumbers` dekorirajući metodu s `McpServerTool`. Također smo definirali parametre i implementaciju.

1. Iskoristimo klasu `Tools` koju smo upravo kreirali:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Dodali smo poziv `WithTools` koji specificira `Tools` kao klasu koja sadrži alate. To je to, spremni smo.

Super, imamo poslužitelj koji koristi SSE, idemo ga isprobati.

## Vježba: Otklanjanje pogrešaka SSE poslužitelja pomoću Inspectora

Inspector je izvrstan alat koji smo vidjeli u prethodnoj lekciji [Creating your first server](/03-GettingStarted/01-first-server/README.md). Pogledajmo možemo li ga koristiti i ovdje:

### -1- Pokretanje Inspectora

Da biste pokrenuli Inspector, prvo morate imati pokrenut SSE poslužitelj, pa to učinimo:

1. Pokrenite poslužitelj

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Primijetite da koristimo izvršnu datoteku `uvicorn` koja se instalira kada upišete `pip install "mcp[cli]"`. Upis `server:app` znači da pokušavamo pokrenuti datoteku `server.py` koja sadrži Starlette instancu nazvanu `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Ovo bi trebalo pokrenuti poslužitelj. Za interakciju s njim trebat će vam novi terminal.

1. Pokrenite Inspector

    > ![NOTE]
    > Pokrenite ovo u zasebnom terminalu od onog u kojem je pokrenut poslužitelj. Također, prilagodite naredbu ispod URL-u na kojem vaš poslužitelj radi.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pokretanje Inspectora izgleda isto u svim runtime okruženjima. Primijetite da umjesto da prosljeđujemo putanju do poslužitelja i naredbu za njegovo pokretanje, prosljeđujemo URL na kojem poslužitelj radi i specificiramo `/sse` rutu.

### -2- Isprobavanje alata

Povežite se s poslužiteljem odabirom SSE u padajućem izborniku i unesite URL na kojem vaš poslužitelj radi, na primjer http:localhost:4321/sse. Zatim kliknite na gumb "Connect". Kao i prije, odaberite da prikažete alate, izaberite alat i unesite ulazne vrijednosti. Trebali biste vidjeti rezultat kao na slici ispod:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hr.png)

Super, možete raditi s Inspectorom, pogledajmo sada kako raditi s Visual Studio Code-om.

## Zadatak

Pokušajte proširiti svoj poslužitelj s više mogućnosti. Pogledajte [ovu stranicu](https://api.chucknorris.io/) kako biste, na primjer, dodali alat koji poziva API. Vi odlučujete kako poslužitelj treba izgledati. Zabavite se :)

## Rješenje

[Rješenje](./solution/README.md) Evo jednog mogućeg rješenja s radnim kodom.

## Ključne spoznaje

Ključne spoznaje iz ovog poglavlja su:

- SSE je drugi podržani transport pored stdio.
- Za podršku SSE-u morate upravljati dolaznim vezama i porukama koristeći web framework.
- Možete koristiti i Inspector i Visual Studio Code za korištenje SSE poslužitelja, kao i kod stdio poslužitelja. Primijetite da postoji mala razlika između stdio i SSE. Za SSE morate posebno pokrenuti poslužitelj, a zatim pokrenuti Inspector alat. Također, za Inspector alat morate specificirati URL.

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Što slijedi

- Sljedeće: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.