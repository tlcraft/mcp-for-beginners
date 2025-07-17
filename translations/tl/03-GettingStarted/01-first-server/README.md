<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fa635ae747c9b4d5c2f61c6c46cb695f",
  "translation_date": "2025-07-17T19:07:31+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tl"
}
-->
# Pagsisimula sa MCP

Maligayang pagdating sa iyong unang hakbang gamit ang Model Context Protocol (MCP)! Kung bago ka sa MCP o nais mong palalimin ang iyong kaalaman, gagabayan ka ng gabay na ito sa mga mahahalagang hakbang sa pagsasaayos at pagbuo. Malalaman mo kung paano pinapadali ng MCP ang tuloy-tuloy na integrasyon sa pagitan ng mga AI model at mga aplikasyon, at matututuhan mo kung paano mabilis na ihanda ang iyong kapaligiran para sa pagbuo at pagsubok ng mga solusyong pinapagana ng MCP.

> TLDR; Kung gumagawa ka ng mga AI app, alam mo na maaari kang magdagdag ng mga tool at iba pang mga mapagkukunan sa iyong LLM (large language model), upang maging mas may kaalaman ang LLM. Ngunit kung ilalagay mo ang mga tool at mapagkukunang iyon sa isang server, maaaring gamitin ng anumang kliyente ang kakayahan ng app at server, may LLM man o wala.

## Pangkalahatang-ideya

Nagbibigay ang araling ito ng praktikal na gabay sa pagsasaayos ng mga kapaligiran ng MCP at pagbuo ng iyong unang mga aplikasyon ng MCP. Matututuhan mo kung paano i-setup ang mga kinakailangang tool at framework, bumuo ng mga pangunahing MCP server, gumawa ng mga host application, at subukan ang iyong mga implementasyon.

Ang Model Context Protocol (MCP) ay isang bukas na protocol na nagtatakda kung paano nagbibigay ng konteksto ang mga aplikasyon sa mga LLM. Isipin ang MCP bilang isang USB-C port para sa mga AI application - nagbibigay ito ng isang standard na paraan para ikonekta ang mga AI model sa iba't ibang pinagkukunan ng data at mga tool.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Mag-setup ng mga development environment para sa MCP gamit ang C#, Java, Python, TypeScript, at JavaScript
- Bumuo at mag-deploy ng mga pangunahing MCP server na may mga custom na tampok (mga resources, prompts, at tools)
- Gumawa ng mga host application na nakakonekta sa mga MCP server
- Subukan at i-debug ang mga implementasyon ng MCP

## Pagsasaayos ng Iyong MCP Environment

Bago ka magsimulang gumamit ng MCP, mahalagang ihanda ang iyong development environment at maunawaan ang pangunahing workflow. Gagabayan ka ng seksyong ito sa mga unang hakbang ng setup upang matiyak ang maayos na pagsisimula sa MCP.

### Mga Kinakailangan

Bago sumabak sa pag-develop gamit ang MCP, siguraduhing mayroon kang:

- **Development Environment**: Para sa napili mong wika (C#, Java, Python, TypeScript, o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, o anumang modernong code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, o npm/yarn
- **API Keys**: Para sa anumang AI services na balak mong gamitin sa iyong mga host application

## Pangunahing Estruktura ng MCP Server

Karaniwang binubuo ang isang MCP server ng:

- **Server Configuration**: Pagsasaayos ng port, authentication, at iba pang settings
- **Resources**: Data at konteksto na ibinibigay sa mga LLM
- **Tools**: Mga functionality na maaaring tawagin ng mga modelo
- **Prompts**: Mga template para sa pagbuo o pag-istruktura ng teksto

Narito ang isang pinasimpleng halimbawa sa TypeScript:

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

Sa code sa itaas ay:

- In-import ang mga kinakailangang klase mula sa MCP TypeScript SDK.
- Gumawa at nag-configure ng bagong MCP server instance.
- Nagrehistro ng custom na tool (`calculator`) na may handler function.
- Sinimulan ang server upang makinig sa mga papasok na MCP request.

## Pagsubok at Pag-debug

Bago ka magsimulang subukan ang iyong MCP server, mahalagang maunawaan ang mga magagamit na tool at mga pinakamahusay na kasanayan sa pag-debug. Ang epektibong pagsubok ay nagsisiguro na gumagana ang iyong server ayon sa inaasahan at tumutulong sa mabilis na pagtukoy at paglutas ng mga isyu. Inilalahad ng sumusunod na seksyon ang mga inirerekomendang pamamaraan para sa pag-validate ng iyong implementasyon ng MCP.

Nagbibigay ang MCP ng mga tool upang matulungan kang subukan at i-debug ang iyong mga server:

- **Inspector tool**, isang graphical interface na nagpapahintulot sa iyo na kumonekta sa iyong server at subukan ang iyong mga tool, prompt, at resource.
- **curl**, maaari ka ring kumonekta sa iyong server gamit ang command line tool tulad ng curl o iba pang kliyente na maaaring gumawa at magpatakbo ng mga HTTP command.

### Paggamit ng MCP Inspector

Ang [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ay isang visual testing tool na tumutulong sa iyo na:

1. **Matuklasan ang Kakayahan ng Server**: Awtomatikong tuklasin ang mga available na resource, tool, at prompt
2. **Subukan ang Pagpapatakbo ng Tool**: Subukan ang iba't ibang parameter at makita ang mga tugon nang real-time
3. **Tingnan ang Metadata ng Server**: Suriin ang impormasyon ng server, mga schema, at mga configuration

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

Kapag pinatakbo mo ang mga utos sa itaas, magbubukas ang MCP Inspector ng lokal na web interface sa iyong browser. Makikita mo ang dashboard na nagpapakita ng iyong mga rehistradong MCP server, ang kanilang mga available na tool, resource, at prompt. Pinapayagan ka ng interface na ito na interaktibong subukan ang pagpapatakbo ng tool, suriin ang metadata ng server, at makita ang mga tugon nang real-time, na nagpapadali sa pag-validate at pag-debug ng iyong mga implementasyon ng MCP server.

Narito ang isang screenshot kung ano ang maaaring itsura nito:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tl.png)

## Mga Karaniwang Isyu sa Setup at Mga Solusyon

| Isyu | Posibleng Solusyon |
|-------|-------------------|
| Connection refused | Suriin kung tumatakbo ang server at tama ang port |
| Mga error sa pagpapatakbo ng tool | Balikan ang validation ng parameter at error handling |
| Mga pagkabigo sa authentication | Siguraduhing tama ang API keys at mga permiso |
| Mga error sa schema validation | Tiyaking tugma ang mga parameter sa tinukoy na schema |
| Hindi nagsisimula ang server | Suriin kung may conflict sa port o kulang ang dependencies |
| Mga error sa CORS | I-configure nang tama ang CORS headers para sa cross-origin requests |
| Mga isyu sa authentication | Siguraduhing valid ang token at may tamang permiso |

## Lokal na Pag-develop

Para sa lokal na pag-develop at pagsubok, maaari mong patakbuhin ang mga MCP server direkta sa iyong makina:

1. **Simulan ang proseso ng server**: Patakbuhin ang iyong MCP server application
2. **I-configure ang networking**: Siguraduhing accessible ang server sa inaasahang port
3. **Kumonekta ang mga kliyente**: Gamitin ang mga lokal na URL tulad ng `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Pagbuo ng Iyong Unang MCP Server

Napag-usapan na natin ang [Core concepts](/01-CoreConcepts/README.md) sa isang naunang aralin, ngayon ay panahon na para ilapat ang kaalamang iyon.

### Ano ang Kayang Gawin ng Isang Server

Bago tayo magsulat ng code, alalahanin muna natin kung ano ang kayang gawin ng isang server:

Ang isang MCP server ay maaaring:

- Mag-access ng mga lokal na file at database
- Kumonekta sa mga remote API
- Magsagawa ng mga kalkulasyon
- Makipag-integrate sa iba pang mga tool at serbisyo
- Magbigay ng user interface para sa interaksyon

Maganda, ngayon na alam na natin ang mga kayang gawin nito, simulan na natin ang pag-cocode.

## Ehersisyo: Paglikha ng Server

Para gumawa ng server, sundin ang mga hakbang na ito:

- I-install ang MCP SDK.
- Gumawa ng proyekto at i-setup ang estruktura ng proyekto.
- Isulat ang code ng server.
- Subukan ang server.

### -1- I-install ang SDK

Medyo nagkakaiba ito depende sa napili mong runtime, kaya piliin ang isa sa mga runtime sa ibaba:

> [!NOTE]
> Para sa Python, unang gagawin ang proyekto at pagkatapos ay i-install ang mga dependencies.

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

Para sa Java, gumawa ng Spring Boot project:

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

I-extract ang zip file:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

Idagdag ang sumusunod na kumpletong configuration sa iyong *pom.xml* file:

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

### -2- Gumawa ng proyekto

Ngayon na na-install mo na ang SDK, gumawa tayo ng proyekto:

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

### -3- Gumawa ng mga file ng proyekto  
### TypeScript

Gumawa ng *package.json* na may sumusunod na nilalaman:

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

Gumawa ng *tsconfig.json* na may sumusunod na nilalaman:

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

Gumawa ng file na *server.py*

```sh
touch server.py
```

### .NET

I-install ang mga kinakailangang NuGet packages:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Para sa mga Java Spring Boot project, awtomatikong nagagawa ang estruktura ng proyekto.

### -4- Gumawa ng code ng server

### TypeScript

Gumawa ng file na *index.ts* at idagdag ang sumusunod na code:

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

Ngayon ay may server ka na, pero hindi pa ito masyadong gumagana, ayusin natin iyon.

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

Para sa Java, gumawa ng mga pangunahing bahagi ng server. Una, baguhin ang pangunahing application class:

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

Gumawa ng calculator service *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**Opsyonal na mga bahagi para sa production-ready na serbisyo:**

Gumawa ng startup configuration *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

Gumawa ng health controller *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

Gumawa ng exception handler *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

Gumawa ng custom banner *src/main/resources/banner.txt*:

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

### -5- Magdagdag ng tool at resource

Magdagdag ng tool at resource sa pamamagitan ng pagdagdag ng sumusunod na code:

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

Tumatanggap ang iyong tool ng mga parameter na `a` at `b` at nagpapatakbo ng function na gumagawa ng tugon sa anyo ng:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

Ang iyong resource ay naa-access sa pamamagitan ng string na "greeting" at tumatanggap ng parameter na `name` at gumagawa ng katulad na tugon tulad ng tool:

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

Sa code sa itaas ay:

- Nagtakda ng tool na `add` na tumatanggap ng mga parameter na `a` at `p`, parehong integer.
- Gumawa ng resource na tinatawag na `greeting` na tumatanggap ng parameter na `name`.

### .NET

Idagdag ito sa iyong Program.cs file:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Nagawa na ang mga tool sa naunang hakbang.

### -6- Panghuling code

Idagdag natin ang huling code na kailangan para makapagsimula ang server:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

Narito ang buong code:

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

Gumawa ng Program.cs file na may sumusunod na nilalaman:

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

Ang kumpletong pangunahing application class mo ay dapat ganito ang hitsura:

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

### -7- Subukan ang server

Simulan ang server gamit ang sumusunod na utos:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> Para gamitin ang MCP Inspector, gamitin ang `mcp dev server.py` na awtomatikong magbubukas ng Inspector at nagbibigay ng kinakailangang proxy session token. Kung gagamit ng `mcp run server.py`, kailangan mong manu-manong simulan ang Inspector at i-configure ang koneksyon.

### .NET

Siguraduhing nasa loob ka ng iyong project directory:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- Patakbuhin gamit ang inspector

Ang inspector ay isang mahusay na tool na maaaring simulan ang iyong server at payagan kang makipag-ugnayan dito upang masubukan kung gumagana ito. Simulan natin ito:

> [!NOTE]
> Maaaring mag-iba ang itsura sa "command" field dahil ito ay naglalaman ng utos para patakbuhin ang server gamit ang iyong partikular na runtime.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

o idagdag ito sa iyong *package.json* tulad nito: `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` at pagkatapos ay patakbuhin ang `npm run inspect`

Ang Python ay gumagamit ng Node.js tool na tinatawag na inspector. Posibleng tawagin ang tool na ito tulad nito:

```sh
mcp dev server.py
```

Gayunpaman, hindi nito naipapatupad ang lahat ng mga method na available sa tool kaya inirerekomenda na patakbuhin mo ang Node.js tool nang direkta tulad ng nasa ibaba:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```  
Kung gumagamit ka ng tool o IDE na nagpapahintulot sa pag-configure ng mga command at argumento para sa pagpapatakbo ng mga script,  
siguraduhing itakda ang `python` sa `Command` field at `server.py` bilang `Arguments`. Tinitiyak nito na tama ang pagpapatakbo ng script.

### .NET

Siguraduhing nasa loob ka ng iyong project directory:

```sh
cd McpCalculatorServer
npx @modelcontextprotocol/inspector dotnet run
```

### Java

Siguraduhing tumatakbo ang iyong calculator server  
Pagkatapos patakbuhin ang inspector:

```cmd
npx @modelcontextprotocol/inspector
```

Sa inspector web interface:

1. Piliin ang "SSE" bilang uri ng transport
2. Itakda ang URL sa: `http://localhost:8080/sse`
3. I-click ang "Connect"

![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.tl.png)

**Nakakonekta ka na ngayon sa server**  
**Natapos na ang seksyon ng pagsubok sa Java server**

Ang susunod na seksyon ay tungkol sa pakikipag-ugnayan sa server.

Makikita mo ang sumusunod na user interface:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png)

