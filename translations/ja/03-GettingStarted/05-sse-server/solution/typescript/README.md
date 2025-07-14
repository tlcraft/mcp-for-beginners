<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:19:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

## -1- 依存関係のインストール

```bash
npm install
```

## -3- サンプルの実行

```bash
npm run build
```

## -4- サンプルのテスト

サーバーが一つのターミナルで起動している状態で、別のターミナルを開き、以下のコマンドを実行してください：

```bash
npm run inspector
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

サーバーが接続されたら：

- ツールの一覧を試し、`add` を引数 2 と 4 で実行してみてください。結果に 6 が表示されるはずです。
- resources と resource template に移動し、「greeting」を呼び出して名前を入力すると、入力した名前を使った挨拶が表示されます。

### CLIモードでのテスト

実行したインスペクターは実際には Node.js アプリで、`mcp dev` はそのラッパーです。

- コマンド `npm run build` でサーバーを起動します。

- 別のターミナルで以下のコマンドを実行してください：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    これにより、サーバーで利用可能なすべてのツールが一覧表示されます。以下のような出力が表示されるはずです：

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- 次に、ツールタイプを呼び出すには以下のコマンドを入力します：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

以下のような出力が表示されるはずです：

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> インスペクターをブラウザよりCLIモードで実行するほうが通常はずっと高速です。
> インスペクターの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。