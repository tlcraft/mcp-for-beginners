<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:53:06+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sk"
}
-->
# HTTPS Streaming s Model Context Protocol (MCP)

Táto kapitola poskytuje komplexný návod na implementáciu bezpečného, škálovateľného a reálneho streamovania pomocou Model Context Protocol (MCP) cez HTTPS. Pokrýva motiváciu pre streamovanie, dostupné transportné mechanizmy, spôsob implementácie streamovateľného HTTP v MCP, bezpečnostné odporúčania, migráciu zo SSE a praktické rady na vytváranie vlastných streamingových MCP aplikácií.

## Transportné mechanizmy a streamovanie v MCP

Táto časť skúma rôzne dostupné transportné mechanizmy v MCP a ich úlohu pri umožnení streamovacích schopností pre reálnu komunikáciu medzi klientmi a servermi.

### Čo je transportný mechanizmus?

Transportný mechanizmus definuje, ako sa vymieňajú dáta medzi klientom a serverom. MCP podporuje viacero typov transportu, aby vyhovel rôznym prostrediam a požiadavkám:

- **stdio**: Štandardný vstup/výstup, vhodný pre lokálne a CLI nástroje. Jednoduchý, ale nevhodný pre web alebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverom posielať reálne aktualizácie klientom cez HTTP. Dobré pre webové UI, ale obmedzené v škálovateľnosti a flexibilite.
- **Streamable HTTP**: Moderný HTTP-based streaming transport, podporujúci notifikácie a lepšiu škálovateľnosť. Odporúča sa pre väčšinu produkčných a cloudových scenárov.

### Porovnávacia tabuľka

Pozrite si porovnávaciu tabuľku nižšie, aby ste pochopili rozdiely medzi týmito transportnými mechanizmami:

| Transport         | Reálne aktualizácie | Streamovanie | Škálovateľnosť | Použitie                  |
|-------------------|---------------------|--------------|----------------|--------------------------|
| stdio             | Nie                 | Nie          | Nízka          | Lokálne CLI nástroje      |
| SSE               | Áno                 | Áno          | Stredná        | Web, reálne aktualizácie  |
| Streamable HTTP   | Áno                 | Áno          | Vysoká         | Cloud, multi-klient       |

> **Tip:** Výber správneho transportu ovplyvňuje výkon, škálovateľnosť a používateľský zážitok. **Streamable HTTP** sa odporúča pre moderné, škálovateľné a cloud-ready aplikácie.

Všimnite si transporty stdio a SSE, ktoré ste videli v predchádzajúcich kapitolách, a to, že streamovateľné HTTP je transport, ktorý je pokrytý v tejto kapitole.

## Streamovanie: koncepty a motivácia

Pochopenie základných konceptov a motivácií za streamovaním je kľúčové pre efektívnu implementáciu reálnej komunikácie v reálnom čase.

**Streamovanie** je technika v sieťovom programovaní, ktorá umožňuje posielať a prijímať dáta po malých, spracovateľných častiach alebo ako sekvenciu udalostí, namiesto čakania na kompletnú odpoveď. Toto je obzvlášť užitočné pre:

- Veľké súbory alebo dátové súbory.
- Reálne aktualizácie (napr. chat, progress bary).
- Dlhodobé výpočty, kde chcete používateľa priebežne informovať.

Tu je, čo by ste mali vedieť o streamovaní na vysokej úrovni:

- Dáta sa doručujú postupne, nie naraz.
- Klient môže spracovávať dáta hneď, ako prichádzajú.
- Znižuje vnímanú latenciu a zlepšuje používateľský zážitok.

### Prečo používať streamovanie?

Dôvody na použitie streamovania sú:

- Používatelia dostávajú spätnú väzbu okamžite, nie až na konci.
- Umožňuje reálne aplikácie a responzívne UI.
- Efektívnejšie využitie sieťových a výpočtových zdrojov.

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
- Server postupne posiela každú správu, keď je pripravená.
- Klient prijíma a vypisuje každú časť, keď dorazí.

**Požiadavky:**
- Server musí používať streamingovú odpoveď (napr. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) namiesto výberu streamovania cez MCP.

