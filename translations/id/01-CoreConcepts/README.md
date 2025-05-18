<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:49:57+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "id"
}
-->
# 📖 Konsep Inti MCP: Menguasai Model Context Protocol untuk Integrasi AI

Model Context Protocol (MCP) adalah kerangka kerja standar yang kuat yang mengoptimalkan komunikasi antara Large Language Models (LLMs) dan alat eksternal, aplikasi, serta sumber data. Panduan yang dioptimalkan untuk SEO ini akan membimbing Anda melalui konsep inti MCP, memastikan Anda memahami arsitektur klien-server, komponen penting, mekanisme komunikasi, dan praktik terbaik implementasi.

## Ikhtisar

Pelajaran ini mengeksplorasi arsitektur dasar dan komponen yang membentuk ekosistem Model Context Protocol (MCP). Anda akan belajar tentang arsitektur klien-server, komponen utama, dan mekanisme komunikasi yang mendukung interaksi MCP.

## 👩‍🎓 Tujuan Pembelajaran Utama

Pada akhir pelajaran ini, Anda akan:

- Memahami arsitektur klien-server MCP.
- Mengidentifikasi peran dan tanggung jawab Host, Klien, dan Server.
- Menganalisis fitur inti yang membuat MCP menjadi lapisan integrasi yang fleksibel.
- Mempelajari bagaimana informasi mengalir dalam ekosistem MCP.
- Mendapatkan wawasan praktis melalui contoh kode dalam .NET, Java, Python, dan JavaScript.

## 🔎 Arsitektur MCP: Tinjauan Mendalam

Ekosistem MCP dibangun di atas model klien-server. Struktur modular ini memungkinkan aplikasi AI untuk berinteraksi dengan alat, basis data, API, dan sumber daya kontekstual secara efisien. Mari kita uraikan arsitektur ini ke dalam komponen intinya.

### 1. Hosts

Dalam Model Context Protocol (MCP), Hosts memainkan peran penting sebagai antarmuka utama di mana pengguna berinteraksi dengan protokol. Hosts adalah aplikasi atau lingkungan yang memulai koneksi dengan server MCP untuk mengakses data, alat, dan prompt. Contoh Hosts termasuk lingkungan pengembangan terintegrasi (IDEs) seperti Visual Studio Code, alat AI seperti Claude Desktop, atau agen yang dibangun khusus untuk tugas tertentu.

**Hosts** adalah aplikasi LLM yang memulai koneksi. Mereka:

- Menjalankan atau berinteraksi dengan model AI untuk menghasilkan respons.
- Memulai koneksi dengan server MCP.
- Mengelola aliran percakapan dan antarmuka pengguna.
- Mengontrol izin dan batasan keamanan.
- Menangani persetujuan pengguna untuk berbagi data dan menjalankan alat.

### 2. Clients

Klien adalah komponen penting yang memfasilitasi interaksi antara Hosts dan server MCP. Klien bertindak sebagai perantara, memungkinkan Hosts untuk mengakses dan memanfaatkan fungsionalitas yang disediakan oleh server MCP. Mereka memainkan peran penting dalam memastikan komunikasi yang lancar dan pertukaran data yang efisien dalam arsitektur MCP.

**Clients** adalah konektor dalam aplikasi host. Mereka:

- Mengirim permintaan ke server dengan prompt/instruksi.
- Menegosiasikan kemampuan dengan server.
- Mengelola permintaan eksekusi alat dari model.
- Memproses dan menampilkan respons kepada pengguna.

### 3. Servers

Server bertanggung jawab untuk menangani permintaan dari klien MCP dan memberikan respons yang sesuai. Mereka mengelola berbagai operasi seperti pengambilan data, eksekusi alat, dan pembuatan prompt. Server memastikan bahwa komunikasi antara klien dan Hosts efisien dan dapat diandalkan, menjaga integritas proses interaksi.

**Servers** adalah layanan yang menyediakan konteks dan kemampuan. Mereka:

- Mendaftarkan fitur yang tersedia (sumber daya, prompt, alat)
- Menerima dan menjalankan panggilan alat dari klien
- Memberikan informasi kontekstual untuk meningkatkan respons model
- Mengembalikan output kembali ke klien
- Mempertahankan status di seluruh interaksi saat diperlukan

