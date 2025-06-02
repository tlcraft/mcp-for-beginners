<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:55:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hk"
}
-->
### -2- 建立專案

而家你已經安裝咗 SDK，下一步就係建立一個專案：

### -3- 建立專案檔案

### -4- 撰寫伺服器程式碼

### -5- 加入工具同資源

透過加入以下程式碼，新增一個工具同一個資源：

### -6 最終程式碼

加埋最後嘅程式碼，令伺服器可以啟動：

### -7- 測試伺服器

用以下指令啟動伺服器：

### -8- 用 Inspector 運行

Inspector 係一個好用嘅工具，可以幫你啟動伺服器，並且同佢互動，測試功能係咪正常。依家我哋啟動佢：

> [!NOTE]
> 「command」欄可能會唔同，因為佢包含咗用你指定運行環境嘅啟動指令。

你應該會見到以下嘅用戶介面：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 按「Connect」掣連接伺服器
   連接成功後，你會見到以下畫面：

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hk.png)

2. 揀「Tools」同「listTools」，你會見到「Add」出現，揀「Add」並填寫參數值。

   你應該會見到以下回應，即係「add」工具嘅結果：

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hk.png)

恭喜你，成功建立並運行咗你嘅第一個伺服器！

### 官方 SDK

MCP 提供多種語言嘅官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實現

## 主要重點

- 設置 MCP 開發環境好簡單，因為有針對語言嘅 SDK
- 建立 MCP 伺服器需要創建並註冊具明確 schema 嘅工具
- 測試同除錯係確保 MCP 實現穩定嘅關鍵

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 作業

建立一個簡單嘅 MCP 伺服器，同你揀嘅工具：
1. 用你鍾意嘅語言（.NET、Java、Python 或 JavaScript）實現工具。
2. 定義輸入參數同返回值。
3. 用 inspector 工具測試伺服器功能。
4. 用唔同嘅輸入測試實現效果。

## 解答

[解答](./solution/README.md)

## 額外資源

- [MCP GitHub 倉庫](https://github.com/microsoft/mcp-for-beginners)

## 下一步

下一章：[Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**免責聲明**：  
本文件係使用AI翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯。雖然我哋盡力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資料，建議使用專業人工翻譯。因使用本翻譯而引致嘅任何誤解或誤釋，我哋概不負責。