<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:15:01+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fi"
}
-->
# HTTPS-suoratoisto Model Context Protocolilla (MCP)

Tässä luvussa annetaan kattava opas turvallisen, skaalautuvan ja reaaliaikaisen suoratoiston toteuttamiseen Model Context Protocolin (MCP) avulla HTTPS:n yli. Käsitellään suoratoiston taustaa, käytettävissä olevia siirtomekanismeja, kuinka toteuttaa streamattava HTTP MCP:ssä, tietoturvakäytännöt, siirtyminen SSE:stä sekä käytännön ohjeet oman suoratoistavan MCP-sovelluksen rakentamiseen.

## Siirtomekanismit ja suoratoisto MCP:ssä

Tässä osiossa tarkastellaan MCP:ssä käytössä olevia erilaisia siirtomekanismeja ja niiden roolia suoratoisto-ominaisuuksien mahdollistamisessa reaaliaikaiseen viestintään asiakkaiden ja palvelimien välillä.

### Mikä on siirtomekanismi?

Siirtomekanismi määrittää, miten data vaihtuu asiakkaan ja palvelimen välillä. MCP tukee useita siirtotyyppejä erilaisiin ympäristöihin ja tarpeisiin:

- **stdio**: Standard input/output, sopii paikallisiin ja komentorivipohjaisiin työkaluihin. Yksinkertainen, mutta ei sovellu web- tai pilviympäristöihin.
- **SSE (Server-Sent Events)**: Mahdollistaa palvelimien työntää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli. Sopii web-käyttöliittymiin, mutta on rajoitettu skaalautuvuudessa ja joustavuudessa.
- **Streamable HTTP**: Moderni HTTP-pohjainen suoratoistosiirto, tukee ilmoituksia ja parempaa skaalautuvuutta. Suositeltava useimpiin tuotanto- ja pilvikäyttötilanteisiin.

### Vertailutaulukko

Tarkastele alla olevaa vertailutaulukkoa ymmärtääksesi näiden siirtomekanismien erot:

| Siirto            | Reaaliaikaiset päivitykset | Suoratoisto | Skaalautuvuus | Käyttötapaus             |
|-------------------|----------------------------|-------------|---------------|--------------------------|
| stdio             | Ei                         | Ei          | Matala        | Paikalliset komentorivityökalut |
| SSE               | Kyllä                      | Kyllä       | Keskitaso     | Web, reaaliaikaiset päivitykset |
| Streamable HTTP   | Kyllä                      | Kyllä       | Korkea        | Pilvi, moniasiakasympäristöt     |

> [!TIP] Oikean siirtomekanismin valinta vaikuttaa suorituskykyyn, skaalautuvuuteen ja käyttökokemukseen. **Streamable HTTP** on suositeltava moderniin, skaalautuvaan ja pilvivalmiiseen sovelluskehitykseen.

Huomaa luvun alussa esitellyt stdio- ja SSE-siirrot sekä miten tässä luvussa käsitellään streamattavaa HTTP-siirtoa.

## Suoratoisto: Perusteet ja motivaatio

Suoratoiston perusperiaatteiden ja taustalla olevien syiden ymmärtäminen on olennaista tehokkaiden reaaliaikaisten viestintäjärjestelmien toteuttamiseksi.

**Suoratoisto** on verkkosovelluksissa käytetty tekniikka, jossa dataa lähetetään ja vastaanotetaan pienissä, hallittavissa paloissa tai tapahtumasarjana sen sijaan, että odotettaisiin koko vastauksen valmistumista. Tämä on erityisen hyödyllistä:

- Suurten tiedostojen tai tietoaineistojen käsittelyssä.
- Reaaliaikaisissa päivityksissä (esim. chat, etenemispalkit).
- Pitkäkestoisissa laskutoimituksissa, joissa halutaan pitää käyttäjä ajan tasalla.

Tässä tärkeimmät asiat suoratoistosta yleisellä tasolla:

- Data toimitetaan vaiheittain, ei kerralla.
- Asiakas voi käsitellä dataa sitä mukaa kun se saapuu.
- Vähentää koettua viivettä ja parantaa käyttökokemusta.

### Miksi käyttää suoratoistoa?

