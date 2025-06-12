<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:03:35+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ja"
}
-->
# MCPの高度なトピック

この章では、Model Context Protocol（MCP）の実装における高度なトピックを扱います。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合などが含まれます。これらのトピックは、現代のAIシステムの要求に応える堅牢で本番環境対応のMCPアプリケーションを構築するために重要です。

## 概要

このレッスンでは、Model Context Protocolの実装における高度な概念を探ります。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合に焦点を当てています。これらは、エンタープライズ環境での複雑な要件に対応できる本番対応のMCPアプリケーションを構築するために欠かせません。

## 学習目標

このレッスンを終えるまでに、以下ができるようになります：

- MCPフレームワーク内でマルチモーダル機能を実装する
- 高負荷シナリオに対応するスケーラブルなMCPアーキテクチャを設計する
- MCPのセキュリティ原則に沿ったセキュリティのベストプラクティスを適用する
- MCPをエンタープライズのAIシステムやフレームワークと統合する
- 本番環境でのパフォーマンスと信頼性を最適化する

## レッスンとサンプルプロジェクト

| Link | タイトル | 説明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azureとの統合 | Azure上でMCPサーバーを統合する方法を学ぶ |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCPマルチモーダルサンプル | 音声、画像、マルチモーダル応答のサンプル |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2デモ | OAuth2を用いたMCPの認可サーバーおよびリソースサーバーとしての最小限のSpring Bootアプリ。安全なトークン発行、保護されたエンドポイント、Azure Container Appsへのデプロイ、API Management統合を示す。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | ルートコンテキスト | ルートコンテキストについての詳細と実装方法を学ぶ |
| [5.5 Routing](./mcp-routing/README.md) | ルーティング | 様々なルーティングの種類を学ぶ |
| [5.6 Sampling](./mcp-sampling/README.md) | サンプリング | サンプリングの扱い方を学ぶ |
| [5.7 Scaling](./mcp-scaling/README.md) | スケーリング | スケーリングについて学ぶ |
| [5.8 Security](./mcp-security/README.md) | セキュリティ | MCPサーバーを安全に保つ方法 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web検索MCP | PythonのMCPサーバーとクライアントでSerpAPIと連携し、リアルタイムのウェブ、ニュース、商品検索、Q&Aを実現。マルチツールのオーケストレーション、外部API統合、堅牢なエラーハンドリングを示す。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | ストリーミング | 今日のデータ駆動型の世界では、ビジネスやアプリケーションが即時の情報アクセスを必要とし、リアルタイムデータストリーミングが不可欠になっている。 |

## 追加参考資料

最新の高度なMCPトピックについては以下を参照してください：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要なポイント

- マルチモーダルなMCP実装はテキスト処理を超えたAIの能力を拡張する
- スケーラビリティはエンタープライズ展開に不可欠であり、水平および垂直スケーリングで対応可能
- 包括的なセキュリティ対策によりデータを保護し、適切なアクセス制御を実現する
- Azure OpenAIやMicrosoft AI Foundryなどのプラットフォームとのエンタープライズ統合でMCPの機能が強化される
- 高度なMCP実装は最適化されたアーキテクチャとリソース管理によって恩恵を受ける

## 演習

特定のユースケースに対するエンタープライズグレードのMCP実装を設計してください：

1. ユースケースに必要なマルチモーダル要件を特定する
2. 機密データを保護するためのセキュリティコントロールを概説する
3. 変動する負荷に対応可能なスケーラブルなアーキテクチャを設計する
4. エンタープライズAIシステムとの統合ポイントを計画する
5. 潜在的なパフォーマンスのボトルネックとその緩和策を文書化する

## 追加リソース

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 次に進むには

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても責任を負いかねます。