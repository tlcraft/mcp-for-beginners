<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:20:43+00:00",
  "source_file": "README.md",
  "language_code": "hk"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.hk.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


跟隨以下步驟開始使用這些資源：
1. **Fork 這個儲存庫**：點擊 [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone 這個儲存庫**：   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**加入 Azure AI Foundry Discord，與專家及其他開發者交流**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 多語言支援

#### 透過 GitHub Action 支援（自動化且隨時保持最新）

# 🚀 Model Context Protocol (MCP) 初學者課程

## **透過 C#、Java、JavaScript、Python 和 TypeScript 的實作範例學習 MCP**

## 🧠 Model Context Protocol 課程概覽

**Model Context Protocol (MCP)** 是一個先進框架，旨在標準化 AI 模型與客戶端應用程式之間的互動。這套開源課程提供結構化的學習路徑，包含實際程式碼範例和真實案例，涵蓋 C#、Java、JavaScript、TypeScript 和 Python 等主流程式語言。

無論你是 AI 開發者、系統架構師還是軟件工程師，本指南都是你掌握 MCP 基礎與實作策略的全面資源。

## 🔗 官方 MCP 資源

- 📘 [MCP 文件](https://modelcontextprotocol.io/) – 詳盡的教學與使用指南  
- 📜 [MCP 規範](https://spec.modelcontextprotocol.io/) – 協議架構與技術參考  
- 🧑‍💻 [MCP GitHub 倉庫](https://github.com/modelcontextprotocol) – 開源 SDK、工具和程式碼範例  

## 🧭 完整 MCP 課程架構

| 章節 | 標題 | 說明 | 連結 |
|--|--|--|--|
| 00 | **MCP 簡介** | 介紹 Model Context Protocol 及其在 AI 流程中的重要性，包括什麼是 MCP、標準化的意義，以及實際應用案例與效益 | [簡介](./00-Introduction/README.md) |
| 01 | **核心概念說明** | 深入探討 MCP 的核心概念，包括客戶端-伺服器架構、協議主要組件及訊息傳遞模式 | [核心概念](./01-CoreConcepts/README.md) |
| 02 | **MCP 的安全性** | 識別 MCP 系統中的安全威脅，及實作安全防護的技術與最佳實務 | [安全性](./02-Security/README.md) |
| 03 | **開始使用 MCP** | 環境設定與配置，建立基本的 MCP 伺服器與客戶端，整合 MCP 至現有應用程式 | [開始使用](./03-GettingStarted/README.md) |
| 3.1 | **第一個伺服器** | 使用 MCP 協議設定基本伺服器，了解伺服器與客戶端的互動，並進行測試 | [第一個伺服器](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **第一個客戶端** | 使用 MCP 協議設定基本客戶端，了解客戶端與伺服器的互動，並進行測試 | [第一個客戶端](./03-GettingStarted/02-client/README.md) |
| 3.3 | **搭配大型語言模型的客戶端** | 使用 MCP 協議搭配大型語言模型 (LLM) 建立客戶端 | [搭配大型語言模型的客戶端](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **使用 Visual Studio Code 消費伺服器** | 設定 Visual Studio Code 以使用 MCP 協議連接伺服器 | [使用 Visual Studio Code 消費伺服器](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **使用 SSE 建立伺服器** | SSE 協助我們將伺服器對外開放，本章節將指導你如何使用 SSE 建立伺服器 | [使用 SSE 建立伺服器](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP 串流** | 學習如何實作 HTTP 串流，實現客戶端與 MCP 伺服器間的即時資料傳輸 | [HTTP 串流](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **使用 AI 工具包** | AI 工具包是協助你管理 AI 與 MCP 工作流程的絕佳工具 | [使用 AI 工具包](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **測試你的伺服器** | 測試是開發過程的重要環節，本章節將協助你使用多種工具進行測試 | [測試你的伺服器](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **部署你的伺服器** | 從本地開發到正式上線，這章節將教你如何開發並部署伺服器 | [部署你的伺服器](./03-GettingStarted/09-deployment/README.md) |
| 04 | **實務應用** | 使用多種語言的 SDK，進行除錯、測試與驗證，設計可重用的提示模板與工作流程 | [實務應用](./04-PracticalImplementation/README.md) |
| 05 | **MCP 進階主題** | 多模態 AI 工作流程與擴充性、安全擴展策略、MCP 在企業生態系統的應用 | [進階主題](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP 與 Azure 整合** | 展示與 Azure 的整合方式 | [MCP Azure 整合](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **多模態應用** | 示範如何處理不同模態，如圖片等 | [多模態應用](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 範例** | 最小化 Spring Boot 應用展示 MCP OAuth2，涵蓋授權伺服器與資源伺服器。示範安全的令牌發放、保護端點、Azure Container Apps 部署及 API 管理整合 | [MCP OAuth2 範例](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | 了解更多關於 root context 及其實作方式 | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | 學習不同類型的路由方式 | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | 學習如何使用採樣技術 | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | 探討 MCP 伺服器的擴展，包括水平與垂直擴展策略、資源優化及效能調校 | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Security** | 保護你的 MCP 伺服器，涵蓋身份驗證、授權及資料保護策略 | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP 伺服器與客戶端整合 SerpAPI，實現即時網頁、新聞、產品搜尋及問答。展示多工具協調、外部 API 整合及穩健的錯誤處理 | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **即時串流** | 即時資料串流在當今數據驅動的世界中變得不可或缺，企業與應用需即時取得資訊以做出及時決策 | [即時串流](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **即時網路搜尋** | 即時網路搜尋如何透過 MCP 提供標準化的上下文管理，串連 AI 模型、搜尋引擎與應用程式 | [即時網路搜尋](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **社群貢獻** | 如何貢獻程式碼與文件，透過 GitHub 協作，社群驅動的改進與回饋 | [社群貢獻](./06-CommunityContributions/README.md) |
| 07 | **早期採用的見解** | 真實世界的實作與成功經驗，構建及部署基於 MCP 的解決方案，趨勢與未來路線圖 | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP 的最佳實踐** | 性能調優與優化、設計容錯 MCP 系統、測試與韌性策略 | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP 案例研究** | 深入探討 MCP 解決方案架構、部署藍圖與整合技巧、帶註解的圖表及專案導覽 | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **簡化 AI 工作流程：使用 AI 工具包構建 MCP 伺服器** | 綜合實作工作坊，結合 MCP 與 Microsoft 的 VS Code AI 工具包。透過實務模組學習構建智能應用，將 AI 模型與現實工具連結，涵蓋基礎、客製化伺服器開發及生產部署策略。 | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## 範例專案

### 🧮 MCP 計算器範例專案：
<details>
  <summary><strong>按語言探索程式碼實作</strong></summary>

  - [C# MCP 伺服器範例](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP 計算器](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP 示範](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP 伺服器](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP 範例](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP 進階計算器專案：
<details>
  <summary><strong>探索進階範例</strong></summary>

  - [進階 C# 範例](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java 容器應用範例](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript 進階範例](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python 複雜實作](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript 容器範例](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 學習 MCP 的先決條件

為了充分利用本課程，建議您具備：

- 基本的 C#、Java 或 Python 知識
- 了解客戶端-伺服器模型及 API
- （選擇性）熟悉機器學習概念

## 📚 學習指南

我們提供了一份完整的[學習指南](./study_guide.md)，幫助您有效掌握本資源庫。指南包含：

- 視覺化課程地圖，展示所有涵蓋主題
- 各資源庫章節的詳細拆解
- 如何使用範例專案的指引
- 不同技能層級的推薦學習路徑
- 補充學習資源，助您深入理解

## 🛠️ 如何有效使用本課程

本指南的每堂課包含：

1. 清晰解釋 MCP 概念  
2. 多語言的即時程式碼範例  
3. 實作練習，打造真實 MCP 應用  
4. 進階學習者的額外資源  

## 📜 授權資訊

本內容採用 **MIT 授權條款**。詳細條款請參閱 [LICENSE](../../LICENSE)。

## 🤝 貢獻指南

本專案歡迎貢獻與建議。大部分貢獻需您同意
貢獻者授權協議（CLA），聲明您有權利且確實授權我們
使用您的貢獻。詳情請參閱 <https://cla.opensource.microsoft.com>。

當您提交 pull request 時，CLA 機器人會自動判斷您是否需要提供
CLA 並相應標註 PR（例如狀態檢查、留言）。只需按照機器人指示操作即可。
您只需在所有使用本 CLA 的資源庫中完成一次此程序。

本專案已採用 [Microsoft 開源行為守則](https://opensource.microsoft.com/codeofconduct/)。
更多資訊請參閱 [行為守則常見問題](https://opensource.microsoft.com/codeofconduct/faq/)，
或透過 [opencode@microsoft.com](mailto:opencode@microsoft.com) 聯絡我們，提出其他問題或意見。

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
- [掌握 GitHub Copilot 以進行 AI 配對編程](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [掌握 GitHub Copilot 供 C#/.NET 開發者使用](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [選擇你自己的 Copilot 冒險之旅](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ 商標聲明

本專案可能包含專案、產品或服務的商標或標誌。授權使用 Microsoft 商標或標誌須遵守並依據
[Microsoft 的商標及品牌指引](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)。
在修改版本中使用 Microsoft 商標或標誌，不得引起混淆或暗示 Microsoft 的贊助。
任何使用第三方商標或標誌的行為，均須遵守該第三方的政策。

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。對於因使用本翻譯而引起的任何誤解或誤釋，本公司概不負責。