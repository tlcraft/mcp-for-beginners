<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T06:04:51+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "th"
}
-->
# SSE Server

SSE (Server Sent Events) คือมาตรฐานสำหรับการสตรีมข้อมูลจากเซิร์ฟเวอร์ไปยังไคลเอนต์ ช่วยให้เซิร์ฟเวอร์ส่งข้อมูลอัปเดตแบบเรียลไทม์ไปยังไคลเอนต์ผ่าน HTTP ซึ่งเหมาะอย่างยิ่งสำหรับแอปพลิเคชันที่ต้องการอัปเดตสด เช่น แอปแชท การแจ้งเตือน หรือฟีดข้อมูลแบบเรียลไทม์ นอกจากนี้เซิร์ฟเวอร์ของคุณยังสามารถให้บริการไคลเอนต์หลายรายพร้อมกันได้ เพราะมันทำงานบนเซิร์ฟเวอร์ที่อาจรันอยู่บนคลาวด์ได้

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
- เนื่องจากเซิร์ฟเวอร์นี้สามารถรันได้ทุกที่ คุณจึงต้องปรับวิธีการทำงานกับเครื่องมืออย่าง Inspector และ Visual Studio Code ให้เหมาะสม ซึ่งหมายความว่าแทนที่จะชี้ไปที่วิธีการเริ่มเซิร์ฟเวอร์ คุณจะชี้ไปที่ endpoint ที่สามารถสร้างการเชื่อมต่อได้ ดูตัวอย่างโค้ดด้านล่าง:

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

- `/sse` ถูกตั้งเป็นเส้นทาง เมื่อมีคำขอไปยังเส้นทางนี้ จะสร้างอินสแตนซ์ของ transport ใหม่และเซิร์ฟเวอร์จะ *เชื่อมต่อ* ผ่าน transport นี้
- `/messages` คือเส้นทางที่จัดการข้อความที่เข้ามา

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

- สร้างอินสแตนซ์ของ ASGI server (โดยใช้ Starlette โดยเฉพาะ) และเมานต์เส้นทางเริ่มต้น `/`

  สิ่งที่เกิดขึ้นเบื้องหลังคือเส้นทาง `/sse` และ `/messages` ถูกตั้งค่าให้จัดการการเชื่อมต่อและข้อความตามลำดับ ส่วนที่เหลือของแอป เช่น การเพิ่มฟีเจอร์อย่างเครื่องมือ จะทำงานเหมือนกับเซิร์ฟเวอร์ stdio

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

    มีสองเมธอดที่ช่วยให้เราเปลี่ยนจากเว็บเซิร์ฟเวอร์เป็นเว็บเซิร์ฟเวอร์ที่รองรับ SSE ได้แก่:

    - `AddMcpServer` เมธอดนี้เพิ่มความสามารถให้เซิร์ฟเวอร์
    - `MapMcp` เมธอดนี้เพิ่มเส้นทางเช่น `/SSE` และ `/messages`

ตอนนี้ที่เราเข้าใจ SSE มากขึ้นแล้ว มาสร้าง SSE server กันเลย

## แบบฝึกหัด: การสร้าง SSE Server

ในการสร้างเซิร์ฟเวอร์ เราต้องคำนึงถึงสองอย่าง:

- ต้องใช้เว็บเซิร์ฟเวอร์เพื่อเปิดเผย endpoint สำหรับการเชื่อมต่อและข้อความ
- สร้างเซิร์ฟเวอร์เหมือนที่เคยทำกับ stdio โดยใช้เครื่องมือ ทรัพยากร และพรอมต์

### -1- สร้างอินสแตนซ์เซิร์ฟเวอร์

ในการสร้างเซิร์ฟเวอร์ เราใช้ชนิดข้อมูลเหมือนกับ stdio แต่สำหรับ transport เราต้องเลือก SSE

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

ในโค้ดข้างต้น เราได้:

- สร้างอินสแตนซ์เซิร์ฟเวอร์
- กำหนดแอปโดยใช้เว็บเฟรมเวิร์ก express
- สร้างตัวแปร transports เพื่อเก็บการเชื่อมต่อที่เข้ามา

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

ในโค้ดข้างต้น เราได้:

- นำเข้าห้องสมุดที่จำเป็น โดยใช้ Starlette (ASGI framework)
- สร้างอินสแตนซ์ MCP server ชื่อ `mcp`

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

ในจุดนี้ เราได้:

- สร้างเว็บแอป
- เพิ่มการรองรับฟีเจอร์ MCP ผ่าน `AddMcpServer`

ต่อไปเราจะเพิ่มเส้นทางที่จำเป็น

### -2- เพิ่มเส้นทาง

เพิ่มเส้นทางที่จัดการการเชื่อมต่อและข้อความที่เข้ามา:

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

ในโค้ดข้างต้น เรากำหนด:

- เส้นทาง `/sse` ที่สร้าง transport ประเภท SSE และเรียก `connect` บน MCP server
- เส้นทาง `/messages` ที่จัดการข้อความที่เข้ามา

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

ในโค้ดข้างต้น เราได้:

- สร้างอินสแตนซ์แอป ASGI โดยใช้ Starlette และส่ง `mcp.sse_app()` เข้าไปในรายการเส้นทาง ซึ่งจะเมานต์เส้นทาง `/sse` และ `/messages` บนแอป

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

เราเพิ่มโค้ดบรรทัดสุดท้าย `add.MapMcp()` ซึ่งหมายความว่าเรามีเส้นทาง `/SSE` และ `/messages` แล้ว