Suoratoiston käyttämisen syyt ovat seuraavat:

- Käyttäjät saavat palautteen välittömästi, eivät vain lopussa
- Mahdollistaa reaaliaikaiset sovellukset ja responsiiviset käyttöliittymät
- Verkko- ja laskentaresurssien tehokkaampi hyödyntäminen

### Yksinkertainen esimerkki: HTTP-suoratoistopalvelin ja asiakas

Tässä yksinkertainen esimerkki suoratoiston toteuttamisesta:

<details>
<summary>Python</summary>

**Palvelin (Python, FastAPI ja StreamingResponse):**
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

**Asiakas (Python, requests-kirjasto):**
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

Tämä esimerkki näyttää palvelimen lähettävän sarjan viestejä asiakkaalle sitä mukaa kun ne ovat valmiita, sen sijaan että odotettaisiin kaikkien viestien valmistumista.

**Miten se toimii:**
- Palvelin tuottaa jokaisen viestin sitä mukaa kun se on valmis.
- Asiakas vastaanottaa ja tulostaa jokaisen osan sitä mukaa kun se saapuu.

**Vaatimukset:**
- Palvelimen on käytettävä suoratoistovastausta (esim. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Palvelin (Java, Spring Boot ja Server-Sent Events):**

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

**Asiakas (Java, Spring WebFlux WebClient):**

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

**Java-toteutusmuistiinpanot:**
- Käyttää Spring Bootin reaktiivista pinoa `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) verrattuna MCP:n suoratoistoon.

- **Yksinkertaisiin suoratoistotarpeisiin:** Klassinen HTTP-suoratoisto on helpompi toteuttaa ja riittää perustoimintoihin.

- **Monimutkaisiin, interaktiivisiin sovelluksiin:** MCP-suoratoisto tarjoaa rakenteellisemman lähestymistavan, jossa on rikkaampi metatieto ja erillisyys ilmoitusten ja lopullisten tulosten välillä.

- **AI-sovelluksiin:** MCP:n ilmoitusjärjestelmä on erityisen hyödyllinen pitkäkestoisissa tekoälytehtävissä, joissa halutaan pitää käyttäjät ajan tasalla edistymisestä.

## Suoratoisto MCP:ssä

Olet nähnyt tähän mennessä suosituksia ja vertailuja klassisen suoratoiston ja MCP-suoratoiston välillä. Käydään nyt tarkemmin läpi, miten voit hyödyntää suoratoistoa MCP:ssä.

MCP-kehyksen sisällä suoratoiston ymmärtäminen on tärkeää, jotta voit rakentaa responsiivisia sovelluksia, jotka tarjoavat reaaliaikaista palautetta käyttäjille pitkäkestoisten toimintojen aikana.

MCP:ssä suoratoisto ei tarkoita päävastauksen lähettämistä paloissa, vaan **ilmoitusten** lähettämistä asiakkaalle työkalun käsitellessä pyyntöä. Nämä ilmoitukset voivat sisältää etenemispäivityksiä, lokitietoja tai muita tapahtumia.

### Miten se toimii

Pääasiallinen tulos lähetetään edelleen yhtenä vastauksena. Ilmoituksia voidaan kuitenkin lähettää erillisinä viesteinä käsittelyn aikana, jolloin asiakas saa päivityksiä reaaliajassa. Asiakkaan on pystyttävä käsittelemään ja näyttämään nämä ilmoitukset.

## Mikä on ilmoitus?

Mainitsimme "ilmoituksen" – mitä se tarkoittaa MCP:n kontekstissa?

Ilmoitus on palvelimelta asiakkaalle lähetettävä viesti, joka kertoo etenemisestä, tilasta tai muista tapahtumista pitkäkestoisen operaation aikana. Ilmoitukset parantavat läpinäkyvyyttä ja käyttökokemusta.

Esimerkiksi asiakkaan odotetaan lähettävän ilmoitus, kun palvelimen kanssa on tehty alkuperäinen kättely.

Ilmoitus näyttää JSON-viestiltä seuraavasti:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Ilmoitukset kuuluvat MCP:n aiheeseen nimeltä ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Kirjautumisen toimimiseksi palvelimen on otettava se käyttöön ominaisuutena/kyvykkyytenä seuraavasti:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Käytetystä SDK:sta riippuen kirjautuminen voi olla oletuksena käytössä tai se pitää erikseen ottaa käyttöön palvelimen asetuksissa.

Ilmoituksia on useita eri tyyppejä:

| Taso      | Kuvaus                         | Esimerkkitapaus              |
|-----------|--------------------------------|-----------------------------|
| debug     | Yksityiskohtaiset virheenkorjaustiedot | Funktioiden sisään- ja ulostulopisteet |
| info      | Yleiset informatiiviset viestit | Toiminnon etenemispäivitykset |
| notice    | Normaaleja, mutta merkittäviä tapahtumia | Konfiguraatiomuutokset       |
| warning   | Varoitustilanteet               | Käytössä vanhentunut ominaisuus |
| error     | Virhetilanteet                 | Toiminnon epäonnistumiset     |
| critical  | Kriittiset tilat               | Järjestelmän komponenttien virheet |
| alert     | Toimenpiteitä vaaditaan välittömästi | Tietojen vioittuminen havaittu |
| emergency | Järjestelmä käyttökelvoton     | Täydellinen järjestelmävika  |

## Ilmoitusten toteuttaminen MCP:ssä

Ilmoitusten toteuttamiseksi MCP:ssä sinun tulee valmistella sekä palvelin- että asiakaspuoli käsittelemään reaaliaikaisia päivityksiä. Tämä mahdollistaa sovelluksesi tarjoavan välitöntä palautetta käyttäjille pitkäkestoisten toimintojen aikana.

### Palvelinpuoli: Ilmoitusten lähetys

Aloitetaan palvelinpuolelta. MCP:ssä määrittelet työkaluja, jotka voivat lähettää ilmoituksia käsitellessään pyyntöjä. Palvelin käyttää konteksti-oliota (yleensä `ctx`) viestien lähettämiseen asiakkaalle.

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

Edellisessä esimerkissä `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` -siirrossa:

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

Tässä .NET-esimerkissä `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` -metodia käytetään informatiivisten viestien lähettämiseen.

Ota ilmoitukset käyttöön .NET MCP -palvelimessasi varmistamalla, että käytät suoratoistosiirtoa:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Asiakaspuoli: Ilmoitusten vastaanotto

Asiakkaan on toteutettava viestinkäsittelijä, joka prosessoi ja näyttää ilmoitukset sitä mukaa kun ne saapuvat.

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

Edellisessä koodissa `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` vastaa saapuvien ilmoitusten käsittelystä.

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

Tässä .NET-esimerkissä `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) ja asiakkaasi toteuttaa viestinkäsittelijän ilmoitusten prosessointiin.

