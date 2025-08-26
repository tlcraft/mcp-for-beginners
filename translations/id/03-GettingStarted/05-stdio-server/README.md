<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:39:54+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "id"
}
-->
# Server MCP dengan Transport stdio

> **⚠️ Pembaruan Penting**: Mulai Spesifikasi MCP 2025-06-18, transport SSE (Server-Sent Events) yang berdiri sendiri telah **dihentikan** dan digantikan oleh transport "Streamable HTTP". Spesifikasi MCP saat ini mendefinisikan dua mekanisme transport utama:
> 1. **stdio** - Input/output standar (direkomendasikan untuk server lokal)
> 2. **Streamable HTTP** - Untuk server jarak jauh yang mungkin menggunakan SSE secara internal
>
> Pelajaran ini telah diperbarui untuk berfokus pada **transport stdio**, yang merupakan pendekatan yang direkomendasikan untuk sebagian besar implementasi server MCP.

Transport stdio memungkinkan server MCP berkomunikasi dengan klien melalui aliran input dan output standar. Ini adalah mekanisme transport yang paling umum digunakan dan direkomendasikan dalam spesifikasi MCP saat ini, menyediakan cara yang sederhana dan efisien untuk membangun server MCP yang dapat dengan mudah diintegrasikan dengan berbagai aplikasi klien.

## Gambaran Umum

Pelajaran ini mencakup cara membangun dan menggunakan server MCP menggunakan transport stdio.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Membangun server MCP menggunakan transport stdio.
- Melakukan debug server MCP menggunakan Inspector.
- Menggunakan server MCP dengan Visual Studio Code.
- Memahami mekanisme transport MCP saat ini dan mengapa stdio direkomendasikan.

## Transport stdio - Cara Kerjanya

Transport stdio adalah salah satu dari dua jenis transport yang didukung dalam spesifikasi MCP saat ini (2025-06-18). Berikut cara kerjanya:

- **Komunikasi Sederhana**: Server membaca pesan JSON-RPC dari input standar (`stdin`) dan mengirim pesan ke output standar (`stdout`).
- **Berbasis Proses**: Klien meluncurkan server MCP sebagai subprocess.
- **Format Pesan**: Pesan adalah permintaan, notifikasi, atau respons JSON-RPC individu yang dipisahkan oleh baris baru.
- **Logging**: Server BOLEH menulis string UTF-8 ke error standar (`stderr`) untuk tujuan logging.

### Persyaratan Utama:
- Pesan HARUS dipisahkan oleh baris baru dan TIDAK BOLEH mengandung baris baru yang tertanam.
- Server TIDAK BOLEH menulis apa pun ke `stdout` yang bukan pesan MCP yang valid.
- Klien TIDAK BOLEH menulis apa pun ke `stdin` server yang bukan pesan MCP yang valid.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

Dalam kode di atas:

- Kami mengimpor kelas `Server` dan `StdioServerTransport` dari MCP SDK.
- Kami membuat instance server dengan konfigurasi dan kemampuan dasar.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

Dalam kode di atas, kami:

- Membuat instance server menggunakan MCP SDK.
- Mendefinisikan alat menggunakan dekorator.
- Menggunakan context manager stdio_server untuk menangani transport.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

Perbedaan utama dari SSE adalah bahwa server stdio:

- Tidak memerlukan pengaturan server web atau endpoint HTTP.
- Diluncurkan sebagai subprocess oleh klien.
- Berkomunikasi melalui aliran stdin/stdout.
- Lebih sederhana untuk diimplementasikan dan di-debug.

## Latihan: Membuat Server stdio

Untuk membuat server kita, kita perlu mengingat dua hal:

- Kita perlu menggunakan server web untuk mengekspos endpoint untuk koneksi dan pesan.

## Lab: Membuat server MCP stdio sederhana

Dalam lab ini, kita akan membuat server MCP sederhana menggunakan transport stdio yang direkomendasikan. Server ini akan mengekspos alat yang dapat dipanggil klien menggunakan Model Context Protocol standar.

### Prasyarat

- Python 3.8 atau lebih baru.
- MCP Python SDK: `pip install mcp`.
- Pemahaman dasar tentang pemrograman async.

Mari kita mulai dengan membuat server MCP stdio pertama kita:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Perbedaan utama dari pendekatan SSE yang dihentikan

**Transport Stdio (Standar Saat Ini):**
- Model subprocess sederhana - klien meluncurkan server sebagai proses anak.
- Komunikasi melalui stdin/stdout menggunakan pesan JSON-RPC.
- Tidak memerlukan pengaturan server HTTP.
- Performa dan keamanan lebih baik.
- Debugging dan pengembangan lebih mudah.

**Transport SSE (Dihentikan mulai MCP 2025-06-18):**
- Memerlukan server HTTP dengan endpoint SSE.
- Pengaturan lebih kompleks dengan infrastruktur server web.
- Pertimbangan keamanan tambahan untuk endpoint HTTP.
- Sekarang digantikan oleh Streamable HTTP untuk skenario berbasis web.

### Membuat server dengan transport stdio

Untuk membuat server stdio kita, kita perlu:

