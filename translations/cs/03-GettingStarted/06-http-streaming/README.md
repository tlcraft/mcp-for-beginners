<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:25:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "cs"
}
-->
# HTTPS streamování s Model Context Protocol (MCP)

Tato kapitola poskytuje podrobný návod na implementaci zabezpečeného, škálovatelného a real-time streamování pomocí Model Context Protocol (MCP) přes HTTPS. Pokrývá motivaci pro streamování, dostupné přenosové mechanismy, jak implementovat streamovatelné HTTP v MCP, bezpečnostní doporučení, migraci ze SSE a praktické rady pro tvorbu vlastních streamovacích MCP aplikací.

## Přenosové mechanismy a streamování v MCP

Tato sekce se zabývá různými přenosovými mechanismy dostupnými v MCP a jejich rolí při umožnění streamovacích funkcí pro real-time komunikaci mezi klienty a servery.

### Co je přenosový mechanismus?

Přenosový mechanismus určuje, jakým způsobem jsou data vyměňována mezi klientem a serverem. MCP podporuje několik typů přenosu, aby vyhověl různým prostředím a požadavkům:

- **stdio**: Standardní vstup/výstup, vhodný pro lokální a CLI nástroje. Jednoduché, ale nevhodné pro web nebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverům posílat klientům real-time aktualizace přes HTTP. Dobré pro webová uživatelská rozhraní, ale omezené v škálovatelnosti a flexibilitě.
- **Streamable HTTP**: Moderní HTTP streamovací přenos, podporující notifikace a lepší škálovatelnost. Doporučený pro většinu produkčních a cloudových scénářů.

### Srovnávací tabulka

Podívejte se na následující tabulku, která ukazuje rozdíly mezi těmito přenosovými mechanismy:

| Přenos            | Real-time aktualizace | Streamování | Škálovatelnost | Použití                  |
|-------------------|----------------------|-------------|----------------|--------------------------|
| stdio             | Ne                   | Ne          | Nízká          | Lokální CLI nástroje     |
| SSE               | Ano                  | Ano         | Střední        | Web, real-time aktualizace|
| Streamable HTTP   | Ano                  | Ano         | Vysoká         | Cloud, více klientů      |

> **Tip:** Volba správného přenosu ovlivňuje výkon, škálovatelnost a uživatelský zážitek. **Streamable HTTP** je doporučen pro moderní, škálovatelné a cloudové aplikace.

Všimněte si přenosů stdio a SSE, které byly představeny v předchozích kapitolách, a že v této kapitole se věnujeme přenosu streamable HTTP.

## Streamování: Koncepty a motivace

Pochopení základních konceptů a motivace za streamováním je klíčové pro efektivní implementaci real-time komunikačních systémů.

**Streamování** je technika v síťovém programování, která umožňuje odesílat a přijímat data po malých, snadno zpracovatelných částech nebo jako posloupnost událostí, místo čekání na kompletní odpověď. To je zvláště užitečné pro:

- Velké soubory nebo datové sady.
- Real-time aktualizace (např. chat, indikátory průběhu).
- Dlouhotrvající výpočty, kdy chcete uživatele průběžně informovat.

Základní fakta o streamování:

- Data jsou doručována postupně, ne najednou.
- Klient může data zpracovávat průběžně, jak přicházejí.
- Snižuje vnímanou latenci a zlepšuje uživatelský zážitek.

### Proč používat streamování?

Důvody pro použití streamování jsou následující:

- Uživatelé dostávají okamžitou zpětnou vazbu, ne jen na konci.
- Umožňuje real-time aplikace a responzivní UI.
- Efektivnější využití síťových a výpočetních zdrojů.

### Jednoduchý příklad: HTTP streamovací server a klient

Zde je jednoduchý příklad, jak lze streamování implementovat:

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

Tento příklad ukazuje server, který posílá klientovi sérii zpráv, jakmile jsou k dispozici, místo aby čekal na všechny zprávy najednou.

**Jak to funguje:**
- Server postupně odesílá každou zprávu, jakmile je připravená.
- Klient přijímá a vypisuje každou část zprávy ihned po příchodu.

