<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-16T15:34:06+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ja"
}
-->
# 実践的な実装

実践的な実装は、Model Context Protocol（MCP）の力が具体的に実感できる場です。MCPの理論やアーキテクチャを理解することは重要ですが、実際にこれらの概念を使って現実の問題を解決するソリューションを構築、テスト、展開することで真の価値が生まれます。本章では、概念的な知識と実践的な開発のギャップを埋め、MCPベースのアプリケーションを形にするプロセスを案内します。

インテリジェントアシスタントの開発、ビジネスワークフローへのAI統合、データ処理のためのカスタムツール構築など、MCPは柔軟な基盤を提供します。言語に依存しない設計と主要なプログラミング言語向けの公式SDKにより、多様な開発者に利用可能です。これらのSDKを活用することで、さまざまなプラットフォームや環境で迅速にプロトタイプを作成し、反復し、スケールさせることができます。

以下のセクションでは、C#、Java、TypeScript、JavaScript、PythonでのMCP実装例、サンプルコード、展開戦略を紹介します。また、MCPサーバーのデバッグやテスト、API管理、Azureを使ったクラウド展開方法についても学べます。これらの実践的なリソースは学習を加速し、堅牢で本番対応可能なMCPアプリケーションの構築に自信を持って取り組めるよう設計されています。

## 概要

このレッスンでは、複数のプログラミング言語にわたるMCPの実践的な実装に焦点を当てます。C#、Java、TypeScript、JavaScript、PythonのMCP SDKを使って堅牢なアプリケーションを構築し、MCPサーバーのデバッグとテスト、再利用可能なリソース、プロンプト、ツールの作成方法を探ります。

## 学習目標

このレッスンの終了時には、以下ができるようになります：
- 公式SDKを使って様々なプログラミング言語でMCPソリューションを実装する
- MCPサーバーを体系的にデバッグ・テストする
- サーバー機能（リソース、プロンプト、ツール）を作成・活用する
- 複雑なタスク向けに効果的なMCPワークフローを設計する
- パフォーマンスと信頼性を考慮したMCP実装を最適化する

## 公式SDKリソース

Model Context Protocolは複数の言語向けに公式SDKを提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKの活用

このセクションでは、複数言語でのMCP実装の実践例を紹介します。サンプルコードは`samples`ディレクトリ内に言語別に整理されています。

### 利用可能なサンプル

リポジトリには以下の言語でのサンプル実装が含まれています：

- C#
- Java
- TypeScript
- JavaScript
- Python

各サンプルは、その言語とエコシステムに特化したMCPの主要な概念と実装パターンを示しています。

## コアサーバー機能

MCPサーバーは以下の機能を組み合わせて実装できます：

### リソース
リソースはユーザーやAIモデルが利用するコンテキストやデータを提供します：
- ドキュメントリポジトリ
- ナレッジベース
- 構造化データソース
- ファイルシステム

### プロンプト
プロンプトはユーザー向けのテンプレート化されたメッセージやワークフローです：
- 事前定義された会話テンプレート
- ガイド付きのインタラクションパターン
- 専門的な対話構造

### ツール
ツールはAIモデルが実行する関数です：
- データ処理ユーティリティ
- 外部API連携
- 計算機能
- 検索機能

## サンプル実装：C#

公式のC# SDKリポジトリには、MCPのさまざまな側面を示す複数のサンプル実装があります：

- **基本的なMCPクライアント**：MCPクライアントの作成とツール呼び出しの簡単な例
- **基本的なMCPサーバー**：基本的なツール登録を備えた最小限のサーバー実装
- **高度なMCPサーバー**：ツール登録、認証、エラーハンドリングを備えたフル機能のサーバー
- **ASP.NET統合**：ASP.NET Coreとの統合例
- **ツール実装パターン**：複雑さの異なるツール実装の様々なパターン

C# MCP SDKはプレビュー段階であり、APIは変更される可能性があります。SDKの進化に合わせてこのブログも随時更新します。

