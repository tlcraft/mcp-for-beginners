<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:43:53+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hk"
}
-->
而家我哋對 SSE 有多啲認識，下一步就嚟建立一個 SSE 伺服器。

## 練習：建立 SSE 伺服器

要建立我哋嘅伺服器，需要記住兩樣嘢：

- 需要用一個網絡伺服器去開放端點，處理連線同訊息。
- 用同平時用 stdio 時一樣嘅工具、資源同提示去建立伺服器。

### -1- 建立伺服器實例

建立伺服器時，我哋用嘅類型同 stdio 一樣，但傳輸方式要揀 SSE。

---

而家加多啲路由。

### -2- 加入路由

下一步加入處理連線同收到訊息嘅路由： 

---

接住加啲伺服器功能。

### -3- 加入伺服器功能

而家我哋已經定義咗所有 SSE 相關嘅嘢，下一步加啲伺服器功能，例如工具、提示同資源。

---

你嘅完整程式碼應該係咁：

---

好啦，我哋而家有個用 SSE 嘅伺服器，試下運行佢啦。

## 練習：用 Inspector 偵錯 SSE 伺服器

Inspector 係個好用嘅工具，我哋喺之前嘅課堂 [建立你嘅第一個伺服器](/03-GettingStarted/01-first-server/README.md) 已經見過。試下喺呢度用下 Inspector：

### -1- 運行 Inspector

要運行 Inspector，首先要有個 SSE 伺服器喺度運行，咁我哋而家就做：

1. 運行伺服器

---

1. 運行 Inspector

    > ![NOTE]
    > 呢個要喺另一個終端機視窗運行，唔好同伺服器用同一個。另外記住，要調整下面嘅指令，配合你伺服器運行嘅 URL。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    喺所有執行環境入面，運行 Inspector 都係一樣。留意我哋唔係傳入啟動伺服器嘅路徑同指令，而係傳入伺服器運行嘅 URL，仲要指定 `/sse` 呢個路由。

### -2- 試用工具

喺下拉選單揀 SSE，再填入你伺服器運行嘅 URL，例如 http:localhost:4321/sse。跟住撳「Connect」按鈕。跟之前一樣，揀列出工具、揀工具同輸入值。你應該會見到以下結果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hk.png)

好嘢，你已經可以用 Inspector 了，下一步睇下點用 Visual Studio Code。

## 作業

試下擴展你嘅伺服器功能。可以參考 [呢個網頁](https://api.chucknorris.io/) 加一個調用 API 嘅工具，點樣設計伺服器由你決定。玩得開心啲 :)

## 解答

[解答](./solution/README.md) 呢度有一個可行嘅解答同完整程式碼。

## 主要重點

本章嘅重點係：

- SSE 係繼 stdio 之後第二種支援嘅傳輸方式。
- 要支援 SSE，你需要用網絡框架去管理連線同訊息。
- 你可以用 Inspector 同 Visual Studio Code 去使用 SSE 伺服器，就好似用 stdio 伺服器一樣。留意 stdio 同 SSE 有啲唔同，SSE 需要先獨立啟動伺服器，再運行 Inspector 工具。用 Inspector 嘅時候，亦要指定 URL。

## 範例

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 額外資源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 下一步

- 下一課：[HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於提供準確的翻譯，但請注意自動翻譯可能包含錯誤或不準確之處。原文的母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們對因使用此翻譯而引致的任何誤解或誤釋概不負責。