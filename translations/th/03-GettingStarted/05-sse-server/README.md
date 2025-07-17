<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:44:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "th"
}
-->
# SSE Server

SSE (Server Sent Events) คือมาตรฐานสำหรับการสตรีมข้อมูลจากเซิร์ฟเวอร์ไปยังไคลเอนต์ ช่วยให้เซิร์ฟเวอร์ส่งข้อมูลอัปเดตแบบเรียลไทม์ไปยังไคลเอนต์ผ่าน HTTP ซึ่งเหมาะอย่างยิ่งสำหรับแอปพลิเคชันที่ต้องการอัปเดตสด เช่น แอปแชท การแจ้งเตือน หรือฟีดข้อมูลแบบเรียลไทม์ นอกจากนี้ เซิร์ฟเวอร์ของคุณยังสามารถรองรับไคลเอนต์หลายคนพร้อมกันได้ เพราะมันทำงานบนเซิร์ฟเวอร์ที่อาจรันอยู่บนคลาวด์ได้

## ภาพรวม

บทเรียนนี้จะสอนวิธีการสร้างและใช้งาน SSE Server

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- สร้าง SSE Server
- ดีบัก SSE Server โดยใช้ Inspector
- ใช้งาน SSE Server ผ่าน Visual Studio Code

## SSE ทำงานอย่างไร

SSE เป็นหนึ่งในสองประเภทของการขนส่งข้อมูลที่รองรับ คุณเคยเห็นการใช้ stdio ในบทเรียนก่อนหน้านี้ ความแตกต่างคือ:

- SSE ต้องจัดการสองอย่าง คือ การเชื่อมต่อและข้อความ
- เนื่องจากเซิร์ฟเวอร์นี้สามารถรันได้ทุกที่ คุณจึงต้องปรับวิธีการใช้งานเครื่องมือต่างๆ เช่น Inspector และ Visual Studio Code ให้เหมาะสม ซึ่งหมายความว่าแทนที่จะชี้ไปที่วิธีการเริ่มเซิร์ฟเวอร์ คุณจะชี้ไปที่ endpoint ที่ใช้เชื่อมต่อแทน ดูตัวอย่างโค้ดด้านล่าง:

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

ในโค้ดข้างต้น:

- `/sse` ถูกตั้งเป็น route เมื่อมีการร้องขอไปยัง route นี้ จะสร้าง instance ของ transport ใหม่และเซิร์ฟเวอร์จะ *เชื่อมต่อ* ผ่าน transport นี้
- `/messages` คือ route ที่จัดการกับข้อความที่เข้ามา

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

ในโค้ดข้างต้น เรา:

- สร้าง instance ของ ASGI server (โดยใช้ Starlette โดยเฉพาะ) และ mount route เริ่มต้น `/`

  สิ่งที่เกิดขึ้นเบื้องหลังคือ routes `/sse` และ `/messages` ถูกตั้งขึ้นเพื่อจัดการการเชื่อมต่อและข้อความตามลำดับ ส่วนที่เหลือของแอป เช่น การเพิ่มฟีเจอร์หรือเครื่องมือต่างๆ จะทำงานเหมือนกับเซิร์ฟเวอร์ stdio

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

    มีสองเมธอดที่ช่วยให้เราสามารถเปลี่ยนจากเว็บเซิร์ฟเวอร์ธรรมดาเป็นเว็บเซิร์ฟเวอร์ที่รองรับ SSE ได้แก่:

    - `AddMcpServer` เมธอดนี้เพิ่มความสามารถให้เซิร์ฟเวอร์
    - `MapMcp` เมธอดนี้เพิ่ม routes เช่น `/SSE` และ `/messages`
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

    การรัน inspector จะเหมือนกันในทุก runtime สังเกตว่าแทนที่จะส่ง path ไปยังเซิร์ฟเวอร์และคำสั่งสำหรับเริ่มเซิร์ฟเวอร์ เราจะส่ง URL ที่เซิร์ฟเวอร์กำลังรันอยู่ และระบุ route `/sse` แทน

### -2- ทดลองใช้เครื่องมือ

เชื่อมต่อเซิร์ฟเวอร์โดยเลือก SSE ในเมนูดรอปดาวน์และกรอก URL ที่เซิร์ฟเวอร์ของคุณกำลังรันอยู่ เช่น http:localhost:4321/sse จากนั้นคลิกปุ่ม "Connect" เหมือนเดิม เลือกแสดงรายการเครื่องมือ เลือกเครื่องมือ และกรอกค่าป้อนข้อมูล คุณจะเห็นผลลัพธ์ดังภาพด้านล่าง:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.th.png)

เยี่ยมมาก คุณสามารถใช้งาน inspector ได้แล้ว ต่อไปมาดูวิธีใช้งานกับ Visual Studio Code กัน

## การบ้าน

ลองสร้างเซิร์ฟเวอร์ของคุณให้มีความสามารถมากขึ้น ดูที่ [หน้านี้](https://api.chucknorris.io/) เพื่อเพิ่มเครื่องมือที่เรียกใช้ API ตัวอย่าง คุณเป็นคนกำหนดว่าเซิร์ฟเวอร์ควรมีลักษณะอย่างไร ขอให้สนุก :)

## ตัวอย่างคำตอบ

[ตัวอย่างคำตอบ](./solution/README.md) นี่คือตัวอย่างโค้ดที่ทำงานได้จริง

## สรุปใจความสำคัญ

ใจความสำคัญจากบทนี้คือ:

- SSE เป็นการขนส่งข้อมูลแบบที่สองที่รองรับถัดจาก stdio
- เพื่อรองรับ SSE คุณต้องจัดการการเชื่อมต่อและข้อความที่เข้ามาโดยใช้เว็บเฟรมเวิร์ก
- คุณสามารถใช้ทั้ง Inspector และ Visual Studio Code เพื่อใช้งาน SSE server เหมือนกับเซิร์ฟเวอร์ stdio แต่จะมีความแตกต่างเล็กน้อย เช่น สำหรับ SSE คุณต้องเริ่มเซิร์ฟเวอร์แยกต่างหากก่อนแล้วจึงรันเครื่องมือ inspector และสำหรับ inspector คุณต้องระบุ URL ให้ชัดเจน

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## แหล่งข้อมูลเพิ่มเติม

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## ต่อไป

- ถัดไป: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้