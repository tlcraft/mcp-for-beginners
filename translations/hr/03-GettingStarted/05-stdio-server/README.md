<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:48:39+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "hr"
}
-->
# MCP Server s stdio transportom

> **⚠️ Važna obavijest**: Od MCP specifikacije 2025-06-18, samostalni SSE (Server-Sent Events) transport je **zastarjeo** i zamijenjen "Streamable HTTP" transportom. Trenutna MCP specifikacija definira dva glavna transportna mehanizma:
> 1. **stdio** - Standardni ulaz/izlaz (preporučeno za lokalne servere)
> 2. **Streamable HTTP** - Za udaljene servere koji mogu interno koristiti SSE
>
> Ova lekcija je ažurirana kako bi se fokusirala na **stdio transport**, koji je preporučeni pristup za većinu MCP server implementacija.

Stdio transport omogućuje MCP serverima komunikaciju s klijentima putem standardnih ulaznih i izlaznih tokova. Ovo je najčešće korišten i preporučen transportni mehanizam u trenutnoj MCP specifikaciji, pružajući jednostavan i učinkovit način za izgradnju MCP servera koji se lako integriraju s raznim klijentskim aplikacijama.

## Pregled

Ova lekcija pokriva kako izgraditi i koristiti MCP servere koristeći stdio transport.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- Izgraditi MCP server koristeći stdio transport.
- Otkloniti pogreške na MCP serveru koristeći Inspector.
- Koristiti MCP server putem Visual Studio Code-a.
- Razumjeti trenutne MCP transportne mehanizme i zašto je stdio preporučen.

## stdio transport - Kako funkcionira

Stdio transport je jedan od dva podržana transportna tipa u trenutnoj MCP specifikaciji (2025-06-18). Evo kako funkcionira:

- **Jednostavna komunikacija**: Server čita JSON-RPC poruke sa standardnog ulaza (`stdin`) i šalje poruke na standardni izlaz (`stdout`).
- **Procesno baziran**: Klijent pokreće MCP server kao podproces.
- **Format poruka**: Poruke su pojedinačni JSON-RPC zahtjevi, obavijesti ili odgovori, odvojeni novim redovima.
- **Logiranje**: Server MOŽE zapisivati UTF-8 stringove na standardnu grešku (`stderr`) za potrebe logiranja.

### Ključni zahtjevi:
- Poruke MORAJU biti odvojene novim redovima i NE SMIJU sadržavati ugrađene nove redove.
- Server NE SMIJE zapisivati ništa na `stdout` što nije valjana MCP poruka.
- Klijent NE SMIJE zapisivati ništa na `stdin` servera što nije valjana MCP poruka.

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

U prethodnom kodu:

- Uvozimo `Server` klasu i `StdioServerTransport` iz MCP SDK-a.
- Kreiramo instancu servera s osnovnom konfiguracijom i mogućnostima.

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

U prethodnom kodu:

- Kreiramo instancu servera koristeći MCP SDK.
- Definiramo alate koristeći dekoratore.
- Koristimo stdio_server kontekstni menadžer za upravljanje transportom.

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

Ključna razlika u odnosu na SSE je da stdio serveri:

- Ne zahtijevaju postavljanje web servera ili HTTP krajnjih točaka.
- Pokreću se kao podprocesi od strane klijenta.
- Komuniciraju putem stdin/stdout tokova.
- Jednostavniji su za implementaciju i otklanjanje pogrešaka.

## Vježba: Kreiranje stdio servera

Za kreiranje našeg servera, trebamo imati na umu dvije stvari:

- Trebamo koristiti web server za izlaganje krajnjih točaka za povezivanje i poruke.

## Laboratorij: Kreiranje jednostavnog MCP stdio servera

U ovom laboratoriju, kreirat ćemo jednostavan MCP server koristeći preporučeni stdio transport. Ovaj server će izlagati alate koje klijenti mogu pozivati koristeći standardni Model Context Protocol.

### Preduvjeti

- Python 3.8 ili noviji
- MCP Python SDK: `pip install mcp`
- Osnovno razumijevanje asinhronog programiranja

Krenimo s kreiranjem našeg prvog MCP stdio servera:

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

## Ključne razlike u odnosu na zastarjeli SSE pristup

**Stdio transport (trenutni standard):**
- Jednostavan model podprocesa - klijent pokreće server kao podproces.
- Komunikacija putem stdin/stdout koristeći JSON-RPC poruke.
- Nema potrebe za postavljanjem HTTP servera.
- Bolje performanse i sigurnost.
- Jednostavnije otklanjanje pogrešaka i razvoj.

**SSE transport (zastarjelo od MCP 2025-06-18):**
- Zahtijevao HTTP server s SSE krajnjim točkama.
- Složenije postavljanje s infrastrukturom web servera.
- Dodatni sigurnosni zahtjevi za HTTP krajnje točke.
- Sada zamijenjen Streamable HTTP-om za web scenarije.

### Kreiranje servera sa stdio transportom

Za kreiranje našeg stdio servera, trebamo:

