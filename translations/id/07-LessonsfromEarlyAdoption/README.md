<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:28:19+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "id"
}
-->
# Pelajaran dari Pengadopsi Awal

## Gambaran Umum

Pelajaran ini menjelaskan bagaimana pengadopsi awal telah memanfaatkan Model Context Protocol (MCP) untuk menyelesaikan tantangan nyata dan mendorong inovasi di berbagai industri. Melalui studi kasus yang mendetail dan proyek langsung, Anda akan melihat bagaimana MCP memungkinkan integrasi AI yang terstandarisasi, aman, dan dapat diskalakan—menghubungkan model bahasa besar, alat, dan data perusahaan dalam satu kerangka kerja. Anda akan mendapatkan pengalaman praktis dalam merancang dan membangun solusi berbasis MCP, belajar dari pola implementasi yang terbukti, dan menemukan praktik terbaik untuk menerapkan MCP dalam lingkungan produksi. Pelajaran ini juga menyoroti tren yang muncul, arah masa depan, dan sumber daya open-source untuk membantu Anda tetap berada di garis depan teknologi MCP dan ekosistemnya yang berkembang.

## Tujuan Pembelajaran

- Menganalisis implementasi MCP nyata di berbagai industri
- Merancang dan membangun aplikasi berbasis MCP yang lengkap
- Menjelajahi tren yang muncul dan arah masa depan dalam teknologi MCP
- Menerapkan praktik terbaik dalam skenario pengembangan nyata

## Implementasi MCP Dunia Nyata

### Studi Kasus 1: Otomatisasi Dukungan Pelanggan Perusahaan

Sebuah perusahaan multinasional mengimplementasikan solusi berbasis MCP untuk menstandarisasi interaksi AI di seluruh sistem dukungan pelanggan mereka. Ini memungkinkan mereka untuk:

- Membuat antarmuka terpadu untuk beberapa penyedia LLM
- Mempertahankan manajemen prompt yang konsisten di seluruh departemen
- Menerapkan kontrol keamanan dan kepatuhan yang kuat
- Mudah beralih antara model AI yang berbeda berdasarkan kebutuhan spesifik

**Implementasi Teknis:**
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**Hasil:** Pengurangan biaya model sebesar 30%, peningkatan konsistensi respons sebesar 45%, dan peningkatan kepatuhan di seluruh operasi global.

### Studi Kasus 2: Asisten Diagnostik Kesehatan

Penyedia layanan kesehatan mengembangkan infrastruktur MCP untuk mengintegrasikan beberapa model AI medis khusus sambil memastikan data pasien yang sensitif tetap terlindungi:

- Pergantian mulus antara model medis umum dan spesialis
- Kontrol privasi yang ketat dan jejak audit
- Integrasi dengan sistem Rekam Medis Elektronik (EHR) yang ada
- Rekayasa prompt yang konsisten untuk terminologi medis

**Implementasi Teknis:**
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**Hasil:** Peningkatan saran diagnostik untuk dokter sambil mempertahankan kepatuhan penuh HIPAA dan pengurangan signifikan dalam pergantian konteks antara sistem.

### Studi Kasus 3: Analisis Risiko Layanan Keuangan

Sebuah institusi keuangan mengimplementasikan MCP untuk menstandarisasi proses analisis risiko mereka di berbagai departemen:

- Membuat antarmuka terpadu untuk model risiko kredit, deteksi penipuan, dan risiko investasi
- Menerapkan kontrol akses yang ketat dan versi model
- Memastikan auditabilitas semua rekomendasi AI
- Mempertahankan format data yang konsisten di seluruh sistem yang beragam

**Implementasi Teknis:**
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**Hasil:** Peningkatan kepatuhan regulasi, siklus penerapan model yang 40% lebih cepat, dan konsistensi penilaian risiko yang lebih baik di seluruh departemen.

### Studi Kasus 4: Microsoft Playwright MCP Server untuk Otomatisasi Peramban

