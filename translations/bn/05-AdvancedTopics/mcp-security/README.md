<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:37:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "bn"
}
-->
# সিকিউরিটি সেরা অনুশীলনসমূহ

সিকিউরিটি MCP বাস্তবায়নের জন্য অত্যন্ত গুরুত্বপূর্ণ, বিশেষ করে এন্টারপ্রাইজ পরিবেশে। এটি নিশ্চিত করা জরুরি যে টুল এবং ডেটা অননুমোদিত প্রবেশ, ডেটা লঙ্ঘন এবং অন্যান্য সিকিউরিটি হুমকি থেকে সুরক্ষিত রয়েছে।

## পরিচিতি

এই পাঠে, আমরা MCP বাস্তবায়নের জন্য সিকিউরিটির সেরা অনুশীলনসমূহ অন্বেষণ করব। আমরা প্রমাণীকরণ এবং অনুমোদন, ডেটা সুরক্ষা, নিরাপদ টুল কার্যকরী এবং ডেটা গোপনীয়তা নিয়মাবলীর সাথে সম্মতি সম্পর্কে আলোচনা করব।

## শেখার উদ্দেশ্যসমূহ

এই পাঠের শেষে, আপনি সক্ষম হবেন:

- MCP সার্ভারের জন্য নিরাপদ প্রমাণীকরণ এবং অনুমোদন প্রক্রিয়া বাস্তবায়ন করতে।
- এনক্রিপশন এবং নিরাপদ সংরক্ষণ ব্যবহার করে সংবেদনশীল ডেটা সুরক্ষিত রাখতে।
- সঠিক প্রবেশ নিয়ন্ত্রণের মাধ্যমে টুলের নিরাপদ কার্যকরী নিশ্চিত করতে।
- ডেটা সুরক্ষা এবং গোপনীয়তা সম্মতির জন্য সেরা অনুশীলন প্রয়োগ করতে।

## প্রমাণীকরণ এবং অনুমোদন

প্রমাণীকরণ এবং অনুমোদন MCP সার্ভার সুরক্ষার জন্য অপরিহার্য। প্রমাণীকরণ প্রশ্নের উত্তর দেয় "আপনি কে?" আর অনুমোদন প্রশ্নের উত্তর দেয় "আপনি কী করতে পারেন?".

চলুন দেখি কিভাবে .NET এবং Java ব্যবহার করে MCP সার্ভারে নিরাপদ প্রমাণীকরণ এবং অনুমোদন বাস্তবায়ন করা যায়।

### .NET Identity ইন্টিগ্রেশন

ASP .NET Core Identity ব্যবহারকারীর প্রমাণীকরণ এবং অনুমোদন পরিচালনার জন্য একটি শক্তিশালী ফ্রেমওয়ার্ক প্রদান করে। আমরা এটি MCP সার্ভারের সাথে সংযুক্ত করে টুল এবং রিসোর্সে প্রবেশ সুরক্ষিত করতে পারি।

ASP.NET Core Identity MCP সার্ভারের সাথে সংযুক্ত করার সময় আমাদের কিছু মূল ধারণা বুঝতে হবে, যেমন:

- **Identity কনফিগারেশন**: ব্যবহারকারীর ভূমিকা এবং দাবিসহ ASP.NET Core Identity সেটআপ করা। একটি দাবি হলো ব্যবহারকারীর সম্পর্কে একটি তথ্য, যেমন তাদের ভূমিকা বা অনুমতি, উদাহরণস্বরূপ "Admin" বা "User"।
- **JWT Authentication**: নিরাপদ API প্রবেশের জন্য JSON Web Tokens (JWT) ব্যবহার। JWT হলো একটি স্ট্যান্ডার্ড যা পক্ষগুলোর মধ্যে তথ্য নিরাপদে JSON অবজেক্ট হিসেবে প্রেরণ করে, যা ডিজিটালি স্বাক্ষরিত হওয়ায় যাচাইযোগ্য এবং বিশ্বাসযোগ্য।
- **Authorization Policies**: ব্যবহারকারীর ভূমিকার ভিত্তিতে নির্দিষ্ট টুলে প্রবেশ নিয়ন্ত্রণের জন্য নীতিমালা নির্ধারণ। MCP ব্যবহারকারীর ভূমিকা এবং দাবির ভিত্তিতে কোন ব্যবহারকারী কোন টুল ব্যবহার করতে পারবে তা নির্ধারণ করতে অনুমোদন নীতিমালা ব্যবহার করে।

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

উপরের কোডে, আমরা:

- ব্যবহারকারী ব্যবস্থাপনার জন্য ASP.NET Core Identity কনফিগার করেছি।
- নিরাপদ API প্রবেশের জন্য JWT প্রমাণীকরণ সেটআপ করেছি। টোকেন যাচাইয়ের প্যারামিটার যেমন ইস্যুয়ার, দর্শক এবং সাইনিং কী নির্ধারণ করেছি।
- ব্যবহারকারীর ভূমিকার ভিত্তিতে টুলে প্রবেশ নিয়ন্ত্রণের জন্য অনুমোদন নীতিমালা নির্ধারণ করেছি। উদাহরণস্বরূপ, "CanUseAdminTools" নীতিতে ব্যবহারকারীর "Admin" ভূমিকা থাকা আবশ্যক, আর "CanUseBasic" নীতিতে ব্যবহারকারীকে প্রমাণীকৃত হতে হবে।
- MCP টুলগুলো নির্দিষ্ট অনুমোদন শর্তসহ নিবন্ধন করেছি, যাতে শুধুমাত্র উপযুক্ত ভূমিকা সম্পন্ন ব্যবহারকারীরাই সেগুলো ব্যবহার করতে পারে।

