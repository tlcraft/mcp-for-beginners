<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:02:23+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "zh"
}
-->
很好，下一步，我们来列出服务器上的能力。

### -2 列出服务器能力

现在我们将连接到服务器并请求其能力列表：

### -3 将服务器能力转换为 LLM 工具

列出服务器能力后，下一步是将它们转换为 LLM 能理解的格式。一旦完成，我们就可以将这些能力作为工具提供给我们的 LLM。

很好，现在我们已经准备好处理用户请求，接下来开始吧。

### -4 处理用户提示请求

在这部分代码中，我们将处理用户的请求。

太棒了，你完成了！

## 作业

请使用练习中的代码，扩展服务器，添加更多工具。然后像练习中那样创建一个带有 LLM 的客户端，并使用不同的提示进行测试，确保服务器上的所有工具都能动态调用。通过这种方式构建客户端，最终用户将获得更好的体验，因为他们可以使用自然语言提示，而无需精确的客户端命令，同时无需关注是否调用了 MCP 服务器。

## 解决方案

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 关键要点

- 给客户端添加 LLM，可以为用户提供更好的与 MCP 服务器交互方式。
- 需要将 MCP 服务器的响应转换为 LLM 能理解的格式。

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 额外资源

## 接下来

- 下一步：[使用 Visual Studio Code 调用服务器](/03-GettingStarted/04-vscode/README.md)

**免责声明**：  
本文件使用AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)进行翻译。尽管我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于重要信息，建议使用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。