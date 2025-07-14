<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:38:10+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ne"
}
-->
# सुरक्षा उत्कृष्ट अभ्यासहरू

सुरक्षा MCP कार्यान्वयनहरूका लागि अत्यन्त महत्वपूर्ण छ, विशेष गरी उद्यम वातावरणहरूमा। उपकरणहरू र डाटालाई अनधिकृत पहुँच, डाटा चुहावट, र अन्य सुरक्षा खतराहरूबाट सुरक्षित राख्नु आवश्यक छ।

## परिचय

यस पाठमा, हामी MCP कार्यान्वयनहरूको लागि सुरक्षा उत्कृष्ट अभ्यासहरू अन्वेषण गर्नेछौं। हामी प्रमाणीकरण र प्राधिकरण, डाटा सुरक्षा, सुरक्षित उपकरण सञ्चालन, र डाटा गोपनीयता नियमहरूको पालना समेट्नेछौं।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- MCP सर्भरहरूको लागि सुरक्षित प्रमाणीकरण र प्राधिकरण संयन्त्रहरू कार्यान्वयन गर्न।
- संवेदनशील डाटालाई इन्क्रिप्सन र सुरक्षित भण्डारणमार्फत संरक्षण गर्न।
- उचित पहुँच नियन्त्रणहरूसँग उपकरणहरूको सुरक्षित सञ्चालन सुनिश्चित गर्न।
- डाटा सुरक्षा र गोपनीयता पालना सम्बन्धी उत्कृष्ट अभ्यासहरू लागू गर्न।

## प्रमाणीकरण र प्राधिकरण

प्रमाणीकरण र प्राधिकरण MCP सर्भरहरूलाई सुरक्षित बनाउन अनिवार्य छन्। प्रमाणीकरणले "तपाईं को हुनुहुन्छ?" भन्ने प्रश्नको उत्तर दिन्छ भने प्राधिकरणले "तपाईं के गर्न सक्नुहुन्छ?" भन्ने प्रश्नको उत्तर दिन्छ।

अब हामी .NET र Java प्रयोग गरी MCP सर्भरहरूमा कसरी सुरक्षित प्रमाणीकरण र प्राधिकरण कार्यान्वयन गर्ने उदाहरणहरू हेरौं।

### .NET Identity एकीकरण

ASP .NET Core Identity ले प्रयोगकर्ता प्रमाणीकरण र प्राधिकरण व्यवस्थापनका लागि बलियो फ्रेमवर्क प्रदान गर्दछ। हामी यसलाई MCP सर्भरहरूसँग एकीकृत गरेर उपकरण र स्रोतहरूमा पहुँच सुरक्षित बनाउन सक्छौं।

ASP.NET Core Identity लाई MCP सर्भरहरूसँग एकीकृत गर्दा बुझ्नुपर्ने केही मुख्य अवधारणाहरू छन्:

- **Identity Configuration**: प्रयोगकर्ता भूमिका र दाबीहरूसँग ASP.NET Core Identity सेटअप गर्ने। दाबी भनेको प्रयोगकर्ताको बारेमा जानकारीको टुक्रा हो, जस्तै तिनीहरूको भूमिका वा अनुमति, उदाहरणका लागि "Admin" वा "User"।
- **JWT Authentication**: सुरक्षित API पहुँचका लागि JSON Web Tokens (JWT) को प्रयोग। JWT एक मानक हो जसले JSON वस्तुको रूपमा पक्षहरूबीच जानकारी सुरक्षित रूपमा प्रसारण गर्न अनुमति दिन्छ, जुन डिजिटल रूपमा हस्ताक्षरित भएकाले प्रमाणित र विश्वासयोग्य हुन्छ।
- **Authorization Policies**: प्रयोगकर्ता भूमिकाहरूको आधारमा विशिष्ट उपकरणहरूमा पहुँच नियन्त्रण गर्न नीतिहरू परिभाषित गर्ने। MCP ले प्रयोगकर्ता भूमिकाहरू र दाबीहरूको आधारमा कुन प्रयोगकर्ताले कुन उपकरणहरू प्रयोग गर्न सक्छन् निर्धारण गर्न प्राधिकरण नीतिहरू प्रयोग गर्छ।

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

माथिको कोडमा, हामीले:

- प्रयोगकर्ता व्यवस्थापनका लागि ASP.NET Core Identity कन्फिगर गरेका छौं।
- सुरक्षित API पहुँचका लागि JWT प्रमाणीकरण सेटअप गरेका छौं। हामीले टोकन प्रमाणीकरणका प्यारामिटरहरू, जस्तै जारीकर्ता, दर्शक, र हस्ताक्षर कुञ्जी निर्दिष्ट गरेका छौं।
- प्रयोगकर्ता भूमिकाहरूको आधारमा उपकरण पहुँच नियन्त्रण गर्न प्राधिकरण नीतिहरू परिभाषित गरेका छौं। उदाहरणका लागि, "CanUseAdminTools" नीति प्रयोगकर्ताले "Admin" भूमिका हुनुपर्नेछ भने "CanUseBasic" नीति प्रयोगकर्ताले प्रमाणीकरण गरिएको हुनुपर्नेछ।
- MCP उपकरणहरूलाई विशिष्ट प्राधिकरण आवश्यकतासहित दर्ता गरेका छौं, जसले उपयुक्त भूमिका भएका प्रयोगकर्ताहरूलाई मात्र पहुँच सुनिश्चित गर्छ।

