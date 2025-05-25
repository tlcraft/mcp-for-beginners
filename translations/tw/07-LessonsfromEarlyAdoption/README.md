<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T20:41:57+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tw"
}
-->
# 早期採用者的經驗分享

## 概覽

本課程探討早期採用者如何運用 Model Context Protocol (MCP) 解決實際問題，並推動各產業創新。透過詳細的案例研究與實作專案，你將了解 MCP 如何實現標準化、安全且可擴展的 AI 整合，將大型語言模型、工具與企業資料串聯於統一架構中。你將獲得設計與建置基於 MCP 解決方案的實務經驗，學習成熟的實作模式，並掌握在生產環境中部署 MCP 的最佳做法。課程同時介紹新興趨勢、未來發展方向與開源資源，幫助你保持在 MCP 技術及其生態系的前沿。

## 學習目標

- 分析不同產業中的 MCP 實際應用案例
- 設計並建置完整的 MCP 應用程式
- 探索 MCP 技術的新興趨勢與未來方向
- 在實際開發情境中應用最佳實務

## MCP 實際應用案例

### 案例研究 1：企業客戶支援自動化

一家跨國企業實作 MCP 解決方案，以標準化其客戶支援系統中的 AI 互動。此方案使他們能夠：

- 建立多家 LLM 供應商的統一介面
- 跨部門維持一致的提示管理
- 實施嚴格的安全與合規控管
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

**成果：** 降低模型成本 30%，回應一致性提升 45%，並加強全球營運的合規性。

### 案例研究 2：醫療診斷助理

某醫療機構建置 MCP 基礎架構，整合多個專業醫療 AI 模型，同時確保敏感病患資料受到保護：

- 在通用與專科醫療模型間無縫切換
- 嚴格的隱私控管與稽核軌跡
- 與現有電子病歷系統（EHR）整合
- 醫療術語的提示工程一致性

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

**成果：** 提升醫師診斷建議，完全符合 HIPAA 規範，並大幅減少系統間切換的負擔。

### 案例研究 3：金融服務風險分析

一家金融機構導入 MCP，標準化各部門的風險分析流程：

- 建立信用風險、詐欺偵測與投資風險模型的統一介面
- 實施嚴格的存取控管與模型版本管理
- 確保所有 AI 建議皆可稽核
- 跨系統維持一致的資料格式

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

**成果：** 強化法規遵循，模型部署週期縮短 40%，風險評估一致性提升。

### 案例研究 4：Microsoft Playwright MCP 伺服器的瀏覽器自動化

Microsoft 開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，透過 Model Context Protocol 實現安全且標準化的瀏覽器自動化。此方案讓 AI 代理與 LLM 能以受控、可稽核且可擴充的方式與網頁瀏覽器互動，應用於自動化網頁測試、資料擷取及端對端工作流程。

- 將瀏覽器自動化功能（導航、表單填寫、截圖等）作為 MCP 工具公開
- 實施嚴格存取控管與沙盒機制，防止未授權操作
- 提供詳細的瀏覽器互動稽核日誌
- 支援與 Azure OpenAI 及其他 LLM 供應商整合，實現代理驅動的自動化

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
- 減少人工測試工作，提升網頁應用測試覆蓋率  
- 提供企業環境中可重用、可擴充的瀏覽器工具整合框架

**參考資料：**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是 Microsoft 管理的企業級 Model Context Protocol 實作，提供可擴展、安全且合規的 MCP 伺服器服務。Azure MCP 讓組織能快速部署、管理並整合 MCP 伺服器與 Azure AI、資料及安全服務，降低營運負擔並加速 AI 採用。