ต่อไปเพิ่มความสามารถให้เซิร์ฟเวอร์

### -3- เพิ่มความสามารถให้เซิร์ฟเวอร์

เมื่อกำหนดทุกอย่างที่เกี่ยวกับ SSE แล้ว มาสร้างความสามารถให้เซิร์ฟเวอร์ เช่น เครื่องมือ พรอมต์ และทรัพยากร

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

นี่คือตัวอย่างการเพิ่มเครื่องมือ เครื่องมือนี้สร้างเครื่องมือชื่อ "random-joke" ที่เรียก API ของ Chuck Norris และส่งคืนผลลัพธ์ในรูปแบบ JSON

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

ตอนนี้เซิร์ฟเวอร์ของคุณมีเครื่องมือหนึ่งตัวแล้ว

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

1. สร้างเครื่องมือก่อน โดยสร้างไฟล์ *Tools.cs* ที่มีเนื้อหาดังนี้:

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

  ในนี้เราได้:

  - สร้างคลาส `Tools` พร้อมกับ decorator `McpServerToolType`
  - กำหนดเครื่องมือ `AddNumbers` โดยตกแต่งเมธอดด้วย `McpServerTool` พร้อมระบุพารามิเตอร์และการทำงาน

1. ใช้คลาส `Tools` ที่สร้างขึ้น:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  เราเพิ่มการเรียก `WithTools` ที่ระบุ `Tools` เป็นคลาสที่เก็บเครื่องมือ เท่านี้ก็พร้อมใช้งาน

เยี่ยมมาก เรามีเซิร์ฟเวอร์ที่ใช้ SSE แล้ว มาลองใช้งานกันต่อ

## แบบฝึกหัด: ดีบัก SSE Server ด้วย Inspector

Inspector เป็นเครื่องมือที่ดีที่เราเห็นในบทเรียนก่อนหน้า [Creating your first server](/03-GettingStarted/01-first-server/README.md) มาดูกันว่าเราจะใช้ Inspector กับ SSE ได้ไหม:

### -1- การรัน Inspector

ก่อนรัน Inspector ต้องมี SSE server รันอยู่ก่อน ดังนั้นมาทำกันเลย:

1. รันเซิร์ฟเวอร์

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    สังเกตว่าเราใช้คำสั่ง `uvicorn` ซึ่งติดตั้งเมื่อเราพิมพ์ `pip install "mcp[cli]"` การพิมพ์ `server:app` หมายถึงเรากำลังรันไฟล์ `server.py` ที่มีอินสแตนซ์ Starlette ชื่อ `app`

    ### .NET

    ```sh
    dotnet run
    ```

    คำสั่งนี้จะเริ่มเซิร์ฟเวอร์ เพื่อโต้ตอบกับมัน คุณต้องเปิดเทอร์มินัลใหม่

1. รัน Inspector

    > ![NOTE]
    > รันคำสั่งนี้ในหน้าต่างเทอร์มินัลแยกต่างหากจากที่รันเซิร์ฟเวอร์ และอย่าลืมปรับคำสั่งด้านล่างให้ตรงกับ URL ที่เซิร์ฟเวอร์ของคุณรันอยู่

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    การรัน Inspector เหมือนกันในทุก runtime สังเกตว่าแทนที่จะส่งพาธไปยังเซิร์ฟเวอร์และคำสั่งเริ่มเซิร์ฟเวอร์ เราจะส่ง URL ที่เซิร์ฟเวอร์รันอยู่และระบุเส้นทาง `/sse`

### -2- ทดลองใช้เครื่องมือ

เชื่อมต่อเซิร์ฟเวอร์โดยเลือก SSE ในเมนูดรอปดาวน์และกรอก URL ที่เซิร์ฟเวอร์ของคุณรันอยู่ เช่น http:localhost:4321/sse จากนั้นคลิกปุ่ม "Connect" เหมือนเดิม เลือกรายการเครื่องมือ เลือกเครื่องมือ และใส่ค่าป้อนข้อมูล คุณจะเห็นผลลัพธ์ดังภาพด้านล่าง:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.th.png)

เยี่ยมมาก คุณสามารถใช้งาน Inspector ได้ ต่อไปมาดูวิธีใช้งานกับ Visual Studio Code กัน

## การบ้าน

ลองสร้างเซิร์ฟเวอร์ของคุณให้มีความสามารถมากขึ้น ดู [หน้านี้](https://api.chucknorris.io/) เพื่อเพิ่มเครื่องมือที่เรียก API ตัวอย่าง คุณจะออกแบบเซิร์ฟเวอร์อย่างไรก็ได้ ขอให้สนุก :)

## ตัวอย่างคำตอบ

[Solution](./solution/README.md) นี่คือตัวอย่างคำตอบที่มีโค้ดทำงานได้

## สรุปใจความสำคัญ

ใจความสำคัญจากบทนี้คือ:

- SSE เป็นการขนส่งข้อมูลที่รองรับเป็นอันดับสองถัดจาก stdio
- เพื่อรองรับ SSE คุณต้องจัดการการเชื่อมต่อและข้อความที่เข้ามาโดยใช้เว็บเฟรมเวิร์ก
- คุณสามารถใช้ทั้ง Inspector และ Visual Studio Code เพื่อใช้งาน SSE server เหมือนกับเซิร์ฟเวอร์ stdio แต่จะมีความแตกต่างเล็กน้อย เช่น สำหรับ SSE คุณต้องเริ่มเซิร์ฟเวอร์แยกต่างหากก่อนแล้วจึงรัน Inspector และสำหรับ Inspector ต้องระบุ URL ด้วย

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