<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:27:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tw"
}
-->
很好，接下來，我們來列出伺服器上的能力。

### -2 列出伺服器能力

現在我們將連接到伺服器並請求其能力列表：

### -3 將伺服器能力轉換為 LLM 工具

列出伺服器能力後的下一步是將它們轉換成 LLM 可以理解的格式。完成後，我們就能把這些能力當作工具提供給 LLM。

很好，我們現在還沒設定好處理使用者請求的部分，接下來就來處理這部分。

### -4 處理使用者提示請求

這段程式碼中，我們會處理使用者的請求。

太棒了，你完成了！

## 作業

請使用練習中的程式碼，擴充伺服器並加入更多工具。接著像練習中一樣建立一個帶有 LLM 的客戶端，並用不同的提示測試，確保所有伺服器工具都能動態被呼叫。這種建立客戶端的方式，能讓最終使用者享有更棒的體驗，因為他們可以使用自然語言提示，而不需要精確的客戶端指令，也不必知道背後有 MCP 伺服器被呼叫。

## 解答

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 主要重點

- 在客戶端加入 LLM，能提供使用者更好的互動方式與 MCP 伺服器。
- 你需要將 MCP 伺服器的回應轉換成 LLM 能理解的格式。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 額外資源

## 接下來

- 下一步：[使用 Visual Studio Code 消費伺服器](/03-GettingStarted/04-vscode/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用此翻譯而產生的任何誤解或誤譯負責。