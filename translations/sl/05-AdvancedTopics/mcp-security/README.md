<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:44:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse

Varnost je ključnega pomena za implementacije MCP, še posebej v poslovnih okoljih. Pomembno je zagotoviti, da so orodja in podatki zaščiteni pred nepooblaščenim dostopom, uhajanjem podatkov in drugimi varnostnimi grožnjami.

## Uvod

V tej lekciji bomo raziskali najboljše varnostne prakse za implementacije MCP. Obravnavali bomo avtentikacijo in avtorizacijo, zaščito podatkov, varno izvajanje orodij ter skladnost z zakonodajo o varstvu podatkov.

## Cilji učenja

Ob koncu te lekcije boste znali:

- Uvesti varne mehanizme avtentikacije in avtorizacije za MCP strežnike.
- Zaščititi občutljive podatke z uporabo šifriranja in varnega shranjevanja.
- Zagotoviti varno izvajanje orodij z ustreznimi kontrolami dostopa.
- Uporabiti najboljše prakse za zaščito podatkov in skladnost z zakonodajo o zasebnosti.

## Avtentikacija in avtorizacija

Avtentikacija in avtorizacija sta ključni za varovanje MCP strežnikov. Avtentikacija odgovarja na vprašanje "Kdo ste?", medtem ko avtorizacija odgovarja na vprašanje "Kaj lahko počnete?".

Poglejmo primere, kako uvesti varno avtentikacijo in avtorizacijo v MCP strežnikih z uporabo .NET in Jave.

### Integracija .NET Identity

ASP .NET Core Identity ponuja robusten okvir za upravljanje avtentikacije in avtorizacije uporabnikov. Lahko ga integriramo z MCP strežniki za varovanje dostopa do orodij in virov.

Pri integraciji ASP.NET Core Identity z MCP strežniki moramo razumeti nekaj osnovnih pojmov:

- **Identity konfiguracija**: Nastavitev ASP.NET Core Identity z uporabniškimi vlogami in trditvami (claims). Trditev je podatek o uporabniku, na primer njegova vloga ali dovoljenja, kot so "Admin" ali "User".
- **JWT avtentikacija**: Uporaba JSON Web Tokenov (JWT) za varen dostop do API-jev. JWT je standard za varno prenašanje informacij med strankami kot JSON objekt, ki ga je mogoče preveriti in mu zaupati, saj je digitalno podpisan.
- **Avtorizacijske politike**: Določanje politik za nadzor dostopa do določenih orodij glede na uporabniške vloge. MCP uporablja avtorizacijske politike za določanje, kateri uporabniki lahko dostopajo do katerih orodij glede na njihove vloge in trditve.

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

V zgornji kodi smo:

- Konfigurirali ASP.NET Core Identity za upravljanje uporabnikov.
- Nastavili JWT avtentikacijo za varen dostop do API-jev. Določili smo parametre preverjanja žetona, vključno z izdajateljem, občinstvom in ključem za podpis.
- Določili avtorizacijske politike za nadzor dostopa do orodij glede na uporabniške vloge. Na primer, politika "CanUseAdminTools" zahteva, da ima uporabnik vlogo "Admin", medtem ko politika "CanUseBasic" zahteva, da je uporabnik avtenticiran.
- Registrirali MCP orodja z določenimi zahtevami za avtorizacijo, s čimer smo zagotovili, da do njih dostopajo le uporabniki z ustreznimi vlogami.

### Integracija Java Spring Security

Za Javo bomo uporabili Spring Security za implementacijo varne avtentikacije in avtorizacije za MCP strežnike. Spring Security ponuja celovit varnostni okvir, ki se brezhibno integrira s Spring aplikacijami.

Osnovni pojmi so:

- **Konfiguracija Spring Security**: Nastavitev varnostnih konfiguracij za avtentikacijo in avtorizacijo.
- **OAuth2 Resource Server**: Uporaba OAuth2 za varen dostop do MCP orodij. OAuth2 je okvir za avtorizacijo, ki omogoča tretjim storitvam izmenjavo dostopnih žetonov za varen dostop do API-jev.
- **Varnostni interceptorji**: Implementacija varnostnih interceptorjev za uveljavljanje kontrol dostopa pri izvajanju orodij.
- **Nadzor dostopa na podlagi vlog**: Uporaba vlog za nadzor dostopa do določenih orodij in virov.
- **Varnostne anotacije**: Uporaba anotacij za zaščito metod in končnih točk.

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

V zgornji kodi smo:

- Konfigurirali Spring Security za varovanje MCP končnih točk, omogočili javni dostop do odkrivanja orodij, medtem ko je za izvajanje orodij potrebna avtentikacija.
- Uporabili OAuth2 kot resource server za upravljanje varnega dostopa do MCP orodij.
- Implementirali varnostni interceptor za uveljavljanje kontrol dostopa pri izvajanju orodij, ki preverja uporabniške vloge in dovoljenja pred dovoljenjem dostopa do določenih orodij.
- Določili nadzor dostopa na podlagi vlog za omejitev dostopa do administratorskih orodij in občutljivih podatkov glede na uporabniške vloge.

## Zaščita podatkov in zasebnost

Zaščita podatkov je ključna za zagotavljanje, da se občutljive informacije obravnavajo varno. To vključuje zaščito osebnih podatkov (PII), finančnih podatkov in drugih občutljivih informacij pred nepooblaščenim dostopom in uhajanjem.

### Primer zaščite podatkov v Pythonu

Poglejmo primer, kako uvesti zaščito podatkov v Pythonu z uporabo šifriranja in zaznavanja PII.

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

V zgornji kodi smo:

- Implementirali razred `PiiDetector` za pregledovanje besedila in parametrov glede osebnih podatkov (PII).
- Ustvarili razred `EncryptionService` za upravljanje šifriranja in dešifriranja občutljivih podatkov z uporabo knjižnice `cryptography`.
- Določili dekorator `secure_tool`, ki ovije izvajanje orodja, da preveri PII, beleži dostop in po potrebi šifrira občutljive podatke.
- Uporabili dekorator `secure_tool` na vzorčnem orodju (`SecureCustomerDataTool`), da zagotovimo varno ravnanje z občutljivimi podatki.

## Kaj sledi

- [5.9 Web search](../web-search-mcp/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.