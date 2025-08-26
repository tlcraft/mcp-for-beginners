<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:32:36+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "tr"
}
-->
# MCP Sunucusu stdio Taşıma ile

> **⚠️ Önemli Güncelleme**: MCP Spesifikasyonu 2025-06-18 itibarıyla, bağımsız SSE (Server-Sent Events) taşıma yöntemi **kaldırılmış** ve yerine "Streamable HTTP" taşıma yöntemi getirilmiştir. Mevcut MCP spesifikasyonu iki ana taşıma mekanizmasını tanımlar:
> 1. **stdio** - Standart giriş/çıkış (yerel sunucular için önerilir)
> 2. **Streamable HTTP** - SSE'yi dahili olarak kullanabilecek uzak sunucular için
>
> Bu ders, çoğu MCP sunucu uygulaması için önerilen yaklaşım olan **stdio taşıma** üzerine odaklanacak şekilde güncellenmiştir.

Stdio taşıma, MCP sunucularının standart giriş ve çıkış akışları aracılığıyla istemcilerle iletişim kurmasını sağlar. Bu, mevcut MCP spesifikasyonunda en yaygın kullanılan ve önerilen taşıma mekanizmasıdır ve çeşitli istemci uygulamalarıyla kolayca entegre edilebilen basit ve verimli bir yol sunar.

## Genel Bakış

Bu ders, stdio taşıma kullanarak MCP Sunucuları oluşturmayı ve tüketmeyi kapsar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Stdio taşıma kullanarak bir MCP Sunucusu oluşturmak.
- MCP Sunucusunu Inspector ile hata ayıklamak.
- MCP Sunucusunu Visual Studio Code kullanarak tüketmek.
- Mevcut MCP taşıma mekanizmalarını ve neden stdio'nun önerildiğini anlamak.

## stdio Taşıma - Nasıl Çalışır?

Stdio taşıma, mevcut MCP spesifikasyonunda (2025-06-18) desteklenen iki taşıma türünden biridir. İşte nasıl çalıştığı:

- **Basit İletişim**: Sunucu, standart girişten (`stdin`) JSON-RPC mesajlarını okur ve standart çıkışa (`stdout`) mesajlar gönderir.
- **İşlem Tabanlı**: İstemci, MCP sunucusunu bir alt işlem olarak başlatır.
- **Mesaj Formatı**: Mesajlar, yeni satırlarla ayrılmış bireysel JSON-RPC istekleri, bildirimleri veya yanıtlarıdır.
- **Günlükleme**: Sunucu, günlükleme amacıyla standart hataya (`stderr`) UTF-8 dizeleri yazabilir.

### Temel Gereksinimler:
- Mesajlar yeni satırlarla ayrılmalıdır ve gömülü yeni satırlar içermemelidir.
- Sunucu, `stdout`'a geçerli bir MCP mesajı olmayan hiçbir şey yazmamalıdır.
- İstemci, sunucunun `stdin`'ine geçerli bir MCP mesajı olmayan hiçbir şey yazmamalıdır.

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

Yukarıdaki kodda:

- MCP SDK'den `Server` sınıfını ve `StdioServerTransport`'u içe aktarıyoruz.
- Temel yapılandırma ve yeteneklerle bir sunucu örneği oluşturuyoruz.

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

Yukarıdaki kodda:

- MCP SDK kullanarak bir sunucu örneği oluşturuyoruz.
- Dekoratörler kullanarak araçlar tanımlıyoruz.
- stdio_server bağlam yöneticisini taşıma işlemini yönetmek için kullanıyoruz.

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

SSE'den temel farklar şunlardır:

- Web sunucusu kurulumu veya HTTP uç noktaları gerektirmez.
- İstemci tarafından alt işlem olarak başlatılır.
- stdin/stdout akışları aracılığıyla iletişim kurar.
- Uygulaması ve hata ayıklaması daha basittir.

