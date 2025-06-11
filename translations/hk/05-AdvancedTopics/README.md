<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T14:57:50+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hk"
}
-->
# Advanced Topics in MCP 

本章旨在介紹 Model Context Protocol (MCP) 實作中的一系列進階主題，包括多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於構建穩健且可投入生產的 MCP 應用程式非常重要，能滿足現代 AI 系統的需求。

## Overview

本課程探討 Model Context Protocol 實作中的進階概念，重點包括多模態整合、可擴展性、安全最佳實踐及企業整合。這些主題對於打造能應付企業環境複雜需求的生產級 MCP 應用至關重要。

## Learning Objectives

完成本課程後，你將能夠：

- 在 MCP 框架中實作多模態功能
- 設計可擴展的 MCP 架構以應付高需求場景
- 套用符合 MCP 安全原則的安全最佳實踐
- 將 MCP 與企業 AI 系統及框架整合
- 優化生產環境中的效能與穩定性

## Lessons and sample Projects

| Link | Title | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | 學習如何在 Azure 上整合你的 MCP Server |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples  | 提供音訊、影像及多模態回應的範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | 最簡化的 Spring Boot 應用示範 MCP OAuth2，涵蓋授權伺服器及資源伺服器。展示安全的 token 發行、受保護端點、Azure Container Apps 部署及 API 管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts  | 深入了解 root context 及其實作方式 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 學習不同類型的路由方式 |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 學習如何使用取樣技術 |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling  | 了解擴展相關知識 |
| [5.8 Security](./mcp-security/README.md) | Security  | 強化你的 MCP Server 安全性 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP 伺服器與客戶端整合 SerpAPI，實現即時網頁、新聞、產品搜尋及問答功能。示範多工具協調、外部 API 整合及穩健的錯誤處理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming  | 即時資料串流已成為現今數據驅動世界的關鍵，企業及應用程式需即時存取資訊以作出迅速決策。|

## Additional References

欲取得最新的 MCP 進階主題資訊，請參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Key Takeaways

- 多模態 MCP 實作將 AI 能力延伸至文字處理以外
- 可擴展性對企業部署至關重要，可透過水平及垂直擴展來實現
- 完善的安全措施保護資料並確保正確的存取控制
- 與 Azure OpenAI 及 Microsoft AI Foundry 等平台的企業整合強化 MCP 功能
- 進階 MCP 實作受益於優化架構及謹慎的資源管理

## Exercise

為特定使用案例設計企業級 MCP 實作：

1. 確認該使用案例的多模態需求
2. 擬定保護敏感資料所需的安全控管措施
3. 設計可因應負載變化的可擴展架構
4. 規劃與企業 AI 系統的整合點
5. 紀錄潛在的效能瓶頸及緩解策略

## Additional Resources

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## What's next

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用本翻譯而引起嘅任何誤解或錯誤詮釋概不負責。