<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T10:25:09+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "hu"
}
-->
# Biztonsági legjobb gyakorlatok

A biztonság kulcsfontosságú az MCP megvalósításoknál, különösen vállalati környezetben. Fontos biztosítani, hogy az eszközök és az adatok védve legyenek illetéktelen hozzáférés, adatlopás és egyéb biztonsági fenyegetések ellen.

## Bevezetés

A Model Context Protocol (MCP) speciális biztonsági megfontolásokat igényel, mivel LLM-ek számára biztosít hozzáférést adatokhoz és eszközökhöz. Ez a lecke az MCP megvalósítások biztonsági legjobb gyakorlatait tárgyalja az MCP hivatalos irányelvei és bevált biztonsági minták alapján.

Az MCP követi a kulcsfontosságú biztonsági elveket a biztonságos és megbízható interakciók érdekében:

- **Felhasználói beleegyezés és kontroll**: A felhasználóknak kifejezett beleegyezést kell adniuk, mielőtt bármilyen adatot elérnének vagy műveletet végeznének. Egyértelmű kontrollt kell biztosítani arról, hogy milyen adatokat osztanak meg és mely műveletek engedélyezettek.
  
- **Adatvédelem**: A felhasználói adatokat csak kifejezett beleegyezéssel szabad megosztani, és megfelelő hozzáférés-ellenőrzéssel kell védeni. Meg kell akadályozni az illetéktelen adatátvitelt.
  
- **Eszközbiztonság**: Mielőtt bármilyen eszközt meghívnánk, kifejezett felhasználói beleegyezés szükséges. A felhasználóknak tisztában kell lenniük az egyes eszközök működésével, és szigorú biztonsági határokat kell érvényesíteni.

## Tanulási célok

A lecke végére képes leszel:

- Biztonságos hitelesítési és jogosultságkezelési mechanizmusokat megvalósítani MCP szerverekhez.
- Érzékeny adatokat titkosítással és biztonságos tárolással védeni.
- Biztosítani az eszközök biztonságos végrehajtását megfelelő hozzáférés-ellenőrzéssel.
- Alkalmazni a legjobb gyakorlatokat az adatvédelem és adatvédelmi megfelelés érdekében.
- Azonosítani és mérsékelni az MCP gyakori biztonsági sebezhetőségeit, mint például a confused deputy problémát, token passthrough-t és munkamenet eltérítést.

## Hitelesítés és jogosultságkezelés

A hitelesítés és jogosultságkezelés elengedhetetlen az MCP szerverek biztonságához. A hitelesítés arra a kérdésre válaszol, hogy „Ki vagy?”, míg a jogosultságkezelés arra, hogy „Mit tehetsz?”.

Az MCP biztonsági specifikációja szerint ezek kritikus biztonsági szempontok:

1. **Token érvényesítés**: Az MCP szerverek NEM fogadhatnak el olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki. A „token passthrough” kifejezetten tiltott anti-minta.

2. **Jogosultság ellenőrzés**: Az MCP szerverek, amelyek jogosultságkezelést valósítanak meg, MINDEN bejövő kérést ellenőrizniük kell, és NEM használhatnak munkameneteket hitelesítésre.

3. **Biztonságos munkamenet-kezelés**: Állapotkezeléshez használt munkamenetek esetén az MCP szervereknek biztonságos, nem determinisztikus munkamenet-azonosítókat kell használniuk, amelyeket biztonságos véletlenszám-generátorokkal hoznak létre. A munkamenet-azonosítókat FEL KELL kötni felhasználó-specifikus adatokhoz.

4. **Kifejezett felhasználói beleegyezés**: Proxy szerverek esetén az MCP megvalósításoknak minden dinamikusan regisztrált kliens esetén be kell szerezniük a felhasználó beleegyezését, mielőtt továbbítanák harmadik fél jogosultságkezelő szervereihez.

Nézzük meg, hogyan valósítható meg biztonságos hitelesítés és jogosultságkezelés MCP szerverekben .NET és Java környezetben.

### .NET Identity integráció

Az ASP .NET Core Identity egy robusztus keretrendszer a felhasználói hitelesítés és jogosultságkezelés kezelésére. Integrálhatjuk MCP szerverekkel az eszközök és erőforrások biztonságos eléréséhez.

Néhány alapvető fogalom, amit meg kell értenünk az ASP.NET Core Identity MCP szerverekkel való integrálásakor:

- **Identity konfiguráció**: Az ASP.NET Core Identity beállítása felhasználói szerepkörökkel és jogosultságokkal. Egy jogosultság (claim) egy információ a felhasználóról, például a szerepköre vagy engedélyei, például „Admin” vagy „User”.
- **JWT hitelesítés**: JSON Web Tokenek (JWT) használata a biztonságos API hozzáféréshez. A JWT egy szabvány az információ biztonságos továbbítására JSON objektumként, amely digitálisan aláírt, így ellenőrizhető és megbízható.
- **Jogosultságkezelési szabályok**: Szabályok definiálása az eszközökhöz való hozzáférés szabályozására felhasználói szerepkörök alapján. Az MCP jogosultságkezelési szabályokat használ annak meghatározására, hogy mely felhasználók férhetnek hozzá mely eszközökhöz szerepköreik és jogosultságaik alapján.

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

A fenti kódban:

- Beállítottuk az ASP.NET Core Identity-t a felhasználókezeléshez.
- Konfiguráltuk a JWT hitelesítést a biztonságos API hozzáféréshez. Megadtuk a token érvényesítési paramétereket, beleértve a kibocsátót, a közönséget és az aláírási kulcsot.
- Meghatároztuk a jogosultságkezelési szabályokat az eszközökhöz való hozzáférés szabályozására felhasználói szerepkörök alapján. Például a „CanUseAdminTools” szabály megköveteli, hogy a felhasználó „Admin” szerepkörrel rendelkezzen, míg a „CanUseBasic” szabály megköveteli, hogy a felhasználó hitelesített legyen.
- Regisztráltuk az MCP eszközöket specifikus jogosultsági követelményekkel, biztosítva, hogy csak a megfelelő szerepkörrel rendelkező felhasználók férhessenek hozzájuk.

### Java Spring Security integráció

Java esetén a Spring Security-t használjuk az MCP szerverek biztonságos hitelesítésének és jogosultságkezelésének megvalósításához. A Spring Security egy átfogó biztonsági keretrendszer, amely zökkenőmentesen integrálódik a Spring alkalmazásokkal.

Az alapfogalmak:

- **Spring Security konfiguráció**: Biztonsági beállítások konfigurálása hitelesítéshez és jogosultságkezeléshez.
- **OAuth2 erőforrás szerver**: OAuth2 használata az MCP eszközökhöz való biztonságos hozzáféréshez. Az OAuth2 egy jogosultságkezelési keretrendszer, amely lehetővé teszi harmadik fél szolgáltatások számára, hogy hozzáférési tokeneket cseréljenek biztonságos API hozzáférés érdekében.
- **Biztonsági interceptors**: Biztonsági interceptors megvalósítása az eszközök végrehajtásának hozzáférés-ellenőrzésére.
- **Szerepkör alapú hozzáférés-vezérlés**: Szerepkörök használata az eszközökhöz és erőforrásokhoz való hozzáférés szabályozására.
- **Biztonsági annotációk**: Annotációk használata metódusok és végpontok védelmére.

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

A fenti kódban:

- Beállítottuk a Spring Security-t az MCP végpontok védelmére, lehetővé téve az eszközök felfedezéséhez a nyilvános hozzáférést, miközben az eszközök végrehajtásához hitelesítést követelünk meg.
- OAuth2-t használtunk erőforrás szerverként az MCP eszközökhöz való biztonságos hozzáférés kezelésére.
- Megvalósítottunk egy biztonsági interceptort az eszközök végrehajtásának hozzáférés-ellenőrzésére, amely ellenőrzi a felhasználói szerepköröket és jogosultságokat, mielőtt engedélyezné a hozzáférést adott eszközökhöz.
- Meghatároztuk a szerepkör alapú hozzáférés-vezérlést, hogy korlátozzuk az adminisztrátori eszközökhöz és érzékeny adatokhoz való hozzáférést a felhasználói szerepkörök alapján.

## Adatvédelem és adatbiztonság

Az adatvédelem elengedhetetlen annak biztosításához, hogy az érzékeny információkat biztonságosan kezeljék. Ez magában foglalja a személyes azonosításra alkalmas információk (PII), pénzügyi adatok és egyéb érzékeny adatok védelmét az illetéktelen hozzáférés és adatlopás ellen.

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

A fenti kódban:

- Megvalósítottunk egy `PiiDetector` osztályt, amely szöveget és paramétereket vizsgál személyes azonosításra alkalmas információk (PII) után.
- Létrehoztunk egy `EncryptionService` osztályt, amely kezeli az érzékeny adatok titkosítását és visszafejtését a `cryptography` könyvtár segítségével.
- Definiáltunk egy `secure_tool` dekorátort, amely az eszköz végrehajtását becsomagolja, hogy ellenőrizze a PII-t, naplózza a hozzáférést, és szükség esetén titkosítsa az érzékeny adatokat.
- Alkalmaztuk a `secure_tool` dekorátort egy mintapéldány eszközön (`SecureCustomerDataTool`), hogy biztosítsuk az érzékeny adatok biztonságos kezelését.

