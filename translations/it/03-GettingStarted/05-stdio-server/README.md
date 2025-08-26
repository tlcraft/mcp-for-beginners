<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:31:23+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "it"
}
-->
# Server MCP con trasporto stdio

> **⚠️ Aggiornamento Importante**: A partire dalla specifica MCP del 18-06-2025, il trasporto SSE (Server-Sent Events) standalone è stato **deprecato** e sostituito dal trasporto "Streamable HTTP". La specifica MCP attuale definisce due meccanismi di trasporto principali:
> 1. **stdio** - Input/output standard (raccomandato per server locali)
> 2. **Streamable HTTP** - Per server remoti che possono utilizzare SSE internamente
>
> Questa lezione è stata aggiornata per concentrarsi sul **trasporto stdio**, che è l'approccio raccomandato per la maggior parte delle implementazioni di server MCP.

Il trasporto stdio consente ai server MCP di comunicare con i client attraverso i flussi di input e output standard. Questo è il meccanismo di trasporto più comunemente utilizzato e raccomandato nella specifica MCP attuale, offrendo un modo semplice ed efficiente per costruire server MCP facilmente integrabili con varie applicazioni client.

## Panoramica

Questa lezione copre come costruire e utilizzare server MCP utilizzando il trasporto stdio.

## Obiettivi di apprendimento

Alla fine di questa lezione, sarai in grado di:

- Creare un server MCP utilizzando il trasporto stdio.
- Effettuare il debug di un server MCP utilizzando l'Inspector.
- Utilizzare un server MCP con Visual Studio Code.
- Comprendere i meccanismi di trasporto MCP attuali e perché il trasporto stdio è raccomandato.

## Trasporto stdio - Come funziona

Il trasporto stdio è uno dei due tipi di trasporto supportati nella specifica MCP attuale (18-06-2025). Ecco come funziona:

- **Comunicazione semplice**: Il server legge i messaggi JSON-RPC dall'input standard (`stdin`) e invia messaggi all'output standard (`stdout`).
- **Basato su processi**: Il client avvia il server MCP come sottoprocesso.
- **Formato dei messaggi**: I messaggi sono richieste, notifiche o risposte JSON-RPC individuali, delimitati da nuove righe.
- **Logging**: Il server PUÒ scrivere stringhe UTF-8 sull'errore standard (`stderr`) per scopi di logging.

### Requisiti principali:
- I messaggi DEVONO essere delimitati da nuove righe e NON DEVONO contenere nuove righe incorporate.
- Il server NON DEVE scrivere nulla su `stdout` che non sia un messaggio MCP valido.
- Il client NON DEVE scrivere nulla su `stdin` del server che non sia un messaggio MCP valido.

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

Nel codice precedente:

- Importiamo la classe `Server` e `StdioServerTransport` dall'SDK MCP.
- Creiamo un'istanza del server con configurazione e capacità di base.

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

Nel codice precedente:

- Creiamo un'istanza del server utilizzando l'SDK MCP.
- Definiamo gli strumenti utilizzando i decoratori.
- Utilizziamo il gestore di contesto `stdio_server` per gestire il trasporto.

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

La differenza principale rispetto a SSE è che i server stdio:

- Non richiedono configurazione di server web o endpoint HTTP.
- Vengono avviati come sottoprocessi dal client.
- Comunicano tramite flussi stdin/stdout.
- Sono più semplici da implementare e fare il debug.

## Esercizio: Creare un server stdio

Per creare il nostro server, dobbiamo tenere a mente due cose:

- Dobbiamo utilizzare un server web per esporre gli endpoint per connessione e messaggi.

## Laboratorio: Creare un semplice server MCP stdio

In questo laboratorio, creeremo un semplice server MCP utilizzando il trasporto stdio raccomandato. Questo server esporrà strumenti che i client possono chiamare utilizzando il protocollo Model Context.

### Prerequisiti

- Python 3.8 o successivo.
- SDK MCP per Python: `pip install mcp`.
- Comprensione di base della programmazione asincrona.

Iniziamo creando il nostro primo server MCP stdio:

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

## Differenze principali rispetto all'approccio SSE deprecato

**Trasporto stdio (Standard attuale):**
- Modello semplice basato su sottoprocessi - il client avvia il server come processo figlio.
- Comunicazione tramite stdin/stdout utilizzando messaggi JSON-RPC.
- Non è necessaria la configurazione di un server HTTP.
- Migliori prestazioni e sicurezza.
- Debug e sviluppo più semplici.

**Trasporto SSE (Deprecato dal 18-06-2025):**
- Richiedeva un server HTTP con endpoint SSE.
- Configurazione più complessa con infrastruttura server web.
- Considerazioni aggiuntive sulla sicurezza per gli endpoint HTTP.
- Ora sostituito da Streamable HTTP per scenari basati sul web.

### Creare un server con trasporto stdio

Per creare il nostro server stdio, dobbiamo:

1. **Importare le librerie necessarie** - Servono i componenti del server MCP e il trasporto stdio.
2. **Creare un'istanza del server** - Definire il server con le sue capacità.
3. **Definire gli strumenti** - Aggiungere le funzionalità che vogliamo esporre.
4. **Configurare il trasporto** - Configurare la comunicazione stdio.
5. **Avviare il server** - Avviare il server e gestire i messaggi.

Costruiamo il tutto passo dopo passo:

### Passo 1: Creare un server stdio di base

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

### Passo 2: Aggiungere più strumenti

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

### Passo 3: Avviare il server

Salva il codice come `server.py` ed eseguilo dalla riga di comando:

```bash
python server.py
```

Il server si avvierà e attenderà input da stdin. Comunica utilizzando messaggi JSON-RPC tramite il trasporto stdio.

### Passo 4: Testare con l'Inspector

Puoi testare il tuo server utilizzando l'MCP Inspector:

1. Installa l'Inspector: `npx @modelcontextprotocol/inspector`.
2. Avvia l'Inspector e puntalo al tuo server.
3. Testa gli strumenti che hai creato.

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

// Aggiungi strumenti
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Ottieni un saluto personalizzato",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Nome della persona da salutare",
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
          text: `Ciao, ${request.params.arguments?.name}! Benvenuto nel server MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Strumento sconosciuto: ${request.params.name}`);
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
    [Description("Ottieni un saluto personalizzato")]
    public string GetGreeting(string name)
    {
        return $"Ciao, {name}! Benvenuto nel server MCP stdio.";
    }

    [Description("Calcola la somma di due numeri")]
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

1. Creiamo prima alcuni strumenti, per questo creeremo un file *Tools.cs* con il seguente contenuto:

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

2. **Apri l'interfaccia web**: L'Inspector aprirà una finestra del browser mostrando le capacità del tuo server.

3. **Testa gli strumenti**: 
   - Prova lo strumento `get_greeting` con nomi diversi.
   - Testa lo strumento `calculate_sum` con vari numeri.
   - Chiama lo strumento `get_server_info` per vedere i metadati del server.

4. **Monitora la comunicazione**: L'Inspector mostra i messaggi JSON-RPC scambiati tra client e server.

### Cosa dovresti vedere

Quando il tuo server si avvia correttamente, dovresti vedere:
- Le capacità del server elencate nell'Inspector.
- Strumenti disponibili per il test.
- Scambi di messaggi JSON-RPC riusciti.
- Risposte degli strumenti visualizzate nell'interfaccia.

### Problemi comuni e soluzioni

**Il server non si avvia:**
- Controlla che tutte le dipendenze siano installate: `pip install mcp`.
- Verifica la sintassi e l'indentazione di Python.
- Cerca messaggi di errore nella console.

**Gli strumenti non appaiono:**
- Assicurati che i decoratori `@server.tool()` siano presenti.
- Controlla che le funzioni degli strumenti siano definite prima di `main()`.
- Verifica che il server sia configurato correttamente.

**Problemi di connessione:**
- Assicurati che il server utilizzi correttamente il trasporto stdio.
- Controlla che nessun altro processo interferisca.
- Verifica la sintassi del comando dell'Inspector.

## Compito

Prova a costruire il tuo server con più capacità. Consulta [questa pagina](https://api.chucknorris.io/) per, ad esempio, aggiungere uno strumento che chiama un'API. Decidi tu come dovrebbe essere il server. Divertiti :)

## Soluzione

[Soluzione](./solution/README.md) Ecco una possibile soluzione con codice funzionante.

## Punti chiave

I punti chiave di questo capitolo sono i seguenti:

- Il trasporto stdio è il meccanismo raccomandato per i server MCP locali.
- Il trasporto stdio consente una comunicazione senza interruzioni tra server MCP e client utilizzando flussi di input e output standard.
- Puoi utilizzare sia l'Inspector che Visual Studio Code per utilizzare direttamente i server stdio, rendendo il debug e l'integrazione semplici.

## Esempi 

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python) 

## Risorse aggiuntive

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Cosa viene dopo

## Prossimi passi

Ora che hai imparato a costruire server MCP con il trasporto stdio, puoi esplorare argomenti più avanzati:

- **Prossimo**: [Streaming HTTP con MCP (Streamable HTTP)](../06-http-streaming/README.md) - Scopri l'altro meccanismo di trasporto supportato per server remoti.
- **Avanzato**: [Migliori pratiche di sicurezza MCP](../../02-Security/README.md) - Implementa la sicurezza nei tuoi server MCP.
- **Produzione**: [Strategie di distribuzione](../09-deployment/README.md) - Distribuisci i tuoi server per l'uso in produzione.

## Risorse aggiuntive

- [Specifiche MCP 18-06-2025](https://spec.modelcontextprotocol.io/specification/) - Specifica ufficiale.
- [Documentazione SDK MCP](https://github.com/modelcontextprotocol/sdk) - Riferimenti SDK per tutti i linguaggi.
- [Esempi della comunità](../../06-CommunityContributions/README.md) - Altri esempi di server dalla comunità.

---

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per garantire l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un traduttore umano. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.