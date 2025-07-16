<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T21:04:54+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "tw"
}
-->
# 安全最佳實務

安全對於 MCP 實作至關重要，尤其是在企業環境中。確保工具和資料免於未經授權的存取、資料外洩及其他安全威脅是非常重要的。

## 介紹

Model Context Protocol (MCP) 由於其提供大型語言模型（LLM）存取資料和工具的角色，因此需要特定的安全考量。本課程將根據官方 MCP 指南及既有的安全模式，探討 MCP 實作的安全最佳實務。

MCP 遵循關鍵的安全原則，以確保互動的安全與可信：

- **用戶同意與控制**：在存取任何資料或執行操作前，必須取得用戶明確同意。提供清楚的控制權，讓用戶決定分享哪些資料及授權哪些行為。
  
- **資料隱私**：用戶資料僅能在明確同意下被揭露，並必須透過適當的存取控制加以保護。防止未經授權的資料傳輸。
  
- **工具安全**：在調用任何工具前，必須取得用戶明確同意。用戶應清楚了解每個工具的功能，並強制執行嚴格的安全邊界。

## 學習目標

完成本課程後，您將能夠：

- 為 MCP 伺服器實作安全的身份驗證與授權機制。
- 使用加密與安全儲存保護敏感資料。
- 確保工具執行的安全性，並實施適當的存取控制。
- 應用資料保護與隱私合規的最佳實務。
- 辨識並減輕常見的 MCP 安全漏洞，如 confused deputy 問題、token passthrough 及會話劫持。

## 身份驗證與授權

身份驗證與授權是保護 MCP 伺服器安全的關鍵。身份驗證回答「你是誰？」的問題，而授權回答「你能做什麼？」。

根據 MCP 安全規範，以下是重要的安全考量：

1. **Token 驗證**：MCP 伺服器不得接受未明確為該 MCP 伺服器簽發的任何 token。「Token passthrough」是明確禁止的反模式。

2. **授權驗證**：實作授權的 MCP 伺服器必須驗證所有進入的請求，且不得使用會話作為身份驗證手段。

3. **安全的會話管理**：若使用會話來維持狀態，MCP 伺服器必須使用安全且非決定性的會話 ID，且該 ID 需由安全的隨機數產生器生成。會話 ID 應綁定用戶特定資訊。

4. **明確的用戶同意**：對於代理伺服器，MCP 實作必須在轉發至第三方授權伺服器前，取得用戶對每個動態註冊客戶端的同意。

以下示範如何使用 .NET 與 Java 實作 MCP 伺服器的安全身份驗證與授權。

### .NET 身份整合

ASP .NET Core Identity 提供強大的框架來管理用戶身份驗證與授權。我們可以將其整合到 MCP 伺服器中，以保護工具和資源的存取。

整合 ASP.NET Core Identity 與 MCP 伺服器時需理解的核心概念包括：

- **Identity 配置**：設定 ASP.NET Core Identity，包含用戶角色與聲明。聲明是關於用戶的資訊，例如角色或權限，如「Admin」或「User」。
- **JWT 身份驗證**：使用 JSON Web Tokens (JWT) 來安全存取 API。JWT 是一種以 JSON 物件安全傳輸資訊的標準，因為它經過數位簽章，可被驗證與信任。
- **授權政策**：定義政策以根據用戶角色控制對特定工具的存取。MCP 使用授權政策來決定哪些用戶可根據其角色與聲明存取哪些工具。

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

上述程式碼中，我們：

- 配置了 ASP.NET Core Identity 以管理用戶。
- 設定 JWT 身份驗證以確保 API 存取安全，指定了 token 驗證參數，包括發行者、受眾與簽章金鑰。
- 定義授權政策以根據用戶角色控制工具存取。例如，「CanUseAdminTools」政策要求用戶擁有「Admin」角色，而「CanUseBasic」政策要求用戶已通過身份驗證。
- 註冊 MCP 工具並設定特定授權需求，確保只有具適當角色的用戶能存取。

### Java Spring Security 整合

對於 Java，我們將使用 Spring Security 來實作 MCP 伺服器的安全身份驗證與授權。Spring Security 提供完整的安全框架，能與 Spring 應用無縫整合。

核心概念包括：

