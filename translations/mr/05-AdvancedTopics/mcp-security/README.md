<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T00:22:47+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "mr"
}
-->
# सुरक्षा सर्वोत्तम पद्धती

सुरक्षा हे MCP अंमलबजावणीसाठी अत्यंत महत्त्वाचे आहे, विशेषतः एंटरप्राइझ वातावरणात. हे सुनिश्चित करणे आवश्यक आहे की साधने आणि डेटा अनधिकृत प्रवेश, डेटा उल्लंघन आणि इतर सुरक्षा धोके यापासून संरक्षित आहेत.

## परिचय

मॉडेल कॉन्टेक्स्ट प्रोटोकॉल (MCP) ला विशिष्ट सुरक्षा विचारांची गरज असते कारण त्याचा LLMs ला डेटा आणि साधनांपर्यंत प्रवेश देण्याचा महत्त्वाचा भाग आहे. हा धडा अधिकृत MCP मार्गदर्शक तत्त्वे आणि स्थापित सुरक्षा नमुन्यांवर आधारित MCP अंमलबजावणीसाठी सुरक्षा सर्वोत्तम पद्धतींचा अभ्यास करतो.

MCP सुरक्षित आणि विश्वासार्ह संवाद सुनिश्चित करण्यासाठी मुख्य सुरक्षा तत्त्वांचे पालन करते:

- **वापरकर्त्याची संमती आणि नियंत्रण**: कोणताही डेटा प्रवेश करण्यापूर्वी किंवा कोणतीही क्रिया करण्यापूर्वी वापरकर्त्याने स्पष्ट संमती द्यावी. कोणता डेटा शेअर केला जातो आणि कोणत्या क्रिया अधिकृत आहेत यावर स्पष्ट नियंत्रण द्या.
  
- **डेटा गोपनीयता**: वापरकर्त्याचा डेटा फक्त स्पष्ट संमतीनेच उघड केला जावा आणि योग्य प्रवेश नियंत्रणाद्वारे संरक्षित केला जावा. अनधिकृत डेटा प्रसारणापासून संरक्षण करा.
  
- **साधनांची सुरक्षितता**: कोणतेही साधन वापरण्यापूर्वी वापरकर्त्याची स्पष्ट संमती आवश्यक आहे. वापरकर्त्यांनी प्रत्येक साधनाच्या कार्यप्रणालीची स्पष्ट समज असावी आणि मजबूत सुरक्षा मर्यादा लागू कराव्यात.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- MCP सर्व्हर साठी सुरक्षित प्रमाणीकरण आणि अधिकृतता यंत्रणा राबविणे.
- संवेदनशील डेटाचे एन्क्रिप्शन आणि सुरक्षित संचयनाद्वारे संरक्षण करणे.
- योग्य प्रवेश नियंत्रणांसह साधनांचे सुरक्षित कार्यान्वयन सुनिश्चित करणे.
- डेटा संरक्षण आणि गोपनीयता अनुपालनासाठी सर्वोत्तम पद्धती लागू करणे.
- सामान्य MCP सुरक्षा धोके जसे की confused deputy समस्या, token passthrough, आणि session hijacking ओळखणे आणि कमी करणे.

## प्रमाणीकरण आणि अधिकृतता

प्रमाणीकरण आणि अधिकृतता हे MCP सर्व्हर सुरक्षित करण्यासाठी अत्यावश्यक आहेत. प्रमाणीकरण "तुम्ही कोण आहात?" या प्रश्नाचे उत्तर देते तर अधिकृतता "तुम्ही काय करू शकता?" या प्रश्नाचे.

MCP सुरक्षा तपशीलानुसार, हे महत्त्वाचे सुरक्षा विचार आहेत:

1. **टोकन पडताळणी**: MCP सर्व्हरने कोणतेही टोकन स्वीकारू नयेत जे स्पष्टपणे MCP सर्व्हरसाठी जारी केलेले नाहीत. "Token passthrough" हा स्पष्टपणे निषिद्ध असलेला अँटी-पॅटर्न आहे.

2. **अधिकृतता पडताळणी**: अधिकृतता राबविणारे MCP सर्व्हर सर्व इनबाउंड विनंत्या पडताळतील आणि प्रमाणीकरणासाठी सत्रांचा वापर करू नयेत.

