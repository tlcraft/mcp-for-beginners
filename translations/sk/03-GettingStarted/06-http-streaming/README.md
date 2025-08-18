<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f1383103523fa822e1fec7ef81904d5",
  "translation_date": "2025-08-18T15:39:43+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sk"
}
-->
# HTTPS Streaming s protokolom Model Context Protocol (MCP)

Táto kapitola poskytuje komplexný návod na implementáciu bezpečného, škálovateľného a reálneho času streamovania s protokolom Model Context Protocol (MCP) pomocou HTTPS. Zahŕňa motiváciu pre streamovanie, dostupné transportné mechanizmy, ako implementovať streamovateľný HTTP v MCP, bezpečnostné osvedčené postupy, migráciu zo SSE a praktické rady pre vytváranie vlastných MCP aplikácií na streamovanie.

## Transportné mechanizmy a streamovanie v MCP

Táto sekcia skúma rôzne transportné mechanizmy dostupné v MCP a ich úlohu pri umožňovaní streamovacích schopností pre komunikáciu v reálnom čase medzi klientmi a servermi.

### Čo je transportný mechanizmus?

Transportný mechanizmus definuje, ako sa údaje vymieňajú medzi klientom a serverom. MCP podporuje viacero typov transportov, aby vyhovoval rôznym prostrediam a požiadavkám:

- **stdio**: Štandardný vstup/výstup, vhodný pre lokálne a CLI nástroje. Jednoduchý, ale nevhodný pre web alebo cloud.
- **SSE (Server-Sent Events)**: Umožňuje serverom posielať aktualizácie v reálnom čase klientom cez HTTP. Dobré pre webové rozhrania, ale obmedzené v škálovateľnosti a flexibilite.
- **Streamovateľný HTTP**: Moderný HTTP transport pre streamovanie, podporujúci notifikácie a lepšiu škálovateľnosť. Odporúčaný pre väčšinu produkčných a cloudových scenárov.

### Porovnávacia tabuľka

Pozrite si porovnávaciu tabuľku nižšie, aby ste pochopili rozdiely medzi týmito transportnými mechanizmami:

| Transport         | Aktualizácie v reálnom čase | Streamovanie | Škálovateľnosť | Použitie                  |
|-------------------|-----------------------------|--------------|----------------|---------------------------|
| stdio             | Nie                         | Nie          | Nízka          | Lokálne CLI nástroje      |
| SSE               | Áno                         | Áno          | Stredná        | Web, aktualizácie v reálnom čase |
| Streamovateľný HTTP | Áno                        | Áno          | Vysoká         | Cloud, viac klientov      |

> **Tip:** Výber správneho transportu ovplyvňuje výkon, škálovateľnosť a používateľskú skúsenosť. **Streamovateľný HTTP** je odporúčaný pre moderné, škálovateľné a cloudové aplikácie.

Všimnite si transporty stdio a SSE, ktoré sme vám ukázali v predchádzajúcich kapitolách, a ako streamovateľný HTTP je transport pokrytý v tejto kapitole.

## Streamovanie: Koncepty a motivácia

Pochopenie základných konceptov a motivácie za streamovaním je nevyhnutné pre implementáciu efektívnych systémov komunikácie v reálnom čase.

**Streamovanie** je technika v sieťovom programovaní, ktorá umožňuje odosielanie a prijímanie údajov v malých, spracovateľných častiach alebo ako sekvenciu udalostí, namiesto čakania na kompletnú odpoveď. To je obzvlášť užitočné pre:

- Veľké súbory alebo dataset-y.
- Aktualizácie v reálnom čase (napr. chat, ukazovatele priebehu).
- Dlhodobé výpočty, kde chcete používateľa priebežne informovať.

Tu je, čo potrebujete vedieť o streamovaní na vysokej úrovni:

- Údaje sú doručované postupne, nie naraz.
- Klient môže spracovávať údaje, ako prichádzajú.
- Znižuje vnímanú latenciu a zlepšuje používateľskú skúsenosť.

### Prečo používať streamovanie?

Dôvody na používanie streamovania sú nasledovné:

- Používatelia dostávajú spätnú väzbu okamžite, nielen na konci.
- Umožňuje aplikácie v reálnom čase a responzívne rozhrania.
- Efektívnejšie využitie sieťových a výpočtových zdrojov.

### Jednoduchý príklad: HTTP Streaming Server & Klient

Tu je jednoduchý príklad, ako môže byť streamovanie implementované:

#### Python

**Server (Python, pomocou FastAPI a StreamingResponse):**

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

**Klient (Python, pomocou requests):**

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

Tento príklad demonštruje server, ktorý posiela sériu správ klientovi, ako sú dostupné, namiesto čakania na všetky správy.

**Ako to funguje:**

- Server postupne odosiela každú správu, ako je pripravená.
- Klient prijíma a tlačí každú časť, ako prichádza.

**Požiadavky:**

- Server musí používať streamovaciu odpoveď (napr. `StreamingResponse` vo FastAPI).
- Klient musí spracovávať odpoveď ako stream (`stream=True` v requests).
- Content-Type je zvyčajne `text/event-stream` alebo `application/octet-stream`.

#### Java

**Server (Java, pomocou Spring Boot a Server-Sent Events):**

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

**Klient (Java, pomocou Spring WebFlux WebClient):**

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

- Používa reaktívny stack Spring Boot s `Flux` pre streamovanie.
- `ServerSentEvent` poskytuje štruktúrované streamovanie udalostí s typmi udalostí.
- `WebClient` s `bodyToFlux()` umožňuje reaktívnu konzumáciu streamovania.
- `delayElements()` simuluje čas spracovania medzi udalosťami.
- Udalosti môžu mať typy (`info`, `result`) pre lepšie spracovanie na strane klienta.

### Porovnanie: Klasické streamovanie vs MCP streamovanie

Rozdiely medzi tým, ako funguje streamovanie "klasickým" spôsobom a ako funguje v MCP, môžeme znázorniť takto:

| Funkcia              | Klasické HTTP streamovanie     | MCP streamovanie (notifikácie)     |
|----------------------|-------------------------------|------------------------------------|
| Hlavná odpoveď       | Po častiach                   | Jedna, na konci                   |
| Aktualizácie priebehu | Posielané ako dátové časti    | Posielané ako notifikácie         |
| Požiadavky na klienta | Musí spracovať stream         | Musí implementovať handler správ  |
| Použitie             | Veľké súbory, AI token streamy | Priebeh, logy, spätná väzba v reálnom čase |

### Pozorované kľúčové rozdiely

Ďalšie kľúčové rozdiely:

- **Komunikačný vzor:**
  - Klasické HTTP streamovanie: Používa jednoduché chunked transfer encoding na posielanie údajov po častiach.
  - MCP streamovanie: Používa štruktúrovaný systém notifikácií s JSON-RPC protokolom.

- **Formát správ:**
  - Klasické HTTP: Čistý text po častiach s novými riadkami.
  - MCP: Štruktúrované objekty LoggingMessageNotification s metadátami.

- **Implementácia klienta:**
  - Klasické HTTP: Jednoduchý klient, ktorý spracováva streamovacie odpovede.
  - MCP: Sofistikovanejší klient s handlerom správ na spracovanie rôznych typov správ.

- **Aktualizácie priebehu:**
  - Klasické HTTP: Priebeh je súčasťou hlavného streamu odpovede.
  - MCP: Priebeh je posielaný cez samostatné notifikačné správy, zatiaľ čo hlavná odpoveď prichádza na konci.

### Odporúčania

Odporúčame nasledovné pri výbere medzi implementáciou klasického streamovania (ako endpoint `/stream`, ktorý sme ukázali vyššie) a streamovania cez MCP:

- **Pre jednoduché potreby streamovania:** Klasické HTTP streamovanie je jednoduchšie implementovať a postačuje pre základné potreby.
- **Pre komplexné, interaktívne aplikácie:** MCP streamovanie poskytuje štruktúrovanejší prístup s bohatšími metadátami a oddelením medzi notifikáciami a konečnými výsledkami.
- **Pre AI aplikácie:** Notifikačný systém MCP je obzvlášť užitočný pre dlhodobé AI úlohy, kde chcete používateľov priebežne informovať o priebehu.

...
Existujú dva presvedčivé dôvody na prechod zo SSE na Streamable HTTP:

- Streamable HTTP ponúka lepšiu škálovateľnosť, kompatibilitu a bohatšiu podporu notifikácií ako SSE.
- Je to odporúčaný transport pre nové MCP aplikácie.

### Kroky migrácie

Tu je postup, ako migrovať zo SSE na Streamable HTTP vo vašich MCP aplikáciách:

- **Aktualizujte serverový kód**, aby používal `transport="streamable-http"` v `mcp.run()`.
- **Aktualizujte klientský kód**, aby používal `streamablehttp_client` namiesto SSE klienta.
- **Implementujte správcu správ** v klientovi na spracovanie notifikácií.
- **Otestujte kompatibilitu** s existujúcimi nástrojmi a pracovnými postupmi.

### Zachovanie kompatibility

Odporúča sa zachovať kompatibilitu s existujúcimi SSE klientmi počas procesu migrácie. Tu sú niektoré stratégie:

- Môžete podporovať SSE aj Streamable HTTP tým, že budete prevádzkovať oba transporty na rôznych koncových bodoch.
- Postupne migrujte klientov na nový transport.

### Výzvy

Uistite sa, že riešite nasledujúce výzvy počas migrácie:

- Zabezpečenie aktualizácie všetkých klientov
- Riešenie rozdielov v doručovaní notifikácií

## Bezpečnostné aspekty

Bezpečnosť by mala byť najvyššou prioritou pri implementácii akéhokoľvek servera, najmä pri používaní transportov založených na HTTP, ako je Streamable HTTP v MCP.

Pri implementácii MCP serverov s transportmi založenými na HTTP sa bezpečnosť stáva kľúčovou otázkou, ktorá si vyžaduje dôkladnú pozornosť voči viacerým vektorom útokov a ochranným mechanizmom.

### Prehľad

Bezpečnosť je kritická pri vystavovaní MCP serverov cez HTTP. Streamable HTTP prináša nové povrchové oblasti útokov a vyžaduje dôkladnú konfiguráciu.

Tu sú niektoré kľúčové bezpečnostné aspekty:

- **Validácia hlavičky Origin**: Vždy validujte hlavičku `Origin`, aby ste zabránili útokom DNS rebinding.
- **Viazanie na localhost**: Pre lokálny vývoj viažte servery na `localhost`, aby ste ich neodhalili verejnému internetu.
- **Autentifikácia**: Implementujte autentifikáciu (napr. API kľúče, OAuth) pre produkčné nasadenia.
- **CORS**: Konfigurujte politiky Cross-Origin Resource Sharing (CORS) na obmedzenie prístupu.
- **HTTPS**: Používajte HTTPS v produkcii na šifrovanie prenosu.

### Najlepšie postupy

Okrem toho, tu sú niektoré najlepšie postupy, ktoré by ste mali dodržiavať pri implementácii bezpečnosti vo vašom MCP streaming serveri:

- Nikdy nedôverujte prichádzajúcim požiadavkám bez validácie.
- Zaznamenávajte a monitorujte všetky prístupy a chyby.
- Pravidelne aktualizujte závislosti na opravu bezpečnostných zraniteľností.

### Výzvy

Pri implementácii bezpečnosti v MCP streaming serveroch sa stretnete s niektorými výzvami:

- Vyváženie bezpečnosti s jednoduchým vývojom
- Zabezpečenie kompatibility s rôznymi klientskými prostrediami

### Zadanie: Vytvorte vlastnú streaming MCP aplikáciu

**Scenár:**
Vytvorte MCP server a klienta, kde server spracováva zoznam položiek (napr. súborov alebo dokumentov) a posiela notifikáciu za každú spracovanú položku. Klient by mal zobrazovať každú notifikáciu, keď dorazí.

**Kroky:**

1. Implementujte serverový nástroj, ktorý spracováva zoznam a posiela notifikácie za každú položku.
2. Implementujte klienta so správcom správ na zobrazovanie notifikácií v reálnom čase.
3. Otestujte svoju implementáciu spustením servera a klienta a pozorujte notifikácie.

[Solution](./solution/README.md)

## Ďalšie čítanie a čo ďalej?

Ak chcete pokračovať vo svojej ceste s MCP streamingom a rozšíriť svoje znalosti, táto sekcia poskytuje ďalšie zdroje a navrhované ďalšie kroky na vytváranie pokročilejších aplikácií.

### Ďalšie čítanie

- [Microsoft: Úvod do HTTP streamingu](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Čo ďalej?

- Skúste vytvoriť pokročilejšie MCP nástroje, ktoré využívajú streaming na analýzu v reálnom čase, chat alebo kolaboratívne úpravy.
- Preskúmajte integráciu MCP streamingu s frontendovými frameworkami (React, Vue, atď.) na živé aktualizácie UI.
- Ďalej: [Využitie AI Toolkit pre VSCode](../07-aitk/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.