<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-16T15:21:56+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

`uv` のインストールを推奨しますが、必須ではありません。詳細は[instructions](https://docs.astral.sh/uv/#highlights)をご覧ください。

## -0- 仮想環境の作成

```bash
python -m venv venv
```

## -1- 仮想環境の有効化

```bash
venv\Scrips\activate
```

## -2- 依存関係のインストール

```bash
pip install "mcp[cli]"
```

## -3- サンプルの実行

```bash
mcp run server.py
```

## -4- サンプルのテスト

サーバーを一つのターミナルで起動したまま、別のターミナルを開いて以下のコマンドを実行してください：

```bash
mcp dev server.py
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

サーバーに接続されたら：

- ツールの一覧を表示し、`add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` はそのラッパーです。

以下のコマンドを実行すると、CLIモードで直接起動できます：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

これでサーバー内の利用可能なツールが一覧表示されます。以下のような出力が確認できるはずです：

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

ツールを呼び出すには、以下のように入力します：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

次のような出力が表示されるはずです：

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> ブラウザよりもCLIモードでインスペクターを実行したほうが通常はずっと高速です。
> インスペクターの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語での文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。