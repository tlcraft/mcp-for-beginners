<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:46:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ja"
}
-->
# HTTPS ストリーミングと Model Context Protocol (MCP)

本章では、HTTPS を使った Model Context Protocol (MCP) による安全でスケーラブルなリアルタイムストリーミングの実装方法を詳しく解説します。ストリーミングの背景、利用可能なトランスポート機構、MCP でのストリーム可能な HTTP の実装方法、セキュリティのベストプラクティス、SSE からの移行、そして実践的な MCP ストリーミングアプリケーション構築の手引きを含みます。

## MCP におけるトランスポート機構とストリーミング

このセクションでは、MCP で利用可能な様々なトランスポート機構と、それらがクライアントとサーバー間のリアルタイム通信におけるストリーミング機能をどのように実現するかを解説します。

### トランスポート機構とは？

トランスポート機構は、クライアントとサーバー間でデータをどのようにやり取りするかを定義します。MCP は環境や要件に応じて複数のトランスポートタイプをサポートしています：

- **stdio**: 標準入出力。ローカルや CLI ベースのツールに適しています。シンプルですが、Web やクラウド環境には不向きです。
- **SSE (Server-Sent Events)**: サーバーが HTTP 経由でクライアントにリアルタイム更新をプッシュできます。Web UI に適していますが、スケーラビリティや柔軟性には制限があります。
- **Streamable HTTP**: 最新の HTTP ベースのストリーミングトランスポートで、通知機能や優れたスケーラビリティを備えています。ほとんどの本番環境やクラウドシナリオで推奨されます。

### 比較表

以下の比較表で各トランスポート機構の違いを確認してください：

| トランスポート       | リアルタイム更新 | ストリーミング | スケーラビリティ | 利用ケース                 |
|---------------------|------------------|----------------|------------------|----------------------------|
| stdio               | なし             | なし           | 低               | ローカル CLI ツール        |
| SSE                 | あり             | あり           | 中               | Web、リアルタイム更新      |
| Streamable HTTP      | あり             | あり           | 高               | クラウド、多クライアント   |

> **Tip:** 適切なトランスポートを選ぶことはパフォーマンス、スケーラビリティ、ユーザー体験に大きく影響します。**Streamable HTTP** は現代的でスケーラブル、クラウド対応アプリケーションに推奨されます。

前章で紹介した stdio と SSE のトランスポートに加え、本章では Streamable HTTP を取り扱います。

## ストリーミング：基本概念と動機

ストリーミングの基本概念とその背景を理解することは、効果的なリアルタイム通信システムを実装する上で重要です。

**ストリーミング**とは、ネットワークプログラミングにおいて、レスポンス全体を待つのではなく、小さなチャンクやイベントの連続としてデータを送受信する手法です。以下のような場合に特に有用です：

- 大きなファイルやデータセットの転送
- リアルタイム更新（例：チャット、進捗バー）
- 長時間かかる計算処理でユーザーに状況を知らせたい場合

高レベルでのストリーミングのポイントは：

- データが一度にではなく段階的に送られる
- クライアントは到着したデータを随時処理できる
- レイテンシの低減とユーザー体験の向上に寄与する

### なぜストリーミングを使うのか？

ストリーミングを使う理由は以下の通りです：

- ユーザーが処理の完了を待たずに即座にフィードバックを得られる
- リアルタイムアプリや応答性の高い UI を実現できる
- ネットワークや計算資源の効率的な利用が可能になる

### 簡単な例：HTTP ストリーミングサーバーとクライアント

ストリーミングの実装例を示します：

<details>
<summary>Python</summary>

**サーバー (Python, FastAPI と StreamingResponse 使用):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**クライアント (Python, requests 使用):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

この例では、サーバーがすべてのメッセージが準備できるのを待つのではなく、メッセージが利用可能になり次第クライアントに送信しています。

**仕組み:**
- サーバーはメッセージが準備でき次第逐次返します。
- クライアントは到着したチャンクを受け取って表示します。

**必要条件:**
- サーバーは StreamingResponse のようなストリーミングレスポンスを使用する必要があります（例：`StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`）。

</details>

<details>
<summary>Java</summary>

**サーバー (Java, Spring Boot と Server-Sent Events 使用):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**クライアント (Java, Spring WebFlux WebClient 使用):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Java 実装ノート:**
- Spring Boot のリアクティブスタックを利用し、`Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream` を活用しています。
- 単純なストリーミングにはクラシックな HTTP ストリーミングが実装しやすく十分です。
- 複雑でインタラクティブなアプリケーションには、通知と最終結果を分離し、豊富なメタデータを扱える MCP ストリーミングが適しています。
- AI アプリケーションには、長時間処理の進捗を通知できる MCP の通知システムが特に有用です。

## MCP におけるストリーミング

これまでの比較や推奨を踏まえ、MCP におけるストリーミングの具体的な活用方法を見ていきましょう。

MCP フレームワーク内でストリーミングがどのように機能するかを理解することは、長時間かかる処理中にユーザーにリアルタイムでフィードバックを提供するレスポンシブなアプリケーション構築に不可欠です。

MCP では、メインのレスポンスをチャンクで送るのではなく、ツールがリクエストを処理している間にクライアントへ **通知** を送る形でストリーミングを実現します。通知は進捗更新やログ、その他のイベントを含むことができます。

### 動作の仕組み

メインの結果は依然として単一のレスポンスとして送られますが、処理中に通知を別メッセージとして送ることでクライアントをリアルタイムに更新します。クライアントはこれらの通知を処理して表示できる必要があります。

## 通知とは何か？

