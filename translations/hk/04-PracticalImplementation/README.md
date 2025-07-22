<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "20064351f7e0fa904e96b057ed742df3",
  "translation_date": "2025-07-22T07:20:19+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hk"
}
-->
# 實際應用

實際應用是 Model Context Protocol (MCP) 展現其強大功能的地方。雖然理解 MCP 的理論和架構很重要，但真正的價值在於如何運用這些概念來構建、測試和部署解決現實問題的方案。本章節旨在縮短概念知識與實際開發之間的距離，指導您如何將基於 MCP 的應用程序付諸實現。

無論您是在開發智能助手、將 AI 整合到業務流程中，還是構建自定義的數據處理工具，MCP 都提供了一個靈活的基礎。其語言無關的設計以及針對流行編程語言的官方 SDK，使得 MCP 對各類開發者都易於使用。通過利用這些 SDK，您可以快速原型設計、迭代並在不同平台和環境中擴展您的解決方案。

在接下來的章節中，您將看到實際範例、示例代碼以及部署策略，展示如何在 C#、Java、TypeScript、JavaScript 和 Python 中實現 MCP。您還將學習如何調試和測試 MCP 伺服器、管理 API，以及使用 Azure 將解決方案部署到雲端。這些實用資源旨在加速您的學習，幫助您自信地構建穩健的、可投入生產的 MCP 應用程序。

## 概述

本課程重點介紹 MCP 在多種編程語言中的實際應用。我們將探討如何使用 MCP SDK 在 C#、Java、TypeScript、JavaScript 和 Python 中構建穩健的應用程序，調試和測試 MCP 伺服器，以及創建可重用的資源、提示和工具。

## 學習目標

完成本課程後，您將能夠：

- 使用官方 SDK 在多種編程語言中實現 MCP 解決方案
- 系統性地調試和測試 MCP 伺服器
- 創建和使用伺服器功能（資源、提示和工具）
- 設計有效的 MCP 工作流程以處理複雜任務
- 優化 MCP 實現以提升性能和可靠性

## 官方 SDK 資源

Model Context Protocol 提供了多種語言的官方 SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用 MCP SDK

本節提供了在多種編程語言中實現 MCP 的實際範例。您可以在 `samples` 目錄中找到按語言分類的示例代碼。

### 可用範例

倉庫中包含以下語言的[示例實現](../../../04-PracticalImplementation/samples)：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

每個示例都展示了該特定語言和生態系統中的關鍵 MCP 概念和實現模式。

## 核心伺服器功能

MCP 伺服器可以實現以下功能的任意組合：

### 資源

資源為用戶或 AI 模型提供上下文和數據：

- 文檔庫
- 知識庫
- 結構化數據源
- 文件系統

### 提示

提示是為用戶設計的模板化消息和工作流程：

- 預定義的對話模板
- 引導式交互模式
- 專門化的對話結構

### 工具

工具是供 AI 模型執行的功能：

- 數據處理工具
- 外部 API 整合
- 計算能力
- 搜索功能

## 示例實現：C# 實現

官方 C# SDK 倉庫包含多個示例實現，展示 MCP 的不同方面：

- **基本 MCP 客戶端**：展示如何創建 MCP 客戶端並調用工具的簡單示例
- **基本 MCP 伺服器**：具有基本工具註冊的最小伺服器實現
- **高級 MCP 伺服器**：功能齊全的伺服器，包含工具註冊、身份驗證和錯誤處理
- **ASP.NET 整合**：展示與 ASP.NET Core 整合的示例
- **工具實現模式**：展示不同複雜程度的工具實現模式

C# MCP SDK 目前處於預覽階段，API 可能會有所變更。我們將隨著 SDK 的演進不斷更新此博客。

