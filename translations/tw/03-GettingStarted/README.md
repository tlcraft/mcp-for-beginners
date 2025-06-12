<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T21:22:53+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tw"
}
-->
## Getting Started  

本節包含多個課程：

- **1 你的第一台伺服器**，在這堂課中，你會學到如何建立你的第一台伺服器，並使用檢查工具來檢視它，這是測試和除錯伺服器的好方法，[前往課程](/03-GettingStarted/01-first-server/README.md)

- **2 用戶端**，在這堂課中，你會學到如何撰寫一個可以連接到你的伺服器的用戶端，[前往課程](/03-GettingStarted/02-client/README.md)

- **3 帶有 LLM 的用戶端**，更進階的用戶端寫法是加入 LLM，讓它可以和你的伺服器「協商」要做什麼，[前往課程](/03-GettingStarted/03-llm-client/README.md)

- **4 在 Visual Studio Code 中使用伺服器 GitHub Copilot Agent 模式**。這裡我們會介紹如何在 Visual Studio Code 裡執行 MCP Server，[前往課程](/03-GettingStarted/04-vscode/README.md)

- **5 從 SSE (Server Sent Events) 消費資料** SSE 是一種伺服器到用戶端的串流標準，允許伺服器透過 HTTP 推送即時更新給用戶端，[前往課程](/03-GettingStarted/05-sse-server/README.md)

- **6 使用 MCP 的 HTTP 串流（可串流的 HTTP）**。了解現代 HTTP 串流、進度通知，以及如何使用可串流的 HTTP 實作可擴展的即時 MCP 伺服器和用戶端，[前往課程](/03-GettingStarted/06-http-streaming/README.md)

- **7 利用 AI Toolkit for VSCode** 來使用和測試你的 MCP 用戶端和伺服器，[前往課程](/03-GettingStarted/07-aitk/README.md)

- **8 測試**。這裡我們會特別著重如何用不同方式測試我們的伺服器和用戶端，[前往課程](/03-GettingStarted/08-testing/README.md)

- **9 部署**。本章會探討部署 MCP 解決方案的不同方法，[前往課程](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) 是一個開放協議，標準化應用程式如何提供上下文給 LLM。你可以把 MCP 想像成 AI 應用的 USB-C 連接埠——它提供一個標準化的方式，讓 AI 模型可以連接到不同的資料來源和工具。

## Learning Objectives

完成本課後，你將能夠：

- 建立 MCP 在 C#、Java、Python、TypeScript 和 JavaScript 的開發環境
- 建置並部署具有自訂功能（資源、提示和工具）的基本 MCP 伺服器
- 建立可連接 MCP 伺服器的主機應用程式
- 測試和除錯 MCP 實作
- 了解常見設定挑戰及其解決方案
- 將你的 MCP 實作連接到熱門的 LLM 服務

## Setting Up Your MCP Environment

在開始使用 MCP 之前，準備好開發環境並了解基本工作流程非常重要。本節將帶你完成初步設定步驟，確保你能順利開始 MCP。

### Prerequisites

在投入 MCP 開發前，請確保你已具備：

- **開發環境**：針對你選擇的語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代程式碼編輯器
- **套件管理工具**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 金鑰**：用於你計劃在主機應用程式中使用的任何 AI 服務


### Official SDKs

接下來的章節你會看到使用 Python、TypeScript、Java 和 .NET 建置的解決方案。以下是所有官方支援的 SDK。

MCP 提供多種語言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實作
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實作
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實作
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實作

## Key Takeaways

- 使用語言專屬 SDK，MCP 開發環境的設定相當簡單
- 建置 MCP 伺服器需建立並註冊帶有明確結構的工具
- MCP 用戶端連接伺服器和模型以擴展功能
- 測試和除錯是確保 MCP 實作可靠的重要步驟
- 部署選項從本地開發到雲端解決方案皆有涵蓋

## Practicing

我們準備了一組範例，搭配本節各章節的練習。此外，每個章節也有自己的練習和作業。

- [Java 計算機](./samples/java/calculator/README.md)
- [.Net 計算機](../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](./samples/javascript/README.md)
- [TypeScript 計算機](./samples/typescript/README.md)
- [Python 計算機](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

下一步：[建立你的第一個 MCP Server](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或誤譯負責。