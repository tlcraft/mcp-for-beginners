<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:04:23+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ja"
}
-->
# 実践的な実装

実践的な実装は、Model Context Protocol（MCP）の力を実感できる場です。MCPの理論やアーキテクチャを理解することは重要ですが、実際にこれらの概念を活用して、現実の問題を解決するソリューションを構築、テスト、デプロイすることで真の価値が生まれます。本章では、概念的な知識と実践的な開発のギャップを埋め、MCPベースのアプリケーションを実際に動かすプロセスを案内します。

インテリジェントアシスタントの開発、ビジネスワークフローへのAI統合、データ処理のためのカスタムツールの構築など、どんな用途であってもMCPは柔軟な基盤を提供します。言語に依存しない設計と主要なプログラミング言語向けの公式SDKにより、幅広い開発者が利用可能です。これらのSDKを活用することで、迅速にプロトタイプを作成し、反復し、異なるプラットフォームや環境でスケールさせることができます。

以下のセクションでは、C#、Java、TypeScript、JavaScript、PythonでのMCP実装の実例、サンプルコード、デプロイ戦略を紹介します。MCPサーバーのデバッグやテスト、API管理、Azureを使ったクラウドへのデプロイ方法も学べます。これらの実践的なリソースは学習を加速し、堅牢で本番対応のMCPアプリケーションを自信を持って構築できるよう設計されています。

## 概要

このレッスンでは、複数のプログラミング言語にわたるMCP実装の実践的な側面に焦点を当てます。C#、Java、TypeScript、JavaScript、PythonのMCP SDKを使って堅牢なアプリケーションを構築し、MCPサーバーのデバッグとテストを行い、再利用可能なリソース、プロンプト、ツールを作成する方法を探ります。

## 学習目標

このレッスンの終了時には、以下ができるようになります：
- 公式SDKを使ってさまざまなプログラミング言語でMCPソリューションを実装する
- MCPサーバーを体系的にデバッグ・テストする
- サーバー機能（リソース、プロンプト、ツール）を作成・利用する
- 複雑なタスクに対応する効果的なMCPワークフローを設計する
- パフォーマンスと信頼性を考慮したMCP実装を最適化する

## 公式SDKリソース

Model Context Protocolは複数の言語向けに公式SDKを提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKの活用

このセクションでは、複数のプログラミング言語でのMCP実装の実例を紹介します。サンプルコードは`samples`ディレクトリ内に言語別に整理されています。

### 利用可能なサンプル

リポジトリには以下の言語でのサンプル実装が含まれています：

- C#
- Java
- TypeScript
- JavaScript
- Python

それぞれのサンプルは、その言語とエコシステムに特化したMCPの主要概念と実装パターンを示しています。

## コアサーバー機能

MCPサーバーは以下の機能を組み合わせて実装できます：

### Resources（リソース）
ユーザーやAIモデルが利用するコンテキストやデータを提供します：
- ドキュメントリポジトリ
- ナレッジベース
- 構造化データソース
- ファイルシステム

### Prompts（プロンプト）
ユーザー向けのテンプレート化されたメッセージやワークフローです：
- 事前定義された会話テンプレート
- ガイド付きインタラクションパターン
- 特化した対話構造

### Tools（ツール）
AIモデルが実行する機能です：
- データ処理ユーティリティ
- 外部API統合
- 計算機能
- 検索機能

## サンプル実装：C#

公式C# SDKリポジトリには、MCPの様々な側面を示す複数のサンプル実装が含まれています：

- **Basic MCP Client**：MCPクライアントを作成しツールを呼び出すシンプルな例
- **Basic MCP Server**：基本的なツール登録を備えた最小限のサーバー実装
- **Advanced MCP Server**：ツール登録、認証、エラーハンドリングを備えたフル機能サーバー
- **ASP.NET Integration**：ASP.NET Coreとの統合例
- **Tool Implementation Patterns**：異なる複雑さのツール実装パターン

MCP C# SDKはプレビュー段階であり、APIは変更される可能性があります。SDKの進化に伴い、このブログは継続的に更新されます。

