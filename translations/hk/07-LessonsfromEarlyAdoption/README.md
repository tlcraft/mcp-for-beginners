<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T20:39:07+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hk"
}
-->
# 早期採用者的經驗分享

## 概覽

本課程探討早期採用者如何運用 Model Context Protocol (MCP) 解決實際問題，並推動各行業的創新。透過詳盡的案例研究和實作項目，你將了解 MCP 如何實現標準化、安全及可擴展的 AI 整合——將大型語言模型、工具與企業數據統一連結於一個框架中。你會獲得設計及構建基於 MCP 解決方案的實務經驗，學習已驗證的實作模式，以及掌握在生產環境部署 MCP 的最佳實踐。課程亦會介紹新興趨勢、未來發展方向和開源資源，助你保持在 MCP 技術及其生態系的前沿。

## 學習目標

- 分析不同行業中 MCP 的實際應用案例  
- 設計並建構完整的 MCP 應用程式  
- 探索 MCP 技術的新興趨勢及未來方向  
- 在實際開發情境中應用最佳實務

## MCP 實際應用案例

### 案例研究 1：企業客戶支援自動化

一間跨國企業實施基於 MCP 的解決方案，統一其客戶支援系統中的 AI 互動。此方案讓他們能：

- 建立多個大型語言模型供應商的統一介面  
- 在不同部門間維持一致的提示管理  
- 實施強健的安全與合規控制  
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

**成果：** 模型成本降低 30%，回應一致性提升 45%，全球營運的合規性加強。

### 案例研究 2：醫療診斷助理

一家醫療機構建立 MCP 基礎設施，整合多個專業醫療 AI 模型，同時確保敏感的病人資料安全：

- 在通用與專科醫療模型間無縫切換  
- 嚴格的隱私控管與審計追蹤  
- 與現有電子健康紀錄（EHR）系統整合  
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

**成果：** 醫師診斷建議更準確，同時完全符合 HIPAA 法規，並大幅減少系統間的切換成本。

### 案例研究 3：金融服務風險分析

一家金融機構運用 MCP 標準化其跨部門的風險分析流程：

- 建立信用風險、詐欺偵測及投資風險模型的統一介面  
- 實施嚴格的存取控制與模型版本管理  
- 確保所有 AI 建議可審計  
- 維持多元系統間資料格式的一致性

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

**成果：** 強化法規遵循，模型部署週期加快 40%，部門間風險評估更一致。

### 案例研究 4：Microsoft Playwright MCP Server 用於瀏覽器自動化

Microsoft 開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，透過 Model Context Protocol 提供安全且標準化的瀏覽器自動化。此方案讓 AI 代理及大型語言模型可在受控、可審計且可擴展的環境下與瀏覽器互動，支援自動化網頁測試、資料擷取及端對端工作流程等應用。

- 將瀏覽器自動化功能（導航、表單填寫、截圖等）作為 MCP 工具暴露  
- 實施嚴格存取控制與沙盒機制，防止未授權操作  
- 提供詳細的瀏覽器互動審計日誌  
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
- 為 AI 代理與 LLM 提供安全、程式化的瀏覽器自動化  
- 降低手動測試工作量，提升網頁應用測試覆蓋率  
- 提供可重用且可擴展的瀏覽器工具整合框架，適用企業環境

**參考資料：**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是 Microsoft 提供的企業級 MCP 托管服務，設計用以提供可擴展、安全且合規的 MCP 伺服器能力。Azure MCP 讓組織能快速部署、管理並整合 MCP 伺服器與 Azure AI、數據及安全服務，降低營運負擔，加速 AI 採用。

