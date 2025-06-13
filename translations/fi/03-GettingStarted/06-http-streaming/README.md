<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:45:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fi"
}
-->
# HTTPS-suoratoisto Model Context Protocolilla (MCP)

Tässä luvussa annetaan kattava opas turvallisen, skaalautuvan ja reaaliaikaisen suoratoiston toteuttamiseen Model Context Protocolin (MCP) avulla HTTPS:n yli. Käsitellään suoratoiston taustaa, käytettävissä olevia siirtomekanismeja, suoratoistettavan HTTP:n toteutusta MCP:ssä, turvallisuusohjeita, siirtymistä SSE:stä sekä käytännön ohjeita oman suoratoistavan MCP-sovelluksen rakentamiseen.

## Siirtomekanismit ja suoratoisto MCP:ssä

Tässä osiossa tarkastellaan MCP:ssä käytettävissä olevia eri siirtomekanismeja ja niiden roolia suoratoistomahdollisuuksien tarjoamisessa reaaliaikaiseen viestintään asiakkaiden ja palvelimien välillä.

### Mikä on siirtomekanismi?

Siirtomekanismi määrittelee, miten dataa vaihdetaan asiakkaan ja palvelimen välillä. MCP tukee useita siirtotyyppejä erilaisiin ympäristöihin ja tarpeisiin:

- **stdio**: Standardisyöte/-tulo, sopii paikallisiin ja komentorivityökaluihin. Yksinkertainen, mutta ei sovellu web- tai pilviympäristöihin.
- **SSE (Server-Sent Events)**: Palvelimet voivat työntää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli. Hyvä web-käyttöliittymiin, mutta skaalautuvuus ja joustavuus ovat rajallisia.
- **Streamable HTTP**: Moderni HTTP-pohjainen suoratoistomekanismi, tukee ilmoituksia ja parempaa skaalautuvuutta. Suositeltava useimpiin tuotanto- ja pilvikäyttöihin.

### Vertailutaulukko

Tarkastele alla olevaa vertailutaulukkoa ymmärtääksesi näiden siirtomekanismien erot:

| Siirto            | Reaaliaikaiset päivitykset | Suoratoisto | Skaalautuvuus | Käyttötarkoitus           |
|-------------------|----------------------------|-------------|---------------|--------------------------|
| stdio             | Ei                         | Ei          | Matala        | Paikalliset komentorivityökalut |
| SSE               | Kyllä                      | Kyllä       | Keskitaso     | Web, reaaliaikaiset päivitykset |
| Streamable HTTP   | Kyllä                      | Kyllä       | Korkea        | Pilvi, moniasiakasympäristöt |

> **Vinkki:** Oikean siirtomekanismin valinta vaikuttaa suorituskykyyn, skaalautuvuuteen ja käyttökokemukseen. **Streamable HTTP** on suositeltava nykyaikaisiin, skaalautuviin ja pilvivalmiisiin sovelluksiin.

Huomaa aiemmissa luvuissa esitellyt stdio- ja SSE-siirrot sekä tässä luvussa käsitelty streamable HTTP -siirto.

## Suoratoisto: käsitteet ja motivaatio

Suoratoiston peruskäsitteiden ja motiivien ymmärtäminen on olennaista tehokkaiden reaaliaikaisten viestintäjärjestelmien toteuttamiseksi.

**Suoratoisto** on verkkosovellusohjelmoinnissa käytetty tekniikka, jossa dataa lähetetään ja vastaanotetaan pienissä, hallittavissa osissa tai tapahtumina sarjana sen sijaan, että odotettaisiin koko vastauksen valmistumista. Tämä on erityisen hyödyllistä:

- Suurten tiedostojen tai tietoaineistojen käsittelyssä.
- Reaaliaikaisissa päivityksissä (esim. chat, etenemispalkit).
- Pitkään kestävissä laskutoimituksissa, joissa käyttäjää halutaan pitää ajan tasalla.

Tässä tärkeimmät asiat suoratoistosta yleisellä tasolla:

- Data toimitetaan asteittain, ei kerralla.
- Asiakas voi käsitellä dataa sitä mukaa kun se saapuu.
- Vähentää koettua viivettä ja parantaa käyttökokemusta.

### Miksi käyttää suoratoistoa?

Suoratoiston käyttämisen syyt ovat seuraavat:

- Käyttäjä saa palautetta heti, ei vasta lopussa.
- Mahdollistaa reaaliaikaiset sovellukset ja reagoivat käyttöliittymät.
- Tehokkaampi verkon ja laskentaresurssien käyttö.

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

**Asiakas (Python, requests-kirjasto):**
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

Tässä esimerkissä palvelin lähettää sarjan viestejä asiakkaalle sitä mukaa kun ne ovat valmiita, sen sijaan että odotettaisiin kaikkien viestien valmistumista.

**Toimintaperiaate:**
- Palvelin tuottaa jokaisen viestin heti kun se on valmis.
- Asiakas vastaanottaa ja tulostaa jokaisen osan sitä mukaa kun se saapuu.

**Vaadittavaa:**
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) eikä valita suoratoistoa MCP:n kautta.

