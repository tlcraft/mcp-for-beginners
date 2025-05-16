<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-16T15:11:35+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

## -1- 安装依赖

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- 运行示例

```bash
dotnet run
```

## -4- 测试示例

在一个终端运行服务器后，打开另一个终端并运行以下命令：

```bash
npx @modelcontextprotocol/inspector dotnet run
```

这将启动一个带有可视界面的 Web 服务器，方便你测试示例。

服务器连接成功后：

- 尝试列出工具并运行 `add`，参数为 2 和 4，你应该能看到结果为 6。
- 进入 resources 和 resource template，调用 "greeting"，输入一个名字，你会看到带有你输入名字的问候语。

### 在 CLI 模式下测试

你可以通过运行以下命令直接以 CLI 模式启动：

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

这会列出服务器上所有可用的工具。你应该能看到如下输出：

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
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
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

你会看到如下输出：

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> 通常在 CLI 模式下运行 inspector 会比在浏览器中快很多。
> 点击[这里](https://github.com/modelcontextprotocol/inspector)了解更多关于 inspector 的信息。

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译而成。虽然我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。