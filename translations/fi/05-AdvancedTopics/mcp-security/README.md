<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:16:05+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fi"
}
-->
# Security Best Practices

Turvallisuus on ratkaisevan tärkeää MCP-toteutuksissa, erityisesti yritysympäristöissä. On tärkeää varmistaa, että työkalut ja tiedot ovat suojattuja luvattomalta käytöltä, tietomurroilta ja muilta turvallisuusuhkilta.

## Introduction

Tässä oppitunnissa käsittelemme turvallisuuden parhaita käytäntöjä MCP-toteutuksissa. Käymme läpi todennuksen ja valtuutuksen, tietosuojaa, työkalujen turvallista suorittamista sekä tietosuojasäädösten noudattamista.

## Learning Objectives

Oppitunnin lopussa osaat:

- Toteuttaa turvalliset todennus- ja valtuutusmekanismit MCP-palvelimille.
- Suojata arkaluonteiset tiedot salauksen ja turvallisen tallennuksen avulla.
- Varmistaa työkalujen turvallisen suorittamisen asianmukaisin käyttöoikeuksin.
- Soveltaa parhaita käytäntöjä tietosuojan ja yksityisyyden suojaamiseksi.

## Authentication and Authorization

Todennus ja valtuutus ovat olennaisia MCP-palvelimien suojaamisessa. Todennus vastaa kysymykseen "Kuka sinä olet?" ja valtuutus kysymykseen "Mitä voit tehdä?".

Tarkastellaan esimerkkejä siitä, miten toteuttaa turvallinen todennus ja valtuutus MCP-palvelimissa käyttäen .NET:iä ja Javaa.

### .NET Identity Integration

ASP .NET Core Identity tarjoaa vankan kehikon käyttäjien todennuksen ja valtuutuksen hallintaan. Voimme integroida sen MCP-palvelimiin työkalujen ja resurssien suojaksi.

Tässä integraatiossa on muutamia keskeisiä käsitteitä, jotka on hyvä ymmärtää:

- **Identity Configuration**: ASP.NET Core Identityn määrittäminen käyttäjärooleineen ja -väitteineen. Väite on käyttäjää koskeva tieto, kuten rooli tai käyttöoikeus, esimerkiksi "Admin" tai "User".
- **JWT Authentication**: JSON Web Tokenien (JWT) käyttö turvalliseen API-käyttöön. JWT on standardi tiedon turvalliseen siirtämiseen osapuolten välillä JSON-objektina, joka voidaan vahvistaa ja johon voidaan luottaa, koska se on digitaalisesti allekirjoitettu.
- **Authorization Policies**: Politiikkojen määrittely, joilla hallitaan pääsyä tiettyihin työkaluihin käyttäjäroolien perusteella. MCP käyttää valtuutuspolitiikkoja määrittäessään, ketkä käyttäjät pääsevät käsiksi mihinkin työkaluihin rooliensa ja väitteidensä mukaan.

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

Edellisessä koodissa olemme:

- Määrittäneet ASP.NET Core Identityn käyttäjähallintaan.
- Asettaneet JWT-todennuksen turvallista API-käyttöä varten. Määrittelimme tokenin validointiparametrit, kuten julkaisijan, kohdeyleisön ja allekirjoitusavaimen.
- Määritelleet valtuutuspolitiikat työkalujen käyttöoikeuksien hallintaan käyttäjäroolien perusteella. Esimerkiksi "CanUseAdminTools" -politiikka vaatii käyttäjältä "Admin"-roolin, kun taas "CanUseBasic" -politiikka edellyttää käyttäjän olevan todennettu.
- Rekisteröineet MCP-työkalut tiettyjen valtuutusvaatimusten kanssa varmistaen, että vain oikeilla rooleilla varustetut käyttäjät pääsevät niihin käsiksi.

### Java Spring Security Integration

Javassa käytämme Spring Securityä toteuttamaan turvallisen todennuksen ja valtuutuksen MCP-palvelimille. Spring Security tarjoaa kattavan turvallisuuskehyksen, joka integroituu saumattomasti Spring-sovelluksiin.

Keskeiset käsitteet ovat:

- **Spring Security Configuration**: Turvallisuusasetusten määrittäminen todennusta ja valtuutusta varten.
- **OAuth2 Resource Server**: OAuth2:n käyttö turvalliseen pääsyyn MCP-työkaluihin. OAuth2 on valtuutuskehys, jonka avulla kolmannen osapuolen palvelut voivat vaihtaa käyttöoikeustokeneita turvallista API-käyttöä varten.
- **Security Interceptors**: Turvainterseptorien toteutus pääsynvalvonnan varmistamiseksi työkalujen suorituksessa.
- **Role-Based Access Control**: Roolipohjainen pääsynhallinta tiettyihin työkaluihin ja resursseihin.
- **Security Annotations**: Annotaatiot metodien ja päätepisteiden suojaamiseen.

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

Edellisessä koodissa olemme:

- Määrittäneet Spring Securityn suojaamaan MCP-päätepisteitä, sallien työkalujen löytymisen julkisesti, mutta vaatimalla todennuksen työkalujen suorittamiseen.
- Käyttäneet OAuth2:ta resurssipalvelimena MCP-työkalujen turvallisen käytön hallintaan.
- Toteuttaneet turvainterseptorin pääsynvalvonnan varmistamiseksi työkalujen suorittamisessa, tarkistaen käyttäjäroolit ja käyttöoikeudet ennen pääsyn myöntämistä tiettyihin työkaluihin.
- Määritelleet roolipohjaisen pääsynhallinnan rajoittamaan pääsyä ylläpitäjätyökaluihin ja arkaluonteisiin tietoihin käyttäjäroolien perusteella.

## Data Protection and Privacy

Tietosuoja on välttämätöntä sen varmistamiseksi, että arkaluonteisia tietoja käsitellään turvallisesti. Tämä koskee henkilötunnistettavia tietoja (PII), taloudellisia tietoja ja muita arkaluonteisia tietoja, joita on suojattava luvattomalta käytöltä ja tietomurroilta.

### Python Data Protection Example

Tarkastellaan esimerkkiä tietosuojan toteuttamisesta Pythonilla salauksen ja PII-tunnistuksen avulla.

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

Edellisessä koodissa olemme:

- Toteuttaneet `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` varmistaaksemme, että se käsittelee arkaluonteisia tietoja turvallisesti.

## What's next

- [Web search](../web-search-mcp/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.