<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T21:28:28+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tr"
}
-->
# 📖 MCP Temel Kavramları: AI Entegrasyonu için Model Context Protocol’ü Ustaca Kullanma

Model Context Protocol (MCP), Büyük Dil Modelleri (LLM’ler) ile dış araçlar, uygulamalar ve veri kaynakları arasındaki iletişimi optimize eden güçlü ve standart bir çerçevedir. Bu SEO uyumlu rehber, MCP’nin temel kavramlarını adım adım açıklayarak, istemci-sunucu mimarisini, temel bileşenlerini, iletişim mekanizmalarını ve uygulama en iyi uygulamalarını anlamanızı sağlar.

## Genel Bakış

Bu ders, Model Context Protocol (MCP) ekosistemini oluşturan temel mimariyi ve bileşenleri inceler. MCP etkileşimlerini güçlendiren istemci-sunucu mimarisi, ana bileşenler ve iletişim mekanizmaları hakkında bilgi edineceksiniz.

## 👩‍🎓 Temel Öğrenme Hedefleri

Bu dersin sonunda:

- MCP istemci-sunucu mimarisini anlayacaksınız.
- Host’ların, Client’ların ve Server’ların rollerini ve sorumluluklarını tanımlayacaksınız.
- MCP’yi esnek bir entegrasyon katmanı yapan temel özellikleri analiz edeceksiniz.
- MCP ekosisteminde bilgi akışını öğreneceksiniz.
- .NET, Java, Python ve JavaScript ile kod örnekleri üzerinden pratik bilgiler kazanacaksınız.

## 🔎 MCP Mimarisi: Daha Derin Bir Bakış

MCP ekosistemi istemci-sunucu modeli üzerine kuruludur. Bu modüler yapı, AI uygulamalarının araçlar, veri tabanları, API’ler ve bağlamsal kaynaklarla verimli şekilde etkileşim kurmasını sağlar. Bu mimariyi temel bileşenlerine ayıralım.

### 1. Hosts

Model Context Protocol (MCP) içinde Host’lar, kullanıcıların protokolle etkileşime geçtiği birincil arayüz olarak kritik bir rol oynar. Host’lar, MCP sunucularıyla bağlantı kurarak veri, araç ve istemlere erişim sağlayan uygulamalar veya ortamlar olarak tanımlanır. Host örnekleri arasında Visual Studio Code gibi entegre geliştirme ortamları (IDE’ler), Claude Desktop gibi AI araçları veya belirli görevler için özel olarak tasarlanmış ajanlar bulunur.

**Host’lar**, bağlantı başlatan LLM uygulamalarıdır. Bunlar:

- Yanıt üretmek için AI modellerini çalıştırır veya onlarla etkileşime girer.
- MCP sunucularıyla bağlantı başlatır.
- Konuşma akışını ve kullanıcı arayüzünü yönetir.
- İzin ve güvenlik kısıtlamalarını kontrol eder.
- Veri paylaşımı ve araç çalıştırma için kullanıcı onayını yönetir.

### 2. Clients

Client’lar, Host’lar ile MCP sunucuları arasındaki etkileşimi kolaylaştıran temel bileşenlerdir. Client’lar, Host’ların MCP sunucularının sunduğu işlevlere erişmesini ve kullanmasını sağlayan aracı görevi görür. MCP mimarisinde sorunsuz iletişim ve verimli veri alışverişini garanti ederler.

**Client’lar**, host uygulaması içindeki bağlantı noktalarıdır. Bunlar:

- Sunuculara istemler (promptlar/talimatlar) gönderir.
- Sunucularla yetenek müzakeresi yapar.
- Modellerden gelen araç çalıştırma taleplerini yönetir.
- Yanıtları işler ve kullanıcıya gösterir.

### 3. Servers

Server’lar, MCP client’larından gelen talepleri karşılamak ve uygun yanıtları sağlamakla sorumludur. Veri alma, araç çalıştırma ve istem oluşturma gibi çeşitli işlemleri yönetirler. Client’lar ile Host’lar arasındaki iletişimin verimli ve güvenilir olmasını sağlar, etkileşim sürecinin bütünlüğünü korur.

**Server’lar**, bağlam ve yetenek sağlayan servislerdir. Bunlar:

- Mevcut özellikleri (kaynaklar, istemler, araçlar) kaydeder.
- Client’tan gelen araç çağrılarını alır ve çalıştırır.
- Model yanıtlarını geliştirmek için bağlamsal bilgi sunar.
- Çıktıları client’a geri gönderir.
- Gerekirse etkileşimler arasında durumu korur.

Server’lar, model yeteneklerini özel fonksiyonlarla genişletmek için herkes tarafından geliştirilebilir.

### 4. Server Özellikleri

