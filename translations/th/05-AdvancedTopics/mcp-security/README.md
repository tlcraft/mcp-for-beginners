<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:40:14+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "th"
}
-->
# แนวทางปฏิบัติด้านความปลอดภัยที่ดีที่สุด

ความปลอดภัยเป็นสิ่งสำคัญสำหรับการใช้งาน MCP โดยเฉพาะในสภาพแวดล้อมองค์กร จำเป็นต้องมั่นใจว่าเครื่องมือและข้อมูลได้รับการปกป้องจากการเข้าถึงโดยไม่ได้รับอนุญาต การรั่วไหลของข้อมูล และภัยคุกคามด้านความปลอดภัยอื่นๆ

## บทนำ

ในบทเรียนนี้ เราจะสำรวจแนวทางปฏิบัติด้านความปลอดภัยที่ดีที่สุดสำหรับการใช้งาน MCP โดยจะครอบคลุมเรื่องการตรวจสอบสิทธิ์และการอนุญาต การปกป้องข้อมูล การใช้งานเครื่องมืออย่างปลอดภัย และการปฏิบัติตามกฎระเบียบด้านความเป็นส่วนตัวของข้อมูล

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- นำกลไกการตรวจสอบสิทธิ์และการอนุญาตที่ปลอดภัยไปใช้กับเซิร์ฟเวอร์ MCP
- ปกป้องข้อมูลที่ละเอียดอ่อนด้วยการเข้ารหัสและการจัดเก็บอย่างปลอดภัย
- รับประกันการใช้งานเครื่องมืออย่างปลอดภัยด้วยการควบคุมการเข้าถึงที่เหมาะสม
- นำแนวทางปฏิบัติที่ดีที่สุดสำหรับการปกป้องข้อมูลและการปฏิบัติตามข้อกำหนดความเป็นส่วนตัวไปใช้

## การตรวจสอบสิทธิ์และการอนุญาต

การตรวจสอบสิทธิ์และการอนุญาตเป็นสิ่งจำเป็นสำหรับการรักษาความปลอดภัยของเซิร์ฟเวอร์ MCP การตรวจสอบสิทธิ์ตอบคำถามว่า "คุณคือใคร?" ขณะที่การอนุญาตตอบคำถามว่า "คุณทำอะไรได้บ้าง?"

มาดูตัวอย่างการใช้งานการตรวจสอบสิทธิ์และการอนุญาตที่ปลอดภัยในเซิร์ฟเวอร์ MCP ด้วย .NET และ Java กัน

### การผสานรวม .NET Identity

ASP .NET Core Identity มีกรอบงานที่แข็งแกร่งสำหรับการจัดการการตรวจสอบสิทธิ์และการอนุญาตของผู้ใช้ เราสามารถผสานรวมกับเซิร์ฟเวอร์ MCP เพื่อรักษาความปลอดภัยในการเข้าถึงเครื่องมือและทรัพยากรต่างๆ

มีแนวคิดหลักที่ต้องเข้าใจเมื่อผสานรวม ASP.NET Core Identity กับเซิร์ฟเวอร์ MCP ได้แก่:

- **การกำหนดค่า Identity**: การตั้งค่า ASP.NET Core Identity พร้อมบทบาทและสิทธิ์ของผู้ใช้ โดยสิทธิ์ (claim) คือข้อมูลเกี่ยวกับผู้ใช้ เช่น บทบาทหรือสิทธิ์ เช่น "Admin" หรือ "User"
- **การตรวจสอบสิทธิ์ JWT**: การใช้ JSON Web Tokens (JWT) สำหรับการเข้าถึง API อย่างปลอดภัย JWT เป็นมาตรฐานสำหรับการส่งข้อมูลอย่างปลอดภัยระหว่างฝ่ายต่างๆ ในรูปแบบ JSON ที่สามารถตรวจสอบและเชื่อถือได้เพราะมีลายเซ็นดิจิทัล
- **นโยบายการอนุญาต**: การกำหนดนโยบายเพื่อควบคุมการเข้าถึงเครื่องมือเฉพาะตามบทบาทของผู้ใช้ MCP ใช้นโยบายการอนุญาตเพื่อกำหนดว่าผู้ใช้คนใดสามารถเข้าถึงเครื่องมือใดได้บ้างตามบทบาทและสิทธิ์ของพวกเขา

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

ในโค้ดข้างต้น เราได้:

- กำหนดค่า ASP.NET Core Identity สำหรับการจัดการผู้ใช้
- ตั้งค่าการตรวจสอบสิทธิ์ JWT เพื่อการเข้าถึง API อย่างปลอดภัย โดยระบุพารามิเตอร์การตรวจสอบโทเค็น เช่น ผู้ออก (issuer), ผู้รับ (audience) และกุญแจสำหรับการลงนาม
- กำหนดนโยบายการอนุญาตเพื่อควบคุมการเข้าถึงเครื่องมือตามบทบาทของผู้ใช้ เช่น นโยบาย "CanUseAdminTools" ต้องการให้ผู้ใช้มีบทบาท "Admin" ขณะที่นโยบาย "CanUseBasic" ต้องการให้ผู้ใช้ผ่านการตรวจสอบสิทธิ์แล้ว
- ลงทะเบียนเครื่องมือ MCP พร้อมข้อกำหนดการอนุญาตเฉพาะ เพื่อให้แน่ใจว่ามีเพียงผู้ใช้ที่มีบทบาทเหมาะสมเท่านั้นที่สามารถเข้าถึงได้

