<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-16T15:12:10+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

`uv` のインストールを推奨しますが、必須ではありません。詳細は[instructions](https://docs.astral.sh/uv/#highlights)を参照してください。

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

サーバーに接続したら：

- ツールの一覧を表示し、`add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` はそのラッパーです。

以下のコマンドを実行すると、CLIモードで直接起動できます：

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

これでサーバーで利用可能な全ツールが一覧表示されます。次のような出力が得られるはずです：

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> ブラウザよりもCLIモードでインスペクターを実行したほうが通常ははるかに高速です。
> インスペクターの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)を参照してください。

**免責事項**:  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の母国語版が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。