- 完全託管的 MCP 伺服器主機，內建擴展、監控與安全功能
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務
- 透過 Microsoft Entra ID 提供企業身份驗證與授權
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
- 提供即用型合規 MCP 伺服器平台，縮短企業 AI 專案價值實現時間  
- 簡化 LLM、工具與企業資料來源整合  
- 強化 MCP 工作負載的安全性、可觀察性與營運效率

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## 案例研究 6：NLWeb  
MCP（Model Context Protocol）是針對聊天機器人和 AI 助理與工具互動的新興協議。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 ask，用自然語言向網站提問。回傳的回應利用 schema.org，一個廣泛使用的網頁資料描述詞彙。簡單來說，MCP 對 NLWeb 的關係，就像 Http 對 HTML 一樣。NLWeb 結合協議、Schema.org 格式與範例程式碼，幫助網站快速建立這些端點，讓人類透過對話介面、機器透過自然代理間互動獲益。

NLWeb 有兩個主要組成部分：  
- 一個非常簡單的協議，用來與網站以自然語言介面互動，並利用 json 與 schema.org 格式回傳答案。詳細說明請參閱 REST API 文件。  
- 一個簡單的實作，利用現有標記語言，適用於可抽象為項目列表（商品、食譜、景點、評論等）的網站。搭配一組使用者介面元件，網站能輕鬆提供對話式內容介面。詳見 Life of a chat query 文件說明其運作方式。

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Foundry MCP – 整合 Azure AI 代理

Azure AI Foundry MCP 伺服器展示 MCP 如何用於企業環境中協調與管理 AI 代理與工作流程。透過與 Azure AI Foundry 整合，組織能標準化代理互動，利用 Foundry 的工作流程管理，並確保安全且可擴展的部署。此方法支持快速原型開發、穩健監控，並無縫整合 Azure AI 服務，支援知識管理與代理評估等進階場景。開發者享有統一介面來建置、部署與監控代理流程，IT 團隊則提升安全性、合規性與營運效率。此方案適合欲加速 AI 採用並掌控複雜代理驅動流程的企業。

**參考資料：**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型開發

Foundry MCP Playground 提供即用環境，方便開發者實驗 MCP 伺服器與 Azure AI Foundry 整合。開發者能快速原型、測試並評估 AI 模型與代理工作流程，利用 Azure AI Foundry Catalog 與 Labs 資源。此平台簡化設定，提供範例專案，支援協作開發，讓團隊輕鬆探索最佳實務與新場景，且負擔低。降低進入門檻，促進 MCP 與 Azure AI Foundry 生態系的創新與社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## 實作專案

### 專案 1：建置多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，能根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**  
- 支援至少三個不同模型供應商（例如 OpenAI、Anthropic、本地模型）  
- 實作基於請求元資料的路由機制  
- 建立管理供應商憑證的設定系統  
- 加入快取以優化效能與成本  
- 建置簡易儀表板以監控使用狀況

**實作步驟：**  
1. 建立基本 MCP 伺服器架構  
2. 為各 AI 模型服務實作供應商適配器  
3. 根據請求屬性實作路由邏輯  
4. 加入頻繁請求的快取機制  
5. 開發監控儀表板  
6. 以多種請求模式進行測試

**技術選擇：** Python（或 .NET/Java/Python 依偏好）、Redis 快取、簡易網頁框架建置儀表板。

### 專案 2：企業提示管理系統

**目標：** 開發基於 MCP 的系統，管理、版本控制及部署組織內的提示模板。

**需求：**  
- 建立集中式提示模板庫  
- 實作版本控制與審核流程  
- 建置模板測試功能，支援範例輸入  
- 開發角色基礎存取控制  
- 提供模板擷取與部署的 API

**實作步驟：**  
1. 設計模板儲存的資料庫結構  
2. 建立模板 CRUD 核心 API  
3. 實作版本控制系統  
4. 建置審核工作流程  
5. 開發測試框架  
6. 建立簡易網頁管理介面  
7. 與 MCP 伺服器整合

**技術選擇：** 後端框架、SQL 或 NoSQL 資料庫，及管理介面前端框架自選。

### 專案 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 提供不同內容類型間一致的結果。

