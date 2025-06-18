<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:28:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "cs"
}
-->
# HTTPS streamování s Model Context Protocol (MCP)

Tato kapitola poskytuje komplexní návod na implementaci zabezpečeného, škálovatelného a real-time streamování pomocí Model Context Protocol (MCP) přes HTTPS. Pokrývá motivaci ke streamování, dostupné transportní mechanismy, jak implementovat streamovatelné HTTP v MCP, bezpečnostní doporučení, migraci ze SSE a praktické rady pro tvorbu vlastních streamovacích MCP aplikací.

## Transportní mechanismy a streamování v MCP

Tato sekce zkoumá různé transportní mechanismy dostupné v MCP a jejich roli při umožnění streamovacích schopností pro real-time komunikaci mezi klienty a servery.

### Co je transportní mechanismus?

Transportní mechanismus definuje, jak jsou data vyměňována mezi klientem a serverem. MCP podporuje více typů transportu, aby vyhověl různým prostředím a požadavkům:

- **stdio**: Standardní vstup/výstup, vhodný pro lokální a CLI nástroje. Jednoduchý, ale nevhodný pro web nebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverům posílat klientům real-time aktualizace přes HTTP. Dobré pro webová uživatelská rozhraní, ale omezené v škálovatelnosti a flexibilitě.
- **Streamable HTTP**: Moderní HTTP-based streamovací transport, podporující notifikace a lepší škálovatelnost. Doporučený pro většinu produkčních a cloudových scénářů.

### Porovnávací tabulka

Podívejte se na následující tabulku, která shrnuje rozdíly mezi těmito transportními mechanismy:

| Transport         | Real-time aktualizace | Streamování | Škálovatelnost | Použití                  |
|-------------------|----------------------|-------------|----------------|--------------------------|
| stdio             | Ne                   | Ne          | Nízká          | Lokální CLI nástroje     |
| SSE               | Ano                  | Ano         | Střední        | Web, real-time aktualizace|
| Streamable HTTP   | Ano                  | Ano         | Vysoká         | Cloud, multi-klient      |

> **Tip:** Volba správného transportu ovlivňuje výkon, škálovatelnost a uživatelský zážitek. **Streamable HTTP** je doporučený pro moderní, škálovatelné a cloud-ready aplikace.

Všimněte si transportů stdio a SSE, které byly zmíněny v předchozích kapitolách, a jak streamovatelné HTTP je hlavním transportem probíraným v této kapitole.

## Streamování: koncepty a motivace

Pochopení základních konceptů a motivací za streamováním je klíčové pro efektivní implementaci real-time komunikačních systémů.

**Streamování** je technika v síťovém programování, která umožňuje odesílat a přijímat data v malých, zvládnutelných částech nebo jako posloupnost událostí, místo čekání na kompletní odpověď. To je zvlášť užitečné pro:

- Velké soubory nebo datové sady.
- Real-time aktualizace (např. chat, ukazatele průběhu).
- Dlouhotrvající výpočty, kde chcete uživatele průběžně informovat.

Základní fakta o streamování:

- Data jsou doručována postupně, ne najednou.
- Klient může data zpracovávat průběžně, jak přicházejí.
- Snižuje vnímanou latenci a zlepšuje uživatelský zážitek.

### Proč používat streamování?

Důvody pro použití streamování jsou:

- Uživatelé dostávají zpětnou vazbu okamžitě, ne až na konci.
- Umožňuje real-time aplikace a responzivní uživatelská rozhraní.
- Efektivnější využití síťových a výpočetních zdrojů.

### Jednoduchý příklad: HTTP streamovací server a klient

Zde je jednoduchý příklad, jak může být streamování implementováno:

<details>
<summary>Python</summary>

**Server (Python, používá FastAPI a StreamingResponse):**
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

**Klient (Python, používá requests):**
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

Tento příklad ukazuje server, který odesílá sérii zpráv klientovi, jakmile jsou k dispozici, místo čekání na všechny zprávy.

**Jak to funguje:**
- Server postupně odesílá každou zprávu, jakmile je připravená.
- Klient přijímá a vypisuje každou část, jak přichází.

**Požadavky:**
- Server musí používat streamovací odpověď (např. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, používá Spring Boot a Server-Sent Events):**

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

