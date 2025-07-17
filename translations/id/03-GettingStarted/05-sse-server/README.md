<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T07:57:14+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "id"
}
-->
# Server SSE

SSE (Server Sent Events) adalah standar untuk streaming dari server ke klien, memungkinkan server mengirim pembaruan real-time ke klien melalui HTTP. Ini sangat berguna untuk aplikasi yang membutuhkan pembaruan langsung, seperti aplikasi chat, notifikasi, atau feed data real-time. Selain itu, server Anda dapat digunakan oleh banyak klien secara bersamaan karena berjalan di server yang bisa ditempatkan di cloud misalnya.

## Gambaran Umum

Pelajaran ini membahas cara membangun dan menggunakan Server SSE.

## Tujuan Pembelajaran

Di akhir pelajaran ini, Anda akan dapat:

- Membangun Server SSE.
- Debug Server SSE menggunakan Inspector.
- Menggunakan Server SSE dengan Visual Studio Code.

## SSE, cara kerjanya

SSE adalah salah satu dari dua jenis transport yang didukung. Anda sudah melihat yang pertama yaitu stdio digunakan di pelajaran sebelumnya. Perbedaannya adalah sebagai berikut:

- SSE mengharuskan Anda menangani dua hal; koneksi dan pesan.
- Karena ini adalah server yang bisa berjalan di mana saja, Anda perlu menyesuaikan cara kerja dengan alat seperti Inspector dan Visual Studio Code. Artinya, alih-alih menunjukkan cara memulai server, Anda menunjuk ke endpoint tempat koneksi dapat dibuat. Lihat contoh kode di bawah:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

Dalam kode di atas:

- `/sse` disiapkan sebagai route. Ketika ada permintaan ke route ini, instance transport baru dibuat dan server *menghubungkan* menggunakan transport ini.
- `/messages`, ini adalah route yang menangani pesan masuk.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

Dalam kode di atas kita:

- Membuat instance server ASGI (menggunakan Starlette secara khusus) dan memasang route default `/`

  Yang terjadi di belakang layar adalah route `/sse` dan `/messages` disiapkan untuk menangani koneksi dan pesan secara terpisah. Sisanya, seperti menambahkan fitur seperti tools, berjalan seperti pada server stdio.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Ada dua metode yang membantu kita beralih dari web server biasa ke web server yang mendukung SSE, yaitu:

    - `AddMcpServer`, metode ini menambahkan kemampuan.
    - `MapMcp`, ini menambahkan route seperti `/SSE` dan `/messages`.

Sekarang setelah kita tahu sedikit lebih banyak tentang SSE, mari kita buat server SSE.

## Latihan: Membuat Server SSE

Untuk membuat server, kita perlu mengingat dua hal:

- Kita perlu menggunakan web server untuk membuka endpoint untuk koneksi dan pesan.
- Bangun server seperti biasa dengan tools, resources, dan prompts seperti saat menggunakan stdio.

### -1- Membuat instance server

Untuk membuat server, kita menggunakan tipe yang sama seperti pada stdio. Namun, untuk transport, kita harus memilih SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

Dalam kode di atas kita telah:

- Membuat instance server.
- Mendefinisikan app menggunakan framework web express.
- Membuat variabel transports yang akan kita gunakan untuk menyimpan koneksi masuk.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Dalam kode di atas kita telah:

- Mengimpor library yang dibutuhkan dengan Starlette (framework ASGI) dimasukkan.
- Membuat instance server MCP `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Pada titik ini, kita telah:

- Membuat web app
- Menambahkan dukungan fitur MCP melalui `AddMcpServer`.

Selanjutnya, mari tambahkan route yang dibutuhkan.

### -2- Menambahkan route

Mari tambahkan route yang menangani koneksi dan pesan masuk:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

Dalam kode di atas kita telah mendefinisikan:

- Route `/sse` yang membuat instance transport tipe SSE dan memanggil `connect` pada server MCP.
- Route `/messages` yang menangani pesan masuk.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Dalam kode di atas kita telah:

- Membuat instance app ASGI menggunakan framework Starlette. Sebagai bagian dari itu kita melewatkan `mcp.sse_app()` ke daftar route-nya. Ini akan memasang route `/sse` dan `/messages` pada instance app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Kita menambahkan satu baris kode di akhir `add.MapMcp()` yang berarti sekarang kita memiliki route `/SSE` dan `/messages`.

Selanjutnya, mari tambahkan kemampuan ke server.

### -3- Menambahkan kemampuan server

Sekarang setelah semua yang spesifik untuk SSE sudah didefinisikan, mari tambahkan kemampuan server seperti tools, prompts, dan resources.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Berikut cara menambahkan sebuah tool misalnya. Tool ini membuat tool bernama "random-joke" yang memanggil API Chuck Norris dan mengembalikan respons JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Sekarang server Anda memiliki satu tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Mari buat beberapa tools terlebih dahulu, untuk ini kita buat file *Tools.cs* dengan isi berikut:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Di sini kita telah menambahkan:

  - Membuat kelas `Tools` dengan dekorator `McpServerToolType`.
  - Mendefinisikan tool `AddNumbers` dengan mendekorasi metode menggunakan `McpServerTool`. Kita juga menyediakan parameter dan implementasi.

1. Mari gunakan kelas `Tools` yang baru dibuat:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Kita menambahkan pemanggilan `WithTools` yang menentukan `Tools` sebagai kelas yang berisi tools. Selesai, kita siap.

Bagus, kita sudah punya server menggunakan SSE, mari coba jalankan.

## Latihan: Debug Server SSE dengan Inspector

Inspector adalah alat yang bagus yang sudah kita lihat di pelajaran sebelumnya [Membuat server pertama Anda](/03-GettingStarted/01-first-server/README.md). Mari kita lihat apakah kita bisa menggunakan Inspector di sini juga:

### -1- Menjalankan inspector

Untuk menjalankan inspector, Anda harus sudah menjalankan server SSE, jadi mari lakukan itu dulu:

1. Jalankan server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Perhatikan kita menggunakan executable `uvicorn` yang terinstal saat mengetik `pip install "mcp[cli]"`. Mengetik `server:app` berarti kita mencoba menjalankan file `server.py` yang memiliki instance Starlette bernama `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Ini akan memulai server. Untuk berinteraksi dengan server, Anda perlu membuka terminal baru.

1. Jalankan inspector

    > ![NOTE]
    > Jalankan ini di jendela terminal terpisah dari tempat server berjalan. Juga perhatikan, Anda perlu menyesuaikan perintah di bawah agar sesuai dengan URL tempat server Anda berjalan.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Menjalankan inspector terlihat sama di semua runtime. Perhatikan bahwa alih-alih melewatkan path ke server dan perintah untuk memulai server, kita melewatkan URL tempat server berjalan dan juga menentukan route `/sse`.

### -2- Mencoba tool

Hubungkan server dengan memilih SSE di dropdown dan isi field url dengan alamat tempat server Anda berjalan, misalnya http:localhost:4321/sse. Sekarang klik tombol "Connect". Seperti sebelumnya, pilih untuk menampilkan daftar tools, pilih sebuah tool dan masukkan nilai input. Anda akan melihat hasil seperti di bawah:

![Server SSE berjalan di inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.id.png)

Bagus, Anda bisa bekerja dengan inspector, sekarang mari lihat cara menggunakan Visual Studio Code.

## Tugas

Cobalah membangun server Anda dengan lebih banyak kemampuan. Lihat [halaman ini](https://api.chucknorris.io/) untuk, misalnya, menambahkan tool yang memanggil API. Anda tentukan seperti apa servernya. Selamat bersenang-senang :)

## Solusi

[Solusi](./solution/README.md) Berikut adalah solusi yang mungkin dengan kode yang berfungsi.

## Poin Penting

Poin penting dari bab ini adalah:

- SSE adalah transport kedua yang didukung setelah stdio.
- Untuk mendukung SSE, Anda perlu mengelola koneksi masuk dan pesan menggunakan framework web.
- Anda dapat menggunakan Inspector dan Visual Studio Code untuk menggunakan server SSE, sama seperti server stdio. Perhatikan ada sedikit perbedaan antara stdio dan SSE. Untuk SSE, Anda perlu memulai server secara terpisah lalu menjalankan alat inspector. Untuk alat inspector, ada juga perbedaan bahwa Anda harus menentukan URL.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Selanjutnya

- Selanjutnya: [HTTP Streaming dengan MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.