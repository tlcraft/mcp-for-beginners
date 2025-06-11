<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:02:56+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tw"
}
-->
## Getting Started  

這一節包含了幾個課程：

- **1 你的第一個伺服器**，在這堂課裡，你會學到如何建立你的第一個伺服器，並用 inspector 工具檢查它，這是測試和除錯伺服器的好方法，[前往課程](/03-GettingStarted/01-first-server/README.md)

- **2 客戶端**，這堂課會教你如何撰寫一個可以連接到你的伺服器的客戶端，[前往課程](/03-GettingStarted/02-client/README.md)

- **3 帶 LLM 的客戶端**，更進階的客戶端寫法是加入 LLM，讓它能和你的伺服器「協商」要做什麼，[前往課程](/03-GettingStarted/03-llm-client/README.md)

- **4 在 Visual Studio Code 中使用 GitHub Copilot Agent 模式消費伺服器**。這裡我們會示範如何從 Visual Studio Code 裡執行 MCP Server，[前往課程](/03-GettingStarted/04-vscode/README.md)

- **5 使用 SSE（Server Sent Events）消費**。SSE 是一種伺服器到客戶端的串流標準，允許伺服器透過 HTTP 推送即時更新給客戶端，[前往課程](/03-GettingStarted/05-sse-server/README.md)

- **6 利用 AI Toolkit for VSCode** 來消費並測試你的 MCP 客戶端和伺服器，[前往課程](/03-GettingStarted/06-aitk/README.md)

- **7 測試**。這部分會特別著重於如何用不同方式測試我們的伺服器和客戶端，[前往課程](/03-GettingStarted/07-testing/README.md)

- **8 部署**。本章節將探討多種部署 MCP 解決方案的方法，[前往課程](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) 是一個開放協定，標準化應用程式如何向 LLM 提供上下文。你可以把 MCP 想成 AI 應用的 USB-C 連接埠——提供一個標準化的方式，讓 AI 模型能連接到不同的資料來源和工具。

## Learning Objectives

完成本課程後，你將能夠：

- 設定 MCP 在 C#、Java、Python、TypeScript 及 JavaScript 的開發環境
- 建立並部署具備自訂功能（資源、提示和工具）的基本 MCP 伺服器
- 建立能連接 MCP 伺服器的主機應用程式
- 測試與除錯 MCP 實作
- 理解常見的設定挑戰及其解決方案
- 將你的 MCP 實作連接到熱門的 LLM 服務

## Setting Up Your MCP Environment

在開始使用 MCP 前，準備好開發環境並了解基本工作流程非常重要。本節將引導你完成初步設定步驟，確保你能順利開始 MCP 的開發。

### Prerequisites

在投入 MCP 開發前，請確認你已具備：

- **開發環境**：你所選擇的語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代化的程式碼編輯器
- **套件管理工具**：NuGet、Maven/Gradle、pip，或 npm/yarn
- **API 金鑰**：針對你計劃在主機應用程式中使用的任何 AI 服務

### Official SDKs

接下來的章節會展示用 Python、TypeScript、Java 和 .NET 建構的解決方案。以下是所有官方支援的 SDK。

MCP 提供多種語言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實作
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實作
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實作
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實作

## Key Takeaways

- 設定 MCP 開發環境相當簡單，因為有語言專屬的 SDK 支援
- 建立 MCP 伺服器需要創建並註冊具明確結構的工具
- MCP 客戶端會連接伺服器和模型，發揮擴充功能
- 測試和除錯對於可靠的 MCP 實作非常重要
- 部署選項從本地開發到雲端解決方案皆有涵蓋

## Practicing

我們準備了一組範例，搭配本節所有章節的練習使用，此外每個章節也都有自己的練習和作業。

- [Java 計算機](./samples/java/calculator/README.md)
- [.Net 計算機](../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](../../../03-GettingStarted/samples/javascript)
- [TypeScript 計算機](./samples/typescript/README.md)
- [Python 計算機](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

下一步：[建立你的第一個 MCP Server](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用本翻譯而產生的任何誤解或誤譯不負任何責任。