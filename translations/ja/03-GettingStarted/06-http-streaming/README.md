<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-12T22:15:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ja"
}
-->
# HTTPS ストリーミングと Model Context Protocol (MCP)

この章では、HTTPS を使った Model Context Protocol (MCP) による安全でスケーラブルなリアルタイムストリーミングの実装方法を詳しく解説します。ストリーミングの動機、利用可能なトランスポート機構、MCP におけるストリーム可能な HTTP の実装方法、セキュリティのベストプラクティス、SSE からの移行方法、そして独自のストリーミング MCP アプリケーション構築の実践的なガイダンスをカバーします。

## MCP におけるトランスポート機構とストリーミング

このセクションでは、MCP で利用可能なさまざまなトランスポート機構と、それらがクライアントとサーバー間のリアルタイム通信におけるストリーミング機能をどのように実現するかを探ります。

### トランスポート機構とは？

トランスポート機構は、クライアントとサーバー間でデータがどのように交換されるかを定義します。MCP は異なる環境や要件に適した複数のトランスポートタイプをサポートしています：

- **stdio**：標準入出力。ローカルや CLI ベースのツールに適しています。シンプルですが、ウェブやクラウドには向きません。
- **SSE (Server-Sent Events)**：サーバーが HTTP 経由でクライアントにリアルタイム更新をプッシュできます。ウェブ UI に適していますが、スケーラビリティや柔軟性に制限があります。
- **Streamable HTTP**：通知と高いスケーラビリティをサポートする最新の HTTP ベースのストリーミングトランスポート。ほとんどの本番環境やクラウドシナリオに推奨されます。

### 比較表

以下の比較表で、これらのトランスポート機構の違いを理解してください：

| トランスポート      | リアルタイム更新 | ストリーミング | スケーラビリティ | 利用ケース               |
|--------------------|-----------------|----------------|------------------|-------------------------|
| stdio              | いいえ          | いいえ         | 低               | ローカル CLI ツール      |
| SSE                | はい            | はい           | 中               | ウェブ、リアルタイム更新  |
| Streamable HTTP    | はい            | はい           | 高               | クラウド、マルチクライアント |

> **Tip:** 適切なトランスポートを選ぶことは、パフォーマンス、スケーラビリティ、ユーザー体験に影響します。**Streamable HTTP** はモダンでスケーラブル、クラウド対応アプリケーションに推奨されます。

前章で紹介した stdio と SSE のトランスポートと、本章で扱う Streamable HTTP トランスポートの違いに注目してください。

## ストリーミング：概念と動機

ストリーミングの基本的な概念と動機を理解することは、効果的なリアルタイム通信システムの実装に不可欠です。

**ストリーミング** は、ネットワークプログラミングの技術で、応答全体を待つのではなく、小さなチャンクやイベントの連続としてデータを送受信できる方法です。特に以下のような場合に有用です：

- 大きなファイルやデータセット
- リアルタイム更新（例：チャット、プログレスバー）
- ユーザーに進行状況を知らせたい長時間処理

ストリーミングのポイントは以下の通りです：

- データは一度に全てではなく、段階的に配信される
- クライアントはデータ到着時に処理可能
- 体感遅延を減らし、ユーザー体験を向上させる

### なぜストリーミングを使うのか？

ストリーミングを使う理由は以下の通りです：

- ユーザーが処理終了時だけでなく即時にフィードバックを得られる
- リアルタイムアプリや応答性の高い UI を実現できる
- ネットワークや計算資源の効率的な利用が可能

### 簡単な例：HTTP ストリーミングサーバーとクライアント

ストリーミングの実装例を示します：

<details>
<summary>Python</summary>

**サーバー (Python, FastAPI と StreamingResponse を使用):**
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

**クライアント (Python, requests を使用):**
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

この例は、サーバーがメッセージをすべて準備完了を待つのではなく、準備ができ次第クライアントに順次送信する様子を示しています。

**動作の仕組み：**
- サーバーは準備ができたメッセージを逐次 yield する
- クライアントは到着したチャンクを受け取り表示する

**要件：**
- サーバーはストリーミングレスポンス（例：`StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`）を使う必要があり、MCP のストリーミング選択とは別

- **シンプルなストリーミングの場合：** 従来の HTTP ストリーミングは実装が簡単で基本的な用途には十分

- **複雑でインタラクティブなアプリケーションの場合：** MCP ストリーミングは通知と最終結果を分け、より構造化されたリッチなメタデータを提供

- **AI アプリケーション向け：** MCP の通知システムは長時間かかる AI タスクの進行状況をユーザーに知らせるのに特に有効

## MCP におけるストリーミング

これまでクラシックなストリーミングと MCP におけるストリーミングの違いを見てきました。ここからは、MCP の中でストリーミングをどのように活用できるかを詳しく説明します。

MCP フレームワーク内でストリーミングがどのように機能するかを理解することは、長時間処理中にユーザーにリアルタイムフィードバックを提供する応答性の高いアプリケーション構築に不可欠です。

MCP におけるストリーミングは、メインのレスポンスをチャンクで送るのではなく、ツールがリクエストを処理している間にクライアントに**通知**を送ることです。これらの通知には進捗状況、ログ、その他のイベントが含まれます。

### 動作の仕組み

メインの結果は依然として単一のレスポンスとして送られますが、処理中に通知を別メッセージとして送信し、クライアントをリアルタイムに更新します。クライアントはこれら通知を処理し表示できる必要があります。

## 通知とは何か？

「通知」とは MCP の文脈で何を指すのでしょうか？

通知は、長時間かかる処理の進捗、状態、その他のイベントをサーバーからクライアントへ知らせるメッセージです。通知は透明性とユーザー体験を向上させます。

