<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T17:38:56+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fa"
}
-->
# سرور SSE

SSE (Server Sent Events) یک استاندارد برای پخش داده‌ها از سرور به کلاینت است که به سرورها اجازه می‌دهد به‌روزرسانی‌های زنده را از طریق HTTP به کلاینت‌ها ارسال کنند. این روش به‌ویژه برای برنامه‌هایی که نیاز به به‌روزرسانی‌های لحظه‌ای دارند، مانند برنامه‌های چت، اعلان‌ها یا فیدهای داده زنده، بسیار مفید است. همچنین، سرور شما می‌تواند به‌طور همزمان توسط چندین کلاینت استفاده شود، زیرا روی سروری اجرا می‌شود که می‌تواند مثلاً در فضای ابری میزبانی شود.

## مرور کلی

در این درس نحوه ساخت و استفاده از سرورهای SSE را بررسی می‌کنیم.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- ساخت یک سرور SSE.
- اشکال‌زدایی سرور SSE با استفاده از Inspector.
- استفاده از سرور SSE با Visual Studio Code.

## SSE، چگونه کار می‌کند

SSE یکی از دو نوع انتقال پشتیبانی شده است. شما قبلاً نوع اول یعنی stdio را در درس‌های قبلی دیده‌اید. تفاوت‌ها به شرح زیر است:

- SSE نیاز دارد که دو مورد را مدیریت کنید؛ اتصال و پیام‌ها.
- از آنجا که این سرور می‌تواند در هر جایی اجرا شود، باید این موضوع در نحوه کار با ابزارهایی مانند Inspector و Visual Studio Code منعکس شود. یعنی به جای اینکه بگویید چگونه سرور را شروع کنید، باید به نقطه انتهایی (endpoint) اشاره کنید که اتصال برقرار می‌شود. نمونه کد زیر را ببینید:

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

در کد بالا:

- `/sse` به عنوان یک مسیر تنظیم شده است. وقتی درخواستی به این مسیر ارسال شود، یک نمونه جدید از transport ساخته می‌شود و سرور با استفاده از این transport *اتصال* برقرار می‌کند.
- `/messages` مسیری است که پیام‌های ورودی را مدیریت می‌کند.

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

در کد بالا:

- یک نمونه از سرور ASGI (به طور خاص Starlette) ساخته و مسیر پیش‌فرض `/` را نصب می‌کنیم.

  پشت صحنه، مسیرهای `/sse` و `/messages` برای مدیریت اتصال‌ها و پیام‌ها تنظیم می‌شوند. بقیه برنامه، مانند افزودن امکانات و ابزارها، مشابه سرورهای stdio انجام می‌شود.

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

    دو متد وجود دارد که به ما کمک می‌کند از یک وب‌سرور به وب‌سروری که SSE را پشتیبانی می‌کند برویم:

    - `AddMcpServer`، این متد قابلیت‌ها را اضافه می‌کند.
    - `MapMcp`، این متد مسیرهایی مانند `/SSE` و `/messages` را اضافه می‌کند.
```

Now that we know a little bit more about SSE, let's build an SSE server next.

## Exercise: Creating an SSE Server

To create our server, we need to keep two things in mind:

- We need to use a web server to expose endpoints for connection and messages.
- Build our server like we normally do with tools, resources and prompts when we were using stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to choose SSE.

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

In the preceding code we've:

- Created a server instance.
- Defined an app using the web framework express.
- Created a transports variable that we will use to store incoming connections.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In the preceding code we've:

- Imported the libraries we're going to need with Starlette (an ASGI framework) being pulled in.
- Created an MCP server instance `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

At this point, we've:

- Created a web app
- Added support for MCP features through `AddMcpServer`.

Let's add the needed routes next.

### -2- Add routes

Let's add routes next that handle the connection and incoming messages:

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

In the preceding code we've defined:

- An `/sse` route that instantiates a transport of type SSE and ends up calling `connect` on the MCP server.
- A `/messages` route that takes care of incoming messages.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In the preceding code we've:

- Created an ASGI app instance using the Starlette framework. As part of that we passes `mcp.sse_app()` to it's list of routes. That ends up mounting an `/sse` and `/messages` route on the app instance.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We've added one line of code at the end `add.MapMcp()` this means we now have routes `/SSE` and `/messages`. 

