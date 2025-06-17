<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:22:23+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hk"
}
-->
# 運行範例

這裡假設你已經有一個可運作的伺服器程式碼。請從之前的章節中找到一個伺服器。

## 設定 mcp.json

這裡有一個供參考的檔案，[mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)。

根據需要更改 server 項目，指出你的伺服器的絕對路徑，以及執行所需的完整命令。

在上述範例檔案中，server 項目看起來像這樣：

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

這對應執行像這樣的命令：`node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`，輸入類似「add 3 to 20」的內容。

    你應該會看到聊天文字框上方出現一個工具，提示你選擇執行該工具，如下圖所示：

    ![VS Code 指示它想執行工具](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hk.png)

    選擇該工具後，如果你的輸入如前所述，應該會產生數字結果「23」。

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用此翻譯而產生的任何誤解或誤釋不承擔任何責任。