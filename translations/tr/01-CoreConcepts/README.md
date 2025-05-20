<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:04:48+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tr"
}
-->
# 📖 MCP Temel Kavramları: Yapay Zeka Entegrasyonu için Model Context Protocol'ü Öğrenmek

Model Context Protocol (MCP), Büyük Dil Modelleri (LLM'ler) ile dış araçlar, uygulamalar ve veri kaynakları arasındaki iletişimi optimize eden güçlü ve standartlaştırılmış bir çerçevedir. Bu SEO uyumlu rehber, MCP'nin istemci-sunucu mimarisini, temel bileşenlerini, iletişim mekanizmalarını ve uygulama en iyi uygulamalarını anlamanızı sağlayacak.

## Genel Bakış

Bu ders, Model Context Protocol (MCP) ekosistemini oluşturan temel mimari ve bileşenleri inceler. MCP etkileşimlerini destekleyen istemci-sunucu mimarisi, ana bileşenler ve iletişim mekanizmaları hakkında bilgi edineceksiniz.

## 👩‍🎓 Temel Öğrenme Hedefleri

Bu dersin sonunda:

- MCP istemci-sunucu mimarisini anlayacaksınız.
- Hostların, İstemcilerin ve Sunucuların rollerini ve sorumluluklarını tanımlayacaksınız.
- MCP'yi esnek bir entegrasyon katmanı yapan temel özellikleri analiz edeceksiniz.
- MCP ekosisteminde bilgi akışının nasıl gerçekleştiğini öğreneceksiniz.
- .NET, Java, Python ve JavaScript ile kod örnekleri üzerinden pratik bilgiler kazanacaksınız.

## 🔎 MCP Mimarisi: Daha Derin Bir Bakış

MCP ekosistemi, istemci-sunucu modeli üzerine kuruludur. Bu modüler yapı, yapay zeka uygulamalarının araçlar, veritabanları, API'ler ve bağlamsal kaynaklarla verimli şekilde etkileşim kurmasını sağlar. Bu mimariyi temel bileşenlerine ayıralım.

### 1. Hostlar

Model Context Protocol (MCP) içinde Hostlar, kullanıcıların protokolle etkileşim kurduğu birincil arayüzü oluşturur. Hostlar, MCP sunucularıyla bağlantı başlatan ve veri, araçlar ile istemler erişen uygulamalar veya ortamlar olarak tanımlanır. Hostlara örnek olarak Visual Studio Code gibi entegre geliştirme ortamları, Claude Desktop gibi yapay zeka araçları veya belirli görevler için özel olarak tasarlanmış ajanlar verilebilir.

**Hostlar**, bağlantı başlatan LLM uygulamalarıdır. Şunları yaparlar:

- Yanıt üretmek için yapay zeka modellerini çalıştırır veya onlarla etkileşir.
- MCP sunucularıyla bağlantı başlatır.
- Konuşma akışını ve kullanıcı arayüzünü yönetir.
- İzin ve güvenlik kısıtlamalarını kontrol eder.
- Veri paylaşımı ve araç çalıştırma için kullanıcı onayını yönetir.

### 2. İstemciler

İstemciler, Hostlar ile MCP sunucuları arasındaki etkileşimi kolaylaştıran temel bileşenlerdir. İstemciler, Hostların MCP sunucularının sağladığı işlevselliklere erişimini ve kullanımını sağlayan aracılardır. MCP mimarisinde sorunsuz iletişim ve verimli veri alışverişi sağlamakta kritik rol oynarlar.

**İstemciler**, host uygulaması içindeki bağlayıcılardır. Şunları yaparlar:

- Sunuculara istem veya talimat gönderir.
- Sunucularla yetenek müzakeresi yapar.
- Modellerden gelen araç çalıştırma isteklerini yönetir.
- Yanıtları işleyip kullanıcılara gösterir.

### 3. Sunucular

Sunucular, MCP istemcilerinden gelen istekleri işlemek ve uygun yanıtları sağlamakla sorumludur. Veri alma, araç çalıştırma ve istem oluşturma gibi çeşitli işlemleri yönetirler. Sunucular, istemciler ile Hostlar arasındaki iletişimin verimli ve güvenilir olmasını sağlar, etkileşim sürecinin bütünlüğünü korur.

**Sunucular**, bağlam ve yetenek sağlayan hizmetlerdir. Şunları yaparlar:

- Mevcut özellikleri (kaynaklar, istemler, araçlar) kaydeder.
- İstemciden gelen araç çağrılarını alır ve çalıştırır.
- Model yanıtlarını geliştirmek için bağlamsal bilgi sağlar.
- Çıktıları istemciye geri döner.
- Gerekirse etkileşimler arasında durumu korur.

Sunucular, model yeteneklerini özel işlevsellikle genişletmek için herkes tarafından geliştirilebilir.

### 4. Sunucu Özellikleri

Model Context Protocol (MCP) sunucuları, istemciler, hostlar ve dil modelleri arasında zengin etkileşimleri mümkün kılan temel yapı taşlarını sağlar. Bu özellikler, MCP'nin yeteneklerini yapılandırılmış bağlam, araçlar ve istemler sunarak artırmak için tasarlanmıştır.

MCP sunucuları aşağıdaki özelliklerden herhangi birini sunabilir:

#### 📑 Kaynaklar

Model Context Protocol (MCP) içindeki kaynaklar, kullanıcıların veya yapay zeka modellerinin kullanabileceği çeşitli bağlam ve veri türlerini kapsar. Bunlar şunları içerir:

- **Bağlamsal Veriler**: Kullanıcıların veya modellerin karar verme ve görev yürütme için kullanabileceği bilgi ve bağlam.
- **Bilgi Tabanları ve Doküman Depoları**: Makaleler, kılavuzlar ve araştırma raporları gibi yapılandırılmış ve yapılandırılmamış veri koleksiyonları, değerli bilgiler sağlar.
- **Yerel Dosyalar ve Veritabanları**: Cihazlarda veya veritabanlarında yerel olarak saklanan ve işleme için erişilebilen veriler.
- **API'ler ve Web Servisleri**: Çeşitli çevrimiçi kaynaklar ve araçlarla entegrasyon sağlayan ek veri ve işlevsellik sunan dış arayüzler.

Bir kaynak örneği, bir veritabanı şeması veya şu şekilde erişilebilen bir dosya olabilir:

```text
file://log.txt
database://schema
```

### 🤖 İstemler

Model Context Protocol (MCP) içindeki istemler, kullanıcı iş akışlarını kolaylaştırmak ve iletişimi geliştirmek için tasarlanmış çeşitli ön tanımlı şablonlar ve etkileşim kalıplarını içerir. Bunlar şunlardır:

- **Şablonlu Mesajlar ve İş Akışları**: Kullanıcıları belirli görevler ve etkileşimler boyunca yönlendiren önceden yapılandırılmış mesajlar ve süreçler.
- **Ön Tanımlı Etkileşim Kalıpları**: Tutarlı ve verimli iletişimi kolaylaştıran standart eylem ve yanıt dizileri.
- **Özelleştirilmiş Konuşma Şablonları**: Belirli konuşma türleri için uygun ve bağlama uygun etkileşimler sağlayan özelleştirilebilir şablonlar.

Bir istem şablonu şu şekilde olabilir:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Araçlar

Model Context Protocol (MCP) içindeki araçlar, yapay zeka modelinin belirli görevleri yerine getirmek için çalıştırabileceği işlevlerdir. Bu araçlar, yapay zeka modelinin yeteneklerini yapılandırılmış ve güvenilir işlemler sunarak artırmak için tasarlanmıştır. Temel özellikler şunlardır:

- **Yapay zeka modelinin çalıştırabileceği işlevler**: Araçlar, modelin çeşitli görevleri yerine getirmek için çağırabileceği çalıştırılabilir fonksiyonlardır.
- **Benzersiz İsim ve Açıklama**: Her aracın amacı ve işlevselliği açıklayan kendine özgü bir adı ve detaylı bir açıklaması vardır.
- **Parametreler ve Çıktılar**: Araçlar belirli parametreleri kabul eder ve yapılandırılmış çıktılar döner, böylece tutarlı ve öngörülebilir sonuçlar sağlanır.
- **Ayrık Fonksiyonlar**: Araçlar web aramaları, hesaplamalar ve veritabanı sorguları gibi ayrı işlevleri yerine getirir.

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

## İstemci Özellikleri

Model Context Protocol (MCP) içinde istemciler, sunuculara çeşitli önemli özellikler sunarak protokol içindeki genel işlevselliği ve etkileşimi geliştirir. Öne çıkan özelliklerden biri Sampling'dir.

### 👉 Sampling

- **Sunucu Başlatmalı Ajan Davranışları**: İstemciler, sunucuların belirli eylemleri veya davranışları özerk olarak başlatmasına olanak tanır, sistemin dinamik yeteneklerini artırır.
- **Yinelenen LLM Etkileşimleri**: Bu özellik, büyük dil modelleriyle (LLM) yinelenen etkileşimlere izin verir, böylece görevlerin daha karmaşık ve yinelemeli işlenmesini sağlar.
- **Ek Model Tamamlamaları Talebi**: Sunucular, yanıtların kapsamlı ve bağlama uygun olmasını sağlamak için modelden ek tamamlamalar talep edebilir.

## MCP'de Bilgi Akışı

Model Context Protocol (MCP), hostlar, istemciler, sunucular ve modeller arasında yapılandırılmış bir bilgi akışı tanımlar. Bu akışın anlaşılması, kullanıcı isteklerinin nasıl işlendiğini ve dış araçlar ile verilerin model yanıtlarına nasıl entegre edildiğini açıklığa kavuşturur.

- **Host Bağlantı Başlatır**  
  Host uygulaması (örneğin bir IDE veya sohbet arayüzü), genellikle STDIO, WebSocket veya desteklenen başka bir taşıma yoluyla MCP sunucusuna bağlantı kurar.

- **Yetenek Müzakeresi**  
  Host içindeki istemci ve sunucu, destekledikleri özellikler, araçlar, kaynaklar ve protokol sürümleri hakkında bilgi alışverişi yapar. Bu, her iki tarafın oturum için mevcut yetenekleri anlamasını sağlar.

- **Kullanıcı İsteği**  
  Kullanıcı host ile etkileşime girer (örneğin bir istem veya komut girer). Host bu girdiyi toplar ve işlenmek üzere istemciye iletir.

- **Kaynak veya Araç Kullanımı**  
  - İstemci, modelin anlayışını zenginleştirmek için sunucudan ek bağlam veya kaynaklar (dosyalar, veritabanı girdileri, bilgi tabanı makaleleri gibi) talep edebilir.
  - Model, bir aracın gerekli olduğunu belirlerse (örneğin veri almak, hesaplama yapmak veya API çağrısı yapmak için), istemci araç çağrısı isteğini sunucuya, araç adı ve parametreleriyle birlikte gönderir.

- **Sunucu İşlemi**  
  Sunucu kaynak veya araç isteğini alır, gerekli işlemleri yapar (örneğin bir fonksiyon çalıştırma, veritabanı sorgulama veya dosya alma) ve sonuçları yapılandırılmış formatta istemciye döner.

- **Yanıt Oluşturma**  
  İstemci, sunucunun yanıtlarını (kaynak verileri, araç çıktıları vb.) devam eden model etkileşimine entegre eder. Model, bu bilgileri kapsamlı ve bağlama uygun yanıt üretmek için kullanır.

- **Sonucun Sunumu**  
  Host, istemciden gelen nihai çıktıyı alır ve kullanıcıya sunar; genellikle model tarafından üretilen metin ile araç çalıştırma veya kaynak sorgulama sonuçlarını içerir.

Bu akış, MCP'nin modelleri dış araçlar ve veri kaynaklarıyla sorunsuzca bağlayarak gelişmiş, etkileşimli ve bağlam farkındalığı yüksek yapay zeka uygulamalarını desteklemesini sağlar.

## Protokol Detayları

MCP (Model Context Protocol), [JSON-RPC 2.0](https://www.jsonrpc.org/) üzerine inşa edilmiştir ve hostlar, istemciler ile sunucular arasında standart, dil bağımsız mesaj formatı sağlar. Bu temel, farklı platformlar ve programlama dilleri arasında güvenilir, yapılandırılmış ve genişletilebilir etkileşimlere olanak tanır.

### Temel Protokol Özellikleri

MCP, araç çağrısı, kaynak erişimi ve istem yönetimi için ek kurallarla JSON-RPC 2.0'ı genişletir. Birden çok taşıma katmanını (STDIO, WebSocket, SSE) destekler ve bileşenler arasında güvenli, genişletilebilir ve dil bağımsız iletişim sağlar.

#### 🧢 Temel Protokol

- **JSON-RPC Mesaj Formatı**: Tüm istekler ve yanıtlar JSON-RPC 2.0 spesifikasyonunu kullanır, böylece yöntem çağrıları, parametreler, sonuçlar ve hata yönetimi için tutarlı yapı sağlanır.
- **Durumlu Bağlantılar**: MCP oturumları, birden çok istek boyunca durumu korur; devam eden konuşmaları, bağlam birikimini ve kaynak yönetimini destekler.
- **Yetenek Müzakeresi**: Bağlantı kurulurken, istemciler ve sunucular desteklenen özellikler, protokol sürümleri, mevcut araçlar ve kaynaklar hakkında bilgi alışverişi yapar. Bu, her iki tarafın birbirinin yeteneklerini anlamasını ve uyum sağlamasını sağlar.

#### ➕ Ek Yardımcılar

MCP'nin geliştirici deneyimini artırmak ve gelişmiş senaryoları desteklemek için sunduğu ek yardımcılar ve protokol genişletmeleri şunlardır:

- **Yapılandırma Seçenekleri**: MCP, oturum parametrelerinin dinamik yapılandırılmasına izin verir; araç izinleri, kaynak erişimi ve model ayarları gibi, her etkileşime özel olarak uyarlanabilir.
- **İlerleme Takibi**: Uzun süren işlemler ilerleme güncellemeleri raporlayabilir, bu da kullanıcı arayüzlerinin daha duyarlı olmasını ve karmaşık görevlerde daha iyi deneyim sağlar.
- **İstek İptali**: İstemciler, devam eden istekleri iptal edebilir; böylece artık gerekli olmayan veya çok uzun süren işlemler durdurulabilir.
- **Hata Bildirimi**: Standartlaştırılmış hata mesajları ve kodları, sorunların teşhisini, hataların zarif yönetimini ve kullanıcılara ile geliştiricilere uygulanabilir geri bildirim sağlamayı kolaylaştırır.
- **Kayıt Tutma**: Hem istemciler hem de sunucular, protokol etkileşimlerini denetleme, hata ayıklama ve izleme için yapılandırılmış günlükler oluşturabilir.

Bu protokol özelliklerini kullanarak MCP, dil modelleri ile dış araçlar veya veri kaynakları arasında sağlam, güvenli ve esnek iletişim sağlar.

### 🔐 Güvenlik Hususları

MCP uygulamaları, güvenli ve güvenilir etkileşimler sağlamak için aşağıdaki temel güvenlik ilkelerine uymalıdır:

- **Kullanıcı Onayı ve Kontrolü**: Herhangi bir veri erişimi veya işlem yapılmadan önce kullanıcıdan açık onay alınmalıdır. Kullanıcılar, hangi verilerin paylaşıldığı ve hangi işlemlerin yetkilendirildiği üzerinde net kontrole sahip olmalı, bu faaliyetleri gözden geçirmek ve onaylamak için sezgisel kullanıcı arayüzleri sunulmalıdır.

- **Veri Gizliliği**: Kullanıcı verileri yalnızca açık onayla paylaşılmalı ve uygun erişim kontrolleri ile korunmalıdır. MCP uygulamaları, yetkisiz veri iletimine karşı koruma sağlamalı ve tüm etkileşimlerde gizliliğin korunmasını güvence altına almalıdır.

- **Araç Güvenliği**: Herhangi bir araç çağrılmadan önce açık kullanıcı onayı gereklidir. Kullanıcılar her aracın işlevselliğini net şekilde anlamalı ve istenmeyen veya güvensiz araç çalıştırmayı önlemek için sağlam güvenlik sınırları uygulanmalıdır.

Bu ilkeler takip edilerek, MCP kullanıcı güveni, gizliliği ve güvenliğini tüm protokol etkileşimlerinde korur.

## Kod Örnekleri: Temel Bileşenler

Aşağıda, popüler programlama dillerinde temel MCP sunucu bileşenleri ve araçlarının nasıl uygulanacağını gösteren kod örnekleri bulunmaktadır.

### .NET Örneği: Araçlarla Basit Bir MCP Sunucusu Oluşturma

İşte özel araçlar içeren basit bir MCP sunucusunu nasıl uygulayacağını gösteren pratik .NET kod örneği. Bu örnek, araçların tanımlanması, kaydedilmesi, isteklerin işlenmesi ve Model Context Protocol kullanılarak sunucuya bağlanmayı gösterir.

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

Bu örnek, yukarıdaki .NET örneğiyle aynı MCP sunucusu ve araç kaydını Java dilinde uygular.

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

Bu örnekte, Python'da bir MCP sunucusunun nasıl oluşturulacağı gösterilir. Ayrıca iki farklı araç oluşturma yöntemi sunulur.

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

Bu örnek, JavaScript'te MCP sunucusunun nasıl oluşturulacağını ve hava durumu ile ilgili iki aracın nasıl kaydedileceğini gösterir.

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

Bu JavaScript örneği, bir MCP istemcisinin sunucuya nasıl bağlanacağını, bir istem göndereceğini ve yapılan araç çağrılarını içeren yanıtı nasıl işleyeceğini gösterir.

## Güvenlik ve Yetkilendirme

MCP, protokol boyunca güvenlik ve yetkilendirmeyi yönetmek için bir dizi yerleşik kavram ve mekanizma içerir:

1. **Araç İzin Kontrolü**:  
   İstemciler, bir modelin oturum sırasında hangi araçları kullanabileceğini belirtebilir. Bu, yalnızca açıkça yetkilendirilmiş araçlara erişim sağlanmasını garanti eder ve istenmeyen veya güvensiz işlemler riskini azaltır. İzinler, kullanıcı tercihleri, organizasyon politikaları veya etkileşim bağlamına göre dinamik olarak yapılandırılabilir.

2. **Kimlik Doğrulama**:  
   Sunucular, araçlara

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek herhangi bir yanlış anlama veya yorum hatasından sorumlu değiliz.