<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T10:59:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy

Bezpečnosť je kľúčová pre implementácie MCP, najmä v podnikových prostrediach. Je dôležité zabezpečiť, aby nástroje a dáta boli chránené pred neoprávneným prístupom, únikmi dát a inými bezpečnostnými hrozbami.

## Úvod

Model Context Protocol (MCP) vyžaduje špecifické bezpečnostné opatrenia vzhľadom na svoju úlohu poskytovať LLM prístup k dátam a nástrojom. Táto lekcia skúma najlepšie bezpečnostné postupy pre implementácie MCP na základe oficiálnych MCP smerníc a osvedčených bezpečnostných vzorov.

MCP dodržiava kľúčové bezpečnostné princípy, aby zabezpečil bezpečnú a dôveryhodnú interakciu:

- **Súhlas a kontrola používateľa**: Používatelia musia výslovne súhlasiť predtým, než sa pristúpi k dátam alebo vykonajú operácie. Poskytnite jasnú kontrolu nad tým, aké dáta sa zdieľajú a ktoré akcie sú povolené.
  
- **Ochrana súkromia dát**: Dáta používateľa by mali byť sprístupnené len s výslovným súhlasom a musia byť chránené vhodnými prístupovými kontrolami. Zabezpečte ochranu pred neoprávneným prenosom dát.
  
- **Bezpečnosť nástrojov**: Pred spustením akéhokoľvek nástroja je potrebný výslovný súhlas používateľa. Používatelia by mali mať jasné pochopenie funkčnosti každého nástroja a musia byť vynútené pevné bezpečnostné hranice.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať bezpečné mechanizmy autentifikácie a autorizácie pre MCP servery.
- Chrániť citlivé dáta pomocou šifrovania a bezpečného ukladania.
- Zabezpečiť bezpečné vykonávanie nástrojov s vhodnými prístupovými kontrolami.
- Použiť najlepšie postupy na ochranu dát a dodržiavanie pravidiel ochrany súkromia.
- Identifikovať a zmierniť bežné bezpečnostné zraniteľnosti MCP, ako sú problémy s „confused deputy“, token passthrough a únos relácie.

## Autentifikácia a autorizácia

Autentifikácia a autorizácia sú nevyhnutné pre zabezpečenie MCP serverov. Autentifikácia odpovedá na otázku „Kto ste?“, zatiaľ čo autorizácia na otázku „Čo môžete robiť?“.

Podľa bezpečnostnej špecifikácie MCP sú tieto aspekty kritické:

1. **Validácia tokenov**: MCP servery NESMÚ akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre daný MCP server. „Token passthrough“ je výslovne zakázaný anti-vzor.

2. **Overovanie autorizácie**: MCP servery, ktoré implementujú autorizáciu, MUSIA overovať všetky prichádzajúce požiadavky a NESMÚ používať relácie na autentifikáciu.

3. **Bezpečná správa relácií**: Pri používaní relácií na uchovávanie stavu MUSIA MCP servery používať bezpečné, nedeterministické ID relácií generované bezpečnými generátormi náhodných čísel. ID relácií by MALI byť viazané na informácie špecifické pre používateľa.

4. **Výslovný súhlas používateľa**: Pre proxy servery MUSIA implementácie MCP získať súhlas používateľa pre každého dynamicky registrovaného klienta predtým, než požiadavky presmerujú na autorizáciu tretích strán.

Pozrime sa na príklady, ako implementovať bezpečnú autentifikáciu a autorizáciu v MCP serveroch pomocou .NET a Java.

### Integrácia .NET Identity

ASP .NET Core Identity poskytuje robustný rámec na správu autentifikácie a autorizácie používateľov. Môžeme ho integrovať s MCP servermi na zabezpečenie prístupu k nástrojom a zdrojom.

Existujú základné koncepty, ktoré je potrebné pochopiť pri integrácii ASP.NET Core Identity s MCP servermi:

- **Konfigurácia Identity**: Nastavenie ASP.NET Core Identity s používateľskými rolami a nárokmi (claims). Nárok je informácia o používateľovi, napríklad jeho rola alebo oprávnenia, napríklad „Admin“ alebo „User“.
- **JWT autentifikácia**: Použitie JSON Web Tokenov (JWT) na bezpečný prístup k API. JWT je štandard na bezpečný prenos informácií medzi stranami vo formáte JSON, ktorý je overiteľný a dôveryhodný, pretože je digitálne podpísaný.
- **Autorizácia pomocou politík**: Definovanie politík na kontrolu prístupu k špecifickým nástrojom na základe rolí používateľov. MCP používa autorizáciu na základe politík, aby určil, ktorí používatelia môžu pristupovať k akým nástrojom podľa ich rolí a nárokov.

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

V predchádzajúcom kóde sme:

- Nakonfigurovali ASP.NET Core Identity pre správu používateľov.
- Nastavili JWT autentifikáciu pre bezpečný prístup k API. Špecifikovali sme parametre validácie tokenu vrátane vydavateľa, publika a podpisového kľúča.
- Definovali politiky autorizácie na kontrolu prístupu k nástrojom podľa rolí používateľov. Napríklad politika „CanUseAdminTools“ vyžaduje, aby používateľ mal rolu „Admin“, zatiaľ čo politika „CanUseBasic“ vyžaduje, aby bol používateľ autentifikovaný.
- Registrovali MCP nástroje so špecifickými požiadavkami na autorizáciu, čím sme zabezpečili, že k nim majú prístup len používatelia s príslušnými rolami.

### Integrácia Java Spring Security

Pre Javu použijeme Spring Security na implementáciu bezpečnej autentifikácie a autorizácie pre MCP servery. Spring Security poskytuje komplexný bezpečnostný rámec, ktorý sa hladko integruje so Spring aplikáciami.

Základné koncepty sú:

- **Konfigurácia Spring Security**: Nastavenie bezpečnostných konfigurácií pre autentifikáciu a autorizáciu.
- **OAuth2 Resource Server**: Použitie OAuth2 na bezpečný prístup k MCP nástrojom. OAuth2 je autorizačný rámec, ktorý umožňuje tretím stranám vymieňať prístupové tokeny na bezpečný prístup k API.
- **Bezpečnostné interceptory**: Implementácia bezpečnostných interceptorov na vynútenie prístupových kontrol pri vykonávaní nástrojov.
- **Riadenie prístupu na základe rolí**: Použitie rolí na kontrolu prístupu k špecifickým nástrojom a zdrojom.
- **Bezpečnostné anotácie**: Použitie anotácií na zabezpečenie metód a endpointov.

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

V predchádzajúcom kóde sme:

- Nakonfigurovali Spring Security na zabezpečenie MCP endpointov, umožňujúc verejný prístup k objavovaniu nástrojov a vyžadujúc autentifikáciu pre ich vykonávanie.
- Použili OAuth2 ako resource server na spracovanie bezpečného prístupu k MCP nástrojom.
- Implementovali bezpečnostný interceptor na vynútenie prístupových kontrol pri vykonávaní nástrojov, kontrolujúc roly a oprávnenia používateľa pred povolením prístupu k špecifickým nástrojom.
- Definovali riadenie prístupu na základe rolí na obmedzenie prístupu k administrátorským nástrojom a citlivým dátam podľa rolí používateľov.

## Ochrana dát a súkromie

Ochrana dát je nevyhnutná na zabezpečenie, že citlivé informácie sú spracovávané bezpečne. To zahŕňa ochranu osobných identifikovateľných údajov (PII), finančných dát a iných citlivých informácií pred neoprávneným prístupom a únikmi.

### Príklad ochrany dát v Pythone

Pozrime sa na príklad, ako implementovať ochranu dát v Pythone pomocou šifrovania a detekcie PII.

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

V predchádzajúcom kóde sme:

- Implementovali triedu `PiiDetector` na skenovanie textu a parametrov na osobné identifikovateľné informácie (PII).
- Vytvorili triedu `EncryptionService` na šifrovanie a dešifrovanie citlivých dát pomocou knižnice `cryptography`.
- Definovali dekorátor `secure_tool`, ktorý obalí vykonávanie nástroja, aby kontroloval PII, zaznamenával prístupy a šifroval citlivé dáta, ak je to potrebné.
- Aplikovali dekorátor `secure_tool` na ukážkový nástroj (`SecureCustomerDataTool`), aby sme zabezpečili bezpečné spracovanie citlivých dát.

## Špecifické bezpečnostné riziká MCP

Podľa oficiálnej MCP bezpečnostnej dokumentácie existujú špecifické bezpečnostné riziká, o ktorých by mali implementátori MCP vedieť:

### 1. Problém „confused deputy“

Táto zraniteľnosť nastáva, keď MCP server funguje ako proxy pre API tretích strán, čo môže útočníkom umožniť zneužiť dôverný vzťah medzi MCP serverom a týmito API.

**Zmiernenie:**
- MCP proxy servery používajúce statické ID klienta MUSIA získať súhlas používateľa pre každého dynamicky registrovaného klienta pred presmerovaním na autorizáciu tretích strán.
- Implementujte správny OAuth tok s PKCE (Proof Key for Code Exchange) pre autorizačné požiadavky.
- Prísne validujte redirect URI a identifikátory klientov.

### 2. Zraniteľnosti token passthrough

Token passthrough nastáva, keď MCP server akceptuje tokeny od MCP klienta bez overenia, že tokeny boli správne vydané pre MCP server, a následne ich posiela ďalej do downstream API.

### Riziká
- Obchádzanie bezpečnostných kontrol (napr. obmedzenia počtu požiadaviek, validácie požiadaviek)
- Problémy s účtovateľnosťou a auditom
- Porušenie dôveryhodnostnej hranice
- Riziká budúcej kompatibility

**Zmiernenie:**
- MCP servery NESMÚ akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre daný MCP server.
- Vždy validujte nároky publika tokenu, aby zodpovedali očakávanému servisu.

### 3. Únos relácie

K tomu dochádza, keď neoprávnená osoba získa ID relácie a použije ho na vydávanie sa za pôvodného klienta, čo môže viesť k neoprávneným akciám.

**Zmiernenie:**
- MCP servery, ktoré implementujú autorizáciu, MUSIA overovať všetky prichádzajúce požiadavky a NESMÚ používať relácie na autentifikáciu.
- Používajte bezpečné, nedeterministické ID relácií generované bezpečnými generátormi náhodných čísel.
- Viažte ID relácií na informácie špecifické pre používateľa pomocou formátu kľúča ako `<user_id>:<session_id>`.
- Implementujte správne politiky vypršania platnosti a rotácie relácií.

## Ďalšie bezpečnostné odporúčania pre MCP

Okrem základných bezpečnostných opatrení MCP zvážte implementáciu týchto dodatočných bezpečnostných praktík:

- **Vždy používajte HTTPS**: Šifrujte komunikáciu medzi klientom a serverom, aby ste ochránili tokeny pred zachytením.
- **Implementujte riadenie prístupu na základe rolí (RBAC)**: Nekontrolujte len, či je používateľ autentifikovaný, ale aj čo má oprávnenie robiť.
- **Monitorujte a auditujte**: Zaznamenávajte všetky autentifikačné udalosti na detekciu a reakciu na podozrivú aktivitu.
- **Riešte obmedzovanie rýchlosti a throttling**: Implementujte exponenciálne spätné odklady a logiku opakovaných pokusov na hladké zvládanie limitov.
- **Bezpečné ukladanie tokenov**: Ukladajte prístupové a obnovovacie tokeny bezpečne pomocou systémových bezpečných úložísk alebo služieb na správu kľúčov.
- **Zvážte použitie API Management**: Služby ako Azure API Management môžu automaticky riešiť mnohé bezpečnostné otázky vrátane autentifikácie, autorizácie a obmedzovania rýchlosti.

## Referencie

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Čo ďalej

- [5.9 Web search](../web-search-mcp/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.