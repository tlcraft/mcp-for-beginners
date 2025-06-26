<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eb12652eb7bd17f2193b835a344425c6",
  "translation_date": "2025-06-26T13:43:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-realtimesearch/README.md",
  "language_code": "hk"
}
-->
## 程式碼範例免責聲明

> **重要提示**：以下程式碼範例展示了 Model Context Protocol (MCP) 與網路搜尋功能的整合。雖然它們遵循官方 MCP SDK 的結構與模式，但為了教學目的而進行了簡化。
> 
> 這些範例包括：
> 
> 1. **Python 實作**：一個 FastMCP 伺服器實作，提供網路搜尋工具並連接外部搜尋 API。此範例展示了正確的生命週期管理、上下文處理以及工具實作，遵循[官方 MCP Python SDK](https://github.com/modelcontextprotocol/python-sdk)的模式。伺服器採用推薦的 Streamable HTTP 傳輸方式，已取代舊有的 SSE 傳輸，適用於生產環境部署。
> 
> 2. **JavaScript 實作**：使用 FastMCP 模式的 TypeScript/JavaScript 實作，來自[官方 MCP TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)，建立一個具有正確工具定義與客戶端連線的搜尋伺服器。此範例遵循最新推薦的會話管理與上下文保存模式。
> 
> 這些範例在生產環境中還需加入額外的錯誤處理、身份驗證及特定 API 整合程式碼。示範的搜尋 API 端點（`https://api.search-service.example/search`）為佔位符，需替換成實際的搜尋服務端點。
> 
> 欲取得完整實作細節與最新方法，請參閱[官方 MCP 規範](https://spec.modelcontextprotocol.io/)及 SDK 文件。

## 核心概念

### Model Context Protocol (MCP) 框架

MCP 的基礎是為 AI 模型、應用程式與服務提供標準化的上下文交換方式。在即時網路搜尋中，這個框架對於創建連貫的多回合搜尋體驗至關重要。主要組件包括：

1. **客戶端-伺服器架構**：MCP 建立了搜尋客戶端（請求端）與搜尋伺服器（提供端）之間的明確分離，允許靈活的部署模型。

2. **JSON-RPC 通訊**：協議使用 JSON-RPC 進行訊息交換，使其與網路技術相容，並易於跨平台實作。

3. **上下文管理**：MCP 定義結構化的方法來維護、更新及利用多次互動中的搜尋上下文。

4. **工具定義**：將搜尋功能以標準化工具形式暴露，擁有明確的參數與回傳值。

5. **串流支援**：協議支援結果串流，對於結果可能逐步抵達的即時搜尋至關重要。

### 網路搜尋整合模式

整合 MCP 與網路搜尋時，會出現幾種典型模式：

#### 1. 直接搜尋提供者整合

```mermaid
graph LR
    Client[MCP Client] --> |MCP Request| Server[MCP Server]
    Server --> |API Call| SearchAPI[Search API]
    SearchAPI --> |Results| Server
    Server --> |MCP Response| Client
```

此模式中，MCP 伺服器直接介接一個或多個搜尋 API，將 MCP 請求轉換成特定 API 呼叫，並將結果格式化為 MCP 回應。

#### 2. 聯邦搜尋與上下文保存

```mermaid
graph LR
    Client[MCP Client] --> |MCP Request| Federation[MCP Federation Layer]
    Federation --> |MCP Request 1| Search1[Search Provider 1]
    Federation --> |MCP Request 2| Search2[Search Provider 2]
    Federation --> |MCP Request 3| Search3[Search Provider 3]
    Search1 --> |MCP Response 1| Federation
    Search2 --> |MCP Response 2| Federation
    Search3 --> |MCP Response 3| Federation
    Federation --> |Aggregated MCP Response| Client
```

此模式將搜尋查詢分散至多個 MCP 相容的搜尋提供者，每個可能專精於不同類型內容或搜尋能力，同時維持統一的上下文。

#### 3. 上下文強化搜尋鏈

```mermaid
graph LR
    Client[MCP Client] --> |Query + Context| Server[MCP Server]
    Server --> |1. Query Analysis| NLP[NLP Service]
    NLP --> |Enhanced Query| Server
    Server --> |2. Search Execution| Search[Search Engine]
    Search --> |Raw Results| Server
    Server --> |3. Result Processing| Enhancement[Result Enhancement]
    Enhancement --> |Enhanced Results| Server
    Server --> |Final Results + Updated Context| Client
```

此模式將搜尋流程拆分為多個階段，每階段強化上下文，逐步產生更相關的結果。

### 搜尋上下文組件

在 MCP 為基礎的網路搜尋中，上下文通常包含：

- **查詢歷史**：會話中的先前搜尋查詢
- **使用者偏好**：語言、地區、安全搜尋設定
- **互動歷史**：點擊過的結果、在結果上的停留時間
- **搜尋參數**：篩選條件、排序方式及其他搜尋修飾符
- **領域知識**：與搜尋相關的特定主題上下文
- **時間上下文**：基於時間的相關性因素
- **來源偏好**：信任或偏好的資訊來源

## 使用案例與應用

### 研究與資訊蒐集

MCP 強化研究流程，能：

- 跨搜尋會話保存研究上下文
- 支援更複雜且上下文相關的查詢
- 支援多來源搜尋聯邦
- 促進從搜尋結果中萃取知識

### 即時新聞與趨勢監控

MCP 驅動的搜尋對新聞監控有以下優勢：

- 幾乎即時發現新興新聞事件
- 依上下文過濾相關資訊
- 跨多個來源追蹤主題與實體
- 根據使用者上下文提供個人化新聞提醒

### AI 強化瀏覽與研究

MCP 為 AI 強化瀏覽創造新可能：

- 根據當前瀏覽活動提供上下文搜尋建議
- 無縫整合網路搜尋與大型語言模型助理
- 多回合搜尋精煉並保持上下文
- 強化事實查核與資訊驗證

## 未來趨勢與創新

### MCP 在網路搜尋的演進

展望未來，預期 MCP 將發展以應對：

- **多模態搜尋**：整合文字、影像、音訊與影片搜尋並保存上下文
- **去中心化搜尋**：支援分散式及聯邦搜尋生態系統
- **搜尋隱私**：上下文感知的隱私保護搜尋機制
- **查詢理解**：自然語言搜尋查詢的深度語意解析

### 技術潛在進展

將塑造 MCP 搜尋未來的技術：

1. **神經搜尋架構**：基於嵌入向量的搜尋系統，為 MCP 最佳化
2. **個人化搜尋上下文**：隨時間學習個別使用者搜尋模式
3. **知識圖譜整合**：以領域專屬知識圖譜強化上下文搜尋
4. **跨模態上下文**：維持不同搜尋模式間的上下文連貫性

## 實作練習

### 練習 1：設定基本 MCP 搜尋流程

在此練習中，你將學會：

- 配置基本的 MCP 搜尋環境
- 實作網路搜尋的上下文處理器
- 測試並驗證搜尋回合間的上下文保存

### 練習 2：使用 MCP 搜尋建立研究助理

建立一個完整應用，能：

- 處理自然語言研究問題
- 執行上下文感知的網路搜尋
- 從多個來源綜合資訊
- 呈現有組織的研究結果

### 練習 3：實作 MCP 多來源搜尋聯邦

進階練習涵蓋：

- 上下文感知的查詢分派至多個搜尋引擎
- 結果排名與整合
- 上下文相關的搜尋結果去重
- 處理來源特定的元資料

## 附加資源

- [Model Context Protocol 規範](https://spec.modelcontextprotocol.io/) - 官方 MCP 規範與詳細協議文件
- [Model Context Protocol 文件](https://modelcontextprotocol.io/) - 詳細教學與實作指南
- [MCP Python SDK](https://github.com/modelcontextprotocol/python-sdk) - MCP 協議官方 Python 實作
- [MCP TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - MCP 協議官方 TypeScript 實作
- [MCP 參考伺服器](https://github.com/modelcontextprotocol/servers) - MCP 伺服器參考實作
- [Bing Web Search API 文件](https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/overview) - 微軟網路搜尋 API
- [Google Custom Search JSON API](https://developers.google.com/custom-search/v1/overview) - Google 可程式化搜尋引擎
- [SerpAPI 文件](https://serpapi.com/search-api) - 搜尋引擎結果頁 API
- [Meilisearch 文件](https://www.meilisearch.com/docs) - 開源搜尋引擎
- [Elasticsearch 文件](https://www.elastic.co/guide/index.html) - 分散式搜尋與分析引擎
- [LangChain 文件](https://python.langchain.com/docs/get_started/introduction) - 使用大型語言模型建立應用程式

## 學習成果

完成本模組後，你將能：

- 理解即時網路搜尋的基本原理及其挑戰
- 解釋 Model Context Protocol (MCP) 如何強化即時網路搜尋能力
- 使用流行框架與 API 實作基於 MCP 的搜尋解決方案
- 設計並部署可擴展、高效能的 MCP 搜尋架構
- 將 MCP 概念應用於語義搜尋、研究助理及 AI 強化瀏覽等多種案例
- 評估 MCP 搜尋技術的最新趨勢與未來創新

### 信任與安全考量

在實作基於 MCP 的網路搜尋解決方案時，請遵守 MCP 規範中的以下重要原則：

1. **使用者同意與控制**：使用者必須明確同意並了解所有資料存取與操作，尤其是涉及外部資料來源的網路搜尋實作。

2. **資料隱私**：妥善處理搜尋查詢與結果，特別是可能包含敏感資訊時，實施適當的存取控制以保護使用者資料。

3. **工具安全**：對搜尋工具實施適當的授權與驗證，因為工具可能透過任意程式碼執行帶來安全風險。工具行為描述除非來自可信伺服器，否則應視為不可信。

4. **清晰文件**：提供關於 MCP 搜尋實作能力、限制及安全考量的清楚文件，遵循 MCP 規範的實作指引。

5. **健全同意流程**：建立健全的同意與授權流程，在授權使用工具前清楚說明其功能，尤其是與外部網路資源互動的工具。

欲了解 MCP 安全與信任考量的完整細節，請參閱[官方文件](https://modelcontextprotocol.io/specification/2025-03-26#security-and-trust-%26-safety)。

## 下一步

- [5.11 Entra ID Authentication for Model Context Protocol Servers](../mcp-security-entra/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋承擔責任。