Server dapat dikembangkan oleh siapa saja untuk memperluas kemampuan model dengan fungsi khusus.

### 4. Fitur Server

Server dalam Model Context Protocol (MCP) menyediakan blok bangunan dasar yang memungkinkan interaksi kaya antara klien, host, dan model bahasa. Fitur-fitur ini dirancang untuk meningkatkan kemampuan MCP dengan menawarkan konteks terstruktur, alat, dan prompt.

Server MCP dapat menawarkan fitur-fitur berikut:

#### 📑 Sumber Daya 

Sumber daya dalam Model Context Protocol (MCP) mencakup berbagai jenis konteks dan data yang dapat digunakan oleh pengguna atau model AI. Ini termasuk:

- **Data Kontekstual**: Informasi dan konteks yang dapat dimanfaatkan oleh pengguna atau model AI untuk pengambilan keputusan dan pelaksanaan tugas.
- **Basis Pengetahuan dan Repositori Dokumen**: Koleksi data terstruktur dan tidak terstruktur, seperti artikel, manual, dan makalah penelitian, yang memberikan wawasan dan informasi berharga.
- **File Lokal dan Basis Data**: Data yang disimpan secara lokal pada perangkat atau dalam basis data, dapat diakses untuk pemrosesan dan analisis.
- **API dan Layanan Web**: Antarmuka dan layanan eksternal yang menawarkan data dan fungsionalitas tambahan, memungkinkan integrasi dengan berbagai sumber daya dan alat online.

Contoh sumber daya dapat berupa skema basis data atau file yang dapat diakses seperti ini:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts dalam Model Context Protocol (MCP) mencakup berbagai template dan pola interaksi yang telah ditentukan sebelumnya yang dirancang untuk menyederhanakan alur kerja pengguna dan meningkatkan komunikasi. Ini termasuk:

- **Pesan dan Alur Kerja Templat**: Pesan dan proses yang telah terstruktur yang membimbing pengguna melalui tugas dan interaksi tertentu.
- **Pola Interaksi yang Telah Ditentukan**: Urutan tindakan dan respons yang terstandarisasi yang memfasilitasi komunikasi yang konsisten dan efisien.
- **Template Percakapan Khusus**: Template yang dapat disesuaikan yang dirancang untuk jenis percakapan tertentu, memastikan interaksi yang relevan dan sesuai dengan konteks.

Template prompt dapat terlihat seperti ini:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alat

Alat dalam Model Context Protocol (MCP) adalah fungsi yang dapat dieksekusi oleh model AI untuk melakukan tugas tertentu. Alat-alat ini dirancang untuk meningkatkan kemampuan model AI dengan menyediakan operasi yang terstruktur dan andal. Aspek utama termasuk:

- **Fungsi untuk Model AI untuk Dieksekusi**: Alat adalah fungsi yang dapat dieksekusi yang dapat dipanggil oleh model AI untuk melaksanakan berbagai tugas.
- **Nama dan Deskripsi Unik**: Setiap alat memiliki nama yang berbeda dan deskripsi yang menjelaskan tujuan dan fungsionalitasnya.
- **Parameter dan Output**: Alat menerima parameter tertentu dan mengembalikan output terstruktur, memastikan hasil yang konsisten dan dapat diprediksi.
- **Fungsi Diskrit**: Alat melakukan fungsi diskrit seperti pencarian web, perhitungan, dan kueri basis data.

Contoh alat dapat terlihat seperti ini:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Fitur Klien

Dalam Model Context Protocol (MCP), klien menawarkan beberapa fitur utama kepada server, meningkatkan fungsionalitas dan interaksi keseluruhan dalam protokol. Salah satu fitur yang penting adalah Sampling.

### 👉 Sampling

- **Perilaku Agen yang Diinisiasi Server**: Klien memungkinkan server untuk memulai tindakan atau perilaku tertentu secara otonom, meningkatkan kemampuan dinamis sistem.
- **Interaksi LLM Rekursif**: Fitur ini memungkinkan interaksi rekursif dengan model bahasa besar (LLMs), memungkinkan pemrosesan tugas yang lebih kompleks dan iteratif.
- **Meminta Penyelesaian Model Tambahan**: Server dapat meminta penyelesaian tambahan dari model, memastikan bahwa respons menyeluruh dan relevan dengan konteks.

