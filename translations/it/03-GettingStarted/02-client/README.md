<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T01:18:52+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "it"
}
-->
# Creare un client

I client sono applicazioni personalizzate o script che comunicano direttamente con un MCP Server per richiedere risorse, strumenti e prompt. A differenza dell'uso dello strumento inspector, che fornisce un'interfaccia grafica per interagire con il server, scrivere un proprio client permette interazioni programmatiche e automatizzate. Questo consente agli sviluppatori di integrare le funzionalità MCP nei propri flussi di lavoro, automatizzare attività e costruire soluzioni personalizzate su misura per esigenze specifiche.

## Panoramica

Questa lezione introduce il concetto di client all'interno dell'ecosistema Model Context Protocol (MCP). Imparerai come scrivere un client e farlo connettere a un MCP Server.

## Obiettivi di apprendimento

Al termine di questa lezione, sarai in grado di:

- Comprendere cosa può fare un client.
- Scrivere il tuo client.
- Connettere e testare il client con un server MCP per assicurarti che funzioni come previsto.

## Cosa serve per scrivere un client?

Per scrivere un client, dovrai fare quanto segue:

- **Importare le librerie corrette**. Userai la stessa libreria di prima, ma con costrutti diversi.
- **Istanziare un client**. Questo comporta creare un'istanza del client e connetterla al metodo di trasporto scelto.
- **Decidere quali risorse elencare**. Il tuo MCP server offre risorse, strumenti e prompt, devi decidere quali elencare.
- **Integrare il client in un'applicazione host**. Una volta note le capacità del server, devi integrare il client nella tua applicazione host in modo che, se un utente digita un prompt o un altro comando, venga invocata la funzione corrispondente del server.

Ora che abbiamo una visione generale di cosa faremo, diamo un’occhiata a un esempio.

### Un esempio di client

Vediamo questo esempio di client:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

Nel codice precedente abbiamo:

- Importato le librerie
- Creato un’istanza di client e connesso usando stdio come trasporto.
- Elencato prompt, risorse e strumenti e li abbiamo invocati tutti.

Ecco fatto, un client che può comunicare con un MCP Server.

Prendiamoci il tempo nella prossima sezione esercizi per analizzare ogni frammento di codice e spiegare cosa succede.

## Esercizio: Scrivere un client

Come detto sopra, prendiamoci il tempo per spiegare il codice, e sentiti libero di scrivere il codice insieme a noi.

### -1- Importare le librerie

Importiamo le librerie necessarie, ci serviranno riferimenti a un client e al protocollo di trasporto scelto, stdio. stdio è un protocollo pensato per esecuzioni sulla macchina locale. SSE è un altro protocollo di trasporto che mostreremo nei capitoli futuri, ma per ora continuiamo con stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Per Java, creerai un client che si connette al MCP server dell’esercizio precedente. Usando la stessa struttura del progetto Java Spring Boot di [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), crea una nuova classe Java chiamata `SDKClient` nella cartella `src/main/java/com/microsoft/mcp/sample/client/` e aggiungi le seguenti importazioni:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

Passiamo all’istanza.

### -2- Istanziare client e trasporto

Dobbiamo creare un’istanza del trasporto e una del client:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

Nel codice precedente abbiamo:

- Creato un’istanza del trasporto stdio. Nota come vengono specificati comando e argomenti per trovare e avviare il server, cosa necessaria mentre creiamo il client.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Istanziato un client assegnandogli un nome e una versione.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Connesso il client al trasporto scelto.

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

Nel codice precedente abbiamo:

- Importato le librerie necessarie
- Istanziato un oggetto parametri server che useremo per avviare il server e connetterci con il client.
- Definito un metodo `run` che a sua volta chiama `stdio_client` per avviare una sessione client.
- Creato un punto di ingresso dove passiamo il metodo `run` a `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

Nel codice precedente abbiamo:

- Importato le librerie necessarie.
- Creato un trasporto stdio e un client `mcpClient`. Quest’ultimo sarà usato per elencare e invocare le funzionalità sul MCP Server.

Nota che in "Arguments" puoi indicare sia il file *.csproj* sia l’eseguibile.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

Nel codice precedente abbiamo:

- Creato un metodo main che configura un trasporto SSE puntando a `http://localhost:8080` dove il nostro MCP server sarà in esecuzione.
- Creato una classe client che prende il trasporto come parametro del costruttore.
- Nel metodo `run`, creiamo un client MCP sincrono usando il trasporto e inizializziamo la connessione.
- Usato il trasporto SSE (Server-Sent Events) adatto per comunicazioni HTTP con server MCP Java Spring Boot.

