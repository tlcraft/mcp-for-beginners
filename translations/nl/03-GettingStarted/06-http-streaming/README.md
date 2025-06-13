<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:46:16+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "nl"
}
-->
# HTTPS Streaming met Model Context Protocol (MCP)

Dit hoofdstuk biedt een uitgebreide handleiding voor het implementeren van veilige, schaalbare en realtime streaming met het Model Context Protocol (MCP) via HTTPS. Het behandelt de motivatie voor streaming, de beschikbare transportmechanismen, hoe je streamable HTTP in MCP implementeert, beveiligingsrichtlijnen, migratie van SSE, en praktische tips voor het bouwen van je eigen streaming MCP-applicaties.

## Transportmechanismen en Streaming in MCP

Deze sectie onderzoekt de verschillende transportmechanismen die beschikbaar zijn in MCP en hun rol bij het mogelijk maken van streaming voor realtime communicatie tussen clients en servers.

### Wat is een Transportmechanisme?

Een transportmechanisme bepaalt hoe data wordt uitgewisseld tussen client en server. MCP ondersteunt meerdere transporttypen om aan verschillende omgevingen en eisen te voldoen:

- **stdio**: Standaard in-/uitvoer, geschikt voor lokale en CLI-gebaseerde tools. Eenvoudig, maar niet geschikt voor web of cloud.
- **SSE (Server-Sent Events)**: Hiermee kunnen servers realtime updates naar clients pushen via HTTP. Goed voor web-UI’s, maar beperkt in schaalbaarheid en flexibiliteit.
- **Streamable HTTP**: Moderne op HTTP gebaseerde streaming transport, ondersteunt notificaties en betere schaalbaarheid. Aanbevolen voor de meeste productie- en cloudscenario’s.

### Vergelijkingstabel

Bekijk de onderstaande vergelijkingstabel om de verschillen tussen deze transportmechanismen te begrijpen:

| Transport         | Realtime Updates | Streaming | Schaalbaarheid | Gebruikssituatie          |
|-------------------|------------------|-----------|----------------|--------------------------|
| stdio             | Nee              | Nee       | Laag           | Lokale CLI-tools         |
| SSE               | Ja               | Ja        | Gemiddeld      | Web, realtime updates    |
| Streamable HTTP   | Ja               | Ja        | Hoog           | Cloud, meerdere clients  |

> **Tip:** De keuze van het juiste transport beïnvloedt prestaties, schaalbaarheid en gebruikerservaring. **Streamable HTTP** wordt aanbevolen voor moderne, schaalbare en cloudklare applicaties.

Let op de transports stdio en SSE die je in eerdere hoofdstukken hebt gezien, en hoe streamable HTTP het transport is dat in dit hoofdstuk wordt behandeld.

## Streaming: Concepten en Motivatie

Het begrijpen van de fundamentele concepten en motivaties achter streaming is essentieel voor het implementeren van effectieve realtime communicatiesystemen.

**Streaming** is een techniek in netwerkprogrammering waarbij data in kleine, beheersbare stukjes of als een reeks gebeurtenissen wordt verzonden en ontvangen, in plaats van te wachten tot de volledige respons klaar is. Dit is vooral nuttig voor:

- Grote bestanden of datasets.
- Realtime updates (bijv. chat, voortgangsbalken).
- Langdurige berekeningen waarbij je de gebruiker op de hoogte wilt houden.

Dit moet je op hoofdlijnen weten over streaming:

- Data wordt geleidelijk geleverd, niet in één keer.
- De client kan data verwerken zodra het binnenkomt.
- Vermindert waargenomen vertraging en verbetert gebruikerservaring.

### Waarom streaming gebruiken?

De redenen om streaming te gebruiken zijn:

- Gebruikers krijgen direct feedback, niet pas aan het einde
- Maakt realtime applicaties en responsieve UI’s mogelijk
- Efficiënter gebruik van netwerk- en rekenmiddelen

### Eenvoudig voorbeeld: HTTP Streaming Server & Client

Hier is een eenvoudig voorbeeld van hoe streaming geïmplementeerd kan worden:

<details>
<summary>Python</summary>

**Server (Python, met FastAPI en StreamingResponse):**
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

**Client (Python, met requests):**
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

