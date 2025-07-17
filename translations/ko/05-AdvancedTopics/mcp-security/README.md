<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T21:47:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ko"
}
-->
# 보안 모범 사례

보안은 특히 기업 환경에서 MCP 구현에 매우 중요합니다. 도구와 데이터가 무단 접근, 데이터 유출 및 기타 보안 위협으로부터 보호되는 것이 중요합니다.

## 소개

Model Context Protocol(MCP)은 LLM이 데이터와 도구에 접근할 수 있도록 하는 역할 때문에 특별한 보안 고려사항이 필요합니다. 이 강의에서는 공식 MCP 가이드라인과 검증된 보안 패턴을 기반으로 MCP 구현을 위한 보안 모범 사례를 살펴봅니다.

MCP는 안전하고 신뢰할 수 있는 상호작용을 보장하기 위해 다음과 같은 핵심 보안 원칙을 따릅니다:

- **사용자 동의 및 제어**: 데이터 접근이나 작업 수행 전에 사용자의 명시적 동의를 받아야 합니다. 어떤 데이터가 공유되고 어떤 작업이 허용되는지 명확하게 제어할 수 있어야 합니다.
  
- **데이터 프라이버시**: 사용자 데이터는 명시적 동의가 있을 때만 노출되어야 하며 적절한 접근 제어로 보호되어야 합니다. 무단 데이터 전송을 방지해야 합니다.
  
- **도구 안전성**: 도구를 호출하기 전에 명시적 사용자 동의가 필요합니다. 사용자는 각 도구의 기능을 명확히 이해해야 하며, 강력한 보안 경계가 적용되어야 합니다.

## 학습 목표

이 강의를 마치면 다음을 수행할 수 있습니다:

- MCP 서버에 대한 안전한 인증 및 권한 부여 메커니즘 구현
- 암호화 및 안전한 저장소를 사용하여 민감한 데이터 보호
- 적절한 접근 제어를 통해 도구의 안전한 실행 보장
- 데이터 보호 및 개인정보 보호 규정 준수를 위한 모범 사례 적용
- 혼란된 대리인 문제, 토큰 전달, 세션 탈취 등 일반적인 MCP 보안 취약점 식별 및 완화

## 인증 및 권한 부여

인증과 권한 부여는 MCP 서버 보안에 필수적입니다. 인증은 "당신은 누구인가?"에 답하고, 권한 부여는 "무엇을 할 수 있는가?"에 답합니다.

MCP 보안 명세에 따르면 다음 사항이 중요한 보안 고려사항입니다:

1. **토큰 검증**: MCP 서버는 명시적으로 MCP 서버를 위해 발급된 토큰만을 허용해야 합니다. "토큰 전달(token passthrough)"은 명백히 금지된 안티패턴입니다.

2. **권한 검증**: 권한 부여를 구현하는 MCP 서버는 모든 수신 요청을 검증해야 하며, 인증에 세션을 사용해서는 안 됩니다.

3. **안전한 세션 관리**: 상태 관리를 위해 세션을 사용할 경우, MCP 서버는 보안 난수 생성기로 생성된 안전하고 비결정적인 세션 ID를 사용해야 합니다. 세션 ID는 사용자별 정보에 바인딩되어야 합니다.

4. **명시적 사용자 동의**: 프록시 서버의 경우, MCP 구현체는 동적으로 등록된 각 클라이언트에 대해 제3자 권한 서버로 전달하기 전에 사용자 동의를 반드시 받아야 합니다.

다음은 .NET과 Java를 사용해 MCP 서버에서 안전한 인증 및 권한 부여를 구현하는 예시입니다.

### .NET Identity 통합

ASP .NET Core Identity는 사용자 인증 및 권한 관리를 위한 강력한 프레임워크를 제공합니다. 이를 MCP 서버와 통합하여 도구와 리소스 접근을 보호할 수 있습니다.

