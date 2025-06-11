<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:30:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "ja"
}
-->
# Basic Calculator MCP Service

このサービスは、Spring Boot の WebFlux トランスポートを使って Model Context Protocol (MCP) 経由で基本的な計算機能を提供します。MCP 実装を学ぶ初心者向けのシンプルな例として設計されています。

詳細は [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) のリファレンスドキュメントをご覧ください。

## Using the Service

このサービスは MCP プロトコルを通じて以下の API エンドポイントを公開しています：

- `add(a, b)`: 2つの数値を加算する
- `subtract(a, b)`: 2番目の数値を1番目の数値から減算する
- `multiply(a, b)`: 2つの数値を乗算する
- `divide(a, b)`: 1番目の数値を2番目の数値で除算する（ゼロチェック付き）
- `power(base, exponent)`: 数値の累乗を計算する
- `squareRoot(number)`: 平方根を計算する（負の数チェック付き）
- `modulus(a, b)`: 除算の余りを計算する
- `absolute(number)`: 絶対値を計算する

## Dependencies

このプロジェクトは以下の主要な依存関係を必要とします：

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Building the Project

Maven を使ってプロジェクトをビルドします：
```bash
./mvnw clean install -DskipTests
```

## Running the Server

### Using Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Using MCP Inspector

MCP Inspector は MCP サービスとやり取りするための便利なツールです。この計算機サービスで使うには：

1. **新しいターミナルウィンドウで MCP Inspector をインストールして起動する**：
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **アプリが表示する URL（通常は http://localhost:6274）をクリックしてウェブ UI にアクセスする**

3. **接続を設定する**：
   - トランスポートタイプを「SSE」に設定
   - 実行中のサーバーの SSE エンドポイント（`http://localhost:8080/sse`）を URL に設定
   - 「Connect」をクリック

4. **ツールを使う**：
   - 「List Tools」をクリックして利用可能な計算機の操作を表示
   - ツールを選択し、「Run Tool」をクリックして操作を実行

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.ja.png)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の母国語版が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。