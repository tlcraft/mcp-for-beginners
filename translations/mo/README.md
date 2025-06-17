<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:19:17+00:00",
  "source_file": "README.md",
  "language_code": "mo"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.mo.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


按照以下步驟開始使用這些資源：
1. **Fork 該倉庫**：點擊 [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone 該倉庫**：   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**加入 Azure AI Foundry Discord，與專家及開發者交流**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 多語言支援

#### 透過 GitHub Action 支援（自動且持續更新）

# 🚀 Model Context Protocol (MCP) 初學者課程

## **透過 C#、Java、JavaScript、Python 與 TypeScript 的實作範例學習 MCP**

## 🧠 Model Context Protocol 課程概覽

**Model Context Protocol (MCP)** 是一個先進的框架，旨在標準化 AI 模型與客戶端應用程式之間的互動。這套開源課程提供結構化的學習路徑，包含實用的程式碼範例和真實案例，涵蓋 C#、Java、JavaScript、TypeScript 與 Python 等主流程式語言。

無論你是 AI 開發者、系統架構師或軟體工程師，本指南都是你掌握 MCP 基礎與實作策略的完整資源。

## 🔗 官方 MCP 資源

- 📘 [MCP 文件](https://modelcontextprotocol.io/) – 詳細的教學與使用指南  
- 📜 [MCP 規範](https://spec.modelcontextprotocol.io/) – 協定架構與技術參考  
- 🧑‍💻 [MCP GitHub 倉庫](https://github.com/modelcontextprotocol) – 開源 SDK、工具與程式範例  

## 🧭 完整 MCP 課程架構

| 章節 | 標題 | 說明 | 連結 |
|--|--|--|--|
| 00 | **MCP 簡介** | 介紹 Model Context Protocol 及其在 AI 流程中的重要性，包括 MCP 是什麼、標準化的意義，以及實際應用與效益 | [簡介](./00-Introduction/README.md) |
| 01 | **核心概念解析** | 深入探討 MCP 的核心概念，包括客戶端-伺服器架構、主要協定組件與訊息傳遞模式 | [核心概念](./01-CoreConcepts/README.md) |
| 02 | **MCP 中的安全性** | 識別基於 MCP 系統中的安全威脅，並介紹安全實作的技術與最佳做法 | [安全性](./02-Security/README.md) |
| 03 | **MCP 入門** | 環境設定與配置，建立基本的 MCP 伺服器與客戶端，將 MCP 整合到現有應用中 | [入門](./03-GettingStarted/README.md) |
| 3.1 | **第一個伺服器** | 使用 MCP 協定建立基本伺服器，理解伺服器與客戶端的互動，並測試伺服器 | [第一個伺服器](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **第一個客戶端** | 使用 MCP 協定建立基本客戶端，理解客戶端與伺服器的互動，並測試客戶端 | [第一個客戶端](./03-GettingStarted/02-client/README.md) |
| 3.3 | **搭配大型語言模型的客戶端** | 使用 MCP 協定建立搭配大型語言模型（LLM）的客戶端 | [搭配大型語言模型的客戶端](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **使用 Visual Studio Code 消費伺服器** | 設定 Visual Studio Code 以使用 MCP 協定連接伺服器 | [使用 Visual Studio Code 消費伺服器](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **使用 SSE 建立伺服器** | SSE 讓我們能將伺服器公開到網際網路，本節將教你如何使用 SSE 建立伺服器 | [使用 SSE 建立伺服器](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP 串流** | 學習如何實作 HTTP 串流，以便客戶端與 MCP 伺服器間即時資料傳輸 | [HTTP 串流](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **使用 AI 工具包** | AI 工具包是管理 AI 與 MCP 工作流程的好幫手 | [使用 AI 工具包](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **測試你的伺服器** | 測試是開發過程的重要環節，本節將教你使用多種工具進行測試 | [測試你的伺服器](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **部署你的伺服器** | 如何從本地開發到正式上線？本節將協助你開發並部署伺服器 | [部署你的伺服器](./03-GettingStarted/09-deployment/README.md) |
| 04 | **實務應用** | 使用多種語言的 SDK，進行除錯、測試與驗證，打造可重複使用的提示範本與工作流程 | [實務應用](./04-PracticalImplementation/README.md) |
| 05 | **MCP 進階主題** | 多模態 AI 工作流程與擴充性、安全擴展策略、MCP 在企業生態系統中的應用 | [進階主題](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP 與 Azure 整合** | 展示如何與 Azure 進行整合 | [MCP Azure 整合](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **多模態** | 展示如何處理不同模態，如圖片等 | [多模態](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 範例** | 使用最小化 Spring Boot 應用示範 MCP 的 OAuth2，包含授權伺服器與資源伺服器。展示安全的令牌發行、受保護端點、Azure Container Apps 部署與 API 管理整合。 | [MCP OAuth2 範例](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **根上下文** | 深入了解根上下文及其實作方式 | [根上下文](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **路由** | 學習不同類型的路由方式 | [路由](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **抽樣** | 學習如何操作抽樣 | [抽樣](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **擴展** | 探討 MCP 伺服器的擴展，包括水平與垂直擴展策略、資源優化與效能調校 | [擴展](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **安全性** | 保護你的 MCP 伺服器，包括身份驗證、授權與資料保護策略 | [安全性](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web 搜尋 MCP** | Python MCP 伺服器與客戶端整合 SerpAPI，實現即時網頁、新聞、產品搜尋與問答。展示多工具協調、外部 API 整合與強健的錯誤處理 | [Web 搜尋 MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **即時串流** | 即時資料串流在當今數據驅動的世界中已成為必要，企業與應用需即時取得資訊以作出迅速決策。 | [即時串流](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **即時網路搜尋** | MCP 如何透過標準化的上下文管理方式，改變即時網路搜尋，串連 AI 模型、搜尋引擎與應用程式。 | [即時網路搜尋](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **社群貢獻** | 如何貢獻程式碼與文件，透過 GitHub 協作，社群驅動的增強與回饋 | [社群貢獻](./06-CommunityContributions/README.md) |
| 07 | **早期採用的洞見** | 真實世界的實作與成功經驗，建立與部署基於 MCP 的解決方案，趨勢與未來路線圖 | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP 最佳實務** | 性能調校與優化，設計容錯的 MCP 系統，測試與韌性策略 | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP 案例研究** | 深入探討 MCP 解決方案架構、部署藍圖與整合技巧，附註解圖表與專案導覽 | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **精簡 AI 工作流程：使用 AI 工具包建置 MCP 伺服器** | 全面性的實作工作坊，結合 MCP 與 Microsoft AI 工具包 for VS Code。透過實務模組涵蓋基礎、客製化伺服器開發與生產部署策略，學習如何構建將 AI 模型與現實工具連結的智慧應用。 | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## 範例專案

### 🧮 MCP 計算機範例專案：
<details>
  <summary><strong>依語言探索程式碼實作</strong></summary>

  - [C# MCP 伺服器範例](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP 計算機](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP 範例](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP 伺服器](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP 範例](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP 進階計算機專案：
<details>
  <summary><strong>探索進階範例</strong></summary>

  - [進階 C# 範例](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java 容器應用範例](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript 進階範例](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python 複雜實作](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript 容器範例](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 學習 MCP 的先決條件

為了充分利用本課程內容，你應該具備：

- 基本的 C#、Java 或 Python 知識
- 了解客戶端-伺服器模型與 API
- （可選）熟悉機器學習概念

## 📚 學習指南

我們提供一份完整的 [學習指南](./study_guide.md)，幫助你有效掌握本儲存庫內容。指南包含：

- 視覺化課程地圖，展示所有涵蓋主題
- 每個儲存庫章節的詳細解析
- 如何使用範例專案的指引
- 依技能層級推薦的學習路徑
- 補充學習資源

## 🛠️ 如何有效利用本課程

本指南中每堂課包含：

1. 清晰的 MCP 概念說明  
2. 多語言的即時程式碼範例  
3. 實作 MCP 應用的練習  
4. 進階學習者的額外資源  

## 📜 授權資訊

本內容採用 **MIT 授權條款**。詳細條款請參閱 [LICENSE](../../LICENSE)。

## 🤝 貢獻指南

歡迎對本專案提出貢獻與建議。大多數貢獻需同意一份貢獻者授權協議（CLA），聲明你擁有且願意授權我們使用你的貢獻。詳情請參考 <https://cla.opensource.microsoft.com>。

當你提交拉取請求時，CLA 機器人會自動判斷是否需要你提供 CLA 並在 PR 上標示（例如狀態檢查、留言）。請依照機器人指示操作。你在所有使用本 CLA 的儲存庫中只需完成此程序一次。

本專案已採用 [Microsoft 開放原始碼行為準則](https://opensource.microsoft.com/codeofconduct/)。更多資訊請參閱 [行為準則 FAQ](https://opensource.microsoft.com/codeofconduct/faq/) 或聯絡 [opencode@microsoft.com](mailto:opencode@microsoft.com) 以獲得進一步協助。

## 🎒 其他課程
我們團隊還製作了其他課程！歡迎參考：

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [掌握 GitHub Copilot 進行 AI 配對程式設計](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [掌握 GitHub Copilot 供 C#/.NET 開發人員使用](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [選擇你的 Copilot 冒險之旅](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ 商標聲明

此專案可能包含專案、產品或服務的商標或標誌。授權使用 Microsoft  
商標或標誌須遵守並遵循  
[Microsoft 的商標與品牌指南](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)。  
在修改版本中使用 Microsoft 商標或標誌，不得造成混淆或暗示 Microsoft 贊助。  
任何第三方商標或標誌的使用均須遵守該第三方的相關政策。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威依據。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。