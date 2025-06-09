<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:10:54+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "tw"
}
-->
# Security Best Practices

安全對於 MCP 實作來說非常重要，尤其是在企業環境中。確保工具和資料免於未經授權的存取、資料外洩以及其他安全威脅是關鍵。

## Introduction

在這堂課中，我們將探討 MCP 實作的安全最佳做法。我們會涵蓋驗證與授權、資料保護、安全的工具執行，以及遵守資料隱私法規。

## Learning Objectives

完成本課後，你將能夠：

- 為 MCP 伺服器實作安全的驗證與授權機制。
- 使用加密和安全儲存保護敏感資料。
- 透過適當的存取控制確保工具的安全執行。
- 應用資料保護和隱私合規的最佳實踐。

## Authentication and Authorization

驗證與授權是保護 MCP 伺服器安全的基礎。驗證回答「你是誰？」這個問題，而授權回答「你能做什麼？」。

接下來我們看如何使用 .NET 和 Java 在 MCP 伺服器中實作安全的驗證與授權。

### .NET Identity Integration

ASP .NET Core Identity 提供強大的框架來管理使用者的驗證與授權。我們可以將它整合到 MCP 伺服器，保護工具和資源的存取。

整合 ASP.NET Core Identity 與 MCP 伺服器時，有幾個核心概念需要理解：

- **Identity Configuration**：設定 ASP.NET Core Identity，包含使用者角色和聲明。聲明是關於使用者的資訊，比如角色或權限，例如「Admin」或「User」。
- **JWT Authentication**：使用 JSON Web Tokens (JWT) 來安全存取 API。JWT 是一種標準，能以 JSON 物件形式安全傳遞資訊，且因為有數位簽章，可被驗證和信任。
- **Authorization Policies**：定義授權政策，根據使用者角色控制對特定工具的存取。MCP 利用授權政策判斷哪些使用者可根據角色和聲明存取哪些工具。

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

- 設定了 ASP.NET Core Identity 來管理使用者。
- 配置了 JWT 驗證，確保 API 安全存取。我們指定了令牌驗證參數，包括發行者、受眾和簽署金鑰。
- 定義授權政策以根據使用者角色控制工具存取。例如「CanUseAdminTools」政策要求使用者具有「Admin」角色，而「CanUseBasic」政策則要求使用者已通過驗證。
- 註冊了具有特定授權要求的 MCP 工具，確保只有具適當角色的使用者才能存取。

### Java Spring Security Integration

在 Java 端，我們將使用 Spring Security 來實作 MCP 伺服器的安全驗證與授權。Spring Security 提供完整的安全框架，能無縫整合 Spring 應用程式。

這裡的核心概念包括：

- **Spring Security Configuration**：設定驗證與授權的安全配置。
- **OAuth2 Resource Server**：使用 OAuth2 來安全存取 MCP 工具。OAuth2 是一個授權框架，允許第三方服務交換存取令牌以安全存取 API。
- **Security Interceptors**：實作安全攔截器，強制執行工具執行的存取控制。
- **Role-Based Access Control**：利用角色控制對特定工具和資源的存取。
- **Security Annotations**：使用註解來保護方法和端點。

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

- 配置 Spring Security 來保護 MCP 端點，允許工具發現公開存取，但執行工具時需要驗證。
- 使用 OAuth2 作為資源伺服器，處理對 MCP 工具的安全存取。
- 實作安全攔截器，執行工具執行的存取控制，檢查使用者角色和權限，確保存取特定工具前符合要求。
- 定義基於角色的存取控制，限制管理工具和敏感資料的存取權限。

## Data Protection and Privacy

資料保護對確保敏感資訊安全處理至關重要。這包括保護個人識別資訊 (PII)、財務資料及其他敏感資訊，避免未經授權的存取和外洩。

### Python Data Protection Example

以下範例展示如何在 Python 中使用加密與 PII 偵測來實作資料保護。

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
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`，確保它能安全處理敏感資料。

## What's next

- [Web search](../web-search-mcp/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於翻譯的準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。