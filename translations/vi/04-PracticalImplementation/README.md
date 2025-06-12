<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:20:24+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "vi"
}
-->
# Triển khai Thực tiễn

Triển khai thực tiễn là nơi sức mạnh của Model Context Protocol (MCP) trở nên rõ ràng. Trong khi việc hiểu lý thuyết và kiến trúc phía sau MCP rất quan trọng, giá trị thực sự xuất hiện khi bạn áp dụng những khái niệm này để xây dựng, kiểm thử và triển khai các giải pháp giải quyết các vấn đề thực tế. Chương này nối liền khoảng cách giữa kiến thức khái niệm và phát triển thực tế, hướng dẫn bạn qua quá trình đưa các ứng dụng dựa trên MCP vào cuộc sống.

Dù bạn đang phát triển trợ lý thông minh, tích hợp AI vào quy trình kinh doanh, hay xây dựng công cụ tùy chỉnh cho xử lý dữ liệu, MCP cung cấp nền tảng linh hoạt. Thiết kế không phụ thuộc ngôn ngữ và các SDK chính thức cho các ngôn ngữ lập trình phổ biến giúp MCP dễ tiếp cận với nhiều nhà phát triển. Bằng cách tận dụng các SDK này, bạn có thể nhanh chóng tạo mẫu, lặp lại và mở rộng giải pháp trên nhiều nền tảng và môi trường khác nhau.

Trong các phần tiếp theo, bạn sẽ tìm thấy các ví dụ thực tế, mã mẫu và chiến lược triển khai minh họa cách triển khai MCP trong C#, Java, TypeScript, JavaScript và Python. Bạn cũng sẽ học cách gỡ lỗi và kiểm thử các máy chủ MCP, quản lý API, và triển khai giải pháp lên đám mây sử dụng Azure. Những tài nguyên thực hành này được thiết kế để tăng tốc quá trình học tập và giúp bạn tự tin xây dựng các ứng dụng MCP vững chắc, sẵn sàng cho môi trường sản xuất.

## Tổng quan

Bài học này tập trung vào các khía cạnh thực tế của việc triển khai MCP trên nhiều ngôn ngữ lập trình. Chúng ta sẽ khám phá cách sử dụng các SDK MCP trong C#, Java, TypeScript, JavaScript và Python để xây dựng ứng dụng vững chắc, gỡ lỗi và kiểm thử máy chủ MCP, cũng như tạo các tài nguyên, prompt và công cụ có thể tái sử dụng.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:
- Triển khai các giải pháp MCP sử dụng SDK chính thức trong nhiều ngôn ngữ lập trình
- Gỡ lỗi và kiểm thử máy chủ MCP một cách hệ thống
- Tạo và sử dụng các tính năng của máy chủ (Resources, Prompts, và Tools)
- Thiết kế các workflow MCP hiệu quả cho các tác vụ phức tạp
- Tối ưu hóa triển khai MCP về hiệu suất và độ tin cậy

## Tài nguyên SDK chính thức

Model Context Protocol cung cấp các SDK chính thức cho nhiều ngôn ngữ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Làm việc với các SDK MCP

Phần này cung cấp các ví dụ thực tế về triển khai MCP trên nhiều ngôn ngữ lập trình. Bạn có thể tìm mã mẫu trong thư mục `samples` được tổ chức theo ngôn ngữ.

### Các mẫu có sẵn

Kho lưu trữ bao gồm các triển khai mẫu trong các ngôn ngữ sau:

- C#
- Java
- TypeScript
- JavaScript
- Python

Mỗi mẫu minh họa các khái niệm MCP chính và các mẫu triển khai cho ngôn ngữ và hệ sinh thái cụ thể đó.

## Các tính năng chính của máy chủ

Máy chủ MCP có thể triển khai bất kỳ kết hợp nào của các tính năng sau:

### Resources
Resources cung cấp ngữ cảnh và dữ liệu để người dùng hoặc mô hình AI sử dụng:
- Kho tài liệu
- Cơ sở tri thức
- Nguồn dữ liệu có cấu trúc
- Hệ thống tập tin

### Prompts
Prompts là các thông điệp mẫu và workflow dành cho người dùng:
- Mẫu hội thoại được định nghĩa trước
- Các mẫu tương tác có hướng dẫn
- Cấu trúc đối thoại chuyên biệt

