<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-16T14:55:10+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "zh"
}
-->
## 入门指南  

本节包含若干课程：

- **-1- 你的第一个服务器**，在本课中，你将学习如何创建你的第一个服务器，并使用检查工具进行调试，这是测试和调试服务器的宝贵方法，[前往课程](/03-GettingStarted/01-first-server/README.md)

- **-2- 客户端**，本课将教你如何编写一个可以连接到服务器的客户端，[前往课程](/03-GettingStarted/02-client/README.md)

- **-3- 带LLM的客户端**，更高级的客户端编写方式是为其添加LLM，使其能够与服务器“协商”执行的操作，[前往课程](/03-GettingStarted/03-llm-client/README.md)

- **-4- 在 Visual Studio Code 中使用服务器 GitHub Copilot 代理模式**。这里我们介绍如何在 Visual Studio Code 中运行 MCP Server，[前往课程](/03-GettingStarted/04-vscode/README.md)

- **-5- 通过 SSE（服务器发送事件）消费**。SSE 是一种服务器到客户端的流式传输标准，允许服务器通过 HTTP 向客户端推送实时更新，[前往课程](/03-GettingStarted/05-sse-server/README.md)

- **-6- 利用 VSCode 的 AI 工具包** 来消费和测试你的 MCP 客户端和服务器，[前往课程](/03-GettingStarted/06-aitk/README.md)

- **-7 测试**。本节重点介绍如何以多种方式测试我们的服务器和客户端，[前往课程](/03-GettingStarted/07-testing/README.md)

- **-8- 部署**。本章将探讨多种 MCP 解决方案的部署方式，[前往课程](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) 是一个开放协议，标准化了应用程序如何为 LLM 提供上下文。可以把 MCP 想象成 AI 应用的 USB-C 端口——它提供了一种标准化方式，将 AI 模型连接到不同的数据源和工具。

## 学习目标

完成本课后，你将能够：

- 为 C#、Java、Python、TypeScript 和 JavaScript 设置 MCP 开发环境
- 构建并部署具备自定义功能（资源、提示和工具）的基础 MCP 服务器
- 创建连接 MCP 服务器的宿主应用程序
- 测试和调试 MCP 实现
- 理解常见的配置难点及其解决方案
- 将你的 MCP 实现连接到主流的 LLM 服务

## 配置你的 MCP 环境

在开始 MCP 开发之前，准备好开发环境并了解基本工作流程非常重要。本节将引导你完成初始设置步骤，确保你能够顺利开始使用 MCP。

### 前置条件

开始 MCP 开发前，请确保你具备：

- **开发环境**：适用于你选择的语言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/编辑器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何现代代码编辑器
- **包管理器**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 密钥**：用于你计划在宿主应用中使用的任何 AI 服务


### 官方 SDK

接下来的章节中，你将看到使用 Python、TypeScript、Java 和 .NET 构建的解决方案。以下是所有官方支持的 SDK。

MCP 提供多语言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 与 Microsoft 共同维护
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 与 Spring AI 共同维护
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 实现
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 实现
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 实现
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 与 Loopwork AI 共同维护
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 实现

## 关键要点

- 使用针对不同语言的 SDK，搭建 MCP 开发环境非常简单
- 构建 MCP 服务器需要创建并注册带有清晰模式的工具
- MCP 客户端连接服务器和模型，以发挥扩展功能
- 测试和调试对可靠的 MCP 实现至关重要
- 部署选项涵盖本地开发到云端解决方案

## 练习

我们提供了一套示例，配合本节所有章节中的练习使用。此外，每章还有各自的练习和作业。

- [Java 计算器](./samples/java/calculator/README.md)
- [.Net 计算器](../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](./samples/javascript/README.md)
- [TypeScript 计算器](./samples/typescript/README.md)
- [Python 计算器](../../../03-GettingStarted/samples/python)

## 其他资源

- [MCP GitHub 仓库](https://github.com/microsoft/mcp-for-beginners)

## 接下来

下一步：[创建你的第一个 MCP 服务器](/03-GettingStarted/01-first-server/README.md)

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻译而成。虽然我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。