Model Context Protocol (MCP) içindeki server’lar, client’lar, host’lar ve dil modelleri arasında zengin etkileşimler sağlayan temel yapı taşlarını sunar. Bu özellikler, yapılandırılmış bağlam, araçlar ve istemler sunarak MCP’nin yeteneklerini artırmak için tasarlanmıştır.

MCP server’ları aşağıdaki özelliklerden herhangi birini sunabilir:

#### 📑 Kaynaklar

Model Context Protocol (MCP) içindeki kaynaklar, kullanıcılar veya AI modelleri tarafından kullanılabilecek çeşitli bağlam ve veri türlerini kapsar. Bunlar şunları içerir:

- **Bağlamsal Veri**: Kullanıcıların veya AI modellerinin karar verme ve görev yürütme için kullanabileceği bilgi ve bağlam.
- **Bilgi Tabanları ve Doküman Depoları**: Makaleler, kılavuzlar ve araştırma raporları gibi yapılandırılmış ve yapılandırılmamış veri koleksiyonları, değerli içgörüler ve bilgiler sağlar.
- **Yerel Dosyalar ve Veri Tabanları**: Cihazlarda veya veri tabanlarında yerel olarak depolanan ve işleme ile analiz için erişilebilen veriler.
- **API’ler ve Web Servisleri**: Çeşitli çevrimiçi kaynaklar ve araçlarla entegrasyon sağlayan ek veri ve işlevsellik sunan dış arayüzler ve servisler.

Bir kaynak örneği, aşağıdaki gibi erişilebilen bir veri tabanı şeması veya dosya olabilir:

```text
file://log.txt
database://schema
```

### 🤖 İstemler

Model Context Protocol (MCP) içindeki istemler, kullanıcı iş akışlarını kolaylaştırmak ve iletişimi geliştirmek için tasarlanmış çeşitli önceden tanımlı şablonlar ve etkileşim kalıplarını içerir. Bunlar şunlardır:

- **Şablonlanmış Mesajlar ve İş Akışları**: Kullanıcıları belirli görevler ve etkileşimler boyunca yönlendiren önceden yapılandırılmış mesajlar ve süreçler.
- **Önceden Tanımlı Etkileşim Kalıpları**: Tutarlı ve verimli iletişimi kolaylaştıran standartlaştırılmış eylem ve yanıt dizileri.
- **Özelleştirilmiş Konuşma Şablonları**: Belirli konuşma türleri için uyarlanabilir şablonlar, ilgili ve bağlama uygun etkileşimler sağlar.

Bir istem şablonu şu şekilde görünebilir:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Araçlar

Model Context Protocol (MCP) içindeki araçlar, AI modelinin belirli görevleri gerçekleştirmek için çalıştırabileceği fonksiyonlardır. Bu araçlar, AI modelinin yeteneklerini yapılandırılmış ve güvenilir işlemler sağlayarak artırmak için tasarlanmıştır. Temel özellikler şunlardır:

- **AI modelinin çalıştırabileceği fonksiyonlar**: Araçlar, AI modelinin çeşitli görevleri yerine getirmek için çağırabileceği yürütülebilir fonksiyonlardır.
- **Benzersiz İsim ve Açıklama**: Her aracın amacı ve işlevselliğini açıklayan kendine özgü bir adı ve ayrıntılı açıklaması vardır.
- **Parametreler ve Çıktılar**: Araçlar belirli parametreleri kabul eder ve yapılandırılmış çıktılar döner, böylece tutarlı ve öngörülebilir sonuçlar sağlar.
- **Ayrık Fonksiyonlar**: Web aramaları, hesaplamalar ve veri tabanı sorguları gibi bağımsız işlevler gerçekleştirir.

Bir araç örneği şu şekilde olabilir:

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

## Client Özellikleri

Model Context Protocol (MCP) içinde client’lar, protokolün genel işlevselliğini ve etkileşimini artıran sunuculara birkaç önemli özellik sunar. Öne çıkan özelliklerden biri Sampling’dir.

### 👉 Sampling

- **Sunucu Tarafından Başlatılan Ajan Davranışları**: Client’lar, sunucuların belirli eylemleri veya davranışları otonom olarak başlatmasını sağlar, sistemin dinamik yeteneklerini artırır.
- **Özyinelemeli LLM Etkileşimleri**: Bu özellik, büyük dil modelleriyle (LLM) özyinelemeli etkileşimlere izin verir, daha karmaşık ve yinelemeli görev işleme olanağı sunar.
- **Ek Model Tamamlamaları Talebi**: Sunucular, yanıtların kapsamlı ve bağlama uygun olmasını sağlamak için modelden ek tamamlamalar isteyebilir.

## MCP’de Bilgi Akışı