## Etenemisilmoitukset ja käyttötapaukset

Tässä osiossa selitetään etenemisilmoitusten käsite MCP:ssä, miksi ne ovat tärkeitä ja miten ne toteutetaan Streamable HTTP:n avulla. Löydät myös käytännön harjoituksen ymmärryksesi vahvistamiseksi.

Etenemisilmoitukset ovat reaaliaikaisia viestejä, joita palvelin lähettää asiakkaalle pitkäkestoisten toimintojen aikana. Sen sijaan, että odotettaisiin koko prosessin valmistumista, palvelin pitää asiakkaan ajan tasalla nykytilasta. Tämä parantaa läpinäkyvyyttä, käyttökokemusta ja helpottaa virheiden jäljittämistä.

**Esimerkki:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miksi käyttää etenemisilmoituksia?

Etenemisilmoitukset ovat tärkeitä monesta syystä:

- **Parempi käyttökokemus:** Käyttäjät näkevät päivitykset työn edetessä, eivät vain lopussa.
- **Reaaliaikainen palaute:** Asiakkaat voivat näyttää etenemispalkkeja tai lokeja, mikä tekee sovelluksesta responsiivisen.
- **Helpompi virheiden jäljitys ja valvonta:** Kehittäjät ja käyttäjät näkevät, missä prosessi saattaa hidastua tai jäädä jumiin.

### Miten toteuttaa etenemisilmoitukset

