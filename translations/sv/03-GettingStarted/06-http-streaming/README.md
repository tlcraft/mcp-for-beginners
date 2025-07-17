<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T18:45:23+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sv"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Det här kapitlet ger en omfattande guide för att implementera säker, skalbar och realtidsströmning med Model Context Protocol (MCP) via HTTPS. Det täcker motivationen för streaming, tillgängliga transportmekanismer, hur man implementerar strömningsbar HTTP i MCP, säkerhetsrutiner, migrering från SSE samt praktiska råd för att bygga egna streaming-MCP-applikationer.

## Transportmekanismer och streaming i MCP

Denna sektion utforskar de olika transportmekanismer som finns i MCP och deras roll för att möjliggöra streamingfunktioner för realtidskommunikation mellan klienter och servrar.

### Vad är en transportmekanism?

En transportmekanism definierar hur data utbyts mellan klient och server. MCP stödjer flera transporttyper för att passa olika miljöer och behov:

- **stdio**: Standard in-/utmatning, lämpligt för lokala och CLI-baserade verktyg. Enkelt men inte lämpligt för webben eller molnet.
- **SSE (Server-Sent Events)**: Tillåter servrar att skicka realtidsuppdateringar till klienter över HTTP. Bra för webbgränssnitt, men begränsat i skalbarhet och flexibilitet.
- **Streamable HTTP**: Modern HTTP-baserad streamingtransport som stödjer notifieringar och bättre skalbarhet. Rekommenderas för de flesta produktions- och molnscenarier.

### Jämförelsetabell

Ta en titt på jämförelsetabellen nedan för att förstå skillnaderna mellan dessa transportmekanismer:

| Transport         | Realtidsuppdateringar | Streaming | Skalbarhet | Användningsområde       |
|-------------------|-----------------------|-----------|------------|------------------------|
| stdio             | Nej                   | Nej       | Låg        | Lokala CLI-verktyg     |
| SSE               | Ja                    | Ja        | Medel      | Webb, realtidsuppdateringar |
| Streamable HTTP   | Ja                    | Ja        | Hög        | Moln, multi-klient     |

> **Tip:** Valet av transport påverkar prestanda, skalbarhet och användarupplevelse. **Streamable HTTP** rekommenderas för moderna, skalbara och molnanpassade applikationer.

Observera transporterna stdio och SSE som visades i tidigare kapitel och hur streamable HTTP är den transport som behandlas i detta kapitel.

## Streaming: Koncept och motivation

Att förstå de grundläggande koncepten och motivationen bakom streaming är avgörande för att implementera effektiva realtidskommunikationssystem.

**Streaming** är en teknik inom nätverksprogrammering som tillåter data att skickas och tas emot i små, hanterbara delar eller som en sekvens av händelser, istället för att vänta på att hela svaret ska vara klart. Detta är särskilt användbart för:

- Stora filer eller dataset.
- Realtidsuppdateringar (t.ex. chatt, progressindikatorer).
- Långvariga beräkningar där man vill hålla användaren informerad.

Här är vad du behöver veta om streaming på en övergripande nivå:

- Data levereras successivt, inte allt på en gång.
- Klienten kan bearbeta data i takt med att den anländer.
- Minskar upplevd fördröjning och förbättrar användarupplevelsen.

### Varför använda streaming?

Anledningarna till att använda streaming är följande:

- Användare får omedelbar återkoppling, inte bara i slutet.
- Möjliggör realtidsapplikationer och responsiva gränssnitt.
- Effektivare användning av nätverks- och beräkningsresurser.

### Enkelt exempel: HTTP Streaming Server & Klient

Här är ett enkelt exempel på hur streaming kan implementeras:

## Python

**Server (Python, med FastAPI och StreamingResponse):**

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


