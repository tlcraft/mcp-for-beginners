<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T10:13:01+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ms"
}
-->
# 🌟 Pengajaran daripada Pengguna Awal

## 🎯 Apa yang Modul Ini Liputi

Modul ini meneroka bagaimana organisasi sebenar dan pembangun menggunakan Model Context Protocol (MCP) untuk menyelesaikan cabaran sebenar dan memacu inovasi. Melalui kajian kes terperinci, projek praktikal, anda akan menemui bagaimana MCP membolehkan integrasi AI yang selamat dan boleh diskala yang menghubungkan model bahasa, alat, dan data perusahaan.

### 📚 Lihat MCP Beraksi

Ingin melihat prinsip-prinsip ini diaplikasikan pada alat yang sedia untuk produksi? Lihat [**10 Microsoft MCP Servers Yang Mengubah Produktiviti Pembangun**](microsoft-mcp-servers.md) yang memaparkan pelayan MCP Microsoft sebenar yang boleh anda gunakan hari ini.

## Gambaran Keseluruhan

Pelajaran ini meneroka bagaimana pengguna awal telah menggunakan Model Context Protocol (MCP) untuk menyelesaikan cabaran dunia sebenar dan memacu inovasi merentasi pelbagai industri. Melalui kajian kes terperinci dan projek praktikal, anda akan melihat bagaimana MCP membolehkan integrasi AI yang standard, selamat, dan boleh diskala—menghubungkan model bahasa besar, alat, dan data perusahaan dalam satu rangka kerja yang bersatu. Anda akan memperoleh pengalaman praktikal dalam mereka bentuk dan membina penyelesaian berasaskan MCP, belajar daripada corak pelaksanaan yang terbukti, dan menemui amalan terbaik untuk melaksanakan MCP dalam persekitaran produksi. Pelajaran ini juga menyorot trend yang sedang muncul, hala tuju masa depan, dan sumber terbuka untuk membantu anda kekal di barisan hadapan teknologi MCP dan ekosistemnya yang berkembang.

## Objektif Pembelajaran

- Menganalisis pelaksanaan MCP dunia sebenar merentasi pelbagai industri  
- Mereka bentuk dan membina aplikasi lengkap berasaskan MCP  
- Meneroka trend yang sedang muncul dan hala tuju masa depan dalam teknologi MCP  
- Mengaplikasikan amalan terbaik dalam senario pembangunan sebenar  

## Pelaksanaan MCP Dunia Sebenar

### Kajian Kes 1: Automasi Sokongan Pelanggan Perusahaan

Sebuah syarikat multinasional melaksanakan penyelesaian berasaskan MCP untuk menstandardkan interaksi AI merentasi sistem sokongan pelanggan mereka. Ini membolehkan mereka:

- Mewujudkan antara muka bersatu untuk pelbagai penyedia LLM  
- Mengekalkan pengurusan prompt yang konsisten merentasi jabatan  
- Melaksanakan kawalan keselamatan dan pematuhan yang kukuh  
- Beralih dengan mudah antara model AI yang berbeza mengikut keperluan khusus  

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

**Keputusan:** Pengurangan kos model sebanyak 30%, peningkatan konsistensi respons sebanyak 45%, dan pematuhan yang dipertingkatkan merentasi operasi global.

### Kajian Kes 2: Pembantu Diagnostik Penjagaan Kesihatan

Penyedia penjagaan kesihatan membangunkan infrastruktur MCP untuk mengintegrasikan pelbagai model AI perubatan khusus sambil memastikan data pesakit yang sensitif kekal dilindungi:

- Peralihan lancar antara model perubatan umum dan pakar  
- Kawalan privasi ketat dan jejak audit  
- Integrasi dengan sistem Rekod Kesihatan Elektronik (EHR) sedia ada  
- Kejuruteraan prompt yang konsisten untuk terminologi perubatan  

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

**Keputusan:** Cadangan diagnostik yang dipertingkatkan untuk doktor sambil mengekalkan pematuhan penuh HIPAA dan pengurangan ketara dalam pertukaran konteks antara sistem.