**Klient (Java, používá Spring WebFlux WebClient):**

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

**Poznámky k implementaci v Javě:**
- Používá reaktivní stack Spring Boot s `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) oproti výběru streamování přes MCP.

- **Pro jednoduché potřeby streamování:** Klasické HTTP streamování je jednodušší na implementaci a dostačující pro základní požadavky.

- **Pro složité, interaktivní aplikace:** MCP streamování poskytuje strukturovanější přístup s bohatšími metadaty a oddělením notifikací od finálních výsledků.

- **Pro AI aplikace:** Notifikační systém MCP je obzvláště užitečný pro dlouhotrvající AI úlohy, kde chcete uživatele průběžně informovat o pokroku.

## Streamování v MCP

Viděli jste dosud doporučení a porovnání klasického streamování a streamování v MCP. Pojďme se detailně podívat, jak můžete streamování v MCP využít.

Pochopení, jak streamování funguje v rámci MCP, je nezbytné pro tvorbu responzivních aplikací, které poskytují uživatelům real-time zpětnou vazbu během dlouhotrvajících operací.

V MCP nejde o odesílání hlavní odpovědi po částech, ale o odesílání **notifikací** klientovi, zatímco nástroj zpracovává požadavek. Tyto notifikace mohou obsahovat informace o průběhu, logy nebo jiné události.

### Jak to funguje

Hlavní výsledek je stále odeslán jako jedna odpověď. Notifikace však mohou být odesílány jako samostatné zprávy během zpracování a tím aktualizovat klienta v reálném čase. Klient musí být schopen tyto notifikace zpracovat a zobrazit.

## Co je to notifikace?

Řekli jsme „notifikace“, co to znamená v kontextu MCP?

Notifikace je zpráva odeslaná ze serveru klientovi, která informuje o průběhu, stavu nebo jiných událostech během dlouhotrvající operace. Notifikace zvyšují transparentnost a uživatelský komfort.

Například klient by měl odeslat notifikaci, jakmile je navázáno počáteční spojení se serverem.

Notifikace vypadá jako JSON zpráva:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikace patří do tématu v MCP označovaného jako ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pro aktivaci logování musí server tuto funkci/příležitost povolit takto:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> V závislosti na použitém SDK může být logování povoleno ve výchozím nastavení, nebo je třeba ho explicitně zapnout v konfiguraci serveru.

Existují různé typy notifikací:

| Úroveň    | Popis                         | Příklad použití              |
|-----------|-------------------------------|-----------------------------|
| debug     | Detailní ladicí informace      | Vstupy/výstupy funkcí        |
| info      | Obecné informační zprávy      | Aktualizace průběhu operace  |
| notice    | Normální, ale významné události| Změny konfigurace            |
| warning   | Varovné stavy                 | Používání zastaralých funkcí |
| error     | Chybové stavy                | Selhání operace              |
| critical  | Kritické stavy               | Selhání systémových komponent|
| alert     | Nutná okamžitá akce          | Detekce poškození dat        |
| emergency | Systém je nepoužitelný       | Kompletní selhání systému    |

## Implementace notifikací v MCP

Pro implementaci notifikací v MCP je potřeba nastavit jak serverovou, tak klientskou stranu pro zpracování real-time aktualizací. To umožní vaší aplikaci poskytovat uživatelům okamžitou zpětnou vazbu během dlouhotrvajících operací.

### Serverová strana: Odesílání notifikací

Začněme serverovou stranou. V MCP definujete nástroje, které mohou odesílat notifikace během zpracování požadavků. Server používá kontextový objekt (obvykle `ctx`) k odesílání zpráv klientovi.

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

V předchozím příkladu metoda `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transportu:

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

V tomto .NET příkladu se používá metoda `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` k odesílání informačních zpráv.

Pro povolení notifikací ve vašem .NET MCP serveru se ujistěte, že používáte streamovací transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klientská strana: Příjem notifikací

Klient musí implementovat handler zpráv, který zpracovává a zobrazuje notifikace, jakmile přicházejí.

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

V předchozím kódu je `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` použit k obsluze příchozích notifikací.

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

