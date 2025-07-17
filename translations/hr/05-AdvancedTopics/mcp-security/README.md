<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T12:06:44+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "hr"
}
-->
# Najbolje sigurnosne prakse

Sigurnost je ključna za implementacije MCP-a, osobito u poslovnim okruženjima. Važno je osigurati da alati i podaci budu zaštićeni od neovlaštenog pristupa, curenja podataka i drugih sigurnosnih prijetnji.

## Uvod

Model Context Protocol (MCP) zahtijeva posebne sigurnosne mjere zbog svoje uloge u omogućavanju LLM-ovima pristup podacima i alatima. Ova lekcija istražuje najbolje sigurnosne prakse za implementacije MCP-a temeljene na službenim MCP smjernicama i utvrđenim sigurnosnim obrascima.

MCP slijedi ključne sigurnosne principe kako bi osigurao sigurne i pouzdane interakcije:

- **Slažem se i kontrola korisnika**: Korisnici moraju dati izričit pristanak prije nego što se pristupi bilo kakvim podacima ili izvrše operacije. Omogućite jasnu kontrolu nad time koji se podaci dijele i koje su radnje ovlaštene.
  
- **Privatnost podataka**: Korisnički podaci trebaju biti izloženi samo uz izričit pristanak i moraju biti zaštićeni odgovarajućim kontrolama pristupa. Zaštitite podatke od neovlaštenog prijenosa.
  
- **Sigurnost alata**: Prije pozivanja bilo kojeg alata, potreban je izričit pristanak korisnika. Korisnici trebaju jasno razumjeti funkcionalnost svakog alata, a moraju se provoditi stroge sigurnosne granice.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Implementirati sigurne mehanizme autentikacije i autorizacije za MCP servere.
- Zaštititi osjetljive podatke korištenjem enkripcije i sigurnog pohranjivanja.
- Osigurati sigurno izvršavanje alata uz odgovarajuće kontrole pristupa.
- Primijeniti najbolje prakse za zaštitu podataka i usklađenost s pravilima privatnosti.
- Prepoznati i ublažiti uobičajene sigurnosne ranjivosti MCP-a poput problema zbunjenog zamjenika, token passthrough i otmice sesije.

## Autentikacija i autorizacija

Autentikacija i autorizacija su ključni za osiguranje MCP servera. Autentikacija odgovara na pitanje "Tko ste vi?", dok autorizacija odgovara na pitanje "Što smijete raditi?".

Prema MCP sigurnosnoj specifikaciji, ovo su ključne sigurnosne smjernice:

1. **Validacija tokena**: MCP serveri NE SMIJU prihvaćati tokene koji nisu izričito izdani za MCP server. "Token passthrough" je izričito zabranjen anti-obrazac.

2. **Provjera autorizacije**: MCP serveri koji implementiraju autorizaciju MORAJU provjeravati sve dolazne zahtjeve i NE SMIJU koristiti sesije za autentikaciju.

3. **Sigurno upravljanje sesijama**: Kada se koriste sesije za stanje, MCP serveri MORAJU koristiti sigurne, nedeterminističke ID-e sesija generirane sigurnim generatorima slučajnih brojeva. ID-evi sesija TREBAJU biti vezani uz korisničke podatke.

4. **Izričit pristanak korisnika**: Za proxy servere, MCP implementacije MORAJU dobiti pristanak korisnika za svakog dinamički registriranog klijenta prije prosljeđivanja zahtjeva trećim autorizacijskim serverima.

Pogledajmo primjere kako implementirati sigurnu autentikaciju i autorizaciju u MCP serverima koristeći .NET i Java.

### Integracija .NET Identity

ASP .NET Core Identity pruža snažan okvir za upravljanje autentikacijom i autorizacijom korisnika. Možemo ga integrirati s MCP serverima kako bismo osigurali pristup alatima i resursima.

Postoje osnovni pojmovi koje trebamo razumjeti pri integraciji ASP.NET Core Identity s MCP serverima, a to su:

- **Konfiguracija Identity**: Postavljanje ASP.NET Core Identity s korisničkim ulogama i tvrdnjama. Tvrdnja je informacija o korisniku, poput njegove uloge ili dozvola, na primjer "Admin" ili "User".
- **JWT autentikacija**: Korištenje JSON Web Tokena (JWT) za siguran pristup API-ju. JWT je standard za siguran prijenos informacija između strana u obliku JSON objekta, koji se može provjeriti i kojem se može vjerovati jer je digitalno potpisan.
- **Politike autorizacije**: Definiranje politika za kontrolu pristupa određenim alatima na temelju korisničkih uloga. MCP koristi politike autorizacije za određivanje koji korisnici mogu pristupiti kojim alatima na temelju njihovih uloga i tvrdnji.

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

U prethodnom kodu smo:

- Konfigurirali ASP.NET Core Identity za upravljanje korisnicima.
- Postavili JWT autentikaciju za siguran pristup API-ju. Definirali smo parametre validacije tokena, uključujući izdavača, publiku i ključ za potpisivanje.
- Definirali politike autorizacije za kontrolu pristupa alatima na temelju korisničkih uloga. Na primjer, politika "CanUseAdminTools" zahtijeva da korisnik ima ulogu "Admin", dok politika "CanUseBasic" zahtijeva da korisnik bude autentificiran.
- Registrirali MCP alate s određenim zahtjevima za autorizaciju, osiguravajući da samo korisnici s odgovarajućim ulogama mogu pristupiti tim alatima.

### Integracija Java Spring Security

Za Javu ćemo koristiti Spring Security za implementaciju sigurne autentikacije i autorizacije MCP servera. Spring Security pruža sveobuhvatan sigurnosni okvir koji se besprijekorno integrira sa Spring aplikacijama.

Osnovni pojmovi su:

- **Konfiguracija Spring Security**: Postavljanje sigurnosnih konfiguracija za autentikaciju i autorizaciju.
- **OAuth2 Resource Server**: Korištenje OAuth2 za siguran pristup MCP alatima. OAuth2 je okvir za autorizaciju koji omogućuje uslugama trećih strana razmjenu pristupnih tokena za siguran pristup API-ju.
- **Sigurnosni presretači**: Implementacija sigurnosnih presretača za provođenje kontrola pristupa pri izvršavanju alata.
- **Kontrola pristupa temeljena na ulogama**: Korištenje uloga za kontrolu pristupa određenim alatima i resursima.
- **Sigurnosne anotacije**: Korištenje anotacija za osiguranje metoda i krajnjih točaka.

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

U prethodnom kodu smo:

- Konfigurirali Spring Security za zaštitu MCP krajnjih točaka, dopuštajući javni pristup otkrivanju alata, dok je za izvršavanje alata potrebna autentikacija.
- Koristili OAuth2 kao resource server za upravljanje sigurnim pristupom MCP alatima.
- Implementirali sigurnosni presretač za provođenje kontrola pristupa pri izvršavanju alata, provjeravajući korisničke uloge i dozvole prije dopuštanja pristupa određenim alatima.
- Definirali kontrolu pristupa temeljenu na ulogama za ograničavanje pristupa administratorskim alatima i pristupu osjetljivim podacima na temelju korisničkih uloga.

## Zaštita podataka i privatnost

Zaštita podataka je ključna za osiguranje da se osjetljive informacije obrađuju sigurno. To uključuje zaštitu osobnih podataka (PII), financijskih podataka i drugih osjetljivih informacija od neovlaštenog pristupa i curenja.

### Primjer zaštite podataka u Pythonu

Pogledajmo primjer kako implementirati zaštitu podataka u Pythonu koristeći enkripciju i detekciju PII.

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

U prethodnom kodu smo:

- Implementirali klasu `PiiDetector` za skeniranje teksta i parametara u potrazi za osobnim podacima (PII).
- Kreirali klasu `EncryptionService` za upravljanje enkripcijom i dekripcijom osjetljivih podataka koristeći biblioteku `cryptography`.
- Definirali dekorator `secure_tool` koji obavija izvršavanje alata kako bi provjerio PII, bilježio pristup i enkriptirao osjetljive podatke ako je potrebno.
- Primijenili dekorator `secure_tool` na primjer alata (`SecureCustomerDataTool`) kako bismo osigurali da sigurno rukuje osjetljivim podacima.

