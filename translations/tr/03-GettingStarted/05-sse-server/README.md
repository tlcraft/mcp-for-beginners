<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T01:32:39+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tr"
}
-->
# SSE Sunucusu

SSE (Server Sent Events), sunucudan istemciye gerçek zamanlı veri akışı sağlayan bir standarttır ve sunucuların HTTP üzerinden istemcilere anlık güncellemeler göndermesine olanak tanır. Bu, sohbet uygulamaları, bildirimler veya gerçek zamanlı veri akışları gibi canlı güncellemeler gerektiren uygulamalar için özellikle faydalıdır. Ayrıca, sunucunuz bulutta bir yerde çalıştırılabilir ve aynı anda birden fazla istemci tarafından kullanılabilir.

## Genel Bakış

Bu ders, SSE Sunucularının nasıl oluşturulacağını ve kullanılacağını kapsar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Bir SSE Sunucusu oluşturmak.
- Inspector kullanarak bir SSE Sunucusunu hata ayıklamak.
- Visual Studio Code kullanarak bir SSE Sunucusunu tüketmek.

## SSE, nasıl çalışır

SSE, desteklenen iki taşıma türünden biridir. Önceki derslerde stdio kullanımını görmüştünüz. Aralarındaki farklar şunlardır:

- SSE, bağlantı ve mesajları yönetmenizi gerektirir.
- Bu sunucu herhangi bir yerde çalışabilir, bu yüzden Inspector ve Visual Studio Code gibi araçlarla çalışırken bunu göz önünde bulundurmalısınız. Yani, sunucuyu nasıl başlatacağınızı göstermek yerine, bağlantı kurulacak uç noktayı belirtirsiniz. Aşağıdaki örnek koda bakın:

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

Yukarıdaki kodda:

- `/sse` bir rota olarak ayarlanmıştır. Bu rotaya bir istek geldiğinde yeni bir taşıma örneği oluşturulur ve sunucu bu taşıma ile *bağlanır*.
- `/messages`, gelen mesajları işleyen rotadır.

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

Yukarıdaki kodda:

- Bir ASGI sunucu örneği (özellikle Starlette kullanılarak) oluşturulur ve varsayılan rota `/` mount edilir.

  Arkada `/sse` ve `/messages` rotalarının sırasıyla bağlantılar ve mesajlar için ayarlandığını unutmayın. Diğer uygulama özellikleri, stdio sunucularında olduğu gibi eklenir.

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

    Web sunucusundan SSE destekleyen bir web sunucusuna geçmemize yardımcı olan iki yöntem vardır:

    - `AddMcpServer`, bu yöntem özellikleri ekler.
    - `MapMcp`, bu da `/SSE` ve `/messages` gibi rotaları ekler.

Artık SSE hakkında biraz daha bilgi sahibi olduğumuza göre, bir SSE sunucusu oluşturalım.

## Alıştırma: Bir SSE Sunucusu Oluşturma

Sunucumuzu oluştururken iki şeyi akılda tutmalıyız:

- Bağlantı ve mesajlar için uç noktaları açmak üzere bir web sunucusu kullanmalıyız.
- Sunucumuzu, stdio kullanırken yaptığımız gibi araçlar, kaynaklar ve istemlerle normal şekilde oluşturmalıyız.

### -1- Sunucu örneği oluşturma

Sunucumuzu oluşturmak için stdio ile kullandığımız aynı türleri kullanıyoruz. Ancak taşıma için SSE seçmeliyiz.

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

Yukarıdaki kodda:

- Bir sunucu örneği oluşturduk.
- express web framework kullanarak bir uygulama tanımladık.
- Gelen bağlantıları saklamak için kullanacağımız bir transports değişkeni oluşturduk.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Yukarıdaki kodda:

- İhtiyacımız olan kütüphaneleri içe aktardık, Starlette (bir ASGI framework) dahil edildi.
- Bir MCP sunucu örneği `mcp` oluşturduk.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Bu noktada:

- Bir web uygulaması oluşturduk.
- `AddMcpServer` ile MCP özellikleri için destek ekledik.

Şimdi gerekli rotaları ekleyelim.

### -2- Rotaları ekleme

Bağlantı ve gelen mesajları yönetecek rotaları ekleyelim:

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

Yukarıdaki kodda:

- SSE türünde bir taşıma örneği oluşturan ve MCP sunucusunda `connect` çağrısı yapan `/sse` rotası tanımlandı.
- Gelen mesajları işleyen `/messages` rotası tanımlandı.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Yukarıdaki kodda:

- Starlette framework kullanarak bir ASGI uygulama örneği oluşturduk. `mcp.sse_app()`'i rotalar listesine ekledik. Bu, uygulama örneğinde `/sse` ve `/messages` rotalarının mount edilmesini sağlar.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Son satıra `add.MapMcp()` satırını ekledik, bu sayede `/SSE` ve `/messages` rotalarımız oldu.

