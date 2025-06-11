<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:03:22+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ja"
}
-->
## はじめに  

このセクションは複数のレッスンで構成されています：

- **1 あなたの最初のサーバー**：最初のレッスンでは、最初のサーバーを作成し、インスペクターツールで検査する方法を学びます。これはサーバーのテストやデバッグに役立つ重要な手法です。[レッスンへ](/03-GettingStarted/01-first-server/README.md)

- **2 クライアント**：このレッスンでは、サーバーに接続できるクライアントの書き方を学びます。[レッスンへ](/03-GettingStarted/02-client/README.md)

- **3 LLMを使ったクライアント**：より良いクライアントの作り方として、LLMを組み込んでサーバーと「交渉」しながら動作させる方法を学びます。[レッスンへ](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio CodeでGitHub Copilot Agentモードのサーバーを利用する**：ここでは、Visual Studio Code内でMCPサーバーを実行する方法を見ていきます。[レッスンへ](/03-GettingStarted/04-vscode/README.md)

- **5 SSE（Server Sent Events）からの利用**：SSEはサーバーからクライアントへリアルタイム更新をHTTP経由で送る標準技術です。[レッスンへ](/03-GettingStarted/05-sse-server/README.md)

- **6 VSCode用AIツールキットの活用**：MCPクライアントやサーバーを消費しテストするためのツールキットを利用します。[レッスンへ](/03-GettingStarted/06-aitk/README.md)

- **7 テスト**：サーバーとクライアントをさまざまな方法でテストする方法に特に焦点を当てます。[レッスンへ](/03-GettingStarted/07-testing/README.md)

- **8 デプロイ**：MCPソリューションを展開する様々な方法を解説します。[レッスンへ](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol（MCP）は、アプリケーションがLLMにコンテキストを提供する方法を標準化するオープンプロトコルです。MCPはAIアプリケーションのUSB-Cポートのようなもので、AIモデルをさまざまなデータソースやツールに接続するための標準的な手段を提供します。

## 学習目標

このレッスンの終了時には、以下ができるようになります：

- C#、Java、Python、TypeScript、JavaScriptでのMCP開発環境のセットアップ
- カスタム機能（リソース、プロンプト、ツール）を備えた基本的なMCPサーバーの構築とデプロイ
- MCPサーバーに接続するホストアプリケーションの作成
- MCP実装のテストとデバッグ
- 一般的なセットアップの課題とその解決方法の理解
- MCP実装を人気のLLMサービスに接続する方法

## MCP環境のセットアップ

MCPの開発を始める前に、開発環境を整え、基本的なワークフローを理解することが重要です。このセクションでは、MCPをスムーズに始めるための初期設定手順を案内します。

### 前提条件

MCP開発に取り掛かる前に、以下を準備してください：

- **開発環境**：選択した言語（C#、Java、Python、TypeScript、JavaScript）の環境
- **IDE/エディタ**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm、または最新のコードエディタ
- **パッケージマネージャー**：NuGet、Maven/Gradle、pip、npm/yarnなど
- **APIキー**：ホストアプリケーションで使用する予定のAIサービス用

### 公式SDK

今後の章ではPython、TypeScript、Java、.NETを使ったソリューションが登場します。以下は公式にサポートされているSDKです。

MCPは複数言語向けの公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと協力してメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと協力してメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式のTypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式のPython実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式のKotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと協力してメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式のRust実装

## 重要ポイント

- MCP開発環境は言語別のSDKで簡単にセットアップ可能
- MCPサーバー構築は明確なスキーマを持つツールの作成と登録が鍵
- MCPクライアントはサーバーやモデルに接続し拡張機能を活用
- テストとデバッグは信頼性あるMCP実装に不可欠
- デプロイ方法はローカル開発からクラウドベースまで多様

## 実践

このセクションのすべての章で出てくる演習を補完するサンプル集があります。さらに各章には独自の演習や課題も用意されています。

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## 追加リソース

- [Azure上でModel Context Protocolを使ったエージェントの構築](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Appsを使ったリモートMCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCPエージェント](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 次にやること

次へ：[最初のMCPサーバーの作成](/03-GettingStarted/01-first-server/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文はあくまで正本として扱われるべきものです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や解釈の相違について、当方は一切の責任を負いかねます。