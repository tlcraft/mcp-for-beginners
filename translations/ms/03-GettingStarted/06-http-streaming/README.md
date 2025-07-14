<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:47:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ms"
}
-->
# Penstriman HTTPS dengan Protokol Konteks Model (MCP)

Bab ini menyediakan panduan menyeluruh untuk melaksanakan penstriman yang selamat, boleh skala, dan masa nyata menggunakan Protokol Konteks Model (MCP) dengan HTTPS. Ia merangkumi motivasi untuk penstriman, mekanisme pengangkutan yang tersedia, cara melaksanakan HTTP yang boleh distrim dalam MCP, amalan keselamatan terbaik, migrasi dari SSE, dan panduan praktikal untuk membina aplikasi MCP penstriman anda sendiri.

## Mekanisme Pengangkutan dan Penstriman dalam MCP

Bahagian ini meneroka pelbagai mekanisme pengangkutan yang tersedia dalam MCP dan peranannya dalam membolehkan keupayaan penstriman untuk komunikasi masa nyata antara klien dan pelayan.

### Apakah Mekanisme Pengangkutan?

Mekanisme pengangkutan mentakrifkan bagaimana data dipertukarkan antara klien dan pelayan. MCP menyokong pelbagai jenis pengangkutan untuk memenuhi persekitaran dan keperluan yang berbeza:

- **stdio**: Input/output standard, sesuai untuk alat tempatan dan berasaskan CLI. Mudah tetapi tidak sesuai untuk web atau awan.
- **SSE (Server-Sent Events)**: Membolehkan pelayan menolak kemas kini masa nyata kepada klien melalui HTTP. Baik untuk UI web, tetapi terhad dari segi kebolehsuaian dan fleksibiliti.
- **Streamable HTTP**: Pengangkutan penstriman berasaskan HTTP moden, menyokong notifikasi dan kebolehsuaian yang lebih baik. Disyorkan untuk kebanyakan senario pengeluaran dan awan.

### Jadual Perbandingan

Lihat jadual perbandingan di bawah untuk memahami perbezaan antara mekanisme pengangkutan ini:

| Pengangkutan      | Kemas Kini Masa Nyata | Penstriman | Kebolehsuaian | Kes Penggunaan          |
|-------------------|----------------------|------------|---------------|------------------------|
| stdio             | Tidak                | Tidak      | Rendah        | Alat CLI tempatan      |
| SSE               | Ya                   | Ya         | Sederhana     | Web, kemas kini masa nyata |
| Streamable HTTP   | Ya                   | Ya         | Tinggi        | Awan, pelbagai klien   |

> **Tip:** Memilih pengangkutan yang betul memberi kesan kepada prestasi, kebolehsuaian, dan pengalaman pengguna. **Streamable HTTP** disyorkan untuk aplikasi moden, boleh skala, dan sedia awan.

Perhatikan pengangkutan stdio dan SSE yang telah anda lihat dalam bab sebelumnya dan bagaimana streamable HTTP adalah pengangkutan yang dibincangkan dalam bab ini.

## Penstriman: Konsep dan Motivasi

Memahami konsep asas dan motivasi di sebalik penstriman adalah penting untuk melaksanakan sistem komunikasi masa nyata yang berkesan.

**Penstriman** adalah teknik dalam pengaturcaraan rangkaian yang membolehkan data dihantar dan diterima dalam bahagian kecil yang boleh diurus atau sebagai satu siri peristiwa, bukannya menunggu keseluruhan respons siap. Ini sangat berguna untuk:

- Fail atau set data yang besar.
- Kemas kini masa nyata (contohnya, sembang, bar kemajuan).
- Pengiraan jangka panjang di mana anda mahu pengguna sentiasa dimaklumkan.

Berikut adalah perkara yang perlu anda tahu tentang penstriman secara ringkas:

- Data dihantar secara berperingkat, bukan sekaligus.
- Klien boleh memproses data sebaik tiba.
- Mengurangkan kelewatan yang dirasai dan meningkatkan pengalaman pengguna.

### Kenapa guna penstriman?

Sebab-sebab menggunakan penstriman adalah seperti berikut:

- Pengguna mendapat maklum balas segera, bukan hanya di akhir
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

Contoh ini menunjukkan pelayan menghantar satu siri mesej kepada klien apabila ia tersedia, bukannya menunggu semua mesej siap.

