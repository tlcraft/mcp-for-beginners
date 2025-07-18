<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a5c1d9e9856024d23da4a65a847c75ac",
  "translation_date": "2025-07-18T07:11:30+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "zh"
}
-->
# MCP 高级主题

本章涵盖了模型上下文协议（MCP）实现中的一系列高级主题，包括多模态集成、可扩展性、安全最佳实践以及企业集成。这些主题对于构建稳健且适合生产环境的 MCP 应用至关重要，能够满足现代 AI 系统的需求。

## 概述

本课将探讨模型上下文协议实现中的高级概念，重点关注多模态集成、可扩展性、安全最佳实践和企业集成。这些内容对于构建能够应对企业环境中复杂需求的生产级 MCP 应用非常重要。

## 学习目标

完成本课后，您将能够：

- 在 MCP 框架中实现多模态功能
- 设计适用于高负载场景的可扩展 MCP 架构
- 应用符合 MCP 安全原则的安全最佳实践
- 将 MCP 与企业 AI 系统和框架集成
- 优化生产环境中的性能和可靠性

## 课程与示例项目

| 链接 | 标题 | 描述 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | 与 Azure 集成 | 学习如何在 Azure 上集成您的 MCP 服务器 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 多模态示例 | 音频、图像及多模态响应示例 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 演示 | 一个最简 Spring Boot 应用，展示 MCP 中 OAuth2 作为授权服务器和资源服务器的用法。演示安全令牌发放、受保护端点、Azure 容器应用部署及 API 管理集成。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | 根上下文 | 了解根上下文及其实现方法 |
| [5.5 Routing](./mcp-routing/README.md) | 路由 | 学习不同类型的路由 |
| [5.6 Sampling](./mcp-sampling/README.md) | 采样 | 学习如何使用采样 |
| [5.7 Scaling](./mcp-scaling/README.md) | 扩展 | 了解扩展相关内容 |
| [5.8 Security](./mcp-security/README.md) | 安全 | 保护您的 MCP 服务器 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web 搜索 MCP | Python MCP 服务器和客户端，集成 SerpAPI 实现实时网页、新闻、产品搜索及问答。演示多工具编排、外部 API 集成及健壮的错误处理。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | 流式传输 | 实时数据流在当今数据驱动的世界中变得至关重要，企业和应用需要即时访问信息以做出及时决策。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | 实时网页搜索 | MCP 如何通过为 AI 模型、搜索引擎和应用提供标准化的上下文管理，改变实时网页搜索。 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID 认证 | Microsoft Entra ID 提供强大的云端身份和访问管理解决方案，确保只有授权用户和应用能够与您的 MCP 服务器交互。 |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry 集成 | 学习如何将模型上下文协议服务器与 Azure AI Foundry 代理集成，实现强大的工具编排和企业 AI 能力，支持标准化的外部数据源连接。 |
| [5.14 Context Engineering](./mcp-contextengineering/README.md) | 上下文工程 | MCP 服务器上下文工程技术的未来机遇，包括上下文优化、动态上下文管理以及 MCP 框架内有效提示工程的策略。 |

## 额外参考资料

有关 MCP 高级主题的最新信息，请参阅：
- [MCP 文档](https://modelcontextprotocol.io/)
- [MCP 规范](https://spec.modelcontextprotocol.io/)
- [GitHub 仓库](https://github.com/modelcontextprotocol)

## 关键要点

- 多模态 MCP 实现扩展了 AI 的能力，超越了文本处理
- 可扩展性对于企业部署至关重要，可通过横向和纵向扩展实现
- 全面的安全措施保护数据并确保适当的访问控制
- 与 Azure OpenAI 和 Microsoft AI Foundry 等平台的企业集成增强了 MCP 功能
- 高级 MCP 实现受益于优化的架构设计和细致的资源管理

## 练习

为特定用例设计一个企业级 MCP 实现：

1. 确定用例的多模态需求
2. 概述保护敏感数据所需的安全控制措施
3. 设计能够应对不同负载的可扩展架构
4. 规划与企业 AI 系统的集成点
5. 记录潜在的性能瓶颈及其缓解策略

## 额外资源

- [Azure OpenAI 文档](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry 文档](https://learn.microsoft.com/en-us/ai-services/)

---

## 接下来

- [5.1 MCP 集成](./mcp-integration/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。