<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:16:56+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fi"
}
-->
# HTTPS-suoratoisto Model Context Protocolin (MCP) kanssa

Tässä luvussa annetaan kattava opas turvallisen, skaalautuvan ja reaaliaikaisen suoratoiston toteuttamiseen Model Context Protocolin (MCP) avulla HTTPS:n yli. Käsitellään suoratoiston taustaa, käytettävissä olevia siirtomekanismeja, streamattavan HTTP:n toteutusta MCP:ssä, turvallisuusohjeita, siirtymistä SSE:stä sekä käytännön ohjeita omien suoratoistavien MCP-sovellusten rakentamiseen.

## Siirtomekanismit ja suoratoisto MCP:ssä

Tässä osiossa tarkastellaan MCP:ssä käytettävissä olevia erilaisia siirtomekanismeja ja niiden roolia suoratoisto-ominaisuuksien mahdollistamisessa reaaliaikaiseen viestintään asiakkaiden ja palvelimien välillä.

### Mikä on siirtomekanismi?

Siirtomekanismi määrittelee, miten data vaihtuu asiakkaan ja palvelimen välillä. MCP tukee useita siirtotyyppejä erilaisiin ympäristöihin ja tarpeisiin:

- **stdio**: Standard input/output, sopii paikallisiin ja komentorivityökaluihin. Yksinkertainen, mutta ei sovellu web- tai pilviympäristöihin.
- **SSE (Server-Sent Events)**: Mahdollistaa palvelimen työntää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli. Hyvä web-käyttöliittymiin, mutta rajallinen skaalautuvuuden ja joustavuuden osalta.
- **Streamable HTTP**: Moderni HTTP-pohjainen suoratoistosiirto, tukee ilmoituksia ja parempaa skaalautuvuutta. Suositeltava useimpiin tuotanto- ja pilvitilanteisiin.

### Vertailutaulukko

Katso alla oleva vertailutaulukko ymmärtääksesi näiden siirtomekanismien erot:

| Siirto            | Reaaliaikaiset päivitykset | Suoratoisto | Skaalautuvuus | Käyttötarkoitus          |
|-------------------|----------------------------|-------------|---------------|-------------------------|
| stdio             | Ei                         | Ei          | Matala        | Paikalliset CLI-työkalut|
| SSE               | Kyllä                      | Kyllä       | Keskitaso     | Web, reaaliaikaiset päivitykset |
| Streamable HTTP   | Kyllä                      | Kyllä       | Korkea        | Pilvi, moniasiakas       |

> **Vinkki:** Oikean siirtomekanismin valinta vaikuttaa suorituskykyyn, skaalautuvuuteen ja käyttökokemukseen. **Streamable HTTP** on suositeltava nykyaikaisiin, skaalautuviin ja pilviyhteensopiviin sovelluksiin.

Huomaa edellisissä luvuissa esitellyt stdio ja SSE siirtomekanismit sekä se, että tässä luvussa käsitellään streamable HTTP -siirtoa.

## Suoratoisto: käsitteet ja tausta

Peruskäsitteiden ja suoratoiston taustan ymmärtäminen on olennaista tehokkaiden reaaliaikaisten viestintäjärjestelmien toteuttamiseksi.

**Suoratoisto** on verkko-ohjelmoinnin tekniikka, jossa dataa lähetetään ja vastaanotetaan pieninä, hallittavina paloina tai tapahtumina sen sijaan, että odotettaisiin koko vastauksen valmistumista. Tämä on erityisen hyödyllistä:

- Suurten tiedostojen tai tietoaineistojen käsittelyssä.
- Reaaliaikaisissa päivityksissä (esim. chat, edistymispalkit).
- Pitkäkestoisissa laskutoimituksissa, joissa käyttäjälle halutaan antaa jatkuvaa tietoa.

Tässä tärkeimmät asiat suoratoistosta yleisellä tasolla:

- Data toimitetaan vaiheittain, ei kerralla.
- Asiakas voi käsitellä dataa sitä mukaa kun se saapuu.
- Vähentää koettua viivettä ja parantaa käyttökokemusta.

### Miksi käyttää suoratoistoa?

Suoratoiston käytön syyt ovat seuraavat:

- Käyttäjät saavat palautetta välittömästi, eivät vain lopussa
- Mahdollistaa reaaliaikaiset sovellukset ja responsiiviset käyttöliittymät
- Tehokkaampi verkon ja laskentaresurssien käyttö

### Yksinkertainen esimerkki: HTTP-suoratoistopalvelin ja asiakas

Tässä yksinkertainen esimerkki suoratoiston toteutuksesta:

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

**Asiakas (Python, requests):**
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

Tässä esimerkissä palvelin lähettää sarjan viestejä asiakkaalle sitä mukaa kun ne valmistuvat sen sijaan, että odottaisi kaikkien viestien valmistumista.

**Miten se toimii:**
- Palvelin tuottaa jokaisen viestin sitä mukaa kun se on valmis.
- Asiakas vastaanottaa ja tulostaa jokaisen palan sitä mukaa kun se saapuu.

**Vaadittavat asiat:**
- Palvelimen tulee käyttää suoratoistovastausta (esim. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) sen sijaan, että valitsee suoratoiston MCP:n kautta.

- **Yksinkertaisiin suoratoistotarpeisiin:** Klassinen HTTP-suoratoisto on helpompi toteuttaa ja riittää peruskäyttöön.

- **Monimutkaisiin, interaktiivisiin sovelluksiin:** MCP-suoratoisto tarjoaa rakenteellisemman lähestymistavan, jossa on rikkaampi metadata ja erottelu ilmoitusten ja lopullisten tulosten välillä.

- **AI-sovelluksiin:** MCP:n ilmoitusjärjestelmä on erityisen hyödyllinen pitkäkestoisissa tekoälytehtävissä, joissa halutaan pitää käyttäjät ajan tasalla edistymisestä.

## Suoratoisto MCP:ssä

Olet nähnyt tähän mennessä suosituksia ja vertailuja klassisen suoratoiston ja MCP-suoratoiston välillä. Tarkastellaan nyt tarkemmin, miten suoratoistoa voi hyödyntää MCP:ssä.

MCP-kehyksen sisällä suoratoiston ymmärtäminen on tärkeää, jotta voi rakentaa responsiivisia sovelluksia, jotka tarjoavat reaaliaikaista palautetta käyttäjille pitkäkestoisten operaatioiden aikana.

MCP:ssä suoratoisto ei tarkoita päävastauksen lähettämistä paloissa, vaan **ilmoitusten** lähettämistä asiakkaalle työkalun käsitellessä pyyntöä. Nämä ilmoitukset voivat sisältää edistymispäivityksiä, lokeja tai muita tapahtumia.

### Miten se toimii

Pääasiallinen tulos lähetetään yhä yhtenä vastauksena. Ilmoituksia voidaan kuitenkin lähettää erillisinä viesteinä käsittelyn aikana, jolloin asiakas saa päivityksiä reaaliajassa. Asiakkaan on kyettävä käsittelemään ja näyttämään nämä ilmoitukset.

## Mikä on ilmoitus?

Käytimme termiä "ilmoitus", mutta mitä se tarkoittaa MCP:n yhteydessä?

Ilmoitus on palvelimen lähettämä viesti asiakkaalle, joka tiedottaa edistymisestä, tilasta tai muista tapahtumista pitkäkestoisen operaation aikana. Ilmoitukset lisäävät läpinäkyvyyttä ja parantavat käyttökokemusta.

Esimerkiksi asiakkaan tulee lähettää ilmoitus, kun alkuperäinen yhteyden muodostus palvelimeen on tehty.

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

