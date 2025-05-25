<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:06:10+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hk"
}
-->
## 入門指南

這一部分包含幾個課程：

- **-1- 你的第一個伺服器**，在這第一堂課中，你將學習如何建立你的第一個伺服器，並使用檢查工具來檢視它，這是一個測試和除錯伺服器的有用方法，[前往課程](/03-GettingStarted/01-first-server/README.md)

- **-2- 客戶端**，在這堂課中，你將學習如何編寫一個可以連接到你伺服器的客戶端，[前往課程](/03-GettingStarted/02-client/README.md)

- **-3- 使用LLM的客戶端**，一個更好的編寫客戶端的方法是加入LLM，使其能夠與你的伺服器“協商”應該做什麼，[前往課程](/03-GettingStarted/03-llm-client/README.md)

- **-4- 在Visual Studio Code中以GitHub Copilot Agent模式使用伺服器**。在這裡，我們將從Visual Studio Code中運行我們的MCP伺服器，[前往課程](/03-GettingStarted/04-vscode/README.md)

- **-5- 使用SSE (伺服器發送事件)** SSE是一種伺服器到客戶端的串流標準，允許伺服器通過HTTP推送即時更新到客戶端，[前往課程](/03-GettingStarted/05-sse-server/README.md)

- **-6- 使用VSCode的AI工具包** 來使用和測試你的MCP客戶端和伺服器，[前往課程](/03-GettingStarted/06-aitk/README.md)

- **-7 測試**。在這裡，我們將特別關注如何以不同的方式測試我們的伺服器和客戶端，[前往課程](/03-GettingStarted/07-testing/README.md)

- **-8- 部署**。這一章將探討不同的MCP解決方案部署方法，[前往課程](/03-GettingStarted/08-deployment/README.md)

模型上下文協議（MCP）是一種開放協議，標準化應用程式如何向LLM提供上下文。可以將MCP想像成AI應用程式的USB-C端口——它提供了一種標準化的方法來將AI模型連接到不同的數據源和工具。

## 學習目標

在這堂課結束時，你將能夠：

- 設置C#、Java、Python、TypeScript和JavaScript的MCP開發環境
- 構建和部署具有自定義功能（資源、提示和工具）的基本MCP伺服器
- 創建連接到MCP伺服器的主機應用程式
- 測試和除錯MCP實現
- 理解常見的設置挑戰及其解決方案
- 將你的MCP實現連接到流行的LLM服務

## 設置你的MCP環境

在開始使用MCP之前，準備你的開發環境並了解基本工作流程是很重要的。本節將指導你完成初始設置步驟，以確保順利開始使用MCP。

### 先決條件

在深入MCP開發之前，確保你擁有：

- **開發環境**：為你選擇的語言（C#、Java、Python、TypeScript或JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm或任何現代代碼編輯器
- **包管理器**：NuGet、Maven/Gradle、pip或npm/yarn
- **API金鑰**：用於你計劃在主機應用程式中使用的任何AI服務

### 官方SDK

在接下來的章節中，你將看到使用Python、TypeScript、Java和.NET構建的解決方案。以下是所有官方支持的SDK。

MCP提供多種語言的官方SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與Microsoft合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與Spring AI合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方TypeScript實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方Python實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方Kotlin實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與Loopwork AI合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方Rust實現

## 關鍵要點

- 使用語言特定的SDK設置MCP開發環境非常簡單
- 構建MCP伺服器涉及創建和註冊具有明確架構的工具
- MCP客戶端連接到伺服器和模型以利用擴展功能
- 測試和除錯對於可靠的MCP實現至關重要
- 部署選項範圍從本地開發到基於雲的解決方案

## 練習

我們有一組範例，補充了你將在本節所有章節中看到的練習。此外，每個章節還有自己的練習和作業

- [Java 計算器](./samples/java/calculator/README.md)
- [.Net 計算器](../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](./samples/javascript/README.md)
- [TypeScript 計算器](./samples/typescript/README.md)
- [Python 計算器](../../../03-GettingStarted/samples/python)

## 其他資源

- [MCP GitHub 資料庫](https://github.com/microsoft/mcp-for-beginners)

## 接下來是什麼

接下來：[創建你的第一個MCP伺服器](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原始語言的文件作為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們對因使用此翻譯而產生的任何誤解或誤釋不承擔責任。