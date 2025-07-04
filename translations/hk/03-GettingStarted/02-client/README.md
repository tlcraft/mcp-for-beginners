<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T16:04:27+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hk"
}
-->
在前面的程式碼中，我們：

- 匯入了所需的函式庫
- 建立了一個 client 實例，並使用 stdio 作為傳輸方式進行連接
- 列出了 prompts、resources 和 tools，並呼叫了它們全部

這樣就完成了一個能與 MCP Server 通訊的 client。

接下來的練習部分，我們會慢慢拆解每段程式碼並說明其運作原理。

## 練習：撰寫一個 client

如前所述，我們會花時間詳細解釋程式碼，如果你願意，也可以跟著一起寫。

### -1- 匯入函式庫

先匯入我們需要的函式庫，我們會用到 client 和選擇的傳輸協定 stdio。stdio 是設計用於本機執行的協定。SSE 是另一種傳輸協定，我們會在後續章節介紹，但目前先用 stdio 繼續。

讓我們繼續進行實例化。

### -2- 實例化 client 和傳輸協定

我們需要建立傳輸協定的實例，還有 client 的實例： 

### -3- 列出伺服器功能

現在，我們有一個能連接的 client（假如程式執行的話）。不過它還沒列出伺服器的功能，接下來就來做這件事：

太好了，現在我們已經取得所有功能。那麼問題是，什麼時候會用到它們呢？這個 client 很簡單，意思是我們必須在需要時明確呼叫這些功能。下一章我們會建立一個更進階的 client，能夠存取自己的大型語言模型（LLM）。不過現在，先來看看如何呼叫伺服器上的功能：

### -4- 呼叫功能

要呼叫功能，我們必須確保指定正確的參數，有時還要指定要呼叫的功能名稱。

### -5- 執行 client

要執行 client，請在終端機輸入以下指令：

## 作業

在這個作業中，你將運用所學來建立自己的 client。

這裡有一個伺服器可以使用，你需要透過 client 程式碼呼叫它，試著為伺服器新增更多功能，讓它更有趣。

## 解答

[解答](./solution/README.md)

## 重要重點

本章關於 client 的重要重點如下：

- 可以用來發現並呼叫伺服器上的功能
- 可以在啟動自己的同時啟動伺服器（如本章所示），但 client 也能連接已在運行的伺服器
- 是測試伺服器功能的好方法，與前章提到的 Inspector 等替代方案並列

## 額外資源

- [在 MCP 中建立 client](https://modelcontextprotocol.io/quickstart/client)

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 接下來

- 下一步：[使用 LLM 建立 client](../03-llm-client/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋承擔責任。