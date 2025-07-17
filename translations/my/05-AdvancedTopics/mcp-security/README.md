<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T12:39:26+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "my"
}
-->
# လုံခြုံရေးအကောင်းဆုံးလေ့လာမှုများ

MCP ကို အထူးသဖြင့် စီးပွားရေးပတ်ဝန်းကျင်များတွင် အသုံးပြုရာတွင် လုံခြုံရေးသည် အလွန်အရေးကြီးသည်။ မလိုလားအပ်သော ဝင်ရောက်မှုများ၊ ဒေတာဖောက်ထွင်းမှုများနှင့် အခြားလုံခြုံရေးအန္တရာယ်များမှ ကာကွယ်ရန် ကိရိယာများနှင့် ဒေတာများကို ကာကွယ်ထားရမည်ဖြစ်သည်။

## နိဒါန်း

Model Context Protocol (MCP) သည် LLM များအား ဒေတာနှင့် ကိရိယာများသို့ ဝင်ရောက်ခွင့်ပေးရာတွင် အရေးပါသော အခန်းကဏ္ဍရှိသောကြောင့် အထူးသဖြင့် လုံခြုံရေးဆိုင်ရာ စဉ်းစားချက်များလိုအပ်သည်။ ဤသင်ခန်းစာတွင် MCP အကောင်အထည်ဖော်မှုများအတွက် တရားဝင် MCP လမ်းညွှန်ချက်များနှင့် အတည်ပြုထားသော လုံခြုံရေးပုံစံများအပေါ် အခြေခံ၍ လုံခြုံရေးအကောင်းဆုံးလေ့လာမှုများကို ရှင်းလင်းပြသထားသည်။

MCP သည် လုံခြုံပြီး ယုံကြည်စိတ်ချရသော အပြန်အလှန်ဆက်သွယ်မှုများအတွက် အောက်ပါ အဓိက လုံခြုံရေးအခြေခံသဘောတရားများကို လိုက်နာသည်-

- **အသုံးပြုသူ၏ သဘောတူညီချက်နှင့် ထိန်းချုပ်မှု** - ဒေတာကို ဝင်ရောက်ကြည့်ရှုခြင်း သို့မဟုတ် လုပ်ဆောင်ချက်များ ပြုလုပ်ခြင်းမပြုမီ အသုံးပြုသူမှ ထောက်ခံချက် ရရှိထားရမည်။ မည်သည့်ဒေတာများကို မည်သည့် လုပ်ဆောင်ချက်များကို ခွင့်ပြုမည်ကို သေချာရှင်းလင်းစွာ ထိန်းချုပ်ပေးရမည်။
  
- **ဒေတာကိုယ်ရေးအချက်အလက်လုံခြုံမှု** - အသုံးပြုသူဒေတာကို သဘောတူညီချက် ရရှိမှသာ ဖော်ပြရမည်ဖြစ်ပြီး သင့်တော်သော ဝင်ရောက်ခွင့်ထိန်းချုပ်မှုများဖြင့် ကာကွယ်ထားရမည်။ မလိုလားအပ်သော ဒေတာပို့ဆောင်မှုမှ ကာကွယ်ရမည်။
  
- **ကိရိယာလုံခြုံမှု** - မည်သည့်ကိရိယာကိုမဆို အသုံးပြုရန်မတိုင်မီ အသုံးပြုသူ၏ ထောက်ခံချက် ရရှိထားရမည်။ အသုံးပြုသူများသည် ကိရိယာတစ်ခုချင်းစီ၏ လုပ်ဆောင်ချက်ကို သေချာနားလည်ထားရမည်ဖြစ်ပြီး ခိုင်မာသော လုံခြုံရေးနယ်နိမိတ်များကို အကောင်အထည်ဖော်ထားရမည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးသတ်သည်အထိ သင်သည်-

- MCP ဆာဗာများအတွက် လုံခြုံသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းစနစ်များကို အကောင်အထည်ဖော်နိုင်မည်။
- စကားဝှက်ခြင်းနှင့် လုံခြုံသော သိမ်းဆည်းမှုများဖြင့် အထူးသဖြင့် ကာကွယ်ထားသည့် ဒေတာများကို ကာကွယ်နိုင်မည်။
- သင့်တော်သော ဝင်ရောက်ခွင့်ထိန်းချုပ်မှုများဖြင့် ကိရိယာများကို လုံခြုံစွာ အကောင်အထည်ဖော်နိုင်မည်။
- ဒေတာကာကွယ်မှုနှင့် ကိုယ်ရေးအချက်အလက်လုံခြုံမှုလိုက်နာမှုအတွက် အကောင်းဆုံးလေ့လာမှုများကို အသုံးချနိုင်မည်။
- confused deputy ပြဿနာ၊ token passthrough နှင့် session hijacking ကဲ့သို့သော MCP လုံခြုံရေး အားနည်းချက်များကို ရှာဖွေ၊ ကာကွယ်နိုင်မည်။

## အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း

အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းသည် MCP ဆာဗာများကို လုံခြုံစေရာတွင် အရေးကြီးသည်။ အတည်ပြုခြင်းသည် "သင်ဘယ်သူလဲ?" ဆိုသော မေးခွန်းကို ဖြေဆိုပြီး ခွင့်ပြုခြင်းသည် "သင်ဘာလုပ်နိုင်သလဲ?" ဆိုသော မေးခွန်းကို ဖြေဆိုသည်။

MCP လုံခြုံရေး သတ်မှတ်ချက်အရ အောက်ပါအချက်များသည် အရေးကြီးသော လုံခြုံရေးစဉ်းစားချက်များဖြစ်သည်-

1. **Token စစ်ဆေးခြင်း** - MCP ဆာဗာများသည် MCP ဆာဗာအတွက် တိတိကျကျ ထုတ်ပေးထားသော token မဟုတ်သော token များကို လက်ခံမထားရ။ "Token passthrough" သည် တိတိကျကျ တားမြစ်ထားသော အပြုအမူဖြစ်သည်။

2. **ခွင့်ပြုချက် စစ်ဆေးခြင်း** - ခွင့်ပြုချက်ကို အကောင်အထည်ဖော်သော MCP ဆာဗာများသည် ဝင်ရောက်လာသော တောင်းဆိုမှုအားလုံးကို စစ်ဆေးရမည်ဖြစ်ပြီး အတည်ပြုခြင်းအတွက် session များကို မသုံးသင့်ပါ။

3. **လုံခြုံသော Session စီမံခန့်ခွဲမှု** - Session များကို အခြေခံ၍ အခြေအနေကို စီမံရာတွင် MCP ဆာဗာများသည် လုံခြုံပြီး မကြိုတင်ခန့်မှန်းနိုင်သော session ID များကို လုံခြုံသော အမှတ်အသား များဖြင့် ဖန်တီးရမည်။ Session ID များကို အသုံးပြုသူအထူးသတ်မှတ်ချက်များနှင့် ချိတ်ဆက်ထားသင့်သည်။

4. **အသုံးပြုသူ၏ ထောက်ခံချက် တိတိကျကျ ရယူခြင်း** - Proxy ဆာဗာများအတွက် MCP အကောင်အထည်ဖော်မှုများသည် တတိယပါတီ ခွင့်ပြုရေးဆာဗာများသို့ ပို့ဆောင်မည့် မတိုင်မီ တစ်ခုချင်းစီ အလိုအလျောက် မှတ်ပုံတင်ထားသော client များအတွက် အသုံးပြုသူ၏ ထောက်ခံချက် ရယူရမည်။

.NET နှင့် Java ကို အသုံးပြု၍ MCP ဆာဗာများတွင် လုံခြုံသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို မည်သို့ အကောင်အထည်ဖော်မည်ကို ဥပမာများဖြင့် ကြည့်ကြရအောင်။

### .NET Identity ပေါင်းစည်းခြင်း

ASP .NET Core Identity သည် အသုံးပြုသူ အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို စီမံခန့်ခွဲရန် ခိုင်မာသော ဖရိမ်ဝတ်တစ်ခုဖြစ်သည်။ MCP ဆာဗာများနှင့် ပေါင်းစည်း၍ ကိရိယာများနှင့် အရင်းအမြစ်များသို့ လုံခြုံစွာ ဝင်ရောက်ခွင့် ထိန်းချုပ်နိုင်သည်။

ASP.NET Core Identity ကို MCP ဆာဗာများနှင့် ပေါင်းစည်းရာတွင် နားလည်ရမည့် အဓိက အယူအဆများမှာ-

- **Identity ဖွဲ့စည်းမှု** - အသုံးပြုသူ အခန်းကဏ္ဍများနှင့် claim များဖြင့် ASP.NET Core Identity ကို စီစဉ်ခြင်း။ Claim သည် အသုံးပြုသူအကြောင်း အချက်အလက်တစ်ခုဖြစ်ပြီး ဥပမာအားဖြင့် "Admin" သို့မဟုတ် "User" အခန်းကဏ္ဍများဖြစ်နိုင်သည်။
- **JWT Authentication** - JSON Web Tokens (JWT) ကို API လုံခြုံစွာ ဝင်ရောက်ခွင့်အတွက် အသုံးပြုခြင်း။ JWT သည် ပါတီများအကြား JSON အရာဝတ္ထုအဖြစ် အချက်အလက်များကို လုံခြုံစွာ ပို့ဆောင်ရန် စံချိန်စံညွှန်းဖြစ်ပြီး ဒစ်ဂျစ်တယ်လက်မှတ်ဖြင့် အတည်ပြုထားသည်။
- **ခွင့်ပြုချက် မူဝါဒများ** - အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ် အခြေခံ၍ ကိရိယာများသို့ ဝင်ရောက်ခွင့် ထိန်းချုပ်ရန် မူဝါဒများ သတ်မှတ်ခြင်း။ MCP သည် အသုံးပြုသူ အခန်းကဏ္ဍများနှင့် claim များအပေါ် အခြေခံ၍ မည်သူက မည်သည့်ကိရိယာကို အသုံးပြုခွင့်ရှိမည်ကို သတ်မှတ်ရန် ခွင့်ပြုချက် မူဝါဒများကို အသုံးပြုသည်။

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

