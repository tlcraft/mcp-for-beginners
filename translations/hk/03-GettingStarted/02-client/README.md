<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "22afa94e3912cd37af9ff20cf4aebc93",
  "translation_date": "2025-07-22T07:23:48+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hk"
}
-->
# 建立客戶端

客戶端是自訂應用程式或腳本，直接與 MCP 伺服器溝通以請求資源、工具和提示。與使用檢查工具提供的圖形介面不同，撰寫自己的客戶端可以進行程式化和自動化的互動。這使得開發者能將 MCP 的功能整合到自己的工作流程中，自動化任務，並根據特定需求建立量身定制的解決方案。

## 概述

本課程介紹了 Model Context Protocol (MCP) 生態系統中的客戶端概念。您將學習如何撰寫自己的客戶端並將其連接到 MCP 伺服器。

## 學習目標

完成本課程後，您將能夠：

- 了解客戶端的功能。
- 撰寫自己的客戶端。
- 連接並測試客戶端與 MCP 伺服器，確保伺服器正常運作。

## 撰寫客戶端需要做什麼？

撰寫客戶端需要完成以下步驟：

- **匯入正確的函式庫**。您將使用之前相同的函式庫，但需要不同的結構。
- **實例化客戶端**。這包括建立客戶端實例並將其連接到選定的傳輸方法。
- **決定要列出的資源**。您的 MCP 伺服器提供資源、工具和提示，您需要決定列出哪一項。
- **將客戶端整合到主應用程式**。一旦了解伺服器的功能，您需要將其整合到主應用程式中，讓使用者輸入提示或其他指令時，能觸發相應的伺服器功能。

現在我們已經了解了高層次的概念，接下來讓我們看一個範例。

### 客戶端範例

以下是一個客戶端範例：

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

在上述程式碼中，我們：

- 匯入函式庫。
- 建立客戶端實例並使用 stdio 作為傳輸方式進行連接。
- 列出提示、資源和工具並全部調用。

這樣就完成了一個可以與 MCP 伺服器溝通的客戶端。

接下來的練習部分，我們將逐段解析程式碼並解釋其運作。

## 練習：撰寫客戶端

如上所述，我們將逐步解釋程式碼，並且如果您願意，可以跟著一起撰寫。

### -1- 匯入函式庫

首先匯入我們需要的函式庫，我們需要引用客戶端和選定的傳輸協議 stdio。stdio 是一種適合在本地機器上運行的協議。SSE 是另一種傳輸協議，我們會在後續章節中展示，但目前我們先使用 stdio。

#### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

#### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

#### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

#### Java

對於 Java，您將建立一個客戶端，連接到之前練習中的 MCP 伺服器。使用 [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) 中的 Java Spring Boot 專案結構，建立一個名為 `SDKClient` 的 Java 類，並將其放置在 `src/main/java/com/microsoft/mcp/sample/client/` 資料夾中，然後添加以下匯入：

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

接下來進行實例化。

### -2- 實例化客戶端和傳輸

我們需要建立傳輸實例以及客戶端實例：

#### TypeScript

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

在上述程式碼中，我們：

- 建立了一個 stdio 傳輸實例。注意它如何指定命令和參數以找到並啟動伺服器，這是我們在建立客戶端時需要做的。

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- 實例化了一個客戶端，並為其指定名稱和版本。

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- 將客戶端連接到選定的傳輸方式。

    ```typescript
    await client.connect(transport);
    ```

#### Python

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

在上述程式碼中，我們：

- 匯入所需的函式庫。
- 實例化伺服器參數物件，因為我們需要使用它來啟動伺服器，以便能用客戶端連接。
- 定義了一個方法 `run`，該方法調用 `stdio_client` 以啟動客戶端會話。
- 建立了一個入口點，將 `run` 方法提供給 `asyncio.run`。

#### .NET

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

在上述程式碼中，我們：

- 匯入所需的函式庫。
- 建立了一個 stdio 傳輸並建立了一個客戶端 `mcpClient`。後者將用於列出和調用 MCP 伺服器上的功能。

注意，在 "Arguments" 中，您可以指向 *.csproj* 或可執行檔。

#### Java

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

在上述程式碼中，我們：

- 建立了一個主方法，設置 SSE 傳輸，指向 MCP 伺服器運行的 `http://localhost:8080`。
- 建立了一個客戶端類，將傳輸作為建構函數參數。
- 在 `run` 方法中，使用傳輸建立了一個同步 MCP 客戶端並初始化連接。
- 使用 SSE (Server-Sent Events) 傳輸，適合與 Java Spring Boot MCP 伺服器進行基於 HTTP 的通信。

### -3- 列出伺服器功能

現在，我們有一個客戶端可以連接到伺服器，但它尚未列出伺服器的功能，因此接下來讓我們完成這部分：

#### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

#### Python

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

在這裡，我們列出了可用的資源 `list_resources()` 和工具 `list_tools`，並將它們打印出來。

#### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

以上是列出伺服器工具的範例。對於每個工具，我們打印出其名稱。

#### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

在上述程式碼中，我們：

- 調用了 `listTools()` 以獲取 MCP 伺服器上的所有可用工具。
- 使用 `ping()` 驗證與伺服器的連接是否正常。
- `ListToolsResult` 包含所有工具的資訊，包括名稱、描述和輸入結構。

很好，現在我們已經捕捉到所有功能。接下來的問題是何時使用它們？目前這個客戶端相對簡單，簡單的意思是我們需要在需要時顯式調用功能。在下一章中，我們將建立一個更高級的客戶端，該客戶端可以訪問自己的大型語言模型 (LLM)。但現在，讓我們看看如何調用伺服器上的功能：

