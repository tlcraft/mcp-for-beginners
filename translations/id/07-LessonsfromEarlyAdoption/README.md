<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:43:47+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "id"
}
-->
# Pelajaran dari Pengadopsi Awal

## Ikhtisar

Pelajaran ini mengeksplorasi bagaimana pengadopsi awal memanfaatkan Model Context Protocol (MCP) untuk menyelesaikan tantangan dunia nyata dan mendorong inovasi di berbagai industri. Melalui studi kasus yang mendetail dan proyek praktis, Anda akan melihat bagaimana MCP memungkinkan integrasi AI yang standar, aman, dan skalabel—menghubungkan model bahasa besar, alat, dan data perusahaan dalam kerangka kerja terpadu. Anda akan mendapatkan pengalaman praktis dalam merancang dan membangun solusi berbasis MCP, mempelajari pola implementasi yang terbukti, dan menemukan praktik terbaik untuk menerapkan MCP di lingkungan produksi. Pelajaran ini juga menyoroti tren yang muncul, arah masa depan, dan sumber daya open-source untuk membantu Anda tetap berada di garis depan teknologi MCP dan ekosistemnya yang berkembang.

## Tujuan Pembelajaran

- Menganalisis implementasi MCP dunia nyata di berbagai industri  
- Merancang dan membangun aplikasi lengkap berbasis MCP  
- Mengeksplorasi tren baru dan arah masa depan teknologi MCP  
- Menerapkan praktik terbaik dalam skenario pengembangan nyata  

## Implementasi MCP Dunia Nyata

### Studi Kasus 1: Otomasi Dukungan Pelanggan Perusahaan

Sebuah perusahaan multinasional mengimplementasikan solusi berbasis MCP untuk menstandarisasi interaksi AI di seluruh sistem dukungan pelanggan mereka. Hal ini memungkinkan mereka untuk:

- Membuat antarmuka terpadu untuk beberapa penyedia LLM  
- Mempertahankan manajemen prompt yang konsisten di berbagai departemen  
- Menerapkan kontrol keamanan dan kepatuhan yang kuat  
- Dengan mudah beralih antara model AI yang berbeda sesuai kebutuhan spesifik  

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

- Peralihan mulus antara model medis generalis dan spesialis  
- Kontrol privasi yang ketat dan jejak audit  
- Integrasi dengan sistem Electronic Health Record (EHR) yang ada  
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

**Hasil:** Peningkatan saran diagnostik untuk dokter dengan tetap menjaga kepatuhan HIPAA penuh dan pengurangan signifikan dalam perpindahan konteks antar sistem.

### Studi Kasus 3: Analisis Risiko Layanan Keuangan

Sebuah institusi keuangan mengimplementasikan MCP untuk menstandarisasi proses analisis risiko di berbagai departemen:

- Membuat antarmuka terpadu untuk model risiko kredit, deteksi penipuan, dan risiko investasi  
- Menerapkan kontrol akses ketat dan versi model  
- Menjamin auditabilitas semua rekomendasi AI  
- Mempertahankan format data yang konsisten di berbagai sistem  

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

**Hasil:** Kepatuhan regulasi yang lebih baik, siklus penyebaran model 40% lebih cepat, dan konsistensi penilaian risiko yang meningkat di seluruh departemen.

### Studi Kasus 4: Microsoft Playwright MCP Server untuk Otomasi Browser

Microsoft mengembangkan [Playwright MCP server](https://github.com/microsoft/playwright-mcp) untuk memungkinkan otomasi browser yang aman dan standar melalui Model Context Protocol. Solusi ini memungkinkan agen AI dan LLM berinteraksi dengan browser web secara terkontrol, dapat diaudit, dan dapat diperluas—mendukung kasus penggunaan seperti pengujian web otomatis, ekstraksi data, dan alur kerja end-to-end.

- Mengekspos kemampuan otomasi browser (navigasi, pengisian formulir, tangkapan layar, dll.) sebagai alat MCP  
- Menerapkan kontrol akses ketat dan sandboxing untuk mencegah tindakan tidak sah  
- Menyediakan log audit rinci untuk semua interaksi browser  
- Mendukung integrasi dengan Azure OpenAI dan penyedia LLM lain untuk otomasi yang digerakkan agen  

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
- Memungkinkan otomasi browser yang aman dan terprogram untuk agen AI dan LLM  
- Mengurangi upaya pengujian manual dan meningkatkan cakupan pengujian aplikasi web  
- Menyediakan kerangka kerja yang dapat digunakan kembali dan diperluas untuk integrasi alat berbasis browser di lingkungan perusahaan  

**Referensi:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studi Kasus 5: Azure MCP – Model Context Protocol Tingkat Perusahaan sebagai Layanan

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) adalah implementasi MCP tingkat perusahaan yang dikelola oleh Microsoft, dirancang untuk menyediakan kemampuan server MCP yang skalabel, aman, dan patuh sebagai layanan cloud. Azure MCP memungkinkan organisasi untuk dengan cepat menyebarkan, mengelola, dan mengintegrasikan server MCP dengan layanan Azure AI, data, dan keamanan, mengurangi beban operasional dan mempercepat adopsi AI.

