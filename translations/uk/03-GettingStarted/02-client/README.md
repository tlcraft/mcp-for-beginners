<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T13:03:30+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "uk"
}
-->
# Створення клієнта

Клієнти — це кастомні додатки або скрипти, які безпосередньо спілкуються з MCP Server для запиту ресурсів, інструментів та підказок. На відміну від використання інструменту інспектора, який надає графічний інтерфейс для взаємодії з сервером, написання власного клієнта дозволяє програмно та автоматизовано взаємодіяти з сервером. Це дає змогу розробникам інтегрувати можливості MCP у власні робочі процеси, автоматизувати завдання та створювати кастомні рішення, адаптовані під конкретні потреби.

## Огляд

Цей урок знайомить з концепцією клієнтів у екосистемі Model Context Protocol (MCP). Ви навчитеся писати власного клієнта та підключати його до MCP Server.

## Цілі навчання

Після завершення цього уроку ви зможете:

- Розуміти, що може робити клієнт.
- Написати власного клієнта.
- Підключити та протестувати клієнта з MCP сервером, щоб переконатися, що він працює як очікується.

## Що потрібно для написання клієнта?

Щоб написати клієнта, вам потрібно:

- **Імпортувати потрібні бібліотеки**. Ви використовуватимете ту ж бібліотеку, що й раніше, але з іншими конструкціями.
- **Створити екземпляр клієнта**. Це включає створення клієнта та підключення його до обраного транспортного методу.
- **Визначити, які ресурси перелічувати**. Ваш MCP сервер має ресурси, інструменти та підказки, потрібно вирішити, які з них показувати.
- **Інтегрувати клієнта у хост-додаток**. Коли ви знаєте можливості сервера, потрібно інтегрувати клієнта у ваш хост-додаток, щоб при введенні користувачем підказки або іншої команди викликалася відповідна функція сервера.

Тепер, коли ми розуміємо загальну ідею, давайте розглянемо приклад.

### Приклад клієнта

Ось приклад клієнта:

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

У наведеному коді ми:

- Імпортували бібліотеки
- Створили екземпляр клієнта та підключили його через stdio як транспорт.
- Перелічили підказки, ресурси та інструменти і викликали їх усі.

Отже, у вас є клієнт, який може спілкуватися з MCP Server.

У наступному розділі вправ ми детально розберемо кожен фрагмент коду і пояснимо, що відбувається.

## Вправа: Написання клієнта

Як було сказано вище, давайте детально розглянемо код, і, звісно, ви можете писати код разом із нами.

### -1- Імпорт бібліотек

Імпортуємо потрібні бібліотеки, нам потрібні посилання на клієнта та обраний транспортний протокол — stdio. stdio — це протокол для програм, які запускаються на вашій локальній машині. SSE — інший транспортний протокол, який ми покажемо в майбутніх розділах, але наразі продовжимо зі stdio.

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

Для Java створіть клієнта, який підключається до MCP сервера з попередньої вправи. Використовуючи ту ж структуру проекту Java Spring Boot з [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), створіть новий клас `SDKClient` у папці `src/main/java/com/microsoft/mcp/sample/client/` та додайте такі імпорти:

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

Переходимо до створення екземплярів.

### -2- Створення екземпляра клієнта та транспорту

Потрібно створити екземпляр транспорту та клієнта:

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

У наведеному коді ми:

- Створили екземпляр транспорту stdio. Зверніть увагу, як вказано команду та аргументи для пошуку та запуску сервера — це те, що нам потрібно зробити при створенні клієнта.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Створили клієнта, задавши йому ім’я та версію.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Підключили клієнта до обраного транспорту.

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

У наведеному коді ми:

- Імпортували потрібні бібліотеки
- Створили об’єкт параметрів сервера, який використаємо для запуску сервера, щоб підключитися до нього клієнтом.
- Визначили метод `run`, який викликає `stdio_client` для запуску сесії клієнта.
- Створили точку входу, де передаємо метод `run` у `asyncio.run`.

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

