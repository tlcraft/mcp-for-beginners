<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T16:55:14+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tw"
}
-->
# 早期採用者的經驗分享

## 概覽

本課程探討早期採用者如何利用 Model Context Protocol (MCP) 解決實際問題並推動各產業創新。透過詳盡的案例研究和實作專案，你將看到 MCP 如何促成標準化、安全且具擴充性的 AI 整合——將大型語言模型、工具與企業資料連結於統一架構。你將獲得設計與建置基於 MCP 解決方案的實務經驗，學習經驗豐富的實作模式，並掌握在生產環境中部署 MCP 的最佳實務。課程也會介紹新興趨勢、未來發展方向，以及開源資源，協助你掌握 MCP 技術及其不斷演進的生態系。

## 學習目標

- 分析不同產業中 MCP 的實際應用案例
- 設計並建置完整的 MCP 應用程式
- 探索 MCP 技術的新興趨勢與未來方向
- 在實際開發情境中應用最佳實務

## MCP 的實際應用案例

### 案例研究 1：企業客戶支援自動化

一家跨國企業實作了基於 MCP 的解決方案，標準化其客戶支援系統中的 AI 互動。這使他們能夠：

- 建立多個大型語言模型供應商的統一介面
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

**成果：** 降低模型成本 30%，回應一致性提升 45%，並加強全球營運的合規性。

### 案例研究 2：醫療診斷助理

一家醫療機構建置 MCP 架構，整合多個專業醫療 AI 模型，同時確保敏感病患資料受到保護：

- 輕鬆切換通用與專科醫療模型
- 嚴格的隱私控管與稽核紀錄
- 與現有電子病歷 (EHR) 系統整合
- 醫療術語提示工程的一致性

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

**成果：** 改善醫師診斷建議，完全符合 HIPAA 規範，並大幅減少系統間切換的情況。

### 案例研究 3：金融服務風險分析

一家金融機構導入 MCP，標準化不同部門的風險分析流程：

- 建立信用風險、詐欺偵測與投資風險模型的統一介面
- 實施嚴格的存取控管與模型版本管理
- 確保所有 AI 建議具備可稽核性
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

**成果：** 強化法規遵循，模型部署速度提升 40%，部門間風險評估一致性改善。

### 案例研究 4：Microsoft Playwright MCP 伺服器的瀏覽器自動化

微軟開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，利用 Model Context Protocol 實現安全、標準化的瀏覽器自動化。此方案讓 AI 代理和大型語言模型能以受控、可稽核且可擴充的方式與瀏覽器互動，支援自動化網頁測試、資料擷取及端對端工作流程等應用。

- 將瀏覽器自動化功能（導航、填表、截圖等）作為 MCP 工具公開
- 實施嚴格存取控管與沙盒機制防止未授權行為
- 提供所有瀏覽器互動的詳細稽核日誌
- 支援與 Azure OpenAI 及其他 LLM 供應商整合，推動代理自動化

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
- 降低手動測試負擔並提升網頁應用測試覆蓋率  
- 提供企業環境中瀏覽器工具整合的可重用且可擴充框架

**參考資料：**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是微軟管理的企業級 MCP 實作，提供可擴充、安全且合規的 MCP 伺服器功能，作為雲端服務。Azure MCP 讓組織能快速部署、管理並整合 MCP 伺服器與 Azure AI、資料及安全服務，降低營運負擔，加速 AI 採用。

- 完全托管的 MCP 伺服器主機，內建擴展、監控與安全功能
- 原生整合 Azure OpenAI、Azure AI Search 與其他 Azure 服務
- 透過 Microsoft Entra ID 實現企業認證與授權
- 支援自訂工具、提示範本與資源連接器
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
- 提供即用型合規 MCP 伺服器平台，縮短企業 AI 專案的價值實現時間  
- 簡化大型語言模型、工具及企業資料來源的整合  
- 強化 MCP 工作負載的安全性、可觀察性與營運效率

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## 案例研究 6：NLWeb

