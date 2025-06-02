<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:09:33+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ne"
}
-->
# Lesson: Building a Web Search MCP Server


This chapter shows how to create a real-world AI agent that connects with external APIs, handles various data types, manages errors, and coordinates multiple tools—all ready for production. You'll learn about:

- **Integrating external APIs that require authentication**
- **Handling different data types from multiple endpoints**
- **Strong error handling and logging methods**
- **Coordinating multiple tools within one server**

By the end, you'll gain hands-on experience with patterns and best practices crucial for advanced AI and LLM-powered applications.

## Introduction

In this lesson, you'll learn how to build an advanced MCP server and client that enhance LLM capabilities with real-time web data using SerpAPI. This skill is essential for developing dynamic AI agents that access up-to-date web information.

## Learning Objectives

By the end of this lesson, you will be able to:

- Securely integrate external APIs (like SerpAPI) into an MCP server
- Implement multiple tools for web, news, product searches, and Q&A
- Parse and format structured data for LLM use
- Effectively handle errors and manage API rate limits
- Build and test both automated and interactive MCP clients

## Web Search MCP Server

This section covers the architecture and features of the Web Search MCP Server. You'll see how FastMCP and SerpAPI work together to extend LLM capabilities with real-time web data.

### Overview

This implementation includes four tools demonstrating MCP's ability to securely and efficiently manage diverse external API-driven tasks:

- **general_search**: For broad web results
- **news_search**: For recent headlines
- **product_search**: For e-commerce data
- **qna**: For question-and-answer snippets

### Features
- **Code Examples**: Contains language-specific code blocks for Python (easily extendable to other languages) using collapsible sections for clarity

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

Before running the client, it’s helpful to understand what the server does. See the [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Here’s a brief example of how the server defines and registers a tool:

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

- **External API Integration**: Demonstrates secure handling of API keys and external requests
- **Structured Data Parsing**: Shows how to convert API responses into LLM-friendly formats
- **Error Handling**: Robust error handling with proper logging
- **Interactive Client**: Includes automated tests and an interactive mode for testing
- **Context Management**: Uses MCP Context for logging and tracking requests

## Prerequisites

Before starting, ensure your environment is properly set up by following these steps. This guarantees all dependencies are installed and your API keys are correctly configured for smooth development and testing.

- Python 3.8 or newer
- SerpAPI API Key (Sign up at [SerpAPI](https://serpapi.com/) - free tier available)

## Installation

To get started, follow these steps to set up your environment:

1. Install dependencies using uv (recommended) or pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Create a `.env` file in the project root with your SerpAPI key:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Usage

The Web Search MCP Server is the main component exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Running the Server

To start the MCP server, run the following command:

```bash
python server.py
```

The server will run as a stdio-based MCP server that the client connects to directly.

### Client Modes

The client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Running the Client

To run automated tests (this will start the server automatically):

```bash
python client.py
```

Or run in interactive mode:

```bash
python client.py --interactive
```

### Testing with Different Methods

There are several ways to test and interact with the server’s tools, depending on your needs and workflow.

#### Writing Custom Test Scripts with the MCP Python SDK
You can also create your own test scripts using the MCP Python SDK:

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


Here, a "test script" is a custom Python program you write to act as a client for the MCP server. Instead of formal unit tests, this script lets you programmatically connect to the server, call its tools with parameters you choose, and inspect results. This approach is useful for:
- Prototyping and experimenting with tool calls
- Checking how the server responds to various inputs
- Automating repeated tool calls
- Building your own workflows or integrations on top of the MCP server

You can quickly try new queries, debug tool behavior, or use this as a base for more advanced automation. Below is an example of using the MCP Python SDK to create such a script:

## Tool Descriptions

The server provides several tools for different search and query types. Each tool is described below with its parameters and example usage.

This section details each available tool and their parameters.

### general_search

Performs a general web search and returns formatted results.

**How to call this tool:**

You can call `general_search` from your script using the MCP Python SDK, or interactively via the Inspector or interactive client mode. Here’s a code example using the SDK:

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

Alternatively, in interactive mode, select `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): The search query

**Example Request:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Searches for recent news articles related to a query.

**How to call this tool:**

You can call `news_search` from your script using the MCP Python SDK, or interactively via the Inspector or interactive client mode. Here’s a code example using the SDK:

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

Alternatively, in interactive mode, select `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): The search query

**Example Request:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Searches for products matching a query.

**How to call this tool:**

You can call `product_search` from your script using the MCP Python SDK, or interactively via the Inspector or interactive client mode. Here’s a code example using the SDK:

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

Alternatively, in interactive mode, select `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): The product search query

**Example Request:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Retrieves direct answers to questions from search engines.

**How to call this tool:**

You can call `qna` from your script using the MCP Python SDK, or interactively via the Inspector or interactive client mode. Here’s a code example using the SDK:

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

Alternatively, in interactive mode, select `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): The question to find an answer for

**Example Request:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Code Details

This section contains code snippets and references for the server and client implementations.

<details>
<summary>Python</summary>

See [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) for full implementation details.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Advanced Concepts in This Lesson

Before building, here are key advanced concepts that will appear throughout this chapter. Understanding them will help you follow along, even if you’re new:

- **Multi-tool Orchestration**: Running multiple tools (web search, news, product search, Q&A) inside one MCP server, allowing it to handle various tasks instead of just one.
- **API Rate Limit Handling**: Many external APIs (like SerpAPI) restrict how many requests you can make in a given time. Good code detects these limits and handles them gracefully, so your app doesn’t break when limits are reached.
- **Structured Data Parsing**: API responses are often complex and nested. This concept involves converting those responses into clean, easy-to-use formats friendly for LLMs or other programs.
- **Error Recovery**: Sometimes things go wrong—like network failures or unexpected API responses. Error recovery means your code handles these problems and still provides useful feedback, instead of crashing.
- **Parameter Validation**: Checking that all inputs to your tools are correct and safe to use. This includes setting default values and verifying types, which helps avoid bugs and confusion.

This section will help you diagnose and fix common issues with the Web Search MCP Server. If you encounter errors or unexpected behavior, this troubleshooting guide offers solutions to the most frequent problems. Check these tips before seeking further help—they often resolve issues quickly.

## Troubleshooting

When working with the Web Search MCP Server, you might occasionally face issues—this is normal when developing with external APIs and new tools. This section offers practical fixes for common problems, helping you get back on track fast. If you get an error, start here: these tips address the issues most users face and often fix your problem without extra help.

### Common Issues

Here are some frequent problems users encounter, along with clear explanations and steps to fix them:

1. **Missing SERPAPI_KEY in .env file**
   - If you see the error `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` file if needed. If your key is correct but you still get this error, check if your free tier quota has been used up.

### Debug Mode

By default, the app logs only important information. To see more details (for example, to troubleshoot tricky issues), enable DEBUG mode. This shows much more about each step the app takes.

**Example: Normal Output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Example: DEBUG Output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Note how DEBUG mode includes extra lines about HTTP requests, responses, and other internal details. This is very useful for troubleshooting.

To enable DEBUG mode, set the logging level to DEBUG at the top of your `client.py` or `server.py`:

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

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको लागि प्रयासरत छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुनसक्छन्। मूल दस्तावेज़लाई यसको मूल भाषामा आधिकारिक स्रोतको रूपमा मान्नुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।