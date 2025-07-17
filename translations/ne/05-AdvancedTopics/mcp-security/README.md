<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T00:35:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ne"
}
-->
# सुरक्षा उत्तम अभ्यासहरू

सुरक्षा MCP कार्यान्वयनहरूका लागि अत्यन्त महत्वपूर्ण छ, विशेष गरी उद्यम वातावरणहरूमा। उपकरणहरू र डाटालाई अनधिकृत पहुँच, डाटा चुहावट, र अन्य सुरक्षा खतराहरूबाट सुरक्षित राख्नु आवश्यक छ।

## परिचय

Model Context Protocol (MCP) ले LLMs लाई डाटा र उपकरणहरूमा पहुँच प्रदान गर्ने भूमिकाका कारण विशेष सुरक्षा विचारहरू आवश्यक पर्छ। यो पाठले आधिकारिक MCP दिशानिर्देशहरू र स्थापित सुरक्षा ढाँचाहरूमा आधारित MCP कार्यान्वयनहरूको लागि सुरक्षा उत्तम अभ्यासहरू अन्वेषण गर्दछ।

MCP ले सुरक्षित र भरपर्दो अन्तरक्रियाहरू सुनिश्चित गर्न मुख्य सुरक्षा सिद्धान्तहरू पालना गर्दछ:

- **प्रयोगकर्ता सहमति र नियन्त्रण**: कुनै पनि डाटा पहुँच गर्नु वा अपरेसनहरू सञ्चालन गर्नु अघि प्रयोगकर्ताबाट स्पष्ट सहमति लिनुपर्छ। कुन डाटा साझा गरिने र कुन कार्यहरू अधिकृत छन् भन्ने स्पष्ट नियन्त्रण प्रदान गर्नुहोस्।
  
- **डाटा गोपनीयता**: प्रयोगकर्ताको डाटा केवल स्पष्ट सहमतिसँग मात्र खुलासा गरिनुपर्छ र उपयुक्त पहुँच नियन्त्रणहरूले सुरक्षित हुनुपर्छ। अनधिकृत डाटा प्रसारणबाट सुरक्षा गर्नुहोस्।
  
- **उपकरण सुरक्षा**: कुनै पनि उपकरण कल गर्नु अघि स्पष्ट प्रयोगकर्ता सहमति आवश्यक छ। प्रयोगकर्ताले प्रत्येक उपकरणको कार्यक्षमता स्पष्ट रूपमा बुझ्नुपर्छ र कडा सुरक्षा सीमाहरू लागू गर्नुपर्छ।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- MCP सर्भरहरूको लागि सुरक्षित प्रमाणीकरण र प्राधिकरण संयन्त्रहरू कार्यान्वयन गर्न।
- संवेदनशील डाटालाई इन्क्रिप्शन र सुरक्षित भण्डारण प्रयोग गरेर सुरक्षा गर्न।
- उचित पहुँच नियन्त्रणहरूसँग उपकरणहरूको सुरक्षित कार्यान्वयन सुनिश्चित गर्न।
- डाटा सुरक्षा र गोपनीयता अनुपालनका लागि उत्तम अभ्यासहरू लागू गर्न।
- confused deputy समस्या, token passthrough, र session hijacking जस्ता सामान्य MCP सुरक्षा जोखिमहरू पहिचान र न्यूनीकरण गर्न।

## प्रमाणीकरण र प्राधिकरण

प्रमाणीकरण र प्राधिकरण MCP सर्भरहरूलाई सुरक्षित बनाउन आवश्यक छन्। प्रमाणीकरणले "तपाईं को हुनुहुन्छ?" भन्ने प्रश्नको उत्तर दिन्छ भने प्राधिकरणले "तपाईं के गर्न सक्नुहुन्छ?" भन्ने प्रश्नको उत्तर दिन्छ।

MCP सुरक्षा विशिष्टता अनुसार, यी महत्वपूर्ण सुरक्षा विचारहरू हुन्:

1. **टोकन प्रमाणीकरण**: MCP सर्भरहरूले त्यस्ता कुनै पनि टोकन स्वीकार गर्नु हुँदैन जुन स्पष्ट रूपमा MCP सर्भरका लागि जारी गरिएको छैन। "Token passthrough" एक स्पष्ट रूपमा निषेध गरिएको एन्टी-प्याटर्न हो।

2. **प्राधिकरण प्रमाणीकरण**: प्राधिकरण कार्यान्वयन गर्ने MCP सर्भरहरूले सबै इनबाउन्ड अनुरोधहरू प्रमाणीकरण गर्नुपर्छ र प्रमाणीकरणका लागि सेसनहरू प्रयोग गर्नु हुँदैन।

3. **सुरक्षित सेसन व्यवस्थापन**: अवस्था राख्न सेसनहरू प्रयोग गर्दा, MCP सर्भरहरूले सुरक्षित, गैर-निर्धारित सेसन ID हरू प्रयोग गर्नुपर्छ जुन सुरक्षित र्यान्डम नम्बर जेनेरेटरबाट उत्पन्न हुन्छ। सेसन ID हरू प्रयोगकर्ता-विशिष्ट जानकारीसँग बाँधिनुपर्छ।

4. **स्पष्ट प्रयोगकर्ता सहमति**: प्रोक्सी सर्भरहरूको लागि, MCP कार्यान्वयनहरूले प्रत्येक गतिशील रूपमा दर्ता गरिएको क्लाइन्टको लागि प्रयोगकर्ताबाट सहमति लिनुपर्छ, त्यसपछि मात्र तेस्रो-पक्ष प्राधिकरण सर्भरहरूमा अग्रेषण गर्नुपर्छ।

अब .NET र Java प्रयोग गरेर MCP सर्भरहरूमा कसरी सुरक्षित प्रमाणीकरण र प्राधिकरण कार्यान्वयन गर्ने उदाहरणहरू हेरौं।

### .NET Identity एकीकरण

ASP .NET Core Identity ले प्रयोगकर्ता प्रमाणीकरण र प्राधिकरण व्यवस्थापनका लागि बलियो फ्रेमवर्क प्रदान गर्दछ। हामी यसलाई MCP सर्भरहरूसँग एकीकृत गरेर उपकरण र स्रोतहरूमा पहुँच सुरक्षित गर्न सक्छौं।

ASP.NET Core Identity लाई MCP सर्भरहरूसँग एकीकृत गर्दा बुझ्नुपर्ने केही मुख्य अवधारणाहरू छन्:

- **Identity कन्फिगरेसन**: प्रयोगकर्ता भूमिका र दाबीहरूसँग ASP.NET Core Identity सेटअप गर्नु। दाबी भनेको प्रयोगकर्ताको बारेमा जानकारीको टुक्रा हो, जस्तै तिनीहरूको भूमिका वा अनुमति, उदाहरणका लागि "Admin" वा "User"।
- **JWT प्रमाणीकरण**: सुरक्षित API पहुँचका लागि JSON Web Tokens (JWT) प्रयोग गर्नु। JWT एक मानक हो जसले पक्षहरूबीच JSON वस्तुको रूपमा जानकारी सुरक्षित रूपमा प्रसारण गर्न अनुमति दिन्छ, जुन डिजिटल रूपमा हस्ताक्षरित भएकाले प्रमाणित र भरोसायोग्य हुन्छ।
- **प्राधिकरण नीतिहरू**: प्रयोगकर्ता भूमिकाहरूको आधारमा विशिष्ट उपकरणहरूमा पहुँच नियन्त्रण गर्न नीतिहरू परिभाषित गर्नु। MCP ले प्राधिकरण नीतिहरू प्रयोग गर्दछ जसले कुन प्रयोगकर्ताले कुन उपकरणहरू प्रयोग गर्न सक्छन् भन्ने निर्धारण गर्छ।

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
- सुरक्षित API पहुँचका लागि JWT प्रमाणीकरण सेटअप गरेका छौं। हामीले टोकन प्रमाणीकरण प्यारामिटरहरू निर्दिष्ट गरेका छौं, जस्तै जारीकर्ता, दर्शक, र हस्ताक्षर कुञ्जी।
- प्रयोगकर्ता भूमिकाहरूको आधारमा उपकरणहरूमा पहुँच नियन्त्रण गर्न प्राधिकरण नीतिहरू परिभाषित गरेका छौं। उदाहरणका लागि, "CanUseAdminTools" नीति प्रयोगकर्ताले "Admin" भूमिका हुनुपर्नेछ भने "CanUseBasic" नीतिले प्रयोगकर्ताले प्रमाणीकरण गरिएको हुनुपर्नेछ।
- MCP उपकरणहरूलाई विशिष्ट प्राधिकरण आवश्यकतासहित दर्ता गरेका छौं, जसले सुनिश्चित गर्छ कि मात्र उपयुक्त भूमिकाका प्रयोगकर्ताहरूले तिनीहरूमा पहुँच पाउन सक्छन्।

