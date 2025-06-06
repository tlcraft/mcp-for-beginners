<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:04:23+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hk"
}
-->
好，下一步，讓我哋列出伺服器嘅能力。

### -2 列出伺服器能力

而家我哋會連接到伺服器，並查詢佢嘅能力：

### -3- 將伺服器能力轉換成 LLM 工具

列出伺服器能力之後，下一步係將佢哋轉換成 LLM 可以理解嘅格式。完成後，我哋就可以將呢啲能力作為工具提供畀 LLM 使用。

好，依家我哋已經準備好處理用戶請求，下一步就係處理呢個部分。

### -4- 處理用戶提示請求

喺呢段代碼入面，我哋會處理用戶嘅請求。

好，你完成咗！

## 作業

用練習入面嘅代碼，喺伺服器度加入多啲工具。然後照練習咁樣創建一個帶有 LLM 嘅客戶端，並用唔同嘅提示測試，確保伺服器所有嘅工具都可以動態調用。咁樣建立嘅客戶端可以俾最終用戶有更好嘅體驗，因為佢哋可以用自然語言提示，而唔使用精確嘅客戶端命令，亦唔使理會有冇 MCP 伺服器被調用。

## 解決方案

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 主要重點

- 加入 LLM 到你嘅客戶端，可以俾用戶有更好嘅方式同 MCP 伺服器互動。
- 你需要將 MCP 伺服器嘅回應轉換成 LLM 可以理解嘅格式。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 額外資源

## 下一步

- 下一步：[使用 Visual Studio Code 消費伺服器](/03-GettingStarted/04-vscode/README.md)

**免責聲明**：  
本文件係用AI翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯。雖然我哋盡力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤譯概不負責。