<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:56:35+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "vi"
}
-->
# Triển Khai Thực Tế

Triển khai thực tế là nơi sức mạnh của Giao Thức Ngữ Cảnh Mô Hình (MCP) trở nên hữu hình. Trong khi việc hiểu lý thuyết và kiến trúc đằng sau MCP là quan trọng, giá trị thực sự xuất hiện khi bạn áp dụng những khái niệm này để xây dựng, kiểm tra, và triển khai các giải pháp giải quyết các vấn đề thực tế. Chương này là cầu nối giữa kiến thức lý thuyết và phát triển thực hành, hướng dẫn bạn qua quá trình đưa các ứng dụng dựa trên MCP vào cuộc sống.

Dù bạn đang phát triển các trợ lý thông minh, tích hợp AI vào quy trình làm việc kinh doanh, hay xây dựng các công cụ tùy chỉnh cho xử lý dữ liệu, MCP cung cấp một nền tảng linh hoạt. Thiết kế không phụ thuộc ngôn ngữ và các SDK chính thức cho các ngôn ngữ lập trình phổ biến làm cho nó trở nên dễ tiếp cận với nhiều nhà phát triển. Bằng cách tận dụng những SDK này, bạn có thể nhanh chóng tạo mẫu, lặp lại, và mở rộng các giải pháp của mình trên các nền tảng và môi trường khác nhau.

Trong các phần sau, bạn sẽ tìm thấy các ví dụ thực tế, mã mẫu, và chiến lược triển khai minh họa cách thực hiện MCP trong C#, Java, TypeScript, JavaScript, và Python. Bạn cũng sẽ học cách gỡ lỗi và kiểm tra các máy chủ MCP của mình, quản lý API, và triển khai các giải pháp lên đám mây bằng Azure. Những tài nguyên thực hành này được thiết kế để tăng tốc độ học tập của bạn và giúp bạn tự tin xây dựng các ứng dụng MCP mạnh mẽ, sẵn sàng cho sản xuất.

## Tổng Quan

Bài học này tập trung vào các khía cạnh thực tế của việc triển khai MCP trên nhiều ngôn ngữ lập trình. Chúng ta sẽ khám phá cách sử dụng các SDK MCP trong C#, Java, TypeScript, JavaScript, và Python để xây dựng các ứng dụng mạnh mẽ, gỡ lỗi và kiểm tra các máy chủ MCP, và tạo ra các tài nguyên, mẫu và công cụ có thể tái sử dụng.

## Mục Tiêu Học Tập

Đến cuối bài học này, bạn sẽ có thể:
- Triển khai các giải pháp MCP sử dụng các SDK chính thức trong các ngôn ngữ lập trình khác nhau
- Gỡ lỗi và kiểm tra máy chủ MCP một cách có hệ thống
- Tạo và sử dụng các tính năng máy chủ (Tài Nguyên, Mẫu, và Công Cụ)
- Thiết kế các quy trình làm việc MCP hiệu quả cho các nhiệm vụ phức tạp
- Tối ưu hóa triển khai MCP cho hiệu suất và độ tin cậy

## Tài Nguyên SDK Chính Thức

Giao Thức Ngữ Cảnh Mô Hình cung cấp các SDK chính thức cho nhiều ngôn ngữ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Làm Việc Với SDK MCP

Phần này cung cấp các ví dụ thực tế về việc triển khai MCP trên nhiều ngôn ngữ lập trình. Bạn có thể tìm thấy mã mẫu trong thư mục `samples` được tổ chức theo ngôn ngữ.

### Các Mẫu Có Sẵn

Kho lưu trữ bao gồm các triển khai mẫu trong các ngôn ngữ sau:

- C#
- Java
- TypeScript
- JavaScript
- Python

Mỗi mẫu minh họa các khái niệm chính và mẫu triển khai MCP cho ngôn ngữ và hệ sinh thái cụ thể đó.

## Các Tính Năng Máy Chủ Cốt Lõi

Máy chủ MCP có thể triển khai bất kỳ sự kết hợp nào của các tính năng sau:

### Tài Nguyên
Tài nguyên cung cấp ngữ cảnh và dữ liệu cho người dùng hoặc mô hình AI sử dụng:
- Kho tài liệu
- Cơ sở kiến thức
- Nguồn dữ liệu có cấu trúc
- Hệ thống tệp

### Mẫu
Mẫu là các thông điệp và quy trình làm việc theo mẫu cho người dùng:
- Mẫu hội thoại được định nghĩa trước
- Mẫu tương tác có hướng dẫn
- Cấu trúc đối thoại chuyên biệt

