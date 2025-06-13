<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-13T00:06:44+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "da"
}
-->
# Security Best Practices

Sikkerhed er afgørende for MCP-implementeringer, især i virksomhedsmiljøer. Det er vigtigt at sikre, at værktøjer og data er beskyttet mod uautoriseret adgang, databrud og andre sikkerhedstrusler.

## Introduction

I denne lektion vil vi gennemgå sikkerhedspraksis for MCP-implementeringer. Vi vil dække autentificering og autorisation, databeskyttelse, sikker værktøjsudførelse og overholdelse af databeskyttelsesregler.

## Learning Objectives

Ved slutningen af denne lektion vil du kunne:

- Implementere sikre autentificerings- og autorisationsmekanismer for MCP-servere.
- Beskytte følsomme data ved hjælp af kryptering og sikker lagring.
- Sikre sikker udførelse af værktøjer med korrekte adgangskontroller.
- Anvende bedste praksis for databeskyttelse og overholdelse af privatlivsregler.

## Authentication and Authorization

Autentificering og autorisation er essentielle for at sikre MCP-servere. Autentificering svarer på spørgsmålet "Hvem er du?", mens autorisation svarer på "Hvad kan du gøre?".

Lad os se på eksempler på, hvordan man implementerer sikker autentificering og autorisation i MCP-servere ved hjælp af .NET og Java.

### .NET Identity Integration

ASP .NET Core Identity tilbyder et robust framework til håndtering af brugerautentificering og autorisation. Vi kan integrere det med MCP-servere for at sikre adgang til værktøjer og ressourcer.

Der er nogle centrale begreber, vi skal forstå, når vi integrerer ASP.NET Core Identity med MCP-servere, nemlig:

- **Identity Configuration**: Opsætning af ASP.NET Core Identity med brugerroller og claims. Et claim er en oplysning om brugeren, såsom deres rolle eller tilladelser, for eksempel "Admin" eller "User".
- **JWT Authentication**: Brug af JSON Web Tokens (JWT) til sikker API-adgang. JWT er en standard til sikker overførsel af information mellem parter som et JSON-objekt, som kan verificeres og stoles på, fordi det er digitalt signeret.
- **Authorization Policies**: Definering af politikker for at kontrollere adgang til specifikke værktøjer baseret på brugerroller. MCP bruger autorisationspolitikker til at afgøre, hvilke brugere der kan få adgang til hvilke værktøjer baseret på deres roller og claims.

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

I den foregående kode har vi:

- Konfigureret ASP.NET Core Identity til brugerstyring.
- Opsat JWT-autentificering for sikker API-adgang. Vi specificerede tokenvalideringsparametre, herunder issuer, audience og signeringsnøgle.
- Defineret autorisationspolitikker for at kontrollere adgang til værktøjer baseret på brugerroller. For eksempel kræver "CanUseAdminTools"-politikken, at brugeren har "Admin"-rollen, mens "CanUseBasic"-politikken kræver, at brugeren er autentificeret.
- Registreret MCP-værktøjer med specifikke autorisationskrav, så kun brugere med passende roller kan få adgang til dem.

### Java Spring Security Integration

For Java bruger vi Spring Security til at implementere sikker autentificering og autorisation for MCP-servere. Spring Security tilbyder et omfattende sikkerhedsframework, der integreres problemfrit med Spring-applikationer.

Kernebegreber her er:

- **Spring Security Configuration**: Opsætning af sikkerhedskonfigurationer for autentificering og autorisation.
- **OAuth2 Resource Server**: Brug af OAuth2 til sikker adgang til MCP-værktøjer. OAuth2 er et autorisationsframework, der tillader tredjepartstjenester at udveksle adgangstokens for sikker API-adgang.
- **Security Interceptors**: Implementering af sikkerhedsinterceptorer for at håndhæve adgangskontroller ved værktøjsudførelse.
- **Role-Based Access Control**: Brug af roller til at styre adgang til specifikke værktøjer og ressourcer.
- **Security Annotations**: Brug af annotationer til at sikre metoder og endpoints.

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

I den foregående kode har vi:

- Konfigureret Spring Security til at sikre MCP-endpoints, hvor værktøjsopdagelse er offentligt tilgængelig, mens autentificering kræves for værktøjsudførelse.
- Brugte OAuth2 som resource server til at håndtere sikker adgang til MCP-værktøjer.
- Implementeret en sikkerhedsinterceptor til at håndhæve adgangskontroller ved værktøjsudførelse, hvor brugerroller og tilladelser tjekkes, før adgang til specifikke værktøjer gives.
- Defineret rollebaseret adgangskontrol for at begrænse adgang til admin-værktøjer og adgang til følsomme data baseret på brugerroller.

## Data Protection and Privacy

Databeskyttelse er afgørende for at sikre, at følsomme oplysninger håndteres sikkert. Dette inkluderer beskyttelse af personligt identificerbare oplysninger (PII), finansielle data og andre følsomme oplysninger mod uautoriseret adgang og brud.

### Python Data Protection Example

Lad os se på et eksempel på, hvordan man implementerer databeskyttelse i Python ved hjælp af kryptering og PII-detektion.

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

I den foregående kode har vi:

- Implementeret en `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) for at sikre, at den håndterer følsomme data sikkert.

## What's next

- [5.9 Web search](../web-search-mcp/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.