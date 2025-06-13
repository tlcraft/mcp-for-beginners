<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:26:45+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "vi"
}
-->
## Bắt đầu  

Phần này gồm nhiều bài học:

- **1 Máy chủ đầu tiên của bạn**, trong bài học đầu tiên này, bạn sẽ học cách tạo máy chủ đầu tiên và kiểm tra nó bằng công cụ inspector, một cách hữu ích để thử nghiệm và gỡ lỗi máy chủ của bạn, [đến bài học](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, trong bài học này, bạn sẽ học cách viết một client có thể kết nối với máy chủ của bạn, [đến bài học](/03-GettingStarted/02-client/README.md)

- **3 Client với LLM**, cách viết client tốt hơn là thêm một LLM để nó có thể "thương lượng" với máy chủ của bạn về những việc cần làm, [đến bài học](/03-GettingStarted/03-llm-client/README.md)

- **4 Sử dụng chế độ GitHub Copilot Agent của server trong Visual Studio Code**. Ở đây, chúng ta sẽ chạy MCP Server từ trong Visual Studio Code, [đến bài học](/03-GettingStarted/04-vscode/README.md)

- **5 Sử dụng SSE (Server Sent Events)** SSE là chuẩn để truyền dữ liệu từ server đến client theo thời gian thực, cho phép server gửi cập nhật đến client qua HTTP [đến bài học](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming với MCP (Streamable HTTP)**. Tìm hiểu về streaming HTTP hiện đại, thông báo tiến trình và cách triển khai các server và client MCP có khả năng mở rộng, thời gian thực bằng Streamable HTTP. [đến bài học](/03-GettingStarted/06-http-streaming/README.md)

- **7 Sử dụng AI Toolkit cho VSCode** để sử dụng và kiểm thử MCP Clients và Servers của bạn [đến bài học](/03-GettingStarted/07-aitk/README.md)

- **8 Kiểm thử**. Ở đây chúng ta sẽ tập trung vào các cách kiểm thử server và client, [đến bài học](/03-GettingStarted/08-testing/README.md)

- **9 Triển khai**. Chương này sẽ xem xét các cách khác nhau để triển khai giải pháp MCP của bạn, [đến bài học](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) là một giao thức mở chuẩn hóa cách các ứng dụng cung cấp ngữ cảnh cho LLMs. Hãy tưởng tượng MCP giống như cổng USB-C cho các ứng dụng AI - nó cung cấp một cách chuẩn để kết nối các mô hình AI với các nguồn dữ liệu và công cụ khác nhau.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Thiết lập môi trường phát triển MCP với C#, Java, Python, TypeScript và JavaScript
- Xây dựng và triển khai các server MCP cơ bản với các tính năng tùy chỉnh (tài nguyên, lời nhắc, và công cụ)
- Tạo các ứng dụng host kết nối với server MCP
- Kiểm thử và gỡ lỗi các triển khai MCP
- Hiểu các thách thức phổ biến khi thiết lập và cách giải quyết
- Kết nối các triển khai MCP với các dịch vụ LLM phổ biến

## Thiết lập môi trường MCP của bạn

Trước khi bắt đầu làm việc với MCP, bạn cần chuẩn bị môi trường phát triển và hiểu quy trình làm việc cơ bản. Phần này sẽ hướng dẫn bạn các bước thiết lập ban đầu để khởi đầu suôn sẻ với MCP.

### Yêu cầu trước

Trước khi bắt đầu phát triển MCP, hãy đảm bảo bạn có:

- **Môi trường phát triển**: Cho ngôn ngữ bạn chọn (C#, Java, Python, TypeScript, hoặc JavaScript)
- **IDE/Trình soạn thảo**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm hoặc bất kỳ trình soạn thảo mã hiện đại nào
- **Trình quản lý gói**: NuGet, Maven/Gradle, pip, hoặc npm/yarn
- **API Keys**: Cho bất kỳ dịch vụ AI nào bạn dự định sử dụng trong ứng dụng host của mình


### SDK chính thức

Trong các chương tới, bạn sẽ thấy các giải pháp được xây dựng bằng Python, TypeScript, Java và .NET. Dưới đây là tất cả các SDK được hỗ trợ chính thức.

MCP cung cấp SDK chính thức cho nhiều ngôn ngữ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Duy trì phối hợp với Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Duy trì phối hợp với Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai TypeScript chính thức
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai Python chính thức
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai Kotlin chính thức
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Duy trì phối hợp với Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai Rust chính thức

## Những điểm chính cần nhớ

- Thiết lập môi trường phát triển MCP khá đơn giản với các SDK dành riêng cho từng ngôn ngữ
- Xây dựng server MCP bao gồm tạo và đăng ký các công cụ với các schema rõ ràng
- MCP clients kết nối với server và các mô hình để tận dụng các khả năng mở rộng
- Kiểm thử và gỡ lỗi rất quan trọng để đảm bảo triển khai MCP tin cậy
- Có nhiều lựa chọn triển khai từ phát triển cục bộ đến giải pháp trên đám mây

## Thực hành

Chúng tôi có một bộ mẫu bổ sung cho các bài tập bạn sẽ gặp trong tất cả các chương trong phần này. Ngoài ra, mỗi chương cũng có bài tập và nhiệm vụ riêng.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Tiếp theo

Tiếp theo: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**Tuyên bố miễn trách**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn tham khảo chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm đối với bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.