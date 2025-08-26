<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:35:55+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "no"
}
-->
# MCP-server med stdio-transport

> **⚠️ Viktig oppdatering**: Fra og med MCP-spesifikasjonen 2025-06-18 er den frittstående SSE (Server-Sent Events)-transporten **utdatert** og erstattet av "Streamable HTTP"-transport. Den nåværende MCP-spesifikasjonen definerer to primære transportmekanismer:
> 1. **stdio** - Standard input/output (anbefalt for lokale servere)
> 2. **Streamable HTTP** - For eksterne servere som kan bruke SSE internt
>
> Denne leksjonen er oppdatert for å fokusere på **stdio-transport**, som er den anbefalte tilnærmingen for de fleste MCP-serverimplementasjoner.

Stdio-transporten lar MCP-servere kommunisere med klienter gjennom standard input- og output-strømmer. Dette er den mest brukte og anbefalte transportmekanismen i den nåværende MCP-spesifikasjonen, og gir en enkel og effektiv måte å bygge MCP-servere som enkelt kan integreres med ulike klientapplikasjoner.

## Oversikt

Denne leksjonen dekker hvordan man bygger og bruker MCP-servere med stdio-transport.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Bygge en MCP-server ved hjelp av stdio-transport.
- Feilsøke en MCP-server ved hjelp av Inspector.
- Bruke en MCP-server med Visual Studio Code.
- Forstå de nåværende MCP-transportmekanismene og hvorfor stdio anbefales.

## Stdio-transport – Hvordan det fungerer

Stdio-transporten er en av to støttede transporttyper i den nåværende MCP-spesifikasjonen (2025-06-18). Slik fungerer det:

- **Enkel kommunikasjon**: Serveren leser JSON-RPC-meldinger fra standard input (`stdin`) og sender meldinger til standard output (`stdout`).
- **Prosessbasert**: Klienten starter MCP-serveren som en underprosess.
- **Meldingsformat**: Meldinger er individuelle JSON-RPC-forespørsler, varsler eller svar, avgrenset med linjeskift.
- **Logging**: Serveren KAN skrive UTF-8-strenger til standard error (`stderr`) for loggingsformål.

### Viktige krav:
- Meldinger MÅ være avgrenset med linjeskift og MÅ IKKE inneholde innebygde linjeskift.
- Serveren MÅ IKKE skrive noe til `stdout` som ikke er en gyldig MCP-melding.
- Klienten MÅ IKKE skrive noe til serverens `stdin` som ikke er en gyldig MCP-melding.

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

I koden ovenfor:

- Importerer vi `Server`-klassen og `StdioServerTransport` fra MCP SDK.
- Oppretter vi en serverinstans med grunnleggende konfigurasjon og funksjonalitet.

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

I koden ovenfor:

- Oppretter vi en serverinstans ved hjelp av MCP SDK.
- Definerer vi verktøy ved hjelp av dekoratorer.
- Bruker vi stdio_server-konteksthåndtereren for å håndtere transporten.

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

Den viktigste forskjellen fra SSE er at stdio-servere:

- Krever ikke oppsett av webserver eller HTTP-endepunkter.
- Startes som underprosesser av klienten.
- Kommuniserer gjennom stdin/stdout-strømmer.
- Er enklere å implementere og feilsøke.

## Øvelse: Lage en stdio-server

For å lage vår server må vi huske to ting:

- Vi må bruke en webserver for å eksponere endepunkter for tilkobling og meldinger.

## Lab: Lage en enkel MCP-stdio-server

I denne laben skal vi lage en enkel MCP-server ved hjelp av den anbefalte stdio-transporten. Denne serveren vil eksponere verktøy som klienter kan kalle ved hjelp av den standardiserte Model Context Protocol.

### Forutsetninger

- Python 3.8 eller nyere
- MCP Python SDK: `pip install mcp`
- Grunnleggende forståelse av asynkron programmering

La oss starte med å lage vår første MCP-stdio-server:

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

## Viktige forskjeller fra den utgåtte SSE-tilnærmingen

**Stdio-transport (nåværende standard):**
- Enkel underprosessmodell – klienten starter serveren som en underprosess.
- Kommunikasjon via stdin/stdout ved bruk av JSON-RPC-meldinger.
- Krever ikke oppsett av HTTP-server.
- Bedre ytelse og sikkerhet.
- Enklere feilsøking og utvikling.

**SSE-transport (utgått fra MCP 2025-06-18):**
- Krevde HTTP-server med SSE-endepunkter.
- Mer komplisert oppsett med webserverinfrastruktur.
- Ekstra sikkerhetsvurderinger for HTTP-endepunkter.
- Nå erstattet av Streamable HTTP for webbaserte scenarier.

### Lage en server med stdio-transport

For å lage vår stdio-server må vi:

