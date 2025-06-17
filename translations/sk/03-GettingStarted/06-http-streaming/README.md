<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:27:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sk"
}
-->
# HTTPS streamovanie s Model Context Protocol (MCP)

Táto kapitola poskytuje komplexný návod na implementáciu bezpečného, škálovateľného a real-time streamovania pomocou Model Context Protocol (MCP) cez HTTPS. Pokrýva motiváciu pre streamovanie, dostupné transportné mechanizmy, spôsob implementácie streamovateľného HTTP v MCP, bezpečnostné odporúčania, migráciu zo SSE a praktické rady na vytvorenie vlastných streamovacích MCP aplikácií.

## Transportné mechanizmy a streamovanie v MCP

Táto časť skúma rôzne dostupné transportné mechanizmy v MCP a ich úlohu pri umožnení streamovacích schopností pre real-time komunikáciu medzi klientmi a servermi.

### Čo je transportný mechanizmus?

Transportný mechanizmus definuje spôsob výmeny dát medzi klientom a serverom. MCP podporuje viaceré typy transportov, aby vyhovel rôznym prostrediam a požiadavkám:

- **stdio**: Štandardný vstup/výstup, vhodný pre lokálne a CLI nástroje. Jednoduchý, ale nevhodný pre web alebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverom posielať klientom real-time aktualizácie cez HTTP. Vhodné pre webové UI, ale s obmedzenou škálovateľnosťou a flexibilitou.
- **Streamovateľné HTTP**: Moderný HTTP založený streamingový transport, podporujúci notifikácie a lepšiu škálovateľnosť. Odporúča sa pre väčšinu produkčných a cloudových scenárov.

### Porovnávacia tabuľka

Pozrite si nižšie porovnávaciu tabuľku, ktorá vám pomôže pochopiť rozdiely medzi týmito transportnými mechanizmami:

| Transport         | Real-time aktualizácie | Streamovanie | Škálovateľnosť | Použitie                  |
|-------------------|-----------------------|--------------|----------------|--------------------------|
| stdio             | Nie                   | Nie          | Nízka          | Lokálne CLI nástroje     |
| SSE               | Áno                   | Áno          | Stredná        | Web, real-time aktualizácie |
| Streamovateľné HTTP | Áno                   | Áno          | Vysoká         | Cloud, multi-klient      |

> **Tip:** Výber správneho transportu ovplyvňuje výkon, škálovateľnosť a používateľský zážitok. **Streamovateľné HTTP** je odporúčané pre moderné, škálovateľné a cloud-ready aplikácie.

Všimnite si transporty stdio a SSE, ktoré ste videli v predchádzajúcich kapitolách, a ako streamovateľné HTTP je transportom pokrytým v tejto kapitole.

## Streamovanie: Koncepty a motivácia

Pochopenie základných konceptov a motivácií za streamovaním je kľúčové pre efektívnu implementáciu real-time komunikačných systémov.

**Streamovanie** je technika v sieťovom programovaní, ktorá umožňuje posielať a prijímať dáta v malých, spravovateľných častiach alebo ako sekvenciu udalostí, namiesto čakania na kompletnú odpoveď. To je obzvlášť užitočné pre:

- Veľké súbory alebo dátové sady.
- Real-time aktualizácie (napr. chat, ukazovatele priebehu).
- Dlhodobé výpočty, kde chcete používateľa priebežne informovať.

Tu je základné, čo potrebujete o streamovaní vedieť:

- Dáta sa doručujú postupne, nie naraz.
- Klient môže spracovávať dáta hneď, ako prídu.
- Znižuje vnímanú latenciu a zlepšuje používateľský zážitok.

### Prečo používať streamovanie?

Dôvody na použitie streamovania sú nasledovné:

- Používatelia dostávajú okamžitú spätnú väzbu, nielen na konci.
- Umožňuje real-time aplikácie a responzívne UI.
- Efektívnejšie využitie sieťových a výpočtových zdrojov.

### Jednoduchý príklad: HTTP streamovací server a klient

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

Tento príklad demonštruje server, ktorý posiela sériu správ klientovi, keď sú dostupné, namiesto čakania na všetky správy naraz.

