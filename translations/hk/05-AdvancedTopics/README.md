<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a5c1d9e9856024d23da4a65a847c75ac",
  "translation_date": "2025-07-18T07:12:03+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hk"
}
-->
# MCP 進階主題

本章涵蓋 Model Context Protocol (MCP) 實作中的一系列進階主題，包括多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於構建穩健且適合生產環境的 MCP 應用程式至關重要，能滿足現代 AI 系統的需求。

## 概覽

本課程探討 MCP 實作中的進階概念，重點在於多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於打造能應付企業環境中複雜需求的生產級 MCP 應用程式非常重要。

## 學習目標

完成本課程後，您將能夠：

- 在 MCP 框架中實作多模態功能
- 設計適用於高需求場景的可擴展 MCP 架構
- 應用符合 MCP 安全原則的安全最佳實踐
- 將 MCP 與企業 AI 系統及框架整合
- 優化生產環境中的效能與可靠性

## 課程與範例專案

| 連結 | 標題 | 說明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | 與 Azure 整合 | 學習如何在 Azure 上整合您的 MCP Server |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 多模態範例 | 音訊、影像及多模態回應範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 範例 | 簡易 Spring Boot 應用示範 MCP 的 OAuth2，涵蓋授權伺服器與資源伺服器。展示安全的令牌發行、受保護端點、Azure Container Apps 部署及 API 管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | 深入了解 root context 及其實作方式 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 學習不同類型的路由方式 |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 學習如何使用取樣技術 |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling | 了解擴展相關知識 |
| [5.8 Security](./mcp-security/README.md) | Security | 保護您的 MCP Server 安全 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP 伺服器與客戶端整合 SerpAPI，實現即時網頁、新聞、產品搜尋及問答。展示多工具協調、外部 API 整合及強健的錯誤處理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | 即時資料串流在現今數據驅動的世界中變得不可或缺，企業與應用程式需要即時存取資訊以做出及時決策。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | 即時網頁搜尋，展示 MCP 如何透過標準化的上下文管理，整合 AI 模型、搜尋引擎與應用程式，改變即時網頁搜尋的方式。 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID 提供強大的雲端身份與存取管理解決方案，確保只有授權的使用者與應用程式能與您的 MCP 伺服器互動。 |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry Integration | 學習如何將 Model Context Protocol 伺服器與 Azure AI Foundry 代理整合，實現強大的工具協調及企業 AI 能力，並標準化外部資料來源連接。 |
| [5.14 Context Engineering](./mcp-contextengineering/README.md) | Context Engineering | MCP 伺服器上下文工程技術的未來機會，包括上下文優化、動態上下文管理，以及 MCP 框架中有效提示工程的策略。 |

## 其他參考資料

欲取得最新的 MCP 進階主題資訊，請參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要重點

- 多模態 MCP 實作擴展 AI 能力，超越純文字處理
- 可擴展性對企業部署至關重要，可透過水平與垂直擴展來實現
- 全面性的安全措施保護資料並確保適當的存取控制
- 與 Azure OpenAI 及 Microsoft AI Foundry 等平台的企業整合提升 MCP 功能
- 進階 MCP 實作受益於優化架構與謹慎的資源管理

## 練習

為特定使用案例設計企業級 MCP 實作：

1. 確認您的使用案例所需的多模態功能
2. 概述保護敏感資料所需的安全控管
3. 設計能應付不同負載的可擴展架構
4. 規劃與企業 AI 系統的整合點
5. 記錄潛在的效能瓶頸及緩解策略

## 額外資源

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 下一步

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。