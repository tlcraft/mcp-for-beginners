<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:30:13+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ja"
}
-->
# HTTPS ストリーミングと Model Context Protocol (MCP)

この章では、HTTPS を使った Model Context Protocol (MCP) による安全でスケーラブル、かつリアルタイムなストリーミングの実装方法を詳しく解説します。ストリーミングの動機、利用可能なトランスポート機構、MCP におけるストリーム可能な HTTP の実装方法、セキュリティのベストプラクティス、SSE からの移行、そして独自のストリーミング MCP アプリケーション構築の実践的なガイダンスを含みます。

## MCP におけるトランスポート機構とストリーミング

このセクションでは、MCP で利用可能なさまざまなトランスポート機構と、それらがクライアントとサーバー間のリアルタイム通信におけるストリーミング機能をどのように実現しているかを説明します。

### トランスポート機構とは？

トランスポート機構とは、クライアントとサーバー間でデータがどのようにやり取りされるかを定義するものです。MCP は異なる環境や要件に対応するため、複数のトランスポートタイプをサポートしています：

- **stdio**: 標準入出力。ローカルや CLI ベースのツールに適しています。シンプルですが、ウェブやクラウドには向きません。
- **SSE (Server-Sent Events)**: サーバーが HTTP 経由でクライアントにリアルタイム更新をプッシュできます。ウェブ UI に適していますが、スケーラビリティや柔軟性に制限があります。
- **Streamable HTTP**: 通知やより良いスケーラビリティをサポートする最新の HTTP ベースのストリーミングトランスポート。ほとんどの本番環境やクラウドシナリオで推奨されます。

### 比較表

以下の比較表で、これらのトランスポート機構の違いを確認してください：

| トランスポート       | リアルタイム更新 | ストリーミング | スケーラビリティ | 利用ケース               |
|---------------------|------------------|---------------|-----------------|-------------------------|
| stdio               | いいえ           | いいえ        | 低              | ローカル CLI ツール      |
| SSE                 | はい             | はい          | 中              | ウェブ、リアルタイム更新 |
| Streamable HTTP     | はい             | はい          | 高              | クラウド、マルチクライアント |

> **Tip:** 適切なトランスポートの選択はパフォーマンス、スケーラビリティ、ユーザー体験に影響します。**Streamable HTTP** はモダンでスケーラブル、クラウド対応のアプリケーションに推奨されます。

前章で紹介した stdio と SSE のトランスポートと、本章で扱う Streamable HTTP の違いに注目してください。

## ストリーミング：概念と動機

ストリーミングの基本的な概念と動機を理解することは、効果的なリアルタイム通信システムを実装する上で重要です。

**ストリーミング** とは、ネットワークプログラミングにおいて、全体のレスポンスが準備されるのを待つのではなく、小さなチャンクやイベントの連続としてデータを送受信する技術です。特に以下のような場合に有効です：

- 大きなファイルやデータセット
- リアルタイム更新（例：チャット、進捗バー）
- 長時間かかる計算処理でユーザーに情報を提供したい場合

ストリーミングのポイントは以下の通りです：

- データは一度に全てではなく段階的に届けられる
- クライアントは到着したデータを随時処理できる
- 体感的な遅延を減らし、ユーザー体験を向上させる

### なぜストリーミングを使うのか？

ストリーミングを使う理由は以下の通りです：

- ユーザーは処理の終わりだけでなく、途中でもフィードバックを得られる
- リアルタイムアプリケーションや応答性の高い UI を実現できる
- ネットワークや計算資源の効率的な利用が可能になる

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

この例では、サーバーがすべてのメッセージが揃うのを待つのではなく、準備ができたメッセージを順次クライアントに送信しています。

**動作の仕組み:**
- サーバーはメッセージが準備でき次第それを返す
- クライアントは到着したチャンクを受け取り、順次表示する

**要件:**
- サーバーはストリーミングレスポンス（例：FastAPI の `StreamingResponse`）を使うこと
- クライアントはレスポンスをストリームとして処理すること（requests の `stream=True`）
- Content-Type は通常 `text/event-stream` または `application/octet-stream`

</details>

<details>
<summary>Java</summary>

**サーバー (Java, Spring Boot と Server-Sent Events を使用):**

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

**クライアント (Java, Spring WebFlux WebClient を使用):**

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

