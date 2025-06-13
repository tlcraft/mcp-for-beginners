<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T23:23:16+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "mr"
}
-->
# सुरक्षा सर्वोत्तम पद्धती

MCP अंमलबजावणीसाठी सुरक्षा अत्यंत महत्त्वाची आहे, विशेषतः एंटरप्राइझ वातावरणात. हे सुनिश्चित करणे आवश्यक आहे की साधने आणि डेटा अनधिकृत प्रवेश, डेटा उल्लंघन आणि इतर सुरक्षा धोके यापासून संरक्षित आहेत.

## परिचय

या धड्यात आपण MCP अंमलबजावणीसाठी सुरक्षा सर्वोत्तम पद्धतींचा अभ्यास करू. आपण प्रमाणीकरण आणि अधिकृतता, डेटा संरक्षण, सुरक्षित साधन अंमलबजावणी, आणि डेटा गोपनीयता नियमांचे पालन यावर चर्चा करू.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, आपण सक्षम असाल:

- MCP सर्व्हर्ससाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता यंत्रणा अंमलात आणणे.
- संवेदनशील डेटाचे एन्क्रिप्शन आणि सुरक्षित साठवणूक वापरून संरक्षण करणे.
- योग्य प्रवेश नियंत्रणांसह साधनांची सुरक्षित अंमलबजावणी सुनिश्चित करणे.
- डेटा संरक्षण आणि गोपनीयता नियमांचे पालन करण्यासाठी सर्वोत्तम पद्धती लागू करणे.

## प्रमाणीकरण आणि अधिकृतता

प्रमाणीकरण आणि अधिकृतता हे MCP सर्व्हर्स सुरक्षित करण्यासाठी अत्यावश्यक आहेत. प्रमाणीकरण "तुम्ही कोण आहात?" या प्रश्नाचे उत्तर देते, तर अधिकृतता "तुम्ही काय करू शकता?" याचे उत्तर देते.

चला पाहूया .NET आणि Java वापरून MCP सर्व्हर्समध्ये सुरक्षित प्रमाणीकरण आणि अधिकृतता कशी अंमलात आणायची याची उदाहरणे.

### .NET ओळख एकत्रीकरण

ASP .NET Core Identity वापरकर्त्यांच्या प्रमाणीकरण आणि अधिकृतता व्यवस्थापनासाठी एक मजबूत फ्रेमवर्क प्रदान करते. आपण त्याला MCP सर्व्हर्ससोबत एकत्र करून साधने आणि संसाधनांवर प्रवेश सुरक्षित करू शकतो.

ASP.NET Core Identity ला MCP सर्व्हर्समध्ये एकत्रित करताना काही मुख्य संकल्पना समजून घेणे आवश्यक आहे:

- **ओळख संरचना**: वापरकर्ता भूमिका आणि दावे सेट करणे. दावा म्हणजे वापरकर्त्याबद्दलची माहिती, जसे की त्यांची भूमिका किंवा परवानग्या, उदा. "Admin" किंवा "User".
- **JWT प्रमाणीकरण**: सुरक्षित API प्रवेशासाठी JSON वेब टोकन (JWT) वापरणे. JWT हा एक मानक आहे जो JSON ऑब्जेक्टच्या स्वरूपात माहिती सुरक्षितपणे प्रसारित करतो, ज्याची डिजिटल स्वाक्षरीमुळे पडताळणी केली जाऊ शकते.
- **अधिकृतता धोरणे**: वापरकर्ता भूमिकांवर आधारित विशिष्ट साधनांवर प्रवेश नियंत्रित करण्यासाठी धोरणे निश्चित करणे. MCP वापरकर्ता भूमिका आणि दाव्यांनुसार कोणत्या वापरकर्त्यांना कोणती साधने वापरता येतील हे ठरवण्यासाठी अधिकृतता धोरणांचा वापर करतो.

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

