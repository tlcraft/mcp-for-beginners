<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:00:55+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "zh"
}
-->
# 实践实现

实践实现是 Model Context Protocol (MCP) 力量得以体现的地方。虽然理解 MCP 的理论和架构很重要，但真正的价值是在你应用这些概念构建、测试和部署解决方案以解决现实问题时体现出来的。本章架起了概念知识与动手开发之间的桥梁，引导你完成基于 MCP 的应用开发全过程。

无论你是在开发智能助手、将 AI 集成到业务流程中，还是构建用于数据处理的定制工具，MCP 都提供了灵活的基础。其语言无关的设计以及面向主流编程语言的官方 SDK，使得各种开发者都能轻松上手。通过利用这些 SDK，你可以快速进行原型设计、迭代开发，并在不同平台和环境中扩展你的解决方案。

在接下来的章节中，你将看到实用示例、示范代码和部署策略，展示如何在 C#、Java、TypeScript、JavaScript 和 Python 中实现 MCP。你还将学习如何调试和测试 MCP 服务器、管理 API 以及使用 Azure 将解决方案部署到云端。这些动手资源旨在加速你的学习，帮助你自信地构建健壮、可投入生产的 MCP 应用。

## 概览

本课聚焦于 MCP 在多种编程语言中的实践实现。我们将探讨如何使用 C#、Java、TypeScript、JavaScript 和 Python 的 MCP SDK 构建健壮的应用，调试和测试 MCP 服务器，以及创建可复用的资源、提示和工具。

## 学习目标

完成本课后，你将能够：
- 使用官方 SDK 在多种编程语言中实现 MCP 解决方案
- 系统地调试和测试 MCP 服务器
- 创建并使用服务器功能（资源、提示和工具）
- 设计有效的 MCP 工作流以完成复杂任务
- 优化 MCP 实现以提升性能和可靠性

## 官方 SDK 资源

Model Context Protocol 提供多语言官方 SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用 MCP SDK

本节提供了跨多种编程语言实现 MCP 的实用示例。你可以在 `samples` 目录下按语言分类找到示范代码。

### 可用示例

仓库包含以下语言的示范实现：

- C#
- Java
- TypeScript
- JavaScript
- Python

每个示例都演示了该语言及生态系统中 MCP 的关键概念和实现模式。

## 核心服务器功能

MCP 服务器可以实现以下任意组合的功能：

### 资源
资源为用户或 AI 模型提供上下文和数据：
- 文档仓库
- 知识库
- 结构化数据源
- 文件系统

### 提示
提示是为用户准备的模板化消息和工作流：
- 预定义对话模板
- 引导式交互模式
- 专门的对话结构

### 工具
工具是 AI 模型可执行的函数：
- 数据处理工具
- 外部 API 集成
- 计算能力
- 搜索功能

## 示例实现：C#

官方 C# SDK 仓库包含多个示范实现，展示 MCP 的不同方面：

- **基础 MCP 客户端**：简单示例，展示如何创建 MCP 客户端并调用工具
- **基础 MCP 服务器**：最小化服务器实现，包含基础工具注册
- **高级 MCP 服务器**：功能完善的服务器，包含工具注册、认证和错误处理
- **ASP.NET 集成**：展示与 ASP.NET Core 集成的示例
- **工具实现模式**：多种复杂度的工具实现模式

MCP C# SDK 目前处于预览阶段，API 可能会变化。随着 SDK 发展，我们会持续更新此博客。

### 关键功能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 构建你的 [第一个 MCP 服务器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)。

完整的 C# 实现示例请访问 [官方 C# SDK 示例仓库](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例实现：Java 实现

Java SDK 提供了企业级特性的稳健 MCP 实现选项。

### 关键功能

- Spring 框架集成
- 强类型安全
- 响应式编程支持
- 完备的错误处理