**Java 実装のポイント:**
- Spring Boot のリアクティブスタックで `Flux` を使ったストリーミング
- `ServerSentEvent` によるイベントタイプ付きの構造化ストリーミング
- `WebClient` の `bodyToFlux()` でリアクティブストリーミングを受信
- `delayElements()` でイベント間の処理時間をシミュレート
- イベントに `info` や `result` といったタイプを付与し、クライアントでの処理を容易に

</details>

### 比較：従来のストリーミング vs MCP ストリーミング

従来のストリーミングと MCP におけるストリーミングの違いは以下のようにまとめられます：

| 特徴                   | 従来の HTTP ストリーミング       | MCP ストリーミング（通知）          |
|------------------------|-------------------------------|-------------------------------------|
| メインレスポンス       | チャンク単位で送信             | 最後に一括で送信                    |
| 進捗更新               | データチャンクとして送信       | 通知メッセージとして送信            |
| クライアント要件       | ストリームを処理できること     | メッセージハンドラを実装すること    |
| 利用ケース             | 大きなファイル、AI トークンストリーム | 進捗、ログ、リアルタイムフィードバック |

### 主な違い

さらに、以下のような違いがあります：

- **通信パターン:**
   - 従来の HTTP ストリーミング：単純なチャンク転送エンコーディングを使用
   - MCP ストリーミング：JSON-RPC プロトコルを使った構造化通知システム

- **メッセージ形式:**
   - 従来の HTTP：改行区切りのプレーンテキストチャンク
   - MCP：メタデータ付きの構造化された LoggingMessageNotification オブジェクト

- **クライアント実装:**
   - 従来の HTTP：ストリーミングレスポンスを処理するシンプルなクライアント
   - MCP：異なる種類のメッセージを処理するメッセージハンドラを備えた高度なクライアント

- **進捗更新:**
   - 従来の HTTP：進捗はメインレスポンスの一部として送信
   - MCP：進捗は別の通知メッセージとして送信され、メインレスポンスは最後に届く

### 推奨事項

従来のストリーミング（上記の `/stream` エンドポイントのような）と MCP ストリーミングのどちらを選ぶかについて、以下の点を推奨します。

- **シンプルなストリーミングが必要な場合:** 従来の HTTP ストリーミングは実装が簡単で基本的なニーズに十分対応可能です。

- **複雑でインタラクティブなアプリケーションの場合:** MCP ストリーミングは、より豊富なメタデータと通知と最終結果の分離を提供する構造化されたアプローチです。

- **AI アプリケーションの場合:** MCP の通知システムは、長時間かかる AI タスクの進捗をユーザーに知らせるのに特に有効です。

## MCP におけるストリーミング

ここまでで、従来のストリーミングと MCP ストリーミングの違いと推奨を見てきました。ここからは、MCP でストリーミングをどのように活用できるかを詳しく説明します。

MCP フレームワーク内でのストリーミングの仕組みを理解することは、長時間かかる処理中にユーザーにリアルタイムのフィードバックを提供する応答性の高いアプリケーションを構築する上で不可欠です。

MCP では、メインレスポンスをチャンクで送るのではなく、ツールがリクエストを処理している間にクライアントへ **通知** を送る形でストリーミングを実現します。これらの通知には進捗更新やログ、その他のイベントが含まれます。

### 動作の仕組み

メインの結果は依然として単一のレスポンスとして送信されますが、処理中に通知が別メッセージとして送られ、クライアントをリアルタイムに更新します。クライアントはこれらの通知を受け取り、表示できる必要があります。

## 通知とは何か？

「通知」とは MCP の文脈で何を意味するのでしょうか？

通知とは、長時間かかる処理の進捗や状態、その他のイベントをサーバーからクライアントに知らせるメッセージです。通知は透明性とユーザー体験を向上させます。

例えば、クライアントはサーバーとの初期ハンドシェイクが完了した際に通知を送ることが想定されています。

通知は JSON メッセージとして以下のような形式を取ります：

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

ログ機能を有効にするには、サーバー側で以下のように機能/能力として設定する必要があります：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 使用する SDK によっては、ログ機能がデフォルトで有効になっている場合や、サーバー設定で明示的に有効化が必要な場合があります。

通知には以下のような種類があります：

