<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:07:05+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ja"
}
-->
# セキュリティのベストプラクティス

Model Context Protocol（MCP）を採用することで、AI駆動型アプリケーションに強力な新機能がもたらされますが、従来のソフトウェアリスクを超えた独自のセキュリティ課題も生じます。セキュアコーディング、最小権限、サプライチェーンセキュリティなどの既存の懸念に加え、MCPやAIワークロードはプロンプトインジェクション、ツールポイズニング、動的ツール変更などの新たな脅威に直面します。これらのリスクは適切に管理されないと、データの流出、プライバシー侵害、意図しないシステム動作を引き起こす可能性があります。

本レッスンでは、MCPに関連する最も重要なセキュリティリスク（認証、認可、過剰な権限、間接的なプロンプトインジェクション、サプライチェーンの脆弱性）を取り上げ、それらを軽減するための具体的な対策やベストプラクティスを紹介します。また、Prompt Shields、Azure Content Safety、GitHub Advanced SecurityなどのMicrosoftソリューションを活用してMCPの実装を強化する方法も学びます。これらのコントロールを理解し適用することで、セキュリティ侵害の可能性を大幅に減らし、AIシステムの堅牢性と信頼性を確保できます。

# 学習目標

このレッスンを終える頃には、以下ができるようになります：

- Model Context Protocol（MCP）によってもたらされる独自のセキュリティリスク（プロンプトインジェクション、ツールポイズニング、過剰な権限、サプライチェーンの脆弱性）を特定し説明する。
- MCPのセキュリティリスクに対する効果的な軽減策（堅牢な認証、最小権限、セキュアなトークン管理、サプライチェーンの検証）を説明し適用する。
- Prompt Shields、Azure Content Safety、GitHub Advanced SecurityなどのMicrosoftソリューションを理解し、MCPやAIワークロードの保護に活用する。
- ツールのメタデータ検証、動的変更の監視、間接的なプロンプトインジェクション攻撃への防御の重要性を認識する。
- セキュアコーディング、サーバーの強化、ゼロトラストアーキテクチャなどの確立されたセキュリティベストプラクティスをMCP実装に統合し、セキュリティ侵害の可能性と影響を減らす。

# MCPのセキュリティコントロール

重要なリソースにアクセスできるシステムには、暗黙のセキュリティ課題があります。これらの課題は基本的なセキュリティコントロールや概念を正しく適用することで一般的に対処可能です。MCPは新しく定義されたばかりのため、仕様は急速に変化しており、プロトコルが進化するにつれてセキュリティコントロールも成熟し、エンタープライズや確立されたセキュリティアーキテクチャ、ベストプラクティスとの統合が進むでしょう。

