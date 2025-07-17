<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fa635ae747c9b4d5c2f61c6c46cb695f",
  "translation_date": "2025-07-17T17:31:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ru"
}
-->
# Начало работы с MCP

Добро пожаловать в первые шаги с Model Context Protocol (MCP)! Независимо от того, новичок вы в MCP или хотите углубить свои знания, это руководство проведет вас через основные этапы настройки и разработки. Вы узнаете, как MCP обеспечивает бесшовную интеграцию между AI-моделями и приложениями, а также как быстро подготовить среду для создания и тестирования решений на базе MCP.

> TLDR; Если вы создаёте AI-приложения, вы знаете, что можно добавить инструменты и другие ресурсы к вашей LLM (большой языковой модели), чтобы сделать её более информированной. Однако, если разместить эти инструменты и ресурсы на сервере, возможности приложения и сервера могут использовать любые клиенты с LLM или без неё.

## Обзор

В этом уроке вы получите практические рекомендации по настройке среды MCP и созданию первых MCP-приложений. Вы научитесь устанавливать необходимые инструменты и фреймворки, создавать базовые MCP-серверы, создавать хост-приложения и тестировать свои реализации.

Model Context Protocol (MCP) — это открытый протокол, стандартизирующий способ предоставления контекста LLM приложениями. Представьте MCP как USB-C порт для AI-приложений — он обеспечивает единый способ подключения AI-моделей к различным источникам данных и инструментам.

## Цели обучения

К концу этого урока вы сможете:

- Настроить среды разработки для MCP на C#, Java, Python, TypeScript и JavaScript
- Создавать и развёртывать базовые MCP-серверы с пользовательскими функциями (ресурсы, подсказки и инструменты)
- Создавать хост-приложения, подключающиеся к MCP-серверам
- Тестировать и отлаживать реализации MCP

## Настройка вашей среды MCP

Прежде чем начать работу с MCP, важно подготовить среду разработки и понять базовый рабочий процесс. В этом разделе вы пройдёте через начальные шаги настройки, чтобы обеспечить плавный старт с MCP.

### Требования

Перед тем как приступить к разработке MCP, убедитесь, что у вас есть:

- **Среда разработки**: для выбранного языка (C#, Java, Python, TypeScript или JavaScript)
- **IDE/редактор**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm или любой современный редактор кода
- **Менеджеры пакетов**: NuGet, Maven/Gradle, pip или npm/yarn
- **API-ключи**: для любых AI-сервисов, которые вы планируете использовать в своих хост-приложениях

## Основная структура MCP-сервера

MCP-сервер обычно включает:

- **Конфигурация сервера**: настройка порта, аутентификации и других параметров
- **Ресурсы**: данные и контекст, доступные для LLM
- **Инструменты**: функциональность, которую модели могут вызывать
- **Подсказки**: шаблоны для генерации или структурирования текста

Вот упрощённый пример на TypeScript:

```typescript
import { Server, Tool, Resource } from "@modelcontextprotocol/typescript-server-sdk";

// Create a new MCP server
const server = new Server({
  port: 3000,
  name: "Example MCP Server",
  version: "1.0.0"
});

// Register a tool
server.registerTool({
  name: "calculator",
  description: "Performs basic calculations",
  parameters: {
    expression: {
      type: "string",
      description: "The math expression to evaluate"
    }
  },
  handler: async (params) => {
    const result = eval(params.expression);
    return { result };
  }
});

// Start the server
server.start();
```

В приведённом коде мы:

- Импортируем необходимые классы из MCP TypeScript SDK.
- Создаём и настраиваем новый экземпляр MCP-сервера.
- Регистрируем пользовательский инструмент (`calculator`) с функцией-обработчиком.
- Запускаем сервер для прослушивания входящих MCP-запросов.

## Тестирование и отладка

Перед тем как начать тестировать MCP-сервер, важно понять доступные инструменты и лучшие практики отладки. Эффективное тестирование гарантирует, что сервер работает как задумано, и помогает быстро выявлять и устранять проблемы. В следующем разделе описаны рекомендуемые подходы для проверки вашей реализации MCP.

MCP предоставляет инструменты для тестирования и отладки серверов:

- **Inspector tool** — графический интерфейс, позволяющий подключаться к серверу и тестировать инструменты, подсказки и ресурсы.
- **curl** — вы также можете подключаться к серверу с помощью командной строки, используя curl или другие клиенты, способные создавать и выполнять HTTP-запросы.

### Использование MCP Inspector

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) — визуальный инструмент для тестирования, который помогает:

1. **Обнаруживать возможности сервера**: автоматически определять доступные ресурсы, инструменты и подсказки
2. **Тестировать выполнение инструментов**: пробовать разные параметры и видеть ответы в реальном времени
3. **Просматривать метаданные сервера**: изучать информацию о сервере, схемы и конфигурации

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

При выполнении вышеуказанных команд MCP Inspector запустит локальный веб-интерфейс в вашем браузере. Вы увидите панель управления с зарегистрированными MCP-серверами, их доступными инструментами, ресурсами и подсказками. Интерфейс позволяет интерактивно тестировать выполнение инструментов, просматривать метаданные сервера и видеть ответы в реальном времени, что облегчает проверку и отладку ваших MCP-серверов.

Вот как это может выглядеть:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ru.png)

## Распространённые проблемы при настройке и их решения

| Проблема | Возможное решение |
|----------|-------------------|
| Отказ в подключении | Проверьте, запущен ли сервер и правильный ли порт |
| Ошибки выполнения инструментов | Проверьте валидацию параметров и обработку ошибок |
| Ошибки аутентификации | Проверьте API-ключи и права доступа |
| Ошибки валидации схемы | Убедитесь, что параметры соответствуют определённой схеме |
| Сервер не запускается | Проверьте конфликты портов или отсутствие зависимостей |
| Ошибки CORS | Настройте правильные заголовки CORS для кросс-доменных запросов |
| Проблемы с аутентификацией | Проверьте действительность токена и права доступа |

## Локальная разработка

Для локальной разработки и тестирования вы можете запускать MCP-серверы прямо на своём компьютере:

1. **Запустите процесс сервера**: запустите ваше MCP-серверное приложение
2. **Настройте сеть**: убедитесь, что сервер доступен на ожидаемом порту
3. **Подключите клиентов**: используйте локальные URL, например `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Создание вашего первого MCP-сервера

Мы уже рассмотрели [Основные концепции](/01-CoreConcepts/README.md) в предыдущем уроке, теперь пора применить эти знания на практике.

### Что может делать сервер

Прежде чем писать код, напомним, что может делать сервер:

MCP-сервер может, например:

- Получать доступ к локальным файлам и базам данных
- Подключаться к удалённым API
- Выполнять вычисления
- Интегрироваться с другими инструментами и сервисами
- Предоставлять пользовательский интерфейс для взаимодействия

Отлично, теперь, когда мы знаем возможности, приступим к коду.

## Упражнение: Создание сервера

Чтобы создать сервер, выполните следующие шаги:

- Установите MCP SDK.
- Создайте проект и настройте структуру проекта.
- Напишите код сервера.
- Протестируйте сервер.

### -1- Установка SDK

Это немного отличается в зависимости от выбранной среды выполнения, поэтому выберите одну из следующих:

> [!NOTE]
> Для Python сначала создадим структуру проекта, а затем установим зависимости.

### TypeScript

```sh
npm install @modelcontextprotocol/sdk zod
npm install -D @types/node typescript
```

### Python

```sh
# Create project dir
mkdir calculator-server
cd calculator-server
# Open the folder in Visual Studio Code - Skip this if you are using a different IDE
code .
```

### .NET

```sh
dotnet new console -n McpCalculatorServer
cd McpCalculatorServer
```

### Java

Для Java создайте проект Spring Boot:

```bash
curl https://start.spring.io/starter.zip \
  -d dependencies=web \
  -d javaVersion=21 \
  -d type=maven-project \
  -d groupId=com.example \
  -d artifactId=calculator-server \
  -d name=McpServer \
  -d packageName=com.microsoft.mcp.sample.server \
  -o calculator-server.zip
