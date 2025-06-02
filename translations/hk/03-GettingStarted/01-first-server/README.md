<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:03:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hk"
}
-->
### -2- 建立專案

而家你已經安裝咗SDK，下一步就係建立一個專案：

### -3- 建立專案檔案

### -4- 撰寫伺服器程式碼

### -5- 新增工具同資源

透過新增以下程式碼，加入一個工具同一個資源：

### -6- 最終程式碼

加入最後嘅程式碼，等伺服器可以啟動：

### -7- 測試伺服器

用以下指令啟動伺服器：

### -8- 用 Inspector 運行

Inspector 係一個好用嘅工具，可以幫你啟動伺服器，並且同伺服器互動，測試功能係咪正常。依家就啟動佢：

> [!NOTE]
> 「command」欄入面嘅指令可能會因為你用嘅執行環境唔同而有所差異。

你應該會見到以下嘅使用介面：

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hk.png)

1. 選擇「Connect」按鈕連接伺服器  
   連接成功後，你會見到以下畫面：

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hk.png)

2. 選擇「Tools」再揀「listTools」，你會見到「Add」出現，揀「Add」並填寫參數值。

   你應該會見到以下回應，即係「add」工具嘅運行結果：

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hk.png)

恭喜你，成功建立同執行咗你嘅第一個伺服器！

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

- MCP 開發環境嘅設定簡單，並有語言專屬嘅 SDK  
- 建立 MCP 伺服器需要創建同註冊帶有明確結構嘅工具  
- 測試同除錯對穩定嘅 MCP 實現非常重要  

## 範例

- [Java 計算機](../samples/java/calculator/README.md)  
- [.Net 計算機](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript 計算機](../samples/javascript/README.md)  
- [TypeScript 計算機](../samples/typescript/README.md)  
- [Python 計算機](../../../../03-GettingStarted/samples/python)  

## 作業

建立一個簡單嘅 MCP 伺服器，並加入你揀嘅工具：  
1. 用你鍾意嘅語言（.NET、Java、Python 或 JavaScript）實作工具。  
2. 定義輸入參數同回傳值。  
3. 用 inspector 工具確保伺服器運作正常。  
4. 用唔同嘅輸入測試實作。  

## 解答

[解答](./solution/README.md)

## 額外資源

- [MCP GitHub 倉庫](https://github.com/microsoft/mcp-for-beginners)

## 下一步

下一課：[Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件以其母語版本為權威來源。如涉及重要資訊，建議使用專業人工翻譯。我們不對因使用此翻譯而引起的任何誤解或誤釋承擔責任。