<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:38:02+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "id"
}
-->
# 📖 Konsep Inti MCP: Menguasai Model Context Protocol untuk Integrasi AI

Model Context Protocol (MCP) adalah kerangka kerja standar yang kuat yang mengoptimalkan komunikasi antara Large Language Models (LLM) dan alat eksternal, aplikasi, serta sumber data. Panduan yang dioptimalkan untuk SEO ini akan memandu Anda melalui konsep inti MCP, memastikan Anda memahami arsitektur client-server, komponen penting, mekanisme komunikasi, dan praktik terbaik implementasinya.

## Ikhtisar

Pelajaran ini membahas arsitektur dasar dan komponen yang membentuk ekosistem Model Context Protocol (MCP). Anda akan mempelajari arsitektur client-server, komponen utama, dan mekanisme komunikasi yang mendukung interaksi MCP.

## 👩‍🎓 Tujuan Pembelajaran Utama

Di akhir pelajaran ini, Anda akan:

- Memahami arsitektur client-server MCP.
- Mengidentifikasi peran dan tanggung jawab Hosts, Clients, dan Servers.
- Menganalisis fitur inti yang membuat MCP menjadi lapisan integrasi yang fleksibel.
- Mempelajari aliran informasi dalam ekosistem MCP.
- Mendapatkan wawasan praktis melalui contoh kode dalam .NET, Java, Python, dan JavaScript.

## 🔎 Arsitektur MCP: Tinjauan Mendalam

Ekosistem MCP dibangun berdasarkan model client-server. Struktur modular ini memungkinkan aplikasi AI berinteraksi dengan alat, basis data, API, dan sumber daya kontekstual secara efisien. Mari kita uraikan arsitektur ini ke dalam komponen utamanya.

### 1. Hosts

Dalam Model Context Protocol (MCP), Hosts berperan penting sebagai antarmuka utama tempat pengguna berinteraksi dengan protokol. Hosts adalah aplikasi atau lingkungan yang memulai koneksi dengan server MCP untuk mengakses data, alat, dan prompt. Contoh Hosts termasuk integrated development environments (IDE) seperti Visual Studio Code, alat AI seperti Claude Desktop, atau agen khusus yang dibuat untuk tugas tertentu.

**Hosts** adalah aplikasi LLM yang memulai koneksi. Mereka:

- Menjalankan atau berinteraksi dengan model AI untuk menghasilkan respons.
- Memulai koneksi dengan server MCP.
- Mengelola alur percakapan dan antarmuka pengguna.
- Mengendalikan izin dan batasan keamanan.
- Menangani persetujuan pengguna untuk berbagi data dan eksekusi alat.

### 2. Clients

Clients adalah komponen penting yang memfasilitasi interaksi antara Hosts dan server MCP. Clients bertindak sebagai perantara, memungkinkan Hosts mengakses dan menggunakan fungsi yang disediakan oleh server MCP. Mereka berperan penting dalam memastikan komunikasi berjalan lancar dan pertukaran data efisien dalam arsitektur MCP.

**Clients** adalah penghubung dalam aplikasi host. Mereka:

- Mengirim permintaan ke server dengan prompt/instruksi.
- Melakukan negosiasi kapabilitas dengan server.
- Mengelola permintaan eksekusi alat dari model.
- Memproses dan menampilkan respons kepada pengguna.

### 3. Servers

Servers bertanggung jawab menangani permintaan dari client MCP dan memberikan respons yang sesuai. Mereka mengelola berbagai operasi seperti pengambilan data, eksekusi alat, dan pembuatan prompt. Servers memastikan komunikasi antara client dan Hosts berjalan efisien dan andal, menjaga integritas proses interaksi.

**Servers** adalah layanan yang menyediakan konteks dan kapabilitas. Mereka:

- Mendaftarkan fitur yang tersedia (sumber daya, prompt, alat)
- Menerima dan menjalankan panggilan alat dari client
- Memberikan informasi kontekstual untuk meningkatkan respons model
- Mengembalikan hasil ke client
- Mempertahankan status selama interaksi jika diperlukan

Servers dapat dikembangkan oleh siapa saja untuk memperluas kapabilitas model dengan fungsi khusus.

