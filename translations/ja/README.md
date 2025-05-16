<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "537bdb70a3ce1e8bd86c83c74bf98c77",
  "translation_date": "2025-05-16T14:22:34+00:00",
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
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/network)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


これらのリソースを使い始めるには、以下の手順に従ってください：
1. **リポジトリをフォークする**: クリック [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/network)
2. **リポジトリをクローンする**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Microsoft Azure AI Foundry Discordに参加して、専門家や他の開発者と交流する**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 多言語サポート

#### GitHub Actionによるサポート（自動化＆常に最新）


# 🚀 Model Context Protocol (MCP) 初心者向けカリキュラムの究極ガイド

## **C#, Java, JavaScript, Python, TypeScriptで学ぶMCPの実践コード例**

## 🧠 Model Context Protocolカリキュラムの概要

**Model Context Protocol (MCP)** は、AIモデルとクライアントアプリケーション間のやり取りを標準化するために設計された最先端のフレームワークです。このオープンソースのカリキュラムは、C#, Java, JavaScript, TypeScript, Pythonといった主要なプログラミング言語での実践的なコード例や実際のユースケースを含む体系的な学習パスを提供します。

AI開発者、システムアーキテクト、ソフトウェアエンジニアのいずれであっても、このガイドはMCPの基本から実装戦略までをマスターするための包括的なリソースです。

## 🔗 MCP公式リソース

- 📘 [MCPドキュメント](https://modelcontextprotocol.io/) – 詳細なチュートリアルとユーザーガイド  
- 📜 [MCP仕様書](https://spec.modelcontextprotocol.io/) – プロトコルの構造と技術的リファレンス  
- 🧑‍💻 [MCP GitHubリポジトリ](https://github.com/modelcontextprotocol) – オープンソースSDK、ツール、コードサンプル  

## 🧭 MCPカリキュラム全体構成

### 📌 [MCP入門](./00-Introduction/README.md)

- Model Context Protocolとは何か？
- AIパイプラインにおける標準化の重要性
- MCPの実用的なユースケースとメリット

### 🧩 [コアコンセプトの解説](./01-CoreConcepts/README.md)

- MCPにおけるクライアント・サーバーアーキテクチャの理解
- 主要なプロトコル要素：リクエスト、レスポンス、スキーマ
- MCPのメッセージングとデータ交換パターン

### 🔐 [MCPのセキュリティ](./02-Security/readme.md)

- MCPベースのシステムにおけるセキュリティ脅威の特定
- セキュアな実装のための手法とベストプラクティス

### 🚀 [MCPの始め方](./03-GettingStarted/README.md)

- 環境構築と設定
- 基本的なMCPサーバーとクライアントの作成
- 既存アプリケーションへのMCP統合

#### 🧮 MCP計算機サンプルプロジェクト：
<details>
  <summary><strong>言語別コード実装を確認する</strong></summary>

  - [C# MCPサーバー例](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP計算機](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCPデモ](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCPサーバー](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP例](./03-GettingStarted/samples/typescript/README.md)

</details>

### 🛠️ [実践的な実装](./04-PracticalImplementation/README.md)

- 各言語でのSDK利用
- デバッグ、テスト、検証
- 再利用可能なプロンプトテンプレートとワークフローの作成

#### 💡 MCP高度な計算機プロジェクト：
<details>
  <summary><strong>高度なサンプルを確認する</strong></summary>

  - [高度なC#サンプル](./04-PracticalImplementation/samples/csharp/README.md)
  - [Javaコンテナアプリ例](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript高度サンプル](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python複雑な実装](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScriptコンテナサンプル](./04-PracticalImplementation/samples/typescript/README.md)

</details>

### 🎓 [MCPの高度なトピック](./05-AdvancedTopics/README.md)

- マルチモーダルAIワークフローと拡張性
- セキュアなスケーリング戦略
- エンタープライズエコシステムにおけるMCP
### 🌍 [Community Contributions](./06-CommunityContributions/README.md)

- コードやドキュメントの貢献方法  
- GitHubを使った共同作業  
- コミュニティ主導の改善とフィードバック  

### 📈 [Insights from Early Adoption](./07-CaseStudies/README.md)

- 実際の導入事例と成功ポイント  
- MCPベースのソリューションの構築と展開  
- トレンドと今後のロードマップ  

### 📏 [Best Practices for MCP](./08-BestPractices/README.md)

- パフォーマンスチューニングと最適化  
- 障害に強いMCPシステムの設計  
- テストとレジリエンス戦略  

### 📊 [MCP Case Studies](./09-CaseStudy/Readme.md)

- MCPソリューションアーキテクチャの詳細解析  
- 展開の設計図と統合のヒント  
- 注釈付き図解とプロジェクトのウォークスルー  

## 🎯 Prerequisites for Learning MCP

このカリキュラムを最大限に活用するには、以下の知識があると良いでしょう：

- C#、Java、またはPythonの基本知識  
- クライアントサーバーモデルやAPIの理解  
- （任意）機械学習の基本概念の知識  

## 🛠️ How to Use This Curriculum Effectively

このガイドの各レッスンには以下が含まれます：

1. MCPの概念をわかりやすく解説  
2. 複数言語によるライブコード例  
3. 実際のMCPアプリケーションを作る演習  
4. より深く学びたい方向けの追加リソース  

## 📜 License Information

このコンテンツは**MIT License**のもとで提供されています。利用条件については[LICENSE](../../LICENSE)をご覧ください。

## 🤝 Contribution Guidelines

このプロジェクトは貢献や提案を歓迎します。ほとんどの貢献には、あなたが権利を持ち、実際に私たちに使用権を与えることを宣言するContributor License Agreement（CLA）への同意が必要です。詳細は<https://cla.opensource.microsoft.com>をご覧ください。

プルリクエストを送ると、CLAボットが自動的にCLAの提出が必要か判断し、PRにステータスチェックやコメントなどの形で表示します。ボットの指示に従うだけでOKです。この手続きはCLAを使用しているすべてのリポジトリで一度だけ行えば十分です。

このプロジェクトは[Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)を採用しています。詳しくは[Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)をご覧いただくか、ご質問があれば[opencode@microsoft.com](mailto:opencode@microsoft.com)までご連絡ください。

## ™️ Trademark Notice

このプロジェクトにはプロジェクト名、製品名、サービス名の商標やロゴが含まれる場合があります。Microsoftの商標やロゴの正当な使用は、[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)に従う必要があります。Microsoftの商標やロゴを改変したバージョンで使用する場合は、混乱を招いたりMicrosoftのスポンサーシップを示唆したりしないようにしてください。第三者の商標やロゴの使用は、それぞれの第三者のポリシーに従います。

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の言語によるオリジナル文書が権威ある情報源とみなされます。重要な情報については、専門の人間翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても責任を負いかねます。