<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:22:26+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ms"
}
-->
# Penstriman HTTPS dengan Model Context Protocol (MCP)

Bab ini menyediakan panduan lengkap untuk melaksanakan penstriman yang selamat, boleh skala, dan masa nyata menggunakan Model Context Protocol (MCP) dengan HTTPS. Ia merangkumi motivasi untuk penstriman, mekanisme pengangkutan yang tersedia, cara melaksanakan HTTP yang boleh distrim dalam MCP, amalan terbaik keselamatan, migrasi dari SSE, serta panduan praktikal untuk membina aplikasi MCP penstriman anda sendiri.

## Mekanisme Pengangkutan dan Penstriman dalam MCP

Bahagian ini meneroka pelbagai mekanisme pengangkutan yang tersedia dalam MCP dan peranannya dalam membolehkan keupayaan penstriman untuk komunikasi masa nyata antara klien dan pelayan.

### Apakah Mekanisme Pengangkutan?

Mekanisme pengangkutan menentukan bagaimana data ditukar antara klien dan pelayan. MCP menyokong pelbagai jenis pengangkutan untuk menyesuaikan dengan persekitaran dan keperluan yang berbeza:

- **stdio**: Input/output standard, sesuai untuk alat tempatan dan berasaskan CLI. Mudah tetapi tidak sesuai untuk web atau awan.
- **SSE (Server-Sent Events)**: Membolehkan pelayan menghantar kemas kini masa nyata kepada klien melalui HTTP. Baik untuk UI web, tetapi terhad dari segi skala dan fleksibiliti.
- **Streamable HTTP**: Pengangkutan penstriman berasaskan HTTP moden, menyokong notifikasi dan skala yang lebih baik. Disyorkan untuk kebanyakan senario pengeluaran dan awan.

### Jadual Perbandingan

Lihat jadual perbandingan di bawah untuk memahami perbezaan antara mekanisme pengangkutan ini:

| Pengangkutan      | Kemas Kini Masa Nyata | Penstriman | Kebolehsuaian | Kes Penggunaan          |
|-------------------|----------------------|------------|---------------|-------------------------|
| stdio             | Tidak                | Tidak      | Rendah        | Alat CLI tempatan       |
| SSE               | Ya                   | Ya         | Sederhana     | Web, kemas kini masa nyata |
| Streamable HTTP   | Ya                   | Ya         | Tinggi        | Awan, pelbagai klien    |

> **Tip:** Pemilihan pengangkutan yang betul mempengaruhi prestasi, kebolehsuaian, dan pengalaman pengguna. **Streamable HTTP** disyorkan untuk aplikasi moden, boleh skala, dan bersedia awan.

Perhatikan pengangkutan stdio dan SSE yang telah anda lihat dalam bab sebelumnya dan bagaimana Streamable HTTP adalah pengangkutan yang dibincangkan dalam bab ini.

## Penstriman: Konsep dan Motivasi

Memahami konsep asas dan motivasi di sebalik penstriman adalah penting untuk melaksanakan sistem komunikasi masa nyata yang berkesan.

**Penstriman** adalah teknik dalam pengaturcaraan rangkaian yang membolehkan data dihantar dan diterima dalam bahagian kecil yang boleh diurus atau sebagai urutan peristiwa, bukannya menunggu keseluruhan respons siap. Ini sangat berguna untuk:

- Fail atau set data yang besar.
- Kemas kini masa nyata (contohnya, sembang, bar kemajuan).
- Pengiraan yang berjalan lama di mana anda ingin memberitahu pengguna.

Berikut adalah perkara yang perlu anda tahu tentang penstriman secara umum:

- Data dihantar secara berperingkat, bukan sekaligus.
- Klien boleh memproses data sebaik ia tiba.
- Mengurangkan kelewatan yang dirasai dan meningkatkan pengalaman pengguna.

### Mengapa menggunakan penstriman?

Sebab-sebab menggunakan penstriman adalah seperti berikut:

- Pengguna mendapat maklum balas segera, bukan hanya pada penghujung proses
- Membolehkan aplikasi masa nyata dan UI yang responsif
- Penggunaan sumber rangkaian dan pengkomputeran yang lebih cekap

### Contoh Mudah: Pelayan & Klien Penstriman HTTP

Berikut adalah contoh mudah bagaimana penstriman boleh dilaksanakan:

<details>
<summary>Python</summary>

**Pelayan (Python, menggunakan FastAPI dan StreamingResponse):**
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

**Klien (Python, menggunakan requests):**
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

Contoh ini menunjukkan pelayan menghantar satu siri mesej kepada klien apabila mesej tersebut tersedia, bukan menunggu semua mesej siap.

**Cara ia berfungsi:**
- Pelayan menghasilkan setiap mesej sebaik ia siap.
- Klien menerima dan mencetak setiap bahagian sebaik ia tiba.