## Egzersiz: Bir stdio Sunucusu Oluşturma

Sunucumuzu oluşturmak için iki şeyi akılda tutmamız gerekiyor:

- Bağlantı ve mesajlar için uç noktalar sunmak üzere bir web sunucusu kullanmamız gerekiyor.

## Laboratuvar: Basit bir MCP stdio sunucusu oluşturma

Bu laboratuvarda, önerilen stdio taşıma yöntemini kullanarak basit bir MCP sunucusu oluşturacağız. Bu sunucu, istemcilerin standart Model Context Protocol kullanarak çağırabileceği araçlar sunacak.

### Ön Koşullar

- Python 3.8 veya üstü
- MCP Python SDK: `pip install mcp`
- Temel async programlama bilgisi

Haydi ilk MCP stdio sunucumuzu oluşturalım:

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

## Kaldırılan SSE yaklaşımından temel farklar

**Stdio Taşıma (Mevcut Standart):**
- Basit alt işlem modeli - istemci sunucuyu alt işlem olarak başlatır.
- JSON-RPC mesajları kullanarak stdin/stdout üzerinden iletişim.
- HTTP sunucusu kurulumu gerekmez.
- Daha iyi performans ve güvenlik.
- Daha kolay hata ayıklama ve geliştirme.

**SSE Taşıma (MCP 2025-06-18 itibarıyla kaldırıldı):**
- SSE uç noktaları olan HTTP sunucusu gerektiriyordu.
- Web sunucusu altyapısı ile daha karmaşık kurulum.
- HTTP uç noktaları için ek güvenlik hususları.
- Web tabanlı senaryolar için Streamable HTTP ile değiştirildi.

### stdio taşıma ile bir sunucu oluşturma

Stdio sunucumuzu oluşturmak için şunları yapmamız gerekiyor:

1. **Gerekli kütüphaneleri içe aktarma** - MCP sunucu bileşenlerini ve stdio taşımayı içe aktarmamız gerekiyor.
2. **Bir sunucu örneği oluşturma** - Sunucuyu yetenekleriyle tanımlayın.
3. **Araçlar tanımlama** - Sunmak istediğimiz işlevselliği ekleyin.
4. **Taşımayı ayarlama** - Stdio iletişimini yapılandırın.
5. **Sunucuyu çalıştırma** - Sunucuyu başlatın ve mesajları yönetin.

Haydi adım adım oluşturalım:

### Adım 1: Temel bir stdio sunucusu oluşturma

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

### Adım 2: Daha fazla araç ekleme

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

### Adım 3: Sunucuyu çalıştırma

Kodunuzu `server.py` olarak kaydedin ve komut satırından çalıştırın:

```bash
python server.py
```

Sunucu başlayacak ve stdin'den giriş bekleyecek. JSON-RPC mesajları üzerinden stdio taşıma kullanarak iletişim kurar.

### Adım 4: Inspector ile test etme

Sunucunuzu MCP Inspector kullanarak test edebilirsiniz:

1. Inspector'ı yükleyin: `npx @modelcontextprotocol/inspector`
2. Inspector'ı çalıştırın ve sunucunuza yönlendirin.
3. Oluşturduğunuz araçları test edin.

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