```

Распакуйте zip-файл:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

Добавьте следующую полную конфигурацию в файл *pom.xml*:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project xmlns="http://maven.apache.org/POM/4.0.0"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xsi:schemaLocation="http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd">
    <modelVersion>4.0.0</modelVersion>
    
    <!-- Spring Boot parent for dependency management -->
    <parent>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-parent</artifactId>
        <version>3.5.0</version>
        <relativePath />
    </parent>

    <!-- Project coordinates -->
    <groupId>com.example</groupId>
    <artifactId>calculator-server</artifactId>
    <version>0.0.1-SNAPSHOT</version>
    <name>Calculator Server</name>
    <description>Basic calculator MCP service for beginners</description>

    <!-- Properties -->
    <properties>
        <java.version>21</java.version>
        <maven.compiler.source>21</maven.compiler.source>
        <maven.compiler.target>21</maven.compiler.target>
    </properties>

    <!-- Spring AI BOM for version management -->
    <dependencyManagement>
        <dependencies>
            <dependency>
                <groupId>org.springframework.ai</groupId>
                <artifactId>spring-ai-bom</artifactId>
                <version>1.0.0-SNAPSHOT</version>
                <type>pom</type>
                <scope>import</scope>
            </dependency>
        </dependencies>
    </dependencyManagement>

    <!-- Dependencies -->
    <dependencies>
        <dependency>
            <groupId>org.springframework.ai</groupId>
            <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
        </dependency>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-actuator</artifactId>
        </dependency>
        <dependency>
         <groupId>org.springframework.boot</groupId>
         <artifactId>spring-boot-starter-test</artifactId>
         <scope>test</scope>
      </dependency>
    </dependencies>

    <!-- Build configuration -->
    <build>
        <plugins>
            <plugin>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-maven-plugin</artifactId>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <configuration>
                    <release>21</release>
                </configuration>
            </plugin>
        </plugins>
    </build>

    <!-- Repositories for Spring AI snapshots -->
    <repositories>
        <repository>
            <id>spring-milestones</id>
            <name>Spring Milestones</name>
            <url>https://repo.spring.io/milestone</url>
            <snapshots>
                <enabled>false</enabled>
            </snapshots>
        </repository>
        <repository>
            <id>spring-snapshots</id>
            <name>Spring Snapshots</name>
            <url>https://repo.spring.io/snapshot</url>
            <releases>
                <enabled>false</enabled>
            </releases>
        </repository>
    </repositories>
</project>
```

### -2- Создание проекта

Теперь, когда SDK установлен, создадим проект:

### TypeScript

```sh
mkdir src
npm install -y
```

### Python

```sh
# Create a virtual env and install dependencies
python -m venv venv
venv\Scripts\activate
pip install "mcp[cli]"
```

### Java

```bash
cd calculator-server
./mvnw clean install -DskipTests
```

### -3- Создание файлов проекта

### TypeScript

Создайте *package.json* со следующим содержимым:

```json
{
   "type": "module",
   "bin": {
     "weather": "./build/index.js"
   },
   "scripts": {
     "build": "tsc && node build/index.js"
   },
   "files": [
     "build"
   ]
}
```

Создайте *tsconfig.json* со следующим содержимым:

```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "Node16",
    "moduleResolution": "Node16",
    "outDir": "./build",
    "rootDir": "./src",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true,
    "forceConsistentCasingInFileNames": true
  },
  "include": ["src/**/*"],
  "exclude": ["node_modules"]
}
```

### Python

Создайте файл *server.py*

```sh
touch server.py
```

### .NET

Установите необходимые пакеты NuGet:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Для проектов Java Spring Boot структура создаётся автоматически.

### -4- Создание кода сервера

### TypeScript

Создайте файл *index.ts* и добавьте следующий код:

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
 
// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});
```

Теперь у вас есть сервер, но он пока мало что делает, исправим это.

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")
```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

// add features
```

### Java

Для Java создайте основные компоненты сервера. Сначала измените главный класс приложения:

*src/main/java/com/microsoft/mcp/sample/server/McpServerApplication.java*:

```java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

Создайте сервис калькулятора *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

