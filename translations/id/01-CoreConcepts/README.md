<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:44:33+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "id"
}
-->
# 📖 Konsep Inti MCP: Menguasai Model Context Protocol untuk Integrasi AI

Model Context Protocol (MCP) adalah kerangka kerja standar yang kuat yang mengoptimalkan komunikasi antara Large Language Models (LLM) dan alat eksternal, aplikasi, serta sumber data. Panduan yang dioptimalkan untuk SEO ini akan membimbing Anda melalui konsep inti MCP, memastikan Anda memahami arsitektur client-server, komponen penting, mekanisme komunikasi, dan praktik terbaik implementasinya.

## Ikhtisar

Pelajaran ini mengeksplorasi arsitektur dasar dan komponen yang membentuk ekosistem Model Context Protocol (MCP). Anda akan mempelajari arsitektur client-server, komponen utama, dan mekanisme komunikasi yang mendukung interaksi MCP.

## 👩‍🎓 Tujuan Pembelajaran Utama

Di akhir pelajaran ini, Anda akan:

- Memahami arsitektur client-server MCP.
- Mengidentifikasi peran dan tanggung jawab Hosts, Clients, dan Servers.
- Menganalisis fitur inti yang membuat MCP menjadi lapisan integrasi yang fleksibel.
- Mempelajari bagaimana aliran informasi berlangsung dalam ekosistem MCP.
- Mendapatkan wawasan praktis melalui contoh kode dalam .NET, Java, Python, dan JavaScript.

## 🔎 Arsitektur MCP: Pandangan Lebih Dalam

Ekosistem MCP dibangun berdasarkan model client-server. Struktur modular ini memungkinkan aplikasi AI berinteraksi dengan alat, basis data, API, dan sumber daya kontekstual secara efisien. Mari kita uraikan arsitektur ini ke dalam komponen utamanya.

### 1. Hosts

Dalam Model Context Protocol (MCP), Hosts berperan penting sebagai antarmuka utama yang digunakan pengguna untuk berinteraksi dengan protokol. Hosts adalah aplikasi atau lingkungan yang memulai koneksi dengan server MCP untuk mengakses data, alat, dan prompt. Contoh Hosts termasuk integrated development environments (IDE) seperti Visual Studio Code, alat AI seperti Claude Desktop, atau agen khusus yang dibuat untuk tugas tertentu.

**Hosts** adalah aplikasi LLM yang memulai koneksi. Mereka:

- Menjalankan atau berinteraksi dengan model AI untuk menghasilkan respons.
- Memulai koneksi dengan server MCP.
- Mengelola alur percakapan dan antarmuka pengguna.
- Mengontrol izin dan batasan keamanan.
- Menangani persetujuan pengguna untuk berbagi data dan eksekusi alat.

### 2. Clients

Clients adalah komponen penting yang memfasilitasi interaksi antara Hosts dan server MCP. Clients bertindak sebagai perantara, memungkinkan Hosts mengakses dan memanfaatkan fungsi yang disediakan oleh server MCP. Mereka berperan penting dalam memastikan komunikasi berjalan lancar dan pertukaran data efisien dalam arsitektur MCP.

**Clients** adalah penghubung di dalam aplikasi host. Mereka:

- Mengirim permintaan ke server dengan prompt/instruksi.
- Bernegosiasi tentang kemampuan dengan server.
- Mengelola permintaan eksekusi alat dari model.
- Memproses dan menampilkan respons kepada pengguna.

### 3. Servers

Servers bertanggung jawab menangani permintaan dari client MCP dan memberikan respons yang sesuai. Mereka mengelola berbagai operasi seperti pengambilan data, eksekusi alat, dan pembuatan prompt. Servers memastikan komunikasi antara client dan Hosts berjalan efisien dan dapat diandalkan, menjaga integritas proses interaksi.

**Servers** adalah layanan yang menyediakan konteks dan kemampuan. Mereka:

- Mendaftarkan fitur yang tersedia (sumber daya, prompt, alat)
- Menerima dan menjalankan panggilan alat dari client
- Memberikan informasi kontekstual untuk meningkatkan respons model
- Mengembalikan hasil ke client
- Mempertahankan status selama interaksi jika diperlukan

Servers dapat dikembangkan oleh siapa saja untuk memperluas kemampuan model dengan fungsi khusus.

### 4. Fitur Server

Server dalam Model Context Protocol (MCP) menyediakan blok bangunan dasar yang memungkinkan interaksi kaya antara client, host, dan model bahasa. Fitur ini dirancang untuk meningkatkan kemampuan MCP dengan menawarkan konteks terstruktur, alat, dan prompt.

Server MCP dapat menawarkan salah satu fitur berikut:

#### 📑 Resources

Resources dalam Model Context Protocol (MCP) mencakup berbagai jenis konteks dan data yang dapat digunakan oleh pengguna atau model AI. Ini termasuk:

- **Data Kontekstual**: Informasi dan konteks yang dapat dimanfaatkan pengguna atau model AI untuk pengambilan keputusan dan pelaksanaan tugas.
- **Basis Pengetahuan dan Repositori Dokumen**: Kumpulan data terstruktur dan tidak terstruktur, seperti artikel, manual, dan makalah penelitian yang menyediakan wawasan dan informasi berharga.
- **File Lokal dan Basis Data**: Data yang disimpan secara lokal di perangkat atau dalam basis data, dapat diakses untuk pemrosesan dan analisis.
- **API dan Layanan Web**: Antarmuka eksternal dan layanan yang menawarkan data dan fungsi tambahan, memungkinkan integrasi dengan berbagai sumber daya dan alat online.

Contoh resource bisa berupa skema basis data atau file yang dapat diakses seperti berikut:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts dalam Model Context Protocol (MCP) mencakup berbagai template dan pola interaksi yang telah ditentukan sebelumnya untuk mempermudah alur kerja pengguna dan meningkatkan komunikasi. Ini termasuk:

- **Pesan dan Alur Kerja Bertemplate**: Pesan dan proses yang sudah terstruktur yang memandu pengguna melalui tugas dan interaksi tertentu.
- **Pola Interaksi yang Telah Ditentukan**: Urutan standar tindakan dan respons yang memfasilitasi komunikasi yang konsisten dan efisien.
- **Template Percakapan Khusus**: Template yang dapat disesuaikan untuk jenis percakapan tertentu, memastikan interaksi yang relevan dan sesuai konteks.

Template prompt dapat terlihat seperti ini:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools dalam Model Context Protocol (MCP) adalah fungsi yang dapat dijalankan oleh model AI untuk melakukan tugas tertentu. Tools ini dirancang untuk meningkatkan kemampuan model AI dengan menyediakan operasi yang terstruktur dan dapat diandalkan. Aspek utama meliputi:

- **Fungsi yang dapat dijalankan oleh model AI**: Tools adalah fungsi yang dapat dieksekusi yang dapat dipanggil oleh model AI untuk menyelesaikan berbagai tugas.
- **Nama dan Deskripsi Unik**: Setiap tool memiliki nama unik dan deskripsi rinci yang menjelaskan tujuan dan fungsinya.
- **Parameter dan Output**: Tools menerima parameter tertentu dan mengembalikan output terstruktur, memastikan hasil yang konsisten dan dapat diprediksi.
- **Fungsi Terpisah**: Tools menjalankan fungsi terpisah seperti pencarian web, perhitungan, dan query basis data.

Contoh tool bisa terlihat seperti ini:

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

Dalam Model Context Protocol (MCP), client menawarkan beberapa fitur utama kepada server, meningkatkan fungsionalitas dan interaksi dalam protokol. Salah satu fitur penting adalah Sampling.

### 👉 Sampling

