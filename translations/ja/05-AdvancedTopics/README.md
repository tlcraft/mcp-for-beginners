<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a5c1d9e9856024d23da4a65a847c75ac",
  "translation_date": "2025-07-18T07:12:42+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ja"
}
-->
# MCPの高度なトピック

この章では、Model Context Protocol（MCP）の実装における高度なトピックを扱います。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合などが含まれます。これらのトピックは、現代のAIシステムの要求に応える堅牢で本番環境対応のMCPアプリケーションを構築するために重要です。

## 概要

このレッスンでは、Model Context Protocolの実装における高度な概念を探ります。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合に焦点を当てています。これらのトピックは、複雑な要件を持つエンタープライズ環境で対応可能な本番グレードのMCPアプリケーションを構築するために不可欠です。

## 学習目標

このレッスンを終えるまでに、以下ができるようになります：

- MCPフレームワーク内でマルチモーダル機能を実装する
- 高負荷シナリオに対応できるスケーラブルなMCPアーキテクチャを設計する
- MCPのセキュリティ原則に沿ったセキュリティのベストプラクティスを適用する
- MCPをエンタープライズAIシステムやフレームワークと統合する
- 本番環境でのパフォーマンスと信頼性を最適化する

## レッスンとサンプルプロジェクト

| Link | タイトル | 説明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azureとの統合 | Azure上でMCPサーバーを統合する方法を学びます |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCPマルチモーダルサンプル | 音声、画像、マルチモーダル応答のサンプル |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2デモ | OAuth2を用いたMCPの最小限Spring Bootアプリ。認可サーバーとリソースサーバーの両方を示し、安全なトークン発行、保護されたエンドポイント、Azure Container Appsへのデプロイ、API管理の統合を実演。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | ルートコンテキスト | ルートコンテキストについて詳しく学び、その実装方法を理解する |
| [5.5 Routing](./mcp-routing/README.md) | ルーティング | さまざまなルーティングの種類を学ぶ |
| [5.6 Sampling](./mcp-sampling/README.md) | サンプリング | サンプリングの扱い方を学ぶ |
| [5.7 Scaling](./mcp-scaling/README.md) | スケーリング | スケーリングについて学ぶ |
| [5.8 Security](./mcp-security/README.md) | セキュリティ | MCPサーバーのセキュリティを強化する |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web検索MCP | PythonのMCPサーバーとクライアントがSerpAPIと連携し、リアルタイムのウェブ、ニュース、商品検索、Q&Aを実現。マルチツールのオーケストレーション、外部API統合、堅牢なエラーハンドリングを示す。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | ストリーミング | 今日のデータ駆動型の世界では、リアルタイムデータストリーミングが不可欠であり、ビジネスやアプリケーションが即時の情報アクセスを必要とするため、迅速な意思決定を支援します。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | ウェブ検索 | MCPがAIモデル、検索エンジン、アプリケーション間でのコンテキスト管理を標準化することで、リアルタイムウェブ検索をどのように変革するかを学ぶ。 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID認証 | Microsoft Entra IDは、クラウドベースの強力なIDおよびアクセス管理ソリューションを提供し、認可されたユーザーとアプリケーションのみがMCPサーバーとやり取りできるようにします。 |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry統合 | Model Context ProtocolサーバーをAzure AI Foundryエージェントと統合し、標準化された外部データソース接続による強力なツールオーケストレーションとエンタープライズAI機能を実現する方法を学ぶ。 |
| [5.14 Context Engineering](./mcp-contextengineering/README.md) | コンテキストエンジニアリング | MCPサーバー向けのコンテキストエンジニアリング技術の将来の可能性。コンテキスト最適化、動的コンテキスト管理、MCPフレームワーク内での効果的なプロンプトエンジニアリング戦略を含む。 |

## 追加参考資料

最新の高度なMCPトピックについては、以下を参照してください：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要なポイント

- マルチモーダルMCP実装はテキスト処理を超えたAIの能力を拡張する
- スケーラビリティはエンタープライズ展開に不可欠であり、水平・垂直スケーリングで対応可能
- 包括的なセキュリティ対策がデータ保護と適切なアクセス制御を保証する
- Azure OpenAIやMicrosoft AI Foundryなどのプラットフォームとのエンタープライズ統合がMCPの能力を強化する
- 高度なMCP実装は最適化されたアーキテクチャと慎重なリソース管理から恩恵を受ける

## 演習

特定のユースケースに対するエンタープライズグレードのMCP実装を設計してください：

1. ユースケースのマルチモーダル要件を特定する
2. 機密データを保護するために必要なセキュリティコントロールを概説する
3. 変動する負荷に対応可能なスケーラブルなアーキテクチャを設計する
4. エンタープライズAIシステムとの統合ポイントを計画する
5. 潜在的なパフォーマンスのボトルネックとその緩和策を文書化する

## 追加リソース

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 次に進む

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。