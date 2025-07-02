<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:05:20+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ja"
}
-->
# MCPの高度なトピック

この章では、Model Context Protocol（MCP）実装におけるマルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合など、一連の高度なトピックを扱います。これらのトピックは、現代のAIシステムの要求に応える堅牢で本番環境対応のMCPアプリケーションを構築するために非常に重要です。

## 概要

このレッスンでは、Model Context Protocolの実装における高度な概念を探求します。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合に焦点を当てています。これらは、複雑な要件を持つエンタープライズ環境で動作する本番品質のMCPアプリケーションを構築するために不可欠なトピックです。

## 学習目標

このレッスンを終えるまでに、以下ができるようになります：

- MCPフレームワーク内でマルチモーダル機能を実装する
- 高負荷シナリオに対応できるスケーラブルなMCPアーキテクチャを設計する
- MCPのセキュリティ原則に沿ったセキュリティのベストプラクティスを適用する
- MCPをエンタープライズAIシステムやフレームワークと統合する
- 本番環境でのパフォーマンスと信頼性を最適化する

## レッスンとサンプルプロジェクト

| リンク | タイトル | 説明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azureとの統合 | Azure上でのMCPサーバー統合方法を学ぶ |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCPマルチモーダルサンプル | 音声、画像、マルチモーダル応答のサンプル |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2デモ | OAuth2を用いたMCPの認可サーバーおよびリソースサーバーを示す最小限のSpring Bootアプリ。安全なトークン発行、保護されたエンドポイント、Azure Container Appsへのデプロイ、API Management統合をデモ。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | ルートコンテキスト | ルートコンテキストの詳細と実装方法を学ぶ |
| [5.5 Routing](./mcp-routing/README.md) | ルーティング | さまざまなルーティングの種類を学ぶ |
| [5.6 Sampling](./mcp-sampling/README.md) | サンプリング | サンプリングの扱い方を学ぶ |
| [5.7 Scaling](./mcp-scaling/README.md) | スケーリング | スケーリングについて学ぶ |
| [5.8 Security](./mcp-security/README.md) | セキュリティ | MCPサーバーのセキュリティ強化方法 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web検索MCP | Python製MCPサーバーとクライアントによるSerpAPI統合で、リアルタイムのウェブ、ニュース、商品検索、Q&Aを実現。マルチツールのオーケストレーション、外部API統合、堅牢なエラーハンドリングをデモ。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | ストリーミング | 今日のデータ駆動型社会において、即時情報アクセスが求められるため、リアルタイムデータストリーミングは不可欠になっている。 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | ウェブ検索 | MCPがAIモデル、検索エンジン、アプリケーション間でのコンテキスト管理を標準化し、リアルタイムウェブ検索を変革する方法。 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID認証 | Microsoft Entra IDは、クラウドベースの堅牢なIDおよびアクセス管理ソリューションを提供し、許可されたユーザーとアプリケーションのみがMCPサーバーとやり取りできるようにする。 |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry統合 | MCPサーバーをAzure AI Foundryエージェントと統合し、強力なツールオーケストレーションとエンタープライズAI機能を標準化された外部データソース接続で実現する方法を学ぶ。 |

## 追加の参考資料

最新の高度なMCPトピックについては、以下を参照してください：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要なポイント

- マルチモーダルMCPの実装は、テキスト処理を超えたAIの能力を拡張する
- スケーラビリティはエンタープライズ展開に不可欠であり、水平・垂直スケーリングで対応可能
- 包括的なセキュリティ対策によりデータ保護と適切なアクセス制御を実現
- Azure OpenAIやMicrosoft AI Foundryなどのプラットフォームとのエンタープライズ統合がMCPの能力を強化
- 高度なMCP実装は、最適化されたアーキテクチャとリソース管理によって恩恵を受ける

## 演習

特定のユースケースに対するエンタープライズグレードのMCP実装を設計してください：

1. ユースケースのマルチモーダル要件を特定する
2. 機密データを保護するために必要なセキュリティ制御を概説する
3. 変動する負荷に対応可能なスケーラブルなアーキテクチャを設計する
4. エンタープライズAIシステムとの統合ポイントを計画する
5. 潜在的なパフォーマンスボトルネックとその緩和策を文書化する

## 追加リソース

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 次に進む

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間翻訳をご利用いただくことを推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。