Dit voorbeeld laat zien hoe een server een reeks berichten naar de client stuurt zodra ze beschikbaar zijn, in plaats van te wachten tot alle berichten klaar zijn.

**Hoe werkt het:**
- De server levert elk bericht zodra het klaar is.
- De client ontvangt en toont elk stuk zodra het binnenkomt.

**Vereisten:**
- De server moet een streaming response gebruiken (bijv. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) in plaats van streaming via MCP te kiezen.

- **Voor eenvoudige streamingbehoeften:** Klassieke HTTP streaming is eenvoudiger te implementeren en voldoende voor basis streaming.

- **Voor complexe, interactieve applicaties:** MCP streaming biedt een meer gestructureerde aanpak met rijkere metadata en scheiding tussen notificaties en eindresultaten.

- **Voor AI-toepassingen:** Het notificatiesysteem van MCP is vooral handig bij langdurige AI-taken waarbij je gebruikers op de hoogte wilt houden van de voortgang.

## Streaming in MCP

Oké, je hebt tot nu toe aanbevelingen en vergelijkingen gezien over het verschil tussen klassieke streaming en streaming in MCP. Laten we nu precies bekijken hoe je streaming in MCP kunt benutten.

Begrijpen hoe streaming werkt binnen het MCP-framework is essentieel voor het bouwen van responsieve applicaties die realtime feedback geven tijdens langdurige bewerkingen.

In MCP gaat streaming niet over het verzenden van de hoofdresponse in stukjes, maar over het sturen van **notificaties** naar de client terwijl een tool een verzoek verwerkt. Deze notificaties kunnen voortgangsupdates, logs of andere gebeurtenissen bevatten.

### Hoe werkt het

Het hoofdresultaat wordt nog steeds als één respons verzonden. Notificaties kunnen echter als aparte berichten tijdens de verwerking worden gestuurd en zo de client realtime bijwerken. De client moet in staat zijn deze notificaties te verwerken en weer te geven.

## Wat is een Notificatie?

We noemden "Notificatie", wat betekent dat in de context van MCP?

Een notificatie is een bericht dat de server naar de client stuurt om te informeren over voortgang, status of andere gebeurtenissen tijdens een langdurige operatie. Notificaties verbeteren transparantie en gebruikerservaring.

Bijvoorbeeld, een client moet een notificatie sturen zodra de initiële handshake met de server is gemaakt.

Een notificatie ziet er zo uit als een JSON-bericht:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notificaties horen bij een onderwerp in MCP dat ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) wordt genoemd.

Om logging te laten werken, moet de server het als feature/capability inschakelen zoals hieronder:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Afhankelijk van de gebruikte SDK kan logging standaard ingeschakeld zijn, of moet je het expliciet aanzetten in je serverconfiguratie.

Er zijn verschillende soorten notificaties:

| Niveau     | Beschrijving                  | Voorbeeldgebruik               |
|------------|------------------------------|-------------------------------|
| debug      | Gedetailleerde debuginformatie | Functie binnenkomst/exit      |
| info       | Algemene informatieve berichten | Voortgangsupdates operatie    |
| notice     | Normale maar belangrijke gebeurtenissen | Configuratie wijzigingen     |
| warning    | Waarschuwingscondities        | Gebruik van verouderde functies|
| error      | Foutcondities                | Foutmeldingen bij operatie    |
| critical   | Kritieke condities           | Systeemcomponentstoringen     |
| alert      | Onmiddellijke actie vereist | Detectie van datacorruptie    |
| emergency  | Systeem is onbruikbaar       | Volledige systeemuitval       |

## Notificaties implementeren in MCP

Om notificaties in MCP te implementeren, moet je zowel de server- als clientzijde instellen om realtime updates te verwerken. Zo kan je applicatie gebruikers direct feedback geven tijdens langdurige bewerkingen.

### Serverzijde: Notificaties verzenden

Laten we beginnen bij de serverzijde. In MCP definieer je tools die notificaties kunnen sturen tijdens het verwerken van verzoeken. De server gebruikt het contextobject (meestal `ctx`) om berichten naar de client te sturen.

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

In het voorgaande voorbeeld gebruikt de `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Clientzijde: Notificaties ontvangen

De client moet een message handler implementeren om notificaties te verwerken en weer te geven zodra ze binnenkomen.

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

In de bovenstaande code gebruikt de `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) en implementeert je client een message handler om notificaties te verwerken.

