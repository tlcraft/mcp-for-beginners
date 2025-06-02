<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:28:30+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "zh"
}
-->
# 课程：构建 Web 搜索 MCP 服务器

本章演示如何构建一个真实世界的 AI 代理，集成外部 API，处理多种数据类型，管理错误，并协调多个工具——所有这些都以生产就绪的形式呈现。你将看到：

- **集成需要身份验证的外部 API**
- **处理来自多个端点的多样化数据类型**
- **健壮的错误处理和日志策略**
- **单一服务器中的多工具协调**

到最后，你将掌握对高级 AI 和基于 LLM 的应用至关重要的模式和最佳实践。

## 介绍

在本课中，你将学习如何构建一个高级的 MCP 服务器和客户端，通过 SerpAPI 将 LLM 功能扩展到实时的网络数据。这是开发能够访问最新网络信息的动态 AI 代理的关键技能。

## 学习目标

完成本课后，你将能够：

- 安全地将外部 API（如 SerpAPI）集成到 MCP 服务器中
- 实现用于网页、新闻、产品搜索和问答的多种工具
- 解析并格式化结构化数据以供 LLM 使用
- 有效处理错误和管理 API 速率限制
- 构建和测试自动化及交互式 MCP 客户端

## Web 搜索 MCP 服务器

本节介绍 Web 搜索 MCP 服务器的架构和功能。你将看到 FastMCP 和 SerpAPI 如何协同工作，将 LLM 功能扩展到实时网络数据。

### 概述

该实现包含四个工具，展示了 MCP 安全高效处理多样化外部 API 任务的能力：

- **general_search**：用于广泛的网页搜索结果
- **news_search**：用于最新新闻头条
- **product_search**：用于电商数据
- **qna**：用于问答片段

### 功能
- **代码示例**：包含针对 Python 的语言特定代码块（并可轻松扩展到其他语言），使用可折叠部分以便清晰展示

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

在运行客户端之前，了解服务器的功能会很有帮助。请查看 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

以下是服务器如何定义并注册工具的简要示例：

<details>  
<summary>Python 服务器</summary> 

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

- **外部 API 集成**：展示了如何安全处理 API 密钥和外部请求
- **结构化数据解析**：展示如何将 API 响应转换为适合 LLM 使用的格式
- **错误处理**：健壮的错误处理和适当的日志记录
- **交互式客户端**：包含自动测试和交互模式用于测试
- **上下文管理**：利用 MCP Context 进行日志记录和请求跟踪

## 前提条件

开始之前，请确保按照以下步骤正确配置环境。这将确保所有依赖项已安装，并且 API 密钥配置正确，便于顺利开发和测试。

