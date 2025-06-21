<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:39:07+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hk"
}
-->
# MCP 實戰：真實案例研究

Model Context Protocol (MCP) 正在改變 AI 應用程式與資料、工具及服務互動的方式。本節將介紹多個真實案例，展示 MCP 在不同企業場景中的實際應用。

## 概覽

本節展示 MCP 實作的具體範例，強調組織如何利用此協議解決複雜的商業挑戰。透過這些案例，你將深入了解 MCP 在真實環境中的多功能性、可擴展性及實際效益。

## 主要學習目標

透過探索這些案例，你將能：

- 了解 MCP 如何應用於解決特定商業問題
- 學習不同的整合模式與架構方法
- 掌握在企業環境中實施 MCP 的最佳實踐
- 獲得真實實作中遇到的挑戰與解決方案的洞見
- 發掘在自身專案中應用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理 – 參考實作](./travelagentsample.md)

本案例探討微軟的完整參考解決方案，展示如何利用 MCP、Azure OpenAI 與 Azure AI Search 建置多代理、AI 驅動的旅遊規劃應用。專案特色包括：

- 透過 MCP 進行多代理協調
- 使用 Azure AI Search 整合企業資料
- 採用安全且可擴展的 Azure 架構
- 可擴充且重複利用的 MCP 元件工具
- 由 Azure OpenAI 支援的對話式使用者體驗

架構與實作細節提供了如何以 MCP 作為協調層建置複雜多代理系統的寶貴見解。

### 2. [從 YouTube 資料更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

本案例展示 MCP 在自動化工作流程中的實際應用。示範如何使用 MCP 工具：

- 從線上平台（YouTube）擷取資料
- 更新 Azure DevOps 系統中的工作項目
- 建立可重複使用的自動化工作流程
- 整合分散系統中的資料

此範例說明即使是相對簡單的 MCP 實作，也能透過自動化例行任務及提升跨系統資料一致性，帶來顯著的效率提升。

### 3. [利用 MCP 即時擷取文件](./docs-mcp/README.md)

本案例引導你如何連接 Python 主控台客戶端至 Model Context Protocol (MCP) 伺服器，以擷取並記錄即時、具情境感知的 Microsoft 文件。你將學會：

- 使用 Python 客戶端及官方 MCP SDK 連接 MCP 伺服器
- 利用串流 HTTP 客戶端高效擷取即時資料
- 呼叫伺服器上的文件工具並直接在主控台記錄回應
- 在不離開終端機的情況下，將最新 Microsoft 文件整合進工作流程

本章包含實作作業、最小可行代碼範例及進階學習資源連結。詳見連結章節的完整步驟與程式碼，了解 MCP 如何改變文件存取及提升主控台環境中的開發者生產力。

### 4. [使用 MCP 的互動式學習計劃生成器網頁應用](./docs-mcp/README.md)

本案例示範如何利用 Chainlit 與 Model Context Protocol (MCP) 建立互動式網頁應用，為任意主題生成個人化學習計劃。使用者可指定主題（如「AI-900 證照」）及學習時長（例如 8 週），應用會提供逐週推薦內容。Chainlit 創造對話式聊天介面，讓體驗更生動且具彈性。

- 由 Chainlit 支援的對話式網頁應用
- 使用者驅動的主題與時長輸入
- 利用 MCP 提供逐週內容推薦
- 聊天介面中即時且自適應的回應

此專案展示如何結合對話式 AI 與 MCP，打造現代網頁環境下動態且以使用者為中心的教育工具。

### 5. [VS Code 中的 MCP 伺服器內嵌文件](./docs-mcp/README.md)

本案例展示如何利用 MCP 伺服器將 Microsoft Learn 文件直接帶入 VS Code 環境，不需再切換瀏覽器分頁！你將看到如何：

- 透過 MCP 面板或指令面板，在 VS Code 內即時搜尋及閱讀文件
- 直接在 README 或課程 Markdown 檔案中參考文件並插入連結
- 結合 GitHub Copilot 與 MCP，實現無縫的 AI 驅動文件與程式碼工作流程
- 以即時回饋及 Microsoft 官方準確度驗證並強化文件
- 將 MCP 整合至 GitHub 工作流程，持續驗證文件品質

實作內容包括：
- 方便設定的 `.vscode/mcp.json` 範例配置
- 以截圖說明編輯器內體驗流程
- 結合 Copilot 與 MCP 以達最大生產力的技巧

此場景非常適合課程作者、文件撰寫者與開發者，讓他們在編輯器中專注工作，同時利用 MCP 支援的文件、Copilot 及驗證工具。

## 結語

這些案例突顯了 Model Context Protocol 在真實世界中多元且實用的應用。從複雜的多代理系統到針對性自動化工作流程，MCP 提供了一種標準化方式，將 AI 系統與所需工具和資料連結，創造價值。

透過研究這些實作，你可以獲得架構模式、實施策略與最佳實踐的寶貴經驗，並應用於自己的 MCP 專案中。這些範例證明 MCP 不僅是理論框架，更是解決真實商業挑戰的實用方案。

## 附加資源

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於提供準確的翻譯，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或錯誤詮釋承擔責任。