<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T08:19:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "tl"
}
-->
# Security Best Practices

Mahalaga ang seguridad para sa mga implementasyon ng MCP, lalo na sa mga enterprise na kapaligiran. Kailangan tiyakin na ang mga tools at datos ay protektado laban sa hindi awtorisadong pag-access, paglabag sa datos, at iba pang mga banta sa seguridad.

## Introduction

Ang Model Context Protocol (MCP) ay nangangailangan ng partikular na mga konsiderasyon sa seguridad dahil sa papel nito sa pagbibigay ng access ng LLMs sa datos at mga tools. Tatalakayin sa araling ito ang mga pinakamahusay na kasanayan sa seguridad para sa mga implementasyon ng MCP batay sa opisyal na mga gabay ng MCP at mga napatunayang pattern sa seguridad.

Sinasunod ng MCP ang mga pangunahing prinsipyo ng seguridad upang matiyak ang ligtas at mapagkakatiwalaang mga interaksyon:

- **Pahintulot at Kontrol ng User**: Dapat magbigay ang mga user ng malinaw na pahintulot bago ma-access ang anumang datos o maisagawa ang mga operasyon. Magbigay ng malinaw na kontrol kung anong datos ang ibabahagi at kung aling mga aksyon ang pinahihintulutan.
  
- **Pribasiya ng Datos**: Ang datos ng user ay dapat ilantad lamang kung may malinaw na pahintulot at dapat protektahan gamit ang angkop na mga kontrol sa pag-access. Siguraduhing ligtas laban sa hindi awtorisadong pagpapadala ng datos.
  
- **Kaligtasan ng Tool**: Bago gamitin ang anumang tool, kinakailangan ang malinaw na pahintulot ng user. Dapat malinaw sa mga user ang bawat functionality ng tool, at dapat ipatupad ang matibay na mga hangganan sa seguridad.

## Learning Objectives

Sa pagtatapos ng araling ito, magagawa mong:

- Magpatupad ng ligtas na mekanismo para sa authentication at authorization para sa mga MCP server.
- Protektahan ang sensitibong datos gamit ang encryption at ligtas na imbakan.
- Siguraduhin ang ligtas na pagpapatupad ng mga tool gamit ang tamang mga kontrol sa pag-access.
- Ipatupad ang mga pinakamahusay na kasanayan para sa proteksyon ng datos at pagsunod sa pribasiya.
- Tukuyin at pigilan ang mga karaniwang kahinaan sa seguridad ng MCP tulad ng confused deputy problems, token passthrough, at session hijacking.

## Authentication and Authorization

Mahalaga ang authentication at authorization para sa seguridad ng mga MCP server. Sinusagot ng authentication ang tanong na "Sino ka?" habang sinasagot ng authorization ang "Ano ang kaya mong gawin?".

Ayon sa MCP security specification, ito ang mga kritikal na konsiderasyon sa seguridad:

1. **Token Validation**: HINDI DAPAT tumanggap ang mga MCP server ng anumang token na hindi tahasang inilabas para sa MCP server. Ang "token passthrough" ay isang tahasang ipinagbabawal na anti-pattern.

2. **Authorization Verification**: Ang mga MCP server na nagpapatupad ng authorization ay DAPAT suriin ang lahat ng papasok na kahilingan at HINDI DAPAT gumamit ng sessions para sa authentication.

3. **Secure Session Management**: Kapag gumagamit ng sessions para sa estado, DAPAT gumamit ang mga MCP server ng ligtas, hindi deterministic na session IDs na nilikha gamit ang secure random number generators. DAPAT i-bind ang session IDs sa impormasyon na tukoy sa user.

4. **Explicit User Consent**: Para sa mga proxy server, DAPAT kumuha ang mga implementasyon ng MCP ng pahintulot ng user para sa bawat dynamically registered client bago ipasa sa third-party authorization servers.

Tingnan natin ang mga halimbawa kung paano magpatupad ng ligtas na authentication at authorization sa mga MCP server gamit ang .NET at Java.

### .NET Identity Integration

Nagbibigay ang ASP .NET Core Identity ng matibay na framework para sa pamamahala ng authentication at authorization ng user. Maaari natin itong isama sa mga MCP server upang maprotektahan ang access sa mga tools at resources.

May ilang pangunahing konsepto na kailangan nating maunawaan kapag isinama ang ASP.NET Core Identity sa mga MCP server, tulad ng:

- **Identity Configuration**: Pagsasaayos ng ASP.NET Core Identity gamit ang mga user roles at claims. Ang claim ay isang piraso ng impormasyon tungkol sa user, tulad ng kanilang role o mga pahintulot, halimbawa "Admin" o "User".
- **JWT Authentication**: Paggamit ng JSON Web Tokens (JWT) para sa ligtas na access sa API. Ang JWT ay isang standard para sa ligtas na pagpapadala ng impormasyon sa pagitan ng mga partido bilang isang JSON object, na maaaring beripikahin at pagkatiwalaan dahil ito ay digitally signed.
- **Authorization Policies**: Pagdeklara ng mga polisiya upang kontrolin ang access sa mga partikular na tool base sa mga user roles. Ginagamit ng MCP ang mga authorization policies upang tukuyin kung aling mga user ang maaaring maka-access sa mga tool base sa kanilang mga role at claim.

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

Sa naunang code, ginawa natin ang mga sumusunod:

- Naka-configure ang ASP.NET Core Identity para sa pamamahala ng user.
- Naka-set up ang JWT authentication para sa ligtas na access sa API. Tinukoy natin ang mga parameter para sa token validation, kabilang ang issuer, audience, at signing key.
- Naka-deklara ang mga authorization policies upang kontrolin ang access sa mga tool base sa mga user roles. Halimbawa, ang polisiya na "CanUseAdminTools" ay nangangailangan na ang user ay may "Admin" role, habang ang "CanUseBasic" policy ay nangangailangan na ang user ay authenticated.
- Nairehistro ang mga MCP tools na may partikular na mga pangangailangan sa authorization, na tinitiyak na tanging ang mga user na may angkop na mga role lamang ang makaka-access sa mga ito.

### Java Spring Security Integration

Para sa Java, gagamit tayo ng Spring Security upang ipatupad ang ligtas na authentication at authorization para sa mga MCP server. Nagbibigay ang Spring Security ng komprehensibong security framework na seamless na nakikipag-integrate sa mga Spring application.

Ang mga pangunahing konsepto dito ay:

- **Spring Security Configuration**: Pagsasaayos ng mga security configuration para sa authentication at authorization.
- **OAuth2 Resource Server**: Paggamit ng OAuth2 para sa ligtas na access sa mga MCP tool. Ang OAuth2 ay isang authorization framework na nagpapahintulot sa mga third-party na serbisyo na magpalitan ng access tokens para sa ligtas na access sa API.
- **Security Interceptors**: Pagpapatupad ng mga security interceptor upang ipatupad ang mga kontrol sa pag-access sa pagpapatupad ng tool.
- **Role-Based Access Control**: Paggamit ng mga role upang kontrolin ang access sa mga partikular na tool at resources.
- **Security Annotations**: Paggamit ng mga annotation upang siguraduhin ang seguridad ng mga method at endpoints.

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

Sa naunang code, ginawa natin ang mga sumusunod:

- Naka-configure ang Spring Security upang protektahan ang mga MCP endpoint, pinapayagan ang pampublikong access sa tool discovery habang kinakailangan ang authentication para sa pagpapatupad ng tool.
- Ginamit ang OAuth2 bilang resource server upang pangasiwaan ang ligtas na access sa mga MCP tool.
- Ipinatupad ang security interceptor upang ipatupad ang mga kontrol sa pag-access sa pagpapatupad ng tool, sinusuri ang mga user role at pahintulot bago payagan ang access sa mga partikular na tool.
- Naka-deklara ang role-based access control upang limitahan ang access sa mga admin tool at sensitibong datos base sa mga user role.

## Data Protection and Privacy

Mahalaga ang proteksyon ng datos upang matiyak na ang sensitibong impormasyon ay hinahawakan nang ligtas. Kasama dito ang pagprotekta sa personally identifiable information (PII), financial data, at iba pang sensitibong impormasyon mula sa hindi awtorisadong pag-access at paglabag.

### Python Data Protection Example

Tingnan natin ang isang halimbawa kung paano magpatupad ng proteksyon ng datos sa Python gamit ang encryption at PII detection.

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

Sa naunang code, ginawa natin ang mga sumusunod:

- Nagpatupad ng `PiiDetector` class upang i-scan ang teksto at mga parameter para sa personally identifiable information (PII).
- Nilikha ang `EncryptionService` class upang pangasiwaan ang encryption at decryption ng sensitibong datos gamit ang `cryptography` library.
- Nagdeklara ng `secure_tool` decorator na bumabalot sa pagpapatupad ng tool upang suriin ang PII, mag-log ng access, at i-encrypt ang sensitibong datos kung kinakailangan.
- Inilapat ang `secure_tool` decorator sa isang sample tool (`SecureCustomerDataTool`) upang matiyak na ligtas nitong hinahawakan ang sensitibong datos.

## MCP-Specific Security Risks

Ayon sa opisyal na dokumentasyon ng seguridad ng MCP, may mga partikular na panganib sa seguridad na dapat malaman ng mga implementer ng MCP:

### 1. Confused Deputy Problem

Nangyayari ang kahinaang ito kapag ang MCP server ay kumikilos bilang proxy sa mga third-party API, na posibleng payagan ang mga attacker na samantalahin ang pinagkakatiwalaang relasyon sa pagitan ng MCP server at ng mga API na ito.

**Mitigation:**
- Ang mga MCP proxy server na gumagamit ng static client IDs ay DAPAT kumuha ng pahintulot ng user para sa bawat dynamically registered client bago ipasa sa third-party authorization servers.
- Ipatupad ang tamang OAuth flow gamit ang PKCE (Proof Key for Code Exchange) para sa mga authorization request.
- Mahigpit na beripikahin ang redirect URIs at mga client identifier.

### 2. Token Passthrough Vulnerabilities

Nangyayari ang token passthrough kapag tumatanggap ang MCP server ng mga token mula sa MCP client nang hindi beripikado na ang mga token ay tamang inilabas para sa MCP server at ipinapasa ito sa mga downstream API.

### Mga Panganib
- Pag-iwas sa mga kontrol sa seguridad (pagbypass sa rate limiting, request validation)
- Mga isyu sa pananagutan at audit trail
- Paglabag sa trust boundary
- Mga panganib sa pagiging compatible sa hinaharap

**Mitigation:**
- HINDI DAPAT tumanggap ang mga MCP server ng anumang token na hindi tahasang inilabas para sa MCP server.
- Laging beripikahin ang mga audience claim ng token upang matiyak na tumutugma ito sa inaasahang serbisyo.

### 3. Session Hijacking

Nangyayari ito kapag ang isang hindi awtorisadong partido ay nakakakuha ng session ID at ginagamit ito upang magpanggap bilang orihinal na kliyente, na posibleng magdulot ng hindi awtorisadong mga aksyon.

**Mitigation:**
- Ang mga MCP server na nagpapatupad ng authorization ay DAPAT suriin ang lahat ng papasok na kahilingan at HINDI DAPAT gumamit ng sessions para sa authentication.
- Gumamit ng ligtas, hindi deterministic na session IDs na nilikha gamit ang secure random number generators.
- I-bind ang session IDs sa impormasyon na tukoy sa user gamit ang key format na tulad ng `<user_id>:<session_id>`.
- Ipatupad ang tamang mga polisiya para sa expiration at rotation ng session.

## Additional Security Best Practices for MCP

Bukod sa mga pangunahing konsiderasyon sa seguridad ng MCP, isaalang-alang ang pagpapatupad ng mga sumusunod na karagdagang kasanayan sa seguridad:

- **Laging gumamit ng HTTPS**: I-encrypt ang komunikasyon sa pagitan ng client at server upang maprotektahan ang mga token mula sa interception.
- **Ipatupad ang Role-Based Access Control (RBAC)**: Huwag lang suriin kung ang user ay authenticated; suriin din kung ano ang pinahihintulutan nilang gawin.
- **Mag-monitor at mag-audit**: I-log ang lahat ng authentication events upang matukoy at matugunan ang mga kahina-hinalang aktibidad.
- **Pangasiwaan ang rate limiting at throttling**: Ipatupad ang exponential backoff at retry logic upang maayos na mahawakan ang mga rate limit.
- **Ligtas na imbakan ng token**: Itago ang access tokens at refresh tokens nang ligtas gamit ang mga mekanismo ng secure storage ng sistema o mga secure key management service.
- **Isaalang-alang ang paggamit ng API Management**: Ang mga serbisyo tulad ng Azure API Management ay maaaring awtomatikong pangasiwaan ang maraming isyu sa seguridad, kabilang ang authentication, authorization, at rate limiting.

## References

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## What's next

- [5.9 Web search](../web-search-mcp/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.