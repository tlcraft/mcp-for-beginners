<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f1383103523fa822e1fec7ef81904d5",
  "translation_date": "2025-08-18T22:12:54+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hr"
}
-->
# HTTPS Streaming s Model Context Protocolom (MCP)

Ovo poglavlje pruža sveobuhvatan vodič za implementaciju sigurnog, skalabilnog i stvarnog vremenskog streaminga s Model Context Protocolom (MCP) koristeći HTTPS. Obuhvaća motivaciju za streaming, dostupne mehanizme prijenosa, kako implementirati streamable HTTP u MCP-u, najbolje sigurnosne prakse, migraciju sa SSE-a te praktične smjernice za izradu vlastitih MCP aplikacija za streaming.

## Mehanizmi prijenosa i streaming u MCP-u

Ovaj odjeljak istražuje različite mehanizme prijenosa dostupne u MCP-u i njihovu ulogu u omogućavanju streaming mogućnosti za komunikaciju u stvarnom vremenu između klijenata i poslužitelja.

### Što je mehanizam prijenosa?

Mehanizam prijenosa definira kako se podaci razmjenjuju između klijenta i poslužitelja. MCP podržava više vrsta prijenosa kako bi odgovarao različitim okruženjima i zahtjevima:

- **stdio**: Standardni ulaz/izlaz, prikladan za lokalne i CLI alate. Jednostavan, ali nije prikladan za web ili cloud.
- **SSE (Server-Sent Events)**: Omogućuje poslužiteljima slanje ažuriranja u stvarnom vremenu klijentima putem HTTP-a. Dobar za web sučelja, ali ograničen u skalabilnosti i fleksibilnosti.
- **Streamable HTTP**: Moderni HTTP-based streaming prijenos, podržava obavijesti i bolju skalabilnost. Preporučuje se za većinu produkcijskih i cloud scenarija.

### Usporedna tablica

Pogledajte usporednu tablicu u nastavku kako biste razumjeli razlike između ovih mehanizama prijenosa:

| Prijenos          | Ažuriranja u stvarnom vremenu | Streaming | Skalabilnost | Primjena                  |
|-------------------|------------------------------|-----------|-------------|--------------------------|
| stdio             | Ne                           | Ne        | Niska       | Lokalni CLI alati        |
| SSE               | Da                           | Da        | Srednja     | Web, ažuriranja u stvarnom vremenu |
| Streamable HTTP   | Da                           | Da        | Visoka      | Cloud, više klijenata    |

> **Savjet:** Odabir pravog prijenosa utječe na performanse, skalabilnost i korisničko iskustvo. **Streamable HTTP** preporučuje se za moderne, skalabilne i cloud-ready aplikacije.

Napomena o prijenosima stdio i SSE koji su objašnjeni u prethodnim poglavljima te kako je streamable HTTP prijenos obrađen u ovom poglavlju.

## Streaming: Koncepti i motivacija

Razumijevanje osnovnih koncepata i motivacije iza streaminga ključno je za implementaciju učinkovitih sustava komunikacije u stvarnom vremenu.

**Streaming** je tehnika u mrežnom programiranju koja omogućuje slanje i primanje podataka u malim, upravljivim dijelovima ili kao niz događaja, umjesto čekanja da cijeli odgovor bude spreman. Ovo je posebno korisno za:

- Velike datoteke ili skupove podataka.
- Ažuriranja u stvarnom vremenu (npr. chat, trake napretka).
- Dugotrajne izračune gdje želite informirati korisnika.

Evo što trebate znati o streamingu na visokoj razini:

- Podaci se isporučuju progresivno, ne odjednom.
- Klijent može obrađivati podatke kako stižu.
- Smanjuje percipiranu latenciju i poboljšava korisničko iskustvo.

### Zašto koristiti streaming?

Razlozi za korištenje streaminga su sljedeći:

- Korisnici dobivaju povratne informacije odmah, a ne tek na kraju.
- Omogućuje aplikacije u stvarnom vremenu i responzivna korisnička sučelja.
- Učinkovitije korištenje mrežnih i računalnih resursa.

### Jednostavan primjer: HTTP streaming poslužitelj i klijent

Evo jednostavnog primjera kako se streaming može implementirati:

#### Python

**Poslužitelj (Python, koristeći FastAPI i StreamingResponse):**

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

