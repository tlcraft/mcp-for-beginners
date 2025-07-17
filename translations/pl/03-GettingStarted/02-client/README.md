<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:59:41+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pl"
}
-->
# Tworzenie klienta

Klienci to niestandardowe aplikacje lub skrypty, które komunikują się bezpośrednio z serwerem MCP, aby żądać zasobów, narzędzi i promptów. W przeciwieństwie do korzystania z narzędzia inspektora, które oferuje graficzny interfejs do interakcji z serwerem, napisanie własnego klienta pozwala na programowe i zautomatyzowane działania. Umożliwia to deweloperom integrację możliwości MCP z własnymi procesami pracy, automatyzację zadań oraz tworzenie niestandardowych rozwiązań dopasowanych do konkretnych potrzeb.

## Przegląd

Ta lekcja wprowadza pojęcie klientów w ekosystemie Model Context Protocol (MCP). Nauczysz się, jak napisać własnego klienta i połączyć go z serwerem MCP.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Zrozumieć, co klient może robić.
- Napisać własnego klienta.
- Połączyć się i przetestować klienta z serwerem MCP, aby upewnić się, że działa zgodnie z oczekiwaniami.

## Co jest potrzebne do napisania klienta?

Aby napisać klienta, musisz wykonać następujące kroki:

- **Zaimportować odpowiednie biblioteki**. Będziesz używać tej samej biblioteki co wcześniej, ale innych konstrukcji.
- **Utworzyć instancję klienta**. Oznacza to stworzenie instancji klienta i połączenie jej z wybraną metodą transportu.
- **Zdecydować, które zasoby wyświetlić**. Twój serwer MCP oferuje zasoby, narzędzia i prompt, musisz zdecydować, które z nich wyświetlić.
- **Zintegrować klienta z aplikacją hosta**. Gdy poznasz możliwości serwera, musisz zintegrować klienta z aplikacją hosta, tak aby po wpisaniu promptu lub innej komendy przez użytkownika, wywoływana była odpowiednia funkcja serwera.

Teraz, gdy mamy ogólne pojęcie, co zamierzamy zrobić, przyjrzyjmy się przykładowemu klientowi.

### Przykładowy klient

Spójrzmy na ten przykładowy klient:

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

W powyższym kodzie:

- Importujemy biblioteki
- Tworzymy instancję klienta i łączymy ją z transportem stdio.
- Wyświetlamy listę promptów, zasobów i narzędzi oraz wywołujemy je wszystkie.

Oto masz klienta, który potrafi komunikować się z serwerem MCP.

W następnej sekcji ćwiczeń poświęcimy czas na szczegółowe omówienie każdego fragmentu kodu.

## Ćwiczenie: Pisanie klienta

Jak wspomniano wcześniej, poświęćmy czas na wyjaśnienie kodu, a jeśli chcesz, możesz kodować razem z nami.

### -1- Importowanie bibliotek

Zaimportujmy potrzebne biblioteki, będziemy potrzebować odniesień do klienta oraz wybranego protokołu transportowego, stdio. stdio to protokół przeznaczony do działania na lokalnej maszynie. SSE to inny protokół transportowy, który pokażemy w kolejnych rozdziałach, ale to jest twoja alternatywa. Na razie jednak kontynuujmy ze stdio.

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

Dla Javy utworzysz klienta, który łączy się z serwerem MCP z poprzedniego ćwiczenia. Korzystając z tej samej struktury projektu Java Spring Boot z [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), stwórz nową klasę Java o nazwie `SDKClient` w folderze `src/main/java/com/microsoft/mcp/sample/client/` i dodaj następujące importy:

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

Przejdźmy do tworzenia instancji.

### -2- Tworzenie instancji klienta i transportu

Musimy utworzyć instancję transportu oraz klienta:

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

W powyższym kodzie:

- Utworzono instancję transportu stdio. Zwróć uwagę, jak określa on polecenie i argumenty do znalezienia i uruchomienia serwera, co jest potrzebne podczas tworzenia klienta.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Utworzono instancję klienta, nadając mu nazwę i wersję.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Połączono klienta z wybranym transportem.

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

W powyższym kodzie:

- Zaimportowano potrzebne biblioteki
- Utworzono obiekt parametrów serwera, którego użyjemy do uruchomienia serwera, aby móc się z nim połączyć klientem.
- Zdefiniowano metodę `run`, która wywołuje `stdio_client`, rozpoczynającą sesję klienta.
- Utworzono punkt wejścia, gdzie przekazujemy metodę `run` do `asyncio.run`.

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

W powyższym kodzie:

- Zaimportowano potrzebne biblioteki.
- Utworzono transport stdio oraz klienta `mcpClient`. Ten ostatni będzie używany do listowania i wywoływania funkcji na serwerze MCP.

