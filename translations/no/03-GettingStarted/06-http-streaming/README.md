<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:43:32+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "no"
}
-->
# HTTPS-strømming med Model Context Protocol (MCP)

Dette kapitlet gir en grundig veiledning for å implementere sikker, skalerbar og sanntidsstrømming med Model Context Protocol (MCP) ved bruk av HTTPS. Det dekker motivasjonen for strømming, tilgjengelige transportmekanismer, hvordan man implementerer strømmbar HTTP i MCP, sikkerhetsanbefalinger, migrering fra SSE, og praktiske råd for å bygge egne strømmende MCP-applikasjoner.

## Transportmekanismer og strømming i MCP

Denne seksjonen utforsker de ulike transportmekanismene som er tilgjengelige i MCP og deres rolle i å muliggjøre strømming for sanntidskommunikasjon mellom klienter og servere.

### Hva er en transportmekanisme?

En transportmekanisme definerer hvordan data utveksles mellom klient og server. MCP støtter flere transporttyper for å passe ulike miljøer og behov:

- **stdio**: Standard input/output, egnet for lokale og CLI-baserte verktøy. Enkelt, men ikke egnet for web eller sky.
- **SSE (Server-Sent Events)**: Lar servere sende sanntidsoppdateringer til klienter over HTTP. Bra for webgrensesnitt, men begrenset i skalerbarhet og fleksibilitet.
- **Strømmbar HTTP**: Moderne HTTP-basert strømming, støtter varsler og bedre skalerbarhet. Anbefales for de fleste produksjons- og sky-scenarier.

### Sammenligningstabell

Se på sammenligningstabellen nedenfor for å forstå forskjellene mellom disse transportmekanismene:

| Transport         | Sanntidsoppdateringer | Strømming | Skalerbarhet | Bruksområde             |
|-------------------|-----------------------|-----------|--------------|------------------------|
| stdio             | Nei                   | Nei       | Lav          | Lokale CLI-verktøy     |
| SSE               | Ja                    | Ja        | Middels      | Web, sanntidsoppdateringer |
| Strømmbar HTTP    | Ja                    | Ja        | Høy          | Sky, multi-klient      |

> **Tip:** Valg av riktig transport påvirker ytelse, skalerbarhet og brukeropplevelse. **Strømmbar HTTP** anbefales for moderne, skalerbare og sky-klare applikasjoner.

Merk transportene stdio og SSE som du ble vist i tidligere kapitler, og hvordan strømmbar HTTP er transporten som dekkes i dette kapitlet.

## Strømming: Konsepter og motivasjon

Å forstå de grunnleggende konseptene og motivasjonene bak strømming er essensielt for å implementere effektive sanntidskommunikasjonssystemer.

**Strømming** er en teknikk i nettverksprogrammering som gjør det mulig å sende og motta data i små, håndterbare biter eller som en sekvens av hendelser, i stedet for å vente på at hele svaret skal være klart. Dette er spesielt nyttig for:

- Store filer eller datasett.
- Sanntidsoppdateringer (f.eks. chat, fremdriftsindikatorer).
- Langvarige beregninger hvor man ønsker å holde brukeren informert.

Her er det viktigste du bør vite om strømming på et overordnet nivå:

- Data leveres gradvis, ikke alt på en gang.
- Klienten kan behandle data etter hvert som det kommer.
- Reduserer opplevd ventetid og forbedrer brukeropplevelsen.

### Hvorfor bruke strømming?

Årsakene til å bruke strømming er følgende:

- Brukere får umiddelbar tilbakemelding, ikke bare til slutt.
- Muliggjør sanntidsapplikasjoner og responsive brukergrensesnitt.
- Mer effektiv bruk av nettverks- og datakraftressurser.

### Enkelt eksempel: HTTP-strømmingsserver og klient

Her er et enkelt eksempel på hvordan strømming kan implementeres:

<details>
<summary>Python</summary>

