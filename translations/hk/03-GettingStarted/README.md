<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-13T17:12:48+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hk"
}
-->
## 入門指南  

本節包含多個課程：

- **1 你的第一個伺服器**，在這第一課中，你將學習如何建立你的第一個伺服器，並使用檢查工具來檢視它，這是一個測試和除錯伺服器的寶貴方法，[前往課程](01-first-server/README.md)

- **2 用戶端**，在這課中，你將學習如何撰寫一個能連接到你的伺服器的用戶端，[前往課程](02-client/README.md)

- **3 帶有 LLM 的用戶端**，更進一步的用戶端寫法是加入 LLM，讓它能與你的伺服器「協商」該如何操作，[前往課程](03-llm-client/README.md)

- **4 在 Visual Studio Code 中使用 GitHub Copilot Agent 模式消費伺服器**。這裡我們會探討如何在 Visual Studio Code 內執行 MCP 伺服器，[前往課程](04-vscode/README.md)

- **5 從 SSE (Server Sent Events) 消費** SSE 是一種伺服器到用戶端的串流標準，允許伺服器透過 HTTP 推送即時更新給用戶端，[前往課程](05-sse-server/README.md)

- **6 使用 MCP 的 HTTP 串流（可串流的 HTTP）**。了解現代 HTTP 串流、進度通知，以及如何使用可串流的 HTTP 實作可擴展的即時 MCP 伺服器和用戶端，[前往課程](06-http-streaming/README.md)

- **7 利用 VSCode 的 AI 工具包** 來消費和測試你的 MCP 用戶端和伺服器，[前往課程](07-aitk/README.md)

- **8 測試**。這裡我們將特別著重於如何用不同方式測試我們的伺服器和用戶端，[前往課程](08-testing/README.md)

- **9 部署**。本章將探討部署 MCP 解決方案的不同方法，[前往課程](09-deployment/README.md)


Model Context Protocol (MCP) 是一個開放協議，標準化應用程式如何向 LLM 提供上下文。可以把 MCP 想像成 AI 應用的 USB-C 端口——它提供一種標準化的方式，將 AI 模型連接到不同的資料來源和工具。

## 學習目標

完成本課程後，你將能夠：

- 為 C#、Java、Python、TypeScript 和 JavaScript 設定 MCP 開發環境
- 建立並部署具自訂功能（資源、提示和工具）的基本 MCP 伺服器
- 建立連接 MCP 伺服器的主機應用程式
- 測試和除錯 MCP 實作
- 理解常見的設定挑戰及其解決方案
- 將你的 MCP 實作連接到熱門的 LLM 服務

## 設定你的 MCP 環境

在開始使用 MCP 之前，準備好開發環境並了解基本工作流程非常重要。本節將引導你完成初始設定步驟，確保你能順利開始使用 MCP。

### 先決條件

在深入 MCP 開發前，請確保你已具備：

- **開發環境**：適用於你選擇的語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代程式碼編輯器
- **套件管理工具**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 金鑰**：用於你計劃在主機應用中使用的任何 AI 服務

### 官方 SDK

在接下來的章節中，你會看到使用 Python、TypeScript、Java 和 .NET 建構的解決方案。以下是所有官方支援的 SDK。

MCP 提供多種語言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實作
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實作
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實作
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實作

## 主要重點

- 使用語言專屬 SDK 設定 MCP 開發環境相當簡單
- 建立 MCP 伺服器需創建並註冊具明確結構的工具
- MCP 用戶端連接伺服器和模型以發揮擴充功能
- 測試和除錯對可靠的 MCP 實作至關重要
- 部署選項涵蓋從本地開發到雲端解決方案

## 練習

我們提供一組範例，補充本節所有章節中的練習。此外，每個章節也有自己的練習和作業。

- [Java 計算機](./samples/java/calculator/README.md)
- [.Net 計算機](../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](./samples/javascript/README.md)
- [TypeScript 計算機](./samples/typescript/README.md)
- [Python 計算機](../../../03-GettingStarted/samples/python)

## 額外資源

- [使用 Model Context Protocol 在 Azure 上建立 Agents](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [使用 Azure Container Apps 遠端 MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 下一步

下一課： [建立你的第一個 MCP 伺服器](01-first-server/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。