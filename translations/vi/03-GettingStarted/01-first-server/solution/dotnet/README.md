<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:03:55+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "vi"
}
-->
# Chạy ví dụ này

## -1- Cài đặt các phụ thuộc

```bash
dotnet restore
```

## -3- Chạy ví dụ


```bash
dotnet run
```

## -4- Kiểm tra ví dụ

Khi server đang chạy trong một terminal, mở một terminal khác và chạy lệnh sau:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Lệnh này sẽ khởi động một web server với giao diện trực quan giúp bạn kiểm tra ví dụ.

Khi server đã kết nối:

- thử liệt kê các công cụ và chạy `add` với các tham số 2 và 4, bạn sẽ thấy kết quả là 6.
- vào phần resources và resource template, gọi "greeting", nhập tên và bạn sẽ thấy lời chào với tên bạn đã nhập.

### Kiểm tra ở chế độ CLI

Bạn có thể khởi chạy trực tiếp ở chế độ CLI bằng cách chạy lệnh sau:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Lệnh này sẽ liệt kê tất cả các công cụ có trên server. Bạn sẽ thấy kết quả như sau:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
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
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Bạn sẽ thấy kết quả như sau:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Thường thì chạy inspector ở chế độ CLI sẽ nhanh hơn nhiều so với chạy trên trình duyệt.
> Đọc thêm về inspector [tại đây](https://github.com/modelcontextprotocol/inspector).

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sai sót. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được xem là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu nhầm hay giải thích sai nào phát sinh từ việc sử dụng bản dịch này.