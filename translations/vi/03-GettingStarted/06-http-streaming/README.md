<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:20:09+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "vi"
}
-->
# HTTPS Streaming với Model Context Protocol (MCP)

Chương này cung cấp hướng dẫn toàn diện về cách triển khai streaming an toàn, có khả năng mở rộng và thời gian thực với Model Context Protocol (MCP) sử dụng HTTPS. Nội dung bao gồm động lực cho việc streaming, các cơ chế truyền tải hiện có, cách triển khai HTTP có khả năng streaming trong MCP, các thực hành bảo mật tốt nhất, di chuyển từ SSE, và hướng dẫn thực tiễn để xây dựng ứng dụng streaming MCP của riêng bạn.

## Cơ chế Truyền tải và Streaming trong MCP

Phần này khám phá các cơ chế truyền tải khác nhau có trong MCP và vai trò của chúng trong việc cho phép khả năng streaming để giao tiếp thời gian thực giữa client và server.

### Cơ chế Truyền tải là gì?

Cơ chế truyền tải xác định cách dữ liệu được trao đổi giữa client và server. MCP hỗ trợ nhiều loại truyền tải để phù hợp với các môi trường và yêu cầu khác nhau:

- **stdio**: Đầu vào/đầu ra chuẩn, phù hợp với các công cụ cục bộ và dựa trên CLI. Đơn giản nhưng không phù hợp với web hoặc đám mây.
- **SSE (Server-Sent Events)**: Cho phép server đẩy cập nhật thời gian thực tới client qua HTTP. Tốt cho giao diện web, nhưng hạn chế về khả năng mở rộng và linh hoạt.
- **Streamable HTTP**: Cơ chế truyền tải dựa trên HTTP hiện đại, hỗ trợ thông báo và khả năng mở rộng tốt hơn. Được khuyến nghị cho hầu hết các trường hợp sản xuất và đám mây.

### Bảng So sánh

Hãy xem bảng so sánh dưới đây để hiểu sự khác biệt giữa các cơ chế truyền tải này:

| Truyền tải       | Cập nhật thời gian thực | Streaming | Khả năng mở rộng | Trường hợp sử dụng      |
|------------------|------------------------|-----------|------------------|-------------------------|
| stdio            | Không                  | Không     | Thấp             | Công cụ CLI cục bộ      |
| SSE              | Có                     | Có        | Trung bình       | Web, cập nhật thời gian thực |
| Streamable HTTP  | Có                     | Có        | Cao              | Đám mây, đa client      |

> **Tip:** Việc chọn cơ chế truyền tải phù hợp ảnh hưởng đến hiệu năng, khả năng mở rộng và trải nghiệm người dùng. **Streamable HTTP** được khuyến nghị cho các ứng dụng hiện đại, có khả năng mở rộng và sẵn sàng cho đám mây.

Lưu ý các cơ chế truyền tải stdio và SSE đã được giới thiệu trong các chương trước và Streamable HTTP là cơ chế truyền tải được đề cập trong chương này.

## Streaming: Khái niệm và Động lực

Hiểu các khái niệm cơ bản và động lực phía sau streaming là điều cần thiết để triển khai hệ thống giao tiếp thời gian thực hiệu quả.

**Streaming** là kỹ thuật trong lập trình mạng cho phép dữ liệu được gửi và nhận theo từng phần nhỏ, dễ quản lý hoặc theo chuỗi sự kiện, thay vì phải đợi toàn bộ phản hồi hoàn chỉnh. Điều này đặc biệt hữu ích cho:

- Các tập tin hoặc bộ dữ liệu lớn.
- Cập nhật thời gian thực (ví dụ: chat, thanh tiến trình).
- Các tính toán kéo dài mà bạn muốn giữ người dùng được thông báo.

Dưới đây là những điều bạn cần biết về streaming ở cấp độ tổng quan:

- Dữ liệu được truyền dần dần, không phải một lần.
- Client có thể xử lý dữ liệu ngay khi nhận được.
- Giảm độ trễ cảm nhận và cải thiện trải nghiệm người dùng.

### Tại sao nên dùng streaming?

Các lý do sử dụng streaming bao gồm:

- Người dùng nhận được phản hồi ngay lập tức, không chỉ khi kết thúc.
- Cho phép các ứng dụng thời gian thực và giao diện người dùng phản hồi nhanh.
- Sử dụng hiệu quả hơn tài nguyên mạng và tính toán.

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

Ví dụ này minh họa server gửi một chuỗi thông điệp tới client khi chúng sẵn sàng, thay vì đợi tất cả các thông điệp hoàn chỉnh.

