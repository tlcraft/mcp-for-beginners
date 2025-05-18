<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:36:15+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tr"
}
-->
# 📖 MCP Temel Kavramlar: AI Entegrasyonu için Model Bağlam Protokolünü Yönetmek

Model Bağlam Protokolü (MCP), Büyük Dil Modelleri (LLM'ler) ile harici araçlar, uygulamalar ve veri kaynakları arasındaki iletişimi optimize eden güçlü, standartlaştırılmış bir çerçevedir. Bu SEO optimize edilmiş kılavuz, MCP'nin temel kavramlarını anlamanızı sağlayarak istemci-sunucu mimarisini, temel bileşenlerini, iletişim mekaniklerini ve uygulama en iyi uygulamalarını anlamanızı sağlayacak.

## Genel Bakış

Bu ders, Model Bağlam Protokolü (MCP) ekosistemini oluşturan temel mimariyi ve bileşenleri keşfeder. MCP etkileşimlerini güçlendiren istemci-sunucu mimarisini, ana bileşenleri ve iletişim mekanizmalarını öğreneceksiniz.

## 👩‍🎓 Temel Öğrenme Hedefleri

Bu dersin sonunda:

- MCP istemci-sunucu mimarisini anlayacaksınız.
- Ana Bilgisayarlar, İstemciler ve Sunucuların rollerini ve sorumluluklarını tanımlayacaksınız.
- MCP'yi esnek bir entegrasyon katmanı yapan temel özellikleri analiz edeceksiniz.
- MCP ekosisteminde bilginin nasıl aktığını öğreneceksiniz.
- .NET, Java, Python ve JavaScript'te kod örnekleriyle pratik bilgiler edineceksiniz.

## 🔎 MCP Mimarisi: Daha Derin Bir Bakış

MCP ekosistemi bir istemci-sunucu modeline dayanır. Bu modüler yapı, AI uygulamalarının araçlar, veritabanları, API'ler ve bağlamsal kaynaklarla verimli bir şekilde etkileşimde bulunmasına olanak tanır. Bu mimariyi temel bileşenlerine ayıralım.

### 1. Ana Bilgisayarlar

Model Bağlam Protokolü'nde (MCP), Ana Bilgisayarlar, kullanıcıların protokolle etkileşime geçtiği birincil arayüz olarak kritik bir rol oynar. Ana Bilgisayarlar, veri, araçlar ve istemlere erişmek için MCP sunucularıyla bağlantı başlatan uygulamalar veya ortamlardır. Ana Bilgisayarlara örnek olarak Visual Studio Code gibi entegre geliştirme ortamları (IDE'ler), Claude Desktop gibi AI araçları veya belirli görevler için özel olarak tasarlanmış ajanlar verilebilir.

**Ana Bilgisayarlar**, bağlantıları başlatan LLM uygulamalarıdır. Onlar:

- Yanıtlar üretmek için AI modelleriyle çalışır veya etkileşime girer.
- MCP sunucularıyla bağlantı başlatır.
- Konuşma akışını ve kullanıcı arayüzünü yönetir.
- İzin ve güvenlik kısıtlamalarını kontrol eder.
- Veri paylaşımı ve araç yürütme için kullanıcı rızasını yönetir.

### 2. İstemciler

İstemciler, Ana Bilgisayarlar ve MCP sunucuları arasındaki etkileşimi kolaylaştıran temel bileşenlerdir. İstemciler, Ana Bilgisayarların MCP sunucularının sağladığı işlevselliklere erişmesini ve bunları kullanmasını sağlayan aracı görevi görür. MCP mimarisi içinde sorunsuz iletişim ve verimli veri alışverişi sağlamak için kritik bir rol oynarlar.

**İstemciler**, ana bilgisayar uygulaması içindeki bağlayıcılardır. Onlar:

- İstemler/talimatlarla sunuculara istek gönderir.
- Sunucularla yetenekleri müzakere eder.
- Modellerden gelen araç yürütme isteklerini yönetir.
- Kullanıcılara yanıtları işler ve gösterir.

### 3. Sunucular

Sunucular, MCP istemcilerinden gelen istekleri işlemek ve uygun yanıtları sağlamakla sorumludur. Veri alma, araç yürütme ve istem oluşturma gibi çeşitli işlemleri yönetirler. Sunucular, istemciler ve Ana Bilgisayarlar arasındaki iletişimin verimli ve güvenilir olmasını sağlayarak etkileşim sürecinin bütünlüğünü korur.

**Sunucular**, bağlam ve yetenekler sağlayan hizmetlerdir. Onlar:

- Mevcut özellikleri (kaynaklar, istemler, araçlar) kaydeder.
- İstemciden gelen araç çağrılarını alır ve yürütür.
- Model yanıtlarını geliştirmek için bağlamsal bilgi sağlar.
- Çıktıları istemciye geri döndürür.
- Gerektiğinde etkileşimler arasında durumu korur.