### 4. Fitur Server

Server dalam Model Context Protocol (MCP) menyediakan blok bangunan dasar yang memungkinkan interaksi kaya antara clients, hosts, dan model bahasa. Fitur-fitur ini dirancang untuk meningkatkan kapabilitas MCP dengan menawarkan konteks terstruktur, alat, dan prompt.

Server MCP dapat menawarkan salah satu fitur berikut:

#### 📑 Sumber Daya

Sumber daya dalam Model Context Protocol (MCP) mencakup berbagai jenis konteks dan data yang dapat digunakan oleh pengguna atau model AI. Ini termasuk:

- **Data Kontekstual**: Informasi dan konteks yang dapat dimanfaatkan pengguna atau model AI untuk pengambilan keputusan dan pelaksanaan tugas.
- **Basis Pengetahuan dan Repositori Dokumen**: Kumpulan data terstruktur dan tidak terstruktur, seperti artikel, manual, dan makalah riset, yang memberikan wawasan dan informasi berharga.
- **File Lokal dan Basis Data**: Data yang disimpan secara lokal di perangkat atau dalam basis data, yang dapat diakses untuk pemrosesan dan analisis.
- **API dan Layanan Web**: Antarmuka dan layanan eksternal yang menawarkan data dan fungsi tambahan, memungkinkan integrasi dengan berbagai sumber daya dan alat online.

Contoh sumber daya bisa berupa skema basis data atau file yang dapat diakses seperti berikut:

```text
file://log.txt
database://schema
```

### 🤖 Prompt

Prompt dalam Model Context Protocol (MCP) meliputi berbagai template dan pola interaksi yang sudah ditentukan untuk mempermudah alur kerja pengguna dan meningkatkan komunikasi. Ini termasuk:

- **Pesan dan Alur Kerja Bertemplat**: Pesan dan proses yang sudah terstruktur untuk membimbing pengguna melalui tugas dan interaksi tertentu.
- **Pola Interaksi yang Telah Ditetapkan**: Urutan tindakan dan respons standar yang memfasilitasi komunikasi yang konsisten dan efisien.
- **Template Percakapan Khusus**: Template yang dapat disesuaikan untuk jenis percakapan tertentu, memastikan interaksi yang relevan dan sesuai konteks.

Template prompt bisa terlihat seperti ini:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alat

Alat dalam Model Context Protocol (MCP) adalah fungsi yang dapat dijalankan oleh model AI untuk melakukan tugas tertentu. Alat ini dirancang untuk meningkatkan kapabilitas model AI dengan menyediakan operasi yang terstruktur dan dapat diandalkan. Aspek utama meliputi:

- **Fungsi yang dapat dijalankan oleh model AI**: Alat adalah fungsi yang dapat dipanggil oleh model AI untuk menjalankan berbagai tugas.
- **Nama dan Deskripsi Unik**: Setiap alat memiliki nama yang khas dan deskripsi rinci yang menjelaskan tujuan dan fungsinya.
- **Parameter dan Output**: Alat menerima parameter tertentu dan mengembalikan output terstruktur, memastikan hasil yang konsisten dan dapat diprediksi.
- **Fungsi Diskrit**: Alat menjalankan fungsi diskrit seperti pencarian web, perhitungan, dan query basis data.

Contoh alat bisa terlihat seperti ini:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Fitur Client

Dalam Model Context Protocol (MCP), client menawarkan beberapa fitur utama kepada server, meningkatkan fungsi dan interaksi dalam protokol. Salah satu fitur penting adalah Sampling.

### 👉 Sampling

- **Perilaku Agentik yang Diinisiasi Server**: Client memungkinkan server untuk memulai tindakan atau perilaku tertentu secara otonom, meningkatkan kapabilitas dinamis sistem.
- **Interaksi Rekursif LLM**: Fitur ini memungkinkan interaksi rekursif dengan large language models (LLM), memungkinkan pemrosesan tugas yang lebih kompleks dan iteratif.
- **Permintaan Penyelesaian Model Tambahan**: Server dapat meminta penyelesaian tambahan dari model, memastikan respons yang lengkap dan relevan secara kontekstual.

## Aliran Informasi dalam MCP

