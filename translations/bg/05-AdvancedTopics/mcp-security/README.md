<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-13T01:11:33+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "bg"
}
-->
# Най-добри практики за сигурност

Сигурността е от ключово значение за имплементациите на MCP, особено в корпоративни среди. Важно е да се гарантира, че инструментите и данните са защитени от неоторизиран достъп, изтичане на данни и други заплахи за сигурността.

## Въведение

В този урок ще разгледаме най-добрите практики за сигурност при имплементации на MCP. Ще покрием автентикация и авторизация, защита на данните, сигурно изпълнение на инструменти и съответствие с регулациите за поверителност на данните.

## Учебни цели

След края на този урок ще можете да:

- Прилагате сигурни механизми за автентикация и авторизация за MCP сървъри.
- Защитавате чувствителни данни чрез криптиране и сигурно съхранение.
- Осигурявате сигурно изпълнение на инструменти с подходящи контроли за достъп.
- Прилагате най-добри практики за защита на данните и съответствие с изискванията за поверителност.

## Автентикация и авторизация

Автентикацията и авторизацията са съществени за защитата на MCP сървърите. Автентикацията отговаря на въпроса „Кой си ти?“, а авторизацията – „Какво можеш да правиш?“.

Нека разгледаме примери за това как да се имплементират сигурна автентикация и авторизация в MCP сървъри с помощта на .NET и Java.

### Интеграция на .NET Identity

ASP .NET Core Identity предоставя стабилна рамка за управление на автентикацията и авторизацията на потребители. Можем да го интегрираме с MCP сървъри, за да осигурим защитен достъп до инструменти и ресурси.

Има някои основни концепции, които трябва да разберем при интеграция на ASP.NET Core Identity с MCP сървъри, а именно:

- **Конфигурация на Identity**: Настройване на ASP.NET Core Identity с потребителски роли и претенции. Претенцията е част от информация за потребителя, като например ролята му или разрешения, например „Admin“ или „User“.
- **JWT автентикация**: Използване на JSON Web Tokens (JWT) за сигурен достъп до API. JWT е стандарт за сигурно предаване на информация между страни като JSON обект, който може да бъде проверен и се доверява, защото е цифрово подписан.
- **Политики за авторизация**: Дефиниране на политики за контрол на достъпа до конкретни инструменти според ролите на потребителите. MCP използва политики за авторизация, за да определи кои потребители могат да имат достъп до кои инструменти според техните роли и претенции.

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
- Настроили JWT автентикация за сигурен достъп до API. Определихме параметрите за валидиране на токена, включително издателя, аудиторията и ключа за подписване.
- Дефинирали политики за авторизация за контрол на достъпа до инструменти според ролите на потребителите. Например, политиката „CanUseAdminTools“ изисква потребителят да има ролята „Admin“, докато „CanUseBasic“ изисква потребителят да е автентикиран.
- Регистрирали MCP инструменти с конкретни изисквания за авторизация, като гарантираме, че само потребители с подходящите роли имат достъп до тях.

### Интеграция на Java Spring Security

За Java ще използваме Spring Security за имплементиране на сигурна автентикация и авторизация за MCP сървъри. Spring Security предоставя цялостна рамка за сигурност, която се интегрира безпроблемно със Spring приложения.

Основните концепции тук са:

- **Конфигурация на Spring Security**: Настройване на конфигурации за автентикация и авторизация.
- **OAuth2 Resource Server**: Използване на OAuth2 за сигурен достъп до MCP инструменти. OAuth2 е рамка за авторизация, която позволява на трети страни да обменят токени за достъп за сигурен API достъп.
- **Сигурност чрез интерсептори**: Имплементиране на интерсептори за сигурност, които налагат контроли за достъп при изпълнение на инструменти.
- **Контрол на достъпа базиран на роли**: Използване на роли за контрол на достъпа до конкретни инструменти и ресурси.
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

- Конфигурирали Spring Security за защита на MCP крайни точки, позволявайки публичен достъп до откриване на инструменти и изисквайки автентикация за изпълнение на инструменти.
- Използвали OAuth2 като ресурсен сървър за обработка на сигурен достъп до MCP инструменти.
- Имплементирали интерсептор за сигурност, който налага контроли за достъп при изпълнение на инструменти, проверявайки ролите и разрешенията на потребителя преди да позволи достъп до конкретни инструменти.
- Дефинирали контрол на достъпа базиран на роли за ограничаване на достъпа до администраторски инструменти и чувствителни данни според ролите на потребителите.

## Защита на данните и поверителност

Защитата на данните е от съществено значение за гарантиране, че чувствителната информация се обработва сигурно. Това включва защита на лични данни (PII), финансови данни и друга чувствителна информация от неоторизиран достъп и изтичания.

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

- Имплементирали `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`, за да гарантираме, че обработва чувствителните данни по сигурен начин.

## Какво следва

- [5.9 Web search](../web-search-mcp/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматичните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия оригинален език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за никакви недоразумения или неправилни тълкувания, възникнали от използването на този превод.