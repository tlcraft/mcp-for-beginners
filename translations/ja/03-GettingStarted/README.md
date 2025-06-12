<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T21:35:36+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ja"
}
-->
## はじめに

このセクションは複数のレッスンで構成されています：

- **1 あなたの最初のサーバー**。最初のレッスンでは、最初のサーバーの作成方法と、サーバーのテストやデバッグに役立つインスペクターツールの使い方を学びます。[レッスンへ](/03-GettingStarted/01-first-server/README.md)

- **2 クライアント**。このレッスンでは、サーバーに接続できるクライアントの書き方を学びます。[レッスンへ](/03-GettingStarted/02-client/README.md)

- **3 LLMを使ったクライアント**。より良いクライアントを書く方法として、LLMを追加してサーバーと「交渉」しながら動作させる方法を学びます。[レッスンへ](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio CodeでのGitHub Copilot Agentモードを使ったサーバーの利用**。ここでは、Visual Studio Code内でMCPサーバーを実行する方法を見ていきます。[レッスンへ](/03-GettingStarted/04-vscode/README.md)

- **5 SSE（Server Sent Events）からの利用**。SSEはサーバーからクライアントへのストリーミングの標準で、サーバーがHTTPを通じてリアルタイム更新をプッシュできます。[レッスンへ](/03-GettingStarted/05-sse-server/README.md)

- **6 MCPによるHTTPストリーミング（Streamable HTTP）**。最新のHTTPストリーミングや進捗通知について学び、Streamable HTTPを使ったスケーラブルでリアルタイムなMCPサーバーとクライアントの実装方法を学びます。[レッスンへ](/03-GettingStarted/06-http-streaming/README.md)

- **7 VSCode用AIツールキットの活用**。MCPクライアントとサーバーの利用やテストに役立つツールキットの使い方を学びます。[レッスンへ](/03-GettingStarted/07-aitk/README.md)

- **8 テスト**。ここでは、サーバーとクライアントを様々な方法でテストする方法に焦点を当てます。[レッスンへ](/03-GettingStarted/08-testing/README.md)

- **9 デプロイ**。この章では、MCPソリューションのさまざまなデプロイ方法を見ていきます。[レッスンへ](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) は、アプリケーションがLLMにコンテキストを提供する方法を標準化したオープンプロトコルです。MCPはAIアプリケーションのためのUSB-Cポートのようなもので、AIモデルをさまざまなデータソースやツールに接続する標準的な手段を提供します。

## 学習目標

このレッスンを終える頃には、以下ができるようになります：

- C#、Java、Python、TypeScript、JavaScript向けのMCP開発環境のセットアップ
- カスタム機能（リソース、プロンプト、ツール）を備えた基本的なMCPサーバーの構築とデプロイ
- MCPサーバーに接続するホストアプリケーションの作成
- MCP実装のテストとデバッグ
- 一般的なセットアップの課題とその解決方法の理解
- MCP実装を主要なLLMサービスに接続する方法

## MCP環境のセットアップ

MCPを使い始める前に、開発環境を整え基本的なワークフローを理解しておくことが重要です。このセクションでは、スムーズにMCPを始めるための初期設定手順を案内します。

### 前提条件

MCP開発に入る前に、以下を準備してください：

- **開発環境**：選択した言語（C#、Java、Python、TypeScript、JavaScript）用
- **IDE/エディター**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm、またはその他のモダンなコードエディター
- **パッケージマネージャー**：NuGet、Maven/Gradle、pip、npm/yarnなど
- **APIキー**：ホストアプリケーションで利用予定のAIサービス用

### 公式SDK

今後の章では、Python、TypeScript、Java、.NETを使ったソリューションが登場します。以下は公式にサポートされているSDKです。

MCPは複数の言語向けに公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと共同でメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと共同でメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式のTypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式のPython実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式のKotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと共同でメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式のRust実装

## 重要なポイント

- MCP開発環境は言語別SDKで簡単にセットアップ可能
- MCPサーバーの構築は、明確なスキーマを持つツールの作成と登録を含む
- MCPクライアントはサーバーやモデルに接続し、拡張機能を活用
- テストとデバッグは信頼性の高いMCP実装に不可欠
- デプロイはローカル開発からクラウドベースまで多様な選択肢がある

## 実践

このセクションの各章で出てくる演習を補完するサンプルセットがあります。さらに、各章にも独自の演習や課題があります。

- [Java 電卓](./samples/java/calculator/README.md)
- [.Net 電卓](../../../03-GettingStarted/samples/csharp)
- [JavaScript 電卓](./samples/javascript/README.md)
- [TypeScript 電卓](./samples/typescript/README.md)
- [Python 電卓](../../../03-GettingStarted/samples/python)

## 追加リソース

- [AzureでModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Appsを使ったリモートMCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次にやること

次へ：[最初のMCPサーバーを作成する](/03-GettingStarted/01-first-server/README.md)

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の言語で記載されたオリジナルの文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の違いについて、当方は一切の責任を負いかねます。