<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T08:10:04+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ms"
}
-->
# Pelayan SSE

SSE (Server Sent Events) adalah standard untuk penstriman dari pelayan ke klien, membolehkan pelayan menghantar kemas kini masa nyata kepada klien melalui HTTP. Ini sangat berguna untuk aplikasi yang memerlukan kemas kini langsung, seperti aplikasi sembang, notifikasi, atau suapan data masa nyata. Selain itu, pelayan anda boleh digunakan oleh pelbagai klien serentak kerana ia dijalankan pada pelayan yang boleh ditempatkan di awan contohnya.

## Gambaran Keseluruhan

Pelajaran ini merangkumi cara membina dan menggunakan Pelayan SSE.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Membina Pelayan SSE.
- Menyahpepijat Pelayan SSE menggunakan Inspector.
- Menggunakan Pelayan SSE dengan Visual Studio Code.

## SSE, bagaimana ia berfungsi

SSE adalah salah satu daripada dua jenis pengangkutan yang disokong. Anda sudah melihat yang pertama iaitu stdio digunakan dalam pelajaran sebelum ini. Perbezaannya adalah seperti berikut:

- SSE memerlukan anda mengendalikan dua perkara; sambungan dan mesej.
- Oleh kerana ini adalah pelayan yang boleh dijalankan di mana-mana, anda perlu menyesuaikan cara anda bekerja dengan alat seperti Inspector dan Visual Studio Code. Maksudnya, bukannya menunjukkan cara memulakan pelayan, anda sebaliknya menunjuk ke titik akhir di mana sambungan boleh dibuat. Lihat contoh kod di bawah:

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

Dalam kod di atas:

- `/sse` ditetapkan sebagai laluan. Apabila permintaan dibuat ke laluan ini, satu contoh pengangkutan baru dibuat dan pelayan *menyambung* menggunakan pengangkutan ini.
- `/messages`, ini adalah laluan yang mengendalikan mesej masuk.

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

Dalam kod di atas kami:

- Membuat satu contoh pelayan ASGI (menggunakan Starlette secara khusus) dan memasang laluan lalai `/`

  Apa yang berlaku di belakang tabir ialah laluan `/sse` dan `/messages` disediakan untuk mengendalikan sambungan dan mesej masing-masing. Bahagian lain aplikasi, seperti menambah ciri seperti alat, berlaku seperti dengan pelayan stdio.

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

    Terdapat dua kaedah yang membantu kita beralih dari pelayan web ke pelayan web yang menyokong SSE iaitu:

    - `AddMcpServer`, kaedah ini menambah keupayaan.
    - `MapMcp`, ini menambah laluan seperti `/SSE` dan `/messages`.

Sekarang kita sudah tahu sedikit tentang SSE, mari bina pelayan SSE seterusnya.

## Latihan: Mencipta Pelayan SSE

Untuk mencipta pelayan kita, kita perlu ingat dua perkara:

- Kita perlu menggunakan pelayan web untuk mendedahkan titik akhir bagi sambungan dan mesej.
- Membina pelayan kita seperti biasa dengan alat, sumber dan arahan ketika menggunakan stdio.

### -1- Cipta contoh pelayan

Untuk mencipta pelayan kita, kita menggunakan jenis yang sama seperti dengan stdio. Namun, untuk pengangkutan, kita perlu memilih SSE.

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

Dalam kod di atas kami telah:

- Mencipta contoh pelayan.
- Mendefinisikan aplikasi menggunakan rangka kerja web express.
- Mencipta pembolehubah transports yang akan digunakan untuk menyimpan sambungan masuk.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Dalam kod di atas kami telah:

- Mengimport perpustakaan yang diperlukan dengan Starlette (rangka kerja ASGI) dimasukkan.
- Mencipta contoh pelayan MCP `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Pada ketika ini, kami telah:

- Mencipta aplikasi web
- Menambah sokongan untuk ciri MCP melalui `AddMcpServer`.

Mari tambah laluan yang diperlukan seterusnya.

### -2- Tambah laluan

Mari tambah laluan yang mengendalikan sambungan dan mesej masuk:

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

Dalam kod di atas kami telah mentakrifkan:

- Laluan `/sse` yang mencipta pengangkutan jenis SSE dan akhirnya memanggil `connect` pada pelayan MCP.
- Laluan `/messages` yang mengendalikan mesej masuk.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Dalam kod di atas kami telah:

- Mencipta contoh aplikasi ASGI menggunakan rangka kerja Starlette. Sebahagian daripadanya kami menghantar `mcp.sse_app()` ke senarai laluan. Ini akan memasang laluan `/sse` dan `/messages` pada contoh aplikasi.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Kami telah menambah satu baris kod di akhir `add.MapMcp()` yang bermaksud kami kini mempunyai laluan `/SSE` dan `/messages`.

Mari tambah keupayaan pada pelayan seterusnya.

### -3- Menambah keupayaan pelayan

Sekarang kita sudah mentakrifkan semua yang khusus untuk SSE, mari tambah keupayaan pelayan seperti alat, arahan dan sumber.

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

Ini cara anda boleh menambah alat contohnya. Alat khusus ini mencipta alat bernama "random-joke" yang memanggil API Chuck Norris dan mengembalikan respons JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Sekarang pelayan anda mempunyai satu alat.

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

1. Mari kita cipta beberapa alat dahulu, untuk ini kita akan cipta fail *Tools.cs* dengan kandungan berikut:

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

  Di sini kami telah menambah:

  - Mencipta kelas `Tools` dengan dekorator `McpServerToolType`.
  - Mendefinisikan alat `AddNumbers` dengan mendekorasi kaedah menggunakan `McpServerTool`. Kami juga menyediakan parameter dan pelaksanaan.

1. Mari gunakan kelas `Tools` yang baru kita cipta:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Kami telah menambah panggilan kepada `WithTools` yang menentukan `Tools` sebagai kelas yang mengandungi alat-alat tersebut. Itu sahaja, kita sudah bersedia.

Bagus, kita ada pelayan menggunakan SSE, mari cuba jalankan seterusnya.

## Latihan: Menyahpepijat Pelayan SSE dengan Inspector

Inspector adalah alat hebat yang kita lihat dalam pelajaran sebelum ini [Mencipta pelayan pertama anda](/03-GettingStarted/01-first-server/README.md). Mari lihat jika kita boleh gunakan Inspector di sini juga:

### -1- Menjalankan inspector

Untuk menjalankan inspector, anda mesti mempunyai pelayan SSE yang sedang berjalan, jadi mari lakukan itu dahulu:

1. Jalankan pelayan 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Perhatikan bagaimana kita menggunakan executable `uvicorn` yang dipasang apabila kita menaip `pip install "mcp[cli]"`. Mengetik `server:app` bermaksud kita cuba jalankan fail `server.py` dan ia mempunyai contoh Starlette bernama `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Ini sepatutnya memulakan pelayan. Untuk berinteraksi dengannya anda perlukan terminal baru.

1. Jalankan inspector

    > ![NOTE]
    > Jalankan ini di tetingkap terminal berasingan daripada tempat pelayan berjalan. Juga ambil perhatian, anda perlu sesuaikan arahan di bawah mengikut URL di mana pelayan anda berjalan.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Menjalankan inspector kelihatan sama di semua runtime. Perhatikan bagaimana kita bukannya menghantar laluan ke pelayan dan arahan untuk memulakan pelayan, kita sebaliknya menghantar URL di mana pelayan berjalan dan juga menentukan laluan `/sse`.

### -2- Mencuba alat

Sambungkan pelayan dengan memilih SSE dalam senarai dropdown dan isi medan url di mana pelayan anda berjalan, contohnya http:localhost:4321/sse. Kemudian klik butang "Connect". Seperti sebelum ini, pilih untuk menyenaraikan alat, pilih alat dan berikan nilai input. Anda sepatutnya melihat hasil seperti di bawah:

![Pelayan SSE berjalan dalam inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ms.png)

Bagus, anda boleh bekerja dengan inspector, mari lihat bagaimana kita boleh bekerja dengan Visual Studio Code seterusnya.

## Tugasan

Cuba bina pelayan anda dengan lebih banyak keupayaan. Lihat [laman ini](https://api.chucknorris.io/) untuk, contohnya, menambah alat yang memanggil API. Anda tentukan bagaimana rupa pelayan itu. Selamat mencuba :)

## Penyelesaian

[Penyelesaian](./solution/README.md) Berikut adalah penyelesaian yang mungkin dengan kod yang berfungsi.

## Perkara Penting

Perkara penting dari bab ini adalah seperti berikut:

- SSE adalah pengangkutan kedua yang disokong selepas stdio.
- Untuk menyokong SSE, anda perlu mengurus sambungan masuk dan mesej menggunakan rangka kerja web.
- Anda boleh menggunakan kedua-dua Inspector dan Visual Studio Code untuk menggunakan pelayan SSE, sama seperti pelayan stdio. Perhatikan bagaimana ia berbeza sedikit antara stdio dan SSE. Untuk SSE, anda perlu memulakan pelayan secara berasingan dan kemudian jalankan alat inspector anda. Untuk alat inspector, terdapat juga beberapa perbezaan di mana anda perlu menentukan URL.

## Contoh 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Sumber Tambahan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Apa Seterusnya

- Seterusnya: [HTTP Streaming dengan MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.