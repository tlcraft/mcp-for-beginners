<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T16:02:14+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "mo"
}
-->
太好了，接下來我們列出伺服器上的功能。

### -2 列出伺服器功能

現在我們將連接到伺服器並請求其功能列表：

### -3 將伺服器功能轉換為 LLM 工具

列出伺服器功能後的下一步是將它們轉換成 LLM 能理解的格式。完成後，我們就能將這些功能作為工具提供給 LLM。

太好了，我們還沒準備好處理使用者請求，接下來就來解決這個問題。

### -4 處理使用者提示請求

在這段程式碼中，我們將處理使用者的請求。

太棒了，你完成了！

## 作業

請從練習中取得程式碼，並為伺服器新增更多工具。接著像練習中一樣建立一個帶有 LLM 的客戶端，並用不同的提示測試，確保所有伺服器工具都能動態被呼叫。這種建立客戶端的方式能讓最終使用者有更好的體驗，因為他們可以使用自然語言提示，而不必輸入精確的客戶端指令，也不會察覺背後有 MCP 伺服器被呼叫。

## 解答

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要重點

- 在客戶端加入 LLM，能提供使用者更好的方式與 MCP 伺服器互動。
- 你需要將 MCP 伺服器的回應轉換成 LLM 能理解的格式。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 其他資源

## 下一步

- 下一步：[使用 Visual Studio Code 消費伺服器](../04-vscode/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。