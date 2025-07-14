<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:40:29+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sv"
}
-->
# Säkerhetsbästa metoder

Säkerhet är avgörande för MCP-implementationer, särskilt i företagsmiljöer. Det är viktigt att säkerställa att verktyg och data skyddas mot obehörig åtkomst, dataintrång och andra säkerhetshot.

## Introduktion

I denna lektion kommer vi att utforska säkerhetsbästa metoder för MCP-implementationer. Vi kommer att täcka autentisering och auktorisering, dataskydd, säker verktygsexekvering och efterlevnad av dataskyddsregler.

## Lärandemål

Efter denna lektion kommer du att kunna:

- Implementera säkra autentiserings- och auktoriseringsmekanismer för MCP-servrar.
- Skydda känslig data med kryptering och säker lagring.
- Säkerställa säker exekvering av verktyg med rätt åtkomstkontroller.
- Tillämpa bästa metoder för dataskydd och integritetsöverensstämmelse.

## Autentisering och auktorisering

Autentisering och auktorisering är grundläggande för att säkra MCP-servrar. Autentisering svarar på frågan "Vem är du?" medan auktorisering svarar på "Vad får du göra?".

Låt oss titta på exempel på hur man implementerar säker autentisering och auktorisering i MCP-servrar med .NET och Java.

### .NET Identity-integration

ASP .NET Core Identity erbjuder ett robust ramverk för att hantera användarautentisering och auktorisering. Vi kan integrera det med MCP-servrar för att säkra åtkomst till verktyg och resurser.

Det finns några grundläggande begrepp vi behöver förstå när vi integrerar ASP.NET Core Identity med MCP-servrar, nämligen:

- **Identity-konfiguration**: Att ställa in ASP.NET Core Identity med användarroller och claims. En claim är en bit information om användaren, som deras roll eller behörigheter, till exempel "Admin" eller "User".
- **JWT-autentisering**: Använda JSON Web Tokens (JWT) för säker API-åtkomst. JWT är en standard för att säkert överföra information mellan parter som ett JSON-objekt, vilket kan verifieras och litas på eftersom det är digitalt signerat.
- **Auktoriseringspolicyer**: Definiera policyer för att kontrollera åtkomst till specifika verktyg baserat på användarroller. MCP använder auktoriseringspolicyer för att avgöra vilka användare som kan komma åt vilka verktyg baserat på deras roller och claims.

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

I koden ovan har vi:

- Konfigurerat ASP.NET Core Identity för användarhantering.
- Ställt in JWT-autentisering för säker API-åtkomst. Vi specificerade tokenvalideringsparametrar, inklusive utfärdare, publik och signeringsnyckel.
- Definierat auktoriseringspolicyer för att kontrollera åtkomst till verktyg baserat på användarroller. Till exempel kräver policyn "CanUseAdminTools" att användaren har rollen "Admin", medan "CanUseBasic" kräver att användaren är autentiserad.
- Registrerat MCP-verktyg med specifika auktoriseringskrav, vilket säkerställer att endast användare med rätt roller kan komma åt dem.

### Java Spring Security-integration

För Java använder vi Spring Security för att implementera säker autentisering och auktorisering för MCP-servrar. Spring Security erbjuder ett omfattande säkerhetsramverk som integreras sömlöst med Spring-applikationer.

Grundläggande begrepp här är:

- **Spring Security-konfiguration**: Att ställa in säkerhetskonfigurationer för autentisering och auktorisering.
- **OAuth2 Resource Server**: Använda OAuth2 för säker åtkomst till MCP-verktyg. OAuth2 är ett auktoriseringsramverk som tillåter tredjepartstjänster att byta access tokens för säker API-åtkomst.
- **Säkerhetsinterceptorer**: Implementera säkerhetsinterceptorer för att upprätthålla åtkomstkontroller vid verktygsexekvering.
- **Rollbaserad åtkomstkontroll**: Använda roller för att styra åtkomst till specifika verktyg och resurser.
- **Säkerhetsannoteringar**: Använda annoteringar för att säkra metoder och endpoints.

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

I koden ovan har vi:

- Konfigurerat Spring Security för att säkra MCP-endpoints, med offentlig åtkomst till verktygsupptäckt men kräver autentisering för verktygsexekvering.
- Använt OAuth2 som resursserver för att hantera säker åtkomst till MCP-verktyg.
- Implementerat en säkerhetsinterceptor för att upprätthålla åtkomstkontroller vid verktygsexekvering, som kontrollerar användarroller och behörigheter innan åtkomst till specifika verktyg tillåts.
- Definierat rollbaserad åtkomstkontroll för att begränsa åtkomst till adminverktyg och känslig data baserat på användarroller.

## Dataskydd och integritet

Dataskydd är avgörande för att säkerställa att känslig information hanteras på ett säkert sätt. Detta inkluderar att skydda personuppgifter (PII), finansiell data och annan känslig information från obehörig åtkomst och intrång.

### Exempel på dataskydd i Python

Låt oss titta på ett exempel på hur man implementerar dataskydd i Python med kryptering och PII-detektion.

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

I koden ovan har vi:

- Implementerat en `PiiDetector`-klass för att skanna text och parametrar efter personuppgifter (PII).
- Skapat en `EncryptionService`-klass för att hantera kryptering och dekryptering av känslig data med hjälp av `cryptography`-biblioteket.
- Definierat en `secure_tool`-dekoration som omsluter verktygsexekvering för att kontrollera PII, logga åtkomst och kryptera känslig data vid behov.
- Använt `secure_tool`-dekorationen på ett exempelverktyg (`SecureCustomerDataTool`) för att säkerställa att det hanterar känslig data på ett säkert sätt.

## Vad händer härnäst

- [5.9 Web search](../web-search-mcp/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.