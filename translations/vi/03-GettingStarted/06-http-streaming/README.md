<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:19:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "vi"
}
-->
# HTTPS Streaming với Model Context Protocol (MCP)

Chương này cung cấp hướng dẫn toàn diện về cách triển khai streaming an toàn, mở rộng và thời gian thực với Model Context Protocol (MCP) sử dụng HTTPS. Nội dung bao gồm động lực cho streaming, các cơ chế truyền tải có sẵn, cách triển khai HTTP có thể stream trong MCP, các thực hành bảo mật tốt nhất, chuyển đổi từ SSE và hướng dẫn thực tiễn để xây dựng ứng dụng MCP streaming của riêng bạn.

## Cơ chế truyền tải và Streaming trong MCP

Phần này khám phá các cơ chế truyền tải khác nhau trong MCP và vai trò của chúng trong việc cho phép khả năng streaming để giao tiếp thời gian thực giữa client và server.

### Cơ chế truyền tải là gì?

Cơ chế truyền tải xác định cách dữ liệu được trao đổi giữa client và server. MCP hỗ trợ nhiều loại truyền tải để phù hợp với các môi trường và yêu cầu khác nhau:

- **stdio**: Đầu vào/đầu ra chuẩn, phù hợp cho công cụ chạy trên máy cục bộ và CLI. Đơn giản nhưng không phù hợp cho web hoặc đám mây.
- **SSE (Server-Sent Events)**: Cho phép server đẩy các cập nhật thời gian thực đến client qua HTTP. Tốt cho giao diện web, nhưng hạn chế về khả năng mở rộng và linh hoạt.
- **Streamable HTTP**: Cơ chế truyền tải streaming dựa trên HTTP hiện đại, hỗ trợ thông báo và khả năng mở rộng tốt hơn. Được khuyến nghị cho hầu hết các kịch bản sản xuất và đám mây.

### Bảng so sánh

Xem bảng so sánh dưới đây để hiểu sự khác biệt giữa các cơ chế truyền tải này:

| Truyền tải       | Cập nhật thời gian thực | Streaming | Khả năng mở rộng | Trường hợp sử dụng         |
|------------------|------------------------|-----------|------------------|---------------------------|
| stdio            | Không                  | Không     | Thấp             | Công cụ CLI cục bộ        |
| SSE              | Có                     | Có        | Trung bình       | Web, cập nhật thời gian thực |
| Streamable HTTP  | Có                     | Có        | Cao              | Đám mây, đa client        |

> **Tip:** Lựa chọn cơ chế truyền tải phù hợp ảnh hưởng đến hiệu năng, khả năng mở rộng và trải nghiệm người dùng. **Streamable HTTP** được khuyến nghị cho các ứng dụng hiện đại, có khả năng mở rộng và sẵn sàng cho đám mây.

Lưu ý các cơ chế truyền tải stdio và SSE đã được đề cập trong các chương trước và streamable HTTP là cơ chế truyền tải được trình bày trong chương này.

## Streaming: Khái niệm và Động lực

Hiểu được các khái niệm cơ bản và động lực đằng sau streaming là điều cần thiết để triển khai hệ thống giao tiếp thời gian thực hiệu quả.

**Streaming** là kỹ thuật trong lập trình mạng cho phép dữ liệu được gửi và nhận theo từng phần nhỏ, dễ quản lý hoặc theo chuỗi sự kiện, thay vì phải chờ toàn bộ phản hồi sẵn sàng. Điều này đặc biệt hữu ích cho:

- Các tập tin hoặc bộ dữ liệu lớn.
- Cập nhật thời gian thực (ví dụ: chat, thanh tiến trình).
- Các phép tính lâu dài cần thông báo tiến độ cho người dùng.

Dưới đây là những điểm bạn cần biết về streaming ở mức tổng quan:

- Dữ liệu được gửi dần dần, không phải tất cả cùng lúc.
- Client có thể xử lý dữ liệu ngay khi nhận được.
- Giảm độ trễ cảm nhận và cải thiện trải nghiệm người dùng.

### Tại sao nên dùng streaming?

Các lý do sử dụng streaming bao gồm:

- Người dùng nhận phản hồi ngay lập tức, không chỉ khi kết thúc.
- Cho phép ứng dụng thời gian thực và giao diện người dùng phản hồi nhanh.
- Sử dụng tài nguyên mạng và tính toán hiệu quả hơn.

### Ví dụ đơn giản: Server & Client HTTP Streaming

Dưới đây là ví dụ đơn giản về cách triển khai streaming:

<details>
<summary>Python</summary>

**Server (Python, dùng FastAPI và StreamingResponse):**
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

**Client (Python, dùng requests):**
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

Ví dụ này minh họa server gửi một chuỗi tin nhắn đến client ngay khi chúng sẵn sàng, thay vì đợi tất cả tin nhắn hoàn tất.

**Cách hoạt động:**
- Server phát từng tin nhắn khi nó sẵn sàng.
- Client nhận và in từng phần dữ liệu khi đến.

