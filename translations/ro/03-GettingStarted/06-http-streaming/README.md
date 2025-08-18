<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f1383103523fa822e1fec7ef81904d5",
  "translation_date": "2025-08-18T16:07:02+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ro"
}
-->
# Streaming HTTPS cu Protocolul Model Context (MCP)

Acest capitol oferă un ghid cuprinzător pentru implementarea streaming-ului securizat, scalabil și în timp real utilizând Protocolul Model Context (MCP) prin HTTPS. Acesta acoperă motivația pentru streaming, mecanismele de transport disponibile, cum să implementați HTTP streamable în MCP, cele mai bune practici de securitate, migrarea de la SSE și sfaturi practice pentru construirea propriilor aplicații MCP de streaming.

## Mecanisme de Transport și Streaming în MCP

Această secțiune explorează diferitele mecanisme de transport disponibile în MCP și rolul lor în activarea capabilităților de streaming pentru comunicarea în timp real între clienți și servere.

### Ce este un Mecanism de Transport?

Un mecanism de transport definește modul în care datele sunt schimbate între client și server. MCP suportă mai multe tipuri de transport pentru a se potrivi diferitelor medii și cerințe:

- **stdio**: Intrare/ieșire standard, potrivit pentru instrumente locale și bazate pe CLI. Simplu, dar nepotrivit pentru web sau cloud.
- **SSE (Server-Sent Events)**: Permite serverelor să trimită actualizări în timp real către clienți prin HTTP. Bun pentru interfețe web, dar limitat în scalabilitate și flexibilitate.
- **Streamable HTTP**: Transport modern bazat pe HTTP pentru streaming, care suportă notificări și o scalabilitate mai bună. Recomandat pentru majoritatea scenariilor de producție și cloud.

### Tabel Comparativ

Consultați tabelul comparativ de mai jos pentru a înțelege diferențele dintre aceste mecanisme de transport:

| Transport         | Actualizări în timp real | Streaming | Scalabilitate | Caz de utilizare         |
|-------------------|--------------------------|-----------|---------------|--------------------------|
| stdio             | Nu                       | Nu        | Scăzut        | Instrumente CLI locale   |
| SSE               | Da                       | Da        | Medie         | Web, actualizări în timp real |
| Streamable HTTP   | Da                       | Da        | Ridicată      | Cloud, multi-client      |

> **Tip:** Alegerea transportului potrivit influențează performanța, scalabilitatea și experiența utilizatorului. **Streamable HTTP** este recomandat pentru aplicații moderne, scalabile și pregătite pentru cloud.

Observați transporturile stdio și SSE prezentate în capitolele anterioare și cum HTTP streamable este transportul acoperit în acest capitol.

## Streaming: Concepte și Motivație

Înțelegerea conceptelor fundamentale și a motivațiilor din spatele streaming-ului este esențială pentru implementarea unor sisteme eficiente de comunicare în timp real.

**Streaming-ul** este o tehnică în programarea de rețea care permite trimiterea și primirea datelor în bucăți mici, gestionabile sau ca o secvență de evenimente, în loc să aștepte ca un răspuns complet să fie gata. Acest lucru este util în special pentru:

- Fișiere sau seturi de date mari.
- Actualizări în timp real (de exemplu, chat, bare de progres).
- Calculuri de lungă durată unde doriți să țineți utilizatorul informat.

Iată ce trebuie să știți despre streaming la un nivel înalt:

- Datele sunt livrate progresiv, nu toate odată.
- Clientul poate procesa datele pe măsură ce acestea sosesc.
- Reduce latența percepută și îmbunătățește experiența utilizatorului.

### De ce să folosiți streaming-ul?

Motivele pentru utilizarea streaming-ului sunt următoarele:

- Utilizatorii primesc feedback imediat, nu doar la final.
- Permite aplicații în timp real și interfețe responsive.
- Utilizare mai eficientă a resurselor de rețea și calcul.

### Exemplu Simplu: Server și Client HTTP Streaming

Iată un exemplu simplu despre cum poate fi implementat streaming-ul:

#### Python

**Server (Python, utilizând FastAPI și StreamingResponse):**

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

