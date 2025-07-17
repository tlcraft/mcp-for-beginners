<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T19:21:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ro"
}
-->
# Streaming HTTPS cu Model Context Protocol (MCP)

Acest capitol oferă un ghid complet pentru implementarea streaming-ului securizat, scalabil și în timp real folosind Model Context Protocol (MCP) prin HTTPS. Sunt abordate motivația pentru streaming, mecanismele de transport disponibile, cum să implementezi HTTP streamabil în MCP, bune practici de securitate, migrarea de la SSE și recomandări practice pentru construirea propriilor aplicații MCP cu streaming.

## Mecanisme de Transport și Streaming în MCP

Această secțiune explorează diferitele mecanisme de transport disponibile în MCP și rolul lor în activarea capabilităților de streaming pentru comunicarea în timp real între clienți și servere.

### Ce este un mecanism de transport?

Un mecanism de transport definește modul în care datele sunt schimbate între client și server. MCP suportă mai multe tipuri de transport pentru a se potrivi diferitelor medii și cerințe:

- **stdio**: Intrare/ieșire standard, potrivit pentru unelte locale și bazate pe CLI. Simplu, dar nepotrivit pentru web sau cloud.
- **SSE (Server-Sent Events)**: Permite serverelor să trimită actualizări în timp real către clienți prin HTTP. Bun pentru interfețe web, dar limitat în scalabilitate și flexibilitate.
- **Streamable HTTP**: Transport modern bazat pe HTTP pentru streaming, suportând notificări și o scalabilitate mai bună. Recomandat pentru majoritatea scenariilor de producție și cloud.

### Tabel comparativ

Consultați tabelul comparativ de mai jos pentru a înțelege diferențele dintre aceste mecanisme de transport:

| Transport         | Actualizări în timp real | Streaming | Scalabilitate | Caz de utilizare          |
|-------------------|--------------------------|-----------|---------------|---------------------------|
| stdio             | Nu                       | Nu        | Scăzut        | Unelte locale CLI         |
| SSE               | Da                       | Da        | Mediu         | Web, actualizări în timp real |
| Streamable HTTP   | Da                       | Da        | Ridicat       | Cloud, multi-client       |

> **Tip:** Alegerea mecanismului de transport potrivit influențează performanța, scalabilitatea și experiența utilizatorului. **Streamable HTTP** este recomandat pentru aplicații moderne, scalabile și pregătite pentru cloud.

Rețineți mecanismele stdio și SSE prezentate în capitolele anterioare și cum streamable HTTP este transportul abordat în acest capitol.

## Streaming: Concepte și Motivație

Înțelegerea conceptelor fundamentale și a motivațiilor din spatele streaming-ului este esențială pentru implementarea unor sisteme eficiente de comunicare în timp real.

**Streaming-ul** este o tehnică în programarea de rețea care permite trimiterea și primirea datelor în bucăți mici, gestionabile sau ca o secvență de evenimente, în loc să se aștepte ca întregul răspuns să fie gata. Acest lucru este util mai ales pentru:

- Fișiere sau seturi mari de date.
- Actualizări în timp real (ex: chat, bare de progres).
- Calculuri de durată lungă unde dorești să ții utilizatorul informat.

Iată ce trebuie să știi despre streaming la nivel înalt:

- Datele sunt livrate progresiv, nu toate odată.
- Clientul poate procesa datele pe măsură ce sosesc.
- Reduce latența percepută și îmbunătățește experiența utilizatorului.

### De ce să folosești streaming?

Motivele pentru utilizarea streaming-ului sunt următoarele:

- Utilizatorii primesc feedback imediat, nu doar la final.
- Permite aplicații în timp real și interfețe responsive.
- Folosește mai eficient resursele de rețea și calcul.

### Exemplu simplu: Server și client HTTP streaming

Iată un exemplu simplu despre cum poate fi implementat streaming-ul:

## Python

**Server (Python, folosind FastAPI și StreamingResponse):**

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

