<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:29:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sk"
}
-->
# HTTPS streamovanie s Model Context Protocol (MCP)

Táto kapitola poskytuje komplexný návod na implementáciu bezpečného, škálovateľného a real-time streamovania pomocou Model Context Protocol (MCP) cez HTTPS. Pokrýva motiváciu pre streamovanie, dostupné transportné mechanizmy, spôsob implementácie streamovateľného HTTP v MCP, bezpečnostné odporúčania, migráciu zo SSE a praktické rady pre tvorbu vlastných streamingových MCP aplikácií.

## Transportné mechanizmy a streamovanie v MCP

Táto časť skúma rôzne dostupné transportné mechanizmy v MCP a ich úlohu pri umožnení streamovacích schopností pre real-time komunikáciu medzi klientmi a servermi.

### Čo je transportný mechanizmus?

Transportný mechanizmus definuje, ako sa vymieňajú dáta medzi klientom a serverom. MCP podporuje viacero typov transportov, aby vyhovel rôznym prostrediam a požiadavkám:

- **stdio**: Štandardný vstup/výstup, vhodný pre lokálne a CLI nástroje. Jednoduchý, ale nevhodný pre web alebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverom posielať real-time aktualizácie klientom cez HTTP. Vhodné pre webové UI, ale obmedzené v škálovateľnosti a flexibilite.
- **Streamable HTTP**: Moderný HTTP založený streamingový transport, podporujúci notifikácie a lepšiu škálovateľnosť. Odporúča sa pre väčšinu produkčných a cloudových scenárov.

### Porovnávacia tabuľka

Pozrite si nižšie porovnávaciu tabuľku, ktorá vám pomôže pochopiť rozdiely medzi týmito transportnými mechanizmami:

| Transport         | Real-time aktualizácie | Streamovanie | Škálovateľnosť | Použitie                 |
|-------------------|-----------------------|--------------|----------------|-------------------------|
| stdio             | Nie                   | Nie          | Nízka          | Lokálne CLI nástroje    |
| SSE               | Áno                   | Áno          | Stredná        | Web, real-time aktualizácie |
| Streamable HTTP   | Áno                   | Áno          | Vysoká         | Cloud, multi-klient     |

> **Tip:** Výber správneho transportu ovplyvňuje výkon, škálovateľnosť a používateľský zážitok. **Streamable HTTP** je odporúčaný pre moderné, škálovateľné a cloud-ready aplikácie.

Všimnite si transporty stdio a SSE, ktoré ste videli v predchádzajúcich kapitolách, a ako je streamovateľné HTTP transport, ktorý sa rieši v tejto kapitole.

## Streamovanie: Koncepty a motivácia

Pochopenie základných konceptov a motivácií za streamovaním je nevyhnutné pre efektívnu implementáciu real-time komunikačných systémov.

**Streamovanie** je technika v sieťovom programovaní, ktorá umožňuje posielať a prijímať dáta v malých, spravovateľných častiach alebo ako sled udalostí, namiesto čakania na kompletnú odpoveď. Je to obzvlášť užitočné pre:

- Veľké súbory alebo dátové sady.
- Real-time aktualizácie (napr. chat, indikátory priebehu).
- Dlhodobé výpočty, kde chcete používateľa priebežne informovať.

Tu je, čo by ste mali o streamovaní vedieť na vyššej úrovni:

- Dáta sa doručujú postupne, nie naraz.
- Klient môže spracovávať dáta hneď, ako prichádzajú.
- Znižuje vnímanú latenciu a zlepšuje používateľský zážitok.

### Prečo používať streamovanie?

Dôvody na použitie streamovania sú nasledovné:

- Používatelia dostávajú spätnú väzbu okamžite, nie až na konci.
- Umožňuje real-time aplikácie a responzívne UI.
- Efektívnejšie využitie sieťových a výpočtových zdrojov.

### Jednoduchý príklad: HTTP streaming server a klient

Tu je jednoduchý príklad, ako môže byť streamovanie implementované:

<details>
<summary>Python</summary>

**Server (Python, s použitím FastAPI a StreamingResponse):**
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

**Klient (Python, s použitím requests):**
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

Tento príklad ukazuje server, ktorý posiela sériu správ klientovi, keď sú k dispozícii, namiesto čakania na všetky správy naraz.

**Ako to funguje:**
- Server postupne vydáva každú správu, keď je pripravená.
- Klient prijíma a vypisuje každú časť hneď, ako príde.

**Požiadavky:**
- Server musí použiť streamingovú odpoveď (napr. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, s použitím Spring Boot a Server-Sent Events):**

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

