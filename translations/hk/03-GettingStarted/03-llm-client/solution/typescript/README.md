<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:53:38+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "hk"
}
-->
# 運行這個範例

這個範例需要在客戶端上有一個LLM。LLM需要你在Codespaces中運行這個，或者在GitHub中設置一個個人訪問令牌來工作。

## -1- 安裝依賴項

```bash
npm install
```

## -3- 運行伺服器

```bash
npm run build
```

## -4- 運行客戶端

```sh
npm run client
```

你應該會看到類似的結果：

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**免責聲明**：
本文件已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要信息，建議使用專業人工翻譯。我們對於使用此翻譯而引起的任何誤解或誤譯不承擔責任。