| レベル     | 説明                           | 使用例                         |
|------------|--------------------------------|-------------------------------|
| debug      | 詳細なデバッグ情報             | 関数の開始・終了ポイント       |
| info       | 一般的な情報メッセージ         | 処理の進捗更新                 |
| notice     | 通常だが重要なイベント         | 設定変更                       |
| warning    | 警告状態                       | 非推奨機能の使用               |
| error      | エラー状態                     | 処理の失敗                     |
| critical   | 重大な状態                     | システムコンポーネントの障害   |
| alert      | 直ちに対応が必要な状態         | データ破損の検出               |
| emergency  | システムが使用不能な状態       | システム全体の障害             |

## MCP での通知の実装

MCP で通知を実装するには、サーバー側とクライアント側の両方でリアルタイム更新を扱う準備が必要です。これにより、長時間かかる処理中にユーザーに即時フィードバックを提供できます。

### サーバー側：通知の送信

まずサーバー側から見ていきましょう。MCP では、リクエスト処理中に通知を送信できるツールを定義します。サーバーは通常 `ctx` と呼ばれるコンテキストオブジェクトを使ってクライアントにメッセージを送ります。

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

上記の例では、`process_files` ツールがファイルを処理するたびに 3 回の通知をクライアントに送信しています。`ctx.info()` メソッドは情報メッセージを送るために使われます。

</details>

さらに、通知を有効にするには、サーバーがストリーミングトランスポート（例：`streamable-http`）を使い、クライアントが通知を処理するメッセージハンドラを実装している必要があります。サーバーで `streamable-http` トランスポートを設定する例は以下の通りです：

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

この .NET の例では、`ProcessFiles` ツールがファイルを処理するたびに 3 回の通知をクライアントに送信しています。`ctx.Info()` メソッドは情報メッセージを送るために使われます。

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

クライアントは通知を受け取り、表示するためのメッセージハンドラを実装する必要があります。

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

上記コードでは、`message_handler` 関数が受信メッセージが通知かどうかを判定し、通知なら表示し、そうでなければ通常のサーバーメッセージとして処理しています。また、`ClientSession` は通知を処理するために `message_handler` を初期化時に渡しています。

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

この .NET の例では、`MessageHandler` 関数が受信メッセージが通知かどうかを判定し、通知なら表示し、そうでなければ通常のサーバーメッセージとして処理しています。`ClientSession` は `ClientSessionOptions` を通じてメッセージハンドラを設定しています。

</details>

通知を有効にするには、サーバーがストリーミングトランスポート（例：`streamable-http`）を使い、クライアントが通知を処理するメッセージハンドラを実装していることを確認してください。

## 進捗通知とシナリオ

このセクションでは、MCP における進捗通知の概念、その重要性、Streamable HTTP を使った実装方法を説明します。理解を深めるための実践課題も含まれています。

進捗通知とは、長時間かかる処理中にサーバーからクライアントへリアルタイムで送られるメッセージです。処理が完了するのを待つのではなく、現在の状況を逐次クライアントに伝えることで、透明性やユーザー体験が向上し、デバッグも容易になります。

**例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### なぜ進捗通知を使うのか？

進捗通知が重要な理由は以下の通りです：

- **ユーザー体験の向上:** 処理の進行状況がリアルタイムで見えるため、ユーザーは待ち時間を感じにくくなる
- **リアルタイムフィードバック:** クライアントは進捗バーやログを表示でき、アプリが応答的に感じられる
- **デバッグや監視が容易に:** 開発者やユーザーが処理のどこ

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

## セキュリティ上の考慮事項

HTTPベースのトランスポートでMCPサーバーを実装する際は、複数の攻撃ベクトルや防御策に注意を払う必要があり、セキュリティが最重要課題となります。

### 概要

MCPサーバーをHTTPで公開する場合、セキュリティは非常に重要です。Streamable HTTPは新たな攻撃面を生み出すため、慎重な設定が求められます。

### 重要ポイント
- **Originヘッダーの検証**: DNSリバインディング攻撃を防ぐため、必ず`Origin`ヘッダーを検証してください。
- **ローカルホストバインド**: ローカル開発時はサーバーを`localhost`にバインドし、公開インターネットへの露出を避けましょう。
- **認証**: 本番環境ではAPIキーやOAuthなどの認証を実装してください。
- **CORS**: クロスオリジンリソース共有（CORS）ポリシーを設定し、アクセスを制限しましょう。
- **HTTPS**: 本番環境では通信を暗号化するためにHTTPSを使用してください。

### ベストプラクティス
- 入ってくるリクエストは必ず検証し、安易に信用しないこと。
- すべてのアクセスとエラーをログに記録し、監視すること。
- セキュリティ脆弱性を修正するために依存関係を定期的に更新すること。

