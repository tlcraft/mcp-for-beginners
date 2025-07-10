<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:18:19+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "vi"
}
-->
# HTTPS Streaming với Model Context Protocol (MCP)

Chương này cung cấp hướng dẫn toàn diện về cách triển khai streaming an toàn, có khả năng mở rộng và thời gian thực với Model Context Protocol (MCP) sử dụng HTTPS. Nội dung bao gồm động lực cho streaming, các cơ chế truyền tải có sẵn, cách triển khai HTTP có thể stream trong MCP, các thực hành bảo mật tốt nhất, di chuyển từ SSE, và hướng dẫn thực tiễn để xây dựng ứng dụng streaming MCP của riêng bạn.

## Cơ chế truyền tải và Streaming trong MCP

Phần này khám phá các cơ chế truyền tải khác nhau có trong MCP và vai trò của chúng trong việc hỗ trợ khả năng streaming cho giao tiếp thời gian thực giữa client và server.

### Cơ chế truyền tải là gì?

Cơ chế truyền tải định nghĩa cách dữ liệu được trao đổi giữa client và server. MCP hỗ trợ nhiều loại truyền tải để phù hợp với các môi trường và yêu cầu khác nhau:

- **stdio**: Đầu vào/đầu ra chuẩn, phù hợp cho các công cụ chạy cục bộ và CLI. Đơn giản nhưng không phù hợp cho web hoặc cloud.
- **SSE (Server-Sent Events)**: Cho phép server đẩy các cập nhật thời gian thực đến client qua HTTP. Tốt cho giao diện web, nhưng hạn chế về khả năng mở rộng và linh hoạt.
- **Streamable HTTP**: Cơ chế truyền tải streaming dựa trên HTTP hiện đại, hỗ trợ thông báo và khả năng mở rộng tốt hơn. Được khuyến nghị cho hầu hết các kịch bản sản xuất và cloud.

### Bảng so sánh

Hãy xem bảng so sánh dưới đây để hiểu sự khác biệt giữa các cơ chế truyền tải này:

| Truyền tải       | Cập nhật thời gian thực | Streaming | Khả năng mở rộng | Trường hợp sử dụng       |
|------------------|------------------------|-----------|------------------|-------------------------|
| stdio            | Không                  | Không     | Thấp             | Công cụ CLI cục bộ      |
| SSE              | Có                     | Có        | Trung bình       | Web, cập nhật thời gian thực |
| Streamable HTTP  | Có                     | Có        | Cao              | Cloud, đa client        |

> **Tip:** Việc chọn cơ chế truyền tải phù hợp ảnh hưởng đến hiệu năng, khả năng mở rộng và trải nghiệm người dùng. **Streamable HTTP** được khuyến nghị cho các ứng dụng hiện đại, có khả năng mở rộng và sẵn sàng cho cloud.

Lưu ý các cơ chế truyền tải stdio và SSE đã được giới thiệu trong các chương trước và cách Streamable HTTP là cơ chế được đề cập trong chương này.

## Streaming: Khái niệm và Động lực

Hiểu các khái niệm cơ bản và động lực đằng sau streaming là điều cần thiết để triển khai các hệ thống giao tiếp thời gian thực hiệu quả.

**Streaming** là kỹ thuật trong lập trình mạng cho phép dữ liệu được gửi và nhận theo từng phần nhỏ, dễ quản lý hoặc theo chuỗi sự kiện, thay vì phải chờ toàn bộ phản hồi sẵn sàng. Điều này đặc biệt hữu ích cho:

- Các tập tin hoặc bộ dữ liệu lớn.
- Cập nhật thời gian thực (ví dụ: chat, thanh tiến trình).
- Các phép tính chạy lâu mà bạn muốn giữ người dùng được cập nhật.

Dưới đây là những điều bạn cần biết về streaming ở mức độ tổng quan:

- Dữ liệu được truyền dần dần, không phải tất cả cùng lúc.
- Client có thể xử lý dữ liệu ngay khi nhận được.
- Giảm độ trễ cảm nhận và cải thiện trải nghiệm người dùng.

### Tại sao nên dùng streaming?

Các lý do sử dụng streaming bao gồm:

- Người dùng nhận phản hồi ngay lập tức, không chỉ khi kết thúc.
- Hỗ trợ các ứng dụng thời gian thực và giao diện người dùng phản hồi nhanh.
- Sử dụng tài nguyên mạng và tính toán hiệu quả hơn.

### Ví dụ đơn giản: Server & Client HTTP Streaming

Dưới đây là ví dụ đơn giản về cách triển khai streaming:

<details>
<summary>Python</summary>

