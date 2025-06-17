<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:11:24+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tr"
}
-->
# Model Context Protocol (MCP) ile HTTPS Akışı

Bu bölüm, Model Context Protocol (MCP) kullanarak HTTPS üzerinden güvenli, ölçeklenebilir ve gerçek zamanlı akış uygulamaya dair kapsamlı bir rehber sunar. Akış motivasyonunu, mevcut taşıma mekanizmalarını, MCP'de akış destekli HTTP'nin nasıl uygulanacağını, güvenlik en iyi uygulamalarını, SSE'den geçişi ve kendi akış MCP uygulamalarınızı oluşturmak için pratik rehberi kapsar.

## MCP’de Taşıma Mekanizmaları ve Akış

Bu bölüm, MCP’de mevcut farklı taşıma mekanizmalarını ve bunların istemciler ile sunucular arasında gerçek zamanlı iletişim için akış yeteneklerini nasıl sağladığını inceler.

### Taşıma Mekanizması Nedir?

Taşıma mekanizması, veri alışverişinin istemci ve sunucu arasında nasıl gerçekleştiğini tanımlar. MCP, farklı ortamlar ve ihtiyaçlar için çeşitli taşıma türlerini destekler:

- **stdio**: Standart giriş/çıkış, yerel ve komut satırı araçları için uygundur. Basittir ancak web veya bulut için uygun değildir.
- **SSE (Server-Sent Events)**: Sunucuların HTTP üzerinden istemcilere gerçek zamanlı güncellemeler göndermesine olanak tanır. Web arayüzleri için iyidir, ancak ölçeklenebilirlik ve esneklik açısından sınırlıdır.
- **Streamable HTTP**: Modern HTTP tabanlı akış taşımasıdır, bildirimleri ve daha iyi ölçeklenebilirliği destekler. Çoğu üretim ve bulut senaryosu için önerilir.

### Karşılaştırma Tablosu

Aşağıdaki karşılaştırma tablosuna göz atarak bu taşıma mekanizmalarının farklarını anlayabilirsiniz:

| Taşıma            | Gerçek Zamanlı Güncellemeler | Akış      | Ölçeklenebilirlik | Kullanım Alanı           |
|-------------------|------------------------------|-----------|-------------------|-------------------------|
| stdio             | Hayır                        | Hayır     | Düşük             | Yerel CLI araçları      |
| SSE               | Evet                         | Evet      | Orta              | Web, gerçek zamanlı güncellemeler |
| Streamable HTTP   | Evet                         | Evet      | Yüksek            | Bulut, çoklu istemci    |

> **İpucu:** Doğru taşıma seçimi performans, ölçeklenebilirlik ve kullanıcı deneyimini etkiler. Modern, ölçeklenebilir ve bulut hazır uygulamalar için **Streamable HTTP** önerilir.

Önceki bölümlerde gördüğünüz stdio ve SSE taşıma türlerini ve bu bölümde ele alınan streamable HTTP taşımasını unutmayın.

## Akış: Kavramlar ve Motivasyon

Akışın temel kavramlarını ve motivasyonlarını anlamak, etkili gerçek zamanlı iletişim sistemleri uygulamak için önemlidir.

**Akış**, ağ programlamasında verinin tamamının hazır olmasını beklemek yerine, küçük, yönetilebilir parçalar veya olay dizisi halinde gönderilip alınmasını sağlayan bir tekniktir. Bu özellikle şu durumlar için faydalıdır:

- Büyük dosyalar veya veri setleri.
- Gerçek zamanlı güncellemeler (örneğin, sohbet, ilerleme çubukları).
- Kullanıcıyı bilgilendirmek istediğiniz uzun süren hesaplamalar.

Akış hakkında bilmeniz gerekenler:

- Veri kademeli olarak iletilir, hepsi birden değil.
- İstemci veriyi geldiği gibi işleyebilir.
- Algılanan gecikmeyi azaltır ve kullanıcı deneyimini geliştirir.

### Neden Akış Kullanılır?

Akış kullanılmasının sebepleri şunlardır:

- Kullanıcılar geri bildirimi anında alır, sadece sonunda değil.
- Gerçek zamanlı uygulamalar ve duyarlı kullanıcı arayüzleri sağlar.
- Ağ ve işlem kaynaklarının daha verimli kullanımı.

### Basit Örnek: HTTP Akış Sunucusu ve İstemcisi

İşte akışın nasıl uygulanabileceğine dair basit bir örnek:

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

Bu örnek, sunucunun tüm mesajlar hazır olana kadar beklemek yerine, mesajları hazır oldukça istemciye göndermesini gösterir.

**Nasıl çalışır:**
- Sunucu her mesajı hazır olduğunda gönderir.
- İstemci gelen her parçayı alır ve yazdırır.

