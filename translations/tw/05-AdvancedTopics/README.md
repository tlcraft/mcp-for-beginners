<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T18:32:52+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tw"
}
-->
# Advanced Topics in MCP 

這一章旨在介紹 Model Context Protocol (MCP) 實作中的一系列進階主題，包括多模態整合、可擴展性、安全最佳實踐，以及企業整合。這些主題對於打造穩健且適合生產環境的 MCP 應用程式，能滿足現代 AI 系統的需求至關重要。

## Overview

本課程探討 MCP 實作中的進階概念，重點在多模態整合、可擴展性、安全最佳實踐與企業整合。這些主題對於建立能應對企業環境複雜需求的生產級 MCP 應用至關重要。

## Learning Objectives

完成本課程後，您將能夠：

- 在 MCP 框架中實作多模態功能
- 設計適用於高需求場景的可擴展 MCP 架構
- 應用符合 MCP 安全原則的安全最佳實踐
- 將 MCP 與企業 AI 系統及框架整合
- 優化生產環境中的效能與可靠性

## Lessons and sample Projects

| Link | Title | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | 學習如何將您的 MCP Server 整合到 Azure 上 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples  | 提供音訊、影像及多模態回應的範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | 簡易 Spring Boot 應用展示 MCP 的 OAuth2，包含授權伺服器與資源伺服器。示範安全的 token 發行、受保護端點、Azure Container Apps 部署，以及 API 管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts  | 深入了解 root context 及其實作方式 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 學習不同類型的路由 |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 學習如何操作抽樣 |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling  | 了解擴展的相關知識 |
| [5.8 Security](./mcp-security/README.md) | Security  | 保護您的 MCP Server 安全 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP 伺服器與客戶端整合 SerpAPI，提供即時網頁、新聞、產品搜尋及問答。展示多工具協同、外部 API 整合與完善的錯誤處理。 |

## Additional References

欲獲取最新的進階 MCP 主題資訊，請參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Key Takeaways

- 多模態 MCP 實作擴展 AI 能力，超越文字處理
- 可擴展性對企業部署至關重要，可透過水平與垂直擴展來實現
- 全面性的安全措施保障資料並確保正確的存取控制
- 與 Azure OpenAI 及 Microsoft AI Foundry 等平台的企業整合強化 MCP 功能
- 進階 MCP 實作受益於優化架構與謹慎的資源管理

## Exercise

為特定使用案例設計一套企業級 MCP 實作：

1. 確認您的使用案例中多模態的需求
2. 列出保護敏感資料所需的安全控管
3. 設計能應付變動負載的可擴展架構
4. 規劃與企業 AI 系統的整合點
5. 記錄可能的效能瓶頸及緩解策略

## Additional Resources

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## What's next

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於確保翻譯準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生的任何誤解或誤釋負責。