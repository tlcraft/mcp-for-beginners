<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-04T16:04:52+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "hk"
}
-->
讓我們在接下來的章節中多談談如何使用視覺介面。

## 方法

以下是我們需要採取的高層次步驟：

- 配置一個檔案來找到我們的 MCP Server。
- 啟動／連接該伺服器，讓它列出其功能。
- 透過 GitHub Copilot Chat 介面使用這些功能。

很好，現在我們了解了流程，讓我們透過一個練習嘗試在 Visual Studio Code 中使用 MCP Server。

## 練習：使用伺服器

在這個練習中，我們將配置 Visual Studio Code 以找到你的 MCP 伺服器，讓它能從 GitHub Copilot Chat 介面使用。

### -0- 預備步驟，啟用 MCP Server 探測

你可能需要啟用 MCP Server 的探測功能。

1. 在 Visual Studio Code 中，前往 `檔案 -> 偏好設定 -> 設定`。

2. 搜尋「MCP」，並在 settings.json 檔案中啟用 `chat.mcp.discovery.enabled`。

### -1- 建立設定檔

首先在你的專案根目錄建立一個設定檔，你需要一個名為 MCP.json 的檔案，並將它放在名為 .vscode 的資料夾中。內容應該長這樣：

```text
.vscode
|-- mcp.json
```

接著，讓我們看看如何新增伺服器條目。

### -2- 配置伺服器

將以下內容加入 *mcp.json*：

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

上面是一個簡單的範例，示範如何啟動一個用 Node.js 撰寫的伺服器，其他執行環境請用 `command` 和 `args` 指定正確的啟動指令。

### -3- 啟動伺服器

現在你已新增條目，讓我們啟動伺服器：

1. 在 *mcp.json* 中找到你的條目，並確認你看到「播放」圖示：

  ![在 Visual Studio Code 中啟動伺服器](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.hk.png)  

2. 點擊「播放」圖示，你應該會看到 GitHub Copilot Chat 中的工具圖示顯示可用工具數量增加。點擊該工具圖示，你會看到已註冊工具的清單。你可以勾選或取消勾選每個工具，決定是否讓 GitHub Copilot 將它們作為上下文使用：

  ![在 Visual Studio Code 中啟動伺服器](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.hk.png)

3. 要執行工具，輸入你知道會符合其中一個工具描述的提示，例如「add 22 to 1」：

  ![從 GitHub Copilot 執行工具](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hk.png)

  你應該會看到回應是 23。

## 作業

嘗試在你的 *mcp.json* 檔案中新增一個伺服器條目，並確保你能啟動／停止伺服器。也要確保你能透過 GitHub Copilot Chat 介面與伺服器上的工具溝通。

## 解答

[解答](./solution/README.md)

## 重要重點

本章重點如下：

- Visual Studio Code 是一個很棒的客戶端，讓你能使用多個 MCP Server 及其工具。
- GitHub Copilot Chat 介面是你與伺服器互動的方式。
- 你可以提示使用者輸入像是 API 金鑰等資訊，並在 *mcp.json* 中配置伺服器條目時將這些資訊傳給 MCP Server。

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 額外資源

- [Visual Studio 文件](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 接下來

- 下一步：[建立 SSE 伺服器](../05-sse-server/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。