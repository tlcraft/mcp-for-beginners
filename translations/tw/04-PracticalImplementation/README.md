<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:07:28+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tw"
}
-->
# 實務應用

實務應用是讓 Model Context Protocol (MCP) 的威力具體展現的階段。雖然理解 MCP 的理論與架構很重要，但真正的價值在於將這些概念應用於建構、測試及部署解決方案，解決實際問題。本章節將彌補概念知識與實作開發之間的落差，引導你完成基於 MCP 的應用程式開發流程。

無論你是在開發智慧助理、將 AI 整合進商業流程，或是打造自訂的資料處理工具，MCP 都提供了彈性的基礎。其語言無關的設計以及針對主流程式語言的官方 SDK，使各種開發者都能輕鬆上手。透過這些 SDK，你可以快速原型設計、反覆迭代，並在不同平台與環境中擴展你的解決方案。

接下來的章節中，你會看到實務範例、示範程式碼與部署策略，展示如何在 C#、Java、TypeScript、JavaScript 及 Python 中實作 MCP。你也將學習如何除錯與測試 MCP 伺服器、管理 API，並使用 Azure 將解決方案部署到雲端。這些實作資源旨在加速你的學習，幫助你自信地打造穩健且可投入生產的 MCP 應用。

## 概覽

本課程聚焦於 MCP 在多種程式語言中的實務應用。我們將探討如何使用 C#、Java、TypeScript、JavaScript 及 Python 的 MCP SDK，建構穩健的應用程式，除錯與測試 MCP 伺服器，以及建立可重複使用的資源、提示與工具。

## 學習目標

完成本課程後，你將能夠：
- 使用官方 SDK 在多種程式語言中實作 MCP 解決方案
- 系統性地除錯與測試 MCP 伺服器
- 建立並使用伺服器功能（資源、提示與工具）
- 設計有效的 MCP 工作流程以處理複雜任務
- 優化 MCP 實作以提升效能與可靠性

## 官方 SDK 資源

Model Context Protocol 提供多種語言的官方 SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用 MCP SDK

本節提供多種程式語言中實作 MCP 的實務範例。你可以在 `samples` 目錄中找到依語言分類的示範程式碼。

### 可用範例

此儲存庫包含以下語言的[示範實作](../../../04-PracticalImplementation/samples)：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

每個範例都展示該語言及生態系中 MCP 的核心概念與實作模式。

## 核心伺服器功能

MCP 伺服器可以實作以下任意組合的功能：

### 資源
資源提供使用者或 AI 模型所需的上下文與資料：
- 文件庫
- 知識庫
- 結構化資料來源
- 檔案系統

### 提示
提示是為使用者設計的模板訊息與工作流程：
- 預先定義的對話模板
- 引導式互動模式
- 專門化的對話結構

### 工具
工具是供 AI 模型執行的功能：
- 資料處理工具
- 外部 API 整合
- 計算能力
- 搜尋功能

## 範例實作：C#

官方 C# SDK 儲存庫包含多個示範實作，展示 MCP 的不同面向：

- **基礎 MCP 用戶端**：簡單範例示範如何建立 MCP 用戶端並呼叫工具
- **基礎 MCP 伺服器**：最小化伺服器實作，包含基本工具註冊
- **進階 MCP 伺服器**：完整功能伺服器，含工具註冊、驗證與錯誤處理
- **ASP.NET 整合**：示範如何與 ASP.NET Core 整合
- **工具實作模式**：多種工具實作模式，涵蓋不同複雜度

MCP C# SDK 目前仍為預覽版，API 可能會變動。我們會持續更新此部落格以反映 SDK 的演進。

### 主要功能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 建立你的[第一個 MCP 伺服器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)。

完整的 C# 實作範例，請參考[官方 C# SDK 範例儲存庫](https://github.com/modelcontextprotocol/csharp-sdk)

## 範例實作：Java 實作

Java SDK 提供企業級功能的強大 MCP 實作選項。

### 主要功能

- Spring Framework 整合
- 強型別安全
- 反應式程式設計支援
- 完整的錯誤處理

完整的 Java 實作範例，請參考 samples 目錄中的 [Java 範例](samples/java/containerapp/README.md)。

## 範例實作：JavaScript 實作

JavaScript SDK 提供輕量且彈性的 MCP 實作方式。

### 主要功能

- 支援 Node.js 與瀏覽器
- 基於 Promise 的 API
- 易於與 Express 及其他框架整合
- 支援 WebSocket 串流

完整的 JavaScript 實作範例，請參考 samples 目錄中的 [JavaScript 範例](samples/javascript/README.md)。

## 範例實作：Python 實作

Python SDK 提供符合 Python 風格的 MCP 實作，並與主流機器學習框架整合良好。

