<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:47:21+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "sv"
}
-->
# Calculator HTTP Streaming Demo

Det här projektet visar HTTP-streaming med Server-Sent Events (SSE) i Spring Boot WebFlux. Det består av två applikationer:

- **Calculator Server**: En reaktiv webbservice som utför beräkningar och strömmar resultat med SSE
- **Calculator Client**: En klientapplikation som konsumerar streaming-endpointen

## Förutsättningar

- Java 17 eller högre
- Maven 3.6 eller högre

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

## Hur det fungerar

1. **Calculator Server** exponerar `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Konsumerar streaming-svaret
   - Skriver ut varje event i konsolen

## Köra applikationerna

### Alternativ 1: Använda Maven (Rekommenderas)

#### 1. Starta Calculator Server

Öppna en terminal och gå till servermappen:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Servern startar på `http://localhost:8080`

Du bör se utdata som:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Kör Calculator Client

Öppna en **ny terminal** och gå till klientmappen:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klienten kopplar upp sig mot servern, utför beräkningen och visar streaming-resultaten.

### Alternativ 2: Använda Java direkt

#### 1. Kompilera och kör servern:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Kompilera och kör klienten:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Testa servern manuellt

Du kan också testa servern via webbläsare eller curl:

### Med webbläsare:
Besök: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Med curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Förväntad utdata

När du kör klienten bör du se streaming-utdata liknande:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Stödda operationer

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
- Returnerar Server-Sent Events med beräkningsprogress och resultat

**Exempel på förfrågan:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Exempel på svar:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Felsökning

### Vanliga problem

1. **Port 8080 används redan**
   - Stoppa andra applikationer som använder port 8080
   - Eller ändra serverport i `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` om du kör som bakgrundsprocess

## Teknologistack

- **Spring Boot 3.3.1** - Applikationsramverk
- **Spring WebFlux** - Reaktivt webb-ramverk
- **Project Reactor** - Bibliotek för reaktiva strömmar
- **Netty** - Icke-blockerande I/O-server
- **Maven** - Byggverktyg
- **Java 17+** - Programmeringsspråk

## Nästa steg

Prova att ändra koden för att:
- Lägga till fler matematiska operationer
- Inkludera felhantering för ogiltiga operationer
- Lägg till loggning av förfrågningar/svar
- Implementera autentisering
- Lägga till enhetstester

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För viktig information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.