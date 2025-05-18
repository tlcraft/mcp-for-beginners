<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:07:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

## -1- 安裝相依套件

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

在一個終端機中啟動伺服器後，打開另一個終端機並執行以下指令：

```bash
npx @modelcontextprotocol/inspector dotnet run
```

這應該會啟動一個具有視覺介面的網頁伺服器，讓你可以測試範例。

一旦伺服器連接成功：

- 嘗試列出工具並執行 `add`，使用參數 2 和 4，你應該會看到結果是 6。
- 前往資源和資源模板並呼叫 "greeting"，輸入一個名字，你應該會看到包含你提供名字的問候語。

### 在 CLI 模式下測試

你可以直接透過執行以下指令來啟動 CLI 模式：

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

要調用工具，請輸入：

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
> 通常在 CLI 模式下執行檢查器比在瀏覽器中快很多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於檢查器的資訊。

**免責聲明**：
本文檔使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原始語言的文件作為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們對因使用此翻譯而產生的任何誤解或曲解不承擔責任。