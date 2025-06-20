<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:05:42+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hk"
}
-->
# MCP 實戰：真實案例研究

Model Context Protocol (MCP) 正在改變 AI 應用程式與數據、工具及服務互動的方式。本節將展示多個真實案例，說明 MCP 在不同企業場景中的實際應用。

## 概覽

本節展示了 MCP 實施的具體範例，突顯組織如何利用此協議解決複雜的商業挑戰。透過這些案例，你將深入了解 MCP 在現實場景中的多樣性、可擴展性及實用價值。

## 主要學習目標

透過探索這些案例，你將能夠：

- 了解 MCP 如何應用於解決特定的商業問題
- 學習不同的整合模式及架構方法
- 認識在企業環境中實施 MCP 的最佳實踐
- 掌握真實實施中遇到的挑戰與解決方案
- 發掘在自身專案中應用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理 – 參考實作](./travelagentsample.md)

本案例探討微軟的完整參考解決方案，展示如何利用 MCP、Azure OpenAI 及 Azure AI Search 建立多代理的 AI 驅動旅遊規劃應用。專案重點包括：

- 透過 MCP 進行多代理協調
- 與 Azure AI Search 進行企業數據整合
- 利用 Azure 服務打造安全且可擴展的架構
- 以可重用 MCP 元件擴充工具功能
- 由 Azure OpenAI 驅動的對話式用戶體驗

架構與實作細節提供了建立以 MCP 為協調層的複雜多代理系統的寶貴參考。

### 2. [從 YouTube 數據更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

此案例展示 MCP 在自動化工作流程中的實際應用，說明如何使用 MCP 工具：

- 從線上平台（YouTube）擷取數據
- 更新 Azure DevOps 系統中的工作項目
- 建立可重複的自動化工作流程
- 跨不同系統整合數據

此範例說明即使是相對簡單的 MCP 實施，也能透過自動化例行任務及提升系統間數據一致性，帶來顯著的效率提升。

## 結論

這些案例突顯了 Model Context Protocol 在真實場景中的多樣性及實用性。從複雜的多代理系統到針對性的自動化工作流程，MCP 提供了一種標準化方式，將 AI 系統與所需的工具及數據連接起來，實現價值交付。

透過研究這些實作，你可以獲得架構模式、實施策略及最佳實踐的寶貴見解，並應用於自己的 MCP 專案中。這些範例證明 MCP 不僅是理論框架，更是解決實際商業挑戰的實用方案。

## 附加資源

- [Azure AI 旅遊代理 GitHub 倉庫](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP 工具](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP 工具](https://github.com/microsoft/playwright-mcp)
- [MCP 社群範例](https://github.com/microsoft/mcp)

**免責聲明**：  
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。因使用本翻譯而引起的任何誤解或誤釋，我們概不負責。