<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T21:06:58+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tw"
}
-->
# 建立客戶端

客戶端是自訂的應用程式或腳本，直接與 MCP Server 通訊以請求資源、工具和提示。與使用提供圖形介面的檢查工具不同，自己撰寫客戶端可以進行程式化和自動化的互動。這讓開發者能將 MCP 功能整合到自己的工作流程中，自動化任務，並打造符合特定需求的客製化解決方案。

## 概述

本課程介紹 Model Context Protocol (MCP) 生態系中的客戶端概念。你將學會如何撰寫自己的客戶端並連接到 MCP Server。

## 學習目標

完成本課程後，你將能夠：

- 了解客戶端的功能。
- 撰寫自己的客戶端。
- 連接並測試客戶端與 MCP Server，確保伺服器運作正常。

## 撰寫客戶端需要做什麼？

撰寫客戶端時，你需要：

- **匯入正確的函式庫**。你會使用之前相同的函式庫，但使用不同的結構。
- **實例化客戶端**。這包括建立客戶端實例並連接到選定的傳輸方式。
- **決定要列出哪些資源**。你的 MCP Server 有資源、工具和提示，你需要決定要列出哪些。
- **將客戶端整合到主機應用程式中**。了解伺服器功能後，需將客戶端整合到主機應用程式，讓使用者輸入提示或指令時，能呼叫對應的伺服器功能。

了解整體流程後，接下來來看一個範例。

### 範例客戶端

來看看這個範例客戶端：

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

上述程式碼中，我們：

- 匯入函式庫
- 建立客戶端實例並使用 stdio 作為傳輸方式連接
- 列出提示、資源和工具，並呼叫它們

這樣就完成了一個能與 MCP Server 通訊的客戶端。

接下來的練習部分，我們會逐段拆解程式碼並說明細節。

## 練習：撰寫客戶端

如前所述，我們會慢慢解釋程式碼，歡迎跟著一起寫。

### -1- 匯入函式庫

先匯入所需函式庫，我們需要客戶端和選定的傳輸協定 stdio。stdio 是用於本機執行的協定。SSE 是另一種傳輸協定，未來章節會介紹，但目前先用 stdio。

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Java 部分，你將建立一個連接到前面練習中 MCP Server 的客戶端。使用 [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) 中相同的 Java Spring Boot 專案結構，在 `src/main/java/com/microsoft/mcp/sample/client/` 資料夾新增一個名為 `SDKClient` 的 Java 類別，並加入以下匯入：

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

接著進入實例化階段。

### -2- 實例化客戶端與傳輸

我們需要建立傳輸實例和客戶端實例：

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

上述程式碼中，我們：

- 建立 stdio 傳輸實例。注意它指定了啟動伺服器的指令和參數，這是建立客戶端時必須處理的。

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- 實例化客戶端，並給予名稱和版本。

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- 將客戶端連接到選定的傳輸。

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

上述程式碼中，我們：

- 匯入所需函式庫
- 實例化伺服器參數物件，用來啟動伺服器以便客戶端連接
- 定義 `run` 方法，呼叫 `stdio_client` 啟動客戶端會話
- 建立入口點，使用 `asyncio.run` 執行 `run` 方法

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

上述程式碼中，我們：

- 匯入所需函式庫
- 建立 stdio 傳輸並建立名為 `mcpClient` 的客戶端，後者用於列出和呼叫 MCP Server 的功能

注意，在「Arguments」中，你可以指定 *.csproj* 或執行檔。

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

上述程式碼中，我們：

- 建立 main 方法，設定 SSE 傳輸指向 `http://localhost:8080`，即 MCP Server 運行位置
- 建立客戶端類別，將傳輸作為建構子參數
- 在 `run` 方法中，使用傳輸建立同步 MCP 客戶端並初始化連線
- 使用 SSE（Server-Sent Events）傳輸，適合與 Java Spring Boot MCP Server 進行 HTTP 通訊

### -3- 列出伺服器功能

現在我們有一個能連接的客戶端，但還沒列出功能，接下來來做這件事：

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

這裡列出可用的資源 `list_resources()` 和工具 `list_tools`，並印出它們。

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

上面示範如何列出伺服器上的工具，並印出每個工具的名稱。

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

上述程式碼中，我們：

- 呼叫 `listTools()` 取得 MCP Server 上所有可用工具
- 使用 `ping()` 驗證與伺服器的連線是否正常
- `ListToolsResult` 包含所有工具的資訊，包括名稱、描述和輸入結構

很好，現在我們已取得所有功能。那麼什麼時候使用它們呢？這個客戶端很簡單，必須明確呼叫功能才能使用。下一章我們會建立更進階的客戶端，內建大型語言模型（LLM）。現在先來看看如何呼叫伺服器上的功能：

### -4- 呼叫功能

呼叫功能時，需確保指定正確的參數，有時還要指定要呼叫的名稱。

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

上述程式碼中，我們：

- 讀取資源，透過呼叫 `readResource()` 並指定 `uri`。伺服器端大致如下：

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    我們的 `uri` 值 `file://example.txt` 對應伺服器端的 `file://{name}`，`example.txt` 會被映射到 `name`。

- 呼叫工具，指定工具的 `name` 和 `arguments`，如下：

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- 取得提示，呼叫 `getPrompt()` 並帶入 `name` 和 `arguments`。伺服器端程式碼如下：

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    因此客戶端程式碼會是：

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

上述程式碼中，我們：

- 使用 `read_resource` 呼叫名為 `greeting` 的資源
- 使用 `call_tool` 呼叫名為 `add` 的工具

### C#

1. 新增呼叫工具的程式碼：

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. 印出結果的程式碼：

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

上述程式碼中，我們：

- 使用 `callTool()` 方法搭配 `CallToolRequest` 物件呼叫多個計算器工具
- 每次呼叫指定工具名稱及該工具所需的參數 `Map`
- 伺服器工具期望特定參數名稱（例如數學運算的 "a"、"b"）
- 回傳結果為包含伺服器回應的 `CallToolResult` 物件

### -5- 執行客戶端

在終端機輸入以下指令執行客戶端：

### TypeScript

在 *package.json* 的 "scripts" 區段新增以下內容：

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

使用以下指令呼叫客戶端：

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

先確定 MCP Server 正在 `http://localhost:8080` 運行，然後執行客戶端：

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

或者，你也可以執行解決方案資料夾 `03-GettingStarted\02-client\solution\java` 中的完整客戶端專案：

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 作業

這次作業中，你將運用所學建立自己的客戶端。

這裡有一個伺服器可供你使用，請透過客戶端呼叫它，並嘗試為伺服器新增更多功能，讓它更有趣。

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

參考此專案了解如何[新增提示和資源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)。

另外，查看此連結了解如何呼叫[提示和資源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)。

## 解答

[解答](./solution/README.md)

## 重要重點

本章關於客戶端的重點如下：

- 可用來發現並呼叫伺服器上的功能。
- 可在啟動自身時同時啟動伺服器（如本章示範），也能連接已在運行的伺服器。
- 是測試伺服器功能的好方法，與前章介紹的 Inspector 等工具互補。

## 其他資源

- [在 MCP 中建立客戶端](https://modelcontextprotocol.io/quickstart/client)

## 範例

- [Java 計算器](../samples/java/calculator/README.md)
- [.Net 計算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](../samples/javascript/README.md)
- [TypeScript 計算器](../samples/typescript/README.md)
- [Python 計算器](../../../../03-GettingStarted/samples/python)

## 下一步

- 下一章：[使用 LLM 建立客戶端](../03-llm-client/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。