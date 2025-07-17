<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T10:43:18+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "cs"
}
-->
# Nejlepší bezpečnostní postupy

Bezpečnost je klíčová pro implementace MCP, zejména v podnikových prostředích. Je důležité zajistit, aby nástroje a data byly chráněny před neoprávněným přístupem, úniky dat a dalšími bezpečnostními hrozbami.

## Úvod

Model Context Protocol (MCP) vyžaduje specifická bezpečnostní opatření vzhledem ke své roli při poskytování LLM přístupu k datům a nástrojům. Tato lekce se zabývá nejlepšími bezpečnostními postupy pro implementace MCP na základě oficiálních pokynů MCP a zavedených bezpečnostních vzorů.

MCP dodržuje klíčové bezpečnostní principy, aby zajistil bezpečné a důvěryhodné interakce:

- **Souhlas a kontrola uživatele**: Uživatelé musí výslovně souhlasit před tím, než jsou data zpřístupněna nebo provedeny operace. Poskytněte jasnou kontrolu nad tím, jaká data jsou sdílena a jaké akce jsou povoleny.
  
- **Ochrana soukromí dat**: Uživatelská data by měla být zpřístupněna pouze s výslovným souhlasem a musí být chráněna vhodnými přístupovými kontrolami. Zabraňte neoprávněnému přenosu dat.
  
- **Bezpečnost nástrojů**: Před vyvoláním jakéhokoli nástroje je vyžadován výslovný souhlas uživatele. Uživatelé by měli mít jasnou představu o funkčnosti každého nástroje a musí být vynuceny pevné bezpečnostní hranice.

## Cíle učení

Na konci této lekce budete schopni:

- Implementovat bezpečné mechanismy autentizace a autorizace pro MCP servery.
- Chránit citlivá data pomocí šifrování a bezpečného ukládání.
- Zajistit bezpečné provádění nástrojů s odpovídajícími přístupovými kontrolami.
- Aplikovat nejlepší postupy pro ochranu dat a dodržování pravidel ochrany soukromí.
- Identifikovat a zmírnit běžné bezpečnostní zranitelnosti MCP, jako jsou problémy s confused deputy, token passthrough a session hijacking.

## Autentizace a autorizace

Autentizace a autorizace jsou nezbytné pro zabezpečení MCP serverů. Autentizace odpovídá na otázku „Kdo jste?“, zatímco autorizace na otázku „Co můžete dělat?“.

Podle bezpečnostní specifikace MCP jsou tyto aspekty klíčové:

1. **Validace tokenů**: MCP servery NESMÍ přijímat žádné tokeny, které nebyly výslovně vydány pro daný MCP server. „Token passthrough“ je výslovně zakázaný anti-vzor.

2. **Ověření autorizace**: MCP servery, které implementují autorizaci, MUSÍ ověřovat všechny příchozí požadavky a NESMÍ používat session pro autentizaci.

3. **Bezpečná správa session**: Při použití session pro stav musí MCP servery používat bezpečné, nedeterministické session ID generované pomocí bezpečných generátorů náhodných čísel. Session ID MĚLA být vázána na uživatelsky specifické informace.

4. **Výslovný souhlas uživatele**: U proxy serverů musí implementace MCP získat souhlas uživatele pro každého dynamicky registrovaného klienta před přesměrováním na autorizaci třetích stran.

Podívejme se na příklady, jak implementovat bezpečnou autentizaci a autorizaci v MCP serverech pomocí .NET a Java.

### Integrace .NET Identity

ASP .NET Core Identity poskytuje robustní rámec pro správu autentizace a autorizace uživatelů. Můžeme jej integrovat s MCP servery pro zabezpečení přístupu k nástrojům a zdrojům.

Některé základní koncepty, které je třeba pochopit při integraci ASP.NET Core Identity s MCP servery, jsou:

- **Konfigurace Identity**: Nastavení ASP.NET Core Identity s uživatelskými rolemi a nároky (claims). Nárok je informace o uživateli, například jeho role nebo oprávnění, například „Admin“ nebo „User“.
- **JWT autentizace**: Použití JSON Web Tokenů (JWT) pro bezpečný přístup k API. JWT je standard pro bezpečný přenos informací mezi stranami jako JSON objekt, který lze ověřit a důvěřovat mu, protože je digitálně podepsaný.
- **Autorizacní politiky**: Definování politik pro kontrolu přístupu k určitým nástrojům na základě uživatelských rolí. MCP používá autorizacní politiky k určení, kteří uživatelé mají přístup k jakým nástrojům na základě jejich rolí a nároků.

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
- Nastavili JWT autentizaci pro bezpečný přístup k API. Specifikovali jsme parametry validace tokenu, včetně vydavatele, publika a podepisovacího klíče.
- Definovali autorizacní politiky pro kontrolu přístupu k nástrojům na základě uživatelských rolí. Například politika „CanUseAdminTools“ vyžaduje, aby uživatel měl roli „Admin“, zatímco politika „CanUseBasic“ vyžaduje, aby uživatel byl autentizován.
- Registrovali MCP nástroje s konkrétními požadavky na autorizaci, čímž jsme zajistili, že k nim mají přístup pouze uživatelé s odpovídajícími rolemi.

