<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:07:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "el"
}
-->
# HTTPS Streaming με το Model Context Protocol (MCP)

Αυτό το κεφάλαιο παρέχει έναν ολοκληρωμένο οδηγό για την υλοποίηση ασφαλούς, επεκτάσιμου και σε πραγματικό χρόνο streaming με το Model Context Protocol (MCP) χρησιμοποιώντας HTTPS. Καλύπτει το κίνητρο για το streaming, τους διαθέσιμους μηχανισμούς μεταφοράς, τον τρόπο υλοποίησης streamable HTTP στο MCP, τις βέλτιστες πρακτικές ασφάλειας, τη μετανάστευση από SSE, καθώς και πρακτικές οδηγίες για την κατασκευή δικών σας streaming εφαρμογών MCP.

## Μηχανισμοί Μεταφοράς και Streaming στο MCP

Αυτή η ενότητα εξετάζει τους διάφορους μηχανισμούς μεταφοράς που είναι διαθέσιμοι στο MCP και τον ρόλο τους στην ενεργοποίηση των δυνατοτήτων streaming για επικοινωνία σε πραγματικό χρόνο μεταξύ πελατών και διακομιστών.

### Τι είναι ο Μηχανισμός Μεταφοράς;

Ένας μηχανισμός μεταφοράς ορίζει τον τρόπο με τον οποίο ανταλλάσσονται τα δεδομένα μεταξύ πελάτη και διακομιστή. Το MCP υποστηρίζει πολλούς τύπους μεταφοράς για να καλύψει διαφορετικά περιβάλλοντα και απαιτήσεις:

- **stdio**: Τυπική είσοδος/έξοδος, κατάλληλη για τοπικά εργαλεία και εργαλεία γραμμής εντολών. Απλή, αλλά όχι κατάλληλη για web ή cloud.
- **SSE (Server-Sent Events)**: Επιτρέπει στους διακομιστές να στέλνουν ενημερώσεις σε πραγματικό χρόνο στους πελάτες μέσω HTTP. Καλή για web UI, αλλά περιορισμένη σε επεκτασιμότητα και ευελιξία.
- **Streamable HTTP**: Σύγχρονη μεταφορά streaming βασισμένη σε HTTP, που υποστηρίζει ειδοποιήσεις και καλύτερη επεκτασιμότητα. Συνιστάται για τις περισσότερες παραγωγικές και cloud περιπτώσεις.

### Πίνακας Σύγκρισης

Δείτε τον παρακάτω πίνακα σύγκρισης για να κατανοήσετε τις διαφορές μεταξύ αυτών των μηχανισμών μεταφοράς:

| Μεταφορά         | Ενημερώσεις σε Πραγματικό Χρόνο | Streaming | Επεκτασιμότητα | Περίπτωση Χρήσης          |
|------------------|---------------------------------|-----------|----------------|--------------------------|
| stdio            | Όχι                             | Όχι       | Χαμηλή         | Τοπικά εργαλεία CLI      |
| SSE              | Ναι                             | Ναι       | Μέτρια         | Web, ενημερώσεις σε πραγματικό χρόνο |
| Streamable HTTP  | Ναι                             | Ναι       | Υψηλή          | Cloud, πολλαπλοί πελάτες |

> **Tip:** Η επιλογή της κατάλληλης μεταφοράς επηρεάζει την απόδοση, την επεκτασιμότητα και την εμπειρία χρήστη. Το **Streamable HTTP** συνιστάται για σύγχρονες, επεκτάσιμες και cloud-έτοιμες εφαρμογές.

Σημειώστε τις μεταφορές stdio και SSE που παρουσιάστηκαν στα προηγούμενα κεφάλαια και πώς το streamable HTTP είναι η μεταφορά που καλύπτεται σε αυτό το κεφάλαιο.

## Streaming: Έννοιες και Κίνητρα

Η κατανόηση των βασικών εννοιών και κινήτρων πίσω από το streaming είναι απαραίτητη για την υλοποίηση αποτελεσματικών συστημάτων επικοινωνίας σε πραγματικό χρόνο.

Το **Streaming** είναι μια τεχνική στον προγραμματισμό δικτύων που επιτρέπει την αποστολή και λήψη δεδομένων σε μικρά, διαχειρίσιμα κομμάτια ή ως ακολουθία γεγονότων, αντί να περιμένουμε ολόκληρη την απάντηση να είναι έτοιμη. Αυτό είναι ιδιαίτερα χρήσιμο για:

