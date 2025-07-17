<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T20:55:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "zh"
}
-->
# 安全最佳实践

安全对于 MCP 实现尤为重要，尤其是在企业环境中。确保工具和数据免受未经授权的访问、数据泄露及其他安全威胁至关重要。

## 介绍

由于 MCP 在为大型语言模型（LLM）提供数据和工具访问方面的作用，必须考虑特定的安全问题。本课将基于官方 MCP 指南和成熟的安全模式，探讨 MCP 实现中的安全最佳实践。

MCP 遵循关键的安全原则，以确保交互的安全和可信：

- **用户同意与控制**：在访问任何数据或执行操作前，必须获得用户明确同意。应清晰地让用户控制共享哪些数据以及授权哪些操作。
  
- **数据隐私**：用户数据仅在获得明确同意后才可暴露，且必须通过适当的访问控制加以保护。防止未经授权的数据传输。
  
- **工具安全**：调用任何工具前必须获得用户明确同意。用户应清楚了解每个工具的功能，并且必须执行严格的安全边界。

## 学习目标

完成本课后，您将能够：

- 为 MCP 服务器实现安全的身份验证和授权机制。
- 使用加密和安全存储保护敏感数据。
- 通过适当的访问控制确保工具的安全执行。
- 应用数据保护和隐私合规的最佳实践。
- 识别并缓解常见的 MCP 安全漏洞，如混淆代理问题、令牌透传和会话劫持。

## 身份验证与授权

身份验证和授权是保护 MCP 服务器安全的关键。身份验证回答“你是谁？”，授权回答“你能做什么？”。

根据 MCP 安全规范，以下是关键的安全考虑：

1. **令牌验证**：MCP 服务器不得接受未明确为该 MCP 服务器签发的任何令牌。“令牌透传”是一种明确禁止的反模式。

2. **授权验证**：实现授权的 MCP 服务器必须验证所有入站请求，且不得使用会话进行身份验证。

3. **安全会话管理**：使用会话存储状态时，MCP 服务器必须使用安全的、非确定性的会话 ID，这些 ID 应由安全随机数生成器生成。会话 ID 应绑定到用户特定信息。

4. **明确用户同意**：对于代理服务器，MCP 实现必须在转发到第三方授权服务器之前，针对每个动态注册的客户端获得用户同意。

下面通过 .NET 和 Java 的示例，展示如何在 MCP 服务器中实现安全的身份验证和授权。

### .NET 身份集成

ASP .NET Core Identity 提供了一个强大的框架，用于管理用户身份验证和授权。我们可以将其集成到 MCP 服务器中，以保护对工具和资源的访问。

集成 ASP.NET Core Identity 与 MCP 服务器时，需要理解以下核心概念：

- **身份配置**：设置 ASP.NET Core Identity，包括用户角色和声明。声明是关于用户的信息片段，例如角色或权限，如“Admin”或“User”。
- **JWT 身份验证**：使用 JSON Web Tokens (JWT) 实现安全的 API 访问。JWT 是一种以 JSON 对象形式安全传输信息的标准，因其数字签名而可被验证和信任。
- **授权策略**：定义策略以基于用户角色控制对特定工具的访问。MCP 使用授权策略来确定哪些用户基于其角色和声明可以访问哪些工具。

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
- 设置了 JWT 身份验证以实现安全的 API 访问，指定了令牌验证参数，包括发行者、受众和签名密钥。
- 定义了基于用户角色的授权策略。例如，“CanUseAdminTools”策略要求用户具有“Admin”角色，而“CanUseBasic”策略要求用户已通过身份验证。
- 注册了带有特定授权要求的 MCP 工具，确保只有具备相应角色的用户才能访问。

### Java Spring Security 集成

对于 Java，我们使用 Spring Security 来实现 MCP 服务器的安全身份验证和授权。Spring Security 提供了一个全面的安全框架，能无缝集成到 Spring 应用中。

核心概念包括：

