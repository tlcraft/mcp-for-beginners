<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5ef8f5821c1a04f7b1fc4f15098ecab8",
  "translation_date": "2025-06-18T05:49:50+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "zh"
}
-->
这相当于运行如下命令：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，然后输入类似“add 3 to 20”的内容。

你应该会在聊天文本框上方看到一个工具提示，提示你选择运行该工具，界面效果如下图所示：

![VS Code 指示它想运行一个工具](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.zh.png)

选择该工具后，如果你的输入如前所述，应该会得到一个数值结果“23”。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言版本的文件应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译内容而产生的任何误解或误释，我们概不负责。