**Keperluan:**
- Pelayan mesti menggunakan respons penstriman (contohnya, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Pelayan (Java, menggunakan Spring Boot dan Server-Sent Events):**

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

**Klien (Java, menggunakan Spring WebFlux WebClient):**

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

**Nota Pelaksanaan Java:**
- Menggunakan stack reaktif Spring Boot dengan `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) berbanding memilih penstriman melalui MCP.

- **Untuk keperluan penstriman mudah:** Penstriman HTTP klasik lebih mudah dilaksanakan dan mencukupi untuk keperluan penstriman asas.

- **Untuk aplikasi kompleks dan interaktif:** Penstriman MCP menyediakan pendekatan yang lebih tersusun dengan metadata yang lebih kaya serta pemisahan antara notifikasi dan hasil akhir.

- **Untuk aplikasi AI:** Sistem notifikasi MCP sangat berguna untuk tugasan AI yang berjalan lama di mana anda mahu pengguna sentiasa dimaklumkan tentang kemajuan.

## Penstriman dalam MCP

Baik, anda sudah melihat beberapa cadangan dan perbandingan setakat ini mengenai perbezaan antara penstriman klasik dan penstriman dalam MCP. Mari kita lihat dengan lebih terperinci bagaimana anda boleh memanfaatkan penstriman dalam MCP.

Memahami bagaimana penstriman berfungsi dalam rangka kerja MCP adalah penting untuk membina aplikasi yang responsif yang memberikan maklum balas masa nyata kepada pengguna semasa operasi yang berjalan lama.

Dalam MCP, penstriman bukanlah menghantar respons utama secara berbahagian, tetapi menghantar **notifikasi** kepada klien semasa alat memproses permintaan. Notifikasi ini boleh merangkumi kemas kini kemajuan, log, atau peristiwa lain.

### Cara ia berfungsi

Hasil utama masih dihantar sebagai satu respons tunggal. Walau bagaimanapun, notifikasi boleh dihantar sebagai mesej berasingan semasa pemprosesan dan dengan itu mengemas kini klien secara masa nyata. Klien mesti boleh mengendalikan dan memaparkan notifikasi ini.

## Apakah itu Notifikasi?

Kami menyebut "Notifikasi", apa maksudnya dalam konteks MCP?

Notifikasi adalah mesej yang dihantar dari pelayan kepada klien untuk memberitahu tentang kemajuan, status, atau peristiwa lain semasa operasi yang berjalan lama. Notifikasi meningkatkan ketelusan dan pengalaman pengguna.

Sebagai contoh, klien sepatutnya menghantar notifikasi apabila jabat tangan awal dengan pelayan telah dibuat.

Notifikasi kelihatan seperti ini sebagai mesej JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikasi tergolong dalam topik dalam MCP yang dirujuk sebagai ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Untuk mengaktifkan logging, pelayan perlu menghidupkannya sebagai ciri/keupayaan seperti berikut:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Bergantung pada SDK yang digunakan, logging mungkin diaktifkan secara lalai, atau anda mungkin perlu mengaktifkannya secara eksplisit dalam konfigurasi pelayan anda.

Terdapat pelbagai jenis notifikasi:

| Tahap     | Penerangan                    | Contoh Kes Penggunaan          |
|-----------|-------------------------------|-------------------------------|
| debug     | Maklumat debugging terperinci | Titik masuk/keluar fungsi      |
| info      | Mesej maklumat umum            | Kemas kini kemajuan operasi    |
| notice    | Peristiwa normal tetapi penting | Perubahan konfigurasi          |
| warning   | Keadaan amaran                 | Penggunaan ciri yang sudah lapuk |
| error     | Keadaan ralat                 | Kegagalan operasi              |
| critical  | Keadaan kritikal               | Kegagalan komponen sistem      |
| alert     | Tindakan mesti diambil segera | Pengesanan kerosakan data      |
| emergency | Sistem tidak boleh digunakan   | Kegagalan sistem sepenuhnya    |

## Melaksanakan Notifikasi dalam MCP

Untuk melaksanakan notifikasi dalam MCP, anda perlu menyediakan kedua-dua sisi pelayan dan klien untuk mengendalikan kemas kini masa nyata. Ini membolehkan aplikasi anda memberikan maklum balas segera kepada pengguna semasa operasi yang berjalan lama.

### Sisi Pelayan: Menghantar Notifikasi

Mari kita mulakan dengan sisi pelayan. Dalam MCP, anda mentakrifkan alat yang boleh menghantar notifikasi semasa memproses permintaan. Pelayan menggunakan objek konteks (biasanya `ctx`) untuk menghantar mesej kepada klien.

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

Dalam contoh sebelumnya, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` pengangkutan:

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

Dalam contoh .NET ini, kaedah `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` digunakan untuk menghantar mesej maklumat.

Untuk mengaktifkan notifikasi dalam pelayan MCP .NET anda, pastikan anda menggunakan pengangkutan penstriman:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Sisi Klien: Menerima Notifikasi

Klien mesti melaksanakan pengendali mesej untuk memproses dan memaparkan notifikasi sebaik ia tiba.

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

Dalam kod sebelumnya, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` digunakan untuk mengendalikan notifikasi yang masuk.

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

Dalam contoh .NET ini, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) dan klien anda melaksanakan pengendali mesej untuk memproses notifikasi.

## Notifikasi Kemajuan & Senario

Bahagian ini menerangkan konsep notifikasi kemajuan dalam MCP, mengapa ia penting, dan cara melaksanakannya menggunakan Streamable HTTP. Anda juga akan menemui tugasan praktikal untuk mengukuhkan pemahaman anda.

Notifikasi kemajuan adalah mesej masa nyata yang dihantar dari pelayan kepada klien semasa operasi yang berjalan lama. Daripada menunggu keseluruhan proses selesai, pelayan sentiasa mengemas kini klien tentang status semasa. Ini meningkatkan ketelusan, pengalaman pengguna, dan memudahkan penyahpepijatan.

**Contoh:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Mengapa Menggunakan Notifikasi Kemajuan?

Notifikasi kemajuan penting atas beberapa sebab:

- **Pengalaman pengguna yang lebih baik:** Pengguna melihat kemas kini semasa kerja berjalan, bukan hanya pada penghujungnya.
- **Maklum balas masa nyata:** Klien boleh memaparkan bar kemajuan atau log, menjadikan aplikasi terasa responsif.
- **Penyahpepijatan dan pemantauan lebih mudah:** Pembangun dan pengguna dapat melihat di mana proses mungkin perlahan atau tersekat.

### Cara Melaksanakan Notifikasi Kemajuan

Berikut adalah cara anda boleh melaksanakan notifikasi kemajuan dalam MCP:

- **Di pelayan:** Gunakan `ctx.info()` or `ctx.log()` untuk menghantar notifikasi semasa setiap item diproses. Ini menghantar mesej kepada klien sebelum hasil utama siap.
- **Di klien:** Laksanakan pengendali mesej yang mendengar dan memaparkan notifikasi sebaik ia tiba. Pengendali ini membezakan antara notifikasi dan hasil akhir.

**Contoh Pelayan:**

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

**Contoh Klien:**

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

## Pertimbangan Keselamatan

Apabila melaksanakan pelayan MCP dengan pengangkutan berasaskan HTTP, keselamatan menjadi keutamaan yang memerlukan perhatian teliti terhadap pelbagai vektor serangan dan mekanisme perlindungan.

### Gambaran Keseluruhan

Keselamatan adalah kritikal apabila mendedahkan pelayan MCP melalui HTTP. Streamable HTTP memperkenalkan permukaan serangan baru dan memerlukan konfigurasi yang berhati-hati.

### Perkara Penting
- **Pengesahan Header Origin**: Sentiasa sahkan `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` berbanding klien SSE.
3. **Laksanakan pengendali mesej** dalam klien untuk memproses notifikasi.
4. **Uji keserasian** dengan alat dan aliran kerja sedia ada.

### Mengekalkan Keserasian

Adalah disyorkan untuk mengekalkan keserasian dengan klien SSE sedia ada semasa proses migrasi. Berikut adalah beberapa strategi:

- Anda boleh menyokong kedua-dua SSE dan Streamable HTTP dengan menjalankan kedua-dua pengangkutan pada titik akhir yang berbeza.
- Migrasi klien secara berperingkat ke pengangkutan baru.

### Cabaran

Pastikan anda menangani cabaran berikut semasa migrasi:

- Memastikan semua klien dikemas kini
- Mengendalikan perbezaan dalam penghantaran notifikasi

### Tugasan: Bina Aplikasi MCP Penstriman Anda Sendiri

**Senario:**
Bina pelayan dan klien MCP di mana pelayan memproses senarai item (contohnya, fail atau dokumen) dan menghantar notifikasi untuk setiap item yang diproses. Klien harus memaparkan setiap notifikasi sebaik ia tiba.

**Langkah-langkah:**

1. Laksanakan alat pelayan yang memproses senarai dan menghantar notifikasi untuk setiap item.
2. Laksanakan klien dengan pengendali mesej untuk memaparkan notifikasi secara masa nyata.
3. Uji pelaksanaan anda dengan menjalankan kedua-dua pelayan dan klien, dan perhatikan notifikasi yang diterima.

[Solution](./solution/README.md)

## Bacaan Lanjut & Apa Seterusnya?

Untuk meneruskan perjalanan anda dengan penstriman MCP dan mengembangkan pengetahuan anda, bahagian ini menyediakan sumber tambahan dan langkah seterusnya yang dicadangkan untuk membina aplikasi yang lebih maju.

### Bacaan Lanjut

- [Microsoft: Pengenalan kepada Penstriman HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS dalam ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Permintaan Penstriman](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Apa Seterusnya?

- Cuba bina alat MCP yang lebih maju yang menggunakan penstriman untuk analitik masa nyata, sembang, atau penyuntingan kolaboratif.
- Terokai integrasi penstriman MCP dengan rangka kerja frontend (React, Vue, dll.) untuk kemas kini UI secara langsung.
- Seterusnya: [Menggunakan AI Toolkit untuk VSCode](../07-aitk/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan oleh penterjemah manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.