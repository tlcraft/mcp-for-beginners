<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T11:17:23+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ro"
}
-->
# Crearea unui client

Clienții sunt aplicații personalizate sau scripturi care comunică direct cu un MCP Server pentru a solicita resurse, unelte și prompturi. Spre deosebire de utilizarea instrumentului inspector, care oferă o interfață grafică pentru interacțiunea cu serverul, scrierea propriului client permite interacțiuni programatice și automate. Acest lucru le permite dezvoltatorilor să integreze capabilitățile MCP în propriile fluxuri de lucru, să automatizeze sarcini și să construiască soluții personalizate adaptate nevoilor specifice.

## Prezentare generală

Această lecție introduce conceptul de clienți în cadrul ecosistemului Model Context Protocol (MCP). Vei învăța cum să scrii propriul client și să îl conectezi la un MCP Server.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Înțelege ce poate face un client.
- Scrie propriul client.
- Conecta și testa clientul cu un server MCP pentru a te asigura că funcționează conform așteptărilor.

## Ce implică scrierea unui client?

Pentru a scrie un client, va trebui să faci următoarele:

- **Importă bibliotecile corecte**. Vei folosi aceeași bibliotecă ca înainte, doar că cu alte construcții.
- **Instanțiază un client**. Aceasta va implica crearea unei instanțe de client și conectarea acesteia la metoda de transport aleasă.
- **Decide ce resurse să listezi**. Serverul tău MCP vine cu resurse, unelte și prompturi, trebuie să decizi care dintre ele să fie listate.
- **Integrează clientul într-o aplicație gazdă**. Odată ce știi capabilitățile serverului, trebuie să integrezi clientul în aplicația gazdă astfel încât, dacă un utilizator tastează un prompt sau o altă comandă, să fie invocată funcționalitatea corespunzătoare a serverului.

Acum că am înțeles la nivel general ce urmează să facem, să vedem un exemplu.

### Un exemplu de client

Să aruncăm o privire la acest exemplu de client:

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

În codul de mai sus am:

- Importat bibliotecile
- Creat o instanță de client și conectat-o folosind stdio ca transport.
- Listat prompturi, resurse și unelte și le-am invocat pe toate.

Iată-l, un client care poate comunica cu un MCP Server.

Să luăm timpul necesar în următoarea secțiune de exerciții pentru a analiza fiecare fragment de cod și a explica ce se întâmplă.

## Exercițiu: Scrierea unui client

Așa cum am spus mai sus, să luăm timpul necesar pentru a explica codul, și, desigur, poți să codezi alături dacă dorești.

### -1- Importarea bibliotecilor

Să importăm bibliotecile de care avem nevoie, vom avea nevoie de referințe la un client și la protocolul de transport ales, stdio. stdio este un protocol pentru lucruri care rulează pe mașina ta locală. SSE este un alt protocol de transport pe care îl vom arăta în capitolele viitoare, dar acesta este cealaltă opțiune. Pentru moment, să continuăm cu stdio.

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

Pentru Java, vei crea un client care se conectează la MCP server din exercițiul anterior. Folosind aceeași structură de proiect Java Spring Boot din [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), creează o nouă clasă Java numită `SDKClient` în folderul `src/main/java/com/microsoft/mcp/sample/client/` și adaugă următoarele importuri:

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

Să trecem la instanțiere.

### -2- Instanțierea clientului și a transportului

Va trebui să creăm o instanță a transportului și una a clientului:

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

În codul de mai sus am:

- Creat o instanță de transport stdio. Observă cum specifică comanda și argumentele pentru a găsi și porni serverul, deoarece asta va trebui să facem când creăm clientul.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instanțiat un client oferindu-i un nume și o versiune.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Conectat clientul la transportul ales.

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

În codul de mai sus am:

- Importat bibliotecile necesare
- Instanțiat un obiect de parametri pentru server, pe care îl vom folosi pentru a rula serverul astfel încât să ne putem conecta la el cu clientul.
- Definit o metodă `run` care la rândul ei apelează `stdio_client` care pornește o sesiune de client.
- Creat un punct de intrare unde oferim metoda `run` către `asyncio.run`.

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

În codul de mai sus am:

- Importat bibliotecile necesare.
- Creat un transport stdio și un client `mcpClient`. Acesta din urmă este ceea ce vom folosi pentru a lista și invoca funcționalități pe MCP Server.

Notă, în "Arguments", poți indica fie către *.csproj*, fie către executabil.

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

În codul de mai sus am:

- Creat o metodă main care configurează un transport SSE indicând către `http://localhost:8080` unde va rula MCP serverul nostru.
- Creat o clasă client care primește transportul ca parametru în constructor.
- În metoda `run`, creăm un client MCP sincron folosind transportul și inițializăm conexiunea.
- Folosit transportul SSE (Server-Sent Events) care este potrivit pentru comunicarea bazată pe HTTP cu serverele MCP Java Spring Boot.

### -3- Listarea funcționalităților serverului

Acum avem un client care se poate conecta dacă programul este rulat. Totuși, nu listează efectiv funcționalitățile, așa că să facem asta acum:

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

Aici listăm resursele disponibile, `list_resources()` și uneltele, `list_tools` și le afișăm.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Mai sus este un exemplu cum putem lista uneltele de pe server. Pentru fiecare unealtă, afișăm numele acesteia.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

În codul de mai sus am:

- Apelat `listTools()` pentru a obține toate uneltele disponibile de pe MCP server.
- Folosit `ping()` pentru a verifica dacă conexiunea la server funcționează.
- `ListToolsResult` conține informații despre toate uneltele, inclusiv numele, descrierile și schemele de input.

Perfect, acum am capturat toate funcționalitățile. Acum întrebarea este când le folosim? Ei bine, acest client este destul de simplu, simplu în sensul că va trebui să apelăm explicit funcționalitățile când le dorim. În capitolul următor vom crea un client mai avansat care are acces la propriul model lingvistic mare, LLM. Pentru moment, să vedem cum putem invoca funcționalitățile de pe server:

### -4- Invocarea funcționalităților

Pentru a invoca funcționalitățile trebuie să ne asigurăm că specificăm argumentele corecte și, în unele cazuri, numele a ceea ce încercăm să invocăm.

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

În codul de mai sus am:

- Citit o resursă, apelăm resursa prin `readResource()` specificând `uri`. Iată cum arată cel mai probabil pe partea de server:

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

    Valoarea noastră `uri` `file://example.txt` corespunde cu `file://{name}` pe server. `example.txt` va fi mapat la `name`.

- Apelat o unealtă, o apelăm specificând `name` și `arguments` astfel:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Obținut un prompt, pentru a obține un prompt, apelezi `getPrompt()` cu `name` și `arguments`. Codul serverului arată astfel:

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

    iar codul clientului rezultat arată astfel pentru a corespunde cu ce este declarat pe server:

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

În codul de mai sus am:

- Apelat o resursă numită `greeting` folosind `read_resource`.
- Invocat o unealtă numită `add` folosind `call_tool`.

### .NET

1. Să adăugăm cod pentru a apela o unealtă:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Pentru a afișa rezultatul, iată un cod care face asta:

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

În codul de mai sus am:

- Apelat mai multe unelte de calculator folosind metoda `callTool()` cu obiecte `CallToolRequest`.
- Fiecare apel specifică numele uneltei și un `Map` de argumente necesare de acea unealtă.
- Uneltele serverului așteaptă nume specifice de parametri (ca "a", "b" pentru operații matematice).
- Rezultatele sunt returnate ca obiecte `CallToolResult` care conțin răspunsul de la server.

### -5- Rularea clientului

Pentru a rula clientul, tastează următoarea comandă în terminal:

### TypeScript

