<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T18:52:16+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fi"
}
-->
# HTTPS-suoratoisto Model Context Protocolilla (MCP)

Tässä luvussa annetaan kattava opas turvallisen, skaalautuvan ja reaaliaikaisen suoratoiston toteuttamiseen Model Context Protocolin (MCP) avulla HTTPS:n yli. Käsitellään suoratoiston taustaa, käytettävissä olevia siirtomekanismeja, suoratoistettavan HTTP:n toteutusta MCP:ssä, turvallisuusohjeita, siirtymistä SSE:stä sekä käytännön ohjeita omien suoratoistavien MCP-sovellusten rakentamiseen.

## Siirtomekanismit ja suoratoisto MCP:ssä

Tässä osiossa tarkastellaan MCP:ssä käytettävissä olevia erilaisia siirtomekanismeja ja niiden roolia suoratoistomahdollisuuksien tarjoamisessa reaaliaikaiseen viestintään asiakkaiden ja palvelimien välillä.

### Mikä on siirtomekanismi?

Siirtomekanismi määrittelee, miten data vaihdetaan asiakkaan ja palvelimen välillä. MCP tukee useita siirtotyyppejä eri ympäristöihin ja tarpeisiin:

- **stdio**: Standardi sisääntulo/uloskäynti, sopii paikallisiin ja komentorivipohjaisiin työkaluihin. Yksinkertainen, mutta ei sovellu web- tai pilviympäristöihin.
- **SSE (Server-Sent Events)**: Mahdollistaa palvelimien työntää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli. Hyvä web-käyttöliittymiin, mutta rajallinen skaalautuvuuden ja joustavuuden suhteen.
- **Streamable HTTP**: Moderni HTTP-pohjainen suoratoistomekanismi, tukee ilmoituksia ja parempaa skaalautuvuutta. Suositeltu useimpiin tuotanto- ja pilvitilanteisiin.

### Vertailutaulukko

Tarkastele alla olevaa vertailutaulukkoa ymmärtääksesi näiden siirtomekanismien erot:

| Siirtomekanismi   | Reaaliaikaiset päivitykset | Suoratoisto | Skaalautuvuus | Käyttötarkoitus          |
|-------------------|----------------------------|-------------|---------------|-------------------------|
| stdio             | Ei                         | Ei          | Matala        | Paikalliset CLI-työkalut|
| SSE               | Kyllä                      | Kyllä       | Keskitaso     | Web, reaaliaikaiset päivitykset |
| Streamable HTTP   | Kyllä                      | Kyllä       | Korkea        | Pilvi, moniasiakasympäristöt |

> **Vinkki:** Oikean siirtomekanismin valinta vaikuttaa suorituskykyyn, skaalautuvuuteen ja käyttökokemukseen. **Streamable HTTP** on suositeltava moderniin, skaalautuvaan ja pilviyhteensopivaan sovellukseen.

Huomaa aiemmissa luvuissa esitellyt stdio- ja SSE-siirtomekanismit sekä tässä luvussa käsitelty streamable HTTP.

## Suoratoisto: käsitteet ja tausta

Suoratoiston peruskäsitteiden ja taustojen ymmärtäminen on olennaista tehokkaiden reaaliaikaisten viestintäjärjestelmien toteuttamiseksi.

**Suoratoisto** on verkkosovelluksissa käytetty tekniikka, jossa dataa lähetetään ja vastaanotetaan pieninä, hallittavina paloina tai tapahtumasarjana sen sijaan, että odotettaisiin koko vastauksen valmistumista. Tämä on erityisen hyödyllistä:

- Suurten tiedostojen tai tietoaineistojen käsittelyssä.
- Reaaliaikaisissa päivityksissä (esim. chat, etenemispalkit).
- Pitkään kestävissä laskutoimituksissa, joissa halutaan pitää käyttäjä ajan tasalla.

Tässä tärkeimmät asiat suoratoistosta yleisellä tasolla:

- Data toimitetaan vaiheittain, ei kerralla.
- Asiakas voi käsitellä dataa sitä mukaa kun se saapuu.
- Vähentää koettua viivettä ja parantaa käyttökokemusta.

### Miksi käyttää suoratoistoa?

Suoratoiston käyttämisen syyt ovat seuraavat:

- Käyttäjät saavat palautetta heti, eivät vain lopussa.
- Mahdollistaa reaaliaikaiset sovellukset ja responsiiviset käyttöliittymät.
- Tehokkaampi verkon ja laskentaresurssien käyttö.

### Yksinkertainen esimerkki: HTTP-suoratoistopalvelin ja asiakas

