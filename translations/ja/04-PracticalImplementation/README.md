<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:47:34+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ja"
}
-->
# 実践的な実装

実践的な実装は、Model Context Protocol（MCP）の力が具体的に感じられる部分です。MCPの理論やアーキテクチャを理解することは重要ですが、実際にこれらの概念を活用して現実の問題を解決するソリューションを構築、テスト、展開することで真の価値が生まれます。本章では、概念的な知識と実践的な開発のギャップを埋め、MCPベースのアプリケーションを実際に動かすプロセスを案内します。

インテリジェントアシスタントの開発、ビジネスワークフローへのAI統合、データ処理のためのカスタムツール構築など、MCPは柔軟な基盤を提供します。言語に依存しない設計と主要なプログラミング言語向けの公式SDKにより、多くの開発者が利用可能です。これらのSDKを活用することで、迅速にプロトタイプを作成し、反復し、異なるプラットフォームや環境でスケールさせることができます。

以下のセクションでは、C#、Java、TypeScript、JavaScript、PythonでのMCP実装例、サンプルコード、展開戦略を紹介します。また、MCPサーバーのデバッグやテスト、API管理、Azureを使ったクラウド展開方法も学べます。これらの実践的なリソースは、学習を加速し、堅牢で本番環境対応のMCPアプリケーションを自信を持って構築できるよう設計されています。

## 概要

このレッスンでは、複数のプログラミング言語にわたるMCP実装の実践的な側面に焦点を当てます。C#、Java、TypeScript、JavaScript、PythonのMCP SDKを使って堅牢なアプリケーションを構築し、MCPサーバーのデバッグやテスト、再利用可能なリソース、プロンプト、ツールの作成方法を探ります。

## 学習目標

このレッスンの終了時には、以下ができるようになります：
- 公式SDKを使って様々なプログラミング言語でMCPソリューションを実装する
- MCPサーバーを体系的にデバッグおよびテストする
- サーバー機能（Resources、Prompts、Tools）を作成・活用する
- 複雑なタスクのための効果的なMCPワークフローを設計する
- パフォーマンスと信頼性を考慮したMCP実装を最適化する

## 公式SDKリソース

Model Context Protocolは複数の言語向けに公式SDKを提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKの活用

このセクションでは、複数のプログラミング言語でのMCP実装の実践例を紹介します。`samples`ディレクトリに言語別に整理されたサンプルコードがあります。

### 利用可能なサンプル

リポジトリには以下の言語での[サンプル実装](../../../04-PracticalImplementation/samples)が含まれています：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

各サンプルは、その言語とエコシステムにおける主要なMCPの概念と実装パターンを示しています。

## コアサーバー機能

MCPサーバーは以下の機能を組み合わせて実装できます：

### Resources
ResourcesはユーザーやAIモデルが利用するコンテキストやデータを提供します：
- ドキュメントリポジトリ
- ナレッジベース
- 構造化データソース
- ファイルシステム

### Prompts
Promptsはユーザー向けのテンプレート化されたメッセージやワークフローです：
- 事前定義された会話テンプレート
- ガイド付きインタラクションパターン
- 専門的な対話構造

### Tools
ToolsはAIモデルが実行する関数です：
- データ処理ユーティリティ
- 外部API連携
- 計算機能
- 検索機能

## サンプル実装：C#

公式のC# SDKリポジトリには、MCPの様々な側面を示す複数のサンプル実装が含まれています：

- **Basic MCP Client**：MCPクライアントの作成とツール呼び出しの簡単な例
- **Basic MCP Server**：基本的なツール登録を備えた最小限のサーバー実装
- **Advanced MCP Server**：ツール登録、認証、エラーハンドリングを備えたフル機能サーバー
- **ASP.NET Integration**：ASP.NET Coreとの統合例
- **Tool Implementation Patterns**：異なる複雑さのツール実装パターン

C# MCP SDKはプレビュー段階であり、APIは変更される可能性があります。SDKの進化に合わせてこのブログも継続的に更新します。

### 主な機能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [最初のMCPサーバー構築](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

C#の完全な実装サンプルは[公式C# SDKサンプルリポジトリ](https://github.com/modelcontextprotocol/csharp-sdk)をご覧ください。

## サンプル実装：Java実装

Java SDKはエンタープライズグレードの機能を備えた堅牢なMCP実装オプションを提供します。

### 主な機能

- Spring Frameworkとの統合
- 強力な型安全性
- リアクティブプログラミング対応
- 包括的なエラーハンドリング

完全なJava実装サンプルは、samplesディレクトリの[Javaサンプル](samples/java/containerapp/README.md)をご覧ください。

## サンプル実装：JavaScript実装

JavaScript SDKは軽量で柔軟なMCP実装アプローチを提供します。

### 主な機能

- Node.jsおよびブラウザ対応
- PromiseベースのAPI
- Expressなどのフレームワークとの簡単な統合
- ストリーミング対応のWebSocketサポート

