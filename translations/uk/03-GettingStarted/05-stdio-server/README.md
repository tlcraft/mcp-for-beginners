<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:56:50+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "uk"
}
-->
# MCP Сервер зі stdio транспортом

> **⚠️ Важливе оновлення**: Починаючи з MCP Специфікації 2025-06-18, окремий транспорт SSE (Server-Sent Events) був **застарілим** і замінений на транспорт "Streamable HTTP". Поточна специфікація MCP визначає два основні механізми транспорту:
> 1. **stdio** - Стандартний ввід/вивід (рекомендовано для локальних серверів)
> 2. **Streamable HTTP** - Для віддалених серверів, які можуть використовувати SSE внутрішньо
>
> Цей урок оновлено, щоб зосередитися на **stdio транспорті**, який є рекомендованим підходом для більшості реалізацій MCP серверів.

Stdio транспорт дозволяє MCP серверам спілкуватися з клієнтами через стандартні потоки вводу та виводу. Це найбільш поширений і рекомендований механізм транспорту в поточній специфікації MCP, який забезпечує простий і ефективний спосіб створення MCP серверів, що легко інтегруються з різними клієнтськими додатками.

## Огляд

Цей урок охоплює створення та використання MCP серверів за допомогою stdio транспорту.

## Цілі навчання

До кінця цього уроку ви зможете:

- Створювати MCP сервер за допомогою stdio транспорту.
- Налагоджувати MCP сервер за допомогою Інспектора.
- Використовувати MCP сервер у Visual Studio Code.
- Розуміти поточні механізми транспорту MCP і чому stdio є рекомендованим.

## stdio Транспорт - Як це працює

Stdio транспорт є одним із двох підтримуваних типів транспорту в поточній специфікації MCP (2025-06-18). Ось як це працює:

- **Просте спілкування**: Сервер читає JSON-RPC повідомлення зі стандартного вводу (`stdin`) і надсилає повідомлення до стандартного виводу (`stdout`).
- **Процесна модель**: Клієнт запускає MCP сервер як підпроцес.
- **Формат повідомлень**: Повідомлення є окремими запитами, сповіщеннями або відповідями JSON-RPC, розділеними новими рядками.
- **Логування**: Сервер МОЖЕ записувати рядки UTF-8 до стандартного помилкового виводу (`stderr`) для логування.

### Основні вимоги:
- Повідомлення МАЮТЬ бути розділені новими рядками і НЕ МАЮТЬ містити вбудованих нових рядків.
- Сервер НЕ МАЄ записувати нічого до `stdout`, що не є дійсним MCP повідомленням.
- Клієнт НЕ МАЄ записувати нічого до `stdin` сервера, що не є дійсним MCP повідомленням.

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

У наведеному коді:

- Ми імпортуємо клас `Server` і `StdioServerTransport` з MCP SDK.
- Ми створюємо екземпляр сервера з базовою конфігурацією та можливостями.

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

У наведеному коді ми:

- Створюємо екземпляр сервера за допомогою MCP SDK.
- Визначаємо інструменти за допомогою декораторів.
- Використовуємо контекстний менеджер stdio_server для обробки транспорту.

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

Основна відмінність від SSE полягає в тому, що stdio сервери:

- Не потребують налаштування веб-сервера або HTTP кінцевих точок.
- Запускаються як підпроцеси клієнтом.
- Спілкуються через потоки stdin/stdout.
- Є простішими для реалізації та налагодження.

## Вправа: Створення stdio сервера

Щоб створити наш сервер, потрібно врахувати дві речі:

- Нам потрібно використовувати веб-сервер для відкриття кінцевих точок для з'єднання та повідомлень.

## Лабораторна робота: Створення простого MCP stdio сервера

У цій лабораторній роботі ми створимо простий MCP сервер, використовуючи рекомендований stdio транспорт. Цей сервер буде надавати інструменти, які клієнти можуть викликати за допомогою стандартного протоколу Model Context Protocol.

### Передумови

- Python 3.8 або новіший.
- MCP Python SDK: `pip install mcp`.
- Базове розуміння асинхронного програмування.

Давайте почнемо створювати наш перший MCP stdio сервер:

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

## Основні відмінності від застарілого підходу SSE

**Stdio Транспорт (Поточний стандарт):**
- Проста модель підпроцесів - клієнт запускає сервер як дочірній процес.
- Спілкування через stdin/stdout за допомогою JSON-RPC повідомлень.
- Не потрібне налаштування веб-сервера.
- Краща продуктивність і безпека.
- Просте налагодження та розробка.

**SSE Транспорт (Застарілий з MCP 2025-06-18):**
- Потребував веб-сервера з SSE кінцевими точками.
- Більш складне налаштування з інфраструктурою веб-сервера.
- Додаткові міркування щодо безпеки для HTTP кінцевих точок.
- Зараз замінений на Streamable HTTP для веб-сценаріїв.

### Створення сервера зі stdio транспортом

Щоб створити наш stdio сервер, нам потрібно:

1. **Імпортувати необхідні бібліотеки** - Нам потрібні компоненти MCP сервера та stdio транспорту.
2. **Створити екземпляр сервера** - Визначити сервер з його можливостями.
3. **Визначити інструменти** - Додати функціональність, яку ми хочемо надати.
4. **Налаштувати транспорт** - Конфігурувати stdio спілкування.
5. **Запустити сервер** - Запустити сервер і обробляти повідомлення.

