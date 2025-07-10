<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:14:50+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "da"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Dette kapitel giver en omfattende vejledning i, hvordan man implementerer sikker, skalerbar og realtids streaming med Model Context Protocol (MCP) ved brug af HTTPS. Det dækker motivationen for streaming, de tilgængelige transportmekanismer, hvordan man implementerer streambar HTTP i MCP, sikkerhedspraksis, migration fra SSE og praktisk vejledning til at bygge dine egne streaming MCP-applikationer.

## Transportmekanismer og Streaming i MCP

Dette afsnit undersøger de forskellige transportmekanismer, der er tilgængelige i MCP, og deres rolle i at muliggøre streamingfunktioner til realtidskommunikation mellem klienter og servere.

### Hvad er en transportmekanisme?

En transportmekanisme definerer, hvordan data udveksles mellem klient og server. MCP understøtter flere transporttyper for at passe til forskellige miljøer og behov:

- **stdio**: Standard input/output, egnet til lokale og CLI-baserede værktøjer. Simpelt, men ikke egnet til web eller cloud.
- **SSE (Server-Sent Events)**: Tillader servere at sende realtidsopdateringer til klienter over HTTP. Godt til web-brugerflader, men begrænset i skalerbarhed og fleksibilitet.
- **Streamable HTTP**: Moderne HTTP-baseret streamingtransport, der understøtter notifikationer og bedre skalerbarhed. Anbefales til de fleste produktions- og cloud-scenarier.

### Sammenligningstabel

Se sammenligningstabellen nedenfor for at forstå forskellene mellem disse transportmekanismer:

| Transport         | Realtidsopdateringer | Streaming | Skalerbarhed | Anvendelsestilfælde     |
|-------------------|---------------------|-----------|--------------|------------------------|
| stdio             | Nej                 | Nej       | Lav          | Lokale CLI-værktøjer   |
| SSE               | Ja                  | Ja        | Mellem       | Web, realtidsopdateringer |
| Streamable HTTP   | Ja                  | Ja        | Høj          | Cloud, multi-klient    |

> **Tip:** Valget af den rigtige transport påvirker ydeevne, skalerbarhed og brugeroplevelse. **Streamable HTTP** anbefales til moderne, skalerbare og cloud-klare applikationer.

Bemærk transporterne stdio og SSE, som du blev vist i de tidligere kapitler, og hvordan streambar HTTP er den transport, der dækkes i dette kapitel.

## Streaming: Begreber og Motivation

At forstå de grundlæggende begreber og motivationen bag streaming er essentielt for at implementere effektive realtidskommunikationssystemer.

**Streaming** er en teknik inden for netværksprogrammering, der tillader data at blive sendt og modtaget i små, håndterbare bidder eller som en sekvens af begivenheder, i stedet for at vente på, at hele svaret er klar. Dette er især nyttigt til:

- Store filer eller datasæt.
- Realtidsopdateringer (f.eks. chat, fremdriftsindikatorer).
- Langvarige beregninger, hvor man ønsker at holde brugeren informeret.

Her er hvad du skal vide om streaming på et overordnet plan:

- Data leveres løbende, ikke alt på én gang.
- Klienten kan behandle data, efterhånden som det ankommer.
- Reducerer oplevet ventetid og forbedrer brugeroplevelsen.

### Hvorfor bruge streaming?

Årsagerne til at bruge streaming er følgende:

- Brugere får feedback med det samme, ikke kun til sidst
- Muliggør realtidsapplikationer og responsive brugerflader
- Mere effektiv udnyttelse af netværks- og computerressourcer

### Simpelt eksempel: HTTP Streaming Server & Klient

Her er et simpelt eksempel på, hvordan streaming kan implementeres:

<details>
<summary>Python</summary>

**Server (Python, bruger FastAPI og StreamingResponse):**
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

**Klient (Python, bruger requests):**
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

