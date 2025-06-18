<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:20:40+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "vi"
}
-->
# Triển Khai Thực Tiễn

Triển khai thực tiễn là nơi sức mạnh của Model Context Protocol (MCP) trở nên rõ ràng. Trong khi việc hiểu lý thuyết và kiến trúc đằng sau MCP rất quan trọng, giá trị thực sự xuất hiện khi bạn áp dụng những khái niệm này để xây dựng, kiểm thử và triển khai các giải pháp giải quyết các vấn đề trong thế giới thực. Chương này kết nối khoảng cách giữa kiến thức khái niệm và phát triển thực hành, hướng dẫn bạn qua quá trình biến các ứng dụng dựa trên MCP thành hiện thực.

Dù bạn đang phát triển trợ lý thông minh, tích hợp AI vào quy trình kinh doanh, hay xây dựng các công cụ tùy chỉnh cho xử lý dữ liệu, MCP cung cấp một nền tảng linh hoạt. Thiết kế không phụ thuộc ngôn ngữ và các SDK chính thức cho các ngôn ngữ lập trình phổ biến giúp MCP dễ tiếp cận với nhiều nhà phát triển. Bằng cách tận dụng các SDK này, bạn có thể nhanh chóng tạo mẫu, lặp lại và mở rộng các giải pháp trên nhiều nền tảng và môi trường khác nhau.

Trong các phần tiếp theo, bạn sẽ tìm thấy các ví dụ thực tế, mã mẫu và chiến lược triển khai minh họa cách thực hiện MCP trong C#, Java, TypeScript, JavaScript và Python. Bạn cũng sẽ học cách gỡ lỗi và kiểm thử các máy chủ MCP, quản lý API, và triển khai giải pháp lên đám mây bằng Azure. Những tài nguyên thực hành này được thiết kế để tăng tốc quá trình học tập và giúp bạn tự tin xây dựng các ứng dụng MCP mạnh mẽ, sẵn sàng cho môi trường sản xuất.

## Tổng Quan

Bài học này tập trung vào các khía cạnh thực tiễn của việc triển khai MCP trên nhiều ngôn ngữ lập trình. Chúng ta sẽ khám phá cách sử dụng MCP SDK trong C#, Java, TypeScript, JavaScript và Python để xây dựng các ứng dụng bền vững, gỡ lỗi và kiểm thử máy chủ MCP, cũng như tạo các tài nguyên, prompt và công cụ có thể tái sử dụng.

## Mục Tiêu Học Tập

Sau bài học này, bạn sẽ có khả năng:
- Triển khai các giải pháp MCP sử dụng SDK chính thức trong nhiều ngôn ngữ lập trình
- Gỡ lỗi và kiểm thử máy chủ MCP một cách có hệ thống
- Tạo và sử dụng các tính năng máy chủ (Resources, Prompts và Tools)
- Thiết kế các workflow MCP hiệu quả cho các nhiệm vụ phức tạp
- Tối ưu hóa triển khai MCP về hiệu suất và độ tin cậy

## Tài Nguyên SDK Chính Thức

Model Context Protocol cung cấp các SDK chính thức cho nhiều ngôn ngữ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Làm Việc Với MCP SDK

Phần này cung cấp các ví dụ thực tế về triển khai MCP trên nhiều ngôn ngữ lập trình. Bạn có thể tìm thấy mã mẫu trong thư mục `samples` được tổ chức theo từng ngôn ngữ.

### Mẫu Có Sẵn

Kho lưu trữ bao gồm các [mẫu triển khai](../../../04-PracticalImplementation/samples) với các ngôn ngữ sau:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Mỗi mẫu thể hiện các khái niệm chính và mô hình triển khai MCP cho ngôn ngữ và hệ sinh thái cụ thể đó.

## Các Tính Năng Cốt Lõi Của Máy Chủ

Máy chủ MCP có thể triển khai bất kỳ sự kết hợp nào của các tính năng sau:

### Resources
Resources cung cấp ngữ cảnh và dữ liệu cho người dùng hoặc mô hình AI sử dụng:
- Kho tài liệu
- Cơ sở tri thức
- Nguồn dữ liệu có cấu trúc
- Hệ thống tập tin

### Prompts
Prompts là các thông điệp và workflow được mẫu hóa dành cho người dùng:
- Mẫu hội thoại định sẵn
- Mẫu tương tác hướng dẫn
- Cấu trúc đối thoại chuyên biệt

