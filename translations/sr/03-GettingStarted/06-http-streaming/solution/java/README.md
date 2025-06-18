<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:50:20+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "sr"
}
-->
# Calculator HTTP Streaming Demo

Овај пројекат демонстрира HTTP стриминг користећи Server-Sent Events (SSE) са Spring Boot WebFlux. Састоји се из две апликације:

- **Calculator Server**: реактивни веб сервис који изводи прорачуне и стримује резултате користећи SSE
- **Calculator Client**: клијент апликација која конзумира стриминг крајњу тачку

## Захтеви

- Java 17 или новији
- Maven 3.6 или новији

## Структура пројекта

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

## Како ради

1. **Calculator Server** излаже `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Конзумира стриминг одговор
   - Исписује сваки догађај на конзолу

## Покретање апликација

### Опција 1: Користећи Maven (препоручено)

#### 1. Покрените Calculator Server

Отворите терминал и идите у директоријум сервера:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Сервер ће се покренути на `http://localhost:8080`

Требало би да видите излаз сличан овом:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Покрените Calculator Client

Отворите **нови терминал** и идите у директоријум клијента:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Клијент ће се повезати на сервер, извршити прорачун и приказати резултате стриминга.

### Опција 2: Директно коришћење Java

#### 1. Компилирајте и покрените сервер:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Компилирајте и покрените клијента:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ручно тестирање сервера

Сервер можете тестирати и помоћу веб прегледача или curl:

### Користећи веб прегледач:
Посетите: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Користећи curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Очекивани излаз

Када покренете клијента, требало би да видите стриминг излаз сличан овом:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Подржане операције

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
- Враћа Server-Sent Events са напретком прорачуна и резултатом

**Пример захтева:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Пример одговора:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Решавање проблема

### Чести проблеми

1. **Порт 8080 је већ у употреби**
   - Зауставите све друге апликације које користе порт 8080
   - Или промените порт сервера у `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` ако се покреће у позадини

## Технолошки стек

- **Spring Boot 3.3.1** - Апликациони фрејмворк
- **Spring WebFlux** - Реактивни веб фрејмворк
- **Project Reactor** - Библиотека за реактивне токове
- **Netty** - Сервер за не-блокирајући улаз/излаз
- **Maven** - Алат за изградњу
- **Java 17+** - Програмски језик

## Следећи кораци

Пробајте да измените код да:
- Додате више математичких операција
- Укључите обраду грешака за неважеће операције
- Додате логовање захтева/одговора
- Имплементирате аутентификацију
- Додате јединичне тестове

**Одрицање одговорности**:  
Овај документ је преведен коришћењем АИ сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, молимо имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала коришћењем овог превода.