### Java Spring Security एकीकरण

Java का लागि, हामी Spring Security प्रयोग गरेर MCP सर्भरहरूको लागि सुरक्षित प्रमाणीकरण र प्राधिकरण कार्यान्वयन गर्नेछौं। Spring Security ले Spring अनुप्रयोगहरूसँग सहज रूपमा एकीकृत हुने व्यापक सुरक्षा फ्रेमवर्क प्रदान गर्दछ।

यहाँका मुख्य अवधारणाहरू हुन्:

- **Spring Security कन्फिगरेसन**: प्रमाणीकरण र प्राधिकरणका लागि सुरक्षा कन्फिगरेसन सेटअप गर्नु।
- **OAuth2 Resource Server**: MCP उपकरणहरूमा सुरक्षित पहुँचका लागि OAuth2 प्रयोग गर्नु। OAuth2 एक प्राधिकरण फ्रेमवर्क हो जसले तेस्रो-पक्ष सेवाहरूलाई सुरक्षित API पहुँचका लागि पहुँच टोकनहरू आदानप्रदान गर्न अनुमति दिन्छ।
- **सुरक्षा इन्टरसेप्टरहरू**: उपकरण कार्यान्वयनमा पहुँच नियन्त्रण लागू गर्न सुरक्षा इन्टरसेप्टरहरू कार्यान्वयन गर्नु।
- **भूमिका-आधारित पहुँच नियन्त्रण**: विशिष्ट उपकरण र स्रोतहरूमा पहुँच नियन्त्रण गर्न भूमिकाहरू प्रयोग गर्नु।
- **सुरक्षा एनोटेसनहरू**: विधिहरू र अन्तबिन्दुहरूलाई सुरक्षित गर्न एनोटेसनहरू प्रयोग गर्नु।

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

- MCP अन्तबिन्दुहरूलाई सुरक्षित गर्न Spring Security कन्फिगर गरेका छौं, उपकरण पत्ता लगाउन सार्वजनिक पहुँच अनुमति दिँदै उपकरण कार्यान्वयनका लागि प्रमाणीकरण आवश्यक बनाएका छौं।
- MCP उपकरणहरूमा सुरक्षित पहुँचका लागि OAuth2 लाई स्रोत सर्भरको रूपमा प्रयोग गरेका छौं।
- उपकरण कार्यान्वयनमा पहुँच नियन्त्रण लागू गर्न सुरक्षा इन्टरसेप्टर कार्यान्वयन गरेका छौं, जसले विशिष्ट उपकरणहरूमा पहुँच दिनुअघि प्रयोगकर्ता भूमिका र अनुमति जाँच गर्छ।
- प्रयोगकर्ता भूमिकाको आधारमा प्रशासनिक उपकरण र संवेदनशील डाटा पहुँच सीमित गर्न भूमिका-आधारित पहुँच नियन्त्रण परिभाषित गरेका छौं।

