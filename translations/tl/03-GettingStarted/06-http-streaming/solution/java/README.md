<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:49:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "tl"
}
-->
# Calculator HTTP Streaming Demo

Ipinapakita ng proyektong ito ang HTTP streaming gamit ang Server-Sent Events (SSE) sa Spring Boot WebFlux. Binubuo ito ng dalawang aplikasyon:

- **Calculator Server**: Isang reactive web service na nagsasagawa ng mga kalkulasyon at nag-stream ng mga resulta gamit ang SSE  
- **Calculator Client**: Isang client application na kumokonsumo sa streaming endpoint

## Prerequisites

- Java 17 o mas mataas  
- Maven 3.6 o mas mataas

## Project Structure

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

## Paano Ito Gumagana

1. Inilalantad ng **Calculator Server** ang `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`  
   - Kinokonsumo ang streaming response  
   - Ipinapakita ang bawat event sa console

## Pagpapatakbo ng mga Aplikasyon

### Opsyon 1: Gamit ang Maven (Inirerekomenda)

#### 1. Simulan ang Calculator Server

Buksan ang terminal at pumunta sa server directory:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Magsisimula ang server sa `http://localhost:8080`

Makikita mo ang output na katulad ng:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Patakbuhin ang Calculator Client

Buksan ang **bagong terminal** at pumunta sa client directory:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Makakonekta ang client sa server, gagawin ang kalkulasyon, at ipapakita ang streaming na resulta.

### Opsyon 2: Direktang Gamitin ang Java

#### 1. I-compile at patakbuhin ang server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. I-compile at patakbuhin ang client:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Manwal na Pagsusuri sa Server

Pwede mo ring subukan ang server gamit ang web browser o curl:

### Gamit ang web browser:  
Bisitahin ang: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Gamit ang curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Inaasahang Output

Kapag pinatakbo ang client, makikita mo ang streaming output na tulad nito:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Sinusuportahang Mga Operasyon

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
- Nagbabalik ng Server-Sent Events na may progreso ng kalkulasyon at resulta

**Halimbawang Request:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Halimbawang Response:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Pag-aayos ng Problema

### Karaniwang Isyu

1. **Port 8080 ay ginagamit na**  
   - Itigil ang ibang aplikasyon na gumagamit ng port 8080  
   - O palitan ang port ng server sa `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` kung tumatakbo bilang background process

## Teknolohiyang Ginamit

- **Spring Boot 3.3.1** - Framework ng aplikasyon  
- **Spring WebFlux** - Reactive web framework  
- **Project Reactor** - Reactive streams library  
- **Netty** - Non-blocking I/O server  
- **Maven** - Build tool  
- **Java 17+** - Programming language

## Susunod na Hakbang

Subukan baguhin ang code para sa mga sumusunod:  
- Magdagdag ng iba pang mga operasyong pang-matematika  
- Isama ang error handling para sa mga invalid na operasyon  
- Magdagdag ng logging para sa request/response  
- Ipatupad ang authentication  
- Magdagdag ng unit tests

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami na maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.