Şimdi sunucuya özellikler ekleyelim.

### -3- Sunucu özellikleri ekleme

Artık SSE'ye özgü her şeyi tanımladığımıza göre, araçlar, istemler ve kaynaklar gibi sunucu özelliklerini ekleyelim.

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

Örneğin, bir araç nasıl eklenir gösteriliyor. Bu özel araç, "random-joke" adında bir araç oluşturur, Chuck Norris API'sini çağırır ve JSON yanıtı döner.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Artık sunucunuzda bir araç var.

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

1. Öncelikle bazı araçlar oluşturalım, bunun için *Tools.cs* adlı bir dosya oluşturup aşağıdaki içeriği ekleyelim:

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

  Burada şunları yaptık:

  - `McpServerToolType` dekoratörü ile `Tools` sınıfı oluşturuldu.
  - `McpServerTool` dekoratörü ile `AddNumbers` aracı tanımlandı. Parametreler ve uygulama sağlandı.

1. Az önce oluşturduğumuz `Tools` sınıfını kullanalım:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  `WithTools` çağrısı ekledik ve araçların bulunduğu sınıf olarak `Tools` belirtildi. Hepsi bu, hazırız.

Harika, SSE kullanan bir sunucumuz var, şimdi onu deneyelim.

## Alıştırma: Inspector ile SSE Sunucusunu Hata Ayıklama

Inspector, önceki derste gördüğümüz harika bir araçtır [İlk sunucunuzu oluşturma](/03-GettingStarted/01-first-server/README.md). Burada da Inspector kullanabilir miyiz bakalım:

### -1- Inspector'ı çalıştırma

Inspector'ı çalıştırmak için önce bir SSE sunucusunun çalışıyor olması gerekir, o halde bunu yapalım:

1. Sunucuyu çalıştırın

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    `pip install "mcp[cli]"` komutunu yazdığınızda kurulan `uvicorn` çalıştırılabilir dosyasını kullandığımıza dikkat edin. `server:app` yazmak, `server.py` dosyasını çalıştırmaya ve içinde `app` adlı bir Starlette örneği olmasını beklemeye karşılık gelir.

    ### .NET

    ```sh
    dotnet run
    ```

    Bu sunucuyu başlatmalıdır. Sunucu ile etkileşim için yeni bir terminal açmanız gerekir.

1. Inspector'ı çalıştırın

    > ![NOTE]
    > Bunu, sunucunun çalıştığı terminalden farklı bir terminal penceresinde çalıştırın. Ayrıca, aşağıdaki komutu sunucunuzun çalıştığı URL'ye göre ayarlamanız gerektiğini unutmayın.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector'ı çalıştırmak tüm çalışma zamanlarında aynıdır. Sunucuyu başlatmak için bir yol ve komut vermek yerine, sunucunun çalıştığı URL'yi ve `/sse` rotasını belirttiğimize dikkat edin.

### -2- Aracı deneme

Sunucuya bağlanmak için açılır listeden SSE'yi seçin ve sunucunuzun çalıştığı URL'yi, örneğin http:localhost:4321/sse, url alanına girin. Ardından "Connect" düğmesine tıklayın. Önceki gibi, araçları listeleyin, bir araç seçin ve giriş değerlerini sağlayın. Aşağıdaki gibi bir sonuç görmelisiniz:

![Inspector'da çalışan SSE Sunucusu](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tr.png)

Harika, Inspector ile çalışabiliyorsunuz, şimdi Visual Studio Code ile nasıl çalışabileceğimize bakalım.

## Ödev

Sunucunuzu daha fazla özellik ekleyerek geliştirmeyi deneyin. Örneğin, bir API çağıran bir araç eklemek için [bu sayfaya](https://api.chucknorris.io/) bakabilirsiniz. Sunucunun nasıl görüneceğine siz karar verin. İyi eğlenceler :)

## Çözüm

[Çözüm](./solution/README.md) Çalışan kodla olası bir çözüm burada.

## Önemli Noktalar

Bu bölümden çıkarılacak önemli noktalar şunlardır:

- SSE, stdio'nun yanında desteklenen ikinci taşıma türüdür.
- SSE'yi desteklemek için gelen bağlantıları ve mesajları bir web framework kullanarak yönetmeniz gerekir.
- Inspector ve Visual Studio Code'u, stdio sunucularında olduğu gibi SSE sunucusunu tüketmek için kullanabilirsiniz. Ancak stdio ve SSE arasında bazı farklar vardır. SSE için sunucuyu ayrı başlatmanız ve ardından Inspector aracını çalıştırmanız gerekir. Inspector aracı için ayrıca URL belirtmeniz gerekir.

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Sonraki Adım

- Sonraki: [MCP ile HTTP Akışı (Streamable HTTP)](../06-http-streaming/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.