- Μεγάλα αρχεία ή σύνολα δεδομένων.
- Ενημερώσεις σε πραγματικό χρόνο (π.χ. chat, μπαρ προόδου).
- Μακροχρόνιους υπολογισμούς όπου θέλετε να κρατάτε τον χρήστη ενήμερο.

Ακολουθούν τα βασικά που πρέπει να γνωρίζετε για το streaming σε υψηλό επίπεδο:

- Τα δεδομένα παραδίδονται προοδευτικά, όχι όλα μαζί.
- Ο πελάτης μπορεί να επεξεργαστεί τα δεδομένα καθώς αυτά φτάνουν.
- Μειώνει την αντιληπτή καθυστέρηση και βελτιώνει την εμπειρία χρήστη.

### Γιατί να χρησιμοποιήσετε streaming;

Οι λόγοι για τη χρήση του streaming είναι οι εξής:

- Οι χρήστες λαμβάνουν άμεση ανατροφοδότηση, όχι μόνο στο τέλος.
- Επιτρέπει εφαρμογές σε πραγματικό χρόνο και ανταποκρινόμενα UI.
- Αποδοτικότερη χρήση πόρων δικτύου και υπολογιστικής ισχύος.

### Απλό Παράδειγμα: HTTP Streaming Server & Client

Ακολουθεί ένα απλό παράδειγμα για το πώς μπορεί να υλοποιηθεί το streaming:

<details>
<summary>Python</summary>

**Διακομιστής (Python, χρησιμοποιώντας FastAPI και StreamingResponse):**
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

**Πελάτης (Python, χρησιμοποιώντας requests):**
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

Αυτό το παράδειγμα δείχνει έναν διακομιστή που στέλνει μια σειρά μηνυμάτων στον πελάτη καθώς αυτά γίνονται διαθέσιμα, αντί να περιμένει όλα τα μηνύματα να είναι έτοιμα.

**Πώς λειτουργεί:**
- Ο διακομιστής αποδίδει κάθε μήνυμα μόλις είναι έτοιμο.
- Ο πελάτης λαμβάνει και εκτυπώνει κάθε κομμάτι μόλις φτάσει.

