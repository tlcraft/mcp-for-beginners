<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:19:26+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sr"
}
-->
# Najbolje prakse za bezbednost

Bezbednost je ključna za implementacije MCP-a, naročito u poslovnim okruženjima. Važno je osigurati da alati i podaci budu zaštićeni od neovlašćenog pristupa, curenja podataka i drugih bezbednosnih pretnji.

## Uvod

U ovoj lekciji ćemo istražiti najbolje prakse za bezbednost MCP implementacija. Obradićemo autentifikaciju i autorizaciju, zaštitu podataka, bezbedno izvršavanje alata i usklađenost sa propisima o zaštiti privatnosti podataka.

## Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Implementirate sigurne mehanizme autentifikacije i autorizacije za MCP servere.
- Zaštitite osetljive podatke korišćenjem enkripcije i sigurnog skladištenja.
- Osigurate bezbedno izvršavanje alata uz odgovarajuće kontrole pristupa.
- Primijenite najbolje prakse za zaštitu podataka i usklađenost sa pravilima o privatnosti.

## Autentifikacija i autorizacija

Autentifikacija i autorizacija su neophodni za zaštitu MCP servera. Autentifikacija odgovara na pitanje "Ko ste vi?", dok autorizacija odgovara na pitanje "Šta smete da radite?".

Pogledajmo primere kako implementirati sigurnu autentifikaciju i autorizaciju u MCP serverima koristeći .NET i Java.

### Integracija .NET Identity

ASP .NET Core Identity pruža snažan okvir za upravljanje autentifikacijom i autorizacijom korisnika. Možemo ga integrisati sa MCP serverima kako bismo zaštitili pristup alatima i resursima.

Postoje ključni koncepti koje treba razumeti prilikom integracije ASP.NET Core Identity sa MCP serverima:

- **Identity konfiguracija**: Podešavanje ASP.NET Core Identity sa korisničkim ulogama i tvrdnjama. Tvrdnja je informacija o korisniku, kao što je njegova uloga ili dozvole, na primer "Admin" ili "User".
- **JWT autentifikacija**: Korišćenje JSON Web Tokena (JWT) za siguran pristup API-ju. JWT je standard za sigurno prenošenje informacija između strana kao JSON objekat, koji se može verifikovati i kome se može verovati jer je digitalno potpisan.
- **Politike autorizacije**: Definisanje politika za kontrolu pristupa određenim alatima na osnovu korisničkih uloga. MCP koristi politike autorizacije da odredi koji korisnici mogu pristupiti kojim alatima na osnovu njihovih uloga i tvrdnji.

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

- Konfigurisali ASP.NET Core Identity za upravljanje korisnicima.
- Postavili JWT autentifikaciju za siguran pristup API-ju. Naveli smo parametre za validaciju tokena, uključujući izdavača, publiku i ključ za potpisivanje.
- Definisali politike autorizacije za kontrolu pristupa alatima na osnovu korisničkih uloga. Na primer, politika "CanUseAdminTools" zahteva da korisnik ima ulogu "Admin", dok politika "CanUseBasic" zahteva da korisnik bude autentifikovan.
- Registrovali MCP alate sa specifičnim zahtevima za autorizaciju, osiguravajući da samo korisnici sa odgovarajućim ulogama mogu da im pristupe.

### Integracija Java Spring Security

Za Javu ćemo koristiti Spring Security za implementaciju sigurne autentifikacije i autorizacije MCP servera. Spring Security pruža sveobuhvatan sigurnosni okvir koji se besprekorno integriše sa Spring aplikacijama.

Ključni koncepti su:

- **Konfiguracija Spring Security**: Podešavanje sigurnosnih konfiguracija za autentifikaciju i autorizaciju.
- **OAuth2 Resource Server**: Korišćenje OAuth2 za siguran pristup MCP alatima. OAuth2 je okvir za autorizaciju koji omogućava trećim stranama da razmenjuju pristupne tokene za siguran pristup API-ju.
- **Sigurnosni interceptor-i**: Implementacija sigurnosnih interceptor-a za sprovođenje kontrola pristupa prilikom izvršavanja alata.
- **Kontrola pristupa zasnovana na ulogama**: Korišćenje uloga za kontrolu pristupa određenim alatima i resursima.
- **Sigurnosne anotacije**: Korišćenje anotacija za zaštitu metoda i krajnjih tačaka.

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

- Konfigurisali Spring Security da zaštitimo MCP krajnje tačke, omogućavajući javni pristup otkrivanju alata dok je za izvršavanje alata potrebna autentifikacija.
- Koristili OAuth2 kao resource server za upravljanje sigurnim pristupom MCP alatima.
- Implementirali sigurnosni interceptor koji sprovodi kontrole pristupa prilikom izvršavanja alata, proveravajući uloge i dozvole korisnika pre nego što im se dozvoli pristup određenim alatima.
- Definisali kontrolu pristupa zasnovanu na ulogama kako bismo ograničili pristup administratorskim alatima i pristup osetljivim podacima na osnovu korisničkih uloga.

## Zaštita podataka i privatnost

Zaštita podataka je od suštinskog značaja za osiguranje da se osetljive informacije obrađuju na siguran način. To uključuje zaštitu ličnih podataka (PII), finansijskih podataka i drugih osetljivih informacija od neovlašćenog pristupa i curenja.

### Primer zaštite podataka u Pythonu

Pogledajmo primer kako implementirati zaštitu podataka u Pythonu koristeći enkripciju i detekciju PII.

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

- Implementirali `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) kako bismo osigurali da rukuje osetljivim podacima na siguran način.

## Šta sledi

- [Web search](../web-search-mcp/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен помоћу АИ сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.