```java
package com.microsoft.mcp.sample.server.service;

import org.springframework.ai.tool.annotation.Tool;
import org.springframework.stereotype.Service;

/**
 * Service for basic calculator operations.
 * This service provides simple calculator functionality through MCP.
 */
@Service
public class CalculatorService {

    /**
     * Add two numbers
     * @param a The first number
     * @param b The second number
     * @return The sum of the two numbers
     */
    @Tool(description = "Add two numbers together")
    public String add(double a, double b) {
        double result = a + b;
        return formatResult(a, "+", b, result);
    }

    /**
     * Subtract one number from another
     * @param a The number to subtract from
     * @param b The number to subtract
     * @return The result of the subtraction
     */
    @Tool(description = "Subtract the second number from the first number")
    public String subtract(double a, double b) {
        double result = a - b;
        return formatResult(a, "-", b, result);
    }

    /**
     * Multiply two numbers
     * @param a The first number
     * @param b The second number
     * @return The product of the two numbers
     */
    @Tool(description = "Multiply two numbers together")
    public String multiply(double a, double b) {
        double result = a * b;
        return formatResult(a, "*", b, result);
    }

    /**
     * Divide one number by another
     * @param a The numerator
     * @param b The denominator
     * @return The result of the division
     */
    @Tool(description = "Divide the first number by the second number")
    public String divide(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a / b;
        return formatResult(a, "/", b, result);
    }

    /**
     * Calculate the power of a number
     * @param base The base number
     * @param exponent The exponent
     * @return The result of raising the base to the exponent
     */
    @Tool(description = "Calculate the power of a number (base raised to an exponent)")
    public String power(double base, double exponent) {
        double result = Math.pow(base, exponent);
        return formatResult(base, "^", exponent, result);
    }

    /**
     * Calculate the square root of a number
     * @param number The number to find the square root of
     * @return The square root of the number
     */
    @Tool(description = "Calculate the square root of a number")
    public String squareRoot(double number) {
        if (number < 0) {
            return "Error: Cannot calculate square root of a negative number";
        }
        double result = Math.sqrt(number);
        return String.format("√%.2f = %.2f", number, result);
    }

    /**
     * Calculate the modulus (remainder) of division
     * @param a The dividend
     * @param b The divisor
     * @return The remainder of the division
     */
    @Tool(description = "Calculate the remainder when one number is divided by another")
    public String modulus(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a % b;
        return formatResult(a, "%", b, result);
    }

    /**
     * Calculate the absolute value of a number
     * @param number The number to find the absolute value of
     * @return The absolute value of the number
     */
    @Tool(description = "Calculate the absolute value of a number")
    public String absolute(double number) {
        double result = Math.abs(number);
        return String.format("|%.2f| = %.2f", number, result);
    }

    /**
     * Get help about available calculator operations
     * @return Information about available operations
     */
    @Tool(description = "Get help about available calculator operations")
    public String help() {
        return "Basic Calculator MCP Service\n\n" +
               "Available operations:\n" +
               "1. add(a, b) - Adds two numbers\n" +
               "2. subtract(a, b) - Subtracts the second number from the first\n" +
               "3. multiply(a, b) - Multiplies two numbers\n" +
               "4. divide(a, b) - Divides the first number by the second\n" +
               "5. power(base, exponent) - Raises a number to a power\n" +
               "6. squareRoot(number) - Calculates the square root\n" + 
               "7. modulus(a, b) - Calculates the remainder of division\n" +
               "8. absolute(number) - Calculates the absolute value\n\n" +
               "Example usage: add(5, 3) will return 5 + 3 = 8";
    }

    /**
     * Format the result of a calculation
     */
    private String formatResult(double a, String operator, double b, double result) {
        return String.format("%.2f %s %.2f = %.2f", a, operator, b, result);
    }
}
```

**Опциональные компоненты для готового к продакшену сервиса:**

Создайте конфигурацию запуска *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

```java
package com.microsoft.mcp.sample.server.config;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class StartupConfig {
    
    @Bean
    public CommandLineRunner startupInfo() {
        return args -> {
            System.out.println("\n" + "=".repeat(60));
            System.out.println("Calculator MCP Server is starting...");
            System.out.println("SSE endpoint: http://localhost:8080/sse");
            System.out.println("Health check: http://localhost:8080/actuator/health");
            System.out.println("=".repeat(60) + "\n");
        };
    }
}
```

Создайте контроллер состояния *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

```java
package com.microsoft.mcp.sample.server.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

@RestController
public class HealthController {
    
    @GetMapping("/health")
    public ResponseEntity<Map<String, Object>> healthCheck() {
        Map<String, Object> response = new HashMap<>();
        response.put("status", "UP");
        response.put("timestamp", LocalDateTime.now().toString());
        response.put("service", "Calculator MCP Server");
        return ResponseEntity.ok(response);
    }
}
```

Создайте обработчик исключений *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

```java
package com.microsoft.mcp.sample.server.exception;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

@RestControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(IllegalArgumentException.class)
    public ResponseEntity<ErrorResponse> handleIllegalArgumentException(IllegalArgumentException ex) {
        ErrorResponse error = new ErrorResponse(
            "Invalid_Input", 
            "Invalid input parameter: " + ex.getMessage());
        return new ResponseEntity<>(error, HttpStatus.BAD_REQUEST);
    }

    public static class ErrorResponse {
        private String code;
        private String message;

        public ErrorResponse(String code, String message) {
            this.code = code;
            this.message = message;
        }

        // Getters
        public String getCode() { return code; }
        public String getMessage() { return message; }
    }
}
```

Создайте кастомный баннер *src/main/resources/banner.txt*:

```text
_____      _            _       _             
 / ____|    | |          | |     | |            
| |     __ _| | ___ _   _| | __ _| |_ ___  _ __ 
| |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
| |___| (_| | | (__| |_| | | (_| | || (_) | |   
 \_____\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                                
Calculator MCP Server v1.0
Spring Boot MCP Application
```

</details>

### -5- Добавление инструмента и ресурса

Добавьте инструмент и ресурс, добавив следующий код:

### TypeScript

```typescript
  server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);
```