## Aliran Informasi dalam MCP

Model Context Protocol (MCP) mendefinisikan aliran informasi yang terstruktur antara host, klien, server, dan model. Memahami aliran ini membantu menjelaskan bagaimana permintaan pengguna diproses dan bagaimana alat serta data eksternal diintegrasikan ke dalam respons model.

- **Host Memulai Koneksi**  
  Aplikasi host (seperti IDE atau antarmuka obrolan) membangun koneksi ke server MCP, biasanya melalui STDIO, WebSocket, atau transportasi lain yang didukung.

- **Negosiasi Kemampuan**  
  Klien (tertanam dalam host) dan server bertukar informasi tentang fitur, alat, sumber daya, dan versi protokol yang didukung. Ini memastikan kedua belah pihak memahami kemampuan apa yang tersedia untuk sesi.

- **Permintaan Pengguna**  
  Pengguna berinteraksi dengan host (misalnya, memasukkan prompt atau perintah). Host mengumpulkan input ini dan meneruskannya ke klien untuk diproses.

- **Penggunaan Sumber Daya atau Alat**  
  - Klien dapat meminta konteks atau sumber daya tambahan dari server (seperti file, entri basis data, atau artikel basis pengetahuan) untuk memperkaya pemahaman model.
  - Jika model menentukan bahwa alat diperlukan (misalnya, untuk mengambil data, melakukan perhitungan, atau memanggil API), klien mengirimkan permintaan pemanggilan alat ke server, menentukan nama alat dan parameter.

- **Eksekusi Server**  
  Server menerima permintaan sumber daya atau alat, melakukan operasi yang diperlukan (seperti menjalankan fungsi, melakukan kueri basis data, atau mengambil file), dan mengembalikan hasil ke klien dalam format terstruktur.

- **Pembuatan Respons**  
  Klien mengintegrasikan respons server (data sumber daya, output alat, dll.) ke dalam interaksi model yang sedang berlangsung. Model menggunakan informasi ini untuk menghasilkan respons yang komprehensif dan relevan dengan konteks.

- **Presentasi Hasil**  
  Host menerima output akhir dari klien dan menyajikannya kepada pengguna, sering kali termasuk teks yang dihasilkan model dan hasil dari eksekusi alat atau pencarian sumber daya.

Aliran ini memungkinkan MCP mendukung aplikasi AI yang canggih, interaktif, dan sadar konteks dengan menghubungkan model secara mulus dengan alat dan sumber data eksternal.

## Detail Protokol