ASP.NET Core Identity를 MCP 서버와 통합할 때 이해해야 할 핵심 개념은 다음과 같습니다:

- **Identity 구성**: 사용자 역할과 클레임을 포함한 ASP.NET Core Identity 설정. 클레임은 예를 들어 "Admin" 또는 "User"와 같이 사용자의 역할이나 권한에 관한 정보입니다.
- **JWT 인증**: JSON Web Token(JWT)을 사용한 안전한 API 접근. JWT는 디지털 서명되어 검증 가능하고 신뢰할 수 있는 JSON 객체 형태로 정보를 안전하게 전송하는 표준입니다.
- **권한 정책**: 사용자 역할에 따라 특정 도구에 대한 접근을 제어하는 정책 정의. MCP는 역할과 클레임에 기반해 어떤 사용자가 어떤 도구에 접근할 수 있는지 결정하기 위해 권한 정책을 사용합니다.

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
- 안전한 API 접근을 위해 JWT 인증을 설정했습니다. 발급자, 대상, 서명 키 등 토큰 검증 매개변수를 지정했습니다.
- 사용자 역할에 따라 도구 접근을 제어하는 권한 정책을 정의했습니다. 예를 들어 "CanUseAdminTools" 정책은 "Admin" 역할을 가진 사용자만 허용하며, "CanUseBasic" 정책은 인증된 사용자만 허용합니다.
- 특정 권한 요구사항을 가진 MCP 도구를 등록하여 적절한 역할을 가진 사용자만 접근할 수 있도록 했습니다.

### Java Spring Security 통합

Java에서는 Spring Security를 사용해 MCP 서버의 안전한 인증 및 권한 부여를 구현합니다. Spring Security는 Spring 애플리케이션과 원활하게 통합되는 포괄적인 보안 프레임워크입니다.

핵심 개념은 다음과 같습니다:

- **Spring Security 구성**: 인증 및 권한 부여를 위한 보안 설정
- **OAuth2 리소스 서버**: MCP 도구에 대한 안전한 접근을 위해 OAuth2 사용. OAuth2는 제3자 서비스가 액세스 토큰을 교환하여 안전한 API 접근을 가능하게 하는 권한 부여 프레임워크입니다.
- **보안 인터셉터**: 도구 실행에 대한 접근 제어를 강제하는 보안 인터셉터 구현
- **역할 기반 접근 제어**: 역할을 사용해 특정 도구와 리소스에 대한 접근 제어
- **보안 어노테이션**: 메서드와 엔드포인트를 보호하기 위한 어노테이션 사용

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

- MCP 엔드포인트를 보호하도록 Spring Security를 구성했으며, 도구 검색은 공개 접근을 허용하고 도구 실행은 인증을 요구하도록 했습니다.
- MCP 도구에 대한 안전한 접근을 처리하기 위해 OAuth2 리소스 서버를 사용했습니다.
- 도구 실행에 대한 접근 제어를 강제하는 보안 인터셉터를 구현하여, 특정 도구에 접근하기 전에 사용자 역할과 권한을 확인했습니다.
- 역할 기반 접근 제어를 정의하여 관리자 도구 및 민감한 데이터 접근을 사용자 역할에 따라 제한했습니다.

## 데이터 보호 및 개인정보

데이터 보호는 민감한 정보가 안전하게 처리되도록 하는 데 필수적입니다. 여기에는 개인 식별 정보(PII), 금융 데이터 및 기타 민감한 정보가 무단 접근과 유출로부터 보호되는 것이 포함됩니다.

### Python 데이터 보호 예시

암호화와 PII 탐지를 사용해 Python에서 데이터 보호를 구현하는 예시를 살펴보겠습니다.

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