**Cách hoạt động:**
- Server phát từng thông điệp khi nó sẵn sàng.
- Client nhận và in từng phần dữ liệu khi nó tới.

**Yêu cầu:**
- Server phải sử dụng phản hồi streaming (ví dụ: `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) thay vì chọn streaming qua MCP.

- **Đối với nhu cầu streaming đơn giản:** Streaming HTTP truyền thống dễ triển khai và đủ dùng cho các nhu cầu cơ bản.

- **Đối với ứng dụng phức tạp, tương tác:** Streaming MCP cung cấp cách tiếp cận có cấu trúc hơn với metadata phong phú và phân tách giữa thông báo và kết quả cuối cùng.

- **Đối với ứng dụng AI:** Hệ thống thông báo của MCP rất hữu ích cho các tác vụ AI chạy lâu, giúp người dùng được cập nhật tiến trình.

## Streaming trong MCP

Bạn đã thấy một số khuyến nghị và so sánh về sự khác biệt giữa streaming truyền thống và streaming trong MCP. Bây giờ hãy đi sâu vào chi tiết cách bạn có thể tận dụng streaming trong MCP.

Hiểu cách streaming hoạt động trong khung MCP là rất quan trọng để xây dựng ứng dụng phản hồi nhanh, cung cấp phản hồi thời gian thực cho người dùng trong các tác vụ chạy lâu.

Trong MCP, streaming không phải là gửi phản hồi chính theo từng phần, mà là gửi **thông báo** tới client trong khi công cụ đang xử lý yêu cầu. Các thông báo này có thể bao gồm cập nhật tiến trình, nhật ký hoặc các sự kiện khác.

### Cách hoạt động

Kết quả chính vẫn được gửi dưới dạng một phản hồi duy nhất. Tuy nhiên, các thông báo có thể được gửi dưới dạng các tin nhắn riêng biệt trong quá trình xử lý và cập nhật client theo thời gian thực. Client phải có khả năng xử lý và hiển thị các thông báo này.

## Thông báo là gì?

Chúng ta đã nói đến "Thông báo", vậy nó có ý nghĩa gì trong ngữ cảnh MCP?

Thông báo là tin nhắn gửi từ server đến client để thông báo về tiến trình, trạng thái hoặc các sự kiện khác trong quá trình thực hiện tác vụ dài. Thông báo giúp tăng tính minh bạch và cải thiện trải nghiệm người dùng.

Ví dụ, client sẽ gửi một thông báo khi quá trình bắt tay (handshake) ban đầu với server đã hoàn thành.

Thông báo có dạng tin nhắn JSON như sau:

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

Để kích hoạt logging, server cần bật tính năng này như sau:

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

| Mức độ    | Mô tả                         | Ví dụ sử dụng                  |
|-----------|-------------------------------|-------------------------------|
| debug     | Thông tin gỡ lỗi chi tiết      | Điểm vào/ra của hàm            |
| info      | Thông tin chung                | Cập nhật tiến trình hoạt động  |
| notice    | Sự kiện bình thường nhưng quan trọng | Thay đổi cấu hình          |
| warning   | Cảnh báo                      | Sử dụng tính năng đã lỗi thời  |
| error     | Lỗi                          | Thất bại trong hoạt động       |
| critical  | Lỗi nghiêm trọng              | Lỗi thành phần hệ thống        |
| alert     | Cần hành động ngay lập tức    | Phát hiện hỏng dữ liệu         |
| emergency | Hệ thống không sử dụng được   | Hỏng hoàn toàn hệ thống        |

## Triển khai Thông báo trong MCP

Để triển khai thông báo trong MCP, bạn cần thiết lập cả phía server và client để xử lý cập nhật thời gian thực. Điều này cho phép ứng dụng của bạn cung cấp phản hồi ngay lập tức cho người dùng trong các tác vụ chạy lâu.

### Phía server: Gửi Thông báo

Bắt đầu với phía server. Trong MCP, bạn định nghĩa các công cụ có thể gửi thông báo trong khi xử lý yêu cầu. Server sử dụng đối tượng context (thường là `ctx`) để gửi tin nhắn tới client.

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

Trong ví dụ trên, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` truyền tải:

```python
mcp.run(transport="streamable-http")
```

</details>

### Phía client: Nhận Thông báo

Client phải triển khai bộ xử lý tin nhắn để xử lý và hiển thị các thông báo khi chúng tới.

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

Trong đoạn mã trên, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) và client của bạn triển khai bộ xử lý tin nhắn để xử lý thông báo.

## Thông báo Tiến trình & Các Tình huống

Phần này giải thích khái niệm thông báo tiến trình trong MCP, tại sao chúng quan trọng và cách triển khai chúng sử dụng Streamable HTTP. Bạn cũng sẽ tìm thấy một bài tập thực hành để củng cố kiến thức.