### Integrace Java Spring Security

Pro Javu použijeme Spring Security k implementaci bezpečné autentizace a autorizace pro MCP servery. Spring Security poskytuje komplexní bezpečnostní rámec, který se hladce integruje se Spring aplikacemi.

Základní koncepty jsou:

- **Konfigurace Spring Security**: Nastavení bezpečnostních konfigurací pro autentizaci a autorizaci.
- **OAuth2 Resource Server**: Použití OAuth2 pro bezpečný přístup k MCP nástrojům. OAuth2 je autorizační rámec, který umožňuje třetím stranám vyměňovat přístupové tokeny pro bezpečný přístup k API.
- **Bezpečnostní interceptory**: Implementace bezpečnostních interceptorů k vynucení přístupových kontrol při spouštění nástrojů.
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

- Nakonfigurovali Spring Security pro zabezpečení MCP endpointů, umožňující veřejný přístup k objevování nástrojů a vyžadující autentizaci pro jejich spuštění.
- Použili OAuth2 jako resource server pro zajištění bezpečného přístupu k MCP nástrojům.
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
- Definovali dekorátor `secure_tool`, který obaluje spuštění nástroje, aby kontroloval PII, zaznamenával přístupy a v případě potřeby šifroval citlivá data.
- Aplikovali dekorátor `secure_tool` na ukázkový nástroj (`SecureCustomerDataTool`), aby bylo zajištěno bezpečné nakládání s citlivými daty.

## Specifická bezpečnostní rizika MCP

Podle oficiální dokumentace MCP o bezpečnosti existují specifická bezpečnostní rizika, která by měli implementátoři MCP znát:

### 1. Problém confused deputy

Tato zranitelnost nastává, když MCP server funguje jako proxy pro API třetích stran, což může útočníkům umožnit zneužít důvěryhodný vztah mezi MCP serverem a těmito API.

**Zmírnění:**
- MCP proxy servery používající statická klientská ID MUSÍ získat souhlas uživatele pro každého dynamicky registrovaného klienta před přesměrováním na autorizaci třetích stran.
- Implementujte správný OAuth tok s PKCE (Proof Key for Code Exchange) pro autorizační požadavky.
- Přísně validujte přesměrovací URI a identifikátory klientů.

### 2. Zranitelnosti token passthrough

Token passthrough nastává, když MCP server přijímá tokeny od MCP klienta bez ověření, že tokeny byly správně vydány pro MCP server, a předává je dále do downstream API.

### Rizika
- Obcházení bezpečnostních kontrol (např. omezení počtu požadavků, validace požadavků)
- Problémy s odpovědností a auditní stopou
- Porušení hranic důvěry
- Rizika budoucí kompatibility

**Zmírnění:**
- MCP servery NESMÍ přijímat žádné tokeny, které nebyly výslovně vydány pro MCP server.
- Vždy validujte nároky publika tokenu, aby odpovídaly očekávané službě.

### 3. Session hijacking

K tomu dochází, když neoprávněná osoba získá session ID a použije ho k vydávání se za původního klienta, což může vést k neoprávněným akcím.

**Zmírnění:**
- MCP servery, které implementují autorizaci, MUSÍ ověřovat všechny příchozí požadavky a NESMÍ používat session pro autentizaci.
- Používejte bezpečné, nedeterministické session ID generované bezpečnými generátory náhodných čísel.
- Vázat session ID na uživatelsky specifické informace pomocí formátu klíče jako `<user_id>:<session_id>`.
- Implementujte správné politiky vypršení platnosti a rotace session.

## Další nejlepší bezpečnostní postupy pro MCP

Kromě základních bezpečnostních opatření MCP zvažte implementaci těchto dalších bezpečnostních praktik:

- **Vždy používejte HTTPS**: Šifrujte komunikaci mezi klientem a serverem, aby byly tokeny chráněny před zachycením.
- **Implementujte řízení přístupu na základě rolí (RBAC)**: Nekontrolujte jen, zda je uživatel autentizován, ale i co má oprávnění dělat.
- **Monitorujte a auditujte**: Logujte všechny autentizační události, abyste mohli detekovat a reagovat na podezřelou aktivitu.
- **Řešte omezení rychlosti a throttling**: Implementujte exponenciální zpomalování a logiku opakování, abyste elegantně zvládli limity rychlosti.
- **Bezpečné ukládání tokenů**: Ukládejte přístupové a obnovovací tokeny bezpečně pomocí systémových bezpečných úložišť nebo služeb pro správu klíčů.
- **Zvažte použití API Managementu**: Služby jako Azure API Management mohou automaticky řešit mnoho bezpečnostních aspektů, včetně autentizace, autorizace a omezení rychlosti.

## Reference

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Co dál

- [5.9 Web search](../web-search-mcp/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.