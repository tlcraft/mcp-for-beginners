<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:34:20+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hk"
}
-->
# 案例研究：Azure AI 旅遊代理 – 參考實作

## 概覽

[Azure AI 旅遊代理](https://github.com/Azure-Samples/azure-ai-travel-agents) 是微軟開發的一個全面參考解決方案，展示如何利用 Model Context Protocol (MCP)、Azure OpenAI 及 Azure AI Search 建立一個多代理、AI 驅動的旅遊規劃應用程式。這個專案展示了協調多個 AI 代理、整合企業數據，以及提供安全且可擴展平台於真實場景中的最佳實踐。

## 主要功能
- **多代理協調：** 利用 MCP 協調專門代理（如航班、酒店及行程代理）合作完成複雜的旅遊規劃任務。
- **企業數據整合：** 連接 Azure AI Search 及其他企業數據來源，提供最新且相關的旅遊建議資訊。
- **安全且可擴展架構：** 採用 Azure 服務進行身份驗證、授權及可擴展部署，遵循企業安全最佳實務。
- **可擴充工具：** 實作可重用的 MCP 工具及提示模板，能快速適應新領域或業務需求。
- **使用者體驗：** 提供會話介面，讓用戶能與旅遊代理互動，由 Azure OpenAI 與 MCP 驅動。

## 架構
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### 架構圖說明

Azure AI 旅遊代理解決方案設計上注重模組化、可擴展性及多個 AI 代理與企業數據來源的安全整合。主要組件及資料流程如下：

- **使用者介面：** 用戶透過會話式 UI（例如網頁聊天或 Teams 機器人）與系統互動，發送查詢並接收旅遊建議。
- **MCP 伺服器：** 作為中央協調者，接收用戶輸入、管理上下文，並透過 Model Context Protocol 協調專門代理（如 FlightAgent、HotelAgent、ItineraryAgent）的行動。
- **AI 代理：** 每個代理負責特定領域（航班、酒店、行程），以 MCP 工具形式實作。代理使用提示模板及邏輯處理請求並生成回應。
- **Azure OpenAI 服務：** 提供先進的自然語言理解與生成，幫助代理解析用戶意圖並產生會話回應。
- **Azure AI Search 與企業數據：** 代理查詢 Azure AI Search 及其他企業數據來源，獲取最新航班、酒店及旅遊選項資訊。
- **身份驗證與安全：** 與 Microsoft Entra ID 整合，確保安全身份驗證，並對所有資源應用最小權限存取控制。
- **部署：** 設計於 Azure Container Apps 上部署，確保可擴展性、監控及營運效率。

此架構實現多個 AI 代理的無縫協調、安全整合企業數據，以及構建特定領域 AI 解決方案的穩健且可擴展平台。

## 架構圖逐步說明
想像你在規劃一次大型旅行，有一隊專家助理協助你處理每個細節。Azure AI 旅遊代理系統就像這樣運作，使用不同部分（就像團隊成員）各自負責專門工作。以下是整體運作方式：

### 使用者介面 (UI):
想像這是你的旅遊代理前台。你（使用者）在這裡提出問題或需求，例如「幫我找一班飛往巴黎的航班」。這可以是網站的聊天視窗或通訊應用程式。

### MCP 伺服器（協調者）:
MCP 伺服器就像經理，聽取你在前台的請求，決定由哪位專家負責處理。它會追蹤對話並確保流程順暢。

### AI 代理（專家助理）:
每位代理都是特定領域的專家──一位熟悉航班，另一位專精酒店，還有一位負責行程規劃。當你提出需求時，MCP 伺服器會將請求發送給適合的代理。這些代理利用自己的知識和工具為你找出最佳方案。

### Azure OpenAI 服務（語言專家）:
這就像一位語言專家，能準確理解你怎麼說，不論你用什麼方式表達。它協助代理理解你的需求，並以自然且會話式的語言回應。

### Azure AI Search 與企業數據（資訊圖書館）:
想像有一個龐大且隨時更新的圖書館，收錄最新的旅遊資訊──航班時刻表、酒店空房等。代理會在這個圖書館中搜尋，為你取得最準確的答案。

### 身份驗證與安全（保安）:
就像保安檢查誰能進入特定區域，這部分確保只有授權的人員和代理能存取敏感資料，保護你的資料安全與隱私。

### 部署於 Azure Container Apps（大樓）:
所有這些助理和工具都運作在一棟安全且可擴展的大樓（雲端）裡。這代表系統能同時應付大量用戶，並且隨時可用。

## 整體運作流程：

你從前台（UI）提出問題。  
經理（MCP 伺服器）判斷由哪位專家（代理）協助你。  
專家透過語言專家（OpenAI）理解需求，並利用圖書館（AI Search）找出最佳答案。  
保安（身份驗證）確保一切安全無虞。  
這一切都在可靠且可擴展的大樓（Azure Container Apps）內完成，讓你的體驗順暢又安全。  
這種團隊合作讓系統能快速且安全地協助你規劃旅程，就像一群專業旅遊代理在現代辦公室協同工作一樣！

## 技術實作
- **MCP 伺服器：** 承載核心協調邏輯，公開代理工具，並管理多步驟旅遊規劃工作流程的上下文。
- **代理：** 每個代理（例如 FlightAgent、HotelAgent）皆以 MCP 工具實作，擁有自己的提示模板及邏輯。
- **Azure 整合：** 使用 Azure OpenAI 進行自然語言理解，並利用 Azure AI Search 取得資料。
- **安全性：** 與 Microsoft Entra ID 整合身份驗證，並對所有資源應用最小權限存取控制。
- **部署：** 支援部署於 Azure Container Apps，以確保可擴展性及營運效率。

## 成果與影響
- 展示 MCP 如何在真實生產環境中協調多個 AI 代理。
- 透過提供可重用的代理協調、數據整合及安全部署範式，加速解決方案開發。
- 作為使用 MCP 與 Azure 服務打造特定領域 AI 應用的藍圖。

## 參考資料
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**免責聲明**：  
本文件係用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力確保準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應被視為權威來源。對於重要資訊，建議採用專業人手翻譯。因使用本翻譯而引致嘅任何誤解或錯誤詮釋，我哋概不負責。