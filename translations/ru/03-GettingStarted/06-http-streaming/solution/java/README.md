<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:43:30+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "ru"
}
-->
# Демонстрация HTTP-стриминга калькулятора

Этот проект демонстрирует HTTP-стриминг с использованием Server-Sent Events (SSE) на базе Spring Boot WebFlux. Он состоит из двух приложений:

- **Calculator Server**: реактивный веб-сервис, который выполняет вычисления и передает результаты через SSE
- **Calculator Client**: клиентское приложение, которое потребляет стриминговый эндпоинт

## Требования

- Java 17 или новее
- Maven 3.6 или новее

## Структура проекта

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

## Как это работает

1. **Calculator Server** открывает эндпоинт `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Потребляет стриминговый ответ
   - Выводит каждое событие в консоль

## Запуск приложений

### Вариант 1: через Maven (рекомендуется)

#### 1. Запустите Calculator Server

Откройте терминал и перейдите в директорию сервера:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Сервер запустится по адресу `http://localhost:8080`

Вы увидите вывод примерно такого вида:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Запустите Calculator Client

Откройте **новый терминал** и перейдите в директорию клиента:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Клиент подключится к серверу, выполнит вычисление и покажет результаты в режиме стрима.

### Вариант 2: запуск напрямую через Java

#### 1. Скомпилируйте и запустите сервер:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Скомпилируйте и запустите клиент:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ручное тестирование сервера

Вы также можете протестировать сервер через браузер или curl:

### Через браузер:
Перейдите по адресу: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Через curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Ожидаемый результат

При запуске клиента вы увидите стриминговый вывод, похожий на следующий:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Поддерживаемые операции

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
- Возвращает Server-Sent Events с прогрессом вычислений и результатом

**Пример запроса:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Пример ответа:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Устранение неполадок

### Частые проблемы

1. **Порт 8080 уже занят**
   - Остановите другие приложения, использующие порт 8080
   - Или измените порт сервера в `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, если сервер запущен в фоновом режиме

## Технологический стек

- **Spring Boot 3.3.1** – фреймворк приложения
- **Spring WebFlux** – реактивный веб-фреймворк
- **Project Reactor** – библиотека реактивных потоков
- **Netty** – сервер с неблокирующим вводом-выводом
- **Maven** – инструмент сборки
- **Java 17+** – язык программирования

## Следующие шаги

Попробуйте изменить код, чтобы:
- Добавить больше математических операций
- Включить обработку ошибок для некорректных операций
- Добавить логирование запросов и ответов
- Реализовать аутентификацию
- Добавить модульные тесты

**Отказ от ответственности**:  
Этот документ был переведен с использованием сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.