**Ako to funguje:**
- Server postupne odovzdáva každú správu, keď je pripravená.
- Klient prijíma a vypisuje každú časť hneď, ako príde.

**Požiadavky:**
- Server musí používať streamovaciu odpoveď (napr. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) namiesto voľby streamovania cez MCP.

- **Pre jednoduché streamovacie potreby:** Klasické HTTP streamovanie je jednoduchšie na implementáciu a postačuje pre základné potreby.

- **Pre komplexné, interaktívne aplikácie:** MCP streamovanie poskytuje štruktúrovanejší prístup s bohatšími metadátami a oddelením notifikácií od konečných výsledkov.

- **Pre AI aplikácie:** Notifikačný systém MCP je obzvlášť užitočný pre dlhodobé AI úlohy, kde chcete používateľov priebežne informovať o stave.

## Streamovanie v MCP

Takže ste už videli niekoľko odporúčaní a porovnaní rozdielov medzi klasickým streamovaním a streamovaním v MCP. Poďme sa podrobnejšie pozrieť na to, ako môžete využiť streamovanie v MCP.

Pochopenie, ako streamovanie funguje v rámci MCP, je nevyhnutné pre tvorbu responzívnych aplikácií, ktoré poskytujú používateľom real-time spätnú väzbu počas dlhodobých operácií.

V MCP nejde o posielanie hlavnej odpovede po častiach, ale o posielanie **notifikácií** klientovi počas spracovania požiadavky nástrojom. Tieto notifikácie môžu obsahovať aktualizácie priebehu, logy alebo iné udalosti.

### Ako to funguje

Hlavný výsledok je stále poslaný ako jedna odpoveď. Notifikácie však môžu byť zasielané ako samostatné správy počas spracovania a tým aktualizovať klienta v reálnom čase. Klient musí byť schopný tieto notifikácie spracovať a zobraziť.

## Čo je to notifikácia?

Povedali sme „notifikácia“, čo to znamená v kontexte MCP?

Notifikácia je správa odoslaná zo servera klientovi, ktorá informuje o priebehu, stave alebo iných udalostiach počas dlhodobej operácie. Notifikácie zvyšujú transparentnosť a používateľský zážitok.

Napríklad klient by mal poslať notifikáciu, keď je nadviazané úvodné spojenie so serverom.

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

Notifikácie patria do témy v MCP nazvanej ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Aby logging fungoval, server musí túto funkcionalitu povoliť ako feature/capability takto:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> V závislosti od použitého SDK môže byť logging povolený štandardne, alebo ho budete musieť explicitne povoliť v konfigurácii servera.

Existujú rôzne typy notifikácií:

| Úroveň     | Popis                          | Príklad použitia             |
|------------|-------------------------------|-----------------------------|
| debug      | Detailné debug informácie      | Vstupné/výstupné body funkcie |
| info       | Všeobecné informačné správy   | Aktualizácie priebehu operácie |
| notice     | Bežné, ale významné udalosti   | Zmeny konfigurácie          |
| warning    | Varovné stavy                 | Použitie zastaranej funkcie |
| error      | Chybové stavy                | Zlyhanie operácie           |
| critical   | Kritické stavy               | Zlyhanie systémovej komponenty |
| alert      | Nutné okamžité riešenie      | Zistená korupcia dát        |
| emergency  | Systém je nepoužiteľný       | Kompletné zlyhanie systému  |

## Implementácia notifikácií v MCP

Pre implementáciu notifikácií v MCP je potrebné nastaviť serverovú aj klientsku stranu na spracovanie real-time aktualizácií. To umožní vašej aplikácii poskytovať okamžitú spätnú väzbu používateľom počas dlhodobých operácií.

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

V predchádzajúcom príklade `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Klientská strana: Prijímanie notifikácií

Klient musí implementovať handler správ na spracovanie a zobrazovanie notifikácií po ich príchode.

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

V predchádzajúcom kóde `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) a váš klient implementuje handler správ na spracovanie notifikácií.

## Notifikácie priebehu a scenáre

Táto časť vysvetľuje koncept notifikácií priebehu v MCP, prečo sú dôležité a ako ich implementovať pomocou Streamovateľného HTTP. Nájdete tu aj praktické zadanie na upevnenie znalostí.

