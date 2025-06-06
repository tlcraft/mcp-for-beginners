<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:24:14+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tr"
}
-->
# 📖 MCP Temel Kavramları: AI Entegrasyonu için Model Context Protocol'ü Ustalaşmak

Model Context Protocol (MCP), Büyük Dil Modelleri (LLM'ler) ile dış araçlar, uygulamalar ve veri kaynakları arasındaki iletişimi optimize eden güçlü ve standartlaştırılmış bir çerçevedir. Bu SEO uyumlu rehber, MCP'nin temel kavramlarını adım adım açıklayarak, istemci-sunucu mimarisini, temel bileşenlerini, iletişim mekanizmalarını ve uygulama en iyi uygulamalarını anlamanızı sağlayacak.

## Genel Bakış

Bu ders, Model Context Protocol (MCP) ekosistemini oluşturan temel mimari ve bileşenleri inceler. MCP etkileşimlerini güçlendiren istemci-sunucu mimarisi, önemli bileşenler ve iletişim mekanizmaları hakkında bilgi edineceksiniz.

## 👩‍🎓 Temel Öğrenme Hedefleri

Bu dersin sonunda:

- MCP istemci-sunucu mimarisini anlayacaksınız.
- Host'ların, Client'ların ve Server'ların rollerini ve sorumluluklarını tanımlayacaksınız.
- MCP'yi esnek bir entegrasyon katmanı yapan temel özellikleri analiz edeceksiniz.
- MCP ekosisteminde bilgi akışının nasıl gerçekleştiğini öğreneceksiniz.
- .NET, Java, Python ve JavaScript'te kod örnekleriyle pratik bilgiler edineceksiniz.

## 🔎 MCP Mimarisi: Daha Derin Bir Bakış

MCP ekosistemi, istemci-sunucu modeli üzerine kuruludur. Bu modüler yapı, AI uygulamalarının araçlar, veritabanları, API'ler ve bağlamsal kaynaklarla verimli şekilde etkileşim kurmasını sağlar. Gelin bu mimariyi temel bileşenlerine ayıralım.

### 1. Hosts

Model Context Protocol (MCP) içinde Host'lar, kullanıcıların protokolle etkileşime geçtiği ana arayüz olarak kritik bir rol oynar. Host'lar, MCP sunucularına bağlantı başlatan uygulamalar veya ortamlar olup, veri, araçlar ve promptlara erişim sağlar. Host örnekleri arasında Visual Studio Code gibi entegre geliştirme ortamları (IDE), Claude Desktop gibi AI araçları veya belirli görevler için özel olarak tasarlanmış ajanlar bulunur.

**Host'lar**, bağlantı başlatan LLM uygulamalarıdır. Bunlar:

- Yanıt üretmek için AI modellerini çalıştırır veya onlarla etkileşir.
- MCP sunucularıyla bağlantı kurar.
- Konuşma akışını ve kullanıcı arayüzünü yönetir.
- İzin ve güvenlik kısıtlamalarını kontrol eder.
- Veri paylaşımı ve araç çalıştırma için kullanıcı onayını yönetir.

### 2. Clients

Client'lar, Host'lar ile MCP sunucuları arasındaki etkileşimi kolaylaştıran temel bileşenlerdir. Aracı olarak işlev görürler ve Host'ların MCP sunucularının sunduğu işlevselliklere erişimini sağlarlar. MCP mimarisinde sorunsuz iletişim ve verimli veri alışverişi sağlamada önemli rol oynarlar.

**Client'lar**, host uygulaması içindeki bağlantı noktalarıdır. Bunlar:

- İstemcilere promptlar/talimatlar içeren istekler gönderir.
- Sunucularla yetenek pazarlığı yapar.
- Modellerden gelen araç çalıştırma isteklerini yönetir.
- Yanıtları işler ve kullanıcıya gösterir.

### 3. Servers

Server'lar, MCP client'larından gelen istekleri işlemek ve uygun yanıtları sağlamakla sorumludur. Veri alma, araç çalıştırma ve prompt oluşturma gibi çeşitli işlemleri yönetirler. Client ve Host arasındaki iletişimin verimli ve güvenilir olmasını sağlar, etkileşim sürecinin bütünlüğünü korur.

**Server'lar**, bağlam ve yetenek sağlayan servislerdir. Bunlar:

- Mevcut özellikleri (kaynaklar, promptlar, araçlar) kaydeder.
- Client'tan gelen araç çağrılarını alır ve yürütür.
- Model yanıtlarını geliştirmek için bağlamsal bilgi sunar.
- Çıktıları client'a geri gönderir.
- Gerekirse etkileşimler arasında durumu korur.

Server'lar, model yeteneklerini özel fonksiyonlarla genişletmek için herkes tarafından geliştirilebilir.

### 4. Server Özellikleri

Model Context Protocol (MCP) içindeki server'lar, client'lar, host'lar ve dil modelleri arasında zengin etkileşimler sağlayan temel yapı taşlarını sunar. Bu özellikler, yapılandırılmış bağlam, araçlar ve promptlar sunarak MCP'nin yeteneklerini artırmak üzere tasarlanmıştır.

MCP sunucuları aşağıdaki özellikleri sunabilir:

#### 📑 Kaynaklar

Model Context Protocol (MCP) içindeki kaynaklar, kullanıcılar veya AI modelleri tarafından kullanılabilecek çeşitli bağlam ve veri türlerini kapsar. Bunlar şunları içerir:

- **Bağlamsal Veri**: Kullanıcıların veya AI modellerinin karar verme ve görev yürütme için kullanabileceği bilgi ve bağlam.
- **Bilgi Tabanları ve Doküman Depoları**: Makaleler, kılavuzlar ve araştırma makaleleri gibi yapılandırılmış ve yapılandırılmamış veri koleksiyonları.
- **Yerel Dosyalar ve Veritabanları**: Cihazlarda veya veritabanlarında yerel olarak depolanan ve işleme veya analiz için erişilebilen veriler.
- **API'ler ve Web Servisleri**: Çeşitli çevrimiçi kaynaklar ve araçlarla entegrasyon sağlayan dış arayüzler ve servisler.

Bir kaynak örneği, aşağıdaki gibi erişilebilen bir veritabanı şeması veya dosya olabilir:

```text
file://log.txt
database://schema
```

### 🤖 Promptlar

Model Context Protocol (MCP) içindeki promptlar, kullanıcı iş akışlarını kolaylaştırmak ve iletişimi geliştirmek için tasarlanmış çeşitli ön tanımlı şablonlar ve etkileşim kalıplarını içerir. Bunlar şunları kapsar:

- **Şablonlanmış Mesajlar ve İş Akışları**: Kullanıcıları belirli görevler ve etkileşimler boyunca yönlendiren önceden yapılandırılmış mesajlar ve süreçler.
- **Ön Tanımlı Etkileşim Kalıpları**: Tutarlı ve verimli iletişimi kolaylaştıran standart eylem ve yanıt dizileri.
- **Özelleştirilmiş Konuşma Şablonları**: Belirli konuşma türleri için uyarlanabilir şablonlar, ilgili ve bağlama uygun etkileşimler sağlar.

Bir prompt şablonu şu şekilde görünebilir:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Araçlar

Model Context Protocol (MCP) içindeki araçlar, AI modelinin belirli görevleri gerçekleştirmek için kullanabileceği fonksiyonlardır. Bu araçlar, yapılandırılmış ve güvenilir işlemler sunarak AI modelinin yeteneklerini artırmak için tasarlanmıştır. Temel özellikler şunlardır:

- **AI modelinin çalıştırabileceği fonksiyonlar**: Araçlar, AI modelinin çağırabileceği yürütülebilir fonksiyonlardır.
- **Benzersiz İsim ve Açıklama**: Her aracın amacı ve işlevselliği detaylı şekilde açıklanan kendine özgü bir adı vardır.
- **Parametreler ve Çıktılar**: Araçlar belirli parametreleri kabul eder ve yapılandırılmış çıktılar döner, böylece tutarlı ve öngörülebilir sonuçlar sağlar.
- **Ayrık Fonksiyonlar**: Araçlar, web aramaları, hesaplamalar ve veritabanı sorguları gibi ayrı fonksiyonlar gerçekleştirir.

Bir araç örneği şöyle olabilir:

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

Model Context Protocol (MCP) içinde client'lar, sunuculara çeşitli önemli özellikler sunarak protokol içindeki genel işlevselliği ve etkileşimi artırır. Öne çıkan özelliklerden biri Sampling'dir.

### 👉 Sampling

- **Sunucu Başlatmalı Otonom Davranışlar**: Client'lar, sunucuların belirli eylemleri veya davranışları kendi kendine başlatmasını sağlar, böylece sistemin dinamik yetenekleri artırılır.
- **Yinelenen LLM Etkileşimleri**: Bu özellik, büyük dil modelleri (LLM) ile yinelenen etkileşimlere izin verir, daha karmaşık ve yinelemeli görev işleme sağlar.
- **Ek Model Tamamlamaları Talebi**: Sunucular, yanıtların kapsamlı ve bağlama uygun olmasını sağlamak için modelden ek tamamlamalar isteyebilir.

## MCP'de Bilgi Akışı

Model Context Protocol (MCP), host'lar, client'lar, sunucular ve modeller arasında yapılandırılmış bir bilgi akışı tanımlar. Bu akışı anlamak, kullanıcı isteklerinin nasıl işlendiğini ve dış araçlar ile verilerin model yanıtlarına nasıl entegre edildiğini netleştirir.

- **Host Bağlantıyı Başlatır**  
  Host uygulaması (örneğin bir IDE veya sohbet arayüzü), genellikle STDIO, WebSocket veya desteklenen başka bir taşıma yöntemiyle MCP sunucusuna bağlantı kurar.

- **Yetenek Pazarlığı**  
  Host içindeki client ile sunucu, destekledikleri özellikler, araçlar, kaynaklar ve protokol sürümleri hakkında bilgi alışverişi yapar. Bu, her iki tarafın oturum için hangi yeteneklerin mevcut olduğunu anlamasını sağlar.

- **Kullanıcı İsteği**  
  Kullanıcı host ile etkileşime girer (örneğin bir prompt veya komut girer). Host bu girdiyi toplar ve işlenmek üzere client'a iletir.

- **Kaynak veya Araç Kullanımı**  
  - Client, modelin anlayışını zenginleştirmek için sunucudan ek bağlam veya kaynaklar (dosyalar, veritabanı girdileri, bilgi tabanı makaleleri gibi) talep edebilir.
  - Model bir araç gerektiğine karar verirse (örneğin veri almak, hesaplama yapmak veya API çağırmak için), client araç adı ve parametreleri belirterek sunucuya araç çağrısı isteği gönderir.

- **Sunucu Yürütme**  
  Sunucu kaynak veya araç isteğini alır, gerekli işlemleri yapar (fonksiyon çalıştırma, veritabanı sorgulama, dosya alma gibi) ve sonuçları yapılandırılmış formatta client'a döner.

- **Yanıt Oluşturma**  
  Client, sunucudan gelen yanıtları (kaynak verileri, araç çıktıları vb.) mevcut model etkileşimine entegre eder. Model bu bilgiyi kullanarak kapsamlı ve bağlama uygun bir yanıt üretir.

- **Sonuç Sunumu**  
  Host, client'tan gelen nihai çıktıyı alır ve kullanıcıya sunar; genellikle model tarafından oluşturulan metin ile araç çalıştırma veya kaynak sorgulama sonuçlarını birlikte gösterir.

Bu akış, MCP'nin modelleri dış araçlar ve veri kaynaklarıyla sorunsuz şekilde bağlayarak gelişmiş, etkileşimli ve bağlama duyarlı AI uygulamalarını desteklemesini sağlar.

## Protokol Detayları

MCP (Model Context Protocol), [JSON-RPC 2.0](https://www.jsonrpc.org/) üzerine inşa edilmiştir ve host'lar, client'lar ve sunucular arasında standart, dil bağımsız mesaj formatı sağlar. Bu temel, farklı platformlar ve programlama dilleri arasında güvenilir, yapılandırılmış ve genişletilebilir etkileşimlere olanak tanır.

### Temel Protokol Özellikleri

MCP, JSON-RPC 2.0'ı araç çağrısı, kaynak erişimi ve prompt yönetimi için ek kurallarla genişletir. Birden fazla taşıma katmanını (STDIO, WebSocket, SSE) destekler ve bileşenler arasında güvenli, genişletilebilir ve dil bağımsız iletişim sağlar.

#### 🧢 Temel Protokol

- **JSON-RPC Mesaj Formatı**: Tüm istekler ve yanıtlar JSON-RPC 2.0 spesifikasyonuna uygundur, metod çağrıları, parametreler, sonuçlar ve hata yönetimi için tutarlı yapı sağlar.
- **Durumlu Bağlantılar**: MCP oturumları, çoklu istekler boyunca durumu korur, devam eden konuşmaları, bağlam birikimini ve kaynak yönetimini destekler.
- **Yetenek Pazarlığı**: Bağlantı kurulurken client ve sunucu, destekledikleri özellikler, protokol sürümleri, mevcut araçlar ve kaynaklar hakkında bilgi alışverişi yapar. Bu, her iki tarafın birbirinin yeteneklerini anlamasını ve buna göre uyum sağlamasını sağlar.

#### ➕ Ek Yardımcılar

MCP'nin geliştirici deneyimini artırmak ve gelişmiş senaryoları mümkün kılmak için sunduğu ek yardımcılar ve protokol genişletmeleri şunlardır:

- **Konfigürasyon Seçenekleri**: MCP, her etkileşime uyarlanmış araç izinleri, kaynak erişimi ve model ayarları gibi oturum parametrelerinin dinamik yapılandırılmasına izin verir.
- **İlerleme Takibi**: Uzun süren işlemler ilerleme güncellemeleri raporlayabilir, böylece kullanıcı arayüzleri daha duyarlı olur ve karmaşık görevlerde deneyim iyileşir.
- **İstek İptali**: Client'lar, artık gerekli olmayan veya uzun süren işlemleri kullanıcıların kesebilmesi için devam eden istekleri iptal edebilir.
- **Hata Raporlama**: Standartlaştırılmış hata mesajları ve kodları, sorunların teşhisini, hataların zarifçe yönetilmesini ve kullanıcılar ile geliştiricilere eyleme dönüştürülebilir geri bildirim sağlamayı kolaylaştırır.
- **Kayıt Tutma**: Hem client hem de sunucu, protokol etkileşimlerinin denetimi, hata ayıklama ve izlenmesi için yapılandırılmış loglar üretebilir.

Bu protokol özelliklerinden yararlanarak, MCP dil modelleri ile dış araçlar veya veri kaynakları arasında sağlam, güvenli ve esnek iletişim sağlar.

### 🔐 Güvenlik Hususları

MCP uygulamaları, güvenli ve güvenilir etkileşimler için birkaç temel güvenlik ilkesine uymalıdır:

- **Kullanıcı Onayı ve Kontrolü**: Herhangi bir veri erişimi veya işlem yapılmadan önce kullanıcıların açık onayı alınmalıdır. Kullanıcılar, hangi verilerin paylaşıldığı ve hangi işlemlerin yetkilendirildiği üzerinde net kontrole sahip olmalı, bunu gözden geçirme ve onaylama için sezgisel kullanıcı arayüzleri desteklemelidir.

- **Veri Gizliliği**: Kullanıcı verileri yalnızca açık onayla paylaşılmalı ve uygun erişim kontrolleriyle korunmalıdır. MCP uygulamaları, yetkisiz veri iletimini önlemeli ve tüm etkileşimlerde gizliliğin korunmasını sağlamalıdır.

- **Araç Güvenliği**: Herhangi bir araç çağrılmadan önce açık kullanıcı onayı gereklidir. Kullanıcılar, her aracın işlevselliğini net şekilde anlamalı ve istenmeyen veya güvensiz araç çalıştırmayı önlemek için sağlam güvenlik sınırları uygulanmalıdır.

Bu ilkeler takip edilerek, MCP kullanıcı güveni, gizliliği ve güvenliğini tüm protokol etkileşimlerinde korur.

## Kod Örnekleri: Temel Bileşenler

Aşağıda, çeşitli popüler programlama dillerinde MCP sunucu bileşenleri ve araçlarının nasıl uygulanacağını gösteren kod örnekleri yer almaktadır.

### .NET Örneği: Araçlarla Basit Bir MCP Sunucusu Oluşturma

Burada, özel araçlarla basit bir MCP sunucusunun nasıl oluşturulacağını gösteren pratik bir .NET kod örneği bulunmaktadır. Bu örnek, araçların tanımlanması ve kaydedilmesi, isteklerin işlenmesi ve Model Context Protocol kullanılarak sunucunun bağlanmasını göstermektedir.

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

Bu örnek, yukarıdaki .NET örneği ile aynı MCP sunucu ve araç kayıt işlemini Java dilinde göstermektedir.

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

Bu örnekte, Python'da bir MCP sunucusunun nasıl oluşturulacağı gösterilmektedir. Ayrıca araç oluşturmanın iki farklı yolu sunulmaktadır.

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

### JavaScript Örneği: MCP Sunucusu Oluşturma

Bu örnek, JavaScript'te MCP sunucusu oluşturmayı ve iki hava durumu ile ilgili aracın kaydını göstermektedir.

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

Bu JavaScript örneği, bir MCP client'ın sunucuya bağlanmasını, bir prompt göndermesini ve yapılan araç çağrılarını da içeren yanıtı işlemesini göstermektedir.

## Güvenlik ve Yetkilendirme

MCP, protokol boyunca güvenlik ve yetkilendirmeyi yönetmek için birkaç yerleşik kavram ve mekanizma içerir:

1. **Araç İzin Kontrolü**  
  Client'lar, modelin oturum sırasında hangi araçları kullanabileceğini belirtebilir. Bu, yalnızca açıkça yetkilendirilmiş araçların erişilebilir olmasını sağlar ve istenmeyen veya güvensiz işlemler riskini azaltır. İzinler, kullanıcı tercihleri, organizasyon politikaları veya etkileşim bağlamına göre dinamik olarak yapılandırılabilir.

2. **Kimlik Doğrulama**  
  Sunucular, araçlara, kaynaklara veya hassas işlemlere erişim öncesinde kimlik doğrulama talep edebilir. Bu, API anahtarları, OAuth tokenları veya diğer kimlik doğrulama şemalarını içerebilir. Doğru kimlik doğrulama, yalnızca güvenilen client ve kullanıcıların sunucu tarafı yetenekleri çağırmasını sağlar.

3. **Doğrulama**  
  Tüm araç çağrıları için parametre doğrulaması uygulanır.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum farklılıklarından sorumlu değiliz.