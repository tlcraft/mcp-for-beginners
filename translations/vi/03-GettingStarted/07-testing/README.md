<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:45:38+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "vi"
}
-->
## Kiểm tra và Gỡ lỗi

Trước khi bạn bắt đầu kiểm tra máy chủ MCP của mình, điều quan trọng là phải hiểu các công cụ có sẵn và các phương pháp tốt nhất để gỡ lỗi. Kiểm tra hiệu quả đảm bảo máy chủ của bạn hoạt động như mong đợi và giúp bạn nhanh chóng xác định và giải quyết các vấn đề. Phần sau đây phác thảo các phương pháp được đề xuất để xác thực việc triển khai MCP của bạn.

## Tổng quan

Bài học này bao gồm cách chọn phương pháp kiểm tra phù hợp và công cụ kiểm tra hiệu quả nhất.

## Mục tiêu học tập

Kết thúc bài học này, bạn sẽ có thể:

- Mô tả các phương pháp khác nhau để kiểm tra.
- Sử dụng các công cụ khác nhau để kiểm tra mã của bạn một cách hiệu quả.

## Kiểm tra Máy chủ MCP

MCP cung cấp các công cụ giúp bạn kiểm tra và gỡ lỗi máy chủ của mình:

- **MCP Inspector**: Một công cụ dòng lệnh có thể chạy cả dưới dạng công cụ CLI và công cụ trực quan.
- **Kiểm tra thủ công**: Bạn có thể sử dụng một công cụ như curl để chạy các yêu cầu web, nhưng bất kỳ công cụ nào có khả năng chạy HTTP đều được.
- **Kiểm tra đơn vị**: Có thể sử dụng khung kiểm tra ưa thích của bạn để kiểm tra các tính năng của cả máy chủ và khách hàng.

### Sử dụng MCP Inspector

Chúng tôi đã mô tả việc sử dụng công cụ này trong các bài học trước nhưng hãy nói về nó một chút ở mức độ cao. Đây là một công cụ được xây dựng trong Node.js và bạn có thể sử dụng nó bằng cách gọi thực thi `npx`, sẽ tải xuống và cài đặt công cụ tạm thời và sẽ tự dọn dẹp khi hoàn tất yêu cầu của bạn.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) giúp bạn:

- **Khám phá khả năng của máy chủ**: Tự động phát hiện các tài nguyên, công cụ và lời nhắc có sẵn
- **Kiểm tra thực thi công cụ**: Thử các tham số khác nhau và xem phản hồi theo thời gian thực
- **Xem siêu dữ liệu máy chủ**: Kiểm tra thông tin máy chủ, các sơ đồ và cấu hình

Một lần chạy công cụ điển hình trông như thế này:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Lệnh trên bắt đầu một MCP và giao diện trực quan của nó và khởi chạy một giao diện web cục bộ trong trình duyệt của bạn. Bạn có thể mong đợi thấy một bảng điều khiển hiển thị các máy chủ MCP đã đăng ký của bạn, các công cụ, tài nguyên và lời nhắc có sẵn của họ. Giao diện cho phép bạn kiểm tra thực thi công cụ tương tác, kiểm tra siêu dữ liệu máy chủ và xem phản hồi theo thời gian thực, giúp dễ dàng xác thực và gỡ lỗi các triển khai máy chủ MCP của bạn.

Đây là những gì nó có thể trông như thế này: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.vi.png)

Bạn cũng có thể chạy công cụ này ở chế độ CLI, trong trường hợp đó bạn thêm thuộc tính `--cli`. Đây là một ví dụ về việc chạy công cụ ở chế độ "CLI", liệt kê tất cả các công cụ trên máy chủ:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Kiểm tra Thủ công

Ngoài việc chạy công cụ inspector để kiểm tra khả năng của máy chủ, một cách tiếp cận tương tự khác là chạy một máy khách có khả năng sử dụng HTTP như curl.

Với curl, bạn có thể kiểm tra máy chủ MCP trực tiếp bằng các yêu cầu HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Như bạn có thể thấy từ việc sử dụng curl ở trên, bạn sử dụng yêu cầu POST để gọi một công cụ bằng một tải trọng gồm tên công cụ và các tham số của nó. Sử dụng phương pháp phù hợp nhất với bạn. Các công cụ CLI nói chung có xu hướng nhanh hơn để sử dụng và có thể được viết kịch bản, điều này có thể hữu ích trong môi trường CI/CD.

### Kiểm tra Đơn vị

Tạo các bài kiểm tra đơn vị cho các công cụ và tài nguyên của bạn để đảm bảo chúng hoạt động như mong đợi. Dưới đây là một số mã kiểm tra ví dụ.

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

Mã trước đó thực hiện các điều sau:

- Sử dụng khung pytest cho phép bạn tạo các bài kiểm tra dưới dạng các hàm và sử dụng các câu lệnh assert.
- Tạo một Máy chủ MCP với hai công cụ khác nhau.
- Sử dụng câu lệnh `assert` để kiểm tra rằng các điều kiện nhất định được thỏa mãn.

Xem tệp đầy đủ [tại đây](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Dựa vào tệp trên, bạn có thể kiểm tra máy chủ của mình để đảm bảo các khả năng được tạo ra như chúng nên.

Tất cả các SDK chính đều có các phần kiểm tra tương tự, vì vậy bạn có thể điều chỉnh theo thời gian chạy mà bạn đã chọn.

## Mẫu

- [Máy tính Java](../samples/java/calculator/README.md)
- [Máy tính .Net](../../../../03-GettingStarted/samples/csharp)
- [Máy tính JavaScript](../samples/javascript/README.md)
- [Máy tính TypeScript](../samples/typescript/README.md)
- [Máy tính Python](../../../../03-GettingStarted/samples/python) 

## Tài nguyên Bổ sung

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Tiếp theo

- Tiếp theo: [Triển khai](/03-GettingStarted/08-deployment/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn đáng tin cậy nhất. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.