<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T09:24:05+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tw"
}
-->
# 🌟 早期採用者的經驗教訓

## 🎯 本單元涵蓋內容

本單元探討真實組織和開發者如何利用 Model Context Protocol (MCP) 解決實際問題並推動創新。透過詳細的案例研究與實作專案，您將了解 MCP 如何實現安全、可擴展的 AI 整合，連結語言模型、工具與企業資料。

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是微軟管理的企業級 Model Context Protocol 實作，旨在作為雲端服務提供可擴展、安全且合規的 MCP 伺服器功能。此完整套件包含多個專門針對不同 Azure 服務與場景的 MCP 伺服器。

> **🎯 生產環境可用工具**
> 
> 本案例展示多個生產環境可用的 MCP 伺服器！了解 Azure MCP Server 及其他整合 Azure 的伺服器，請參考我們的 [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#2--azure-mcp-server)。

**主要特色：**
- 完全託管的 MCP 伺服器主機，內建擴展、監控與安全機制
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務
- 透過 Microsoft Entra ID 實現企業級身份驗證與授權
- 支援自訂工具、提示模板與資源連接器
- 符合企業安全與法規要求
- 超過 15 種專用 Azure 服務連接器，包括資料庫、監控與儲存

**Azure MCP Server 功能：**
- **資源管理**：完整 Azure 資源生命週期管理
- **資料庫連接器**：直接存取 Azure Database for PostgreSQL 與 SQL Server
- **Azure Monitor**：基於 KQL 的日誌分析與運營洞察
- **身份驗證**：支援 DefaultAzureCredential 與管理身分識別模式
- **儲存服務**：Blob Storage、Queue Storage 與 Table Storage 操作
- **容器服務**：Azure Container Apps、Container Instances 與 AKS 管理

### 📚 MCP 實際應用展示

想看這些原則如何應用於生產環境工具？請參考我們的 [**10 個改變開發者生產力的 Microsoft MCP 伺服器**](microsoft-mcp-servers.md)，展示您今天就能使用的真實 Microsoft MCP 伺服器。

## 概述

本課程探討早期採用者如何利用 Model Context Protocol (MCP) 解決真實世界的挑戰並推動各行業創新。透過詳細案例研究與實作專案，您將看到 MCP 如何實現標準化、安全且可擴展的 AI 整合——將大型語言模型、工具與企業資料統一連結。您將獲得設計與建置 MCP 解決方案的實務經驗，學習經驗豐富的實作模式，並掌握 MCP 在生產環境部署的最佳實踐。課程同時強調新興趨勢、未來方向與開源資源，助您站在 MCP 技術及其生態系的最前端。

## 學習目標

- 分析不同行業的真實 MCP 實作案例
- 設計並建置完整的 MCP 應用程式
- 探索 MCP 技術的新興趨勢與未來發展
- 在實際開發場景中應用最佳實踐

## 真實世界的 MCP 實作案例

### 案例研究 1：企業客戶支援自動化

一家跨國企業實作 MCP 解決方案，標準化其客戶支援系統中的 AI 互動，達成以下目標：

- 建立多個 LLM 供應商的統一介面
- 跨部門維持一致的提示管理
- 實施強健的安全與合規控管
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

一家醫療機構建立 MCP 基礎架構，整合多個專業醫療 AI 模型，同時確保敏感病患資料安全：

- 無縫切換通用與專科醫療模型
- 嚴格的隱私控管與稽核追蹤
- 與現有電子病歷系統 (EHR) 整合
- 醫療術語的一致提示工程

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

**成果：** 改善醫師診斷建議，完全符合 HIPAA 規範，並大幅減少系統間的上下文切換。

### 案例研究 3：金融服務風險分析

一家金融機構利用 MCP 標準化不同部門的風險分析流程：

- 建立信用風險、詐欺偵測與投資風險模型的統一介面
- 實施嚴格的存取控制與模型版本管理
- 確保所有 AI 建議可稽核
- 維持多元系統間一致的資料格式

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

**成果：** 強化法規遵循，模型部署週期加快 40%，並提升部門間風險評估一致性。

### 案例研究 4：Microsoft Playwright MCP Server 用於瀏覽器自動化

微軟開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，透過 Model Context Protocol 實現安全且標準化的瀏覽器自動化。此生產環境伺服器允許 AI 代理與 LLM 在受控、可稽核且可擴充的環境中與瀏覽器互動，支援自動化網頁測試、資料擷取與端對端工作流程等應用。

> **🎯 生產環境可用工具**
> 
> 本案例展示您今天就能使用的真實 MCP 伺服器！了解 Playwright MCP Server 及其他 9 個生產環境 Microsoft MCP 伺服器，請參考我們的 [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#8--playwright-mcp-server)。

**主要特色：**
- 將瀏覽器自動化功能（導航、表單填寫、截圖等）作為 MCP 工具公開
- 實施嚴格存取控制與沙箱機制，防止未授權操作
- 提供詳細的瀏覽器互動稽核日誌
- 支援與 Azure OpenAI 及其他 LLM 供應商整合，實現代理驅動自動化
- 為 GitHub Copilot 的程式碼代理提供網頁瀏覽能力

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
- 為 AI 代理與 LLM 啟用安全的程式化瀏覽器自動化  
- 降低手動測試工作量，提升網頁應用測試覆蓋率  
- 提供可重用且可擴充的企業級瀏覽器工具整合框架  
- 支援 GitHub Copilot 的網頁瀏覽功能

**參考資料：**  
- [Playwright MCP Server GitHub 倉庫](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI 與自動化解決方案](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP Server ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是微軟管理的企業級 Model Context Protocol 實作，作為雲端服務提供可擴展、安全且合規的 MCP 伺服器功能。Azure MCP 讓組織能快速部署、管理並整合 MCP 伺服器與 Azure AI、資料及安全服務，降低營運負擔並加速 AI 採用。

> **🎯 生產環境可用工具**
> 
> 這是您今天就能使用的真實 MCP 伺服器！了解更多 Azure AI Foundry MCP Server，請參考我們的 [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md)。

- 完全託管的 MCP 伺服器主機，內建擴展、監控與安全機制  
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務  
- 透過 Microsoft Entra ID 實現企業級身份驗證與授權  
- 支援自訂工具、提示模板與資源連接器  
- 符合企業安全與法規要求  

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
- 提供即用且合規的 MCP 伺服器平台，縮短企業 AI 專案的價值實現時間  
- 簡化 LLM、工具與企業資料來源的整合  
- 強化 MCP 工作負載的安全性、可觀察性與營運效率  
- 透過 Azure SDK 最佳實踐與最新身份驗證模式提升程式碼品質

**參考資料：**  
- [Azure MCP 文件](https://aka.ms/azmcp)  
- [Azure MCP Server GitHub 倉庫](https://github.com/Azure/azure-mcp)  
- [Azure AI 服務](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 6：NLWeb – 自然語言網頁介面協定

NLWeb 是微軟對 AI 網路基礎層的願景。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 `ask`，用自然語言向網站提問。回傳的回應採用 schema.org 格式，這是描述網頁資料的廣泛使用詞彙。簡言之，MCP 對 NLWeb 的角色，就像 HTTP 對 HTML。

**主要特色：**
- **協定層**：簡單協定以自然語言介面與網站互動  
- **Schema.org 格式**：利用 JSON 與 schema.org 提供結構化、機器可讀的回應  
- **社群實作**：適用於可抽象為項目清單（產品、食譜、景點、評論等）網站的簡易實作  
- **UI 元件**：預建的對話式介面使用者元件  

**架構組件：**
1. **協定**：針對網站的自然語言查詢簡易 REST API  
2. **實作**：利用現有標記與網站結構自動回應  
3. **UI 元件**：即用型對話介面整合元件  

**優點：**
- 支援人與網站及代理間的互動  
- 提供 AI 系統易於處理的結構化資料回應  
- 快速部署於清單型內容網站  
- 標準化網站 AI 可存取的方式  

**成果：**
- 建立 AI 網路互動標準基礎  
- 簡化內容網站對話介面建置  
- 提升 AI 系統對網頁內容的可發現性與可存取性  
- 促進不同 AI 代理與網路服務間的互通性  

**參考資料：**  
- [NLWeb GitHub 倉庫](https://github.com/microsoft/NlWeb)  
- [NLWeb 文件](https://github.com/microsoft/NlWeb)

### 案例研究 7：Azure AI Foundry MCP Server – 企業 AI 代理整合

Azure AI Foundry MCP 伺服器展示 MCP 如何在企業環境中協調與管理 AI 代理與工作流程。透過整合 MCP 與 Azure AI Foundry，組織能標準化代理互動，利用 Foundry 的工作流程管理，並確保安全且可擴展的部署。

> **🎯 生產環境可用工具**
> 
> 這是您今天就能使用的真實 MCP 伺服器！了解更多 Azure AI Foundry MCP Server，請參考我們的 [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server)。

**主要特色：**
- 全面存取 Azure AI 生態系，包括模型目錄與部署管理  
- 利用 Azure AI Search 進行知識索引，支援 RAG 應用  
- AI 模型效能與品質保證評估工具  
- 整合 Azure AI Foundry Catalog 與 Labs，支援前沿研究模型  
- 代理管理與評估功能，適用於生產場景  

**成果：**
- 快速原型開發與穩健的 AI 代理工作流程監控  
- 與 Azure AI 服務無縫整合，支援進階應用  
- 統一介面建置、部署與監控代理管線  
- 提升企業安全、合規與營運效率  
- 加速 AI 採用，同時掌控複雜代理驅動流程  

**參考資料：**  
- [Azure AI Foundry MCP Server GitHub 倉庫](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI 代理與 MCP 整合（Microsoft Foundry 部落格）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型開發

Foundry MCP Playground 提供即用環境，方便開發者實驗 MCP 伺服器與 Azure AI Foundry 整合。開發者能快速原型、測試與評估 AI 模型及代理工作流程，利用 Azure AI Foundry Catalog 與 Labs 的資源。此 Playground 簡化設定，提供範例專案，支援協作開發，讓您輕鬆探索最佳實踐與新場景，降低基礎建設門檻，促進 MCP 與 Azure AI Foundry 生態系的創新與社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub 倉庫](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 案例研究 9：Microsoft Learn Docs MCP Server – AI 驅動的文件存取

Microsoft Learn Docs MCP Server 是一個雲端託管服務，透過 Model Context Protocol 為 AI 助理提供即時存取官方 Microsoft 文件的能力。此生產環境伺服器連接完整的 Microsoft Learn 生態系，支援跨所有官方 Microsoft 資源的語意搜尋。
> **🎯 生產環境可用工具**
> 
> 這是一個你今天就能使用的真實 MCP 伺服器！想了解更多關於 Microsoft Learn Docs MCP Server 的資訊，請參考我們的 [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server)。
**主要特色：**
- 即時存取官方 Microsoft 文件、Azure 文件及 Microsoft 365 文件
- 具備理解上下文與意圖的進階語意搜尋功能
- 隨著 Microsoft Learn 內容發布，資訊始終保持最新
- 全面涵蓋 Microsoft Learn、Azure 文件及 Microsoft 365 資源
- 回傳最多 10 筆高品質內容片段，附帶文章標題與網址

**重要性說明：**
- 解決 Microsoft 技術「AI 知識過時」的問題
- 確保 AI 助手能取得最新的 .NET、C#、Azure 及 Microsoft 365 功能資訊
- 提供權威且第一方的資訊，確保程式碼生成的準確性
- 對於使用快速演進的 Microsoft 技術的開發者至關重要

**成果：**
- 大幅提升 AI 生成 Microsoft 技術程式碼的準確度
- 減少尋找最新文件與最佳實踐的時間
- 透過具上下文感知的文件檢索，提升開發者生產力
- 無縫整合開發流程，無需離開 IDE

**參考資料：**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## 實作專案

### 專案 1：建置多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，能根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**
- 支援至少三個不同模型供應商（例如 OpenAI、Anthropic、本地模型）
- 根據請求的元資料實作路由機制
- 建立管理供應商憑證的設定系統
- 加入快取以優化效能與成本
- 建置簡易儀表板以監控使用狀況

**實作步驟：**
1. 建立基本的 MCP 伺服器架構
2. 為每個 AI 模型服務實作供應商適配器
3. 根據請求屬性建立路由邏輯
4. 為常見請求加入快取機制
5. 開發監控儀表板
6. 以多種請求模式進行測試

**技術選擇：** 可選擇 Python（或依喜好使用 .NET/Java/Python）、Redis 作為快取，以及簡單的網頁框架建置儀表板。

### 專案 2：企業級提示管理系統

**目標：** 開發基於 MCP 的系統，用於管理、版本控制及部署組織內的提示模板。

**需求：**
- 建立集中式提示模板庫
- 實作版本控制與審核流程
- 建置模板測試功能，支援範例輸入
- 開發基於角色的存取控制
- 建立模板檢索與部署的 API

**實作步驟：**
1. 設計模板儲存的資料庫結構
2. 建立模板 CRUD 操作的核心 API
3. 實作版本控制系統
4. 建置審核流程
5. 開發測試框架
6. 建立簡易的管理網頁介面
7. 與 MCP 伺服器整合

**技術選擇：** 自行選擇後端框架、SQL 或 NoSQL 資料庫，以及前端框架來建置管理介面。

### 專案 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 提供跨不同內容類型的一致結果。

**需求：**
- 支援多種內容格式（部落格文章、社群媒體、行銷文案）
- 實作基於模板的生成，並提供自訂選項
- 建立內容審核與回饋系統
- 追蹤內容效能指標
- 支援內容版本控制與迭代

**實作步驟：**
1. 建置 MCP 用戶端架構
2. 建立不同內容類型的模板
3. 建構內容生成流程
4. 實作審核系統
5. 開發效能指標追蹤系統
6. 建立模板管理與內容生成的使用者介面

**技術選擇：** 選擇您偏好的程式語言、網頁框架及資料庫系統。

## MCP 技術未來發展方向

### 新興趨勢

1. **多模態 MCP**
   - 擴展 MCP 以標準化與影像、音訊及影片模型的互動
   - 發展跨模態推理能力
   - 為不同模態制定標準化提示格式

2. **聯邦 MCP 基礎設施**
   - 分散式 MCP 網路，可跨組織共享資源
   - 標準化安全模型共享協定
   - 隱私保護計算技術

3. **MCP 市場生態系**
   - 分享與貨幣化 MCP 模板與插件的生態系
   - 品質保證與認證流程
   - 與模型市場整合

4. **邊緣運算的 MCP**
   - 適用於資源受限邊緣裝置的 MCP 標準調整
   - 低頻寬環境的優化協定
   - 專為物聯網生態系設計的 MCP 實作

5. **法規框架**
   - 為法規遵循開發 MCP 擴充功能
   - 標準化稽核軌跡與可解釋性介面
   - 與新興 AI 治理框架整合

### 微軟的 MCP 解決方案

微軟與 Azure 開發了多個開源資源庫，協助開發者在不同場景中實作 MCP：

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化與測試的 Playwright MCP 伺服器
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 伺服器實作，供本地測試與社群貢獻
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb 是一套開放協定與相關開源工具，主要聚焦於建立 AI Web 的基礎層

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - 提供多語言在 Azure 上建置與整合 MCP 伺服器的範例、工具與資源連結
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 示範基於現行 Model Context Protocol 規範的認證 MCP 伺服器範例
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 中遠端 MCP 伺服器實作的入口頁，附語言專屬資源庫連結
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Python 於 Azure Functions 快速建置與部署自訂遠端 MCP 伺服器的範本
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 .NET/C# 於 Azure Functions 快速建置與部署自訂遠端 MCP 伺服器的範本
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 TypeScript 於 Azure Functions 快速建置與部署自訂遠端 MCP 伺服器的範本
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 以 Python 實作 Azure API 管理作為遠端 MCP 伺服器的 AI 閘道
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI 實驗專案，包含 MCP 功能，整合 Azure OpenAI 與 AI Foundry

這些資源庫提供多種 MCP 實作、範本與工具，涵蓋不同程式語言與 Azure 服務，適用於從基礎伺服器實作到認證、雲端部署及企業整合等多種使用情境。

#### MCP 資源目錄

官方 Microsoft MCP 資源庫中的 [MCP Resources 目錄](https://github.com/microsoft/mcp/tree/main/Resources) 精選了範例資源、提示模板與工具定義，協助開發者快速上手 MCP，提供可重用的組件與最佳實踐範例，包括：

- **提示模板：** 適用於常見 AI 任務與場景的現成提示模板，可依需求調整用於 MCP 伺服器實作。
- **工具定義：** 範例工具結構與元資料，標準化不同 MCP 伺服器間的工具整合與調用。
- **資源範例：** 連接資料來源、API 與外部服務的範例資源定義，適用於 MCP 框架。
- **參考實作：** 展示如何在實際 MCP 專案中組織資源、提示與工具的實用範例。

這些資源加速開發、促進標準化，並確保 MCP 解決方案的最佳實踐。

#### MCP 資源目錄連結
- [MCP Resources（範例提示、工具與資源定義）](https://github.com/microsoft/mcp/tree/main/Resources)

### 研究機會

- MCP 框架中的高效提示優化技術
- 多租戶 MCP 部署的安全模型
- 不同 MCP 實作的效能基準測試
- MCP 伺服器的形式驗證方法

## 結論

Model Context Protocol (MCP) 正快速塑造標準化、安全且可互操作的 AI 整合未來。透過本課程中的案例研究與實作專案，您已見識到包括 Microsoft 與 Azure 在內的早期採用者如何利用 MCP 解決實際問題、加速 AI 採用，並確保合規、安全與可擴展性。MCP 的模組化設計使組織能在統一且可稽核的框架中連結大型語言模型、工具與企業資料。隨著 MCP 持續演進，積極參與社群、探索開源資源並應用最佳實踐，將是打造穩健且面向未來 AI 解決方案的關鍵。

## 額外資源

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)
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

## 練習題

1. 分析其中一個案例研究，提出替代的實作方案。
2. 選擇一個專案構想，撰寫詳細的技術規格。
3. 研究一個案例中未涵蓋的產業，概述 MCP 如何解決其特定挑戰。
4. 探索未來發展方向之一，設計一個新的 MCP 擴充概念以支援該方向。

下一課： [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。