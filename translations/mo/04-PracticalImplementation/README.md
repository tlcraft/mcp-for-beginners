<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:43:45+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "mo"
}
-->
# 实际实施

实际实施是模型上下文协议（MCP）力量变得具体的地方。虽然理解MCP背后的理论和架构很重要，但真正的价值在于应用这些概念来构建、测试和部署解决方案以解决现实世界的问题。本章将桥接概念知识与动手开发之间的差距，引导您通过过程将基于MCP的应用程序带入生活。

无论您是在开发智能助手、将AI集成到业务工作流中，还是构建用于数据处理的定制工具，MCP都提供了一个灵活的基础。它与语言无关的设计和流行编程语言的官方SDK使其对广泛的开发人员来说都很容易访问。通过利用这些SDK，您可以快速原型化、迭代并在不同平台和环境中扩展您的解决方案。

在接下来的部分中，您将找到实践示例、示例代码和部署策略，展示如何在C#、Java、TypeScript、JavaScript和Python中实施MCP。您还将学习如何调试和测试您的MCP服务器，管理API，并使用Azure将解决方案部署到云端。这些动手资源旨在加速您的学习，帮助您自信地构建健壮的、生产就绪的MCP应用程序。

## 概述

本课程重点关注MCP在多种编程语言中的实施的实际方面。我们将探讨如何在C#、Java、TypeScript、JavaScript和Python中使用MCP SDK构建稳健的应用程序，调试和测试MCP服务器，以及创建可重用的资源、提示和工具。

## 学习目标

完成本课程后，您将能够：
- 使用官方SDK在各种编程语言中实施MCP解决方案
- 系统地调试和测试MCP服务器
- 创建和使用服务器功能（资源、提示和工具）
- 为复杂任务设计有效的MCP工作流
- 优化MCP实施以提高性能和可靠性

## 官方SDK资源

模型上下文协议提供了多种语言的官方SDK：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## 使用MCP SDK

本节提供了在多种编程语言中实施MCP的实践示例。您可以在`samples`目录中找到按语言组织的示例代码。

### 可用示例

仓库包括以下语言的示例实现：

- C#
- Java
- TypeScript
- JavaScript
- Python

每个示例都展示了该特定语言和生态系统的关键MCP概念和实施模式。

## 核心服务器功能

MCP服务器可以实施这些功能的任意组合：

### 资源
资源为用户或AI模型提供上下文和数据：
- 文档存储库
- 知识库
- 结构化数据源
- 文件系统

### 提示
提示是为用户提供的模板化消息和工作流：
- 预定义的对话模板
- 引导的互动模式
- 专门的对话结构

### 工具
工具是AI模型执行的功能：
- 数据处理实用程序
- 外部API集成
- 计算能力
- 搜索功能

## 示例实施：C#

官方C# SDK仓库包含几个示例实现，展示了MCP的不同方面：

- **基本MCP客户端**：简单示例展示如何创建MCP客户端并调用工具
- **基本MCP服务器**：具有基本工具注册的最小服务器实现
- **高级MCP服务器**：具有工具注册、身份验证和错误处理的完整功能服务器
- **ASP.NET集成**：展示与ASP.NET Core集成的示例
- **工具实施模式**：实施不同复杂级别工具的各种模式

MCP C# SDK处于预览阶段，API可能会更改。我们将随着SDK的演变不断更新此博客。

### 关键功能 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- 构建您的[第一个MCP服务器](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

有关完整的C#实现示例，请访问[官方C# SDK示例仓库](https://github.com/modelcontextprotocol/csharp-sdk)

## 示例实施：Java实施

Java SDK提供了具有企业级功能的稳健MCP实施选项。

### 关键功能

- Spring Framework集成
- 强类型安全
- 支持反应式编程
- 全面的错误处理

有关完整的Java实现示例，请参见samples目录中的[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)。

## 示例实施：JavaScript实施

JavaScript SDK提供了一种轻量级和灵活的MCP实施方法。

### 关键功能

- Node.js和浏览器支持
- 基于Promise的API
- 与Express和其他框架的轻松集成
- 支持WebSocket流

有关完整的JavaScript实现示例，请参见samples目录中的[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)。

## 示例实施：Python实施

