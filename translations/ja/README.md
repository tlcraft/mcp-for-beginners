<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:24:03+00:00",
  "source_file": "README.md",
  "language_code": "ja"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.ja.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


これらのリソースを使い始めるには、以下の手順に従ってください：
1. **リポジトリをフォークする**: クリック [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **リポジトリをクローンする**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Azure AI Foundry Discordに参加して、専門家や他の開発者と交流しよう**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 多言語サポート

#### GitHub Actionを利用して対応（自動化＆常に最新）

# 🚀 初心者向け Model Context Protocol (MCP) カリキュラム

## **C#, Java, JavaScript, Python, TypeScript の実践コード例で学ぶ MCP**

## 🧠 Model Context Protocol カリキュラムの概要

**Model Context Protocol (MCP)** は、AIモデルとクライアントアプリケーション間のやり取りを標準化するために設計された最先端のフレームワークです。このオープンソースのカリキュラムは、C#, Java, JavaScript, TypeScript, Python といった人気のプログラミング言語での実践的なコード例や実際のユースケースを通じて、体系的に学べる学習パスを提供します。

AI開発者、システムアーキテクト、ソフトウェアエンジニアのいずれであっても、このガイドはMCPの基本から実装戦略までを習得するための総合的なリソースとなります。

## 🔗 公式 MCP リソース

- 📘 [MCP ドキュメント](https://modelcontextprotocol.io/) – 詳細なチュートリアルとユーザーガイド  
- 📜 [MCP 仕様書](https://spec.modelcontextprotocol.io/) – プロトコルの構造と技術的リファレンス  
- 🧑‍💻 [MCP GitHub リポジトリ](https://github.com/modelcontextprotocol) – オープンソースのSDK、ツール、コードサンプル  

## 🧭 MCP カリキュラム全体構成

| Ch | タイトル | 説明 | リンク |
|--|--|--|--|
| 00 | **MCP入門** | Model Context Protocolの概要とAIパイプラインにおける重要性、MCPとは何か、標準化がなぜ重要か、実用例と利点について解説 | [Introduction](./00-Introduction/README.md) |
| 01 | **コアコンセプトの解説** | MCPのコアコンセプトを深く掘り下げ、クライアント・サーバーアーキテクチャ、主要なプロトコルコンポーネント、メッセージングパターンを説明 | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **MCPにおけるセキュリティ** | MCPベースのシステムにおけるセキュリティ脅威の特定、実装を安全にするための技術とベストプラクティス | [Security](/02-Security/README.md) |
| 03 | **MCPのはじめ方** | 環境のセットアップと設定、基本的なMCPサーバーとクライアントの作成、既存アプリケーションとの統合方法 | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **最初のサーバー** | MCPプロトコルを使った基本的なサーバーの構築、サーバーとクライアントのやり取りの理解、サーバーのテスト | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **最初のクライアント** | MCPプロトコルを使った基本的なクライアントの構築、クライアントとサーバーのやり取りの理解、クライアントのテスト | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLMを使ったクライアント** | MCPプロトコルを使い、大規模言語モデル(LLM)を組み込んだクライアントの構築 | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Codeでサーバーを利用する** | Visual Studio Codeを使ってMCPプロトコルのサーバーを利用する設定方法 | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSEを使ったサーバー作成** | SSEを使ってインターネットにサーバーを公開する方法。このセクションでSSEを用いたサーバー作成を学びます | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTPストリーミング** | クライアントとMCPサーバー間でリアルタイムデータ転送を実現するHTTPストリーミングの実装方法 | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AIツールキットの利用** | AIツールキットはAIとMCPのワークフロー管理に役立つ優れたツールです | [Use AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **サーバーのテスト** | 開発プロセスで重要なテストについて、複数のツールを使ったテスト方法を学びます | [Testing your server](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **サーバーのデプロイ** | ローカル開発から本番環境への移行方法を学び、サーバーの開発とデプロイを行います | [Deploy your server](./03-GettingStarted/09-deployment/README.md) |
| 04 | **実践的な実装** | 各言語のSDKを使った実装、デバッグ、テストと検証、再利用可能なプロンプトテンプレートやワークフローの作成 | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **MCPの高度なトピック** | マルチモーダルAIワークフローと拡張性、安全なスケーリング戦略、企業エコシステムにおけるMCPの活用 | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **AzureとのMCP統合** | Azureとの統合例を紹介 | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **マルチモダリティ** | 画像など異なるモダリティの扱い方を解説 | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 デモ** | OAuth2を使ったMCPの最小限Spring Bootアプリ。認可サーバーとリソースサーバーとしての動作、セキュアなトークン発行、保護されたエンドポイント、Azure Container Appsへのデプロイ、API管理との統合を示します | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **ルートコンテキスト** | ルートコンテキストについて詳しく学び、その実装方法を解説 | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **ルーティング** | さまざまなルーティングの種類を学ぶ | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **サンプリング** | サンプリングの扱い方を学ぶ | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **スケーリング** | MCPサーバーのスケーリングについて、水平・垂直スケーリング戦略、リソース最適化、パフォーマンスチューニングを解説 | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **セキュリティ** | 認証、認可、データ保護戦略を含むMCPサーバーのセキュリティ強化方法 | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web検索MCP** | SerpAPIと連携したPython MCPサーバーとクライアント。リアルタイムのウェブ、ニュース、商品検索、Q&Aを実現。マルチツールオーケストレーション、外部API統合、堅牢なエラーハンドリングを示します | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **リアルタイムストリーミング** | 今日のデータ駆動型社会で不可欠なリアルタイムデータストリーミング。ビジネスやアプリケーションが即時情報アクセスで迅速な意思決定を可能にします | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **リアルタイムWeb検索** | MCPがAIモデル、検索エンジン、アプリケーション間でのコンテキスト管理を標準化し、リアルタイムWeb検索をどのように変革するかを解説 | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **コミュニティへの貢献** | コードやドキュメントの貢献方法、GitHubを通じた協力、コミュニティ主導の改善とフィードバック | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **早期導入からの洞察** | 実際の導入事例と成功要因、MCPベースのソリューションの構築と展開、トレンドと今後のロードマップ | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCPのベストプラクティス** | パフォーマンスチューニングと最適化、フォールトトレラントなMCPシステム設計、テストとレジリエンス戦略 | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCPケーススタディ** | MCPソリューションアーキテクチャの詳細解析、展開ブループリントと統合のヒント、注釈付き図解とプロジェクトウォークスルー | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AIワークフローの効率化：AIツールキットを使ったMCPサーバー構築** | MCPとMicrosoftのAIツールキット for VS Codeを組み合わせた実践的ワークショップ。基本からカスタムサーバー開発、実運用展開戦略まで、実用的なモジュールでAIモデルと現実世界のツールをつなぐインテリジェントなアプリケーションの構築方法を学びます。 | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## サンプルプロジェクト

### 🧮 MCP電卓サンプルプロジェクト:
<details>
  <summary><strong>言語別コード実装を探る</strong></summary>

  - [C# MCPサーバー例](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP電卓](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCPデモ](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCPサーバー](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP例](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP高度な電卓プロジェクト:
<details>
  <summary><strong>高度なサンプルを探る</strong></summary>

  - [高度なC#サンプル](./04-PracticalImplementation/samples/csharp/README.md)
  - [Javaコンテナアプリ例](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript高度サンプル](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python複雑実装](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScriptコンテナサンプル](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP学習の前提条件

このカリキュラムを最大限に活用するには、以下が望ましいです：

- C#、Java、またはPythonの基本知識
- クライアント・サーバーモデルおよびAPIの理解
- （任意）機械学習の基礎知識

## 📚 学習ガイド

このリポジトリを効果的に活用するための包括的な[学習ガイド](./study_guide.md)があります。内容は以下を含みます：

- カバーするトピックを視覚的に示したカリキュラムマップ
- 各リポジトリセクションの詳細な内訳
- サンプルプロジェクトの活用方法の案内
- スキルレベル別の推奨学習パス
- 学習を補完する追加リソース

## 🛠️ このカリキュラムの効果的な使い方

各レッスンには以下が含まれます：

1. MCPコンセプトの明確な説明  
2. 複数言語でのライブコード例  
3. 実際のMCPアプリ構築の演習  
4. 上級者向けの追加リソース  

## 📜 ライセンス情報

本コンテンツは**MITライセンス**の下で提供されています。利用条件は[LICENSE](../../LICENSE)をご覧ください。

## 🤝 コントリビューションガイドライン

このプロジェクトは貢献や提案を歓迎します。ほとんどの貢献には、あなたが権利を持ち、実際に当社に貢献物の利用権を与えることを宣言するContributor License Agreement (CLA)への同意が必要です。詳細は<https://cla.opensource.microsoft.com>をご覧ください。

プルリクエストを送信すると、CLAボットが自動的にCLAの提出が必要か判断し、PRに適切な装飾（ステータスチェックやコメントなど）を行います。ボットの指示に従うだけで、当社のCLAを利用するすべてのリポジトリで一度だけの対応で済みます。

このプロジェクトは[Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)を採用しています。詳しくは[Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)をご覧いただくか、質問やコメントは[opencode@microsoft.com](mailto:opencode@microsoft.com)までご連絡ください。

## 🎒 その他のコース
当チームは他にもコースを提供しています。ぜひご覧ください：

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [.NETを使った初心者向け生成AI](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [JavaScriptを使った初心者向け生成AI](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [初心者向け生成AI](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [初心者向け機械学習](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [初心者向けデータサイエンス](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [初心者向けAI](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [初心者向けサイバーセキュリティ](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [初心者向けWeb開発](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [初心者向けIoT](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [初心者向けXR開発](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [AIペアプログラミングのためのGitHub Copilotマスターガイド](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [C#/.NET開発者のためのGitHub Copilotマスターガイド](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [自分だけのCopilotアドベンチャーを選ぼう](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ 商標に関する注意

このプロジェクトには、プロジェクト、製品、またはサービスの商標やロゴが含まれている場合があります。Microsoftの商標やロゴの正当な使用は、[Microsoftの商標およびブランドガイドライン](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)に従う必要があります。  
本プロジェクトの改変版でMicrosoftの商標やロゴを使用する場合、混乱を招いたりMicrosoftの後援を示唆したりしてはいけません。  
第三者の商標やロゴの使用については、それらの第三者の方針に従う必要があります。

**免責事項**：  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の母国語版が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。