## Sigurnosni rizici specifični za MCP

Prema službenoj MCP sigurnosnoj dokumentaciji, postoje specifični sigurnosni rizici na koje bi implementatori MCP-a trebali obratiti pažnju:

### 1. Problem zbunjenog zamjenika (Confused Deputy)

Ova ranjivost nastaje kada MCP server djeluje kao proxy prema API-jima trećih strana, što potencijalno omogućuje napadačima da iskoriste povjerenje između MCP servera i tih API-ja.

**Ublažavanje:**
- MCP proxy serveri koji koriste statičke ID-eve klijenata MORAJU dobiti pristanak korisnika za svakog dinamički registriranog klijenta prije prosljeđivanja zahtjeva trećim autorizacijskim serverima.
- Implementirati ispravan OAuth tijek s PKCE (Proof Key for Code Exchange) za autorizacijske zahtjeve.
- Strogo validirati URI-je za preusmjeravanje i identifikatore klijenata.

### 2. Ranjivosti token passthrough

Token passthrough nastaje kada MCP server prihvaća tokene od MCP klijenta bez provjere jesu li tokeni ispravno izdani za MCP server i prosljeđuje ih dalje prema API-jima.

### Rizici
- Zaobilaženje sigurnosnih kontrola (npr. ograničenja brzine, validacija zahtjeva)
- Problemi s odgovornošću i revizijskim tragom
- Kršenje granica povjerenja
- Rizici buduće kompatibilnosti

**Ublažavanje:**
- MCP serveri NE SMIJU prihvaćati tokene koji nisu izričito izdani za MCP server.
- Uvijek validirati tvrdnje o publici tokena kako bi se osiguralo da odgovaraju očekivanoj usluzi.

### 3. Otmica sesije (Session Hijacking)

Do ovoga dolazi kada neovlaštena osoba dobije ID sesije i koristi ga za lažno predstavljanje izvornog klijenta, što može dovesti do neovlaštenih radnji.

**Ublažavanje:**
- MCP serveri koji implementiraju autorizaciju MORAJU provjeravati sve dolazne zahtjeve i NE SMIJU koristiti sesije za autentikaciju.
- Koristiti sigurne, nedeterminističke ID-eve sesija generirane sigurnim generatorima slučajnih brojeva.
- Vezati ID-eve sesija uz korisničke podatke koristeći format ključa poput `<user_id>:<session_id>`.
- Implementirati pravilnu politiku isteka i rotacije sesija.

## Dodatne najbolje sigurnosne prakse za MCP

Osim osnovnih sigurnosnih smjernica MCP-a, razmotrite implementaciju sljedećih dodatnih sigurnosnih mjera:

- **Uvijek koristite HTTPS**: Šifrirajte komunikaciju između klijenta i servera kako biste zaštitili tokene od presretanja.
- **Implementirajte kontrolu pristupa temeljenu na ulogama (RBAC)**: Ne provjeravajte samo je li korisnik autentificiran, već i što smije raditi.
- **Nadzor i revizija**: Bilježite sve događaje autentikacije kako biste mogli otkriti i reagirati na sumnjive aktivnosti.
- **Rukovanje ograničenjima brzine i throttlingom**: Implementirajte eksponencijalno odgađanje i logiku ponovnog pokušaja za elegantno upravljanje ograničenjima.
- **Sigurno pohranjivanje tokena**: Pohranjujte pristupne i osvježavajuće tokene sigurno koristeći sustavne mehanizme sigurnog pohranjivanja ili usluge upravljanja ključevima.
- **Razmotrite korištenje API upravljanja**: Usluge poput Azure API Management mogu automatski upravljati mnogim sigurnosnim aspektima, uključujući autentikaciju, autorizaciju i ograničenje brzine.

## Reference

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Što slijedi

- [5.9 Web search](../web-search-mcp/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.