## MCP-specifikus biztonsági kockázatok

Az MCP hivatalos biztonsági dokumentációja szerint vannak olyan specifikus biztonsági kockázatok, amelyekre az MCP megvalósítóknak figyelniük kell:

### 1. Confused Deputy probléma

Ez a sebezhetőség akkor fordul elő, amikor egy MCP szerver proxyként működik harmadik fél API-k felé, ami lehetővé teheti a támadók számára, hogy kihasználják az MCP szerver és ezek az API-k közötti megbízható kapcsolatot.

**Megelőzés:**
- Az MCP proxy szerverek, amelyek statikus kliensazonosítókat használnak, MINDEN dinamikusan regisztrált kliens esetén be kell szerezniük a felhasználó beleegyezését, mielőtt továbbítanák a kérést harmadik fél jogosultságkezelő szervereihez.
- Megfelelő OAuth folyamatot kell alkalmazni PKCE-vel (Proof Key for Code Exchange) az engedélykérésekhez.
- Szigorúan ellenőrizni kell az átirányítási URI-kat és kliensazonosítókat.

### 2. Token passthrough sebezhetőségek

Token passthrough akkor fordul elő, amikor egy MCP szerver elfogad tokeneket egy MCP klienstől anélkül, hogy ellenőrizné, hogy a tokeneket megfelelően az MCP szerver számára bocsátották-e ki, majd továbbítja azokat downstream API-k felé.

### Kockázatok
- Biztonsági kontrollok megkerülése (pl. sebességkorlátozás, kérés-ellenőrzés kikerülése)
- Felelősség és audit nyom problémák
- Megbízhatósági határok megsértése
- Jövőbeli kompatibilitási kockázatok

**Megelőzés:**
- Az MCP szerverek NEM fogadhatnak el olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki.
- Mindig ellenőrizni kell a token közönség (audience) jogosultságait, hogy megfeleljenek a várt szolgáltatásnak.

### 3. Munkamenet eltérítés

Ez akkor fordul elő, amikor egy illetéktelen fél megszerzi a munkamenet-azonosítót, és azt használva megszemélyesíti az eredeti klienst, ami illetéktelen műveletekhez vezethet.

**Megelőzés:**
- Az MCP szerverek, amelyek jogosultságkezelést valósítanak meg, MINDEN bejövő kérést ellenőrizniük kell, és NEM használhatnak munkameneteket hitelesítésre.
- Biztonságos, nem determinisztikus munkamenet-azonosítókat kell használni, amelyeket biztonságos véletlenszám-generátorokkal hoznak létre.
- A munkamenet-azonosítókat felhasználó-specifikus adatokhoz kell kötni, például `<user_id>:<session_id>` formátumban.
- Megfelelő munkamenet lejárati és forgatási szabályokat kell alkalmazni.

## További biztonsági legjobb gyakorlatok MCP-hez

Az MCP alapvető biztonsági megfontolásain túl érdemes megfontolni az alábbi további biztonsági gyakorlatokat:

- **Mindig használj HTTPS-t**: Titkosítsd a kliens és szerver közötti kommunikációt, hogy megvédd a tokeneket az elfogástól.
- **Alkalmazz szerepkör alapú hozzáférés-vezérlést (RBAC)**: Ne csak azt ellenőrizd, hogy a felhasználó hitelesített-e, hanem azt is, hogy milyen jogosultságai vannak.
- **Figyelj és naplózz**: Rögzíts minden hitelesítési eseményt, hogy észleld és reagálj a gyanús tevékenységekre.
- **Kezeld a sebességkorlátozást és a terheléscsökkentést**: Alkalmazz exponenciális visszalépést és újrapróbálkozási logikát a sebességkorlátok kezelése érdekében.
- **Biztonságos token tárolás**: Tárold az elérési és frissítő tokeneket biztonságosan, rendszer szintű biztonságos tároló mechanizmusokkal vagy biztonságos kulcskezelő szolgáltatásokkal.
- **Fontold meg API menedzsment használatát**: Olyan szolgáltatások, mint az Azure API Management, automatikusan kezelhetik sok biztonsági kérdést, beleértve a hitelesítést, jogosultságkezelést és sebességkorlátozást.

## Hivatkozások

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Mi következik

- [5.9 Web search](../web-search-mcp/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.