### 主要機能
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [最初のMCPサーバーの構築](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

完全なC#実装サンプルは[公式C# SDKサンプルリポジトリ](https://github.com/modelcontextprotocol/csharp-sdk)をご覧ください。

## サンプル実装：Java

Java SDKはエンタープライズグレードの機能を備えた堅牢なMCP実装オプションを提供します。

### 主要機能

- Spring Frameworkとの統合
- 強力な型安全性
- リアクティブプログラミング対応
- 包括的なエラーハンドリング

完全なJava実装サンプルは、samplesディレクトリ内の[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)をご覧ください。

## サンプル実装：JavaScript

JavaScript SDKは軽量で柔軟なMCP実装を提供します。

### 主要機能

- Node.jsおよびブラウザ対応
- PromiseベースのAPI
- Expressなどのフレームワークとの簡単な統合
- ストリーミング用WebSocket対応

完全なJavaScript実装サンプルは、samplesディレクトリ内の[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)をご覧ください。

## サンプル実装：Python

Python SDKはPythonらしいMCP実装を提供し、優れたMLフレームワークとの統合が特徴です。

### 主要機能

- asyncioによるAsync/await対応
- FlaskおよびFastAPIとの統合
- シンプルなツール登録
- 人気のMLライブラリとのネイティブ統合

完全なPython実装サンプルは、samplesディレクトリ内の[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)をご覧ください。

## API管理

Azure API ManagementはMCPサーバーを安全に運用するための優れた手段です。MCPサーバーの前にAzure API Managementインスタンスを配置し、以下のような機能を担わせるアイデアです：

- レート制限
- トークン管理
- 監視
- ロードバランシング
- セキュリティ

### Azureサンプル

以下はまさにそれを実現するAzureサンプルです。すなわち、[MCPサーバーを作成しAzure API Managementで保護する](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)。

以下の画像で認証フローを確認できます：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

上記の画像で起きていること：

- Microsoft Entraを使った認証／認可が行われる
- Azure API Managementがゲートウェイとして機能し、ポリシーでトラフィックを制御・管理
- Azure Monitorがすべてのリクエストをログに記録し、分析に活用

#### 認可フロー

認可フローをもう少し詳しく見てみましょう：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP認可仕様

[MCP認可仕様](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)の詳細もご覧ください。

## AzureへのリモートMCPサーバーのデプロイ

先に紹介したサンプルをデプロイしてみましょう：

1. リポジトリをクローン

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App`プロバイダーを登録し、登録完了を確認

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. 次の[azd](https://aka.ms/azd)コマンドでAPI管理サービス、Function App（コード含む）、その他必要なAzureリソースをプロビジョニング

    ```shell
    azd up
    ```

    これによりAzure上のクラウドリソースがすべてデプロイされます。

### MCP Inspectorでサーバーをテスト

1. **新しいターミナルウィンドウ**でMCP Inspectorをインストールし実行

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    以下のようなインターフェースが表示されます：

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.ja.png)

2. 表示されたURL（例：http://127.0.0.1:6274/#resources）をCTRLクリックしてMCP InspectorのWebアプリを読み込む
3. トランスポートタイプを`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`に設定し、**Connect**をクリック

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**をクリックし、ツールを選択して**Run Tool**を実行

すべての手順が成功すれば、MCPサーバーに接続され、ツール呼び出しができているはずです。

## Azure向けMCPサーバー

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)は、Python、C# .NET、Node/TypeScriptを使ってAzure Functions上にカスタムリモートMCPサーバーを構築・展開するためのクイックスタートテンプレートです。

このサンプルは開発者に以下の完全なソリューションを提供します：

- ローカルでの構築・実行：ローカルマシン上でMCPサーバーを開発・デバッグ
- Azureへの展開：シンプルなazd upコマンドでクラウドへ簡単に展開
- クライアントからの接続：VS CodeのCopilotエージェントモードやMCP Inspectorツールなど、多様なクライアントからMCPサーバーに接続可能

### 主要機能

- セキュリティ設計：MCPサーバーはキーとHTTPSで保護
- 認証オプション：組み込み認証やAPI管理を使ったOAuth対応
- ネットワーク分離：Azure Virtual Networks（VNET）を利用可能
- サーバーレスアーキテクチャ：Azure Functionsによるスケーラブルでイベント駆動型の実行
- ローカル開発：包括的なローカル開発とデバッグサポート
- 簡単な展開：Azureへのスムーズな展開プロセス

このリポジトリには、本番対応可能なMCPサーバー実装を迅速に開始するための設定ファイル、ソースコード、インフラ定義がすべて含まれています。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Pythonを使ったAzure Functions上のMCP実装サンプル
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NETを使ったAzure Functions上のMCP実装サンプル
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScriptを使ったAzure Functions上のMCP実装サンプル

## 重要ポイント

- MCP SDKは言語別に堅牢なMCPソリューションを実装するためのツールを提供
- デバッグとテストは信頼性の高いMCPアプリケーションに不可欠
- 再利用可能なプロンプトテンプレートにより一貫したAIインタラクションが可能
- 良く設計されたワークフローは複数のツールを使った複雑なタスクをオーケストレーションできる
- MCP実装にはセキュリティ、パフォーマンス、エラーハンドリングの考慮が必要

## 演習

自分の分野の現実的な問題を解決する実践的なMCPワークフローを設計してみましょう：

1. 問題解決に役立つ3〜4つのツールを特定する
2. これらのツールがどのように連携するかを示すワークフローダイアグラムを作成する
3. 好みの言語でツールの基本的なバージョンを実装する
4. モデルが効果的にツールを使えるようにするプロンプトテンプレートを作成する

## 追加リソース


---

次へ：[高度なトピック](../05-AdvancedTopics/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。