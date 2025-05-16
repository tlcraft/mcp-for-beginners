<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-16T15:17:39+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ja"
}
-->
SSEについて少し理解したところで、次はSSEサーバーを作ってみましょう。

## 演習：SSEサーバーの作成

サーバーを作るにあたって、以下の2点を意識しましょう：

- 接続とメッセージ用のエンドポイントを公開するために、Webサーバーを使う必要がある。
- stdioを使っていた時と同様に、ツールやリソース、プロンプトを使ってサーバーを構築する。

### -1- サーバーインスタンスの作成

サーバーを作成するには、stdioの時と同じ型を使います。ただし、transportにはSSEを選択します。  

次に必要なルートを追加しましょう。

### -2- ルートの追加

接続と受信メッセージを処理するルートを追加します。  

次はサーバーの機能を追加していきます。

### -3- サーバー機能の追加

SSE特有の部分が定義できたので、ツールやプロンプト、リソースなどのサーバー機能を追加しましょう。  

完成したコードは以下のようになります。

素晴らしい、SSEを使ったサーバーができましたね。次はこれを動かしてみましょう。

## 演習：Inspectorを使ったSSEサーバーのデバッグ

Inspectorは前のレッスン[最初のサーバーを作成する](/03-GettingStarted/01-first-server/README.md)で使った便利なツールです。ここでも使えるか試してみましょう。

### -1- Inspectorの起動

Inspectorを使うには、まずSSEサーバーが起動している必要があります。では起動しましょう：

1. サーバーを起動する  

1. Inspectorを起動する

    > ![NOTE]
    > サーバーを起動しているターミナルとは別のウィンドウで実行してください。また、以下のコマンドはサーバーが動作しているURLに合わせて調整してください。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Inspectorの起動方法はすべてのランタイムで共通です。サーバーのパスや起動コマンドを渡す代わりに、サーバーが動作しているURLと`/sse`ルートを指定している点に注目してください。

### -2- ツールの試用

ドロップダウンリストからSSEを選択し、サーバーが動いているURL（例: http://localhost:4321/sse）を入力します。次に「Connect」ボタンをクリック。前回同様、ツール一覧からツールを選び、入力値を与えましょう。以下のような結果が表示されるはずです：

![Inspectorで動作するSSEサーバー](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ja.png)

うまくInspectorで操作できましたね。次はVisual Studio Codeでの使い方を見てみましょう。

## 課題

より多機能なサーバーを作ってみましょう。例えば[こちらのページ](https://api.chucknorris.io/)を参考にAPIを呼び出すツールを追加するなど、サーバーの形は自由です。楽しんでくださいね :)

## 解答例

[解答例](./solution/README.md) 動作するコードの一例です。

## まとめ

この章のポイントは以下の通りです：

- SSEはstdioに次ぐ2番目のサポートされるtransportです。
- SSEをサポートするには、Webフレームワークを使って接続とメッセージの管理が必要です。
- InspectorやVisual Studio Codeの両方でSSEサーバーを利用可能ですが、stdioとは少し違いがあります。SSEではサーバーを別途起動し、その後Inspectorツールを起動します。またInspectorではURLの指定が必要です。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 次に進む

- 次へ：[VSCode用AI Toolkitの使い方](/03-GettingStarted/06-aitk/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の母国語版が正式な情報源として扱われるべきです。重要な情報については、専門の人間翻訳をご利用いただくことを推奨します。本翻訳の使用により生じた誤解や誤訳について、一切の責任を負いかねますのでご了承ください。