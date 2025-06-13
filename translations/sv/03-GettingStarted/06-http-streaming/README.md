<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:43:33+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sv"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Det här kapitlet ger en omfattande guide för att implementera säker, skalbar och realtidsströmning med Model Context Protocol (MCP) via HTTPS. Det täcker motivationen för strömning, tillgängliga transportmekanismer, hur man implementerar strömmande HTTP i MCP, säkerhetsbästa praxis, migrering från SSE och praktisk vägledning för att bygga egna strömmande MCP-applikationer.

## Transportmekanismer och strömning i MCP

Denna sektion utforskar de olika transportmekanismer som finns tillgängliga i MCP och deras roll för att möjliggöra strömmande funktioner för realtidskommunikation mellan klienter och servrar.

### Vad är en transportmekanism?

En transportmekanism definierar hur data utbyts mellan klient och server. MCP stödjer flera transporttyper för att passa olika miljöer och behov:

- **stdio**: Standard in-/utgång, lämpligt för lokala och CLI-baserade verktyg. Enkelt men inte lämpligt för webben eller molnet.
- **SSE (Server-Sent Events)**: Tillåter servrar att skicka realtidsuppdateringar till klienter över HTTP. Bra för webbgränssnitt, men begränsad i skalbarhet och flexibilitet.
- **Streamable HTTP**: Modern HTTP-baserad strömnings-transport som stödjer notifikationer och bättre skalbarhet. Rekommenderas för de flesta produktions- och molnscenarier.

### Jämförelsetabell

Ta en titt på jämförelsetabellen nedan för att förstå skillnaderna mellan dessa transportmekanismer:

| Transport         | Realtidsuppdateringar | Strömning | Skalbarhet | Användningsområde       |
|-------------------|-----------------------|-----------|------------|------------------------|
| stdio             | Nej                   | Nej       | Låg        | Lokala CLI-verktyg     |
| SSE               | Ja                    | Ja        | Medel      | Webb, realtidsuppdateringar |
| Streamable HTTP   | Ja                    | Ja        | Hög        | Moln, flera klienter   |

> **Tip:** Valet av rätt transport påverkar prestanda, skalbarhet och användarupplevelse. **Streamable HTTP** rekommenderas för moderna, skalbara och molnanpassade applikationer.

Observera transporterna stdio och SSE som du såg i tidigare kapitel och hur streamable HTTP är transporten som behandlas i detta kapitel.

## Strömning: Begrepp och motivation

Att förstå de grundläggande begreppen och motivationen bakom strömning är avgörande för att implementera effektiva realtidskommunikationssystem.

**Strömning** är en teknik inom nätverksprogrammering som tillåter data att skickas och tas emot i små, hanterbara delar eller som en sekvens av händelser, istället för att vänta på att hela svaret ska vara klart. Detta är särskilt användbart för:

- Stora filer eller datamängder.
- Realtidsuppdateringar (t.ex. chatt, progressindikatorer).
- Långvariga beräkningar där man vill hålla användaren informerad.

Här är vad du behöver veta om strömning på en övergripande nivå:

- Data levereras successivt, inte allt på en gång.
- Klienten kan bearbeta data i takt med att den anländer.
- Minskar upplevd fördröjning och förbättrar användarupplevelsen.

### Varför använda strömning?

Anledningarna till att använda strömning är följande:

- Användare får omedelbar återkoppling, inte bara i slutet.
- Möjliggör realtidsapplikationer och responsiva gränssnitt.
- Effektivare användning av nätverks- och beräkningsresurser.

### Enkelt exempel: HTTP Streaming Server & Klient

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

Detta exempel visar en server som skickar en serie meddelanden till klienten i takt med att de blir tillgängliga, istället för att vänta på att alla meddelanden ska vara klara.

**Så här fungerar det:**
- Servern skickar varje meddelande när det är klart.
- Klienten tar emot och skriver ut varje del så fort den anländer.

