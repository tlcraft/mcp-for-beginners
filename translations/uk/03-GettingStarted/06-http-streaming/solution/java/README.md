<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:51:05+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "uk"
}
-->
# Calculator HTTP Streaming Demo

Цей проєкт демонструє HTTP стрімінг за допомогою Server-Sent Events (SSE) з Spring Boot WebFlux. Він складається з двох додатків:

- **Calculator Server**: реактивний веб-сервіс, який виконує обчислення та передає результати через SSE
- **Calculator Client**: клієнтський додаток, який споживає стрімінгову кінцеву точку

## Вимоги

- Java 17 або новіша версія
- Maven 3.6 або новіша версія

## Структура проєкту

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

## Як це працює

1. **Calculator Server** надає `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Споживає стрімінгову відповідь
   - Виводить кожну подію у консоль

## Запуск додатків

### Варіант 1: Використання Maven (рекомендовано)

#### 1. Запустіть Calculator Server

Відкрийте термінал і перейдіть до директорії сервера:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Сервер запуститься за адресою `http://localhost:8080`

Ви побачите приблизно такий вивід:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Запустіть Calculator Client

Відкрийте **новий термінал** і перейдіть до директорії клієнта:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Клієнт підключиться до сервера, виконає обчислення та покаже результати у стрімі.

### Варіант 2: Запуск безпосередньо через Java

#### 1. Скомпілюйте та запустіть сервер:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Скомпілюйте та запустіть клієнт:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ручне тестування сервера

Також ви можете протестувати сервер через браузер або curl:

### Через браузер:
Перейдіть за адресою: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Через curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Очікуваний результат

При запуску клієнта ви побачите стрімінговий вивід, схожий на цей:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Підтримувані операції

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
- Повертає Server-Sent Events з прогресом обчислень та результатом

**Приклад запиту:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Приклад відповіді:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Вирішення проблем

### Поширені проблеми

1. **Порт 8080 вже використовується**
   - Зупиніть інші додатки, які використовують порт 8080
   - Або змініть порт сервера у `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, якщо сервер запущений у фоновому режимі

## Технологічний стек

- **Spring Boot 3.3.1** - фреймворк додатка
- **Spring WebFlux** - реактивний веб-фреймворк
- **Project Reactor** - бібліотека реактивних стрімів
- **Netty** - сервер з неблокуючим ввід/виводом
- **Maven** - інструмент збірки
- **Java 17+** - мова програмування

## Подальші кроки

Спробуйте змінити код, щоб:
- Додати більше математичних операцій
- Впровадити обробку помилок для некоректних операцій
- Додати логування запитів/відповідей
- Реалізувати аутентифікацію
- Додати модульні тести

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.