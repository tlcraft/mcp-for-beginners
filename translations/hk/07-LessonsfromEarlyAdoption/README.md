<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T16:06:55+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hk"
}
-->
# 早期採用者的經驗教訓

## 概覽

本課程探討早期採用者如何利用 Model Context Protocol (MCP) 解決現實世界的挑戰，並推動各行業的創新。透過詳盡的案例研究和實作項目，你將了解 MCP 如何實現標準化、安全且具擴展性的 AI 整合——將大型語言模型、工具和企業數據統一於一個框架內。你將獲得設計和建構基於 MCP 解決方案的實務經驗，學習經過驗證的實作模式，並發掘在生產環境中部署 MCP 的最佳實踐。本課程亦會介紹新興趨勢、未來發展方向及開源資源，助你掌握 MCP 技術及其不斷演進的生態系統。

## 學習目標

- 分析不同行業中 MCP 的實際應用
- 設計並構建完整的 MCP 應用程式
- 探索 MCP 技術的新興趨勢與未來方向
- 在實際開發場景中應用最佳實踐

## MCP 實際應用案例

### 案例研究 1：企業客戶支援自動化

一家跨國企業實施了基於 MCP 的解決方案，統一其客戶支援系統中的 AI 互動，實現了：

- 為多個 LLM 供應商建立統一介面
- 在各部門間維持一致的提示管理
- 實施嚴謹的安全與合規控管
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

**成果：** 模型成本降低 30%，回應一致性提升 45%，並加強全球營運的合規性。

### 案例研究 2：醫療診斷助理

一家醫療機構建立 MCP 基礎設施，整合多個專業醫療 AI 模型，同時確保敏感病人資料安全：

- 無縫切換通用與專科醫療模型
- 嚴格的隱私控管與審計追蹤
- 與現有電子健康紀錄（EHR）系統整合
- 對醫療術語維持一致的提示設計

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

**成果：** 改善醫師診斷建議，完全符合 HIPAA 規範，並大幅減少系統間切換上下文的負擔。

### 案例研究 3：金融服務風險分析

一家金融機構運用 MCP 統一其風險分析流程，涵蓋不同部門：

- 為信用風險、詐騙偵測及投資風險模型建立統一介面
- 實施嚴格存取控制與模型版本管理
- 確保所有 AI 建議可審計
- 跨多系統維持一致的資料格式

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

**成果：** 強化法規遵循，模型部署速度提升 40%，部門間風險評估一致性改善。

### 案例研究 4：Microsoft Playwright MCP 伺服器用於瀏覽器自動化

Microsoft 開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，透過 Model Context Protocol 實現安全且標準化的瀏覽器自動化。此方案讓 AI 代理與 LLM 能以受控、可審計且可擴充的方式與瀏覽器互動，應用於自動化網頁測試、資料擷取及端對端工作流程。

- 將瀏覽器自動化功能（導航、填表、截圖等）作為 MCP 工具公開
- 實施嚴格存取控制與沙盒機制，防止未授權操作
- 提供詳細的瀏覽器互動審計日誌
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
- 為 AI 代理及 LLM 啟用安全且程式化的瀏覽器自動化  
- 降低人工測試工作量，提升網頁應用測試覆蓋率  
- 提供可重用且可擴充的企業級瀏覽器工具整合框架

**參考資料：**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是 Microsoft 提供的企業級托管 MCP 實作，旨在作為雲端服務提供可擴展、安全且合規的 MCP 伺服器功能。Azure MCP 讓組織能快速部署、管理並整合 MCP 伺服器與 Azure AI、數據及安全服務，減少營運負擔，加速 AI 採用。

- 完整托管 MCP 伺服器，內建擴展、監控與安全機制
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務
- 透過 Microsoft Entra ID 提供企業級身份驗證與授權
- 支援自訂工具、提示範本及資源連接器
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
- 提供即用型、合規的 MCP 伺服器平台，縮短企業 AI 專案的價值實現時間  
- 簡化 LLM、工具與企業資料源整合  
- 強化 MCP 工作負載的安全性、可觀察性及營運效率

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## 案例研究 6：NLWeb