Let's add capabilties to the server next.

### -3- Adding server capabilities

Now that we've got everything SSE specific defined, let's add server capabilities like tools, prompts and resources.

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

Here's how you can add a tool for example. This specific tool creates a tool call "random-joke" that calls a Chuck Norris API and returns a JSON response.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Now your server has one tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// ایجاد یک سرور MCP
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

server.tool("random-joke", "یک جوک برگرفته از API چاک نوریس", {}, async () => {
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
    """دو عدد را جمع می‌کند"""
    return a + b

# نصب سرور SSE روی سرور ASGI موجود
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Let's create some tools first, for this we will create a file *Tools.cs* with the following content:

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

      [McpServerTool, Description("دو عدد را با هم جمع می‌کند.")]
      public async Task<string> AddNumbers(
          [Description("عدد اول")] int a,
          [Description("عدد دوم")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Here we've added the following:

  - Created a class `Tools` with the decorator `McpServerToolType`.
  - Defined a tool `AddNumbers` by decorating the method with `McpServerTool`. We've also provided parameters and an implementation.

1. Let's leverage the `Tools` class we just created:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We've added a call to `WithTools` that specifies `Tools` as the class containing the tools. That's it, we're ready.

Great, we have a server using SSE, let's take it for a spin next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a great tool that we saw in a previous lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's see if we can use the Inspector even here:

### -1- Running the inspector

To run the inspector, you first must have an SSE server running, so let's do that next:

1. Run the server 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note how we use the executable `uvicorn` that's installed when we typed `pip install "mcp[cli]"`. Typing `server:app` means we're trying to run a file `server.py` and for it to have a Starlette instance called `app`. 

    ### .NET

    ```sh
    dotnet run
    ```

    This should start the server. To interface with it you need a new terminal.

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window than the server is running in. Also note, you need to adjust the below command to fit the URL where your server runs.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    اجرای inspector در همه محیط‌ها مشابه است. توجه کنید که به جای ارسال مسیر سرور و دستور شروع سرور، آدرس URL که سرور روی آن اجرا می‌شود را می‌دهیم و همچنین مسیر `/sse` را مشخص می‌کنیم.

### -2- آزمایش ابزار

با انتخاب SSE از لیست کشویی، به سرور متصل شوید و در فیلد URL آدرس سرور خود را وارد کنید، مثلاً http:localhost:4321/sse. سپس روی دکمه "Connect" کلیک کنید. مانند قبل، گزینه لیست ابزارها را انتخاب کنید، یک ابزار را انتخاب کرده و مقادیر ورودی را وارد کنید. باید نتیجه‌ای مشابه تصویر زیر ببینید:

![اجرای سرور SSE در inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fa.png)

عالی است، شما می‌توانید با inspector کار کنید، حالا ببینیم چگونه می‌توانیم با Visual Studio Code کار کنیم.

## تمرین

سعی کنید سرور خود را با قابلیت‌های بیشتر توسعه دهید. به [این صفحه](https://api.chucknorris.io/) مراجعه کنید تا مثلاً ابزاری اضافه کنید که یک API را فراخوانی کند. تصمیم با شماست که سرور چگونه باشد. موفق باشید :)

## راه‌حل

[راه‌حل](./solution/README.md) اینجا یک راه‌حل ممکن با کد عملی ارائه شده است.

## نکات کلیدی

نکات کلیدی این فصل عبارتند از:

- SSE دومین نوع انتقال پشتیبانی شده پس از stdio است.
- برای پشتیبانی از SSE، باید اتصال‌ها و پیام‌های ورودی را با استفاده از یک فریم‌ورک وب مدیریت کنید.
- می‌توانید از هر دو ابزار Inspector و Visual Studio Code برای استفاده از سرور SSE استفاده کنید، درست مانند سرورهای stdio. توجه کنید که تفاوت‌هایی بین stdio و SSE وجود دارد. برای SSE باید سرور را جداگانه راه‌اندازی کنید و سپس ابزار inspector را اجرا کنید. همچنین برای ابزار inspector باید URL سرور را مشخص کنید.

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین حساب تایپ‌اسکریپت](../samples/typescript/README.md)
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)

## منابع بیشتر

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## مرحله بعد

- بعدی: [پخش HTTP با MCP (HTTP قابل پخش)](../06-http-streaming/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.