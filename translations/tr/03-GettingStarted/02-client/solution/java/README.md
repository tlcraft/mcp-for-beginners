<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:10:55+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "tr"
}
-->
# MCP Java Client - Calculator Demo

Bu proje, bir MCP (Model Context Protocol) sunucusuna bağlanan ve onunla etkileşime giren bir Java istemcisinin nasıl oluşturulacağını gösterir. Bu örnekte, Bölüm 01'deki hesap makinesi sunucusuna bağlanacak ve çeşitli matematiksel işlemler yapacağız.

## Ön Koşullar

Bu istemciyi çalıştırmadan önce:

1. **Bölüm 01'deki Hesap Makinesi Sunucusunu Başlatın**:
   - Hesap makinesi sunucusu dizinine gidin: `03-GettingStarted/01-first-server/solution/java/`
   - Hesap makinesi sunucusunu derleyip çalıştırın:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Sunucu `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `` adresinde çalışıyor olmalı

SDKClient, aşağıdakileri gösteren bir Java uygulamasıdır:
- Server-Sent Events (SSE) taşıyıcısı kullanarak bir MCP sunucusuna bağlanma
- Sunucudan mevcut araçları listeleme
- Çeşitli hesap makinesi fonksiyonlarını uzaktan çağırma
- Yanıtları işleyip sonuçları gösterme

## Nasıl Çalışır

İstemci, Spring AI MCP çerçevesini kullanarak:

1. **Bağlantı Kurar**: Hesap makinesi sunucusuna bağlanmak için WebFlux SSE istemci taşıyıcısı oluşturur
2. **İstemciyi Başlatır**: MCP istemcisini kurar ve bağlantıyı sağlar
3. **Araçları Keşfeder**: Tüm mevcut hesap makinesi işlemlerini listeler
4. **İşlemleri Gerçekleştirir**: Örnek verilerle çeşitli matematiksel fonksiyonları çağırır
5. **Sonuçları Gösterir**: Her hesaplamanın sonucunu gösterir

## Proje Yapısı

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Temel Bağımlılıklar

Proje aşağıdaki temel bağımlılıkları kullanır:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Bu bağımlılık şunları sağlar:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - web tabanlı iletişim için SSE taşıyıcısı
- MCP protokol şemaları ve istek/yanıt türleri

## Projeyi Derleme

Projeyi Maven sarmalayıcısı ile derleyin:

```cmd
.\mvnw clean install
```

## İstemciyi Çalıştırma

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Not**: Hesap makinesi sunucusunun `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080` adresinde çalıştığından emin olun  
2. **Araçları Listele** - Mevcut tüm hesap makinesi işlemlerini gösterir  
3. **Hesaplamaları Yap**:  
   - Toplama: 5 + 3 = 8  
   - Çıkarma: 10 - 4 = 6  
   - Çarpma: 6 × 7 = 42  
   - Bölme: 20 ÷ 4 = 5  
   - Üs Alma: 2^8 = 256  
   - Karekök: √16 = 4  
   - Mutlak Değer: |-5.5| = 5.5  
   - Yardım: Mevcut işlemleri gösterir  

## Beklenen Çıktı

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Not**: Maven'in sonlarda kalan iş parçacıklarıyla ilgili uyarılar görmeniz normaldir - bu, reaktif uygulamalar için olağandır ve hata anlamına gelmez.

## Kodu Anlama

### 1. Taşıyıcı Kurulumu
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
Bu, hesap makinesi sunucusuna bağlanan bir SSE (Server-Sent Events) taşıyıcısı oluşturur.

### 2. İstemci Oluşturma
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
Senkron bir MCP istemcisi oluşturur ve bağlantıyı başlatır.

### 3. Araçları Çağırma
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
"a"=5.0 ve "b"=3.0 parametreleriyle "add" aracını çağırır.

## Sorun Giderme

### Sunucu Çalışmıyor
Bağlantı hatası alıyorsanız, Bölüm 01'deki hesap makinesi sunucusunun çalıştığından emin olun:  
```
Error: Connection refused
```  
**Çözüm**: Önce hesap makinesi sunucusunu başlatın.

### Port Zaten Kullanılıyor
Eğer 8080 portu meşgulse:  
```
Error: Address already in use
```  
**Çözüm**: 8080 portunu kullanan diğer uygulamaları durdurun veya sunucunun farklı bir port kullanmasını sağlayın.

### Derleme Hataları
Derleme hataları alırsanız:  
```cmd
.\mvnw clean install -DskipTests
```

## Daha Fazla Bilgi Edinin

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.