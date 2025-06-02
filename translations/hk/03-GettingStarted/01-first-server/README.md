<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:28:53+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hk"
}
-->
### -2- 建立項目

而家你已經安裝咗SDK，下一步就係建立一個項目：

### -3- 建立項目檔案

### -4- 撰寫伺服器代碼

### -5- 加入工具同資源

加入以下代碼，新增一個工具同一個資源：

### -6 最終代碼

加入最後嘅代碼，令伺服器可以啟動：

### -7- 測試伺服器

用以下命令啟動伺服器：

### -8- 用 inspector 運行

inspector 係一個好用嘅工具，可以啟動你嘅伺服器，並且讓你互動測試佢嘅運作。依家開始用佢：

> [!NOTE]
> 「command」欄位入面嘅命令可能會因應你嘅運行時環境而有所不同

你應該會見到以下介面：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 按「Connect」按鈕連接伺服器  
   連接成功後，你應該會見到以下畫面：

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hk.png)

2. 選擇「Tools」同「listTools」，你會見到「Add」出現，揀「Add」並填寫參數值。

   你會見到以下回應，即係「add」工具嘅運行結果：

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
- 建立 MCP 伺服器需創建並註冊帶有清晰結構嘅工具
- 測試同除錯對可靠嘅 MCP 實現非常重要

## 範例

- [Java 計算機](../samples/java/calculator/README.md)
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../samples/javascript/README.md)
- [TypeScript 計算機](../samples/typescript/README.md)
- [Python 計算機](../../../../03-GettingStarted/samples/python)

## 作業

建立一個簡單嘅 MCP 伺服器同你選擇嘅工具：
1. 用你鍾意嘅語言（.NET、Java、Python 或 JavaScript）實現該工具。
2. 定義輸入參數同回傳值。
3. 運行 inspector 工具確保伺服器正常運作。
4. 用不同輸入測試實現效果。

## 解答

[解答](./solution/README.md)

## 額外資源

- [MCP GitHub 倉庫](https://github.com/microsoft/mcp-for-beginners)

## 下一步

下一步: [開始使用 MCP 客戶端](/03-GettingStarted/02-client/README.md)

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋負責。