1. **Mengimpor pustaka yang diperlukan** - Kita memerlukan komponen server MCP dan transport stdio.
2. **Membuat instance server** - Mendefinisikan server dengan kemampuannya.
3. **Mendefinisikan alat** - Menambahkan fungsionalitas yang ingin kita ekspos.
4. **Mengatur transport** - Mengonfigurasi komunikasi stdio.
5. **Menjalankan server** - Memulai server dan menangani pesan.

Mari kita bangun langkah demi langkah:

### Langkah 1: Membuat server stdio dasar

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Langkah 2: Menambahkan lebih banyak alat

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Langkah 3: Menjalankan server

Simpan kode sebagai `server.py` dan jalankan dari command line:

```bash
python server.py
```

Server akan mulai dan menunggu input dari stdin. Server berkomunikasi menggunakan pesan JSON-RPC melalui transport stdio.

### Langkah 4: Pengujian dengan Inspector

Anda dapat menguji server Anda menggunakan MCP Inspector:

1. Instal Inspector: `npx @modelcontextprotocol/inspector`.
2. Jalankan Inspector dan arahkan ke server Anda.
3. Uji alat yang telah Anda buat.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Tambahkan alat
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Dapatkan salam yang dipersonalisasi",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Nama orang yang akan disapa",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Halo, ${request.params.arguments?.name}! Selamat datang di server MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Alat tidak dikenal: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Dapatkan salam yang dipersonalisasi")]
    public string GetGreeting(string name)
    {
        return $"Halo, {name}! Selamat datang di server MCP stdio.";
    }

    [Description("Hitung jumlah dua angka")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. Mari kita buat beberapa alat terlebih dahulu, untuk ini kita akan membuat file *Tools.cs* dengan konten berikut:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **Buka antarmuka web**: Inspector akan membuka jendela browser yang menunjukkan kemampuan server Anda.

3. **Uji alat**: 
   - Coba alat `get_greeting` dengan berbagai nama.
   - Uji alat `calculate_sum` dengan berbagai angka.
   - Panggil alat `get_server_info` untuk melihat metadata server.

4. **Pantau komunikasi**: Inspector menunjukkan pesan JSON-RPC yang dipertukarkan antara klien dan server.

### Apa yang harus Anda lihat

Ketika server Anda berhasil dimulai, Anda harus melihat:
- Kemampuan server terdaftar di Inspector.
- Alat tersedia untuk pengujian.
- Pertukaran pesan JSON-RPC yang berhasil.
- Respons alat ditampilkan di antarmuka.

### Masalah umum dan solusinya

**Server tidak mau mulai:**
- Periksa bahwa semua dependensi telah diinstal: `pip install mcp`.
- Verifikasi sintaks Python dan indentasi.
- Cari pesan error di konsol.

**Alat tidak muncul:**
- Pastikan dekorator `@server.tool()` ada.
- Periksa bahwa fungsi alat didefinisikan sebelum `main()`.
- Verifikasi bahwa server dikonfigurasi dengan benar.

**Masalah koneksi:**
- Pastikan server menggunakan transport stdio dengan benar.
- Periksa bahwa tidak ada proses lain yang mengganggu.
- Verifikasi sintaks perintah Inspector.

## Tugas

Cobalah membangun server Anda dengan lebih banyak kemampuan. Lihat [halaman ini](https://api.chucknorris.io/) untuk, misalnya, menambahkan alat yang memanggil API. Anda yang menentukan seperti apa servernya. Selamat bersenang-senang :)

## Solusi

[Solusi](./solution/README.md) Berikut adalah solusi yang mungkin dengan kode yang berfungsi.

## Poin Penting

Poin-poin penting dari bab ini adalah sebagai berikut:

- Transport stdio adalah mekanisme yang direkomendasikan untuk server MCP lokal.
- Transport stdio memungkinkan komunikasi yang mulus antara server MCP dan klien menggunakan aliran input dan output standar.
- Anda dapat menggunakan Inspector dan Visual Studio Code untuk langsung menggunakan server stdio, membuat debugging dan integrasi menjadi mudah.

## Contoh 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Sumber Daya Tambahan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Apa Selanjutnya

## Langkah Berikutnya

Sekarang setelah Anda belajar cara membangun server MCP dengan transport stdio, Anda dapat menjelajahi topik yang lebih lanjut:

- **Selanjutnya**: [HTTP Streaming dengan MCP (Streamable HTTP)](../06-http-streaming/README.md) - Pelajari tentang mekanisme transport lain yang didukung untuk server jarak jauh.
- **Lanjutan**: [Praktik Terbaik Keamanan MCP](../../02-Security/README.md) - Terapkan keamanan di server MCP Anda.
- **Produksi**: [Strategi Deployment](../09-deployment/README.md) - Deploy server Anda untuk penggunaan produksi.

## Sumber Daya Tambahan

- [Spesifikasi MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Spesifikasi resmi.
- [Dokumentasi MCP SDK](https://github.com/modelcontextprotocol/sdk) - Referensi SDK untuk semua bahasa.
- [Contoh Komunitas](../../06-CommunityContributions/README.md) - Contoh server lainnya dari komunitas.

---

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk memberikan hasil yang akurat, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi yang bersifat kritis, disarankan menggunakan jasa penerjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.