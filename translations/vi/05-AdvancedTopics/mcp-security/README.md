<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:16:51+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "vi"
}
-->
# Thực hành Bảo mật Tốt nhất

Bảo mật rất quan trọng đối với các triển khai MCP, đặc biệt trong môi trường doanh nghiệp. Việc đảm bảo công cụ và dữ liệu được bảo vệ khỏi truy cập trái phép, rò rỉ dữ liệu và các mối đe dọa bảo mật khác là điều cần thiết.

## Giới thiệu

Trong bài học này, chúng ta sẽ tìm hiểu các thực hành bảo mật tốt nhất cho các triển khai MCP. Chúng ta sẽ đề cập đến xác thực và phân quyền, bảo vệ dữ liệu, thực thi công cụ an toàn và tuân thủ các quy định về quyền riêng tư dữ liệu.

## Mục tiêu học tập

Kết thúc bài học này, bạn sẽ có khả năng:

- Triển khai cơ chế xác thực và phân quyền an toàn cho các máy chủ MCP.
- Bảo vệ dữ liệu nhạy cảm bằng cách sử dụng mã hóa và lưu trữ an toàn.
- Đảm bảo thực thi công cụ an toàn với các kiểm soát truy cập phù hợp.
- Áp dụng các thực hành tốt nhất cho bảo vệ dữ liệu và tuân thủ quyền riêng tư.

## Xác thực và Phân quyền

Xác thực và phân quyền là yếu tố thiết yếu để bảo vệ các máy chủ MCP. Xác thực trả lời câu hỏi "Bạn là ai?" trong khi phân quyền trả lời "Bạn có thể làm gì?".

Hãy cùng xem ví dụ về cách triển khai xác thực và phân quyền an toàn trong các máy chủ MCP sử dụng .NET và Java.

### Tích hợp .NET Identity

ASP .NET Core Identity cung cấp một khung làm việc mạnh mẽ để quản lý xác thực và phân quyền người dùng. Chúng ta có thể tích hợp nó với các máy chủ MCP để bảo vệ quyền truy cập vào công cụ và tài nguyên.

Có một số khái niệm cốt lõi cần hiểu khi tích hợp ASP.NET Core Identity với các máy chủ MCP, cụ thể:

- **Cấu hình Identity**: Thiết lập ASP.NET Core Identity với vai trò người dùng và các claims. Claim là một thông tin về người dùng, ví dụ như vai trò hoặc quyền hạn, như "Admin" hoặc "User".
- **Xác thực JWT**: Sử dụng JSON Web Tokens (JWT) để truy cập API an toàn. JWT là tiêu chuẩn truyền tải thông tin an toàn giữa các bên dưới dạng đối tượng JSON, có thể xác thực và tin cậy vì được ký số.
- **Chính sách phân quyền**: Định nghĩa các chính sách để kiểm soát quyền truy cập công cụ dựa trên vai trò người dùng. MCP sử dụng chính sách phân quyền để xác định người dùng nào có thể truy cập công cụ nào dựa trên vai trò và claims của họ.

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

Trong đoạn mã trên, chúng ta đã:

- Cấu hình ASP.NET Core Identity để quản lý người dùng.
- Thiết lập xác thực JWT cho truy cập API an toàn. Chúng ta đã chỉ định các tham số xác thực token, bao gồm issuer, audience và khóa ký.
- Định nghĩa chính sách phân quyền để kiểm soát truy cập công cụ dựa trên vai trò người dùng. Ví dụ, chính sách "CanUseAdminTools" yêu cầu người dùng có vai trò "Admin", trong khi chính sách "CanUseBasic" yêu cầu người dùng phải được xác thực.
- Đăng ký các công cụ MCP với yêu cầu phân quyền cụ thể, đảm bảo chỉ những người dùng có vai trò phù hợp mới có thể truy cập.

### Tích hợp Java Spring Security

Đối với Java, chúng ta sẽ sử dụng Spring Security để triển khai xác thực và phân quyền an toàn cho các máy chủ MCP. Spring Security cung cấp một khung bảo mật toàn diện tích hợp liền mạch với các ứng dụng Spring.

Các khái niệm cốt lõi ở đây gồm:

- **Cấu hình Spring Security**: Thiết lập cấu hình bảo mật cho xác thực và phân quyền.
- **OAuth2 Resource Server**: Sử dụng OAuth2 để truy cập an toàn các công cụ MCP. OAuth2 là khung phân quyền cho phép dịch vụ bên thứ ba trao đổi token truy cập để truy cập API an toàn.
- **Interceptor bảo mật**: Triển khai interceptor bảo mật để thực thi kiểm soát truy cập khi chạy công cụ.
- **Kiểm soát truy cập dựa trên vai trò**: Sử dụng vai trò để kiểm soát quyền truy cập công cụ và tài nguyên cụ thể.
- **Chú thích bảo mật**: Sử dụng các chú thích để bảo vệ các phương thức và điểm cuối.

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

Trong đoạn mã trên, chúng ta đã:

- Cấu hình Spring Security để bảo vệ các điểm cuối MCP, cho phép truy cập công khai cho việc khám phá công cụ trong khi yêu cầu xác thực để thực thi công cụ.
- Sử dụng OAuth2 làm resource server để xử lý truy cập an toàn vào các công cụ MCP.
- Triển khai interceptor bảo mật để thực thi kiểm soát truy cập khi chạy công cụ, kiểm tra vai trò và quyền hạn người dùng trước khi cho phép truy cập công cụ cụ thể.
- Định nghĩa kiểm soát truy cập dựa trên vai trò để hạn chế truy cập các công cụ quản trị và truy cập dữ liệu nhạy cảm dựa trên vai trò người dùng.

## Bảo vệ Dữ liệu và Quyền riêng tư

Bảo vệ dữ liệu rất quan trọng để đảm bảo thông tin nhạy cảm được xử lý một cách an toàn. Điều này bao gồm bảo vệ thông tin nhận dạng cá nhân (PII), dữ liệu tài chính và các thông tin nhạy cảm khác khỏi truy cập trái phép và rò rỉ.

### Ví dụ Bảo vệ Dữ liệu trong Python

Hãy xem ví dụ về cách triển khai bảo vệ dữ liệu trong Python bằng mã hóa và phát hiện PII.

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

Trong đoạn mã trên, chúng ta đã:

- Triển khai `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) để đảm bảo công cụ xử lý dữ liệu nhạy cảm một cách an toàn.

## Tiếp theo

- [Web search](../web-search-mcp/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được coi là nguồn chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.