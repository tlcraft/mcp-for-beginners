<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T22:25:46+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fa"
}
-->
# بهترین شیوه‌های امنیتی

امنیت برای پیاده‌سازی‌های MCP بسیار حیاتی است، به‌ویژه در محیط‌های سازمانی. مهم است که اطمینان حاصل شود ابزارها و داده‌ها در برابر دسترسی غیرمجاز، نشت داده‌ها و تهدیدات امنیتی دیگر محافظت شده‌اند.

## مقدمه

پروتکل مدل کانتکست (MCP) به دلیل نقش خود در فراهم کردن دسترسی LLMها به داده‌ها و ابزارها، نیازمند ملاحظات امنیتی خاصی است. این درس بهترین شیوه‌های امنیتی برای پیاده‌سازی‌های MCP را بر اساس دستورالعمل‌های رسمی MCP و الگوهای امنیتی شناخته‌شده بررسی می‌کند.

MCP اصول کلیدی امنیتی را دنبال می‌کند تا تعاملات ایمن و قابل اعتماد را تضمین کند:

- **رضایت و کنترل کاربر**: کاربران باید پیش از دسترسی به هر داده یا انجام هر عملی، رضایت صریح خود را اعلام کنند. کنترل واضحی بر اینکه چه داده‌هایی به اشتراک گذاشته می‌شود و چه اقداماتی مجاز است، فراهم کنید.
  
- **حریم خصوصی داده‌ها**: داده‌های کاربران تنها با رضایت صریح آنها افشا شود و باید با کنترل‌های دسترسی مناسب محافظت شود. از انتقال غیرمجاز داده‌ها جلوگیری کنید.
  
- **ایمنی ابزارها**: پیش از فراخوانی هر ابزار، رضایت صریح کاربر لازم است. کاربران باید درک روشنی از عملکرد هر ابزار داشته باشند و مرزهای امنیتی قوی باید اعمال شود.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- مکانیزم‌های احراز هویت و مجوزدهی امن برای سرورهای MCP پیاده‌سازی کنید.
- داده‌های حساس را با استفاده از رمزنگاری و ذخیره‌سازی امن محافظت کنید.
- اجرای امن ابزارها را با کنترل‌های دسترسی مناسب تضمین کنید.
- بهترین شیوه‌ها برای حفاظت از داده‌ها و رعایت حریم خصوصی را به کار ببرید.
- آسیب‌پذیری‌های رایج امنیتی MCP مانند مشکلات confused deputy، عبور توکن و ربودن نشست را شناسایی و کاهش دهید.

## احراز هویت و مجوزدهی

احراز هویت و مجوزدهی برای ایمن‌سازی سرورهای MCP ضروری هستند. احراز هویت به سؤال «شما کی هستید؟» پاسخ می‌دهد و مجوزدهی به سؤال «چه کاری می‌توانید انجام دهید؟».

طبق مشخصات امنیتی MCP، این موارد از ملاحظات حیاتی امنیتی هستند:

1. **اعتبارسنجی توکن**: سرورهای MCP نباید هیچ توکنی را بپذیرند که به‌طور صریح برای آن سرور صادر نشده باشد. «عبور توکن» یک الگوی ضد امنیتی ممنوع است.

2. **تأیید مجوزدهی**: سرورهای MCP که مجوزدهی را پیاده‌سازی می‌کنند باید تمام درخواست‌های ورودی را بررسی کنند و نباید از نشست‌ها برای احراز هویت استفاده کنند.

3. **مدیریت امن نشست**: هنگام استفاده از نشست‌ها برای ذخیره وضعیت، سرورهای MCP باید از شناسه‌های نشست امن و غیرقابل پیش‌بینی استفاده کنند که با تولیدکننده‌های عدد تصادفی امن ساخته شده‌اند. شناسه‌های نشست باید به اطلاعات خاص کاربر متصل شوند.

4. **رضایت صریح کاربر**: برای سرورهای پراکسی، پیاده‌سازی‌های MCP باید پیش از ارسال به سرورهای مجوزدهی شخص ثالث، رضایت کاربر را برای هر کلاینت ثبت‌شده پویا دریافت کنند.

بیایید نمونه‌هایی از نحوه پیاده‌سازی احراز هویت و مجوزدهی امن در سرورهای MCP با استفاده از .NET و جاوا را بررسی کنیم.

### ادغام هویت در .NET

ASP .NET Core Identity چارچوب قدرتمندی برای مدیریت احراز هویت و مجوزدهی کاربران فراهم می‌کند. می‌توانیم آن را با سرورهای MCP ادغام کنیم تا دسترسی به ابزارها و منابع را ایمن کنیم.

برخی مفاهیم کلیدی که باید هنگام ادغام ASP.NET Core Identity با سرورهای MCP درک کنیم عبارتند از:

- **پیکربندی هویت**: راه‌اندازی ASP.NET Core Identity با نقش‌ها و ادعاهای کاربر. ادعا اطلاعاتی درباره کاربر است، مانند نقش یا مجوزهای او، مثلاً «مدیر» یا «کاربر».
- **احراز هویت JWT**: استفاده از JSON Web Tokens (JWT) برای دسترسی امن به API. JWT استانداردی برای انتقال امن اطلاعات بین طرفین به صورت یک شیء JSON است که به دلیل امضای دیجیتال قابل تأیید و اعتماد است.
- **سیاست‌های مجوزدهی**: تعریف سیاست‌هایی برای کنترل دسترسی به ابزارهای خاص بر اساس نقش‌های کاربر. MCP از سیاست‌های مجوزدهی برای تعیین اینکه کدام کاربران بر اساس نقش‌ها و ادعاهایشان به کدام ابزارها دسترسی دارند، استفاده می‌کند.

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

در کد بالا:

- ASP.NET Core Identity را برای مدیریت کاربران پیکربندی کرده‌ایم.
- احراز هویت JWT را برای دسترسی امن به API راه‌اندازی کرده‌ایم. پارامترهای اعتبارسنجی توکن شامل صادرکننده، مخاطب و کلید امضا مشخص شده‌اند.
- سیاست‌های مجوزدهی برای کنترل دسترسی به ابزارها بر اساس نقش‌های کاربر تعریف شده‌اند. به عنوان مثال، سیاست «CanUseAdminTools» نیازمند نقش «مدیر» است، در حالی که سیاست «CanUseBasic» نیازمند احراز هویت کاربر است.
- ابزارهای MCP با نیازمندی‌های مجوزدهی خاص ثبت شده‌اند تا فقط کاربران با نقش‌های مناسب به آنها دسترسی داشته باشند.

### ادغام امنیت Spring در جاوا

برای جاوا، از Spring Security برای پیاده‌سازی احراز هویت و مجوزدهی امن در سرورهای MCP استفاده خواهیم کرد. Spring Security چارچوب امنیتی جامعی است که به‌خوبی با برنامه‌های Spring ادغام می‌شود.

مفاهیم کلیدی در اینجا عبارتند از:

- **پیکربندی امنیت Spring**: تنظیمات امنیتی برای احراز هویت و مجوزدهی.
- **سرور منابع OAuth2**: استفاده از OAuth2 برای دسترسی امن به ابزارهای MCP. OAuth2 چارچوب مجوزدهی است که به سرویس‌های شخص ثالث اجازه می‌دهد توکن‌های دسترسی را برای دسترسی امن به API مبادله کنند.
- **میانجی‌های امنیتی**: پیاده‌سازی میانجی‌های امنیتی برای اعمال کنترل‌های دسترسی بر اجرای ابزارها.
- **کنترل دسترسی مبتنی بر نقش**: استفاده از نقش‌ها برای کنترل دسترسی به ابزارها و منابع خاص.
- **حاشیه‌نویسی‌های امنیتی**: استفاده از حاشیه‌نویسی‌ها برای ایمن‌سازی متدها و نقاط انتهایی.

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

در کد بالا:

- Spring Security را برای ایمن‌سازی نقاط انتهایی MCP پیکربندی کرده‌ایم، به‌طوری که کشف ابزارها به صورت عمومی در دسترس است اما اجرای ابزارها نیازمند احراز هویت است.
- از OAuth2 به عنوان سرور منابع برای مدیریت دسترسی امن به ابزارهای MCP استفاده شده است.
- میانجی امنیتی برای اعمال کنترل‌های دسترسی بر اجرای ابزارها پیاده‌سازی شده است، به‌طوری که نقش‌ها و مجوزهای کاربر پیش از اجازه دسترسی به ابزارهای خاص بررسی می‌شوند.
- کنترل دسترسی مبتنی بر نقش برای محدود کردن دسترسی به ابزارهای مدیریتی و داده‌های حساس بر اساس نقش‌های کاربر تعریف شده است.

## حفاظت از داده‌ها و حریم خصوصی

حفاظت از داده‌ها برای اطمینان از اینکه اطلاعات حساس به‌صورت امن مدیریت می‌شوند، حیاتی است. این شامل محافظت از اطلاعات شناسایی شخصی (PII)، داده‌های مالی و سایر اطلاعات حساس در برابر دسترسی غیرمجاز و نشت است.

### نمونه حفاظت از داده‌ها در پایتون

بیایید نمونه‌ای از پیاده‌سازی حفاظت از داده‌ها در پایتون با استفاده از رمزنگاری و شناسایی PII را بررسی کنیم.

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

در کد بالا:

- کلاس `PiiDetector` برای اسکن متن و پارامترها به دنبال اطلاعات شناسایی شخصی (PII) پیاده‌سازی شده است.
- کلاس `EncryptionService` برای رمزنگاری و رمزگشایی داده‌های حساس با استفاده از کتابخانه `cryptography` ایجاد شده است.
- دکوراتور `secure_tool` تعریف شده که اجرای ابزار را در بر می‌گیرد تا وجود PII را بررسی کند، دسترسی را ثبت کند و در صورت نیاز داده‌های حساس را رمزنگاری نماید.
- دکوراتور `secure_tool` روی یک ابزار نمونه (`SecureCustomerDataTool`) اعمال شده تا اطمینان حاصل شود که داده‌های حساس به‌صورت امن مدیریت می‌شوند.

