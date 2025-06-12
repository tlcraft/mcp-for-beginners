<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T21:36:36+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ja"
}
-->
さて、SSEについて少し理解できたので、次はSSEサーバーを作ってみましょう。

## 演習：SSEサーバーの作成

サーバーを作成するにあたり、次の2点を意識する必要があります：

- 接続とメッセージ用のエンドポイントを公開するために、ウェブサーバーを使うこと。
- stdioを使っていたときと同様に、ツールやリソース、プロンプトを使ってサーバーを構築すること。

### -1- サーバーインスタンスの作成

サーバーを作成する際は、stdioと同じタイプを使います。ただし、transportにはSSEを選択します。 

---

次に必要なルートを追加しましょう。

### -2- ルートの追加

接続と受信メッセージを処理するルートを追加します：

---

次にサーバーの機能を追加していきましょう。

### -3- サーバー機能の追加

SSE特有の設定ができたので、ツールやプロンプト、リソースなどサーバーの機能を追加します。

---

完成したコードは次のようになります：

---

素晴らしい、SSEを使ったサーバーができました。次は実際に動かしてみましょう。

## 演習：Inspectorを使ったSSEサーバーのデバッグ

Inspectorは、前のレッスン[最初のサーバーの作成](/03-GettingStarted/01-first-server/README.md)で見た素晴らしいツールです。ここでも使えるか試してみましょう。

### -1- Inspectorの起動

Inspectorを起動するには、まずSSEサーバーが起動している必要があります。では、起動してみましょう：

1. サーバーを起動する

---

1. Inspectorを起動する

    > ![NOTE]
    > サーバーが動いているターミナルとは別のウィンドウで実行してください。また、以下のコマンドはサーバーが動いているURLに合わせて調整が必要です。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspectorの実行方法はどのランタイムでも同じです。サーバーの起動パスやコマンドを渡す代わりに、サーバーが動作しているURLを指定し、さらに`/sse`ルートを指定している点に注目してください。

### -2- ツールの試用

ドロップダウンリストからSSEを選択し、サーバーが動作しているURL（例：http://localhost:4321/sse）を入力します。次に「Connect」ボタンをクリック。前回と同様にツールの一覧を取得し、ツールを選択して入力値を渡すと、以下のような結果が表示されます：

![Inspectorで動作中のSSEサーバー](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ja.png)

素晴らしい、Inspectorでの操作ができました。次はVisual Studio Codeでの使い方を見てみましょう。

## 課題

サーバーにさらに機能を追加してみてください。例えば[このページ](https://api.chucknorris.io/)を参考にAPIを呼び出すツールを追加するなど、サーバーの設計は自由です。楽しんでくださいね :)

## 解答例

[解答例](./solution/README.md) 実際に動くコードの一例です。

## まとめ

この章のポイントは以下の通りです：

- SSEはstdioに次ぐ2番目のサポートされているtransportです。
- SSEをサポートするには、ウェブフレームワークを使って接続とメッセージを管理する必要があります。
- InspectorやVisual Studio Codeはstdioサーバーと同様にSSEサーバーを扱えます。ただし、stdioとSSEでは少し違いがあります。SSEではサーバーを別途起動してからInspectorを起動し、InspectorではURLを指定する必要があります。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## 追加リソース

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 次に学ぶこと

- 次へ: [MCPによるHTTPストリーミング（Streamable HTTP）](/03-GettingStarted/06-http-streaming/README.md)

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書を正式な情報源とみなしてください。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用に起因するいかなる誤解や誤訳についても、一切の責任を負いかねます。