**Client (Python, utilizând requests):**

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

Acest exemplu demonstrează un server care trimite o serie de mesaje către client pe măsură ce acestea devin disponibile, în loc să aștepte ca toate mesajele să fie gata.

**Cum funcționează:**

- Serverul transmite fiecare mesaj pe măsură ce este pregătit.
- Clientul primește și afișează fiecare bucățică pe măsură ce sosește.

**Cerințe:**

- Serverul trebuie să utilizeze un răspuns de tip streaming (de exemplu, `StreamingResponse` în FastAPI).
- Clientul trebuie să proceseze răspunsul ca un flux (`stream=True` în requests).
- Content-Type este de obicei `text/event-stream` sau `application/octet-stream`.

#### Java

**Server (Java, utilizând Spring Boot și Server-Sent Events):**

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

**Client (Java, utilizând Spring WebFlux WebClient):**

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

**Note despre Implementarea în Java:**

- Utilizează stiva reactivă a Spring Boot cu `Flux` pentru streaming.
- `ServerSentEvent` oferă streaming structurat de evenimente cu tipuri de evenimente.
- `WebClient` cu `bodyToFlux()` permite consumul reactiv al streaming-ului.
- `delayElements()` simulează timpul de procesare între evenimente.
- Evenimentele pot avea tipuri (`info`, `result`) pentru o gestionare mai bună pe partea clientului.

### Comparație: Streaming Clasic vs Streaming MCP

Diferențele dintre modul în care funcționează streaming-ul într-o manieră "clasică" și modul în care funcționează în MCP pot fi descrise astfel:

| Caracteristică          | Streaming HTTP Clasic         | Streaming MCP (Notificări)         |
|-------------------------|-------------------------------|-------------------------------------|
| Răspuns principal       | În bucăți                     | Unic, la final                     |
| Actualizări de progres  | Transmise ca bucăți de date   | Transmise ca notificări            |
| Cerințe client          | Trebuie să proceseze fluxul   | Trebuie să implementeze un handler de mesaje |
| Caz de utilizare        | Fișiere mari, fluxuri AI      | Progres, loguri, feedback în timp real |

### Diferențe Cheie Observate

În plus, iată câteva diferențe cheie:

- **Model de Comunicare:**
  - Streaming HTTP clasic: Utilizează codificarea simplă a transferului în bucăți pentru a trimite date.
  - Streaming MCP: Utilizează un sistem structurat de notificări cu protocol JSON-RPC.

- **Formatul Mesajului:**
  - HTTP clasic: Bucăți de text simplu cu linii noi.
  - MCP: Obiecte structurate `LoggingMessageNotification` cu metadate.

- **Implementarea Clientului:**
  - HTTP clasic: Client simplu care procesează răspunsurile de streaming.
  - MCP: Client mai sofisticat cu un handler de mesaje pentru a procesa diferite tipuri de mesaje.

- **Actualizări de Progres:**
  - HTTP clasic: Progresul face parte din fluxul principal de răspuns.
  - MCP: Progresul este transmis prin mesaje de notificare separate, în timp ce răspunsul principal vine la final.

### Recomandări

Există câteva recomandări atunci când vine vorba de alegerea între implementarea streaming-ului clasic (ca endpoint-ul pe care vi l-am arătat mai sus folosind `/stream`) și alegerea streaming-ului prin MCP.

- **Pentru nevoi simple de streaming:** Streaming-ul HTTP clasic este mai simplu de implementat și suficient pentru nevoi de bază.
- **Pentru aplicații complexe și interactive:** Streaming-ul MCP oferă o abordare mai structurată, cu metadate mai bogate și separarea între notificări și rezultate finale.
- **Pentru aplicații AI:** Sistemul de notificări al MCP este deosebit de util pentru sarcini AI de lungă durată, unde doriți să țineți utilizatorii informați despre progres.
Există două motive convingătoare pentru a face upgrade de la SSE la HTTP Streamable:

- HTTP Streamable oferă o scalabilitate mai bună, compatibilitate și suport mai bogat pentru notificări decât SSE.
- Este transportul recomandat pentru aplicațiile MCP noi.

### Pași de Migrare