**需求：**  
- 支援多種內容格式（部落格文章、社群媒體、行銷文案）  
- 實作模板生成並支援客製化選項  
- 建立內容審核與回饋系統  
- 追蹤內容效能指標  
- 支援內容版本控制與迭代

**實作步驟：**  
1. 建立 MCP 用戶端架構  
2. 建立不同內容類型的模板  
3. 建置內容生成管線  
4. 實作審核系統  
5. 開發效能指標追蹤系統  
6. 建立模板管理與內容生成的使用介面

**技術選擇：** 自選程式語言、網頁框架與資料庫系統。

## MCP 技術未來方向

### 新興趨勢

1. **多模態 MCP**  
   - 擴展 MCP 以標準化與影像、音訊及影片模型的互動  
   - 發展跨模態推理能力  
   - 不同模態的標準提示格式

2. **聯邦 MCP 基礎架構**  
   - 分散式 MCP 網路，可跨組織共享資源  
   - 安全模型共享的標準協議  
   - 隱私保護計算技術

3. **MCP 市場平台**  
   - 共享與變現 MCP 模板與插件的生態系  
   - 品質保證與認證流程  
   - 與模型市場整合

4. **邊緣運算的 MCP**  
   - 為資源有限的邊緣裝置調整 MCP 標準  
   - 低頻寬環境的優化協議  
   - 針對物聯網生態系的專用 MCP 實作

5. **法規架構**  
   - 為合規開發 MCP 擴充功能  
   - 標準化稽核軌跡與可解釋性介面  
   - 與新興 AI 治理框架整合

### Microsoft 的 MCP 解決方案

Microsoft 與 Azure 提供多個開源資源庫，協助開發者在各種情境下實作 MCP：

#### Microsoft 組織  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化與測試的 Playwright MCP 伺服器  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 伺服器實作，支援本地測試與社群貢獻  
3. [NLWeb](https://github.com/microsoft/NlWeb) - 一套開放協議與相關開源工具，專注於建立 AI 網頁基礎層  

#### Azure-Samples 組織  
1. [mcp](https://github.com/Azure-Samples/mcp) - 多語言 MCP 伺服器建置與整合範例、工具與資源  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 依現行 MCP 規範展示身份驗證的參考伺服器  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 上的遠端 MCP 伺服器實作入口，含語言專屬資源庫連結  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Python 建置與部署自訂遠端 MCP 伺服器的快速範本  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 .NET/C# 建置與部署自訂遠端 MCP 伺服器的快速範本  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 TypeScript 建置與部署自訂遠端 MCP 伺服器的快速範本  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 以 Python 實現 Azure API 管理作為 AI 閘道連接遠端 MCP 伺服器  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - 包含 MCP 功能的 APIM ❤️ AI 實驗，整合 Azure OpenAI 與 AI Foundry

這些資源庫提供多種實作範例、模板與工具，涵蓋不同程式語言與 Azure 服務，從基本伺服器建置到身份驗證、雲端部署與企業整合場景皆有涵蓋。

#### MCP 資源目錄

官方 Microsoft MCP 資源庫中的 [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) 蒐集了範例資源、提示模板與工具定義，供 MCP 伺服器使用。此目錄幫助開發者快速入門 MCP，提供可重用的組件與最佳實務範例：

- **提示模板：** 常見 AI 任務與場景的即用型提示模板，可依需求調整  
- **工具定義：** 標準化工具整合與調用的範例工具結構與元資料  
- **資源範例：** 用於連接資料來源、API 與
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

1. 分析其中一個案例研究，並提出替代的實作方法。
2. 選擇一個專案構想，並撰寫詳細的技術規格。
3. 研究案例中未涵蓋的產業，並說明 MCP 如何解決該產業的特定挑戰。
4. 探索未來發展方向之一，並設計一個新的 MCP 擴充功能概念以支援該方向。

下一步: [Best Practices](../08-BestPractices/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們努力追求準確性，但請注意自動翻譯可能會包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所引起之任何誤解或誤釋負責。