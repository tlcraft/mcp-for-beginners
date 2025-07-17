<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T00:09:44+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "bn"
}
-->
# Security Best Practices

MCP বাস্তবায়নের জন্য নিরাপত্তা অত্যন্ত গুরুত্বপূর্ণ, বিশেষ করে এন্টারপ্রাইজ পরিবেশে। টুল এবং ডেটা অননুমোদিত প্রবেশ, ডেটা লঙ্ঘন এবং অন্যান্য নিরাপত্তা হুমকি থেকে সুরক্ষিত রাখা জরুরি।

## পরিচিতি

Model Context Protocol (MCP) এর নিরাপত্তা বিবেচনা বিশেষ কারণ এটি LLM-কে ডেটা এবং টুল ব্যবহারের সুযোগ দেয়। এই পাঠে অফিসিয়াল MCP নির্দেশিকা এবং প্রতিষ্ঠিত নিরাপত্তা প্যাটার্নের ভিত্তিতে MCP বাস্তবায়নের জন্য নিরাপত্তার সেরা অনুশীলনগুলি আলোচনা করা হয়েছে।

MCP নিরাপদ এবং বিশ্বাসযোগ্য ইন্টারঅ্যাকশনের জন্য মূল নিরাপত্তা নীতিমালা অনুসরণ করে:

- **ব্যবহারকারীর সম্মতি এবং নিয়ন্ত্রণ**: ডেটা অ্যাক্সেস বা অপারেশন করার আগে ব্যবহারকারীর স্পষ্ট সম্মতি প্রয়োজন। কোন ডেটা শেয়ার করা হবে এবং কোন কাজ অনুমোদিত তা স্পষ্ট নিয়ন্ত্রণ প্রদান করুন।
  
- **ডেটা গোপনীয়তা**: ব্যবহারকারীর ডেটা শুধুমাত্র স্পষ্ট সম্মতির মাধ্যমে প্রকাশ করা উচিত এবং উপযুক্ত প্রবেশ নিয়ন্ত্রণ দ্বারা সুরক্ষিত থাকতে হবে। অননুমোদিত ডেটা প্রেরণ থেকে রক্ষা করুন।
  
- **টুল নিরাপত্তা**: যেকোনো টুল কল করার আগে স্পষ্ট ব্যবহারকারীর সম্মতি আবশ্যক। ব্যবহারকারীরা প্রতিটি টুলের কার্যকারিতা সম্পর্কে পরিষ্কার ধারণা পেতে হবে এবং শক্তিশালী নিরাপত্তা সীমারেখা প্রয়োগ করতে হবে।

## শেখার উদ্দেশ্য

এই পাঠের শেষে আপনি সক্ষম হবেন:

- MCP সার্ভারের জন্য নিরাপদ প্রমাণীকরণ এবং অনুমোদন প্রক্রিয়া বাস্তবায়ন করতে।
- এনক্রিপশন এবং নিরাপদ সংরক্ষণ ব্যবহার করে সংবেদনশীল ডেটা সুরক্ষিত রাখতে।
- সঠিক প্রবেশ নিয়ন্ত্রণের মাধ্যমে টুলের নিরাপদ কার্যকরী নিশ্চিত করতে।
- ডেটা সুরক্ষা এবং গোপনীয়তা সম্মতি জন্য সেরা অনুশীলন প্রয়োগ করতে।
- সাধারণ MCP নিরাপত্তা দুর্বলতা যেমন confused deputy সমস্যা, token passthrough, এবং session hijacking সনাক্ত ও প্রতিরোধ করতে।

## Authentication and Authorization

Authentication এবং authorization MCP সার্ভার সুরক্ষার জন্য অপরিহার্য। Authentication প্রশ্ন করে "আপনি কে?" আর authorization প্রশ্ন করে "আপনি কি করতে পারেন?".

MCP নিরাপত্তা স্পেসিফিকেশনের অনুযায়ী, এগুলো গুরুত্বপূর্ণ নিরাপত্তা বিবেচনা:

1. **Token Validation**: MCP সার্ভার অবশ্যই এমন কোনো টোকেন গ্রহণ করবে না যা স্পষ্টভাবে MCP সার্ভারের জন্য ইস্যু করা হয়নি। "Token passthrough" স্পষ্টভাবে নিষিদ্ধ একটি অ্যান্টি-প্যাটার্ন।

2. **Authorization Verification**: MCP সার্ভার যা authorization বাস্তবায়ন করে, তারা অবশ্যই সব ইনবাউন্ড অনুরোধ যাচাই করবে এবং authentication এর জন্য session ব্যবহার করবে না।

