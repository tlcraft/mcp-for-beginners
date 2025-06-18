<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T21:57:21+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "mo"
}
-->
現在我們對 SSE 有更多了解了，接下來讓我們來建立一個 SSE 伺服器。

## 練習：建立 SSE 伺服器

建立伺服器時，我們需要記住兩件事：

- 需要使用網頁伺服器來暴露用於連接和訊息的端點。
- 像使用 stdio 時一樣，使用工具、資源和提示來建構伺服器。

### -1- 建立伺服器實例

建立伺服器時，我們使用與 stdio 相同的類型，但在傳輸方式上，我們需要選擇 SSE。

---

接下來讓我們新增所需的路由。

### -2- 新增路由

接著新增處理連接和接收訊息的路由：

---

接著為伺服器新增功能。

### -3- 新增伺服器功能

現在我們已經定義了所有 SSE 特定的部分，接著加入像是工具、提示和資源等伺服器功能。

---

你的完整程式碼應該長這樣：

---

太好了，我們已經有一個使用 SSE 的伺服器，接下來讓我們試試看。

## 練習：使用 Inspector 偵錯 SSE 伺服器

Inspector 是一個很棒的工具，我們在之前的課程[建立你的第一個伺服器](/03-GettingStarted/01-first-server/README.md)中已經看過。讓我們看看是否也能在這裡使用 Inspector：

### -1- 執行 Inspector

要執行 Inspector，你必須先啟動 SSE 伺服器，讓我們先來啟動它：

1. 執行伺服器

---

1. 執行 Inspector

    > ![NOTE]
    > 請在與伺服器不同的終端視窗執行此指令。另外請注意，你需要根據你的伺服器運行的 URL 調整以下指令。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

在所有執行環境中，執行 Inspector 的方式都相同。注意這裡我們不是傳入伺服器的路徑或啟動指令，而是傳入伺服器運行的 URL，並且指定了 `/sse` 路由。

### -2- 試用工具

在下拉選單中選擇 SSE，並填入你的伺服器運行的 URL，例如 http://localhost:4321/sse。然後點擊「Connect」按鈕。和之前一樣，選擇列出工具、選擇工具並提供輸入值。你應該會看到如下結果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.mo.png)

太棒了，你已經可以使用 Inspector，接下來我們看看如何使用 Visual Studio Code。

## 作業

試著為你的伺服器新增更多功能。參考 [這個頁面](https://api.chucknorris.io/) 來新增一個呼叫 API 的工具。伺服器的樣子由你決定，玩得開心 :)

## 解答

[解答](./solution/README.md) 這裡有一個可能的解答範例，附有可運行的程式碼。

## 主要重點

本章的主要重點如下：

- SSE 是繼 stdio 之後第二個支援的傳輸方式。
- 支援 SSE 需要使用網頁框架來管理進入的連接和訊息。
- 你可以像使用 stdio 伺服器一樣，使用 Inspector 和 Visual Studio Code 來使用 SSE 伺服器。注意 stdio 和 SSE 之間有些差異。對 SSE 來說，你需要先啟動伺服器，然後再執行 Inspector 工具。Inspector 工具也有差異，需要指定 URL。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 其他資源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 接下來

- 下一課：[使用 MCP 的 HTTP 串流（可串流的 HTTP）](/03-GettingStarted/06-http-streaming/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。對於因使用本翻譯而產生的任何誤解或誤譯，我們不承擔任何責任。