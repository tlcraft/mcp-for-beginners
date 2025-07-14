<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:35:35+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fa"
}
-->
# بهترین شیوه‌های امنیتی

امنیت برای پیاده‌سازی‌های MCP بسیار حیاتی است، به‌ویژه در محیط‌های سازمانی. مهم است که ابزارها و داده‌ها در برابر دسترسی غیرمجاز، نشت داده‌ها و تهدیدات امنیتی دیگر محافظت شوند.

## مقدمه

در این درس، بهترین شیوه‌های امنیتی برای پیاده‌سازی‌های MCP را بررسی خواهیم کرد. موضوعاتی مانند احراز هویت و مجوزدهی، حفاظت از داده‌ها، اجرای امن ابزارها و رعایت مقررات حفظ حریم خصوصی داده‌ها را پوشش می‌دهیم.

## اهداف یادگیری

در پایان این درس، قادر خواهید بود:

- مکانیزم‌های امن احراز هویت و مجوزدهی را برای سرورهای MCP پیاده‌سازی کنید.
- داده‌های حساس را با استفاده از رمزنگاری و ذخیره‌سازی امن محافظت کنید.
- اجرای امن ابزارها را با کنترل‌های دسترسی مناسب تضمین کنید.
- بهترین شیوه‌ها را برای حفاظت از داده‌ها و رعایت حریم خصوصی به کار ببرید.

## احراز هویت و مجوزدهی

احراز هویت و مجوزدهی برای ایمن‌سازی سرورهای MCP ضروری هستند. احراز هویت پاسخ به سؤال «شما کی هستید؟» است و مجوزدهی پاسخ به سؤال «چه کاری می‌توانید انجام دهید؟».

بیایید نمونه‌هایی از نحوه پیاده‌سازی احراز هویت و مجوزدهی امن در سرورهای MCP با استفاده از .NET و Java را بررسی کنیم.

### ادغام هویت در .NET

ASP .NET Core Identity چارچوب قدرتمندی برای مدیریت احراز هویت و مجوزدهی کاربران فراهم می‌کند. می‌توانیم آن را با سرورهای MCP ادغام کنیم تا دسترسی به ابزارها و منابع را ایمن کنیم.

برخی مفاهیم کلیدی که هنگام ادغام ASP.NET Core Identity با سرورهای MCP باید درک کنیم عبارتند از:

- **پیکربندی هویت**: راه‌اندازی ASP.NET Core Identity با نقش‌ها و ادعاهای کاربری. ادعا (claim) قطعه‌ای از اطلاعات درباره کاربر است، مانند نقش یا مجوزهای او، مثلاً «Admin» یا «User».
- **احراز هویت JWT**: استفاده از JSON Web Tokens (JWT) برای دسترسی امن به API. JWT استانداردی برای انتقال امن اطلاعات بین طرفین به صورت یک شیء JSON است که به دلیل امضای دیجیتال قابل تأیید و اعتماد است.
- **سیاست‌های مجوزدهی**: تعریف سیاست‌هایی برای کنترل دسترسی به ابزارهای خاص بر اساس نقش‌های کاربری. MCP از سیاست‌های مجوزدهی برای تعیین اینکه کدام کاربران بر اساس نقش‌ها و ادعاهایشان به کدام ابزارها دسترسی دارند، استفاده می‌کند.

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
- احراز هویت JWT را برای دسترسی امن به API راه‌اندازی کرده‌ایم. پارامترهای اعتبارسنجی توکن شامل صادرکننده، مخاطب و کلید امضا را مشخص کردیم.
- سیاست‌های مجوزدهی را برای کنترل دسترسی به ابزارها بر اساس نقش‌های کاربری تعریف کردیم. به عنوان مثال، سیاست «CanUseAdminTools» نیازمند داشتن نقش «Admin» است، در حالی که سیاست «CanUseBasic» نیازمند احراز هویت کاربر است.
- ابزارهای MCP را با نیازمندی‌های مجوزدهی خاص ثبت کردیم تا فقط کاربران با نقش‌های مناسب بتوانند به آن‌ها دسترسی داشته باشند.

### ادغام امنیت Spring در Java

برای Java، از Spring Security برای پیاده‌سازی احراز هویت و مجوزدهی امن در سرورهای MCP استفاده خواهیم کرد. Spring Security چارچوب امنیتی جامعی است که به‌خوبی با برنامه‌های Spring ادغام می‌شود.

مفاهیم کلیدی در اینجا عبارتند از:

- **پیکربندی امنیت Spring**: راه‌اندازی تنظیمات امنیتی برای احراز هویت و مجوزدهی.
- **سرور منابع OAuth2**: استفاده از OAuth2 برای دسترسی امن به ابزارهای MCP. OAuth2 چارچوب مجوزدهی است که به سرویس‌های ثالث اجازه می‌دهد توکن‌های دسترسی را برای دسترسی امن به API مبادله کنند.
- **میانجی‌های امنیتی**: پیاده‌سازی میانجی‌های امنیتی برای اعمال کنترل‌های دسترسی در اجرای ابزارها.
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

- Spring Security را برای ایمن‌سازی نقاط انتهایی MCP پیکربندی کردیم، به‌طوری که کشف ابزارها به صورت عمومی در دسترس باشد و اجرای ابزارها نیازمند احراز هویت باشد.
- از OAuth2 به عنوان سرور منابع برای مدیریت دسترسی امن به ابزارهای MCP استفاده کردیم.
- میانجی امنیتی را برای اعمال کنترل‌های دسترسی در اجرای ابزارها پیاده‌سازی کردیم، به‌طوری که نقش‌ها و مجوزهای کاربر قبل از اجازه دسترسی به ابزارهای خاص بررسی شود.
- کنترل دسترسی مبتنی بر نقش را تعریف کردیم تا دسترسی به ابزارهای مدیریتی و داده‌های حساس بر اساس نقش‌های کاربری محدود شود.

## حفاظت از داده‌ها و حریم خصوصی

حفاظت از داده‌ها برای اطمینان از اینکه اطلاعات حساس به صورت امن مدیریت می‌شوند، بسیار مهم است. این شامل محافظت از اطلاعات شناسایی شخصی (PII)، داده‌های مالی و سایر اطلاعات حساس در برابر دسترسی غیرمجاز و نشت است.

### نمونه حفاظت از داده‌ها در Python

بیایید نمونه‌ای از نحوه پیاده‌سازی حفاظت از داده‌ها در Python با استفاده از رمزنگاری و شناسایی PII را بررسی کنیم.

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

- کلاس `PiiDetector` را برای اسکن متن و پارامترها به منظور شناسایی اطلاعات شناسایی شخصی (PII) پیاده‌سازی کردیم.
- کلاس `EncryptionService` را برای انجام عملیات رمزنگاری و رمزگشایی داده‌های حساس با استفاده از کتابخانه `cryptography` ایجاد کردیم.
- دکوراتور `secure_tool` را تعریف کردیم که اجرای ابزار را در بر می‌گیرد تا وجود PII را بررسی کند، دسترسی را ثبت کند و در صورت نیاز داده‌های حساس را رمزنگاری نماید.
- دکوراتور `secure_tool` را روی یک ابزار نمونه (`SecureCustomerDataTool`) اعمال کردیم تا اطمینان حاصل شود که داده‌های حساس به صورت امن مدیریت می‌شوند.

## مرحله بعد

- [5.9 جستجوی وب](../web-search-mcp/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.