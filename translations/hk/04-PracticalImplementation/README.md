<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:44:13+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hk"
}
-->
# 實際應用

實際應用是讓模型上下文協議（MCP）的力量變得具體可感的地方。理解MCP的理論和架構固然重要，但真正的價值在於你如何應用這些概念來構建、測試和部署解決實際問題的方案。本章將概念知識與實際開發橋接起來，指導你如何將基於MCP的應用程序付諸實現。

無論你是在開發智能助手、將AI整合到業務流程中，還是構建自定義的數據處理工具，MCP都提供了一個靈活的基礎。它的語言無關設計和針對流行編程語言的官方SDK使其對廣泛的開發者群體都可用。通過利用這些SDK，你可以快速原型化、迭代並在不同平台和環境中擴展你的解決方案。

在接下來的部分中，你會找到實際例子、樣本代碼和部署策略，展示如何在C#、Java、TypeScript、JavaScript和Python中實現MCP。你還會學習如何調試和測試MCP服務器、管理API，以及使用Azure將解決方案部署到雲端。這些實際資源旨在加速你的學習，幫助你自信地構建健全的、可投入生產的MCP應用程序。

## 概述

本課程重點關注MCP在多種編程語言中的實際應用。我們將探討如何使用C#、Java、TypeScript、JavaScript和Python中的MCP SDK來構建健全的應用程序，調試和測試MCP服務器，以及創建可重用的資源、提示和工具。

## 學習目標

完成本課程後，你將能夠：
- 使用官方SDK在各種編程語言中實現MCP解決方案
- 系統地調試和測試MCP服務器
- 創建和使用服務器功能（資源、提示和工具）
- 設計有效的MCP工作流程以處理複雜任務
- 優化MCP實現以提高性能和可靠性

## 官方SDK資源

模型上下文協議提供多種語言的官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用MCP SDK

本節提供了在多種編程語言中實現MCP的實際例子。你可以在`samples`目錄中找到按語言組織的樣本代碼。

### 可用樣本

倉庫包括以下語言的樣本實現：

- C#
- Java
- TypeScript
- JavaScript
- Python

每個樣本展示了該特定語言和生態系統中的關鍵MCP概念和實現模式。

## 核心服務器功能

MCP服務器可以實現以下功能的任意組合：

### 資源
資源為用戶或AI模型提供上下文和數據：
- 文檔庫
- 知識庫
- 結構化數據源
- 文件系統

### 提示
提示是為用戶設計的模板消息和工作流程：
- 預定義的對話模板
- 引導式交互模式
- 專門的對話結構

### 工具
工具是供AI模型執行的功能：
- 數據處理工具
- 外部API集成
- 計算能力
- 搜索功能

## 樣本實現：C#

官方C# SDK倉庫包含多個樣本實現，展示了MCP的不同方面：

- **基本MCP客戶端**：展示如何創建MCP客戶端並調用工具的簡單示例
- **基本MCP服務器**：帶有基本工具註冊的最小服務器實現
- **高級MCP服務器**：具有工具註冊、身份驗證和錯誤處理的全功能服務器
- **ASP.NET集成**：展示與ASP.NET Core集成的示例
- **工具實現模式**：展示不同複雜程度工具實現的各種模式

MCP C# SDK目前處於預覽階段，API可能會有所變更。隨著SDK的演進，我們將不斷更新此博客。

