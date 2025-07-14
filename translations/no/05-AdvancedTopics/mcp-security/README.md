<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:40:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "no"
}
-->
# Sikkerhetsrutiner

Sikkerhet er avgjørende for MCP-implementasjoner, spesielt i bedriftsmiljøer. Det er viktig å sørge for at verktøy og data er beskyttet mot uautorisert tilgang, datainnbrudd og andre sikkerhetstrusler.

## Introduksjon

I denne leksjonen skal vi utforske sikkerhetsrutiner for MCP-implementasjoner. Vi vil dekke autentisering og autorisasjon, databeskyttelse, sikker kjøring av verktøy og overholdelse av personvernregler.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Implementere sikre autentiserings- og autorisasjonsmekanismer for MCP-servere.
- Beskytte sensitiv data ved hjelp av kryptering og sikker lagring.
- Sikre at verktøy kjøres trygt med riktige tilgangskontroller.
- Anvende beste praksis for databeskyttelse og personvern.

## Autentisering og autorisasjon

Autentisering og autorisasjon er essensielt for å sikre MCP-servere. Autentisering svarer på spørsmålet «Hvem er du?», mens autorisasjon svarer på «Hva kan du gjøre?».

La oss se på eksempler på hvordan man kan implementere sikker autentisering og autorisasjon i MCP-servere ved bruk av .NET og Java.

### .NET Identity-integrasjon

ASP .NET Core Identity tilbyr et robust rammeverk for håndtering av brukerautentisering og autorisasjon. Vi kan integrere det med MCP-servere for å sikre tilgang til verktøy og ressurser.

Det er noen grunnleggende konsepter vi må forstå når vi integrerer ASP.NET Core Identity med MCP-servere, nemlig:

- **Identity-konfigurasjon**: Sette opp ASP.NET Core Identity med brukerroller og claims. En claim er en informasjon om brukeren, som for eksempel deres rolle eller tillatelser, som «Admin» eller «User».
- **JWT-autentisering**: Bruke JSON Web Tokens (JWT) for sikker API-tilgang. JWT er en standard for sikker overføring av informasjon mellom parter som et JSON-objekt, som kan verifiseres og stoles på fordi det er digitalt signert.
- **Autorisasjonspolicyer**: Definere policyer for å kontrollere tilgang til spesifikke verktøy basert på brukerroller. MCP bruker autorisasjonspolicyer for å avgjøre hvilke brukere som kan få tilgang til hvilke verktøy basert på deres roller og claims.

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

I koden over har vi:

- Konfigurert ASP.NET Core Identity for brukerstyring.
- Satt opp JWT-autentisering for sikker API-tilgang. Vi spesifiserte token-valideringsparametere, inkludert issuer, audience og signeringsnøkkel.
- Definert autorisasjonspolicyer for å kontrollere tilgang til verktøy basert på brukerroller. For eksempel krever policyen «CanUseAdminTools» at brukeren har rollen «Admin», mens «CanUseBasic» krever at brukeren er autentisert.
- Registrert MCP-verktøy med spesifikke autorisasjonskrav, slik at kun brukere med riktige roller får tilgang.

### Java Spring Security-integrasjon

For Java bruker vi Spring Security for å implementere sikker autentisering og autorisasjon for MCP-servere. Spring Security tilbyr et omfattende sikkerhetsrammeverk som integreres sømløst med Spring-applikasjoner.

Kjernebegrepene her er:

- **Spring Security-konfigurasjon**: Sette opp sikkerhetskonfigurasjoner for autentisering og autorisasjon.
- **OAuth2 Resource Server**: Bruke OAuth2 for sikker tilgang til MCP-verktøy. OAuth2 er et autorisasjonsrammeverk som lar tredjepartstjenester utveksle tilgangstokener for sikker API-tilgang.
- **Sikkerhetsinterceptorer**: Implementere sikkerhetsinterceptorer for å håndheve tilgangskontroller ved kjøring av verktøy.
- **Rollebasert tilgangskontroll**: Bruke roller for å styre tilgang til spesifikke verktøy og ressurser.
- **Sikkerhetsannotasjoner**: Bruke annotasjoner for å sikre metoder og endepunkter.

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

I koden over har vi:

- Konfigurert Spring Security for å sikre MCP-endepunkter, med offentlig tilgang til verktøysøk, men krav om autentisering for kjøring av verktøy.
- Brukt OAuth2 som resource server for å håndtere sikker tilgang til MCP-verktøy.
- Implementert en sikkerhetsinterceptor for å håndheve tilgangskontroller ved kjøring av verktøy, som sjekker brukerroller og tillatelser før tilgang gis til spesifikke verktøy.
- Definert rollebasert tilgangskontroll for å begrense tilgang til admin-verktøy og sensitiv data basert på brukerroller.

## Databeskyttelse og personvern

Databeskyttelse er avgjørende for å sikre at sensitiv informasjon håndteres trygt. Dette inkluderer beskyttelse av personlig identifiserbar informasjon (PII), økonomiske data og annen sensitiv informasjon mot uautorisert tilgang og lekkasjer.

### Python-eksempel på databeskyttelse

La oss se på et eksempel på hvordan man kan implementere databeskyttelse i Python ved bruk av kryptering og PII-deteksjon.

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

I koden over har vi:

- Implementert en `PiiDetector`-klasse for å skanne tekst og parametere etter personlig identifiserbar informasjon (PII).
- Opprettet en `EncryptionService`-klasse for å håndtere kryptering og dekryptering av sensitiv data ved hjelp av `cryptography`-biblioteket.
- Definert en `secure_tool`-dekoratør som pakker inn verktøykjøring for å sjekke etter PII, logge tilgang og kryptere sensitiv data ved behov.
- Brukt `secure_tool`-dekoratøren på et eksempelverktøy (`SecureCustomerDataTool`) for å sikre at det håndterer sensitiv data på en trygg måte.

## Hva nå

- [5.9 Web search](../web-search-mcp/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.