<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T22:29:34+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fa"
}
-->
# سرور SSE

SSE (Server Sent Events) یک استاندارد برای پخش داده‌ها از سرور به کلاینت است که به سرورها اجازه می‌دهد به‌روزرسانی‌های زنده را از طریق HTTP به کلاینت‌ها ارسال کنند. این روش به‌ویژه برای برنامه‌هایی که نیاز به به‌روزرسانی‌های لحظه‌ای دارند، مانند برنامه‌های چت، اعلان‌ها یا فیدهای داده زنده، بسیار مفید است. همچنین، سرور شما می‌تواند توسط چندین کلاینت به‌طور همزمان استفاده شود، زیرا روی یک سرور قرار دارد که می‌تواند مثلاً در فضای ابری اجرا شود.

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

- مسیر `/sse` به عنوان یک روت تنظیم شده است. وقتی درخواستی به این مسیر ارسال شود، یک نمونه جدید از transport ساخته می‌شود و سرور با استفاده از این transport *اتصال* برقرار می‌کند.
- مسیر `/messages`، این مسیر پیام‌های ورودی را مدیریت می‌کند.

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

- یک نمونه از سرور ASGI (به طور خاص با Starlette) ساخته و روت پیش‌فرض `/` را نصب می‌کنیم.

  پشت صحنه، مسیرهای `/sse` و `/messages` برای مدیریت اتصال‌ها و پیام‌ها تنظیم می‌شوند. بقیه برنامه، مانند افزودن امکاناتی مثل ابزارها، مشابه سرورهای stdio انجام می‌شود.

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

حالا که کمی بیشتر با SSE آشنا شدیم، بیایید یک سرور SSE بسازیم.

## تمرین: ساخت یک سرور SSE

برای ساخت سرور، باید دو نکته را در نظر داشته باشیم:

- باید از یک وب‌سرور برای ارائه نقاط انتهایی اتصال و پیام‌ها استفاده کنیم.
- سرور را مانند همیشه با ابزارها، منابع و درخواست‌ها بسازیم، همانطور که در stdio انجام می‌دادیم.

### -1- ایجاد یک نمونه سرور

برای ساخت سرور، از همان نوع‌ها مانند stdio استفاده می‌کنیم. اما برای transport باید SSE را انتخاب کنیم.

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

در کد بالا:

- یک نمونه سرور ساخته‌ایم.
- یک اپلیکیشن با استفاده از فریم‌ورک وب express تعریف کرده‌ایم.
- متغیر transports را ایجاد کرده‌ایم که برای ذخیره اتصالات ورودی استفاده می‌شود.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

در کد بالا:

- کتابخانه‌های مورد نیاز را وارد کرده‌ایم، از جمله Starlette (یک فریم‌ورک ASGI).
- یک نمونه سرور MCP به نام `mcp` ساخته‌ایم.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

در این مرحله:

- یک اپلیکیشن وب ساخته‌ایم.
- پشتیبانی از قابلیت‌های MCP را با `AddMcpServer` اضافه کرده‌ایم.

حالا بیایید مسیرهای لازم را اضافه کنیم.

### -2- افزودن مسیرها

حالا مسیرهایی را اضافه می‌کنیم که اتصال و پیام‌های ورودی را مدیریت می‌کنند:

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

در کد بالا:

- مسیر `/sse` را تعریف کرده‌ایم که یک transport از نوع SSE ایجاد می‌کند و در نهایت متد `connect` را روی سرور MCP فراخوانی می‌کند.
- مسیر `/messages` که پیام‌های ورودی را مدیریت می‌کند.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

در کد بالا:

- یک نمونه اپلیکیشن ASGI با استفاده از فریم‌ورک Starlette ساخته‌ایم. در این مسیر، `mcp.sse_app()` را به لیست مسیرهای آن اضافه کرده‌ایم. این باعث می‌شود مسیرهای `/sse` و `/messages` روی اپلیکیشن نصب شوند.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

یک خط کد در انتها اضافه کرده‌ایم `add.MapMcp()` که به این معنی است که حالا مسیرهای `/SSE` و `/messages` داریم.

حالا بیایید قابلیت‌ها را به سرور اضافه کنیم.

### -3- افزودن قابلیت‌های سرور

حالا که همه چیز مربوط به SSE تعریف شده، بیایید قابلیت‌هایی مانند ابزارها، درخواست‌ها و منابع را اضافه کنیم.

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

در اینجا نحوه افزودن یک ابزار را می‌بینید. این ابزار خاص یک ابزار به نام "random-joke" ایجاد می‌کند که به API چاک نوریس متصل شده و پاسخ JSON برمی‌گرداند.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

حالا سرور شما یک ابزار دارد.

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

