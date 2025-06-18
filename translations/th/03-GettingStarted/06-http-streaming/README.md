<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:09:27+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "th"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

บทนี้เป็นคู่มือครบถ้วนสำหรับการใช้งานการสตรีมแบบปลอดภัย ขยายขนาดได้ และเรียลไทม์ด้วย Model Context Protocol (MCP) ผ่าน HTTPS ครอบคลุมแรงจูงใจในการสตรีม กลไกการส่งข้อมูลที่มีให้ใช้งาน วิธีการใช้งาน HTTP แบบสตรีมใน MCP แนวทางปฏิบัติด้านความปลอดภัย การย้ายจาก SSE และคำแนะนำเชิงปฏิบัติสำหรับการสร้างแอปพลิเคชัน MCP ที่รองรับการสตรีมด้วยตนเอง

## กลไกการส่งข้อมูลและการสตรีมใน MCP

ส่วนนี้จะสำรวจกลไกการส่งข้อมูลต่างๆ ที่มีใน MCP และบทบาทของพวกมันในการเปิดใช้งานความสามารถในการสตรีมสำหรับการสื่อสารแบบเรียลไทม์ระหว่างไคลเอนต์และเซิร์ฟเวอร์

### กลไกการส่งข้อมูลคืออะไร?

กลไกการส่งข้อมูลคือวิธีที่ข้อมูลถูกแลกเปลี่ยนระหว่างไคลเอนต์และเซิร์ฟเวอร์ MCP รองรับประเภทการส่งข้อมูลหลายแบบเพื่อให้เหมาะกับสภาพแวดล้อมและความต้องการที่แตกต่างกัน:

- **stdio**: การส่งข้อมูลผ่านอินพุต/เอาต์พุตมาตรฐาน เหมาะสำหรับเครื่องมือที่ใช้งานบนเครื่องท้องถิ่นและ CLI ใช้งานง่ายแต่ไม่เหมาะกับเว็บหรือคลาวด์
- **SSE (Server-Sent Events)**: ให้เซิร์ฟเวอร์ส่งอัปเดตแบบเรียลไทม์ไปยังไคลเอนต์ผ่าน HTTP เหมาะกับเว็บ UI แต่มีข้อจำกัดด้านการขยายและความยืดหยุ่น
- **Streamable HTTP**: การส่งข้อมูลแบบสตรีมผ่าน HTTP สมัยใหม่ รองรับการแจ้งเตือนและขยายขนาดได้ดีกว่า แนะนำสำหรับการใช้งานจริงและบนคลาวด์ส่วนใหญ่

### ตารางเปรียบเทียบ

ดูตารางเปรียบเทียบด้านล่างเพื่อเข้าใจความแตกต่างระหว่างกลไกการส่งข้อมูลเหล่านี้:

| การส่งข้อมูล    | อัปเดตแบบเรียลไทม์ | การสตรีม | ขยายขนาดได้ | กรณีการใช้งาน             |
|-----------------|---------------------|----------|--------------|---------------------------|
| stdio           | ไม่                  | ไม่       | ต่ำ          | เครื่องมือ CLI ท้องถิ่น    |
| SSE             | ใช่                 | ใช่      | ปานกลาง     | เว็บ, อัปเดตแบบเรียลไทม์  |
| Streamable HTTP | ใช่                 | ใช่      | สูง          | คลาวด์, หลายไคลเอนต์      |

> **Tip:** การเลือกกลไกการส่งข้อมูลที่เหมาะสมส่งผลต่อประสิทธิภาพ ขยายขนาด และประสบการณ์ผู้ใช้ **Streamable HTTP** เป็นตัวเลือกที่แนะนำสำหรับแอปสมัยใหม่ที่ต้องการขยายขนาดและพร้อมใช้งานบนคลาวด์

สังเกตว่ากลไก stdio และ SSE ที่ได้เห็นในบทก่อนหน้า และ Streamable HTTP คือกลไกที่กล่าวถึงในบทนี้