### 主要功能

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- 構建您的[第一個 MCP 伺服器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

完整的 C# 實現示例，請訪問[官方 C# SDK 示例倉庫](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例實現：Java 實現

Java SDK 提供了具有企業級功能的穩健 MCP 實現選項。

### 主要功能

- 與 Spring Framework 整合
- 強類型安全性
- 支持反應式編程
- 全面的錯誤處理

完整的 Java 實現示例，請參見 samples 目錄中的 [Java 示例](samples/java/containerapp/README.md)。

## 示例實現：JavaScript 實現

JavaScript SDK 提供了一種輕量且靈活的 MCP 實現方法。

### 主要功能

- 支持 Node.js 和瀏覽器
- 基於 Promise 的 API
- 易於與 Express 和其他框架整合
- 支持 WebSocket 流式傳輸

完整的 JavaScript 實現示例，請參見 samples 目錄中的 [JavaScript 示例](samples/javascript/README.md)。

## 示例實現：Python 實現

Python SDK 提供了一種符合 Python 語言特性的 MCP 實現方法，並與主流機器學習框架有良好的整合。

### 主要功能

- 使用 asyncio 支持 async/await
- 與 FastAPI 整合
- 簡單的工具註冊
- 與流行的機器學習庫原生整合

完整的 Python 實現示例，請參見 samples 目錄中的 [Python 示例](samples/python/README.md)。

## API 管理

Azure API Management 是保護 MCP 伺服器的絕佳解決方案。其核心思想是將 Azure API Management 實例置於 MCP 伺服器之前，並讓其處理您可能需要的功能，例如：

- 限流
- 令牌管理
- 監控
- 負載均衡
- 安全性

### Azure 示例

以下是一個 Azure 示例，展示如何[創建 MCP 伺服器並使用 Azure API Management 保護它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

請參考下圖了解授權流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

在上述圖像中，發生了以下情況：

- 使用 Microsoft Entra 進行身份驗證/授權。
- Azure API Management 作為網關，使用策略來引導和管理流量。
- Azure Monitor 記錄所有請求以供進一步分析。

#### 授權流程

以下是授權流程的詳細說明：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP 授權規範

了解更多關於 [MCP 授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 部署遠程 MCP 伺服器到 Azure

以下是部署前面提到的示例的步驟：

1. 克隆倉庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 註冊 `Microsoft.App` 資源提供者。

   - 如果您使用 Azure CLI，運行 `az provider register --namespace Microsoft.App --wait`。
   - 如果您使用 Azure PowerShell，運行 `Register-AzResourceProvider -ProviderNamespace Microsoft.App`。稍後運行 `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 檢查註冊是否完成。

1. 運行此 [azd](https://aka.ms/azd) 命令以配置 API 管理服務、函數應用（包含代碼）以及所有其他所需的 Azure 資源

    ```shell
    azd up
    ```

    此命令應該會在 Azure 上部署所有雲資源。

### 使用 MCP Inspector 測試您的伺服器

1. 在**新終端窗口**中，安裝並運行 MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    您應該會看到類似以下的界面：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 按住 CTRL 點擊以從應用程序顯示的 URL 加載 MCP Inspector 網頁應用（例如 [http://127.0.0.1:6274/#resources](http://127.0.0.1:6274/#resources)）
1. 將傳輸類型設置為 `SSE`
1. 將 URL 設置為您運行的 API Management SSE 端點（在 `azd up` 後顯示）並**連接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

1. **列出工具**。點擊工具並**運行工具**。

如果所有步驟都成功，您現在應該已連接到 MCP 伺服器，並且能夠調用工具。

## Azure 的 MCP 伺服器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：這些倉庫是使用 Azure Functions 與 Python、C# .NET 或 Node/TypeScript 構建和部署自定義遠程 MCP（Model Context Protocol）伺服器的快速入門模板。

這些示例提供了一個完整的解決方案，允許開發者：

- 本地構建和運行：在本地機器上開發和調試 MCP 伺服器
- 部署到 Azure：使用簡單的 azd up 命令輕鬆部署到雲端
- 從客戶端連接：從各種客戶端（包括 VS Code 的 Copilot agent 模式和 MCP Inspector 工具）連接到 MCP 伺服器

### 主要功能

- 設計安全性：MCP 伺服器使用密鑰和 HTTPS 進行保護
- 身份驗證選項：支持使用內置身份驗證和/或 API Management 的 OAuth
- 網絡隔離：支持使用 Azure 虛擬網絡（VNET）進行網絡隔離
- 無伺服器架構：利用 Azure Functions 實現可擴展的事件驅動執行
- 本地開發：全面的本地開發和調試支持
- 簡化部署：流線型的 Azure 部署過程

倉庫包含所有必要的配置文件、源代碼和基礎設施定義，幫助您快速開始生產就緒的 MCP 伺服器實現。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Python 和 Azure Functions 實現 MCP 的示例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 C# .NET 和 Azure Functions 實現 MCP 的示例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Node/TypeScript 和 Azure Functions 實現 MCP 的示例

## 關鍵要點

- MCP SDK 提供了語言特定的工具，用於實現穩健的 MCP 解決方案
- 調試和測試過程對於可靠的 MCP 應用至關重要
- 可重用的提示模板能夠實現一致的 AI 交互
- 精心設計的工作流程可以使用多個工具協調複雜任務
- 實現 MCP 解決方案需要考慮安全性、性能和錯誤處理

## 練習

設計一個實際的 MCP 工作流程，解決您領域中的現實問題：

1. 確定 3-4 個對解決此問題有用的工具
2. 創建一個工作流程圖，展示這些工具如何交互
3. 使用您偏好的編程語言實現其中一個工具的基本版本
4. 創建一個提示模板，幫助模型有效地使用您的工具

## 其他資源

---

下一步：[高級主題](../05-AdvancedTopics/README.md)

**免責聲明**：  
本文件已使用人工智能翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原文文件作為權威來源。對於關鍵資訊，建議尋求專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或錯誤解讀概不負責。