- **Yksinkertaisiin suoratoistotarpeisiin:** Perinteinen HTTP-suoratoisto on helpompi toteuttaa ja riittää perustoimintoihin.

- **Monimutkaisiin, vuorovaikutteisiin sovelluksiin:** MCP-suoratoisto tarjoaa rakenteellisemman lähestymistavan, jossa on rikkaampaa metatietoa sekä ilmoitusten ja lopputulosten erottelu.

- **AI-sovelluksiin:** MCP:n ilmoitusjärjestelmä on erityisen hyödyllinen pitkissä tekoälytehtävissä, joissa käyttäjälle halutaan välittää etenemispäivityksiä.

## Suoratoisto MCP:ssä

Olet nähnyt suosituksia ja vertailuja perinteisen suoratoiston ja MCP-suoratoiston välillä. Käydään nyt tarkemmin läpi, miten voit hyödyntää suoratoistoa MCP:ssä.

Suoratoiston toimintatavan ymmärtäminen MCP-kehyksessä on tärkeää, jotta voit rakentaa reagoivia sovelluksia, jotka tarjoavat reaaliaikaista palautetta käyttäjille pitkien operaatioiden aikana.

MCP:ssä suoratoisto ei tarkoita päävastauksen lähettämistä paloissa, vaan **ilmoitusten** lähettämistä asiakkaalle työkalun käsitellessä pyyntöä. Nämä ilmoitukset voivat sisältää etenemispäivityksiä, lokitietoja tai muita tapahtumia.

### Miten se toimii

Pääasiallinen tulos lähetetään edelleen yhtenä vastauksena. Ilmoitukset sen sijaan voidaan lähettää erillisinä viesteinä prosessoinnin aikana, jolloin asiakas saa päivityksiä reaaliajassa. Asiakkaan tulee osata käsitellä ja näyttää nämä ilmoitukset.

## Mikä on ilmoitus?

Käytimme termiä "ilmoitus" – mitä se tarkoittaa MCP:n yhteydessä?

Ilmoitus on palvelimen lähettämä viesti asiakkaalle, joka kertoo etenemisestä, tilasta tai muista tapahtumista pitkän prosessin aikana. Ilmoitukset parantavat läpinäkyvyyttä ja käyttökokemusta.

Esimerkiksi asiakas voi lähettää ilmoituksen heti, kun aloitusyhteys palvelimeen on muodostettu.

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

Ilmoitukset kuuluvat MCP:n aihealueeseen nimeltä ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Lokituksen toimimiseksi palvelimen täytyy ottaa se käyttöön ominaisuutena/kyvykkyytenä näin:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Käytetystä SDK:sta riippuen lokitus voi olla oletuksena päällä tai se pitää ottaa erikseen käyttöön palvelimen asetuksissa.

Ilmoituksia on useita tyyppejä:

| Taso       | Kuvaus                        | Esimerkkikäyttö                |
|------------|------------------------------|-------------------------------|
| debug      | Yksityiskohtainen virheenkorjaustieto | Funktioiden sisään-/ulosmenot  |
| info       | Yleiset informatiiviset viestit | Toiminnon etenemispäivitykset  |
| notice     | Normaaleja, mutta merkittäviä tapahtumia | Konfiguraatiomuutokset         |
| warning    | Varoitustilanteet             | Käytöstä poistettujen ominaisuuksien käyttö |
| error      | Virhetilanteet               | Toimintojen epäonnistumiset    |
| critical   | Kriittiset tilanteet          | Järjestelmän osien vikatilanteet |
| alert      | Toimenpiteitä vaativa välitön tilanne | Tiedon korruptio havaittu      |
| emergency  | Järjestelmä käyttökelvoton   | Täydellinen järjestelmän kaatuminen |

## Ilmoitusten toteutus MCP:ssä

Ilmoitusten toteuttamiseksi MCP:ssä sinun tulee valmistella sekä palvelin- että asiakaspuolet käsittelemään reaaliaikaisia päivityksiä. Näin sovelluksesi voi antaa välitöntä palautetta käyttäjälle pitkien operaatioiden aikana.

### Palvelinpuoli: Ilmoitusten lähettäminen

