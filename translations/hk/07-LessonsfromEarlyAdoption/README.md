<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "261078280431a58292789702da620407",
  "translation_date": "2025-07-28T23:44:19+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hk"
}
-->
# 🌟 從早期採用者學到的經驗

[![從 MCP 早期採用者學到的經驗](../../../translated_images/08.980bb2babbaadd8a97739effc9b31e5f1abd8f4c4a3fbc90fb9f931a866674d0.hk.png)](https://youtu.be/jds7dSmNptE)

_（點擊上方圖片觀看本課程的影片）_

## 🎯 本模組涵蓋的內容

本模組探討了真實的組織和開發者如何利用 Model Context Protocol (MCP) 解決實際挑戰並推動創新。透過詳細的案例研究和實作範例，您將了解 MCP 如何實現安全、可擴展的 AI 整合，將語言模型、工具和企業數據連結在一起。

### 📚 MCP 的實際應用

想了解這些原則如何應用於生產工具？請參考我們的 [**10 個改變開發者生產力的 Microsoft MCP 伺服器**](microsoft-mcp-servers.md)，其中展示了您今天就可以使用的真實 Microsoft MCP 伺服器。

## 概覽

本課程探討了早期採用者如何利用 Model Context Protocol (MCP) 解決實際挑戰並推動各行業的創新。透過詳細的案例研究和實作項目，您將看到 MCP 如何實現標準化、安全且可擴展的 AI 整合，將大型語言模型、工具和企業數據統一在一個框架中。您將獲得設計和構建基於 MCP 解決方案的實際經驗，學習經過驗證的實施模式，並發現如何在生產環境中部署 MCP 的最佳實踐。本課程還強調了新興趨勢、未來方向以及開源資源，幫助您保持 MCP 技術及其生態系統的前沿。

## 學習目標

- 分析不同產業中 MCP 的實際應用
- 設計並構建完整的基於 MCP 的應用程式
- 探索 MCP 技術的新興趨勢和未來方向
- 在實際開發場景中應用最佳實踐

## MCP 的實際應用

### 案例研究 1：企業客戶支持自動化

一家跨國公司實施了基於 MCP 的解決方案，標準化其客戶支持系統中的 AI 互動。這使他們能夠：

- 為多個 LLM 提供商創建統一的介面
- 在各部門之間保持一致的提示管理
- 實施強大的安全性和合規控制
- 根據特定需求輕鬆切換不同的 AI 模型

**技術實施：**

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

**結果：** 模型成本降低 30%，回應一致性提高 45%，並增強了全球業務的合規性。

### 案例研究 2：醫療診斷助手

一家醫療機構開發了 MCP 基礎設施，以整合多個專業醫療 AI 模型，同時確保敏感的患者數據受到保護：

- 在通用和專業醫療模型之間無縫切換
- 嚴格的隱私控制和審計記錄
- 與現有電子健康記錄 (EHR) 系統整合
- 為醫療術語提供一致的提示設計

**技術實施：**

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

**結果：** 為醫生提供改進的診斷建議，同時保持完全符合 HIPAA 規範，並顯著減少系統之間的上下文切換。

### 案例研究 3：金融服務風險分析

一家金融機構實施了 MCP，以標準化其不同部門的風險分析流程：

- 為信用風險、欺詐檢測和投資風險模型創建統一的介面
- 實施嚴格的訪問控制和模型版本管理
- 確保所有 AI 建議的可審計性
- 在多樣化系統之間保持一致的數據格式

**技術實施：**

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

**結果：** 增強了監管合規性，模型部署週期加快 40%，並提高了部門間風險評估的一致性。

### 案例研究 4：Microsoft Playwright MCP 伺服器用於瀏覽器自動化

Microsoft 開發了 [Playwright MCP 伺服器](https://github.com/microsoft/playwright-mcp)，以透過 Model Context Protocol 實現安全、標準化的瀏覽器自動化。這個生產就緒的伺服器允許 AI 代理和 LLM 在受控、可審計且可擴展的方式下與網頁瀏覽器互動，實現自動化網頁測試、數據提取和端到端工作流程等用例。

> **🎯 生產就緒工具**
> 
> 本案例研究展示了一個您今天就可以使用的真實 MCP 伺服器！了解更多關於 Playwright MCP 伺服器及其他 9 個生產就緒的 Microsoft MCP 伺服器的資訊，請參考我們的 [**Microsoft MCP 伺服器指南**](microsoft-mcp-servers.md#8--playwright-mcp-server)。

**主要功能：**
- 將瀏覽器自動化功能（導航、表單填寫、截圖等）作為 MCP 工具公開
- 實施嚴格的訪問控制和沙盒機制，防止未授權操作
- 提供所有瀏覽器互動的詳細審計日誌
- 支援與 Azure OpenAI 和其他 LLM 提供商的整合，用於代理驅動的自動化
- 為 GitHub Copilot 的編碼代理提供網頁瀏覽功能

**技術實施：**

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

**結果：**

- 為 AI 代理和 LLM 實現了安全的程式化瀏覽器自動化
- 減少了手動測試工作量，並提高了網頁應用程式的測試覆蓋率
- 提供了一個可重用、可擴展的框架，用於企業環境中的基於瀏覽器的工具整合
- 支援 GitHub Copilot 的網頁瀏覽功能

**參考資料：**

- [Playwright MCP 伺服器 GitHub 儲存庫](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI 和自動化解決方案](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP – 企業級 Model Context Protocol 即服務

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是 Microsoft 的企業級 Model Context Protocol 托管實現，旨在作為雲服務提供可擴展、安全且合規的 MCP 伺服器功能。Azure MCP 使組織能夠快速部署、管理和整合 MCP 伺服器與 Azure AI、數據和安全服務，減少運營負擔並加速 AI 的採用。

> **🎯 生產就緒工具**
> 
> 這是一個您今天就可以使用的真實 MCP 伺服器！了解更多關於 Azure AI Foundry MCP 伺服器的資訊，請參考我們的 [**Microsoft MCP 伺服器指南**](microsoft-mcp-servers.md)。

- 完全托管的 MCP 伺服器託管，內建擴展、監控和安全功能
- 與 Azure OpenAI、Azure AI Search 和其他 Azure 服務的原生整合
- 通過 Microsoft Entra ID 提供企業級身份驗證和授權
- 支援自定義工具、提示模板和資源連接器
- 符合企業安全和監管要求

**技術實施：**

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

**結果：**  
- 通過提供即用型、合規的 MCP 伺服器平台，縮短企業 AI 項目的價值實現時間
- 簡化 LLM、工具和企業數據源的整合
- 增強 MCP 工作負載的安全性、可觀察性和運營效率
- 使用 Azure SDK 最佳實踐和當前身份驗證模式改進代碼質量

**參考資料：**  
- [Azure MCP 文件](https://aka.ms/azmcp)  
- [Azure MCP 伺服器 GitHub 儲存庫](https://github.com/Azure/azure-mcp)  
- [Azure AI 服務](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 6：NLWeb

MCP (Model Context Protocol) 是一個新興的協議，用於讓聊天機器人和 AI 助手與工具互動。每個 NLWeb 實例也是一個 MCP 伺服器，支援一個核心方法 `ask`，用於以自然語言向網站提問。返回的回應利用了 schema.org，一個廣泛使用的網頁數據描述詞彙。簡單來說，MCP 對 NLWeb 的關係就像 Http 對 HTML 的關係。NLWeb 結合了協議、Schema.org 格式和示例代碼，幫助網站快速創建這些端點，既能讓人類通過對話介面受益，也能讓機器通過自然的代理對代理互動受益。

NLWeb 有兩個主要組成部分：
- 一個非常簡單的協議，用於以自然語言與網站介面互動，以及一個格式，利用 json 和 schema.org 返回答案。詳情請參考 REST API 文件。
- 一個簡單的實現，利用現有的標記，適用於可以抽象為項目列表（產品、食譜、景點、評論等）的網站。結合一組用戶介面小工具，網站可以輕鬆為其內容提供對話介面。詳情請參考 "Life of a chat query" 文件。

**參考資料：**  
- [Azure MCP 文件](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 案例研究 7：Azure AI Foundry MCP 伺服器 – 企業 AI 代理整合

Azure AI Foundry MCP 伺服器展示了 MCP 如何用於在企業環境中協調和管理 AI 代理及工作流程。通過將 MCP 與 Azure AI Foundry 整合，組織可以標準化代理互動，利用 Foundry 的工作流程管理，並確保安全、可擴展的部署。

> **🎯 生產就緒工具**
> 
> 這是一個您今天就可以使用的真實 MCP 伺服器！了解更多關於 Azure AI Foundry MCP 伺服器的資訊，請參考我們的 [**Microsoft MCP 伺服器指南**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server)。

**主要功能：**
- 全面訪問 Azure 的 AI 生態系統，包括模型目錄和部署管理
- 使用 Azure AI Search 進行 RAG 應用的知識索引
- 用於 AI 模型性能和質量保證的評估工具
- 與 Azure AI Foundry Catalog 和 Labs 整合，用於尖端研究模型
- 用於生產場景的代理管理和評估功能

**結果：**
- 快速原型設計和 AI 代理工作流程的強大監控
- 與 Azure AI 服務無縫整合，用於高級場景
- 為構建、部署和監控代理管道提供統一介面
- 提高企業的安全性、合規性和運營效率
- 加速 AI 採用，同時保持對複雜代理驅動流程的控制

**參考資料：**
- [Azure AI Foundry MCP 伺服器 GitHub 儲存庫](https://github.com/azure-ai-foundry/mcp-foundry)  
- [整合 Azure AI 代理與 MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground – 實驗與原型設計

Foundry MCP Playground 提供了一個即用型環境，用於實驗 MCP 伺服器和 Azure AI Foundry 整合。開發者可以快速原型設計、測試和評估 AI 模型及代理工作流程，使用來自 Azure AI Foundry Catalog 和 Labs 的資源。Playground 簡化了設置，提供示例項目，並支援協作開發，使團隊能夠以最小的負擔探索最佳實踐和新場景。通過降低進入門檻，Playground 幫助推動 MCP 和 Azure AI Foundry 生態系統中的創新和社群貢獻。

**參考資料：**

- [Foundry MCP Playground GitHub 儲存庫](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 案例研究 9：Microsoft Learn Docs MCP 伺服器 – AI 驅動的文件存取

Microsoft Learn Docs MCP 伺服器是一個雲端託管服務，透過 Model Context Protocol 為 AI 助手提供即時存取官方 Microsoft 文件的功能。這個生產就緒的伺服器連接到全面的 Microsoft Learn 生態系統，並實現跨所有官方 Microsoft 資源的語義搜索。
> **🎯 適用於生產環境的工具**  
>  
> 這是一個你今天就可以使用的真正 MCP 伺服器！想了解更多有關 Microsoft Learn Docs MCP 伺服器的資訊，請參閱我們的[**Microsoft MCP 伺服器指南**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server)。
**主要功能：**
- 即時存取官方 Microsoft 文件、Azure 文件及 Microsoft 365 文件
- 高級語義搜尋功能，能理解上下文及意圖
- 隨 Microsoft Learn 內容發布而保持最新資訊
- 全面覆蓋 Microsoft Learn、Azure 文件及 Microsoft 365 資源
- 提供最多 10 個高質量內容片段，附文章標題及 URL

**為何至關重要：**
- 解決 Microsoft 技術中「過時 AI 知識」的問題
- 確保 AI 助手能存取最新的 .NET、C#、Azure 及 Microsoft 365 功能
- 提供權威的一手資訊以生成準確的程式碼
- 對於使用快速演進的 Microsoft 技術的開發者至關重要

**成果：**
- 顯著提升 AI 生成 Microsoft 技術程式碼的準確性
- 減少搜尋最新文件及最佳實踐所花費的時間
- 通過上下文感知的文件檢索提升開發者生產力
- 無需離開 IDE，即可與開發工作流程無縫整合

**參考資料：**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## 實作項目

### 項目 1：建立多供應商 MCP 伺服器

**目標：** 建立一個 MCP 伺服器，能根據特定條件將請求路由至多個 AI 模型供應商。

**需求：**

- 支援至少三個不同的模型供應商（例如 OpenAI、Anthropic、本地模型）
- 根據請求元數據實現路由機制
- 建立管理供應商憑證的配置系統
- 添加緩存以優化性能及成本
- 建立簡單的儀表板以監控使用情況

**實作步驟：**

1. 設置基本 MCP 伺服器基礎架構
2. 為每個 AI 模型服務實現供應商適配器
3. 根據請求屬性創建路由邏輯
4. 添加頻繁請求的緩存機制
5. 開發監控儀表板
6. 使用各種請求模式進行測試

**技術選擇：** 可選 Python（基於 .NET/Java/Python 的偏好），Redis 作為緩存，及簡單的網頁框架用於儀表板。

### 項目 2：企業提示管理系統

**目標：** 開發基於 MCP 的系統，用於管理、版本控制及部署提示模板於整個組織。

**需求：**

- 建立提示模板的集中式存儲庫
- 實現版本控制及審批工作流程
- 建立使用樣本輸入的模板測試功能
- 開發基於角色的訪問控制
- 創建用於模板檢索及部署的 API

**實作步驟：**

1. 設計模板存儲的數據庫架構
2. 創建模板 CRUD 操作的核心 API
3. 實現版本控制系統
4. 建立審批工作流程
5. 開發測試框架
6. 創建簡單的網頁界面進行管理
7. 與 MCP 伺服器集成

**技術選擇：** 可選後端框架、SQL 或 NoSQL 數據庫，以及前端框架用於管理界面。

### 項目 3：基於 MCP 的內容生成平台

**目標：** 建立一個內容生成平台，利用 MCP 提供不同內容類型的一致結果。

**需求：**

- 支援多種內容格式（博客文章、社交媒體、行銷文案）
- 實現基於模板的生成及自定義選項
- 建立內容審查及反饋系統
- 跟蹤內容性能指標
- 支援內容版本控制及迭代

**實作步驟：**

1. 設置 MCP 客戶端基礎架構
2. 為不同內容類型創建模板
3. 建立內容生成管道
4. 實現審查系統
5. 開發性能指標跟蹤系統
6. 創建用於模板管理及內容生成的用戶界面

**技術選擇：** 可選編程語言、網頁框架及數據庫系統。

## MCP 技術的未來方向

### 新興趨勢

1. **多模態 MCP**
   - 擴展 MCP 標準化與圖像、音頻及視頻模型的交互
   - 開發跨模態推理能力
   - 為不同模態建立標準化提示格式

2. **聯邦 MCP 基礎架構**
   - 分布式 MCP 網絡，可在組織間共享資源
   - 安全模型共享的標準化協議
   - 隱私保護計算技術

3. **MCP 市場**
   - 用於共享及貨幣化 MCP 模板及插件的生態系統
   - 質量保證及認證流程
   - 與模型市場集成

4. **MCP 用於邊緣計算**
   - 為資源受限的邊緣設備適配 MCP 標準
   - 為低帶寬環境優化協議
   - 專門為物聯網生態系統設計的 MCP 實現

5. **監管框架**
   - 開發 MCP 擴展以符合監管要求
   - 標準化審計追蹤及可解釋性界面
   - 與新興 AI 治理框架集成

### Microsoft 的 MCP 解決方案

Microsoft 及 Azure 已開發多個開源存儲庫，幫助開發者在不同場景中實現 MCP：

#### Microsoft 組織

1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用於瀏覽器自動化及測試的 Playwright MCP 伺服器
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - 用於本地測試及社群貢獻的 OneDrive MCP 伺服器實現
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb 是一套開放協議及相關開源工具，主要聚焦於建立 AI Web 的基礎層

#### Azure-Samples 組織

1. [mcp](https://github.com/Azure-Samples/mcp) - 提供樣本、工具及資源，用於在 Azure 上使用多種語言構建及集成 MCP 伺服器
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 展示使用當前 Model Context Protocol 規範進行身份驗證的參考 MCP 伺服器
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - 使用 Azure Functions 實現的遠程 MCP 伺服器的登陸頁，附語言特定存儲庫的鏈接
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Azure Functions 及 Python 構建及部署自定義遠程 MCP 伺服器的快速入門模板
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 Azure Functions 及 .NET/C# 構建及部署自定義遠程 MCP 伺服器的快速入門模板
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Azure Functions 及 TypeScript 構建及部署自定義遠程 MCP 伺服器的快速入門模板
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 使用 Python 的 Azure API Management 作為遠程 MCP 伺服器的 AI Gateway
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI 實驗，包括 MCP 功能，與 Azure OpenAI 及 AI Foundry 集成

這些存儲庫提供了多種實現、模板及資源，用於在不同編程語言及 Azure 服務中使用 Model Context Protocol。它們涵蓋了從基本伺服器實現到身份驗證、雲端部署及企業集成場景的多種用例。

#### MCP 資源目錄

官方 Microsoft MCP 存儲庫中的 [MCP Resources 目錄](https://github.com/microsoft/mcp/tree/main/Resources) 提供了一套精選的樣本資源、提示模板及工具定義，用於 Model Context Protocol 伺服器。此目錄旨在幫助開發者快速入門 MCP，提供可重用的構建模塊及最佳實踐示例：

- **提示模板：** 用於常見 AI 任務及場景的即用型提示模板，可根據自己的 MCP 伺服器實現進行調整。
- **工具定義：** 標準化工具集成及調用的示例工具架構及元數據。
- **資源樣本：** 用於在 MCP 框架中連接數據源、API 及外部服務的示例資源定義。
- **參考實現：** 展示如何在實際 MCP 項目中結構化及組織資源、提示及工具的實用樣本。

這些資源加速開發，促進標準化，並幫助在構建及部署基於 MCP 的解決方案時遵循最佳實踐。

#### MCP 資源目錄

- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### 研究機會

- MCP 框架內的高效提示優化技術
- 多租戶 MCP 部署的安全模型
- 不同 MCP 實現的性能基準測試
- MCP 伺服器的形式化驗證方法

## 結論

Model Context Protocol (MCP) 正在快速塑造跨行業標準化、安全及可互操作的 AI 集成的未來。通過本課程中的案例研究及實作項目，你已看到早期採用者（包括 Microsoft 及 Azure）如何利用 MCP 解決實際挑戰，加速 AI 採用，並確保合規性、安全性及可擴展性。MCP 的模塊化方法使組織能在統一、可審計的框架中連接大型語言模型、工具及企業數據。隨著 MCP 的不斷發展，保持與社群的互動、探索開源資源及應用最佳實踐將是構建穩健、面向未來的 AI 解決方案的關鍵。

## 附加資源

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

## 練習

1. 分析其中一個案例研究，並提出替代的實現方法。
2. 選擇其中一個項目想法，並創建詳細的技術規範。
3. 研究案例研究中未涵蓋的行業，並概述 MCP 如何解決其特定挑戰。
4. 探索其中一個未來方向，並創建支持該方向的新 MCP 擴展概念。

下一步：[Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**免責聲明**：  
本文件已使用人工智能翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要信息，建議使用專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或錯誤解釋概不負責。