Uwaga, w "Arguments" możesz wskazać albo plik *.csproj*, albo plik wykonywalny.

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

W powyższym kodzie:

- Utworzono metodę main, która konfiguruje transport SSE wskazujący na `http://localhost:8080`, gdzie będzie działał nasz serwer MCP.
- Utworzono klasę klienta, która przyjmuje transport jako parametr konstruktora.
- W metodzie `run` tworzymy synchronicznego klienta MCP z użyciem transportu i inicjalizujemy połączenie.
- Użyto transportu SSE (Server-Sent Events), który jest odpowiedni do komunikacji HTTP z serwerami MCP opartymi na Java Spring Boot.

### -3- Wyświetlanie funkcji serwera

Mamy klienta, który może się połączyć, jeśli program zostanie uruchomiony. Jednak nie wyświetla on jeszcze dostępnych funkcji, zróbmy to teraz:

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

Tutaj wyświetlamy dostępne zasoby `list_resources()` i narzędzia `list_tools` oraz je wypisujemy.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Powyżej przykład, jak wyświetlić narzędzia na serwerze. Dla każdego narzędzia wypisujemy jego nazwę.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

W powyższym kodzie:

- Wywołano `listTools()`, aby pobrać wszystkie dostępne narzędzia z serwera MCP.
- Użyto `ping()`, aby zweryfikować, że połączenie z serwerem działa.
- `ListToolsResult` zawiera informacje o wszystkich narzędziach, w tym ich nazwy, opisy i schematy wejściowe.

Świetnie, mamy teraz wszystkie funkcje. Pytanie brzmi: kiedy ich używać? Ten klient jest dość prosty, co oznacza, że musimy wywoływać funkcje explicite, gdy ich potrzebujemy. W kolejnym rozdziale stworzymy bardziej zaawansowanego klienta, który będzie miał dostęp do własnego dużego modelu językowego (LLM). Na razie jednak zobaczmy, jak wywołać funkcje na serwerze:

### -4- Wywoływanie funkcji

Aby wywołać funkcje, musimy podać odpowiednie argumenty, a w niektórych przypadkach nazwę tego, co chcemy wywołać.

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

W powyższym kodzie:

- Odczytujemy zasób, wywołując `readResource()` i podając `uri`. Po stronie serwera wygląda to mniej więcej tak:

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

    Nasza wartość `uri` `file://example.txt` odpowiada `file://{name}` na serwerze. `example.txt` zostanie przypisane do `name`.

- Wywołujemy narzędzie, podając jego `name` i `arguments` w ten sposób:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Pobieramy prompt, wywołując `getPrompt()` z `name` i `arguments`. Kod serwera wygląda tak:

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

    Twój kod klienta będzie więc wyglądał tak, aby odpowiadać deklaracjom po stronie serwera:

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

W powyższym kodzie:

- Wywołano zasób o nazwie `greeting` za pomocą `read_resource`.
- Wywołano narzędzie o nazwie `add` za pomocą `call_tool`.

### .NET

1. Dodajmy kod do wywołania narzędzia:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. Aby wypisać wynik, oto kod do obsługi tego:

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

W powyższym kodzie:

- Wywołano kilka narzędzi kalkulatora za pomocą metody `callTool()` z obiektami `CallToolRequest`.
- Każde wywołanie narzędzia określa nazwę narzędzia oraz `Map` argumentów wymaganych przez to narzędzie.
- Narzędzia serwera oczekują konkretnych nazw parametrów (np. "a", "b" dla operacji matematycznych).
- Wyniki zwracane są jako obiekty `CallToolResult` zawierające odpowiedź z serwera.

### -5- Uruchomienie klienta

Aby uruchomić klienta, wpisz następujące polecenie w terminalu:

### TypeScript

