<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:10:05+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "bn"
}
-->
# SSE সার্ভার

SSE (Server Sent Events) হলো একটি স্ট্যান্ডার্ড যা সার্ভার থেকে ক্লায়েন্টের দিকে স্ট্রিমিং করার জন্য ব্যবহৃত হয়, যা সার্ভারকে HTTP এর মাধ্যমে ক্লায়েন্টদের রিয়েল-টাইম আপডেট পাঠাতে সক্ষম করে। এটি বিশেষভাবে উপযোগী এমন অ্যাপ্লিকেশনগুলোর জন্য যেগুলো লাইভ আপডেটের প্রয়োজন, যেমন চ্যাট অ্যাপ্লিকেশন, নোটিফিকেশন, বা রিয়েল-টাইম ডেটা ফিড। এছাড়াও, আপনার সার্ভার একাধিক ক্লায়েন্ট দ্বারা একই সময়ে ব্যবহার করা যেতে পারে কারণ এটি একটি সার্ভারে থাকে যা ক্লাউডে কোথাও চালানো যেতে পারে।

## ওভারভিউ

এই পাঠে শেখানো হবে কিভাবে SSE সার্ভার তৈরি এবং ব্যবহার করতে হয়।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর, আপনি সক্ষম হবেন:

- একটি SSE সার্ভার তৈরি করতে।
- Inspector ব্যবহার করে একটি SSE সার্ভার ডিবাগ করতে।
- Visual Studio Code ব্যবহার করে একটি SSE সার্ভার ব্যবহার করতে।

## SSE, এটি কিভাবে কাজ করে

SSE হলো দুইটি সমর্থিত ট্রান্সপোর্ট টাইপের মধ্যে একটি। আপনি আগের পাঠে stdio ব্যবহার দেখেছেন। পার্থক্য হলো:

- SSE আপনাকে দুইটি বিষয় পরিচালনা করতে হবে; সংযোগ এবং মেসেজ।
- যেহেতু এটি এমন একটি সার্ভার যা যেকোনো জায়গায় থাকতে পারে, তাই আপনাকে Inspector এবং Visual Studio Code এর মতো টুলের সাথে কাজ করার সময় সেটি প্রতিফলিত করতে হবে। এর মানে হলো, সার্ভার শুরু করার পদ্ধতি দেখানোর পরিবর্তে, আপনি সেই এন্ডপয়েন্ট দেখাবেন যেখানে সংযোগ স্থাপন করা যাবে। নিচে উদাহরণ কোড দেখুন:

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

- `/sse` একটি রুট হিসেবে সেটআপ করা হয়েছে। যখন এই রুটে অনুরোধ আসে, তখন একটি নতুন ট্রান্সপোর্ট ইনস্ট্যান্স তৈরি হয় এবং সার্ভার এই ট্রান্সপোর্ট ব্যবহার করে *সংযোগ* স্থাপন করে।
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

  পেছনের দৃশ্যে ঘটে যেটা হলো, `/sse` এবং `/messages` রুটগুলো সংযোগ এবং মেসেজ পরিচালনার জন্য সেটআপ করা হয়েছে। বাকি অ্যাপ্লিকেশন, যেমন টুলস যোগ করা, stdio সার্ভারের মতোই কাজ করে।

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

    দুটি মেথড আছে যা আমাদের একটি ওয়েব সার্ভার থেকে SSE সমর্থনকারী ওয়েব সার্ভারে রূপান্তর করতে সাহায্য করে:

    - `AddMcpServer`, এই মেথড ক্ষমতা যোগ করে।
    - `MapMcp`, এটি `/SSE` এবং `/messages` এর মতো রুট যোগ করে।
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

// একটি MCP সার্ভার তৈরি করুন
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

# বিদ্যমান ASGI সার্ভারে SSE সার্ভার মাউন্ট করুন
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

    Inspector চালানো সব রানটাইমে একই রকম দেখায়। লক্ষ্য করুন, আমরা সার্ভারের পাথ এবং সার্ভার শুরু করার কমান্ড দেওয়ার পরিবর্তে সার্ভারটি যেখানে চলছে সেই URL এবং `/sse` রুটটি উল্লেখ করছি।

### -2- টুলটি পরীক্ষা করা

SSE নির্বাচন করে সার্ভারের সাথে সংযোগ করুন এবং URL ফিল্ডে আপনার সার্ভারের ঠিকানা দিন, যেমন http:localhost:4321/sse। এখন "Connect" বাটনে ক্লিক করুন। আগের মতো, টুল তালিকা থেকে একটি টুল নির্বাচন করুন এবং ইনপুট মান দিন। নিচের মতো ফলাফল দেখতে পাবেন:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.bn.png)

দারুণ, আপনি Inspector এর সাথে কাজ করতে পারছেন, এবার দেখা যাক Visual Studio Code এর সাথে কিভাবে কাজ করা যায়।

## অ্যাসাইনমেন্ট

আপনার সার্ভার আরও ক্ষমতাসম্পন্ন করে তৈরি করার চেষ্টা করুন। উদাহরণস্বরূপ, একটি টুল যোগ করুন যা একটি API কল করে, যেমন [এই পেজটি](https://api.chucknorris.io/) দেখুন। সার্ভার কেমন হবে তা আপনি নির্ধারণ করবেন। মজা করুন :)

## সমাধান

[সমাধান](./solution/README.md) এখানে একটি সম্ভাব্য সমাধান এবং কাজ করা কোড দেওয়া হয়েছে।

## মূল বিষয়সমূহ

এই অধ্যায় থেকে মূল বিষয়গুলো হলো:

- SSE হলো stdio এর পর দ্বিতীয় সমর্থিত ট্রান্সপোর্ট।
- SSE সমর্থনের জন্য, আপনাকে ওয়েব ফ্রেমওয়ার্ক ব্যবহার করে ইনকামিং সংযোগ এবং মেসেজ পরিচালনা করতে হবে।
- Inspector এবং Visual Studio Code উভয়ই SSE সার্ভার ব্যবহার করতে পারে, stdio সার্ভারের মতোই। তবে stdio এবং SSE এর মধ্যে কিছু পার্থক্য আছে। SSE এর জন্য আপনাকে সার্ভার আলাদাভাবে চালু করতে হবে এবং তারপর Inspector টুল চালাতে হবে। Inspector টুলে URL উল্লেখ করতে হয়।

## নমুনা 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## অতিরিক্ত সম্পদ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## পরবর্তী ধাপ

- পরবর্তী: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।