MCP（Model Context Protocol）是一種新興協定，讓聊天機器人和 AI 助理能與工具互動。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 ask，用自然語言向網站提問。回傳的回應使用 schema.org，一個廣泛應用於描述網頁資料的詞彙。簡單來說，MCP 對 NLWeb 就像 Http 對 HTML 一樣。NLWeb 結合協定、Schema.org 格式與範例程式碼，協助網站快速建立這類端點，讓人類透過對話介面，機器則透過自然的代理間互動獲益。

NLWeb 有兩個主要組成部分：  
- 一個簡單的協定，用於自然語言與網站介面互動，回應格式使用 json 與 schema.org。詳細內容請參閱 REST API 文件。  
- 一個基於 (1) 的簡單實作，利用現有標記，適用於可抽象為項目清單的網站（如產品、食譜、景點、評論等）。搭配一組使用者介面元件，網站能輕鬆提供內容的對話式介面。詳情請參考 Life of a chat query 文件。

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Foundry MCP – 整合 Azure AI 代理

Azure AI Foundry MCP 伺服器示範 MCP 如何用於企業環境中編排與管理 AI 代理與工作流程。透過將 MCP 與 Azure AI Foundry 整合，組織能標準化代理互動、運用 Foundry 的工作流程管理，並確保安全、可擴展的部署。此方法支援快速原型開發、健全監控，以及與 Azure AI 服務的無縫整合，促成知識管理與代理評估等進階應用。開發者可透過統一介面建置、部署與監控代理管線，IT 團隊則獲得更佳的安全性、合規性與營運效率。此方案非常適合想加速 AI 採用且掌控複雜代理流程的企業。

**參考資料：**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型開發

Foundry MCP Playground 提供一個即用環境，方便開發者實驗 MCP 伺服器與 Azure AI Foundry 整合。開發者可快速建立原型、測試並評估 AI 模型及代理工作流程，利用 Azure AI Foundry Catalog 與 Labs 的資源。該 Playground 簡化設定，提供範例專案並支援協同開發，輕鬆探索最佳實務與新場景，且無需複雜基礎設施。降低進入門檻，有助於促進 MCP 與 Azure AI Foundry 生態系的創新與社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 案例研究 9：Microsoft Docs MCP Server – 學習與技能提升

Microsoft Docs MCP Server 實作了 Model Context Protocol (MCP) 伺服器，讓 AI 助理能即時存取官方 Microsoft 文件，並針對技術文件執行語意搜尋。

**參考資料：**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## 實作專案

### 專案 1：建置多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，能根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**  
- 支援至少三個不同模型供應商（例如 OpenAI、Anthropic、本地模型）  
- 根據請求元資料實作路由機制  
- 建立管理供應商憑證的設定系統  
- 加入快取以優化效能與成本  
- 建置簡單儀表板監控使用狀況

**實作步驟：**  
1. 建立基本 MCP 伺服器架構  
2. 為各 AI 模型服務實作供應商適配器  
3. 建立基於請求屬性的路由邏輯  
4. 加入快取機制處理常見請求  
5. 開發監控儀表板  
6. 針對不同請求模式進行測試

**技術選擇：** Python (.NET/Java/Python 擇一)、Redis 快取、簡單的網頁框架作儀表板。

### 專案 2：企業提示管理系統

**目標：** 開發一套基於 MCP 的系統，用於管理、版本控制及部署組織內的提示範本。

**需求：**  
- 建立集中式提示範本庫  
- 實作版本控制與審核流程  
- 提供範本測試功能及範例輸入  
- 開發角色權限控管  
- 建立範本檢索與部署的 API

**實作步驟：**  
1. 設計範本儲存的資料庫結構  
2. 建立範本 CRUD 核心 API  
3. 實作版本控制系統  
4. 建置審核流程  
5. 開發測試框架  
6. 建立簡單的網頁管理介面  
7. 與 MCP 伺服器整合

