<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:34:01+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "th"
}
-->
# เซิร์ฟเวอร์ MCP ด้วย stdio Transport

> **⚠️ อัปเดตสำคัญ**: ตั้งแต่ MCP Specification วันที่ 18 มิถุนายน 2025 การใช้งาน SSE (Server-Sent Events) แบบเดี่ยวได้ถูก **ยกเลิก** และแทนที่ด้วย "Streamable HTTP" transport สเปค MCP ปัจจุบันกำหนดวิธีการส่งข้อมูลหลักสองแบบ:
> 1. **stdio** - การส่งข้อมูลผ่าน input/output มาตรฐาน (แนะนำสำหรับเซิร์ฟเวอร์ในเครื่อง)
> 2. **Streamable HTTP** - สำหรับเซิร์ฟเวอร์ระยะไกลที่อาจใช้ SSE ภายใน
>
> บทเรียนนี้ได้รับการปรับปรุงเพื่อเน้นที่ **stdio transport** ซึ่งเป็นวิธีที่แนะนำสำหรับการใช้งานเซิร์ฟเวอร์ MCP ส่วนใหญ่

stdio transport ช่วยให้เซิร์ฟเวอร์ MCP สื่อสารกับไคลเอนต์ผ่าน input และ output มาตรฐาน นี่เป็นวิธีการส่งข้อมูลที่ใช้บ่อยที่สุดและแนะนำในสเปค MCP ปัจจุบัน โดยให้วิธีที่ง่ายและมีประสิทธิภาพในการสร้างเซิร์ฟเวอร์ MCP ที่สามารถผสานรวมกับแอปพลิเคชันไคลเอนต์ต่างๆ ได้อย่างง่ายดาย

## ภาพรวม

บทเรียนนี้ครอบคลุมวิธีการสร้างและใช้งานเซิร์ฟเวอร์ MCP โดยใช้ stdio transport

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- สร้างเซิร์ฟเวอร์ MCP โดยใช้ stdio transport
- ดีบักเซิร์ฟเวอร์ MCP ด้วย Inspector
- ใช้งานเซิร์ฟเวอร์ MCP ผ่าน Visual Studio Code
- เข้าใจกลไกการส่งข้อมูล MCP ปัจจุบันและเหตุผลที่ stdio ถูกแนะนำ

## stdio Transport - วิธีการทำงาน

stdio transport เป็นหนึ่งในสองประเภทการส่งข้อมูลที่รองรับในสเปค MCP ปัจจุบัน (18 มิถุนายน 2025) วิธีการทำงานมีดังนี้:

- **การสื่อสารที่ง่าย**: เซิร์ฟเวอร์อ่านข้อความ JSON-RPC จาก input มาตรฐาน (`stdin`) และส่งข้อความไปยัง output มาตรฐาน (`stdout`)
- **กระบวนการพื้นฐาน**: ไคลเอนต์เปิดเซิร์ฟเวอร์ MCP เป็น subprocess
- **รูปแบบข้อความ**: ข้อความเป็นคำขอ JSON-RPC การแจ้งเตือน หรือการตอบกลับ โดยแยกด้วยบรรทัดใหม่
- **การบันทึก**: เซิร์ฟเวอร์ **อาจ** เขียนข้อความ UTF-8 ไปยัง error มาตรฐาน (`stderr`) เพื่อบันทึกข้อมูล

### ข้อกำหนดสำคัญ:
- ข้อความ **ต้อง** แยกด้วยบรรทัดใหม่และ **ต้องไม่** มีบรรทัดใหม่ฝังอยู่
- เซิร์ฟเวอร์ **ต้องไม่** เขียนสิ่งใดไปยัง `stdout` ที่ไม่ใช่ข้อความ MCP ที่ถูกต้อง
- ไคลเอนต์ **ต้องไม่** เขียนสิ่งใดไปยัง `stdin` ของเซิร์ฟเวอร์ที่ไม่ใช่ข้อความ MCP ที่ถูกต้อง

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

ในโค้ดข้างต้น:

- เรา import `Server` และ `StdioServerTransport` จาก MCP SDK
- เราสร้าง instance ของเซิร์ฟเวอร์ด้วยการตั้งค่าพื้นฐานและความสามารถ

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

ในโค้ดข้างต้น:

- เราสร้าง instance ของเซิร์ฟเวอร์โดยใช้ MCP SDK
- กำหนดเครื่องมือด้วย decorators
- ใช้ context manager `stdio_server` เพื่อจัดการ transport

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

ความแตกต่างสำคัญจาก SSE คือ stdio servers:

- ไม่ต้องตั้งค่าเว็บเซิร์ฟเวอร์หรือ endpoints HTTP
- ถูกเปิดใช้งานเป็น subprocess โดยไคลเอนต์
- สื่อสารผ่าน streams stdin/stdout
- ง่ายต่อการพัฒนาและดีบัก