**Klijent (Python, koristeći requests):**

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

Ovaj primjer demonstrira poslužitelj koji šalje niz poruka klijentu kako postaju dostupne, umjesto da čeka da sve poruke budu spremne.

**Kako radi:**

- Poslužitelj šalje svaku poruku čim je spremna.
- Klijent prima i ispisuje svaki dio kako stiže.

**Zahtjevi:**

- Poslužitelj mora koristiti streaming odgovor (npr. `StreamingResponse` u FastAPI-ju).
- Klijent mora obrađivati odgovor kao stream (`stream=True` u requests).
- Content-Type je obično `text/event-stream` ili `application/octet-stream`.

#### Java

**Poslužitelj (Java, koristeći Spring Boot i Server-Sent Events):**

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

**Klijent (Java, koristeći Spring WebFlux WebClient):**

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

**Napomene o implementaciji u Javi:**

- Koristi reaktivni stack Spring Boota s `Flux` za streaming.
- `ServerSentEvent` omogućuje strukturirani streaming događaja s tipovima događaja.
- `WebClient` s `bodyToFlux()` omogućuje reaktivnu potrošnju streaminga.
- `delayElements()` simulira vrijeme obrade između događaja.
- Događaji mogu imati tipove (`info`, `result`) za bolje rukovanje na strani klijenta.

### Usporedba: Klasični streaming vs MCP streaming

Razlike između načina na koji streaming radi na "klasičan" način i kako radi u MCP-u mogu se prikazati ovako:

| Značajka              | Klasični HTTP streaming       | MCP streaming (Obavijesti)         |
|-----------------------|------------------------------|------------------------------------|
| Glavni odgovor        | U dijelovima                | Jedan, na kraju                   |
| Ažuriranja napretka   | Šalju se kao dijelovi podataka | Šalju se kao obavijesti           |
| Zahtjevi klijenta     | Mora obrađivati stream       | Mora implementirati handler poruka |
| Primjena              | Velike datoteke, AI tokeni  | Napredak, logovi, povratne informacije u stvarnom vremenu |

### Ključne razlike

Dodatno, evo nekih ključnih razlika:

- **Obrazac komunikacije:**
  - Klasični HTTP streaming: Koristi jednostavno chunked transfer encoding za slanje podataka u dijelovima.
  - MCP streaming: Koristi strukturirani sustav obavijesti s JSON-RPC protokolom.

- **Format poruka:**
  - Klasični HTTP: Dijelovi običnog teksta s novim redovima.
  - MCP: Strukturirani LoggingMessageNotification objekti s metapodacima.

- **Implementacija klijenta:**
  - Klasični HTTP: Jednostavan klijent koji obrađuje streaming odgovore.
  - MCP: Sofisticiraniji klijent s handlerom poruka za obradu različitih tipova poruka.

- **Ažuriranja napretka:**
  - Klasični HTTP: Napredak je dio glavnog stream odgovora.
  - MCP: Napredak se šalje putem zasebnih obavijesti dok glavni odgovor dolazi na kraju.

### Preporuke

Evo nekoliko preporuka kada birate između implementacije klasičnog streaminga (kao endpointa `/stream`) i streaminga putem MCP-a:

- **Za jednostavne potrebe streaminga:** Klasični HTTP streaming je jednostavniji za implementaciju i dovoljan za osnovne potrebe.
- **Za složene, interaktivne aplikacije:** MCP streaming pruža strukturiraniji pristup s bogatijim metapodacima i odvojenim obavijestima i konačnim rezultatima.
- **Za AI aplikacije:** MCP-ov sustav obavijesti posebno je koristan za dugotrajne AI zadatke gdje želite informirati korisnike o napretku.

## Streaming u MCP-u

Ok, vidjeli ste neke preporuke i usporedbe o razlici između klasičnog streaminga i streaminga u MCP-u. Pogledajmo detaljno kako možete iskoristiti streaming u MCP-u.

Razumijevanje kako streaming funkcionira unutar MCP okvira ključno je za izradu responzivnih aplikacija koje pružaju povratne informacije u stvarnom vremenu korisnicima tijekom dugotrajnih operacija.

U MCP-u, streaming nije o slanju glavnog odgovora u dijelovima, već o slanju **obavijesti** klijentu dok alat obrađuje zahtjev. Te obavijesti mogu uključivati ažuriranja napretka, logove ili druge događaje.

