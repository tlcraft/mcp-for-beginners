<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:36:32+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "vi"
}
-->
# 📘 Giải pháp Bài tập: Mở rộng Máy chủ MCP Máy tính của bạn với Công cụ Căn bậc hai

## Tổng quan
Trong bài tập này, bạn đã nâng cấp máy chủ MCP máy tính của mình bằng cách thêm một công cụ mới để tính căn bậc hai của một số. Sự bổ sung này cho phép tác nhân AI của bạn xử lý các truy vấn toán học phức tạp hơn, chẳng hạn như "Căn bậc hai của 16 là bao nhiêu?" hoặc "Tính √49," bằng cách sử dụng các yêu cầu ngôn ngữ tự nhiên.

## 🛠️ Triển khai Công cụ Căn bậc hai
Để thêm chức năng này, bạn đã định nghĩa một hàm công cụ mới trong tệp server.py của mình. Đây là cách triển khai:

```python
"""
Sample MCP Calculator Server implementation in Python.

This module demonstrates how to create a simple MCP server with calculator tools
that can perform basic arithmetic operations (add, subtract, multiply, divide).
"""

from mcp.server.fastmcp import FastMCP
import math

server = FastMCP("calculator")

@server.tool()
def add(a: float, b: float) -> float:
    """Add two numbers together and return the result."""
    return a + b

@server.tool()
def subtract(a: float, b: float) -> float:
    """Subtract b from a and return the result."""
    return a - b

@server.tool()
def multiply(a: float, b: float) -> float:
    """Multiply two numbers together and return the result."""
    return a * b

@server.tool()
def divide(a: float, b: float) -> float:
    """
    Divide a by b and return the result.
    
    Raises:
        ValueError: If b is zero
    """
    if b == 0:
        raise ValueError("Cannot divide by zero")
    return a / b

@server.tool()
def sqrt(a: float) -> float:
    """
    Return the square root of a.

    Raises:
        ValueError: If a is negative.
    """
    if a < 0:
        raise ValueError("Cannot compute the square root of a negative number.")
    return math.sqrt(a)
```

## 🔍 Cách hoạt động

- **Nhập công cụ `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
- **Function Definition**: The `@server.tool()` decorator registers the `sqrt` function as a tool accessible by your AI agent.
- **Input Parameter**: The function accepts a single argument `a` of type `float`.
- **Error Handling**: If `a` is negative, the function raises a `ValueError` to prevent computing the square root of a negative number, which is not supported by the `math.sqrt()` function.
- **Return Value**: For non-negative inputs, the function returns the square root of `a` using Python's built-in `math.sqrt()` method.

## 🔄 Restarting the Server
After adding the new `sqrt` tool, it's essential to restart your MCP server to ensure the agent recognizes and can utilize the newly added functionality.

## 💬 Example Prompts to Test the New Tool
Here are some natural language prompts you can use to test the square root functionality:

- "What is the square root of 25?"
- "Calculate the square root of 81."
- "Find the square root of 0."
- "What is the square root of 2.25?"

These prompts should trigger the agent to invoke the `sqrt` tool and return the correct results.

## ✅ Summary
By completing this assignment, you've:

- Extended your calculator MCP server with a new `sqrt`.
- Cho phép tác nhân AI của bạn xử lý các phép tính căn bậc hai thông qua các yêu cầu ngôn ngữ tự nhiên.
- Thực hành thêm các công cụ mới và khởi động lại máy chủ để tích hợp các chức năng bổ sung.

Hãy thoải mái thử nghiệm thêm bằng cách thêm nhiều công cụ toán học khác, chẳng hạn như hàm lũy thừa hoặc hàm logarit, để tiếp tục nâng cao khả năng của tác nhân của bạn!

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.