**Client (Python, folosind requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

Acest exemplu demonstrează un server care trimite o serie de mesaje către client pe măsură ce acestea devin disponibile, în loc să aștepte ca toate mesajele să fie gata.

**Cum funcționează:**
- Serverul transmite fiecare mesaj pe măsură ce este gata.
- Clientul primește și afișează fiecare fragment pe măsură ce sosește.

**Cerințe:**
- Serverul trebuie să folosească un răspuns de tip streaming (ex: `StreamingResponse` în FastAPI).
- Clientul trebuie să proceseze răspunsul ca un flux (`stream=True` în requests).
- Content-Type este de obicei `text/event-stream` sau `application/octet-stream`.

## Java

**Server (Java, folosind Spring Boot și Server-Sent Events):**

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

**Client (Java, folosind Spring WebFlux WebClient):**

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

**Note despre implementarea în Java:**
- Folosește stiva reactivă Spring Boot cu `Flux` pentru streaming
- `ServerSentEvent` oferă streaming structurat de evenimente cu tipuri de evenimente
- `WebClient` cu `bodyToFlux()` permite consumul reactiv al streaming-ului
- `delayElements()` simulează timpul de procesare între evenimente
- Evenimentele pot avea tipuri (`info`, `result`) pentru o gestionare mai bună de către client

### Comparație: Streaming clasic vs Streaming MCP

Diferențele dintre modul clasic de streaming și cel din MCP pot fi ilustrate astfel:

| Caracteristică         | Streaming HTTP Clasic          | Streaming MCP (Notificări)         |
|-----------------------|-------------------------------|-----------------------------------|
| Răspuns principal      | În bucăți (chunked)            | Unic, la final                    |
| Actualizări de progres | Trimise ca bucăți de date      | Trimise ca notificări             |
| Cerințe client         | Trebuie să proceseze fluxul    | Trebuie să implementeze handler de mesaje |
| Caz de utilizare       | Fișiere mari, fluxuri de tokeni AI | Progres, jurnale, feedback în timp real |

### Diferențe cheie observate

Mai mult, iată câteva diferențe importante:

- **Model de comunicare:**
   - Streaming HTTP clasic: Folosește codificare simplă chunked pentru a trimite date în bucăți
   - Streaming MCP: Folosește un sistem structurat de notificări cu protocol JSON-RPC

- **Formatul mesajelor:**
   - HTTP clasic: Bucăți de text simplu cu linii noi
   - MCP: Obiecte structurate LoggingMessageNotification cu metadate

- **Implementarea clientului:**
   - HTTP clasic: Client simplu care procesează răspunsuri streaming
   - MCP: Client mai sofisticat cu handler de mesaje pentru a procesa tipuri diferite de mesaje

- **Actualizări de progres:**
   - HTTP clasic: Progresul face parte din fluxul principal de răspuns
   - MCP: Progresul este trimis prin mesaje de notificare separate, iar răspunsul principal vine la final

### Recomandări

Există câteva recomandări privind alegerea între implementarea streaming-ului clasic (ca endpoint-ul `/stream` prezentat mai sus) și streaming-ul prin MCP.

- **Pentru nevoi simple de streaming:** Streaming-ul HTTP clasic este mai simplu de implementat și suficient pentru cerințe de bază.

- **Pentru aplicații complexe, interactive:** Streaming-ul MCP oferă o abordare mai structurată, cu metadate mai bogate și separare clară între notificări și rezultatele finale.

- **Pentru aplicații AI:** Sistemul de notificări MCP este deosebit de util pentru sarcini AI de durată lungă, unde dorești să ții utilizatorii informați despre progres.

## Streaming în MCP

Ok, ai văzut până acum recomandări și comparații între streaming-ul clasic și cel în MCP. Hai să intrăm în detalii despre cum poți folosi streaming-ul în MCP.

Înțelegerea modului în care funcționează streaming-ul în cadrul MCP este esențială pentru construirea unor aplicații responsive care oferă feedback în timp real utilizatorilor în timpul operațiunilor de durată lungă.

În MCP, streaming-ul nu înseamnă trimiterea răspunsului principal în bucăți, ci trimiterea de **notificări** către client în timp ce o unealtă procesează o cerere. Aceste notificări pot include actualizări de progres, jurnale sau alte evenimente.

### Cum funcționează

Rezultatul principal este încă trimis ca un răspuns unic. Totuși, notificările pot fi trimise ca mesaje separate în timpul procesării și astfel actualizează clientul în timp real. Clientul trebuie să poată gestiona și afișa aceste notificări.

## Ce este o notificare?

Am spus „Notificare”, ce înseamnă asta în contextul MCP?

O notificare este un mesaj trimis de server către client pentru a informa despre progres, stare sau alte evenimente în timpul unei operațiuni de durată lungă. Notificările îmbunătățesc transparența și experiența utilizatorului.

De exemplu, clientul trebuie să trimită o notificare odată ce s-a realizat handshake-ul inițial cu serverul.

O notificare arată astfel ca mesaj JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notificările aparțin unui topic în MCP numit ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pentru a activa logging-ul, serverul trebuie să îl activeze ca funcționalitate/capabilitate astfel:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> În funcție de SDK-ul folosit, logging-ul poate fi activat implicit sau poate fi necesar să îl activezi explicit în configurația serverului.

Există diferite tipuri de notificări:

| Nivel     | Descriere                      | Exemplu de utilizare           |
|-----------|-------------------------------|-------------------------------|
| debug     | Informații detaliate pentru depanare | Puncte de intrare/ieșire din funcții |
| info      | Mesaje informaționale generale | Actualizări de progres         |
| notice    | Evenimente normale, dar semnificative | Modificări de configurare     |
| warning   | Condiții de avertizare         | Utilizarea unei funcționalități depreciate |
| error     | Condiții de eroare             | Eșecuri în operațiuni         |
| critical  | Condiții critice               | Defecțiuni ale componentelor sistemului |
| alert     | Acțiune imediată necesară      | Detectare corupție de date    |
| emergency | Sistemul este inutilizabil     | Defecțiune completă a sistemului |

## Implementarea notificărilor în MCP

Pentru a implementa notificările în MCP, trebuie să configurezi atât partea de server, cât și pe cea de client pentru a gestiona actualizările în timp real. Astfel, aplicația ta poate oferi feedback imediat utilizatorilor în timpul operațiunilor de durată lungă.

### Partea de server: Trimiterea notificărilor

Să începem cu partea de server. În MCP, definești unelte care pot trimite notificări în timp ce procesează cereri. Serverul folosește obiectul context (de obicei `ctx`) pentru a trimite mesaje către client.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

În exemplul de mai sus, unealta `process_files` trimite trei notificări către client pe măsură ce procesează fiecare fișier. Metoda `ctx.info()` este folosită pentru a trimite mesaje informaționale.

În plus, pentru a activa notificările, asigură-te că serverul folosește un transport de tip streaming (ex: `streamable-http`) și clientul implementează un handler de mesaje pentru a procesa notificările. Iată cum poți configura serverul să folosească transportul `streamable-http`:

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

În acest exemplu .NET, unealta `ProcessFiles` este decorată cu atributul `Tool` și trimite trei notificări către client pe măsură ce procesează fiecare fișier. Metoda `ctx.Info()` este folosită pentru a trimite mesaje informaționale.

Pentru a activa notificările în serverul tău MCP .NET, asigură-te că folosești un transport de streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Partea de client: Primirea notificărilor

Clientul trebuie să implementeze un handler de mesaje pentru a procesa și afișa notificările pe măsură ce sosesc.

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

În codul de mai sus, funcția `message_handler` verifică dacă mesajul primit este o notificare. Dacă da, îl afișează; altfel, îl procesează ca mesaj normal de server. De asemenea, observă cum `ClientSession` este inițializat cu `message_handler` pentru a gestiona notificările primite.

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

În acest exemplu .NET, funcția `MessageHandler` verifică dacă mesajul primit este o notificare. Dacă da, îl afișează; altfel, îl procesează ca mesaj normal de server. `ClientSession` este inițializat cu handler-ul de mesaje prin `ClientSessionOptions`.

Pentru a activa notificările, asigură-te că serverul folosește un transport de streaming (ex: `streamable-http`) și clientul implementează un handler de mesaje pentru a procesa notificările.

## Notificări de progres & scenarii

Această secțiune explică conceptul de notificări de progres în MCP, de ce sunt importante și cum să le implementezi folosind Streamable HTTP. Vei găsi și o sarcină practică pentru a-ți consolida înțelegerea.

Notificările de progres sunt mesaje în timp real trimise de server către client în timpul operațiunilor de durată lungă. În loc să aștepte finalizarea întregului proces, serverul ține clientul la curent cu stadiul curent. Acest lucru îmbunătățește transparența, experiența utilizatorului și facilitează depanarea.

**Exemplu:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### De ce să folosești notificări de progres?

Notificările de progres sunt esențiale din mai multe motive:

- **Experiență mai bună pentru utilizator:** Utilizatorii văd actualizări pe măsură ce munca avansează, nu doar la final.
- **Feedback în timp real:** Clienții pot afișa bare de progres sau jurnale, făcând aplicația să pară mai receptivă.
- **Depanare și monitorizare mai ușoară:** Dezvoltatorii și utilizatorii pot vedea unde un proces este lent sau blocat.

### Cum să implementezi notificările de progres

Iată cum poți implementa notificările de progres în MCP:

- **Pe server:** Folosește `ctx.info()` sau `ctx.log()` pentru a trimite notificări pe măsură ce fiecare element este procesat. Acest lucru trimite un mesaj clientului înainte ca rezultatul principal să fie gata.
- **Pe client:** Implementează un handler de mesaje care ascultă și afișează notificările pe măsură ce sosesc. Acest handler face diferența între notificări și rezultatul final.

**Exemplu server:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

**Exemplu client:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

## Considerații de securitate

Atunci când implementezi servere MCP cu transporturi bazate pe HTTP, securitatea devine o preocupare majoră care necesită atenție atentă la multiple vectori de atac și mecanisme de protecție.

### Prezentare generală

Securitatea este critică când expui servere MCP prin HTTP. Streamable HTTP introduce noi suprafețe de atac și necesită configurare atentă.

### Puncte cheie
- **Validarea header-ului Origin:** Verifică întotdeauna header-ul `Origin` pentru a preveni atacurile de tip DNS rebinding.
- **Legarea la localhost:** Pentru dezvoltare locală, leagă serverele la `localhost` pentru a evita expunerea publică.
- **Autentificare:** Implementează autentificare (ex: chei API, OAuth) pentru mediile de producție.
- **CORS:** Configurează politicile Cross-Origin Resource Sharing pentru a restricționa accesul.
- **HTTPS:** Folosește HTTPS în producție pentru criptarea traficului.

### Bune practici
- Nu avea încredere în cererile primite fără validare.
- Înregistrează și monitorizează toate accesările și erorile.
- Actualizează regulat dependențele pentru a remedia vulnerabilități de securitate.

### Provocări
- Echilibrarea securității cu ușurința dezvoltării
- Asigurarea compatibilității cu diverse medii client

## Actualizarea de la SSE la Streamable HTTP

Pentru aplicațiile care folosesc în prezent Server-Sent Events (SSE), migrarea la Streamable HTTP oferă capabilități îmbunătățite și o sustenabilitate mai bună pe termen lung pentru implementările MCP.
### De ce să faci upgrade?

Există două motive convingătoare pentru a face upgrade de la SSE la Streamable HTTP:

- Streamable HTTP oferă o scalabilitate mai bună, compatibilitate și suport mai bogat pentru notificări decât SSE.
- Este transportul recomandat pentru noile aplicații MCP.

### Pașii migrației

Iată cum poți migra de la SSE la Streamable HTTP în aplicațiile tale MCP:

- **Actualizează codul serverului** pentru a folosi `transport="streamable-http"` în `mcp.run()`.
- **Actualizează codul clientului** pentru a folosi `streamablehttp_client` în locul clientului SSE.
- **Implementează un handler de mesaje** în client pentru a procesa notificările.
- **Testează compatibilitatea** cu uneltele și fluxurile de lucru existente.

### Menținerea compatibilității

Se recomandă să menții compatibilitatea cu clienții SSE existenți pe durata procesului de migrare. Iată câteva strategii:

- Poți suporta atât SSE, cât și Streamable HTTP rulând ambele transporturi pe endpoint-uri diferite.
- Migrează treptat clienții către noul transport.

### Provocări

Asigură-te că abordezi următoarele provocări în timpul migrației:

- Actualizarea tuturor clienților
- Gestionarea diferențelor în livrarea notificărilor

## Considerații de securitate

Securitatea trebuie să fie o prioritate majoră atunci când implementezi orice server, mai ales când folosești transporturi bazate pe HTTP, cum este Streamable HTTP în MCP.

Atunci când implementezi servere MCP cu transporturi bazate pe HTTP, securitatea devine o preocupare esențială care necesită atenție atentă la multiple vectori de atac și mecanisme de protecție.

### Prezentare generală

Securitatea este critică când expui servere MCP prin HTTP. Streamable HTTP introduce noi suprafețe de atac și necesită o configurare atentă.

Iată câteva aspecte cheie legate de securitate:

- **Validarea header-ului Origin**: Verifică întotdeauna header-ul `Origin` pentru a preveni atacurile de tip DNS rebinding.
- **Legarea la localhost**: Pentru dezvoltare locală, leagă serverele la `localhost` pentru a evita expunerea lor pe internetul public.
- **Autentificare**: Implementează autentificare (de ex. chei API, OAuth) pentru mediile de producție.
- **CORS**: Configurează politicile Cross-Origin Resource Sharing (CORS) pentru a restricționa accesul.
- **HTTPS**: Folosește HTTPS în producție pentru a cripta traficul.

### Cele mai bune practici

În plus, iată câteva bune practici de urmat când implementezi securitatea în serverul tău MCP de streaming:

- Nu avea încredere în cererile primite fără validare.
- Înregistrează și monitorizează toate accesările și erorile.
- Actualizează regulat dependențele pentru a remedia vulnerabilitățile de securitate.

### Provocări

Vei întâmpina unele provocări când implementezi securitatea în serverele MCP de streaming:

- Echilibrarea securității cu ușurința dezvoltării
- Asigurarea compatibilității cu diverse medii client

### Tema: Construiește-ți propria aplicație MCP de streaming

**Scenariu:**  
Construiește un server și un client MCP unde serverul procesează o listă de elemente (de ex. fișiere sau documente) și trimite o notificare pentru fiecare element procesat. Clientul trebuie să afișeze fiecare notificare pe măsură ce aceasta sosește.

**Pași:**

1. Implementează un instrument server care procesează o listă și trimite notificări pentru fiecare element.
2. Implementează un client cu un handler de mesaje pentru a afișa notificările în timp real.
3. Testează implementarea rulând atât serverul, cât și clientul, și observă notificările.

[Solution](./solution/README.md)

## Lecturi suplimentare și ce urmează?

Pentru a-ți continua parcursul cu streaming-ul MCP și a-ți extinde cunoștințele, această secțiune oferă resurse suplimentare și pași sugerați pentru construirea unor aplicații mai avansate.

### Lecturi suplimentare

- [Microsoft: Introducere în HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS în ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ce urmează?

- Încearcă să construiești unelte MCP mai avansate care folosesc streaming pentru analize în timp real, chat sau editare colaborativă.
- Explorează integrarea streaming-ului MCP cu framework-uri frontend (React, Vue etc.) pentru actualizări live ale interfeței.
- Următorul pas: [Utilizarea AI Toolkit pentru VSCode](../07-aitk/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.