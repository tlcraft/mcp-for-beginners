<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:42:14+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "ja"
}
-->
# Security Best Practices

Model Context Protocol (MCP) を採用することで、AI駆動のアプリケーションに強力な新機能がもたらされますが、従来のソフトウェアリスクを超える独自のセキュリティ課題も生じます。安全なコーディング、最小権限、サプライチェーンセキュリティといった既存の懸念に加え、MCPやAIワークロードではプロンプトインジェクション、ツールポイズニング、動的ツール変更といった新たな脅威に直面します。これらのリスクは適切に管理されないと、データ流出、プライバシー侵害、意図しないシステム動作につながる可能性があります。

本レッスンでは、MCPに関連する最も重要なセキュリティリスク（認証、認可、過剰な権限、間接的なプロンプトインジェクション、サプライチェーンの脆弱性）を取り上げ、それらを軽減するための実践的な対策やベストプラクティスを紹介します。また、MicrosoftのPrompt Shields、Azure Content Safety、GitHub Advanced Securityといったソリューションを活用してMCPの実装を強化する方法も学びます。これらの対策を理解し適用することで、セキュリティ侵害の可能性を大幅に減らし、AIシステムの堅牢性と信頼性を確保できます。

# Learning Objectives

このレッスンの終了時には、以下ができるようになります：

- Model Context Protocol (MCP) によってもたらされる独自のセキュリティリスク（プロンプトインジェクション、ツールポイズニング、過剰権限、サプライチェーンの脆弱性）を特定し説明する。
- MCPのセキュリティリスクに対する効果的な軽減策（強固な認証、最小権限、セキュアなトークン管理、サプライチェーン検証）を理解し適用する。
- MicrosoftのPrompt Shields、Azure Content Safety、GitHub Advanced Securityなどのソリューションを活用して、MCPとAIワークロードを保護する方法を理解する。
- ツールのメタデータ検証、動的変更の監視、間接的なプロンプトインジェクション攻撃への防御の重要性を認識する。
- 安全なコーディング、サーバーハードニング、ゼロトラストアーキテクチャなどの確立されたセキュリティベストプラクティスをMCP実装に統合し、セキュリティ侵害の可能性と影響を低減する。

# MCP security controls

重要なリソースにアクセスできるシステムには暗黙のセキュリティ課題があります。これらの課題は基本的なセキュリティコントロールや概念を正しく適用することで一般的に対処可能です。MCPは新たに定義されたばかりで、仕様は急速に変化しており、プロトコルの進化に伴いセキュリティコントロールも成熟していきます。最終的には、企業の既存セキュリティアーキテクチャやベストプラクティスとより良く統合できるようになるでしょう。

