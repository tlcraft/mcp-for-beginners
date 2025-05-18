<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:28:59+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ms"
}
-->
# Pelajaran dari Penerima Awal

## Gambaran Keseluruhan

Pelajaran ini meneroka bagaimana penerima awal telah memanfaatkan Protokol Konteks Model (MCP) untuk menyelesaikan cabaran dunia sebenar dan mendorong inovasi merentasi industri. Melalui kajian kes terperinci dan projek praktikal, anda akan melihat bagaimana MCP membolehkan integrasi AI yang standard, selamat dan boleh diskala—menghubungkan model bahasa besar, alat, dan data perusahaan dalam satu rangka kerja bersatu. Anda akan mendapat pengalaman praktikal dalam mereka bentuk dan membina penyelesaian berasaskan MCP, belajar dari corak pelaksanaan yang terbukti, dan menemui amalan terbaik untuk menggunakan MCP dalam persekitaran pengeluaran. Pelajaran ini juga menyoroti trend yang muncul, arah masa depan, dan sumber terbuka untuk membantu anda kekal di barisan hadapan teknologi MCP dan ekosistemnya yang berkembang.

## Objektif Pembelajaran

- Menganalisis pelaksanaan MCP dunia sebenar merentasi pelbagai industri
- Mereka bentuk dan membina aplikasi lengkap berasaskan MCP
- Meneroka trend yang muncul dan arah masa depan dalam teknologi MCP
- Menerapkan amalan terbaik dalam senario pembangunan sebenar

## Pelaksanaan MCP Dunia Sebenar

### Kajian Kes 1: Automasi Sokongan Pelanggan Perusahaan

Sebuah syarikat multinasional melaksanakan penyelesaian berasaskan MCP untuk menyeragamkan interaksi AI merentasi sistem sokongan pelanggan mereka. Ini membolehkan mereka:

- Mewujudkan antara muka bersatu untuk pelbagai penyedia LLM
- Mengekalkan pengurusan prompt yang konsisten merentasi jabatan
- Melaksanakan kawalan keselamatan dan pematuhan yang kukuh
- Mudah beralih antara model AI yang berbeza berdasarkan keperluan khusus

**Pelaksanaan Teknikal:**
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

**Hasil:** Pengurangan 30% dalam kos model, peningkatan 45% dalam konsistensi respons, dan pematuhan yang dipertingkatkan merentasi operasi global.

### Kajian Kes 2: Pembantu Diagnostik Penjagaan Kesihatan

Penyedia penjagaan kesihatan membangunkan infrastruktur MCP untuk mengintegrasikan pelbagai model AI perubatan khusus sambil memastikan data pesakit yang sensitif kekal dilindungi:

- Peralihan lancar antara model perubatan generalis dan pakar
- Kawalan privasi yang ketat dan jejak audit
- Integrasi dengan sistem Rekod Kesihatan Elektronik (EHR) sedia ada
- Kejuruteraan prompt yang konsisten untuk istilah perubatan

**Pelaksanaan Teknikal:**
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

**Hasil:** Cadangan diagnostik yang dipertingkatkan untuk doktor sambil mengekalkan pematuhan HIPAA sepenuhnya dan pengurangan ketara dalam pertukaran konteks antara sistem.

### Kajian Kes 3: Analisis Risiko Perkhidmatan Kewangan

Sebuah institusi kewangan melaksanakan MCP untuk menyeragamkan proses analisis risiko mereka merentasi pelbagai jabatan:

- Mewujudkan antara muka bersatu untuk model risiko kredit, pengesanan penipuan, dan risiko pelaburan
- Melaksanakan kawalan akses yang ketat dan versi model
- Memastikan kebolehaudit semua cadangan AI
- Mengekalkan pemformatan data yang konsisten merentasi sistem yang pelbagai

**Pelaksanaan Teknikal:**
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

**Hasil:** Pematuhan peraturan yang dipertingkatkan, kitaran pelaksanaan model 40% lebih cepat, dan konsistensi penilaian risiko yang dipertingkatkan merentasi jabatan.

### Kajian Kes 4: Microsoft Playwright MCP Server untuk Automasi Pelayar

