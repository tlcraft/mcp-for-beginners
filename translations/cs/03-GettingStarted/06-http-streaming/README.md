<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T19:16:40+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "cs"
}
-->
# HTTPS Streaming s protokolem Model Context Protocol (MCP)

Tato kapitola poskytuje komplexní návod k implementaci bezpečného, škálovatelného a real-time streamování pomocí protokolu Model Context Protocol (MCP) přes HTTPS. Pokrývá motivaci pro streamování, dostupné transportní mechanismy, jak implementovat streamovatelné HTTP v MCP, bezpečnostní osvědčené postupy, migraci ze SSE a praktické rady pro vytváření vlastních aplikací MCP pro streamování.

## Transportní mechanismy a streamování v MCP

Tato sekce zkoumá různé transportní mechanismy dostupné v MCP a jejich roli při umožnění streamovacích schopností pro real-time komunikaci mezi klienty a servery.

### Co je transportní mechanismus?

Transportní mechanismus definuje, jak jsou data vyměňována mezi klientem a serverem. MCP podporuje více typů transportu, aby vyhověl různým prostředím a požadavkům:

- **stdio**: Standardní vstup/výstup, vhodné pro lokální a CLI nástroje. Jednoduché, ale nevhodné pro web nebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverům posílat klientům real-time aktualizace přes HTTP. Dobré pro webová uživatelská rozhraní, ale omezené v škálovatelnosti a flexibilitě.
- **Streamable HTTP**: Moderní HTTP-based streamovací transport, podporující notifikace a lepší škálovatelnost. Doporučeno pro většinu produkčních a cloudových scénářů.

### Porovnávací tabulka

Podívejte se na následující porovnávací tabulku, abyste pochopili rozdíly mezi těmito transportními mechanismy:

| Transport         | Real-time aktualizace | Streamování | Škálovatelnost | Použití                  |
|-------------------|-----------------------|-------------|----------------|--------------------------|
| stdio             | Ne                   | Ne          | Nízká          | Lokální CLI nástroje     |
| SSE               | Ano                  | Ano         | Střední        | Web, real-time aktualizace |
| Streamovatelné HTTP | Ano                 | Ano         | Vysoká         | Cloud, multi-klient      |

> **Tip:** Výběr správného transportu ovlivňuje výkon, škálovatelnost a uživatelskou zkušenost. **Streamovatelné HTTP** je doporučeno pro moderní, škálovatelné a cloudové aplikace.

Všimněte si transportů stdio a SSE, které jste viděli v předchozích kapitolách, a jak streamovatelné HTTP je transport, který je pokryt v této kapitole.

## Streamování: Koncepty a motivace

Porozumění základním konceptům a motivacím za streamováním je klíčové pro implementaci efektivních systémů real-time komunikace.

**Streamování** je technika v síťovém programování, která umožňuje posílání a přijímání dat v malých, zvládnutelných částech nebo jako sekvenci událostí, místo čekání na kompletní odpověď. To je obzvláště užitečné pro:

- Velké soubory nebo datové sady.
- Real-time aktualizace (např. chat, ukazatele průběhu).
- Dlouhotrvající výpočty, kde chcete uživatele průběžně informovat.

Zde je, co byste měli o streamování vědět na vysoké úrovni:

- Data jsou doručována postupně, ne najednou.
- Klient může zpracovávat data, jakmile dorazí.
- Snižuje vnímanou latenci a zlepšuje uživatelskou zkušenost.

### Proč používat streamování?

Důvody pro použití streamování jsou následující:

- Uživatelé dostávají zpětnou vazbu okamžitě, ne až na konci.
- Umožňuje real-time aplikace a responzivní UI.
- Efektivnější využití síťových a výpočetních zdrojů.

### Jednoduchý příklad: HTTP streamovací server a klient

Zde je jednoduchý příklad, jak může být streamování implementováno:

#### Python

**Server (Python, pomocí FastAPI a StreamingResponse):**

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

