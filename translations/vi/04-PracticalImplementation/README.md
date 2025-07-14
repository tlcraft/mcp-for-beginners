<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:18:58+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "vi"
}
-->
# Triển Khai Thực Tiễn

Triển khai thực tiễn là nơi sức mạnh của Model Context Protocol (MCP) trở nên rõ ràng. Mặc dù việc hiểu lý thuyết và kiến trúc đằng sau MCP rất quan trọng, giá trị thực sự xuất hiện khi bạn áp dụng những khái niệm này để xây dựng, kiểm thử và triển khai các giải pháp giải quyết các vấn đề thực tế. Chương này sẽ kết nối khoảng cách giữa kiến thức khái niệm và phát triển thực hành, hướng dẫn bạn qua quá trình đưa các ứng dụng dựa trên MCP vào cuộc sống.

Dù bạn đang phát triển trợ lý thông minh, tích hợp AI vào quy trình kinh doanh, hay xây dựng các công cụ tùy chỉnh để xử lý dữ liệu, MCP cung cấp một nền tảng linh hoạt. Thiết kế không phụ thuộc ngôn ngữ và các SDK chính thức cho các ngôn ngữ lập trình phổ biến giúp MCP dễ tiếp cận với nhiều nhà phát triển. Bằng cách tận dụng các SDK này, bạn có thể nhanh chóng tạo mẫu, lặp lại và mở rộng giải pháp trên nhiều nền tảng và môi trường khác nhau.

Trong các phần tiếp theo, bạn sẽ tìm thấy các ví dụ thực tế, mã mẫu và chiến lược triển khai minh họa cách triển khai MCP trong C#, Java, TypeScript, JavaScript và Python. Bạn cũng sẽ học cách gỡ lỗi và kiểm thử các máy chủ MCP, quản lý API và triển khai giải pháp lên đám mây bằng Azure. Những tài nguyên thực hành này được thiết kế để tăng tốc quá trình học tập và giúp bạn tự tin xây dựng các ứng dụng MCP mạnh mẽ, sẵn sàng cho môi trường sản xuất.

## Tổng Quan

Bài học này tập trung vào các khía cạnh thực tiễn của việc triển khai MCP trên nhiều ngôn ngữ lập trình. Chúng ta sẽ khám phá cách sử dụng các SDK MCP trong C#, Java, TypeScript, JavaScript và Python để xây dựng các ứng dụng vững chắc, gỡ lỗi và kiểm thử máy chủ MCP, cũng như tạo các tài nguyên, prompt và công cụ có thể tái sử dụng.

## Mục Tiêu Học Tập

Kết thúc bài học này, bạn sẽ có khả năng:
- Triển khai các giải pháp MCP sử dụng SDK chính thức trên nhiều ngôn ngữ lập trình
- Gỡ lỗi và kiểm thử máy chủ MCP một cách có hệ thống
- Tạo và sử dụng các tính năng máy chủ (Resources, Prompts và Tools)
- Thiết kế các workflow MCP hiệu quả cho các tác vụ phức tạp
- Tối ưu hóa triển khai MCP về hiệu suất và độ tin cậy

## Tài Nguyên SDK Chính Thức

Model Context Protocol cung cấp các SDK chính thức cho nhiều ngôn ngữ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Làm Việc Với MCP SDKs

Phần này cung cấp các ví dụ thực tế về triển khai MCP trên nhiều ngôn ngữ lập trình. Bạn có thể tìm thấy mã mẫu trong thư mục `samples` được tổ chức theo từng ngôn ngữ.

### Mẫu Có Sẵn

Kho lưu trữ bao gồm các [mẫu triển khai](../../../04-PracticalImplementation/samples) bằng các ngôn ngữ sau:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Mỗi mẫu minh họa các khái niệm và mẫu triển khai MCP chính cho ngôn ngữ và hệ sinh thái tương ứng.

## Các Tính Năng Cốt Lõi Của Máy Chủ

Máy chủ MCP có thể triển khai bất kỳ sự kết hợp nào của các tính năng sau:

### Resources
Resources cung cấp ngữ cảnh và dữ liệu để người dùng hoặc mô hình AI sử dụng:
- Kho tài liệu
- Cơ sở tri thức
- Nguồn dữ liệu có cấu trúc
- Hệ thống tập tin

### Prompts
Prompts là các mẫu tin nhắn và quy trình làm việc dành cho người dùng:
- Mẫu hội thoại được định nghĩa sẵn
- Các mẫu tương tác có hướng dẫn
- Cấu trúc đối thoại chuyên biệt

### Tools
Tools là các hàm mà mô hình AI có thể thực thi:
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

- Xây dựng [Máy chủ MCP đầu tiên của bạn](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Để xem các mẫu triển khai C# đầy đủ, hãy truy cập [kho mẫu SDK C# chính thức](https://github.com/modelcontextprotocol/csharp-sdk)

## Mẫu Triển Khai: Java

SDK Java cung cấp các tùy chọn triển khai MCP mạnh mẽ với các tính năng cấp doanh nghiệp.

### Tính Năng Chính

- Tích hợp Spring Framework
- An toàn kiểu dữ liệu cao
- Hỗ trợ lập trình phản ứng
- Xử lý lỗi toàn diện

Để xem mẫu triển khai Java đầy đủ, xem [Java sample](samples/java/containerapp/README.md) trong thư mục mẫu.

## Mẫu Triển Khai: JavaScript

SDK JavaScript cung cấp cách tiếp cận nhẹ và linh hoạt cho triển khai MCP.

### Tính Năng Chính

- Hỗ trợ Node.js và trình duyệt
- API dựa trên Promise
- Dễ dàng tích hợp với Express và các framework khác
- Hỗ trợ WebSocket cho streaming

Để xem mẫu triển khai JavaScript đầy đủ, xem [JavaScript sample](samples/javascript/README.md) trong thư mục mẫu.

## Mẫu Triển Khai: Python

SDK Python cung cấp cách tiếp cận Pythonic cho triển khai MCP với tích hợp xuất sắc các framework ML.

### Tính Năng Chính

- Hỗ trợ async/await với asyncio
- Tích hợp FastAPI
- Đăng ký công cụ đơn giản
- Tích hợp gốc với các thư viện ML phổ biến

Để xem mẫu triển khai Python đầy đủ, xem [Python sample](samples/python/README.md) trong thư mục mẫu.

## Quản Lý API

Azure API Management là giải pháp tuyệt vời để bảo mật các máy chủ MCP. Ý tưởng là đặt một instance Azure API Management trước máy chủ MCP của bạn và để nó xử lý các tính năng bạn có thể cần như:

- giới hạn tốc độ
- quản lý token
- giám sát
- cân bằng tải
- bảo mật

### Mẫu Azure

Dưới đây là một mẫu Azure thực hiện chính xác điều đó, tức là [tạo một máy chủ MCP và bảo mật nó bằng Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Xem cách luồng ủy quyền diễn ra trong hình dưới đây:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Trong hình trên, các bước sau diễn ra:

- Xác thực/Ủy quyền được thực hiện qua Microsoft Entra.
- Azure API Management hoạt động như một cổng và sử dụng các chính sách để điều hướng và quản lý lưu lượng.
- Azure Monitor ghi lại tất cả các yêu cầu để phân tích sau này.

#### Luồng ủy quyền

Hãy xem chi tiết hơn về luồng ủy quyền:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Đặc tả ủy quyền MCP

Tìm hiểu thêm về [đặc tả ủy quyền MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Triển Khai Máy Chủ MCP Từ Xa Lên Azure

Hãy thử triển khai mẫu mà chúng ta đã đề cập trước đó:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Đăng ký nhà cung cấp tài nguyên `Microsoft.App`.
    * Nếu bạn dùng Azure CLI, chạy `az provider register --namespace Microsoft.App --wait`.
    * Nếu bạn dùng Azure PowerShell, chạy `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Sau đó chạy `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` sau một thời gian để kiểm tra xem đăng ký đã hoàn tất chưa.

2. Chạy lệnh [azd](https://aka.ms/azd) này để cấp phát dịch vụ quản lý API, function app (có mã nguồn) và tất cả các tài nguyên Azure cần thiết khác

    ```shell
    azd up
    ```

    Lệnh này sẽ triển khai tất cả các tài nguyên đám mây trên Azure

### Kiểm thử máy chủ với MCP Inspector

1. Trong **cửa sổ terminal mới**, cài đặt và chạy MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Bạn sẽ thấy giao diện tương tự như:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. Nhấn CTRL và click để tải ứng dụng web MCP Inspector từ URL hiển thị bởi ứng dụng (ví dụ: http://127.0.0.1:6274/#resources)
1. Đặt loại giao thức truyền tải là `SSE`
1. Đặt URL đến endpoint SSE của API Management đang chạy được hiển thị sau khi chạy `azd up` và **Kết nối**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Liệt kê Tools**. Nhấn vào một công cụ và **Chạy Tool**.

Nếu tất cả các bước đều thành công, bạn sẽ kết nối được với máy chủ MCP và gọi được một công cụ.

## Máy Chủ MCP Cho Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bộ kho lưu trữ này là mẫu khởi đầu nhanh để xây dựng và triển khai các máy chủ MCP từ xa tùy chỉnh sử dụng Azure Functions với Python, C# .NET hoặc Node/TypeScript.

Các mẫu này cung cấp giải pháp hoàn chỉnh cho phép nhà phát triển:

- Xây dựng và chạy cục bộ: Phát triển và gỡ lỗi máy chủ MCP trên máy tính cá nhân
- Triển khai lên Azure: Dễ dàng triển khai lên đám mây chỉ với lệnh azd up đơn giản
- Kết nối từ các client: Kết nối tới máy chủ MCP từ nhiều client khác nhau bao gồm chế độ Copilot của VS Code và công cụ MCP Inspector

### Tính Năng Chính:

- Bảo mật theo thiết kế: Máy chủ MCP được bảo vệ bằng khóa và HTTPS
- Tùy chọn xác thực: Hỗ trợ OAuth sử dụng xác thực tích hợp sẵn và/hoặc API Management
- Cô lập mạng: Cho phép cô lập mạng bằng Azure Virtual Networks (VNET)
- Kiến trúc serverless: Tận dụng Azure Functions cho thực thi mở rộng, sự kiện kích hoạt
- Phát triển cục bộ: Hỗ trợ phát triển và gỡ lỗi toàn diện trên máy cá nhân
- Triển khai đơn giản: Quy trình triển khai lên Azure được tối giản

Kho lưu trữ bao gồm tất cả các file cấu hình cần thiết, mã nguồn và định nghĩa hạ tầng để bạn nhanh chóng bắt đầu với triển khai máy chủ MCP sẵn sàng cho môi trường sản xuất.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mẫu triển khai MCP sử dụng Azure Functions với Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mẫu triển khai MCP sử dụng Azure Functions với C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mẫu triển khai MCP sử dụng Azure Functions với Node/TypeScript.

## Những Điểm Chính Cần Nhớ

- SDK MCP cung cấp các công cụ theo ngôn ngữ để triển khai các giải pháp MCP vững chắc
- Quá trình gỡ lỗi và kiểm thử rất quan trọng để đảm bảo ứng dụng MCP đáng tin cậy
- Các mẫu prompt có thể tái sử dụng giúp tương tác AI nhất quán
- Các workflow được thiết kế tốt có thể điều phối các tác vụ phức tạp sử dụng nhiều công cụ
- Triển khai MCP cần cân nhắc về bảo mật, hiệu suất và xử lý lỗi

## Bài Tập

Thiết kế một workflow MCP thực tiễn giải quyết một vấn đề thực tế trong lĩnh vực của bạn:

1. Xác định 3-4 công cụ hữu ích để giải quyết vấn đề này
2. Tạo sơ đồ workflow thể hiện cách các công cụ này tương tác với nhau
3. Triển khai phiên bản cơ bản của một trong các công cụ bằng ngôn ngữ bạn ưa thích
4. Tạo mẫu prompt giúp mô hình sử dụng hiệu quả công cụ của bạn

## Tài Nguyên Bổ Sung


---

Tiếp theo: [Chủ Đề Nâng Cao](../05-AdvancedTopics/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.