Microsoft membangunkan [pelayan Playwright MCP](https://github.com/microsoft/playwright-mcp) untuk membolehkan automasi pelayar yang selamat dan standard melalui Protokol Konteks Model. Penyelesaian ini membolehkan ejen AI dan LLM berinteraksi dengan pelayar web dengan cara yang terkawal, boleh diaudit, dan boleh diperluas—membolehkan kes penggunaan seperti ujian web automatik, pengekstrakan data, dan aliran kerja hujung ke hujung.

- Mendedahkan keupayaan automasi pelayar (navigasi, pengisian borang, tangkapan skrin, dll.) sebagai alat MCP
- Melaksanakan kawalan akses yang ketat dan kotak pasir untuk mengelakkan tindakan tidak sah
- Menyediakan log audit terperinci untuk semua interaksi pelayar
- Menyokong integrasi dengan Azure OpenAI dan penyedia LLM lain untuk automasi yang dipacu ejen

**Pelaksanaan Teknikal:**
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
- Membolehkan automasi pelayar yang selamat dan programatik untuk ejen AI dan LLM
- Mengurangkan usaha ujian manual dan meningkatkan liputan ujian untuk aplikasi web
- Menyediakan rangka kerja yang boleh digunakan semula dan boleh diperluas untuk integrasi alat berasaskan pelayar dalam persekitaran perusahaan

**Rujukan:**  
- [Repositori GitHub Pelayan Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Penyelesaian AI dan Automasi Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### Kajian Kes 5: Azure MCP – Protokol Konteks Model Bertaraf Perusahaan sebagai Perkhidmatan

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ialah pelaksanaan bertaraf perusahaan yang diuruskan oleh Microsoft bagi Protokol Konteks Model, yang direka untuk menyediakan keupayaan pelayan MCP yang boleh diskala, selamat, dan mematuhi sebagai perkhidmatan awan. Azure MCP membolehkan organisasi melaksanakan, mengurus, dan mengintegrasikan pelayan MCP dengan Azure AI, data, dan perkhidmatan keselamatan dengan cepat, mengurangkan beban operasi dan mempercepatkan penerimaan AI.

- Pengehosan pelayan MCP yang diuruskan sepenuhnya dengan penskalaan, pemantauan, dan keselamatan terbina dalam
- Integrasi asli dengan Azure OpenAI, Azure AI Search, dan perkhidmatan Azure lain
- Pengesahan dan kebenaran perusahaan melalui Microsoft Entra ID
- Sokongan untuk alat tersuai, templat prompt, dan penyambung sumber
- Pematuhan dengan keperluan keselamatan dan peraturan perusahaan

**Pelaksanaan Teknikal:**
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
- Mengurangkan masa untuk nilai bagi projek AI perusahaan dengan menyediakan platform pelayan MCP yang sedia untuk digunakan dan mematuhi
- Memudahkan integrasi LLM, alat, dan sumber data perusahaan
- Meningkatkan keselamatan, kebolehlacakan, dan kecekapan operasi untuk beban kerja MCP

**Rujukan:**  
- [Dokumentasi Azure MCP](https://aka.ms/azmcp)
- [Perkhidmatan AI Azure](https://azure.microsoft.com/en-us/products/ai-services/)

## Projek Praktikal

### Projek 1: Bina Pelayan MCP Berbilang Penyedia

**Objektif:** Mewujudkan pelayan MCP yang boleh mengarahkan permintaan kepada pelbagai penyedia model AI berdasarkan kriteria tertentu.

**Keperluan:**
- Menyokong sekurang-kurangnya tiga penyedia model berbeza (contohnya, OpenAI, Anthropic, model tempatan)
- Melaksanakan mekanisme penghalaan berdasarkan metadata permintaan
- Mewujudkan sistem konfigurasi untuk menguruskan kelayakan penyedia
- Menambah caching untuk mengoptimumkan prestasi dan kos
- Membangun papan pemuka ringkas untuk memantau penggunaan

**Langkah Pelaksanaan:**
1. Sediakan infrastruktur pelayan MCP asas
2. Melaksanakan adapter penyedia untuk setiap perkhidmatan model AI
3. Mewujudkan logik penghalaan berdasarkan atribut permintaan
4. Menambah mekanisme caching untuk permintaan yang kerap
5. Membangun papan pemuka pemantauan
6. Uji dengan pelbagai corak permintaan

**Teknologi:** Pilih dari Python (.NET/Java/Python berdasarkan pilihan anda), Redis untuk caching, dan rangka kerja web ringkas untuk papan pemuka.

### Projek 2: Sistem Pengurusan Prompt Perusahaan

**Objektif:** Membangun sistem berasaskan MCP untuk menguruskan, membuat versi, dan menggunakan templat prompt merentasi organisasi.

**Keperluan:**
- Mewujudkan repositori berpusat untuk templat prompt
- Melaksanakan versi dan aliran kerja kelulusan
- Membangun keupayaan ujian templat dengan input sampel
- Membangun kawalan akses berdasarkan peranan
- Mewujudkan API untuk pengambilan dan penggunaan templat

**Langkah Pelaksanaan:**
1. Reka bentuk skema pangkalan data untuk penyimpanan templat
2. Mewujudkan API teras untuk operasi CRUD templat
3. Melaksanakan sistem versi
4. Membangun aliran kerja kelulusan
5. Membangun rangka kerja ujian
6. Mewujudkan antara muka web ringkas untuk pengurusan
7. Mengintegrasikan dengan pelayan MCP

**Teknologi:** Pilihan rangka kerja backend anda, pangkalan data SQL atau NoSQL, dan rangka kerja frontend untuk antara muka pengurusan.

### Projek 3: Platform Penjanaan Kandungan Berasaskan MCP

**Objektif:** Membangun platform penjanaan kandungan yang memanfaatkan MCP untuk menyediakan hasil yang konsisten merentasi jenis kandungan yang berbeza.

**Keperluan:**
- Menyokong pelbagai format kandungan (posting blog, media sosial, salinan pemasaran)
- Melaksanakan penjanaan berasaskan templat dengan pilihan penyesuaian
- Mewujudkan sistem semakan dan maklum balas kandungan
- Menjejaki metrik prestasi kandungan
- Menyokong versi dan iterasi kandungan

**Langkah Pelaksanaan:**
1. Sediakan infrastruktur klien MCP
2. Mewujudkan templat untuk pelbagai jenis kandungan
3. Membangun saluran penjanaan kandungan
4. Melaksanakan sistem semakan
5. Membangun sistem penjejakan metrik
6. Mewujudkan antara muka pengguna untuk pengurusan templat dan penjanaan kandungan

**Teknologi:** Bahasa pengaturcaraan pilihan anda, rangka kerja web, dan sistem pangkalan data.

## Arah Masa Depan untuk Teknologi MCP

### Trend Yang Muncul

1. **MCP Berbilang Mod**
   - Pengembangan MCP untuk menyeragamkan interaksi dengan model imej, audio, dan video
   - Pembangunan keupayaan penaakulan silang-mod
   - Format prompt standard untuk pelbagai mod

2. **Infrastruktur MCP Teragih**
   - Rangkaian MCP teragih yang boleh berkongsi sumber merentasi organisasi
   - Protokol standard untuk perkongsian model yang selamat
   - Teknik pengiraan yang memelihara privasi

3. **Pasaran MCP**
   - Ekosistem untuk berkongsi dan memonetkan templat dan plugin MCP
   - Proses jaminan kualiti dan pensijilan
   - Integrasi dengan pasaran model

4. **MCP untuk Pengkomputeran Edge**
   - Penyesuaian standard MCP untuk peranti edge yang terhad sumber
   - Protokol yang dioptimumkan untuk persekitaran jalur lebar rendah
   - Pelaksanaan MCP khusus untuk ekosistem IoT

5. **Rangka Kerja Peraturan**
   - Pembangunan lanjutan MCP untuk pematuhan peraturan
   - Jejak audit standard dan antara muka kebolehexplainan
   - Integrasi dengan rangka kerja tadbir urus AI yang muncul

### Penyelesaian MCP dari Microsoft 

Microsoft dan Azure telah membangunkan beberapa repositori sumber terbuka untuk membantu pembangun melaksanakan MCP dalam pelbagai senario:

#### Organisasi Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Pelayan Playwright MCP untuk automasi dan ujian pelayar
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Pelaksanaan pelayan MCP OneDrive untuk ujian tempatan dan sumbangan komuniti

#### Organisasi Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - Pautan kepada sampel, alat, dan sumber untuk membina dan mengintegrasikan pelayan MCP di Azure menggunakan pelbagai bahasa
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Pelayan MCP rujukan yang menunjukkan pengesahan dengan spesifikasi Protokol Konteks Model semasa
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Halaman pendaratan untuk pelaksanaan Pelayan MCP Jauh dalam Fungsi Azure dengan pautan ke repos khusus bahasa
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Templat permulaan cepat untuk membina dan menggunakan pelayan MCP jauh tersuai menggunakan Fungsi Azure dengan Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Templat permulaan cepat untuk membina dan menggunakan pelayan MCP jauh tersuai menggunakan Fungsi Azure dengan .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Templat permulaan cepat untuk membina dan menggunakan pelayan MCP jauh tersuai menggunakan Fungsi Azure dengan TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Pengurusan API Azure sebagai Gerbang AI kepada pelayan MCP Jauh menggunakan Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Eksperimen APIM ❤️ AI termasuk keupayaan MCP, mengintegrasikan dengan Azure OpenAI dan AI Foundry

Repositori ini menyediakan pelbagai pelaksanaan, templat, dan sumber untuk bekerja dengan Protokol Konteks Model merentasi pelbagai bahasa pengaturcaraan dan perkhidmatan Azure. Mereka merangkumi pelbagai kes penggunaan dari pelaksanaan pelayan asas hingga pengesahan, penggunaan awan, dan senario integrasi perusahaan.

#### Direktori Sumber MCP

Direktori [Sumber MCP](https://github.com/microsoft/mcp/tree/main/Resources) dalam repositori rasmi Microsoft MCP menyediakan koleksi sumber sampel, templat prompt, dan definisi alat yang dikurasi untuk digunakan dengan pelayan Protokol Konteks Model. Direktori ini direka untuk membantu pembangun memulakan dengan cepat dengan MCP dengan menawarkan blok binaan yang boleh digunakan semula dan contoh amalan terbaik untuk:

- **Templat Prompt:** Templat prompt siap pakai untuk tugas dan senario AI biasa, yang boleh disesuaikan untuk pelaksanaan pelayan MCP anda sendiri.
- **Definisi Alat:** Skema alat contoh dan metadata untuk menyeragamkan integrasi dan pelaksanaan alat merentasi pelayan MCP yang berbeza.
- **Sampel Sumber:** Definisi sumber contoh untuk menyambung ke sumber data, API, dan perkhidmatan luaran dalam rangka kerja MCP.
- **Pelaksanaan Rujukan:** Sampel praktikal yang menunjukkan cara untuk menyusun dan mengatur sumber, prompt, dan alat dalam projek MCP dunia sebenar.

Sumber ini mempercepatkan pembangunan, mempromosikan standardisasi, dan membantu memastikan amalan terbaik apabila membina dan menggunakan penyelesaian berasaskan MCP.

#### Direktori Sumber MCP
- [Sumber MCP (Prompt Sampel, Alat, dan Definisi Sumber)](https://github.com/microsoft/mcp/tree/main/Resources)

### Peluang Penyelidikan

- Teknik pengoptimuman prompt yang cekap dalam rangka kerja MCP
- Model keselamatan untuk pelaksanaan MCP berbilang penyewa
- Penanda aras prestasi merentasi pelbagai pelaksanaan MCP
- Kaedah pengesahan formal untuk pelayan MCP

## Kesimpulan

Protokol Konteks Model (MCP) sedang membentuk masa depan integrasi AI yang standard, selamat, dan boleh dipertukarkan merentasi industri dengan pantas. Melalui kajian kes dan projek praktikal dalam pelajaran ini, anda telah melihat bagaimana penerima awal—termasuk Microsoft dan Azure—memanfaatkan MCP untuk menyelesaikan cabaran dunia sebenar, mempercepatkan penerimaan AI, dan memastikan pematuhan, keselamatan, dan skalabilitas. Pendekatan modular MCP membolehkan organisasi menghubungkan model bahasa besar, alat, dan data perusahaan dalam rangka kerja bersatu yang boleh diaudit. Apabila MCP terus berkembang, kekal terlibat dengan komuniti, meneroka sumber terbuka, dan menerapkan amalan terbaik akan menjadi kunci untuk membina penyelesaian AI yang kukuh dan bersedia untuk masa depan.

## Sumber Tambahan

- [Repositori GitHub MCP (Microsoft)](https://github.com/microsoft/mcp)
- [Direktori Sumber MCP (Prompt Sampel, Alat, dan Definisi Sumber)](https://github.com/microsoft/mcp/tree/main/Resources)
- [Komuniti & Dokumentasi MCP](https://modelcontextprotocol.io/introduction)
- [Dokumentasi Azure MCP](https://aka.ms/azmcp)
- [Repositori GitHub Pelayan Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Pelayan MCP Fail (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [Pelayan MCP Auth (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Fungsi MCP Jauh (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Fungsi MCP Jauh Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Fungsi MCP Jauh .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Fungsi MCP Jauh TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Latihan

1. Analisis salah satu kajian kes dan cadangkan pendekatan pelaksanaan alternatif.
2. Pilih salah satu idea projek dan buat spesifikasi teknikal yang terperinci.
3. Selidik satu industri yang tidak diliputi dalam kajian kes dan gariskan bagaimana MCP boleh menangani cabaran khususnya.
4. Terokai salah satu arah masa depan dan buat konsep untuk sambungan MCP baharu untuk menyokongnya.

Seterusnya: [Amalan Terbaik](../08-BestPractices/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.