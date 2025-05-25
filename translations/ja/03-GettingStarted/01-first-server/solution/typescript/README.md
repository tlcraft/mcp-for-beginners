<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-16T15:10:31+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

`uv` のインストールを推奨しますが、必須ではありません。詳しくは[instructions](https://docs.astral.sh/uv/#highlights)をご覧ください。

## -1- 依存関係のインストール

```bash
npm install
```

## -3- サンプルの実行

```bash
npm run build
```

## -4- サンプルのテスト

サーバーを一つのターミナルで起動した状態で、別のターミナルを開き、次のコマンドを実行してください：

```bash
npm run inspector
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

サーバーが接続されたら：

- ツールの一覧表示を試し、`add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` はそのラッパーです。

次のコマンドを実行することで、CLIモードで直接起動できます：

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

これでサーバーで利用可能なすべてのツールが一覧表示されます。以下のような出力が表示されるはずです：

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
> ブラウザよりもCLIモードでinspectorを実行する方が通常はずっと高速です。
> inspectorについての詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、一切の責任を負いかねます。