V tomto .NET příkladu je `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) a klient implementuje handler zpráv k zpracování notifikací.

## Notifikace o průběhu a scénáře

Tato sekce vysvětluje koncept notifikací o průběhu v MCP, proč jsou důležité a jak je implementovat pomocí Streamable HTTP. Najdete zde také praktické zadání pro upevnění znalostí.

Notifikace o průběhu jsou real-time zprávy odesílané ze serveru klientovi během dlouhotrvajících operací. Místo čekání na dokončení celého procesu server průběžně informuje klienta o aktuálním stavu. To zlepšuje transparentnost, uživatelský zážitek a usnadňuje ladění.

**Příklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Proč používat notifikace o průběhu?

Notifikace o průběhu jsou důležité z několika důvodů:

- **Lepší uživatelský zážitek:** Uživatelé vidí aktualizace průběhu práce, ne jen na konci.
- **Real-time zpětná vazba:** Klienti mohou zobrazovat průběhové lišty nebo logy, díky čemuž aplikace působí responzivně.
- **Snazší ladění a monitoring:** Vývojáři a uživatelé vidí, kde může být proces pomalý nebo zablokovaný.

### Jak implementovat notifikace o průběhu

Zde je postup, jak implementovat notifikace o průběhu v MCP:

- **Na serveru:** Použijte `ctx.info()` or `ctx.log()` k odeslání notifikací při zpracování jednotlivých položek. Tím posíláte zprávu klientovi ještě předtím, než je hlavní výsledek hotov.
- **Na klientovi:** Implementujte handler zpráv, který naslouchá a zobrazuje notifikace, jak přicházejí. Tento handler rozlišuje mezi notifikacemi a finálním výsledkem.

**Příklad serveru:**

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

**Příklad klienta:**

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

## Bezpečnostní aspekty

Při implementaci MCP serverů s HTTP-based transporty je bezpečnost klíčovou oblastí, která vyžaduje pečlivé zvážení různých útoků a ochranných mechanismů.

### Přehled

Bezpečnost je zásadní při zpřístupňování MCP serverů přes HTTP. Streamable HTTP přináší nové možnosti útoků a vyžaduje důkladnou konfiguraci.

### Klíčové body
- **Validace Origin hlavičky**: Vždy ověřujte `Origin` hlavičku, aby byla z důvěryhodného zdroje.
- **Použití HTTPS**: Vždy používejte HTTPS pro šifrování komunikace.
- **Autentizace a autorizace**: Zajistěte, aby přístup k serveru měli pouze oprávnění uživatelé.
- **Ochrana proti CSRF**: Implementujte opatření proti cross-site request forgery.
- **Monitorování a logování**: Sledujte podezřelé aktivity a logujte je pro audit.

### Udržování kompatibility

Doporučuje se zachovat kompatibilitu s existujícími SSE klienty během migrace. Některé strategie:

- Podporovat oba transporty (SSE i Streamable HTTP) na různých koncových bodech.
- Postupně migrovat klienty na nový transport.

### Výzvy

Při migraci je třeba řešit:

- Aktualizaci všech klientů.
- Rozdíly v doručování notifikací.

### Zadání: Vytvořte vlastní streamovací MCP aplikaci

**Scénář:**
Vytvořte MCP server a klienta, kde server zpracovává seznam položek (např. souborů nebo dokumentů) a pro každou zpracovanou položku odesílá notifikaci. Klient by měl zobrazovat každou notifikaci, jakmile přijde.

**Kroky:**

1. Implementujte serverový nástroj, který zpracuje seznam a odesílá notifikace pro každou položku.
2. Implementujte klienta s handlerem zpráv, který zobrazuje notifikace v reálném čase.
3. Otestujte implementaci spuštěním serveru i klienta a sledujte přicházející notifikace.

[Řešení](./solution/README.md)

## Další čtení a co dál?

Pokračujte ve své cestě s MCP streamováním a rozšiřujte své znalosti pomocí následujících zdrojů a doporučených kroků pro tvorbu pokročilejších aplikací.

### Další čtení

- [Microsoft: Úvod do HTTP streamování](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streamování požadavků](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Co dál?

- Zkuste vytvořit pokročilejší MCP nástroje využívající streamování pro real-time analytiku, chat nebo kolaborativní editaci.
- Prozkoumejte integraci MCP streamování s frontendovými frameworky (React, Vue, apod.) pro živé aktualizace UI.
- Další: [Využití AI Toolkit pro VSCode](../07-aitk/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.