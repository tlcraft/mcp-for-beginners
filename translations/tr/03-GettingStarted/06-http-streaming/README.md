<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:05:49+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tr"
}
-->
# Model Context Protocol (MCP) ile HTTPS Akışı

Bu bölüm, Model Context Protocol (MCP) kullanarak HTTPS üzerinden güvenli, ölçeklenebilir ve gerçek zamanlı akışın nasıl uygulanacağına dair kapsamlı bir rehber sunar. Akışın motivasyonu, mevcut taşıma mekanizmaları, MCP’de akışlı HTTP’nin nasıl uygulanacağı, güvenlik en iyi uygulamaları, SSE’den geçiş ve kendi akışlı MCP uygulamalarınızı oluşturmak için pratik rehberlik konularını kapsar.

## MCP’de Taşıma Mekanizmaları ve Akış

Bu bölüm, MCP’de mevcut farklı taşıma mekanizmalarını ve bunların istemci ile sunucu arasında gerçek zamanlı iletişim için akış yeteneklerini nasıl sağladığını inceler.

### Taşıma Mekanizması Nedir?

Taşıma mekanizması, istemci ile sunucu arasında verinin nasıl değiş tokuş edildiğini tanımlar. MCP, farklı ortamlar ve gereksinimler için birden fazla taşıma türünü destekler:

- **stdio**: Standart giriş/çıkış, yerel ve CLI tabanlı araçlar için uygundur. Basit ama web veya bulut için uygun değildir.
- **SSE (Server-Sent Events)**: Sunucuların HTTP üzerinden istemcilere gerçek zamanlı güncellemeler göndermesine olanak tanır. Web arayüzleri için iyidir ancak ölçeklenebilirlik ve esneklik açısından sınırlıdır.
- **Streamable HTTP**: Bildirimleri destekleyen ve daha iyi ölçeklenebilirlik sunan modern HTTP tabanlı akış taşıması. Çoğu üretim ve bulut senaryosu için önerilir.

### Karşılaştırma Tablosu

Aşağıdaki karşılaştırma tablosu bu taşıma mekanizmalarının farklarını anlamanıza yardımcı olur:

| Taşıma            | Gerçek Zamanlı Güncellemeler | Akış       | Ölçeklenebilirlik | Kullanım Alanı           |
|-------------------|------------------------------|------------|-------------------|-------------------------|
| stdio             | Hayır                        | Hayır      | Düşük             | Yerel CLI araçları      |
| SSE               | Evet                         | Evet       | Orta              | Web, gerçek zamanlı güncellemeler |
| Streamable HTTP   | Evet                         | Evet       | Yüksek            | Bulut, çoklu istemci    |

> **Tip:** Doğru taşıma yöntemini seçmek performans, ölçeklenebilirlik ve kullanıcı deneyimini etkiler. Modern, ölçeklenebilir ve bulut dostu uygulamalar için **Streamable HTTP** önerilir.

Önceki bölümlerde gösterilen stdio ve SSE taşıma mekanizmalarına ve bu bölümde ele alınan Streamable HTTP taşımasına dikkat edin.

## Akış: Kavramlar ve Motivasyon

Akışın temel kavramlarını ve motivasyonlarını anlamak, etkili gerçek zamanlı iletişim sistemleri oluşturmak için önemlidir.

**Akış**, ağ programlamada verinin tamamının hazır olmasını beklemek yerine küçük, yönetilebilir parçalar halinde veya olay dizisi olarak gönderilip alınmasına olanak tanıyan bir tekniktir. Özellikle şunlar için faydalıdır:

- Büyük dosyalar veya veri setleri.
- Gerçek zamanlı güncellemeler (örneğin, sohbet, ilerleme çubukları).
- Kullanıcıyı bilgilendirmek istediğiniz uzun süreli hesaplamalar.

Akış hakkında bilmeniz gerekenler:

- Veri kademeli olarak teslim edilir, hepsi birden değil.
- İstemci veri geldikçe işleyebilir.
- Algılanan gecikmeyi azaltır ve kullanıcı deneyimini iyileştirir.

### Neden Akış Kullanılır?

Akış kullanmanın nedenleri şunlardır:

- Kullanıcılar sadece sonunda değil, hemen geri bildirim alır.
- Gerçek zamanlı uygulamalar ve duyarlı kullanıcı arayüzleri sağlar.
- Ağ ve hesaplama kaynaklarının daha verimli kullanımı.

### Basit Örnek: HTTP Akış Sunucusu ve İstemcisi

Akışın nasıl uygulanabileceğine dair basit bir örnek:

<details>
<summary>Python</summary>

**Sunucu (Python, FastAPI ve StreamingResponse kullanarak):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**İstemci (Python, requests kullanarak):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Bu örnek, tüm mesajlar hazır olana kadar beklemek yerine sunucunun mesajları hazır oldukça istemciye göndermesini gösterir.

**Nasıl çalışır:**
- Sunucu her mesajı hazır olduğunda gönderir.
- İstemci gelen her parçayı alır ve yazdırır.

**Gereksinimler:**
- Sunucu, akış yanıtı kullanmalıdır (örneğin, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Sunucu (Java, Spring Boot ve Server-Sent Events kullanarak):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**İstemci (Java, Spring WebFlux WebClient kullanarak):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Java Uygulama Notları:**
- Spring Boot’un reaktif yığını ile `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) ile MCP üzerinden akış arasında seçim.

- **Basit akış ihtiyaçları için:** Klasik HTTP akışı uygulaması daha basittir ve temel akış ihtiyaçları için yeterlidir.

- **Karmaşık, etkileşimli uygulamalar için:** MCP akışı, bildirimler ve nihai sonuçlar arasında ayrım yaparak daha yapılandırılmış ve zengin meta veri sunar.

- **Yapay zeka uygulamaları için:** MCP’nin bildirim sistemi, kullanıcıları ilerleme hakkında bilgilendirmek istediğiniz uzun süreli AI görevleri için özellikle faydalıdır.

## MCP’de Akış

Şimdiye kadar klasik akış ile MCP akışı arasındaki farklara dair öneriler ve karşılaştırmalar gördünüz. MCP’de akıştan tam olarak nasıl yararlanabileceğinizi detaylandıralım.

MCP çerçevesinde akışın nasıl çalıştığını anlamak, uzun süren işlemler sırasında kullanıcılara gerçek zamanlı geri bildirim sağlayan duyarlı uygulamalar oluşturmak için gereklidir.

MCP’de akış, ana yanıtın parçalara bölünerek gönderilmesi değil, bir aracın isteği işlerken istemciye **bildirimler** göndermesiyle ilgilidir. Bu bildirimler ilerleme güncellemeleri, günlükler veya diğer olayları içerebilir.

### Nasıl Çalışır?

Ana sonuç hâlâ tek bir yanıt olarak gönderilir. Ancak bildirimler işleme sırasında ayrı mesajlar olarak gönderilebilir ve böylece istemci gerçek zamanlı olarak güncellenir. İstemci bu bildirimleri işleyip görüntüleyebilmelidir.

## Bildirim Nedir?

"Bildirim" dedik, MCP bağlamında bu ne anlama geliyor?

Bildirim, uzun süren bir işlem sırasında sunucudan istemciye ilerleme, durum veya diğer olaylar hakkında bilgi vermek için gönderilen mesajdır. Bildirimler şeffaflığı ve kullanıcı deneyimini artırır.

Örneğin, istemcinin sunucu ile ilk el sıkışma tamamlandığında bir bildirim göndermesi gerekir.

Bir bildirim JSON mesajı şeklindedir:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Bildirimler MCP’de ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) adlı bir konuya aittir.

Logging’in çalışması için sunucunun bunu özellik/yetenek olarak etkinleştirmesi gerekir:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kullanılan SDK’ya bağlı olarak, logging varsayılan olarak etkin olabilir veya sunucu yapılandırmanızda açıkça etkinleştirmeniz gerekebilir.

Bildirimlerin farklı türleri vardır:

| Seviye    | Açıklama                      | Örnek Kullanım Durumu          |
|-----------|-------------------------------|-------------------------------|
| debug     | Detaylı hata ayıklama bilgisi | Fonksiyon giriş/çıkış noktaları|
| info      | Genel bilgilendirici mesajlar | İşlem ilerleme güncellemeleri  |
| notice    | Normal ama önemli olaylar      | Konfigürasyon değişiklikleri   |
| warning   | Uyarı durumları               | Kullanımdan kalkmış özellikler|
| error     | Hata durumları               | İşlem başarısızlıkları         |
| critical  | Kritik durumlar              | Sistem bileşeni arızaları      |
| alert     | Hemen müdahale gerektiren durumlar | Veri bozulması tespiti    |
| emergency | Sistem kullanılamaz durumda  | Tam sistem arızası             |

## MCP’de Bildirimlerin Uygulanması

MCP’de bildirimleri uygulamak için hem sunucu hem de istemci tarafını gerçek zamanlı güncellemeleri işleyip gösterecek şekilde hazırlamanız gerekir. Bu, uzun süren işlemler sırasında uygulamanızın kullanıcıya anında geri bildirim sağlamasına olanak tanır.

### Sunucu Tarafı: Bildirim Gönderme

Sunucu tarafıyla başlayalım. MCP’de, istekleri işlerken bildirim gönderebilen araçlar tanımlarsınız. Sunucu, istemciye mesaj göndermek için genellikle `ctx` olan context nesnesini kullanır.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Önceki örnekte, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` taşıma yöntemi kullanılmıştır:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

Bu .NET örneğinde, `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` yöntemi bilgilendirici mesajlar göndermek için kullanılır.

Bildirimleri etkinleştirmek için .NET MCP sunucunuzda akış taşıması kullandığınızdan emin olun:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### İstemci Tarafı: Bildirim Alma

İstemci, gelen bildirimleri işleyip görüntülemek için bir mesaj işleyici uygulamalıdır.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

Önceki kodda, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` gelen bildirimleri işlemek için kullanılır.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

Bu .NET örneğinde, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) kullanılır ve istemci bildirimleri işlemek için mesaj işleyici uygular.

## İlerleme Bildirimleri ve Senaryolar

Bu bölüm, MCP’de ilerleme bildirimleri kavramını, neden önemli olduklarını ve Streamable HTTP kullanarak nasıl uygulanacağını açıklar. Ayrıca, bilgilerinizi pekiştirmeniz için pratik bir görev içerir.

İlerleme bildirimleri, uzun süren işlemler sırasında sunucudan istemciye gönderilen gerçek zamanlı mesajlardır. Sunucu, tüm işlemin bitmesini beklemek yerine mevcut durumu güncellemeye devam eder. Bu, şeffaflığı, kullanıcı deneyimini artırır ve hata ayıklamayı kolaylaştırır.

**Örnek:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Neden İlerleme Bildirimleri Kullanılır?

İlerleme bildirimleri şu nedenlerle önemlidir:

- **Daha iyi kullanıcı deneyimi:** Kullanıcılar iş ilerledikçe güncellemeleri görür, sadece sonunda değil.
- **Gerçek zamanlı geri bildirim:** İstemciler ilerleme çubukları veya günlükler gösterebilir, uygulama daha duyarlı hissedilir.
- **Daha kolay hata ayıklama ve izleme:** Geliştiriciler ve kullanıcılar işlemin nerede yavaşladığını veya takıldığını görebilir.

### İlerleme Bildirimleri Nasıl Uygulanır?

MCP’de ilerleme bildirimlerini şu şekilde uygulayabilirsiniz:

- **Sunucu tarafında:** Her öğe işlendikçe `ctx.info()` or `ctx.log()` kullanarak bildirim gönderin. Bu, ana sonuç hazır olmadan istemciye mesaj iletir.
- **İstemci tarafında:** Bildirimleri dinleyen ve gösteren bir mesaj işleyici uygulayın. Bu işleyici bildirimler ile nihai sonuç arasında ayrım yapar.

**Sunucu Örneği:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**İstemci Örneği:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Güvenlik Hususları

HTTP tabanlı taşıma yöntemleriyle MCP sunucuları uygularken güvenlik, birden fazla saldırı vektörüne ve koruma mekanizmasına dikkat edilmesini gerektiren kritik bir konudur.

### Genel Bakış

MCP sunucularını HTTP üzerinden açarken güvenlik çok önemlidir. Streamable HTTP yeni saldırı yüzeyleri getirir ve dikkatli yapılandırma gerektirir.

### Temel Noktalar
- **Origin Header Doğrulaması**: Her zaman `Origin` başlığını doğrulayın.
- **TLS Kullanımı**: Tüm iletişim için HTTPS zorunlu olmalıdır.
- **Yetkilendirme ve Kimlik Doğrulama**: İstemcilerin kimliği doğrulanmalı ve yetkilendirilmelidir.
- **Rate Limiting**: Aşırı yüklenmeyi önlemek için istek sınırları uygulanmalıdır.
- **Günlük Kaydı ve İzleme**: Şüpheli aktiviteler için sunucu günlükleri izlenmelidir.

### Geçiş Sürecinde Uyumluluğun Korunması

Geçiş sırasında mevcut SSE istemcileriyle uyumluluğun korunması önerilir. Bazı stratejiler:

- Hem SSE hem de Streamable HTTP’yi farklı uç noktalarda destekleyebilirsiniz.
- İstemcileri kademeli olarak yeni taşıma yöntemine geçirin.

### Zorluklar

Geçiş sırasında aşağıdaki zorlukların ele alınması gerekir:

- Tüm istemcilerin güncellenmesini sağlamak
- Bildirim iletimindeki farklılıkların yönetilmesi

### Görev: Kendi Akışlı MCP Uygulamanızı Oluşturun

**Senaryo:**
Sunucu, bir öğe listesi (örneğin dosyalar veya belgeler) işler ve işlenen her öğe için bir bildirim gönderir. İstemci, gelen her bildirimi anında gösterir.

**Adımlar:**

1. Bir listeyi işleyen ve her öğe için bildirim gönderen bir sunucu aracı uygulayın.
2. Bildirimleri gerçek zamanlı göstermek için mesaj işleyici içeren bir istemci uygulayın.
3. Hem sunucu hem de istemciyi çalıştırarak bildirimleri gözlemleyin.

[Çözüm](./solution/README.md)

## Daha Fazla Okuma ve Sonraki Adımlar

MCP akışı ile yolculuğunuza devam etmek ve bilginizi genişletmek için bu bölüm ek kaynaklar ve daha gelişmiş uygulamalar oluşturmak için önerilen sonraki adımları sunar.

### Daha Fazla Okuma

- [Microsoft: HTTP Akışına Giriş](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core’da CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Akışlı İstekler](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Sonraki Adımlar

- Gerçek zamanlı analiz, sohbet veya ortak düzenleme için akış kullanan daha gelişmiş MCP araçları oluşturmayı deneyin.
- MCP akışını canlı UI güncellemeleri için frontend çerçeveleri (React, Vue vb.) ile entegre etmeyi keşfedin.
- Sonraki: [VSCode için AI Toolkit Kullanımı](../07-aitk/README.md)

**Feragatname**:  
Bu belge, yapay zeka çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi ana dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yanlış yorumlamalar nedeniyle sorumluluk kabul edilmemektedir.