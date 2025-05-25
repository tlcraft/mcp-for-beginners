<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:44:44+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tw"
}
-->
# 實際應用

實際應用是讓模型上下文協議（MCP）的強大功能變得具體可見的地方。雖然理解MCP背後的理論和架構很重要，但真正的價值在於你應用這些概念來構建、測試和部署解決方案以解決現實世界的問題。本章節將概念知識與實際開發橋接起來，引導你完成將基於MCP的應用程序實現的過程。

無論你是在開發智能助手、將AI整合到商業工作流程中，還是構建自定義工具進行數據處理，MCP都提供了一個靈活的基礎。其語言無關的設計和針對流行編程語言的官方SDK使得它對廣泛的開發者都可及。利用這些SDK，你可以快速原型、迭代和擴展你的解決方案到不同的平台和環境。

在接下來的章節中，你將找到實際的例子、示例代碼和部署策略，展示如何在C#、Java、TypeScript、JavaScript和Python中實現MCP。你還將學習如何調試和測試你的MCP伺服器、管理API，以及使用Azure將解決方案部署到雲端。這些實際的資源旨在加速你的學習，幫助你自信地構建強大、可投入生產的MCP應用程序。

## 概述

本課程著重於多種編程語言中MCP實現的實際方面。我們將探索如何使用C#、Java、TypeScript、JavaScript和Python中的MCP SDK來構建強大的應用程序，調試和測試MCP伺服器，並創建可重用的資源、提示和工具。

## 學習目標

在本課程結束時，你將能夠：
- 使用各種編程語言的官方SDK實現MCP解決方案
- 系統地調試和測試MCP伺服器
- 創建和使用伺服器功能（資源、提示和工具）
- 為複雜任務設計有效的MCP工作流程
- 優化MCP實現以提高性能和可靠性

## 官方SDK資源

模型上下文協議提供多種語言的官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用MCP SDK

本節提供了在多種編程語言中實現MCP的實際例子。你可以在`samples`目錄中找到按語言組織的示例代碼。

### 可用示例

倉庫包括以下語言的示例實現：

- C#
- Java
- TypeScript
- JavaScript
- Python

每個示例展示了該特定語言和生態系統的關鍵MCP概念和實現模式。

## 核心伺服器功能

MCP伺服器可以實現以下任意組合的功能：

### 資源
資源提供用戶或AI模型使用的上下文和數據：
- 文件庫
- 知識庫
- 結構化數據源
- 文件系統

### 提示
提示是用戶的模板消息和工作流程：
- 預定義的對話模板
- 引導式交互模式
- 專門化的對話結構

### 工具
工具是AI模型執行的功能：
- 數據處理工具
- 外部API集成
- 計算能力
- 搜索功能

## 示例實現：C#

官方C# SDK倉庫包含幾個示例實現，展示了MCP的不同方面：

- **基本MCP客戶端**：簡單示例展示如何創建MCP客戶端並調用工具
- **基本MCP伺服器**：具有基本工具註冊的最小伺服器實現
- **高級MCP伺服器**：功能齊全的伺服器，具有工具註冊、身份驗證和錯誤處理
- **ASP.NET集成**：展示與ASP.NET Core集成的示例
- **工具實現模式**：實現不同複雜程度工具的各種模式

MCP C# SDK處於預覽階段，API可能會改變。我們將隨著SDK的演變不斷更新此博客。

### 主要功能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 構建你的[第一個MCP伺服器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)。

欲獲取完整的C#實現示例，請訪問[官方C# SDK示例倉庫](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例實現：Java實現

Java SDK提供了具有企業級功能的強大MCP實現選項。

### 主要功能

- Spring框架集成
- 強類型安全性
- 支持反應式編程
- 全面的錯誤處理

