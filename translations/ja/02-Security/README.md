<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:57:19+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ja"
}
-->
# Security Best Practices

Model Context Protocol (MCP)の採用はAI駆動アプリケーションに強力な新機能をもたらしますが、従来のソフトウェアリスクを超える独自のセキュリティ課題も生じます。安全なコーディング、最小権限、サプライチェーンセキュリティといった既存の懸念に加え、MCPやAIワークロードはプロンプトインジェクション、ツールポイズニング、動的ツール変更など新たな脅威に直面しています。これらのリスクは適切に管理されなければ、データの流出やプライバシー侵害、意図しないシステム動作を引き起こす可能性があります。

本レッスンでは、認証、認可、過剰な権限、間接的なプロンプトインジェクション、サプライチェーンの脆弱性など、MCPに関連する主要なセキュリティリスクを解説し、それらを軽減するための実践的な対策とベストプラクティスを紹介します。また、MicrosoftのPrompt Shields、Azure Content Safety、GitHub Advanced Securityなどのソリューションを活用してMCPの実装を強化する方法も学びます。これらの対策を理解し適用することで、セキュリティ侵害の可能性を大幅に減らし、AIシステムの堅牢性と信頼性を確保できます。

# Learning Objectives

このレッスンの終了時には、以下ができるようになります：

- Model Context Protocol (MCP)がもたらす独自のセキュリティリスク（プロンプトインジェクション、ツールポイズニング、過剰な権限、サプライチェーンの脆弱性など）を特定し説明できる。
- 強固な認証、最小権限、セキュアなトークン管理、サプライチェーン検証など、MCPのセキュリティリスクに対する効果的な緩和策を理解し適用できる。
- MicrosoftのPrompt Shields、Azure Content Safety、GitHub Advanced Securityなどのソリューションを活用し、MCPやAIワークロードを保護できる。
- ツールのメタデータ検証、動的変更の監視、間接的なプロンプトインジェクション攻撃への防御の重要性を認識できる。
- 安全なコーディング、サーバーハードニング、ゼロトラストアーキテクチャなどの確立されたセキュリティベストプラクティスをMCP実装に統合し、セキュリティ侵害の可能性と影響を軽減できる。

# MCP security controls

重要なリソースにアクセスするシステムには必然的にセキュリティ上の課題があります。これらの課題は基本的なセキュリティコントロールと概念を正しく適用することで一般的に対処可能です。MCPは新しく定義されたプロトコルであり、その仕様は急速に変化しているため、プロトコルの進化に伴いセキュリティコントロールも成熟し、企業の既存セキュリティアーキテクチャやベストプラクティスとより良く統合されるようになるでしょう。

