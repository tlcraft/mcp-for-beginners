<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:13:51+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "vi"
}
-->
# MCP Java Client - Ví dụ Máy tính

Dự án này trình bày cách tạo một client Java kết nối và tương tác với server MCP (Model Context Protocol). Trong ví dụ này, chúng ta sẽ kết nối đến server máy tính từ Chương 01 và thực hiện các phép toán toán học khác nhau.

## Yêu cầu trước

Trước khi chạy client này, bạn cần:

1. **Khởi động Server Máy tính** từ Chương 01:
   - Điều hướng đến thư mục server máy tính: `03-GettingStarted/01-first-server/solution/java/`
   - Xây dựng và chạy server máy tính:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Server sẽ chạy tại `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` là một ứng dụng Java minh họa cách:
- Kết nối tới server MCP sử dụng giao thức Server-Sent Events (SSE)
- Liệt kê các công cụ có sẵn từ server
- Gọi các hàm máy tính từ xa
- Xử lý phản hồi và hiển thị kết quả

## Cách hoạt động

Client sử dụng framework Spring AI MCP để:

1. **Thiết lập kết nối**: Tạo WebFlux SSE client transport để kết nối đến server máy tính
2. **Khởi tạo client**: Thiết lập MCP client và thiết lập kết nối
3. **Khám phá công cụ**: Liệt kê tất cả các phép toán máy tính có sẵn
4. **Thực thi phép toán**: Gọi các hàm toán học với dữ liệu mẫu
5. **Hiển thị kết quả**: Hiển thị kết quả của từng phép tính

## Cấu trúc dự án

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Các phụ thuộc chính

Dự án sử dụng các phụ thuộc chính sau:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Phụ thuộc này cung cấp:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - Giao thức SSE cho giao tiếp web
- Các schema MCP và các kiểu yêu cầu/phản hồi

## Xây dựng dự án

Xây dựng dự án sử dụng Maven wrapper:

```cmd
.\mvnw clean install
```

## Chạy client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Lưu ý**: Đảm bảo server máy tính đang chạy tại `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Liệt kê công cụ** - Hiển thị tất cả các phép toán máy tính có sẵn
3. **Thực hiện phép tính**:
   - Cộng: 5 + 3 = 8
   - Trừ: 10 - 4 = 6
   - Nhân: 6 × 7 = 42
   - Chia: 20 ÷ 4 = 5
   - Lũy thừa: 2^8 = 256
   - Căn bậc hai: √16 = 4
   - Giá trị tuyệt đối: |-5.5| = 5.5
   - Trợ giúp: Hiển thị các phép toán có sẵn

## Kết quả mong đợi

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Lưu ý**: Bạn có thể thấy cảnh báo Maven về các luồng còn chạy khi kết thúc - điều này bình thường với ứng dụng phản ứng và không phải lỗi.

## Hiểu về mã nguồn

### 1. Thiết lập giao thức
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Điều này tạo một giao thức SSE (Server-Sent Events) kết nối đến server máy tính.

### 2. Tạo client
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Tạo một MCP client đồng bộ và khởi tạo kết nối.

### 3. Gọi công cụ
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Gọi công cụ "add" với tham số a=5.0 và b=3.0.

## Khắc phục sự cố

### Server không chạy
Nếu bạn gặp lỗi kết nối, hãy chắc chắn server máy tính từ Chương 01 đang chạy:
```
Error: Connection refused
```
**Giải pháp**: Khởi động server máy tính trước.

### Cổng đã được sử dụng
Nếu cổng 8080 đang bận:
```
Error: Address already in use
```
**Giải pháp**: Dừng các ứng dụng khác đang dùng cổng 8080 hoặc thay đổi cổng server.

### Lỗi khi xây dựng
Nếu gặp lỗi khi xây dựng:
```cmd
.\mvnw clean install -DskipTests
```

## Tìm hiểu thêm

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn chính xác và đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.