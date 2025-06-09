<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:09:53+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ur"
}
-->
# بہترین حفاظتی طریقے

MCP کے نفاذ میں سیکیورٹی انتہائی اہم ہے، خاص طور پر ادارہ جاتی ماحول میں۔ یہ یقینی بنانا ضروری ہے کہ اوزار اور ڈیٹا غیر مجاز رسائی، ڈیٹا کی خلاف ورزیوں، اور دیگر حفاظتی خطرات سے محفوظ رہیں۔

## تعارف

اس سبق میں، ہم MCP کے نفاذ کے لیے بہترین حفاظتی طریقوں کا جائزہ لیں گے۔ ہم توثیق اور اجازت، ڈیٹا کی حفاظت، محفوظ اوزار کے نفاذ، اور ڈیٹا پرائیویسی قوانین کی تعمیل پر بات کریں گے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- MCP سرورز کے لیے محفوظ توثیق اور اجازت کے طریقے نافذ کرنا۔
- خفیہ کاری اور محفوظ ذخیرہ اندوزی کے ذریعے حساس ڈیٹا کی حفاظت کرنا۔
- مناسب رسائی کنٹرول کے ساتھ اوزار کے محفوظ نفاذ کو یقینی بنانا۔
- ڈیٹا کی حفاظت اور پرائیویسی کی تعمیل کے بہترین طریقے اپنانا۔

## توثیق اور اجازت

توثیق اور اجازت MCP سرورز کو محفوظ بنانے کے لیے لازمی ہیں۔ توثیق سوال کا جواب دیتی ہے "آپ کون ہیں؟" جبکہ اجازت پوچھتی ہے "آپ کیا کر سکتے ہیں؟"۔

آئیے دیکھتے ہیں کہ .NET اور Java استعمال کرتے ہوئے MCP سرورز میں محفوظ توثیق اور اجازت کیسے نافذ کی جاتی ہے۔

### .NET شناختی انضمام

ASP .NET Core Identity ایک مضبوط فریم ورک فراہم کرتا ہے جو صارف کی توثیق اور اجازت کا انتظام کرتا ہے۔ ہم اسے MCP سرورز کے ساتھ مربوط کر سکتے ہیں تاکہ اوزاروں اور وسائل تک محفوظ رسائی یقینی بنائی جا سکے۔

ASP.NET Core Identity کو MCP سرورز کے ساتھ مربوط کرتے وقت ہمیں چند بنیادی تصورات کو سمجھنا ہوگا، جیسے:

- **شناختی ترتیب**: صارف کے کرداروں اور دعوؤں کے ساتھ ASP.NET Core Identity کو ترتیب دینا۔ دعویٰ صارف کے بارے میں معلومات کا ایک ٹکڑا ہوتا ہے، جیسے ان کا کردار یا اجازتیں، مثلاً "Admin" یا "User"۔
- **JWT توثیق**: محفوظ API رسائی کے لیے JSON Web Tokens (JWT) کا استعمال۔ JWT ایک معیاری طریقہ ہے جو معلومات کو JSON آبجیکٹ کی صورت میں محفوظ طریقے سے منتقل کرتا ہے، جس کی تصدیق کی جا سکتی ہے اور یہ ڈیجیٹل طور پر دستخط شدہ ہوتا ہے۔
- **اجازت کی پالیسیاں**: صارف کے کرداروں کی بنیاد پر مخصوص اوزاروں تک رسائی کو کنٹرول کرنے کے لیے پالیسیاں متعین کرنا۔ MCP اجازت کی پالیسیوں کا استعمال کرتا ہے تاکہ یہ تعین کیا جا سکے کہ کون سے صارفین اپنے کرداروں اور دعوؤں کی بنیاد پر کون سے اوزار استعمال کر سکتے ہیں۔

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

پچھلے کوڈ میں، ہم نے:

- صارف کے انتظام کے لیے ASP.NET Core Identity کو ترتیب دیا ہے۔
- محفوظ API رسائی کے لیے JWT توثیق قائم کی ہے۔ ہم نے ٹوکن کی تصدیق کے پیرامیٹرز، بشمول جاری کنندہ، سامعین، اور دستخطی کلید، متعین کی ہیں۔
- صارف کے کرداروں کی بنیاد پر اوزاروں تک رسائی کو کنٹرول کرنے کے لیے اجازت کی پالیسیاں متعین کی ہیں۔ مثلاً، "CanUseAdminTools" پالیسی صارف کے "Admin" کردار کا حامل ہونے کا تقاضا کرتی ہے، جبکہ "CanUseBasic" پالیسی صارف کے توثیق شدہ ہونے کا تقاضا کرتی ہے۔
- مخصوص اجازت کی ضروریات کے ساتھ MCP اوزاروں کو رجسٹر کیا ہے، تاکہ صرف وہ صارفین جن کے پاس مناسب کردار ہوں، انہیں رسائی حاصل ہو۔

### Java Spring Security انضمام

Java کے لیے، ہم MCP سرورز کے لیے محفوظ توثیق اور اجازت نافذ کرنے کے لیے Spring Security استعمال کریں گے۔ Spring Security ایک جامع حفاظتی فریم ورک فراہم کرتا ہے جو Spring ایپلیکیشنز کے ساتھ بخوبی مربوط ہوتا ہے۔

یہاں بنیادی تصورات یہ ہیں:

- **Spring Security ترتیب**: توثیق اور اجازت کے لیے حفاظتی ترتیبات قائم کرنا۔
- **OAuth2 Resource Server**: MCP اوزاروں تک محفوظ رسائی کے لیے OAuth2 کا استعمال۔ OAuth2 ایک اجازت فریم ورک ہے جو تیسری پارٹی کی خدمات کو محفوظ API رسائی کے لیے رسائی ٹوکنز کے تبادلے کی اجازت دیتا ہے۔
- **سیکیورٹی انٹرسپٹرز**: اوزار کے نفاذ پر رسائی کنٹرول کو نافذ کرنے کے لیے سیکیورٹی انٹرسپٹرز کا نفاذ۔
- **کردار کی بنیاد پر رسائی کنٹرول**: مخصوص اوزاروں اور وسائل تک رسائی کو کنٹرول کرنے کے لیے کرداروں کا استعمال۔
- **سیکیورٹی اینوٹیشنز**: طریقوں اور اینڈ پوائنٹس کو محفوظ بنانے کے لیے اینوٹیشنز کا استعمال۔

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

پچھلے کوڈ میں، ہم نے:

- MCP اینڈ پوائنٹس کو محفوظ بنانے کے لیے Spring Security کو ترتیب دیا ہے، اوزار کی دریافت کے لیے عوامی رسائی کی اجازت دیتے ہوئے اوزار کے نفاذ کے لیے توثیق کی ضرورت رکھی ہے۔
- MCP اوزاروں تک محفوظ رسائی کے لیے OAuth2 کو بطور resource server استعمال کیا ہے۔
- اوزار کے نفاذ پر رسائی کنٹرول نافذ کرنے کے لیے سیکیورٹی انٹرسپٹر کا نفاذ کیا ہے، جو مخصوص اوزاروں تک رسائی کی اجازت دینے سے پہلے صارف کے کردار اور اجازتوں کی جانچ کرتا ہے۔
- صارف کے کرداروں کی بنیاد پر ایڈمن اوزاروں اور حساس ڈیٹا تک رسائی کو محدود کرنے کے لیے کردار کی بنیاد پر رسائی کنٹرول متعین کیا ہے۔

## ڈیٹا کی حفاظت اور پرائیویسی

ڈیٹا کی حفاظت اس بات کو یقینی بنانے کے لیے اہم ہے کہ حساس معلومات کو محفوظ طریقے سے سنبھالا جائے۔ اس میں ذاتی شناختی معلومات (PII)، مالیاتی ڈیٹا، اور دیگر حساس معلومات کو غیر مجاز رسائی اور خلاف ورزیوں سے بچانا شامل ہے۔

### Python میں ڈیٹا کی حفاظت کی مثال

آئیے دیکھتے ہیں کہ Python میں خفیہ کاری اور PII کی شناخت کے ذریعے ڈیٹا کی حفاظت کیسے نافذ کی جاتی ہے۔

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

پچھلے کوڈ میں، ہم نے:

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` نافذ کیا ہے تاکہ یہ یقینی بنایا جا سکے کہ یہ حساس ڈیٹا کو محفوظ طریقے سے سنبھالتا ہے۔

## آگے کیا ہے

- [Web search](../web-search-mcp/README.md)

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ذمہ دار نہیں ہیں۔