<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T23:28:18+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ne"
}
-->
# सुरक्षा उत्तम अभ्यासहरू

MCP कार्यान्वयनहरूमा सुरक्षा अत्यन्त महत्वपूर्ण छ, विशेष गरी उद्यम वातावरणहरूमा। उपकरणहरू र डेटा अनधिकृत पहुँच, डेटा भंग, र अन्य सुरक्षा खतराहरूबाट सुरक्षित राख्न आवश्यक छ।

## परिचय

यस पाठमा, हामी MCP कार्यान्वयनहरूको लागि सुरक्षा उत्तम अभ्यासहरू अन्वेषण गर्नेछौं। हामी प्रमाणीकरण र प्राधिकरण, डेटा सुरक्षा, सुरक्षित उपकरण सञ्चालन, र डेटा गोपनीयता नियमहरूको पालना कभर गर्नेछौं।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- MCP सर्भरहरूको लागि सुरक्षित प्रमाणीकरण र प्राधिकरण मेकानिजमहरू लागू गर्न।
- संवेदनशील डेटा इन्क्रिप्शन र सुरक्षित भण्डारण प्रयोग गरी संरक्षण गर्न।
- उचित पहुँच नियन्त्रणसँग उपकरणहरूको सुरक्षित सञ्चालन सुनिश्चित गर्न।
- डेटा सुरक्षा र गोपनीयता नियमहरूको पालना गर्ने उत्तम अभ्यासहरू लागू गर्न।

## प्रमाणीकरण र प्राधिकरण

प्रमाणीकरण र प्राधिकरण MCP सर्भरहरूलाई सुरक्षित राख्न अत्यावश्यक छन्। प्रमाणीकरणले "तपाईं को हुनुहुन्छ?" भन्ने प्रश्नको उत्तर दिन्छ भने प्राधिकरणले "तपाईं के गर्न सक्नुहुन्छ?" भन्ने प्रश्नको उत्तर दिन्छ।

अब हामी .NET र Java प्रयोग गरी MCP सर्भरहरूमा कसरी सुरक्षित प्रमाणीकरण र प्राधिकरण लागू गर्ने उदाहरणहरू हेरौं।

### .NET Identity एकीकरण

ASP .NET Core Identity ले प्रयोगकर्ता प्रमाणीकरण र प्राधिकरण व्यवस्थापनका लागि एक बलियो फ्रेमवर्क प्रदान गर्दछ। हामी यसलाई MCP सर्भरहरूसँग एकीकृत गरी उपकरण र स्रोतहरूमा पहुँच सुरक्षित गर्न सक्छौं।

ASP.NET Core Identity लाई MCP सर्भरहरूसँग एकीकृत गर्दा हामीले बुझ्नुपर्ने मुख्य अवधारणाहरू यस्ता छन्:

- **Identity Configuration**: प्रयोगकर्ता भूमिकाहरू र दाबीहरू सहित ASP.NET Core Identity सेटअप गर्ने। दाबी भनेको प्रयोगकर्ताको बारेमा जानकारीको एक टुक्रा हो, जस्तै उनीहरूको भूमिका वा अनुमति, जस्तै "Admin" वा "User"।
- **JWT Authentication**: सुरक्षित API पहुँचका लागि JSON Web Tokens (JWT) प्रयोग गर्ने। JWT एक मानक हो जसले JSON वस्तुको रूपमा पक्षहरूबीच सुरक्षित रूपमा जानकारी सञ्‍चार गर्न अनुमति दिन्छ, जुन डिजिटल रूपमा हस्ताक्षर गरिएको भएकाले प्रमाणित र विश्वसनीय हुन्छ।
- **Authorization Policies**: प्रयोगकर्ता भूमिकाहरूको आधारमा विशेष उपकरणहरूमा पहुँच नियन्त्रण गर्न नीतिहरू परिभाषित गर्ने। MCP ले भूमिका र दाबीहरूको आधारमा कुन प्रयोगकर्ताले कुन उपकरण पहुँच गर्न सक्छ भनेर निर्धारण गर्न प्राधिकरण नीतिहरू प्रयोग गर्छ।

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
- सुरक्षित API पहुँचका लागि JWT प्रमाणीकरण सेटअप गरेका छौं। हामीले टोकन मान्यकरण प्यारामिटरहरू निर्दिष्ट गरेका छौं, जसमा issuer, audience, र signing key समावेश छन्।
- प्रयोगकर्ता भूमिकाहरूको आधारमा उपकरण पहुँच नियन्त्रण गर्न प्राधिकरण नीतिहरू परिभाषित गरेका छौं। उदाहरणका लागि, "CanUseAdminTools" नीति प्रयोगकर्ताले "Admin" भूमिका राख्न आवश्यक छ भने, "CanUseBasic" नीति प्रयोगकर्ताले प्रमाणीकरण गरिएको हुनुपर्छ।
- MCP उपकरणहरूलाई विशिष्ट प्राधिकरण आवश्यकताहरू सहित दर्ता गरेका छौं, जसले सुनिश्चित गर्छ कि केवल उपयुक्त भूमिकाका प्रयोगकर्ताहरूले मात्र ती उपकरणहरू पहुँच गर्न सक्छन्।