**Cara ia berfungsi:**
- Pelayan menghantar setiap mesej sebaik ia sedia.
- Klien menerima dan mencetak setiap bahagian sebaik tiba.

**Keperluan:**
- Pelayan mesti menggunakan respons penstriman (contohnya, `StreamingResponse` dalam FastAPI).
- Klien mesti memproses respons sebagai aliran (`stream=True` dalam requests).
- Content-Type biasanya `text/event-stream` atau `application/octet-stream`.

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
- Menggunakan tumpukan reaktif Spring Boot dengan `Flux` untuk penstriman
- `ServerSentEvent` menyediakan penstriman peristiwa berstruktur dengan jenis peristiwa
- `WebClient` dengan `bodyToFlux()` membolehkan penggunaan penstriman reaktif
- `delayElements()` mensimulasikan masa pemprosesan antara peristiwa
- Peristiwa boleh mempunyai jenis (`info`, `result`) untuk pengendalian klien yang lebih baik

</details>

### Perbandingan: Penstriman Klasik vs Penstriman MCP

Perbezaan antara cara penstriman berfungsi secara "klasik" berbanding dalam MCP boleh digambarkan seperti berikut:

| Ciri                   | Penstriman HTTP Klasik         | Penstriman MCP (Notifikasi)       |
|------------------------|-------------------------------|----------------------------------|
| Respons utama          | Berpecah-pecah (chunked)       | Tunggal, di akhir                 |
| Kemas kini kemajuan    | Dihantar sebagai bahagian data  | Dihantar sebagai notifikasi       |
| Keperluan klien        | Mesti memproses aliran          | Mesti melaksanakan pengendali mesej |
| Kes penggunaan         | Fail besar, aliran token AI     | Kemajuan, log, maklum balas masa nyata |

### Perbezaan Utama Diperhatikan

Selain itu, berikut adalah beberapa perbezaan utama:

- **Corak Komunikasi:**
   - Penstriman HTTP klasik: Menggunakan pengekodan pemindahan berpecah-pecah untuk menghantar data dalam bahagian
   - Penstriman MCP: Menggunakan sistem notifikasi berstruktur dengan protokol JSON-RPC

- **Format Mesej:**
   - HTTP klasik: Bahagian teks biasa dengan baris baru
   - MCP: Objek LoggingMessageNotification berstruktur dengan metadata

- **Pelaksanaan Klien:**
   - HTTP klasik: Klien mudah yang memproses respons penstriman
   - MCP: Klien lebih canggih dengan pengendali mesej untuk memproses pelbagai jenis mesej

- **Kemas Kini Kemajuan:**
   - HTTP klasik: Kemajuan adalah sebahagian daripada aliran respons utama
   - MCP: Kemajuan dihantar melalui mesej notifikasi berasingan sementara respons utama datang di akhir

### Cadangan

Terdapat beberapa perkara yang kami cadangkan apabila memilih antara melaksanakan penstriman klasik (sebagai titik akhir yang kami tunjukkan di atas menggunakan `/stream`) berbanding memilih penstriman melalui MCP.

- **Untuk keperluan penstriman mudah:** Penstriman HTTP klasik lebih mudah dilaksanakan dan mencukupi untuk keperluan penstriman asas.

- **Untuk aplikasi kompleks dan interaktif:** Penstriman MCP menyediakan pendekatan yang lebih berstruktur dengan metadata yang lebih kaya dan pemisahan antara notifikasi dan hasil akhir.

- **Untuk aplikasi AI:** Sistem notifikasi MCP sangat berguna untuk tugas AI jangka panjang di mana anda mahu pengguna sentiasa dimaklumkan tentang kemajuan.

## Penstriman dalam MCP

Baik, jadi anda telah melihat beberapa cadangan dan perbandingan setakat ini mengenai perbezaan antara penstriman klasik dan penstriman dalam MCP. Mari kita terokai dengan lebih terperinci bagaimana anda boleh memanfaatkan penstriman dalam MCP.

Memahami bagaimana penstriman berfungsi dalam rangka kerja MCP adalah penting untuk membina aplikasi responsif yang memberikan maklum balas masa nyata kepada pengguna semasa operasi jangka panjang.