- 完整托管的 MCP 伺服器主機，內建擴展、監控與安全功能  
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務  
- 透過 Microsoft Entra ID 實現企業級認證與授權  
- 支援自訂工具、提示模板及資源連接器  
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
- 提供即用型、合規的 MCP 伺服器平台，縮短企業 AI 專案上市時間  
- 簡化 LLM、工具與企業數據來源的整合  
- 強化 MCP 工作負載的安全性、可觀察性與營運效率

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## 案例研究 6：NLWeb  
MCP（Model Context Protocol）是一種新興協議，讓聊天機器人和 AI 助理能與工具互動。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 ask，用以用自然語言向網站提問。回應採用 schema.org 格式，一個廣泛使用的網頁資料描述詞彙。簡單來說，MCP 對 NLWeb 的關係就像 HTTP 對 HTML。NLWeb 結合協議、Schema.org 格式和範例程式碼，幫助網站快速建立此類端點，既方便人類透過對話介面，也利於機器間的自然代理互動。

NLWeb 有兩個主要組成部分：  
- 一個簡單的協議，讓網站能以自然語言介面互動，回應格式則採用 json 與 schema.org。詳見 REST API 文件。  
- 一個簡易實作，利用現有標記語言，適用於可抽象為項目清單（產品、食譜、景點、評論等）的網站。結合一組使用者介面元件，網站能輕鬆提供對話式介面。詳見 Life of a chat query 文件了解運作原理。

**參考資料：**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Foundry MCP – 整合 Azure AI Agents

Azure AI Foundry MCP 伺服器展示 MCP 如何在企業環境中協調與管理 AI 代理及工作流程。透過將 MCP 與 Azure AI Foundry 整合，組織可標準化代理互動，利用 Foundry 的工作流程管理，並確保安全且可擴展的部署。此方法支持快速原型開發、完善監控，以及與 Azure AI 服務的無縫整合，適用於知識管理與代理評估等進階場景。開發者享有統一介面來建構、部署與監控代理管線，IT 團隊則提升安全性、合規性及營運效率。此方案適合希望加速 AI 採用並掌控複雜代理流程的企業。

**參考資料：**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型設計

Foundry MCP Playground 提供即用環境，方便開發者實驗 MCP 伺服器及 Azure AI Foundry 整合。開發者可快速原型、測試並評估 AI 模型與代理工作流程，使用 Azure AI Foundry Catalog 與 Labs 的資源。此 Playground 簡化設定，提供範例專案，並支援協作開發，輕鬆探索最佳實踐與新場景，降低基礎建設門檻，促進創新與社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## 實作項目

### 項目 1：建構多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**  
- 支援至少三個不同模型供應商（例如 OpenAI、Anthropic、本地模型）  
- 根據請求元資料實作路由機制  
- 建立管理供應商憑證的設定系統  
- 加入快取以優化效能及成本  
- 建立簡易儀表板監控使用情況

**實作步驟：**  
1. 建置基礎 MCP 伺服器架構  
2. 實作每個 AI 模型服務的供應商適配器  
3. 根據請求屬性設計路由邏輯  
4. 加入常用請求的快取機制  
5. 開發監控儀表板  
6. 以不同請求模式進行測試

**技術選擇：** Python (.NET/Java/Python 擇一)、Redis 快取、簡易網頁框架做儀表板。

### 項目 2：企業提示管理系統

**目標：** 開發基於 MCP 的系統，管理、版本控管並部署組織內的提示模板。

**需求：**  
- 建立集中式提示模板庫  
- 實作版本控管與審核流程  
- 建置模板測試功能，提供範例輸入  
- 開發基於角色的存取控制  
- 提供模板檢索及部署的 API

**實作步驟：**  
1. 設計模板儲存的資料庫結構  
2. 建立模板 CRUD 的核心 API  
3. 實作版本控管系統  
4. 建立審核流程  
5. 開發測試框架  
6. 製作簡易管理網頁介面  
7. 與 MCP 伺服器整合

**技術選擇：** 自選後端框架、SQL 或 NoSQL 資料庫，前端框架做管理介面。

### 項目 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 產出不同內容類型的一致結果。