**Yêu cầu:**
- Server phải sử dụng phản hồi streaming (ví dụ `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, dùng Spring Boot và Server-Sent Events):**

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

**Client (Java, dùng Spring WebFlux WebClient):**

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

**Ghi chú triển khai Java:**
- Sử dụng reactive stack của Spring Boot với `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) so với chọn streaming qua MCP.

- **Với nhu cầu streaming đơn giản:** Streaming HTTP cổ điển dễ triển khai và đủ dùng cho các nhu cầu cơ bản.

- **Với ứng dụng phức tạp, tương tác:** Streaming MCP cung cấp cách tiếp cận có cấu trúc hơn với metadata phong phú và phân tách giữa thông báo và kết quả cuối cùng.

- **Với ứng dụng AI:** Hệ thống thông báo của MCP đặc biệt hữu ích cho các tác vụ AI lâu dài, giúp người dùng được cập nhật tiến độ.

## Streaming trong MCP

Bạn đã thấy một số khuyến nghị và so sánh về sự khác biệt giữa streaming cổ điển và streaming trong MCP. Bây giờ hãy đi sâu vào chi tiết cách bạn có thể tận dụng streaming trong MCP.

Hiểu cách streaming hoạt động trong khung MCP là điều cần thiết để xây dựng ứng dụng phản hồi nhanh, cung cấp phản hồi thời gian thực cho người dùng trong các thao tác chạy lâu.

Trong MCP, streaming không phải là gửi phản hồi chính theo từng phần, mà là gửi **thông báo** đến client trong khi công cụ đang xử lý yêu cầu. Các thông báo này có thể bao gồm cập nhật tiến độ, nhật ký hoặc các sự kiện khác.

### Cách hoạt động

Kết quả chính vẫn được gửi dưới dạng một phản hồi duy nhất. Tuy nhiên, các thông báo có thể được gửi dưới dạng các tin nhắn riêng biệt trong quá trình xử lý và cập nhật client theo thời gian thực. Client phải có khả năng xử lý và hiển thị các thông báo này.

## Thông báo là gì?

Chúng ta đã nói về “Thông báo”, vậy nó có nghĩa gì trong ngữ cảnh MCP?

Thông báo là một tin nhắn được gửi từ server đến client để thông báo về tiến độ, trạng thái hoặc các sự kiện khác trong quá trình thực hiện thao tác lâu dài. Thông báo giúp tăng tính minh bạch và cải thiện trải nghiệm người dùng.

Ví dụ, client sẽ gửi một thông báo khi quá trình bắt tay ban đầu với server đã hoàn tất.

Một thông báo trông như sau dưới dạng tin nhắn JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Thông báo thuộc về một chủ đề trong MCP gọi là ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Để bật logging, server cần kích hoạt tính năng này như sau:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Tùy thuộc SDK được sử dụng, logging có thể được bật mặc định hoặc bạn cần bật rõ ràng trong cấu hình server.

Có các loại thông báo khác nhau:

| Mức độ    | Mô tả                         | Ví dụ sử dụng               |
|-----------|-------------------------------|----------------------------|
| debug     | Thông tin gỡ lỗi chi tiết      | Điểm vào/ra hàm            |
| info      | Thông tin tổng quát            | Cập nhật tiến độ thao tác   |
| notice    | Sự kiện bình thường nhưng quan trọng | Thay đổi cấu hình          |
| warning   | Điều kiện cảnh báo             | Sử dụng tính năng đã lỗi thời |
| error     | Lỗi xảy ra                    | Thao tác thất bại          |
| critical  | Lỗi nghiêm trọng              | Lỗi thành phần hệ thống    |
| alert     | Cần hành động ngay lập tức     | Phát hiện lỗi dữ liệu       |
| emergency | Hệ thống không thể sử dụng    | Hỏng hoàn toàn hệ thống    |

## Triển khai Thông báo trong MCP

Để triển khai thông báo trong MCP, bạn cần thiết lập cả phía server và client để xử lý cập nhật thời gian thực. Điều này cho phép ứng dụng của bạn cung cấp phản hồi ngay lập tức cho người dùng trong các thao tác chạy lâu.

### Phía server: Gửi Thông báo

Bắt đầu với phía server. Trong MCP, bạn định nghĩa các công cụ có thể gửi thông báo trong khi xử lý yêu cầu. Server sử dụng đối tượng context (thường là `ctx`) để gửi tin nhắn đến client.

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

Trong ví dụ trên, phương thức `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` được sử dụng:

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

Trong ví dụ .NET này, phương thức `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` được dùng để gửi các tin nhắn thông tin.

Để bật thông báo trong server MCP .NET, đảm bảo bạn đang sử dụng cơ chế truyền tải streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Phía client: Nhận Thông báo

Client phải triển khai trình xử lý tin nhắn để xử lý và hiển thị các thông báo khi chúng đến.

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