## แบบฝึกหัด: การสร้างเซิร์ฟเวอร์ stdio

ในการสร้างเซิร์ฟเวอร์ของเรา เราต้องคำนึงถึงสองสิ่ง:

- เราต้องใช้เว็บเซิร์ฟเวอร์เพื่อเปิดเผย endpoints สำหรับการเชื่อมต่อและข้อความ

## ห้องปฏิบัติการ: การสร้างเซิร์ฟเวอร์ MCP stdio แบบง่าย

ในห้องปฏิบัติการนี้ เราจะสร้างเซิร์ฟเวอร์ MCP แบบง่ายโดยใช้ stdio transport ที่แนะนำ เซิร์ฟเวอร์นี้จะเปิดเผยเครื่องมือที่ไคลเอนต์สามารถเรียกใช้ได้โดยใช้ Model Context Protocol มาตรฐาน

### สิ่งที่ต้องเตรียม

- Python 3.8 หรือใหม่กว่า
- MCP Python SDK: `pip install mcp`
- ความเข้าใจพื้นฐานเกี่ยวกับการเขียนโปรแกรมแบบ async

เริ่มต้นสร้างเซิร์ฟเวอร์ MCP stdio แรกของเรา:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## ความแตกต่างสำคัญจากวิธี SSE ที่ถูกยกเลิก

**Stdio Transport (มาตรฐานปัจจุบัน):**
- โมเดล subprocess ที่ง่าย - ไคลเอนต์เปิดเซิร์ฟเวอร์เป็น child process
- สื่อสารผ่าน stdin/stdout โดยใช้ข้อความ JSON-RPC
- ไม่ต้องตั้งค่าเว็บเซิร์ฟเวอร์
- ประสิทธิภาพและความปลอดภัยที่ดีกว่า
- ง่ายต่อการดีบักและพัฒนา

**SSE Transport (ยกเลิกตั้งแต่ MCP 18 มิถุนายน 2025):**
- ต้องใช้เว็บเซิร์ฟเวอร์พร้อม endpoints SSE
- การตั้งค่าที่ซับซ้อนมากขึ้นด้วยโครงสร้างพื้นฐานเว็บเซิร์ฟเวอร์
- ข้อพิจารณาด้านความปลอดภัยเพิ่มเติมสำหรับ endpoints HTTP
- ถูกแทนที่ด้วย Streamable HTTP สำหรับสถานการณ์ที่ใช้เว็บ

### การสร้างเซิร์ฟเวอร์ด้วย stdio transport

ในการสร้างเซิร์ฟเวอร์ stdio เราต้อง:

1. **Import ไลบรารีที่จำเป็น** - เราต้องใช้ส่วนประกอบเซิร์ฟเวอร์ MCP และ stdio transport
2. **สร้าง instance ของเซิร์ฟเวอร์** - กำหนดเซิร์ฟเวอร์พร้อมความสามารถ
3. **กำหนดเครื่องมือ** - เพิ่มฟังก์ชันที่เราต้องการเปิดเผย
4. **ตั้งค่า transport** - กำหนดการสื่อสาร stdio
5. **รันเซิร์ฟเวอร์** - เริ่มเซิร์ฟเวอร์และจัดการข้อความ

มาสร้างทีละขั้นตอน:

### ขั้นตอนที่ 1: สร้างเซิร์ฟเวอร์ stdio แบบพื้นฐาน

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### ขั้นตอนที่ 2: เพิ่มเครื่องมือเพิ่มเติม

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### ขั้นตอนที่ 3: รันเซิร์ฟเวอร์

บันทึกโค้ดเป็น `server.py` และรันจาก command line:

```bash
python server.py
```

เซิร์ฟเวอร์จะเริ่มต้นและรอ input จาก stdin โดยสื่อสารผ่านข้อความ JSON-RPC ผ่าน stdio transport

### ขั้นตอนที่ 4: ทดสอบด้วย Inspector

คุณสามารถทดสอบเซิร์ฟเวอร์ของคุณโดยใช้ MCP Inspector:

1. ติดตั้ง Inspector: `npx @modelcontextprotocol/inspector`
2. รัน Inspector และชี้ไปที่เซิร์ฟเวอร์ของคุณ
3. ทดสอบเครื่องมือที่คุณสร้างขึ้น

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Add tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Get a personalized greeting",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Name of the person to greet",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Hello, ${request.params.arguments?.name}! Welcome to MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Unknown tool: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Get a personalized greeting")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Calculate the sum of two numbers")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. สร้างเครื่องมือก่อน โดยสร้างไฟล์ *Tools.cs* ด้วยเนื้อหาดังนี้:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **เปิดอินเทอร์เฟซเว็บ**: Inspector จะเปิดหน้าต่างเบราว์เซอร์ที่แสดงความสามารถของเซิร์ฟเวอร์ของคุณ