Microsoft mengembangkan [server Playwright MCP](https://github.com/microsoft/playwright-mcp) untuk memungkinkan otomasi peramban yang aman dan terstandarisasi melalui Model Context Protocol. Solusi ini memungkinkan agen AI dan LLM untuk berinteraksi dengan peramban web dengan cara yang terkontrol, dapat diaudit, dan dapat diperluas—memungkinkan kasus penggunaan seperti pengujian web otomatis, ekstraksi data, dan alur kerja end-to-end.

- Memaparkan kemampuan otomasi peramban (navigasi, pengisian formulir, pengambilan tangkapan layar, dll.) sebagai alat MCP
- Menerapkan kontrol akses yang ketat dan sandboxing untuk mencegah tindakan yang tidak sah
- Menyediakan log audit yang terperinci untuk semua interaksi peramban
- Mendukung integrasi dengan Azure OpenAI dan penyedia LLM lainnya untuk otomasi yang digerakkan oleh agen

**Implementasi Teknis:**
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**Hasil:**  
- Memungkinkan otomasi peramban programatik yang aman untuk agen AI dan LLM
- Mengurangi upaya pengujian manual dan meningkatkan cakupan pengujian untuk aplikasi web
- Menyediakan kerangka kerja yang dapat digunakan kembali dan dapat diperluas untuk integrasi alat berbasis peramban di lingkungan perusahaan

**Referensi:**  
- [Repositori GitHub Server Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Solusi AI dan Otomasi Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### Studi Kasus 5: Azure MCP – Protokol Konteks Model Tingkat Perusahaan sebagai Layanan

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) adalah implementasi terkelola Microsoft yang berkualitas perusahaan dari Model Context Protocol, dirancang untuk menyediakan kemampuan server MCP yang skalabel, aman, dan patuh sebagai layanan cloud. Azure MCP memungkinkan organisasi untuk dengan cepat menerapkan, mengelola, dan mengintegrasikan server MCP dengan layanan AI, data, dan keamanan Azure, mengurangi overhead operasional dan mempercepat adopsi AI.

- Hosting server MCP yang sepenuhnya terkelola dengan penskalaan, pemantauan, dan keamanan bawaan
- Integrasi asli dengan Azure OpenAI, Azure AI Search, dan layanan Azure lainnya
- Otentikasi dan otorisasi perusahaan melalui Microsoft Entra ID
- Dukungan untuk alat khusus, template prompt, dan konektor sumber daya
- Kepatuhan dengan persyaratan keamanan dan regulasi perusahaan

**Implementasi Teknis:**
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**Hasil:**  
- Mengurangi waktu untuk mendapatkan nilai bagi proyek AI perusahaan dengan menyediakan platform server MCP yang siap pakai dan patuh
- Menyederhanakan integrasi LLM, alat, dan sumber data perusahaan
- Meningkatkan keamanan, observabilitas, dan efisiensi operasional untuk beban kerja MCP

**Referensi:**  
- [Dokumentasi Azure MCP](https://aka.ms/azmcp)
- [Layanan AI Azure](https://azure.microsoft.com/en-us/products/ai-services/)

## Proyek Langsung

### Proyek 1: Membangun Server MCP Multi-Penyedia

**Tujuan:** Membuat server MCP yang dapat mengarahkan permintaan ke beberapa penyedia model AI berdasarkan kriteria tertentu.

**Persyaratan:**
- Mendukung setidaknya tiga penyedia model yang berbeda (misalnya, OpenAI, Anthropic, model lokal)
- Menerapkan mekanisme pengarah berdasarkan metadata permintaan
- Membuat sistem konfigurasi untuk mengelola kredensial penyedia
- Menambahkan caching untuk mengoptimalkan kinerja dan biaya
- Membangun dasbor sederhana untuk memantau penggunaan

**Langkah Implementasi:**
1. Menyiapkan infrastruktur server MCP dasar
2. Menerapkan adaptor penyedia untuk setiap layanan model AI
3. Membuat logika pengarah berdasarkan atribut permintaan
4. Menambahkan mekanisme caching untuk permintaan yang sering
5. Mengembangkan dasbor pemantauan
6. Menguji dengan berbagai pola permintaan

**Teknologi:** Pilih dari Python (.NET/Java/Python berdasarkan preferensi Anda), Redis untuk caching, dan kerangka kerja web sederhana untuk dasbor.

### Proyek 2: Sistem Manajemen Prompt Perusahaan

**Tujuan:** Mengembangkan sistem berbasis MCP untuk mengelola, membuat versi, dan menerapkan template prompt di seluruh organisasi.

**Persyaratan:**
- Membuat repositori terpusat untuk template prompt
- Menerapkan sistem versi dan alur kerja persetujuan
- Membangun kemampuan pengujian template dengan input sampel
- Mengembangkan kontrol akses berbasis peran
- Membuat API untuk pengambilan dan penerapan template

**Langkah Implementasi:**
1. Merancang skema basis data untuk penyimpanan template
2. Membuat API inti untuk operasi CRUD template
3. Menerapkan sistem versi
4. Membangun alur kerja persetujuan
5. Mengembangkan kerangka kerja pengujian
6. Membuat antarmuka web sederhana untuk manajemen
7. Mengintegrasikan dengan server MCP

**Teknologi:** Pilihan kerangka kerja backend Anda, basis data SQL atau NoSQL, dan kerangka kerja frontend untuk antarmuka manajemen.

### Proyek 3: Platform Pembangkitan Konten Berbasis MCP

**Tujuan:** Membangun platform pembangkitan konten yang memanfaatkan MCP untuk memberikan hasil yang konsisten di berbagai jenis konten.

**Persyaratan:**
- Mendukung berbagai format konten (posting blog, media sosial, salinan pemasaran)
- Menerapkan pembangkitan berbasis template dengan opsi kustomisasi
- Membuat sistem tinjauan dan umpan balik konten
- Melacak metrik kinerja konten
- Mendukung versi dan iterasi konten

**Langkah Implementasi:**
1. Menyiapkan infrastruktur klien MCP
2. Membuat template untuk berbagai jenis konten
3. Membangun pipeline pembangkitan konten
4. Menerapkan sistem tinjauan
5. Mengembangkan sistem pelacakan metrik
6. Membuat antarmuka pengguna untuk manajemen template dan pembangkitan konten

**Teknologi:** Bahasa pemrograman pilihan Anda, kerangka kerja web, dan sistem basis data.

## Arah Masa Depan untuk Teknologi MCP

### Tren yang Muncul

1. **MCP Multi-Modal**
   - Ekspansi MCP untuk menstandarisasi interaksi dengan model gambar, audio, dan video
   - Pengembangan kemampuan penalaran lintas-modal
   - Format prompt yang terstandarisasi untuk berbagai modalitas

2. **Infrastruktur MCP Terdistribusi**
   - Jaringan MCP terdistribusi yang dapat berbagi sumber daya di seluruh organisasi
   - Protokol terstandarisasi untuk berbagi model yang aman
   - Teknik komputasi yang melindungi privasi

3. **Pasar MCP**
   - Ekosistem untuk berbagi dan memonetisasi template dan plugin MCP
   - Proses penjaminan kualitas dan sertifikasi
   - Integrasi dengan pasar model

4. **MCP untuk Komputasi Tepi**
   - Adaptasi standar MCP untuk perangkat tepi yang terbatas sumber daya
   - Protokol yang dioptimalkan untuk lingkungan dengan bandwidth rendah
   - Implementasi MCP khusus untuk ekosistem IoT

5. **Kerangka Regulasi**
   - Pengembangan ekstensi MCP untuk kepatuhan regulasi
   - Jejak audit terstandarisasi dan antarmuka penjelasan
   - Integrasi dengan kerangka kerja tata kelola AI yang muncul

### Solusi MCP dari Microsoft

Microsoft dan Azure telah mengembangkan beberapa repositori open-source untuk membantu pengembang mengimplementasikan MCP dalam berbagai skenario:

#### Organisasi Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Server Playwright MCP untuk otomasi dan pengujian peramban
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementasi server MCP OneDrive untuk pengujian lokal dan kontribusi komunitas

#### Organisasi Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - Tautan ke sampel, alat, dan sumber daya untuk membangun dan mengintegrasikan server MCP di Azure menggunakan berbagai bahasa
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Server referensi MCP yang menunjukkan otentikasi dengan spesifikasi Model Context Protocol saat ini
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Halaman pendaratan untuk implementasi Server MCP Jarak Jauh dalam Fungsi Azure dengan tautan ke repositori bahasa spesifik
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Template mulai cepat untuk membangun dan menerapkan server MCP jarak jauh khusus menggunakan Fungsi Azure dengan Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Template mulai cepat untuk membangun dan menerapkan server MCP jarak jauh khusus menggunakan Fungsi Azure dengan .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Template mulai cepat untuk membangun dan menerapkan server MCP jarak jauh khusus menggunakan Fungsi Azure dengan TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Manajemen API Azure sebagai Gerbang AI ke server MCP jarak jauh menggunakan Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Eksperimen APIM ❤️ AI termasuk kemampuan MCP, mengintegrasikan dengan Azure OpenAI dan AI Foundry

Repositori ini menyediakan berbagai implementasi, template, dan sumber daya untuk bekerja dengan Model Context Protocol di berbagai bahasa pemrograman dan layanan Azure. Mereka mencakup berbagai kasus penggunaan dari implementasi server dasar hingga otentikasi, penerapan cloud, dan skenario integrasi perusahaan.

#### Direktori Sumber Daya MCP

Direktori [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) di repositori MCP resmi Microsoft menyediakan koleksi sumber daya sampel, template prompt, dan definisi alat yang dikurasi untuk digunakan dengan server Model Context Protocol. Direktori ini dirancang untuk membantu pengembang dengan cepat memulai dengan MCP dengan menawarkan blok bangunan yang dapat digunakan kembali dan contoh praktik terbaik untuk:

- **Template Prompt:** Template prompt siap pakai untuk tugas dan skenario AI umum, yang dapat disesuaikan untuk implementasi server MCP Anda sendiri.
- **Definisi Alat:** Skema alat contoh dan metadata untuk menstandarisasi integrasi dan pemanggilan alat di seluruh server MCP yang berbeda.
- **Sampel Sumber Daya:** Definisi sumber daya contoh untuk menghubungkan ke sumber data, API, dan layanan eksternal dalam kerangka MCP.
- **Implementasi Referensi:** Sampel praktis yang menunjukkan bagaimana menyusun dan mengatur sumber daya, prompt, dan alat dalam proyek MCP dunia nyata.

Sumber daya ini mempercepat pengembangan, mempromosikan standarisasi, dan membantu memastikan praktik terbaik saat membangun dan menerapkan solusi berbasis MCP.

#### Direktori Sumber Daya MCP
- [Sumber Daya MCP (Prompt Sampel, Alat, dan Definisi Sumber Daya)](https://github.com/microsoft/mcp/tree/main/Resources)

### Peluang Penelitian

- Teknik optimasi prompt yang efisien dalam kerangka MCP
- Model keamanan untuk penerapan MCP multi-penyewa
- Benchmarking kinerja di berbagai implementasi MCP
- Metode verifikasi formal untuk server MCP

## Kesimpulan

Model Context Protocol (MCP) dengan cepat membentuk masa depan integrasi AI yang terstandarisasi, aman, dan dapat dioperasikan di berbagai industri. Melalui studi kasus dan proyek langsung dalam pelajaran ini, Anda telah melihat bagaimana pengadopsi awal—termasuk Microsoft dan Azure—memanfaatkan MCP untuk menyelesaikan tantangan nyata, mempercepat adopsi AI, dan memastikan kepatuhan, keamanan, dan skalabilitas. Pendekatan modular MCP memungkinkan organisasi untuk menghubungkan model bahasa besar, alat, dan data perusahaan dalam kerangka kerja yang terpadu dan dapat diaudit. Saat MCP terus berkembang, tetap terlibat dengan komunitas, menjelajahi sumber daya open-source, dan menerapkan praktik terbaik akan menjadi kunci untuk membangun solusi AI yang kuat dan siap masa depan.

## Sumber Daya Tambahan

- [Repositori GitHub MCP (Microsoft)](https://github.com/microsoft/mcp)
- [Direktori Sumber Daya MCP (Prompt Sampel, Alat, dan Definisi Sumber Daya)](https://github.com/microsoft/mcp/tree/main/Resources)
- [Komunitas & Dokumentasi MCP](https://modelcontextprotocol.io/introduction)
- [Dokumentasi Azure MCP](https://aka.ms/azmcp)
- [Repositori GitHub Server Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Server MCP Files (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [Server Autentikasi MCP (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Fungsi MCP Jarak Jauh (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Fungsi MCP Jarak Jauh Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Fungsi MCP Jarak Jauh .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Fungsi MCP Jarak Jauh TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Latihan

1. Analisis salah satu studi kasus dan usulkan pendekatan implementasi alternatif.
2. Pilih salah satu ide proyek dan buat spesifikasi teknis yang terperinci.
3. Teliti industri yang tidak tercakup dalam studi kasus dan gambarkan bagaimana MCP dapat mengatasi tantangan spesifiknya.
4. Jelajahi salah satu arah masa depan dan buat konsep untuk ekstensi MCP baru untuk mendukungnya.

Selanjutnya: [Praktik Terbaik](../08-BestPractices/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap disadari bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.