### 課題
- セキュリティと開発のしやすさのバランスを取ること
- 多様なクライアント環境との互換性を確保すること


## SSEからStreamable HTTPへのアップグレード

現在Server-Sent Events（SSE）を使用しているアプリケーションでは、Streamable HTTPへの移行により、MCPの機能強化と長期的な持続可能性が得られます。

### なぜアップグレードするのか？

SSEからStreamable HTTPにアップグレードする理由は主に2つあります：

- Streamable HTTPはSSEよりもスケーラビリティ、互換性、通知機能が優れている。
- 新しいMCPアプリケーションには推奨されるトランスポートである。

### 移行手順

MCPアプリケーションでSSEからStreamable HTTPに移行する方法は以下の通りです：

- サーバーコードを更新し、`mcp.run()`で`transport="streamable-http"`を使用する。
- クライアントコードを更新し、SSEクライアントの代わりに`streamablehttp_client`を使う。
- クライアントに通知を処理するメッセージハンドラーを実装する。
- 既存のツールやワークフローとの互換性をテストする。

### 互換性の維持

移行期間中は既存のSSEクライアントとの互換性を保つことが推奨されます。以下の方法があります：

- 異なるエンドポイントでSSEとStreamable HTTPの両方をサポートする。
- クライアントを段階的に新しいトランスポートに移行する。

### 課題

移行時に以下の課題に対応する必要があります：

- すべてのクライアントが更新されることを確実にする。
- 通知配信の違いを適切に処理する。

## セキュリティ上の考慮事項

HTTPベースのトランスポート（Streamable HTTPなど）を使う場合、MCPサーバーの実装においてセキュリティは最優先事項です。

HTTPベースのトランスポートでMCPサーバーを実装する際は、複数の攻撃ベクトルや防御策に注意を払う必要があり、セキュリティが最重要課題となります。

### 概要

MCPサーバーをHTTPで公開する場合、セキュリティは非常に重要です。Streamable HTTPは新たな攻撃面を生み出すため、慎重な設定が求められます。

主なセキュリティ上の考慮点は以下の通りです：

- **Originヘッダーの検証**: DNSリバインディング攻撃を防ぐため、必ず`Origin`ヘッダーを検証してください。
- **ローカルホストバインド**: ローカル開発時はサーバーを`localhost`にバインドし、公開インターネットへの露出を避けましょう。
- **認証**: 本番環境ではAPIキーやOAuthなどの認証を実装してください。
- **CORS**: クロスオリジンリソース共有（CORS）ポリシーを設定し、アクセスを制限しましょう。
- **HTTPS**: 本番環境では通信を暗号化するためにHTTPSを使用してください。

### ベストプラクティス

MCPストリーミングサーバーのセキュリティ実装にあたっては、以下のベストプラクティスも守りましょう：

- 入ってくるリクエストは必ず検証し、安易に信用しないこと。
- すべてのアクセスとエラーをログに記録し、監視すること。
- セキュリティ脆弱性を修正するために依存関係を定期的に更新すること。

### 課題

MCPストリーミングサーバーのセキュリティ実装では、以下の課題に直面します：

- セキュリティと開発のしやすさのバランスを取ること
- 多様なクライアント環境との互換性を確保すること

### 課題: 自分だけのストリーミングMCPアプリを作ろう

**シナリオ:**
サーバーがファイルやドキュメントなどのリストを処理し、処理した各アイテムごとに通知を送信するMCPサーバーとクライアントを作成します。クライアントは通知を受け取るたびに表示します。

**手順:**

1. リストを処理し、各アイテムの通知を送信するサーバーツールを実装する。
2. 通知をリアルタイムで表示するメッセージハンドラーを持つクライアントを実装する。
3. サーバーとクライアントを両方実行して、通知が届く様子を確認する。

[Solution](./solution/README.md)

## さらなる学習と次のステップ

MCPストリーミングの理解を深め、より高度なアプリケーション構築に進むための追加リソースと次のステップを紹介します。

### さらなる学習

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 次のステップ

- ストリーミングを活用したリアルタイム分析、チャット、共同編集など、より高度なMCPツールの構築に挑戦してみましょう。
- MCPストリーミングをReactやVueなどのフロントエンドフレームワークと統合し、ライブUI更新を実現しましょう。
- 次へ: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。