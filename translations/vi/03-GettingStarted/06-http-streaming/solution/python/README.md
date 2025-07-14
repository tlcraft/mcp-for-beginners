<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:21:06+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "vi"
}
-->
# Chạy ví dụ này

Dưới đây là cách chạy server và client streaming HTTP cổ điển, cũng như server và client streaming MCP sử dụng Python.

### Tổng quan

- Bạn sẽ thiết lập một server MCP phát các thông báo tiến trình đến client trong quá trình xử lý các mục.
- Client sẽ hiển thị từng thông báo theo thời gian thực.
- Hướng dẫn này bao gồm các yêu cầu trước, cài đặt, chạy và khắc phục sự cố.

### Yêu cầu trước

- Python 3.9 trở lên
- Gói Python `mcp` (cài đặt bằng `pip install mcp`)

### Cài đặt & Thiết lập

1. Clone repository hoặc tải các file giải pháp về.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Tạo và kích hoạt môi trường ảo (khuyến nghị):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Cài đặt các phụ thuộc cần thiết:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Các file

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Chạy Classic HTTP Streaming Server

1. Điều hướng đến thư mục giải pháp:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Khởi động server streaming HTTP cổ điển:

   ```pwsh
   python server.py
   ```

3. Server sẽ khởi động và hiển thị:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Chạy Classic HTTP Streaming Client

1. Mở một terminal mới (kích hoạt cùng môi trường ảo và thư mục):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Bạn sẽ thấy các thông điệp được phát liên tiếp:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Chạy MCP Streaming Server

1. Điều hướng đến thư mục giải pháp:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Khởi động server MCP với transport streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server sẽ khởi động và hiển thị:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Chạy MCP Streaming Client

1. Mở một terminal mới (kích hoạt cùng môi trường ảo và thư mục):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Bạn sẽ thấy các thông báo được in ra theo thời gian thực khi server xử lý từng mục:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Các bước triển khai chính

1. **Tạo server MCP sử dụng FastMCP.**
2. **Định nghĩa một công cụ xử lý danh sách và gửi thông báo bằng `ctx.info()` hoặc `ctx.log()`.**
3. **Chạy server với `transport="streamable-http"`.**
4. **Triển khai client với bộ xử lý tin nhắn để hiển thị thông báo khi chúng đến.**

### Giải thích mã nguồn
- Server sử dụng các hàm async và context MCP để gửi cập nhật tiến trình.
- Client triển khai bộ xử lý tin nhắn async để in thông báo và kết quả cuối cùng.

### Mẹo & Khắc phục sự cố

- Sử dụng `async/await` để tránh chặn quá trình.
- Luôn xử lý ngoại lệ ở cả server và client để tăng độ ổn định.
- Thử với nhiều client để quan sát cập nhật theo thời gian thực.
- Nếu gặp lỗi, kiểm tra phiên bản Python và đảm bảo đã cài đủ các phụ thuộc.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.