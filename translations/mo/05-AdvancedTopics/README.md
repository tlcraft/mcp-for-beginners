<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T13:42:20+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "mo"
}
-->
# MCP 進階主題

本章旨在涵蓋 Model Context Protocol (MCP) 實作中的一系列進階主題，包括多模態整合、可擴展性、安全最佳實踐以及企業整合。這些主題對於構建穩健且適合生產環境的 MCP 應用程式至關重要，以滿足現代 AI 系統的需求。

## 概述

本課程探討 Model Context Protocol 實作中的進階概念，重點放在多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於建立能夠處理企業環境中複雜需求的生產級 MCP 應用程式非常重要。

## 學習目標

完成本課程後，您將能夠：

- 在 MCP 框架中實現多模態功能
- 設計適用於高需求場景的可擴展 MCP 架構
- 應用符合 MCP 安全原則的安全最佳實踐
- 將 MCP 與企業 AI 系統及框架整合
- 在生產環境中優化效能與可靠性

## 課程與範例專案

| 連結 | 標題 | 說明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | 與 Azure 整合 | 學習如何將您的 MCP Server 整合到 Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 多模態範例 | 提供音訊、影像及多模態回應的範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 範例 | 簡易的 Spring Boot 應用程式示範 MCP 的 OAuth2，涵蓋授權伺服器與資源伺服器。展示安全的令牌發行、受保護端點、Azure Container Apps 部署及 API 管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | 根上下文 | 深入了解根上下文及其實作方式 |
| [5.5 Routing](./mcp-routing/README.md) | 路由 | 學習不同類型的路由方式 |
| [5.6 Sampling](./mcp-sampling/README.md) | 抽樣 | 學習如何使用抽樣技術 |
| [5.7 Scaling](./mcp-scaling/README.md) | 擴展 | 了解擴展相關知識 |
| [5.8 Security](./mcp-security/README.md) | 安全性 | 保護您的 MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | 網頁搜尋 MCP | Python MCP 伺服器與客戶端整合 SerpAPI，實現即時網頁、新聞、產品搜尋及問答功能。示範多工具協調、外部 API 整合及強健的錯誤處理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | 串流 | 即時資料串流已成為當今資料驅動世界的關鍵，企業與應用程式需要即時存取資訊以做出迅速決策。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | 即時網頁搜尋 | MCP 如何透過提供標準化的上下文管理方式，改變即時網頁搜尋，涵蓋 AI 模型、搜尋引擎與應用程式。 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID 認證 | Microsoft Entra ID 提供強大的雲端身份與存取管理解決方案，確保只有授權用戶與應用程式能與您的 MCP 伺服器互動。 |

## 其他參考資料

欲取得最新的 MCP 進階主題資訊，請參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要重點

- 多模態 MCP 實作將 AI 能力擴展至文字處理以外
- 可擴展性對企業部署至關重要，可透過水平及垂直擴展來實現
- 全面性的安全措施可保護資料並確保適當的存取控制
- 與 Azure OpenAI 及 Microsoft AI Foundry 等平台的企業整合可增強 MCP 功能
- 進階 MCP 實作受益於優化的架構設計及謹慎的資源管理

## 練習

為特定使用案例設計企業級 MCP 實作：

1. 確認您的使用案例所需的多模態功能
2. 概述保護敏感資料所需的安全控管
3. 設計能因應不同負載的可擴展架構
4. 規劃與企業 AI 系統的整合點
5. 記錄潛在效能瓶頸及緩解策略

## 其他資源

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 接下來的內容

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。