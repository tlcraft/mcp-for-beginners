<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T21:35:13+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ja"
}
-->
# セキュリティのベストプラクティス

セキュリティは、特に企業環境におけるMCP実装において非常に重要です。ツールやデータが不正アクセス、データ漏洩、その他のセキュリティ脅威から保護されていることを確実にする必要があります。

## はじめに

Model Context Protocol（MCP）は、LLMにデータやツールへのアクセスを提供する役割を持つため、特定のセキュリティ上の配慮が求められます。本レッスンでは、公式のMCPガイドラインと確立されたセキュリティパターンに基づくMCP実装のセキュリティベストプラクティスを紹介します。

MCPは安全で信頼できるやり取りを保証するために、以下の主要なセキュリティ原則に従っています：

- **ユーザーの同意とコントロール**：データへのアクセスや操作を行う前に、ユーザーの明示的な同意が必要です。どのデータが共有され、どの操作が許可されているかを明確にコントロールできるようにします。
  
- **データプライバシー**：ユーザーデータは明示的な同意がある場合にのみ公開され、適切なアクセス制御によって保護されなければなりません。不正なデータ送信を防ぎます。
  
- **ツールの安全性**：ツールを呼び出す前に明示的なユーザー同意が必要です。ユーザーは各ツールの機能を明確に理解し、強固なセキュリティ境界が適用される必要があります。

## 学習目標

このレッスンを終える頃には、以下ができるようになります：

- MCPサーバーのための安全な認証と認可の仕組みを実装する。
- 暗号化と安全なストレージを用いて機密データを保護する。
- 適切なアクセス制御を用いてツールの安全な実行を保証する。
- データ保護とプライバシー遵守のベストプラクティスを適用する。
- 混乱代理問題、トークンパススルー、セッションハイジャックなど、一般的なMCPのセキュリティ脆弱性を特定し軽減する。

## 認証と認可

認証と認可はMCPサーバーのセキュリティ確保に不可欠です。認証は「あなたは誰ですか？」に答え、認可は「何ができますか？」に答えます。

MCPセキュリティ仕様によると、以下が重要なセキュリティ上の考慮点です：

1. **トークン検証**：MCPサーバーは、明示的にMCPサーバー用に発行されていないトークンを受け入れてはなりません。「トークンパススルー」は明確に禁止されたアンチパターンです。

2. **認可の検証**：認可を実装するMCPサーバーは、すべての受信リクエストを検証し、認証にセッションを使用してはなりません。

3. **安全なセッション管理**：状態管理にセッションを使用する場合、MCPサーバーは安全な乱数生成器で生成された非決定論的なセッションIDを使用しなければなりません。セッションIDはユーザー固有の情報に紐付けるべきです。

4. **明示的なユーザー同意**：プロキシサーバーの場合、MCP実装は動的に登録された各クライアントについて、第三者認可サーバーに転送する前にユーザーの同意を得なければなりません。

次に、.NETとJavaを使ったMCPサーバーでの安全な認証と認可の実装例を見てみましょう。

### .NET Identity 統合

ASP .NET Core Identityは、ユーザー認証と認可を管理するための堅牢なフレームワークを提供します。これをMCPサーバーに統合して、ツールやリソースへのアクセスを保護できます。

ASP.NET Core IdentityをMCPサーバーに統合する際に理解すべき主な概念は以下の通りです：

- **Identityの設定**：ユーザーロールやクレームを用いたASP.NET Core Identityのセットアップ。クレームとは、ユーザーに関する情報の一部で、例えば「Admin」や「User」といった役割や権限を示します。
- **JWT認証**：安全なAPIアクセスのためのJSON Web Token（JWT）の使用。JWTは、デジタル署名により検証可能で信頼できるJSON形式の情報を安全に送信する標準です。
- **認可ポリシー**：ユーザーロールに基づいて特定のツールへのアクセスを制御するポリシーの定義。MCPは、ユーザーのロールやクレームに基づいてどのユーザーがどのツールにアクセスできるかを判断するために認可ポリシーを使用します。