### 主な特徴
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [最初のMCPサーバー構築](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

C#の完全な実装サンプルは[公式C# SDKサンプルリポジトリ](https://github.com/modelcontextprotocol/csharp-sdk)をご覧ください。

## サンプル実装：Java

Java SDKはエンタープライズグレードの機能を備えた堅牢なMCP実装オプションを提供します。

### 主な特徴

- Spring Framework統合
- 強力な型安全性
- リアクティブプログラミング対応
- 包括的なエラーハンドリング

完全なJava実装サンプルは、samplesディレクトリ内の[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)をご覧ください。

## サンプル実装：JavaScript

JavaScript SDKは軽量で柔軟なMCP実装アプローチを提供します。

### 主な特徴

- Node.jsとブラウザ対応
- PromiseベースのAPI
- Expressなどのフレームワークとの簡単な統合
- ストリーミング対応のWebSocketサポート

完全なJavaScript実装サンプルはsamplesディレクトリ内の[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)をご覧ください。

## サンプル実装：Python

Python SDKはPythonらしいアプローチでMCP実装を提供し、優れたMLフレームワーク統合を備えています。

### 主な特徴

- asyncioを使ったasync/awaitサポート
- FlaskおよびFastAPIとの統合
- シンプルなツール登録
- 人気のMLライブラリとのネイティブ統合

完全なPython実装サンプルはsamplesディレクトリ内の[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)をご覧ください。

## API管理

Azure API ManagementはMCPサーバーのセキュリティを確保する優れた方法です。基本的な考え方は、Azure API ManagementインスタンスをMCPサーバーの前に配置し、以下のような必要な機能を担当させることです：

- レート制限
- トークン管理
- モニタリング
- ロードバランシング
- セキュリティ

### Azureサンプル

こちらはまさにそれを行うAzureサンプル、すなわち「MCPサーバーを作成し、Azure API Managementで保護する」例です：[リンク](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

以下の画像で認証フローがどのように行われるか確認できます：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

上記の画像では以下の処理が行われています：

- Microsoft Entraを使った認証／認可
- Azure API Managementがゲートウェイとして動作し、ポリシーでトラフィックを管理
- Azure Monitorがすべてのリクエストをログに記録し、分析に利用

#### 認可フロー

認可フローをもう少し詳しく見てみましょう：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP認可仕様

詳細は[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)をご覧ください。

## AzureへのリモートMCPサーバーのデプロイ

先に紹介したサンプルをデプロイしてみましょう：

1. リポジトリをクローン

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App`プロバイダーを登録し、登録完了を確認

    `az provider register --namespace Microsoft.App --wait`  
    または  
    `Register-AzResourceProvider -ProviderNamespace Microsoft.App`  
    しばらくしてから  
    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`  
    で状態を確認

3. 次の[azd](https://aka.ms/azd)コマンドを実行して、API Managementサービス、Function App（コード付き）、その他必要なAzureリソースをプロビジョニング

    ```shell
    azd up
    ```

    このコマンドでAzure上にすべてのクラウドリソースがデプロイされます。

### MCP Inspectorを使ったサーバーテスト

1. **新しいターミナルウィンドウ**でMCP Inspectorをインストールして起動

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    以下のようなインターフェースが表示されるはずです：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

2. アプリが表示するURL（例：http://127.0.0.1:6274/#resources）をCTRLクリックしてMCP Inspectorウェブアプリをロード
3. トランスポートタイプを`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`に設定し、**Connect**をクリック

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**。ツールをクリックし、**Run Tool**を実行

すべての手順が成功すれば、MCPサーバーに接続され、ツールを呼び出せたことになります。

## Azure向けMCPサーバー

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：このリポジトリ群は、Python、C# .NET、Node/TypeScriptを使ってAzure Functions上にカスタムリモートMCP（Model Context Protocol）サーバーを構築・デプロイするためのクイックスタートテンプレートです。

サンプルは開発者に以下を提供します：

- ローカルでのビルドと実行：ローカルマシンでMCPサーバーを開発・デバッグ
- Azureへのデプロイ：シンプルなazd upコマンドでクラウドへ簡単にデプロイ
- クライアントからの接続：VS CodeのCopilotエージェントモードやMCP Inspectorツールなど多様なクライアントから接続可能

### 主な特徴：

- セキュリティ設計：MCPサーバーはキーとHTTPSで保護
- 認証オプション：組み込み認証やAPI Managementを使ったOAuth対応
- ネットワーク分離：Azure Virtual Networks（VNET）によるネットワーク分離が可能
- サーバーレスアーキテクチャ：Azure Functionsを活用したスケーラブルでイベント駆動型の実行
- ローカル開発：充実したローカル開発とデバッグサポート
- 簡単なデプロイ：Azureへのスムーズなデプロイプロセス

リポジトリには、本番対応のMCPサーバー実装を素早く開始するためのすべての設定ファイル、ソースコード、インフラ定義が含まれています。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure FunctionsとPythonを使ったMCPのサンプル実装

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure FunctionsとC# .NETを使ったMCPのサンプル実装

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure FunctionsとNode/TypeScriptを使ったMCPのサンプル実装

## まとめ

- MCP SDKは言語別のツールを提供し、堅牢なMCPソリューションの実装を支援
- デバッグとテストは信頼性の高いMCPアプリケーションに不可欠
- 再利用可能なプロンプトテンプレートで一貫したAIインタラクションを実現
- よく設計されたワークフローは複数ツールを使った複雑なタスクをオーケストレーション
- MCP実装にはセキュリティ、パフォーマンス、エラーハンドリングの考慮が必要

## 演習

あなたのドメインの現実的な問題に対応する実践的なMCPワークフローを設計してください：

1. 問題解決に役立つ3〜4のツールを特定する
2. これらのツールがどのように連携するかを示すワークフローダイアグラムを作成する
3. 好みの言語でツールの基本バージョンを実装する
4. モデルがツールを効果的に使うためのプロンプトテンプレートを作成する

## 追加リソース


---

次へ：[高度なトピック](../05-AdvancedTopics/README.md)

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文はあくまで正式な情報源としてご利用ください。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。