Ilmoitukset kuuluvat MCP:n aiheeseen, jota kutsutaan ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Jotta lokitus toimisi, palvelimen täytyy ottaa se käyttöön ominaisuutena/kyvykkyytenä seuraavasti:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Käytetystä SDK:sta riippuen lokitus saattaa olla oletuksena päällä tai se pitää erikseen ottaa käyttöön palvelimen asetuksissa.

Ilmoituksia on eri tasoja:

| Taso      | Kuvaus                         | Esimerkkikäyttö               |
|-----------|--------------------------------|------------------------------|
| debug     | Yksityiskohtaiset virheenkorjaustiedot | Funktioiden sisään-/uloskäynnit |
| info      | Yleiset informatiiviset viestit | Toiminnon edistymispäivitykset |
| notice    | Normaaleja mutta merkittäviä tapahtumia | Konfiguraatiomuutokset       |
| warning   | Varoitustilanteita             | Vanhentuneen ominaisuuden käyttö |
| error     | Virhetilanteita                | Toiminnon epäonnistumiset     |
| critical  | Kriittisiä tiloja              | Järjestelmäkomponenttien virheet |
| alert     | Välitöntä toimintaa vaativa tilanne | Tiedon korruptio havaittu    |
| emergency | Järjestelmä ei käytettävissä   | Täydellinen järjestelmävika  |

## Ilmoitusten toteutus MCP:ssä

Ilmoitusten toteuttamiseksi MCP:ssä on asetettava sekä palvelin- että asiakaspuolet käsittelemään reaaliaikaisia päivityksiä. Tämä mahdollistaa sovelluksellesi välittömän palautteen antamisen käyttäjille pitkäkestoisten operaatioiden aikana.

### Palvelinpuoli: Ilmoitusten lähettäminen

