<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:04:10+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

`uv` のインストールを推奨しますが、必須ではありません。詳しくは [instructions](https://docs.astral.sh/uv/#highlights) をご覧ください。

## -1- 依存関係のインストール

```bash
npm install
```

## -3- サンプルの実行

```bash
npm run build
```

## -4- サンプルのテスト

サーバーを一つのターミナルで起動したまま、別のターミナルを開いて以下のコマンドを実行してください：

```bash
npm run inspector
```

これで、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動するはずです。

サーバーに接続したら：

- ツールの一覧を表示し、`add` を引数 2 と 4 で実行してみてください。結果に 6 が表示されるはずです。
- resources と resource template に移動し、「greeting」を呼び出して名前を入力すると、入力した名前を使った挨拶が表示されます。

### CLIモードでのテスト

実行している inspector は実際には Node.js アプリで、`mcp dev` はそのラッパーです。

以下のコマンドを実行すると、CLIモードで直接起動できます：

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

これでサーバー上のすべてのツールが一覧表示されます。以下のような出力が得られるはずです：

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

以下のような出力が表示されるはずです：

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
> inspector をブラウザで使うよりも、CLIモードで実行したほうが通常はずっと高速です。
> inspector についての詳細は [こちら](https://github.com/modelcontextprotocol/inspector) をご覧ください。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。