Model Context Protocol (MCP), host’lar, client’lar, server’lar ve modeller arasında yapılandırılmış bir bilgi akışı tanımlar. Bu akışı anlamak, kullanıcı taleplerinin nasıl işlendiğini ve dış araçlar ile verilerin model yanıtlarına nasıl entegre edildiğini netleştirir.

- **Host Bağlantı Başlatır**  
  Host uygulaması (örneğin bir IDE veya sohbet arayüzü), genellikle STDIO, WebSocket veya desteklenen başka bir taşıma yöntemiyle MCP sunucusuna bağlantı kurar.

- **Yetenek Müzakeresi**  
  Host içindeki client ile sunucu, destekledikleri özellikler, araçlar, kaynaklar ve protokol sürümleri hakkında bilgi alışverişi yapar. Bu, her iki tarafın oturum için hangi yeteneklerin mevcut olduğunu anlamasını sağlar.

- **Kullanıcı Talebi**  
  Kullanıcı host ile etkileşime girer (örneğin bir istem veya komut girer). Host bu girdiyi toplar ve işleme için client’a iletir.

- **Kaynak veya Araç Kullanımı**  
  - Client, modelin anlayışını zenginleştirmek için sunucudan ek bağlam veya kaynaklar (dosyalar, veri tabanı girdileri veya bilgi tabanı makaleleri gibi) talep edebilir.  
  - Modelin bir araca ihtiyaç duyduğunu belirlemesi halinde (örneğin veri getirmek, hesaplama yapmak veya API çağrısı yapmak için), client araç adı ve parametreleri belirterek sunucuya araç çağrısı talebi gönderir.

- **Sunucu Çalıştırma**  
  Sunucu, kaynak veya araç talebini alır, gerekli işlemleri gerçekleştirir (örneğin fonksiyon çalıştırma, veri tabanı sorgulama veya dosya getirme) ve sonuçları yapılandırılmış biçimde client’a döner.

- **Yanıt Oluşturma**  
  Client, sunucudan gelen yanıtları (kaynak verisi, araç çıktıları vb.) devam eden model etkileşimine entegre eder. Model bu bilgileri kullanarak kapsamlı ve bağlama uygun yanıt üretir.

- **Sonucun Sunumu**  
  Host, client’tan gelen nihai çıktıyı alır ve kullanıcıya sunar; genellikle model tarafından oluşturulan metin ve araç çalıştırma ya da kaynak sorgulama sonuçlarını içerir.

Bu akış, MCP’nin modelleri dış araçlar ve veri kaynaklarıyla sorunsuz şekilde bağlayarak gelişmiş, etkileşimli ve bağlama duyarlı AI uygulamalarını desteklemesini sağlar.

## Protokol Detayları

