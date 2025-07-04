<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T16:17:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ja"
}
-->
素晴らしいです。次のステップとして、サーバーの機能一覧を取得しましょう。

### -2 サーバーの機能一覧を取得する

次に、サーバーに接続してその機能を取得します。

### -3 サーバーの機能をLLMのツールに変換する

サーバーの機能一覧を取得した後は、それらをLLMが理解できる形式に変換します。これにより、これらの機能をLLMのツールとして提供できるようになります。

素晴らしいです。ユーザーからのリクエストを処理する準備ができていないので、次はそれに取り組みましょう。

### -4 ユーザーのプロンプトリクエストを処理する

このコード部分では、ユーザーからのリクエストを処理します。

素晴らしい、できましたね！

## 課題

演習のコードを使って、さらにいくつかのツールを持つサーバーを構築してください。その後、演習のようにLLMを使ったクライアントを作成し、さまざまなプロンプトでテストして、サーバーのすべてのツールが動的に呼び出されることを確認しましょう。この方法でクライアントを構築すると、エンドユーザーは正確なクライアントコマンドではなくプロンプトを使って操作でき、MCPサーバーが呼び出されていることを意識せずに済むため、優れたユーザー体験を提供できます。

## 解答例

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要なポイント

- クライアントにLLMを追加することで、ユーザーがMCPサーバーとより良く対話できるようになります。
- MCPサーバーの応答をLLMが理解できる形式に変換する必要があります。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

## 次に進む

- 次へ: [Visual Studio Codeを使ってサーバーを利用する](../04-vscode/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。