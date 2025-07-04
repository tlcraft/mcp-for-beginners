<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T15:55:04+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "zh"
}
-->
## 入门指南  

本节包含多个课程：

- **1 你的第一个服务器**，在本课中，你将学习如何创建你的第一个服务器，并使用 inspector 工具进行检查，这是一种测试和调试服务器的有效方法，[查看课程](/03-GettingStarted/01-first-server/README.md)

- **2 客户端**，本课将教你如何编写一个可以连接到服务器的客户端，[查看课程](/03-GettingStarted/02-client/README.md)

- **3 带 LLM 的客户端**，更高级的客户端写法是为其添加一个 LLM，使其能够与服务器“协商”如何处理请求，[查看课程](/03-GettingStarted/03-llm-client/README.md)

- **4 在 Visual Studio Code 中使用 GitHub Copilot Agent 模式消费服务器**。这里我们将演示如何在 Visual Studio Code 中运行 MCP 服务器，[查看课程](/03-GettingStarted/04-vscode/README.md)

- **5 通过 SSE（服务器发送事件）消费**。SSE 是一种服务器到客户端的流式传输标准，允许服务器通过 HTTP 向客户端推送实时更新，[查看课程](/03-GettingStarted/05-sse-server/README.md)

- **6 使用 MCP 的 HTTP 流式传输（可流式 HTTP）**。了解现代 HTTP 流式传输、进度通知，以及如何使用可流式 HTTP 实现可扩展的实时 MCP 服务器和客户端，[查看课程](/03-GettingStarted/06-http-streaming/README.md)

- **7 利用 VSCode 的 AI 工具包** 来消费和测试你的 MCP 客户端和服务器，[查看课程](/03-GettingStarted/07-aitk/README.md)

- **8 测试**。本课重点介绍如何以多种方式测试服务器和客户端，[查看课程](/03-GettingStarted/08-testing/README.md)

- **9 部署**。本章将介绍多种部署 MCP 解决方案的方法，[查看课程](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) 是一个开放协议，标准化了应用程序向 LLM 提供上下文的方式。可以把 MCP 想象成 AI 应用的 USB-C 接口——它为连接 AI 模型与不同数据源和工具提供了统一的标准。

## 学习目标

完成本课后，你将能够：

- 为 C#、Java、Python、TypeScript 和 JavaScript 设置 MCP 开发环境
- 构建并部署带有自定义功能（资源、提示和工具）的基础 MCP 服务器
- 创建连接 MCP 服务器的宿主应用程序
- 测试和调试 MCP 实现
- 理解常见的设置难题及其解决方案
- 将你的 MCP 实现连接到主流 LLM 服务

## 设置你的 MCP 环境

在开始使用 MCP 之前，准备好开发环境并了解基本工作流程非常重要。本节将指导你完成初始设置步骤，确保你能顺利开始 MCP 开发。

### 前提条件

在开始 MCP 开发前，请确保你具备：

- **开发环境**：适用于你选择的语言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/编辑器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何现代代码编辑器
- **包管理器**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 密钥**：用于你计划在宿主应用中使用的任何 AI 服务

### 官方 SDK

接下来的章节中，你将看到使用 Python、TypeScript、Java 和 .NET 构建的解决方案。以下是所有官方支持的 SDK。

MCP 提供多语言官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 与 Microsoft 合作维护
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 与 Spring AI 合作维护
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 实现
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 实现
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 实现
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 与 Loopwork AI 合作维护
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 实现

## 关键要点

- 使用针对特定语言的 SDK，设置 MCP 开发环境非常简单
- 构建 MCP 服务器需要创建并注册带有清晰模式的工具
- MCP 客户端连接服务器和模型，以利用扩展功能
- 测试和调试对可靠的 MCP 实现至关重要
- 部署选项涵盖本地开发到云端解决方案

## 练习

我们提供了一套示例，配合本节所有章节中的练习使用。此外，每个章节也包含各自的练习和作业。

- [Java 计算器](./samples/java/calculator/README.md)
- [.Net 计算器](../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](./samples/javascript/README.md)
- [TypeScript 计算器](./samples/typescript/README.md)
- [Python 计算器](../../../03-GettingStarted/samples/python)

## 额外资源

- [使用 Model Context Protocol 在 Azure 上构建代理](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [使用 Azure Container Apps 远程 MCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP 代理](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 接下来

下一步：[创建你的第一个 MCP 服务器](./01-first-server/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。