**Klient (Java, s použitím Spring WebFlux WebClient):**

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

**Poznámky k implementácii v Jave:**
- Používa reaktívny stack Spring Boot s `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) oproti výberu streamovania cez MCP.

- **Pre jednoduché potreby streamovania:** Klasické HTTP streamovanie je jednoduchšie na implementáciu a postačuje pre základné použitia.

- **Pre komplexné, interaktívne aplikácie:** MCP streamovanie poskytuje štruktúrovanejší prístup s bohatšími metadátami a oddelením notifikácií od konečných výsledkov.

- **Pre AI aplikácie:** Notifikačný systém MCP je obzvlášť užitočný pre dlhodobé AI úlohy, kde chcete používateľov priebežne informovať o stave.

## Streamovanie v MCP

Takže ste už videli niektoré odporúčania a porovnania medzi klasickým streamovaním a streamovaním v MCP. Poďme si podrobne vysvetliť, ako môžete využiť streamovanie v MCP.

Pochopenie, ako streamovanie funguje v rámci MCP, je kľúčové pre tvorbu responzívnych aplikácií, ktoré poskytujú real-time spätnú väzbu používateľom počas dlhodobých operácií.

V MCP nejde o posielanie hlavnej odpovede po častiach, ale o posielanie **notifikácií** klientovi počas spracovania požiadavky nástrojom. Tieto notifikácie môžu obsahovať informácie o priebehu, logy alebo iné udalosti.

### Ako to funguje

Hlavný výsledok sa stále posiela ako jedna odpoveď. Notifikácie sa však môžu posielať ako samostatné správy počas spracovania a tak aktualizovať klienta v reálnom čase. Klient musí byť schopný tieto notifikácie spracovať a zobraziť.

## Čo je notifikácia?

Povedali sme „notifikácia“, čo to znamená v kontexte MCP?

Notifikácia je správa od servera klientovi, ktorá informuje o priebehu, stave alebo iných udalostiach počas dlhodobej operácie. Notifikácie zlepšujú transparentnosť a používateľský zážitok.

Napríklad klient má poslať notifikáciu, keď je dokončené počiatočné nadviazanie spojenia so serverom.

Notifikácia vyzerá takto ako JSON správa:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikácie patria do témy v MCP nazvanej ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Aby logging fungoval, server musí túto funkciu/povolenie povoliť takto:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> V závislosti od použitého SDK môže byť logging predvolene zapnutý, alebo ho budete musieť explicitne povoliť v konfigurácii servera.

Existujú rôzne typy notifikácií:

| Úroveň     | Popis                          | Príklad použitia             |
|------------|-------------------------------|-----------------------------|
| debug      | Detailné ladacie informácie   | Vstupy a výstupy funkcií    |
| info       | Všeobecné informačné správy   | Aktualizácie priebehu       |
| notice     | Normálne, ale významné udalosti | Zmeny konfigurácie         |
| warning    | Varovné stavy                 | Použitie zastaralých funkcií|
| error      | Chybové stavy                | Zlyhania operácií           |
| critical   | Kritické stavy               | Zlyhania systémových komponentov |
| alert      | Nutná okamžitá akcia          | Detekcia poškodenia dát     |
| emergency  | Systém nepoužiteľný           | Kompletné zlyhanie systému  |

## Implementácia notifikácií v MCP

Na implementáciu notifikácií v MCP je potrebné nastaviť server aj klienta tak, aby zvládali real-time aktualizácie. To umožní vašej aplikácii poskytovať okamžitú spätnú väzbu počas dlhodobých operácií.

### Serverová strana: Posielanie notifikácií

Začnime serverovou stranou. V MCP definujete nástroje, ktoré môžu posielať notifikácie počas spracovania požiadaviek. Server používa kontextový objekt (zvyčajne `ctx`) na posielanie správ klientovi.

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

V predchádzajúcom príklade sa používa `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

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

V tomto .NET príklade sa na posielanie informačných správ používa metóda `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()`.

Aby ste povolili notifikácie na vašom .NET MCP serveri, uistite sa, že používate streamingový transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klientská strana: Prijímanie notifikácií

Klient musí implementovať handler správ na spracovanie a zobrazenie notifikácií, keď prichádzajú.

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

V predchádzajúcom kóde sa `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` používa na spracovanie prichádzajúcich notifikácií.

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

V tomto .NET príklade sa `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` používa a klient implementuje handler správ na spracovanie notifikácií.

## Notifikácie o priebehu a scenáre

