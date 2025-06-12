<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T21:28:53+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "hk"
}
-->
# Security Best Practices

安全對於 MCP 實施來說至關重要，特別是在企業環境中。確保工具和數據免受未經授權的訪問、數據洩露及其他安全威脅非常重要。

## Introduction

在本課程中，我們會探討 MCP 實施的安全最佳做法。內容包括身份驗證與授權、數據保護、安全工具執行，以及遵守數據私隱法規。

## Learning Objectives

完成本課程後，你將能夠：

- 為 MCP 伺服器實施安全的身份驗證與授權機制。
- 使用加密和安全存儲保護敏感數據。
- 確保工具在適當的訪問控制下安全執行。
- 應用數據保護及私隱合規的最佳實踐。

## Authentication and Authorization

身份驗證和授權是保障 MCP 伺服器安全的基石。身份驗證回答「你係邊個？」而授權回答「你可以做啲乜嘢？」。

以下會示範點樣用 .NET 同 Java 去實現 MCP 伺服器嘅安全身份驗證同授權。

### .NET Identity Integration

ASP .NET Core Identity 提供強大嘅框架管理用戶身份驗證同授權。我哋可以將佢整合入 MCP 伺服器，保障工具同資源嘅訪問安全。

整合 ASP.NET Core Identity 同 MCP 伺服器時，有幾個核心概念要明：

- **Identity Configuration**：設定 ASP.NET Core Identity，包含用戶角色同聲明。聲明係關於用戶嘅一啲資料，例如佢哋嘅角色或者權限，例如「Admin」或者「User」。
- **JWT Authentication**：用 JSON Web Tokens (JWT) 保障 API 訪問安全。JWT 係一種標準，用嚟安全傳輸雙方之間嘅資料，因為佢有數碼簽名，資料可信。
- **Authorization Policies**：定義政策控制用戶根據角色訪問特定工具。MCP 用授權政策判斷用戶基於角色同聲明可以訪問邊啲工具。

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

喺上面嘅代碼中，我哋：

- 配置咗 ASP.NET Core Identity 用嚟管理用戶。
- 設定咗 JWT 身份驗證保障 API 訪問安全，包含發行者、受眾同簽名金鑰嘅驗證參數。
- 定義咗授權政策控制用戶角色訪問工具，例如「CanUseAdminTools」政策要求用戶具備「Admin」角色，而「CanUseBasic」政策要求用戶已身份驗證。
- 為 MCP 工具註冊咗特定授權要求，確保只有擁有適當角色嘅用戶先能訪問。

### Java Spring Security Integration

Java 方面，我哋會用 Spring Security 去實現 MCP 伺服器嘅安全身份驗證同授權。Spring Security 提供全面嘅安全框架，能夠無縫整合入 Spring 應用。

核心概念包括：

- **Spring Security Configuration**：設定身份驗證同授權嘅安全配置。
- **OAuth2 Resource Server**：用 OAuth2 保障 MCP 工具嘅安全訪問。OAuth2 係一個授權框架，容許第三方服務用訪問令牌安全地訪問 API。
- **Security Interceptors**：實現安全攔截器，執行工具時強制執行訪問控制。
- **Role-Based Access Control**：用角色控制訪問特定工具同資源。
- **Security Annotations**：用註解保障方法同端點安全。

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

喺上面嘅代碼中，我哋：

- 配置咗 Spring Security 去保障 MCP 端點安全，容許公開訪問工具發現功能，但執行工具時需要身份驗證。
- 用 OAuth2 作為資源伺服器處理 MCP 工具嘅安全訪問。
- 實現咗安全攔截器，喺執行工具前檢查用戶角色同權限，強制執行訪問控制。
- 定義咗基於角色嘅訪問控制，限制訪問管理員工具同敏感數據。

## Data Protection and Privacy

數據保護對確保敏感資訊安全處理至關重要。包括保護個人身份信息（PII）、財務數據及其他敏感資料，避免未經授權訪問及洩露。

### Python Data Protection Example

以下係用 Python 實現數據保護嘅例子，包括加密同 PII 偵測。

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

喺上面嘅代碼中，我哋：

- 實現咗 `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`，確保佢安全處理敏感數據。

## What's next

- [5.9 Web search](../web-search-mcp/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。因使用本翻譯而引致嘅任何誤解或誤釋，我哋概不負責。