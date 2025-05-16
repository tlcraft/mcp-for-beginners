<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ceacbad0013938974fc0bf493e93f05b",
  "translation_date": "2025-05-16T17:09:55+00:00",
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
2. **リポジトリをクローンする**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Microsoft Azure AI Foundry Discord に参加して、専門家や他の開発者と交流しよう**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 多言語対応

### GitHub Action によるサポート（自動化＆常に最新）

[French](../fr/README.md) | [Spanish](../es/README.md) | [German](../de/README.md) | [Chinese (Simplified)](../zh/README.md)  [Japanese](./README.md) | [Korean](../ko/README.md) | [Polish](../pl/README.md)


# 🚀 初心者向け Model Context Protocol (MCP) カリキュラム 完全ガイド

## **C#, Java, JavaScript, Python, TypeScript の実践コード例で学ぶ MCP**

## 🧠 Model Context Protocol カリキュラムの概要

**Model Context Protocol (MCP)** は、AIモデルとクライアントアプリケーション間のやり取りを標準化する最先端のフレームワークです。このオープンソースのカリキュラムは、C#, Java, JavaScript, TypeScript, Python といった人気のプログラミング言語での実用的なコード例や実際のユースケースを交えた体系的な学習パスを提供します。

AI開発者、システムアーキテクト、ソフトウェアエンジニアを問わず、このガイドはMCPの基礎から実装方法までをマスターするための包括的なリソースです。

## 🔗 公式MCPリソース

- 📘 [MCPドキュメント](https://modelcontextprotocol.io/) – 詳細なチュートリアルとユーザーガイド  
- 📜 [MCP仕様書](https://spec.modelcontextprotocol.io/) – プロトコルの構造と技術的リファレンス  
- 🧑‍💻 [MCP GitHubリポジトリ](https://github.com/modelcontextprotocol) – オープンソースのSDK、ツール、コードサンプル  

## 🧭 MCPカリキュラムの全体構成

### 📌 [MCP入門](./00-Introduction/README.md)

- Model Context Protocolとは何か
- AIパイプラインにおける標準化の重要性
- MCPの実用例とメリット

### 🧩 [コアコンセプトの解説](./01-CoreConcepts/README.md)

- MCPにおけるクライアント・サーバーアーキテクチャの理解
- 主要なプロトコル要素：リクエスト、レスポンス、スキーマ
- MCPのメッセージングとデータ交換パターン

### 🔐 [MCPのセキュリティ](./02-Security/readme.md)

- MCPベースのシステムにおけるセキュリティリスクの特定
- 実装を安全に保つための手法とベストプラクティス

### 🚀 [MCPのはじめ方](./03-GettingStarted/README.md)

- 環境設定と構築
- 基本的なMCPサーバーとクライアントの作成
- 既存アプリケーションへのMCP統合

#### 🧮 MCP電卓サンプルプロジェクト：
<details>
  <summary><strong>言語別コード実装を見てみる</strong></summary>

  - [C# MCPサーバー例](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP電卓](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCPデモ](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCPサーバー](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP例](./03-GettingStarted/samples/typescript/README.md)

</details>
### 🛠️ [実践的な実装](./04-PracticalImplementation/README.md)

- 複数言語でのSDKの利用
- デバッグ、テスト、検証
- 再利用可能なプロンプトテンプレートとワークフローの作成

#### 💡 MCP高度計算プロジェクト：
<details>
  <summary><strong>高度なサンプルを探る</strong></summary>

  - [高度なC#サンプル](./04-PracticalImplementation/samples/csharp/README.md)
  - [Javaコンテナアプリ例](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript高度サンプル](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python複雑な実装](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScriptコンテナサンプル](./04-PracticalImplementation/samples/typescript/README.md)

</details>

### 🎓 [MCPの高度なトピック](./05-AdvancedTopics/README.md)

- マルチモーダルAIワークフローと拡張性
- セキュアなスケーリング戦略
- 企業エコシステムにおけるMCP

### 🌍 [コミュニティへの貢献](./06-CommunityContributions/README.md)

- コードやドキュメントの貢献方法
- GitHubを通じたコラボレーション
- コミュニティ主導の改善とフィードバック

### 📈 [早期導入からの洞察](./07-CaseStudies/README.md)

- 実際の導入事例と成功要因
- MCPベースのソリューションの構築と展開
- トレンドと今後のロードマップ

### 📏 [MCPのベストプラクティス](./08-BestPractices/README.md)

- パフォーマンスチューニングと最適化
- 障害に強いMCPシステムの設計
- テストとレジリエンス戦略

### 📊 [MCPケーススタディ](./09-CaseStudy/Readme.md)

- MCPソリューションアーキテクチャの詳細解析
- 展開の設計図と統合のヒント
- 注釈付き図解とプロジェクトのウォークスルー

## 🎯 MCP学習の前提条件

このカリキュラムを最大限に活用するには、以下が望ましいです：

- C#、Java、またはPythonの基本知識
- クライアントサーバーモデルとAPIの理解
- （任意）機械学習の基本概念への親しみ

## 🛠️ このカリキュラムの効果的な使い方

各レッスンには以下が含まれます：

1. MCPの概念のわかりやすい解説  
2. 複数言語でのライブコード例  
3. 実際のMCPアプリケーション構築の演習  
4. 上級者向けの追加リソース  

## 📜 ライセンス情報

このコンテンツは**MITライセンス**のもとで提供されています。利用規約については[LICENSE](../../LICENSE)をご覧ください。

## 🤝 貢献ガイドライン

このプロジェクトでは貢献や提案を歓迎しています。ほとんどの貢献には、貢献者が権利を持ち、実際に当該権利を付与することを宣言するContributor License Agreement（CLA）への同意が必要です。詳細は<https://cla.opensource.microsoft.com>をご覧ください。

プルリクエストを送信すると、CLAボットが自動的にCLAの必要性を判定し、PRに適切な表示（ステータスチェックやコメントなど）を行います。ボットの指示に従うだけで手続きは完了します。この操作はCLAを利用する全リポジトリで一度だけ必要です。

このプロジェクトは[Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)を採用しています。詳細は[Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)をご覧いただくか、質問やコメントは[opencode@microsoft.com](mailto:opencode@microsoft.com)までお問い合わせください。

## ™️ 商標について

このプロジェクトにはプロジェクト、製品、サービスの商標やロゴが含まれている場合があります。Microsoftの商標やロゴの正当な使用は、[Microsoftの商標・ブランドガイドライン](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)に従う必要があります。改変版でのMicrosoft商標やロゴの使用は混乱を招かず、Microsoftの後援を示唆してはなりません。第三者の商標やロゴの使用は、該当する第三者のポリシーに従います。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の母国語版が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の相違について、当方は一切の責任を負いかねます。