Tässä yksinkertainen esimerkki suoratoiston toteutuksesta:

## Python

**Palvelin (Python, FastAPI ja StreamingResponse):**

### Python

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


**Asiakas (Python, requests-kirjasto):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


Tämä esimerkki näyttää palvelimen lähettävän sarjan viestejä asiakkaalle sitä mukaa kun ne valmistuvat, sen sijaan että odotettaisiin kaikkien viestien valmistumista.

**Miten se toimii:**
- Palvelin tuottaa jokaisen viestin heti kun se on valmis.
- Asiakas vastaanottaa ja tulostaa jokaisen osan sitä mukaa kun se saapuu.

**Vaatimukset:**
- Palvelimen tulee käyttää suoratoistovastausta (esim. `StreamingResponse` FastAPI:ssa).
- Asiakkaan tulee käsitellä vastaus suoratoistona (`stream=True` requests-kirjastossa).
- Content-Type on yleensä `text/event-stream` tai `application/octet-stream`.

## Java

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

**Java-toteutuksen huomioita:**
- Käyttää Spring Bootin reaktiivista pinoa `Flux`-suoratoistoon
- `ServerSentEvent` tarjoaa rakenteellisen tapahtumasuoratoiston tapahtumatyypeillä
- `WebClient` ja `bodyToFlux()` mahdollistavat reaktiivisen suoratoiston kulutuksen
- `delayElements()` simuloi käsittelyaikaa tapahtumien välillä
- Tapahtumilla voi olla tyyppejä (`info`, `result`) paremman asiakashallinnan vuoksi


### Vertailu: Klassinen suoratoisto vs MCP-suoratoisto

Seuraavassa taulukossa kuvataan eroavaisuuksia klassisen suoratoiston ja MCP-suoratoiston välillä:

| Ominaisuus             | Klassinen HTTP-suoratoisto     | MCP-suoratoisto (Ilmoitukset)    |
|------------------------|-------------------------------|----------------------------------|
| Päävastaus             | Palasina                      | Yksi, lopussa                    |
| Etenemispäivitykset    | Lähetetään datapalasina       | Lähetetään ilmoituksina          |
| Asiakasvaatimukset     | Pitää käsitellä suoratoisto   | Pitää toteuttaa viestinkäsittelijä |
| Käyttötarkoitus        | Suuret tiedostot, AI-tokenvirrat | Eteneminen, lokit, reaaliaikainen palaute |

### Keskeiset erot

Lisäksi tässä muutamia keskeisiä eroja:

- **Viestintämalli:**
   - Klassinen HTTP-suoratoisto: Käyttää yksinkertaista palasiensiirtokoodausta datan lähettämiseen paloissa
   - MCP-suoratoisto: Käyttää rakenteellista ilmoitusjärjestelmää JSON-RPC-protokollalla

- **Viestimuoto:**
   - Klassinen HTTP: Pelkät tekstipalat rivinvaihtoineen
   - MCP: Rakenteelliset LoggingMessageNotification-objektit metatiedoilla

- **Asiakkaan toteutus:**
   - Klassinen HTTP: Yksinkertainen asiakas, joka käsittelee suoratoistovastauksia
   - MCP: Kehittyneempi asiakas, jossa viestinkäsittelijä eri viestityyppien käsittelyyn

- **Etenemispäivitykset:**
   - Klassinen HTTP: Eteneminen on osa päävastausta
   - MCP: Eteneminen lähetetään erillisinä ilmoitusviesteinä, päävastaus tulee lopussa

### Suositukset

Suosittelemme seuraavaa valintaa klassisen suoratoiston (kuten yllä esitetty `/stream`-päätepiste) ja MCP-suoratoiston välillä:

- **Yksinkertaisiin suoratoistotarpeisiin:** Klassinen HTTP-suoratoisto on helpompi toteuttaa ja riittää perustoimintoihin.

- **Monimutkaisiin, interaktiivisiin sovelluksiin:** MCP-suoratoisto tarjoaa rakenteellisemman lähestymistavan, jossa on rikkaammat metatiedot ja ilmoitusten sekä lopputulosten erottelu.

- **AI-sovelluksiin:** MCP:n ilmoitusjärjestelmä on erityisen hyödyllinen pitkään kestävissä AI-tehtävissä, joissa halutaan pitää käyttäjät ajan tasalla etenemisestä.

## Suoratoisto MCP:ssä

Olet nähnyt suosituksia ja vertailuja klassisen suoratoiston ja MCP-suoratoiston eroista. Käydään nyt tarkemmin läpi, miten suoratoistoa voi hyödyntää MCP:ssä.

