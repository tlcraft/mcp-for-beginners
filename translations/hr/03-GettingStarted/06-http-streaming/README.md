<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:56:06+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hr"
}
-->
# HTTPS Streaming s Model Context Protocolom (MCP)

Ovo poglavlje pruža sveobuhvatan vodič za implementaciju sigurnog, skalabilnog i real-time streaminga pomoću Model Context Protocola (MCP) preko HTTPS-a. Obrađuje motivaciju za streaming, dostupne transportne mehanizme, kako implementirati streamable HTTP u MCP-u, najbolje sigurnosne prakse, migraciju sa SSE-a i praktične smjernice za izradu vlastitih streaming MCP aplikacija.

## Transportni mehanizmi i streaming u MCP-u

Ovaj dio istražuje različite transportne mehanizme dostupne u MCP-u i njihovu ulogu u omogućavanju streaming mogućnosti za komunikaciju u stvarnom vremenu između klijenata i servera.

### Što je transportni mehanizam?

Transportni mehanizam definira kako se podaci razmjenjuju između klijenta i servera. MCP podržava više vrsta transporta kako bi odgovorio različitim okruženjima i zahtjevima:

- **stdio**: Standardni ulaz/izlaz, prikladan za lokalne i CLI alate. Jednostavan, ali nije pogodan za web ili cloud.
- **SSE (Server-Sent Events)**: Omogućuje serverima da šalju ažuriranja u stvarnom vremenu klijentima preko HTTP-a. Dobar za web UI, ali ograničen u skalabilnosti i fleksibilnosti.
- **Streamable HTTP**: Moderan streaming transport baziran na HTTP-u, podržava notifikacije i bolju skalabilnost. Preporuča se za većinu produkcijskih i cloud scenarija.

### Usporedna tablica

Pogledajte tablicu ispod za razumijevanje razlika između ovih transportnih mehanizama:

| Transport         | Ažuriranja u stvarnom vremenu | Streaming | Skalabilnost | Primjena                |
|-------------------|-------------------------------|-----------|--------------|-------------------------|
| stdio             | Ne                            | Ne        | Niska        | Lokalni CLI alati       |
| SSE               | Da                            | Da        | Srednja      | Web, ažuriranja u realnom vremenu |
| Streamable HTTP   | Da                            | Da        | Visoka       | Cloud, višekorisnički   |

> **Tip:** Odabir pravog transporta utječe na performanse, skalabilnost i korisničko iskustvo. **Streamable HTTP** se preporučuje za moderne, skalabilne i cloud-ready aplikacije.

Obratite pažnju na transport stdio i SSE koje ste vidjeli u prethodnim poglavljima te na streamable HTTP koji je obrađen u ovom poglavlju.

## Streaming: Koncepti i motivacija

Razumijevanje osnovnih koncepata i motivacije iza streaminga ključno je za implementaciju učinkovitih sustava za komunikaciju u stvarnom vremenu.

**Streaming** je tehnika u mrežnom programiranju koja omogućuje slanje i primanje podataka u malim, upravljivim dijelovima ili kao niz događaja, umjesto čekanja da cijeli odgovor bude spreman. Posebno je koristan za:

- Velike datoteke ili skupove podataka.
- Ažuriranja u stvarnom vremenu (npr. chat, trake napretka).
- Dugotrajne izračune gdje želite korisnika držati informiranim.

Evo što trebate znati o streamingu na visokoj razini:

- Podaci se dostavljaju postupno, ne odjednom.
- Klijent može obrađivati podatke čim stignu.
- Smanjuje percipiranu latenciju i poboljšava korisničko iskustvo.

### Zašto koristiti streaming?

Razlozi za korištenje streaminga su sljedeći:

- Korisnici odmah dobivaju povratnu informaciju, ne samo na kraju
- Omogućuje real-time aplikacije i responzivne UI-e
- Efikasnije korištenje mrežnih i računalnih resursa

### Jednostavan primjer: HTTP streaming server i klijent

Evo jednostavnog primjera kako se streaming može implementirati:

<details>
<summary>Python</summary>

**Server (Python, koristeći FastAPI i StreamingResponse):**
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

**Klijent (Python, koristeći requests):**
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

Ovaj primjer pokazuje server koji šalje niz poruka klijentu čim su dostupne, umjesto da čeka da sve poruke budu spremne.

