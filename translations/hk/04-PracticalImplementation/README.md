<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:43:11+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hk"
}
-->
# 實務應用

實務應用是 Model Context Protocol (MCP) 的威力真正展現的地方。雖然理解 MCP 的理論和架構很重要，但真正的價值在於將這些概念應用於構建、測試和部署解決方案，解決現實世界的問題。本章節將填補概念知識與實際開發之間的鴻溝，帶領你完成基於 MCP 的應用程式實現過程。

無論你是在開發智能助理、將 AI 整合到業務流程中，還是打造自訂的數據處理工具，MCP 都提供了彈性的基礎。它的語言無關設計以及針對主流程式語言的官方 SDK，使各類開發者都能輕鬆使用。透過這些 SDK，你可以快速建立原型、反覆優化，並在不同平台和環境中擴展你的解決方案。

接下來的章節中，你將看到實務範例、示範程式碼和部署策略，展示如何在 C#、Java、TypeScript、JavaScript 和 Python 中實作 MCP。你還會學到如何除錯和測試 MCP 伺服器、管理 API，以及使用 Azure 部署解決方案。這些實作資源能加速你的學習，幫助你自信地打造穩健且適合生產環境的 MCP 應用。

## 概述

本課程聚焦於多種程式語言中 MCP 實作的實務面向。我們將探索如何使用 C#、Java、TypeScript、JavaScript 和 Python 的 MCP SDK 來建立穩健的應用程式，除錯和測試 MCP 伺服器，並創建可重複使用的資源、提示和工具。

## 學習目標

完成本課程後，你將能夠：
- 使用官方 SDK 在多種程式語言中實作 MCP 解決方案
- 系統性地除錯和測試 MCP 伺服器
- 創建並使用伺服器功能（資源、提示和工具）
- 設計有效的 MCP 工作流程以處理複雜任務
- 優化 MCP 實作的效能與可靠性

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

此倉庫包含以下語言的[示範實作](../../../04-PracticalImplementation/samples)：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

每個範例都展示了該語言及生態系中 MCP 的核心概念和實作模式。

## 核心伺服器功能

MCP 伺服器可實作以下任意組合的功能：

### 資源
資源為使用者或 AI 模型提供上下文和數據：
- 文件庫
- 知識庫
- 結構化資料來源
- 檔案系統

### 提示
提示是為使用者設計的模板訊息和工作流程：
- 預設的對話模板
- 引導式互動模式
- 專門的對話結構

### 工具
工具是供 AI 模型執行的函式：
- 數據處理工具
- 外部 API 整合
- 計算功能
- 搜尋功能

## 範例實作：C#

官方 C# SDK 倉庫包含多個示範實作，展示 MCP 的不同面向：

- **基本 MCP 客戶端**：簡單示範如何建立 MCP 客戶端並呼叫工具
- **基本 MCP 伺服器**：最小化伺服器實作，包含基本工具註冊
- **進階 MCP 伺服器**：功能完整的伺服器，包含工具註冊、認證與錯誤處理
- **ASP.NET 整合**：示範與 ASP.NET Core 的整合
- **工具實作模式**：多種工具實作範例，涵蓋不同複雜度

MCP C# SDK 尚在預覽階段，API 可能會有變動。我們將持續更新此部落格以反映 SDK 的演進。

### 主要功能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 建立你的[第一個 MCP 伺服器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)。

完整 C# 實作範例，請參考[官方 C# SDK 範例倉庫](https://github.com/modelcontextprotocol/csharp-sdk)

## 範例實作：Java 實作

Java SDK 提供企業級的 MCP 實作方案，具備強大功能。

### 主要功能

- Spring Framework 整合
- 強型別安全
- 反應式程式設計支援
- 全面錯誤處理

