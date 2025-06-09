<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:09:14+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ar"
}
-->
# أفضل ممارسات الأمان

الأمان أمر حيوي لتطبيقات MCP، خاصة في بيئات المؤسسات. من المهم ضمان حماية الأدوات والبيانات من الوصول غير المصرح به، وتسريبات البيانات، والتهديدات الأمنية الأخرى.

## المقدمة

في هذا الدرس، سوف نستعرض أفضل ممارسات الأمان لتطبيقات MCP. سنغطي المصادقة والتفويض، حماية البيانات، تنفيذ الأدوات بشكل آمن، والامتثال للوائح خصوصية البيانات.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- تنفيذ آليات مصادقة وتفويض آمنة لخوادم MCP.
- حماية البيانات الحساسة باستخدام التشفير والتخزين الآمن.
- ضمان تنفيذ الأدوات بشكل آمن مع ضوابط وصول مناسبة.
- تطبيق أفضل الممارسات لحماية البيانات والامتثال للخصوصية.

## المصادقة والتفويض

المصادقة والتفويض ضروريان لتأمين خوادم MCP. المصادقة تجيب عن سؤال "من أنت؟" بينما التفويض يجيب عن "ماذا يمكنك أن تفعل؟".

لننظر إلى أمثلة على كيفية تنفيذ المصادقة والتفويض الآمن في خوادم MCP باستخدام .NET وJava.

### دمج هوية .NET

يوفر ASP .NET Core Identity إطارًا قويًا لإدارة مصادقة المستخدمين وتفويضهم. يمكننا دمجه مع خوادم MCP لتأمين الوصول إلى الأدوات والموارد.

هناك بعض المفاهيم الأساسية التي نحتاج لفهمها عند دمج ASP.NET Core Identity مع خوادم MCP وهي:

- **تكوين الهوية**: إعداد ASP.NET Core Identity مع أدوار المستخدمين والادعاءات. الادعاء هو قطعة من المعلومات عن المستخدم، مثل دوره أو صلاحياته، على سبيل المثال "Admin" أو "User".
- **مصادقة JWT**: استخدام رموز الويب JSON (JWT) للوصول الآمن إلى واجهات برمجة التطبيقات. JWT هو معيار لنقل المعلومات بأمان بين الأطراف ككائن JSON، يمكن التحقق منه والثقة به لأنه موقع رقميًا.
- **سياسات التفويض**: تحديد السياسات للتحكم في الوصول إلى أدوات معينة بناءً على أدوار المستخدمين. يستخدم MCP سياسات التفويض لتحديد من يمكنه الوصول إلى أي أدوات بناءً على أدوارهم وادعاءاتهم.

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

في الكود السابق، قمنا بـ:

- تكوين ASP.NET Core Identity لإدارة المستخدمين.
- إعداد مصادقة JWT للوصول الآمن إلى واجهات برمجة التطبيقات. حددنا معايير التحقق من الرمز، بما في ذلك المصدر، الجمهور، ومفتاح التوقيع.
- تعريف سياسات التفويض للتحكم في الوصول إلى الأدوات بناءً على أدوار المستخدمين. على سبيل المثال، تتطلب سياسة "CanUseAdminTools" أن يكون للمستخدم دور "Admin"، بينما تتطلب سياسة "CanUseBasic" أن يكون المستخدم مصادقًا.
- تسجيل أدوات MCP مع متطلبات تفويض محددة، لضمان أن المستخدمين الذين لديهم الأدوار المناسبة فقط يمكنهم الوصول إليها.

### دمج أمان Java Spring

بالنسبة لـ Java، سنستخدم Spring Security لتنفيذ مصادقة وتفويض آمن لخوادم MCP. يوفر Spring Security إطار أمان شامل يندمج بسلاسة مع تطبيقات Spring.

المفاهيم الأساسية هنا هي:

- **تكوين أمان Spring**: إعداد تكوينات الأمان للمصادقة والتفويض.
- **خادم موارد OAuth2**: استخدام OAuth2 للوصول الآمن إلى أدوات MCP. OAuth2 هو إطار تفويض يسمح للخدمات الخارجية بتبادل رموز الوصول للوصول الآمن إلى واجهات برمجة التطبيقات.
- **اعتراضات الأمان**: تنفيذ اعتراضات أمان لفرض ضوابط الوصول على تنفيذ الأدوات.
- **التحكم في الوصول بناءً على الدور**: استخدام الأدوار للتحكم في الوصول إلى أدوات وموارد محددة.
- **تعليقات الأمان**: استخدام التعليقات لتأمين الطرق ونقاط النهاية.

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

في الكود السابق، قمنا بـ:

- تكوين Spring Security لتأمين نقاط نهاية MCP، مما يسمح بالوصول العام لاكتشاف الأدوات مع طلب المصادقة لتنفيذ الأدوات.
- استخدام OAuth2 كخادم موارد للتعامل مع الوصول الآمن لأدوات MCP.
- تنفيذ اعتراض أمان لفرض ضوابط الوصول على تنفيذ الأدوات، والتحقق من أدوار وصلاحيات المستخدم قبل السماح بالوصول إلى أدوات معينة.
- تعريف التحكم في الوصول بناءً على الدور لتقييد الوصول إلى أدوات الإدارة والوصول إلى البيانات الحساسة بناءً على أدوار المستخدمين.

## حماية البيانات والخصوصية

حماية البيانات أمر بالغ الأهمية لضمان التعامل الآمن مع المعلومات الحساسة. يشمل ذلك حماية المعلومات الشخصية المحددة (PII)، البيانات المالية، وغيرها من المعلومات الحساسة من الوصول غير المصرح به والتسريبات.

### مثال حماية البيانات في Python

لننظر إلى مثال على كيفية تنفيذ حماية البيانات في Python باستخدام التشفير والكشف عن المعلومات الشخصية.

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

في الكود السابق، قمنا بـ:

- تنفيذ `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) لضمان التعامل الآمن مع البيانات الحساسة.

## ما التالي

- [البحث على الويب](../web-search-mcp/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. بالنسبة للمعلومات الحساسة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.