```csharp
public class SecureMcpStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add ASP.NET Core Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        // Configure JWT authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });
        
        // Add authorization policies
        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanUseAdminTools", policy =>
                policy.RequireRole("Admin"));
                
            options.AddPolicy("CanUseBasicTools", policy =>
                policy.RequireAuthenticatedUser());
        });
        
        // Configure MCP server with security
        services.AddMcpServer(options =>
        {
            options.ServerName = "Secure MCP Server";
            options.ServerVersion = "1.0.0";
            options.RequireAuthentication = true;
        });
        
        // Register tools with authorization requirements
        services.AddMcpTool<BasicTool>(options => 
            options.RequirePolicy("CanUseBasicTools"));
            
        services.AddMcpTool<AdminTool>(options => 
            options.RequirePolicy("CanUseAdminTools"));
    }
    
    public void Configure(IApplicationBuilder app)
    {
        // Use authentication and authorization
        app.UseAuthentication();
        app.UseAuthorization();
        
        // Use MCP server middleware
        app.UseMcpServer();
    }
}
```

上記コードでは以下を行っています：

- ユーザー管理のためにASP.NET Core Identityを設定。
- 安全なAPIアクセスのためにJWT認証を設定。発行者、受信者、署名キーなどのトークン検証パラメータを指定。
- ユーザーロールに基づいてツールへのアクセスを制御する認可ポリシーを定義。例えば、「CanUseAdminTools」ポリシーは「Admin」ロールを持つユーザーにのみ許可し、「CanUseBasic」ポリシーは認証済みユーザーに適用。
- 適切なロールを持つユーザーのみがアクセスできるように、特定の認可要件を持つMCPツールを登録。

### Java Spring Security 統合

Javaでは、Spring Securityを使ってMCPサーバーの安全な認証と認可を実装します。Spring SecurityはSpringアプリケーションとシームレスに統合できる包括的なセキュリティフレームワークです。

主な概念は以下の通りです：

- **Spring Securityの設定**：認証と認可のためのセキュリティ設定。
- **OAuth2リソースサーバー**：MCPツールへの安全なアクセスのためにOAuth2を使用。OAuth2は第三者サービスがアクセストークンを交換して安全にAPIアクセスを行うための認可フレームワークです。
- **セキュリティインターセプター**：ツール実行時のアクセス制御を強制するためのインターセプターの実装。
- **ロールベースアクセス制御**：特定のツールやリソースへのアクセスをロールで制御。
- **セキュリティアノテーション**：メソッドやエンドポイントを保護するためのアノテーションの使用。

```java
@Configuration
@EnableWebSecurity
public class SecurityConfig extends WebSecurityConfigurerAdapter {

    @Override
    protected void configure(HttpSecurity http) throws Exception {
        http
            .csrf().disable()
            .authorizeRequests()
                .antMatchers("/mcp/discovery").permitAll() // Allow tool discovery
                .antMatchers("/mcp/tools/**").hasAnyRole("USER", "ADMIN") // Require authentication for tools
                .antMatchers("/mcp/admin/**").hasRole("ADMIN") // Admin-only endpoints
                .anyRequest().authenticated()
            .and()
            .oauth2ResourceServer().jwt();
    }
    
    @Bean
    public McpSecurityInterceptor mcpSecurityInterceptor() {
        return new McpSecurityInterceptor();
    }
}

// MCP Security Interceptor for tool authorization
public class McpSecurityInterceptor implements ToolExecutionInterceptor {
    @Autowired
    private JwtDecoder jwtDecoder;
    
    @Override
    public void beforeToolExecution(ToolRequest request, Authentication authentication) {
        String toolName = request.getToolName();
        
        // Check if user has permissions for this tool
        if (toolName.startsWith("admin") && !authentication.getAuthorities().contains("ROLE_ADMIN")) {
            throw new AccessDeniedException("You don't have permission to use this tool");
        }
        
        // Additional security checks based on tool or parameters
        if ("sensitiveDataAccess".equals(toolName)) {
            validateDataAccessPermissions(request, authentication);
        }
    }
    
    private void validateDataAccessPermissions(ToolRequest request, Authentication auth) {
        // Implementation to check fine-grained data access permissions
    }
}
```

上記コードでは以下を行っています：

