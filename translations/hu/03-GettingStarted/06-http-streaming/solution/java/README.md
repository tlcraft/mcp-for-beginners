<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:49:21+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "hu"
}
-->
# Calculator HTTP Streaming Demo

Ez a projekt a HTTP streaminget mutatja be Server-Sent Events (SSE) segítségével, Spring Boot WebFlux használatával. Két alkalmazásból áll:

- **Calculator Server**: egy reaktív webszolgáltatás, amely számításokat végez és SSE-n keresztül továbbítja az eredményeket
- **Calculator Client**: egy kliens alkalmazás, amely fogyasztja a streaming végpontot

## Előfeltételek

- Java 17 vagy újabb
- Maven 3.6 vagy újabb

## Projekt felépítése

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

## Hogyan működik

1. A **Calculator Server** elérhetővé teszi a `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Fogyasztja a streaming választ
   - Minden eseményt kiír a konzolra

## Az alkalmazások futtatása

### 1. lehetőség: Maven használata (ajánlott)

#### 1. Indítsd el a Calculator Server-t

Nyiss egy terminált, és lépj a szerver könyvtárába:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

A szerver a `http://localhost:8080` címen fog futni

Ilyen kimenetet kell látnod:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Futtasd a Calculator Client-et

Nyiss egy **új terminált**, és lépj a kliens könyvtárába:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

A kliens csatlakozik a szerverhez, végrehajtja a számítást, és megjeleníti a streaming eredményeket.

### 2. lehetőség: Java közvetlen futtatása

#### 1. Fordítsd és futtasd a szervert:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Fordítsd és futtasd a klienst:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## A szerver manuális tesztelése

Tesztelheted a szervert böngészőből vagy curl-lel is:

### Böngésző használata:
Látogass el ide: `http://localhost:8080/calculate?a=10&b=5&op=add`

### curl használata:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Várt kimenet

A kliens futtatásakor hasonló streaming kimenetet kell látnod:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Támogatott műveletek

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
- Visszaad Server-Sent Eventeket a számítás állapotáról és eredményéről

**Példa kérés:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Példa válasz:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Hibakeresés

### Gyakori problémák

1. **A 8080-as port már használatban van**
   - Állítsd le azokat az alkalmazásokat, amelyek használják a 8080-as portot
   - Vagy módosítsd a szerver portját a `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` fájlban, ha háttérben fut

## Technológiai környezet

- **Spring Boot 3.3.1** - Alkalmazás keretrendszer
- **Spring WebFlux** - Reaktív web keretrendszer
- **Project Reactor** - Reaktív stream könyvtár
- **Netty** - Nem blokkoló I/O szerver
- **Maven** - Build eszköz
- **Java 17+** - Programozási nyelv

## Következő lépések

Próbáld meg módosítani a kódot, hogy:
- Több matematikai műveletet támogasson
- Hibakezelést tartalmazzon érvénytelen műveletek esetén
- Kérés/válasz naplózást valósítson meg
- Hitelesítést építsen be
- Egységteszteket adjon hozzá

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.