## ریسک‌های امنیتی خاص MCP

طبق مستندات رسمی امنیتی MCP، ریسک‌های امنیتی خاصی وجود دارد که پیاده‌سازان MCP باید از آنها آگاه باشند:

### ۱. مشکل Confused Deputy

این آسیب‌پذیری زمانی رخ می‌دهد که سرور MCP به عنوان پراکسی برای APIهای شخص ثالث عمل می‌کند و ممکن است مهاجمان از رابطه اعتماد بین سرور MCP و این APIها سوءاستفاده کنند.

**کاهش ریسک:**
- سرورهای پراکسی MCP که از شناسه‌های کلاینت ثابت استفاده می‌کنند باید پیش از ارسال به سرورهای مجوزدهی شخص ثالث، رضایت کاربر را برای هر کلاینت ثبت‌شده پویا دریافت کنند.
- جریان OAuth مناسب با PKCE (اثبات کلید برای تبادل کد) برای درخواست‌های مجوزدهی پیاده‌سازی شود.
- URIهای بازگشت و شناسه‌های کلاینت به‌دقت اعتبارسنجی شوند.

### ۲. آسیب‌پذیری‌های عبور توکن

عبور توکن زمانی رخ می‌دهد که سرور MCP توکن‌هایی را از کلاینت MCP بدون اعتبارسنجی اینکه توکن‌ها به‌درستی برای سرور MCP صادر شده‌اند، می‌پذیرد و آنها را به APIهای پایین‌دستی منتقل می‌کند.

### ریسک‌ها
- دور زدن کنترل‌های امنیتی (مانند محدودیت نرخ، اعتبارسنجی درخواست)
- مشکلات پاسخگویی و ردگیری
- نقض مرزهای اعتماد
- ریسک‌های سازگاری آینده

**کاهش ریسک:**
- سرورهای MCP نباید هیچ توکنی را بپذیرند که به‌طور صریح برای آن سرور صادر نشده باشد.
- همیشه ادعاهای مخاطب توکن را اعتبارسنجی کنید تا مطمئن شوید با سرویس مورد انتظار مطابقت دارند.

### ۳. ربودن نشست

این اتفاق زمانی رخ می‌دهد که یک فرد غیرمجاز شناسه نشست را به دست آورده و از آن برای جعل هویت کلاینت اصلی استفاده می‌کند که ممکن است منجر به اقدامات غیرمجاز شود.

**کاهش ریسک:**
- سرورهای MCP که مجوزدهی را پیاده‌سازی می‌کنند باید تمام درخواست‌های ورودی را بررسی کنند و نباید از نشست‌ها برای احراز هویت استفاده کنند.
- از شناسه‌های نشست امن و غیرقابل پیش‌بینی که با تولیدکننده‌های عدد تصادفی امن ساخته شده‌اند استفاده کنید.
- شناسه‌های نشست را به اطلاعات خاص کاربر با قالب کلید مانند `<user_id>:<session_id>` متصل کنید.
- سیاست‌های مناسب برای انقضا و چرخش نشست‌ها پیاده‌سازی کنید.

## بهترین شیوه‌های امنیتی اضافی برای MCP

علاوه بر ملاحظات اصلی امنیتی MCP، این شیوه‌های امنیتی اضافی را نیز در نظر بگیرید:

- **همیشه از HTTPS استفاده کنید**: ارتباط بین کلاینت و سرور را رمزنگاری کنید تا توکن‌ها در برابر رهگیری محافظت شوند.
- **پیاده‌سازی کنترل دسترسی مبتنی بر نقش (RBAC)**: فقط بررسی نکنید که کاربر احراز هویت شده است؛ بلکه بررسی کنید چه مجوزهایی دارد.
- **نظارت و حسابرسی**: تمام رویدادهای احراز هویت را ثبت کنید تا فعالیت‌های مشکوک شناسایی و پاسخ داده شوند.
- **مدیریت محدودیت نرخ و کنترل بار**: از الگوریتم‌های بازگشت نمایی و منطق تلاش مجدد برای مدیریت محدودیت‌های نرخ به‌صورت مؤثر استفاده کنید.
- **ذخیره امن توکن‌ها**: توکن‌های دسترسی و تازه‌سازی را با استفاده از مکانیزم‌های ذخیره‌سازی امن سیستم یا خدمات مدیریت کلید امن ذخیره کنید.
- **استفاده از مدیریت API**: سرویس‌هایی مانند Azure API Management می‌توانند بسیاری از نگرانی‌های امنیتی از جمله احراز هویت، مجوزدهی و محدودیت نرخ را به‌صورت خودکار مدیریت کنند.

## منابع

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## مرحله بعد

- [5.9 جستجوی وب](../web-search-mcp/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.