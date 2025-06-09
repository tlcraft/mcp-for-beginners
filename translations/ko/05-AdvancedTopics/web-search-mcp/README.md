<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:36:48+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ko"
}
-->
# Lesson: 웹 검색 MCP 서버 구축

이 장에서는 외부 API와 통합하고, 다양한 데이터 유형을 처리하며, 오류를 관리하고, 여러 도구를 조율하는 실제 AI 에이전트를 만드는 방법을 보여줍니다. 다음 내용을 다룹니다:

- **인증이 필요한 외부 API 통합**
- **여러 엔드포인트에서 다양한 데이터 유형 처리**
- **견고한 오류 처리 및 로깅 전략**
- **단일 서버 내에서 다중 도구 조율**

마지막에는 고급 AI 및 LLM 기반 애플리케이션에 필수적인 패턴과 모범 사례를 실습하게 됩니다.

## 소개

이번 수업에서는 SerpAPI를 활용해 실시간 웹 데이터를 통해 LLM 기능을 확장하는 고급 MCP 서버와 클라이언트를 만드는 방법을 배웁니다. 이는 웹에서 최신 정보를 얻을 수 있는 동적 AI 에이전트를 개발하는 데 중요한 기술입니다.

## 학습 목표

이 수업이 끝나면 다음을 할 수 있습니다:

- SerpAPI 같은 외부 API를 MCP 서버에 안전하게 통합하기
- 웹, 뉴스, 상품 검색, Q&A를 위한 다중 도구 구현하기
- LLM에 적합하도록 구조화된 데이터 파싱 및 포맷팅하기
- 오류 처리 및 API 호출 제한 관리하기
- 자동화 및 인터랙티브 MCP 클라이언트 구축 및 테스트하기

## 웹 검색 MCP 서버

이 섹션에서는 웹 검색 MCP 서버의 아키텍처와 기능을 소개합니다. FastMCP와 SerpAPI가 어떻게 결합되어 LLM 기능을 실시간 웹 데이터로 확장하는지 확인할 수 있습니다.

### 개요

이 구현은 MCP가 다양한 외부 API 기반 작업을 안전하고 효율적으로 처리하는 능력을 보여주는 네 가지 도구를 포함합니다:

- **general_search**: 광범위한 웹 결과 검색
- **news_search**: 최신 뉴스 헤드라인 검색
- **product_search**: 전자상거래 데이터 검색
- **qna**: 질문-답변 스니펫 제공

### 기능
- **코드 예제**: Python을 비롯한 여러 언어별 코드 블록을 접을 수 있는 섹션으로 명확하게 제공

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

클라이언트를 실행하기 전에 서버가 어떤 역할을 하는지 이해하는 것이 도움이 됩니다. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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
- **구조화된 데이터 파싱**: API 응답을 LLM 친화적 포맷으로 변환하는 방법
- **오류 처리**: 적절한 로깅과 함께 견고한 오류 처리
- **인터랙티브 클라이언트**: 자동화된 테스트와 인터랙티브 모드 포함
- **컨텍스트 관리**: MCP 컨텍스트를 활용한 로깅 및 요청 추적

## 사전 준비 사항

시작하기 전에 환경이 올바르게 설정되어 있는지 다음 단계를 따라 확인하세요. 이 과정을 통해 모든 의존성이 설치되고 API 키가 올바르게 구성되어 원활한 개발과 테스트가 가능합니다.

