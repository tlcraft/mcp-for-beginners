<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:55:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sr"
}
-->
# HTTPS Streaming sa Model Context Protocol (MCP)

Ovo poglavlje pruža detaljan vodič za implementaciju sigurnog, skalabilnog i real-time strimovanja pomoću Model Context Protocol (MCP) preko HTTPS-a. Obrađuje motivaciju za strimovanje, dostupne transportne mehanizme, kako implementirati strimabilni HTTP u MCP-u, najbolje sigurnosne prakse, migraciju sa SSE-a i praktične savete za pravljenje sopstvenih strim MCP aplikacija.

## Transportni mehanizmi i strimovanje u MCP-u

Ovaj deo istražuje različite transportne mehanizme dostupne u MCP-u i njihovu ulogu u omogućavanju strimovanja za real-time komunikaciju između klijenata i servera.

### Šta je transportni mehanizam?

Transportni mehanizam definiše kako se podaci razmenjuju između klijenta i servera. MCP podržava više tipova transporta da bi se prilagodio različitim okruženjima i zahtevima:

- **stdio**: Standardni ulaz/izlaz, pogodan za lokalne i CLI alate. Jednostavan, ali nije pogodan za web ili cloud.
- **SSE (Server-Sent Events)**: Omogućava serverima da šalju real-time ažuriranja klijentima preko HTTP-a. Dobar za web interfejse, ali ograničen u skalabilnosti i fleksibilnosti.
- **Streamable HTTP**: Moderan HTTP baziran striming transport, podržava notifikacije i bolju skalabilnost. Preporučuje se za većinu produkcijskih i cloud scenarija.

### Tabela poređenja

Pogledajte tabelu ispod da biste razumeli razlike između ovih transportnih mehanizama:

| Transport         | Real-time Ažuriranja | Strimovanje | Skalabilnost | Upotreba                |
|-------------------|----------------------|-------------|--------------|-------------------------|
| stdio             | Ne                   | Ne          | Niska        | Lokalni CLI alati       |
| SSE               | Da                   | Da          | Srednja      | Web, real-time ažuriranja |
| Streamable HTTP   | Da                   | Da          | Visoka       | Cloud, višekorisnički   |

> **Tip:** Izbor pravog transporta utiče na performanse, skalabilnost i korisničko iskustvo. **Streamable HTTP** je preporuka za moderne, skalabilne i cloud spremne aplikacije.

Obratite pažnju na transport stdio i SSE koji su prikazani u prethodnim poglavljima i kako je streamable HTTP transport obrađen u ovom poglavlju.

## Strimovanje: Koncepti i motivacija

Razumevanje osnovnih koncepata i razloga za strimovanje je ključno za implementaciju efikasnih sistema za real-time komunikaciju.

**Strimovanje** je tehnika u mrežnom programiranju koja omogućava slanje i prijem podataka u malim, upravljivim delovima ili kao niz događaja, umesto da se čeka da ceo odgovor bude spreman. Ovo je posebno korisno za:

- Velike fajlove ili skupove podataka.
- Real-time ažuriranja (npr. chat, progress barovi).
- Dugotrajne proračune gde želite da korisnik bude stalno obavešten.

Evo šta treba da znate o strimovanju na visokom nivou:

- Podaci se isporučuju postepeno, ne odjednom.
- Klijent može obrađivati podatke kako stignu.
- Smanjuje percepciju latencije i poboljšava korisnički doživljaj.

### Zašto koristiti strimovanje?

Razlozi za korišćenje strimovanja su sledeći:

- Korisnici dobijaju povratnu informaciju odmah, ne samo na kraju
- Omogućava real-time aplikacije i responzivne UI-je
- Efikasnija upotreba mrežnih i računarskih resursa

### Jednostavan primer: HTTP Streaming Server & Client

Evo jednostavnog primera kako se strimovanje može implementirati:

<details>
<summary>Python</summary>

**Server (Python, koristeći FastAPI i StreamingResponse):**
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

**Klijent (Python, koristeći requests):**
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

Ovaj primer prikazuje server koji šalje niz poruka klijentu čim postanu dostupne, umesto da čeka da sve poruke budu spremne.

**Kako radi:**
- Server šalje svaku poruku čim je spremna.
- Klijent prima i ispisuje svaki deo čim stigne.

