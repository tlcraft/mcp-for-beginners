<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-17T16:56:16+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "my"
}
-->
# လုံခြုံရေး အကောင်းဆုံး လေ့လာမှုများ

MCP အကောင်အထည်ဖော်မှုများတွင် လုံခြုံရေးသည် အရေးကြီးပါသည်၊ အထူးသဖြင့် စီးပွားရေးလုပ်ငန်းပတ်ဝန်းကျင်များတွင်။ မလိုလားအပ်သော ဝင်ရောက်မှုများ၊ ဒေတာပေါက်ကြားမှုများနှင့် အခြားလုံခြုံရေးအန္တရာယ်များမှ ကာကွယ်ရန် ကိရိယာများနှင့် ဒေတာများကို ကာကွယ်ထားရမည်ဖြစ်သည်။

## နိဒါန်း

ဤသင်ခန်းစာတွင် MCP အကောင်အထည်ဖော်မှုများအတွက် လုံခြုံရေးအကောင်းဆုံး လေ့လာမှုများကို လေ့လာပါမည်။ အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း၊ ဒေတာကာကွယ်ခြင်း၊ လုံခြုံစိတ်ချရသော ကိရိယာများဆောင်ရွက်ခြင်းနှင့် ဒေတာလုံခြုံရေးစည်းမျဉ်းများနှင့် ကိုက်ညီမှုတို့ကို ဖော်ပြပါမည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာပြီးဆုံးချိန်တွင် သင်သည် -

- MCP ဆာဗာများအတွက် လုံခြုံစိတ်ချရသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း နည်းလမ်းများကို အကောင်အထည်ဖော်နိုင်မည်။
- အချက်အလက်များကို စာလုံးဖုံးခြင်းနှင့် လုံခြုံစိတ်ချရသော သိမ်းဆည်းမှုဖြင့် ကာကွယ်နိုင်မည်။
- သင့်တော်သော ဝင်ရောက်ခွင့်ထိန်းချုပ်မှုများဖြင့် ကိရိယာများကို လုံခြုံစိတ်ချစွာ ဆောင်ရွက်နိုင်မည်။
- ဒေတာကာကွယ်မှုနှင့် ကိုယ်ရေးကာကွယ်မှုစည်းမျဉ်းများနှင့် ကိုက်ညီသော အကောင်းဆုံး လေ့လာမှုများကို အသုံးပြုနိုင်မည်။

## အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း

MCP ဆာဗာများကို လုံခြုံစိတ်ချစေရန်အတွက် အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းသည် အလွန်အရေးကြီးပါသည်။ အတည်ပြုခြင်းသည် "သင်ဘယ်သူလဲ?" ဆိုသောမေးခွန်းကိုဖြေဆိုပြီး ခွင့်ပြုခြင်းသည် "သင်ဘာလုပ်နိုင်ပါသလဲ?" ဆိုသောမေးခွန်းကို ဖြေဆိုသည်။

.NET နှင့် Java အသုံးပြု၍ MCP ဆာဗာများတွင် လုံခြုံစိတ်ချရသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို မည်သို့အကောင်အထည်ဖော်မည်ကို ဥပမာများဖြင့် ကြည့်ကြရအောင်။

### .NET Identity ပေါင်းစပ်ခြင်း

ASP .NET Core Identity သည် အသုံးပြုသူအတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို စီမံခန့်ခွဲရန် အင်အားကြီးသော ဖရိမ်းဝပ်တစ်ခုဖြစ်သည်။ MCP ဆာဗာများနှင့် ပေါင်းစပ်၍ ကိရိယာများနှင့် အရင်းအမြစ်များသို့ လုံခြုံစိတ်ချစွာ ဝင်ရောက်နိုင်မှုကို ကာကွယ်နိုင်သည်။

ASP.NET Core Identity ကို MCP ဆာဗာများနှင့် ပေါင်းစပ်ရာတွင် နားလည်ရန် အဓိကအယူအဆများမှာ -