- 텍스트와 매개변수에서 개인 식별 정보(PII)를 검사하는 `PiiDetector` 클래스를 구현했습니다.
- `cryptography` 라이브러리를 사용해 민감한 데이터를 암호화 및 복호화하는 `EncryptionService` 클래스를 만들었습니다.
- 도구 실행을 감싸 PII를 검사하고 접근을 기록하며 필요 시 민감한 데이터를 암호화하는 `secure_tool` 데코레이터를 정의했습니다.
- `secure_tool` 데코레이터를 샘플 도구(`SecureCustomerDataTool`)에 적용해 민감한 데이터를 안전하게 처리하도록 했습니다.

## MCP 고유 보안 위험

공식 MCP 보안 문서에 따르면 MCP 구현자가 인지해야 할 특정 보안 위험이 있습니다:

### 1. 혼란된 대리인 문제(Confused Deputy Problem)

이 취약점은 MCP 서버가 제3자 API에 대한 프록시 역할을 할 때 발생하며, 공격자가 MCP 서버와 API 간의 신뢰 관계를 악용할 수 있습니다.

**완화 방안:**
- 정적 클라이언트 ID를 사용하는 MCP 프록시 서버는 제3자 권한 서버로 전달하기 전에 동적으로 등록된 각 클라이언트에 대해 사용자 동의를 받아야 합니다.
- 권한 요청에 대해 PKCE(Proof Key for Code Exchange)를 포함한 적절한 OAuth 흐름을 구현합니다.
- 리디렉션 URI와 클라이언트 식별자를 엄격히 검증합니다.

### 2. 토큰 전달 취약점(Token Passthrough Vulnerabilities)

토큰 전달은 MCP 서버가 MCP 클라이언트로부터 토큰이 MCP 서버에 적절히 발급되었는지 검증하지 않고 받아서 하위 API에 전달할 때 발생합니다.

### 위험
- 보안 통제 우회(요청 제한, 요청 검증 우회)
- 책임 추적 및 감사 문제
- 신뢰 경계 위반
- 향후 호환성 문제

**완화 방안:**
- MCP 서버는 명시적으로 MCP 서버를 위해 발급된 토큰만 허용해야 합니다.
- 토큰의 대상(audience) 클레임이 예상 서비스와 일치하는지 항상 검증해야 합니다.

### 3. 세션 탈취(Session Hijacking)

무단 사용자가 세션 ID를 획득해 원래 클라이언트를 가장하여 무단 작업을 수행할 수 있는 상황입니다.

**완화 방안:**
- 권한 부여를 구현하는 MCP 서버는 모든 수신 요청을 검증해야 하며, 인증에 세션을 사용해서는 안 됩니다.
- 보안 난수 생성기로 생성된 안전하고 비결정적인 세션 ID를 사용합니다.
- `<user_id>:<session_id>`와 같은 키 형식을 사용해 세션 ID를 사용자별 정보에 바인딩합니다.
- 적절한 세션 만료 및 갱신 정책을 구현합니다.

## MCP 추가 보안 모범 사례

핵심 MCP 보안 고려사항 외에도 다음과 같은 추가 보안 관행을 고려하세요:

- **항상 HTTPS 사용**: 클라이언트와 서버 간 통신을 암호화해 토큰 가로채기를 방지합니다.
- **역할 기반 접근 제어(RBAC) 구현**: 사용자가 인증되었는지뿐 아니라 어떤 권한이 있는지도 확인합니다.
- **모니터링 및 감사**: 모든 인증 이벤트를 기록해 의심스러운 활동을 탐지하고 대응합니다.
- **요청 제한 및 스로틀링 처리**: 지수 백오프 및 재시도 로직을 구현해 요청 제한을 원활히 처리합니다.
- **안전한 토큰 저장**: 시스템 보안 저장소나 안전한 키 관리 서비스를 사용해 액세스 토큰과 리프레시 토큰을 안전하게 보관합니다.
- **API 관리 도구 활용 고려**: Azure API Management 같은 서비스는 인증, 권한 부여, 요청 제한 등 많은 보안 문제를 자동으로 처리할 수 있습니다.

## 참고 문헌

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## 다음 단계

- [5.9 웹 검색](../web-search-mcp/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.