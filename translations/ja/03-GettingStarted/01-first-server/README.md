<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:17:01+00:00",
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

### -6 最終コード

サーバーを起動できるように、最後のコードを追加します。

### -7- サーバーをテストする

次のコマンドでサーバーを起動します。

### -8- インスペクターを使って実行する

インスペクターは、サーバーを起動し、対話的に操作して動作をテストできる便利なツールです。さっそく起動してみましょう。

> [!NOTE]
> 「コマンド」欄に表示される内容は、ご利用のランタイムに合わせたサーバー起動コマンドになっているため異なる場合があります。

次のユーザーインターフェースが表示されるはずです。

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 「Connect」ボタンを選択してサーバーに接続します。接続に成功すると、次の画面が表示されます。

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

2. 「Tools」から「listTools」を選択すると、「Add」が表示されます。「Add」を選択してパラメーター値を入力してください。

  以下のように「add」ツールの実行結果が返ってきます。

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます！これで最初のサーバーを作成し、実行することができました。

### 公式SDK

MCPは複数の言語向けに公式SDKを提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと共同でメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと共同でメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式TypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式Python実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式Kotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと共同でメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式Rust実装

## 重要ポイント

- MCPの開発環境は、言語別SDKを使うことで簡単にセットアップ可能
- MCPサーバーの構築は、明確なスキーマを持つツールの作成と登録が基本
- テストとデバッグは信頼性の高いMCP実装のために不可欠

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

お好きなツールを使ったシンプルなMCPサーバーを作成してください：

1. お好みの言語（.NET、Java、Python、JavaScript）でツールを実装する。
2. 入力パラメーターと戻り値を定義する。
3. インスペクターツールを使ってサーバーが正常に動作することを確認する。
4. さまざまな入力で実装をテストする。

## 解答例

[解答例](./solution/README.md)

## 追加リソース

- [Azure上でModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Appsを使ったリモートMCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次のステップ

次へ: [MCPクライアントの使い方](/03-GettingStarted/02-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の言語で記載されたオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の利用により生じた誤解や誤訳について、一切の責任を負いかねますのでご了承ください。