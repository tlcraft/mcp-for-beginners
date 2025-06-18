<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:48:11+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "nl"
}
-->
# Calculator HTTP Streaming Demo

Dit project toont HTTP streaming met Server-Sent Events (SSE) in Spring Boot WebFlux. Het bestaat uit twee applicaties:

- **Calculator Server**: een reactieve webservice die berekeningen uitvoert en resultaten via SSE streamt  
- **Calculator Client**: een clientapplicatie die de streaming endpoint consumeert

## Vereisten

- Java 17 of hoger  
- Maven 3.6 of hoger

## Projectstructuur

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

## Hoe het werkt

1. De **Calculator Server** maakt `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` beschikbaar  
   - Consumeert de streaming response  
   - Drukt elk event af in de console

## Applicaties starten

### Optie 1: Met Maven (aanbevolen)

#### 1. Start de Calculator Server

Open een terminal en ga naar de servermap:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

De server start op `http://localhost:8080`

Je ziet output zoals:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Start de Calculator Client

Open een **nieuwe terminal** en ga naar de clientmap:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

De client maakt verbinding met de server, voert de berekening uit en toont de streaming resultaten.

### Optie 2: Java direct gebruiken

#### 1. Compileer en start de server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Compileer en start de client:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Server handmatig testen

Je kunt de server ook testen met een webbrowser of curl:

### Met een webbrowser:  
Bezoek: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Met curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Verwachte output

Bij het draaien van de client zie je streaming output zoals:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Ondersteunde bewerkingen

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
- Stuurt Server-Sent Events met voortgang en resultaat van de berekening

**Voorbeeld request:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Voorbeeld response:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Problemen oplossen

### Veelvoorkomende problemen

1. **Poort 8080 is al in gebruik**  
   - Stop andere applicaties die poort 8080 gebruiken  
   - Of verander de serverpoort in `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` als je de server op de achtergrond draait

## Technologieën

- **Spring Boot 3.3.1** - Applicatieframework  
- **Spring WebFlux** - Reactief webframework  
- **Project Reactor** - Reactive streams bibliotheek  
- **Netty** - Non-blocking I/O server  
- **Maven** - Build tool  
- **Java 17+** - Programmeertaal

## Volgende stappen

Probeer de code aan te passen om:  
- Meer wiskundige bewerkingen toe te voegen  
- Foutafhandeling voor ongeldige bewerkingen te implementeren  
- Request/response logging toe te voegen  
- Authenticatie te implementeren  
- Unit tests toe te voegen

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal dient als de gezaghebbende bron te worden beschouwd. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.