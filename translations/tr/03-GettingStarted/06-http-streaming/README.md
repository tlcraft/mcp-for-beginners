<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:41:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tr"
}
-->
# Model Context Protokolü (MCP) ile HTTPS Yayını

Bu bölüm, Model Context Protokolü (MCP) kullanarak HTTPS üzerinden güvenli, ölçeklenebilir ve gerçek zamanlı yayın yapmanın kapsamlı bir rehberini sunar. Yayının motivasyonu, mevcut taşıma mekanizmaları, MCP’de yayınlanabilir HTTP’nin nasıl uygulanacağı, güvenlik en iyi uygulamaları, SSE’den geçiş ve kendi yayın MCP uygulamalarınızı oluşturmak için pratik rehberlik ele alınmaktadır.

## MCP’de Taşıma Mekanizmaları ve Yayın

Bu bölüm, MCP’de mevcut farklı taşıma mekanizmalarını ve bunların istemciler ile sunucular arasında gerçek zamanlı iletişim için yayın yeteneklerini nasıl sağladığını inceler.

### Taşıma Mekanizması Nedir?

Taşıma mekanizması, verinin istemci ile sunucu arasında nasıl değiştirileceğini tanımlar. MCP, farklı ortamlar ve gereksinimler için birden fazla taşıma türünü destekler:

- **stdio**: Standart giriş/çıkış, yerel ve CLI tabanlı araçlar için uygundur. Basittir ancak web veya bulut için uygun değildir.
- **SSE (Server-Sent Events)**: Sunucuların HTTP üzerinden istemcilere gerçek zamanlı güncellemeler göndermesini sağlar. Web arayüzleri için iyidir, ancak ölçeklenebilirlik ve esneklik açısından sınırlıdır.
- **Yayınlanabilir HTTP**: Bildirimleri destekleyen ve daha iyi ölçeklenebilirlik sunan modern HTTP tabanlı yayın taşıması. Çoğu üretim ve bulut senaryosu için önerilir.

### Karşılaştırma Tablosu

Aşağıdaki karşılaştırma tablosuna göz atarak bu taşıma mekanizmaları arasındaki farkları anlayabilirsiniz:

| Taşıma           | Gerçek Zamanlı Güncellemeler | Yayın     | Ölçeklenebilirlik | Kullanım Alanı           |
|------------------|------------------------------|-----------|-------------------|-------------------------|
| stdio            | Hayır                        | Hayır     | Düşük             | Yerel CLI araçları      |
| SSE              | Evet                         | Evet      | Orta              | Web, gerçek zamanlı güncellemeler |
| Yayınlanabilir HTTP | Evet                       | Evet      | Yüksek            | Bulut, çoklu istemci    |

> **İpucu:** Doğru taşıma yöntemini seçmek performans, ölçeklenebilirlik ve kullanıcı deneyimini etkiler. Modern, ölçeklenebilir ve bulut uyumlu uygulamalar için **Yayınlanabilir HTTP** önerilir.

Önceki bölümlerde gösterilen stdio ve SSE taşıma yöntemlerine dikkat edin; bu bölümde ise yayınlanabilir HTTP ele alınmaktadır.

## Yayın: Kavramlar ve Motivasyon

Yayınlamanın temel kavramlarını ve motivasyonlarını anlamak, etkili gerçek zamanlı iletişim sistemleri geliştirmek için önemlidir.

**Yayın**, ağ programlamasında verilerin tamamının hazır olmasını beklemek yerine, küçük, yönetilebilir parçalarda veya bir olay dizisi olarak gönderilip alınmasını sağlayan bir tekniktir. Bu özellikle şunlar için faydalıdır:

- Büyük dosyalar veya veri setleri.
- Gerçek zamanlı güncellemeler (ör. sohbet, ilerleme çubukları).
- Kullanıcıyı bilgilendirmek istediğiniz uzun süren hesaplamalar.

Yayın hakkında bilmeniz gerekenler:

- Veri kademeli olarak iletilir, hepsi bir anda değil.
- İstemci veriyi geldiği gibi işleyebilir.
- Algılanan gecikmeyi azaltır ve kullanıcı deneyimini iyileştirir.

### Neden yayın kullanılır?

Yayın kullanmanın sebepleri şunlardır:

- Kullanıcılar sadece sonunda değil, anında geri bildirim alır.
- Gerçek zamanlı uygulamalar ve duyarlı arayüzler sağlar.
- Ağ ve işlem kaynaklarının daha verimli kullanımı.

### Basit Örnek: HTTP Yayın Sunucusu ve İstemcisi