### Java Spring Security ইন্টিগ্রেশন

Java এর জন্য, আমরা MCP সার্ভারের নিরাপদ প্রমাণীকরণ এবং অনুমোদনের জন্য Spring Security ব্যবহার করব। Spring Security একটি ব্যাপক সিকিউরিটি ফ্রেমওয়ার্ক যা Spring অ্যাপ্লিকেশনের সাথে নির্বিঘ্নে সংযুক্ত হয়।

এখানে মূল ধারণাগুলো হলো:

- **Spring Security কনফিগারেশন**: প্রমাণীকরণ এবং অনুমোদনের জন্য সিকিউরিটি কনফিগারেশন সেটআপ।
- **OAuth2 Resource Server**: MCP টুলে নিরাপদ প্রবেশের জন্য OAuth2 ব্যবহার। OAuth2 হলো একটি অনুমোদন ফ্রেমওয়ার্ক যা তৃতীয় পক্ষের সেবাগুলোকে নিরাপদ API প্রবেশের জন্য অ্যাক্সেস টোকেন বিনিময় করতে দেয়।
- **Security Interceptors**: টুল কার্যকরীতে প্রবেশ নিয়ন্ত্রণ প্রয়োগের জন্য সিকিউরিটি ইন্টারসেপ্টর বাস্তবায়ন।
- **Role-Based Access Control**: নির্দিষ্ট টুল এবং রিসোর্সে প্রবেশ নিয়ন্ত্রণের জন্য ভূমিকা ব্যবহার।
- **Security Annotations**: মেথড এবং এন্ডপয়েন্ট সুরক্ষিত করতে অ্যানোটেশন ব্যবহার।

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

উপরের কোডে, আমরা:

- MCP এন্ডপয়েন্ট সুরক্ষিত করতে Spring Security কনফিগার করেছি, টুল আবিষ্কারের জন্য পাবলিক প্রবেশাধিকার রেখে টুল কার্যকরীর জন্য প্রমাণীকরণ বাধ্যতামূলক করেছি।
- MCP টুলে নিরাপদ প্রবেশের জন্য OAuth2 রিসোর্স সার্ভার হিসেবে ব্যবহার করেছি।
- টুল কার্যকরীতে প্রবেশ নিয়ন্ত্রণ প্রয়োগের জন্য সিকিউরিটি ইন্টারসেপ্টর বাস্তবায়ন করেছি, ব্যবহারকারীর ভূমিকা এবং অনুমতি যাচাই করে নির্দিষ্ট টুলে প্রবেশের অনুমতি দিই।
- ব্যবহারকারীর ভূমিকার ভিত্তিতে অ্যাডমিন টুল এবং সংবেদনশীল ডেটা প্রবেশ সীমাবদ্ধ করতে ভূমিকা-ভিত্তিক প্রবেশ নিয়ন্ত্রণ নির্ধারণ করেছি।

## ডেটা সুরক্ষা এবং গোপনীয়তা

ডেটা সুরক্ষা অত্যন্ত গুরুত্বপূর্ণ যাতে সংবেদনশীল তথ্য নিরাপদে পরিচালিত হয়। এর মধ্যে ব্যক্তিগত সনাক্তযোগ্য তথ্য (PII), আর্থিক তথ্য এবং অন্যান্য সংবেদনশীল তথ্য অননুমোদিত প্রবেশ এবং লঙ্ঘন থেকে সুরক্ষিত রাখা অন্তর্ভুক্ত।

### Python ডেটা সুরক্ষা উদাহরণ

চলুন দেখি কিভাবে Python এ এনক্রিপশন এবং PII সনাক্তকরণ ব্যবহার করে ডেটা সুরক্ষা বাস্তবায়ন করা যায়।

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

উপরের কোডে, আমরা:

- `PiiDetector` ক্লাস বাস্তবায়ন করেছি যা টেক্সট এবং প্যারামিটারগুলোতে ব্যক্তিগত সনাক্তযোগ্য তথ্য (PII) স্ক্যান করে।
- `EncryptionService` ক্লাস তৈরি করেছি যা `cryptography` লাইব্রেরি ব্যবহার করে সংবেদনশীল ডেটার এনক্রিপশন এবং ডিক্রিপশন পরিচালনা করে।
- `secure_tool` ডেকোরেটর সংজ্ঞায়িত করেছি যা টুল কার্যকরীকে ঘিরে রাখে, PII পরীক্ষা করে, প্রবেশ লগ করে এবং প্রয়োজনে সংবেদনশীল ডেটা এনক্রিপ্ট করে।
- একটি নমুনা টুল (`SecureCustomerDataTool`) এ `secure_tool` ডেকোরেটর প্রয়োগ করেছি যাতে এটি সংবেদনশীল ডেটা নিরাপদে পরিচালনা করে।

## পরবর্তী ধাপ

- [5.9 Web search](../web-search-mcp/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।