- **Pre jednoduché potreby streamovania:** Klasické HTTP streamovanie je jednoduchšie na implementáciu a postačuje pre základné potreby.

- **Pre komplexné, interaktívne aplikácie:** MCP streamovanie poskytuje štruktúrovanejší prístup s bohatšími metadátami a oddelením notifikácií od finálnych výsledkov.

- **Pre AI aplikácie:** Notifikačný systém MCP je obzvlášť užitočný pre dlhodobé AI úlohy, kde chcete používateľov priebežne informovať o pokroku.

## Streamovanie v MCP

Takže ste videli niektoré odporúčania a porovnania rozdielov medzi klasickým streamovaním a streamovaním v MCP. Poďme sa podrobnejšie pozrieť, ako presne môžete využiť streamovanie v MCP.

Pochopenie, ako streamovanie funguje v rámci MCP, je dôležité pre vytváranie responzívnych aplikácií, ktoré poskytujú reálnu spätnú väzbu používateľom počas dlhodobých operácií.

V MCP nejde o posielanie hlavnej odpovede po častiach, ale o posielanie **notifikácií** klientovi počas spracovania požiadavky nástrojom. Tieto notifikácie môžu obsahovať aktualizácie o pokroku, logy alebo iné udalosti.

### Ako to funguje

Hlavný výsledok je stále odoslaný ako jedna odpoveď. Notifikácie však môžu byť odosielané ako samostatné správy počas spracovania a tým priebežne aktualizujú klienta v reálnom čase. Klient musí byť schopný tieto notifikácie spracovať a zobraziť.

## Čo je to notifikácia?

Povedali sme „Notifikácia“, čo to znamená v kontexte MCP?

Notifikácia je správa odoslaná zo servera klientovi, ktorá informuje o pokroku, stave alebo iných udalostiach počas dlhodobej operácie. Notifikácie zlepšujú prehľadnosť a používateľský zážitok.

Napríklad klient má poslať notifikáciu, keď je inicializácia spojenia so serverom dokončená.

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

Notifikácie patria do témy v MCP označenej ako ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Na zapnutie logovania musí server povoliť túto funkciu/možnosť takto:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> V závislosti od použitého SDK môže byť logovanie zapnuté automaticky, alebo ho možno budete musieť explicitne povoliť v konfigurácii servera.

Existujú rôzne typy notifikácií:

| Úroveň     | Popis                           | Príklad použitia                |
|------------|---------------------------------|--------------------------------|
| debug      | Podrobné debug informácie       | Vstupy/výstupy funkcií          |
| info       | Všeobecné informačné správy     | Aktualizácie o pokroku          |
| notice     | Normálne, ale významné udalosti | Zmeny konfigurácie              |
| warning    | Varovné stavy                   | Použitie zastaranej funkcie     |
| error      | Chybové stavy                  | Zlyhanie operácie              |
| critical   | Kritické stavy                 | Zlyhanie systémových komponentov|
| alert      | Nutné okamžité opatrenia       | Zistená korupcia dát           |
| emergency  | Systém nefunkčný               | Kompletné zlyhanie systému     |

## Implementácia notifikácií v MCP

Na implementáciu notifikácií v MCP je potrebné nastaviť serverovú aj klientske stranu na spracovanie reálnych aktualizácií. To umožní vašej aplikácii poskytovať okamžitú spätnú väzbu používateľom počas dlhodobých operácií.

### Serverová strana: Odosielanie notifikácií

Začnime serverovou stranou. V MCP definujete nástroje, ktoré môžu posielať notifikácie počas spracovania požiadaviek. Server používa kontextový objekt (zvyčajne `ctx`) na odosielanie správ klientovi.

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