[Microsoft Digital Defense Report](https://aka.ms/mddr)によると、報告された侵害の98％は堅牢なセキュリティ衛生管理によって防止可能であり、どのような侵害に対しても最良の防御は基本的なセキュリティ衛生、セキュアなコーディングベストプラクティス、サプライチェーンセキュリティを正しく実施することだと述べられています。これらの確立された手法は依然としてセキュリティリスクを減らす上で最も効果的です。

MCP採用時にセキュリティリスクに対処するためのいくつかの方法を見ていきましょう。

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** 以下の情報は2025年4月26日時点の内容です。MCPプロトコルは継続的に進化しており、将来的な実装では新しい認証パターンやコントロールが導入される可能性があります。最新の情報やガイダンスについては、常に[MCP Specification](https://spec.modelcontextprotocol.io/)および公式の[MCP GitHubリポジトリ](https://github.com/modelcontextprotocol)を参照してください。

### Problem statement  
初期のMCP仕様では、開発者が独自に認証サーバーを構築することが前提とされていました。これにはOAuthや関連するセキュリティ制約の知識が必要でした。MCPサーバーはOAuth 2.0認可サーバーとして機能し、Microsoft Entra IDのような外部サービスに認証を委任するのではなく、ユーザー認証を直接管理していました。2025年4月26日時点の仕様更新により、MCPサーバーはユーザー認証を外部サービスに委任できるようになりました。

### Risks
- MCPサーバーの認可ロジックの誤設定により、機密データの漏洩や誤ったアクセス制御が発生する可能性があります。
- ローカルのMCPサーバー上でOAuthトークンが盗まれると、そのトークンを使ってMCPサーバーを偽装し、トークン対象サービスのリソースやデータにアクセスされる恐れがあります。

### Mitigating controls
- **認可ロジックのレビューと強化:** MCPサーバーの認可実装を慎重に監査し、意図したユーザーとクライアントのみが機密リソースにアクセスできるようにしてください。実践的なガイダンスは[Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)および[Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)を参照してください。
- **セキュアなトークン管理の徹底:** [Microsoftのトークン検証と有効期限に関するベストプラクティス](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)に従い、アクセストークンの誤用を防ぎ、トークンのリプレイや盗難リスクを低減してください。
- **トークンの安全な保管:** トークンは常に安全に保管し、保存時および転送時に暗号化を利用してください。実装のヒントは[Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)を参照してください。

# Excessive permissions for MCP servers

### Problem statement  
MCPサーバーに対してアクセスするサービスやリソースに過剰な権限が付与されている場合があります。例えば、企業のデータストアに接続するAI営業アプリケーションのMCPサーバーは、営業データへのアクセスに限定されるべきであり、ストア内のすべてのファイルにアクセスできる権限を持つべきではありません。最小権限の原則（最も古いセキュリティ原則の一つ）に立ち返ると、リソースは必要なタスクを実行するために必要な権限を超えて許可されるべきではありません。AIの場合、柔軟性を持たせるために必要な正確な権限の定義が難しいという課題が増えています。

### Risks  
- 過剰な権限を付与すると、MCPサーバーがアクセスするべきでないデータの持ち出しや改ざんが可能になり得ます。特に個人を特定できる情報（PII）であればプライバシー問題にもつながります。

### Mitigating controls
- **最小権限の原則を適用:** MCPサーバーには必要最低限の権限のみを付与し、定期的に権限を見直して不要な権限がないか確認してください。詳細は[Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)を参照してください。
- **ロールベースアクセス制御（RBAC）の活用:** MCPサーバーに対しては、特定のリソースやアクションに厳密にスコープされたロールを割り当て、広範または不必要な権限を避けてください。
- **権限の監視と監査:** 権限の使用状況を継続的に監視し、アクセスログを監査して過剰または未使用の権限を速やかに検出・是正してください。

# Indirect prompt injection attacks

### Problem statement

悪意のある、または侵害されたMCPサーバーは、顧客データの漏洩や意図しない操作を引き起こす重大なリスクをもたらします。これらのリスクは特にAIやMCPベースのワークロードにおいて重要です。具体的には：

- **プロンプトインジェクション攻撃:** 攻撃者がプロンプトや外部コンテンツに悪意のある指示を埋め込み、AIシステムが意図しない操作を行ったり機密データを漏洩したりします。詳細はこちら：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **ツールポイズニング:** 攻撃者がツールのメタデータ（説明やパラメータなど）を操作し、AIの挙動に影響を与え、セキュリティコントロールを回避したりデータを持ち出したりします。詳細はこちら：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **クロスドメインプロンプトインジェクション:** 悪意のある指示が文書、ウェブページ、メールに埋め込まれ、それがAIに処理されてデータ漏洩や操作を引き起こします。
- **動的ツール変更（Rug Pulls）:** ユーザーの承認後にツール定義が変更され、新たな悪意ある挙動がユーザーの知らないうちに導入される可能性があります。

これらの脆弱性は、MCPサーバーやツールを環境に統合する際に厳密な検証、監視、セキュリティコントロールが必要であることを示しています。詳細は上記のリンクを参照してください。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ja.png)

**間接的プロンプトインジェクション**（別名クロスドメインプロンプトインジェクション、XPIA）は、Model Context Protocol (MCP)を含む生成AIシステムにおける重大な脆弱性です。この攻撃では、悪意のある指示が文書、ウェブページ、メールなどの外部コンテンツに隠されており、AIシステムがこれらを処理すると、埋め込まれた指示を正当なユーザーコマンドとして解釈し、データ漏洩、有害コンテンツの生成、ユーザーインタラクションの操作などの意図しない動作を引き起こします。詳細な説明と実例は[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)を参照してください。

特に危険なのが**ツールポイズニング**です。攻撃者はMCPツールのメタデータ（ツールの説明やパラメータ）に悪意のある指示を注入します。大規模言語モデル（LLM）はこれらのメタデータを基にどのツールを呼び出すか判断するため、改ざんされた説明により不正なツール呼び出しやセキュリティコントロールの回避が起こり得ます。これらの操作はエンドユーザーには見えにくいですが、AIシステムは解釈して実行してしまいます。ホスト型MCPサーバー環境では、ユーザー承認後にツール定義が更新されることがあり、これは「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」と呼ばれます。この場合、以前は安全だったツールが後に悪意ある動作を行うよう変更され、ユーザーの知らないうちにデータ持ち出しやシステム挙動の改変が行われる可能性があります。この攻撃手法の詳細は[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)を参照してください。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ja.png)