MCP-kehyksessä suoratoisto ei tarkoita päävastauksen lähettämistä paloissa, vaan **ilmoitusten** lähettämistä asiakkaalle työkalun käsitellessä pyyntöä. Nämä ilmoitukset voivat sisältää etenemispäivityksiä, lokeja tai muita tapahtumia.

### Miten se toimii

Pääasiallinen tulos lähetetään edelleen yhtenä vastauksena. Ilmoituksia voidaan kuitenkin lähettää erillisinä viesteinä käsittelyn aikana, jolloin asiakas saa päivityksiä reaaliajassa. Asiakkaan tulee osata käsitellä ja näyttää nämä ilmoitukset.

## Mikä on ilmoitus?

Mainitsimme "ilmoituksen" – mitä se tarkoittaa MCP:n yhteydessä?

Ilmoitus on palvelimen lähettämä viesti asiakkaalle, joka kertoo etenemisestä, tilasta tai muista tapahtumista pitkään kestävän operaation aikana. Ilmoitukset parantavat läpinäkyvyyttä ja käyttökokemusta.

Esimerkiksi asiakas lähettää ilmoituksen heti, kun alkuperäinen yhteyden muodostus palvelimeen on tehty.

Ilmoitus näyttää JSON-viestinä tältä:

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

Lokituksen toimimiseksi palvelimen tulee ottaa se käyttöön ominaisuutena/kyvykkyytenä seuraavasti:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Käytetystä SDK:sta riippuen lokitus voi olla oletuksena päällä tai se täytyy erikseen ottaa käyttöön palvelimen asetuksissa.

Ilmoituksia on eri tyyppejä:

| Taso       | Kuvaus                        | Esimerkkikäyttö                |
|------------|------------------------------|-------------------------------|
| debug      | Yksityiskohtaiset debug-tiedot| Funktioiden sisään-/uloskäynnit|
| info       | Yleiset informatiiviset viestit| Toiminnon etenemispäivitykset |
| notice     | Normaaleja mutta merkittäviä tapahtumia | Konfiguraatiomuutokset        |
| warning    | Varoitustilanteet             | Käytössä vanhentunut ominaisuus|
| error      | Virhetilanteet               | Toiminnon epäonnistumiset      |
| critical   | Kriittiset tilanteet          | Järjestelmäkomponenttien viat |
| alert      | Toimintaa vaaditaan välittömästi | Tietojen korruptio havaittu  |
| emergency  | Järjestelmä käyttökelvoton    | Täydellinen järjestelmävika   |

## Ilmoitusten toteutus MCP:ssä

Ilmoitusten toteuttamiseksi MCP:ssä sinun tulee määrittää sekä palvelin- että asiakaspuolet käsittelemään reaaliaikaisia päivityksiä. Näin sovelluksesi voi antaa välitöntä palautetta käyttäjille pitkien operaatioiden aikana.

### Palvelinpuoli: Ilmoitusten lähettäminen

Aloitetaan palvelinpuolelta. MCP:ssä määrittelet työkaluja, jotka voivat lähettää ilmoituksia pyyntöjen käsittelyn aikana. Palvelin käyttää konteksti-oliota (yleensä `ctx`) viestien lähettämiseen asiakkaalle.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Edellisessä esimerkissä `process_files`-työkalu lähettää kolme ilmoitusta asiakkaalle käsitellessään kutakin tiedostoa. `ctx.info()`-metodia käytetään informatiivisten viestien lähettämiseen.

Lisäksi ilmoitusten käyttöönottoon varmista, että palvelimesi käyttää suoratoistosiirtoa (kuten `streamable-http`) ja asiakkaasi toteuttaa viestinkäsittelijän ilmoitusten vastaanottoon. Näin voit määrittää palvelimen käyttämään `streamable-http`-siirtoa:

```python
mcp.run(transport="streamable-http")
```

### .NET

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

Tässä .NET-esimerkissä `ProcessFiles`-työkalu on merkitty `Tool`-attribuutilla ja lähettää kolme ilmoitusta asiakkaalle käsitellessään tiedostoja. `ctx.Info()`-metodia käytetään informatiivisten viestien lähettämiseen.

Ilmoitusten käyttöönottoon .NET MCP-palvelimessa varmista, että käytät suoratoistosiirtoa:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Asiakaspuoli: Ilmoitusten vastaanotto

Asiakkaan tulee toteuttaa viestinkäsittelijä, joka käsittelee ja näyttää ilmoitukset sitä mukaa kun ne saapuvat.

### Python

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

