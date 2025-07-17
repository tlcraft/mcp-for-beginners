<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T17:36:05+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ar"
}
-->
# خادم SSE

SSE (Server Sent Events) هو معيار للبث من الخادم إلى العميل، يسمح للخوادم بدفع التحديثات الحية إلى العملاء عبر HTTP. هذا مفيد بشكل خاص للتطبيقات التي تتطلب تحديثات فورية، مثل تطبيقات الدردشة، الإشعارات، أو تدفقات البيانات الحية. كما يمكن استخدام خادمك من قبل عدة عملاء في نفس الوقت لأنه يعمل على خادم يمكن تشغيله في مكان ما في السحابة مثلاً.

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

في الكود السابق نقوم بـ:

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

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
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

    تشغيل الـ inspector يبدو نفسه في جميع بيئات التشغيل. لاحظ كيف أننا بدلاً من تمرير مسار لخادمنا وأمر لبدء الخادم، نمرر بدلاً من ذلك عنوان URL حيث يعمل الخادم ونحدد أيضًا مسار `/sse`.

### -2- تجربة الأداة

اتصل بالخادم عن طريق اختيار SSE من القائمة المنسدلة واملأ حقل العنوان URL حيث يعمل خادمك، مثلاً http:localhost:4321/sse. الآن اضغط على زر "Connect". كما في السابق، اختر قائمة الأدوات، اختر أداة وقدم قيم الإدخال. يجب أن ترى نتيجة مثل الصورة أدناه:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ar.png)

رائع، أنت قادر على العمل مع الـ inspector، دعنا نرى كيف يمكننا العمل مع Visual Studio Code بعد ذلك.

## المهمة

حاول بناء خادمك مع المزيد من القدرات. راجع [هذه الصفحة](https://api.chucknorris.io/) لإضافة أداة تستدعي API على سبيل المثال. أنت من يقرر كيف يجب أن يبدو الخادم. استمتع :)

## الحل

[الحل](./solution/README.md) هذا حل ممكن مع كود يعمل.

## النقاط الرئيسية

النقاط الرئيسية من هذا الفصل هي:

- SSE هو نوع النقل الثاني المدعوم بعد stdio.
- لدعم SSE، تحتاج إلى إدارة الاتصالات والرسائل الواردة باستخدام إطار عمل ويب.
- يمكنك استخدام كل من Inspector و Visual Studio Code لاستهلاك خادم SSE، تمامًا كما هو الحال مع خوادم stdio. لاحظ كيف يختلف الأمر قليلاً بين stdio و SSE. بالنسبة لـ SSE، تحتاج إلى تشغيل الخادم بشكل منفصل ثم تشغيل أداة الـ inspector. بالنسبة لأداة الـ inspector، هناك أيضًا بعض الاختلافات في أنه يجب عليك تحديد عنوان URL.

## عينات

- [حاسبة جافا](../samples/java/calculator/README.md)
- [حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [حاسبة جافا سكريبت](../samples/javascript/README.md)
- [حاسبة تايب سكريبت](../samples/typescript/README.md)
- [حاسبة بايثون](../../../../03-GettingStarted/samples/python)

## موارد إضافية

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## ما التالي

- التالي: [البث عبر HTTP مع MCP (HTTP قابل للبث)](../06-http-streaming/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.