**Klient (Python, pomocí requests):**

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

Tento příklad demonstruje server, který posílá sérii zpráv klientovi, jakmile jsou dostupné, místo čekání na všechny zprávy.

**Jak to funguje:**

- Server postupně posílá každou zprávu, jakmile je připravena.
- Klient přijímá a tiskne každou část, jakmile dorazí.

**Požadavky:**

- Server musí používat streamovací odpověď (např. `StreamingResponse` ve FastAPI).
- Klient musí zpracovávat odpověď jako stream (`stream=True` v requests).
- Content-Type je obvykle `text/event-stream` nebo `application/octet-stream`.

#### Java

**Server (Java, pomocí Spring Boot a Server-Sent Events):**

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

**Klient (Java, pomocí Spring WebFlux WebClient):**

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

- Používá reaktivní stack Spring Boot s `Flux` pro streamování.
- `ServerSentEvent` poskytuje strukturované streamování událostí s typy událostí.
- `WebClient` s `bodyToFlux()` umožňuje reaktivní konzumaci streamu.
- `delayElements()` simuluje čas zpracování mezi událostmi.
- Události mohou mít typy (`info`, `result`) pro lepší zpracování na straně klienta.

### Porovnání: Klasické streamování vs MCP streamování

Rozdíly mezi klasickým způsobem streamování a tím, jak funguje streamování v MCP, lze znázornit takto:

| Vlastnost              | Klasické HTTP streamování      | MCP streamování (notifikace)       |
|------------------------|-------------------------------|-----------------------------------|
| Hlavní odpověď         | Chunked (po částech)           | Jedna, na konci                   |
| Aktualizace průběhu    | Posílány jako datové chunky    | Posílány jako notifikace          |
| Požadavky na klienta   | Musí zpracovávat stream        | Musí implementovat message handler|
| Použití                | Velké soubory, AI token stream | Průběh, logy, real-time zpětná vazba|

### Klíčové rozdíly

Navíc zde jsou některé klíčové rozdíly:

- **Komunikační vzor:**
  - Klasické HTTP streamování: Používá jednoduché chunked transfer encoding pro posílání dat po částech.
  - MCP streamování: Používá strukturovaný systém notifikací s JSON-RPC protokolem.

- **Formát zpráv:**
  - Klasické HTTP: Prosté textové části s novými řádky.
  - MCP: Strukturované objekty LoggingMessageNotification s metadaty.

- **Implementace klienta:**
   - Klasické HTTP: Jednoduchý klient zpracovávající streamované odpovědi
   - MCP: Sofistikovanější klient s message handlerem pro zpracování různých typů zpráv

- **Aktualizace průběhu:**
  - Klasické HTTP: Průběh je součástí hlavního streamu odpovědi.
  - MCP: Průběh je posílán prostřednictvím samostatných notifikačních zpráv, zatímco hlavní odpověď přichází na konci.

### Doporučení

Existují některá doporučení při výběru mezi implementací klasického streamování (jako endpoint `/stream`, který jsme ukázali výše) a streamování přes MCP.

- **Pro jednoduché potřeby streamování:** Klasické HTTP streamování je jednodušší na implementaci a dostatečné pro základní potřeby streamování.

- **Pro komplexní, interaktivní aplikace:** MCP streamování poskytuje strukturovanější přístup s bohatšími metadaty a oddělením mezi notifikacemi a finálními výsledky.

- **Pro AI aplikace:** Notifikační systém MCP je obzvláště užitečný pro dlouhotrvající AI úlohy, kde chcete uživatele průběžně informovat o průběhu.

## Streamování v MCP

Dobře, viděli jste některá doporučení a porovnání rozdílů mezi klasickým streamováním a streamováním v MCP. Pojďme se podrobně podívat na to, jak můžete využít streamování v MCP.

Porozumění tomu, jak streamování funguje v rámci MCP frameworku, je klíčové pro vytváření responzivních aplikací, které poskytují real-time zpětnou vazbu uživatelům během dlouhotrvajících operací.

