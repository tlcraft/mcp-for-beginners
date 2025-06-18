<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:47:17+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ja"
}
-->
# 実践的な実装

実践的な実装は、Model Context Protocol（MCP）の力が具体的に感じられる場面です。MCPの理論やアーキテクチャを理解することは重要ですが、実際にこれらの概念を活用して現実の問題を解決するソリューションを構築、テスト、展開することで、本当の価値が生まれます。本章では、概念的な知識と実践的な開発のギャップを埋め、MCPベースのアプリケーションを実現するプロセスを案内します。

インテリジェントアシスタントの開発、ビジネスワークフローへのAI統合、データ処理のためのカスタムツール構築など、MCPは柔軟な基盤を提供します。言語に依存しない設計と主要プログラミング言語向けの公式SDKにより、多くの開発者が利用可能です。これらのSDKを活用することで、迅速にプロトタイプを作成し、反復開発を行い、異なるプラットフォームや環境でスケールさせることができます。

以下のセクションでは、C#、Java、TypeScript、JavaScript、PythonでのMCP実装例、サンプルコード、展開戦略を紹介します。また、MCPサーバーのデバッグやテスト、API管理、Azureを使ったクラウド展開方法についても学びます。これらの実践的なリソースは、学習を加速し、堅牢で本番対応可能なMCPアプリケーションを自信を持って構築できるよう設計されています。

## 概要

このレッスンでは、複数のプログラミング言語におけるMCP実装の実践的な側面に焦点を当てます。C#、Java、TypeScript、JavaScript、PythonのMCP SDKを使って堅牢なアプリケーションを構築し、MCPサーバーのデバッグやテスト、再利用可能なリソース、プロンプト、ツールの作成方法を探ります。

## 学習目標

このレッスンの終了時には、以下ができるようになります：
- 公式SDKを使って様々なプログラミング言語でMCPソリューションを実装する
- MCPサーバーを体系的にデバッグおよびテストする
- サーバー機能（リソース、プロンプト、ツール）を作成・活用する
- 複雑なタスクのための効果的なMCPワークフローを設計する
- パフォーマンスと信頼性を考慮したMCP実装を最適化する

## 公式SDKリソース

Model Context Protocolは複数言語向けの公式SDKを提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKの活用

このセクションでは、複数のプログラミング言語でのMCP実装の実践例を紹介します。サンプルコードは`samples`ディレクトリに言語別に整理されています。

### 利用可能なサンプル

リポジトリには以下の言語での[サンプル実装](../../../04-PracticalImplementation/samples)が含まれています：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

各サンプルは、その言語およびエコシステムにおける主要なMCPの概念と実装パターンを示しています。

## コアサーバー機能

MCPサーバーは以下の機能を組み合わせて実装可能です：

### リソース
リソースはユーザーやAIモデルが利用するコンテキストやデータを提供します：
- ドキュメントリポジトリ
- ナレッジベース
- 構造化データソース
- ファイルシステム

### プロンプト
プロンプトはユーザー向けのテンプレート化されたメッセージやワークフローです：
- 事前定義された会話テンプレート
- ガイド付きインタラクションパターン
- 専門的な対話構造

### ツール
ツールはAIモデルが実行する関数です：
- データ処理ユーティリティ
- 外部API統合
- 計算機能
- 検索機能

## サンプル実装：C#

公式C# SDKリポジトリには、MCPの様々な側面を示す複数のサンプル実装が含まれています：

- **基本的なMCPクライアント**：MCPクライアントの作成とツール呼び出しの簡単な例
- **基本的なMCPサーバー**：基本的なツール登録を備えた最小限のサーバー実装
- **高度なMCPサーバー**：ツール登録、認証、エラーハンドリングを備えたフル機能のサーバー
- **ASP.NET統合**：ASP.NET Coreとの統合例
- **ツール実装パターン**：異なる複雑さのツール実装パターン

MCP C# SDKはプレビュー段階であり、APIが変更される可能性があります。SDKの進化に伴い、このブログも継続的に更新していきます。