## डाटा सुरक्षा र गोपनीयता

डाटा सुरक्षा संवेदनशील जानकारीलाई सुरक्षित रूपमा व्यवस्थापन गर्न अत्यावश्यक छ। यसमा व्यक्तिगत पहिचानयोग्य जानकारी (PII), वित्तीय डाटा, र अन्य संवेदनशील जानकारीलाई अनधिकृत पहुँच र चुहावटबाट सुरक्षा गर्नु पर्दछ।

### Python डाटा सुरक्षा उदाहरण

इन्क्रिप्शन र PII पत्ता लगाउने प्रयोग गरेर Python मा डाटा सुरक्षा कसरी कार्यान्वयन गर्ने उदाहरण हेरौं।

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
- `EncryptionService` क्लास बनाएका छौं जसले `cryptography` लाइब्रेरी प्रयोग गरेर संवेदनशील डाटाको इन्क्रिप्शन र डिक्रिप्शन ह्यान्डल गर्छ।
- `secure_tool` डेकोरेटर परिभाषित गरेका छौं जसले उपकरण कार्यान्वयनलाई PII जाँच, पहुँच लगिङ, र आवश्यक परे संवेदनशील डाटाको इन्क्रिप्शन गर्छ।
- नमूना उपकरण (`SecureCustomerDataTool`) मा `secure_tool` डेकोरेटर लागू गरेका छौं जसले सुनिश्चित गर्छ कि यो संवेदनशील डाटालाई सुरक्षित रूपमा ह्यान्डल गर्छ।

## MCP-विशिष्ट सुरक्षा जोखिमहरू

आधिकारिक MCP सुरक्षा दस्तावेज अनुसार, MCP कार्यान्वयनकर्ताहरूले थाहा पाउनुपर्ने विशिष्ट सुरक्षा जोखिमहरू छन्:

### 1. Confused Deputy समस्या

यो कमजोरी तब हुन्छ जब MCP सर्भर तेस्रो-पक्ष API हरूको प्रोक्सीको रूपमा काम गर्छ, जसले आक्रमणकारीहरूलाई MCP सर्भर र ती API हरूबीचको भरोसायोग्य सम्बन्धलाई दुरुपयोग गर्न अनुमति दिन सक्छ।

**निवारण:**
- MCP प्रोक्सी सर्भरहरूले स्थिर क्लाइन्ट ID हरू प्रयोग गर्दा प्रत्येक गतिशील रूपमा दर्ता गरिएको क्लाइन्टको लागि प्रयोगकर्ताबाट सहमति लिनुपर्छ, त्यसपछि मात्र तेस्रो-पक्ष प्राधिकरण सर्भरहरूमा अग्रेषण गर्नुपर्छ।
- प्राधिकरण अनुरोधहरूको लागि PKCE (Proof Key for Code Exchange) सहित उचित OAuth फ्लो कार्यान्वयन गर्नुहोस्।
- रिडिरेक्ट URI र क्लाइन्ट पहिचानकर्ताहरू कडाइका साथ प्रमाणीकरण गर्नुहोस्।

### 2. Token Passthrough जोखिमहरू

Token passthrough तब हुन्छ जब MCP सर्भरले MCP क्लाइन्टबाट टोकनहरू स्वीकार्छ तर ती टोकनहरू MCP सर्भरका लागि सही रूपमा जारी गरिएको हो कि होइन भनी प्रमाणीकरण नगरी तिनीहरूलाई डाउनस्ट्रीम API हरूमा पास गर्छ।

### जोखिमहरू
- सुरक्षा नियन्त्रणहरू छलेर (जस्तै दर सीमांकन, अनुरोध प्रमाणीकरण)।
- जवाफदेहिता र अडिट ट्रेल समस्याहरू।
- भरोसा सीमा उल्लंघन।
- भविष्यको अनुकूलता जोखिमहरू।

