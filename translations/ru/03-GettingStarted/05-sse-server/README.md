<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T23:29:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ru"
}
-->
# SSE Сервер

SSE (Server Sent Events) — это стандарт для потоковой передачи данных от сервера к клиенту, позволяющий серверам отправлять обновления в реальном времени через HTTP. Это особенно полезно для приложений, которым нужны живые обновления, таких как чаты, уведомления или потоки данных в реальном времени. Кроме того, ваш сервер может обслуживать сразу несколько клиентов, так как он работает на сервере, который, например, может быть размещён в облаке.

## Обзор

В этом уроке мы рассмотрим, как создавать и использовать SSE серверы.

## Цели обучения

К концу этого урока вы сможете:

- Создавать SSE сервер.
- Отлаживать SSE сервер с помощью Inspector.
- Использовать SSE сервер в Visual Studio Code.

## SSE, как это работает

SSE — один из двух поддерживаемых типов транспорта. Вы уже видели использование первого — stdio — в предыдущих уроках. Разница в следующем:

- SSE требует управления двумя вещами: соединением и сообщениями.
- Поскольку сервер может работать где угодно, это нужно учитывать при работе с такими инструментами, как Inspector и Visual Studio Code. Это значит, что вместо того, чтобы указывать, как запустить сервер, вы указываете конечную точку (endpoint), к которой можно подключиться. Пример кода ниже:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

В приведённом коде:

- `/sse` настроен как маршрут. При запросе к этому маршруту создаётся новый экземпляр транспорта, и сервер *подключается* через этот транспорт.
- `/messages` — маршрут, который обрабатывает входящие сообщения.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

В этом коде мы:

- Создаём экземпляр ASGI сервера (конкретно Starlette) и монтируем маршрут по умолчанию `/`.

  За кулисами маршруты `/sse` и `/messages` настроены для обработки соединений и сообщений соответственно. Остальная часть приложения, например добавление инструментов, работает так же, как и с stdio серверами.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Есть два метода, которые помогают превратить веб-сервер в сервер с поддержкой SSE:

    - `AddMcpServer` — добавляет необходимые возможности.
    - `MapMcp` — добавляет маршруты, такие как `/SSE` и `/messages`.

Теперь, когда мы немного разобрались с SSE, давайте создадим SSE сервер.

## Упражнение: Создание SSE сервера

Для создания сервера нужно помнить о двух вещах:

- Нужно использовать веб-сервер для открытия конечных точек для соединения и сообщений.
- Строить сервер так же, как мы делали с stdio — с инструментами, ресурсами и подсказками.

### -1- Создание экземпляра сервера

Для создания сервера используем те же типы, что и с stdio. Но для транспорта выбираем SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

В этом коде мы:

- Создали экземпляр сервера.
- Определили приложение с использованием веб-фреймворка express.
- Создали переменную transports для хранения входящих соединений.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

В этом коде мы:

- Импортировали необходимые библиотеки, включая Starlette (ASGI фреймворк).
- Создали экземпляр MCP сервера `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

На этом этапе мы:

- Создали веб-приложение.
- Добавили поддержку MCP через `AddMcpServer`.

Далее добавим необходимые маршруты.

### -2- Добавление маршрутов

Добавим маршруты для обработки соединений и входящих сообщений:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

В этом коде мы определили:

- Маршрут `/sse`, который создаёт транспорт типа SSE и вызывает `connect` на MCP сервере.
- Маршрут `/messages`, который обрабатывает входящие сообщения.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

В этом коде мы:

- Создали экземпляр ASGI приложения с использованием Starlette. В список маршрутов передали `mcp.sse_app()`, что монтирует маршруты `/sse` и `/messages` в приложение.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Мы добавили строку `add.MapMcp()`, что означает наличие маршрутов `/SSE` и `/messages`.

Теперь добавим возможности серверу.

### -3- Добавление возможностей серверу

Теперь, когда всё, что связано с SSE, определено, добавим возможности сервера — инструменты, подсказки и ресурсы.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Вот пример добавления инструмента. Этот инструмент создаёт вызов "random-joke", который обращается к API Чака Норриса и возвращает JSON ответ.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Теперь у вашего сервера есть один инструмент.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Сначала создадим инструменты, для этого создадим файл *Tools.cs* со следующим содержимым:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Здесь мы:

  - Создали класс `Tools` с декоратором `McpServerToolType`.
  - Определили инструмент `AddNumbers`, оформив метод с помощью `McpServerTool`. Также задали параметры и реализацию.

1. Используем класс `Tools`, который только что создали:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Мы добавили вызов `WithTools`, указав класс `Tools` как содержащий инструменты. Всё, сервер готов.

Отлично, у нас есть сервер на SSE, давайте его протестируем.

## Упражнение: Отладка SSE сервера с Inspector

Inspector — отличный инструмент, который мы уже видели в предыдущем уроке [Создание вашего первого сервера](/03-GettingStarted/01-first-server/README.md). Посмотрим, можно ли использовать Inspector и здесь:

### -1- Запуск Inspector

Для запуска Inspector сначала нужно запустить SSE сервер, сделаем это:

1. Запустите сервер

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Обратите внимание, что мы используем исполняемый файл `uvicorn`, который устанавливается при вводе `pip install "mcp[cli]"`. Команда `server:app` означает, что мы запускаем файл `server.py`, в котором есть экземпляр Starlette с именем `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Это запустит сервер. Для взаимодействия с ним откройте новое окно терминала.

1. Запустите Inspector

    > ![NOTE]
    > Запускайте это в отдельном окне терминала, отличном от того, где запущен сервер. Также обратите внимание, что нужно подстроить команду под URL, по которому работает ваш сервер.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Запуск Inspector одинаков во всех средах. Обратите внимание, что вместо передачи пути к серверу и команды запуска, мы передаём URL, где работает сервер, и указываем маршрут `/sse`.

### -2- Проверка инструмента

Подключитесь к серверу, выбрав SSE в выпадающем списке, и введите URL, где работает сервер, например http://localhost:4321/sse. Нажмите кнопку "Connect". Как и раньше, выберите список инструментов, выберите инструмент и введите значения. Вы должны увидеть результат, похожий на изображение ниже:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ru.png)

Отлично, вы можете работать с Inspector, теперь посмотрим, как работать с Visual Studio Code.

## Задание

Попробуйте расширить ваш сервер новыми возможностями. Посмотрите [эту страницу](https://api.chucknorris.io/), чтобы, например, добавить инструмент, который вызывает API. Решайте сами, каким должен быть ваш сервер. Удачи :)

## Решение

[Решение](./solution/README.md) Вот возможный вариант с рабочим кодом.

## Основные выводы

Основные выводы из этой главы:

- SSE — второй поддерживаемый транспорт после stdio.
- Для поддержки SSE нужно управлять входящими соединениями и сообщениями с помощью веб-фреймворка.
- Вы можете использовать как Inspector, так и Visual Studio Code для работы с SSE сервером, так же как и с stdio серверами. Обратите внимание, что есть небольшие отличия между stdio и SSE. Для SSE сервер нужно запускать отдельно, а затем запускать Inspector. Для Inspector также нужно указывать URL сервера.

## Примеры

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Дополнительные ресурсы

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Что дальше

- Далее: [HTTP Streaming с MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.