- Hosting server MCP yang sepenuhnya dikelola dengan penskalaan, pemantauan, dan keamanan bawaan  
- Integrasi native dengan Azure OpenAI, Azure AI Search, dan layanan Azure lainnya  
- Otentikasi dan otorisasi tingkat perusahaan melalui Microsoft Entra ID  
- Dukungan untuk alat kustom, template prompt, dan konektor sumber daya  
- Kepatuhan terhadap persyaratan keamanan dan regulasi perusahaan  

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
- Mempercepat waktu ke nilai untuk proyek AI perusahaan dengan menyediakan platform server MCP yang siap pakai dan patuh  
- Menyederhanakan integrasi LLM, alat, dan sumber data perusahaan  
- Meningkatkan keamanan, keterlihatan, dan efisiensi operasional untuk beban kerja MCP  

**Referensi:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studi Kasus 6: NLWeb  
MCP (Model Context Protocol) adalah protokol yang sedang berkembang untuk chatbot dan asisten AI berinteraksi dengan alat. Setiap instance NLWeb juga merupakan server MCP, yang mendukung satu metode inti, ask, yang digunakan untuk mengajukan pertanyaan ke situs web dalam bahasa alami. Respons yang dikembalikan memanfaatkan schema.org, kosakata yang banyak digunakan untuk mendeskripsikan data web. Secara longgar, MCP adalah NLWeb seperti Http terhadap HTML. NLWeb menggabungkan protokol, format Schema.org, dan kode contoh untuk membantu situs dengan cepat membuat endpoint ini, memberikan manfaat bagi manusia melalui antarmuka percakapan dan mesin melalui interaksi agen-ke-agen alami.

Ada dua komponen berbeda dalam NLWeb.  
- Sebuah protokol, sangat sederhana untuk memulai, untuk berinteraksi dengan situs dalam bahasa alami dan format, memanfaatkan json dan schema.org untuk jawaban yang dikembalikan. Lihat dokumentasi REST API untuk detail lebih lanjut.  
- Implementasi sederhana dari (1) yang memanfaatkan markup yang ada, untuk situs yang dapat diabstraksi sebagai daftar item (produk, resep, atraksi, ulasan, dll.). Bersama dengan seperangkat widget antarmuka pengguna, situs dapat dengan mudah menyediakan antarmuka percakapan untuk konten mereka. Lihat dokumentasi Life of a chat query untuk lebih jelasnya tentang cara kerjanya.  

**Referensi:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studi Kasus 7: MCP untuk Foundry – Integrasi Azure AI Agents

Server MCP Azure AI Foundry menunjukkan bagaimana MCP dapat digunakan untuk mengatur dan mengelola agen AI dan alur kerja di lingkungan perusahaan. Dengan mengintegrasikan MCP dengan Azure AI Foundry, organisasi dapat menstandarisasi interaksi agen, memanfaatkan manajemen alur kerja Foundry, dan memastikan penyebaran yang aman dan skalabel. Pendekatan ini memungkinkan prototipe cepat, pemantauan yang kuat, dan integrasi mulus dengan layanan Azure AI, mendukung skenario lanjutan seperti manajemen pengetahuan dan evaluasi agen. Pengembang mendapatkan antarmuka terpadu untuk membangun, menyebarkan, dan memantau pipeline agen, sementara tim TI mendapatkan peningkatan keamanan, kepatuhan, dan efisiensi operasional. Solusi ini ideal bagi perusahaan yang ingin mempercepat adopsi AI dan mempertahankan kontrol atas proses kompleks yang digerakkan agen.

**Referensi:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studi Kasus 8: Foundry MCP Playground – Eksperimen dan Prototipe

