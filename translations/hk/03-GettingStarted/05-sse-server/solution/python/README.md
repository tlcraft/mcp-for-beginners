<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:00:53+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hk"
}
-->
# 執行此範例

建議安裝 `uv`，但不是必須，請參閱[指示](https://docs.astral.sh/uv/#highlights)

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

在一個終端執行伺服器後，打開另一個終端並執行以下命令：

```bash
mcp dev server.py
```

這將啟動一個具有視覺介面的網絡伺服器，讓您測試範例。

伺服器連接後：

- 嘗試列出工具並執行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` 是其的封裝器。

您可以通過執行以下命令直接在 CLI 模式下啟動它：

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
> 在此處閱讀有關檢查器的更多信息[here](https://github.com/modelcontextprotocol/inspector)。

**免責聲明**：
本文件已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。應以原始文件的母語版本為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們對於使用此翻譯而引起的任何誤解或誤釋不承擔責任。