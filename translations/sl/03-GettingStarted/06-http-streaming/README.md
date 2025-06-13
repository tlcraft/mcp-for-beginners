<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:56:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sl"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

Ta poglavje ponuja celovit vodič za implementacijo varnega, razširljivega in realnočasovnega pretakanja z Model Context Protocol (MCP) preko HTTPS. Obravnava motivacijo za pretakanje, razpoložljive transportne mehanizme, kako implementirati streamable HTTP v MCP, varnostne dobre prakse, migracijo iz SSE in praktična navodila za izdelavo lastnih streaming MCP aplikacij.

## Transportni mehanizmi in pretakanje v MCP

Ta razdelek raziskuje različne transportne mehanizme, ki so na voljo v MCP, in njihovo vlogo pri omogočanju streaming funkcionalnosti za realnočasovno komunikacijo med odjemalci in strežniki.

### Kaj je transportni mehanizem?

Transportni mehanizem določa, kako se podatki izmenjujejo med odjemalcem in strežnikom. MCP podpira več vrst transportov, da ustreza različnim okoljem in zahtevam:

- **stdio**: Standardni vhod/izhod, primeren za lokalna orodja in CLI. Preprost, a neprimeren za splet ali oblak.
- **SSE (Server-Sent Events)**: Omogoča strežnikom, da potiskajo realnočasovne posodobitve do odjemalcev preko HTTP. Dobro za spletne uporabniške vmesnike, vendar omejeno glede skalabilnosti in fleksibilnosti.
- **Streamable HTTP**: Sodobni HTTP streaming transport, ki podpira obvestila in boljšo skalabilnost. Priporočeno za večino produkcijskih in oblačnih scenarijev.

### Primerjalna tabela

Oglejte si spodnjo primerjalno tabelo, da razumete razlike med temi transportnimi mehanizmi:

| Transport         | Realnočasovne posodobitve | Pretakanje | Skalabilnost | Uporaba                  |
|-------------------|---------------------------|------------|--------------|--------------------------|
| stdio             | Ne                        | Ne         | Nizka        | Lokalna CLI orodja       |
| SSE               | Da                        | Da         | Srednja      | Splet, realnočasovne posodobitve |
| Streamable HTTP   | Da                        | Da         | Visoka       | Oblačni, več odjemalcev  |

> **Nasvet:** Prava izbira transporta vpliva na zmogljivost, skalabilnost in uporabniško izkušnjo. **Streamable HTTP** je priporočljiv za sodobne, skalabilne in oblačne aplikacije.

Opazite transporte stdio in SSE, ki ste ju videli v prejšnjih poglavjih, ter kako je streamable HTTP transport, obravnavan v tem poglavju.

## Pretakanje: koncepti in motivacija

Razumevanje osnovnih konceptov in motivacij za pretakanje je ključno za učinkovito implementacijo realnočasovnih komunikacijskih sistemov.

**Pretakanje** je tehnika v omrežnem programiranju, ki omogoča pošiljanje in prejemanje podatkov v majhnih, obvladljivih delih ali kot zaporedje dogodkov, namesto da bi čakali na celoten odgovor. To je še posebej uporabno za:

- Velike datoteke ali nabor podatkov.
- Realnočasovne posodobitve (npr. klepet, napredne vrstice).
- Dolgotrajne izračune, kjer želite uporabnika obveščati sproti.

Tukaj so glavne stvari, ki jih morate vedeti o pretakanju:

- Podatki se dostavljajo postopoma, ne vsi naenkrat.
- Odjemalec lahko obdela podatke takoj, ko prispejo.
- Zmanjšuje zaznano zakasnitev in izboljšuje uporabniško izkušnjo.

### Zakaj uporabljati pretakanje?

Razlogi za uporabo pretakanja so naslednji:

- Uporabniki prejmejo povratne informacije takoj, ne šele na koncu.
- Omogoča realnočasovne aplikacije in odzivne uporabniške vmesnike.
- Bolj učinkovita raba omrežnih in računalniških virov.

### Preprost primer: HTTP streaming strežnik in odjemalec

Tukaj je preprost primer, kako lahko implementirate pretakanje:

<details>
<summary>Python</summary>

**Strežnik (Python, z uporabo FastAPI in StreamingResponse):**
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

**Odjemalec (Python, z uporabo requests):**
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

Ta primer prikazuje strežnik, ki pošilja serijo sporočil odjemalcu sproti, namesto da bi čakal, da so vsa sporočila pripravljena.

