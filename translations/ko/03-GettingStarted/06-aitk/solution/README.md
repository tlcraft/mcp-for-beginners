<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-16T15:31:47+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "ko"
}
-->
# 📘 과제 해결: 제곱근 도구로 계산기 MCP 서버 확장하기

## 개요
이번 과제에서는 숫자의 제곱근을 계산하는 새로운 도구를 추가하여 계산기 MCP 서버를 확장했습니다. 이를 통해 AI 에이전트가 "16의 제곱근은 무엇인가요?" 또는 "√49를 계산해줘"와 같은 자연어 명령어로 더 복잡한 수학 문제를 처리할 수 있게 되었습니다.

## 🛠️ 제곱근 도구 구현하기
이 기능을 추가하기 위해 server.py 파일에 새로운 도구 함수를 정의했습니다. 구현 내용은 다음과 같습니다:

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

## 🔍 작동 원리

- **`math.sqrt()` 도구를 `@server.tool()` 데코레이터와 함께 사용하여 정의했습니다.**
- AI 에이전트가 자연어 명령어로 제곱근 계산을 수행할 수 있도록 했습니다.
- 새로운 도구를 추가하고 서버를 재시작하여 기능을 통합하는 과정을 연습했습니다.

더 나아가 거듭제곱이나 로그 함수 같은 수학 도구를 추가해 보면서 에이전트의 기능을 계속 확장해 보세요!

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역은 오류나 부정확성이 포함될 수 있음을 유의해 주시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.