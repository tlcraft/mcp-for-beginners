<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T11:33:36+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "bg"
}
-->
# Създаване на клиент

Клиентите са персонализирани приложения или скриптове, които комуникират директно с MCP сървър, за да заявяват ресурси, инструменти и подсказки. За разлика от използването на инспекторския инструмент, който предоставя графичен интерфейс за взаимодействие със сървъра, писането на собствен клиент позволява програмно и автоматизирано взаимодействие. Това дава възможност на разработчиците да интегрират възможностите на MCP в собствените си работни процеси, да автоматизират задачи и да създават персонализирани решения, съобразени с конкретни нужди.

## Преглед

Този урок въвежда концепцията за клиенти в екосистемата на Model Context Protocol (MCP). Ще научите как да напишете собствен клиент и да го свържете към MCP сървър.

## Учебни цели

Към края на този урок ще можете да:

- Разберете какво може да прави един клиент.
- Напишете собствен клиент.
- Свържете и тествате клиента с MCP сървър, за да се уверите, че всичко работи както трябва.

## Какво включва писането на клиент?

За да напишете клиент, трябва да направите следното:

- **Импортирайте правилните библиотеки**. Ще използвате същата библиотека като преди, но с различни конструкции.
- **Създайте инстанция на клиент**. Това включва създаване на клиентски обект и свързването му с избрания транспортен метод.
- **Решете какви ресурси да изброите**. Вашият MCP сървър разполага с ресурси, инструменти и подсказки, трябва да решите кои от тях да изброите.
- **Интегрирайте клиента в хост приложението**. След като разберете възможностите на сървъра, трябва да интегрирате това във вашето хост приложение, така че когато потребител въведе подсказка или друга команда, съответната функция на сървъра да бъде извикана.

Сега, след като имаме обща представа какво предстои, нека разгледаме пример.

### Примерен клиент

Нека разгледаме този примерен клиент:

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

В горния код ние:

- Импортираме библиотеките
- Създаваме инстанция на клиент и го свързваме чрез stdio транспорт.
- Изброяваме подсказки, ресурси и инструменти и ги извикваме всички.

Ето го, клиент, който може да комуникира с MCP сървър.

В следващата упражнителна част ще разгледаме всяка част от кода по-подробно и ще обясним какво се случва.

## Упражнение: Писане на клиент

Както казахме по-горе, нека отделим време да обясним кода, и разбира се, можете да пишете кода заедно с нас, ако желаете.

### -1- Импортиране на библиотеки

Нека импортираме необходимите библиотеки, ще ни трябват препратки към клиент и към избрания транспортен протокол, stdio. stdio е протокол за неща, които се изпълняват на локалната ви машина. SSE е друг транспортен протокол, който ще покажем в бъдещи глави, но това е другата ви опция. За сега обаче, нека продължим със stdio.

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

За Java ще създадете клиент, който се свързва към MCP сървъра от предишното упражнение. Използвайки същата структура на Java Spring Boot проекта от [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), създайте нов Java клас на име `SDKClient` в папката `src/main/java/com/microsoft/mcp/sample/client/` и добавете следните импорти:

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

Нека преминем към създаване на инстанции.

### -2- Създаване на инстанции на клиент и транспорт

Ще трябва да създадем инстанция на транспорта и на клиента:

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

В горния код ние:

- Създадохме инстанция на stdio транспорт. Обърнете внимание как се задават командата и аргументите за намиране и стартиране на сървъра, тъй като това ще ни трябва при създаването на клиента.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Създадохме клиент, като му дадохме име и версия.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Свързахме клиента с избрания транспорт.

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

В горния код ние:

- Импортирахме нужните библиотеки
- Създадохме обект с параметри за сървъра, който ще използваме, за да стартираме сървъра и да се свържем с него чрез клиента.
- Дефинирахме метод `run`, който от своя страна извиква `stdio_client`, който стартира клиентска сесия.
- Създадохме входна точка, където подаваме метода `run` на `asyncio.run`.

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

В горния код ние:

- Импортирахме нужните библиотеки.
- Създадохме stdio транспорт и клиент `mcpClient`. Последният ще използваме за изброяване и извикване на функции на MCP сървъра.

Забележка: в "Arguments" можете да посочите или *.csproj*, или изпълнимия файл.

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

В горния код ние:

- Създадохме главен метод, който настройва SSE транспорт, сочещ към `http://localhost:8080`, където ще работи нашият MCP сървър.
- Създадохме клиентски клас, който приема транспорта като параметър на конструктора.
- В метода `run` създаваме синхронен MCP клиент с помощта на транспорта и инициализираме връзката.
- Използвахме SSE (Server-Sent Events) транспорт, подходящ за HTTP базирана комуникация с Java Spring Boot MCP сървъри.

### -3- Изброяване на функциите на сървъра

Сега имаме клиент, който може да се свърже, ако програмата бъде стартирана. Въпреки това, той все още не изброява функциите си, така че нека направим това:

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

Тук изброяваме наличните ресурси с `list_resources()` и инструменти с `list_tools` и ги отпечатваме.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

По-горе е пример как можем да изброим инструментите на сървъра. За всеки инструмент отпечатваме името му.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

В горния код ние:

- Извикахме `listTools()`, за да получим всички налични инструменти от MCP сървъра.
- Използвахме `ping()`, за да проверим дали връзката със сървъра работи.
- `ListToolsResult` съдържа информация за всички инструменти, включително техните имена, описания и входни схеми.

Страхотно, вече сме получили всички функции. Сега въпросът е кога да ги използваме? Този клиент е доста прост, в смисъл, че трябва изрично да извикваме функциите, когато искаме да ги използваме. В следващата глава ще създадем по-усъвършенстван клиент, който има достъп до собствен голям езиков модел (LLM). За сега обаче, нека видим как можем да извикаме функциите на сървъра:

### -4- Извикване на функции

За да извикаме функциите, трябва да сме сигурни, че задаваме правилните аргументи и в някои случаи името на това, което искаме да извикаме.

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

В горния код ние:

- Четем ресурс, като извикваме `readResource()`, посочвайки `uri`. Ето как най-вероятно изглежда това на сървърната страна:

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

    Нашата стойност за `uri` `file://example.txt` съвпада с `file://{name}` на сървъра. `example.txt` ще бъде съпоставен с `name`.

- Извикваме инструмент, като посочваме неговото `name` и `arguments`, както следва:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Вземаме подсказка, като извикваме `getPrompt()` с `name` и `arguments`. Кодът на сървъра изглежда така:

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

    и съответно клиентският код изглежда така, за да съвпада с това, което е декларирано на сървъра:

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

В горния код ние:

- Извикахме ресурс на име `greeting` чрез `read_resource`.
- Извикахме инструмент на име `add` чрез `call_tool`.

### .NET

1. Нека добавим код за извикване на инструмент:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. За да отпечатаме резултата, ето код за това:

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

В горния код ние:

- Извикахме няколко калкулаторни инструмента чрез метода `callTool()` с обекти `CallToolRequest`.
- Всеки инструмент се извиква с име и `Map` от аргументи, необходими за инструмента.
- Сървърните инструменти очакват специфични имена на параметри (като "a", "b" за математически операции).
- Резултатите се връщат като обекти `CallToolResult`, съдържащи отговора от сървъра.

### -5- Стартиране на клиента

За да стартирате клиента, въведете следната команда в терминала:

### TypeScript

