<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:27:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ja"
}
-->
素晴らしいです。次のステップとして、サーバーの機能をリストアップしましょう。

### -2 サーバーの機能をリストアップする

次に、サーバーに接続してその機能を問い合わせます。

### -3 サーバーの機能をLLMツールに変換する

サーバーの機能をリストアップした後は、それらをLLMが理解できる形式に変換します。これにより、これらの機能をLLMのツールとして提供できるようになります。

素晴らしいです。ユーザーからのリクエストを処理する準備ができていないので、次はそれに取り組みましょう。

### -4 ユーザープロンプトのリクエストを処理する

このコード部分では、ユーザーからのリクエストを処理します。

素晴らしい、できましたね！

## 課題

演習のコードをベースに、さらに多くのツールを持つサーバーを構築してください。その後、演習と同様にLLMを備えたクライアントを作成し、さまざまなプロンプトでテストしてサーバーツールが動的に呼び出されることを確認しましょう。このようにクライアントを構築することで、エンドユーザーは正確なクライアントコマンドではなくプロンプトを使い、MCPサーバーが呼ばれていることを意識せずに済むため、優れたユーザー体験を提供できます。

## ソリューション

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要なポイント

- クライアントにLLMを追加することで、ユーザーがMCPサーバーとより良く対話できるようになります。
- MCPサーバーの応答をLLMが理解できる形に変換する必要があります。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

## 次にやること

- 次へ: [Visual Studio Codeを使ってサーバーを利用する](/03-GettingStarted/04-vscode/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご了承ください。原文の言語で記載されたオリジナルの文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。