- **Perilaku Agen yang Diinisiasi Server**: Client memungkinkan server memulai tindakan atau perilaku tertentu secara otomatis, meningkatkan kemampuan dinamis sistem.
- **Interaksi Rekursif dengan LLM**: Fitur ini memungkinkan interaksi berulang dengan large language models (LLM), memungkinkan pemrosesan tugas yang lebih kompleks dan iteratif.
- **Permintaan Penyelesaian Model Tambahan**: Server dapat meminta penyelesaian tambahan dari model, memastikan respons yang lengkap dan relevan secara kontekstual.

## Aliran Informasi dalam MCP

Model Context Protocol (MCP) mendefinisikan aliran informasi yang terstruktur antara host, client, server, dan model. Memahami aliran ini membantu memperjelas bagaimana permintaan pengguna diproses dan bagaimana alat eksternal serta data diintegrasikan ke dalam respons model.

- **Host Memulai Koneksi**  
  Aplikasi host (seperti IDE atau antarmuka chat) membuat koneksi ke server MCP, biasanya melalui STDIO, WebSocket, atau transport lain yang didukung.

- **Negosiasi Kemampuan**  
  Client (yang tersemat di host) dan server bertukar informasi tentang fitur, alat, sumber daya, dan versi protokol yang didukung. Ini memastikan kedua pihak memahami kemampuan yang tersedia untuk sesi tersebut.

- **Permintaan Pengguna**  
  Pengguna berinteraksi dengan host (misalnya memasukkan prompt atau perintah). Host mengumpulkan input ini dan mengirimkannya ke client untuk diproses.

- **Penggunaan Resource atau Tool**  
  - Client dapat meminta konteks atau sumber daya tambahan dari server (seperti file, entri basis data, atau artikel basis pengetahuan) untuk memperkaya pemahaman model.
  - Jika model menentukan bahwa sebuah tool diperlukan (misalnya untuk mengambil data, melakukan perhitungan, atau memanggil API), client mengirimkan permintaan pemanggilan tool ke server, dengan menyebutkan nama tool dan parameternya.

- **Eksekusi Server**  
  Server menerima permintaan resource atau tool, menjalankan operasi yang diperlukan (seperti menjalankan fungsi, query basis data, atau mengambil file), dan mengembalikan hasilnya ke client dalam format terstruktur.

- **Pembuatan Respons**  
  Client mengintegrasikan respons server (data resource, output tool, dll.) ke dalam interaksi model yang sedang berlangsung. Model menggunakan informasi ini untuk menghasilkan respons yang komprehensif dan relevan secara kontekstual.

- **Penyajian Hasil**  
  Host menerima output akhir dari client dan menyajikannya kepada pengguna, biasanya termasuk teks yang dihasilkan model dan hasil dari eksekusi tool atau pencarian resource.

Aliran ini memungkinkan MCP mendukung aplikasi AI yang canggih, interaktif, dan sadar konteks dengan menghubungkan model secara mulus dengan alat dan sumber data eksternal.

## Detail Protokol

