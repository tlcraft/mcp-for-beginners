<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:17:30+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "tl"
}
-->
# Security Best Practices

Mahalaga ang seguridad para sa mga implementasyon ng MCP, lalo na sa mga enterprise na kapaligiran. Kailangan tiyakin na protektado ang mga tools at data laban sa hindi awtorisadong pag-access, paglabag sa data, at iba pang banta sa seguridad.

## Introduction

Sa araling ito, tatalakayin natin ang mga pinakamahusay na kasanayan sa seguridad para sa mga implementasyon ng MCP. Saklaw nito ang authentication at authorization, proteksyon ng data, ligtas na pagpapatakbo ng mga tool, at pagsunod sa mga regulasyon sa privacy ng data.

## Learning Objectives

Pagkatapos ng araling ito, magagawa mong:

- Magpatupad ng ligtas na authentication at authorization para sa mga MCP server.
- Protektahan ang sensitibong data gamit ang encryption at secure na imbakan.
- Tiyakin ang ligtas na pagpapatakbo ng mga tool gamit ang tamang kontrol sa access.
- Ipatupad ang mga pinakamahusay na kasanayan para sa proteksyon ng data at pagsunod sa privacy.

## Authentication and Authorization

Mahalaga ang authentication at authorization para sa seguridad ng mga MCP server. Ang authentication ang sumasagot sa tanong na "Sino ka?" habang ang authorization naman ay "Ano ang kaya mong gawin?".

Tingnan natin ang mga halimbawa kung paano ipinatutupad ang ligtas na authentication at authorization sa mga MCP server gamit ang .NET at Java.

### .NET Identity Integration

Nagbibigay ang ASP .NET Core Identity ng matibay na framework para sa pamamahala ng authentication at authorization ng mga user. Maaari natin itong isama sa mga MCP server upang maprotektahan ang access sa mga tool at resources.

Narito ang ilang pangunahing konsepto na kailangan nating maintindihan kapag isinama ang ASP.NET Core Identity sa mga MCP server:

- **Identity Configuration**: Pagsasaayos ng ASP.NET Core Identity gamit ang mga user role at claim. Ang claim ay isang piraso ng impormasyon tungkol sa user, tulad ng kanilang role o mga permiso, halimbawa "Admin" o "User".
- **JWT Authentication**: Paggamit ng JSON Web Tokens (JWT) para sa ligtas na API access. Ang JWT ay isang standard para sa ligtas na pagpapadala ng impormasyon sa pagitan ng mga partido bilang isang JSON object, na maaaring mapatunayan at pagkatiwalaan dahil ito ay digitally signed.
- **Authorization Policies**: Pagdedeklara ng mga polisiya upang kontrolin ang access sa mga partikular na tool base sa mga user role. Ginagamit ng MCP ang mga authorization policy para matukoy kung aling mga user ang maaaring makagamit ng mga tool base sa kanilang mga role at claim.

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

- Na-configure ang ASP.NET Core Identity para sa pamamahala ng user.
- Na-set up ang JWT authentication para sa ligtas na API access. Tinukoy natin ang mga token validation parameter, kabilang ang issuer, audience, at signing key.
- Na-define ang mga authorization policy para kontrolin ang access sa mga tool base sa mga user role. Halimbawa, ang polisiya na "CanUseAdminTools" ay nangangailangan na ang user ay may "Admin" role, habang ang "CanUseBasic" ay nangangailangan na ang user ay authenticated.
- Na-rehistro ang mga MCP tool na may partikular na mga requirement sa authorization, tinitiyak na tanging ang mga user na may tamang role lamang ang makaka-access sa mga ito.

### Java Spring Security Integration

Para sa Java, gagamitin natin ang Spring Security upang ipatupad ang ligtas na authentication at authorization para sa mga MCP server. Nagbibigay ang Spring Security ng komprehensibong security framework na seamless na nakakasama sa mga Spring application.

Ang mga pangunahing konsepto dito ay:

- **Spring Security Configuration**: Pagsasaayos ng security configuration para sa authentication at authorization.
- **OAuth2 Resource Server**: Paggamit ng OAuth2 para sa ligtas na access sa mga MCP tool. Ang OAuth2 ay isang authorization framework na nagpapahintulot sa third-party services na magpalitan ng access token para sa secure na API access.
- **Security Interceptors**: Pagpapatupad ng security interceptors upang ipatupad ang access control sa pagpapatakbo ng mga tool.
- **Role-Based Access Control**: Paggamit ng mga role para kontrolin ang access sa mga partikular na tool at resources.
- **Security Annotations**: Paggamit ng mga annotation upang siguraduhin ang seguridad ng mga method at endpoint.

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

- Na-configure ang Spring Security upang protektahan ang mga MCP endpoint, pinapayagan ang pampublikong access sa tool discovery habang kinakailangan ang authentication para sa pagpapatakbo ng mga tool.
- Ginamit ang OAuth2 bilang resource server upang pangasiwaan ang ligtas na access sa mga MCP tool.
- Ipinatupad ang security interceptor upang ipatupad ang access control sa pagpapatakbo ng mga tool, sinusuri ang mga user role at permiso bago payagan ang access sa mga partikular na tool.
- Na-define ang role-based access control upang limitahan ang access sa admin tool at sensitibong data base sa mga user role.

## Data Protection and Privacy

Mahalaga ang proteksyon ng data upang matiyak na ang sensitibong impormasyon ay hinahandle nang ligtas. Kabilang dito ang pagprotekta sa personally identifiable information (PII), financial data, at iba pang sensitibong impormasyon mula sa hindi awtorisadong pag-access at paglabag.

### Python Data Protection Example

Tingnan natin ang halimbawa kung paano ipinatutupad ang proteksyon ng data sa Python gamit ang encryption at PII detection.

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

- Ipinatupad ang `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` upang matiyak na ligtas nitong hinahandle ang sensitibong data.

## What's next

- [Web search](../web-search-mcp/README.md)

**Pagtatanggol**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.