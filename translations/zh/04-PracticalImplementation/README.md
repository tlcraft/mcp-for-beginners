<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-16T15:35:28+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "zh"
}
-->
# 实践应用

实践应用是模型上下文协议（MCP）威力得以体现的地方。虽然理解MCP的理论和架构很重要，但真正的价值在于你将这些概念应用于构建、测试和部署解决方案，从而解决现实问题。本章旨在弥合概念知识与实际开发之间的鸿沟，指导你如何将基于MCP的应用付诸实践。

无论你是在开发智能助手、将AI集成到业务流程中，还是构建用于数据处理的定制工具，MCP都提供了灵活的基础。其语言无关的设计以及针对主流编程语言的官方SDK，使得广大开发者都能轻松上手。通过利用这些SDK，你可以快速原型设计、反复迭代，并在不同平台和环境中扩展你的解决方案。

在接下来的章节中，你将看到实用示例、示范代码和部署策略，展示如何在C#、Java、TypeScript、JavaScript和Python中实现MCP。你还将学习如何调试和测试MCP服务器，管理API，以及使用Azure将解决方案部署到云端。这些实战资源旨在加速你的学习，帮助你自信地构建稳健且可投入生产的MCP应用。

## 概述

本课聚焦于跨多种编程语言的MCP实践实现。我们将探讨如何使用C#、Java、TypeScript、JavaScript和Python的MCP SDK构建稳健的应用，调试和测试MCP服务器，以及创建可复用的资源、提示和工具。

## 学习目标

完成本课后，你将能够：
- 使用官方SDK在多种编程语言中实现MCP解决方案
- 系统性地调试和测试MCP服务器
- 创建并使用服务器功能（资源、提示和工具）
- 设计有效的MCP工作流以处理复杂任务
- 优化MCP实现以提升性能和可靠性

## 官方SDK资源

模型上下文协议提供了多语言的官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用MCP SDK

本节提供了跨多种编程语言实现MCP的实用示例。你可以在`samples`目录中按语言分类找到示范代码。

### 可用示例

代码库包含以下语言的示范实现：

- C#
- Java
- TypeScript
- JavaScript
- Python

每个示例都演示了该语言及其生态系统中的关键MCP概念和实现模式。

## 核心服务器功能

MCP服务器可以实现以下任意组合的功能：

### 资源
资源为用户或AI模型提供上下文和数据：
- 文档库
- 知识库
- 结构化数据源
- 文件系统

### 提示
提示是针对用户的模板化消息和工作流：
- 预定义的对话模板
- 引导式交互模式
- 专用对话结构

### 工具
工具是AI模型可执行的函数：
- 数据处理工具
- 外部API集成
- 计算功能
- 搜索功能

## 示例实现：C#

官方C# SDK仓库包含多个示范实现，展示MCP的不同方面：

- **基础MCP客户端**：简单示例，展示如何创建MCP客户端并调用工具
- **基础MCP服务器**：最简服务器实现，带基本工具注册
- **高级MCP服务器**：功能完善的服务器，包含工具注册、身份验证和错误处理
- **ASP.NET集成**：展示与ASP.NET Core集成的示例
- **工具实现模式**：多种复杂度的工具实现模式

MCP C# SDK目前处于预览阶段，API可能会有变动。随着SDK的发展，我们将持续更新此博客。

