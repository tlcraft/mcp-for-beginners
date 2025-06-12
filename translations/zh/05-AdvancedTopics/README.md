<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-12T21:15:18+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "zh"
}
-->
# MCP 高级主题

本章旨在介绍 Model Context Protocol (MCP) 实现中的一系列高级主题，包括多模态集成、可扩展性、安全最佳实践以及企业集成。这些主题对于构建稳健且适合生产环境的 MCP 应用至关重要，能够满足现代 AI 系统的需求。

## 概述

本课将探讨 MCP 实现中的高级概念，重点关注多模态集成、可扩展性、安全最佳实践以及企业集成。这些内容对于构建能够应对企业环境中复杂需求的生产级 MCP 应用非常重要。

## 学习目标

完成本课后，您将能够：

- 在 MCP 框架中实现多模态功能
- 设计适用于高负载场景的可扩展 MCP 架构
- 应用符合 MCP 安全原则的安全最佳实践
- 将 MCP 集成到企业 AI 系统和框架中
- 优化生产环境中的性能和可靠性

## 课程与示例项目

| 链接 | 标题 | 描述 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | 与 Azure 集成 | 学习如何在 Azure 上集成您的 MCP 服务器 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 多模态示例 | 音频、图像及多模态响应示例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 演示 | 最小化 Spring Boot 应用展示 MCP 的 OAuth2，既作为授权服务器又作为资源服务器。演示安全令牌颁发、受保护端点、Azure 容器应用部署及 API 管理集成。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | 根上下文 | 了解根上下文及其实现方法 |
| [5.5 Routing](./mcp-routing/README.md) | 路由 | 学习不同类型的路由 |
| [5.6 Sampling](./mcp-sampling/README.md) | 采样 | 学习如何进行采样操作 |
| [5.7 Scaling](./mcp-scaling/README.md) | 扩展 | 了解扩展相关内容 |
| [5.8 Security](./mcp-security/README.md) | 安全 | 保护您的 MCP 服务器 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web 搜索 MCP | Python MCP 服务器和客户端集成 SerpAPI，实现实时网页、新闻、产品搜索及问答。展示多工具编排、外部 API 集成及健壮的错误处理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | 流媒体 | 实时数据流已成为当今数据驱动世界的关键，企业和应用需要即时访问信息以做出及时决策。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | 实时网页搜索 | 介绍 MCP 如何通过为 AI 模型、搜索引擎和应用提供标准化的上下文管理方法，变革实时网页搜索。 |

## 额外参考资料

有关最新的 MCP 高级主题信息，请参阅：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 关键要点

- 多模态 MCP 实现扩展了 AI 的能力，超越了文本处理
- 可扩展性对于企业部署至关重要，可通过横向和纵向扩展实现
- 全面的安全措施保护数据并确保适当的访问控制
- 与 Azure OpenAI 和 Microsoft AI Foundry 等平台的企业集成增强了 MCP 功能
- 高级 MCP 实现受益于优化的架构设计和细致的资源管理

## 练习

设计一个面向企业级的 MCP 实现，针对特定用例：

1. 确定用例中的多模态需求
2. 概述保护敏感数据所需的安全控制措施
3. 设计能够应对不同负载的可扩展架构
4. 规划与企业 AI 系统的集成点
5. 记录潜在的性能瓶颈及其缓解策略

## 额外资源

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 接下来内容

- [5.1 MCP Integration](./mcp-integration/README.md)

**免责声明**：  
本文件已使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。