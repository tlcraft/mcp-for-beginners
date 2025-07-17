<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T23:47:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ur"
}
-->
# سیکیورٹی کے بہترین طریقے

MCP کی تنصیبات کے لیے سیکیورٹی انتہائی اہم ہے، خاص طور پر انٹرپرائز ماحول میں۔ یہ ضروری ہے کہ ٹولز اور ڈیٹا کو غیر مجاز رسائی، ڈیٹا لیک اور دیگر سیکیورٹی خطرات سے محفوظ رکھا جائے۔

## تعارف

Model Context Protocol (MCP) کو خاص سیکیورٹی پہلوؤں کی ضرورت ہوتی ہے کیونکہ یہ LLMs کو ڈیٹا اور ٹولز تک رسائی فراہم کرتا ہے۔ یہ سبق MCP کی تنصیبات کے لیے سرکاری MCP رہنما اصولوں اور قائم شدہ سیکیورٹی پیٹرنز کی بنیاد پر سیکیورٹی کے بہترین طریقوں کا جائزہ لیتا ہے۔

MCP محفوظ اور قابل اعتماد تعاملات کو یقینی بنانے کے لیے اہم سیکیورٹی اصولوں کی پیروی کرتا ہے:

- **صارف کی رضامندی اور کنٹرول**: کسی بھی ڈیٹا تک رسائی یا آپریشن کرنے سے پہلے صارف کی واضح رضامندی ضروری ہے۔ واضح کنٹرول فراہم کریں کہ کون سا ڈیٹا شیئر کیا جائے اور کون سے اقدامات کی اجازت دی گئی ہے۔
  
- **ڈیٹا کی رازداری**: صارف کا ڈیٹا صرف واضح رضامندی کے ساتھ ظاہر کیا جانا چاہیے اور مناسب رسائی کنٹرولز کے ذریعے محفوظ ہونا چاہیے۔ غیر مجاز ڈیٹا کی منتقلی سے بچاؤ کریں۔
  
- **ٹول کی حفاظت**: کسی بھی ٹول کو استعمال کرنے سے پہلے صارف کی واضح رضامندی ضروری ہے۔ صارفین کو ہر ٹول کی فعالیت کا واضح ادراک ہونا چاہیے، اور مضبوط سیکیورٹی حدود نافذ کی جانی چاہئیں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام پر، آپ قابل ہوں گے:

- MCP سرورز کے لیے محفوظ توثیق اور اجازت کے طریقے نافذ کرنا۔
- حساس ڈیٹا کو انکرپشن اور محفوظ ذخیرہ کے ذریعے محفوظ بنانا۔
- مناسب رسائی کنٹرولز کے ساتھ ٹولز کی محفوظ عمل درآمد کو یقینی بنانا۔
- ڈیٹا کی حفاظت اور رازداری کی تعمیل کے بہترین طریقے اپنانا۔
- عام MCP سیکیورٹی کمزوریوں جیسے confused deputy مسائل، token passthrough، اور session hijacking کی شناخت اور ان کا سدباب کرنا۔

## توثیق اور اجازت

توثیق اور اجازت MCP سرورز کو محفوظ بنانے کے لیے ضروری ہیں۔ توثیق سوال کا جواب دیتی ہے "آپ کون ہیں؟" جبکہ اجازت کا جواب ہے "آپ کیا کر سکتے ہیں؟"۔

MCP سیکیورٹی وضاحت کے مطابق، یہ اہم سیکیورٹی پہلو ہیں:

1. **ٹوکن کی تصدیق**: MCP سرورز کو وہ ٹوکن قبول نہیں کرنے چاہئیں جو واضح طور پر MCP سرور کے لیے جاری نہیں کیے گئے ہوں۔ "Token passthrough" ایک واضح ممنوعہ اینٹی پیٹرن ہے۔

2. **اجازت کی تصدیق**: MCP سرورز جو اجازت نافذ کرتے ہیں، انہیں تمام آنے والی درخواستوں کی تصدیق کرنی چاہیے اور توثیق کے لیے سیشنز استعمال نہیں کرنے چاہئیں۔

3. **محفوظ سیشن مینجمنٹ**: جب سٹیٹ کے لیے سیشنز استعمال کیے جائیں، MCP سرورز کو محفوظ، غیر متعین سیشن IDs استعمال کرنی چاہئیں جو محفوظ رینڈم نمبر جنریٹرز سے بنائی گئی ہوں۔ سیشن IDs کو صارف کی مخصوص معلومات سے منسلک کیا جانا چاہیے۔

