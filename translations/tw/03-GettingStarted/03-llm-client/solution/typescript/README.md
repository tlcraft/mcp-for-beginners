<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:53:44+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

這個範例需要在客戶端上擁有一個 LLM。你需要在 Codespaces 中執行它，或者在 GitHub 中設置一個個人訪問權限令牌來使其工作。

## -1- 安裝依賴項

```bash
npm install
```

## -3- 啟動伺服器

```bash
npm run build
```

## -4- 啟動客戶端

```sh
npm run client
```

你應該會看到類似以下的結果：

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**免責聲明**：
本文檔使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們努力確保翻譯準確，但請注意，自動翻譯可能包含錯誤或不精確之處。應以原始語言的文件作為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對使用此翻譯而引起的任何誤解或誤釋不承擔責任。