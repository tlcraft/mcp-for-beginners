<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:34:39+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tw"
}
-->
# Case Study: Azure AI 旅遊代理人 – 參考實作

## 概覽

[Azure AI 旅遊代理人](https://github.com/Azure-Samples/azure-ai-travel-agents) 是微軟打造的一個完整參考解決方案，示範如何利用 Model Context Protocol (MCP)、Azure OpenAI 及 Azure AI Search 建構一個多代理人、AI 驅動的旅遊規劃應用程式。此專案展示了多個 AI 代理人協調運作、整合企業資料，並提供安全且可擴充的平台以應用於實際場景的最佳實務。

## 主要功能
- **多代理人協調：** 利用 MCP 來協調專門代理人（如航班、飯店和行程代理人）合作完成複雜的旅遊規劃任務。
- **企業資料整合：** 連接 Azure AI Search 及其他企業資料來源，提供最新且相關的旅遊推薦資訊。
- **安全且可擴展的架構：** 運用 Azure 服務進行身份驗證、授權及可擴展部署，遵循企業安全最佳實務。
- **可擴充工具：** 實作可重複使用的 MCP 工具與提示範本，快速適應新領域或商業需求。
- **使用者體驗：** 提供對話式介面，讓使用者能與旅遊代理人互動，由 Azure OpenAI 與 MCP 支援。

## 架構
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### 架構圖說明

Azure AI 旅遊代理人解決方案的架構設計強調模組化、可擴展性與多個 AI 代理人及企業資料來源的安全整合。主要元件與資料流程如下：

- **使用者介面：** 使用者透過對話式 UI（例如網頁聊天或 Teams 機器人）互動，發送查詢並接收旅遊建議。
- **MCP Server：** 作為中央協調者，接收使用者輸入、管理上下文，並透過 Model Context Protocol 協調專門代理人（如 FlightAgent、HotelAgent、ItineraryAgent）的行動。
- **AI 代理人：** 每個代理人負責特定領域（航班、飯店、行程），以 MCP 工具形式實作，利用提示範本與邏輯處理請求並產生回應。
- **Azure OpenAI 服務：** 提供進階自然語言理解與生成，協助代理人解讀使用者意圖並產生對話式回應。
- **Azure AI Search 與企業資料：** 代理人查詢 Azure AI Search 及其他企業資料來源，取得最新航班、飯店及旅遊選項資訊。
- **身份驗證與安全性：** 整合 Microsoft Entra ID 以確保安全身份驗證，並對所有資源採用最小權限存取控制。
- **部署：** 設計於 Azure Container Apps 上部署，確保可擴展性、監控及營運效率。

此架構使多個 AI 代理人能無縫協調，安全整合企業資料，並打造專屬領域的 AI 解決方案平台。

## 架構圖逐步說明
想像你在規劃一趟大型旅程，有一隊專家助理團隊協助你處理每個細節。Azure AI 旅遊代理人系統也是這樣運作，用不同角色（就像團隊成員）各自負責特定工作。以下是整體運作方式：

### 使用者介面 (UI):
把它想像成你的旅遊代理人的櫃台。你（使用者）在這裡提問或提出需求，例如「幫我找一班飛往巴黎的航班」。這可以是網站上的聊天視窗或通訊軟體。

### MCP Server（協調者）：
MCP Server 就像經理，聽你在櫃台的需求，決定由哪位專家處理。它負責追蹤對話內容，確保流程順暢。

### AI 代理人（專家助理）：
每位代理人都是特定領域的專家—有的專精航班，有的專精飯店，還有負責規劃行程。當你提出需求時，MCP Server 會把請求傳給適合的代理人。這些代理人運用知識與工具，幫你找出最佳方案。

### Azure OpenAI 服務（語言專家）：
就像有位語言專家能精準理解你的意思，不管你怎麼說。它協助代理人理解你的需求，並用自然、對話式的語言回應。

### Azure AI Search 與企業資料（資訊圖書館）：
想像一個龐大且最新的圖書館，收藏所有旅遊資訊—航班時刻、飯店空房等。代理人會在這裡搜尋，取得最精準的答案。

### 身份驗證與安全性（安全守衛）：
就像保全檢查誰能進入特定區域，這部分確保只有授權的人員與代理人能存取敏感資料，保障你的資訊安全與隱私。

### 部署於 Azure Container Apps（大樓）：
所有助理與工具都在一棟安全且可擴展的大樓（雲端）內協同工作，確保系統能同時服務大量使用者，並隨時可用。

## 整體運作流程：

你在櫃台（UI）提出問題。
經理（MCP Server）判斷由哪位專家（代理人）協助你。
專家運用語言專家（OpenAI）理解需求，並到圖書館（AI Search）找出最佳答案。
安全守衛（身份驗證）確保一切安全無虞。
這些都在可靠且可擴展的大樓（Azure Container Apps）內進行，讓你的體驗流暢又安全。
這樣的團隊合作讓系統能快速且安全地幫你規劃旅程，就像一群專業旅遊代理人在現代辦公室中協同作業一樣！

## 技術實作
- **MCP Server：** 承載核心協調邏輯，暴露代理人工具，並管理多步驟旅遊規劃的上下文。
- **代理人：** 每個代理人（如 FlightAgent、HotelAgent）以 MCP 工具實作，具備專屬提示範本與邏輯。
- **Azure 整合：** 使用 Azure OpenAI 進行自然語言理解，並透過 Azure AI Search 取得資料。
- **安全性：** 整合 Microsoft Entra ID 進行身份驗證，並對所有資源實施最小權限存取控制。
- **部署：** 支援部署至 Azure Container Apps，確保可擴展性與營運效率。

## 成果與影響
- 展示 MCP 如何用於實際生產環境中協調多個 AI 代理人。
- 透過提供可重複使用的代理人協調、資料整合及安全部署模式，加速解決方案開發。
- 成為利用 MCP 與 Azure 服務打造領域專屬 AI 應用的藍圖。

## 參考資料
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不精確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所引起之任何誤解或錯誤詮釋負責。