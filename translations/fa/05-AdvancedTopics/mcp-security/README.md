<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:09:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fa"
}
-->
# بهترین شیوه‌های امنیتی

امنیت برای پیاده‌سازی‌های MCP به‌ویژه در محیط‌های سازمانی بسیار حیاتی است. مهم است که اطمینان حاصل کنیم ابزارها و داده‌ها در برابر دسترسی‌های غیرمجاز، نقض داده‌ها و سایر تهدیدات امنیتی محافظت شده‌اند.

## مقدمه

در این درس، بهترین شیوه‌های امنیتی برای پیاده‌سازی‌های MCP را بررسی خواهیم کرد. مباحث شامل احراز هویت و مجوزدهی، حفاظت از داده‌ها، اجرای امن ابزارها و رعایت مقررات حفظ حریم خصوصی داده‌ها خواهد بود.

## اهداف یادگیری

در پایان این درس، قادر خواهید بود:

- مکانیزم‌های امن احراز هویت و مجوزدهی برای سرورهای MCP را پیاده‌سازی کنید.
- داده‌های حساس را با استفاده از رمزنگاری و ذخیره‌سازی امن محافظت کنید.
- اجرای امن ابزارها را با کنترل‌های دسترسی مناسب تضمین کنید.
- بهترین شیوه‌ها را برای حفاظت از داده‌ها و رعایت مقررات حریم خصوصی به کار ببرید.

## احراز هویت و مجوزدهی

احراز هویت و مجوزدهی برای ایمن‌سازی سرورهای MCP ضروری هستند. احراز هویت به سؤال «شما کی هستید؟» پاسخ می‌دهد، در حالی که مجوزدهی پاسخ می‌دهد «چه کاری می‌توانید انجام دهید؟».

بیایید به نمونه‌هایی از نحوه پیاده‌سازی احراز هویت و مجوزدهی امن در سرورهای MCP با استفاده از .NET و Java نگاه کنیم.

### یکپارچه‌سازی هویت .NET

ASP .NET Core Identity چارچوبی قوی برای مدیریت احراز هویت و مجوزدهی کاربران فراهم می‌کند. می‌توانیم آن را با سرورهای MCP ادغام کنیم تا دسترسی به ابزارها و منابع را ایمن کنیم.

برخی مفاهیم کلیدی که باید هنگام ادغام ASP.NET Core Identity با سرورهای MCP درک کنیم عبارتند از:

- **پیکربندی هویت**: تنظیم ASP.NET Core Identity با نقش‌ها و ادعاهای کاربر. ادعا اطلاعاتی درباره کاربر است، مانند نقش یا مجوزهای او، برای مثال «Admin» یا «User».
- **احراز هویت JWT**: استفاده از JSON Web Tokens (JWT) برای دسترسی امن به API. JWT استانداردی برای انتقال امن اطلاعات بین طرف‌ها به صورت یک شیء JSON است که به دلیل امضای دیجیتال قابل تأیید و اعتماد است.
- **سیاست‌های مجوزدهی**: تعریف سیاست‌هایی برای کنترل دسترسی به ابزارهای خاص بر اساس نقش‌های کاربری. MCP از سیاست‌های مجوزدهی برای تعیین اینکه کدام کاربران بر اساس نقش‌ها و ادعاهایشان می‌توانند به کدام ابزارها دسترسی داشته باشند، استفاده می‌کند.

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

در کد بالا، ما:

- ASP.NET Core Identity را برای مدیریت کاربران پیکربندی کرده‌ایم.
- احراز هویت JWT را برای دسترسی امن به API راه‌اندازی کرده‌ایم. پارامترهای اعتبارسنجی توکن شامل صادرکننده، مخاطب و کلید امضا را مشخص کرده‌ایم.
- سیاست‌های مجوزدهی را برای کنترل دسترسی به ابزارها بر اساس نقش‌های کاربری تعریف کرده‌ایم. برای مثال، سیاست "CanUseAdminTools" نیازمند داشتن نقش "Admin" است، در حالی که سیاست "CanUseBasic" نیازمند احراز هویت کاربر است.
- ابزارهای MCP را با الزامات مجوزدهی خاص ثبت کرده‌ایم تا اطمینان حاصل شود فقط کاربران با نقش‌های مناسب می‌توانند به آن‌ها دسترسی داشته باشند.

### یکپارچه‌سازی امنیت Spring در Java

برای Java، از Spring Security برای پیاده‌سازی احراز هویت و مجوزدهی امن برای سرورهای MCP استفاده خواهیم کرد. Spring Security چارچوب امنیتی جامعی ارائه می‌دهد که به‌صورت یکپارچه با برنامه‌های Spring ادغام می‌شود.

مفاهیم کلیدی اینجا عبارتند از:

- **پیکربندی امنیت Spring**: تنظیمات امنیتی برای احراز هویت و مجوزدهی.
- **سرور منبع OAuth2**: استفاده از OAuth2 برای دسترسی امن به ابزارهای MCP. OAuth2 چارچوبی برای مجوزدهی است که به سرویس‌های ثالث اجازه می‌دهد توکن‌های دسترسی را برای دسترسی امن به API تبادل کنند.
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

در کد بالا، ما:

- Spring Security را برای ایمن‌سازی نقاط انتهایی MCP پیکربندی کرده‌ایم، به‌طوری که کشف ابزارها به صورت عمومی قابل دسترسی است ولی اجرای ابزارها نیازمند احراز هویت است.
- از OAuth2 به عنوان سرور منبع برای مدیریت دسترسی امن به ابزارهای MCP استفاده کرده‌ایم.
- میانجی امنیتی را برای اعمال کنترل‌های دسترسی بر اجرای ابزارها پیاده‌سازی کرده‌ایم، به طوری که نقش‌ها و مجوزهای کاربر پیش از اجازه دسترسی به ابزارهای خاص بررسی می‌شوند.
- کنترل دسترسی مبتنی بر نقش را تعریف کرده‌ایم تا دسترسی به ابزارهای مدیریتی و داده‌های حساس بر اساس نقش‌های کاربری محدود شود.

## حفاظت از داده‌ها و حریم خصوصی

حفاظت از داده‌ها برای اطمینان از اینکه اطلاعات حساس به صورت امن مدیریت می‌شوند، حیاتی است. این شامل حفاظت از اطلاعات شناسایی شخصی (PII)، داده‌های مالی و سایر اطلاعات حساس در برابر دسترسی غیرمجاز و نقض داده‌ها است.

### نمونه حفاظت از داده‌ها در Python

بیایید نمونه‌ای از پیاده‌سازی حفاظت از داده‌ها در Python با استفاده از رمزنگاری و تشخیص PII را بررسی کنیم.

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

در کد بالا، ما:

- یک `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` پیاده‌سازی کرده‌ایم تا اطمینان حاصل شود که داده‌های حساس به صورت امن مدیریت می‌شوند.

## مرحله بعد

- [Web search](../web-search-mcp/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نواقص باشند. سند اصلی به زبان مادری خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوء تفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.