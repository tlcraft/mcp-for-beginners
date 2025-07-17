<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T23:51:08+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ur"
}
-->
# SSE سرور

SSE (Server Sent Events) ایک معیاری طریقہ ہے جو سرور سے کلائنٹ تک سٹریمنگ کے لیے استعمال ہوتا ہے، جس سے سرورز کلائنٹس کو HTTP کے ذریعے حقیقی وقت کی تازہ کاری بھیج سکتے ہیں۔ یہ خاص طور پر ان ایپلیکیشنز کے لیے مفید ہے جنہیں لائیو اپڈیٹس کی ضرورت ہوتی ہے، جیسے چیٹ ایپلیکیشنز، نوٹیفیکیشنز، یا حقیقی وقت کے ڈیٹا فیڈز۔ نیز، آپ کا سرور ایک ساتھ کئی کلائنٹس کے لیے استعمال ہو سکتا ہے کیونکہ یہ کسی کلاؤڈ میں چلنے والے سرور پر ہوسکتا ہے۔

## جائزہ

اس سبق میں ہم SSE سرور بنانے اور استعمال کرنے کا طریقہ سیکھیں گے۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ کر سکیں گے:

- ایک SSE سرور بنائیں۔
- Inspector کا استعمال کرتے ہوئے SSE سرور کو ڈیبگ کریں۔
- Visual Studio Code کے ذریعے SSE سرور کو استعمال کریں۔

## SSE، یہ کیسے کام کرتا ہے

SSE دو سپورٹ شدہ ٹرانسپورٹ اقسام میں سے ایک ہے۔ آپ نے پہلے سبقوں میں stdio کو استعمال ہوتے دیکھا ہے۔ فرق درج ذیل ہے:

- SSE میں آپ کو دو چیزوں کو سنبھالنا ہوتا ہے؛ کنکشن اور پیغامات۔
- چونکہ یہ سرور کہیں بھی ہوسکتا ہے، اس لیے آپ کو Inspector اور Visual Studio Code جیسے ٹولز کے ساتھ کام کرنے کے طریقے میں یہ چیز ظاہر ہونی چاہیے۔ اس کا مطلب یہ ہے کہ آپ سرور شروع کرنے کی جگہ اس اینڈ پوائنٹ کی نشاندہی کریں جہاں کنکشن قائم کیا جا سکتا ہے۔ نیچے مثال دیکھیں:

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

مندرجہ بالا کوڈ میں:

- `/sse` کو ایک روٹ کے طور پر سیٹ کیا گیا ہے۔ جب اس روٹ کی طرف درخواست آتی ہے، تو ایک نیا ٹرانسپورٹ انسٹینس بنایا جاتا ہے اور سرور اس ٹرانسپورٹ کے ذریعے *کنیکٹ* ہوتا ہے۔
- `/messages` وہ روٹ ہے جو آنے والے پیغامات کو ہینڈل کرتا ہے۔

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

مندرجہ بالا کوڈ میں ہم نے:

- ایک ASGI سرور کا انسٹینس بنایا (خاص طور پر Starlette استعمال کرتے ہوئے) اور ڈیفالٹ روٹ `/` کو ماؤنٹ کیا۔

  پس منظر میں `/sse` اور `/messages` روٹس کنکشنز اور پیغامات کو ہینڈل کرنے کے لیے سیٹ کیے جاتے ہیں۔ باقی ایپ، جیسے ٹولز شامل کرنا، stdio سرورز کی طرح ہوتا ہے۔

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

    دو طریقے ہیں جو ہمیں ویب سرور سے SSE سپورٹ کرنے والے ویب سرور تک لے جاتے ہیں:

    - `AddMcpServer`، یہ طریقہ صلاحیتیں شامل کرتا ہے۔
    - `MapMcp`، یہ `/SSE` اور `/messages` جیسے روٹس شامل کرتا ہے۔

اب جب کہ ہمیں SSE کے بارے میں کچھ معلوم ہو گیا ہے، آئیں اگلے مرحلے میں SSE سرور بنائیں۔

## مشق: SSE سرور بنانا

سرور بنانے کے لیے ہمیں دو باتیں ذہن میں رکھنی ہوں گی:

- ہمیں کنکشن اور پیغامات کے لیے اینڈ پوائنٹس ظاہر کرنے کے لیے ویب سرور استعمال کرنا ہوگا۔
- سرور کو ویسے ہی بنائیں جیسے ہم stdio استعمال کرتے ہوئے کرتے تھے، یعنی ٹولز، ریسورسز اور پرامپٹس کے ساتھ۔

