<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:05:24+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "vi"
}
-->
# Chạy ví dụ này

## -1- Cài đặt các phụ thuộc

```bash
dotnet restore
```

## -2- Chạy ví dụ

```bash
dotnet run
```

## -3- Kiểm tra ví dụ

Mở một terminal riêng trước khi bạn chạy lệnh dưới đây (đảm bảo server vẫn đang chạy).

Khi server đang chạy ở một terminal, mở terminal khác và chạy lệnh sau:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Lệnh này sẽ khởi động một web server với giao diện trực quan cho phép bạn kiểm tra ví dụ.

> Đảm bảo rằng **Streamable HTTP** được chọn làm loại giao thức truyền tải, và URL là `http://localhost:3001/mcp`.

Khi server đã kết nối:

- thử liệt kê các công cụ và chạy `add` với các tham số 2 và 4, bạn sẽ thấy kết quả là 6.
- vào phần resources và resource template, gọi "greeting", nhập một tên và bạn sẽ thấy lời chào với tên bạn đã nhập.

### Kiểm tra ở chế độ CLI

Bạn có thể khởi chạy trực tiếp ở chế độ CLI bằng cách chạy lệnh sau:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Lệnh này sẽ liệt kê tất cả các công cụ có trên server. Bạn sẽ thấy kết quả như sau:

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

Để gọi một công cụ, gõ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Tìm hiểu thêm về inspector [tại đây](https://github.com/modelcontextprotocol/inspector).

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.