<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:28:03+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "zh"
}
-->
# Model Context Protocol (MCP) Python 实现

本仓库包含了 Model Context Protocol (MCP) 的 Python 实现，演示了如何创建同时作为服务器和客户端的应用程序，通过 MCP 标准进行通信。

## 概述

MCP 实现由两个主要部分组成：

1. **MCP Server (`server.py`)** - 一个服务器，提供：
   - **工具**：可远程调用的函数
   - **资源**：可获取的数据
   - **提示模板**：用于生成语言模型提示的模板

2. **MCP Client (`client.py`)** - 一个客户端应用，连接服务器并使用其功能

## 功能

该实现演示了几个关键的 MCP 功能：

### 工具
- `completion` - 生成 AI 模型的文本补全（模拟）
- `add` - 简单计算器，执行两个数字相加

### 资源
- `models://` - 返回可用 AI 模型的信息
- `greeting://{name}` - 根据给定名字返回个性化问候语

### 提示模板
- `review_code` - 生成代码审查的提示模板

## 安装

使用此 MCP 实现前，请安装所需的依赖包：

```powershell
pip install mcp-server mcp-client
```

## 运行服务器和客户端

### 启动服务器

在一个终端窗口运行服务器：

```powershell
python server.py
```

服务器也可以通过 MCP CLI 以开发模式运行：

```powershell
mcp dev server.py
```

或者安装到 Claude Desktop（如果可用）：

```powershell
mcp install server.py
```

### 运行客户端

在另一个终端窗口运行客户端：

```powershell
python client.py
```

这将连接服务器并演示所有可用功能。

### 客户端使用

客户端 (`client.py`) 演示了所有 MCP 功能：

```powershell
python client.py
```

这会连接服务器并调用所有功能，包括工具、资源和提示模板。输出内容包括：

1. 计算器工具结果（5 + 7 = 12）
2. 补全文本工具对“生命的意义是什么？”的回答
3. 可用 AI 模型列表
4. 针对“MCP Explorer”的个性化问候
5. 代码审查提示模板

## 实现细节

服务器使用 `FastMCP` API 实现，提供了定义 MCP 服务的高级抽象。以下是定义工具的简化示例：

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

客户端使用 MCP 客户端库连接并调用服务器：

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## 了解更多

有关 MCP 的更多信息，请访问：https://modelcontextprotocol.io/

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译而成。尽管我们努力确保准确性，但请注意自动翻译可能存在错误或不准确之处。原始文件的原文版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。