Sunucular, model yeteneklerini özel işlevselliklerle genişletmek için herhangi biri tarafından geliştirilebilir.

### 4. Sunucu Özellikleri

Model Bağlam Protokolü'nde (MCP) sunucular, istemciler, ana bilgisayarlar ve dil modelleri arasında zengin etkileşimleri mümkün kılan temel yapı taşları sağlar. Bu özellikler, yapılandırılmış bağlam, araçlar ve istemler sunarak MCP'nin yeteneklerini geliştirmek için tasarlanmıştır.

MCP sunucuları aşağıdaki özelliklerden herhangi birini sunabilir:

#### 📑 Kaynaklar

Model Bağlam Protokolü'nde (MCP) kaynaklar, kullanıcılar veya AI modelleri tarafından kullanılabilecek çeşitli bağlam ve veri türlerini kapsar. Bunlar şunları içerir:

- **Bağlamsal Veri**: Kullanıcılar veya AI modelleri tarafından karar verme ve görev yürütme için kullanılabilecek bilgi ve bağlam.
- **Bilgi Tabanları ve Doküman Depoları**: Değerli içgörüler ve bilgiler sağlayan makaleler, kılavuzlar ve araştırma makaleleri gibi yapılandırılmış ve yapılandırılmamış veri koleksiyonları.
- **Yerel Dosyalar ve Veritabanları**: Cihazlarda veya veritabanlarında yerel olarak depolanan ve işleme ve analiz için erişilebilen veriler.
- **API'ler ve Web Hizmetleri**: Çeşitli çevrimiçi kaynaklar ve araçlarla entegrasyonu sağlayan ek veri ve işlevler sunan harici arayüzler ve hizmetler.

Bir kaynak örneği, aşağıdaki gibi erişilebilen bir veritabanı şeması veya bir dosya olabilir:

```text
file://log.txt
database://schema
```

### 🤖 İstemler

Model Bağlam Protokolü'ndeki (MCP) istemler, kullanıcı iş akışlarını kolaylaştırmak ve iletişimi geliştirmek için tasarlanmış çeşitli önceden tanımlanmış şablonları ve etkileşim kalıplarını içerir. Bunlar şunları içerir:

- **Şablon Mesajlar ve İş Akışları**: Kullanıcıları belirli görevler ve etkileşimler boyunca yönlendiren önceden yapılandırılmış mesajlar ve süreçler.
- **Önceden Tanımlanmış Etkileşim Kalıpları**: Tutarlı ve verimli iletişimi kolaylaştıran standartlaştırılmış eylem ve yanıt dizileri.
- **Özel Konuşma Şablonları**: Belirli türdeki konuşmalar için uyarlanmış özelleştirilebilir şablonlar, ilgili ve bağlamsal olarak uygun etkileşimler sağlar.

Bir istem şablonu şöyle görünebilir:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Araçlar

Model Bağlam Protokolü'ndeki (MCP) araçlar, AI modelinin belirli görevleri yerine getirmek için yürütebileceği işlevlerdir. Bu araçlar, AI modelinin yeteneklerini yapılandırılmış ve güvenilir işlemler sağlayarak artırmak için tasarlanmıştır. Temel yönler şunları içerir:

- **AI Modeli için Yürütülecek İşlevler**: Araçlar, AI modelinin çeşitli görevleri gerçekleştirmek için çağırabileceği yürütülebilir işlevlerdir.
- **Benzersiz Ad ve Açıklama**: Her aracın, amacını ve işlevselliğini açıklayan benzersiz bir adı ve ayrıntılı bir açıklaması vardır.
- **Parametreler ve Çıktılar**: Araçlar belirli parametreleri kabul eder ve tutarlı ve öngörülebilir sonuçlar sağlayarak yapılandırılmış çıktılar döndürür.
- **Ayrık İşlevler**: Araçlar, web aramaları, hesaplamalar ve veritabanı sorguları gibi ayrık işlevler gerçekleştirir.

Bir araç örneği şöyle görünebilir:

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

## İstemci Özellikleri

Model Bağlam Protokolü'nde (MCP) istemciler, protokol içindeki genel işlevselliği ve etkileşimi artırarak sunuculara birkaç önemli özellik sunar. Dikkate değer özelliklerden biri Örnekleme'dir.

### 👉 Örnekleme

