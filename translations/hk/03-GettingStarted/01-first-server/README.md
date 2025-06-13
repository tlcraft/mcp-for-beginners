<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:53:46+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hk"
}
-->
### -2- 建立專案

安裝好 SDK 後，下一步就係建立一個專案啦：

### -3- 建立專案檔案

### -4- 撰寫伺服器程式碼

### -5- 加入工具同資源

透過加入以下程式碼，新增一個工具同一個資源：

### -6 最終程式碼

加埋最後啲程式碼，咁個伺服器先可以啟動：

### -7- 測試伺服器

用以下指令啟動伺服器：

### -8- 用 Inspector 運行

Inspector 係一個好用嘅工具，可以幫你啟動伺服器，並且互動測試，確保佢正常運作。即刻試下啟動佢：

> [!NOTE]  
> 喺「command」欄位入面嘅指令可能會唔同，因為佢會包含用你指定執行環境嘅啟動指令。

你應該會見到以下嘅介面：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 按「Connect」按鈕連接伺服器  
   連接成功後，你應該會見到以下畫面：

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hk.png)

2. 選擇「Tools」同「listTools」，你會見到「Add」出現，揀「Add」然後填寫參數值。

   你應該會見到以下回應，即係「add」工具嘅結果：

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hk.png)

恭喜你，成功建立並運行咗你嘅第一個伺服器！

### 官方 SDK

MCP 提供多種語言嘅官方 SDK：  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實作  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實作  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實作  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實作

## 主要重點

- 利用語言專屬 SDK，設定 MCP 開發環境好簡單  
- 建立 MCP 伺服器需要建立並註冊帶有明確 schema 嘅工具  
- 測試同除錯係確保 MCP 實作可靠嘅關鍵

## 範例

- [Java 計算機](../samples/java/calculator/README.md)  
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript 計算機](../samples/javascript/README.md)  
- [TypeScript 計算機](../samples/typescript/README.md)  
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 作業

建立一個簡單嘅 MCP 伺服器，並加入你選擇嘅工具：  
1. 用你熟悉嘅語言（.NET、Java、Python 或 JavaScript）實作該工具。  
2. 定義輸入參數同返回值。  
3. 用 inspector 工具測試伺服器運作是否正常。  
4. 嘗試用不同輸入值測試實作。

## 解答

[解答](./solution/README.md)

## 額外資源

- [用 Model Context Protocol 喺 Azure 上建立代理](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [用 Azure Container Apps 遠端運行 MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP 代理](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 下一步

下一課：[Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用此翻譯而引起的任何誤解或誤釋負責。