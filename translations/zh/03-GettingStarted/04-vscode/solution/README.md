<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:19:12+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "zh"
}
-->
# 运行示例

这里假设你已经有一个可用的服务器代码。请从前面的章节中找到一个服务器。

## 设置 mcp.json

这是一个供你参考的文件，[mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)。

根据需要修改 server 条目，指明你的服务器的绝对路径以及运行所需的完整命令。

在上面提到的示例文件中，server 条目如下所示：

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

这对应于运行如下命令：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，输入类似“add 3 to 20”的内容。

    你应该会看到聊天文本框上方出现一个工具，提示你选择运行该工具，如下图所示：

    ![VS Code 指示想要运行工具](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.zh.png)

    选择该工具后，如果你的提示如前所述，应该会得到一个数值结果“23”。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误读，我们不承担任何责任。