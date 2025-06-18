<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:47:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "da"
}
-->
# Calculator HTTP Streaming Demo

Dette projekt demonstrerer HTTP streaming ved brug af Server-Sent Events (SSE) med Spring Boot WebFlux. Det består af to applikationer:

- **Calculator Server**: En reaktiv webservice, der udfører beregninger og streamer resultater ved hjælp af SSE
- **Calculator Client**: En klientapplikation, der forbruger streaming-endpointet

## Forudsætninger

- Java 17 eller nyere
- Maven 3.6 eller nyere

## Projektstruktur

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

## Sådan virker det

1. **Calculator Server** eksponerer en `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Forbruger den streamede respons
   - Printer hver event til konsollen

## Kørsel af applikationerne

### Mulighed 1: Brug af Maven (anbefalet)

#### 1. Start Calculator Server

Åbn en terminal og naviger til server-mappen:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Serveren starter på `http://localhost:8080`

Du skulle se output som:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Kør Calculator Client

Åbn en **ny terminal** og naviger til klient-mappen:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klienten opretter forbindelse til serveren, udfører beregningen og viser de streamede resultater.

### Mulighed 2: Brug Java direkte

#### 1. Kompiler og kør serveren:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Kompiler og kør klienten:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Manuel test af serveren

Du kan også teste serveren via en webbrowser eller curl:

### Brug af webbrowser:
Besøg: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Brug af curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Forventet output

Når klienten kører, bør du se streamet output som:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Understøttede operationer

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
- Returnerer Server-Sent Events med beregningsprogression og resultat

**Eksempel på forespørgsel:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Eksempel på svar:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Fejlfinding

### Almindelige problemer

1. **Port 8080 er allerede i brug**
   - Stop andre applikationer, der bruger port 8080
   - Eller skift serverporten i `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` hvis den kører som baggrundsproces

## Teknologistak

- **Spring Boot 3.3.1** - Applikationsframework
- **Spring WebFlux** - Reaktivt webframework
- **Project Reactor** - Bibliotek til reaktive streams
- **Netty** - Non-blocking I/O server
- **Maven** - Byggeværktøj
- **Java 17+** - Programmeringssprog

## Næste skridt

Prøv at ændre koden til at:
- Tilføje flere matematiske operationer
- Inkludere fejlhåndtering for ugyldige operationer
- Tilføje logning af forespørgsler/svar
- Implementere autentificering
- Tilføje enhedstests

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.