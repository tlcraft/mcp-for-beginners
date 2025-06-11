<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:02:35+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hk"
}
-->
## Getting Started  

呢部分包括咗幾堂課：

- **1 Your first server**，喺呢堂課入面，你會學識點樣建立你嘅第一個 server，仲可以用 inspector 工具檢查佢，呢個係一個好有用嘅方法去測試同埋除錯你嘅 server，[去課堂](/03-GettingStarted/01-first-server/README.md)

- **2 Client**，喺呢堂課，你會學識點樣寫一個 client，可以連接到你嘅 server，[去課堂](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**，寫 client 仲有一個更好嘅方法，就係加入 LLM，咁佢可以同你嘅 server “傾掂”要做啲乜，[去課堂](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**。呢度我哋會睇下點樣喺 Visual Studio Code 裡面運行我哋嘅 MCP Server，[去課堂](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE 係一個標準，令 server 可以用 HTTP 直接推送即時更新畀 client，[去課堂](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilising AI Toolkit for VSCode** 用嚟消費同測試你嘅 MCP Clients 同 Servers，[去課堂](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**。呢度我哋會特別集中講點樣用唔同方法測試我哋嘅 server 同 client，[去課堂](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**。呢章會介紹唔同嘅方法去部署你嘅 MCP 解決方案，[去課堂](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) 係一個開放協議，標準化咗應用點樣向 LLM 提供上下文。你可以將 MCP 想像成 AI 應用嘅 USB-C 端口，佢提供一個標準化嘅方式，連接 AI 模型同唔同嘅數據來源同工具。

## Learning Objectives

完成呢堂課後，你將能夠：

- 為 C#、Java、Python、TypeScript 同 JavaScript 嘅 MCP 設置開發環境
- 建立同部署帶有自訂功能（資源、提示、工具）嘅基本 MCP 服務器
- 建立連接 MCP 服務器嘅主機應用程式
- 測試同除錯 MCP 實現
- 理解常見設置難題同解決方法
- 將你嘅 MCP 實現連接到熱門嘅 LLM 服務

## Setting Up Your MCP Environment

開始用 MCP 之前，準備好開發環境同了解基本工作流程好重要。呢部分會引導你完成初步設置步驟，確保你順利開始用 MCP。

### Prerequisites

開始 MCP 開發之前，請確保你有：

- **開發環境**：適用於你選擇嘅語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代代碼編輯器
- **套件管理器**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 金鑰**：用於你主機應用中打算使用嘅 AI 服務

### Official SDKs

未來章節你會見到用 Python、TypeScript、Java 同 .NET 建立嘅解決方案。以下係所有官方支持嘅 SDK。

MCP 提供多種語言嘅官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實現

## Key Takeaways

- 設置 MCP 開發環境好直接，用語言專用 SDK
- 建立 MCP 服務器需要創建同註冊帶有清晰 schema 嘅工具
- MCP 客戶端連接服務器同模型，以利用擴展功能
- 測試同除錯對可靠嘅 MCP 實現好重要
- 部署選項由本地開發到雲端解決方案都有

## Practicing

我哋有一組示例，配合呢部分所有章節嘅練習。另外，每章都有自己嘅練習同作業。

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

下一步：[Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋盡力確保準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原文文件嘅母語版本應被視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。