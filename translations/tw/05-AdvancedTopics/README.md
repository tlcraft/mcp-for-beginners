<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:03:41+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tw"
}
-->
# MCP 進階主題

本章節旨在涵蓋 Model Context Protocol (MCP) 實作中的一系列進階主題，包括多模態整合、可擴展性、安全最佳實踐與企業整合。這些主題對於打造穩健且適合生產環境的 MCP 應用程式至關重要，能滿足現代 AI 系統的需求。

## 概覽

本課程探討 MCP 實作中的進階概念，重點在於多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於建置能應付企業環境複雜需求的生產級 MCP 應用程式非常重要。

## 學習目標

完成本課程後，您將能夠：

- 在 MCP 框架中實現多模態功能
- 設計可擴展的 MCP 架構以應對高負載場景
- 套用符合 MCP 安全原則的安全最佳實踐
- 將 MCP 與企業 AI 系統和框架整合
- 優化生產環境中的效能與可靠性

## 課程與範例專案

| 連結 | 標題 | 說明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | 與 Azure 整合 | 學習如何在 Azure 上整合您的 MCP Server |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 多模態範例 | 音訊、影像與多模態回應範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 範例 | 最簡化的 Spring Boot 應用程式示範 MCP 的 OAuth2，包含授權伺服器與資源伺服器。展示安全的 Token 發行、受保護的端點、Azure Container Apps 部署及 API 管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root Contexts | 深入了解 root context 及其實作方式 |
| [5.5 Routing](./mcp-routing/README.md) | 路由 | 學習各種路由類型 |
| [5.6 Sampling](./mcp-sampling/README.md) | 取樣 | 學習如何操作取樣 |
| [5.7 Scaling](./mcp-scaling/README.md) | 擴展 | 瞭解擴展相關概念 |
| [5.8 Security](./mcp-security/README.md) | 安全性 | 保護您的 MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | 網路搜尋 MCP | Python MCP 伺服器與客戶端整合 SerpAPI，提供即時網頁、新聞、產品搜尋及問答。示範多工具協調、外部 API 整合與完善的錯誤處理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | 串流 | 即時資料串流在現今資料驅動的世界中已成為必備，企業與應用程式需要即時取得資訊以作出及時決策。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | 即時網路搜尋 | MCP 如何透過提供標準化的上下文管理方式，改變 AI 模型、搜尋引擎與應用程式間的即時網路搜尋體驗。 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID 認證 | Microsoft Entra ID 提供強大的雲端身分與存取管理解決方案，確保只有授權的使用者與應用程式能與您的 MCP 伺服器互動。 |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry 整合 | 學習如何將 Model Context Protocol 伺服器與 Azure AI Foundry 代理整合，實現強大的工具協調與企業 AI 能力，並標準化外部資料來源連接。 |

## 附加參考資料

欲取得最新的 MCP 進階主題資訊，請參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要重點

- 多模態 MCP 實作擴展 AI 能力，超越純文字處理
- 可擴展性是企業部署的關鍵，可透過水平與垂直擴展達成
- 全面性的安全措施保護資料並確保適當的存取控制
- 與 Azure OpenAI 及 Microsoft AI Foundry 等平台的企業整合，提升 MCP 功能
- 進階 MCP 實作受惠於優化的架構設計與謹慎的資源管理

## 練習

為特定使用案例設計企業級 MCP 實作：

1. 確認使用案例的多模態需求
2. 擬定保護敏感資料所需的安全控管措施
3. 設計可應對負載變化的可擴展架構
4. 規劃與企業 AI 系統的整合點
5. 記錄可能的效能瓶頸及其緩解策略

## 額外資源

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 下一步

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生之任何誤解或誤釋負責。