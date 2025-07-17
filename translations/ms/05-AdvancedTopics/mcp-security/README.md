<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T08:05:34+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "ms"
}
-->
# Amalan Terbaik Keselamatan

Keselamatan adalah kritikal untuk pelaksanaan MCP, terutamanya dalam persekitaran perusahaan. Adalah penting untuk memastikan alat dan data dilindungi daripada akses tanpa kebenaran, kebocoran data, dan ancaman keselamatan lain.

## Pengenalan

Model Context Protocol (MCP) memerlukan pertimbangan keselamatan khusus kerana peranannya dalam memberikan LLM akses kepada data dan alat. Pelajaran ini meneroka amalan terbaik keselamatan untuk pelaksanaan MCP berdasarkan garis panduan rasmi MCP dan corak keselamatan yang telah ditetapkan.

MCP mengikuti prinsip keselamatan utama untuk memastikan interaksi yang selamat dan boleh dipercayai:

- **Persetujuan dan Kawalan Pengguna**: Pengguna mesti memberikan persetujuan secara jelas sebelum sebarang data diakses atau operasi dilakukan. Berikan kawalan yang jelas mengenai data yang dikongsi dan tindakan yang dibenarkan.
  
- **Privasi Data**: Data pengguna hanya boleh didedahkan dengan persetujuan jelas dan mesti dilindungi dengan kawalan akses yang sesuai. Lindungi daripada penghantaran data tanpa kebenaran.
  
- **Keselamatan Alat**: Sebelum menggunakan sebarang alat, persetujuan pengguna secara jelas diperlukan. Pengguna harus memahami fungsi setiap alat dengan jelas, dan sempadan keselamatan yang kukuh mesti dikuatkuasakan.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Melaksanakan mekanisme pengesahan dan kebenaran yang selamat untuk pelayan MCP.
- Melindungi data sensitif menggunakan penyulitan dan penyimpanan yang selamat.
- Memastikan pelaksanaan alat yang selamat dengan kawalan akses yang betul.
- Mengaplikasikan amalan terbaik untuk perlindungan data dan pematuhan privasi.
- Mengenal pasti dan mengurangkan kerentanan keselamatan MCP yang biasa seperti masalah confused deputy, token passthrough, dan sesi diculik.

## Pengesahan dan Kebenaran

Pengesahan dan kebenaran adalah penting untuk mengamankan pelayan MCP. Pengesahan menjawab soalan "Siapa anda?" manakala kebenaran menjawab "Apa yang anda boleh lakukan?".

Menurut spesifikasi keselamatan MCP, ini adalah pertimbangan keselamatan kritikal:

1. **Pengesahan Token**: Pelayan MCP TIDAK BOLEH menerima sebarang token yang tidak dikeluarkan secara eksplisit untuk pelayan MCP. "Token passthrough" adalah corak anti yang dilarang secara jelas.

2. **Pengesahan Kebenaran**: Pelayan MCP yang melaksanakan kebenaran MESTI mengesahkan semua permintaan masuk dan TIDAK BOLEH menggunakan sesi untuk pengesahan.

3. **Pengurusan Sesi Selamat**: Apabila menggunakan sesi untuk keadaan, pelayan MCP MESTI menggunakan ID sesi yang selamat dan tidak deterministik yang dijana dengan penjana nombor rawak yang selamat. ID sesi SEBAIKNYA diikat kepada maklumat khusus pengguna.

4. **Persetujuan Pengguna Secara Eksplisit**: Untuk pelayan proksi, pelaksanaan MCP MESTI mendapatkan persetujuan pengguna untuk setiap klien yang didaftarkan secara dinamik sebelum meneruskan ke pelayan kebenaran pihak ketiga.

Mari kita lihat contoh bagaimana melaksanakan pengesahan dan kebenaran yang selamat dalam pelayan MCP menggunakan .NET dan Java.

### Integrasi Identiti .NET

ASP .NET Core Identity menyediakan rangka kerja yang kukuh untuk mengurus pengesahan dan kebenaran pengguna. Kita boleh mengintegrasikannya dengan pelayan MCP untuk mengamankan akses kepada alat dan sumber.

Terdapat beberapa konsep utama yang perlu difahami apabila mengintegrasikan ASP.NET Core Identity dengan pelayan MCP iaitu:

- **Konfigurasi Identiti**: Menyediakan ASP.NET Core Identity dengan peranan dan tuntutan pengguna. Tuntutan adalah maklumat tentang pengguna, seperti peranan atau kebenaran mereka contohnya "Admin" atau "User".
- **Pengesahan JWT**: Menggunakan JSON Web Tokens (JWT) untuk akses API yang selamat. JWT adalah standard untuk menghantar maklumat secara selamat antara pihak sebagai objek JSON, yang boleh disahkan dan dipercayai kerana ia ditandatangani secara digital.
- **Polisi Kebenaran**: Mendefinisikan polisi untuk mengawal akses kepada alat tertentu berdasarkan peranan pengguna. MCP menggunakan polisi kebenaran untuk menentukan pengguna mana boleh mengakses alat mana berdasarkan peranan dan tuntutan mereka.

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
- Menyediakan pengesahan JWT untuk akses API yang selamat. Kami menentukan parameter pengesahan token, termasuk penerbit, audiens, dan kunci tandatangan.
- Mendefinisikan polisi kebenaran untuk mengawal akses kepada alat berdasarkan peranan pengguna. Contohnya, polisi "CanUseAdminTools" memerlukan pengguna mempunyai peranan "Admin", manakala polisi "CanUseBasic" memerlukan pengguna disahkan.
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

