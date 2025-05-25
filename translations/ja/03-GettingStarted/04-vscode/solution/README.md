<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-16T15:15:55+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ja"
}
-->
# サンプルの実行

ここではすでに動作するサーバーコードがあるものとします。前の章のいずれかからサーバーを探してください。

## mcp.json の設定

参考用のファイルとして [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json) があります。

必要に応じて server エントリを変更し、サーバーへの絶対パスと実行に必要なフルコマンドを指定してください。

上記の例ファイルの server エントリは次のようになっています：

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

これは次のようなコマンドを実行することに対応しています：`cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` 例えば「add 3 to 20」と入力します。

    チャットテキストボックスの上にツールを選択して実行できることを示す表示が出るはずです。以下のような画面です：

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ja.png)

    ツールを選択すると、先ほどのようなプロンプトの場合は「23」という数値結果が出力されるはずです。

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知ください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。