// Araçları ekle
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Kişiselleştirilmiş bir selamlama alın",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Selamlanacak kişinin adı",
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
          text: `Merhaba, ${request.params.arguments?.name}! MCP stdio sunucusuna hoş geldiniz.`,
        },
      ],
    };
  } else {
    throw new Error(`Bilinmeyen araç: ${request.params.name}`);
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
    [Description("Kişiselleştirilmiş bir selamlama alın")]
    public string GetGreeting(string name)
    {
        return $"Merhaba, {name}! MCP stdio sunucusuna hoş geldiniz.";
    }

    [Description("İki sayının toplamını hesaplayın")]
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

1. Önce bazı araçlar oluşturalım, bunun için *Tools.cs* dosyasını aşağıdaki içerikle oluşturacağız:

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

2. **Web arayüzünü açın**: Inspector bir tarayıcı penceresi açarak sunucunuzun yeteneklerini gösterecek.

3. **Araçları test edin**: 
   - Farklı isimlerle `get_greeting` aracını deneyin.
   - Çeşitli sayılarla `calculate_sum` aracını test edin.
   - Sunucu meta verilerini görmek için `get_server_info` aracını çağırın.

4. **İletişimi izleyin**: Inspector, istemci ve sunucu arasında değiş tokuş edilen JSON-RPC mesajlarını gösterir.

### Görmeniz gerekenler

Sunucunuz doğru şekilde başlatıldığında şunları görmelisiniz:
- Inspector'da listelenen sunucu yetenekleri.
- Test edilebilecek araçlar.
- Başarılı JSON-RPC mesaj alışverişleri.
- Arayüzde gösterilen araç yanıtları.

### Yaygın sorunlar ve çözümler

**Sunucu başlamıyor:**
- Tüm bağımlılıkların yüklü olduğundan emin olun: `pip install mcp`
- Python sözdizimi ve girintiyi kontrol edin.
- Konsoldaki hata mesajlarını inceleyin.

**Araçlar görünmüyor:**
- `@server.tool()` dekoratörlerinin mevcut olduğundan emin olun.
- Araç işlevlerinin `main()`'den önce tanımlandığını kontrol edin.
- Sunucunun doğru şekilde yapılandırıldığını doğrulayın.

**Bağlantı sorunları:**
- Sunucunun stdio taşımayı doğru şekilde kullandığından emin olun.
- Başka işlemlerin müdahale etmediğinden emin olun.
- Inspector komut sözdizimini doğrulayın.

## Ödev

Sunucunuzu daha fazla yetenekle geliştirmeyi deneyin. Örneğin, [bu sayfayı](https://api.chucknorris.io/) kullanarak bir API çağıran bir araç ekleyebilirsiniz. Sunucunun nasıl görüneceğine siz karar verin. İyi eğlenceler :)

## Çözüm

[Çözüm](./solution/README.md) Çalışan kod ile olası bir çözüm burada.

## Temel Çıkarımlar

Bu bölümden çıkarılacak temel noktalar şunlardır:

- Stdio taşıma, yerel MCP sunucuları için önerilen mekanizmadır.
- Stdio taşıma, MCP sunucuları ve istemciler arasında standart giriş ve çıkış akışlarını kullanarak sorunsuz iletişim sağlar.
- Inspector ve Visual Studio Code'u kullanarak stdio sunucularını doğrudan tüketebilir, hata ayıklamayı ve entegrasyonu kolaylaştırabilirsiniz.

## Örnekler 

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python) 

## Ek Kaynaklar

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Sırada Ne Var

## Sonraki Adımlar

Artık stdio taşıma ile MCP sunucuları oluşturmayı öğrendiğinize göre, daha ileri konuları keşfedebilirsiniz:

- **Sonraki**: [MCP ile HTTP Akışı (Streamable HTTP)](../06-http-streaming/README.md) - Uzak sunucular için desteklenen diğer taşıma mekanizmasını öğrenin.
- **İleri Düzey**: [MCP Güvenlik En İyi Uygulamaları](../../02-Security/README.md) - MCP sunucularınızda güvenlik uygulayın.
- **Üretim**: [Dağıtım Stratejileri](../09-deployment/README.md) - Sunucularınızı üretim kullanımı için dağıtın.

## Ek Kaynaklar

- [MCP Spesifikasyonu 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Resmi spesifikasyon
- [MCP SDK Belgeleri](https://github.com/modelcontextprotocol/sdk) - Tüm diller için SDK referansları
- [Topluluk Örnekleri](../../06-CommunityContributions/README.md) - Topluluktan daha fazla sunucu örneği

---

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul etmiyoruz.