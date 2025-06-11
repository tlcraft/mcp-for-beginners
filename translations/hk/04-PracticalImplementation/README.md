<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:02:27+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hk"
}
-->
# Practical Implementation

實際應用係Model Context Protocol (MCP)威力真正展現嘅地方。雖然理解MCP背後嘅理論同架構好重要，但真正嘅價值係當你將呢啲概念應用喺建構、測試同部署解決方案，解決真實世界嘅問題。呢章會幫你由概念知識過渡到實戰開發，帶你一步步實現基於MCP嘅應用。

無論你係開發智能助理、將AI整合入業務工作流程，定係建立自訂嘅數據處理工具，MCP都提供咗一個靈活嘅基礎。佢嘅語言無關設計同官方SDK支援多種流行編程語言，令唔同開發者都易於使用。利用呢啲SDK，你可以快速原型設計、反覆優化，並喺唔同平台同環境中擴展你嘅解決方案。

以下章節會提供實用例子、示範代碼同部署策略，展示點樣喺C#、Java、TypeScript、JavaScript同Python中實現MCP。你亦會學到點樣調試同測試MCP服務器、管理API，以及用Azure部署解決方案。呢啲實戰資源旨在加快你嘅學習，幫你有信心打造穩健、可投入生產嘅MCP應用。

## Overview

本課程集中講解多種編程語言中MCP實踐嘅實際應用。我哋會探討點樣用C#、Java、TypeScript、JavaScript同Python嘅MCP SDK建構穩健應用、調試同測試MCP服務器，並創建可重用嘅資源、提示同工具。

## Learning Objectives

完成本課後，你將能夠：
- 用官方SDK喺多種編程語言中實現MCP解決方案
- 系統性調試同測試MCP服務器
- 創建同使用服務器功能（資源、提示同工具）
- 設計高效嘅MCP工作流程應對複雜任務
- 優化MCP實現嘅性能同可靠性

## Official SDK Resources

Model Context Protocol提供多種語言嘅官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

本節提供多語言中實現MCP嘅實用例子。你可以喺`samples`目錄中按語言找到示範代碼。

### Available Samples

倉庫中包含以下語言嘅示範實現：

- C#
- Java
- TypeScript
- JavaScript
- Python

每個示範都展示咗該語言生態系統中MCP嘅核心概念同實現模式。

## Core Server Features

MCP服務器可以實現以下功能嘅任意組合：

### Resources
資源為用戶或AI模型提供上下文同數據：
- 文件庫
- 知識庫
- 結構化數據源
- 文件系統

### Prompts
提示係為用戶設計嘅模板消息同工作流程：
- 預設對話模板
- 引導式交互模式
- 專門嘅對話結構

### Tools
工具係AI模型可執行嘅功能：
- 數據處理工具
- 外部API整合
- 計算能力
- 搜索功能

## Sample Implementations: C#

官方C# SDK倉庫包含多個示範，展示MCP唔同方面嘅實現：

- **Basic MCP Client**：簡單示範點樣建立MCP客戶端同調用工具
- **Basic MCP Server**：基本服務器實現，包含簡單工具註冊
- **Advanced MCP Server**：功能齊全嘅服務器，包含工具註冊、身份驗證同錯誤處理
- **ASP.NET Integration**：展示同ASP.NET Core整合嘅例子
- **Tool Implementation Patterns**：多種工具實現模式，涵蓋唔同複雜度

MCP C# SDK現時仍處於預覽階段，API可能會變動。我哋會持續更新呢個博客，緊貼SDK發展。

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 建立你嘅 [第一個 MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)。

想睇完整嘅C#實現示範，可以訪問[官方C# SDK示範倉庫](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK提供強大嘅MCP實現方案，具備企業級功能。

### Key Features

- Spring Framework整合
- 強類型安全
- 反應式編程支持
- 全面嘅錯誤處理