[Microsoft Digital Defense Report](https://aka.ms/mddr) によると、報告された侵害の98％は堅牢なセキュリティ衛生状態によって防止可能であり、どんな侵害に対しても最良の防御は基礎的なセキュリティ衛生、セキュアコーディングベストプラクティス、サプライチェーンセキュリティを確実に実施することです。これらの既知の実践が最も効果的にリスクを減らします。

MCPを採用する際にセキュリティリスクに対処するためのいくつかの方法を見ていきましょう。

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** 以下の情報は2025年4月26日時点の正確な内容です。MCPプロトコルは継続的に進化しており、将来的な実装では新たな認証パターンやコントロールが導入される可能性があります。最新情報やガイダンスは常に[MCP Specification](https://spec.modelcontextprotocol.io/)および公式[MCP GitHubリポジトリ](https://github.com/modelcontextprotocol)を参照してください。

### Problem statement  
初期のMCP仕様では、開発者が独自に認証サーバーを構築することを前提としていました。これにはOAuthや関連するセキュリティ制約の知識が必要でした。MCPサーバーはOAuth 2.0の認可サーバーとして機能し、Microsoft Entra IDのような外部サービスに委任するのではなく、ユーザー認証を直接管理していました。2025年4月26日以降のMCP仕様の更新により、MCPサーバーがユーザー認証を外部サービスに委任できるようになりました。

### Risks
- MCPサーバーの認可ロジックの誤設定により、機密データの漏洩やアクセス制御の誤適用が発生する可能性があります。
- ローカルのMCPサーバーでOAuthトークンが盗まれるリスク。盗まれたトークンはMCPサーバーを偽装し、トークンが対象とするサービスのリソースやデータにアクセスするために悪用される恐れがあります。

### Mitigating controls
- **認可ロジックの見直しと強化：** MCPサーバーの認可実装を綿密に監査し、意図したユーザーとクライアントのみが機密リソースにアクセスできるようにします。実践的なガイダンスは[Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)や[Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)を参照してください。
- **セキュアなトークン運用の徹底：** [Microsoftのトークン検証と有効期限に関するベストプラクティス](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)を遵守し、アクセス・トークンの不正使用やリプレイ、盗難リスクを軽減します。
- **トークン保管の保護：** トークンは常に安全に保管し、保存時および転送時に暗号化を施します。実装のヒントは[Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)をご覧ください。

# Excessive permissions for MCP servers

### Problem statement  
MCPサーバーに対して、アクセス先のサービスやリソースに対して過剰な権限が付与されている可能性があります。例えば、企業のデータストアに接続するAI営業アプリケーションの一部であるMCPサーバーは、営業データへのアクセスに限定されるべきであり、ストア内のすべてのファイルにアクセスできてはなりません。最小権限の原則（最も古くからあるセキュリティ原則の一つ）に立ち返ると、リソースは必要なタスクを実行するために必要な権限を超えて権限を持つべきではありません。AIは柔軟性を持たせる必要があるため、必要な正確な権限を定義するのが難しいという課題が増えています。

### Risks  
- 過剰な権限が付与されると、MCPサーバーがアクセスすべきでないデータの流出や改ざんを許してしまう可能性があります。特に個人識別情報（PII）が含まれる場合はプライバシー問題にもなりえます。

### Mitigating controls
- **最小権限の原則を適用する：** MCPサーバーに必要最低限の権限のみを付与し、定期的に権限を見直して必要以上になっていないか確認します。詳細は[Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)を参照してください。
- **ロールベースアクセス制御（RBAC）の活用：** MCPサーバーに特定のリソースやアクションに厳密にスコープされたロールを割り当て、広範囲や不必要な権限を避けます。
- **権限の監視と監査：** 権限の使用状況を継続的に監視し、アクセスログを監査して過剰または未使用の権限を速やかに検出し対応します。

# Indirect prompt injection attacks

### Problem statement

悪意のある、あるいは侵害されたMCPサーバーは、顧客データの漏洩や意図しない動作を引き起こす重大なリスクをもたらします。これは特にAIやMCPベースのワークロードで顕著です：

- **プロンプトインジェクション攻撃**：攻撃者がプロンプトや外部コンテンツに悪意ある命令を埋め込み、AIシステムが意図しない動作をしたり機密データを漏洩させたりします。詳細はこちら：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **ツールポイズニング**：攻撃者がツールのメタデータ（説明やパラメーターなど）を操作し、AIの挙動に影響を与え、セキュリティ制御を回避したりデータを流出させたりします。詳細：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **クロスドメインプロンプトインジェクション**：悪意ある命令がドキュメント、ウェブページ、メールに埋め込まれ、それがAIに処理されてデータ漏洩や改ざんが起こります。
- **動的ツール変更（ラグプル）**：ユーザー承認後にツール定義が変更され、新たな悪意ある動作がユーザーの知らないうちに追加されることがあります。

これらの脆弱性は、MCPサーバーやツールを環境に統合する際に堅牢な検証、監視、セキュリティコントロールが必要であることを示しています。詳細は上記のリンクを参照してください。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ja.png)

**間接的プロンプトインジェクション**（クロスドメインプロンプトインジェクション、XPIAとも呼ばれる）は、Model Context Protocol (MCP) を含む生成AIシステムにおける重大な脆弱性です。この攻撃では、悪意ある命令がドキュメント、ウェブページ、メールなどの外部コンテンツに隠されます。AIシステムがこれらのコンテンツを処理する際に、その命令を正当なユーザーコマンドとして誤解し、データ漏洩、有害コンテンツ生成、ユーザー操作の改ざんといった意図しない動作を引き起こします。詳細な説明や実例は[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)を参照してください。

特に危険なのが**ツールポイズニング**です。攻撃者がMCPツールのメタデータ（説明やパラメーターなど）に悪意ある命令を注入します。大規模言語モデル（LLM）はこのメタデータを基にどのツールを呼び出すかを判断するため、改ざんされた説明によりモデルが不正なツール呼び出しやセキュリティ制御の回避をしてしまう可能性があります。これらの操作はエンドユーザーには見えませんが、AIシステムは解釈して実行します。ホスト型MCPサーバー環境では、ユーザー承認後にツール定義が変更されることがあり、これを「ラグプル」と呼びます。この場合、以前は安全だったツールが後に悪意ある動作（データ流出やシステム動作の改変など）を行うように変更される恐れがあります。攻撃ベクトルの詳細は[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)をご覧ください。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ja.png)

