<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:35:27+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hr"
}
-->
# HTTPS streaming s Model Context Protocolom (MCP)

Ovo poglavlje pruža sveobuhvatan vodič za implementaciju sigurnog, skalabilnog i real-time streaminga koristeći Model Context Protocol (MCP) preko HTTPS-a. Obrađuje motivaciju za streaming, dostupne transportne mehanizme, kako implementirati streamabilni HTTP u MCP-u, najbolje sigurnosne prakse, migraciju sa SSE-a te praktične smjernice za izgradnju vlastitih streaming MCP aplikacija.

## Transportni mehanizmi i streaming u MCP-u

Ovaj odjeljak istražuje različite transportne mehanizme dostupne u MCP-u i njihovu ulogu u omogućavanju streaming funkcionalnosti za real-time komunikaciju između klijenata i servera.

### Što je transportni mehanizam?

Transportni mehanizam definira kako se podaci razmjenjuju između klijenta i servera. MCP podržava više tipova transporta kako bi odgovorio različitim okruženjima i zahtjevima:

- **stdio**: Standardni ulaz/izlaz, pogodan za lokalne i CLI alate. Jednostavan, ali nije prikladan za web ili cloud.
- **SSE (Server-Sent Events)**: Omogućuje serverima da šalju real-time ažuriranja klijentima preko HTTP-a. Dobar za web UI, ali ograničen u skalabilnosti i fleksibilnosti.
- **Streamable HTTP**: Moderni HTTP bazirani streaming transport, podržava notifikacije i bolju skalabilnost. Preporuča se za većinu produkcijskih i cloud scenarija.

### Tablica usporedbe

Pogledajte donju tablicu za razumijevanje razlika između ovih transportnih mehanizama:

| Transport         | Real-time ažuriranja | Streaming | Skalabilnost | Primjena                 |
|-------------------|---------------------|-----------|--------------|--------------------------|
| stdio             | Ne                  | Ne        | Niska        | Lokalni CLI alati         |
| SSE               | Da                  | Da        | Srednja      | Web, real-time ažuriranja|
| Streamable HTTP   | Da                  | Da        | Visoka       | Cloud, višekorisnički    |

> **Tip:** Odabir pravog transporta utječe na performanse, skalabilnost i korisničko iskustvo. **Streamable HTTP** se preporučuje za moderne, skalabilne i cloud-ready aplikacije.

Primijetite transportne mehanizme stdio i SSE koje ste vidjeli u prethodnim poglavljima te kako je streamable HTTP transport obrađen u ovom poglavlju.

## Streaming: koncepti i motivacija

Razumijevanje osnovnih koncepata i motiva iza streaminga ključno je za implementaciju učinkovitih real-time komunikacijskih sustava.

**Streaming** je tehnika u mrežnom programiranju koja omogućuje slanje i primanje podataka u malim, upravljivim dijelovima ili kao niz događaja, umjesto da se čeka da cijeli odgovor bude spreman. Ovo je posebno korisno za:

- Velike datoteke ili skupove podataka.
- Real-time ažuriranja (npr. chat, trake napretka).
- Dugotrajne izračune kod kojih želite korisnika stalno informirati.

Evo što trebate znati o streamingu na visokoj razini:

- Podaci se isporučuju postupno, ne odjednom.
- Klijent može obrađivati podatke kako pristižu.
- Smanjuje percipiranu latenciju i poboljšava korisničko iskustvo.

### Zašto koristiti streaming?

Razlozi za korištenje streaminga su sljedeći:

- Korisnici odmah dobivaju povratnu informaciju, ne samo na kraju
- Omogućava real-time aplikacije i responzivne UI-je
- Učinkovitije korištenje mrežnih i računalnih resursa

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

**Kako to funkcionira:**
- Server šalje svaku poruku čim je spremna.
- Klijent prima i ispisuje svaki dio čim stigne.

**Zahtjevi:**
- Server mora koristiti streaming response (npr. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, koristeći Spring Boot i Server-Sent Events):**

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

