<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T08:08:03+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ms"
}
-->
# Membina klien

Klien adalah aplikasi atau skrip khusus yang berkomunikasi secara langsung dengan MCP Server untuk meminta sumber, alat, dan arahan. Berbeza dengan menggunakan alat pemeriksa yang menyediakan antara muka grafik untuk berinteraksi dengan server, menulis klien sendiri membolehkan interaksi secara programatik dan automatik. Ini membolehkan pembangun mengintegrasikan keupayaan MCP ke dalam aliran kerja mereka sendiri, mengautomasikan tugasan, dan membina penyelesaian khusus yang disesuaikan dengan keperluan tertentu.

## Gambaran Keseluruhan

Pelajaran ini memperkenalkan konsep klien dalam ekosistem Model Context Protocol (MCP). Anda akan belajar cara menulis klien sendiri dan menyambungkannya ke MCP Server.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Memahami apa yang boleh dilakukan oleh klien.
- Menulis klien anda sendiri.
- Menyambung dan menguji klien dengan MCP server untuk memastikan ia berfungsi seperti yang dijangkakan.

## Apa yang terlibat dalam menulis klien?

Untuk menulis klien, anda perlu melakukan perkara berikut:

- **Import perpustakaan yang betul**. Anda akan menggunakan perpustakaan yang sama seperti sebelum ini, cuma dengan struktur yang berbeza.
- **Mewujudkan instans klien**. Ini melibatkan penciptaan instans klien dan menyambungkannya ke kaedah pengangkutan yang dipilih.
- **Memutuskan sumber apa yang hendak disenaraikan**. MCP server anda mempunyai sumber, alat dan arahan, anda perlu memutuskan yang mana satu untuk disenaraikan.
- **Mengintegrasikan klien ke dalam aplikasi hos**. Setelah anda mengetahui keupayaan server, anda perlu mengintegrasikannya ke dalam aplikasi hos supaya jika pengguna menaip arahan atau perintah lain, ciri server yang sepadan akan dipanggil.

Sekarang kita sudah faham secara umum apa yang akan kita lakukan, mari kita lihat contoh seterusnya.

### Contoh klien

Mari kita lihat contoh klien ini:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

Dalam kod di atas kita:

- Mengimport perpustakaan
- Mencipta instans klien dan menyambungkannya menggunakan stdio sebagai pengangkutan.
- Menyenaraikan arahan, sumber dan alat serta memanggil kesemuanya.

Itulah dia, klien yang boleh berkomunikasi dengan MCP Server.

Mari kita luangkan masa dalam bahagian latihan seterusnya untuk menguraikan setiap potongan kod dan menerangkan apa yang sedang berlaku.

## Latihan: Menulis klien

Seperti yang disebutkan tadi, mari kita luangkan masa untuk menerangkan kod, dan anda boleh ikut menulis kod jika mahu.

### -1- Import perpustakaan

Mari kita import perpustakaan yang diperlukan, kita akan memerlukan rujukan kepada klien dan protokol pengangkutan yang dipilih, stdio. stdio adalah protokol untuk perkara yang dijalankan pada mesin tempatan anda. SSE adalah protokol pengangkutan lain yang akan kami tunjukkan dalam bab akan datang tetapi itu adalah pilihan lain anda. Buat masa ini, mari teruskan dengan stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Untuk Java, anda akan mencipta klien yang menyambung ke MCP server dari latihan sebelumnya. Menggunakan struktur projek Java Spring Boot yang sama dari [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), cipta kelas Java baru bernama `SDKClient` dalam folder `src/main/java/com/microsoft/mcp/sample/client/` dan tambah import berikut:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

Mari kita teruskan ke penciptaan instans.

### -2- Mewujudkan instans klien dan pengangkutan

Kita perlu mencipta instans pengangkutan dan instans klien kita:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

Dalam kod di atas kita telah:

- Mencipta instans pengangkutan stdio. Perhatikan bagaimana ia menentukan command dan args untuk mencari dan memulakan server kerana itu adalah sesuatu yang perlu kita lakukan semasa mencipta klien.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Mewujudkan klien dengan memberikan nama dan versi.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Menyambungkan klien ke pengangkutan yang dipilih.

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

Dalam kod di atas kita telah:

- Mengimport perpustakaan yang diperlukan
- Mewujudkan objek parameter server kerana kita akan menggunakannya untuk menjalankan server supaya kita boleh menyambung kepadanya dengan klien kita.
- Mendefinisikan kaedah `run` yang seterusnya memanggil `stdio_client` yang memulakan sesi klien.
- Mencipta titik masuk di mana kita menyediakan kaedah `run` kepada `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

Dalam kod di atas kita telah:

- Mengimport perpustakaan yang diperlukan.
- Mencipta pengangkutan stdio dan mencipta klien `mcpClient`. Ini adalah sesuatu yang akan kita gunakan untuk menyenaraikan dan memanggil ciri pada MCP Server.

Nota, dalam "Arguments", anda boleh menunjuk kepada *.csproj* atau kepada fail boleh laku.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

Dalam kod di atas kita telah:

- Mencipta kaedah main yang menyediakan pengangkutan SSE menunjuk ke `http://localhost:8080` di mana MCP server kita akan berjalan.
- Mencipta kelas klien yang mengambil pengangkutan sebagai parameter konstruktor.
- Dalam kaedah `run`, kita mencipta klien MCP secara sinkron menggunakan pengangkutan dan memulakan sambungan.
- Menggunakan pengangkutan SSE (Server-Sent Events) yang sesuai untuk komunikasi berasaskan HTTP dengan MCP server Java Spring Boot.

