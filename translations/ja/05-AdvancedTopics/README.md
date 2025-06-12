<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-12T21:36:48+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ja"
}
-->
# MCPの高度なトピック

この章では、Model Context Protocol（MCP）の実装における高度なトピックを扱います。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合などが含まれます。これらのトピックは、現代のAIシステムの要求に応えられる堅牢で本番環境対応のMCPアプリケーションを構築する上で非常に重要です。

## 概要

このレッスンでは、Model Context Protocolの実装における高度な概念を探ります。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合に焦点を当てています。これらは、複雑な要件を持つエンタープライズ環境で本番レベルのMCPアプリケーションを構築するために欠かせないトピックです。

## 学習目標

このレッスンを終えるまでに、以下ができるようになります：

- MCPフレームワーク内でマルチモーダル機能を実装する
- 高負荷シナリオに対応できるスケーラブルなMCPアーキテクチャを設計する
- MCPのセキュリティ原則に沿ったベストプラクティスを適用する
- MCPをエンタープライズAIシステムやフレームワークと統合する
- 本番環境でのパフォーマンスと信頼性を最適化する

## レッスンとサンプルプロジェクト

| Link | タイトル | 説明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azureとの統合 | Azure上でのMCPサーバーの統合方法を学ぶ |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCPマルチモーダルサンプル | 音声、画像、マルチモーダル応答のサンプル |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2デモ | MCPの認可サーバーおよびリソースサーバーとしてのOAuth2を示す最小限のSpring Bootアプリ。安全なトークン発行、保護されたエンドポイント、Azure Container Apps展開、API管理統合をデモ。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | ルートコンテキスト | ルートコンテキストについて詳しく学び、実装方法を習得 |
| [5.5 Routing](./mcp-routing/README.md) | ルーティング | さまざまなルーティングの種類を学ぶ |
| [5.6 Sampling](./mcp-sampling/README.md) | サンプリング | サンプリングの扱い方を学ぶ |
| [5.7 Scaling](./mcp-scaling/README.md) | スケーリング | スケーリングについて学ぶ |
| [5.8 Security](./mcp-security/README.md) | セキュリティ | MCPサーバーを安全に保つ方法 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web検索MCP | PythonベースのMCPサーバーとクライアントで、SerpAPIを使ったリアルタイムのウェブ、ニュース、商品検索、Q&Aを統合。マルチツールのオーケストレーション、外部API連携、堅牢なエラーハンドリングをデモ。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | ストリーミング | リアルタイムデータストリーミングは、ビジネスやアプリケーションが即時の情報アクセスを必要とする現代のデータ駆動型社会で不可欠になっています。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | ウェブ検索 | MCPがAIモデル、検索エンジン、アプリケーション間のコンテキスト管理を標準化することで、リアルタイムウェブ検索をどのように変革するかを学ぶ。 |

## 追加参考資料

高度なMCPトピックの最新情報は以下を参照してください：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要なポイント

- マルチモーダルMCP実装はテキスト処理を超えたAIの能力を拡張する
- スケーラビリティはエンタープライズ展開に不可欠であり、水平・垂直スケーリングで対応可能
- 包括的なセキュリティ対策によりデータ保護と適切なアクセス制御を実現
- Azure OpenAIやMicrosoft AI Foundryなどのプラットフォームとのエンタープライズ統合がMCPの能力を強化
- 高度なMCP実装は最適化されたアーキテクチャと慎重なリソース管理によって恩恵を受ける

## 演習

特定のユースケースに対してエンタープライズレベルのMCP実装を設計してください：

1. ユースケースに必要なマルチモーダル要件を特定する
2. 機密データを保護するためのセキュリティコントロールを概説する
3. 変動する負荷に対応可能なスケーラブルなアーキテクチャを設計する
4. エンタープライズAIシステムとの統合ポイントを計画する
5. パフォーマンスのボトルネックとその緩和策を文書化する

## 追加リソース

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 次に進むには

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の言語によるオリジナルの文書が権威ある情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、一切の責任を負いかねますのでご了承ください。