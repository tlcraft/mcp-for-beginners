<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:51:16+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ms"
}
-->
# 📖 Konsep Asas MCP: Menguasai Protokol Konteks Model untuk Integrasi AI

Model Context Protocol (MCP) adalah rangka kerja berstandard yang berkuasa yang mengoptimumkan komunikasi antara Model Bahasa Besar (LLM) dan alat luaran, aplikasi, dan sumber data. Panduan yang dioptimumkan untuk SEO ini akan membawa anda melalui konsep asas MCP, memastikan anda memahami seni bina klien-pelayan, komponen penting, mekanik komunikasi, dan amalan terbaik pelaksanaan.

## Gambaran Keseluruhan

Pelajaran ini meneroka seni bina asas dan komponen yang membentuk ekosistem Model Context Protocol (MCP). Anda akan belajar mengenai seni bina klien-pelayan, komponen utama, dan mekanisme komunikasi yang menggerakkan interaksi MCP.

## 👩‍🎓 Objektif Pembelajaran Utama

Menjelang akhir pelajaran ini, anda akan:

- Memahami seni bina klien-pelayan MCP.
- Mengenal pasti peranan dan tanggungjawab Hos, Klien, dan Pelayan.
- Menganalisis ciri utama yang menjadikan MCP lapisan integrasi yang fleksibel.
- Mempelajari bagaimana maklumat mengalir dalam ekosistem MCP.
- Mendapatkan pandangan praktikal melalui contoh kod dalam .NET, Java, Python, dan JavaScript.

## 🔎 Seni Bina MCP: Pandangan Lebih Mendalam

Ekosistem MCP dibina atas model klien-pelayan. Struktur modular ini membolehkan aplikasi AI berinteraksi dengan alat, pangkalan data, API, dan sumber kontekstual dengan cekap. Mari kita pecahkan seni bina ini kepada komponen terasnya.

### 1. Hos

Dalam Model Context Protocol (MCP), Hos memainkan peranan penting sebagai antara muka utama melalui mana pengguna berinteraksi dengan protokol. Hos adalah aplikasi atau persekitaran yang memulakan sambungan dengan pelayan MCP untuk mengakses data, alat, dan arahan. Contoh Hos termasuk persekitaran pembangunan bersepadu (IDE) seperti Visual Studio Code, alat AI seperti Claude Desktop, atau ejen binaan khas yang direka untuk tugas tertentu.

**Hos** adalah aplikasi LLM yang memulakan sambungan. Mereka:

- Melaksanakan atau berinteraksi dengan model AI untuk menghasilkan respons.
- Memulakan sambungan dengan pelayan MCP.
- Mengurus aliran perbualan dan antara muka pengguna.
- Mengawal kebenaran dan kekangan keselamatan.
- Mengendalikan persetujuan pengguna untuk perkongsian data dan pelaksanaan alat.

### 2. Klien

Klien adalah komponen penting yang memudahkan interaksi antara Hos dan pelayan MCP. Klien bertindak sebagai perantara, membolehkan Hos mengakses dan memanfaatkan fungsi yang disediakan oleh pelayan MCP. Mereka memainkan peranan penting dalam memastikan komunikasi lancar dan pertukaran data yang cekap dalam seni bina MCP.

**Klien** adalah penyambung dalam aplikasi hos. Mereka:

- Menghantar permintaan kepada pelayan dengan arahan/petunjuk.
- Merundingkan keupayaan dengan pelayan.
- Mengurus permintaan pelaksanaan alat dari model.
- Memproses dan memaparkan respons kepada pengguna.

### 3. Pelayan

Pelayan bertanggungjawab mengendalikan permintaan dari klien MCP dan memberikan respons yang sesuai. Mereka mengurus pelbagai operasi seperti pengambilan data, pelaksanaan alat, dan penjanaan arahan. Pelayan memastikan bahawa komunikasi antara klien dan Hos adalah cekap dan boleh dipercayai, mengekalkan integriti proses interaksi.

**Pelayan** adalah perkhidmatan yang menyediakan konteks dan keupayaan. Mereka:

- Mendaftar ciri yang tersedia (sumber, arahan, alat).
- Menerima dan melaksanakan panggilan alat dari klien.
- Memberikan maklumat kontekstual untuk meningkatkan respons model.
- Mengembalikan output kepada klien.
- Mengekalkan keadaan merentas interaksi apabila diperlukan.

Pelayan boleh dibangunkan oleh sesiapa sahaja untuk melanjutkan keupayaan model dengan fungsi khusus.

### 4. Ciri Pelayan

Pelayan dalam Model Context Protocol (MCP) menyediakan blok binaan asas yang membolehkan interaksi kaya antara klien, hos, dan model bahasa. Ciri-ciri ini direka untuk meningkatkan keupayaan MCP dengan menawarkan konteks berstruktur, alat, dan arahan.

Pelayan MCP boleh menawarkan mana-mana ciri berikut:

#### 📑 Sumber

Sumber dalam Model Context Protocol (MCP) merangkumi pelbagai jenis konteks dan data yang boleh digunakan oleh pengguna atau model AI. Ini termasuk:

- **Data Kontekstual**: Maklumat dan konteks yang boleh dimanfaatkan oleh pengguna atau model AI untuk membuat keputusan dan melaksanakan tugas.
- **Pangkalan Pengetahuan dan Repositori Dokumen**: Koleksi data berstruktur dan tidak berstruktur, seperti artikel, manual, dan kertas penyelidikan, yang menyediakan wawasan dan maklumat berharga.
- **Fail Tempatan dan Pangkalan Data**: Data yang disimpan secara tempatan pada peranti atau dalam pangkalan data, boleh diakses untuk pemprosesan dan analisis.
- **API dan Perkhidmatan Web**: Antara muka luaran dan perkhidmatan yang menawarkan data dan fungsi tambahan, membolehkan integrasi dengan pelbagai sumber dan alat dalam talian.

Contoh sumber boleh menjadi skema pangkalan data atau fail yang boleh diakses seperti berikut:

```text
file://log.txt
database://schema
```

### 🤖 Arahan

Arahan dalam Model Context Protocol (MCP) merangkumi pelbagai templat pra-takrif dan corak interaksi yang direka untuk mempermudah aliran kerja pengguna dan meningkatkan komunikasi. Ini termasuk:

- **Mesej dan Aliran Kerja Berstruktur**: Mesej dan proses pra-struktur yang membimbing pengguna melalui tugas dan interaksi tertentu.
- **Corak Interaksi Pra-takrif**: Urutan tindakan dan respons yang standard yang memudahkan komunikasi yang konsisten dan cekap.
- **Templat Perbualan Khusus**: Templat yang boleh disesuaikan yang disesuaikan untuk jenis perbualan tertentu, memastikan interaksi yang relevan dan sesuai dengan konteks.

Templat arahan boleh kelihatan seperti berikut:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alat

Alat dalam Model Context Protocol (MCP) adalah fungsi yang boleh dilaksanakan oleh model AI untuk melaksanakan tugas tertentu. Alat ini direka untuk meningkatkan keupayaan model AI dengan menyediakan operasi yang berstruktur dan boleh dipercayai. Aspek utama termasuk:

- **Fungsi untuk Dilaksanakan oleh Model AI**: Alat adalah fungsi yang boleh dilaksanakan yang boleh dipanggil oleh model AI untuk melaksanakan pelbagai tugas.
- **Nama dan Penerangan Unik**: Setiap alat mempunyai nama yang berbeza dan penerangan terperinci yang menerangkan tujuannya dan fungsinya.
- **Parameter dan Output**: Alat menerima parameter tertentu dan mengembalikan output berstruktur, memastikan hasil yang konsisten dan boleh diramalkan.
- **Fungsi Diskret**: Alat melaksanakan fungsi diskret seperti carian web, pengiraan, dan pertanyaan pangkalan data.

Contoh alat boleh kelihatan seperti berikut:

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

## Ciri Klien

Dalam Model Context Protocol (MCP), klien menawarkan beberapa ciri utama kepada pelayan, meningkatkan fungsi keseluruhan dan interaksi dalam protokol. Salah satu ciri yang ketara ialah Sampling.

