<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:43:23+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "cs"
}
-->
# Nejlepší bezpečnostní postupy

Bezpečnost je klíčová pro implementace MCP, zejména v podnikových prostředích. Je důležité zajistit, aby nástroje a data byly chráněny před neoprávněným přístupem, úniky dat a dalšími bezpečnostními hrozbami.

## Úvod

V této lekci se zaměříme na nejlepší bezpečnostní postupy pro implementace MCP. Probereme autentizaci a autorizaci, ochranu dat, bezpečné spouštění nástrojů a dodržování předpisů o ochraně osobních údajů.

## Cíle učení

Na konci této lekce budete schopni:

- Implementovat bezpečné mechanismy autentizace a autorizace pro MCP servery.
- Chránit citlivá data pomocí šifrování a bezpečného ukládání.
- Zajistit bezpečné spouštění nástrojů s odpovídajícími přístupovými kontrolami.
- Aplikovat nejlepší postupy pro ochranu dat a dodržování pravidel ochrany soukromí.

## Autentizace a autorizace

Autentizace a autorizace jsou nezbytné pro zabezpečení MCP serverů. Autentizace odpovídá na otázku „Kdo jste?“, zatímco autorizace na otázku „Co můžete dělat?“.

Podívejme se na příklady, jak implementovat bezpečnou autentizaci a autorizaci v MCP serverech pomocí .NET a Javy.

### Integrace .NET Identity

ASP .NET Core Identity poskytuje robustní rámec pro správu autentizace a autorizace uživatelů. Můžeme jej integrovat s MCP servery, aby byl přístup k nástrojům a zdrojům zabezpečený.

Při integraci ASP.NET Core Identity s MCP servery je třeba pochopit několik základních konceptů:

- **Konfigurace Identity**: Nastavení ASP.NET Core Identity s uživatelskými rolemi a nároky (claims). Nárok je informace o uživateli, například jeho role nebo oprávnění, například „Admin“ nebo „User“.
- **JWT autentizace**: Použití JSON Web Tokenů (JWT) pro bezpečný přístup k API. JWT je standard pro bezpečný přenos informací mezi stranami jako JSON objekt, který lze ověřit a důvěřovat mu, protože je digitálně podepsaný.
- **Autorizacní politiky**: Definování politik pro řízení přístupu k určitým nástrojům na základě uživatelských rolí. MCP používá autorizacní politiky k určení, kteří uživatelé mají přístup k jakým nástrojům podle jejich rolí a nároků.

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

V předchozím kódu jsme:

- Nakonfigurovali ASP.NET Core Identity pro správu uživatelů.
- Nastavili JWT autentizaci pro bezpečný přístup k API. Specifikovali jsme parametry ověřování tokenu, včetně vydavatele, publika a klíče pro podepisování.
- Definovali autorizacní politiky pro řízení přístupu k nástrojům na základě uživatelských rolí. Například politika „CanUseAdminTools“ vyžaduje, aby uživatel měl roli „Admin“, zatímco politika „CanUseBasic“ vyžaduje, aby byl uživatel autentizovaný.
- Registrovali MCP nástroje s konkrétními požadavky na autorizaci, čímž jsme zajistili, že k nim mají přístup pouze uživatelé s odpovídajícími rolemi.

### Integrace Java Spring Security

Pro Javu použijeme Spring Security k implementaci bezpečné autentizace a autorizace pro MCP servery. Spring Security poskytuje komplexní bezpečnostní rámec, který se hladce integruje se Spring aplikacemi.

Základní koncepty jsou:

- **Konfigurace Spring Security**: Nastavení bezpečnostních konfigurací pro autentizaci a autorizaci.
- **OAuth2 Resource Server**: Použití OAuth2 pro bezpečný přístup k MCP nástrojům. OAuth2 je autorizační rámec, který umožňuje třetím stranám vyměňovat přístupové tokeny pro bezpečný přístup k API.
- **Bezpečnostní interceptory**: Implementace bezpečnostních interceptorů pro vynucení přístupových kontrol při spouštění nástrojů.
- **Řízení přístupu na základě rolí**: Použití rolí k řízení přístupu k určitým nástrojům a zdrojům.
- **Bezpečnostní anotace**: Použití anotací k zabezpečení metod a endpointů.

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

V předchozím kódu jsme:

- Nakonfigurovali Spring Security pro zabezpečení MCP endpointů, umožňující veřejný přístup k objevování nástrojů a vyžadující autentizaci pro jejich spouštění.
- Použili OAuth2 jako resource server pro správu bezpečného přístupu k MCP nástrojům.
- Implementovali bezpečnostní interceptor pro vynucení přístupových kontrol při spouštění nástrojů, kontrolující uživatelské role a oprávnění před povolením přístupu k určitým nástrojům.
- Definovali řízení přístupu na základě rolí pro omezení přístupu k administrátorským nástrojům a citlivým datům podle uživatelských rolí.

## Ochrana dat a soukromí

Ochrana dat je zásadní pro zajištění bezpečného nakládání s citlivými informacemi. To zahrnuje ochranu osobních identifikovatelných údajů (PII), finančních dat a dalších citlivých informací před neoprávněným přístupem a úniky.

### Příklad ochrany dat v Pythonu

Podívejme se na příklad, jak implementovat ochranu dat v Pythonu pomocí šifrování a detekce PII.

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

V předchozím kódu jsme:

- Implementovali třídu `PiiDetector` pro skenování textu a parametrů na osobní identifikovatelné informace (PII).
- Vytvořili třídu `EncryptionService` pro šifrování a dešifrování citlivých dat pomocí knihovny `cryptography`.
- Definovali dekorátor `secure_tool`, který obaluje spouštění nástroje, aby kontroloval PII, zaznamenával přístupy a v případě potřeby šifroval citlivá data.
- Aplikovali dekorátor `secure_tool` na ukázkový nástroj (`SecureCustomerDataTool`), aby bylo zajištěno bezpečné nakládání s citlivými daty.

## Co dál

- [5.9 Web search](../web-search-mcp/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.