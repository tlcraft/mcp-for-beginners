<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:10:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "zh"
}
-->
# 安全最佳实践

安全对于 MCP 实现尤为重要，尤其是在企业环境中。确保工具和数据免受未经授权的访问、数据泄露及其他安全威胁至关重要。

## 介绍

本课将探讨 MCP 实现中的安全最佳实践。内容涵盖身份验证与授权、数据保护、安全工具执行以及数据隐私法规的合规性。

## 学习目标

完成本课后，您将能够：

- 实现 MCP 服务器的安全身份验证和授权机制。
- 使用加密和安全存储保护敏感数据。
- 通过适当的访问控制确保工具的安全执行。
- 应用数据保护和隐私合规的最佳实践。

## 身份验证与授权

身份验证和授权是保护 MCP 服务器安全的关键。身份验证回答“你是谁？”，授权则回答“你能做什么？”。

下面我们来看如何使用 .NET 和 Java 实现 MCP 服务器的安全身份验证和授权。

### .NET 身份集成

ASP .NET Core Identity 提供了一个强大的框架来管理用户身份验证和授权。我们可以将其集成到 MCP 服务器中，以保护对工具和资源的访问。

集成 ASP.NET Core Identity 与 MCP 服务器时，需要理解以下核心概念：

- **身份配置**：设置 ASP.NET Core Identity，管理用户角色和声明。声明是关于用户的信息，如角色或权限，例如“Admin”或“User”。
- **JWT 身份验证**：使用 JSON Web Tokens (JWT) 实现安全的 API 访问。JWT 是一种在各方之间安全传递信息的标准，信息以 JSON 对象形式传输，并通过数字签名进行验证和信任。
- **授权策略**：定义基于用户角色的访问控制策略，决定用户能访问哪些工具。MCP 使用授权策略，根据用户的角色和声明控制访问权限。

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

上述代码中，我们：

- 配置了 ASP.NET Core Identity 以管理用户。
- 设置了 JWT 身份验证，确保 API 访问安全。指定了令牌验证参数，包括发行者、受众和签名密钥。
- 定义了基于用户角色的授权策略。例如，“CanUseAdminTools”策略要求用户具有“Admin”角色，而“CanUseBasic”策略要求用户已通过身份验证。
- 为 MCP 工具注册了特定的授权要求，确保只有具备相应角色的用户才能访问。

### Java Spring Security 集成

对于 Java，我们将使用 Spring Security 实现 MCP 服务器的安全身份验证和授权。Spring Security 提供了一个全面的安全框架，能与 Spring 应用无缝集成。

核心概念包括：

- **Spring Security 配置**：设置身份验证和授权的安全配置。
- **OAuth2 资源服务器**：使用 OAuth2 实现对 MCP 工具的安全访问。OAuth2 是一种授权框架，允许第三方服务通过访问令牌实现安全的 API 访问。
- **安全拦截器**：实现安全拦截器，强制执行工具执行的访问控制。
- **基于角色的访问控制**：通过角色控制对特定工具和资源的访问。
- **安全注解**：使用注解保护方法和端点。

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

上述代码中，我们：

- 配置了 Spring Security 保护 MCP 端点，允许公开访问工具发现功能，但执行工具时需要身份验证。
- 使用 OAuth2 作为资源服务器，处理对 MCP 工具的安全访问。
- 实现了安全拦截器，在允许访问特定工具前检查用户角色和权限。
- 定义了基于角色的访问控制，限制对管理工具和敏感数据的访问。

## 数据保护与隐私

数据保护对于确保敏感信息的安全处理至关重要。这包括保护个人身份信息（PII）、财务数据以及其他敏感信息，防止未经授权的访问和泄露。

### Python 数据保护示例

下面是一个使用加密和 PII 检测实现数据保护的 Python 示例。

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

上述代码中，我们：

- 实现了 `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`，确保其安全处理敏感数据。

## 后续内容

- [Web search](../web-search-mcp/README.md)

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻译而成。虽然我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而引起的任何误解或错误解释，我们概不负责。