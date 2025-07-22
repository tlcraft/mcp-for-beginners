<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "20064351f7e0fa904e96b057ed742df3",
  "translation_date": "2025-07-22T07:47:57+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ja"
}
-->
# 実践的な実装

実践的な実装は、Model Context Protocol (MCP) の力を実感できる場面です。MCP の理論やアーキテクチャを理解することも重要ですが、これらの概念を活用して現実の問題を解決するソリューションを構築、テスト、デプロイする際にその真価が発揮されます。この章では、概念的な知識と実践的な開発のギャップを埋め、MCP ベースのアプリケーションを実現するプロセスを案内します。

知能アシスタントの開発、AI のビジネスワークフローへの統合、データ処理用のカスタムツールの構築など、どのような用途であっても、MCP は柔軟な基盤を提供します。その言語非依存の設計と、主要なプログラミング言語向けの公式 SDK により、幅広い開発者が利用可能です。これらの SDK を活用することで、迅速にプロトタイプを作成し、反復し、さまざまなプラットフォームや環境でソリューションをスケールできます。

以下のセクションでは、C#、Java、TypeScript、JavaScript、Python を使用した MCP の実装方法を示す実践的な例、サンプルコード、デプロイ戦略を紹介します。また、MCP サーバーのデバッグやテスト、API 管理、Azure を使用したクラウドへのデプロイ方法についても学びます。これらの実践的なリソースは、学習を加速させ、堅牢で本番環境対応の MCP アプリケーションを自信を持って構築できるようにするためのものです。

## 概要

このレッスンでは、複数のプログラミング言語における MCP 実装の実践的な側面に焦点を当てます。C#、Java、TypeScript、JavaScript、Python の MCP SDK を使用して堅牢なアプリケーションを構築し、MCP サーバーをデバッグおよびテストし、再利用可能なリソース、プロンプト、ツールを作成する方法を探ります。

## 学習目標

このレッスンを終えるまでに、以下ができるようになります：

- さまざまなプログラミング言語で公式 SDK を使用して MCP ソリューションを実装する
- MCP サーバーを体系的にデバッグおよびテストする
- サーバー機能（リソース、プロンプト、ツール）を作成して使用する
- 複雑なタスクのための効果的な MCP ワークフローを設計する
- パフォーマンスと信頼性を最適化した MCP 実装を行う

## 公式 SDK リソース

Model Context Protocol は、複数の言語向けに公式 SDK を提供しています：

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK の活用

このセクションでは、複数のプログラミング言語で MCP を実装する実践的な例を紹介します。`samples` ディレクトリには、言語ごとに整理されたサンプルコードが含まれています。

### 利用可能なサンプル

リポジトリには、以下の言語での[サンプル実装](../../../04-PracticalImplementation/samples)が含まれています：

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

各サンプルでは、その特定の言語とエコシステムにおける主要な MCP 概念と実装パターンを示しています。

## コアサーバー機能

MCP サーバーは、以下の機能の任意の組み合わせを実装できます：

### リソース

リソースは、ユーザーや AI モデルが使用するためのコンテキストやデータを提供します：

- ドキュメントリポジトリ
- ナレッジベース
- 構造化データソース
- ファイルシステム

### プロンプト

プロンプトは、ユーザー向けのテンプレート化されたメッセージやワークフローです：

- 事前定義された会話テンプレート
- ガイド付きのインタラクションパターン
- 特化した対話構造

### ツール

ツールは、AI モデルが実行するための機能です：

- データ処理ユーティリティ
- 外部 API 統合
- 計算能力
- 検索機能

## サンプル実装：C# 実装

公式の C# SDK リポジトリには、MCP のさまざまな側面を示すいくつかのサンプル実装が含まれています：

- **基本的な MCP クライアント**：MCP クライアントを作成し、ツールを呼び出すシンプルな例
- **基本的な MCP サーバー**：基本的なツール登録を備えた最小限のサーバー実装
- **高度な MCP サーバー**：ツール登録、認証、エラーハンドリングを備えたフル機能のサーバー
- **ASP.NET 統合**：ASP.NET Core との統合を示す例
- **ツール実装パターン**：さまざまな複雑さのツールを実装するためのパターン

C# MCP SDK はプレビュー段階にあり、API は変更される可能性があります。SDK の進化に伴い、このブログも随時更新されます。

