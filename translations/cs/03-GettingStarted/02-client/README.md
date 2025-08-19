<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T10:46:33+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "cs"
}
-->
# Vytvoření klienta

Klienti jsou vlastní aplikace nebo skripty, které komunikují přímo se serverem MCP za účelem požadavků na zdroje, nástroje a výzvy. Na rozdíl od používání inspektoru, který poskytuje grafické rozhraní pro interakci se serverem, psaní vlastního klienta umožňuje programatickou a automatizovanou komunikaci. To vývojářům umožňuje integrovat schopnosti MCP do vlastních pracovních postupů, automatizovat úkoly a vytvářet řešení na míru podle specifických potřeb.

## Přehled

Tato lekce představuje koncept klientů v ekosystému Model Context Protocol (MCP). Naučíte se, jak napsat vlastního klienta a připojit ho k MCP Serveru.

## Cíle učení

Na konci této lekce budete schopni:

- Porozumět tomu, co klient dokáže.
- Napsat vlastního klienta.
- Připojit a otestovat klienta s MCP serverem, aby bylo zajištěno, že server funguje podle očekávání.

## Co obnáší psaní klienta?

Pro napsání klienta je potřeba:

- **Naimportovat správné knihovny**. Budete používat stejnou knihovnu jako dříve, jen jiné konstrukty.
- **Vytvořit instanci klienta**. To zahrnuje vytvoření instance klienta a připojení k vybranému způsobu přenosu dat.
- **Rozhodnout, jaké zdroje zobrazit**. Váš MCP server nabízí zdroje, nástroje a výzvy, musíte se rozhodnout, které z nich zobrazíte.
- **Integrovat klienta do hostitelské aplikace**. Jakmile znáte schopnosti serveru, je potřeba klienta integrovat do hostitelské aplikace tak, aby při zadání výzvy nebo jiného příkazu uživatelem byla vyvolána odpovídající funkce serveru.

Nyní, když rozumíme na vysoké úrovni tomu, co budeme dělat, podívejme se na příklad.

### Příklad klienta

Podívejme se na tento příklad klienta:

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

V předchozím kódu jsme:

- Naimportovali knihovny
- Vytvořili instanci klienta a připojili ji pomocí stdio jako transportu.
- Vypsali výzvy, zdroje a nástroje a všechny je vyvolali.

A je to, klient, který dokáže komunikovat s MCP Serverem.

V další části si kód podrobně rozebere a vysvětlíme, co se děje.

## Cvičení: Psaní klienta

Jak bylo řečeno, pojďme si kód podrobně vysvětlit a klidně si ho i sami vyzkoušejte.

### -1- Import knihoven

Naimportujme potřebné knihovny, budeme potřebovat reference na klienta a na zvolený transportní protokol stdio. stdio je protokol určený pro aplikace běžící na lokálním počítači. SSE je další transportní protokol, který ukážeme v budoucích kapitolách, ale prozatím pokračujme se stdio.

#### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

#### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

#### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

#### Java

Pro Javu vytvoříte klienta, který se připojí k MCP serveru z předchozího cvičení. Použijte stejnou strukturu projektu Java Spring Boot z [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), vytvořte novou třídu `SDKClient` ve složce `src/main/java/com/microsoft/mcp/sample/client/` a přidejte následující importy:

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

#### Rust

Budete muset přidat následující závislosti do svého souboru `Cargo.toml`.

