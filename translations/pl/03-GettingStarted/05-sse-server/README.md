<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T22:41:21+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pl"
}
-->
# Serwer SSE

SSE (Server Sent Events) to standard umożliwiający strumieniowanie danych z serwera do klienta, pozwalający serwerom na przesyłanie aktualizacji w czasie rzeczywistym do klientów przez HTTP. Jest to szczególnie przydatne w aplikacjach wymagających aktualizacji na żywo, takich jak czaty, powiadomienia czy strumienie danych w czasie rzeczywistym. Twój serwer może być również używany przez wielu klientów jednocześnie, ponieważ działa na serwerze, który może być uruchomiony na przykład w chmurze.

## Przegląd

Ta lekcja omawia, jak zbudować i korzystać z serwerów SSE.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Zbudować serwer SSE.
- Debugować serwer SSE za pomocą Inspektora.
- Korzystać z serwera SSE w Visual Studio Code.

## SSE, jak to działa

SSE to jeden z dwóch obsługiwanych typów transportu. W poprzednich lekcjach widziałeś już użycie pierwszego typu, czyli stdio. Różnice są następujące:

- SSE wymaga obsługi dwóch rzeczy: połączenia i wiadomości.
- Ponieważ jest to serwer, który może działać gdziekolwiek, musisz to uwzględnić w pracy z narzędziami takimi jak Inspector i Visual Studio Code. Oznacza to, że zamiast wskazywać, jak uruchomić serwer, wskazujesz punkt końcowy, gdzie można nawiązać połączenie. Zobacz poniższy przykład kodu:

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

W powyższym kodzie:

- `/sse` jest ustawiona jako trasa. Gdy zostanie wykonane żądanie do tej trasy, tworzona jest nowa instancja transportu, a serwer *łączy się* za pomocą tego transportu.
- `/messages` to trasa obsługująca przychodzące wiadomości.

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

W powyższym kodzie:

- Tworzymy instancję serwera ASGI (konkretnie używając Starlette) i montujemy domyślną trasę `/`.

  Za kulisami trasy `/sse` i `/messages` są skonfigurowane do obsługi połączeń i wiadomości odpowiednio. Reszta aplikacji, jak dodawanie funkcji takich jak narzędzia, działa tak samo jak w serwerach stdio.

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

    Istnieją dwie metody, które pomagają przejść od serwera WWW do serwera WWW obsługującego SSE:

    - `AddMcpServer` – ta metoda dodaje funkcjonalności.
    - `MapMcp` – ta metoda dodaje trasy takie jak `/SSE` i `/messages`.

Teraz, gdy wiemy trochę więcej o SSE, zbudujmy serwer SSE.

## Ćwiczenie: Tworzenie serwera SSE

Aby stworzyć nasz serwer, musimy pamiętać o dwóch rzeczach:

- Musimy użyć serwera WWW, aby udostępnić punkty końcowe do połączeń i wiadomości.
- Budować serwer tak, jak zwykle, korzystając z narzędzi, zasobów i promptów, tak jak przy użyciu stdio.

### -1- Utwórz instancję serwera

Do stworzenia serwera używamy tych samych typów co przy stdio. Jednak dla transportu musimy wybrać SSE.

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

W powyższym kodzie:

- Utworzyliśmy instancję serwera.
- Zdefiniowaliśmy aplikację korzystającą z frameworka webowego express.
- Stworzyliśmy zmienną transports, w której będziemy przechowywać przychodzące połączenia.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

W powyższym kodzie:

- Zaimportowaliśmy potrzebne biblioteki, w tym Starlette (framework ASGI).
- Utworzyliśmy instancję serwera MCP o nazwie `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Na tym etapie:

- Utworzyliśmy aplikację webową.
- Dodaliśmy wsparcie dla funkcji MCP przez `AddMcpServer`.

Dodajmy teraz potrzebne trasy.

### -2- Dodaj trasy

Dodajmy trasy obsługujące połączenia i przychodzące wiadomości:

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

W powyższym kodzie zdefiniowaliśmy:

- Trasę `/sse`, która tworzy transport typu SSE i wywołuje `connect` na serwerze MCP.
- Trasę `/messages`, która obsługuje przychodzące wiadomości.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

W powyższym kodzie:

- Utworzyliśmy instancję aplikacji ASGI korzystając z frameworka Starlette. Przekazaliśmy `mcp.sse_app()` do listy tras, co powoduje zamontowanie tras `/sse` i `/messages` w aplikacji.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Dodaliśmy na końcu linię `add.MapMcp()`, co oznacza, że mamy teraz trasy `/SSE` i `/messages`.

Dodajmy teraz funkcjonalności do serwera.

### -3- Dodawanie funkcji serwera

Teraz, gdy mamy wszystko specyficzne dla SSE, dodajmy funkcje serwera takie jak narzędzia, prompt i zasoby.

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

Oto jak można dodać narzędzie. To konkretne narzędzie tworzy narzędzie o nazwie "random-joke", które wywołuje API Chucka Norrisa i zwraca odpowiedź w formacie JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Teraz twój serwer ma jedno narzędzie.

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

1. Najpierw stwórzmy kilka narzędzi, do tego utworzymy plik *Tools.cs* z następującą zawartością:

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

  Tutaj dodaliśmy:

  - Utworzyliśmy klasę `Tools` z dekoratorem `McpServerToolType`.
  - Zdefiniowaliśmy narzędzie `AddNumbers`, dekorując metodę `McpServerTool`. Podaliśmy też parametry i implementację.

1. Wykorzystajmy klasę `Tools`, którą właśnie stworzyliśmy:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Dodaliśmy wywołanie `WithTools`, które wskazuje klasę `Tools` jako zawierającą narzędzia. To wszystko, jesteśmy gotowi.

Świetnie, mamy serwer korzystający z SSE, wypróbujmy go teraz.

## Ćwiczenie: Debugowanie serwera SSE za pomocą Inspektora

Inspector to świetne narzędzie, które poznaliśmy w poprzedniej lekcji [Tworzenie pierwszego serwera](/03-GettingStarted/01-first-server/README.md). Sprawdźmy, czy możemy go użyć także tutaj:

### -1- Uruchamianie inspektora

Aby uruchomić inspektora, najpierw musisz mieć działający serwer SSE, więc zróbmy to teraz:

1. Uruchom serwer

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Zwróć uwagę, że używamy wykonywalnego pliku `uvicorn`, który jest instalowany po wpisaniu `pip install "mcp[cli]"`. Wpisanie `server:app` oznacza, że próbujemy uruchomić plik `server.py`, który zawiera instancję Starlette o nazwie `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    To powinno uruchomić serwer. Aby się z nim komunikować, potrzebujesz nowego terminala.

1. Uruchom inspektora

    > ![NOTE]
    > Uruchom to w osobnym oknie terminala niż ten, w którym działa serwer. Pamiętaj też, aby dostosować poniższe polecenie do URL, pod którym działa twój serwer.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Uruchamianie inspektora wygląda tak samo we wszystkich środowiskach. Zauważ, że zamiast podawać ścieżkę do serwera i polecenie uruchomienia serwera, podajemy URL, pod którym działa serwer, oraz określamy trasę `/sse`.

### -2- Wypróbowanie narzędzia

Połącz się z serwerem, wybierając SSE z listy rozwijanej i wpisz adres URL, pod którym działa twój serwer, na przykład http:localhost:4321/sse. Następnie kliknij przycisk "Connect". Jak wcześniej, wybierz listę narzędzi, wybierz narzędzie i podaj wartości wejściowe. Powinieneś zobaczyć wynik podobny do poniższego:

![Serwer SSE działający w inspektorze](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pl.png)

Świetnie, możesz pracować z inspektorem, zobaczmy teraz, jak pracować z Visual Studio Code.

## Zadanie

Spróbuj rozbudować swój serwer o więcej funkcji. Zobacz [tę stronę](https://api.chucknorris.io/), aby na przykład dodać narzędzie wywołujące API. To ty decydujesz, jak ma wyglądać serwer. Powodzenia :)

## Rozwiązanie

[Rozwiązanie](./solution/README.md) Oto możliwe rozwiązanie z działającym kodem.

## Najważniejsze wnioski

Najważniejsze wnioski z tego rozdziału to:

- SSE to drugi obsługiwany transport obok stdio.
- Aby obsłużyć SSE, musisz zarządzać przychodzącymi połączeniami i wiadomościami za pomocą frameworka webowego.
- Możesz używać zarówno Inspektora, jak i Visual Studio Code do korzystania z serwera SSE, tak jak z serwerami stdio. Zauważ, że różni się to nieco między stdio a SSE. W przypadku SSE musisz najpierw uruchomić serwer osobno, a potem uruchomić narzędzie inspektora. W przypadku inspektora jest też różnica, że musisz podać URL.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dalej

- Następne: [HTTP Streaming z MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.