Dette eksempel demonstrerer en server, der sender en række beskeder til klienten, efterhånden som de bliver tilgængelige, i stedet for at vente på, at alle beskeder er klar.

**Sådan fungerer det:**
- Serveren leverer hver besked, så snart den er klar.
- Klienten modtager og udskriver hver del, efterhånden som den ankommer.

**Krav:**
- Serveren skal bruge en streamingrespons (f.eks. `StreamingResponse` i FastAPI).
- Klienten skal behandle svaret som en stream (`stream=True` i requests).
- Content-Type er normalt `text/event-stream` eller `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, bruger Spring Boot og Server-Sent Events):**

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

**Klient (Java, bruger Spring WebFlux WebClient):**

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

**Noter til Java-implementering:**
- Bruger Spring Boots reaktive stack med `Flux` til streaming
- `ServerSentEvent` giver struktureret event-streaming med event-typer
- `WebClient` med `bodyToFlux()` muliggør reaktiv streamingforbrug
- `delayElements()` simulerer behandlingstid mellem events
- Events kan have typer (`info`, `result`) for bedre klienthåndtering

</details>

### Sammenligning: Klassisk Streaming vs MCP Streaming

Forskellene mellem, hvordan streaming fungerer på en "klassisk" måde versus i MCP, kan illustreres således:

| Funktion               | Klassisk HTTP Streaming        | MCP Streaming (Notifikationer)     |
|------------------------|-------------------------------|-----------------------------------|
| Hovedrespons           | Chunked                       | Enkelt, til sidst                 |
| Fremdriftsopdateringer | Sendes som datablokke         | Sendes som notifikationer          |
| Klientkrav             | Skal behandle stream           | Skal implementere beskedshåndtering |
| Anvendelsestilfælde    | Store filer, AI token streams | Fremdrift, logs, realtidsfeedback  |

### Vigtige observerede forskelle

Derudover er her nogle nøgleforskelle:

- **Kommunikationsmønster:**
   - Klassisk HTTP streaming: Bruger simpel chunked transfer encoding til at sende data i bidder
   - MCP streaming: Bruger et struktureret notifikationssystem med JSON-RPC protokol

- **Beskedformat:**
   - Klassisk HTTP: Almindelige tekstbidder med linjeskift
   - MCP: Strukturerede LoggingMessageNotification-objekter med metadata

- **Klientimplementering:**
   - Klassisk HTTP: Simpel klient, der behandler streaming-respons
   - MCP: Mere avanceret klient med beskedshåndtering til at behandle forskellige typer beskeder

- **Fremdriftsopdateringer:**
   - Klassisk HTTP: Fremdrift er en del af hovedresponsen
   - MCP: Fremdrift sendes via separate notifikationsbeskeder, mens hovedresponsen kommer til sidst

### Anbefalinger

Der er nogle ting, vi anbefaler, når det kommer til valget mellem at implementere klassisk streaming (som et endpoint vist ovenfor med `/stream`) versus streaming via MCP.

- **Til simple streamingbehov:** Klassisk HTTP streaming er nemmere at implementere og tilstrækkeligt til grundlæggende streamingbehov.

- **Til komplekse, interaktive applikationer:** MCP streaming giver en mere struktureret tilgang med rigere metadata og adskillelse mellem notifikationer og endelige resultater.

- **Til AI-applikationer:** MCP’s notifikationssystem er særligt nyttigt til langvarige AI-opgaver, hvor man ønsker at holde brugerne opdateret om fremdriften.

## Streaming i MCP

Ok, så du har set nogle anbefalinger og sammenligninger indtil nu om forskellen mellem klassisk streaming og streaming i MCP. Lad os gå i detaljer med, hvordan du præcist kan udnytte streaming i MCP.

At forstå, hvordan streaming fungerer inden for MCP-rammen, er essentielt for at bygge responsive applikationer, der giver realtidsfeedback til brugere under langvarige operationer.

I MCP handler streaming ikke om at sende hovedresponsen i bidder, men om at sende **notifikationer** til klienten, mens et værktøj behandler en anmodning. Disse notifikationer kan inkludere fremdriftsopdateringer, logs eller andre begivenheder.

### Sådan fungerer det

Hovedresultatet sendes stadig som et enkelt svar. Dog kan notifikationer sendes som separate beskeder under behandlingen og dermed opdatere klienten i realtid. Klienten skal kunne håndtere og vise disse notifikationer.

## Hvad er en notifikation?

Vi sagde "Notifikation", hvad betyder det i MCP-sammenhæng?

En notifikation er en besked sendt fra serveren til klienten for at informere om fremdrift, status eller andre begivenheder under en langvarig operation. Notifikationer øger gennemsigtigheden og forbedrer brugeroplevelsen.

For eksempel skal en klient sende en notifikation, når den indledende håndtryk med serveren er gennemført.

En notifikation ser således ud som en JSON-besked:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikationer hører til et emne i MCP kaldet ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

For at få logging til at fungere, skal serveren aktivere det som en feature/kapabilitet på denne måde:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Afhængigt af den anvendte SDK kan logging være aktiveret som standard, eller du skal eksplicit aktivere det i din serverkonfiguration.

Der findes forskellige typer notifikationer:

| Niveau     | Beskrivelse                   | Eksempel på anvendelse          |
|------------|------------------------------|--------------------------------|
| debug      | Detaljeret fejlsøgningsinfo  | Funktionsindgang/-udgang       |
| info       | Generelle informationsbeskeder | Fremdriftsopdateringer         |
| notice     | Normale, men væsentlige begivenheder | Konfigurationsændringer       |
| warning    | Advarselsbetingelser         | Brug af forældet funktion      |
| error      | Fejltilstande                | Fejl i operationer             |
| critical   | Kritiske tilstande            | Systemkomponentfejl            |
| alert      | Handling skal udføres straks  | Datakorruption opdaget         |
| emergency  | Systemet er ubrugeligt        | Total systemfejl               |

## Implementering af notifikationer i MCP

For at implementere notifikationer i MCP skal du sætte både server- og klientsiden op til at håndtere realtidsopdateringer. Dette gør det muligt for din applikation at give øjeblikkelig feedback til brugere under langvarige operationer.

### Serverside: Afsendelse af notifikationer

Lad os starte med serversiden. I MCP definerer du værktøjer, der kan sende notifikationer, mens de behandler anmodninger. Serveren bruger kontekstobjektet (typisk `ctx`) til at sende beskeder til klienten.

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

I det foregående eksempel sender `process_files`-værktøjet tre notifikationer til klienten, mens det behandler hver fil. Metoden `ctx.info()` bruges til at sende informationsbeskeder.

</details>

Derudover, for at aktivere notifikationer, skal din server bruge en streamingtransport (som `streamable-http`), og din klient skal implementere en beskedshåndtering til at behandle notifikationer. Sådan kan du sætte serveren op til at bruge `streamable-http` transporten:

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

I dette .NET-eksempel er `ProcessFiles`-værktøjet dekoreret med `Tool`-attributten og sender tre notifikationer til klienten, mens det behandler hver fil. Metoden `ctx.Info()` bruges til at sende informationsbeskeder.

For at aktivere notifikationer i din .NET MCP-server skal du sikre, at du bruger en streamingtransport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klientside: Modtagelse af notifikationer

Klienten skal implementere en beskedshåndtering til at behandle og vise notifikationer, efterhånden som de ankommer.

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

I den foregående kode tjekker funktionen `message_handler`, om den indkommende besked er en notifikation. Hvis det er tilfældet, udskrives notifikationen; ellers behandles den som en almindelig serverbesked. Bemærk også, hvordan `ClientSession` initialiseres med `message_handler` for at håndtere indkommende notifikationer.

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

I dette .NET-eksempel tjekker funktionen `MessageHandler`, om den indkommende besked er en notifikation. Hvis det er tilfældet, udskrives notifikationen; ellers behandles den som en almindelig serverbesked. `ClientSession` initialiseres med beskedshåndteringen via `ClientSessionOptions`.

</details>

For at aktivere notifikationer skal du sikre, at din server bruger en streamingtransport (som `streamable-http`), og at din klient implementerer en beskedshåndtering til at behandle notifikationer.

## Fremdriftsnotifikationer & Scenarier

Dette afsnit forklarer konceptet med fremdriftsnotifikationer i MCP, hvorfor de er vigtige, og hvordan man implementerer dem ved brug af Streamable HTTP. Du finder også en praktisk opgave til at styrke din forståelse.

Fremdriftsnotifikationer er realtidsbeskeder sendt fra serveren til klienten under langvarige operationer. I stedet for at vente på, at hele processen er færdig, holder serveren klienten opdateret om den aktuelle status. Dette øger gennemsigtigheden, forbedrer brugeroplevelsen og gør fejlfinding lettere.

**Eksempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Hvorfor bruge fremdriftsnotifikationer?

Fremdriftsnotifikationer er vigtige af flere grunde:

- **Bedre brugeroplevelse:** Brugere ser opdateringer, mens arbejdet skrider frem, ikke kun til sidst.
- **Realtidsfeedback:** Klienter kan vise fremdriftsbjælker eller logs, hvilket gør appen mere responsiv.
- **Lettere fejlfinding og overvågning:** Udviklere og brugere kan se, hvor en proces eventuelt er langsom eller hænger.

### Sådan implementeres fremdriftsnotifikationer

Sådan kan du implementere fremdriftsnotifikationer i MCP:

- **På serveren:** Brug `ctx.info()` eller `ctx.log()` til at sende notifikationer, efterhånden som hvert element behandles. Dette sender en besked til klienten, før hovedresultatet er klar.
- **På klienten:** Implementer en beskedshåndtering, der lytter efter og viser notifikationer, efterhånden som de ankommer. Denne håndtering skelner mellem notifikationer og det endelige resultat.

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

## Sikkerhedsovervejelser

Når man implementerer MCP-servere med HTTP-baserede transports, bliver sikkerhed en altafgørende faktor, der kræver nøje opmærksomhed på flere angrebsvinkler og beskyttelsesmekanismer.

### Oversigt

Sikkerhed er afgørende, når MCP-servere eksponeres over HTTP. Streamable HTTP introducerer nye angrebsflader og kræver omhyggelig konfiguration.

### Vigtige punkter
- **Validering af Origin-header**: Valider altid `Origin`-headeren for at forhindre DNS-rebinding-angreb.
- **Binding til localhost**: Til lokal udvikling skal servere bindes til `localhost` for at undgå eksponering mod det offentlige internet.
- **Autentificering**: Implementer autentificering (f.eks. API-nøgler, OAuth) til produktionsmiljøer.
- **CORS**: Konfigurer Cross-Origin Resource Sharing (CORS)-politikker for at begrænse adgang.
- **HTTPS**: Brug HTTPS i produktion for at kryptere trafikken.

### Bedste praksis
- Stol aldrig på indkommende forespørgsler uden validering.
- Log og overvåg al adgang og fejl.
- Opdater regelmæssigt afhængigheder for at lukke sikkerhedshuller.

### Udfordringer
- At balancere sikkerhed med udviklingsvenlighed
- At sikre kompatibilitet med forskellige klientmiljøer


## Opgradering fra SSE til Streamable HTTP

For applikationer, der i øjeblikket bruger Server-Sent Events (SSE), giver en migration til Streamable HTTP forbedrede muligheder og bedre langsigtet bæredygtighed for dine MCP-implementeringer.

### Hvorfor opgradere?

Der er to overbevisende grunde til at opgradere fra SSE til Streamable HTTP:

- Streamable HTTP tilbyder bedre skalerbarhed, kompatibilitet og mere omfattende notifikationsunderstøttelse end SSE.
- Det er den anbefalede transport for nye MCP-applikationer.

### Migreringstrin

Sådan kan du migrere fra SSE til Streamable HTTP i dine MCP-applikationer:

- **Opdater serverkoden** til at bruge `transport="streamable-http"` i `mcp.run()`.
- **Opdater klientkoden** til at bruge `streamablehttp_client` i stedet for SSE-klienten.
- **Implementer en beskedbehandler** i klienten til at håndtere notifikationer.
- **Test for kompatibilitet** med eksisterende værktøjer og arbejdsgange.

### Opretholdelse af kompatibilitet

Det anbefales at bevare kompatibilitet med eksisterende SSE-klienter under migrationsprocessen. Her er nogle strategier:

- Du kan understøtte både SSE og Streamable HTTP ved at køre begge transports på forskellige endpoints.
- Migrer klienter gradvist til den nye transport.

### Udfordringer

Sørg for at håndtere følgende udfordringer under migreringen:

- At sikre, at alle klienter opdateres
- At håndtere forskelle i leveringen af notifikationer

## Sikkerhedsovervejelser

Sikkerhed bør være en topprioritet ved implementering af enhver server, især når man bruger HTTP-baserede transports som Streamable HTTP i MCP.

Når man implementerer MCP-servere med HTTP-baserede transports, bliver sikkerhed en altafgørende faktor, der kræver nøje opmærksomhed på flere angrebsvinkler og beskyttelsesmekanismer.

### Oversigt

Sikkerhed er afgørende, når MCP-servere eksponeres over HTTP. Streamable HTTP introducerer nye angrebsflader og kræver omhyggelig konfiguration.

Her er nogle centrale sikkerhedsovervejelser:

- **Validering af Origin-header**: Valider altid `Origin`-headeren for at forhindre DNS-rebinding-angreb.
- **Binding til localhost**: Til lokal udvikling skal servere bindes til `localhost` for at undgå eksponering mod det offentlige internet.
- **Autentificering**: Implementer autentificering (f.eks. API-nøgler, OAuth) til produktionsmiljøer.
- **CORS**: Konfigurer Cross-Origin Resource Sharing (CORS)-politikker for at begrænse adgang.
- **HTTPS**: Brug HTTPS i produktion for at kryptere trafikken.

### Bedste praksis

Derudover er her nogle bedste praksisser at følge, når du implementerer sikkerhed i din MCP streaming-server:

- Stol aldrig på indkommende forespørgsler uden validering.
- Log og overvåg al adgang og fejl.
- Opdater regelmæssigt afhængigheder for at lukke sikkerhedshuller.

### Udfordringer

Du vil møde nogle udfordringer, når du implementerer sikkerhed i MCP streaming-servere:

- At balancere sikkerhed med udviklingsvenlighed
- At sikre kompatibilitet med forskellige klientmiljøer

### Opgave: Byg din egen streaming MCP-app

**Scenario:**
Byg en MCP-server og klient, hvor serveren behandler en liste af elementer (f.eks. filer eller dokumenter) og sender en notifikation for hvert behandlede element. Klienten skal vise hver notifikation, efterhånden som den modtages.

**Trin:**

1. Implementer et serverværktøj, der behandler en liste og sender notifikationer for hvert element.
2. Implementer en klient med en beskedbehandler, der viser notifikationer i realtid.
3. Test din implementering ved at køre både server og klient og observere notifikationerne.

[Solution](./solution/README.md)

## Yderligere læsning & hvad nu?

For at fortsætte din rejse med MCP streaming og udvide din viden, giver denne sektion yderligere ressourcer og foreslåede næste skridt til at bygge mere avancerede applikationer.

### Yderligere læsning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Hvad nu?

- Prøv at bygge mere avancerede MCP-værktøjer, der bruger streaming til realtidsanalyse, chat eller samarbejdende redigering.
- Undersøg integration af MCP streaming med frontend-rammer (React, Vue osv.) for live UI-opdateringer.
- Næste: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.