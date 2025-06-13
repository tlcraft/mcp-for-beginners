<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:42:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "th"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

บทนี้ให้คำแนะนำอย่างครบถ้วนในการใช้งานการสตรีมแบบปลอดภัย ขยายตัวได้ และแบบเรียลไทม์ด้วย Model Context Protocol (MCP) ผ่าน HTTPS ครอบคลุมแรงจูงใจของการสตรีม กลไกการขนส่งที่มีอยู่ วิธีการใช้งาน HTTP แบบสตรีมใน MCP แนวทางปฏิบัติด้านความปลอดภัย การย้ายจาก SSE และคำแนะนำเชิงปฏิบัติสำหรับการสร้างแอปพลิเคชัน MCP สตรีมมิ่งของคุณเอง

## Transport Mechanisms and Streaming in MCP

ส่วนนี้สำรวจกลไกการขนส่งที่มีใน MCP และบทบาทของพวกมันในการเปิดใช้งานความสามารถสตรีมสำหรับการสื่อสารแบบเรียลไทม์ระหว่างไคลเอนต์และเซิร์ฟเวอร์

### What is a Transport Mechanism?

กลไกการขนส่งคือวิธีการแลกเปลี่ยนข้อมูลระหว่างไคลเอนต์กับเซิร์ฟเวอร์ MCP รองรับประเภทการขนส่งหลายแบบเพื่อตอบโจทย์สภาพแวดล้อมและความต้องการที่แตกต่างกัน:

- **stdio**: อินพุต/เอาต์พุตมาตรฐาน เหมาะสำหรับเครื่องมือบนเครื่องและ CLI ง่ายแต่ไม่เหมาะกับเว็บหรือคลาวด์
- **SSE (Server-Sent Events)**: ให้เซิร์ฟเวอร์ส่งอัปเดตเรียลไทม์ไปยังไคลเอนต์ผ่าน HTTP ดีสำหรับเว็บ UI แต่มีข้อจำกัดด้านการขยายตัวและความยืดหยุ่น
- **Streamable HTTP**: การขนส่งสตรีมผ่าน HTTP สมัยใหม่ รองรับการแจ้งเตือนและขยายตัวได้ดีกว่า แนะนำสำหรับสถานการณ์การใช้งานในโปรดักชันและคลาวด์ส่วนใหญ่

### Comparison Table

ดูตารางเปรียบเทียบด้านล่างเพื่อเข้าใจความแตกต่างระหว่างกลไกการขนส่งเหล่านี้:

| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | No               | No        | Low         | Local CLI tools         |
| SSE               | Yes              | Yes       | Medium      | Web, real-time updates  |
| Streamable HTTP   | Yes              | Yes       | High        | Cloud, multi-client     |

> **Tip:** การเลือกกลไกการขนส่งที่เหมาะสมส่งผลต่อประสิทธิภาพ การขยายตัว และประสบการณ์ผู้ใช้ **Streamable HTTP** แนะนำสำหรับแอปพลิเคชันที่ทันสมัย ขยายตัวได้ และพร้อมใช้งานบนคลาวด์

โปรดสังเกตกลไก stdio และ SSE ที่แสดงในบทก่อนหน้า และ Streamable HTTP ที่เป็นหัวข้อในบทนี้

## Streaming: Concepts and Motivation

การเข้าใจแนวคิดพื้นฐานและแรงจูงใจเบื้องหลังการสตรีมเป็นสิ่งสำคัญสำหรับการสร้างระบบสื่อสารแบบเรียลไทม์ที่มีประสิทธิภาพ

**Streaming** คือเทคนิคในการเขียนโปรแกรมเครือข่ายที่อนุญาตให้ส่งและรับข้อมูลเป็นชิ้นเล็ก ๆ หรือเป็นลำดับของเหตุการณ์ แทนการรอให้ข้อมูลทั้งหมดพร้อมก่อน ซึ่งมีประโยชน์อย่างมากสำหรับ:

- ไฟล์หรือชุดข้อมูลขนาดใหญ่
- การอัปเดตแบบเรียลไทม์ (เช่น แชท แถบแสดงความคืบหน้า)
- การคำนวณที่ใช้เวลานานและต้องการแจ้งผู้ใช้ตลอดเวลา

นี่คือสิ่งที่ควรรู้เกี่ยวกับการสตรีมในภาพรวม:

- ข้อมูลถูกส่งอย่างต่อเนื่อง ไม่ใช่ทั้งหมดในครั้งเดียว
- ไคลเอนต์สามารถประมวลผลข้อมูลได้ทันทีที่ได้รับ
- ลดความรู้สึกหน่วงเวลาและเพิ่มประสบการณ์ผู้ใช้

### Why use streaming?

เหตุผลในการใช้การสตรีมมีดังนี้:

- ผู้ใช้ได้รับฟีดแบ็คทันที ไม่ต้องรอจนจบ
- เปิดทางให้แอปแบบเรียลไทม์และ UI ที่ตอบสนองเร็ว
- ใช้ทรัพยากรเครือข่ายและคำนวณได้อย่างมีประสิทธิภาพมากขึ้น

### Simple Example: HTTP Streaming Server & Client

ตัวอย่างง่าย ๆ ของการใช้งานสตรีมมิ่ง:

<details>
<summary>Python</summary>

**Server (Python, using FastAPI and StreamingResponse):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Client (Python, using requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

ตัวอย่างนี้แสดงให้เห็นเซิร์ฟเวอร์ส่งชุดข้อความไปยังไคลเอนต์ทันทีที่พร้อม แทนการรอให้ข้อความทั้งหมดพร้อมก่อน

**How it works:**
- เซิร์ฟเวอร์ส่งข้อความแต่ละข้อความเมื่อพร้อม
- ไคลเอนต์รับและพิมพ์ข้อมูลแต่ละส่วนทันทีที่ได้รับ

**Requirements:**
- เซิร์ฟเวอร์ต้องใช้การตอบสนองแบบสตรีม (เช่น `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) แทนการเลือกสตรีมผ่าน MCP

- **สำหรับความต้องการสตรีมง่าย ๆ:** การสตรีม HTTP แบบคลาสสิกง่ายและเพียงพอสำหรับงานพื้นฐาน

- **สำหรับแอปพลิเคชันซับซ้อนและโต้ตอบได้:** การสตรีม MCP ให้โครงสร้างที่ชัดเจนพร้อมข้อมูลเมตาที่สมบูรณ์และแยกการแจ้งเตือนกับผลลัพธ์สุดท้าย

- **สำหรับแอป AI:** ระบบแจ้งเตือนของ MCP มีประโยชน์อย่างยิ่งสำหรับงาน AI ที่ใช้เวลานานที่ต้องการแจ้งความคืบหน้าให้ผู้ใช้ทราบ

## Streaming in MCP

ตอนนี้คุณได้เห็นคำแนะนำและการเปรียบเทียบระหว่างการสตรีมแบบคลาสสิกและ MCP แล้ว เรามาดูรายละเอียดว่าคุณจะใช้การสตรีมใน MCP ได้อย่างไร

การเข้าใจวิธีการทำงานของสตรีมในกรอบงาน MCP เป็นสิ่งจำเป็นสำหรับการสร้างแอปที่ตอบสนองและให้ฟีดแบ็คแบบเรียลไทม์แก่ผู้ใช้ในระหว่างกระบวนการที่ใช้เวลานาน

ใน MCP การสตรีมไม่ได้หมายถึงการส่งผลลัพธ์หลักเป็นชิ้น แต่เป็นการส่ง **การแจ้งเตือน** ไปยังไคลเอนต์ในขณะที่เครื่องมือกำลังประมวลผลคำขอ การแจ้งเตือนเหล่านี้อาจรวมถึงการอัปเดตความคืบหน้า บันทึก หรือเหตุการณ์อื่น ๆ

### How it works

ผลลัพธ์หลักยังคงถูกส่งเป็นการตอบกลับครั้งเดียว อย่างไรก็ตาม การแจ้งเตือนสามารถส่งแยกเป็นข้อความต่างหากระหว่างการประมวลผลเพื่ออัปเดตไคลเอนต์แบบเรียลไทม์ ไคลเอนต์ต้องสามารถจัดการและแสดงการแจ้งเตือนได้

## What is a Notification?

เราใช้คำว่า "Notification" หมายถึงอะไรในบริบทของ MCP?

การแจ้งเตือนคือข้อความที่ส่งจากเซิร์ฟเวอร์ไปยังไคลเอนต์เพื่อแจ้งความคืบหน้า สถานะ หรือเหตุการณ์อื่น ๆ ในระหว่างการทำงานที่ใช้เวลานาน การแจ้งเตือนช่วยเพิ่มความโปร่งใสและประสบการณ์ผู้ใช้

ตัวอย่างเช่น ไคลเอนต์ควรส่งการแจ้งเตือนเมื่อทำการจับมือเริ่มต้นกับเซิร์ฟเวอร์เสร็จแล้ว

การแจ้งเตือนมีลักษณะเป็นข้อความ JSON ดังนี้:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

การแจ้งเตือนเป็นส่วนหนึ่งของหัวข้อใน MCP ที่เรียกว่า ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging)

เพื่อให้การล็อกทำงาน เซิร์ฟเวอร์ต้องเปิดใช้งานเป็นฟีเจอร์/ความสามารถ ดังนี้:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ขึ้นอยู่กับ SDK ที่ใช้ การล็อกอาจเปิดใช้งานโดยอัตโนมัติ หรือคุณอาจต้องเปิดใช้งานเองในการตั้งค่าเซิร์ฟเวอร์

มีประเภทของการแจ้งเตือนต่าง ๆ ดังนี้:

| Level     | Description                    | Example Use Case                |
|-----------|-------------------------------|---------------------------------|
| debug     | ข้อมูลสำหรับดีบักละเอียด      | จุดเข้า/ออกฟังก์ชัน           |
| info      | ข้อความข้อมูลทั่วไป            | อัปเดตความคืบหน้าของงาน      |
| notice    | เหตุการณ์ปกติแต่สำคัญ          | การเปลี่ยนแปลงการตั้งค่า       |
| warning   | เงื่อนไขเตือน                  | การใช้ฟีเจอร์ที่เลิกใช้แล้ว    |
| error     | เงื่อนไขข้อผิดพลาด             | ความล้มเหลวของงาน             |
| critical  | เงื่อนไขรุนแรง                  | ความล้มเหลวของส่วนประกอบระบบ  |
| alert     | ต้องดำเนินการทันที             | ตรวจพบข้อมูลเสียหาย          |
| emergency | ระบบไม่สามารถใช้งานได้          | ระบบล่มทั้งหมด               |

## Implementing Notifications in MCP

การใช้งานการแจ้งเตือนใน MCP ต้องตั้งค่าทั้งฝั่งเซิร์ฟเวอร์และไคลเอนต์เพื่อรองรับการอัปเดตแบบเรียลไทม์ ซึ่งช่วยให้แอปของคุณส่งฟีดแบ็คให้ผู้ใช้ทันทีในระหว่างการทำงานที่ใช้เวลานาน

### Server-side: Sending Notifications

เริ่มจากฝั่งเซิร์ฟเวอร์ ใน MCP คุณกำหนดเครื่องมือที่สามารถส่งการแจ้งเตือนขณะประมวลผลคำขอ เซิร์ฟเวอร์ใช้วัตถุ context (ปกติคือ `ctx`) เพื่อส่งข้อความไปยังไคลเอนต์

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

ในตัวอย่างก่อนหน้า transport `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

### Client-side: Receiving Notifications

ไคลเอนต์ต้องใช้งาน message handler เพื่อประมวลผลและแสดงการแจ้งเตือนทันทีที่ได้รับ

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

ในโค้ดก่อนหน้า `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` ไคลเอนต์ของคุณจะมี message handler เพื่อจัดการการแจ้งเตือน

## Progress Notifications & Scenarios

ส่วนนี้อธิบายแนวคิดของการแจ้งเตือนความคืบหน้าใน MCP ทำไมถึงสำคัญ และวิธีใช้งานผ่าน Streamable HTTP พร้อมแบบฝึกหัดเพื่อเสริมความเข้าใจ

การแจ้งเตือนความคืบหน้าเป็นข้อความเรียลไทม์ที่ส่งจากเซิร์ฟเวอร์ไปยังไคลเอนต์ในระหว่างการทำงานที่ใช้เวลานาน แทนที่จะรอจนกระบวนการทั้งหมดเสร็จ เซิร์ฟเวอร์จะอัปเดตสถานะปัจจุบันให้ไคลเอนต์ทราบ ช่วยเพิ่มความโปร่งใส ประสบการณ์ผู้ใช้ และช่วยให้ง่ายต่อการดีบัก

**Example:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Why Use Progress Notifications?

การแจ้งเตือนความคืบหน้ามีความสำคัญด้วยเหตุผลหลายประการ:

- **ประสบการณ์ผู้ใช้ที่ดีขึ้น:** ผู้ใช้เห็นการอัปเดตระหว่างดำเนินงาน ไม่ใช่แค่ตอนจบ
- **ฟีดแบ็คแบบเรียลไทม์:** ไคลเอนต์สามารถแสดงแถบความคืบหน้าหรือบันทึก ทำให้แอปดูตอบสนองดี
- **ช่วยดีบักและติดตามง่ายขึ้น:** นักพัฒนาและผู้ใช้เห็นได้ว่ากระบวนการใดช้า หรือติดขัดตรงไหน

### How to Implement Progress Notifications

วิธีการใช้งานแจ้งเตือนความคืบหน้าใน MCP:

- **ฝั่งเซิร์ฟเวอร์:** ใช้ `ctx.info()` or `ctx.log()` เพื่อส่งการแจ้งเตือนทุกครั้งที่ประมวลผลรายการ ส่งข้อความไปยังไคลเอนต์ก่อนผลลัพธ์หลักพร้อม
- **ฝั่งไคลเอนต์:** สร้าง message handler ที่ฟังและแสดงการแจ้งเตือนทันทีที่ได้รับ ตัวจัดการนี้จะแยกแยะระหว่างการแจ้งเตือนกับผลลัพธ์สุดท้าย

**Server Example:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Client Example:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Security Considerations

เมื่อสร้าง MCP เซิร์ฟเวอร์ที่ใช้การขนส่งผ่าน HTTP ความปลอดภัยเป็นเรื่องสำคัญที่ต้องใส่ใจอย่างรอบคอบเพื่อป้องกันช่องโหว่และการโจมตีต่าง ๆ

### Overview

ความปลอดภัยเป็นสิ่งจำเป็นเมื่อเปิด MCP เซิร์ฟเวอร์ผ่าน HTTP Streamable HTTP เพิ่มพื้นผิวโจมตีใหม่ ๆ และต้องการการตั้งค่าที่ระมัดระวัง

### Key Points
- **Origin Header Validation**: ตรวจสอบค่า `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` แทนการใช้ไคลเอนต์ SSE
3. **Implement a message handler** ในไคลเอนต์เพื่อจัดการการแจ้งเตือน
4. **Test for compatibility** กับเครื่องมือและเวิร์กโฟลว์ที่มีอยู่

### Maintaining Compatibility

แนะนำให้รักษาความเข้ากันได้กับไคลเอนต์ SSE เดิมในระหว่างการย้ายระบบ นี่คือแนวทางบางส่วน:

- คุณสามารถรองรับทั้ง SSE และ Streamable HTTP โดยรันทั้งสองบน endpoints ต่างกัน
- ค่อย ๆ ย้ายไคลเอนต์ไปยังการขนส่งแบบใหม่

### Challenges

ต้องแก้ไขปัญหาดังนี้ในระหว่างการย้าย:

- ทำให้แน่ใจว่าไคลเอนต์ทุกตัวได้รับการอัปเดต
- จัดการความแตกต่างในการส่งการแจ้งเตือน

### Assignment: Build Your Own Streaming MCP App

**Scenario:**
สร้าง MCP เซิร์ฟเวอร์และไคลเอนต์ที่เซิร์ฟเวอร์ประมวลผลรายการของไอเทม (เช่น ไฟล์หรือเอกสาร) และส่งการแจ้งเตือนสำหรับแต่ละไอเทมที่ประมวลผล ไคลเอนต์จะแสดงการแจ้งเตือนแต่ละรายการทันทีที่ได้รับ

**Steps:**

1. สร้างเครื่องมือบนเซิร์ฟเวอร์ที่ประมวลผลรายการและส่งการแจ้งเตือนสำหรับแต่ละไอเทม
2. สร้างไคลเอนต์ที่มี message handler เพื่อแสดงการแจ้งเตือนแบบเรียลไทม์
3. ทดสอบการใช้งานโดยรันทั้งเซิร์ฟเวอร์และไคลเอนต์ และสังเกตการแจ้งเตือน

[Solution](./solution/README.md)

## Further Reading & What Next?

เพื่อเดินหน้าต่อกับ MCP สตรีมมิ่งและขยายความรู้ ส่วนนี้มีแหล่งข้อมูลเพิ่มเติมและขั้นตอนถัดไปสำหรับการสร้างแอปพลิเคชันที่ซับซ้อนขึ้น

### Further Reading

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### What Next?

- ลองสร้างเครื่องมือ MCP ขั้นสูงที่ใช้การสตรีมสำหรับวิเคราะห์แบบเรียลไทม์ แชท หรือแก้ไขร่วมกัน
- สำรวจการผสาน MCP สตรีมมิ่งกับเฟรมเวิร์ก frontend (React, Vue ฯลฯ) เพื่ออัปเดต UI แบบสด
- ถัดไป: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้การแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้