Dalam MCP, penstriman bukan tentang menghantar respons utama secara berpecah-pecah, tetapi tentang menghantar **notifikasi** kepada klien semasa alat memproses permintaan. Notifikasi ini boleh merangkumi kemas kini kemajuan, log, atau peristiwa lain.

### Cara ia berfungsi

Hasil utama masih dihantar sebagai satu respons tunggal. Walau bagaimanapun, notifikasi boleh dihantar sebagai mesej berasingan semasa pemprosesan dan dengan itu mengemas kini klien secara masa nyata. Klien mesti dapat mengendalikan dan memaparkan notifikasi ini.

## Apakah Notifikasi?

Kami sebut "Notifikasi", apa maksudnya dalam konteks MCP?

Notifikasi adalah mesej yang dihantar dari pelayan ke klien untuk memaklumkan tentang kemajuan, status, atau peristiwa lain semasa operasi jangka panjang. Notifikasi meningkatkan ketelusan dan pengalaman pengguna.

Sebagai contoh, klien sepatutnya menghantar notifikasi sebaik sahaja jabat tangan awal dengan pelayan telah dibuat.

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

| Tahap      | Penerangan                    | Contoh Kes Penggunaan          |
|------------|-------------------------------|-------------------------------|
| debug      | Maklumat debugging terperinci | Titik masuk/keluar fungsi     |
| info       | Mesej maklumat umum           | Kemas kini kemajuan operasi   |
| notice     | Peristiwa normal tetapi penting | Perubahan konfigurasi         |
| warning    | Keadaan amaran                | Penggunaan ciri yang sudah lapuk |
| error      | Keadaan ralat                | Kegagalan operasi             |
| critical   | Keadaan kritikal             | Kegagalan komponen sistem     |
| alert      | Tindakan mesti diambil segera | Pengesanan kerosakan data     |
| emergency  | Sistem tidak boleh digunakan  | Kegagalan sistem sepenuhnya   |

## Melaksanakan Notifikasi dalam MCP

Untuk melaksanakan notifikasi dalam MCP, anda perlu menyediakan kedua-dua pihak pelayan dan klien untuk mengendalikan kemas kini masa nyata. Ini membolehkan aplikasi anda memberikan maklum balas segera kepada pengguna semasa operasi jangka panjang.

### Pihak Pelayan: Menghantar Notifikasi

Mari mulakan dengan pihak pelayan. Dalam MCP, anda mentakrifkan alat yang boleh menghantar notifikasi semasa memproses permintaan. Pelayan menggunakan objek konteks (biasanya `ctx`) untuk menghantar mesej kepada klien.

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

Dalam contoh sebelum ini, alat `process_files` menghantar tiga notifikasi kepada klien semasa memproses setiap fail. Kaedah `ctx.info()` digunakan untuk menghantar mesej maklumat.

</details>

Selain itu, untuk mengaktifkan notifikasi, pastikan pelayan anda menggunakan pengangkutan penstriman (seperti `streamable-http`) dan klien anda melaksanakan pengendali mesej untuk memproses notifikasi. Berikut adalah cara anda boleh menyediakan pelayan untuk menggunakan pengangkutan `streamable-http`:

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

Dalam contoh .NET ini, alat `ProcessFiles` dihiasi dengan atribut `Tool` dan menghantar tiga notifikasi kepada klien semasa memproses setiap fail. Kaedah `ctx.Info()` digunakan untuk menghantar mesej maklumat.

Untuk mengaktifkan notifikasi dalam pelayan MCP .NET anda, pastikan anda menggunakan pengangkutan penstriman:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Pihak Klien: Menerima Notifikasi

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

Dalam kod sebelum ini, fungsi `message_handler` memeriksa sama ada mesej yang masuk adalah notifikasi. Jika ya, ia mencetak notifikasi; jika tidak, ia memprosesnya sebagai mesej pelayan biasa. Juga perhatikan bagaimana `ClientSession` diinisialisasi dengan `message_handler` untuk mengendalikan notifikasi yang masuk.

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

Dalam contoh .NET ini, fungsi `MessageHandler` memeriksa sama ada mesej yang masuk adalah notifikasi. Jika ya, ia mencetak notifikasi; jika tidak, ia memprosesnya sebagai mesej pelayan biasa. `ClientSession` diinisialisasi dengan pengendali mesej melalui `ClientSessionOptions`.

</details>

