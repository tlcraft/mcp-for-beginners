<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd0fdbbbebbef2b6b179ceba21d82ed2",
  "translation_date": "2025-07-17T07:42:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "vi"
}
-->
# Bắt đầu với MCP

Chào mừng bạn đến với những bước đầu tiên cùng Model Context Protocol (MCP)! Dù bạn mới làm quen với MCP hay muốn nâng cao hiểu biết, hướng dẫn này sẽ giúp bạn thiết lập và phát triển cơ bản. Bạn sẽ khám phá cách MCP giúp tích hợp liền mạch giữa các mô hình AI và ứng dụng, đồng thời học cách nhanh chóng chuẩn bị môi trường để xây dựng và thử nghiệm các giải pháp dựa trên MCP.

> TLDR; Nếu bạn phát triển ứng dụng AI, bạn biết rằng có thể thêm công cụ và tài nguyên vào LLM (mô hình ngôn ngữ lớn) để làm cho LLM hiểu biết hơn. Tuy nhiên, nếu bạn đặt các công cụ và tài nguyên đó trên một máy chủ, khả năng của ứng dụng và máy chủ có thể được sử dụng bởi bất kỳ khách hàng nào có hoặc không có LLM.

## Tổng quan

Bài học này cung cấp hướng dẫn thực tiễn về cách thiết lập môi trường MCP và xây dựng ứng dụng MCP đầu tiên của bạn. Bạn sẽ học cách cài đặt các công cụ và framework cần thiết, xây dựng các máy chủ MCP cơ bản, tạo ứng dụng host và kiểm thử các triển khai của mình.

Model Context Protocol (MCP) là một giao thức mở chuẩn hóa cách các ứng dụng cung cấp ngữ cảnh cho LLM. Hãy tưởng tượng MCP như một cổng USB-C dành cho ứng dụng AI - nó cung cấp cách kết nối chuẩn hóa giữa các mô hình AI với các nguồn dữ liệu và công cụ khác nhau.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Thiết lập môi trường phát triển MCP với C#, Java, Python, TypeScript và JavaScript
- Xây dựng và triển khai các máy chủ MCP cơ bản với các tính năng tùy chỉnh (tài nguyên, prompt, công cụ)
- Tạo ứng dụng host kết nối với máy chủ MCP
- Kiểm thử và gỡ lỗi các triển khai MCP

## Thiết lập môi trường MCP của bạn

Trước khi bắt đầu làm việc với MCP, bạn cần chuẩn bị môi trường phát triển và hiểu quy trình làm việc cơ bản. Phần này sẽ hướng dẫn bạn các bước thiết lập ban đầu để khởi đầu thuận lợi với MCP.

### Yêu cầu trước

Trước khi bắt đầu phát triển MCP, hãy đảm bảo bạn có:

- **Môi trường phát triển**: Cho ngôn ngữ bạn chọn (C#, Java, Python, TypeScript hoặc JavaScript)
- **IDE/Trình soạn thảo**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm hoặc bất kỳ trình soạn thảo mã hiện đại nào
- **Trình quản lý gói**: NuGet, Maven/Gradle, pip hoặc npm/yarn
- **API Keys**: Cho bất kỳ dịch vụ AI nào bạn dự định sử dụng trong ứng dụng host

## Cấu trúc máy chủ MCP cơ bản

Một máy chủ MCP thường bao gồm:

- **Cấu hình máy chủ**: Thiết lập cổng, xác thực và các cài đặt khác
- **Tài nguyên**: Dữ liệu và ngữ cảnh được cung cấp cho LLM
- **Công cụ**: Các chức năng mà mô hình có thể gọi
- **Prompt**: Mẫu để tạo hoặc cấu trúc văn bản

Dưới đây là ví dụ đơn giản bằng TypeScript:

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

Trong đoạn mã trên, chúng ta đã:

- Nhập các lớp cần thiết từ MCP TypeScript SDK.
- Tạo và cấu hình một phiên bản máy chủ MCP mới.
- Đăng ký một công cụ tùy chỉnh (`calculator`) với hàm xử lý.
- Khởi động máy chủ để lắng nghe các yêu cầu MCP đến.

## Kiểm thử và gỡ lỗi

Trước khi bắt đầu kiểm thử máy chủ MCP, bạn cần hiểu các công cụ có sẵn và các phương pháp gỡ lỗi tốt nhất. Kiểm thử hiệu quả giúp máy chủ hoạt động đúng như mong đợi và giúp bạn nhanh chóng phát hiện, khắc phục sự cố. Phần dưới đây trình bày các cách tiếp cận được khuyến nghị để xác thực triển khai MCP của bạn.

MCP cung cấp các công cụ hỗ trợ kiểm thử và gỡ lỗi máy chủ:

- **Công cụ Inspector**, giao diện đồ họa cho phép bạn kết nối với máy chủ và kiểm thử các công cụ, prompt và tài nguyên.
- **curl**, bạn cũng có thể kết nối với máy chủ bằng công cụ dòng lệnh như curl hoặc các client khác có thể tạo và chạy các lệnh HTTP.

### Sử dụng MCP Inspector

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) là công cụ kiểm thử trực quan giúp bạn:

1. **Khám phá khả năng máy chủ**: Tự động phát hiện các tài nguyên, công cụ và prompt có sẵn
2. **Kiểm thử thực thi công cụ**: Thử các tham số khác nhau và xem phản hồi theo thời gian thực
3. **Xem metadata máy chủ**: Kiểm tra thông tin máy chủ, schema và cấu hình

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

Khi bạn chạy các lệnh trên, MCP Inspector sẽ khởi chạy giao diện web cục bộ trên trình duyệt. Bạn sẽ thấy bảng điều khiển hiển thị các máy chủ MCP đã đăng ký, các công cụ, tài nguyên và prompt có sẵn. Giao diện cho phép bạn tương tác kiểm thử thực thi công cụ, xem metadata máy chủ và phản hồi theo thời gian thực, giúp việc xác thực và gỡ lỗi các triển khai MCP dễ dàng hơn.

Dưới đây là ảnh chụp màn hình minh họa:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.vi.png)

## Các vấn đề thường gặp khi thiết lập và cách khắc phục

| Vấn đề | Giải pháp khả thi |
|--------|-------------------|
| Kết nối bị từ chối | Kiểm tra xem máy chủ có đang chạy và cổng có đúng không |
| Lỗi khi thực thi công cụ | Kiểm tra xác thực tham số và xử lý lỗi |
| Lỗi xác thực | Xác minh API key và quyền truy cập |
| Lỗi xác thực schema | Đảm bảo tham số phù hợp với schema đã định nghĩa |
| Máy chủ không khởi động | Kiểm tra xung đột cổng hoặc thiếu phụ thuộc |
| Lỗi CORS | Cấu hình header CORS phù hợp cho yêu cầu cross-origin |
| Vấn đề xác thực | Kiểm tra tính hợp lệ của token và quyền truy cập |

## Phát triển cục bộ

Để phát triển và kiểm thử cục bộ, bạn có thể chạy máy chủ MCP trực tiếp trên máy của mình:

1. **Khởi động tiến trình máy chủ**: Chạy ứng dụng máy chủ MCP của bạn
2. **Cấu hình mạng**: Đảm bảo máy chủ có thể truy cập qua cổng mong muốn
3. **Kết nối client**: Sử dụng URL kết nối cục bộ như `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Xây dựng máy chủ MCP đầu tiên của bạn

Chúng ta đã tìm hiểu [Các khái niệm cốt lõi](/01-CoreConcepts/README.md) trong bài học trước, giờ là lúc áp dụng kiến thức đó.

### Máy chủ có thể làm gì

Trước khi bắt đầu viết mã, hãy nhắc lại máy chủ có thể làm gì:

Một máy chủ MCP có thể ví dụ:

- Truy cập file và cơ sở dữ liệu cục bộ
- Kết nối với API từ xa
- Thực hiện các phép tính
- Tích hợp với các công cụ và dịch vụ khác
- Cung cấp giao diện người dùng để tương tác

Tuyệt vời, giờ chúng ta đã biết máy chủ có thể làm gì, hãy bắt đầu viết mã.

## Bài tập: Tạo máy chủ

Để tạo máy chủ, bạn cần thực hiện các bước sau:

- Cài đặt MCP SDK.
- Tạo dự án và thiết lập cấu trúc dự án.
- Viết mã máy chủ.
- Kiểm thử máy chủ.

### -1- Cài đặt SDK

Điều này sẽ khác nhau tùy theo runtime bạn chọn, hãy chọn một trong các runtime dưới đây:

> [!NOTE]
> Với Python, chúng ta sẽ tạo cấu trúc dự án trước rồi mới cài đặt các phụ thuộc.

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

Với Java, tạo một dự án Spring Boot:

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

Giải nén file zip:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

Thêm cấu hình đầy đủ sau vào file *pom.xml* của bạn:

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

### TypeScript

Tạo file *package.json* với nội dung sau:

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

Tạo file *tsconfig.json* với nội dung sau:

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

Tạo file *server.py*

```sh
touch server.py
```

### .NET

Cài đặt các gói NuGet cần thiết:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Với dự án Java Spring Boot, cấu trúc dự án được tạo tự động.

### TypeScript

Tạo file *index.ts* và thêm đoạn mã sau:

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

Giờ bạn đã có máy chủ, nhưng nó chưa làm được nhiều việc, hãy sửa nó.

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

Với Java, tạo các thành phần máy chủ cốt lõi. Đầu tiên, chỉnh sửa lớp ứng dụng chính:

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

Tạo dịch vụ calculator *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**Các thành phần tùy chọn cho dịch vụ sẵn sàng sản xuất:**

Tạo cấu hình khởi động *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

Tạo controller kiểm tra sức khỏe *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

Tạo bộ xử lý ngoại lệ *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

Tạo banner tùy chỉnh *src/main/resources/banner.txt*:

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

### -5- Thêm công cụ và tài nguyên

Thêm công cụ và tài nguyên bằng cách thêm đoạn mã sau:

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

Công cụ của bạn nhận tham số `a` và `b` và chạy một hàm trả về phản hồi theo dạng:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

Tài nguyên của bạn được truy cập qua chuỗi "greeting", nhận tham số `name` và tạo phản hồi tương tự công cụ:

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

Trong đoạn mã trên, chúng ta đã:

- Định nghĩa công cụ `add` nhận tham số `a` và `p`, đều là số nguyên.
- Tạo tài nguyên `greeting` nhận tham số `name`.

### .NET

Thêm đoạn này vào file Program.cs của bạn:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Các công cụ đã được tạo ở bước trước.

### -6- Mã hoàn chỉnh cuối cùng

Hãy thêm đoạn mã cuối cùng để máy chủ có thể khởi động:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

Đây là mã đầy đủ:

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

Tạo file Program.cs với nội dung sau:

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

Lớp ứng dụng chính hoàn chỉnh của bạn sẽ trông như sau:

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

### -7- Kiểm thử máy chủ

Khởi động máy chủ với lệnh sau:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> Để sử dụng MCP Inspector, dùng `mcp dev server.py` sẽ tự động khởi chạy Inspector và cung cấp token phiên proxy cần thiết. Nếu dùng `mcp run server.py`, bạn cần khởi động Inspector thủ công và cấu hình kết nối.

### .NET

Đảm bảo bạn đang ở thư mục dự án:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- Chạy với inspector

Inspector là công cụ tuyệt vời giúp bạn khởi động máy chủ và tương tác để kiểm thử hoạt động. Hãy khởi động nó:

> [!NOTE]
> Trường "command" có thể khác nhau vì nó chứa lệnh chạy máy chủ với runtime cụ thể của bạn.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

Hoặc thêm vào *package.json* như sau: `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` rồi chạy `npm run inspect`

Python sử dụng một công cụ Node.js gọi là inspector. Bạn có thể gọi công cụ này như sau:

```sh
mcp dev server.py
```

Tuy nhiên, nó không hỗ trợ tất cả các phương thức có trên công cụ, nên bạn nên chạy công cụ Node.js trực tiếp như dưới đây:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```