V MCP není streamování o posílání hlavní odpovědi po částech, ale o posílání **notifikací** klientovi během zpracování požadavku. Tyto notifikace mohou zahrnovat aktualizace průběhu, logy nebo jiné události.

### Jak to funguje

Hlavní výsledek je stále poslán jako jedna odpověď. Nicméně notifikace mohou být posílány jako samostatné zprávy během zpracování a tím aktualizovat klienta v reálném čase. Klient musí být schopen tyto notifikace zpracovat a zobrazit.

## Co je notifikace?

Řekli jsme "notifikace", co to znamená v kontextu MCP?

Notifikace je zpráva poslaná ze serveru klientovi, která informuje o průběhu, stavu nebo jiných událostech během dlouhotrvající operace. Notifikace zlepšují transparentnost a uživatelskou zkušenost.

Například klient by měl poslat notifikaci, jakmile je provedeno počáteční handshake se serverem.

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

Aby logging fungoval, server musí povolit tuto funkci/schopnost takto:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> V závislosti na použitém SDK může být logging ve výchozím nastavení povolen, nebo ho budete muset explicitně zapnout v konfiguraci serveru.

Existují různé typy notifikací:

| Úroveň     | Popis                          | Příklad použití               |
|------------|-------------------------------|------------------------------|
| debug      | Detailní ladicí informace      | Vstupy/výstupy funkcí         |
| info       | Obecné informační zprávy      | Aktualizace průběhu operace   |
| notice     | Normální, ale významné události| Změny konfigurace             |
| warning    | Varovné stavy                 | Použití zastaralých funkcí    |
| error      | Chybové stavy                | Selhání operace               |
| critical   | Kritické stavy               | Selhání systémových komponent |
| alert      | Nutná okamžitá akce          | Detekce poškození dat         |
| emergency  | Systém nepoužitelný          | Kompletní selhání systému     |

## Implementace notifikací v MCP

Pro implementaci notifikací v MCP musíte nastavit jak serverovou, tak klientskou stranu, aby zvládaly real-time aktualizace. To umožní vaší aplikaci poskytovat okamžitou zpětnou vazbu uživatelům během dlouhotrvajících operací.

### Serverová strana: Posílání notifikací

Začněme serverovou stranou. V MCP definujete nástroje, které mohou posílat notifikace během zpracování požadavků. Server používá objekt kontextu (obvykle `ctx`) k posílání zpráv klientovi.

#### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

V předchozím příkladu nástroj `process_files` posílá tři notifikace klientovi během zpracování každého souboru. Metoda `ctx.info()` se používá k posílání informačních zpráv.