- Python 3.8 或更高版本
- SerpAPI API Key（可在 [SerpAPI](https://serpapi.com/) 注册，提供免费套餐）

## 安装

开始之前，请按照以下步骤设置环境：

1. 使用 uv（推荐）或 pip 安装依赖：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 在项目根目录创建 `.env` 文件，填入你的 SerpAPI 密钥：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使用说明

Web 搜索 MCP 服务器是核心组件，通过集成 SerpAPI 提供网页、新闻、产品搜索和问答工具。它处理传入请求，管理 API 调用，解析响应，并将结构化结果返回给客户端。

你可以查看完整实现 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

### 启动服务器

启动 MCP 服务器，使用以下命令：

```bash
python server.py
```

服务器将作为基于 stdio 的 MCP 服务器运行，客户端可直接连接。

### 客户端模式

客户端（`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

### 运行客户端

运行自动化测试（会自动启动服务器）：

```bash
python client.py
```

或者以交互模式运行：

```bash
python client.py --interactive
```

### 使用不同方式测试

根据你的需求和工作流程，有多种方式测试和交互服务器提供的工具。

#### 使用 MCP Python SDK 编写自定义测试脚本
你也可以使用 MCP Python SDK 编写自己的测试脚本：

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

这里的“测试脚本”指的是你编写的自定义 Python 程序，作为 MCP 服务器的客户端。它不是正式的单元测试，而是允许你以编程方式连接服务器，调用任意工具并传入自定义参数，检查结果。此方法适合：

- 快速原型开发和工具调用实验
- 验证服务器对不同输入的响应
- 自动化重复的工具调用
- 在 MCP 服务器基础上构建自己的工作流或集成

你可以用测试脚本快速尝试新查询，调试工具行为，甚至作为更高级自动化的起点。下面是使用 MCP Python SDK 创建此类脚本的示例：

## 工具说明

服务器提供以下工具，用于执行不同类型的搜索和查询。每个工具都附有参数说明和示例用法。

本节详细介绍每个可用工具及其参数。

### general_search

执行通用网页搜索并返回格式化结果。

**如何调用此工具：**

你可以通过 MCP Python SDK 从自己的脚本调用 `general_search`，或在 Inspector 或交互式客户端模式下交互调用。以下是使用 SDK 的代码示例：

<details>
<summary>Python 示例</summary>

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

或者，在交互模式下，选择 `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字符串）：搜索查询

**示例请求：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

搜索与查询相关的最新新闻文章。

**如何调用此工具：**

你可以通过 MCP Python SDK 从自己的脚本调用 `news_search`，或在 Inspector 或交互式客户端模式下交互调用。以下是使用 SDK 的代码示例：

<details>
<summary>Python 示例</summary>

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

或者，在交互模式下，选择 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字符串）：搜索查询

**示例请求：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

搜索与查询匹配的产品。

**如何调用此工具：**

你可以通过 MCP Python SDK 从自己的脚本调用 `product_search`，或在 Inspector 或交互式客户端模式下交互调用。以下是使用 SDK 的代码示例：

<details>
<summary>Python 示例</summary>

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

或者，在交互模式下，选择 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字符串）：产品搜索查询

**示例请求：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

从搜索引擎获取问题的直接答案。

**如何调用此工具：**

你可以通过 MCP Python SDK 从自己的脚本调用 `qna`，或在 Inspector 或交互式客户端模式下交互调用。以下是使用 SDK 的代码示例：

<details>
<summary>Python 示例</summary>

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

或者，在交互模式下，选择 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question`（字符串）：需要回答的问题

**示例请求：**

```json
{
  "question": "what is artificial intelligence"
}
```

## 代码详情

本节提供服务器和客户端实现的代码片段和参考。

<details>
<summary>Python</summary>

完整实现详见 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 本课中的高级概念

开始构建之前，这里介绍本章中会涉及的一些重要高级概念。理解它们将帮助你更好地跟进内容，即使你是第一次接触：

- **多工具协调**：在单一 MCP 服务器中运行多个不同工具（如网页搜索、新闻搜索、产品搜索和问答）。这使服务器能够处理多样化任务，而非单一功能。
- **API 速率限制处理**：许多外部 API（如 SerpAPI）限制单位时间内的请求次数。优秀代码会检测这些限制并优雅处理，避免应用崩溃。
- **结构化数据解析**：API 响应通常复杂且嵌套。该概念指将响应转换为干净、易用且适合 LLM 或其他程序处理的格式。
- **错误恢复**：有时会出现网络故障或 API 返回异常数据。错误恢复意味着代码能应对这些问题，提供有用反馈，而非崩溃。
- **参数验证**：检查传入工具的所有输入是否正确且安全使用，包括设置默认值和类型检查，有助于避免错误和混淆。

本节还帮助你诊断和解决使用 Web 搜索 MCP 服务器时可能遇到的常见问题。遇到错误或异常行为时，先查看本节，许多问题可以快速解决。

## 故障排查

使用 Web 搜索 MCP 服务器时，偶尔会遇到问题——这是使用外部 API 和新工具时的正常现象。本节提供常见问题的实用解决方案，帮助你快速恢复。如果遇到错误，请从这里开始：以下建议涵盖大多数用户遇到的问题，通常能在无需额外帮助的情况下解决。

### 常见问题

以下是用户最常遇到的问题，附带清晰解释和解决步骤：

1. **.env 文件中缺少 SERPAPI_KEY**
   - 如果出现错误 `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``，请确认 `.env` 文件存在且正确设置。如果密钥正确但仍报错，检查免费套餐配额是否已用尽。

### 调试模式

默认情况下，应用只记录重要信息。如果你想查看更多细节（例如诊断复杂问题），可以启用 DEBUG 模式。这样会显示应用执行的更多步骤细节。

**示例：正常输出**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**示例：DEBUG 输出**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

注意 DEBUG 模式包含额外的 HTTP 请求、响应和其他内部细节，非常有助于故障排查。

启用 DEBUG 模式，请在 `client.py` or `server.py` 顶部将日志级别设置为 DEBUG：

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

## 后续内容

- [6. 社区贡献](../../06-CommunityContributions/README.md)

**免责声明**：  
本文件使用AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)进行翻译。尽管我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始语言版本的文件应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或曲解，我们不承担任何责任。