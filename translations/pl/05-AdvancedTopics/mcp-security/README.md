<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T22:37:09+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa

Bezpieczeństwo jest kluczowe dla implementacji MCP, zwłaszcza w środowiskach korporacyjnych. Ważne jest, aby narzędzia i dane były chronione przed nieautoryzowanym dostępem, wyciekami danych oraz innymi zagrożeniami bezpieczeństwa.

## Wprowadzenie

Model Context Protocol (MCP) wymaga szczególnych rozważań dotyczących bezpieczeństwa ze względu na swoją rolę w udostępnianiu LLM dostępu do danych i narzędzi. Ta lekcja omawia najlepsze praktyki bezpieczeństwa dla implementacji MCP, opierając się na oficjalnych wytycznych MCP oraz sprawdzonych wzorcach bezpieczeństwa.

MCP opiera się na kluczowych zasadach bezpieczeństwa, aby zapewnić bezpieczne i godne zaufania interakcje:

- **Zgoda i kontrola użytkownika**: Użytkownicy muszą wyrazić wyraźną zgodę przed uzyskaniem dostępu do danych lub wykonaniem operacji. Zapewnij jasną kontrolę nad tym, jakie dane są udostępniane i które działania są autoryzowane.
  
- **Prywatność danych**: Dane użytkownika powinny być udostępniane tylko za wyraźną zgodą i chronione odpowiednimi mechanizmami kontroli dostępu. Zabezpiecz przed nieautoryzowanym przesyłaniem danych.
  
- **Bezpieczeństwo narzędzi**: Przed wywołaniem jakiegokolwiek narzędzia wymagana jest wyraźna zgoda użytkownika. Użytkownicy powinni mieć jasne zrozumienie funkcji każdego narzędzia, a granice bezpieczeństwa muszą być rygorystycznie egzekwowane.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Wdrażać bezpieczne mechanizmy uwierzytelniania i autoryzacji dla serwerów MCP.
- Chronić wrażliwe dane za pomocą szyfrowania i bezpiecznego przechowywania.
- Zapewnić bezpieczne wykonywanie narzędzi z odpowiednimi kontrolami dostępu.
- Stosować najlepsze praktyki ochrony danych i zgodności z przepisami o prywatności.
- Identyfikować i łagodzić typowe luki bezpieczeństwa MCP, takie jak problemy typu confused deputy, token passthrough i przejęcie sesji.

## Uwierzytelnianie i autoryzacja

Uwierzytelnianie i autoryzacja są niezbędne do zabezpieczenia serwerów MCP. Uwierzytelnianie odpowiada na pytanie „Kim jesteś?”, natomiast autoryzacja na „Co możesz zrobić?”.

Zgodnie ze specyfikacją bezpieczeństwa MCP, są to kluczowe kwestie bezpieczeństwa:

1. **Weryfikacja tokenów**: Serwery MCP NIE MOGĄ akceptować żadnych tokenów, które nie zostały wyraźnie wydane dla serwera MCP. „Token passthrough” jest wyraźnie zabronionym antywzorcem.

2. **Weryfikacja autoryzacji**: Serwery MCP implementujące autoryzację MUSZĄ weryfikować wszystkie przychodzące żądania i NIE MOGĄ używać sesji do uwierzytelniania.

3. **Bezpieczne zarządzanie sesjami**: Przy używaniu sesji do przechowywania stanu, serwery MCP MUSZĄ stosować bezpieczne, niedeterministyczne identyfikatory sesji generowane za pomocą bezpiecznych generatorów liczb losowych. Identyfikatory sesji POWINNY być powiązane z informacjami specyficznymi dla użytkownika.

4. **Wyraźna zgoda użytkownika**: W przypadku serwerów proxy implementacje MCP MUSZĄ uzyskać zgodę użytkownika dla każdego dynamicznie rejestrowanego klienta przed przekazaniem do zewnętrznych serwerów autoryzacji.

Przyjrzyjmy się przykładom implementacji bezpiecznego uwierzytelniania i autoryzacji w serwerach MCP z użyciem .NET i Java.

### Integracja z .NET Identity

ASP .NET Core Identity oferuje solidne ramy do zarządzania uwierzytelnianiem i autoryzacją użytkowników. Możemy zintegrować je z serwerami MCP, aby zabezpieczyć dostęp do narzędzi i zasobów.

Istnieją podstawowe koncepcje, które musimy zrozumieć przy integracji ASP.NET Core Identity z serwerami MCP, mianowicie:

- **Konfiguracja Identity**: Konfiguracja ASP.NET Core Identity z rolami i roszczeniami użytkowników. Roszczenie to informacja o użytkowniku, np. jego rola lub uprawnienia, takie jak „Admin” lub „User”.
- **Uwierzytelnianie JWT**: Użycie JSON Web Tokens (JWT) do bezpiecznego dostępu do API. JWT to standard bezpiecznego przesyłania informacji między stronami jako obiekt JSON, który można zweryfikować i któremu można zaufać, ponieważ jest cyfrowo podpisany.
- **Polityki autoryzacji**: Definiowanie polityk kontrolujących dostęp do konkretnych narzędzi na podstawie ról użytkowników. MCP używa polityk autoryzacji, aby określić, którzy użytkownicy mogą korzystać z których narzędzi na podstawie ich ról i roszczeń.

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

W powyższym kodzie:

- Skonfigurowaliśmy ASP.NET Core Identity do zarządzania użytkownikami.
- Ustawiliśmy uwierzytelnianie JWT dla bezpiecznego dostępu do API. Określiliśmy parametry walidacji tokenów, w tym wydawcę, odbiorcę i klucz podpisu.
- Zdefiniowaliśmy polityki autoryzacji kontrolujące dostęp do narzędzi na podstawie ról użytkowników. Na przykład polityka „CanUseAdminTools” wymaga roli „Admin”, a polityka „CanUseBasic” wymaga uwierzytelnienia użytkownika.
- Zarejestrowaliśmy narzędzia MCP z określonymi wymaganiami autoryzacyjnymi, zapewniając, że tylko użytkownicy z odpowiednimi rolami mają do nich dostęp.

### Integracja z Java Spring Security

Dla Javy użyjemy Spring Security do implementacji bezpiecznego uwierzytelniania i autoryzacji dla serwerów MCP. Spring Security oferuje kompleksowy framework bezpieczeństwa, który integruje się bezproblemowo z aplikacjami Spring.

Podstawowe koncepcje to:

- **Konfiguracja Spring Security**: Ustawienia bezpieczeństwa dla uwierzytelniania i autoryzacji.
- **OAuth2 Resource Server**: Użycie OAuth2 do bezpiecznego dostępu do narzędzi MCP. OAuth2 to framework autoryzacji pozwalający usługom trzecim wymieniać tokeny dostępu dla bezpiecznego dostępu do API.
- **Interceptory bezpieczeństwa**: Implementacja interceptorów bezpieczeństwa do egzekwowania kontroli dostępu przy wykonywaniu narzędzi.
- **Kontrola dostępu oparta na rolach**: Użycie ról do kontrolowania dostępu do konkretnych narzędzi i zasobów.
- **Adnotacje bezpieczeństwa**: Użycie adnotacji do zabezpieczania metod i punktów końcowych.

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

W powyższym kodzie:

- Skonfigurowaliśmy Spring Security, aby zabezpieczyć punkty końcowe MCP, umożliwiając publiczny dostęp do wykrywania narzędzi, a wymagając uwierzytelnienia do ich wykonywania.
- Użyliśmy OAuth2 jako resource server do obsługi bezpiecznego dostępu do narzędzi MCP.
- Zaimplementowaliśmy interceptor bezpieczeństwa, który egzekwuje kontrolę dostępu przy wykonywaniu narzędzi, sprawdzając role i uprawnienia użytkownika przed udzieleniem dostępu.
- Zdefiniowaliśmy kontrolę dostępu opartą na rolach, aby ograniczyć dostęp do narzędzi administracyjnych i wrażliwych danych na podstawie ról użytkowników.

## Ochrona danych i prywatność

Ochrona danych jest kluczowa, aby zapewnić bezpieczne przetwarzanie wrażliwych informacji. Obejmuje to ochronę danych osobowych (PII), danych finansowych oraz innych wrażliwych informacji przed nieautoryzowanym dostępem i wyciekami.

### Przykład ochrony danych w Pythonie

Przyjrzyjmy się przykładzie implementacji ochrony danych w Pythonie z użyciem szyfrowania i wykrywania PII.

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

W powyższym kodzie:

- Zaimplementowaliśmy klasę `PiiDetector` do skanowania tekstu i parametrów pod kątem danych osobowych (PII).
- Stworzyliśmy klasę `EncryptionService` do obsługi szyfrowania i odszyfrowywania wrażliwych danych z użyciem biblioteki `cryptography`.
- Zdefiniowaliśmy dekorator `secure_tool`, który otacza wykonanie narzędzia, sprawdzając PII, logując dostęp i szyfrując wrażliwe dane, jeśli jest to wymagane.
- Zastosowaliśmy dekorator `secure_tool` do przykładowego narzędzia (`SecureCustomerDataTool`), aby zapewnić bezpieczne przetwarzanie wrażliwych danych.

## Specyficzne ryzyka bezpieczeństwa MCP

Zgodnie z oficjalną dokumentacją bezpieczeństwa MCP, istnieją specyficzne zagrożenia, o których powinni wiedzieć implementatorzy MCP:

### 1. Problem confused deputy

Ta luka występuje, gdy serwer MCP działa jako proxy do zewnętrznych API, co może pozwolić atakującym na wykorzystanie zaufanego związku między serwerem MCP a tymi API.

**Łagodzenie:**
- Serwery proxy MCP używające statycznych identyfikatorów klienta MUSZĄ uzyskać zgodę użytkownika dla każdego dynamicznie rejestrowanego klienta przed przekazaniem do zewnętrznych serwerów autoryzacji.
- Wdrożenie właściwego przepływu OAuth z PKCE (Proof Key for Code Exchange) dla żądań autoryzacji.
- Ścisła walidacja URI przekierowań i identyfikatorów klienta.

### 2. Luki token passthrough

Token passthrough występuje, gdy serwer MCP akceptuje tokeny od klienta MCP bez weryfikacji, czy tokeny zostały prawidłowo wydane dla serwera MCP, i przekazuje je dalej do downstream API.

### Ryzyka
- Obejście kontroli bezpieczeństwa (np. limitów zapytań, walidacji żądań)
- Problemy z odpowiedzialnością i śledzeniem działań
- Naruszenia granic zaufania
- Ryzyka kompatybilności w przyszłości

**Łagodzenie:**
- Serwery MCP NIE MOGĄ akceptować tokenów, które nie zostały wyraźnie wydane dla serwera MCP.
- Zawsze weryfikuj roszczenia odbiorcy tokena, aby upewnić się, że odpowiadają oczekiwanej usłudze.

### 3. Przejęcie sesji

Występuje, gdy nieuprawniona osoba uzyskuje identyfikator sesji i używa go do podszywania się pod oryginalnego klienta, co może prowadzić do nieautoryzowanych działań.

**Łagodzenie:**
- Serwery MCP implementujące autoryzację MUSZĄ weryfikować wszystkie przychodzące żądania i NIE MOGĄ używać sesji do uwierzytelniania.
- Używaj bezpiecznych, niedeterministycznych identyfikatorów sesji generowanych za pomocą bezpiecznych generatorów liczb losowych.
- Powiąż identyfikatory sesji z informacjami specyficznymi dla użytkownika, stosując format klucza np. `<user_id>:<session_id>`.
- Wdroż odpowiednie polityki wygasania i rotacji sesji.

## Dodatkowe najlepsze praktyki bezpieczeństwa dla MCP

Poza podstawowymi wymaganiami bezpieczeństwa MCP, rozważ wdrożenie następujących praktyk:

- **Zawsze używaj HTTPS**: Szyfruj komunikację między klientem a serwerem, aby chronić tokeny przed przechwyceniem.
- **Wdrażaj kontrolę dostępu opartą na rolach (RBAC)**: Nie sprawdzaj tylko, czy użytkownik jest uwierzytelniony, ale także, do czego jest uprawniony.
- **Monitoruj i audytuj**: Loguj wszystkie zdarzenia uwierzytelniania, aby wykrywać i reagować na podejrzane działania.
- **Obsługuj limitowanie i throttling**: Wdrażaj mechanizmy wykładniczego opóźniania i ponawiania prób, aby łagodnie radzić sobie z limitami zapytań.
- **Bezpieczne przechowywanie tokenów**: Przechowuj tokeny dostępu i odświeżania w bezpieczny sposób, korzystając z systemowych mechanizmów bezpiecznego przechowywania lub usług zarządzania kluczami.
- **Rozważ użycie zarządzania API**: Usługi takie jak Azure API Management mogą automatycznie obsługiwać wiele kwestii bezpieczeństwa, w tym uwierzytelnianie, autoryzację i limitowanie zapytań.

## Źródła

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Co dalej

- [5.9 Web search](../web-search-mcp/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.