3. **Secure Session Management**: স্টেট ব্যবহারের জন্য session ব্যবহার করলে, MCP সার্ভার অবশ্যই নিরাপদ, অ-নির্ধারিত session ID ব্যবহার করবে যা নিরাপদ র‍্যান্ডম নাম্বার জেনারেটর দিয়ে তৈরি। session ID ব্যবহারকারীর নির্দিষ্ট তথ্যের সাথে বেঁধে রাখা উচিত।

4. **Explicit User Consent**: proxy সার্ভারের জন্য, MCP বাস্তবায়ন অবশ্যই প্রতিটি ডায়নামিক্যালি রেজিস্টার করা ক্লায়েন্টের জন্য ব্যবহারকারীর সম্মতি নেবে তৃতীয় পক্ষের authorization সার্ভারে ফরওয়ার্ড করার আগে।

চলুন দেখি কিভাবে .NET এবং Java ব্যবহার করে MCP সার্ভারে নিরাপদ authentication এবং authorization বাস্তবায়ন করা যায়।

### .NET Identity Integration

ASP .NET Core Identity ব্যবহারকারীর authentication এবং authorization পরিচালনার জন্য একটি শক্তিশালী ফ্রেমওয়ার্ক প্রদান করে। আমরা এটিকে MCP সার্ভারের সাথে ইন্টিগ্রেট করে টুল এবং রিসোর্সের নিরাপদ প্রবেশাধিকার নিশ্চিত করতে পারি।

ASP.NET Core Identity MCP সার্ভারের সাথে ইন্টিগ্রেশনের সময় কিছু মূল ধারণা বুঝতে হবে:

- **Identity Configuration**: ব্যবহারকারীর রোল এবং ক্লেইম সহ ASP.NET Core Identity সেটআপ করা। ক্লেইম হলো ব্যবহারকারীর সম্পর্কে একটি তথ্য, যেমন তাদের রোল বা অনুমতি, যেমন "Admin" বা "User"।
- **JWT Authentication**: নিরাপদ API প্রবেশাধিকার জন্য JSON Web Tokens (JWT) ব্যবহার। JWT হলো একটি স্ট্যান্ডার্ড যা JSON অবজেক্ট হিসেবে তথ্য নিরাপদে প্রেরণ করে, যা ডিজিটালি সাইন করা থাকায় যাচাইযোগ্য এবং বিশ্বাসযোগ্য।
- **Authorization Policies**: ব্যবহারকারীর রোলের ভিত্তিতে নির্দিষ্ট টুলে প্রবেশাধিকার নিয়ন্ত্রণ করার জন্য নীতি নির্ধারণ। MCP authorization policies ব্যবহার করে নির্ধারণ করে কোন ব্যবহারকারী কোন টুল ব্যবহার করতে পারবে তাদের রোল এবং ক্লেইমের ভিত্তিতে।

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

উপরের কোডে আমরা:

- ব্যবহারকারী ব্যবস্থাপনার জন্য ASP.NET Core Identity কনফিগার করেছি।
- নিরাপদ API প্রবেশাধিকার জন্য JWT authentication সেটআপ করেছি। টোকেন যাচাই প্যারামিটার যেমন issuer, audience, এবং signing key নির্ধারণ করেছি।
- ব্যবহারকারীর রোলের ভিত্তিতে টুলে প্রবেশাধিকার নিয়ন্ত্রণ করার জন্য authorization policies সংজ্ঞায়িত করেছি। উদাহরণস্বরূপ, "CanUseAdminTools" পলিসি ব্যবহারকারীর "Admin" রোল থাকা প্রয়োজন, আর "CanUseBasic" পলিসি ব্যবহারকারীকে authenticated হতে হবে।
- MCP টুলগুলো নির্দিষ্ট authorization প্রয়োজনীয়তা সহ নিবন্ধন করেছি, নিশ্চিত করেছি যে শুধুমাত্র উপযুক্ত রোলের ব্যবহারকারীরাই সেগুলো ব্যবহার করতে পারবে।

### Java Spring Security Integration

Java এর জন্য, MCP সার্ভারের নিরাপদ authentication এবং authorization বাস্তবায়নের জন্য Spring Security ব্যবহার করব। Spring Security একটি ব্যাপক নিরাপত্তা ফ্রেমওয়ার্ক যা Spring অ্যাপ্লিকেশনের সাথে সহজে ইন্টিগ্রেট হয়।

এখানে মূল ধারণাগুলো:

- **Spring Security Configuration**: authentication এবং authorization এর জন্য নিরাপত্তা কনফিগারেশন সেটআপ।
- **OAuth2 Resource Server**: MCP টুলে নিরাপদ প্রবেশাধিকার জন্য OAuth2 ব্যবহার। OAuth2 হলো একটি authorization ফ্রেমওয়ার্ক যা তৃতীয় পক্ষের সার্ভিসকে নিরাপদ API প্রবেশাধিকার জন্য access token বিনিময় করতে দেয়।
- **Security Interceptors**: টুল কার্যকরীতে প্রবেশ নিয়ন্ত্রণ প্রয়োগ করার জন্য নিরাপত্তা ইন্টারসেপ্টর বাস্তবায়ন।
- **Role-Based Access Control**: নির্দিষ্ট টুল এবং রিসোর্সে প্রবেশাধিকার নিয়ন্ত্রণে রোল ব্যবহার।
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

উপরের কোডে আমরা:

- MCP এন্ডপয়েন্ট সুরক্ষিত করতে Spring Security কনফিগার করেছি, টুল ডিসকভারি পাবলিক অ্যাক্সেসযোগ্য রেখে টুল কার্যকরীর জন্য authentication প্রয়োজন।
- MCP টুলে নিরাপদ প্রবেশাধিকার পরিচালনার জন্য OAuth2 রিসোর্স সার্ভার ব্যবহার করেছি।
- টুল কার্যকরীতে প্রবেশ নিয়ন্ত্রণ প্রয়োগ করতে একটি নিরাপত্তা ইন্টারসেপ্টর বাস্তবায়ন করেছি, ব্যবহারকারীর রোল এবং অনুমতি যাচাই করে নির্দিষ্ট টুলে প্রবেশাধিকার অনুমোদন করার আগে।
- রোল-ভিত্তিক প্রবেশ নিয়ন্ত্রণ সংজ্ঞায়িত করেছি যাতে admin টুল এবং সংবেদনশীল ডেটা অ্যাক্সেস রোলের ভিত্তিতে সীমাবদ্ধ থাকে।

## Data Protection and Privacy

ডেটা সুরক্ষা অত্যন্ত গুরুত্বপূর্ণ যাতে সংবেদনশীল তথ্য নিরাপদে পরিচালিত হয়। এর মধ্যে ব্যক্তিগত সনাক্তযোগ্য তথ্য (PII), আর্থিক ডেটা এবং অন্যান্য সংবেদনশীল তথ্য অননুমোদিত প্রবেশ এবং লঙ্ঘন থেকে রক্ষা করা অন্তর্ভুক্ত।

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

উপরের কোডে আমরা:

- `PiiDetector` ক্লাস তৈরি করেছি যা টেক্সট এবং প্যারামিটারগুলোতে ব্যক্তিগত সনাক্তযোগ্য তথ্য (PII) স্ক্যান করে।
- `EncryptionService` ক্লাস তৈরি করেছি যা `cryptography` লাইব্রেরি ব্যবহার করে সংবেদনশীল ডেটার এনক্রিপশন এবং ডিক্রিপশন পরিচালনা করে।
- `secure_tool` ডেকোরেটর সংজ্ঞায়িত করেছি যা টুল কার্যকরীকে মোড়কে আবৃত করে PII পরীক্ষা করে, অ্যাক্সেস লগ করে এবং প্রয়োজনে সংবেদনশীল ডেটা এনক্রিপ্ট করে।
- একটি নমুনা টুল (`SecureCustomerDataTool`) এ `secure_tool` ডেকোরেটর প্রয়োগ করেছি যাতে এটি সংবেদনশীল ডেটা নিরাপদে পরিচালনা করে।

## MCP-Specific Security Risks

অফিসিয়াল MCP নিরাপত্তা ডকুমেন্টেশনের অনুযায়ী, MCP বাস্তবায়নকারীদের সচেতন হওয়ার জন্য নির্দিষ্ট নিরাপত্তা ঝুঁকিগুলো রয়েছে:

### 1. Confused Deputy Problem

এই দুর্বলতা ঘটে যখন MCP সার্ভার তৃতীয় পক্ষের API এর জন্য একটি প্রক্সি হিসেবে কাজ করে, যা আক্রমণকারীদের MCP সার্ভার এবং API এর মধ্যে বিশ্বাসযোগ্য সম্পর্ককে শোষণ করার সুযোগ দেয়।

