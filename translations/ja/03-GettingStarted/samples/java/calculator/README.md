<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-05-16T15:03:16+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "ja"
}
-->
# Basic Calculator MCP Service

このサービスは、Spring Boot の WebFlux トランスポートを使い、Model Context Protocol (MCP) を通じて基本的な計算機能を提供します。MCPの実装を学ぶ初心者向けのシンプルな例として設計されています。

詳細は [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) のリファレンスドキュメントをご覧ください。

## 概要

このサービスの特徴：
- SSE（Server-Sent Events）対応
- Spring AI の `@Tool` アノテーションによる自動ツール登録
- 基本的な計算機能：
  - 足し算、引き算、掛け算、割り算
  - 累乗計算と平方根
  - 剰余（モジュラス）と絶対値
  - 操作説明のヘルプ機能

## 機能

この計算機サービスが提供する機能は以下の通りです：

1. **基本的な算術演算**：
   - 2つの数の加算
   - 1つの数から別の数を引く減算
   - 2つの数の乗算
   - 1つの数を別の数で割る除算（ゼロ除算チェック付き）

2. **高度な演算**：
   - 累乗計算（底の数を指数でべき乗）
   - 平方根計算（負の数チェック付き）
   - 剰余計算
   - 絶対値計算

3. **ヘルプシステム**：
   - 利用可能なすべての操作を説明する組み込みのヘルプ機能

## サービスの利用方法

このサービスは MCP プロトコルを通じて以下のAPIエンドポイントを公開しています：

- `add(a, b)`: 2つの数を加算
- `subtract(a, b)`: 2つ目の数を1つ目の数から減算
- `multiply(a, b)`: 2つの数を乗算
- `divide(a, b)`: 1つ目の数を2つ目の数で除算（ゼロチェック付き）
- `power(base, exponent)`: 数の累乗計算
- `squareRoot(number)`: 平方根計算（負の数チェック付き）
- `modulus(a, b)`: 除算時の剰余計算
- `absolute(number)`: 絶対値計算
- `help()`: 利用可能な操作の情報取得

## テストクライアント

シンプルなテストクライアントが `com.microsoft.mcp.sample.client` パッケージに含まれています。`SampleCalculatorClient` クラスは計算機サービスの利用可能な操作を実演しています。

## LangChain4j クライアントの利用

プロジェクトには LangChain4j のサンプルクライアントが `com.microsoft.mcp.sample.client.LangChain4jClient` に含まれており、計算機サービスを LangChain4j と GitHub モデルと統合する方法を示しています。

### 前提条件

1. **GitHub トークンの設定**：

   GitHub の AI モデル（phi-4 など）を使うには、GitHub のパーソナルアクセストークンが必要です：

   a. GitHub アカウント設定へアクセス：https://github.com/settings/tokens

   b. 「Generate new token」→「Generate new token (classic)」をクリック

   c. トークンにわかりやすい名前を付ける

   d. 以下のスコープを選択：
      - `repo`（プライベートリポジトリの完全制御）
      - `read:org`（組織とチームメンバーシップの読み取り、組織プロジェクトの読み取り）
      - `gist`（Gistの作成）
      - `user:email`（ユーザーのメールアドレスアクセス（読み取り専用））

   e. 「Generate token」をクリックし、新しいトークンをコピー

   f. 環境変数として設定：

      Windows の場合：
      ```
      set GITHUB_TOKEN=your-github-token
      ```

      macOS/Linux の場合：
      ```bash
      export GITHUB_TOKEN=your-github-token
      ```

   g. 永続的に設定する場合はシステム設定から環境変数に追加してください

2. プロジェクトに LangChain4j の GitHub 依存を追加（pom.xml に既に含まれています）：
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. 計算機サーバーが `localhost:8080` で起動していることを確認

### LangChain4j クライアントの実行

この例では以下を示しています：
- SSE トランスポート経由で計算機 MCP サーバーに接続
- LangChain4j を使って計算機能を活用するチャットボットの作成
- GitHub AI モデル（現在は phi-4 モデル）との統合

クライアントは以下のサンプルクエリを送信して機能をデモンストレーションします：
1. 2つの数の合計計算
2. 数の平方根計算
3. 利用可能な計算機操作のヘルプ情報取得

実行してコンソール出力を確認し、AIモデルがどのように計算機ツールを使って応答するかを見てください。

### GitHub モデルの設定

LangChain4j クライアントは以下の設定で GitHub の phi-4 モデルを使用するように構成されています：

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

他の GitHub モデルを使う場合は、`modelName` パラメータを別のサポートされているモデル名（例："claude-3-haiku-20240307"、"llama-3-70b-8192" など）に変更してください。

## 依存関係

プロジェクトで必要な主な依存関係：

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
</dependency>
```

## プロジェクトのビルド

Maven を使ってプロジェクトをビルド：
```bash
./mvnw clean install -DskipTests
```

## サーバーの起動

### Java を使う場合

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### MCP Inspector の利用

MCP Inspector は MCP サービスと対話するための便利なツールです。この計算機サービスで使う手順：

1. 新しいターミナルで MCP Inspector をインストールし起動：
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. アプリが表示するURL（通常 http://localhost:6274）をクリックして Web UI にアクセス

3. 接続設定：
   - トランスポートタイプを「SSE」に設定
   - 実行中のサーバーの SSE エンドポイント（`http://localhost:8080/sse`）をURLに設定
   - 「Connect」をクリック

4. ツールの利用：
   - 「List Tools」をクリックして利用可能な計算機操作を表示
   - ツールを選択し「Run Tool」をクリックして操作を実行

![MCP Inspector Screenshot](../../../../../../translated_images/tool.c75a0b2380efcf1a47a8478f54380a36ddcca7943b98f56dabbac8b07e15c3bb.ja.png)

### Docker の利用

コンテナ化されたデプロイ用に Dockerfile が含まれています：

1. Docker イメージのビルド：
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. Docker コンテナの起動：
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

これにより：
- Maven 3.9.9 と Eclipse Temurin 24 JDK を使ったマルチステージビルド
- 最適化されたコンテナイメージの作成
- ポート8080でサービスを公開
- コンテナ内で MCP 計算機サービスが起動

コンテナが起動したら `http://localhost:8080` でサービスにアクセス可能です。

## トラブルシューティング

### GitHub トークンに関するよくある問題

1. **トークン権限の問題**：403 Forbidden エラーが出る場合、トークンの権限が前述の前提条件通りに設定されているか確認してください。

2. **トークン未設定**：「No API key found」エラーが出る場合、GITHUB_TOKEN 環境変数が正しく設定されているか確認してください。

3. **レートリミット**：GitHub API にはレート制限があります。429 ステータスコードのエラーが出たら数分待ってから再試行してください。

4. **トークンの有効期限切れ**：トークンは期限切れになることがあります。認証エラーが発生した場合は新しいトークンを作成し、環境変数を更新してください。

さらなるサポートが必要な場合は、[LangChain4j ドキュメント](https://github.com/langchain4j/langchain4j) または [GitHub API ドキュメント](https://docs.github.com/en/rest) を参照してください。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間翻訳を推奨いたします。本翻訳の利用により生じたいかなる誤解や解釈の相違についても、当方は責任を負いかねます。