**Server (Python, bruker FastAPI og StreamingResponse):**
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

**Klient (Python, bruker requests):**
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

Dette eksempelet viser en server som sender en serie meldinger til klienten etter hvert som de blir tilgjengelige, i stedet for å vente på at alle meldinger skal være klare.

**Slik fungerer det:**
- Serveren sender hver melding etter hvert som den er klar.
- Klienten mottar og skriver ut hver del så snart den kommer.

**Krav:**
- Serveren må bruke en strømmende respons (f.eks. `StreamingResponse` i FastAPI).
- Klienten må behandle responsen som en strøm (`stream=True` i requests).
- Content-Type er vanligvis `text/event-stream` eller `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, bruker Spring Boot og Server-Sent Events):**

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

**Klient (Java, bruker Spring WebFlux WebClient):**

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

**Notater om Java-implementasjon:**
- Bruker Spring Boots reaktive stack med `Flux` for strømming
- `ServerSentEvent` gir strukturert hendelsesstrømming med hendelsestyper
- `WebClient` med `bodyToFlux()` muliggjør reaktiv strømmingskonsumering
- `delayElements()` simulerer behandlingstid mellom hendelser
- Hendelser kan ha typer (`info`, `result`) for bedre klienthåndtering

</details>

### Sammenligning: Klassisk strømming vs MCP-strømming

Forskjellene mellom hvordan strømming fungerer på en "klassisk" måte versus i MCP kan illustreres slik:

| Funksjon               | Klassisk HTTP-strømming        | MCP-strømming (Varsler)          |
|------------------------|-------------------------------|---------------------------------|
| Hovedrespons            | Delvis (chunked)               | Enkel, til slutt                |
| Fremdriftsoppdateringer | Sendt som datadeler            | Sendt som varsler               |
| Klientkrav             | Må behandle strømmen           | Må implementere meldingshåndterer |
| Bruksområde            | Store filer, AI token-strømmer | Fremdrift, logger, sanntidsfeedback |

### Viktige observerte forskjeller

I tillegg er det noen nøkkelforskjeller:

- **Kommunikasjonsmønster:**
   - Klassisk HTTP-strømming: Bruker enkel chunked transfer encoding for å sende data i biter
   - MCP-strømming: Bruker et strukturert varslingssystem med JSON-RPC-protokoll

- **Meldingsformat:**
   - Klassisk HTTP: Ren tekst med linjeskift
   - MCP: Strukturerte LoggingMessageNotification-objekter med metadata

- **Klientimplementasjon:**
   - Klassisk HTTP: Enkel klient som behandler strømmende responser
   - MCP: Mer avansert klient med meldingshåndterer for å behandle ulike meldingstyper

- **Fremdriftsoppdateringer:**
   - Klassisk HTTP: Fremdrift er en del av hovedstrømmen
   - MCP: Fremdrift sendes via separate varslingsmeldinger mens hovedresponsen kommer til slutt

### Anbefalinger

Vi anbefaler følgende når det gjelder valg mellom klassisk strømming (som endepunktet vi viste deg over med `/stream`) og strømming via MCP:

- **For enkle strømmingsbehov:** Klassisk HTTP-strømming er enklere å implementere og tilstrekkelig for grunnleggende behov.

- **For komplekse, interaktive applikasjoner:** MCP-strømming gir en mer strukturert tilnærming med rikere metadata og separasjon mellom varsler og endelige resultater.

- **For AI-applikasjoner:** MCPs varslingssystem er spesielt nyttig for langvarige AI-oppgaver hvor man ønsker å holde brukere oppdatert om fremdrift.

## Strømming i MCP

Ok, så du har sett noen anbefalinger og sammenligninger så langt om forskjellen mellom klassisk strømming og strømming i MCP. La oss gå i detalj på hvordan du kan utnytte strømming i MCP.

Å forstå hvordan strømming fungerer innenfor MCP-rammeverket er avgjørende for å bygge responsive applikasjoner som gir sanntidsfeedback til brukere under langvarige operasjoner.

I MCP handler ikke strømming om å sende hovedresponsen i biter, men om å sende **varsler** til klienten mens et verktøy behandler en forespørsel. Disse varslene kan inkludere fremdriftsoppdateringer, logger eller andre hendelser.

### Slik fungerer det

Hovedresultatet sendes fortsatt som en enkelt respons. Varsler kan imidlertid sendes som separate meldinger under behandlingen og dermed oppdatere klienten i sanntid. Klienten må kunne håndtere og vise disse varslene.

## Hva er et varsel?

Vi nevnte "varsel", hva betyr det i MCP-sammenheng?

Et varsel er en melding sendt fra server til klient for å informere om fremdrift, status eller andre hendelser under en langvarig operasjon. Varsler øker åpenhet og forbedrer brukeropplevelsen.

For eksempel skal en klient sende et varsel når den innledende håndtrykkingen med serveren er fullført.

Et varsel ser slik ut som en JSON-melding:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Varsler tilhører et tema i MCP kalt ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

For å få logging til å fungere, må serveren aktivere det som en funksjon/kapasitet slik:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Avhengig av SDK som brukes, kan logging være aktivert som standard, eller du må eksplisitt aktivere det i serverkonfigurasjonen.

Det finnes ulike typer varsler:

| Nivå      | Beskrivelse                   | Eksempel på bruk               |
|-----------|------------------------------|-------------------------------|
| debug     | Detaljert feilsøkingsinformasjon | Funksjonsinngang/-utgang      |
| info      | Generelle informasjonsmeldinger | Oppdateringer om fremdrift    |
| notice    | Vanlige, men viktige hendelser | Konfigurasjonsendringer       |
| warning   | Advarsler                    | Bruk av utgåtte funksjoner    |
| error     | Feil                        | Operasjonsfeil                |
| critical  | Kritiske forhold             | Systemkomponentfeil           |
| alert     | Umiddelbar handling kreves  | Oppdaget datakorrupsjon       |
| emergency | Systemet er ubrukelig       | Fullstendig systemsvikt       |

## Implementering av varsler i MCP

For å implementere varsler i MCP må du sette opp både server- og klientsiden for å håndtere sanntidsoppdateringer. Dette gjør at applikasjonen din kan gi umiddelbar tilbakemelding til brukere under langvarige operasjoner.

### Serverside: Sende varsler

La oss starte med serversiden. I MCP definerer du verktøy som kan sende varsler mens de behandler forespørsler. Serveren bruker kontekstobjektet (vanligvis `ctx`) for å sende meldinger til klienten.

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

I eksemplet over sender `process_files`-verktøyet tre varsler til klienten mens det behandler hver fil. Metoden `ctx.info()` brukes for å sende informasjonsmeldinger.

</details>

I tillegg, for å aktivere varsler, må serveren bruke en strømmende transport (som `streamable-http`) og klienten må implementere en meldingshåndterer for å behandle varsler. Slik kan du sette opp serveren til å bruke `streamable-http`-transporten:

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

I dette .NET-eksempelet er `ProcessFiles`-verktøyet dekorert med `Tool`-attributtet og sender tre varsler til klienten mens det behandler hver fil. Metoden `ctx.Info()` brukes for å sende informasjonsmeldinger.

For å aktivere varsler i din .NET MCP-server, sørg for at du bruker en strømmende transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klientside: Motta varsler

Klienten må implementere en meldingshåndterer for å behandle og vise varsler etter hvert som de kommer.

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

I koden over sjekker funksjonen `message_handler` om den innkommende meldingen er et varsel. Hvis det er det, skrives varselet ut; ellers behandles det som en vanlig servermelding. Merk også hvordan `ClientSession` initialiseres med `message_handler` for å håndtere innkommende varsler.

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

I dette .NET-eksempelet sjekker funksjonen `MessageHandler` om den innkommende meldingen er et varsel. Hvis det er det, skrives varselet ut; ellers behandles det som en vanlig servermelding. `ClientSession` initialiseres med meldingshåndtereren via `ClientSessionOptions`.

</details>

For å aktivere varsler, sørg for at serveren bruker en strømmende transport (som `streamable-http`) og at klienten implementerer en meldingshåndterer for å behandle varsler.

## Fremdriftsvarsler og scenarier

Denne seksjonen forklarer konseptet med fremdriftsvarsler i MCP, hvorfor de er viktige, og hvordan du kan implementere dem med Streamable HTTP. Du finner også en praktisk oppgave for å styrke forståelsen.

Fremdriftsvarsler er sanntidsmeldinger sendt fra server til klient under langvarige operasjoner. I stedet for å vente på at hele prosessen skal bli ferdig, holder serveren klienten oppdatert om gjeldende status. Dette øker åpenhet, forbedrer brukeropplevelsen og gjør feilsøking enklere.

**Eksempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Hvorfor bruke fremdriftsvarsler?

Fremdriftsvarsler er viktige av flere grunner:

- **Bedre brukeropplevelse:** Brukere ser oppdateringer mens arbeidet pågår, ikke bare til slutt.
- **Sanntidsfeedback:** Klienter kan vise fremdriftsindikatorer eller logger, noe som gjør appen mer responsiv.
- **Enklere feilsøking og overvåking:** Utviklere og brukere kan se hvor en prosess eventuelt er treg eller står fast.

### Hvordan implementere fremdriftsvarsler

Slik kan du implementere fremdriftsvarsler i MCP:

- **På serveren:** Bruk `ctx.info()` eller `ctx.log()` for å sende varsler etter hvert som hvert element behandles. Dette sender en melding til klienten før hovedresultatet er klart.
- **På klienten:** Implementer en meldingshåndterer som lytter etter og viser varsler etter hvert som de kommer. Denne håndtereren skiller mellom varsler og det endelige resultatet.

**Servereksempel:**

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

**Klienteksempel:**

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

## Sikkerhetshensyn

Når du implementerer MCP-servere med HTTP-baserte transportmetoder, blir sikkerhet en avgjørende faktor som krever nøye vurdering av flere angrepsvektorer og beskyttelsesmekanismer.

### Oversikt

Sikkerhet er kritisk når MCP-servere eksponeres over HTTP. Streamable HTTP introduserer nye angrepsflater og krever nøye konfigurasjon.

### Viktige punkter
- **Validering av Origin-header**: Alltid valider `Origin`-headeren for å forhindre DNS-rebinding-angrep.
- **Binding til localhost**: For lokal utvikling, bind servere til `localhost` for å unngå eksponering mot det offentlige internett.
- **Autentisering**: Implementer autentisering (f.eks. API-nøkler, OAuth) for produksjonsdistribusjoner.
- **CORS**: Konfigurer Cross-Origin Resource Sharing (CORS)-policyer for å begrense tilgang.
- **HTTPS**: Bruk HTTPS i produksjon for å kryptere trafikken.

### Beste praksis
- Stol aldri på innkommende forespørsler uten validering.
- Loggfør og overvåk all tilgang og feil.
- Oppdater avhengigheter jevnlig for å tette sikkerhetshull.

### Utfordringer
- Å balansere sikkerhet med enkel utvikling
- Sikre kompatibilitet med ulike klientmiljøer


## Oppgradering fra SSE til Streamable HTTP

For applikasjoner som i dag bruker Server-Sent Events (SSE), gir migrering til Streamable HTTP forbedrede muligheter og bedre langsiktig bærekraft for dine MCP-implementasjoner.

### Hvorfor oppgradere?

Det finnes to gode grunner til å oppgradere fra SSE til Streamable HTTP:

- Streamable HTTP tilbyr bedre skalerbarhet, kompatibilitet og rikere støtte for varslinger enn SSE.
- Det er den anbefalte transporten for nye MCP-applikasjoner.

### Migrasjonstrinn

Slik kan du migrere fra SSE til Streamable HTTP i dine MCP-applikasjoner:

- **Oppdater serverkoden** til å bruke `transport="streamable-http"` i `mcp.run()`.
- **Oppdater klientkoden** til å bruke `streamablehttp_client` i stedet for SSE-klienten.
- **Implementer en meldingsbehandler** i klienten for å håndtere varslinger.
- **Test for kompatibilitet** med eksisterende verktøy og arbeidsflyter.

### Opprettholde kompatibilitet

Det anbefales å opprettholde kompatibilitet med eksisterende SSE-klienter under migreringen. Her er noen strategier:

- Du kan støtte både SSE og Streamable HTTP ved å kjøre begge transportene på forskjellige endepunkter.
- Migrer klienter gradvis til den nye transporten.

### Utfordringer

Sørg for å håndtere følgende utfordringer under migreringen:

- At alle klienter blir oppdatert
- Håndtering av forskjeller i leveringen av varslinger

## Sikkerhetshensyn

Sikkerhet bør være en topp prioritet når du implementerer servere, spesielt når du bruker HTTP-baserte transportmetoder som Streamable HTTP i MCP.

Når du implementerer MCP-servere med HTTP-baserte transportmetoder, blir sikkerhet en avgjørende faktor som krever nøye vurdering av flere angrepsvektorer og beskyttelsesmekanismer.

### Oversikt

Sikkerhet er kritisk når MCP-servere eksponeres over HTTP. Streamable HTTP introduserer nye angrepsflater og krever nøye konfigurasjon.

Her er noen viktige sikkerhetshensyn:

- **Validering av Origin-header**: Alltid valider `Origin`-headeren for å forhindre DNS-rebinding-angrep.
- **Binding til localhost**: For lokal utvikling, bind servere til `localhost` for å unngå eksponering mot det offentlige internett.
- **Autentisering**: Implementer autentisering (f.eks. API-nøkler, OAuth) for produksjonsdistribusjoner.
- **CORS**: Konfigurer Cross-Origin Resource Sharing (CORS)-policyer for å begrense tilgang.
- **HTTPS**: Bruk HTTPS i produksjon for å kryptere trafikken.

### Beste praksis

I tillegg er det noen beste praksiser å følge når du implementerer sikkerhet i din MCP streaming-server:

- Stol aldri på innkommende forespørsler uten validering.
- Loggfør og overvåk all tilgang og feil.
- Oppdater avhengigheter jevnlig for å tette sikkerhetshull.

### Utfordringer

Du vil møte noen utfordringer når du implementerer sikkerhet i MCP streaming-servere:

- Å balansere sikkerhet med enkel utvikling
- Sikre kompatibilitet med ulike klientmiljøer

### Oppgave: Bygg din egen streaming MCP-app

**Scenario:**
Bygg en MCP-server og klient der serveren behandler en liste med elementer (f.eks. filer eller dokumenter) og sender en varsling for hvert element som behandles. Klienten skal vise hver varsling etter hvert som den kommer.

**Trinn:**

1. Implementer et serververktøy som behandler en liste og sender varslinger for hvert element.
2. Implementer en klient med en meldingsbehandler som viser varslinger i sanntid.
3. Test implementeringen ved å kjøre både server og klient, og observer varslingene.

[Solution](./solution/README.md)

## Videre lesning og hva nå?

For å fortsette reisen med MCP streaming og utvide kunnskapen din, gir denne seksjonen flere ressurser og forslag til neste steg for å bygge mer avanserte applikasjoner.

### Videre lesning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Hva nå?

- Prøv å bygge mer avanserte MCP-verktøy som bruker streaming for sanntidsanalyse, chat eller samarbeidende redigering.
- Utforsk integrasjon av MCP streaming med frontend-rammeverk (React, Vue, osv.) for live UI-oppdateringer.
- Neste: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.