MCP (Model Context Protocol) dibangun di atas [JSON-RPC 2.0](https://www.jsonrpc.org/), menyediakan format pesan standar, bebas bahasa untuk komunikasi antara host, klien, dan server. Fondasi ini memungkinkan interaksi yang dapat diandalkan, terstruktur, dan dapat diperluas di berbagai platform dan bahasa pemrograman.

### Fitur Protokol Utama

MCP memperluas JSON-RPC 2.0 dengan konvensi tambahan untuk pemanggilan alat, akses sumber daya, dan manajemen prompt. Ini mendukung beberapa lapisan transportasi (STDIO, WebSocket, SSE) dan memungkinkan komunikasi yang aman, dapat diperluas, dan bebas bahasa antara komponen.

#### 🧢 Protokol Dasar

- **Format Pesan JSON-RPC**: Semua permintaan dan respons menggunakan spesifikasi JSON-RPC 2.0, memastikan struktur konsisten untuk panggilan metode, parameter, hasil, dan penanganan kesalahan.
- **Koneksi Berstatus**: Sesi MCP mempertahankan status di seluruh permintaan, mendukung percakapan yang sedang berlangsung, akumulasi konteks, dan manajemen sumber daya.
- **Negosiasi Kemampuan**: Selama pengaturan koneksi, klien dan server bertukar informasi tentang fitur yang didukung, versi protokol, alat yang tersedia, dan sumber daya. Ini memastikan kedua belah pihak memahami kemampuan masing-masing dan dapat beradaptasi sesuai kebutuhan.

#### ➕ Utilitas Tambahan

Berikut adalah beberapa utilitas tambahan dan ekstensi protokol yang disediakan MCP untuk meningkatkan pengalaman pengembang dan memungkinkan skenario lanjutan:

- **Opsi Konfigurasi**: MCP memungkinkan konfigurasi dinamis parameter sesi, seperti izin alat, akses sumber daya, dan pengaturan model, disesuaikan dengan setiap interaksi.
- **Pelacakan Kemajuan**: Operasi yang berjalan lama dapat melaporkan pembaruan kemajuan, memungkinkan antarmuka pengguna yang responsif dan pengalaman pengguna yang lebih baik selama tugas yang kompleks.
- **Pembatalan Permintaan**: Klien dapat membatalkan permintaan yang sedang berjalan, memungkinkan pengguna untuk menghentikan operasi yang tidak lagi diperlukan atau memakan waktu terlalu lama.
- **Pelaporan Kesalahan**: Pesan kesalahan dan kode standar membantu mendiagnosis masalah, menangani kegagalan dengan baik, dan memberikan umpan balik yang dapat ditindaklanjuti kepada pengguna dan pengembang.
- **Pencatatan**: Baik klien maupun server dapat mengeluarkan log terstruktur untuk audit, debugging, dan pemantauan interaksi protokol.

Dengan memanfaatkan fitur protokol ini, MCP memastikan komunikasi yang kuat, aman, dan fleksibel antara model bahasa dan alat atau sumber data eksternal.

### 🔐 Pertimbangan Keamanan

Implementasi MCP harus mematuhi beberapa prinsip keamanan utama untuk memastikan interaksi yang aman dan dapat dipercaya:

- **Persetujuan dan Kontrol Pengguna**: Pengguna harus memberikan persetujuan eksplisit sebelum data diakses atau operasi dilakukan. Mereka harus memiliki kontrol yang jelas atas data apa yang dibagikan dan tindakan mana yang diotorisasi, didukung oleh antarmuka pengguna yang intuitif untuk meninjau dan menyetujui aktivitas.

- **Privasi Data**: Data pengguna hanya boleh diekspos dengan persetujuan eksplisit dan harus dilindungi oleh kontrol akses yang sesuai. Implementasi MCP harus melindungi terhadap transmisi data yang tidak sah dan memastikan bahwa privasi dijaga di seluruh interaksi.

- **Keamanan Alat**: Sebelum memanggil alat apa pun, persetujuan pengguna yang eksplisit diperlukan. Pengguna harus memiliki pemahaman yang jelas tentang fungsionalitas setiap alat, dan batasan keamanan yang kuat harus ditegakkan untuk mencegah eksekusi alat yang tidak disengaja atau tidak aman.

Dengan mengikuti prinsip-prinsip ini, MCP memastikan bahwa kepercayaan, privasi, dan keamanan pengguna dijaga di seluruh interaksi protokol.

## Contoh Kode: Komponen Utama

Berikut adalah contoh kode dalam beberapa bahasa pemrograman populer yang menggambarkan cara mengimplementasikan komponen server MCP utama dan alat.

### Contoh .NET: Membuat Server MCP Sederhana dengan Alat

Berikut adalah contoh kode praktis .NET yang menunjukkan cara mengimplementasikan server MCP sederhana dengan alat khusus. Contoh ini menampilkan cara mendefinisikan dan mendaftarkan alat, menangani permintaan, dan menghubungkan server menggunakan Model Context Protocol.

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

Contoh ini menunjukkan pendaftaran server dan alat MCP yang sama seperti contoh .NET di atas, tetapi diimplementasikan dalam Java.

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

Dalam contoh ini, kami menunjukkan cara membangun server MCP dalam Python. Anda juga ditunjukkan dua cara berbeda untuk membuat alat.

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

Contoh ini menunjukkan pembuatan server MCP dalam JavaScript dan menunjukkan cara mendaftarkan dua alat terkait cuaca.

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

Contoh JavaScript ini menunjukkan cara membuat klien MCP yang terhubung ke server, mengirimkan prompt, dan memproses respons termasuk panggilan alat yang dilakukan.

## Keamanan dan Otorisasi

MCP mencakup beberapa konsep dan mekanisme bawaan untuk mengelola keamanan dan otorisasi di seluruh protokol:

1. **Kontrol Izin Alat**:  
  Klien dapat menentukan alat mana yang diizinkan untuk digunakan oleh model selama sesi. Ini memastikan bahwa hanya alat yang diotorisasi secara eksplisit yang dapat diakses, mengurangi risiko operasi yang tidak disengaja atau tidak aman. Izin dapat dikonfigurasi secara dinamis berdasarkan preferensi pengguna, kebijakan organisasi, atau konteks interaksi.

2. **Otentikasi**:  
  Server dapat memerlukan otentikasi sebelum memberikan akses ke alat, sumber daya, atau operasi sensitif. Ini mungkin melibatkan kunci API, token OAuth, atau skema otentikasi lainnya. Otentikasi yang tepat memastikan bahwa hanya klien dan pengguna yang tepercaya dapat memanggil kemampuan sisi server.

3. **Validasi**:  
  Validasi parameter ditegakkan untuk semua pemanggilan alat. Setiap alat mendefinisikan jenis, format, dan batasan yang diharapkan untuk parameternya, dan server memvalidasi permintaan masuk sesuai. Ini mencegah input yang salah atau berbahaya mencapai implementasi alat dan membantu menjaga integritas operasi.

4. **Pembatasan Tingkat**:  
  Untuk mencegah penyalahgunaan dan memastikan penggunaan sumber daya server yang adil, server MCP dapat menerapkan pembatasan tingkat untuk panggilan alat dan akses sumber daya. Pembatasan tingkat dapat diterapkan per pengguna, per sesi, atau secara global, dan membantu melindungi dari serangan denial-of-service atau konsumsi sumber daya yang berlebihan.

Dengan menggabungkan mekanisme ini, MCP menyediakan dasar yang aman untuk mengintegrasikan model bahasa dengan alat dan sumber data eksternal, sambil memberikan kontrol yang terperinci kepada pengguna dan pengembang atas akses dan penggunaan.

## Pesan Protokol

Komunikasi MCP menggunakan pesan JSON terstruktur untuk memfasilitasi interaksi yang jelas dan dapat diandalkan antara klien, server, dan model. Jenis pesan utama termasuk:

- **Permintaan Klien**  
  Dikirim dari klien ke server, pesan ini biasanya mencakup:
  - Prompt atau perintah pengguna
  - Riwayat percakapan untuk konteks
  - Konfigurasi dan izin alat
  - Informasi tambahan atau sesi lainnya

- **Respons Model**  
  Dikembalikan oleh model (melalui klien), pesan ini berisi:
  - Teks atau penyelesaian yang dihasilkan berdasarkan prompt dan konteks
  - Instruksi panggilan alat opsional jika model menentukan bahwa alat harus dipanggil
  - Referensi ke sumber daya atau konteks tambahan sesuai kebutuhan

- **Permintaan Alat**  
  Dikirim dari klien ke server ketika alat perlu dieksekusi. Pesan ini mencakup:
  - Nama alat yang akan dipanggil
  - Parameter yang diperlukan oleh alat (divalidasi terhadap skema alat)
  - Informasi kontekstual atau pengidentifikasi untuk melacak permintaan

- **Respons Alat**  
  Dikembalikan oleh server setelah mengeksekusi alat. Pesan ini menyediakan:
  - Hasil eksekusi alat (data atau konten terstruktur)
  - Kesalahan atau informasi status jika panggilan alat gagal
  - Opsional, metadata tambahan atau log terkait eksekusi

Pesan-pesan terstruktur ini memastikan bahwa setiap langkah dalam alur kerja MCP adalah eksplisit, dapat dilacak, dan dapat diperluas, mendukung skenario lanjutan seperti percakapan multi-putaran, penggabungan alat, dan penanganan kesalahan yang kuat.

## Poin-Poin Penting

- MCP menggunakan arsitektur klien-server untuk menghubungkan model dengan kemampuan eksternal
- Ekosistem terdiri dari klien, host, server,

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan penerjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.