1. **Uvesti potrebne biblioteke** - Trebamo MCP server komponente i stdio transport.
2. **Kreirati instancu servera** - Definirati server s njegovim mogućnostima.
3. **Definirati alate** - Dodati funkcionalnosti koje želimo izložiti.
4. **Postaviti transport** - Konfigurirati stdio komunikaciju.
5. **Pokrenuti server** - Pokrenuti server i upravljati porukama.

Krenimo korak po korak:

### Korak 1: Kreiranje osnovnog stdio servera

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

### Korak 2: Dodavanje više alata

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

### Korak 3: Pokretanje servera

Spremite kod kao `server.py` i pokrenite ga iz komandne linije:

```bash
python server.py
```

Server će se pokrenuti i čekati unos sa stdin-a. Komunicira koristeći JSON-RPC poruke putem stdio transporta.

### Korak 4: Testiranje s Inspectorom

Možete testirati svoj server koristeći MCP Inspector:

1. Instalirajte Inspector: `npx @modelcontextprotocol/inspector`
2. Pokrenite Inspector i povežite ga sa svojim serverom.
3. Testirajte alate koje ste kreirali.

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

// Dodavanje alata
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Dobijte personalizirani pozdrav",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Ime osobe za pozdrav",
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
          text: `Pozdrav, ${request.params.arguments?.name}! Dobrodošli na MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Nepoznat alat: ${request.params.name}`);
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
    [Description("Dobijte personalizirani pozdrav")]
    public string GetGreeting(string name)
    {
        return $"Pozdrav, {name}! Dobrodošli na MCP stdio server.";
    }

    [Description("Izračunajte zbroj dvaju brojeva")]
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

1. Prvo kreirajmo alate. Za to ćemo kreirati datoteku *Tools.cs* sa sljedećim sadržajem:

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

2. **Otvorite web sučelje**: Inspector će otvoriti prozor preglednika s prikazom mogućnosti vašeg servera.

3. **Testirajte alate**: 
   - Isprobajte alat `get_greeting` s različitim imenima.
   - Testirajte alat `calculate_sum` s raznim brojevima.
   - Pozovite alat `get_server_info` za prikaz metapodataka servera.

4. **Pratite komunikaciju**: Inspector prikazuje JSON-RPC poruke koje se razmjenjuju između klijenta i servera.

### Što biste trebali vidjeti

Kada vaš server ispravno započne, trebali biste vidjeti:
- Popis mogućnosti servera u Inspectoru.
- Alate dostupne za testiranje.
- Uspješne razmjene JSON-RPC poruka.
- Odgovore alata prikazane u sučelju.

### Uobičajeni problemi i rješenja

**Server se ne pokreće:**
- Provjerite jesu li sve ovisnosti instalirane: `pip install mcp`.
- Provjerite Python sintaksu i uvlačenje.
- Pogledajte poruke o pogreškama u konzoli.

**Alati se ne pojavljuju:**
- Provjerite jesu li prisutni `@server.tool()` dekoratori.
- Provjerite jesu li funkcije alata definirane prije `main()`.
- Provjerite je li server ispravno konfiguriran.

**Problemi s povezivanjem:**
- Provjerite koristi li server ispravno stdio transport.
- Provjerite da li drugi procesi ne ometaju rad.
- Provjerite sintaksu naredbe za Inspector.

## Zadaci

Pokušajte proširiti svoj server s više mogućnosti. Pogledajte [ovu stranicu](https://api.chucknorris.io/) kako biste, na primjer, dodali alat koji poziva API. Sami odlučite kako će server izgledati. Zabavite se :)

## Rješenje

[Rješenje](./solution/README.md) Evo mogućeg rješenja s ispravnim kodom.

## Ključne točke

Ključne točke iz ovog poglavlja su sljedeće:

- Stdio transport je preporučeni mehanizam za lokalne MCP servere.
- Stdio transport omogućuje besprijekornu komunikaciju između MCP servera i klijenata koristeći standardne ulazne i izlazne tokove.
- Možete koristiti i Inspector i Visual Studio Code za direktno korištenje stdio servera, što olakšava otklanjanje pogrešaka i integraciju.

## Primjeri 

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python) 

## Dodatni resursi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Što slijedi

## Sljedeći koraci

Sada kada ste naučili kako izgraditi MCP servere sa stdio transportom, možete istražiti naprednije teme:

- **Sljedeće**: [HTTP Streaming s MCP-om (Streamable HTTP)](../06-http-streaming/README.md) - Naučite o drugom podržanom transportnom mehanizmu za udaljene servere.
- **Napredno**: [Najbolje sigurnosne prakse za MCP](../../02-Security/README.md) - Implementirajte sigurnost u svoje MCP servere.
- **Produkcija**: [Strategije implementacije](../09-deployment/README.md) - Implementirajte svoje servere za produkcijsku upotrebu.

## Dodatni resursi

- [MCP Specifikacija 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Službena specifikacija.
- [MCP SDK Dokumentacija](https://github.com/modelcontextprotocol/sdk) - SDK reference za sve jezike.
- [Primjeri iz zajednice](../../06-CommunityContributions/README.md) - Više primjera servera iz zajednice.

---

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane ljudskog prevoditelja. Ne preuzimamo odgovornost za bilo kakve nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.