У наведеному коді ми:

- Імпортували потрібні бібліотеки.
- Створили транспорт stdio та клієнта `mcpClient`. Останній використовується для переліку та виклику функцій MCP Server.

Зверніть увагу, у "Arguments" можна вказати або *.csproj*, або виконуваний файл.

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

У наведеному коді ми:

- Створили метод main, який налаштовує SSE транспорт, що вказує на `http://localhost:8080`, де працюватиме MCP сервер.
- Створили клас клієнта, який приймає транспорт у конструкторі.
- У методі `run` створили синхронного MCP клієнта з транспортом і ініціалізували з’єднання.
- Використали SSE (Server-Sent Events) транспорт, який підходить для HTTP-комунікації з MCP серверами на Java Spring Boot.

### -3- Перелік функцій сервера

Тепер у нас є клієнт, який може підключатися, якщо програму запустити. Однак він ще не перелічує функції сервера, зробимо це зараз:

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

Тут ми перелічуємо доступні ресурси `list_resources()` та інструменти `list_tools` і виводимо їх.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Приклад, як перелічити інструменти на сервері. Для кожного інструменту виводимо його ім’я.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

У наведеному коді ми:

- Викликали `listTools()` для отримання всіх доступних інструментів MCP сервера.
- Використали `ping()` для перевірки з’єднання з сервером.
- `ListToolsResult` містить інформацію про всі інструменти, включно з їхніми іменами, описами та схемами вхідних даних.

Чудово, тепер ми отримали всі функції. Але коли їх використовувати? Цей клієнт досить простий — потрібно явно викликати функції, коли вони потрібні. У наступному розділі ми створимо більш просунутий клієнт із власною великою мовною моделлю (LLM). А поки подивимось, як викликати функції сервера:

### -4- Виклик функцій

Щоб викликати функції, потрібно вказати правильні аргументи і в деяких випадках ім’я того, що хочемо викликати.

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

У наведеному коді ми:

- Читаємо ресурс, викликаючи `readResource()` з параметром `uri`. Ось як це, ймовірно, виглядає на сервері:

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

    Значення `uri` — `file://example.txt` відповідає `file://{name}` на сервері. `example.txt` буде зіставлено з `name`.

- Викликаємо інструмент, вказуючи його `name` та `arguments` так:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Отримуємо підказку, викликаючи `getPrompt()` з `name` та `arguments`. Код сервера виглядає так:

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

    Відповідно, код клієнта виглядає так, щоб відповідати серверній декларації:

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

У наведеному коді ми:

- Викликали ресурс `greeting` за допомогою `read_resource`.
- Викликали інструмент `add` через `call_tool`.

### .NET

1. Додамо код для виклику інструменту:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. Ось код для виводу результату:

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

У наведеному коді ми:

- Викликали кілька калькуляторних інструментів за допомогою методу `callTool()` з об’єктами `CallToolRequest`.
- Кожен виклик інструменту вказує ім’я інструменту та `Map` аргументів, необхідних для нього.
- Серверні інструменти очікують конкретні імена параметрів (наприклад, "a", "b" для математичних операцій).
- Результати повертаються як об’єкти `CallToolResult`, що містять відповідь сервера.

### -5- Запуск клієнта

Щоб запустити клієнта, введіть у терміналі таку команду:

### TypeScript