Untuk mengaktifkan notifikasi, pastikan pelayan anda menggunakan pengangkutan penstriman (seperti `streamable-http`) dan klien anda melaksanakan pengendali mesej untuk memproses notifikasi.

## Notifikasi Kemajuan & Senario

Bahagian ini menerangkan konsep notifikasi kemajuan dalam MCP, mengapa ia penting, dan cara melaksanakannya menggunakan Streamable HTTP. Anda juga akan menemui tugasan praktikal untuk mengukuhkan pemahaman anda.

Notifikasi kemajuan adalah mesej masa nyata yang dihantar dari pelayan ke klien semasa operasi jangka panjang. Daripada menunggu keseluruhan proses selesai, pelayan sentiasa mengemas kini klien tentang status semasa. Ini meningkatkan ketelusan, pengalaman pengguna, dan memudahkan penyahpepijatan.

**Contoh:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Kenapa Guna Notifikasi Kemajuan?

Notifikasi kemajuan penting atas beberapa sebab:

- **Pengalaman pengguna lebih baik:** Pengguna melihat kemas kini semasa kerja berjalan, bukan hanya di akhir.
- **Maklum balas masa nyata:** Klien boleh memaparkan bar kemajuan atau log, menjadikan aplikasi terasa responsif.
- **Penyahpepijatan dan pemantauan lebih mudah:** Pembangun dan pengguna boleh melihat di mana proses mungkin perlahan atau tersekat.

### Cara Melaksanakan Notifikasi Kemajuan

Berikut adalah cara anda boleh melaksanakan notifikasi kemajuan dalam MCP:

- **Di pelayan:** Gunakan `ctx.info()` atau `ctx.log()` untuk menghantar notifikasi semasa setiap item diproses. Ini menghantar mesej kepada klien sebelum hasil utama siap.
- **Di klien:** Laksanakan pengendali mesej yang mendengar dan memaparkan notifikasi sebaik ia tiba. Pengendali ini membezakan antara notifikasi dan hasil akhir.

**Contoh Pelayan:**

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

Keselamatan adalah penting apabila mendedahkan pelayan MCP melalui HTTP. Streamable HTTP memperkenalkan permukaan serangan baru dan memerlukan konfigurasi yang teliti.

### Perkara Utama
- **Pengesahan Header Origin**: Sentiasa sahkan header `Origin` untuk mengelakkan serangan DNS rebinding.
- **Pengikatan Localhost**: Untuk pembangunan tempatan, ikat pelayan kepada `localhost` supaya tidak terdedah kepada internet awam.
- **Pengesahan**: Laksanakan pengesahan (contohnya, kunci API, OAuth) untuk pengeluaran.
- **CORS**: Konfigurasikan polisi Cross-Origin Resource Sharing (CORS) untuk mengehadkan akses.
- **HTTPS**: Gunakan HTTPS dalam pengeluaran untuk menyulitkan trafik.

### Amalan Terbaik
- Jangan sesekali mempercayai permintaan masuk tanpa pengesahan.
- Log dan pantau semua akses dan ralat.
- Kemas kini kebergantungan secara berkala untuk menampal kelemahan keselamatan.

### Cabaran
- Mengimbangi keselamatan dengan kemudahan pembangunan
- Memastikan keserasian dengan pelbagai persekitaran klien


## Naik Taraf dari SSE ke Streamable HTTP

Bagi aplikasi yang kini menggunakan Server-Sent Events (SSE), migrasi ke Streamable HTTP memberikan keupayaan yang lebih baik dan kelestarian jangka panjang yang lebih baik untuk pelaksanaan MCP anda.

### Kenapa Naik Taraf?

Terdapat dua sebab utama untuk naik taraf dari SSE ke Streamable HTTP:

- Streamable HTTP menawarkan kebolehsuaian yang lebih baik, keserasian, dan sokongan notifikasi yang lebih kaya berbanding SSE.
- Ia adalah pengangkutan yang disyorkan untuk aplikasi MCP baru.

### Langkah Migrasi

Berikut adalah cara anda boleh migrasi dari SSE ke Streamable HTTP dalam aplikasi MCP anda:

- **Kemas kini kod pelayan** untuk menggunakan `transport="streamable-http"` dalam `mcp.run()`.
- **Kemas kini kod klien** untuk menggunakan `streamablehttp_client` menggantikan klien SSE.
- **Laksanakan pengendali mesej** dalam klien untuk memproses notifikasi.
- **Uji keserasian** dengan alat dan aliran kerja sedia ada.

