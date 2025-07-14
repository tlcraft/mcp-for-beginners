<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:45:08+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "my"
}
-->
# လုံခြုံရေးအကောင်းဆုံးလေ့ကျင့်မှုများ

MCP အကောင်အထည်ဖော်မှုများတွင် လုံခြုံရေးသည် အရေးကြီးပါသည်၊ အထူးသဖြင့် စီးပွားရေးလုပ်ငန်းပတ်ဝန်းကျင်များတွင်။ ကိရိယာများနှင့် ဒေတာများကို ခွင့်ပြုမထားသော ဝင်ရောက်မှု၊ ဒေတာဖောက်ထွင်းမှုများနှင့် အခြားလုံခြုံရေးအန္တရာယ်များမှ ကာကွယ်ထားရန် အရေးကြီးပါသည်။

## နိဒါန်း

ဒီသင်ခန်းစာတွင် MCP အကောင်အထည်ဖော်မှုများအတွက် လုံခြုံရေးအကောင်းဆုံးလေ့ကျင့်မှုများကို လေ့လာသွားမည်ဖြစ်သည်။ အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း၊ ဒေတာကာကွယ်မှု၊ လုံခြုံစိတ်ချရသော ကိရိယာများ အကောင်အထည်ဖော်ခြင်းနှင့် ဒေတာကိုယ်ရေးအချက်အလက်ကာကွယ်မှု စည်းမျဉ်းစည်းကမ်းများနှင့် ကိုက်ညီမှုတို့ကို ဖော်ပြသွားမည်ဖြစ်သည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးသတ်ချိန်တွင် သင်သည် အောက်ပါအရာများကို ပြုလုပ်နိုင်မည်ဖြစ်သည်-

- MCP ဆာဗာများအတွက် လုံခြုံစိတ်ချရသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းစနစ်များကို အကောင်အထည်ဖော်နိုင်ခြင်း။
- စကားဝှက်နှင့် လုံခြုံစိတ်ချရသော သိမ်းဆည်းမှုများဖြင့် အရေးကြီးဒေတာများကို ကာကွယ်နိုင်ခြင်း။
- သင့်တော်သော ဝင်ရောက်ခွင့်ထိန်းချုပ်မှုများဖြင့် ကိရိယာများကို လုံခြုံစိတ်ချစွာ အကောင်အထည်ဖော်နိုင်ခြင်း။
- ဒေတာကာကွယ်မှုနှင့် ကိုယ်ရေးအချက်အလက်ကာကွယ်မှု စည်းမျဉ်းစည်းကမ်းများအတွက် အကောင်းဆုံးလေ့ကျင့်မှုများကို အသုံးပြုနိုင်ခြင်း။

## အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း

အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းသည် MCP ဆာဗာများကို လုံခြုံစိတ်ချစေရန် အရေးကြီးပါသည်။ အတည်ပြုခြင်းသည် "သင်ဘယ်သူလဲ?" ဆိုသော မေးခွန်းကို ဖြေဆိုပြီး ခွင့်ပြုခြင်းသည် "သင်ဘာလုပ်နိုင်ပါသလဲ?" ဆိုသော မေးခွန်းကို ဖြေဆိုသည်။

.NET နှင့် Java ကို အသုံးပြု၍ MCP ဆာဗာများတွင် လုံခြုံစိတ်ချရသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို မည်သို့ အကောင်အထည်ဖော်မည်ကို ဥပမာများဖြင့် ကြည့်ကြမည်။

### .NET Identity ပေါင်းစည်းခြင်း

ASP .NET Core Identity သည် အသုံးပြုသူ အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို စီမံခန့်ခွဲရန် ခိုင်မာသော ဖရိမ်ဝတ်တစ်ခုဖြစ်သည်။ MCP ဆာဗာများနှင့် ပေါင်းစည်း၍ ကိရိယာများနှင့် အရင်းအမြစ်များသို့ လုံခြုံစိတ်ချရသော ဝင်ရောက်ခွင့်ကို သေချာစေနိုင်သည်။

ASP.NET Core Identity ကို MCP ဆာဗာများနှင့် ပေါင်းစည်းရာတွင် နားလည်ရမည့် အဓိကအယူအဆများမှာ-

