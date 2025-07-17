<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T21:39:07+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ja"
}
-->
# SSEサーバー

SSE（Server Sent Events）は、サーバーからクライアントへのストリーミングの標準であり、サーバーがHTTPを通じてリアルタイムの更新をクライアントにプッシュすることを可能にします。これは、チャットアプリケーション、通知、リアルタイムデータフィードなど、ライブアップデートが必要なアプリケーションに特に役立ちます。また、サーバーはクラウド上などどこかで実行できるため、複数のクライアントが同時に利用することも可能です。

## 概要

このレッスンでは、SSEサーバーの構築と利用方法について学びます。

## 学習目標

このレッスンの終わりまでに、以下ができるようになります：

- SSEサーバーを構築する。
- Inspectorを使ってSSEサーバーをデバッグする。
- Visual Studio Codeを使ってSSEサーバーを利用する。

## SSEの仕組み

SSEはサポートされている2つのトランスポートタイプのうちの一つです。前のレッスンで使ったstdioが最初のタイプでした。違いは以下の通りです：

- SSEでは、接続とメッセージの2つを扱う必要があります。
- サーバーはどこにでも存在できるため、InspectorやVisual Studio Codeのようなツールの使い方にもそれが反映されます。つまり、サーバーの起動方法を指定するのではなく、接続を確立できるエンドポイントを指定します。以下の例コードを参照してください。

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

上記のコードでは：

- `/sse`がルートとして設定されています。このルートにリクエストが来ると、新しいトランスポートインスタンスが作成され、サーバーはこのトランスポートを使って*接続*します。
- `/messages`は、受信メッセージを処理するルートです。

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

上記のコードでは：

- ASGIサーバーのインスタンス（特にStarletteを使用）を作成し、デフォルトルート`/`にマウントしています。

  裏側では、`/sse`と`/messages`のルートがそれぞれ接続とメッセージの処理に設定されています。その他の機能追加はstdioサーバーと同様に行います。

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

    WebサーバーからSSE対応のWebサーバーにするための2つのメソッドがあります：

    - `AddMcpServer`：機能を追加します。
    - `MapMcp`：`/SSE`や`/messages`のようなルートを追加します。

SSEについて少し理解できたので、次にSSEサーバーを構築してみましょう。

## 演習：SSEサーバーの作成

サーバーを作成するにあたり、以下の2点を意識します：

- 接続とメッセージ用のエンドポイントを公開するためにWebサーバーを使う。
- stdioを使っていた時と同様に、ツールやリソース、プロンプトを使ってサーバーを構築する。

### -1- サーバーインスタンスの作成

サーバーを作成するには、stdioと同じ型を使います。ただし、トランスポートはSSEを選択します。

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

上記のコードでは：

- サーバーインスタンスを作成しました。
- Webフレームワークexpressを使ってアプリを定義しました。
- 受信接続を保存するためのtransports変数を作成しました。

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

上記のコードでは：

- 必要なライブラリをインポートし、Starlette（ASGIフレームワーク）を取り込みました。
- MCPサーバーインスタンス`mcp`を作成しました。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

この時点で：

- Webアプリを作成しました。
- `AddMcpServer`を使ってMCP機能のサポートを追加しました。

次に必要なルートを追加しましょう。

### -2- ルートの追加

接続と受信メッセージを処理するルートを追加します：

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

上記のコードでは：

- `/sse`ルートを定義し、SSEタイプのトランスポートをインスタンス化し、MCPサーバーの`connect`を呼び出しています。
- `/messages`ルートは受信メッセージを処理します。

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

上記のコードでは：

- Starletteフレームワークを使ってASGIアプリインスタンスを作成しました。その際、`mcp.sse_app()`をルートリストに渡しています。これにより、アプリインスタンスに`/sse`と`/messages`のルートがマウントされます。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

最後に`add.MapMcp()`を追加しました。これで`/SSE`と`/messages`のルートが利用可能になります。

次にサーバーに機能を追加しましょう。

### -3- サーバー機能の追加

SSE固有の設定ができたので、ツールやプロンプト、リソースなどのサーバー機能を追加します。

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

例えば、ツールを追加する方法はこうです。このツールは"random-joke"という名前で、Chuck NorrisのAPIを呼び出し、JSONレスポンスを返します。

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

これでサーバーに1つのツールが追加されました。

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

1. まずツールを作成します。*Tools.cs*というファイルを作成し、以下の内容を記述します：

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

  ここでは以下を行いました：

  - `McpServerToolType`デコレーターを付けた`Tools`クラスを作成。
  - `McpServerTool`デコレーターを付けた`AddNumbers`ツールを定義。パラメーターと実装も提供しています。

1. 作成した`Tools`クラスを活用します：

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  `WithTools`を呼び出し、ツールを含むクラスとして`Tools`を指定しました。これで準備完了です。

素晴らしい、SSEを使ったサーバーができました。次は実際に動かしてみましょう。

## 演習：InspectorでSSEサーバーをデバッグする

Inspectorは前のレッスン[最初のサーバーを作成する](/03-GettingStarted/01-first-server/README.md)で紹介した便利なツールです。ここでも使えるか試してみましょう：

### -1- Inspectorの起動

Inspectorを使うには、まずSSEサーバーが起動している必要があります。では起動しましょう：

1. サーバーを起動する

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    `pip install "mcp[cli]"`でインストールされる`uvicorn`実行ファイルを使っている点に注目してください。`server:app`は`server.py`ファイルを実行し、その中のStarletteインスタンス`app`を使うことを意味します。

    ### .NET

    ```sh
    dotnet run
    ```

    これでサーバーが起動します。操作するには新しいターミナルが必要です。

1. Inspectorを起動する

    > ![NOTE]
    > サーバーを起動しているターミナルとは別のウィンドウで実行してください。また、以下のコマンドはサーバーのURLに合わせて調整が必要です。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspectorの起動はどのランタイムでも同じです。サーバーのパスや起動コマンドを渡す代わりに、サーバーが動いているURLと`/sse`ルートを指定している点に注目してください。

### -2- ツールを試す

ドロップリストからSSEを選択し、サーバーが動いているURL（例：`http:localhost:4321/sse`）を入力して「Connect」ボタンを押します。前回同様、ツール一覧を表示し、ツールを選択して入力値を渡します。以下のような結果が表示されるはずです：

![Inspectorで動作中のSSEサーバー](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ja.png)

素晴らしい、Inspectorで操作できました。次はVisual Studio Codeでの使い方を見てみましょう。

## 課題

サーバーにさらに機能を追加してみてください。例えば[こちらのページ](https://api.chucknorris.io/)を参考にAPIを呼び出すツールを追加するのも良いでしょう。サーバーの形は自由に決めてください。楽しんでくださいね :)

## 解答例

[解答例](./solution/README.md) 動作するコードの一例です。

## まとめ

この章の重要なポイントは以下の通りです：

- SSEはstdioに次ぐ2つ目のサポートされているトランスポートです。
- SSEをサポートするには、Webフレームワークを使って接続とメッセージを管理する必要があります。
- InspectorやVisual Studio Codeを使ってstdioサーバーと同様にSSEサーバーを利用できます。ただしstdioとSSEでは少し違いがあります。SSEではサーバーを別途起動してからInspectorを実行します。またInspectorではURLを指定する必要があります。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 次に学ぶこと

- 次へ：[MCPによるHTTPストリーミング（Streamable HTTP）](../06-http-streaming/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。