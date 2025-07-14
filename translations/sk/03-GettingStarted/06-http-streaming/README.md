<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:51:34+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sk"
}
-->
# HTTPS Streaming s Model Context Protocol (MCP)

Táto kapitola poskytuje komplexný návod na implementáciu bezpečného, škálovateľného a real-time streamovania pomocou Model Context Protocol (MCP) cez HTTPS. Pokrýva motiváciu pre streamovanie, dostupné transportné mechanizmy, ako implementovať streamovateľný HTTP v MCP, bezpečnostné odporúčania, migráciu zo SSE a praktické rady pre tvorbu vlastných streamovacích MCP aplikácií.

## Transportné mechanizmy a streamovanie v MCP

Táto sekcia skúma rôzne dostupné transportné mechanizmy v MCP a ich úlohu pri umožnení streamovacích schopností pre real-time komunikáciu medzi klientmi a servermi.

### Čo je transportný mechanizmus?

Transportný mechanizmus definuje, ako sa vymieňajú dáta medzi klientom a serverom. MCP podporuje viacero typov transportu, aby vyhovel rôznym prostrediam a požiadavkám:

- **stdio**: Štandardný vstup/výstup, vhodný pre lokálne a CLI nástroje. Jednoduchý, ale nevhodný pre web alebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverom posielať real-time aktualizácie klientom cez HTTP. Dobré pre webové UI, ale obmedzené v škálovateľnosti a flexibilite.
- **Streamable HTTP**: Moderný HTTP-based streaming transport, podporujúci notifikácie a lepšiu škálovateľnosť. Odporúča sa pre väčšinu produkčných a cloudových scenárov.

### Porovnávacia tabuľka

Pozrite si porovnávaciu tabuľku nižšie, aby ste pochopili rozdiely medzi týmito transportnými mechanizmami:

| Transport         | Real-time aktualizácie | Streamovanie | Škálovateľnosť | Použitie                  |
|-------------------|-----------------------|--------------|----------------|--------------------------|
| stdio             | Nie                   | Nie          | Nízka          | Lokálne CLI nástroje     |
| SSE               | Áno                   | Áno          | Stredná        | Web, real-time aktualizácie |
| Streamable HTTP   | Áno                   | Áno          | Vysoká         | Cloud, multi-klient      |

> **Tip:** Výber správneho transportu ovplyvňuje výkon, škálovateľnosť a používateľský zážitok. **Streamable HTTP** je odporúčaný pre moderné, škálovateľné a cloud-ready aplikácie.

Všimnite si transporty stdio a SSE, ktoré ste videli v predchádzajúcich kapitolách, a ako streamovateľný HTTP je transport, ktorý je pokrytý v tejto kapitole.

## Streamovanie: Koncepty a motivácia

Pochopenie základných konceptov a motivácií za streamovaním je kľúčové pre implementáciu efektívnych real-time komunikačných systémov.

**Streamovanie** je technika v sieťovom programovaní, ktorá umožňuje posielať a prijímať dáta v malých, spravovateľných častiach alebo ako sekvenciu udalostí, namiesto čakania na kompletnú odpoveď. Je to obzvlášť užitočné pre:

- Veľké súbory alebo dátové sady.
- Real-time aktualizácie (napr. chat, progress bary).
- Dlhodobé výpočty, kde chcete používateľa priebežne informovať.

Tu je, čo potrebujete vedieť o streamovaní na vysokej úrovni:

- Dáta sa doručujú postupne, nie naraz.
- Klient môže spracovávať dáta hneď, ako prichádzajú.
- Znižuje vnímanú latenciu a zlepšuje používateľský zážitok.

### Prečo používať streamovanie?

Dôvody pre použitie streamovania sú nasledovné:

- Používatelia dostávajú spätnú väzbu okamžite, nie až na konci
- Umožňuje real-time aplikácie a responzívne UI
- Efektívnejšie využitie sieťových a výpočtových zdrojov

### Jednoduchý príklad: HTTP streaming server a klient

Tu je jednoduchý príklad, ako môže byť streamovanie implementované:

<details>
<summary>Python</summary>

**Server (Python, používa FastAPI a StreamingResponse):**
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

