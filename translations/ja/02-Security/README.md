<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T16:17:32+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ja"
}
-->
# セキュリティのベストプラクティス

Model Context Protocol（MCP）を採用することで、AI駆動のアプリケーションに強力な新機能がもたらされますが、従来のソフトウェアリスクを超えた独自のセキュリティ課題も生じます。安全なコーディング、最小権限、サプライチェーンセキュリティといった既存の懸念に加え、MCPやAIワークロードはプロンプトインジェクション、ツールポイズニング、動的ツール変更などの新たな脅威に直面しています。これらのリスクは適切に管理されなければ、データの流出、プライバシー侵害、意図しないシステム動作を引き起こす可能性があります。

本レッスンでは、MCPに関連する最も重要なセキュリティリスク（認証、認可、過剰な権限、間接的なプロンプトインジェクション、サプライチェーンの脆弱性）を取り上げ、それらを軽減するための実践的な対策とベストプラクティスを紹介します。また、Prompt Shields、Azure Content Safety、GitHub Advanced SecurityなどのMicrosoftソリューションを活用してMCPの実装を強化する方法も学びます。これらの対策を理解し適用することで、セキュリティ侵害の可能性を大幅に減らし、AIシステムの堅牢性と信頼性を確保できます。

# 学習目標

このレッスンの終了時には、以下ができるようになります：

- Model Context Protocol（MCP）がもたらす独自のセキュリティリスク（プロンプトインジェクション、ツールポイズニング、過剰な権限、サプライチェーンの脆弱性）を特定し説明する。
- 強固な認証、最小権限、セキュアなトークン管理、サプライチェーン検証など、MCPのセキュリティリスクに対する効果的な緩和策を説明し適用する。
- Prompt Shields、Azure Content Safety、GitHub Advanced SecurityなどのMicrosoftソリューションを理解し、MCPおよびAIワークロードの保護に活用する。
- ツールのメタデータ検証、動的変更の監視、間接的なプロンプトインジェクション攻撃への防御の重要性を認識する。
- セキュアコーディング、サーバーハードニング、ゼロトラストアーキテクチャなどの確立されたセキュリティベストプラクティスをMCP実装に統合し、セキュリティ侵害の発生率と影響を低減する。

# MCPのセキュリティコントロール

重要なリソースにアクセスするシステムには、暗黙のセキュリティ課題があります。これらの課題は、基本的なセキュリティコントロールと概念を正しく適用することで一般的に対処可能です。MCPはまだ新しく定義されたばかりであり、仕様は急速に変化し続けています。プロトコルが進化するにつれて、セキュリティコントロールも成熟し、企業の既存のセキュリティアーキテクチャやベストプラクティスとの統合がより良くなっていくでしょう。

