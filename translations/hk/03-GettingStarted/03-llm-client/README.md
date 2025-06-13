<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:27:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hk"
}
-->
好，下一步，我哋嚟列出伺服器嘅功能。

### -2 列出伺服器功能

而家我哋會連接到伺服器，並且查詢佢嘅功能：


### -3 將伺服器功能轉換成 LLM 工具

列出伺服器功能之後嘅下一步，就係將佢哋轉換成 LLM 可以理解嘅格式。一旦完成，我哋就可以將呢啲功能作為工具提供畀我哋嘅 LLM。


好嘅，依家我哋準備好處理用戶請求，下一步就嚟搞掂佢。

### -4 處理用戶提示請求

喺呢部分嘅程式碼，我哋會處理用戶嘅請求。


好嘢，你做到了！

## 作業

用練習入面嘅程式碼，擴展伺服器，加入多啲工具。然後照住練習咁樣，建立一個帶有 LLM 嘅客戶端，並用唔同嘅提示測試，確保所有伺服器工具都能夠動態調用。咁樣建立嘅客戶端，最終用戶就可以享受到更好嘅體驗，因為佢哋可以用自然語言提示，而唔使記住準確嘅客戶端指令，同時完全唔使理會背後有冇調用 MCP 伺服器。

## 解答

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 主要重點

- 喺客戶端加入 LLM，可以令用戶同 MCP 伺服器嘅互動更加順暢。
- 你需要將 MCP 伺服器嘅回應轉換成 LLM 可以理解嘅格式。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 附加資源

## 下一步

- 下一步：[用 Visual Studio Code 使用伺服器](/03-GettingStarted/04-vscode/README.md)

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯所得。雖然我們致力於確保準確性，但請注意，自動翻譯可能存在錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用此翻譯而引起的任何誤解或誤釋負責。