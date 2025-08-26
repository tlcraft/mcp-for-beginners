<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:54:24+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "sl"
}
-->
# MCP strežnik s stdio transportom

> **⚠️ Pomembna posodobitev**: Od MCP specifikacije 2025-06-18 je samostojni SSE (Server-Sent Events) transport **opuščen** in nadomeščen s transportom "Streamable HTTP". Trenutna MCP specifikacija opredeljuje dva glavna transportna mehanizma:
> 1. **stdio** - Standardni vhod/izhod (priporočeno za lokalne strežnike)
> 2. **Streamable HTTP** - Za oddaljene strežnike, ki lahko interno uporabljajo SSE
>
> Ta lekcija je posodobljena, da se osredotoča na **stdio transport**, ki je priporočena metoda za večino implementacij MCP strežnikov.

Stdio transport omogoča MCP strežnikom komunikacijo s klienti prek standardnih vhodnih in izhodnih tokov. To je najpogosteje uporabljan in priporočljiv transportni mehanizem v trenutni MCP specifikaciji, saj omogoča preprost in učinkovit način za gradnjo MCP strežnikov, ki jih je mogoče enostavno integrirati z različnimi klientskimi aplikacijami.

## Pregled

Ta lekcija pokriva, kako zgraditi in uporabljati MCP strežnike z uporabo stdio transporta.

## Cilji učenja

Po koncu te lekcije boste znali:

- Zgraditi MCP strežnik z uporabo stdio transporta.
- Odpravljati napake na MCP strežniku z uporabo Inspectorja.
- Uporabljati MCP strežnik v Visual Studio Code.
- Razumeti trenutne MCP transportne mehanizme in zakaj je stdio priporočljiv.

## stdio transport - Kako deluje

Stdio transport je eden od dveh podprtih transportnih tipov v trenutni MCP specifikaciji (2025-06-18). Tukaj je, kako deluje:

- **Preprosta komunikacija**: Strežnik bere JSON-RPC sporočila iz standardnega vhoda (`stdin`) in pošilja sporočila na standardni izhod (`stdout`).
- **Na osnovi procesov**: Klient zažene MCP strežnik kot podproces.
- **Format sporočil**: Sporočila so posamezne JSON-RPC zahteve, obvestila ali odgovori, ločeni z novimi vrsticami.
- **Beleženje**: Strežnik LAHKO piše UTF-8 nize na standardni izhod za napake (`stderr`) za beleženje.

### Ključne zahteve:
- Sporočila MORAJO biti ločena z novimi vrsticami in NE SMEJO vsebovati vgrajenih novih vrstic.
- Strežnik NE SME pisati ničesar na `stdout`, kar ni veljavno MCP sporočilo.
- Klient NE SME pisati ničesar na strežnikov `stdin`, kar ni veljavno MCP sporočilo.

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

V zgornji kodi:

- Uvozimo razreda `Server` in `StdioServerTransport` iz MCP SDK.
- Ustvarimo instanco strežnika z osnovno konfiguracijo in zmožnostmi.

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

V zgornji kodi:

- Ustvarimo instanco strežnika z uporabo MCP SDK.
- Definiramo orodja z uporabo dekoratorjev.
- Uporabimo kontekstni upravitelj `stdio_server` za upravljanje transporta.

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

Ključna razlika od SSE je, da stdio strežniki:

- Ne potrebujejo nastavitve spletnega strežnika ali HTTP končnih točk.
- So zagnani kot podprocesi s strani klienta.
- Komunicirajo prek tokov stdin/stdout.
- So enostavnejši za implementacijo in odpravljanje napak.

## Vaja: Ustvarjanje stdio strežnika

Za ustvarjanje našega strežnika moramo upoštevati dve stvari:

- Uporabiti moramo spletni strežnik za izpostavitev končnih točk za povezavo in sporočila.

## Laboratorijska vaja: Ustvarjanje preprostega MCP stdio strežnika

V tej vaji bomo ustvarili preprost MCP strežnik z uporabo priporočenega stdio transporta. Ta strežnik bo izpostavil orodja, ki jih lahko klienti kličejo z uporabo standardnega Model Context Protocol.

### Predpogoji

- Python 3.8 ali novejši
- MCP Python SDK: `pip install mcp`
- Osnovno razumevanje asinhronega programiranja

Začnimo z ustvarjanjem našega prvega MCP stdio strežnika:

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

## Ključne razlike od opuščenega SSE pristopa

**Stdio transport (trenutni standard):**
- Preprost model podprocesov - klient zažene strežnik kot otroški proces.
- Komunikacija prek stdin/stdout z uporabo JSON-RPC sporočil.
- Ni potrebna nastavitev spletnega strežnika.
- Boljša zmogljivost in varnost.
- Lažje odpravljanje napak in razvoj.

**SSE transport (opuščen od MCP 2025-06-18):**
- Zahteval je spletni strežnik z SSE končnimi točkami.
- Bolj zapletena nastavitev z infrastrukturo spletnega strežnika.
- Dodatni varnostni premisleki za HTTP končne točke.
- Zdaj nadomeščen s Streamable HTTP za spletne scenarije.

### Ustvarjanje strežnika z stdio transportom

Za ustvarjanje našega stdio strežnika moramo:

1. **Uvoziti potrebne knjižnice** - Potrebujemo komponente MCP strežnika in stdio transport.
2. **Ustvariti instanco strežnika** - Definirati strežnik z njegovimi zmožnostmi.
3. **Definirati orodja** - Dodati funkcionalnosti, ki jih želimo izpostaviti.
4. **Nastaviti transport** - Konfigurirati stdio komunikacijo.
5. **Zagnati strežnik** - Začeti strežnik in obdelovati sporočila.

Gradimo to korak za korakom:

### Korak 1: Ustvarjanje osnovnega stdio strežnika

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

### Korak 2: Dodajanje več orodij

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

### Korak 3: Zagon strežnika

Shrani kodo kot `server.py` in jo zaženi iz ukazne vrstice:

```bash
python server.py
```

Strežnik se bo zagnal in čakal na vhod iz stdin. Komunicira z uporabo JSON-RPC sporočil prek stdio transporta.

### Korak 4: Testiranje z Inspectorjem

Svoj strežnik lahko testirate z uporabo MCP Inspectorja:

1. Namestite Inspector: `npx @modelcontextprotocol/inspector`
2. Zaženite Inspector in ga usmerite na svoj strežnik.
3. Testirajte orodja, ki ste jih ustvarili.

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

// Dodajanje orodij
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Pridobi personalizirano pozdravno sporočilo",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Ime osebe, ki jo želite pozdraviti",
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
          text: `Pozdravljeni, ${request.params.arguments?.name}! Dobrodošli na MCP stdio strežniku.`,
        },
      ],
    };
  } else {
    throw new Error(`Neznano orodje: ${request.params.name}`);
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
    [Description("Pridobi personalizirano pozdravno sporočilo")]
    public string GetGreeting(string name)
    {
        return $"Pozdravljeni, {name}! Dobrodošli na MCP stdio strežniku.";
    }

    [Description("Izračunaj vsoto dveh števil")]
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

1. Najprej ustvarimo nekaj orodij. Za to ustvarimo datoteko *Tools.cs* z naslednjo vsebino:

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

2. **Odprite spletni vmesnik**: Inspector bo odprl okno brskalnika, ki prikazuje zmožnosti vašega strežnika.

3. **Testirajte orodja**: 
   - Preizkusite orodje `get_greeting` z različnimi imeni.
   - Testirajte orodje `calculate_sum` z različnimi številkami.
   - Pokličite orodje `get_server_info`, da vidite metapodatke strežnika.

4. **Spremljajte komunikacijo**: Inspector prikazuje JSON-RPC sporočila, ki se izmenjujejo med klientom in strežnikom.

### Kaj bi morali videti

Ko se vaš strežnik pravilno zažene, bi morali videti:
- Zmožnosti strežnika, prikazane v Inspectorju.
- Orodja, ki so na voljo za testiranje.
- Uspešne izmenjave JSON-RPC sporočil.
- Odzive orodij, prikazane v vmesniku.

### Pogoste težave in rešitve

**Strežnik se ne zažene:**
- Preverite, ali so vse odvisnosti nameščene: `pip install mcp`.
- Preverite Python sintakso in zamike.
- Poiščite sporočila o napakah v konzoli.

**Orodja se ne prikažejo:**
- Prepričajte se, da so prisotni dekoratorji `@server.tool()`.
- Preverite, ali so funkcije orodij definirane pred `main()`.
- Preverite, ali je strežnik pravilno konfiguriran.

**Težave s povezavo:**
- Prepričajte se, da strežnik pravilno uporablja stdio transport.
- Preverite, ali drugi procesi ne motijo.
- Preverite sintakso ukaza Inspector.

## Naloga

Poskusite razširiti svoj strežnik z več zmožnostmi. Oglejte si [to stran](https://api.chucknorris.io/) in na primer dodajte orodje, ki kliče API. Sami se odločite, kako naj strežnik izgleda. Zabavajte se :)

## Rešitev

[Rešitev](./solution/README.md) Tukaj je možna rešitev z delujočo kodo.

## Ključne točke

Ključne točke iz tega poglavja so naslednje:

- Stdio transport je priporočeni mehanizem za lokalne MCP strežnike.
- Stdio transport omogoča brezhibno komunikacijo med MCP strežniki in klienti z uporabo standardnih vhodnih in izhodnih tokov.
- Uporabite lahko tako Inspector kot Visual Studio Code za neposredno uporabo stdio strežnikov, kar olajša odpravljanje napak in integracijo.

## Primeri 

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python) 

## Dodatni viri

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Kaj sledi

## Naslednji koraki

Zdaj, ko ste se naučili, kako zgraditi MCP strežnike z stdio transportom, lahko raziščete bolj napredne teme:

- **Naslednje**: [HTTP Streaming z MCP (Streamable HTTP)](../06-http-streaming/README.md) - Naučite se o drugem podprtem transportnem mehanizmu za oddaljene strežnike.
- **Napredno**: [Najboljše prakse za varnost MCP](../../02-Security/README.md) - Implementirajte varnost v svojih MCP strežnikih.
- **Produkcija**: [Strategije uvajanja](../09-deployment/README.md) - Uvedite svoje strežnike za produkcijsko uporabo.

## Dodatni viri

- [MCP Specifikacija 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Uradna specifikacija.
- [MCP SDK Dokumentacija](https://github.com/modelcontextprotocol/sdk) - SDK reference za vse jezike.
- [Primeri skupnosti](../../06-CommunityContributions/README.md) - Več primerov strežnikov iz skupnosti.

---

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo profesionalni človeški prevod. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki bi nastale zaradi uporabe tega prevoda.