## Voortgangsnotificaties & Scenario’s

Deze sectie legt het concept van voortgangsnotificaties in MCP uit, waarom ze belangrijk zijn en hoe je ze implementeert met Streamable HTTP. Ook is er een praktische opdracht om je begrip te versterken.

Voortgangsnotificaties zijn realtime berichten die de server naar de client stuurt tijdens langdurige operaties. In plaats van te wachten tot het hele proces klaar is, houdt de server de client op de hoogte van de huidige status. Dit verbetert transparantie, gebruikerservaring en maakt debuggen eenvoudiger.

**Voorbeeld:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Waarom voortgangsnotificaties gebruiken?

Voortgangsnotificaties zijn om verschillende redenen belangrijk:

- **Betere gebruikerservaring:** Gebruikers zien updates terwijl het werk vordert, niet alleen aan het einde.
- **Realtime feedback:** Clients kunnen voortgangsbalken of logs tonen, waardoor de app responsief aanvoelt.
- **Eenvoudiger debuggen en monitoren:** Ontwikkelaars en gebruikers kunnen zien waar een proces traag is of vastloopt.

### Hoe voortgangsnotificaties implementeren

Zo kun je voortgangsnotificaties in MCP implementeren:

- **Op de server:** Gebruik `ctx.info()` or `ctx.log()` om notificaties te sturen terwijl elk item wordt verwerkt. Dit stuurt een bericht naar de client voordat het hoofdresultaat klaar is.
- **Op de client:** Implementeer een message handler die luistert naar en notificaties toont zodra ze binnenkomen. Deze handler maakt onderscheid tussen notificaties en het eindresultaat.

**Servervoorbeeld:**

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

**Clientvoorbeeld:**

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

## Beveiligingsoverwegingen

Bij het implementeren van MCP-servers met HTTP-gebaseerde transports is beveiliging een cruciale zorg die aandacht vraagt voor verschillende aanvalsvectoren en beschermingsmechanismen.

### Overzicht

Beveiliging is essentieel wanneer MCP-servers via HTTP worden aangeboden. Streamable HTTP brengt nieuwe aanvalsvlakken mee en vereist zorgvuldige configuratie.

### Belangrijke punten
- **Validatie van de Origin-header**: Valideer altijd de `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` in plaats van SSE client.
3. **Implementeer een message handler** in de client om notificaties te verwerken.
4. **Test op compatibiliteit** met bestaande tools en workflows.

### Compatibiliteit behouden

Het is aan te raden om compatibiliteit met bestaande SSE-clients te behouden tijdens het migratieproces. Enkele strategieën:

- Je kunt zowel SSE als Streamable HTTP ondersteunen door beide transports op verschillende endpoints te draaien.
- Migreer clients geleidelijk naar het nieuwe transport.

### Uitdagingen

Zorg ervoor dat je de volgende uitdagingen tijdens migratie aanpakt:

- Alle clients updaten
- Omgaan met verschillen in notificatielevering

### Opdracht: Bouw je eigen streaming MCP-app

**Scenario:**
Bouw een MCP-server en client waarbij de server een lijst items (bijv. bestanden of documenten) verwerkt en voor elk verwerkt item een notificatie stuurt. De client toont elke notificatie zodra deze binnenkomt.

**Stappen:**

1. Implementeer een servertool die een lijst verwerkt en voor elk item notificaties stuurt.
2. Implementeer een client met een message handler die notificaties realtime toont.
3. Test je implementatie door zowel server als client te draaien en observeer de notificaties.

[Oplossing](./solution/README.md)

## Verder lezen & Wat nu?

Om je reis met MCP streaming voort te zetten en je kennis uit te breiden, biedt deze sectie aanvullende bronnen en suggesties voor volgende stappen bij het bouwen van geavanceerdere applicaties.

### Verder lezen

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Wat nu?

- Probeer geavanceerdere MCP-tools te bouwen die streaming gebruiken voor realtime analytics, chat of collaboratief bewerken.
- Verken de integratie van MCP streaming met frontend frameworks (React, Vue, etc.) voor live UI-updates.
- Volgende stap: [Gebruik van AI Toolkit voor VSCode](../07-aitk/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal dient als de gezaghebbende bron te worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.