Adaugă următoarea intrare în secțiunea "scripts" din *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Apelează clientul cu următoarea comandă:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Mai întâi, asigură-te că MCP serverul tău rulează pe `http://localhost:8080`. Apoi rulează clientul:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativ, poți rula proiectul complet al clientului furnizat în folderul soluției `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tema

În această temă, vei folosi ce ai învățat pentru a crea un client, dar vei crea un client propriu.

Iată un server pe care îl poți folosi și la care trebuie să apelezi prin codul clientului tău, vezi dacă poți adăuga mai multe funcționalități serverului pentru a-l face mai interesant.

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

Vezi acest proiect pentru a vedea cum poți [adăuga prompturi și resurse](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

De asemenea, verifică acest link pentru cum să invoci [prompturi și resurse](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Soluție

Folderul **solution** conține implementări complete, gata de rulare, ale clienților care demonstrează toate conceptele acoperite în acest tutorial. Fiecare soluție include atât codul clientului, cât și al serverului, organizate în proiecte separate, autonome.

### 📁 Structura soluției

Directorul soluției este organizat pe limbaje de programare:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Ce include fiecare soluție

Fiecare soluție specifică limbajului oferă:

- **Implementare completă a clientului** cu toate funcționalitățile din tutorial
- **Structură de proiect funcțională** cu dependențe și configurări corecte
- **Scripturi de build și rulare** pentru configurare și execuție ușoară
- **README detaliat** cu instrucțiuni specifice limbajului
- **Exemple de tratare a erorilor** și procesare a rezultatelor

### 📖 Utilizarea soluțiilor

1. **Navighează în folderul limbajului preferat**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Urmărește instrucțiunile din README** din fiecare folder pentru:
   - Instalarea dependențelor
   - Construirea proiectului
   - Rularea clientului

3. **Exemplu de output** pe care ar trebui să îl vezi:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Pentru documentație completă și instrucțiuni pas cu pas, vezi: **[📖 Documentația soluției](./solution/README.md)**

## 🎯 Exemple complete

Am furnizat implementări complete, funcționale ale clienților pentru toate limbajele de programare acoperite în acest tutorial. Aceste exemple demonstrează funcționalitatea completă descrisă mai sus și pot fi folosite ca implementări de referință sau puncte de plecare pentru propriile proiecte.

### Exemple complete disponibile

| Limbaj  | Fișier                          | Descriere                                                      |
|---------|--------------------------------|----------------------------------------------------------------|
| **Java**| [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Client Java complet folosind transport SSE cu tratare completă a erorilor |
| **C#**  | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Client C# complet folosind transport stdio cu pornire automată a serverului |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Client TypeScript complet cu suport complet pentru protocolul MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)     | Client Python complet folosind pattern-uri async/await          |

Fiecare exemplu complet include:

- ✅ **Stabilirea conexiunii** și tratarea erorilor
- ✅ **Descoperirea serverului** (unelte, resurse, prompturi unde este cazul)
- ✅ **Operații calculator** (adunare, scădere, înmulțire, împărțire, ajutor)
- ✅ **Procesarea rezultatelor** și afișare formatată
- ✅ **Tratare completă a erorilor**
- ✅ **Cod curat, documentat** cu comentarii pas cu pas

### Începe cu exemplele complete

1. **Alege limbajul preferat** din tabelul de mai sus
2. **Studiază fișierul exemplu complet** pentru a înțelege implementarea completă
3. **Rulează exemplul** urmând instrucțiunile din [`complete_examples.md`](./complete_examples.md)
4. **Modifică și extinde** exemplul pentru cazul tău specific

Pentru documentație detaliată despre rulare și personalizare, vezi: **[📖 Documentația exemplelor complete](./complete_examples.md)**

### 💡 Soluție vs. Exemple complete

| **Folder Soluție**          | **Exemple Complete**          |
|----------------------------|------------------------------|
| Structură completă de proiect cu fișiere de build | Implementări într-un singur fișier |
| Gata de rulare cu dependențe | Exemple de cod concentrate    |
| Configurare asemănătoare mediului de producție | Referință educațională          |
| Instrumente specifice limbajului | Comparare cross-limbaj         |
Ambele abordări sunt valoroase - folosește **folderul solution** pentru proiecte complete și **exemplele complete** pentru învățare și referință.  
## Aspecte esențiale

Aspectele esențiale ale acestui capitol despre clienți sunt următoarele:

- Pot fi folosiți atât pentru a descoperi, cât și pentru a invoca funcționalități pe server.  
- Pot porni un server în timp ce se pornesc singuri (așa cum este în acest capitol), dar clienții se pot conecta și la servere deja pornite.  
- Sunt o metodă excelentă de a testa capabilitățile serverului, alături de alternative precum Inspector, așa cum a fost descris în capitolul anterior.  

## Resurse suplimentare

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemple

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Ce urmează

- Următorul: [Creating a client with an LLM](../03-llm-client/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.