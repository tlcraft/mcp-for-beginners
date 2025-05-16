<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-16T15:20:10+00:00",
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

サーバーが一つのターミナルで起動している状態で、別のターミナルを開き、以下のコマンドを実行してください。

```bash
npm run inspector
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

サーバーが接続されたら：

- ツールの一覧を表示し、`add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` を実行してみてください。

- 別のターミナルで以下のコマンドを実行します：

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

- 次のコマンドを入力してツールタイプを呼び出します：

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
> ブラウザよりもCLIモードでインスペクターを実行する方が通常はずっと高速です。
> インスペクターの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご理解ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の利用により生じた誤解や誤訳について、一切の責任を負いかねます。