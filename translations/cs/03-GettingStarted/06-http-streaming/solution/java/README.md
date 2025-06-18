<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:49:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "cs"
}
-->
# Calculator HTTP Streaming Demo

Tento projekt ukazuje HTTP streaming pomocí Server-Sent Events (SSE) ve Spring Boot WebFlux. Skládá se ze dvou aplikací:

- **Calculator Server**: reaktivní webová služba, která provádí výpočty a streamuje výsledky pomocí SSE  
- **Calculator Client**: klientská aplikace, která spotřebovává streamovaný endpoint

## Požadavky

- Java 17 nebo novější  
- Maven 3.6 nebo novější

## Struktura projektu

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

## Jak to funguje

1. **Calculator Server** vystavuje `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`  
   - Spotřebovává streamovanou odpověď  
   - Vypisuje každou událost do konzole

## Spuštění aplikací

### Možnost 1: Použití Maven (doporučeno)

#### 1. Spusťte Calculator Server

Otevřete terminál a přejděte do adresáře serveru:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Server poběží na `http://localhost:8080`

Měli byste vidět výstup podobný tomuto:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Spusťte Calculator Client

Otevřete **nový terminál** a přejděte do adresáře klienta:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klient se připojí k serveru, provede výpočet a zobrazí streamované výsledky.

### Možnost 2: Spuštění přímo pomocí Java

#### 1. Zkompilujte a spusťte server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Zkompilujte a spusťte klienta:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Manuální testování serveru

Server můžete otestovat také pomocí webového prohlížeče nebo curl:

### Použití webového prohlížeče:  
Navštivte: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Použití curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Očekávaný výstup

Při spuštění klienta byste měli vidět streamovaný výstup podobný:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Podporované operace

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
- Vrací Server-Sent Events s průběhem výpočtu a výsledkem

**Příklad požadavku:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Příklad odpovědi:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Řešení problémů

### Běžné problémy

1. **Port 8080 je již obsazen**  
   - Zastavte jiné aplikace používající port 8080  
   - Nebo změňte port serveru v `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, pokud server běží na pozadí

## Technologický stack

- **Spring Boot 3.3.1** - aplikační framework  
- **Spring WebFlux** - reaktivní webový framework  
- **Project Reactor** - knihovna pro reaktivní streamy  
- **Netty** - server s neblokujícím I/O  
- **Maven** - nástroj pro build  
- **Java 17+** - programovací jazyk

## Další kroky

Zkuste upravit kód tak, aby:  
- Přidal více matematických operací  
- Zahrnul ošetření chyb pro neplatné operace  
- Přidal logování požadavků/odpovědí  
- Implementoval autentizaci  
- Přidal jednotkové testy

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.