### -1- سرور کا انسٹینس بنائیں

سرور بنانے کے لیے ہم وہی ٹائپس استعمال کریں گے جو stdio میں استعمال ہوتے ہیں، لیکن ٹرانسپورٹ کے لیے ہمیں SSE منتخب کرنا ہوگا۔

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

مندرجہ بالا کوڈ میں ہم نے:

- سرور کا ایک انسٹینس بنایا۔
- express ویب فریم ورک کا استعمال کرتے ہوئے ایک ایپ ڈیفائن کی۔
- ایک transports ویریبل بنایا جس میں آنے والے کنکشنز کو محفوظ کیا جائے گا۔

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

مندرجہ بالا کوڈ میں ہم نے:

- وہ لائبریریاں امپورٹ کیں جن کی ہمیں ضرورت ہے، خاص طور پر Starlette (ایک ASGI فریم ورک) کو شامل کیا۔
- ایک MCP سرور انسٹینس `mcp` بنایا۔

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

اس مرحلے پر ہم نے:

- ایک ویب ایپ بنایا۔
- `AddMcpServer` کے ذریعے MCP فیچرز کی سپورٹ شامل کی۔

اب اگلے مرحلے میں ضروری روٹس شامل کرتے ہیں۔

### -2- روٹس شامل کریں

آئیں ایسے روٹس شامل کریں جو کنکشن اور آنے والے پیغامات کو ہینڈل کریں:

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

مندرجہ بالا کوڈ میں ہم نے:

- ایک `/sse` روٹ ڈیفائن کیا جو SSE ٹائپ کا ٹرانسپورٹ انسٹینشیئٹ کرتا ہے اور MCP سرور پر `connect` کال کرتا ہے۔
- ایک `/messages` روٹ جو آنے والے پیغامات کا خیال رکھتا ہے۔

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

مندرجہ بالا کوڈ میں ہم نے:

- Starlette فریم ورک استعمال کرتے ہوئے ایک ASGI ایپ انسٹینس بنایا۔ اس میں `mcp.sse_app()` کو روٹس کی فہرست میں شامل کیا، جو ایپ انسٹینس پر `/sse` اور `/messages` روٹس ماؤنٹ کرتا ہے۔

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

ہم نے آخر میں ایک لائن کوڈ `add.MapMcp()` شامل کی ہے، جس کا مطلب ہے کہ اب ہمارے پاس `/SSE` اور `/messages` روٹس موجود ہیں۔

اب سرور میں صلاحیتیں شامل کرتے ہیں۔

### -3- سرور کی صلاحیتیں شامل کرنا

اب جب کہ ہم نے SSE سے متعلق سب کچھ ڈیفائن کر لیا ہے، تو سرور میں ٹولز، پرامپٹس اور ریسورسز جیسی صلاحیتیں شامل کرتے ہیں۔

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

یہاں ایک ٹول شامل کرنے کی مثال ہے۔ یہ مخصوص ٹول "random-joke" نامی ٹول بناتا ہے جو Chuck Norris API کو کال کرتا ہے اور JSON جواب دیتا ہے۔

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

اب آپ کے سرور میں ایک ٹول موجود ہے۔

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

1. پہلے کچھ ٹولز بنائیں، اس کے لیے ہم ایک فائل *Tools.cs* بنائیں گے جس میں درج ذیل مواد ہوگا:

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

  یہاں ہم نے درج ذیل کیا ہے:

  - `Tools` کلاس بنائی جس پر `McpServerToolType` ڈیکوریٹر لگا ہے۔
  - `AddNumbers` نامی ٹول ڈیفائن کیا، جس کے لیے میتھڈ کو `McpServerTool` سے ڈیکوریٹ کیا گیا ہے۔ ہم نے پیرامیٹرز اور امپلیمنٹیشن بھی فراہم کی ہے۔

1. اب ہم نے جو `Tools` کلاس بنائی ہے اسے استعمال کرتے ہیں:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  ہم نے `WithTools` کال شامل کی ہے جو `Tools` کو ٹولز والی کلاس کے طور پر بتاتی ہے۔ بس، اب ہم تیار ہیں۔

زبردست، ہمارے پاس SSE استعمال کرنے والا سرور ہے، آئیں اسے چلائیں۔

