<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:59:53+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "vi"
}
-->
Hãy cùng tìm hiểu thêm về cách sử dụng giao diện trực quan trong các phần tiếp theo.

## Phương pháp tiếp cận

Dưới đây là cách chúng ta cần tiếp cận ở mức độ tổng quan:

- Cấu hình một tập tin để tìm MCP Server của chúng ta.
- Khởi động/Kết nối đến server đó để nhận danh sách các khả năng của nó.
- Sử dụng các khả năng đó thông qua giao diện GitHub Copilot Chat.

Tuyệt vời, bây giờ khi đã hiểu được quy trình, hãy thử sử dụng MCP Server qua Visual Studio Code thông qua một bài tập.

## Bài tập: Sử dụng một server

Trong bài tập này, chúng ta sẽ cấu hình Visual Studio Code để tìm MCP server của bạn nhằm có thể sử dụng từ giao diện GitHub Copilot Chat.

### -0- Bước chuẩn bị, bật tính năng phát hiện MCP Server

Bạn có thể cần bật tính năng phát hiện MCP Servers.

1. Vào `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` trong tập tin settings.json.

### -1- Tạo tập tin cấu hình

Bắt đầu bằng cách tạo một tập tin cấu hình ở thư mục gốc dự án của bạn, bạn cần một tập tin tên MCP.json và đặt nó trong thư mục .vscode. Nó sẽ trông như sau:

```text
.vscode
|-- mcp.json
```

Tiếp theo, hãy xem cách thêm một mục server.

### -2- Cấu hình một server

Thêm nội dung sau vào *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Ví dụ đơn giản trên đây là cách khởi động một server viết bằng Node.js, với các runtime khác bạn cần chỉ định lệnh phù hợp để khởi động server dùng `command` and `args`.

### -3- Khởi động server

Bây giờ bạn đã thêm mục, hãy khởi động server:

1. Tìm mục của bạn trong *mcp.json* và đảm bảo bạn thấy biểu tượng "play":

  ![Khởi động server trong Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.vi.png)  

1. Nhấn vào biểu tượng "play", bạn sẽ thấy biểu tượng công cụ trong GitHub Copilot Chat tăng số lượng công cụ khả dụng. Nếu bạn nhấn vào biểu tượng công cụ này, bạn sẽ thấy danh sách các công cụ đã đăng ký. Bạn có thể chọn hoặc bỏ chọn từng công cụ tùy ý muốn GitHub Copilot sử dụng chúng làm ngữ cảnh hay không:

  ![Khởi động server trong Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.vi.png)

1. Để chạy một công cụ, gõ một câu lệnh bạn biết sẽ phù hợp với mô tả một trong các công cụ của bạn, ví dụ câu lệnh "add 22 to 1":

  ![Chạy công cụ từ GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.vi.png)

  Bạn sẽ thấy phản hồi là 23.

## Bài tập về nhà

Hãy thử thêm một mục server vào tập tin *mcp.json* của bạn và đảm bảo bạn có thể khởi động/dừng server. Đồng thời đảm bảo bạn có thể giao tiếp với các công cụ trên server thông qua giao diện GitHub Copilot Chat.

## Giải pháp

[Giải pháp](./solution/README.md)

## Những điểm chính cần nhớ

Các điểm chính trong chương này như sau:

- Visual Studio Code là một client tuyệt vời cho phép bạn sử dụng nhiều MCP Servers và công cụ của chúng.
- Giao diện GitHub Copilot Chat là cách bạn tương tác với các server.
- Bạn có thể yêu cầu người dùng nhập các thông tin như API key để truyền vào MCP Server khi cấu hình mục server trong tập tin *mcp.json*.

## Mẫu ví dụ

- [Máy tính Java](../samples/java/calculator/README.md)
- [Máy tính .Net](../../../../03-GettingStarted/samples/csharp)
- [Máy tính JavaScript](../samples/javascript/README.md)
- [Máy tính TypeScript](../samples/typescript/README.md)
- [Máy tính Python](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

- [Tài liệu Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Tiếp theo

- Tiếp theo: [Tạo một SSE Server](/03-GettingStarted/05-sse-server/README.md)

**Tuyên bố miễn trách**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được xem là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu nhầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.