### 👉 Sampling

- **Perilaku Agenik yang Dimulakan oleh Pelayan**: Klien membolehkan pelayan memulakan tindakan atau perilaku tertentu secara autonomi, meningkatkan keupayaan dinamik sistem.
- **Interaksi LLM Rekursif**: Ciri ini membolehkan interaksi rekursif dengan model bahasa besar (LLM), membolehkan pemprosesan tugas yang lebih kompleks dan berulang.
- **Meminta Penyelesaian Model Tambahan**: Pelayan boleh meminta penyelesaian tambahan dari model, memastikan respons yang menyeluruh dan relevan dengan konteks.

## Aliran Maklumat dalam MCP

Model Context Protocol (MCP) mendefinisikan aliran maklumat yang berstruktur antara hos, klien, pelayan, dan model. Memahami aliran ini membantu menjelaskan bagaimana permintaan pengguna diproses dan bagaimana alat dan data luaran diintegrasikan ke dalam respons model.

- **Hos Memulakan Sambungan**  
  Aplikasi hos (seperti IDE atau antara muka sembang) membentuk sambungan ke pelayan MCP, biasanya melalui STDIO, WebSocket, atau pengangkutan lain yang disokong.

- **Rundingan Keupayaan**  
  Klien (tertanam dalam hos) dan pelayan bertukar maklumat tentang ciri yang disokong, alat, sumber, dan versi protokol. Ini memastikan kedua-dua pihak memahami keupayaan yang tersedia untuk sesi tersebut.

- **Permintaan Pengguna**  
  Pengguna berinteraksi dengan hos (contohnya, memasukkan arahan atau perintah). Hos mengumpulkan input ini dan menyerahkannya kepada klien untuk diproses.

- **Penggunaan Sumber atau Alat**  
  - Klien mungkin meminta konteks atau sumber tambahan dari pelayan (seperti fail, entri pangkalan data, atau artikel pangkalan pengetahuan) untuk memperkaya pemahaman model.
  - Jika model menentukan bahawa alat diperlukan (contohnya, untuk mendapatkan data, melaksanakan pengiraan, atau memanggil API), klien menghantar permintaan panggilan alat kepada pelayan, menentukan nama alat dan parameter.

- **Pelaksanaan Pelayan**  
  Pelayan menerima permintaan sumber atau alat, melaksanakan operasi yang diperlukan (seperti menjalankan fungsi, membuat pertanyaan pangkalan data, atau mendapatkan fail), dan mengembalikan hasil kepada klien dalam format berstruktur.

- **Penjanaan Respons**  
  Klien mengintegrasikan respons pelayan (data sumber, output alat, dll.) ke dalam interaksi model yang sedang berlangsung. Model menggunakan maklumat ini untuk menghasilkan respons yang menyeluruh dan relevan dengan konteks.

- **Pembentangan Hasil**  
  Hos menerima output akhir dari klien dan menyampaikannya kepada pengguna, sering kali termasuk teks yang dihasilkan oleh model dan sebarang hasil dari pelaksanaan alat atau pencarian sumber.

Aliran ini membolehkan MCP menyokong aplikasi AI yang maju, interaktif, dan sedar konteks dengan menghubungkan model dengan alat dan sumber data luaran secara lancar.

## Butiran Protokol