Thông báo tiến trình là các tin nhắn thời gian thực gửi từ server đến client trong các tác vụ chạy lâu. Thay vì đợi toàn bộ quá trình kết thúc, server liên tục cập nhật trạng thái hiện tại cho client. Điều này cải thiện tính minh bạch, trải nghiệm người dùng và giúp dễ dàng gỡ lỗi hơn.

**Ví dụ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Tại sao dùng Thông báo Tiến trình?

Thông báo tiến trình quan trọng vì nhiều lý do:

- **Trải nghiệm người dùng tốt hơn:** Người dùng thấy cập nhật khi công việc đang tiến triển, không chỉ khi kết thúc.
- **Phản hồi thời gian thực:** Client có thể hiển thị thanh tiến trình hoặc nhật ký, làm cho ứng dụng cảm giác phản hồi nhanh.
- **Dễ gỡ lỗi và giám sát:** Nhà phát triển và người dùng có thể biết được điểm nào trong quá trình có thể chậm hoặc bị kẹt.

### Cách triển khai Thông báo Tiến trình

Dưới đây là cách bạn có thể triển khai thông báo tiến trình trong MCP:

- **Ở phía server:** Dùng `ctx.info()` or `ctx.log()` để gửi thông báo khi từng mục được xử lý. Điều này gửi tin nhắn tới client trước khi kết quả chính sẵn sàng.
- **Ở phía client:** Triển khai bộ xử lý tin nhắn lắng nghe và hiển thị thông báo khi chúng tới. Bộ xử lý này phân biệt giữa thông báo và kết quả cuối cùng.

**Ví dụ Server:**

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

## Các Xem Xét về Bảo mật

Khi triển khai các server MCP với các cơ chế truyền tải dựa trên HTTP, bảo mật trở thành mối quan tâm hàng đầu cần chú ý đến nhiều vectơ tấn công và cơ chế bảo vệ.

### Tổng quan

Bảo mật rất quan trọng khi mở các server MCP qua HTTP. Streamable HTTP tạo ra các bề mặt tấn công mới và cần cấu hình cẩn thận.

### Các điểm chính
- **Xác thực Header Origin**: Luôn xác thực `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` thay vì client SSE.
3. **Triển khai bộ xử lý tin nhắn** ở client để xử lý thông báo.
4. **Kiểm tra tính tương thích** với các công cụ và quy trình hiện có.

### Duy trì Tính tương thích

Khuyến nghị duy trì tương thích với các client SSE hiện có trong quá trình di chuyển. Các chiến lược gồm:

- Bạn có thể hỗ trợ cả SSE và Streamable HTTP bằng cách chạy cả hai cơ chế trên các endpoint khác nhau.
- Di chuyển dần dần client sang cơ chế truyền tải mới.

### Thách thức

Hãy đảm bảo bạn giải quyết các thách thức sau trong quá trình di chuyển:

- Đảm bảo tất cả client được cập nhật
- Xử lý sự khác biệt trong việc gửi thông báo

### Bài tập: Xây dựng Ứng dụng Streaming MCP của riêng bạn

**Kịch bản:**
Xây dựng một server và client MCP, trong đó server xử lý danh sách các mục (ví dụ: file hoặc tài liệu) và gửi một thông báo cho mỗi mục đã xử lý. Client hiển thị từng thông báo khi nó đến.

**Các bước:**

1. Triển khai công cụ server xử lý danh sách và gửi thông báo cho từng mục.
2. Triển khai client với bộ xử lý tin nhắn để hiển thị thông báo theo thời gian thực.
3. Kiểm tra triển khai bằng cách chạy cả server và client, quan sát các thông báo.

[Solution](./solution/README.md)

## Đọc thêm & Tiếp theo?

Để tiếp tục hành trình với streaming MCP và mở rộng kiến thức, phần này cung cấp các tài nguyên bổ sung và các bước tiếp theo gợi ý để xây dựng các ứng dụng nâng cao hơn.

### Đọc thêm

- [Microsoft: Giới thiệu về HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS trong ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Tiếp theo?

- Thử xây dựng các công cụ MCP nâng cao hơn sử dụng streaming cho phân tích thời gian thực, chat hoặc chỉnh sửa hợp tác.
- Khám phá tích hợp streaming MCP với các framework frontend (React, Vue, v.v.) để cập nhật giao diện người dùng trực tiếp.
- Tiếp theo: [Sử dụng AI Toolkit cho VSCode](../07-aitk/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi nỗ lực đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn tham khảo chính xác nhất. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm đối với bất kỳ sự hiểu nhầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.