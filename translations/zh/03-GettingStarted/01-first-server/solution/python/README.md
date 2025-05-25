<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-16T15:12:25+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

建议安装 `uv`，但不是必须，详见[instructions](https://docs.astral.sh/uv/#highlights)

## -0- 创建虚拟环境

```bash
python -m venv venv
```

## -1- 激活虚拟环境

```bash
venv\Scrips\activate
```

## -2- 安装依赖

```bash
pip install "mcp[cli]"
```

## -3- 运行示例

```bash
mcp run server.py
```

## -4- 测试示例

服务器在一个终端运行时，打开另一个终端并运行以下命令：

```bash
mcp dev server.py
```

这将启动一个带有可视化界面的网页服务器，方便你测试示例。

服务器连接后：

- 尝试列出工具并运行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` 是它的一个封装。

你也可以通过运行以下命令直接以 CLI 模式启动：

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

这会列出服务器中所有可用的工具。你应该能看到如下输出：

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> 通常在 CLI 模式下运行 inspector 会比在浏览器中快得多。
> 详细了解 inspector 请点击[这里](https://github.com/modelcontextprotocol/inspector)。

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻译而成。虽然我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。