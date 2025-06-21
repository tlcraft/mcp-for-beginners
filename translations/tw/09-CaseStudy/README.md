<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:39:59+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tw"
}
-->
# MCP 實戰：真實案例研究

Model Context Protocol（MCP）正在改變 AI 應用與資料、工具及服務的互動方式。本節將展示多個真實案例，說明 MCP 在各種企業場景中的實際應用。

## 概述

本節展示具體的 MCP 實作範例，強調組織如何運用此協定解決複雜的商業挑戰。透過這些案例研究，您將深入了解 MCP 在真實場景中的多樣性、擴展性及實用優勢。

## 主要學習目標

透過探索這些案例，您將能：

- 理解 MCP 如何應用於解決特定商業問題
- 學習不同的整合模式與架構方法
- 認識企業環境中實施 MCP 的最佳實務
- 掌握真實應用中遇到的挑戰與解決方案
- 發掘在自身專案中運用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理 – 參考實作](./travelagentsample.md)

本案例探討微軟的完整參考方案，展示如何利用 MCP、Azure OpenAI 及 Azure AI Search 建立多代理的 AI 旅遊規劃應用。專案重點包括：

- 透過 MCP 進行多代理協調
- 與 Azure AI Search 整合企業資料
- 利用 Azure 服務打造安全且具擴展性的架構
- 使用可重複利用的 MCP 元件擴充工具功能
- 由 Azure OpenAI 支援的對話式使用者體驗

架構與實作細節提供了寶貴的見解，說明如何以 MCP 作為協調層構建複雜的多代理系統。

### 2. [從 YouTube 資料更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

本案例展示 MCP 在自動化工作流程中的實務應用，說明如何使用 MCP 工具來：

- 從線上平台（YouTube）擷取資料
- 更新 Azure DevOps 系統中的工作項目
- 建立可重複執行的自動化流程
- 跨異質系統整合資料

此範例顯示即使是相對簡單的 MCP 實作，也能透過自動化例行任務及提升資料一致性，帶來顯著的效率提升。

### 3. [使用 MCP 即時擷取文件](./docs-mcp/README.md)

本案例引導您如何連接 Python 主控台客戶端至 MCP 伺服器，擷取並記錄即時且具上下文關聯的 Microsoft 文件。您將學到：

- 使用 Python 客戶端及官方 MCP SDK 連接 MCP 伺服器
- 透過串流 HTTP 客戶端高效擷取即時資料
- 呼叫伺服器上的文件工具，並將回應直接輸出至主控台
- 在終端機中整合最新 Microsoft 文件，無需離開工作環境

本章包含實作練習、最小可行程式碼範例及進階資源連結。請參閱完整章節與程式碼，了解 MCP 如何改變文件存取與開發者生產力，尤其是在主控台環境中。

### 4. [使用 MCP 的互動式學習計畫生成網頁應用](./docs-mcp/README.md)

本案例示範如何結合 Chainlit 與 Model Context Protocol（MCP）打造互動式網頁應用，為任意主題生成個人化學習計畫。使用者可指定主題（例如「AI-900 認證」）及學習週期（如 8 週），應用會提供逐週的推薦內容細分。Chainlit 提供對話式聊天介面，使體驗更具互動性與彈性。

- 由 Chainlit 驅動的對話式網頁應用
- 使用者自訂主題與時長的輸入提示
- 利用 MCP 提供逐週內容建議
- 在聊天介面中即時且具適應性的回應

此專案展示對話式 AI 與 MCP 如何結合，打造現代網頁環境中動態且以使用者為中心的教育工具。

### 5. [在 VS Code 中使用 MCP 伺服器實現編輯器內文件](./docs-mcp/README.md)

本案例說明如何利用 MCP 伺服器將 Microsoft Learn 文件直接帶入 VS Code 編輯環境，無需切換瀏覽器分頁！您將看到如何：

- 使用 MCP 面板或命令面板，在 VS Code 內即時搜尋及閱讀文件
- 直接在 README 或課程 Markdown 檔案中引用文件並插入連結
- 結合 GitHub Copilot 與 MCP，實現無縫的 AI 文件與程式碼工作流程
- 以即時反饋與 Microsoft 授權的準確性驗證並增強文件內容
- 將 MCP 整合至 GitHub 工作流程，持續進行文件驗證

實作內容包括：
- `.vscode/mcp.json` 範例設定，方便快速部署
- 以截圖說明編輯器內使用體驗
- 結合 Copilot 與 MCP 的生產力提升秘訣

此場景特別適合課程作者、文件撰寫者及開發者，讓他們能專注於編輯器內，同時操作文件、Copilot 及驗證工具，皆由 MCP 支援。

## 結語

這些案例凸顯 Model Context Protocol 在真實場景中的多元應用與實務價值。從複雜的多代理系統到針對性自動化工作流程，MCP 提供了一種標準化的方式，連結 AI 系統與所需工具及資料，創造價值。

透過學習這些實作，您能掌握架構模式、實作策略與最佳實務，應用於自己的 MCP 專案。這些範例證明 MCP 不僅是理論框架，更是解決實際商業挑戰的實用方案。

## 其他資源

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。本公司不對因使用本翻譯所產生之任何誤解或誤譯負責。