Dále, aby notifikace fungovaly, ujistěte se, že server používá streamovací transport (např. `streamable-http`) a klient implementuje message handler pro zpracování notifikací. Zde je, jak nastavit server pro použití transportu `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

#### .NET

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

V tomto příkladu .NET je nástroj `ProcessFiles` označen atributem `Tool` a posílá tři notifikace klientovi během zpracování každého souboru. Metoda `ctx.Info()` se používá k posílání informačních zpráv.

Pro povolení notifikací ve vašem .NET MCP serveru se ujistěte, že používáte streamovací transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Klientská strana: Přijímání notifikací

Klient musí implementovat message handler, který zpracovává a zobrazuje notifikace, jakmile přicházejí.

#### Python

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

V předchozím kódu funkce `message_handler` kontroluje, zda je příchozí zpráva notifikací. Pokud ano, vypíše ji; jinak ji zpracuje jako běžnou serverovou zprávu. Také si všimněte, jak je `ClientSession` inicializována s `message_handler` pro zpracování příchozích notifikací.

#### .NET

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

V tomto .NET příkladu funkce `MessageHandler` kontroluje, zda je příchozí zpráva notifikací. Pokud ano, vypíše ji; jinak ji zpracuje jako běžnou serverovou zprávu. `ClientSession` je inicializována s message handlerem přes `ClientSessionOptions`.

Pro povolení notifikací se ujistěte, že server používá streamovací transport (např. `streamable-http`) a klient implementuje message handler pro zpracování notifikací.

## Notifikace průběhu & scénáře

Tato sekce vysvětluje koncept notifikací průběhu v MCP, proč jsou důležité, a jak je implementovat pomocí Streamable HTTP. Najdete zde také praktické zadání pro posílení vašeho porozumění.

Notifikace průběhu jsou real-time zprávy posílané ze serveru klientovi během dlouhotrvajících operací. Místo čekání na dokončení celého procesu server průběžně informuje klienta o aktuálním stavu. To zlepšuje transparentnost, uživatelskou zkušenost a usnadňuje ladění.

**Příklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Proč používat notifikace průběhu?

Notifikace průběhu jsou důležité z několika důvodů:

- **Lepší uživatelská zkušenost:** Uživatelé vidí aktualizace během práce, ne až na konci.
- **Real-time zpětná vazba:** Klienti mohou zobrazovat ukazatele průběhu nebo logy, což aplikaci činí responzivní.
- **Snadnější ladění a monitorování:** Vývojáři a uživatelé vidí, kde může být proces pomalý nebo zaseknutý.

### Jak implementovat notifikace průběhu

Zde je, jak můžete implementovat notifikace průběhu v MCP:

- **Na serveru:** Použijte `ctx.info()` nebo `ctx.log()` k odesílání notifikací při zpracování každé položky. Tím se klientovi pošle zpráva ještě před tím, než je hlavní výsledek připraven.
- **Na klientovi:** Implementujte message handler, který poslouchá a zobrazuje notifikace, jakmile přicházejí. Tento handler rozlišuje mezi notifikacemi a finálním výsledkem.

**Příklad serveru:**

#### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

**Příklad klienta:**

#### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

## Bezpečnostní aspekty

Při implementaci MCP serverů s HTTP-based transporty je bezpečnost zásadní otázkou, která vyžaduje pečlivou pozornost vůči různým útokům a ochranným mechanismům.

### Přehled

Bezpečnost je klíčová při zpřístupňování MCP serverů přes HTTP. Streamable HTTP přináší nové možnosti útoků a vyžaduje pečlivou konfiguraci.

### Klíčové body
- **Validace hlavičky Origin**: Vždy ověřujte hlavičku `Origin`, aby se zabránilo DNS rebinding útokům.
- **Vazba na localhost**: Pro lokální vývoj bindujte servery na `localhost`, aby nebyly veřejně dostupné.
- **Autentizace**: Implementujte autentizaci (např. API klíče, OAuth) pro produkční nasazení.
- **CORS**: Konfigurujte Cross-Origin Resource Sharing (CORS) politiky pro omezení přístupu.
- **HTTPS**: Používejte HTTPS v produkci pro šifrování provozu.

### Doporučené postupy
- Nikdy nevěřte příchozím požadavkům bez validace.
- Logujte a monitorujte veškerý přístup a chyby.
- Pravidelně aktualizujte závislosti kvůli bezpečnostním záplatám.

### Výzvy
- Vyvážení bezpečnosti a jednoduchosti vývoje
- Zajištění kompatibility s různými klientskými prostředími

## Přechod ze SSE na Streamable HTTP

Pro aplikace, které aktuálně
### Proč upgradovat?

Existují dva přesvědčivé důvody, proč přejít ze SSE na Streamable HTTP:

- Streamable HTTP nabízí lepší škálovatelnost, kompatibilitu a bohatší podporu notifikací než SSE.
- Jedná se o doporučený transport pro nové MCP aplikace.

### Kroky migrace

Zde je postup, jak migrovat ze SSE na Streamable HTTP ve vašich MCP aplikacích:

- **Aktualizujte kód serveru**, aby používal `transport="streamable-http"` v `mcp.run()`.
- **Aktualizujte kód klienta**, aby používal `streamablehttp_client` místo SSE klienta.
- **Implementujte zpracovatel zpráv** na straně klienta pro zpracování notifikací.
- **Otestujte kompatibilitu** s existujícími nástroji a pracovními postupy.

### Udržování kompatibility

Během migračního procesu se doporučuje zachovat kompatibilitu s existujícími SSE klienty. Zde jsou některé strategie:

- Můžete podporovat jak SSE, tak Streamable HTTP spuštěním obou transportů na různých endpointech.
- Postupně migrujte klienty na nový transport.

### Výzvy

Během migrace se ujistěte, že řešíte následující výzvy:

- Zajištění aktualizace všech klientů
- Řešení rozdílů v doručování notifikací

## Bezpečnostní aspekty

Bezpečnost by měla být nejvyšší prioritou při implementaci jakéhokoliv serveru, zejména při použití transportů založených na HTTP, jako je Streamable HTTP v MCP.

Při implementaci MCP serverů s HTTP transporty je bezpečnost klíčová a vyžaduje pečlivou pozornost vůči různým útokům a ochranným mechanismům.

### Přehled

Bezpečnost je zásadní při zpřístupňování MCP serverů přes HTTP. Streamable HTTP přináší nové bezpečnostní rizika a vyžaduje pečlivé nastavení.

Zde jsou klíčové bezpečnostní aspekty:

- **Validace hlavičky Origin**: Vždy validujte hlavičku `Origin`, abyste předešli útokům typu DNS rebinding.
- **Vazba na localhost**: Pro lokální vývoj připojte servery na `localhost`, abyste je neodhalili veřejnému internetu.
- **Autentizace**: Implementujte autentizaci (např. API klíče, OAuth) pro produkční nasazení.
- **CORS**: Nakonfigurujte zásady Cross-Origin Resource Sharing (CORS) pro omezení přístupu.
- **HTTPS**: Používejte HTTPS v produkci pro šifrování provozu.

### Osvědčené postupy

Dále zde jsou některé osvědčené postupy při implementaci bezpečnosti ve vašem MCP streaming serveru:

- Nikdy nedůvěřujte příchozím požadavkům bez validace.
- Logujte a monitorujte veškerý přístup a chyby.
- Pravidelně aktualizujte závislosti, abyste opravili bezpečnostní zranitelnosti.

### Výzvy

Při implementaci bezpečnosti v MCP streaming serverech se můžete setkat s následujícími výzvami:

- Vyvážení bezpečnosti a snadnosti vývoje
- Zajištění kompatibility s různými klientskými prostředími

### Úkol: Vytvořte vlastní streamingovou MCP aplikaci

**Scénář:**
Vytvořte MCP server a klienta, kde server zpracovává seznam položek (např. souborů nebo dokumentů) a odesílá notifikaci pro každou zpracovanou položku. Klient by měl zobrazovat každou notifikaci, jakmile dorazí.

**Kroky:**

1. Implementujte serverový nástroj, který zpracuje seznam a odešle notifikace pro každou položku.
2. Implementujte klienta se zpracovatelem zpráv, který bude notifikace zobrazovat v reálném čase.
3. Otestujte implementaci spuštěním serveru i klienta a sledujte notifikace.

[Řešení](./solution/README.md)

## Další čtení a co dál?

Pro pokračování ve vašem studiu MCP streamingu a rozšíření znalostí tato sekce poskytuje další zdroje a navrhované kroky pro budování pokročilejších aplikací.

### Další čtení

- [Microsoft: Úvod do HTTP streamingu](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Co dál?

- Zkuste vytvořit pokročilejší MCP nástroje, které využívají streaming pro analýzu v reálném čase, chat nebo kolaborativní editaci.
- Prozkoumejte integraci MCP streamingu s frontendovými frameworky (React, Vue, atd.) pro živé aktualizace uživatelského rozhraní.
- Další: [Využití AI Toolkit pro VSCode](../07-aitk/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.