**Klient (Python, med requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


Detta exempel visar en server som skickar en serie meddelanden till klienten i takt med att de blir tillgängliga, istället för att vänta på att alla meddelanden ska vara klara.

**Så fungerar det:**
- Servern skickar varje meddelande så fort det är klart.
- Klienten tar emot och skriver ut varje del så fort den anländer.

**Krav:**
- Servern måste använda en strömningsrespons (t.ex. `StreamingResponse` i FastAPI).
- Klienten måste bearbeta svaret som en ström (`stream=True` i requests).
- Content-Type är vanligtvis `text/event-stream` eller `application/octet-stream`.

## Java

**Server (Java, med Spring Boot och Server-Sent Events):**

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

**Klient (Java, med Spring WebFlux WebClient):**

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

**Noteringar om Java-implementeringen:**
- Använder Spring Boots reaktiva stack med `Flux` för streaming
- `ServerSentEvent` ger strukturerad event-streaming med eventtyper
- `WebClient` med `bodyToFlux()` möjliggör reaktiv streamingkonsumtion
- `delayElements()` simulerar bearbetningstid mellan events
- Events kan ha typer (`info`, `result`) för bättre klienthantering

### Jämförelse: Klassisk streaming vs MCP-streaming

Skillnaderna mellan hur streaming fungerar på ett "klassiskt" sätt jämfört med hur det fungerar i MCP kan illustreras så här:

| Funktion               | Klassisk HTTP Streaming        | MCP Streaming (Notifieringar)     |
|------------------------|-------------------------------|----------------------------------|
| Huvudsvar              | Chunked                       | Enkelt, i slutet                 |
| Progressuppdateringar  | Skickas som datadelar         | Skickas som notifieringar        |
| Klientkrav             | Måste bearbeta strömmen       | Måste implementera meddelandehanterare |
| Användningsområde      | Stora filer, AI token-strömmar | Progress, loggar, realtidsfeedback |

### Viktiga skillnader

Här är några viktiga skillnader:

- **Kommunikationsmönster:**
   - Klassisk HTTP streaming: Använder enkel chunked transfer encoding för att skicka data i delar
   - MCP streaming: Använder ett strukturerat notifieringssystem med JSON-RPC-protokoll

- **Meddelandformat:**
   - Klassisk HTTP: Vanlig text med nya rader
   - MCP: Strukturerade LoggingMessageNotification-objekt med metadata

- **Klientimplementering:**
   - Klassisk HTTP: Enkel klient som bearbetar streaming-svar
   - MCP: Mer avancerad klient med meddelandehanterare för att bearbeta olika typer av meddelanden

- **Progressuppdateringar:**
   - Klassisk HTTP: Progress är en del av huvudsvarsströmmen
   - MCP: Progress skickas via separata notifieringsmeddelanden medan huvudsvar kommer i slutet

### Rekommendationer

Här är några rekommendationer när det gäller valet mellan klassisk streaming (som endpointen vi visade ovan med `/stream`) och streaming via MCP.

- **För enkla streamingbehov:** Klassisk HTTP streaming är enklare att implementera och räcker för grundläggande streamingbehov.

- **För komplexa, interaktiva applikationer:** MCP streaming ger en mer strukturerad metod med rikare metadata och separation mellan notifieringar och slutresultat.

- **För AI-applikationer:** MCP:s notifieringssystem är särskilt användbart för långvariga AI-uppgifter där man vill hålla användare informerade om progress.

## Streaming i MCP

Okej, du har sett några rekommendationer och jämförelser hittills om skillnaden mellan klassisk streaming och streaming i MCP. Nu går vi in på detaljer om hur du kan utnyttja streaming i MCP.

Att förstå hur streaming fungerar inom MCP-ramverket är avgörande för att bygga responsiva applikationer som ger realtidsfeedback till användare under långvariga operationer.

I MCP handlar streaming inte om att skicka huvudsvar i delar, utan om att skicka **notifieringar** till klienten medan ett verktyg bearbetar en förfrågan. Dessa notifieringar kan innehålla progressuppdateringar, loggar eller andra händelser.

### Så fungerar det

Huvudresultatet skickas fortfarande som ett enda svar. Men notifieringar kan skickas som separata meddelanden under bearbetningen och därmed uppdatera klienten i realtid. Klienten måste kunna hantera och visa dessa notifieringar.

## Vad är en notifiering?

Vi nämnde "Notifiering", vad betyder det i MCP-sammanhang?

En notifiering är ett meddelande som skickas från servern till klienten för att informera om progress, status eller andra händelser under en långvarig operation. Notifieringar ökar transparensen och förbättrar användarupplevelsen.

Till exempel ska en klient skicka en notifiering när den initiala handskakningen med servern är klar.

En notifiering ser ut så här som ett JSON-meddelande:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifieringar tillhör ett ämne i MCP som kallas ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

För att få logging att fungera behöver servern aktivera det som en funktion/kapacitet så här:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Beroende på vilken SDK som används kan logging vara aktiverat som standard, eller så kan du behöva aktivera det explicit i serverkonfigurationen.

Det finns olika typer av notifieringar:

| Nivå      | Beskrivning                   | Exempel på användning          |
|-----------|-------------------------------|-------------------------------|
| debug     | Detaljerad felsökningsinformation | Funktionsin- och utgångspunkter |
| info      | Allmänna informationsmeddelanden | Uppdateringar om progress      |
| notice    | Normala men viktiga händelser  | Konfigurationsändringar        |
| warning   | Varningsförhållanden           | Användning av föråldrad funktion |
| error     | Fel                           | Fel i operationer              |
| critical  | Kritiska förhållanden          | Systemkomponentfel             |
| alert     | Åtgärd måste vidtas omedelbart | Upptäckt datakorruption        |
| emergency | Systemet är oanvändbart        | Fullständigt systemfel         |

## Implementera notifieringar i MCP

För att implementera notifieringar i MCP behöver du konfigurera både server- och klientsidan för att hantera realtidsuppdateringar. Detta gör att din applikation kan ge omedelbar återkoppling till användare under långvariga operationer.

### Serversidan: Skicka notifieringar

Vi börjar med serversidan. I MCP definierar du verktyg som kan skicka notifieringar medan de bearbetar förfrågningar. Servern använder kontextobjektet (vanligtvis `ctx`) för att skicka meddelanden till klienten.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

I exemplet ovan skickar verktyget `process_files` tre notifieringar till klienten medan det bearbetar varje fil. Metoden `ctx.info()` används för att skicka informationsmeddelanden.

Dessutom, för att aktivera notifieringar, se till att din server använder en streamingtransport (som `streamable-http`) och att din klient implementerar en meddelandehanterare för att bearbeta notifieringar. Så här kan du konfigurera servern att använda `streamable-http`-transporten:

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

I detta .NET-exempel är verktyget `ProcessFiles` dekorerat med attributet `Tool` och skickar tre notifieringar till klienten medan det bearbetar varje fil. Metoden `ctx.Info()` används för att skicka informationsmeddelanden.

För att aktivera notifieringar i din .NET MCP-server, se till att du använder en streamingtransport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Klientsidan: Ta emot notifieringar

Klienten måste implementera en meddelandehanterare för att bearbeta och visa notifieringar när de anländer.

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

I koden ovan kontrollerar funktionen `message_handler` om det inkommande meddelandet är en notifiering. Om så är fallet skrivs notifieringen ut, annars bearbetas det som ett vanligt servermeddelande. Observera också hur `ClientSession` initieras med `message_handler` för att hantera inkommande notifieringar.

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

I detta .NET-exempel kontrollerar funktionen `MessageHandler` om det inkommande meddelandet är en notifiering. Om så är fallet skrivs notifieringen ut, annars bearbetas det som ett vanligt servermeddelande. `ClientSession` initieras med meddelandehanteraren via `ClientSessionOptions`.

För att aktivera notifieringar, se till att din server använder en streamingtransport (som `streamable-http`) och att din klient implementerar en meddelandehanterare för att bearbeta notifieringar.

## Progressnotifieringar & scenarier

Denna sektion förklarar konceptet med progressnotifieringar i MCP, varför de är viktiga och hur man implementerar dem med Streamable HTTP. Du hittar också en praktisk uppgift för att förstärka din förståelse.

Progressnotifieringar är realtidsmeddelanden som skickas från servern till klienten under långvariga operationer. Istället för att vänta på att hela processen ska bli klar håller servern klienten uppdaterad om aktuell status. Detta ökar transparensen, förbättrar användarupplevelsen och underlättar felsökning.

**Exempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Varför använda progressnotifieringar?

Progressnotifieringar är viktiga av flera skäl:

- **Bättre användarupplevelse:** Användare ser uppdateringar medan arbetet pågår, inte bara i slutet.
- **Realtidsåterkoppling:** Klienter kan visa progressindikatorer eller loggar, vilket gör appen mer responsiv.
- **Enklare felsökning och övervakning:** Utvecklare och användare kan se var en process eventuellt är långsam eller fastnar.

### Hur implementerar man progressnotifieringar?

Så här kan du implementera progressnotifieringar i MCP:

- **På servern:** Använd `ctx.info()` eller `ctx.log()` för att skicka notifieringar när varje objekt bearbetas. Detta skickar ett meddelande till klienten innan huvudresultatet är klart.
- **På klienten:** Implementera en meddelandehanterare som lyssnar efter och visar notifieringar när de anländer. Denna hanterare skiljer på notifieringar och slutresultat.

**Serverexempel:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**Klientexempel:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## Säkerhetsaspekter

När man implementerar MCP-servrar med HTTP-baserade transporter blir säkerhet en avgörande fråga som kräver noggrann uppmärksamhet på flera angreppsvektorer och skyddsmekanismer.

### Översikt

Säkerhet är kritiskt när MCP-servrar exponeras över HTTP. Streamable HTTP introducerar nya angreppsytor och kräver noggrann konfiguration.

### Viktiga punkter
- **Validering av Origin-header:** Validera alltid `Origin`-headern för att förhindra DNS-rebinding-attacker.
- **Bindning till localhost:** För lokal utveckling, bind servrar till `localhost` för att undvika exponering mot det publika internet.
- **Autentisering:** Implementera autentisering (t.ex. API-nycklar, OAuth) för produktionsmiljöer.
- **CORS:** Konfigurera Cross-Origin Resource Sharing (CORS)-policyer för att begränsa åtkomst.
- **HTTPS:** Använd HTTPS i produktion för att kryptera trafiken.

### Bästa praxis
- Lita aldrig på inkommande förfrågningar utan validering.
- Logga och övervaka all åtkomst och fel.
- Uppdatera regelbundet beroenden för att täppa till säkerhetshål.

### Utmaningar
- Balans mellan säkerhet och enkel utveckling
- Säkerställa kompatibilitet med olika klientmiljöer

## Uppgradering från SSE till Streamable HTTP

För applikationer som för närvarande använder Server-Sent Events (SSE) ger migrering till Streamable HTTP förbättrade möjligheter och bättre långsiktig hållbarhet för dina MCP-implementationer.
### Varför uppgradera?

Det finns två starka skäl att uppgradera från SSE till Streamable HTTP:

- Streamable HTTP erbjuder bättre skalbarhet, kompatibilitet och rikare notifikationsstöd än SSE.
- Det är den rekommenderade transporten för nya MCP-applikationer.

### Migreringssteg

Så här kan du migrera från SSE till Streamable HTTP i dina MCP-applikationer:

- **Uppdatera serverkoden** för att använda `transport="streamable-http"` i `mcp.run()`.
- **Uppdatera klientkoden** för att använda `streamablehttp_client` istället för SSE-klienten.
- **Implementera en meddelandehanterare** i klienten för att bearbeta notifikationer.
- **Testa kompatibilitet** med befintliga verktyg och arbetsflöden.

### Behålla kompatibilitet

Det rekommenderas att behålla kompatibilitet med befintliga SSE-klienter under migreringsprocessen. Här är några strategier:

- Du kan stödja både SSE och Streamable HTTP genom att köra båda transporterna på olika endpoints.
- Migrera klienter successivt till den nya transporten.

### Utmaningar

Se till att hantera följande utmaningar under migreringen:

- Säkerställa att alla klienter uppdateras
- Hantera skillnader i leverans av notifikationer

## Säkerhetsaspekter

Säkerhet bör vara högsta prioritet när du implementerar någon server, särskilt när du använder HTTP-baserade transporter som Streamable HTTP i MCP.

När du implementerar MCP-servrar med HTTP-baserade transporter blir säkerhet en avgörande fråga som kräver noggrann uppmärksamhet på flera angreppsvektorer och skyddsmekanismer.

### Översikt

Säkerhet är kritiskt när MCP-servrar exponeras över HTTP. Streamable HTTP introducerar nya angreppsyta och kräver noggrann konfiguration.

Här är några viktiga säkerhetsaspekter:

- **Validering av Origin-header**: Validera alltid `Origin`-headern för att förhindra DNS-rebinding-attacker.
- **Bindning till localhost**: För lokal utveckling, bind servrar till `localhost` för att undvika exponering mot det publika internet.
- **Autentisering**: Implementera autentisering (t.ex. API-nycklar, OAuth) för produktionsmiljöer.
- **CORS**: Konfigurera Cross-Origin Resource Sharing (CORS)-policyer för att begränsa åtkomst.
- **HTTPS**: Använd HTTPS i produktion för att kryptera trafiken.

### Bästa praxis

Dessutom, här är några bästa praxis att följa när du implementerar säkerhet i din MCP-streamingserver:

- Lita aldrig på inkommande förfrågningar utan validering.
- Logga och övervaka all åtkomst och fel.
- Uppdatera regelbundet beroenden för att åtgärda säkerhetssårbarheter.

### Utmaningar

Du kommer att möta vissa utmaningar när du implementerar säkerhet i MCP-streamingservrar:

- Att balansera säkerhet med enkel utveckling
- Att säkerställa kompatibilitet med olika klientmiljöer

### Uppgift: Bygg din egen streaming MCP-app

**Scenario:**  
Bygg en MCP-server och klient där servern bearbetar en lista med objekt (t.ex. filer eller dokument) och skickar en notifikation för varje objekt som bearbetas. Klienten ska visa varje notifikation när den anländer.

**Steg:**

1. Implementera ett serververktyg som bearbetar en lista och skickar notifikationer för varje objekt.
2. Implementera en klient med en meddelandehanterare som visar notifikationer i realtid.
3. Testa din implementation genom att köra både server och klient och observera notifikationerna.

[Solution](./solution/README.md)

## Vidare läsning & Vad händer härnäst?

För att fortsätta din resa med MCP-streaming och fördjupa dina kunskaper, erbjuder denna sektion ytterligare resurser och förslag på nästa steg för att bygga mer avancerade applikationer.

### Vidare läsning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Vad händer härnäst?

- Prova att bygga mer avancerade MCP-verktyg som använder streaming för realtidsanalys, chatt eller samarbetsredigering.
- Utforska integration av MCP-streaming med frontend-ramverk (React, Vue, etc.) för live-uppdateringar i användargränssnittet.
- Nästa: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.