4. **واضح صارف کی رضامندی**: پراکسی سرورز کے لیے، MCP تنصیبات کو ہر متحرک طور پر رجسٹرڈ کلائنٹ کے لیے صارف کی رضامندی حاصل کرنی چاہیے اس سے پہلے کہ وہ تیسری پارٹی کے اجازت سرورز کو فارورڈ کریں۔

آئیے دیکھتے ہیں کہ .NET اور Java میں MCP سرورز کے لیے محفوظ توثیق اور اجازت کیسے نافذ کی جاتی ہے۔

### .NET Identity انٹیگریشن

ASP .NET Core Identity صارف کی توثیق اور اجازت کے انتظام کے لیے ایک مضبوط فریم ورک فراہم کرتا ہے۔ ہم اسے MCP سرورز کے ساتھ انٹیگریٹ کر کے ٹولز اور وسائل تک محفوظ رسائی یقینی بنا سکتے ہیں۔

ASP.NET Core Identity کو MCP سرورز کے ساتھ انٹیگریٹ کرتے وقت ہمیں چند بنیادی تصورات سمجھنے ہوں گے:

- **Identity کنفیگریشن**: ASP.NET Core Identity کو صارف کے کرداروں اور دعوؤں کے ساتھ سیٹ اپ کرنا۔ دعویٰ صارف کے بارے میں معلومات کا ایک ٹکڑا ہوتا ہے، جیسے ان کا کردار یا اجازتیں، مثلاً "Admin" یا "User"۔
- **JWT توثیق**: JSON Web Tokens (JWT) کا استعمال کرتے ہوئے محفوظ API رسائی۔ JWT ایک معیاری طریقہ ہے جس سے معلومات کو JSON آبجیکٹ کی صورت میں محفوظ طریقے سے منتقل کیا جاتا ہے، جس کی تصدیق اور اعتماد ڈیجیٹل دستخط کی وجہ سے ممکن ہے۔
- **اجازت کی پالیسیاں**: صارف کے کرداروں کی بنیاد پر مخصوص ٹولز تک رسائی کو کنٹرول کرنے کے لیے پالیسیاں متعین کرنا۔ MCP اجازت کی پالیسیاں استعمال کرتا ہے تاکہ یہ تعین کیا جا سکے کہ کون سے صارفین کن ٹولز تک ان کے کرداروں اور دعوؤں کی بنیاد پر رسائی حاصل کر سکتے ہیں۔

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

مندرجہ بالا کوڈ میں، ہم نے:

- صارف کے انتظام کے لیے ASP.NET Core Identity کو کنفیگر کیا۔
- محفوظ API رسائی کے لیے JWT توثیق سیٹ کی۔ ہم نے ٹوکن کی تصدیق کے پیرامیٹرز، بشمول issuer، audience، اور signing key، متعین کیے۔
- صارف کے کرداروں کی بنیاد پر ٹولز تک رسائی کو کنٹرول کرنے کے لیے اجازت کی پالیسیاں متعین کیں۔ مثلاً، "CanUseAdminTools" پالیسی کے لیے صارف کا "Admin" کردار ہونا ضروری ہے، جبکہ "CanUseBasic" پالیسی کے لیے صارف کا توثیق شدہ ہونا ضروری ہے۔
- MCP ٹولز کو مخصوص اجازت کی ضروریات کے ساتھ رجسٹر کیا، تاکہ صرف مناسب کردار رکھنے والے صارفین ہی ان تک رسائی حاصل کر سکیں۔

### Java Spring Security انٹیگریشن

Java کے لیے، ہم MCP سرورز کے لیے محفوظ توثیق اور اجازت نافذ کرنے کے لیے Spring Security استعمال کریں گے۔ Spring Security ایک جامع سیکیورٹی فریم ورک فراہم کرتا ہے جو Spring ایپلیکیشنز کے ساتھ بخوبی انٹیگریٹ ہوتا ہے۔

یہاں بنیادی تصورات یہ ہیں:

- **Spring Security کنفیگریشن**: توثیق اور اجازت کے لیے سیکیورٹی کنفیگریشنز سیٹ کرنا۔
- **OAuth2 Resource Server**: MCP ٹولز تک محفوظ رسائی کے لیے OAuth2 کا استعمال۔ OAuth2 ایک اجازت فریم ورک ہے جو تیسری پارٹی کی خدمات کو محفوظ API رسائی کے لیے ٹوکنز کے تبادلے کی اجازت دیتا ہے۔
- **سیکیورٹی انٹرسیپٹرز**: ٹول کی عمل درآمد پر رسائی کنٹرولز نافذ کرنے کے لیے سیکیورٹی انٹرسیپٹرز کا نفاذ۔
- **کردار کی بنیاد پر رسائی کنٹرول**: مخصوص ٹولز اور وسائل تک رسائی کو کنٹرول کرنے کے لیے کرداروں کا استعمال۔
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

مندرجہ بالا کوڈ میں، ہم نے:

- MCP اینڈ پوائنٹس کو محفوظ بنانے کے لیے Spring Security کو کنفیگر کیا، ٹول کی دریافت کے لیے عوامی رسائی کی اجازت دی جبکہ ٹول کی عمل درآمد کے لیے توثیق ضروری بنائی۔
- MCP ٹولز تک محفوظ رسائی کے لیے OAuth2 کو resource server کے طور پر استعمال کیا۔
- ٹول کی عمل درآمد پر رسائی کنٹرولز نافذ کرنے کے لیے سیکیورٹی انٹرسیپٹر کا نفاذ کیا، صارف کے کردار اور اجازتوں کی جانچ کی تاکہ مخصوص ٹولز تک رسائی کی اجازت دی جا سکے۔
- کردار کی بنیاد پر رسائی کنٹرول متعین کیا تاکہ ایڈمن ٹولز اور حساس ڈیٹا تک رسائی کو صارف کے کردار کی بنیاد پر محدود کیا جا سکے۔

## ڈیٹا کی حفاظت اور رازداری

ڈیٹا کی حفاظت اس بات کو یقینی بنانے کے لیے ضروری ہے کہ حساس معلومات کو محفوظ طریقے سے ہینڈل کیا جائے۔ اس میں ذاتی شناختی معلومات (PII)، مالیاتی ڈیٹا، اور دیگر حساس معلومات کو غیر مجاز رسائی اور لیک سے بچانا شامل ہے۔

### Python میں ڈیٹا پروٹیکشن کی مثال

آئیے دیکھتے ہیں کہ Python میں انکرپشن اور PII کی شناخت کے ذریعے ڈیٹا کی حفاظت کیسے کی جاتی ہے۔

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

مندرجہ بالا کوڈ میں، ہم نے:

- `PiiDetector` کلاس نافذ کی جو متن اور پیرامیٹرز میں ذاتی شناختی معلومات (PII) کی جانچ کرتی ہے۔
- `EncryptionService` کلاس بنائی جو `cryptography` لائبریری کا استعمال کرتے ہوئے حساس ڈیٹا کی انکرپشن اور ڈکرپشن کا انتظام کرتی ہے۔
- `secure_tool` ڈیکوریٹر متعین کیا جو ٹول کی عمل درآمد کو لپیٹتا ہے تاکہ PII کی جانچ کرے، رسائی کو لاگ کرے، اور ضرورت پڑنے پر حساس ڈیٹا کو انکرپٹ کرے۔
- `secure_tool` ڈیکوریٹر کو ایک نمونہ ٹول (`SecureCustomerDataTool`) پر لاگو کیا تاکہ یہ یقینی بنایا جا سکے کہ یہ حساس ڈیٹا کو محفوظ طریقے سے ہینڈل کرتا ہے۔

## MCP سے متعلق مخصوص سیکیورٹی خطرات

سرکاری MCP سیکیورٹی دستاویزات کے مطابق، MCP کے نفاذ کرنے والوں کو چند مخصوص سیکیورٹی خطرات سے آگاہ ہونا چاہیے:

### 1. Confused Deputy مسئلہ

یہ کمزوری اس وقت پیش آتی ہے جب MCP سرور تیسری پارٹی کے APIs کے لیے پراکسی کے طور پر کام کرتا ہے، جس سے حملہ آور MCP سرور اور ان APIs کے درمیان اعتماد کے تعلقات کا غلط فائدہ اٹھا سکتے ہیں۔

