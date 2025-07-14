<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:34:28+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "vi"
}
-->
# Case Study: Phơi bày REST API trong API Management dưới dạng MCP server

Azure API Management là một dịch vụ cung cấp Gateway nằm trên các API Endpoints của bạn. Cách hoạt động là Azure API Management đóng vai trò như một proxy đứng trước các API của bạn và có thể quyết định cách xử lý các yêu cầu đến.

Bằng cách sử dụng dịch vụ này, bạn sẽ có thêm rất nhiều tính năng như:

- **Bảo mật**, bạn có thể sử dụng từ API keys, JWT đến managed identity.
- **Giới hạn tần suất gọi (Rate limiting)**, một tính năng tuyệt vời giúp bạn quyết định số lượng cuộc gọi được phép thực hiện trong một khoảng thời gian nhất định. Điều này giúp đảm bảo tất cả người dùng đều có trải nghiệm tốt và dịch vụ của bạn không bị quá tải bởi các yêu cầu.
- **Mở rộng & Cân bằng tải**. Bạn có thể thiết lập nhiều endpoint để cân bằng tải và cũng có thể quyết định cách thức "cân bằng tải".
- **Các tính năng AI như semantic caching**, giới hạn token và giám sát token, cùng nhiều tính năng khác. Đây là những tính năng tuyệt vời giúp cải thiện khả năng phản hồi cũng như giúp bạn kiểm soát chi phí token. [Tìm hiểu thêm tại đây](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Tại sao chọn MCP + Azure API Management?

Model Context Protocol đang nhanh chóng trở thành tiêu chuẩn cho các ứng dụng AI agentic và cách thức phơi bày công cụ và dữ liệu một cách nhất quán. Azure API Management là lựa chọn tự nhiên khi bạn cần "quản lý" các API. MCP Servers thường tích hợp với các API khác để xử lý các yêu cầu đến một công cụ, ví dụ. Do đó, việc kết hợp Azure API Management và MCP là rất hợp lý.

## Tổng quan

Trong trường hợp sử dụng cụ thể này, chúng ta sẽ học cách phơi bày các API endpoints dưới dạng MCP Server. Bằng cách này, chúng ta có thể dễ dàng biến các endpoint này thành một phần của ứng dụng agentic đồng thời tận dụng các tính năng từ Azure API Management.

## Các tính năng chính

- Bạn chọn các phương thức endpoint muốn phơi bày dưới dạng công cụ.
- Các tính năng bổ sung bạn nhận được phụ thuộc vào cấu hình trong phần chính sách (policy) cho API của bạn. Ở đây, chúng tôi sẽ hướng dẫn bạn cách thêm giới hạn tần suất gọi.

## Bước chuẩn bị: nhập API

Nếu bạn đã có API trong Azure API Management thì rất tốt, bạn có thể bỏ qua bước này. Nếu chưa, hãy xem liên kết này, [nhập API vào Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Phơi bày API dưới dạng MCP Server

Để phơi bày các API endpoints, hãy làm theo các bước sau:

1. Truy cập Azure Portal tại địa chỉ <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Đi đến instance API Management của bạn.

1. Trong menu bên trái, chọn APIs > MCP Servers > + Create new MCP Server.

1. Trong phần API, chọn một REST API để phơi bày dưới dạng MCP server.

1. Chọn một hoặc nhiều API Operations để phơi bày dưới dạng công cụ. Bạn có thể chọn tất cả các operation hoặc chỉ một số cụ thể.

    ![Chọn các phương thức để phơi bày](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Chọn **Create**.

1. Truy cập menu **APIs** và **MCP Servers**, bạn sẽ thấy như sau:

    ![Xem MCP Server trong khung chính](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP server đã được tạo và các API operations được phơi bày dưới dạng công cụ. MCP server được liệt kê trong khung MCP Servers. Cột URL hiển thị endpoint của MCP server mà bạn có thể gọi để thử nghiệm hoặc sử dụng trong ứng dụng client.

## Tùy chọn: Cấu hình chính sách

Azure API Management có khái niệm cốt lõi là chính sách (policies), nơi bạn thiết lập các quy tắc khác nhau cho các endpoint, ví dụ như giới hạn tần suất gọi hoặc semantic caching. Các chính sách này được viết dưới dạng XML.

Dưới đây là cách bạn có thể thiết lập chính sách để giới hạn tần suất gọi cho MCP Server:

1. Trong portal, dưới mục APIs, chọn **MCP Servers**.

1. Chọn MCP server bạn đã tạo.

1. Trong menu bên trái, dưới MCP, chọn **Policies**.

1. Trong trình chỉnh sửa chính sách, thêm hoặc chỉnh sửa các chính sách bạn muốn áp dụng cho các công cụ của MCP server. Các chính sách được định nghĩa dưới dạng XML. Ví dụ, bạn có thể thêm chính sách giới hạn số cuộc gọi đến các công cụ của MCP server (ví dụ này giới hạn 5 cuộc gọi mỗi 30 giây cho mỗi địa chỉ IP client). Đây là đoạn XML để thực hiện giới hạn tần suất gọi:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Đây là hình ảnh của trình chỉnh sửa chính sách:

    ![Trình chỉnh sửa chính sách](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Thử nghiệm

Hãy đảm bảo MCP Server của chúng ta hoạt động như mong đợi.

Để làm điều này, chúng ta sẽ sử dụng Visual Studio Code và GitHub Copilot với chế độ Agent. Chúng ta sẽ thêm MCP server vào file *mcp.json*. Bằng cách này, Visual Studio Code sẽ hoạt động như một client có khả năng agentic và người dùng cuối có thể nhập prompt để tương tác với server đó.

Cách thêm MCP server trong Visual Studio Code:

1. Sử dụng lệnh MCP: **Add Server** từ Command Palette.

1. Khi được yêu cầu, chọn loại server: **HTTP (HTTP hoặc Server Sent Events)**.

1. Nhập URL của MCP server trong API Management. Ví dụ: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (cho endpoint SSE) hoặc **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (cho endpoint MCP), lưu ý sự khác biệt giữa các giao thức là `/sse` hoặc `/mcp`.

1. Nhập một server ID tùy chọn. Đây không phải giá trị quan trọng nhưng giúp bạn nhớ server instance này là gì.

1. Chọn lưu cấu hình vào workspace settings hoặc user settings.

  - **Workspace settings** - Cấu hình server được lưu trong file .vscode/mcp.json chỉ có trong workspace hiện tại.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    hoặc nếu bạn chọn streaming HTTP làm giao thức thì sẽ hơi khác:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Cấu hình server được thêm vào file *settings.json* toàn cục và có thể dùng trong tất cả workspace. Cấu hình trông giống như sau:

    ![Cấu hình user](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Bạn cũng cần thêm cấu hình header để đảm bảo xác thực đúng với Azure API Management. Nó sử dụng header có tên **Ocp-Apim-Subscription-Key**.

    - Đây là cách thêm header vào settings:

    ![Thêm header để xác thực](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), điều này sẽ hiển thị prompt yêu cầu bạn nhập giá trị API key mà bạn có thể tìm thấy trong Azure Portal cho instance Azure API Management của bạn.

   - Để thêm vào *mcp.json*, bạn có thể thêm như sau:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Sử dụng chế độ Agent

Bây giờ chúng ta đã thiết lập xong trong settings hoặc trong *.vscode/mcp.json*. Hãy thử nghiệm.

Sẽ có một biểu tượng Tools như sau, nơi các công cụ được phơi bày từ server của bạn được liệt kê:

![Công cụ từ server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Nhấn vào biểu tượng tools và bạn sẽ thấy danh sách các công cụ như sau:

    ![Công cụ](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Nhập prompt trong chat để gọi công cụ. Ví dụ, nếu bạn chọn công cụ lấy thông tin về một đơn hàng, bạn có thể hỏi agent về đơn hàng đó. Đây là ví dụ prompt:

    ```text
    get information from order 2
    ```

    Bạn sẽ thấy biểu tượng công cụ yêu cầu bạn xác nhận gọi công cụ. Chọn để tiếp tục chạy công cụ, bạn sẽ thấy kết quả như sau:

    ![Kết quả từ prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Kết quả bạn thấy phụ thuộc vào các công cụ bạn đã thiết lập, nhưng ý tưởng là bạn nhận được phản hồi dạng văn bản như trên**


## Tài liệu tham khảo

Dưới đây là các nguồn để bạn tìm hiểu thêm:

- [Hướng dẫn về Azure API Management và MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Ví dụ Python: Bảo mật MCP servers từ xa sử dụng Azure API Management (thử nghiệm)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Phòng thí nghiệm ủy quyền client MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Sử dụng extension Azure API Management cho VS Code để nhập và quản lý API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Đăng ký và khám phá MCP servers từ xa trong Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Kho lưu trữ tuyệt vời trình bày nhiều khả năng AI với Azure API Management
- [Workshop AI Gateway](https://azure-samples.github.io/AI-Gateway/) Chứa các workshop sử dụng Azure Portal, là cách tuyệt vời để bắt đầu đánh giá các khả năng AI.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.