完整的 Java 实现示例请参见 samples 目录下的 [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## 示例实现：JavaScript 实现

JavaScript SDK 提供轻量且灵活的 MCP 实现方式。

### 关键功能

- 支持 Node.js 和浏览器环境
- 基于 Promise 的 API
- 轻松集成 Express 及其他框架
- 支持 WebSocket 流式传输

完整的 JavaScript 实现示例请参见 samples 目录下的 [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## 示例实现：Python 实现

Python SDK 提供符合 Python 风格的 MCP 实现，并且与主流机器学习框架集成良好。

### 关键功能

- 支持 asyncio 的 async/await
- 集成 Flask 和 FastAPI
- 简单的工具注册
- 原生支持流行的机器学习库

完整的 Python 实现示例请参见 samples 目录下的 [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API 管理

Azure API Management 是保护 MCP 服务器的理想方案。思路是将 Azure API Management 实例置于 MCP 服务器之前，处理你可能需要的功能，如：

- 限流
- 令牌管理
- 监控
- 负载均衡
- 安全性

### Azure 示例

这里有一个 Azure 示例，正是实现了这个功能，即[创建 MCP 服务器并用 Azure API Management 保护它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下图展示了授权流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

图中流程包括：

- 使用 Microsoft Entra 进行身份验证/授权。
- Azure API Management 作为网关，利用策略来引导和管理流量。
- Azure Monitor 记录所有请求以供后续分析。

#### 授权流程

让我们更详细地看看授权流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP 授权规范

了解更多关于 [MCP 授权规范](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 将远程 MCP 服务器部署到 Azure

让我们尝试部署之前提到的示例：

1. 克隆仓库

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. 注册 `Microsoft.App` 资源提供程序，使用命令 `az provider register --namespace Microsoft.App --wait`，或者使用 PowerShell 命令 `Register-AzResourceProvider -ProviderNamespace Microsoft.App`，稍后通过 `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 查看注册状态是否完成。

3. 运行以下 [azd](https://aka.ms/azd) 命令，来创建 API 管理服务、包含代码的函数应用以及所有其他所需的 Azure 资源：

    ```shell
    azd up
    ```

    该命令应会在 Azure 上部署所有云资源。

### 使用 MCP Inspector 测试你的服务器

1. 在**新终端窗口**中，安装并运行 MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你应该看到类似的界面：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.zh.png)

2. 按住 CTRL 并点击应用显示的 URL（例如 http://127.0.0.1:6274/#resources）以加载 MCP Inspector 网页应用
3. 将传输类型设置为 `SSE`，然后执行 `azd up` 并**连接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。点击某个工具并**运行工具**。

如果所有步骤都成功，你现在应该已连接到 MCP 服务器，并能调用工具。

## Azure 上的 MCP 服务器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：该系列仓库是使用 Azure Functions 结合 Python、C# .NET 或 Node/TypeScript 快速构建和部署定制远程 MCP（Model Context Protocol）服务器的入门模板。

该示例提供了完整解决方案，帮助开发者：

- 本地构建和运行：在本地机器上开发和调试 MCP 服务器
- 部署到 Azure：通过简单的 azd up 命令轻松部署到云端
- 客户端连接：支持从多种客户端连接 MCP 服务器，包括 VS Code 的 Copilot 代理模式和 MCP Inspector 工具

### 关键特性：

- 安全设计：MCP 服务器通过密钥和 HTTPS 保障安全
- 认证选项：支持内置认证和/或 API 管理的 OAuth
- 网络隔离：支持使用 Azure 虚拟网络（VNET）实现网络隔离
- 无服务器架构：利用 Azure Functions 实现可扩展的事件驱动执行
- 本地开发：提供全面的本地开发和调试支持
- 简单部署：简化的 Azure 部署流程

仓库包含所有必要的配置文件、源代码和基础设施定义，帮助你快速启动生产级 MCP 服务器实现。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Azure Functions 和 Python 的 MCP 示例实现

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 Azure Functions 和 C# .NET 的 MCP 示例实现

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Azure Functions 和 Node/TypeScript 的 MCP 示例实现

## 关键要点

- MCP SDK 提供针对不同语言的工具，用于实现健壮的 MCP 解决方案
- 调试和测试流程对于构建可靠的 MCP 应用至关重要
- 可复用的提示模板帮助实现一致的 AI 交互
- 设计良好的工作流可以协调多个工具完成复杂任务
- 实现 MCP 解决方案时需考虑安全性、性能和错误处理

## 练习

设计一个实际的 MCP 工作流，解决你领域中的一个现实问题：

1. 确定 3-4 个对解决该问题有帮助的工具
2. 创建一个工作流图，展示这些工具如何交互
3. 使用你喜欢的语言实现其中一个工具的基础版本
4. 创建一个提示模板，帮助模型有效地使用你的工具

## 附加资源


---

下一章: [高级主题](../05-AdvancedTopics/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译内容而产生的任何误解或误释，我们概不负责。