- **Spring Security 配置**：設定身份驗證與授權的安全配置。
- **OAuth2 資源伺服器**：使用 OAuth2 來安全存取 MCP 工具。OAuth2 是一種授權框架，允許第三方服務交換存取 token 以安全存取 API。
- **安全攔截器**：實作安全攔截器以強制工具執行的存取控制。
- **基於角色的存取控制**：使用角色來控制對特定工具與資源的存取。
- **安全註解**：使用註解來保護方法與端點。

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

上述程式碼中，我們：

- 配置 Spring Security 以保護 MCP 端點，允許公開存取工具發現，但執行工具時需身份驗證。
- 使用 OAuth2 作為資源伺服器，處理對 MCP 工具的安全存取。
- 實作安全攔截器，在允許存取特定工具前檢查用戶角色與權限。
- 定義基於角色的存取控制，限制對管理工具及敏感資料的存取。

## 資料保護與隱私

資料保護對於確保敏感資訊安全處理至關重要，包括保護個人識別資訊（PII）、財務資料及其他敏感資訊，避免未經授權的存取與外洩。

### Python 資料保護範例

以下示範如何在 Python 中使用加密與 PII 偵測來實作資料保護。

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

上述程式碼中，我們：

- 實作 `PiiDetector` 類別，用於掃描文字與參數中的個人識別資訊（PII）。
- 建立 `EncryptionService` 類別，使用 `cryptography` 函式庫處理敏感資料的加密與解密。
- 定義 `secure_tool` 裝飾器，包裹工具執行流程，檢查 PII、記錄存取並在需要時加密敏感資料。
- 將 `secure_tool` 裝飾器應用於範例工具 (`SecureCustomerDataTool`)，確保其安全處理敏感資料。

## MCP 特定的安全風險

根據官方 MCP 安全文件，MCP 實作者應注意以下特定安全風險：

### 1. Confused Deputy 問題

此漏洞發生於 MCP 伺服器作為第三方 API 代理時，攻擊者可能利用 MCP 伺服器與這些 API 之間的信任關係進行濫用。

**緩解措施：**
- 使用靜態客戶端 ID 的 MCP 代理伺服器，必須在轉發至第三方授權伺服器前，取得用戶對每個動態註冊客戶端的同意。
- 對授權請求實作正確的 OAuth 流程，包含 PKCE（Proof Key for Code Exchange）。
- 嚴格驗證重定向 URI 與客戶端識別碼。

### 2. Token Passthrough 漏洞

Token passthrough 發生在 MCP 伺服器接受 MCP 用戶端的 token，卻未驗證該 token 是否正確簽發給 MCP 伺服器，並將其直接傳遞給下游 API。

### 風險
- 繞過安全控管（如速率限制、請求驗證）
- 責任追蹤與審計問題
- 信任邊界違反
- 未來相容性風險

**緩解措施：**
- MCP 伺服器不得接受未明確簽發給該 MCP 伺服器的 token。
- 始終驗證 token 的受眾聲明，確保與預期服務相符。

### 3. 會話劫持

當未經授權者取得會話 ID 並冒充原始用戶時，可能導致未經授權的操作。

**緩解措施：**
- 實作授權的 MCP 伺服器必須驗證所有進入請求，且不得使用會話作為身份驗證。
- 使用安全且非決定性的會話 ID，由安全隨機數產生器生成。
- 使用類似 `<user_id>:<session_id>` 的格式將會話 ID 綁定至用戶特定資訊。
- 實施適當的會話過期與輪替政策。

## MCP 額外的安全最佳實務

除了核心 MCP 安全考量外，建議實施以下額外安全措施：

- **始終使用 HTTPS**：加密客戶端與伺服器間的通訊，防止 token 被攔截。
- **實作基於角色的存取控制 (RBAC)**：不僅檢查用戶是否已驗證，還要檢查其授權範圍。
- **監控與審計**：記錄所有身份驗證事件，以偵測並回應可疑活動。
- **處理速率限制與節流**：實作指數退避與重試機制，優雅地應對速率限制。
- **安全儲存 token**：使用系統安全儲存機制或安全金鑰管理服務，妥善保存存取 token 與刷新 token。
- **考慮使用 API 管理服務**：如 Azure API Management，可自動處理多項安全議題，包括身份驗證、授權與速率限制。

## 參考資料

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## 接下來的內容

- [5.9 Web search](../web-search-mcp/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。