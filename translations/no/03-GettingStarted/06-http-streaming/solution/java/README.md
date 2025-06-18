<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:47:52+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "no"
}
-->
# Calculator HTTP Streaming Demo

Dette prosjektet demonstrerer HTTP streaming ved bruk av Server-Sent Events (SSE) med Spring Boot WebFlux. Det består av to applikasjoner:

- **Calculator Server**: En reaktiv webtjeneste som utfører beregninger og streamer resultater ved hjelp av SSE  
- **Calculator Client**: En klientapplikasjon som konsumerer streaming-endepunktet

## Forutsetninger

- Java 17 eller nyere  
- Maven 3.6 eller nyere  

## Prosjektstruktur

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

## Hvordan det fungerer

1. **Calculator Server** eksponerer `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`  
   - Konsumerer streaming-responsen  
   - Skriver ut hvert event til konsollen  

## Kjøre applikasjonene

### Alternativ 1: Bruke Maven (anbefalt)

#### 1. Start Calculator Server

Åpne et terminalvindu og naviger til server-mappen:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Serveren starter på `http://localhost:8080`

Du bør se output som:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Kjør Calculator Client

Åpne et **nytt terminalvindu** og naviger til klient-mappen:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klienten kobler til serveren, utfører beregningen og viser streaming-resultatene.

### Alternativ 2: Kjøre Java direkte

#### 1. Kompiler og kjør serveren:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Kompiler og kjør klienten:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Teste serveren manuelt

Du kan også teste serveren med en nettleser eller curl:

### Med nettleser:  
Besøk: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Med curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Forventet output

Når du kjører klienten, skal du se streaming-output som ligner på:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Støttede operasjoner

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
- Returnerer Server-Sent Events med beregningsprogresjon og resultat

**Eksempel på forespørsel:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Eksempel på respons:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Feilsøking

### Vanlige problemer

1. **Port 8080 er allerede i bruk**  
   - Stopp andre applikasjoner som bruker port 8080  
   - Eller endre serverport i `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` hvis serveren kjører i bakgrunnen  

## Teknologistack

- **Spring Boot 3.3.1** - Applikasjonsrammeverk  
- **Spring WebFlux** - Reaktivt web-rammeverk  
- **Project Reactor** - Bibliotek for reaktive streams  
- **Netty** - Ikke-blokkerende I/O-server  
- **Maven** - Byggeverktøy  
- **Java 17+** - Programmeringsspråk  

## Neste steg

Prøv å endre koden for å:  
- Legge til flere matematiske operasjoner  
- Inkludere feilhåndtering for ugyldige operasjoner  
- Legge til logging av forespørsler/responser  
- Implementere autentisering  
- Legge til enhetstester

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår som følge av bruk av denne oversettelsen.