## Risks  
意図しないAIの動作は、データ流出やプライバシー侵害など多様なセキュリティリスクをもたらします。

### Mitigating controls  
### 間接的プロンプトインジェクション攻撃から守るためのPrompt Shieldsの活用
-----------------------------------------------------------------------------

**AI Prompt Shields** は、Microsoftが開発した直接的・間接的なプロンプトインジェクション攻撃から防御するためのソリューションです。以下の方法で支援します：

1.  **検出とフィルタリング**：Prompt Shieldsは高度な機械学習アルゴリズムと自然言語処理を用いて、ドキュメントやウェブページ、メールなど外部コンテンツに埋め込まれた悪意ある命令を検出し除去します。
    
2.  **スポットライティング**：この技術によりAIシステムは正当なシステム命令と潜在的に信頼できない外部入力を区別できます。入力テキストをモデルにとってより関連性の高い形に変換することで、悪意ある命令を識別し無視しやすくします。
    
3.  **区切り文字とデータマーキング**：システムメッセージに区切り文字を含めることで、AIが入力テキストの位置を明確に認識し、ユーザー入力と潜在的に有害な外部コンテンツを分離します。データマーキングはこれを拡張し、信頼されたデータと信頼されていないデータの境界を特別なマーカーで示します。
    
4.  **継続的な監視と更新**：MicrosoftはPrompt Shieldsを継続的に監視・更新し、新たかつ進化する脅威に対応しています。この積極的な取り組みにより、最新の攻撃手法に対しても効果的な防御を維持します。
    
5.  **Azure Content Safetyとの統合**：Prompt ShieldsはAzure AI Content Safetyスイートの一部であり、脱獄検出、有害コンテンツ、その他AIアプリケーションのセキュリティリスク検出のための追加ツールを提供します。

AI Prompt Shieldsの詳細は[Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)をご覧ください。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ja.png)

### Supply chain security

AI時代においてもサプライチェーンセキュリティは依然として基本的な重要事項ですが、サプライチェーンの範囲は拡大しています。従来のコードパッケージに加え、基盤モデル、埋め込みサービス、コンテキストプロバイダー、サードパーティAPIなど、AI関連のあらゆるコンポーネントを厳密に検証・監視する必要があります。これらのいずれも適切に管理されなければ脆弱性やリスクをもたらす可能性があります。

**AIとMCPにおけるサプライチェーンセキュリティの主要な実践例：**  
- **統合前の全コンポーネント検証：** オープンソースライブラリだけでなく、AIモデル、データソース、外部APIも含め、出所、ライセンス、既知の脆弱性を必ず確認します。  
- **安全なデプロイパイプラインの維持：** セキュリティスキャンを統合した自動化されたCI/CDパイプラインを使用し、問題を早期に検出します。信頼できる成果物のみを本番環境にデプロイするよう
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoftにおけるソフトウェアサプライチェーンのセキュリティ強化への道のり](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [最小権限アクセスのセキュリティ確保 (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [トークン検証と有効期限のベストプラクティス](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [安全なトークンストレージとトークンの暗号化の利用 (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [MCP向け認証ゲートウェイとしてのAzure API Management](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra IDを使ったMCPサーバー認証](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 次へ

次へ: [第3章: はじめに](/03-GettingStarted/README.md)

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文はその言語における正本として扱われるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。