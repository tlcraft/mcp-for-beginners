<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T18:31:11+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hk"
}
-->
# Advanced Topics in MCP 

呢章會講解Model Context Protocol (MCP)實作嘅一啲進階主題，包括多模態整合、可擴展性、安全最佳實踐同企業整合。呢啲內容對於打造穩健同適合生產環境嘅MCP應用好重要，可以應付現代AI系統嘅需求。

## Overview

今課會探討Model Context Protocol實作嘅進階概念，集中喺多模態整合、可擴展性、安全最佳實踐同企業整合。呢啲主題係建立生產級MCP應用，能夠處理企業環境中複雜需求嘅關鍵。

## Learning Objectives

完成今課後，你將能夠：

- 喺MCP框架入面實現多模態功能
- 設計可擴展嘅MCP架構，應付高負載情況
- 應用符合MCP安全原則嘅安全最佳實踐
- 將MCP整合到企業AI系統同框架
- 優化生產環境中嘅效能同可靠性

## Lessons and sample Projects

| Link | Title | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | 學習點樣將你嘅MCP Server整合到Azure上 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples  | 音頻、圖像同多模態回應嘅範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | 簡易Spring Boot應用示範MCP嘅OAuth2，包含授權伺服器同資源伺服器。展示安全嘅token發行、受保護端點、Azure Container Apps部署同API管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts  | 深入了解root context同點樣實作佢哋 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 學習唔同類型嘅routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 學習點樣處理sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling  | 了解scaling嘅概念 |
| [5.8 Security](./mcp-security/README.md) | Security  | 保護你嘅MCP Server安全 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server同client整合SerpAPI，實現即時網頁、新聞、產品搜尋同問答。示範多工具協調、外部API整合同強健嘅錯誤處理。 |

## Additional References

想獲取最新嘅進階MCP資訊，可以參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Key Takeaways

- 多模態MCP實作令AI能力超越文字處理
- 可擴展性係企業部署嘅必要條件，可以透過水平同垂直擴展實現
- 全面嘅安全措施保障數據同確保適當嘅存取控制
- 同Azure OpenAI同Microsoft AI Foundry等平台嘅企業整合增強MCP能力
- 進階MCP實作受惠於優化架構同謹慎嘅資源管理

## Exercise

為一個特定用例設計企業級MCP實作：

1. 確認你用例嘅多模態需求
2. 概述保護敏感數據所需嘅安全控制
3. 設計能應付變化負載嘅可擴展架構
4. 規劃與企業AI系統嘅整合點
5. 記錄潛在嘅效能瓶頸同緩解策略

## Additional Resources

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## What's next

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力於準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。因使用本翻譯而引起嘅任何誤解或誤釋，我哋概不負責。