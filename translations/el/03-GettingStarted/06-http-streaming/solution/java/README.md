<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:46:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "el"
}
-->
# Calculator HTTP Streaming Demo

Αυτό το έργο παρουσιάζει το HTTP streaming χρησιμοποιώντας Server-Sent Events (SSE) με Spring Boot WebFlux. Αποτελείται από δύο εφαρμογές:

- **Calculator Server**: Μια αντιδραστική web υπηρεσία που εκτελεί υπολογισμούς και μεταδίδει αποτελέσματα μέσω SSE
- **Calculator Client**: Μια εφαρμογή πελάτη που καταναλώνει το streaming endpoint

## Απαιτήσεις

- Java 17 ή νεότερη έκδοση
- Maven 3.6 ή νεότερη έκδοση

## Δομή Έργου

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## Πώς Λειτουργεί

1. Ο **Calculator Server** εκθέτει το `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Καταναλώνει την απάντηση streaming
   - Εκτυπώνει κάθε event στην κονσόλα

## Εκτέλεση των Εφαρμογών

### Επιλογή 1: Χρήση Maven (Συνιστάται)

#### 1. Εκκίνηση του Calculator Server

Άνοιξε ένα τερματικό και πήγαινε στον φάκελο του server:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Ο server θα ξεκινήσει στο `http://localhost:8080`

Θα δεις έξοδο σαν την παρακάτω:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Εκτέλεση του Calculator Client

Άνοιξε ένα **νέο τερματικό** και πήγαινε στον φάκελο του client:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Ο client θα συνδεθεί με τον server, θα εκτελέσει τον υπολογισμό και θα εμφανίσει τα streaming αποτελέσματα.

### Επιλογή 2: Χρήση Java απευθείας

#### 1. Μεταγλώττιση και εκτέλεση του server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Μεταγλώττιση και εκτέλεση του client:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Χειροκίνητος Έλεγχος του Server

Μπορείς επίσης να δοκιμάσεις τον server χρησιμοποιώντας έναν web browser ή curl:

### Χρήση web browser:
Επισκέψου: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Χρήση curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Αναμενόμενη Έξοδος

Κατά την εκτέλεση του client, θα πρέπει να δεις streaming έξοδο παρόμοια με:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Υποστηριζόμενες Λειτουργίες

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Επιστρέφει Server-Sent Events με την πρόοδο και το αποτέλεσμα του υπολογισμού

**Παράδειγμα Αιτήματος:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Παράδειγμα Απάντησης:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Αντιμετώπιση Προβλημάτων

### Συχνά Προβλήματα

1. **Η θύρα 8080 χρησιμοποιείται ήδη**
   - Τερμάτισε οποιαδήποτε άλλη εφαρμογή που χρησιμοποιεί τη θύρα 8080
   - Ή άλλαξε τη θύρα του server στο `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` αν τρέχει ως background process

## Τεχνολογικό Υπόβαθρο

- **Spring Boot 3.3.1** - Πλαίσιο εφαρμογής
- **Spring WebFlux** - Αντιδραστικό web framework
- **Project Reactor** - Βιβλιοθήκη reactive streams
- **Netty** - Μη αποκλειστικός I/O server
- **Maven** - Εργαλείο κατασκευής
- **Java 17+** - Γλώσσα προγραμματισμού

## Επόμενα Βήματα

Δοκίμασε να τροποποιήσεις τον κώδικα ώστε να:
- Προσθέσεις περισσότερες μαθηματικές λειτουργίες
- Ενσωματώσεις χειρισμό σφαλμάτων για μη έγκυρες λειτουργίες
- Προσθέσεις καταγραφή αιτημάτων/απαντήσεων
- Υλοποιήσεις authentication
- Προσθέσεις unit tests

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρότι επιδιώκουμε την ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.