- **Identity Configuration**: အသုံးပြုသူ အခန်းကဏ္ဍများနှင့် အခွင့်အရေးများဖြင့် ASP.NET Core Identity ကို စီစဉ်ခြင်း။ Claim ဆိုသည်မှာ အသုံးပြုသူအကြောင်း အချက်အလက်တစ်ခုဖြစ်ပြီး၊ ဥပမာအားဖြင့် "Admin" သို့မဟုတ် "User" ကဲ့သို့သော အခန်းကဏ္ဍ သို့မဟုတ် ခွင့်ပြုချက်များဖြစ်သည်။
- **JWT Authentication**: JSON Web Tokens (JWT) ကို အသုံးပြု၍ လုံခြုံစိတ်ချရသော API ဝင်ရောက်ခွင့်။ JWT သည် JSON အရာဝတ္ထုအဖြစ် ပါတီများအကြား အချက်အလက်များကို လုံခြုံစွာ ပို့ဆောင်ရန် စံချိန်စံညွှန်းဖြစ်ပြီး၊ ဒစ်ဂျစ်တယ်လက်မှတ်ဖြင့် အတည်ပြုထားသောကြောင့် ယုံကြည်စိတ်ချရသည်။
- **Authorization Policies**: အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ် မူတည်၍ ကိရိယာများသို့ ဝင်ရောက်ခွင့်ကို ထိန်းချုပ်ရန် မူဝါဒများ သတ်မှတ်ခြင်း။ MCP သည် အသုံးပြုသူများ၏ အခန်းကဏ္ဍများနှင့် claim များအပေါ် မူတည်၍ မည်သူက မည်သည့်ကိရိယာများကို အသုံးပြုနိုင်မည်ကို သတ်မှတ်ရန် ခွင့်ပြုမူဝါဒများကို အသုံးပြုသည်။

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

အထက်ပါ ကုဒ်တွင်-

- အသုံးပြုသူ စီမံခန့်ခွဲမှုအတွက် ASP.NET Core Identity ကို စီစဉ်ထားသည်။
- လုံခြုံစိတ်ချရသော API ဝင်ရောက်ခွင့်အတွက် JWT အတည်ပြုခြင်းကို စီစဉ်ထားသည်။ token အတည်ပြုမှု parameter များတွင် issuer, audience နှင့် signing key ပါဝင်သည်။
- အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ် မူတည်၍ ကိရိယာများသို့ ဝင်ရောက်ခွင့်ကို ထိန်းချုပ်ရန် ခွင့်ပြုမူဝါဒများ သတ်မှတ်ထားသည်။ ဥပမာအားဖြင့် "CanUseAdminTools" မူဝါဒသည် အသုံးပြုသူတွင် "Admin" အခန်းကဏ္ဍ ရှိရမည်ဟု တောင်းဆိုပြီး၊ "CanUseBasic" မူဝါဒသည် အသုံးပြုသူ အတည်ပြုထားရမည်ဟု တောင်းဆိုသည်။
- MCP ကိရိယာများကို သတ်မှတ်ထားသော ခွင့်ပြုချက်လိုအပ်ချက်များနှင့် အတူ မှတ်ပုံတင်ထားပြီး၊ သင့်တော်သော အခန်းကဏ္ဍရှိသူများသာ ဝင်ရောက်နိုင်စေရန် သေချာစေသည်။

### Java Spring Security ပေါင်းစည်းခြင်း

Java အတွက် MCP ဆာဗာများအတွက် လုံခြုံစိတ်ချရသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို အကောင်အထည်ဖော်ရန် Spring Security ကို အသုံးပြုမည်ဖြစ်သည်။ Spring Security သည် Spring အက်ပလီကေးရှင်းများနှင့် အဆင်ပြေစွာ ပေါင်းစည်းနိုင်သော လုံခြုံရေး ဖရိမ်ဝတ်တစ်ခုဖြစ်သည်။

အဓိကအယူအဆများမှာ-

- **Spring Security Configuration**: အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းအတွက် လုံခြုံရေး ဖွဲ့စည်းမှုများကို စီစဉ်ခြင်း။
- **OAuth2 Resource Server**: MCP ကိရိယာများသို့ လုံခြုံစိတ်ချရသော ဝင်ရောက်ခွင့်အတွက် OAuth2 ကို အသုံးပြုခြင်း။ OAuth2 သည် တတိယပါတီ ဝန်ဆောင်မှုများအား လုံခြုံစိတ်ချရသော API ဝင်ရောက်ခွင့်အတွက် access token များ လဲလှယ်ခွင့်ပြုသော ခွင့်ပြုမှု ဖရိမ်ဝတ်ဖြစ်သည်။
- **Security Interceptors**: ကိရိယာများ အကောင်အထည်ဖော်မှုတွင် ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုများကို အကောင်အထည်ဖော်ရန် လုံခြုံရေး အတားအဆီးများကို ထည့်သွင်းဆောင်ရွက်ခြင်း။
- **Role-Based Access Control**: အခန်းကဏ္ဍများကို အသုံးပြု၍ ကိရိယာများနှင့် အရင်းအမြစ်များသို့ ဝင်ရောက်ခွင့်ကို ထိန်းချုပ်ခြင်း။
- **Security Annotations**: နည်းလမ်းများနှင့် endpoint များကို လုံခြုံစေရန် အမှတ်အသားများကို အသုံးပြုခြင်း။

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

