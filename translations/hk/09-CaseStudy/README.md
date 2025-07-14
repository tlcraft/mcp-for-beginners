<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:42:23+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hk"
}
-->
# MCP 實戰：真實案例研究

Model Context Protocol (MCP) 正在改變 AI 應用程式與數據、工具及服務的互動方式。本節將展示多個真實案例，說明 MCP 在不同企業場景中的實際應用。

## 概覽

本節展示 MCP 實作的具體範例，突顯各組織如何利用此協議解決複雜的商業挑戰。透過這些案例研究，你將深入了解 MCP 在現實場景中的多樣性、可擴展性及實用價值。

## 主要學習目標

透過探索這些案例，你將能夠：

- 了解 MCP 如何應用於解決特定商業問題
- 學習不同的整合模式與架構方法
- 掌握在企業環境中實施 MCP 的最佳實踐
- 瞭解真實實作中遇到的挑戰與解決方案
- 發掘在自身專案中應用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理 – 參考實作](./travelagentsample.md)

本案例探討微軟的完整參考解決方案，展示如何利用 MCP、Azure OpenAI 及 Azure AI Search 建構多代理、AI 驅動的旅遊規劃應用。專案重點包括：

- 透過 MCP 進行多代理協調
- 與 Azure AI Search 整合企業數據
- 使用 Azure 服務打造安全且可擴展的架構
- 利用可重用的 MCP 元件擴充工具功能
- 由 Azure OpenAI 支援的對話式使用者體驗

架構與實作細節提供了寶貴的見解，說明如何以 MCP 作為協調層建構複雜的多代理系統。

### 2. [從 YouTube 資料更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

此案例展示 MCP 在自動化工作流程中的實際應用，說明如何利用 MCP 工具：

- 從線上平台（YouTube）擷取資料
- 更新 Azure DevOps 系統中的工作項目
- 建立可重複使用的自動化流程
- 整合跨系統的資料

此範例說明即使是相對簡單的 MCP 實作，也能透過自動化例行任務及提升系統間資料一致性，帶來顯著的效率提升。

### 3. [使用 MCP 即時文件檢索](./docs-mcp/README.md)

本案例引導你如何連接 Python 主控台客戶端至 Model Context Protocol (MCP) 伺服器，以檢索並記錄即時且具上下文感知的 Microsoft 文件。你將學習如何：

- 使用 Python 客戶端及官方 MCP SDK 連接 MCP 伺服器
- 利用串流 HTTP 客戶端高效取得即時資料
- 呼叫伺服器上的文件工具並直接將回應記錄至主控台
- 在不離開終端機的情況下，將最新 Microsoft 文件整合至工作流程

本章包含實作練習、最小可用程式碼範例及進階資源連結。請參閱連結章節的完整教學與程式碼，了解 MCP 如何改變基於主控台環境的文件存取與開發者生產力。

### 4. [使用 MCP 的互動式學習計劃產生器網頁應用](./docs-mcp/README.md)

本案例展示如何利用 Chainlit 與 Model Context Protocol (MCP) 建立互動式網頁應用，為任意主題生成個人化學習計劃。使用者可指定主題（如「AI-900 認證」）及學習時長（例如 8 週），應用程式將提供逐週的推薦內容。Chainlit 創造對話式聊天介面，使體驗更具互動性與適應性。

- 由 Chainlit 支援的對話式網頁應用
- 使用者主導的主題與時長輸入
- 透過 MCP 提供逐週內容推薦
- 聊天介面中即時且具適應性的回應

此專案展示如何結合對話式 AI 與 MCP，打造現代網頁環境中動態且以使用者為中心的教育工具。

### 5. [在 VS Code 編輯器中使用 MCP 伺服器的文件](./docs-mcp/README.md)

本案例展示如何利用 MCP 伺服器將 Microsoft Learn 文件直接帶入 VS Code 環境，免去切換瀏覽器分頁的麻煩！你將看到如何：

- 使用 MCP 面板或命令面板，在 VS Code 內即時搜尋與閱讀文件
- 直接在 README 或課程 Markdown 檔案中引用文件並插入連結
- 結合 GitHub Copilot 與 MCP，實現無縫的 AI 文件與程式碼工作流程
- 透過即時回饋與 Microsoft 來源的準確性，驗證並強化文件內容
- 將 MCP 整合至 GitHub 工作流程，持續驗證文件品質

實作內容包括：
- 範例 `.vscode/mcp.json` 配置，方便快速設定
- 以截圖說明編輯器內的使用體驗
- 結合 Copilot 與 MCP 的生產力提升技巧

此場景非常適合課程作者、文件撰寫者及開發者，讓他們在編輯器中專注工作，同時使用文件、Copilot 及驗證工具，全部由 MCP 驅動。

### 6. [APIM MCP 伺服器建立](./apimsample.md)

本案例提供如何使用 Azure API Management (APIM) 建立 MCP 伺服器的逐步指南，涵蓋：

- 在 Azure API Management 中設定 MCP 伺服器
- 將 API 操作暴露為 MCP 工具
- 配置速率限制與安全性政策
- 使用 Visual Studio Code 與 GitHub Copilot 測試 MCP 伺服器

此範例說明如何利用 Azure 的功能打造強健的 MCP 伺服器，促進 AI 系統與企業 API 的整合。

## 結語

這些案例突顯了 Model Context Protocol 在真實場景中的多樣性與實用性。從複雜的多代理系統到針對性自動化工作流程，MCP 提供了一種標準化方式，連結 AI 系統與所需的工具及數據，創造價值。

透過研究這些實作，你可以獲得架構模式、實施策略及最佳實踐的寶貴見解，並應用於自己的 MCP 專案。這些範例證明 MCP 不僅是理論框架，更是解決實際商業挑戰的實用方案。

## 其他資源

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

下一步：實作實驗室 [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。