### Kako radi

Glavni rezultat se i dalje šalje kao jedan odgovor. Međutim, obavijesti se mogu slati kao zasebne poruke tijekom obrade, čime se klijent ažurira u stvarnom vremenu. Klijent mora biti sposoban obraditi i prikazati te obavijesti.

## Što je obavijest?

Spomenuli smo "obavijest", što to znači u kontekstu MCP-a?

Obavijest je poruka koju poslužitelj šalje klijentu kako bi ga informirao o napretku, statusu ili drugim događajima tijekom dugotrajne operacije. Obavijesti poboljšavaju transparentnost i korisničko iskustvo.

Na primjer, klijent bi trebao poslati obavijest nakon što je uspostavljena početna veza s poslužiteljem.

Obavijest izgleda ovako kao JSON poruka:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Obavijesti pripadaju temi u MCP-u koja se naziva ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Kako bi logging radio, poslužitelj ga mora omogućiti kao značajku/sposobnost ovako:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Ovisno o korištenom SDK-u, logging može biti omogućen prema zadanim postavkama ili ga možda trebate eksplicitno omogućiti u konfiguraciji poslužitelja.

Postoje različite vrste obavijesti:

| Razina     | Opis                        | Primjer primjene                |
|------------|-----------------------------|---------------------------------|
| debug      | Detaljne informacije za debug | Ulaz/izlaz iz funkcija         |
| info       | Opće informativne poruke    | Ažuriranja napretka operacije  |
| notice     | Normalni, ali značajni događaji | Promjene konfiguracije         |
| warning    | Upozorenja                  | Korištenje zastarjelih značajki |
| error      | Pogreške                    | Neuspjesi operacija            |
| critical   | Kritične pogreške           | Neuspjesi sustavnih komponenti |
| alert      | Potrebna hitna akcija       | Otkrivena korupcija podataka   |
| emergency  | Sustav nije upotrebljiv     | Potpuni neuspjeh sustava       |

## Implementacija obavijesti u MCP-u

Za implementaciju obavijesti u MCP-u, potrebno je postaviti i poslužiteljsku i klijentsku stranu kako bi mogle obrađivati ažuriranja u stvarnom vremenu. Ovo omogućuje vašoj aplikaciji da pruži trenutne povratne informacije korisnicima tijekom dugotrajnih operacija.

### Poslužiteljska strana: Slanje obavijesti

Počnimo s poslužiteljskom stranom. U MCP-u definirate alate koji mogu slati obavijesti dok obrađuju zahtjeve. Poslužitelj koristi objekt konteksta (obično `ctx`) za slanje poruka klijentu.

#### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

U prethodnom primjeru, alat `process_files` šalje tri obavijesti klijentu dok obrađuje svaku datoteku. Metoda `ctx.info()` koristi se za slanje informativnih poruka.

Dodatno, kako biste omogućili obavijesti, osigurajte da vaš poslužitelj koristi streaming prijenos (poput `streamable-http`) i da vaš klijent implementira handler poruka za obradu obavijesti. Evo kako možete postaviti poslužitelj da koristi `streamable-http` prijenos:

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

U ovom .NET primjeru, alat `ProcessFiles` označen je atributom `Tool` i šalje tri obavijesti klijentu dok obrađuje svaku datoteku. Metoda `ctx.Info()` koristi se za slanje informativnih poruka.

Kako biste omogućili obavijesti u vašem .NET MCP poslužitelju, osigurajte da koristite streaming prijenos:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Klijentska strana: Primanje obavijesti

Klijent mora implementirati handler poruka za obradu i prikaz obavijesti kako stižu.

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

U prethodnom kodu, funkcija `message_handler` provjerava je li dolazna poruka obavijest. Ako jest, ispisuje obavijest; inače, obrađuje je kao uobičajenu poruku poslužitelja. Također, primijetite kako je `ClientSession` inicijaliziran s `message_handler` za obradu dolaznih obavijesti.

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

U ovom .NET primjeru, funkcija `MessageHandler` provjerava je li dolazna poruka obavijest. Ako jest, ispisuje obavijest; inače, obrađuje je kao uobičajenu poruku poslužitelja. `ClientSession` je inicijaliziran s handlerom poruka putem `ClientSessionOptions`.