- MCPエンドポイントを保護するためにSpring Securityを設定し、ツールの検出は公開アクセス可能にしつつ、ツール実行には認証を要求。
- MCPツールへの安全なアクセスを処理するためにOAuth2をリソースサーバーとして使用。
- ツール実行時のアクセス制御を強制するセキュリティインターセプターを実装し、特定ツールへのアクセス前にユーザーロールと権限をチェック。
- 管理ツールや機密データアクセスをユーザーロールに基づいて制限するロールベースアクセス制御を定義。

## データ保護とプライバシー

データ保護は、機密情報が安全に取り扱われることを保証するために重要です。これには、個人識別情報（PII）、財務データ、その他の機密情報を不正アクセスや漏洩から守ることが含まれます。

### Pythonによるデータ保護の例

暗号化とPII検出を用いてPythonでデータ保護を実装する例を見てみましょう。

```python
from mcp_server import McpServer
from mcp_tools import Tool, ToolRequest, ToolResponse
from cryptography.fernet import Fernet
import os
import json
from functools import wraps

# PII Detector - identifies and protects sensitive information
class PiiDetector:
    def __init__(self):
        # Load patterns for different types of PII
        with open("pii_patterns.json", "r") as f:
            self.patterns = json.load(f)
    
    def scan_text(self, text):
        """Scans text for PII and returns detected PII types"""
        detected_pii = []
        # Implementation to detect PII using regex or ML models
        return detected_pii
    
    def scan_parameters(self, parameters):
        """Scans request parameters for PII"""
        detected_pii = []
        for key, value in parameters.items():
            if isinstance(value, str):
                pii_in_value = self.scan_text(value)
                if pii_in_value:
                    detected_pii.append((key, pii_in_value))
        return detected_pii

# Encryption Service for protecting sensitive data
class EncryptionService:
    def __init__(self, key_path=None):
        if key_path and os.path.exists(key_path):
            with open(key_path, "rb") as key_file:
                self.key = key_file.read()
        else:
            self.key = Fernet.generate_key()
            if key_path:
                with open(key_path, "wb") as key_file:
                    key_file.write(self.key)
        
        self.cipher = Fernet(self.key)
    
    def encrypt(self, data):
        """Encrypt data"""
        if isinstance(data, str):
            return self.cipher.encrypt(data.encode()).decode()
        else:
            return self.cipher.encrypt(json.dumps(data).encode()).decode()
    
    def decrypt(self, encrypted_data):
        """Decrypt data"""
        if encrypted_data is None:
            return None
        
        decrypted = self.cipher.decrypt(encrypted_data.encode())
        try:
            return json.loads(decrypted)
        except:
            return decrypted.decode()

# Security decorator for tools
def secure_tool(requires_encryption=False, log_access=True):
    def decorator(cls):
        original_execute = cls.execute_async if hasattr(cls, 'execute_async') else cls.execute
        
        @wraps(original_execute)
        async def secure_execute(self, request):
            # Check for PII in request
            pii_detector = PiiDetector()
            pii_found = pii_detector.scan_parameters(request.parameters)
            
            # Log access if required
            if log_access:
                tool_name = self.get_name()
                user_id = request.context.get("user_id", "anonymous")
                log_entry = {
                    "timestamp": datetime.now().isoformat(),
                    "tool": tool_name,
                    "user": user_id,
                    "contains_pii": bool(pii_found),
                    "parameters": {k: "***" for k in request.parameters.keys()}  # Don't log actual values
                }
                logging.info(f"Tool access: {json.dumps(log_entry)}")
            
            # Handle detected PII
            if pii_found:
                # Either encrypt sensitive data or reject the request
                if requires_encryption:
                    encryption_service = EncryptionService("keys/tool_key.key")
                    for param_name, pii_types in pii_found:
                        # Encrypt the sensitive parameter
                        request.parameters[param_name] = encryption_service.encrypt(
                            request.parameters[param_name]
                        )
                else:
                    # If encryption not available but PII found, you might reject the request
                    raise ToolExecutionException(
                        "Request contains sensitive data that cannot be processed securely"
                    )
            
            # Execute the original method
            return await original_execute(self, request)
        
        # Replace the execute method
        if hasattr(cls, 'execute_async'):
            cls.execute_async = secure_execute
        else:
            cls.execute = secure_execute
        return cls
    
    return decorator

# Example of a secure tool with the decorator
@secure_tool(requires_encryption=True, log_access=True)
class SecureCustomerDataTool(Tool):
    def get_name(self):
        return "customerData"
    
    def get_description(self):
        return "Accesses customer data securely"
    
    def get_schema(self):
        # Schema definition
        return {}
    
    async def execute_async(self, request):
        # Implementation would access customer data securely
        # Since we used the decorator, PII is already detected and encrypted
        return ToolResponse(result={"status": "success"})
```

