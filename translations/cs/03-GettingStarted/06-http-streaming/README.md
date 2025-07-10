<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:23:17+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "cs"
}
-->
# HTTPS streamování s Model Context Protocol (MCP)

Tato kapitola poskytuje komplexní návod na implementaci bezpečného, škálovatelného a real-time streamování pomocí Model Context Protocol (MCP) přes HTTPS. Pokrývá motivaci pro streamování, dostupné transportní mechanismy, jak implementovat streamovatelné HTTP v MCP, bezpečnostní doporučení, migraci ze SSE a praktické rady pro tvorbu vlastních streamovacích aplikací MCP.

## Transportní mechanismy a streamování v MCP

Tato sekce zkoumá různé dostupné transportní mechanismy v MCP a jejich roli při umožnění streamovacích schopností pro real-time komunikaci mezi klienty a servery.

### Co je transportní mechanismus?

Transportní mechanismus definuje, jak jsou data vyměňována mezi klientem a serverem. MCP podporuje více typů transportu, aby vyhověl různým prostředím a požadavkům:

- **stdio**: Standardní vstup/výstup, vhodné pro lokální a CLI nástroje. Jednoduché, ale nevhodné pro web nebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverům posílat klientům real-time aktualizace přes HTTP. Dobré pro webová uživatelská rozhraní, ale omezené v škálovatelnosti a flexibilitě.
- **Streamable HTTP**: Moderní HTTP založený streamovací transport, podporující notifikace a lepší škálovatelnost. Doporučeno pro většinu produkčních a cloudových scénářů.

### Porovnávací tabulka

Podívejte se na následující tabulku, která ukazuje rozdíly mezi těmito transportními mechanismy:

| Transport         | Real-time aktualizace | Streamování | Škálovatelnost | Použití                  |
|-------------------|----------------------|-------------|----------------|--------------------------|
| stdio             | Ne                   | Ne          | Nízká          | Lokální CLI nástroje     |
| SSE               | Ano                  | Ano         | Střední        | Web, real-time aktualizace|
| Streamable HTTP   | Ano                  | Ano         | Vysoká         | Cloud, multi-klient      |

> **Tip:** Výběr správného transportu ovlivňuje výkon, škálovatelnost a uživatelský zážitek. **Streamable HTTP** je doporučeno pro moderní, škálovatelné a cloudové aplikace.

Všimněte si transportů stdio a SSE, které jste viděli v předchozích kapitolách, a jak streamable HTTP je transport, který je pokryt v této kapitole.

## Streamování: Koncepty a motivace

Pochopení základních konceptů a motivací za streamováním je klíčové pro efektivní implementaci real-time komunikačních systémů.

**Streamování** je technika v síťovém programování, která umožňuje odesílat a přijímat data v malých, zvládnutelných částech nebo jako sekvenci událostí, místo čekání na kompletní odpověď. To je zvláště užitečné pro:

- Velké soubory nebo datové sady.
- Real-time aktualizace (např. chat, progress bary).
- Dlouhotrvající výpočty, kdy chcete uživatele průběžně informovat.

Zde je, co byste měli o streamování vědět na vysoké úrovni:

- Data jsou doručována postupně, ne najednou.
- Klient může data zpracovávat, jak přicházejí.
- Snižuje vnímanou latenci a zlepšuje uživatelský zážitek.

### Proč používat streamování?

Důvody pro použití streamování jsou následující:

- Uživatelé dostávají zpětnou vazbu okamžitě, ne až na konci.
- Umožňuje real-time aplikace a responzivní UI.
- Efektivnější využití síťových a výpočetních zdrojů.

### Jednoduchý příklad: HTTP streamovací server a klient

Zde je jednoduchý příklad, jak lze streamování implementovat:

<details>
<summary>Python</summary>

**Server (Python, používající FastAPI a StreamingResponse):**
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

**Klient (Python, používající requests):**
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

Tento příklad ukazuje server, který posílá sérii zpráv klientovi, jakmile jsou k dispozici, místo čekání na všechny zprávy najednou.

**Jak to funguje:**
- Server postupně odesílá každou zprávu, jakmile je připravená.
- Klient přijímá a vypisuje každou část, jak přichází.