3. **सुरक्षित सत्र व्यवस्थापन**: सत्रांसाठी राज्य वापरताना, MCP सर्व्हरने सुरक्षित, अनिश्चित सत्र आयडी वापरले पाहिजेत जे सुरक्षित यादृच्छिक संख्या जनरेटरने तयार केलेले असतील. सत्र आयडी वापरकर्त्याशी संबंधित माहितीशी बांधलेले असावेत.

4. **स्पष्ट वापरकर्ता संमती**: प्रॉक्सी सर्व्हरसाठी, MCP अंमलबजावणीने प्रत्येक डायनॅमिकली नोंदणीकृत क्लायंटसाठी वापरकर्त्याची संमती घेणे आवश्यक आहे, त्यानंतरच तृतीय-पक्ष अधिकृतता सर्व्हरकडे पुढे पाठवावे.

.NET आणि Java वापरून MCP सर्व्हरमध्ये सुरक्षित प्रमाणीकरण आणि अधिकृतता कशी राबवायची याची उदाहरणे पाहूया.

### .NET Identity एकत्रीकरण

ASP .NET Core Identity वापरकर्त्यांच्या प्रमाणीकरण आणि अधिकृतता व्यवस्थापनासाठी एक मजबूत फ्रेमवर्क प्रदान करते. आम्ही ते MCP सर्व्हरशी एकत्र करून साधने आणि संसाधनांवर सुरक्षित प्रवेश सुनिश्चित करू शकतो.

ASP.NET Core Identity आणि MCP सर्व्हर एकत्र करताना काही मुख्य संकल्पना समजून घेणे आवश्यक आहे:

- **Identity कॉन्फिगरेशन**: वापरकर्ता भूमिका आणि दावे (claims) सेट करणे. दावा म्हणजे वापरकर्त्याबद्दलची माहिती, जसे की त्यांची भूमिका किंवा परवानग्या, उदाहरणार्थ "Admin" किंवा "User".
- **JWT प्रमाणीकरण**: सुरक्षित API प्रवेशासाठी JSON Web Tokens (JWT) वापरणे. JWT ही माहिती सुरक्षितपणे JSON ऑब्जेक्ट स्वरूपात पाठवण्याची मानक पद्धत आहे, जी डिजिटल स्वाक्षरीमुळे पडताळली जाऊ शकते आणि विश्वासार्ह असते.
- **अधिकृतता धोरणे**: वापरकर्त्याच्या भूमिका आणि दाव्यांवर आधारित विशिष्ट साधनांवर प्रवेश नियंत्रित करण्यासाठी धोरणे निश्चित करणे. MCP वापरकर्त्याच्या भूमिकांनुसार कोणत्या साधनांवर प्रवेश मिळेल हे ठरवण्यासाठी अधिकृतता धोरणे वापरते.

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
- सुरक्षित API प्रवेशासाठी JWT प्रमाणीकरण सेट केले आहे. टोकन पडताळणीचे निकष जसे की जारी करणारा, प्रेक्षक, आणि स्वाक्षरी की निर्दिष्ट केली आहे.
- वापरकर्त्याच्या भूमिकांवर आधारित साधनांवर प्रवेश नियंत्रित करण्यासाठी अधिकृतता धोरणे निश्चित केली आहेत. उदाहरणार्थ, "CanUseAdminTools" धोरणासाठी वापरकर्त्याला "Admin" भूमिका असणे आवश्यक आहे, तर "CanUseBasic" धोरणासाठी वापरकर्त्याचे प्रमाणीकरण झालेले असणे आवश्यक आहे.
- विशिष्ट अधिकृतता आवश्यकतांसह MCP साधने नोंदणी केली आहेत, ज्यामुळे केवळ योग्य भूमिका असलेल्या वापरकर्त्यांनाच त्यांचा प्रवेश मिळतो.

### Java Spring Security एकत्रीकरण

Java साठी, आम्ही MCP सर्व्हरसाठी सुरक्षित प्रमाणीकरण आणि अधिकृतता राबविण्यासाठी Spring Security वापरणार आहोत. Spring Security हे Spring अनुप्रयोगांसोबत सहजपणे एकत्र होणारे व्यापक सुरक्षा फ्रेमवर्क आहे.

येथे मुख्य संकल्पना आहेत:

- **Spring Security कॉन्फिगरेशन**: प्रमाणीकरण आणि अधिकृततेसाठी सुरक्षा कॉन्फिगरेशन सेट करणे.
- **OAuth2 रिसोर्स सर्व्हर**: MCP साधनांवर सुरक्षित प्रवेशासाठी OAuth2 वापरणे. OAuth2 हे अधिकृतता फ्रेमवर्क आहे जे तृतीय-पक्ष सेवा सुरक्षित API प्रवेशासाठी प्रवेश टोकनची देवाणघेवाण करू देते.
- **सुरक्षा इंटरसेप्टर्स**: साधनांच्या कार्यान्वयनावर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर्स राबविणे.
- **भूमिकाधारित प्रवेश नियंत्रण**: विशिष्ट साधने आणि संसाधनांवर प्रवेश नियंत्रित करण्यासाठी भूमिका वापरणे.
- **सुरक्षा अ‍ॅनोटेशन्स**: पद्धती आणि एंडपॉइंट्स सुरक्षित करण्यासाठी अ‍ॅनोटेशन्स वापरणे.

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

- MCP एंडपॉइंट्स सुरक्षित करण्यासाठी Spring Security कॉन्फिगर केले आहे, साधन शोधासाठी सार्वजनिक प्रवेश परवानगी देत असताना साधन कार्यान्वयनासाठी प्रमाणीकरण आवश्यक आहे.
- MCP साधनांवर सुरक्षित प्रवेश हाताळण्यासाठी OAuth2 रिसोर्स सर्व्हर वापरले आहे.
- साधन कार्यान्वयनावर प्रवेश नियंत्रण लागू करण्यासाठी सुरक्षा इंटरसेप्टर राबविला आहे, ज्यात वापरकर्त्याच्या भूमिका आणि परवानग्या तपासल्या जातात.
- वापरकर्त्याच्या भूमिकांवर आधारित प्रवेश नियंत्रण निश्चित केले आहे, ज्यामुळे प्रशासकीय साधने आणि संवेदनशील डेटावर प्रवेश मर्यादित केला जातो.

## डेटा संरक्षण आणि गोपनीयता

डेटा संरक्षण हे संवेदनशील माहिती सुरक्षितपणे हाताळण्यासाठी अत्यंत महत्त्वाचे आहे. यात वैयक्तिक ओळख पटवणारी माहिती (PII), आर्थिक डेटा आणि इतर संवेदनशील माहिती अनधिकृत प्रवेश आणि उल्लंघनापासून संरक्षण करणे समाविष्ट आहे.

### Python डेटा संरक्षण उदाहरण

एन्क्रिप्शन आणि PII शोध वापरून Python मध्ये डेटा संरक्षण कसे राबवायचे याचे उदाहरण पाहूया.

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

- `PiiDetector` वर्ग तयार केला आहे जो मजकूर आणि पॅरामीटर्समध्ये वैयक्तिक ओळख पटवणारी माहिती (PII) शोधतो.
- `EncryptionService` वर्ग तयार केला आहे जो `cryptography` लायब्ररी वापरून संवेदनशील डेटाचे एन्क्रिप्शन आणि डीक्रिप्शन हाताळतो.
- `secure_tool` डेकोरेटर तयार केला आहे जो साधन कार्यान्वयनाला वेढतो, PII तपासतो, प्रवेश लॉग करतो आणि आवश्यक असल्यास संवेदनशील डेटा एन्क्रिप्ट करतो.
- `secure_tool` डेकोरेटर एका नमुना साधनावर (`SecureCustomerDataTool`) लागू केला आहे जेणेकरून ते संवेदनशील डेटा सुरक्षितपणे हाताळेल.

## MCP-विशिष्ट सुरक्षा धोके

अधिकृत MCP सुरक्षा दस्तऐवजांनुसार, MCP अंमलबजावणीकर्त्यांनी लक्षात ठेवावयाचे विशिष्ट सुरक्षा धोके आहेत:

### 1. Confused Deputy समस्या

ही असुरक्षितता तेव्हा उद्भवते जेव्हा MCP सर्व्हर तृतीय-पक्ष API साठी प्रॉक्सी म्हणून कार्य करतो, ज्यामुळे हल्लेखोरांना MCP सर्व्हर आणि या API मधील विश्वासार्ह संबंधाचा गैरफायदा घेण्याची संधी मिळू शकते.