1. **Importere nødvendige biblioteker** – Vi trenger MCP-serverkomponentene og stdio-transporten.
2. **Opprette en serverinstans** – Definere serveren med dens funksjonalitet.
3. **Definere verktøy** – Legge til funksjonaliteten vi vil eksponere.
4. **Sette opp transporten** – Konfigurere stdio-kommunikasjon.
5. **Kjøre serveren** – Starte serveren og håndtere meldinger.

La oss bygge dette steg for steg:

### Steg 1: Lage en grunnleggende stdio-server

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

### Steg 2: Legge til flere verktøy

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

### Steg 3: Kjøre serveren

Lagre koden som `server.py` og kjør den fra kommandolinjen:

```bash
python server.py
```

Serveren vil starte og vente på input fra stdin. Den kommuniserer ved hjelp av JSON-RPC-meldinger over stdio-transporten.

### Steg 4: Testing med Inspector

Du kan teste serveren din ved hjelp av MCP Inspector:

1. Installer Inspector: `npx @modelcontextprotocol/inspector`
2. Kjør Inspector og pek den til serveren din.
3. Test verktøyene du har laget.

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

// Legg til verktøy
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Få en personlig hilsen",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Navnet på personen som skal hilses",
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
          text: `Hei, ${request.params.arguments?.name}! Velkommen til MCP-stdio-serveren.`,
        },
      ],
    };
  } else {
    throw new Error(`Ukjent verktøy: ${request.params.name}`);
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
    [Description("Få en personlig hilsen")]
    public string GetGreeting(string name)
    {
        return $"Hei, {name}! Velkommen til MCP-stdio-serveren.";
    }

    [Description("Beregn summen av to tall")]
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

1. La oss først lage noen verktøy. For dette lager vi en fil *Tools.cs* med følgende innhold:

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

2. **Åpne webgrensesnittet**: Inspector vil åpne et nettleservindu som viser serverens funksjonalitet.

3. **Test verktøyene**: 
   - Prøv `get_greeting`-verktøyet med ulike navn.
   - Test `calculate_sum`-verktøyet med forskjellige tall.
   - Kall `get_server_info`-verktøyet for å se servermetadata.

4. **Overvåk kommunikasjonen**: Inspector viser JSON-RPC-meldingene som utveksles mellom klient og server.

### Hva du bør se

Når serveren din starter riktig, bør du se:
- Serverens funksjonalitet listet opp i Inspector.
- Verktøy tilgjengelige for testing.
- Vellykkede JSON-RPC-meldingsutvekslinger.
- Verktøysvar vist i grensesnittet.

### Vanlige problemer og løsninger

**Serveren starter ikke:**
- Sjekk at alle avhengigheter er installert: `pip install mcp`.
- Verifiser Python-syntaks og innrykk.
- Se etter feilmeldinger i konsollen.

**Verktøy vises ikke:**
- Sørg for at `@server.tool()`-dekoratorer er til stede.
- Sjekk at verktøyfunksjoner er definert før `main()`.
- Verifiser at serveren er riktig konfigurert.

**Tilkoblingsproblemer:**
- Sørg for at serveren bruker stdio-transport riktig.
- Sjekk at ingen andre prosesser forstyrrer.
- Verifiser Inspector-kommandoens syntaks.

## Oppgave

Prøv å utvide serveren din med flere funksjoner. Se [denne siden](https://api.chucknorris.io/) for eksempel for å legge til et verktøy som kaller en API. Du bestemmer hvordan serveren skal se ut. Ha det gøy :)

## Løsning

[Løsning](./solution/README.md) Her er en mulig løsning med fungerende kode.

## Viktige punkter

De viktigste punktene fra dette kapittelet er følgende:

- Stdio-transport er den anbefalte mekanismen for lokale MCP-servere.
- Stdio-transport muliggjør sømløs kommunikasjon mellom MCP-servere og klienter ved bruk av standard input- og output-strømmer.
- Du kan bruke både Inspector og Visual Studio Code til å bruke stdio-servere direkte, noe som gjør feilsøking og integrasjon enkelt.

## Eksempler 

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python) 

## Tilleggsressurser

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Hva nå?

## Neste steg

Nå som du har lært hvordan du bygger MCP-servere med stdio-transport, kan du utforske mer avanserte emner:

- **Neste**: [HTTP Streaming med MCP (Streamable HTTP)](../06-http-streaming/README.md) - Lær om den andre støttede transportmekanismen for eksterne servere.
- **Avansert**: [MCP Sikkerhetspraksis](../../02-Security/README.md) - Implementer sikkerhet i MCP-serverne dine.
- **Produksjon**: [Distribusjonsstrategier](../09-deployment/README.md) - Distribuer serverne dine for produksjonsbruk.

## Tilleggsressurser

- [MCP-spesifikasjon 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Offisiell spesifikasjon.
- [MCP SDK-dokumentasjon](https://github.com/modelcontextprotocol/sdk) - SDK-referanser for alle språk.
- [Eksempler fra fellesskapet](../../06-CommunityContributions/README.md) - Flere servereksempler fra fellesskapet.

---

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.