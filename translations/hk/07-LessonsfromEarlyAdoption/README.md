<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T16:53:36+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hk"
}
-->
# 早期採用者的經驗教訓

## 概覽

本課程探討早期採用者如何利用 Model Context Protocol (MCP) 解決實際問題，推動各行業的創新。透過詳細的案例研究和實作項目，你將了解 MCP 如何實現標準化、安全且具擴展性的 AI 整合，將大型語言模型、工具和企業數據統一連接於一個框架內。你會獲得設計及構建基於 MCP 解決方案的實務經驗，學習經驗豐富的實作模式，並掌握在生產環境中部署 MCP 的最佳實踐。課程亦會介紹新興趨勢、未來發展方向及開源資源，助你緊貼 MCP 技術及其生態系的最新動態。

## 學習目標

- 分析不同行業中 MCP 的實際應用
- 設計及構建完整的 MCP 應用程式
- 探索 MCP 技術的新興趨勢與未來方向
- 在實際開發場景中應用最佳實踐

## MCP 實際應用案例

### 案例研究 1：企業客戶支援自動化

一家跨國企業實施了基於 MCP 的方案，以標準化其客戶支援系統中的 AI 互動。這讓他們能夠：

- 建立多個 LLM 供應商的統一介面
- 跨部門維持一致的提示管理
- 實施嚴謹的安全及合規控管
- 根據需求輕鬆切換不同 AI 模型

**技術實作：**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**成果：** 模型成本降低 30%，回應一致性提升 45%，並強化全球營運的合規性。

### 案例研究 2：醫療診斷助理

一家醫療機構建立 MCP 架構，整合多個專科醫療 AI 模型，同時確保病患敏感資料受到保護：

- 在通用與專科醫療模型間無縫切換
- 嚴格的隱私控管與稽核追蹤
- 與現有電子健康紀錄 (EHR) 系統整合
- 醫療術語提示工程一致性

**技術實作：**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**成果：** 改善醫師診斷建議，同時完全符合 HIPAA 規範，並顯著減少系統間切換上下文的時間。

### 案例研究 3：金融服務風險分析

一家金融機構利用 MCP 標準化不同部門的風險分析流程：

- 建立信用風險、詐欺偵測及投資風險模型的統一介面
- 實施嚴格的存取控管及模型版本管理
- 確保所有 AI 建議的可稽核性
- 維持跨系統一致的資料格式

**技術實作：**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**成果：** 強化法規遵循，模型部署速度提升 40%，並提升部門間風險評估的一致性。

### 案例研究 4：Microsoft Playwright MCP Server 用於瀏覽器自動化

Microsoft 開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，利用 Model Context Protocol 實現安全且標準化的瀏覽器自動化。此方案允許 AI 代理與 LLM 在受控、可稽核且可擴充的環境中與瀏覽器互動，支援自動化網頁測試、資料擷取及端對端工作流程。

- 將瀏覽器自動化功能（導航、填表、截圖等）作為 MCP 工具提供
- 實施嚴格的存取控管及沙盒機制，防止未授權行為
- 提供詳細的瀏覽器互動稽核日誌
- 支援與 Azure OpenAI 及其他 LLM 供應商整合，實現代理驅動自動化

**技術實作：**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**成果：**  
- 為 AI 代理和 LLM 啟用安全、程式化的瀏覽器自動化  
- 降低手動測試工作量，提升網頁應用測試覆蓋率  
- 提供企業環境中可重用且可擴充的瀏覽器工具整合框架

**參考資料：**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是 Microsoft 管理的企業級 Model Context Protocol 實作，旨在提供可擴展、安全且合規的 MCP 伺服器雲端服務。Azure MCP 讓組織能快速部署、管理及整合 MCP 伺服器與 Azure AI、資料及安全服務，降低營運負擔，加速 AI 採用。

- 完全管理的 MCP 伺服器託管，內建擴展、監控與安全功能
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務
- 透過 Microsoft Entra ID 實現企業級認證與授權
- 支援自訂工具、提示模板及資源連接器
- 符合企業安全及法規要求

