<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T00:13:59+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "bn"
}
-->
# SSE সার্ভার

SSE (Server Sent Events) হলো একটি স্ট্যান্ডার্ড যা সার্ভার থেকে ক্লায়েন্টের দিকে স্ট্রিমিং করার জন্য ব্যবহৃত হয়, যা সার্ভারকে HTTP এর মাধ্যমে ক্লায়েন্টদের রিয়েল-টাইম আপডেট পাঠাতে সক্ষম করে। এটি বিশেষভাবে উপযোগী এমন অ্যাপ্লিকেশনগুলোর জন্য যেগুলো লাইভ আপডেটের প্রয়োজন, যেমন চ্যাট অ্যাপ্লিকেশন, নোটিফিকেশন, বা রিয়েল-টাইম ডেটা ফিড। এছাড়াও, আপনার সার্ভার একাধিক ক্লায়েন্ট দ্বারা একই সময়ে ব্যবহার করা যেতে পারে কারণ এটি এমন একটি সার্ভারে থাকে যা ক্লাউডে কোথাও চালানো যেতে পারে।

## ওভারভিউ

এই পাঠে আমরা শিখব কিভাবে SSE সার্ভার তৈরি এবং ব্যবহার করতে হয়।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর, আপনি সক্ষম হবেন:

- একটি SSE সার্ভার তৈরি করতে।
- Inspector ব্যবহার করে একটি SSE সার্ভার ডিবাগ করতে।
- Visual Studio Code ব্যবহার করে একটি SSE সার্ভার ব্যবহার করতে।

## SSE, এটি কিভাবে কাজ করে

SSE হলো দুইটি সমর্থিত ট্রান্সপোর্ট টাইপের একটি। আপনি আগের পাঠে stdio ব্যবহার দেখেছেন। পার্থক্য হলো:

- SSE আপনাকে দুইটি বিষয় পরিচালনা করতে হবে; সংযোগ এবং মেসেজ।
- যেহেতু এটি এমন একটি সার্ভার যা যেকোনো জায়গায় থাকতে পারে, তাই আপনাকে Inspector এবং Visual Studio Code এর মতো টুলসের সাথে কাজ করার সময় সেটি প্রতিফলিত করতে হবে। এর মানে হলো, সার্ভার শুরু করার পরিবর্তে, আপনি সেই এন্ডপয়েন্ট নির্দেশ করবেন যেখানে সংযোগ স্থাপন করা যাবে। নিচে উদাহরণ কোড দেখুন:

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

উপরের কোডে:

- `/sse` একটি রুট হিসেবে সেটআপ করা হয়েছে। যখন এই রুটে অনুরোধ আসে, তখন একটি নতুন ট্রান্সপোর্ট ইনস্ট্যান্স তৈরি হয় এবং সার্ভার এই ট্রান্সপোর্ট ব্যবহার করে *connect* করে।
- `/messages` হলো সেই রুট যা ইনকামিং মেসেজগুলো পরিচালনা করে।

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

উপরের কোডে আমরা:

- একটি ASGI সার্ভারের ইনস্ট্যান্স তৈরি করেছি (বিশেষ করে Starlette ব্যবহার করে) এবং ডিফল্ট রুট `/` মাউন্ট করেছি।

  পেছনের দৃশ্যে যা ঘটে তা হলো `/sse` এবং `/messages` রুটগুলো সংযোগ এবং মেসেজ পরিচালনার জন্য সেটআপ করা হয়। বাকি অ্যাপ্লিকেশন, যেমন টুলস যোগ করা, stdio সার্ভারের মতোই হয়।

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

    দুটি মেথড আছে যা আমাদের একটি ওয়েব সার্ভার থেকে SSE সমর্থিত ওয়েব সার্ভারে নিয়ে যায়:

    - `AddMcpServer`, এই মেথড ক্ষমতা যোগ করে।
    - `MapMcp`, এটি `/SSE` এবং `/messages` এর মতো রুট যোগ করে।

এখন যেহেতু আমরা SSE সম্পর্কে কিছুটা জানি, চলুন একটি SSE সার্ভার তৈরি করি।

## অনুশীলন: একটি SSE সার্ভার তৈরি করা

আমাদের সার্ভার তৈরি করতে, আমাদের দুইটি বিষয় মাথায় রাখতে হবে:

- সংযোগ এবং মেসেজের জন্য এন্ডপয়েন্ট প্রকাশ করতে একটি ওয়েব সার্ভার ব্যবহার করতে হবে।
- stdio ব্যবহার করার সময় যেভাবে টুলস, রিসোর্স এবং প্রম্পট ব্যবহার করতাম, সেভাবেই সার্ভার তৈরি করতে হবে।

### -1- সার্ভার ইনস্ট্যান্স তৈরি করা

সার্ভার তৈরি করতে, আমরা stdio এর মতো একই টাইপ ব্যবহার করব। তবে ট্রান্সপোর্ট হিসেবে SSE নির্বাচন করতে হবে।

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

উপরের কোডে আমরা:

- একটি সার্ভার ইনস্ট্যান্স তৈরি করেছি।
- express ওয়েব ফ্রেমওয়ার্ক ব্যবহার করে একটি অ্যাপ ডিফাইন করেছি।
- একটি transports ভেরিয়েবল তৈরি করেছি যা ইনকামিং সংযোগগুলো সংরক্ষণ করবে।

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

উপরের কোডে আমরা:

- প্রয়োজনীয় লাইব্রেরি ইমপোর্ট করেছি, Starlette (একটি ASGI ফ্রেমওয়ার্ক) অন্তর্ভুক্ত।
- একটি MCP সার্ভার ইনস্ট্যান্স `mcp` তৈরি করেছি।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

এই পর্যায়ে, আমরা:

- একটি ওয়েব অ্যাপ তৈরি করেছি।
- `AddMcpServer` এর মাধ্যমে MCP ফিচার সমর্থন যোগ করেছি।

এখন প্রয়োজনীয় রুটগুলো যোগ করি।

### -2- রুট যোগ করা

এখন সংযোগ এবং ইনকামিং মেসেজ পরিচালনার জন্য রুট যোগ করি:

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

উপরের কোডে আমরা ডিফাইন করেছি:

- একটি `/sse` রুট যা SSE টাইপের একটি ট্রান্সপোর্ট ইনস্ট্যান্স তৈরি করে এবং MCP সার্ভারে `connect` কল করে।
- একটি `/messages` রুট যা ইনকামিং মেসেজগুলো পরিচালনা করে।

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

উপরের কোডে আমরা:

- Starlette ফ্রেমওয়ার্ক ব্যবহার করে একটি ASGI অ্যাপ ইনস্ট্যান্স তৈরি করেছি। এর অংশ হিসেবে `mcp.sse_app()` রুটের তালিকায় পাস করেছি। এটি অ্যাপ ইনস্ট্যান্সে `/sse` এবং `/messages` রুট মাউন্ট করে।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

আমরা শেষে একটি লাইন কোড যোগ করেছি `add.MapMcp()` যা নির্দেশ করে এখন আমাদের `/SSE` এবং `/messages` রুট রয়েছে।

এখন সার্ভারে ক্ষমতা যোগ করি।

### -3- সার্ভারের ক্ষমতা যোগ করা

এখন যেহেতু SSE সম্পর্কিত সবকিছু ডিফাইন করা হয়েছে, চলুন সার্ভারে টুলস, প্রম্পট এবং রিসোর্সের মতো ক্ষমতা যোগ করি।

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

উদাহরণস্বরূপ, এখানে একটি টুল যোগ করার পদ্ধতি দেখানো হয়েছে। এই টুলটি "random-joke" নামে একটি টুল তৈরি করে যা Chuck Norris API কল করে এবং JSON রেসপন্স দেয়।

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

এখন আপনার সার্ভারে একটি টুল রয়েছে।

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

1. প্রথমে কিছু টুল তৈরি করি, এর জন্য আমরা *Tools.cs* নামে একটি ফাইল তৈরি করব নিম্নলিখিত বিষয়বস্তু সহ:

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

  এখানে আমরা নিম্নলিখিত কাজ করেছি:

  - `Tools` নামে একটি ক্লাস তৈরি করেছি এবং `McpServerToolType` ডেকোরেটর ব্যবহার করেছি।
  - `AddNumbers` নামে একটি টুল ডিফাইন করেছি, মেথডটিকে `McpServerTool` দিয়ে ডেকোরেট করেছি। প্যারামিটার এবং ইমপ্লিমেন্টেশনও দিয়েছি।

1. এখন আমরা刚刚 তৈরি করা `Tools` ক্লাসটি ব্যবহার করব:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  আমরা `WithTools` কল যোগ করেছি যা `Tools` ক্লাসটিকে টুলস ধারণকারী ক্লাস হিসেবে নির্দিষ্ট করে। এতেই সব প্রস্তুত।