**Kako radi:**
- Server šalje svaku poruku čim je spremna.
- Klijent prima i ispisuje svaki dio čim stigne.

**Zahtjevi:**
- Server mora koristiti streaming response (npr. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) umjesto klasičnog MCP streaminga.

- **Za jednostavne streaming potrebe:** Klasični HTTP streaming je jednostavniji za implementaciju i dovoljan za osnovne potrebe.

- **Za složenije, interaktivne aplikacije:** MCP streaming pruža strukturiraniji pristup s bogatijim metapodacima i razdvajanjem notifikacija od konačnih rezultata.

- **Za AI aplikacije:** MCP sustav notifikacija posebno je koristan za dugotrajne AI zadatke gdje želite korisnike držati informiranim o napretku.

## Streaming u MCP-u

Dakle, vidjeli ste neke preporuke i usporedbe dosad o razlikama između klasičnog streaminga i streaminga u MCP-u. Sada ćemo detaljno objasniti kako točno možete iskoristiti streaming u MCP-u.

Razumijevanje kako streaming funkcionira unutar MCP okvira ključno je za izgradnju responzivnih aplikacija koje pružaju povratne informacije u stvarnom vremenu tijekom dugotrajnih operacija.

U MCP-u streaming nije slanje glavnog odgovora u dijelovima, već slanje **notifikacija** klijentu dok alat obrađuje zahtjev. Te notifikacije mogu sadržavati informacije o napretku, logove ili druge događaje.

### Kako to radi

Glavni rezultat i dalje se šalje kao jedinstveni odgovor. Međutim, notifikacije se mogu slati kao zasebne poruke tijekom obrade i na taj način ažurirati klijenta u stvarnom vremenu. Klijent mora moći obraditi i prikazati te notifikacije.

## Što je notifikacija?

Rekli smo "notifikacija", što to znači u kontekstu MCP-a?

Notifikacija je poruka koju server šalje klijentu kako bi ga obavijestio o napretku, statusu ili drugim događajima tijekom dugotrajne operacije. Notifikacije poboljšavaju transparentnost i korisničko iskustvo.

Na primjer, klijent treba poslati notifikaciju nakon što je uspostavljena početna veza (handshake) sa serverom.

Notifikacija izgleda ovako kao JSON poruka:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikacije pripadaju temi u MCP-u nazvanoj ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Da bi logiranje funkcioniralo, server ga mora omogućiti kao značajku/kapacitet na sljedeći način:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Ovisno o korištenom SDK-u, logiranje može biti omogućeno po defaultu ili ga je potrebno eksplicitno uključiti u konfiguraciji servera.

Postoje različite vrste notifikacija:

| Razina    | Opis                          | Primjer upotrebe               |
|-----------|-------------------------------|-------------------------------|
| debug     | Detaljne informacije za debug | Ulaz/izlaz funkcije           |
| info      | Opće informativne poruke      | Ažuriranja napretka operacije |
| notice    | Normalni, ali značajni događaji | Promjene konfiguracije       |
| warning   | Upozoravajući uvjeti          | Korištenje zastarjele funkcije|
| error     | Greške                       | Neuspjesi operacija           |
| critical  | Kritični uvjeti              | Kvarovi sistemskih komponenti |
| alert     | Potrebna je hitna akcija     | Detekcija korupcije podataka  |
| emergency | Sustav je neupotrebljiv      | Potpuni kvar sustava          |

## Implementacija notifikacija u MCP-u

Da biste implementirali notifikacije u MCP-u, potrebno je postaviti i server i klijentsku stranu za obradu ažuriranja u stvarnom vremenu. To omogućava vašoj aplikaciji da korisnicima pruži trenutne povratne informacije tijekom dugotrajnih operacija.

### Server: Slanje notifikacija

Počnimo sa serverskom stranom. U MCP-u definirate alate koji mogu slati notifikacije dok obrađuju zahtjeve. Server koristi kontekstni objekt (obično `ctx`) za slanje poruka klijentu.

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

U prethodnom primjeru, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Klijent: Primanje notifikacija

Klijent mora implementirati handler poruka koji obrađuje i prikazuje notifikacije čim stignu.

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

U prethodnom kodu, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) i vaš klijent implementira handler poruka za obradu notifikacija.

## Notifikacije napretka i scenariji

Ovaj dio objašnjava koncept notifikacija napretka u MCP-u, zašto su važne i kako ih implementirati koristeći Streamable HTTP. Također ćete pronaći praktični zadatak za bolje razumijevanje.