MCP（Model Context Protocol）是一個新興協議，讓聊天機器人和 AI 助手能與工具互動。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 ask，用自然語言向網站提問。回傳的回應利用 schema.org，一套廣泛使用的網頁資料描述詞彙。簡單來說，MCP 對 NLWeb 就像 Http 對 HTML。NLWeb 結合協議、Schema.org 格式及範例程式碼，幫助網站快速建立這類端點，讓人類可透過對話介面互動，機器則可實現自然的代理間溝通。

NLWeb 包含兩個主要組件：  
- 一個簡單協議，用自然語言與網站介面互動，並利用 json 與 schema.org 格式回應。詳細請參閱 REST API 文件。  
- (1) 的簡易實作，利用現有標記，適用於可抽象為項目清單（產品、食譜、景點、評論等）的網站。配合一組使用者介面元件，網站能輕鬆提供內容的對話介面。更多細節見 Life of a chat query 文件。

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Foundry MCP – 整合 Azure AI 代理

Azure AI Foundry MCP 伺服器展示如何利用 MCP 來協調及管理企業環境中的 AI 代理與工作流程。透過與 Azure AI Foundry 整合，組織能標準化代理互動，利用 Foundry 的工作流程管理，確保安全且具擴展性的部署。此方案支援快速原型開發、穩健監控及與 Azure AI 服務的無縫整合，適用於知識管理及代理評估等進階場景。開發者可透過統一介面建構、部署與監控代理管線，IT 團隊則獲得更佳的安全性、合規性及營運效率。此方案適合企業加速 AI 採用，並掌控複雜的代理驅動流程。

**參考資料：**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型開發

Foundry MCP Playground 提供一個即用型環境，供開發者試驗 MCP 伺服器及 Azure AI Foundry 整合。開發者可快速進行原型設計、測試及評估 AI 模型與代理工作流程，利用 Azure AI Foundry Catalog 與 Labs 的資源。此 Playground 簡化設定，提供範例專案，支援協作開發，便於探索最佳實踐及新場景，降低基礎設施門檻。特別適合團隊驗證想法、分享實驗並加速學習，促進 MCP 與 Azure AI Foundry 生態系的創新與社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## 實作專案

### 專案 1：建置多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**  
- 支援至少三個不同模型供應商（如 OpenAI、Anthropic、本地模型）  
- 實作基於請求元資料的路由機制  
- 建立供應商憑證管理的設定系統  
- 加入快取機制以優化效能與成本  
- 建置簡易儀表板監控使用情況

**實作步驟：**  
1. 建立基本 MCP 伺服器基礎架構  
2. 為每個 AI 模型服務實作供應商適配器  
3. 建立基於請求屬性的路由邏輯  
4. 加入常用請求的快取機制  
5. 開發監控儀表板  
6. 使用多種請求模式測試

**技術選擇：** 可選 Python（.NET/Java/Python 擇一），Redis 作為快取，及簡易網頁框架建構儀表板。

### 專案 2：企業提示管理系統

**目標：** 開發基於 MCP 的系統，管理、版本控管及部署組織內的提示範本。

**需求：**  
- 建立集中式提示範本庫  
- 實作版本控管與審核工作流程  
- 建置範本測試功能，含範例輸入  
- 發展角色基礎存取控制  
- 提供範本檢索與部署的 API

**實作步驟：**  
1. 設計範本儲存的資料庫架構  
2. 建立範本 CRUD 核心 API  
3. 實作版本控管系統  
4. 建置審核工作流程  
5. 開發測試框架  
6. 建立簡易管理網頁介面  
7. 與 MCP 伺服器整合

**技術選擇：** 自行選擇後端框架、SQL 或 NoSQL 資料庫，以及前端框架。