## مشق: Inspector کے ساتھ SSE سرور کو ڈیبگ کرنا

Inspector ایک بہترین ٹول ہے جسے ہم نے پچھلے سبق [Creating your first server](/03-GettingStarted/01-first-server/README.md) میں دیکھا تھا۔ آئیں دیکھتے ہیں کہ کیا ہم یہاں بھی Inspector استعمال کر سکتے ہیں:

### -1- Inspector چلانا

Inspector چلانے کے لیے، پہلے آپ کا SSE سرور چل رہا ہونا چاہیے، تو آئیں اسے چلائیں:

1. سرور چلائیں

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    دھیان دیں کہ ہم `uvicorn` ایکزیکیوبل استعمال کر رہے ہیں جو `pip install "mcp[cli]"` کمانڈ کے ذریعے انسٹال ہوتا ہے۔ `server:app` لکھنے کا مطلب ہے کہ ہم `server.py` فائل کو چلانے کی کوشش کر رہے ہیں جس میں `app` نامی Starlette انسٹینس موجود ہے۔

    ### .NET

    ```sh
    dotnet run
    ```

    یہ سرور شروع کر دے گا۔ اس سے بات چیت کرنے کے لیے آپ کو نیا ٹرمینل کھولنا ہوگا۔

1. Inspector چلائیں

    > ![NOTE]
    > اسے اس ٹرمینل ونڈو میں چلائیں جو سرور کے چلنے والے ٹرمینل سے مختلف ہو۔ نیز، نیچے دی گئی کمانڈ کو اپنے سرور کے URL کے مطابق ایڈجسٹ کرنا ہوگا۔

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector چلانا تمام رن ٹائمز میں ایک جیسا ہے۔ دھیان دیں کہ ہم سرور کا راستہ اور شروع کرنے کا کمانڈ دینے کی بجائے سرور کے چلنے والے URL اور `/sse` روٹ کو پاس کرتے ہیں۔

### -2- ٹول آزمانا

سرور سے کنیکٹ کرنے کے لیے ڈراپ ڈاؤن میں SSE منتخب کریں اور URL فیلڈ میں وہ پتہ درج کریں جہاں آپ کا سرور چل رہا ہے، مثلاً http:localhost:4321/sse۔ پھر "Connect" بٹن پر کلک کریں۔ جیسا کہ پہلے، ٹولز کی فہرست دیکھیں، کوئی ٹول منتخب کریں اور ان پٹ ویلیوز فراہم کریں۔ آپ کو نیچے کی طرح نتیجہ نظر آئے گا:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ur.png)

زبردست، آپ Inspector کے ساتھ کام کر سکتے ہیں، آئیں دیکھتے ہیں کہ Visual Studio Code کے ساتھ کیسے کام کریں۔

## اسائنمنٹ

اپنے سرور میں مزید صلاحیتیں شامل کرنے کی کوشش کریں۔ مثال کے طور پر، [اس صفحہ](https://api.chucknorris.io/) کو دیکھیں تاکہ کوئی ایسا ٹول بنایا جا سکے جو API کال کرے۔ فیصلہ آپ کا ہے کہ سرور کیسا نظر آئے۔ مزہ کریں :)

## حل

[حل](./solution/README.md) یہاں ایک ممکنہ حل ہے جس میں کام کرنے والا کوڈ موجود ہے۔

## اہم نکات

اس باب کے اہم نکات درج ذیل ہیں:

- SSE stdio کے بعد دوسرا سپورٹ شدہ ٹرانسپورٹ ہے۔
- SSE کو سپورٹ کرنے کے لیے آپ کو ویب فریم ورک کے ذریعے آنے والے کنکشنز اور پیغامات کو سنبھالنا ہوتا ہے۔
- آپ Inspector اور Visual Studio Code دونوں کو SSE سرور استعمال کرنے کے لیے استعمال کر سکتے ہیں، بالکل stdio سرورز کی طرح۔ دھیان دیں کہ stdio اور SSE میں تھوڑا فرق ہے۔ SSE کے لیے آپ کو سرور الگ سے شروع کرنا ہوتا ہے اور پھر Inspector ٹول چلانا ہوتا ہے۔ Inspector ٹول میں بھی فرق ہے کہ آپ کو URL بتانا پڑتا ہے۔

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## اضافی وسائل

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## آگے کیا ہے

- اگلا: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