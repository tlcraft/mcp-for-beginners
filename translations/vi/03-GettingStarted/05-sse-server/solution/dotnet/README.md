<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:57:25+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "vi"
}
-->
# Chạy mẫu này

## -1- Cài đặt các phụ thuộc

```bash
dotnet run
```

## -2- Chạy mẫu

```bash
dotnet run
```

## -3- Kiểm tra mẫu

Mở một terminal riêng trước khi bạn chạy lệnh dưới đây (đảm bảo rằng server vẫn đang chạy).

Với server đang chạy trong một terminal, mở một terminal khác và chạy lệnh sau:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Điều này sẽ khởi động một máy chủ web với giao diện trực quan cho phép bạn kiểm tra mẫu.

Khi server đã kết nối:

- thử liệt kê các công cụ và chạy `add`, với tham số 2 và 4, bạn sẽ thấy kết quả là 6.
- đi đến tài nguyên và mẫu tài nguyên và gọi "greeting", nhập vào một tên và bạn sẽ thấy lời chào với tên bạn đã cung cấp.

### Kiểm tra ở chế độ CLI

Bạn có thể khởi động trực tiếp ở chế độ CLI bằng cách chạy lệnh sau:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Điều này sẽ liệt kê tất cả các công cụ có sẵn trong server. Bạn sẽ thấy kết quả sau:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Để gọi một công cụ, nhập:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Bạn sẽ thấy kết quả sau:

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
> Thường thì chạy inspector ở chế độ CLI nhanh hơn nhiều so với trên trình duyệt.
> Đọc thêm về inspector [tại đây](https://github.com/modelcontextprotocol/inspector).

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa của nó nên được coi là nguồn chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.