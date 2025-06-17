<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:45:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "mo"
}
-->
太好了，接下來我們來列出伺服器上的功能。

### -2 列出伺服器功能

現在我們將連接到伺服器並請求它的功能：

### -3- 將伺服器功能轉換為 LLM 工具

列出伺服器功能後的下一步是將它們轉換成 LLM 能理解的格式。完成後，我們可以把這些功能作為工具提供給 LLM。

太好了，我們還沒有準備好處理使用者請求，接下來就來解決這個問題。

### -4- 處理使用者提示請求

在這段程式碼中，我們將處理使用者的請求。

太棒了，你完成了！

## 作業

從練習中的程式碼出發，為伺服器新增更多工具。然後像練習中一樣建立一個帶有 LLM 的客戶端，並用不同的提示測試，確保所有伺服器工具都能動態被呼叫。這種建立客戶端的方式能帶給最終使用者良好的使用體驗，因為他們可以用自然語言提示，而不必使用精確的客戶端指令，且不會察覺到背後有 MCP 伺服器被呼叫。

## 解答

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要重點

- 為客戶端加入 LLM，能讓使用者與 MCP 伺服器互動的方式更友善。
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
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用此翻譯所引起的任何誤解或誤釋負責。