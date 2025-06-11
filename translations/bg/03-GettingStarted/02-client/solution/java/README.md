<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:16:51+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "bg"
}
-->
# MCP Java клиент - демонстрация на калкулатор

Този проект показва как да се създаде Java клиент, който се свързва и взаимодейства със сървър MCP (Model Context Protocol). В този пример ще се свържем със сървъра на калкулатора от Глава 01 и ще извършим различни математически операции.

## Предварителни условия

Преди да стартирате този клиент, трябва да:

1. **Стартирате сървъра на калкулатора** от Глава 01:
   - Отидете в директорията на сървъра на калкулатора: `03-GettingStarted/01-first-server/solution/java/`
   - Компилирайте и стартирайте сървъра на калкулатора:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Сървърът трябва да работи на `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` е Java приложение, което демонстрира как да:
- Свържете се със сървър MCP чрез Server-Sent Events (SSE) транспорт
- Изведете списък с наличните инструменти от сървъра
- Извършите различни функции на калкулатора от разстояние
- Обработвате отговорите и показвате резултатите

## Как работи

Клиентът използва Spring AI MCP фреймуърк, за да:

1. **Установи връзка**: Създава WebFlux SSE клиентски транспорт за свързване със сървъра на калкулатора
2. **Инициализира клиента**: Настройва MCP клиента и установява връзката
3. **Открива инструменти**: Извежда списък с всички налични операции на калкулатора
4. **Изпълнява операции**: Извиква различни математически функции с примерни данни
5. **Показва резултатите**: Отразява резултатите от всяко изчисление

## Структура на проекта

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Основни зависимости

Проектът използва следните основни зависимости:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Тази зависимост предоставя:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE транспорт за уеб базирана комуникация
- MCP протоколни схеми и типове заявки/отговори

## Компилиране на проекта

Компилирайте проекта с помощта на Maven wrapper:

```cmd
.\mvnw clean install
```

## Стартиране на клиента

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Забележка**: Уверете се, че сървърът на калкулатора работи на `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Списък с инструменти** - Показва всички налични операции на калкулатора
3. **Извършване на изчисления**:
   - Събиране: 5 + 3 = 8
   - Изваждане: 10 - 4 = 6
   - Умножение: 6 × 7 = 42
   - Деление: 20 ÷ 4 = 5
   - Степенуване: 2^8 = 256
   - Квадратен корен: √16 = 4
   - Абсолютна стойност: |-5.5| = 5.5
   - Помощ: Показва наличните операции

## Очакван резултат

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Забележка**: Възможно е да видите предупреждения от Maven за останали нишки в края - това е нормално при реактивни приложения и не означава грешка.

## Разбиране на кода

### 1. Настройка на транспорта
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Това създава SSE (Server-Sent Events) транспорт, който се свързва със сървъра на калкулатора.

### 2. Създаване на клиента
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Създава синхронен MCP клиент и инициализира връзката.

### 3. Извикване на инструменти
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Извиква инструмента "add" с параметри a=5.0 и b=3.0.

## Отстраняване на проблеми

### Сървърът не работи
Ако получите грешки при свързване, уверете се, че сървърът на калкулатора от Глава 01 работи:
```
Error: Connection refused
```
**Решение**: Стартирайте първо сървъра на калкулатора.

### Портът вече е зает
Ако порт 8080 е зает:
```
Error: Address already in use
```
**Решение**: Затворете други приложения, които използват порт 8080, или променете порта на сървъра.

### Грешки при компилация
Ако срещнете грешки при компилиране:
```cmd
.\mvnw clean install -DskipTests
```

## Научете повече

- [Spring AI MCP документация](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Спецификация на Model Context Protocol](https://modelcontextprotocol.io/)
- [Spring WebFlux документация](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за никакви недоразумения или неправилни тълкувания, произтичащи от използването на този превод.