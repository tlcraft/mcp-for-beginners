<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:23:27+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "hk"
}
-->
# 案例研究：Azure AI 旅行代理 - 参考实现

## 概览

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) 是由 Microsoft 开发的一个全面的参考解决方案，展示了如何使用 Model Context Protocol (MCP)、Azure OpenAI 和 Azure AI Search 构建一个多代理的 AI 驱动旅行规划应用程序。这个项目展示了协调多个 AI 代理、整合企业数据以及为真实场景提供一个安全、可扩展平台的最佳实践。

## 关键特性
- **多代理协调：** 利用 MCP 协调专门的代理（如航班、酒店和行程代理），协作完成复杂的旅行规划任务。
- **企业数据集成：** 连接到 Azure AI Search 和其他企业数据源，提供最新的、相关的旅行推荐信息。
- **安全、可扩展架构：** 使用 Azure 服务进行身份验证、授权和可扩展部署，遵循企业安全最佳实践。
- **可扩展工具：** 实现可重用的 MCP 工具和提示模板，能够快速适应新领域或业务需求。
- **用户体验：** 提供一个对话界面，让用户与旅行代理进行互动，由 Azure OpenAI 和 MCP 驱动。

## 架构
![架构](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### 架构图描述

Azure AI Travel Agents 解决方案的架构设计旨在实现模块化、可扩展性和安全地集成多个 AI 代理和企业数据源。主要组件和数据流如下：

- **用户界面：** 用户通过对话式 UI（如网页聊天或 Teams 机器人）与系统互动，发送用户查询并接收旅行推荐。
- **MCP 服务器：** 作为中央协调器，接收用户输入，管理上下文，并通过 Model Context Protocol 协调专门代理（如 FlightAgent、HotelAgent、ItineraryAgent）的操作。
- **AI 代理：** 每个代理负责特定领域（航班、酒店、行程），并实现为 MCP 工具。代理使用提示模板和逻辑来处理请求并生成响应。
- **Azure OpenAI 服务：** 提供高级自然语言理解和生成，使代理能够解释用户意图并生成对话式响应。
- **Azure AI Search 和企业数据：** 代理查询 Azure AI Search 和其他企业数据源，以获取有关航班、酒店和旅行选项的最新信息。
- **身份验证和安全：** 与 Microsoft Entra ID 集成以实现安全身份验证，并对所有资源应用最小特权访问控制。
- **部署：** 设计用于部署在 Azure Container Apps 上，确保可扩展性、监控和运营效率。

这种架构实现了多个 AI 代理的无缝协调，与企业数据的安全集成，以及构建特定领域 AI 解决方案的强大、可扩展平台。

## 架构图的逐步解释
想象一下，计划一次大型旅行，并有一组专家助理帮助您处理每一个细节。Azure AI Travel Agents 系统以类似的方式工作，使用不同的部分（如团队成员），每个部分都有一个特殊的工作。以下是它们如何协同工作：

### 用户界面 (UI)：
把它想象成你的旅行代理的前台。你（用户）在这里提出问题或请求，比如“帮我找一趟去巴黎的航班。”这可能是网站上的一个聊天窗口或一个消息应用程序。

### MCP 服务器（协调者）：
MCP 服务器就像经理，听取你在前台的请求并决定哪个专家应该处理每个部分。它跟踪你的对话并确保一切顺利进行。

### AI 代理（专家助理）：
每个代理都是某个领域的专家——一个了解所有关于航班的知识，另一个了解酒店，还有一个了解如何规划你的行程。当你请求旅行时，MCP 服务器将你的请求发送给合适的代理。这些代理利用他们的知识和工具为你找到最佳选项。

### Azure OpenAI 服务（语言专家）：
这就像拥有一个语言专家，无论你怎么表达，它都能准确理解你的请求。它帮助代理理解你的请求并以自然的对话语言回应。

### Azure AI Search 和企业数据（信息库）：
想象一个庞大的、最新的信息库，里面有所有最新的旅行信息——航班时间表、酒店可用性等等。代理在这个信息库中搜索，为你提供最准确的答案。

### 身份验证和安全（安全卫士）：
就像安全卫士检查谁可以进入某些区域一样，这个部分确保只有授权的人和代理可以访问敏感信息。它保护你的数据安全和隐私。

### 部署在 Azure Container Apps 上（建筑物）：
所有这些助理和工具在一个安全、可扩展的建筑物（云端）中协同工作。这意味着系统可以同时处理大量用户，并且在你需要时始终可用。

## 如何协同工作：

你从在前台（UI）提出一个问题开始。
经理（MCP 服务器）找出哪个专家（代理）应该帮助你。
专家利用语言专家（OpenAI）理解你的请求，并使用信息库（AI Search）找到最佳答案。
安全卫士（身份验证）确保一切安全。
所有这些都在一个可靠、可扩展的建筑物（Azure Container Apps）中发生，因此你的体验是顺畅和安全的。
这种团队合作让系统能够快速、安全地帮助你规划旅行，就像一个现代办公室中一组专家旅行代理在一起工作一样！

## 技术实现
- **MCP 服务器：** 托管核心协调逻辑，暴露代理工具，并管理多步骤旅行规划工作流的上下文。
- **代理：** 每个代理（如 FlightAgent、HotelAgent）实现为一个 MCP 工具，具有自己的提示模板和逻辑。
- **Azure 集成：** 使用 Azure OpenAI 进行自然语言理解和 Azure AI Search 进行数据检索。
- **安全：** 与 Microsoft Entra ID 集成进行身份验证，并对所有资源应用最小特权访问控制。
- **部署：** 支持部署到 Azure Container Apps，以实现可扩展性和运营效率。

## 结果和影响
- 演示了 MCP 如何在真实的、生产级场景中协调多个 AI 代理。
- 通过提供可重用的代理协调、数据集成和安全部署模式，加速解决方案开发。
- 作为使用 MCP 和 Azure 服务构建特定领域 AI 驱动应用程序的蓝图。

## 参考资料
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**免責聲明**：
本文件是使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)翻譯的。雖然我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原始文件的母語版本作為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們不對因使用此翻譯而產生的任何誤解或誤譯承擔責任。