3. **ทดสอบเครื่องมือ**: 
   - ลองใช้เครื่องมือ `get_greeting` กับชื่อที่แตกต่างกัน
   - ทดสอบเครื่องมือ `calculate_sum` กับตัวเลขต่างๆ
   - เรียกใช้เครื่องมือ `get_server_info` เพื่อดูข้อมูลเมตาของเซิร์ฟเวอร์

4. **ตรวจสอบการสื่อสาร**: Inspector แสดงข้อความ JSON-RPC ที่แลกเปลี่ยนระหว่างไคลเอนต์และเซิร์ฟเวอร์

### สิ่งที่คุณควรเห็น

เมื่อเซิร์ฟเวอร์ของคุณเริ่มต้นอย่างถูกต้อง คุณควรเห็น:
- ความสามารถของเซิร์ฟเวอร์ที่แสดงใน Inspector
- เครื่องมือที่พร้อมใช้งานสำหรับการทดสอบ
- การแลกเปลี่ยนข้อความ JSON-RPC ที่สำเร็จ
- การตอบกลับของเครื่องมือที่แสดงในอินเทอร์เฟซ

### ปัญหาทั่วไปและวิธีแก้ไข

**เซิร์ฟเวอร์ไม่เริ่มต้น:**
- ตรวจสอบว่าติดตั้ง dependencies ทั้งหมดแล้ว: `pip install mcp`
- ตรวจสอบไวยากรณ์ Python และการเยื้อง
- ดูข้อความแสดงข้อผิดพลาดในคอนโซล

**เครื่องมือไม่ปรากฏ:**
- ตรวจสอบว่า `@server.tool()` decorators มีอยู่
- ตรวจสอบว่าฟังก์ชันเครื่องมือถูกกำหนดก่อน `main()`
- ตรวจสอบว่าเซิร์ฟเวอร์ถูกตั้งค่าอย่างถูกต้อง

**ปัญหาการเชื่อมต่อ:**
- ตรวจสอบว่าเซิร์ฟเวอร์ใช้ stdio transport อย่างถูกต้อง
- ตรวจสอบว่าไม่มีกระบวนการอื่นรบกวน
- ตรวจสอบไวยากรณ์คำสั่ง Inspector

## งานที่ได้รับมอบหมาย

ลองสร้างเซิร์ฟเวอร์ของคุณด้วยความสามารถเพิ่มเติม ดู [หน้านี้](https://api.chucknorris.io/) เพื่อเพิ่มเครื่องมือที่เรียก API ตัวอย่าง คุณสามารถออกแบบเซิร์ฟเวอร์ได้ตามต้องการ สนุกกับการสร้างนะ :)

## คำตอบ

[คำตอบ](./solution/README.md) นี่คือตัวอย่างคำตอบพร้อมโค้ดที่ใช้งานได้

## สิ่งที่ควรจดจำ

สิ่งที่ควรจดจำจากบทนี้คือ:

- stdio transport เป็นกลไกที่แนะนำสำหรับเซิร์ฟเวอร์ MCP ในเครื่อง
- stdio transport ช่วยให้การสื่อสารระหว่างเซิร์ฟเวอร์ MCP และไคลเอนต์เป็นไปอย่างราบรื่นโดยใช้ input และ output มาตรฐาน
- คุณสามารถใช้ Inspector และ Visual Studio Code เพื่อใช้งานเซิร์ฟเวอร์ stdio ได้โดยตรง ทำให้การดีบักและการผสานรวมเป็นเรื่องง่าย

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## แหล่งข้อมูลเพิ่มเติม

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## สิ่งที่ต้องทำต่อไป

## ขั้นตอนถัดไป

ตอนนี้คุณได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์ MCP ด้วย stdio transport แล้ว คุณสามารถสำรวจหัวข้อขั้นสูงเพิ่มเติมได้:

- **ขั้นตอนถัดไป**: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md) - เรียนรู้เกี่ยวกับกลไกการส่งข้อมูลที่รองรับอีกแบบสำหรับเซิร์ฟเวอร์ระยะไกล
- **ขั้นสูง**: [MCP Security Best Practices](../../02-Security/README.md) - ใช้การรักษาความปลอดภัยในเซิร์ฟเวอร์ MCP ของคุณ
- **การใช้งานจริง**: [Deployment Strategies](../09-deployment/README.md) - นำเซิร์ฟเวอร์ของคุณไปใช้งานจริง

## แหล่งข้อมูลเพิ่มเติม

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - สเปคอย่างเป็นทางการ
- [MCP SDK Documentation](https://github.com/modelcontextprotocol/sdk) - เอกสารอ้างอิง SDK สำหรับทุกภาษา
- [Community Examples](../../06-CommunityContributions/README.md) - ตัวอย่างเซิร์ฟเวอร์เพิ่มเติมจากชุมชน

---

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาดั้งเดิมควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลภาษามืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้