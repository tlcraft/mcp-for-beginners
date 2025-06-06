<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:06:47+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ja"
}
-->
素晴らしいですね。次のステップとして、サーバーの機能一覧を取得しましょう。

### -2 サーバーの機能一覧を取得する

次にサーバーに接続して、その機能を問い合わせてみましょう。

### -3 サーバーの機能をLLMのツール形式に変換する

サーバーの機能を一覧化した後は、それらをLLMが理解できる形式に変換します。こうすることで、これらの機能をLLMのツールとして提供できます。

素晴らしいです。次はユーザーからのリクエストを処理する準備をしましょう。

### -4 ユーザープロンプトのリクエストを処理する

この部分のコードでは、ユーザーからのリクエストを処理します。

よくできました！

## 課題

演習で使ったコードをもとに、サーバーにいくつかのツールを追加して構築してください。その後、演習と同様にLLMを使ったクライアントを作成し、さまざまなプロンプトでテストして、サーバーツールが動的に呼び出されることを確認しましょう。この方法でクライアントを構築すると、エンドユーザーは正確なクライアントコマンドを覚える必要がなく、プロンプトを使って操作できるため、MCPサーバーが呼び出されていることを意識せずに済み、優れたユーザー体験を提供できます。

## ソリューション

[ソリューション](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要なポイント

- クライアントにLLMを追加することで、ユーザーがMCPサーバーとより良くやり取りできるようになります。
- MCPサーバーのレスポンスをLLMが理解できる形式に変換する必要があります。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

## 次にやること

- 次へ: [Visual Studio Codeでサーバーを利用する](/03-GettingStarted/04-vscode/README.md)

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知ください。原文の言語で記載された文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、一切の責任を負いかねます。