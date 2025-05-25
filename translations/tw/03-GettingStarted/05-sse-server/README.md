<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-17T11:29:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tw"
}
-->
# SSE 伺服器

SSE（Server Sent Events）是一種伺服器到客戶端的串流標準，允許伺服器透過 HTTP 向客戶端推送即時更新。這對於需要即時更新的應用程式特別有用，例如聊天應用程式、通知或即時資料饋送。此外，您的伺服器可以同時被多個客戶端使用，因為它可以在雲端的伺服器上運行。

## 概述

本課程涵蓋如何建立和使用 SSE 伺服器。

## 學習目標

在本課程結束時，您將能夠：

- 建立 SSE 伺服器。
- 使用 Inspector 調試 SSE 伺服器。
- 使用 Visual Studio Code 使用 SSE 伺服器。

## SSE 的運作原理

SSE 是兩種支援的傳輸類型之一。您已經在前面的課程中看到過第一種 stdio 的使用。其差異如下：

- SSE 需要您處理兩件事：連接和訊息。
- 由於這是一個可以在任何地方運行的伺服器，您需要在使用 Inspector 和 Visual Studio 等工具時反映出這一點。這意味著，您不再指出如何啟動伺服器，而是指向它可以建立連接的端點。請參見以下範例代碼：
您已接受訓練的資料截至 2023 年 10 月。

現在我們對 SSE 有了更多的了解，接下來讓我們建立一個 SSE 伺服器。

## 練習：建立一個 SSE 伺服器

要建立我們的伺服器，我們需要記住兩件事：

- 我們需要使用網路伺服器來公開連接和訊息的端點。
- 像我們通常使用 stdio 時一樣，使用工具、資源和提示來構建我們的伺服器。

### -1- 建立伺服器實例

要建立我們的伺服器，我們使用與 stdio 相同的類型。然而，對於傳輸，我們需要選擇 SSE。

接下來讓我們添加所需的路由。

### -2- 添加路由

接下來讓我們添加處理連接和傳入訊息的路由：

接下來讓我們為伺服器添加功能。

### -3- 添加伺服器功能

現在我們已經定義了所有 SSE 特定的內容，讓我們添加像工具、提示和資源這樣的伺服器功能。

您的完整代碼應如下所示：

太好了，我們有一個使用 SSE 的伺服器，接下來讓我們試用一下。

## 練習：使用 Inspector 調試 SSE 伺服器

Inspector 是一個我們在之前的課程中見過的很好的工具 [建立您的第一個伺服器](/03-GettingStarted/01-first-server/README.md)。讓我們看看我們是否也可以在這裡使用 Inspector：

### -1- 運行 Inspector

要運行 Inspector，您首先必須有一個運行中的 SSE 伺服器，所以讓我們接下來這樣做：

1. 運行伺服器

1. 運行 Inspector

    > ![NOTE]
    > 在與伺服器運行的不同終端窗口中運行這個。還要注意，您需要調整以下命令以適應伺服器運行的 URL。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    在所有運行環境中運行 Inspector 看起來都是一樣的。注意我們不是傳遞一個伺服器的路徑和一個啟動伺服器的命令，而是傳遞伺服器運行的 URL，我們還指定了 `/sse` 路由。

### -2- 試用工具

通過選擇下拉列表中的 SSE 並在 URL 欄位中填寫伺服器運行的網址來連接伺服器，例如 http:localhost:4321/sse。現在點擊 "Connect" 按鈕。和之前一樣，選擇列出工具，選擇一個工具並提供輸入值。您應該會看到如下結果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.12861eb95abecbfc82610f480b55901524fed1a6aca025bb948e09e882c48428.tw.png)

太好了，您能夠使用 Inspector，接下來讓我們看看如何使用 Visual Studio Code。

## 作業

嘗試建立更多功能的伺服器。參見 [此頁面](https://api.chucknorris.io/) 例如添加一個調用 API 的工具，您決定伺服器應該是什麼樣的。祝您玩得開心 :)

## 解決方案

[解決方案](./solution/README.md) 這是一個可能的解決方案，帶有有效代碼。

## 重要收穫

本章的收穫如下：

- SSE 是繼 stdio 之後的第二種支援的傳輸。
- 要支援 SSE，您需要使用網路框架管理傳入的連接和訊息。
- 您可以像 stdio 伺服器一樣使用 Inspector 和 Visual Studio Code 使用 SSE 伺服器。注意它在 stdio 和 SSE 之間有些不同。對於 SSE，您需要單獨啟動伺服器，然後運行您的 Inspector 工具。對於 Inspector 工具，還有一些不同之處，您需要指定 URL。

## 範例

- [Java 計算器](../samples/java/calculator/README.md)
- [.Net 計算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](../samples/javascript/README.md)
- [TypeScript 計算器](../samples/typescript/README.md)
- [Python 計算器](../../../../03-GettingStarted/samples/python)

## 其他資源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 下一步

- 下一步：[開始使用 VSCode 的 AI 工具包](/03-GettingStarted/06-aitk/README.md)

**免責聲明**：
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原文文件作為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們不對因使用此翻譯而引起的任何誤解或誤釋承擔責任。