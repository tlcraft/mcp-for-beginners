<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-09T22:59:49+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ja"
}
-->
### -2- プロジェクトを作成する

SDKをインストールしたので、次にプロジェクトを作成しましょう。

### -3- プロジェクトファイルを作成する

### -4- サーバーコードを作成する

### -5- ツールとリソースを追加する

次のコードを追加して、ツールとリソースを追加しましょう。

### -6- 最終コード

サーバーを起動できるように、最後のコードを追加しましょう。

### -7- サーバーをテストする

次のコマンドでサーバーを起動します。

### -8- インスペクターを使って実行する

インスペクターはサーバーを起動し、動作を確認しながら対話できる便利なツールです。さっそく起動してみましょう。
> [!NOTE]  
> "command" フィールドには特定のランタイムでサーバーを起動するためのコマンドが含まれているため、見た目が異なる場合があります。
次のユーザーインターフェースが表示されるはずです：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. Connectボタンを選択してサーバーに接続します  
  サーバーに接続すると、次の画面が表示されます：

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

1. 「Tools」から「listTools」を選択すると、「Add」が表示されます。「Add」を選択してパラメーターの値を入力してください。

  次のような応答が表示されます。これは「add」ツールの結果です：

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます、最初のサーバーを作成して実行することができました！

### 公式SDK

MCPは複数の言語向けに公式SDKを提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと共同でメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと共同でメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式のTypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式のPython実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式のKotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと共同でメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式のRust実装

## 重要なポイント

- MCPの開発環境は言語別SDKを使うことで簡単にセットアップできる
- MCPサーバーの構築は、明確なスキーマを持つツールの作成と登録が必要
- テストとデバッグは信頼性の高いMCP実装に不可欠

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

お好きなツールを使ってシンプルなMCPサーバーを作成してください：

1. お好みの言語（.NET、Java、Python、JavaScript）でツールを実装する
2. 入力パラメーターと戻り値を定義する
3. インスペクターツールを実行してサーバーが正しく動作することを確認する
4. さまざまな入力で実装をテストする

## 解答例

[Solution](./solution/README.md)

## 追加リソース

- [AzureでModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container AppsでのリモートMCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次にやること

次へ：[MCPクライアントの使い方](../02-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。