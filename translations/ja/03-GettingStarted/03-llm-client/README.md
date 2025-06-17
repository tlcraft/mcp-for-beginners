<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:46:19+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ja"
}
-->
素晴らしい、次のステップとしてサーバー上の機能一覧を取得しましょう。

### -2 サーバーの機能一覧を取得する

次に、サーバーに接続してその機能を問い合わせます。

### -3 サーバーの機能をLLMのツールに変換する

サーバーの機能一覧を取得した後は、それらをLLMが理解できる形式に変換します。変換が完了したら、これらの機能をツールとしてLLMに提供します。

素晴らしい、これでユーザーのリクエストを処理する準備ができました。次はそれに取り組みましょう。

### -4 ユーザーのプロンプトリクエストを処理する

このコード部分では、ユーザーからのリクエストを処理します。

素晴らしい、できましたね！

## 課題

演習のコードを基に、さらにいくつかのツールを備えたサーバーを構築してください。その後、演習のようにLLMを搭載したクライアントを作成し、さまざまなプロンプトでテストして、サーバーのツールが動的に呼び出されることを確認しましょう。このようにクライアントを構築することで、エンドユーザーは正確なクライアントコマンドを知らなくてもプロンプトを使って操作でき、MCPサーバーが呼び出されていることに気づかずに済むため、優れたユーザー体験を提供できます。

## 解答例

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要なポイント

- クライアントにLLMを追加することで、ユーザーがMCPサーバーとより良くやり取りできるようになる。
- MCPサーバーの応答をLLMが理解できる形式に変換する必要がある。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

## 次に進む

- 次へ: [Visual Studio Codeを使ったサーバーの利用](/03-GettingStarted/04-vscode/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。