### 主な特徴
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [最初のMCPサーバーの構築](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

C#の完全な実装サンプルは、[公式C# SDKサンプルリポジトリ](https://github.com/modelcontextprotocol/csharp-sdk)を参照してください。

## サンプル実装：Java実装

Java SDKはエンタープライズグレードの機能を備えた堅牢なMCP実装オプションを提供します。

### 主な特徴

- Spring Frameworkとの統合
- 強力な型安全性
- リアクティブプログラミングのサポート
- 包括的なエラーハンドリング

完全なJava実装サンプルは、サンプルディレクトリの[MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)を参照してください。

## サンプル実装：JavaScript実装

JavaScript SDKは軽量で柔軟なMCP実装アプローチを提供します。

### 主な特徴

- Node.jsおよびブラウザ対応
- PromiseベースのAPI
- Expressなどのフレームワークとの簡単な統合
- ストリーミング用WebSocketサポート

完全なJavaScript実装サンプルは、サンプルディレクトリの[mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)を参照してください。

## サンプル実装：Python実装

Python SDKはPythonらしいアプローチでMCP実装を提供し、優れたMLフレームワーク統合を備えています。

### 主な特徴

- asyncioを用いたasync/awaitサポート
- FlaskおよびFastAPIとの統合
- シンプルなツール登録
- 人気のMLライブラリとのネイティブ統合

完全なPython実装サンプルは、サンプルディレクトリの[mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)を参照してください。

## API管理

Azure API ManagementはMCPサーバーを安全に運用するための優れた手段です。アイデアとしては、Azure API ManagementインスタンスをMCPサーバーの前に置き、以下のような機能を処理させます：

- レート制限
- トークン管理
- 監視
- ロードバランシング
- セキュリティ

### Azureサンプル

以下のAzureサンプルは、まさにこれを実現しています。つまり、MCPサーバーを作成し、Azure API Managementで保護する例です。

認可フローは以下の画像のように行われます：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

この画像では、以下の処理が行われています：

- Microsoft Entraを使用した認証／認可が実施されます。
- Azure API Managementはゲートウェイとして機能し、ポリシーを使ってトラフィックを制御・管理します。
- Azure Monitorがすべてのリクエストをログに記録し、分析に備えます。

#### 認可フロー

認可フローの詳細を見てみましょう：

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP認可仕様

[MCP認可仕様](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)について詳しく学べます。

## AzureへのリモートMCPサーバーのデプロイ

先ほど紹介したサンプルをデプロイしてみましょう：

1. リポジトリをクローンします

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App`プロバイダーを登録します

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

    登録完了までしばらく待ちます。

3. 次の[azd](https://aka.ms/azd)コマンドを実行し、API Managementサービス、Function App（コード付き）、その他必要なAzureリソースをプロビジョニングします。

    ```shell
    azd up
    ```

    このコマンドでAzure上にすべてのクラウドリソースがデプロイされます。

### MCP Inspectorを使ったサーバーテスト

1. **新しいターミナルウィンドウ**でMCP Inspectorをインストールし、起動します。

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    以下のようなインターフェースが表示されます：

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png) 

2. アプリが表示するURL（例：http://127.0.0.1:6274/#resources）をCTRLクリックしてMCP InspectorのWebアプリを開きます。
3. トランスポートタイプを`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`に設定し、**接続**します：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **ツール一覧**を表示し、ツールをクリックして**ツールを実行**します。

すべての手順が成功すれば、MCPサーバーに接続され、ツールを呼び出すことができています。

## Azure向けMCPサーバー

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：このリポジトリセットは、Python、C# .NET、Node/TypeScriptを使ったAzure Functions上でのカスタムリモートMCPサーバー構築・展開のクイックスタートテンプレートです。

このサンプルは開発者に以下を提供します：

- ローカルでのビルドと実行：ローカル環境でMCPサーバーを開発・デバッグ
- Azureへのデプロイ：シンプルなazd upコマンドでクラウドに容易に展開
- クライアントからの接続：VS CodeのCopilotエージェントモードやMCP Inspectorツールなど多様なクライアントからの接続

### 主な特徴：

- セキュリティ設計：MCPサーバーはキーとHTTPSで保護
- 認証オプション：組み込み認証および/またはAPI Managementを使ったOAuth対応
- ネットワーク分離：Azure Virtual Networks (VNET)によるネットワーク分離が可能
- サーバーレスアーキテクチャ：スケーラブルなイベント駆動実行をAzure Functionsで実現
- ローカル開発：充実したローカル開発およびデバッグサポート
- シンプルなデプロイ：Azureへの展開プロセスを簡素化

このリポジトリには、本番対応可能なMCPサーバー実装を素早く始められるよう、必要な設定ファイル、ソースコード、インフラ定義がすべて含まれています。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - PythonでAzure Functionsを使ったMCP実装サンプル
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NETでAzure Functionsを使ったMCP実装サンプル
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScriptでAzure Functionsを使ったMCP実装サンプル

## まとめ

- MCP SDKは言語別に堅牢なMCPソリューションを実装するためのツールを提供
- デバッグとテストは信頼性の高いMCPアプリケーションに不可欠
- 再利用可能なプロンプトテンプレートは一貫したAIインタラクションを可能にする
- よく設計されたワークフローは複数ツールを使った複雑なタスクを調整できる
- MCPソリューションの実装にはセキュリティ、パフォーマンス、エラーハンドリングの考慮が必要

## 演習

実際の業務ドメインでの課題に対応する実践的なMCPワークフローを設計してください：

1. 問題解決に役立つ3～4のツールを特定する
2. それらのツールがどのように連携するかを示すワークフローダイアグラムを作成する
3. 好みの言語でツールの基本的なバージョンを実装する
4. モデルが効果的にツールを使えるようにするプロンプトテンプレートを作成する

## 追加リソース


---

次へ：[高度なトピック](../05-AdvancedTopics/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の言語によるオリジナル文書が権威ある情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。