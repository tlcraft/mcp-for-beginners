<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-16T14:57:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "zh"
}
-->
太好了，接下来，让我们列出服务器上的功能。

### -2 列出服务器功能

现在我们将连接到服务器并请求其功能：

### -3 将服务器功能转换为 LLM 工具

列出服务器功能后，下一步是将它们转换为 LLM 能理解的格式。完成后，我们就可以将这些功能作为工具提供给我们的 LLM。

太好了，我们已经准备好处理用户请求了，接下来让我们解决这个问题。

### -4 处理用户提示请求

在这部分代码中，我们将处理用户请求。

太棒了，你完成了！

## 任务

使用练习中的代码，扩展服务器，添加更多工具。然后像练习中那样创建一个带有 LLM 的客户端，并用不同的提示进行测试，确保服务器上的所有工具都能被动态调用。这样构建客户端，最终用户可以通过提示而非精确的客户端命令进行操作，而无需关心是否调用了 MCP 服务器，从而获得更好的用户体验。

## 解决方案

[解决方案](/03-GettingStarted/03-llm-client/solution/README.md)

## 主要收获

- 给客户端添加 LLM，可以为用户提供更好的与 MCP 服务器交互方式。
- 需要将 MCP 服务器的响应转换成 LLM 能理解的格式。

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 其他资源

## 接下来

- 下一步：[使用 Visual Studio Code 访问服务器](/03-GettingStarted/04-vscode/README.md)

**免责声明**：  
本文件已使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于关键信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或曲解承担责任。