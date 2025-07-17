<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T07:39:22+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "vi"
}
-->
# Thực Tiễn Tốt Nhất Về Bảo Mật

Bảo mật là yếu tố then chốt đối với các triển khai MCP, đặc biệt trong môi trường doanh nghiệp. Việc đảm bảo các công cụ và dữ liệu được bảo vệ khỏi truy cập trái phép, rò rỉ dữ liệu và các mối đe dọa bảo mật khác là rất quan trọng.

## Giới thiệu

Model Context Protocol (MCP) đòi hỏi các cân nhắc bảo mật đặc thù do vai trò của nó trong việc cung cấp cho LLM quyền truy cập vào dữ liệu và công cụ. Bài học này sẽ khám phá các thực tiễn bảo mật tốt nhất cho các triển khai MCP dựa trên hướng dẫn chính thức của MCP và các mẫu bảo mật đã được thiết lập.

MCP tuân theo các nguyên tắc bảo mật chính để đảm bảo các tương tác an toàn và đáng tin cậy:

- **Sự đồng ý và kiểm soát của người dùng**: Người dùng phải cung cấp sự đồng ý rõ ràng trước khi bất kỳ dữ liệu nào được truy cập hoặc các thao tác được thực hiện. Cung cấp quyền kiểm soát rõ ràng về dữ liệu được chia sẻ và các hành động được phép.
  
- **Bảo mật dữ liệu cá nhân**: Dữ liệu người dùng chỉ được tiết lộ khi có sự đồng ý rõ ràng và phải được bảo vệ bằng các cơ chế kiểm soát truy cập phù hợp. Ngăn chặn việc truyền dữ liệu trái phép.
  
- **An toàn công cụ**: Trước khi gọi bất kỳ công cụ nào, cần có sự đồng ý rõ ràng từ người dùng. Người dùng cần hiểu rõ chức năng của từng công cụ, đồng thời phải áp dụng các ranh giới bảo mật chặt chẽ.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có khả năng:

- Triển khai các cơ chế xác thực và ủy quyền an toàn cho các máy chủ MCP.
- Bảo vệ dữ liệu nhạy cảm bằng mã hóa và lưu trữ an toàn.
- Đảm bảo thực thi công cụ an toàn với các kiểm soát truy cập phù hợp.
- Áp dụng các thực tiễn tốt nhất về bảo vệ dữ liệu và tuân thủ quyền riêng tư.
- Nhận diện và giảm thiểu các lỗ hổng bảo mật phổ biến của MCP như vấn đề confused deputy, token passthrough và chiếm đoạt phiên làm việc.

## Xác thực và Ủy quyền

Xác thực và ủy quyền là yếu tố thiết yếu để bảo vệ các máy chủ MCP. Xác thực trả lời câu hỏi "Bạn là ai?" trong khi ủy quyền trả lời "Bạn có thể làm gì?".

Theo đặc tả bảo mật MCP, các điểm sau là những cân nhắc bảo mật quan trọng:

1. **Xác thực token**: Máy chủ MCP KHÔNG ĐƯỢC chấp nhận bất kỳ token nào không được cấp phát rõ ràng cho máy chủ MCP. "Token passthrough" là một mẫu chống được cấm rõ ràng.

2. **Kiểm tra ủy quyền**: Các máy chủ MCP có triển khai ủy quyền PHẢI xác minh tất cả các yêu cầu đến và KHÔNG ĐƯỢC sử dụng phiên làm phương thức xác thực.

3. **Quản lý phiên an toàn**: Khi sử dụng phiên để lưu trạng thái, máy chủ MCP PHẢI sử dụng ID phiên an toàn, không xác định được trước, được tạo ra bằng bộ sinh số ngẫu nhiên an toàn. ID phiên NÊN được liên kết với thông tin người dùng cụ thể.

4. **Sự đồng ý rõ ràng của người dùng**: Đối với các máy chủ proxy, các triển khai MCP PHẢI lấy sự đồng ý của người dùng cho từng client được đăng ký động trước khi chuyển tiếp đến các máy chủ ủy quyền bên thứ ba.

Hãy xem ví dụ về cách triển khai xác thực và ủy quyền an toàn trong các máy chủ MCP sử dụng .NET và Java.

### Tích hợp .NET Identity

ASP .NET Core Identity cung cấp một khung làm việc mạnh mẽ để quản lý xác thực và ủy quyền người dùng. Chúng ta có thể tích hợp nó với các máy chủ MCP để bảo vệ quyền truy cập vào công cụ và tài nguyên.