1. ابتدا چند ابزار ایجاد کنیم، برای این کار یک فایل *Tools.cs* با محتوای زیر می‌سازیم:

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

  در اینجا موارد زیر را اضافه کرده‌ایم:

  - یک کلاس `Tools` با دکوراتور `McpServerToolType` ساخته‌ایم.
  - یک ابزار `AddNumbers` تعریف کرده‌ایم که متد آن با `McpServerTool` تزئین شده است. همچنین پارامترها و پیاده‌سازی آن را مشخص کرده‌ایم.

1. حالا از کلاس `Tools` که ساختیم استفاده می‌کنیم:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  یک فراخوانی به `WithTools` اضافه کرده‌ایم که کلاس `Tools` را به عنوان کلاس حاوی ابزارها مشخص می‌کند. همین، آماده‌ایم.

عالی است، حالا یک سرور با استفاده از SSE داریم، بیایید آن را امتحان کنیم.

## تمرین: اشکال‌زدایی سرور SSE با Inspector

Inspector یک ابزار عالی است که در درس قبلی [ساخت اولین سرور شما](/03-GettingStarted/01-first-server/README.md) دیدیم. بیایید ببینیم آیا می‌توانیم اینجا هم از Inspector استفاده کنیم:

### -1- اجرای Inspector

برای اجرای Inspector، ابتدا باید یک سرور SSE در حال اجرا داشته باشید، پس ابتدا این کار را انجام می‌دهیم:

1. سرور را اجرا کنید

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    توجه کنید که از اجرایی `uvicorn` استفاده می‌کنیم که هنگام اجرای `pip install "mcp[cli]"` نصب شده است. نوشتن `server:app` یعنی می‌خواهیم فایل `server.py` را اجرا کنیم که یک نمونه Starlette به نام `app` دارد.

    ### .NET

    ```sh
    dotnet run
    ```

    این باید سرور را راه‌اندازی کند. برای کار با آن نیاز به یک ترمینال جدید دارید.

1. Inspector را اجرا کنید

    > ![NOTE]
    > این را در یک پنجره ترمینال جداگانه نسبت به جایی که سرور اجرا می‌شود، اجرا کنید. همچنین توجه داشته باشید که باید دستور زیر را متناسب با URL سرور خود تنظیم کنید.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    اجرای Inspector در همه محیط‌ها مشابه است. توجه کنید که به جای ارسال مسیر سرور و دستور شروع سرور، URL سرور را می‌دهیم و مسیر `/sse` را مشخص می‌کنیم.

### -2- امتحان کردن ابزار

با انتخاب SSE از لیست کشویی و وارد کردن آدرس URL سرور خود، مثلاً http:localhost:4321/sse، به سرور متصل شوید. سپس روی دکمه "Connect" کلیک کنید. مانند قبل، گزینه لیست ابزارها را انتخاب کنید، یک ابزار را انتخاب کرده و مقادیر ورودی را وارد کنید. باید نتیجه‌ای مشابه تصویر زیر ببینید:

![سرور SSE در حال اجرا در inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fa.png)

عالی است، شما می‌توانید با Inspector کار کنید، حالا ببینیم چگونه می‌توانیم با Visual Studio Code کار کنیم.

## تمرین

سعی کنید سرور خود را با قابلیت‌های بیشتر توسعه دهید. به [این صفحه](https://api.chucknorris.io/) مراجعه کنید تا مثلاً ابزاری اضافه کنید که به یک API متصل شود. خودتان تصمیم بگیرید سرور چگونه باشد. موفق باشید :)

## راه‌حل

[راه‌حل](./solution/README.md) اینجا یک راه‌حل ممکن با کد عملی ارائه شده است.

## نکات کلیدی

نکات کلیدی این فصل عبارتند از:

- SSE دومین نوع انتقال پشتیبانی شده بعد از stdio است.
- برای پشتیبانی از SSE، باید اتصالات و پیام‌های ورودی را با استفاده از یک فریم‌ورک وب مدیریت کنید.
- می‌توانید از هر دو Inspector و Visual Studio Code برای استفاده از سرور SSE استفاده کنید، درست مانند سرورهای stdio. توجه کنید که تفاوت‌هایی بین stdio و SSE وجود دارد. برای SSE باید سرور را جداگانه راه‌اندازی کنید و سپس ابزار Inspector را اجرا کنید. همچنین برای Inspector باید URL را مشخص کنید.

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین حساب تایپ‌اسکریپت](../samples/typescript/README.md)
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)

## منابع اضافی

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## مرحله بعد

- مرحله بعد: [پخش HTTP با MCP (HTTP قابل پخش)](../06-http-streaming/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.