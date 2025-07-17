<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T01:16:29+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "it"
}
-->
# Best Practice di Sicurezza

La sicurezza è fondamentale per le implementazioni MCP, specialmente in ambienti aziendali. È importante garantire che strumenti e dati siano protetti da accessi non autorizzati, violazioni dei dati e altre minacce alla sicurezza.

## Introduzione

Il Model Context Protocol (MCP) richiede considerazioni specifiche di sicurezza a causa del suo ruolo nel fornire agli LLM l'accesso a dati e strumenti. Questa lezione esplora le best practice di sicurezza per le implementazioni MCP basate sulle linee guida ufficiali MCP e su modelli di sicurezza consolidati.

MCP segue principi chiave di sicurezza per garantire interazioni sicure e affidabili:

- **Consenso e Controllo dell’Utente**: Gli utenti devono fornire un consenso esplicito prima che qualsiasi dato venga accesso o che vengano eseguite operazioni. Fornire un controllo chiaro su quali dati vengono condivisi e quali azioni sono autorizzate.
  
- **Privacy dei Dati**: I dati degli utenti devono essere esposti solo con consenso esplicito e devono essere protetti da adeguati controlli di accesso. Proteggere contro la trasmissione non autorizzata dei dati.
  
- **Sicurezza degli Strumenti**: Prima di invocare qualsiasi strumento, è richiesto il consenso esplicito dell’utente. Gli utenti devono comprendere chiaramente la funzionalità di ogni strumento e devono essere applicati confini di sicurezza robusti.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Implementare meccanismi sicuri di autenticazione e autorizzazione per i server MCP.
- Proteggere dati sensibili usando crittografia e archiviazione sicura.
- Garantire l’esecuzione sicura degli strumenti con adeguati controlli di accesso.
- Applicare best practice per la protezione dei dati e la conformità alla privacy.
- Identificare e mitigare vulnerabilità comuni di sicurezza MCP come problemi di confused deputy, token passthrough e session hijacking.

## Autenticazione e Autorizzazione

Autenticazione e autorizzazione sono essenziali per la sicurezza dei server MCP. L’autenticazione risponde alla domanda "Chi sei?" mentre l’autorizzazione risponde a "Cosa puoi fare?".

Secondo la specifica di sicurezza MCP, queste sono considerazioni critiche:

1. **Validazione del Token**: I server MCP NON DEVONO accettare token che non siano stati esplicitamente emessi per il server MCP. Il "token passthrough" è un anti-pattern esplicitamente vietato.

2. **Verifica dell’Autorizzazione**: I server MCP che implementano l’autorizzazione DEVONO verificare tutte le richieste in ingresso e NON DEVONO usare sessioni per l’autenticazione.

3. **Gestione Sicura delle Sessioni**: Quando si usano sessioni per lo stato, i server MCP DEVONO utilizzare ID di sessione sicuri e non deterministici generati con generatori di numeri casuali sicuri. Gli ID di sessione DOVREBBERO essere legati a informazioni specifiche dell’utente.

4. **Consenso Esplicito dell’Utente**: Per i server proxy, le implementazioni MCP DEVONO ottenere il consenso dell’utente per ogni client registrato dinamicamente prima di inoltrare a server di autorizzazione di terze parti.

Vediamo esempi di come implementare autenticazione e autorizzazione sicure in server MCP usando .NET e Java.

### Integrazione .NET Identity

ASP .NET Core Identity fornisce un framework solido per gestire autenticazione e autorizzazione degli utenti. Possiamo integrarlo con i server MCP per proteggere l’accesso a strumenti e risorse.

Ci sono alcuni concetti chiave da comprendere quando si integra ASP.NET Core Identity con i server MCP, ovvero:

- **Configurazione di Identity**: Configurare ASP.NET Core Identity con ruoli e claim degli utenti. Un claim è un’informazione sull’utente, come il suo ruolo o permessi, ad esempio "Admin" o "User".
- **Autenticazione JWT**: Usare JSON Web Tokens (JWT) per un accesso API sicuro. JWT è uno standard per trasmettere informazioni in modo sicuro tra le parti come oggetto JSON, che può essere verificato e considerato affidabile perché firmato digitalmente.
- **Policy di Autorizzazione**: Definire policy per controllare l’accesso a strumenti specifici basate sui ruoli degli utenti. MCP usa policy di autorizzazione per determinare quali utenti possono accedere a quali strumenti in base ai loro ruoli e claim.

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

Nel codice precedente, abbiamo:

- Configurato ASP.NET Core Identity per la gestione degli utenti.
- Impostato l’autenticazione JWT per un accesso API sicuro. Abbiamo specificato i parametri di validazione del token, inclusi issuer, audience e chiave di firma.
- Definito policy di autorizzazione per controllare l’accesso agli strumenti in base ai ruoli degli utenti. Ad esempio, la policy "CanUseAdminTools" richiede che l’utente abbia il ruolo "Admin", mentre la policy "CanUseBasic" richiede che l’utente sia autenticato.
- Registrato strumenti MCP con requisiti di autorizzazione specifici, assicurando che solo utenti con i ruoli appropriati possano accedervi.

### Integrazione Java Spring Security

Per Java, useremo Spring Security per implementare autenticazione e autorizzazione sicure per i server MCP. Spring Security fornisce un framework di sicurezza completo che si integra perfettamente con le applicazioni Spring.

I concetti chiave qui sono:

- **Configurazione di Spring Security**: Impostare configurazioni di sicurezza per autenticazione e autorizzazione.
- **OAuth2 Resource Server**: Usare OAuth2 per l’accesso sicuro agli strumenti MCP. OAuth2 è un framework di autorizzazione che permette a servizi terzi di scambiare token di accesso per un accesso API sicuro.
- **Interceptor di Sicurezza**: Implementare interceptor di sicurezza per applicare controlli di accesso sull’esecuzione degli strumenti.
- **Controllo di Accesso Basato sui Ruoli**: Usare i ruoli per controllare l’accesso a strumenti e risorse specifiche.
- **Annotazioni di Sicurezza**: Usare annotazioni per proteggere metodi ed endpoint.

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

Nel codice precedente, abbiamo:

- Configurato Spring Security per proteggere gli endpoint MCP, permettendo accesso pubblico alla scoperta degli strumenti e richiedendo autenticazione per l’esecuzione degli strumenti.
- Usato OAuth2 come resource server per gestire l’accesso sicuro agli strumenti MCP.
- Implementato un interceptor di sicurezza per applicare controlli di accesso sull’esecuzione degli strumenti, verificando ruoli e permessi degli utenti prima di consentire l’accesso a strumenti specifici.
- Definito controllo di accesso basato sui ruoli per limitare l’accesso agli strumenti amministrativi e ai dati sensibili in base ai ruoli degli utenti.

## Protezione dei Dati e Privacy

La protezione dei dati è cruciale per garantire che le informazioni sensibili siano gestite in modo sicuro. Questo include la protezione di informazioni personali identificabili (PII), dati finanziari e altre informazioni sensibili da accessi non autorizzati e violazioni.

### Esempio di Protezione dei Dati in Python

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

Nel codice precedente, abbiamo:

- Implementato una classe `PiiDetector` per scansionare testo e parametri alla ricerca di informazioni personali identificabili (PII).
- Creato una classe `EncryptionService` per gestire la crittografia e decrittografia di dati sensibili usando la libreria `cryptography`.
- Definito un decoratore `secure_tool` che avvolge l’esecuzione dello strumento per controllare la presenza di PII, registrare gli accessi e criptare i dati sensibili se necessario.
- Applicato il decoratore `secure_tool` a un esempio di strumento (`SecureCustomerDataTool`) per garantire che gestisca i dati sensibili in modo sicuro.

## Rischi di Sicurezza Specifici MCP

Secondo la documentazione ufficiale di sicurezza MCP, ci sono rischi specifici di sicurezza di cui gli implementatori MCP devono essere consapevoli:

### 1. Problema del Confused Deputy

Questa vulnerabilità si verifica quando un server MCP agisce da proxy verso API di terze parti, potenzialmente permettendo ad attaccanti di sfruttare il rapporto di fiducia tra il server MCP e queste API.

**Mitigazione:**
- I server proxy MCP che usano client ID statici DEVONO ottenere il consenso dell’utente per ogni client registrato dinamicamente prima di inoltrare a server di autorizzazione di terze parti.
- Implementare un corretto flusso OAuth con PKCE (Proof Key for Code Exchange) per le richieste di autorizzazione.
- Validare rigorosamente gli URI di redirect e gli identificatori client.

### 2. Vulnerabilità di Token Passthrough

Il token passthrough si verifica quando un server MCP accetta token da un client MCP senza verificare che i token siano stati correttamente emessi per il server MCP e li passa a valle verso API downstream.

### Rischi
- Circumvenzione dei controlli di sicurezza (bypass di rate limiting, validazione delle richieste)
- Problemi di responsabilità e tracciabilità
- Violazioni dei confini di fiducia
- Rischi di compatibilità futura

**Mitigazione:**
- I server MCP NON DEVONO accettare token che non siano stati esplicitamente emessi per il server MCP.
- Validare sempre i claim audience del token per assicurarsi che corrispondano al servizio previsto.

### 3. Session Hijacking

Si verifica quando una parte non autorizzata ottiene un ID di sessione e lo usa per impersonare il client originale, potenzialmente causando azioni non autorizzate.

**Mitigazione:**
- I server MCP che implementano l’autorizzazione DEVONO verificare tutte le richieste in ingresso e NON DEVONO usare sessioni per l’autenticazione.
- Usare ID di sessione sicuri e non deterministici generati con generatori di numeri casuali sicuri.
- Legare gli ID di sessione a informazioni specifiche dell’utente usando un formato chiave come `<user_id>:<session_id>`.
- Implementare politiche corrette di scadenza e rotazione delle sessioni.

## Ulteriori Best Practice di Sicurezza per MCP

Oltre alle considerazioni di sicurezza core MCP, considera di implementare queste ulteriori pratiche di sicurezza:

- **Usa sempre HTTPS**: Cripta la comunicazione tra client e server per proteggere i token dall’intercettazione.
- **Implementa il Controllo di Accesso Basato sui Ruoli (RBAC)**: Non limitarti a verificare se un utente è autenticato; verifica cosa è autorizzato a fare.
- **Monitora e registra**: Registra tutti gli eventi di autenticazione per rilevare e rispondere ad attività sospette.
- **Gestisci rate limiting e throttling**: Implementa backoff esponenziale e logiche di retry per gestire i limiti di richiesta in modo elegante.
- **Archiviazione sicura dei token**: Conserva i token di accesso e refresh in modo sicuro usando meccanismi di archiviazione sicura di sistema o servizi di gestione chiavi sicuri.
- **Considera l’uso di API Management**: Servizi come Azure API Management possono gestire automaticamente molte preoccupazioni di sicurezza, inclusi autenticazione, autorizzazione e rate limiting.

## Riferimenti

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Cosa c’è dopo

- [5.9 Web search](../web-search-mcp/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.