Добавете следния запис в секцията "scripts" на *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Извикайте клиента със следната команда:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Първо се уверете, че MCP сървърът ви работи на `http://localhost:8080`. След това стартирайте клиента:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Алтернативно, можете да стартирате пълния клиентски проект, предоставен в папката с решение `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Задача

В тази задача ще използвате наученото за създаване на клиент, но ще създадете собствен клиент.

Ето един сървър, който можете да използвате и към който трябва да се обръщате чрез вашия клиентски код. Опитайте да добавите повече функции към сървъра, за да го направите по-интересен.

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

Вижте този проект, за да разберете как да [добавяте подсказки и ресурси](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Също така, проверете този линк за това как да извиквате [подсказки и ресурси](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Решение

**Папката с решения** съдържа пълни, готови за изпълнение клиентски реализации, които демонстрират всички концепции, разгледани в този урок. Всяко решение включва както клиентски, така и сървърни кодове, организирани в отделни, самостоятелни проекти.

### 📁 Структура на решението

Директорията с решения е организирана по програмни езици:

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

### 🚀 Какво включва всяко решение

Всяко решение за конкретен език предоставя:

- **Пълна клиентска реализация** с всички функции от урока
- **Работеща структура на проекта** с правилни зависимости и конфигурация
- **Скриптове за компилиране и стартиране** за лесна настройка и изпълнение
- **Подробен README** с инструкции за конкретния език
- **Примери за обработка на грешки** и обработка на резултати

### 📖 Използване на решенията

1. **Навигирайте до папката за предпочитания от вас език**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Следвайте инструкциите в README във всяка папка за**:
   - Инсталиране на зависимости
   - Компилиране на проекта
   - Стартиране на клиента

3. **Примерен изход, който трябва да видите**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

За пълна документация и стъпка по стъпка инструкции вижте: **[📖 Документация на решението](./solution/README.md)**

## 🎯 Пълни примери

Предоставили сме пълни, работещи клиентски реализации за всички програмни езици, разгледани в този урок. Тези примери демонстрират пълната функционалност, описана по-горе, и могат да се използват като референтни реализации или отправна точка за вашите собствени проекти.

### Налични пълни примери

| Език    | Файл                          | Описание                                                      |
|---------|-------------------------------|---------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Пълен Java клиент с SSE транспорт и обстойна обработка на грешки |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Пълен C# клиент с stdio транспорт и автоматично стартиране на сървъра |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Пълен TypeScript клиент с пълна поддръжка на MCP протокола      |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Пълен Python клиент с async/await модели                        |

Всяка пълна примерна реализация включва:

- ✅ **Установяване на връзка** и обработка на грешки
- ✅ **Откриване на сървър** (инструменти, ресурси, подсказки, където е приложимо)
- ✅ **Калкулаторни операции** (събиране, изваждане, умножение, деление, помощ)
- ✅ **Обработка на резултати** и форматиран изход
- ✅ **Обстойна обработка на грешки**
- ✅ **Чист, документиран код** с коментари стъпка по стъпка

### Започване с пълните примери

1. **Изберете предпочитания от вас език** от таблицата по-горе
2. **Прегледайте пълния примерен файл**, за да разберете цялостната реализация
3. **Стартирайте примера** следвайки инструкциите в [`complete_examples.md`](./complete_examples.md)
4. **Модифицирайте и разширявайте** примера за вашия конкретен случай

За подробна документация относно стартирането и персонализирането на тези примери вижте: **[📖 Документация на пълните примери](./complete_examples.md)**

### 💡 Решение срещу пълни примери

| **Папка с решения**          | **Пълни примери**               |
|-----------------------------|--------------------------------|
| Пълна структура на проекта с файлове за компилиране | Еднофайлови реализации          |
| Готови за изпълнение с зависимости | Фокусирани кодови примери       |
| Настройка, близка до продукция | Образователен референтен материал |
| Инструменти специфични за езика | Сравнение между езици           |
И двата подхода са ценни - използвайте **папката с решения** за пълни проекти и **пълните примери** за учене и справка.

## Основни изводи

Основните изводи от тази глава относно клиентите са следните:

- Могат да се използват както за откриване, така и за извикване на функции на сървъра.
- Могат да стартират сървър, докато сами се стартират (както в тази глава), но клиентите могат да се свързват и към вече работещи сървъри.
- Това е отличен начин за тестване на възможностите на сървъра, алтернативно на инструменти като Inspector, както беше описано в предишната глава.

## Допълнителни ресурси

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Примери

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Какво следва

- Следва: [Creating a client with an LLM](../03-llm-client/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.