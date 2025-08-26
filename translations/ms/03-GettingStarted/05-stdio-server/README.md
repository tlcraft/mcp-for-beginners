<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:40:27+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "ms"
}
-->
# Pelayan MCP dengan Pengangkutan stdio

> **⚠️ Kemas Kini Penting**: Mulai Spesifikasi MCP 2025-06-18, pengangkutan SSE (Server-Sent Events) yang berdiri sendiri telah **dihentikan** dan digantikan dengan pengangkutan "Streamable HTTP". Spesifikasi MCP semasa mendefinisikan dua mekanisme pengangkutan utama:
> 1. **stdio** - Input/output standard (disyorkan untuk pelayan tempatan)
> 2. **Streamable HTTP** - Untuk pelayan jauh yang mungkin menggunakan SSE secara dalaman
>
> Pelajaran ini telah dikemas kini untuk memberi fokus kepada **pengangkutan stdio**, yang merupakan pendekatan yang disyorkan untuk kebanyakan implementasi pelayan MCP.

Pengangkutan stdio membolehkan pelayan MCP berkomunikasi dengan klien melalui aliran input dan output standard. Ini adalah mekanisme pengangkutan yang paling biasa digunakan dan disyorkan dalam spesifikasi MCP semasa, menyediakan cara yang mudah dan efisien untuk membina pelayan MCP yang boleh diintegrasikan dengan pelbagai aplikasi klien.

## Gambaran Keseluruhan

Pelajaran ini merangkumi cara membina dan menggunakan pelayan MCP menggunakan pengangkutan stdio.

## Objektif Pembelajaran

Pada akhir pelajaran ini, anda akan dapat:

- Membina pelayan MCP menggunakan pengangkutan stdio.
- Menyahpepijat pelayan MCP menggunakan Inspector.
- Menggunakan pelayan MCP dengan Visual Studio Code.
- Memahami mekanisme pengangkutan MCP semasa dan mengapa stdio disyorkan.

## Pengangkutan stdio - Cara Ia Berfungsi

Pengangkutan stdio adalah salah satu daripada dua jenis pengangkutan yang disokong dalam spesifikasi MCP semasa (2025-06-18). Berikut adalah cara ia berfungsi:

- **Komunikasi Mudah**: Pelayan membaca mesej JSON-RPC dari input standard (`stdin`) dan menghantar mesej ke output standard (`stdout`).
- **Berbasis Proses**: Klien melancarkan pelayan MCP sebagai subprocess.
- **Format Mesej**: Mesej adalah permintaan, pemberitahuan, atau respons JSON-RPC individu, dipisahkan oleh baris baru.
- **Log**: Pelayan BOLEH menulis string UTF-8 ke ralat standard (`stderr`) untuk tujuan log.

### Keperluan Utama:
- Mesej MESTI dipisahkan oleh baris baru dan MESTI TIDAK mengandungi baris baru yang tertanam.
- Pelayan MESTI TIDAK menulis apa-apa ke `stdout` yang bukan mesej MCP yang sah.
- Klien MESTI TIDAK menulis apa-apa ke `stdin` pelayan yang bukan mesej MCP yang sah.

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

Dalam kod di atas:

- Kami mengimport kelas `Server` dan `StdioServerTransport` dari MCP SDK.
- Kami mencipta instance pelayan dengan konfigurasi dan keupayaan asas.

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

Dalam kod di atas, kami:

- Mencipta instance pelayan menggunakan MCP SDK.
- Mendefinisikan alat menggunakan dekorator.
- Menggunakan pengurus konteks stdio_server untuk mengendalikan pengangkutan.

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

Perbezaan utama dari SSE adalah bahawa pelayan stdio:

- Tidak memerlukan persediaan pelayan web atau endpoint HTTP.
- Dilancarkan sebagai subprocess oleh klien.
- Berkomunikasi melalui aliran stdin/stdout.
- Lebih mudah untuk dilaksanakan dan disahpepijat.

## Latihan: Membuat Pelayan stdio

Untuk membuat pelayan kita, kita perlu mengingat dua perkara:

- Kita perlu menggunakan pelayan web untuk mendedahkan endpoint untuk sambungan dan mesej.

## Makmal: Membuat pelayan MCP stdio yang ringkas

Dalam makmal ini, kita akan membuat pelayan MCP yang ringkas menggunakan pengangkutan stdio yang disyorkan. Pelayan ini akan mendedahkan alat yang boleh dipanggil oleh klien menggunakan Protokol Model Context standard.

### Prasyarat

- Python 3.8 atau lebih baru.
- MCP Python SDK: `pip install mcp`.
- Pemahaman asas tentang pengaturcaraan async.

Mari kita mulakan dengan membuat pelayan MCP stdio pertama kita:

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

## Perbezaan utama dari pendekatan SSE yang dihentikan

**Pengangkutan Stdio (Standard Semasa):**
- Model subprocess yang mudah - klien melancarkan pelayan sebagai proses anak.
- Komunikasi melalui stdin/stdout menggunakan mesej JSON-RPC.
- Tidak memerlukan persediaan pelayan HTTP.
- Prestasi dan keselamatan yang lebih baik.
- Penyahpepijatan dan pembangunan yang lebih mudah.

**Pengangkutan SSE (Dihentikan mulai MCP 2025-06-18):**
- Memerlukan pelayan HTTP dengan endpoint SSE.
- Persediaan yang lebih kompleks dengan infrastruktur pelayan web.
- Pertimbangan keselamatan tambahan untuk endpoint HTTP.
- Kini digantikan oleh Streamable HTTP untuk senario berasaskan web.

### Membuat pelayan dengan pengangkutan stdio

