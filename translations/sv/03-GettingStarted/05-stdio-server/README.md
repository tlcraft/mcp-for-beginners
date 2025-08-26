<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:34:39+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "sv"
}
-->
# MCP Server med stdio Transport

> **⚠️ Viktig Uppdatering**: Från och med MCP-specifikationen 2025-06-18 har den fristående SSE (Server-Sent Events) transporten **avvecklats** och ersatts av "Streamable HTTP"-transport. Den aktuella MCP-specifikationen definierar två primära transportmekanismer:
> 1. **stdio** - Standard in-/utgång (rekommenderas för lokala servrar)
> 2. **Streamable HTTP** - För fjärrservrar som kan använda SSE internt
>
> Denna lektion har uppdaterats för att fokusera på **stdio transport**, vilket är det rekommenderade tillvägagångssättet för de flesta MCP-serverimplementationer.

Stdio-transporten gör det möjligt för MCP-servrar att kommunicera med klienter via standard in- och utgångsströmmar. Detta är den mest använda och rekommenderade transportmekanismen i den aktuella MCP-specifikationen, vilket ger ett enkelt och effektivt sätt att bygga MCP-servrar som enkelt kan integreras med olika klientapplikationer.

## Översikt

Denna lektion täcker hur man bygger och använder MCP-servrar med stdio transport.

## Lärandemål

Efter denna lektion kommer du att kunna:

- Bygga en MCP-server med stdio transport.
- Felsöka en MCP-server med Inspector.
- Använda en MCP-server med Visual Studio Code.
- Förstå de aktuella MCP-transportmekanismerna och varför stdio rekommenderas.

## stdio Transport - Så fungerar det

Stdio-transporten är en av två stödda transporttyper i den aktuella MCP-specifikationen (2025-06-18). Så här fungerar det:

- **Enkel kommunikation**: Servern läser JSON-RPC-meddelanden från standard in (`stdin`) och skickar meddelanden till standard ut (`stdout`).
- **Processbaserad**: Klienten startar MCP-servern som en underprocess.
- **Meddelandeformat**: Meddelanden är individuella JSON-RPC-förfrågningar, notifieringar eller svar, avgränsade med radbrytningar.
- **Loggning**: Servern KAN skriva UTF-8-strängar till standardfel (`stderr`) för loggningsändamål.

### Viktiga krav:
- Meddelanden MÅSTE avgränsas med radbrytningar och FÅR INTE innehålla inbäddade radbrytningar.
- Servern FÅR INTE skriva något till `stdout` som inte är ett giltigt MCP-meddelande.
- Klienten FÅR INTE skriva något till serverns `stdin` som inte är ett giltigt MCP-meddelande.

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

I den föregående koden:

- Vi importerar `Server`-klassen och `StdioServerTransport` från MCP SDK.
- Vi skapar en serverinstans med grundläggande konfiguration och funktioner.

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

I den föregående koden:

- Vi skapar en serverinstans med MCP SDK.
- Vi definierar verktyg med hjälp av dekoratorer.
- Vi använder stdio_server context manager för att hantera transporten.

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

Den största skillnaden från SSE är att stdio-servrar:

- Kräver inte webbserverinställning eller HTTP-endpoints.
- Startas som underprocesser av klienten.
- Kommunicerar via stdin/stdout-strömmar.
- Är enklare att implementera och felsöka.

## Övning: Skapa en stdio-server

För att skapa vår server måste vi tänka på två saker:

- Vi behöver använda en webbserver för att exponera endpoints för anslutning och meddelanden.

## Lab: Skapa en enkel MCP stdio-server

I detta labb kommer vi att skapa en enkel MCP-server med den rekommenderade stdio-transporten. Denna server kommer att exponera verktyg som klienter kan anropa med hjälp av standard Model Context Protocol.

### Förkunskaper

- Python 3.8 eller senare.
- MCP Python SDK: `pip install mcp`.
- Grundläggande förståelse för asynkron programmering.

Låt oss börja med att skapa vår första MCP stdio-server:

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

## Viktiga skillnader från den avvecklade SSE-metoden

**Stdio Transport (Nuvarande standard):**
- Enkel underprocessmodell - klienten startar servern som en underprocess.
- Kommunikation via stdin/stdout med JSON-RPC-meddelanden.
- Ingen HTTP-serverinställning krävs.
- Bättre prestanda och säkerhet.
- Enklare felsökning och utveckling.

**SSE Transport (Avvecklad från och med MCP 2025-06-18):**
- Krävde HTTP-server med SSE-endpoints.
- Mer komplex inställning med webbserverinfrastruktur.
- Ytterligare säkerhetsöverväganden för HTTP-endpoints.
- Nu ersatt av Streamable HTTP för webbaserade scenarier.

### Skapa en server med stdio transport

För att skapa vår stdio-server behöver vi:

1. **Importera nödvändiga bibliotek** - Vi behöver MCP-serverkomponenter och stdio transport.
2. **Skapa en serverinstans** - Definiera servern med dess funktioner.
3. **Definiera verktyg** - Lägg till den funktionalitet vi vill exponera.
4. **Ställ in transporten** - Konfigurera stdio-kommunikation.
5. **Starta servern** - Starta servern och hantera meddelanden.

Låt oss bygga detta steg för steg:

### Steg 1: Skapa en grundläggande stdio-server

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

### Steg 2: Lägg till fler verktyg

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

### Steg 3: Starta servern

Spara koden som `server.py` och kör den från kommandoraden:

```bash
python server.py
```

Servern kommer att starta och vänta på inmatning från stdin. Den kommunicerar med JSON-RPC-meddelanden via stdio transport.

### Steg 4: Testa med Inspector

Du kan testa din server med MCP Inspector:

1. Installera Inspector: `npx @modelcontextprotocol/inspector`.
2. Kör Inspector och peka den mot din server.
3. Testa de verktyg du har skapat.

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

// Lägg till verktyg
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Få en personlig hälsning",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Namnet på personen att hälsa",
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
          text: `Hej, ${request.params.arguments?.name}! Välkommen till MCP stdio-server.`,
        },
      ],
    };
  } else {
    throw new Error(`Okänt verktyg: ${request.params.name}`);
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
    [Description("Få en personlig hälsning")]
    public string GetGreeting(string name)
    {
        return $"Hej, {name}! Välkommen till MCP stdio-server.";
    }

    [Description("Beräkna summan av två tal")]
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

1. Låt oss först skapa några verktyg. För detta skapar vi en fil *Tools.cs* med följande innehåll:

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

2. **Öppna webbgränssnittet**: Inspector öppnar ett webbläsarfönster som visar din servers funktioner.

3. **Testa verktygen**: 
   - Testa `get_greeting`-verktyget med olika namn.
   - Testa `calculate_sum`-verktyget med olika tal.
   - Anropa `get_server_info`-verktyget för att se servermetadata.

4. **Övervaka kommunikationen**: Inspector visar JSON-RPC-meddelanden som utbyts mellan klient och server.

### Vad du bör se

När din server startar korrekt bör du se:
- Serverfunktioner listade i Inspector.
- Verktyg tillgängliga för testning.
- Framgångsrika JSON-RPC-meddelandeutbyten.
- Verktygsvar visas i gränssnittet.

### Vanliga problem och lösningar

**Servern startar inte:**
- Kontrollera att alla beroenden är installerade: `pip install mcp`.
- Verifiera Python-syntax och indrag.
- Leta efter felmeddelanden i konsolen.

**Verktyg visas inte:**
- Kontrollera att `@server.tool()`-dekorationer finns.
- Kontrollera att verktygsfunktioner är definierade före `main()`.
- Verifiera att servern är korrekt konfigurerad.

**Anslutningsproblem:**
- Kontrollera att servern använder stdio transport korrekt.
- Kontrollera att inga andra processer stör.
- Verifiera Inspector-kommandosyntaxen.

## Uppgift

Försök att bygga ut din server med fler funktioner. Se [denna sida](https://api.chucknorris.io/) för att till exempel lägga till ett verktyg som anropar en API. Du bestämmer hur servern ska se ut. Ha kul :)

## Lösning

[Lösning](./solution/README.md) Här är en möjlig lösning med fungerande kod.

## Viktiga lärdomar

De viktigaste lärdomarna från detta kapitel är följande:

- Stdio-transporten är den rekommenderade mekanismen för lokala MCP-servrar.
- Stdio-transporten möjliggör sömlös kommunikation mellan MCP-servrar och klienter via standard in- och utgångsströmmar.
- Du kan använda både Inspector och Visual Studio Code för att direkt använda stdio-servrar, vilket gör felsökning och integration enkel.

## Exempel 

- [Java Kalkylator](../samples/java/calculator/README.md)
- [.Net Kalkylator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkylator](../samples/javascript/README.md)
- [TypeScript Kalkylator](../samples/typescript/README.md)
- [Python Kalkylator](../../../../03-GettingStarted/samples/python) 

## Ytterligare resurser

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Vad är nästa steg

## Nästa steg

Nu när du har lärt dig att bygga MCP-servrar med stdio transport kan du utforska mer avancerade ämnen:

- **Nästa**: [HTTP Streaming med MCP (Streamable HTTP)](../06-http-streaming/README.md) - Lär dig om den andra stödda transportmekanismen för fjärrservrar.
- **Avancerat**: [MCP Säkerhetsbästa praxis](../../02-Security/README.md) - Implementera säkerhet i dina MCP-servrar.
- **Produktion**: [Distributionsstrategier](../09-deployment/README.md) - Distribuera dina servrar för produktionsanvändning.

## Ytterligare resurser

- [MCP-specifikation 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Officiell specifikation.
- [MCP SDK Dokumentation](https://github.com/modelcontextprotocol/sdk) - SDK-referenser för alla språk.
- [Community Exempel](../../06-CommunityContributions/README.md) - Fler serverexempel från communityn.

---

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, bör du vara medveten om att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.