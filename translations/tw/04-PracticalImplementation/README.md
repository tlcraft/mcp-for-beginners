<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:03:00+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tw"
}
-->
# Practical Implementation

實務應用是 Model Context Protocol (MCP) 真正發揮威力的地方。雖然了解 MCP 的理論與架構很重要，但真正的價值在於你如何運用這些概念來建置、測試並部署解決真實問題的方案。本章節將橋接概念知識與實務開發，帶領你一步步實現基於 MCP 的應用程式。

無論你是在開發智慧助理、將 AI 整合到商業流程，或是打造自訂的資料處理工具，MCP 都提供了彈性的基礎架構。它的語言無關設計及針對熱門程式語言提供的官方 SDK，使得各種開發者都能輕鬆使用。透過這些 SDK，你可以快速進行原型設計、反覆調整，並在不同平台與環境中擴展你的解決方案。

接下來的章節中，你會看到實務範例、示範程式碼與部署策略，展示如何在 C#、Java、TypeScript、JavaScript 和 Python 中實作 MCP。你也會學到如何除錯與測試 MCP 伺服器、管理 API，並利用 Azure 部署解決方案。這些實作資源將幫助你加速學習，並自信地打造穩健且可投入生產的 MCP 應用。

## Overview

本課程聚焦於多種程式語言中 MCP 實作的實務面向。我們將探討如何使用 C#、Java、TypeScript、JavaScript 和 Python 的 MCP SDK，打造穩健的應用程式，並除錯、測試 MCP 伺服器，以及建立可重複使用的資源、提示與工具。

## Learning Objectives

完成本課程後，你將能夠：
- 使用官方 SDK 以多種程式語言實作 MCP 解決方案
- 系統性地除錯與測試 MCP 伺服器
- 建立並使用伺服器功能（資源、提示與工具）
- 設計有效的 MCP 工作流程以處理複雜任務
- 優化 MCP 實作以提升效能與可靠度

## Official SDK Resources

Model Context Protocol 提供多種語言的官方 SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

本節提供多種程式語言中實作 MCP 的實務範例。你可以在 `samples` 目錄中依語言找到示範程式碼。

### Available Samples

這個倉庫包含以下語言的範例實作：

- C#
- Java
- TypeScript
- JavaScript
- Python

每個範例都展示該語言及生態系中 MCP 重要概念與實作模式。

## Core Server Features

MCP 伺服器可實作以下任意組合的功能：

### Resources
資源提供使用者或 AI 模型可用的上下文與資料：
- 文件庫
- 知識庫
- 結構化資料來源
- 檔案系統

### Prompts
提示是為使用者設計的範本訊息與工作流程：
- 預先定義的對話範本
- 指引式互動模式
- 專門的對話結構

### Tools
工具是 AI 模型可執行的函式：
- 資料處理工具
- 外部 API 整合
- 計算能力
- 搜尋功能

## Sample Implementations: C#

官方 C# SDK 倉庫包含多個範例，展示 MCP 不同面向：

- **Basic MCP Client**：簡單示範如何建立 MCP 用戶端並呼叫工具
- **Basic MCP Server**：最小化伺服器實作，含基本工具註冊
- **Advanced MCP Server**：功能完整的伺服器，包含工具註冊、驗證與錯誤處理
- **ASP.NET Integration**：示範如何與 ASP.NET Core 整合
- **Tool Implementation Patterns**：多種工具實作模式，涵蓋不同複雜度

