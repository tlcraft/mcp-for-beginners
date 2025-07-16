<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "77bfab7090f987a5b9fe078f50dbda13",
  "translation_date": "2025-07-16T21:10:15+00:00",
  "source_file": "study_guide.md",
  "language_code": "hk"
}
-->
# Model Context Protocol (MCP) 初學者學習指南

本學習指南概述了「Model Context Protocol (MCP) 初學者」課程的倉庫結構與內容。請利用本指南有效瀏覽倉庫，充分發揮資源的價值。

## 倉庫概覽

Model Context Protocol (MCP) 是一套標準化框架，用於 AI 模型與客戶端應用程式之間的互動。MCP 最初由 Anthropic 創建，現由更廣泛的 MCP 社群透過官方 GitHub 組織維護。本倉庫提供完整課程，包含 C#、Java、JavaScript、Python 及 TypeScript 的實作範例，適合 AI 開發者、系統架構師及軟件工程師使用。

## 視覺化課程地圖

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization)
      (Use Cases)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
    02. Security
      ::icon(fa fa-shield)
      (Threat Models)
      (Best Practices)
      (Auth Strategies)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server)
      (Client)
      (LLM Client)
      (VS Code Integration)
      (SSE Server)
      (HTTP Streaming)
      (AI Toolkit)
      (Testing)
      (Deployment)
    04. Practical Implementation
      ::icon(fa fa-code)
      (SDKs)
      (Testing/Debugging)
      (Prompt Templates)
      (Sample Projects)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Integration)
      (Multi-modal AI)
      (OAuth2 Demo)
      (Real-time Search)
      (Streaming)
      (Root Contexts)
      (Routing)
      (Sampling)
      (Scaling)
      (Security)
      (Entra ID)
      (Web Search)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Clients)
      (MCP Servers)
      (Image Generation)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Real-world Examples)
      (Deployment Stories)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance)
      (Fault Tolerance)
      (Resilience)
    09. Case Studies
      ::icon(fa fa-file-text)
      (API Management)
      (Travel Agent)
      (Azure DevOps)
      (Documentation MCP)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (AI Toolkit Integration)
      (Custom Server Development)
      (Production Deployment)
```

## 倉庫結構

倉庫分為十個主要章節，各自聚焦 MCP 的不同面向：

1. **Introduction (00-Introduction/)**
   - Model Context Protocol 概述
   - 為何 AI 流程中標準化至關重要
   - 實際應用案例與效益

2. **Core Concepts (01-CoreConcepts/)**
   - 客戶端-伺服器架構
   - 主要協議元件
   - MCP 中的訊息傳遞模式

3. **Security (02-Security/)**
   - MCP 系統中的安全威脅
   - 安全實作最佳做法
   - 認證與授權策略

4. **Getting Started (03-GettingStarted/)**
   - 環境設定與配置
   - 建立基本 MCP 伺服器與客戶端
   - 與現有應用整合
   - 包含以下章節：
     - 首個伺服器實作
     - 客戶端開發
     - LLM 客戶端整合
     - VS Code 整合
     - Server-Sent Events (SSE) 伺服器
     - HTTP 串流
     - AI 工具包整合
     - 測試策略
     - 部署指引

5. **Practical Implementation (04-PracticalImplementation/)**
   - 跨語言 SDK 使用
   - 除錯、測試與驗證技巧
   - 製作可重用的提示模板與工作流程
   - 範例專案與實作示範

6. **Advanced Topics (05-AdvancedTopics/)**
   - 上下文工程技術
   - Foundry 代理整合
   - 多模態 AI 工作流程
   - OAuth2 認證示範
   - 即時搜尋功能
   - 即時串流
   - Root contexts 實作
   - 路由策略
   - 取樣技術
   - 擴展方法
   - 安全性考量
   - Entra ID 安全整合
   - 網路搜尋整合

7. **Community Contributions (06-CommunityContributions/)**
   - 如何貢獻程式碼與文件
   - 透過 GitHub 協作
   - 社群驅動的改進與回饋
   - 使用多種 MCP 客戶端（Claude Desktop、Cline、VSCode）
   - 使用熱門 MCP 伺服器，包括影像生成

8. **Lessons from Early Adoption (07-LessonsfromEarlyAdoption/)**
   - 實際案例與成功故事
   - 建置與部署 MCP 解決方案
   - 趨勢與未來發展路線圖

9. **Best Practices (08-BestPractices/)**
   - 效能調校與優化
   - 設計容錯的 MCP 系統
   - 測試與韌性策略

10. **Case Studies (09-CaseStudy/)**
    - 案例研究：Azure API Management 整合
    - 案例研究：旅遊代理實作
    - 案例研究：Azure DevOps 與 YouTube 整合
    - 詳細文件的實作範例

11. **Hands-on Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - 結合 MCP 與 AI 工具包的完整實作工作坊
    - 建立連結 AI 模型與實務工具的智慧應用
    - 涵蓋基礎、客製伺服器開發與生產部署策略的實務模組
    - 以實驗室方式學習，附逐步指引

## 附加資源

倉庫包含以下輔助資源：

- **Images 資料夾**：課程中使用的圖表與插圖
- **翻譯**：多語言支援，包含文件的自動翻譯
- **官方 MCP 資源**：
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## 如何使用本倉庫

1. **循序學習**：依章節順序（00 至 10）學習，建立系統性知識。
2. **語言專注**：若偏好特定程式語言，可瀏覽對應語言的範例目錄。
3. **實務入門**：從「Getting Started」章節開始，設定環境並建立首個 MCP 伺服器與客戶端。
4. **進階探索**：熟悉基礎後，深入進階主題擴展知識。
5. **社群互動**：透過 GitHub 討論與 Discord 頻道加入 MCP 社群，與專家及開發者交流。

## MCP 客戶端與工具

課程涵蓋多種 MCP 客戶端與工具：

1. **官方客戶端**：
   - Claude Desktop
   - VSCode 內的 Claude
   - Claude API

2. **社群客戶端**：
   - Cline（終端機介面）
   - Cursor（程式碼編輯器）
   - ChatMCP
   - Windsurf

3. **MCP 管理工具**：
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## 熱門 MCP 伺服器

倉庫介紹多款 MCP 伺服器，包括：

1. **官方參考伺服器**：
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

2. **影像生成**：
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

3. **開發工具**：
   - Git MCP
   - Terminal Control
   - Code Assistant

4. **專用伺服器**：
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## 貢獻指南

本倉庫歡迎社群貢獻。請參考 Community Contributions 章節，了解如何有效參與 MCP 生態系統的建設。

## 更新紀錄

| 日期 | 變更內容 |
|------|---------|
| 2025 年 7 月 16 日 | - 更新倉庫結構以反映最新內容<br>- 新增 MCP 客戶端與工具章節<br>- 新增熱門 MCP 伺服器章節<br>- 更新視覺化課程地圖，涵蓋所有現有主題<br>- 強化進階主題章節，包含所有專業領域<br>- 更新案例研究，反映實際範例<br>- 明確標示 MCP 由 Anthropic 創建 |
| 2025 年 6 月 11 日 | - 初版學習指南建立<br>- 新增視覺化課程地圖<br>- 概述倉庫結構<br>- 包含範例專案與附加資源 |

---

*本學習指南於 2025 年 7 月 16 日更新，內容反映該日期的倉庫狀態。倉庫內容可能於此後持續更新。*

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。