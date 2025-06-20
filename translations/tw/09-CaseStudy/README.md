<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:05:51+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tw"
}
-->
# MCP 實戰：真實案例研究

Model Context Protocol (MCP) 正在改變 AI 應用程式與資料、工具及服務的互動方式。本節將展示多個真實案例，說明 MCP 在各種企業場景中的實際應用。

## 概述

本節展示 MCP 實作的具體範例，強調組織如何利用此協議解決複雜的商業挑戰。透過這些案例研究，你將了解 MCP 在現實場景中的多樣性、可擴展性與實際效益。

## 主要學習目標

透過探索這些案例，你將能：

- 理解 MCP 如何應用於解決特定的商業問題
- 學習不同的整合模式與架構方法
- 認識在企業環境中實施 MCP 的最佳實務
- 獲得真實實作中遇到的挑戰與解決方案的見解
- 發掘在自身專案中應用類似模式的機會

## 精選案例研究

### 1. [Azure AI 旅遊代理人 – 參考實作](./travelagentsample.md)

此案例探討微軟的完整參考方案，展示如何利用 MCP、Azure OpenAI 與 Azure AI Search 建構多代理人 AI 旅遊規劃應用程式。專案重點包括：

- 透過 MCP 進行多代理人協調
- 與 Azure AI Search 的企業資料整合
- 使用 Azure 服務打造安全且可擴展的架構
- 以可重用 MCP 元件實現可擴充工具
- 由 Azure OpenAI 驅動的對話式使用者體驗

架構與實作細節提供了建構複雜多代理人系統，並以 MCP 作為協調層的寶貴參考。

### 2. [從 YouTube 資料更新 Azure DevOps 項目](./UpdateADOItemsFromYT.md)

此案例展示 MCP 在自動化工作流程中的實際應用，說明如何使用 MCP 工具：

- 從線上平台（YouTube）擷取資料
- 更新 Azure DevOps 系統中的工作項目
- 建立可重複使用的自動化流程
- 整合不同系統間的資料

此範例說明即使是相對簡單的 MCP 實作，也能透過自動化例行任務並提升系統間資料一致性，帶來顯著的效率提升。

## 結論

這些案例凸顯 Model Context Protocol 在真實場景中的多樣性與實用性。從複雜的多代理人系統到針對性自動化工作流程，MCP 提供一套標準化方式，連結 AI 系統與所需的工具及資料，創造價值。

透過研究這些實作，你能掌握架構模式、實作策略與最佳實務，並應用於自己的 MCP 專案。這些範例證明 MCP 不僅是理論框架，更是解決實際商業挑戰的實用方案。

## 其他資源

- [Azure AI 旅遊代理人 GitHub 倉庫](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP 工具](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP 工具](https://github.com/microsoft/playwright-mcp)
- [MCP 社群範例](https://github.com/microsoft/mcp)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。