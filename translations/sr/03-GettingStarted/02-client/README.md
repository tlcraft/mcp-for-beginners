<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T11:52:50+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sr"
}
-->
# Креирање клијента

Клијенти су прилагођене апликације или скрипте које директно комуницирају са MCP сервером како би захтевали ресурсе, алате и упите. За разлику од коришћења алата инспектора који пружа графички интерфејс за интеракцију са сервером, писање сопственог клијента омогућава програмску и аутоматизовану комуникацију. Ово омогућава програмерима да интегришу MCP могућности у своје радне токове, аутоматизују задатке и креирају прилагођена решења по мери специфичних потреба.

## Преглед

Ова лекција уводи појам клијената у оквиру Model Context Protocol (MCP) екосистема. Научићете како да напишете сопствени клијент и повежете га са MCP сервером.

## Циљеви учења

До краја ове лекције моћи ћете да:

- Разумете шта клијент може да ради.
- Напишете сопствени клијент.
- Повежете и тестирате клијента са MCP сервером како бисте били сигурни да сервер ради како се очекује.

## Шта је потребно за писање клијента?

Да бисте написали клијента, потребно је да урадите следеће:

- **Увезите одговарајуће библиотеке**. Користићете исту библиотеку као и раније, само другачије конструкције.
- **Инстанцирате клијента**. Ово подразумева креирање инстанце клијента и повезивање са изабраним транспортним методом.
- **Одлучите које ресурсе ћете приказати**. Ваш MCP сервер има ресурсе, алате и упите, потребно је да одлучите које ћете приказати.
- **Интегришете клијента у апликацију домаћина**. Када знате могућности сервера, потребно је да интегришете клијента у вашу апликацију тако да, ако корисник унесе упит или другу команду, одговарајућа функција сервера буде позвана.

Сада када смо на високом нивоу разумели шта ћемо радити, хајде да погледамо пример.

### Пример клијента

Погледајмо овај пример клијента:

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

У претходном коду смо:

- Увезли библиотеке
- Креирали инстанцу клијента и повезали га користећи stdio као транспорт.
- Приказали упите, ресурсе и алате и позвали их све.

Ето га, клијент који може да комуницира са MCP сервером.

У наредном делу вежбе ћемо полако разложити сваки део кода и објаснити шта се дешава.

## Вежба: Писање клијента

Као што је речено, хајде да полако објаснимо код, и слободно пратите ако желите.

### -1- Увоз библиотека

Увезимо библиотеке које су нам потребне, требаће нам референце на клијента и на изабрани транспортни протокол, stdio. stdio је протокол за ствари које се извршавају на вашем локалном рачунару. SSE је други транспортни протокол који ћемо показати у будућим поглављима, али то је ваша друга опција. За сада, наставимо са stdio.

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

За Јаву, креираћете клијента који се повезује на MCP сервер из претходне вежбе. Користећи исту структуру Java Spring Boot пројекта из [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), направите нову Java класу под називом `SDKClient` у фасцикли `src/main/java/com/microsoft/mcp/sample/client/` и додајте следеће увозе:

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

Хајде да пређемо на инстанцирање.

### -2- Инстанцирање клијента и транспорта

Потребно је да креирамо инстанцу транспорта и инстанцу нашег клијента:

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

У претходном коду смо:

- Креирали инстанцу stdio транспорта. Обратите пажњу како се одређују команда и аргументи за покретање сервера, јер ћемо то морати да урадимо приликом креирања клијента.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Инстанцирали клијента тако што смо му дали име и верзију.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Повезали клијента са изабраним транспортом.

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

У претходном коду смо:

- Увезли потребне библиотеке
- Инстанцирали објекат параметара сервера који ћемо користити да покренемо сервер како бисмо се могли повезати са њим преко клијента.
- Дефинисали метод `run` који позива `stdio_client` који покреће сесију клијента.
- Креирали улазну тачку где позивамо `run` метод преко `asyncio.run`.

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