- वापरकर्ता व्यवस्थापनासाठी ASP.NET Core Identity संरचीत केले आहे.
- सुरक्षित API प्रवेशासाठी JWT प्रमाणीकरण सेट केले आहे. यात जारी करणारा, प्रेक्षक, आणि स्वाक्षरी की यांसारखे टोकन पडताळणीचे निकष नमूद केले आहेत.
- वापरकर्ता भूमिकांवर आधारित साधनांवर प्रवेश नियंत्रित करण्यासाठी अधिकृतता धोरणे निश्चित केली आहेत. उदाहरणार्थ, "CanUseAdminTools" धोरणासाठी वापरकर्त्याला "Admin" भूमिका असणे आवश्यक आहे, तर "CanUseBasic" धोरणासाठी वापरकर्त्याचे प्रमाणीकरण आवश्यक आहे.
- विशिष्ट अधिकृतता आवश्यकतांसह MCP साधने नोंदवली आहेत, ज्यामुळे योग्य भूमिका असलेल्या वापरकर्त्यांनाच त्यांचा प्रवेश मिळतो.

### Java Spring Security एकत्रीकरण

Java साठी, आपण MCP सर्व्हर्ससाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता अंमलात आणण्यासाठी Spring Security वापरणार आहोत. Spring Security हे Spring अनुप्रयोगांसोबत सहजपणे एकत्रित होणारे व्यापक सुरक्षा फ्रेमवर्क आहे.

येथे मुख्य संकल्पना आहेत:

- **Spring Security संरचना**: प्रमाणीकरण आणि अधिकृततेसाठी सुरक्षा संरचना सेट करणे.
- **OAuth2 रिसोर्स सर्व्हर**: MCP साधनांवर सुरक्षित प्रवेशासाठी OAuth2 वापरणे. OAuth2 हा अधिकृतता फ्रेमवर्क आहे जो तृतीय-पक्ष सेवा सुरक्षित API प्रवेशासाठी प्रवेश टोकन विनिमय करू शकतात.
- **सुरक्षा इंटरसेप्टर्स**: साधन अंमलबजावणीवर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर्स वापरणे.
- **भूमिकाधारित प्रवेश नियंत्रण**: विशिष्ट साधने आणि संसाधनांवर प्रवेश नियंत्रित करण्यासाठी भूमिका वापरणे.
- **सुरक्षा अ‍ॅनोटेशन्स**: पद्धती आणि एंडपॉइंट सुरक्षित करण्यासाठी अ‍ॅनोटेशन्स वापरणे.

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

- MCP एंडपॉइंट्स सुरक्षित करण्यासाठी Spring Security संरचीत केले आहे, जेथे साधन शोधासाठी सार्वजनिक प्रवेश परवानगी दिली आहे, पण साधन अंमलबजावणीसाठी प्रमाणीकरण आवश्यक आहे.
- MCP साधनांवर सुरक्षित प्रवेश हाताळण्यासाठी OAuth2 रिसोर्स सर्व्हर म्हणून वापरले आहे.
- साधन अंमलबजावणीवर प्रवेश नियंत्रण अंमलात आणण्यासाठी सुरक्षा इंटरसेप्टर लागू केला आहे, जो विशिष्ट साधनांवर प्रवेश देण्यापूर्वी वापरकर्त्याच्या भूमिका आणि परवानग्या तपासतो.
- वापरकर्ता भूमिकांनुसार प्रशासकीय साधने आणि संवेदनशील डेटा प्रवेश मर्यादित करण्यासाठी भूमिकाधारित प्रवेश नियंत्रण निश्चित केले आहे.

## डेटा संरक्षण आणि गोपनीयता

डेटा संरक्षण हे संवेदनशील माहिती सुरक्षितपणे हाताळण्याच्या दृष्टीने अत्यंत महत्त्वाचे आहे. यात वैयक्तिक ओळखण्यायोग्य माहिती (PII), आर्थिक डेटा आणि इतर संवेदनशील माहिती अनधिकृत प्रवेश आणि उल्लंघनापासून संरक्षण करणे समाविष्ट आहे.

### Python डेटा संरक्षण उदाहरण

Python मध्ये एन्क्रिप्शन आणि PII शोध वापरून डेटा संरक्षण कशी अंमलात आणायची याचे उदाहरण पाहूया.

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

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` यांसारख्या साधनांसाठी संवेदनशील डेटा सुरक्षितपणे हाताळण्याची खात्री करण्यासाठी डेटा संरक्षण अंमलात आणले आहे.

## पुढे काय

- [5.9 Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीकरिता व्यावसायिक मानवी अनुवाद शिफारसीय आहे. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुतीसाठी किंवा चुकीच्या अर्थलागीसाठी आम्ही जबाबदार नाही.