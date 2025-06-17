<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:45:52+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hk"
}
-->
太好了，接下來我們列出伺服器上的功能。

### -2 列出伺服器功能

現在我們將連接到伺服器並請求它的功能：

### -3 將伺服器功能轉換成 LLM 工具

列出伺服器功能之後的下一步是將它們轉換成 LLM 可以理解的格式。一旦完成，我們就可以把這些功能作為工具提供給 LLM。

太好了，我們還沒準備好處理使用者請求，接下來就來處理這部分。

### -4 處理使用者提示請求

這部分程式碼負責處理使用者的請求。

太棒了，你完成了！

## 作業

請從練習中的程式碼出發，擴充伺服器，加入更多工具。然後像練習中一樣建立一個帶有 LLM 的客戶端，並用不同的提示測試它，確保所有伺服器工具都能動態被呼叫。這種建立客戶端的方式，能讓最終使用者有很棒的體驗，因為他們可以使用自然語言提示，而不必輸入精確的客戶端指令，且完全不需要知道有 MCP 伺服器在背後被呼叫。

## 解答

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 重要重點

- 在客戶端加入 LLM，能提供使用者更好的互動方式來使用 MCP 伺服器。
- 你需要將 MCP 伺服器的回應轉換成 LLM 可以理解的格式。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 其他資源

## 下一步

- 下一課：[使用 Visual Studio Code 消費伺服器](/03-GettingStarted/04-vscode/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於確保翻譯的準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用此翻譯而引致的任何誤解或誤釋概不負責。