<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:12:41+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "mo"
}
-->
# 早期採用者的經驗教訓

## 概述

本課程探討早期採用者如何利用 Model Context Protocol (MCP) 解決現實世界的挑戰，並推動各行業的創新。透過詳細的案例研究和實作專案，你將了解 MCP 如何實現標準化、安全且可擴展的 AI 整合——將大型語言模型、工具與企業數據連結於統一框架中。你將獲得設計與構建基於 MCP 解決方案的實務經驗，學習經過驗證的實作模式，並發掘在生產環境中部署 MCP 的最佳實踐。課程同時強調新興趨勢、未來方向及開源資源，助你保持在 MCP 技術及其生態系統的前沿。

## 學習目標

- 分析不同行業中 MCP 的實際應用案例
- 設計並構建完整的 MCP 應用程式
- 探索 MCP 技術的新興趨勢與未來發展
- 在實際開發場景中應用最佳實踐

## MCP 實際應用案例

### 案例研究 1：企業客戶支援自動化

一家跨國企業實施了基於 MCP 的解決方案，以標準化其客戶支援系統中的 AI 互動。此舉使他們能夠：

- 為多個 LLM 供應商建立統一介面
- 在各部門間維持一致的提示管理
- 實施強健的安全與合規控制
- 根據特定需求輕鬆切換不同 AI 模型

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

一家醫療機構建立了 MCP 基礎設施，整合多個專業醫療 AI 模型，同時確保敏感病患資料受到保護：

- 在通用與專科醫療模型間無縫切換
- 嚴格的隱私控管與審計追蹤
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

- 為信用風險、詐欺偵測及投資風險模型建立統一介面
- 實施嚴格的存取控制與模型版本管理
- 確保所有 AI 建議具備可審計性
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

**成果：** 強化法規遵循，模型部署週期加快 40%，並提升部門間風險評估的一致性。

### 案例研究 4：Microsoft Playwright MCP 伺服器用於瀏覽器自動化