У претходном коду смо:

- Увезли потребне библиотеке.
- Креирали stdio транспорт и клијента `mcpClient`. Ово ћемо користити за листање и позивање функција на MCP серверу.

Напомена: у "Arguments" можете указати или на *.csproj* или на извршну датотеку.

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

У претходном коду смо:

- Креирали main метод који подешава SSE транспорт усмерен на `http://localhost:8080` где ће наш MCP сервер радити.
- Креирали класу клијента која као параметар конструктора прима транспорт.
- У `run` методу креирали синхрони MCP клијент користећи транспорт и иницијализовали везу.
- Користили SSE (Server-Sent Events) транспорт који је погодан за HTTP комуникацију са Java Spring Boot MCP серверима.

### -3- Листање функција сервера

Сада имамо клијента који може да се повеже ако се програм покрене. Међутим, он заправо не приказује његове функције, па хајде да то урадимо:

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

Овде приказујемо доступне ресурсе, `list_resources()` и алате, `list_tools` и штампамо их.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Горе је пример како можемо да прикажемо алате на серверу. За сваки алат штампамо његово име.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

У претходном коду смо:

- Позвали `listTools()` да добијемо све доступне алате са MCP сервера.
- Користили `ping()` да проверимо да ли веза са сервером ради.
- `ListToolsResult` садржи информације о свим алатима укључујући имена, описе и шеме улаза.

Одлично, сада смо добили све функције. Сада се поставља питање када их користити? Овај клијент је прилично једноставан, у смислу да ћемо морати експлицитно да позивамо функције кад их желимо. У наредном поглављу направићемо напреднијег клијента који има приступ свом великом језичком моделу, LLM. За сада, хајде да видимо како да позовемо функције на серверу:

### -4- Позивање функција

Да бисмо позвали функције, морамо да обезбедимо исправне аргументе и у неким случајевима име онога што желимо да позовемо.

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

У претходном коду смо:

- Прочитали ресурс, позивамо ресурс позивом `readResource()` са параметром `uri`. Ево како то највероватније изгледа на серверу:

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

    Вредност нашег `uri` `file://example.txt` одговара `file://{name}` на серверу. `example.txt` ће бити мапиран на `name`.

- Позвали алат, позивамо га тако што наведемо његово `name` и `arguments` овако:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Добијамо упит, да бисмо добили упит, позивамо `getPrompt()` са `name` и `arguments`. Код на серверу изгледа овако:

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

    и ваш резултујући код клијента изгледа овако да одговара ономе што је дефинисано на серверу:

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

У претходном коду смо:

- Позвали ресурс под називом `greeting` користећи `read_resource`.
- Позвали алат под називом `add` користећи `call_tool`.

### .NET

1. Додајмо код за позивање алата:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. За штампање резултата, ево кода који то обрађује:

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

У претходном коду смо:

- Позвали више калкулаторских алата користећи `callTool()` метод са `CallToolRequest` објектима.
- Сваки позив алата одређује име алата и `Map` аргумената потребних за тај алат.
- Серверски алати очекују специфична имена параметара (нпр. "a", "b" за математичке операције).
- Резултати се враћају као `CallToolResult` објекти који садрже одговор са сервера.

### -5- Покретање клијента

Да бисте покренули клијента, укуцајте следећу команду у терминал:

### TypeScript