[Microsoft Digital Defense Report](https://aka.ms/mddr) によると、報告された侵害の98%は堅牢なセキュリティ衛生状態によって防止可能であり、あらゆる侵害に対する最良の防御は基本的なセキュリティ衛生、セキュアコーディングのベストプラクティス、サプライチェーンセキュリティを正しく実践することだと述べられています。既知の実績ある対策が依然としてセキュリティリスク軽減に最も効果的です。

MCPを採用する際にセキュリティリスクに対処する方法をいくつか見ていきましょう。

> **Note:** 以下の情報は**2025年5月29日**時点の内容です。MCPプロトコルは継続的に進化しており、将来的な実装では新しい認証パターンやコントロールが導入される可能性があります。最新の更新やガイダンスについては、常に[MCP Specification](https://spec.modelcontextprotocol.io/)および公式の[MCP GitHubリポジトリ](https://github.com/modelcontextprotocol)、[セキュリティベストプラクティスページ](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)を参照してください。

### 問題提起
元のMCP仕様では、開発者が独自に認証サーバーを構築することを想定していました。これにはOAuthや関連するセキュリティ制約の知識が必要でした。MCPサーバーはOAuth 2.0認可サーバーとして機能し、Microsoft Entra IDなどの外部サービスに委任するのではなく、ユーザー認証を直接管理していました。2025年4月26日付のMCP仕様の更新により、MCPサーバーはユーザー認証を外部サービスに委任できるようになりました。

### リスク
- MCPサーバーの認可ロジックの誤設定により、機密データの漏洩や誤ったアクセス制御が発生する可能性があります。
- ローカルのMCPサーバーでOAuthトークンが盗まれた場合、そのトークンを使ってMCPサーバーを偽装し、トークンが対象とするサービスのリソースやデータにアクセスされる恐れがあります。

#### トークンパススルー
トークンパススルーは認可仕様で明示的に禁止されています。これは以下のような複数のセキュリティリスクをもたらします。

#### セキュリティコントロールの回避
MCPサーバーや下流APIは、トークンのオーディエンスやその他の資格情報制約に依存したレート制限、リクエスト検証、トラフィック監視など重要なセキュリティコントロールを実装している場合があります。クライアントがMCPサーバーの適切な検証なしに直接下流APIでトークンを使用できると、これらのコントロールを回避してしまいます。

#### 責任追跡と監査の問題
MCPサーバーは、上流で発行されたアクセス・トークンで呼び出すクライアントを識別できず区別もできません。下流のリソースサーバーのログは、実際にトークンを転送しているMCPサーバーではなく、異なるソースや異なるIDからのリクエストのように見える可能性があります。これらはインシデント調査、コントロール、監査を困難にします。MCPサーバーがトークンのクレーム（役割、権限、オーディエンスなど）やその他のメタデータを検証せずにトークンを渡すと、盗まれたトークンを持つ悪意のある攻撃者がサーバーをデータ流出のプロキシとして利用することが可能になります。

#### 信頼境界の問題
下流のリソースサーバーは特定のエンティティに信頼を与えています。この信頼には発信元やクライアントの挙動パターンに関する想定が含まれることがあります。この信頼境界を破ると予期せぬ問題が発生します。トークンが複数のサービスで適切に検証されずに受け入れられると、一つのサービスが侵害された場合にそのトークンで他の接続サービスにもアクセスされる恐れがあります。

#### 将来の互換性リスク
現在MCPサーバーが「純粋なプロキシ」として動作していても、将来的にセキュリティコントロールを追加する必要が出てくる可能性があります。最初から適切なトークンオーディエンスの分離を行うことで、セキュリティモデルの進化が容易になります。

### 軽減策

**MCPサーバーは、明示的にMCPサーバー用に発行されたトークン以外を受け入れてはなりません**

- **認可ロジックの見直しと強化:** MCPサーバーの認可実装を慎重に監査し、意図したユーザーとクライアントだけが機密リソースにアクセスできるようにしてください。実践的なガイダンスは[Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)や[Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)を参照してください。
- **セキュアなトークン管理の徹底:** [Microsoftのトークン検証と有効期限に関するベストプラクティス](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)に従い、アクセストークンの不正使用やリプレイ、盗難リスクを軽減してください。
- **トークン保管の保護:** トークンは常に安全に保管し、保存時と転送時の暗号化を実施してください。実装のヒントは[Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)を参照してください。

# MCPサーバーの過剰な権限

### 問題提起
MCPサーバーがアクセスするサービスやリソースに対して過剰な権限が付与されている場合があります。例えば、AI営業アプリケーションの一部として企業データストアに接続するMCPサーバーは、営業データに限定したアクセス権を持つべきであり、ストア内のすべてのファイルにアクセスできてはなりません。最小権限の原則（最も古くからあるセキュリティ原則の一つ）に立ち返ると、リソースはその実行に必要な最小限の権限以上を持つべきではありません。AIは柔軟性を持たせるために必要な正確な権限を定義するのが難しいため、この分野での課題が増しています。

### リスク
- 過剰な権限を付与すると、本来アクセスすべきでないデータの流出や改ざんが可能になり、個人を特定できる情報（PII）であればプライバシー問題にもつながります。

### 軽減策
- **最小権限の原則を適用する:** MCPサーバーに必要最低限の権限だけを付与し、定期的に権限を見直して必要以上に拡大していないことを確認してください。詳細は[Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)を参照。
- **ロールベースアクセス制御（RBAC）の活用:** MCPサーバーに特定のリソースや操作に限定された役割を割り当て、広範囲または不要な権限を避けます。
- **権限の監視と監査:** 権限の使用状況を継続的に監視し、アクセスログを監査して過剰または未使用の権限を速やかに特定・是正します。

# 間接的なプロンプトインジェクション攻撃

### 問題提起

悪意ある、または侵害されたMCPサーバーは、顧客データの漏洩や意図しない動作を引き起こす重大なリスクをもたらします。これは特にAIおよびMCPベースのワークロードで重要であり、以下のような攻撃が含まれます：

- **プロンプトインジェクション攻撃**：攻撃者がプロンプトや外部コンテンツに悪意のある指示を埋め込み、AIシステムに意図しない動作や機密データの漏洩を引き起こさせます。詳細はこちら：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **ツールポイズニング**：攻撃者がツールのメタデータ（説明やパラメーターなど）を操作し、AIの挙動に影響を与え、セキュリティコントロールを回避したりデータを流出させたりします。詳細はこちら：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **クロスドメインプロンプトインジェクション**：悪意のある指示がドキュメント、ウェブページ、メールなどに埋め込まれ、それがAIに処理されてデータ漏洩や操作につながります。
- **動的ツール変更（ラグプル）**：ユーザー承認後にツール定義が変更され、新たな悪意ある挙動がユーザーの気づかないうちに導入される可能性があります。

これらの脆弱性は、MCPサーバーやツールを環境に統合する際に堅牢な検証、監視、セキュリティコントロールが必要であることを示しています。詳細は上記のリンクを参照してください。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ja.png)

**間接的プロンプトインジェクション**（別名クロスドメインプロンプトインジェクション、XPIA）は、Model Context Protocol（MCP）を含む生成AIシステムにおける重大な脆弱性です。この攻撃では、悪意のある指示がドキュメント、ウェブページ、メールなどの外部コンテンツに隠されます。AIシステムがこれらのコンテンツを処理すると、埋め込まれた指示を正当なユーザーコマンドとして解釈し、データ漏洩、有害コンテンツの生成、ユーザーインタラクションの操作など意図しない動作を引き起こすことがあります。詳細な説明や実例は[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)を参照してください。

特に危険な形態が**ツールポイズニング**です。ここでは、攻撃者がMCPツールのメタデータ（ツール説明やパラメーターなど）に悪意のある指示を注入します。大規模言語モデル（LLM）はこのメタデータを基にどのツールを呼び出すか判断するため、改ざんされた説明によって不正なツール呼び出しやセキュリティコントロールの回避が行われる可能性があります。これらの操作はエンドユーザーには見えませんが、AIシステムは解釈し実行します。このリスクは、ユーザー承認後にツール定義が変更されるホスト型MCPサーバー環境で特に高まります。このような状況は「[ラグプル](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」と呼ばれ、安全だったツールが後に悪意のある動作を行うよう改変されることがあります。詳細は[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)を参照してください。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ja.png)

## リスク
意図しないAIの動作は、データ流出やプライバシー侵害など様々なセキュリティリスクを伴います。

### 軽減策
### 間接的プロンプトインジェクション攻撃から守るためのPrompt Shieldsの活用
-----------------------------------------------------------------------------

**AI Prompt Shields**は、Microsoftが開発した、直接的および間接的なプロンプトインジェクション攻撃から防御するためのソリューションです。以下の方法で支援します：

1.  **検出とフィルタリング**：Prompt Shieldsは高度な機械学習アルゴリズムと自然言語処理を用いて、ドキュメント、ウェブページ、メールなどの外部
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoftにおけるソフトウェアサプライチェーンのセキュリティ強化への道のり](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [最小権限アクセスのセキュリティ確保 (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [トークン検証と有効期限のベストプラクティス](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [安全なトークンストレージとトークンの暗号化の利用 (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [MCPの認証ゲートウェイとしてのAzure API Management](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCPセキュリティベストプラクティス](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Microsoft Entra IDを使ったMCPサーバー認証](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 次へ

次へ: [第3章: はじめに](/03-GettingStarted/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご了承ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。