### 主要功能

- 支援 asyncio 的 async/await
- FastAPI 整合
- 簡易的工具註冊
- 原生整合熱門機器學習函式庫

完整的 Python 實作範例，請參考 samples 目錄中的 [Python 範例](samples/python/README.md)。

## API 管理

Azure API Management 是保護 MCP 伺服器的絕佳方案。其概念是在 MCP 伺服器前端放置 Azure API Management 實例，讓它處理你可能需要的功能，例如：

- 流量限制
- 令牌管理
- 監控
- 負載平衡
- 安全性

### Azure 範例

這裡有一個 Azure 範例，正是實現上述功能，也就是[建立 MCP 伺服器並用 Azure API Management 保護它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下圖展示了授權流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

圖中發生的流程：

- 使用 Microsoft Entra 進行身份驗證與授權。
- Azure API Management 作為閘道，並透過政策管理與導向流量。
- Azure Monitor 記錄所有請求以供後續分析。

#### 授權流程

讓我們更詳細地看看授權流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP 授權規範

深入了解 [MCP 授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 將遠端 MCP 伺服器部署到 Azure

讓我們試著部署前面提到的範例：

1. 複製儲存庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 註冊 `Microsoft.App` 資源提供者。
    * 若使用 Azure CLI，執行 `az provider register --namespace Microsoft.App --wait`。
    * 若使用 Azure PowerShell，執行 `Register-AzResourceProvider -ProviderNamespace Microsoft.App`。稍後執行 `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 以確認註冊是否完成。

2. 執行此 [azd](https://aka.ms/azd) 指令，佈建 API 管理服務、Function App（含程式碼）及其他所需 Azure 資源

    ```shell
    azd up
    ```

    此指令將在 Azure 上部署所有雲端資源。

### 使用 MCP Inspector 測試你的伺服器

1. 在**新終端機視窗**中，安裝並執行 MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你應該會看到類似以下的介面：

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. 按住 CTRL 並點擊，從應用程式顯示的 URL（例如 http://127.0.0.1:6274/#resources）載入 MCP Inspector 網頁應用
1. 將傳輸類型設定為 `SSE`
1. 將 URL 設為你執行中 API Management SSE 端點（`azd up` 後顯示的），然後**連線**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。點擊某個工具並**執行工具**。

若所有步驟順利完成，你現在應該已連接到 MCP 伺服器，並成功呼叫了一個工具。

## Azure 的 MCP 伺服器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：這組儲存庫是使用 Azure Functions 以 Python、C# .NET 或 Node/TypeScript 快速建立與部署自訂遠端 MCP（Model Context Protocol）伺服器的範本。

這些範例提供完整解決方案，讓開發者能夠：

- 本地建置與執行：在本機開發與除錯 MCP 伺服器
- 部署到 Azure：透過簡單的 azd up 指令輕鬆部署到雲端
- 從用戶端連接：支援從多種用戶端連接 MCP 伺服器，包括 VS Code 的 Copilot 代理模式與 MCP Inspector 工具

### 主要功能：

- 以安全為設計核心：MCP 伺服器透過金鑰與 HTTPS 保護
- 驗證選項：支援使用內建驗證及/或 API Management 的 OAuth
- 網路隔離：支援使用 Azure 虛擬網路 (VNET) 進行網路隔離
- 無伺服器架構：利用 Azure Functions 實現可擴展的事件驅動執行
- 本地開發：完整的本地開發與除錯支援
- 簡易部署：流暢的 Azure 部署流程

儲存庫包含所有必要的設定檔、原始碼與基礎架構定義，讓你能快速啟動生產就緒的 MCP 伺服器實作。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Azure Functions 與 Python 的 MCP 範例實作

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 Azure Functions 與 C# .NET 的 MCP 範例實作

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Azure Functions 與 Node/TypeScript 的 MCP 範例實作。

## 重要重點

- MCP SDK 提供針對不同語言的工具，協助實作穩健的 MCP 解決方案
- 除錯與測試流程對於可靠的 MCP 應用至關重要
- 可重複使用的提示模板能確保 AI 互動的一致性
- 良好設計的工作流程能協調多個工具完成複雜任務
- 實作 MCP 解決方案時需考量安全性、效能與錯誤處理

## 練習

設計一個實用的 MCP 工作流程，解決你領域中的真實問題：

1. 確認 3-4 個對解決此問題有幫助的工具
2. 繪製工作流程圖，展示這些工具如何互動
3. 使用你偏好的程式語言實作其中一個工具的基礎版本
4. 建立一個提示模板，幫助模型有效使用你的工具

## 其他資源


---

下一章節：[進階主題](../05-AdvancedTopics/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。