<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:13:07+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "th"
}
-->
# การสตรีมผ่าน HTTPS ด้วย Model Context Protocol (MCP)

บทนี้เป็นคู่มือครบถ้วนสำหรับการใช้งานสตรีมมิ่งที่ปลอดภัย ขยายขนาดได้ และเรียลไทม์ด้วย Model Context Protocol (MCP) ผ่าน HTTPS ครอบคลุมทั้งแรงจูงใจในการสตรีม กลไกการขนส่งที่มีอยู่ วิธีการใช้งาน HTTP แบบสตรีมใน MCP แนวทางปฏิบัติด้านความปลอดภัย การย้ายจาก SSE และคำแนะนำเชิงปฏิบัติสำหรับการสร้างแอปพลิเคชัน MCP ที่รองรับสตรีมด้วยตัวเอง

## กลไกการขนส่งและการสตรีมใน MCP

ส่วนนี้จะสำรวจกลไกการขนส่งต่าง ๆ ที่มีใน MCP และบทบาทของแต่ละกลไกในการเปิดใช้งานฟีเจอร์สตรีมสำหรับการสื่อสารแบบเรียลไทม์ระหว่างไคลเอนต์กับเซิร์ฟเวอร์

### กลไกการขนส่งคืออะไร?

กลไกการขนส่งคือวิธีการแลกเปลี่ยนข้อมูลระหว่างไคลเอนต์และเซิร์ฟเวอร์ MCP รองรับประเภทการขนส่งหลายแบบเพื่อตอบสนองต่อสภาพแวดล้อมและความต้องการที่แตกต่างกัน:

- **stdio**: การรับ/ส่งข้อมูลมาตรฐาน เหมาะกับเครื่องมือที่ใช้ในเครื่องและ CLI ง่ายแต่ไม่เหมาะกับเว็บหรือคลาวด์
- **SSE (Server-Sent Events)**: ให้เซิร์ฟเวอร์ส่งอัปเดตแบบเรียลไทม์ไปยังไคลเอนต์ผ่าน HTTP เหมาะกับเว็บ UI แต่มีข้อจำกัดด้านการขยายและความยืดหยุ่น
- **Streamable HTTP**: การขนส่งสตรีมมิ่งบนพื้นฐาน HTTP แบบสมัยใหม่ รองรับการแจ้งเตือนและขยายขนาดได้ดีกว่า แนะนำสำหรับสภาพแวดล้อมการใช้งานจริงและคลาวด์ส่วนใหญ่

### ตารางเปรียบเทียบ

ดูตารางเปรียบเทียบด้านล่างเพื่อเข้าใจความแตกต่างของกลไกการขนส่งเหล่านี้:

| การขนส่ง         | อัปเดตเรียลไทม์ | สตรีมมิ่ง | การขยายขนาด | กรณีใช้งาน              |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | ไม่               | ไม่        | ต่ำ          | เครื่องมือ CLI ในเครื่อง |
| SSE               | ใช่              | ใช่       | ปานกลาง     | เว็บ, อัปเดตเรียลไทม์  |
| Streamable HTTP   | ใช่              | ใช่       | สูง          | คลาวด์, หลายไคลเอนต์    |

> **เคล็ดลับ:** การเลือกกลไกการขนส่งที่เหมาะสมส่งผลต่อประสิทธิภาพ การขยายขนาด และประสบการณ์ผู้ใช้ **Streamable HTTP** เป็นตัวเลือกที่แนะนำสำหรับแอปพลิเคชันที่ทันสมัย ขยายได้ และพร้อมสำหรับคลาวด์

โปรดสังเกตกลไก stdio และ SSE ที่ได้เห็นในบทก่อนหน้า และว่ากลไก Streamable HTTP คือกลไกที่ครอบคลุมในบทนี้

## การสตรีม: แนวคิดและแรงจูงใจ

การเข้าใจแนวคิดพื้นฐานและแรงจูงใจเบื้องหลังการสตรีมเป็นสิ่งสำคัญสำหรับการพัฒนาระบบสื่อสารเรียลไทม์ที่มีประสิทธิภาพ

**การสตรีม** คือเทคนิคในโปรแกรมเครือข่ายที่ช่วยให้ข้อมูลถูกส่งและรับทีละส่วนเล็ก ๆ หรือเป็นลำดับของเหตุการณ์ แทนที่จะรอให้ข้อมูลทั้งหมดพร้อมก่อน ซึ่งมีประโยชน์มากสำหรับ:

- ไฟล์หรือชุดข้อมูลขนาดใหญ่
- อัปเดตแบบเรียลไทม์ (เช่น แชท, แถบความคืบหน้า)
- งานประมวลผลที่ใช้เวลานานที่ต้องการแจ้งผู้ใช้ตลอดเวลา