**Krav:**
- Servern måste använda en strömmande respons (t.ex. `StreamingResponse` in FastAPI).
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

- **För enkla strömningsbehov:** Klassisk HTTP-strömning är enklare att implementera och tillräckligt för grundläggande behov.

- **För komplexa, interaktiva applikationer:** MCP-strömning ger en mer strukturerad metod med rikare metadata och separation mellan notifikationer och slutresultat.

- **För AI-applikationer:** MCP:s notifikationssystem är särskilt användbart för långvariga AI-uppgifter där man vill hålla användarna informerade om framsteg.

## Strömning i MCP

Okej, du har sett några rekommendationer och jämförelser hittills om skillnaden mellan klassisk strömning och strömning i MCP. Låt oss gå in på detaljer om hur du kan använda strömning i MCP.

Att förstå hur strömning fungerar inom MCP-ramverket är avgörande för att bygga responsiva applikationer som ger realtidsåterkoppling till användare under långvariga operationer.

I MCP handlar strömning inte om att skicka huvudsvar i delar, utan om att skicka **notifikationer** till klienten medan ett verktyg bearbetar en förfrågan. Dessa notifikationer kan innehålla statusuppdateringar, loggar eller andra händelser.

### Så här fungerar det

Huvudresultatet skickas fortfarande som ett enda svar. Dock kan notifikationer skickas som separata meddelanden under bearbetningen och därigenom uppdatera klienten i realtid. Klienten måste kunna hantera och visa dessa notifikationer.

## Vad är en notifikation?

Vi nämnde "Notifikation", vad betyder det i MCP-sammanhang?

En notifikation är ett meddelande som skickas från servern till klienten för att informera om framsteg, status eller andra händelser under en långvarig operation. Notifikationer ökar transparensen och förbättrar användarupplevelsen.

Till exempel ska en klient skicka en notifikation när den initiala handskakningen med servern är klar.

En notifikation ser ut så här som ett JSON-meddelande:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikationer tillhör ett ämne i MCP som kallas ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

För att få logging att fungera måste servern aktivera det som en funktion/kapacitet på detta sätt:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Beroende på vilken SDK som används kan logging vara aktiverat som standard, eller så kan du behöva aktivera det explicit i serverns konfiguration.

Det finns olika typer av notifikationer:

| Nivå      | Beskrivning                  | Exempel på användning          |
|-----------|------------------------------|-------------------------------|
| debug     | Detaljerad felsökningsinformation | Funktionsin- och utgångspunkter |
| info      | Allmänna informationsmeddelanden | Uppdateringar om processens framsteg |
| notice    | Normala men viktiga händelser | Konfigurationsändringar        |
| warning   | Varningsmeddelanden          | Användning av föråldrad funktion |
| error     | Felmeddelanden              | Fel i operationer              |
| critical  | Kritiska tillstånd           | Fel i systemkomponenter       |
| alert     | Åtgärd måste vidtas omedelbart | Upptäckt datakorruption       |
| emergency | Systemet är obrukbart        | Total systemkrasch            |

## Implementera notifikationer i MCP

För att implementera notifikationer i MCP behöver du konfigurera både server- och klientsidan för att hantera realtidsuppdateringar. Detta gör att din applikation kan ge omedelbar återkoppling till användare under långvariga operationer.

### Serversidan: Skicka notifikationer

Vi börjar med serversidan. I MCP definierar du verktyg som kan skicka notifikationer medan de bearbetar förfrågningar. Servern använder kontextobjektet (vanligtvis `ctx`) för att skicka meddelanden till klienten.

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

I föregående exempel använder `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Klientsidan: Ta emot notifikationer

Klienten måste implementera en meddelandehanterare för att bearbeta och visa notifikationer i takt med att de anländer.

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

I koden ovan använder `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) och din klient implementerar en meddelandehanterare för att bearbeta notifikationer.