MCP (Model Context Protocol), [JSON-RPC 2.0](https://www.jsonrpc.org/) üzerine inşa edilmiştir ve host’lar, client’lar ile server’lar arasında standart, dil bağımsız mesaj formatı sağlar. Bu temel, farklı platformlar ve programlama dilleri arasında güvenilir, yapılandırılmış ve genişletilebilir etkileşimlere olanak tanır.

### Temel Protokol Özellikleri

MCP, araç çağrısı, kaynak erişimi ve istem yönetimi için ek kurallarla JSON-RPC 2.0’ı genişletir. Birden çok taşıma katmanını (STDIO, WebSocket, SSE) destekler ve bileşenler arasında güvenli, genişletilebilir ve dil bağımsız iletişimi mümkün kılar.

#### 🧢 Temel Protokol

- **JSON-RPC Mesaj Formatı**: Tüm istekler ve yanıtlar JSON-RPC 2.0 spesifikasyonunu kullanır; bu, metod çağrıları, parametreler, sonuçlar ve hata yönetimi için tutarlı yapı sağlar.
- **Durumlu Bağlantılar**: MCP oturumları, birden fazla istek boyunca durumu korur; devam eden konuşmaları, bağlam birikimini ve kaynak yönetimini destekler.
- **Yetenek Müzakeresi**: Bağlantı kurulurken, client ve server desteklenen özellikler, protokol sürümleri, mevcut araçlar ve kaynaklar hakkında bilgi alışverişi yapar. Bu, her iki tarafın yeteneklerini anlamasını ve uyum sağlamasını sağlar.

#### ➕ Ek Yardımcılar

Aşağıda, MCP’nin geliştirici deneyimini artırmak ve gelişmiş senaryoları mümkün kılmak için sunduğu ek yardımcılar ve protokol genişletmeleri yer almaktadır:

- **Yapılandırma Seçenekleri**: MCP, oturum parametrelerinin (araç izinleri, kaynak erişimi, model ayarları gibi) dinamik olarak yapılandırılmasına izin verir, her etkileşime özel uyarlanabilir.
- **İlerleme Takibi**: Uzun süren işlemler ilerleme güncellemeleri raporlayabilir, böylece kullanıcı arayüzleri daha duyarlı ve kullanıcı deneyimi daha iyi olur.
- **İstek İptali**: Client’lar, devam eden istekleri iptal edebilir; bu, artık gerekli olmayan veya uzun süren işlemlerin kesilmesini sağlar.
- **Hata Bildirimi**: Standartlaştırılmış hata mesajları ve kodları sorunların teşhisini kolaylaştırır, hataların zarif şekilde yönetilmesini ve kullanıcı ile geliştiricilere eyleme geçirilebilir geri bildirim sağlanmasını destekler.
- **Kayıt Tutma**: Hem client hem de server, denetim, hata ayıklama ve protokol etkileşimlerinin izlenmesi için yapılandırılmış loglar üretebilir.

Bu protokol özelliklerinden yararlanarak MCP, dil modelleri ile dış araçlar veya veri kaynakları arasında sağlam, güvenli ve esnek iletişim sağlar.

### 🔐 Güvenlik Hususları

MCP uygulamaları, güvenli ve güvenilir etkileşimler için aşağıdaki temel güvenlik ilkelerine uymalıdır:

- **Kullanıcı Onayı ve Kontrolü**: Veri erişimi veya işlem yapılmadan önce kullanıcıdan açık onay alınmalıdır. Kullanıcılar, hangi verilerin paylaşıldığı ve hangi işlemlerin yetkilendirildiği üzerinde net kontrole sahip olmalı, bu faaliyetleri gözden geçirmek ve onaylamak için sezgisel kullanıcı arayüzleri sağlanmalıdır.
- **Veri Gizliliği**: Kullanıcı verileri yalnızca açık onayla paylaşılmalı ve uygun erişim kontrolleri ile korunmalıdır. MCP uygulamaları, yetkisiz veri iletimini önlemeli ve gizliliğin tüm etkileşimlerde korunmasını sağlamalıdır.
- **Araç Güvenliği**: Herhangi bir araç çağrılmadan önce açık kullanıcı onayı gereklidir. Kullanıcılar, her aracın işlevselliğini net şekilde anlamalı ve istenmeyen ya da güvensiz araç çalıştırmalarını engellemek için güçlü güvenlik sınırları uygulanmalıdır.

Bu ilkeler takip edilerek MCP, kullanıcı güveni, gizliliği ve güvenliğini tüm protokol etkileşimlerinde korur.

## Kod Örnekleri: Temel Bileşenler

Aşağıda, popüler programlama dillerinde MCP server bileşenleri ve araçlarının nasıl uygulanacağını gösteren kod örnekleri yer almaktadır.

### .NET Örneği: Araçlarla Basit MCP Sunucusu Oluşturma

Aşağıdaki .NET kod örneği, özel araçlar içeren basit bir MCP sunucusunun nasıl uygulanacağını gösterir. Bu örnek, araçların tanımlanması ve kaydedilmesi, isteklerin yönetilmesi ve Model Context Protocol ile sunucu bağlantısının kurulmasını sergiler.

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

### Java Örneği: MCP Sunucu Bileşenleri

Bu örnek, yukarıdaki .NET örneğiyle aynı MCP sunucu ve araç kaydını Java’da göstermektedir.

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

### Python Örneği: MCP Sunucusu Oluşturma

Bu örnekte, Python’da bir MCP sunucusunun nasıl oluşturulacağı gösterilmektedir. Ayrıca araç oluşturmanın iki farklı yolu sunulmaktadır.

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

### JavaScript Örneği: MCP Sunucusu Oluşturma

Bu örnek, JavaScript’te MCP sunucusu oluşturmayı ve hava durumu ile ilgili iki aracın kaydını gösterir.

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

Bu JavaScript örneği, bir MCP client’ın sunucuya nasıl bağlandığını, istem gönderdiğini ve yapılan araç çağrılarını da içeren yanıtları nasıl işlediğini gösterir.

## Güvenlik ve Yetkilendirme

MCP, protokol boyunca güvenlik ve yetkilendirmeyi yönetmek için birkaç yerleşik kavram ve mekanizma içerir:

1. **Araç İzin Kontrolü**:  
   Client’lar, bir modelin oturum sırasında hangi araçları kullanabileceğini belirtebilir. Bu, yalnızca açıkça yetkilendirilmiş araçların erişilebilir olmasını sağlar ve istenmeyen veya güvensiz işlemlerin riskini azaltır. İzinler, kullanıcı tercihleri, kurumsal politikalar veya etkileşim bağlamına göre dinamik olarak yapılandırılabilir.

2. **Kimlik Doğrulama**:  
   Sunucular, araçlara, kaynaklara veya hassas işlemlere erişimden önce kimlik doğrulaması talep edebilir. Bu, API anahtarları, OAuth token’ları veya diğer kimlik doğrulama şemalarını içerebilir. Do

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.