Microsoft 開發了 [Playwright MCP server](https://github.com/microsoft/playwright-mcp)，透過 Model Context Protocol 實現安全且標準化的瀏覽器自動化。此解決方案允許 AI 代理與 LLM 在受控、可審計且可擴充的環境中與網頁瀏覽器互動，支援自動化網頁測試、資料擷取及端對端工作流程等應用。

- 將瀏覽器自動化功能（導航、表單填寫、截圖等）以 MCP 工具形式暴露
- 實施嚴格的存取控制與沙盒機制，防止未授權操作
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
- 為 AI 代理與 LLM 啟用安全的程式化瀏覽器自動化  
- 降低手動測試工作量，提升網頁應用測試覆蓋率  
- 提供可重用且可擴充的企業級瀏覽器工具整合框架

**參考資料：**  
- [Playwright MCP Server GitHub 倉庫](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI 與自動化解決方案](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是 Microsoft 管理的企業級 Model Context Protocol 實作，旨在提供可擴展、安全且合規的 MCP 伺服器雲端服務。Azure MCP 使組織能快速部署、管理並整合 MCP 伺服器與 Azure AI、資料及安全服務，降低營運負擔，加速 AI 採用。

- 完全託管的 MCP 伺服器主機，內建擴展、監控與安全功能
- 原生整合 Azure OpenAI、Azure AI Search 及其他 Azure 服務
- 透過 Microsoft Entra ID 實現企業級身份驗證與授權
- 支援自訂工具、提示範本及資源連接器
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
- 簡化 LLM、工具與企業資料來源的整合  
- 強化 MCP 工作負載的安全性、可觀察性與營運效率

**參考資料：**  
- [Azure MCP 文件](https://aka.ms/azmcp)  
- [Azure AI 服務](https://azure.microsoft.com/en-us/products/ai-services/)

## 案例研究 6：NLWeb

MCP（Model Context Protocol）是一種新興協議，讓聊天機器人和 AI 助理能與工具互動。每個 NLWeb 實例同時也是 MCP 伺服器，支援一個核心方法 ask，用於以自然語言向網站提問。回傳的回應利用 schema.org，一個廣泛使用的網頁資料描述詞彙。簡言之，MCP 對 NLWeb 的關係就像 Http 對 HTML。NLWeb 結合協議、Schema.org 格式與範例程式碼，幫助網站快速建立這些端點，既方便人類透過對話介面，也利於機器間的自然代理互動。

NLWeb 有兩個主要組成部分：  
- 一個簡單的協議，用於以自然語言與網站介面互動，回應格式採用 json 與 schema.org。詳情請參閱 REST API 文件。  
- 一個基於 (1) 的簡易實作，利用現有標記，適用於可抽象為項目清單（產品、食譜、景點、評論等）的網站。結合一組使用者介面元件，網站能輕鬆提供內容的對話式介面。詳情請參閱「聊天查詢的生命週期」文件。

**參考資料：**  
- [Azure MCP 文件](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Foundry MCP – 整合 Azure AI 代理

Azure AI Foundry MCP 伺服器展示了 MCP 如何用於企業環境中協調與管理 AI 代理及工作流程。透過將 MCP 與 Azure AI Foundry 整合，組織能標準化代理互動，利用 Foundry 的工作流程管理，並確保安全且可擴展的部署。此方法支援快速原型開發、強健監控及與 Azure AI 服務的無縫整合，適用於知識管理與代理評估等進階場景。開發者可透過統一介面建置、部署及監控代理流程，IT 團隊則獲得更佳的安全性、合規性與營運效率。此解決方案非常適合希望加速 AI 採用並掌控複雜代理驅動流程的企業。

**參考資料：**  
- [MCP Foundry GitHub 倉庫](https://github.com/azure-ai-foundry/mcp-foundry)  
- [整合 Azure AI 代理與 MCP（Microsoft Foundry 部落格）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型開發

Foundry MCP Playground 提供一個即用環境，方便開發者實驗 MCP 伺服器與 Azure AI Foundry 整合。開發者能快速原型、測試及評估 AI 模型與代理工作流程，利用 Azure AI Foundry 目錄與實驗室資源。此 Playground 簡化設定，提供範例專案，支援協作開發，讓團隊輕鬆探索最佳實踐與新場景，且無需複雜基礎設施。透過降低入門門檻，促進 MCP 與 Azure AI Foundry 生態系的創新與社群貢獻。

**參考資料：**  
- [Foundry MCP Playground GitHub 倉庫](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 案例研究 9：Microsoft Docs MCP 伺服器 – 學習與技能提升

Microsoft Docs MCP 伺服器實作了 Model Context Protocol，為 AI 助理提供即時存取官方 Microsoft 文件的能力。可對 Microsoft 官方技術文件執行語意搜尋。

**參考資料：**  
- [Microsoft Learn Docs MCP 伺服器](https://github.com/MicrosoftDocs/mcp)

## 實作專案

### 專案 1：建置多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，能根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**  
- 支援至少三個不同模型供應商（如 OpenAI、Anthropic、本地模型）  
- 實作基於請求元資料的路由機制  
- 建立管理供應商憑證的設定系統  
- 加入快取以優化效能與成本  
- 建置簡易儀表板以監控使用狀況

**實作步驟：**  
1. 建立基本 MCP 伺服器架構  
2. 為每個 AI 模型服務實作供應商適配器  
3. 根據請求屬性建立路由邏輯  
4. 加入常用請求的快取機制  
5. 開發監控儀表板  
6. 以多種請求模式進行測試

**技術選擇：** 可選擇 Python（或 .NET/Java/Python，依偏好而定）、Redis 作為快取，及簡易網頁框架建置儀表板。

### 專案 2：企業提示管理系統

**目標：** 開發基於 MCP 的系統，用於管理、版本控制及部署組織內的提示範本。

**需求：**  
- 建立集中式提示範本庫  
- 實作版本控制與審核流程  
- 建置範本測試功能，支援範例輸入  
- 開發基於角色的存取控制  
- 提供範本檢索與部署的 API

**實作步驟：**  
1. 設計範本儲存的資料庫結構  
2. 建立範本 CRUD 核心 API  
3. 實作版本控制系統  
4. 建置審核工作流程  
5. 開發測試框架  
6. 建立簡易網頁管理介面  
7. 與 MCP 伺服器整合

**技術選擇：** 自選後端框架、SQL 或 NoSQL 資料庫，以及前端框架。

### 專案 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 提供跨不同內容類型的一致結果。

**需求：**  
- 支援多種內容格式（部落格文章、社群媒體、行銷文案）  
- 實作基於範本的生成，並提供自訂選項  
- 建立內容審核與回饋系統  
- 追蹤內容效能指標  
- 支援內容版本控制與迭代

**實作步驟：**  
1. 建立 MCP 用戶端架構  
2. 建立不同內容類型的範本  
3. 建置內容生成流程  
4. 實作審核系統  
5. 開發效能指標追蹤系統  
6. 建立範本管理與內容生成的使用者介面

**技術選擇：** 自選程式語言、網頁框架與資料庫系統。

## MCP 技術未來發展方向

### 新興趨勢

1. **多模態 MCP**  
   - 擴展 MCP 以標準化與影像、音訊及影片模型的互動  
   - 發展跨模態推理能力  
   - 制定不同模態的標準提示格式

2. **聯邦 MCP 基礎設施**  
   - 建立可跨組織共享資源的分散式 MCP 網路  
   - 制定安全模型共享的標準協議  
   - 採用隱私保護計算技術

3. **MCP 市場生態系**  
   - 建立 MCP 範本與插件的分享與貨幣化生態系  
   - 品質保證與認證流程  
   - 與模型市場整合

4. **邊緣運算的 MCP**  
   - 調整 MCP 標準以適應資源受限的邊緣裝置  
   - 優化低頻寬環境的協議  
   - 為物聯網生態系打造專用 MCP 實作

5. **法規框架**  
   - 發展 MCP 擴充以符合法規要求  
   - 標準化審計追蹤與可解釋性介面  
   - 與新興 AI 治理框架整合

### Microsoft 的 MCP 解決方案

Microsoft 與 Azure 推出多個開源倉庫，協助開發者在各種場景中實作 MCP：

#### Microsoft 組織  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化與測試的 Playwright MCP 伺服器  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 伺服器實作，供本地測試與社群貢獻  
3. [NLWeb](https://github.com/microsoft/NlWeb) - 一套開放協議與相關開源工具，專注於建立 AI 網頁的基礎層

#### Azure-Samples 組織  
1. [mcp](https://github.com/Azure-Samples/mcp) - 提供多語言範例、工具與資源，協助在 Azure 上建置與整合 MCP 伺服器  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 參考 MCP 伺服器，示範基於現行 Model Context Protocol 規範的身份驗證

#
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 中 Remote MCP Server 實作的入口頁面，並附有各語言專屬的程式庫連結  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Python 透過 Azure Functions 建置及部署自訂遠端 MCP 伺服器的快速入門範本  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 .NET/C# 透過 Azure Functions 建置及部署自訂遠端 MCP 伺服器的快速入門範本  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 TypeScript 透過 Azure Functions 建置及部署自訂遠端 MCP 伺服器的快速入門範本  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 使用 Python 將 Azure API Management 作為 AI 閘道連接遠端 MCP 伺服器  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI 實驗專案，包含 MCP 功能，整合 Azure OpenAI 與 AI Foundry  

這些程式庫提供了多種實作範例、範本及資源，涵蓋不同程式語言與 Azure 服務中使用 Model Context Protocol 的應用。內容涵蓋從基礎伺服器實作到認證、雲端部署及企業整合等多種使用情境。  

#### MCP 資源目錄  

官方 Microsoft MCP 程式庫中的 [MCP Resources 目錄](https://github.com/microsoft/mcp/tree/main/Resources) 提供精選的範例資源、提示範本及工具定義，供 Model Context Protocol 伺服器使用。此目錄旨在協助開發者快速上手 MCP，提供可重複使用的組件及最佳實踐範例，包括：  

- **提示範本：** 適用於常見 AI 任務與場景的現成提示範本，可依需求調整用於自訂 MCP 伺服器實作。  
- **工具定義：** 範例工具結構與元資料，標準化不同 MCP 伺服器間的工具整合與調用。  
- **資源範例：** 連接資料來源、API 及外部服務的範例資源定義，適用於 MCP 框架內。  
- **參考實作：** 實務範例展示如何在真實 MCP 專案中組織與架構資源、提示及工具。  

這些資源能加速開發流程，促進標準化，並確保在建置與部署 MCP 解決方案時遵循最佳實務。  

#### MCP 資源目錄  
- [MCP Resources（範例提示、工具及資源定義）](https://github.com/microsoft/mcp/tree/main/Resources)  

### 研究機會  

- MCP 框架中高效提示優化技術  
- 多租戶 MCP 部署的安全模型  
- 不同 MCP 實作的效能基準測試  
- MCP 伺服器的形式驗證方法  

## 結論  

Model Context Protocol (MCP) 正快速塑造跨產業標準化、安全且可互操作的 AI 整合未來。透過本課程中的案例研究與實作專案，你已見識到包括 Microsoft 與 Azure 在內的早期採用者如何利用 MCP 解決實際問題，加速 AI 採用，並確保合規性、安全性與可擴展性。MCP 的模組化設計使組織能在統一且可稽核的框架中連接大型語言模型、工具與企業資料。隨著 MCP 持續演進，積極參與社群、探索開源資源並應用最佳實務，將是打造穩健且面向未來 AI 解決方案的關鍵。  

## 其他資源  

- [MCP Foundry GitHub 程式庫](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [將 Azure AI Agents 與 MCP 整合（Microsoft Foundry 部落格）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub 程式庫（Microsoft）](https://github.com/microsoft/mcp)  
- [MCP 資源目錄（範例提示、工具及資源定義）](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCP 社群與文件](https://modelcontextprotocol.io/introduction)  
- [Azure MCP 文件](https://aka.ms/azmcp)  
- [Playwright MCP Server GitHub 程式庫](https://github.com/microsoft/playwright-mcp)  
- [Files MCP Server（OneDrive）](https://github.com/microsoft/files-mcp-server)  
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)  
- [MCP Auth Servers（Azure-Samples）](https://github.com/Azure-Samples/mcp-auth-servers)  
- [Remote MCP Functions（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions)  
- [Remote MCP Functions Python（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-python)  
- [Remote MCP Functions .NET（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)  
- [Remote MCP Functions TypeScript（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-typescript)  
- [Remote MCP APIM Functions Python（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway（Azure-Samples）](https://github.com/Azure-Samples/AI-Gateway)  
- [Microsoft AI 與自動化解決方案](https://azure.microsoft.com/en-us/products/ai-services/)  

## 練習題  

1. 分析其中一個案例研究，並提出替代的實作方法。  
2. 選擇一個專案構想，撰寫詳細的技術規格。  
3. 研究一個案例中未涵蓋的產業，並概述 MCP 如何解決該產業的特定挑戰。  
4. 探索未來發展方向之一，並設計一個新的 MCP 擴充概念以支持該方向。  

下一章節：[最佳實務](../08-BestPractices/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。