<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:37:53+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "mr"
}
-->
# सुरक्षा सर्वोत्तम पद्धती

MCP अंमलबजावणीसाठी सुरक्षा अत्यंत महत्त्वाची आहे, विशेषतः एंटरप्राइझ वातावरणात. हे सुनिश्चित करणे आवश्यक आहे की साधने आणि डेटा अनधिकृत प्रवेश, डेटा उल्लंघन आणि इतर सुरक्षा धोके यापासून संरक्षित आहेत.

## परिचय

या धड्यात, आपण MCP अंमलबजावणीसाठी सुरक्षा सर्वोत्तम पद्धतींचा अभ्यास करू. आपण प्रमाणीकरण आणि अधिकृतता, डेटा संरक्षण, सुरक्षित साधन अंमलबजावणी, आणि डेटा गोपनीयता नियमांचे पालन यावर चर्चा करू.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, आपण सक्षम असाल:

- MCP सर्व्हरसाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता यंत्रणा राबविणे.
- संवेदनशील डेटाचे एन्क्रिप्शन आणि सुरक्षित संचयनाद्वारे संरक्षण करणे.
- योग्य प्रवेश नियंत्रणांसह साधनांची सुरक्षित अंमलबजावणी सुनिश्चित करणे.
- डेटा संरक्षण आणि गोपनीयता नियमांचे पालन करण्यासाठी सर्वोत्तम पद्धती लागू करणे.

## प्रमाणीकरण आणि अधिकृतता

प्रमाणीकरण आणि अधिकृतता हे MCP सर्व्हर सुरक्षित करण्यासाठी अत्यावश्यक आहेत. प्रमाणीकरण "तुम्ही कोण आहात?" या प्रश्नाचे उत्तर देते तर अधिकृतता "तुम्ही काय करू शकता?" या प्रश्नाचे.

.NET आणि Java वापरून MCP सर्व्हरमध्ये सुरक्षित प्रमाणीकरण आणि अधिकृतता कशी राबवायची याची उदाहरणे पाहूया.

### .NET Identity एकत्रीकरण

ASP .NET Core Identity वापरकर्त्यांच्या प्रमाणीकरण आणि अधिकृतता व्यवस्थापनासाठी एक मजबूत फ्रेमवर्क प्रदान करते. आपण ते MCP सर्व्हरशी एकत्र करून साधने आणि संसाधनांवर सुरक्षित प्रवेश सुनिश्चित करू शकतो.

ASP.NET Core Identity चे MCP सर्व्हरशी एकत्रीकरण करताना काही मूलभूत संकल्पना समजून घेणे आवश्यक आहे:

- **Identity Configuration**: वापरकर्ता भूमिका आणि दावे (claims) सह ASP.NET Core Identity सेट करणे. दावा म्हणजे वापरकर्त्याबद्दलची माहिती, जसे की त्यांची भूमिका किंवा परवानग्या, उदाहरणार्थ "Admin" किंवा "User".
- **JWT Authentication**: सुरक्षित API प्रवेशासाठी JSON Web Tokens (JWT) वापरणे. JWT ही माहिती सुरक्षितपणे JSON ऑब्जेक्ट स्वरूपात पाठवण्याची एक मानक पद्धत आहे, जी डिजिटल स्वाक्षरीमुळे सत्यापित आणि विश्वासार्ह असते.
- **Authorization Policies**: वापरकर्त्यांच्या भूमिका आणि दाव्यांवर आधारित विशिष्ट साधनांवर प्रवेश नियंत्रित करण्यासाठी धोरणे निश्चित करणे. MCP वापरकर्त्यांच्या भूमिका आणि दाव्यांनुसार कोणत्या वापरकर्त्यांना कोणती साधने वापरता येतील हे ठरवण्यासाठी अधिकृतता धोरणे वापरते.

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

वरील कोडमध्ये, आपण:

- वापरकर्ता व्यवस्थापनासाठी ASP.NET Core Identity कॉन्फिगर केले आहे.
- सुरक्षित API प्रवेशासाठी JWT प्रमाणीकरण सेट केले आहे. यात टोकन सत्यापनाचे निकष, जसे की जारी करणारा, प्रेक्षक, आणि स्वाक्षरी की यांचा समावेश आहे.
- वापरकर्त्यांच्या भूमिका आधारित साधनांवर प्रवेश नियंत्रित करण्यासाठी अधिकृतता धोरणे निश्चित केली आहेत. उदाहरणार्थ, "CanUseAdminTools" धोरणासाठी वापरकर्त्याला "Admin" भूमिका असणे आवश्यक आहे, तर "CanUseBasic" धोरणासाठी वापरकर्त्याचे प्रमाणीकरण झालेले असणे आवश्यक आहे.
- MCP साधने विशिष्ट अधिकृतता आवश्यकतांसह नोंदवली आहेत, ज्यामुळे केवळ योग्य भूमिका असलेले वापरकर्ते त्यांना वापरू शकतात.

