<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:07:04+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ko"
}
-->
# Lesson: Building a Web Search MCP Server


이 장에서는 외부 API와 통합하고, 다양한 데이터 유형을 처리하며, 오류를 관리하고 여러 도구를 조율하는 실제 AI 에이전트를 제작하는 방법을 보여줍니다. 실무에 바로 적용 가능한 형태로 다음 내용을 다룹니다:

- **인증이 필요한 외부 API 통합**
- **여러 엔드포인트에서 다양한 데이터 유형 처리**
- **견고한 오류 처리 및 로깅 전략**
- **단일 서버 내 다중 도구 조율**

마지막에는 고급 AI 및 LLM 기반 애플리케이션에 필수적인 패턴과 모범 사례를 직접 경험할 수 있습니다.

## Introduction

이번 수업에서는 SerpAPI를 활용해 실시간 웹 데이터를 통해 LLM 기능을 확장하는 고급 MCP 서버와 클라이언트를 만드는 방법을 배웁니다. 최신 정보를 웹에서 실시간으로 가져올 수 있는 동적 AI 에이전트를 개발하는 데 중요한 기술입니다.

## Learning Objectives

이 수업이 끝나면 다음을 할 수 있게 됩니다:

- SerpAPI 같은 외부 API를 MCP 서버에 안전하게 통합하기
- 웹, 뉴스, 제품 검색, Q&A를 위한 여러 도구 구현하기
- LLM에 적합한 형식으로 구조화된 데이터 파싱 및 포맷팅
- 오류 처리 및 API 속도 제한 관리 효율적으로 수행하기
- 자동화 및 인터랙티브 MCP 클라이언트 구축 및 테스트

## Web Search MCP Server

이 섹션에서는 Web Search MCP Server의 아키텍처와 기능을 소개합니다. FastMCP와 SerpAPI가 어떻게 결합되어 LLM 기능을 실시간 웹 데이터로 확장하는지 살펴봅니다.

### Overview

이 구현에는 MCP가 다양한 외부 API 기반 작업을 안전하고 효율적으로 처리하는 능력을 보여주는 네 가지 도구가 포함되어 있습니다:

- **general_search**: 광범위한 웹 검색용
- **news_search**: 최신 뉴스 헤드라인용
- **product_search**: 전자상거래 데이터용
- **qna**: 질문과 답변 스니펫용

### Features
- **코드 예제**: Python용 언어별 코드 블록 포함 (다른 언어로 쉽게 확장 가능), 가독성을 위해 접을 수 있는 섹션 사용

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

클라이언트를 실행하기 전에 서버가 무엇을 하는지 이해하는 것이 좋습니다. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)를 참고하세요.

서버가 도구를 정의하고 등록하는 간단한 예는 다음과 같습니다:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **외부 API 통합**: API 키와 외부 요청을 안전하게 처리하는 방법 시연
- **구조화된 데이터 파싱**: API 응답을 LLM 친화적 형식으로 변환하는 과정 소개
- **오류 처리**: 적절한 로깅과 함께 견고한 오류 처리 구현
- **인터랙티브 클라이언트**: 자동화 테스트와 인터랙티브 모드 모두 포함
- **컨텍스트 관리**: MCP Context를 활용해 로깅과 요청 추적 수행

## Prerequisites

시작하기 전에 환경이 제대로 설정되어 있는지 다음 단계를 따라 확인하세요. 모든 의존성이 설치되고 API 키가 올바르게 구성되어 원활한 개발과 테스트가 가능합니다.