Давайте створимо це крок за кроком:

### Крок 1: Створення базового stdio сервера

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

### Крок 2: Додавання більше інструментів

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

### Крок 3: Запуск сервера

Збережіть код як `server.py` і запустіть його з командного рядка:

```bash
python server.py
```

Сервер запуститься і чекатиме вводу через stdin. Він спілкується за допомогою JSON-RPC повідомлень через stdio транспорт.

### Крок 4: Тестування за допомогою Інспектора

Ви можете протестувати ваш сервер за допомогою MCP Інспектора:

1. Встановіть Інспектор: `npx @modelcontextprotocol/inspector`.
2. Запустіть Інспектор і вкажіть його на ваш сервер.
3. Протестуйте створені вами інструменти.

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

// Додати інструменти
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Отримати персоналізоване привітання",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Ім'я людини для привітання",
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
          text: `Привіт, ${request.params.arguments?.name}! Ласкаво просимо до MCP stdio сервера.`,
        },
      ],
    };
  } else {
    throw new Error(`Невідомий інструмент: ${request.params.name}`);
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
    [Description("Отримати персоналізоване привітання")]
    public string GetGreeting(string name)
    {
        return $"Привіт, {name}! Ласкаво просимо до MCP stdio сервера.";
    }

    [Description("Обчислити суму двох чисел")]
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

1. Спочатку створимо кілька інструментів, для цього створимо файл *Tools.cs* з наступним вмістом:

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

2. **Відкрийте веб-інтерфейс**: Інспектор відкриє вікно браузера, показуючи можливості вашого сервера.

3. **Протестуйте інструменти**: 
   - Спробуйте інструмент `get_greeting` з різними іменами.
   - Протестуйте інструмент `calculate_sum` з різними числами.
   - Викличте інструмент `get_server_info`, щоб побачити метадані сервера.

4. **Моніторинг спілкування**: Інспектор показує JSON-RPC повідомлення, які обмінюються між клієнтом і сервером.

### Що ви повинні побачити

Коли ваш сервер успішно запуститься, ви побачите:
- Список можливостей сервера в Інспекторі.
- Інструменти, доступні для тестування.
- Успішний обмін JSON-RPC повідомленнями.
- Відповіді інструментів, відображені в інтерфейсі.

### Поширені проблеми та рішення

**Сервер не запускається:**
- Перевірте, чи всі залежності встановлені: `pip install mcp`.
- Переконайтеся у правильності синтаксису Python та відступів.
- Перегляньте повідомлення про помилки в консолі.

**Інструменти не з'являються:**
- Переконайтеся, що присутні декоратори `@server.tool()`.
- Перевірте, чи функції інструментів визначені перед `main()`.
- Переконайтеся, що сервер правильно налаштований.

**Проблеми з підключенням:**
- Переконайтеся, що сервер правильно використовує stdio транспорт.
- Перевірте, чи інші процеси не заважають.
- Перевірте синтаксис команди Інспектора.

## Завдання

Спробуйте розширити ваш сервер, додавши більше можливостей. Наприклад, використовуйте [цю сторінку](https://api.chucknorris.io/), щоб додати інструмент, який викликає API. Ви вирішуєте, як має виглядати сервер. Удачі :)

## Рішення

[Рішення](./solution/README.md) Ось можливе рішення з робочим кодом.

## Основні висновки

Основні висновки з цього розділу:

- Stdio транспорт є рекомендованим механізмом для локальних MCP серверів.
- Stdio транспорт дозволяє безперешкодне спілкування між MCP серверами та клієнтами за допомогою стандартних потоків вводу та виводу.
- Ви можете використовувати як Інспектор, так і Visual Studio Code для прямого використання stdio серверів, що робить налагодження та інтеграцію простими.

## Зразки 

- [Java Калькулятор](../samples/java/calculator/README.md)
- [.Net Калькулятор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Калькулятор](../samples/javascript/README.md)
- [TypeScript Калькулятор](../samples/typescript/README.md)
- [Python Калькулятор](../../../../03-GettingStarted/samples/python) 

## Додаткові ресурси

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Що далі

## Наступні кроки

Тепер, коли ви дізналися, як створювати MCP сервери зі stdio транспортом, ви можете дослідити більш складні теми:

- **Далі**: [HTTP Streaming з MCP (Streamable HTTP)](../06-http-streaming/README.md) - Дізнайтеся про інший підтримуваний механізм транспорту для віддалених серверів.
- **Розширено**: [Найкращі практики безпеки MCP](../../02-Security/README.md) - Реалізуйте безпеку у ваших MCP серверах.
- **Виробництво**: [Стратегії розгортання](../09-deployment/README.md) - Розгорніть ваші сервери для використання у виробництві.

## Додаткові ресурси

- [MCP Специфікація 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Офіційна специфікація.
- [Документація MCP SDK](https://github.com/modelcontextprotocol/sdk) - Посилання на SDK для всіх мов.
- [Приклади спільноти](../../06-CommunityContributions/README.md) - Більше прикладів серверів від спільноти.

---

**Відмова від відповідальності**:  
Цей документ був перекладений за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ на його рідній мові слід вважати авторитетним джерелом. Для критичної інформації рекомендується професійний людський переклад. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникають внаслідок використання цього перекладу.