完整Java實現示範請參考samples目錄中嘅[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## Sample implementation: JavaScript Implementation

JavaScript SDK提供輕量靈活嘅MCP實現方法。

### Key Features

- 支援Node.js同瀏覽器
- 基於Promise嘅API
- 易於同Express等框架整合
- 支援WebSocket串流

完整JavaScript示範請參考samples目錄中嘅[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## Sample implementation: Python Implementation

Python SDK採用Pythonic方式實現MCP，並與多個機器學習框架深度整合。

### Key Features

- 支援async/await同asyncio
- Flask同FastAPI整合
- 簡易工具註冊
- 原生支援流行機器學習庫

完整Python示範請參考samples目錄中嘅[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API management 

Azure API Management係保障MCP服務器安全嘅好方法。思路係喺MCP服務器前面放置一個Azure API Management實例，幫你管理以下功能：

- 限流
- 令牌管理
- 監控
- 負載均衡
- 安全性

### Azure Sample

以下係一個Azure示範，即[建立MCP服務器並用Azure API Management保障](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

睇下下面圖片中授權流程點運作：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

圖片中發生嘅事：

- 用Microsoft Entra做身份驗證/授權。
- Azure API Management充當閘道，利用策略引導同管理流量。
- Azure Monitor記錄所有請求以便進一步分析。

#### Authorization flow

詳細睇下授權流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

了解更多關於[MCP授權規範](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server to Azure

而家試下部署之前提過嘅示範：

1. 克隆倉庫

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 註冊 `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`，過陣再檢查註冊完成未。

2. 執行呢個[azd](https://aka.ms/azd)命令，部署API管理服務、function app（連代碼）同其他Azure資源

    ```shell
    azd up
    ```

    呢個命令會喺Azure部署所有雲端資源。

### Testing your server with MCP Inspector

1. 喺**新嘅終端視窗**安裝同運行MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你會見到類似嘅介面：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png) 

1. 按住CTRL點擊，從應用顯示嘅URL載入MCP Inspector網頁（例如：http://127.0.0.1:6274/#resources）
1. 設定傳輸類型為 `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`，然後**連接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。點擊一個工具，然後**執行工具**。

如果所有步驟都成功，你而家已經連接到MCP服務器，並成功調用咗工具。

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：呢組倉庫係快速入門模板，用Azure Functions同Python、C# .NET或Node/TypeScript打造同部署自訂遠端MCP（Model Context Protocol）服務器。

示範提供完整方案，幫助開發者：

- 本地構建同運行：喺本地機器開發同調試MCP服務器
- 部署到Azure：用簡單嘅azd up命令輕鬆部署到雲端
- 從客戶端連接：支援包括VS Code嘅Copilot代理模式同MCP Inspector工具等多種客戶端連接

### Key Features:

- 安全設計：MCP服務器用密鑰同HTTPS保障安全
- 認證選項：支援內置身份驗證同/或API管理嘅OAuth
- 網絡隔離：支持用Azure虛擬網絡（VNET）實現網絡隔離
- 無服務器架構：利用Azure Functions實現可擴展、事件驅動執行
- 本地開發：提供全面嘅本地開發同調試支持
- 簡單部署：簡化嘅Azure部署流程

倉庫包含所有必要配置文件、源代碼同基礎設施定義，幫你快速開始生產就緒嘅MCP服務器實現。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 用Azure Functions同Python實現嘅MCP示範

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 用Azure Functions同C# .NET實現嘅MCP示範

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 用Azure Functions同Node/TypeScript實現嘅MCP示範。

## Key Takeaways

- MCP SDK提供針對不同語言嘅工具，方便實現穩健嘅MCP解決方案
- 調試同測試過程對可靠嘅MCP應用至關重要
- 可重用嘅提示模板令AI交互更一致
- 精心設計嘅工作流程能用多種工具協調複雜任務
- 實現MCP方案時需考慮安全性、性能同錯誤處理

## Exercise

設計一個實用嘅MCP工作流程，解決你領域嘅真實問題：

1. 識別3-4個對解決問題有用嘅工具
2. 畫出呢啲工具點互相配合嘅工作流程圖
3. 用你慣用嘅語言實現其中一個工具嘅基本版本
4. 創建一個提示模板，幫助模型有效使用你嘅工具

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋盡力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用本翻譯而引起嘅任何誤解或誤釋概不負責。