- Python 3.8 이상
- SerpAPI API 키 ([SerpAPI](https://serpapi.com/)에서 가입 - 무료 플랜 제공)

## Installation

환경 설정을 위해 다음 단계를 따라하세요:

1. uv(권장) 또는 pip로 의존성 설치:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 프로젝트 루트에 `.env` 파일을 만들고 SerpAPI 키를 추가:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Usage

Web Search MCP Server는 SerpAPI와 통합해 웹, 뉴스, 제품 검색, Q&A 도구를 노출하는 핵심 컴포넌트입니다. 들어오는 요청을 처리하고 API 호출을 관리하며 응답을 파싱해 구조화된 결과를 클라이언트에 반환합니다.

전체 구현은 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)에서 확인할 수 있습니다.

### Running the Server

MCP 서버를 시작하려면 다음 명령어를 사용하세요:

```bash
python server.py
```

서버는 stdio 기반 MCP 서버로 실행되며 클라이언트가 직접 연결할 수 있습니다.

### Client Modes

클라이언트(`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)에는 여러 모드가 있습니다.

### Running the Client

자동화 테스트를 실행하려면 (서버도 자동으로 시작됨):

```bash
python client.py
```

또는 인터랙티브 모드로 실행하려면:

```bash
python client.py --interactive
```

### Testing with Different Methods

필요와 작업 흐름에 따라 서버가 제공하는 도구를 테스트하고 상호작용하는 여러 방법이 있습니다.

#### MCP Python SDK로 커스텀 테스트 스크립트 작성하기
MCP Python SDK를 사용해 직접 테스트 스크립트를 작성할 수도 있습니다:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

여기서 "테스트 스크립트"란 MCP 서버의 클라이언트 역할을 하는 사용자 정의 Python 프로그램을 의미합니다. 정식 단위 테스트가 아니라, 프로그래밍 방식으로 서버에 연결해 원하는 도구를 호출하고 결과를 확인할 수 있습니다. 이 방법은 다음에 유용합니다:

- 도구 호출 프로토타입 작성 및 실험
- 서버의 다양한 입력에 대한 응답 검증
- 반복적인 도구 호출 자동화
- MCP 서버 위에 자신만의 워크플로우 또는 통합 구축

테스트 스크립트를 통해 새 쿼리를 빠르게 시도하거나 도구 동작을 디버깅하고, 더 발전된 자동화의 출발점으로 활용할 수 있습니다. 아래는 MCP Python SDK를 이용해 스크립트를 만드는 예시입니다:

## Tool Descriptions

서버에서 제공하는 다음 도구들을 사용해 다양한 검색과 쿼리를 수행할 수 있습니다. 각 도구에 대해 파라미터와 사용 예제가 설명되어 있습니다.

이 섹션에서는 사용 가능한 각 도구와 파라미터에 대해 자세히 다룹니다.

### general_search

일반 웹 검색을 수행하고 포맷된 결과를 반환합니다.

**이 도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `general_search`를 호출하거나, Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK 사용 예제는 다음과 같습니다:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

또는 인터랙티브 모드에서는 `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

특정 쿼리와 관련된 최신 뉴스 기사를 검색합니다.

**이 도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `news_search`를 호출하거나, Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK 사용 예제는 다음과 같습니다:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

또는 인터랙티브 모드에서는 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

특정 쿼리에 맞는 제품을 검색합니다.

**이 도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `product_search`를 호출하거나, Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK 사용 예제는 다음과 같습니다:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

또는 인터랙티브 모드에서는 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 제품 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

검색 엔진에서 질문에 대한 직접 답변을 가져옵니다.

**이 도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `qna`를 호출하거나, Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK 사용 예제는 다음과 같습니다:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

또는 인터랙티브 모드에서는 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (문자열): 답변을 찾을 질문을 선택하세요.

**요청 예시:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Code Details

이 섹션에서는 서버와 클라이언트 구현을 위한 코드 스니펫과 참조를 제공합니다.

<details>
<summary>Python</summary>

전체 구현은 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)에서 확인할 수 있습니다.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Advanced Concepts in This Lesson

구축을 시작하기 전에, 이 장에서 다룰 중요한 고급 개념을 살펴봅니다. 이 내용을 이해하면 처음 접하는 사람도 따라가기 쉬울 것입니다:

- **다중 도구 조율**: 웹 검색, 뉴스 검색, 제품 검색, Q&A 같은 여러 도구를 하나의 MCP 서버에서 실행하는 것을 의미합니다. 서버가 다양한 작업을 처리할 수 있게 합니다.
- **API 속도 제한 처리**: SerpAPI 같은 외부 API는 일정 시간 내 요청 횟수에 제한을 둡니다. 좋은 코드는 이를 감지하고 적절히 대응해 앱이 중단되지 않도록 합니다.
- **구조화된 데이터 파싱**: API 응답은 복잡하고 중첩된 경우가 많습니다. 이 개념은 그런 응답을 LLM이나 다른 프로그램이 쉽게 사용할 수 있는 깔끔한 형식으로 바꾸는 것입니다.
- **오류 복구**: 네트워크 실패나 API 비정상 응답 등 문제가 발생할 때, 코드가 이를 처리하고 유용한 피드백을 제공하며 충돌을 방지하는 것을 의미합니다.
- **파라미터 검증**: 도구에 전달되는 입력값이 올바르고 안전한지 확인하는 과정입니다. 기본값 설정과 타입 체크를 포함하며, 버그와 혼란을 예방합니다.

이 섹션은 Web Search MCP Server 작업 중 자주 겪는 문제를 진단하고 해결하는 데 도움이 됩니다. 오류나 예상치 못한 동작이 발생하면 이 문제 해결 섹션을 먼저 참고하세요. 대부분의 문제를 빠르게 해결할 수 있습니다.

## Troubleshooting

Web Search MCP Server 작업 중 때때로 문제가 발생할 수 있는데, 이는 외부 API와 새 도구를 개발할 때 자연스러운 현상입니다. 이 섹션에서는 가장 흔한 문제에 대한 실용적인 해결책을 제공합니다. 문제가 생기면 여기서 시작하세요. 아래 팁은 대부분의 사용자가 겪는 문제를 다루며 추가 도움 없이도 문제를 해결할 수 있습니다.

### Common Issues

다음은 사용자가 자주 겪는 문제와 명확한 설명 및 해결 단계입니다:

1. **.env 파일에 SERPAPI_KEY 누락**
   - `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` 파일을 확인하세요. 키가 맞는데도 오류가 계속되면 무료 플랜의 할당량이 소진되었는지 점검하세요.

### Debug Mode

기본적으로 앱은 중요한 정보만 로그에 남깁니다. 문제 진단을 위해 더 자세한 정보를 보고 싶다면 DEBUG 모드를 활성화할 수 있습니다. 그러면 앱의 각 단계에 대한 훨씬 많은 정보가 표시됩니다.

**예시: 일반 출력**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**예시: DEBUG 출력**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

DEBUG 모드에서는 HTTP 요청, 응답 및 기타 내부 세부 사항에 관한 추가 로그가 포함되어 문제 해결에 매우 유용합니다.

DEBUG 모드를 활성화하려면 `client.py` or `server.py` 상단에서 로깅 레벨을 DEBUG로 설정하세요:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## What's next 

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 있을 수 있음을 양지해 주시기 바랍니다. 원문 문서는 해당 언어의 원본이므로 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.