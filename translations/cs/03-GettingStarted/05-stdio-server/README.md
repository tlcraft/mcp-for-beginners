<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:43:34+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "cs"
}
-->
# MCP Server s transportem stdio

> **⚠️ Důležitá aktualizace**: Od specifikace MCP 2025-06-18 byl samostatný transport SSE (Server-Sent Events) **zastaralý** a nahrazen transportem "Streamable HTTP". Aktuální specifikace MCP definuje dva hlavní transportní mechanismy:
> 1. **stdio** - Standardní vstup/výstup (doporučeno pro lokální servery)
> 2. **Streamable HTTP** - Pro vzdálené servery, které mohou interně používat SSE
>
> Tato lekce byla aktualizována, aby se zaměřila na **transport stdio**, což je doporučený přístup pro většinu implementací MCP serverů.

Transport stdio umožňuje MCP serverům komunikovat s klienty prostřednictvím standardních vstupních a výstupních proudů. Jedná se o nejčastěji používaný a doporučený transportní mechanismus v aktuální specifikaci MCP, který poskytuje jednoduchý a efektivní způsob, jak vytvářet MCP servery, které lze snadno integrovat s různými klientskými aplikacemi.

## Přehled

Tato lekce se zabývá tím, jak vytvořit a používat MCP servery s transportem stdio.

## Cíle učení

Na konci této lekce budete schopni:

- Vytvořit MCP server s transportem stdio.
- Ladit MCP server pomocí Inspektoru.
- Používat MCP server ve Visual Studio Code.
- Porozumět aktuálním transportním mechanismům MCP a důvodům, proč je stdio doporučeno.

## Transport stdio - Jak funguje

Transport stdio je jedním ze dvou podporovaných typů transportu v aktuální specifikaci MCP (2025-06-18). Zde je, jak funguje:

- **Jednoduchá komunikace**: Server čte zprávy JSON-RPC ze standardního vstupu (`stdin`) a odesílá zprávy na standardní výstup (`stdout`).
- **Procesní model**: Klient spouští MCP server jako podproces.
- **Formát zpráv**: Zprávy jsou jednotlivé požadavky, oznámení nebo odpovědi JSON-RPC, oddělené novými řádky.
- **Logování**: Server MŮŽE zapisovat řetězce UTF-8 na standardní chybu (`stderr`) pro účely logování.

### Klíčové požadavky:
- Zprávy MUSÍ být odděleny novými řádky a NESMÍ obsahovat vložené nové řádky.
- Server NESMÍ zapisovat na `stdout` nic, co není platná zpráva MCP.
- Klient NESMÍ zapisovat na `stdin` serveru nic, co není platná zpráva MCP.

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

V předchozím kódu:

- Importujeme třídu `Server` a `StdioServerTransport` z MCP SDK.
- Vytváříme instanci serveru se základní konfigurací a schopnostmi.

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

V předchozím kódu:

- Vytváříme instanci serveru pomocí MCP SDK.
- Definujeme nástroje pomocí dekorátorů.
- Používáme kontextový manažer stdio_server pro zpracování transportu.

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

Hlavní rozdíl oproti SSE je, že servery stdio:

- Nevyžadují nastavení webového serveru nebo HTTP endpointů.
- Jsou spouštěny jako podprocesy klientem.
- Komunikují prostřednictvím proudů stdin/stdout.
- Jsou jednodušší na implementaci a ladění.

## Cvičení: Vytvoření serveru stdio

Pro vytvoření našeho serveru musíme mít na paměti dvě věci:

- Musíme použít webový server k vystavení endpointů pro připojení a zprávy.

## Laboratoř: Vytvoření jednoduchého MCP serveru stdio

V této laboratoři vytvoříme jednoduchý MCP server pomocí doporučeného transportu stdio. Tento server bude vystavovat nástroje, které mohou klienti volat pomocí standardního protokolu Model Context Protocol.

### Předpoklady

- Python 3.8 nebo novější
- MCP Python SDK: `pip install mcp`
- Základní znalost asynchronního programování

Začněme vytvořením našeho prvního MCP serveru stdio:

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

## Klíčové rozdíly oproti zastaralému přístupu SSE

**Transport stdio (aktuální standard):**
- Jednoduchý model podprocesu - klient spouští server jako podproces.
- Komunikace přes stdin/stdout pomocí zpráv JSON-RPC.
- Není potřeba nastavení HTTP serveru.
- Lepší výkon a bezpečnost.
- Snadnější ladění a vývoj.

**Transport SSE (zastaralý od MCP 2025-06-18):**
- Vyžadoval HTTP server s endpointy SSE.
- Složitější nastavení s infrastrukturou webového serveru.
- Další bezpečnostní úvahy pro HTTP endpointy.
- Nyní nahrazen Streamable HTTP pro webové scénáře.

### Vytvoření serveru s transportem stdio

Pro vytvoření serveru stdio musíme:

1. **Importovat potřebné knihovny** - Potřebujeme komponenty MCP serveru a transport stdio.
2. **Vytvořit instanci serveru** - Definovat server s jeho schopnostmi.
3. **Definovat nástroje** - Přidat funkce, které chceme vystavit.
4. **Nastavit transport** - Konfigurovat komunikaci stdio.
5. **Spustit server** - Spustit server a zpracovávat zprávy.

Postupujme krok za krokem:

### Krok 1: Vytvoření základního serveru stdio

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

### Krok 2: Přidání dalších nástrojů

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

### Krok 3: Spuštění serveru

Uložte kód jako `server.py` a spusťte ho z příkazového řádku:

```bash
python server.py
```

Server se spustí a bude čekat na vstup ze stdin. Komunikuje pomocí zpráv JSON-RPC přes transport stdio.

### Krok 4: Testování pomocí Inspektoru

Můžete otestovat svůj server pomocí MCP Inspektoru:

1. Nainstalujte Inspektor: `npx @modelcontextprotocol/inspector`
2. Spusťte Inspektor a nasměrujte ho na svůj server.
3. Otestujte nástroje, které jste vytvořili.

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

// Přidání nástrojů
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Získat personalizovaný pozdrav",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Jméno osoby, kterou chcete pozdravit",
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
          text: `Ahoj, ${request.params.arguments?.name}! Vítejte na MCP serveru stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Neznámý nástroj: ${request.params.name}`);
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
    [Description("Získat personalizovaný pozdrav")]
    public string GetGreeting(string name)
    {
        return $"Ahoj, {name}! Vítejte na MCP serveru stdio.";
    }

    [Description("Vypočítat součet dvou čísel")]
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

1. Nejprve vytvořme několik nástrojů. Pro tento účel vytvoříme soubor *Tools.cs* s následujícím obsahem:

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

2. **Otevřete webové rozhraní**: Inspektor otevře okno prohlížeče zobrazující schopnosti vašeho serveru.

3. **Otestujte nástroje**: 
   - Vyzkoušejte nástroj `get_greeting` s různými jmény.
   - Otestujte nástroj `calculate_sum` s různými čísly.
   - Zavolejte nástroj `get_server_info`, abyste viděli metadata serveru.

4. **Sledujte komunikaci**: Inspektor zobrazuje zprávy JSON-RPC, které jsou vyměňovány mezi klientem a serverem.

### Co byste měli vidět

Když váš server správně startuje, měli byste vidět:
- Schopnosti serveru uvedené v Inspektoru.
- Nástroje dostupné pro testování.
- Úspěšné výměny zpráv JSON-RPC.
- Odpovědi nástrojů zobrazené v rozhraní.

### Běžné problémy a jejich řešení

**Server se nespustí:**
- Zkontrolujte, zda jsou všechny závislosti nainstalovány: `pip install mcp`.
- Ověřte syntaxi Pythonu a odsazení.
- Hledejte chybové zprávy v konzoli.

**Nástroje se nezobrazují:**
- Ujistěte se, že jsou přítomny dekorátory `@server.tool()`.
- Zkontrolujte, zda jsou funkce nástrojů definovány před `main()`.
- Ověřte, že server je správně nakonfigurován.

**Problémy s připojením:**
- Ujistěte se, že server správně používá transport stdio.
- Zkontrolujte, zda žádné jiné procesy nezasahují.
- Ověřte syntaxi příkazu Inspektoru.

## Úkol

Zkuste rozšířit svůj server o další schopnosti. Podívejte se na [tuto stránku](https://api.chucknorris.io/), například přidejte nástroj, který volá API. Rozhodněte, jak by měl váš server vypadat. Bavte se :)

## Řešení

[Řešení](./solution/README.md) Zde je možné řešení s funkčním kódem.

## Klíčové poznatky

Klíčové poznatky z této kapitoly jsou následující:

- Transport stdio je doporučený mechanismus pro lokální MCP servery.
- Transport stdio umožňuje bezproblémovou komunikaci mezi MCP servery a klienty pomocí standardních vstupních a výstupních proudů.
- Můžete přímo používat Inspektor a Visual Studio Code pro spotřebu serverů stdio, což usnadňuje ladění a integraci.

## Ukázky 

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python) 

## Další zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dál

## Další kroky

Nyní, když jste se naučili, jak vytvářet MCP servery s transportem stdio, můžete prozkoumat pokročilejší témata:

- **Další**: [HTTP Streaming s MCP (Streamable HTTP)](../06-http-streaming/README.md) - Naučte se o druhém podporovaném transportním mechanismu pro vzdálené servery.
- **Pokročilé**: [Nejlepší bezpečnostní praktiky MCP](../../02-Security/README.md) - Implementujte bezpečnost na svých MCP serverech.
- **Produkce**: [Strategie nasazení](../09-deployment/README.md) - Nasazení serverů pro produkční použití.

## Další zdroje

- [Specifikace MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Oficiální specifikace.
- [Dokumentace MCP SDK](https://github.com/modelcontextprotocol/sdk) - Odkazy na SDK pro všechny jazyky.
- [Příklady komunity](../../06-CommunityContributions/README.md) - Další příklady serverů od komunity.

---

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby pro automatizovaný překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro kritické informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádné nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.