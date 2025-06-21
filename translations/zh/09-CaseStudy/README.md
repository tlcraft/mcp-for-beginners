<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:37:27+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "zh"
}
-->
# MCP 实战：真实案例研究

Model Context Protocol（MCP）正在改变 AI 应用与数据、工具及服务的交互方式。本节展示了多个真实案例，演示 MCP 在各种企业场景中的实际应用。

## 概述

本节通过具体的 MCP 实施案例，展示组织如何利用该协议解决复杂的业务难题。通过这些案例，您将深入了解 MCP 在实际场景中的多样性、可扩展性及其实际优势。

## 主要学习目标

通过研究这些案例，您将能够：

- 理解 MCP 如何应用于解决具体的业务问题
- 了解不同的集成模式和架构方法
- 掌握在企业环境中实施 MCP 的最佳实践
- 了解实际实施中遇到的挑战及解决方案
- 发现如何在自己的项目中应用类似模式的机会

## 重点案例

### 1. [Azure AI 旅行代理 – 参考实现](./travelagentsample.md)

本案例分析了微软的综合参考解决方案，展示如何利用 MCP、Azure OpenAI 和 Azure AI Search 构建一个多代理、AI 驱动的旅行规划应用。项目亮点包括：

- 通过 MCP 实现多代理编排
- 使用 Azure AI Search 进行企业数据整合
- 利用 Azure 服务构建安全且可扩展的架构
- 采用可重用的 MCP 组件实现可扩展工具
- 由 Azure OpenAI 支持的对话式用户体验

架构与实现细节为构建以 MCP 作为协调层的复杂多代理系统提供了宝贵参考。

### 2. [从 YouTube 数据更新 Azure DevOps 条目](./UpdateADOItemsFromYT.md)

本案例展示了 MCP 在自动化工作流程中的实际应用，说明如何使用 MCP 工具：

- 从在线平台（YouTube）提取数据
- 更新 Azure DevOps 系统中的工作项
- 创建可重复的自动化流程
- 跨异构系统整合数据

此示例表明，即使是相对简单的 MCP 实现，也能通过自动化日常任务和提升系统间数据一致性，实现显著的效率提升。

### 3. [基于 MCP 的实时文档检索](./docs-mcp/README.md)

本案例引导您如何连接 Python 控制台客户端与 Model Context Protocol (MCP) 服务器，实时检索并记录上下文感知的微软文档。您将学习：

- 使用 Python 客户端及官方 MCP SDK 连接 MCP 服务器
- 采用流式 HTTP 客户端实现高效的实时数据获取
- 调用服务器上的文档工具并将响应直接记录到控制台
- 在终端中集成最新微软文档，无需离开工作环境

本章节包含实践任务、最小可用代码示例及更多学习资源链接。请参阅完整章节及代码，了解 MCP 如何革新基于控制台的文档访问和开发者生产力。

### 4. [基于 MCP 的交互式学习计划生成 Web 应用](./docs-mcp/README.md)

本案例展示如何使用 Chainlit 和 Model Context Protocol (MCP) 构建一个交互式 Web 应用，为任意主题生成个性化学习计划。用户可指定学习主题（如“AI-900 认证”）和学习周期（例如 8 周），应用会按周提供推荐内容。Chainlit 提供对话式聊天界面，使体验更具互动性和适应性。

- 由 Chainlit 支持的对话式 Web 应用
- 用户自定义主题和时长输入
- 通过 MCP 提供逐周内容推荐
- 聊天界面中的实时适应响应

该项目展示了如何将对话式 AI 与 MCP 结合，在现代 Web 环境中打造动态、用户驱动的教育工具。

### 5. [VS Code 中基于 MCP 服务器的编辑器内文档](./docs-mcp/README.md)

本案例演示如何通过 MCP 服务器将 Microsoft Learn 文档直接引入 VS Code 环境，无需切换浏览器标签页。您将了解如何：

- 使用 MCP 面板或命令面板在 VS Code 内即时搜索和阅读文档
- 直接引用文档并插入链接到 README 或课程 Markdown 文件
- 结合 GitHub Copilot 和 MCP，实现无缝的 AI 驱动文档与代码工作流
- 通过实时反馈和微软官方内容验证及增强文档质量
- 将 MCP 集成到 GitHub 工作流，实现持续的文档验证

实现内容包括：
- 简单配置示例 `.vscode/mcp.json`
- 编辑器内体验的截图演示
- 结合 Copilot 和 MCP 的高效使用技巧

此场景适合课程作者、文档撰写者及开发者，他们希望在编辑器内专注工作，同时利用文档、Copilot 和验证工具，这一切均由 MCP 支持。

## 结语

这些案例突显了 Model Context Protocol 在实际场景中的多样性和实用性。从复杂的多代理系统到针对性的自动化流程，MCP 提供了一种标准化方式，将 AI 系统与所需工具和数据连接起来，创造价值。

通过学习这些实施案例，您可以掌握架构模式、实施策略和最佳实践，将其应用于自己的 MCP 项目。这些示例证明 MCP 不仅是理论框架，更是解决实际业务挑战的实用方案。

## 额外资源

- [Azure AI Travel Agents GitHub 仓库](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP 工具](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP 工具](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP 服务器](https://github.com/MicrosoftDocs/mcp)
- [MCP 社区示例](https://github.com/microsoft/mcp)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的原文版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。我们不对因使用本翻译而产生的任何误解或曲解承担责任。