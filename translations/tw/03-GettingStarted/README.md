<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:06:32+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tw"
}
-->
## 入門指南

本節包含幾個課程：

- **-1- 您的第一個伺服器**，在這第一課中，您將學習如何創建您的第一個伺服器，並使用檢查工具進行檢查，這是一種測試和調試伺服器的寶貴方法，[前往課程](/03-GettingStarted/01-first-server/README.md)

- **-2- 客戶端**，在這課中，您將學習如何編寫一個能夠連接到您伺服器的客戶端，[前往課程](/03-GettingStarted/02-client/README.md)

- **-3- 使用 LLM 的客戶端**，更好的編寫客戶端的方法是加入一個 LLM，使其能夠與您的伺服器「協商」該做什麼，[前往課程](/03-GettingStarted/03-llm-client/README.md)

- **-4- 在 Visual Studio Code 中以 GitHub Copilot Agent 模式使用伺服器**。在這裡，我們將在 Visual Studio Code 中運行我們的 MCP 伺服器，[前往課程](/03-GettingStarted/04-vscode/README.md)

- **-5- 從 SSE (Server Sent Events) 消費**。SEE 是一種伺服器到客戶端流的標準，允許伺服器通過 HTTP 向客戶端推送實時更新，[前往課程](/03-GettingStarted/05-sse-server/README.md)

- **-6- 利用 VSCode 的 AI 工具包**來消費和測試您的 MCP 客戶端和伺服器，[前往課程](/03-GettingStarted/06-aitk/README.md)

- **-7 測試**。在這裡，我們將特別關注如何以不同方式測試我們的伺服器和客戶端，[前往課程](/03-GettingStarted/07-testing/README.md)

- **-8- 部署**。本章將探討部署您的 MCP 解決方案的不同方式，[前往課程](/03-GettingStarted/08-deployment/README.md)

模型上下文協議（MCP）是一個開放的協議，標準化應用程序如何向 LLM 提供上下文。可以將 MCP 想像成 AI 應用程序的 USB-C 端口 - 它提供了一種標準化的方式來連接 AI 模型與不同的數據源和工具。

## 學習目標

在本課結束時，您將能夠：

- 為 MCP 在 C#、Java、Python、TypeScript 和 JavaScript 設置開發環境
- 構建和部署具有自定義功能（資源、提示和工具）的基本 MCP 伺服器
- 創建連接到 MCP 伺服器的主機應用程序
- 測試和調試 MCP 的實現
- 理解常見的設置挑戰及其解決方案
- 將您的 MCP 實現連接到流行的 LLM 服務

## 設置您的 MCP 環境

在開始使用 MCP 之前，準備您的開發環境並理解基本工作流程是很重要的。本節將指導您完成初始設置步驟，以確保順利開始使用 MCP。

### 先決條件

在深入 MCP 開發之前，請確保您擁有：

- **開發環境**：適用於您選擇的語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代代碼編輯器
- **包管理器**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 密鑰**：適用於您計劃在主機應用程序中使用的任何 AI 服務

### 官方 SDK

在即將到來的章節中，您將看到使用 Python、TypeScript、Java 和 .NET 構建的解決方案。以下是所有官方支持的 SDK。

MCP 提供多種語言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與微軟合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實現

## 關鍵要點

- 使用語言特定的 SDK 設置 MCP 開發環境非常簡單
- 構建 MCP 伺服器涉及創建和註冊具有清晰模式的工具
- MCP 客戶端連接到伺服器和模型以利用擴展功能
- 測試和調試對於可靠的 MCP 實現至關重要
- 部署選項從本地開發到基於雲的解決方案不等

## 實踐

我們有一套樣本來補充您在本節所有章節中看到的練習。此外，每個章節還有自己的練習和作業

- [Java 計算器](./samples/java/calculator/README.md)
- [.Net 計算器](../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](./samples/javascript/README.md)
- [TypeScript 計算器](./samples/typescript/README.md)
- [Python 計算器](../../../03-GettingStarted/samples/python)

## 其他資源

- [MCP GitHub 資源庫](https://github.com/microsoft/mcp-for-beginners)

## 下一步

下一步：[創建您的第一個 MCP 伺服器](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：

本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應將原文檔視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對於使用此翻譯所產生的任何誤解或誤釋不承擔責任。