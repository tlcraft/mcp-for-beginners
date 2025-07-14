<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:16:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "vi"
}
-->
# Chạy ví dụ này

Bạn nên cài đặt `uv` nhưng không bắt buộc, xem [hướng dẫn](https://docs.astral.sh/uv/#highlights)

## -0- Tạo môi trường ảo

```bash
python -m venv venv
```

## -1- Kích hoạt môi trường ảo

```bash
venv\Scrips\activate
```

## -2- Cài đặt các phụ thuộc

```bash
pip install "mcp[cli]"
```

## -3- Chạy ví dụ


```bash
mcp run server.py
```

## -4- Kiểm tra ví dụ

Khi server đang chạy trong một terminal, mở terminal khác và chạy lệnh sau:

```bash
mcp dev server.py
```

Lệnh này sẽ khởi động một web server với giao diện trực quan cho phép bạn kiểm tra ví dụ.

Khi server đã kết nối:

- thử liệt kê các công cụ và chạy `add` với các tham số 2 và 4, bạn sẽ thấy kết quả là 6.
- vào phần resources và resource template, gọi get_greeting, nhập tên và bạn sẽ thấy lời chào với tên bạn đã nhập.

### Kiểm tra ở chế độ CLI

Inspector bạn chạy thực chất là một ứng dụng Node.js và `mcp dev` là một trình bao bọc cho nó.

Bạn có thể khởi chạy trực tiếp ở chế độ CLI bằng cách chạy lệnh sau:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Lệnh này sẽ liệt kê tất cả các công cụ có trên server. Bạn sẽ thấy kết quả như sau:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Để gọi một công cụ, gõ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Bạn sẽ thấy kết quả như sau:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Thường thì chạy inspector ở chế độ CLI sẽ nhanh hơn nhiều so với chạy trên trình duyệt.
> Đọc thêm về inspector [tại đây](https://github.com/modelcontextprotocol/inspector).

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.