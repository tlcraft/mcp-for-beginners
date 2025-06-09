<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:39:32+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "vi"
}
-->
## Bắt đầu  

Phần này gồm nhiều bài học:

- **-1- Server đầu tiên của bạn**, trong bài học đầu tiên này, bạn sẽ học cách tạo server đầu tiên và kiểm tra nó bằng công cụ inspector, một cách hữu ích để thử nghiệm và gỡ lỗi server của bạn, [đến bài học](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, trong bài học này, bạn sẽ học cách viết một client có thể kết nối tới server của bạn, [đến bài học](/03-GettingStarted/02-client/README.md)

- **-3- Client với LLM**, cách viết client tốt hơn là thêm LLM vào để nó có thể "thương lượng" với server của bạn về việc cần làm, [đến bài học](/03-GettingStarted/03-llm-client/README.md)

- **-4- Sử dụng chế độ GitHub Copilot Agent của server trong Visual Studio Code**. Ở đây, chúng ta sẽ xem cách chạy MCP Server từ bên trong Visual Studio Code, [đến bài học](/03-GettingStarted/04-vscode/README.md)

- **-5- Tiêu thụ từ SSE (Server Sent Events)** SSE là chuẩn cho việc truyền dữ liệu thời gian thực từ server đến client, cho phép server gửi cập nhật liên tục qua HTTP [đến bài học](/03-GettingStarted/05-sse-server/README.md)

- **-6- Sử dụng AI Toolkit cho VSCode** để tiêu thụ và kiểm thử MCP Clients và Servers của bạn [đến bài học](/03-GettingStarted/06-aitk/README.md)

- **-7 Kiểm thử**. Ở đây chúng ta sẽ tập trung vào các cách kiểm thử server và client của bạn, [đến bài học](/03-GettingStarted/07-testing/README.md)

- **-8- Triển khai**. Chương này sẽ xem xét các cách khác nhau để triển khai giải pháp MCP của bạn, [đến bài học](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) là một giao thức mở chuẩn hóa cách các ứng dụng cung cấp ngữ cảnh cho LLMs. Hãy tưởng tượng MCP giống như cổng USB-C cho các ứng dụng AI - nó cung cấp một cách chuẩn để kết nối các mô hình AI với nhiều nguồn dữ liệu và công cụ khác nhau.

## Mục tiêu học tập

Kết thúc bài học này, bạn sẽ có khả năng:

- Thiết lập môi trường phát triển MCP cho C#, Java, Python, TypeScript và JavaScript
- Xây dựng và triển khai các server MCP cơ bản với các tính năng tùy chỉnh (tài nguyên, prompts và công cụ)
- Tạo ứng dụng host kết nối tới các server MCP
- Kiểm thử và gỡ lỗi các triển khai MCP
- Hiểu các thách thức phổ biến khi thiết lập và cách giải quyết
- Kết nối các triển khai MCP của bạn với các dịch vụ LLM phổ biến

## Thiết lập môi trường MCP của bạn

Trước khi bắt đầu làm việc với MCP, bạn cần chuẩn bị môi trường phát triển và hiểu quy trình làm việc cơ bản. Phần này sẽ hướng dẫn bạn các bước thiết lập ban đầu để khởi đầu thuận lợi với MCP.

### Yêu cầu trước

Trước khi bắt đầu phát triển MCP, hãy đảm bảo bạn có:

- **Môi trường phát triển**: cho ngôn ngữ bạn chọn (C#, Java, Python, TypeScript hoặc JavaScript)
- **IDE/Trình soạn thảo**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm hoặc bất kỳ trình soạn thảo mã hiện đại nào
- **Trình quản lý gói**: NuGet, Maven/Gradle, pip hoặc npm/yarn
- **API Keys**: cho bất kỳ dịch vụ AI nào bạn dự định sử dụng trong ứng dụng host


### SDK chính thức

Trong các chương tới, bạn sẽ thấy các giải pháp được xây dựng bằng Python, TypeScript, Java và .NET. Dưới đây là tất cả các SDK chính thức được hỗ trợ.

MCP cung cấp SDK chính thức cho nhiều ngôn ngữ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Bảo trì cùng Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Bảo trì cùng Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai chính thức cho TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai chính thức cho Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai chính thức cho Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Bảo trì cùng Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai chính thức cho Rust

## Những điểm chính cần nhớ

- Thiết lập môi trường phát triển MCP rất đơn giản với các SDK theo ngôn ngữ
- Xây dựng server MCP bao gồm tạo và đăng ký các công cụ với schema rõ ràng
- MCP client kết nối tới server và mô hình để tận dụng các khả năng mở rộng
- Kiểm thử và gỡ lỗi là rất cần thiết để đảm bảo triển khai MCP đáng tin cậy
- Các tùy chọn triển khai đa dạng từ phát triển cục bộ đến giải pháp trên đám mây

## Thực hành

Chúng tôi có bộ mẫu bổ sung cho các bài tập bạn sẽ thấy trong tất cả các chương của phần này. Ngoài ra mỗi chương cũng có các bài tập và nhiệm vụ riêng.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

- [Xây dựng Agents sử dụng Model Context Protocol trên Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP với Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Tiếp theo

Tiếp theo: [Tạo MCP Server đầu tiên của bạn](/03-GettingStarted/01-first-server/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp bởi con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.