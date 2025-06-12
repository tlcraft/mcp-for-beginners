<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:20:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

下面介绍如何使用 Python 运行经典的 HTTP 流式服务器和客户端，以及 MCP 流式服务器和客户端。

### 概述

- 你将搭建一个 MCP 服务器，在处理项目时向客户端推送进度通知。
- 客户端会实时显示每条通知。
- 本指南涵盖前提条件、设置、运行及故障排除。

### 前提条件

- Python 3.9 或更高版本
- `mcp` Python 包（使用 `pip install mcp` 安装）

### 安装与设置

1. 克隆仓库或下载解决方案文件。

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **创建并激活虚拟环境（推荐）：**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **安装所需依赖：**

   ```pwsh
   pip install "mcp[cli]"
   ```

### 文件

- **服务器：** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **客户端：** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### 运行经典 HTTP 流式服务器

1. 进入解决方案目录：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. 启动经典 HTTP 流式服务器：

   ```pwsh
   python server.py
   ```

3. 服务器启动后会显示：

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### 运行经典 HTTP 流式客户端

1. 打开一个新的终端（激活相同的虚拟环境和目录）：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. 你将看到依次打印的流式消息：

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### 运行 MCP 流式服务器

1. 进入解决方案目录：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. 使用 streamable-http 传输启动 MCP 服务器：
   ```pwsh
   python server.py mcp
   ```
3. 服务器启动后会显示：
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### 运行 MCP 流式客户端

1. 打开一个新的终端（激活相同的虚拟环境和目录）：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. 你将看到服务器处理每个项目时实时打印的通知：
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### 关键实现步骤

1. **使用 FastMCP 创建 MCP 服务器。**
2. **定义一个处理列表并通过 `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` 发送通知的工具，实现非阻塞操作。**
- 始终在服务器和客户端处理异常，确保程序健壮。
- 通过多个客户端测试以观察实时更新效果。
- 遇到错误时，请检查 Python 版本并确保所有依赖已安装。

**免责声明**：  
本文件已使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们不承担任何责任。