**Napomene za Java implementaciju:**
- Koristi Spring Boot reaktivni stack s `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) u odnosu na odabir streaminga preko MCP-a.

- **Za jednostavne potrebe streaminga:** Klasični HTTP streaming je jednostavniji za implementaciju i dovoljan za osnovne potrebe.

- **Za složene, interaktivne aplikacije:** MCP streaming nudi strukturiraniji pristup s bogatijim metapodacima i odvojenim notifikacijama i konačnim rezultatima.

- **Za AI aplikacije:** MCP-ov sustav notifikacija posebno je koristan za dugotrajne AI zadatke gdje želite korisnike držati informiranima o napretku.

## Streaming u MCP-u

Dakle, vidjeli ste neke preporuke i usporedbe do sada o razlikama između klasičnog streaminga i streaminga u MCP-u. Sada ćemo detaljno objasniti kako možete iskoristiti streaming u MCP-u.

Razumijevanje kako streaming funkcionira unutar MCP okvira ključno je za izgradnju responzivnih aplikacija koje korisnicima pružaju real-time povratne informacije tijekom dugotrajnih operacija.

U MCP-u streaming nije slanje glavnog odgovora u dijelovima, već slanje **notifikacija** klijentu dok alat obrađuje zahtjev. Te notifikacije mogu uključivati ažuriranja napretka, zapise ili druge događaje.

### Kako to funkcionira

Glavni rezultat se i dalje šalje kao jedan odgovor. Međutim, notifikacije se mogu slati kao zasebne poruke tijekom obrade te tako u realnom vremenu ažurirati klijenta. Klijent mora biti sposoban obraditi i prikazati te notifikacije.

## Što je notifikacija?

Rekli smo "notifikacija", što to znači u kontekstu MCP-a?

Notifikacija je poruka koju server šalje klijentu kako bi ga obavijestio o napretku, statusu ili drugim događajima tijekom dugotrajne operacije. Notifikacije povećavaju transparentnost i poboljšavaju korisničko iskustvo.

Na primjer, klijent bi trebao poslati notifikaciju čim se uspostavi početni handshake sa serverom.

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

Da bi logging radio, server ga mora omogućiti kao značajku/sposobnost na sljedeći način:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Ovisno o korištenom SDK-u, logging može biti omogućen po defaultu ili ga je potrebno eksplicitno uključiti u konfiguraciji servera.

Postoje različite vrste notifikacija:

| Razina    | Opis                          | Primjer upotrebe              |
|-----------|-------------------------------|------------------------------|
| debug     | Detaljne informacije za debug | Ulaz/izlaz funkcija          |
| info      | Opće informativne poruke      | Ažuriranja napretka operacije|
| notice    | Normalni, ali značajni događaji | Promjene konfiguracije       |
| warning   | Upozoravajući uvjeti          | Korištenje zastarjele funkcije|
| error     | Greške                       | Neuspjesi u operacijama      |
| critical  | Kritični uvjeti              | Kvarovi sistemskih komponenti|
| alert     | Potrebna je hitna akcija      | Otkrivena korupcija podataka |
| emergency | Sustav je neupotrebljiv       | Potpuni kvar sustava         |

## Implementacija notifikacija u MCP-u

Za implementaciju notifikacija u MCP-u potrebno je postaviti i server i klijent da obrađuju real-time ažuriranja. To omogućuje vašoj aplikaciji da korisnicima pruži trenutne povratne informacije tijekom dugotrajnih operacija.

### Server-side: slanje notifikacija

Počnimo sa serverom. U MCP-u definirate alate koji mogu slati notifikacije tijekom obrade zahtjeva. Server koristi context objekt (obično `ctx`) za slanje poruka klijentu.

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

U ovom .NET primjeru, metoda `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` koristi se za slanje informativnih poruka.

Da biste omogućili notifikacije u vašem .NET MCP serveru, provjerite koristite li streaming transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Client-side: primanje notifikacija

Klijent mora implementirati handler poruka za obradu i prikaz notifikacija čim stignu.

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

U prethodnom kodu, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` obrađuje dolazne notifikacije.

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

U ovom .NET primjeru, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) i vaš klijent implementira handler za obradu notifikacija.

## Notifikacije napretka i scenariji

