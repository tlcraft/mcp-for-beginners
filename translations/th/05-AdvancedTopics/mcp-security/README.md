<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:14:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "th"
}
-->
# Security Best Practices

ความปลอดภัยเป็นสิ่งสำคัญสำหรับการใช้งาน MCP โดยเฉพาะในสภาพแวดล้อมองค์กร จำเป็นต้องมั่นใจว่าเครื่องมือและข้อมูลได้รับการปกป้องจากการเข้าถึงโดยไม่ได้รับอนุญาต การรั่วไหลของข้อมูล และภัยคุกคามด้านความปลอดภัยอื่นๆ

## Introduction

ในบทเรียนนี้ เราจะสำรวจแนวทางปฏิบัติที่ดีที่สุดด้านความปลอดภัยสำหรับการใช้งาน MCP โดยครอบคลุมการตรวจสอบตัวตนและการอนุญาต การปกป้องข้อมูล การรันเครื่องมืออย่างปลอดภัย และการปฏิบัติตามข้อกำหนดด้านความเป็นส่วนตัวของข้อมูล

## Learning Objectives

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- นำกลไกการตรวจสอบตัวตนและการอนุญาตที่ปลอดภัยมาใช้กับเซิร์ฟเวอร์ MCP
- ปกป้องข้อมูลที่ละเอียดอ่อนด้วยการเข้ารหัสและการจัดเก็บอย่างปลอดภัย
- รับรองการรันเครื่องมืออย่างปลอดภัยด้วยการควบคุมการเข้าถึงที่เหมาะสม
- ใช้แนวทางปฏิบัติที่ดีที่สุดสำหรับการปกป้องข้อมูลและการปฏิบัติตามข้อกำหนดความเป็นส่วนตัว

## Authentication and Authorization

การตรวจสอบตัวตนและการอนุญาตเป็นสิ่งจำเป็นสำหรับการรักษาความปลอดภัยของเซิร์ฟเวอร์ MCP การตรวจสอบตัวตนตอบคำถามว่า "คุณคือใคร?" ขณะที่การอนุญาตตอบคำถามว่า "คุณทำอะไรได้บ้าง?"

มาดูตัวอย่างการนำการตรวจสอบตัวตนและการอนุญาตที่ปลอดภัยมาใช้กับเซิร์ฟเวอร์ MCP โดยใช้ .NET และ Java กัน

### .NET Identity Integration

ASP .NET Core Identity มีกรอบงานที่แข็งแกร่งสำหรับจัดการการตรวจสอบตัวตนและการอนุญาตของผู้ใช้ เราสามารถผสานรวมกับเซิร์ฟเวอร์ MCP เพื่อรักษาความปลอดภัยในการเข้าถึงเครื่องมือและทรัพยากรต่างๆ

มีแนวคิดหลักที่ต้องเข้าใจเมื่อนำ ASP.NET Core Identity มารวมกับเซิร์ฟเวอร์ MCP ดังนี้:

- **Identity Configuration**: การตั้งค่า ASP.NET Core Identity พร้อมบทบาทผู้ใช้และ claims ซึ่ง claim คือข้อมูลเกี่ยวกับผู้ใช้ เช่น บทบาทหรือสิทธิ์ เช่น "Admin" หรือ "User"
- **JWT Authentication**: การใช้ JSON Web Tokens (JWT) เพื่อเข้าถึง API อย่างปลอดภัย JWT เป็นมาตรฐานสำหรับส่งข้อมูลอย่างปลอดภัยระหว่างฝ่ายต่างๆ ในรูปแบบ JSON ที่สามารถตรวจสอบและเชื่อถือได้เพราะมีการลงลายมือชื่อดิจิทัล
- **Authorization Policies**: การกำหนดนโยบายเพื่อควบคุมการเข้าถึงเครื่องมือเฉพาะตามบทบาทของผู้ใช้ MCP ใช้นโยบายการอนุญาตเพื่อตัดสินใจว่าผู้ใช้คนใดสามารถเข้าถึงเครื่องมือใดตามบทบาทและ claims ของพวกเขา

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

ในโค้ดก่อนหน้านี้ เราได้:

