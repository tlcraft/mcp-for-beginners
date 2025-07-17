<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T19:33:18+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sl"
}
-->
# HTTPS pretakanje s protokolom Model Context Protocol (MCP)

To poglavje ponuja celovit vodič za implementacijo varnega, razširljivega in pretočnega pretakanja v realnem času s protokolom Model Context Protocol (MCP) prek HTTPS. Obravnava motivacijo za pretakanje, razpoložljive transportne mehanizme, kako implementirati pretočni HTTP v MCP, varnostne dobre prakse, migracijo s SSE ter praktične nasvete za izdelavo lastnih pretočnih MCP aplikacij.

## Transportni mehanizmi in pretakanje v MCP

Ta razdelek raziskuje različne transportne mehanizme, ki so na voljo v MCP, in njihovo vlogo pri omogočanju pretočnih zmogljivosti za komunikacijo v realnem času med odjemalci in strežniki.

### Kaj je transportni mehanizem?

Transportni mehanizem določa, kako se podatki izmenjujejo med odjemalcem in strežnikom. MCP podpira več vrst transporta, da ustreza različnim okoljem in zahtevam:

- **stdio**: Standardni vhod/izhod, primeren za lokalna orodja in ukazno vrstico. Preprost, a neprimeren za splet ali oblak.
- **SSE (Server-Sent Events)**: Omogoča strežnikom, da prek HTTP-ja pošiljajo posodobitve v realnem času odjemalcem. Dobro za spletne uporabniške vmesnike, a omejeno glede razširljivosti in prilagodljivosti.
- **Streamable HTTP**: Sodobni pretočni transport na osnovi HTTP, ki podpira obvestila in boljšo razširljivost. Priporočeno za večino produkcijskih in oblačnih scenarijev.

### Primerjalna tabela

Oglejte si spodnjo primerjalno tabelo, da razumete razlike med temi transportnimi mehanizmi:

| Transport         | Posodobitve v realnem času | Pretakanje | Razširljivost | Uporabni primer          |
|-------------------|----------------------------|------------|---------------|-------------------------|
| stdio             | Ne                         | Ne         | Nizka         | Lokalna orodja CLI      |
| SSE               | Da                         | Da         | Srednja       | Splet, posodobitve v realnem času |
| Streamable HTTP   | Da                         | Da         | Visoka        | Oblačne, večodjemalske aplikacije |

> **Tip:** Prava izbira transporta vpliva na zmogljivost, razširljivost in uporabniško izkušnjo. **Streamable HTTP** je priporočljiv za sodobne, razširljive in oblačne aplikacije.

Opazite transporta stdio in SSE, ki ste ju spoznali v prejšnjih poglavjih, ter kako je streamable HTTP transport, obravnavan v tem poglavju.

## Pretakanje: koncepti in motivacija

Razumevanje osnovnih konceptov in motivacije za pretakanje je ključno za učinkovito implementacijo komunikacijskih sistemov v realnem času.

**Pretakanje** je tehnika v omrežnem programiranju, ki omogoča pošiljanje in prejemanje podatkov v majhnih, obvladljivih delih ali kot zaporedje dogodkov, namesto da bi čakali na celoten odgovor. To je še posebej uporabno za:

- Velike datoteke ali podatkovne nize.
- Posodobitve v realnem času (npr. klepet, prikaz napredka).
- Dolgotrajne izračune, kjer želite uporabnika sproti obveščati.

Tukaj je nekaj osnovnih dejstev o pretakanju:

- Podatki se dostavljajo postopoma, ne naenkrat.
- Odjemalec lahko podatke obdeluje sproti, ko prispejo.
- Zmanjšuje zaznano zakasnitev in izboljšuje uporabniško izkušnjo.

### Zakaj uporabljati pretakanje?

Razlogi za uporabo pretakanja so naslednji:

- Uporabniki takoj dobijo povratne informacije, ne šele na koncu.
- Omogoča aplikacije v realnem času in odzivne uporabniške vmesnike.
- Bolj učinkovita raba omrežnih in računalniških virov.

### Preprost primer: HTTP pretočni strežnik in odjemalec

Tukaj je preprost primer, kako lahko implementirate pretakanje:

## Python

**Strežnik (Python, z uporabo FastAPI in StreamingResponse):**

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


**Odjemalec (Python, z uporabo requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


Ta primer prikazuje strežnik, ki pošilja vrsto sporočil odjemalcu sproti, ko so na voljo, namesto da bi čakal, da so vsa sporočila pripravljena.

**Kako deluje:**
- Strežnik sproti pošilja vsako sporočilo, ko je pripravljeno.
- Odjemalec prejema in izpisuje vsak del, ko prispe.

**Zahteve:**
- Strežnik mora uporabljati pretočni odgovor (npr. `StreamingResponse` v FastAPI).
- Odjemalec mora obdelovati odgovor kot tok (`stream=True` v requests).
- Content-Type je običajno `text/event-stream` ali `application/octet-stream`.

## Java

**Strežnik (Java, z uporabo Spring Boot in Server-Sent Events):**

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

**Odjemalec (Java, z uporabo Spring WebFlux WebClient):**

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

**Opombe o implementaciji v Javi:**
- Uporablja reaktivni sklad Spring Boot z `Flux` za pretakanje
- `ServerSentEvent` omogoča strukturirano pretakanje dogodkov z vrstami dogodkov
- `WebClient` z `bodyToFlux()` omogoča reaktivno porabo pretoka
- `delayElements()` simulira čas obdelave med dogodki
- Dogodki lahko imajo tipe (`info`, `result`) za boljšo obdelavo na odjemalcu

### Primerjava: klasično pretakanje vs MCP pretakanje

Razlike med klasičnim pretakanjem in pretakanjem v MCP lahko prikažemo takole:

| Značilnost            | Klasično HTTP pretakanje       | MCP pretakanje (obvestila)         |
|-----------------------|-------------------------------|-----------------------------------|
| Glavni odgovor        | Razdeljen na kose (chunked)    | En sam, na koncu                  |
| Posodobitve napredka  | Pošiljane kot podatkovni kosi  | Pošiljane kot obvestila           |
| Zahteve za odjemalca  | Mora obdelovati tok            | Mora implementirati upravljalnik sporočil |
| Uporabni primer       | Velike datoteke, AI token tokovi | Napredek, dnevniki, povratne informacije v realnem času |

### Ključne opažene razlike

Poleg tega so tu nekatere ključne razlike:

- **Vzorec komunikacije:**
   - Klasično HTTP pretakanje: uporablja preprosto kodiranje prenosa v kosih za pošiljanje podatkov
   - MCP pretakanje: uporablja strukturiran sistem obvestil s protokolom JSON-RPC

- **Oblika sporočila:**
   - Klasično HTTP: navadni besedilni kosi z novimi vrsticami
   - MCP: strukturirani objekti LoggingMessageNotification z metapodatki

- **Implementacija odjemalca:**
   - Klasično HTTP: preprost odjemalec, ki obdeluje pretočne odgovore
   - MCP: bolj sofisticiran odjemalec z upravljalcem sporočil za obdelavo različnih vrst sporočil

- **Posodobitve napredka:**
   - Klasično HTTP: napredek je del glavnega toka odgovora
   - MCP: napredek se pošilja prek ločenih obvestil, medtem ko glavni odgovor pride na koncu

### Priporočila

Priporočamo nekaj stvari pri izbiri med klasičnim pretakanjem (kot smo prikazali zgoraj z `/stream`) in pretakanjem prek MCP:

- **Za preproste potrebe pretakanja:** Klasično HTTP pretakanje je lažje za implementacijo in zadostuje za osnovne potrebe pretakanja.

- **Za kompleksne, interaktivne aplikacije:** MCP pretakanje ponuja bolj strukturiran pristop z bogatejšimi metapodatki in ločitvijo med obvestili in končnimi rezultati.

- **Za AI aplikacije:** MCP-jev sistem obvestil je posebej uporaben za dolgotrajne AI naloge, kjer želite uporabnike sproti obveščati o napredku.

## Pretakanje v MCP

Torej, videli ste nekaj priporočil in primerjav o razlikah med klasičnim pretakanjem in pretakanjem v MCP. Poglejmo podrobneje, kako lahko izkoristite pretakanje v MCP.

Razumevanje, kako pretakanje deluje znotraj okvira MCP, je ključno za izdelavo odzivnih aplikacij, ki uporabnikom med dolgotrajnimi operacijami zagotavljajo povratne informacije v realnem času.

V MCP pretakanje ni pošiljanje glavnega odgovora v kosih, ampak pošiljanje **obvestil** odjemalcu medtem, ko orodje obdeluje zahtevo. Ta obvestila lahko vključujejo posodobitve napredka, dnevnike ali druge dogodke.

### Kako deluje

Glavni rezultat se še vedno pošlje kot en sam odgovor. Vendar pa se obvestila lahko pošiljajo kot ločena sporočila med obdelavo in tako sproti obveščajo odjemalca. Odjemalec mora biti sposoben obdelati in prikazati ta obvestila.

## Kaj je obvestilo?

Rekli smo "obvestilo", kaj to pomeni v kontekstu MCP?

Obvestilo je sporočilo, ki ga strežnik pošlje odjemalcu, da ga obvesti o napredku, stanju ali drugih dogodkih med dolgotrajno operacijo. Obvestila izboljšujejo preglednost in uporabniško izkušnjo.

Na primer, odjemalec naj bi poslal obvestilo, ko je bil vzpostavljen začetni stik s strežnikom.

Obvestilo izgleda takole kot JSON sporočilo:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Obvestila spadajo v temo v MCP, imenovano ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Da bi omogočili beleženje, mora strežnik to omogočiti kot funkcijo/zmožnost, kot sledi:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Glede na uporabljeni SDK je beleženje morda privzeto omogočeno ali pa ga je treba izrecno aktivirati v konfiguraciji strežnika.

Obstajajo različne vrste obvestil:

| Raven     | Opis                          | Primer uporabe               |
|-----------|-------------------------------|-----------------------------|
| debug     | Podrobne informacije za odpravljanje napak | Vhodi/izhodi funkcij        |
| info      | Splošna informativna sporočila | Posodobitve napredka        |
| notice    | Normalni, a pomembni dogodki   | Spremembe konfiguracije     |
| warning   | Opozorilna stanja             | Uporaba zastarelih funkcij  |
| error     | Napake                       | Neuspehi operacij           |
| critical  | Kritična stanja              | Napake sistemskih komponent |
| alert     | Potrebno takojšnje ukrepanje | Zaznana poškodba podatkov   |
| emergency | Sistem ni uporaben           | Popolna okvara sistema      |

## Implementacija obvestil v MCP

Za implementacijo obvestil v MCP morate nastaviti tako strežniško kot odjemalsko stran za obdelavo posodobitev v realnem času. To omogoča vaši aplikaciji, da uporabnikom med dolgotrajnimi operacijami zagotavlja takojšnje povratne informacije.

### Strežniška stran: pošiljanje obvestil

Začnimo s strežniško stranjo. V MCP definirate orodja, ki lahko med obdelavo zahtev pošiljajo obvestila. Strežnik uporablja kontekstni objekt (običajno `ctx`) za pošiljanje sporočil odjemalcu.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

V zgornjem primeru orodje `process_files` pošlje tri obvestila odjemalcu med obdelavo posamezne datoteke. Metoda `ctx.info()` se uporablja za pošiljanje informativnih sporočil.

Poleg tega, da omogočite obvestila, poskrbite, da vaš strežnik uporablja pretočni transport (kot je `streamable-http`), odjemalec pa implementira upravljalca sporočil za obdelavo obvestil. Tako lahko nastavite strežnik za uporabo transporta `streamable-http`:

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

V tem .NET primeru je orodje `ProcessFiles` označeno z atributom `Tool` in pošilja tri obvestila odjemalcu med obdelavo posamezne datoteke. Metoda `ctx.Info()` se uporablja za pošiljanje informativnih sporočil.

Da omogočite obvestila v vašem .NET MCP strežniku, poskrbite, da uporabljate pretočni transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Odjemalska stran: prejemanje obvestil

Odjemalec mora implementirati upravljalca sporočil, ki obdeluje in prikazuje obvestila, ko prispejo.

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

V zgornji kodi funkcija `message_handler` preveri, ali je dohodno sporočilo obvestilo. Če je, ga izpiše; sicer ga obdela kot običajno strežniško sporočilo. Prav tako opazite, kako je `ClientSession` inicializiran z `message_handler`, da obravnava dohodna obvestila.

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

V tem .NET primeru funkcija `MessageHandler` preveri, ali je dohodno sporočilo obvestilo. Če je, ga izpiše; sicer ga obdela kot običajno strežniško sporočilo. `ClientSession` je inicializiran z upravljalcem sporočil prek `ClientSessionOptions`.

Da omogočite obvestila, poskrbite, da vaš strežnik uporablja pretočni transport (kot je `streamable-http`) in da odjemalec implementira upravljalca sporočil za obdelavo obvestil.

## Obvestila o napredku in scenariji

Ta razdelek pojasnjuje koncept obvestil o napredku v MCP, zakaj so pomembna in kako jih implementirati z uporabo Streamable HTTP. Prav tako boste našli praktično nalogo za utrjevanje znanja.

Obvestila o napredku so sporočila v realnem času, ki jih strežnik pošilja odjemalcu med dolgotrajnimi operacijami. Namesto da bi čakali, da se celoten proces zaključi, strežnik sproti obvešča odjemalca o trenutnem stanju. To izboljšuje preglednost, uporabniško izkušnjo in olajša odpravljanje napak.

**Primer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zakaj uporabljati obvestila o napredku?

Obvestila o napredku so pomembna iz več razlogov:

- **Boljša uporabniška izkušnja:** Uporabniki vidijo posodobitve med delom, ne šele na koncu.
- **Povratne informacije v realnem času:** Odjemalci lahko prikazujejo trakove napredka ali dnevnike, kar naredi aplikacijo bolj odzivno.
- **Lažje odpravljanje napak in nadzor:** Razvijalci in uporabniki lahko vidijo, kje je proces morda počasen ali zastal.

### Kako implementirati obvestila o napredku

Tako lahko implementirate obvestila o napredku v MCP:

- **Na strežniku:** Uporabite `ctx.info()` ali `ctx.log()` za pošiljanje obvestil, ko je vsak element obdelan. To pošlje sporočilo odjemalcu pred glavnim rezultatom.
- **Na odjemalcu:** Implementirajte upravljalca sporočil, ki posluša in prikazuje obvestila, ko prispejo. Ta upravljalec razlikuje med obvestili in končnim rezultatom.

**Primer strežnika:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**Primer odjemalca:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## Varnostni vidiki

Pri implementaciji MCP strežnikov s transporti na osnovi HTTP postane varnost ključna skrb, ki zahteva skrbno obravnavo različnih napadalnih vektorjev in zaščitnih mehanizmov.

### Pregled

Varnost je ključna pri izpostavljanju MCP strežnikov prek HTTP. Streamable HTTP uvaja nove ranljivosti in zahteva skrbno konfiguracijo.

### Ključne točke
- **Preverjanje glave Origin**: Vedno preverjajte glavo `Origin`, da preprečite DNS rebinding napade.
- **Povezava na localhost**: Za lokalni razvoj povežite strežnike na `localhost`, da jih ne izpostavite javnemu internetu.
- **Avtentikacija**: Za produkcijske namestitve implementirajte avtentikacijo (npr. API ključi, OAuth).
- **CORS**: Konfigurirajte politike Cross-Origin Resource Sharing (CORS) za omejitev dostopa.
- **HTTPS**: V produkciji uporabljajte HTTPS za šifriranje prometa.

### Dobre prakse
- Nikoli ne zaupajte dohodnim zahtevam brez preverjanja.
- Beležite in spremljajte ves dostop in
### Zakaj nadgraditi?

Obstajata dva prepričljiva razloga za nadgradnjo s SSE na Streamable HTTP:

- Streamable HTTP omogoča boljšo razširljivost, združljivost in bogatejšo podporo za obvestila kot SSE.
- Je priporočeni prenos za nove MCP aplikacije.

### Koraki migracije

Tako lahko migrirate s SSE na Streamable HTTP v svojih MCP aplikacijah:

- **Posodobite strežniško kodo**, da uporabite `transport="streamable-http"` v `mcp.run()`.
- **Posodobite odjemalsko kodo**, da uporabite `streamablehttp_client` namesto SSE odjemalca.
- **Implementirajte upravljalnik sporočil** v odjemalcu za obdelavo obvestil.
- **Preizkusite združljivost** z obstoječimi orodji in delovnimi tokovi.

### Ohranjanje združljivosti

Priporočljivo je ohraniti združljivost z obstoječimi SSE odjemalci med postopkom migracije. Tukaj je nekaj strategij:

- Podpirate lahko tako SSE kot Streamable HTTP tako, da zaženete oba prenosa na različnih končnih točkah.
- Postopoma migrirajte odjemalce na novi prenos.

### Izzivi

Poskrbite, da boste med migracijo naslovili naslednje izzive:

- Zagotoviti, da so vsi odjemalci posodobljeni
- Obvladovati razlike v dostavi obvestil

## Varnostni vidiki

Varnost mora biti najvišja prioriteta pri implementaciji kateregakoli strežnika, še posebej pri uporabi HTTP-prenosov, kot je Streamable HTTP v MCP.

Pri implementaciji MCP strežnikov z HTTP-prenosi je varnost ključnega pomena in zahteva skrbno pozornost na več napadalnih vektorjev in zaščitnih mehanizmov.

### Pregled

Varnost je ključna pri izpostavljanju MCP strežnikov prek HTTP. Streamable HTTP prinaša nove ranljivosti in zahteva natančno konfiguracijo.

Tukaj so ključni varnostni vidiki:

- **Preverjanje glave Origin**: Vedno preverite glavo `Origin`, da preprečite DNS rebinding napade.
- **Povezava na localhost**: Za lokalni razvoj povežite strežnike na `localhost`, da jih ne izpostavite javnemu internetu.
- **Avtentikacija**: Za produkcijske namene implementirajte avtentikacijo (npr. API ključi, OAuth).
- **CORS**: Nastavite politike Cross-Origin Resource Sharing (CORS) za omejitev dostopa.
- **HTTPS**: V produkciji uporabljajte HTTPS za šifriranje prometa.

### Najboljše prakse

Poleg tega upoštevajte naslednje najboljše prakse pri implementaciji varnosti v vašem MCP streaming strežniku:

- Nikoli ne zaupajte dohodnim zahtevam brez preverjanja.
- Beležite in spremljajte ves dostop in napake.
- Redno posodabljajte odvisnosti, da zaprete varnostne ranljivosti.

### Izzivi

Pri implementaciji varnosti v MCP streaming strežnikih se boste soočili z nekaterimi izzivi:

- Uravnoteženje varnosti z enostavnostjo razvoja
- Zagotavljanje združljivosti z različnimi odjemalskimi okolji

### Naloga: Zgradite svojo streaming MCP aplikacijo

**Scenarij:**
Zgradite MCP strežnik in odjemalca, kjer strežnik obdela seznam elementov (npr. datotek ali dokumentov) in pošlje obvestilo za vsak obdelan element. Odjemalec naj prikaže vsako obvestilo takoj, ko prispe.

**Koraki:**

1. Implementirajte strežniško orodje, ki obdela seznam in pošlje obvestila za vsak element.
2. Implementirajte odjemalca z upravljalnikom sporočil, ki v realnem času prikazuje obvestila.
3. Preizkusite implementacijo tako, da zaženete strežnik in odjemalca ter opazujete obvestila.

[Solution](./solution/README.md)

## Nadaljnje branje in kaj sledi?

Za nadaljevanje poti z MCP streamingom in širjenje znanja ta razdelek ponuja dodatne vire in predloge za naslednje korake pri gradnji bolj naprednih aplikacij.

### Nadaljnje branje

- [Microsoft: Uvod v HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Kaj sledi?

- Poskusite zgraditi bolj napredna MCP orodja, ki uporabljajo streaming za analitiko v realnem času, klepet ali sodelovalno urejanje.
- Raziskujte integracijo MCP streaminga s frontend ogrodji (React, Vue itd.) za žive posodobitve uporabniškega vmesnika.
- Naslednje: [Uporaba AI Toolkit za VSCode](../07-aitk/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.