Python SDK提供了一种符合Python风格的MCP实施方法，并具有出色的ML框架集成。

### 关键功能

- 使用asyncio支持异步/等待
- Flask和FastAPI集成
- 简单的工具注册
- 与流行的ML库的原生集成

有关完整的Python实现示例，请参见samples目录中的[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)。

## API管理 

Azure API Management是如何保护MCP服务器的绝佳答案。其理念是在您的MCP服务器前面放置一个Azure API Management实例，并让它处理您可能想要的功能，例如：

- 限速
- 令牌管理
- 监控
- 负载均衡
- 安全性

### Azure示例

这是一个Azure示例，正是这样做的，即[创建MCP服务器并使用Azure API Management进行保护](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

查看下面图片中的授权流程是如何进行的：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

在前面的图片中，发生了以下情况：

- 使用Microsoft Entra进行身份验证/授权。
- Azure API Management充当网关，并使用策略来引导和管理流量。
- Azure Monitor记录所有请求以进行进一步分析。

#### 授权流程

让我们更详细地看看授权流程：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP授权规范

了解有关[MCP授权规范](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)的更多信息

## 部署远程MCP服务器到Azure

让我们看看我们是否可以部署我们之前提到的示例：

1. 克隆仓库

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. 注册`Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` 一段时间后检查注册是否完成。

2. 运行此[azd](https://aka.ms/azd)命令来提供API管理服务、函数应用（含代码）和所有其他所需的Azure资源

    ```shell
    azd up
    ```

    此命令应在Azure上部署所有云资源

### 使用MCP Inspector测试您的服务器

1. 在一个**新终端窗口**中，安装并运行MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    您应该看到一个类似于以下的界面：

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.mo.png)

1. CTRL点击从应用显示的URL加载MCP Inspector Web应用（例如http://127.0.0.1:6274/#resources）
1. 将传输类型设置为`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`并**连接**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **列出工具**。 点击一个工具并**运行工具**。  

如果所有步骤都成功，您现在应该已连接到MCP服务器，并且您能够调用一个工具。

## Azure的MCP服务器 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：这组仓库是使用Azure Functions与Python、C# .NET或Node/TypeScript构建和部署自定义远程MCP（模型上下文协议）服务器的快速启动模板。

样本提供了一个完整的解决方案，允许开发人员：

- 本地构建和运行：在本地机器上开发和调试MCP服务器
- 部署到Azure：使用简单的azd up命令轻松部署到云端
- 从客户端连接：从各种客户端连接到MCP服务器，包括VS Code的Copilot代理模式和MCP Inspector工具

### 关键功能：

- 设计安全性：MCP服务器使用密钥和HTTPS进行保护
- 身份验证选项：支持使用内置身份验证和/或API管理进行OAuth
- 网络隔离：允许使用Azure虚拟网络（VNET）进行网络隔离
- 无服务器架构：利用Azure Functions进行可扩展的事件驱动执行
- 本地开发：全面的本地开发和调试支持
- 简单部署：简化的Azure部署过程

仓库包括所有必要的配置文件、源代码和基础设施定义，以快速开始生产就绪的MCP服务器实施。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用Azure Functions和Python实施MCP的示例

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用Azure Functions和C# .NET实施MCP的示例

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用Azure Functions和Node/TypeScript实施MCP的示例。

## 关键要点

- MCP SDK提供了语言特定的工具用于实施稳健的MCP解决方案
- 调试和测试过程对于可靠的MCP应用程序至关重要
- 可重用的提示模板使AI交互一致
- 设计良好的工作流可以使用多个工具协调复杂任务
- 实施MCP解决方案需要考虑安全性、性能和错误处理

## 练习

设计一个实用的MCP工作流，以解决您领域中的现实问题：

1. 确定3-4个对解决此问题有用的工具
2. 创建一个工作流图，显示这些工具如何交互
3. 使用您偏爱的语言实施其中一个工具的基本版本
4. 创建一个提示模板，以帮助模型有效地使用您的工具

## 附加资源

---

下一步：[高级主题](../05-AdvancedTopics/README.md)

I'm sorry, but it seems like "mo" is not a recognized language code. Could you please clarify which language you would like the text translated into?