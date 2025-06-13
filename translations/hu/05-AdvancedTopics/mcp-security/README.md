<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-13T00:51:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "hu"
}
-->
# Biztonsági legjobb gyakorlatok

A biztonság kiemelten fontos az MCP megvalósítások esetében, különösen vállalati környezetben. Fontos biztosítani, hogy az eszközök és az adatok védve legyenek illetéktelen hozzáférés, adatlopás és egyéb biztonsági fenyegetések ellen.

## Bevezetés

Ebben a leckében áttekintjük az MCP megvalósítások biztonsági legjobb gyakorlatait. Foglalkozunk az autentikációval és jogosultságkezeléssel, az adatvédelemmel, az eszközök biztonságos futtatásával, valamint az adatvédelmi szabályozásoknak való megfeleléssel.

## Tanulási célok

A lecke végére képes leszel:

- Biztonságos autentikációs és jogosultságkezelési mechanizmusokat megvalósítani MCP szerverek számára.
- Érzékeny adatokat titkosítással és biztonságos tárolással védeni.
- Biztosítani az eszközök biztonságos futtatását megfelelő hozzáférés-ellenőrzéssel.
- Alkalmazni a legjobb gyakorlatokat az adatvédelem és az adatvédelmi megfelelés terén.

## Autentikáció és jogosultságkezelés

Az autentikáció és a jogosultságkezelés elengedhetetlen az MCP szerverek biztonságához. Az autentikáció arra a kérdésre válaszol, hogy „Ki vagy?”, míg a jogosultságkezelés arra, hogy „Mit tehetsz?”.

Nézzünk példákat arra, hogyan lehet biztonságos autentikációt és jogosultságkezelést megvalósítani MCP szervereken .NET és Java környezetben.

### .NET Identity integráció

Az ASP .NET Core Identity egy erős keretrendszer a felhasználói autentikáció és jogosultságkezelés kezelésére. Integrálhatjuk az MCP szerverekkel az eszközökhöz és erőforrásokhoz való hozzáférés védelmére.

Néhány alapvető fogalom, amit értenünk kell az ASP.NET Core Identity MCP szerverekkel való integrálásakor:

- **Identity konfiguráció**: ASP.NET Core Identity beállítása felhasználói szerepkörökkel és jogosultságokkal. Egy jogosultság (claim) egy információ a felhasználóról, például a szerepe vagy engedélyei, például „Admin” vagy „User”.
- **JWT autentikáció**: JSON Web Tokenek (JWT) használata a biztonságos API-hozzáféréshez. A JWT egy szabvány az információk biztonságos továbbítására JSON objektumként, amely digitális aláírással igazolható és megbízható.
- **Jogosultságkezelési szabályzatok**: Szabályzatok definiálása a hozzáférés vezérlésére az eszközökhöz felhasználói szerepkörök alapján. Az MCP jogosultságkezelési szabályzatokat használ annak meghatározására, hogy mely felhasználók férhetnek hozzá mely eszközökhöz a szerepköreik és jogosultságaik alapján.

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

Az előző kódban:

- Beállítottuk az ASP.NET Core Identity-t a felhasználókezeléshez.
- Konfiguráltuk a JWT autentikációt a biztonságos API-hozzáféréshez, megadtuk a token érvényesítési paramétereket, beleértve a kibocsátót, a közönséget és az aláírási kulcsot.
- Meghatároztunk jogosultságkezelési szabályzatokat az eszközökhöz való hozzáférés szabályozására felhasználói szerepkörök alapján. Például a „CanUseAdminTools” szabályzat megköveteli az „Admin” szerepkört, míg a „CanUseBasic” szabályzat csak hitelesített felhasználók számára engedélyezi a hozzáférést.
- Regisztráltuk az MCP eszközöket specifikus jogosultsági követelményekkel, így csak az arra jogosult felhasználók férhetnek hozzájuk.

### Java Spring Security integráció

Java esetén a Spring Security-t használjuk a biztonságos autentikáció és jogosultságkezelés megvalósítására MCP szervereknél. A Spring Security egy átfogó biztonsági keretrendszer, amely zökkenőmentesen integrálódik Spring alkalmazásokkal.

Az alapvető fogalmak itt:

- **Spring Security konfiguráció**: Biztonsági beállítások konfigurálása autentikációhoz és jogosultságkezeléshez.
- **OAuth2 erőforrás-szerver**: OAuth2 használata az MCP eszközökhöz való biztonságos hozzáféréshez. Az OAuth2 egy jogosultságkezelési keretrendszer, amely lehetővé teszi harmadik fél szolgáltatások számára az elérési tokenek cseréjét biztonságos API-hozzáféréshez.
- **Biztonsági interceptors**: Biztonsági interceptors megvalósítása a hozzáférés-ellenőrzés érvényesítésére az eszközök futtatásakor.
- **Szerepkör alapú hozzáférés-vezérlés**: Szerepkörök használata az adott eszközökhöz és erőforrásokhoz való hozzáférés szabályozására.
- **Biztonsági annotációk**: Annotációk használata a metódusok és végpontok védelmére.

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

Az előző kódban:

- Beállítottuk a Spring Security-t az MCP végpontok védelmére, engedélyezve az eszközök felfedezéséhez a nyilvános hozzáférést, miközben az eszközök futtatásához hitelesítést követelünk meg.
- OAuth2-t használtunk erőforrás-szerverként az MCP eszközökhöz való biztonságos hozzáférés kezelésére.
- Megvalósítottunk egy biztonsági interceptort az eszközök futtatásának hozzáférés-ellenőrzésére, amely ellenőrzi a felhasználói szerepköröket és jogosultságokat, mielőtt engedélyezné a hozzáférést.
- Meghatároztunk szerepkör alapú hozzáférés-vezérlést, amely korlátozza az adminisztrátori eszközök és érzékeny adatok elérését a felhasználói szerepkörök alapján.

## Adatvédelem és adatbiztonság

Az adatvédelem kulcsfontosságú annak biztosításához, hogy az érzékeny információk biztonságosan legyenek kezelve. Ez magában foglalja a személyes azonosításra alkalmas adatok (PII), pénzügyi adatok és egyéb érzékeny információk védelmét az illetéktelen hozzáférés és adatlopás ellen.

### Python adatvédelmi példa

Nézzünk egy példát arra, hogyan valósítható meg adatvédelem Pythonban titkosítás és PII felismerés segítségével.

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

Az előző kódban:

- Megvalósítottunk egy `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) osztályt, amely biztosítja az érzékeny adatok biztonságos kezelését.

## Mi következik

- [5.9 Web search](../web-search-mcp/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.