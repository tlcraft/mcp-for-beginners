<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:14:20+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sv"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Det här kapitlet ger en omfattande guide för att implementera säker, skalbar och realtidsströmning med Model Context Protocol (MCP) via HTTPS. Det täcker motivationen bakom strömning, tillgängliga transportmekanismer, hur man implementerar strömningsbar HTTP i MCP, säkerhetsrutiner, migrering från SSE och praktisk vägledning för att bygga egna strömningsbaserade MCP-applikationer.

## Transportmekanismer och strömning i MCP

Den här sektionen utforskar de olika transportmekanismer som finns i MCP och deras roll för att möjliggöra strömningsfunktioner för realtidskommunikation mellan klienter och servrar.

### Vad är en transportmekanism?

En transportmekanism definierar hur data utbyts mellan klient och server. MCP stöder flera transporttyper för att passa olika miljöer och behov:

- **stdio**: Standard in-/utgång, lämpligt för lokala och CLI-baserade verktyg. Enkelt men inte anpassat för webben eller molnet.
- **SSE (Server-Sent Events)**: Gör det möjligt för servrar att skicka realtidsuppdateringar till klienter över HTTP. Bra för webbgränssnitt men begränsad i skalbarhet och flexibilitet.
- **Streamable HTTP**: Modern HTTP-baserad strömningsmetod som stödjer notifieringar och bättre skalbarhet. Rekommenderas för de flesta produktions- och molnsituationer.

### Jämförelsetabell

Titta på jämförelsetabellen nedan för att förstå skillnaderna mellan dessa transportmekanismer:

| Transport         | Realtidsuppdateringar | Strömning | Skalbarhet | Användningsområde          |
|-------------------|-----------------------|-----------|------------|---------------------------|
| stdio             | Nej                   | Nej       | Låg        | Lokala CLI-verktyg        |
| SSE               | Ja                    | Ja        | Medel      | Webb, realtidsuppdateringar |
| Streamable HTTP   | Ja                    | Ja        | Hög        | Moln, flera klienter      |

> **Tip:** Valet av transport påverkar prestanda, skalbarhet och användarupplevelse. **Streamable HTTP** rekommenderas för moderna, skalbara och molnanpassade applikationer.

Observera transporterna stdio och SSE som visades i tidigare kapitel och hur streamable HTTP är den transport som behandlas i detta kapitel.

## Strömning: Begrepp och motivation

Att förstå grundläggande begrepp och motivationen bakom strömning är avgörande för att implementera effektiva realtidskommunikationssystem.

**Strömning** är en teknik inom nätverksprogrammering som gör det möjligt att skicka och ta emot data i små, hanterbara delar eller som en sekvens av händelser, istället för att vänta på att hela svaret ska vara färdigt. Detta är särskilt användbart för:

- Stora filer eller dataset.
- Realtidsuppdateringar (t.ex. chatt, progressindikatorer).
- Långvariga beräkningar där man vill hålla användaren informerad.

Här är vad du behöver veta om strömning på en övergripande nivå:

- Data levereras successivt, inte allt på en gång.
- Klienten kan bearbeta data allteftersom det anländer.
- Minskar upplevd fördröjning och förbättrar användarupplevelsen.

### Varför använda strömning?

Anledningarna till att använda strömning är följande:

- Användare får omedelbar återkoppling, inte bara i slutet
- Möjliggör realtidsapplikationer och responsiva användargränssnitt
- Effektivare användning av nätverks- och beräkningsresurser

### Enkelt exempel: HTTP-strömningsserver & klient

Här är ett enkelt exempel på hur strömning kan implementeras:

<details>
<summary>Python</summary>

**Server (Python, med FastAPI och StreamingResponse):**
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

**Klient (Python, med requests):**
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

Detta exempel visar en server som skickar en serie meddelanden till klienten så fort de blir tillgängliga, istället för att vänta på att alla meddelanden ska vara klara.

**Hur det fungerar:**
- Servern skickar varje meddelande så snart det är klart.
- Klienten tar emot och skriver ut varje del så fort den anländer.

**Krav:**
- Servern måste använda en strömningsrespons (t.ex. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) istället för att välja strömning via MCP.

- **För enkla strömningsbehov:** Klassisk HTTP-strömning är enklare att implementera och räcker för grundläggande strömning.

- **För komplexa, interaktiva applikationer:** MCP-strömning ger ett mer strukturerat tillvägagångssätt med rikare metadata och separation mellan notifieringar och slutresultat.

- **För AI-applikationer:** MCP:s notifieringssystem är särskilt användbart för långvariga AI-uppgifter där man vill hålla användarna informerade om framsteg.

## Strömning i MCP

Okej, du har sett några rekommendationer och jämförelser hittills om skillnaden mellan klassisk strömning och strömning i MCP. Låt oss gå in på detalj om hur du kan utnyttja strömning i MCP.

Att förstå hur strömning fungerar inom MCP-ramverket är avgörande för att bygga responsiva applikationer som ger realtidsåterkoppling till användare under långvariga operationer.

I MCP handlar strömning inte om att skicka huvudsvaret i delar, utan om att skicka **notifieringar** till klienten medan ett verktyg bearbetar en förfrågan. Dessa notifieringar kan innehålla statusuppdateringar, loggar eller andra händelser.

### Hur det fungerar

Huvudresultatet skickas fortfarande som ett enda svar. Dock kan notifieringar skickas som separata meddelanden under bearbetningen och därigenom uppdatera klienten i realtid. Klienten måste kunna hantera och visa dessa notifieringar.

## Vad är en notifiering?

Vi nämnde "Notifiering", vad betyder det i MCP:s sammanhang?

