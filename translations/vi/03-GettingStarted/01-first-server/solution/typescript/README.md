<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:25:07+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "vi"
}
-->
# Chạy mẫu này

Bạn nên cài đặt `uv` nhưng không bắt buộc, xem [hướng dẫn](https://docs.astral.sh/uv/#highlights)

## -1- Cài đặt các phụ thuộc

```bash
npm install
```

## -3- Chạy mẫu

```bash
npm run build
```

## -4- Kiểm tra mẫu

Với máy chủ đang chạy trong một terminal, mở một terminal khác và chạy lệnh sau:

```bash
npm run inspector
```

Điều này sẽ khởi động một máy chủ web với giao diện trực quan cho phép bạn kiểm tra mẫu.

Khi máy chủ đã kết nối:

- thử liệt kê các công cụ và chạy `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` là một lớp bọc xung quanh nó.

Bạn có thể khởi chạy trực tiếp ở chế độ CLI bằng cách chạy lệnh sau:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Điều này sẽ liệt kê tất cả các công cụ có sẵn trong máy chủ. Bạn sẽ thấy đầu ra sau:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Bạn sẽ thấy đầu ra sau:

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
> Thông thường chạy ispector ở chế độ CLI nhanh hơn nhiều so với trong trình duyệt.
> Đọc thêm về ispector [tại đây](https://github.com/modelcontextprotocol/inspector).

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.