- **Identity ဖွဲ့စည်းမှု**: အသုံးပြုသူ အခန်းကဏ္ဍများနှင့် အာမခံချက်များဖြင့် ASP.NET Core Identity ကို စီစဉ်ခြင်း။ အာမခံချက်ဆိုသည်မှာ အသုံးပြုသူ၏ အခန်းကဏ္ဍ သို့မဟုတ် ခွင့်ပြုချက်များကဲ့သို့သော အသုံးပြုသူအကြောင်းအချက်တစ်စိတ်တစ်ပိုင်းဖြစ်သည်၊ ဥပမာ "Admin" သို့မဟုတ် "User"။
- **JWT အတည်ပြုခြင်း**: JSON Web Tokens (JWT) ကို လုံခြုံစိတ်ချသော API ဝင်ရောက်မှုအတွက် အသုံးပြုခြင်း။ JWT သည် ပါတီများအကြား JSON အရာဝတ္ထုအဖြစ် သတင်းအချက်အလက်များကို လုံခြုံစိတ်ချစွာ ပို့ဆောင်ရန် စံချိန်စံညွှန်းဖြစ်ပြီး ဒစ်ဂျစ်တယ်လက်မှတ်ဖြင့် စစ်ဆေးနိုင်သည်။
- **ခွင့်ပြုချက်မူဝါဒများ**: အသုံးပြုသူ အခန်းကဏ္ဍအပေါ် အခြေခံ၍ ကိရိယာအချို့သို့ ဝင်ရောက်ခွင့်ကို ထိန်းချုပ်ရန် မူဝါဒများ သတ်မှတ်ခြင်း။ MCP သည် အသုံးပြုသူ၏ အခန်းကဏ္ဍများနှင့် အာမခံချက်များအပေါ်မူတည်၍ ဘယ်သူက ဘယ်ကိရိယာကို အသုံးပြုနိုင်မည်ကို ဆုံးဖြတ်ရန် ခွင့်ပြုချက်မူဝါဒများကို အသုံးပြုသည်။

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

အထက်ပါ ကုဒ်တွင် -

- အသုံးပြုသူ စီမံခန့်ခွဲမှုအတွက် ASP.NET Core Identity ကို ဖွဲ့စည်းထားသည်။
- လုံခြုံစိတ်ချရသော API ဝင်ရောက်မှုအတွက် JWT အတည်ပြုခြင်းကို စီစဉ်ထားသည်။ token စစ်ဆေးမှု ပါရာမီတာများဖြစ်သော ထုတ်ဝေသူ၊ ပရိသတ်နှင့် လက်မှတ်ရေးထိုးသော key ကို သတ်မှတ်ထားသည်။
- အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ်မူတည်၍ ကိရိယာများသို့ ဝင်ရောက်ခွင့် ထိန်းချုပ်ရန် ခွင့်ပြုချက်မူဝါဒများကို သတ်မှတ်ထားသည်။ ဥပမာ "CanUseAdminTools" မူဝါဒသည် အသုံးပြုသူတွင် "Admin" အခန်းကဏ္ဍ ရှိရမည်ဟု တောင်းဆိုပြီး "CanUseBasic" မူဝါဒသည် အသုံးပြုသူ အတည်ပြုခံရထားရမည်။
- MCP ကိရိယာများကို သတ်မှတ်ထားသော ခွင့်ပြုချက်လိုအပ်ချက်များနှင့် အတူ မှတ်ပုံတင်ထားပြီး သင့်တော်သော အခန်းကဏ္ဍရှိသူများသာ ဝင်ရောက်ခွင့်ရှိစေရန် သေချာစေသည်။

### Java Spring Security ပေါင်းစပ်ခြင်း

Java အတွက် MCP ဆာဗာများအတွက် လုံခြုံစိတ်ချရသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို အကောင်အထည်ဖော်ရန် Spring Security ကို အသုံးပြုမည်။ Spring Security သည် Spring အက်ပ်လီကေးရှင်းများနှင့် အဆင်ပြေစွာ ပေါင်းစပ်နိုင်သော လုံခြုံရေးဖရိမ်းဝပ်တစ်ခုဖြစ်သည်။

အဓိက အယူအဆများမှာ -

