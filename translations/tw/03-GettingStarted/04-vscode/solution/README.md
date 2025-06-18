<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5ef8f5821c1a04f7b1fc4f15098ecab8",
  "translation_date": "2025-06-18T05:51:25+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "tw"
}
-->
這相當於執行如下指令：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，輸入類似「add 3 to 20」的內容。

    你應該會在聊天文字框上方看到一個工具提示，提示你選擇執行該工具，如下圖所示：

    ![VS Code 指示它想執行一個工具](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tw.png)

    選擇該工具後，如果你的輸入如前所述，應該會顯示數字結果「23」。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生之任何誤解或誤釋負責。