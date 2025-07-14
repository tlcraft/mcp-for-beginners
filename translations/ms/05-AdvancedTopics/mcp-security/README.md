<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:42:23+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ms"
}
-->
# Amalan Terbaik Keselamatan

Keselamatan adalah sangat penting untuk pelaksanaan MCP, terutamanya dalam persekitaran perusahaan. Adalah penting untuk memastikan alat dan data dilindungi daripada akses tanpa kebenaran, kebocoran data, dan ancaman keselamatan lain.

## Pengenalan

Dalam pelajaran ini, kita akan meneroka amalan terbaik keselamatan untuk pelaksanaan MCP. Kita akan membincangkan pengesahan dan kebenaran, perlindungan data, pelaksanaan alat yang selamat, dan pematuhan dengan peraturan privasi data.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Melaksanakan mekanisme pengesahan dan kebenaran yang selamat untuk pelayan MCP.
- Melindungi data sensitif menggunakan penyulitan dan penyimpanan yang selamat.
- Memastikan pelaksanaan alat yang selamat dengan kawalan akses yang betul.
- Mengaplikasikan amalan terbaik untuk perlindungan data dan pematuhan privasi.

## Pengesahan dan Kebenaran

Pengesahan dan kebenaran adalah penting untuk mengamankan pelayan MCP. Pengesahan menjawab soalan "Siapa anda?" manakala kebenaran menjawab "Apa yang anda boleh lakukan?".

Mari kita lihat contoh bagaimana untuk melaksanakan pengesahan dan kebenaran yang selamat dalam pelayan MCP menggunakan .NET dan Java.

### Integrasi Identiti .NET

ASP .NET Core Identity menyediakan rangka kerja yang kukuh untuk mengurus pengesahan dan kebenaran pengguna. Kita boleh mengintegrasikannya dengan pelayan MCP untuk mengamankan akses kepada alat dan sumber.

Terdapat beberapa konsep utama yang perlu difahami apabila mengintegrasikan ASP.NET Core Identity dengan pelayan MCP iaitu:

- **Konfigurasi Identiti**: Menyediakan ASP.NET Core Identity dengan peranan pengguna dan tuntutan. Tuntutan adalah maklumat tentang pengguna, seperti peranan atau kebenaran mereka contohnya "Admin" atau "User".
- **Pengesahan JWT**: Menggunakan JSON Web Tokens (JWT) untuk akses API yang selamat. JWT adalah standard untuk menghantar maklumat secara selamat antara pihak sebagai objek JSON, yang boleh disahkan dan dipercayai kerana ia ditandatangani secara digital.
- **Polisi Kebenaran**: Mendefinisikan polisi untuk mengawal akses kepada alat tertentu berdasarkan peranan pengguna. MCP menggunakan polisi kebenaran untuk menentukan pengguna mana yang boleh mengakses alat tertentu berdasarkan peranan dan tuntutan mereka.

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

Dalam kod di atas, kita telah:

- Mengkonfigurasi ASP.NET Core Identity untuk pengurusan pengguna.
- Menyediakan pengesahan JWT untuk akses API yang selamat. Kita telah menetapkan parameter pengesahan token, termasuk penerbit, audiens, dan kunci tandatangan.
- Mendefinisikan polisi kebenaran untuk mengawal akses kepada alat berdasarkan peranan pengguna. Contohnya, polisi "CanUseAdminTools" memerlukan pengguna mempunyai peranan "Admin", manakala polisi "CanUseBasic" memerlukan pengguna untuk disahkan.
- Mendaftarkan alat MCP dengan keperluan kebenaran tertentu, memastikan hanya pengguna dengan peranan yang sesuai boleh mengaksesnya.

### Integrasi Java Spring Security

Untuk Java, kita akan menggunakan Spring Security untuk melaksanakan pengesahan dan kebenaran yang selamat untuk pelayan MCP. Spring Security menyediakan rangka kerja keselamatan yang komprehensif yang berintegrasi dengan lancar dengan aplikasi Spring.

Konsep utama di sini adalah:

- **Konfigurasi Spring Security**: Menyediakan konfigurasi keselamatan untuk pengesahan dan kebenaran.
- **OAuth2 Resource Server**: Menggunakan OAuth2 untuk akses selamat kepada alat MCP. OAuth2 adalah rangka kerja kebenaran yang membenarkan perkhidmatan pihak ketiga menukar token akses untuk akses API yang selamat.
- **Interceptor Keselamatan**: Melaksanakan interceptor keselamatan untuk menguatkuasakan kawalan akses ke atas pelaksanaan alat.
- **Kawalan Akses Berasaskan Peranan**: Menggunakan peranan untuk mengawal akses kepada alat dan sumber tertentu.
- **Anotasi Keselamatan**: Menggunakan anotasi untuk mengamankan kaedah dan titik akhir.

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

Dalam kod di atas, kita telah:

- Mengkonfigurasi Spring Security untuk mengamankan titik akhir MCP, membenarkan akses awam untuk penemuan alat sementara memerlukan pengesahan untuk pelaksanaan alat.
- Menggunakan OAuth2 sebagai pelayan sumber untuk mengendalikan akses selamat kepada alat MCP.
- Melaksanakan interceptor keselamatan untuk menguatkuasakan kawalan akses ke atas pelaksanaan alat, memeriksa peranan dan kebenaran pengguna sebelum membenarkan akses kepada alat tertentu.
- Mendefinisikan kawalan akses berasaskan peranan untuk mengehadkan akses kepada alat pentadbir dan akses data sensitif berdasarkan peranan pengguna.

## Perlindungan Data dan Privasi

Perlindungan data adalah penting untuk memastikan maklumat sensitif dikendalikan dengan selamat. Ini termasuk melindungi maklumat peribadi yang boleh dikenal pasti (PII), data kewangan, dan maklumat sensitif lain daripada akses tanpa kebenaran dan kebocoran.

### Contoh Perlindungan Data Python

Mari kita lihat contoh bagaimana untuk melaksanakan perlindungan data dalam Python menggunakan penyulitan dan pengesanan PII.

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

Dalam kod di atas, kita telah:

- Melaksanakan kelas `PiiDetector` untuk mengimbas teks dan parameter bagi maklumat peribadi yang boleh dikenal pasti (PII).
- Mewujudkan kelas `EncryptionService` untuk mengendalikan penyulitan dan penyahsulitan data sensitif menggunakan perpustakaan `cryptography`.
- Mendefinisikan dekorator `secure_tool` yang membalut pelaksanaan alat untuk memeriksa PII, merekod akses, dan menyulitkan data sensitif jika diperlukan.
- Mengaplikasikan dekorator `secure_tool` kepada alat contoh (`SecureCustomerDataTool`) untuk memastikan ia mengendalikan data sensitif dengan selamat.

## Apa seterusnya

- [5.9 Web search](../web-search-mcp/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.