<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:25:53+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ja"
}
-->
# サンプルの実行

ここでは、すでに動作するサーバーコードがあることを前提としています。前の章のいずれかからサーバーを見つけてください。

## mcp.json の設定

参照用のファイルとして [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json) があります。

必要に応じて server エントリを変更し、実行に必要なフルコマンドを含むサーバーへの絶対パスを指定してください。

上記の例ファイルの server エントリは次のようになっています：

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

これは次のようなコマンドを実行することに対応しています：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` 例えば「add 3 to 20」のような入力をしてください。

    チャットのテキストボックスの上にツールが表示され、ツールを実行するために選択するよう促されるはずです。以下のような画面になります：

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ja.png)

    ツールを選択すると、先ほどの例のようなプロンプトであれば「23」という数値結果が表示されるはずです。

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の使用により生じた誤解や解釈の相違について、当方は一切の責任を負いかねます。