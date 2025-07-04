<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T15:54:06+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "zh"
}
-->
# MCP 实践：真实案例研究

Model Context Protocol（MCP）正在改变 AI 应用与数据、工具和服务的交互方式。本节展示了多个真实案例，演示 MCP 在各种企业场景中的实际应用。

## 概述

本节通过具体的 MCP 实现案例，展示各组织如何利用该协议解决复杂的业务难题。通过分析这些案例，您将深入了解 MCP 在现实场景中的多样性、可扩展性及实际优势。

## 主要学习目标

通过研究这些案例，您将能够：

- 理解 MCP 如何应用于解决具体的业务问题
- 了解不同的集成模式和架构方法
- 掌握在企业环境中实施 MCP 的最佳实践
- 了解真实项目中遇到的挑战及解决方案
- 发现将类似模式应用于自身项目的机会

## 重点案例研究

### 1. [Azure AI 旅行代理 – 参考实现](./travelagentsample.md)

本案例研究介绍微软的综合参考解决方案，展示如何利用 MCP、Azure OpenAI 和 Azure AI Search 构建多代理、AI 驱动的旅行规划应用。项目亮点包括：

- 通过 MCP 实现多代理编排
- 利用 Azure AI Search 进行企业数据集成
- 使用 Azure 服务构建安全且可扩展的架构
- 通过可复用的 MCP 组件实现工具扩展
- 由 Azure OpenAI 支持的对话式用户体验

架构和实现细节为构建以 MCP 作为协调层的复杂多代理系统提供了宝贵参考。

### 2. [基于 YouTube 数据更新 Azure DevOps 项目](./UpdateADOItemsFromYT.md)

本案例展示了 MCP 在自动化工作流程中的实际应用，说明如何利用 MCP 工具：

- 从在线平台（YouTube）提取数据
- 更新 Azure DevOps 系统中的工作项
- 创建可重复使用的自动化流程
- 实现跨系统数据集成

该示例表明，即使是相对简单的 MCP 实现，也能通过自动化常规任务和提升系统间数据一致性带来显著效率提升。

### 3. [使用 MCP 实现实时文档检索](./docs-mcp/README.md)

本案例引导您通过 Python 控制台客户端连接 Model Context Protocol (MCP) 服务器，实时检索并记录上下文相关的微软文档。您将学习如何：

- 使用 Python 客户端和官方 MCP SDK 连接 MCP 服务器
- 利用流式 HTTP 客户端实现高效的实时数据获取
- 调用服务器上的文档工具并将响应直接记录到控制台
- 在终端内集成最新微软文档，无需离开工作环境

本章包含动手练习、最小可用代码示例及更多学习资源链接。请参阅完整章节和代码，了解 MCP 如何革新基于控制台的文档访问和开发者生产力。

### 4. [基于 MCP 的交互式学习计划生成器 Web 应用](./docs-mcp/README.md)

本案例展示如何使用 Chainlit 和 Model Context Protocol (MCP) 构建交互式 Web 应用，为任意主题生成个性化学习计划。用户可指定主题（如“AI-900 认证”）和学习周期（例如 8 周），应用将提供逐周推荐内容。Chainlit 提供对话式聊天界面，使体验更具互动性和适应性。

- 由 Chainlit 驱动的对话式 Web 应用
- 用户自定义主题和时长
- 通过 MCP 提供逐周内容推荐
- 聊天界面中的实时自适应响应

该项目展示了如何将对话式 AI 与 MCP 结合，打造现代 Web 环境下动态、用户驱动的教育工具。

### 5. [VS Code 中基于 MCP 服务器的编辑器内文档](./docs-mcp/README.md)

本案例展示如何利用 MCP 服务器将 Microsoft Learn 文档直接引入 VS Code 环境，无需切换浏览器标签页。您将了解如何：

- 通过 MCP 面板或命令面板即时搜索并阅读 VS Code 内的文档
- 直接引用文档并插入链接到 README 或课程 Markdown 文件
- 将 GitHub Copilot 与 MCP 结合，实现无缝的 AI 驱动文档和代码工作流
- 利用实时反馈和微软官方内容验证并提升文档质量
- 将 MCP 集成到 GitHub 工作流，实现持续文档验证

实现内容包括：
- 示例 `.vscode/mcp.json` 配置，便于快速设置
- 基于截图的编辑器内体验演示
- 结合 Copilot 和 MCP 提升生产力的技巧

该场景非常适合课程作者、文档编写者和开发者，帮助他们在编辑器内专注处理文档、Copilot 和验证工具，全部由 MCP 驱动。

### 6. [APIM MCP 服务器创建](./apimsample.md)

本案例提供了使用 Azure API Management (APIM) 创建 MCP 服务器的逐步指南，涵盖：

- 在 Azure API Management 中设置 MCP 服务器
- 将 API 操作暴露为 MCP 工具
- 配置限流和安全策略
- 使用 Visual Studio Code 和 GitHub Copilot 测试 MCP 服务器

该示例展示如何利用 Azure 功能构建强大的 MCP 服务器，增强 AI 系统与企业 API 的集成能力。

## 结论

这些案例突显了 Model Context Protocol 在现实场景中的多样性和实用性。从复杂的多代理系统到针对性自动化工作流，MCP 提供了一种标准化方式，将 AI 系统与所需工具和数据连接起来，实现价值交付。

通过学习这些实现，您可以获得架构模式、实施策略和最佳实践的宝贵经验，应用于自己的 MCP 项目。案例表明，MCP 不仅是理论框架，更是解决实际业务挑战的实用方案。

## 额外资源

- [Azure AI Travel Agents GitHub 仓库](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP 工具](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP 工具](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP 服务器](https://github.com/MicrosoftDocs/mcp)
- [MCP 社区示例](https://github.com/microsoft/mcp)

下一步：动手实验 [简化 AI 工作流：使用 AI 工具包构建 MCP 服务器](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。