**Απαιτήσεις:**
- Ο διακομιστής πρέπει να χρησιμοποιεί streaming response (π.χ. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Διακομιστής (Java, χρησιμοποιώντας Spring Boot και Server-Sent Events):**

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

**Πελάτης (Java, χρησιμοποιώντας Spring WebFlux WebClient):**

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

**Σημειώσεις Υλοποίησης Java:**
- Χρησιμοποιεί το reactive stack του Spring Boot με `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) σε σύγκριση με την επιλογή streaming μέσω MCP.

- **Για απλές ανάγκες streaming:** Το κλασικό HTTP streaming είναι πιο απλό στην υλοποίηση και επαρκεί για βασικές ανάγκες.

- **Για πολύπλοκες, διαδραστικές εφαρμογές:** Το MCP streaming παρέχει πιο δομημένη προσέγγιση με πλουσιότερα μεταδεδομένα και διαχωρισμό μεταξύ ειδοποιήσεων και τελικών αποτελεσμάτων.

- **Για εφαρμογές AI:** Το σύστημα ειδοποιήσεων του MCP είναι ιδιαίτερα χρήσιμο για μακροχρόνιες εργασίες AI όπου θέλετε να κρατάτε τους χρήστες ενήμερους για την πρόοδο.

## Streaming στο MCP

Έχετε δει κάποιες συστάσεις και συγκρίσεις μέχρι τώρα σχετικά με τη διαφορά μεταξύ κλασικού streaming και streaming στο MCP. Ας δούμε αναλυτικά πώς μπορείτε να αξιοποιήσετε το streaming στο MCP.

Η κατανόηση του πώς λειτουργεί το streaming εντός του πλαισίου του MCP είναι απαραίτητη για την κατασκευή ανταποκρινόμενων εφαρμογών που παρέχουν ανατροφοδότηση σε πραγματικό χρόνο στους χρήστες κατά τη διάρκεια μακροχρόνιων λειτουργιών.

Στο MCP, το streaming δεν αφορά την αποστολή της κύριας απάντησης σε κομμάτια, αλλά την αποστολή **ειδοποιήσεων** στον πελάτη ενώ ένα εργαλείο επεξεργάζεται ένα αίτημα. Αυτές οι ειδοποιήσεις μπορεί να περιλαμβάνουν ενημερώσεις προόδου, αρχεία καταγραφής ή άλλα γεγονότα.

### Πώς λειτουργεί

Το κύριο αποτέλεσμα εξακολουθεί να αποστέλλεται ως μία απάντηση. Ωστόσο, οι ειδοποιήσεις μπορούν να αποστέλλονται ως ξεχωριστά μηνύματα κατά τη διάρκεια της επεξεργασίας και έτσι να ενημερώνουν τον πελάτη σε πραγματικό χρόνο. Ο πελάτης πρέπει να μπορεί να χειρίζεται και να εμφανίζει αυτές τις ειδοποιήσεις.

## Τι είναι μια Ειδοποίηση;

Είπαμε "Ειδοποίηση", τι σημαίνει αυτό στο πλαίσιο του MCP;

Μια ειδοποίηση είναι ένα μήνυμα που αποστέλλεται από τον διακομιστή στον πελάτη για να ενημερώσει σχετικά με την πρόοδο, την κατάσταση ή άλλα γεγονότα κατά τη διάρκεια μιας μακροχρόνιας λειτουργίας. Οι ειδοποιήσεις βελτιώνουν τη διαφάνεια και την εμπειρία χρήστη.

Για παράδειγμα, ένας πελάτης πρέπει να στείλει μια ειδοποίηση μόλις ολοκληρωθεί η αρχική σύνδεση (handshake) με τον διακομιστή.

Μια ειδοποίηση έχει την εξής μορφή ως μήνυμα JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Οι ειδοποιήσεις ανήκουν σε ένα θέμα στο MCP που αναφέρεται ως ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Για να λειτουργήσει το logging, ο διακομιστής πρέπει να το ενεργοποιήσει ως λειτουργία/δυνατότητα ως εξής:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Ανάλογα με το SDK που χρησιμοποιείται, το logging μπορεί να είναι ενεργοποιημένο από προεπιλογή ή μπορεί να χρειαστεί να το ενεργοποιήσετε ρητά στη ρύθμιση του διακομιστή σας.

Υπάρχουν διάφοροι τύποι ειδοποιήσεων:

| Επίπεδο    | Περιγραφή                    | Παράδειγμα Χρήσης            |
|------------|-----------------------------|-----------------------------|
| debug      | Λεπτομερείς πληροφορίες αποσφαλμάτωσης | Σημεία εισόδου/εξόδου συναρτήσεων |
| info       | Γενικά πληροφοριακά μηνύματα | Ενημερώσεις προόδου λειτουργίας |
| notice     | Κανονικά αλλά σημαντικά γεγονότα | Αλλαγές ρυθμίσεων           |
| warning    | Συνθήκες προειδοποίησης      | Χρήση παρωχημένων λειτουργιών |
| error      | Συνθήκες σφάλματος           | Αποτυχίες λειτουργίας       |
| critical   | Κρίσιμες συνθήκες            | Αποτυχίες συστατικών συστήματος |
| alert      | Άμεση ανάγκη δράσης          | Ανίχνευση καταστροφής δεδομένων |
| emergency  | Το σύστημα είναι μη λειτουργικό | Ολική αποτυχία συστήματος   |

## Υλοποίηση Ειδοποιήσεων στο MCP

Για να υλοποιήσετε ειδοποιήσεις στο MCP, πρέπει να ρυθμίσετε τόσο την πλευρά του διακομιστή όσο και του πελάτη για να χειρίζονται ενημερώσεις σε πραγματικό χρόνο. Αυτό επιτρέπει στην εφαρμογή σας να παρέχει άμεση ανατροφοδότηση στους χρήστες κατά τη διάρκεια μακροχρόνιων λειτουργιών.

### Πλευρά Διακομιστή: Αποστολή Ειδοποιήσεων

Ας ξεκινήσουμε με την πλευρά του διακομιστή. Στο MCP, ορίζετε εργαλεία που μπορούν να στέλνουν ειδοποιήσεις ενώ επεξεργάζονται αιτήματα. Ο διακομιστής χρησιμοποιεί το αντικείμενο context (συνήθως `ctx`) για να στέλνει μηνύματα στον πελάτη.

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

Στο προηγούμενο παράδειγμα, η μέθοδος `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` χρησιμοποιεί τη μεταφορά:

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

Σε αυτό το παράδειγμα .NET, η μέθοδος `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` χρησιμοποιείται για την αποστολή πληροφοριακών μηνυμάτων.

Για να ενεργοποιήσετε τις ειδοποιήσεις στον MCP διακομιστή σας .NET, βεβαιωθείτε ότι χρησιμοποιείτε streaming μεταφορά:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Πλευρά Πελάτη: Λήψη Ειδοποιήσεων

Ο πελάτης πρέπει να υλοποιήσει έναν χειριστή μηνυμάτων για να επεξεργάζεται και να εμφανίζει τις ειδοποιήσεις καθώς φτάνουν.

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

Στον προηγούμενο κώδικα, η `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` χρησιμοποιείται για τη διαχείριση εισερχόμενων ειδοποιήσεων.

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

Σε αυτό το παράδειγμα .NET, η `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) και ο πελάτης υλοποιεί έναν χειριστή μηνυμάτων για την επεξεργασία ειδοποιήσεων.