MCP C# SDK 目前仍在預覽階段，API 可能會有變動。我們會持續更新此部落格，跟進 SDK 發展。

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 建立你的[第一個 MCP 伺服器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

完整的 C# 實作範例，請參考[官方 C# SDK 範例倉庫](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK 提供企業級功能的強大 MCP 實作選項。

### Key Features

- Spring Framework 整合
- 強型別安全
- 反應式程式設計支援
- 全面錯誤處理

完整 Java 實作範例，請參考 samples 目錄中的 [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## Sample implementation: JavaScript Implementation

JavaScript SDK 提供輕量且彈性的 MCP 實作方式。

### Key Features

- 支援 Node.js 與瀏覽器
- Promise-based API
- 容易與 Express 及其他框架整合
- 支援 WebSocket 串流

完整 JavaScript 實作範例，請參考 samples 目錄中的 [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## Sample implementation: Python Implementation

Python SDK 以 Pythonic 風格實作 MCP，並與主流機器學習框架整合良好。

### Key Features

- 支援 asyncio 的 async/await
- Flask 與 FastAPI 整合
- 簡易的工具註冊
- 原生整合熱門機器學習函式庫

完整 Python 實作範例，請參考 samples 目錄中的 [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API management 

Azure API Management 是保護 MCP 伺服器的絕佳解決方案。想法是在 MCP 伺服器前面放置一個 Azure API Management 實例，並讓它處理你可能需要的功能，例如：

- 流量限制
- 令牌管理
- 監控
- 負載平衡
- 安全性

### Azure Sample

這裡有一個 Azure 範例，就是[建立 MCP 伺服器並用 Azure API Management 保護它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下圖展示授權流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

圖中發生的事情：

- 使用 Microsoft Entra 進行身份驗證與授權
- Azure API Management 作為閘道，並透過政策來導向與管理流量
- Azure Monitor 記錄所有請求以供後續分析

#### Authorization flow

讓我們更詳細看看授權流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

深入了解 [MCP 授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server to Azure

我們來試著部署先前提到的範例：

1. Clone 倉庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. 註冊 `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`，稍等一會兒確認註冊是否完成。

3. 執行此 [azd](https://aka.ms/azd) 指令來佈署 API 管理服務、函式應用（含程式碼）及所有其他必要的 Azure 資源

    ```shell
    azd up
    ```

    此指令會將所有雲端資源部署到 Azure

### Testing your server with MCP Inspector

1. 在 **新的終端機視窗**，安裝並執行 MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你應該會看到類似以下的介面：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tw.png) 

2. 按住 CTRL 並點擊，從應用程式顯示的 URL（例如 http://127.0.0.1:6274/#resources）載入 MCP Inspector 網頁應用
3. 將傳輸類型設定為 `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`，然後按 **Connect**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。點選一個工具並 **執行工具**。

如果以上步驟都成功，你現在應該已連線到 MCP 伺服器，並能呼叫工具。

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：這組倉庫是用於快速啟動並部署自訂遠端 MCP (Model Context Protocol) 伺服器的範本，支援使用 Azure Functions 搭配 Python、C# .NET 或 Node/TypeScript。

這些範例提供完整解決方案，讓開發者能夠：

- 本地端建置與執行：在本機開發並除錯 MCP 伺服器
- 部署到 Azure：使用簡單的 azd up 指令輕鬆部署到雲端
- 從客戶端連接：支援多種客戶端連接，包括 VS Code 的 Copilot agent 模式與 MCP Inspector 工具

### Key Features:

- 以安全為設計核心：MCP 伺服器透過金鑰與 HTTPS 保護
- 驗證選項：支援內建驗證與/或 API Management 的 OAuth
- 網路隔離：允許使用 Azure 虛擬網路 (VNET) 進行網路隔離
- 無伺服器架構：利用 Azure Functions 實現可擴展、事件驅動的執行
- 本地開發：完整的本地開發與除錯支援
- 簡易部署：簡化的 Azure 部署流程

倉庫包含所有必要的設定檔、原始碼與基礎建設定義，讓你能快速開始生產環境等級的 MCP 伺服器實作。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Azure Functions 與 Python 實作 MCP 範例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 Azure Functions 與 C# .NET 實作 MCP 範例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Azure Functions 與 Node/TypeScript 實作 MCP 範例

## Key Takeaways

- MCP SDK 提供語言專屬的工具，方便實作穩健的 MCP 解決方案
- 除錯與測試流程對可靠的 MCP 應用至關重要
- 可重複使用的提示範本能確保 AI 互動的一致性
- 良好設計的工作流程可協調多種工具完成複雜任務
- 實作 MCP 解決方案需考慮安全性、效能與錯誤處理

## Exercise

設計一個實用的 MCP 工作流程，解決你領域中的真實問題：

1. 找出 3-4 個適合解決此問題的工具
2. 繪製工作流程圖，展示這些工具如何互動
3. 使用你偏好的程式語言，實作其中一個工具的基本版本
4. 建立一個提示範本，幫助模型有效使用你的工具

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們努力追求準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對於因使用本翻譯所產生之任何誤解或誤譯不負任何責任。