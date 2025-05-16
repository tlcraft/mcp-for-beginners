<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-16T14:56:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ja"
}
-->
素晴らしいですね。次のステップとして、サーバーの能力をリストアップしましょう。

### -2 サーバーの能力をリストアップする

次に、サーバーに接続してその能力を取得します。

### -3 サーバーの能力をLLMのツールに変換する

サーバーの能力をリストアップした後は、それらをLLMが理解できる形式に変換します。これにより、これらの能力をツールとしてLLMに提供できます。

素晴らしい、次はユーザーからのリクエストを処理できるようにしましょう。

### -4 ユーザーのプロンプトリクエストを処理する

このコード部分では、ユーザーからのリクエストを処理します。

素晴らしい、できましたね！

## 課題

演習で作成したコードを使って、さらにツールを追加したサーバーを構築してください。その後、演習のようにLLMを搭載したクライアントを作成し、さまざまなプロンプトでテストして、サーバーのツールが動的に呼び出されることを確認しましょう。この方法でクライアントを構築すると、エンドユーザーは正確なクライアントコマンドではなくプロンプトを使って操作でき、MCPサーバーが呼び出されていることを意識せずに快適なユーザー体験を得られます。

## ソリューション

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要なポイント

- クライアントにLLMを追加すると、ユーザーがMCPサーバーとより良く対話できるようになります。
- MCPサーバーのレスポンスをLLMが理解できる形式に変換する必要があります。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

## 次にやること

- 次へ: [Visual Studio Codeを使ったサーバーの利用](/03-GettingStarted/04-vscode/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。