Dodaj następujący wpis do sekcji "scripts" w *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Uruchom klienta poleceniem:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Najpierw upewnij się, że serwer MCP działa pod adresem `http://localhost:8080`. Następnie uruchom klienta:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternatywnie możesz uruchomić kompletny projekt klienta dostępny w folderze rozwiązania `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Zadanie

W tym zadaniu wykorzystasz zdobytą wiedzę do stworzenia własnego klienta.

Oto serwer, którego możesz użyć i do którego musisz się odwołać za pomocą swojego klienta. Spróbuj dodać więcej funkcji do serwera, aby był ciekawszy.

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

Zobacz ten projekt, aby dowiedzieć się, jak [dodawać prompt i zasoby](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Sprawdź też ten link, aby dowiedzieć się, jak wywoływać [prompt i zasoby](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Rozwiązanie

**Folder rozwiązania** zawiera kompletne, gotowe do uruchomienia implementacje klienta, które demonstrują wszystkie koncepcje omówione w tym tutorialu. Każde rozwiązanie zawiera zarówno kod klienta, jak i serwera, zorganizowany w osobnych, samodzielnych projektach.

### 📁 Struktura rozwiązania

Katalog rozwiązania jest zorganizowany według języka programowania:

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

### 🚀 Co zawiera każde rozwiązanie

Każde rozwiązanie specyficzne dla języka oferuje:

- **Kompletną implementację klienta** ze wszystkimi funkcjami z tutoriala
- **Działającą strukturę projektu** z odpowiednimi zależnościami i konfiguracją
- **Skrypty do budowania i uruchamiania** dla łatwej konfiguracji i wykonania
- **Szczegółowy README** z instrukcjami specyficznymi dla języka
- **Przykłady obsługi błędów** i przetwarzania wyników

### 📖 Korzystanie z rozwiązań

1. **Przejdź do folderu z wybranym językiem**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Postępuj zgodnie z instrukcjami w README** w każdym folderze, aby:
   - Zainstalować zależności
   - Zbudować projekt
   - Uruchomić klienta

3. **Przykładowy wynik**, który powinieneś zobaczyć:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Pełną dokumentację i instrukcje krok po kroku znajdziesz w: **[📖 Dokumentacja rozwiązania](./solution/README.md)**

## 🎯 Kompleksowe przykłady

Udostępniliśmy kompletne, działające implementacje klienta dla wszystkich języków programowania omawianych w tym tutorialu. Przykłady te demonstrują pełną funkcjonalność opisaną powyżej i mogą służyć jako wzorce lub punkty wyjścia do własnych projektów.

### Dostępne kompletne przykłady

| Język    | Plik                          | Opis                                                        |
|----------|-------------------------------|-------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Kompletny klient Java używający transportu SSE z obsługą błędów |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Kompletny klient C# używający transportu stdio z automatycznym uruchamianiem serwera |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Kompletny klient TypeScript z pełnym wsparciem protokołu MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Kompletny klient Python używający wzorców async/await         |

Każdy kompletny przykład zawiera:

- ✅ **Nawiązanie połączenia** i obsługę błędów
- ✅ **Odkrywanie serwera** (narzędzia, zasoby, prompt tam gdzie dotyczy)
- ✅ **Operacje kalkulatora** (dodawanie, odejmowanie, mnożenie, dzielenie, pomoc)
- ✅ **Przetwarzanie wyników** i formatowany output
- ✅ **Kompleksową obsługę błędów**
- ✅ **Czysty, udokumentowany kod** z komentarzami krok po kroku

### Jak zacząć z kompletnymi przykładami

1. **Wybierz preferowany język** z powyższej tabeli
2. **Przejrzyj kompletny plik przykładu**, aby zrozumieć pełną implementację
3. **Uruchom przykład** zgodnie z instrukcjami w [`complete_examples.md`](./complete_examples.md)
4. **Modyfikuj i rozszerzaj** przykład pod kątem własnych potrzeb

Szczegółową dokumentację dotyczącą uruchamiania i dostosowywania tych przykładów znajdziesz w: **[📖 Dokumentacja kompletnych przykładów](./complete_examples.md)**

### 💡 Rozwiązanie vs. Kompleksowe przykłady

| **Folder rozwiązania**       | **Kompleksowe przykłady**       |
|------------------------------|--------------------------------|
| Pełna struktura projektu z plikami budowania | Implementacje w pojedynczych plikach |
| Gotowe do uruchomienia z zależnościami | Skoncentrowane przykłady kodu |
| Konfiguracja produkcyjna     | Materiały edukacyjne           |
| Narzędzia specyficzne dla języka | Porównanie międzyjęzykowe       |
Oba podejścia są wartościowe – używaj **folderu rozwiązania** do kompletnych projektów, a **kompletnych przykładów** do nauki i odniesienia.

## Najważniejsze wnioski

Najważniejsze wnioski z tego rozdziału dotyczą klientów:

- Mogą być używane zarówno do odkrywania, jak i wywoływania funkcji na serwerze.
- Mogą uruchomić serwer podczas własnego startu (tak jak w tym rozdziale), ale klienci mogą też łączyć się z już działającymi serwerami.
- To świetny sposób na przetestowanie możliwości serwera obok alternatyw, takich jak Inspector, opisany w poprzednim rozdziale.

## Dodatkowe zasoby

- [Budowanie klientów w MCP](https://modelcontextprotocol.io/quickstart/client)

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Co dalej

- Następny: [Tworzenie klienta z LLM](../03-llm-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.