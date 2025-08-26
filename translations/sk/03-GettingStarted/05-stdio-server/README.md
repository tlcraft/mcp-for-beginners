<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:44:10+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "sk"
}
-->
# MCP Server s transportom stdio

> **⚠️ Dôležitá aktualizácia**: Od špecifikácie MCP z 18. júna 2025 bol samostatný transport SSE (Server-Sent Events) **zastaraný** a nahradený transportom "Streamable HTTP". Aktuálna špecifikácia MCP definuje dva hlavné transportné mechanizmy:
> 1. **stdio** - Štandardný vstup/výstup (odporúčaný pre lokálne servery)
> 2. **Streamable HTTP** - Pre vzdialené servery, ktoré môžu interne používať SSE
>
> Táto lekcia bola aktualizovaná, aby sa zamerala na **transport stdio**, ktorý je odporúčaným prístupom pre väčšinu implementácií MCP serverov.

Transport stdio umožňuje MCP serverom komunikovať s klientmi prostredníctvom štandardných vstupných a výstupných tokov. Ide o najbežnejšie používaný a odporúčaný transportný mechanizmus v aktuálnej špecifikácii MCP, ktorý poskytuje jednoduchý a efektívny spôsob na vytváranie MCP serverov, ktoré sa dajú ľahko integrovať s rôznymi klientskými aplikáciami.

## Prehľad

Táto lekcia pokrýva, ako vytvoriť a používať MCP servery pomocou transportu stdio.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Vytvoriť MCP server pomocou transportu stdio.
- Debugovať MCP server pomocou nástroja Inspector.
- Používať MCP server vo Visual Studio Code.
- Pochopiť aktuálne transportné mechanizmy MCP a dôvody, prečo je stdio odporúčaný.

## Transport stdio - Ako funguje

Transport stdio je jedným z dvoch podporovaných typov transportu v aktuálnej špecifikácii MCP (2025-06-18). Tu je, ako funguje:

- **Jednoduchá komunikácia**: Server číta správy JSON-RPC zo štandardného vstupu (`stdin`) a posiela správy na štandardný výstup (`stdout`).
- **Procesný model**: Klient spúšťa MCP server ako podproces.
- **Formát správ**: Správy sú jednotlivé požiadavky, notifikácie alebo odpovede JSON-RPC, oddelené novými riadkami.
- **Logovanie**: Server MÔŽE zapisovať UTF-8 reťazce na štandardný chybový výstup (`stderr`) na účely logovania.

### Kľúčové požiadavky:
- Správy MUSIA byť oddelené novými riadkami a NESMÚ obsahovať vložené nové riadky.
- Server NESMIE zapisovať na `stdout` nič, čo nie je platná správa MCP.
- Klient NESMIE zapisovať na `stdin` servera nič, čo nie je platná správa MCP.

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

V predchádzajúcom kóde:

- Importujeme triedu `Server` a `StdioServerTransport` z MCP SDK.
- Vytvárame inštanciu servera so základnou konfiguráciou a schopnosťami.

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

V predchádzajúcom kóde:

- Vytvárame inštanciu servera pomocou MCP SDK.
- Definujeme nástroje pomocou dekorátorov.
- Používame kontextový manažér `stdio_server` na spracovanie transportu.

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

Hlavný rozdiel oproti SSE je, že servery stdio:

- Nepotrebujú nastavenie webového servera ani HTTP endpointy.
- Sú spúšťané ako podprocesy klientom.
- Komunikujú prostredníctvom tokov stdin/stdout.
- Sú jednoduchšie na implementáciu a debugovanie.

## Cvičenie: Vytvorenie servera stdio

Na vytvorenie nášho servera musíme mať na pamäti dve veci:

- Musíme použiť webový server na sprístupnenie endpointov pre pripojenie a správy.

## Laboratórium: Vytvorenie jednoduchého MCP servera stdio

V tomto laboratóriu vytvoríme jednoduchý MCP server pomocou odporúčaného transportu stdio. Tento server bude sprístupňovať nástroje, ktoré môžu klienti volať pomocou štandardného protokolu Model Context Protocol.

### Predpoklady

- Python 3.8 alebo novší
- MCP Python SDK: `pip install mcp`
- Základné pochopenie asynchrónneho programovania

Začnime vytvorením nášho prvého MCP servera stdio:

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

## Kľúčové rozdiely oproti zastaranému prístupu SSE

**Transport stdio (aktuálny štandard):**
- Jednoduchý model podprocesov - klient spúšťa server ako podproces.
- Komunikácia cez stdin/stdout pomocou správ JSON-RPC.
- Nie je potrebné nastavenie HTTP servera.
- Lepší výkon a bezpečnosť.
- Jednoduchšie debugovanie a vývoj.

**Transport SSE (zastaraný od MCP 2025-06-18):**
- Vyžadoval HTTP server s endpointmi SSE.
- Komplexnejšie nastavenie s infraštruktúrou webového servera.
- Dodatočné bezpečnostné úvahy pre HTTP endpointy.
- Teraz nahradený Streamable HTTP pre webové scenáre.

### Vytvorenie servera s transportom stdio

Na vytvorenie servera stdio musíme:

1. **Importovať potrebné knižnice** - Potrebujeme komponenty MCP servera a transport stdio.
2. **Vytvoriť inštanciu servera** - Definovať server s jeho schopnosťami.
3. **Definovať nástroje** - Pridať funkcionalitu, ktorú chceme sprístupniť.
4. **Nastaviť transport** - Konfigurovať komunikáciu stdio.
5. **Spustiť server** - Spustiť server a spracovať správy.

Postupujme krok za krokom:

### Krok 1: Vytvorenie základného servera stdio

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

### Krok 2: Pridanie ďalších nástrojov

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

### Krok 3: Spustenie servera

Uložte kód ako `server.py` a spustite ho z príkazového riadku:

```bash
python server.py
```

Server sa spustí a bude čakať na vstup zo stdin. Komunikuje pomocou správ JSON-RPC cez transport stdio.

### Krok 4: Testovanie pomocou nástroja Inspector

Server môžete otestovať pomocou MCP Inspector:

1. Nainštalujte Inspector: `npx @modelcontextprotocol/inspector`
2. Spustite Inspector a nasmerujte ho na váš server.
3. Otestujte nástroje, ktoré ste vytvorili.

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

// Add tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Get a personalized greeting",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Name of the person to greet",
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
          text: `Hello, ${request.params.arguments?.name}! Welcome to MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Unknown tool: ${request.params.name}`);
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
    [Description("Get a personalized greeting")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Calculate the sum of two numbers")]
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

1. Najprv vytvorme niektoré nástroje. Na tento účel vytvoríme súbor *Tools.cs* s nasledujúcim obsahom:

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

2. **Otvorte webové rozhranie**: Inspector otvorí okno prehliadača, ktoré zobrazí schopnosti vášho servera.

3. **Otestujte nástroje**: 
   - Vyskúšajte nástroj `get_greeting` s rôznymi menami.
   - Otestujte nástroj `calculate_sum` s rôznymi číslami.
   - Zavolajte nástroj `get_server_info`, aby ste videli metadáta servera.

4. **Monitorujte komunikáciu**: Inspector zobrazuje správy JSON-RPC, ktoré sa vymieňajú medzi klientom a serverom.

### Čo by ste mali vidieť

Keď váš server správne začne, mali by ste vidieť:
- Schopnosti servera uvedené v Inspector.
- Nástroje dostupné na testovanie.
- Úspešné výmeny správ JSON-RPC.
- Odpovede nástrojov zobrazené v rozhraní.

### Bežné problémy a riešenia

**Server sa nespustí:**
- Skontrolujte, či sú nainštalované všetky závislosti: `pip install mcp`.
- Overte syntax Pythonu a odsadenie.
- Hľadajte chybové správy v konzole.

**Nástroje sa nezobrazujú:**
- Uistite sa, že sú prítomné dekorátory `@server.tool()`.
- Skontrolujte, či sú funkcie nástrojov definované pred `main()`.
- Overte, že server je správne nakonfigurovaný.

**Problémy s pripojením:**
- Uistite sa, že server správne používa transport stdio.
- Skontrolujte, či žiadne iné procesy nezasahujú.
- Overte syntax príkazu Inspector.

## Zadanie

Skúste rozšíriť svoj server o ďalšie schopnosti. Pozrite si [túto stránku](https://api.chucknorris.io/), aby ste napríklad pridali nástroj, ktorý volá API. Vy rozhodnete, ako by mal server vyzerať. Bavte sa :)

## Riešenie

[Riešenie](./solution/README.md) Tu je možné riešenie s funkčným kódom.

## Kľúčové poznatky

Kľúčové poznatky z tejto kapitoly sú nasledujúce:

- Transport stdio je odporúčaný mechanizmus pre lokálne MCP servery.
- Transport stdio umožňuje bezproblémovú komunikáciu medzi MCP servermi a klientmi pomocou štandardných vstupných a výstupných tokov.
- Môžete priamo používať Inspector a Visual Studio Code na konzumáciu serverov stdio, čo uľahčuje debugovanie a integráciu.

## Príklady 

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python) 

## Dodatočné zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Čo ďalej

## Ďalšie kroky

Teraz, keď ste sa naučili, ako vytvárať MCP servery s transportom stdio, môžete preskúmať pokročilejšie témy:

- **Ďalej**: [HTTP Streaming s MCP (Streamable HTTP)](../06-http-streaming/README.md) - Naučte sa o druhom podporovanom transportnom mechanizme pre vzdialené servery.
- **Pokročilé**: [Najlepšie bezpečnostné praktiky MCP](../../02-Security/README.md) - Implementujte bezpečnosť vo svojich MCP serveroch.
- **Produkcia**: [Stratégie nasadenia](../09-deployment/README.md) - Nasadzujte svoje servery na produkčné použitie.

## Dodatočné zdroje

- [Špecifikácia MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Oficiálna špecifikácia.
- [Dokumentácia MCP SDK](https://github.com/modelcontextprotocol/sdk) - Referencie SDK pre všetky jazyky.
- [Príklady komunity](../../06-CommunityContributions/README.md) - Viac príkladov serverov od komunity.

---

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.