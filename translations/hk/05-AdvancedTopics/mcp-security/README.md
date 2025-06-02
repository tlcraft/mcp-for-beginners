<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:10:40+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "hk"
}
-->
# Security Best Practices

安全對於 MCP 實施至關重要，尤其是在企業環境中。確保工具和數據免受未經授權的訪問、數據洩露及其他安全威脅非常重要。

## Introduction

在本課程中，我們會探討 MCP 實施的安全最佳實踐，包括身份驗證和授權、數據保護、安全工具執行，以及遵守數據隱私法規。

## Learning Objectives

完成本課程後，你將能夠：

- 為 MCP 伺服器實現安全的身份驗證和授權機制。
- 利用加密和安全存儲保護敏感數據。
- 確保工具在適當訪問控制下安全執行。
- 應用數據保護和隱私合規的最佳實踐。

## Authentication and Authorization

身份驗證和授權是保護 MCP 伺服器的關鍵。身份驗證回答「你是誰？」，授權則回答「你可以做什麼？」。

以下示範如何在 MCP 伺服器中，利用 .NET 和 Java 實現安全的身份驗證和授權。

### .NET Identity Integration

ASP .NET Core Identity 提供了管理用戶身份驗證和授權的強大框架。我們可以將它整合到 MCP 伺服器中，保障工具和資源的訪問安全。

整合 ASP.NET Core Identity 與 MCP 伺服器時，有幾個核心概念需要了解：

- **Identity Configuration**：設定 ASP.NET Core Identity，包含用戶角色和聲明。聲明是關於用戶的一項資訊，例如角色或權限，如「Admin」或「User」。
- **JWT Authentication**：使用 JSON Web Tokens (JWT) 進行安全的 API 訪問。JWT 是一種以 JSON 物件安全傳輸資訊的標準，因為它有數碼簽名，可以驗證及信任。
- **Authorization Policies**：定義政策以根據用戶角色控制對特定工具的訪問。MCP 利用授權政策決定用戶可否基於角色和聲明訪問相應工具。

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

- 配置了 ASP.NET Core Identity 以管理用戶。
- 設置了 JWT 身份驗證以保障 API 訪問安全，指定了令牌驗證參數，包括發行者、受眾和簽名密鑰。
- 定義了授權政策，根據用戶角色控制工具訪問。例如，「CanUseAdminTools」政策要求用戶具備「Admin」角色，而「CanUseBasic」政策則要求用戶已通過身份驗證。
- 為 MCP 工具註冊了具體授權要求，確保只有具備相應角色的用戶能訪問。

### Java Spring Security Integration

對於 Java，我們會使用 Spring Security 來實現 MCP 伺服器的安全身份驗證和授權。Spring Security 提供全面的安全框架，能無縫整合到 Spring 應用中。

這裡的核心概念包括：

- **Spring Security Configuration**：設定身份驗證和授權的安全配置。
- **OAuth2 Resource Server**：使用 OAuth2 保障對 MCP 工具的安全訪問。OAuth2 是一種授權框架，允許第三方服務交換存取令牌以安全訪問 API。
- **Security Interceptors**：實作安全攔截器，強制執行工具執行的訪問控制。
- **Role-Based Access Control**：利用角色控制對特定工具和資源的訪問。
- **Security Annotations**：使用註解保護方法和端點。

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

- 配置了 Spring Security 以保障 MCP 端點安全，允許公開訪問工具發現，但執行工具時需要身份驗證。
- 使用 OAuth2 作為資源伺服器，處理 MCP 工具的安全訪問。
- 實現安全攔截器，執行工具訪問控制，根據用戶角色和權限檢查後才允許訪問特定工具。
- 定義基於角色的訪問控制，限制對管理工具和敏感數據的訪問。

## Data Protection and Privacy

數據保護對於確保敏感資訊的安全處理非常重要，包括防止未經授權訪問和洩露個人身份信息 (PII)、財務數據及其他敏感資訊。

### Python Data Protection Example

以下示範如何在 Python 中利用加密和 PII 偵測實現數據保護。

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

- 實作了 `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`，確保敏感數據得到安全處理。

## What's next

- [Web search](../web-search-mcp/README.md)

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋負責。