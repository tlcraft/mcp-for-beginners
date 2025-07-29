<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-07-28T23:35:49+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tw"
}
-->
# MCP 實踐：真實案例研究

[![MCP 實踐：真實案例研究](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.tw.png)](https://youtu.be/IxshWb2Az5w)

_（點擊上方圖片觀看本課程的影片）_

模型上下文協議（MCP）正在改變 AI 應用程式與數據、工具和服務互動的方式。本節將展示多個真實案例，說明 MCP 在各種企業場景中的實際應用。

## 概述

本節展示了 MCP 實施的具體範例，重點介紹各組織如何利用該協議解決複雜的業務挑戰。通過研究這些案例，您將深入了解 MCP 在真實場景中的多功能性、可擴展性和實際效益。

## 主要學習目標

通過探索這些案例，您將能夠：

- 理解 MCP 如何應用於解決特定業務問題
- 學習不同的整合模式和架構方法
- 掌握在企業環境中實施 MCP 的最佳實踐
- 獲得關於真實實施中遇到的挑戰和解決方案的見解
- 發掘在您自己的項目中應用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理 – 參考實現](./travelagentsample.md)

此案例研究探討了 Microsoft 的一個全面參考解決方案，展示如何使用 MCP、Azure OpenAI 和 Azure AI Search 構建多代理、AI 驅動的旅遊規劃應用程式。該項目展示了：

- 通過 MCP 實現多代理協作
- 與 Azure AI Search 的企業數據整合
- 使用 Azure 服務構建安全且可擴展的架構
- 可擴展的工具，包含可重用的 MCP 元件
- 由 Azure OpenAI 驅動的對話式用戶體驗

該架構和實施細節為構建以 MCP 作為協調層的複雜多代理系統提供了寶貴的見解。

### 2. [從 YouTube 數據更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

此案例研究展示了 MCP 在自動化工作流程中的實際應用。它說明了如何使用 MCP 工具來：

- 從線上平台（如 YouTube）提取數據
- 更新 Azure DevOps 系統中的工作項目
- 創建可重複的自動化工作流程
- 整合分散系統中的數據

該範例說明，即使是相對簡單的 MCP 實施，也能通過自動化日常任務和提高系統間數據一致性帶來顯著的效率提升。

### 3. [使用 MCP 實現即時文檔檢索](./docs-mcp/README.md)

此案例研究指導您如何將 Python 控制台客戶端連接到模型上下文協議（MCP）伺服器，以檢索並記錄即時、上下文相關的 Microsoft 文檔。您將學習如何：

- 使用 Python 客戶端和官方 MCP SDK 連接 MCP 伺服器
- 使用流式 HTTP 客戶端進行高效的即時數據檢索
- 調用伺服器上的文檔工具並將響應直接記錄到控制台
- 將最新的 Microsoft 文檔整合到您的工作流程中，而無需離開終端

該章節包括一個實作任務、一個最小可行的代碼範例，以及指向更多學習資源的鏈接。通過完整的操作指南和代碼，您將了解 MCP 如何改變文檔訪問和開發者生產力。

### 4. [使用 MCP 構建互動式學習計劃生成器 Web 應用](./docs-mcp/README.md)

此案例研究展示了如何使用 Chainlit 和模型上下文協議（MCP）構建一個互動式 Web 應用，生成針對任何主題的個性化學習計劃。用戶可以指定主題（例如 "AI-900 認證"）和學習時長（例如 8 週），應用程式將提供逐週的推薦內容。Chainlit 提供對話式聊天介面，使體驗更具互動性和適應性。

- 由 Chainlit 驅動的對話式 Web 應用
- 用戶驅動的主題和時長提示
- 使用 MCP 提供逐週內容推薦
- 在聊天介面中實現即時、適應性響應

該項目展示了如何將對話式 AI 和 MCP 結合起來，創建現代 Web 環境中的動態、用戶驅動的教育工具。

### 5. [在 VS Code 中使用 MCP 伺服器實現內嵌文檔](./docs-mcp/README.md)

此案例研究展示了如何將 Microsoft Learn 文檔直接引入 VS Code 環境中，無需切換瀏覽器標籤！您將學習如何：

- 使用 MCP 面板或命令面板在 VS Code 中即時搜索和閱讀文檔
- 在 README 或課程 Markdown 文件中直接引用文檔並插入鏈接
- 將 GitHub Copilot 和 MCP 結合使用，實現無縫的 AI 驅動文檔和代碼工作流程
- 通過即時反饋和 Microsoft 提供的準確性增強文檔
- 將 MCP 與 GitHub 工作流程整合，實現持續文檔驗證

實施內容包括：

- 範例 `.vscode/mcp.json` 配置，便於快速設置
- 基於截圖的內嵌體驗操作指南
- 結合 Copilot 和 MCP 的生產力提升技巧

此場景非常適合課程作者、文檔撰寫者和開發者，幫助他們在編輯器中專注於文檔、Copilot 和驗證工具的工作流程，所有這些都由 MCP 提供支持。

### 6. [APIM MCP 伺服器創建](./apimsample.md)

此案例研究提供了如何使用 Azure API 管理（APIM）創建 MCP 伺服器的分步指南。內容涵蓋：

- 在 Azure API 管理中設置 MCP 伺服器
- 將 API 操作公開為 MCP 工具
- 配置速率限制和安全性策略
- 使用 Visual Studio Code 和 GitHub Copilot 測試 MCP 伺服器

該範例說明了如何利用 Azure 的功能創建一個穩健的 MCP 伺服器，該伺服器可用於各種應用，增強 AI 系統與企業 API 的整合。

## 結論

這些案例研究突出了模型上下文協議在真實場景中的多功能性和實際應用。從複雜的多代理系統到針對性的自動化工作流程，MCP 提供了一種標準化的方式，將 AI 系統與它們所需的工具和數據連接起來，以創造價值。

通過研究這些實施案例，您可以獲得關於架構模式、實施策略和最佳實踐的見解，並將其應用於您自己的 MCP 項目中。這些範例證明，MCP 不僅僅是一個理論框架，而是一個解決真實業務挑戰的實用方案。

## 其他資源

- [Azure AI 旅遊代理 GitHub 儲存庫](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP 工具](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP 工具](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP 伺服器](https://github.com/MicrosoftDocs/mcp)
- [MCP 社群範例](https://github.com/microsoft/mcp)

下一步：實作實驗 [簡化 AI 工作流程：使用 AI 工具包構建 MCP 伺服器](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們努力確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於關鍵資訊，建議使用專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或錯誤解釋不承擔責任。