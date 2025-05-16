<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5331ffd328a54b90f76706c52b673e27",
  "translation_date": "2025-05-16T15:08:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ja"
}
-->
### -2- プロジェクトの作成

SDKをインストールしたので、次にプロジェクトを作成しましょう。

### -3- プロジェクトファイルの作成

### -4- サーバーコードの作成

### -5- ツールとリソースの追加

以下のコードを追加して、ツールとリソースを追加します。

### -6- 最終コード

サーバーを起動するために必要な最後のコードを追加しましょう。

### -7- サーバーのテスト

以下のコマンドでサーバーを起動します。

### -8- Inspectorを使って実行

Inspectorはサーバーを起動し、対話的に操作して動作確認ができる便利なツールです。起動してみましょう。

> [!NOTE]
> 「command」フィールドに表示されるコマンドは、使用しているランタイムによって異なる場合があります。

次のようなユーザーインターフェースが表示されるはずです。

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 「Connect」ボタンを選択してサーバーに接続します。  
  接続に成功すると、次の画面が表示されます。

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

2. 「Tools」から「listTools」を選択すると、「Add」が表示されます。「Add」を選択してパラメーターを入力してください。

  次のようなレスポンスが表示されます。これは「add」ツールの結果です。

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます！最初のサーバーの作成と実行に成功しました。

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

- MCPの開発環境は言語別SDKで簡単にセットアップできる
- MCPサーバー構築では、明確なスキーマを持つツールを作成し登録することが必要
- テストとデバッグは信頼性の高いMCP実装に不可欠

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

お好きなツールを使ったシンプルなMCPサーバーを作成してください：
1. お好きな言語（.NET、Java、Python、JavaScript）でツールを実装する。
2. 入力パラメーターと戻り値を定義する。
3. Inspectorツールを使ってサーバーが正しく動作するか確認する。
4. さまざまな入力で実装をテストする。

## 解答例

[解答例](./solution/README.md)

## 追加リソース

- [MCP GitHubリポジトリ](https://github.com/microsoft/mcp-for-beginners)

## 次に進む

次へ：[MCPクライアントの使い方](/03-GettingStarted/02-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。