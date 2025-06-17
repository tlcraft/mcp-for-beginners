<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:46:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tw"
}
-->
太好了，接下來我們列出伺服器上的功能。

### -2 列出伺服器功能

現在我們將連接到伺服器並請求其功能：


### -3- 將伺服器功能轉換為 LLM 工具

列出伺服器功能後的下一步是將它們轉換成 LLM 能理解的格式。完成後，我們可以將這些功能作為工具提供給 LLM。


太好了，我們還沒設定好處理使用者請求，接下來就來解決這個問題。

### -4- 處理使用者提示請求

這部分程式碼將負責處理使用者的請求。


太棒了，你完成了！

## 作業

從練習中取得程式碼，並在伺服器上新增更多工具。接著像練習中一樣建立一個帶有 LLM 的用戶端，並用不同的提示進行測試，確保伺服器上的所有工具都能動態被呼叫。這種建立用戶端的方式能讓最終使用者有極佳的體驗，因為他們可以用提示語言互動，而不用精確輸入用戶端指令，也不會察覺到背後有 MCP 伺服器在被呼叫。

## 解答

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 主要重點

- 在用戶端加入 LLM，能提供使用者更好的互動方式來操作 MCP 伺服器。
- 需要將 MCP 伺服器的回應轉換成 LLM 可以理解的格式。

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
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生之任何誤解或誤譯負責。