Додајте следећи унос у ваш "scripts" део у *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Позовите клијента следећом командом:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Прво, уверите се да ваш MCP сервер ради на `http://localhost:8080`. Затим покрените клијента:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Алтернативно, можете покренути комплетан клијент пројекат који се налази у фасцикли решења `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Задатак

У овом задатку искористићете оно што сте научили о креирању клијента, али ћете направити сопствени клијент.

Ево сервера који можете користити и који треба да позовете преко вашег клијент кода, покушајте да додате више функција серверу како би био занимљивији.

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

Погледајте овај пројекат да видите како можете [додати упите и ресурсе](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Такође, проверите овај линк за начин позивања [упита и ресурса](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Решење

**Фасцикла решења** садржи комплетне, спремне за покретање имплементације клијената које демонстрирају све концепте обрађене у овом туторијалу. Свака имплементација укључује и код клијента и сервера организован у одвојене, самосталне пројекте.

### 📁 Структура решења

Директоријум решења је организован по програмским језицима:

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

### 🚀 Шта свака имплементација садржи

Свака имплементација по језику пружа:

- **Комплетну имплементацију клијента** са свим функцијама из туторијала
- **Функционалну структуру пројекта** са одговарајућим зависностима и конфигурацијом
- **Скрипте за изградњу и покретање** ради лакшег подешавања и извршавања
- **Детаљан README** са упутствима специфичним за језик
- **Примере обраде грешака** и обраде резултата

### 📖 Коришћење решења

1. **Идите у фасциклу за жељени језик**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Пратите упутства из README-а** у свакој фасцикли за:
   - Инсталацију зависности
   - Изградњу пројекта
   - Покретање клијента

3. **Пример излаза који треба да видите**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

За комплетну документацију и корак по корак упутства, погледајте: **[📖 Solution Documentation](./solution/README.md)**

## 🎯 Комплетни примери

Пружили смо комплетне, функционалне имплементације клијената за све програмске језике обрађене у овом туторијалу. Ови примери показују пуну функционалност описану горе и могу се користити као референтне имплементације или почетне тачке за ваше пројекте.

### Доступни комплетни примери

| Језик   | Датотека                        | Опис                                                        |
|---------|--------------------------------|-------------------------------------------------------------|
| **Java**  | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Комплетан Java клијент користећи SSE транспорт са детаљном обрадом грешака |
| **C#**    | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Комплетан C# клијент користећи stdio транспорт са аутоматским покретањем сервера |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Комплетан TypeScript клијент са пуном подршком MCP протокола |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Комплетан Python клијент користећи async/await обрасце |

Сваки комплетан пример укључује:

- ✅ **Успостављање везе** и обраду грешака
- ✅ **Откривање сервера** (алати, ресурси, упити где је применљиво)
- ✅ **Операције калкулатора** (збир, разлика, множење, дељење, помоћ)
- ✅ **Обраду резултата** и форматирани излаз
- ✅ **Детаљну обраду грешака**
- ✅ **Чист и документован код** са коментарима корак по корак

### Почетак рада са комплетним примерима

1. **Изаберите жељени језик** из табеле изнад
2. **Прегледајте комплетан пример** да бисте разумели целу имплементацију
3. **Покрените пример** пратећи упутства у [`complete_examples.md`](./complete_examples.md)
4. **Измените и проширите** пример за своје специфичне потребе

За детаљну документацију о покретању и прилагођавању ових примера, погледајте: **[📖 Complete Examples Documentation](./complete_examples.md)**

### 💡 Решење у односу на комплетне примере

| **Фасцикла решења**          | **Комплетни примери**          |
|------------------------------|-------------------------------|
| Комплетна структура пројекта са фајловима за изградњу | Имплементације у једној датотеци |
| Спремно за покретање са зависностима | Фокусирани примери кода         |
| Подешавање као у продукцији  | Образовни референтни материјал |
| Алатке специфичне за језик   | Поређење између језика         |
Оба приступа су вредна - користите **solution folder** за комплетне пројекте и **complete examples** за учење и референцу.

## Кључне поуке

Кључне поуке овог поглавља у вези са клијентима су следеће:

- Могу се користити и за откривање и за позивање функција на серверу.
- Могу покренути сервер док се сами покрећу (као у овом поглављу), али клијенти се могу повезати и на већ покренуте сервере.
- Одличан су начин да се тестирају могућности сервера поред алтернатива као што је Inspector, како је описано у претходном поглављу.

## Додатни ресурси

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Примери

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Шта следи

- Следеће: [Creating a client with an LLM](../03-llm-client/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.