[Microsoft Digital Defense Report](https://aka.ms/mddr) によると、報告された侵害の98％は堅牢なセキュリティ衛生管理によって防止可能であり、あらゆる侵害に対する最良の防御は、基礎となるセキュリティ衛生管理、セキュアコーディングのベストプラクティス、サプライチェーンセキュリティを正しく実施することだと述べられています。これらの既知の実践が依然としてセキュリティリスク軽減に最も効果的です。

MCPを採用する際にセキュリティリスクに対処するためのいくつかの方法を見ていきましょう。

> **Note:** 以下の情報は**2025年5月29日**時点で正確です。MCPプロトコルは継続的に進化しており、将来的な実装では新たな認証パターンやコントロールが導入される可能性があります。最新の情報とガイダンスについては、常に[MCP Specification](https://spec.modelcontextprotocol.io/)および公式の[MCP GitHubリポジトリ](https://github.com/modelcontextprotocol)、[セキュリティベストプラクティスページ](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)を参照してください。

### 問題の概要  
元のMCP仕様では、開発者が独自の認証サーバーを構築することを前提としていました。これにはOAuthや関連するセキュリティ制約の知識が必要でした。MCPサーバーはOAuth 2.0の認可サーバーとして機能し、Microsoft Entra IDのような外部サービスに委任するのではなく、ユーザー認証を直接管理していました。2025年4月26日付のMCP仕様の更新により、MCPサーバーはユーザー認証を外部サービスに委任できるようになりました。

### リスク
- MCPサーバーの認可ロジックの誤設定により、機密データの漏洩や誤ったアクセス制御が発生する可能性があります。
- ローカルのMCPサーバーでOAuthトークンが盗まれた場合、そのトークンを使ってMCPサーバーを偽装し、トークンが対象とするサービスのリソースやデータにアクセスされる恐れがあります。

#### トークンパススルー
トークンパススルーは認可仕様で明確に禁止されています。これは以下のような複数のセキュリティリスクを引き起こすためです。

#### セキュリティコントロールの回避
MCPサーバーや下流のAPIは、トークンのオーディエンスやその他の認証情報に依存して、レート制限、リクエスト検証、トラフィック監視などの重要なセキュリティコントロールを実装している場合があります。クライアントがMCPサーバーの適切な検証なしに直接下流APIのトークンを取得・使用できると、これらのコントロールを回避してしまいます。

#### 責任追跡と監査の問題
クライアントが上流で発行されたアクセス・トークンを使って呼び出す場合、MCPサーバーはクライアントを識別・区別できません。  
下流のリソースサーバーのログには、実際にトークンを転送しているMCPサーバーではなく、異なるソースや異なるIDからのリクエストとして記録される可能性があります。  
これらはインシデント調査やコントロール、監査を困難にします。  
MCPサーバーがトークンのクレーム（役割、権限、オーディエンスなど）やその他のメタデータを検証せずにトークンを転送すると、盗まれたトークンを持つ悪意のある者がサーバーをデータ流出のプロキシとして利用できてしまいます。

#### 信頼境界の問題
下流のリソースサーバーは特定のエンティティに信頼を与えています。この信頼には発信元やクライアントの振る舞いパターンに関する前提が含まれることがあります。この信頼境界が破られると予期せぬ問題が発生する可能性があります。  
トークンが適切に検証されずに複数のサービスで受け入れられると、1つのサービスが侵害された場合に、そのトークンを使って他の連携サービスにもアクセスされる恐れがあります。

#### 将来の互換性リスク
たとえ現在MCPサーバーが「純粋なプロキシ」として動作していても、将来的にセキュリティコントロールを追加する必要が出てくるかもしれません。最初から適切なトークンオーディエンスの分離を行うことで、セキュリティモデルの進化が容易になります。

### 緩和策

**MCPサーバーは、明示的にMCPサーバー向けに発行されていないトークンを受け入れてはなりません**

- **認可ロジックの見直しと強化:** MCPサーバーの認可実装を慎重に監査し、意図したユーザーとクライアントのみが機密リソースにアクセスできるようにしてください。実践的なガイダンスは[Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)や[Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)を参照してください。
- **安全なトークン運用の徹底:** [Microsoftのトークン検証と有効期限に関するベストプラクティス](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)に従い、アクセス・トークンの誤用やリプレイ、盗難リスクを低減してください。
- **トークン保管の保護:** トークンは常に安全に保管し、保存時および転送時に暗号化を使用してください。実装のヒントは[Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)をご覧ください。

# MCPサーバーの過剰な権限

### 問題の概要
MCPサーバーに対して、アクセスするサービスやリソースに対して過剰な権限が付与されている場合があります。例えば、企業のデータストアに接続するAI営業アプリケーションの一部であるMCPサーバーは、営業データに限定したアクセス権を持つべきであり、ストア内のすべてのファイルにアクセスできてはなりません。最小権限の原則（最も古いセキュリティ原則の一つ）に立ち返ると、リソースはその目的を遂行するために必要な権限を超えて権限を持つべきではありません。AIは柔軟性を持たせるために必要な正確な権限を定義するのが難しいため、この点で特に課題が大きくなります。

### リスク  
- 過剰な権限を付与すると、MCPサーバーがアクセスすべきでないデータの流出や改ざんが可能になり得ます。個人を特定できる情報（PII）が含まれる場合はプライバシー問題にもなります。

### 緩和策
- **最小権限の原則を適用する:** MCPサーバーには必要最低限の権限のみを付与し、定期的にこれらの権限を見直して不要な権限が付与されていないか確認してください。詳細は[Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)を参照してください。
- **ロールベースアクセス制御（RBAC）を利用する:** MCPサーバーに対して、特定のリソースや操作に厳密にスコープされたロールを割り当て、広範囲または不要な権限を避けてください。
- **権限の監視と監査:** 権限の使用状況を継続的に監視し、アクセスログを監査して過剰または未使用の権限を速やかに検出・是正してください。

# 間接的なプロンプトインジェクション攻撃

### 問題の概要

悪意のある、または侵害されたMCPサーバーは、顧客データの漏洩や意図しない操作を引き起こす重大なリスクをもたらします。これらのリスクは特にAIおよびMCPベースのワークロードで顕著であり、以下のような攻撃が含まれます：

- **プロンプトインジェクション攻撃**：攻撃者がプロンプトや外部コンテンツに悪意のある指示を埋め込み、AIシステムに意図しない操作をさせたり機密データを漏洩させたりします。詳細はこちら：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **ツールポイズニング**：攻撃者がツールのメタデータ（説明やパラメーターなど）を操作し、AIの挙動に影響を与え、セキュリティコントロールを回避したりデータを流出させたりします。詳細はこちら：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **クロスドメインプロンプトインジェクション**：悪意のある指示が文書、ウェブページ、メールなどに埋め込まれ、AIがそれらを処理することでデータ漏洩や操作が発生します。
- **動的ツール変更（ラグプル）**：ユーザーの承認後にツール定義が変更され、新たな悪意ある動作がユーザーの知らないうちに導入されることがあります。

これらの脆弱性は、MCPサーバーやツールを環境に統合する際に、堅牢な検証、監視、セキュリティコントロールが必要であることを示しています。詳細は上記のリンクを参照してください。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ja.png)

**間接的プロンプトインジェクション**（別名クロスドメインプロンプトインジェクション、XPIA）は、Model Context Protocol（MCP）を含む生成AIシステムにおける重大な脆弱性です。この攻撃では、悪意のある指示が文書、ウェブページ、メールなどの外部コンテンツに隠されます。AIシステムがこれらのコンテンツを処理すると、埋め込まれた指示を正当なユーザーコマンドとして解釈し、データ漏洩、有害コンテンツの生成、ユーザー操作の改ざんなどの意図しない動作を引き起こします。詳細な説明と実例は[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)をご覧ください。

特に危険な形態が**ツールポイズニング**です。ここでは、攻撃者がMCPツールのメタデータ（ツールの説明やパラメーターなど）に悪意のある指示を注入します。大規模言語モデル（LLM）はこのメタデータを基にどのツールを呼び出すか判断するため、改ざんされた説明により不正なツール呼び出しやセキュリティコントロールの回避が起こり得ます。これらの操作はエンドユーザーには見えませんが、AIシステムは解釈して実行してしまいます。このリスクは、ユーザー承認後にツール定義が更新可能なホスト型MCPサーバー環境で特に高まります。これは「[ラグプル](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」と呼ばれることもあり、以前は安全だったツールが後から悪意ある動作に変更され、ユーザーの知らないうちにデータ流出やシステム挙動の改変が行われる可能性があります。この攻撃ベクターの詳細は[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)を参照してください。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ja.png)

## リスク
意図しないAIの動作は、データ流出やプライバシー侵害など多様なセキュリティリスクをもたらします。

### 緩和策
### 間接的プロンプトインジェクション攻撃から守るためのPrompt Shields
サプライチェーンのセキュリティはAI時代においても依然として重要ですが、サプライチェーンの範囲は拡大しています。従来のコードパッケージに加え、基盤モデル、埋め込みサービス、コンテキストプロバイダー、サードパーティAPIなど、すべてのAI関連コンポーネントを厳密に検証・監視する必要があります。これらの各要素は、適切に管理されなければ脆弱性やリスクをもたらす可能性があります。

**AIおよびMCPにおける主要なサプライチェーンセキュリティの実践例：**
- **統合前にすべてのコンポーネントを検証すること：** オープンソースライブラリだけでなく、AIモデル、データソース、外部APIも含まれます。出所、ライセンス、既知の脆弱性を必ず確認してください。
- **安全なデプロイパイプラインを維持すること：** セキュリティスキャンを組み込んだ自動CI/CDパイプラインを使用し、問題を早期に検出します。信頼できる成果物のみを本番環境にデプロイするようにしてください。
- **継続的な監視と監査を行うこと：** モデルやデータサービスを含むすべての依存関係に対して継続的な監視を実施し、新たな脆弱性やサプライチェーン攻撃を検出します。
- **最小権限とアクセス制御を適用すること：** MCPサーバーの機能に必要な範囲に限定して、モデル、データ、サービスへのアクセスを制限してください。
- **脅威に迅速に対応すること：** 侵害が検出された場合に、影響を受けたコンポーネントのパッチ適用や交換、シークレットや認証情報のローテーションを行うプロセスを用意しておきましょう。

[GitHub Advanced Security](https://github.com/security/advanced-security) は、シークレットスキャン、依存関係スキャン、CodeQL解析などの機能を提供しています。これらのツールは[Azure DevOps](https://azure.microsoft.com/en-us/products/devops)や[Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/)と連携し、コードおよびAIサプライチェーンの両方にわたる脆弱性の特定と軽減を支援します。

Microsoftもすべての製品に対して社内で広範なサプライチェーンセキュリティ対策を実施しています。詳細は[The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)をご覧ください。


# MCP実装のセキュリティ体制を強化するための確立されたベストプラクティス

MCPの実装は、その基盤となる組織の環境の既存のセキュリティ体制を引き継ぐため、MCPをAIシステム全体の一部として考慮する際には、既存のセキュリティ体制の強化を検討することが推奨されます。特に以下の確立されたセキュリティコントロールが重要です：

- AIアプリケーションにおける安全なコーディングのベストプラクティス — [OWASP Top 10](https://owasp.org/www-project-top-ten/)や[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)に対する防御、シークレットやトークンの安全な保管、すべてのアプリケーションコンポーネント間のエンドツーエンドの安全な通信の実装など。
- サーバーの強化 — 可能な限りMFAを使用し、パッチを最新に保ち、アクセスにはサードパーティのIDプロバイダーを統合するなど。
- デバイス、インフラストラクチャ、アプリケーションのパッチ適用を常に最新に保つこと。
- セキュリティ監視 — AIアプリケーション（MCPクライアント/サーバーを含む）のログ取得と監視を実施し、異常な活動を検出するために中央のSIEMにログを送信すること。
- ゼロトラストアーキテクチャ — ネットワークおよびID制御を用いてコンポーネントを論理的に分離し、AIアプリケーションが侵害された場合の横移動を最小限に抑えること。

# 重要なポイント

- セキュリティの基本は依然として重要です：安全なコーディング、最小権限、サプライチェーンの検証、継続的な監視はMCPおよびAIワークロードに不可欠です。
- MCPはプロンプトインジェクション、ツールポイズニング、過剰な権限などの新たなリスクをもたらし、従来の対策に加えAI特有のコントロールも必要です。
- 強力な認証、認可、トークン管理の実践を行い、可能な限りMicrosoft Entra IDなどの外部IDプロバイダーを活用してください。
- ツールのメタデータ検証、動的変化の監視、Microsoft Prompt Shieldsのようなソリューションを用いて、間接的なプロンプトインジェクションやツールポイズニングから保護しましょう。
- モデル、埋め込み、コンテキストプロバイダーを含むAIサプライチェーンのすべてのコンポーネントを、コード依存関係と同じ厳格さで扱ってください。
- 進化するMCP仕様に常に追随し、コミュニティに貢献して安全な標準の形成を支援しましょう。

# 追加リソース

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 次へ

次へ: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。