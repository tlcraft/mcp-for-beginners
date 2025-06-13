<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:03:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "vi"
}
-->
# Chạy ví dụ này

Dưới đây là cách chạy server và client HTTP streaming cổ điển, cũng như server và client MCP streaming sử dụng Python.

### Tổng quan

- Bạn sẽ thiết lập một MCP server phát các thông báo tiến trình đến client khi xử lý các mục.
- Client sẽ hiển thị từng thông báo theo thời gian thực.
- Hướng dẫn này bao gồm các phần về yêu cầu, cài đặt, chạy và xử lý sự cố.

### Yêu cầu

- Python 3.9 trở lên
- Gói `mcp` Python (cài đặt bằng `pip install mcp`)

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

2. Khởi động server HTTP streaming cổ điển:

   ```pwsh
   python server.py
   ```

3. Server sẽ khởi động và hiển thị:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Chạy Classic HTTP Streaming Client

1. Mở terminal mới (kích hoạt cùng môi trường ảo và thư mục):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Bạn sẽ thấy các tin nhắn được phát liên tiếp:

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
2. Khởi động MCP server với giao thức streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server sẽ khởi động và hiển thị:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Chạy MCP Streaming Client

1. Mở terminal mới (kích hoạt cùng môi trường ảo và thư mục):
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

1. **Tạo MCP server sử dụng FastMCP.**
2. **Định nghĩa một công cụ xử lý danh sách và gửi thông báo sử dụng `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` để thực hiện không chặn.**
- Luôn xử lý ngoại lệ ở cả server và client để đảm bảo ổn định.
- Thử nghiệm với nhiều client để quan sát cập nhật theo thời gian thực.
- Nếu gặp lỗi, kiểm tra phiên bản Python và đảm bảo đã cài đặt đủ các phụ thuộc.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được xem là nguồn tham khảo chính xác nhất. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hay giải thích sai nào phát sinh từ việc sử dụng bản dịch này.