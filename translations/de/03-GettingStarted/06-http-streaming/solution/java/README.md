<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:43:21+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "de"
}
-->
# Calculator HTTP Streaming Demo

Dieses Projekt demonstriert HTTP-Streaming mit Server-Sent Events (SSE) unter Verwendung von Spring Boot WebFlux. Es besteht aus zwei Anwendungen:

- **Calculator Server**: Ein reaktiver Webservice, der Berechnungen durchführt und Ergebnisse per SSE streamt
- **Calculator Client**: Eine Client-Anwendung, die den Streaming-Endpunkt konsumiert

## Voraussetzungen

- Java 17 oder höher
- Maven 3.6 oder höher

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

## Funktionsweise

1. Der **Calculator Server** stellt einen `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` Endpunkt bereit
   - Konsumiert die Streaming-Antwort
   - Gibt jedes Event in der Konsole aus

## Anwendungen starten

### Option 1: Mit Maven (empfohlen)

#### 1. Starte den Calculator Server

Öffne ein Terminal und wechsle in das Server-Verzeichnis:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Der Server startet unter `http://localhost:8080`

Du solltest eine Ausgabe wie folgt sehen:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Starte den Calculator Client

Öffne ein **neues Terminal** und wechsle in das Client-Verzeichnis:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Der Client verbindet sich mit dem Server, führt die Berechnung aus und zeigt die Streaming-Ergebnisse an.

### Option 2: Java direkt verwenden

#### 1. Server kompilieren und starten:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Client kompilieren und starten:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Server manuell testen

Du kannst den Server auch mit einem Webbrowser oder curl testen:

### Mit einem Webbrowser:
Besuche: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Mit curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Erwartete Ausgabe

Beim Ausführen des Clients solltest du eine Streaming-Ausgabe ähnlich dieser sehen:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Unterstützte Operationen

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
- Gibt Server-Sent Events mit Berechnungsfortschritt und Ergebnis zurück

**Beispiel-Anfrage:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Beispiel-Antwort:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Fehlerbehebung

### Häufige Probleme

1. **Port 8080 ist bereits belegt**
   - Beende alle anderen Anwendungen, die Port 8080 verwenden
   - Oder ändere den Server-Port in `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, falls der Server im Hintergrund läuft

## Technologie-Stack

- **Spring Boot 3.3.1** - Anwendungsframework
- **Spring WebFlux** - Reaktives Webframework
- **Project Reactor** - Reactive Streams Bibliothek
- **Netty** - Non-blocking I/O Server
- **Maven** - Build-Tool
- **Java 17+** - Programmiersprache

## Nächste Schritte

Versuche den Code zu ändern, um:
- Weitere mathematische Operationen hinzuzufügen
- Fehlerbehandlung für ungültige Operationen einzubauen
- Request-/Response-Logging zu integrieren
- Authentifizierung zu implementieren
- Unit-Tests hinzuzufügen

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, kann es bei automatischen Übersetzungen zu Fehlern oder Ungenauigkeiten kommen. Das Originaldokument in seiner ursprünglichen Sprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.