En notifiering är ett meddelande som skickas från servern till klienten för att informera om framsteg, status eller andra händelser under en långvarig operation. Notifieringar ökar transparensen och förbättrar användarupplevelsen.

Till exempel ska en klient skicka en notifiering när den initiala handskakningen med servern är genomförd.

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

För att få logging att fungera behöver servern aktivera det som en funktion/kapabilitet så här:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Beroende på vilken SDK som används kan logging vara aktiverat som standard, eller så kan du behöva aktivera det uttryckligen i serverkonfigurationen.

Det finns olika typer av notifieringar:

| Nivå      | Beskrivning                   | Exempel på användning          |
|-----------|------------------------------|-------------------------------|
| debug     | Detaljerad felsökningsinformation | Funktionsin- och utgångspunkter |
| info      | Allmänna informationsmeddelanden | Uppdateringar om operationens framsteg |
| notice    | Normala men viktiga händelser  | Konfigurationsändringar         |
| warning   | Varningsvillkor               | Användning av föråldrad funktion |
| error     | Felvillkor                   | Fel i operationer              |
| critical  | Kritiska villkor             | Systemkomponentfel             |
| alert     | Åtgärd måste vidtas omedelbart | Upptäckt datakorruption        |
| emergency | Systemet är obrukbart        | Total systemkrasch             |

## Implementera notifieringar i MCP

För att implementera notifieringar i MCP behöver du konfigurera både server- och klientsidan för att hantera realtidsuppdateringar. Detta gör att din applikation kan ge omedelbar återkoppling till användare under långvariga operationer.

### Serversidan: Skicka notifieringar

Vi börjar med serversidan. I MCP definierar du verktyg som kan skicka notifieringar medan förfrågningar bearbetas. Servern använder kontextobjektet (vanligtvis `ctx`) för att skicka meddelanden till klienten.

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

I det föregående exemplet använder `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`-transporten:

```python
mcp.run(transport="streamable-http")
```

</details>

### Klientsidan: Ta emot notifieringar

Klienten måste implementera en meddelandehanterare för att bearbeta och visa notifieringar när de anländer.

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

I koden ovan implementerar klienten en `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) som hanterar notifieringar.

## Progressnotifieringar & scenarier

Den här sektionen förklarar begreppet progressnotifieringar i MCP, varför de är viktiga och hur man implementerar dem med Streamable HTTP. Du hittar även en praktisk uppgift för att förstärka din förståelse.

Progressnotifieringar är realtidsmeddelanden som skickas från servern till klienten under långvariga operationer. Istället för att vänta på att hela processen ska avslutas håller servern klienten uppdaterad om aktuell status. Detta förbättrar transparens, användarupplevelse och gör felsökning enklare.

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
- **Realtidsåterkoppling:** Klienter kan visa progressindikatorer eller loggar, vilket gör att appen känns responsiv.
- **Enklare felsökning och övervakning:** Utvecklare och användare kan se var en process är långsam eller fastnat.

### Hur implementerar man progressnotifieringar

Så här kan du implementera progressnotifieringar i MCP:

- **På servern:** Använd `ctx.info()` or `ctx.log()` för att skicka notifieringar när varje objekt bearbetas. Detta skickar ett meddelande till klienten innan huvudresultatet är klart.
- **På klienten:** Implementera en meddelandehanterare som lyssnar efter och visar notifieringar när de anländer. Denna hanterare skiljer på notifieringar och slutresultat.

**Serverexempel:**

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

**Klientexempel:**

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

## Säkerhetsaspekter

När man implementerar MCP-servrar med HTTP-baserade transporter blir säkerhet en avgörande fråga som kräver noggrann uppmärksamhet på flera angreppsytor och skyddsmekanismer.

### Översikt

Säkerhet är kritiskt när MCP-servrar exponeras över HTTP. Streamable HTTP introducerar nya angreppsmöjligheter och kräver noggrann konfiguration.

### Viktiga punkter
- **Validering av Origin-headern**: Validera alltid `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` istället för SSE-klienten.
3. **Implementera en meddelandehanterare** i klienten för att bearbeta notifieringar.
4. **Testa kompatibilitet** med befintliga verktyg och arbetsflöden.

### Upprätthålla kompatibilitet

Det rekommenderas att behålla kompatibilitet med befintliga SSE-klienter under migreringsprocessen. Här är några strategier:

- Du kan stödja både SSE och Streamable HTTP genom att köra båda transporterna på olika endpoints.
- Migrera klienter gradvis till den nya transporten.

### Utmaningar

Se till att hantera följande utmaningar under migreringen:

- Säkerställa att alla klienter uppdateras
- Hantera skillnader i leverans av notifieringar

### Uppgift: Bygg din egen strömningsbaserade MCP-app

**Scenario:**
Bygg en MCP-server och klient där servern bearbetar en lista med objekt (t.ex. filer eller dokument) och skickar en notifiering för varje bearbetat objekt. Klienten ska visa varje notifiering när den anländer.

**Steg:**

1. Implementera ett serververktyg som bearbetar en lista och skickar notifieringar för varje objekt.
2. Implementera en klient med en meddelandehanterare som visar notifieringar i realtid.
3. Testa din implementation genom att köra både server och klient och observera notifieringarna.

[Lösning](./solution/README.md)

## Vidare läsning & nästa steg

För att fortsätta din resa med MCP-strömning och utöka din kunskap ger denna sektion ytterligare resurser och förslag på nästa steg för att bygga mer avancerade applikationer.

### Vidare läsning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Vad händer härnäst?

- Försök bygga mer avancerade MCP-verktyg som använder strömning för realtidsanalys, chatt eller samredigering.
- Utforska integration av MCP-strömning med frontend-ramverk (React, Vue, etc.) för liveuppdateringar i UI.
- Nästa: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var vänlig observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår från användningen av denna översättning.