<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T21:42:17+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ko"
}
-->
# 보안 모범 사례

보안은 특히 기업 환경에서 MCP 구현에 매우 중요합니다. 도구와 데이터가 무단 접근, 데이터 유출 및 기타 보안 위협으로부터 보호되도록 하는 것이 중요합니다.

## 소개

이번 강의에서는 MCP 구현을 위한 보안 모범 사례를 살펴봅니다. 인증 및 권한 부여, 데이터 보호, 안전한 도구 실행, 그리고 데이터 개인정보 보호 규정 준수에 대해 다룹니다.

## 학습 목표

이 강의를 마치면 다음을 수행할 수 있습니다:

- MCP 서버에 대해 안전한 인증 및 권한 부여 메커니즘을 구현합니다.
- 암호화와 안전한 저장소를 사용하여 민감한 데이터를 보호합니다.
- 적절한 접근 제어를 통해 도구의 안전한 실행을 보장합니다.
- 데이터 보호 및 개인정보 보호 규정 준수를 위한 모범 사례를 적용합니다.

## 인증 및 권한 부여

인증과 권한 부여는 MCP 서버 보안에 필수적입니다. 인증은 "당신은 누구인가요?"에 대한 답변이고, 권한 부여는 "무엇을 할 수 있나요?"에 대한 답변입니다.

.NET과 Java를 사용해 MCP 서버에서 안전한 인증과 권한 부여를 구현하는 예를 살펴보겠습니다.

### .NET Identity 통합

ASP .NET Core Identity는 사용자 인증과 권한 관리를 위한 강력한 프레임워크를 제공합니다. 이를 MCP 서버와 통합해 도구와 리소스에 대한 접근을 보호할 수 있습니다.

ASP.NET Core Identity를 MCP 서버에 통합할 때 이해해야 할 핵심 개념은 다음과 같습니다:

- **Identity 구성**: 사용자 역할과 클레임을 포함한 ASP.NET Core Identity 설정. 클레임은 사용자에 대한 정보 조각으로, 예를 들어 "Admin"이나 "User" 같은 역할 또는 권한을 의미합니다.
- **JWT 인증**: 안전한 API 접근을 위한 JSON Web Token(JWT) 사용. JWT는 디지털 서명으로 검증 가능하고 신뢰할 수 있는 JSON 객체 형태로 정보를 안전하게 전달하는 표준입니다.
- **권한 부여 정책**: 사용자 역할에 따라 특정 도구 접근을 제어하는 정책 정의. MCP는 역할과 클레임에 기반해 어떤 사용자가 어떤 도구에 접근할 수 있는지 결정하는 권한 부여 정책을 사용합니다.

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

위 코드에서는 다음을 수행했습니다:

- 사용자 관리를 위해 ASP.NET Core Identity를 구성했습니다.
- 안전한 API 접근을 위해 JWT 인증을 설정했습니다. 발행자, 수신자, 서명 키를 포함한 토큰 검증 매개변수를 지정했습니다.
- 사용자 역할에 따라 도구 접근을 제어하는 권한 부여 정책을 정의했습니다. 예를 들어 "CanUseAdminTools" 정책은 사용자가 "Admin" 역할을 가져야 하며, "CanUseBasic" 정책은 사용자가 인증된 상태여야 합니다.
- 적절한 역할을 가진 사용자만 접근할 수 있도록 특정 권한 요구 사항과 함께 MCP 도구를 등록했습니다.

### Java Spring Security 통합

Java에서는 Spring Security를 사용해 MCP 서버에 대한 안전한 인증과 권한 부여를 구현합니다. Spring Security는 Spring 애플리케이션과 원활하게 통합되는 포괄적인 보안 프레임워크입니다.

핵심 개념은 다음과 같습니다:

- **Spring Security 구성**: 인증과 권한 부여를 위한 보안 설정.
- **OAuth2 리소스 서버**: MCP 도구에 대한 안전한 접근을 위한 OAuth2 사용. OAuth2는 제3자 서비스가 액세스 토큰을 교환해 안전한 API 접근을 가능하게 하는 권한 부여 프레임워크입니다.
- **보안 인터셉터**: 도구 실행 시 접근 제어를 적용하는 보안 인터셉터 구현.
- **역할 기반 접근 제어**: 특정 도구와 리소스 접근을 역할에 따라 제어.
- **보안 어노테이션**: 메서드와 엔드포인트를 보호하기 위한 어노테이션 사용.

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

위 코드에서는 다음을 수행했습니다:

- Spring Security를 구성해 MCP 엔드포인트를 보호하고, 도구 검색은 공개 접근을 허용하되 도구 실행은 인증을 요구하도록 했습니다.
- MCP 도구에 대한 안전한 접근을 처리하기 위해 OAuth2를 리소스 서버로 사용했습니다.
- 도구 실행 시 사용자 역할과 권한을 확인하는 보안 인터셉터를 구현해 접근 제어를 적용했습니다.
- 역할 기반 접근 제어를 정의해 관리자 도구와 민감한 데이터 접근을 사용자 역할에 따라 제한했습니다.

## 데이터 보호 및 개인정보

데이터 보호는 민감한 정보가 안전하게 처리되도록 보장하는 데 필수적입니다. 여기에는 개인 식별 정보(PII), 금융 데이터, 기타 민감 정보가 무단 접근과 유출로부터 보호되는 것이 포함됩니다.

### Python 데이터 보호 예제

암호화와 PII 탐지를 사용해 Python에서 데이터 보호를 구현하는 예를 살펴보겠습니다.

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

위 코드에서는 다음을 수행했습니다:

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`을 구현해 민감한 데이터를 안전하게 처리하도록 했습니다.

## 다음 단계

- [5.9 Web search](../web-search-mcp/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역은 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 당사가 책임지지 않습니다.