အထက်ပါ ကုဒ်တွင်-

- MCP endpoint များကို လုံခြုံစေရန် Spring Security ကို စီစဉ်ထားပြီး၊ ကိရိယာ ရှာဖွေရေးအတွက် ပြည်သူ့ဝင်ရောက်ခွင့် ခွင့်ပြုထားသော်လည်း ကိရိယာ အကောင်အထည်ဖော်မှုအတွက် အတည်ပြုခြင်း လိုအပ်သည်။
- MCP ကိရိယာများသို့ လုံခြုံစိတ်ချရသော ဝင်ရောက်ခွင့်ကို ကိုင်တွယ်ရန် OAuth2 ကို resource server အဖြစ် အသုံးပြုထားသည်။
- ကိရိယာ အကောင်အထည်ဖော်မှုတွင် ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုများကို အကောင်အထည်ဖော်ရန် လုံခြုံရေး အတားအဆီးတစ်ခုကို ထည့်သွင်းဆောင်ရွက်ပြီး၊ အသုံးပြုသူ အခန်းကဏ္ဍများနှင့် ခွင့်ပြုချက်များကို စစ်ဆေးသည်။
- အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ် မူတည်၍ အက်မင် ကိရိယာများနှင့် အရေးကြီးဒေတာ ဝင်ရောက်ခွင့်ကို ကန့်သတ်ရန် အခန်းကဏ္ဍအခြေပြု ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုကို သတ်မှတ်ထားသည်။

## ဒေတာကာကွယ်မှုနှင့် ကိုယ်ရေးအချက်အလက်ကာကွယ်မှု

ဒေတာကာကွယ်မှုသည် အရေးကြီးသော အချက်အလက်များကို လုံခြုံစိတ်ချစွာ ကိုင်တွယ်ထားရန် အရေးကြီးသည်။ ၎င်းတွင် ကိုယ်ရေးအချက်အလက်များ (PII), ငွေကြေးဆိုင်ရာ ဒေတာများနှင့် အခြား အရေးကြီးသော အချက်အလက်များကို ခွင့်မပြုထားသော ဝင်ရောက်မှုနှင့် ဖောက်ထွင်းမှုများမှ ကာကွယ်ခြင်း ပါဝင်သည်။

### Python ဒေတာကာကွယ်မှု ဥပမာ

Python တွင် စကားဝှက်ရေးခြင်းနှင့် PII ရှာဖွေရေးကို အသုံးပြု၍ ဒေတာကာကွယ်မှုကို မည်သို့ အကောင်အထည်ဖော်မည်ကို ဥပမာဖြင့် ကြည့်ကြမည်။

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

အထက်ပါ ကုဒ်တွင်-

- စာသားနှင့် ပါရာမီတာများကို ကိုယ်ရေးအချက်အလက် (PII) ရှိ/မရှိ စစ်ဆေးရန် `PiiDetector` class ကို အကောင်အထည်ဖော်ထားသည်။
- `cryptography` စာကြည့်တိုက်ကို အသုံးပြု၍ အရေးကြီးဒေတာများကို စကားဝှက်ရေးခြင်းနှင့် စကားဝှက်ဖျက်ခြင်းကို ကိုင်တွယ်ရန် `EncryptionService` class ကို ဖန်တီးထားသည်။
- ကိရိယာ အကောင်အထည်ဖော်မှုကို PII ရှိ/မရှိ စစ်ဆေးခြင်း၊ ဝင်ရောက်မှုမှတ်တမ်းတင်ခြင်းနှင့် လိုအပ်ပါက အရေးကြီးဒေတာများကို စကားဝှက်ရေးခြင်းတို့ ပြုလုပ်ရန် `secure_tool` decorator ကို သတ်မှတ်ထားသည်။
- `secure_tool` decorator ကို နမူနာကိရိယာတစ်ခုဖြစ်သည့် `SecureCustomerDataTool` တွင် အသုံးပြု၍ အရေးကြီးဒေတာများကို လုံခြုံစိတ်ချစွာ ကိုင်တွယ်နိုင်စေရန် သေချာစေသည်။

## နောက်တစ်ဆင့်

- [5.9 Web search](../web-search-mcp/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။