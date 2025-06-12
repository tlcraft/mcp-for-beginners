<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90651bcd1df019768921d531653638a",
  "translation_date": "2025-06-12T21:36:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ja"
}
-->
### -2- プロジェクトを作成する

SDKをインストールしたので、次はプロジェクトを作成しましょう。

### -3- プロジェクトファイルを作成する

### -4- サーバーコードを作成する

### -5- ツールとリソースの追加

以下のコードを追加して、ツールとリソースを追加します。

### -6- 最終コード

サーバーを起動するために必要な最後のコードを追加しましょう。

### -7- サーバーのテスト

以下のコマンドでサーバーを起動します。

### -8- インスペクターを使って実行する

インスペクターは、サーバーを起動して操作できる便利なツールです。動作確認のために起動してみましょう。

> [!NOTE]
> 「コマンド」欄の表示は、ご利用のランタイムに合わせたサーバー起動コマンドが表示されるため異なる場合があります。

以下のユーザーインターフェースが表示されるはずです。

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 「Connect」ボタンを選択してサーバーに接続します。  
   接続が成功すると、以下の画面が表示されます。

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

2. 「Tools」から「listTools」を選択すると「Add」が表示されます。  
   「Add」を選択し、パラメーターの値を入力してください。

   以下のように「add」ツールの結果が返ってくるはずです。

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます、これで最初のサーバーを作成して実行できました！

### 公式SDK

MCPは複数の言語向けに公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと協力してメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと協力してメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式TypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式Python実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式Kotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと協力してメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式Rust実装

## 重要なポイント

- 言語別のSDKを使えば、MCP開発環境のセットアップは簡単です
- MCPサーバーの構築では、明確なスキーマを持つツールの作成と登録が必要です
- テストとデバッグは信頼性の高いMCP実装に不可欠です

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

好きなツールを使ってシンプルなMCPサーバーを作成しましょう：
1. 好みの言語（.NET、Java、Python、JavaScript）でツールを実装する
2. 入力パラメーターと戻り値を定義する
3. インスペクターツールを使ってサーバーが正しく動作するか確認する
4. さまざまな入力で実装をテストする

## 解答例

[解答例](./solution/README.md)

## 追加リソース

- [AzureでModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container AppsでのリモートMCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次のステップ

次へ: [MCPクライアントの始め方](/03-GettingStarted/02-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知おきください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の相違について、一切の責任を負いかねます。