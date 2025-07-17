<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T07:52:47+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "id"
}
-->
# Praktik Terbaik Keamanan

Keamanan sangat penting untuk implementasi MCP, terutama di lingkungan perusahaan. Penting untuk memastikan bahwa alat dan data terlindungi dari akses tidak sah, kebocoran data, dan ancaman keamanan lainnya.

## Pendahuluan

Model Context Protocol (MCP) memerlukan pertimbangan keamanan khusus karena perannya dalam memberikan akses LLM ke data dan alat. Pelajaran ini membahas praktik terbaik keamanan untuk implementasi MCP berdasarkan pedoman resmi MCP dan pola keamanan yang sudah mapan.

MCP mengikuti prinsip keamanan utama untuk memastikan interaksi yang aman dan dapat dipercaya:

- **Persetujuan dan Kontrol Pengguna**: Pengguna harus memberikan persetujuan eksplisit sebelum data diakses atau operasi dilakukan. Berikan kontrol yang jelas atas data apa yang dibagikan dan tindakan apa yang diizinkan.
  
- **Privasi Data**: Data pengguna hanya boleh dibuka dengan persetujuan eksplisit dan harus dilindungi dengan kontrol akses yang tepat. Lindungi dari transmisi data yang tidak sah.
  
- **Keamanan Alat**: Sebelum memanggil alat apa pun, diperlukan persetujuan eksplisit dari pengguna. Pengguna harus memahami dengan jelas fungsi setiap alat, dan batasan keamanan yang kuat harus diterapkan.

## Tujuan Pembelajaran

Setelah menyelesaikan pelajaran ini, Anda akan dapat:

- Menerapkan mekanisme autentikasi dan otorisasi yang aman untuk server MCP.
- Melindungi data sensitif menggunakan enkripsi dan penyimpanan yang aman.
- Memastikan eksekusi alat yang aman dengan kontrol akses yang tepat.
- Menerapkan praktik terbaik untuk perlindungan data dan kepatuhan privasi.
- Mengidentifikasi dan mengatasi kerentanan keamanan MCP umum seperti masalah confused deputy, token passthrough, dan pembajakan sesi.

## Autentikasi dan Otorisasi

Autentikasi dan otorisasi sangat penting untuk mengamankan server MCP. Autentikasi menjawab pertanyaan "Siapa Anda?" sedangkan otorisasi menjawab "Apa yang bisa Anda lakukan?".

Menurut spesifikasi keamanan MCP, berikut adalah pertimbangan keamanan yang krusial:

1. **Validasi Token**: Server MCP TIDAK BOLEH menerima token yang tidak secara eksplisit diterbitkan untuk server MCP tersebut. "Token passthrough" adalah pola anti yang dilarang keras.

2. **Verifikasi Otorisasi**: Server MCP yang menerapkan otorisasi HARUS memverifikasi semua permintaan masuk dan TIDAK BOLEH menggunakan sesi untuk autentikasi.

3. **Manajemen Sesi yang Aman**: Saat menggunakan sesi untuk menyimpan status, server MCP HARUS menggunakan ID sesi yang aman dan tidak deterministik yang dihasilkan dengan generator angka acak yang aman. ID sesi SEBAIKNYA diikat ke informasi spesifik pengguna.

4. **Persetujuan Pengguna Eksplisit**: Untuk server proxy, implementasi MCP HARUS mendapatkan persetujuan pengguna untuk setiap klien yang terdaftar secara dinamis sebelum meneruskan ke server otorisasi pihak ketiga.

Mari kita lihat contoh bagaimana menerapkan autentikasi dan otorisasi yang aman di server MCP menggunakan .NET dan Java.

### Integrasi Identitas .NET

ASP .NET Core Identity menyediakan kerangka kerja yang kuat untuk mengelola autentikasi dan otorisasi pengguna. Kita dapat mengintegrasikannya dengan server MCP untuk mengamankan akses ke alat dan sumber daya.

Ada beberapa konsep inti yang perlu dipahami saat mengintegrasikan ASP.NET Core Identity dengan server MCP, yaitu:

- **Konfigurasi Identitas**: Menyiapkan ASP.NET Core Identity dengan peran dan klaim pengguna. Klaim adalah informasi tentang pengguna, seperti peran atau izin mereka, misalnya "Admin" atau "User".
- **Autentikasi JWT**: Menggunakan JSON Web Tokens (JWT) untuk akses API yang aman. JWT adalah standar untuk mengirimkan informasi secara aman antar pihak dalam bentuk objek JSON, yang dapat diverifikasi dan dipercaya karena ditandatangani secara digital.
- **Kebijakan Otorisasi**: Mendefinisikan kebijakan untuk mengontrol akses ke alat tertentu berdasarkan peran pengguna. MCP menggunakan kebijakan otorisasi untuk menentukan pengguna mana yang dapat mengakses alat mana berdasarkan peran dan klaim mereka.

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

Dalam kode sebelumnya, kita telah:

- Mengonfigurasi ASP.NET Core Identity untuk manajemen pengguna.
- Menyiapkan autentikasi JWT untuk akses API yang aman. Kita menentukan parameter validasi token, termasuk issuer, audience, dan signing key.
- Mendefinisikan kebijakan otorisasi untuk mengontrol akses ke alat berdasarkan peran pengguna. Misalnya, kebijakan "CanUseAdminTools" mengharuskan pengguna memiliki peran "Admin", sedangkan kebijakan "CanUseBasic" mengharuskan pengguna sudah terautentikasi.
- Mendaftarkan alat MCP dengan persyaratan otorisasi spesifik, memastikan hanya pengguna dengan peran yang sesuai yang dapat mengaksesnya.

### Integrasi Java Spring Security

Untuk Java, kita akan menggunakan Spring Security untuk menerapkan autentikasi dan otorisasi yang aman pada server MCP. Spring Security menyediakan kerangka kerja keamanan yang komprehensif dan terintegrasi dengan mulus pada aplikasi Spring.

Konsep inti di sini adalah:

- **Konfigurasi Spring Security**: Menyiapkan konfigurasi keamanan untuk autentikasi dan otorisasi.
- **OAuth2 Resource Server**: Menggunakan OAuth2 untuk akses aman ke alat MCP. OAuth2 adalah kerangka kerja otorisasi yang memungkinkan layanan pihak ketiga menukar token akses untuk akses API yang aman.
- **Interceptor Keamanan**: Menerapkan interceptor keamanan untuk menegakkan kontrol akses pada eksekusi alat.
- **Kontrol Akses Berbasis Peran**: Menggunakan peran untuk mengontrol akses ke alat dan sumber daya tertentu.
- **Anotasi Keamanan**: Menggunakan anotasi untuk mengamankan metode dan endpoint.

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

Dalam kode sebelumnya, kita telah:

- Mengonfigurasi Spring Security untuk mengamankan endpoint MCP, memungkinkan akses publik untuk penemuan alat sambil mengharuskan autentikasi untuk eksekusi alat.
- Menggunakan OAuth2 sebagai resource server untuk menangani akses aman ke alat MCP.
- Menerapkan interceptor keamanan untuk menegakkan kontrol akses pada eksekusi alat, memeriksa peran dan izin pengguna sebelum mengizinkan akses ke alat tertentu.
- Mendefinisikan kontrol akses berbasis peran untuk membatasi akses ke alat admin dan akses data sensitif berdasarkan peran pengguna.

## Perlindungan Data dan Privasi

Perlindungan data sangat penting untuk memastikan informasi sensitif ditangani dengan aman. Ini termasuk melindungi informasi identitas pribadi (PII), data keuangan, dan informasi sensitif lainnya dari akses tidak sah dan kebocoran.

### Contoh Perlindungan Data dengan Python

Mari kita lihat contoh bagaimana menerapkan perlindungan data di Python menggunakan enkripsi dan deteksi PII.

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

Dalam kode sebelumnya, kita telah:

- Menerapkan kelas `PiiDetector` untuk memindai teks dan parameter mencari informasi identitas pribadi (PII).
- Membuat kelas `EncryptionService` untuk menangani enkripsi dan dekripsi data sensitif menggunakan pustaka `cryptography`.
- Mendefinisikan dekorator `secure_tool` yang membungkus eksekusi alat untuk memeriksa PII, mencatat akses, dan mengenkripsi data sensitif jika diperlukan.
- Menerapkan dekorator `secure_tool` pada alat contoh (`SecureCustomerDataTool`) untuk memastikan alat tersebut menangani data sensitif dengan aman.

## Risiko Keamanan Khusus MCP

Menurut dokumentasi keamanan resmi MCP, ada risiko keamanan spesifik yang harus diperhatikan oleh para pengembang MCP:

### 1. Masalah Confused Deputy

Kerentanan ini terjadi ketika server MCP bertindak sebagai proxy ke API pihak ketiga, yang memungkinkan penyerang mengeksploitasi hubungan kepercayaan antara server MCP dan API tersebut.

**Mitigasi:**
- Server proxy MCP yang menggunakan client ID statis HARUS mendapatkan persetujuan pengguna untuk setiap klien yang terdaftar secara dinamis sebelum meneruskan ke server otorisasi pihak ketiga.
- Terapkan alur OAuth yang tepat dengan PKCE (Proof Key for Code Exchange) untuk permintaan otorisasi.
- Validasi URI pengalihan dan pengenal klien dengan ketat.

### 2. Kerentanan Token Passthrough

Token passthrough terjadi ketika server MCP menerima token dari klien MCP tanpa memvalidasi bahwa token tersebut diterbitkan dengan benar untuk server MCP dan meneruskannya ke API hilir.

### Risiko
- Penghindaran kontrol keamanan (melewati pembatasan laju, validasi permintaan)
- Masalah akuntabilitas dan jejak audit
- Pelanggaran batas kepercayaan
- Risiko kompatibilitas di masa depan

**Mitigasi:**
- Server MCP TIDAK BOLEH menerima token yang tidak secara eksplisit diterbitkan untuk server MCP.
- Selalu validasi klaim audience token untuk memastikan sesuai dengan layanan yang diharapkan.

### 3. Pembajakan Sesi

Ini terjadi ketika pihak tidak berwenang mendapatkan ID sesi dan menggunakannya untuk menyamar sebagai klien asli, yang berpotensi menyebabkan tindakan tidak sah.

**Mitigasi:**
- Server MCP yang menerapkan otorisasi HARUS memverifikasi semua permintaan masuk dan TIDAK BOLEH menggunakan sesi untuk autentikasi.
- Gunakan ID sesi yang aman dan tidak deterministik yang dihasilkan dengan generator angka acak yang aman.
- Ikat ID sesi ke informasi spesifik pengguna menggunakan format kunci seperti `<user_id>:<session_id>`.
- Terapkan kebijakan kedaluwarsa dan rotasi sesi yang tepat.

## Praktik Keamanan Tambahan untuk MCP

Selain pertimbangan keamanan inti MCP, pertimbangkan untuk menerapkan praktik keamanan tambahan berikut:

- **Selalu gunakan HTTPS**: Enkripsi komunikasi antara klien dan server untuk melindungi token dari penyadapan.
- **Terapkan Kontrol Akses Berbasis Peran (RBAC)**: Jangan hanya memeriksa apakah pengguna sudah terautentikasi; periksa juga apa yang mereka diizinkan lakukan.
- **Pantau dan audit**: Catat semua kejadian autentikasi untuk mendeteksi dan merespons aktivitas mencurigakan.
- **Tangani pembatasan laju dan throttling**: Terapkan exponential backoff dan logika retry untuk menangani batasan laju dengan baik.
- **Simpan token dengan aman**: Simpan token akses dan token refresh dengan aman menggunakan mekanisme penyimpanan aman sistem atau layanan manajemen kunci yang aman.
- **Pertimbangkan menggunakan Manajemen API**: Layanan seperti Azure API Management dapat menangani banyak masalah keamanan secara otomatis, termasuk autentikasi, otorisasi, dan pembatasan laju.

## Referensi

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Selanjutnya

- [5.9 Web search](../web-search-mcp/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.