<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-17T11:03:09+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "tw"
}
-->
讓我們在接下來的部分中更詳細地討論如何使用視覺介面。

## 方法

以下是我們需要如何高層次地處理這個問題：

- 配置一個文件以尋找我們的 MCP 伺服器。
- 啟動/連接該伺服器以列出其功能。
- 通過 GitHub Copilot 的聊天介面使用這些功能。

很好，既然我們了解了流程，讓我們通過一個練習嘗試使用 Visual Studio Code 使用 MCP 伺服器。

## 練習：使用伺服器

在這個練習中，我們將配置 Visual Studio Code 以尋找您的 MCP 伺服器，以便可以從 GitHub Copilot 的聊天介面中使用它。

### -0- 前置步驟，啟用 MCP 伺服器發現

您可能需要啟用 MCP 伺服器的發現功能。

1. 在 settings.json 文件中，前往 `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled`。

### -1- 創建配置文件

首先在您的專案根目錄中創建一個配置文件，您需要一個名為 MCP.json 的文件，並將其放置在一個名為 .vscode 的文件夾中。它應該看起來像這樣：

```text
.vscode
|-- mcp.json
```

接下來，讓我們看看如何添加伺服器條目。

### -2- 配置伺服器

將以下內容添加到 *mcp.json* 中：

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

上面是一個如何啟動用 Node.js 編寫的伺服器的簡單示例，對於其他運行時，請指出使用 `command` and `args` 啟動伺服器的正確命令。

### -3- 啟動伺服器

現在您已經添加了一個條目，讓我們啟動伺服器：

1. 在 *mcp.json* 中找到您的條目，並確保您找到“播放”圖標：

  ![在 Visual Studio Code 中啟動伺服器](../../../../translated_images/vscode-start-server.c7f1132263a8ce789fa7f436eb3df7e36199ebf863f1a8205bfc4483c9e40924.tw.png)  

1. 點擊“播放”圖標，您應該會看到 GitHub Copilot 聊天中的工具圖標增加了可用工具的數量。如果您點擊該工具圖標，您將看到註冊工具的列表。您可以根據是否希望 GitHub Copilot 使用它們作為上下文來檢查/取消檢查每個工具：

  ![在 Visual Studio Code 中啟動伺服器](../../../../translated_images/vscode-tool.ce37be05a56b9af258f882c161dbf35e23ac885b08ee5f5ee643097653b135b8.tw.png)

1. 要運行工具，輸入一個您知道會匹配您工具描述的提示，例如這樣的提示“將 22 加到 1”：

  ![從 GitHub Copilot 運行工具](../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.tw.png)

  您應該會看到一個回應說 23。

## 作業

嘗試向您的 *mcp.json* 文件添加一個伺服器條目，並確保您可以啟動/停止伺服器。確保您也可以通過 GitHub Copilot 的聊天介面與伺服器上的工具進行通信。

## 解答

[解答](./solution/README.md)

## 主要收穫

本章的收穫如下：

- Visual Studio Code 是一個很棒的客戶端，讓您可以使用多個 MCP 伺服器及其工具。
- GitHub Copilot 的聊天介面是您與伺服器互動的方式。
- 您可以提示用戶輸入如 API 金鑰之類的內容，這些內容可以在 *mcp.json* 文件中配置伺服器條目時傳遞給 MCP 伺服器。

## 範例

- [Java 計算器](../samples/java/calculator/README.md)
- [.Net 計算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](../samples/javascript/README.md)
- [TypeScript 計算器](../samples/typescript/README.md)
- [Python 計算器](../../../../03-GettingStarted/samples/python) 

## 其他資源

- [Visual Studio 文件](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 接下來是什麼

- 下一步：[創建 SSE 伺服器](/03-GettingStarted/05-sse-server/README.md)

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為權威來源。對於關鍵信息，建議使用專業人工翻譯。對於因使用此翻譯而產生的任何誤解或誤釋，我們不承擔責任。