**Gereksinimler:**
- Sunucu, MCP üzerinden akış seçmek yerine, akış yanıtı (`StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) kullanmalıdır.

- **Basit akış ihtiyaçları için:** Klasik HTTP akışı uygulaması daha basit ve temel ihtiyaçlar için yeterlidir.

- **Karmaşık, etkileşimli uygulamalar için:** MCP akışı, bildirimler ve nihai sonuçlar arasında ayrım yaparak daha yapılandırılmış bir yaklaşım sunar.

- **Yapay zeka uygulamaları için:** MCP’nin bildirim sistemi, uzun süren AI görevlerinde kullanıcıları ilerleme hakkında bilgilendirmek için özellikle faydalıdır.

## MCP’de Akış

Klasik akış ve MCP akışı arasındaki farklar hakkında bazı öneriler ve karşılaştırmalar gördünüz. Şimdi MCP’de akışı tam olarak nasıl kullanabileceğinizi detaylandıralım.

MCP çerçevesinde akışın nasıl çalıştığını anlamak, uzun süren işlemler sırasında kullanıcılara gerçek zamanlı geri bildirim sağlayan duyarlı uygulamalar geliştirmek için gereklidir.

MCP’de akış, ana yanıtı parçalara bölerek göndermek değil, bir araç isteği işlerken istemciye **bildirimler** göndermekle ilgilidir. Bu bildirimler ilerleme güncellemeleri, günlükler veya diğer olayları içerebilir.

### Nasıl Çalışır?

Ana sonuç hala tek bir yanıt olarak gönderilir. Ancak, işlem sırasında bildirimler ayrı mesajlar olarak gönderilebilir ve böylece istemci gerçek zamanlı olarak güncellenir. İstemci bu bildirimleri işleyip görüntüleyebilmelidir.

## Bildirim Nedir?

“Bildirim” dedik, MCP bağlamında ne anlama geliyor?

Bildirim, uzun süren bir işlem sırasında sunucudan istemciye ilerleme, durum veya diğer olaylar hakkında bilgi vermek için gönderilen mesajdır. Bildirimler şeffaflığı ve kullanıcı deneyimini artırır.

Örneğin, istemcinin sunucuyla ilk el sıkışma tamamlandığında bir bildirim göndermesi beklenir.

Bir bildirim JSON mesajı olarak şöyle görünür:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Bildirimler, MCP’de ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) olarak adlandırılan bir konuya aittir.

Günlüklemenin çalışması için sunucunun bunu bir özellik/yetenek olarak etkinleştirmesi gerekir:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kullanılan SDK’ya bağlı olarak, günlükleme varsayılan olarak etkin olabilir veya sunucu yapılandırmanızda açıkça etkinleştirmeniz gerekebilir.

Bildirimlerin farklı türleri vardır:

| Seviye    | Açıklama                     | Örnek Kullanım                |
|-----------|------------------------------|------------------------------|
| debug     | Detaylı hata ayıklama bilgisi | Fonksiyon giriş/çıkış noktaları |
| info      | Genel bilgilendirme mesajları | İşlem ilerleme güncellemeleri |
| notice    | Normal ama önemli olaylar      | Yapılandırma değişiklikleri   |
| warning   | Uyarı durumları               | Kullanımdan kaldırılmış özellikler |
| error     | Hata durumları               | İşlem başarısızlıkları        |
| critical  | Kritik durumlar              | Sistem bileşeni arızaları     |
| alert     | Hemen müdahale gerektiren durum | Veri bozulması tespiti       |
| emergency | Sistem kullanılamaz durumda  | Tam sistem arızası            |

## MCP’de Bildirimleri Uygulama

Bildirimleri MCP’de uygulamak için, gerçek zamanlı güncellemeleri işleyebilecek şekilde hem sunucu hem de istemci tarafını yapılandırmanız gerekir. Bu, uygulamanızın uzun süren işlemler sırasında kullanıcılara anlık geri bildirim sağlamasını mümkün kılar.

### Sunucu Tarafı: Bildirim Gönderme

Sunucu tarafı ile başlayalım. MCP’de, istekleri işlerken bildirim gönderebilen araçlar tanımlarsınız. Sunucu, istemciye mesaj göndermek için genellikle `ctx` adlı context nesnesini kullanır.

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` taşıması kullanılmıştır:

```python
mcp.run(transport="streamable-http")
```

</details>

### İstemci Tarafı: Bildirim Alma

İstemci, gelen bildirimleri işlemek ve göstermek için bir mesaj işleyicisi uygulamalıdır.

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

Yukarıdaki kodda, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` kullanılarak istemcide bir mesaj işleyici uygulanmıştır.

## İlerleme Bildirimleri ve Senaryolar

Bu bölümde MCP’de ilerleme bildirimlerinin ne olduğu, neden önemli olduğu ve Streamable HTTP kullanarak nasıl uygulanacağı anlatılır. Ayrıca konuyu pekiştirmek için pratik bir görev sunulur.

İlerleme bildirimleri, uzun süren işlemler sırasında sunucudan istemciye gönderilen gerçek zamanlı mesajlardır. Sunucu, işlemin tamamlanmasını beklemek yerine mevcut durumu istemciye bildirir. Bu, şeffaflığı artırır, kullanıcı deneyimini iyileştirir ve hata ayıklamayı kolaylaştırır.

**Örnek:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Neden İlerleme Bildirimleri Kullanılır?

İlerleme bildirimleri aşağıdaki nedenlerle önemlidir:

- **Daha iyi kullanıcı deneyimi:** Kullanıcılar işi ilerledikçe güncellemeleri görür, sadece sonunda değil.
- **Gerçek zamanlı geri bildirim:** İstemciler ilerleme çubukları veya günlükler göstererek uygulamanın duyarlı hissettirmesini sağlar.
- **Kolay hata ayıklama ve izleme:** Geliştiriciler ve kullanıcılar işlemin nerede yavaşladığını veya takıldığını görebilir.

### İlerleme Bildirimleri Nasıl Uygulanır?

İşte MCP’de ilerleme bildirimlerini nasıl uygulayabileceğiniz:

- **Sunucu tarafında:** Her öğe işlendiğinde `ctx.info()` or `ctx.log()` kullanarak bildirim gönderin. Bu, ana sonuç hazır olmadan istemciye mesaj gönderir.
- **İstemci tarafında:** Bildirimleri dinleyen ve gösteren bir mesaj işleyici uygulayın. Bu işleyici bildirimleri ve nihai sonucu ayırt eder.

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

HTTP tabanlı taşıma mekanizmalarıyla MCP sunucuları uygularken, güvenlik çok önemli bir konudur ve birçok saldırı vektörüne karşı dikkatli koruma gerektirir.

### Genel Bakış

MCP sunucularını HTTP üzerinden açarken güvenlik kritik önemdedir. Streamable HTTP yeni saldırı yüzeyleri ortaya çıkarır ve dikkatli yapılandırma gerektirir.

### Temel Noktalar
- **Origin Header Doğrulaması**: `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` yerine SSE istemcisi kullanmayın.
3. **İstemcide mesaj işleyici uygulayın** bildirimleri işlemek için.
4. **Mevcut araçlar ve iş akışlarıyla uyumluluğu test edin.**

### Uyumluluğun Korunması

Geçiş sürecinde mevcut SSE istemcileriyle uyumluluğun korunması önerilir. Bazı stratejiler:

- Hem SSE hem de Streamable HTTP’yi farklı uç noktalarda destekleyebilirsiniz.
- İstemcileri kademeli olarak yeni taşıma türüne geçirin.

### Zorluklar

Geçiş sırasında aşağıdaki zorlukların üstesinden gelmelisiniz:

- Tüm istemcilerin güncellenmesini sağlamak
- Bildirim teslimatındaki farklılıkları yönetmek

### Görev: Kendi Akış MCP Uygulamanızı Oluşturun

**Senaryo:**
Sunucu, bir öğe listesi (örneğin dosyalar veya belgeler) işler ve işlenen her öğe için bir bildirim gönderir. İstemci, gelen her bildirimi gerçek zamanlı olarak görüntüler.

**Adımlar:**

1. Bir listeyi işleyen ve her öğe için bildirim gönderen bir sunucu aracı oluşturun.
2. Bildirimleri gerçek zamanlı gösteren mesaj işleyicili bir istemci uygulayın.
3. Sunucu ve istemciyi çalıştırarak bildirimleri gözlemleyin.

[Çözüm](./solution/README.md)

## Daha Fazla Okuma ve Sonraki Adımlar

MCP akışı ile yolculuğunuza devam etmek ve bilginizi derinleştirmek için bu bölüm ek kaynaklar ve ileri düzey uygulamalar geliştirmek için önerilen adımları sunar.

### Daha Fazla Okuma

- [Microsoft: HTTP Akışına Giriş](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core’da CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Akışlı İstekler](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Sonraki Adımlar

- Gerçek zamanlı analiz, sohbet veya ortak düzenleme için akış kullanan daha gelişmiş MCP araçları geliştirmeyi deneyin.
- MCP akışını canlı kullanıcı arayüzü güncellemeleri için frontend framework’leri (React, Vue vb.) ile entegre etmeyi keşfedin.
- Sonraki: [VSCode için AI Araç Setini Kullanma](../07-aitk/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.