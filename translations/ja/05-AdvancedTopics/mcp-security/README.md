<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:11:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ja"
}
-->
# セキュリティのベストプラクティス

セキュリティはMCPの実装において非常に重要であり、特に企業環境では欠かせません。ツールやデータが不正アクセスや情報漏洩、その他のセキュリティ脅威から守られていることを確実にすることが重要です。

## はじめに

このレッスンでは、MCPの実装におけるセキュリティのベストプラクティスを学びます。認証と認可、データ保護、安全なツール実行、データプライバシー規制の遵守について取り上げます。

## 学習目標

このレッスンを終える頃には、以下のことができるようになります：

- MCPサーバーのための安全な認証および認可機構を実装する。
- 暗号化と安全なストレージを用いて機密データを保護する。
- 適切なアクセス制御を用いてツールの安全な実行を保証する。
- データ保護とプライバシー遵守のベストプラクティスを適用する。

## 認証と認可

認証と認可はMCPサーバーのセキュリティに欠かせません。認証は「あなたは誰ですか？」という問いに答え、認可は「何ができますか？」に答えます。

ここでは、.NETとJavaを使ってMCPサーバーで安全な認証と認可を実装する例を見ていきましょう。

### .NET Identityの統合

ASP .NET Core Identityはユーザー認証と認可を管理するための堅牢なフレームワークを提供します。これをMCPサーバーに統合してツールやリソースへのアクセスを保護できます。

ASP.NET Core IdentityをMCPサーバーに統合する際に理解しておくべき主要な概念は以下の通りです：

- **Identityの設定**：ユーザーロールやクレームを用いてASP.NET Core Identityを設定します。クレームとはユーザーに関する情報の一部で、例えば「Admin」や「User」といったロールや権限を指します。
- **JWT認証**：JSON Web Tokens（JWT）を使って安全なAPIアクセスを実現します。JWTはデジタル署名により検証可能で信頼できるJSON形式の情報伝達標準です。
- **認可ポリシー**：ユーザーロールに基づいて特定のツールへのアクセスを制御するポリシーを定義します。MCPではユーザーのロールやクレームに基づき、どのツールにアクセス可能かを認可ポリシーで判断します。

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

上記のコードでは以下を行っています：

- ユーザー管理のためにASP.NET Core Identityを設定。
- セキュアなAPIアクセスのためJWT認証を設定。発行者、受信者、署名鍵などのトークン検証パラメーターを指定。
- ユーザーロールに基づきツールへのアクセスを制御する認可ポリシーを定義。例えば「CanUseAdminTools」ポリシーは「Admin」ロールを持つユーザーにのみ許可し、「CanUseBasic」ポリシーは認証済みユーザーに適用。
- MCPツールを特定の認可要件で登録し、適切なロールを持つユーザーだけがアクセスできるようにしています。

### Java Spring Securityの統合

Javaでは、Spring Securityを用いてMCPサーバーの安全な認証と認可を実装します。Spring SecurityはSpringアプリケーションとシームレスに統合できる包括的なセキュリティフレームワークです。

ここでの主要な概念は以下の通りです：

- **Spring Securityの設定**：認証と認可のためのセキュリティ設定を行います。
- **OAuth2リソースサーバー**：OAuth2を使ってMCPツールへの安全なアクセスを実現します。OAuth2はサードパーティサービスがアクセストークンを交換して安全なAPIアクセスを可能にする認可フレームワークです。
- **セキュリティインターセプター**：ツール実行時のアクセス制御を強制するためのインターセプターを実装します。
- **ロールベースアクセス制御**：特定のツールやリソースへのアクセスをロールによって制御します。
- **セキュリティアノテーション**：メソッドやエンドポイントを保護するためにアノテーションを使用します。

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

上記のコードでは以下を行っています：

- Spring Securityを設定し、ツールの探索は公開アクセス可能にしつつ、ツール実行時には認証を必須にしています。
- OAuth2をリソースサーバーとして利用し、MCPツールへの安全なアクセスを管理。
- セキュリティインターセプターを実装し、ツール実行前にユーザーのロールや権限をチェックしてアクセス制御を実施。
- ロールベースアクセス制御を定義し、管理者ツールや機密データへのアクセスをユーザーロールに基づき制限。

## データ保護とプライバシー

データ保護は機密情報を安全に扱うために不可欠です。個人識別情報（PII）、財務データ、その他の機密情報を不正アクセスや漏洩から守ることが含まれます。

### Pythonによるデータ保護の例

Pythonで暗号化とPII検出を用いてデータ保護を実装する例を見てみましょう。

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

上記のコードでは以下を行っています：

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` を実装し、機密データを安全に取り扱うことを保証しています。

## 次に進むには

- [Web search](../web-search-mcp/README.md)

**免責事項**：  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文はあくまで権威ある情報源としてご参照ください。重要な情報については、専門の人間翻訳を推奨いたします。本翻訳の利用により生じたいかなる誤解や解釈違いについても、当方は一切の責任を負いかねます。