Edellisessä koodissa `message_handler`-funktio tarkistaa, onko saapuva viesti ilmoitus. Jos on, se tulostaa ilmoituksen; muuten käsittelee sen tavallisena palvelinviestinä. Huomaa myös, miten `ClientSession` alustetaan `message_handler`-parametrilla ilmoitusten käsittelyä varten.

### .NET

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

Tässä .NET-esimerkissä `MessageHandler`-funktio tarkistaa, onko saapuva viesti ilmoitus. Jos on, se tulostaa ilmoituksen; muuten käsittelee sen tavallisena palvelinviestinä. `ClientSession` alustetaan viestinkäsittelijällä `ClientSessionOptions`-parametrin kautta.

Ilmoitusten käyttöönottoon varmista, että palvelimesi käyttää suoratoistosiirtoa (kuten `streamable-http`) ja asiakkaasi toteuttaa viestinkäsittelijän ilmoitusten vastaanottoon.

## Etenemisilmoitukset ja käyttötapaukset

Tässä osiossa selitetään etenemisilmoitusten käsite MCP:ssä, miksi ne ovat tärkeitä ja miten ne toteutetaan Streamable HTTP:n avulla. Löydät myös käytännön harjoituksen ymmärryksen vahvistamiseksi.

Etenemisilmoitukset ovat reaaliaikaisia viestejä, joita palvelin lähettää asiakkaalle pitkien operaatioiden aikana. Sen sijaan, että odotettaisiin koko prosessin valmistumista, palvelin pitää asiakkaan ajan tasalla nykytilasta. Tämä parantaa läpinäkyvyyttä, käyttökokemusta ja helpottaa virheiden jäljittämistä.

**Esimerkki:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miksi käyttää etenemisilmoituksia?

Etenemisilmoitukset ovat tärkeitä monesta syystä:

- **Parempi käyttökokemus:** Käyttäjät näkevät päivityksiä työn edetessä, eivät vain lopussa.
- **Reaaliaikainen palaute:** Asiakkaat voivat näyttää etenemispalkkeja tai lokeja, mikä tekee sovelluksesta responsiivisen.
- **Helpompi virheiden jäljitys ja valvonta:** Kehittäjät ja käyttäjät näkevät, missä vaiheessa prosessi saattaa hidastua tai jumittua.

### Miten toteuttaa etenemisilmoitukset

Näin voit toteuttaa etenemisilmoitukset MCP:ssä:

- **Palvelimella:** Käytä `ctx.info()` tai `ctx.log()` lähettääksesi ilmoituksia sitä mukaa kun kukin kohde käsitellään. Tämä lähettää viestin asiakkaalle ennen päävastauksen valmistumista.
- **Asiakkaalla:** Toteuta viestinkäsittelijä, joka kuuntelee ja näyttää ilmoitukset sitä mukaa kun ne saapuvat. Tämä käsittelijä erottaa ilmoitukset ja lopullisen tuloksen.

**Palvelinesimerkki:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**Asiakas-esimerkki:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## Turvallisuusnäkökohdat

Kun toteutat MCP-palvelimia HTTP-pohjaisilla siirroilla, turvallisuus on ensisijaisen tärkeää ja vaatii huolellista huomiointia moniin hyökkäysvektoreihin ja suojamekanismeihin.

### Yleiskatsaus

Turvallisuus on kriittistä, kun MCP-palvelimet ovat saatavilla HTTP:n yli. Streamable HTTP tuo uusia hyökkäyspintoja ja vaatii huolellista konfigurointia.

### Keskeiset kohdat
- **Origin-headerin validointi:** Tarkista aina `Origin`-header estääksesi DNS-rebinding-hyökkäykset.
- **Localhost-sidonta:** Paikallisessa kehityksessä sido palvelimet `localhost`-osoitteeseen, jotta niitä ei altisteta julkiselle internetille.
- **Autentikointi:** Toteuta autentik
### Miksi päivittää?

SSE:stä Streamable HTTP:hen päivittämiselle on kaksi vahvaa syytä:

- Streamable HTTP tarjoaa paremman skaalautuvuuden, yhteensopivuuden ja monipuolisemman ilmoitustuen kuin SSE.
- Se on suositeltu siirtotapa uusille MCP-sovelluksille.

### Siirtymävaiheet

Näin voit siirtyä SSE:stä Streamable HTTP:hen MCP-sovelluksissasi:

- **Päivitä palvelinkoodi** käyttämään `transport="streamable-http"` `mcp.run()`-kutsussa.
- **Päivitä asiakaskoodi** käyttämään `streamablehttp_client` SSE-asiakkaan sijaan.
- **Toteuta viestinkäsittelijä** asiakkaaseen ilmoitusten käsittelyä varten.
- **Testaa yhteensopivuus** olemassa olevien työkalujen ja työnkulkujen kanssa.

