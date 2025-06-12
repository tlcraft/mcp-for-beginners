<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T21:15:07+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "zh"
}
-->
现在我们对SSE有了更多了解，接下来让我们来构建一个SSE服务器。

## 练习：创建一个SSE服务器

创建服务器时，我们需要记住两点：

- 需要使用一个Web服务器来暴露连接和消息的端点。
- 像使用stdio时一样，使用工具、资源和提示来构建服务器。

### -1- 创建服务器实例

创建服务器时，我们使用和stdio相同的类型。不过，传输方式需要选择SSE。 

接下来让我们添加所需的路由。

### -2- 添加路由

接下来添加处理连接和传入消息的路由：

接下来为服务器添加功能。

### -3- 添加服务器功能

既然已经定义了所有SSE特定的内容，接下来添加服务器功能，比如工具、提示和资源。

你的完整代码应该如下所示：

太好了，我们已经有了一个使用SSE的服务器，接下来让我们来试用一下。

## 练习：使用Inspector调试SSE服务器

Inspector是一个非常棒的工具，我们在之前的课程[创建你的第一个服务器](/03-GettingStarted/01-first-server/README.md)中已经见过。让我们看看能否在这里也使用Inspector：

### -1- 运行Inspector

要运行Inspector，首先必须有一个正在运行的SSE服务器，所以先启动服务器：

1. 运行服务器

1. 运行Inspector

    > ![NOTE]
    > 请在与服务器不同的终端窗口中运行此命令。同时注意，需要根据你的服务器运行的URL调整下面的命令。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    在所有运行时中，运行Inspector的方式都是一样的。注意这里我们不是传递服务器的路径和启动服务器的命令，而是传递服务器运行的URL，并且指定了`/sse`路由。

### -2- 试用工具

通过下拉列表选择SSE，并填写服务器运行的URL，例如 http:localhost:4321/sse。然后点击“Connect”按钮。和之前一样，选择列出工具，选择一个工具并提供输入值。你应该会看到如下结果：

![Inspector中运行的SSE服务器](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.zh.png)

太棒了，你已经能够使用Inspector了，接下来看看如何用Visual Studio Code进行操作。

## 任务

尝试为你的服务器添加更多功能。可以参考[这个页面](https://api.chucknorris.io/)来添加调用API的工具，服务器的具体样子由你决定。玩得开心 :)

## 解决方案

[解决方案](./solution/README.md) 这是一个可运行代码的示例解决方案。

## 主要收获

本章的主要收获如下：

- SSE是继stdio之后支持的第二种传输方式。
- 支持SSE需要使用Web框架来管理传入连接和消息。
- 你可以像使用stdio服务器一样使用Inspector和Visual Studio Code来消费SSE服务器。注意stdio和SSE之间有些许不同。对于SSE，需要先单独启动服务器，然后再运行Inspector工具。对于Inspector工具，还需要指定URL。

## 示例

- [Java计算器](../samples/java/calculator/README.md)
- [.Net计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript计算器](../samples/javascript/README.md)
- [TypeScript计算器](../samples/typescript/README.md)
- [Python计算器](../../../../03-GettingStarted/samples/python) 

## 额外资源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 接下来

- 下一步：[使用MCP的HTTP流（可流式HTTP）](/03-GettingStarted/06-http-streaming/README.md)

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译而成。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。