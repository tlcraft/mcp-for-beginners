<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b3b4a6ad10c3c0edbf7fa7cfa0ec496b",
  "translation_date": "2025-07-02T07:26:02+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ms"
}
-->
# 📖 Konsep Teras MCP: Menguasai Model Context Protocol untuk Integrasi AI

[Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) adalah rangka kerja standard yang kukuh yang mengoptimumkan komunikasi antara Large Language Models (LLMs) dan alat luaran, aplikasi, serta sumber data. Panduan yang dioptimumkan untuk SEO ini akan membawa anda memahami konsep teras MCP, memastikan anda faham tentang seni bina klien-pelayan, komponen penting, mekanisme komunikasi, dan amalan terbaik pelaksanaan.

## Gambaran Keseluruhan

Pelajaran ini meneroka seni bina asas dan komponen yang membentuk ekosistem Model Context Protocol (MCP). Anda akan mempelajari seni bina klien-pelayan, komponen utama, dan mekanisme komunikasi yang menggerakkan interaksi MCP.

## 👩‍🎓 Objektif Pembelajaran Utama

Pada akhir pelajaran ini, anda akan:

- Memahami seni bina klien-pelayan MCP.
- Mengenal pasti peranan dan tanggungjawab Hosts, Clients, dan Servers.
- Menganalisis ciri teras yang menjadikan MCP lapisan integrasi yang fleksibel.
- Mempelajari aliran maklumat dalam ekosistem MCP.
- Mendapatkan pandangan praktikal melalui contoh kod dalam .NET, Java, Python, dan JavaScript.

## 🔎 Seni Bina MCP: Pandangan Mendalam

Ekosistem MCP dibina atas model klien-pelayan. Struktur modular ini membolehkan aplikasi AI berinteraksi dengan alat, pangkalan data, API, dan sumber konteks dengan cekap. Mari kita pecahkan seni bina ini kepada komponen utamanya.

Pada asasnya, MCP mengikuti seni bina klien-pelayan di mana aplikasi host boleh berhubung dengan pelbagai pelayan:

```mermaid
flowchart LR
    subgraph "Your Computer"
        Host["Host with MCP VScode, IDEs, Tools)"]
        S1["MCP Server A"]
        S2["MCP Server B"]
        S3["MCP Server C"]
        Host <-->|"MCP Protocol"| S1
        Host <-->|"MCP Protocol"| S2
        Host <-->|"MCP Protocol"| S3
        S1 <--> D1[("Local\Data Source A")]
        S2 <--> D2[("Local\Data Source B")]
    end
    subgraph "Internet"
        S3 <-->|"Web APIs"| D3[("Remote\Services")]
    end
```

- **MCP Hosts**: Program seperti VSCode, Claude Desktop, IDE, atau alat AI yang ingin mengakses data melalui MCP
- **MCP Clients**: Klien protokol yang mengekalkan sambungan 1:1 dengan pelayan
- **MCP Servers**: Program ringan yang masing-masing menyediakan keupayaan tertentu melalui Model Context Protocol yang distandardkan
- **Local Data Sources**: Fail, pangkalan data, dan perkhidmatan pada komputer anda yang boleh diakses dengan selamat oleh pelayan MCP
- **Remote Services**: Sistem luaran yang tersedia melalui internet yang boleh dihubungkan oleh pelayan MCP melalui API.

