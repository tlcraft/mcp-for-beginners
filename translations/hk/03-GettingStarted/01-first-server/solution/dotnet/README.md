<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-13T17:47:32+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hk"
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

當伺服器在一個終端機運行時，打開另一個終端機並執行以下指令：

```bash
npx @modelcontextprotocol/inspector dotnet run
```

這會啟動一個帶有視覺介面的網頁伺服器，讓你可以測試範例。

伺服器連線後：

- 試著列出工具並執行 `add`，帶入參數 2 和 4，結果應該會顯示 6。
- 前往 resources 和 resource template，呼叫 "greeting"，輸入一個名字，你應該會看到帶有你輸入名字的問候語。

### 在 CLI 模式下測試

你可以直接用以下指令啟動 CLI 模式：

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

要呼叫工具，輸入：

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
> 更多關於 inspector 的資訊請參考 [這裡](https://github.com/modelcontextprotocol/inspector)。

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。