Có một số khái niệm cốt lõi cần hiểu khi tích hợp ASP.NET Core Identity với các máy chủ MCP, cụ thể:

- **Cấu hình Identity**: Thiết lập ASP.NET Core Identity với các vai trò và claims của người dùng. Claim là một thông tin về người dùng, ví dụ như vai trò hoặc quyền hạn, như "Admin" hoặc "User".
- **Xác thực JWT**: Sử dụng JSON Web Tokens (JWT) để truy cập API an toàn. JWT là tiêu chuẩn truyền tải thông tin an toàn giữa các bên dưới dạng đối tượng JSON, có thể được xác minh và tin cậy vì được ký số.
- **Chính sách ủy quyền**: Định nghĩa các chính sách để kiểm soát quyền truy cập vào các công cụ dựa trên vai trò người dùng. MCP sử dụng các chính sách ủy quyền để xác định người dùng nào có thể truy cập công cụ nào dựa trên vai trò và claims của họ.

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
- Thiết lập xác thực JWT để truy cập API an toàn. Chúng ta đã chỉ định các tham số xác thực token, bao gồm issuer, audience và khóa ký.
- Định nghĩa các chính sách ủy quyền để kiểm soát quyền truy cập công cụ dựa trên vai trò người dùng. Ví dụ, chính sách "CanUseAdminTools" yêu cầu người dùng có vai trò "Admin", trong khi chính sách "CanUseBasic" yêu cầu người dùng đã xác thực.
- Đăng ký các công cụ MCP với các yêu cầu ủy quyền cụ thể, đảm bảo chỉ người dùng có vai trò phù hợp mới có thể truy cập.

### Tích hợp Java Spring Security

Đối với Java, chúng ta sẽ sử dụng Spring Security để triển khai xác thực và ủy quyền an toàn cho các máy chủ MCP. Spring Security cung cấp một khung bảo mật toàn diện tích hợp mượt mà với các ứng dụng Spring.

Các khái niệm cốt lõi ở đây bao gồm:

- **Cấu hình Spring Security**: Thiết lập cấu hình bảo mật cho xác thực và ủy quyền.
- **OAuth2 Resource Server**: Sử dụng OAuth2 để truy cập an toàn các công cụ MCP. OAuth2 là khung ủy quyền cho phép dịch vụ bên thứ ba trao đổi token truy cập để truy cập API an toàn.
- **Bộ chặn bảo mật (Security Interceptors)**: Triển khai các bộ chặn bảo mật để thực thi kiểm soát truy cập khi thực thi công cụ.
- **Kiểm soát truy cập dựa trên vai trò**: Sử dụng vai trò để kiểm soát quyền truy cập vào các công cụ và tài nguyên cụ thể.
- **Chú thích bảo mật (Security Annotations)**: Sử dụng chú thích để bảo vệ các phương thức và điểm cuối.

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

- Cấu hình Spring Security để bảo vệ các điểm cuối MCP, cho phép truy cập công khai vào việc khám phá công cụ trong khi yêu cầu xác thực để thực thi công cụ.
- Sử dụng OAuth2 như một resource server để xử lý truy cập an toàn vào các công cụ MCP.
- Triển khai bộ chặn bảo mật để thực thi kiểm soát truy cập khi thực thi công cụ, kiểm tra vai trò và quyền của người dùng trước khi cho phép truy cập các công cụ cụ thể.
- Định nghĩa kiểm soát truy cập dựa trên vai trò để giới hạn truy cập vào các công cụ quản trị và dữ liệu nhạy cảm dựa trên vai trò người dùng.

## Bảo vệ dữ liệu và Quyền riêng tư

Bảo vệ dữ liệu là yếu tố quan trọng để đảm bảo thông tin nhạy cảm được xử lý một cách an toàn. Điều này bao gồm bảo vệ thông tin cá nhân nhận dạng được (PII), dữ liệu tài chính và các thông tin nhạy cảm khác khỏi truy cập trái phép và rò rỉ.

### Ví dụ bảo vệ dữ liệu trong Python

Hãy xem ví dụ về cách triển khai bảo vệ dữ liệu trong Python sử dụng mã hóa và phát hiện PII.

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