### Công Cụ
Công cụ là các chức năng để mô hình AI thực thi:
- Tiện ích xử lý dữ liệu
- Tích hợp API bên ngoài
- Khả năng tính toán
- Chức năng tìm kiếm

## Triển Khai Mẫu: C#

Kho lưu trữ SDK C# chính thức chứa một số triển khai mẫu minh họa các khía cạnh khác nhau của MCP:

- **Khách Hàng MCP Cơ Bản**: Ví dụ đơn giản về cách tạo một khách hàng MCP và gọi các công cụ
- **Máy Chủ MCP Cơ Bản**: Triển khai máy chủ tối giản với đăng ký công cụ cơ bản
- **Máy Chủ MCP Nâng Cao**: Máy chủ đầy đủ tính năng với đăng ký công cụ, xác thực, và xử lý lỗi
- **Tích Hợp ASP.NET**: Các ví dụ minh họa tích hợp với ASP.NET Core
- **Mẫu Triển Khai Công Cụ**: Các mẫu khác nhau cho việc triển khai công cụ với các mức độ phức tạp khác nhau

SDK C# MCP đang ở giai đoạn xem trước và API có thể thay đổi. Chúng tôi sẽ liên tục cập nhật blog này khi SDK phát triển.

### Các Tính Năng Chính 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Xây dựng [máy chủ MCP đầu tiên của bạn](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Để xem đầy đủ các mẫu triển khai C#, hãy truy cập [kho mẫu SDK C# chính thức](https://github.com/modelcontextprotocol/csharp-sdk)

## Triển Khai Mẫu: Triển Khai Java

SDK Java cung cấp các tùy chọn triển khai MCP mạnh mẽ với các tính năng cấp doanh nghiệp.

### Các Tính Năng Chính

- Tích hợp Spring Framework
- An toàn kiểu mạnh
- Hỗ trợ lập trình phản ứng
- Xử lý lỗi toàn diện

Để xem mẫu triển khai Java hoàn chỉnh, hãy xem [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) trong thư mục mẫu.

## Triển Khai Mẫu: Triển Khai JavaScript

SDK JavaScript cung cấp một cách tiếp cận nhẹ và linh hoạt để triển khai MCP.

### Các Tính Năng Chính

- Hỗ trợ Node.js và trình duyệt
- API dựa trên Promise
- Dễ dàng tích hợp với Express và các framework khác
- Hỗ trợ WebSocket cho streaming

Để xem mẫu triển khai JavaScript hoàn chỉnh, hãy xem [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) trong thư mục mẫu.

## Triển Khai Mẫu: Triển Khai Python

SDK Python cung cấp một cách tiếp cận Pythonic để triển khai MCP với tích hợp tuyệt vời với các framework ML.

### Các Tính Năng Chính

- Hỗ trợ async/await với asyncio
- Tích hợp Flask và FastAPI
- Đăng ký công cụ đơn giản
- Tích hợp tự nhiên với các thư viện ML phổ biến

Để xem mẫu triển khai Python hoàn chỉnh, hãy xem [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) trong thư mục mẫu.

## Quản Lý API

Azure API Management là một câu trả lời tuyệt vời cho cách chúng ta có thể bảo mật các máy chủ MCP. Ý tưởng là đặt một instance Azure API Management trước máy chủ MCP của bạn và để nó xử lý các tính năng mà bạn có thể muốn như:

- giới hạn tốc độ
- quản lý token
- giám sát
- cân bằng tải
- bảo mật

### Mẫu Azure