### Java Spring Security एकीकरण

Java का लागि, हामी MCP सर्भरहरूको लागि सुरक्षित प्रमाणीकरण र प्राधिकरण कार्यान्वयन गर्न Spring Security प्रयोग गर्नेछौं। Spring Security ले Spring अनुप्रयोगहरूसँग सहज रूपमा एकीकृत हुने व्यापक सुरक्षा फ्रेमवर्क प्रदान गर्दछ।

यहाँ मुख्य अवधारणाहरू:

- **Spring Security Configuration**: प्रमाणीकरण र प्राधिकरणका लागि सुरक्षा कन्फिगरेसन सेटअप गर्ने।
- **OAuth2 Resource Server**: MCP उपकरणहरूको सुरक्षित पहुँचका लागि OAuth2 प्रयोग गर्ने। OAuth2 एक प्राधिकरण फ्रेमवर्क हो जसले तेस्रो पक्ष सेवाहरूलाई सुरक्षित API पहुँचका लागि एक्सेस टोकनहरू आदानप्रदान गर्न अनुमति दिन्छ।
- **Security Interceptors**: उपकरण सञ्चालनमा पहुँच नियन्त्रण लागू गर्न सुरक्षा इन्टरसेप्टरहरू कार्यान्वयन गर्ने।
- **Role-Based Access Control**: विशिष्ट उपकरण र स्रोतहरूमा पहुँच नियन्त्रण गर्न भूमिकाहरू प्रयोग गर्ने।
- **Security Annotations**: मेथडहरू र अन्तबिन्दुहरूलाई सुरक्षित गर्न एनोटेसनहरू प्रयोग गर्ने।

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

- MCP अन्तबिन्दुहरूलाई सुरक्षित गर्न Spring Security कन्फिगर गरेका छौं, उपकरण खोजका लागि सार्वजनिक पहुँच अनुमति दिँदै उपकरण सञ्चालनका लागि प्रमाणीकरण आवश्यक पार्ने।
- MCP उपकरणहरूको सुरक्षित पहुँचका लागि OAuth2 लाई रिसोर्स सर्भरको रूपमा प्रयोग गरेका छौं।
- उपकरण सञ्चालनमा पहुँच नियन्त्रण लागू गर्न सुरक्षा इन्टरसेप्टर कार्यान्वयन गरेका छौं, जसले विशिष्ट उपकरणहरूमा पहुँच अनुमति दिनुअघि प्रयोगकर्ताका भूमिका र अनुमति जाँच्छ।
- प्रशासन उपकरणहरू र संवेदनशील डेटा पहुँचलाई प्रयोगकर्ता भूमिकाहरूको आधारमा सीमित गर्न भूमिका-आधारित पहुँच नियन्त्रण परिभाषित गरेका छौं।

## डेटा सुरक्षा र गोपनीयता

डेटा सुरक्षा संवेदनशील जानकारीलाई सुरक्षित रूपमा व्यवस्थापन गर्न अत्यन्त आवश्यक छ। यसमा व्यक्तिगत पहिचानयोग्य जानकारी (PII), वित्तीय डेटा, र अन्य संवेदनशील जानकारीलाई अनधिकृत पहुँच र भंगबाट संरक्षण गर्ने समावेश छ।

### Python डेटा सुरक्षा उदाहरण

इन्क्रिप्शन र PII पत्ता लगाउने प्रयोग गरी Python मा डेटा सुरक्षा कसरी लागू गर्ने उदाहरण हेरौं।

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

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` कार्यान्वयन गरेका छौं जसले संवेदनशील डेटा सुरक्षित रूपमा ह्यान्डल गर्छ।

## अब के गर्ने

- [5.9 Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा असत्यता हुन सक्छ। मूल दस्तावेजलाई यसको मूल भाषामा आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।