<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:09:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ru"
}
-->
# Лучшие практики безопасности

Безопасность критически важна для реализации MCP, особенно в корпоративных средах. Важно обеспечить защиту инструментов и данных от несанкционированного доступа, утечек информации и других угроз безопасности.

## Введение

В этом уроке мы рассмотрим лучшие практики безопасности для реализации MCP. Мы обсудим аутентификацию и авторизацию, защиту данных, безопасное выполнение инструментов и соблюдение требований по защите персональных данных.

## Цели обучения

К концу этого урока вы сможете:

- Реализовать надежные механизмы аутентификации и авторизации для MCP-серверов.
- Защищать конфиденциальные данные с помощью шифрования и безопасного хранения.
- Обеспечивать безопасное выполнение инструментов с правильным контролем доступа.
- Применять лучшие практики по защите данных и соблюдению требований конфиденциальности.

## Аутентификация и авторизация

Аутентификация и авторизация необходимы для защиты MCP-серверов. Аутентификация отвечает на вопрос «Кто вы?», а авторизация — «Что вы можете делать?».

Рассмотрим примеры реализации надежной аутентификации и авторизации в MCP-серверах с использованием .NET и Java.

### Интеграция .NET Identity

ASP .NET Core Identity предоставляет надежный фреймворк для управления аутентификацией и авторизацией пользователей. Мы можем интегрировать его с MCP-серверами для защиты доступа к инструментам и ресурсам.

При интеграции ASP.NET Core Identity с MCP-серверами важно понимать следующие основные концепции:

- **Конфигурация Identity**: Настройка ASP.NET Core Identity с ролями пользователей и утверждениями. Утверждение — это информация о пользователе, например его роль или права, например «Admin» или «User».
- **JWT-аутентификация**: Использование JSON Web Tokens (JWT) для безопасного доступа к API. JWT — это стандарт для безопасной передачи информации между сторонами в формате JSON, который можно проверить и которому можно доверять, так как он цифрово подписан.
- **Политики авторизации**: Определение политик для контроля доступа к конкретным инструментам на основе ролей пользователей. MCP использует политики авторизации, чтобы определить, какие пользователи могут получить доступ к каким инструментам в зависимости от их ролей и утверждений.

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

В приведённом выше коде мы:

- Настроили ASP.NET Core Identity для управления пользователями.
- Настроили JWT-аутентификацию для безопасного доступа к API, указав параметры проверки токена, включая издателя, аудиторию и ключ подписи.
- Определили политики авторизации для контроля доступа к инструментам на основе ролей пользователей. Например, политика "CanUseAdminTools" требует роль "Admin", а политика "CanUseBasic" — просто аутентификацию пользователя.
- Зарегистрировали MCP-инструменты с конкретными требованиями по авторизации, чтобы только пользователи с соответствующими ролями могли получить к ним доступ.

### Интеграция Java Spring Security

Для Java мы используем Spring Security для реализации надежной аутентификации и авторизации MCP-серверов. Spring Security предоставляет комплексный фреймворк безопасности, который легко интегрируется с приложениями на Spring.

Основные концепции здесь:

- **Конфигурация Spring Security**: Настройка безопасности для аутентификации и авторизации.
- **OAuth2 Resource Server**: Использование OAuth2 для безопасного доступа к инструментам MCP. OAuth2 — это фреймворк авторизации, который позволяет сторонним сервисам обмениваться токенами доступа для безопасного доступа к API.
- **Секьюрити-перехватчики**: Реализация перехватчиков безопасности для контроля доступа при выполнении инструментов.
- **Контроль доступа на основе ролей**: Использование ролей для ограничения доступа к конкретным инструментам и ресурсам.
- **Аннотации безопасности**: Использование аннотаций для защиты методов и конечных точек.

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

В приведённом выше коде мы:

- Настроили Spring Security для защиты MCP-эндпоинтов, разрешая публичный доступ к обнаружению инструментов и требуя аутентификацию для их выполнения.
- Использовали OAuth2 в качестве resource server для обеспечения безопасного доступа к инструментам MCP.
- Реализовали перехватчик безопасности для контроля доступа при выполнении инструментов, проверяя роли и права пользователя перед предоставлением доступа к конкретным инструментам.
- Определили контроль доступа на основе ролей для ограничения доступа к административным инструментам и конфиденциальным данным в зависимости от ролей пользователей.

## Защита данных и конфиденциальность

Защита данных крайне важна для обеспечения безопасной обработки конфиденциальной информации. Это включает защиту персональных данных (PII), финансовой информации и других чувствительных данных от несанкционированного доступа и утечек.

### Пример защиты данных на Python

Рассмотрим пример реализации защиты данных на Python с использованием шифрования и обнаружения PII.

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

В приведённом выше коде мы:

- Реализовали `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`, чтобы обеспечить безопасную обработку конфиденциальных данных.

## Что дальше

- [Web search](../web-search-mcp/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.