### Kajian Kes 3: Analisis Risiko Perkhidmatan Kewangan

Institusi kewangan melaksanakan MCP untuk menstandardkan proses analisis risiko mereka merentasi jabatan yang berbeza:

- Mewujudkan antara muka bersatu untuk model risiko kredit, pengesanan penipuan, dan risiko pelaburan  
- Melaksanakan kawalan akses ketat dan pengurusan versi model  
- Memastikan kebolehlaudit semua cadangan AI  
- Mengekalkan format data yang konsisten merentasi sistem yang pelbagai  

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

**Keputusan:** Pematuhan peraturan yang dipertingkatkan, kitaran pelaksanaan model 40% lebih pantas, dan konsistensi penilaian risiko yang lebih baik merentasi jabatan.

### Kajian Kes 4: Microsoft Playwright MCP Server untuk Automasi Pelayar

Microsoft membangunkan [Playwright MCP server](https://github.com/microsoft/playwright-mcp) untuk membolehkan automasi pelayar yang selamat dan standard melalui Model Context Protocol. Pelayan yang sedia untuk produksi ini membolehkan agen AI dan LLM berinteraksi dengan pelayar web secara terkawal, boleh diaudit, dan boleh dikembangkan—membolehkan kes penggunaan seperti ujian web automatik, pengekstrakan data, dan aliran kerja hujung ke hujung.

> **🎯 Alat Sedia Produksi**  
> Kajian kes ini memaparkan pelayan MCP sebenar yang boleh anda gunakan hari ini! Ketahui lebih lanjut tentang Playwright MCP Server dan 9 pelayan MCP Microsoft lain yang sedia untuk produksi dalam [**Panduan Microsoft MCP Servers**](microsoft-mcp-servers.md#8--playwright-mcp-server).

**Ciri Utama:**  
- Mendedahkan keupayaan automasi pelayar (navigasi, pengisian borang, tangkapan skrin, dan lain-lain) sebagai alat MCP  
- Melaksanakan kawalan akses ketat dan sandboxing untuk mengelakkan tindakan tanpa kebenaran  
- Menyediakan log audit terperinci untuk semua interaksi pelayar  
- Menyokong integrasi dengan Azure OpenAI dan penyedia LLM lain untuk automasi berasaskan agen  
- Menyokong GitHub Copilot Coding Agent dengan keupayaan pelayaran web  

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

**Keputusan:**  
- Membolehkan automasi pelayar yang selamat dan berprogram untuk agen AI dan LLM  
- Mengurangkan usaha ujian manual dan meningkatkan liputan ujian untuk aplikasi web  
- Menyediakan rangka kerja boleh guna semula dan boleh dikembangkan untuk integrasi alat berasaskan pelayar dalam persekitaran perusahaan  
- Menyokong keupayaan pelayaran web GitHub Copilot  

**Rujukan:**  
- [Repositori GitHub Playwright MCP Server](https://github.com/microsoft/playwright-mcp)  
- [Penyelesaian AI dan Automasi Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### Kajian Kes 5: Azure MCP – Model Context Protocol Gred Perusahaan sebagai Perkhidmatan

Azure MCP Server ([https://aka.ms/azmcp](https://aka.ms/azmcp)) adalah pelaksanaan MCP gred perusahaan yang diurus oleh Microsoft, direka untuk menyediakan keupayaan pelayan MCP yang boleh diskala, selamat, dan mematuhi peraturan sebagai perkhidmatan awan. Azure MCP membolehkan organisasi melancarkan, mengurus, dan mengintegrasikan pelayan MCP dengan perkhidmatan Azure AI, data, dan keselamatan dengan pantas, mengurangkan beban operasi dan mempercepatkan penerimaan AI.

> **🎯 Alat Sedia Produksi**  
> Ini adalah pelayan MCP sebenar yang boleh anda gunakan hari ini! Ketahui lebih lanjut tentang Azure AI Foundry MCP Server dalam [**Panduan Microsoft MCP Servers**](microsoft-mcp-servers.md).

- Penghosan pelayan MCP yang diurus sepenuhnya dengan skala, pemantauan, dan keselamatan terbina dalam  
- Integrasi asli dengan Azure OpenAI, Azure AI Search, dan perkhidmatan Azure lain  
- Pengesahan dan kebenaran perusahaan melalui Microsoft Entra ID  
- Sokongan untuk alat tersuai, templat prompt, dan penyambung sumber  
- Pematuhan dengan keselamatan perusahaan dan keperluan peraturan  

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

**Keputusan:**  
- Mengurangkan masa untuk mencapai nilai bagi projek AI perusahaan dengan menyediakan platform pelayan MCP yang sedia digunakan dan mematuhi peraturan  
- Memudahkan integrasi LLM, alat, dan sumber data perusahaan  
- Meningkatkan keselamatan, kebolehlihatan, dan kecekapan operasi untuk beban kerja MCP  
- Memperbaiki kualiti kod dengan amalan terbaik Azure SDK dan corak pengesahan terkini  

**Rujukan:**  
- [Dokumentasi Azure MCP](https://aka.ms/azmcp)  
- [Repositori GitHub Azure MCP Server](https://github.com/Azure/azure-mcp)  
- [Perkhidmatan AI Azure](https://azure.microsoft.com/en-us/products/ai-services/)

### Kajian Kes 6: NLWeb – Protokol Antara Muka Web Bahasa Semula Jadi

NLWeb mewakili visi Microsoft untuk mewujudkan lapisan asas bagi Web AI. Setiap instans NLWeb juga merupakan pelayan MCP, yang menyokong satu kaedah teras, `ask`, yang digunakan untuk bertanya soalan kepada laman web dalam bahasa semula jadi. Respons yang dikembalikan menggunakan schema.org, satu kosa kata yang banyak digunakan untuk menerangkan data web. Secara longgar, MCP adalah kepada NLWeb seperti HTTP kepada HTML.

**Ciri Utama:**  
- **Lapisan Protokol**: Protokol mudah untuk berinteraksi dengan laman web dalam bahasa semula jadi  
- **Format Schema.org**: Menggunakan JSON dan schema.org untuk respons berstruktur yang boleh dibaca mesin  
- **Pelaksanaan Komuniti**: Pelaksanaan mudah untuk laman yang boleh diwakili sebagai senarai item (produk, resipi, tarikan, ulasan, dan lain-lain)  
- **Widget UI**: Komponen antara muka pengguna siap guna untuk antara muka perbualan  

**Komponen Seni Bina:**  
1. **Protokol**: REST API mudah untuk pertanyaan bahasa semula jadi ke laman web  
2. **Pelaksanaan**: Menggunakan markup dan struktur laman sedia ada untuk respons automatik  
3. **Widget UI**: Komponen siap guna untuk integrasi antara muka perbualan  

**Manfaat:**  
- Membolehkan interaksi manusia-ke-laman dan agen-ke-agen  
- Menyediakan respons data berstruktur yang mudah diproses oleh sistem AI  
- Pelaksanaan pantas untuk laman dengan struktur kandungan berasaskan senarai  
- Pendekatan standard untuk menjadikan laman web boleh diakses AI  

**Keputusan:**  
- Menetapkan asas untuk piawaian interaksi AI-web  
- Memudahkan penciptaan antara muka perbualan untuk laman kandungan  
- Meningkatkan kebolehcapaian dan keterlihatan kandungan web untuk sistem AI  
- Menggalakkan interoperabiliti antara agen AI dan perkhidmatan web yang berbeza  

**Rujukan:**  
- [Repositori GitHub NLWeb](https://github.com/microsoft/NlWeb)  
- [Dokumentasi NLWeb](https://github.com/microsoft/NlWeb)

### Kajian Kes 7: Azure AI Foundry MCP Server – Integrasi Agen AI Perusahaan

Pelayan Azure AI Foundry MCP menunjukkan bagaimana MCP boleh digunakan untuk mengatur dan mengurus agen AI serta aliran kerja dalam persekitaran perusahaan. Dengan mengintegrasikan MCP dengan Azure AI Foundry, organisasi dapat menstandardkan interaksi agen, memanfaatkan pengurusan aliran kerja Foundry, dan memastikan pelaksanaan yang selamat dan boleh diskala.

> **🎯 Alat Sedia Produksi**  
> Ini adalah pelayan MCP sebenar yang boleh anda gunakan hari ini! Ketahui lebih lanjut tentang Azure AI Foundry MCP Server dalam [**Panduan Microsoft MCP Servers**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server).

**Ciri Utama:**  
- Akses menyeluruh ke ekosistem AI Azure, termasuk katalog model dan pengurusan pelaksanaan  
- Pengindeksan pengetahuan dengan Azure AI Search untuk aplikasi RAG  
- Alat penilaian prestasi model AI dan jaminan kualiti  
- Integrasi dengan Azure AI Foundry Catalog dan Labs untuk model penyelidikan terkini  
- Keupayaan pengurusan dan penilaian agen untuk senario produksi  

**Keputusan:**  
- Prototip pantas dan pemantauan kukuh aliran kerja agen AI  
- Integrasi lancar dengan perkhidmatan Azure AI untuk senario lanjutan  
- Antara muka bersatu untuk membina, melaksanakan, dan memantau saluran agen  
- Keselamatan, pematuhan, dan kecekapan operasi yang dipertingkatkan untuk perusahaan  
- Mempercepat penerimaan AI sambil mengekalkan kawalan ke atas proses kompleks berasaskan agen  

**Rujukan:**  
- [Repositori GitHub Azure AI Foundry MCP Server](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Mengintegrasikan Agen Azure AI dengan MCP (Blog Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Kajian Kes 8: Foundry MCP Playground – Eksperimen dan Prototip

Foundry MCP Playground menawarkan persekitaran siap guna untuk bereksperimen dengan pelayan MCP dan integrasi Azure AI Foundry. Pembangun boleh dengan cepat membuat prototaip, menguji, dan menilai model AI serta aliran kerja agen menggunakan sumber dari Azure AI Foundry Catalog dan Labs. Playground ini memudahkan penyediaan, menyediakan projek contoh, dan menyokong pembangunan kolaboratif, menjadikannya mudah untuk meneroka amalan terbaik dan senario baru dengan beban minimum. Ia sangat berguna untuk pasukan yang ingin mengesahkan idea, berkongsi eksperimen, dan mempercepat pembelajaran tanpa memerlukan infrastruktur yang kompleks. Dengan menurunkan halangan kemasukan, playground ini membantu memupuk inovasi dan sumbangan komuniti dalam ekosistem MCP dan Azure AI Foundry.

**Rujukan:**  
- [Repositori GitHub Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Kajian Kes 9: Microsoft Learn Docs MCP Server – Akses Dokumentasi Berkuasa AI

Microsoft Learn Docs MCP Server adalah perkhidmatan yang dihoskan di awan yang menyediakan pembantu AI dengan akses masa nyata ke dokumentasi rasmi Microsoft melalui Model Context Protocol. Pelayan yang sedia untuk produksi ini menghubungkan ke ekosistem Microsoft Learn yang komprehensif dan membolehkan carian semantik merentasi semua sumber rasmi Microsoft.
> **🎯 Alat Sedia untuk Pengeluaran**
> 
> Ini adalah server MCP sebenar yang anda boleh gunakan hari ini! Ketahui lebih lanjut tentang Microsoft Learn Docs MCP Server dalam [**Panduan Server MCP Microsoft**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server).
**Ciri-ciri Utama:**
- Akses masa nyata kepada dokumentasi rasmi Microsoft, dokumentasi Azure, dan dokumentasi Microsoft 365
- Keupayaan carian semantik lanjutan yang memahami konteks dan niat
- Maklumat sentiasa dikemas kini apabila kandungan Microsoft Learn diterbitkan
- Liputan menyeluruh merangkumi Microsoft Learn, dokumentasi Azure, dan sumber Microsoft 365
- Mengembalikan sehingga 10 bahagian kandungan berkualiti tinggi dengan tajuk artikel dan URL

**Mengapa Ia Penting:**
- Menyelesaikan masalah "pengetahuan AI yang ketinggalan zaman" untuk teknologi Microsoft
- Memastikan pembantu AI mempunyai akses kepada ciri terkini .NET, C#, Azure, dan Microsoft 365
- Menyediakan maklumat autoritatif dari pihak pertama untuk penjanaan kod yang tepat
- Penting untuk pembangun yang bekerja dengan teknologi Microsoft yang berkembang pesat

**Hasil:**
- Ketepatan kod yang dijana AI untuk teknologi Microsoft meningkat dengan ketara
- Masa yang dihabiskan untuk mencari dokumentasi terkini dan amalan terbaik dikurangkan
- Produktiviti pembangun dipertingkatkan dengan pengambilan dokumentasi yang peka konteks
- Integrasi lancar dengan aliran kerja pembangunan tanpa perlu meninggalkan IDE

**Rujukan:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Projek Praktikal

### Projek 1: Bina Pelayan MCP Multi-Penyedia

**Objektif:** Cipta pelayan MCP yang boleh menghala permintaan ke pelbagai penyedia model AI berdasarkan kriteria tertentu.

**Keperluan:**
- Menyokong sekurang-kurangnya tiga penyedia model berbeza (contoh: OpenAI, Anthropic, model tempatan)
- Laksanakan mekanisme penghalaan berdasarkan metadata permintaan
- Cipta sistem konfigurasi untuk mengurus kelayakan penyedia
- Tambah caching untuk mengoptimumkan prestasi dan kos
- Bina papan pemuka ringkas untuk memantau penggunaan

**Langkah Pelaksanaan:**
1. Sediakan infrastruktur asas pelayan MCP
2. Laksanakan penyesuai penyedia untuk setiap perkhidmatan model AI
3. Cipta logik penghalaan berdasarkan atribut permintaan
4. Tambah mekanisme caching untuk permintaan kerap
5. Bangunkan papan pemuka pemantauan
6. Uji dengan pelbagai corak permintaan

**Teknologi:** Pilih dari Python (.NET/Java/Python mengikut pilihan anda), Redis untuk caching, dan rangka kerja web ringkas untuk papan pemuka.

### Projek 2: Sistem Pengurusan Prompt Perusahaan

**Objektif:** Bangunkan sistem berasaskan MCP untuk mengurus, versi, dan melancarkan templat prompt di seluruh organisasi.

**Keperluan:**
- Cipta repositori berpusat untuk templat prompt
- Laksanakan sistem versi dan aliran kerja kelulusan
- Bina keupayaan ujian templat dengan input contoh
- Bangunkan kawalan akses berasaskan peranan
- Cipta API untuk pengambilan dan pelancaran templat

**Langkah Pelaksanaan:**
1. Reka skema pangkalan data untuk penyimpanan templat
2. Cipta API teras untuk operasi CRUD templat
3. Laksanakan sistem versi
4. Bina aliran kerja kelulusan
5. Bangunkan rangka kerja ujian
6. Cipta antara muka web ringkas untuk pengurusan
7. Integrasi dengan pelayan MCP

**Teknologi:** Pilihan rangka kerja backend anda, pangkalan data SQL atau NoSQL, dan rangka kerja frontend untuk antara muka pengurusan.

### Projek 3: Platform Penjanaan Kandungan Berasaskan MCP

**Objektif:** Bina platform penjanaan kandungan yang menggunakan MCP untuk memberikan hasil konsisten merentas pelbagai jenis kandungan.

**Keperluan:**
- Menyokong pelbagai format kandungan (catatan blog, media sosial, salinan pemasaran)
- Laksanakan penjanaan berasaskan templat dengan pilihan penyesuaian
- Cipta sistem semakan dan maklum balas kandungan
- Jejaki metrik prestasi kandungan
- Sokong versi dan iterasi kandungan

**Langkah Pelaksanaan:**
1. Sediakan infrastruktur klien MCP
2. Cipta templat untuk pelbagai jenis kandungan
3. Bina saluran penjanaan kandungan
4. Laksanakan sistem semakan
5. Bangunkan sistem penjejakan metrik
6. Cipta antara muka pengguna untuk pengurusan templat dan penjanaan kandungan

**Teknologi:** Bahasa pengaturcaraan pilihan anda, rangka kerja web, dan sistem pangkalan data.

## Arah Masa Depan Teknologi MCP

### Trend Berkembang

1. **MCP Multi-Modal**
   - Pengembangan MCP untuk menstandardkan interaksi dengan model imej, audio, dan video
   - Pembangunan keupayaan penaakulan rentas modal
   - Format prompt standard untuk pelbagai modaliti

2. **Infrastruktur MCP Berfederasi**
   - Rangkaian MCP teragih yang boleh berkongsi sumber merentas organisasi
   - Protokol standard untuk perkongsian model yang selamat
   - Teknik pengiraan yang memelihara privasi

3. **Pasaran MCP**
   - Ekosistem untuk berkongsi dan memonetisasi templat dan plugin MCP
   - Proses jaminan kualiti dan pensijilan
   - Integrasi dengan pasaran model

4. **MCP untuk Pengkomputeran Edge**
   - Penyesuaian piawaian MCP untuk peranti edge yang terhad sumber
   - Protokol dioptimumkan untuk persekitaran jalur lebar rendah
   - Pelaksanaan MCP khusus untuk ekosistem IoT

5. **Rangka Kerja Peraturan**
   - Pembangunan peluasan MCP untuk pematuhan peraturan
   - Jejak audit standard dan antara muka kebolehjelasan
   - Integrasi dengan rangka kerja tadbir urus AI yang sedang berkembang

### Penyelesaian MCP dari Microsoft

Microsoft dan Azure telah membangunkan beberapa repositori sumber terbuka untuk membantu pembangun melaksanakan MCP dalam pelbagai senario:

#### Organisasi Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Pelayan MCP Playwright untuk automasi dan ujian pelayar
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Pelaksanaan pelayan MCP OneDrive untuk ujian tempatan dan sumbangan komuniti
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb adalah koleksi protokol terbuka dan alat sumber terbuka berkaitan. Fokus utamanya adalah mewujudkan lapisan asas untuk AI Web

#### Organisasi Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - Pautan kepada sampel, alat, dan sumber untuk membina dan mengintegrasi pelayan MCP di Azure menggunakan pelbagai bahasa
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Pelayan MCP rujukan yang menunjukkan pengesahan dengan spesifikasi Model Context Protocol semasa
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Halaman pendaratan untuk pelaksanaan Remote MCP Server dalam Azure Functions dengan pautan ke repositori khusus bahasa
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Templat permulaan pantas untuk membina dan melancarkan pelayan MCP jauh tersuai menggunakan Azure Functions dengan Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Templat permulaan pantas untuk membina dan melancarkan pelayan MCP jauh tersuai menggunakan Azure Functions dengan .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Templat permulaan pantas untuk membina dan melancarkan pelayan MCP jauh tersuai menggunakan Azure Functions dengan TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management sebagai AI Gateway ke pelayan MCP jauh menggunakan Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Eksperimen APIM ❤️ AI termasuk keupayaan MCP, integrasi dengan Azure OpenAI dan AI Foundry

Repositori ini menyediakan pelbagai pelaksanaan, templat, dan sumber untuk bekerja dengan Model Context Protocol merentas pelbagai bahasa pengaturcaraan dan perkhidmatan Azure. Ia merangkumi pelbagai kes penggunaan dari pelaksanaan pelayan asas hingga pengesahan, pelancaran awan, dan senario integrasi perusahaan.

#### Direktori Sumber MCP

[Direktori Sumber MCP](https://github.com/microsoft/mcp/tree/main/Resources) dalam repositori rasmi Microsoft MCP menyediakan koleksi terpilih sumber sampel, templat prompt, dan definisi alat untuk digunakan dengan pelayan Model Context Protocol. Direktori ini direka untuk membantu pembangun memulakan dengan cepat MCP dengan menawarkan blok binaan boleh guna semula dan contoh amalan terbaik untuk:

- **Templat Prompt:** Templat prompt sedia guna untuk tugasan dan senario AI biasa, yang boleh disesuaikan untuk pelaksanaan pelayan MCP anda sendiri.
- **Definisi Alat:** Skema alat contoh dan metadata untuk menstandardkan integrasi dan panggilan alat merentas pelayan MCP yang berbeza.
- **Sumber Sampel:** Definisi sumber contoh untuk menyambung ke sumber data, API, dan perkhidmatan luaran dalam rangka kerja MCP.
- **Pelaksanaan Rujukan:** Sampel praktikal yang menunjukkan cara menyusun dan mengatur sumber, prompt, dan alat dalam projek MCP dunia sebenar.

Sumber ini mempercepat pembangunan, menggalakkan standardisasi, dan membantu memastikan amalan terbaik apabila membina dan melancarkan penyelesaian berasaskan MCP.

#### Direktori Sumber MCP
- [Sumber MCP (Prompt Sampel, Alat, dan Definisi Sumber)](https://github.com/microsoft/mcp/tree/main/Resources)

### Peluang Penyelidikan

- Teknik pengoptimuman prompt yang cekap dalam rangka kerja MCP
- Model keselamatan untuk pelaksanaan MCP berbilang penyewa
- Penanda aras prestasi merentas pelbagai pelaksanaan MCP
- Kaedah pengesahan formal untuk pelayan MCP

## Kesimpulan

Model Context Protocol (MCP) sedang membentuk masa depan integrasi AI yang standard, selamat, dan boleh beroperasi antara industri dengan pantas. Melalui kajian kes dan projek praktikal dalam pelajaran ini, anda telah melihat bagaimana penerima awal—termasuk Microsoft dan Azure—menggunakan MCP untuk menyelesaikan cabaran dunia sebenar, mempercepat penerimaan AI, dan memastikan pematuhan, keselamatan, serta kebolehsesuaian. Pendekatan modular MCP membolehkan organisasi menyambungkan model bahasa besar, alat, dan data perusahaan dalam rangka kerja yang bersatu dan boleh diaudit. Semasa MCP terus berkembang, kekal terlibat dengan komuniti, meneroka sumber terbuka, dan mengamalkan amalan terbaik akan menjadi kunci untuk membina penyelesaian AI yang kukuh dan bersedia untuk masa depan.

## Sumber Tambahan

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Mengintegrasi Ejen Azure AI dengan MCP (Blog Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [Repositori MCP GitHub (Microsoft)](https://github.com/microsoft/mcp)
- [Direktori Sumber MCP (Prompt Sampel, Alat, dan Definisi Sumber)](https://github.com/microsoft/mcp/tree/main/Resources)
- [Komuniti & Dokumentasi MCP](https://modelcontextprotocol.io/introduction)
- [Dokumentasi Azure MCP](https://aka.ms/azmcp)
- [Repositori Playwright MCP Server GitHub](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Penyelesaian AI dan Automasi Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

## Latihan

1. Analisis salah satu kajian kes dan cadangkan pendekatan pelaksanaan alternatif.
2. Pilih salah satu idea projek dan buat spesifikasi teknikal terperinci.
3. Selidik satu industri yang tidak diliputi dalam kajian kes dan gariskan bagaimana MCP boleh menangani cabaran khususnya.
4. Terokai salah satu arah masa depan dan cipta konsep untuk peluasan MCP baru bagi menyokongnya.

Seterusnya: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.