- Triển khai lớp `PiiDetector` để quét văn bản và tham số nhằm phát hiện thông tin cá nhân nhận dạng được (PII).
- Tạo lớp `EncryptionService` để xử lý mã hóa và giải mã dữ liệu nhạy cảm sử dụng thư viện `cryptography`.
- Định nghĩa decorator `secure_tool` bao bọc việc thực thi công cụ để kiểm tra PII, ghi lại truy cập và mã hóa dữ liệu nhạy cảm nếu cần.
- Áp dụng decorator `secure_tool` cho một công cụ mẫu (`SecureCustomerDataTool`) để đảm bảo nó xử lý dữ liệu nhạy cảm một cách an toàn.

## Các rủi ro bảo mật đặc thù của MCP

Theo tài liệu bảo mật chính thức của MCP, có một số rủi ro bảo mật mà người triển khai MCP cần lưu ý:

### 1. Vấn đề Confused Deputy

Lỗ hổng này xảy ra khi máy chủ MCP đóng vai trò proxy cho các API bên thứ ba, có thể cho phép kẻ tấn công lợi dụng mối quan hệ tin cậy giữa máy chủ MCP và các API này.

**Giải pháp:**
- Các máy chủ proxy MCP sử dụng client ID tĩnh PHẢI lấy sự đồng ý của người dùng cho từng client được đăng ký động trước khi chuyển tiếp đến các máy chủ ủy quyền bên thứ ba.
- Triển khai đúng quy trình OAuth với PKCE (Proof Key for Code Exchange) cho các yêu cầu ủy quyền.
- Kiểm tra chặt chẽ các URI chuyển hướng và định danh client.

### 2. Lỗ hổng Token Passthrough

Token passthrough xảy ra khi máy chủ MCP chấp nhận token từ client MCP mà không xác thực rằng token đó được cấp phát hợp lệ cho máy chủ MCP và chuyển tiếp chúng đến các API hạ nguồn.

### Rủi ro
- Vượt qua các kiểm soát bảo mật (bỏ qua giới hạn tần suất, kiểm tra yêu cầu)
- Vấn đề trách nhiệm và theo dõi kiểm toán
- Vi phạm ranh giới tin cậy
- Rủi ro tương thích trong tương lai

**Giải pháp:**
- Máy chủ MCP KHÔNG ĐƯỢC chấp nhận bất kỳ token nào không được cấp phát rõ ràng cho máy chủ MCP.
- Luôn xác thực các claim audience của token để đảm bảo chúng phù hợp với dịch vụ mong đợi.

### 3. Chiếm đoạt phiên làm việc (Session Hijacking)

Xảy ra khi bên không được phép lấy được ID phiên và sử dụng nó để giả mạo client gốc, có thể dẫn đến các hành động trái phép.

**Giải pháp:**
- Các máy chủ MCP có triển khai ủy quyền PHẢI xác minh tất cả các yêu cầu đến và KHÔNG ĐƯỢC sử dụng phiên làm phương thức xác thực.
- Sử dụng ID phiên an toàn, không xác định được trước, được tạo bằng bộ sinh số ngẫu nhiên an toàn.
- Liên kết ID phiên với thông tin người dùng cụ thể theo định dạng khóa như `<user_id>:<session_id>`.
- Triển khai chính sách hết hạn và xoay vòng phiên hợp lý.

## Các thực tiễn bảo mật bổ sung cho MCP

Ngoài các cân nhắc bảo mật cốt lõi của MCP, hãy xem xét triển khai các thực tiễn bảo mật bổ sung sau:

- **Luôn sử dụng HTTPS**: Mã hóa giao tiếp giữa client và server để bảo vệ token khỏi bị chặn.
- **Triển khai Kiểm soát truy cập dựa trên vai trò (RBAC)**: Không chỉ kiểm tra người dùng đã xác thực mà còn kiểm tra họ được phép làm gì.
- **Giám sát và kiểm toán**: Ghi lại tất cả sự kiện xác thực để phát hiện và phản ứng với các hoạt động đáng ngờ.
- **Xử lý giới hạn tần suất và điều tiết**: Triển khai cơ chế lùi dần theo cấp số nhân và logic thử lại để xử lý giới hạn tần suất một cách linh hoạt.
- **Lưu trữ token an toàn**: Lưu trữ token truy cập và token làm mới một cách an toàn bằng các cơ chế lưu trữ bảo mật của hệ thống hoặc dịch vụ quản lý khóa an toàn.
- **Xem xét sử dụng API Management**: Các dịch vụ như Azure API Management có thể xử lý nhiều vấn đề bảo mật tự động, bao gồm xác thực, ủy quyền và giới hạn tần suất.

## Tài liệu tham khảo

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Tiếp theo

- [5.9 Web search](../web-search-mcp/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.