完全なJavaScript実装サンプルは、samplesディレクトリの[JavaScriptサンプル](samples/javascript/README.md)をご覧ください。

## サンプル実装：Python実装

Python SDKはPythonらしいアプローチでMCP実装を提供し、優れたMLフレームワーク統合を備えています。

### 主な機能

- asyncioによるasync/awaitサポート
- FlaskおよびFastAPIとの統合
- シンプルなツール登録
- 人気のMLライブラリとのネイティブ統合

完全なPython実装サンプルは、samplesディレクトリの[Pythonサンプル](samples/python/README.md)をご覧ください。

## API管理

Azure API ManagementはMCPサーバーを安全に保つための優れたソリューションです。MCPサーバーの前にAzure API Managementインスタンスを配置し、以下のような機能を任せることができます：

- レート制限
- トークン管理
- モニタリング
- ロードバランシング
- セキュリティ

### Azureサンプル

以下はまさにそれを行うAzureサンプルです。すなわち、MCPサーバーを作成しAzure API Managementで保護する例です。

[Azureサンプルリポジトリ](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

以下の画像で認証フローの様子を確認できます：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

上記画像では以下のことが行われています：

- Microsoft Entraを使った認証/認可が行われる
- Azure API Managementがゲートウェイとして機能し、ポリシーでトラフィックを制御・管理
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

1. `Microsoft.App`リソースプロバイダーを登録
    * Azure CLIを使う場合は、`az provider register --namespace Microsoft.App --wait`を実行
    * Azure PowerShellを使う場合は、`Register-AzResourceProvider -ProviderNamespace Microsoft.App`を実行し、しばらくしてから`(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`で登録状態を確認

2. 次の[azd](https://aka.ms/azd)コマンドを実行し、API Managementサービス、Function App（コード付き）、その他必要なAzureリソースをプロビジョニング

    ```shell
    azd up
    ```

    このコマンドでAzure上にすべてのクラウドリソースが展開されます。

### MCP Inspectorでサーバーをテスト

1. **新しいターミナルウィンドウ**でMCP Inspectorをインストールして起動

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    以下のようなインターフェースが表示されるはずです：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. アプリが表示するURL（例：http://127.0.0.1:6274/#resources）をCTRLクリックしてMCP InspectorのWebアプリを読み込む
1. トランスポートタイプを`SSE`に設定
1. `azd up`実行後に表示されるAPI ManagementのSSEエンドポイントURLを設定し、**Connect**をクリック：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**でツールをクリックし、**Run Tool**を実行

すべての手順が成功すれば、MCPサーバーに接続され、ツールを呼び出せるようになっています。

## Azure向けMCPサーバー

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：このリポジトリ群は、Python、C# .NET、Node/TypeScriptを使ったAzure Functions上でのカスタムリモートMCPサーバー構築・展開のクイックスタートテンプレートです。

このサンプルは開発者に以下を提供します：

- ローカルでの構築と実行：ローカルマシンでMCPサーバーを開発・デバッグ
- Azureへのデプロイ：シンプルなazd upコマンドでクラウドに展開
- クライアントからの接続：VS CodeのCopilotエージェントモードやMCP Inspectorツールなど様々なクライアントから接続可能

### 主な特徴：

- セキュリティ設計：キーとHTTPSでMCPサーバーを保護
- 認証オプション：組み込み認証やAPI Managementを使ったOAuth対応
- ネットワーク分離：Azure Virtual Networks（VNET）によるネットワーク分離が可能
- サーバーレスアーキテクチャ：Azure Functionsを活用したスケーラブルでイベント駆動の実行
- ローカル開発：充実したローカル開発・デバッグサポート
- 簡単なデプロイ：Azureへの展開プロセスを簡素化

リポジトリには、本番環境対応のMCPサーバー実装を迅速に始めるための設定ファイル、ソースコード、インフラ定義がすべて含まれています。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - PythonでAzure Functionsを使ったMCPのサンプル実装

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NETでAzure Functionsを使ったMCPのサンプル実装

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScriptでAzure Functionsを使ったMCPのサンプル実装

## まとめ

- MCP SDKは言語別のツールを提供し、堅牢なMCPソリューションの実装を支援
- デバッグとテストは信頼性の高いMCPアプリケーションに不可欠
- 再利用可能なプロンプトテンプレートで一貫したAIインタラクションを実現
- よく設計されたワークフローは複数のツールを使った複雑なタスクを調整可能
- MCPソリューションの実装にはセキュリティ、パフォーマンス、エラーハンドリングの考慮が必要

## 演習

あなたの分野の現実的な問題を解決する実践的なMCPワークフローを設計してください：

1. 問題解決に役立つ3～4つのツールを特定する
2. これらのツールがどのように連携するかを示すワークフローダイアグラムを作成する
3. 好みの言語でツールの基本的なバージョンを実装する
4. モデルが効果的にツールを使えるようにするプロンプトテンプレートを作成する

## 追加リソース


---

次へ：[高度なトピック](../05-AdvancedTopics/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。