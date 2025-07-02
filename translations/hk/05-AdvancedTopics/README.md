<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:02:18+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hk"
}
-->
# Advanced Topics in MCP 

本章旨在介紹 Model Context Protocol (MCP) 實作中的一系列進階主題，包括多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於打造穩健且具備生產力的 MCP 應用至關重要，能夠滿足現代 AI 系統的需求。

## Overview

本課程探討 Model Context Protocol 實作中的進階概念，重點在於多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於構建能夠應對企業環境中複雜需求的生產級 MCP 應用非常重要。

## Learning Objectives

完成本課程後，您將能夠：

- 在 MCP 框架中實作多模態功能
- 設計適用於高負載場景的可擴展 MCP 架構
- 運用符合 MCP 安全原則的安全最佳實踐
- 將 MCP 與企業 AI 系統及框架整合
- 在生產環境中優化效能與可靠性

## Lessons and sample Projects

| Link | Title | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | 學習如何在 Azure 上整合您的 MCP Server |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples  | 提供音訊、影像及多模態回應的範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | 一個簡易的 Spring Boot 應用，展示 MCP 的 OAuth2 功能，涵蓋授權伺服器與資源伺服器。示範安全的 Token 發行、受保護端點、Azure Container Apps 部署及 API 管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts  | 深入了解 root context 及其實作方式 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 探討不同類型的路由設計 |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 學習如何使用抽樣技術 |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling  | 了解擴展相關知識 |
| [5.8 Security](./mcp-security/README.md) | Security  | 強化您的 MCP Server 安全性 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP 伺服器與客戶端整合 SerpAPI，實現即時網頁、新聞、商品搜尋及問答。示範多工具協調、外部 API 整合及強健錯誤處理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming  | 即時資料串流已成為現今數據驅動世界的關鍵，企業與應用程式需即時取得資訊以作出及時決策。|
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | MCP 如何透過提供標準化的上下文管理方法，改變即時網頁搜尋，涵蓋 AI 模型、搜尋引擎及應用程式。| 
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID 提供強大的雲端身份與存取管理解決方案，確保只有授權用戶與應用程式能與您的 MCP 伺服器互動。|
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry Integration | 學習如何將 Model Context Protocol 伺服器與 Azure AI Foundry 代理整合，實現強大的工具協調及企業 AI 能力，並標準化外部資料來源連接。|

## Additional References

欲獲取最新的 MCP 進階主題資訊，請參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Key Takeaways

- 多模態 MCP 實作擴展了 AI 在文本處理之外的能力
- 可擴展性對企業部署至關重要，可透過水平與垂直擴展來實現
- 全面性的安全措施能保護資料並確保正確的存取控制
- 與 Azure OpenAI 及 Microsoft AI Foundry 等平台的企業整合提升 MCP 功能
- 進階 MCP 實作受益於優化的架構設計及謹慎的資源管理

## Exercise

為特定用例設計一套企業級 MCP 實作：

1. 確認用例所需的多模態功能
2. 概述保護敏感資料所需的安全控管措施
3. 設計能應對負載變化的可擴展架構
4. 規劃與企業 AI 系統的整合點
5. 記錄可能的效能瓶頸及其緩解策略

## Additional Resources

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## What's next

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的原文版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋承擔責任。