**Kako deluje:**
- Strežnik sproti pošilja vsako sporočilo, ko je pripravljeno.
- Odjemalec prejema in izpisuje vsak del podatkov takoj, ko prispe.

**Zahteve:**
- Strežnik mora uporabljati streaming odziv (npr. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) namesto izbire streaming preko MCP.

- **Za enostavne potrebe pretakanja:** Klasični HTTP streaming je lažji za implementacijo in zadostuje za osnovne primere.

- **Za kompleksne, interaktivne aplikacije:** MCP streaming nudi bolj strukturiran pristop z bogatejšimi metapodatki in ločitvijo med obvestili in končnimi rezultati.

- **Za AI aplikacije:** MCP-jev sistem obvestil je še posebej uporaben za dolgotrajne AI naloge, kjer želite uporabnike sproti obveščati o napredku.

## Pretakanje v MCP

Torej, videli ste nekaj priporočil in primerjav med klasičnim pretakanjem in pretakanjem v MCP. Poglejmo natančno, kako lahko izkoristite pretakanje v MCP.

Razumevanje, kako pretakanje deluje znotraj MCP okvira, je ključno za gradnjo odzivnih aplikacij, ki uporabnikom nudijo realnočasovne povratne informacije med dolgotrajnimi operacijami.

V MCP pretakanje ni pošiljanje glavnega odgovora v delih, ampak pošiljanje **obvestil** odjemalcu med procesiranjem zahteve. Ta obvestila lahko vključujejo posodobitve napredka, dnevnike ali druge dogodke.

### Kako deluje

Glavni rezultat se še vedno pošlje kot en sam odgovor. Vendar pa se obvestila pošiljajo kot ločena sporočila med procesiranjem in tako sproti obveščajo odjemalca. Odjemalec mora znati obravnavati in prikazovati ta obvestila.

## Kaj je obvestilo?

Rekli smo "obvestilo", kaj to pomeni v kontekstu MCP?

Obvestilo je sporočilo, ki ga strežnik pošlje odjemalcu, da ga obvesti o napredku, stanju ali drugih dogodkih med dolgotrajno operacijo. Obvestila izboljšujejo preglednost in uporabniško izkušnjo.

Na primer, odjemalec naj bi poslal obvestilo, ko je izveden začetni handshake s strežnikom.

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

Obvestila pripadajo temi v MCP, imenovani ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Za delovanje logiranja mora strežnik omogočiti to funkcijo oziroma zmožnost tako:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Odvisno od uporabljenega SDK-ja je lahko logiranje privzeto omogočeno ali pa ga je treba eksplicitno omogočiti v konfiguraciji strežnika.

Obstajajo različne vrste obvestil:

| Raven     | Opis                           | Primer uporabe               |
|-----------|--------------------------------|-----------------------------|
| debug     | Podrobne informacije za odpravljanje napak | Vhodi/izhodi funkcij        |
| info      | Splošna informativna sporočila | Posodobitve napredka operacij |
| notice    | Normalni, a pomembni dogodki    | Spremembe konfiguracije      |
| warning   | Opozorila                      | Uporaba zastarelih funkcij  |
| error     | Napake                        | Neuspehi operacij           |
| critical  | Kritični pogoji                | Napake sistemskih komponent |
| alert     | Potrebno takojšnje ukrepanje  | Zaznana poškodba podatkov   |
| emergency | Sistem ni uporaben            | Popolna odpoved sistema     |

## Implementacija obvestil v MCP

Za implementacijo obvestil v MCP morate nastaviti tako strežniško kot odjemalsko stran za obravnavo realnočasovnih posodobitev. To omogoča vaši aplikaciji, da uporabnikom nudi takojšnje povratne informacije med dolgotrajnimi operacijami.

### Strežniška stran: pošiljanje obvestil

Začnimo s strežniško stranjo. V MCP definirate orodja, ki lahko pošiljajo obvestila med procesiranjem zahtev. Strežnik uporablja kontekstni objekt (običajno `ctx`) za pošiljanje sporočil odjemalcu.

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

V prejšnjem primeru `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Odjemalska stran: prejemanje obvestil

Odjemalec mora implementirati upravljalnik sporočil, ki obdeluje in prikazuje obvestila takoj, ko prispejo.

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

V zgornji kodi `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) in vaš odjemalec implementira upravljalnik sporočil za obdelavo obvestil.

