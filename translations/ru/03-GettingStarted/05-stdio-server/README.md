<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:17:41+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "ru"
}
-->
# MCP Server с транспортом stdio

> **⚠️ Важное обновление**: Начиная с MCP Specification 2025-06-18, отдельный транспорт SSE (Server-Sent Events) был **устаревшим** и заменен на транспорт "Streamable HTTP". Текущая спецификация MCP определяет два основных механизма транспорта:
> 1. **stdio** - Стандартный ввод/вывод (рекомендуется для локальных серверов)
> 2. **Streamable HTTP** - Для удаленных серверов, которые могут использовать SSE внутри
>
> Этот урок обновлен, чтобы сосредоточиться на **транспорте stdio**, который является рекомендуемым подходом для большинства реализаций MCP серверов.

Транспорт stdio позволяет MCP серверам взаимодействовать с клиентами через потоки стандартного ввода и вывода. Это наиболее часто используемый и рекомендуемый механизм транспорта в текущей спецификации MCP, обеспечивающий простой и эффективный способ создания MCP серверов, которые легко интегрируются с различными клиентскими приложениями.

## Обзор

Этот урок охватывает создание и использование MCP серверов с использованием транспорта stdio.

## Цели обучения

К концу этого урока вы сможете:

- Создавать MCP сервер с использованием транспорта stdio.
- Отлаживать MCP сервер с помощью Inspector.
- Использовать MCP сервер в Visual Studio Code.
- Понять текущие механизмы транспорта MCP и почему рекомендуется stdio.

## Транспорт stdio - Как это работает

Транспорт stdio является одним из двух поддерживаемых типов транспорта в текущей спецификации MCP (2025-06-18). Вот как он работает:

- **Простая коммуникация**: Сервер читает сообщения JSON-RPC из стандартного ввода (`stdin`) и отправляет сообщения в стандартный вывод (`stdout`).
- **Процессная модель**: Клиент запускает MCP сервер как подпроцесс.
- **Формат сообщений**: Сообщения представляют собой отдельные запросы, уведомления или ответы JSON-RPC, разделенные символами новой строки.
- **Логирование**: Сервер МОЖЕТ записывать строки в формате UTF-8 в стандартный поток ошибок (`stderr`) для целей логирования.

### Основные требования:
- Сообщения ДОЛЖНЫ быть разделены символами новой строки и НЕ ДОЛЖНЫ содержать встроенные символы новой строки.
- Сервер НЕ ДОЛЖЕН записывать в `stdout` ничего, кроме валидных сообщений MCP.
- Клиент НЕ ДОЛЖЕН записывать в `stdin` сервера ничего, кроме валидных сообщений MCP.

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

В приведенном выше коде:

- Мы импортируем классы `Server` и `StdioServerTransport` из MCP SDK.
- Мы создаем экземпляр сервера с базовой конфигурацией и возможностями.

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

В приведенном выше коде мы:

- Создаем экземпляр сервера с использованием MCP SDK.
- Определяем инструменты с помощью декораторов.
- Используем контекстный менеджер stdio_server для обработки транспорта.

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

Ключевое отличие от SSE заключается в том, что stdio серверы:

- Не требуют настройки веб-сервера или HTTP-эндпоинтов.
- Запускаются как подпроцессы клиентом.
- Общаются через потоки stdin/stdout.
- Проще в реализации и отладке.

## Упражнение: Создание сервера stdio

Для создания нашего сервера нужно учитывать два момента:

- Нам нужно использовать веб-сервер для предоставления эндпоинтов для подключения и сообщений.

## Лабораторная работа: Создание простого MCP сервера stdio

В этой лабораторной работе мы создадим простой MCP сервер с использованием рекомендуемого транспорта stdio. Этот сервер будет предоставлять инструменты, которые клиенты могут вызывать с использованием стандартного протокола Model Context Protocol.

### Предварительные требования

- Python 3.8 или новее.
- MCP Python SDK: `pip install mcp`.
- Базовое понимание асинхронного программирования.

Начнем с создания нашего первого MCP сервера stdio:

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

## Основные отличия от устаревшего подхода SSE

**Транспорт stdio (текущий стандарт):**
- Простая модель подпроцесса - клиент запускает сервер как дочерний процесс.
- Коммуникация через stdin/stdout с использованием сообщений JSON-RPC.
- Не требуется настройка веб-сервера.
- Лучшая производительность и безопасность.
- Проще в отладке и разработке.

**Транспорт SSE (устарел с MCP 2025-06-18):**
- Требовал веб-сервера с SSE-эндпоинтами.
- Более сложная настройка с инфраструктурой веб-сервера.
- Дополнительные соображения безопасности для HTTP-эндпоинтов.
- Теперь заменен на Streamable HTTP для веб-сценариев.

### Создание сервера с транспортом stdio

Чтобы создать сервер stdio, нужно:

1. **Импортировать необходимые библиотеки** - Нам понадобятся компоненты MCP сервера и транспорт stdio.
2. **Создать экземпляр сервера** - Определить сервер с его возможностями.
3. **Определить инструменты** - Добавить функциональность, которую мы хотим предоставить.
4. **Настроить транспорт** - Конфигурировать коммуникацию через stdio.
5. **Запустить сервер** - Запустить сервер и обрабатывать сообщения.

