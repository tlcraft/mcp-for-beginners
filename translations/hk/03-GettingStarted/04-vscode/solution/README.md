<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5ef8f5821c1a04f7b1fc4f15098ecab8",
  "translation_date": "2025-06-18T05:50:52+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hk"
}
-->
這相當於執行如下命令：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，然後輸入類似「add 3 to 20」的內容。

你應該會在聊天文字框上方看到一個工具提示，提示你選擇執行該工具，如下圖所示：

![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hk.png)

選擇該工具後，如果你的提示如前所述，應該會得到一個數字結果「23」。

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。因使用本翻譯而引致的任何誤解或誤釋，我們概不負責。