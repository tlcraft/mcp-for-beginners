<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:22:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tw"
}
-->
## Getting Started  

這個章節包含了幾個課程：

- **-1- 你的第一台伺服器**，在這堂課中，你會學到如何建立你的第一台伺服器，並用檢查工具來檢視它，這是測試和除錯伺服器非常有用的方法，[前往課程](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**，在這堂課中，你會學到如何撰寫一個能連接到伺服器的 client，[前往課程](/03-GettingStarted/02-client/README.md)

- **-3- Client with LLM**，更進一步的 client 寫法是加入 LLM，讓它可以和伺服器「協商」要執行什麼操作，[前往課程](/03-GettingStarted/03-llm-client/README.md)

- **-4- 在 Visual Studio Code 中使用伺服器的 GitHub Copilot Agent 模式**。這裡會介紹如何在 Visual Studio Code 裡執行 MCP Server，[前往課程](/03-GettingStarted/04-vscode/README.md)

- **-5- 從 SSE (Server Sent Events) 消費資料**。SSE 是一種伺服器到客戶端的串流標準，讓伺服器能透過 HTTP 推送即時更新給客戶端，[前往課程](/03-GettingStarted/05-sse-server/README.md)

- **-6- 利用 AI Toolkit for VSCode** 來消費並測試你的 MCP Clients 和 Servers，[前往課程](/03-GettingStarted/06-aitk/README.md)

- **-7 測試**。這裡會特別著重於如何用不同方式測試你的伺服器和 client，[前往課程](/03-GettingStarted/07-testing/README.md)

- **-8- 部署**。本章會介紹部署 MCP 解決方案的各種方法，[前往課程](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) 是一個開放協定，標準化應用程式如何向 LLM 提供上下文。你可以把 MCP 想像成 AI 應用的 USB-C 連接埠——它提供一種標準化的方式，讓 AI 模型能連接不同的資料來源和工具。

## Learning Objectives

完成這堂課後，你將能夠：

- 為 MCP 設定 C#、Java、Python、TypeScript 及 JavaScript 的開發環境
- 建立並部署具備自訂功能（資源、提示詞和工具）的基本 MCP 伺服器
- 建立能連接 MCP 伺服器的主機應用程式
- 測試與除錯 MCP 實作
- 理解常見的設定挑戰及解決方案
- 將你的 MCP 實作連接到熱門的 LLM 服務

## Setting Up Your MCP Environment

在開始使用 MCP 之前，準備好開發環境並了解基本工作流程非常重要。本節將引導你完成初步設定步驟，確保你能順利開始使用 MCP。

### Prerequisites

在進入 MCP 開發之前，請確保你具備：

- **開發環境**：你選擇的語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或其他現代程式編輯器
- **套件管理工具**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 金鑰**：用於你主機應用程式中計畫使用的 AI 服務


### Official SDKs

接下來的章節會示範用 Python、TypeScript、Java 和 .NET 所建立的解決方案。以下是所有官方支援的 SDK。

MCP 提供多種語言的官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 共同維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 共同維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實作
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實作
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實作
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 共同維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實作

## Key Takeaways

- 利用語言專用 SDK，設定 MCP 開發環境相當簡單
- 建立 MCP 伺服器需要建立並註冊具明確結構的工具
- MCP client 能連接伺服器與模型，發揮擴充功能
- 測試與除錯對可靠的 MCP 實作至關重要
- 部署選項涵蓋本地開發到雲端解決方案

## Practicing

我們準備了一系列範例，搭配你在本節各章看到的練習。此外，每個章節也都有自己的練習與作業

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

下一步：[建立你的第一台 MCP Server](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。