นี่คือสิ่งที่ควรรู้เกี่ยวกับการสตรีมในภาพรวม:

- ข้อมูลถูกส่งอย่างต่อเนื่อง ไม่ใช่ทั้งหมดในครั้งเดียว
- ไคลเอนต์สามารถประมวลผลข้อมูลเมื่อได้รับ
- ลดความรู้สึกหน่วงและเพิ่มประสบการณ์ผู้ใช้

### ทำไมต้องใช้การสตรีม?

เหตุผลในการใช้การสตรีมมีดังนี้:

- ผู้ใช้ได้รับข้อมูลตอบกลับทันที ไม่ต้องรอจนจบ
- เปิดโอกาสสำหรับแอปเรียลไทม์และ UI ที่ตอบสนองเร็ว
- ใช้ทรัพยากรเครือข่ายและคอมพิวต์อย่างมีประสิทธิภาพมากขึ้น

### ตัวอย่างง่าย: เซิร์ฟเวอร์และไคลเอนต์ HTTP Streaming

นี่คือตัวอย่างง่าย ๆ ของการใช้งานสตรีม:

<details>
<summary>Python</summary>

**เซิร์ฟเวอร์ (Python, ใช้ FastAPI และ StreamingResponse):**
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

**ไคลเอนต์ (Python, ใช้ requests):**
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

ตัวอย่างนี้แสดงให้เห็นว่าเซิร์ฟเวอร์ส่งข้อความทีละข้อความไปยังไคลเอนต์เมื่อพร้อม แทนที่จะรอข้อความทั้งหมดให้พร้อมก่อน

**วิธีการทำงาน:**
- เซิร์ฟเวอร์ส่งข้อความแต่ละข้อความทันทีที่พร้อม
- ไคลเอนต์รับและแสดงผลข้อความทีละส่วนเมื่อได้รับ

**ข้อกำหนด:**
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

- **สำหรับความต้องการสตรีมง่าย ๆ:** การสตรีม HTTP แบบคลาสสิกง่ายต่อการใช้งานและเพียงพอสำหรับความต้องการพื้นฐาน

- **สำหรับแอปที่ซับซ้อนและโต้ตอบ:** การสตรีม MCP ให้โครงสร้างที่ชัดเจนขึ้น พร้อมข้อมูลเมตาที่หลากหลายและแยกระหว่างการแจ้งเตือนกับผลลัพธ์สุดท้าย

- **สำหรับแอป AI:** ระบบแจ้งเตือนของ MCP เหมาะอย่างยิ่งสำหรับงาน AI ที่ใช้เวลานาน ซึ่งต้องการแจ้งความคืบหน้าแก่ผู้ใช้

## การสตรีมใน MCP

ตอนนี้คุณเห็นคำแนะนำและการเปรียบเทียบระหว่างสตรีมแบบคลาสสิกกับสตรีมใน MCP แล้ว เรามาดูรายละเอียดว่าคุณจะใช้สตรีมใน MCP ได้อย่างไร

การเข้าใจการทำงานของการสตรีมในกรอบ MCP เป็นสิ่งจำเป็นสำหรับการสร้างแอปที่ตอบสนองและให้ข้อมูลเรียลไทม์แก่ผู้ใช้ในระหว่างการทำงานที่ใช้เวลานาน

ใน MCP การสตรีมไม่ใช่การส่งผลลัพธ์หลักเป็นส่วน ๆ แต่เป็นการส่ง **การแจ้งเตือน** ไปยังไคลเอนต์ในขณะที่เครื่องมือกำลังประมวลผลคำขอ การแจ้งเตือนเหล่านี้อาจประกอบด้วยการอัปเดตความคืบหน้า, บันทึก หรือเหตุการณ์อื่น ๆ

### วิธีการทำงาน

ผลลัพธ์หลักยังคงถูกส่งเป็นคำตอบเดียว แต่การแจ้งเตือนสามารถส่งเป็นข้อความแยกต่างหากในระหว่างการประมวลผลเพื่ออัปเดตไคลเอนต์แบบเรียลไทม์ ไคลเอนต์ต้องสามารถจัดการและแสดงการแจ้งเตือนเหล่านี้ได้

## การแจ้งเตือนคืออะไร?

เราใช้คำว่า "การแจ้งเตือน" ในบริบทของ MCP หมายความว่าอย่างไร?

การแจ้งเตือนคือข้อความที่เซิร์ฟเวอร์ส่งไปยังไคลเอนต์เพื่อแจ้งความคืบหน้า สถานะ หรือเหตุการณ์ต่าง ๆ ในระหว่างการทำงานที่ใช้เวลานาน การแจ้งเตือนช่วยเพิ่มความโปร่งใสและประสบการณ์ผู้ใช้

