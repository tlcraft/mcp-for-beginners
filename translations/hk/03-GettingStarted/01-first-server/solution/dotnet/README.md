<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:07:30+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hk"
}
-->
# 執行此範例

## -1- 安裝依賴項

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- 執行範例

```bash
dotnet run
```

## -4- 測試範例

在一個終端機中啟動伺服器後，打開另一個終端機並執行以下命令：

```bash
npx @modelcontextprotocol/inspector dotnet run
```

這應該會啟動一個帶有視覺介面的網頁伺服器，讓你可以測試範例。

伺服器連接後：

- 嘗試列出工具並運行 `add`，使用參數 2 和 4，你應該會在結果中看到 6。
- 前往資源和資源模板，呼叫 "greeting"，輸入一個名字，你應該會看到包含你提供名字的問候語。

### 在 CLI 模式中測試

你可以通過運行以下命令直接在 CLI 模式中啟動它：

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

這將列出伺服器中所有可用的工具。你應該會看到以下輸出：

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

要調用工具請輸入：

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
> 通常在 CLI 模式中運行檢查器比在瀏覽器中快得多。
> 在這裡閱讀更多關於檢查器的信息 [here](https://github.com/modelcontextprotocol/inspector).

**免責聲明**：  
本文檔使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原文作為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對使用此翻譯可能引起的任何誤解或誤讀不承擔責任。