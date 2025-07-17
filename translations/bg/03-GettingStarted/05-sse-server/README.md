<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T11:36:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "bg"
}
-->
# SSE сървър

SSE (Server Sent Events) е стандарт за стрийминг от сървър към клиент, който позволява на сървърите да изпращат актуализации в реално време към клиентите през HTTP. Това е особено полезно за приложения, които изискват живи обновления, като чат приложения, известия или потоци с данни в реално време. Освен това, вашият сървър може да бъде използван от множество клиенти едновременно, тъй като работи на сървър, който може да бъде разположен например в облака.

## Преглед

Този урок обхваща как да изградите и използвате SSE сървъри.

## Учебни цели

Към края на този урок ще можете да:

- Създавате SSE сървър.
- Отстранявате грешки в SSE сървър с помощта на Inspector.
- Използвате SSE сървър с Visual Studio Code.

## SSE, как работи

SSE е един от двата поддържани типа транспорт. Вече сте виждали първия – stdio, използван в предишни уроци. Разликата е следната:

- SSE изисква да управлявате две неща: връзката и съобщенията.
- Тъй като това е сървър, който може да работи навсякъде, трябва това да се отрази в начина, по който работите с инструменти като Inspector и Visual Studio Code. Това означава, че вместо да посочвате как да стартирате сървъра, вие посочвате крайна точка, където може да се установи връзка. Вижте примерния код по-долу:

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

В горния код:

- `/sse` е настроен като маршрут. Когато се направи заявка към този маршрут, се създава нов транспортен екземпляр и сървърът *свързва* чрез този транспорт.
- `/messages` е маршрутът, който обработва входящите съобщения.

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

В горния код:

- Създаваме инстанция на ASGI сървър (специално с Starlette) и монтираме основния маршрут `/`.

  Това, което се случва зад кулисите, е, че маршрутите `/sse` и `/messages` са настроени да обработват връзки и съобщения съответно. Останалата част от приложението, като добавяне на функции и инструменти, се случва както при stdio сървърите.

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

    Има два метода, които ни помагат да преминем от уеб сървър към уеб сървър, поддържащ SSE, а именно:

    - `AddMcpServer` – този метод добавя възможности.
    - `MapMcp` – този добавя маршрути като `/SSE` и `/messages`.

Сега, когато знаем малко повече за SSE, нека изградим SSE сървър.

## Упражнение: Създаване на SSE сървър

За да създадем нашия сървър, трябва да имаме предвид две неща:

- Трябва да използваме уеб сървър, който да предоставя крайни точки за връзка и съобщения.
- Да изградим сървъра както обикновено с инструменти, ресурси и подсказки, както при използване на stdio.

### -1- Създаване на инстанция на сървъра

За да създадем сървъра, използваме същите типове като при stdio. Въпреки това, за транспорта трябва да изберем SSE.

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

В горния код сме:

- Създали инстанция на сървър.
- Дефинирали приложение с помощта на уеб фреймуърка express.
- Създали променлива transports, която ще използваме за съхранение на входящи връзки.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

В горния код сме:

- Импортирали нужните библиотеки, като използваме Starlette (ASGI фреймуърк).
- Създали MCP сървър инстанция `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Към този момент сме:

- Създали уеб приложение.
- Добавили поддръжка за MCP функции чрез `AddMcpServer`.

Нека добавим необходимите маршрути.

### -2- Добавяне на маршрути

Сега ще добавим маршрути, които обработват връзката и входящите съобщения:

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

В горния код сме дефинирали:

- Маршрут `/sse`, който създава транспорт от тип SSE и в крайна сметка извиква `connect` на MCP сървъра.
- Маршрут `/messages`, който се грижи за входящите съобщения.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

В горния код сме:

- Създали ASGI приложение с помощта на Starlette. Като част от това подаваме `mcp.sse_app()` в списъка с маршрути. Това монтира маршрутите `/sse` и `/messages` в приложението.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Добавили сме един ред код в края `add.MapMcp()`, което означава, че вече имаме маршрути `/SSE` и `/messages`.

Нека добавим възможности на сървъра.

### -3- Добавяне на възможности на сървъра

Сега, когато сме дефинирали всичко специфично за SSE, нека добавим възможности като инструменти, подсказки и ресурси.

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

Ето как можете да добавите инструмент, например. Този конкретен инструмент създава инструмент с име "random-joke", който извиква Chuck Norris API и връща JSON отговор.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Сега вашият сървър има един инструмент.

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

1. Нека първо създадем някои инструменти, за това ще създадем файл *Tools.cs* със следното съдържание:

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

  Тук сме добавили следното:

  - Създадена е клас `Tools` с декоратор `McpServerToolType`.
  - Дефиниран е инструмент `AddNumbers`, като методът е декориран с `McpServerTool`. Също така сме предоставили параметри и имплементация.

1. Нека използваме класа `Tools`, който току-що създадохме:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Добавили сме извикване на `WithTools`, което посочва `Tools` като клас, съдържащ инструментите. Това е всичко, готови сме.

Страхотно, имаме сървър, използващ SSE, нека го изпробваме.

## Упражнение: Отстраняване на грешки в SSE сървър с Inspector

Inspector е страхотен инструмент, който видяхме в предишен урок [Създаване на първия ви сървър](/03-GettingStarted/01-first-server/README.md). Нека видим дали можем да използваме Inspector и тук:

### -1- Стартиране на Inspector

За да стартирате Inspector, първо трябва да имате работещ SSE сървър, така че нека направим това:

1. Стартирайте сървъра

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Обърнете внимание, че използваме изпълнимия файл `uvicorn`, който се инсталира при командата `pip install "mcp[cli]"`. Когато пишем `server:app`, означава, че се опитваме да стартираме файл `server.py`, който съдържа Starlette инстанция с име `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Това трябва да стартира сървъра. За да взаимодействате с него, ви трябва нов терминал.

1. Стартирайте Inspector

    > ![NOTE]
    > Стартирайте това в отделен терминал от този, в който работи сървърът. Също така, имайте предвид, че трябва да коригирате командата по-долу, за да съответства на URL адреса, на който работи вашият сървър.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Стартирането на Inspector изглежда еднакво във всички среди. Обърнете внимание, че вместо да подаваме път към сървъра и команда за стартирането му, подаваме URL адреса, на който работи сървърът, и посочваме маршрута `/sse`.

### -2- Изпробване на инструмента

Свържете се със сървъра, като изберете SSE от падащото меню и попълните полето с URL адреса, на който работи вашият сървър, например http://localhost:4321/sse. След това натиснете бутона "Connect". Както преди, изберете да изброите инструментите, изберете инструмент и въведете стойности за вход. Трябва да видите резултат като този по-долу:

![SSE сървър работещ в Inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.bg.png)

Страхотно, можете да работите с Inspector, нека видим как да работим с Visual Studio Code.

## Задача

Опитайте да разширите сървъра си с повече възможности. Вижте [тази страница](https://api.chucknorris.io/), за да добавите например инструмент, който извиква API. Вие решавате как да изглежда сървърът. Забавлявайте се :)

## Решение

[Решение](./solution/README.md) Ето едно възможно решение с работещ код.

## Основни изводи

Основните изводи от тази глава са:

- SSE е вторият поддържан транспорт след stdio.
- За да поддържате SSE, трябва да управлявате входящи връзки и съобщения чрез уеб фреймуърк.
- Можете да използвате както Inspector, така и Visual Studio Code за работа със SSE сървър, както при stdio сървърите. Обърнете внимание, че има малки разлики между stdio и SSE. При SSE трябва първо да стартирате сървъра отделно и след това да стартирате инструмента Inspector. При Inspector има и разлики, тъй като трябва да посочите URL адреса.

## Примери

- [Java калкулатор](../samples/java/calculator/README.md)
- [.Net калкулатор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript калкулатор](../samples/javascript/README.md)
- [TypeScript калкулатор](../samples/typescript/README.md)
- [Python калкулатор](../../../../03-GettingStarted/samples/python)

## Допълнителни ресурси

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Какво следва

- Следва: [HTTP стрийминг с MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.