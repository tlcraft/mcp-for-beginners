<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-16T14:47:35+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "zh"
}
-->
# 案例研究：Azure AI 旅行代理 – 参考实现

## 概述

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) 是微软开发的一个综合参考解决方案，展示了如何使用 Model Context Protocol (MCP)、Azure OpenAI 和 Azure AI Search 构建一个多代理、AI 驱动的旅行规划应用。该项目展示了多 AI 代理的协调最佳实践、企业数据的整合，以及为真实场景提供安全且可扩展的平台。

## 主要功能
- **多代理协调：** 利用 MCP 协调专门的代理（如航班代理、酒店代理和行程代理），协作完成复杂的旅行规划任务。
- **企业数据集成：** 连接 Azure AI Search 及其他企业数据源，提供最新且相关的旅行推荐信息。
- **安全且可扩展的架构：** 利用 Azure 服务实现身份验证、授权及可扩展部署，遵循企业安全最佳实践。
- **可扩展工具：** 实现可复用的 MCP 工具和提示模板，支持快速适应新领域或业务需求。
- **用户体验：** 提供基于 Azure OpenAI 和 MCP 的对话界面，方便用户与旅行代理互动。

## 架构
![Architecture](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### 架构图说明

Azure AI Travel Agents 解决方案的架构设计注重模块化、可扩展性和多 AI 代理与企业数据源的安全集成。主要组件和数据流如下：

- **用户界面：** 用户通过对话式 UI（如网页聊天或 Teams 机器人）与系统交互，发送查询并接收旅行推荐。
- **MCP 服务器：** 作为核心协调器，接收用户输入，管理上下文，并通过 Model Context Protocol 协调专门代理（如 FlightAgent、HotelAgent、ItineraryAgent）的动作。
- **AI 代理：** 每个代理负责特定领域（航班、酒店、行程），作为 MCP 工具实现，使用提示模板和逻辑处理请求并生成响应。
- **Azure OpenAI 服务：** 提供高级自然语言理解与生成，帮助代理解析用户意图并生成对话式回复。
- **Azure AI Search 及企业数据：** 代理查询 Azure AI Search 和其他企业数据源，获取最新的航班、酒店和旅行选项信息。
- **身份验证与安全：** 集成 Microsoft Entra ID 实现安全身份验证，并对所有资源实施最小权限访问控制。
- **部署：** 设计用于 Azure Container Apps 部署，确保可扩展性、监控和运营效率。

该架构实现了多 AI 代理的无缝协调、企业数据的安全集成，以及构建领域特定 AI 解决方案的稳健且可扩展平台。

## 架构图逐步说明
想象你正在计划一次大型旅行，并且有一支专家团队帮你处理每个细节。Azure AI Travel Agents 系统的工作方式类似，使用不同的部分（就像团队成员）各司其职。下面是它们如何协同工作的：

### 用户界面 (UI)：
把它想象成你的旅行代理的前台。你（用户）在这里提出问题或请求，比如“帮我找一趟去巴黎的航班。”这可以是网站上的聊天窗口或消息应用。

### MCP 服务器（协调者）：
MCP 服务器就像前台的经理，听取你的请求并决定哪个专家来处理具体部分。它跟踪你的对话，确保整个流程顺畅进行。

### AI 代理（专业助理）：
每个代理都是某个领域的专家——有的专门负责航班，有的负责酒店，还有的负责行程规划。当你提出旅行请求时，MCP 服务器会将请求发送给相应代理。这些代理利用自身知识和工具为你找到最佳方案。

### Azure OpenAI 服务（语言专家）：
就像一个语言专家，无论你怎么表达，都能准确理解你的意思。它帮助代理理解请求，并用自然、对话式的语言作出回应。

### Azure AI Search 与企业数据（信息库）：
想象有一个庞大且实时更新的图书馆，包含所有最新的旅行信息——航班时刻、酒店可用性等。代理会在这个图书馆中搜索，给你最准确的答案。

### 身份验证与安全（保安）：
就像保安检查谁能进入特定区域，这部分确保只有授权人员和代理能访问敏感信息，保护你的数据安全和隐私。

### 在 Azure Container Apps 上部署（大楼）：
所有助理和工具都在一个安全、可扩展的大楼（云端）中协作。这意味着系统可以同时处理大量用户请求，且始终可用。

## 它们如何协同工作：

你先在前台（UI）提出问题。
经理（MCP 服务器）确定由哪个专家（代理）帮你。
专家借助语言专家（OpenAI）理解请求，利用信息库（AI Search）找到最佳答案。
保安（身份验证）确保整个过程安全。
所有这些都在可靠且可扩展的大楼（Azure Container Apps）内完成，保证你的体验顺畅且安全。
这种团队协作让系统能快速且安全地帮你规划旅行，就像一群专家旅行代理在现代办公室共同工作一样！

## 技术实现
- **MCP 服务器：** 托管核心协调逻辑，暴露代理工具，管理多步骤旅行规划流程的上下文。
- **代理：** 每个代理（如 FlightAgent、HotelAgent）作为 MCP 工具实现，拥有自己的提示模板和逻辑。
- **Azure 集成：** 使用 Azure OpenAI 实现自然语言理解，利用 Azure AI Search 进行数据检索。
- **安全性：** 集成 Microsoft Entra ID 实现身份验证，并对所有资源应用最小权限访问控制。
- **部署：** 支持部署到 Azure Container Apps，实现可扩展性和运营效率。

## 结果与影响
- 展示了 MCP 如何在真实生产环境中协调多个 AI 代理。
- 通过提供可复用的代理协调、数据集成和安全部署模式，加速解决方案开发。
- 作为使用 MCP 和 Azure 服务构建领域特定 AI 应用的蓝图。

## 参考资料
- [Azure AI Travel Agents GitHub 仓库](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI 服务](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始文件的原文版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。