<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:32:04+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "vi"
}
-->
# Giao thức Ngữ cảnh Mô hình (MCP) Triển khai Python

Kho lưu trữ này chứa một triển khai Python của Giao thức Ngữ cảnh Mô hình (MCP), minh họa cách tạo cả ứng dụng máy chủ và khách hàng giao tiếp theo tiêu chuẩn MCP.

## Tổng quan

Việc triển khai MCP bao gồm hai thành phần chính:

1. **MCP Server (`server.py`)** - Một máy chủ cung cấp:
   - **Tools**: Các hàm có thể gọi từ xa
   - **Resources**: Dữ liệu có thể truy xuất
   - **Prompts**: Mẫu để tạo lời nhắc cho các mô hình ngôn ngữ

2. **MCP Client (`client.py`)** - Ứng dụng khách kết nối với máy chủ và sử dụng các tính năng của nó

## Tính năng

Việc triển khai này trình bày một số tính năng chính của MCP:

### Tools
- `completion` - Tạo văn bản hoàn chỉnh từ các mô hình AI (giả lập)
- `add` - Máy tính đơn giản cộng hai số

### Resources
- `models://` - Trả về thông tin về các mô hình AI có sẵn
- `greeting://{name}` - Trả về lời chào cá nhân hóa theo tên cho trước

### Prompts
- `review_code` - Tạo lời nhắc để đánh giá mã nguồn

## Cài đặt

Để sử dụng triển khai MCP này, cài đặt các gói cần thiết:

```powershell
pip install mcp-server mcp-client
```

## Chạy Máy chủ và Khách hàng

### Khởi động Máy chủ

Chạy máy chủ trong một cửa sổ terminal:

```powershell
python server.py
```

Máy chủ cũng có thể chạy ở chế độ phát triển bằng MCP CLI:

```powershell
mcp dev server.py
```

Hoặc cài đặt trong Claude Desktop (nếu có):

```powershell
mcp install server.py
```

### Chạy Khách hàng

Chạy khách hàng trong một cửa sổ terminal khác:

```powershell
python client.py
```

Điều này sẽ kết nối với máy chủ và trình diễn tất cả các tính năng có sẵn.

### Cách sử dụng Khách hàng

Khách hàng (`client.py`) trình bày tất cả khả năng của MCP:

```powershell
python client.py
```

Điều này sẽ kết nối với máy chủ và thực hiện tất cả các tính năng bao gồm tools, resources, và prompts. Kết quả sẽ hiển thị:

1. Kết quả công cụ máy tính (5 + 7 = 12)
2. Phản hồi công cụ hoàn thành cho câu hỏi "What is the meaning of life?"
3. Danh sách các mô hình AI có sẵn
4. Lời chào cá nhân hóa cho "MCP Explorer"
5. Mẫu lời nhắc đánh giá mã nguồn

## Chi tiết Triển khai

Máy chủ được triển khai sử dụng API `FastMCP`, cung cấp các trừu tượng cấp cao để định nghĩa dịch vụ MCP. Dưới đây là ví dụ đơn giản về cách định nghĩa tools:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Khách hàng sử dụng thư viện MCP client để kết nối và gọi máy chủ:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Tìm hiểu thêm

Để biết thêm thông tin về MCP, truy cập: https://modelcontextprotocol.io/

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được xem là nguồn tham khảo chính xác nhất. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.