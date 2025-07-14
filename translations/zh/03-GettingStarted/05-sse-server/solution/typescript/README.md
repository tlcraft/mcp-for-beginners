<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:18:46+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

## -1- 安装依赖

```bash
npm install
```

## -3- 运行示例

```bash
npm run build
```

## -4- 测试示例

在一个终端中启动服务器后，打开另一个终端并运行以下命令：

```bash
npm run inspector
```

这将启动一个带有可视界面的网页服务器，方便你测试示例。

服务器连接后：

- 尝试列出工具并运行 `add`，参数为 2 和 4，结果应显示 6。
- 进入 resources 和 resource template，调用 "greeting"，输入一个名字，你将看到带有你输入名字的问候语。

### 在 CLI 模式下测试

你运行的 inspector 实际上是一个 Node.js 应用，而 `mcp dev` 是它的一个封装。

- 使用命令 `npm run build` 启动服务器。

- 在另一个终端运行以下命令：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    这将列出服务器中所有可用的工具。你应该看到如下输出：

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

- 通过输入以下命令调用某个工具类型：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

你应该看到如下输出：

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> 在 CLI 模式下运行 inspector 通常比在浏览器中快得多。
> 你可以在[这里](https://github.com/modelcontextprotocol/inspector)了解更多关于 inspector 的信息。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言的原文应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。