Protokol MCP adalah standard yang sedang berkembang dan anda boleh melihat kemas kini terkini pada [spesifikasi protokol](https://modelcontextprotocol.io/specification/2025-06-18/)

### 1. Hosts

Dalam Model Context Protocol (MCP), Hosts memainkan peranan penting sebagai antara muka utama di mana pengguna berinteraksi dengan protokol. Hosts adalah aplikasi atau persekitaran yang memulakan sambungan dengan pelayan MCP untuk mengakses data, alat, dan arahan. Contoh Hosts termasuk persekitaran pembangunan bersepadu (IDEs) seperti Visual Studio Code, alat AI seperti Claude Desktop, atau agen khusus yang dibina untuk tugasan tertentu.

**Hosts** adalah aplikasi LLM yang memulakan sambungan. Mereka:

- Melaksanakan atau berinteraksi dengan model AI untuk menghasilkan respons.
- Memulakan sambungan dengan pelayan MCP.
- Mengurus aliran perbualan dan antara muka pengguna.
- Mengawal kebenaran dan sekatan keselamatan.
- Mengendalikan persetujuan pengguna untuk perkongsian data dan pelaksanaan alat.

### 2. Clients

Clients adalah komponen penting yang memudahkan interaksi antara Hosts dan pelayan MCP. Clients bertindak sebagai perantara, membolehkan Hosts mengakses dan menggunakan fungsi yang disediakan oleh pelayan MCP. Mereka memainkan peranan penting dalam memastikan komunikasi lancar dan pertukaran data yang efisien dalam seni bina MCP.

**Clients** adalah penyambung dalam aplikasi host. Mereka:

- Menghantar permintaan kepada pelayan dengan arahan/arah.
- Merundingkan keupayaan dengan pelayan.
- Mengurus permintaan pelaksanaan alat daripada model.
- Memproses dan memaparkan respons kepada pengguna.

### 3. Servers

Servers bertanggungjawab mengendalikan permintaan daripada klien MCP dan memberikan respons yang sesuai. Mereka mengurus pelbagai operasi seperti pengambilan data, pelaksanaan alat, dan penjanaan arahan. Servers memastikan komunikasi antara klien dan Hosts berjalan dengan cekap dan boleh dipercayai, mengekalkan integriti proses interaksi.

**Servers** adalah perkhidmatan yang menyediakan konteks dan keupayaan. Mereka:

- Mendaftar ciri tersedia (sumber, arahan, alat)
- Menerima dan melaksanakan panggilan alat daripada klien
- Menyediakan maklumat konteks untuk meningkatkan respons model
- Mengembalikan output kepada klien
- Mengekalkan keadaan sepanjang interaksi apabila diperlukan

Servers boleh dibangunkan oleh sesiapa sahaja untuk memperluaskan keupayaan model dengan fungsi khusus.

### 4. Ciri Pelayan

Servers dalam Model Context Protocol (MCP) menyediakan blok binaan asas yang membolehkan interaksi kaya antara klien, host, dan model bahasa. Ciri-ciri ini direka untuk meningkatkan keupayaan MCP dengan menawarkan konteks berstruktur, alat, dan arahan.

Pelayan MCP boleh menawarkan mana-mana ciri berikut:

#### 📑 Sumber

Sumber dalam Model Context Protocol (MCP) merangkumi pelbagai jenis konteks dan data yang boleh digunakan oleh pengguna atau model AI. Ini termasuk:

- **Data Kontekstual**: Maklumat dan konteks yang boleh dimanfaatkan oleh pengguna atau model AI untuk membuat keputusan dan melaksanakan tugasan.
- **Pangkalan Pengetahuan dan Repositori Dokumen**: Koleksi data berstruktur dan tidak berstruktur, seperti artikel, manual, dan kertas penyelidikan, yang menyediakan pandangan dan maklumat berharga.
- **Fail Tempatan dan Pangkalan Data**: Data yang disimpan secara tempatan pada peranti atau dalam pangkalan data, boleh diakses untuk pemprosesan dan analisis.
- **API dan Perkhidmatan Web**: Antara muka dan perkhidmatan luaran yang menawarkan data dan fungsi tambahan, membolehkan integrasi dengan pelbagai sumber dan alat dalam talian.

Contoh sumber boleh berupa skema pangkalan data atau fail yang boleh diakses seperti berikut:

```text
file://log.txt
database://schema
```

### 🤖 Arahan

Arahan dalam Model Context Protocol (MCP) termasuk pelbagai templat dan corak interaksi yang telah ditetapkan untuk mempermudah aliran kerja pengguna dan meningkatkan komunikasi. Ini termasuk:

- **Mesej dan Aliran Kerja Bertemplated**: Mesej dan proses yang telah distrukturkan untuk membimbing pengguna melalui tugasan dan interaksi tertentu.
- **Corak Interaksi Pra-Tetap**: Urutan tindakan dan respons yang distandardkan untuk memudahkan komunikasi yang konsisten dan efisien.
- **Templat Perbualan Khusus**: Templat yang boleh disesuaikan untuk jenis perbualan tertentu, memastikan interaksi yang relevan dan sesuai konteks.

Templat arahan boleh kelihatan seperti berikut:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alat

Alat dalam Model Context Protocol (MCP) adalah fungsi yang boleh dilaksanakan oleh model AI untuk melaksanakan tugasan tertentu. Alat ini direka untuk meningkatkan keupayaan model AI dengan menyediakan operasi yang terstruktur dan boleh dipercayai. Aspek utama termasuk:

- **Fungsi untuk model AI laksanakan**: Alat adalah fungsi yang boleh dilaksanakan yang boleh dipanggil oleh model AI untuk melaksanakan pelbagai tugasan.
- **Nama dan Penerangan Unik**: Setiap alat mempunyai nama yang berbeza dan penerangan terperinci yang menerangkan tujuan dan fungsinya.
- **Parameter dan Output**: Alat menerima parameter tertentu dan mengembalikan output berstruktur, memastikan hasil yang konsisten dan boleh diramal.
- **Fungsi Diskret**: Alat melaksanakan fungsi diskret seperti carian web, pengiraan, dan pertanyaan pangkalan data.

Contoh alat boleh kelihatan seperti berikut:

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

## Ciri Klien

Dalam Model Context Protocol (MCP), klien menawarkan beberapa ciri utama kepada pelayan, meningkatkan fungsi dan interaksi keseluruhan dalam protokol. Salah satu ciri penting adalah Sampling.

### 👉 Sampling

- **Kelakuan Agen Inisiatif Pelayan**: Klien membolehkan pelayan memulakan tindakan atau kelakuan tertentu secara autonomi, meningkatkan keupayaan dinamik sistem.
- **Interaksi LLM Berulang**: Ciri ini membolehkan interaksi berulang dengan large language models (LLMs), membolehkan pemprosesan tugasan yang lebih kompleks dan berulang.
- **Meminta Penyempurnaan Model Tambahan**: Pelayan boleh meminta penyempurnaan tambahan daripada model, memastikan respons yang lengkap dan sesuai konteks.

## Aliran Maklumat dalam MCP

Model Context Protocol (MCP) mentakrifkan aliran maklumat berstruktur antara host, klien, pelayan, dan model. Memahami aliran ini membantu menjelaskan bagaimana permintaan pengguna diproses dan bagaimana alat serta data luaran diintegrasikan ke dalam respons model.

- **Host Memulakan Sambungan**  
  Aplikasi host (seperti IDE atau antara muka chat) mewujudkan sambungan ke pelayan MCP, biasanya melalui STDIO, WebSocket, atau pengangkutan yang disokong lain.

- **Perundingan Keupayaan**  
  Klien (terbenam dalam host) dan pelayan bertukar maklumat mengenai ciri, alat, sumber, dan versi protokol yang disokong. Ini memastikan kedua-dua pihak faham keupayaan yang tersedia untuk sesi tersebut.

- **Permintaan Pengguna**  
  Pengguna berinteraksi dengan host (contohnya, memasukkan arahan atau prompt). Host mengumpulkan input ini dan menghantarnya ke klien untuk diproses.

- **Penggunaan Sumber atau Alat**  
  - Klien mungkin meminta konteks tambahan atau sumber dari pelayan (seperti fail, entri pangkalan data, atau artikel pangkalan pengetahuan) untuk memperkayakan pemahaman model.
  - Jika model menentukan bahawa alat diperlukan (contohnya, untuk mendapatkan data, melakukan pengiraan, atau memanggil API), klien menghantar permintaan pelaksanaan alat kepada pelayan, menyatakan nama alat dan parameter.

- **Pelaksanaan Pelayan**  
  Pelayan menerima permintaan sumber atau alat, melaksanakan operasi yang diperlukan (seperti menjalankan fungsi, membuat pertanyaan pangkalan data, atau mengambil fail), dan mengembalikan hasil kepada klien dalam format berstruktur.

- **Penjanaan Respons**  
  Klien menggabungkan respons pelayan (data sumber, output alat, dan lain-lain) ke dalam interaksi model yang sedang berjalan. Model menggunakan maklumat ini untuk menghasilkan respons yang komprehensif dan sesuai konteks.

- **Pembentangan Keputusan**  
  Host menerima output akhir dari klien dan membentangkannya kepada pengguna, sering kali termasuk teks yang dijana oleh model dan apa-apa hasil dari pelaksanaan alat atau pencarian sumber.

Aliran ini membolehkan MCP menyokong aplikasi AI yang maju, interaktif, dan peka konteks dengan menghubungkan model dengan alat luaran dan sumber data secara lancar.

## Butiran Protokol

MCP (Model Context Protocol) dibina di atas [JSON-RPC 2.0](https://www.jsonrpc.org/), menyediakan format mesej standard dan bebas bahasa untuk komunikasi antara host, klien, dan pelayan. Asas ini membolehkan interaksi yang boleh dipercayai, berstruktur, dan boleh diperluaskan merentas pelbagai platform dan bahasa pengaturcaraan.

### Ciri Protokol Utama

MCP memperluaskan JSON-RPC 2.0 dengan konvensyen tambahan untuk pelaksanaan alat, akses sumber, dan pengurusan arahan. Ia menyokong pelbagai lapisan pengangkutan (STDIO, WebSocket, SSE) dan membolehkan komunikasi yang selamat, boleh diperluaskan, dan bebas bahasa antara komponen.

#### 🧢 Protokol Asas

- **Format Mesej JSON-RPC**: Semua permintaan dan respons menggunakan spesifikasi JSON-RPC 2.0, memastikan struktur konsisten untuk panggilan kaedah, parameter, hasil, dan pengendalian ralat.
- **Sambungan Berkeadaan**: Sesi MCP mengekalkan keadaan merentasi pelbagai permintaan, menyokong perbualan berterusan, pengumpulan konteks, dan pengurusan sumber.
- **Perundingan Keupayaan**: Semasa penyediaan sambungan, klien dan pelayan bertukar maklumat mengenai ciri yang disokong, versi protokol, alat dan sumber yang tersedia. Ini memastikan kedua-dua pihak memahami keupayaan masing-masing dan boleh menyesuaikan diri dengan sewajarnya.

#### ➕ Utiliti Tambahan

Berikut adalah beberapa utiliti tambahan dan peluasan protokol yang disediakan MCP untuk meningkatkan pengalaman pembangun dan membolehkan senario lanjutan:

- **Pilihan Konfigurasi**: MCP membenarkan konfigurasi dinamik parameter sesi, seperti kebenaran alat, akses sumber, dan tetapan model, yang disesuaikan untuk setiap interaksi.
- **Penjejakan Kemajuan**: Operasi jangka panjang boleh melaporkan kemas kini kemajuan, membolehkan antara muka pengguna responsif dan pengalaman pengguna yang lebih baik semasa tugasan kompleks.
- **Pembatalan Permintaan**: Klien boleh membatalkan permintaan yang sedang berjalan, membolehkan pengguna menghentikan operasi yang tidak lagi diperlukan atau mengambil masa terlalu lama.
- **Laporan Ralat**: Mesej ralat dan kod standard membantu mendiagnosis isu, mengendalikan kegagalan dengan baik, dan memberikan maklum balas yang berguna kepada pengguna dan pembangun.
- **Logging**: Kedua-dua klien dan pelayan boleh mengeluarkan log berstruktur untuk audit, debugging, dan pemantauan interaksi protokol.

Dengan memanfaatkan ciri protokol ini, MCP memastikan komunikasi yang mantap, selamat, dan fleksibel antara model bahasa dan alat atau sumber data luaran.

### 🔐 Pertimbangan Keselamatan

Pelaksanaan MCP harus mematuhi beberapa prinsip keselamatan utama untuk memastikan interaksi yang selamat dan boleh dipercayai:

- **Persetujuan dan Kawalan Pengguna**: Pengguna mesti memberikan persetujuan jelas sebelum sebarang data diakses atau operasi dijalankan. Mereka harus mempunyai kawalan yang jelas terhadap data yang dikongsi dan tindakan yang dibenarkan, disokong oleh antara muka pengguna yang intuitif untuk menyemak dan meluluskan aktiviti.

- **Privasi Data**: Data pengguna hanya boleh didedahkan dengan persetujuan jelas dan mesti dilindungi oleh kawalan akses yang sesuai. Pelaksanaan MCP mesti melindungi daripada penghantaran data tanpa kebenaran dan memastikan privasi terjaga sepanjang interaksi.

- **Keselamatan Alat**: Sebelum memanggil mana-mana alat, persetujuan jelas pengguna diperlukan. Pengguna harus memahami fungsi setiap alat dengan jelas, dan sempadan keselamatan yang kukuh mesti dikuatkuasakan untuk mengelakkan pelaksanaan alat yang tidak diingini atau tidak selamat.

Dengan mengikuti prinsip ini, MCP memastikan kepercayaan, privasi, dan keselamatan pengguna terpelihara sepanjang interaksi protokol.

## Contoh Kod: Komponen Utama

Berikut adalah contoh kod dalam beberapa bahasa pengaturcaraan popular yang menunjukkan cara melaksanakan komponen pelayan MCP utama dan alat.

### Contoh .NET: Membina Pelayan MCP Mudah dengan Alat

Berikut adalah contoh kod .NET praktikal yang menunjukkan cara melaksanakan pelayan MCP mudah dengan alat tersuai. Contoh ini mempamerkan cara mentakrif dan mendaftar alat, mengendalikan permintaan, dan menyambungkan pelayan menggunakan Model Context Protocol.

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

Contoh ini menunjukkan pelayan MCP dan pendaftaran alat yang sama seperti contoh .NET di atas, tetapi dilaksanakan dalam Java.

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

Dalam contoh ini kami tunjukkan cara membina pelayan MCP dalam Python. Anda juga akan ditunjukkan dua cara berbeza untuk mencipta alat.

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

### Contoh JavaScript: Membina Pelayan MCP

Contoh ini menunjukkan penciptaan pelayan MCP dalam JavaScript dan cara mendaftar dua alat berkaitan cuaca.

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

Contoh JavaScript ini menunjukkan cara membuat klien MCP yang menyambung ke pelayan, menghantar arahan, dan memproses respons termasuk sebarang panggilan alat yang dibuat.

## Keselamatan dan Kebenaran

MCP merangkumi beberapa konsep dan mekanisme terbina dalam untuk mengurus keselamatan dan kebenaran sepanjang protokol:

1. **Kawalan Kebenaran Alat**:  
  Klien boleh menentukan alat mana yang dibenarkan digunakan oleh model semasa sesi. Ini memastikan hanya alat yang diberi kebenaran secara eksplisit boleh diakses, mengurangkan risiko operasi yang tidak diingini atau tidak selamat. Kebenaran boleh dikonfigurasikan secara dinamik berdasarkan keutamaan pengguna, polisi organisasi, atau konteks interaksi.

2. **Pengesahan**:  
  Pelayan boleh memerlukan pengesahan sebelum memberi akses kepada alat, sumber, atau operasi sensitif. Ini mungkin melibatkan kunci API, token OAuth, atau skema pengesahan lain. Pengesahan yang betul memastikan hanya klien dan pengguna yang dipercayai boleh memanggil keupayaan pelayan.

3. **Pengesahan Parameter**:  
  Pengesahan parameter dikuatkuasakan untuk semua panggilan alat. Setiap alat mentakrifkan jenis, format, dan kekangan yang dijangka untuk parameternya, dan pelayan mengesahkan permintaan yang diterima dengan sewajarnya. Ini mengelakkan input yang tidak sah atau berniat jahat sampai ke pelaksanaan alat dan membantu mengekalkan integriti operasi.

4. **Had Kadar**:  
  Untuk mengelakkan penyalahgunaan dan memastikan penggunaan sumber pelayan yang adil, pelayan MCP boleh melaksanakan had kadar untuk panggilan alat dan akses sumber. Had kadar boleh dikenakan per pengguna, per sesi, atau secara global, dan membantu melindungi daripada serangan penafian perkhidmatan atau penggunaan sumber yang berlebihan.

Dengan menggabungkan mekanisme ini, MCP menyediakan asas yang selamat untuk mengintegrasikan model bahasa dengan alat dan sumber data luaran, sambil memberi pengguna dan pembangun kawalan terperinci ke atas akses dan penggunaan.

## Mesej Protokol

Komunikasi MCP menggunakan mesej JSON berstruktur untuk memudahkan interaksi yang jelas dan boleh dipercay

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.