- Mengkonfigurasi Spring Security untuk mengamankan titik akhir MCP, membenarkan akses awam kepada penemuan alat sambil memerlukan pengesahan untuk pelaksanaan alat.
- Menggunakan OAuth2 sebagai pelayan sumber untuk mengendalikan akses selamat kepada alat MCP.
- Melaksanakan interceptor keselamatan untuk menguatkuasakan kawalan akses ke atas pelaksanaan alat, memeriksa peranan dan kebenaran pengguna sebelum membenarkan akses kepada alat tertentu.
- Mendefinisikan kawalan akses berasaskan peranan untuk mengehadkan akses kepada alat pentadbir dan akses data sensitif berdasarkan peranan pengguna.

## Perlindungan Data dan Privasi

Perlindungan data adalah penting untuk memastikan maklumat sensitif dikendalikan dengan selamat. Ini termasuk melindungi maklumat peribadi yang boleh dikenal pasti (PII), data kewangan, dan maklumat sensitif lain daripada akses tanpa kebenaran dan kebocoran.

### Contoh Perlindungan Data Python

Mari kita lihat contoh bagaimana melaksanakan perlindungan data dalam Python menggunakan penyulitan dan pengesanan PII.

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
- Mencipta kelas `EncryptionService` untuk mengendalikan penyulitan dan penyahsulitan data sensitif menggunakan perpustakaan `cryptography`.
- Mendefinisikan dekorator `secure_tool` yang membalut pelaksanaan alat untuk memeriksa PII, merekod akses, dan menyulitkan data sensitif jika diperlukan.
- Mengaplikasikan dekorator `secure_tool` kepada alat contoh (`SecureCustomerDataTool`) untuk memastikan ia mengendalikan data sensitif dengan selamat.

## Risiko Keselamatan Khusus MCP

Menurut dokumentasi keselamatan rasmi MCP, terdapat risiko keselamatan khusus yang perlu diketahui oleh pelaksana MCP:

### 1. Masalah Confused Deputy

Kerentanan ini berlaku apabila pelayan MCP bertindak sebagai proksi kepada API pihak ketiga, yang berpotensi membolehkan penyerang mengeksploitasi hubungan dipercayai antara pelayan MCP dan API tersebut.

**Mitigasi:**
- Pelayan proksi MCP yang menggunakan ID klien statik MESTI mendapatkan persetujuan pengguna untuk setiap klien yang didaftarkan secara dinamik sebelum meneruskan ke pelayan kebenaran pihak ketiga.
- Melaksanakan aliran OAuth yang betul dengan PKCE (Proof Key for Code Exchange) untuk permintaan kebenaran.
- Memastikan pengesahan ketat URI pengalihan dan pengecam klien.

### 2. Kerentanan Token Passthrough

Token passthrough berlaku apabila pelayan MCP menerima token daripada klien MCP tanpa mengesahkan bahawa token tersebut dikeluarkan dengan betul untuk pelayan MCP dan meneruskannya ke API hiliran.

### Risiko
- Pengelakan kawalan keselamatan (membypass had kadar, pengesahan permintaan)
- Isu akauntabiliti dan jejak audit
- Pelanggaran sempadan kepercayaan
- Risiko keserasian masa depan

**Mitigasi:**
- Pelayan MCP TIDAK BOLEH menerima sebarang token yang tidak dikeluarkan secara eksplisit untuk pelayan MCP.
- Sentiasa sahkan tuntutan audiens token untuk memastikan ia sepadan dengan perkhidmatan yang dijangka.

### 3. Penculikan Sesi

Ini berlaku apabila pihak yang tidak dibenarkan memperoleh ID sesi dan menggunakannya untuk menyamar sebagai klien asal, yang berpotensi menyebabkan tindakan tanpa kebenaran.

**Mitigasi:**
- Pelayan MCP yang melaksanakan kebenaran MESTI mengesahkan semua permintaan masuk dan TIDAK BOLEH menggunakan sesi untuk pengesahan.
- Gunakan ID sesi yang selamat dan tidak deterministik yang dijana dengan penjana nombor rawak yang selamat.
- Ikat ID sesi kepada maklumat khusus pengguna menggunakan format kunci seperti `<user_id>:<session_id>`.
- Melaksanakan polisi tamat tempoh dan putaran sesi yang betul.

## Amalan Terbaik Keselamatan Tambahan untuk MCP

Selain pertimbangan keselamatan teras MCP, pertimbangkan untuk melaksanakan amalan keselamatan tambahan berikut:

- **Sentiasa gunakan HTTPS**: Sulitkan komunikasi antara klien dan pelayan untuk melindungi token daripada diserang.
- **Laksanakan Kawalan Akses Berasaskan Peranan (RBAC)**: Jangan hanya periksa jika pengguna disahkan; periksa apa yang mereka dibenarkan lakukan.
- **Pantau dan audit**: Rekod semua acara pengesahan untuk mengesan dan bertindak balas terhadap aktiviti mencurigakan.
- **Urus had kadar dan throttling**: Laksanakan logik backoff eksponen dan cuba semula untuk mengendalikan had kadar dengan lancar.
- **Simpan token dengan selamat**: Simpan token akses dan token segar dengan selamat menggunakan mekanisme penyimpanan selamat sistem atau perkhidmatan pengurusan kunci yang selamat.
- **Pertimbangkan menggunakan Pengurusan API**: Perkhidmatan seperti Azure API Management boleh mengendalikan banyak kebimbangan keselamatan secara automatik, termasuk pengesahan, kebenaran, dan had kadar.

## Rujukan

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Apa seterusnya

- [5.9 Web search](../web-search-mcp/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.