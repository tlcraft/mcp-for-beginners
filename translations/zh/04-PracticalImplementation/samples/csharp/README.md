<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:47:14+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "zh"
}
-->
# 示例

前面的示例展示了如何使用本地的 .NET 项目和 `stdio` 类型，以及如何在容器中本地运行服务器。这在很多情况下都是一个不错的解决方案。然而，有时让服务器远程运行，比如在云环境中，会更有用。这时就用到了 `http` 类型。

看看 `04-PracticalImplementation` 文件夹中的解决方案，可能看起来比之前的要复杂得多。但实际上并非如此。如果仔细查看 `src/Calculator` 项目，你会发现它的代码大部分和之前的示例一样。唯一的区别是我们使用了不同的库 `ModelContextProtocol.AspNetCore` 来处理 HTTP 请求。并且我们把方法 `IsPrime` 改成了私有方法，仅仅是为了演示代码中可以有私有方法。其余代码和之前一样。

其他项目来自 [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview)。在解决方案中加入 .NET Aspire 可以提升开发和测试时的体验，并帮助进行可观测性。运行服务器时并不是必须的，但在解决方案中加入它是个好习惯。

## 本地启动服务器

1. 在 VS Code（安装了 C# DevKit 扩展）中，进入 `04-PracticalImplementation/samples/csharp` 目录。
2. 执行以下命令启动服务器：

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

3. 当网页浏览器打开 .NET Aspire 仪表盘时，记下 `http` 的 URL，通常类似于 `http://localhost:5058/`。

   ![.NET Aspire 仪表盘](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.zh.png)

## 使用 MCP Inspector 测试 Streamable HTTP

如果你安装了 Node.js 22.7.5 及以上版本，可以使用 MCP Inspector 测试你的服务器。

启动服务器后，在终端运行以下命令：

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.zh.png)

- 选择 `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`。它应该是 `http` （而不是 `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp`），之前创建的服务器应该长这样：

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

进行一些测试：

- 询问“6780 之后的 3 个质数”。注意 Copilot 会使用新工具 `NextFivePrimeNumbers`，并且只返回前 3 个质数。
- 询问“111 之后的 7 个质数”，看看结果。
- 询问“John 有 24 颗棒棒糖，要分给他的 3 个孩子，每个孩子能分到多少颗？”，观察结果。

## 部署服务器到 Azure

我们将服务器部署到 Azure，让更多人可以使用。

在终端中，进入 `04-PracticalImplementation/samples/csharp` 文件夹，运行以下命令：

```bash
azd up
```

部署完成后，你应该会看到类似这样的提示：

![Azd 部署成功](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.zh.png)

复制这个 URL，并在 MCP Inspector 和 GitHub Copilot Chat 中使用。

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## 接下来做什么？

我们尝试了不同的传输类型和测试工具，也将 MCP 服务器部署到了 Azure。但如果服务器需要访问私有资源呢？比如数据库或私有 API？下一章，我们将探讨如何提升服务器的安全性。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们努力保证准确性，但请注意自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或曲解承担责任。