### 主要特點
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 構建你的[第一個MCP服務器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

如需完整的C#實現樣本，請訪問[官方C# SDK樣本倉庫](https://github.com/modelcontextprotocol/csharp-sdk)

## 樣本實現：Java實現

Java SDK提供了具有企業級功能的穩健MCP實現選項。

### 主要特點

- Spring框架集成
- 強類型安全
- 支持響應式編程
- 全面的錯誤處理

如需完整的Java實現樣本，請參見樣本目錄中的[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## 樣本實現：JavaScript實現

JavaScript SDK提供了一種輕量且靈活的MCP實現方法。

### 主要特點

- 支持Node.js和瀏覽器
- 基於Promise的API
- 易於與Express和其他框架集成
- 支持WebSocket流

如需完整的JavaScript實現樣本，請參見樣本目錄中的[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## 樣本實現：Python實現

Python SDK提供了一種Python化的MCP實現方法，並與優秀的機器學習框架集成。

### 主要特點

- 使用asyncio支持異步/等待
- Flask和FastAPI集成
- 簡單的工具註冊
- 與流行的機器學習庫原生集成

如需完整的Python實現樣本，請參見樣本目錄中的[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API管理

Azure API管理是如何保護MCP服務器的一個很好的答案。這個想法是將Azure API管理實例放在你的MCP服務器前面，讓它處理你可能需要的功能，比如：

- 限速
- 令牌管理
- 監控
- 負載均衡
- 安全

### Azure樣本

這裡有一個Azure樣本正是這樣做的，即[創建MCP服務器並使用Azure API管理保護它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

請參見下圖中的授權流程是如何發生的：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

在上圖中，發生了以下情況：

- 使用Microsoft Entra進行身份驗證/授權。
- Azure API管理充當網關並使用策略來引導和管理流量。
- Azure Monitor記錄所有請求以供進一步分析。

#### 授權流程

讓我們更詳細地看看授權流程：

![序列圖](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP授權規範

了解更多[MCP授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 部署遠程MCP服務器到Azure

讓我們看看是否可以部署我們之前提到的樣本：

1. 克隆倉庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 註冊`Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`稍後檢查註冊是否完成。

2. 運行這個[azd](https://aka.ms/azd)命令來配置API管理服務、函數應用（含代碼）和所有其他所需的Azure資源

    ```shell
    azd up
    ```

    此命令應該在Azure上部署所有雲資源

### 使用MCP Inspector測試你的服務器

1. 在**新終端窗口**中，安裝並運行MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你應該看到類似以下界面的內容：

    ![連接到Node Inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.hk.png)

1. 按住CTRL點擊以從應用顯示的URL加載MCP Inspector網頁應用（例如：http://127.0.0.1:6274/#resources）
1. 將傳輸類型設置為`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`並**連接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。 點擊一個工具並**運行工具**。  

如果所有步驟都成功，你現在應該已經連接到MCP服務器並能夠調用工具。

## Azure的MCP服務器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：這些倉庫集合是使用Azure Functions構建和部署自定義遠程MCP（模型上下文協議）服務器的快速入門模板，支持Python、C# .NET或Node/TypeScript。

這些樣本提供了一個完整的解決方案，允許開發者：

- 本地構建和運行：在本地機器上開發和調試MCP服務器
- 部署到Azure：通過簡單的azd up命令輕鬆部署到雲端
- 從客戶端連接：從各種客戶端連接到MCP服務器，包括VS Code的Copilot代理模式和MCP Inspector工具

### 主要特點：

- 設計安全：MCP服務器使用密鑰和HTTPS進行安全保護
- 身份驗證選項：支持使用內置身份驗證和/或API管理的OAuth
- 網絡隔離：允許使用Azure虛擬網絡（VNET）進行網絡隔離
- 無服務器架構：利用Azure Functions進行可擴展的事件驅動執行
- 本地開發：全面的本地開發和調試支持
- 簡單部署：流線化的Azure部署過程

倉庫包括所有必要的配置文件、源代碼和基礎設施定義，快速開始生產就緒的MCP服務器實現。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用Python進行MCP實現的Azure Functions樣本

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用C# .NET進行MCP實現的Azure Functions樣本

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用Node/TypeScript進行MCP實現的Azure Functions樣本。

## 關鍵要點

- MCP SDK提供了語言特定的工具以實現健全的MCP解決方案
- 調試和測試過程對於可靠的MCP應用程序至關重要
- 可重用的提示模板使AI交互保持一致
- 設計良好的工作流程可以使用多個工具協同完成複雜任務
- 實施MCP解決方案需要考慮安全性、性能和錯誤處理

## 練習

設計一個實際的MCP工作流程，以解決你領域中的實際問題：

1. 確定3-4個有助於解決此問題的工具
2. 創建一個工作流程圖，展示這些工具如何交互
3. 使用你喜歡的語言實現其中一個工具的基本版本
4. 創建一個提示模板，幫助模型有效地使用你的工具

## 其他資源

---

下一步：[高級主題](../05-AdvancedTopics/README.md)

**免責聲明**：  
此文件是使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯的。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原文檔的本地語言版本應被視為權威來源。對於關鍵信息，建議使用專業的人力翻譯。我們對因使用此翻譯而引起的任何誤解或誤釋不承擔責任。