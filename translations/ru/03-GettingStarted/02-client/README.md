<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:35:55+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ru"
}
-->
# Создание клиента

Клиенты — это пользовательские приложения или скрипты, которые напрямую взаимодействуют с MCP Server для запроса ресурсов, инструментов и подсказок. В отличие от использования инспектора, который предоставляет графический интерфейс для работы с сервером, написание собственного клиента позволяет автоматизировать взаимодействия программно. Это даёт разработчикам возможность интегрировать возможности MCP в свои рабочие процессы, автоматизировать задачи и создавать кастомные решения под конкретные нужды.

## Обзор

В этом уроке мы познакомимся с понятием клиентов в экосистеме Model Context Protocol (MCP). Вы научитесь писать собственного клиента и подключать его к MCP Server.

## Цели обучения

К концу урока вы сможете:

- Понимать, что умеет клиент.
- Написать собственного клиента.
- Подключить и протестировать клиента с MCP сервером, чтобы убедиться, что всё работает как задумано.

## Что нужно для написания клиента?

Чтобы написать клиента, необходимо:

- **Импортировать нужные библиотеки**. Вы будете использовать ту же библиотеку, что и раньше, но с другими конструкциями.
- **Создать экземпляр клиента**. Это включает создание объекта клиента и подключение его к выбранному транспортному протоколу.
- **Определиться, какие ресурсы выводить**. Ваш MCP сервер содержит ресурсы, инструменты и подсказки — нужно решить, что именно показывать.
- **Интегрировать клиента в хост-приложение**. Когда вы узнаете возможности сервера, нужно встроить клиента в ваше приложение так, чтобы при вводе пользователем подсказки или команды вызывалась соответствующая функция сервера.

Теперь, когда мы в общих чертах понимаем, что предстоит сделать, давайте рассмотрим пример.

### Пример клиента

Посмотрим на пример клиента:

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

В приведённом коде мы:

- Импортируем библиотеки
- Создаём экземпляр клиента и подключаем его через stdio транспорт
- Выводим списки подсказок, ресурсов и инструментов и вызываем их все

Вот и всё — клиент, который может общаться с MCP Server.

В следующем упражнении мы подробно разберём каждый фрагмент кода и объясним, что происходит.

## Упражнение: написание клиента

Как уже говорилось, давайте подробно разберём код, и, конечно, вы можете писать код вместе с нами.

### -1- Импорт библиотек

Импортируем необходимые библиотеки: нам нужны ссылки на клиента и выбранный транспортный протокол stdio. stdio — это протокол для приложений, работающих на локальной машине. SSE — другой транспортный протокол, который мы покажем в будущих главах, но пока продолжим со stdio.

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

Для Java создайте клиента, который подключается к MCP серверу из предыдущего упражнения. Используя ту же структуру проекта Java Spring Boot из [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), создайте новый класс `SDKClient` в папке `src/main/java/com/microsoft/mcp/sample/client/` и добавьте следующие импорты:

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

Переходим к созданию экземпляров.

### -2- Создание экземпляра клиента и транспорта

Нужно создать экземпляры транспорта и клиента:

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

В приведённом коде мы:

- Создали экземпляр транспорта stdio. Обратите внимание, что здесь указываются команда и аргументы для запуска сервера — это важно, так как клиент должен уметь запускать сервер.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Создали клиента, указав имя и версию.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Подключили клиента к выбранному транспорту.

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

В этом коде мы:

- Импортировали необходимые библиотеки
- Создали объект параметров сервера, который будем использовать для запуска сервера и подключения к нему клиента
- Определили метод `run`, который вызывает `stdio_client` для запуска сессии клиента
- Создали точку входа, где вызываем `asyncio.run` с методом `run`

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

В этом коде мы:

- Импортировали необходимые библиотеки
- Создали stdio транспорт и клиента `mcpClient`. Этот клиент будет использоваться для получения списка и вызова функций MCP сервера.

Обратите внимание, что в "Arguments" можно указать либо *.csproj*, либо исполняемый файл.

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

В этом коде мы:

- Создали метод main, который настраивает SSE транспорт, указывающий на `http://localhost:8080`, где будет запущен MCP сервер
- Создали класс клиента, принимающий транспорт в конструкторе
- В методе `run` создаём синхронного MCP клиента с использованием транспорта и инициализируем соединение
- Используем SSE (Server-Sent Events) транспорт, подходящий для HTTP-коммуникации с Java Spring Boot MCP серверами

### -3- Получение списка функций сервера

Теперь у нас есть клиент, который может подключаться к серверу при запуске программы. Но он пока не выводит список функций, давайте исправим это:

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

Здесь мы выводим доступные ресурсы (`list_resources()`) и инструменты (`list_tools`) и печатаем их.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Пример того, как можно получить список инструментов на сервере. Для каждого инструмента выводим его имя.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

В этом коде мы:

- Вызвали `listTools()` для получения всех доступных инструментов MCP сервера
- Использовали `ping()` для проверки соединения с сервером
- `ListToolsResult` содержит информацию обо всех инструментах, включая имена, описания и схемы входных данных

Отлично, теперь мы получили все функции. Но когда их использовать? Этот клиент довольно простой — функции нужно вызывать явно, когда они нужны. В следующей главе мы создадим более продвинутого клиента с собственным большим языковым моделем (LLM). А пока посмотрим, как вызывать функции сервера:

### -4- Вызов функций

Чтобы вызвать функции, нужно правильно указать аргументы и, в некоторых случаях, имя вызываемой функции.

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

В этом коде мы:

- Читаем ресурс, вызывая `readResource()` с указанием `uri`. Вот как это примерно выглядит на сервере:

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

    Значение `uri` — `file://example.txt` — соответствует шаблону `file://{name}` на сервере. `example.txt` будет сопоставлено с `name`.

- Вызываем инструмент, указывая его `name` и `arguments`:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Получаем подсказку, вызывая `getPrompt()` с `name` и `arguments`. Код сервера выглядит так:

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

    Соответственно, клиентский код будет таким, чтобы соответствовать серверной декларации:

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

В этом коде мы:

- Вызвали ресурс `greeting` через `read_resource`
- Вызвали инструмент `add` через `call_tool`

### .NET

1. Добавим код для вызова инструмента:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. Чтобы вывести результат, используем следующий код:

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

В этом коде мы:

- Вызвали несколько калькуляторных инструментов через метод `callTool()` с объектами `CallToolRequest`
- Для каждого вызова указываем имя инструмента и `Map` с аргументами, необходимыми для работы инструмента
- Серверные инструменты ожидают конкретные имена параметров (например, "a", "b" для математических операций)
- Результаты возвращаются в объектах `CallToolResult`, содержащих ответ сервера

### -5- Запуск клиента

Чтобы запустить клиента, введите следующую команду в терминале:

### TypeScript

Добавьте следующую запись в раздел "scripts" файла *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Запустите клиента командой:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Сначала убедитесь, что MCP сервер запущен на `http://localhost:8080`. Затем запустите клиента:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Или запустите готовый проект клиента из папки решения `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Задание

В этом задании вы примените полученные знания для создания собственного клиента.

Вот сервер, который вы можете использовать и вызывать через ваш клиентский код. Попробуйте добавить новые функции на сервер, чтобы сделать его интереснее.

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

Посмотрите этот проект, чтобы узнать, как [добавлять подсказки и ресурсы](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Также ознакомьтесь с этим [руководством по вызову подсказок и ресурсов](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Решение

**Папка решения** содержит готовые к запуску реализации клиентов, демонстрирующие все концепции, рассмотренные в этом уроке. Каждое решение включает код клиента и сервера, организованный в отдельные, автономные проекты.

### 📁 Структура решения

Директория решения организована по языкам программирования:

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

### 🚀 Что включает каждое решение

Каждое решение для конкретного языка содержит:

- **Полную реализацию клиента** со всеми функциями из урока
- **Рабочую структуру проекта** с нужными зависимостями и настройками
- **Скрипты сборки и запуска** для удобной настройки и запуска
- **Подробный README** с инструкциями для конкретного языка
- **Обработку ошибок** и примеры обработки результатов

### 📖 Использование решений

1. **Перейдите в папку с нужным языком**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Следуйте инструкциям в README** каждой папки для:
   - Установки зависимостей
   - Сборки проекта
   - Запуска клиента

3. **Пример вывода, который вы должны увидеть**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Для полной документации и пошаговых инструкций смотрите: **[📖 Документация решения](./solution/README.md)**

## 🎯 Полные примеры

Мы предоставили готовые, рабочие реализации клиентов для всех языков программирования, рассмотренных в этом уроке. Эти примеры демонстрируют полный функционал, описанный выше, и могут служить эталонными реализациями или отправной точкой для ваших проектов.

### Доступные полные примеры

| Язык     | Файл                          | Описание                                                        |
|----------|-------------------------------|-----------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Полный Java клиент с SSE транспортом и подробной обработкой ошибок |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Полный C# клиент с stdio транспортом и автоматическим запуском сервера |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Полный TypeScript клиент с полной поддержкой MCP протокола       |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Полный Python клиент с использованием async/await паттернов       |

Каждый полный пример включает:

- ✅ **Установление соединения** и обработку ошибок
- ✅ **Обнаружение сервера** (инструменты, ресурсы, подсказки, где применимо)
- ✅ **Операции калькулятора** (сложение, вычитание, умножение, деление, помощь)
- ✅ **Обработку результатов** и форматированный вывод
- ✅ **Полную обработку ошибок**
- ✅ **Чистый, документированный код** с пошаговыми комментариями

### Начало работы с полными примерами

1. **Выберите предпочитаемый язык** из таблицы выше
2. **Изучите полный пример** для понимания полной реализации
3. **Запустите пример** согласно инструкциям в [`complete_examples.md`](./complete_examples.md)
4. **Модифицируйте и расширяйте** пример под свои задачи

Для подробной документации по запуску и настройке этих примеров смотрите: **[📖 Документация полных примеров](./complete_examples.md)**

### 💡 Решение vs. Полные примеры

| **Папка решения**           | **Полные примеры**           |
|----------------------------|-----------------------------|
| Полная структура проекта с файлами сборки | Однофайловые реализации       |
| Готово к запуску с зависимостями          | Фокус на примерах кода         |
| Настройка, приближенная к продакшену      | Образовательные эталоны        |
| Инструменты, специфичные для языка        | Сравнение между языками        |
Оба подхода ценны — используйте **папку решения** для полноценных проектов и **полные примеры** для обучения и справки.  
## Основные выводы

Основные выводы по этой главе о клиентах:

- Могут использоваться как для обнаружения, так и для вызова функций на сервере.  
- Могут запускать сервер вместе с собой (как в этой главе), но клиенты также могут подключаться к уже запущенным серверам.  
- Отличный способ проверить возможности сервера наряду с альтернативами, такими как Inspector, описанными в предыдущей главе.

## Дополнительные ресурсы

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Примеры

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Что дальше

- Далее: [Creating a client with an LLM](../03-llm-client/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному человеческому переводу. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.