Kako biste omogućili obavijesti, osigurajte da vaš poslužitelj koristi streaming prijenos (poput `streamable-http`) i da vaš klijent implementira handler poruka za obradu obavijesti.

## Obavijesti o napretku i scenariji

Ovaj odjeljak objašnjava koncept obavijesti o napretku u MCP-u, zašto su važne i kako ih implementirati koristeći Streamable HTTP. Također ćete pronaći praktičan zadatak za jačanje vašeg razumijevanja.

Obavijesti o napretku su poruke u stvarnom vremenu koje poslužitelj šalje klijentu tijekom dugotrajnih operacija. Umjesto čekanja da cijeli proces završi, poslužitelj ažurira klijenta o trenutnom statusu. Ovo poboljšava transparentnost, korisničko iskustvo i olakšava debugiranje.

**Primjer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zašto koristiti obavijesti o napretku?

Obavijesti o napretku su ključne iz nekoliko razloga:

- **Bolje korisničko iskustvo:** Korisnici vide ažuriranja kako posao napreduje, a ne samo na kraju.
- **Povratne informacije u stvarnom vremenu:** Klijenti mogu prikazati trake napretka ili logove, čineći aplikaciju responzivnom.
- **Lakše debugiranje i praćenje:** Programeri i korisnici mogu vidjeti gdje proces može biti spor ili zapeo.

### Kako implementirati obavijesti o napretku

Evo kako možete implementirati obavijesti o napretku u MCP-u:

- **Na poslužitelju:** Koristite `ctx.info()` ili `ctx.log()` za slanje obavijesti dok se svaki element obrađuje. Ovo šalje poruku klijentu prije nego što je glavni rezultat spreman.
- **Na klijentu:** Implementirajte handler poruka koji sluša i prikazuje obavijesti kako stižu. Ovaj handler razlikuje obavijesti od konačnog rezultata.

**Primjer poslužitelja:**

#### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

**Primjer klijenta:**

#### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

## Sigurnosni aspekti

Kada implementirate MCP poslužitelje s HTTP-based prijenosima, sigurnost postaje ključna briga koja zahtijeva pažnju na više vektora napada i mehanizama zaštite.

### Pregled

Sigurnost je kritična kada izlažete MCP poslužitelje putem HTTP-a. Streamable HTTP uvodi nove površine napada i zahtijeva pažljivu konfiguraciju.

### Ključne točke

- **Validacija Origin zaglavlja:** Uvijek validirajte `Origin` zaglavlje kako biste spriječili DNS rebinding napade.
- **Lokalno vezivanje:** Za lokalni razvoj, vežite poslužitelje na `localhost` kako biste izbjegli izlaganje javnom internetu.
- **Autentifikacija:** Implementirajte autentifikaciju (npr. API ključeve, OAuth) za produkcijska okruženja.
- **CORS:** Konfigurirajte Cross-Origin Resource Sharing (CORS) politike za ograničavanje pristupa.
- **HTTPS:** Koristite HTTPS u produkciji za enkripciju prometa.

### Najbolje prakse

- Nikada ne vjerujte dolaznim zahtjevima bez validacije.
- Logirajte i pratite sav pristup i pogreške.
- Redovito ažurirajte ovisnosti kako biste zakrpali sigurnosne ranjivosti.

### Izazovi

- Balansiranje sigurnosti i jednostavnosti razvoja.
- Osiguravanje kompatibilnosti s različitim klijentskim okruženjima.

## Nadogradnja sa SSE-a na Streamable HTTP

Za aplikacije koje trenutno koriste Server-Sent Events (SSE), migracija na Streamable HTTP pruža poboljšane mogućnosti i bolju dugoročnu održivost za vaše MCP implementacije.

### Zašto nadograditi?
Postoje dva uvjerljiva razloga za nadogradnju s SSE na Streamable HTTP:

- Streamable HTTP nudi bolju skalabilnost, kompatibilnost i bogatiju podršku za obavijesti u usporedbi s SSE.
- Preporučeni je transport za nove MCP aplikacije.

### Koraci migracije

Evo kako možete migrirati s SSE na Streamable HTTP u svojim MCP aplikacijama:

- **Ažurirajte kod na poslužitelju** kako biste koristili `transport="streamable-http"` u `mcp.run()`.
- **Ažurirajte kod na klijentu** kako biste koristili `streamablehttp_client` umjesto SSE klijenta.
- **Implementirajte rukovatelja porukama** na klijentu za obradu obavijesti.
- **Testirajte kompatibilnost** s postojećim alatima i radnim procesima.

