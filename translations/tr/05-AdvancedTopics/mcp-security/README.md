<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:39:35+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "tr"
}
-->
# Güvenlik En İyi Uygulamaları

Güvenlik, özellikle kurumsal ortamlarda MCP uygulamaları için kritik öneme sahiptir. Araçların ve verilerin yetkisiz erişim, veri ihlalleri ve diğer güvenlik tehditlerine karşı korunması önemlidir.

## Giriş

Bu derste, MCP uygulamaları için güvenlik en iyi uygulamalarını inceleyeceğiz. Kimlik doğrulama ve yetkilendirme, veri koruma, güvenli araç çalıştırma ve veri gizliliği düzenlemelerine uyum konularını ele alacağız.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- MCP sunucuları için güvenli kimlik doğrulama ve yetkilendirme mekanizmaları uygulamak.
- Şifreleme ve güvenli depolama kullanarak hassas verileri korumak.
- Doğru erişim kontrolleri ile araçların güvenli çalışmasını sağlamak.
- Veri koruma ve gizlilik uyumu için en iyi uygulamaları uygulamak.

## Kimlik Doğrulama ve Yetkilendirme

Kimlik doğrulama ve yetkilendirme, MCP sunucularının güvenliği için temel unsurlardır. Kimlik doğrulama "Sen kimsin?" sorusuna yanıt verirken, yetkilendirme "Ne yapabilirsin?" sorusuna cevap verir.

Şimdi, .NET ve Java kullanarak MCP sunucularında güvenli kimlik doğrulama ve yetkilendirme nasıl uygulanır örneklerine bakalım.

### .NET Identity Entegrasyonu

ASP .NET Core Identity, kullanıcı kimlik doğrulama ve yetkilendirmeyi yönetmek için sağlam bir çerçeve sunar. MCP sunucularına entegre ederek araçlara ve kaynaklara erişimi güvence altına alabiliriz.

ASP.NET Core Identity'yi MCP sunucularıyla entegre ederken anlamamız gereken bazı temel kavramlar şunlardır:

- **Identity Yapılandırması**: Kullanıcı rolleri ve talepleri ile ASP.NET Core Identity'nin kurulması. Bir talep, kullanıcının rolü veya izinleri gibi bilgileri içerir; örneğin "Admin" veya "User".
- **JWT Kimlik Doğrulama**: Güvenli API erişimi için JSON Web Token (JWT) kullanımı. JWT, dijital olarak imzalandığı için doğrulanabilir ve güvenilir olan, taraflar arasında bilgi güvenli şekilde iletmek için kullanılan standart bir JSON nesnesidir.
- **Yetkilendirme Politikaları**: Kullanıcı rollerine göre belirli araçlara erişimi kontrol eden politikaların tanımlanması. MCP, kullanıcıların rollerine ve taleplerine göre hangi araçlara erişebileceğini belirlemek için yetkilendirme politikaları kullanır.

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

Yukarıdaki kodda:

- Kullanıcı yönetimi için ASP.NET Core Identity yapılandırıldı.
- Güvenli API erişimi için JWT kimlik doğrulaması ayarlandı. Token doğrulama parametreleri, yayımlayan, hedef kitle ve imzalama anahtarı dahil olmak üzere belirtildi.
- Kullanıcı rollerine göre araçlara erişimi kontrol eden yetkilendirme politikaları tanımlandı. Örneğin, "CanUseAdminTools" politikası kullanıcının "Admin" rolüne sahip olmasını gerektirirken, "CanUseBasic" politikası kullanıcının kimlik doğrulanmış olmasını şart koşar.
- MCP araçları, yalnızca uygun rollere sahip kullanıcıların erişebilmesi için belirli yetkilendirme gereksinimleriyle kaydedildi.

### Java Spring Security Entegrasyonu

Java için, MCP sunucularında güvenli kimlik doğrulama ve yetkilendirme uygulamak üzere Spring Security kullanacağız. Spring Security, Spring uygulamalarıyla sorunsuz entegrasyon sağlayan kapsamlı bir güvenlik çerçevesidir.

Buradaki temel kavramlar şunlardır:

- **Spring Security Yapılandırması**: Kimlik doğrulama ve yetkilendirme için güvenlik yapılandırmalarının kurulması.
- **OAuth2 Resource Server**: MCP araçlarına güvenli erişim için OAuth2 kullanımı. OAuth2, üçüncü taraf hizmetlerin güvenli API erişimi için erişim tokenları alışverişi yapmasını sağlayan bir yetkilendirme çerçevesidir.
- **Güvenlik Kesicileri (Interceptors)**: Araç çalıştırma sırasında erişim kontrollerini uygulamak için güvenlik kesicilerinin kullanılması.
- **Role Dayalı Erişim Kontrolü**: Belirli araçlara ve kaynaklara erişimi kontrol etmek için rollerin kullanılması.
- **Güvenlik Anotasyonları**: Metodları ve uç noktaları güvence altına almak için anotasyonların kullanılması.

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

Yukarıdaki kodda:

- MCP uç noktalarını güvence altına almak için Spring Security yapılandırıldı; araç keşfine genel erişim sağlanırken, araç çalıştırma için kimlik doğrulama zorunlu kılındı.
- MCP araçlarına güvenli erişimi yönetmek için OAuth2 resource server olarak kullanıldı.
- Araç çalıştırma sırasında erişim kontrollerini uygulamak için güvenlik kesicisi uygulandı; belirli araçlara erişim öncesinde kullanıcı rolleri ve izinleri kontrol edildi.
- Yönetici araçlarına ve hassas veri erişimine kullanıcı rollerine göre kısıtlama getiren role dayalı erişim kontrolü tanımlandı.

## Veri Koruma ve Gizlilik

Veri koruma, hassas bilgilerin güvenli şekilde işlenmesini sağlamak için çok önemlidir. Bu, kişisel tanımlayıcı bilgilerin (PII), finansal verilerin ve diğer hassas bilgilerin yetkisiz erişim ve ihlallerden korunmasını içerir.

### Python Veri Koruma Örneği

Şimdi, Python’da şifreleme ve PII tespiti kullanarak veri koruma nasıl uygulanır örneğine bakalım.

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

Yukarıdaki kodda:

- Metin ve parametrelerde kişisel tanımlayıcı bilgileri (PII) taramak için `PiiDetector` sınıfı uygulandı.
- `cryptography` kütüphanesini kullanarak hassas verilerin şifrelenmesi ve şifresinin çözülmesi için `EncryptionService` sınıfı oluşturuldu.
- Araç çalıştırmayı sarmalayan, PII kontrolü yapan, erişimi kaydeden ve gerekirse hassas verileri şifreleyen `secure_tool` dekoratörü tanımlandı.
- Örnek bir araç olan `SecureCustomerDataTool` üzerinde `secure_tool` dekoratörü uygulanarak hassas verilerin güvenli şekilde işlendiği sağlandı.

## Sonraki Adımlar

- [5.9 Web search](../web-search-mcp/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.