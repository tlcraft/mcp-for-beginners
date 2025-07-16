<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T21:08:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tw"
}
-->
# SSE 伺服器

SSE（Server Sent Events）是一種伺服器到客戶端的串流標準，允許伺服器透過 HTTP 推送即時更新給客戶端。這對於需要即時更新的應用程式非常有用，例如聊天應用、通知或即時資料串流。此外，您的伺服器可以同時被多個客戶端使用，因為它可以部署在雲端等任何地方。

## 概覽

本課程將介紹如何建立與使用 SSE 伺服器。

## 學習目標

完成本課程後，您將能夠：

- 建立 SSE 伺服器。
- 使用 Inspector 偵錯 SSE 伺服器。
- 使用 Visual Studio Code 使用 SSE 伺服器。

## SSE 運作原理

SSE 是兩種支援的傳輸類型之一。您之前的課程已經看過第一種 stdio 的使用。兩者的差異如下：

- SSE 需要您處理兩件事：連線與訊息。
- 由於這是可以部署在任何地方的伺服器，您需要在使用 Inspector 和 Visual Studio Code 等工具時反映這點。也就是說，您不再是指定如何啟動伺服器，而是指定可建立連線的端點。請參考以下範例程式碼：

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

在上述程式碼中：

- `/sse` 被設定為路由。當有請求到此路由時，會建立一個新的傳輸實例，伺服器會透過此傳輸進行*連線*。
- `/messages` 是處理傳入訊息的路由。

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

在上述程式碼中，我們：

- 建立一個 ASGI 伺服器實例（特別使用 Starlette）並掛載預設路由 `/`。

  背後的運作是 `/sse` 和 `/messages` 路由分別用來處理連線和訊息。其餘應用程式功能，如加入工具，則與 stdio 伺服器相同。

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    有兩個方法幫助我們從一般的網頁伺服器轉成支援 SSE 的伺服器：

    - `AddMcpServer`，此方法加入相關功能。
    - `MapMcp`，此方法加入像是 `/SSE` 和 `/messages` 的路由。

現在我們對 SSE 有更多了解了，接下來來建立一個 SSE 伺服器。

## 練習：建立 SSE 伺服器

建立伺服器時，我們需要記住兩件事：

- 需要使用網頁伺服器來公開連線與訊息的端點。
- 建立伺服器時，像使用 stdio 一樣使用工具、資源和提示。

### -1- 建立伺服器實例

建立伺服器時，我們使用與 stdio 相同的類型，但傳輸方式需選擇 SSE。

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

在上述程式碼中，我們：

- 建立了伺服器實例。
- 使用 express 建立應用程式。
- 建立一個 transports 變數，用來儲存傳入的連線。

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

在上述程式碼中，我們：

- 匯入所需的函式庫，並引入 Starlette（ASGI 框架）。
- 建立 MCP 伺服器實例 `mcp`。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

此時，我們已經：

- 建立了網頁應用程式。
- 透過 `AddMcpServer` 加入 MCP 功能支援。

接下來加入必要的路由。

### -2- 加入路由

接著加入處理連線與傳入訊息的路由：

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

在上述程式碼中，我們定義了：

- `/sse` 路由，建立 SSE 類型的傳輸，並呼叫 MCP 伺服器的 `connect`。
- `/messages` 路由，處理傳入訊息。

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

在上述程式碼中，我們：

- 使用 Starlette 框架建立 ASGI 應用程式實例，並將 `mcp.sse_app()` 傳入路由列表，這會在應用程式實例上掛載 `/sse` 和 `/messages` 路由。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

我們在最後加入了一行 `add.MapMcp()`，這表示現在有 `/SSE` 和 `/messages` 路由。

接下來為伺服器加入功能。

### -3- 加入伺服器功能

現在 SSE 相關設定完成，接著加入工具、提示和資源等伺服器功能。

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

以下示範如何加入一個工具。這個工具名為 "random-joke"，會呼叫 Chuck Norris API 並回傳 JSON 回應。

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

現在您的伺服器有一個工具了。

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. 先建立一些工具，為此我們建立一個檔案 *Tools.cs*，內容如下：

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  這裡我們做了以下事情：

  - 建立一個帶有 `McpServerToolType` 裝飾器的 `Tools` 類別。
  - 定義一個工具 `AddNumbers`，使用 `McpServerTool` 裝飾方法，並提供參數與實作。

1. 接著使用剛建立的 `Tools` 類別：

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  我們加入了 `WithTools` 呼叫，指定 `Tools` 為包含工具的類別。就這樣，準備完成。

太棒了，我們有一個使用 SSE 的伺服器，接下來來試試看。

## 練習：使用 Inspector 偵錯 SSE 伺服器

Inspector 是一個很棒的工具，我們在之前的課程 [建立您的第一個伺服器](/03-GettingStarted/01-first-server/README.md) 中已經看過。現在看看是否也能用在這裡：

### -1- 執行 Inspector

要執行 Inspector，您必須先啟動 SSE 伺服器，接著：

1. 啟動伺服器

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    注意我們使用了 `uvicorn` 可執行檔，這是在執行 `pip install "mcp[cli]"` 時安裝的。`server:app` 表示我們嘗試執行 `server.py` 檔案，且該檔案中有一個名為 `app` 的 Starlette 實例。

    ### .NET

    ```sh
    dotnet run
    ```

    這樣應該會啟動伺服器。要與它互動，您需要開啟另一個終端機視窗。

1. 執行 Inspector

    > ![NOTE]
    > 請在與伺服器不同的終端機視窗執行此指令。並且請根據您的伺服器 URL 調整以下指令。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    在所有執行環境中，執行 Inspector 的方式相同。注意，我們不是傳入伺服器的路徑和啟動指令，而是傳入伺服器運行的 URL，並指定 `/sse` 路由。

### -2- 試用工具

在下拉選單中選擇 SSE，並填入您的伺服器 URL，例如 http:localhost:4321/sse。接著點擊「Connect」按鈕。和之前一樣，選擇列出工具、選擇工具並輸入參數。您應該會看到如下結果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tw.png)

太棒了，您已能使用 Inspector，接下來看看如何使用 Visual Studio Code。

## 作業

嘗試為您的伺服器加入更多功能。參考 [這個網站](https://api.chucknorris.io/) 來新增一個呼叫 API 的工具。伺服器的樣貌由您決定，祝您玩得開心 :)

## 解答

[解答](./solution/README.md) 這裡有一個可運作的範例程式碼解答。

## 重要重點

本章節的重點如下：

- SSE 是繼 stdio 之後支援的第二種傳輸方式。
- 支援 SSE 需要使用網頁框架管理傳入的連線與訊息。
- 您可以使用 Inspector 和 Visual Studio Code 來使用 SSE 伺服器，就像 stdio 伺服器一樣。注意 stdio 與 SSE 之間有些差異。SSE 需要先啟動伺服器，再執行 Inspector 工具。Inspector 工具也需要指定 URL。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python) 

## 其他資源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 接下來

- 下一課：[使用 MCP 的 HTTP 串流（Streamable HTTP）](../06-http-streaming/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。