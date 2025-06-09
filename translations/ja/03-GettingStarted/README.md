<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:23:16+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ja"
}
-->
## はじめに  

このセクションは複数のレッスンで構成されています：

- **-1- あなたの最初のサーバー**、この最初のレッスンでは、最初のサーバーの作成方法と、インスペクターツールを使った検査方法を学びます。これはサーバーのテストやデバッグに非常に役立ちます。[レッスンへ](/03-GettingStarted/01-first-server/README.md)

- **-2- クライアント**、このレッスンでは、サーバーに接続できるクライアントの書き方を学びます。[レッスンへ](/03-GettingStarted/02-client/README.md)

- **-3- LLMを使ったクライアント**、クライアントにLLMを追加して、サーバーと「交渉」しながら動作させる、より良い方法を学びます。[レッスンへ](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio CodeでのGitHub Copilot Agentモードのサーバー利用**。ここでは、Visual Studio Code内でMCPサーバーを動かす方法を見ていきます。[レッスンへ](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE（Server Sent Events）からの利用**。SSEはサーバーからクライアントへのストリーミング標準で、HTTP経由でリアルタイム更新をプッシュできます。[レッスンへ](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode用AIツールキットの活用**。MCPクライアントとサーバーの利用やテストに役立ちます。[レッスンへ](/03-GettingStarted/06-aitk/README.md)

- **-7- テスト**。ここでは特に、サーバーとクライアントをさまざまな方法でテストする方法に焦点を当てます。[レッスンへ](/03-GettingStarted/07-testing/README.md)

- **-8- デプロイ**。この章では、MCPソリューションのさまざまなデプロイ方法を見ていきます。[レッスンへ](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol（MCP）は、アプリケーションがLLMにコンテキストを提供する方法を標準化するオープンプロトコルです。MCPはAIアプリケーションのためのUSB-Cポートのようなもので、AIモデルをさまざまなデータソースやツールに接続する標準的な方法を提供します。

## 学習目標

このレッスンを終える頃には、以下ができるようになります：

- C#, Java, Python, TypeScript, JavaScript向けのMCP開発環境のセットアップ
- カスタム機能（リソース、プロンプト、ツール）を備えた基本的なMCPサーバーの構築とデプロイ
- MCPサーバーに接続するホストアプリケーションの作成
- MCP実装のテストとデバッグ
- 一般的なセットアップの課題とその解決方法の理解
- MCP実装を主要なLLMサービスに接続する方法

## MCP環境のセットアップ

MCPでの作業を始める前に、開発環境の準備と基本的なワークフローの理解が重要です。このセクションでは、MCPをスムーズに始めるための初期設定手順を案内します。

### 前提条件

MCP開発に取り掛かる前に、以下を準備してください：

- **開発環境**：選択した言語（C#, Java, Python, TypeScript, JavaScript）用
- **IDE/エディター**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm、またはその他のモダンなコードエディター
- **パッケージマネージャー**：NuGet、Maven/Gradle、pip、npm/yarn
- **APIキー**：ホストアプリケーションで使用予定のAIサービス用

### 公式SDK

これからの章では、Python、TypeScript、Java、.NETを使ったソリューションが紹介されます。以下は公式にサポートされているSDKです。

MCPは複数言語向けに公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftとの共同メンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIとの共同メンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式TypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式Python実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式Kotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIとの共同メンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式Rust実装

## 重要なポイント

- 言語別SDKを使えばMCP開発環境のセットアップは簡単
- MCPサーバーの構築は、明確なスキーマを持つツールの作成と登録が基本
- MCPクライアントはサーバーやモデルに接続して拡張機能を活用
- テストとデバッグは信頼性の高いMCP実装に不可欠
- デプロイ方法はローカル開発からクラウドベースまで多様

## 実践

このセクションのすべての章で出てくる演習を補完するサンプルを用意しています。さらに各章ごとに独自の演習や課題もあります。

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## 追加リソース

- [Azure上でModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Appsを使ったリモートMCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次にやること

次へ：[最初のMCPサーバーの作成](/03-GettingStarted/01-first-server/README.md)

**免責事項**:  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。正式な情報源としては、原文（原言語の文書）を参照してください。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、一切の責任を負いかねます。