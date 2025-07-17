<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T23:39:39+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ar"
}
-->
# خادم SSE

SSE (Server Sent Events) هو معيار للبث من الخادم إلى العميل، يسمح للخوادم بدفع التحديثات الحية إلى العملاء عبر HTTP. هذا مفيد بشكل خاص للتطبيقات التي تتطلب تحديثات فورية، مثل تطبيقات الدردشة، الإشعارات، أو تدفقات البيانات الحية. كما يمكن استخدام خادمك من قبل عدة عملاء في نفس الوقت لأنه يعمل على خادم يمكن تشغيله في مكان ما في السحابة على سبيل المثال.

## نظرة عامة

تغطي هذه الدرس كيفية بناء واستهلاك خوادم SSE.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- بناء خادم SSE.
- تصحيح خادم SSE باستخدام Inspector.
- استهلاك خادم SSE باستخدام Visual Studio Code.

## SSE، كيف يعمل

SSE هو أحد نوعي النقل المدعومين. لقد رأيت بالفعل النوع الأول stdio المستخدم في الدروس السابقة. الفرق هو كالتالي:

- SSE يتطلب منك التعامل مع أمرين؛ الاتصال والرسائل.
- بما أن هذا خادم يمكن أن يعمل في أي مكان، يجب أن ينعكس ذلك في كيفية عملك مع أدوات مثل Inspector و Visual Studio Code. هذا يعني أنه بدلاً من الإشارة إلى كيفية بدء الخادم، تشير إلى نقطة النهاية حيث يمكنه إنشاء الاتصال. انظر المثال التالي:

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

في الكود السابق:

- تم إعداد `/sse` كمسار. عند إجراء طلب إلى هذا المسار، يتم إنشاء نسخة جديدة من النقل ويتصل الخادم باستخدام هذا النقل.
- `/messages`، هذا هو المسار الذي يتعامل مع الرسائل الواردة.

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

في الكود السابق قمنا بـ:

- إنشاء نسخة من خادم ASGI (باستخدام Starlette تحديدًا) وتركيب المسار الافتراضي `/`

  ما يحدث خلف الكواليس هو أن المسارات `/sse` و `/messages` تم إعدادها للتعامل مع الاتصالات والرسائل على التوالي. بقية التطبيق، مثل إضافة ميزات كالأدوات، يتم كما هو الحال مع خوادم stdio.

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

    هناك طريقتان تساعداننا على الانتقال من خادم ويب إلى خادم ويب يدعم SSE وهما:

    - `AddMcpServer`، تضيف هذه الطريقة القدرات.
    - `MapMcp`، تضيف هذه الطرق مسارات مثل `/SSE` و `/messages`.

الآن بعد أن عرفنا المزيد عن SSE، دعونا نبني خادم SSE بعد ذلك.

## تمرين: إنشاء خادم SSE

لإنشاء خادمنا، يجب أن نضع في اعتبارنا أمرين:

- نحتاج إلى استخدام خادم ويب لعرض نقاط النهاية للاتصال والرسائل.
- بناء خادمنا كما نفعل عادة باستخدام الأدوات، الموارد، والمطالبات عندما كنا نستخدم stdio.

### -1- إنشاء نسخة من الخادم

لإنشاء خادمنا، نستخدم نفس الأنواع كما في stdio. ومع ذلك، بالنسبة للنقل، نحتاج إلى اختيار SSE.

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

في الكود السابق قمنا بـ:

- إنشاء نسخة من الخادم.
- تعريف تطبيق باستخدام إطار العمل express.
- إنشاء متغير transports الذي سنستخدمه لتخزين الاتصالات الواردة.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

في الكود السابق قمنا بـ:

- استيراد المكتبات التي سنحتاجها مع استيراد Starlette (إطار عمل ASGI).
- إنشاء نسخة من خادم MCP باسم `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

في هذه المرحلة، قمنا بـ:

- إنشاء تطبيق ويب
- إضافة دعم لميزات MCP من خلال `AddMcpServer`.

دعونا نضيف المسارات اللازمة بعد ذلك.

### -2- إضافة المسارات

دعونا نضيف المسارات التي تتعامل مع الاتصال والرسائل الواردة:

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

في الكود السابق قمنا بتعريف:

- مسار `/sse` الذي ينشئ نقل من نوع SSE وينتهي باستدعاء `connect` على خادم MCP.
- مسار `/messages` الذي يتولى معالجة الرسائل الواردة.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

في الكود السابق قمنا بـ:

- إنشاء نسخة من تطبيق ASGI باستخدام إطار عمل Starlette. كجزء من ذلك، مررنا `mcp.sse_app()` إلى قائمة المسارات. هذا يؤدي إلى تركيب مساري `/sse` و `/messages` على نسخة التطبيق.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

أضفنا سطرًا واحدًا في النهاية `add.MapMcp()` وهذا يعني أن لدينا الآن مسارات `/SSE` و `/messages`.

دعونا نضيف القدرات إلى الخادم بعد ذلك.

### -3- إضافة قدرات الخادم

الآن بعد أن عرفنا كل ما يتعلق بـ SSE، دعونا نضيف قدرات الخادم مثل الأدوات، المطالبات، والموارد.

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

إليك كيف يمكنك إضافة أداة على سبيل المثال. هذه الأداة المحددة تنشئ أداة تسمى "random-joke" التي تستدعي API خاص بـ Chuck Norris وتعيد استجابة JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

الآن يحتوي خادمك على أداة واحدة.

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

1. لننشئ بعض الأدوات أولاً، لهذا سننشئ ملف *Tools.cs* بالمحتوى التالي:

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

  هنا أضفنا ما يلي:

  - أنشأنا فئة `Tools` مع المزخرف `McpServerToolType`.
  - عرفنا أداة `AddNumbers` بتزيين الطريقة بـ `McpServerTool`. كما قدمنا المعلمات والتنفيذ.

1. لنستخدم فئة `Tools` التي أنشأناها للتو:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  أضفنا استدعاءً لـ `WithTools` يحدد `Tools` كالفئة التي تحتوي على الأدوات. هذا كل شيء، نحن جاهزون.

رائع، لدينا خادم يستخدم SSE، دعونا نجربه الآن.

## تمرين: تصحيح خادم SSE باستخدام Inspector

Inspector هي أداة رائعة رأيناها في درس سابق [إنشاء خادمك الأول](/03-GettingStarted/01-first-server/README.md). دعونا نرى إذا كان بإمكاننا استخدام Inspector هنا أيضًا:

### -1- تشغيل Inspector

لتشغيل Inspector، يجب أولاً أن يكون لديك خادم SSE يعمل، فلنقم بذلك الآن:

1. تشغيل الخادم

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    لاحظ كيف نستخدم البرنامج التنفيذي `uvicorn` الذي تم تثبيته عند كتابة `pip install "mcp[cli]"`. كتابة `server:app` تعني أننا نحاول تشغيل ملف `server.py` وأن يحتوي على نسخة Starlette تسمى `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    يجب أن يبدأ هذا الخادم. للتفاعل معه تحتاج إلى نافذة طرفية جديدة.

1. تشغيل Inspector

    > ![NOTE]
    > شغّل هذا في نافذة طرفية منفصلة عن تلك التي يعمل فيها الخادم. لاحظ أيضًا، يجب تعديل الأمر أدناه ليتناسب مع عنوان URL الذي يعمل عليه خادمك.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    تشغيل Inspector يبدو نفسه في جميع بيئات التشغيل. لاحظ كيف أننا بدلاً من تمرير مسار إلى خادمنا وأمر لبدء الخادم، نمرر عنوان URL حيث يعمل الخادم ونحدد أيضًا مسار `/sse`.

### -2- تجربة الأداة

اتصل بالخادم باختيار SSE من القائمة المنسدلة واملأ حقل URL حيث يعمل خادمك، على سبيل المثال http:localhost:4321/sse. الآن اضغط على زر "Connect". كما في السابق، اختر قائمة الأدوات، اختر أداة وقدم قيم الإدخال. يجب أن ترى نتيجة مثل الصورة أدناه:

![خادم SSE يعمل في Inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ar.png)

رائع، يمكنك العمل مع Inspector، دعونا نرى كيف يمكننا العمل مع Visual Studio Code بعد ذلك.

## المهمة

حاول بناء خادمك مع المزيد من القدرات. راجع [هذه الصفحة](https://api.chucknorris.io/) لإضافة أداة تستدعي API على سبيل المثال. القرار لك حول شكل الخادم. استمتع :)

## الحل

[الحل](./solution/README.md) هذا حل ممكن مع كود يعمل.

## النقاط الرئيسية

النقاط الرئيسية من هذا الفصل هي:

- SSE هو نوع النقل الثاني المدعوم بعد stdio.
- لدعم SSE، تحتاج إلى إدارة الاتصالات والرسائل الواردة باستخدام إطار عمل ويب.
- يمكنك استخدام كل من Inspector و Visual Studio Code لاستهلاك خادم SSE، تمامًا كما هو الحال مع خوادم stdio. لاحظ كيف يختلف الأمر قليلاً بين stdio و SSE. بالنسبة لـ SSE، تحتاج إلى تشغيل الخادم بشكل منفصل ثم تشغيل أداة Inspector. بالنسبة لأداة Inspector، هناك بعض الاختلافات أيضًا حيث تحتاج إلى تحديد عنوان URL.

## عينات

- [حاسبة جافا](../samples/java/calculator/README.md)
- [حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [حاسبة جافا سكريبت](../samples/javascript/README.md)
- [حاسبة TypeScript](../samples/typescript/README.md)
- [حاسبة بايثون](../../../../03-GettingStarted/samples/python)

## موارد إضافية

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## ما التالي

- التالي: [البث عبر HTTP مع MCP (HTTP قابل للبث)](../06-http-streaming/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.