<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-13T00:19:34+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "nl"
}
-->
# Beveiligingsrichtlijnen

Beveiliging is cruciaal voor MCP-implementaties, vooral in bedrijfsomgevingen. Het is belangrijk om ervoor te zorgen dat tools en gegevens beschermd zijn tegen ongeautoriseerde toegang, datalekken en andere beveiligingsbedreigingen.

## Introductie

In deze les bespreken we de beste beveiligingspraktijken voor MCP-implementaties. We behandelen authenticatie en autorisatie, gegevensbescherming, veilige uitvoering van tools en naleving van privacyregels.

## Leerdoelen

Aan het einde van deze les kun je:

- Veilige authenticatie- en autorisatiemechanismen implementeren voor MCP-servers.
- Gevoelige gegevens beschermen met encryptie en veilige opslag.
- Veilige uitvoering van tools waarborgen met juiste toegangscontroles.
- Beste praktijken toepassen voor gegevensbescherming en privacy-naleving.

## Authenticatie en Autorisatie

Authenticatie en autorisatie zijn essentieel voor het beveiligen van MCP-servers. Authenticatie beantwoordt de vraag "Wie ben je?" terwijl autorisatie antwoord geeft op "Wat mag je doen?".

Laten we voorbeelden bekijken van hoe je veilige authenticatie en autorisatie kunt implementeren in MCP-servers met .NET en Java.

### .NET Identity Integratie

ASP .NET Core Identity biedt een krachtig framework voor het beheren van gebruikersauthenticatie en -autorisatie. We kunnen dit integreren met MCP-servers om de toegang tot tools en resources te beveiligen.

Er zijn een paar kernconcepten die we moeten begrijpen bij het integreren van ASP.NET Core Identity met MCP-servers, namelijk:

- **Identity Configuratie**: Het instellen van ASP.NET Core Identity met gebruikersrollen en claims. Een claim is een stukje informatie over de gebruiker, zoals hun rol of permissies, bijvoorbeeld "Admin" of "User".
- **JWT Authenticatie**: Het gebruik van JSON Web Tokens (JWT) voor veilige API-toegang. JWT is een standaard voor het veilig overdragen van informatie tussen partijen als een JSON-object, dat geverifieerd en vertrouwd kan worden omdat het digitaal is ondertekend.
- **Autorisatiebeleid**: Het definiëren van beleid om de toegang tot specifieke tools te regelen op basis van gebruikersrollen. MCP gebruikt autorisatiebeleid om te bepalen welke gebruikers toegang hebben tot welke tools, gebaseerd op hun rollen en claims.

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
- JWT-authenticatie opgezet voor veilige API-toegang. We hebben de tokenvalidatieparameters gespecificeerd, inclusief de issuer, audience en signing key.
- Autorisatiebeleid gedefinieerd om de toegang tot tools te regelen op basis van gebruikersrollen. Bijvoorbeeld het beleid "CanUseAdminTools" vereist dat de gebruiker de rol "Admin" heeft, terwijl het beleid "CanUseBasic" vereist dat de gebruiker geauthenticeerd is.
- MCP-tools geregistreerd met specifieke autorisatievereisten, zodat alleen gebruikers met de juiste rollen toegang krijgen.

### Java Spring Security Integratie

Voor Java gebruiken we Spring Security om veilige authenticatie en autorisatie voor MCP-servers te implementeren. Spring Security biedt een uitgebreid beveiligingsframework dat naadloos integreert met Spring-applicaties.

De kernconcepten hier zijn:

- **Spring Security Configuratie**: Het instellen van beveiligingsconfiguraties voor authenticatie en autorisatie.
- **OAuth2 Resource Server**: Het gebruik van OAuth2 voor veilige toegang tot MCP-tools. OAuth2 is een autorisatieframework dat derde partijen toestaat om toegangstokens uit te wisselen voor veilige API-toegang.
- **Security Interceptors**: Het implementeren van beveiligingsinterceptors om toegangscontroles op tooluitvoering af te dwingen.
- **Role-Based Access Control**: Het gebruik van rollen om toegang tot specifieke tools en resources te regelen.
- **Security Annotaties**: Het gebruik van annotaties om methoden en endpoints te beveiligen.

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
- Een beveiligingsinterceptor geïmplementeerd om toegangscontroles op tooluitvoering af te dwingen, waarbij gebruikersrollen en permissies worden gecontroleerd voordat toegang wordt verleend tot specifieke tools.
- Role-based access control gedefinieerd om de toegang tot admin-tools en gevoelige data te beperken op basis van gebruikersrollen.

## Gegevensbescherming en Privacy

Gegevensbescherming is essentieel om ervoor te zorgen dat gevoelige informatie veilig wordt behandeld. Dit omvat het beschermen van persoonlijk identificeerbare informatie (PII), financiële gegevens en andere gevoelige informatie tegen ongeautoriseerde toegang en datalekken.

### Voorbeeld Gegevensbescherming in Python

Laten we een voorbeeld bekijken van hoe je gegevensbescherming kunt implementeren in Python met encryptie en PII-detectie.

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

- Een `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` geïmplementeerd om te zorgen dat gevoelige gegevens veilig worden verwerkt.

## Wat volgt

- [5.9 Web search](../web-search-mcp/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.