## Ειδοποιήσεις Προόδου & Σενάρια

Αυτή η ενότητα εξηγεί την έννοια των ειδοποιήσεων προόδου στο MCP, γιατί είναι σημαντικές και πώς να τις υλοποιήσετε χρησιμοποιώντας Streamable HTTP. Θα βρείτε επίσης μια πρακτική άσκηση για να εμβαθύνετε την κατανόησή σας.

Οι ειδοποιήσεις προόδου είναι μηνύματα σε πραγματικό χρόνο που στέλνονται από τον διακομιστή στον πελάτη κατά τη διάρκεια μακροχρόνιων λειτουργιών. Αντί να περιμένει ο διακομιστής να ολοκληρωθεί η όλη διαδικασία, ενημερώνει τον πελάτη για την τρέχουσα κατάσταση. Αυτό βελτιώνει τη διαφάνεια, την εμπειρία χρήστη και διευκολύνει τον εντοπισμό σφαλμάτων.

**Παράδειγμα:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Γιατί να χρησιμοποιήσετε ειδοποιήσεις προόδου;

Οι ειδοποιήσεις προόδου είναι απαραίτητες για διάφορους λόγους:

- **Καλύτερη εμπειρία χρήστη:** Οι χρήστες βλέπουν ενημερώσεις καθώς προχωρά η εργασία, όχι μόνο στο τέλος.
- **Άμεση ανατροφοδότηση:** Οι πελάτες μπορούν να εμφανίζουν μπαρ προόδου ή αρχεία καταγραφής, κάνοντας την εφαρμογή να φαίνεται ανταποκρινόμενη.
- **Ευκολότερος εντοπισμός σφαλμάτων και παρακολούθηση:** Οι προγραμματιστές και οι χρήστες μπορούν να δουν πού μπορεί να υπάρχει καθυστέρηση ή πρόβλημα στη διαδικασία.

### Πώς να υλοποιήσετε ειδοποιήσεις προόδου

Ακολουθεί ο τρόπος υλοποίησης ειδοποιήσεων προόδου στο MCP:

- **Στον διακομιστή:** Χρησιμοποιήστε `ctx.info()` or `ctx.log()` για να στέλνετε ειδοποιήσεις καθώς επεξεργάζεται κάθε στοιχείο. Αυτό στέλνει μήνυμα στον πελάτη πριν το κύριο αποτέλεσμα είναι έτοιμο.
- **Στον πελάτη:** Υλοποιήστε έναν χειριστή μηνυμάτων που ακούει και εμφανίζει τις ειδοποιήσεις καθώς φτάνουν. Ο χειριστής αυτός διαχωρίζει τις ειδοποιήσεις από το τελικό αποτέλεσμα.

**Παράδειγμα Διακομιστή:**

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

**Παράδειγμα Πελάτη:**

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

## Θεωρήσεις Ασφαλείας

Κατά την υλοποίηση MCP διακομιστών με μεταφορές βασισμένες σε HTTP, η ασφάλεια γίνεται πρωτεύουσα ανησυχία που απαιτεί προσεκτική προσοχή σε πολλαπλές επιθέσεις και μηχανισμούς προστασίας.

### Επισκόπηση

Η ασφάλεια είναι κρίσιμη όταν εκθέτετε MCP διακομιστές μέσω HTTP. Το Streamable HTTP εισάγει νέες επιφάνειες επίθεσης και απαιτεί προσεκτική διαμόρφωση.

### Βασικά Σημεία
- **Έλεγχος της κεφαλίδας Origin**: Πάντα ελέγχετε την κεφαλίδα `Origin` header to prevent DNS rebinding attacks.
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

1. **Update server code** to use `transport="streamable-http"@@INLINE_CODE

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από άνθρωπο. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.