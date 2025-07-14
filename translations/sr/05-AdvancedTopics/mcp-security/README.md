<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:44:25+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sr"
}
-->
# Најбоље праксе безбедности

Безбедност је кључна за имплементације MCP-а, посебно у пословним окружењима. Важно је обезбедити да алати и подаци буду заштићени од неовлашћеног приступа, цурења података и других безбедносних претњи.

## Увод

У овој лекцији ћемо истражити најбоље праксе безбедности за имплементације MCP-а. Обрадићемо аутентификацију и ауторизацију, заштиту података, безбедно извршавање алата и усаглашеност са прописима о заштити података.

## Циљеви учења

На крају ове лекције моћи ћете да:

- Имплементирате безбедне механизме аутентификације и ауторизације за MCP сервере.
- Заштитите осетљиве податке коришћењем енкрипције и безбедног складиштења.
- Обезбедите безбедно извршавање алата уз одговарајуће контроле приступа.
- Примените најбоље праксе за заштиту података и усаглашеност са прописима о приватности.

## Аутентификација и ауторизација

Аутентификација и ауторизација су неопходни за обезбеђивање MCP сервера. Аутентификација одговара на питање „Ко сте ви?“, док ауторизација одговара на питање „Шта можете да урадите?“.

Погледајмо примере како да имплементирамо безбедну аутентификацију и ауторизацију на MCP серверима користећи .NET и Јаву.

### .NET интеграција идентитета

ASP .NET Core Identity пружа робустан оквир за управљање аутентификацијом и ауторизацијом корисника. Можемо га интегрисати са MCP серверима како бисмо обезбедили приступ алатима и ресурсима.

Постоје неки основни појмови које треба разумети приликом интеграције ASP.NET Core Identity са MCP серверима, а то су:

- **Конфигурација идентитета**: Подешавање ASP.NET Core Identity са корисничким улогама и захтевима (claims). Захтев је информација о кориснику, као што је његова улога или дозволе, на пример „Admin“ или „User“.
- **JWT аутентификација**: Коришћење JSON Web Token-а (JWT) за безбедан приступ API-ју. JWT је стандард за безбедан пренос информација између страна као JSON објекат, који се може верификовати и коме се може веровати јер је дигитално потписан.
- **Политике ауторизације**: Дефинисање политика за контролу приступа одређеним алатима на основу корисничких улога. MCP користи политике ауторизације да одреди који корисници могу приступити којим алатима на основу својих улога и захтева.

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

У претходном коду смо:

- Конфигурисали ASP.NET Core Identity за управљање корисницима.
- Подесили JWT аутентификацију за безбедан приступ API-ју. Навели смо параметре валидације токена, укључујући издавача, публику и кључ за потписивање.
- Дефинисали политике ауторизације за контролу приступа алатима на основу корисничких улога. На пример, политика „CanUseAdminTools“ захтева да корисник има улогу „Admin“, док политика „CanUseBasic“ захтева да корисник буде аутентификован.
- Регистровали MCP алате са специфичним захтевима за ауторизацију, осигуравајући да само корисници са одговарајућим улогама могу да им приступе.

### Java Spring Security интеграција

За Јаву ћемо користити Spring Security за имплементацију безбедне аутентификације и ауторизације за MCP сервере. Spring Security пружа свеобухватан безбедносни оквир који се беспрекорно интегрише са Spring апликацијама.

Основни појмови су:

- **Конфигурација Spring Security**: Подешавање безбедносних конфигурација за аутентификацију и ауторизацију.
- **OAuth2 Resource Server**: Коришћење OAuth2 за безбедан приступ MCP алатима. OAuth2 је оквир за ауторизацију који омогућава трећим странама да размењују приступне токене за безбедан приступ API-ју.
- **Безбедносни интерцептори**: Имплементација безбедносних интерцептора за спровођење контрола приступа приликом извршавања алата.
- **Контрола приступа заснована на улогама**: Коришћење улога за контролу приступа одређеним алатима и ресурсима.
- **Безбедносне анотације**: Коришћење анотација за обезбеђивање метода и крајњих тачака.

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

У претходном коду смо:

- Конфигурисали Spring Security за обезбеђење MCP крајњих тачака, дозвољавајући јавни приступ откривању алата, док је за извршавање алата потребна аутентификација.
- Користили OAuth2 као ресурсни сервер за руковање безбедним приступом MCP алатима.
- Имплементирали безбедносни интерцептор за спровођење контрола приступа приликом извршавања алата, проверавајући корисничке улоге и дозволе пре него што се омогући приступ одређеним алатима.
- Дефинисали контролу приступа засновану на улогама како бисмо ограничили приступ администраторским алатима и приступ осетљивим подацима на основу корисничких улога.

## Заштита података и приватност

Заштита података је од суштинског значаја за обезбеђивање да се осетљиве информације обрађују на безбедан начин. Ово укључује заштиту лично идентификационих података (PII), финансијских података и других осетљивих информација од неовлашћеног приступа и цурења.

### Пример заштите података у Python-у

Погледајмо пример како да имплементирамо заштиту података у Python-у користећи енкрипцију и детекцију PII.

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

У претходном коду смо:

- Имплементирали класу `PiiDetector` за скенирање текста и параметара у потрази за лично идентификационим подацима (PII).
- Креирали класу `EncryptionService` за руковање енкрипцијом и дешифровањем осетљивих података користећи библиотеку `cryptography`.
- Дефинисали декоратор `secure_tool` који обавија извршавање алата како би проверио PII, евидентирао приступ и енкриптовао осетљиве податке ако је потребно.
- Применили декоратор `secure_tool` на пример алата (`SecureCustomerDataTool`) како бисмо осигурали да безбедно рукује осетљивим подацима.

## Шта следи

- [5.9 Web search](../web-search-mcp/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.