<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:07:45+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ko"
}
-->
# Lesson: 웹 검색 MCP 서버 구축

이 장에서는 외부 API와 연동하고, 다양한 데이터 유형을 처리하며, 오류를 관리하고, 여러 도구를 조율하는 실제 AI 에이전트를 만드는 방법을 보여줍니다. 다음 내용을 다룹니다:

- **인증이 필요한 외부 API 통합**
- **여러 엔드포인트에서 다양한 데이터 유형 처리**
- **견고한 오류 처리 및 로깅 전략**
- **단일 서버 내 다중 도구 조율**

마지막에는 고급 AI 및 LLM 기반 애플리케이션에 필수적인 패턴과 모범 사례를 실습할 수 있습니다.

## 소개

이번 수업에서는 SerpAPI를 활용해 실시간 웹 데이터를 LLM 기능에 확장하는 고급 MCP 서버와 클라이언트를 만드는 방법을 배웁니다. 이는 최신 웹 정보를 실시간으로 활용하는 동적 AI 에이전트를 개발하는 데 중요한 기술입니다.

## 학습 목표

이 수업을 마치면 다음을 할 수 있습니다:

- SerpAPI 같은 외부 API를 MCP 서버에 안전하게 통합하기
- 웹, 뉴스, 제품 검색 및 Q&A용 다중 도구 구현
- LLM에서 활용할 수 있도록 구조화된 데이터 파싱 및 포맷팅
- 오류 처리 및 API 호출 제한 효과적으로 관리
- 자동화 및 대화형 MCP 클라이언트 구축 및 테스트

## 웹 검색 MCP 서버

이 절에서는 웹 검색 MCP 서버의 아키텍처와 기능을 소개합니다. FastMCP와 SerpAPI가 어떻게 결합되어 LLM 기능을 실시간 웹 데이터로 확장하는지 살펴봅니다.

### 개요

이 구현은 MCP가 다양한 외부 API 기반 작업을 안전하고 효율적으로 처리하는 능력을 보여주는 네 가지 도구를 포함합니다:

- **general_search**: 광범위한 웹 결과 검색
- **news_search**: 최신 뉴스 헤드라인 검색
- **product_search**: 전자상거래 데이터 검색
- **qna**: 질문과 답변 스니펫 제공

### 기능
- **코드 예제**: Python을 비롯해 다른 언어로도 쉽게 확장 가능한 언어별 코드 블록을 접을 수 있는 섹션으로 제공하여 가독성 향상

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

클라이언트를 실행하기 전에 서버가 하는 일을 이해하는 것이 도움이 됩니다. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) 파일을 참고하세요.

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
- **구조화된 데이터 파싱**: API 응답을 LLM 친화적 포맷으로 변환하는 과정
- **오류 처리**: 적절한 로깅과 함께 견고한 오류 처리
- **대화형 클라이언트**: 자동화 테스트와 대화형 모드 모두 포함
- **컨텍스트 관리**: MCP Context를 활용한 로깅 및 요청 추적

## 사전 준비 사항

시작하기 전에 환경이 제대로 설정되었는지 다음 단계를 따라 확인하세요. 이 과정은 모든 의존성이 설치되고 API 키가 올바르게 구성되어 원활한 개발과 테스트가 가능하도록 합니다.

