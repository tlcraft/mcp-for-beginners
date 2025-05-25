<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:53:55+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "hk"
}
-->
# 運行這個範例

## -1- 安裝依賴項

```bash
dotnet run
```

## -2- 運行範例

```bash
dotnet run
```

## -3- 測試範例

在運行下面命令之前，先啟動一個獨立的終端（確保服務器仍在運行）。

在一個終端運行服務器的情況下，打開另一個終端並運行以下命令：

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

這應該會啟動一個具有可視化界面的網絡服務器，讓你可以測試這個範例。

一旦服務器連接上：

- 嘗試列出工具並運行 `add`，參數為 2 和 4，結果應該是 6。
- 前往資源和資源模板，調用 "greeting"，輸入一個名字，你應該會看到帶有你提供的名字的問候。

### 在 CLI 模式下測試

你可以通過運行以下命令直接在 CLI 模式下啟動它：

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

這將列出服務器中所有可用的工具。你應該會看到以下輸出：

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

要調用工具，請輸入：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> 通常在 CLI 模式下運行檢查器比在瀏覽器中要快得多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於檢查器的信息。

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的本地語言版本應被視為權威來源。對於關鍵信息，建議使用專業人工翻譯。對於因使用此翻譯而產生的任何誤解或誤釋，我們不承擔責任。