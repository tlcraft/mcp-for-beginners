<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-13T17:47:44+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

## -1- 依存関係のインストール

```bash
dotnet restore
```

## -3- サンプルの実行

```bash
dotnet run
```

## -4- サンプルのテスト

サーバーが一つのターミナルで動作している状態で、別のターミナルを開き、以下のコマンドを実行してください：

```bash
npx @modelcontextprotocol/inspector dotnet run
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

サーバーが接続されたら：

- ツールの一覧を試し、`add` を引数 2 と 4 で実行すると、結果に 6 が表示されるはずです。
- resources と resource template に移動し、「greeting」を呼び出して名前を入力すると、入力した名前を使った挨拶が表示されます。

### CLIモードでのテスト

以下のコマンドを実行すると、直接CLIモードで起動できます：

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

これにより、サーバーで利用可能なすべてのツールが一覧表示されます。以下のような出力が表示されるはずです：

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

ツールを呼び出すには、以下のように入力します：

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

以下のような出力が表示されるはずです：

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> インスペクターをブラウザよりCLIモードで実行するほうが通常はずっと速いです。
> インスペクターの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。