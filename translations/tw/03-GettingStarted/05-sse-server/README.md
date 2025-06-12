<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T21:23:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tw"
}
-->
現在我們對 SSE 有更多了解了，接下來來建立一個 SSE 伺服器。

## 練習：建立 SSE 伺服器

要建立我們的伺服器，需要記住兩件事：

- 我們需要使用網頁伺服器來開放連接和訊息的端點。
- 建立伺服器的方式跟以前使用 stdio 時一樣，使用工具、資源和提示。

### -1- 建立伺服器實例

建立伺服器時，我們使用跟 stdio 相同的類型，不過傳輸方式要選 SSE。

---

接著我們來新增所需的路由。

### -2- 新增路由

新增處理連接和接收訊息的路由：

---

接下來為伺服器加入功能。

### -3- 新增伺服器功能

現在 SSE 相關的設定都完成了，接著加入伺服器功能，比如工具、提示和資源。

---

完整程式碼應該長這樣：

---

太好了，我們已經有一個使用 SSE 的伺服器，接下來試著運行看看。

## 練習：用 Inspector 除錯 SSE 伺服器

Inspector 是我們之前課程 [建立你的第一個伺服器](/03-GettingStarted/01-first-server/README.md) 中看到的好工具，來試試看能不能用在這裡：

### -1- 執行 Inspector

要執行 Inspector，必須先啟動 SSE 伺服器，接著：

1. 啟動伺服器

---

1. 啟動 Inspector

    > ![NOTE]
    > 請在跟伺服器不同的終端機視窗執行這個指令。並且要調整下面指令中的 URL，符合你伺服器運行的位置。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Inspector 在各種執行環境下操作方式都一樣。注意，我們不是傳入伺服器的路徑和啟動指令，而是傳入伺服器運行的 URL，並指定 `/sse` 路由。

### -2- 試用工具

在下拉選單中選 SSE，填入伺服器運行的 URL，例如 http:localhost:4321/sse，然後按「Connect」按鈕。跟之前一樣，選擇列出工具、選擇工具並輸入參數，你會看到類似下圖的結果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tw.png)

太棒了，你已經能用 Inspector 了，接下來看看怎麼用 Visual Studio Code。

## 作業

試著為你的伺服器加入更多功能。可以參考[這個網站](https://api.chucknorris.io/)新增呼叫 API 的工具，伺服器長什麼樣子由你決定。玩得開心 :)

## 解答

[解答](./solution/README.md) 這裡有一個可行的解答範例。

## 重要重點

這章節的重點如下：

- SSE 是繼 stdio 之後支援的第二種傳輸方式。
- 支援 SSE 需要使用網頁框架管理連接和訊息。
- 你可以用 Inspector 和 Visual Studio Code 來使用 SSE 伺服器，就像 stdio 伺服器一樣。不同的是，SSE 需要先啟動伺服器，然後再執行 Inspector 工具，且 Inspector 需要指定 URL。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 額外資源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 接下來學什麼

- 下一課：[使用 MCP 的 HTTP 串流 (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。本公司對因使用本翻譯所導致之任何誤解或誤譯概不負責。