- အသုံးပြုသူ စီမံခန့်ခွဲမှုအတွက် ASP.NET Core Identity ကို ဖွဲ့စည်းထားသည်။
- လုံခြုံသော API ဝင်ရောက်ခွင့်အတွက် JWT authentication ကို စီစဉ်ထားသည်။ Token စစ်ဆေးမှု parameter များ (issuer, audience, signing key) ကို သတ်မှတ်ထားသည်။
- အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ် အခြေခံ၍ ကိရိယာများသို့ ဝင်ရောက်ခွင့် ထိန်းချုပ်ရန် ခွင့်ပြုချက် မူဝါဒများကို သတ်မှတ်ထားသည်။ ဥပမာအားဖြင့် "CanUseAdminTools" မူဝါဒသည် အသုံးပြုသူတွင် "Admin" အခန်းကဏ္ဍ ရှိရမည်ဟု တောင်းဆိုသည်။ "CanUseBasic" မူဝါဒသည် အသုံးပြုသူ အတည်ပြုထားရမည်ဟု တောင်းဆိုသည်။
- MCP ကိရိယာများကို သတ်မှတ်ထားသော ခွင့်ပြုချက်လိုအပ်ချက်များနှင့် အတူ မှတ်ပုံတင်ထားပြီး သင့်တော်သော အခန်းကဏ္ဍရှိ အသုံးပြုသူများသာ ဝင်ရောက်ခွင့်ရှိစေရန် သေချာစေသည်။

### Java Spring Security ပေါင်းစည်းခြင်း

Java အတွက် MCP ဆာဗာများအတွက် လုံခြုံသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းကို အကောင်အထည်ဖော်ရန် Spring Security ကို အသုံးပြုမည်။ Spring Security သည် Spring အက်ပလီကေးရှင်းများနှင့် အဆင်ပြေစွာ ပေါင်းစည်းနိုင်သော လုံခြုံရေး ဖရိမ်ဝတ်တစ်ခုဖြစ်သည်။

အဓိက အယူအဆများမှာ-

- **Spring Security ဖွဲ့စည်းမှု** - အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းအတွက် လုံခြုံရေး ဖွဲ့စည်းမှုများကို သတ်မှတ်ခြင်း။
- **OAuth2 Resource Server** - MCP ကိရိယာများသို့ လုံခြုံစွာ ဝင်ရောက်ခွင့်ရရှိရန် OAuth2 ကို အသုံးပြုခြင်း။ OAuth2 သည် တတိယပါတီ ဝန်ဆောင်မှုများအား လုံခြုံသော API ဝင်ရောက်ခွင့်အတွက် access token များ လဲလှယ်ခွင့်ပြုသည့် ခွင့်ပြုရေး ဖရိမ်ဝတ်ဖြစ်သည်။
- **Security Interceptors** - ကိရိယာများ အကောင်အထည်ဖော်ရာတွင် ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုများကို အကောင်အထည်ဖော်ရန် လုံခြုံရေး အတားအဆီးများကို ထည့်သွင်းဆောင်ရွက်ခြင်း။
- **Role-Based Access Control** - အခန်းကဏ္ဍများကို အသုံးပြု၍ ကိရိယာများနှင့် အရင်းအမြစ်များသို့ ဝင်ရောက်ခွင့် ထိန်းချုပ်ခြင်း။
- **Security Annotations** - နည်းလမ်းများနှင့် endpoint များကို လုံခြုံစေရန် အမှတ်အသားများကို အသုံးပြုခြင်း။

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

