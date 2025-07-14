<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:46:09+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "zh"
}
-->
# 实践应用

实践应用是模型上下文协议（MCP）威力得以体现的地方。虽然理解MCP的理论和架构很重要，但真正的价值在于将这些概念应用于构建、测试和部署解决方案，以解决现实世界的问题。本章弥合了概念知识与动手开发之间的差距，指导你如何将基于MCP的应用付诸实践。

无论你是在开发智能助手、将AI集成到业务流程中，还是构建定制的数据处理工具，MCP都提供了灵活的基础。其语言无关的设计和针对主流编程语言的官方SDK，使得各种开发者都能轻松上手。通过利用这些SDK，你可以快速进行原型设计、迭代和跨平台扩展解决方案。

在接下来的章节中，你将看到实用示例、示范代码和部署策略，展示如何在C#、Java、TypeScript、JavaScript和Python中实现MCP。你还将学习如何调试和测试MCP服务器、管理API，以及使用Azure将解决方案部署到云端。这些实操资源旨在加速你的学习，帮助你自信地构建健壮且可投入生产的MCP应用。

## 概述

本课聚焦于多种编程语言中MCP实现的实用方面。我们将探讨如何使用C#、Java、TypeScript、JavaScript和Python的MCP SDK构建稳健的应用，调试和测试MCP服务器，以及创建可复用的资源、提示和工具。

## 学习目标

完成本课后，你将能够：
- 使用官方SDK在多种编程语言中实现MCP解决方案
- 系统地调试和测试MCP服务器
- 创建并使用服务器功能（资源、提示和工具）
- 设计复杂任务的高效MCP工作流
- 优化MCP实现的性能和可靠性

## 官方SDK资源

模型上下文协议提供了多种语言的官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用MCP SDK

本节提供了跨多种编程语言实现MCP的实用示例。你可以在`samples`目录中按语言分类找到示范代码。

### 可用示例

仓库包含以下语言的[示例实现](../../../04-PracticalImplementation/samples)：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

每个示例都展示了该语言及生态系统中MCP的关键概念和实现模式。

## 核心服务器功能

MCP服务器可以实现以下任意组合的功能：

### 资源
资源为用户或AI模型提供上下文和数据：
- 文档库
- 知识库
- 结构化数据源
- 文件系统

### 提示
提示是为用户设计的模板化消息和工作流：
- 预定义的对话模板
- 引导式交互模式
- 专门的对话结构

### 工具
工具是供AI模型执行的功能：
- 数据处理工具
- 外部API集成
- 计算能力
- 搜索功能

## 示例实现：C#

官方C# SDK仓库包含多个示例实现，展示MCP的不同方面：

- **基础MCP客户端**：展示如何创建MCP客户端并调用工具的简单示例
- **基础MCP服务器**：带有基础工具注册的最简服务器实现
- **高级MCP服务器**：具备工具注册、身份验证和错误处理的完整服务器
- **ASP.NET集成**：展示与ASP.NET Core集成的示例
- **工具实现模式**：多种复杂度的工具实现模式

MCP C# SDK目前处于预览阶段，API可能会变动。我们将持续更新博客内容以跟进SDK的演进。

### 主要功能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 构建你的[第一个MCP服务器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)。

完整的C#实现示例，请访问[官方C# SDK示例仓库](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例实现：Java实现

Java SDK提供了企业级功能的强大MCP实现选项。

### 主要功能

- Spring框架集成
- 强类型安全
- 响应式编程支持
- 全面的错误处理

完整的Java实现示例，请参见示例目录中的[Java示例](samples/java/containerapp/README.md)。

## 示例实现：JavaScript实现

JavaScript SDK提供了轻量且灵活的MCP实现方式。

### 主要功能

- 支持Node.js和浏览器环境
- 基于Promise的API
- 易于与Express及其他框架集成
- 支持WebSocket流式传输

完整的JavaScript实现示例，请参见示例目录中的[JavaScript示例](samples/javascript/README.md)。

## 示例实现：Python实现

Python SDK提供了符合Python习惯的MCP实现方式，并与主流机器学习框架集成良好。

### 主要功能

