<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T22:08:15+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "hi"
}
-->
# Security Best Practices

MCP इम्प्लीमेंटेशन के लिए सुरक्षा बहुत महत्वपूर्ण है, खासकर एंटरप्राइज वातावरण में। यह सुनिश्चित करना जरूरी है कि टूल्स और डेटा अनधिकृत पहुंच, डेटा उल्लंघनों और अन्य सुरक्षा खतरों से सुरक्षित रहें।

## Introduction

इस पाठ में, हम MCP इम्प्लीमेंटेशन के लिए सुरक्षा की बेहतरीन प्रथाओं का अध्ययन करेंगे। हम प्रमाणीकरण और प्राधिकरण, डेटा सुरक्षा, सुरक्षित टूल निष्पादन, और डेटा गोपनीयता नियमों के अनुपालन को कवर करेंगे।

## Learning Objectives

इस पाठ के अंत तक, आप सक्षम होंगे:

- MCP सर्वरों के लिए सुरक्षित प्रमाणीकरण और प्राधिकरण तंत्र लागू करना।
- संवेदनशील डेटा को एन्क्रिप्शन और सुरक्षित भंडारण के माध्यम से सुरक्षित रखना।
- उचित पहुंच नियंत्रण के साथ टूल्स के सुरक्षित निष्पादन को सुनिश्चित करना।
- डेटा सुरक्षा और गोपनीयता अनुपालन के लिए सर्वोत्तम प्रथाओं को लागू करना।

## Authentication and Authorization

प्रमाणीकरण और प्राधिकरण MCP सर्वरों को सुरक्षित करने के लिए अनिवार्य हैं। प्रमाणीकरण सवाल का जवाब देता है "आप कौन हैं?" जबकि प्राधिकरण जवाब देता है "आप क्या कर सकते हैं?"।

आइए देखें कि MCP सर्वरों में .NET और Java का उपयोग करके सुरक्षित प्रमाणीकरण और प्राधिकरण कैसे लागू किया जा सकता है।

### .NET Identity Integration

ASP .NET Core Identity उपयोगकर्ता प्रमाणीकरण और प्राधिकरण प्रबंधन के लिए एक मजबूत फ्रेमवर्क प्रदान करता है। हम इसे MCP सर्वरों के साथ एकीकृत कर सकते हैं ताकि टूल्स और संसाधनों तक सुरक्षित पहुंच सुनिश्चित की जा सके।

ASP.NET Core Identity को MCP सर्वरों के साथ एकीकृत करते समय हमें कुछ मूल अवधारणाओं को समझना होगा:

- **Identity Configuration**: ASP.NET Core Identity को उपयोगकर्ता भूमिकाओं और दावों के साथ सेटअप करना। एक दावा उपयोगकर्ता के बारे में जानकारी का एक टुकड़ा होता है, जैसे उनकी भूमिका या अनुमतियां, उदाहरण के लिए "Admin" या "User"।
- **JWT Authentication**: सुरक्षित API पहुंच के लिए JSON Web Tokens (JWT) का उपयोग। JWT एक मानक है जो पक्षों के बीच जानकारी को JSON ऑब्जेक्ट के रूप में सुरक्षित रूप से ट्रांसमिट करता है, जिसे डिजिटल रूप से साइन किया गया होता है और इसलिए इसे सत्यापित और भरोसेमंद माना जा सकता है।
- **Authorization Policies**: उपयोगकर्ता भूमिकाओं के आधार पर विशिष्ट टूल्स तक पहुंच नियंत्रित करने के लिए नीतियां निर्धारित करना। MCP प्राधिकरण नीतियों का उपयोग यह तय करने के लिए करता है कि कौन से उपयोगकर्ता किन टूल्स तक अपनी भूमिकाओं और दावों के आधार पर पहुंच सकते हैं।

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

उपरोक्त कोड में, हमने:

- उपयोगकर्ता प्रबंधन के लिए ASP.NET Core Identity को कॉन्फ़िगर किया है।
- सुरक्षित API पहुंच के लिए JWT प्रमाणीकरण सेटअप किया है। हमने टोकन सत्यापन पैरामीटर, जैसे जारीकर्ता, दर्शक, और साइनिंग कुंजी निर्दिष्ट की है।
- उपयोगकर्ता भूमिकाओं के आधार पर टूल्स तक पहुंच नियंत्रित करने के लिए प्राधिकरण नीतियां परिभाषित की हैं। उदाहरण के लिए, "CanUseAdminTools" नीति के लिए उपयोगकर्ता के पास "Admin" भूमिका होना आवश्यक है, जबकि "CanUseBasic" नीति के लिए उपयोगकर्ता का प्रमाणीकरण होना जरूरी है।
- MCP टूल्स को विशिष्ट प्राधिकरण आवश्यकताओं के साथ पंजीकृत किया है, जिससे केवल उपयुक्त भूमिकाओं वाले उपयोगकर्ता ही उन्हें एक्सेस कर सकते हैं।

### Java Spring Security Integration

Java के लिए, हम MCP सर्वरों के लिए सुरक्षित प्रमाणीकरण और प्राधिकरण लागू करने हेतु Spring Security का उपयोग करेंगे। Spring Security एक व्यापक सुरक्षा फ्रेमवर्क प्रदान करता है जो Spring एप्लिकेशन के साथ सहजता से एकीकृत होता है।

मुख्य अवधारणाएं यहां हैं:

- **Spring Security Configuration**: प्रमाणीकरण और प्राधिकरण के लिए सुरक्षा कॉन्फ़िगरेशन सेटअप करना।
- **OAuth2 Resource Server**: MCP टूल्स तक सुरक्षित पहुंच के लिए OAuth2 का उपयोग। OAuth2 एक प्राधिकरण फ्रेमवर्क है जो थर्ड-पार्टी सेवाओं को सुरक्षित API पहुंच के लिए एक्सेस टोकन एक्सचेंज करने की अनुमति देता है।
- **Security Interceptors**: टूल निष्पादन पर पहुंच नियंत्रण लागू करने के लिए सुरक्षा इंटरसेप्टर्स को लागू करना।
- **Role-Based Access Control**: विशिष्ट टूल्स और संसाधनों तक पहुंच नियंत्रित करने के लिए भूमिकाओं का उपयोग।
- **Security Annotations**: मेथड्स और एंडपॉइंट्स को सुरक्षित करने के लिए एनोटेशन का उपयोग।

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

उपरोक्त कोड में, हमने:

- MCP एंडपॉइंट्स को सुरक्षित करने के लिए Spring Security को कॉन्फ़िगर किया है, टूल डिस्कवरी के लिए सार्वजनिक पहुंच की अनुमति देते हुए टूल निष्पादन के लिए प्रमाणीकरण आवश्यक किया है।
- MCP टूल्स तक सुरक्षित पहुंच संभालने के लिए OAuth2 को एक रिसोर्स सर्वर के रूप में उपयोग किया है।
- टूल निष्पादन पर पहुंच नियंत्रण लागू करने के लिए एक सुरक्षा इंटरसेप्टर लागू किया है, जो विशिष्ट टूल्स तक पहुंच की अनुमति देने से पहले उपयोगकर्ता की भूमिकाओं और अनुमतियों की जांच करता है।
- उपयोगकर्ता भूमिकाओं के आधार पर एडमिन टूल्स और संवेदनशील डेटा तक पहुंच सीमित करने के लिए भूमिका-आधारित पहुंच नियंत्रण परिभाषित किया है।

## Data Protection and Privacy

डेटा सुरक्षा यह सुनिश्चित करने के लिए आवश्यक है कि संवेदनशील जानकारी को सुरक्षित तरीके से संभाला जाए। इसमें व्यक्तिगत पहचान योग्य जानकारी (PII), वित्तीय डेटा, और अन्य संवेदनशील जानकारी को अनधिकृत पहुंच और उल्लंघनों से बचाना शामिल है।

### Python Data Protection Example

आइए देखें कि Python में एन्क्रिप्शन और PII पहचान का उपयोग करके डेटा सुरक्षा कैसे लागू की जाती है।

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

उपरोक्त कोड में, हमने:

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` को लागू किया है ताकि यह सुनिश्चित किया जा सके कि यह संवेदनशील डेटा को सुरक्षित तरीके से संभाले।

## What's next

- [5.9 Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।