Untuk membuat pelayan stdio kita, kita perlu:

1. **Mengimport pustaka yang diperlukan** - Kita memerlukan komponen pelayan MCP dan pengangkutan stdio.
2. **Mencipta instance pelayan** - Mendefinisikan pelayan dengan keupayaannya.
3. **Mendefinisikan alat** - Menambah fungsi yang ingin kita dedahkan.
4. **Menyiapkan pengangkutan** - Mengkonfigurasi komunikasi stdio.
5. **Menjalankan pelayan** - Memulakan pelayan dan mengendalikan mesej.

Mari kita bina langkah demi langkah:

### Langkah 1: Membuat pelayan stdio asas

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

### Langkah 2: Menambah lebih banyak alat

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

### Langkah 3: Menjalankan pelayan

Simpan kod sebagai `server.py` dan jalankan dari baris perintah:

```bash
python server.py
```

Pelayan akan bermula dan menunggu input dari stdin. Ia berkomunikasi menggunakan mesej JSON-RPC melalui pengangkutan stdio.

### Langkah 4: Ujian dengan Inspector

Anda boleh menguji pelayan anda menggunakan MCP Inspector:

1. Pasang Inspector: `npx @modelcontextprotocol/inspector`.
2. Jalankan Inspector dan arahkan ke pelayan anda.
3. Uji alat yang telah anda buat.

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

// Tambah alat
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Dapatkan ucapan peribadi",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Nama orang yang ingin disapa",
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
          text: `Hello, ${request.params.arguments?.name}! Selamat datang ke pelayan MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Alat tidak dikenali: ${request.params.name}`);
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
    [Description("Dapatkan ucapan peribadi")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Selamat datang ke pelayan MCP stdio.";
    }

    [Description("Kira jumlah dua nombor")]
    public int CalculateSum(int a, int b)
    {
        return $"Jumlah: {a + b}";
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

1. Mari kita buat beberapa alat terlebih dahulu, untuk ini kita akan mencipta fail *Tools.cs* dengan kandungan berikut:

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

2. **Buka antara muka web**: Inspector akan membuka tetingkap pelayar yang menunjukkan keupayaan pelayan anda.

3. **Uji alat**: 
   - Cuba alat `get_greeting` dengan nama yang berbeza.
   - Uji alat `calculate_sum` dengan pelbagai nombor.
   - Panggil alat `get_server_info` untuk melihat metadata pelayan.

4. **Pantau komunikasi**: Inspector menunjukkan mesej JSON-RPC yang dipertukarkan antara klien dan pelayan.

### Apa yang anda patut lihat

Apabila pelayan anda bermula dengan betul, anda patut melihat:
- Keupayaan pelayan disenaraikan dalam Inspector.
- Alat tersedia untuk diuji.
- Pertukaran mesej JSON-RPC yang berjaya.
- Respons alat dipaparkan dalam antara muka.

### Masalah biasa dan penyelesaian

**Pelayan tidak bermula:**
- Periksa bahawa semua kebergantungan telah dipasang: `pip install mcp`.
- Sahkan sintaks Python dan indentasi.
- Cari mesej ralat dalam konsol.

**Alat tidak muncul:**
- Pastikan dekorator `@server.tool()` hadir.
- Periksa bahawa fungsi alat ditakrifkan sebelum `main()`.
- Sahkan pelayan dikonfigurasi dengan betul.

**Masalah sambungan:**
- Pastikan pelayan menggunakan pengangkutan stdio dengan betul.
- Periksa bahawa tiada proses lain yang mengganggu.
- Sahkan sintaks arahan Inspector.

## Tugasan

Cuba bina pelayan anda dengan lebih banyak keupayaan. Lihat [halaman ini](https://api.chucknorris.io/) untuk, sebagai contoh, menambah alat yang memanggil API. Anda tentukan bagaimana pelayan itu sepatutnya kelihatan. Selamat mencuba :)

## Penyelesaian

[Solution](./solution/README.md) Berikut adalah penyelesaian yang mungkin dengan kod yang berfungsi.

## Poin Penting

Poin penting dari bab ini adalah seperti berikut:

- Pengangkutan stdio adalah mekanisme yang disyorkan untuk pelayan MCP tempatan.
- Pengangkutan stdio membolehkan komunikasi lancar antara pelayan MCP dan klien menggunakan aliran input dan output standard.
- Anda boleh menggunakan Inspector dan Visual Studio Code untuk menggunakan pelayan stdio secara langsung, menjadikan penyahpepijatan dan integrasi lebih mudah.

## Contoh 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Sumber Tambahan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Apa Seterusnya

## Langkah Seterusnya

Sekarang anda telah belajar bagaimana membina pelayan MCP dengan pengangkutan stdio, anda boleh meneroka topik yang lebih maju:

- **Seterusnya**: [HTTP Streaming dengan MCP (Streamable HTTP)](../06-http-streaming/README.md) - Pelajari tentang mekanisme pengangkutan lain yang disokong untuk pelayan jauh.
- **Lanjutan**: [Amalan Terbaik Keselamatan MCP](../../02-Security/README.md) - Laksanakan keselamatan dalam pelayan MCP anda.
- **Pengeluaran**: [Strategi Penerapan](../09-deployment/README.md) - Terapkan pelayan anda untuk penggunaan pengeluaran.

## Sumber Tambahan

- [Spesifikasi MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Spesifikasi rasmi.
- [Dokumentasi MCP SDK](https://github.com/modelcontextprotocol/sdk) - Rujukan SDK untuk semua bahasa.
- [Contoh Komuniti](../../06-CommunityContributions/README.md) - Lebih banyak contoh pelayan dari komuniti.

---

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk memastikan ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat yang kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.