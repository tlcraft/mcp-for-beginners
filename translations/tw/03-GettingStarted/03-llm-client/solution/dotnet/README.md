<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:39:23+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

> [!NOTE]
> 此範例假設您正在使用 GitHub Codespaces 實例。如果您想在本地運行，需要在 GitHub 上設置個人訪問令牌。

## 安裝庫

```sh
dotnet restore
```

應安裝以下庫：Azure AI Inference、Azure Identity、Microsoft.Extension、Model.Hosting、ModelContextProtcol

## 執行

```sh 
dotnet run
```

您應該會看到類似以下的輸出：

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

很多輸出只是調試信息，但重要的是您正在從 MCP 服務器列出工具，將這些轉換為 LLM 工具，最終得到 MCP 客戶端響應 "Sum 6"。

**免責聲明**：
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不精確之處。原始文件的母語版本應被視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們不對因使用此翻譯而產生的任何誤解或錯誤解釋承擔責任。