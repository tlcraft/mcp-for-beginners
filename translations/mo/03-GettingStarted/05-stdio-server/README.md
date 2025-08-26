<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:21:12+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "mo"
}
-->
# MCP 伺服器與 stdio 傳輸

> **⚠️ 重要更新**：自 MCP 規範 2025-06-18 起，獨立的 SSE（伺服器推送事件）傳輸已被 **棄用**，並由「可流式 HTTP」傳輸取代。目前的 MCP 規範定義了兩種主要的傳輸機制：
> 1. **stdio** - 標準輸入/輸出（建議用於本地伺服器）
> 2. **可流式 HTTP** - 用於可能內部使用 SSE 的遠端伺服器
>
> 本課程已更新為專注於 **stdio 傳輸**，這是大多數 MCP 伺服器實作的推薦方法。

stdio 傳輸允許 MCP 伺服器通過標準輸入和輸出流與客戶端進行通信。這是目前 MCP 規範中最常用且推薦的傳輸機制，提供了一種簡單且高效的方式來構建 MCP 伺服器，並能輕鬆整合到各種客戶端應用中。

## 概述

本課程涵蓋如何使用 stdio 傳輸構建和使用 MCP 伺服器。

## 學習目標

完成本課程後，您將能夠：

- 使用 stdio 傳輸構建 MCP 伺服器。
- 使用 Inspector 調試 MCP 伺服器。
- 使用 Visual Studio Code 使用 MCP 伺服器。
- 理解目前的 MCP 傳輸機制以及推薦使用 stdio 的原因。

## stdio 傳輸 - 運作方式

stdio 傳輸是目前 MCP 規範（2025-06-18）支持的兩種傳輸類型之一。其運作方式如下：

- **簡單通信**：伺服器從標準輸入（`stdin`）讀取 JSON-RPC 消息，並將消息發送到標準輸出（`stdout`）。
- **基於進程**：客戶端以子進程的形式啟動 MCP 伺服器。
- **消息格式**：消息是獨立的 JSON-RPC 請求、通知或回應，以換行符分隔。
- **日誌記錄**：伺服器可以選擇性地將 UTF-8 字符串寫入標準錯誤（`stderr`）進行日誌記錄。

### 關鍵要求：
- 消息必須以換行符分隔，且不得包含嵌入的換行符。
- 伺服器不得向 `stdout` 寫入任何非有效的 MCP 消息。
- 客戶端不得向伺服器的 `stdin` 寫入任何非有效的 MCP 消息。

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

在上述程式碼中：

- 我們從 MCP SDK 中匯入 `Server` 類和 `StdioServerTransport`。
- 我們使用基本配置和功能創建伺服器實例。

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

在上述程式碼中，我們：

- 使用 MCP SDK 創建伺服器實例。
- 使用裝飾器定義工具。
- 使用 stdio_server 上下文管理器處理傳輸。

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

與 SSE 的主要區別在於 stdio 伺服器：

- 不需要設置網頁伺服器或 HTTP 端點。
- 由客戶端以子進程形式啟動。
- 通過 stdin/stdout 流進行通信。
- 更易於實作和調試。

## 練習：創建一個 stdio 伺服器

要創建伺服器，我們需要注意以下兩點：

- 我們需要使用網頁伺服器來暴露端點以進行連接和消息傳遞。

## 實驗：創建一個簡單的 MCP stdio 伺服器

在本實驗中，我們將使用推薦的 stdio 傳輸創建一個簡單的 MCP 伺服器。此伺服器將暴露工具，客戶端可以使用標準的 Model Context Protocol 調用這些工具。

### 前置條件

- Python 3.8 或更高版本
- MCP Python SDK：`pip install mcp`
- 基本的異步編程知識

讓我們開始創建第一個 MCP stdio 伺服器：

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## 與棄用的 SSE 方法的主要區別

**Stdio 傳輸（目前標準）：**
- 簡單的子進程模型 - 客戶端以子進程形式啟動伺服器。
- 通過 stdin/stdout 使用 JSON-RPC 消息進行通信。
- 不需要設置 HTTP 伺服器。
- 性能和安全性更佳。
- 更易於調試和開發。

**SSE 傳輸（自 MCP 2025-06-18 起棄用）：**
- 需要具有 SSE 端點的 HTTP 伺服器。
- 使用網頁伺服器基礎設施設置更為複雜。
- HTTP 端點的額外安全考量。
- 現已被可流式 HTTP 取代，用於基於網頁的場景。

### 使用 stdio 傳輸創建伺服器

要創建 stdio 伺服器，我們需要：

