<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:11:09+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "el"
}
-->
# MCP Java Client - Παράδειγμα Αριθμομηχανής

Αυτό το έργο δείχνει πώς να δημιουργήσετε έναν Java client που συνδέεται και αλληλεπιδρά με έναν MCP (Model Context Protocol) server. Σε αυτό το παράδειγμα, θα συνδεθούμε στον server της αριθμομηχανής από το Κεφάλαιο 01 και θα εκτελέσουμε διάφορες μαθηματικές λειτουργίες.

## Απαιτούμενα

Πριν εκτελέσετε αυτόν τον client, πρέπει να:

1. **Εκκινήσετε τον Server της Αριθμομηχανής** από το Κεφάλαιο 01:
   - Μεταβείτε στον φάκελο του server της αριθμομηχανής: `03-GettingStarted/01-first-server/solution/java/`
   - Δημιουργήστε και εκτελέστε τον server της αριθμομηχανής:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Ο server θα πρέπει να τρέχει στο `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` είναι μια Java εφαρμογή που δείχνει πώς να:
- Συνδεθείτε σε MCP server χρησιμοποιώντας Server-Sent Events (SSE) μεταφορά
- Λίστα διαθέσιμων εργαλείων από τον server
- Κλήση διαφόρων λειτουργιών αριθμομηχανής απομακρυσμένα
- Διαχείριση απαντήσεων και εμφάνιση αποτελεσμάτων

## Πώς Λειτουργεί

Ο client χρησιμοποιεί το Spring AI MCP framework για να:

1. **Εγκαθιδρύσει Σύνδεση**: Δημιουργεί έναν WebFlux SSE client transport για σύνδεση με τον server της αριθμομηχανής
2. **Αρχικοποίηση Client**: Ρυθμίζει τον MCP client και δημιουργεί τη σύνδεση
3. **Ανακάλυψη Εργαλείων**: Εμφανίζει όλες τις διαθέσιμες λειτουργίες της αριθμομηχανής
4. **Εκτέλεση Λειτουργιών**: Καλεί διάφορες μαθηματικές συναρτήσεις με δείγματα δεδομένων
5. **Εμφάνιση Αποτελεσμάτων**: Δείχνει τα αποτελέσματα κάθε υπολογισμού

## Δομή Έργου

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Βασικές Εξαρτήσεις

Το έργο χρησιμοποιεί τις παρακάτω βασικές εξαρτήσεις:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Αυτή η εξάρτηση παρέχει:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE μεταφορά για επικοινωνία μέσω web
- MCP πρωτόκολλο schemas και τύπους αιτημάτων/απαντήσεων

## Δημιουργία του Έργου

Δημιουργήστε το έργο χρησιμοποιώντας το Maven wrapper:

```cmd
.\mvnw clean install
```

## Εκτέλεση του Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Βεβαιωθείτε ότι ο server της αριθμομηχανής τρέχει στο `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Λίστα Εργαλείων** - Εμφανίζει όλες τις διαθέσιμες λειτουργίες της αριθμομηχανής
3. **Εκτέλεση Υπολογισμών**:
   - Πρόσθεση: 5 + 3 = 8
   - Αφαίρεση: 10 - 4 = 6
   - Πολλαπλασιασμός: 6 × 7 = 42
   - Διαίρεση: 20 ÷ 4 = 5
   - Δύναμη: 2^8 = 256
   - Τετραγωνική Ρίζα: √16 = 4
   - Απόλυτη Τιμή: |-5.5| = 5.5
   - Βοήθεια: Εμφανίζει τις διαθέσιμες λειτουργίες

## Αναμενόμενο Αποτέλεσμα

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Note**: Μπορεί να δείτε προειδοποιήσεις του Maven σχετικά με υπολειπόμενα νήματα στο τέλος - αυτό είναι φυσιολογικό για αντιδραστικές εφαρμογές και δεν υποδηλώνει σφάλμα.

## Κατανόηση του Κώδικα

### 1. Ρύθμιση Μεταφοράς
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Αυτό δημιουργεί μια SSE (Server-Sent Events) μεταφορά που συνδέεται με τον server της αριθμομηχανής.

### 2. Δημιουργία Client
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Δημιουργεί έναν συγχρονικό MCP client και αρχικοποιεί τη σύνδεση.

### 3. Κλήση Εργαλείων
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Καλεί το εργαλείο "add" με παραμέτρους a=5.0 και b=3.0.

## Επίλυση Προβλημάτων

### Ο Server δεν τρέχει
Αν λαμβάνετε σφάλματα σύνδεσης, βεβαιωθείτε ότι ο server της αριθμομηχανής από το Κεφάλαιο 01 τρέχει:
```
Error: Connection refused
```
**Λύση**: Ξεκινήστε πρώτα τον server της αριθμομηχανής.

### Η θύρα είναι ήδη σε χρήση
Αν η θύρα 8080 είναι κατειλημμένη:
```
Error: Address already in use
```
**Λύση**: Σταματήστε άλλες εφαρμογές που χρησιμοποιούν τη θύρα 8080 ή τροποποιήστε τον server να χρησιμοποιεί διαφορετική θύρα.

### Σφάλματα Κατασκευής
Αν αντιμετωπίζετε σφάλματα κατά τη δημιουργία:
```cmd
.\mvnw clean install -DskipTests
```

## Μάθετε Περισσότερα

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.