Aloitetaan palvelinpuolelta. MCP:ssä määrittelet työkaluja, jotka voivat lähettää ilmoituksia käsitellessään pyyntöjä. Palvelin käyttää kontekstioliota (yleensä `ctx`) lähettääkseen viestejä asiakkaalle.

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` -siirrossa:

```python
mcp.run(transport="streamable-http")
```

</details>

### Asiakaspuoli: Ilmoitusten vastaanottaminen

Asiakkaan täytyy toteuttaa viestinkäsittelijä, joka käsittelee ja näyttää ilmoitukset sitä mukaa kun ne saapuvat.

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) ja asiakkaasi toteuttaa viestinkäsittelijän ilmoitusten käsittelyyn.

## Etenemisilmoitukset ja käyttötapaukset

Tässä osiossa selitetään etenemisilmoitusten käsite MCP:ssä, miksi ne ovat tärkeitä ja miten ne toteutetaan Streamable HTTP:n avulla. Löydät myös käytännön harjoituksen ymmärryksesi vahvistamiseksi.

Etenemisilmoitukset ovat reaaliaikaisia viestejä, joita palvelin lähettää asiakkaalle pitkien operaatioiden aikana. Sen sijaan että odotettaisiin koko prosessin valmistumista, palvelin pitää asiakkaan ajan tasalla nykytilanteesta. Tämä parantaa läpinäkyvyyttä, käyttökokemusta ja helpottaa virheiden jäljittämistä.

**Esimerkki:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miksi käyttää etenemisilmoituksia?

Etenemisilmoitukset ovat tärkeitä useista syistä:

- **Parempi käyttökokemus:** Käyttäjät näkevät päivitykset työn edetessä, eivät vain lopussa.
- **Reaaliaikainen palaute:** Asiakkaat voivat näyttää etenemispalkkeja tai lokeja, mikä tekee sovelluksesta reagoivan.
- **Helpompi virheiden seuranta ja valvonta:** Kehittäjät ja käyttäjät näkevät missä vaiheessa prosessi saattaa hidastua tai jumittua.

### Miten toteuttaa etenemisilmoitukset

Näin voit toteuttaa etenemisilmoitukset MCP:ssä:

- **Palvelimella:** Käytä `ctx.info()` or `ctx.log()` lähettääksesi ilmoituksia sitä mukaa kun kukin kohde käsitellään. Tämä lähettää viestin asiakkaalle ennen päävastauksen valmistumista.
- **Asiakkaalla:** Toteuta viestinkäsittelijä, joka kuuntelee ja näyttää ilmoitukset saapuessaan. Tämä käsittelijä erottaa ilmoitukset ja lopullisen tuloksen.

**Palvelinesimerkki:**

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

Kun toteutat MCP-palvelimia HTTP-pohjaisilla siirroilla, turvallisuus on ensiarvoisen tärkeää ja vaatii huolellista huomiointia moniin hyökkäysvektoreihin ja suojausmekanismeihin.

### Yleiskatsaus

Turvallisuus on kriittistä MCP-palvelimia HTTP:n yli tarjottaessa. Streamable HTTP tuo uusia hyökkäyspintoja ja vaatii tarkkaa konfigurointia.

### Keskeiset kohdat
- **Origin-otsikon tarkistus:** Tarkista aina `Origin` header to prevent DNS rebinding attacks.
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
3. **Toteuta viestinkäsittelijä** asiakkaalle ilmoitusten käsittelyä varten.
4. **Testaa yhteensopivuus** olemassa olevien työkalujen ja työnkulkujen kanssa.

### Yhteensopivuuden ylläpito

Suositellaan ylläpitämään yhteensopivuus nykyisten SSE-asiakkaiden kanssa siirtymävaiheen ajan. Tässä joitakin strategioita:

- Voit tukea sekä SSE:tä että Streamable HTTP:ta ajamalla molempia eri päätepisteissä.
- Siirrä asiakkaita vähitellen uuteen siirtotapaan.

### Haasteet

Varmista, että otat huomioon seuraavat haasteet siirtymävaiheessa:

- Kaikkien asiakkaiden päivittäminen
- Ilmoitusten toimituksen eroavaisuuksien hallinta

### Harjoitus: Rakenna oma suoratoistava MCP-sovellus

**Tilanne:**
Rakenna MCP-palvelin ja asiakas, jossa palvelin käsittelee listan kohteita (esim. tiedostoja tai dokumentteja) ja lähettää ilmoituksen jokaisen käsitellyn kohteen jälkeen. Asiakkaan tulee näyttää ilmoitukset sitä mukaa kun ne saapuvat.

**Vaiheet:**

1. Toteuta palvelintyökalu, joka käsittelee listan ja lähettää ilmoituksia jokaisesta kohteesta.
2. Toteuta asiakas, jossa on viestinkäsittelijä ilmoitusten reaaliaikaista näyttämistä varten.
3. Testaa toteutustasi ajamalla sekä palvelin että asiakas ja seuraa ilmoituksia.

[Ratkaisu](./solution/README.md)

## Lisälukemista & Mitä seuraavaksi?

Jatka MCP-suoratoiston opiskelua ja laajenna osaamistasi tämän osion tarjoamien lisäresurssien ja suositeltujen seuraavien askelten avulla kehittyneempien sovellusten rakentamiseksi.

### Lisälukemista

- [Microsoft: Johdatus HTTP-suoratoistoon](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS ASP.NET Core -sovelluksissa](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Mitä seuraavaksi?

- Kokeile rakentaa kehittyneempiä MCP-työkaluja, jotka käyttävät suoratoistoa reaaliaikaiseen analytiikkaan, chattiin tai yhteismuokkaukseen.
- Tutki MCP-suoratoiston yhdistämistä frontend-kehyksiin (React, Vue jne.) live-käyttöliittymäpäivityksiä varten.
- Seuraavaksi: [AI Toolkitin hyödyntäminen VSCode:ssa](../07-aitk/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on pidettävä virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa mahdollisista väärinymmärryksistä tai tulkinnoista, jotka johtuvat tämän käännöksen käytöstä.