### Java Spring Security एकीकरण

Java का लागि, हामी MCP सर्भरहरूको लागि सुरक्षित प्रमाणीकरण र प्राधिकरण कार्यान्वयन गर्न Spring Security प्रयोग गर्नेछौं। Spring Security ले Spring अनुप्रयोगहरूसँग सहज रूपमा एकीकृत हुने व्यापक सुरक्षा फ्रेमवर्क प्रदान गर्दछ।

यहाँका मुख्य अवधारणाहरू हुन्:

- **Spring Security Configuration**: प्रमाणीकरण र प्राधिकरणका लागि सुरक्षा कन्फिगरेसन सेटअप गर्ने।
- **OAuth2 Resource Server**: MCP उपकरणहरूमा सुरक्षित पहुँचका लागि OAuth2 को प्रयोग। OAuth2 एक प्राधिकरण फ्रेमवर्क हो जसले तेस्रो पक्ष सेवाहरूलाई सुरक्षित API पहुँचका लागि पहुँच टोकनहरू आदानप्रदान गर्न अनुमति दिन्छ।
- **Security Interceptors**: उपकरण सञ्चालनमा पहुँच नियन्त्रण लागू गर्न सुरक्षा इन्टरसेप्टरहरू कार्यान्वयन गर्ने।
- **Role-Based Access Control**: विशिष्ट उपकरण र स्रोतहरूमा पहुँच नियन्त्रण गर्न भूमिकाहरूको प्रयोग।
- **Security Annotations**: विधिहरू र अन्तबिन्दुहरूलाई सुरक्षित बनाउन एनोटेसनहरूको प्रयोग।

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

माथिको कोडमा, हामीले:

- MCP अन्तबिन्दुहरूलाई सुरक्षित बनाउन Spring Security कन्फिगर गरेका छौं, उपकरण पत्ता लगाउन सार्वजनिक पहुँच अनुमति दिँदै उपकरण सञ्चालनका लागि प्रमाणीकरण आवश्यक पर्ने गरी।
- MCP उपकरणहरूमा सुरक्षित पहुँचको लागि OAuth2 लाई स्रोत सर्भरको रूपमा प्रयोग गरेका छौं।
- उपकरण सञ्चालनमा पहुँच नियन्त्रण लागू गर्न सुरक्षा इन्टरसेप्टर कार्यान्वयन गरेका छौं, विशिष्ट उपकरणहरूमा पहुँच दिनुअघि प्रयोगकर्ता भूमिका र अनुमति जाँच गर्दै।
- प्रयोगकर्ता भूमिकाहरूको आधारमा प्रशासनिक उपकरण र संवेदनशील डाटा पहुँच सीमित गर्न भूमिका-आधारित पहुँच नियन्त्रण परिभाषित गरेका छौं।

## डाटा सुरक्षा र गोपनीयता

डाटा सुरक्षा संवेदनशील जानकारीलाई सुरक्षित रूपमा व्यवस्थापन गर्न अत्यावश्यक छ। यसमा व्यक्तिगत पहिचानयोग्य जानकारी (PII), वित्तीय डाटा, र अन्य संवेदनशील जानकारीलाई अनधिकृत पहुँच र चुहावटबाट जोगाउनु पर्दछ।

### Python डाटा सुरक्षा उदाहरण

अब हामी Python मा इन्क्रिप्सन र PII पत्ता लगाउने प्रयोग गरी डाटा सुरक्षा कसरी कार्यान्वयन गर्ने उदाहरण हेरौं।

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

माथिको कोडमा, हामीले:

- `PiiDetector` क्लास कार्यान्वयन गरेका छौं जसले पाठ र प्यारामिटरहरूमा व्यक्तिगत पहिचानयोग्य जानकारी (PII) स्क्यान गर्छ।
- `EncryptionService` क्लास बनाएका छौं जसले `cryptography` लाइब्रेरी प्रयोग गरी संवेदनशील डाटाको इन्क्रिप्सन र डिक्रिप्सन ह्यान्डल गर्छ।
- `secure_tool` डेकोरेटर परिभाषित गरेका छौं जसले उपकरण सञ्चालनलाई PII जाँच, पहुँच लगिङ, र आवश्यक परे संवेदनशील डाटाको इन्क्रिप्सन गरेर सुरक्षित बनाउँछ।
- नमूना उपकरण (`SecureCustomerDataTool`) मा `secure_tool` डेकोरेटर लागू गरेका छौं जसले सुनिश्चित गर्छ कि यो संवेदनशील डाटालाई सुरक्षित रूपमा ह्यान्डल गर्छ।

## के छ अर्को

- [5.9 Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।