### -3- Elencare le funzionalità del server

Ora abbiamo un client che può connettersi se il programma viene eseguito. Tuttavia, non elenca ancora le sue funzionalità, facciamolo ora:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

Qui elenchiamo le risorse disponibili, `list_resources()` e gli strumenti, `list_tools`, e li stampiamo.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Qui un esempio di come elencare gli strumenti sul server. Per ogni strumento stampiamo il nome.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Nel codice precedente abbiamo:

- Chiamato `listTools()` per ottenere tutti gli strumenti disponibili dal MCP server.
- Usato `ping()` per verificare che la connessione al server funzioni.
- `ListToolsResult` contiene informazioni su tutti gli strumenti, inclusi nomi, descrizioni e schemi di input.

Ottimo, ora abbiamo catturato tutte le funzionalità. Ma quando le usiamo? Questo client è piuttosto semplice, nel senso che dobbiamo chiamare esplicitamente le funzionalità quando le vogliamo. Nel prossimo capitolo creeremo un client più avanzato che avrà accesso a un proprio modello linguistico di grandi dimensioni, LLM. Per ora vediamo come invocare le funzionalità sul server:

### -4- Invocare le funzionalità

Per invocare le funzionalità dobbiamo assicurarci di specificare gli argomenti corretti e in alcuni casi il nome di ciò che vogliamo invocare.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

Nel codice precedente abbiamo:

- Letto una risorsa, la chiamiamo con `readResource()` specificando `uri`. Ecco come appare probabilmente sul server:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Il nostro valore `uri` `file://example.txt` corrisponde a `file://{name}` sul server. `example.txt` sarà mappato a `name`.

- Chiamato uno strumento, lo invochiamo specificando il suo `name` e i suoi `arguments` così:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Ottenuto un prompt, per ottenerlo chiami `getPrompt()` con `name` e `arguments`. Il codice server è così:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    e il codice client risultante sarà quindi così per corrispondere a quanto dichiarato sul server:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

Nel codice precedente abbiamo:

- Chiamato una risorsa chiamata `greeting` usando `read_resource`.
- Invocato uno strumento chiamato `add` usando `call_tool`.

### C#

1. Aggiungiamo del codice per chiamare uno strumento:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Per stampare il risultato, ecco del codice per gestirlo:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

Nel codice precedente abbiamo:

- Chiamato più strumenti calcolatrice usando il metodo `callTool()` con oggetti `CallToolRequest`.
- Ogni chiamata specifica il nome dello strumento e una `Map` di argomenti richiesti dallo strumento.
- Gli strumenti server si aspettano nomi di parametri specifici (come "a", "b" per operazioni matematiche).
- I risultati sono restituiti come oggetti `CallToolResult` contenenti la risposta del server.

### -5- Eseguire il client

Per eseguire il client, digita il seguente comando nel terminale:

### TypeScript

Aggiungi la seguente voce alla sezione "scripts" in *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Esegui il client con il seguente comando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Prima assicurati che il tuo MCP server sia in esecuzione su `http://localhost:8080`. Poi esegui il client:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

In alternativa, puoi eseguire il progetto client completo fornito nella cartella soluzione `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Compito

In questo compito, userai quanto appreso per creare un client tutto tuo.

Ecco un server che puoi usare e che devi chiamare tramite il codice del tuo client, prova ad aggiungere più funzionalità al server per renderlo più interessante.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

Guarda questo progetto per vedere come [aggiungere prompt e risorse](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Inoltre, consulta questo link per sapere come invocare [prompt e risorse](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Soluzione

[Soluzione](./solution/README.md)

## Punti chiave

I punti chiave di questo capitolo riguardo ai client sono:

- Possono essere usati sia per scoprire che per invocare funzionalità sul server.
- Possono avviare un server mentre si avviano (come in questo capitolo), ma i client possono anche connettersi a server già in esecuzione.
- Sono un ottimo modo per testare le capacità del server accanto ad alternative come l’Inspector, come descritto nel capitolo precedente.

## Risorse aggiuntive

- [Costruire client in MCP](https://modelcontextprotocol.io/quickstart/client)

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Cosa c’è dopo

- Prossimo: [Creare un client con un LLM](../03-llm-client/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.