**Zahtevi:**
- Server mora koristiti strim odgovor (npr. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) umesto običnog HTTP odgovora.

- **Za jednostavne potrebe strimovanja:** Klasični HTTP streaming je lakši za implementaciju i dovoljan za osnovne potrebe.

- **Za složenije, interaktivne aplikacije:** MCP streaming nudi strukturiraniji pristup sa bogatijim metapodacima i razdvajanjem između notifikacija i konačnih rezultata.

- **Za AI aplikacije:** MCP-ov sistem notifikacija je naročito koristan za dugotrajne AI zadatke gde želite da korisnike stalno obaveštavate o napretku.

## Strimovanje u MCP-u

Dakle, videli ste preporuke i poređenja između klasičnog strimovanja i strimovanja u MCP-u. Hajde da detaljnije objasnimo kako tačno možete iskoristiti strimovanje u MCP-u.

Razumevanje kako strimovanje funkcioniše unutar MCP okvira je ključno za pravljenje responzivnih aplikacija koje pružaju real-time povratne informacije korisnicima tokom dugotrajnih operacija.

U MCP-u, strimovanje nije slanje glavnog odgovora u delovima, već slanje **notifikacija** klijentu dok alat obrađuje zahtev. Te notifikacije mogu sadržavati ažuriranja napretka, logove ili druge događaje.

### Kako to funkcioniše

Glavni rezultat se i dalje šalje kao jedan odgovor. Međutim, notifikacije se mogu slati kao posebne poruke tokom obrade i tako ažurirati klijenta u realnom vremenu. Klijent mora biti sposoban da obradi i prikaže te notifikacije.

## Šta je notifikacija?

Rekli smo "notifikacija", šta to znači u kontekstu MCP-a?

Notifikacija je poruka koju server šalje klijentu da ga obavesti o napretku, statusu ili drugim događajima tokom dugotrajne operacije. Notifikacije poboljšavaju transparentnost i korisničko iskustvo.

Na primer, klijent treba da pošalje notifikaciju kada je inicijalni dogovor sa serverom završen.

Notifikacija izgleda ovako kao JSON poruka:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikacije pripadaju temi u MCP-u nazvanoj ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Da bi logovanje radilo, server mora omogućiti ovu funkcionalnost kao feature/capability na sledeći način:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> U zavisnosti od korišćenog SDK-a, logovanje može biti omogućeno po defaultu, ili ga je potrebno eksplicitno uključiti u konfiguraciji servera.

Postoje različite vrste notifikacija:

| Nivo       | Opis                         | Primer upotrebe                |
|------------|------------------------------|-------------------------------|
| debug      | Detaljne informacije za debug | Ulaz/izlaz funkcije           |
| info       | Opšte informativne poruke     | Ažuriranja napretka operacije |
| notice     | Normalni, ali značajni događaji | Promene konfiguracije         |
| warning    | Upozorenja                   | Korišćenje zastarelih funkcija|
| error      | Greške                      | Neuspeh operacije             |
| critical   | Kritične greške             | Kvarovi sistema               |
| alert      | Hitna akcija potrebna       | Otkrivena korupcija podataka  |
| emergency  | Sistem neupotrebljiv        | Potpuni pad sistema           |

## Implementacija notifikacija u MCP-u

Da biste implementirali notifikacije u MCP-u, potrebno je da podesite i server i klijenta da obrađuju real-time ažuriranja. Ovo omogućava vašoj aplikaciji da pruži trenutnu povratnu informaciju korisnicima tokom dugotrajnih operacija.

### Sa serverske strane: slanje notifikacija

Počnimo sa serverskom stranom. U MCP-u definišete alate koji mogu slati notifikacije dok obrađuju zahteve. Server koristi kontekst objekat (obično `ctx`) za slanje poruka klijentu.

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

U prethodnom primeru, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Sa klijentske strane: prijem notifikacija

Klijent mora implementirati handler poruka koji obrađuje i prikazuje notifikacije čim stignu.

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

U prethodnom kodu, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) i vaš klijent implementira handler poruka za obradu notifikacija.

## Notifikacije o napretku i scenariji

