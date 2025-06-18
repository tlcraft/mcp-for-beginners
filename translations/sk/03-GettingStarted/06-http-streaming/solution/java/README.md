<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:49:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "sk"
}
-->
# Calculator HTTP Streaming Demo

Tento projekt demonštruje HTTP streaming pomocou Server-Sent Events (SSE) so Spring Boot WebFlux. Skladá sa z dvoch aplikácií:

- **Calculator Server**: reaktívna webová služba, ktorá vykonáva výpočty a streamuje výsledky pomocou SSE
- **Calculator Client**: klientská aplikácia, ktorá spotrebúva streamovací endpoint

## Požiadavky

- Java 17 alebo novšia
- Maven 3.6 alebo novší

## Štruktúra projektu

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

## Ako to funguje

1. **Calculator Server** sprístupňuje `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Spotrebúva streamovaciu odpoveď
   - Vypisuje každú udalosť do konzoly

## Spustenie aplikácií

### Možnosť 1: Použitie Maven (odporúčané)

#### 1. Spustenie Calculator Servera

Otvorte terminál a prejdite do adresára servera:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Server sa spustí na `http://localhost:8080`

Mali by ste vidieť výstup ako:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Spustenie Calculator Clienta

Otvorte **nový terminál** a prejdite do adresára klienta:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klient sa pripojí k serveru, vykoná výpočet a zobrazí streamované výsledky.

### Možnosť 2: Priame použitie Java

#### 1. Preložte a spustite server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Preložte a spustite klienta:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Manuálne testovanie servera

Server môžete otestovať aj cez webový prehliadač alebo curl:

### Použitie webového prehliadača:
Navštívte: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Použitie curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Očakávaný výstup

Pri spustení klienta by ste mali vidieť streamovaný výstup podobný:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Podporované operácie

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
- Vracia Server-Sent Events s priebehom výpočtu a výsledkom

**Príklad požiadavky:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Príklad odpovede:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Riešenie problémov

### Bežné problémy

1. **Port 8080 je už obsadený**
   - Zastavte iné aplikácie používajúce port 8080
   - Alebo zmeňte port servera v `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, ak beží ako pozadový proces

## Technologický stack

- **Spring Boot 3.3.1** - aplikačný framework
- **Spring WebFlux** - reaktívny webový framework
- **Project Reactor** - knižnica pre reaktívne streamy
- **Netty** - server s neblokujúcim I/O
- **Maven** - nástroj na build
- **Java 17+** - programovací jazyk

## Ďalšie kroky

Vyskúšajte upraviť kód tak, aby:
- Pridal viac matematických operácií
- Zahrnul spracovanie chýb pre neplatné operácie
- Pridal logovanie požiadaviek a odpovedí
- Implementoval autentifikáciu
- Pridal jednotkové testy

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.