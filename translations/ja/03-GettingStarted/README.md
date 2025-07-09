<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:28:31+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ja"
}
-->
## はじめに  

このセクションは複数のレッスンで構成されています：

- **1 あなたの最初のサーバー**、この最初のレッスンでは、最初のサーバーの作成方法と、サーバーのテストやデバッグに役立つインスペクターツールの使い方を学びます。[レッスンへ](01-first-server/README.md)

- **2 クライアント**、このレッスンでは、サーバーに接続できるクライアントの書き方を学びます。[レッスンへ](02-client/README.md)

- **3 LLMを使ったクライアント**、クライアントにLLMを組み込むことで、サーバーと「交渉」しながら動作を決める、より高度なクライアントの作り方を学びます。[レッスンへ](03-llm-client/README.md)

- **4 Visual Studio CodeでのGitHub Copilot Agentモードのサーバー利用**。ここでは、Visual Studio Code内でMCPサーバーを動かす方法を見ていきます。[レッスンへ](04-vscode/README.md)

- **5 SSE（Server Sent Events）からの利用**。SSEはサーバーからクライアントへのストリーミングの標準で、HTTP経由でリアルタイム更新をプッシュできます。[レッスンへ](05-sse-server/README.md)

- **6 MCPによるHTTPストリーミング（Streamable HTTP）**。最新のHTTPストリーミング技術、進捗通知、スケーラブルでリアルタイムなMCPサーバーとクライアントの実装方法を学びます。[レッスンへ](06-http-streaming/README.md)

- **7 VSCode用AIツールキットの活用**。MCPクライアントとサーバーの利用とテストに役立つツールキットの使い方を学びます。[レッスンへ](07-aitk/README.md)

- **8 テスト**。ここでは、サーバーとクライアントをさまざまな方法でテストする方法に焦点を当てます。[レッスンへ](08-testing/README.md)

- **9 デプロイ**。この章では、MCPソリューションのさまざまなデプロイ方法を見ていきます。[レッスンへ](09-deployment/README.md)


Model Context Protocol（MCP）は、アプリケーションがLLMにコンテキストを提供する方法を標準化したオープンプロトコルです。MCPはAIアプリケーションのUSB-Cポートのようなもので、AIモデルをさまざまなデータソースやツールに接続するための標準的な手段を提供します。

## 学習目標

このレッスンを終える頃には、以下ができるようになります：

- C#, Java, Python, TypeScript, JavaScriptでのMCP開発環境のセットアップ
- カスタム機能（リソース、プロンプト、ツール）を備えた基本的なMCPサーバーの構築とデプロイ
- MCPサーバーに接続するホストアプリケーションの作成
- MCP実装のテストとデバッグ
- よくあるセットアップの課題とその解決策の理解
- 人気のLLMサービスへのMCP実装の接続

## MCP環境のセットアップ

MCPの作業を始める前に、開発環境を整え、基本的なワークフローを理解することが重要です。このセクションでは、MCPをスムーズに始めるための初期設定手順を案内します。

### 前提条件

MCP開発に取り掛かる前に、以下を準備してください：

- **開発環境**：選択した言語（C#, Java, Python, TypeScript, JavaScript）用
- **IDE/エディター**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm、または任意のモダンなコードエディター
- **パッケージマネージャー**：NuGet、Maven/Gradle、pip、npm/yarn
- **APIキー**：ホストアプリケーションで使用予定のAIサービス用

### 公式SDK

今後の章では、Python、TypeScript、Java、.NETを使ったソリューションを紹介します。以下は公式にサポートされているSDKです。

MCPは複数言語向けに公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと共同でメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと共同でメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式TypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式Python実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式Kotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと共同でメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式Rust実装

## 重要なポイント

- MCP開発環境のセットアップは、言語別SDKで簡単に行えます
- MCPサーバーの構築は、明確なスキーマを持つツールの作成と登録が必要です
- MCPクライアントはサーバーやモデルに接続し、拡張機能を活用します
- テストとデバッグは信頼性の高いMCP実装に不可欠です
- デプロイはローカル開発からクラウドベースまで多様な選択肢があります

## 実践

このセクションのすべての章で紹介する演習を補完するサンプルを用意しています。さらに各章には独自の演習や課題もあります。

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## 追加リソース

- [Azure上でModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container AppsでのリモートMCP（Node.js/TypeScript/JavaScript）](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次に進む

次へ：[最初のMCPサーバーの作成](01-first-server/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。