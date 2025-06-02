<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:40:05+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "vi"
}
-->
### -2- Tạo dự án

Bây giờ bạn đã cài đặt SDK, hãy cùng tạo một dự án tiếp theo:

### -3- Tạo các tệp dự án

### -4- Viết mã máy chủ

### -5- Thêm một công cụ và một tài nguyên

Thêm một công cụ và một tài nguyên bằng cách thêm đoạn mã sau:

### -6 Mã hoàn chỉnh

Hãy thêm đoạn mã cuối cùng cần thiết để máy chủ có thể khởi động:

### -7- Kiểm tra máy chủ

Khởi động máy chủ với lệnh sau:

### -8- Chạy bằng inspector

Inspector là một công cụ tuyệt vời giúp bạn khởi động máy chủ và tương tác với nó để kiểm tra hoạt động. Hãy khởi động nó:

> [!NOTE]
> giao diện trong trường "command" có thể khác nhau vì nó chứa lệnh chạy máy chủ cho runtime cụ thể của bạn/

Bạn sẽ thấy giao diện người dùng sau:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.vi.png)

1. Kết nối đến máy chủ bằng cách chọn nút Connect  
   Khi kết nối thành công, bạn sẽ thấy giao diện sau:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.vi.png)

2. Chọn "Tools" và "listTools", bạn sẽ thấy "Add" xuất hiện, chọn "Add" và điền giá trị tham số.

   Bạn sẽ nhận được phản hồi như sau, tức là kết quả từ công cụ "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.vi.png)

Chúc mừng, bạn đã tạo và chạy thành công máy chủ đầu tiên của mình!

### SDK chính thức

MCP cung cấp các SDK chính thức cho nhiều ngôn ngữ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Được duy trì cùng Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Được duy trì cùng Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai chính thức cho TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai chính thức cho Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai chính thức cho Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Được duy trì cùng Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai chính thức cho Rust

## Những điểm chính cần nhớ

- Việc thiết lập môi trường phát triển MCP rất đơn giản với các SDK theo từng ngôn ngữ
- Xây dựng máy chủ MCP bao gồm việc tạo và đăng ký các công cụ với schema rõ ràng
- Kiểm tra và gỡ lỗi là bước thiết yếu để đảm bảo các triển khai MCP đáng tin cậy

## Mẫu ví dụ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Bài tập

Tạo một máy chủ MCP đơn giản với một công cụ bạn chọn:
1. Triển khai công cụ bằng ngôn ngữ bạn thích (.NET, Java, Python hoặc JavaScript).
2. Định nghĩa tham số đầu vào và giá trị trả về.
3. Chạy công cụ inspector để đảm bảo máy chủ hoạt động đúng.
4. Thử nghiệm triển khai với nhiều đầu vào khác nhau.

## Giải pháp

[Solution](./solution/README.md)

## Tài nguyên bổ sung

- [Xây dựng Agents sử dụng Model Context Protocol trên Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP với Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Tiếp theo

Tiếp theo: [Bắt đầu với MCP Clients](/03-GettingStarted/02-client/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được xem là nguồn tham khảo chính xác nhất. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.