ตัวอย่างเช่น ไคลเอนต์ควรส่งการแจ้งเตือนเมื่อการเชื่อมต่อเบื้องต้นกับเซิร์ฟเวอร์เสร็จสิ้น

การแจ้งเตือนจะมีลักษณะเป็นข้อความ JSON ดังนี้:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

การแจ้งเตือนจะอยู่ภายใต้หัวข้อใน MCP ที่เรียกว่า ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging)

เพื่อให้ระบบ logging ทำงาน เซิร์ฟเวอร์ต้องเปิดใช้งานฟีเจอร์นี้ดังนี้:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ขึ้นอยู่กับ SDK ที่ใช้ การเปิดใช้งาน logging อาจเป็นค่าเริ่มต้น หรือคุณอาจต้องเปิดใช้งานอย่างชัดเจนในการตั้งค่าเซิร์ฟเวอร์

มีการแจ้งเตือนหลายระดับดังนี้:

| ระดับ       | คำอธิบาย                   | ตัวอย่างการใช้งาน               |
|-------------|----------------------------|--------------------------------|
| debug       | ข้อมูลสำหรับดีบักละเอียด  | จุดเข้า/ออกฟังก์ชัน            |
| info        | ข้อความข้อมูลทั่วไป       | อัปเดตความคืบหน้าการทำงาน     |
| notice      | เหตุการณ์ปกติแต่สำคัญ    | การเปลี่ยนแปลงการตั้งค่า       |
| warning     | เงื่อนไขเตือน             | การใช้ฟีเจอร์ที่เลิกใช้แล้ว     |
| error       | เงื่อนไขผิดพลาด           | ความล้มเหลวในการทำงาน          |
| critical    | เงื่อนไขวิกฤต             | ความล้มเหลวของส่วนประกอบระบบ  |
| alert       | ต้องดำเนินการทันที        | ตรวจพบข้อมูลเสียหาย            |
| emergency   | ระบบไม่สามารถใช้งานได้    | ระบบล่มทั้งหมด                 |

## การใช้งานการแจ้งเตือนใน MCP

การใช้งานการแจ้งเตือนใน MCP ต้องตั้งค่าทั้งฝั่งเซิร์ฟเวอร์และไคลเอนต์ให้รองรับการอัปเดตแบบเรียลไทม์ เพื่อให้แอปของคุณสามารถแจ้งข้อมูลตอบกลับแก่ผู้ใช้ในระหว่างการทำงานที่ใช้เวลานาน

### ฝั่งเซิร์ฟเวอร์: การส่งการแจ้งเตือน

เริ่มจากฝั่งเซิร์ฟเวอร์ ใน MCP คุณกำหนดเครื่องมือที่สามารถส่งการแจ้งเตือนได้ในระหว่างการประมวลผลคำขอ เซิร์ฟเวอร์ใช้อ็อบเจกต์ context (โดยทั่วไปคือ `ctx`) เพื่อส่งข้อความไปยังไคลเอนต์

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

ในตัวอย่างก่อนหน้า การใช้ `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### ฝั่งไคลเอนต์: การรับการแจ้งเตือน

ไคลเอนต์ต้องมีการจัดการข้อความเพื่อประมวลผลและแสดงการแจ้งเตือนเมื่อได้รับ

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` ไคลเอนต์ได้กำหนดตัวจัดการข้อความเพื่อประมวลผลการแจ้งเตือน

## การแจ้งเตือนความคืบหน้าและสถานการณ์ใช้งาน

ส่วนนี้อธิบายแนวคิดของการแจ้งเตือนความคืบหน้าใน MCP ทำไมจึงสำคัญ และวิธีใช้งานผ่าน Streamable HTTP พร้อมแบบฝึกหัดเพื่อเพิ่มความเข้าใจ

การแจ้งเตือนความคืบหน้าเป็นข้อความเรียลไทม์ที่ส่งจากเซิร์ฟเวอร์ไปยังไคลเอนต์ในระหว่างการทำงานที่ใช้เวลานาน แทนที่จะรอจนกระบวนการทั้งหมดเสร็จ เซิร์ฟเวอร์จะแจ้งสถานะปัจจุบันให้ไคลเอนต์ทราบ ช่วยเพิ่มความโปร่งใส ประสบการณ์ผู้ใช้ และทำให้ง่ายต่อการดีบัก

**ตัวอย่าง:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### ทำไมต้องใช้การแจ้งเตือนความคืบหน้า?

การแจ้งเตือนความคืบหน้ามีความสำคัญด้วยเหตุผลดังนี้:

- **ประสบการณ์ผู้ใช้ที่ดีขึ้น:** ผู้ใช้เห็นอัปเดตขณะงานกำลังดำเนิน ไม่ใช่แค่ตอนจบ
- **ฟีดแบ็คเรียลไทม์:** ไคลเอนต์สามารถแสดงแถบความคืบหน้าหรือบันทึก ทำให้แอปดูตอบสนองเร็ว
- **ง่ายต่อการดีบักและติดตาม:** นักพัฒนาและผู้ใช้เห็นได้ว่ากระบวนการใดช้า หรือติดขัดตรงไหน

