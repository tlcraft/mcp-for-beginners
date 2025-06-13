<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:52:42+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "zh"
}
-->
### -2- 创建项目

既然你已经安装了 SDK，接下来我们创建一个项目：

### -3- 创建项目文件

### -4- 编写服务器代码

### -5- 添加工具和资源

通过添加以下代码，给服务器添加一个工具和一个资源：

### -6- 完整代码

让我们添加启动服务器所需的最后代码：

### -7- 测试服务器

使用以下命令启动服务器：

### -8- 使用 Inspector 运行

Inspector 是一个很棒的工具，可以启动你的服务器并让你与之交互，从而测试其功能。让我们启动它：

> [!NOTE]
> “command”字段中的内容可能看起来不同，因为它包含了针对你所用运行时启动服务器的命令。

你应该会看到如下用户界面：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.zh.png)

1. 点击“Connect”按钮连接服务器  
   连接成功后，你应该会看到如下界面：

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.zh.png)

2. 选择“Tools”然后选择“listTools”，你会看到“Add”选项，点击“Add”并填写参数值。

   你应该会看到如下响应，也就是“add”工具的执行结果：

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.zh.png)

恭喜，你已经成功创建并运行了你的第一个服务器！

### 官方 SDK

MCP 提供多种语言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 与微软合作维护
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 与 Spring AI 合作维护
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 实现
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 实现
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 实现
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 与 Loopwork AI 合作维护
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 实现

## 关键要点

- 利用语言特定的 SDK，搭建 MCP 开发环境非常简单
- 构建 MCP 服务器需要创建并注册带有清晰模式的工具
- 测试和调试对于实现稳定可靠的 MCP 至关重要

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 练习

创建一个带有你选择的工具的简单 MCP 服务器：
1. 使用你喜欢的语言（.NET、Java、Python 或 JavaScript）实现该工具。
2. 定义输入参数和返回值。
3. 运行 inspector 工具，确保服务器正常工作。
4. 使用各种输入测试实现效果。

## 解决方案

[解决方案](./solution/README.md)

## 额外资源

- [在 Azure 上使用 Model Context Protocol 构建 Agents](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [使用 Azure Container Apps 远程 MCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 接下来

下一步：[MCP 客户端入门](/03-GettingStarted/02-client/README.md)

**免责声明**：  
本文件已使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们努力确保翻译的准确性，但请注意自动翻译可能包含错误或不准确之处。原始语言的文件应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。