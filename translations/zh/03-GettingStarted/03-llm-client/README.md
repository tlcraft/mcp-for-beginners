<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T15:57:37+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "zh"
}
-->
太好了，接下来，让我们列出服务器上的功能。

### -2 列出服务器功能

现在我们将连接到服务器并请求其功能列表：

### -3 将服务器功能转换为LLM工具

列出服务器功能后，下一步是将它们转换成LLM能够理解的格式。一旦完成，我们就可以将这些功能作为工具提供给我们的LLM。

太好了，我们还没有设置处理用户请求的功能，接下来让我们解决这个问题。

### -4 处理用户提示请求

在这部分代码中，我们将处理用户请求。

太棒了，你完成了！

## 任务

使用练习中的代码，扩展服务器，添加更多工具。然后像练习中那样创建一个带有LLM的客户端，并用不同的提示进行测试，确保服务器上的所有工具都能被动态调用。通过这种方式构建客户端，最终用户将获得极佳的使用体验，因为他们可以使用自然语言提示，而不必输入精确的客户端命令，也无需知道背后调用了任何MCP服务器。

## 解决方案

[解决方案](/03-GettingStarted/03-llm-client/solution/README.md)

## 关键要点

- 给客户端添加LLM，为用户与MCP服务器的交互提供了更好的方式。
- 需要将MCP服务器的响应转换成LLM能够理解的格式。

## 示例

- [Java计算器](../samples/java/calculator/README.md)
- [.Net计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript计算器](../samples/javascript/README.md)
- [TypeScript计算器](../samples/typescript/README.md)
- [Python计算器](../../../../03-GettingStarted/samples/python)

## 额外资源

## 接下来

- 下一步：[使用Visual Studio Code调用服务器](../04-vscode/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。