Давайте создадим это шаг за шагом:

### Шаг 1: Создание базового сервера stdio

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

### Шаг 2: Добавление дополнительных инструментов

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

### Шаг 3: Запуск сервера

Сохраните код как `server.py` и запустите его из командной строки:

```bash
python server.py
```

Сервер запустится и будет ожидать ввода через stdin. Он общается с использованием сообщений JSON-RPC через транспорт stdio.

### Шаг 4: Тестирование с помощью Inspector

Вы можете протестировать ваш сервер с помощью MCP Inspector:

1. Установите Inspector: `npx @modelcontextprotocol/inspector`.
2. Запустите Inspector и укажите путь к вашему серверу.
3. Протестируйте созданные инструменты.

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

// Add tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Получить персонализированное приветствие",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Имя человека, которому адресовано приветствие",
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
          text: `Привет, ${request.params.arguments?.name}! Добро пожаловать на MCP сервер stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Неизвестный инструмент: ${request.params.name}`);
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
    [Description("Получить персонализированное приветствие")]
    public string GetGreeting(string name)
    {
        return $"Привет, {name}! Добро пожаловать на MCP сервер stdio.";
    }

    [Description("Вычислить сумму двух чисел")]
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

1. Сначала создадим несколько инструментов, для этого создадим файл *Tools.cs* со следующим содержимым:

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

2. **Откройте веб-интерфейс**: Inspector откроет окно браузера, показывающее возможности вашего сервера.

3. **Протестируйте инструменты**: 
   - Попробуйте инструмент `get_greeting` с разными именами.
   - Протестируйте инструмент `calculate_sum` с различными числами.
   - Вызовите инструмент `get_server_info`, чтобы увидеть метаданные сервера.

4. **Отслеживайте коммуникацию**: Inspector показывает сообщения JSON-RPC, обмениваемые между клиентом и сервером.

### Что вы должны увидеть

Когда ваш сервер успешно запустится, вы увидите:
- Список возможностей сервера в Inspector.
- Доступные инструменты для тестирования.
- Успешный обмен сообщениями JSON-RPC.
- Ответы инструментов, отображаемые в интерфейсе.

### Частые проблемы и их решения

**Сервер не запускается:**
- Проверьте, что все зависимости установлены: `pip install mcp`.
- Убедитесь в правильности синтаксиса Python и отступов.
- Проверьте сообщения об ошибках в консоли.

**Инструменты не отображаются:**
- Убедитесь, что декораторы `@server.tool()` присутствуют.
- Проверьте, что функции инструментов определены до `main()`.
- Убедитесь, что сервер правильно настроен.

**Проблемы с подключением:**
- Убедитесь, что сервер правильно использует транспорт stdio.
- Проверьте, что другие процессы не мешают.
- Убедитесь в правильности синтаксиса команды Inspector.

## Задание

Попробуйте расширить ваш сервер, добавив больше возможностей. Например, используйте [эту страницу](https://api.chucknorris.io/), чтобы добавить инструмент, который вызывает API. Вы сами решаете, как должен выглядеть сервер. Удачи :)

## Решение

[Решение](./solution/README.md) Вот возможное решение с рабочим кодом.

## Основные выводы

Основные выводы из этой главы:

- Транспорт stdio является рекомендуемым механизмом для локальных MCP серверов.
- Транспорт stdio позволяет бесшовно взаимодействовать между MCP серверами и клиентами с использованием потоков стандартного ввода и вывода.
- Вы можете использовать как Inspector, так и Visual Studio Code для непосредственного использования серверов stdio, что упрощает отладку и интеграцию.

## Примеры 

- [Калькулятор на Java](../samples/java/calculator/README.md)
- [Калькулятор на .Net](../../../../03-GettingStarted/samples/csharp)
- [Калькулятор на JavaScript](../samples/javascript/README.md)
- [Калькулятор на TypeScript](../samples/typescript/README.md)
- [Калькулятор на Python](../../../../03-GettingStarted/samples/python) 

## Дополнительные ресурсы

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Что дальше

## Следующие шаги

Теперь, когда вы узнали, как создавать MCP серверы с транспортом stdio, вы можете изучить более продвинутые темы:

- **Далее**: [HTTP Streaming с MCP (Streamable HTTP)](../06-http-streaming/README.md) - Узнайте о другом поддерживаемом механизме транспорта для удаленных серверов.
- **Продвинутое**: [Лучшие практики безопасности MCP](../../02-Security/README.md) - Реализуйте безопасность в ваших MCP серверах.
- **В продакшн**: [Стратегии развертывания](../09-deployment/README.md) - Разверните ваши серверы для использования в продакшене.

## Дополнительные ресурсы

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Официальная спецификация.
- [Документация MCP SDK](https://github.com/modelcontextprotocol/sdk) - Справочные материалы по SDK для всех языков.
- [Примеры сообщества](../../06-CommunityContributions/README.md) - Больше примеров серверов от сообщества.

---

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные интерпретации, возникшие в результате использования данного перевода.