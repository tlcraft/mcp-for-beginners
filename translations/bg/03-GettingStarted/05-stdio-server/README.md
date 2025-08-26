<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:46:38+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "bg"
}
-->
# MCP Server със stdio транспорт

> **⚠️ Важна актуализация**: От MCP спецификацията 2025-06-18, самостоятелният SSE (Server-Sent Events) транспорт е **отхвърлен** и заменен с "Streamable HTTP" транспорт. Текущата MCP спецификация дефинира два основни транспортни механизма:
> 1. **stdio** - Стандартен вход/изход (препоръчителен за локални сървъри)
> 2. **Streamable HTTP** - За отдалечени сървъри, които могат да използват SSE вътрешно
>
> Този урок е актуализиран, за да се фокусира върху **stdio транспорт**, който е препоръчителният подход за повечето MCP сървърни реализации.

Stdio транспортът позволява MCP сървърите да комуникират с клиенти чрез стандартни входни и изходни потоци. Това е най-често използваният и препоръчителен транспортен механизъм в текущата MCP спецификация, предоставящ прост и ефективен начин за изграждане на MCP сървъри, които лесно могат да бъдат интегрирани с различни клиентски приложения.

## Общ преглед

Този урок обхваща как да изградите и използвате MCP сървъри със stdio транспорт.

## Цели на обучението

До края на този урок ще можете:

- Да изградите MCP сървър със stdio транспорт.
- Да дебъгвате MCP сървър с помощта на Inspector.
- Да използвате MCP сървър с Visual Studio Code.
- Да разберете текущите MCP транспортни механизми и защо stdio е препоръчителен.

## stdio транспорт - Как работи

Stdio транспортът е един от двата поддържани типа транспорт в текущата MCP спецификация (2025-06-18). Ето как работи:

- **Проста комуникация**: Сървърът чете JSON-RPC съобщения от стандартния вход (`stdin`) и изпраща съобщения към стандартния изход (`stdout`).
- **Процесно-базиран**: Клиентът стартира MCP сървъра като подпроцес.
- **Формат на съобщенията**: Съобщенията са индивидуални JSON-RPC заявки, известия или отговори, разделени с нов ред.
- **Логване**: Сървърът МОЖЕ да записва UTF-8 низове към стандартния грешка (`stderr`) за целите на логването.

### Основни изисквания:
- Съобщенията ТРЯБВА да бъдат разделени с нов ред и НЕ ТРЯБВА да съдържат вложени нови редове.
- Сървърът НЕ ТРЯБВА да записва нищо в `stdout`, което не е валидно MCP съобщение.
- Клиентът НЕ ТРЯБВА да записва нищо в `stdin` на сървъра, което не е валидно MCP съобщение.

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

В предходния код:

- Импортираме класа `Server` и `StdioServerTransport` от MCP SDK.
- Създаваме инстанция на сървър с основна конфигурация и възможности.

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

В предходния код:

- Създаваме инстанция на сървър с MCP SDK.
- Дефинираме инструменти с помощта на декоратори.
- Използваме контекстния мениджър stdio_server за управление на транспорта.

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

Основната разлика от SSE е, че stdio сървърите:

- Не изискват настройка на уеб сървър или HTTP крайни точки.
- Се стартират като подпроцеси от клиента.
- Комуникират чрез stdin/stdout потоци.
- Са по-прости за имплементация и дебъгване.

## Упражнение: Създаване на stdio сървър

За да създадем нашия сървър, трябва да имаме предвид две неща:

- Трябва да използваме уеб сървър за излагане на крайни точки за връзка и съобщения.

## Лаборатория: Създаване на прост MCP stdio сървър

В тази лаборатория ще създадем прост MCP сървър, използвайки препоръчания stdio транспорт. Този сървър ще излага инструменти, които клиентите могат да извикват, използвайки стандартния Model Context Protocol.

### Предварителни изисквания

- Python 3.8 или по-нова версия.
- MCP Python SDK: `pip install mcp`.
- Основно разбиране на асинхронното програмиране.

Нека започнем със създаването на нашия първи MCP stdio сървър:

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

## Основни разлики от отхвърления SSE подход

**Stdio транспорт (текущ стандарт):**
- Прост модел на подпроцеси - клиентът стартира сървъра като дъщерен процес.
- Комуникация чрез stdin/stdout, използвайки JSON-RPC съобщения.
- Не се изисква настройка на HTTP сървър.
- По-добра производителност и сигурност.
- По-лесно дебъгване и разработка.

**SSE транспорт (отхвърлен от MCP 2025-06-18):**
- Изискваше HTTP сървър с SSE крайни точки.
- По-сложна настройка с инфраструктура на уеб сървър.
- Допълнителни съображения за сигурност за HTTP крайни точки.
- Сега заменен със Streamable HTTP за уеб-базирани сценарии.

### Създаване на сървър със stdio транспорт

За да създадем нашия stdio сървър, трябва да:

1. **Импортираме необходимите библиотеки** - Нуждаем се от MCP сървърните компоненти и stdio транспорт.
2. **Създадем инстанция на сървър** - Дефинираме сървъра с неговите възможности.
3. **Дефинираме инструменти** - Добавяме функционалността, която искаме да изложим.
4. **Настроим транспорта** - Конфигурираме stdio комуникацията.
5. **Стартираме сървъра** - Започваме сървъра и обработваме съобщения.

Нека изградим това стъпка по стъпка:

### Стъпка 1: Създаване на основен stdio сървър

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

### Стъпка 2: Добавяне на повече инструменти

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

### Стъпка 3: Стартиране на сървъра

Запазете кода като `server.py` и го стартирайте от командния ред:

```bash
python server.py
```

Сървърът ще започне и ще чака вход от stdin. Той комуникира, използвайки JSON-RPC съобщения през stdio транспорт.

### Стъпка 4: Тестване с Inspector

Можете да тествате вашия сървър, използвайки MCP Inspector:

1. Инсталирайте Inspector: `npx @modelcontextprotocol/inspector`.
2. Стартирайте Inspector и го насочете към вашия сървър.
3. Тествайте инструментите, които сте създали.

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
        description: "Get a personalized greeting",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Name of the person to greet",
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
          text: `Hello, ${request.params.arguments?.name}! Welcome to MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Unknown tool: ${request.params.name}`);
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
    [Description("Get a personalized greeting")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Calculate the sum of two numbers")]
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

1. Нека първо създадем някои инструменти. За това ще създадем файл *Tools.cs* със следното съдържание:

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

2. **Отворете уеб интерфейса**: Inspector ще отвори прозорец на браузъра, показващ възможностите на вашия сървър.

3. **Тествайте инструментите**: 
   - Опитайте инструмента `get_greeting` с различни имена.
   - Тествайте инструмента `calculate_sum` с различни числа.
   - Извикайте инструмента `get_server_info`, за да видите метаданни на сървъра.

4. **Наблюдавайте комуникацията**: Inspector показва JSON-RPC съобщенията, които се обменят между клиента и сървъра.

### Какво трябва да видите

Когато вашият сървър стартира правилно, трябва да видите:
- Списък с възможностите на сървъра в Inspector.
- Инструменти, достъпни за тестване.
- Успешен обмен на JSON-RPC съобщения.
- Отговори от инструменти, показани в интерфейса.

### Чести проблеми и решения

**Сървърът не стартира:**
- Проверете дали всички зависимости са инсталирани: `pip install mcp`.
- Уверете се, че Python синтаксисът и отстъпите са правилни.
- Потърсете съобщения за грешки в конзолата.

**Инструментите не се появяват:**
- Уверете се, че декораторите `@server.tool()` са налични.
- Проверете дали функциите на инструментите са дефинирани преди `main()`.
- Уверете се, че сървърът е правилно конфигуриран.

**Проблеми с връзката:**
- Уверете се, че сървърът използва stdio транспорт правилно.
- Проверете дали няма други процеси, които пречат.
- Уверете се, че синтаксисът на командата Inspector е правилен.

## Задача

Опитайте да разширите вашия сървър с повече възможности. Вижте [тази страница](https://api.chucknorris.io/), за да добавите, например, инструмент, който извиква API. Вие решавате как да изглежда сървърът. Забавлявайте се :)

## Решение

[Решение](./solution/README.md) Ето възможно решение с работещ код.

## Основни изводи

Основните изводи от тази глава са следните:

- Stdio транспортът е препоръчителният механизъм за локални MCP сървъри.
- Stdio транспортът позволява безпроблемна комуникация между MCP сървъри и клиенти, използвайки стандартни входни и изходни потоци.
- Можете да използвате както Inspector, така и Visual Studio Code, за да използвате stdio сървъри директно, което прави дебъгването и интеграцията лесни.

## Примери 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Допълнителни ресурси

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Какво следва

## Следващи стъпки

Сега, когато сте научили как да изграждате MCP сървъри със stdio транспорт, можете да изследвате по-напреднали теми:

- **Следващо**: [HTTP Streaming с MCP (Streamable HTTP)](../06-http-streaming/README.md) - Научете за другия поддържан транспортен механизъм за отдалечени сървъри.
- **Напреднали**: [MCP Security Best Practices](../../02-Security/README.md) - Имплементирайте сигурност във вашите MCP сървъри.
- **Производство**: [Deployment Strategies](../09-deployment/README.md) - Разгърнете вашите сървъри за производствена употреба.

## Допълнителни ресурси

- [MCP Спецификация 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Официална спецификация.
- [MCP SDK Документация](https://github.com/modelcontextprotocol/sdk) - SDK референции за всички езици.
- [Примери от общността](../../06-CommunityContributions/README.md) - Още примери за сървъри от общността.

---

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматичните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия изходен език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален превод от човек. Не носим отговорност за каквито и да било недоразумения или погрешни интерпретации, произтичащи от използването на този превод.