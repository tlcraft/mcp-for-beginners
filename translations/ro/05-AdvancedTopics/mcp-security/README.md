<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T11:14:22+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici de securitate

Securitatea este esențială pentru implementările MCP, în special în mediile enterprise. Este important să ne asigurăm că instrumentele și datele sunt protejate împotriva accesului neautorizat, scurgerilor de date și altor amenințări de securitate.

## Introducere

Model Context Protocol (MCP) necesită considerații specifice de securitate datorită rolului său de a oferi LLM-urilor acces la date și instrumente. Această lecție explorează cele mai bune practici de securitate pentru implementările MCP, bazate pe ghidurile oficiale MCP și pe modele de securitate consacrate.

MCP urmează principii cheie de securitate pentru a asigura interacțiuni sigure și de încredere:

- **Consimțământul și controlul utilizatorului**: Utilizatorii trebuie să ofere consimțământ explicit înainte ca orice date să fie accesate sau operațiuni să fie efectuate. Oferiți un control clar asupra datelor partajate și a acțiunilor autorizate.
  
- **Confidențialitatea datelor**: Datele utilizatorilor trebuie expuse doar cu consimțământ explicit și trebuie protejate prin controale adecvate de acces. Protejați împotriva transmiterii neautorizate a datelor.
  
- **Siguranța instrumentelor**: Înainte de a apela orice instrument, este necesar consimțământul explicit al utilizatorului. Utilizatorii trebuie să înțeleagă clar funcționalitatea fiecărui instrument, iar limitele de securitate trebuie aplicate riguros.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Implementa mecanisme sigure de autentificare și autorizare pentru serverele MCP.
- Proteja datele sensibile folosind criptarea și stocarea securizată.
- Asigura execuția sigură a instrumentelor cu controale adecvate de acces.
- Aplica cele mai bune practici pentru protecția datelor și conformitatea cu reglementările privind confidențialitatea.
- Identifica și atenua vulnerabilitățile comune de securitate MCP, cum ar fi problemele de tip confused deputy, token passthrough și deturnarea sesiunilor.

## Autentificare și autorizare

Autentificarea și autorizarea sunt esențiale pentru securizarea serverelor MCP. Autentificarea răspunde la întrebarea „Cine ești?” în timp ce autorizarea răspunde la „Ce poți face?”.

Conform specificației de securitate MCP, acestea sunt considerații critice de securitate:

1. **Validarea token-urilor**: Serverele MCP NU TREBUIE să accepte token-uri care nu au fost emise explicit pentru serverul MCP. „Token passthrough” este un anti-pattern interzis explicit.

2. **Verificarea autorizării**: Serverele MCP care implementează autorizare TREBUIE să verifice toate cererile primite și NU TREBUIE să folosească sesiuni pentru autentificare.

3. **Gestionarea securizată a sesiunilor**: Atunci când se folosesc sesiuni pentru stocarea stării, serverele MCP TREBUIE să utilizeze ID-uri de sesiune securizate, nedeterministe, generate cu generatoare de numere aleatoare sigure. ID-urile de sesiune AR TREBUI să fie legate de informații specifice utilizatorului.

4. **Consimțământ explicit al utilizatorului**: Pentru serverele proxy, implementările MCP TREBUIE să obțină consimțământul utilizatorului pentru fiecare client înregistrat dinamic înainte de a redirecționa către serverele de autorizare terțe.

Să vedem exemple despre cum să implementăm autentificare și autorizare securizate în serverele MCP folosind .NET și Java.

### Integrare .NET Identity

ASP .NET Core Identity oferă un cadru robust pentru gestionarea autentificării și autorizării utilizatorilor. Putem integra acest sistem cu serverele MCP pentru a securiza accesul la instrumente și resurse.

Există câteva concepte de bază pe care trebuie să le înțelegem când integrăm ASP.NET Core Identity cu serverele MCP, și anume:

- **Configurarea Identity**: Configurarea ASP.NET Core Identity cu roluri și revendicări ale utilizatorilor. O revendicare este o informație despre utilizator, cum ar fi rolul sau permisiunile, de exemplu „Admin” sau „User”.
- **Autentificare JWT**: Folosirea JSON Web Tokens (JWT) pentru acces securizat la API. JWT este un standard pentru transmiterea securizată a informațiilor între părți sub forma unui obiect JSON, care poate fi verificat și este de încredere deoarece este semnat digital.
- **Politici de autorizare**: Definirea politicilor pentru controlul accesului la instrumente specifice pe baza rolurilor utilizatorilor. MCP folosește politici de autorizare pentru a determina ce utilizatori pot accesa ce instrumente în funcție de rolurile și revendicările lor.

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

În codul de mai sus, am:

- Configurat ASP.NET Core Identity pentru gestionarea utilizatorilor.
- Setat autentificarea JWT pentru acces securizat la API. Am specificat parametrii de validare a token-ului, inclusiv emițătorul, audiența și cheia de semnare.
- Definit politici de autorizare pentru controlul accesului la instrumente pe baza rolurilor utilizatorilor. De exemplu, politica „CanUseAdminTools” necesită ca utilizatorul să aibă rolul „Admin”, în timp ce politica „CanUseBasic” necesită ca utilizatorul să fie autentificat.
- Înregistrat instrumentele MCP cu cerințe specifice de autorizare, asigurându-ne că doar utilizatorii cu rolurile potrivite pot accesa aceste instrumente.

### Integrare Java Spring Security

Pentru Java, vom folosi Spring Security pentru a implementa autentificare și autorizare securizate pentru serverele MCP. Spring Security oferă un cadru complet de securitate care se integrează perfect cu aplicațiile Spring.

Conceptele de bază sunt:

- **Configurarea Spring Security**: Setarea configurațiilor de securitate pentru autentificare și autorizare.
- **OAuth2 Resource Server**: Folosirea OAuth2 pentru acces securizat la instrumentele MCP. OAuth2 este un cadru de autorizare care permite serviciilor terțe să schimbe token-uri de acces pentru acces securizat la API.
- **Interceptori de securitate**: Implementarea interceptorilor de securitate pentru a aplica controale de acces la execuția instrumentelor.
- **Controlul accesului bazat pe roluri**: Folosirea rolurilor pentru a controla accesul la instrumente și resurse specifice.
- **Anotări de securitate**: Folosirea anotărilor pentru a securiza metode și endpoint-uri.

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

În codul de mai sus, am:

- Configurat Spring Security pentru a securiza endpoint-urile MCP, permițând acces public la descoperirea instrumentelor, dar cerând autentificare pentru execuția instrumentelor.
- Folosit OAuth2 ca server de resurse pentru a gestiona accesul securizat la instrumentele MCP.
- Implementat un interceptor de securitate pentru a aplica controale de acces la execuția instrumentelor, verificând rolurile și permisiunile utilizatorilor înainte de a permite accesul la instrumente specifice.
- Definit controlul accesului bazat pe roluri pentru a restricționa accesul la instrumentele administrative și la accesul la date sensibile în funcție de rolurile utilizatorilor.

## Protecția datelor și confidențialitatea

Protecția datelor este crucială pentru a asigura că informațiile sensibile sunt gestionate în siguranță. Aceasta include protejarea informațiilor personale identificabile (PII), a datelor financiare și a altor informații sensibile împotriva accesului neautorizat și a scurgerilor.

### Exemplu de protecție a datelor în Python

Să vedem un exemplu despre cum să implementăm protecția datelor în Python folosind criptarea și detectarea PII.

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

În codul de mai sus, am:

- Implementat o clasă `PiiDetector` pentru a scana textul și parametrii în căutare de informații personale identificabile (PII).
- Creat o clasă `EncryptionService` pentru a gestiona criptarea și decriptarea datelor sensibile folosind biblioteca `cryptography`.
- Definit un decorator `secure_tool` care învelește execuția instrumentului pentru a verifica prezența PII, a înregistra accesul și a cripta datele sensibile dacă este necesar.
- Aplicat decoratorul `secure_tool` unui instrument exemplu (`SecureCustomerDataTool`) pentru a ne asigura că gestionează datele sensibile în mod securizat.

## Riscuri specifice de securitate MCP

Conform documentației oficiale de securitate MCP, există riscuri specifice de securitate de care implementatorii MCP trebuie să fie conștienți:

### 1. Problema Confused Deputy

Această vulnerabilitate apare atunci când un server MCP acționează ca proxy pentru API-uri terțe, permițând potențial atacatorilor să exploateze relația de încredere dintre serverul MCP și aceste API-uri.

**Atenuare:**
- Serverele proxy MCP care folosesc ID-uri statice de client TREBUIE să obțină consimțământul utilizatorului pentru fiecare client înregistrat dinamic înainte de a redirecționa către serverele de autorizare terțe.
- Implementați un flux OAuth corect cu PKCE (Proof Key for Code Exchange) pentru cererile de autorizare.
- Validați strict URI-urile de redirecționare și identificatorii clientului.

### 2. Vulnerabilități Token Passthrough

Token passthrough apare atunci când un server MCP acceptă token-uri de la un client MCP fără a valida că token-urile au fost emise corect pentru serverul MCP și le transmite mai departe către API-urile downstream.

### Riscuri
- Ocolirea controalelor de securitate (evitarea limitării ratei, validarea cererilor)
- Probleme de responsabilitate și trasabilitate
- Încălcări ale limitelor de încredere
- Riscuri de compatibilitate viitoare

**Atenuare:**
- Serverele MCP NU TREBUIE să accepte token-uri care nu au fost emise explicit pentru serverul MCP.
- Validați întotdeauna revendicările audienței token-ului pentru a vă asigura că se potrivesc cu serviciul așteptat.

### 3. Deturnarea sesiunii

Aceasta apare atunci când o parte neautorizată obține un ID de sesiune și îl folosește pentru a se da drept clientul original, ceea ce poate duce la acțiuni neautorizate.

**Atenuare:**
- Serverele MCP care implementează autorizare TREBUIE să verifice toate cererile primite și NU TREBUIE să folosească sesiuni pentru autentificare.
- Folosiți ID-uri de sesiune securizate, nedeterministe, generate cu generatoare de numere aleatoare sigure.
- Legați ID-urile de sesiune de informații specifice utilizatorului folosind un format de cheie precum `<user_id>:<session_id>`.
- Implementați politici adecvate de expirare și rotație a sesiunilor.

## Alte bune practici de securitate pentru MCP

Dincolo de considerațiile de bază ale securității MCP, luați în considerare implementarea acestor practici suplimentare de securitate:

- **Folosiți întotdeauna HTTPS**: Criptați comunicația între client și server pentru a proteja token-urile de interceptare.
- **Implementați controlul accesului bazat pe roluri (RBAC)**: Nu verificați doar dacă un utilizator este autentificat; verificați ce este autorizat să facă.
- **Monitorizați și auditați**: Înregistrați toate evenimentele de autentificare pentru a detecta și răspunde la activități suspecte.
- **Gestionați limitarea ratei și throttling-ul**: Implementați backoff exponențial și logica de retry pentru a gestiona limitările ratei în mod elegant.
- **Stocare securizată a token-urilor**: Stocați token-urile de acces și refresh în mod securizat folosind mecanismele de stocare securizată ale sistemului sau servicii sigure de gestionare a cheilor.
- **Luați în considerare utilizarea API Management**: Servicii precum Azure API Management pot gestiona automat multe aspecte de securitate, inclusiv autentificarea, autorizarea și limitarea ratei.

## Referințe

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Ce urmează

- [5.9 Web search](../web-search-mcp/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.