**Server (Python, sử dụng FastAPI và StreamingResponse):**
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

**Client (Python, sử dụng requests):**
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

Ví dụ này minh họa server gửi một chuỗi các thông điệp đến client ngay khi chúng sẵn sàng, thay vì chờ tất cả thông điệp được chuẩn bị xong.

**Cách hoạt động:**
- Server trả về từng thông điệp ngay khi sẵn sàng.
- Client nhận và in từng phần dữ liệu khi nó đến.

**Yêu cầu:**
- Server phải sử dụng phản hồi streaming (ví dụ `StreamingResponse` trong FastAPI).
- Client phải xử lý phản hồi dưới dạng stream (`stream=True` trong requests).
- Content-Type thường là `text/event-stream` hoặc `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, sử dụng Spring Boot và Server-Sent Events):**

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

**Client (Java, sử dụng Spring WebFlux WebClient):**

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
- Sử dụng stack reactive của Spring Boot với `Flux` cho streaming
- `ServerSentEvent` cung cấp streaming sự kiện có cấu trúc với các loại sự kiện
- `WebClient` với `bodyToFlux()` cho phép tiêu thụ streaming theo kiểu reactive
- `delayElements()` mô phỏng thời gian xử lý giữa các sự kiện
- Sự kiện có thể có loại (`info`, `result`) để client xử lý tốt hơn

</details>

### So sánh: Streaming truyền thống vs Streaming MCP

Sự khác biệt giữa cách streaming hoạt động theo kiểu "truyền thống" và cách hoạt động trong MCP có thể được mô tả như sau:

| Tính năng              | Streaming HTTP truyền thống | Streaming MCP (Thông báo)       |
|-----------------------|-----------------------------|--------------------------------|
| Phản hồi chính         | Chia nhỏ (chunked)           | Một lần, ở cuối                |
| Cập nhật tiến trình    | Gửi dưới dạng các phần dữ liệu | Gửi dưới dạng thông báo         |
| Yêu cầu client         | Phải xử lý stream            | Phải triển khai bộ xử lý thông điệp |
| Trường hợp sử dụng     | Tập tin lớn, luồng token AI  | Tiến trình, nhật ký, phản hồi thời gian thực |

### Những điểm khác biệt chính

Ngoài ra, đây là một số điểm khác biệt chính:

- **Mẫu giao tiếp:**
   - Streaming HTTP truyền thống: Sử dụng mã hóa chunked đơn giản để gửi dữ liệu theo từng phần
   - Streaming MCP: Sử dụng hệ thống thông báo có cấu trúc với giao thức JSON-RPC

- **Định dạng thông điệp:**
   - HTTP truyền thống: Các phần dữ liệu dạng văn bản thuần với dấu xuống dòng
   - MCP: Các đối tượng LoggingMessageNotification có cấu trúc kèm metadata

- **Triển khai client:**
   - HTTP truyền thống: Client đơn giản xử lý phản hồi streaming
   - MCP: Client phức tạp hơn với bộ xử lý thông điệp để xử lý các loại thông điệp khác nhau

- **Cập nhật tiến trình:**
   - HTTP truyền thống: Tiến trình là một phần của luồng phản hồi chính
   - MCP: Tiến trình được gửi qua các thông báo riêng biệt trong khi phản hồi chính được gửi ở cuối

### Khuyến nghị

Chúng tôi có một số khuyến nghị khi lựa chọn giữa triển khai streaming truyền thống (như endpoint `/stream` đã trình bày ở trên) và streaming qua MCP.

- **Cho nhu cầu streaming đơn giản:** Streaming HTTP truyền thống dễ triển khai và đủ cho các nhu cầu cơ bản.

- **Cho ứng dụng phức tạp, tương tác:** Streaming MCP cung cấp cách tiếp cận có cấu trúc hơn với metadata phong phú và tách biệt giữa thông báo và kết quả cuối cùng.

- **Cho ứng dụng AI:** Hệ thống thông báo của MCP đặc biệt hữu ích cho các tác vụ AI chạy lâu, giúp người dùng được cập nhật tiến trình.

## Streaming trong MCP

Bạn đã thấy một số khuyến nghị và so sánh về sự khác biệt giữa streaming truyền thống và streaming trong MCP. Bây giờ hãy đi sâu vào chi tiết cách bạn có thể tận dụng streaming trong MCP.

Hiểu cách streaming hoạt động trong khuôn khổ MCP là điều cần thiết để xây dựng các ứng dụng phản hồi nhanh, cung cấp phản hồi thời gian thực cho người dùng trong các thao tác chạy lâu.

Trong MCP, streaming không phải là gửi phản hồi chính theo từng phần, mà là gửi **thông báo** đến client trong khi công cụ đang xử lý yêu cầu. Các thông báo này có thể bao gồm cập nhật tiến trình, nhật ký hoặc các sự kiện khác.

### Cách hoạt động

Kết quả chính vẫn được gửi dưới dạng một phản hồi duy nhất. Tuy nhiên, các thông báo có thể được gửi dưới dạng các tin nhắn riêng biệt trong quá trình xử lý và cập nhật client theo thời gian thực. Client phải có khả năng xử lý và hiển thị các thông báo này.

## Thông báo là gì?

Chúng ta đã nói đến "Thông báo", vậy nó có nghĩa gì trong bối cảnh MCP?

Thông báo là một tin nhắn được gửi từ server đến client để thông báo về tiến trình, trạng thái hoặc các sự kiện khác trong quá trình thực hiện thao tác chạy lâu. Thông báo giúp tăng tính minh bạch và cải thiện trải nghiệm người dùng.

Ví dụ, client sẽ gửi một thông báo khi quá trình bắt tay ban đầu với server đã hoàn thành.

Một thông báo có dạng tin nhắn JSON như sau:

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

Để logging hoạt động, server cần kích hoạt nó như một tính năng/năng lực như sau:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Tùy thuộc vào SDK sử dụng, logging có thể được bật mặc định hoặc bạn cần bật rõ ràng trong cấu hình server.

Có nhiều loại thông báo khác nhau:

| Cấp độ    | Mô tả                         | Ví dụ sử dụng                  |
|-----------|-------------------------------|-------------------------------|
| debug     | Thông tin gỡ lỗi chi tiết      | Điểm vào/ra hàm               |
| info      | Thông tin chung                | Cập nhật tiến trình thao tác   |
| notice    | Sự kiện bình thường nhưng quan trọng | Thay đổi cấu hình          |
| warning   | Điều kiện cảnh báo             | Sử dụng tính năng đã lỗi thời  |
| error     | Điều kiện lỗi                 | Thao tác thất bại              |
| critical  | Điều kiện nghiêm trọng         | Lỗi thành phần hệ thống        |
| alert     | Cần hành động ngay lập tức     | Phát hiện hỏng dữ liệu         |
| emergency | Hệ thống không thể sử dụng     | Lỗi hệ thống hoàn toàn         |

## Triển khai Thông báo trong MCP

Để triển khai thông báo trong MCP, bạn cần thiết lập cả phía server và client để xử lý cập nhật thời gian thực. Điều này cho phép ứng dụng của bạn cung cấp phản hồi ngay lập tức cho người dùng trong các thao tác chạy lâu.

### Phía server: Gửi Thông báo

Bắt đầu với phía server. Trong MCP, bạn định nghĩa các công cụ có thể gửi thông báo trong quá trình xử lý yêu cầu. Server sử dụng đối tượng context (thường là `ctx`) để gửi tin nhắn đến client.

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

Trong ví dụ trên, công cụ `process_files` gửi ba thông báo đến client khi xử lý từng file. Phương thức `ctx.info()` được dùng để gửi các thông điệp thông tin.

</details>

Ngoài ra, để bật thông báo, đảm bảo server của bạn sử dụng cơ chế truyền tải streaming (như `streamable-http`) và client của bạn triển khai bộ xử lý thông điệp để xử lý thông báo. Dưới đây là cách thiết lập server sử dụng truyền tải `streamable-http`:

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

Trong ví dụ .NET này, công cụ `ProcessFiles` được trang trí bằng thuộc tính `Tool` và gửi ba thông báo đến client khi xử lý từng file. Phương thức `ctx.Info()` được dùng để gửi các thông điệp thông tin.

Để bật thông báo trong server MCP .NET, đảm bảo bạn sử dụng cơ chế truyền tải streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Phía client: Nhận Thông báo

Client phải triển khai bộ xử lý thông điệp để xử lý và hiển thị các thông báo khi chúng đến.

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

Trong đoạn mã trên, hàm `message_handler` kiểm tra xem tin nhắn đến có phải là thông báo không. Nếu đúng, nó in ra thông báo; nếu không, xử lý như tin nhắn server bình thường. Cũng lưu ý cách `ClientSession` được khởi tạo với `message_handler` để xử lý các thông báo đến.

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

Trong ví dụ .NET này, hàm `MessageHandler` kiểm tra xem tin nhắn đến có phải là thông báo không. Nếu đúng, nó in ra thông báo; nếu không, xử lý như tin nhắn server bình thường. `ClientSession` được khởi tạo với bộ xử lý thông điệp thông qua `ClientSessionOptions`.

</details>

Để bật thông báo, đảm bảo server của bạn sử dụng cơ chế truyền tải streaming (như `streamable-http`) và client triển khai bộ xử lý thông điệp để xử lý thông báo.

## Thông báo tiến trình & Các kịch bản

Phần này giải thích khái niệm thông báo tiến trình trong MCP, tại sao chúng quan trọng và cách triển khai chúng bằng Streamable HTTP. Bạn cũng sẽ tìm thấy một bài tập thực hành để củng cố kiến thức.

Thông báo tiến trình là các tin nhắn thời gian thực được gửi từ server đến client trong quá trình thao tác chạy lâu. Thay vì chờ toàn bộ quá trình kết thúc, server liên tục cập nhật trạng thái hiện tại cho client. Điều này cải thiện tính minh bạch, trải nghiệm người dùng và giúp việc gỡ lỗi dễ dàng hơn.

**Ví dụ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Tại sao nên dùng Thông báo tiến trình?

Thông báo tiến trình quan trọng vì nhiều lý do:

- **Trải nghiệm người dùng tốt hơn:** Người dùng thấy được cập nhật khi công việc đang tiến triển, không chỉ khi kết thúc.
- **Phản hồi thời gian thực:** Client có thể hiển thị thanh tiến trình hoặc nhật ký, giúp ứng dụng cảm giác phản hồi nhanh.
- **Dễ dàng gỡ lỗi và giám sát:** Nhà phát triển và người dùng có thể thấy được quá trình đang chậm hoặc bị kẹt ở đâu.

### Cách triển khai Thông báo tiến trình

Dưới đây là cách bạn có thể triển khai thông báo tiến trình trong MCP:

- **Phía server:** Sử dụng `ctx.info()` hoặc `ctx.log()` để gửi thông báo khi từng mục được xử lý. Điều này gửi tin nhắn đến client trước khi kết quả chính sẵn sàng.
- **Phía client:** Triển khai bộ xử lý thông điệp lắng nghe và hiển thị các thông báo khi chúng đến. Bộ xử lý này phân biệt giữa thông báo và kết quả cuối cùng.

**Ví dụ phía server:**

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

**Ví dụ Client:**

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

## Các Vấn Đề Bảo Mật

Khi triển khai các server MCP sử dụng giao thức HTTP, bảo mật trở thành một yếu tố cực kỳ quan trọng, đòi hỏi phải chú ý kỹ lưỡng đến nhiều hướng tấn công và cơ chế bảo vệ.

### Tổng Quan

Bảo mật là yếu tố then chốt khi mở các server MCP qua HTTP. Streamable HTTP tạo ra các điểm tấn công mới và cần được cấu hình cẩn thận.

### Các Điểm Chính
- **Kiểm tra Header Origin**: Luôn xác thực header `Origin` để ngăn chặn các cuộc tấn công DNS rebinding.
- **Ràng buộc với localhost**: Trong phát triển cục bộ, hãy ràng buộc server với `localhost` để tránh bị truy cập từ internet công cộng.
- **Xác thực**: Triển khai xác thực (ví dụ: API keys, OAuth) cho môi trường sản xuất.
- **CORS**: Cấu hình chính sách Cross-Origin Resource Sharing (CORS) để giới hạn quyền truy cập.
- **HTTPS**: Sử dụng HTTPS trong môi trường sản xuất để mã hóa lưu lượng.

### Thực Hành Tốt Nhất
- Không bao giờ tin tưởng các yêu cầu đến mà không xác thực.
- Ghi lại và giám sát tất cả các truy cập và lỗi.
- Thường xuyên cập nhật các thư viện phụ thuộc để vá các lỗ hổng bảo mật.

### Thách Thức
- Cân bằng giữa bảo mật và sự thuận tiện trong phát triển
- Đảm bảo tương thích với nhiều môi trường client khác nhau


## Nâng Cấp Từ SSE Sang Streamable HTTP

Đối với các ứng dụng đang sử dụng Server-Sent Events (SSE), việc chuyển sang Streamable HTTP sẽ mang lại khả năng mở rộng tốt hơn và bền vững hơn cho các triển khai MCP của bạn.

### Tại Sao Nên Nâng Cấp?

Có hai lý do chính để nâng cấp từ SSE sang Streamable HTTP:

- Streamable HTTP cung cấp khả năng mở rộng, tương thích và hỗ trợ thông báo phong phú hơn so với SSE.
- Đây là giao thức được khuyến nghị cho các ứng dụng MCP mới.

### Các Bước Di Cư

Dưới đây là cách bạn có thể chuyển từ SSE sang Streamable HTTP trong các ứng dụng MCP:

- **Cập nhật mã server** để sử dụng `transport="streamable-http"` trong `mcp.run()`.
- **Cập nhật mã client** để dùng `streamablehttp_client` thay vì client SSE.
- **Triển khai bộ xử lý tin nhắn** trong client để xử lý các thông báo.
- **Kiểm tra tính tương thích** với các công cụ và quy trình hiện có.

### Duy Trì Tương Thích

Nên duy trì tương thích với các client SSE hiện tại trong quá trình di cư. Một số chiến lược:

- Hỗ trợ cả SSE và Streamable HTTP bằng cách chạy hai giao thức trên các endpoint khác nhau.
- Dần dần chuyển các client sang giao thức mới.

### Thách Thức

Cần lưu ý các thách thức sau trong quá trình di cư:

- Đảm bảo tất cả client được cập nhật
- Xử lý sự khác biệt trong cách gửi thông báo

## Các Vấn Đề Bảo Mật

Bảo mật luôn là ưu tiên hàng đầu khi triển khai bất kỳ server nào, đặc biệt là khi sử dụng các giao thức HTTP như Streamable HTTP trong MCP.

Khi triển khai các server MCP sử dụng giao thức HTTP, bảo mật trở thành một yếu tố cực kỳ quan trọng, đòi hỏi phải chú ý kỹ lưỡng đến nhiều hướng tấn công và cơ chế bảo vệ.

### Tổng Quan

Bảo mật là yếu tố then chốt khi mở các server MCP qua HTTP. Streamable HTTP tạo ra các điểm tấn công mới và cần được cấu hình cẩn thận.

Dưới đây là một số lưu ý quan trọng về bảo mật:

- **Kiểm tra Header Origin**: Luôn xác thực header `Origin` để ngăn chặn các cuộc tấn công DNS rebinding.
- **Ràng buộc với localhost**: Trong phát triển cục bộ, hãy ràng buộc server với `localhost` để tránh bị truy cập từ internet công cộng.
- **Xác thực**: Triển khai xác thực (ví dụ: API keys, OAuth) cho môi trường sản xuất.
- **CORS**: Cấu hình chính sách Cross-Origin Resource Sharing (CORS) để giới hạn quyền truy cập.
- **HTTPS**: Sử dụng HTTPS trong môi trường sản xuất để mã hóa lưu lượng.

### Thực Hành Tốt Nhất

Ngoài ra, đây là một số thực hành tốt khi triển khai bảo mật cho server streaming MCP của bạn:

- Không bao giờ tin tưởng các yêu cầu đến mà không xác thực.
- Ghi lại và giám sát tất cả các truy cập và lỗi.
- Thường xuyên cập nhật các thư viện phụ thuộc để vá các lỗ hổng bảo mật.

### Thách Thức

Bạn sẽ gặp một số thách thức khi triển khai bảo mật cho server streaming MCP:

- Cân bằng giữa bảo mật và sự thuận tiện trong phát triển
- Đảm bảo tương thích với nhiều môi trường client khác nhau

### Bài Tập: Xây Dựng Ứng Dụng Streaming MCP Của Riêng Bạn

**Kịch bản:**
Xây dựng một server và client MCP, trong đó server xử lý một danh sách các mục (ví dụ: file hoặc tài liệu) và gửi thông báo cho mỗi mục được xử lý. Client sẽ hiển thị từng thông báo ngay khi nhận được.

**Các bước:**

1. Triển khai công cụ server xử lý danh sách và gửi thông báo cho từng mục.
2. Triển khai client với bộ xử lý tin nhắn để hiển thị thông báo theo thời gian thực.
3. Kiểm tra bằng cách chạy đồng thời server và client, quan sát các thông báo.

[Solution](./solution/README.md)

## Tài Liệu Tham Khảo & Bước Tiếp Theo?

Để tiếp tục hành trình với streaming MCP và mở rộng kiến thức, phần này cung cấp các tài nguyên bổ sung và gợi ý các bước tiếp theo để xây dựng các ứng dụng nâng cao hơn.

### Tài Liệu Tham Khảo

- [Microsoft: Giới thiệu về HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS trong ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Bước Tiếp Theo?

- Thử xây dựng các công cụ MCP nâng cao hơn sử dụng streaming cho phân tích thời gian thực, chat hoặc chỉnh sửa cộng tác.
- Khám phá tích hợp streaming MCP với các framework frontend (React, Vue, v.v.) để cập nhật giao diện người dùng trực tiếp.
- Tiếp theo: [Sử dụng AI Toolkit cho VSCode](../07-aitk/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.