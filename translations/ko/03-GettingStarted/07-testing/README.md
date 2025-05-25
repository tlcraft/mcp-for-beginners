<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-16T15:23:19+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "ko"
}
-->
## Testing and Debugging

MCP 서버 테스트를 시작하기 전에, 사용 가능한 도구와 디버깅을 위한 최선의 방법을 이해하는 것이 중요합니다. 효과적인 테스트는 서버가 예상대로 동작하는지 확인하고 문제를 빠르게 찾아 해결하는 데 도움을 줍니다. 다음 섹션에서는 MCP 구현을 검증하기 위한 권장 방법을 설명합니다.

## Overview

이 수업에서는 올바른 테스트 방법을 선택하고 가장 효과적인 테스트 도구를 사용하는 방법을 다룹니다.

## Learning Objectives

이 수업이 끝나면 다음을 할 수 있습니다:

- 다양한 테스트 방법을 설명할 수 있습니다.
- 여러 도구를 사용해 효과적으로 코드를 테스트할 수 있습니다.

## Testing MCP Servers

MCP는 서버를 테스트하고 디버깅하는 데 도움이 되는 도구를 제공합니다:

- **MCP Inspector**: CLI 도구와 시각적 도구로 모두 실행할 수 있는 커맨드 라인 도구입니다.
- **수동 테스트**: curl 같은 도구를 사용해 웹 요청을 실행할 수 있으며, HTTP 요청을 실행할 수 있는 어떤 도구도 사용할 수 있습니다.
- **단위 테스트**: 선호하는 테스트 프레임워크를 사용해 서버와 클라이언트의 기능을 테스트할 수 있습니다.

### Using MCP Inspector

이 도구의 사용법은 이전 수업에서 설명했지만, 여기서 간단히 다시 이야기해보겠습니다. 이 도구는 Node.js로 만들어졌으며, `npx` 실행 파일을 호출해 사용할 수 있습니다. 이 실행 파일은 도구를 임시로 다운로드 및 설치하고, 요청이 완료되면 자동으로 정리합니다.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector)는 다음을 도와줍니다:

- **서버 기능 발견**: 사용 가능한 리소스, 도구, 프롬프트를 자동으로 감지합니다.
- **도구 실행 테스트**: 다양한 매개변수를 시도하고 실시간으로 응답을 확인할 수 있습니다.
- **서버 메타데이터 보기**: 서버 정보, 스키마, 설정을 검토할 수 있습니다.

도구를 실행하는 일반적인 모습은 다음과 같습니다:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

위 명령어는 MCP와 시각적 인터페이스를 시작하고 브라우저에서 로컬 웹 인터페이스를 실행합니다. 대시보드에서는 등록된 MCP 서버, 사용 가능한 도구, 리소스, 프롬프트를 확인할 수 있습니다. 인터페이스를 통해 도구 실행을 인터랙티브하게 테스트하고, 서버 메타데이터를 검사하며, 실시간 응답을 볼 수 있어 MCP 서버 구현을 검증하고 디버깅하는 데 유용합니다.

아래는 인터페이스 예시입니다: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ko.png)

이 도구는 `--cli` 속성을 추가해 CLI 모드로도 실행할 수 있습니다. 아래는 서버의 모든 도구를 나열하는 CLI 모드 실행 예시입니다:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manual Testing

서버 기능을 테스트하기 위해 inspector 도구를 사용하는 것 외에도, curl 같은 HTTP 요청을 실행할 수 있는 클라이언트를 사용하는 방법도 있습니다.

curl을 사용하면 HTTP 요청으로 MCP 서버를 직접 테스트할 수 있습니다:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

위 curl 사용 예시에서 볼 수 있듯이, POST 요청을 통해 도구 이름과 매개변수를 포함한 페이로드로 도구를 호출합니다. 자신에게 맞는 방법을 선택하세요. 일반적으로 CLI 도구는 사용 속도가 빠르고 스크립트 작성에 용이해 CI/CD 환경에서 유용합니다.

### Unit Testing

도구와 리소스가 예상대로 작동하는지 확인하기 위해 단위 테스트를 작성하세요. 다음은 예시 테스트 코드입니다.

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

위 코드는 다음을 수행합니다:

- pytest 프레임워크를 사용해 함수 형태로 테스트를 작성하고 assert 문으로 조건을 확인합니다.
- 두 가지 도구를 가진 MCP Server를 생성합니다.
- 특정 조건이 충족되는지 `assert` 문으로 검증합니다.

[전체 파일은 여기서 확인할 수 있습니다](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

위 파일을 참고해 자신만의 서버가 제대로 기능을 수행하는지 테스트할 수 있습니다.

주요 SDK들도 유사한 테스트 섹션을 제공하므로, 선택한 런타임에 맞게 조정할 수 있습니다.

## Samples

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Additional Resources

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## What's Next

- 다음: [Deployment](/03-GettingStarted/08-deployment/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 내용이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.