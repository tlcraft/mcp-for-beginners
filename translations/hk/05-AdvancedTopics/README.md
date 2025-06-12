<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-12T21:28:25+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hk"
}
-->
# Advanced Topics in MCP 

呢章會講解Model Context Protocol (MCP)嘅一啲進階主題，包括多模態整合、可擴展性、安全最佳實踐同企業整合。呢啲主題對建立穩健同適合生產環境嘅MCP應用好重要，可以滿足現代AI系統嘅需求。

## Overview

本課程會探討MCP實現嘅進階概念，重點係多模態整合、可擴展性、安全最佳實踐同企業整合。呢啲主題對打造能應付企業環境複雜要求嘅生產級MCP應用非常重要。

## Learning Objectives

完成本課程後，你將能夠：

- 喺MCP框架入面實現多模態功能
- 設計可擴展嘅MCP架構以應付高需求場景
- 應用符合MCP安全原則嘅安全最佳實踐
- 將MCP同企業AI系統同框架整合
- 喺生產環境優化性能同可靠性

## Lessons and sample Projects

| Link | Title | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | 學習點樣喺Azure上整合你嘅MCP Server |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples  | 音頻、圖像同多模態回應嘅範例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | 簡易Spring Boot應用示範OAuth2同MCP結合，作為授權同資源伺服器。展示安全嘅token發行、受保護端點、Azure Container Apps部署同API管理整合。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts  | 了解更多關於root context同點樣實現佢哋 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 學習唔同類型嘅路由 |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 學習點樣處理sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling  | 了解可擴展性 |
| [5.8 Security](./mcp-security/README.md) | Security  | 保護你嘅MCP Server安全 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server同client結合SerpAPI，提供實時網頁、新聞、產品搜索同問答功能。示範多工具協調、外部API整合同強健嘅錯誤處理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming  | 實時數據串流喺今日數據驅動世界變得不可或缺，企業同應用需要即時取得資訊以作出及時決策。|
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | 實時網絡搜索，講解MCP點樣透過提供標準化嘅上下文管理方法，喺AI模型、搜索引擎同應用之間實現實時網絡搜索嘅轉變。| 

## Additional References

想了解最新嘅進階MCP主題，可以參考：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Key Takeaways

- 多模態MCP實現擴展AI能力，唔止限於文字處理
- 可擴展性對企業部署至關重要，可以透過水平同垂直擴展解決
- 全面嘅安全措施保障數據安全同正確嘅存取控制
- 同Azure OpenAI同Microsoft AI Foundry等平台整合，提升MCP能力
- 進階MCP實現得益於優化架構同謹慎嘅資源管理

## Exercise

為一個具體用例設計企業級MCP實現：

1. 確認用例嘅多模態需求
2. 概述保護敏感數據所需嘅安全控制
3. 設計能應付不同負載嘅可擴展架構
4. 計劃同企業AI系統嘅整合點
5. 記錄潛在嘅性能瓶頸同緩解策略

## Additional Resources

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## What's next

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責聲明**：  
本文件係使用AI翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或錯誤解釋概不負責。