**निवारण:**
- MCP सर्भरहरूले त्यस्ता कुनै पनि टोकन स्वीकार गर्नु हुँदैन जुन स्पष्ट रूपमा MCP सर्भरका लागि जारी गरिएको छैन।
- सधैं टोकन दर्शक दाबीहरू प्रमाणीकरण गर्नुहोस् ताकि तिनीहरू अपेक्षित सेवासँग मेल खान्छन् भन्ने सुनिश्चित होस्।

### 3. सेसन हाइज्याकिंग

यो तब हुन्छ जब अनधिकृत पक्षले सेसन ID प्राप्त गरी मूल क्लाइन्टको नक्कल गर्छ, जसले अनधिकृत कार्यहरू गर्न सक्छ।

**निवारण:**
- प्राधिकरण कार्यान्वयन गर्ने MCP सर्भरहरूले सबै इनबाउन्ड अनुरोध प्रमाणीकरण गर्नुपर्छ र प्रमाणीकरणका लागि सेसनहरू प्रयोग गर्नु हुँदैन।
- सुरक्षित, गैर-निर्धारित सेसन ID हरू प्रयोग गर्नुहोस् जुन सुरक्षित र्यान्डम नम्बर जेनेरेटरबाट उत्पन्न हुन्छ।
- सेसन ID हरूलाई प्रयोगकर्ता-विशिष्ट जानकारीसँग बाँध्नुहोस्, जस्तै `<user_id>:<session_id>` ढाँचामा।
- उचित सेसन समाप्ति र रोटेशन नीतिहरू लागू गर्नुहोस्।

## MCP का लागि थप सुरक्षा उत्तम अभ्यासहरू

मुख्य MCP सुरक्षा विचारहरू बाहेक, यी थप सुरक्षा अभ्यासहरू कार्यान्वयन गर्न विचार गर्नुहोस्:

- **सधैं HTTPS प्रयोग गर्नुहोस्**: क्लाइन्ट र सर्भरबीच सञ्चार इन्क्रिप्ट गरेर टोकनहरूलाई अवरोधबाट जोगाउनुहोस्।
- **भूमिका-आधारित पहुँच नियन्त्रण (RBAC) लागू गर्नुहोस्**: केवल प्रयोगकर्ता प्रमाणीकरण भएको छ कि छैन जाँच नगर्नुहोस्; उनीहरूले के गर्न सक्छन् पनि जाँच गर्नुहोस्।
- **निगरानी र अडिट गर्नुहोस्**: सबै प्रमाणीकरण घटनाहरू लग गर्नुहोस् ताकि शंकास्पद गतिविधि पत्ता लगाउन र प्रतिक्रिया दिन सकियोस्।
- **दर सीमांकन र थ्रोटलिङ ह्यान्डल गर्नुहोस्**: दर सीमाहरूलाई सहज रूपमा व्यवस्थापन गर्न exponential backoff र पुन: प्रयास तर्क लागू गर्नुहोस्।
- **सुरक्षित टोकन भण्डारण गर्नुहोस्**: पहुँच टोकन र रिफ्रेश टोकनहरूलाई प्रणालीको सुरक्षित भण्डारण संयन्त्रहरू वा सुरक्षित कुञ्जी व्यवस्थापन सेवाहरू प्रयोग गरेर सुरक्षित राख्नुहोस्।
- **API व्यवस्थापन प्रयोग गर्ने विचार गर्नुहोस्**: Azure API Management जस्ता सेवाहरूले प्रमाणीकरण, प्राधिकरण, र दर सीमांकन सहित धेरै सुरक्षा चिन्ताहरू स्वचालित रूपमा ह्यान्डल गर्न सक्छन्।

## सन्दर्भहरू

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## के छ अर्को

- [5.9 Web search](../web-search-mcp/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।