দারুণ, আমাদের কাছে একটি SSE ব্যবহারকারী সার্ভার আছে, চলুন এটি পরীক্ষা করি।

## অনুশীলন: Inspector দিয়ে SSE সার্ভার ডিবাগ করা

Inspector একটি চমৎকার টুল যা আমরা আগের পাঠে দেখেছি [Creating your first server](/03-GettingStarted/01-first-server/README.md)। চলুন দেখি এখানে কি আমরা Inspector ব্যবহার করতে পারি:

### -1- Inspector চালানো

Inspector চালানোর জন্য প্রথমে একটি SSE সার্ভার চালু থাকতে হবে, তাই চলুন সেটা করি:

1. সার্ভার চালান

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    লক্ষ্য করুন আমরা `uvicorn` এক্সিকিউটেবল ব্যবহার করছি যা `pip install "mcp[cli]"` কমান্ড চালানোর সময় ইনস্টল হয়। `server:app` টাইপ করলে অর্থ হলো আমরা `server.py` ফাইল চালাচ্ছি এবং এতে একটি Starlette ইনস্ট্যান্স `app` আছে।

    ### .NET

    ```sh
    dotnet run
    ```

    এটি সার্ভার শুরু করবে। এর সাথে ইন্টারফেস করার জন্য একটি নতুন টার্মিনাল দরকার।

1. Inspector চালান

    > ![NOTE]
    > এটি সার্ভার চালানো টার্মিনাল থেকে আলাদা একটি টার্মিনাল উইন্ডোতে চালান। এছাড়াও লক্ষ্য করুন, নিচের কমান্ডটি আপনার সার্ভারের URL অনুযায়ী সামঞ্জস্য করতে হবে।

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector চালানো সব রানটাইমে একই রকম। লক্ষ্য করুন, আমরা সার্ভারের পাথ এবং সার্ভার শুরু করার কমান্ডের পরিবর্তে সার্ভারের URL এবং `/sse` রুট উল্লেখ করছি।

### -2- টুল ব্যবহার করে দেখা

SSE নির্বাচন করে সার্ভারের URL দিন, যেমন http:localhost:4321/sse। তারপর "Connect" বাটনে ক্লিক করুন। আগের মতো টুল তালিকা থেকে একটি টুল নির্বাচন করুন এবং ইনপুট দিন। নিচের মতো ফলাফল দেখতে পাবেন:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.bn.png)

দারুণ, আপনি Inspector এর সাথে কাজ করতে পারছেন, চলুন দেখি Visual Studio Code এর সাথে কিভাবে কাজ করা যায়।

## অ্যাসাইনমেন্ট

আপনার সার্ভার আরও ক্ষমতাসম্পন্ন করে তৈরি করার চেষ্টা করুন। উদাহরণস্বরূপ, [এই পেজটি](https://api.chucknorris.io/) দেখুন, যেখানে একটি API কল করে টুল যোগ করা যায়। সার্ভার কেমন হবে তা আপনি নির্ধারণ করবেন। মজা করুন :)

## সমাধান

[সমাধান](./solution/README.md) এখানে একটি সম্ভাব্য সমাধান এবং কাজ করা কোড দেওয়া হয়েছে।

## মূল বিষয়সমূহ

এই অধ্যায় থেকে মূল বিষয়গুলো হলো:

- SSE হলো stdio এর পরবর্তী সমর্থিত দ্বিতীয় ট্রান্সপোর্ট।
- SSE সমর্থনের জন্য, আপনাকে ওয়েব ফ্রেমওয়ার্ক ব্যবহার করে ইনকামিং সংযোগ এবং মেসেজ পরিচালনা করতে হবে।
- Inspector এবং Visual Studio Code উভয়ই SSE সার্ভার ব্যবহার করতে পারে, stdio সার্ভারের মতোই। তবে stdio এবং SSE এর মধ্যে কিছু পার্থক্য আছে। SSE এর জন্য আপনাকে সার্ভার আলাদাভাবে চালু করতে হবে এবং তারপর Inspector চালাতে হবে। Inspector টুলে URL উল্লেখ করতে হয়।

## স্যাম্পলস

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## অতিরিক্ত রিসোর্স

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## পরবর্তী ধাপ

- পরবর্তী: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।