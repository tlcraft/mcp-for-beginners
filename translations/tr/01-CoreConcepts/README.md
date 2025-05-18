<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:14:45+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tr"
}
-->
# 📖 MCP Temel Kavramları: Yapay Zeka Entegrasyonu için Model Context Protocol'ü Ustalaşmak

Model Context Protocol (MCP), Büyük Dil Modelleri (LLM'ler) ile dış araçlar, uygulamalar ve veri kaynakları arasındaki iletişimi optimize eden güçlü, standartlaştırılmış bir çerçevedir. Bu SEO uyumlu rehber, MCP'nin istemci-sunucu mimarisi, temel bileşenleri, iletişim mekanizmaları ve uygulama en iyi uygulamalarını anlamanızı sağlayacak.

## Genel Bakış

Bu ders, Model Context Protocol (MCP) ekosistemini oluşturan temel mimari ve bileşenleri keşfeder. MCP etkileşimlerini güçlendiren istemci-sunucu mimarisi, ana bileşenler ve iletişim mekanizmalarını öğreneceksiniz.

## 👩‍🎓 Temel Öğrenme Hedefleri

Bu dersin sonunda:

- MCP istemci-sunucu mimarisini anlayacaksınız.
- Hosts, Clients ve Servers’ın rollerini ve sorumluluklarını tanımlayacaksınız.
- MCP’yi esnek bir entegrasyon katmanı yapan temel özellikleri analiz edeceksiniz.
- MCP ekosistemi içindeki bilgi akışını öğreneceksiniz.
- .NET, Java, Python ve JavaScript ile kod örnekleri üzerinden pratik bilgiler edineceksiniz.

## 🔎 MCP Mimarisi: Daha Derin Bir Bakış

MCP ekosistemi, istemci-sunucu modeli üzerine kuruludur. Bu modüler yapı, yapay zeka uygulamalarının araçlar, veritabanları, API'ler ve bağlamsal kaynaklarla verimli şekilde etkileşim kurmasını sağlar. Bu mimariyi temel bileşenlerine ayıralım.

### 1. Hosts

Model Context Protocol (MCP) içinde Hosts, kullanıcıların protokolle etkileşime geçtiği birincil arayüz olarak kritik bir rol oynar. Hosts, MCP sunucularıyla bağlantı kurarak veri, araç ve istemlere erişim sağlayan uygulamalar veya ortamlardır. Hosts örnekleri arasında Visual Studio Code gibi entegre geliştirme ortamları (IDE'ler), Claude Desktop gibi yapay zeka araçları veya belirli görevler için özel olarak tasarlanmış ajanlar bulunur.

**Hosts**, bağlantı başlatan LLM uygulamalarıdır. Şunları yaparlar:

- Yanıt üretmek için yapay zeka modellerini çalıştırır veya onlarla etkileşime girerler.
- MCP sunucularıyla bağlantı kurarlar.
- Konuşma akışını ve kullanıcı arayüzünü yönetirler.
- İzin ve güvenlik kısıtlamalarını kontrol ederler.
- Veri paylaşımı ve araç çalıştırma için kullanıcı onayını yönetirler.

### 2. Clients

Clients, Hosts ile MCP sunucuları arasındaki etkileşimi kolaylaştıran temel bileşenlerdir. Clients, Hosts’un MCP sunucularının sunduğu işlevleri erişip kullanabilmesini sağlayan aracılar olarak görev yapar. MCP mimarisinde sorunsuz iletişim ve verimli veri alışverişi sağlamada önemli bir rol oynarlar.

**Clients**, host uygulaması içinde bağlayıcılardır. Şunları yaparlar:

- Sunuculara istemler gönderirler (promptlar/talimatlar ile).
- Sunucularla yetenek müzakeresi yaparlar.
- Modellerden gelen araç çalıştırma isteklerini yönetirler.
- Yanıtları işler ve kullanıcıya gösterirler.

### 3. Servers

Servers, MCP clients'tan gelen istekleri işlemek ve uygun yanıtları sağlamakla sorumludur. Veri alma, araç çalıştırma ve istem oluşturma gibi çeşitli işlemleri yönetirler. Clients ve Hosts arasındaki iletişimin verimli ve güvenilir olmasını sağlar, etkileşim sürecinin bütünlüğünü korurlar.

**Servers**, bağlam ve yetenek sağlayan hizmetlerdir. Şunları yaparlar:

- Mevcut özellikleri kaydederler (kaynaklar, istemler, araçlar).
- Client'tan gelen araç çağrılarını alır ve çalıştırırlar.
- Model yanıtlarını geliştirmek için bağlamsal bilgi sağlarlar.
- Çıktıları client'a geri döndürürler.
- Gerekirse etkileşimler arasında durumu korurlar.

Servers, model yeteneklerini özel işlevsellikle genişletmek için herkes tarafından geliştirilebilir.

### 4. Server Özellikleri

Model Context Protocol (MCP) sunucuları, clients, hosts ve dil modelleri arasında zengin etkileşimleri mümkün kılan temel yapı taşlarını sağlar. Bu özellikler, MCP'nin yeteneklerini yapılandırılmış bağlam, araçlar ve istemler sunarak artırmak üzere tasarlanmıştır.

MCP sunucuları aşağıdaki özelliklerden herhangi birini sunabilir:

#### 📑 Kaynaklar

Model Context Protocol (MCP) içindeki kaynaklar, kullanıcıların veya yapay zeka modellerinin kullanabileceği çeşitli bağlam ve veri türlerini kapsar. Bunlar şunları içerir:

- **Bağlamsal Veriler**: Kullanıcıların veya yapay zeka modellerinin karar verme ve görev yürütme için kullanabileceği bilgi ve bağlam.
- **Bilgi Tabanları ve Doküman Depoları**: Makaleler, kılavuzlar ve araştırma makaleleri gibi yapılandırılmış ve yapılandırılmamış veri koleksiyonları, değerli içgörüler ve bilgiler sağlar.
- **Yerel Dosyalar ve Veritabanları**: Cihazlarda veya veritabanlarında yerel olarak depolanan, işleme ve analiz için erişilebilir veriler.
- **API’ler ve Web Servisleri**: Çeşitli çevrimiçi kaynaklar ve araçlarla entegrasyon sağlayan ek veri ve işlevsellik sunan dış arayüzler ve servisler.

Bir kaynak örneği, şöyle erişilebilen bir veritabanı şeması veya dosya olabilir:

```text
file://log.txt
database://schema
```

### 🤖 İstemler

Model Context Protocol (MCP) içindeki istemler, kullanıcı iş akışlarını kolaylaştırmak ve iletişimi geliştirmek için tasarlanmış çeşitli ön tanımlı şablonlar ve etkileşim desenlerini içerir. Bunlar şunları kapsar:

- **Şablonlanmış Mesajlar ve İş Akışları**: Kullanıcıları belirli görevler ve etkileşimler boyunca yönlendiren önceden yapılandırılmış mesajlar ve süreçler.
- **Ön Tanımlı Etkileşim Desenleri**: Tutarlı ve verimli iletişimi kolaylaştıran standartlaştırılmış eylem ve yanıt dizileri.
- **Özel Konuşma Şablonları**: Belirli konuşma türleri için uyarlanabilir şablonlar, ilgili ve bağlamsal olarak uygun etkileşimler sağlar.

Bir istem şablonu şöyle görünebilir:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Araçlar

Model Context Protocol (MCP) içindeki araçlar, yapay zeka modelinin belirli görevleri gerçekleştirmek için çalıştırabileceği işlevlerdir. Bu araçlar, yapay zeka modelinin yeteneklerini yapılandırılmış ve güvenilir işlemler sağlayarak artırmak üzere tasarlanmıştır. Temel özellikler şunlardır:

- **Yapay Zeka Modelinin Çalıştırabileceği Fonksiyonlar**: Araçlar, yapay zeka modelinin çağırabileceği yürütülebilir fonksiyonlardır.
- **Benzersiz İsim ve Açıklama**: Her aracın amacı ve işlevselliği açıklayan ayrı bir adı ve detaylı açıklaması vardır.
- **Parametreler ve Çıktılar**: Araçlar belirli parametreleri kabul eder ve yapılandırılmış çıktılar döndürür, böylece tutarlı ve öngörülebilir sonuçlar sağlanır.
- **Ayrık Fonksiyonlar**: Araçlar web aramaları, hesaplamalar ve veritabanı sorguları gibi ayrı işlevleri yerine getirir.

Bir araç örneği şöyle olabilir:

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

## Client Özellikleri

Model Context Protocol (MCP) içinde clients, sunuculara çeşitli temel özellikler sunarak protokol içindeki genel işlevselliği ve etkileşimi artırır. Öne çıkan özelliklerden biri Sampling’dir.

### 👉 Sampling

- **Sunucu Tarafından Başlatılan Ajan Davranışları**: Clients, sunucuların belirli eylemleri veya davranışları otonom olarak başlatmasını sağlar, sistemin dinamik yeteneklerini artırır.
- **Yinelenen LLM Etkileşimleri**: Bu özellik, büyük dil modelleri (LLM'ler) ile yinelenen etkileşimlere olanak tanır, görevlerin daha karmaşık ve yinelemeli işlenmesini sağlar.
- **Ek Model Tamamlamaları Talebi**: Sunucular, modelden ek tamamlamalar talep edebilir, böylece yanıtların kapsamlı ve bağlamsal olarak uygun olması sağlanır.

## MCP'de Bilgi Akışı

Model Context Protocol (MCP), hosts, clients, servers ve modeller arasında yapılandırılmış bir bilgi akışı tanımlar. Bu akışı anlamak, kullanıcı isteklerinin nasıl işlendiğini ve dış araçlar ile verilerin model yanıtlarına nasıl entegre edildiğini netleştirir.

- **Host Bağlantı Başlatır**  
  Host uygulaması (örneğin bir IDE veya sohbet arayüzü), genellikle STDIO, WebSocket veya desteklenen başka bir taşıma yöntemiyle MCP sunucusuna bağlantı kurar.

- **Yetenek Müzakeresi**  
  Host içindeki client ile sunucu, destekledikleri özellikler, araçlar, kaynaklar ve protokol sürümleri hakkında bilgi alışverişi yapar. Bu, her iki tarafın oturum için hangi yeteneklerin mevcut olduğunu anlamasını sağlar.

- **Kullanıcı İsteği**  
  Kullanıcı host ile etkileşime girer (örneğin bir istem veya komut girer). Host bu girdiyi toplar ve işleme için client’a iletir.

- **Kaynak veya Araç Kullanımı**  
  - Client, modelin anlayışını zenginleştirmek için sunucudan ek bağlam veya kaynaklar (dosyalar, veritabanı kayıtları veya bilgi tabanı makaleleri gibi) talep edebilir.  
  - Model bir aracın gerekli olduğuna karar verirse (örneğin veri çekmek, hesaplama yapmak veya API çağrısı yapmak için), client araç çağrısı isteğini sunucuya gönderir; araç adı ve parametreleri belirtilir.

- **Sunucu Çalıştırması**  
  Sunucu kaynak veya araç isteğini alır, gerekli işlemleri yapar (fonksiyon çalıştırma, veritabanı sorgulama veya dosya alma gibi) ve sonuçları yapılandırılmış biçimde client’a döner.

- **Yanıt Oluşturma**  
  Client, sunucunun yanıtlarını (kaynak verileri, araç çıktıları vb.) devam eden model etkileşimine entegre eder. Model, kapsamlı ve bağlamsal olarak uygun bir yanıt üretmek için bu bilgileri kullanır.

- **Sonucun Sunumu**  
  Host, client’tan aldığı nihai çıktıyı kullanıcıya sunar; genellikle modelin oluşturduğu metin ve araç çalıştırma ya da kaynak sorgulama sonuçları birlikte gösterilir.

Bu akış, MCP’nin modelleri dış araçlar ve veri kaynaklarıyla kesintisiz bağlayarak gelişmiş, etkileşimli ve bağlam farkındalığı yüksek yapay zeka uygulamalarını desteklemesini sağlar.

## Protokol Detayları

MCP (Model Context Protocol), hosts, clients ve servers arasında iletişim için standartlaştırılmış, dil bağımsız bir mesaj formatı sağlayan [JSON-RPC 2.0](https://www.jsonrpc.org/) üzerine inşa edilmiştir. Bu temel, farklı platformlar ve programlama dilleri arasında güvenilir, yapılandırılmış ve genişletilebilir etkileşimlere olanak tanır.

### Temel Protokol Özellikleri

MCP, araç çağrısı, kaynak erişimi ve istem yönetimi için ek kurallarla JSON-RPC 2.0’ı genişletir. Çoklu taşıma katmanlarını (STDIO, WebSocket, SSE) destekler ve bileşenler arasında güvenli, genişletilebilir ve dil bağımsız iletişim sağlar.

#### 🧢 Temel Protokol

- **JSON-RPC Mesaj Formatı**: Tüm istek ve yanıtlar JSON-RPC 2.0 spesifikasyonuna uygun olarak yapılandırılır; metod çağrıları, parametreler, sonuçlar ve hata yönetimi tutarlı biçimdedir.
- **Durumlu Bağlantılar**: MCP oturumları, birden fazla istek boyunca durumu korur; devam eden konuşmaları, bağlam birikimini ve kaynak yönetimini destekler.
- **Yetenek Müzakeresi**: Bağlantı kurulurken, clients ve servers destekledikleri özellikler, protokol sürümleri, mevcut araçlar ve kaynaklar hakkında bilgi alışverişi yapar. Bu, her iki tarafın birbirinin yeteneklerini anlamasını ve uyum sağlamasını sağlar.

#### ➕ Ek Yardımcılar

MCP, geliştirici deneyimini artırmak ve gelişmiş senaryoları mümkün kılmak için aşağıdaki ek yardımcılar ve protokol uzantılarını sunar:

- **Konfigürasyon Seçenekleri**: MCP, oturum parametrelerinin dinamik yapılandırılmasına izin verir; araç izinleri, kaynak erişimi ve model ayarları gibi etkileşimlere özel ayarlamalar yapılabilir.
- **İlerleme Takibi**: Uzun süren işlemler ilerleme güncellemeleri raporlayabilir; bu sayede kullanıcı arayüzleri daha duyarlı olur ve karmaşık görevlerde kullanıcı deneyimi iyileşir.
- **İstek İptali**: Clients, devam eden istekleri iptal edebilir; kullanıcılar artık gerek kalmayan veya çok uzun süren işlemleri durdurabilir.
- **Hata Raporlama**: Standartlaştırılmış hata mesajları ve kodları, sorunların teşhis edilmesini, hataların zarifçe yönetilmesini ve kullanıcılar ile geliştiricilere uygulanabilir geri bildirim sağlanmasını kolaylaştırır.
- **Kayıt Tutma**: Hem clients hem de servers, denetim, hata ayıklama ve protokol etkileşimlerinin izlenmesi için yapılandırılmış loglar üretebilir.

Bu protokol özellikleri sayesinde MCP, dil modelleri ile dış araçlar veya veri kaynakları arasında sağlam, güvenli ve esnek iletişim sağlar.

### 🔐 Güvenlik Hususları

MCP uygulamaları, güvenli ve güvenilir etkileşimler sağlamak için birkaç temel güvenlik ilkesine uymalıdır:

- **Kullanıcı Onayı ve Kontrolü**: Herhangi bir veri erişimi veya işlem gerçekleştirilmeden önce kullanıcıdan açık onay alınmalıdır. Kullanıcılar, hangi verilerin paylaşıldığı ve hangi işlemlerin yetkilendirildiği üzerinde net kontrole sahip olmalı; bu işlemleri gözden geçirme ve onaylama için sezgisel kullanıcı arayüzleri desteklenmelidir.

- **Veri Gizliliği**: Kullanıcı verileri yalnızca açık onayla paylaşılmalı ve uygun erişim kontrolleriyle korunmalıdır. MCP uygulamaları, yetkisiz veri iletimine karşı koruma sağlamalı ve gizliliğin tüm etkileşimler boyunca sürdürülmesini temin etmelidir.

- **Araç Güvenliği**: Herhangi bir araç çağrılmadan önce açık kullanıcı onayı gereklidir. Kullanıcılar, her aracın işlevselliğini net şekilde anlamalı ve istenmeyen veya güvensiz araç çalıştırmalarını önlemek için sağlam güvenlik sınırları uygulanmalıdır.

Bu ilkeler takip edilerek, MCP kullanıcı güveni, gizliliği ve güvenliğini tüm protokol etkileşimlerinde korur.

## Kod Örnekleri: Temel Bileşenler

Aşağıda, popüler programlama dillerinde MCP sunucu bileşenleri ve araçlarının nasıl uygulanacağını gösteren kod örnekleri bulunmaktadır.

### .NET Örneği: Araçlarla Basit Bir MCP Sunucusu Oluşturma

İşte özel araçlar tanımlamayı ve kaydetmeyi, istekleri işlemeyi ve Model Context Protocol kullanarak sunucu bağlantısı kurmayı gösteren pratik bir .NET kod örneği.

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

Bu örnek, yukarıdaki .NET örneğiyle aynı MCP sunucu ve araç kaydını Java ile uygular.

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

Bu örnekte, Python’da bir MCP sunucusunun nasıl kurulacağı gösterilir. Ayrıca iki farklı araç oluşturma yöntemi sunulur.

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

Bu örnek, JavaScript ile MCP sunucusu oluşturmayı ve hava durumu ile ilgili iki aracın kaydını gösterir.

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

Bu JavaScript örneği, bir MCP client’ın sunucuya bağlanmasını, bir istem göndermesini ve yapılan araç çağrılarını içeren yanıtı işlemesini gösterir.

## Güvenlik ve Yetkilendirme

MCP, protokol boyunca güvenlik ve yetkilendirmeyi yönetmek için birkaç yerleşik kavram ve mekanizma içerir:

1. **Araç İzin Kontrolü**:  
  Clients, bir modelin oturum sırasında hangi araçları kullanabileceğini belirtebilir. Bu, yalnızca açıkça yetkilendirilmiş araçların erişilebilir olmasını sağlar ve istenmeyen veya güvensiz işlemlerin riskini azaltır. İzinler, kullanıcı tercihleri, organizasyon politikaları veya etkileşim bağlamına göre dinamik olarak yapılandırılabilir.

2. **Kimlik Doğrulama**:  
  Sunucular, araçlara, kaynaklara veya hassas işlemlere erişim öncesinde kimlik doğrulama isteyebilir. Bu API anahtarları, OAuth token’ları veya diğer kimlik doğrulama şemalarını içerebilir. Doğru kimlik doğrulama, yalnızca güvenilir client ve kullanıcıların sunucu tarafı yetenekleri çağırmasını sağlar.

3. **Doğrulama**

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.