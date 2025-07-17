<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T11:29:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "bg"
}
-->
# Най-добри практики за сигурност

Сигурността е от съществено значение за имплементациите на MCP, особено в корпоративни среди. Важно е да се гарантира, че инструментите и данните са защитени от неоторизиран достъп, изтичане на данни и други заплахи за сигурността.

## Въведение

Model Context Protocol (MCP) изисква специфични съображения за сигурност поради ролята си да предоставя на LLM достъп до данни и инструменти. Този урок разглежда най-добрите практики за сигурност при имплементации на MCP, базирани на официалните насоки на MCP и утвърдени модели за сигурност.

MCP следва ключови принципи за сигурност, за да осигури безопасни и надеждни взаимодействия:

- **Съгласие и контрол от потребителя**: Потребителите трябва да дадат изрично съгласие преди достъп до данни или извършване на операции. Осигурете ясен контрол върху това какви данни се споделят и кои действия са разрешени.
  
- **Поверителност на данните**: Данните на потребителя трябва да се разкриват само с изрично съгласие и да са защитени с подходящи контролни механизми за достъп. Предпазвайте от неоторизирано предаване на данни.
  
- **Безопасност на инструментите**: Преди да се извика някой инструмент, е необходимо изричното съгласие на потребителя. Потребителите трябва ясно да разбират функционалността на всеки инструмент, а сигурните граници трябва да се налагат стриктно.

## Учебни цели

След края на този урок ще можете да:

- Имплементирате сигурни механизми за удостоверяване и упълномощаване за MCP сървъри.
- Защитите чувствителни данни чрез криптиране и сигурно съхранение.
- Осигурите сигурно изпълнение на инструменти с подходящи контролни механизми за достъп.
- Прилагате най-добри практики за защита на данните и съответствие с изискванията за поверителност.
- Идентифицирате и смекчавате често срещани уязвимости в сигурността на MCP като проблеми с объркания посредник, token passthrough и отвличане на сесии.

## Удостоверяване и упълномощаване

Удостоверяването и упълномощаването са ключови за защитата на MCP сървърите. Удостоверяването отговаря на въпроса „Кой си ти?“, а упълномощаването – „Какво можеш да правиш?“.

Според спецификацията за сигурност на MCP, следните са критични съображения:

1. **Валидиране на токени**: MCP сървърите НЕ ТРЯБВА да приемат токени, които не са изрично издадени за този MCP сървър. „Token passthrough“ е изрично забранен анти-патърн.

2. **Проверка на упълномощаването**: MCP сървърите, които имплементират упълномощаване, ТРЯБВА да проверяват всички входящи заявки и НЕ ТРЯБВА да използват сесии за удостоверяване.

3. **Сигурно управление на сесии**: При използване на сесии за състояние, MCP сървърите ТРЯБВА да използват сигурни, недетерминирани идентификатори на сесии, генерирани с помощта на сигурни генератори на случайни числа. Идентификаторите на сесии ТРЯБВА да бъдат свързани с информация, специфична за потребителя.

4. **Изрично съгласие на потребителя**: За прокси сървъри, имплементациите на MCP ТРЯБВА да получават съгласие от потребителя за всеки динамично регистриран клиент преди препращане към трети страни за упълномощаване.

Нека разгледаме примери за това как да се имплементират сигурно удостоверяване и упълномощаване в MCP сървъри с помощта на .NET и Java.

### Интеграция с .NET Identity

ASP .NET Core Identity предоставя стабилна рамка за управление на удостоверяването и упълномощаването на потребители. Можем да я интегрираме с MCP сървъри, за да защитим достъпа до инструменти и ресурси.

Има някои основни концепции, които трябва да разберем при интеграцията на ASP.NET Core Identity с MCP сървъри, а именно:

- **Конфигурация на Identity**: Настройване на ASP.NET Core Identity с потребителски роли и претенции. Претенцията е информация за потребителя, като например ролята му или разрешенията му, например „Admin“ или „User“.
- **JWT удостоверяване**: Използване на JSON Web Tokens (JWT) за сигурен достъп до API. JWT е стандарт за сигурно предаване на информация между страни като JSON обект, който може да бъде проверен и се доверява, тъй като е цифрово подписан.
- **Политики за упълномощаване**: Дефиниране на политики за контрол на достъпа до конкретни инструменти въз основа на потребителски роли. MCP използва политики за упълномощаване, за да определи кои потребители могат да имат достъп до кои инструменти според техните роли и претенции.

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

В горния код сме:

- Конфигурирали ASP.NET Core Identity за управление на потребителите.
- Настроили JWT удостоверяване за сигурен достъп до API, като сме задали параметрите за валидиране на токена, включително издателя, аудиторията и ключа за подписване.
- Дефинирали политики за упълномощаване за контрол на достъпа до инструменти според потребителските роли. Например, политиката „CanUseAdminTools“ изисква потребителят да има ролята „Admin“, докато „CanUseBasic“ изисква потребителят да е удостоверен.
- Регистрирали MCP инструменти с конкретни изисквания за упълномощаване, гарантирайки, че само потребители с подходящите роли имат достъп до тях.

### Интеграция с Java Spring Security

За Java ще използваме Spring Security за имплементиране на сигурно удостоверяване и упълномощаване за MCP сървъри. Spring Security предоставя цялостна рамка за сигурност, която се интегрира безпроблемно със Spring приложения.

Основните концепции тук са:

- **Конфигурация на Spring Security**: Настройване на конфигурации за удостоверяване и упълномощаване.
- **OAuth2 Resource Server**: Използване на OAuth2 за сигурен достъп до MCP инструменти. OAuth2 е рамка за упълномощаване, която позволява на трети страни да обменят токени за достъп за сигурен API достъп.
- **Сигурност чрез интерсептори**: Имплементиране на интерсептори за сигурност, които налагат контрол на достъпа при изпълнение на инструменти.
- **Контрол на достъпа на базата на роли**: Използване на роли за контрол на достъпа до конкретни инструменти и ресурси.
- **Анотации за сигурност**: Използване на анотации за защита на методи и крайни точки.

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

В горния код сме:

- Конфигурирали Spring Security за защита на MCP крайни точки, позволявайки публичен достъп до откриване на инструменти, като изискваме удостоверяване за изпълнение на инструменти.
- Използвали OAuth2 като ресурсен сървър за обработка на сигурен достъп до MCP инструменти.
- Имплементирали интерсептор за сигурност, който налага контрол на достъпа при изпълнение на инструменти, проверявайки роли и разрешения на потребителя преди да разреши достъп до конкретни инструменти.
- Дефинирали контрол на достъпа на базата на роли, за да ограничим достъпа до администраторски инструменти и достъп до чувствителни данни според потребителските роли.

## Защита на данните и поверителност

Защитата на данните е от ключово значение за гарантиране, че чувствителната информация се обработва сигурно. Това включва защита на лични данни (PII), финансови данни и друга чувствителна информация от неоторизиран достъп и изтичане.

### Пример за защита на данни с Python

Нека разгледаме пример за това как да се имплементира защита на данни в Python чрез криптиране и откриване на PII.

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

В горния код сме:

- Имплементирали клас `PiiDetector`, който сканира текст и параметри за лична идентифицираща информация (PII).
- Създали клас `EncryptionService`, който обработва криптиране и декриптиране на чувствителни данни с помощта на библиотеката `cryptography`.
- Дефинирали декоратор `secure_tool`, който обвива изпълнението на инструменти, за да проверява за PII, да записва достъпа и да криптира чувствителните данни при необходимост.
- Приложили декоратора `secure_tool` към примерен инструмент (`SecureCustomerDataTool`), за да гарантираме, че той обработва чувствителните данни сигурно.

## Специфични рискове за сигурността при MCP

Според официалната документация за сигурност на MCP, има специфични рискове, за които разработчиците на MCP трябва да са наясно:

### 1. Проблемът с объркания посредник (Confused Deputy)

Тази уязвимост възниква, когато MCP сървър действа като прокси към API-та на трети страни, което може да позволи на нападатели да експлоатират доверието между MCP сървъра и тези API-та.

**Смекчаване:**
- MCP прокси сървърите, използващи статични клиентски идентификатори, ТРЯБВА да получават съгласие от потребителя за всеки динамично регистриран клиент преди препращане към трети страни за упълномощаване.
- Имплементирайте правилен OAuth поток с PKCE (Proof Key for Code Exchange) за заявки за упълномощаване.
- Стриктно валидирайте redirect URI-та и клиентските идентификатори.

### 2. Уязвимости при token passthrough

Token passthrough възниква, когато MCP сървър приема токени от MCP клиент без да валидира, че токените са издадени правилно за MCP сървъра и ги препраща към downstream API-та.

### Рискове
- Заобикаляне на контролите за сигурност (например ограничаване на честотата, валидиране на заявки)
- Проблеми с отчетността и одитния след
- Нарушаване на границите на доверие
- Рискове за съвместимост в бъдеще

**Смекчаване:**
- MCP сървърите НЕ ТРЯБВА да приемат токени, които не са изрично издадени за MCP сървъра.
- Винаги валидирайте претенциите за аудитория на токена, за да се уверите, че съвпадат с очакваната услуга.

### 3. Отвличане на сесия (Session Hijacking)

Това се случва, когато неоторизирана страна получи идентификатор на сесия и го използва, за да се представи за оригиналния клиент, което може да доведе до неоторизирани действия.

**Смекчаване:**
- MCP сървърите, които имплементират упълномощаване, ТРЯБВА да проверяват всички входящи заявки и НЕ ТРЯБВА да използват сесии за удостоверяване.
- Използвайте сигурни, недетерминирани идентификатори на сесии, генерирани с помощта на сигурни генератори на случайни числа.
- Свържете идентификаторите на сесии с информация, специфична за потребителя, използвайки формат на ключа като `<user_id>:<session_id>`.
- Имплементирайте правилни политики за изтичане и ротация на сесиите.

## Допълнителни най-добри практики за сигурност при MCP

Освен основните съображения за сигурност на MCP, обмислете прилагането на следните допълнителни практики:

- **Винаги използвайте HTTPS**: Криптирайте комуникацията между клиента и сървъра, за да защитите токените от прихващане.
- **Прилагайте контрол на достъпа на базата на роли (RBAC)**: Не проверявайте само дали потребителят е удостоверен, а и какво е упълномощен да прави.
- **Мониторинг и одит**: Записвайте всички събития по удостоверяване, за да откривате и реагирате на подозрителна активност.
- **Обработка на ограничаване на честотата и throttling**: Имплементирайте експоненциално изчакване и логика за повторен опит, за да се справяте с ограниченията на честотата по плавен начин.
- **Сигурно съхранение на токени**: Съхранявайте токените за достъп и обновяване сигурно, използвайки системни механизми за сигурно съхранение или услуги за управление на ключове.
- **Обмислете използването на API Management**: Услуги като Azure API Management могат автоматично да се справят с много въпроси по сигурността, включително удостоверяване, упълномощаване и ограничаване на честотата.

## Референции

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Какво следва

- [5.9 Web search](../web-search-mcp/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.