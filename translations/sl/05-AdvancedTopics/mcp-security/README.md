<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T12:21:18+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse

Varnost je ključnega pomena za implementacije MCP, še posebej v poslovnih okoljih. Pomembno je zagotoviti, da so orodja in podatki zaščiteni pred nepooblaščenim dostopom, uhajanjem podatkov in drugimi varnostnimi grožnjami.

## Uvod

Model Context Protocol (MCP) zahteva posebne varnostne premisleke zaradi svoje vloge pri zagotavljanju dostopa LLM-jem do podatkov in orodij. Ta lekcija raziskuje najboljše varnostne prakse za implementacije MCP na podlagi uradnih smernic MCP in uveljavljenih varnostnih vzorcev.

MCP sledi ključnim varnostnim načelom za zagotavljanje varnih in zaupanja vrednih interakcij:

- **Soglasje in nadzor uporabnika**: Uporabniki morajo dati izrecno soglasje, preden se dostopajo podatki ali izvajajo operacije. Zagotovite jasen nadzor nad tem, kateri podatki se delijo in katere akcije so pooblaščene.
  
- **Zasebnost podatkov**: Uporabniški podatki naj bodo razkriti le z izrecnim soglasjem in zaščiteni z ustreznimi kontrolami dostopa. Zaščitite pred nepooblaščenim prenosom podatkov.
  
- **Varnost orodij**: Pred uporabo kateregakoli orodja je potrebno izrecno soglasje uporabnika. Uporabniki naj imajo jasno razumevanje funkcionalnosti vsakega orodja, hkrati pa morajo biti vzpostavljene trdne varnostne meje.

## Cilji učenja

Ob koncu te lekcije boste znali:

- Implementirati varne mehanizme avtentikacije in avtorizacije za MCP strežnike.
- Zaščititi občutljive podatke z uporabo šifriranja in varnega shranjevanja.
- Zagotoviti varno izvajanje orodij z ustreznimi kontrolami dostopa.
- Uporabiti najboljše prakse za zaščito podatkov in skladnost z zakonodajo o zasebnosti.
- Prepoznati in omiliti pogoste varnostne ranljivosti MCP, kot so problemi z zmedo pooblaščenca, prenos žetonov in prevzem sej.

## Avtentikacija in avtorizacija

Avtentikacija in avtorizacija sta ključni za varovanje MCP strežnikov. Avtentikacija odgovarja na vprašanje "Kdo ste?", medtem ko avtorizacija odgovarja na vprašanje "Kaj lahko počnete?".

Po varnostni specifikaciji MCP so to ključni varnostni premisleki:

1. **Preverjanje žetonov**: MCP strežniki NE SMEJO sprejemati žetonov, ki niso bili izrecno izdani za MCP strežnik. "Token passthrough" je izrecno prepovedan anti-vzorec.

2. **Preverjanje avtorizacije**: MCP strežniki, ki izvajajo avtorizacijo, MORAJO preveriti vse dohodne zahteve in NE SMEJO uporabljati sej za avtentikacijo.

3. **Varnostno upravljanje sej**: Pri uporabi sej za stanje MORAJO MCP strežniki uporabljati varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil. ID-ji sej NAJ bodo vezani na uporabniško specifične informacije.

4. **Izrecno soglasje uporabnika**: Za proxy strežnike MORAJO implementacije MCP pridobiti soglasje uporabnika za vsakega dinamično registriranega odjemalca, preden posredujejo tretjim avtorizacijskim strežnikom.

Poglejmo primere, kako implementirati varno avtentikacijo in avtorizacijo v MCP strežnikih z uporabo .NET in Jave.

### Integracija .NET Identity

ASP .NET Core Identity ponuja robusten okvir za upravljanje avtentikacije in avtorizacije uporabnikov. Lahko ga integriramo z MCP strežniki za varovanje dostopa do orodij in virov.

Nekaj osnovnih konceptov, ki jih moramo razumeti pri integraciji ASP.NET Core Identity z MCP strežniki:

- **Konfiguracija Identity**: Nastavitev ASP.NET Core Identity z uporabniškimi vlogami in zahtevki (claims). Zahtevek je podatek o uporabniku, na primer njegova vloga ali dovoljenja, kot so "Admin" ali "User".
- **JWT avtentikacija**: Uporaba JSON Web Tokenov (JWT) za varen dostop do API-jev. JWT je standard za varen prenos informacij med strankami kot JSON objekt, ki ga je mogoče preveriti in mu zaupati, ker je digitalno podpisan.
- **Avtorizacijske politike**: Določanje politik za nadzor dostopa do določenih orodij glede na uporabniške vloge. MCP uporablja avtorizacijske politike za določanje, kateri uporabniki lahko dostopajo do katerih orodij glede na njihove vloge in zahtevke.

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

Za Javo bomo uporabili Spring Security za implementacijo varne avtentikacije in avtorizacije MCP strežnikov. Spring Security ponuja celovit varnostni okvir, ki se brezhibno integrira s Spring aplikacijami.

Osnovni koncepti so:

- **Konfiguracija Spring Security**: Nastavitev varnostnih konfiguracij za avtentikacijo in avtorizacijo.
- **OAuth2 Resource Server**: Uporaba OAuth2 za varen dostop do MCP orodij. OAuth2 je okvir za avtorizacijo, ki omogoča tretjim storitvam izmenjavo dostopnih žetonov za varen dostop do API-jev.
- **Varnostni interceptorji**: Implementacija varnostnih interceptorjev za uveljavljanje kontrol dostopa pri izvajanju orodij.
- **Nadzor dostopa na podlagi vlog**: Uporaba vlog za nadzor dostopa do določenih orodij in virov.
- **Varnostne anotacije**: Uporaba anotacij za varovanje metod in končnih točk.

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