**需求：**  
- 支援多種內容格式（部落格文章、社群媒體貼文、行銷文案）  
- 實作基於模板的生成，並提供客製化選項  
- 建立內容審核與回饋系統  
- 追蹤內容表現指標  
- 支援內容版本控管與迭代

**實作步驟：**  
1. 建立 MCP 用戶端架構  
2. 製作不同內容類型的模板  
3. 建構內容生成管線  
4. 實作審核系統  
5. 開發指標追蹤系統  
6. 建立模板管理與內容生成的使用者介面

**技術選擇：** 自選程式語言、網頁框架及資料庫系統。

## MCP 技術未來發展方向

### 新興趨勢

1. **多模態 MCP**  
   - 擴展 MCP 以標準化影像、音訊與影片模型的互動  
   - 發展跨模態推理能力  
   - 為不同模態設計標準化提示格式

2. **聯邦 MCP 基礎設施**  
   - 分散式 MCP 網絡，促進跨組織資源共享  
   - 標準化安全模型共享協議  
   - 隱私保護計算技術

3. **MCP 市場平台**  
   - 共享及貨幣化 MCP 模板與插件的生態系  
   - 品質保證與認證流程  
   - 與模型市場整合

4. **MCP 邊緣運算**  
   - 調整 MCP 標準以適應資源有限的邊緣裝置  
   - 優化低頻寬環境的協議  
   - 專為物聯網生態系設計的 MCP 實作

5. **法規框架**  
   - 開發 MCP 擴充以符合法規要求  
   - 標準化審計軌跡與可解釋性介面  
   - 與新興 AI 治理框架整合

### Microsoft 推出的 MCP 解決方案

Microsoft 與 Azure 提供多個開源資源庫，協助開發者在不同場景中實作 MCP：

#### Microsoft 組織  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化與測試的 Playwright MCP 伺服器  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 伺服器實作，適合本地測試與社群貢獻  
3. [NLWeb](https://github.com/microsoft/NlWeb) - 一組開放協議與相關開源工具，主攻 AI Web 基礎層

#### Azure-Samples 組織  
1. [mcp](https://github.com/Azure-Samples/mcp) - MCP 伺服器建置與整合的範例、工具及資源，支援多語言與 Azure  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 示範基於現行 MCP 規範的認證伺服器  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 上的遠端 MCP 伺服器實作入口，含語言專屬連結  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions Python 快速啟動範本  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions .NET/C# 快速啟動範本  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions TypeScript 快速啟動範本  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 使用 Python 的 Azure API Management 作為遠端 MCP 伺服器 AI 閘道  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI 實驗，含 MCP 功能，整合 Azure OpenAI 及 AI Foundry

這些資源庫涵蓋從基本伺服器實作、認證、雲端部署到企業整合等多種用例，支援多種程式語言與 Azure 服務。

#### MCP 資源目錄

官方 Microsoft MCP 資源庫中的 [MCP Resources 目錄](https://github.com/microsoft/mcp/tree/main/Resources) 提供精選的範例資源、提示模板與工具定義，協助開發者快速上手 MCP，並提供可重用元件及最佳實務範例，包括：

- **提示模板：** 針對常見 AI 任務的即用模板，可調整用於自有 MCP 伺服器  
- **工具定義：** 範例工具架構與元資料，標準化 MCP 伺服器間工具整合與調用  
- **資源範例：** 連接資料來源、API 及外部服務的資源定義範例  
- **參考實作：** 展示如何在實際 MCP 專案中結構化資源、提示與工具的範例

這些資
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

1. 分析其中一個案例研究，並提出另一種實施方法。
2. 選擇一個項目構思，撰寫詳細的技術規格。
3. 研究一個案例研究中未涵蓋的行業，並概述 MCP 如何解決該行業的具體挑戰。
4. 探討其中一個未來發展方向，構思一個新的 MCP 擴展以支持該方向。

下一步: [Best Practices](../08-BestPractices/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我哋致力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。