Foundry MCP Playground menawarkan lingkungan siap pakai untuk bereksperimen dengan server MCP dan integrasi Azure AI Foundry. Pengembang dapat dengan cepat membuat prototipe, menguji, dan mengevaluasi model AI dan alur kerja agen menggunakan sumber daya dari Azure AI Foundry Catalog dan Labs. Playground menyederhanakan pengaturan, menyediakan proyek contoh, dan mendukung pengembangan kolaboratif, sehingga mudah untuk mengeksplorasi praktik terbaik dan skenario baru dengan overhead minimal. Ini sangat berguna bagi tim yang ingin memvalidasi ide, berbagi eksperimen, dan mempercepat pembelajaran tanpa perlu infrastruktur kompleks. Dengan menurunkan hambatan masuk, playground membantu mendorong inovasi dan kontribusi komunitas dalam ekosistem MCP dan Azure AI Foundry.

**Referensi:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Proyek Praktis

### Proyek 1: Bangun Server MCP Multi-Penyedia

**Tujuan:** Membuat server MCP yang dapat mengarahkan permintaan ke beberapa penyedia model AI berdasarkan kriteria tertentu.

**Persyaratan:**  
- Mendukung minimal tiga penyedia model berbeda (misal OpenAI, Anthropic, model lokal)  
- Menerapkan mekanisme routing berdasarkan metadata permintaan  
- Membuat sistem konfigurasi untuk mengelola kredensial penyedia  
- Menambahkan caching untuk mengoptimalkan performa dan biaya  
- Membangun dashboard sederhana untuk pemantauan penggunaan  

**Langkah Implementasi:**  
1. Siapkan infrastruktur server MCP dasar  
2. Implementasikan adapter penyedia untuk setiap layanan model AI  
3. Buat logika routing berdasarkan atribut permintaan  
4. Tambahkan mekanisme caching untuk permintaan yang sering  
5. Kembangkan dashboard pemantauan  
6. Uji dengan berbagai pola permintaan  

**Teknologi:** Pilih dari Python (.NET/Java/Python sesuai preferensi), Redis untuk caching, dan framework web sederhana untuk dashboard.

### Proyek 2: Sistem Manajemen Prompt Perusahaan

**Tujuan:** Mengembangkan sistem berbasis MCP untuk mengelola, memversioning, dan menyebarkan template prompt di seluruh organisasi.

**Persyaratan:**  
- Membuat repositori terpusat untuk template prompt  
- Menerapkan versioning dan workflow persetujuan  
- Membangun kemampuan pengujian template dengan input contoh  
- Mengembangkan kontrol akses berbasis peran  
- Membuat API untuk pengambilan dan penyebaran template  

**Langkah Implementasi:**  
1. Rancang skema database untuk penyimpanan template  
2. Buat API inti untuk operasi CRUD template  
3. Implementasikan sistem versioning  
4. Bangun workflow persetujuan  
5. Kembangkan framework pengujian  
6. Buat antarmuka web sederhana untuk manajemen  
7. Integrasikan dengan server MCP  

**Teknologi:** Pilihan framework backend, database SQL atau NoSQL, dan framework frontend untuk antarmuka manajemen.

### Proyek 3: Platform Generasi Konten Berbasis MCP

**Tujuan:** Membangun platform generasi konten yang memanfaatkan MCP untuk memberikan hasil konsisten di berbagai jenis konten.

**Persyaratan:**  
- Mendukung berbagai format konten (posting blog, media sosial, salinan pemasaran)  
- Menerapkan generasi berbasis template dengan opsi kustomisasi  
- Membuat sistem review dan umpan balik konten  
- Melacak metrik performa konten  
- Mendukung versioning dan iterasi konten  

**Langkah Implementasi:**  
1. Siapkan infrastruktur klien MCP  
2. Buat template untuk berbagai jenis konten  
3. Bangun pipeline generasi konten  
4. Implementasikan sistem review  
5. Kembangkan sistem pelacakan metrik  
6. Buat antarmuka pengguna untuk manajemen template dan generasi konten  

**Teknologi:** Bahasa pemrograman pilihan, framework web, dan sistem database.

## Arah Masa Depan Teknologi MCP

### Tren yang Muncul

1. **MCP Multi-Modal**  
   - Perluasan MCP untuk menstandarisasi interaksi dengan model gambar, audio, dan video  
   - Pengembangan kemampuan penalaran lintas modalitas  
   - Format prompt standar untuk berbagai modalitas  

2. **Infrastruktur MCP Terdistribusi**  
   - Jaringan MCP terdistribusi yang dapat berbagi sumber daya antar organisasi  
   - Protokol standar untuk berbagi model secara aman  
   - Teknik komputasi yang menjaga privasi  

3. **Marketplace MCP**  
   - Ekosistem untuk berbagi dan memonetisasi template dan plugin MCP  
   - Proses jaminan kualitas dan sertifikasi  
   - Integrasi dengan marketplace model  

