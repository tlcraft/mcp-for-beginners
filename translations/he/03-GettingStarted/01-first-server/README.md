<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fa635ae747c9b4d5c2f61c6c46cb695f",
  "translation_date": "2025-07-17T18:57:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "he"
}
-->
# התחלה עם MCP

ברוכים הבאים לצעדים הראשונים שלכם עם Model Context Protocol (MCP)! בין אם אתם חדשים ב-MCP או רוצים להעמיק את ההבנה שלכם, מדריך זה ילווה אתכם בתהליך ההתקנה והפיתוח הבסיסי. תלמדו כיצד MCP מאפשר אינטגרציה חלקה בין מודלים של בינה מלאכותית ליישומים, וכיצד להכין במהירות את הסביבה שלכם לבניית ובדיקת פתרונות מבוססי MCP.

> TLDR; אם אתם מפתחים אפליקציות AI, אתם יודעים שניתן להוסיף כלים ומשאבים נוספים ל-LLM (מודל שפה גדול), כדי להעשיר את הידע שלו. עם זאת, אם אתם ממקמים את הכלים והמשאבים האלה בשרת, היכולות של האפליקציה והשרת זמינות לכל לקוח, עם או בלי LLM.

## סקירה כללית

השיעור הזה מספק הנחיות מעשיות להקמת סביבות MCP ולבניית האפליקציות הראשונות שלכם ב-MCP. תלמדו כיצד להגדיר את הכלים והמסגרות הנדרשות, לבנות שרתי MCP בסיסיים, ליצור אפליקציות מארחות ולבדוק את היישומים שלכם.

Model Context Protocol (MCP) הוא פרוטוקול פתוח שמאחד את האופן שבו אפליקציות מספקות הקשר ל-LLM. אפשר לחשוב על MCP כמו על חיבור USB-C לאפליקציות AI – הוא מספק דרך סטנדרטית לחבר מודלים של AI למקורות נתונים וכלים שונים.

## מטרות הלמידה

בסיום השיעור תוכלו:

- להקים סביבות פיתוח ל-MCP ב-C#, Java, Python, TypeScript ו-JavaScript
- לבנות ולפרוס שרתי MCP בסיסיים עם תכונות מותאמות אישית (משאבים, פרומפטים וכלים)
- ליצור אפליקציות מארחות שמתחברות לשרתי MCP
- לבדוק ולפתור תקלות ביישומי MCP

## הקמת סביבת MCP שלכם

לפני שתתחילו לעבוד עם MCP, חשוב להכין את סביבת הפיתוח ולהבין את זרימת העבודה הבסיסית. בסעיף זה נדריך אתכם בשלבי ההתקנה הראשוניים כדי להבטיח התחלה חלקה עם MCP.

### דרישות מוקדמות

לפני שתתחילו בפיתוח MCP, ודאו שיש לכם:

- **סביבת פיתוח**: עבור שפת התכנות שבחרתם (C#, Java, Python, TypeScript או JavaScript)
- **IDE/עורך קוד**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm או כל עורך קוד מודרני אחר
- **מנהל חבילות**: NuGet, Maven/Gradle, pip או npm/yarn
- **מפתחות API**: עבור כל שירותי AI שתכננתם להשתמש בהם באפליקציות המארחות שלכם

## מבנה בסיסי של שרת MCP

שרת MCP בדרך כלל כולל:

- **הגדרות שרת**: הגדרת פורט, אימות והגדרות נוספות
- **משאבים**: נתונים והקשר הזמינים ל-LLM
- **כלים**: פונקציונליות שהמודלים יכולים להפעיל
- **פרומפטים**: תבניות ליצירת או מבנה טקסט

הנה דוגמה פשוטה ב-TypeScript:

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

בקוד שלמעלה:

- מייבאים את המחלקות הנדרשות מ-SDK של MCP ל-TypeScript.
- יוצרים ומגדירים מופע חדש של שרת MCP.
- רושמים כלי מותאם אישית (`calculator`) עם פונקציית טיפול.
- מפעילים את השרת להאזנה לבקשות MCP נכנסות.

## בדיקה ופתרון תקלות

לפני שתתחילו לבדוק את שרת ה-MCP שלכם, חשוב להבין את הכלים הזמינים ואת שיטות העבודה המומלצות לפתרון תקלות. בדיקה יעילה מבטיחה שהשרת מתנהג כמצופה ועוזרת לזהות ולפתור בעיות במהירות. הסעיף הבא מפרט גישות מומלצות לאימות יישום MCP שלכם.

MCP מספק כלים שיעזרו לכם לבדוק ולפתור תקלות בשרתים שלכם:

- **כלי Inspector**, ממשק גרפי שמאפשר להתחבר לשרת ולבדוק את הכלים, הפרומפטים והמשאבים.
- **curl**, ניתן גם להתחבר לשרת באמצעות כלי שורת פקודה כמו curl או לקוחות אחרים שיכולים ליצור ולהריץ פקודות HTTP.

### שימוש ב-MCP Inspector

[!NOTE]  
[MCP Inspector](https://github.com/modelcontextprotocol/inspector) הוא כלי בדיקה ויזואלי שעוזר לכם:

1. **לגלות יכולות שרת**: לזהות אוטומטית משאבים, כלים ופרומפטים זמינים  
2. **לבחון הפעלת כלים**: לנסות פרמטרים שונים ולראות תגובות בזמן אמת  
3. **לצפות במטא-נתוני השרת**: לבדוק מידע על השרת, סכימות והגדרות

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

כאשר תריצו את הפקודות שלמעלה, MCP Inspector יפתח ממשק ווב מקומי בדפדפן שלכם. תוכלו לראות לוח בקרה המציג את שרתי MCP הרשומים שלכם, הכלים, המשאבים והפרומפטים הזמינים. הממשק מאפשר לכם לבדוק אינטראקטיבית הפעלת כלים, לבדוק מטא-נתונים של השרת ולראות תגובות בזמן אמת, מה שמקל על אימות ופתרון תקלות ביישומי MCP שלכם.

הנה צילום מסך של איך זה יכול להיראות:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.he.png)

## בעיות נפוצות בהגדרה ופתרונות

| בעיה | פתרון אפשרי |
|-------|-------------------|
| חיבור נדחה | בדקו אם השרת פועל והפורט נכון |
| שגיאות בהפעלת כלים | בדקו את אימות הפרמטרים וטיפול בשגיאות |
| כשל באימות | ודאו שמפתחות ה-API והרשאות תקינים |
| שגיאות באימות סכימה | ודאו שהפרמטרים תואמים לסכימה המוגדרת |
| השרת לא מתחיל | בדקו קונפליקטים בפורט או תלות חסרה |
| שגיאות CORS | הגדירו כותרות CORS מתאימות לבקשות חוצות מקור |
| בעיות אימות | בדקו את תוקף הטוקן והרשאות |

## פיתוח מקומי

לצורך פיתוח ובדיקה מקומית, ניתן להריץ שרתי MCP ישירות על המחשב שלכם:

1. **הפעלת תהליך השרת**: הריצו את אפליקציית שרת ה-MCP שלכם  
2. **הגדרת רשת**: ודאו שהשרת נגיש בפורט הצפוי  
3. **חיבור לקוחות**: השתמשו בכתובות חיבור מקומיות כמו `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## בניית שרת MCP ראשון שלכם

כבר סקרנו [מושגים בסיסיים](/01-CoreConcepts/README.md) בשיעור קודם, ועכשיו הגיע הזמן ליישם את הידע.

### מה שרת יכול לעשות

לפני שנתחיל לכתוב קוד, נזכיר מה שרת יכול לעשות:

שרת MCP יכול למשל:

- לגשת לקבצים ומסדי נתונים מקומיים  
- להתחבר ל-APIs מרוחקים  
- לבצע חישובים  
- להשתלב עם כלים ושירותים אחרים  
- לספק ממשק משתמש לאינטראקציה

מעולה, עכשיו כשאנחנו יודעים מה אפשר לעשות, בואו נתחיל לקודד.

## תרגיל: יצירת שרת

כדי ליצור שרת, יש לבצע את השלבים הבאים:

- התקנת MCP SDK.  
- יצירת פרויקט והגדרת מבנה הפרויקט.  
- כתיבת קוד השרת.  
- בדיקת השרת.

### -1- התקנת ה-SDK

זה משתנה מעט בהתאם לסביבת הריצה שבחרתם, אז בחרו אחת מהאפשרויות הבאות:

> [!NOTE]  
> בפייתון, ניצור קודם את מבנה הפרויקט ואז נתקין את התלויות.

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

ל-Java, צרו פרויקט Spring Boot:

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

חלצו את קובץ ה-zip:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

הוסיפו את ההגדרה המלאה הבאה לקובץ *pom.xml* שלכם:

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

### -2- יצירת פרויקט

כעת כשיש לכם את ה-SDK מותקן, בואו ניצור פרויקט:

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

### -3- יצירת קבצי פרויקט  
### TypeScript

צרו קובץ *package.json* עם התוכן הבא:

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

צרו קובץ *tsconfig.json* עם התוכן הבא:

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

צרו קובץ *server.py*  
```sh
touch server.py
```

### .NET

התקינו את חבילות NuGet הנדרשות:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

לפרויקטים ב-Java Spring Boot, מבנה הפרויקט נוצר אוטומטית.

### -4- כתיבת קוד השרת

### TypeScript

צרו קובץ *index.ts* והוסיפו את הקוד הבא:

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

כעת יש לכם שרת, אבל הוא לא עושה הרבה, בואו נשפר את זה.

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

ל-Java, צרו את רכיבי השרת המרכזיים. ראשית, ערכו את מחלקת האפליקציה הראשית:

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

צרו את שירות המחשבון *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**רכיבים אופציונליים לשירות מוכן לייצור:**

צרו קונפיגורציית הפעלה *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

צרו בקר בריאות *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

צרו מטפל בשגיאות *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

צרו באנר מותאם אישית *src/main/resources/banner.txt*:

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

### -5- הוספת כלי ומשאב

הוסיפו כלי ומשאב על ידי הוספת הקוד הבא:

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

הכלי שלכם מקבל פרמטרים `a` ו-`b` ומריץ פונקציה שמחזירה תגובה בצורה:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

המשאב שלכם נגיש דרך המחרוזת "greeting", מקבל פרמטר `name` ומחזיר תגובה דומה לכלי:

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

בקוד שלמעלה הגדרנו:

- כלי בשם `add` שמקבל פרמטרים `a` ו-`p`, שניהם מספרים שלמים.  
- משאב בשם `greeting` שמקבל פרמטר `name`.

### .NET

הוסיפו זאת לקובץ Program.cs שלכם:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

הכלים כבר נוצרו בשלב הקודם.

### -6- קוד סופי

נוסיף את הקוד האחרון הדרוש כדי שהשרת יוכל להתחיל לפעול:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

הנה הקוד המלא:

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

צרו קובץ Program.cs עם התוכן הבא:

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

מחלקת האפליקציה הראשית המלאה שלכם צריכה להיראות כך:

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

### -7- בדיקת השרת

הפעילו את השרת עם הפקודה הבאה:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> כדי להשתמש ב-MCP Inspector, השתמשו ב-`mcp dev server.py` שמפעיל אוטומטית את ה-Inspector ומספק את טוקן הסשן הנדרש. אם משתמשים ב-`mcp run server.py`, תצטרכו להפעיל את ה-Inspector ידנית ולהגדיר את החיבור.

### .NET

ודאו שאתם בתיקיית הפרויקט שלכם:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- הפעלה באמצעות ה-Inspector

ה-Inspector הוא כלי מצוין שיכול להפעיל את השרת שלכם ומאפשר לכם לתקשר איתו כדי לבדוק שהוא עובד. בואו נתחיל:

> [!NOTE]  
> ייתכן שהשדה "command" ייראה שונה כי הוא מכיל את הפקודה להרצת שרת עם סביבת הריצה הספציפית שלכם.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

או הוסיפו זאת ל-*package.json* שלכם כך: `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` ואז הריצו `npm run inspect`

Python עוטף כלי Node.js בשם inspector. אפשר לקרוא לכלי הזה כך:

```sh
mcp dev server.py
```

עם זאת, הוא לא מיישם את כל הפונקציות הזמינות בכלי, לכן מומלץ להריץ את כלי ה-Node.js ישירות כך:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```  
אם אתם משתמשים בכלי או IDE שמאפשר להגדיר פקודות וארגומנטים להרצת סקריפטים,  
ודאו שהגדרתם `python` בשדה `Command` ו-`server.py` כ-`Arguments`. זה מבטיח שהסקריפט ירוץ כראוי.

### .NET

ודאו שאתם בתיקיית הפרויקט שלכם:

```sh
cd McpCalculatorServer
npx @modelcontextprotocol/inspector dotnet run
```

### Java

ודאו ששרת המחשבון שלכם פועל  
ואז הריצו את ה-Inspector:

```cmd
npx @modelcontextprotocol/inspector
```

בממשק הווב של ה-Inspector:

1. בחרו ב-"SSE" כסוג התעבורה  
2. הגדירו את ה-URL ל-: `http://localhost:8080/sse`  
3. לחצו על "Connect"

![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.he.png)

**כעת אתם מחוברים לשרת**  
**חלק הבדיקה של שרת ה-Java הושלם**

החלק הבא עוסק באינטראקציה עם השרת.

עליכם לראות את ממשק המשתמש הבא:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

1. התחברו לשרת על ידי לחיצה על כפתור Connect  
   לאחר ההתחברות, תראו את המסך הבא:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.he.png)

