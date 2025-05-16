<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-16T15:21:19+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

## -1- 安装依赖

```bash
dotnet run
```

## -2- 运行示例

```bash
dotnet run
```

## -3- 测试示例

在运行以下命令前，请先打开一个新的终端（确保服务器仍在运行）。

服务器在一个终端运行时，打开另一个终端并运行以下命令：

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

这将启动一个带有可视界面的网页服务器，方便你测试示例。

服务器连接成功后：

- 尝试列出工具并运行 `add`，参数为 2 和 4，结果应显示 6。
- 进入 resources 和 resource template，调用 "greeting"，输入一个名字，你将看到带有该名字的问候语。

### 在 CLI 模式下测试

你可以通过运行以下命令直接启动 CLI 模式：

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

这会列出服务器中所有可用的工具。你应该看到如下输出：

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

调用工具时输入：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

你应该看到如下输出：

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
> 在 CLI 模式下运行 inspector 通常比在浏览器中快得多。
> 更多关于 inspector 的信息请查看[这里](https://github.com/modelcontextprotocol/inspector)。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。