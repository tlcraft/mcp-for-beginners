<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:44:48+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "ja"
}
-->
# Calculator HTTP Streaming Demo

このプロジェクトは、Spring Boot WebFluxを使ったServer-Sent Events（SSE）によるHTTPストリーミングを示しています。以下の2つのアプリケーションで構成されています：

- **Calculator Server**：計算を行い、SSEを使って結果をストリーミングするリアクティブなウェブサービス
- **Calculator Client**：ストリーミングエンドポイントを利用するクライアントアプリケーション

## 前提条件

- Java 17以上
- Maven 3.6以上

## プロジェクト構成

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## 動作の仕組み

1. **Calculator Server** は `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` を公開します
   - ストリーミングレスポンスを受け取ります
   - 各イベントをコンソールに出力します

## アプリケーションの実行方法

### オプション1：Mavenを使う（推奨）

#### 1. Calculator Serverを起動する

ターミナルを開き、サーバーディレクトリに移動します：

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

サーバーは `http://localhost:8080` で起動します

以下のような出力が表示されるはずです：
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Clientを実行する

**新しいターミナル**を開き、クライアントディレクトリに移動します：

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

クライアントはサーバーに接続し、計算を実行してストリーミング結果を表示します。

### オプション2：Javaを直接使う

#### 1. サーバーをコンパイルして実行する：

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. クライアントをコンパイルして実行する：

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## サーバーを手動でテストする

ウェブブラウザやcurlでもサーバーをテストできます：

### ウェブブラウザを使う場合：
`http://localhost:8080/calculate?a=10&b=5&op=add` にアクセスしてください

### curlを使う場合：
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## 期待される出力

クライアントを実行すると、以下のようなストリーミング出力が表示されます：

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## サポートされている演算

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- 計算の進行状況や結果を含むServer-Sent Eventsを返します

**リクエスト例：**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**レスポンス例：**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## トラブルシューティング

### よくある問題

1. **ポート8080がすでに使用中**
   - ポート8080を使用している他のアプリケーションを停止してください
   - または `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` でサーバーポートを変更するか、バックグラウンドで実行している場合は停止してください

## 技術スタック

- **Spring Boot 3.3.1** - アプリケーションフレームワーク
- **Spring WebFlux** - リアクティブウェブフレームワーク
- **Project Reactor** - リアクティブストリームライブラリ
- **Netty** - ノンブロッキングI/Oサーバー
- **Maven** - ビルドツール
- **Java 17+** - プログラミング言語

## 次のステップ

コードを修正してみましょう：
- さらに多くの数学演算を追加する
- 無効な演算に対するエラーハンドリングを含める
- リクエスト／レスポンスのログを追加する
- 認証機能を実装する
- ユニットテストを追加する

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。