### -4- 調用功能

要調用功能，我們需要確保指定正確的參數，有些情況下還需要指定要調用的名稱。

#### TypeScript

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

在上述程式碼中，我們：

- 讀取了一個資源，通過調用 `readResource()` 並指定 `uri`。以下是伺服器端的可能程式碼：

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

    我們的 `uri` 值 `file://example.txt` 與伺服器上的 `file://{name}` 匹配。`example.txt` 將映射到 `name`。

- 調用了一個工具，通過指定其 `name` 和 `arguments` 來調用：

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- 獲取提示，通過調用 `getPrompt()` 並提供 `name` 和 `arguments`。伺服器端程式碼如下：

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

    因此，客戶端程式碼如下，以匹配伺服器上聲明的內容：

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

#### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

在上述程式碼中，我們：

- 調用了名為 `greeting` 的資源，使用 `read_resource`。
- 調用了名為 `add` 的工具，使用 `call_tool`。

#### .NET

1. 添加一些程式碼以調用工具：

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. 打印結果，以下是處理結果的程式碼：

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

#### Java

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

在上述程式碼中，我們：

- 使用 `callTool()` 方法和 `CallToolRequest` 物件調用了多個計算器工具。
- 每次工具調用都指定工具名稱和工具所需的參數 `Map`。
- 伺服器工具期望特定的參數名稱（例如 "a" 和 "b" 用於數學運算）。
- 結果以 `CallToolResult` 物件的形式返回，包含伺服器的回應。

### -5- 運行客戶端

要運行客戶端，請在終端中輸入以下命令：

#### TypeScript

在 *package.json* 的 "scripts" 部分添加以下條目：

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

#### Python

使用以下命令調用客戶端：

```sh
python client.py
```

#### .NET

```sh
dotnet run
```

#### Java

首先，確保您的 MCP 伺服器正在 `http://localhost:8080` 運行。然後運行客戶端：

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

或者，您可以運行解決方案資料夾 `03-GettingStarted\02-client\solution\java` 中提供的完整客戶端專案：

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 作業

在此作業中，您將使用所學內容建立自己的客戶端。

以下是一個伺服器，您需要通過客戶端程式碼調用它，試著為伺服器添加更多功能，使其更有趣。

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

請參考此專案以了解如何 [添加提示和資源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)。

同時，查看此連結以了解如何調用 [提示和資源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)。

## 解決方案

**解決方案資料夾**包含完整、可運行的客戶端實現，展示了本教程涵蓋的所有概念。每個解決方案包括客戶端和伺服器程式碼，並以獨立的專案形式組織。

### 📁 解決方案結構

解決方案目錄按程式語言組織：

```text
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 每個解決方案包含的內容

每個語言特定的解決方案提供：

- **完整的客戶端實現**，包含本教程中的所有功能
- **工作專案結構**，具有適當的依賴項和配置
- **構建和運行腳本**，便於設置和執行
- **詳細的 README**，提供語言特定的指導
- **錯誤處理**和結果處理範例

### 📖 使用解決方案

1. **導航到您偏好的語言資料夾**：

   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **按照每個資料夾中的 README 指導**：
   - 安裝依賴項
   - 構建專案
   - 運行客戶端

3. **您應該看到的範例輸出**：

   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

有關完整文檔和逐步指導，請參閱：**[📖 解決方案文檔](./solution/README.md)**

## 🎯 完整範例

我們提供了所有程式語言的完整、可運行客戶端實現。這些範例展示了上述功能的完整實現，可作為參考或您自己專案的起點。

### 可用的完整範例

| 語言 | 檔案 | 描述 |
|------|------|------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | 使用 SSE 傳輸的完整 Java 客戶端，包含全面的錯誤處理 |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | 使用 stdio 傳輸的完整 C# 客戶端，包含自動伺服器啟動 |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | 完整的 TypeScript 客戶端，支持 MCP 協議 |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | 使用 async/await 模式的完整 Python 客戶端 |

每個完整範例包括：

- ✅ **建立連接**和錯誤處理
- ✅ **伺服器探索**（工具、資源、提示等）
- ✅ **計算器操作**（加、減、乘、除、幫助）
- ✅ **結果處理**和格式化輸出
- ✅ **全面的錯誤處理**
- ✅ **乾淨且有註解的程式碼**，逐步解釋

### 開始使用完整範例

1. **選擇您偏好的語言**，從上表中選擇
2. **查看完整範例檔案**，了解完整實現
3. **按照 [`complete_examples.md`](./complete_examples.md) 中的指導運行範例**
4. **修改並擴展**範例以適應您的特定需求

有關運行和自訂這些範例的詳細文檔，請參閱：**[📖 完整範例文檔](./complete_examples.md)**

### 💡 解決方案 vs. 完整範例

| **解決方案資料夾** | **完整範例** |
|--------------------|-------------|
| 完整的專案結構，包含構建檔案 | 單檔實現 |
| 可直接運行，包含依賴項 | 集中於程式碼範例 |
| 類似生產環境的設置 | 教學參考 |
| 語言特定工具 | 跨語言比較 |
兩種方法都很有價值——使用 **solution folder** 適合完整項目，而使用 **complete examples** 則適合學習和參考。

## 主要重點

本章的主要重點是關於客戶端的以下內容：

- 可用於發現和調用伺服器上的功能。
- 可以在自身啟動時啟動伺服器（如本章所述），但客戶端也可以連接到正在運行的伺服器。
- 是測試伺服器功能的絕佳方式，與上一章提到的 Inspector 等替代方案相比。

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
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為具權威性的來源。對於重要資訊，建議使用專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或錯誤解釋概不負責。