### Mengekalkan Keserasian

Adalah disyorkan untuk mengekalkan keserasian dengan klien SSE sedia ada semasa proses migrasi. Berikut adalah beberapa strategi:

- Anda boleh menyokong kedua-dua SSE dan Streamable HTTP dengan menjalankan kedua-dua pengangkutan pada titik akhir yang berbeza.
- Migrasi klien secara berperingkat ke pengangkutan baru.

### Cabaran

Pastikan anda menangani cabaran berikut semasa migrasi:

- Memastikan semua klien dikemas kini
- Mengendalikan perbezaan dalam penghantaran notifikasi

## Pertimbangan Keselamatan

Keselamatan harus menjadi keutamaan utama apabila melaksanakan mana-mana pelayan, terutamanya apabila menggunakan pengangkutan berasaskan HTTP seperti Streamable HTTP dalam MCP.

Apabila melaksanakan pelayan MCP dengan pengangkutan berasaskan HTTP, keselamatan menjadi keutamaan yang memerlukan perhatian teliti terhadap pelbagai vektor serangan dan mekanisme perlindungan.

### Gambaran Keseluruhan

Keselamatan adalah penting apabila mendedahkan pelayan MCP melalui HTTP. Streamable HTTP memperkenalkan permukaan serangan baru dan memerlukan konfigurasi yang teliti.

Berikut adalah beberapa pertimbangan keselamatan utama:

- **Pengesahan Header Origin**: Sentiasa sahkan header `Origin` untuk mengelakkan serangan DNS rebinding.
- **Pengikatan Localhost**: Untuk pembangunan tempatan, ikat pelayan kepada `localhost` supaya tidak terdedah kepada internet awam.
- **Pengesahan**: Laksanakan pengesahan (contohnya, kunci API, OAuth) untuk pengeluaran.
- **CORS**: Konfigurasikan polisi Cross-Origin Resource Sharing (CORS) untuk mengehadkan akses.
- **HTTPS**: Gunakan HTTPS dalam pengeluaran untuk menyulitkan trafik.

### Amalan Terbaik

Selain itu, berikut adalah beberapa amalan terbaik yang perlu diikuti apabila melaksanakan keselamatan dalam pelayan streaming MCP anda:

- Jangan sesekali mempercayai permintaan masuk tanpa pengesahan.
- Log dan pantau semua akses dan ralat.
- Kemas kini kebergantungan secara berkala untuk menampal kelemahan keselamatan.

### Cabaran

Anda akan menghadapi beberapa cabaran apabila melaksanakan keselamatan dalam pelayan streaming MCP:

- Mengimbangi keselamatan dengan kemudahan pembangunan
- Memastikan keserasian dengan pelbagai persekitaran klien

### Tugasan: Bina Aplikasi Streaming MCP Anda Sendiri

**Senario:**
Bina pelayan dan klien MCP di mana pelayan memproses senarai item (contohnya, fail atau dokumen) dan menghantar notifikasi untuk setiap item yang diproses. Klien harus memaparkan setiap notifikasi sebaik sahaja ia diterima.

**Langkah-langkah:**

1. Laksanakan alat pelayan yang memproses senarai dan menghantar notifikasi untuk setiap item.
2. Laksanakan klien dengan pengendali mesej untuk memaparkan notifikasi secara masa nyata.
3. Uji pelaksanaan anda dengan menjalankan pelayan dan klien, dan perhatikan notifikasi.

[Solution](./solution/README.md)

## Bacaan Lanjut & Apa Seterusnya?

Untuk meneruskan perjalanan anda dengan streaming MCP dan mengembangkan pengetahuan, bahagian ini menyediakan sumber tambahan dan langkah seterusnya yang disyorkan untuk membina aplikasi yang lebih maju.

### Bacaan Lanjut

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Apa Seterusnya?

- Cuba bina alat MCP yang lebih maju yang menggunakan streaming untuk analitik masa nyata, sembang, atau penyuntingan kolaboratif.
- Terokai integrasi streaming MCP dengan rangka kerja frontend (React, Vue, dan lain-lain) untuk kemas kini UI secara langsung.
- Seterusnya: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.