V predchádzajúcom príklade transport `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

### Klientská strana: Prijímanie notifikácií

Klient musí implementovať spracovateľa správ na spracovanie a zobrazenie notifikácií hneď, ako prídu.

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

V predchádzajúcom kóde klient implementuje `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`, ktorý spracováva notifikácie.

## Notifikácie o pokroku a scenáre

Táto sekcia vysvetľuje koncept notifikácií o pokroku v MCP, prečo sú dôležité a ako ich implementovať pomocou Streamable HTTP. Nájdete tu aj praktické zadanie na upevnenie vedomostí.

Notifikácie o pokroku sú správy posielané zo servera klientovi počas dlhodobých operácií v reálnom čase. Namiesto čakania na dokončenie celého procesu server priebežne informuje klienta o aktuálnom stave. To zlepšuje prehľadnosť, používateľský zážitok a uľahčuje ladenie.

**Príklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Prečo používať notifikácie o pokroku?

Notifikácie o pokroku sú dôležité z niekoľkých dôvodov:

- **Lepší používateľský zážitok:** Používatelia vidia aktualizácie počas práce, nie len na konci.
- **Reálna spätná väzba:** Klienti môžu zobrazovať progress bary alebo logy, čo robí aplikáciu responzívnou.
- **Jednoduchšie ladenie a monitoring:** Vývojári a používatelia vidia, kde môže proces spomaľovať alebo zastaviť.

### Ako implementovať notifikácie o pokroku

Tu je, ako môžete implementovať notifikácie o pokroku v MCP:

- **Na serveri:** Použite `ctx.info()` or `ctx.log()` na odosielanie notifikácií počas spracovania každej položky. Tým sa pošle správa klientovi ešte pred finálnym výsledkom.
- **Na klientovi:** Implementujte spracovateľa správ, ktorý počúva a zobrazuje notifikácie hneď, ako prídu. Tento handler rozlišuje medzi notifikáciami a finálnym výsledkom.

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

**Klientský príklad:**

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

## Bezpečnostné aspekty

Pri implementácii MCP serverov s HTTP-based transportami je bezpečnosť kľúčovým faktorom, ktorý si vyžaduje dôkladnú pozornosť voči rôznym útokom a ochranným mechanizmom.

### Prehľad

Bezpečnosť je kritická pri sprístupňovaní MCP serverov cez HTTP. Streamable HTTP prináša nové potenciálne bezpečnostné riziká a vyžaduje starostlivú konfiguráciu.

### Kľúčové body
- **Validácia Origin Header:** Vždy validujte hlavičku `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` namiesto SSE klienta.
3. **Implementujte spracovateľa správ** v klientovi na spracovanie notifikácií.
4. **Testujte kompatibilitu** s existujúcimi nástrojmi a pracovnými tokmi.

### Udržiavanie kompatibility

Odporúča sa zachovať kompatibilitu s existujúcimi SSE klientmi počas migrácie. Tu sú niektoré stratégie:

- Môžete podporovať oba transporty SSE aj Streamable HTTP súčasne na rôznych endpointoch.
- Postupne migrujte klientov na nový transport.

### Výzvy

Počas migrácie riešte nasledujúce výzvy:

- Zabezpečiť, aby všetci klienti boli aktualizovaní
- Riešiť rozdiely v doručovaní notifikácií

### Zadanie: Vytvorte vlastnú streamingovú MCP aplikáciu

**Scenár:**
Vytvorte MCP server a klienta, kde server spracuje zoznam položiek (napr. súbory alebo dokumenty) a pre každú spracovanú položku pošle notifikáciu. Klient by mal zobrazovať každú notifikáciu hneď, ako príde.

**Kroky:**

1. Implementujte serverový nástroj, ktorý spracuje zoznam a posiela notifikácie pre každú položku.
2. Implementujte klienta so spracovateľom správ na zobrazenie notifikácií v reálnom čase.
3. Otestujte implementáciu spustením servera aj klienta a sledujte notifikácie.

[Solution](./solution/README.md)

## Ďalšie čítanie a čo ďalej?

Ak chcete pokračovať vo svojej ceste so streamovaním MCP a rozšíriť svoje vedomosti, táto sekcia poskytuje ďalšie zdroje a odporúčané kroky na vytváranie pokročilejších aplikácií.

### Ďalšie čítanie

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Čo ďalej?

- Skúste vytvoriť pokročilejšie MCP nástroje, ktoré používajú streamovanie pre reálne analytiky, chat alebo kolaboratívne úpravy.
- Preskúmajte integráciu MCP streamovania s frontendovými frameworkmi (React, Vue, atď.) pre živé aktualizácie UI.
- Ďalej: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.