- ตั้งค่า ASP.NET Core Identity สำหรับการจัดการผู้ใช้
- ตั้งค่าการตรวจสอบตัวตนด้วย JWT เพื่อเข้าถึง API อย่างปลอดภัย โดยระบุพารามิเตอร์การตรวจสอบโทเค็น รวมถึง issuer, audience และ signing key
- กำหนดนโยบายการอนุญาตเพื่อควบคุมการเข้าถึงเครื่องมือตามบทบาทของผู้ใช้ เช่น นโยบาย "CanUseAdminTools" ต้องการให้ผู้ใช้มีบทบาท "Admin" ขณะที่นโยบาย "CanUseBasic" ต้องการให้ผู้ใช้ผ่านการตรวจสอบตัวตนแล้ว
- ลงทะเบียนเครื่องมือ MCP พร้อมข้อกำหนดการอนุญาตเฉพาะ เพื่อให้แน่ใจว่ามีเพียงผู้ใช้ที่มีบทบาทเหมาะสมเท่านั้นที่สามารถเข้าถึงได้

### Java Spring Security Integration

สำหรับ Java เราจะใช้ Spring Security เพื่อนำการตรวจสอบตัวตนและการอนุญาตที่ปลอดภัยมาใช้กับเซิร์ฟเวอร์ MCP Spring Security มีกรอบงานความปลอดภัยที่ครอบคลุมและผสานรวมได้อย่างราบรื่นกับแอปพลิเคชัน Spring

แนวคิดหลักมีดังนี้:

- **Spring Security Configuration**: การตั้งค่าคอนฟิกความปลอดภัยสำหรับการตรวจสอบตัวตนและการอนุญาต
- **OAuth2 Resource Server**: การใช้ OAuth2 เพื่อเข้าถึงเครื่องมือ MCP อย่างปลอดภัย OAuth2 เป็นกรอบงานการอนุญาตที่อนุญาตให้บริการภายนอกแลกเปลี่ยน access token เพื่อเข้าถึง API อย่างปลอดภัย
- **Security Interceptors**: การใช้งานตัวดักจับความปลอดภัยเพื่อบังคับใช้การควบคุมการเข้าถึงในการรันเครื่องมือ
- **Role-Based Access Control**: การใช้บทบาทในการควบคุมการเข้าถึงเครื่องมือและทรัพยากรเฉพาะ
- **Security Annotations**: การใช้ annotation เพื่อรักษาความปลอดภัยของเมธอดและ endpoint

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

ในโค้ดก่อนหน้านี้ เราได้:

- ตั้งค่า Spring Security เพื่อรักษาความปลอดภัยของ MCP endpoints โดยอนุญาตให้เข้าถึงสาธารณะสำหรับการค้นหาเครื่องมือ แต่ต้องตรวจสอบตัวตนก่อนรันเครื่องมือ
- ใช้ OAuth2 ในฐานะ resource server เพื่อจัดการการเข้าถึงเครื่องมือ MCP อย่างปลอดภัย
- นำ security interceptor มาใช้เพื่อบังคับการควบคุมการเข้าถึงในการรันเครื่องมือ ตรวจสอบบทบาทและสิทธิ์ของผู้ใช้ก่อนอนุญาตให้เข้าถึงเครื่องมือเฉพาะ
- กำหนดการควบคุมการเข้าถึงตามบทบาทเพื่อจำกัดการเข้าถึงเครื่องมือผู้ดูแลระบบและข้อมูลที่ละเอียดอ่อนตามบทบาทของผู้ใช้

## Data Protection and Privacy

การปกป้องข้อมูลเป็นสิ่งสำคัญเพื่อให้แน่ใจว่าข้อมูลที่ละเอียดอ่อนได้รับการจัดการอย่างปลอดภัย ซึ่งรวมถึงการปกป้องข้อมูลส่วนบุคคล (PII) ข้อมูลทางการเงิน และข้อมูลสำคัญอื่นๆ จากการเข้าถึงโดยไม่ได้รับอนุญาตและการรั่วไหล

### Python Data Protection Example

มาดูตัวอย่างการนำการปกป้องข้อมูลใน Python มาใช้ด้วยการเข้ารหัสและการตรวจจับ PII

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

ในโค้ดก่อนหน้านี้ เราได้:

- นำ `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` มาใช้เพื่อให้แน่ใจว่าสามารถจัดการข้อมูลที่ละเอียดอ่อนได้อย่างปลอดภัย

## What's next

- [Web search](../web-search-mcp/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นฉบับควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้