### การผสานรวม Java Spring Security

สำหรับ Java เราจะใช้ Spring Security เพื่อใช้งานการตรวจสอบสิทธิ์และการอนุญาตอย่างปลอดภัยสำหรับเซิร์ฟเวอร์ MCP Spring Security มีกรอบงานความปลอดภัยที่ครอบคลุมและผสานรวมได้อย่างราบรื่นกับแอปพลิเคชัน Spring

แนวคิดหลักที่นี่คือ:

- **การกำหนดค่า Spring Security**: การตั้งค่าความปลอดภัยสำหรับการตรวจสอบสิทธิ์และการอนุญาต
- **OAuth2 Resource Server**: การใช้ OAuth2 สำหรับการเข้าถึงเครื่องมือ MCP อย่างปลอดภัย OAuth2 เป็นกรอบการอนุญาตที่อนุญาตให้บริการภายนอกแลกเปลี่ยนโทเค็นการเข้าถึงเพื่อเข้าถึง API อย่างปลอดภัย
- **Security Interceptors**: การใช้งานตัวดักจับความปลอดภัยเพื่อบังคับใช้การควบคุมการเข้าถึงในการใช้งานเครื่องมือ
- **การควบคุมการเข้าถึงตามบทบาท**: การใช้บทบาทเพื่อควบคุมการเข้าถึงเครื่องมือและทรัพยากรเฉพาะ
- **Security Annotations**: การใช้คำอธิบายประกอบเพื่อรักษาความปลอดภัยของเมธอดและจุดสิ้นสุด

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

ในโค้ดข้างต้น เราได้:

- กำหนดค่า Spring Security เพื่อรักษาความปลอดภัยของจุดสิ้นสุด MCP โดยอนุญาตให้เข้าถึงการค้นหาเครื่องมือได้แบบสาธารณะ แต่ต้องตรวจสอบสิทธิ์ก่อนใช้งานเครื่องมือ
- ใช้ OAuth2 เป็น resource server เพื่อจัดการการเข้าถึงเครื่องมือ MCP อย่างปลอดภัย
- ใช้ security interceptor เพื่อบังคับใช้การควบคุมการเข้าถึงในการใช้งานเครื่องมือ โดยตรวจสอบบทบาทและสิทธิ์ของผู้ใช้ก่อนอนุญาตให้เข้าถึงเครื่องมือเฉพาะ
- กำหนดการควบคุมการเข้าถึงตามบทบาทเพื่อจำกัดการเข้าถึงเครื่องมือผู้ดูแลระบบและข้อมูลที่ละเอียดอ่อนตามบทบาทของผู้ใช้

## การปกป้องข้อมูลและความเป็นส่วนตัว

การปกป้องข้อมูลเป็นสิ่งสำคัญเพื่อให้แน่ใจว่าข้อมูลที่ละเอียดอ่อนได้รับการจัดการอย่างปลอดภัย ซึ่งรวมถึงการปกป้องข้อมูลส่วนบุคคล (PII) ข้อมูลทางการเงิน และข้อมูลสำคัญอื่นๆ จากการเข้าถึงโดยไม่ได้รับอนุญาตและการรั่วไหล

### ตัวอย่างการปกป้องข้อมูลใน Python

มาดูตัวอย่างการใช้งานการปกป้องข้อมูลใน Python ด้วยการเข้ารหัสและการตรวจจับ PII

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

ในโค้ดข้างต้น เราได้:

- สร้างคลาส `PiiDetector` เพื่อสแกนข้อความและพารามิเตอร์สำหรับข้อมูลส่วนบุคคล (PII)
- สร้างคลาส `EncryptionService` เพื่อจัดการการเข้ารหัสและถอดรหัสข้อมูลที่ละเอียดอ่อนโดยใช้ไลบรารี `cryptography`
- กำหนด decorator `secure_tool` ที่ห่อหุ้มการใช้งานเครื่องมือเพื่อตรวจสอบ PII บันทึกการเข้าถึง และเข้ารหัสข้อมูลที่ละเอียดอ่อนหากจำเป็น
- นำ decorator `secure_tool` ไปใช้กับเครื่องมือตัวอย่าง (`SecureCustomerDataTool`) เพื่อให้แน่ใจว่าจัดการข้อมูลที่ละเอียดอ่อนอย่างปลอดภัย

## ต่อไปคือ

- [5.9 Web search](../web-search-mcp/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้