欲獲取完整的Java實現示例，請查看samples目錄中的[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## 示例實現：JavaScript實現

JavaScript SDK提供了一種輕量且靈活的MCP實現方法。

### 主要功能

- 支持Node.js和瀏覽器
- 基於Promise的API
- 與Express和其他框架輕鬆集成
- 支持WebSocket流

欲獲取完整的JavaScript實現示例，請查看samples目錄中的[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## 示例實現：Python實現

Python SDK提供了一種符合Python風格的MCP實現，並與出色的ML框架集成。

### 主要功能

- 使用asyncio支持Async/await
- 與Flask和FastAPI集成
- 簡單的工具註冊
- 與流行的ML庫的原生集成

欲獲取完整的Python實現示例，請查看samples目錄中的[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API管理

Azure API管理是如何保障MCP伺服器安全的絕佳答案。其理念是將Azure API管理實例放在你的MCP伺服器前面，並讓它處理你可能想要的功能，例如：

- 限速
- 令牌管理
- 監控
- 負載平衡
- 安全性

### Azure示例

這裡有一個Azure示例正是這樣做的，即[創建MCP伺服器並使用Azure API管理保障其安全](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

查看下圖中的授權流程是如何進行的：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

在前面的圖像中，發生了以下情況：

- 使用Microsoft Entra進行身份驗證/授權。
- Azure API管理充當網關並使用策略來指導和管理流量。
- Azure Monitor記錄所有請求以供進一步分析。

#### 授權流程

讓我們更詳細地看一下授權流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP授權規範

了解更多[MCP授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 部署遠程MCP伺服器到Azure

讓我們看看是否可以部署我們之前提到的示例：

1. 克隆倉庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 註冊`Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`經過一段時間後檢查註冊是否完成。

2. 運行此[azd](https://aka.ms/azd)命令來提供api管理服務、函數應用（含代碼）和所有其他所需的Azure資源

    ```shell
    azd up
    ```

    此命令應在Azure上部署所有雲資源

### 使用MCP Inspector測試你的伺服器

1. 在**新終端窗口**中，安裝並運行MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你應該看到類似於以下的界面：

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.tw.png)

1. CTRL點擊從應用程序顯示的URL（例如http://127.0.0.1:6274/#resources）加載MCP Inspector web應用程序
1. 將傳輸類型設置為`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`並**連接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。點擊一個工具並**運行工具**。

如果所有步驟都成功，你現在應該已連接到MCP伺服器並且能夠調用工具。

## Azure的MCP伺服器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：這組倉庫是使用Python、C# .NET或Node/TypeScript的Azure Functions構建和部署自定義遠程MCP（模型上下文協議）伺服器的快速入門模板。

這些示例提供了一個完整的解決方案，允許開發者：

- 本地構建和運行：在本地機器上開發和調試MCP伺服器
- 部署到Azure：通過簡單的azd up命令輕鬆部署到雲端
- 從客戶端連接：從各種客戶端連接到MCP伺服器，包括VS Code的Copilot代理模式和MCP Inspector工具

### 主要功能：

- 設計安全性：MCP伺服器使用密鑰和HTTPS進行安全保護
- 身份驗證選項：支持使用內置身份驗證和/或API管理的OAuth
- 網絡隔離：允許使用Azure虛擬網絡（VNET）進行網絡隔離
- 無伺服器架構：利用Azure Functions進行可擴展的事件驅動執行
- 本地開發：全面的本地開發和調試支持
- 簡單部署：簡化的部署過程到Azure

倉庫包括所有必要的配置文件、源代碼和基礎設施定義，以便快速開始使用可投入生產的MCP伺服器實現。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用Azure Functions和Python的MCP示例實現

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用Azure Functions和C# .NET的MCP示例實現

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用Azure Functions和Node/TypeScript的MCP示例實現。

## 關鍵要點

- MCP SDK提供了語言特定的工具來實現強大的MCP解決方案
- 調試和測試過程對於可靠的MCP應用程序至關重要
- 可重用的提示模板可實現一致的AI交互
- 設計良好的工作流程可以使用多個工具編排複雜任務
- 實現MCP解決方案需要考慮安全性、性能和錯誤處理

## 練習

設計一個實際的MCP工作流程來解決你領域中的現實問題：

1. 確定3-4個對解決此問題有用的工具
2. 創建一個工作流程圖，展示這些工具如何互動
3. 使用你喜歡的語言實現其中一個工具的基本版本
4. 創建一個提示模板，以幫助模型有效地使用你的工具

## 其他資源

---

下一步：[高級主題](../05-AdvancedTopics/README.md)

**免責聲明**：
本文檔使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。雖然我們努力確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應將原始語言的文檔視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們不對使用此翻譯引起的任何誤解或誤釋承擔責任。