**उपाय:**
- MCP प्रॉक्सी सर्व्हरने स्थिर क्लायंट आयडी वापरताना प्रत्येक डायनॅमिक नोंदणीकृत क्लायंटसाठी वापरकर्त्याची संमती घेणे आवश्यक आहे, त्यानंतरच तृतीय-पक्ष अधिकृतता सर्व्हरकडे पुढे पाठवावे.
- अधिकृतता विनंत्यांसाठी PKCE (Proof Key for Code Exchange) सह योग्य OAuth प्रवाह राबवा.
- रीडायरेक्ट URI आणि क्लायंट आयडेंटिफायर्स काटेकोरपणे पडताळा.

### 2. Token Passthrough धोके

Token passthrough तेव्हा होते जेव्हा MCP सर्व्हर MCP क्लायंटकडून टोकन स्वीकारतो परंतु हे पडताळणी करत नाही की टोकन योग्यरित्या MCP सर्व्हरसाठी जारी केले आहेत का आणि नंतर ते टोकन खालील API कडे पास करतो.

### धोके
- सुरक्षा नियंत्रण टाळणे (रेट लिमिटिंग, विनंती पडताळणी टाळणे)
- जबाबदारी आणि ऑडिट ट्रेल समस्या
- विश्वास मर्यादा उल्लंघन
- भविष्यातील सुसंगततेचे धोके

**उपाय:**
- MCP सर्व्हरने कोणतेही टोकन स्वीकारू नयेत जे स्पष्टपणे MCP सर्व्हरसाठी जारी केलेले नाहीत.
- टोकन प्रेक्षक दावे नेहमी पडताळा जेणेकरून ते अपेक्षित सेवेशी जुळतात याची खात्री होईल.

### 3. सत्र हायजॅकिंग

ही समस्या तेव्हा उद्भवते जेव्हा अनधिकृत पक्ष सत्र आयडी मिळवतो आणि मूळ क्लायंटची नक्कल करतो, ज्यामुळे अनधिकृत क्रिया होऊ शकतात.

**उपाय:**
- अधिकृतता राबविणारे MCP सर्व्हर सर्व इनबाउंड विनंत्या पडताळतील आणि प्रमाणीकरणासाठी सत्रांचा वापर करू नयेत.
- सुरक्षित, अनिश्चित सत्र आयडी वापरा जे सुरक्षित यादृच्छिक संख्या जनरेटरने तयार केलेले असतील.
- सत्र आयडी वापरकर्त्याशी संबंधित माहितीशी `<user_id>:<session_id>` या स्वरूपात बांधा.
- योग्य सत्र कालबाह्यता आणि फेरफटका धोरणे राबवा.

## MCP साठी अतिरिक्त सुरक्षा सर्वोत्तम पद्धती

मूलभूत MCP सुरक्षा विचारांव्यतिरिक्त, खालील अतिरिक्त सुरक्षा पद्धतींचा विचार करा:

- **नेहमी HTTPS वापरा**: क्लायंट आणि सर्व्हरमधील संवाद एन्क्रिप्ट करा जेणेकरून टोकन हस्तक्षेपापासून सुरक्षित राहतील.
- **भूमिकाधारित प्रवेश नियंत्रण (RBAC) राबवा**: फक्त वापरकर्ता प्रमाणीकरण तपासू नका; त्याला काय करण्याची परवानगी आहे ते तपासा.
- **निगराणी आणि ऑडिट करा**: सर्व प्रमाणीकरण घटना लॉग करा जेणेकरून संशयास्पद क्रियाकलाप ओळखता येतील आणि प्रतिसाद देता येईल.
- **रेट लिमिटिंग आणि थ्रॉटलिंग हाताळा**: रेट लिमिट्स सहज हाताळण्यासाठी एक्स्पोनेंशियल बॅकऑफ आणि पुनर्प्रयत्न लॉजिक राबवा.
- **सुरक्षित टोकन संचयन**: प्रवेश टोकन आणि रिफ्रेश टोकन सुरक्षितपणे संचयित करा, सिस्टमच्या सुरक्षित संचयन यंत्रणा किंवा सुरक्षित की व्यवस्थापन सेवा वापरून.
- **API व्यवस्थापन वापरण्याचा विचार करा**: Azure API Management सारख्या सेवा अनेक सुरक्षा चिंता आपोआप हाताळू शकतात, ज्यात प्रमाणीकरण, अधिकृतता आणि रेट लिमिटिंग यांचा समावेश आहे.

## संदर्भ

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## पुढे काय

- [5.9 वेब शोध](../web-search-mcp/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.