<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:42:58+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "tw"
}
-->
# Case Study: Azure AI Travel Agents – 參考實作

## 概覽

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) 是微軟開發的一個完整參考解決方案，示範如何使用 Model Context Protocol (MCP)、Azure OpenAI 與 Azure AI Search 建構多代理人、AI 驅動的旅遊規劃應用程式。此專案展現了多個 AI 代理人協調運作、企業資料整合，以及提供安全且可擴充的平台於實務場景中的最佳實踐。

## 主要功能
- **多代理人協調：** 利用 MCP 協調專門的代理人（如航班、飯店及行程代理人），共同完成複雜的旅遊規劃任務。
- **企業資料整合：** 連接 Azure AI Search 與其他企業資料來源，提供最新且相關的旅遊建議資訊。
- **安全且可擴展的架構：** 採用 Azure 服務進行身份驗證、授權及可擴展部署，遵循企業安全最佳實務。
- **可擴充的工具：** 實作可重複使用的 MCP 工具與提示範本，快速適應新領域或業務需求。
- **使用者體驗：** 提供會話式介面讓使用者與旅遊代理人互動，由 Azure OpenAI 與 MCP 驅動。

## 架構
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### 架構圖說明

Azure AI Travel Agents 解決方案設計強調模組化、可擴展性，以及多個 AI 代理人與企業資料來源的安全整合。主要元件與資料流程如下：

- **使用者介面：** 使用者透過會話式 UI（例如網站聊天視窗或 Teams 機器人）與系統互動，發送查詢並接收旅遊建議。
- **MCP Server：** 作為中央協調者，接收使用者輸入、管理上下文，並透過 Model Context Protocol 協調專門代理人（如 FlightAgent、HotelAgent、ItineraryAgent）的行動。
- **AI 代理人：** 每個代理人負責特定領域（航班、飯店、行程），以 MCP 工具形式實作，利用提示範本與邏輯處理請求並產生回應。
- **Azure OpenAI 服務：** 提供先進的自然語言理解與生成，幫助代理人解讀使用者意圖並產生會話回應。
- **Azure AI Search 與企業資料：** 代理人查詢 Azure AI Search 及其他企業資料來源，取得最新的航班、飯店及旅遊選項資訊。
- **身份驗證與安全：** 與 Microsoft Entra ID 整合，確保安全身份驗證，並對所有資源套用最小權限存取控制。
- **部署：** 設計於 Azure Container Apps 上部署，確保可擴展性、監控及營運效率。

此架構使多個 AI 代理人能無縫協調，安全整合企業資料，並打造強健且可擴充的領域專用 AI 解決方案平台。

## 架構圖逐步說明
想像你正在規劃一趟大型旅程，有一群專家助理在每個細節上幫忙。Azure AI Travel Agents 系統就像這樣運作，使用不同部分（就像團隊成員）各司其職。以下說明整體運作：

### 使用者介面 (UI):
把它想成你的旅遊代理人櫃檯。你（使用者）在這裡提出問題或需求，例如「幫我找去巴黎的航班」。這可以是網站上的聊天視窗或通訊應用程式。

### MCP Server (協調者):
MCP Server 就像櫃檯的經理，聆聽你的需求，決定哪位專家該處理哪部分。它追蹤對話上下文，確保流程順暢。

### AI 代理人 (專家助理):
每位代理人都是特定領域的專家──一位精通航班，另一位熟悉飯店，還有負責行程規劃的。當你提出需求時，MCP Server 會將請求送給適合的代理人，他們利用專業知識和工具為你尋找最佳方案。

### Azure OpenAI 服務 (語言專家):
就像有位語言專家，能精確理解你提出的各種說法，協助代理人理解需求並用自然、會話式語言回應。

### Azure AI Search 與企業資料 (資訊圖書館):
想像一座龐大且即時更新的圖書館，收藏最新的航班時刻表、飯店空房等資訊。代理人會在這裡搜尋，以提供最準確的答案。

### 身份驗證與安全 (保全):
如同保全人員檢查進出權限，確保只有授權的人員和代理人能存取敏感資訊，保障你的資料安全與隱私。

### 部署於 Azure Container Apps (大樓):
所有助理和工具都在一棟安全、可擴展的大樓（雲端）裡協同作業，系統能同時服務大量使用者，且隨時可用。

## 整體運作流程：

你從櫃檯（UI）提出問題。
經理（MCP Server）判斷由哪位專家（代理人）協助。
專家利用語言專家（OpenAI）理解需求，並在圖書館（AI Search）尋找最佳答案。
保全（身份驗證）確保一切安全。
這一切都發生在可靠且可擴展的大樓（Azure Container Apps）內，讓你的使用體驗順暢又安全。
這種團隊合作讓系統能快速且安全地協助你規劃旅程，就像一群專業旅遊代理人在現代辦公室一起工作一樣！

## 技術實作
- **MCP Server：** 承載核心協調邏輯，公開代理人工具，管理多步驟旅遊規劃工作流程的上下文。
- **代理人：** 每個代理人（如 FlightAgent、HotelAgent）以 MCP 工具形式實作，擁有自己的提示範本與邏輯。
- **Azure 整合：** 使用 Azure OpenAI 進行自然語言理解，並利用 Azure AI Search 取得資料。
- **安全性：** 與 Microsoft Entra ID 整合身份驗證，並對所有資源套用最小權限存取控制。
- **部署：** 支援部署至 Azure Container Apps，確保系統可擴展與營運效率。

## 成果與影響
- 展示 MCP 如何用於協調多個 AI 代理人，應用於真實且生產等級的場景。
- 透過提供可重用的代理人協調、資料整合與安全部署範式，加速解決方案開發。
- 作為使用 MCP 與 Azure 服務打造領域專用 AI 應用的藍圖。

## 參考資料
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生的任何誤解或誤釋負責。