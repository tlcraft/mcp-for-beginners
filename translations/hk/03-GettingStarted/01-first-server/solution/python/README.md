<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:14:24+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "hk"
}
-->
# 執行此範例

建議你安裝 `uv`，但這不是必須的，參見[說明](https://docs.astral.sh/uv/#highlights)

## -0- 建立虛擬環境

```bash
python -m venv venv
```

## -1- 啟動虛擬環境

```bash
venv\Scrips\activate
```

## -2- 安裝依賴

```bash
pip install "mcp[cli]"
```

## -3- 執行範例

```bash
mcp run server.py
```

## -4- 測試範例

在一個終端運行服務器，然後開啟另一個終端並執行以下命令：

```bash
mcp dev server.py
```

這將啟動一個帶有視覺介面的網絡服務器，允許你測試範例。

一旦服務器連接：

- 嘗試列出工具並運行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` 是其封裝器。

你可以通過運行以下命令直接在 CLI 模式下啟動它：

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

這將列出服務器中可用的所有工具。你應該會看到以下輸出：

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

要調用一個工具，請輸入：

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> 通常在 CLI 模式下運行檢查器比在瀏覽器中快很多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於檢查器的信息。

**免責聲明**：  
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原文文件作為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們不對使用本翻譯所產生的任何誤解或錯誤承擔責任。