MCP (Model Context Protocol) dibina di atas [JSON-RPC 2.0](https://www.jsonrpc.org/), menyediakan format mesej yang berstandard, bebas bahasa untuk komunikasi antara hos, klien, dan pelayan. Asas ini membolehkan interaksi yang boleh dipercayai, berstruktur, dan boleh diperluas merentas platform dan bahasa pengaturcaraan yang pelbagai.

### Ciri Protokol Utama

MCP memperluas JSON-RPC 2.0 dengan konvensyen tambahan untuk panggilan alat, akses sumber, dan pengurusan arahan. Ia menyokong pelbagai lapisan pengangkutan (STDIO, WebSocket, SSE) dan membolehkan komunikasi yang selamat, boleh diperluas, dan bebas bahasa antara komponen.

#### 🧢 Protokol Asas

- **Format Mesej JSON-RPC**: Semua permintaan dan respons menggunakan spesifikasi JSON-RPC 2.0, memastikan struktur yang konsisten untuk panggilan kaedah, parameter, hasil, dan pengendalian ralat.
- **Sambungan Berkeadaan**: Sesi MCP mengekalkan keadaan merentas pelbagai permintaan, menyokong perbualan yang sedang berlangsung, pengumpulan konteks, dan pengurusan sumber.
- **Rundingan Keupayaan**: Semasa penyediaan sambungan, klien dan pelayan bertukar maklumat tentang ciri yang disokong, versi protokol, alat yang tersedia, dan sumber. Ini memastikan kedua-dua pihak memahami keupayaan masing-masing dan boleh menyesuaikan diri dengan sewajarnya.

#### ➕ Utiliti Tambahan

Di bawah adalah beberapa utiliti tambahan dan peluasan protokol yang MCP sediakan untuk meningkatkan pengalaman pembangun dan membolehkan senario lanjutan:

- **Pilihan Konfigurasi**: MCP membolehkan konfigurasi dinamik parameter sesi, seperti kebenaran alat, akses sumber, dan tetapan model, disesuaikan untuk setiap interaksi.
- **Penjejakan Kemajuan**: Operasi jangka panjang boleh melaporkan kemas kini kemajuan, membolehkan antara muka pengguna yang responsif dan pengalaman pengguna yang lebih baik semasa tugas yang kompleks.
- **Pembatalan Permintaan**: Klien boleh membatalkan permintaan yang sedang dalam perjalanan, membolehkan pengguna menghentikan operasi yang tidak lagi diperlukan atau mengambil masa terlalu lama.
- **Pelaporan Ralat**: Mesej ralat dan kod standard membantu mendiagnosis isu, mengendalikan kegagalan dengan anggun, dan menyediakan maklum balas yang boleh diambil tindakan kepada pengguna dan pembangun.
- **Pembalakan**: Kedua-dua klien dan pelayan boleh mengeluarkan log berstruktur untuk audit, penyahpepijatan, dan pemantauan interaksi protokol.

Dengan memanfaatkan ciri protokol ini, MCP memastikan komunikasi yang kukuh, selamat, dan fleksibel antara model bahasa dan alat luaran atau sumber data.

### 🔐 Pertimbangan Keselamatan

Pelaksanaan MCP harus mematuhi beberapa prinsip keselamatan utama untuk memastikan interaksi yang selamat dan boleh dipercayai:

- **Persetujuan dan Kawalan Pengguna**: Pengguna mesti memberikan persetujuan eksplisit sebelum sebarang data diakses atau operasi dilakukan. Mereka harus mempunyai kawalan yang jelas terhadap data yang dikongsi dan tindakan yang dibenarkan, disokong oleh antara muka pengguna yang intuitif untuk menyemak dan meluluskan aktiviti.

- **Privasi Data**: Data pengguna hanya boleh didedahkan dengan persetujuan eksplisit dan mesti dilindungi oleh kawalan akses yang sesuai. Pelaksanaan MCP mesti melindungi terhadap penghantaran data yang tidak dibenarkan dan memastikan bahawa privasi dikekalkan sepanjang semua interaksi.

- **Keselamatan Alat**: Sebelum memanggil sebarang alat, persetujuan pengguna yang jelas diperlukan. Pengguna harus mempunyai pemahaman yang jelas tentang fungsi setiap alat, dan sempadan keselamatan yang kukuh mesti dikuatkuasakan untuk mencegah pelaksanaan alat yang tidak diingini atau tidak selamat.

Dengan mengikuti prinsip-prinsip ini, MCP memastikan bahawa kepercayaan pengguna, privasi, dan keselamatan dikekalkan merentas semua interaksi protokol.

## Contoh Kod: Komponen Utama

Di bawah adalah contoh kod dalam beberapa bahasa pengaturcaraan popular yang menggambarkan cara melaksanakan komponen pelayan MCP utama dan alat.

### Contoh .NET: Mencipta Pelayan MCP Mudah dengan Alat

Berikut adalah contoh kod .NET praktikal yang menunjukkan cara melaksanakan pelayan MCP mudah dengan alat khusus. Contoh ini memaparkan cara mentakrif dan mendaftarkan alat, mengendalikan permintaan, dan menyambungkan pelayan menggunakan Model Context Protocol.

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

### Contoh Java: Komponen Pelayan MCP

Contoh ini menunjukkan pendaftaran pelayan dan alat MCP yang sama seperti contoh .NET di atas, tetapi dilaksanakan dalam Java.

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

### Contoh Python: Membina Pelayan MCP

Dalam contoh ini, kami menunjukkan cara membina pelayan MCP dalam Python. Anda juga ditunjukkan dua cara berbeza untuk mencipta alat.

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

### Contoh JavaScript: Mencipta Pelayan MCP

Contoh ini menunjukkan penciptaan pelayan MCP dalam JavaScript dan menunjukkan cara mendaftarkan dua alat berkaitan cuaca.

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

Contoh JavaScript ini menunjukkan cara mencipta klien MCP yang menyambung ke pelayan, menghantar arahan, dan memproses respons termasuk sebarang panggilan alat yang dibuat.

## Keselamatan dan Kebenaran

MCP merangkumi beberapa konsep dan mekanisme terbina untuk mengurus keselamatan dan kebenaran sepanjang protokol:

1. **Kawalan Kebenaran Alat**:  
  Klien boleh menentukan alat mana yang dibenarkan untuk digunakan oleh model semasa sesi. Ini memastikan hanya alat yang dibenarkan secara eksplisit boleh diakses, mengurangkan risiko operasi yang tidak diingini atau tidak selamat. Kebenaran boleh dikonfigurasikan secara dinamik berdasarkan keutamaan pengguna, dasar organisasi, atau konteks interaksi.

2. **Pengesahan**:  
  Pelayan boleh memerlukan pengesahan sebelum memberikan akses kepada alat, sumber, atau operasi sensitif. Ini mungkin melibatkan kunci API, token OAuth, atau skim pengesahan lain. Pengesahan yang betul memastikan bahawa hanya klien dan pengguna yang dipercayai boleh memanggil keupayaan pelayan.

3. **Pengesahan**:  
  Pengesahan parameter dikuatkuasakan untuk semua panggilan alat. Setiap alat mentakrifkan jenis, format, dan kekangan yang dijangkakan untuk parameternya, dan pelayan mengesahkan permintaan masuk dengan sewajarnya. Ini mencegah input yang tidak sah atau berniat jahat daripada mencapai pelaksanaan alat dan membantu mengekalkan integriti operasi.

4. **Pengehadan Kadar**:  
  Untuk mencegah penyalahgunaan dan memastikan penggunaan sumber pelayan yang adil, pelayan MCP boleh melaksanakan pengehadan kadar untuk panggilan alat dan akses sumber. Had kadar boleh dikenakan setiap pengguna, setiap sesi, atau secara global, dan membantu melindungi daripada serangan penafian perkhidmatan atau penggunaan sumber yang berlebihan.

Dengan menggabungkan mekanisme ini, MCP menyediakan asas yang selamat untuk mengintegrasikan model bahasa dengan alat dan sumber data luaran, sambil memberikan pengguna dan pembangun kawalan yang halus terhadap akses dan penggunaan.

## Mesej Protokol

Komunikasi MCP menggunakan mesej JSON berstruktur untuk memudahkan interaksi yang jelas dan boleh dipercayai antara klien, pelayan, dan model. Jenis mesej utama termasuk:

- **Permintaan Klien**  
  Dihantar dari klien ke pelayan, mesej ini biasanya merangkumi:
  - Arahan atau perintah pengguna
  - Sejarah perbualan untuk konteks
  - Konfigurasi alat dan kebenaran
  - Sebarang metadata tambahan atau maklumat sesi

- **Respons Model**  
  Dikembalikan oleh model (melalui klien), mesej ini mengandungi:
  - Teks yang dijana atau penyelesaian berdasarkan arahan dan konteks
  - Arahan panggilan alat opsional jika model menentukan alat harus dipanggil
  - Rujukan kepada sumber atau konte

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.