## Obvestila o napredku in scenariji

Ta razdelek pojasnjuje koncept obvestil o napredku v MCP, zakaj so pomembna in kako jih implementirati z uporabo Streamable HTTP. Prav tako vsebuje praktično nalogo za utrjevanje znanja.

Obvestila o napredku so realnočasovna sporočila, ki jih strežnik pošilja odjemalcu med dolgotrajnimi operacijami. Namesto da bi čakali, da se celoten proces zaključi, strežnik sproti obvešča odjemalca o trenutnem stanju. To izboljšuje preglednost, uporabniško izkušnjo in olajša odpravljanje napak.

**Primer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zakaj uporabljati obvestila o napredku?

Obvestila o napredku so ključna iz več razlogov:

- **Boljša uporabniška izkušnja:** Uporabniki vidijo posodobitve med delom, ne šele na koncu.
- **Realnočasovne povratne informacije:** Odjemalci lahko prikazujejo napredne vrstice ali dnevnike, kar naredi aplikacijo bolj odzivno.
- **Lažje odpravljanje napak in nadzor:** Razvijalci in uporabniki lahko vidijo, kje je proces morda počasen ali obstaja težava.

### Kako implementirati obvestila o napredku

Tukaj je, kako lahko implementirate obvestila o napredku v MCP:

- **Na strežniku:** Uporabite `ctx.info()` or `ctx.log()` za pošiljanje obvestil sproti, ko se vsak element obdela. Tako pošljete sporočilo odjemalcu pred glavnimi rezultati.
- **Na odjemalcu:** Implementirajte upravljalnik sporočil, ki posluša in prikazuje obvestila, ko prispejo. Ta upravljalnik loči med obvestili in končnim rezultatom.

**Primer strežnika:**

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

**Primer odjemalca:**

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

## Varnostni vidiki

Pri implementaciji MCP strežnikov z HTTP transporti postane varnost ključna tema, ki zahteva skrbno obravnavo različnih napadalnih vektorjev in zaščitnih mehanizmov.

### Pregled

Varnost je kritična, ko izpostavljate MCP strežnike preko HTTP. Streamable HTTP odpira nove možnosti za napade in zahteva natančno konfiguracijo.

### Ključne točke
- **Preverjanje Origin glave**: Vedno preverite `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` namesto SSE odjemalca.
3. **Implementirajte upravljalnik sporočil** v odjemalcu za obdelavo obvestil.
4. **Preizkusite združljivost** z obstoječimi orodji in delovnimi tokovi.

### Ohranjanje združljivosti

Priporočljivo je ohraniti združljivost z obstoječimi SSE odjemalci med migracijo. Tukaj so nekatere strategije:

- Lahko podpirate oba, SSE in Streamable HTTP, tako da izvajate oba transporta na različnih končnih točkah.
- Postopoma migrirajte odjemalce na nov transport.

### Izzivi

Med migracijo poskrbite za naslednje izzive:

- Zagotovitev, da so vsi odjemalci posodobljeni.
- Obvladovanje razlik v dostavi obvestil.

### Naloga: Naredite svojo streaming MCP aplikacijo

**Scenarij:**
Naredite MCP strežnik in odjemalca, kjer strežnik obdela seznam elementov (npr. datoteke ali dokumente) in pošlje obvestilo za vsak obdelan element. Odjemalec naj prikaže vsako obvestilo takoj, ko prispe.

**Koraki:**

1. Implementirajte strežniško orodje, ki obdela seznam in pošlje obvestila za vsak element.
2. Implementirajte odjemalca z upravljalnikom sporočil, ki v realnem času prikazuje obvestila.
3. Preizkusite implementacijo z zagonom strežnika in odjemalca ter opazujte obvestila.

[Solution](./solution/README.md)

## Nadaljnje branje in kaj sledi?

Za nadaljevanje poti z MCP streamingom in širjenje znanja ta razdelek ponuja dodatne vire in predloge za naslednje korake pri izdelavi bolj naprednih aplikacij.

### Nadaljnje branje

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Kaj sledi?

- Poskusite izdelati bolj napredna MCP orodja, ki uporabljajo pretakanje za realnočasovno analitiko, klepet ali sodelovalno urejanje.
- Raziskujte integracijo MCP streaming s frontend ogrodji (React, Vue itd.) za žive posodobitve uporabniškega vmesnika.
- Naslednje: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.