### Yhteensopivuuden ylläpito

On suositeltavaa säilyttää yhteensopivuus olemassa olevien SSE-asiakkaiden kanssa siirtymävaiheen aikana. Tässä muutamia keinoja:

- Voit tukea sekä SSE:tä että Streamable HTTP:ta ajamalla molempia siirtotapoja eri päätepisteissä.
- Siirrä asiakkaita vähitellen uuteen siirtotapaan.

### Haasteet

Varmista, että otat huomioon seuraavat haasteet siirtymän aikana:

- Kaikkien asiakkaiden päivittäminen
- Ilmoitusten toimituserojen käsittely

## Turvallisuusnäkökohdat

Turvallisuus on ensisijaisen tärkeää minkä tahansa palvelimen toteutuksessa, erityisesti HTTP-pohjaisia siirtotapoja kuten Streamable HTTP MCP:ssä käytettäessä.

MCP-palvelimia toteutettaessa HTTP-pohjaisilla siirtotavoilla turvallisuus vaatii huolellista huomiota moniin hyökkäysvektoreihin ja suojausmekanismeihin.

### Yleiskatsaus

Turvallisuus on kriittistä, kun MCP-palvelimet altistetaan HTTP:n kautta. Streamable HTTP tuo mukanaan uusia hyökkäyspintoja ja vaatii tarkkaa konfigurointia.

Tässä keskeisiä turvallisuusnäkökohtia:

- **Origin-otsikon validointi**: Tarkista aina `Origin`-otsikko DNS-rebinding-hyökkäysten estämiseksi.
- **Localhost-sidonta**: Paikallisessa kehityksessä sido palvelimet `localhost`-osoitteeseen, jotta niitä ei altisteta julkiselle internetille.
- **Autentikointi**: Toteuta autentikointi (esim. API-avaimet, OAuth) tuotantoympäristössä.
- **CORS**: Määritä Cross-Origin Resource Sharing (CORS) -käytännöt pääsyn rajoittamiseksi.
- **HTTPS**: Käytä HTTPS:ää tuotannossa liikenteen salaamiseksi.

### Parhaat käytännöt

Lisäksi tässä muutamia parhaita käytäntöjä MCP-streamauspalvelimen turvallisuuden toteuttamiseen:

- Älä koskaan luota saapuviin pyyntöihin ilman validointia.
- Kirjaa ja valvo kaikki pääsyt ja virheet.
- Päivitä riippuvuudet säännöllisesti tietoturvahaavoittuvuuksien korjaamiseksi.

### Haasteet

Turvallisuuden toteuttamisessa MCP-streamauspalvelimissa kohtaat seuraavia haasteita:

- Turvallisuuden ja kehityksen helppouden tasapainottaminen
- Yhteensopivuuden varmistaminen eri asiakasympäristöjen kanssa

### Tehtävä: Rakenna oma streamaava MCP-sovellus

**Tilanne:**
Rakenna MCP-palvelin ja -asiakas, jossa palvelin käsittelee listan kohteita (esim. tiedostoja tai dokumentteja) ja lähettää ilmoituksen jokaisesta käsitellystä kohteesta. Asiakkaan tulee näyttää ilmoitukset reaaliajassa niiden saapuessa.

**Vaiheet:**

1. Toteuta palvelintyökalu, joka käsittelee listan ja lähettää ilmoitukset jokaisesta kohteesta.
2. Toteuta asiakas, jossa on viestinkäsittelijä ilmoitusten reaaliaikaista näyttämistä varten.
3. Testaa toteutuksesi ajamalla sekä palvelin että asiakas ja seuraa ilmoituksia.

[Solution](./solution/README.md)

## Lisälukemista & Mitä seuraavaksi?

Jatka MCP-streamauksen opettelua ja laajenna osaamistasi tämän osion tarjoamien lisäresurssien ja ehdotettujen seuraavien askelten avulla kehittyneempien sovellusten rakentamiseksi.

### Lisälukemista

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Mitä seuraavaksi?

- Kokeile rakentaa kehittyneempiä MCP-työkaluja, jotka käyttävät streamausta reaaliaikaiseen analytiikkaan, chattiin tai yhteismuokkaukseen.
- Tutustu MCP-streamauksen integrointiin frontend-kehyksiin (React, Vue jne.) live-käyttöliittymäpäivityksiä varten.
- Seuraavaksi: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.