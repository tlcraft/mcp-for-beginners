<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:41:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "he"
}
-->
# שיטות עבודה מומלצות לאבטחה

האבטחה קריטית ליישומי MCP, במיוחד בסביבות ארגוניות. חשוב לוודא שכלים ונתונים מוגנים מפני גישה לא מורשית, דליפות מידע ואיומי אבטחה אחרים.

## מבוא

בשיעור זה נחקור שיטות עבודה מומלצות לאבטחה ביישומי MCP. נעסוק באימות והרשאה, הגנת נתונים, הרצת כלים מאובטחת ועמידה בתקנות פרטיות מידע.

## מטרות הלמידה

בסיום השיעור תוכל/י:

- ליישם מנגנוני אימות והרשאה מאובטחים לשרתים של MCP.
- להגן על נתונים רגישים באמצעות הצפנה ואחסון מאובטח.
- להבטיח הרצת כלים מאובטחת עם בקרות גישה מתאימות.
- ליישם שיטות עבודה מומלצות להגנת נתונים ועמידה בתקנות פרטיות.

## אימות והרשאה

אימות והרשאה הם חיוניים לאבטחת שרתי MCP. אימות עונה על השאלה "מי אתה?" בעוד שהרשאה עונה על "מה מותר לך לעשות?".

נבחן דוגמאות ליישום אימות והרשאה מאובטחים בשרתי MCP באמצעות .NET ו-Java.

### אינטגרציה עם .NET Identity

ASP .NET Core Identity מספקת מסגרת חזקה לניהול אימות והרשאת משתמשים. ניתן לשלב אותה עם שרתי MCP כדי לאבטח גישה לכלים ולמשאבים.

יש כמה מושגים מרכזיים שחשוב להבין כשמשלבים ASP.NET Core Identity עם שרתי MCP, ביניהם:

- **הגדרת Identity**: הקמת ASP.NET Core Identity עם תפקידי משתמש וטענות. טענה היא מידע על המשתמש, כמו תפקידו או הרשאותיו, לדוגמה "Admin" או "User".
- **אימות JWT**: שימוש ב-JSON Web Tokens (JWT) לגישה מאובטחת ל-API. JWT הוא תקן להעברת מידע בצורה מאובטחת בין צדדים כאובייקט JSON, שניתן לאמתו ולהסתמך עליו כי הוא חתום דיגיטלית.
- **מדיניות הרשאה**: הגדרת מדיניות לשליטה בגישה לכלים ספציפיים על בסיס תפקידי משתמש. MCP משתמש במדיניות הרשאה כדי לקבוע אילו משתמשים יכולים לגשת לאילו כלים בהתאם לתפקידיהם ולטענותיהם.

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

בקוד שלמעלה:

- הגדרנו את ASP.NET Core Identity לניהול משתמשים.
- הקמנו אימות JWT לגישה מאובטחת ל-API. ציינו את פרמטרי אימות הטוקן, כולל המנפיק, הקהל ומפתח החתימה.
- הגדרנו מדיניות הרשאה לשליטה בגישה לכלים על בסיס תפקידי משתמש. לדוגמה, מדיניות "CanUseAdminTools" דורשת שהמשתמש יהיה בעל תפקיד "Admin", בעוד שמדיניות "CanUseBasic" דורשת שהמשתמש יהיה מאומת.
- רשמנו כלים של MCP עם דרישות הרשאה ספציפיות, כדי לוודא שרק משתמשים עם התפקידים המתאימים יוכלו לגשת אליהם.

### אינטגרציה עם Java Spring Security

ב-Java נשתמש ב-Spring Security ליישום אימות והרשאה מאובטחים לשרתי MCP. Spring Security מספקת מסגרת אבטחה מקיפה שמשתלבת בצורה חלקה עם יישומי Spring.

המושגים המרכזיים כאן הם:

- **הגדרת Spring Security**: הקמת הגדרות אבטחה לאימות והרשאה.
- **OAuth2 Resource Server**: שימוש ב-OAuth2 לגישה מאובטחת לכלי MCP. OAuth2 היא מסגרת הרשאה המאפשרת לשירותים צד שלישי להחליף אסימוני גישה לגישה מאובטחת ל-API.
- **אינטרספטורים לאבטחה**: יישום אינטרספטורים לאכיפת בקרות גישה בהרצת כלים.
- **בקרת גישה מבוססת תפקידים**: שימוש בתפקידים לשליטה בגישה לכלים ולמשאבים ספציפיים.
- **הערות אבטחה**: שימוש בהערות לאבטחת שיטות ונקודות קצה.

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

בקוד שלמעלה:

- הגדרנו את Spring Security לאבטחת נקודות הקצה של MCP, תוך מתן גישה ציבורית לגילוי כלים ודרישת אימות להרצת כלים.
- השתמשנו ב-OAuth2 כשרת משאבים לטיפול בגישה מאובטחת לכלי MCP.
- יישמנו אינטרספטור אבטחה לאכיפת בקרות גישה בהרצת כלים, שבודק תפקידים והרשאות לפני מתן גישה לכלים ספציפיים.
- הגדרנו בקרת גישה מבוססת תפקידים להגבלת גישה לכלי מנהל ולגישה לנתונים רגישים בהתאם לתפקידי המשתמש.

## הגנת נתונים ופרטיות

הגנת נתונים חיונית להבטיח שטיפול במידע רגיש נעשה בצורה מאובטחת. זה כולל הגנה על מידע אישי מזהה (PII), נתונים פיננסיים ומידע רגיש אחר מפני גישה לא מורשית ודליפות.

### דוגמה להגנת נתונים בפייתון

נבחן דוגמה ליישום הגנת נתונים בפייתון באמצעות הצפנה וזיהוי PII.

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

בקוד שלמעלה:

- יישמנו מחלקת `PiiDetector` לסריקת טקסט ופרמטרים לזיהוי מידע אישי מזהה (PII).
- יצרנו מחלקת `EncryptionService` לטיפול בהצפנה ופענוח של נתונים רגישים באמצעות ספריית `cryptography`.
- הגדרנו דקורטור `secure_tool` שעוטף את הרצת הכלי כדי לבדוק PII, לתעד גישה ולהצפין נתונים רגישים במידת הצורך.
- יישמנו את דקורטור `secure_tool` על כלי לדוגמה (`SecureCustomerDataTool`) כדי להבטיח טיפול מאובטח בנתונים רגישים.

## מה הלאה

- [5.9 Web search](../web-search-mcp/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.