<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "20064351f7e0fa904e96b057ed742df3",
  "translation_date": "2025-07-22T06:57:19+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "zh"
}
-->
# 实践应用

实践应用是让模型上下文协议（MCP）的强大功能变得具体可见的地方。虽然理解MCP的理论和架构很重要，但真正的价值在于将这些概念应用于构建、测试和部署解决实际问题的解决方案。本章将理论知识与实际开发之间的鸿沟弥合，指导您如何将基于MCP的应用程序付诸实践。

无论您是在开发智能助手、将AI集成到业务流程中，还是构建用于数据处理的定制工具，MCP都提供了一个灵活的基础。其与语言无关的设计以及针对流行编程语言的官方SDK使其对各种开发者都易于使用。通过利用这些SDK，您可以快速原型设计、迭代并在不同平台和环境中扩展您的解决方案。

在接下来的章节中，您将看到实践示例、示例代码和部署策略，展示如何在C#、Java、TypeScript、JavaScript和Python中实现MCP。您还将学习如何调试和测试MCP服务器、管理API，以及使用Azure将解决方案部署到云端。这些实践资源旨在加速您的学习，帮助您自信地构建强大、可用于生产的MCP应用程序。

## 概述

本课程重点介绍跨多种编程语言实现MCP的实践方面。我们将探索如何使用MCP SDK在C#、Java、TypeScript、JavaScript和Python中构建强大的应用程序，调试和测试MCP服务器，以及创建可重用的资源、提示和工具。

## 学习目标

完成本课程后，您将能够：

- 使用官方SDK在多种编程语言中实现MCP解决方案
- 系统地调试和测试MCP服务器
- 创建和使用服务器功能（资源、提示和工具）
- 为复杂任务设计有效的MCP工作流
- 优化MCP实现以提高性能和可靠性

## 官方SDK资源

模型上下文协议提供了针对多种语言的官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用MCP SDK

本节提供了跨多种编程语言实现MCP的实践示例。您可以在`samples`目录中找到按语言组织的示例代码。

### 可用示例

仓库包括以下语言的[示例实现](../../../04-PracticalImplementation/samples)：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

每个示例都展示了该特定语言和生态系统中MCP的关键概念和实现模式。

## 核心服务器功能

MCP服务器可以实现以下功能的任意组合：

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
- 专门化的对话结构

### 工具

工具是供AI模型执行的功能：

- 数据处理工具
- 外部API集成
- 计算能力
- 搜索功能

## 示例实现：C#实现

官方C# SDK仓库包含多个示例实现，展示了MCP的不同方面：

- **基础MCP客户端**：展示如何创建MCP客户端并调用工具的简单示例
- **基础MCP服务器**：具有基本工具注册的最小服务器实现
- **高级MCP服务器**：功能齐全的服务器，包含工具注册、身份验证和错误处理
- **ASP.NET集成**：展示与ASP.NET Core集成的示例
- **工具实现模式**：展示不同复杂性级别的工具实现模式

C# MCP SDK目前处于预览阶段，API可能会发生变化。我们将随着SDK的演进不断更新此博客。