1. Kumonekta sa server sa pamamagitan ng pagpili sa Connect button  
  Kapag nakakonekta ka na sa server, makikita mo ang sumusunod:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tl.png)

1. Piliin ang "Tools" at "listTools", makikita mo ang "Add" na lalabas, piliin ang "Add" at punan ang mga halaga ng parameter.

  Makikita mo ang sumusunod na tugon, ibig sabihin ay resulta mula sa "add" tool:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tl.png)

Congrats, nagawa mo nang likhain at patakbuhin ang iyong unang server!

### Opisyal na SDKs

Nagbibigay ang MCP ng opisyal na SDK para sa iba't ibang wika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili sa pakikipagtulungan sa Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili sa pakikipagtulungan sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na implementasyon sa TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na implementasyon sa Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na implementasyon ng Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili sa pakikipagtulungan sa Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na implementasyon ng Rust  

## Mga Pangunahing Punto

- Madaling mag-setup ng MCP development environment gamit ang mga SDK na nakatuon sa partikular na wika  
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrerehistro ng mga tool na may malinaw na mga schema  
- Mahalaga ang pagsubok at pag-debug para sa maaasahang implementasyon ng MCP  

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Takdang-Aralin

Gumawa ng isang simpleng MCP server gamit ang tool na iyong pipiliin:

1. I-implementa ang tool sa iyong gustong wika (.NET, Java, Python, o JavaScript).  
2. Tukuyin ang mga input parameter at mga return value.  
3. Patakbuhin ang inspector tool upang matiyak na gumagana ang server ayon sa inaasahan.  
4. Subukan ang implementasyon gamit ang iba't ibang input.  

## Solusyon

[Solution](./solution/README.md)  

## Karagdagang Mga Mapagkukunan

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Ano ang susunod

Susunod: [Getting Started with MCP Clients](../02-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.