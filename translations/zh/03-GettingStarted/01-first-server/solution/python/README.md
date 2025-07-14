<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-13T17:58:21+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

建议安装 `uv`，但不是必须，详情请参见 [instructions](https://docs.astral.sh/uv/#highlights)

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

在一个终端运行服务器后，打开另一个终端并执行以下命令：

```bash
mcp dev server.py
```

这将启动一个带有可视界面的网页服务器，方便你测试示例。

服务器连接后：

- 尝试列出工具并运行 `add`，传入参数 2 和 4，结果应显示 6。

- 进入 resources 和 resource template，调用 get_greeting，输入一个名字，你将看到带有你输入名字的问候语。

### 在 CLI 模式下测试

你运行的 inspector 实际上是一个 Node.js 应用，而 `mcp dev` 是它的一个包装器。

你可以通过运行以下命令直接以 CLI 模式启动它：

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

这会列出服务器上所有可用的工具。你应该看到如下输出：

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
> 通常在 CLI 模式下运行 inspector 比在浏览器中快得多。
> 详情请参见 [here](https://github.com/modelcontextprotocol/inspector)。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。