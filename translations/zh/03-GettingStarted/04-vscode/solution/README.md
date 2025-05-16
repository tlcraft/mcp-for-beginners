<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-16T15:16:07+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "zh"
}
-->
# 运行示例

这里假设你已经有一个可用的服务器代码。请从之前的章节中找到一个服务器。

## 配置 mcp.json

这里有一个供参考的文件，[mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)。

根据需要修改 server 条目，指明服务器的绝对路径以及运行所需的完整命令。

在上面提到的示例文件中，server 条目如下所示：

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

这相当于运行如下命令：`cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，输入类似“add 3 to 20”的内容。

    你应该会在聊天文本框上方看到一个工具提示，提示你选择运行该工具，如下图所示：

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.zh.png)

    选择该工具后，如果你的提示如前所述，应会得到一个数字结果“23”。

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译而成。尽管我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。