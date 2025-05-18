<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:21:37+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "hk"
}
-->
# 執行此範例

建議你安裝`uv`，但不是必須的，請參閱[說明](https://docs.astral.sh/uv/#highlights)

## -1- 安裝依賴項

```bash
npm install
```

## -3- 執行範例

```bash
npm run build
```

## -4- 測試範例

在一個終端運行伺服器後，打開另一個終端並運行以下命令：

```bash
npm run inspector
```

這應該會啟動一個帶有可視介面的網頁伺服器，讓你可以測試這個範例。

一旦伺服器連接上：

- 嘗試列出工具並運行`add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev`，這是一個封裝器。

你可以通過運行以下命令直接在CLI模式下啟動它：

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

這將列出伺服器中可用的所有工具。你應該會看到以下輸出：

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

要調用一個工具，輸入：

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

你應該會看到以下輸出：

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
> 通常在CLI模式下運行檢查器比在瀏覽器中快得多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於檢查器的內容。

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們對使用此翻譯而產生的任何誤解或誤釋不承擔責任。