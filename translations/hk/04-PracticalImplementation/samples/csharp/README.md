<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:47:34+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "hk"
}
-->
# 範例

之前的範例展示了如何使用本地的 .NET 專案與 `stdio` 類型，並且如何在容器中本地執行伺服器。這在很多情況下都是不錯的解決方案。不過，有時候讓伺服器遠端運行會更有用，比如在雲端環境中。這時就會用到 `http` 類型。

看看 `04-PracticalImplementation` 資料夾中的解決方案，乍看之下可能比之前的複雜得多，但其實並非如此。如果仔細看 `src/Calculator` 專案，你會發現它大部分程式碼和前一個範例差不多。唯一的差別是我們使用了不同的函式庫 `ModelContextProtocol.AspNetCore` 來處理 HTTP 請求，並且將 `IsPrime` 方法改成 private，這只是為了展示你可以在程式碼中使用私有方法。其他程式碼和之前一樣。

其他專案來自 [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview)。在解決方案中加入 .NET Aspire，可以提升開發者在開發和測試時的體驗，並有助於可觀察性。雖然執行伺服器不一定需要，但在解決方案中加入它是個好習慣。

## 本地啟動伺服器

1. 在 VS Code（安裝了 C# DevKit 擴充功能）中，切換到 `04-PracticalImplementation/samples/csharp` 目錄。
1. 執行以下指令來啟動伺服器：

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. 當瀏覽器開啟 .NET Aspire 儀表板時，記下 `http` 的 URL，通常會是類似 `http://localhost:5058/`。

   ![.NET Aspire 儀表板](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.hk.png)

## 使用 MCP Inspector 測試 Streamable HTTP

如果你有 Node.js 22.7.5 或以上版本，可以使用 MCP Inspector 來測試你的伺服器。

啟動伺服器後，在終端機執行以下指令：

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.hk.png)

- 選擇 `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`，它應該是 `http`（而不是 `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp`）伺服器，畫面會像這樣：

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

進行一些測試：

- 請求「6780 之後的 3 個質數」，注意 Copilot 會使用新的工具 `NextFivePrimeNumbers`，並只回傳前三個質數。
- 請求「111 之後的 7 個質數」，看看結果如何。
- 請求「John 有 24 顆棒棒糖，要分給他三個小孩，每個小孩有多少顆？」，看看會發生什麼。

## 將伺服器部署到 Azure

讓我們把伺服器部署到 Azure，讓更多人可以使用。

在終端機中切換到 `04-PracticalImplementation/samples/csharp` 資料夾，執行以下指令：

```bash
azd up
```

部署完成後，應該會看到類似這樣的訊息：

![Azd 部署成功](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.hk.png)

拿到 URL 後，可以在 MCP Inspector 和 GitHub Copilot Chat 中使用。

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## 接下來呢？

我們會嘗試不同的傳輸類型和測試工具，也會把你的 MCP 伺服器部署到 Azure。但如果伺服器需要存取私有資源呢？例如資料庫或私有 API？下一章，我們將探討如何提升伺服器的安全性。

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋承擔責任。