## Risks
意図しないAIの動作は、データ流出やプライバシー侵害など多様なセキュリティリスクをもたらします。

### Mitigating controls
### Using prompt shields to protect against Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

**AI Prompt Shields**は、Microsoftが開発した直接および間接のプロンプトインジェクション攻撃から守るためのソリューションです。以下の機能で支援します：

1.  **検出とフィルタリング:** Prompt Shieldsは高度な機械学習アルゴリズムと自然言語処理を用い、文書、ウェブページ、メールなどの外部コンテンツに埋め込まれた悪意のある指示を検出・除去します。
    
2.  **スポットライティング:** この技術はAIシステムが有効なシステム指示と潜在的に信頼できない外部入力を区別できるようにします。入力テキストをモデルにとってより関連性の高い形に変換し、悪意ある指示を識別し無視しやすくします。
    
3.  **デリミタとデータマーキング:** システムメッセージにデリミタを含めることで、入力テキストの位置を明示し、AIがユーザー入力と潜在的に有害な外部コンテンツを区別できるようにします。データマーキングは特別なマーカーを使い、信頼できるデータと信頼できないデータの境界を強調します。
    
4.  **継続的な監視と更新:** MicrosoftはPrompt Shieldsを継続的に監視・更新し、新たな脅威に対応します。この先手のアプローチにより、最新の攻撃手法に対しても効果的な防御が維持されます。
    
5. **Azure Content Safetyとの統合:** Prompt ShieldsはAzure AI Content Safetyスイートの一部であり、脱獄検出、有害コンテンツ、その他AIアプリケーションのセキュリティリスク検出のための追加ツールを提供します。

AI Prompt Shieldsの詳細は[Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)をご覧ください。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ja.png)

### Supply chain security

AI時代においてもサプライチェーンセキュリティは基本的な重要性を持ちますが、その範囲は拡大しています。従来のコードパッケージに加え、ファウンデーションモデル、埋め込みサービス、コンテキストプロバイダー、サードパーティAPIなど、AI関連のすべてのコンポーネントを厳密に検証・監視する必要があります。これらのいずれも適切に管理されなければ脆弱性やリスクをもたらします。

**AIおよびMCPにおける主要なサプライチェーンセキュリティ対策：**
- **統合前にすべてのコンポーネントを検証:** オープンソースライブラリだけでなく、AIモデル、データソース、外部APIも含め、出所、ライセンス、既知の脆弱性を必ず確認してください。
- **安全なデプロイパイプラインの維持:** セキュリティスキャンを組み込んだ自動CI/CDパイプラインを使い、問題を早期に検出してください。信頼できる成果物のみ
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 次へ

次へ: [第3章: はじめに](/03-GettingStarted/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文はあくまで正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。