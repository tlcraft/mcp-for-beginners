<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:50:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "sl"
}
-->
# Calculator HTTP Streaming Demo

Ta projekt prikazuje HTTP pretakanje z uporabo Server-Sent Events (SSE) v Spring Boot WebFlux. Sestavljen je iz dveh aplikacij:

- **Calculator Server**: reaktivna spletna storitev, ki izvaja izračune in pretaka rezultate prek SSE
- **Calculator Client**: odjemalska aplikacija, ki uporablja streaming endpoint

## Zahteve

- Java 17 ali novejša
- Maven 3.6 ali novejši

## Struktura projekta

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

## Kako deluje

1. **Calculator Server** izpostavi `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Porabi streaming odgovor
   - Vsak dogodek izpiše v konzolo

## Zagon aplikacij

### Možnost 1: z uporabo Mavena (priporočeno)

#### 1. Zaženi Calculator Server

Odpri terminal in pojdi v mapo serverja:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Strežnik bo zagnan na `http://localhost:8080`

Videti bi moral izhod, kot je:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Zaženi Calculator Client

Odpri **nov terminal** in pojdi v mapo klienta:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klient se bo povezal s strežnikom, izvedel izračun in prikazal streaming rezultate.

### Možnost 2: neposreden zagon z Javo

#### 1. Prevedi in zaženi strežnik:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Prevedi in zaženi klienta:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ročno testiranje strežnika

Strežnik lahko preizkusiš tudi z brskalnikom ali curl:

### Z brskalnikom:
Obišči: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Z uporabo curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Pričakovani izhod

Ko zaženeš klienta, bi moral videti streaming izhod, podoben temu:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Podprte operacije

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
- Vrne Server-Sent Events z napredkom izračuna in rezultatom

**Primer zahteve:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Primer odgovora:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Reševanje težav

### Pogoste težave

1. **Vrata 8080 so že zasedena**
   - Ustavi druge aplikacije, ki uporabljajo vrata 8080
   - Ali spremeni vrata strežnika v `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, če teče kot ozadinski proces

## Tehnološki sklad

- **Spring Boot 3.3.1** - aplikacijski okvir
- **Spring WebFlux** - reaktivni spletni okvir
- **Project Reactor** - knjižnica za reaktivne tokove
- **Netty** - strežnik z neblokirnim I/O
- **Maven** - orodje za gradnjo
- **Java 17+** - programski jezik

## Naslednji koraki

Poskusi spremeniti kodo, da:
- dodaš več matematičnih operacij
- vključiš obravnavo napak za neveljavne operacije
- dodaš beleženje zahtev in odgovorov
- implementiraš avtentikacijo
- dodaš enotne teste

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvorno jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za kakršnekoli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.