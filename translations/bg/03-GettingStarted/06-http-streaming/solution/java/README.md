<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:50:10+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "bg"
}
-->
# Calculator HTTP Streaming Demo

Този проект демонстрира HTTP стрийминг с използване на Server-Sent Events (SSE) и Spring Boot WebFlux. Състои се от две приложения:

- **Calculator Server**: реактивен уеб сървис, който извършва изчисления и предава резултатите чрез SSE
- **Calculator Client**: клиентско приложение, което консумира стрийминг крайна точка

## Изисквания

- Java 17 или по-нова версия
- Maven 3.6 или по-нова версия

## Структура на проекта

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

## Как работи

1. **Calculator Server** предоставя `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Консумира стрийминг отговора
   - Извежда всяко събитие в конзолата

## Стартиране на приложенията

### Вариант 1: Използване на Maven (препоръчително)

#### 1. Стартирайте Calculator Server

Отворете терминал и навигирайте до директорията на сървъра:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Сървърът ще стартира на `http://localhost:8080`

Ще видите изход като:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Стартирайте Calculator Client

Отворете **нов терминал** и навигирайте до директорията на клиента:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Клиентът ще се свърже със сървъра, ще извърши изчислението и ще покаже стрийминг резултатите.

### Вариант 2: Използване на Java директно

#### 1. Компилирайте и стартирайте сървъра:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Компилирайте и стартирайте клиента:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ръчно тестване на сървъра

Можете да тествате сървъра и с уеб браузър или curl:

### С уеб браузър:
Посетете: `http://localhost:8080/calculate?a=10&b=5&op=add`

### С curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Очакван изход

При стартиране на клиента, трябва да видите стрийминг изход подобен на:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Поддържани операции

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
- Връща Server-Sent Events с прогреса и резултата от изчислението

**Примерна заявка:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Примерен отговор:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Отстраняване на проблеми

### Чести проблеми

1. **Порт 8080 вече се използва**
   - Затворете всички други приложения, които използват порт 8080
   - Или променете порта на сървъра в `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, ако работи като фонов процес

## Технологичен стек

- **Spring Boot 3.3.1** - Фреймуърк за приложения
- **Spring WebFlux** - Реактивен уеб фреймуърк
- **Project Reactor** - Библиотека за реактивни потоци
- **Netty** - Неблокиращ I/O сървър
- **Maven** - Инструмент за билд
- **Java 17+** - Програмен език

## Следващи стъпки

Опитайте да модифицирате кода, за да:
- Добавите още математически операции
- Включите обработка на грешки при невалидни операции
- Добавите логване на заявки и отговори
- Имплементирате автентикация
- Добавите unit тестове

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за никакви недоразумения или неправилни тълкувания, произтичащи от използването на този превод.