### -3- Menyenaraikan ciri server

Sekarang, kita mempunyai klien yang boleh menyambung jika program dijalankan. Namun, ia tidak menyenaraikan ciri-cirinya, jadi mari kita lakukan itu sekarang:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

Di sini kita menyenaraikan sumber yang tersedia, `list_resources()` dan alat, `list_tools` dan mencetaknya.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Di atas adalah contoh bagaimana kita boleh menyenaraikan alat pada server. Untuk setiap alat, kita kemudian mencetak namanya.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Dalam kod di atas kita telah:

- Memanggil `listTools()` untuk mendapatkan semua alat yang tersedia dari MCP server.
- Menggunakan `ping()` untuk mengesahkan bahawa sambungan ke server berfungsi.
- `ListToolsResult` mengandungi maklumat tentang semua alat termasuk nama, penerangan, dan skema input mereka.

Bagus, sekarang kita telah menangkap semua ciri. Soalannya, bila kita gunakan mereka? Klien ini agak mudah, maksudnya kita perlu memanggil ciri-ciri itu secara eksplisit apabila kita mahu. Dalam bab seterusnya, kita akan mencipta klien yang lebih maju yang mempunyai akses kepada model bahasa besar sendiri, LLM. Buat masa ini, mari lihat bagaimana kita boleh memanggil ciri pada server:

### -4- Memanggil ciri

Untuk memanggil ciri, kita perlu pastikan kita menyatakan argumen yang betul dan dalam beberapa kes nama apa yang kita cuba panggil.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

Dalam kod di atas kita:

- Membaca sumber, kita panggil sumber dengan memanggil `readResource()` dan menyatakan `uri`. Ini kemungkinan besar kelihatan seperti ini di sisi server:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Nilai `uri` kita `file://example.txt` sepadan dengan `file://{name}` pada server. `example.txt` akan dipetakan kepada `name`.

- Memanggil alat, kita panggil dengan menyatakan `name` dan `arguments` seperti berikut:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Mendapatkan arahan, untuk mendapatkan arahan, anda panggil `getPrompt()` dengan `name` dan `arguments`. Kod server kelihatan seperti ini:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    dan kod klien anda yang terhasil kelihatan seperti ini untuk sepadan dengan apa yang diisytiharkan pada server:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

Dalam kod di atas, kita telah:

- Memanggil sumber bernama `greeting` menggunakan `read_resource`.
- Memanggil alat bernama `add` menggunakan `call_tool`.

### C#

1. Mari kita tambah kod untuk memanggil alat:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Untuk mencetak hasil, ini adalah kod untuk mengendalikannya:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

Dalam kod di atas kita telah:

- Memanggil beberapa alat kalkulator menggunakan kaedah `callTool()` dengan objek `CallToolRequest`.
- Setiap panggilan alat menyatakan nama alat dan `Map` argumen yang diperlukan oleh alat tersebut.
- Alat server mengharapkan nama parameter tertentu (seperti "a", "b" untuk operasi matematik).
- Keputusan dikembalikan sebagai objek `CallToolResult` yang mengandungi respons dari server.

### -5- Menjalankan klien

Untuk menjalankan klien, taip arahan berikut di terminal:

### TypeScript

Tambah entri berikut ke bahagian "scripts" dalam *package.json* anda:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Panggil klien dengan arahan berikut:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Pertama, pastikan MCP server anda berjalan di `http://localhost:8080`. Kemudian jalankan klien:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Sebagai alternatif, anda boleh menjalankan projek klien lengkap yang disediakan dalam folder penyelesaian `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tugasan

Dalam tugasan ini, anda akan menggunakan apa yang telah anda pelajari dalam membina klien tetapi mencipta klien anda sendiri.

Ini adalah server yang boleh anda gunakan yang perlu anda panggil melalui kod klien anda, cuba lihat jika anda boleh menambah lebih banyak ciri pada server untuk menjadikannya lebih menarik.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

Lihat projek ini untuk melihat bagaimana anda boleh [menambah arahan dan sumber](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Juga, semak pautan ini untuk cara memanggil [arahan dan sumber](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Penyelesaian

[Penyelesaian](./solution/README.md)

## Perkara Penting

Perkara penting untuk bab ini mengenai klien adalah seperti berikut:

- Boleh digunakan untuk mencari dan memanggil ciri pada server.
- Boleh memulakan server semasa ia memulakan dirinya sendiri (seperti dalam bab ini) tetapi klien juga boleh menyambung ke server yang sedang berjalan.
- Merupakan cara yang baik untuk menguji keupayaan server berbanding alternatif seperti Inspector seperti yang diterangkan dalam bab sebelumnya.

## Sumber Tambahan

- [Membina klien dalam MCP](https://modelcontextprotocol.io/quickstart/client)

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Apa Seterusnya

- Seterusnya: [Membina klien dengan LLM](../03-llm-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.