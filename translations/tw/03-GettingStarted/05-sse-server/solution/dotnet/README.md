<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:51:35+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

## -1- 安裝相依套件

```bash
dotnet restore
```

## -2- 執行範例

```bash
dotnet run
```

## -3- 測試範例

在執行以下指令前，請先開啟另一個終端機（確保伺服器仍在運行中）。

在一個終端機中啟動伺服器後，開啟另一個終端機並執行以下指令：

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

這會啟動一個帶有視覺介面的網頁伺服器，讓你可以測試範例。

> 確認已選擇 **SSE** 作為傳輸類型，URL 為 `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`，並帶入參數 2 和 4，結果應該會顯示 6。
- 前往 resources 和 resource template，呼叫 "greeting"，輸入一個名稱，你會看到帶有該名稱的問候訊息。

### CLI 模式測試

你也可以直接以 CLI 模式啟動，執行以下指令：

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

這會列出伺服器上所有可用的工具。你應該會看到以下輸出：

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

若要呼叫工具，請輸入：

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

你會看到以下輸出：

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
> 通常在 CLI 模式下執行 inspector 比在瀏覽器中快得多。
> 更多關於 inspector 的資訊請參考 [這裡](https://github.com/modelcontextprotocol/inspector)。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生之任何誤解或誤譯負責。