完整 Java 實作範例請參考 samples 目錄下的 [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## 範例實作：JavaScript 實作

JavaScript SDK 提供輕量且彈性的 MCP 實作方式。

### 主要功能

- 支援 Node.js 與瀏覽器
- 基於 Promise 的 API
- 易於與 Express 及其他框架整合
- 支援 WebSocket 串流

完整 JavaScript 實作範例請參考 samples 目錄下的 [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## 範例實作：Python 實作

Python SDK 以 Python 風格實作 MCP，並與主流機器學習框架良好整合。

### 主要功能

- 支援 asyncio 的 async/await
- Flask 與 FastAPI 整合
- 簡單的工具註冊
- 與熱門機器學習庫原生整合

完整 Python 實作範例請參考 samples 目錄下的 [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API 管理

Azure API Management 是保護 MCP 伺服器的理想方案。其理念是在 MCP 伺服器前端放置 Azure API Management 實例，讓它負責你可能需要的功能，例如：

- 流量限制
- 令牌管理
- 監控
- 負載平衡
- 安全性

### Azure 範例

這是一個 Azure 範例，示範如何[建立 MCP 伺服器並用 Azure API Management 保護它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下圖展示了授權流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

圖中發生的流程包括：

- 使用 Microsoft Entra 進行認證與授權
- Azure API Management 作為閘道，並透過政策管理流量
- Azure Monitor 記錄所有請求以供後續分析

#### 授權流程

讓我們更詳細看授權流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP 授權規範

深入了解 [MCP 授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 將遠端 MCP 伺服器部署到 Azure

接著示範如何部署前面提到的範例：

1. 複製倉庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 註冊 `Microsoft.App` 提供者，執行 `az provider register --namespace Microsoft.App --wait` 或 `Register-AzResourceProvider -ProviderNamespace Microsoft.App`，稍後可用 `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 檢查是否完成註冊。

2. 執行此 [azd](https://aka.ms/azd) 指令來佈署 API 管理服務、函式應用（含程式碼）及其他所需的 Azure 資源

    ```shell
    azd up
    ```

    此指令會將所有雲端資源部署到 Azure。

### 使用 MCP Inspector 測試你的伺服器

1. 在 **新終端機視窗** 中安裝並執行 MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你應該會看到類似以下介面：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 按住 CTRL 點擊從應用顯示的 URL 載入 MCP Inspector 網頁應用（例如 http://127.0.0.1:6274/#resources）
1. 將傳輸類型設為 `SSE`，然後 **連接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。點擊某個工具並 **執行工具**。

若以上步驟成功，你現在應已連接至 MCP 伺服器並成功呼叫工具。

## Azure 上的 MCP 伺服器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：這組倉庫是使用 Azure Functions 搭配 Python、C# .NET 或 Node/TypeScript 快速建立和部署自訂遠端 MCP (Model Context Protocol) 伺服器的範本。

這些範例提供完整解決方案，讓開發者能夠：

- 本地建置與執行：在本機開發並除錯 MCP 伺服器
- 部署到 Azure：使用簡單的 azd up 指令輕鬆部署到雲端
- 從客戶端連線：可從各種客戶端連接 MCP 伺服器，包括 VS Code 的 Copilot 代理模式和 MCP Inspector 工具

### 主要功能：

- 安全設計：MCP 伺服器透過金鑰與 HTTPS 保護
- 認證選項：支援內建認證和/或 API 管理的 OAuth
- 網路隔離：可使用 Azure 虛擬網路 (VNET) 實現網路隔離
- 無伺服器架構：利用 Azure Functions 實現可擴展的事件驅動執行
- 本地開發：完整的本地開發與除錯支援
- 簡易部署：流暢的 Azure 部署流程

此倉庫包含所有必要的設定檔、原始碼及基礎架構定義，助你快速啟動生產級 MCP 伺服器實作。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Azure Functions 與 Python 實作 MCP 的範例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 Azure Functions 與 C# .NET 實作 MCP 的範例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Azure Functions 與 Node/TypeScript 實作 MCP 的範例

## 重要重點

- MCP SDK 提供針對各語言的工具，以實作穩健的 MCP 解決方案
- 除錯與測試流程對可靠的 MCP 應用至關重要
- 可重用的提示模板能確保 AI 互動的一致性
- 良好設計的工作流程能協調多工具完成複雜任務
- 實作 MCP 解決方案需考量安全性、效能與錯誤處理

## 練習

設計一個實用的 MCP 工作流程，以解決你領域中的真實問題：

1. 識別 3-4 個對解決此問題有用的工具
2. 繪製一張工作流程圖，顯示這些工具如何互動
3. 使用你偏好的程式語言實作其中一個工具的基礎版本
4. 創建一個提示模板，幫助模型有效使用你的工具

## 其他資源


---

下一章節：[進階主題](../05-AdvancedTopics/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。因使用本翻譯所引致的任何誤解或誤釋，我們概不負責。