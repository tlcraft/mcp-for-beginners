<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:22:26+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "vi"
}
-->
# Chạy mẫu

Ở đây, chúng ta giả định rằng bạn đã có mã máy chủ hoạt động. Vui lòng tìm một máy chủ từ một trong các chương trước.

## Thiết lập mcp.json

Đây là một tệp bạn sử dụng để tham khảo, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Thay đổi mục máy chủ theo nhu cầu để chỉ ra đường dẫn tuyệt đối đến máy chủ của bạn, bao gồm cả lệnh đầy đủ cần thiết để chạy.

Trong tệp ví dụ được đề cập ở trên, mục máy chủ trông như sau:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Điều này tương ứng với việc chạy một lệnh như sau: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` kiểu như "add 3 to 20".

Bạn sẽ thấy một công cụ được hiển thị phía trên hộp văn bản trò chuyện, chỉ ra rằng bạn có thể chọn chạy công cụ như trong hình ảnh này:

![VS Code chỉ ra rằng nó muốn chạy một công cụ](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.vi.png)

Việc chọn công cụ sẽ tạo ra kết quả số là "23" nếu lời nhắc của bạn giống như chúng tôi đã đề cập trước đó.

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin có thẩm quyền. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hay diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.