1. בחרו ב-"Tools" ואז ב-"listTools", אמור להופיע "Add", בחרו ב-"Add" ומלאו את ערכי הפרמטרים.

   תקבלו את התגובה הבאה, כלומר תוצאה מהפעלת הכלי "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.he.png)

כל הכבוד, הצלחתם ליצור ולהפעיל את השרת הראשון שלכם!

### SDKs רשמיים

MCP מספק SDKs רשמיים למספר שפות:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - מימוש רשמי ב-TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - מימוש רשמי בפייתון
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - המימוש הרשמי של Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - המימוש הרשמי של Rust  

## נקודות מפתח

- הקמת סביבת פיתוח ל-MCP היא פשוטה עם SDKים ייעודיים לשפות  
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות  
- בדיקות וניפוי שגיאות הם חיוניים למימושים אמינים של MCP  

## דוגמאות

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## משימה

צור שרת MCP פשוט עם כלי לבחירתך:

1. מימש את הכלי בשפת התכנות המועדפת עליך (.NET, Java, Python או JavaScript).  
2. הגדר פרמטרי קלט וערכי החזרה.  
3. הרץ את כלי הבדיקה (inspector) כדי לוודא שהשרת פועל כמצופה.  
4. בדוק את המימוש עם קלטים שונים.  

## פתרון

[Solution](./solution/README.md)  

## משאבים נוספים

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## מה הלאה

הבא: [Getting Started with MCP Clients](../02-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.