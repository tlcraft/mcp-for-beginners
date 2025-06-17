<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:00:02+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "vi"
}
-->
# Chạy ví dụ

Ở đây giả sử bạn đã có mã máy chủ hoạt động. Vui lòng tìm một máy chủ từ một trong những chương trước.

## Thiết lập mcp.json

Đây là một file bạn dùng để tham khảo, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Thay đổi mục server theo nhu cầu để chỉ rõ đường dẫn tuyệt đối đến máy chủ của bạn cùng với lệnh đầy đủ cần thiết để chạy.

Trong file ví dụ được nhắc đến ở trên, mục server trông như sau:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Điều này tương ứng với việc chạy một lệnh như sau: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` gõ một thứ gì đó như "add 3 to 20".

    Bạn sẽ thấy một công cụ xuất hiện phía trên hộp văn bản chat, báo cho bạn chọn để chạy công cụ như trong hình minh họa này:

    ![VS Code chỉ ra nó muốn chạy một công cụ](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.vi.png)

    Việc chọn công cụ sẽ cho ra kết quả số là "23" nếu câu lệnh của bạn giống như chúng tôi đã đề cập trước đó.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được coi là nguồn tham khảo chính thức. Đối với những thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu nhầm hay giải thích sai nào phát sinh từ việc sử dụng bản dịch này.