### 主な機能

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- [最初の MCP サーバーを構築する](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

完全な C# 実装サンプルについては、[公式 C# SDK サンプルリポジトリ](https://github.com/modelcontextprotocol/csharp-sdk)をご覧ください。

## サンプル実装：Java 実装

Java SDK は、エンタープライズグレードの機能を備えた堅牢な MCP 実装オプションを提供します。

### 主な機能

- Spring Framework との統合
- 強力な型安全性
- リアクティブプログラミングのサポート
- 包括的なエラーハンドリング

完全な Java 実装サンプルについては、`samples` ディレクトリ内の [Java サンプル](samples/java/containerapp/README.md) を参照してください。

## サンプル実装：JavaScript 実装

JavaScript SDK は、軽量で柔軟な MCP 実装アプローチを提供します。

### 主な機能

- Node.js とブラウザのサポート
- Promise ベースの API
- Express やその他のフレームワークとの簡単な統合
- ストリーミング用の WebSocket サポート

完全な JavaScript 実装サンプルについては、`samples` ディレクトリ内の [JavaScript サンプル](samples/javascript/README.md) を参照してください。

## サンプル実装：Python 実装

Python SDK は、優れた機械学習フレームワーク統合を備えた Python 的な MCP 実装を提供します。

### 主な機能

- asyncio を使用した非同期/await サポート
- FastAPI との統合
- シンプルなツール登録
- 人気のある機械学習ライブラリとのネイティブ統合

完全な Python 実装サンプルについては、`samples` ディレクトリ内の [Python サンプル](samples/python/README.md) を参照してください。

## API 管理

Azure API Management は、MCP サーバーを保護するための優れたソリューションです。Azure API Management インスタンスを MCP サーバーの前に配置し、以下のような機能を処理させることができます：

- レート制限
- トークン管理
- モニタリング
- 負荷分散
- セキュリティ

### Azure サンプル

以下の Azure サンプルでは、MCP サーバーを作成し、Azure API Management を使用して保護する方法を示しています：[Azure API Management を使用した MCP サーバーの保護](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

以下の画像で認証フローを確認できます：

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

上記の画像では、以下が行われます：

- Microsoft Entra を使用した認証/認可
- Azure API Management がゲートウェイとして機能し、ポリシーを使用してトラフィックを管理
- Azure Monitor がすべてのリクエストをログに記録してさらなる分析を可能に

#### 認証フロー

以下の図で認証フローを詳しく見てみましょう：

![シーケンス図](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP 認証仕様

[MCP 認証仕様](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)について詳しく学ぶ

## Azure へのリモート MCP サーバーのデプロイ

前述のサンプルをデプロイしてみましょう：

1. リポジトリをクローン

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App` リソースプロバイダーを登録

   - Azure CLI を使用している場合、`az provider register --namespace Microsoft.App --wait` を実行
   - Azure PowerShell を使用している場合、`Register-AzResourceProvider -ProviderNamespace Microsoft.App` を実行。その後、`(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` を実行して登録が完了したか確認

1. この [azd](https://aka.ms/azd) コマンドを実行して、API 管理サービス、関数アプリ（コード付き）、およびその他の必要な Azure リソースをプロビジョニング

    ```shell
    azd up
    ```

    このコマンドは、Azure 上のすべてのクラウドリソースをデプロイします

### MCP Inspector を使用したサーバーのテスト

1. **新しいターミナルウィンドウ**で MCP Inspector をインストールして実行

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    以下のようなインターフェースが表示されるはずです：

    ![Node Inspector に接続](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ja.png)

1. 表示された URL（例：[http://127.0.0.1:6274/#resources](http://127.0.0.1:6274/#resources)）を CTRL クリックして MCP Inspector Web アプリをロード
1. トランスポートタイプを `SSE` に設定
1. `azd up` 実行後に表示された API Management SSE エンドポイントの URL を設定し、**接続**：

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

1. **ツール一覧**を表示。ツールをクリックして **ツールを実行**。

すべての手順が正常に完了した場合、MCP サーバーに接続され、ツールを呼び出すことができるはずです。

## Azure 用 MCP サーバー

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)：このリポジトリセットは、Azure Functions を使用してカスタムリモート MCP（Model Context Protocol）サーバーを構築およびデプロイするためのクイックスタートテンプレートです。

このサンプルは、開発者が以下を行える完全なソリューションを提供します：

- ローカルでの構築と実行：ローカルマシンで MCP サーバーを開発およびデバッグ
- Azure へのデプロイ：シンプルな `azd up` コマンドでクラウドに簡単にデプロイ
- クライアントからの接続：VS Code の Copilot エージェントモードや MCP Inspector ツールを含むさまざまなクライアントから MCP サーバーに接続

### 主な機能

- 設計時のセキュリティ：MCP サーバーはキーと HTTPS を使用して保護
- 認証オプション：組み込み認証および/または API 管理を使用した OAuth をサポート
- ネットワーク分離：Azure Virtual Networks (VNET) を使用したネットワーク分離を許可
- サーバーレスアーキテクチャ：スケーラブルでイベント駆動型の実行を可能にする Azure Functions を活用
- ローカル開発：包括的なローカル開発およびデバッグサポート
- シンプルなデプロイ：Azure へのスムーズなデプロイプロセス

リポジトリには、すぐに使用可能な MCP サーバー実装のための必要な設定ファイル、ソースコード、およびインフラストラクチャ定義がすべて含まれています。

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python を使用した MCP のサンプル実装
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET を使用した MCP のサンプル実装
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript を使用した MCP のサンプル実装

## 重要なポイント

- MCP SDK は、堅牢な MCP ソリューションを実装するための言語固有のツールを提供
- デバッグとテストプロセスは、信頼性の高い MCP アプリケーションにとって重要
- 再利用可能なプロンプトテンプレートは、一貫した AI インタラクションを可能に
- よく設計されたワークフローは、複数のツールを使用した複雑なタスクを調整可能
- MCP ソリューションの実装には、セキュリティ、パフォーマンス、エラーハンドリングの考慮が必要

## 演習

自分の分野での現実的な問題を解決するための実践的な MCP ワークフローを設計してください：

1. この問題を解決するのに役立つツールを 3～4 つ特定する
2. これらのツールがどのように相互作用するかを示すワークフローダイアグラムを作成する
3. 好きな言語を使用してツールの基本バージョンを 1 つ実装する
4. モデルがツールを効果的に使用できるようにするプロンプトテンプレートを作成する

## 追加リソース

---

次へ：[高度なトピック](../05-AdvancedTopics/README.md)

**免責事項**:  
この文書は、AI翻訳サービス [Co-op Translator](https://github.com/Azure/co-op-translator) を使用して翻訳されています。正確性を追求しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。元の言語で記載された文書が正式な情報源と見なされるべきです。重要な情報については、専門の人間による翻訳を推奨します。この翻訳の利用に起因する誤解や誤訳について、当社は一切の責任を負いません。