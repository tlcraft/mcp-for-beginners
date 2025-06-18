<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:16:27+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "ja"
}
-->
# サンプルの実行

## -1- 依存関係のインストール

```bash
dotnet restore
```

## -2- サンプルの実行

```bash
dotnet run
```

## -3- サンプルのテスト

以下を実行する前に、別のターミナルを開いて（サーバーがまだ動作していることを確認してください）。

一方のターミナルでサーバーを起動したまま、別のターミナルを開いて次のコマンドを実行します：

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

これにより、サンプルをテストできるビジュアルインターフェース付きのウェブサーバーが起動します。

> **Streamable HTTP** がトランスポートタイプとして選択されていること、URLが `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add` であることを確認してください。引数に2と4を指定すると、結果に6が表示されるはずです。  
> - resources と resource template に移動し、「greeting」を呼び出して名前を入力すると、入力した名前で挨拶が表示されます。

### CLIモードでのテスト

次のコマンドを実行することで、直接CLIモードで起動できます：

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

ツールを呼び出すには、次のように入力します：

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
> ブラウザよりもCLIモードでインスペクターを実行したほうが通常はずっと高速です。  
> インスペクターの詳細は[こちら](https://github.com/modelcontextprotocol/inspector)をご覧ください。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知おきください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。