Táto časť vysvetľuje koncept notifikácií o priebehu v MCP, prečo sú dôležité a ako ich implementovať pomocou Streamable HTTP. Nájdete tu aj praktické zadanie na upevnenie vedomostí.

Notifikácie o priebehu sú real-time správy posielané zo servera klientovi počas dlhodobých operácií. Namiesto čakania na dokončenie celého procesu server priebežne informuje klienta o aktuálnom stave. To zlepšuje transparentnosť, používateľský zážitok a uľahčuje ladenie.

**Príklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Prečo používať notifikácie o priebehu?

Notifikácie o priebehu sú dôležité z viacerých dôvodov:

- **Lepší používateľský zážitok:** Používatelia vidia aktualizácie počas práce, nie len na konci.
- **Real-time spätná väzba:** Klienti môžu zobrazovať indikátory priebehu alebo logy, vďaka čomu aplikácia pôsobí responzívne.
- **Jednoduchšie ladenie a monitorovanie:** Vývojári a používatelia vidia, kde môže byť proces pomalý alebo zablokovaný.

### Ako implementovať notifikácie o priebehu

Tu je postup, ako implementovať notifikácie o priebehu v MCP:

- **Na serveri:** Použite `ctx.info()` or `ctx.log()` na posielanie notifikácií pri spracovaní každej položky. Tým sa klientovi pošle správa ešte predtým, než je hlavný výsledok pripravený.
- **Na klientovi:** Implementujte handler správ, ktorý počúva a zobrazuje notifikácie hneď, ako prídu. Tento handler rozlišuje medzi notifikáciami a konečným výsledkom.

**Serverový príklad:**

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

**Klientsky príklad:**

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

## Bezpečnostné úvahy

Pri implementácii MCP serverov s HTTP-based transportami je bezpečnosť kľúčová a vyžaduje si dôkladnú pozornosť voči rôznym útokom a ochranným mechanizmom.

### Prehľad

Bezpečnosť je kritická pri vystavovaní MCP serverov cez HTTP. Streamable HTTP prináša nové potenciálne útoky a vyžaduje dôkladné nastavenie.

### Kľúčové body
- **Validácia hlavičky Origin**: Vždy overujte hlavičku `Origin`, aby ste zabránili CSRF útokom.
- **Používanie HTTPS**: Vždy používajte šifrované spojenie na ochranu dát.
- **Autentifikácia a autorizácia**: Implementujte mechanizmy na overenie a povolenie prístupu k serveru.
- **Ochrana proti DoS útokom**: Obmedzte počet spojení a požiadaviek na server.
- **Bezpečné nastavenie CORS**: Konfigurujte CORS pravidlá podľa potreby.

### Udržiavanie kompatibility

Odporúča sa zachovať kompatibilitu so súčasnými SSE klientmi počas migrácie. Tu sú niektoré stratégie:

- Môžete podporovať súčasne SSE aj Streamable HTTP na rôznych endpointoch.
- Postupne migrujte klientov na nový transport.

### Výzvy

Počas migrácie je potrebné riešiť:

- Zabezpečenie, že všetci klienti sú aktualizovaní.
- Riešenie rozdielov v doručovaní notifikácií.

### Zadanie: Vytvorte vlastnú streamingovú MCP aplikáciu

**Scenár:**
Vytvorte MCP server a klienta, kde server spracováva zoznam položiek (napr. súbory alebo dokumenty) a pre každú spracovanú položku pošle notifikáciu. Klient by mal zobrazovať každú notifikáciu hneď, ako príde.

**Kroky:**

1. Implementujte serverový nástroj, ktorý spracuje zoznam a pošle notifikácie pre každú položku.
2. Implementujte klienta s handlerom správ, ktorý zobrazuje notifikácie v reálnom čase.
3. Otestujte implementáciu spustením servera aj klienta a sledujte notifikácie.

[Solution](./solution/README.md)

## Ďalšie čítanie a čo ďalej?

Ak chcete pokračovať vo vašej ceste so streamovaním MCP a rozšíriť svoje znalosti, táto sekcia poskytuje ďalšie zdroje a odporúčané kroky na tvorbu pokročilejších aplikácií.

### Ďalšie čítanie

- [Microsoft: Úvod do HTTP streamovania](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Čo ďalej?

- Vyskúšajte vytvoriť pokročilejšie MCP nástroje, ktoré používajú streamovanie pre real-time analytiku, chat alebo kolaboratívne úpravy.
- Preskúmajte integráciu MCP streamovania s frontend frameworkami (React, Vue a pod.) pre živé aktualizácie UI.
- Ďalej: [Využitie AI Toolkit pre VSCode

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.