- **Spring Security 配置**：设置身份验证和授权的安全配置。
- **OAuth2 资源服务器**：使用 OAuth2 实现对 MCP 工具的安全访问。OAuth2 是一种授权框架，允许第三方服务交换访问令牌以实现安全的 API 访问。
- **安全拦截器**：实现安全拦截器以强制执行工具执行的访问控制。
- **基于角色的访问控制**：使用角色控制对特定工具和资源的访问。
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

- 配置了 Spring Security 以保护 MCP 端点，允许公开访问工具发现，但执行工具时需要身份验证。
- 使用 OAuth2 作为资源服务器，处理对 MCP 工具的安全访问。
- 实现了安全拦截器，在允许访问特定工具前检查用户角色和权限。
- 定义了基于角色的访问控制，限制对管理工具和敏感数据的访问。

## 数据保护与隐私

数据保护对于确保敏感信息的安全处理至关重要。这包括保护个人身份信息（PII）、财务数据及其他敏感信息，防止未经授权的访问和泄露。

### Python 数据保护示例

下面展示如何使用加密和 PII 检测在 Python 中实现数据保护。

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

- 实现了 `PiiDetector` 类，用于扫描文本和参数中的个人身份信息（PII）。
- 创建了 `EncryptionService` 类，使用 `cryptography` 库处理敏感数据的加密和解密。
- 定义了 `secure_tool` 装饰器，包装工具执行过程，检查 PII、记录访问日志，并在需要时加密敏感数据。
- 将 `secure_tool` 装饰器应用于示例工具（`SecureCustomerDataTool`），确保其安全处理敏感数据。

## MCP 特定的安全风险

根据官方 MCP 安全文档，MCP 实现者应注意以下特定安全风险：

### 1. 混淆代理问题

当 MCP 服务器作为第三方 API 的代理时，攻击者可能利用 MCP 服务器与这些 API 之间的信任关系进行攻击。

**缓解措施：**
- 使用静态客户端 ID 的 MCP 代理服务器必须在转发到第三方授权服务器之前，针对每个动态注册的客户端获得用户同意。
- 对授权请求实施带 PKCE（Proof Key for Code Exchange）的 OAuth 流程。
- 严格验证重定向 URI 和客户端标识符。

### 2. 令牌透传漏洞

令牌透传指 MCP 服务器接受来自 MCP 客户端的令牌，但未验证这些令牌是否正确签发给 MCP 服务器，且将其传递给下游 API。

### 风险
- 绕过安全控制（如速率限制、请求验证）
- 责任追踪和审计问题
- 信任边界被破坏
- 未来兼容性风险

**缓解措施：**
- MCP 服务器不得接受未明确为其签发的令牌。
- 始终验证令牌的受众声明，确保其与预期服务匹配。

### 3. 会话劫持

当未经授权的第三方获取会话 ID 并冒充原始客户端时，可能导致未经授权的操作。

**缓解措施：**
- 实现授权的 MCP 服务器必须验证所有入站请求，且不得使用会话进行身份验证。
- 使用安全的、非确定性的会话 ID，由安全随机数生成器生成。
- 使用类似 `<user_id>:<session_id>` 的格式将会话 ID 绑定到用户特定信息。
- 实施适当的会话过期和轮换策略。

## MCP 的其他安全最佳实践

除了核心的 MCP 安全考虑外，还应考虑实施以下安全措施：

- **始终使用 HTTPS**：加密客户端与服务器之间的通信，防止令牌被截获。
- **实施基于角色的访问控制（RBAC）**：不仅检查用户是否已认证，还要检查其被授权执行的操作。
- **监控和审计**：记录所有身份验证事件，以便检测和响应可疑活动。
- **处理速率限制和节流**：实现指数退避和重试逻辑，优雅地应对速率限制。
- **安全存储令牌**：使用系统安全存储机制或安全密钥管理服务，安全存储访问令牌和刷新令牌。
- **考虑使用 API 管理**：如 Azure API Management 等服务可自动处理许多安全问题，包括身份验证、授权和速率限制。

## 参考资料

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## 后续内容

- [5.9 Web search](../web-search-mcp/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。