<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:49:56+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "ro"
}
-->
# Demo Streaming HTTP Calculator

Acest proiect demonstrează streaming-ul HTTP folosind Server-Sent Events (SSE) cu Spring Boot WebFlux. Este compus din două aplicații:

- **Calculator Server**: Un serviciu web reactiv care efectuează calcule și transmite rezultatele prin SSE
- **Calculator Client**: O aplicație client care consumă endpoint-ul de streaming

## Cerințe

- Java 17 sau versiune superioară
- Maven 3.6 sau versiune superioară

## Structura Proiectului

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

## Cum Funcționează

1. **Calculator Server** expune `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Consumă răspunsul de tip streaming
   - Afișează fiecare eveniment în consolă

## Pornirea Aplicațiilor

### Opțiunea 1: Folosind Maven (Recomandat)

#### 1. Pornește Calculator Server

Deschide un terminal și navighează în directorul serverului:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Serverul va porni pe `http://localhost:8080`

Ar trebui să vezi un output asemănător cu:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Rulează Calculator Client

Deschide un **nou terminal** și navighează în directorul clientului:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Clientul se va conecta la server, va efectua calculul și va afișa rezultatele în streaming.

### Opțiunea 2: Folosind Java direct

#### 1. Compilează și rulează serverul:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Compilează și rulează clientul:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Testarea Serverului Manual

Poți testa serverul și folosind un browser web sau curl:

### Folosind un browser:
Accesează: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Folosind curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Output Așteptat

La rularea clientului, ar trebui să vezi un output în streaming similar cu:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Operații Suportate

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
- Returnează Server-Sent Events cu progresul și rezultatul calculului

**Exemplu de Cerere:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Exemplu de Răspuns:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Depanare

### Probleme Comune

1. **Portul 8080 este deja folosit**
   - Oprește orice altă aplicație care folosește portul 8080
   - Sau schimbă portul serverului în `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` dacă rulezi în fundal

## Tehnologii Folosite

- **Spring Boot 3.3.1** - Framework pentru aplicații
- **Spring WebFlux** - Framework web reactiv
- **Project Reactor** - Bibliotecă pentru fluxuri reactive
- **Netty** - Server I/O non-blocant
- **Maven** - Unealtă de build
- **Java 17+** - Limbaj de programare

## Pași Următori

Încearcă să modifici codul pentru a:
- Adăuga mai multe operații matematice
- Include tratarea erorilor pentru operații invalide
- Adăuga logare pentru cereri/răspunsuri
- Implementa autentificare
- Adăuga teste unitare

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.