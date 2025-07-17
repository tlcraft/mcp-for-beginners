<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T07:10:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "nl"
}
-->
# Security Best Practices

Beveiliging is cruciaal voor MCP-implementaties, vooral in bedrijfsomgevingen. Het is belangrijk om ervoor te zorgen dat tools en data beschermd zijn tegen ongeautoriseerde toegang, datalekken en andere beveiligingsrisico's.

## Introductie

Het Model Context Protocol (MCP) vereist specifieke beveiligingsoverwegingen vanwege zijn rol in het bieden van toegang tot data en tools voor LLM's. Deze les behandelt de beste beveiligingspraktijken voor MCP-implementaties, gebaseerd op officiële MCP-richtlijnen en gevestigde beveiligingspatronen.

MCP volgt belangrijke beveiligingsprincipes om veilige en betrouwbare interacties te waarborgen:

- **Toestemming en controle van de gebruiker**: Gebruikers moeten expliciet toestemming geven voordat er data wordt geraadpleegd of acties worden uitgevoerd. Bied duidelijke controle over welke data wordt gedeeld en welke acties zijn toegestaan.
  
- **Privacy van data**: Gebruikersdata mag alleen worden blootgesteld met expliciete toestemming en moet worden beschermd met passende toegangscontroles. Bescherm tegen ongeautoriseerde datatransmissie.
  
- **Veiligheid van tools**: Voor het aanroepen van een tool is expliciete toestemming van de gebruiker vereist. Gebruikers moeten duidelijk begrijpen wat elke tool doet, en er moeten robuuste beveiligingsgrenzen worden gehandhaafd.

## Leerdoelen

Aan het einde van deze les kun je:

- Veilige authenticatie- en autorisatiemechanismen implementeren voor MCP-servers.
- Gevoelige data beschermen met encryptie en veilige opslag.
- Zorgen voor veilige uitvoering van tools met juiste toegangscontroles.
- Beste praktijken toepassen voor databeveiliging en privacycompliance.
- Veelvoorkomende MCP-beveiligingsproblemen herkennen en mitigeren, zoals confused deputy-problemen, token passthrough en session hijacking.

## Authenticatie en Autorisatie

Authenticatie en autorisatie zijn essentieel voor het beveiligen van MCP-servers. Authenticatie beantwoordt de vraag "Wie ben je?" terwijl autorisatie antwoord geeft op "Wat mag je doen?".

Volgens de MCP-beveiligingsspecificatie zijn dit kritieke beveiligingsoverwegingen:

1. **Tokenvalidatie**: MCP-servers MOGEN GEEN tokens accepteren die niet expliciet voor de MCP-server zijn uitgegeven. "Token passthrough" is een uitdrukkelijk verboden anti-patroon.

2. **Verificatie van autorisatie**: MCP-servers die autorisatie implementeren MOETEN alle binnenkomende verzoeken verifiëren en MOGEN geen sessies gebruiken voor authenticatie.

3. **Veilig sessiebeheer**: Bij gebruik van sessies voor status MOETEN MCP-servers veilige, niet-deterministische sessie-ID's gebruiken die gegenereerd zijn met veilige willekeurige getallengeneratoren. Sessies ID's MOETEN bij voorkeur gebonden zijn aan gebruikersspecifieke informatie.

4. **Expliciete toestemming van de gebruiker**: Voor proxy-servers MOETEN MCP-implementaties toestemming van de gebruiker verkrijgen voor elke dynamisch geregistreerde client voordat ze verzoeken doorsturen naar autorisatieservers van derden.

Laten we voorbeelden bekijken van hoe je veilige authenticatie en autorisatie kunt implementeren in MCP-servers met .NET en Java.

### .NET Identity Integratie

ASP .NET Core Identity biedt een robuust framework voor het beheren van gebruikersauthenticatie en -autorisatie. We kunnen dit integreren met MCP-servers om toegang tot tools en resources te beveiligen.

Enkele kernconcepten die we moeten begrijpen bij het integreren van ASP.NET Core Identity met MCP-servers zijn:

- **Identity-configuratie**: Het opzetten van ASP.NET Core Identity met gebruikersrollen en claims. Een claim is een stukje informatie over de gebruiker, zoals hun rol of rechten, bijvoorbeeld "Admin" of "User".
- **JWT-authenticatie**: Het gebruik van JSON Web Tokens (JWT) voor veilige API-toegang. JWT is een standaard voor het veilig overdragen van informatie tussen partijen als een JSON-object, dat geverifieerd en vertrouwd kan worden omdat het digitaal is ondertekend.
- **Autorisatiebeleid**: Het definiëren van beleidsregels om toegang tot specifieke tools te regelen op basis van gebruikersrollen. MCP gebruikt autorisatiebeleid om te bepalen welke gebruikers toegang hebben tot welke tools op basis van hun rollen en claims.

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

In bovenstaande code hebben we:

- ASP.NET Core Identity geconfigureerd voor gebruikersbeheer.
- JWT-authenticatie opgezet voor veilige API-toegang. We hebben de tokenvalidatieparameters gespecificeerd, waaronder de issuer, audience en signing key.
- Autorisatiebeleid gedefinieerd om toegang tot tools te regelen op basis van gebruikersrollen. Bijvoorbeeld, het "CanUseAdminTools" beleid vereist dat de gebruiker de rol "Admin" heeft, terwijl het "CanUseBasic" beleid vereist dat de gebruiker geauthenticeerd is.
- MCP-tools geregistreerd met specifieke autorisatievereisten, zodat alleen gebruikers met de juiste rollen toegang hebben.

### Java Spring Security Integratie

Voor Java gebruiken we Spring Security om veilige authenticatie en autorisatie voor MCP-servers te implementeren. Spring Security biedt een uitgebreid beveiligingsframework dat naadloos integreert met Spring-applicaties.

Kernconcepten zijn hier:

- **Spring Security-configuratie**: Het opzetten van beveiligingsconfiguraties voor authenticatie en autorisatie.
- **OAuth2 Resource Server**: Het gebruik van OAuth2 voor veilige toegang tot MCP-tools. OAuth2 is een autorisatieframework dat derde partijen toestaat toegangstokens uit te wisselen voor veilige API-toegang.
- **Security Interceptors**: Het implementeren van beveiligingsinterceptors om toegangscontroles op tooluitvoering af te dwingen.
- **Rolgebaseerde toegangscontrole**: Het gebruik van rollen om toegang tot specifieke tools en resources te regelen.
- **Beveiligingsannotaties**: Het gebruik van annotaties om methoden en endpoints te beveiligen.

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

In bovenstaande code hebben we:

- Spring Security geconfigureerd om MCP-endpoints te beveiligen, waarbij publieke toegang tot tooldiscovery is toegestaan, maar authenticatie vereist is voor tooluitvoering.
- OAuth2 gebruikt als resource server om veilige toegang tot MCP-tools te regelen.
- Een security interceptor geïmplementeerd om toegangscontroles op tooluitvoering af te dwingen, waarbij gebruikersrollen en -rechten worden gecontroleerd voordat toegang tot specifieke tools wordt verleend.
- Rolgebaseerde toegangscontrole gedefinieerd om toegang tot admin-tools en gevoelige data te beperken op basis van gebruikersrollen.

## Databeveiliging en Privacy

Databeveiliging is essentieel om ervoor te zorgen dat gevoelige informatie veilig wordt behandeld. Dit omvat het beschermen van persoonlijk identificeerbare informatie (PII), financiële gegevens en andere gevoelige informatie tegen ongeautoriseerde toegang en datalekken.

### Python Voorbeeld van Databeveiliging

Laten we een voorbeeld bekijken van hoe je databeveiliging kunt implementeren in Python met encryptie en PII-detectie.

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

In bovenstaande code hebben we:

- Een `PiiDetector`-klasse geïmplementeerd om tekst en parameters te scannen op persoonlijk identificeerbare informatie (PII).
- Een `EncryptionService`-klasse gemaakt om encryptie en decryptie van gevoelige data te verzorgen met behulp van de `cryptography`-bibliotheek.
- Een `secure_tool` decorator gedefinieerd die de uitvoering van tools omhult om te controleren op PII, toegang te loggen en gevoelige data te versleutelen indien nodig.
- De `secure_tool` decorator toegepast op een voorbeeldtool (`SecureCustomerDataTool`) om te zorgen dat deze gevoelige data veilig verwerkt.

## MCP-specifieke Beveiligingsrisico's

Volgens de officiële MCP-beveiligingsdocumentatie zijn er specifieke beveiligingsrisico's waar MCP-implementatoren zich bewust van moeten zijn:

### 1. Confused Deputy Probleem

Deze kwetsbaarheid doet zich voor wanneer een MCP-server fungeert als proxy voor API's van derden, waardoor aanvallers mogelijk misbruik kunnen maken van de vertrouwde relatie tussen de MCP-server en deze API's.

**Mitigatie:**
- MCP-proxyservers die statische client-ID's gebruiken MOETEN toestemming van de gebruiker verkrijgen voor elke dynamisch geregistreerde client voordat ze verzoeken doorsturen naar autorisatieservers van derden.
- Implementeer een correcte OAuth-flow met PKCE (Proof Key for Code Exchange) voor autorisatieverzoeken.
- Valideer redirect-URI's en clientidentificaties strikt.

### 2. Token Passthrough Kwetsbaarheden

Token passthrough doet zich voor wanneer een MCP-server tokens accepteert van een MCP-client zonder te verifiëren dat de tokens correct zijn uitgegeven aan de MCP-server, en deze vervolgens doorstuurt naar downstream API's.

### Risico's
- Omzeilen van beveiligingscontroles (zoals rate limiting en verzoekvalidatie)
- Problemen met verantwoording en audit trails
- Schending van vertrouwensgrenzen
- Risico's voor toekomstige compatibiliteit

**Mitigatie:**
- MCP-servers MOGEN GEEN tokens accepteren die niet expliciet voor de MCP-server zijn uitgegeven.
- Valideer altijd de audience-claims van tokens om te verzekeren dat ze overeenkomen met de verwachte service.

### 3. Session Hijacking

Dit gebeurt wanneer een onbevoegde partij een sessie-ID verkrijgt en deze gebruikt om zich voor te doen als de oorspronkelijke client, wat kan leiden tot ongeautoriseerde acties.

**Mitigatie:**
- MCP-servers die autorisatie implementeren MOETEN alle binnenkomende verzoeken verifiëren en MOGEN geen sessies gebruiken voor authenticatie.
- Gebruik veilige, niet-deterministische sessie-ID's die gegenereerd zijn met veilige willekeurige getallengeneratoren.
- Bind sessie-ID's aan gebruikersspecifieke informatie met een sleutelindeling zoals `<user_id>:<session_id>`.
- Implementeer correcte sessieverval- en rotatiebeleid.

## Aanvullende Beveiligingspraktijken voor MCP

Naast de kernbeveiligingsoverwegingen van MCP, overweeg ook deze aanvullende beveiligingspraktijken:

- **Gebruik altijd HTTPS**: Versleutel de communicatie tussen client en server om tokens te beschermen tegen onderschepping.
- **Implementeer rolgebaseerde toegangscontrole (RBAC)**: Controleer niet alleen of een gebruiker is geauthenticeerd, maar ook wat hij/zij mag doen.
- **Monitor en audit**: Log alle authenticatiegebeurtenissen om verdachte activiteiten te detecteren en erop te reageren.
- **Beheer rate limiting en throttling**: Implementeer exponentiële backoff en retry-logica om rate limits soepel af te handelen.
- **Veilige tokenopslag**: Bewaar access tokens en refresh tokens veilig met behulp van systeemsecure opslagmechanismen of beveiligde key management services.
- **Overweeg het gebruik van API Management**: Diensten zoals Azure API Management kunnen veel beveiligingsaspecten automatisch afhandelen, waaronder authenticatie, autorisatie en rate limiting.

## Referenties

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Wat volgt

- [5.9 Web search](../web-search-mcp/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.