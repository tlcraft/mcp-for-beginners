<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T23:18:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "bn"
}
-->
# Security Best Practices

MCP ইমপ্লিমেন্টেশনের জন্য নিরাপত্তা অত্যন্ত গুরুত্বপূর্ণ, বিশেষ করে এন্টারপ্রাইজ পরিবেশে। টুল এবং ডেটা অননুমোদিত প্রবেশ, ডেটা লঙ্ঘন এবং অন্যান্য নিরাপত্তা হুমকি থেকে সুরক্ষিত রাখা জরুরি।

## Introduction

এই পাঠে আমরা MCP ইমপ্লিমেন্টেশনের জন্য নিরাপত্তার সেরা অনুশীলনগুলো আলোচনা করব। আমরা প্রমাণীকরণ এবং অনুমোদন, ডেটা সুরক্ষা, নিরাপদ টুল কার্যকরী এবং ডেটা গোপনীয়তা নিয়মাবলীর সাথে সামঞ্জস্য কিভাবে নিশ্চিত করবেন তা দেখব।

## Learning Objectives

এই পাঠ শেষে, আপনি সক্ষম হবেন:

- MCP সার্ভারের জন্য নিরাপদ প্রমাণীকরণ এবং অনুমোদন পদ্ধতি বাস্তবায়ন করতে।
- এনক্রিপশন এবং নিরাপদ সংরক্ষণ ব্যবহার করে সংবেদনশীল ডেটা সুরক্ষিত রাখতে।
- সঠিক প্রবেশ নিয়ন্ত্রণের মাধ্যমে টুলগুলোর নিরাপদ কার্যকরী নিশ্চিত করতে।
- ডেটা সুরক্ষা এবং গোপনীয়তা সম্মতির জন্য সেরা অনুশীলন প্রয়োগ করতে।

## Authentication and Authorization

প্রমাণীকরণ এবং অনুমোদন MCP সার্ভার নিরাপদ করার জন্য অপরিহার্য। প্রমাণীকরণ প্রশ্ন করে "আপনি কে?" আর অনুমোদন প্রশ্ন করে "আপনি কি করতে পারবেন?".

চলুন দেখি .NET এবং Java ব্যবহার করে MCP সার্ভারে কিভাবে নিরাপদ প্রমাণীকরণ এবং অনুমোদন বাস্তবায়ন করা যায় তার উদাহরণ।

### .NET Identity Integration

ASP .NET Core Identity ব্যবহারকারীর প্রমাণীকরণ এবং অনুমোদন ব্যবস্থাপনার জন্য একটি শক্তিশালী ফ্রেমওয়ার্ক প্রদান করে। আমরা এটিকে MCP সার্ভারের সাথে সংযুক্ত করে টুল এবং রিসোর্সের অ্যাক্সেস সুরক্ষিত করতে পারি।

ASP.NET Core Identity MCP সার্ভারের সাথে সংযুক্ত করার সময় আমাদের কিছু মূল ধারণা বুঝতে হবে, যেমন:

- **Identity Configuration**: ASP.NET Core Identity সেটআপ করা ব্যবহারকারীর ভূমিকা এবং দাবিসহ। একটি দাবি হলো ব্যবহারকারীর সম্পর্কে তথ্যের একটি অংশ, যেমন তাদের ভূমিকা বা অনুমতি, যেমন "Admin" বা "User"।
- **JWT Authentication**: নিরাপদ API অ্যাক্সেসের জন্য JSON Web Tokens (JWT) ব্যবহার। JWT হলো একটি স্ট্যান্ডার্ড যা পক্ষগুলোর মধ্যে JSON অবজেক্ট হিসেবে তথ্য নিরাপদে প্রেরণ করে, যা ডিজিটালি সাইন করা থাকায় যাচাইযোগ্য এবং বিশ্বাসযোগ্য।
- **Authorization Policies**: ব্যবহারকারীর ভূমিকা অনুযায়ী নির্দিষ্ট টুলে প্রবেশ নিয়ন্ত্রণ করার জন্য নীতি নির্ধারণ। MCP ভূমিকা এবং দাবি অনুযায়ী কোন ব্যবহারকারী কোন টুলে প্রবেশ করতে পারবে তা নির্ধারণ করতে অনুমোদন নীতি ব্যবহার করে।

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
- নিরাপদ API অ্যাক্সেসের জন্য JWT প্রমাণীকরণ সেটআপ করেছি। টোকেন যাচাই প্যারামিটার যেমন ইস্যুয়ার, শ্রোতা এবং সাইনিং কী নির্দিষ্ট করেছি।
- ব্যবহারকারীর ভূমিকা অনুযায়ী টুল অ্যাক্সেস নিয়ন্ত্রণ করার জন্য অনুমোদন নীতি সংজ্ঞায়িত করেছি। উদাহরণস্বরূপ, "CanUseAdminTools" নীতিটি ব্যবহারকারীর "Admin" ভূমিকা থাকা আবশ্যক করে, আর "CanUseBasic" নীতিটি ব্যবহারকারীকে প্রমাণীকৃত হতে হবে বলে নির্ধারণ করে।
- নির্দিষ্ট অনুমোদন প্রয়োজনীয়তা সহ MCP টুল নিবন্ধন করেছি, নিশ্চিত করে যে শুধুমাত্র সঠিক ভূমিকা সম্পন্ন ব্যবহারকারীরাই সেগুলো ব্যবহার করতে পারবে।

