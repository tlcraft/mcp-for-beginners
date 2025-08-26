<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:31:59+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "pl"
}
-->
# MCP Serwer z transportem stdio

> **⚠️ Ważna aktualizacja**: Od wersji specyfikacji MCP z dnia 2025-06-18, samodzielny transport SSE (Server-Sent Events) został **wycofany** i zastąpiony transportem "Streamable HTTP". Obecna specyfikacja MCP definiuje dwa główne mechanizmy transportu:
> 1. **stdio** - Standardowe wejście/wyjście (zalecane dla lokalnych serwerów)
> 2. **Streamable HTTP** - Dla zdalnych serwerów, które mogą wewnętrznie korzystać z SSE
>
> Ta lekcja została zaktualizowana, aby skupić się na **transporcie stdio**, który jest zalecanym podejściem dla większości implementacji serwerów MCP.

Transport stdio umożliwia serwerom MCP komunikację z klientami za pomocą standardowych strumieni wejścia i wyjścia. Jest to najczęściej używany i zalecany mechanizm transportu w obecnej specyfikacji MCP, zapewniający prosty i efektywny sposób budowania serwerów MCP, które można łatwo zintegrować z różnymi aplikacjami klienckimi.

## Przegląd

Ta lekcja omawia, jak budować i korzystać z serwerów MCP za pomocą transportu stdio.

## Cele nauki

Po ukończeniu tej lekcji będziesz w stanie:

- Zbudować serwer MCP korzystający z transportu stdio.
- Debugować serwer MCP za pomocą Inspektora.
- Korzystać z serwera MCP w Visual Studio Code.
- Zrozumieć obecne mechanizmy transportu MCP i dlaczego stdio jest zalecane.

## Transport stdio - Jak to działa

Transport stdio jest jednym z dwóch obsługiwanych typów transportu w obecnej specyfikacji MCP (2025-06-18). Oto jak działa:

- **Prosta komunikacja**: Serwer odczytuje wiadomości JSON-RPC ze standardowego wejścia (`stdin`) i wysyła wiadomości na standardowe wyjście (`stdout`).
- **Procesowy model**: Klient uruchamia serwer MCP jako podproces.
- **Format wiadomości**: Wiadomości to pojedyncze żądania, powiadomienia lub odpowiedzi JSON-RPC, oddzielone znakami nowej linii.
- **Logowanie**: Serwer MOŻE zapisywać ciągi UTF-8 na standardowe wyjście błędów (`stderr`) w celu logowania.

### Kluczowe wymagania:
- Wiadomości MUSZĄ być oddzielone znakami nowej linii i NIE MOGĄ zawierać wbudowanych znaków nowej linii.
- Serwer NIE MOŻE zapisywać niczego na `stdout`, co nie jest prawidłową wiadomością MCP.
- Klient NIE MOŻE zapisywać niczego na `stdin` serwera, co nie jest prawidłową wiadomością MCP.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

W powyższym kodzie:

- Importujemy klasę `Server` i `StdioServerTransport` z MCP SDK.
- Tworzymy instancję serwera z podstawową konfiguracją i możliwościami.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

W powyższym kodzie:

- Tworzymy instancję serwera za pomocą MCP SDK.
- Definiujemy narzędzia za pomocą dekoratorów.
- Używamy kontekstu `stdio_server`, aby obsłużyć transport.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

Kluczowa różnica w stosunku do SSE polega na tym, że serwery stdio:

- Nie wymagają konfiguracji serwera WWW ani punktów końcowych HTTP.
- Są uruchamiane jako podprocesy przez klienta.
- Komunikują się za pomocą strumieni stdin/stdout.
- Są prostsze w implementacji i debugowaniu.

## Ćwiczenie: Tworzenie serwera stdio

Aby stworzyć nasz serwer, musimy pamiętać o dwóch rzeczach:

- Musimy użyć serwera WWW do udostępnienia punktów końcowych dla połączeń i wiadomości.

## Laboratorium: Tworzenie prostego serwera MCP stdio

W tym laboratorium stworzymy prosty serwer MCP korzystający z zalecanego transportu stdio. Ten serwer udostępni narzędzia, które klienci mogą wywoływać za pomocą standardowego protokołu Model Context Protocol.

### Wymagania wstępne

- Python 3.8 lub nowszy
- MCP Python SDK: `pip install mcp`
- Podstawowa znajomość programowania asynchronicznego

Zacznijmy od stworzenia naszego pierwszego serwera MCP stdio:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Kluczowe różnice w stosunku do wycofanego podejścia SSE

**Transport stdio (obecny standard):**
- Prosty model podprocesów - klient uruchamia serwer jako proces potomny.
- Komunikacja za pomocą stdin/stdout przy użyciu wiadomości JSON-RPC.
- Brak wymogu konfiguracji serwera HTTP.
- Lepsza wydajność i bezpieczeństwo.
- Łatwiejsze debugowanie i rozwój.

**Transport SSE (wycofany od MCP 2025-06-18):**
- Wymagał serwera HTTP z punktami końcowymi SSE.
- Bardziej skomplikowana konfiguracja z infrastrukturą serwera WWW.
- Dodatkowe kwestie bezpieczeństwa dla punktów końcowych HTTP.
- Zastąpiony przez Streamable HTTP dla scenariuszy opartych na sieci.

### Tworzenie serwera z transportem stdio

Aby stworzyć nasz serwer stdio, musimy:

1. **Zaimportować wymagane biblioteki** - Potrzebujemy komponentów serwera MCP i transportu stdio.
2. **Stworzyć instancję serwera** - Zdefiniować serwer z jego możliwościami.
3. **Zdefiniować narzędzia** - Dodać funkcjonalności, które chcemy udostępnić.
4. **Skonfigurować transport** - Ustawić komunikację stdio.
5. **Uruchomić serwer** - Wystartować serwer i obsłużyć wiadomości.

Zbudujmy to krok po kroku:

### Krok 1: Stwórz podstawowy serwer stdio

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Krok 2: Dodaj więcej narzędzi

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Krok 3: Uruchom serwer

Zapisz kod jako `server.py` i uruchom go z wiersza poleceń:

```bash
python server.py
```

Serwer uruchomi się i będzie oczekiwał na dane wejściowe ze stdin. Komunikuje się za pomocą wiadomości JSON-RPC przez transport stdio.

### Krok 4: Testowanie za pomocą Inspektora

Możesz przetestować swój serwer za pomocą MCP Inspector:

1. Zainstaluj Inspektora: `npx @modelcontextprotocol/inspector`
2. Uruchom Inspektora i wskaż go na swój serwer.
3. Przetestuj narzędzia, które stworzyłeś.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Dodaj narzędzia
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Uzyskaj spersonalizowane powitanie",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Imię osoby, którą chcesz powitać",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Cześć, ${request.params.arguments?.name}! Witamy na serwerze MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Nieznane narzędzie: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Uzyskaj spersonalizowane powitanie")]
    public string GetGreeting(string name)
    {
        return $"Cześć, {name}! Witamy na serwerze MCP stdio.";
    }

    [Description("Oblicz sumę dwóch liczb")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. Najpierw stwórzmy kilka narzędzi, w tym celu utworzymy plik *Tools.cs* z następującą zawartością:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **Otwórz interfejs webowy**: Inspektor otworzy okno przeglądarki pokazujące możliwości Twojego serwera.

3. **Przetestuj narzędzia**: 
   - Wypróbuj narzędzie `get_greeting` z różnymi imionami.
   - Przetestuj narzędzie `calculate_sum` z różnymi liczbami.
   - Wywołaj narzędzie `get_server_info`, aby zobaczyć metadane serwera.

4. **Monitoruj komunikację**: Inspektor pokazuje wiadomości JSON-RPC wymieniane między klientem a serwerem.

### Co powinieneś zobaczyć

Gdy Twój serwer uruchomi się poprawnie, powinieneś zobaczyć:
- Możliwości serwera wymienione w Inspektorze.
- Narzędzia dostępne do testowania.
- Udane wymiany wiadomości JSON-RPC.
- Odpowiedzi narzędzi wyświetlane w interfejsie.

### Typowe problemy i rozwiązania

**Serwer nie uruchamia się:**
- Sprawdź, czy wszystkie zależności są zainstalowane: `pip install mcp`.
- Zweryfikuj składnię Pythona i wcięcia.
- Poszukaj komunikatów o błędach w konsoli.

**Narzędzia nie pojawiają się:**
- Upewnij się, że dekoratory `@server.tool()` są obecne.
- Sprawdź, czy funkcje narzędzi są zdefiniowane przed `main()`.
- Zweryfikuj, czy serwer jest poprawnie skonfigurowany.

**Problemy z połączeniem:**
- Upewnij się, że serwer poprawnie korzysta z transportu stdio.
- Sprawdź, czy inne procesy nie zakłócają działania.
- Zweryfikuj składnię polecenia Inspektora.

## Zadanie

Spróbuj rozbudować swój serwer o dodatkowe możliwości. Zobacz [tę stronę](https://api.chucknorris.io/), aby na przykład dodać narzędzie, które wywołuje API. Ty decydujesz, jak ma wyglądać serwer. Powodzenia :)

## Rozwiązanie

[Rozwiązanie](./solution/README.md) Oto możliwe rozwiązanie z działającym kodem.

## Kluczowe wnioski

Kluczowe wnioski z tego rozdziału to:

- Transport stdio jest zalecanym mechanizmem dla lokalnych serwerów MCP.
- Transport stdio umożliwia płynną komunikację między serwerami MCP a klientami za pomocą standardowych strumieni wejścia i wyjścia.
- Możesz używać zarówno Inspektora, jak i Visual Studio Code do bezpośredniego korzystania z serwerów stdio, co ułatwia debugowanie i integrację.

## Przykłady 

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python) 

## Dodatkowe zasoby

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dalej

## Kolejne kroki

Teraz, gdy nauczyłeś się budować serwery MCP z transportem stdio, możesz zgłębić bardziej zaawansowane tematy:

- **Następne**: [HTTP Streaming z MCP (Streamable HTTP)](../06-http-streaming/README.md) - Dowiedz się o drugim obsługiwanym mechanizmie transportu dla zdalnych serwerów.
- **Zaawansowane**: [Najlepsze praktyki bezpieczeństwa MCP](../../02-Security/README.md) - Zaimplementuj bezpieczeństwo w swoich serwerach MCP.
- **Produkcja**: [Strategie wdrażania](../09-deployment/README.md) - Wdrażaj swoje serwery do użytku produkcyjnego.

## Dodatkowe zasoby

- [Specyfikacja MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Oficjalna specyfikacja.
- [Dokumentacja MCP SDK](https://github.com/modelcontextprotocol/sdk) - Odniesienia do SDK dla wszystkich języków.
- [Przykłady społeczności](../../06-CommunityContributions/README.md) - Więcej przykładów serwerów od społeczności.

---

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.