<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:20:06+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "zh"
}
-->
## 入门  

本节包含多个课程：

- **-1- 你的第一个服务器**，在本课中，你将学习如何创建第一个服务器，并使用检查工具进行检查，这是一种测试和调试服务器的有效方法，[查看课程](/03-GettingStarted/01-first-server/README.md)

- **-2- 客户端**，本课将教你如何编写能够连接到服务器的客户端，[查看课程](/03-GettingStarted/02-client/README.md)

- **-3- 带有LLM的客户端**，更高级的客户端写法是为其添加一个LLM，这样它可以与服务器“协商”下一步操作，[查看课程](/03-GettingStarted/03-llm-client/README.md)

- **-4- 在Visual Studio Code中使用服务器GitHub Copilot代理模式**。本节介绍如何在Visual Studio Code中运行我们的MCP服务器，[查看课程](/03-GettingStarted/04-vscode/README.md)

- **-5- 通过SSE（服务器发送事件）进行消费**。SSE是一种服务器到客户端的流式传输标准，允许服务器通过HTTP向客户端推送实时更新，[查看课程](/03-GettingStarted/05-sse-server/README.md)

- **-6- 利用VSCode的AI工具包**来使用和测试你的MCP客户端和服务器，[查看课程](/03-GettingStarted/06-aitk/README.md)

- **-7 测试**。本节重点介绍如何以不同方式测试服务器和客户端，[查看课程](/03-GettingStarted/07-testing/README.md)

- **-8- 部署**。本章将介绍多种部署MCP解决方案的方法，[查看课程](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) 是一个开放协议，用于标准化应用程序向LLM提供上下文的方式。可以把MCP看作AI应用的USB-C接口——它提供了一种标准化的方式，将AI模型连接到不同的数据源和工具。

## 学习目标

完成本课后，你将能够：

- 在C#、Java、Python、TypeScript和JavaScript中搭建MCP开发环境
- 构建并部署带有自定义功能（资源、提示和工具）的基础MCP服务器
- 创建连接到MCP服务器的宿主应用程序
- 测试和调试MCP实现
- 理解常见的设置问题及其解决方案
- 将你的MCP实现连接到流行的LLM服务

## 搭建你的MCP环境

在开始使用MCP之前，准备好开发环境并了解基本工作流程非常重要。本节将引导你完成初始设置步骤，确保顺利开始MCP开发。

### 先决条件

开始MCP开发前，请确保你具备：

- **开发环境**：适用于你选择的语言（C#、Java、Python、TypeScript或JavaScript）
- **IDE/编辑器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm或任何现代代码编辑器
- **包管理工具**：NuGet、Maven/Gradle、pip或npm/yarn
- **API密钥**：用于你计划在宿主应用中使用的任何AI服务

### 官方SDK

接下来的章节中，你将看到使用Python、TypeScript、Java和.NET构建的解决方案。以下是所有官方支持的SDK。

MCP提供多语言的官方SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 与Microsoft合作维护
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 与Spring AI合作维护
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方TypeScript实现
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方Python实现
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方Kotlin实现
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 与Loopwork AI合作维护
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方Rust实现

## 关键要点

- 使用语言特定的SDK，搭建MCP开发环境非常简单
- 构建MCP服务器需要创建并注册带有清晰架构的工具
- MCP客户端连接服务器和模型，以利用扩展功能
- 测试和调试对可靠的MCP实现至关重要
- 部署选项涵盖从本地开发到云端解决方案

## 练习

我们提供了一组示例，配合本节所有章节中的练习使用。此外，每章还有各自的练习和任务。

- [Java计算器](./samples/java/calculator/README.md)
- [.Net计算器](../../../03-GettingStarted/samples/csharp)
- [JavaScript计算器](./samples/javascript/README.md)
- [TypeScript计算器](./samples/typescript/README.md)
- [Python计算器](../../../03-GettingStarted/samples/python)

## 额外资源

- [使用Model Context Protocol在Azure上构建代理](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [通过Azure Container Apps远程使用MCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP代理](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 接下来

下一步：[创建你的第一个MCP服务器](/03-GettingStarted/01-first-server/README.md)

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻译而成。尽管我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。