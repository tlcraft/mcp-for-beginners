<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:39:18+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "hk"
}
-->
# 執行此範例

## 安裝庫

```sh
dotnet restore
```

應該安裝以下庫：Azure AI Inference、Azure Identity、Microsoft.Extension、Model.Hosting、ModelContextProtcol 

## 執行

```sh 
dotnet run
```

您應該看到類似以下的輸出：

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

大部分輸出只是調試信息，但重要的是您正在從 MCP 伺服器列出工具，將它們轉換為 LLM 工具，最後得到 MCP 客戶端響應 "Sum 6"。

**免責聲明**：

此文件是使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)翻譯的。雖然我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為權威來源。對於關鍵信息，建議尋求專業的人力翻譯。我們對使用此翻譯所產生的任何誤解或誤釋不承擔責任。