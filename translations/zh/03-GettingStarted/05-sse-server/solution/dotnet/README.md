<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:49:58+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

## -1- 安装依赖

```bash
dotnet restore
```

## -2- 运行示例

```bash
dotnet run
```

## -3- 测试示例

在运行以下命令之前，请先打开一个单独的终端（确保服务器仍在运行）。

在一个终端运行服务器的同时，打开另一个终端并运行以下命令：

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

这将启动一个带有可视化界面的网页服务器，方便你测试示例。

> 确保传输类型选择的是 **SSE**，且 URL 为 `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`，参数为 2 和 4，结果应该显示为 6。  
> - 进入 resources 和 resource template，调用 "greeting"，输入一个名字，你应该会看到带有你输入名字的问候语。

### 在 CLI 模式下测试

你可以通过运行以下命令直接以 CLI 模式启动：

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

这会列出服务器上所有可用的工具。你应该会看到如下输出：

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

要调用某个工具，请输入：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

你应该会看到如下输出：

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]  
> 在 CLI 模式下运行 inspector 通常比在浏览器中更快。  
> 在这里了解更多关于 inspector 的信息：[here](https://github.com/modelcontextprotocol/inspector)。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。