<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:04:19+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ja"
}
-->
### -2- プロジェクトの作成

SDKをインストールしたら、次はプロジェクトを作成しましょう。

### -3- プロジェクトファイルの作成

### -4- サーバーコードの作成

### -5- ツールとリソースの追加

以下のコードを追加して、ツールとリソースを追加します。

### -6 最終コード

サーバーを起動するために必要な最後のコードを追加しましょう。

### -7- サーバーのテスト

以下のコマンドでサーバーを起動します。

### -8- Inspectorを使った実行

Inspectorはサーバーを起動し、対話的に操作して動作をテストできる便利なツールです。起動してみましょう。

> [!NOTE]
> 「command」フィールドの表示は、特定のランタイムでサーバーを実行するコマンドによって異なる場合があります。

以下のユーザーインターフェースが表示されるはずです。

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 「Connect」ボタンを選択してサーバーに接続します。  
  接続すると、以下の画面が表示されます。

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

2. 「Tools」から「listTools」を選択すると、「Add」が表示されます。「Add」を選択し、パラメーターの値を入力してください。

  以下のようなレスポンスが返されます。これは「add」ツールの結果です。

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます、初めてのサーバーを作成して実行することができました！

### 公式SDK

MCPは複数の言語向けに公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと共同でメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと共同でメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式TypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式Python実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式Kotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと共同でメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式Rust実装

## 重要なポイント

- MCPの開発環境は言語別のSDKを使うことで簡単にセットアップできる
- MCPサーバーの構築は、ツールを作成しスキーマを登録することが基本
- テストとデバッグは信頼性の高いMCP実装には欠かせない

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

選んだツールを使ってシンプルなMCPサーバーを作成しましょう：
1. 好きな言語（.NET、Java、Python、JavaScript）でツールを実装する
2. 入力パラメーターと戻り値を定義する
3. Inspectorツールを使ってサーバーが意図した通り動作するか確認する
4. さまざまな入力で実装をテストする

## 解答例

[Solution](./solution/README.md)

## 追加リソース

- [MCP GitHub リポジトリ](https://github.com/microsoft/mcp-for-beginners)

## 次に進む

次へ：[Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。正式な情報源としては、原文の言語による原文書を参照してください。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、当方は一切の責任を負いません。