4. **MCP untuk Edge Computing**  
   - Adaptasi standar MCP untuk perangkat edge dengan sumber daya terbatas  
   - Protokol yang dioptimalkan untuk lingkungan bandwidth rendah  
   - Implementasi MCP khusus untuk ekosistem IoT  

5. **Kerangka Regulasi**  
   - Pengembangan ekstensi MCP untuk kepatuhan regulasi  
   - Jejak audit standar dan antarmuka keterjelasan  
   - Integrasi dengan kerangka tata kelola AI yang sedang berkembang  

### Solusi MCP dari Microsoft

Microsoft dan Azure telah mengembangkan beberapa repositori open-source untuk membantu pengembang mengimplementasikan MCP dalam berbagai skenario:

#### Organisasi Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Server Playwright MCP untuk otomasi dan pengujian browser  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementasi server MCP OneDrive untuk pengujian lokal dan kontribusi komunitas  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Kumpulan protokol terbuka dan alat open source terkait, fokus pada lapisan dasar untuk AI Web  

#### Organisasi Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - Tautan ke sampel, alat, dan sumber daya untuk membangun dan mengintegrasikan server MCP di Azure dengan berbagai bahasa  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Referensi server MCP yang menunjukkan otentikasi dengan spesifikasi Model Context Protocol saat ini  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Halaman landing untuk implementasi Remote MCP Server di Azure Functions dengan tautan ke repositori bahasa spesifik  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Template quickstart untuk membangun dan menyebarkan server MCP remote kustom menggunakan Azure Functions dengan Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Template quickstart untuk membangun dan menyebarkan server MCP remote kustom menggunakan Azure Functions dengan .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Template quickstart untuk membangun dan menyebarkan server MCP remote kustom menggunakan Azure Functions dengan TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management sebagai AI Gateway ke server MCP remote menggunakan Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Eksperimen APIM ❤️ AI termasuk kemampuan MCP, integrasi dengan Azure OpenAI dan AI Foundry  

Repositori ini menyediakan berbagai implementasi, template, dan sumber daya untuk bekerja dengan Model Context Protocol di berbagai bahasa pemrograman dan layanan Azure. Mereka mencakup berbagai kasus penggunaan dari implementasi server dasar hingga otentikasi, penyebaran cloud, dan skenario integrasi perusahaan.

#### Direktori Sumber Daya MCP

[Direktori MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) di repositori resmi Microsoft MCP menyediakan koleksi sumber daya contoh, template prompt, dan definisi alat untuk digunakan dengan server Model Context Protocol. Direktori ini dirancang untuk membantu pengembang memulai dengan cepat menggunakan MCP dengan menawarkan blok bangunan yang dapat digunakan ulang dan contoh praktik terbaik untuk:

- **Template Prompt:** Template prompt siap pakai untuk tugas dan skenario AI umum, yang dapat disesuaikan untuk implementasi server MCP Anda sendiri.  
- **Definisi Alat:** Skema dan metadata alat contoh untuk menstandarisasi integrasi dan pemanggilan alat di berbagai server MCP.  
- **Contoh Sumber Daya:** Definisi sumber daya contoh untuk menghubungkan ke sumber data, API, dan layanan eksternal dalam kerangka MCP.  
- **Implementasi Referensi:** Contoh praktis yang menunjukkan cara menyusun dan mengorganisasi sumber daya, prompt, dan alat dalam proyek MCP dunia nyata.  

Sumber daya ini mempercepat pengembangan, mendorong standarisasi, dan membantu memastikan praktik terbaik saat membangun dan menerapkan solusi berbasis MCP.

#### Direktori MCP Resources  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Peluang Riset

- Teknik optimasi prompt yang efisien dalam kerangka MCP  
- Model keamanan untuk penyebaran MCP multi-tenant  
- Benchmark performa di berbagai implementasi MCP  
- Metode verifikasi formal untuk server MCP  

## Kesimpulan

Model Context Protocol (MCP) dengan cepat membentuk masa depan integrasi AI yang standar, aman, dan interoperabel di berbagai industri. Melalui studi kasus dan proyek praktis dalam pelajaran ini, Anda telah melihat bagaimana pengadopsi awal—termas
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Latihan

1. Analisis salah satu studi kasus dan usulkan pendekatan implementasi alternatif.
2. Pilih salah satu ide proyek dan buat spesifikasi teknis yang rinci.
3. Teliti sebuah industri yang tidak dibahas dalam studi kasus dan jelaskan bagaimana MCP dapat mengatasi tantangan spesifiknya.
4. Jelajahi salah satu arah masa depan dan buat konsep untuk ekstensi MCP baru yang mendukungnya.

Selanjutnya: [Best Practices](../08-BestPractices/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi yang penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.