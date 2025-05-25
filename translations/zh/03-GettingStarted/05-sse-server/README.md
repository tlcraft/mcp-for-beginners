<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-16T15:18:35+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "zh"
}
-->
现在我们对 SSE 有了更多了解，接下来让我们来构建一个 SSE 服务器。

## 练习：创建一个 SSE 服务器

要创建我们的服务器，需要牢记两点：

- 需要使用一个 Web 服务器来暴露连接和消息的端点。
- 像使用 stdio 时一样构建服务器，包含工具、资源和提示。

### -1- 创建服务器实例

创建服务器时，我们使用和 stdio 相同的类型。但传输方式需要选择 SSE。 

接下来我们添加所需的路由。

### -2- 添加路由

接下来添加处理连接和传入消息的路由：

接下来给服务器添加功能。

### -3- 添加服务器功能

既然我们已经定义了所有 SSE 相关内容，现在添加服务器功能，如工具、提示和资源。

完整代码应如下所示：

太好了，我们已经有了一个使用 SSE 的服务器，接下来来试运行一下。

## 练习：使用 Inspector 调试 SSE 服务器

Inspector 是一个很棒的工具，我们在之前的课程[创建你的第一个服务器](/03-GettingStarted/01-first-server/README.md)中已经见过。让我们看看是否也能用 Inspector 调试 SSE 服务器：

### -1- 运行 Inspector

要运行 Inspector，首先必须有一个 SSE 服务器在运行，接下来我们启动服务器：

1. 运行服务器

1. 运行 Inspector

    > ![NOTE]
    > 请在与服务器不同的终端窗口运行此命令。同时请根据你的服务器实际运行的 URL 调整下面的命令。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    在所有运行时环境中，运行 Inspector 的方式相同。注意这里我们不是传入服务器路径和启动服务器的命令，而是传入服务器运行的 URL，并指定了 `/sse` 路由。

### -2- 试用该工具

通过下拉列表选择 SSE，然后填写服务器运行的 URL，例如 http://localhost:4321/sse。点击“连接”按钮。和之前一样，选择列出工具，选中一个工具并输入参数。你应该会看到如下结果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.zh.png)

很好，你已经能使用 Inspector 了，接下来看看如何用 Visual Studio Code 来使用 SSE 服务器。

## 任务

尝试为你的服务器添加更多功能。参考[这个页面](https://api.chucknorris.io/)添加一个调用 API 的工具，服务器的具体功能由你决定。玩得开心 :)

## 解决方案

[解决方案](./solution/README.md) 这里有一个可用的示例代码。

## 关键要点

本章的关键要点如下：

- SSE 是继 stdio 之后支持的第二种传输方式。
- 支持 SSE 需要使用 Web 框架管理传入的连接和消息。
- 你可以使用 Inspector 和 Visual Studio Code 来消费 SSE 服务器，就像使用 stdio 服务器一样。注意 stdio 和 SSE 之间有些许差别。对于 SSE，你需要先单独启动服务器，再运行 Inspector 工具。Inspector 工具还需要你指定服务器的 URL。

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 额外资源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 接下来

- 下一步：[VSCode AI 工具包入门](/03-GettingStarted/06-aitk/README.md)

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。因使用本翻译而产生的任何误解或曲解，我们概不负责。