例えば、クライアントはサーバーとの初期ハンドシェイクが完了したら通知を送ることが期待されます。

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

通知は MCP のトピックの一つである ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) に属します。

ログ機能を有効にするには、サーバーで以下のように機能/キャパビリティとして設定する必要があります：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 利用する SDK によっては、ログ機能がデフォルトで有効になっている場合や、サーバー設定で明示的に有効化が必要な場合があります。

通知には以下のような種類があります：

| レベル     | 説明                          | 使用例                         |
|------------|-------------------------------|-------------------------------|
| debug      | 詳細なデバッグ情報            | 関数の開始/終了ポイント       |
| info       | 一般的な情報メッセージ        | 処理進捗の更新                 |
| notice     | 通常だが重要なイベント        | 設定変更                       |
| warning    | 警告状態                      | 非推奨機能の使用               |
| error      | エラー状態                    | 処理失敗                       |
| critical   | 重大な状態                   | システムコンポーネントの故障   |
| alert      | 即時対応が必要な状態          | データ破損の検出               |
| emergency  | システムが使用不能の状態      | システム全体の障害             |

## MCP における通知の実装

MCP で通知を実装するには、サーバー側とクライアント側の両方をリアルタイム更新に対応させる必要があります。これにより、長時間処理中にユーザーに即時フィードバックを提供できます。

### サーバー側：通知の送信

まずサーバー側から。MCP では、リクエスト処理中に通知を送信できるツールを定義します。サーバーは通常 `ctx` と呼ばれるコンテキストオブジェクトを使ってクライアントにメッセージを送ります。

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

前の例では、`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` トランスポートを使っています：

```python
mcp.run(transport="streamable-http")
```

</details>

### クライアント側：通知の受信

クライアント側は、通知を受け取り処理・表示するメッセージハンドラーを実装する必要があります。

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` を使い、クライアントは通知を処理しています。

## 進捗通知とシナリオ

このセクションでは MCP における進捗通知の概念、その重要性、Streamable HTTP を使った実装方法を説明します。理解を深めるための実践課題もあります。

進捗通知は、長時間処理中にサーバーからクライアントへ送られるリアルタイムメッセージです。処理完了を待つのではなく、現在の状態を逐次クライアントに伝えます。これにより透明性が向上し、ユーザー体験が良くなり、デバッグも容易になります。

**例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### なぜ進捗通知を使うのか？

進捗通知は以下の理由で重要です：

- **ユーザー体験の向上：** ユーザーは処理の進行状況をリアルタイムで確認できる
- **リアルタイムフィードバック：** クライアントはプログレスバーやログを表示し、アプリの応答性を高める
- **デバッグと監視の容易化：** 開発者やユーザーが処理のどこで遅延や停止が起きているかを把握しやすくなる

### 進捗通知の実装方法

進捗通知は以下のように実装します：

- **サーバー側：** 各アイテム処理時に `ctx.info()` または `ctx.log()` を使って通知を送信。メインの結果が準備できる前にクライアントにメッセージを送る。
- **クライアント側：** 到着する通知を受け取り表示するメッセージハンドラーを実装。通知と最終結果を区別して処理する。

**サーバー例：**

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

**クライアント例：**

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

HTTP ベースのトランスポートを使って MCP サーバーを実装する際は、複数の攻撃ベクトルや防御策に注意を払う必要があり、セキュリティが最重要課題となります。

### 概要

MCP サーバーを HTTP 経由で公開する際はセキュリティが非常に重要です。Streamable HTTP は新たな攻撃面をもたらし、慎重な設定が求められます。

### 重要ポイント
- **Origin ヘッダーの検証**：必ず `Origin` ヘッダーを検証すること
- **認証と認可の適用**：アクセス制御を適切に行うこと
- **クライアント側でのメッセージハンドラー実装**：通知を正しく処理する
- **既存ツールやワークフローとの互換性テスト**：移行時の問題を防ぐ

### 互換性の維持

移行プロセス中は既存の SSE クライアントとの互換性を保つことが推奨されます。以下のような戦略があります：

- SSE と Streamable HTTP の両方を異なるエンドポイントでサポートする
- クライアントを段階的に新しいトランスポートへ移行する

### 課題

移行時には以下の課題に対処してください：

- すべてのクライアントを最新化することの確実性
- 通知配信の違いの扱い

### 課題：独自のストリーミング MCP アプリを作ろう

**シナリオ：**
アイテム（ファイルやドキュメントなど）のリストを処理し、処理済みの各アイテムについて通知を送る MCP サーバーとクライアントを構築してください。クライアントは通知を受け取るたびに表示します。

**手順：**

1. アイテムリストを処理し、各アイテムごとに通知を送るサーバーツールを実装する
2. 通知をリアルタイムに表示するメッセージハンドラーを持つクライアントを実装する
3. サーバーとクライアントを起動し、通知が正しく表示されることを確認する

[解答例](./solution/README.md)

## さらなる学習と今後の展望

MCP ストリーミングの理解を深め、より高度なアプリケーション構築へ進むための追加リソースと次のステップを紹介します。

### さらなる学習

- [Microsoft: HTTP ストリーミング入門](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core における CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: ストリーミングリクエスト](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 今後の展望

- ストリーミングを使ったリアルタイム分析、チャット、共同編集などのより高度な MCP ツールを構築してみましょう
- MCP ストリーミングをフロントエンドフレームワーク（React、Vue など）と統合し、ライブ UI 更新を実現しましょう
- 次へ：[VSCode 用 AI ツールキットの活用](../07-aitk/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。