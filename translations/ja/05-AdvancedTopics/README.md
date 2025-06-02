<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T18:34:43+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ja"
}
-->
# MCPの高度なトピック

この章では、Model Context Protocol（MCP）実装における高度なトピック群を扱います。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合などが含まれます。これらのトピックは、現代のAIシステムの要求に応えられる堅牢で本番環境対応のMCPアプリケーションを構築するために不可欠です。

## 概要

このレッスンでは、Model Context Protocolの実装における高度な概念を探ります。特にマルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合に焦点を当てています。これらは複雑な要件を持つエンタープライズ環境で動作する本番グレードのMCPアプリケーションを構築するために重要です。

## 学習目標

このレッスンの終了時には、以下のことができるようになります：

- MCPフレームワーク内でマルチモーダル機能を実装する
- 高負荷シナリオに対応できるスケーラブルなMCPアーキテクチャを設計する
- MCPのセキュリティ原則に沿ったセキュリティのベストプラクティスを適用する
- MCPをエンタープライズのAIシステムやフレームワークと統合する
- 本番環境でのパフォーマンスと信頼性を最適化する

## レッスンとサンプルプロジェクト

| Link | タイトル | 説明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azureとの統合 | Azure上でのMCPサーバー統合方法を学ぶ |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCPマルチモーダルサンプル | 音声、画像、マルチモーダル応答のサンプル |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2デモ | MCPを使ったOAuth2を示す最小限のSpring Bootアプリ。認可サーバーとリソースサーバーの両方として機能し、安全なトークン発行、保護されたエンドポイント、Azure Container Appsへのデプロイ、API管理の統合を実演。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | ルートコンテキスト | ルートコンテキストについて詳しく学び、その実装方法を習得 |
| [5.5 Routing](./mcp-routing/README.md) | ルーティング | さまざまなルーティングの種類を学ぶ |
| [5.6 Sampling](./mcp-sampling/README.md) | サンプリング | サンプリングの扱い方を学ぶ |
| [5.7 Scaling](./mcp-scaling/README.md) | スケーリング | スケーリングについて学ぶ |
| [5.8 Security](./mcp-security/README.md) | セキュリティ | MCPサーバーのセキュリティ強化方法 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | SerpAPIと連携したPython MCPサーバーとクライアント。リアルタイムのウェブ、ニュース、製品検索、Q&Aを実現。マルチツールのオーケストレーション、外部API統合、堅牢なエラーハンドリングを実演。 |

## 追加参考資料

高度なMCPトピックの最新情報については以下を参照してください：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要ポイント

- マルチモーダルMCPの実装はテキスト処理を超えたAI能力を拡張する
- スケーラビリティはエンタープライズ展開に不可欠で、水平・垂直スケーリングで対応可能
- 包括的なセキュリティ対策がデータ保護と適切なアクセス制御を保証する
- Azure OpenAIやMicrosoft AI Foundryなどのプラットフォームとのエンタープライズ統合がMCPの機能を強化する
- 高度なMCP実装は最適化されたアーキテクチャと慎重なリソース管理から恩恵を受ける

## 演習

特定のユースケースに対するエンタープライズグレードのMCP実装を設計してください：

1. ユースケースのマルチモーダル要件を特定する
2. 機密データを保護するために必要なセキュリティ制御を概説する
3. 変動する負荷に対応可能なスケーラブルなアーキテクチャを設計する
4. エンタープライズAIシステムとの統合ポイントを計画する
5. 潜在的なパフォーマンスのボトルネックとその緩和策を文書化する

## 追加リソース

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 次に進むには

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責事項**:  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な表現が含まれる場合があります。原文の言語で記載された文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や解釈の相違についても、当方は責任を負いかねます。