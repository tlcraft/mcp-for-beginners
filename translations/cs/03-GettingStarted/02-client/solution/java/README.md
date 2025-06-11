<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:15:55+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "cs"
}
-->
# MCP Java Client - Calculator Demo

Этот проект демонстрирует, как создать Java-клиент, который подключается и взаимодействует с MCP (Model Context Protocol) сервером. В этом примере мы подключимся к калькуляторному серверу из Главы 01 и выполним различные математические операции.

## Требования

Перед запуском этого клиента необходимо:

1. **Запустить калькуляторный сервер** из Главы 01:
   - Перейдите в каталог калькуляторного сервера: `03-GettingStarted/01-first-server/solution/java/`
   - Соберите и запустите калькуляторный сервер:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Сервер должен работать по адресу `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` — это Java-приложение, которое демонстрирует, как:
- Подключаться к MCP серверу с использованием транспорта Server-Sent Events (SSE)
- Получать список доступных инструментов с сервера
- Вызывать различные функции калькулятора удалённо
- Обрабатывать ответы и отображать результаты

## Как это работает

Клиент использует фреймворк Spring AI MCP для:

1. **Установки соединения**: создаёт WebFlux SSE клиентский транспорт для подключения к калькуляторному серверу
2. **Инициализации клиента**: настраивает MCP клиент и устанавливает соединение
3. **Обнаружения инструментов**: выводит список всех доступных операций калькулятора
4. **Выполнения операций**: вызывает различные математические функции с примерными данными
5. **Отображения результатов**: показывает результаты каждого вычисления

## Структура проекта

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

## Основные зависимости

Проект использует следующие ключевые зависимости:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Эта зависимость предоставляет:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` — SSE транспорт для веб-коммуникации
- Схемы протокола MCP и типы запросов/ответов

## Сборка проекта

Соберите проект с помощью Maven wrapper:

```cmd
.\mvnw clean install
```

## Запуск клиента

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Примечание**: Убедитесь, что калькуляторный сервер запущен по адресу `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Список инструментов** — показывает все доступные операции калькулятора
3. **Выполнение вычислений**:
   - Сложение: 5 + 3 = 8
   - Вычитание: 10 - 4 = 6
   - Умножение: 6 × 7 = 42
   - Деление: 20 ÷ 4 = 5
   - Возведение в степень: 2^8 = 256
   - Квадратный корень: √16 = 4
   - Абсолютное значение: |-5.5| = 5.5
   - Помощь: показывает доступные операции

## Ожидаемый вывод

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

**Примечание**: В конце могут появляться предупреждения Maven о фоновых потоках — это нормально для реактивных приложений и не является ошибкой.

## Пояснение к коду

### 1. Настройка транспорта
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Создаёт SSE (Server-Sent Events) транспорт, который подключается к калькуляторному серверу.

### 2. Создание клиента
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Создаёт синхронный MCP клиент и инициализирует соединение.

### 3. Вызов инструментов
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Вызов инструмента "add" с параметрами a=5.0 и b=3.0.

## Устранение неполадок

### Сервер не запущен
Если возникают ошибки подключения, убедитесь, что калькуляторный сервер из Главы 01 запущен:
```
Error: Connection refused
```
**Решение**: сначала запустите калькуляторный сервер.

### Порт уже занят
Если порт 8080 занят:
```
Error: Address already in use
```
**Решение**: остановите другие приложения, использующие порт 8080, или измените порт сервера.

### Ошибки сборки
Если возникают ошибки сборки:
```cmd
.\mvnw clean install -DskipTests
```

## Дополнительная информация

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.