Näin voit toteuttaa etenemisilmoitukset MCP:ssä:

- **Palvelimella:** Käytä `ctx.info()` or `ctx.log()` lähettääksesi ilmoituksia jokaisen käsitellyn kohteen yhteydessä. Tämä lähettää viestin asiakkaalle ennen lopullisen tuloksen valmistumista.
- **Asiakkaalla:** Toteuta viestinkäsittelijä, joka kuuntelee ja näyttää ilmoitukset sitä mukaa kun ne saapuvat. Tämä käsittelijä erottaa ilmoitukset ja lopullisen tuloksen.

**Palvelinesimerkki:**

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

**Asiakkaan esimerkki:**

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

## Tietoturvaan liittyvät seikat

Kun toteutat MCP-palvelimia HTTP-pohjaisten siirtojen kanssa, tietoturva on ensiarvoisen tärkeää ja vaatii huolellista huomiointia monien hyökkäysvektorien ja suojausmekanismien osalta.

### Yleiskatsaus

Tietoturva on kriittistä MCP-palvelimien avaamisessa HTTP:n yli. Streamable HTTP tuo uusia hyökkäyspintojaja vaatii huolellista konfigurointia.

### Keskeiset kohdat
- **Origin-otsikon validointi**: Tarkista aina `Origin`-otsikko varmistaaksesi, että yhteys tulee luotetusta lähteestä.
- **HTTPS-käyttö**: Käytä aina HTTPS:ää suojataksesi tiedonsiirron.
- **Autentikointi ja valtuutus**: Varmista, että vain valtuutetut käyttäjät pääsevät käsiksi palvelimeen.
- **Pyyntöjen rajoittaminen**: Estä palvelunestohyökkäykset rajoittamalla pyyntöjen määrää ja nopeutta.
- **Turvallinen siirtomekanismi**: Käytä streamable HTTP -siirtoa SSE:n sijaan, koska se tarjoaa parempia suojausmahdollisuuksia.
- **Asiakaspuolen viestinkäsittelijä**: Toteuta viestinkäsittelijä, joka käsittelee ilmoitukset turvallisesti.
- **Yhteensopivuuden testaaminen**: Testaa yhteensopivuus olemassa olevien työkalujen ja työnkulkujen kanssa.

### Yhteensopivuuden ylläpito

On suositeltavaa säilyttää yhteensopivuus olemassa olevien SSE-asiakkaiden kanssa siirtymävaiheen ajan. Tässä muutamia strategioita:

- Voit tukea sekä SSE:tä että Streamable HTTP:ta ajamalla molempia eri päätepisteissä.
- Siirrä asiakkaita asteittain uuteen siirtomekanismiin.

### Haasteet

Varmista, että käsittelet seuraavat haasteet siirtymävaiheessa:

- Kaikkien asiakkaiden päivittäminen
- Ilmoitusten toimituserojen käsittelyerot

### Harjoitus: Rakenna oma suoratoistava MCP-sovellus

**Tilanne:**
Rakenna MCP-palvelin ja asiakas, jossa palvelin käsittelee listan kohteita (esim. tiedostoja tai dokumentteja) ja lähettää ilmoituksen jokaisen käsitellyn kohteen yhteydessä. Asiakkaan tulee näyttää jokainen ilmoitus sitä mukaa kun se saapuu.

**Vaiheet:**

1. Toteuta palvelintyökalu, joka käsittelee listan ja lähettää ilmoituksia jokaisesta kohteesta.
2. Toteuta asiakas, jossa on viestinkäsittelijä ilmoitusten reaaliaikaiseen näyttämiseen.
3. Testaa toteutuksesi ajamalla sekä palvelin että asiakas ja seuraa ilmoituksia.

[Ratkaisu](./solution/README.md)

## Lisälukemista ja seuraavat askeleet

Jatkaaksesi MCP-suoratoiston opiskelua ja laajentaaksesi osaamistasi, tässä osiossa on lisäresursseja ja ehdotuksia seuraavista askelista kehittyneempien sovellusten rakentamis

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja omalla kielellään on virallinen lähde. Tärkeissä tiedoissa suositellaan ammattimaisen ihmiskääntäjän käyttöä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.