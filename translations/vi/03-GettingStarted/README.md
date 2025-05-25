<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:12:40+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "vi"
}
-->
## Bắt đầu  

Phần này bao gồm một số bài học:

- **-1- Máy chủ đầu tiên của bạn**, trong bài học đầu tiên này, bạn sẽ học cách tạo máy chủ đầu tiên của mình và kiểm tra nó bằng công cụ kiểm tra, một cách quý giá để thử nghiệm và gỡ lỗi máy chủ của bạn, [đến bài học](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, trong bài học này, bạn sẽ học cách viết một client có thể kết nối với máy chủ của bạn, [đến bài học](/03-GettingStarted/02-client/README.md)

- **-3- Client với LLM**, một cách viết client tốt hơn nữa là thêm LLM vào để nó có thể "thương lượng" với máy chủ của bạn về những việc cần làm, [đến bài học](/03-GettingStarted/03-llm-client/README.md)

- **-4- Tiêu thụ chế độ Agent của GitHub Copilot trên máy chủ trong Visual Studio Code**. Tại đây, chúng ta sẽ xem xét cách chạy máy chủ MCP của mình từ trong Visual Studio Code, [đến bài học](/03-GettingStarted/04-vscode/README.md)

- **-5- Tiêu thụ từ SSE (Server Sent Events)** SSE là tiêu chuẩn cho streaming từ máy chủ đến client, cho phép máy chủ đẩy cập nhật theo thời gian thực tới client qua HTTP [đến bài học](/03-GettingStarted/05-sse-server/README.md)

- **-6- Sử dụng AI Toolkit cho VSCode** để tiêu thụ và thử nghiệm các client và máy chủ MCP của bạn [đến bài học](/03-GettingStarted/06-aitk/README.md)

- **-7 Thử nghiệm**. Tại đây chúng ta sẽ tập trung đặc biệt vào cách chúng ta có thể thử nghiệm máy chủ và client của mình theo nhiều cách khác nhau, [đến bài học](/03-GettingStarted/07-testing/README.md)

- **-8- Triển khai**. Chương này sẽ xem xét các cách khác nhau để triển khai các giải pháp MCP của bạn, [đến bài học](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) là một giao thức mở tiêu chuẩn hóa cách ứng dụng cung cấp ngữ cảnh cho LLMs. Hãy nghĩ MCP như cổng USB-C cho các ứng dụng AI - nó cung cấp một cách tiêu chuẩn để kết nối các mô hình AI với các nguồn dữ liệu và công cụ khác nhau.

## Mục tiêu học tập

Sau khi hoàn thành bài học này, bạn sẽ có thể:

- Thiết lập môi trường phát triển cho MCP trong C#, Java, Python, TypeScript và JavaScript
- Xây dựng và triển khai máy chủ MCP cơ bản với các tính năng tùy chỉnh (tài nguyên, prompts và công cụ)
- Tạo ứng dụng host kết nối với máy chủ MCP
- Thử nghiệm và gỡ lỗi các triển khai MCP
- Hiểu các thách thức thiết lập phổ biến và giải pháp của chúng
- Kết nối các triển khai MCP của bạn với các dịch vụ LLM phổ biến

## Thiết lập môi trường MCP của bạn

Trước khi bắt đầu làm việc với MCP, điều quan trọng là phải chuẩn bị môi trường phát triển của bạn và hiểu quy trình làm việc cơ bản. Phần này sẽ hướng dẫn bạn qua các bước thiết lập ban đầu để đảm bảo bắt đầu thuận lợi với MCP.

### Yêu cầu tiên quyết

Trước khi bắt đầu phát triển MCP, hãy đảm bảo bạn có:

- **Môi trường phát triển**: Cho ngôn ngữ bạn chọn (C#, Java, Python, TypeScript hoặc JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, hoặc bất kỳ trình soạn thảo mã hiện đại nào
- **Trình quản lý gói**: NuGet, Maven/Gradle, pip, hoặc npm/yarn
- **API Keys**: Cho bất kỳ dịch vụ AI nào bạn dự định sử dụng trong ứng dụng host của mình


### SDK chính thức

Trong các chương sắp tới, bạn sẽ thấy các giải pháp được xây dựng bằng Python, TypeScript, Java và .NET. Dưới đây là tất cả các SDK được hỗ trợ chính thức.

MCP cung cấp các SDK chính thức cho nhiều ngôn ngữ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Được duy trì cùng với Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Được duy trì cùng với Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai TypeScript chính thức
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai Python chính thức
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai Kotlin chính thức
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Được duy trì cùng với Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai Rust chính thức

## Điểm chính cần nhớ

- Thiết lập môi trường phát triển MCP dễ dàng với các SDK theo ngôn ngữ
- Xây dựng máy chủ MCP liên quan đến việc tạo và đăng ký công cụ với các schema rõ ràng
- Các client MCP kết nối với máy chủ và mô hình để tận dụng các khả năng mở rộng
- Thử nghiệm và gỡ lỗi là cần thiết cho các triển khai MCP đáng tin cậy
- Các tùy chọn triển khai từ phát triển cục bộ đến các giải pháp dựa trên đám mây

## Thực hành

Chúng tôi có một bộ mẫu bổ sung cho các bài tập bạn sẽ thấy trong tất cả các chương trong phần này. Ngoài ra mỗi chương cũng có bài tập và bài tập riêng

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

- [Kho lưu trữ GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## Tiếp theo

Tiếp theo: [Tạo máy chủ MCP đầu tiên của bạn](/03-GettingStarted/01-first-server/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.