Ваш инструмент принимает параметры `a` и `b` и выполняет функцию, которая возвращает ответ в формате:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

Ваш ресурс доступен по строке "greeting", принимает параметр `name` и возвращает ответ, похожий на инструмент:

```typescript
{
  uri: "<href>",
  text: "a text"
}
```

### Python

```python
# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"
```

В приведённом коде мы:

- Определили инструмент `add`, который принимает параметры `a` и `p`, оба целые числа.
- Создали ресурс `greeting`, который принимает параметр `name`.

### .NET

Добавьте это в файл Program.cs:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Инструменты уже были созданы на предыдущем шаге.

### -6- Финальный код

Добавим последний необходимый код, чтобы сервер мог запуститься:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

Вот полный код:

```typescript
// index.ts
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

# Main execution block - this is required to run the server
if __name__ == "__main__":
    mcp.run()
```

### .NET

Создайте файл Program.cs со следующим содержимым:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Ваш полный главный класс приложения должен выглядеть так:

```java
// McpServerApplication.java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

### -7- Тестирование сервера

Запустите сервер следующей командой:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> Для использования MCP Inspector запустите `mcp dev server.py`, который автоматически запускает Inspector и предоставляет необходимый токен сессии прокси. Если использовать `mcp run server.py`, Inspector нужно запускать вручную и настраивать подключение.

### .NET

Убедитесь, что вы находитесь в каталоге проекта:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- Запуск с помощью Inspector

Inspector — отличный инструмент, который может запустить ваш сервер и позволит взаимодействовать с ним для тестирования. Запустим его:

> [!NOTE]
> В поле "command" команда может выглядеть иначе, так как содержит команду запуска сервера для вашей конкретной среды выполнения.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

Или добавьте в *package.json* скрипт `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` и затем выполните `npm run inspect`

Python использует обёртку над Node.js-инструментом inspector. Можно вызвать этот инструмент так:

```sh
mcp dev server.py
```

Однако он не реализует все методы инструмента, поэтому рекомендуется запускать Node.js-инструмент напрямую, как показано ниже:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```

Если вы используете инструмент или IDE, позволяющие настраивать команды и аргументы для запуска скриптов, убедитесь, что в поле `Command` указан `python`, а в `Arguments` — `server.py`. Это обеспечит корректный запуск скрипта.

### .NET

Убедитесь, что вы находитесь в каталоге проекта:

```sh
cd McpCalculatorServer
npx @modelcontextprotocol/inspector dotnet run
```

### Java

Убедитесь, что сервер калькулятора запущен. Затем запустите Inspector:

```cmd
npx @modelcontextprotocol/inspector
```

В веб-интерфейсе Inspector:

1. Выберите "SSE" в качестве типа транспорта
2. Установите URL: `http://localhost:8080/sse`
3. Нажмите "Connect"

![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.ru.png)

**Вы подключены к серверу**  
**Раздел тестирования Java-сервера завершён**

Следующий раздел посвящён взаимодействию с сервером.

Вы должны увидеть следующий интерфейс:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ru.png)

1. Подключитесь к серверу, нажав кнопку Connect  
   После подключения вы увидите следующее:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ru.png)

2. Выберите "Tools" и "listTools", вы увидите "Add", выберите "Add" и заполните параметры.

   Вы увидите следующий ответ — результат работы инструмента "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ru.png)

Поздравляем, вы успешно создали и запустили свой первый сервер!

### Официальные SDK

MCP предоставляет официальные SDK для нескольких языков:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) — поддерживается в сотрудничестве с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) — поддерживается в сотрудничестве с Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) — официальная реализация на TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) — официальная реализация на Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Официальная реализация на Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Поддерживается в сотрудничестве с Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Официальная реализация на Rust  

## Основные выводы

- Настройка среды разработки MCP проста благодаря SDK для конкретных языков  
- Создание MCP серверов включает разработку и регистрацию инструментов с чёткими схемами  
- Тестирование и отладка необходимы для надёжной реализации MCP  

## Примеры

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Задание

Создайте простой MCP сервер с инструментом на ваш выбор:

1. Реализуйте инструмент на предпочитаемом языке (.NET, Java, Python или JavaScript).  
2. Определите входные параметры и возвращаемые значения.  
3. Запустите инспектор, чтобы убедиться, что сервер работает корректно.  
4. Проверьте реализацию с разными входными данными.  

## Решение

[Решение](./solution/README.md)  

## Дополнительные ресурсы

- [Создание агентов с использованием Model Context Protocol на Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Удалённый MCP с Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Что дальше

Далее: [Начало работы с MCP клиентами](../02-client/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному человеческому переводу. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.