**প্রতিরোধ:**
- MCP প্রক্সি সার্ভার যারা স্ট্যাটিক ক্লায়েন্ট আইডি ব্যবহার করে, তাদের অবশ্যই প্রতিটি ডায়নামিক্যালি রেজিস্টার করা ক্লায়েন্টের জন্য ব্যবহারকারীর সম্মতি নিতে হবে তৃতীয় পক্ষের authorization সার্ভারে ফরওয়ার্ড করার আগে।
- authorization অনুরোধের জন্য PKCE (Proof Key for Code Exchange) সহ সঠিক OAuth ফ্লো বাস্তবায়ন করুন।
- redirect URI এবং ক্লায়েন্ট আইডেন্টিফায়ার কঠোরভাবে যাচাই করুন।

### 2. Token Passthrough Vulnerabilities

Token passthrough ঘটে যখন MCP সার্ভার MCP ক্লায়েন্ট থেকে টোকেন গ্রহণ করে কিন্তু যাচাই করে না যে টোকেনগুলো MCP সার্ভারের জন্য সঠিকভাবে ইস্যু করা হয়েছে কিনা এবং সেগুলোকে নিচের API গুলোর কাছে ফরওয়ার্ড করে।

### ঝুঁকি
- নিরাপত্তা নিয়ন্ত্রণ এড়ানো (rate limiting, অনুরোধ যাচাই এড়ানো)
- দায়িত্ব এবং অডিট ট্রেইল সমস্যা
- বিশ্বাস সীমার লঙ্ঘন
- ভবিষ্যত সামঞ্জস্য ঝুঁকি

**প্রতিরোধ:**
- MCP সার্ভার অবশ্যই এমন কোনো টোকেন গ্রহণ করবে না যা স্পষ্টভাবে MCP সার্ভারের জন্য ইস্যু করা হয়নি।
- সর্বদা টোকেনের audience ক্লেইম যাচাই করুন যাতে তা প্রত্যাশিত সার্ভিসের সাথে মেলে।

### 3. Session Hijacking

এই সমস্যা ঘটে যখন অননুমোদিত পক্ষ একটি session ID পেয়ে মূল ক্লায়েন্টের ছদ্মবেশ ধারণ করে, যা অননুমোদিত কার্যকলাপে নিয়ে যেতে পারে।

**প্রতিরোধ:**
- MCP সার্ভার যা authorization বাস্তবায়ন করে, তারা অবশ্যই সব ইনবাউন্ড অনুরোধ যাচাই করবে এবং authentication এর জন্য session ব্যবহার করবে না।
- নিরাপদ, অ-নির্ধারিত session ID ব্যবহার করুন যা নিরাপদ র‍্যান্ডম নাম্বার জেনারেটর দিয়ে তৈরি।
- session ID ব্যবহারকারীর নির্দিষ্ট তথ্যের সাথে বেঁধে রাখুন, যেমন `<user_id>:<session_id>` ফরম্যাটে।
- session মেয়াদ শেষ হওয়া এবং রোটেশন নীতি সঠিকভাবে বাস্তবায়ন করুন।

## Additional Security Best Practices for MCP

মূল MCP নিরাপত্তা বিবেচনার বাইরে, নিচের অতিরিক্ত নিরাপত্তা অনুশীলনগুলো বিবেচনা করুন:

- **সবসময় HTTPS ব্যবহার করুন**: ক্লায়েন্ট এবং সার্ভারের মধ্যে যোগাযোগ এনক্রিপ্ট করুন যাতে টোকেন আটকানো থেকে রক্ষা পায়।
- **Role-Based Access Control (RBAC) বাস্তবায়ন করুন**: শুধু ব্যবহারকারী authenticated কিনা তা যাচাই করবেন না; তারা কি করতে অনুমোদিত তা যাচাই করুন।
- **মনিটর এবং অডিট করুন**: সব authentication ইভেন্ট লগ করুন যাতে সন্দেহজনক কার্যকলাপ শনাক্ত ও প্রতিক্রিয়া জানানো যায়।
- **Rate limiting এবং throttling পরিচালনা করুন**: rate limit gracefully পরিচালনার জন্য exponential backoff এবং retry লজিক বাস্তবায়ন করুন।
- **নিরাপদ টোকেন সংরক্ষণ করুন**: access token এবং refresh token সিস্টেমের নিরাপদ স্টোরেজ মেকানিজম বা নিরাপদ কী ম্যানেজমেন্ট সার্ভিস ব্যবহার করে সুরক্ষিত রাখুন।
- **API Management ব্যবহার বিবেচনা করুন**: Azure API Management এর মতো সার্ভিসগুলো অনেক নিরাপত্তা বিষয় স্বয়ংক্রিয়ভাবে পরিচালনা করতে পারে, যেমন authentication, authorization, এবং rate limiting।

## References

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## What's next

- [5.9 Web search](../web-search-mcp/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।