### Tools
Tools là các hàm để mô hình AI thực thi:
- Tiện ích xử lý dữ liệu
- Tích hợp API bên ngoài
- Khả năng tính toán
- Chức năng tìm kiếm

## Ví dụ triển khai: C#

Kho SDK C# chính thức chứa nhiều ví dụ triển khai minh họa các khía cạnh khác nhau của MCP:

- **Basic MCP Client**: Ví dụ đơn giản cho thấy cách tạo client MCP và gọi các tool
- **Basic MCP Server**: Triển khai máy chủ tối giản với đăng ký tool cơ bản
- **Advanced MCP Server**: Máy chủ đầy đủ tính năng với đăng ký tool, xác thực và xử lý lỗi
- **ASP.NET Integration**: Ví dụ minh họa tích hợp với ASP.NET Core
- **Tool Implementation Patterns**: Các mẫu khác nhau để triển khai tool với mức độ phức tạp khác nhau

SDK C# MCP đang trong giai đoạn xem trước và API có thể thay đổi. Chúng tôi sẽ liên tục cập nhật blog này khi SDK phát triển.

### Tính năng chính
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Xây dựng [máy chủ MCP đầu tiên](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Để xem các mẫu triển khai C# đầy đủ, hãy truy cập kho [mẫu SDK C# chính thức](https://github.com/modelcontextprotocol/csharp-sdk)

## Ví dụ triển khai: Java

SDK Java cung cấp các tùy chọn triển khai MCP mạnh mẽ với các tính năng cấp doanh nghiệp.

### Tính năng chính

- Tích hợp Spring Framework
- Kiểm soát kiểu mạnh mẽ
- Hỗ trợ lập trình phản ứng (Reactive)
- Xử lý lỗi toàn diện

Để xem mẫu triển khai Java đầy đủ, xem [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) trong thư mục samples.

## Ví dụ triển khai: JavaScript

SDK JavaScript cung cấp cách tiếp cận nhẹ và linh hoạt cho triển khai MCP.

### Tính năng chính

- Hỗ trợ Node.js và trình duyệt
- API dựa trên Promise
- Dễ dàng tích hợp với Express và các framework khác
- Hỗ trợ WebSocket cho streaming

Để xem mẫu triển khai JavaScript đầy đủ, xem [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) trong thư mục samples.

## Ví dụ triển khai: Python

SDK Python cung cấp cách tiếp cận Pythonic cho triển khai MCP với tích hợp tuyệt vời cho các framework ML.

### Tính năng chính

- Hỗ trợ async/await với asyncio
- Tích hợp Flask và FastAPI
- Đăng ký tool đơn giản
- Tích hợp native với các thư viện ML phổ biến

Để xem mẫu triển khai Python đầy đủ, xem [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) trong thư mục samples.

## Quản lý API

Azure API Management là giải pháp tuyệt vời để bảo vệ các máy chủ MCP. Ý tưởng là đặt một instance Azure API Management phía trước máy chủ MCP của bạn và để nó xử lý các tính năng bạn có thể cần như:

- giới hạn tốc độ (rate limiting)
- quản lý token
- giám sát
- cân bằng tải
- bảo mật

### Ví dụ Azure

Dưới đây là ví dụ Azure thực hiện chính xác điều đó, tức là [tạo máy chủ MCP và bảo vệ nó bằng Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Xem cách luồng ủy quyền diễn ra trong hình dưới đây:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Trong hình trên, các bước sau diễn ra:

- Xác thực/Ủy quyền sử dụng Microsoft Entra.
- Azure API Management hoạt động như một cổng và sử dụng các chính sách để điều hướng và quản lý lưu lượng.
- Azure Monitor ghi lại tất cả các yêu cầu để phân tích sau này.

#### Luồng ủy quyền

Hãy xem chi tiết hơn về luồng ủy quyền:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Đặc tả ủy quyền MCP

Tìm hiểu thêm về [Đặc tả ủy quyền MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Triển khai máy chủ MCP từ xa lên Azure

Hãy xem liệu chúng ta có thể triển khai mẫu đã đề cập trước đó không:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Đăng ký `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` sau một thời gian để kiểm tra đăng ký đã hoàn tất.

3. Chạy lệnh [azd](https://aka.ms/azd) này để cấp phát dịch vụ quản lý API, function app (với mã nguồn) và tất cả các tài nguyên Azure cần thiết khác

    ```shell
    azd up
    ```

    Lệnh này sẽ triển khai tất cả tài nguyên đám mây trên Azure

### Kiểm thử máy chủ với MCP Inspector

1. Trong **cửa sổ terminal mới**, cài đặt và chạy MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Bạn sẽ thấy giao diện tương tự như:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.vi.png)

2. CTRL click để tải ứng dụng web MCP Inspector từ URL hiển thị bởi ứng dụng (ví dụ: http://127.0.0.1:6274/#resources)
3. Đặt loại giao thức truyền tải thành `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` và **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Liệt kê Tools**. Nhấp vào một tool và **Run Tool**.

Nếu tất cả các bước thành công, bạn sẽ được kết nối với máy chủ MCP và có thể gọi một tool.

## Máy chủ MCP cho Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bộ kho lưu trữ này là mẫu khởi đầu nhanh để xây dựng và triển khai máy chủ MCP tùy chỉnh từ xa sử dụng Azure Functions với Python, C# .NET hoặc Node/TypeScript.

Các mẫu cung cấp giải pháp hoàn chỉnh cho phép nhà phát triển:

- Xây dựng và chạy cục bộ: Phát triển và gỡ lỗi máy chủ MCP trên máy cục bộ
- Triển khai lên Azure: Dễ dàng triển khai lên đám mây với lệnh azd up đơn giản
- Kết nối từ các client: Kết nối đến máy chủ MCP từ nhiều client khác nhau bao gồm chế độ Copilot của VS Code và công cụ MCP Inspector

### Tính năng chính:

- Bảo mật theo thiết kế: Máy chủ MCP được bảo vệ bằng khóa và HTTPS
- Tùy chọn xác thực: Hỗ trợ OAuth qua xác thực tích hợp sẵn và/hoặc API Management
- Cô lập mạng: Cho phép cô lập mạng bằng Azure Virtual Networks (VNET)
- Kiến trúc serverless: Tận dụng Azure Functions để thực thi theo sự kiện, có khả năng mở rộng
- Phát triển cục bộ: Hỗ trợ phát triển và gỡ lỗi toàn diện tại chỗ
- Triển khai đơn giản: Quy trình triển khai lên Azure được đơn giản hóa

Kho lưu trữ bao gồm tất cả các file cấu hình cần thiết, mã nguồn và định nghĩa hạ tầng để bạn nhanh chóng bắt đầu với triển khai máy chủ MCP sẵn sàng cho sản xuất.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mẫu triển khai MCP sử dụng Azure Functions với Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mẫu triển khai MCP sử dụng Azure Functions với C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mẫu triển khai MCP sử dụng Azure Functions với Node/TypeScript.

## Những điểm chính cần nhớ

- SDK MCP cung cấp các công cụ đặc thù cho từng ngôn ngữ để triển khai giải pháp MCP vững chắc
- Quá trình gỡ lỗi và kiểm thử rất quan trọng để đảm bảo ứng dụng MCP đáng tin cậy
- Các mẫu prompt có thể tái sử dụng giúp tương tác AI nhất quán
- Workflow được thiết kế tốt có thể điều phối các tác vụ phức tạp sử dụng nhiều tool
- Triển khai giải pháp MCP cần xem xét bảo mật, hiệu suất và xử lý lỗi

## Bài tập

Thiết kế một workflow MCP thực tế giải quyết một vấn đề thực tế trong lĩnh vực của bạn:

1. Xác định 3-4 tool hữu ích để giải quyết vấn đề này
2. Tạo sơ đồ workflow thể hiện cách các tool này tương tác
3. Triển khai phiên bản cơ bản của một trong các tool bằng ngôn ngữ bạn chọn
4. Tạo một mẫu prompt giúp mô hình sử dụng tool của bạn hiệu quả

## Tài nguyên bổ sung


---

Tiếp theo: [Advanced Topics](../05-AdvancedTopics/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn chính xác và đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm đối với bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.