Nếu bạn dùng công cụ hoặc IDE cho phép cấu hình lệnh và tham số chạy script, hãy đặt `python` ở trường `Command` và `server.py` ở trường `Arguments`. Điều này đảm bảo script chạy đúng.

### .NET

Đảm bảo bạn đang ở thư mục dự án:

```sh
cd McpCalculatorServer
npx @modelcontextprotocol/inspector dotnet run
```

### Java

Đảm bảo máy chủ calculator đang chạy  
Sau đó chạy inspector:

```cmd
npx @modelcontextprotocol/inspector
```

Trong giao diện web của inspector:

1. Chọn "SSE" làm loại truyền tải
2. Đặt URL là: `http://localhost:8080/sse`
3. Nhấn "Connect"

![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.vi.png)

**Bạn đã kết nối với máy chủ**  
**Phần kiểm thử máy chủ Java đã hoàn thành**

Phần tiếp theo sẽ hướng dẫn tương tác với máy chủ.

Bạn sẽ thấy giao diện người dùng như sau:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.vi.png)

1. Kết nối với máy chủ bằng cách chọn nút Connect  
   Khi kết nối thành công, bạn sẽ thấy:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.vi.png)

2. Chọn "Tools" và "listTools", bạn sẽ thấy "Add" xuất hiện, chọn "Add" và điền các giá trị tham số.

   Bạn sẽ nhận được phản hồi như sau, tức là kết quả từ công cụ "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.vi.png)

Chúc mừng, bạn đã tạo và chạy thành công máy chủ đầu tiên!

### SDK chính thức

MCP cung cấp SDK chính thức cho nhiều ngôn ngữ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Được duy trì phối hợp với Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Được duy trì phối hợp với Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Triển khai chính thức cho TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Triển khai chính thức cho Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Triển khai chính thức cho Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Được duy trì phối hợp cùng Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Triển khai chính thức bằng Rust

## Những điểm chính cần nhớ

- Thiết lập môi trường phát triển MCP rất đơn giản với các SDK dành riêng cho từng ngôn ngữ  
- Xây dựng server MCP bao gồm việc tạo và đăng ký các công cụ với các schema rõ ràng  
- Việc kiểm thử và gỡ lỗi là rất quan trọng để đảm bảo triển khai MCP đáng tin cậy

## Ví dụ mẫu

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Bài tập

Tạo một server MCP đơn giản với một công cụ bạn chọn:

1. Triển khai công cụ bằng ngôn ngữ bạn ưa thích (.NET, Java, Python hoặc JavaScript).  
2. Định nghĩa các tham số đầu vào và giá trị trả về.  
3. Chạy công cụ inspector để đảm bảo server hoạt động như mong muốn.  
4. Kiểm thử triển khai với nhiều đầu vào khác nhau.

## Giải pháp

[Solution](./solution/README.md)

## Tài nguyên bổ sung

- [Xây dựng Agents sử dụng Model Context Protocol trên Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP với Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Tiếp theo

Tiếp theo: [Bắt đầu với MCP Clients](../02-client/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.