**Požadavky:**
- Server musí používat streamovací odpověď (např. `StreamingResponse` ve FastAPI).
- Klient musí zpracovávat odpověď jako stream (`stream=True` v requests).
- Content-Type je obvykle `text/event-stream` nebo `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, používající Spring Boot a Server-Sent Events):**

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

**Klient (Java, používající Spring WebFlux WebClient):**

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
- Používá reaktivní stack Spring Boot s `Flux` pro streamování
- `ServerSentEvent` poskytuje strukturované streamování událostí s typy událostí
- `WebClient` s `bodyToFlux()` umožňuje reaktivní příjem streamu
- `delayElements()` simuluje čas zpracování mezi událostmi
- Události mohou mít typy (`info`, `result`) pro lepší zpracování na klientovi

</details>

### Porovnání: Klasické streamování vs MCP streamování

Rozdíly mezi klasickým streamováním a streamováním v MCP lze znázornit takto:

| Vlastnost              | Klasické HTTP streamování      | MCP streamování (notifikace)       |
|------------------------|-------------------------------|-----------------------------------|
| Hlavní odpověď         | Chunkovaná                    | Jedna, na konci                   |
| Aktualizace průběhu    | Posílány jako datové chunky   | Posílány jako notifikace          |
| Požadavky na klienta   | Musí zpracovat stream         | Musí implementovat message handler|
| Použití                | Velké soubory, AI token stream| Průběh, logy, real-time zpětná vazba|

### Klíčové rozdíly

Dále zde jsou některé klíčové rozdíly:

- **Komunikační vzor:**
   - Klasické HTTP streamování: Používá jednoduché chunkované přenosové kódování pro odesílání dat po částech
   - MCP streamování: Používá strukturovaný notifikační systém s JSON-RPC protokolem

- **Formát zpráv:**
   - Klasické HTTP: Prostý text s chunky oddělenými novými řádky
   - MCP: Strukturované objekty LoggingMessageNotification s metadaty

- **Implementace klienta:**
   - Klasické HTTP: Jednoduchý klient zpracovávající streamovací odpovědi
   - MCP: Sofistikovanější klient s message handlerem pro zpracování různých typů zpráv

- **Aktualizace průběhu:**
   - Klasické HTTP: Průběh je součástí hlavního streamu odpovědi
   - MCP: Průběh je posílán jako samostatné notifikační zprávy, zatímco hlavní odpověď přijde na konci

### Doporučení

Některé doporučení při výběru mezi klasickým streamováním (jako endpoint `/stream`, který jsme ukázali výše) a streamováním přes MCP:

- **Pro jednoduché potřeby streamování:** Klasické HTTP streamování je jednodušší na implementaci a dostačující pro základní scénáře.

- **Pro složité, interaktivní aplikace:** MCP streamování nabízí strukturovanější přístup s bohatšími metadaty a oddělením notifikací od finálních výsledků.

- **Pro AI aplikace:** Notifikační systém MCP je zvlášť užitečný pro dlouhotrvající AI úlohy, kde chcete uživatele průběžně informovat o stavu.

## Streamování v MCP

Takže jste viděli některá doporučení a porovnání rozdílů mezi klasickým streamováním a streamováním v MCP. Pojďme se podrobněji podívat, jak můžete streamování v MCP využít.

Pochopení, jak streamování funguje v rámci MCP, je klíčové pro tvorbu responzivních aplikací, které poskytují uživatelům real-time zpětnou vazbu během dlouhotrvajících operací.

V MCP streamování neznamená odesílání hlavní odpovědi po částech, ale odesílání **notifikací** klientovi během zpracování požadavku. Tyto notifikace mohou obsahovat aktualizace průběhu, logy nebo jiné události.

### Jak to funguje

Hlavní výsledek je stále odeslán jako jedna odpověď. Nicméně notifikace mohou být odesílány jako samostatné zprávy během zpracování a tím aktualizovat klienta v reálném čase. Klient musí být schopen tyto notifikace zpracovat a zobrazit.

## Co je notifikace?

Řekli jsme „notifikace“, co to znamená v kontextu MCP?

Notifikace je zpráva odeslaná ze serveru klientovi, která informuje o průběhu, stavu nebo jiných událostech během dlouhotrvající operace. Notifikace zlepšují transparentnost a uživatelský zážitek.

Například klient by měl poslat notifikaci, jakmile je navázáno počáteční spojení se serverem.

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

Notifikace patří do tématu v MCP nazývaného ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Aby logging fungoval, server musí tuto funkci/povolení aktivovat takto:

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
| debug      | Detailní ladicí informace      | Vstupy/výstupy funkcí        |
| info       | Obecné informační zprávy      | Aktualizace průběhu operace  |
| notice     | Normální, ale významné události| Změny konfigurace            |
| warning    | Varovné stavy                 | Použití zastaralých funkcí   |
| error      | Chybové stavy                 | Selhání operace              |
| critical   | Kritické stavy                | Selhání systémových komponent|
| alert      | Nutná okamžitá akce           | Detekce poškození dat        |
| emergency  | Systém nepoužitelný           | Kompletní selhání systému    |

## Implementace notifikací v MCP

Pro implementaci notifikací v MCP je potřeba nastavit jak serverovou, tak klientskou stranu pro zpracování real-time aktualizací. To umožní vaší aplikaci poskytovat okamžitou zpětnou vazbu uživatelům během dlouhotrvajících operací.

### Serverová strana: Odesílání notifikací

Začněme serverovou stranou. V MCP definujete nástroje, které mohou během zpracování požadavků odesílat notifikace. Server používá kontextový objekt (obvykle `ctx`) k odesílání zpráv klientovi.

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

V předchozím příkladu nástroj `process_files` odesílá klientovi tři notifikace během zpracování každého souboru. Metoda `ctx.info()` slouží k odesílání informačních zpráv.

</details>

Dále, aby notifikace fungovaly, ujistěte se, že server používá streamovací transport (např. `streamable-http`) a klient implementuje message handler pro zpracování notifikací. Zde je, jak nastavit server pro použití transportu `streamable-http`:

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

V tomto .NET příkladu je nástroj `ProcessFiles` označen atributem `Tool` a odesílá tři notifikace klientovi během zpracování každého souboru. Metoda `ctx.Info()` slouží k odesílání informačních zpráv.

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

Klient musí implementovat message handler, který zpracovává a zobrazuje notifikace, jakmile přicházejí.

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

V předchozím kódu funkce `message_handler` kontroluje, zda je příchozí zpráva notifikací. Pokud ano, vypíše ji; jinak ji zpracuje jako běžnou serverovou zprávu. Také si všimněte, jak je `ClientSession` inicializována s `message_handler` pro zpracování příchozích notifikací.

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

V tomto .NET příkladu funkce `MessageHandler` kontroluje, zda je příchozí zpráva notifikací. Pokud ano, vypíše ji; jinak ji zpracuje jako běžnou serverovou zprávu. `ClientSession` je inicializována s message handlerem přes `ClientSessionOptions`.

</details>

Pro povolení notifikací se ujistěte, že server používá streamovací transport (např. `streamable-http`) a klient implementuje message handler pro zpracování notifikací.

## Notifikace průběhu a scénáře

Tato sekce vysvětluje koncept notifikací průběhu v MCP, proč jsou důležité a jak je implementovat pomocí Streamable HTTP. Najdete zde také praktické zadání pro upevnění znalostí.

Notifikace průběhu jsou real-time zprávy odesílané ze serveru klientovi během dlouhotrvajících operací. Místo čekání na dokončení celého procesu server průběžně informuje klienta o aktuálním stavu. To zlepšuje transparentnost, uživatelský zážitek a usnadňuje ladění.

**Příklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Proč používat notifikace průběhu?

Notifikace průběhu jsou důležité z několika důvodů:

- **Lepší uživatelský zážitek:** Uživatelé vidí aktualizace během práce, ne jen na konci.
- **Real-time zpětná vazba:** Klienti mohou zobrazovat progress bary nebo logy, což dělá aplikaci responzivní.
- **Snazší ladění a monitoring:** Vývojáři i uživatelé vidí, kde může být proces pomalý nebo zablokovaný.

### Jak implementovat notifikace průběhu

Zde je, jak můžete implementovat notifikace průběhu v MCP:

- **Na serveru:** Použijte `ctx.info()` nebo `ctx.log()` k odesílání notifikací při zpracování každé položky. Tím se klientovi pošle zpráva ještě před tím, než je hlavní výsledek připraven.
- **Na klientovi:** Implementujte message handler, který poslouchá a zobrazuje notifikace, jakmile přicházejí. Tento handler rozlišuje mezi notifikacemi a finálním výsledkem.

**Serverový příklad:**

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

Při implementaci MCP serverů s HTTP přenosem je bezpečnost zásadní otázkou, která vyžaduje pečlivou pozornost vůči různým útokům a ochranným mechanismům.

### Přehled

Bezpečnost je klíčová při zpřístupňování MCP serverů přes HTTP. Streamable HTTP přináší nové možnosti útoků a vyžaduje pečlivé nastavení.

### Hlavní body
- **Validace hlavičky Origin**: Vždy ověřujte hlavičku `Origin`, abyste zabránili DNS rebinding útokům.
- **Vazba na localhost**: Pro lokální vývoj svazujte servery na `localhost`, aby nebyly přístupné z veřejného internetu.
- **Autentizace**: Pro produkční nasazení implementujte autentizaci (např. API klíče, OAuth).
- **CORS**: Nastavte politiky Cross-Origin Resource Sharing (CORS) pro omezení přístupu.
- **HTTPS**: V produkci používejte HTTPS pro šifrování komunikace.

### Doporučené postupy
- Nikdy nevěřte příchozím požadavkům bez ověření.
- Logujte a monitorujte veškerý přístup a chyby.
- Pravidelně aktualizujte závislosti kvůli opravám bezpečnostních chyb.

### Výzvy
- Najít rovnováhu mezi bezpečností a jednoduchostí vývoje
- Zajistit kompatibilitu s různými klientskými prostředími


## Přechod ze SSE na Streamable HTTP

Pro aplikace, které aktuálně používají Server-Sent Events (SSE), přechod na Streamable HTTP přináší lepší možnosti a dlouhodobější udržitelnost MCP implementací.

### Proč přecházet?

Existují dva hlavní důvody, proč přejít ze SSE na Streamable HTTP:

- Streamable HTTP nabízí lepší škálovatelnost, kompatibilitu a bohatší podporu notifikací než SSE.
- Je doporučeným přenosem pro nové MCP aplikace.

### Kroky migrace

Jak migrovat ze SSE na Streamable HTTP ve vašich MCP aplikacích:

- **Aktualizujte serverový kód** tak, aby používal `transport="streamable-http"` v `mcp.run()`.
- **Aktualizujte klientský kód** tak, aby používal `streamablehttp_client` místo SSE klienta.
- **Implementujte zpracování zpráv** v klientovi pro příjem notifikací.
- **Otestujte kompatibilitu** s existujícími nástroji a workflow.

### Zachování kompatibility

Během migrace je vhodné zachovat kompatibilitu se stávajícími SSE klienty. Některé strategie:

- Podporujte oba přenosy (SSE i Streamable HTTP) na různých koncových bodech.
- Postupně přecházejte klienty na nový přenos.

### Výzvy

Při migraci je potřeba řešit:

- Zajištění, že všichni klienti budou aktualizováni
- Řešení rozdílů v doručování notifikací

## Bezpečnostní aspekty

Bezpečnost by měla být prioritou při implementaci jakéhokoliv serveru, zvláště při použití HTTP přenosů jako Streamable HTTP v MCP.

Při implementaci MCP serverů s HTTP přenosem je bezpečnost zásadní otázkou, která vyžaduje pečlivou pozornost vůči různým útokům a ochranným mechanismům.

### Přehled

Bezpečnost je klíčová při zpřístupňování MCP serverů přes HTTP. Streamable HTTP přináší nové možnosti útoků a vyžaduje pečlivé nastavení.

Zde jsou některé klíčové bezpečnostní aspekty:

- **Validace hlavičky Origin**: Vždy ověřujte hlavičku `Origin`, abyste zabránili DNS rebinding útokům.
- **Vazba na localhost**: Pro lokální vývoj svazujte servery na `localhost`, aby nebyly přístupné z veřejného internetu.
- **Autentizace**: Pro produkční nasazení implementujte autentizaci (např. API klíče, OAuth).
- **CORS**: Nastavte politiky Cross-Origin Resource Sharing (CORS) pro omezení přístupu.
- **HTTPS**: V produkci používejte HTTPS pro šifrování komunikace.

### Doporučené postupy

Dále zde jsou některé doporučené postupy pro zabezpečení vašeho MCP streaming serveru:

- Nikdy nevěřte příchozím požadavkům bez ověření.
- Logujte a monitorujte veškerý přístup a chyby.
- Pravidelně aktualizujte závislosti kvůli opravám bezpečnostních chyb.

### Výzvy

Při zabezpečení MCP streaming serverů narazíte na tyto výzvy:

- Najít rovnováhu mezi bezpečností a jednoduchostí vývoje
- Zajistit kompatibilitu s různými klientskými prostředími

### Zadání: Vytvořte vlastní streamingovou MCP aplikaci

**Scénář:**
Vytvořte MCP server a klienta, kde server zpracovává seznam položek (např. soubory nebo dokumenty) a pro každou zpracovanou položku odesílá notifikaci. Klient by měl zobrazovat každou notifikaci ihned po jejím přijetí.

**Kroky:**

1. Implementujte serverový nástroj, který zpracuje seznam a odešle notifikace pro každou položku.
2. Implementujte klienta se zpracovatelem zpráv, který bude notifikace zobrazovat v reálném čase.
3. Otestujte implementaci spuštěním serveru i klienta a sledujte notifikace.

[Řešení](./solution/README.md)

## Další čtení a co dál?

Pokračujte ve svém poznávání MCP streamingu a rozšiřujte své znalosti pomocí následujících zdrojů a doporučených kroků pro tvorbu pokročilejších aplikací.

### Další čtení

- [Microsoft: Úvod do HTTP streamingu](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Co dál?

- Vyzkoušejte tvorbu pokročilejších MCP nástrojů využívajících streaming pro analýzy v reálném čase, chat nebo kolaborativní editaci.
- Prozkoumejte integraci MCP streamingu s frontendovými frameworky (React, Vue apod.) pro živé aktualizace uživatelského rozhraní.
- Další krok: [Využití AI Toolkit pro VSCode](../07-aitk/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.