### Java Spring Security Integration

Java এর জন্য, আমরা MCP সার্ভারের নিরাপদ প্রমাণীকরণ এবং অনুমোদনের জন্য Spring Security ব্যবহার করব। Spring Security একটি বিস্তৃত নিরাপত্তা ফ্রেমওয়ার্ক প্রদান করে যা Spring অ্যাপ্লিকেশনের সাথে মসৃণভাবে একত্রিত হয়।

এখানে মূল ধারণাগুলো হলো:

- **Spring Security Configuration**: প্রমাণীকরণ এবং অনুমোদনের জন্য নিরাপত্তা কনফিগারেশন সেটআপ।
- **OAuth2 Resource Server**: MCP টুলের নিরাপদ অ্যাক্সেসের জন্য OAuth2 ব্যবহার। OAuth2 একটি অনুমোদন ফ্রেমওয়ার্ক যা তৃতীয় পক্ষের সেবাগুলোকে নিরাপদ API অ্যাক্সেসের জন্য অ্যাক্সেস টোকেন বিনিময় করতে দেয়।
- **Security Interceptors**: টুল কার্যকরীর সময় প্রবেশ নিয়ন্ত্রণ জোরদার করার জন্য নিরাপত্তা ইন্টারসেপ্টর বাস্তবায়ন।
- **Role-Based Access Control**: নির্দিষ্ট টুল এবং রিসোর্সে প্রবেশ নিয়ন্ত্রণে ভূমিকা ব্যবহার।
- **Security Annotations**: মেথড এবং এন্ডপয়েন্ট সুরক্ষিত করার জন্য অ্যানোটেশন ব্যবহার।

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

- MCP এন্ডপয়েন্ট সুরক্ষিত করতে Spring Security কনফিগার করেছি, টুল আবিষ্কারের জন্য পাবলিক অ্যাক্সেস দেওয়া হয়েছে, তবে টুল কার্যকরীর জন্য প্রমাণীকরণ বাধ্যতামূলক।
- MCP টুলের নিরাপদ অ্যাক্সেসের জন্য OAuth2 রিসোর্স সার্ভার হিসেবে ব্যবহার করেছি।
- টুল কার্যকরীর সময় প্রবেশ নিয়ন্ত্রণ নিশ্চিত করতে নিরাপত্তা ইন্টারসেপ্টর বাস্তবায়ন করেছি, ব্যবহারকারীর ভূমিকা এবং অনুমতি যাচাই করে নির্দিষ্ট টুলে প্রবেশের অনুমতি দেয়ার আগে।
- ব্যবহারকারীর ভূমিকা অনুযায়ী অ্যাডমিন টুল এবং সংবেদনশীল ডেটা অ্যাক্সেস সীমাবদ্ধ করতে ভূমিকা-ভিত্তিক প্রবেশ নিয়ন্ত্রণ সংজ্ঞায়িত করেছি।

## Data Protection and Privacy

ডেটা সুরক্ষা অত্যন্ত জরুরি যাতে সংবেদনশীল তথ্য নিরাপদে পরিচালিত হয়। এর মধ্যে ব্যক্তিগত সনাক্তযোগ্য তথ্য (PII), আর্থিক ডেটা এবং অন্যান্য সংবেদনশীল তথ্য অননুমোদিত প্রবেশ এবং লঙ্ঘন থেকে রক্ষা করা অন্তর্ভুক্ত।

### Python Data Protection Example

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

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` বাস্তবায়ন করেছি যাতে এটি সংবেদনশীল ডেটা নিরাপদে পরিচালনা করে।

## What's next

- [5.9 Web search](../web-search-mcp/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতা নিশ্চিত করার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায় কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।