**Požadavky:**
- Server musí používat streamovací odpověď (např. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) namísto volby streamování přes MCP.

- **Pro jednoduché streamovací potřeby:** Klasické HTTP streamování je jednodušší na implementaci a dostačující pro základní scénáře.

- **Pro složité, interaktivní aplikace:** MCP streamování nabízí strukturovanější přístup s bohatšími metadaty a oddělením notifikací od finálních výsledků.

- **Pro AI aplikace:** Notifikační systém MCP je zvlášť užitečný pro dlouhotrvající AI úlohy, kde chcete uživatele informovat o průběhu.

## Streamování v MCP

Viděli jste již doporučení a srovnání klasického streamování a streamování v MCP. Pojďme se nyní podrobně podívat, jak přesně využít streamování v MCP.

Pochopení fungování streamování v rámci MCP je klíčové pro tvorbu responzivních aplikací, které uživatelům poskytují real-time zpětnou vazbu během dlouhotrvajících operací.

V MCP streamování neznamená posílání hlavní odpovědi po částech, ale odesílání **notifikací** klientovi během zpracování požadavku nástrojem. Tyto notifikace mohou obsahovat informace o průběhu, logy nebo jiné události.

### Jak to funguje

Hlavní výsledek je stále odesílán jako jedna odpověď. Notifikace však mohou být zasílány jako samostatné zprávy během zpracování a tím aktualizovat klienta v reálném čase. Klient musí být schopen tyto notifikace přijímat a zobrazovat.

## Co je to notifikace?

Řekli jsme „notifikace“, co to znamená v kontextu MCP?

Notifikace je zpráva odeslaná ze serveru klientovi, která informuje o průběhu, stavu nebo jiných událostech během dlouhotrvající operace. Notifikace zvyšují transparentnost a zlepšují uživatelský zážitek.

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

Notifikace patří do tématu v MCP nazývaného ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pro funkčnost logování musí server povolit tuto funkci/kapacitu takto:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> V závislosti na použitém SDK může být logování zapnuto ve výchozím nastavení, nebo ho budete muset explicitně povolit v konfiguraci serveru.

Existují různé typy notifikací:

| Úroveň     | Popis                         | Příklad použití               |
|------------|-------------------------------|------------------------------|
| debug      | Podrobné ladicí informace      | Vstup a výstup z funkcí      |
| info       | Obecné informační zprávy       | Aktualizace průběhu operace  |
| notice     | Normální, ale významné události| Změny konfigurace            |
| warning    | Varovné stavy                 | Použití zastaralých funkcí   |
| error      | Chybové stavy                | Selhání operace              |
| critical   | Kritické stavy               | Selhání systémové komponenty |
| alert      | Nutná okamžitá akce          | Zjištěná poškození dat       |
| emergency  | Systém je nepoužitelný       | Kompletní selhání systému    |

## Implementace notifikací v MCP

Pro implementaci notifikací v MCP je potřeba nastavit jak serverovou, tak klientskou část pro zpracování real-time aktualizací. To umožní vaší aplikaci poskytovat okamžitou zpětnou vazbu uživatelům během dlouhotrvajících operací.

### Serverová část: Odesílání notifikací

Začněme na straně serveru. V MCP definujete nástroje, které mohou během zpracování požadavků odesílat notifikace. Server používá kontextový objekt (obvykle `ctx`) k odesílání zpráv klientovi.

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

V předchozím příkladu `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` přenos:

```python
mcp.run(transport="streamable-http")
```

</details>

### Klientská část: Příjem notifikací

Klient musí implementovat zpracovatele zpráv, který bude notifikace přijímat a zobrazovat je v reálném čase.

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

