<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-16T14:58:19+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行

このサンプルではクライアント側にLLMを用意します。LLMを動かすには、Codespacesで実行するか、GitHubでパーソナルアクセストークンを設定する必要があります。

## -1- 依存関係のインストール

```bash
npm install
```

## -3- サーバーの起動

```bash
npm run build
```

## -4- クライアントの起動

```sh
npm run client
```

次のような結果が表示されるはずです：

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**免責事項**：  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知おきください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の使用により生じたいかなる誤解や誤訳についても、一切の責任を負いかねます。