### Java Spring Security एकत्रीकरण

Java साठी, आपण MCP सर्व्हरसाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता राबविण्यासाठी Spring Security वापरणार आहोत. Spring Security हे एक व्यापक सुरक्षा फ्रेमवर्क आहे जे Spring अनुप्रयोगांशी सहजपणे एकत्रित होते.

येथे काही मूलभूत संकल्पना आहेत:

- **Spring Security Configuration**: प्रमाणीकरण आणि अधिकृतता साठी सुरक्षा कॉन्फिगरेशन सेट करणे.
- **OAuth2 Resource Server**: MCP साधनांवर सुरक्षित प्रवेशासाठी OAuth2 वापरणे. OAuth2 ही अधिकृतता फ्रेमवर्क आहे जी तृतीय-पक्ष सेवा सुरक्षित API प्रवेशासाठी प्रवेश टोकनची देवाणघेवाण करण्यास अनुमती देते.
- **Security Interceptors**: साधन अंमलबजावणीवर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर्स राबविणे.
- **Role-Based Access Control**: विशिष्ट साधने आणि संसाधनांवर प्रवेश नियंत्रित करण्यासाठी भूमिका वापरणे.
- **Security Annotations**: पद्धती आणि एंडपॉइंट्स सुरक्षित करण्यासाठी अ‍ॅनोटेशन्स वापरणे.

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

वरील कोडमध्ये, आपण:

- MCP एंडपॉइंट्स सुरक्षित करण्यासाठी Spring Security कॉन्फिगर केले आहे, ज्यामुळे साधन शोधासाठी सार्वजनिक प्रवेश परवानगी आहे, परंतु साधन अंमलबजावणीसाठी प्रमाणीकरण आवश्यक आहे.
- MCP साधनांवर सुरक्षित प्रवेश हाताळण्यासाठी OAuth2 रिसोर्स सर्व्हर वापरले आहे.
- साधन अंमलबजावणीवर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर राबविला आहे, जो विशिष्ट साधनांवर प्रवेश देण्यापूर्वी वापरकर्त्याच्या भूमिका आणि परवानग्या तपासतो.
- वापरकर्त्यांच्या भूमिकांवर आधारित प्रवेश नियंत्रण निश्चित केले आहे, ज्यामुळे प्रशासकीय साधने आणि संवेदनशील डेटावर प्रवेश मर्यादित केला जातो.

## डेटा संरक्षण आणि गोपनीयता

डेटा संरक्षण हे संवेदनशील माहिती सुरक्षितपणे हाताळण्याच्या दृष्टीने अत्यंत महत्त्वाचे आहे. यात वैयक्तिक ओळख पटविणारी माहिती (PII), आर्थिक डेटा आणि इतर संवेदनशील माहिती अनधिकृत प्रवेश आणि उल्लंघनापासून संरक्षण करणे समाविष्ट आहे.

### Python डेटा संरक्षण उदाहरण

Python मध्ये एन्क्रिप्शन आणि PII शोध वापरून डेटा संरक्षण कसे राबवायचे याचे उदाहरण पाहूया.

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

वरील कोडमध्ये, आपण:

- `PiiDetector` वर्ग राबविला आहे जो मजकूर आणि पॅरामीटर्समध्ये वैयक्तिक ओळख पटविणारी माहिती (PII) शोधतो.
- `cryptography` लायब्ररी वापरून संवेदनशील डेटाचे एन्क्रिप्शन आणि डीक्रिप्शन हाताळण्यासाठी `EncryptionService` वर्ग तयार केला आहे.
- `secure_tool` डेकोरेटर तयार केला आहे जो साधन अंमलबजावणीला वेढून ठेवतो, PII तपासतो, प्रवेश लॉग करतो, आणि आवश्यक असल्यास संवेदनशील डेटा एन्क्रिप्ट करतो.
- `secure_tool` डेकोरेटर एका नमुना साधनावर (`SecureCustomerDataTool`) लागू केला आहे जेणेकरून ते संवेदनशील डेटा सुरक्षितपणे हाताळेल.

## पुढे काय

- [5.9 Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.