Dưới đây là một Mẫu Azure làm chính xác điều đó, tức là [tạo một máy chủ MCP và bảo mật nó với Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Xem cách luồng ủy quyền xảy ra trong hình ảnh dưới đây:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Trong hình trên, các bước sau diễn ra:

- Xác thực/Ủy quyền diễn ra bằng cách sử dụng Microsoft Entra.
- Azure API Management hoạt động như một cổng và sử dụng các chính sách để điều hướng và quản lý lưu lượng.
- Azure Monitor ghi lại tất cả các yêu cầu để phân tích thêm.

#### Luồng Ủy Quyền

Hãy xem xét kỹ hơn luồng ủy quyền:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Đặc Tả Ủy Quyền MCP

Tìm hiểu thêm về [đặc tả Ủy quyền MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Triển Khai Máy Chủ MCP Từ Xa lên Azure

Hãy xem liệu chúng ta có thể triển khai mẫu mà chúng ta đã đề cập trước đó:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Đăng ký `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` sau một thời gian để kiểm tra xem việc đăng ký đã hoàn tất chưa.

2. Chạy lệnh [azd](https://aka.ms/azd) này để cung cấp dịch vụ quản lý api, ứng dụng chức năng (với mã) và tất cả các tài nguyên Azure cần thiết khác

    ```shell
    azd up
    ```

    Lệnh này nên triển khai tất cả các tài nguyên đám mây trên Azure

### Kiểm Tra Máy Chủ của Bạn với MCP Inspector

1. Trong một **cửa sổ terminal mới**, cài đặt và chạy MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Bạn nên thấy một giao diện tương tự như:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.vi.png)

1. CTRL nhấp để tải ứng dụng web MCP Inspector từ URL được hiển thị bởi ứng dụng (ví dụ: http://127.0.0.1:6274/#resources)
1. Đặt loại truyền tải thành `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` và **Kết Nối**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Liệt Kê Công Cụ**. Nhấp vào một công cụ và **Chạy Công Cụ**.  

Nếu tất cả các bước đã hoạt động, bạn nên kết nối với máy chủ MCP và bạn đã có thể gọi một công cụ.

## Máy Chủ MCP cho Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bộ kho lưu trữ này là mẫu khởi đầu nhanh chóng để xây dựng và triển khai các máy chủ MCP (Model Context Protocol) từ xa tùy chỉnh sử dụng Azure Functions với Python, C# .NET hoặc Node/TypeScript.

Các mẫu cung cấp một giải pháp hoàn chỉnh cho phép các nhà phát triển:

- Xây dựng và chạy cục bộ: Phát triển và gỡ lỗi một máy chủ MCP trên máy cục bộ
- Triển khai lên Azure: Dễ dàng triển khai lên đám mây với lệnh azd up đơn giản
- Kết nối từ các khách hàng: Kết nối với máy chủ MCP từ nhiều khách hàng bao gồm chế độ tác nhân của VS Code và công cụ MCP Inspector

### Các Tính Năng Chính:

- Bảo mật theo thiết kế: Máy chủ MCP được bảo mật bằng khóa và HTTPS
- Tùy chọn xác thực: Hỗ trợ OAuth sử dụng xác thực tích hợp và/hoặc Quản lý API
- Cách ly mạng: Cho phép cách ly mạng sử dụng Mạng ảo Azure (VNET)
- Kiến trúc không máy chủ: Tận dụng Azure Functions cho thực thi mở rộng, dựa trên sự kiện
- Phát triển cục bộ: Hỗ trợ phát triển và gỡ lỗi cục bộ toàn diện
- Triển khai đơn giản: Quy trình triển khai đơn giản hóa lên Azure

Kho lưu trữ bao gồm tất cả các tệp cấu hình cần thiết, mã nguồn, và định nghĩa hạ tầng để nhanh chóng bắt đầu với triển khai máy chủ MCP sẵn sàng cho sản xuất.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Triển khai mẫu của MCP sử dụng Azure Functions với Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Triển khai mẫu của MCP sử dụng Azure Functions với C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Triển khai mẫu của MCP sử dụng Azure Functions với Node/TypeScript.

## Những Điểm Chính

- Các SDK MCP cung cấp các công cụ theo ngôn ngữ để triển khai các giải pháp MCP mạnh mẽ
- Quá trình gỡ lỗi và kiểm tra là rất quan trọng cho các ứng dụng MCP đáng tin cậy
- Mẫu gợi ý có thể tái sử dụng cho phép tương tác AI nhất quán
- Quy trình làm việc được thiết kế tốt có thể điều phối các nhiệm vụ phức tạp bằng cách sử dụng nhiều công cụ
- Triển khai các giải pháp MCP yêu cầu xem xét đến bảo mật, hiệu suất, và xử lý lỗi

## Bài Tập

Thiết kế một quy trình làm việc MCP thực tế giải quyết một vấn đề thực tế trong lĩnh vực của bạn:

1. Xác định 3-4 công cụ sẽ hữu ích cho việc giải quyết vấn đề này
2. Tạo một sơ đồ quy trình làm việc cho thấy cách các công cụ này tương tác
3. Triển khai một phiên bản cơ bản của một trong các công cụ bằng ngôn ngữ bạn ưa thích
4. Tạo một mẫu gợi ý sẽ giúp mô hình sử dụng hiệu quả công cụ của bạn

## Tài Nguyên Bổ Sung

---

Tiếp theo: [Chủ Đề Nâng Cao](../05-AdvancedTopics/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.