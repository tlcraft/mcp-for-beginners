<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T23:25:28+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ru"
}
-->
# Лучшие практики безопасности

Безопасность имеет решающее значение для реализации MCP, особенно в корпоративной среде. Важно обеспечить защиту инструментов и данных от несанкционированного доступа, утечек и других угроз безопасности.

## Введение

Протокол контекста модели (MCP) требует особого внимания к безопасности, поскольку он предоставляет LLM доступ к данным и инструментам. В этом уроке рассматриваются лучшие практики безопасности для реализации MCP на основе официальных рекомендаций и проверенных паттернов.

MCP придерживается ключевых принципов безопасности для обеспечения надежного и безопасного взаимодействия:

- **Согласие и контроль пользователя**: Пользователь должен явно согласиться на доступ к данным или выполнение операций. Обеспечьте прозрачный контроль над тем, какие данные передаются и какие действия разрешены.
  
- **Конфиденциальность данных**: Данные пользователя должны передаваться только с его явного согласия и защищаться соответствующими механизмами контроля доступа. Предотвращайте несанкционированную передачу данных.
  
- **Безопасность инструментов**: Перед вызовом любого инструмента требуется явное согласие пользователя. Пользователь должен четко понимать функциональность каждого инструмента, а также должны соблюдаться строгие границы безопасности.

## Цели обучения

К концу этого урока вы сможете:

- Реализовать надежные механизмы аутентификации и авторизации для MCP-серверов.
- Защищать конфиденциальные данные с помощью шифрования и безопасного хранения.
- Обеспечить безопасное выполнение инструментов с правильным контролем доступа.
- Применять лучшие практики защиты данных и соблюдения требований конфиденциальности.
- Выявлять и устранять распространённые уязвимости MCP, такие как проблема «confused deputy», передача токенов и перехват сессий.

## Аутентификация и авторизация

Аутентификация и авторизация — ключевые элементы безопасности MCP-серверов. Аутентификация отвечает на вопрос «Кто вы?», а авторизация — «Что вы можете делать?».

Согласно спецификации безопасности MCP, важны следующие моменты:

1. **Проверка токенов**: MCP-серверы НЕ ДОЛЖНЫ принимать токены, которые не были явно выданы для данного MCP-сервера. «Передача токенов» — это явно запрещённый антипаттерн.

2. **Проверка авторизации**: MCP-серверы, реализующие авторизацию, ДОЛЖНЫ проверять все входящие запросы и НЕ ДОЛЖНЫ использовать сессии для аутентификации.

3. **Безопасное управление сессиями**: При использовании сессий MCP-серверы ДОЛЖНЫ применять безопасные, недетерминированные идентификаторы сессий, сгенерированные с помощью криптографически стойких генераторов случайных чисел. Идентификаторы сессий ДОЛЖНЫ быть связаны с информацией о пользователе.

4. **Явное согласие пользователя**: Для прокси-серверов MCP необходимо получать согласие пользователя для каждого динамически зарегистрированного клиента перед перенаправлением на сторонние серверы авторизации.

Рассмотрим примеры реализации безопасной аутентификации и авторизации MCP-серверов на .NET и Java.

### Интеграция с .NET Identity

ASP .NET Core Identity предоставляет надежный фреймворк для управления аутентификацией и авторизацией пользователей. Его можно интегрировать с MCP-серверами для защиты доступа к инструментам и ресурсам.

Основные понятия при интеграции ASP.NET Core Identity с MCP:

- **Конфигурация Identity**: Настройка ASP.NET Core Identity с ролями и утверждениями пользователей. Утверждение — это информация о пользователе, например, роль или права, например «Admin» или «User».
- **Аутентификация JWT**: Использование JSON Web Tokens (JWT) для безопасного доступа к API. JWT — стандарт для безопасной передачи информации в виде JSON-объекта, который можно проверить и которому можно доверять благодаря цифровой подписи.
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

В приведённом коде мы:

- Настроили ASP.NET Core Identity для управления пользователями.
- Настроили аутентификацию JWT для безопасного доступа к API, указав параметры проверки токена, включая издателя, аудиторию и ключ подписи.
- Определили политики авторизации для контроля доступа к инструментам на основе ролей пользователей. Например, политика «CanUseAdminTools» требует роль «Admin», а «CanUseBasic» — просто аутентификацию пользователя.
- Зарегистрировали инструменты MCP с конкретными требованиями авторизации, чтобы только пользователи с нужными ролями могли к ним обращаться.

### Интеграция с Java Spring Security

Для Java мы используем Spring Security для реализации безопасной аутентификации и авторизации MCP-серверов. Spring Security — это комплексный фреймворк безопасности, который легко интегрируется с приложениями Spring.

Основные понятия:

- **Конфигурация Spring Security**: Настройка безопасности для аутентификации и авторизации.
- **OAuth2 Resource Server**: Использование OAuth2 для безопасного доступа к инструментам MCP. OAuth2 — это фреймворк авторизации, позволяющий сторонним сервисам обмениваться токенами доступа для безопасного API-доступа.
- **Секьюрити-интерцепторы**: Реализация перехватчиков безопасности для контроля доступа при выполнении инструментов.
- **Ролевой контроль доступа**: Использование ролей для ограничения доступа к конкретным инструментам и ресурсам.
- **Аннотации безопасности**: Использование аннотаций для защиты методов и эндпоинтов.

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

В приведённом коде мы:

- Настроили Spring Security для защиты MCP-эндпоинтов, разрешая публичный доступ к обнаружению инструментов и требуя аутентификацию для их выполнения.
- Использовали OAuth2 в качестве resource server для безопасного доступа к инструментам MCP.
- Реализовали перехватчик безопасности для контроля доступа при выполнении инструментов, проверяя роли и права пользователя перед разрешением доступа.
- Определили ролевой контроль доступа для ограничения доступа к административным инструментам и конфиденциальным данным на основе ролей пользователей.

## Защита данных и конфиденциальность

Защита данных крайне важна для обеспечения безопасности обработки конфиденциальной информации. Это включает защиту персональных данных (PII), финансовой информации и других чувствительных данных от несанкционированного доступа и утечек.

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

В приведённом коде мы:

- Реализовали класс `PiiDetector` для сканирования текста и параметров на наличие персональных данных (PII).
- Создали класс `EncryptionService` для шифрования и расшифровки конфиденциальных данных с помощью библиотеки `cryptography`.
- Определили декоратор `secure_tool`, который оборачивает выполнение инструмента, проверяет наличие PII, ведёт журнал доступа и при необходимости шифрует чувствительные данные.
- Применили декоратор `secure_tool` к примеру инструмента (`SecureCustomerDataTool`), чтобы обеспечить безопасную обработку конфиденциальных данных.

## Специфические риски безопасности MCP

Согласно официальной документации по безопасности MCP, существуют определённые риски, о которых должны знать разработчики MCP:

### 1. Проблема «confused deputy»

Эта уязвимость возникает, когда MCP-сервер выступает в роли прокси для сторонних API, что может позволить злоумышленникам использовать доверительные отношения между MCP-сервером и этими API.

**Меры защиты:**
- Прокси-серверы MCP с использованием статических client ID ДОЛЖНЫ получать согласие пользователя для каждого динамически зарегистрированного клиента перед перенаправлением на сторонние серверы авторизации.
- Реализовать корректный OAuth-поток с PKCE (Proof Key for Code Exchange) для запросов авторизации.
- Строго проверять redirect URI и идентификаторы клиентов.

### 2. Уязвимости, связанные с передачей токенов

Передача токенов происходит, когда MCP-сервер принимает токены от MCP-клиента без проверки, что эти токены были выданы именно для MCP-сервера, и передаёт их дальше в API.

### Риски
- Обход механизмов безопасности (например, ограничений по количеству запросов, проверок запросов)
- Проблемы с ответственностью и аудитом
- Нарушение границ доверия
- Риски совместимости в будущем

**Меры защиты:**
- MCP-серверы НЕ ДОЛЖНЫ принимать токены, не выданные явно для них.
- Всегда проверяйте аудиторию токена, чтобы убедиться, что она соответствует ожидаемому сервису.

### 3. Перехват сессии

Происходит, когда злоумышленник получает идентификатор сессии и использует его для выдачи себя за оригинального клиента, что может привести к несанкционированным действиям.

**Меры защиты:**
- MCP-серверы, реализующие авторизацию, ДОЛЖНЫ проверять все входящие запросы и НЕ ДОЛЖНЫ использовать сессии для аутентификации.
- Используйте безопасные, недетерминированные идентификаторы сессий, сгенерированные с помощью криптографически стойких генераторов случайных чисел.
- Связывайте идентификаторы сессий с информацией о пользователе в формате `<user_id>:<session_id>`.
- Реализуйте корректные политики истечения срока действия и ротации сессий.

## Дополнительные лучшие практики безопасности для MCP

Помимо основных требований безопасности MCP, рекомендуется применять следующие меры:

- **Всегда используйте HTTPS**: Шифруйте коммуникацию между клиентом и сервером, чтобы защитить токены от перехвата.
- **Реализуйте ролевой контроль доступа (RBAC)**: Проверяйте не только аутентификацию пользователя, но и его права.
- **Мониторинг и аудит**: Логируйте все события аутентификации для обнаружения и реагирования на подозрительную активность.
- **Обработка ограничений по количеству запросов и троттлинг**: Реализуйте экспоненциальное увеличение задержек и логику повторных попыток для корректной обработки лимитов.
- **Безопасное хранение токенов**: Храните access и refresh токены с использованием системных механизмов безопасного хранения или сервисов управления ключами.
- **Рассмотрите использование API Management**: Сервисы вроде Azure API Management могут автоматически решать многие вопросы безопасности, включая аутентификацию, авторизацию и ограничение запросов.

## Ссылки

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Что дальше

- [5.9 Web search](../web-search-mcp/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному человеческому переводу. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.