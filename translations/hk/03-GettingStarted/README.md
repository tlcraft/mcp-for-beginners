<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T21:27:11+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hk"
}
-->
## Getting Started  

呢個部分包括幾堂課：

- **1 你的第一個伺服器**，喺呢堂課入面，你會學識點樣建立你嘅第一個伺服器，同埋用 inspector 工具去檢查佢，呢個係一個好有用嘅方法去測試同埋除錯你嘅伺服器，[去課堂](/03-GettingStarted/01-first-server/README.md)

- **2 客戶端**，呢堂課會教你點樣寫一個可以連接你伺服器嘅客戶端，[去課堂](/03-GettingStarted/02-client/README.md)

- **3 帶 LLM 嘅客戶端**，寫客戶端嘅一個更好方法係加一個 LLM，咁佢就可以同你嘅伺服器「協商」做咩事，[去課堂](/03-GettingStarted/03-llm-client/README.md)

- **4 喺 Visual Studio Code 使用伺服器嘅 GitHub Copilot Agent 模式**。呢度我哋會睇點樣喺 Visual Studio Code 入面運行我哋嘅 MCP Server，[去課堂](/03-GettingStarted/04-vscode/README.md)

- **5 使用 SSE (Server Sent Events) 消費**。SSE 係一個標準，讓伺服器可以用 HTTP 即時推送更新畀客戶端，[去課堂](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP 嘅 HTTP 串流 (Streamable HTTP)**。了解現代 HTTP 串流、進度通知，仲有點樣用 Streamable HTTP 去實現可擴展嘅即時 MCP 伺服器同客戶端，[去課堂](/03-GettingStarted/06-http-streaming/README.md)

- **7 利用 AI Toolkit for VSCode** 去消費同測試你嘅 MCP 客戶端同伺服器，[去課堂](/03-GettingStarted/07-aitk/README.md)

- **8 測試**。呢度我哋會特別集中講點樣用唔同方法測試我哋嘅伺服器同客戶端，[去課堂](/03-GettingStarted/08-testing/README.md)

- **9 部署**。呢章會睇下唔同嘅方法去部署你嘅 MCP 解決方案，[去課堂](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) 係一個開放協議，標準化咗應用程式點樣向 LLM 提供上下文。你可以將 MCP 想像成 AI 應用嘅 USB-C 端口——佢提供一個標準化嘅方法，將 AI 模型連接到唔同嘅數據來源同工具。

## Learning Objectives

完成呢堂課後，你會識：

- 為 MCP 喺 C#、Java、Python、TypeScript 同 JavaScript 設定開發環境
- 建立同部署基本嘅 MCP 伺服器，包含自訂功能（資源、提示同工具）
- 建立可以連接 MCP 伺服器嘅主機應用程式
- 測試同除錯 MCP 實現
- 了解常見設定問題同解決方案
- 將你嘅 MCP 實現連接到熱門嘅 LLM 服務

## Setting Up Your MCP Environment

開始用 MCP 之前，好重要嘅係準備好開發環境，仲要明白基本工作流程。呢部分會帶你完成初步嘅設定步驟，確保你用 MCP 可以順利起步。

### Prerequisites

開始 MCP 開發之前，請確保你有：

- **開發環境**：根據你選擇嘅語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代代碼編輯器
- **套件管理工具**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 金鑰**：用於你主機應用程式打算使用嘅 AI 服務


### Official SDKs

喺之後嘅章節你會見到用 Python、TypeScript、Java 同 .NET 寫嘅解決方案。以下係所有官方支援嘅 SDK。

MCP 提供多種語言嘅官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 同 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 同 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方嘅 TypeScript 實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方嘅 Python 實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方嘅 Kotlin 實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 同 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方嘅 Rust 實現

## Key Takeaways

- 設定 MCP 開發環境用語言專用嘅 SDK 好簡單
- 建立 MCP 伺服器涉及創建同註冊有清晰結構嘅工具
- MCP 客戶端會連接伺服器同模型，利用擴展功能
- 測試同除錯對可靠嘅 MCP 實現好重要
- 部署選項由本地開發到雲端方案都有

## Practicing

我哋有一啲範例配合呢部分所有章節嘅練習。另外每個章節都有自己嘅練習同作業。

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

下一步: [創建你嘅第一個 MCP Server](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或誤釋概不負責。