Notifikacije napretka su poruke u stvarnom vremenu koje server šalje klijentu tijekom dugotrajnih operacija. Umjesto da se čeka da cijeli proces završi, server stalno ažurira klijenta o trenutnom statusu. To poboljšava transparentnost, korisničko iskustvo i olakšava otklanjanje grešaka.

**Primjer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zašto koristiti notifikacije napretka?

Notifikacije napretka su važne iz nekoliko razloga:

- **Bolje korisničko iskustvo:** Korisnici vide ažuriranja dok posao napreduje, ne samo na kraju.
- **Povratna informacija u stvarnom vremenu:** Klijenti mogu prikazivati trake napretka ili logove, čineći aplikaciju responzivnijom.
- **Lakše praćenje i debugiranje:** Programeri i korisnici mogu vidjeti gdje proces može biti spor ili zapetljan.

### Kako implementirati notifikacije napretka

Evo kako možete implementirati notifikacije napretka u MCP-u:

- **Na serveru:** Koristite `ctx.info()` or `ctx.log()` za slanje notifikacija dok se obrađuje svaki element. Time se šalje poruka klijentu prije nego što glavni rezultat bude spreman.
- **Na klijentu:** Implementirajte handler poruka koji sluša i prikazuje notifikacije čim stignu. Taj handler razlikuje notifikacije od konačnog rezultata.

**Primjer servera:**

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

**Primjer klijenta:**

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

## Sigurnosne napomene

Kod implementacije MCP servera s HTTP transportima, sigurnost postaje ključna tema koja zahtijeva pažnju na više mogućih napada i mehanizme zaštite.

### Pregled

Sigurnost je kritična kada se MCP serveri izlažu preko HTTP-a. Streamable HTTP donosi nove potencijalne ranjivosti i zahtijeva pažljivu konfiguraciju.

### Ključne točke
- **Validacija Origin zaglavlja**: Uvijek provjeravajte `Origin` zaglavlje kako biste spriječili neželjene izvore.
- **Koristite HTTPS**: Zaštitite prijenos podataka enkripcijom.
- **Autentikacija i autorizacija**: Osigurajte da samo ovlašteni korisnici pristupaju servisima.
- **Ograničenje brzine i zaštita od DoS napada**: Implementirajte mehanizme za sprječavanje preopterećenja.
- **Redovito ažuriranje softvera**: Održavajte server i biblioteke sigurnima.
- **Testiranje i praćenje**: Kontinuirano pratite sigurnosne incidente i ranjivosti.

### Održavanje kompatibilnosti

Preporučuje se održavati kompatibilnost s postojećim SSE klijentima tijekom migracije. Evo nekoliko strategija:

- Možete podržavati oba transporta, SSE i Streamable HTTP, tako da ih pokrenete na različitim endpointima.
- Postupno migrirajte klijente na novi transport.

### Izazovi

Obratite pažnju na sljedeće izazove tijekom migracije:

- Osigurati da su svi klijenti ažurirani
- Rukovanje razlikama u dostavi notifikacija

### Zadatak: Izgradite vlastitu streaming MCP aplikaciju

**Scenarij:**
Izradite MCP server i klijent gdje server obrađuje listu stavki (npr. datoteke ili dokumente) i šalje notifikaciju za svaku obrađenu stavku. Klijent treba prikazati svaku notifikaciju čim stigne.

**Koraci:**

1. Implementirajte serverski alat koji obrađuje listu i šalje notifikacije za svaku stavku.
2. Implementirajte klijenta s handlerom poruka koji prikazuje notifikacije u stvarnom vremenu.
3. Testirajte implementaciju pokretanjem servera i klijenta te pratite notifikacije.

[Solution](./solution/README.md)

## Dodatna literatura i što dalje?

Da biste nastavili svoje putovanje s MCP streamingom i proširili znanje, ovaj dio pruža dodatne izvore i preporuke za daljnje korake u izgradnji naprednijih aplikacija.

### Dodatna literatura

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Što dalje?

- Pokušajte izgraditi naprednije MCP alate koji koriste streaming za real-time analitiku, chat ili kolaborativno uređivanje.
- Istražite integraciju MCP streaminga s frontend frameworkima (React, Vue itd.) za live UI ažuriranja.
- Sljedeće: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja proizašla iz korištenja ovog prijevoda.