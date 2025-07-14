<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:36:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "mo"
}
-->
# 安全最佳實務

安全對於 MCP 實作至關重要，尤其是在企業環境中。確保工具和資料免於未經授權的存取、資料外洩及其他安全威脅是非常重要的。

## 介紹

在本課程中，我們將探討 MCP 實作的安全最佳實務。我們會涵蓋身份驗證與授權、資料保護、安全的工具執行，以及遵守資料隱私法規。

## 學習目標

完成本課程後，您將能夠：

- 為 MCP 伺服器實作安全的身份驗證與授權機制。
- 使用加密和安全儲存保護敏感資料。
- 透過適當的存取控制確保工具的安全執行。
- 應用資料保護與隱私合規的最佳實務。

## 身份驗證與授權

身份驗證與授權是保護 MCP 伺服器安全的關鍵。身份驗證回答「你是誰？」的問題，而授權則回答「你能做什麼？」。

讓我們來看看如何使用 .NET 和 Java 在 MCP 伺服器中實作安全的身份驗證與授權。

### .NET 身份整合

ASP .NET Core Identity 提供了一個強大的框架來管理使用者身份驗證與授權。我們可以將它整合到 MCP 伺服器中，以保護工具和資源的存取。

整合 ASP.NET Core Identity 與 MCP 伺服器時，有幾個核心概念需要了解：

- **Identity 配置**：設定 ASP.NET Core Identity，包含使用者角色和聲明。聲明是關於使用者的一項資訊，例如其角色或權限，如「Admin」或「User」。
- **JWT 身份驗證**：使用 JSON Web Tokens (JWT) 來實現安全的 API 存取。JWT 是一種標準，用於在雙方之間以 JSON 物件安全傳輸資訊，因為它是數位簽章的，可以被驗證和信任。
- **授權政策**：定義政策以根據使用者角色控制對特定工具的存取。MCP 使用授權政策來決定哪些使用者可以根據其角色和聲明存取哪些工具。

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

在上述程式碼中，我們：

- 配置了 ASP.NET Core Identity 以管理使用者。
- 設定了 JWT 身份驗證以確保 API 的安全存取，指定了令牌驗證參數，包括發行者、受眾和簽名金鑰。
- 定義了授權政策，根據使用者角色控制工具存取。例如，「CanUseAdminTools」政策要求使用者擁有「Admin」角色，而「CanUseBasic」政策則要求使用者已通過身份驗證。
- 註冊了具有特定授權需求的 MCP 工具，確保只有擁有適當角色的使用者才能存取。

### Java Spring Security 整合

對於 Java，我們將使用 Spring Security 來實作 MCP 伺服器的安全身份驗證與授權。Spring Security 提供了一個完整的安全框架，能與 Spring 應用程式無縫整合。

這裡的核心概念包括：

- **Spring Security 配置**：設定身份驗證與授權的安全配置。
- **OAuth2 資源伺服器**：使用 OAuth2 來安全存取 MCP 工具。OAuth2 是一個授權框架，允許第三方服務交換存取令牌以安全存取 API。
- **安全攔截器**：實作安全攔截器以強制執行工具執行的存取控制。
- **基於角色的存取控制**：使用角色來控制對特定工具和資源的存取。
- **安全註解**：使用註解來保護方法和端點。

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

在上述程式碼中，我們：

- 配置了 Spring Security 以保護 MCP 端點，允許公開存取工具發現功能，但執行工具時需要身份驗證。
- 使用 OAuth2 作為資源伺服器來處理 MCP 工具的安全存取。
- 實作了安全攔截器，在允許存取特定工具前檢查使用者角色和權限。
- 定義了基於角色的存取控制，限制對管理工具和敏感資料的存取。

## 資料保護與隱私

資料保護對於確保敏感資訊的安全處理至關重要。這包括保護個人識別資訊 (PII)、財務資料及其他敏感資訊，避免未經授權的存取和外洩。

### Python 資料保護範例

讓我們來看一個如何使用加密和 PII 偵測在 Python 中實作資料保護的範例。

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

在上述程式碼中，我們：

- 實作了 `PiiDetector` 類別，用於掃描文字和參數中的個人識別資訊 (PII)。
- 建立了 `EncryptionService` 類別，使用 `cryptography` 函式庫來處理敏感資料的加密與解密。
- 定義了 `secure_tool` 裝飾器，包裹工具執行流程以檢查 PII、記錄存取並在需要時加密敏感資料。
- 將 `secure_tool` 裝飾器應用於範例工具 (`SecureCustomerDataTool`)，確保其安全處理敏感資料。

## 接下來的內容

- [5.9 Web search](../web-search-mcp/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。