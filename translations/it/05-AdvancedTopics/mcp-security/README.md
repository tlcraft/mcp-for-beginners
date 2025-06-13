<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T23:43:03+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "it"
}
-->
# Pratiche di Sicurezza Consigliate

La sicurezza è fondamentale per le implementazioni MCP, soprattutto in ambienti aziendali. È importante garantire che strumenti e dati siano protetti da accessi non autorizzati, violazioni dei dati e altre minacce alla sicurezza.

## Introduzione

In questa lezione, esploreremo le migliori pratiche di sicurezza per le implementazioni MCP. Tratteremo autenticazione e autorizzazione, protezione dei dati, esecuzione sicura degli strumenti e conformità alle normative sulla privacy dei dati.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Implementare meccanismi sicuri di autenticazione e autorizzazione per i server MCP.
- Proteggere i dati sensibili utilizzando crittografia e archiviazione sicura.
- Garantire l’esecuzione sicura degli strumenti con controlli di accesso appropriati.
- Applicare le migliori pratiche per la protezione dei dati e la conformità alla privacy.

## Autenticazione e Autorizzazione

Autenticazione e autorizzazione sono essenziali per mettere in sicurezza i server MCP. L’autenticazione risponde alla domanda "Chi sei?" mentre l’autorizzazione risponde a "Cosa puoi fare?".

Vediamo esempi di come implementare autenticazione e autorizzazione sicure nei server MCP usando .NET e Java.

### Integrazione .NET Identity

ASP .NET Core Identity fornisce un framework solido per la gestione dell’autenticazione e dell’autorizzazione degli utenti. Possiamo integrarlo con i server MCP per proteggere l’accesso a strumenti e risorse.

Ci sono alcuni concetti chiave da comprendere quando si integra ASP.NET Core Identity con i server MCP, nello specifico:

- **Configurazione Identity**: Configurare ASP.NET Core Identity con ruoli utente e claims. Un claim è un’informazione sull’utente, come il suo ruolo o permessi, ad esempio "Admin" o "User".
- **Autenticazione JWT**: Usare JSON Web Tokens (JWT) per un accesso API sicuro. JWT è uno standard per trasmettere informazioni in modo sicuro tra le parti come oggetto JSON, che può essere verificato e considerato affidabile perché firmato digitalmente.
- **Policy di Autorizzazione**: Definire policy per controllare l’accesso a strumenti specifici basate sui ruoli utente. MCP utilizza queste policy per determinare quali utenti possono accedere a quali strumenti in base a ruoli e claims.

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

Nel codice precedente abbiamo:

- Configurato ASP.NET Core Identity per la gestione utenti.
- Impostato l’autenticazione JWT per un accesso API sicuro, specificando i parametri di validazione del token, inclusi issuer, audience e chiave di firma.
- Definito policy di autorizzazione per controllare l’accesso agli strumenti in base ai ruoli. Per esempio, la policy "CanUseAdminTools" richiede il ruolo "Admin", mentre "CanUseBasic" richiede che l’utente sia autenticato.
- Registrato gli strumenti MCP con requisiti di autorizzazione specifici, assicurando che solo gli utenti con i ruoli appropriati possano accedervi.

### Integrazione Java Spring Security

Per Java, utilizzeremo Spring Security per implementare autenticazione e autorizzazione sicure per i server MCP. Spring Security offre un framework completo che si integra perfettamente con le applicazioni Spring.

I concetti chiave sono:

- **Configurazione Spring Security**: Impostare le configurazioni di sicurezza per autenticazione e autorizzazione.
- **OAuth2 Resource Server**: Usare OAuth2 per un accesso sicuro agli strumenti MCP. OAuth2 è un framework di autorizzazione che permette a servizi terzi di scambiare token di accesso per un accesso API sicuro.
- **Interceptor di Sicurezza**: Implementare interceptor di sicurezza per far rispettare i controlli di accesso durante l’esecuzione degli strumenti.
- **Controllo Accesso Basato su Ruoli**: Usare i ruoli per controllare l’accesso a strumenti e risorse specifiche.
- **Annotazioni di Sicurezza**: Usare annotazioni per mettere in sicurezza metodi ed endpoint.

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

Nel codice precedente abbiamo:

- Configurato Spring Security per mettere in sicurezza gli endpoint MCP, permettendo accesso pubblico alla scoperta degli strumenti ma richiedendo autenticazione per l’esecuzione.
- Usato OAuth2 come resource server per gestire l’accesso sicuro agli strumenti MCP.
- Implementato un interceptor di sicurezza per far rispettare i controlli di accesso durante l’esecuzione degli strumenti, verificando ruoli e permessi prima di consentire l’accesso a strumenti specifici.
- Definito il controllo accesso basato su ruoli per limitare l’accesso agli strumenti admin e ai dati sensibili in base ai ruoli utente.

## Protezione dei Dati e Privacy

La protezione dei dati è fondamentale per garantire che le informazioni sensibili siano gestite in modo sicuro. Questo include la protezione delle informazioni personali identificabili (PII), dati finanziari e altre informazioni sensibili da accessi non autorizzati e violazioni.

### Esempio di Protezione Dati in Python

Vediamo un esempio di come implementare la protezione dei dati in Python usando crittografia e rilevamento PII.

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

Nel codice precedente abbiamo:

- Implementato un `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) per garantire che gestisca i dati sensibili in modo sicuro.

## Cosa fare dopo

- [5.9 Web search](../web-search-mcp/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.