## การสตรีม: แนวคิดและแรงจูงใจ

การเข้าใจแนวคิดพื้นฐานและแรงจูงใจเบื้องหลังการสตรีมเป็นสิ่งสำคัญสำหรับการสร้างระบบสื่อสารแบบเรียลไทม์ที่มีประสิทธิภาพ

**การสตรีม** คือเทคนิคในการเขียนโปรแกรมเครือข่ายที่อนุญาตให้ส่งและรับข้อมูลเป็นชิ้นเล็กๆ หรือเป็นลำดับของเหตุการณ์ แทนที่จะรอให้ข้อมูลทั้งหมดพร้อมก่อน เหมาะอย่างยิ่งสำหรับ:

- ไฟล์หรือชุดข้อมูลขนาดใหญ่
- อัปเดตแบบเรียลไทม์ (เช่น แชท แถบความคืบหน้า)
- การคำนวณที่ใช้เวลานานที่ต้องการแจ้งสถานะให้ผู้ใช้ทราบ

นี่คือสิ่งที่ควรรู้เกี่ยวกับการสตรีมในภาพรวม:

- ข้อมูลถูกส่งอย่างต่อเนื่อง ไม่ใช่ทั้งหมดในครั้งเดียว
- ไคลเอนต์สามารถประมวลผลข้อมูลเมื่อได้รับ
- ลดความรู้สึกหน่วงเวลาและเพิ่มประสบการณ์ผู้ใช้

### ทำไมต้องใช้การสตรีม?

เหตุผลในการใช้การสตรีมมีดังนี้:

- ผู้ใช้ได้รับข้อมูลตอบกลับทันที ไม่ใช่แค่ตอนจบเท่านั้น
- รองรับแอปเรียลไทม์และ UI ที่ตอบสนองได้ดี
- ใช้ทรัพยากรเครือข่ายและคำนวณได้อย่างมีประสิทธิภาพมากขึ้น

### ตัวอย่างง่ายๆ: HTTP Streaming Server & Client

นี่คือตัวอย่างง่ายๆ ของการใช้งานการสตรีม:

<details>
<summary>Python</summary>

**เซิร์ฟเวอร์ (Python ใช้ FastAPI และ StreamingResponse):**
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

**ไคลเอนต์ (Python ใช้ requests):**
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

ตัวอย่างนี้แสดงให้เห็นว่าเซิร์ฟเวอร์ส่งข้อความเป็นชุดๆ ไปยังไคลเอนต์เมื่อพร้อม แทนที่จะรอให้ข้อความทั้งหมดพร้อมก่อน

**วิธีทำงาน:**
- เซิร์ฟเวอร์ส่งข้อความแต่ละข้อความเมื่อพร้อม
- ไคลเอนต์รับและแสดงข้อความแต่ละชิ้นเมื่อมาถึง

**ข้อกำหนด:**
- เซิร์ฟเวอร์ต้องใช้การตอบสนองแบบสตรีม (เช่น `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`)

</details>

<details>
<summary>Java</summary>