### Tools
Tools là các chức năng để mô hình AI thực thi:
- Tiện ích xử lý dữ liệu
- Tích hợp API bên ngoài
- Khả năng tính toán
- Chức năng tìm kiếm

## Mẫu Triển Khai: C#

Kho SDK C# chính thức chứa nhiều mẫu triển khai minh họa các khía cạnh khác nhau của MCP:

- **Basic MCP Client**: Ví dụ đơn giản cho thấy cách tạo client MCP và gọi các công cụ
- **Basic MCP Server**: Triển khai máy chủ tối giản với đăng ký công cụ cơ bản
- **Advanced MCP Server**: Máy chủ đầy đủ tính năng với đăng ký công cụ, xác thực và xử lý lỗi
- **ASP.NET Integration**: Ví dụ minh họa tích hợp với ASP.NET Core
- **Tool Implementation Patterns**: Các mẫu khác nhau để triển khai công cụ với các mức độ phức tạp khác nhau

SDK MCP C# đang trong giai đoạn xem trước và API có thể thay đổi. Chúng tôi sẽ liên tục cập nhật blog này khi SDK phát triển.

### Tính Năng Chính
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Hướng dẫn xây dựng [máy chủ MCP đầu tiên của bạn](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Để xem các mẫu triển khai C# đầy đủ, hãy truy cập [kho mẫu SDK C# chính thức](https://github.com/modelcontextprotocol/csharp-sdk)

## Mẫu Triển Khai: Java

SDK Java cung cấp các tùy chọn triển khai MCP mạnh mẽ với các tính năng cấp doanh nghiệp.

### Tính Năng Chính

- Tích hợp Spring Framework
- An toàn kiểu mạnh mẽ
- Hỗ trợ lập trình phản ứng
- Xử lý lỗi toàn diện

Để xem mẫu triển khai Java đầy đủ, tham khảo [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) trong thư mục mẫu.

## Mẫu Triển Khai: JavaScript

SDK JavaScript cung cấp cách tiếp cận nhẹ và linh hoạt cho triển khai MCP.

### Tính Năng Chính

- Hỗ trợ Node.js và trình duyệt
- API dựa trên Promise
- Dễ dàng tích hợp với Express và các framework khác
- Hỗ trợ WebSocket cho streaming

Để xem mẫu triển khai JavaScript đầy đủ, tham khảo [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) trong thư mục mẫu.

## Mẫu Triển Khai: Python

SDK Python cung cấp cách tiếp cận Pythonic cho triển khai MCP với tích hợp xuất sắc với các framework ML.

### Tính Năng Chính

- Hỗ trợ async/await với asyncio
- Tích hợp Flask và FastAPI
- Đăng ký công cụ đơn giản
- Tích hợp gốc với các thư viện ML phổ biến

Để xem mẫu triển khai Python đầy đủ, tham khảo [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) trong thư mục mẫu.

## Quản Lý API

Azure API Management là giải pháp tuyệt vời để bảo mật các máy chủ MCP. Ý tưởng là đặt một instance Azure API Management trước máy chủ MCP của bạn và để nó xử lý các tính năng bạn thường cần như:

- giới hạn tốc độ
- quản lý token
- giám sát
- cân bằng tải
- bảo mật

### Mẫu Azure

Dưới đây là một mẫu Azure làm đúng điều đó, tức là [tạo một máy chủ MCP và bảo mật nó bằng Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Xem cách luồng xác thực diễn ra trong hình dưới đây:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Trong hình trên, các bước sau diễn ra:

- Xác thực/Xác nhận quyền được thực hiện qua Microsoft Entra.
- Azure API Management hoạt động như một cổng và sử dụng các chính sách để điều hướng và quản lý lưu lượng.
- Azure Monitor ghi lại tất cả các yêu cầu để phân tích thêm.

#### Luồng xác thực

Hãy xem chi tiết hơn về luồng xác thực:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Đặc tả xác thực MCP

Tìm hiểu thêm về [Đặc tả xác thực MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Triển Khai Máy Chủ MCP Từ Xa Lên Azure

Hãy thử triển khai mẫu mà chúng ta đã đề cập trước đó:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Đăng ký `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` sau một thời gian để kiểm tra xem việc đăng ký đã hoàn tất chưa.

3. Chạy lệnh [azd](https://aka.ms/azd) này để tạo dịch vụ quản lý API, function app (kèm mã nguồn) và tất cả các tài nguyên Azure cần thiết khác

    ```shell
    azd up
    ```

    Lệnh này sẽ triển khai tất cả tài nguyên đám mây trên Azure

### Kiểm thử máy chủ của bạn với MCP Inspector

1. Trong một **cửa sổ terminal mới**, cài đặt và chạy MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Bạn sẽ thấy giao diện tương tự như:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.vi.png)

2. CTRL click để tải ứng dụng web MCP Inspector từ URL được hiển thị bởi ứng dụng (ví dụ: http://127.0.0.1:6274/#resources)
3. Đặt loại truyền tải thành `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` và **Kết nối**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Liệt kê Công cụ**. Nhấp vào một công cụ và **Chạy Công cụ**.

Nếu tất cả các bước đều thành công, bạn sẽ được kết nối với máy chủ MCP và có thể gọi một công cụ.

## Máy Chủ MCP Cho Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bộ kho lưu trữ này là mẫu khởi đầu nhanh để xây dựng và triển khai các máy chủ MCP từ xa tùy chỉnh sử dụng Azure Functions với Python, C# .NET hoặc Node/TypeScript.

Các mẫu cung cấp giải pháp hoàn chỉnh cho phép nhà phát triển:

- Xây dựng và chạy cục bộ: Phát triển và gỡ lỗi máy chủ MCP trên máy tính cá nhân
- Triển khai lên Azure: Dễ dàng triển khai lên đám mây chỉ với một lệnh azd up đơn giản
- Kết nối từ các client: Kết nối tới máy chủ MCP từ nhiều client khác nhau bao gồm chế độ agent Copilot của VS Code và công cụ MCP Inspector

### Tính Năng Chính:

- Bảo mật theo thiết kế: Máy chủ MCP được bảo vệ bằng khóa và HTTPS
- Tùy chọn xác thực: Hỗ trợ OAuth sử dụng xác thực tích hợp và/hoặc API Management
- Cách ly mạng: Cho phép cách ly mạng bằng Azure Virtual Networks (VNET)
- Kiến trúc serverless: Tận dụng Azure Functions để thực thi theo sự kiện, có thể mở rộng
- Phát triển cục bộ: Hỗ trợ toàn diện cho phát triển và gỡ lỗi cục bộ
- Triển khai đơn giản: Quy trình triển khai lên Azure được tối giản

Kho lưu trữ bao gồm tất cả các file cấu hình cần thiết, mã nguồn và định nghĩa hạ tầng để bạn nhanh chóng bắt đầu với triển khai máy chủ MCP sẵn sàng cho môi trường sản xuất.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mẫu triển khai MCP sử dụng Azure Functions với Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mẫu triển khai MCP sử dụng Azure Functions với C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mẫu triển khai MCP sử dụng Azure Functions với Node/TypeScript.

## Những Điểm Chính Cần Nhớ

- MCP SDK cung cấp các công cụ theo ngôn ngữ để triển khai các giải pháp MCP bền vững
- Quá trình gỡ lỗi và kiểm thử rất quan trọng để đảm bảo ứng dụng MCP đáng tin cậy
- Các mẫu prompt tái sử dụng giúp tương tác AI nhất quán
- Workflow được thiết kế tốt có thể điều phối các tác vụ phức tạp sử dụng nhiều công cụ
- Triển khai MCP cần cân nhắc về bảo mật, hiệu suất và xử lý lỗi

## Bài Tập

Thiết kế một workflow MCP thực tế giải quyết một vấn đề trong lĩnh vực của bạn:

1. Xác định 3-4 công cụ hữu ích để giải quyết vấn đề này
2. Tạo sơ đồ workflow thể hiện cách các công cụ này tương tác
3. Triển khai phiên bản cơ bản của một trong các công cụ sử dụng ngôn ngữ bạn ưa thích
4. Tạo mẫu prompt giúp mô hình sử dụng công cụ của bạn một cách hiệu quả

## Tài Nguyên Bổ Sung


---

Tiếp theo: [Chủ Đề Nâng Cao](../05-AdvancedTopics/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sai sót. Tài liệu gốc bằng ngôn ngữ nguyên bản của nó nên được coi là nguồn chính xác và có thẩm quyền. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm đối với bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.