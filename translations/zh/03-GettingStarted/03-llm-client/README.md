<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:45:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "zh"
}
-->
太棒了，接下来，让我们列出服务器上的能力。

### -2 列出服务器能力

现在我们将连接到服务器并请求它的能力：


### -3 将服务器能力转换为LLM工具

列出服务器能力的下一步是将它们转换成LLM能理解的格式。一旦完成，我们就可以把这些能力作为工具提供给我们的LLM。


太好了，我们还没有设置处理用户请求的功能，所以接下来让我们解决这个问题。

### -4 处理用户提示请求

在代码的这一部分，我们将处理用户请求。


太棒了，你完成了！

## 任务

将练习中的代码拿出来，给服务器添加更多工具。然后像练习中那样创建一个带有LLM的客户端，并用不同的提示测试，确保服务器上的所有工具都能被动态调用。通过这种方式构建客户端，最终用户将拥有更好的使用体验，因为他们可以使用自然语言提示，而不是精确的客户端命令，而且不需要关心背后是否调用了MCP服务器。

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

## 其他资源

## 接下来

- 下一步：[使用Visual Studio Code调用服务器](/03-GettingStarted/04-vscode/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们努力确保准确性，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们不承担任何责任。