<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:10:20+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "vi"
}
-->
## Kiểm tra và Gỡ lỗi

Trước khi bắt đầu kiểm tra server MCP của bạn, điều quan trọng là phải hiểu các công cụ sẵn có và những phương pháp tốt nhất để gỡ lỗi. Việc kiểm tra hiệu quả giúp server của bạn hoạt động như mong đợi và hỗ trợ bạn nhanh chóng phát hiện cũng như khắc phục sự cố. Phần sau đây trình bày các cách tiếp cận được khuyến nghị để xác thực việc triển khai MCP của bạn.

## Tổng quan

Bài học này bao gồm cách chọn phương pháp kiểm tra phù hợp và công cụ kiểm tra hiệu quả nhất.

## Mục tiêu học tập

Kết thúc bài học này, bạn sẽ có thể:

- Mô tả các phương pháp khác nhau để kiểm tra.
- Sử dụng các công cụ khác nhau để kiểm tra mã của bạn một cách hiệu quả.

## Kiểm tra MCP Servers

MCP cung cấp các công cụ giúp bạn kiểm tra và gỡ lỗi server của mình:

- **MCP Inspector**: Công cụ dòng lệnh có thể chạy dưới dạng CLI hoặc giao diện trực quan.
- **Kiểm tra thủ công**: Bạn có thể dùng công cụ như curl để gửi các yêu cầu web, nhưng bất kỳ công cụ nào có thể chạy HTTP đều được.
- **Kiểm tra đơn vị**: Bạn có thể dùng framework kiểm tra yêu thích để kiểm tra các tính năng của cả server và client.

### Sử dụng MCP Inspector

Chúng tôi đã mô tả cách sử dụng công cụ này trong các bài học trước, nhưng hãy cùng điểm qua một chút ở cấp độ tổng quát. Đây là công cụ được xây dựng trên Node.js và bạn có thể dùng bằng cách gọi `npx` thực thi, công cụ này sẽ tải về và cài đặt tạm thời, sau đó tự động dọn dẹp khi hoàn thành yêu cầu của bạn.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) giúp bạn:

- **Khám phá khả năng của Server**: Tự động phát hiện tài nguyên, công cụ và lời nhắc có sẵn
- **Kiểm tra thực thi công cụ**: Thử các tham số khác nhau và xem phản hồi theo thời gian thực
- **Xem metadata của Server**: Xem thông tin server, schema và cấu hình

Một ví dụ chạy công cụ trông như sau:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Lệnh trên khởi động MCP và giao diện trực quan, đồng thời mở giao diện web cục bộ trên trình duyệt của bạn. Bạn sẽ thấy một bảng điều khiển hiển thị các server MCP đã đăng ký, các công cụ, tài nguyên và lời nhắc có sẵn. Giao diện cho phép bạn kiểm tra tương tác thực thi công cụ, xem metadata server và phản hồi thời gian thực, giúp bạn dễ dàng xác thực và gỡ lỗi các triển khai MCP.

Giao diện có thể trông như thế này: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.vi.png)

Bạn cũng có thể chạy công cụ này ở chế độ CLI bằng cách thêm thuộc tính `--cli`. Dưới đây là ví dụ chạy công cụ ở chế độ "CLI" liệt kê tất cả các công cụ trên server:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Kiểm tra thủ công

Ngoài việc chạy công cụ inspector để kiểm tra khả năng của server, một cách tiếp cận tương tự là chạy client có thể sử dụng HTTP, ví dụ như curl.

Với curl, bạn có thể kiểm tra trực tiếp các MCP server bằng các yêu cầu HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Như bạn thấy trong ví dụ sử dụng curl trên, bạn dùng yêu cầu POST để gọi một công cụ với payload gồm tên công cụ và các tham số của nó. Hãy chọn cách phù hợp nhất với bạn. Các công cụ CLI thường nhanh hơn khi sử dụng và dễ dàng được tự động hóa trong môi trường CI/CD.

### Kiểm tra đơn vị

Tạo các bài kiểm tra đơn vị cho công cụ và tài nguyên của bạn để đảm bảo chúng hoạt động như mong đợi. Dưới đây là ví dụ mã kiểm tra.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Mã trên thực hiện:

- Sử dụng framework pytest cho phép bạn tạo các bài kiểm tra dưới dạng hàm và dùng câu lệnh assert.
- Tạo một MCP Server với hai công cụ khác nhau.
- Dùng câu lệnh `assert` để kiểm tra các điều kiện nhất định.

Bạn có thể xem [toàn bộ file tại đây](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Dựa trên file trên, bạn có thể kiểm tra server của riêng mình để đảm bảo các khả năng được tạo đúng như mong muốn.

Hầu hết các SDK lớn đều có phần kiểm tra tương tự, bạn có thể điều chỉnh cho phù hợp với môi trường runtime bạn chọn.

## Ví dụ mẫu

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Tiếp theo

- Tiếp theo: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn chính xác và đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.