<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:26:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "zh"
}
-->
很好，接下来，让我们列出服务器上的能力。

### -2 列出服务器能力

现在我们将连接到服务器并请求它的能力：


### -3- 将服务器能力转换为LLM工具

列出服务器能力后的下一步是将它们转换为LLM能够理解的格式。一旦完成，我们就可以将这些能力作为工具提供给我们的LLM。


很好，我们已经准备好处理用户请求了，接下来让我们来实现这一部分。

### -4- 处理用户提示请求

在这部分代码中，我们将处理用户的请求。


太棒了，你完成了！

## 任务

使用练习中的代码，扩展服务器，添加更多工具。然后像练习中那样创建一个带有LLM的客户端，并用不同的提示进行测试，确保所有服务器工具都能动态调用。通过这种方式构建客户端，最终用户将拥有出色的体验，因为他们可以使用自然语言提示，而不必输入精确的客户端命令，也无需关心是否调用了MCP服务器。

## 解决方案

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## 关键要点

- 给客户端添加LLM，能为用户提供更好的与MCP服务器交互方式。
- 需要将MCP服务器的响应转换成LLM能理解的格式。

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 额外资源

## 下一步

- 下一步：[使用 Visual Studio Code 调用服务器](/03-GettingStarted/04-vscode/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们努力确保准确性，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。