**เซิร์ฟเวอร์ (Java ใช้ Spring Boot และ Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**ไคลเอนต์ (Java ใช้ Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**หมายเหตุการใช้งาน Java:**
- ใช้สแตก reactive ของ Spring Boot กับ `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) เทียบกับการเลือกสตรีมผ่าน MCP

- **สำหรับความต้องการสตรีมง่ายๆ:** การสตรีม HTTP แบบคลาสสิกง่ายต่อการใช้งานและเพียงพอสำหรับความต้องการพื้นฐาน

- **สำหรับแอปที่ซับซ้อนและโต้ตอบได้:** การสตรีม MCP ให้โครงสร้างที่ชัดเจนพร้อมข้อมูลเมตาที่ครบถ้วนและแยกระหว่างการแจ้งเตือนกับผลลัพธ์สุดท้าย

- **สำหรับแอป AI:** ระบบแจ้งเตือนของ MCP เหมาะสำหรับงาน AI ที่ใช้เวลานานที่ต้องการแจ้งความคืบหน้าให้ผู้ใช้ทราบ

## การสตรีมใน MCP

ตอนนี้คุณได้เห็นคำแนะนำและการเปรียบเทียบระหว่างการสตรีมแบบคลาสสิกกับการสตรีมใน MCP แล้ว มาดูรายละเอียดว่าเราจะใช้การสตรีมใน MCP ได้อย่างไร

การเข้าใจการทำงานของการสตรีมในกรอบงาน MCP เป็นสิ่งสำคัญสำหรับการสร้างแอปที่ตอบสนองและให้ข้อมูลเรียลไทม์แก่ผู้ใช้ในระหว่างกระบวนการที่ใช้เวลานาน

ใน MCP การสตรีมไม่ได้หมายถึงการส่งผลลัพธ์หลักเป็นชิ้นๆ แต่หมายถึงการส่ง **การแจ้งเตือน** ไปยังไคลเอนต์ในขณะที่เครื่องมือกำลังประมวลผลคำขอ การแจ้งเตือนเหล่านี้อาจรวมถึงการอัปเดตความคืบหน้า, บันทึก หรือเหตุการณ์อื่นๆ

### วิธีทำงาน

ผลลัพธ์หลักยังคงถูกส่งเป็นการตอบสนองครั้งเดียว แต่การแจ้งเตือนสามารถส่งเป็นข้อความแยกต่างหากระหว่างการประมวลผลเพื่ออัปเดตไคลเอนต์แบบเรียลไทม์ ไคลเอนต์ต้องสามารถจัดการและแสดงการแจ้งเตือนเหล่านี้ได้

## การแจ้งเตือนคืออะไร?

เราใช้คำว่า "การแจ้งเตือน" หมายถึงอะไรในบริบทของ MCP?

การแจ้งเตือนคือข้อความที่ส่งจากเซิร์ฟเวอร์ไปยังไคลเอนต์เพื่อแจ้งความคืบหน้า สถานะ หรือเหตุการณ์อื่นๆ ระหว่างกระบวนการที่ใช้เวลานาน การแจ้งเตือนช่วยเพิ่มความโปร่งใสและประสบการณ์ผู้ใช้

ตัวอย่างเช่น ไคลเอนต์ควรส่งการแจ้งเตือนเมื่อการเชื่อมต่อเริ่มต้นกับเซิร์ฟเวอร์สำเร็จ

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

การแจ้งเตือนอยู่ภายใต้หัวข้อใน MCP ที่เรียกว่า ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging)

เพื่อให้การบันทึกทำงาน เซิร์ฟเวอร์ต้องเปิดใช้งานฟีเจอร์นี้เหมือนดังนี้:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ขึ้นอยู่กับ SDK ที่ใช้ การบันทึกอาจเปิดใช้งานโดยอัตโนมัติ หรือคุณอาจต้องเปิดใช้งานเองในการตั้งค่าเซิร์ฟเวอร์

มีประเภทของการแจ้งเตือนต่างๆ ดังนี้:

| ระดับ      | คำอธิบาย                     | ตัวอย่างการใช้งาน            |
|------------|------------------------------|------------------------------|
| debug      | ข้อมูลดีเทลสำหรับดีบัก       | จุดเข้า/ออกของฟังก์ชัน      |
| info       | ข้อความข้อมูลทั่วไป           | อัปเดตความคืบหน้าของงาน     |
| notice     | เหตุการณ์ปกติแต่สำคัญ        | การเปลี่ยนแปลงการตั้งค่า    |
| warning    | สถานะเตือน                   | การใช้ฟีเจอร์ที่เลิกใช้แล้ว   |
| error      | สถานะข้อผิดพลาด              | ความล้มเหลวของงาน           |
| critical   | สถานะวิกฤต                   | ความล้มเหลวของส่วนประกอบระบบ |
| alert      | ต้องดำเนินการทันที           | ตรวจพบข้อมูลเสียหาย         |
| emergency  | ระบบไม่สามารถใช้งานได้        | ระบบล้มเหลวทั้งหมด           |

## การใช้งานการแจ้งเตือนใน MCP

การใช้งานการแจ้งเตือนใน MCP ต้องตั้งค่าทั้งฝั่งเซิร์ฟเวอร์และไคลเอนต์ให้รองรับการอัปเดตแบบเรียลไทม์ ซึ่งช่วยให้แอปพลิเคชันสามารถตอบสนองผู้ใช้ทันทีในระหว่างการทำงานที่ใช้เวลานาน

### ฝั่งเซิร์ฟเวอร์: การส่งการแจ้งเตือน

เริ่มจากฝั่งเซิร์ฟเวอร์ ใน MCP คุณกำหนดเครื่องมือที่สามารถส่งการแจ้งเตือนระหว่างประมวลผลคำขอ เซิร์ฟเวอร์ใช้วัตถุ context (ปกติคือ `ctx`) เพื่อส่งข้อความไปยังไคลเอนต์

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

ในตัวอย่างข้างต้น เมธอด `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ถูกใช้กับการส่งข้อมูลแบบสตรีม:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

ในตัวอย่าง .NET นี้ เมธอด `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` ถูกใช้เพื่อส่งข้อความข้อมูล

เพื่อเปิดใช้งานการแจ้งเตือนในเซิร์ฟเวอร์ MCP .NET ของคุณ ให้แน่ใจว่าใช้การส่งข้อมูลแบบสตรีม:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
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

ในโค้ดนี้ ฟังก์ชัน `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` ถูกใช้เพื่อจัดการการแจ้งเตือนที่เข้ามา

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

ในตัวอย่าง .NET นี้ คลาส `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` และไคลเอนต์มีการจัดการข้อความเพื่อประมวลผลการแจ้งเตือน

## การแจ้งเตือนความคืบหน้า & กรณีใช้งาน

ส่วนนี้อธิบายแนวคิดของการแจ้งเตือนความคืบหน้าใน MCP ว่าทำไมจึงสำคัญ และวิธีใช้งานกับ Streamable HTTP รวมถึงแบบฝึกหัดเพื่อเสริมความเข้าใจ

การแจ้งเตือนความคืบหน้าเป็นข้อความเรียลไทม์ที่ส่งจากเซิร์ฟเวอร์ไปยังไคลเอนต์ในระหว่างการทำงานที่ใช้เวลานาน แทนที่จะรอจนกระบวนการเสร็จสิ้น เซิร์ฟเวอร์จะแจ้งสถานะปัจจุบันให้ไคลเอนต์ทราบ ช่วยเพิ่มความโปร่งใส ประสบการณ์ผู้ใช้ และทำให้ง่ายต่อการดีบัก

**ตัวอย่าง:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### ทำไมต้องใช้การแจ้งเตือนความคืบหน้า?

การแจ้งเตือนความคืบหน้ามีความสำคัญด้วยเหตุผลหลายประการ:

- **ประสบการณ์ผู้ใช้ที่ดีขึ้น:** ผู้ใช้เห็นการอัปเดตระหว่างทำงาน ไม่ใช่แค่ตอนจบ
- **ข้อมูลตอบกลับแบบเรียลไทม์:** ไคลเอนต์สามารถแสดงแถบความคืบหน้าหรือบันทึก ทำให้แอปดูตอบสนองได้ดี
- **ง่ายต่อการดีบักและตรวจสอบ:** นักพัฒนาและผู้ใช้เห็นว่ากระบวนการอยู่ในขั้นตอนไหน อาจเกิดความล่าช้าหรือค้างที่จุดใด

### วิธีใช้งานการแจ้งเตือนความคืบหน้า

นี่คือวิธีใช้งานการแจ้งเตือนความคืบหน้าใน MCP:

- **ฝั่งเซิร์ฟเวอร์:** ใช้ `ctx.info()` or `ctx.log()` เพื่อส่งการแจ้งเตือนเมื่อประมวลผลแต่ละรายการ ส่งข้อความไปยังไคลเอนต์ก่อนผลลัพธ์หลักจะพร้อม
- **ฝั่งไคลเอนต์:** สร้าง message handler ที่ฟังและแสดงการแจ้งเตือนเมื่อได้รับ ตัวจัดการนี้จะแยกแยะระหว่างการแจ้งเตือนและผลลัพธ์สุดท้าย

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

## ข้อควรระวังด้านความปลอดภัย

เมื่อใช้งานเซิร์ฟเวอร์ MCP กับการส่งข้อมูลผ่าน HTTP ความปลอดภัยเป็นเรื่องสำคัญที่ต้องให้ความสนใจอย่างรอบคอบกับช่องโหว่และกลไกป้องกันต่างๆ

### ภาพรวม

ความปลอดภัยเป็นสิ่งจำเป็นเมื่อเปิดเผยเซิร์ฟเวอร์ MCP ผ่าน HTTP การใช้ Streamable HTTP เพิ่มพื้นผิวโจมตีใหม่ๆ และต้องมีการตั้งค่าที่เหมาะสม

### ประเด็นสำคัญ
- **การตรวจสอบ Origin Header**: ควรตรวจสอบค่า `Origin` เสมอเพื่อป้องกันการโจมตีแบบ Cross-Origin
- **ใช้ HTTPS เท่านั้น**: หลีกเลี่ยงการส่งข้อมูลแบบไม่เข้ารหัส
- **กำหนดสิทธิ์และการพิสูจน์ตัวตน**: ควบคุมการเข้าถึงอย่างเข้มงวด
- **จำกัดขนาดและจำนวนการเชื่อมต่อ**: ป้องกันการโจมตีแบบ DoS
- **ตรวจสอบและบันทึกเหตุการณ์อย่างเหมาะสม**: เพื่อการวิเคราะห์และตอบสนองต่อเหตุการณ์ด้านความปลอดภัย

### การรักษาความเข้ากันได้

แนะนำให้รักษาความเข้ากันได้กับไคลเอนต์ SSE เดิมในระหว่างการย้ายระบบ โดยมีกลยุทธ์ดังนี้:

- รองรับทั้ง SSE และ Streamable HTTP โดยแยกใช้ปลายทาง (endpoints) ต่างกัน
- ค่อยๆ ย้ายไคลเอนต์ไปยังการส่งข้อมูลแบบใหม่

### ความท้าทาย

ต้องจัดการกับความท้าทายต่อไปนี้ในระหว่างการย้ายระบบ:

- ทำให้แน่ใจว่าไคลเอนต์ทั้งหมดได้รับการอัปเดต
- จัดการความแตกต่างในการส่งการแจ้งเตือน

### แบบฝึกหัด: สร้างแอป MCP สตรีมมิ่งของคุณเอง

**สถานการณ์:**
สร้างเซิร์ฟเวอร์และไคลเอนต์ MCP ที่เซิร์ฟเวอร์ประมวลผลรายการของรายการ (เช่น ไฟล์หรือเอกสาร) และส่งการแจ้งเตือนสำหรับแต่ละรายการที่ประมวลผล ไคลเอนต์จะแสดงการแจ้งเตือนแต่ละรายการเมื่อได้รับ

**ขั้นตอน:**

1. สร้างเครื่องมือเซิร์ฟเวอร์ที่ประมวลผลรายการและส่งการแจ้งเตือนสำหรับแต่ละ

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่มีความสำคัญ แนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้