Model Context Protocol (MCP) mendefinisikan aliran informasi terstruktur antara hosts, clients, servers, dan model. Memahami aliran ini membantu menjelaskan bagaimana permintaan pengguna diproses dan bagaimana alat eksternal serta data diintegrasikan ke dalam respons model.

- **Host Memulai Koneksi**  
  Aplikasi host (seperti IDE atau antarmuka chat) membuat koneksi ke server MCP, biasanya melalui STDIO, WebSocket, atau transportasi lain yang didukung.

- **Negosiasi Kapabilitas**  
  Client (yang tertanam di host) dan server bertukar informasi tentang fitur, alat, sumber daya, dan versi protokol yang didukung. Ini memastikan kedua pihak memahami kapabilitas yang tersedia untuk sesi tersebut.

- **Permintaan Pengguna**  
  Pengguna berinteraksi dengan host (misalnya memasukkan prompt atau perintah). Host mengumpulkan input ini dan meneruskannya ke client untuk diproses.

- **Penggunaan Sumber Daya atau Alat**  
  - Client dapat meminta konteks atau sumber daya tambahan dari server (seperti file, entri basis data, atau artikel basis pengetahuan) untuk memperkaya pemahaman model.
  - Jika model menentukan bahwa alat diperlukan (misalnya untuk mengambil data, melakukan perhitungan, atau memanggil API), client mengirim permintaan pemanggilan alat ke server, menyebutkan nama alat dan parameter.

- **Eksekusi Server**  
  Server menerima permintaan sumber daya atau alat, menjalankan operasi yang diperlukan (seperti menjalankan fungsi, query basis data, atau mengambil file), dan mengembalikan hasil ke client dalam format terstruktur.

- **Pembuatan Respons**  
  Client mengintegrasikan respons server (data sumber daya, output alat, dll.) ke dalam interaksi model yang sedang berlangsung. Model menggunakan informasi ini untuk menghasilkan respons yang komprehensif dan relevan secara kontekstual.

- **Penyajian Hasil**  
  Host menerima output akhir dari client dan menyajikannya kepada pengguna, sering kali mencakup teks yang dihasilkan model dan hasil dari eksekusi alat atau pencarian sumber daya.

Aliran ini memungkinkan MCP mendukung aplikasi AI yang canggih, interaktif, dan sadar konteks dengan menghubungkan model secara mulus dengan alat eksternal dan sumber data.

## Detail Protokol

