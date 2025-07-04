<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:04:27+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "vi"
}
-->
## Bắt Đầu  

Phần này bao gồm một số bài học:

- **1 Máy chủ đầu tiên của bạn**, trong bài học đầu tiên này, bạn sẽ học cách tạo máy chủ đầu tiên và kiểm tra nó bằng công cụ inspector, một cách hữu ích để thử nghiệm và gỡ lỗi máy chủ, [đến bài học](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, trong bài học này, bạn sẽ học cách viết một client có thể kết nối với máy chủ của bạn, [đến bài học](/03-GettingStarted/02-client/README.md)

- **3 Client với LLM**, một cách viết client tốt hơn là thêm LLM vào để nó có thể "thương lượng" với máy chủ về những việc cần làm, [đến bài học](/03-GettingStarted/03-llm-client/README.md)

- **4 Sử dụng chế độ GitHub Copilot Agent của máy chủ trong Visual Studio Code**. Ở đây, chúng ta sẽ xem cách chạy MCP Server từ bên trong Visual Studio Code, [đến bài học](/03-GettingStarted/04-vscode/README.md)

- **5 Sử dụng SSE (Server Sent Events)** SSE là một chuẩn cho việc truyền dữ liệu từ server đến client, cho phép server đẩy các cập nhật thời gian thực đến client qua HTTP [đến bài học](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming với MCP (Streamable HTTP)**. Tìm hiểu về streaming HTTP hiện đại, thông báo tiến trình, và cách triển khai các máy chủ và client MCP có khả năng mở rộng, thời gian thực sử dụng Streamable HTTP. [đến bài học](/03-GettingStarted/06-http-streaming/README.md)

- **7 Sử dụng AI Toolkit cho VSCode** để sử dụng và kiểm thử MCP Clients và Servers của bạn [đến bài học](/03-GettingStarted/07-aitk/README.md)

- **8 Kiểm thử**. Ở đây chúng ta sẽ tập trung đặc biệt vào cách kiểm thử máy chủ và client theo nhiều cách khác nhau, [đến bài học](/03-GettingStarted/08-testing/README.md)

- **9 Triển khai**. Chương này sẽ xem xét các cách khác nhau để triển khai các giải pháp MCP của bạn, [đến bài học](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) là một giao thức mở chuẩn hóa cách các ứng dụng cung cấp ngữ cảnh cho LLMs. Hãy tưởng tượng MCP như một cổng USB-C cho các ứng dụng AI - nó cung cấp một cách chuẩn để kết nối các mô hình AI với các nguồn dữ liệu và công cụ khác nhau.

## Mục Tiêu Học Tập

Kết thúc bài học này, bạn sẽ có thể:

- Thiết lập môi trường phát triển cho MCP bằng C#, Java, Python, TypeScript và JavaScript
- Xây dựng và triển khai các máy chủ MCP cơ bản với các tính năng tùy chỉnh (tài nguyên, prompts, và công cụ)
- Tạo các ứng dụng host kết nối với máy chủ MCP
- Kiểm thử và gỡ lỗi các triển khai MCP
- Hiểu các thách thức phổ biến khi thiết lập và cách giải quyết
- Kết nối các triển khai MCP của bạn với các dịch vụ LLM phổ biến

## Thiết Lập Môi Trường MCP

Trước khi bắt đầu làm việc với MCP, bạn cần chuẩn bị môi trường phát triển và hiểu quy trình làm việc cơ bản. Phần này sẽ hướng dẫn bạn các bước thiết lập ban đầu để khởi đầu thuận lợi với MCP.

### Yêu Cầu Tiền Đề

Trước khi bắt đầu phát triển MCP, hãy đảm bảo bạn có:

- **Môi trường phát triển**: Cho ngôn ngữ bạn chọn (C#, Java, Python, TypeScript hoặc JavaScript)
- **IDE/Trình soạn thảo**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm hoặc bất kỳ trình soạn thảo mã hiện đại nào
- **Trình quản lý gói**: NuGet, Maven/Gradle, pip hoặc npm/yarn
- **API Keys**: Cho bất kỳ dịch vụ AI nào bạn dự định sử dụng trong ứng dụng host của mình


### SDK Chính Thức

Trong các chương tiếp theo, bạn sẽ thấy các giải pháp được xây dựng bằng Python, TypeScript, Java và .NET. Dưới đây là tất cả các SDK được hỗ trợ chính thức.

MCP cung cấp SDK chính thức cho nhiều ngôn ngữ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Được duy trì phối hợp với Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Được duy trì phối hợp với Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai TypeScript chính thức
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai Python chính thức
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai Kotlin chính thức
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Được duy trì phối hợp với Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai Rust chính thức

## Những Điểm Chính

- Thiết lập môi trường phát triển MCP khá đơn giản với các SDK theo ngôn ngữ
- Xây dựng máy chủ MCP bao gồm tạo và đăng ký các công cụ với schema rõ ràng
- Client MCP kết nối với máy chủ và mô hình để tận dụng các khả năng mở rộng
- Kiểm thử và gỡ lỗi là rất quan trọng để có triển khai MCP đáng tin cậy
- Các lựa chọn triển khai đa dạng từ phát triển cục bộ đến giải pháp đám mây

## Thực Hành

Chúng tôi có một bộ mẫu bổ sung cho các bài tập bạn sẽ thấy trong tất cả các chương của phần này. Ngoài ra mỗi chương cũng có các bài tập và nhiệm vụ riêng.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Tài Nguyên Bổ Sung

- [Xây dựng Agents sử dụng Model Context Protocol trên Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP từ xa với Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Tiếp Theo

Tiếp theo: [Tạo MCP Server đầu tiên của bạn](./01-first-server/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.