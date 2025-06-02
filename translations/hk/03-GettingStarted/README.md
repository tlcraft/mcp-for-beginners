<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:21:28+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hk"
}
-->
## Getting Started  

呢個部分包括幾個課堂：

- **-1- 你嘅第一個伺服器**，喺呢個第一課，你會學到點樣建立你嘅第一個伺服器，並用 inspector 工具檢查佢，呢個係一個好有用嘅方法去測試同除錯你嘅伺服器，[去課堂](/03-GettingStarted/01-first-server/README.md)

- **-2- 客戶端**，喺呢課你會學到點寫一個可以連接你伺服器嘅客戶端，[去課堂](/03-GettingStarted/02-client/README.md)

- **-3- 帶 LLM 嘅客戶端**，寫客戶端更好嘅方法係加埋 LLM，咁佢可以同你嘅伺服器「傾偈」決定要做啲乜，[去課堂](/03-GettingStarted/03-llm-client/README.md)

- **-4- 喺 Visual Studio Code 用 GitHub Copilot Agent 模式消費伺服器**。呢度我哋會睇點喺 Visual Studio Code 裡面運行我哋嘅 MCP Server，[去課堂](/03-GettingStarted/04-vscode/README.md)

- **-5- 用 SSE (Server Sent Events) 消費**。SSE 係一個伺服器到客戶端嘅串流標準，令伺服器可以透過 HTTP 即時推送更新俾客戶端，[去課堂](/03-GettingStarted/05-sse-server/README.md)

- **-6- 善用 AI Toolkit for VSCode** 去消費同測試你嘅 MCP 客戶端同伺服器，[去課堂](/03-GettingStarted/06-aitk/README.md)

- **-7 測試**。呢度我哋會特別集中講點樣用唔同方法測試我哋嘅伺服器同客戶端，[去課堂](/03-GettingStarted/07-testing/README.md)

- **-8- 部署**。呢章會睇下唔同方法去部署你嘅 MCP 解決方案，[去課堂](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) 係一個開放協議，標準化應用程式點樣提供上下文俾 LLM。你可以將 MCP 想像成 AI 應用嘅 USB-C 端口 — 佢提供咗一個標準化嘅方法去連接 AI 模型同唔同嘅數據來源同工具。

## 學習目標

完成呢課後，你會識得：

- 為 C#、Java、Python、TypeScript 同 JavaScript 設置 MCP 嘅開發環境
- 建立同部署具自訂功能（資源、提示同工具）嘅基本 MCP 伺服器
- 建立連接 MCP 伺服器嘅主機應用程式
- 測試同除錯 MCP 嘅實現
- 理解常見嘅設置問題同解決方案
- 將你嘅 MCP 實現連接到流行嘅 LLM 服務

## 設置你嘅 MCP 環境

開始使用 MCP 之前，好重要嘅係準備好你嘅開發環境，同埋了解基本嘅工作流程。呢部分會帶你完成初步設置步驟，確保你可以順利開始用 MCP。

### 先決條件

開始 MCP 開發前，請確保你有：

- **開發環境**：適用於你揀嘅語言（C#、Java、Python、TypeScript 或 JavaScript）
- **IDE/編輯器**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm 或任何現代化嘅程式碼編輯器
- **套件管理器**：NuGet、Maven/Gradle、pip 或 npm/yarn
- **API 金鑰**：用於你計劃喺主機應用程式使用嘅 AI 服務

### 官方 SDKs

喺接下來嘅章節，你會見到用 Python、TypeScript、Java 同 .NET 建立嘅解決方案。以下係所有官方支持嘅 SDK。

MCP 提供多種語言嘅官方 SDK：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - 與 Microsoft 合作維護
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - 與 Spring AI 合作維護
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 官方 TypeScript 實現
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 官方 Python 實現
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 官方 Kotlin 實現
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - 與 Loopwork AI 合作維護
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 官方 Rust 實現

## 主要重點

- 用針對語言嘅 SDK 設置 MCP 開發環境好簡單
- 建立 MCP 伺服器需要創建同註冊有清晰結構嘅工具
- MCP 客戶端會連接伺服器同模型，發揮擴展功能
- 測試同除錯對穩定嘅 MCP 實現好重要
- 部署選擇由本地開發到雲端方案都有

## 練習

我哋準備咗一套範例，配合你喺呢部分所有章節嘅練習。此外，每個章節都有自己嘅練習同作業。

- [Java 計算機](./samples/java/calculator/README.md)
- [.Net 計算機](../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算機](./samples/javascript/README.md)
- [TypeScript 計算機](./samples/typescript/README.md)
- [Python 計算機](../../../03-GettingStarted/samples/python)

## 額外資源

- [用 Model Context Protocol 喺 Azure 建立 Agents](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [用 Azure Container Apps 遠端 MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 下一步

下一步: [建立你嘅第一個 MCP Server](/03-GettingStarted/01-first-server/README.md)

**免責聲明**：  
本文件係用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯。雖然我哋努力追求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。