**技術實作：**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**成果：**  
- 提供即用、合規的 MCP 伺服器平台，縮短企業 AI 專案的價值實現時間  
- 簡化 LLM、工具及企業資料源整合  
- 強化 MCP 工作負載的安全性、可觀察性與營運效率

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## 案例研究 6：NLWeb  
MCP（Model Context Protocol）是用於聊天機器人及 AI 助理與工具互動的新興協議。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 ask，用以用自然語言向網站提問。回傳的回應利用 schema.org，這是一套廣泛使用的網頁資料描述詞彙。簡單來說，MCP 對應於 NLWeb，就像 Http 對應於 HTML。NLWeb 結合協議、Schema.org 格式及範例程式碼，幫助網站快速建立這些端點，既造福使用者的對話介面，也促進機器間的自然代理互動。

NLWeb 有兩個主要組件：  
- 一個非常簡單的協議，用自然語言與網站介面互動，回應格式採用 json 與 schema.org。詳情請參考 REST API 文件。  
- 一個簡易實作，利用現有標記語言，適用於可抽象為項目列表（產品、食譜、景點、評論等）的網站。結合一套使用者介面元件，網站能輕鬆提供對話式內容介面。詳情請參考「Life of a chat query」文件。

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Foundry MCP – 整合 Azure AI 代理

Azure AI Foundry MCP 伺服器示範如何使用 MCP 來協調及管理企業環境中的 AI 代理與工作流程。透過將 MCP 與 Azure AI Foundry 整合，組織能標準化代理互動，利用 Foundry 的工作流程管理，確保安全且具擴展性的部署。此方案支援快速原型開發、完善監控及與 Azure AI 服務的無縫整合，適用於知識管理與代理評估等進階場景。開發者可使用統一介面構建、部署及監控代理管線，IT 團隊則獲得提升的安全性、合規性及營運效率。此方案非常適合希望加速 AI 採用並掌控複雜代理流程的企業。

**參考資料：**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型開發

Foundry MCP Playground 提供一個即用環境，方便實驗 MCP 伺服器與 Azure AI Foundry 整合。開發者可快速原型、測試及評估 AI 模型與代理工作流程，使用 Azure AI Foundry 目錄及實驗室資源。Playground 簡化設定，提供範例專案，支援協作開發，讓團隊能輕鬆探索最佳實踐及新場景，且負擔輕微。降低進入門檻，有助推動 MCP 與 Azure AI Foundry 生態系的創新及社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 案例研究 9：Microsoft Docs MCP Server – 學習與技能提升  
Microsoft Docs MCP Server 實作了 Model Context Protocol (MCP) 伺服器，為 AI 助理提供即時存取官方 Microsoft 文件的能力，並針對官方技術文件執行語意搜尋。

**參考資料：**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## 實作項目

### 項目 1：建立多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，能根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**  
- 支援至少三個不同模型供應商（如 OpenAI、Anthropic、本地模型）  
- 實作基於請求元資料的路由機制  
- 建立管理供應商憑證的配置系統  
- 加入快取以優化效能與成本  
- 建立簡易儀表板以監控使用情況

**實作步驟：**  
1. 建立基本 MCP 伺服器架構  
2. 為每個 AI 模型服務實作供應商適配器  
3. 根據請求屬性實作路由邏輯  
4. 新增常用請求的快取機制  
5. 開發監控儀表板  
6. 以多種請求模式進行測試

**技術選擇：** Python (.NET/Java/Python 擇一)、Redis 快取及簡易 Web 框架作儀表板。

### 項目 2：企業提示管理系統

**目標：** 開發基於 MCP 的系統，用於管理、版本控管及部署組織內的提示模板。

**需求：**  
- 建立集中式提示模板儲存庫  
- 實作版本控管及審核流程  
- 建立模板測試功能，支援範例輸入  
- 開發基於角色的存取控制  
- 建立模板檢索及部署 API

**實作步驟：**  
1. 設計模板存儲的資料庫結構  
2. 建立模板 CRUD 核心 API  
3. 實作版本控管系統  
4. 建立審核工作流程  
5. 開發測試框架  
6. 建立簡易管理 Web 介面  
7. 與 MCP 伺服器整合