- 支持async/await和asyncio
- 集成Flask和FastAPI
- 简单的工具注册
- 与流行机器学习库的原生集成

完整的Python实现示例，请参见示例目录中的[Python示例](samples/python/README.md)。

## API管理

Azure API管理是保护MCP服务器的绝佳方案。思路是在你的MCP服务器前面放置一个Azure API管理实例，让它处理你可能需要的功能，如：

- 限流
- 令牌管理
- 监控
- 负载均衡
- 安全性

### Azure示例

这里有一个Azure示例，正是实现了上述功能，即[创建MCP服务器并用Azure API管理保护它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下图展示了授权流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

图中发生了以下过程：

- 使用Microsoft Entra进行身份验证/授权。
- Azure API管理作为网关，使用策略来引导和管理流量。
- Azure Monitor记录所有请求以供后续分析。

#### 授权流程

让我们更详细地看看授权流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP授权规范

了解更多关于[MCP授权规范](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 将远程MCP服务器部署到Azure

让我们尝试部署前面提到的示例：

1. 克隆仓库

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. 注册`Microsoft.App`资源提供程序。
    * 如果使用Azure CLI，运行 `az provider register --namespace Microsoft.App --wait`。
    * 如果使用Azure PowerShell，运行 `Register-AzResourceProvider -ProviderNamespace Microsoft.App`。稍后运行 `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 检查注册是否完成。

3. 运行此[azd](https://aka.ms/azd)命令，预配API管理服务、函数应用（含代码）及所有其他所需的Azure资源

    ```shell
    azd up
    ```

    该命令应在Azure上部署所有云资源。

### 使用MCP Inspector测试服务器

1. 在**新终端窗口**中，安装并运行MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    你应看到类似如下界面：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.zh.png)

2. 按住CTRL点击，从应用显示的URL（例如 http://127.0.0.1:6274/#resources）加载MCP Inspector网页应用
3. 将传输类型设置为`SSE`
4. 将URL设置为`azd up`后显示的正在运行的API管理SSE端点，并点击**连接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。点击某个工具并**运行工具**。

如果以上步骤都成功，你现在应该已连接到MCP服务器，并能调用工具。

## Azure上的MCP服务器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：该系列仓库是使用Azure Functions（Python、C# .NET或Node/TypeScript）构建和部署自定义远程MCP服务器的快速入门模板。

该示例提供了完整解决方案，允许开发者：

- 本地构建和运行：在本地机器上开发和调试MCP服务器
- 部署到Azure：通过简单的azd up命令轻松部署到云端
- 客户端连接：支持包括VS Code的Copilot代理模式和MCP Inspector工具在内的多种客户端连接

### 主要功能：

- 安全设计：MCP服务器通过密钥和HTTPS保障安全
- 认证选项：支持内置认证和/或API管理的OAuth
- 网络隔离：支持使用Azure虚拟网络（VNET）实现网络隔离
- 无服务器架构：利用Azure Functions实现可扩展的事件驱动执行
- 本地开发：全面支持本地开发和调试
- 简单部署：简化的Azure部署流程

仓库包含所有必要的配置文件、源代码和基础设施定义，帮助你快速启动生产级MCP服务器实现。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用Azure Functions和Python实现的MCP示例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用Azure Functions和C# .NET实现的MCP示例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用Azure Functions和Node/TypeScript实现的MCP示例

## 关键要点

- MCP SDK提供了针对不同语言的工具，便于实现稳健的MCP解决方案
- 调试和测试过程对可靠的MCP应用至关重要
- 可复用的提示模板确保AI交互的一致性
- 设计良好的工作流能协调多个工具完成复杂任务
- 实现MCP解决方案时需考虑安全性、性能和错误处理

## 练习

设计一个实用的MCP工作流，解决你所在领域的一个现实问题：

1. 确定3-4个对解决该问题有用的工具
2. 创建一个工作流图，展示这些工具如何交互
3. 使用你偏好的语言实现其中一个工具的基础版本
4. 创建一个提示模板，帮助模型有效使用你的工具

## 额外资源


---

下一章：[高级主题](../05-AdvancedTopics/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言的原文应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。