### Održavanje kompatibilnosti

Preporučuje se održavanje kompatibilnosti s postojećim SSE klijentima tijekom procesa migracije. Evo nekoliko strategija:

- Možete podržavati i SSE i Streamable HTTP pokretanjem oba transporta na različitim krajnjim točkama.
- Postupno migrirajte klijente na novi transport.

### Izazovi

Pobrinite se da riješite sljedeće izazove tijekom migracije:

- Osiguravanje da su svi klijenti ažurirani
- Rukovanje razlikama u isporuci obavijesti

## Sigurnosni aspekti

Sigurnost bi trebala biti glavni prioritet prilikom implementacije bilo kojeg poslužitelja, posebno kada koristite HTTP-bazirane transporte poput Streamable HTTP u MCP-u.

Prilikom implementacije MCP poslužitelja s HTTP-baziranim transportima, sigurnost postaje ključna briga koja zahtijeva pažnju na više vektora napada i mehanizama zaštite.

### Pregled

Sigurnost je ključna kada izlažete MCP poslužitelje putem HTTP-a. Streamable HTTP uvodi nove površine za napade i zahtijeva pažljivu konfiguraciju.

Evo nekoliko ključnih sigurnosnih razmatranja:

- **Validacija zaglavlja Origin**: Uvijek validirajte zaglavlje `Origin` kako biste spriječili DNS rebinding napade.
- **Veza na localhost**: Za lokalni razvoj, povežite poslužitelje na `localhost` kako biste izbjegli izlaganje javnom internetu.
- **Autentifikacija**: Implementirajte autentifikaciju (npr. API ključeve, OAuth) za produkcijska okruženja.
- **CORS**: Konfigurirajte Cross-Origin Resource Sharing (CORS) politike kako biste ograničili pristup.
- **HTTPS**: Koristite HTTPS u produkciji za enkripciju prometa.

### Najbolje prakse

Osim toga, evo nekoliko najboljih praksi koje treba slijediti prilikom implementacije sigurnosti u vašem MCP streaming poslužitelju:

- Nikada ne vjerujte dolaznim zahtjevima bez validacije.
- Bilježite i pratite sav pristup i pogreške.
- Redovito ažurirajte ovisnosti kako biste zakrpali sigurnosne ranjivosti.

### Izazovi

Suočit ćete se s nekim izazovima prilikom implementacije sigurnosti u MCP streaming poslužiteljima:

- Balansiranje sigurnosti i jednostavnosti razvoja
- Osiguravanje kompatibilnosti s različitim klijentskim okruženjima

### Zadatak: Izgradite vlastitu streaming MCP aplikaciju

**Scenarij:**
Izgradite MCP poslužitelj i klijent gdje poslužitelj obrađuje popis stavki (npr. datoteka ili dokumenata) i šalje obavijest za svaku obrađenu stavku. Klijent bi trebao prikazivati svaku obavijest čim stigne.

**Koraci:**

1. Implementirajte alat na poslužitelju koji obrađuje popis i šalje obavijesti za svaku stavku.
2. Implementirajte klijenta s rukovateljem porukama za prikaz obavijesti u stvarnom vremenu.
3. Testirajte svoju implementaciju pokretanjem i poslužitelja i klijenta te promatrajte obavijesti.

[Solution](./solution/README.md)

## Dodatno čitanje i što dalje?

Kako biste nastavili svoje putovanje s MCP streamingom i proširili svoje znanje, ovaj odjeljak pruža dodatne resurse i predložene sljedeće korake za izgradnju naprednijih aplikacija.

### Dodatno čitanje

- [Microsoft: Uvod u HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS u ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Što dalje?

- Pokušajte izgraditi naprednije MCP alate koji koriste streaming za analitiku u stvarnom vremenu, chat ili kolaborativno uređivanje.
- Istražite integraciju MCP streaminga s frontend okvirima (React, Vue, itd.) za ažuriranja korisničkog sučelja uživo.
- Sljedeće: [Korištenje AI alata za VSCode](../07-aitk/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za nesporazume ili pogrešna tumačenja koja mogu proizaći iz korištenja ovog prijevoda.