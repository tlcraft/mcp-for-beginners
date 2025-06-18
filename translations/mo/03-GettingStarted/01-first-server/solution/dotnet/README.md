<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:50:24+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "mo"
}
-->
# 執行此範例

## -1- 安裝相依套件

```bash
dotnet restore
```

## -3- 執行範例


```bash
dotnet run
```

## -4- 測試範例

在一個終端機啟動伺服器後，開啟另一個終端機並執行以下指令：

```bash
npx @modelcontextprotocol/inspector dotnet run
```

這會啟動一個具有視覺介面的網頁伺服器，讓你能測試範例。

伺服器連線後：

- 嘗試列出工具並執行 `add`，帶入參數 2 和 4，結果應該會顯示 6。
- 前往 resources 和 resource template，呼叫 "greeting"，輸入一個名字，你應該會看到包含該名字的問候語。

### 在 CLI 模式下測試

你可以透過執行以下指令直接以 CLI 模式啟動：

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

這會列出伺服器中所有可用的工具。你應該會看到以下輸出：

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

要呼叫工具，請輸入：

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

你應該會看到以下輸出：

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> 在 CLI 模式下執行 inspector 通常比在瀏覽器中快很多。
> 可在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於 inspector 的資訊。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用本翻譯而產生的任何誤解或誤譯概不負責。