## Framstegsnotifikationer & scenarier

Denna sektion förklarar konceptet med framstegsnotifikationer i MCP, varför de är viktiga och hur man implementerar dem med Streamable HTTP. Du hittar även en praktisk uppgift för att förstärka din förståelse.

Framstegsnotifikationer är realtidsmeddelanden som skickas från servern till klienten under långvariga operationer. Istället för att vänta på att hela processen ska avslutas, håller servern klienten uppdaterad om aktuell status. Detta förbättrar transparens, användarupplevelse och gör felsökning enklare.

**Exempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Varför använda framstegsnotifikationer?

Framstegsnotifikationer är viktiga av flera skäl:

- **Bättre användarupplevelse:** Användare ser uppdateringar medan arbetet pågår, inte bara i slutet.
- **Realtidsåterkoppling:** Klienter kan visa progressindikatorer eller loggar, vilket gör appen mer responsiv.
- **Enklare felsökning och övervakning:** Utvecklare och användare kan se var en process eventuellt är långsam eller fastnar.

### Hur man implementerar framstegsnotifikationer

Så här kan du implementera framstegsnotifikationer i MCP:

- **På servern:** Använd `ctx.info()` or `ctx.log()` för att skicka notifikationer i takt med att varje objekt bearbetas. Detta skickar ett meddelande till klienten innan huvudresultatet är klart.
- **På klienten:** Implementera en meddelandehanterare som lyssnar på och visar notifikationer i takt med att de anländer. Denna hanterare skiljer på notifikationer och slutresultatet.

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

När man implementerar MCP-servrar med HTTP-baserade transporter blir säkerheten en avgörande fråga som kräver noggrann uppmärksamhet på flera angreppsvektorer och skyddsmekanismer.

### Översikt

Säkerhet är kritiskt när MCP-servrar exponeras över HTTP. Streamable HTTP introducerar nya angreppsytor och kräver noggrann konfiguration.

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
2. **Update client code** to use `streamablehttp_client` istället för SSE-klient.
3. **Implementera en meddelandehanterare** i klienten för att bearbeta notifikationer.
4. **Testa kompatibilitet** med befintliga verktyg och arbetsflöden.

### Upprätthålla kompatibilitet

Det rekommenderas att behålla kompatibilitet med befintliga SSE-klienter under migreringsprocessen. Här är några strategier:

- Du kan stödja både SSE och Streamable HTTP genom att köra båda transporterna på olika endpoints.
- Migrera klienter gradvis till den nya transporten.

### Utmaningar

Se till att hantera följande utmaningar under migreringen:

- Säkerställ att alla klienter uppdateras
- Hantera skillnader i leverans av notifikationer

### Uppgift: Bygg din egen strömmande MCP-app

**Scenario:**
Bygg en MCP-server och klient där servern bearbetar en lista med objekt (t.ex. filer eller dokument) och skickar en notifikation för varje objekt som bearbetas. Klienten ska visa varje notifikation när den anländer.

**Steg:**

1. Implementera ett serververktyg som bearbetar en lista och skickar notifikationer för varje objekt.
2. Implementera en klient med en meddelandehanterare som visar notifikationer i realtid.
3. Testa din implementation genom att köra både server och klient och observera notifikationerna.

[Lösning](./solution/README.md)

## Vidare läsning & vad händer sen?

För att fortsätta din resa med MCP-strömning och utöka din kunskap erbjuder denna sektion ytterligare resurser och förslag på nästa steg för att bygga mer avancerade applikationer.

### Vidare läsning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Vad händer sen?

- Prova att bygga mer avancerade MCP-verktyg som använder strömning för realtidsanalys, chatt eller samredigering.
- Utforska integration av MCP-strömning med frontend-ramverk (React, Vue, etc.) för liveuppdateringar i användargränssnitt.
- Nästa: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess ursprungliga språk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.