Yayınlamanın nasıl uygulanabileceğine dair basit bir örnek:

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
- Sunucu, MCP üzerinden yayın seçmek yerine `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream` gibi bir yayın yanıtı kullanmalıdır.

- **Basit yayın ihtiyaçları için:** Klasik HTTP yayını daha kolay uygulanır ve temel yayın ihtiyaçları için yeterlidir.

- **Karmaşık, etkileşimli uygulamalar için:** MCP yayını, bildirimler ile nihai sonuçlar arasında ayrım yaparak daha yapılandırılmış ve zengin meta veriler sunar.

- **Yapay zeka uygulamaları için:** MCP’nin bildirim sistemi, uzun süren AI görevlerinde kullanıcıları ilerleme hakkında bilgilendirmek için özellikle faydalıdır.

## MCP’de Yayınlama

Klasik yayın ile MCP yayını arasındaki farklara dair öneri ve karşılaştırmaları gördünüz. Şimdi MCP’de yayınlamanın tam olarak nasıl kullanılacağını detaylandıralım.

MCP çerçevesinde yayınlamanın nasıl çalıştığını anlamak, uzun süren işlemler sırasında kullanıcılara gerçek zamanlı geri bildirim sağlayan duyarlı uygulamalar geliştirmek için gereklidir.

MCP’de yayınlama, ana yanıtı parçalara bölerek göndermek değil, bir aracın bir isteği işlerken istemciye **bildirimler** göndermesiyle ilgilidir. Bu bildirimler ilerleme güncellemeleri, günlükler veya diğer olayları içerebilir.

### Nasıl çalışır

Ana sonuç hala tek bir yanıt olarak gönderilir. Ancak, işlem sırasında bildirimler ayrı mesajlar olarak gönderilebilir ve böylece istemci gerçek zamanlı olarak güncellenir. İstemci bu bildirimleri işleyip gösterebilmelidir.

## Bildirim Nedir?

“Bildirim” dedik, MCP bağlamında bu ne anlama gelir?

Bildirim, uzun süren bir işlem sırasında sunucudan istemciye ilerleme, durum veya diğer olaylar hakkında bilgi vermek için gönderilen mesajdır. Bildirimler şeffaflığı ve kullanıcı deneyimini artırır.

Örneğin, istemcinin sunucu ile ilk el sıkışması tamamlandığında bir bildirim göndermesi beklenir.

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

Bildirimler, MCP’de ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) adlı bir konuya aittir.

Günlüklemeyi çalıştırmak için sunucunun bunu özellik/kapasite olarak etkinleştirmesi gerekir:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kullanılan SDK’ya bağlı olarak, günlükleme varsayılan olarak etkin olabilir ya da sunucu yapılandırmanızda açıkça etkinleştirmeniz gerekebilir.

Farklı bildirim türleri vardır:

| Seviye    | Açıklama                      | Örnek Kullanım                |
|-----------|------------------------------|------------------------------|
| debug     | Detaylı hata ayıklama bilgisi | Fonksiyon giriş/çıkış noktaları |
| info      | Genel bilgilendirici mesajlar | İşlem ilerleme güncellemeleri  |
| notice    | Normal ama önemli olaylar      | Konfigürasyon değişiklikleri   |
| warning   | Uyarı durumları               | Kullanımdan kalkmış özellikler |
| error     | Hata durumları               | İşlem hataları                |
| critical  | Kritik durumlar               | Sistem bileşeni hataları       |
| alert     | Hemen aksiyon gerektiren durum | Veri bozulması tespiti         |
| emergency | Sistem kullanılamaz durumda   | Tam sistem arızası            |

## MCP’de Bildirimlerin Uygulanması

MCP’de bildirimleri uygulamak için, hem sunucu hem de istemci tarafını gerçek zamanlı güncellemeleri işleyebilecek şekilde ayarlamanız gerekir. Bu, uygulamanızın uzun süren işlemler sırasında kullanıcılara anında geri bildirim vermesini sağlar.

### Sunucu tarafı: Bildirim Gönderme

Sunucu tarafıyla başlayalım. MCP’de, istekleri işlerken bildirim gönderebilen araçlar tanımlarsınız. Sunucu, istemciye mesaj göndermek için genellikle `ctx` olarak adlandırılan context nesnesini kullanır.

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

### İstemci tarafı: Bildirim Alma

İstemci, gelen bildirimleri işlemek ve göstermek için bir mesaj işleyici uygulamalıdır.

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