### 專案 3：基於 MCP 的內容生成平台

**目標：** 建立一個利用 MCP 提供不同內容類型一致結果的內容生成平台。

**需求：**  
- 支援多種內容格式（部落格文章、社群媒體、行銷文案）  
- 實作基於範本的生成，含自訂選項  
- 建立內容審核與反饋系統  
- 追蹤內容效能指標  
- 支援內容版本控管與迭代

**實作步驟：**  
1. 建立 MCP 客戶端基礎架構  
2. 建立不同內容類型的範本  
3. 建構內容生成管線  
4. 實作審核系統  
5. 開發指標追蹤系統  
6. 建立範本管理與內容生成的使用者介面

**技術選擇：** 自選程式語言、網頁框架及資料庫系統。

## MCP 技術未來方向

### 新興趨勢

1. **多模態 MCP**  
   - 擴展 MCP，標準化影像、音訊及影片模型互動  
   - 發展跨模態推理能力  
   - 制定不同模態的標準提示格式

2. **聯邦 MCP 基礎設施**  
   - 分散式 MCP 網絡，促進跨組織資源共享  
   - 安全模型共享的標準協議  
   - 隱私保護計算技術

3. **MCP 市場平台**  
   - MCP 範本與插件的分享與變現生態系  
   - 品質保證與認證流程  
   - 與模型市場整合

4. **MCP 在邊緣運算的應用**  
   - 適用於資源受限邊緣裝置的 MCP 標準  
   - 低頻寬環境優化協議  
   - IoT 生態系專用 MCP 實作

5. **法規框架**  
   - 為法規遵循開發 MCP 擴充功能  
   - 標準化審計追蹤與可解釋性介面  
   - 與新興 AI 治理框架整合

### Microsoft 的 MCP 解決方案

Microsoft 與 Azure 推出多個開源資源庫，協助開發者在各種場景實作 MCP：

#### Microsoft 組織  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化與測試的 Playwright MCP 伺服器  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 伺服器實作，適合本地測試與社群貢獻  
3. [NLWeb](https://github.com/microsoft/NlWeb) - 一系列開放協議及開源工具，主要聚焦於 AI 網頁基礎層

#### Azure-Samples 組織  
1. [mcp](https://github.com/Azure-Samples/mcp) - 多語言 Azure MCP 伺服器建置與整合範例、工具與資源  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - MCP 認證伺服器參考實作  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 上的遠端 MCP 伺服器實作彙整  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python 快速起步範本  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# 快速起步範本  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript 快速起步範本  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 使用 Python 的 Azure API 管理作為 AI 閘道  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI 實驗，包括 MCP 能力，整合 Azure OpenAI 與 AI Foundry

這些資源庫涵蓋從基礎伺服器實作到認證、雲端部署與企業整合等多種用例，支持多種程式語言與 Azure 服務。

#### MCP 資源目錄

官方 Microsoft MCP 資源庫中的 [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) 提供精選範例資源、提示範本及工具定義，協助開發者快速上手 MCP，並提供可重用元件與最佳實踐範例，包括：

- **提示範本：** 通用 AI 任務與場景的現成範本，可調整用於自家 MCP 伺服器  
- **工具定義：** 範例工具結構與元資料，標準化不同 MCP 伺服器間的工具整合與調用  
- **資源範例：** 連接資料源、API 及外部服務的範例定義
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## 練習

1. 分析其中一個案例研究，並提出另一種實現方案。
2. 選擇一個專案構想，撰寫詳細的技術規格說明。
3. 研究一個案例中未涵蓋的行業，並概述 MCP 如何解決該行業的特定挑戰。
4. 探索其中一個未來發展方向，設計一個新的 MCP 擴充功能概念來支援它。

下一步: [Best Practices](../08-BestPractices/README.md)

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件的母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用此翻譯而引起的任何誤解或誤釋承擔責任。