「通知」とは MCP の文脈で何を指すのでしょうか？

通知とは、長時間の処理中に進捗や状態、その他のイベントをサーバーからクライアントに知らせるためのメッセージです。通知は透明性を高め、ユーザー体験を向上させます。

例えば、クライアントはサーバーとの初期ハンドシェイクが完了した際に通知を送ることが想定されています。

通知は以下のような JSON メッセージ形式です：

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

通知は MCP のトピックの一つである ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) に属します。

ログ機能を有効にするには、サーバー側で以下のように機能を有効化する必要があります：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 使用する SDK によっては、ログ機能がデフォルトで有効になっている場合もあれば、サーバー設定で明示的に有効化が必要な場合もあります。

通知には以下の種類があります：

| レベル       | 説明                           | 使用例                        |
|--------------|--------------------------------|-------------------------------|
| debug        | 詳細なデバッグ情報             | 関数の開始/終了ポイント       |
| info         | 一般的な情報メッセージ         | 処理の進捗更新                |
| notice       | 通常だが重要なイベント         | 設定変更                      |
| warning      | 警告条件                      | 非推奨機能の使用              |
| error        | エラー条件                    | 処理の失敗                    |
| critical     | 重大な条件                    | システムコンポーネントの故障  |
| alert        | 直ちに対応が必要な事象         | データ破損の検出              |
| emergency    | システムが使用不能な状態       | 完全なシステム障害            |

## MCP での通知の実装

MCP で通知を実装するには、サーバー側とクライアント側の両方でリアルタイム更新を扱えるようにセットアップする必要があります。これにより、長時間処理中にユーザーへ即時フィードバックを提供できます。

### サーバー側：通知の送信

まずサーバー側です。MCP では、リクエスト処理中に通知を送信できるツールを定義します。サーバーは通常 `ctx` と呼ばれるコンテキストオブジェクトを使ってクライアントにメッセージを送ります。

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

上記例では、`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` トランスポートを使用しています：

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

この .NET の例では、`ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` メソッドを使って情報メッセージを送信しています。

.NET MCP サーバーで通知を有効にするには、ストリーミングトランスポートを使用していることを確認してください：

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### クライアント側：通知の受信

クライアント側では、到着した通知を処理し表示するメッセージハンドラを実装する必要があります。

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

上記コードでは、`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` が通知を処理しています。

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

この .NET の例では、`MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` を使用し、クライアントが通知を処理しています。

## 進捗通知とユースケース

このセクションでは、MCP における進捗通知の概念、重要性、Streamable HTTP を使った実装方法を解説し、理解を深めるための課題も用意しています。

進捗通知は、長時間の処理中にサーバーからクライアントへリアルタイムで送られるメッセージです。処理完了を待つのではなく、現在の状態を継続的に知らせることで、透明性やユーザー体験が向上し、デバッグも容易になります。

**例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### なぜ進捗通知を使うのか？

進捗通知が重要な理由は以下の通りです：

- **ユーザー体験の向上:** ユーザーは処理の進行状況をリアルタイムで確認できる。
- **リアルタイムフィードバック:** クライアントは進捗バーやログを表示し、アプリの応答性を高める。
- **デバッグ・監視の容易化:** 開発者やユーザーは処理の遅延や停止箇所を把握しやすくなる。

### 進捗通知の実装方法

MCP での進捗通知実装方法は以下の通りです：

- **サーバー側:** `ctx.info()` or `ctx.log()` を使い、各アイテム処理時に通知を送信。これによりメインの結果が準備される前にクライアントへメッセージが届く。
- **クライアント側:** 到着した通知を受け取り表示するメッセージハンドラを実装。通知と最終結果を区別して処理する。

**サーバー例:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**クライアント例:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## セキュリティ考慮事項

HTTP ベースのトランスポートで MCP サーバーを実装する際は、複数の攻撃ベクトルや防御策に注意を払い、セキュリティを最優先する必要があります。

### 概要

HTTP 経由で MCP サーバーを公開する場合、Streamable HTTP は新たな攻撃面を持つため、慎重な設定が求められます。

### 重要ポイント
- **Origin ヘッダー検証:** 常に `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` を使い SSE クライアントではなく検証してください。
3. **クライアントにメッセージハンドラを実装**し、通知を処理する。
4. **既存ツールやワークフローとの互換性をテスト**する。

### 互換性の維持

移行期間中は既存の SSE クライアントとの互換性を保つことが推奨されます。戦略例：

- SSE と Streamable HTTP の両方を異なるエンドポイントでサポートする。
- クライアントを段階的に新トランスポートへ移行する。

### 課題

移行にあたっては以下の課題に注意してください：

- すべてのクライアントが更新されていることを保証する
- 通知配信の違いを扱う

### 課題：自分のストリーミング MCP アプリを作ろう

**シナリオ:**
サーバーがアイテム（例：ファイルやドキュメント）のリストを処理し、処理完了ごとに通知を送信する MCP サーバーとクライアントを作成してください。クライアントは通知を受け取り次第表示します。

**手順:**

1. リストを処理し、各アイテムの処理時に通知を送るサーバーツールを実装する。
2. 通知をリアルタイムで表示するメッセージハンドラを備えたクライアントを実装する。
3. サーバーとクライアントを動作させ、通知が適切に届くか確認する。

[Solution](./solution/README.md)

## さらなる学習と次のステップ

MCP ストリーミングの理解を深め、より高度なアプリケーション構築に役立つ追加リソースと次のステップを紹介します。

### さらなる学習

- [Microsoft: HTTP ストリーミング入門](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期していますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。