Aloitetaan palvelinpuolelta. MCP:ssä määritellään työkaluja, jotka voivat lähettää ilmoituksia pyynnön käsittelyn aikana. Palvelin käyttää konteksti-oliota (yleensä `ctx`) viestien lähettämiseen asiakkaalle.

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` siirrossa:

```python
mcp.run(transport="streamable-http")
```

</details>

### Asiakaspuoli: Ilmoitusten vastaanottaminen

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

Edellisessä koodissa `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` ja asiakas toteuttaa viestinkäsittelijän ilmoitusten prosessointiin.

## Edistymisilmoitukset ja käyttötapaukset

Tässä osiossa selitetään edistymisilmoitusten käsite MCP:ssä, miksi ne ovat tärkeitä ja miten ne toteutetaan Streamable HTTP:n avulla. Lisäksi mukana on käytännön harjoitus ymmärryksen vahvistamiseksi.

Edistymisilmoitukset ovat reaaliaikaisia viestejä, joita palvelin lähettää asiakkaalle pitkäkestoisten operaatioiden aikana. Sen sijaan, että odotettaisiin koko prosessin valmistumista, palvelin pitää asiakkaan ajan tasalla nykytilanteesta. Tämä parantaa läpinäkyvyyttä, käyttökokemusta ja helpottaa virheiden etsintää.

**Esimerkki:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miksi käyttää edistymisilmoituksia?

Edistymisilmoitukset ovat tärkeitä monesta syystä:

- **Parempi käyttökokemus:** Käyttäjät näkevät päivityksiä työn edetessä, eivät vain lopussa.
- **Reaaliaikainen palaute:** Asiakkaat voivat näyttää edistymispalkkeja tai lokiviestejä, mikä tekee sovelluksesta responsiivisen.
- **Helpompi virheiden etsintä ja seuranta:** Kehittäjät ja käyttäjät näkevät, missä vaiheessa prosessi saattaa hidastua tai jumiutua.

### Miten toteuttaa edistymisilmoitukset

Näin voit toteuttaa edistymisilmoitukset MCP:ssä:

- **Palvelimella:** Käytä `ctx.info()` or `ctx.log()` lähettääksesi ilmoituksia sitä mukaa kun kohteita käsitellään. Tämä lähettää viestin asiakkaalle ennen lopullisen tuloksen valmistumista.
- **Asiakkaalla:** Toteuta viestinkäsittelijä, joka kuuntelee ja näyttää ilmoitukset sitä mukaa kun ne saapuvat. Käsittelijä erottaa ilmoitukset lopullisesta tuloksesta.

**Palvelin-esimerkki:**

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

**Asiakas-esimerkki:**

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

## Turvallisuusnäkökohdat

MCP-palvelimien toteuttamisessa HTTP-pohjaisten siirtojen kanssa turvallisuus on ensiarvoisen tärkeää ja vaatii huolellista huomiointia useiden hyökkäysvektorien ja suojamekanismien osalta.

### Yleiskatsaus

Turvallisuus on kriittinen tekijä, kun MCP-palvelimet altistetaan HTTP:n yli. Streamable HTTP avaa uusia hyökkäyspintoja ja vaatii huolellisen konfiguroinnin.

### Keskeiset asiat
- **Origin-headerin validointi**: Tarkista aina `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` SSE-asiakkaan sijaan.
3. **Toteuta viestinkäsittelijä** asiakkaalle ilmoitusten käsittelyyn.
4. **Testaa yhteensopivuus** olemassa olevien työkalujen ja työnkulkujen kanssa.

### Yhteensopivuuden ylläpito

On suositeltavaa ylläpitää yhteensopivuutta olemassa olevien SSE-asiakkaiden kanssa siirtymävaiheen aikana. Tässä muutamia strategioita:

- Voit tukea sekä SSE:tä että Streamable HTTP:ta ajamalla molempia eri päätepisteissä.
- Siirrä asiakkaita asteittain uuteen siirtotapaan.

### Haasteet

Huolehdi seuraavista haasteista siirtymän aikana:

- Kaikkien asiakkaiden päivittäminen
- Erojen hallinta ilmoitusten toimituksessa

### Harjoitus: Rakenna oma suoratoistava MCP-sovellus

**Tilanne:**
Rakenna MCP-palvelin ja asiakas, jossa palvelin käsittelee listan kohteita (esim. tiedostoja tai dokumentteja) ja lähettää ilmoituksen jokaisen käsitellyn kohteen jälkeen. Asiakkaan tulee näyttää jokainen ilmoitus sitä mukaa kun se saapuu.

**Vaiheet:**

1. Toteuta palvelintyökalu, joka käsittelee listan ja lähettää ilmoituksia jokaisesta kohteesta.
2. Toteuta asiakas, jolla on viestinkäsittelijä ilmoitusten reaaliaikaiseen näyttämiseen.
3. Testaa toteutustasi ajamalla sekä palvelin että asiakas ja seuraa ilmoituksia.

[Ratkaisu](./solution/README.md)

## Lisälukemista & Mitä seuraavaksi?

Jatka matkaasi MCP-suoratoiston parissa ja laajenna osaamistasi tämän osion tarjoamien lisäresurssien ja ehdotettujen seuraavien askelten avulla edistyneempien sovellusten rakentamiseksi.

### Lisälukemista

- [Microsoft: Johdatus HTTP-suoratoistoon](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS ASP.NET Core:ssa](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Suoratoistopyynnöt](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Mitä seuraavaksi?

- Kokeile rakentaa edistyneempiä MCP-työkaluja, jotka käyttävät suoratoistoa reaaliaikaisessa analytiikassa, chatissa tai yhteismuokkauksessa.
- Tutustu MCP-suoratoiston integrointiin frontend-kehyksiin (React, Vue jne.) live-käyttöliittymäpäivityksiä varten.
- Seuraavaksi: [AI Toolkitin hyödyntäminen VSCode:ssa](../07-aitk/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää ensisijaisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinkäsityksistä tai virhetulkinnoista.