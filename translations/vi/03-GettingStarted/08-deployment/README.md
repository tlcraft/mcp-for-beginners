<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:54:18+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "vi"
}
-->
# Triển khai Máy chủ MCP

Triển khai máy chủ MCP của bạn cho phép người khác truy cập vào các công cụ và tài nguyên của nó vượt ra ngoài môi trường cục bộ của bạn. Có nhiều chiến lược triển khai khác nhau để cân nhắc, tùy thuộc vào yêu cầu của bạn về khả năng mở rộng, độ tin cậy và dễ quản lý. Dưới đây là hướng dẫn triển khai máy chủ MCP cục bộ, trong container và lên đám mây.

## Tổng quan

Bài học này hướng dẫn cách triển khai ứng dụng máy chủ MCP của bạn.

## Mục tiêu học tập

Cuối bài học này, bạn sẽ có thể:

- Đánh giá các phương pháp triển khai khác nhau.
- Triển khai ứng dụng của bạn.

## Phát triển và triển khai cục bộ

Nếu máy chủ của bạn được thiết kế để chạy trên máy của người dùng, bạn có thể làm theo các bước sau:

1. **Tải xuống máy chủ**. Nếu bạn không viết máy chủ, hãy tải xuống máy chủ trước tiên về máy của bạn.
1. **Khởi động quá trình máy chủ**: Chạy ứng dụng máy chủ MCP của bạn

Đối với SSE (không cần thiết cho loại máy chủ stdio)

1. **Cấu hình mạng**: Đảm bảo máy chủ có thể truy cập được trên cổng mong đợi
1. **Kết nối khách hàng**: Sử dụng URL kết nối cục bộ như `http://localhost:3000`

## Triển khai lên đám mây

Máy chủ MCP có thể được triển khai lên các nền tảng đám mây khác nhau:

- **Chức năng không máy chủ**: Triển khai máy chủ MCP nhẹ dưới dạng chức năng không máy chủ
- **Dịch vụ Container**: Sử dụng các dịch vụ như Azure Container Apps, AWS ECS, hoặc Google Cloud Run
- **Kubernetes**: Triển khai và quản lý máy chủ MCP trong các cụm Kubernetes để có độ khả dụng cao

### Ví dụ: Azure Container Apps

Azure Container Apps hỗ trợ triển khai Máy chủ MCP. Đây vẫn là một công việc đang tiến hành và hiện tại hỗ trợ máy chủ SSE.

Cách thực hiện:

1. Clone một repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Chạy nó cục bộ để kiểm tra:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Để thử nghiệm cục bộ, tạo một tệp *mcp.json* trong thư mục *.vscode* và thêm nội dung sau:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Khi máy chủ SSE được khởi động, bạn có thể nhấp vào biểu tượng play trong tệp JSON, bạn sẽ thấy các công cụ trên máy chủ được GitHub Copilot nhận diện, xem biểu tượng Tool.

1. Để triển khai, chạy lệnh sau:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Vậy là xong, triển khai nó cục bộ, triển khai nó lên Azure thông qua các bước này.

## Tài nguyên bổ sung

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Bài viết về Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo MCP trên Azure Container Apps](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Tiếp theo

- Tiếp theo: [Thực hành triển khai](/04-PracticalImplementation/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn tài liệu có thẩm quyền. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.