**سدباب:**
- MCP پراکسی سرورز جو static client IDs استعمال کرتے ہیں، انہیں ہر متحرک طور پر رجسٹرڈ کلائنٹ کے لیے صارف کی رضامندی حاصل کرنی چاہیے اس سے پہلے کہ وہ تیسری پارٹی کے اجازت سرورز کو فارورڈ کریں۔
- اجازت کی درخواستوں کے لیے PKCE (Proof Key for Code Exchange) کے ساتھ مناسب OAuth فلو نافذ کریں۔
- redirect URIs اور client identifiers کی سختی سے تصدیق کریں۔

### 2. Token Passthrough کی کمزوریاں

Token passthrough اس وقت ہوتا ہے جب MCP سرور MCP کلائنٹ سے ٹوکن قبول کرتا ہے بغیر اس کی تصدیق کیے کہ یہ ٹوکنز MCP سرور کے لیے صحیح طریقے سے جاری کیے گئے ہیں اور انہیں نیچے کے APIs کو فارورڈ کر دیتا ہے۔

### خطرات
- سیکیورٹی کنٹرولز کا چالاکی سے چکمہ دینا (rate limiting، request validation کو بائی پاس کرنا)
- جوابدہی اور آڈٹ ٹریل کے مسائل
- اعتماد کی حدود کی خلاف ورزی
- مستقبل کی مطابقت کے خطرات

**سدباب:**
- MCP سرورز کو وہ ٹوکن قبول نہیں کرنے چاہئیں جو واضح طور پر MCP سرور کے لیے جاری نہیں کیے گئے ہوں۔
- ہمیشہ ٹوکن کے audience دعوے کی تصدیق کریں تاکہ یہ یقینی بنایا جا سکے کہ وہ متوقع سروس سے میل کھاتے ہیں۔

### 3. سیشن ہائی جیکنگ

یہ اس وقت ہوتا ہے جب کوئی غیر مجاز فریق سیشن ID حاصل کر لیتا ہے اور اسے اصل کلائنٹ کے طور پر ظاہر کرتا ہے، جس سے غیر مجاز کارروائیاں ہو سکتی ہیں۔

**سدباب:**
- MCP سرورز جو اجازت نافذ کرتے ہیں، انہیں تمام آنے والی درخواستوں کی تصدیق کرنی چاہیے اور توثیق کے لیے سیشنز استعمال نہیں کرنے چاہئیں۔
- محفوظ، غیر متعین سیشن IDs استعمال کریں جو محفوظ رینڈم نمبر جنریٹرز سے بنائی گئی ہوں۔
- سیشن IDs کو صارف کی مخصوص معلومات سے منسلک کریں، جیسے `<user_id>:<session_id>` کی شکل میں۔
- مناسب سیشن کی میعاد ختم ہونے اور گردش کی پالیسیاں نافذ کریں۔

## MCP کے لیے اضافی سیکیورٹی کے بہترین طریقے

بنیادی MCP سیکیورٹی پہلوؤں کے علاوہ، ان اضافی سیکیورٹی طریقوں پر غور کریں:

- **ہمیشہ HTTPS استعمال کریں**: کلائنٹ اور سرور کے درمیان مواصلات کو انکرپٹ کریں تاکہ ٹوکنز کو مداخلت سے بچایا جا سکے۔
- **کردار کی بنیاد پر رسائی کنٹرول (RBAC) نافذ کریں**: صرف یہ نہ دیکھیں کہ صارف توثیق شدہ ہے، بلکہ یہ بھی چیک کریں کہ اسے کیا کرنے کی اجازت ہے۔
- **مانیٹر اور آڈٹ کریں**: تمام توثیقی واقعات کو لاگ کریں تاکہ مشکوک سرگرمی کا پتہ لگایا جا سکے اور اس کا جواب دیا جا سکے۔
- **ریٹ لمٹنگ اور تھروٹلنگ کو سنبھالیں**: ریٹ لمٹس کو مؤثر طریقے سے سنبھالنے کے لیے exponential backoff اور retry لاجک نافذ کریں۔
- **ٹوکنز کو محفوظ طریقے سے ذخیرہ کریں**: access tokens اور refresh tokens کو سسٹم کے محفوظ ذخیرہ یا محفوظ کی مینجمنٹ سروسز کے ذریعے محفوظ رکھیں۔
- **API مینجمنٹ کا استعمال کریں**: Azure API Management جیسی خدمات بہت سے سیکیورٹی مسائل کو خودکار طریقے سے سنبھال سکتی ہیں، بشمول توثیق، اجازت، اور ریٹ لمٹنگ۔

## حوالہ جات

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## آگے کیا ہے

- [5.9 Web search](../web-search-mcp/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