MCP (Model Context Protocol) dibangun di atas [JSON-RPC 2.0](https://www.jsonrpc.org/), menyediakan format pesan standar dan lintas bahasa untuk komunikasi antara host, client, dan server. Dasar ini memungkinkan interaksi yang andal, terstruktur, dan dapat diperluas di berbagai platform dan bahasa pemrograman.

### Fitur Utama Protokol

MCP memperluas JSON-RPC 2.0 dengan konvensi tambahan untuk pemanggilan tool, akses resource, dan pengelolaan prompt. Protokol ini mendukung berbagai lapisan transport (STDIO, WebSocket, SSE) dan memungkinkan komunikasi yang aman, dapat diperluas, dan lintas bahasa antar komponen.

#### 🧢 Protokol Dasar

- **Format Pesan JSON-RPC**: Semua permintaan dan respons menggunakan spesifikasi JSON-RPC 2.0, memastikan struktur konsisten untuk panggilan metode, parameter, hasil, dan penanganan kesalahan.
- **Koneksi Stateful**: Sesi MCP mempertahankan status di antara beberapa permintaan, mendukung percakapan berkelanjutan, akumulasi konteks, dan pengelolaan resource.
- **Negosiasi Kemampuan**: Saat pengaturan koneksi, client dan server bertukar informasi tentang fitur yang didukung, versi protokol, alat, dan resource yang tersedia. Ini memastikan kedua pihak memahami kemampuan masing-masing dan dapat beradaptasi.

#### ➕ Utilitas Tambahan

Berikut beberapa utilitas dan ekstensi protokol yang MCP sediakan untuk meningkatkan pengalaman pengembang dan mendukung skenario lanjutan:

- **Opsi Konfigurasi**: MCP memungkinkan konfigurasi dinamis parameter sesi, seperti izin alat, akses resource, dan pengaturan model, disesuaikan untuk setiap interaksi.
- **Pelacakan Progres**: Operasi yang berjalan lama dapat melaporkan pembaruan progres, memungkinkan antarmuka pengguna yang responsif dan pengalaman pengguna yang lebih baik selama tugas kompleks.
- **Pembatalan Permintaan**: Client dapat membatalkan permintaan yang sedang berjalan, memungkinkan pengguna menghentikan operasi yang tidak lagi diperlukan atau terlalu lama.
- **Pelaporan Kesalahan**: Pesan dan kode kesalahan standar membantu mendiagnosis masalah, menangani kegagalan dengan baik, dan memberikan umpan balik yang dapat ditindaklanjuti kepada pengguna dan pengembang.
- **Logging**: Baik client maupun server dapat mengeluarkan log terstruktur untuk audit, debugging, dan pemantauan interaksi protokol.

Dengan memanfaatkan fitur protokol ini, MCP menjamin komunikasi yang kuat, aman, dan fleksibel antara model bahasa dan alat atau sumber data eksternal.

### 🔐 Pertimbangan Keamanan

Implementasi MCP harus mematuhi beberapa prinsip keamanan utama untuk memastikan interaksi yang aman dan dapat dipercaya:

- **Persetujuan dan Kontrol Pengguna**: Pengguna harus memberikan persetujuan eksplisit sebelum data diakses atau operasi dijalankan. Mereka harus memiliki kontrol jelas atas data apa yang dibagikan dan tindakan mana yang diizinkan, didukung oleh antarmuka pengguna yang intuitif untuk meninjau dan menyetujui aktivitas.

- **Privasi Data**: Data pengguna hanya boleh dibuka dengan persetujuan eksplisit dan harus dilindungi oleh kontrol akses yang sesuai. Implementasi MCP harus melindungi dari transmisi data yang tidak sah dan memastikan privasi terjaga sepanjang interaksi.

- **Keamanan Alat**: Sebelum memanggil alat apa pun, persetujuan pengguna eksplisit diperlukan. Pengguna harus memahami fungsi setiap alat dengan jelas, dan batas keamanan yang kuat harus diterapkan untuk mencegah eksekusi alat yang tidak diinginkan atau berbahaya.

Dengan mengikuti prinsip ini, MCP memastikan kepercayaan, privasi, dan keamanan pengguna terjaga dalam semua interaksi protokol.

## Contoh Kode: Komponen Utama

Berikut adalah contoh kode dalam beberapa bahasa pemrograman populer yang menggambarkan cara mengimplementasikan komponen server MCP utama dan tools.

### Contoh .NET: Membuat Server MCP Sederhana dengan Tools

Berikut contoh kode .NET praktis yang menunjukkan cara mengimplementasikan server MCP sederhana dengan tools khusus. Contoh ini menampilkan cara mendefinisikan dan mendaftarkan tools, menangani permintaan, dan menghubungkan server menggunakan Model Context Protocol.

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

Contoh ini menunjukkan server MCP dan pendaftaran tools yang sama seperti contoh .NET di atas, tetapi diimplementasikan dalam Java.

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

Dalam contoh ini kami menunjukkan cara membangun server MCP di Python. Anda juga diperlihatkan dua cara berbeda untuk membuat tools.

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

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### Contoh JavaScript: Membuat Server MCP

Contoh ini menunjukkan pembuatan server MCP dalam JavaScript dan cara mendaftarkan dua tools terkait cuaca.

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

Contoh JavaScript ini menunjukkan cara membuat client MCP yang terhubung ke server, mengirim prompt, dan memproses respons termasuk panggilan tool yang dilakukan.

## Keamanan dan Otorisasi

MCP mencakup beberapa konsep dan mekanisme bawaan untuk mengelola keamanan dan otorisasi di seluruh protokol:

1. **Kontrol Izin Alat**  
  Client dapat menentukan alat mana yang boleh digunakan model selama sesi. Ini memastikan hanya alat yang secara eksplisit diizinkan yang dapat diakses, mengurangi risiko operasi yang tidak diinginkan atau berbahaya. Izin dapat dikonfigurasi secara dinamis berdasarkan preferensi pengguna, kebijakan organisasi, atau konteks interaksi.

2. **Autentikasi**  
  Server dapat mengharuskan autentikasi sebelum memberikan akses ke alat, resource, atau operasi sensitif. Ini dapat melibatkan API key, token OAuth, atau skema autentikasi lain. Autentikasi yang tepat memastikan hanya client dan pengguna terpercaya yang dapat memanggil kemampuan sisi server.

3. **Validasi**  
  Validasi parameter diterapkan untuk semua pemanggilan alat. Setiap alat mendefinisikan tipe, format, dan batasan yang diharapkan untuk parameternya, dan server memvalidasi permintaan yang masuk sesuai dengan itu. Ini mencegah input yang salah format atau berbahaya mencapai implementasi alat dan membantu menjaga integritas operasi.

4. **Pembatasan Laju**  
  Untuk mencegah penyalahgunaan dan memastikan penggunaan sumber daya server yang adil, server MCP dapat menerapkan pembatasan laju untuk panggilan alat dan akses resource. Pembatasan dapat diterapkan per pengguna, per sesi, atau secara global, dan membantu melindungi dari serangan denial-of-service atau konsumsi sumber daya berlebihan.

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
  - Instruksi panggilan alat opsional jika model menentukan alat perlu dipanggil
  - Referensi ke resource atau konteks tambahan sesuai kebutuhan

- **Permintaan Tool**  
  Dikirim dari client ke server ketika sebuah tool perlu dijalankan. Pesan ini mencakup:
  - Nama tool yang akan dipanggil
  - Parameter yang diperlukan oleh tool (divalidasi sesuai skema tool)
  - Informasi kontekstual atau pengenal untuk melacak permintaan

- **Respons Tool**  
  Dikembalikan oleh server setelah menjalankan tool. Pesan ini menyediakan:
  - Hasil eksekusi tool (data terstruktur atau konten)
  - Setiap kesalahan atau informasi status jika panggilan tool gagal
  - Opsional, metadata tambahan atau log terkait eksekusi

Pesan terstruktur ini memastikan setiap langkah dalam alur kerja MCP eksplisit, dapat dilacak, dan dapat diperluas, mendukung skenario lanjutan seperti percakapan multi-putaran, chaining tool, dan penanganan kesalahan yang kuat.

## Poin Penting

- MCP menggunakan arsitektur client-server untuk menghubungkan model dengan kemampuan eksternal
- Ekosistem terdiri dari client, host, server, tool, dan sumber data
- Komunikasi dapat berlangsung melalui STDIO, SSE, atau WebSocket
- Tools adalah unit dasar fungsionalitas yang diekspos ke model
- Protokol komunikasi terstruktur memastikan interaksi yang konsisten

## Latihan

Rancang sebuah tool MCP sederhana yang berguna dalam domain Anda. Tentukan:
1. Nama tool tersebut
2. Parameter apa yang diterimanya
3. Output apa yang akan dikembalikan
4. Bagaimana model dapat menggunakan tool ini untuk menyelesaikan masalah pengguna

---

## Selanjutnya

Berikutnya: [Chapter 2: Security](/02-Security/readme.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk memberikan terjemahan yang akurat, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah dan utama. Untuk informasi yang sangat penting, disarankan menggunakan jasa penerjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.