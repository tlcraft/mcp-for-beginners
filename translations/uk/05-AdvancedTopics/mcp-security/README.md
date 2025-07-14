<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:45:32+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "uk"
}
-->
# Найкращі практики безпеки

Безпека є критичною для впроваджень MCP, особливо в корпоративних середовищах. Важливо забезпечити захист інструментів і даних від несанкціонованого доступу, витоків інформації та інших загроз безпеці.

## Вступ

У цьому уроці ми розглянемо найкращі практики безпеки для впроваджень MCP. Ми охопимо аутентифікацію та авторизацію, захист даних, безпечне виконання інструментів та дотримання вимог щодо конфіденційності даних.

## Цілі навчання

Після завершення цього уроку ви зможете:

- Реалізувати безпечні механізми аутентифікації та авторизації для MCP серверів.
- Захищати конфіденційні дані за допомогою шифрування та безпечного зберігання.
- Забезпечувати безпечне виконання інструментів із належним контролем доступу.
- Застосовувати найкращі практики захисту даних та дотримання вимог конфіденційності.

## Аутентифікація та авторизація

Аутентифікація та авторизація є необхідними для захисту MCP серверів. Аутентифікація відповідає на питання «Хто ви?», а авторизація — «Що ви можете робити?».

Розглянемо приклади реалізації безпечної аутентифікації та авторизації на MCP серверах за допомогою .NET та Java.

### Інтеграція .NET Identity

ASP .NET Core Identity надає надійну платформу для керування аутентифікацією та авторизацією користувачів. Ми можемо інтегрувати її з MCP серверами для захисту доступу до інструментів і ресурсів.

Існують основні поняття, які потрібно розуміти при інтеграції ASP.NET Core Identity з MCP серверами, а саме:

- **Конфігурація Identity**: Налаштування ASP.NET Core Identity з ролями користувачів та їхніми правами (claims). Claim — це інформація про користувача, наприклад його роль або дозволи, наприклад «Admin» або «User».
- **JWT аутентифікація**: Використання JSON Web Tokens (JWT) для безпечного доступу до API. JWT — це стандарт для безпечної передачі інформації між сторонами у вигляді JSON-об’єкта, який можна перевірити та довіряти йому, оскільки він цифрово підписаний.
- **Політики авторизації**: Визначення політик для контролю доступу до конкретних інструментів на основі ролей користувачів. MCP використовує політики авторизації, щоб визначити, які користувачі можуть отримати доступ до яких інструментів залежно від їхніх ролей і прав.

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

У наведеному коді ми:

- Налаштували ASP.NET Core Identity для керування користувачами.
- Впровадили JWT аутентифікацію для безпечного доступу до API. Вказали параметри перевірки токена, включно з видавцем, аудиторією та ключем підпису.
- Визначили політики авторизації для контролю доступу до інструментів на основі ролей користувачів. Наприклад, політика «CanUseAdminTools» вимагає роль «Admin», а політика «CanUseBasic» — щоб користувач був автентифікований.
- Зареєстрували інструменти MCP з конкретними вимогами авторизації, забезпечуючи доступ лише користувачам з відповідними ролями.

### Інтеграція Java Spring Security

Для Java ми використаємо Spring Security для реалізації безпечної аутентифікації та авторизації MCP серверів. Spring Security надає комплексний фреймворк безпеки, який легко інтегрується з додатками Spring.

Основні поняття тут:

- **Конфігурація Spring Security**: Налаштування безпеки для аутентифікації та авторизації.
- **OAuth2 Resource Server**: Використання OAuth2 для безпечного доступу до інструментів MCP. OAuth2 — це фреймворк авторизації, який дозволяє стороннім сервісам обмінюватися токенами доступу для безпечного доступу до API.
- **Інтерцептори безпеки**: Реалізація інтерцепторів безпеки для забезпечення контролю доступу під час виконання інструментів.
- **Контроль доступу на основі ролей**: Використання ролей для контролю доступу до конкретних інструментів і ресурсів.
- **Анотації безпеки**: Використання анотацій для захисту методів і кінцевих точок.

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

У наведеному коді ми:

- Налаштували Spring Security для захисту MCP кінцевих точок, дозволяючи публічний доступ до пошуку інструментів і вимагаючи аутентифікацію для їх виконання.
- Використали OAuth2 як ресурсний сервер для обробки безпечного доступу до інструментів MCP.
- Реалізували інтерцептор безпеки для контролю доступу під час виконання інструментів, перевіряючи ролі та дозволи користувача перед наданням доступу до конкретних інструментів.
- Визначили контроль доступу на основі ролей для обмеження доступу до адміністративних інструментів і конфіденційних даних залежно від ролей користувачів.

## Захист даних і конфіденційність

Захист даних є надзвичайно важливим для забезпечення безпечної обробки конфіденційної інформації. Це включає захист персональних даних (PII), фінансової інформації та інших чутливих даних від несанкціонованого доступу та витоків.

### Приклад захисту даних на Python

Розглянемо приклад реалізації захисту даних на Python за допомогою шифрування та виявлення PII.

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

У наведеному коді ми:

- Реалізували клас `PiiDetector` для сканування тексту та параметрів на наявність персональних даних (PII).
- Створили клас `EncryptionService` для шифрування та дешифрування конфіденційних даних за допомогою бібліотеки `cryptography`.
- Визначили декоратор `secure_tool`, який обгортає виконання інструменту, перевіряє наявність PII, веде журнал доступу та шифрує конфіденційні дані за потреби.
- Застосували декоратор `secure_tool` до прикладного інструменту (`SecureCustomerDataTool`), щоб гарантувати безпечну обробку конфіденційних даних.

## Що далі

- [5.9 Web search](../web-search-mcp/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.