MCP (Model Context Protocol) dibangun di atas [JSON-RPC 2.0](https://www.jsonrpc.org/), menyediakan format pesan standar dan agnostik bahasa untuk komunikasi antara hosts, clients, dan servers. Dasar ini memungkinkan interaksi yang andal, terstruktur, dan dapat diperluas di berbagai platform dan bahasa pemrograman.

### Fitur Protokol Utama

MCP memperluas JSON-RPC 2.0 dengan konvensi tambahan untuk pemanggilan alat, akses sumber daya, dan manajemen prompt. Protokol ini mendukung berbagai lapisan transportasi (STDIO, WebSocket, SSE) dan memungkinkan komunikasi yang aman, dapat diperluas, dan agnostik bahasa antar komponen.

#### 🧢 Protokol Dasar

- **Format Pesan JSON-RPC**: Semua permintaan dan respons menggunakan spesifikasi JSON-RPC 2.0, memastikan struktur konsisten untuk panggilan metode, parameter, hasil, dan penanganan error.
- **Koneksi Stateful**: Sesi MCP mempertahankan status di antara beberapa permintaan, mendukung percakapan berkelanjutan, akumulasi konteks, dan pengelolaan sumber daya.
- **Negosiasi Kapabilitas**: Saat setup koneksi, client dan server bertukar informasi tentang fitur yang didukung, versi protokol, alat, dan sumber daya yang tersedia. Ini memastikan kedua pihak memahami kapabilitas masing-masing dan dapat menyesuaikan.

#### ➕ Utilitas Tambahan

Berikut beberapa utilitas dan ekstensi protokol yang MCP sediakan untuk meningkatkan pengalaman pengembang dan memungkinkan skenario lanjutan:

- **Opsi Konfigurasi**: MCP memungkinkan konfigurasi dinamis parameter sesi, seperti izin alat, akses sumber daya, dan pengaturan model, disesuaikan untuk setiap interaksi.
- **Pelacakan Progres**: Operasi yang berjalan lama dapat melaporkan pembaruan progres, memungkinkan antarmuka pengguna responsif dan pengalaman pengguna yang lebih baik selama tugas kompleks.
- **Pembatalan Permintaan**: Client dapat membatalkan permintaan yang sedang berjalan, memungkinkan pengguna menghentikan operasi yang tidak lagi diperlukan atau terlalu lama.
- **Pelaporan Error**: Pesan dan kode error standar membantu mendiagnosis masalah, menangani kegagalan dengan baik, dan memberikan umpan balik yang dapat ditindaklanjuti kepada pengguna dan pengembang.
- **Logging**: Baik client maupun server dapat menghasilkan log terstruktur untuk audit, debugging, dan pemantauan interaksi protokol.

Dengan memanfaatkan fitur protokol ini, MCP memastikan komunikasi yang kuat, aman, dan fleksibel antara model bahasa dan alat atau sumber data eksternal.

### 🔐 Pertimbangan Keamanan

Implementasi MCP harus mematuhi beberapa prinsip keamanan utama untuk memastikan interaksi yang aman dan dapat dipercaya:

- **Persetujuan dan Kontrol Pengguna**: Pengguna harus memberikan persetujuan eksplisit sebelum data diakses atau operasi dilakukan. Mereka harus memiliki kontrol jelas atas data apa yang dibagikan dan tindakan mana yang diizinkan, didukung oleh antarmuka pengguna yang intuitif untuk meninjau dan menyetujui aktivitas.

- **Privasi Data**: Data pengguna hanya boleh diakses dengan persetujuan eksplisit dan harus dilindungi dengan kontrol akses yang sesuai. Implementasi MCP harus mencegah transmisi data yang tidak sah dan memastikan privasi terjaga selama semua interaksi.

- **Keamanan Alat**: Sebelum memanggil alat apa pun, diperlukan persetujuan pengguna secara eksplisit. Pengguna harus memahami fungsi setiap alat dengan jelas, dan batas keamanan yang kuat harus diterapkan untuk mencegah eksekusi alat yang tidak disengaja atau berbahaya.

Dengan mengikuti prinsip-prinsip ini, MCP memastikan kepercayaan, privasi, dan keamanan pengguna terjaga dalam semua interaksi protokol.

## Contoh Kode: Komponen Utama

Berikut contoh kode dalam beberapa bahasa pemrograman populer yang menggambarkan cara mengimplementasikan komponen server MCP utama dan alat.

### Contoh .NET: Membuat Server MCP Sederhana dengan Alat

Berikut contoh kode .NET praktis yang menunjukkan cara mengimplementasikan server MCP sederhana dengan alat khusus. Contoh ini menampilkan cara mendefinisikan dan mendaftarkan alat, menangani permintaan, dan menghubungkan server menggunakan Model Context Protocol.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Contoh Java: Komponen Server MCP

Contoh ini menunjukkan server MCP yang sama dan pendaftaran alat seperti contoh .NET di atas, tetapi diimplementasikan dalam Java.

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Contoh Python: Membangun Server MCP

Dalam contoh ini kami menunjukkan cara membangun server MCP dalam Python. Anda juga diperlihatkan dua cara berbeda untuk membuat alat.

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
    asyncio.run(serve_stdio(mcp))
```

### Contoh JavaScript: Membuat Server MCP

Contoh ini menunjukkan pembuatan server MCP dalam JavaScript dan cara mendaftarkan dua alat terkait cuaca.

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

Contoh JavaScript ini menunjukkan cara membuat client MCP yang terhubung ke server, mengirim prompt, dan memproses respons termasuk panggilan alat yang dilakukan.

## Keamanan dan Otorisasi

MCP mencakup beberapa konsep dan mekanisme bawaan untuk mengelola keamanan dan otorisasi sepanjang protokol:

1. **Kontrol Izin Alat**:  
  Client dapat menentukan alat mana yang boleh digunakan model selama sesi. Ini memastikan hanya alat yang secara eksplisit diizinkan yang dapat diakses, mengurangi risiko operasi yang tidak disengaja atau berbahaya. Izin dapat dikonfigurasi secara dinamis berdasarkan preferensi pengguna, kebijakan organisasi, atau konteks interaksi.

2. **Autentikasi**:  
  Server dapat mengharuskan autentikasi sebelum memberikan akses ke alat, sumber daya, atau operasi sensitif. Ini dapat melibatkan API key, token OAuth, atau skema autentikasi lainnya. Autentikasi yang tepat memastikan hanya client dan pengguna tepercaya yang dapat memanggil kapabilitas server.

3. **Validasi**:  
  Validasi parameter diterapkan untuk semua pemanggilan alat. Setiap alat mendefinisikan tipe, format, dan batasan yang diharapkan untuk parameternya, dan server memvalidasi permintaan yang masuk sesuai. Ini mencegah input yang salah format atau berbahaya mencapai implementasi alat dan membantu menjaga integritas operasi.

4. **Pembatasan Laju (Rate Limiting)**:  
  Untuk mencegah penyalahgunaan dan memastikan penggunaan sumber daya server yang adil, server MCP dapat menerapkan pembatasan laju untuk panggilan alat dan akses sumber daya. Pembatasan laju dapat diterapkan per pengguna, per sesi, atau secara global, dan membantu melindungi dari serangan denial-of-service atau konsumsi sumber daya berlebihan.

Dengan menggabungkan mekanisme ini, MCP menyediakan fondasi yang aman untuk mengintegrasikan model bahasa dengan alat dan sumber data eksternal, sambil memberikan kontrol granular kepada pengguna dan pengembang atas akses dan penggunaan.

## Pesan Protokol

Komunikasi MCP menggunakan pesan JSON terstruktur untuk memfasilitasi interaksi yang jelas dan andal antara client, server, dan model. Jenis pesan utama meliputi:

- **Permintaan Client**  
  Dikirim dari client ke server, pesan ini biasanya mencakup:
  - Prompt atau perintah pengguna
  - Riwayat percakapan untuk konteks
  - Konfigurasi dan izin alat
  - Metadata tambahan atau informasi sesi

- **Respons Model**  
  Dikembalikan oleh model (melalui client), pesan ini berisi:
  - Teks yang dihasilkan atau penyelesaian berdasarkan prompt dan konteks
  - Instruksi pemanggilan alat opsional jika model menentukan alat harus dipanggil
  - Referensi ke sumber daya atau konteks tambahan sesuai kebutuhan

- **Permintaan Alat**  
  Dikirim dari client ke server ketika alat perlu dijalankan. Pesan ini mencakup:
  - Nama alat yang akan dipanggil
  - Parameter yang diperlukan alat (divalidasi terhadap skema alat)
  - Informasi kontekstual atau pengenal untuk melacak permintaan

- **Respons Alat**  
  Dikembalikan oleh server setelah menjalankan alat. Pesan ini menyediakan:
  - Hasil eksekusi alat (data terstruktur atau konten)
  - Error atau informasi status jika panggilan alat gagal
  - Opsional, metadata tambahan atau log terkait eksekusi

Pesan terstruktur ini memastikan setiap langkah dalam alur kerja MCP eksplisit, dapat dilacak, dan dapat diperluas, mendukung skenario lanjutan seperti percakapan multi-putaran, penggabungan alat, dan penanganan error yang kuat.

## Poin Penting

- MCP menggunakan arsitektur client-server untuk menghubungkan model dengan kapabilitas eksternal
- Ekosistem terdiri dari client, host, server, alat, dan sumber data
- Komunikasi dapat terjadi melalui STDIO, SSE, atau WebSockets
- Alat adalah unit fungsi dasar yang diekspos ke model
- Protokol komunikasi terstruktur memastikan interaksi yang konsisten

## Latihan

Rancang alat MCP sederhana yang berguna di bidang Anda. Tentukan:
1. Nama alat tersebut
2. Parameter yang diterima
3. Output yang dikembalikan
4. Bagaimana model dapat menggunakan alat ini untuk menyelesaikan masalah pengguna

---

## Selanjutnya

Selanjutnya

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau kesalahan tafsir yang timbul dari penggunaan terjemahan ini.