**技術選擇：** 後端框架、SQL 或 NoSQL 資料庫及前端框架自選。

### 項目 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 在不同內容類型間提供一致結果。

**需求：**  
- 支援多種內容格式（部落格文章、社群媒體、行銷文案）  
- 實作基於模板的生成，並提供客製化選項  
- 建立內容審核與反饋系統  
- 追蹤內容效能指標  
- 支援內容版本控管與迭代

**實作步驟：**  
1. 建立 MCP 用戶端架構  
2. 建立不同內容類型的模板  
3. 建置內容生成管線  
4. 實作審核系統  
5. 開發效能指標追蹤系統  
6. 建立模板管理及內容生成的用戶介面

**技術選擇：** 自選程式語言、Web 框架及資料庫系統。

## MCP 技術的未來方向

### 新興趨勢

1. **多模態 MCP**  
   - 擴展 MCP 以標準化影像、音訊及影片模型的互動  
   - 發展跨模態推理能力  
   - 制定不同模態的標準提示格式

2. **聯邦 MCP 基礎架構**  
   - 分散式 MCP 網絡，促進組織間資源共享  
   - 制定安全模型共享的標準協議  
   - 隱私保護計算技術

3. **MCP 市場平台**  
   - 建立 MCP 模板及插件的分享與變現生態系  
   - 品質保證及認證流程  
   - 與模型市場整合

4. **邊緣運算的 MCP**  
   - 適配資源有限的邊緣裝置 MCP 標準  
   - 低頻寬環境的協議優化  
   - 專為物聯網生態設計的 MCP 實作

5. **法規架構**  
   - 為法規遵循開發 MCP 擴充功能  
   - 標準化稽核軌跡及解釋介面  
   - 與新興 AI 治理架構整合

### Microsoft 的 MCP 解決方案

Microsoft 與 Azure 推出多個開源資源，協助開發者在不同場景中實作 MCP：

#### Microsoft 組織
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – 用於瀏覽器自動化及測試的 Playwright MCP 伺服器  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP 伺服器實作，適用本地測試及社群貢獻  
3. [NLWeb](https://github.com/microsoft/NlWeb) – 一套開放協議與工具，聚焦建立 AI 網頁的基礎層

#### Azure-Samples 組織
1. [mcp](https://github.com/Azure-Samples/mcp) – Azure 上多語言 MCP 伺服器建置與整合的範例、工具及資源  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – MCP 認證示範伺服器  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Azure Functions 上遠端 MCP 伺服器實作入口  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – 使用 Python 的遠端 MCP 伺服器快速啟動模板  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – 使用 .NET/C# 的遠端 MCP 伺服器快速啟動模板  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – 使用 TypeScript 的遠端 MCP 伺服器快速啟動模板  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – 使用 Python 的 Azure API 管理作為 AI 閘道連接遠端 MCP 伺服器  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM 與 AI 實驗整合，包括 MCP 能力，支援 Azure OpenAI 及 AI Foundry

這些資源涵蓋從基本伺服器實作、認證、雲端部署到企業整合等多種應用場景。

#### MCP 資源目錄

官方 Microsoft MCP 倉庫中的 [MCP Resources 目錄](https://github.com/microsoft/mcp/tree/main/Resources) 提供精選的範例資源、提示模板及工具定義，幫助開發者快速起步 MCP，並提供可重用的組件與最佳實踐範例，包括：

- **提示模板：** 適用於常見 AI 任務的現成模板，可依
- [MCP 社區與文件](https://modelcontextprotocol.io/introduction)
- [Azure MCP 文件](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub 倉庫](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI 與自動化方案](https://azure.microsoft.com/en-us/products/ai-services/)

## 練習

1. 分析其中一個案例研究，並提出另一種實現方法。
2. 選擇一個專案構思，撰寫詳細的技術規格。
3. 研究一個案例中未涵蓋的行業，並概述 MCP 如何解決該行業的特定挑戰。
4. 探索其中一個未來發展方向，並設計一個新的 MCP 擴充概念以支持它。

下一章節: [最佳實踐](../08-BestPractices/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用此翻譯而引起嘅任何誤解或誤釋概不負責。