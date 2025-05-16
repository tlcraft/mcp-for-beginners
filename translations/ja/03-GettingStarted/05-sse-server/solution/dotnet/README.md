<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-16T15:21:04+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

## -1- 依存関係のインストール

```bash
dotnet run
```

## -2- サンプルの実行

```bash
dotnet run
```

## -3- サンプルのテスト

以下を実行する前に別のターミナルを開いてください（サーバーがまだ動作していることを確認してください）。

サーバーが一つのターミナルで動作している状態で、別のターミナルを開き、次のコマンドを実行します：

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

サーバーに接続されたら：

- ツールの一覧を試し、引数2と4で`add`を実行すると、結果に6が表示されるはずです。
- resourcesとresource templateに移動し、「greeting」を呼び出して名前を入力すると、入力した名前入りの挨拶が表示されます。

### CLIモードでのテスト

以下のコマンドを実行すると、直接CLIモードで起動できます：

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

これにより、サーバーで利用可能なすべてのツールが一覧表示されます。以下のような出力が表示されるはずです：

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

ツールを呼び出すには、以下を入力します：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> ブラウザよりもCLIモードでinspectorを実行したほうが通常はずっと速いです。
> inspectorの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の言語で記載された文書が権威ある情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、一切の責任を負いかねます。