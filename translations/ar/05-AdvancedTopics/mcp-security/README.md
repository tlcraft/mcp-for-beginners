<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T23:03:43+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ar"
}
-->
# أفضل ممارسات الأمان

الأمان أمر حيوي لتطبيقات MCP، خصوصًا في بيئات المؤسسات. من المهم التأكد من حماية الأدوات والبيانات من الوصول غير المصرح به، وتسريبات البيانات، وغيرها من التهديدات الأمنية.

## المقدمة

في هذا الدرس، سوف نستعرض أفضل ممارسات الأمان لتطبيقات MCP. سنغطي المصادقة والتفويض، حماية البيانات، تنفيذ الأدوات بشكل آمن، والامتثال للوائح خصوصية البيانات.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- تنفيذ آليات مصادقة وتفويض آمنة لخوادم MCP.
- حماية البيانات الحساسة باستخدام التشفير والتخزين الآمن.
- ضمان تنفيذ الأدوات بشكل آمن مع ضوابط وصول مناسبة.
- تطبيق أفضل الممارسات لحماية البيانات والامتثال للخصوصية.

## المصادقة والتفويض

المصادقة والتفويض ضروريان لتأمين خوادم MCP. المصادقة تجيب على سؤال "من أنت؟" بينما التفويض يجيب على "ماذا يمكنك أن تفعل؟".

لننظر إلى أمثلة على كيفية تنفيذ المصادقة والتفويض الآمنين في خوادم MCP باستخدام .NET وJava.

### تكامل هوية .NET

يوفر ASP .NET Core Identity إطارًا قويًا لإدارة مصادقة وتفويض المستخدمين. يمكننا دمجه مع خوادم MCP لتأمين الوصول إلى الأدوات والموارد.

هناك بعض المفاهيم الأساسية التي يجب فهمها عند دمج ASP.NET Core Identity مع خوادم MCP وهي:

- **تكوين الهوية**: إعداد ASP.NET Core Identity مع أدوار المستخدمين والمطالبات. المطالبة هي معلومة عن المستخدم، مثل دوره أو أذوناته، على سبيل المثال "مسؤول" أو "مستخدم".
- **مصادقة JWT**: استخدام رموز JSON Web Tokens (JWT) للوصول الآمن إلى API. JWT هو معيار لنقل المعلومات بأمان بين الأطراف ككائن JSON، يمكن التحقق منه والثقة به لأنه موقع رقميًا.
- **سياسات التفويض**: تعريف سياسات للتحكم في الوصول إلى أدوات محددة بناءً على أدوار المستخدمين. يستخدم MCP سياسات التفويض لتحديد من يمكنه الوصول إلى أي أدوات بناءً على أدوارهم ومطالباتهم.

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
- إعداد مصادقة JWT للوصول الآمن إلى API. حددنا معلمات التحقق من الرمز، بما في ذلك المُصدر، الجمهور، ومفتاح التوقيع.
- تعريف سياسات التفويض للتحكم في الوصول إلى الأدوات بناءً على أدوار المستخدمين. على سبيل المثال، سياسة "CanUseAdminTools" تتطلب أن يكون لدى المستخدم دور "مسؤول"، بينما سياسة "CanUseBasic" تتطلب أن يكون المستخدم مصادقًا عليه.
- تسجيل أدوات MCP مع متطلبات تفويض محددة، لضمان أن المستخدمين ذوي الأدوار المناسبة فقط يمكنهم الوصول إليها.

### تكامل أمان Spring في Java

بالنسبة لـ Java، سنستخدم Spring Security لتنفيذ المصادقة والتفويض الآمنين لخوادم MCP. يوفر Spring Security إطار أمان شامل يتكامل بسلاسة مع تطبيقات Spring.

المفاهيم الأساسية هنا هي:

- **تكوين أمان Spring**: إعداد تكوينات الأمان للمصادقة والتفويض.
- **خادم موارد OAuth2**: استخدام OAuth2 للوصول الآمن إلى أدوات MCP. OAuth2 هو إطار تفويض يسمح للخدمات الخارجية بتبادل رموز الوصول للوصول الآمن إلى API.
- **اعتراضات الأمان**: تنفيذ اعتراضات أمان لفرض ضوابط الوصول على تنفيذ الأدوات.
- **التحكم في الوصول بناءً على الأدوار**: استخدام الأدوار للتحكم في الوصول إلى أدوات وموارد محددة.
- **توضيحات الأمان**: استخدام التوضيحات لتأمين الطرق ونقاط النهاية.

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

- تكوين Spring Security لتأمين نقاط نهاية MCP، مع السماح بالوصول العام لاكتشاف الأدوات مع طلب المصادقة لتنفيذ الأدوات.
- استخدام OAuth2 كخادم موارد للتعامل مع الوصول الآمن إلى أدوات MCP.
- تنفيذ اعتراض أمان لفرض ضوابط الوصول على تنفيذ الأدوات، بالتحقق من أدوار المستخدم وأذوناته قبل السماح بالوصول إلى أدوات محددة.
- تعريف التحكم في الوصول بناءً على الأدوار لتقييد الوصول إلى أدوات الإدارة والوصول إلى البيانات الحساسة بناءً على أدوار المستخدمين.

## حماية البيانات والخصوصية

حماية البيانات ضرورية لضمان التعامل الآمن مع المعلومات الحساسة. يشمل ذلك حماية المعلومات الشخصية (PII)، والبيانات المالية، وغيرها من المعلومات الحساسة من الوصول غير المصرح به والتسريبات.

### مثال حماية البيانات في Python

لننظر إلى مثال على كيفية تنفيذ حماية البيانات في Python باستخدام التشفير واكتشاف PII.

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

- تنفيذ أداة `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) لضمان التعامل الآمن مع البيانات الحساسة.

## ما التالي

- [5.9 Web search](../web-search-mcp/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.