### วิธีการใช้งานการแจ้งเตือนความคืบหน้า

นี่คือวิธีใช้งานการแจ้งเตือนความคืบหน้าใน MCP:

- **ฝั่งเซิร์ฟเวอร์:** ใช้ `ctx.info()` or `ctx.log()` เพื่อส่งการแจ้งเตือนทีละรายการในขณะที่ประมวลผล ส่งข้อความไปยังไคลเอนต์ก่อนผลลัพธ์หลักจะพร้อม
- **ฝั่งไคลเอนต์:** สร้างตัวจัดการข้อความที่ฟังและแสดงการแจ้งเตือนเมื่อได้รับ ตัวจัดการนี้จะแยกความแตกต่างระหว่างการแจ้งเตือนกับผลลัพธ์สุดท้าย

**ตัวอย่างฝั่งเซิร์ฟเวอร์:**

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

**ตัวอย่างฝั่งไคลเอนต์:**

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

## ข้อควรพิจารณาด้านความปลอดภัย

เมื่อพัฒนาเซิร์ฟเวอร์ MCP ที่ใช้การขนส่งผ่าน HTTP ความปลอดภัยเป็นเรื่องสำคัญที่ต้องใส่ใจหลายแง่มุมของการโจมตีและมาตรการป้องกัน

### ภาพรวม

ความปลอดภัยเป็นสิ่งจำเป็นเมื่อเปิดเซิร์ฟเวอร์ MCP ผ่าน HTTP Streamable HTTP เพิ่มจุดอ่อนใหม่ ๆ ที่ต้องตั้งค่าด้วยความระมัดระวัง

### ประเด็นสำคัญ
- **การตรวจสอบค่า Origin Header**: ควรตรวจสอบค่า `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` แทนที่จะเป็นไคลเอนต์ SSE
3. **สร้างตัวจัดการข้อความ** ในไคลเอนต์เพื่อประมวลผลการแจ้งเตือน
4. **ทดสอบความเข้ากันได้** กับเครื่องมือและเวิร์กโฟลว์ที่มีอยู่

### การรักษาความเข้ากันได้

แนะนำให้รักษาความเข้ากันได้กับไคลเอนต์ SSE เดิมในช่วงการย้ายระบบ โดยมีวิธีการดังนี้:

- คุณสามารถรองรับทั้ง SSE และ Streamable HTTP โดยรันทั้งสองแบบใน endpoint ที่ต่างกัน
- ย้ายไคลเอนต์ไปยังการขนส่งแบบใหม่อย่างค่อยเป็นค่อยไป

### ความท้าทาย

ต้องแก้ไขปัญหาต่อไปนี้ในช่วงการย้ายระบบ:

- ตรวจสอบให้แน่ใจว่าไคลเอนต์ทั้งหมดได้รับการอัปเดต
- จัดการความแตกต่างในการส่งการแจ้งเตือน

### แบบฝึกหัด: สร้างแอป MCP สตรีมมิ่งของคุณเอง

**สถานการณ์:**
สร้างเซิร์ฟเวอร์และไคลเอนต์ MCP ที่เซิร์ฟเวอร์ประมวลผลรายการของไอเท็ม (เช่น ไฟล์หรือเอกสาร) และส่งการแจ้งเตือนสำหรับแต่ละไอเท็มที่ประมวลผล ไคลเอนต์จะแสดงการแจ้งเตือนแต่ละรายการเมื่อได้รับ

**ขั้นตอน:**

1. สร้างเครื่องมือเซิร์ฟเวอร์ที่ประมวลผลรายการและส่งการแจ้งเตือนสำหรับแต่ละไอเท็ม
2. สร้างไคลเอนต์ที่มีตัวจัดการข้อความเพื่อแสดงการแจ้งเตือนแบบเรียลไทม์
3. ทดสอบการใช้งานโดยรันทั้งเซิร์ฟเวอร์และไคลเอนต์ และสังเกตการแจ้งเตือน

[Solution](./solution/README.md)

## อ่านเพิ่มเติม & ต่อไปทำอะไร?

เพื่อเดินหน้าต่อกับการสตรีม MCP และขยายความรู้ ส่วนนี้มีแหล่งข้อมูลเพิ่มเติมและคำแนะนำสำหรับก้าวต่อไปในการสร้างแอปที่ซับซ้อนขึ้น

### อ่านเพิ่มเติม

- [Microsoft: แนะนำ HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS ใน ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่มีความสำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใดๆ ที่เกิดจากการใช้การแปลนี้