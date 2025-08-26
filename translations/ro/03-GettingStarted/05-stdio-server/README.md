<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:45:20+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "ro"
}
-->
# MCP Server cu Transport stdio

> **⚠️ Actualizare Importantă**: Începând cu Specificația MCP 2025-06-18, transportul SSE (Server-Sent Events) standalone a fost **depreciat** și înlocuit cu transportul "Streamable HTTP". Specificația MCP actuală definește două mecanisme principale de transport:
> 1. **stdio** - Intrare/ieșire standard (recomandat pentru servere locale)
> 2. **Streamable HTTP** - Pentru servere la distanță care pot utiliza SSE intern
>
> Această lecție a fost actualizată pentru a se concentra pe **transportul stdio**, care este abordarea recomandată pentru majoritatea implementărilor de server MCP.

Transportul stdio permite serverelor MCP să comunice cu clienții prin fluxuri de intrare și ieșire standard. Acesta este cel mai utilizat și recomandat mecanism de transport în specificația MCP actuală, oferind o modalitate simplă și eficientă de a construi servere MCP care pot fi integrate ușor cu diverse aplicații client.

## Prezentare Generală

Această lecție acoperă modul de construire și utilizare a serverelor MCP folosind transportul stdio.

## Obiective de Învățare

La finalul acestei lecții, vei putea:

- Construi un server MCP folosind transportul stdio.
- Depana un server MCP utilizând Inspectorul.
- Utiliza un server MCP în Visual Studio Code.
- Înțelege mecanismele actuale de transport MCP și de ce stdio este recomandat.

## Transportul stdio - Cum Funcționează

Transportul stdio este unul dintre cele două tipuri de transport acceptate în specificația MCP actuală (2025-06-18). Iată cum funcționează:

- **Comunicare Simplă**: Serverul citește mesaje JSON-RPC din intrarea standard (`stdin`) și trimite mesaje către ieșirea standard (`stdout`).
- **Bazat pe Proces**: Clientul lansează serverul MCP ca un subproces.
- **Formatul Mesajelor**: Mesajele sunt cereri, notificări sau răspunsuri JSON-RPC individuale, delimitate prin linii noi.
- **Logare**: Serverul POATE scrie șiruri UTF-8 în eroarea standard (`stderr`) pentru scopuri de logare.

### Cerințe Cheie:
- Mesajele TREBUIE să fie delimitate prin linii noi și NU TREBUIE să conțină linii noi încorporate.
- Serverul NU TREBUIE să scrie nimic în `stdout` care să nu fie un mesaj MCP valid.
- Clientul NU TREBUIE să scrie nimic în `stdin` al serverului care să nu fie un mesaj MCP valid.

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

În codul precedent:

- Importăm clasa `Server` și `StdioServerTransport` din MCP SDK.
- Creăm o instanță de server cu configurație și capabilități de bază.

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

În codul precedent:

- Creăm o instanță de server utilizând MCP SDK.
- Definim instrumente folosind decoratori.
- Utilizăm context managerul stdio_server pentru a gestiona transportul.

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

Diferența cheie față de SSE este că serverele stdio:

- Nu necesită configurarea unui server web sau puncte finale HTTP.
- Sunt lansate ca subprocese de către client.
- Comunică prin fluxuri stdin/stdout.
- Sunt mai simple de implementat și depanat.

## Exercițiu: Crearea unui Server stdio

Pentru a crea serverul nostru, trebuie să ținem cont de două lucruri:

- Trebuie să utilizăm un server web pentru a expune puncte finale pentru conexiune și mesaje.

## Laborator: Crearea unui server MCP stdio simplu

În acest laborator, vom crea un server MCP simplu folosind transportul stdio recomandat. Acest server va expune instrumente pe care clienții le pot apela utilizând Protocolul Model Context Standard.

### Cerințe Prealabile

- Python 3.8 sau mai recent.
- MCP Python SDK: `pip install mcp`.
- Înțelegere de bază a programării asincrone.

Să începem prin crearea primului nostru server MCP stdio:

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

## Diferențe cheie față de abordarea SSE depreciată

**Transportul Stdio (Standard Actual):**
- Model simplu de subproces - clientul lansează serverul ca proces copil.
- Comunicare prin stdin/stdout utilizând mesaje JSON-RPC.
- Nu necesită configurarea unui server HTTP.
- Performanță și securitate mai bune.
- Depanare și dezvoltare mai ușoare.

**Transportul SSE (Depreciat din MCP 2025-06-18):**
- Necesita un server HTTP cu puncte finale SSE.
- Configurare mai complexă cu infrastructură de server web.
- Considerații suplimentare de securitate pentru punctele finale HTTP.
- Acum înlocuit de Streamable HTTP pentru scenarii bazate pe web.

### Crearea unui server cu transport stdio

Pentru a crea serverul nostru stdio, trebuie să:

1. **Importăm bibliotecile necesare** - Avem nevoie de componentele serverului MCP și transportul stdio.
2. **Creăm o instanță de server** - Definim serverul cu capabilitățile sale.
3. **Definim instrumente** - Adăugăm funcționalitatea pe care dorim să o expunem.
4. **Configurăm transportul** - Configurăm comunicarea stdio.
5. **Pornim serverul** - Lansăm serverul și gestionăm mesajele.

Să construim acest lucru pas cu pas:

### Pasul 1: Crearea unui server stdio de bază

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

### Pasul 2: Adăugarea mai multor instrumente

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

### Pasul 3: Pornirea serverului

Salvează codul ca `server.py` și rulează-l din linia de comandă:

```bash
python server.py
```

Serverul va porni și va aștepta intrări din stdin. Comunică utilizând mesaje JSON-RPC prin transportul stdio.

### Pasul 4: Testarea cu Inspectorul

Poți testa serverul utilizând MCP Inspector:

1. Instalează Inspectorul: `npx @modelcontextprotocol/inspector`.
2. Rulează Inspectorul și indică-l către serverul tău.
3. Testează instrumentele pe care le-ai creat.

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

// Adaugă instrumente
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Obține un salut personalizat",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Numele persoanei pentru salut",
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
          text: `Salut, ${request.params.arguments?.name}! Bine ai venit la serverul MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Instrument necunoscut: ${request.params.name}`);
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
    [Description("Obține un salut personalizat")]
    public string GetGreeting(string name)
    {
        return $"Salut, {name}! Bine ai venit la serverul MCP stdio.";
    }

    [Description("Calculează suma a două numere")]
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

1. Să creăm mai întâi câteva instrumente, pentru aceasta vom crea un fișier *Tools.cs* cu următorul conținut:

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

2. **Deschide interfața web**: Inspectorul va deschide o fereastră de browser care afișează capabilitățile serverului tău.

3. **Testează instrumentele**: 
   - Încearcă instrumentul `get_greeting` cu diferite nume.
   - Testează instrumentul `calculate_sum` cu diverse numere.
   - Apelează instrumentul `get_server_info` pentru a vedea metadatele serverului.

4. **Monitorizează comunicarea**: Inspectorul afișează mesajele JSON-RPC schimbate între client și server.

### Ce ar trebui să vezi

Când serverul tău pornește corect, ar trebui să vezi:
- Capabilitățile serverului listate în Inspector.
- Instrumentele disponibile pentru testare.
- Schimburi de mesaje JSON-RPC reușite.
- Răspunsurile instrumentelor afișate în interfață.

### Probleme comune și soluții

**Serverul nu pornește:**
- Verifică dacă toate dependențele sunt instalate: `pip install mcp`.
- Verifică sintaxa și indentarea Python.
- Caută mesaje de eroare în consolă.

**Instrumentele nu apar:**
- Asigură-te că decoratoarele `@server.tool()` sunt prezente.
- Verifică dacă funcțiile instrumentelor sunt definite înainte de `main()`.
- Asigură-te că serverul este configurat corect.

**Probleme de conexiune:**
- Asigură-te că serverul utilizează corect transportul stdio.
- Verifică dacă alte procese nu interferează.
- Verifică sintaxa comenzii Inspector.

## Temă

Încearcă să extinzi serverul tău cu mai multe capabilități. Vezi [această pagină](https://api.chucknorris.io/) pentru a adăuga, de exemplu, un instrument care apelează o API. Tu decizi cum ar trebui să arate serverul. Distracție plăcută :)

## Soluție

[Soluție](./solution/README.md) Iată o soluție posibilă cu cod funcțional.

## Concluzii Cheie

Concluziile cheie din acest capitol sunt următoarele:

- Transportul stdio este mecanismul recomandat pentru serverele MCP locale.
- Transportul stdio permite comunicarea fără probleme între serverele MCP și clienți utilizând fluxuri de intrare și ieșire standard.
- Poți utiliza atât Inspectorul, cât și Visual Studio Code pentru a consuma servere stdio direct, facilitând depanarea și integrarea.

## Exemple 

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python) 

## Resurse Suplimentare

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ce Urmează

## Pași Următori

Acum că ai învățat cum să construiești servere MCP cu transportul stdio, poți explora subiecte mai avansate:

- **Următorul**: [HTTP Streaming cu MCP (Streamable HTTP)](../06-http-streaming/README.md) - Învață despre celălalt mecanism de transport acceptat pentru servere la distanță.
- **Avansat**: [Practici de Securitate MCP](../../02-Security/README.md) - Implementează securitatea în serverele tale MCP.
- **Producție**: [Strategii de Implementare](../09-deployment/README.md) - Implementează serverele tale pentru utilizare în producție.

## Resurse Suplimentare

- [Specificația MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Specificația oficială.
- [Documentația MCP SDK](https://github.com/modelcontextprotocol/sdk) - Referințe SDK pentru toate limbajele.
- [Exemple Comunitare](../../06-CommunityContributions/README.md) - Mai multe exemple de servere din comunitate.

---

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.