**Klient (Python, používa requests):**
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

Tento príklad demonštruje server, ktorý posiela sériu správ klientovi, keď sú k dispozícii, namiesto čakania na všetky správy naraz.

**Ako to funguje:**
- Server postupne odovzdáva každú správu, keď je pripravená.
- Klient prijíma a vypisuje každú časť hneď, ako príde.

**Požiadavky:**
- Server musí používať streamovaciu odpoveď (napr. `StreamingResponse` vo FastAPI).
- Klient musí spracovávať odpoveď ako stream (`stream=True` v requests).
- Content-Type je zvyčajne `text/event-stream` alebo `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, používa Spring Boot a Server-Sent Events):**

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

**Klient (Java, používa Spring WebFlux WebClient):**

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
- Používa reaktívny stack Spring Boot s `Flux` pre streamovanie
- `ServerSentEvent` poskytuje štruktúrované streamovanie udalostí s typmi udalostí
- `WebClient` s `bodyToFlux()` umožňuje reaktívne spracovanie streamu
- `delayElements()` simuluje čas spracovania medzi udalosťami
- Udalosti môžu mať typy (`info`, `result`) pre lepšie spracovanie na strane klienta

</details>

### Porovnanie: Klasické streamovanie vs MCP streamovanie

Rozdiely medzi klasickým spôsobom streamovania a tým, ako funguje streamovanie v MCP, možno zhrnúť takto:

| Funkcia                | Klasické HTTP streamovanie     | MCP streamovanie (notifikácie)    |
|------------------------|-------------------------------|----------------------------------|
| Hlavná odpoveď         | Rozdelená na časti (chunked)  | Jedna odpoveď na konci            |
| Aktualizácie priebehu  | Posielané ako dátové časti    | Posielané ako notifikácie         |
| Požiadavky na klienta  | Musí spracovať stream         | Musí implementovať spracovanie správ |
| Použitie               | Veľké súbory, AI token streamy| Priebeh, logy, real-time spätná väzba |

### Kľúčové rozdiely

Ďalej sú uvedené niektoré kľúčové rozdiely:

- **Komunikačný vzor:**
   - Klasické HTTP streamovanie: Používa jednoduché chunked transfer encoding na posielanie dát po častiach
   - MCP streamovanie: Používa štruktúrovaný systém notifikácií s JSON-RPC protokolom

- **Formát správ:**
   - Klasické HTTP: Jednoduché textové časti s novými riadkami
   - MCP: Štruktúrované objekty LoggingMessageNotification s metadátami

- **Implementácia klienta:**
   - Klasické HTTP: Jednoduchý klient spracúvajúci streamované odpovede
   - MCP: Zložitejší klient s handlerom správ na spracovanie rôznych typov správ

- **Aktualizácie priebehu:**
   - Klasické HTTP: Priebeh je súčasťou hlavného streamu odpovede
   - MCP: Priebeh sa posiela cez samostatné notifikačné správy, zatiaľ čo hlavná odpoveď príde na konci

### Odporúčania

Odporúčame zvážiť nasledujúce pri výbere medzi klasickým streamovaním (ako endpoint `/stream`, ktorý sme ukázali vyššie) a streamovaním cez MCP:

- **Pre jednoduché potreby streamovania:** Klasické HTTP streamovanie je jednoduchšie na implementáciu a postačuje pre základné potreby.

- **Pre komplexné, interaktívne aplikácie:** MCP streamovanie poskytuje štruktúrovanejší prístup s bohatšími metadátami a oddelením notifikácií od finálnych výsledkov.

- **Pre AI aplikácie:** Notifikačný systém MCP je obzvlášť užitočný pre dlhodobé AI úlohy, kde chcete priebežne informovať používateľov o stave.

## Streamovanie v MCP

Takže ste už videli niektoré odporúčania a porovnania rozdielov medzi klasickým streamovaním a streamovaním v MCP. Poďme sa podrobnejšie pozrieť, ako môžete využiť streamovanie v MCP.

Pochopenie, ako streamovanie funguje v rámci MCP, je nevyhnutné pre tvorbu responzívnych aplikácií, ktoré poskytujú real-time spätnú väzbu používateľom počas dlhodobých operácií.

V MCP nejde o posielanie hlavnej odpovede po častiach, ale o posielanie **notifikácií** klientovi počas spracovania požiadavky nástrojom. Tieto notifikácie môžu obsahovať aktualizácie priebehu, logy alebo iné udalosti.

### Ako to funguje

Hlavný výsledok sa stále posiela ako jedna odpoveď. Notifikácie sa však môžu posielať ako samostatné správy počas spracovania a tým priebežne aktualizovať klienta. Klient musí byť schopný tieto notifikácie spracovať a zobraziť.

## Čo je to notifikácia?

Povedali sme "notifikácia", čo to znamená v kontexte MCP?

Notifikácia je správa odoslaná zo servera klientovi, ktorá informuje o priebehu, stave alebo iných udalostiach počas dlhodobej operácie. Notifikácie zlepšujú transparentnosť a používateľský zážitok.

Napríklad klient by mal poslať notifikáciu, keď je dokončené úvodné nadviazanie spojenia so serverom.

Notifikácia vyzerá ako JSON správa:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikácie patria do témy v MCP nazývanej ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Aby logging fungoval, server musí túto funkciu/povolenie aktivovať takto:

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

| Úroveň    | Popis                         | Príklad použitia              |
|-----------|-------------------------------|------------------------------|
| debug     | Detailné debug informácie      | Vstupy/výstupy funkcií       |
| info      | Všeobecné informačné správy   | Aktualizácie priebehu        |
| notice    | Bežné, ale významné udalosti   | Zmeny konfigurácie           |
| warning   | Varovné stavy                 | Použitie zastaranej funkcie  |
| error     | Chybové stavy                | Zlyhania operácií            |
| critical  | Kritické stavy               | Zlyhania systémových komponentov |
| alert     | Nutná okamžitá akcia         | Zistená korupcia dát         |
| emergency | Systém je nepoužiteľný       | Kompletné zlyhanie systému   |

## Implementácia notifikácií v MCP

Na implementáciu notifikácií v MCP je potrebné nastaviť server aj klienta tak, aby zvládali real-time aktualizácie. To umožní vašej aplikácii poskytovať okamžitú spätnú väzbu používateľom počas dlhodobých operácií.

### Serverová strana: Odosielanie notifikácií

Začnime serverovou stranou. V MCP definujete nástroje, ktoré môžu počas spracovania požiadaviek posielať notifikácie. Server používa kontextový objekt (zvyčajne `ctx`) na odosielanie správ klientovi.

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

V predchádzajúcom príklade nástroj `process_files` posiela klientovi tri notifikácie počas spracovania každého súboru. Metóda `ctx.info()` sa používa na odosielanie informačných správ.

</details>

Okrem toho, aby notifikácie fungovali, uistite sa, že server používa streamovací transport (napr. `streamable-http`) a klient implementuje handler správ na spracovanie notifikácií. Tu je príklad, ako nastaviť server na použitie transportu `streamable-http`:

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

V tomto .NET príklade je nástroj `ProcessFiles` označený atribútom `Tool` a počas spracovania každého súboru posiela klientovi tri notifikácie. Metóda `ctx.Info()` sa používa na odosielanie informačných správ.

Na povolenie notifikácií vo vašom .NET MCP serveri sa uistite, že používate streamovací transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klientská strana: Prijímanie notifikácií

Klient musí implementovať handler správ, ktorý spracuje a zobrazí notifikácie hneď, ako prídu.

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

V predchádzajúcom kóde funkcia `message_handler` kontroluje, či je prichádzajúca správa notifikáciou. Ak áno, vypíše ju; inak ju spracuje ako bežnú správu zo servera. Tiež si všimnite, že `ClientSession` je inicializovaná s `message_handler` na spracovanie prichádzajúcich notifikácií.

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

V tomto .NET príklade funkcia `MessageHandler` kontroluje, či je prichádzajúca správa notifikáciou. Ak áno, vypíše ju; inak ju spracuje ako bežnú správu zo servera. `ClientSession` je inicializovaná s handlerom správ cez `ClientSessionOptions`.

</details>

Na povolenie notifikácií sa uistite, že server používa streamovací transport (napr. `streamable-http`) a klient implementuje handler správ na spracovanie notifikácií.

## Notifikácie priebehu a scenáre

Táto sekcia vysvetľuje koncept notifikácií priebehu v MCP, prečo sú dôležité a ako ich implementovať pomocou Streamable HTTP. Nájdete tu aj praktické zadanie na upevnenie vedomostí.

Notifikácie priebehu sú real-time správy posielané zo servera klientovi počas dlhodobých operácií. Namiesto čakania na dokončenie celého procesu server priebežne informuje klienta o aktuálnom stave. To zlepšuje transparentnosť, používateľský zážitok a uľahčuje ladenie.

**Príklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Prečo používať notifikácie priebehu?

Notifikácie priebehu sú dôležité z niekoľkých dôvodov:

- **Lepší používateľský zážitok:** Používatelia vidia aktualizácie počas práce, nie len na konci.
- **Real-time spätná väzba:** Klienti môžu zobrazovať progress bary alebo logy, čo robí aplikáciu responzívnejšou.
- **Jednoduchšie ladenie a monitorovanie:** Vývojári a používatelia vidia, kde môže byť proces pomalý alebo zaseknutý.

### Ako implementovať notifikácie priebehu

Tu je, ako môžete implementovať notifikácie priebehu v MCP:

- **Na serveri:** Použite `ctx.info()` alebo `ctx.log()` na odosielanie notifikácií po spracovaní každej položky. Tým sa klientovi pošle správa ešte pred finálnym výsledkom.
- **Na klientovi:** Implementujte handler správ, ktorý počúva a zobrazuje notifikácie hneď, ako prídu. Tento handler rozlišuje medzi notifikáciami a finálnym výsledkom.

**Príklad servera:**

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

**Príklad klienta:**

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

Pri implementácii MCP serverov s HTTP transportmi je bezpečnosť kľúčovou otázkou, ktorá si vyžaduje dôkladnú pozornosť voči rôznym útokom a ochranným mechanizmom.

### Prehľad

Bezpečnosť je zásadná pri sprístupňovaní MCP serverov cez HTTP. Streamable HTTP prináša nové možnosti útokov a vyžaduje starostlivé nastavenie.

### Kľúčové body
- **Validácia hlavičky Origin**: Vždy overujte hlavičku `Origin`, aby ste predišli DNS rebinding útokom.
- **Viazanie na localhost**: Pri lokálnom vývoji viažte servery na `localhost`, aby neboli prístupné z verejného internetu.
- **Autentifikácia**: Pre produkčné nasadenia implementujte autentifikáciu (napr. API kľúče, OAuth).
- **CORS**: Nastavte politiky Cross-Origin Resource Sharing (CORS) na obmedzenie prístupu.
- **HTTPS**: V produkcii používajte HTTPS na šifrovanie komunikácie.

### Najlepšie postupy
- Nikdy neverte prichádzajúcim požiadavkám bez overenia.
- Logujte a monitorujte všetky prístupy a chyby.
- Pravidelne aktualizujte závislosti, aby ste opravili bezpečnostné chyby.

### Výzvy
- Nájsť rovnováhu medzi bezpečnosťou a jednoduchosťou vývoja
- Zabezpečiť kompatibilitu s rôznymi klientskymi prostrediami


## Prechod zo SSE na Streamable HTTP

Pre aplikácie, ktoré momentálne používajú Server-Sent Events (SSE), migrácia na Streamable HTTP prináša rozšírené možnosti a lepšiu dlhodobú udržateľnosť MCP implementácií.

### Prečo prejsť na novú verziu?

Existujú dva hlavné dôvody na prechod zo SSE na Streamable HTTP:

- Streamable HTTP ponúka lepšiu škálovateľnosť, kompatibilitu a bohatšiu podporu notifikácií než SSE.
- Je to odporúčaný transport pre nové MCP aplikácie.

### Kroky migrácie

Takto môžete migrovať zo SSE na Streamable HTTP vo vašich MCP aplikáciách:

- **Aktualizujte serverový kód** na použitie `transport="streamable-http"` v `mcp.run()`.
- **Aktualizujte klientsky kód** na použitie `streamablehttp_client` namiesto SSE klienta.
- **Implementujte spracovanie správ** v klientovi na spracovanie notifikácií.
- **Otestujte kompatibilitu** s existujúcimi nástrojmi a pracovnými postupmi.

### Udržiavanie kompatibility

Odporúča sa počas migrácie zachovať kompatibilitu so súčasnými SSE klientmi. Tu sú niektoré stratégie:

- Môžete podporovať oba transporty – SSE aj Streamable HTTP – na rôznych endpointoch.
- Postupne migrujte klientov na nový transport.

### Výzvy

Pri migrácii je potrebné riešiť tieto výzvy:

- Zabezpečiť, aby všetci klienti boli aktualizovaní
- Riešiť rozdiely v doručovaní notifikácií

## Bezpečnostné úvahy

Bezpečnosť by mala byť prioritou pri implementácii akéhokoľvek servera, najmä pri použití HTTP transportov ako Streamable HTTP v MCP.

Pri implementácii MCP serverov s HTTP transportmi je bezpečnosť kľúčovou otázkou, ktorá si vyžaduje dôkladnú pozornosť voči rôznym útokom a ochranným mechanizmom.

### Prehľad

Bezpečnosť je zásadná pri sprístupňovaní MCP serverov cez HTTP. Streamable HTTP prináša nové možnosti útokov a vyžaduje starostlivé nastavenie.

Tu sú niektoré kľúčové bezpečnostné aspekty:

- **Validácia hlavičky Origin**: Vždy overujte hlavičku `Origin`, aby ste predišli DNS rebinding útokom.
- **Viazanie na localhost**: Pri lokálnom vývoji viažte servery na `localhost`, aby neboli prístupné z verejného internetu.
- **Autentifikácia**: Pre produkčné nasadenia implementujte autentifikáciu (napr. API kľúče, OAuth).
- **CORS**: Nastavte politiky Cross-Origin Resource Sharing (CORS) na obmedzenie prístupu.
- **HTTPS**: V produkcii používajte HTTPS na šifrovanie komunikácie.

### Najlepšie postupy

Okrem toho tu sú niektoré odporúčané postupy pri zabezpečení MCP streaming servera:

- Nikdy neverte prichádzajúcim požiadavkám bez overenia.
- Logujte a monitorujte všetky prístupy a chyby.
- Pravidelne aktualizujte závislosti, aby ste opravili bezpečnostné chyby.

### Výzvy

Pri implementácii bezpečnosti v MCP streaming serveroch narazíte na tieto výzvy:

- Nájsť rovnováhu medzi bezpečnosťou a jednoduchosťou vývoja
- Zabezpečiť kompatibilitu s rôznymi klientskymi prostrediami

### Zadanie: Vytvorte si vlastnú streamingovú MCP aplikáciu

**Scenár:**
Vytvorte MCP server a klienta, kde server spracuje zoznam položiek (napr. súbory alebo dokumenty) a pre každú spracovanú položku pošle notifikáciu. Klient by mal zobrazovať každú notifikáciu hneď, ako príde.

**Kroky:**

1. Implementujte serverový nástroj, ktorý spracuje zoznam a pošle notifikácie pre každú položku.
2. Implementujte klienta so spracovaním správ, ktorý bude notifikácie zobrazovať v reálnom čase.
3. Otestujte implementáciu spustením servera aj klienta a sledujte notifikácie.

[Solution](./solution/README.md)

## Ďalšie čítanie a čo ďalej?

Ak chcete pokračovať vo svojej ceste s MCP streamingom a rozšíriť si vedomosti, táto sekcia ponúka ďalšie zdroje a odporúčané kroky pre tvorbu pokročilejších aplikácií.

### Ďalšie čítanie

- [Microsoft: Úvod do HTTP streamingu](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Čo ďalej?

- Skúste vytvoriť pokročilejšie MCP nástroje, ktoré využívajú streaming pre analýzy v reálnom čase, chat alebo kolaboratívne úpravy.
- Preskúmajte integráciu MCP streamingu s frontendovými frameworkmi (React, Vue a pod.) pre živé aktualizácie UI.
- Ďalej: [Využitie AI Toolkit pre VSCode](../07-aitk/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.