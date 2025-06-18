<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:59:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ja"
}
-->
# HTTPS ストリーミングと Model Context Protocol (MCP)

この章では、HTTPS を使った Model Context Protocol (MCP) による安全でスケーラブル、かつリアルタイムなストリーミングの実装方法を詳しく解説します。ストリーミングの動機、利用可能なトランスポートメカニズム、MCP におけるストリーミング可能な HTTP の実装方法、セキュリティのベストプラクティス、SSE からの移行、そして独自のストリーミング MCP アプリケーション構築の実践的なガイドを扱います。

## MCP におけるトランスポートメカニズムとストリーミング

このセクションでは、MCP で利用可能なさまざまなトランスポートメカニズムと、それらがクライアントとサーバー間のリアルタイム通信におけるストリーミング機能をどのように実現しているかを説明します。

### トランスポートメカニズムとは？

トランスポートメカニズムは、クライアントとサーバー間でデータを交換する方法を定義します。MCP は異なる環境や要件に対応するために複数のトランスポートタイプをサポートしています：

- **stdio**: 標準入力/出力。ローカルや CLI ベースのツールに適しています。シンプルですが、ウェブやクラウドには不向きです。
- **SSE (Server-Sent Events)**: サーバーが HTTP を介してクライアントにリアルタイム更新をプッシュする仕組み。ウェブ UI に適していますが、スケーラビリティや柔軟性に制限があります。
- **Streamable HTTP**: 通知やより良いスケーラビリティをサポートする最新の HTTP ベースのストリーミングトランスポート。ほとんどの本番環境やクラウドシナリオで推奨されます。

### 比較表

以下の比較表で各トランスポートメカニズムの違いを確認してください：

| トランスポート     | リアルタイム更新 | ストリーミング | スケーラビリティ | 利用ケース               |
|-------------------|------------------|---------------|-----------------|-------------------------|
| stdio             | いいえ           | いいえ        | 低              | ローカル CLI ツール      |
| SSE               | はい             | はい          | 中              | ウェブ、リアルタイム更新 |
| Streamable HTTP   | はい             | はい          | 高              | クラウド、マルチクライアント |

> **Tip:** 適切なトランスポートを選ぶことは、パフォーマンス、スケーラビリティ、ユーザー体験に大きく影響します。モダンでスケーラブル、クラウド対応のアプリケーションには **Streamable HTTP** を推奨します。

前章で紹介した stdio と SSE のトランスポートと比べ、本章で扱うのは Streamable HTTP です。

## ストリーミング：概念と動機

ストリーミングの基本的な概念と動機を理解することは、効果的なリアルタイム通信システムを実装するうえで不可欠です。

**ストリーミング** は、ネットワークプログラミングの技術で、全体の応答が準備されるのを待つのではなく、小さく扱いやすいチャンクやイベントの連続としてデータを送受信することを可能にします。特に以下のような場合に有効です：

- 大きなファイルやデータセット
- リアルタイム更新（例：チャット、進捗バー）
- ユーザーに情報を提供し続けたい長時間の計算処理

ストリーミングのポイントは以下の通りです：

- データは一度にすべてではなく段階的に届けられる
- クライアントは到着したデータを逐次処理できる
- 体感レイテンシが減り、ユーザー体験が向上する

### なぜストリーミングを使うのか？

ストリーミングを使う理由は以下の通りです：

- ユーザーが処理の途中からフィードバックを受け取れる
- リアルタイムアプリケーションや応答性の高い UI を実現できる
- ネットワークや計算リソースの効率的な利用が可能になる

### 簡単な例：HTTP ストリーミングサーバー＆クライアント

ストリーミングの実装例を示します：

<details>
<summary>Python</summary>

**サーバー (Python、FastAPI と StreamingResponse を使用):**
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

**クライアント (Python、requests を使用):**
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

この例では、サーバーがすべてのメッセージが揃うのを待つのではなく、準備できたメッセージを順次クライアントに送信しています。

**仕組み:**
- サーバーはメッセージが準備でき次第それを逐次返す
- クライアントは到着したチャンクを受け取り表示する

**要件:**
- サーバーはストリーミングレスポンスを使う必要があります（例：`StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`）。MCP でのストリーミング選択とは異なります。

- **シンプルなストリーミングには:** 従来の HTTP ストリーミングの方が実装が簡単で基本的なニーズには十分です。

- **複雑でインタラクティブなアプリケーションには:** MCP ストリーミングは通知と最終結果を分離し、より豊富なメタデータを持つ構造化されたアプローチを提供します。

- **AI アプリケーション向けには:** MCP の通知システムは、長時間かかる AI タスクの進捗をユーザーに知らせるのに特に有用です。

## MCP におけるストリーミング

これまでにクラシックなストリーミングと MCP ストリーミングの違いについての推奨事項や比較を見てきました。ここからは MCP でのストリーミングの具体的な活用方法を詳しく解説します。

MCP フレームワーク内でストリーミングがどのように機能するかを理解することは、長時間の処理中にユーザーへリアルタイムでフィードバックを提供する応答性の高いアプリケーションを構築するうえで重要です。

MCP におけるストリーミングは、メインのレスポンスをチャンクで送るのではなく、ツールがリクエストを処理している間にクライアントへ **通知** を送る仕組みです。通知は進捗更新やログ、その他のイベントを含みます。

### 仕組み

メインの結果は単一のレスポンスとして送られますが、処理中に通知が別メッセージとして送られ、クライアントはそれをリアルタイムで受け取り表示します。クライアントはこれらの通知を扱える必要があります。

## 通知とは？

「通知」とは MCP の文脈で何を意味するのでしょうか？

