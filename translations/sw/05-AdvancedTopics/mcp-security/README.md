<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-13T00:45:46+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "sw"
}
-->
# Mazoea Bora za Usalama

Usalama ni muhimu kwa utekelezaji wa MCP, hasa katika mazingira ya biashara. Ni muhimu kuhakikisha kuwa zana na data zinahifadhiwa dhidi ya upatikanaji usioidhinishwa, uvunjaji wa data, na tishio lingine lolote la usalama.

## Utangulizi

Katika somo hili, tutachunguza mazalio bora ya usalama kwa utekelezaji wa MCP. Tutagusia uthibitishaji na idhini, ulinzi wa data, utekelezaji salama wa zana, na kufuata kanuni za faragha ya data.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutekeleza mbinu salama za uthibitishaji na idhini kwa seva za MCP.
- Kulinda data nyeti kwa kutumia usimbaji na uhifadhi salama.
- Kuhakikisha utekelezaji salama wa zana kwa kudhibiti upatikanaji ipasavyo.
- Kutumia mbinu bora za ulinzi wa data na kufuata sheria za faragha.

## Uthibitishaji na Idhini

Uthibitishaji na idhini ni muhimu kwa usalama wa seva za MCP. Uthibitishaji hujibu swali "Wewe ni nani?" wakati idhini hujibu "Unaweza kufanya nini?".

Tuchunguze mifano ya jinsi ya kutekeleza uthibitishaji na idhini salama kwenye seva za MCP kwa kutumia .NET na Java.

### Muunganisho wa .NET Identity

ASP .NET Core Identity hutoa mfumo thabiti wa kusimamia uthibitishaji na idhini ya watumiaji. Tunaweza kuuiunganisha na seva za MCP ili kulinda upatikanaji wa zana na rasilimali.

Kuna dhana kuu tunazohitaji kuelewa tunapoingiza ASP.NET Core Identity na seva za MCP, yaani:

- **Usanidi wa Identity**: Kuweka ASP.NET Core Identity na majukumu ya watumiaji na madai. Dadai ni kipande cha taarifa kuhusu mtumiaji, kama jukumu lao au ruhusa, mfano "Admin" au "User".
- **Uthibitishaji wa JWT**: Kutumia JSON Web Tokens (JWT) kwa upatikanaji salama wa API. JWT ni kiwango cha kusafirisha taarifa kwa usalama kati ya pande kama kitu cha JSON, kinachoweza kuthibitishwa na kuaminiwa kwa sababu kimesainiwa kidijitali.
- **Sera za Idhini**: Kuweka sera za kudhibiti upatikanaji wa zana maalum kulingana na majukumu ya watumiaji. MCP hutumia sera za idhini kuamua ni watumiaji gani wanaweza kupata zana gani kulingana na majukumu na madai yao.

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

Katika msimbo uliotangulia, tumefanya:

- Kuandaa ASP.NET Core Identity kwa usimamizi wa watumiaji.
- Kuweka uthibitishaji wa JWT kwa upatikanaji salama wa API. Tulibainisha vigezo vya uthibitishaji wa tokeni, ikiwemo mtumaji, hadhira, na funguo za kusaini.
- Kuweka sera za idhini kudhibiti upatikanaji wa zana kulingana na majukumu ya watumiaji. Kwa mfano, sera ya "CanUseAdminTools" inahitaji mtumiaji kuwa na jukumu la "Admin", wakati sera ya "CanUseBasic" inahitaji mtumiaji kuthibitishwa.
- Kusajili zana za MCP na mahitaji maalum ya idhini, kuhakikisha kuwa ni watumiaji wenye majukumu sahihi tu ndio wanaweza kuzitumia.

### Muunganisho wa Java Spring Security

Kwa Java, tutatumia Spring Security kutekeleza uthibitishaji na idhini salama kwa seva za MCP. Spring Security hutoa mfumo kamili wa usalama unaounganishwa vizuri na programu za Spring.

Dhana kuu hapa ni:

- **Usanidi wa Spring Security**: Kuweka usanidi wa usalama kwa uthibitishaji na idhini.
- **OAuth2 Resource Server**: Kutumia OAuth2 kwa upatikanaji salama wa zana za MCP. OAuth2 ni mfumo wa idhini unaowezesha huduma za tatu kubadilishana tokeni za upatikanaji kwa upatikanaji salama wa API.
- **Vizuizi vya Usalama**: Kutekeleza vizuizi vya usalama ili kutekeleza udhibiti wa upatikanaji kwenye utekelezaji wa zana.
- **Udhibiti wa Upatikanaji Kulingana na Majukumu**: Kutumia majukumu kudhibiti upatikanaji wa zana na rasilimali maalum.
- **Maelezo ya Usalama**: Kutumia maelezo ili kulinda njia na vipengele vya programu.

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

Katika msimbo uliotangulia, tumefanya:

- Kuandaa Spring Security kulinda vituo vya MCP, kuruhusu upatikanaji wa umma kwa kugundua zana huku tukihitaji uthibitishaji kwa utekelezaji wa zana.
- Kutumia OAuth2 kama seva ya rasilimali kushughulikia upatikanaji salama wa zana za MCP.
- Kutekeleza kizui cha usalama kuimarisha udhibiti wa upatikanaji kwenye utekelezaji wa zana, kuangalia majukumu na ruhusa za mtumiaji kabla ya kuruhusu upatikanaji kwa zana maalum.
- Kuweka udhibiti wa upatikanaji kulingana na majukumu ili kupunguza upatikanaji wa zana za wasimamizi na data nyeti kulingana na majukumu ya watumiaji.

## Ulinzi wa Data na Faragha

Ulinzi wa data ni muhimu kuhakikisha kuwa taarifa nyeti zinashughulikiwa kwa usalama. Hii ni pamoja na kulinda taarifa zinazotambulika binafsi (PII), data za kifedha, na taarifa nyingine nyeti dhidi ya upatikanaji usioidhinishwa na uvunjaji.

### Mfano wa Ulinzi wa Data kwa Python

Tuchunguze mfano wa jinsi ya kutekeleza ulinzi wa data kwa Python kwa kutumia usimbaji na kugundua PII.

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

Katika msimbo uliotangulia, tumefanya:

- Kutekeleza `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) kuhakikisha inashughulikia data nyeti kwa usalama.

## Nini Kifuatacho

- [5.9 Web search](../web-search-mcp/README.md)

**Kiasi cha Hati**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.