**技術選擇：** 後端框架、自選 SQL 或 NoSQL 資料庫、前端框架。

### 專案 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 提供跨多種內容類型的一致結果。

**需求：**  
- 支援多種內容格式（部落格文章、社群媒體、行銷文案）  
- 實作基於範本的生成並支援客製化選項  
- 建立內容審核與回饋系統  
- 追蹤內容效能指標  
- 支援內容版本管理與迭代

**實作步驟：**  
1. 建立 MCP 客戶端架構  
2. 建立不同內容類型的範本  
3. 建置內容生成流程  
4. 實作審核系統  
5. 開發指標追蹤系統  
6. 建立範本管理與內容生成的使用介面

**技術選擇：** 你偏好的程式語言、網頁框架與資料庫系統。

## MCP 技術的未來發展方向

### 新興趨勢

1. **多模態 MCP**  
   - 擴展 MCP 以標準化與影像、音訊、影片模型的互動  
   - 發展跨模態推理能力  
   - 不同模態的標準提示格式

2. **聯邦 MCP 基礎架構**  
   - 分散式 MCP 網路，跨組織共享資源  
   - 安全模型共享的標準協定  
   - 保護隱私的計算技術

3. **MCP 市集**  
   - 分享與變現 MCP 範本與插件的生態系  
   - 品質保證與認證流程  
   - 與模型市集整合

4. **用於邊緣運算的 MCP**  
   - 適用於資源受限的邊緣裝置的 MCP 標準  
   - 優化低頻寬環境的協定  
   - IoT 生態系專用 MCP 實作

5. **法規框架**  
   - 為法規遵循開發 MCP 擴充  
   - 標準化稽核軌跡與解釋介面  
   - 與新興 AI 治理框架整合

### 微軟的 MCP 解決方案

微軟與 Azure 提供多個開源專案，協助開發者在各種情境下實作 MCP：

#### Microsoft 組織  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化與測試的 Playwright MCP 伺服器  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 伺服器實作，供本地測試與社群貢獻  
3. [NLWeb](https://github.com/microsoft/NlWeb) - 一套開放協定與開源工具，專注於 AI Web 的基礎層

#### Azure-Samples 組織  
1. [mcp](https://github.com/Azure-Samples/mcp) - MCP 伺服器的範例、工具與資源，支援多語言在 Azure 上建置與整合  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 示範基於現行 Model Context Protocol 規範的認證 MCP 伺服器  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 上遠端 MCP 伺服器實作的入口頁與語言專案連結  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Python 的遠端 MCP 伺服器快速啟動範本  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 .NET/C# 的遠端 MCP 伺服器快速啟動範本  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 TypeScript 的遠端 MCP 伺服器快速啟動範本  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 使用 Python 的 Azure API 管理作為遠端 MCP 伺服器的 AI 閘道  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM 與 AI 實驗，包含 MCP 能力，整合 Azure OpenAI 與 AI Foundry

這些專案提供多種實作、範本與資源，涵蓋不同程式語言與 Azure 服務，從基礎伺服器實作到認證、雲端部署與企業整合場景。

#### MCP 資源目錄

官方 Microsoft MCP 專案中的 [MCP Resources directory](https://github.com/microsoft
- [MCP 社群與文件](https://modelcontextprotocol.io/introduction)
- [Azure MCP 文件](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub 儲存庫](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI 與自動化解決方案](https://azure.microsoft.com/en-us/products/ai-services/)

## 練習題

1. 分析其中一個案例研究，並提出替代的實作方法。
2. 選擇一個專案構想，並撰寫詳細的技術規格。
3. 研究案例中未涵蓋的產業，並概述 MCP 如何解決該產業的特定挑戰。
4. 探討未來發展方向之一，並設計一個新的 MCP 擴充概念來支持它。

下一步: [最佳實務](../08-BestPractices/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。