### 关键特性
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 构建你的[第一个MCP服务器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

完整的C#实现示例请访问[官方C# SDK示例仓库](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例实现：Java实现

Java SDK提供了强大的MCP实现选项，具备企业级功能。

### 关键特性

- Spring框架集成
- 强类型安全
- 响应式编程支持
- 全面错误处理

完整的Java实现示例请参见samples目录下的[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## 示例实现：JavaScript实现

JavaScript SDK提供轻量且灵活的MCP实现方式。

### 关键特性

- 支持Node.js和浏览器环境
- 基于Promise的API
- 方便与Express及其他框架集成
- 支持流式的WebSocket

完整的JavaScript实现示例请参见samples目录下的[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## 示例实现：Python实现

Python SDK以Pythonic方式实现MCP，且与主流机器学习框架深度集成。

### 关键特性

- 支持async/await和asyncio
- 集成Flask和FastAPI
- 简单的工具注册
- 原生支持流行的机器学习库

完整的Python实现示例请参见samples目录下的[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API管理

Azure API管理是保护MCP服务器的绝佳方案。思路是在你的MCP服务器前面放置一个Azure API管理实例，让它处理你可能需要的功能，例如：

- 限流
- 令牌管理
- 监控
- 负载均衡
- 安全保障

### Azure示例

这里有一个Azure示例，展示了如何创建MCP服务器并使用Azure API管理进行保护，详见[创建MCP服务器并用Azure API管理保护](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下图展示了授权流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

图中发生了以下过程：

- 使用Microsoft Entra进行身份验证/授权。
- Azure API管理作为网关，使用策略来引导和管理流量。
- Azure Monitor记录所有请求以供后续分析。

#### 授权流程

让我们更详细地看一下授权流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP授权规范

了解更多关于[MCP授权规范](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 将远程MCP服务器部署到Azure

我们来看看如何部署前面提到的示例：

1. 克隆仓库

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. 注册 `Microsoft.App` 资源提供程序：

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `

    或者使用PowerShell：

    Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `

    之后使用 `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 检查注册是否完成。

3. 运行此[azd](https://aka.ms/azd)命令来配置API管理服务、函数应用（含代码）以及所有其他必需的Azure资源：

    ```shell
    azd up
    ```

    该命令将部署所有Azure云资源。

### 使用MCP Inspector测试你的服务器

1. 在**新终端窗口**中，安装并运行MCP Inspector：

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你应该看到类似如下界面：

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.zh.png)

2. 按住CTRL点击应用显示的URL（例如 http://127.0.0.1:6274/#resources）以加载MCP Inspector网页应用。
3. 将传输类型设置为 `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` 并点击**连接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。点击某个工具并**运行工具**。

如果以上步骤都成功，你现在应该已连接到MCP服务器，并成功调用了工具。

## Azure上的MCP服务器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：这一系列仓库是使用Azure Functions（Python、C# .NET或Node/TypeScript）构建和部署自定义远程MCP服务器的快速入门模板。

这些示例提供了完整的解决方案，允许开发者：

- 本地构建和运行：在本地机器上开发和调试MCP服务器
- 部署到Azure：通过简单的azd up命令轻松部署到云端
- 客户端连接：支持包括VS Code的Copilot代理模式和MCP Inspector工具在内的多种客户端连接

### 关键特性：

- 安全设计：MCP服务器通过密钥和HTTPS保障安全
- 认证选项：支持内置身份验证和/或API管理的OAuth
- 网络隔离：支持使用Azure虚拟网络（VNET）实现网络隔离
- 无服务器架构：利用Azure Functions实现可扩展的事件驱动执行
- 本地开发：全面支持本地开发和调试
- 简单部署：简化的Azure部署流程

仓库包含所有必要的配置文件、源代码和基础设施定义，帮助你快速启动生产级MCP服务器实现。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用Azure Functions和Python实现的MCP示例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用Azure Functions和C# .NET实现的MCP示例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用Azure Functions和Node/TypeScript实现的MCP示例

## 关键要点

- MCP SDK提供针对不同语言的工具，助力实现稳健的MCP解决方案
- 调试和测试流程对于可靠的MCP应用至关重要
- 可复用的提示模板确保一致的AI交互体验
- 设计良好的工作流可通过多工具协作完成复杂任务
- 实现MCP解决方案时需考虑安全性、性能和错误处理

## 练习

设计一个实用的MCP工作流，解决你所在领域的现实问题：

1. 确定3-4个有助于解决该问题的工具
2. 绘制工作流图，展示这些工具之间的交互
3. 使用你偏好的语言实现其中一个工具的基础版本
4. 创建一个提示模板，帮助模型有效使用你的工具

## 其他资源


---

下一节：[高级主题](../05-AdvancedTopics/README.md)

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻译。虽然我们努力确保准确性，但请注意，自动翻译可能存在错误或不准确之处。原始文件的原文版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而引起的任何误解或误释，我们概不负责。