V předchozím kódu `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) klient implementuje zpracovatele zpráv pro notifikace.

## Notifikace průběhu a scénáře

Tato sekce vysvětluje koncept notifikací průběhu v MCP, proč jsou důležité a jak je implementovat pomocí Streamable HTTP. Najdete zde i praktické zadání pro upevnění znalostí.

Notifikace průběhu jsou zprávy odesílané ze serveru klientovi během dlouhotrvajících operací v reálném čase. Místo čekání na dokončení celého procesu server průběžně informuje klienta o aktuálním stavu. To zvyšuje transparentnost, zlepšuje uživatelský zážitek a usnadňuje ladění.

**Příklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Proč používat notifikace průběhu?

Notifikace průběhu jsou důležité z několika důvodů:

- **Lepší uživatelský zážitek:** Uživatelé vidí aktualizace během zpracování, ne jen na konci.
- **Real-time zpětná vazba:** Klienti mohou zobrazovat progress bary nebo logy, což zvyšuje vnímání responzivity aplikace.
- **Snazší ladění a monitorování:** Vývojáři i uživatelé vidí, kde může být proces pomalý nebo zablokovaný.

### Jak implementovat notifikace průběhu

Zde je postup, jak implementovat notifikace průběhu v MCP:

- **Na serveru:** Použijte `ctx.info()` nebo `ctx.log()` pro odesílání notifikací při zpracování jednotlivých položek. Tím posíláte zprávy klientovi ještě před tím, než je hlavní výsledek připraven.
- **Na klientovi:** Implementujte zpracovatele zpráv, který poslouchá a zobrazuje notifikace, jak přicházejí. Tento zpracovatel rozlišuje notifikace a finální výsledek.

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

Při implementaci MCP serverů s HTTP přenosy je bezpečnost zásadní otázkou, která vyžaduje pečlivé zohlednění různých útoků a ochranných mechanismů.

### Přehled

Bezpečnost je klíčová při zpřístupňování MCP serverů přes HTTP. Streamable HTTP přináší nové možnosti útoků a vyžaduje pečlivé nastavení.

### Klíčové body
- **Validace hlavičky Origin**: Vždy ověřujte `Origin` hlavičku, abyste zabránili CSRF a dalším útokům.
- **Používejte HTTPS**: Vždy provozujte streamovací servery přes HTTPS pro šifrování komunikace.
- **Omezte přístup**: Implementujte autentizaci a autorizaci pro přístup ke streamovacím endpointům.
- **Zabezpečte CORS**: Správně nastavte CORS pravidla, aby byly povoleny pouze důvěryhodné domény.
- **Monitorujte provoz**: Sledujte neobvyklé vzory provozu, které by mohly indikovat útok.
- **Aktualizujte SDK a závislosti**: Pravidelně aktualizujte používané knihovny a frameworky.

### Udržování kompatibility

Během migrace je doporučeno zachovat kompatibilitu s existujícími SSE klienty. Zde jsou některé strategie:

- Můžete podporovat oba přenosy – SSE i Streamable HTTP – spuštěním na různých endpointách.
- Postupně migrujte klienty na nový přenos.

### Výzvy

Během migrace je potřeba řešit následující výzvy:

- Zajistit, aby všichni klienti byli aktualizováni.
- Řešit rozdíly v doručování notifikací.

### Zadání: Vytvořte vlastní streamovací MCP aplikaci

**Scénář:**
Vytvořte MCP server a klienta, kde server zpracovává seznam položek (např. soubory nebo dokumenty) a posílá notifikaci za každou zpracovanou položku. Klient by měl zobrazovat každou notifikaci ihned po příchodu.

**Kroky:**

1. Implementujte serverový nástroj, který zpracovává seznam a posílá notifikace pro každou položku.
2. Implementujte klienta se zpracovatelem zpráv, který notifikace zobrazuje v reálném čase.
3. Otestujte implementaci spuštěním serveru i klienta a sledujte přicházející notifikace.

[Řešení](./solution/README.md)

## Další čtení a co dál?

Pokračujte ve svém poznávání MCP streamování a rozšiřujte své znalosti s pomocí dalších zdrojů a doporučených kroků pro tvorbu pokročilejších aplikací.

### Další čtení

- [Microsoft: Úvod do HTTP streamování](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Co dál?

- Vyzkoušejte tvorbu pokročilejších MCP nástrojů, které používají streamování pro real-time analytiku, chat nebo kolaborativní editaci.
- Prozkoumejte integraci MCP streamování s frontendovými frameworky (React, Vue, apod.) pro živé aktualizace UI.
- Další krok: [Využití AI Toolkit pro VSCode](../07-aitk/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro zásadní informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.