Önceki kodda, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` kullanılarak istemci, bildirimleri işlemek üzere bir mesaj işleyici uygular.

## İlerleme Bildirimleri ve Senaryolar

Bu bölüm, MCP’de ilerleme bildirimlerinin ne olduğunu, neden önemli olduklarını ve Streamable HTTP kullanarak nasıl uygulanacağını açıklar. Ayrıca anlayışınızı pekiştirmek için pratik bir görev de içerir.

İlerleme bildirimleri, uzun süren işlemler sırasında sunucudan istemciye gönderilen gerçek zamanlı mesajlardır. Tüm işlemin bitmesini beklemek yerine, sunucu istemciyi mevcut durum hakkında sürekli bilgilendirir. Bu şeffaflığı artırır, kullanıcı deneyimini iyileştirir ve hata ayıklamayı kolaylaştırır.

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
- **Gerçek zamanlı geri bildirim:** İstemciler ilerleme çubukları veya günlükleri gösterebilir, uygulama daha duyarlı hissedilir.
- **Hata ayıklama ve izleme kolaylığı:** Geliştiriciler ve kullanıcılar işlemin nerede yavaşladığını veya takıldığını görebilir.

### İlerleme Bildirimleri Nasıl Uygulanır?

İşte MCP’de ilerleme bildirimlerini nasıl uygulayabileceğiniz:

- **Sunucuda:** Her öğe işlendiğinde `ctx.info()` or `ctx.log()` kullanarak bildirim gönderin. Bu, ana sonuç hazır olmadan önce istemciye mesaj gönderir.
- **İstemcide:** Gelen bildirimleri dinleyen ve gösteren bir mesaj işleyici uygulayın. Bu işleyici bildirimleri ve nihai sonucu ayırt eder.

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

HTTP tabanlı taşıma yöntemleriyle MCP sunucuları uygularken, güvenlik önemli bir konu olup birçok saldırı vektörüne karşı dikkatli koruma gerektirir.

### Genel Bakış

MCP sunucularını HTTP üzerinden açarken güvenlik kritik önemdedir. Yayınlanabilir HTTP yeni saldırı yüzeyleri getirir ve dikkatli yapılandırma gerektirir.

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
2. **Update client code** to use `streamablehttp_client` doğrulamasını her zaman yapın.
- SSE istemcisi yerine Streamable HTTP istemcisi kullanın.
- İstemcide bildirimleri işlemek için bir mesaj işleyici uygulayın.
- Mevcut araçlar ve iş akışları ile uyumluluğu test edin.

### Uyumluluğun Korunması

Geçiş sürecinde mevcut SSE istemcileri ile uyumluluğu korumanız önerilir. Bazı stratejiler:

- Hem SSE hem de Yayınlanabilir HTTP’yi farklı uç noktalarda destekleyebilirsiniz.
- İstemcileri kademeli olarak yeni taşıma yöntemine geçirin.

### Karşılaşılan Zorluklar

Geçiş sırasında şu zorlukları ele alın:

- Tüm istemcilerin güncellenmesini sağlamak
- Bildirim teslimindeki farklılıkları yönetmek

### Görev: Kendi Yayın MCP Uygulamanızı Oluşturun

**Senaryo:**
Sunucu, bir öğe listesi (örneğin dosyalar veya belgeler) işler ve her işlenen öğe için bir bildirim gönderir. İstemci, gelen her bildirimi anında gösterir.

**Adımlar:**

1. Bir listeyi işleyen ve her öğe için bildirim gönderen bir sunucu aracı oluşturun.
2. Bildirimleri gerçek zamanlı göstermek için bir mesaj işleyiciye sahip istemci uygulayın.
3. Sunucu ve istemciyi çalıştırarak uygulamanızı test edin ve bildirimleri gözlemleyin.

[Çözüm](./solution/README.md)

## Daha Fazla Okuma ve Sonraki Adımlar

MCP yayını yolculuğunuza devam etmek ve bilginizi genişletmek için bu bölüm, daha ileri kaynaklar ve daha gelişmiş uygulamalar oluşturmak için önerilen sonraki adımları sunar.

### Daha Fazla Okuma

- [Microsoft: HTTP Yayına Giriş](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core’da CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Yayın İstekleri](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Sonraki Adımlar

- Gerçek zamanlı analiz, sohbet veya ortak düzenleme için yayın kullanan daha gelişmiş MCP araçları geliştirmeyi deneyin.
- MCP yayını ile ön yüz frameworklerini (React, Vue vb.) entegre ederek canlı arayüz güncellemeleri sağlayın.
- Sonraki: [VSCode için AI Araç Seti Kullanımı](../07-aitk/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle oluşabilecek herhangi bir yanlış anlama veya yorum hatasından sorumlu değiliz.