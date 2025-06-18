<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:37:05+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sl"
}
-->
# HTTPS pretakanje s protokolom Model Context Protocol (MCP)

To poglavje ponuja celovit vodič za implementacijo varnega, razširljivega in pretakanja v realnem času s protokolom Model Context Protocol (MCP) preko HTTPS. Obravnava motivacijo za pretakanje, razpoložljive transportne mehanizme, kako implementirati pretakajoči HTTP v MCP, varnostne dobre prakse, migracijo iz SSE ter praktična navodila za gradnjo lastnih MCP aplikacij s pretakanjem.

## Transportni mehanizmi in pretakanje v MCP

Ta razdelek raziskuje različne transportne mehanizme, ki so na voljo v MCP, in njihovo vlogo pri omogočanju pretakanja za komunikacijo v realnem času med odjemalci in strežniki.

### Kaj je transportni mehanizem?

Transportni mehanizem določa, kako se podatki izmenjujejo med odjemalcem in strežnikom. MCP podpira več vrst transportov, ki ustrezajo različnim okoljem in zahtevam:

- **stdio**: standardni vhod/izhod, primeren za lokalna orodja in orodja prek ukazne vrstice. Enostaven, a neprimeren za splet ali oblak.
- **SSE (Server-Sent Events)**: omogoča strežnikom pošiljanje posodobitev v realnem času odjemalcem preko HTTP. Dobro za spletne uporabniške vmesnike, a omejeno glede razširljivosti in prilagodljivosti.
- **Streamable HTTP**: sodoben HTTP transport za pretakanje, ki podpira obvestila in boljšo razširljivost. Priporočen za večino produkcijskih in oblačnih scenarijev.

### Primerjalna tabela

Oglejte si spodnjo primerjalno tabelo, da razumete razlike med temi transportnimi mehanizmi:

| Transport         | Posodobitve v realnem času | Pretakanje | Razširljivost | Uporabni primer          |
|-------------------|----------------------------|------------|---------------|-------------------------|
| stdio             | Ne                         | Ne         | Nizka         | Lokalna orodja CLI      |
| SSE               | Da                         | Da         | Srednja       | Splet, posodobitve v realnem času |
| Streamable HTTP   | Da                         | Da         | Visoka        | Oblačne, več odjemalcev |

> **Nasvet:** Izbira pravega transporta vpliva na zmogljivost, razširljivost in uporabniško izkušnjo. **Streamable HTTP** je priporočljiv za sodobne, razširljive in oblačne aplikacije.

Opazite transporta stdio in SSE, ki ste ju spoznali v prejšnjih poglavjih, ter kako je streamable HTTP transport, obravnavan v tem poglavju.

## Pretakanje: koncepti in motivacija

Razumevanje osnovnih konceptov in motivacij za pretakanje je ključno za učinkovito implementacijo komunikacijskih sistemov v realnem času.

**Pretakanje** je tehnika v mrežnem programiranju, ki omogoča pošiljanje in sprejemanje podatkov v majhnih, obvladljivih delih ali kot zaporedje dogodkov, namesto da bi čakali, da je celoten odgovor pripravljen. To je posebej uporabno za:

- Velike datoteke ali nabor podatkov.
- Posodobitve v realnem času (npr. klepet, indikatorji napredka).
- Dolgotrajne izračune, kjer želite uporabnika sproti obveščati.

Tukaj je nekaj osnovnih dejstev o pretakanju:

- Podatki se dostavljajo postopoma, ne naenkrat.
- Odjemalec lahko podatke obdeluje takoj, ko prispejo.
- Zmanjšuje zaznano zakasnitev in izboljšuje uporabniško izkušnjo.

### Zakaj uporabljati pretakanje?

Razlogi za uporabo pretakanja so naslednji:

- Uporabniki takoj prejmejo povratne informacije, ne šele na koncu.
- Omogoča aplikacije v realnem času in odzivne uporabniške vmesnike.
- Učinkovitejša raba omrežnih in računalniških virov.

### Preprost primer: HTTP strežnik in odjemalec s pretakanjem

Tukaj je preprost primer, kako lahko implementirate pretakanje:

<details>
<summary>Python</summary>

**Strežnik (Python, uporaba FastAPI in StreamingResponse):**
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

**Odjemalec (Python, uporaba requests):**
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

Ta primer prikazuje strežnik, ki pošilja serijo sporočil odjemalcu, takoj ko so na voljo, namesto da bi čakal, da so vsa sporočila pripravljena.