```toml
[package]
name = "calculator-client"
version = "0.1.0"
edition = "2024"

[dependencies]
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

Odtud můžete importovat potřebné knihovny do svého klientského kódu.

```rust
use rmcp::{
    RmcpError,
    model::CallToolRequestParam,
    service::ServiceExt,
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use tokio::process::Command;
```

#### Rust

Budete muset přidat následující závislosti do svého souboru `Cargo.toml`.

```toml
[package]
name = "calculator-client"
version = "0.1.0"
edition = "2024"

[dependencies]
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

Poté můžete importovat potřebné knihovny do svého klientského kódu.

```rust
use rmcp::{
    RmcpError,
    model::CallToolRequestParam,
    service::ServiceExt,
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use tokio::process::Command;
```

Pokračujme s instancí.

### -2- Vytvoření instance klienta a transportu

Budeme muset vytvořit instanci transportu a klienta:

#### TypeScript

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

V předchozím kódu jsme:

- Vytvořili instanci stdio transportu. Všimněte si, jak jsou specifikovány příkaz a argumenty pro nalezení a spuštění serveru, což budeme potřebovat při vytváření klienta.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Vytvořili instanci klienta zadáním jeho jména a verze.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Připojili klienta k vybranému transportu.

    ```typescript
    await client.connect(transport);
    ```

#### Python

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

V předchozím kódu jsme:

- Importovali potřebné knihovny.
- Vytvořili objekt parametrů serveru, který použijeme ke spuštění serveru, abychom se k němu mohli připojit s naším klientem.
- Definovali metodu `run`, která následně volá `stdio_client`, což spustí klientskou relaci.
- Vytvořili vstupní bod, kde poskytujeme metodu `run` funkci `asyncio.run`.

#### .NET

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

V předchozím kódu jsme:

- Naimportovali potřebné knihovny.
- Vytvořili stdio transport a klienta `mcpClient`. Ten budeme používat k vypsání a vyvolání funkcí na MCP serveru.

Poznámka: v "Arguments" můžete zadat buď *.csproj* nebo spustitelný soubor.

#### Java

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

V předchozím kódu jsme:

- Vytvořili metodu main, která nastavuje SSE transport směřující na `http://localhost:8080`, kde bude běžet náš MCP server.
- Vytvořili klientskou třídu, která přijímá transport jako parametr konstruktoru.
- V metodě `run` vytvořili synchronní MCP klienta pomocí transportu a inicializovali připojení.
- Použili SSE (Server-Sent Events) transport, který je vhodný pro HTTP komunikaci s Java Spring Boot MCP servery.

### -3- Výpis funkcí serveru

Nyní máme klienta, který se může připojit, pokud program spustíme. Nicméně zatím nevypisuje dostupné funkce, pojďme to napravit:

#### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

#### Python

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

Zde vypisujeme dostupné zdroje pomocí `list_resources()` a nástroje pomocí `list_tools` a vypisujeme je.

#### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Výše je příklad, jak vypsat nástroje na serveru. Pro každý nástroj pak vypíšeme jeho název.

#### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

V předchozím kódu jsme:

- Zavolali `listTools()` pro získání všech dostupných nástrojů z MCP serveru.
- Použili `ping()` k ověření, že připojení k serveru funguje.
- `ListToolsResult` obsahuje informace o všech nástrojích včetně jejich názvů, popisů a vstupních schémat.

Skvěle, nyní máme všechny funkce zachycené. Otázka zní, kdy je použít? Tento klient je poměrně jednoduchý, v tom smyslu, že funkce musíme explicitně volat, když je chceme použít. V další kapitole vytvoříme pokročilejšího klienta, který bude mít přístup ke svému vlastnímu velkému jazykovému modelu (LLM). Prozatím si ale ukážeme, jak funkce na serveru vyvolat:

### -4- Vyvolání funkcí

Pro vyvolání funkcí musíme zajistit správné argumenty a v některých případech i název toho, co chceme spustit.

#### TypeScript

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

V předchozím kódu jsme:

- Přečetli zdroj, zavolali jsme `readResource()` s parametrem `uri`. Na serveru to pravděpodobně vypadá takto:

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

    Naše hodnota `uri` `file://example.txt` odpovídá `file://{name}` na serveru. `example.txt` bude mapováno na `name`.

- Zavolali nástroj, specifikovali jsme jeho `name` a `arguments` takto:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Získali výzvu, pro získání výzvy voláme `getPrompt()` s `name` a `arguments`. Kód serveru vypadá takto:

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

    a výsledný klientský kód proto vypadá takto, aby odpovídal deklaraci na serveru:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

#### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

V předchozím kódu jsme:

- Zavolali zdroj nazvaný `greeting` pomocí `read_resource`.
- Vyvolali nástroj nazvaný `add` pomocí `call_tool`.

#### .NET

1. Přidejme nějaký kód pro volání nástroje:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. Pro vypsání výsledku použijeme tento kód:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

#### Java

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

V předchozím kódu jsme:

- Zavolali několik kalkulačních nástrojů pomocí metody `callTool()` s objekty `CallToolRequest`.
- Každé volání nástroje specifikuje název nástroje a `Map` argumentů požadovaných tímto nástrojem.
- Nástroje serveru očekávají specifické názvy parametrů (např. "a", "b" pro matematické operace).
- Výsledky jsou vráceny jako objekty `CallToolResult`, které obsahují odpověď ze serveru.

#### Rust

```rust
// Call add tool with arguments = {"a": 3, "b": 2}
let a = 3;
let b = 2;
let tool_result = client
    .call_tool(CallToolRequestParam {
        name: "add".into(),
        arguments: serde_json::json!({ "a": a, "b": b }).as_object().cloned(),
    })
    .await?;
println!("Result of {:?} + {:?}: {:?}", a, b, tool_result);
```

### -5- Spuštění klienta

Pro spuštění klienta zadejte následující příkaz do terminálu:

#### TypeScript

Přidejte následující položku do sekce "scripts" v *package.json*:

```json
"client": "tsc && node build/client.js"
```

```sh
npm run client
```

#### Python

Spusťte klienta následujícím příkazem:

```sh
python client.py
```

#### .NET

```sh
dotnet run
```

#### Java

Nejprve se ujistěte, že váš MCP server běží na `http://localhost:8080`. Poté spusťte klienta:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativně můžete spustit celý klientský projekt, který je k dispozici ve složce řešení `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

#### Rust

```bash
cargo fmt
cargo run
```

## Zadání

V tomto zadání použijete, co jste se naučili při vytváření klienta, ale vytvoříte vlastního klienta.

Zde je server, který můžete použít a ke kterému se budete připojovat přes svůj klientský kód. Zkuste přidat další funkce, aby byl server zajímavější.

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

Podívejte se na tento projekt, kde najdete, jak [přidat výzvy a zdroje](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Také se podívejte na tento odkaz, jak vyvolat [výzvy a zdroje](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

### Rust

V [předchozí sekci](../../../../03-GettingStarted/01-first-server) jste se naučili, jak vytvořit jednoduchý MCP server s Rustem. Můžete na tom pokračovat nebo se podívat na tento odkaz pro více příkladů MCP serverů založených na Rustu: [MCP Server Examples](https://github.com/modelcontextprotocol/rust-sdk/tree/main/examples/servers)

## Řešení

**Složka řešení** obsahuje kompletní, připravené klientské implementace, které demonstrují všechny koncepty pokryté v tomto tutoriálu. Každé řešení zahrnuje jak klientský, tak serverový kód uspořádaný v samostatných, samostatně fungujících projektech.

### 📁 Struktura řešení

Adresář řešení je uspořádán podle programovacích jazyků:

```text
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw             # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
├── rust/                # Rust client implementation
|  ├── Cargo.lock        # Cargo lock file
|  ├── Cargo.toml        # Project configuration and dependencies
|  ├── src               # Source code
|  │   └── main.rs       # Main client code
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Co každé řešení obsahuje

Každé jazykově specifické řešení poskytuje:

- **Kompletní implementaci klienta** se všemi funkcemi z tutoriálu
- **Funkční strukturu projektu** s potřebnými závislostmi a konfigurací
- **Skripty pro sestavení a spuštění** pro snadné nastavení a použití
- **Podrobný README** s instrukcemi specifickými pro jazyk
- **Příklady zpracování chyb** a výsledků

### 📖 Použití řešení

1. **Přejděte do složky preferovaného jazyka**:

   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Postupujte podle pokynů v README** v každé složce pro:
   - Instalaci závislostí.
   - Sestavení projektu.
   - Spuštění klienta.

3. **Příklad výstupu**, který byste měli vidět:

   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Pro kompletní dokumentaci a podrobné pokyny viz: **[📖 Dokumentace řešení](./solution/README.md)**

## 🎯 Kompletní příklady

Poskytli jsme kompletní, funkční implementace klientů pro všechny programovací jazyky pokryté v tomto tutoriálu. Tyto příklady demonstrují plnou funkcionalitu popsanou výše a mohou být použity jako referenční implementace nebo výchozí body pro vaše vlastní projekty.

### Dostupné kompletní příklady

| Jazyk | Soubor | Popis |
|-------|--------|-------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Kompletní Java klient používající SSE transport s komplexním zpracováním chyb |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Kompletní C# klient používající stdio transport s automatickým spuštěním serveru |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Kompletní TypeScript klient s plnou podporou MCP protokolu |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Kompletní Python klient používající async/await vzory |
| **Rust** | [`client_example_rust.rs`](../../../../03-GettingStarted/02-client/client_example_rust.rs) | Kompletní Rust klient používající Tokio pro asynchronní operace |
Každý kompletní příklad zahrnuje:

- ✅ **Navázání spojení** a zpracování chyb
- ✅ **Objevování serveru** (nástroje, zdroje, výzvy, kde je to možné)
- ✅ **Operace kalkulačky** (sčítání, odčítání, násobení, dělení, pomoc)
- ✅ **Zpracování výsledků** a formátovaný výstup
- ✅ **Komplexní zpracování chyb**
- ✅ **Čistý, dokumentovaný kód** s komentáři krok za krokem

### Začínáme s kompletními příklady

1. **Vyberte preferovaný jazyk** z tabulky výše
2. **Projděte si soubor s kompletním příkladem**, abyste pochopili celou implementaci
3. **Spusťte příklad** podle pokynů v [`complete_examples.md`](./complete_examples.md)
4. **Upravte a rozšiřte** příklad pro váš konkrétní případ použití

Podrobnou dokumentaci o spuštění a přizpůsobení těchto příkladů najdete zde: **[📖 Dokumentace kompletních příkladů](./complete_examples.md)**

### 💡 Řešení vs. Kompletní příklady

| **Složka řešení** | **Kompletní příklady** |
|--------------------|--------------------- |
| Kompletní struktura projektu s build soubory | Implementace v jednom souboru |
| Připraveno ke spuštění s potřebnými závislostmi | Zaměřené ukázky kódu |
| Nastavení podobné produkčnímu prostředí | Vzdělávací reference |
| Nástroje specifické pro jazyk | Porovnání mezi jazyky |

Oba přístupy jsou hodnotné - použijte **složku řešení** pro kompletní projekty a **kompletní příklady** pro učení a reference.

## Klíčové poznatky

Klíčové poznatky této kapitoly o klientech jsou následující:

- Lze je použít jak k objevování, tak k vyvolávání funkcí na serveru.  
- Mohou spustit server současně se svým vlastním spuštěním (jako v této kapitole), ale klienti se mohou také připojit k již běžícím serverům.  
- Jsou skvělým způsobem, jak otestovat schopnosti serveru vedle alternativ jako Inspector, jak bylo popsáno v předchozí kapitole.

## Další zdroje

- [Vytváření klientů v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)
- [Rust Kalkulačka](../../../../03-GettingStarted/samples/rust)

## Co dál

- Další: [Vytvoření klienta s LLM](../03-llm-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.