Ovaj deo objašnjava koncept notifikacija o napretku u MCP-u, zašto su važne i kako ih implementirati koristeći Streamable HTTP. Takođe, pronaći ćete praktičan zadatak za utvrđivanje znanja.

Notifikacije o napretku su real-time poruke koje server šalje klijentu tokom dugotrajnih operacija. Umesto da se čeka da ceo proces završi, server stalno obaveštava klijenta o trenutnom statusu. Ovo poboljšava transparentnost, korisnički doživljaj i olakšava debugovanje.

**Primer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zašto koristiti notifikacije o napretku?

Notifikacije o napretku su važne iz nekoliko razloga:

- **Bolje korisničko iskustvo:** Korisnici vide ažuriranja kako posao napreduje, ne samo na kraju.
- **Real-time povratne informacije:** Klijenti mogu prikazivati progress barove ili logove, čineći aplikaciju responzivnijom.
- **Lakše debugovanje i praćenje:** Programeri i korisnici mogu videti gde proces može biti spor ili zapao.

### Kako implementirati notifikacije o napretku

Evo kako možete implementirati notifikacije o napretku u MCP-u:

- **Na serveru:** Koristite `ctx.info()` or `ctx.log()` da šaljete notifikacije dok se svaki element obrađuje. Ovo šalje poruku klijentu pre nego što glavni rezultat bude spreman.
- **Na klijentu:** Implementirajte handler poruka koji sluša i prikazuje notifikacije čim stignu. Ovaj handler razlikuje notifikacije od konačnog rezultata.

**Primer servera:**

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

**Primer klijenta:**

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

## Bezbednosne smernice

Prilikom implementacije MCP servera sa HTTP baziranim transportima, bezbednost postaje ključni faktor koji zahteva pažnju prema različitim vrstama napada i mehanizmima zaštite.

### Pregled

Bezbednost je kritična kada se MCP serveri izlažu preko HTTP-a. Streamable HTTP uvodi nove potencijalne tačke napada i zahteva pažljivo podešavanje.

### Ključne tačke
- **Validacija Origin zaglavlja**: Uvek proveravajte `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` umesto SSE klijenta.
3. **Implementirajte handler poruka** na klijentu za obradu notifikacija.
4. **Testirajte kompatibilnost** sa postojećim alatima i tokovima rada.

### Održavanje kompatibilnosti

Preporučuje se održavanje kompatibilnosti sa postojećim SSE klijentima tokom procesa migracije. Evo nekoliko strategija:

- Možete podržavati i SSE i Streamable HTTP tako što ćete pokretati oba transporta na različitim endpoint-ovima.
- Postepeno migrirajte klijente na novi transport.

### Izazovi

Obratite pažnju na sledeće izazove tokom migracije:

- Obezbediti da su svi klijenti ažurirani
- Rukovati razlikama u isporuci notifikacija

### Zadatak: Napravite sopstvenu Streaming MCP aplikaciju

**Scenario:**
Napravite MCP server i klijent gde server obrađuje listu stavki (npr. fajlove ili dokumente) i šalje notifikaciju za svaku obrađenu stavku. Klijent treba da prikazuje svaku notifikaciju čim stigne.

**Koraci:**

1. Implementirajte server alat koji obrađuje listu i šalje notifikacije za svaku stavku.
2. Implementirajte klijenta sa handlerom poruka koji prikazuje notifikacije u realnom vremenu.
3. Testirajte implementaciju pokretanjem servera i klijenta i pratite notifikacije.

[Solution](./solution/README.md)

## Dalje čitanje i šta dalje?

Da nastavite svoje putovanje sa MCP strimovanjem i proširite znanje, ovaj deo pruža dodatne resurse i predložene naredne korake za pravljenje naprednijih aplikacija.

### Dalje čitanje

- [Microsoft: Uvod u HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS u ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming zahtevi](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Šta dalje?

- Pokušajte da pravite složenije MCP alate koji koriste strimovanje za real-time analitiku, chat ili kolaborativno uređivanje.
- Istražite integraciju MCP strimovanja sa frontend framework-ima (React, Vue, itd.) za live UI ažuriranja.
- Sledeće: [Korišćenje AI Toolkit za VSCode](../07-aitk/README.md)

**Ограничење одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Не сносимо одговорност за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.