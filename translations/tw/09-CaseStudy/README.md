<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "23899e82d806f25e5e46e89aab564dca",
  "translation_date": "2025-06-13T21:23:43+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tw"
}
-->
# MCP 實戰：真實案例研究

Model Context Protocol (MCP) 正在改變 AI 應用程式與資料、工具及服務互動的方式。本節介紹多個真實案例，展示 MCP 在各種企業場景中的實際應用。

## 概覽

本節展示 MCP 實作的具體範例，突顯各組織如何利用此協定解決複雜的商業問題。透過這些案例研究，你將了解 MCP 在現實情境中的多樣性、可擴展性及實用優勢。

## 主要學習目標

透過探索這些案例，你將能夠：

- 了解 MCP 如何應用於解決特定的商業問題
- 認識不同的整合模式與架構方法
- 掌握在企業環境中實施 MCP 的最佳實務
- 獲得在真實實作中遇到的挑戰與解決方案的洞見
- 找出可在自身專案中應用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理人 – 參考實作](./travelagentsample.md)

本案例探討微軟的完整參考解決方案，展示如何利用 MCP、Azure OpenAI 與 Azure AI Search 建立多代理人 AI 驅動的旅遊規劃應用程式。專案重點包括：

- 透過 MCP 進行多代理人協調
- 與 Azure AI Search 整合企業資料
- 使用 Azure 服務打造安全且可擴展的架構
- 利用可重複使用的 MCP 元件擴充工具功能
- 由 Azure OpenAI 支援的對話式使用者體驗

架構與實作細節提供了建立複雜多代理系統，以 MCP 作為協調層的寶貴見解。

### 2. [從 YouTube 資料更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

此案例展示 MCP 在自動化工作流程上的實際應用，說明 MCP 工具如何用來：

- 從線上平台（YouTube）擷取資料
- 更新 Azure DevOps 系統中的工作項目
- 建立可重複的自動化工作流程
- 跨不同系統整合資料

此範例說明即使是相對簡單的 MCP 實作，也能透過自動化例行任務並提升系統間資料一致性，大幅提升效率。

## 結論

這些案例凸顯 Model Context Protocol 在真實場景中的多元性與實用價值。從複雜的多代理系統到針對性自動化工作流程，MCP 提供一種標準化的方式，將 AI 系統與所需工具和資料連結起來，創造價值。

透過研究這些實作，你可以獲得架構模式、實施策略與最佳實務的洞見，並應用於自身的 MCP 專案。這些範例證明 MCP 不只是理論框架，更是解決實際商業挑戰的實用方案。

## 其他資源

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所導致的任何誤解或誤釋負責。