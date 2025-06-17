<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:17:57+00:00",
  "source_file": "README.md",
  "language_code": "zh"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.zh.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


按照以下步骤开始使用这些资源：
1. **Fork 仓库**：点击 [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **克隆仓库**：   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**加入 Azure AI Foundry Discord，结识专家和开发者同行**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 多语言支持

#### 通过 GitHub Action 提供支持（自动且始终保持最新）

# 🚀 Model Context Protocol (MCP) 初学者课程

## **通过 C#、Java、JavaScript、Python 和 TypeScript 的实战代码学习 MCP**

## 🧠 Model Context Protocol 课程概览

**Model Context Protocol (MCP)** 是一个前沿框架，旨在规范 AI 模型与客户端应用之间的交互。这个开源课程提供了结构化的学习路径，配有实用的代码示例和真实案例，涵盖 C#、Java、JavaScript、TypeScript 和 Python 等主流编程语言。

无论你是 AI 开发者、系统架构师，还是软件工程师，本指南都是你掌握 MCP 基础知识和实现策略的全面资源。

## 🔗 官方 MCP 资源

- 📘 [MCP 文档](https://modelcontextprotocol.io/) – 详细的教程和用户指南  
- 📜 [MCP 规范](https://spec.modelcontextprotocol.io/) – 协议架构和技术参考  
- 🧑‍💻 [MCP GitHub 仓库](https://github.com/modelcontextprotocol) – 开源 SDK、工具和代码示例  

## 🧭 完整的 MCP 课程结构

| 章节 | 标题 | 描述 | 链接 |
|--|--|--|--|
| 00 | **MCP 简介** | 介绍 Model Context Protocol 及其在 AI 流水线中的重要性，包括什么是 Model Context Protocol、为何标准化重要，以及实际应用案例和优势 | [简介](./00-Introduction/README.md) |
| 01 | **核心概念详解** | 深入探讨 MCP 的核心概念，包括客户端-服务器架构、关键协议组件和消息模式 | [核心概念](./01-CoreConcepts/README.md) |
| 02 | **MCP 中的安全性** | 识别基于 MCP 系统中的安全威胁，安全实现的技术和最佳实践 | [安全性](./02-Security/README.md) |
| 03 | **MCP 入门** | 环境搭建与配置，创建基础 MCP 服务器和客户端，将 MCP 集成到现有应用中 | [入门](./03-GettingStarted/README.md) |
| 3.1 | **第一个服务器** | 使用 MCP 协议搭建基础服务器，理解服务器-客户端交互，并测试服务器 | [第一个服务器](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **第一个客户端** | 使用 MCP 协议搭建基础客户端，理解客户端-服务器交互，并测试客户端 | [第一个客户端](./03-GettingStarted/02-client/README.md) |
| 3.3 | **带 LLM 的客户端** | 使用 MCP 协议搭建带有大型语言模型（LLM）的客户端 | [带 LLM 的客户端](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **用 Visual Studio Code 连接服务器** | 配置 Visual Studio Code 以使用 MCP 协议连接服务器 | [用 Visual Studio Code 连接服务器](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **使用 SSE 创建服务器** | SSE 帮助我们将服务器暴露到互联网，本节指导你使用 SSE 创建服务器 | [使用 SSE 创建服务器](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP 流式传输** | 学习如何实现 HTTP 流式传输，实现客户端与 MCP 服务器间的实时数据传输 | [HTTP 流式传输](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **使用 AI 工具包** | AI 工具包是一个极好的工具，帮助你管理 AI 和 MCP 工作流程 | [使用 AI 工具包](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **测试你的服务器** | 测试是开发过程中重要的一环，本节将帮助你使用多种工具进行测试 | [测试你的服务器](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **部署你的服务器** | 如何将本地开发环境迁移到生产环境？本节指导你开发和部署服务器 | [部署你的服务器](./03-GettingStarted/09-deployment/README.md) |
| 04 | **实战应用** | 跨语言使用 SDK，调试、测试与验证，设计可复用的提示模板和工作流 | [实战应用](./04-PracticalImplementation/README.md) |
| 05 | **MCP 高级主题** | 多模态 AI 工作流与扩展性，安全扩展策略，MCP 在企业生态系统中的应用 | [高级主题](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP 与 Azure 集成** | 展示与 Azure 的集成方式 | [MCP Azure 集成](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **多模态** | 展示如何处理图像等不同模态数据 | [多模态](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 演示** | 基于 Spring Boot 的简易应用，展示 MCP 中 OAuth2 的用法，包含授权服务器和资源服务器。演示安全令牌发放、受保护端点、Azure 容器应用部署及 API 管理集成。 | [MCP OAuth2 演示](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **根上下文** | 深入了解根上下文及其实现方法 | [根上下文](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **路由** | 学习不同类型的路由方式 | [路由](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **采样** | 学习采样的使用方法 | [采样](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **扩展** | 了解 MCP 服务器的扩展策略，包括水平和垂直扩展、资源优化和性能调优 | [扩展](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **安全性** | 保护你的 MCP 服务器，包括认证、授权和数据保护策略 | [安全性](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web 搜索 MCP** | Python MCP 服务器和客户端，集成 SerpAPI 实现实时网页、新闻、产品搜索及问答。演示多工具编排、外部 API 集成及健壮的错误处理 | [Web 搜索 MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **实时流式传输** | 实时数据流已成为当今数据驱动世界的核心，帮助企业和应用即时获取信息以做出及时决策。 | [实时流式传输](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **实时网页搜索** | 介绍 MCP 如何通过为 AI 模型、搜索引擎和应用提供统一的上下文管理，变革实时网页搜索 | [实时网页搜索](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **社区贡献** | 如何贡献代码和文档，通过 GitHub 协作，社区驱动的增强和反馈 | [社区贡献](./06-CommunityContributions/README.md) |
| 07 | **早期采用的见解** | 真实案例的实施经验与成功要点，基于MCP的解决方案构建与部署，趋势与未来路线图 | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP最佳实践** | 性能调优与优化，设计容错MCP系统，测试与弹性策略 | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP案例研究** | 深入解析MCP解决方案架构，部署蓝图与集成技巧，带注释的图示和项目演示 | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **简化AI工作流程：使用AI工具包构建MCP服务器** | 结合MCP与微软AI工具包（VS Code）的综合实操课程。通过涵盖基础知识、自定义服务器开发和生产部署策略的实用模块，学习如何构建连接AI模型与现实工具的智能应用。 | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## 示例项目

### 🧮 MCP计算器示例项目：
<details>
  <summary><strong>按语言探索代码实现</strong></summary>

  - [C# MCP服务器示例](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP计算器](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP演示](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP服务器](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP示例](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP高级计算器项目：
<details>
  <summary><strong>探索高级示例</strong></summary>

  - [高级C#示例](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java容器应用示例](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript高级示例](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python复杂实现](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript容器示例](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 学习MCP的先决条件

为了最大程度地利用本课程，你应该具备：

- 基础的C#、Java或Python知识
- 了解客户端-服务器模型及API
- （可选）具备机器学习相关概念的基础

## 📚 学习指南

提供了全面的[学习指南](./study_guide.md)，帮助你高效浏览本仓库。指南内容包括：

- 展示所有主题的可视化课程地图
- 各仓库部分的详细拆解
- 样例项目的使用指导
- 针对不同技能水平的推荐学习路径
- 补充学习资源

## 🛠️ 如何高效使用本课程

本指南中的每节课均包含：

1. 清晰的MCP概念讲解  
2. 多语言的实时代码示例  
3. 构建实际MCP应用的练习  
4. 面向高级学习者的额外资源  

## 📜 许可信息

本内容采用**MIT许可证**授权。详细条款请参见[LICENSE](../../LICENSE)。

## 🤝 贡献指南

欢迎对本项目提出贡献和建议。大多数贡献需要你同意一份贡献者许可协议（CLA），声明你有权且确实授权我们使用你的贡献。详情请访问 <https://cla.opensource.microsoft.com>。

当你提交拉取请求时，CLA机器人会自动判断你是否需要提供CLA，并相应地标记PR（如状态检查、评论）。只需按照机器人提供的指引操作即可。你在所有使用我们CLA的仓库中只需执行一次此操作。

本项目采用了[微软开源行为准则](https://opensource.microsoft.com/codeofconduct/)。更多信息请参阅[行为准则常见问题](https://opensource.microsoft.com/codeofconduct/faq/)或通过 [opencode@microsoft.com](mailto:opencode@microsoft.com) 联系我们，提出任何额外问题或建议。

## 🎒 其他课程
我们团队还提供其他课程！欢迎查看：

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [使用.NET的生成式AI入门](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [使用JavaScript的生成式AI入门](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [生成式AI入门](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [机器学习入门](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [数据科学入门](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [人工智能入门](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [网络安全入门](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web开发入门](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [物联网入门](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR开发入门](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [掌握 GitHub Copilot 实现 AI 结对编程](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [掌握 GitHub Copilot 面向 C#/.NET 开发者](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [选择你自己的 Copilot 冒险之旅](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ 商标声明

本项目可能包含项目、产品或服务的商标或标识。对 Microsoft 商标或标识的授权使用须遵守并遵循
[Microsoft 的商标和品牌指南](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)。
在本项目的修改版本中使用 Microsoft 商标或标识时，不得引起混淆或暗示 Microsoft 赞助。
任何第三方商标或标识的使用均须遵守相应第三方的政策。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始语言版本的文件应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。