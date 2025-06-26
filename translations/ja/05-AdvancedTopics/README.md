<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T13:45:28+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ja"
}
-->
# MCPの高度なトピック

この章では、Model Context Protocol（MCP）の実装における高度なトピックを取り扱います。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合など、現代のAIシステムの要求に応える堅牢で本番環境対応のMCPアプリケーション構築に不可欠な内容です。

## 概要

このレッスンでは、Model Context Protocolの実装における高度な概念を探ります。マルチモーダル統合、スケーラビリティ、セキュリティのベストプラクティス、エンタープライズ統合に焦点を当てています。これらのトピックは、エンタープライズ環境で複雑な要件に対応できる本番レベルのMCPアプリケーション構築に必須です。

## 学習目標

このレッスンを終える頃には、以下ができるようになります：

- MCPフレームワーク内でマルチモーダル機能を実装する
- 高負荷シナリオに対応可能なスケーラブルなMCPアーキテクチャを設計する
- MCPのセキュリティ原則に沿ったベストプラクティスを適用する
- MCPをエンタープライズAIシステムやフレームワークと統合する
- 本番環境でのパフォーマンスと信頼性を最適化する

## レッスンとサンプルプロジェクト

| Link | タイトル | 説明 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azureとの統合 | Azure上でMCPサーバーを統合する方法を学びます |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCPマルチモーダルサンプル | 音声、画像、マルチモーダル応答のサンプル |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2デモ | OAuth2を用いたMCPのミニマルなSpring Bootアプリ。認可サーバーとリソースサーバーの両方を示し、安全なトークン発行、保護されたエンドポイント、Azure Container Appsへのデプロイ、API Management統合を実演します。 |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | ルートコンテキスト | ルートコンテキストについて詳しく学び、その実装方法を解説します |
| [5.5 Routing](./mcp-routing/README.md) | ルーティング | さまざまなタイプのルーティングを学びます |
| [5.6 Sampling](./mcp-sampling/README.md) | サンプリング | サンプリングの扱い方を学びます |
| [5.7 Scaling](./mcp-scaling/README.md) | スケーリング | スケーリングについて学びます |
| [5.8 Security](./mcp-security/README.md) | セキュリティ | MCPサーバーのセキュリティを強化します |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web検索MCP | Python製MCPサーバーとクライアントがSerpAPIと連携し、リアルタイムのウェブ、ニュース、商品検索、Q&Aを実現。マルチツールのオーケストレーション、外部API統合、堅牢なエラーハンドリングを実演します。 |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | ストリーミング | 今日のデータ駆動型社会で即時の情報アクセスが求められる中、リアルタイムデータストリーミングの重要性を解説します。|
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | ウェブ検索 | MCPがAIモデル、検索エンジン、アプリケーション間のコンテキスト管理を標準化し、リアルタイムウェブ検索をどのように変革するかを説明します。|
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID認証 | Microsoft Entra IDは、クラウドベースの堅牢なID・アクセス管理ソリューションを提供し、認可されたユーザーとアプリケーションのみがMCPサーバーとやり取りできるようにします。|

## 追加参考資料

高度なMCPトピックの最新情報は以下を参照してください：
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 重要ポイント

- マルチモーダルなMCP実装はテキスト処理を超えたAIの能力を拡張する
- スケーラビリティはエンタープライズ展開に不可欠で、水平・垂直スケーリングで対応可能
- 包括的なセキュリティ対策がデータ保護と適切なアクセス制御を実現する
- Azure OpenAIやMicrosoft AI Foundryなどのプラットフォームとのエンタープライズ統合がMCPの能力を強化する
- 高度なMCP実装は最適化されたアーキテクチャと慎重なリソース管理から恩恵を受ける

## 演習

特定のユースケースに対するエンタープライズレベルのMCP実装を設計してください：

1. ユースケースのマルチモーダル要件を特定する
2. 機密データを保護するために必要なセキュリティ制御を概説する
3. 変動する負荷に対応できるスケーラブルなアーキテクチャを設計する
4. エンタープライズAIシステムとの統合ポイントを計画する
5. 潜在的なパフォーマンスボトルネックとその緩和策を文書化する

## 追加リソース

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 次に進む

- [5.1 MCP Integration](./mcp-integration/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨いたします。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。