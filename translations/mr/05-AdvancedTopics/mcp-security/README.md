<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:12:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "mr"
}
-->
# सुरक्षा सर्वोत्तम सराव

MCP अंमलबजावणीसाठी सुरक्षा अत्यंत महत्त्वाची आहे, विशेषतः एंटरप्राइज वातावरणात. साधने आणि डेटा अनधिकृत प्रवेश, डेटा भंग आणि इतर सुरक्षा धोक्यांपासून संरक्षित असल्याची खात्री करणे गरजेचे आहे.

## परिचय

या धड्यात, आपण MCP अंमलबजावणीसाठी सुरक्षा सर्वोत्तम सराव पाहणार आहोत. आपण प्रमाणीकरण आणि अधिकृतता, डेटा संरक्षण, सुरक्षित साधन अंमलबजावणी आणि डेटा गोपनीयता नियमांचे पालन यावर चर्चा करू.

## शिकण्याची उद्दिष्टे

या धड्याच्या शेवटी, आपण सक्षम असाल:

- MCP सर्व्हरसाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता यंत्रणा राबविणे.
- संवेदनशील डेटाचे एन्क्रिप्शन आणि सुरक्षित संग्रहणाद्वारे संरक्षण करणे.
- योग्य प्रवेश नियंत्रणासह साधनांची सुरक्षित अंमलबजावणी सुनिश्चित करणे.
- डेटा संरक्षण आणि गोपनीयता नियमांचे पालन करण्यासाठी सर्वोत्तम सराव लागू करणे.

## प्रमाणीकरण आणि अधिकृतता

MCP सर्व्हर सुरक्षित करण्यासाठी प्रमाणीकरण आणि अधिकृतता आवश्यक आहेत. प्रमाणीकरण प्रश्नाचे उत्तर देते "तुम्ही कोण आहात?" तर अधिकृतता विचारते "तुम्ही काय करू शकता?".

चला पाहूया ASP.NET आणि Java वापरून MCP सर्व्हरमध्ये सुरक्षित प्रमाणीकरण आणि अधिकृतता कशी राबवायची याची उदाहरणे.

### .NET Identity एकत्रीकरण

ASP .NET Core Identity वापरकर्त्याच्या प्रमाणीकरण आणि अधिकृतता व्यवस्थापनासाठी एक मजबूत फ्रेमवर्क प्रदान करते. आम्ही याला MCP सर्व्हरशी एकत्र करून साधने आणि संसाधनांवर प्रवेश सुरक्षित करू शकतो.

ASP.NET Core Identity MCP सर्व्हरशी एकत्र करताना काही मुख्य संकल्पना समजून घेणे आवश्यक आहे जसे:

- **Identity Configuration**: वापरकर्ता भूमिका आणि दावे सेट करणे. दावा म्हणजे वापरकर्त्याबद्दल माहितीचा तुकडा, जसे की त्यांची भूमिका किंवा परवानग्या, उदाहरणार्थ "Admin" किंवा "User".
- **JWT Authentication**: सुरक्षित API प्रवेशासाठी JSON Web Tokens (JWT) वापरणे. JWT हा JSON ऑब्जेक्ट स्वरूपात माहिती सुरक्षितपणे पाठविण्याचा एक मानक आहे, जो डिजिटल साइनिंगमुळे सत्यापित आणि विश्वासार्ह असतो.
- **Authorization Policies**: वापरकर्ता भूमिका आधारित विशिष्ट साधनांवर प्रवेश नियंत्रित करण्यासाठी धोरणे परिभाषित करणे. MCP वापरकर्ता भूमिका आणि दाव्यांवर आधारित कोणत्या वापरकर्त्यांना कोणत्या साधनांवर प्रवेश आहे हे ठरवण्यासाठी अधिकृतता धोरणे वापरते.

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

वरील कोडमध्ये, आम्ही:

- वापरकर्ता व्यवस्थापनासाठी ASP.NET Core Identity कॉन्फिगर केले आहे.
- सुरक्षित API प्रवेशासाठी JWT प्रमाणीकरण सेट केले आहे. यात टोकन सत्यापन पॅरामीटर्स जसे की issuer, audience आणि signing key समाविष्ट आहेत.
- वापरकर्ता भूमिका आधारित साधनांवर प्रवेश नियंत्रित करण्यासाठी अधिकृतता धोरणे परिभाषित केली आहेत. उदाहरणार्थ, "CanUseAdminTools" धोरणासाठी वापरकर्त्याला "Admin" भूमिका असणे आवश्यक आहे, तर "CanUseBasic" धोरणासाठी वापरकर्त्याचे प्रमाणीकरण झालेले असणे आवश्यक आहे.
- MCP साधने विशिष्ट अधिकृतता गरजांसह नोंदवली आहेत, ज्यामुळे योग्य भूमिका असलेल्या वापरकर्त्यांनाच त्यांचा प्रवेश मिळतो.

### Java Spring Security एकत्रीकरण

Java साठी, आम्ही MCP सर्व्हरसाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता राबविण्यासाठी Spring Security वापरणार आहोत. Spring Security हा Spring अनुप्रयोगांमध्ये सहजपणे एकत्रित होणारा व्यापक सुरक्षा फ्रेमवर्क आहे.

येथे मुख्य संकल्पना आहेत:

- **Spring Security Configuration**: प्रमाणीकरण आणि अधिकृतता साठी सुरक्षा कॉन्फिगरेशन सेट करणे.
- **OAuth2 Resource Server**: MCP साधनांवर सुरक्षित प्रवेशासाठी OAuth2 वापरणे. OAuth2 ही अधिकृतता फ्रेमवर्क आहे जी तृतीय पक्ष सेवा सुरक्षित API प्रवेशासाठी access tokens विनिमय करण्यास अनुमती देते.
- **Security Interceptors**: साधन अंमलबजावणीवर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर्स राबविणे.
- **Role-Based Access Control**: विशिष्ट साधने आणि संसाधनांवर प्रवेश नियंत्रित करण्यासाठी भूमिका वापरणे.
- **Security Annotations**: पद्धती आणि endpoints सुरक्षित करण्यासाठी annotations वापरणे.

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

वरील कोडमध्ये, आम्ही:

- MCP endpoints सुरक्षित करण्यासाठी Spring Security कॉन्फिगर केले आहे, ज्यामुळे साधन शोधासाठी सार्वजनिक प्रवेश दिला जातो तर साधन अंमलबजावणीसाठी प्रमाणीकरण आवश्यक आहे.
- MCP साधनांवर सुरक्षित प्रवेश हाताळण्यासाठी OAuth2 resource server वापरले आहे.
- साधन अंमलबजावणीवर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर राबविला आहे, जो वापरकर्त्याच्या भूमिका आणि परवानग्या तपासतो.
- वापरकर्ता भूमिकांवर आधारित प्रवेश नियंत्रण परिभाषित केले आहे, ज्यामुळे admin साधने आणि संवेदनशील डेटावर प्रवेश मर्यादित केला जातो.

## डेटा संरक्षण आणि गोपनीयता

डेटा संरक्षण हे संवेदनशील माहिती सुरक्षितपणे हाताळण्यासाठी अत्यंत आवश्यक आहे. यात वैयक्तिक ओळखण्यायोग्य माहिती (PII), आर्थिक डेटा आणि इतर संवेदनशील माहिती अनधिकृत प्रवेश आणि भंगापासून संरक्षित करणे समाविष्ट आहे.

### Python डेटा संरक्षण उदाहरण

Python मध्ये एन्क्रिप्शन आणि PII शोध वापरून डेटा संरक्षण कशी राबवायची हे पाहूया.

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

वरील कोडमध्ये, आम्ही:

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` वापरून संवेदनशील डेटा सुरक्षितपणे हाताळण्याची खात्री केली आहे.

## पुढे काय

- [Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीकरिता व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुतींसाठी आम्ही जबाबदार नाही.