- **Sunucu Tarafından Başlatılan Ajan Davranışları**: İstemciler, sunucuların belirli eylemleri veya davranışları özerk bir şekilde başlatmasına olanak tanır, sistemin dinamik yeteneklerini artırır.
- **Yinelemeli LLM Etkileşimleri**: Bu özellik, büyük dil modelleri (LLM'ler) ile yinelemeli etkileşimlere olanak tanır, daha karmaşık ve yinelemeli görev işleme sağlar.
- **Ek Model Tamamlamaları Talep Etme**: Sunucular, yanıtların kapsamlı ve bağlamsal olarak uygun olmasını sağlamak için modelden ek tamamlamalar talep edebilir.

## MCP'de Bilgi Akışı

Model Bağlam Protokolü (MCP), ana bilgisayarlar, istemciler, sunucular ve modeller arasında yapılandırılmış bir bilgi akışını tanımlar. Bu akışı anlamak, kullanıcı isteklerinin nasıl işlendiğini ve harici araçların ve verilerin model yanıtlarına nasıl entegre edildiğini açıklamaya yardımcı olur.

- **Ana Bilgisayar Bağlantıyı Başlatır**  
  Ana bilgisayar uygulaması (örneğin, bir IDE veya sohbet arayüzü), genellikle STDIO, WebSocket veya başka bir desteklenen taşıma aracılığıyla bir MCP sunucusuna bağlantı kurar.

- **Yetenek Müzakeresi**  
  Ana bilgisayara gömülü istemci ve sunucu, destekledikleri özellikler, araçlar, kaynaklar ve protokol sürümleri hakkında bilgi alışverişinde bulunur. Bu, her iki tarafın da oturum için hangi yeteneklerin mevcut olduğunu anlamasını sağlar.

- **Kullanıcı İsteği**  
  Kullanıcı, ana bilgisayarla etkileşimde bulunur (örneğin, bir istem veya komut girer). Ana bilgisayar bu girdiyi toplar ve işlem için istemciye iletir.

- **Kaynak veya Araç Kullanımı**  
  - İstemci, modelin anlayışını zenginleştirmek için sunucudan ek bağlam veya kaynaklar (örneğin, dosyalar, veritabanı girdileri veya bilgi tabanı makaleleri) talep edebilir.
  - Model bir aracın gerekli olduğunu belirlerse (örneğin, veri almak, bir hesaplama yapmak veya bir API çağrısı yapmak), istemci, araç adı ve parametrelerini belirterek sunucuya bir araç çağrısı isteği gönderir.

- **Sunucu Yürütmesi**  
  Sunucu, kaynak veya araç isteğini alır, gerekli işlemleri gerçekleştirir (örneğin, bir işlev çalıştırmak, bir veritabanını sorgulamak veya bir dosya almak) ve sonuçları istemciye yapılandırılmış bir formatta geri döndürür.

- **Yanıt Oluşturma**  
  İstemci, sunucunun yanıtlarını (kaynak verileri, araç çıktıları vb.) devam eden model etkileşimine entegre eder. Model, kapsamlı ve bağlamsal olarak uygun bir yanıt oluşturmak için bu bilgiyi kullanır.

- **Sonuç Sunumu**  
  Ana bilgisayar, istemciden nihai çıktıyı alır ve genellikle hem modelin ürettiği metni hem de araç yürütmelerinden veya kaynak aramalarından gelen sonuçları içerecek şekilde kullanıcıya sunar.

Bu akış, MCP'nin modelleri harici araçlar ve veri kaynaklarıyla sorunsuz bir şekilde bağlayarak gelişmiş, etkileşimli ve bağlam farkındalığı olan AI uygulamalarını desteklemesini sağlar.

## Protokol Ayrıntıları

MCP (Model Bağlam Protokolü), ana bilgisayarlar, istemciler ve sunucular arasında iletişim için standartlaştırılmış, dil bağımsız bir mesaj formatı sağlayan [JSON-RPC 2.0](https://www.jsonrpc.org/) üzerine inşa edilmiştir. Bu temel, çeşitli platformlar ve programlama dilleri arasında güvenilir, yapılandırılmış ve genişletilebilir etkileşimleri mümkün kılar.

### Ana Protokol Özellikleri

MCP, araç çağrısı, kaynak erişimi ve istem yönetimi için ek kurallarla JSON-RPC 2.0'ı genişletir. Birden fazla taşıma katmanını (STDIO, WebSocket, SSE) destekler ve bileşenler arasında güvenli, genişletilebilir ve dil bağımsız iletişim sağlar.

#### 🧢 Temel Protokol

- **JSON-RPC Mesaj Formatı**: Tüm istekler ve yanıtlar, yöntem çağrıları, parametreler, sonuçlar ve hata işleme için tutarlı bir yapı sağlayan JSON-RPC 2.0 spesifikasyonunu kullanır.
- **Durumlu Bağlantılar**: MCP oturumları, birden fazla istek boyunca durumu korur, devam eden konuşmaları, bağlam birikimini ve kaynak yönetimini destekler.
- **Yetenek Müzakeresi**: Bağlantı kurulumu sırasında, istemciler ve sunucular desteklenen özellikler, protokol sürümleri, mevcut araçlar ve kaynaklar hakkında bilgi alışverişinde bulunur. Bu, her iki tarafın da birbirinin yeteneklerini anlamasını ve buna göre uyum sağlamasını sağlar.

#### ➕ Ek Araçlar

Aşağıda, MCP'nin geliştirici deneyimini artırmak ve gelişmiş senaryoları mümkün kılmak için sağladığı bazı ek araçlar ve protokol uzantıları bulunmaktadır:

- **Yapılandırma Seçenekleri**: MCP, her etkileşime uygun araç izinleri, kaynak erişimi ve model ayarları gibi oturum parametrelerinin dinamik yapılandırılmasına olanak tanır.
- **İlerleme Takibi**: Uzun süren işlemler ilerleme güncellemeleri rapor edebilir, bu da duyarlı kullanıcı arayüzleri ve karmaşık görevler sırasında daha iyi bir kullanıcı deneyimi sağlar.
- **İstek İptali**: İstemciler, artık gerekli olmayan veya çok uzun süren işlemleri kesintiye uğratmak için uçuş halindeki istekleri iptal edebilir.
- **Hata Raporlama**: Standartlaştırılmış hata mesajları ve kodları, sorunların teşhis edilmesine, hataların zarif bir şekilde ele alınmasına ve kullanıcılara ve geliştiricilere eyleme geçirilebilir geri bildirim sağlanmasına yardımcı olur.
- **Günlükleme**: Hem istemciler hem de sunucular, protokol etkileşimlerini denetleme, hata ayıklama ve izleme için yapılandırılmış günlükler yayabilir.

Bu protokol özelliklerinden yararlanarak, MCP, dil modelleri ile harici araçlar veya veri kaynakları arasında sağlam, güvenli ve esnek iletişimi sağlar.

### 🔐 Güvenlik Hususları

MCP uygulamaları, güvenli ve güvenilir etkileşimleri sağlamak için birkaç temel güvenlik ilkesine uymalıdır:

- **Kullanıcı Onayı ve Kontrolü**: Herhangi bir veri erişilmeden veya işlemler gerçekleştirilmeden önce kullanıcılar açıkça onay vermelidir. Paylaşılan veriler ve yetkilendirilen işlemler üzerinde net bir kontrole sahip olmalı ve etkinlikleri gözden geçirme ve onaylama için sezgisel kullanıcı arayüzleri ile desteklenmelidirler.

- **Veri Gizliliği**: Kullanıcı verileri yalnızca açık onayla ifşa edilmeli ve uygun erişim kontrolleri ile korunmalıdır. MCP uygulamaları, yetkisiz veri iletimine karşı koruma sağlamalı ve tüm etkileşimler boyunca gizliliğin korunmasını sağlamalıdır.

- **Araç Güvenliği**: Herhangi bir aracı çalıştırmadan önce açık kullanıcı onayı gereklidir. Kullanıcılar, her aracın işlevselliğini net bir şekilde anlamalı ve istenmeyen veya güvensiz araç çalıştırmalarını önlemek için sağlam güvenlik sınırları uygulanmalıdır.

Bu ilkeleri izleyerek, MCP tüm protokol etkileşimlerinde kullanıcı güveni, gizliliği ve güvenliğini sağlar.

## Kod Örnekleri: Temel Bileşenler

Aşağıda, ana MCP sunucu bileşenlerini ve araçlarını nasıl uygulayacağınızı gösteren birkaç popüler programlama dilinde kod örnekleri bulunmaktadır.

### .NET Örneği: Araçlarla Basit Bir MCP Sunucusu Oluşturma

İşte, Model Bağlam Protokolünü kullanarak araçları tanımlama ve kaydetme, istekleri işleme ve sunucuyu bağlama konularını gösteren pratik bir .NET kod örneği.

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

Bu örnek, yukarıdaki .NET örneğinde olduğu gibi MCP sunucusu ve araç kaydını, ancak Java'da uygulanmış haliyle göstermektedir.

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

### Python Örneği: Bir MCP Sunucusu Oluşturma

Bu örnekte, Python'da bir MCP sunucusunun nasıl oluşturulacağını gösteriyoruz. Ayrıca araçları oluşturmanın iki farklı yolunu da gösteriyoruz.

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

### JavaScript Örneği: Bir MCP Sunucusu Oluşturma

Bu örnek, JavaScript'te MCP sunucu oluşturmayı ve hava durumu ile ilgili iki aracı nasıl kaydedeceğinizi gösterir.

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

Bu JavaScript örneği, bir sun

**Feragatname**:
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlaşılmalardan veya yanlış yorumlamalardan sorumlu değiliz.