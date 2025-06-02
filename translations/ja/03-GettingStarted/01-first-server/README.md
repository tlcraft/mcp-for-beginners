<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:29:38+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ja"
}
-->
### -2- プロジェクトを作成する

SDKをインストールしたら、次にプロジェクトを作成しましょう。

### -3- プロジェクトファイルを作成する

### -4- サーバーコードを作成する

### -5- ツールとリソースを追加する

以下のコードを追加して、ツールとリソースを追加しましょう。

### -6 最終コード

サーバーを起動するために必要な最後のコードを追加します。

### -7- サーバーをテストする

以下のコマンドでサーバーを起動します。

### -8- Inspectorを使って実行する

Inspectorはサーバーを起動し、対話的に操作して動作確認ができる便利なツールです。さっそく起動してみましょう。

> [!NOTE]
> 「command」欄の表示は、使用しているランタイムに応じたサーバー起動コマンドが含まれているため異なる場合があります。

以下のユーザーインターフェイスが表示されるはずです：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 「Connect」ボタンを選択してサーバーに接続します。接続が成功すると、以下の画面が表示されます：

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

2. 「Tools」から「listTools」を選択すると、「Add」が表示されます。「Add」を選択し、パラメーターの値を入力してください。

  以下のように「add」ツールの結果が返ってくるはずです：

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます！これで最初のサーバーを作成し、実行できました。

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

- MCPの開発環境は言語別SDKで簡単に構築可能
- MCPサーバーの構築には、スキーマを明確にしたツールの作成と登録が必要
- テストとデバッグは信頼性の高いMCP実装に不可欠

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

好きなツールを使ってシンプルなMCPサーバーを作成してください：
1. お好みの言語（.NET、Java、Python、JavaScript）でツールを実装する。
2. 入力パラメーターと戻り値を定義する。
3. Inspectorツールを使ってサーバーが意図した通りに動作することを確認する。
4. さまざまな入力で実装をテストする。

## 解答例

[解答例](./solution/README.md)

## 追加リソース

- [MCP GitHubリポジトリ](https://github.com/microsoft/mcp-for-beginners)

## 次のステップ

次へ：[Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナルの文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、一切の責任を負いかねますのでご了承ください。