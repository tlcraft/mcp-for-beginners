<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:43:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy

Bezpečnosť je kľúčová pre implementácie MCP, najmä v podnikových prostrediach. Je dôležité zabezpečiť, aby nástroje a dáta boli chránené pred neoprávneným prístupom, únikmi dát a inými bezpečnostnými hrozbami.

## Úvod

V tejto lekcii preskúmame najlepšie bezpečnostné postupy pre implementácie MCP. Pokryjeme autentifikáciu a autorizáciu, ochranu dát, bezpečné spúšťanie nástrojov a dodržiavanie predpisov o ochrane osobných údajov.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať bezpečné mechanizmy autentifikácie a autorizácie pre MCP servery.
- Chrániť citlivé údaje pomocou šifrovania a bezpečného ukladania.
- Zabezpečiť bezpečné spúšťanie nástrojov s vhodnou kontrolou prístupu.
- Použiť najlepšie postupy na ochranu dát a dodržiavanie pravidiel ochrany súkromia.

## Autentifikácia a autorizácia

Autentifikácia a autorizácia sú nevyhnutné pre zabezpečenie MCP serverov. Autentifikácia odpovedá na otázku „Kto ste?“, zatiaľ čo autorizácia na otázku „Čo môžete robiť?“.

Pozrime sa na príklady, ako implementovať bezpečnú autentifikáciu a autorizáciu v MCP serveroch pomocou .NET a Javy.

### Integrácia .NET Identity

ASP .NET Core Identity poskytuje robustný rámec na správu autentifikácie a autorizácie používateľov. Môžeme ho integrovať s MCP servermi na zabezpečenie prístupu k nástrojom a zdrojom.

Existujú základné koncepty, ktoré je potrebné pochopiť pri integrácii ASP.NET Core Identity s MCP servermi, a to:

- **Konfigurácia Identity**: Nastavenie ASP.NET Core Identity s používateľskými rolami a nárokmi. Nárok je informácia o používateľovi, napríklad jeho rola alebo oprávnenia, napríklad „Admin“ alebo „User“.
- **JWT autentifikácia**: Použitie JSON Web Tokenov (JWT) na bezpečný prístup k API. JWT je štandard na bezpečný prenos informácií medzi stranami vo formáte JSON, ktorý je overiteľný a dôveryhodný, pretože je digitálne podpísaný.
- **Autorizacné politiky**: Definovanie politík na kontrolu prístupu k špecifickým nástrojom na základe používateľských rolí. MCP používa autorizacné politiky na určenie, ktorí používatelia môžu pristupovať k akým nástrojom podľa ich rolí a nárokov.

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

- Nakonfigurovali ASP.NET Core Identity na správu používateľov.
- Nastavili JWT autentifikáciu pre bezpečný prístup k API. Špecifikovali sme parametre overovania tokenu, vrátane vydavateľa, publika a podpisového kľúča.
- Definovali autorizacné politiky na kontrolu prístupu k nástrojom podľa používateľských rolí. Napríklad politika „CanUseAdminTools“ vyžaduje, aby používateľ mal rolu „Admin“, zatiaľ čo politika „CanUseBasic“ vyžaduje, aby bol používateľ autentifikovaný.
- Registrovali MCP nástroje so špecifickými požiadavkami na autorizáciu, čím sme zabezpečili, že k nim majú prístup len používatelia s príslušnými rolami.

### Integrácia Java Spring Security

Pre Javu použijeme Spring Security na implementáciu bezpečnej autentifikácie a autorizácie pre MCP servery. Spring Security poskytuje komplexný bezpečnostný rámec, ktorý sa hladko integruje so Spring aplikáciami.

Základné koncepty sú:

- **Konfigurácia Spring Security**: Nastavenie bezpečnostných konfigurácií pre autentifikáciu a autorizáciu.
- **OAuth2 Resource Server**: Použitie OAuth2 na bezpečný prístup k MCP nástrojom. OAuth2 je autorizačný rámec, ktorý umožňuje tretím stranám vymieňať prístupové tokeny na bezpečný prístup k API.
- **Bezpečnostné interceptory**: Implementácia bezpečnostných interceptorov na vynucovanie kontrol prístupu pri spúšťaní nástrojov.
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

- Nakonfigurovali Spring Security na zabezpečenie MCP endpointov, pričom sme umožnili verejný prístup k objavovaniu nástrojov a vyžadovali autentifikáciu pre spúšťanie nástrojov.
- Použili OAuth2 ako resource server na spracovanie bezpečného prístupu k MCP nástrojom.
- Implementovali bezpečnostný interceptor na vynucovanie kontrol prístupu pri spúšťaní nástrojov, kontrolujúc používateľské roly a oprávnenia pred povolením prístupu k špecifickým nástrojom.
- Definovali riadenie prístupu na základe rolí na obmedzenie prístupu k administrátorským nástrojom a citlivým dátam podľa používateľských rolí.

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
- Definovali dekorátor `secure_tool`, ktorý obalí spúšťanie nástroja, aby kontroloval PII, zaznamenával prístupy a v prípade potreby šifroval citlivé dáta.
- Aplikovali dekorátor `secure_tool` na ukážkový nástroj (`SecureCustomerDataTool`), aby sme zabezpečili bezpečné spracovanie citlivých dát.

## Čo ďalej

- [5.9 Web search](../web-search-mcp/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.