Додайте наступний запис у розділ "scripts" файлу *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Запустіть клієнта командою:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Спочатку переконайтеся, що MCP сервер працює на `http://localhost:8080`. Потім запустіть клієнта:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Або ж запустіть повний проект клієнта, що знаходиться у папці рішення `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Завдання

У цьому завданні ви використаєте набуті знання для створення власного клієнта.

Ось сервер, який ви можете використовувати, викликаючи його через свій клієнтський код. Спробуйте додати більше функцій до сервера, щоб зробити його цікавішим.

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

Перегляньте цей проект, щоб дізнатися, як [додавати підказки та ресурси](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Також ознайомтеся з цим посиланням про те, як викликати [підказки та ресурси](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Рішення

**Папка з рішенням** містить повні, готові до запуску реалізації клієнтів, які демонструють усі концепції, розглянуті в цьому посібнику. Кожне рішення включає код клієнта та сервера, організований у окремі, автономні проекти.

### 📁 Структура рішення

Директорія рішення організована за мовами програмування:

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

### 🚀 Що включає кожне рішення

Кожне рішення для конкретної мови містить:

- **Повну реалізацію клієнта** з усіма функціями з уроку
- **Робочу структуру проекту** з правильними залежностями та конфігурацією
- **Скрипти для збірки та запуску** для зручного налаштування та виконання
- **Детальний README** з інструкціями для конкретної мови
- **Обробку помилок** та приклади обробки результатів

### 📖 Використання рішень

1. **Перейдіть у папку з обраною мовою**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Дотримуйтесь інструкцій у README** у кожній папці для:
   - Встановлення залежностей
   - Збірки проекту
   - Запуску клієнта

3. **Приклад виводу, який ви маєте побачити**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Для повної документації та покрокових інструкцій дивіться: **[📖 Документація рішення](./solution/README.md)**

## 🎯 Повні приклади

Ми надали повні, робочі реалізації клієнтів для всіх мов програмування, розглянутих у цьому посібнику. Ці приклади демонструють повний функціонал, описаний вище, і можуть слугувати як еталонні реалізації або стартові точки для ваших проектів.

### Доступні повні приклади

| Мова     | Файл                          | Опис                                                        |
|----------|-------------------------------|-------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Повний Java клієнт з SSE транспортом та комплексною обробкою помилок |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Повний C# клієнт з stdio транспортом та автоматичним запуском сервера |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Повний TypeScript клієнт з повною підтримкою MCP протоколу |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Повний Python клієнт з використанням async/await патернів |

Кожен повний приклад включає:

- ✅ **Встановлення з’єднання** та обробку помилок
- ✅ **Виявлення сервера** (інструменти, ресурси, підказки, де застосовно)
- ✅ **Операції калькулятора** (додавання, віднімання, множення, ділення, допомога)
- ✅ **Обробку результатів** та форматований вивід
- ✅ **Комплексну обробку помилок**
- ✅ **Чистий, документований код** з покроковими коментарями

### Початок роботи з повними прикладами

1. **Обрати бажану мову** з таблиці вище
2. **Ознайомитись з повним прикладом** для розуміння повної реалізації
3. **Запустити приклад** згідно з інструкціями у файлі [`complete_examples.md`](./complete_examples.md)
4. **Модифікувати та розширювати** приклад під свої потреби

Для детальної документації про запуск і налаштування цих прикладів дивіться: **[📖 Документація повних прикладів](./complete_examples.md)**

### 💡 Рішення vs. Повні приклади

| **Папка з рішенням**          | **Повні приклади**            |
|------------------------------|------------------------------|
| Повна структура проекту з файлами збірки | Однофайлові реалізації       |
| Готові до запуску з залежностями | Фокус на прикладах коду       |
| Налаштування, близьке до продакшену | Освітні еталони               |
| Інструменти, специфічні для мови | Порівняння між мовами         |
Обидва підходи корисні — використовуйте **папку solution** для повних проєктів, а **complete examples** — для навчання та довідки.  
## Основні висновки

Основні висновки цієї глави про клієнтів:

- Можна використовувати як для виявлення, так і для виклику функцій на сервері.  
- Можуть запускати сервер під час свого старту (як у цій главі), але клієнти також можуть підключатися до вже запущених серверів.  
- Це чудовий спосіб перевірити можливості сервера поряд з альтернативами, як-от Inspector, про який йшлося в попередній главі.

## Додаткові ресурси

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Приклади

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Що далі

- Далі: [Creating a client with an LLM](../03-llm-client/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.