**Kako deluje:**
- Strežnik sproti pošilja vsako sporočilo, ko je pripravljeno.
- Odjemalec prejema in izpiše vsak delček takoj, ko prispe.

**Zahteve:**
- Strežnik mora uporabljati pretakan odziv (npr. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Strežnik (Java, uporaba Spring Boot in Server-Sent Events):**

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

**Odjemalec (Java, uporaba Spring WebFlux WebClient):**

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

**Opombe k Java implementaciji:**
- Uporablja reaktivni sklad Spring Boot z `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) v primerjavi z izbiro pretakanja preko MCP.

- **Za preproste potrebe pretakanja:** Klasično HTTP pretakanje je lažje za implementacijo in zadostuje za osnovne primere.

- **Za kompleksne, interaktivne aplikacije:** MCP pretakanje ponuja bolj strukturiran pristop z bogatejšimi metapodatki in ločitvijo med obvestili in končnimi rezultati.

- **Za AI aplikacije:** MCP obvestilni sistem je še posebej uporaben za dolgotrajne AI naloge, kjer želite uporabnike sproti obveščati o napredku.

## Pretakanje v MCP

Videli ste nekaj priporočil in primerjav med klasičnim pretakanjem in pretakanjem v MCP. Poglejmo podrobneje, kako lahko pretakanje izkoristite v MCP.

Razumevanje, kako pretakanje deluje znotraj okvira MCP, je ključnega pomena za gradnjo odzivnih aplikacij, ki uporabnikom med dolgotrajnimi operacijami zagotavljajo povratne informacije v realnem času.

V MCP pretakanje ni pošiljanje glavnega odgovora v delih, temveč pošiljanje **obvestil** odjemalcu med obdelavo zahteve. Ta obvestila lahko vključujejo posodobitve napredka, zapise ali druge dogodke.

### Kako deluje

Glavni rezultat se še vedno pošlje kot en sam odgovor. Vendar pa se obvestila lahko pošiljajo kot ločena sporočila med obdelavo in tako sproti posodabljajo odjemalca. Odjemalec mora biti sposoben obdelati in prikazati ta obvestila.

## Kaj je obvestilo?

Rekli smo "obvestilo", kaj to pomeni v kontekstu MCP?

Obvestilo je sporočilo, ki ga strežnik pošlje odjemalcu, da ga obvesti o napredku, stanju ali drugih dogodkih med dolgotrajno operacijo. Obvestila izboljšujejo preglednost in uporabniško izkušnjo.

Na primer, odjemalec naj bi poslal obvestilo, ko je bil opravljen začetni dogovor s strežnikom.

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

Za delovanje beleženja mora strežnik omogočiti to funkcionalnost kot lastnost oziroma zmogljivost, na primer takole:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Glede na uporabljeni SDK je lahko beleženje privzeto omogočeno ali pa ga je treba izrecno omogočiti v konfiguraciji strežnika.

Obstajajo različne vrste obvestil:

| Raven     | Opis                          | Primer uporabe               |
|-----------|-------------------------------|-----------------------------|
| debug     | Podrobne informacije za odpravljanje napak | Vhodi/izhodi funkcij         |
| info      | Splošna informacijska sporočila | Posodobitve napredka operacije |
| notice    | Normalni, a pomembni dogodki   | Spremembe konfiguracije      |
| warning   | Opozorilna stanja             | Uporaba zastarelih funkcij   |
| error     | Napake                       | Neuspehi operacij            |
| critical  | Kritična stanja              | Napake sistemskih komponent  |
| alert     | Takojšnje ukrepanje potrebno | Zaznana poškodba podatkov    |
| emergency | Sistem ni uporaben           | Popolna odpoved sistema      |

## Implementacija obvestil v MCP

Za implementacijo obvestil v MCP morate nastaviti tako strežniški kot odjemalski del, da lahko obdelujeta posodobitve v realnem času. To omogoča vaši aplikaciji, da uporabnikom med dolgotrajnimi operacijami zagotavlja takojšnje povratne informacije.

### Strežniška stran: pošiljanje obvestil

Začnimo s strežniško stranjo. V MCP definirate orodja, ki lahko med obdelavo zahtev pošiljajo obvestila. Strežnik uporablja kontekstni objekt (običajno `ctx`) za pošiljanje sporočil odjemalcu.

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

V prejšnjem primeru metoda `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

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

V tem .NET primeru se uporablja metoda `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` za pošiljanje informativnih sporočil.

Da omogočite obvestila v vašem .NET MCP strežniku, poskrbite, da uporabljate pretakan transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Odjemalska stran: prejemanje obvestil

Odjemalec mora implementirati obdelovalec sporočil, ki bo obdelal in prikazal obvestila takoj, ko prispejo.

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

V zgornji kodi `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` obdeluje dohodna obvestila.

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

V tem .NET primeru `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) in vaš odjemalec implementira obdelovalca sporočil za obvestila.

## Obvestila o napredku in scenariji

Ta razdelek pojasnjuje koncept obvestil o napredku v MCP, zakaj so pomembna in kako jih implementirati z uporabo Streamable HTTP. Prav tako je na voljo praktična naloga za utrditev znanja.

Obvestila o napredku so sporočila v realnem času, ki jih strežnik pošilja odjemalcu med dolgotrajnimi operacijami. Namesto da bi čakal na zaključek procesa, strežnik sproti obvešča odjemalca o trenutnem stanju. To izboljša preglednost, uporabniško izkušnjo in olajša odpravljanje napak.

**Primer:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Zakaj uporabljati obvestila o napredku?

Obvestila o napredku so pomembna zaradi več razlogov:

- **Boljša uporabniška izkušnja:** uporabniki vidijo posodobitve sproti, ne le na koncu.
- **Povratne informacije v realnem času:** odjemalci lahko prikazujejo indikatorje napredka ali zapise, kar naredi aplikacijo odzivno.
- **Lažje odpravljanje napak in nadzor:** razvijalci in uporabniki lahko vidijo, kje je postopek morda počasen ali zataknjen.

### Kako implementirati obvestila o napredku

Tako lahko implementirate obvestila o napredku v MCP:

- **Na strežniku:** uporabite `ctx.info()` or `ctx.log()`, da pošljete obvestila za vsak obdelan element. To pošlje sporočilo odjemalcu, preden je glavni rezultat pripravljen.
- **Na odjemalcu:** implementirajte obdelovalca sporočil, ki posluša in prikazuje obvestila, ko prispejo. Ta obdelovalec razlikuje med obvestili in končnim rezultatom.

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

Pri implementaciji MCP strežnikov z HTTP transporti postane varnost ključna skrb, ki zahteva skrbno obravnavo različnih načinov napadov in zaščitnih mehanizmov.

### Pregled

Varnost je bistvena pri izpostavljanju MCP strežnikov preko HTTP. Streamable HTTP odpira nove možnosti za napade in zahteva natančno konfiguracijo.

### Ključne točke
- **Preverjanje glave Origin**: Vedno preverite `Origin` header to prevent DNS rebinding attacks.
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
3. **Implementirajte obdelovalca sporočil** v odjemalcu za obdelavo obvestil.
4. **Testirajte združljivost** z obstoječimi orodji in delovnimi tokovi.

### Ohranjanje združljivosti

Priporočljivo je ohraniti združljivost z obstoječimi SSE odjemalci med postopkom migracije. Nekatere strategije so:

- Lahko podpirate oba transporta, SSE in Streamable HTTP, tako da ju zaženete na različnih končnih točkah.
- Postopoma migrirajte odjemalce na novi transport.

### Izzivi

Poskrbite, da boste med migracijo naslovili naslednje izzive:

- Zagotovitev, da so vsi odjemalci posodobljeni.
- Obvladovanje razlik v dostavi obvestil.

### Naloga: zgradite svojo MCP aplikacijo s pretakanjem

**Scenarij:**
Zgradite MCP strežnik in odjemalca, kjer strežnik obdeluje seznam elementov (npr. datoteke ali dokumente) in pošlje obvestilo za vsak obdelan element. Odjemalec naj sproti prikazuje vsako obvestilo, ko prispe.

**Koraki:**

1. Implementirajte strežniško orodje, ki obdeluje seznam in pošilja obvestila za vsak element.
2. Implementirajte odjemalca z obdelovalcem sporočil, ki v realnem času prikazuje obvestila.
3. Preizkusite svojo implementacijo z zagonom strežnika in odjemalca ter opazujte obvestila.

[Solution](./solution/README.md)

## Nadaljnje branje in kaj sledi?

Za nadaljevanje poti z MCP pretakanjem in širjenje znanja ta razdelek ponuja dodatne vire in predloge za naslednje korake pri gradnji bolj naprednih aplikacij.

### Nadaljnje branje

- [Microsoft: Uvod v HTTP pretakanje](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS v ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Kaj sledi?

- Poskusite zgraditi bolj napredna MCP orodja, ki uporabljajo pretakanje za analitiko v realnem času, klepet ali sodelovalno urejanje.
- Raziskujte integracijo MCP pretakanja s frontend ogrodji (React, Vue itd.) za žive posodobitve

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.