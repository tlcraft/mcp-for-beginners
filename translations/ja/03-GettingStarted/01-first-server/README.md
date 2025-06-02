<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:23:48+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ja"
}
-->
### -2- プロジェクトの作成

SDKをインストールしたら、次にプロジェクトを作成しましょう。

### -3- プロジェクトファイルの作成

### -4- サーバーコードの作成

### -5- ツールとリソースの追加

次のコードを追加して、ツールとリソースを追加しましょう。

### -6- 最終コード

サーバーを起動するために必要な最後のコードを追加します。

### -7- サーバーのテスト

以下のコマンドでサーバーを起動してください。

### -8- インスペクターを使って実行

インスペクターはサーバーを起動し、対話的に動作をテストできる便利なツールです。起動してみましょう。

> [!NOTE]
> 「command」フィールドに表示される内容は、使用しているランタイムに応じたサーバー起動コマンドが含まれているため、異なる場合があります。

以下のユーザーインターフェースが表示されるはずです。

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 「Connect」ボタンを選択してサーバーに接続します。  
   接続に成功すると、次の画面が表示されます。

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ja.png)

2. 「Tools」タブを選択し、「listTools」を選ぶと「Add」が表示されます。  
   「Add」を選択し、パラメーターの値を入力してください。

   「Add」ツールの実行結果として、以下のようなレスポンスが表示されるはずです。

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ja.png)

おめでとうございます！これで最初のサーバーを作成して実行できました。

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

- MCPの開発環境は、言語ごとのSDKを使えば簡単にセットアップできる
- MCPサーバーの構築は、ツールを作成してスキーマを明確に登録することが重要
- テストとデバッグは、信頼性の高いMCP実装のために欠かせない

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 課題

好きなツールを使ってシンプルなMCPサーバーを作成してください：  
1. 好みの言語（.NET、Java、Python、JavaScript）でツールを実装する。  
2. 入力パラメーターと返り値を定義する。  
3. インスペクターツールを使ってサーバーが正しく動作するか確認する。  
4. さまざまな入力で実装をテストする。

## 解答例

[解答例](./solution/README.md)

## 追加リソース

- [AzureでModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container AppsでのリモートMCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次にやること

次へ：[MCPクライアントの使い方](/03-GettingStarted/02-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文はあくまで正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の違いについて、当方は一切の責任を負いかねます。