- Python 3.8 이상
- SerpAPI API 키 ([SerpAPI](https://serpapi.com/)에서 가입 가능, 무료 요금제 제공)

## 설치

환경 설정을 위해 다음 단계를 따르세요:

1. uv(권장) 또는 pip로 의존성 설치:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 프로젝트 루트에 `.env` 파일을 만들고 SerpAPI 키를 입력:

```
SERPAPI_KEY=your_serpapi_key_here
```

## 사용법

웹 검색 MCP 서버는 SerpAPI와 통합해 웹, 뉴스, 제품 검색 및 Q&A 도구를 노출하는 핵심 구성요소입니다. 서버는 들어오는 요청을 처리하고, API 호출을 관리하며, 응답을 파싱해 구조화된 결과를 클라이언트에 반환합니다.

전체 구현 내용은 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)에서 확인할 수 있습니다.

### 서버 실행

MCP 서버를 시작하려면 다음 명령어를 사용하세요:

```bash
python server.py
```

서버는 stdio 기반 MCP 서버로 실행되어 클라이언트가 직접 연결할 수 있습니다.

### 클라이언트 모드

클라이언트(`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)입니다.

### 클라이언트 실행

자동화 테스트를 실행하려면(서버도 자동으로 시작됨):

```bash
python client.py
```

또는 대화형 모드로 실행:

```bash
python client.py --interactive
```

### 다양한 테스트 방법

서버가 제공하는 도구를 테스트하고 상호작용하는 방법은 필요와 작업 흐름에 따라 여러 가지가 있습니다.

#### MCP Python SDK로 맞춤 테스트 스크립트 작성
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

여기서 "테스트 스크립트"란 MCP 서버의 클라이언트 역할을 하는 맞춤형 Python 프로그램을 의미합니다. 정식 단위 테스트가 아니라 서버에 프로그래밍 방식으로 연결해 원하는 매개변수로 도구를 호출하고 결과를 검사할 수 있습니다. 이 방식은 다음에 유용합니다:

- 도구 호출 프로토타입 제작 및 실험
- 서버가 다양한 입력에 어떻게 반응하는지 검증
- 반복적인 도구 호출 자동화
- MCP 서버 위에 자체 워크플로우나 통합 구축

테스트 스크립트를 사용하면 새 쿼리를 빠르게 시도하거나 도구 동작을 디버깅하는 데 도움되며, 더 고급 자동화의 출발점으로도 활용할 수 있습니다. 아래는 MCP Python SDK를 사용해 스크립트를 만드는 예입니다:

## 도구 설명

서버가 제공하는 다음 도구들을 사용해 다양한 검색과 질의를 수행할 수 있습니다. 각 도구의 매개변수와 사용 예시는 아래에 설명되어 있습니다.

이 절에서는 각 도구와 매개변수에 관한 세부 정보를 제공합니다.

### general_search

일반 웹 검색을 수행하고 포맷된 결과를 반환합니다.

**이 도구를 호출하는 방법:**

MCP Python SDK를 이용해 직접 스크립트에서 `general_search`를 호출하거나, Inspector나 대화형 클라이언트 모드에서 상호작용할 수 있습니다. SDK 사용 예는 다음과 같습니다:

<details>
<summary>Python 예제</summary>

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

또는 대화형 모드에서 `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

쿼리와 관련된 최신 뉴스 기사를 검색합니다.

**이 도구를 호출하는 방법:**

MCP Python SDK를 사용하거나 Inspector, 대화형 클라이언트 모드에서 `news_search`를 호출할 수 있습니다. SDK 사용 예:

<details>
<summary>Python 예제</summary>

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

또는 대화형 모드에서 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

쿼리에 맞는 제품을 검색합니다.

**이 도구를 호출하는 방법:**

MCP Python SDK, Inspector, 대화형 클라이언트 모드에서 `product_search`를 호출할 수 있습니다. SDK 사용 예:

<details>
<summary>Python 예제</summary>

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

또는 대화형 모드에서 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 제품 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

검색 엔진에서 직접 질문에 대한 답변을 가져옵니다.

**이 도구를 호출하는 방법:**

MCP Python SDK, Inspector, 대화형 클라이언트 모드에서 `qna`를 호출할 수 있습니다. SDK 사용 예:

<details>
<summary>Python 예제</summary>

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

또는 대화형 모드에서 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (문자열): 답변을 찾을 질문을 선택하세요.

**요청 예시:**

```json
{
  "question": "what is artificial intelligence"
}
```

## 코드 상세

서버와 클라이언트 구현에 관한 코드 스니펫과 참고 자료를 제공합니다.

<details>
<summary>Python</summary>

전체 구현 내용은 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)에서 확인하세요.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 이번 수업의 고급 개념

개발을 시작하기 전에 이 장에서 다룰 중요한 고급 개념들을 이해하는 것이 도움이 됩니다. 이 내용을 이해하면 처음 접하는 경우에도 수업 내용을 따라가기 쉽습니다:

- **다중 도구 조율**: 웹 검색, 뉴스 검색, 제품 검색, Q&A 등 여러 도구를 단일 MCP 서버 내에서 동시에 운영하는 것을 의미합니다. 서버가 다양한 작업을 처리할 수 있게 합니다.
- **API 호출 제한 관리**: SerpAPI 같은 외부 API는 일정 시간 내 요청 횟수를 제한합니다. 좋은 코드는 이 제한을 감지하고 우아하게 처리해 앱이 중단되지 않도록 합니다.
- **구조화된 데이터 파싱**: API 응답은 복잡하고 중첩된 경우가 많습니다. 이 개념은 그런 응답을 LLM이나 다른 프로그램이 쉽게 사용할 수 있도록 깔끔한 형식으로 변환하는 것을 뜻합니다.
- **오류 복구**: 네트워크 실패나 예상치 못한 API 응답 등 문제가 발생할 때도 코드가 적절히 대응해 유용한 피드백을 제공하며 중단되지 않도록 하는 방법입니다.
- **매개변수 검증**: 도구에 전달되는 입력값이 올바르고 안전한지 확인하는 과정입니다. 기본값 설정과 타입 체크를 포함해 버그와 혼란을 줄이는 데 도움됩니다.

이 절은 웹 검색 MCP 서버 작업 중 흔히 마주칠 수 있는 문제를 진단하고 해결하는 데 도움을 줍니다. 오류나 예상치 못한 동작이 발생하면 먼저 이 문제 해결 섹션을 확인하세요. 많은 경우 여기서 제시하는 방법으로 빠르게 문제를 해결할 수 있습니다.

## 문제 해결

웹 검색 MCP 서버를 다루면서 가끔 문제에 부딪힐 수 있는데, 이는 외부 API와 새로운 도구를 개발할 때 자연스러운 일입니다. 이 절에서는 가장 흔한 문제와 그에 대한 실용적인 해결책을 제공합니다. 오류가 발생하면 우선 이곳을 참고하세요. 아래 팁들은 대부분의 사용자 문제를 다루며, 추가 지원 없이도 해결할 가능성이 높습니다.

### 자주 발생하는 문제

아래는 사용자들이 자주 겪는 문제와 명확한 설명, 해결 방법입니다:

1. **.env 파일에 SERPAPI_KEY 누락**
   - `SERPAPI_KEY 환경 변수 없음`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `클라이언트 실행 중 오류`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API가 오류 상태 401 반환` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` 파일을 생성하세요. 키가 맞는데도 오류가 계속되면 무료 요금제 쿼터가 소진됐는지 확인하세요.

### 디버그 모드

기본적으로 앱은 중요한 정보만 로그에 기록합니다. 문제를 자세히 파악하고 싶을 때(예: 까다로운 문제 진단용) DEBUG 모드를 활성화하면 앱이 수행하는 각 단계에 관한 훨씬 더 많은 정보를 볼 수 있습니다.

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

DEBUG 모드에서는 HTTP 요청, 응답 등 내부 동작에 관한 추가 정보가 포함되어 문제 해결에 매우 유용합니다.

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

## 다음 단계

- [5.10 실시간 스트리밍](../mcp-realtimestreaming/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.