<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-16T15:10:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

建议你安装 `uv`，但不是必须，详见[说明](https://docs.astral.sh/uv/#highlights)

## -1- 安装依赖

```bash
npm install
```

## -3- 运行示例

```bash
npm run build
```

## -4- 测试示例

在一个终端运行服务器的同时，打开另一个终端并执行以下命令：

```bash
npm run inspector
```

这将启动一个带有可视界面的网页服务器，方便你测试示例。

服务器连接后：

- 尝试列出工具并运行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` 是它的一个封装。

你也可以直接通过 CLI 模式运行，执行以下命令：

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

这会列出服务器上所有可用的工具。你应该会看到如下输出：

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

调用工具时输入：

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> 通常在 CLI 模式下运行 inspector 会比在浏览器中快很多。
> 详情请阅读关于 inspector 的介绍 [这里](https://github.com/modelcontextprotocol/inspector)。

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译而成。虽然我们努力确保翻译的准确性，但请注意，自动翻译可能包含错误或不准确之处。原始语言版本的文件应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。