上記コードでは以下を行っています：

- テキストやパラメータ内の個人識別情報（PII）を検出する`PiiDetector`クラスを実装。
- `cryptography`ライブラリを使って機密データの暗号化と復号を行う`EncryptionService`クラスを作成。
- ツール実行をラップし、PIIの検出、アクセスログの記録、必要に応じて機密データの暗号化を行う`secure_tool`デコレーターを定義。
- サンプルツール`SecureCustomerDataTool`に`secure_tool`デコレーターを適用し、機密データを安全に扱うようにした。

## MCP固有のセキュリティリスク

公式のMCPセキュリティドキュメントによると、MCP実装者が注意すべき特定のセキュリティリスクがあります：

### 1. 混乱代理問題（Confused Deputy Problem）

この脆弱性は、MCPサーバーが第三者APIのプロキシとして動作する際に発生し、攻撃者がMCPサーバーとこれらAPI間の信頼関係を悪用する可能性があります。

**軽減策：**
- 静的クライアントIDを使用するMCPプロキシサーバーは、第三者認可サーバーに転送する前に動的に登録された各クライアントについてユーザーの同意を得る必要があります。
- 認可リクエストにはPKCE（Proof Key for Code Exchange）を用いた適切なOAuthフローを実装。
- リダイレクトURIとクライアント識別子を厳密に検証。

### 2. トークンパススルーの脆弱性

トークンパススルーは、MCPサーバーがMCPクライアントから受け取ったトークンがMCPサーバー用に正しく発行されたかを検証せずに、下流のAPIにそのまま渡してしまう場合に発生します。

### リスク
- セキュリティ制御の回避（レート制限やリクエスト検証のバイパス）
- 責任追跡や監査の問題
- 信頼境界の侵害
- 将来的な互換性リスク

**軽減策：**
- MCPサーバーは、明示的にMCPサーバー用に発行されていないトークンを受け入れてはなりません。
- トークンのaudienceクレームを常に検証し、期待されるサービスと一致することを確認。

### 3. セッションハイジャック

これは、不正な第三者がセッションIDを取得し、元のクライアントになりすまして不正な操作を行う可能性がある攻撃です。

**軽減策：**
- 認可を実装するMCPサーバーは、すべての受信リクエストを検証し、認証にセッションを使用してはなりません。
- 安全な乱数生成器で生成された非決定論的なセッションIDを使用。
- セッションIDを`<user_id>:<session_id>`のようにユーザー固有情報に紐付ける。
- 適切なセッションの有効期限とローテーションポリシーを実装。

## MCPの追加セキュリティベストプラクティス

基本的なMCPセキュリティ考慮事項に加え、以下の追加的なセキュリティ対策も検討してください：

- **常にHTTPSを使用**：クライアントとサーバー間の通信を暗号化し、トークンの傍受を防止。
- **ロールベースアクセス制御（RBAC）の実装**：ユーザーが認証されているかだけでなく、何が許可されているかを確認。
- **監視と監査**：すべての認証イベントをログに記録し、不審な活動を検知・対応。
- **レート制限とスロットリングの管理**：指数的バックオフやリトライロジックを実装し、レート制限を適切に処理。
- **安全なトークン保管**：アクセストークンやリフレッシュトークンは、システムの安全なストレージ機構や安全なキー管理サービスを使って保管。
- **API管理の活用**：Azure API Managementなどのサービスを利用すると、認証、認可、レート制限など多くのセキュリティ課題を自動的に処理可能。

## 参考文献

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## 次に進むこと

- [5.9 Web search](../web-search-mcp/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。