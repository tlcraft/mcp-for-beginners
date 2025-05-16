<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-16T14:54:35+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ja"
}
-->
## はじめに  

このセクションは複数のレッスンで構成されています：

- **-1- あなたの最初のサーバー**。最初のレッスンでは、最初のサーバーの作成方法と、サーバーをテスト・デバッグするのに役立つインスペクターツールの使い方を学びます。[レッスンへ](/03-GettingStarted/01-first-server/README.md)

- **-2- クライアント**。このレッスンでは、サーバーに接続できるクライアントの書き方を学びます。[レッスンへ](/03-GettingStarted/02-client/README.md)

- **-3- LLMを使ったクライアント**。より良いクライアントの書き方として、LLMを追加してサーバーと「交渉」しながら動作させる方法を紹介します。[レッスンへ](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio CodeでGitHub Copilot Agentモードのサーバーを利用する**。ここでは、Visual Studio Code内からMCPサーバーを実行する方法を見ていきます。[レッスンへ](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE（Server Sent Events）を使った利用**。SSEはサーバーからクライアントへのストリーミングの標準で、HTTP経由でリアルタイム更新をプッシュできます。[レッスンへ](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode用AIツールキットの活用**。MCPクライアントとサーバーの利用とテストに役立ちます。[レッスンへ](/03-GettingStarted/06-aitk/README.md)

- **-7- テスト**。サーバーとクライアントを様々な方法でテストする方法に焦点を当てます。[レッスンへ](/03-GettingStarted/07-testing/README.md)

- **-8- デプロイ**。MCPソリューションのさまざまなデプロイ方法を紹介します。[レッスンへ](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol（MCP）は、アプリケーションがLLMにコンテキストを提供する方法を標準化したオープンプロトコルです。MCPはAIアプリケーションのUSB-Cポートのようなもので、AIモデルをさまざまなデータソースやツールに接続するための標準的な方法を提供します。

## 学習目標

このレッスンの終了時には、以下ができるようになります：

- C#、Java、Python、TypeScript、JavaScriptでのMCP開発環境の構築
- カスタム機能（リソース、プロンプト、ツール）を備えた基本的なMCPサーバーの構築とデプロイ
- MCPサーバーに接続するホストアプリケーションの作成
- MCP実装のテストとデバッグ
- よくあるセットアップの課題とその解決方法の理解
- 人気のLLMサービスへのMCP実装の接続

## MCP環境のセットアップ

MCPを使い始める前に、開発環境を整え基本的なワークフローを理解することが重要です。このセクションでは、スムーズにMCPを始めるための初期設定手順を案内します。

### 前提条件

MCP開発を始める前に、以下を準備してください：

- **開発環境**：選択した言語（C#、Java、Python、TypeScript、JavaScript）用の環境
- **IDE/エディタ**：Visual Studio、Visual Studio Code、IntelliJ、Eclipse、PyCharm、または最新のコードエディタ
- **パッケージマネージャー**：NuGet、Maven/Gradle、pip、npm/yarn
- **APIキー**：ホストアプリケーションで使用予定のAIサービス用

### 公式SDK

今後の章ではPython、TypeScript、Java、.NETを使ったソリューションが登場します。以下は公式にサポートされているSDKです。

MCPは複数の言語向けに公式SDKを提供しています：
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoftと共同でメンテナンス
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AIと共同でメンテナンス
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 公式のTypeScript実装
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 公式のPython実装
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 公式のKotlin実装
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AIと共同でメンテナンス
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 公式のRust実装

## 重要なポイント

- MCP開発環境のセットアップは言語別SDKで簡単に行える
- MCPサーバー構築は明確なスキーマを持つツールの作成と登録が必要
- MCPクライアントはサーバーやモデルに接続して拡張機能を活用する
- テストとデバッグは信頼性の高いMCP実装に不可欠
- デプロイはローカル開発からクラウドベースまで多様な選択肢がある

## 実践

このセクションのすべての章で扱う演習を補完するサンプルを用意しています。さらに各章には独自の演習や課題もあります。

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## 追加リソース

- [MCP GitHubリポジトリ](https://github.com/microsoft/mcp-for-beginners)

## 次に進む

次へ：[最初のMCPサーバーを作成する](/03-GettingStarted/01-first-server/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の相違について、一切の責任を負いかねます。