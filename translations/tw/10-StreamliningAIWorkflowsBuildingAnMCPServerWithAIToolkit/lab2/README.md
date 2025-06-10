<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a22b7dd11cd7690f99f9195877cafdc3",
  "translation_date": "2025-06-10T05:40:21+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab2/README.md",
  "language_code": "tw"
}
-->
# 🌐 Module 2: MCP 與 AI Toolkit 基礎

[![Duration](https://img.shields.io/badge/Duration-20%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-yellow.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-Module%201%20Complete-orange.svg)]()

## 📋 學習目標

完成本模組後，你將能夠：
- ✅ 了解 Model Context Protocol (MCP) 的架構與優勢
- ✅ 探索 Microsoft 的 MCP 伺服器生態系
- ✅ 將 MCP 伺服器整合到 AI Toolkit Agent Builder
- ✅ 使用 Playwright MCP 建立功能完整的瀏覽器自動化代理
- ✅ 配置並測試代理中的 MCP 工具
- ✅ 匯出並部署具 MCP 功能的代理到生產環境

## 🎯 以 Module 1 為基礎

在 Module 1，我們掌握了 AI Toolkit 的基礎，並建立了第一個 Python 代理。現在，我們要透過革命性的 **Model Context Protocol (MCP)**，讓你的代理更強大，連接外部工具和服務。

想像從簡單計算機升級成完整電腦，你的 AI 代理將能夠：
- 🌐 瀏覽並操作網站
- 📁 存取與管理檔案
- 🔧 整合企業系統
- 📊 處理來自 API 的即時資料

## 🧠 了解 Model Context Protocol (MCP)

### 🔍 MCP 是什麼？

Model Context Protocol (MCP) 是 AI 應用的 **「USB-C」** — 一個革命性的開放標準，連結大型語言模型（LLM）與外部工具、資料來源及服務。就像 USB-C 統一了連接埠，MCP 也用一套標準協定簡化了 AI 的整合複雜度。

### 🎯 MCP 解決了什麼問題

**MCP 出現前：**
- 🔧 每個工具都需自訂整合
- 🔄 被廠商綁定，無法自由切換
- 🔒 臨時連接帶來安全風險
- ⏱️ 基本整合需要數月開發

**有了 MCP：**
- ⚡ 即插即用的工具整合
- 🔄 廠商中立的架構
- 🛡️ 內建安全最佳實踐
- 🚀 幾分鐘就能新增功能

### 🏗️ MCP 架構深入

MCP 採用 **客戶端-伺服器架構**，建立安全且可擴展的生態系：

```mermaid
graph TB
    A[AI Application/Agent] --> B[MCP Client]
    B --> C[MCP Server 1: Files]
    B --> D[MCP Server 2: Web APIs]
    B --> E[MCP Server 3: Database]
    B --> F[MCP Server N: Custom Tools]
    
    C --> G[Local File System]
    D --> H[External APIs]
    E --> I[Database Systems]
    F --> J[Enterprise Systems]
```

**🔧 核心元件：**

| 元件 | 角色 | 範例 |
|-----------|------|----------|
| **MCP Hosts** | 使用 MCP 服務的應用程式 | Claude Desktop、VS Code、AI Toolkit |
| **MCP Clients** | 協定處理器（與伺服器一對一） | 內建於 Host 應用中 |
| **MCP Servers** | 透過標準協定提供功能 | Playwright、Files、Azure、GitHub |
| **傳輸層** | 通訊方式 | stdio、HTTP、WebSockets |


## 🏢 Microsoft 的 MCP 伺服器生態系

Microsoft 領導 MCP 生態系，提供一套企業級伺服器，滿足真實商業需求。

### 🌟 特色 Microsoft MCP 伺服器

#### 1. ☁️ Azure MCP Server
**🔗 倉庫**: [azure/azure-mcp](https://github.com/azure/azure-mcp)  
**🎯 目的**: 結合 AI 的完整 Azure 資源管理

**✨ 主要功能：**
- 宣告式基礎架構佈建
- 即時資源監控
- 成本優化建議
- 安全合規檢查

**🚀 使用場景：**
- AI 輔助的基礎架構即程式碼
- 自動資源擴縮
- 雲端成本管理
- DevOps 工作流程自動化

#### 2. 📊 Microsoft Dataverse MCP
**📚 文件**: [Microsoft Dataverse Integration](https://go.microsoft.com/fwlink/?linkid=2320176)  
**🎯 目的**: 商業資料的自然語言介面

**✨ 主要功能：**
- 自然語言資料庫查詢
- 商業情境理解
- 自訂提示範本
- 企業資料治理

**🚀 使用場景：**
- 商業智慧報告
- 客戶資料分析
- 銷售管道洞察
- 合規資料查詢

#### 3. 🌐 Playwright MCP Server
**🔗 倉庫**: [microsoft/playwright-mcp](https://github.com/microsoft/playwright-mcp)  
**🎯 目的**: 瀏覽器自動化與網頁互動功能

**✨ 主要功能：**
- 跨瀏覽器自動化（Chrome、Firefox、Safari）
- 智慧元素偵測
- 截圖與 PDF 產生
- 網路流量監控

**🚀 使用場景：**
- 自動化測試流程
- 網頁爬蟲與資料擷取
- UI/UX 監控
- 競爭分析自動化

#### 4. 📁 Files MCP Server
**🔗 倉庫**: [microsoft/files-mcp-server](https://github.com/microsoft/files-mcp-server)  
**🎯 目的**: 智慧型檔案系統操作

**✨ 主要功能：**
- 宣告式檔案管理
- 內容同步
- 版本控制整合
- 元資料擷取

**🚀 使用場景：**
- 文件管理
- 程式碼倉庫組織
- 內容發佈工作流程
- 資料管線檔案處理

#### 5. 📝 MarkItDown MCP Server
**🔗 倉庫**: [microsoft/markitdown](https://github.com/microsoft/markitdown)  
**🎯 目的**: 進階 Markdown 處理與操作

**✨ 主要功能：**
- 強大的 Markdown 解析
- 格式轉換（MD ↔ HTML ↔ PDF）
- 內容結構分析
- 範本處理

**🚀 使用場景：**
- 技術文件工作流程
- 內容管理系統
- 報告生成
- 知識庫自動化

#### 6. 📈 Clarity MCP Server
**📦 套件**: [@microsoft/clarity-mcp-server](https://www.npmjs.com/package/@microsoft/clarity-mcp-server)  
**🎯 目的**: 網站分析與用戶行為洞察

**✨ 主要功能：**
- 熱點圖資料分析
- 用戶會話錄影
- 效能指標
- 轉換漏斗分析

**🚀 使用場景：**
- 網站優化
- 用戶體驗研究
- A/B 測試分析
- 商業智慧儀表板

### 🌍 社群生態系

除了 Microsoft 的伺服器外，MCP 生態系還包括：
- **🐙 GitHub MCP**：倉庫管理與程式碼分析
- **🗄️ 資料庫 MCP**：PostgreSQL、MySQL、MongoDB 整合
- **☁️ 雲端服務 MCP**：AWS、GCP、Digital Ocean 工具
- **📧 通訊 MCP**：Slack、Teams、Email 整合

## 🛠️ 實作實驗：打造瀏覽器自動化代理

**🎯 專案目標**：利用 Playwright MCP 伺服器，建立能瀏覽網站、擷取資訊並執行複雜網頁互動的智慧瀏覽器自動化代理。

### 🚀 階段 1：代理基礎設定

#### 步驟 1：初始化你的代理
1. **開啟 AI Toolkit Agent Builder**
2. **建立新代理**，設定如下：
   - **名稱**：`BrowserAgent`
   - **Model**: Choose GPT-4o 

![BrowserAgent](../../../../translated_images/BrowserAgent.09c1adde5e136573b64ab1baecd830049830e295eac66cb18bebb85fb386e00a.tw.png)


### 🔧 Phase 2: MCP Integration Workflow

#### Step 3: Add MCP Server Integration
1. **Navigate to Tools Section** in Agent Builder
2. **Click "Add Tool"** to open the integration menu
3. **Select "MCP Server"** from available options

![AddMCP](../../../../translated_images/AddMCP.afe3308ac20aa94469a5717b632d77b2197b9838a438b05d39aeb2db3ec47ef1.tw.png)

**🔍 Understanding Tool Types:**
- **Built-in Tools**: Pre-configured AI Toolkit functions
- **MCP Servers**: External service integrations
- **Custom APIs**: Your own service endpoints
- **Function Calling**: Direct model function access

#### Step 4: MCP Server Selection
1. **Choose "MCP Server"** option to proceed
![AddMCPServer](../../../../translated_images/AddMCPServer.69b911ccef872cbd0d0c0c2e6a00806916e1673e543b902a23dee23e6ff54b4c.tw.png)

2. **Browse MCP Catalog** to explore available integrations
![MCPCatalog](../../../../translated_images/MCPCatalog.a817d053145699006264f5a475f2b48fbd744e43633f656b6453c15a09ba5130.tw.png)


### 🎮 Phase 3: Playwright MCP Configuration

#### Step 5: Select and Configure Playwright
1. **Click "Use Featured MCP Servers"** to access Microsoft's verified servers
2. **Select "Playwright"** from the featured list
3. **Accept Default MCP ID** or customize for your environment

![MCPID](../../../../translated_images/MCPID.67d446052979e819c945ff7b6430196ef587f5217daadd3ca52fa9659c1245c9.tw.png)

#### Step 6: Enable Playwright Capabilities
**🔑 Critical Step**: Select **ALL** available Playwright methods for maximum functionality

![Tools](../../../../translated_images/Tools.3ea23c447b4d9feccbd7101e6dcf9e27cb0e5273f351995fde62c5abf9a78b4c.tw.png)

**🛠️ Essential Playwright Tools:**
- **Navigation**: `goto`, `goBack`, `goForward`, `reload`
- **Interaction**: `click`, `fill`, `press`, `hover`, `drag`
- **Extraction**: `textContent`, `innerHTML`, `getAttribute`
- **Validation**: `isVisible`, `isEnabled`, `waitForSelector`
- **Capture**: `screenshot`, `pdf`, `video`
- **Network**: `setExtraHTTPHeaders`, `route`, `waitForResponse`

#### 步驟 7：驗證整合成功
**✅ 成功指標：**
- 所有工具都出現在 Agent Builder 介面
- 整合面板無錯誤訊息
- Playwright 伺服器狀態顯示「Connected」

![AgentTools](../../../../translated_images/AgentTools.053cfb96a17e02199dcc6563010d2b324d4fc3ebdd24889657a6950647a52f63.tw.png)

**🔧 常見問題排解：**
- **連線失敗**：檢查網路連線與防火牆設定
- **缺少工具**：確認設定時已選取所有功能
- **權限錯誤**：確保 VS Code 擁有必要系統權限

### 🎯 階段 4：進階提示工程

#### 步驟 8：設計智慧系統提示
建立能充分利用 Playwright 功能的複雜提示：

```markdown
# Web Automation Expert System Prompt

## Core Identity
You are an advanced web automation specialist with deep expertise in browser automation, web scraping, and user experience analysis. You have access to Playwright tools for comprehensive browser control.

## Capabilities & Approach
### Navigation Strategy
- Always start with screenshots to understand page layout
- Use semantic selectors (text content, labels) when possible
- Implement wait strategies for dynamic content
- Handle single-page applications (SPAs) effectively

### Error Handling
- Retry failed operations with exponential backoff
- Provide clear error descriptions and solutions
- Suggest alternative approaches when primary methods fail
- Always capture diagnostic screenshots on errors

### Data Extraction
- Extract structured data in JSON format when possible
- Provide confidence scores for extracted information
- Validate data completeness and accuracy
- Handle pagination and infinite scroll scenarios

### Reporting
- Include step-by-step execution logs
- Provide before/after screenshots for verification
- Suggest optimizations and alternative approaches
- Document any limitations or edge cases encountered

## Ethical Guidelines
- Respect robots.txt and rate limiting
- Avoid overloading target servers
- Only extract publicly available information
- Follow website terms of service
```

#### 步驟 9：建立動態用戶提示
設計展示多種功能的提示範例：

**🌐 網頁分析示例：**
```markdown
Navigate to github.com/kinfey and provide a comprehensive analysis including:
1. Repository structure and organization
2. Recent activity and contribution patterns  
3. Documentation quality assessment
4. Technology stack identification
5. Community engagement metrics
6. Notable projects and their purposes

Include screenshots at key steps and provide actionable insights.
```

![Prompt](../../../../translated_images/Prompt.bfc846605db4999f4d9c1b09c710ef63cae7b3057444e68bf07240fb142d9f8f.tw.png)

### 🚀 階段 5：執行與測試

#### 步驟 10：執行你的第一個自動化流程
1. **點擊「Run」** 啟動自動化序列
2. **監控即時執行狀況**：
   - 自動啟動 Chrome 瀏覽器
   - 代理導覽至目標網站
   - 每個主要步驟截圖保存
   - 分析結果即時串流

![Browser](../../../../translated_images/Browser.ec011d0bd64d0d112c8a29bd8cc44c76d0bbfd0b019cb2983ef679328435ce5d.tw.png)

#### 步驟 11：分析結果與洞察
在 Agent Builder 介面檢視完整分析報告：

![Result](../../../../translated_images/Result.8638f2b6703e9ea6d58d4e4475e39456b6a51d4c787f9bf481bae694d370a69a.tw.png)

### 🌟 階段 6：進階功能與部署

#### 步驟 12：匯出與生產部署
Agent Builder 支援多種部署選項：

![Code](../../../../translated_images/Code.d9eeeead0b96db0ca19c5b10ad64cfea8c1d0d1736584262970a4d43e1403d13.tw.png)

## 🎓 Module 2 總結與後續步驟

### 🏆 成就解鎖：MCP 整合大師

**✅ 掌握技能：**
- [ ] 理解 MCP 架構與優勢
- [ ] 熟悉 Microsoft MCP 伺服器生態系
- [ ] 整合 Playwright MCP 與 AI Toolkit
- [ ] 建立高階瀏覽器自動化代理
- [ ] 進階網頁自動化提示工程

### 📚 延伸資源

- **🔗 MCP 規範**：[官方協定文件](https://modelcontextprotocol.io/)
- **🛠️ Playwright API**：[完整方法參考](https://playwright.dev/docs/api/class-playwright)
- **🏢 Microsoft MCP 伺服器**：[企業整合指南](https://github.com/microsoft/mcp-servers)
- **🌍 社群範例**：[MCP 伺服器展示](https://github.com/modelcontextprotocol/servers)

**🎉 恭喜你！** 已成功掌握 MCP 整合，現在能打造具備外部工具功能的生產級 AI 代理！

### 🔜 繼續下一模組

準備好提升你的 MCP 技能了嗎？前往 **[Module 3: Advanced MCP Development with AI Toolkit](../lab3/README.md)**，學習如何：
- 自行建立客製 MCP 伺服器
- 設定並使用最新 MCP Python SDK
- 使用 MCP Inspector 進行除錯
- 精通進階 MCP 伺服器開發流程
- 從零打造天氣 MCP 伺服器

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於翻譯準確，但請注意自動翻譯可能包含錯誤或不精確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。