Notifikácie priebehu sú real-time správy posielané zo servera klientovi počas dlhodobých operácií. Namiesto čakania na dokončenie celého procesu server priebežne informuje klienta o aktuálnom stave. To zlepšuje transparentnosť, používateľský zážitok a uľahčuje ladenie.

**Príklad:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Prečo používať notifikácie priebehu?

Notifikácie priebehu sú nevyhnutné z niekoľkých dôvodov:

- **Lepší používateľský zážitok:** Používatelia vidia aktualizácie priebehu, nie len výsledok na konci.
- **Real-time spätná väzba:** Klienti môžu zobrazovať ukazovatele priebehu alebo logy, čím aplikácia pôsobí responzívnejšie.
- **Jednoduchšie ladenie a monitorovanie:** Vývojári a používatelia vidia, kde môže byť proces pomalý alebo zablokovaný.

### Ako implementovať notifikácie priebehu

Tu je spôsob, ako implementovať notifikácie priebehu v MCP:

- **Na serveri:** Použite `ctx.info()` or `ctx.log()` na odosielanie notifikácií pri spracovaní jednotlivých položiek. Tým sa klientovi pošle správa ešte pred pripravením hlavného výsledku.
- **Na klientovi:** Implementujte handler správ, ktorý počúva na notifikácie a zobrazuje ich hneď, ako prídu. Tento handler rozlišuje notifikácie a konečný výsledok.

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

## Bezpečnostné úvahy

Pri implementácii MCP serverov s HTTP transportmi sa bezpečnosť stáva zásadnou otázkou, ktorá vyžaduje dôkladné zváženie viacerých útokových vektorov a ochranných mechanizmov.

### Prehľad

Bezpečnosť je kľúčová pri sprístupňovaní MCP serverov cez HTTP. Streamovateľné HTTP prináša nové možnosti útokov a vyžaduje starostlivé nastavenie.

### Kľúčové body
- **Validácia hlavičky Origin**: Vždy overujte `Origin` header to prevent DNS rebinding attacks.
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
3. **Implementujte handler správ** v klientovi na spracovanie notifikácií.
4. **Testujte kompatibilitu** s existujúcimi nástrojmi a pracovnými tokmi.

### Zachovanie kompatibility

Odporúča sa zachovať kompatibilitu s existujúcimi SSE klientmi počas migrácie. Tu sú niektoré stratégie:

- Môžete podporovať oba transporty SSE aj Streamovateľné HTTP súčasne na rôznych endpointoch.
- Postupne migrujte klientov na nový transport.

### Výzvy

Počas migrácie je potrebné riešiť tieto výzvy:

- Zaistenie aktualizácie všetkých klientov
- Riešenie rozdielov v doručovaní notifikácií

### Zadanie: Vytvorte vlastnú streamingovú MCP aplikáciu

**Scenár:**
Vytvorte MCP server a klienta, kde server spracováva zoznam položiek (napr. súbory alebo dokumenty) a pre každú spracovanú položku posiela notifikáciu. Klient by mal zobrazovať každú notifikáciu hneď, ako príde.

**Kroky:**

1. Implementujte serverový nástroj, ktorý spracováva zoznam a posiela notifikácie pre každú položku.
2. Implementujte klienta s handlerom správ na zobrazenie notifikácií v reálnom čase.
3. Otestujte implementáciu spustením servera aj klienta a sledujte notifikácie.

[Riešenie](./solution/README.md)

## Ďalšie čítanie a čo ďalej?

Ak chcete pokračovať vo vašej ceste so streamovaním MCP a rozšíriť si vedomosti, táto časť poskytuje ďalšie zdroje a odporúčané kroky pre tvorbu pokročilejších aplikácií.

### Ďalšie čítanie

- [Microsoft: Úvod do HTTP streamovania](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Čo ďalej?

- Skúste vytvoriť pokročilejšie MCP nástroje, ktoré využívajú streamovanie pre real-time analytiku, chat alebo kolaboratívne úpravy.
- Preskúmajte integráciu MCP streamovania s frontend frameworkami (React, Vue a pod.) pre živé aktualizácie UI.
- Ďalej: [Využitie AI Toolkit pre VSCode](../07-aitk/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.