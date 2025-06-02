<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:22:01+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hk"
}
-->
### -2- 建立項目

而家你已經安裝咗SDK，下一步就係建立一個項目：

### -3- 建立項目檔案

### -4- 撰寫伺服器程式碼

### -5- 加入工具同資源

透過加入以下程式碼，新增一個工具同一個資源：

### -6- 最終程式碼

加埋最後一段程式碼，令伺服器可以啟動：

### -7- 測試伺服器

用以下指令啟動伺服器：

### -8- 用 inspector 運行

inspector 係一個好用嘅工具，可以幫你啟動伺服器，並且讓你互動測試佢嘅功能。依家我哋開始用佢：

> [!NOTE]
> 喺「command」欄位入面嘅指令可能會唔同，因為佢會包含針對你用緊嘅執行環境嘅啟動指令。

你應該會見到以下嘅用戶介面：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 按「Connect」掣連接伺服器
  連接成功後，你會見到以下畫面：

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hk.png)

1. 選擇「Tools」再揀「listTools」，你會見到「Add」選項，揀「Add」然後填寫參數值。

  你應該會見到以下回應，即係「add」工具嘅結果：

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hk.png)

恭喜你，成功建立同運行咗你嘅第一個伺服器！

### 官方 SDK

MCP 提供多種語言嘅官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實現

## 重要重點

- 設置 MCP 開發環境簡單，配合語言專用 SDK
- 建立 MCP 伺服器需要創建並註冊有清晰 schema 嘅工具
- 測試同除錯對可靠嘅 MCP 實現非常重要

## 範例

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 練習題

建立一個簡單嘅 MCP 伺服器，並加入你選擇嘅工具：
1. 用你鍾意嘅語言 (.NET、Java、Python 或 JavaScript) 實作該工具。
2. 定義輸入參數同回傳值。
3. 用 inspector 工具測試伺服器運作正常。
4. 用唔同嘅輸入測試實作結果。

## 解答

[解答](./solution/README.md)

## 額外資源

- [使用 Model Context Protocol 喺 Azure 建立代理](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [使用 Azure Container Apps 遠端 MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP 代理](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 下一步

下一章：[Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**免責聲明**：  
本文件係使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。雖然我哋致力確保準確性，但請注意自動翻譯可能會包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。