- Konfigurirali Spring Security za varovanje MCP končnih točk, omogočajoč javni dostop do odkrivanja orodij, medtem ko je za izvajanje orodij potrebna avtentikacija.
- Uporabili OAuth2 kot resource server za upravljanje varnega dostopa do MCP orodij.
- Implementirali varnostni interceptor za uveljavljanje kontrol dostopa pri izvajanju orodij, preverjajoč uporabniške vloge in dovoljenja pred dovoljenjem dostopa do določenih orodij.
- Določili nadzor dostopa na podlagi vlog za omejitev dostopa do administratorskih orodij in občutljivih podatkov glede na uporabniške vloge.

## Zaščita podatkov in zasebnost

Zaščita podatkov je ključna za zagotavljanje, da se občutljive informacije obravnavajo varno. To vključuje zaščito osebno prepoznavnih informacij (PII), finančnih podatkov in drugih občutljivih informacij pred nepooblaščenim dostopom in uhajanjem.

### Primer zaščite podatkov v Pythonu

Poglejmo primer, kako implementirati zaščito podatkov v Pythonu z uporabo šifriranja in zaznavanja PII.

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

- Implementirali razred `PiiDetector` za pregledovanje besedila in parametrov glede osebno prepoznavnih informacij (PII).
- Ustvarili razred `EncryptionService` za upravljanje šifriranja in dešifriranja občutljivih podatkov z uporabo knjižnice `cryptography`.
- Določili dekorator `secure_tool`, ki ovije izvajanje orodja, da preveri PII, beleži dostop in po potrebi šifrira občutljive podatke.
- Uporabili dekorator `secure_tool` na vzorčnem orodju (`SecureCustomerDataTool`), da zagotovimo varno ravnanje z občutljivimi podatki.

## Specifična varnostna tveganja MCP

Po uradni MCP varnostni dokumentaciji obstajajo specifična varnostna tveganja, ki jih morajo izvajalci MCP poznati:

### 1. Problem zmedenega pooblaščenca (Confused Deputy)

Ta ranljivost nastane, ko MCP strežnik deluje kot proxy do API-jev tretjih oseb, kar lahko napadalcem omogoči izkoriščanje zaupanja med MCP strežnikom in temi API-ji.

**Omilitev:**
- MCP proxy strežniki, ki uporabljajo statične ID-je odjemalcev, MORAJO pridobiti soglasje uporabnika za vsakega dinamično registriranega odjemalca, preden posredujejo tretjim avtorizacijskim strežnikom.
- Implementirajte ustrezen OAuth potek z PKCE (Proof Key for Code Exchange) za avtorizacijske zahteve.
- Strogo preverjajte URI-je za preusmeritev in identifikatorje odjemalcev.

### 2. Ranljivosti pri prenosu žetonov (Token Passthrough)

Prenos žetonov nastane, ko MCP strežnik sprejema žetone od MCP odjemalca brez preverjanja, ali so bili ti žetoni pravilno izdani za MCP strežnik, in jih posreduje naprej do API-jev.

### Tveganja
- Obhod varnostnih kontrol (obhod omejitev hitrosti, preverjanja zahtev)
- Težave z odgovornostjo in revizijsko sledjo
- Kršitve mej zaupanja
- Tveganja za združljivost v prihodnosti

**Omilitev:**
- MCP strežniki NE SMEJO sprejemati žetonov, ki niso bili izrecno izdani za MCP strežnik.
- Vedno preverjajte zahtevke občinstva žetona, da se ujemajo z pričakovano storitvijo.

### 3. Prevzem sej (Session Hijacking)

Do tega pride, ko nepooblaščena oseba pridobi ID seje in ga uporabi za ponarejanje izvirnega odjemalca, kar lahko vodi do nepooblaščenih dejanj.

**Omilitev:**
- MCP strežniki, ki izvajajo avtorizacijo, MORAJO preveriti vse dohodne zahteve in NE SMEJO uporabljati sej za avtentikacijo.
- Uporabljajte varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil.
- Vežite ID-je sej na uporabniško specifične informacije z uporabo formata ključa, kot je `<user_id>:<session_id>`.
- Implementirajte ustrezne politike poteka in rotacije sej.

## Dodatne najboljše varnostne prakse za MCP

Poleg osnovnih varnostnih premislekov MCP razmislite o implementaciji naslednjih dodatnih varnostnih praks:

- **Vedno uporabljajte HTTPS**: Šifrirajte komunikacijo med odjemalcem in strežnikom, da zaščitite žetone pred prestrezanjem.
- **Implementirajte nadzor dostopa na podlagi vlog (RBAC)**: Ne preverjajte le, ali je uporabnik avtenticiran, ampak tudi, kaj je pooblaščen početi.
- **Spremljajte in revidirajte**: Beležite vse dogodke avtentikacije za odkrivanje in odzivanje na sumljive aktivnosti.
- **Upravljajte omejitve hitrosti in zadrževanje**: Implementirajte eksponentno vračanje in logiko ponovnega poskusa za prijazno obravnavo omejitev hitrosti.
- **Varno shranjujte žetone**: Dostopne in osvežitvene žetone shranjujte varno z uporabo sistemskih mehanizmov za varno shranjevanje ali storitev za upravljanje ključev.
- **Razmislite o uporabi upravljanja API-jev**: Storitve, kot je Azure API Management, lahko samodejno obravnavajo številne varnostne vidike, vključno z avtentikacijo, avtorizacijo in omejevanjem hitrosti.

## Viri

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Kaj sledi

- [5.9 Web search](../web-search-mcp/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.