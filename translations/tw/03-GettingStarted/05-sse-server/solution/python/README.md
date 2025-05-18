<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:01:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

建議安裝 `uv`，但不是必須的，請參閱[說明](https://docs.astral.sh/uv/#highlights)

## -0- 建立虛擬環境

```bash
python -m venv venv
```

## -1- 啟動虛擬環境

```bash
venv\Scrips\activate
```

## -2- 安裝依賴項

```bash
pip install "mcp[cli]"
```

## -3- 執行範例

```bash
mcp run server.py
```

## -4- 測試範例

在一個終端機中啟動伺服器，然後在另一個終端機中執行以下命令：

```bash
mcp dev server.py
```

這將啟動一個帶有視覺介面的網頁伺服器，讓您可以測試範例。

一旦伺服器連接：

- 嘗試列出工具並執行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` 是它的包裝器。

您可以直接在 CLI 模式中啟動它，方法是執行以下命令：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

這將列出伺服器中所有可用的工具。您應該看到以下輸出：

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

要調用工具，請輸入：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

您應該看到以下輸出：

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
> 通常在 CLI 模式下運行檢查器比在瀏覽器中要快得多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於檢查器的內容。

**免責聲明**：

本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。應將原始語言的文件視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對因使用此翻譯而產生的任何誤解或誤讀不承擔責任。