Trong đoạn mã trên, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` được dùng để xử lý các thông báo đến.

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

Trong ví dụ .NET này, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) và client của bạn triển khai trình xử lý tin nhắn để xử lý thông báo.

## Thông báo tiến độ & Các kịch bản

Phần này giải thích khái niệm thông báo tiến độ trong MCP, tại sao chúng quan trọng và cách triển khai chúng bằng Streamable HTTP. Bạn cũng sẽ tìm thấy bài tập thực hành để củng cố kiến thức.

Thông báo tiến độ là các tin nhắn thời gian thực được gửi từ server đến client trong quá trình thực hiện thao tác lâu dài. Thay vì chờ quá trình hoàn tất, server liên tục cập nhật trạng thái hiện tại cho client. Điều này tăng tính minh bạch, cải thiện trải nghiệm người dùng và giúp việc gỡ lỗi dễ dàng hơn.

**Ví dụ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Tại sao sử dụng thông báo tiến độ?

Thông báo tiến độ quan trọng vì một số lý do sau:

- **Trải nghiệm người dùng tốt hơn:** Người dùng thấy được cập nhật trong quá trình xử lý, không chỉ khi kết thúc.
- **Phản hồi thời gian thực:** Client có thể hiển thị thanh tiến trình hoặc nhật ký, giúp ứng dụng cảm giác phản hồi nhanh.
- **Dễ dàng gỡ lỗi và giám sát:** Nhà phát triển và người dùng có thể thấy quá trình đang bị chậm hoặc bị kẹt ở đâu.

### Cách triển khai thông báo tiến độ

Cách bạn có thể triển khai thông báo tiến độ trong MCP:

- **Phía server:** Dùng `ctx.info()` or `ctx.log()` để gửi thông báo khi mỗi mục được xử lý. Điều này gửi tin nhắn đến client trước khi kết quả chính sẵn sàng.
- **Phía client:** Triển khai trình xử lý tin nhắn lắng nghe và hiển thị thông báo khi chúng đến. Trình xử lý này phân biệt giữa thông báo và kết quả cuối cùng.

**Ví dụ server:**

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

**Ví dụ client:**

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

## Các lưu ý về Bảo mật

Khi triển khai server MCP với các cơ chế truyền tải dựa trên HTTP, bảo mật trở thành mối quan tâm hàng đầu đòi hỏi chú ý kỹ lưỡng đến nhiều vectơ tấn công và cơ chế bảo vệ.

### Tổng quan

Bảo mật là rất quan trọng khi mở server MCP qua HTTP. Streamable HTTP tạo ra các bề mặt tấn công mới và cần được cấu hình cẩn thận.

### Các điểm chính
- **Xác thực Origin Header**: Luôn xác thực trường `Origin` để ngăn chặn các truy cập không hợp lệ.
- **Sử dụng HTTPS**: Đảm bảo kết nối được mã hóa và an toàn.
- **Cấu hình CORS chính xác**: Giới hạn các nguồn được phép truy cập tài nguyên.
- **Xác thực và phân quyền**: Kiểm soát truy cập đến server và dữ liệu.
- **Theo dõi và ghi nhật ký**: Giám sát các hoạt động bất thường và tấn công tiềm ẩn.

### Duy trì tương thích

Khuyến nghị duy trì tương thích với các client SSE hiện có trong quá trình chuyển đổi. Một số chiến lược:

- Hỗ trợ cả SSE và Streamable HTTP bằng cách chạy hai cơ chế truyền tải trên các endpoint khác nhau.
- Di chuyển dần dần các client sang cơ chế truyền tải mới.

### Thách thức

Cần giải quyết các thách thức sau trong quá trình chuyển đổi:

- Đảm bảo tất cả client được cập nhật.
- Xử lý sự khác biệt trong việc gửi và nhận thông báo.

### Bài tập: Xây dựng ứng dụng MCP streaming của riêng bạn

**Kịch bản:**
Xây dựng server và client MCP trong đó server xử lý một danh sách các mục (ví dụ: tập tin hoặc tài liệu) và gửi một thông báo cho mỗi mục được xử lý. Client sẽ hiển thị từng thông báo ngay khi nhận được.

**Các bước:**

1. Triển khai công cụ server xử lý danh sách và gửi thông báo cho mỗi mục.
2. Triển khai client với trình xử lý tin nhắn để hiển thị thông báo thời gian thực.
3. Kiểm tra bằng cách chạy đồng thời server và client, quan sát các thông báo.

[Solution](./solution/README.md)

## Tài liệu tham khảo & Bước tiếp theo?

Để tiếp tục hành trình với MCP streaming và mở rộng kiến thức, phần này cung cấp thêm tài nguyên và gợi ý các bước tiếp theo để xây dựng ứng dụng nâng cao hơn.

### Tài liệu tham khảo

- [Microsoft: Giới thiệu về HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS trong ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Bước tiếp theo?

- Thử xây dựng các công cụ MCP nâng cao hơn sử dụng streaming cho phân tích thời gian thực, chat hoặc chỉnh sửa cộng tác.
- Khám phá tích hợp MCP streaming với các framework frontend (React, Vue, v.v.) để cập nhật giao diện người dùng trực tiếp.
- Tiếp theo: [Sử dụng AI Toolkit cho VSCode](../07-aitk/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được xem là nguồn chính xác và có thẩm quyền. Đối với những thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu nhầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.