- **Spring Security ဖွဲ့စည်းမှု**: အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းအတွက် လုံခြုံရေးဖွဲ့စည်းမှုများကို စီမံခြင်း။
- **OAuth2 Resource Server**: MCP ကိရိယာများသို့ လုံခြုံစိတ်ချသော ဝင်ရောက်မှုအတွက် OAuth2 ကို အသုံးပြုခြင်း။ OAuth2 သည် တတိယပါတီဝန်ဆောင်မှုများအား လုံခြုံစိတ်ချရသော API ဝင်ရောက်မှုအတွက် access token များကို လဲလှယ်ခွင့်ပြုသော ခွင့်ပြုရေးဖရိမ်းဝပ်ဖြစ်သည်။
- **Security Interceptors**: ကိရိယာဆောင်ရွက်မှုတွင် ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုများကို စည်းကမ်းသတ်မှတ်ရန် လုံခြုံရေးအတားအဆီးများကို အကောင်အထည်ဖော်ခြင်း။
- **Role-Based Access Control**: အခန်းကဏ္ဍများကို အသုံးပြု၍ ကိရိယာနှင့် အရင်းအမြစ်များသို့ ဝင်ရောက်ခွင့် ထိန်းချုပ်ခြင်း။
- **Security Annotations**: နည်းလမ်းများနှင့် endpoint များကို လုံခြုံစေရန် annotation များကို အသုံးပြုခြင်း။

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

အထက်ပါ ကုဒ်တွင် -

- MCP endpoint များကို လုံခြုံစေရန် Spring Security ကို ဖွဲ့စည်းထားပြီး ကိရိယာရှာဖွေရေးအတွက် လူထုဝင်ရောက်ခွင့်ပေးသော်လည်း ကိရိယာဆောင်ရွက်မှုအတွက် အတည်ပြုခြင်း လိုအပ်သည်။
- MCP ကိရိယာများသို့ လုံခြုံစိတ်ချရသော ဝင်ရောက်မှုကို ကိုင်တွယ်ရန် OAuth2 ကို resource server အဖြစ် အသုံးပြုထားသည်။
- ကိရိယာဆောင်ရွက်မှုတွင် ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုများအား လုပ်ဆောင်ရန် လုံခြုံရေးအတားအဆီးတစ်ခုကို အကောင်အထည်ဖော်ထားပြီး အသုံးပြုသူ အခန်းကဏ္ဍနှင့် ခွင့်ပြုချက်များကို စစ်ဆေးကာ သတ်မှတ်ထားသော ကိရိယာများသို့ ဝင်ရောက်ခွင့်ပြုသည်။
- အခန်းကဏ္ဍအခြေခံ ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုကို သတ်မှတ်ထားပြီး admin ကိရိယာများနှင့် အချက်အလက်များသို့ ဝင်ရောက်ခွင့်ကို အခန်းကဏ္ဍအလိုက် ကန့်သတ်ထားသည်။

## ဒေတာကာကွယ်မှုနှင့် ကိုယ်ရေးကာကွယ်မှု

ဒေတာကာကွယ်မှုသည် အချက်အလက်များကို လုံခြုံစိတ်ချစွာ ကိုင်တွယ်စေခြင်းအတွက် အလွန်အရေးကြီးသည်။ ၎င်းတွင် ကိုယ်ရေးအချက်အလက်များ (PII), ငွေကြေးဆိုင်ရာ ဒေတာများနှင့် အခြားအချက်အလက်များကို မလိုလားအပ်သော ဝင်ရောက်မှုများနှင့် ပေါက်ကြားမှုများမှ ကာကွယ်ခြင်း ပါဝင်သည်။

### Python ဒေတာကာကွယ်မှု ဥပမာ

Python တွင် စာလုံးဖုံးခြင်းနှင့် PII ရှာဖွေရေးကို အသုံးပြု၍ ဒေတာကာကွယ်မှုကို မည်သို့ အကောင်အထည်ဖော်မည်ကို ဥပမာကြည့်ပါမည်။

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

အထက်ပါ ကုဒ်တွင် -

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` ကို အချက်အလက်များကို လုံခြုံစိတ်ချစွာ ကိုင်တွယ်နိုင်ရန် အကောင်အထည်ဖော်ထားသည်။

## နောက်တစ်ဆင့်

- [5.9 Web search](../web-search-mcp/README.md)

**အသိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်မှုဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှုအတွက် ကြိုးစားခဲ့သော်လည်း အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် တိကျမှုမရှိမှုများ ဖြစ်ပေါ်နိုင်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ကျွမ်းကျင်သော လူသားဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုရာမှ ဖြစ်ပေါ်နိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းသော အဓိပ္ပာယ်ဖွင့်ဆိုမှုများအတွက် ကျွန်ုပ်တို့မှာ တာဝန်မခံပါ။