- Python 3.8 이상
- SerpAPI API 키 ([SerpAPI](https://serpapi.com/)에서 가입 - 무료 플랜 이용 가능)

## 설치

환경 설정을 위해 다음 단계를 따르세요:

1. uv(권장) 또는 pip를 사용해 의존성 설치:

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

## 사용법

웹 검색 MCP 서버는 SerpAPI와 통합해 웹, 뉴스, 상품 검색, Q&A 도구를 노출하는 핵심 구성 요소입니다. 요청을 처리하고 API 호출을 관리하며 응답을 파싱해 구조화된 결과를 클라이언트에 반환합니다.

전체 구현은 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)에서 확인할 수 있습니다.

### 서버 실행

MCP 서버를 시작하려면 다음 명령어를 사용하세요:

```bash
python server.py
```

서버는 stdio 기반 MCP 서버로 실행되며 클라이언트가 직접 연결할 수 있습니다.

### 클라이언트 모드

클라이언트는 [`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)입니다.

### 클라이언트 실행

자동화 테스트를 실행하려면(서버도 자동으로 시작됨):

```bash
python client.py
```

또는 인터랙티브 모드로 실행하려면:

```bash
python client.py --interactive
```

### 다양한 방법으로 테스트하기

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

여기서 "테스트 스크립트"는 MCP 서버의 클라이언트 역할을 하는 맞춤형 Python 프로그램을 의미합니다. 정식 단위 테스트가 아니라, 서버에 프로그래밍 방식으로 연결해 원하는 매개변수로 도구를 호출하고 결과를 확인할 수 있습니다. 이 방법은 다음에 유용합니다:

- 도구 호출 프로토타입 제작 및 실험
- 다양한 입력에 대한 서버 응답 검증
- 반복 도구 호출 자동화
- MCP 서버 위에 자체 워크플로우 또는 통합 구축

테스트 스크립트로 새로운 쿼리를 빠르게 시도하거나 도구 동작을 디버깅하거나 고급 자동화의 출발점으로 활용할 수 있습니다. 아래는 MCP Python SDK를 이용해 스크립트를 작성하는 예입니다.

## 도구 설명

서버가 제공하는 다음 도구들을 이용해 다양한 검색과 질의를 수행할 수 있습니다. 각 도구별 매개변수와 사용 예시를 설명합니다.

이 섹션에서는 사용 가능한 각 도구와 그 매개변수에 대해 자세히 설명합니다.

### general_search

일반 웹 검색을 수행하고 포맷된 결과를 반환합니다.

**도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `general_search`를 호출하거나 Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK를 이용한 코드 예시는 다음과 같습니다:

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

또는 인터랙티브 모드에서 `general_search` from the menu and enter your query when prompted.

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

**도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `news_search`를 호출하거나 Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK를 이용한 코드 예시는 다음과 같습니다:

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

또는 인터랙티브 모드에서 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

쿼리에 맞는 상품을 검색합니다.

**도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `product_search`를 호출하거나 Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK를 이용한 코드 예시는 다음과 같습니다:

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

또는 인터랙티브 모드에서 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (문자열): 상품 검색 쿼리를 선택하세요.

**요청 예시:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

검색 엔진에서 질문에 대한 직접적인 답변을 제공합니다.

**도구 호출 방법:**

MCP Python SDK를 사용해 직접 스크립트에서 `qna`를 호출하거나 Inspector 또는 인터랙티브 클라이언트 모드에서 사용할 수 있습니다. SDK를 이용한 코드 예시는 다음과 같습니다:

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

또는 인터랙티브 모드에서 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (문자열): 답변을 찾을 질문을 선택하세요.

**요청 예시:**

```json
{
  "question": "what is artificial intelligence"
}
```

## 코드 상세

서버와 클라이언트 구현에 관한 코드 스니펫과 참조를 제공합니다.

<details>
<summary>Python</summary>

전체 구현은 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)에서 확인하세요.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 이 수업의 고급 개념

구축을 시작하기 전에 이 장에서 다룰 중요한 고급 개념들을 소개합니다. 이 개념들을 이해하면 처음 접하는 경우에도 내용을 따라가기 쉽습니다:

- **다중 도구 조율**: 웹 검색, 뉴스 검색, 상품 검색, Q&A 같은 여러 도구를 단일 MCP 서버 내에서 실행하는 것. 서버가 단일 작업이 아닌 다양한 작업을 처리할 수 있게 합니다.
- **API 호출 제한 관리**: SerpAPI 같은 외부 API는 일정 시간 내 호출 횟수에 제한을 둡니다. 좋은 코드는 이러한 제한을 확인하고 우아하게 처리해 앱이 중단되지 않도록 합니다.
- **구조화된 데이터 파싱**: API 응답은 종종 복잡하고 중첩되어 있습니다. 이를 LLM이나 다른 프로그램이 쉽게 사용할 수 있도록 깔끔하고 사용하기 편한 형식으로 변환하는 개념입니다.
- **오류 복구**: 네트워크 문제나 예상치 못한 API 응답 등 오류 상황을 코드가 잘 처리해 유용한 피드백을 주고 프로그램이 중단되지 않도록 하는 것.
- **매개변수 검증**: 도구에 입력되는 모든 값이 올바르고 안전한지 확인하는 작업. 기본값 설정과 타입 체크를 포함해 버그와 혼란을 방지합니다.

이 섹션은 웹 검색 MCP 서버 작업 중 마주칠 수 있는 일반적인 문제를 진단하고 해결하는 데 도움을 줍니다. 오류나 예기치 않은 동작이 발생하면 이 문제 해결 섹션을 먼저 참고하세요. 대부분 빠르게 문제를 해결할 수 있습니다.

## 문제 해결

웹 검색 MCP 서버를 사용하면서 가끔 문제를 만날 수 있습니다. 이는 외부 API와 새로운 도구를 개발할 때 흔한 일입니다. 이 섹션은 가장 흔한 문제들에 대한 실용적인 해결책을 제공해 빠르게 정상 상태로 돌아갈 수 있도록 돕습니다. 오류가 발생하면 여기부터 확인하세요. 아래 팁들은 대부분의 사용자가 겪는 문제를 다루며, 추가 지원 없이도 문제를 해결할 수 있습니다.

### 자주 발생하는 문제

아래는 사용자들이 자주 겪는 문제와 그에 대한 명확한 설명 및 해결 단계입니다:

1. **.env 파일에 SERPAPI_KEY 누락**
   - `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` 파일을 확인하거나 생성하세요. 키가 맞는데도 오류가 발생하면 무료 플랜 할당량이 소진되었는지 확인하세요.

### 디버그 모드

기본적으로 앱은 중요한 정보만 로그에 기록합니다. 문제 원인 파악이나 상세한 동작을 보고 싶으면 DEBUG 모드를 활성화할 수 있습니다. 그러면 앱이 수행하는 각 단계에 대한 더 많은 정보가 표시됩니다.

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

DEBUG 모드에서는 HTTP 요청, 응답 및 기타 내부 세부 정보가 추가로 포함되어 문제 해결에 큰 도움이 됩니다.

DEBUG 모드를 켜려면 `client.py` or `server.py` 상단에서 로깅 레벨을 DEBUG로 설정하세요:

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

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역은 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.