### 关键功能

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- 构建您的[第一个MCP服务器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

有关完整的C#实现示例，请访问[官方C# SDK示例仓库](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例实现：Java实现

Java SDK提供了具有企业级功能的强大MCP实现选项。

### 关键功能

- Spring框架集成
- 强类型安全
- 支持响应式编程
- 全面的错误处理

有关完整的Java实现示例，请参见`samples`目录中的[Java示例](samples/java/containerapp/README.md)。

## 示例实现：JavaScript实现

JavaScript SDK提供了一种轻量级且灵活的MCP实现方法。

### 关键功能

- 支持Node.js和浏览器
- 基于Promise的API
- 易于与Express等框架集成
- 支持WebSocket流

有关完整的JavaScript实现示例，请参见`samples`目录中的[JavaScript示例](samples/javascript/README.md)。

## 示例实现：Python实现

Python SDK提供了一种符合Python风格的MCP实现方法，并与优秀的机器学习框架集成。

### 关键功能

- 使用asyncio支持异步/等待
- FastAPI集成
- 简单的工具注册
- 与流行的机器学习库的原生集成

有关完整的Python实现示例，请参见`samples`目录中的[Python示例](samples/python/README.md)。

## API管理

Azure API管理是保护MCP服务器的绝佳解决方案。其核心思想是将Azure API管理实例置于MCP服务器前端，并让其处理您可能需要的功能，例如：

- 限流
- 令牌管理
- 监控
- 负载均衡
- 安全性

### Azure示例

以下是一个Azure示例，展示了如何[创建MCP服务器并使用Azure API管理保护它](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

下图展示了授权流程：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

在上述图像中，发生了以下情况：

- 使用Microsoft Entra进行身份验证/授权。
- Azure API管理充当网关，并使用策略来引导和管理流量。
- Azure Monitor记录所有请求以供进一步分析。

#### 授权流程

让我们更详细地了解授权流程：

![序列图](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP授权规范

了解更多关于[MCP授权规范](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## 将远程MCP服务器部署到Azure

让我们看看如何部署前面提到的示例：

1. 克隆仓库

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 注册`Microsoft.App`资源提供者。

   - 如果您使用Azure CLI，请运行`az provider register --namespace Microsoft.App --wait`。
   - 如果您使用Azure PowerShell，请运行`Register-AzResourceProvider -ProviderNamespace Microsoft.App`。然后稍后运行`(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`检查注册是否完成。

1. 运行此[azd](https://aka.ms/azd)命令以配置API管理服务、函数应用（包含代码）以及所有其他所需的Azure资源

    ```shell
    azd up
    ```

    此命令应在Azure上部署所有云资源。

### 使用MCP Inspector测试您的服务器

1. 在**新终端窗口**中安装并运行MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    您应该看到类似以下的界面：

    ![连接到Node Inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.zh.png)

1. 按住CTRL点击从应用显示的URL加载MCP Inspector Web应用（例如：[http://127.0.0.1:6274/#resources](http://127.0.0.1:6274/#resources)）
1. 将传输类型设置为`SSE`
1. 将URL设置为运行的API管理SSE端点（在`azd up`后显示）并**连接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

1. **列出工具**。点击一个工具并**运行工具**。

如果所有步骤都成功，您现在应该已连接到MCP服务器，并能够调用工具。

## Azure上的MCP服务器

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：这组仓库是使用Azure Functions构建和部署自定义远程MCP（模型上下文协议）服务器的快速启动模板，支持Python、C# .NET或Node/TypeScript。

这些示例提供了一个完整的解决方案，允许开发者：

- 本地构建和运行：在本地机器上开发和调试MCP服务器
- 部署到Azure：通过简单的`azd up`命令轻松部署到云端
- 从客户端连接：从各种客户端连接到MCP服务器，包括VS Code的Copilot代理模式和MCP Inspector工具

### 关键功能

- 设计安全性：MCP服务器使用密钥和HTTPS进行保护
- 身份验证选项：支持使用内置身份验证和/或API管理的OAuth
- 网络隔离：支持使用Azure虚拟网络（VNET）进行网络隔离
- 无服务器架构：利用Azure Functions实现可扩展的事件驱动执行
- 本地开发：全面支持本地开发和调试
- 简单部署：简化的Azure部署流程

仓库包含所有必要的配置文件、源代码和基础设施定义，帮助您快速开始生产级MCP服务器实现。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用Python和Azure Functions实现MCP的示例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用C# .NET和Azure Functions实现MCP的示例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用Node/TypeScript和Azure Functions实现MCP的示例。

## 关键要点

- MCP SDK提供了语言特定的工具，用于实现强大的MCP解决方案
- 调试和测试过程对于可靠的MCP应用程序至关重要
- 可重用的提示模板能够实现一致的AI交互
- 精心设计的工作流可以使用多个工具协调复杂任务
- 实现MCP解决方案需要考虑安全性、性能和错误处理

## 练习

设计一个解决您领域内实际问题的MCP工作流：

1. 确定3-4个有助于解决该问题的工具
2. 创建一个工作流图，展示这些工具如何交互
3. 使用您喜欢的语言实现其中一个工具的基础版本
4. 创建一个提示模板，帮助模型有效地使用您的工具

## 其他资源

---

下一步：[高级主题](../05-AdvancedTopics/README.md)

**免责声明**：  
本文档使用AI翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们努力确保翻译的准确性，但请注意，自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于关键信息，建议使用专业人工翻译。我们不对因使用此翻译而产生的任何误解或误读承担责任。