Ovaj odjeljak objašnjava koncept notifikacija napretka u MCP-u, zašto su važne i kako ih implementirati koristeći Streamable HTTP. Također sadrži praktični zadatak za utvrđivanje znanja.

Notifikacije napretka su real-time poruke koje server šalje klijentu tijekom dugotrajnih operacija. Umjesto da se čeka da cijeli proces završi, server stalno obavještava klijenta o trenutnom statusu. To poboljšava transparentnost, korisničko iskustvo i olakšava debugiranje.

**Primjer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zašto koristiti notifikacije napretka?

Notifikacije napretka su važne iz nekoliko razloga:

- **Bolje korisničko iskustvo:** Korisnici vide ažuriranja tijekom rada, ne samo na kraju.
- **Real-time povratna informacija:** Klijenti mogu prikazivati trake napretka ili zapise, što aplikaciju čini responzivnijom.
- **Jednostavnije debugiranje i nadzor:** Programeri i korisnici mogu vidjeti gdje proces može biti spor ili zapeti.

### Kako implementirati notifikacije napretka

Evo kako možete implementirati notifikacije napretka u MCP-u:

- **Na serveru:** Koristite `ctx.info()` or `ctx.log()` za slanje notifikacija dok se svaki element obrađuje. To šalje poruku klijentu prije nego što glavni rezultat bude spreman.
- **Na klijentu:** Implementirajte handler poruka koji sluša i prikazuje notifikacije čim stignu. Ovaj handler razlikuje notifikacije i konačni rezultat.

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

Prilikom implementacije MCP servera s HTTP baziranim transportima, sigurnost postaje ključni aspekt koji zahtijeva pažnju prema različitim vrstama napada i zaštitnim mehanizmima.

### Pregled

Sigurnost je presudna pri izlaganju MCP servera preko HTTP-a. Streamable HTTP uvodi nove površine za napad i zahtijeva pažljivu konfiguraciju.

### Ključne točke
- **Validacija Origin zaglavlja**: Uvijek provjeravajte `Origin` zaglavlje kako biste spriječili neovlašteni pristup.
- **Koristite HTTPS** za enkripciju podataka u prijenosu.
- **Autentikacija i autorizacija** moraju biti pravilno postavljene.
- **Ograničite pristup** samo na pouzdane klijente i domene.
- **Redovito pratite i ažurirajte** server i njegove komponente.

### Održavanje kompatibilnosti

Preporučuje se održavati kompatibilnost s postojećim SSE klijentima tijekom procesa migracije. Evo nekoliko strategija:

- Možete podržavati i SSE i Streamable HTTP pokretanjem oba transporta na različitim endpointima.
- Postupno migrirajte klijente na novi transport.

### Izazovi

Tijekom migracije obratite pažnju na sljedeće izazove:

- Osigurati da su svi klijenti ažurirani
- Rukovanje razlikama u isporuci notifikacija

### Zadatak: Izgradite vlastitu streaming MCP aplikaciju

**Scenarij:**
Izradite MCP server i klijenta gdje server obrađuje listu stavki (npr. datoteke ili dokumente) i šalje notifikaciju za svaku obrađenu stavku. Klijent treba prikazivati svaku notifikaciju čim stigne.

**Koraci:**

1. Implementirajte server alat koji obrađuje listu i šalje notifikacije za svaku stavku.
2. Implementirajte klijenta s handlerom poruka koji prikazuje notifikacije u realnom vremenu.
3. Testirajte implementaciju pokretanjem servera i klijenta te promatrajte notifikacije.

[Solution](./solution/README.md)

## Dodatna literatura i što dalje?

Za nastavak učenja o MCP streamingu i širenje znanja, ovaj odjeljak pruža dodatne izvore i prijedloge za daljnje korake u izgradnji naprednijih aplikacija.

### Dodatna literatura

- [Microsoft: Uvod u HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS u ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Što dalje?

- Pokušajte izgraditi naprednije MCP alate koji koriste streaming za real-time analitiku, chat ili kolaborativno uređivanje.
- Istražite integraciju MCP streaminga s frontend frameworkima (React, Vue, itd.) za live UI ažuriranja.
- Sljedeće: [Korištenje AI Toolkit-a za VSCode](../07-aitk/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.