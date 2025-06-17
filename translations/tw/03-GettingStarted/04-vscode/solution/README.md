<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:23:54+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "tw"
}
-->
# 執行範例

這裡假設你已經有一個可運作的伺服器程式碼。請從前面章節中找到一個伺服器。

## 設定 mcp.json

這是一個供你參考的檔案，[mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)。

根據需要修改 server 項目，指定你的伺服器的絕對路徑以及執行該伺服器所需的完整命令。

在上述範例檔案中，server 項目長這樣：

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

這對應到執行類似以下的指令：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，輸入像是「add 3 to 20」的字串。

    你應該會看到聊天文字框上方出現一個工具提示，提示你選擇執行該工具，如下圖所示：

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tw.png)

    選擇該工具後，如果你的提示如前述，應該會得到一個數字結果「23」。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。本公司對因使用本翻譯而產生的任何誤解或誤譯概不負責。