- MCP endpoint များကို လုံခြုံစေရန် Spring Security ကို ဖွဲ့စည်းထားပြီး ကိရိယာ ရှာဖွေရေးအတွက် အများပြည်သူ ဝင်ရောက်ခွင့်ပြုထားသော်လည်း ကိရိယာ အကောင်အထည်ဖော်မှုအတွက် အတည်ပြုခြင်း လိုအပ်သည်။
- MCP ကိရိယာများသို့ လုံခြုံစွာ ဝင်ရောက်ခွင့်ရရှိရန် OAuth2 ကို resource server အဖြစ် အသုံးပြုထားသည်။
- ကိရိယာ အကောင်အထည်ဖော်မှုအတွက် ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုများကို အကောင်အထည်ဖော်ရန် လုံခြုံရေး အတားအဆီးကို ထည့်သွင်းထားပြီး အသုံးပြုသူ အခန်းကဏ္ဍများနှင့် ခွင့်ပြုချက်များကို စစ်ဆေးသည်။
- အသုံးပြုသူ အခန်းကဏ္ဍများအပေါ် အခြေခံ၍ admin ကိရိယာများနှင့် အထူးသဖြင့် ဒေတာဝင်ရောက်ခွင့်ကို ကန့်သတ်ထားသည်။

## ဒေတာကာကွယ်မှုနှင့် ကိုယ်ရေးအချက်အလက်လုံခြုံမှု

ဒေတာကာကွယ်မှုသည် အထူးသဖြင့် ကိုယ်ရေးအချက်အလက်များ (PII), ငွေကြေးဆိုင်ရာ ဒေတာများနှင့် အခြား အထူးသဖြင့် ကာကွယ်ရမည့် အချက်အလက်များကို မလိုလားအပ်သော ဝင်ရောက်မှုနှင့် ဖောက်ထွင်းမှုမှ ကာကွယ်ရန် အရေးကြီးသည်။

### Python ဒေတာကာကွယ်မှု ဥပမာ

Python တွင် စကားဝှက်ခြင်းနှင့် PII ရှာဖွေရေးကို အသုံးပြု၍ ဒေတာကာကွယ်မှုကို မည်သို့ အကောင်အထည်ဖော်မည်ကို ဥပမာဖြင့် ကြည့်ကြရအောင်။

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

- စာသားနှင့် ပါရာမီတာများတွင် ကိုယ်ရေးအချက်အလက် (PII) ရှိမရှိ စစ်ဆေးရန် `PiiDetector` class ကို ဖန်တီးထားသည်။
- `cryptography` စာကြည့်တိုက်ကို အသုံးပြု၍ အထူးသဖြင့် ကာကွယ်ရမည့် ဒေတာများကို စကားဝှက်ခြင်းနှင့် ဖွင့်ခြင်းလုပ်ငန်းများကို ကိုင်တွယ်ရန် `EncryptionService` class ကို ဖန်တီးထားသည်။
- ကိရိယာ အကောင်အထည်ဖော်မှုကို PII စစ်ဆေးခြင်း၊ ဝင်ရောက်မှု မှတ်တမ်းတင်ခြင်းနှင့် လိုအပ်ပါက အထူးသဖြင့် ဒေတာများကို စကားဝှက်ခြင်းလုပ်ငန်းများ ပြုလုပ်ရန် `secure_tool` decorator ကို သတ်မှတ်ထားသည်။
- ဥပမာကိရိယာတစ်ခုဖြစ်သည့် `SecureCustomerDataTool` တွင် `secure_tool` decorator ကို အသုံးပြု၍ အထူးသဖြင့် ဒေတာများကို လုံခြုံစွာ ကိုင်တွယ်နိုင်စေရန် သေချာထားသည်။

## MCP အထူး လုံခြုံရေး အန္တရာယ်များ

တရားဝင် MCP လုံခြုံရေး စာတမ်းများအရ MCP အကောင်အထည်ဖော်သူများ သတိပြုရမည့် အထူးလုံခြုံရေး အန္တရာယ်များမှာ-

### 1. Confused Deputy ပြဿနာ

ဤအားနည်းချက်သည် MCP ဆာဗာသည် တတိယပါတီ API များအတွက် proxy အဖြစ် လုပ်ဆောင်သောအခါ ဖြစ်ပေါ်ပြီး တိုက်ခိုက်သူများအား MCP ဆာဗာနှင့် API များအကြား ယုံကြည်မှုဆက်ဆံရေးကို အကျိုးပြုရန် ခွင့်ပြုနိုင်သည်။

**ကာကွယ်ရန်-**
- MCP proxy ဆာဗာများသည် တတိယပါတီ ခွင့်ပြုရေးဆာဗာများသို့ ပို့ဆောင်မည့် မတိုင်မီ တစ်ခုချင်းစီ အလိုအလျောက် မှတ်ပုံတင်ထားသော client များအတွက် အသုံးပြုသူ၏ ထောက်ခံချက် ရယူရမည်။
- ခွင့်ပြုချက် တောင်းဆိုမှုများအတွက် PKCE (Proof Key for Code Exchange) ပါသော OAuth လည်ပတ်မှုကို မှန်ကန်စွာ အကောင်အထည်ဖော်ရန်။
- Redirect URI မ

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။