1. **匯入所需的庫** - 我們需要 MCP 伺服器組件和 stdio 傳輸。
2. **創建伺服器實例** - 定義伺服器及其功能。
3. **定義工具** - 添加我們希望暴露的功能。
4. **設置傳輸** - 配置 stdio 通信。
5. **運行伺服器** - 啟動伺服器並處理消息。

讓我們逐步構建：

### 第一步：創建基本的 stdio 伺服器

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### 第二步：添加更多工具

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### 第三步：運行伺服器

將程式碼保存為 `server.py`，並從命令行運行：

```bash
python server.py
```

伺服器將啟動並等待來自 stdin 的輸入。它通過 stdio 傳輸使用 JSON-RPC 消息進行通信。

### 第四步：使用 Inspector 測試

您可以使用 MCP Inspector 測試伺服器：

1. 安裝 Inspector：`npx @modelcontextprotocol/inspector`
2. 運行 Inspector 並指向您的伺服器。
3. 測試您創建的工具。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// 添加工具
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "獲取個性化問候語",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "需要問候的人的名字",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `你好，${request.params.arguments?.name}！歡迎使用 MCP stdio 伺服器。`,
        },
      ],
    };
  } else {
    throw new Error(`未知工具：${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("獲取個性化問候語")]
    public string GetGreeting(string name)
    {
        return $"你好，{name}！歡迎使用 MCP stdio 伺服器。";
    }

    [Description("計算兩個數字的和")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. 讓我們先創建一些工具，為此我們將創建一個名為 *Tools.cs* 的文件，內容如下：

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **打開網頁界面**：Inspector 將打開一個瀏覽器窗口，顯示伺服器的功能。

3. **測試工具**：
   - 嘗試使用不同的名字測試 `get_greeting` 工具。
   - 使用各種數字測試 `calculate_sum` 工具。
   - 調用 `get_server_info` 工具查看伺服器元數據。

4. **監控通信**：Inspector 顯示客戶端和伺服器之間交換的 JSON-RPC 消息。

### 您應該看到的內容

當伺服器正確啟動時，您應該看到：
- Inspector 中列出的伺服器功能。
- 可供測試的工具。
- 成功的 JSON-RPC 消息交換。
- 工具回應顯示在界面中。

### 常見問題及解決方案

**伺服器無法啟動：**
- 確保所有依賴項已安裝：`pip install mcp`
- 驗證 Python 語法和縮排。
- 查看控制台中的錯誤消息。

**工具未顯示：**
- 確保使用了 `@server.tool()` 裝飾器。
- 確保工具函數在 `main()` 之前定義。
- 驗證伺服器是否正確配置。

**連接問題：**
- 確保伺服器正確使用 stdio 傳輸。
- 檢查是否有其他進程干擾。
- 驗證 Inspector 命令語法。

## 作業

嘗試為您的伺服器添加更多功能。參考 [此頁面](https://api.chucknorris.io/)，例如添加一個調用 API 的工具。您可以決定伺服器的外觀。祝您玩得愉快 :)

## 解決方案

[解決方案](./solution/README.md) 提供了一個可能的解決方案及其工作程式碼。

## 關鍵要點

本章的關鍵要點如下：

- stdio 傳輸是本地 MCP 伺服器的推薦機制。
- stdio 傳輸允許 MCP 伺服器和客戶端通過標準輸入和輸出流進行無縫通信。
- 您可以直接使用 Inspector 和 Visual Studio Code 使用 stdio 伺服器，使調試和整合變得簡單。

## 範例

- [Java 計算器](../samples/java/calculator/README.md)
- [.Net 計算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](../samples/javascript/README.md)
- [TypeScript 計算器](../samples/typescript/README.md)
- [Python 計算器](../../../../03-GettingStarted/samples/python) 

## 其他資源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 下一步

## 下一步行動

現在您已學會如何使用 stdio 傳輸構建 MCP 伺服器，您可以探索更高級的主題：

- **下一步**：[MCP 的 HTTP 流式傳輸（可流式 HTTP）](../06-http-streaming/README.md) - 學習另一種支持的遠端伺服器傳輸機制。
- **進階**：[MCP 安全最佳實踐](../../02-Security/README.md) - 在 MCP 伺服器中實施安全性。
- **生產環境**：[部署策略](../09-deployment/README.md) - 部署伺服器以供生產使用。

## 其他資源

- [MCP 規範 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - 官方規範。
- [MCP SDK 文件](https://github.com/modelcontextprotocol/sdk) - 各語言的 SDK 參考。
- [社群範例](../../06-CommunityContributions/README.md) - 更多來自社群的伺服器範例。

---

**免責聲明**：  
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於關鍵資訊，建議尋求專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或錯誤解釋不承擔責任。