Iată cum poți migra de la SSE la HTTP Streamable în aplicațiile tale MCP:

- **Actualizează codul serverului** pentru a utiliza `transport="streamable-http"` în `mcp.run()`.
- **Actualizează codul clientului** pentru a utiliza `streamablehttp_client` în loc de clientul SSE.
- **Implementează un handler de mesaje** în client pentru a procesa notificările.
- **Testează compatibilitatea** cu instrumentele și fluxurile de lucru existente.

### Menținerea Compatibilității

Se recomandă menținerea compatibilității cu clienții SSE existenți în timpul procesului de migrare. Iată câteva strategii:

- Poți suporta atât SSE, cât și HTTP Streamable, rulând ambele transporturi pe endpoint-uri diferite.
- Migrează treptat clienții către noul transport.

### Provocări

Asigură-te că abordezi următoarele provocări în timpul migrării:

- Asigurarea că toți clienții sunt actualizați
- Gestionarea diferențelor în livrarea notificărilor

## Considerații de Securitate

Securitatea ar trebui să fie o prioritate principală atunci când implementezi orice server, mai ales când utilizezi transporturi bazate pe HTTP, cum ar fi HTTP Streamable în MCP.

Când implementezi servere MCP cu transporturi bazate pe HTTP, securitatea devine o preocupare esențială care necesită atenție la multiple vectori de atac și mecanisme de protecție.

### Prezentare Generală

Securitatea este crucială atunci când expui servere MCP prin HTTP. HTTP Streamable introduce noi suprafețe de atac și necesită configurare atentă.

Iată câteva considerații cheie de securitate:

- **Validarea Header-ului Origin**: Validează întotdeauna header-ul `Origin` pentru a preveni atacurile de tip DNS rebinding.
- **Binding pe Localhost**: Pentru dezvoltarea locală, leagă serverele de `localhost` pentru a evita expunerea lor pe internetul public.
- **Autentificare**: Implementează autentificare (de exemplu, chei API, OAuth) pentru implementările în producție.
- **CORS**: Configurează politicile Cross-Origin Resource Sharing (CORS) pentru a restricționa accesul.
- **HTTPS**: Utilizează HTTPS în producție pentru a cripta traficul.

### Cele Mai Bune Practici

În plus, iată câteva bune practici de urmat atunci când implementezi securitatea în serverul MCP de streaming:

- Nu avea încredere în cererile primite fără validare.
- Loghează și monitorizează toate accesările și erorile.
- Actualizează regulat dependențele pentru a remedia vulnerabilitățile de securitate.

### Provocări

Vei întâmpina unele provocări atunci când implementezi securitatea în serverele MCP de streaming:

- Echilibrarea securității cu ușurința dezvoltării
- Asigurarea compatibilității cu diverse medii de client

### Sarcină: Construiește Propria Aplicație MCP de Streaming

**Scenariu:**
Construiește un server și un client MCP unde serverul procesează o listă de elemente (de exemplu, fișiere sau documente) și trimite o notificare pentru fiecare element procesat. Clientul ar trebui să afișeze fiecare notificare pe măsură ce aceasta sosește.

**Pași:**

1. Implementează un instrument server care procesează o listă și trimite notificări pentru fiecare element.
2. Implementează un client cu un handler de mesaje pentru a afișa notificările în timp real.
3. Testează implementarea rulând atât serverul, cât și clientul, și observă notificările.

[Solution](./solution/README.md)

## Lecturi Suplimentare & Ce Urmează?

Pentru a continua călătoria ta cu streaming-ul MCP și pentru a-ți extinde cunoștințele, această secțiune oferă resurse suplimentare și pași sugerați pentru construirea unor aplicații mai avansate.

### Lecturi Suplimentare

- [Microsoft: Introducere în HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS în ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ce Urmează?

- Încearcă să construiești instrumente MCP mai avansate care utilizează streaming pentru analize în timp real, chat sau editare colaborativă.
- Explorează integrarea streaming-ului MCP cu framework-uri frontend (React, Vue, etc.) pentru actualizări live ale interfeței.
- Următorul pas: [Utilizarea AI Toolkit pentru VSCode](../07-aitk/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.