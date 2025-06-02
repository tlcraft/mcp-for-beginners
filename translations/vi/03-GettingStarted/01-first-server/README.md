<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:05:00+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "vi"
}
-->
### -2- Tạo dự án

Bây giờ bạn đã cài đặt SDK, hãy tiếp tục tạo một dự án mới:

### -3- Tạo các tệp dự án

### -4- Viết mã cho server

### -5- Thêm một công cụ và một tài nguyên

Thêm một công cụ và một tài nguyên bằng cách thêm đoạn mã sau:

### -6- Mã hoàn chỉnh

Hãy thêm đoạn mã cuối cùng cần thiết để server có thể khởi động:

### -7- Kiểm tra server

Khởi động server với lệnh sau:

### -8- Chạy bằng inspector

Inspector là một công cụ tuyệt vời giúp bạn khởi động server và tương tác với nó để kiểm tra hoạt động. Hãy khởi động nó:

> [!NOTE]
> Giao diện trong trường "command" có thể khác nhau vì nó chứa lệnh chạy server phù hợp với runtime cụ thể của bạn

Bạn sẽ thấy giao diện người dùng sau:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.vi.png)

1. Kết nối với server bằng cách chọn nút Connect  
   Khi đã kết nối, bạn sẽ thấy giao diện sau:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.vi.png)

2. Chọn "Tools" rồi "listTools", bạn sẽ thấy nút "Add" xuất hiện, chọn "Add" và điền các giá trị tham số.

   Bạn sẽ nhận được phản hồi như sau, tức là kết quả từ công cụ "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.vi.png)

Chúc mừng, bạn đã tạo và chạy thành công server đầu tiên của mình!

### SDK chính thức

MCP cung cấp SDK chính thức cho nhiều ngôn ngữ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Được duy trì cùng Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Được duy trì cùng Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai chính thức cho TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai chính thức cho Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai chính thức cho Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Được duy trì cùng Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai chính thức cho Rust

## Những điểm chính cần nhớ

- Việc thiết lập môi trường phát triển MCP rất đơn giản với các SDK theo ngôn ngữ
- Xây dựng server MCP bao gồm tạo và đăng ký các công cụ với schema rõ ràng
- Kiểm tra và gỡ lỗi rất quan trọng để đảm bảo triển khai MCP đáng tin cậy

## Mẫu

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Bài tập

Tạo một server MCP đơn giản với một công cụ bạn chọn:
1. Triển khai công cụ bằng ngôn ngữ bạn thích (.NET, Java, Python hoặc JavaScript).
2. Định nghĩa tham số đầu vào và giá trị trả về.
3. Chạy công cụ inspector để đảm bảo server hoạt động như mong đợi.
4. Kiểm tra triển khai với nhiều đầu vào khác nhau.

## Giải pháp

[Solution](./solution/README.md)

## Tài nguyên bổ sung

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Tiếp theo

Tiếp theo: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sai sót. Tài liệu gốc bằng ngôn ngữ gốc nên được xem là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.