通知とは、長時間の処理中に進捗や状態、その他のイベントをサーバーからクライアントに知らせるメッセージです。通知は透明性とユーザー体験を向上させます。

例えば、クライアントはサーバーとの初期ハンドシェイクが完了した際に通知を送ることが求められます。

通知は以下のような JSON メッセージの形をとります：

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

通知は MCP 内の「[Logging](https://modelcontextprotocol.io/specification/draft/server/utilities/logging)」というトピックに属します。

ログ機能を動作させるには、サーバー側で以下のように機能/能力として有効化する必要があります：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 使用する SDK によっては、ログ機能がデフォルトで有効になっている場合や、サーバー設定で明示的に有効化が必要な場合があります。

通知にはさまざまなレベルがあります：

| レベル      | 説明                         | 使用例                      |
|-------------|------------------------------|-----------------------------|
| debug       | 詳細なデバッグ情報           | 関数の開始・終了ポイント     |
| info        | 一般的な情報メッセージ       | 処理の進捗更新              |
| notice      | 通常だが重要なイベント       | 設定変更                    |
| warning     | 警告状態                     | 非推奨機能の使用            |
| error       | エラー状態                   | 処理の失敗                  |
| critical    | 重大な状態                   | システムコンポーネントの障害 |
| alert       | 直ちに対応が必要な状態       | データ破損の検出            |
| emergency   | システムが使用不能な状態     | システム全体の障害          |

## MCP における通知の実装

MCP で通知を実装するには、サーバーとクライアントの両方でリアルタイム更新を扱えるように設定する必要があります。これにより、長時間の処理中でもユーザーに即時のフィードバックを提供できます。

### サーバー側：通知の送信

まずサーバー側から。MCP では、リクエスト処理中に通知を送信できるツールを定義します。サーバーは通常 `ctx` と呼ばれるコンテキストオブジェクトを使い、クライアントへメッセージを送ります。

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

前述の例では、`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` トランスポートを使っています：

```python
mcp.run(transport="streamable-http")
```

</details>

### クライアント側：通知の受信

クライアントは通知を受け取り処理・表示するためのメッセージハンドラーを実装する必要があります。

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

上記コードでは、`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` を用い、クライアント側で通知処理を行っています。

## 進捗通知とシナリオ

このセクションでは、MCP における進捗通知の概念、その重要性、Streamable HTTP を使った実装方法を説明します。理解を深めるための課題も用意しています。

進捗通知とは、長時間の処理中にサーバーからクライアントへリアルタイムに送られるメッセージです。処理の完了を待つのではなく、現在の状態を逐次伝えることで透明性を高め、ユーザー体験を向上させ、デバッグも容易にします。

**例:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### なぜ進捗通知を使うのか？

進捗通知が重要な理由は以下の通りです：

- **ユーザー体験の向上:** 処理が進むにつれて更新が見えるため、ユーザーは待ち時間を感じにくくなる
- **リアルタイムフィードバック:** クライアントは進捗バーやログを表示でき、アプリが応答している印象を与える
- **デバッグや監視が容易に:** 開発者やユーザーが処理の遅延や停止箇所を特定しやすくなる

### 進捗通知の実装方法

MCP で進捗通知を実装するには以下のようにします：

- **サーバー側:** 各アイテム処理時に `ctx.info()` or `ctx.log()` を使って通知を送る。メイン結果が準備できる前にクライアントにメッセージを送信する。
- **クライアント側:** 通知を受け取って表示するメッセージハンドラーを実装する。通知と最終結果を区別して処理する。

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

## セキュリティ上の考慮点

HTTP ベースのトランスポートで MCP サーバーを実装する際は、複数の攻撃ベクトルや保護機構に注意を払う必要があり、セキュリティは非常に重要です。

### 概要

MCP サーバーを HTTP で公開する場合、Streamable HTTP は新たな攻撃面を生み出すため、慎重な設定が求められます。

### 重要ポイント
- **Origin ヘッダーの検証**: `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` を SSE クライアントではなく検証すること。
3. **クライアント側にメッセージハンドラーを実装し**、通知を処理する。
4. **既存ツールやワークフローとの互換性をテストする**。

### 互換性の維持

移行プロセス中は既存の SSE クライアントとの互換性を保つことが推奨されます。以下のような方法があります：

- SSE と Streamable HTTP の両方を異なるエンドポイントで同時にサポートする
- クライアントを段階的に新しいトランスポートへ移行する

### 課題

移行時には以下の課題に対応してください：

- すべてのクライアントが更新されていることを保証する
- 通知の配信方法の違いを扱う

### 課題：自分だけのストリーミング MCP アプリを作ろう

**シナリオ:**
サーバーがアイテムのリスト（例：ファイルやドキュメント）を処理し、処理が完了するたびに通知を送る MCP サーバーとクライアントを作成してください。クライアントは通知を受け取るとすぐに表示します。

**手順:**

1. リストを処理し、各アイテムの処理ごとに通知を送るサーバーツールを実装する。
2. 通知をリアルタイムで表示するメッセージハンドラーを持つクライアントを実装する。
3. サーバーとクライアントを実行し、通知が届く様子を確認する。

[Solution](./solution/README.md)

## さらに学ぶ & 次のステップ

MCP ストリーミングの学習を続け、より高度なアプリケーション構築へ進むために、以下の追加リソースと次のステップを紹介します。

### さらに学ぶ

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 次のステップ

- ストリーミングを活用したリアルタイム分析、チャット、共同編集などの高度な MCP ツールを作成してみましょう。
- MCP ストリーミングをフロントエンドフレームワーク（React、Vue など）と統合し、ライブ UI 更新を実

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の利用により生じたいかなる誤解や解釈の相違についても、一切の責任を負いかねます。