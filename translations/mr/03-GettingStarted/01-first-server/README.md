<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd0fdbbbebbef2b6b179ceba21d82ed2",
  "translation_date": "2025-07-17T00:26:17+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "mr"
}
-->
# MCP सह सुरुवात करणे

Model Context Protocol (MCP) सह तुमच्या पहिल्या पावलांमध्ये तुमचे स्वागत आहे! तुम्ही MCP मध्ये नवीन असाल किंवा तुमचे ज्ञान अधिक सखोल करायचे असेल, हा मार्गदर्शक तुम्हाला आवश्यक सेटअप आणि विकास प्रक्रियेतून मार्गदर्शन करेल. तुम्हाला कसे MCP AI मॉडेल्स आणि अॅप्लिकेशन्स यांच्यात सहज समाकलन सक्षम करते हे समजेल, तसेच MCP-शक्तीने चालणाऱ्या सोल्यूशन्स तयार करण्यासाठी आणि चाचणीसाठी तुमचे वातावरण लवकर तयार करण्याचा मार्ग शिकायला मिळेल.

> TLDR; जर तुम्ही AI अॅप्स तयार करत असाल, तर तुम्हाला माहीत आहे की तुम्ही तुमच्या LLM (large language model) मध्ये टूल्स आणि इतर संसाधने जोडू शकता, ज्यामुळे LLM अधिक ज्ञानवान होते. मात्र जर तुम्ही ती टूल्स आणि संसाधने सर्व्हरवर ठेवली, तर अॅप आणि सर्व्हरची क्षमता कोणत्याही क्लायंटद्वारे LLM सह किंवा शिवाय वापरली जाऊ शकते.

## आढावा

हा धडा MCP वातावरण सेटअप करण्याबाबत आणि तुमची पहिली MCP अॅप्लिकेशन्स तयार करण्याबाबत व्यावहारिक मार्गदर्शन देतो. तुम्हाला आवश्यक टूल्स आणि फ्रेमवर्क्स कसे सेट करायचे, मूलभूत MCP सर्व्हर्स कसे तयार करायचे, होस्ट अॅप्लिकेशन्स कसे तयार करायचे आणि तुमच्या अंमलबजावणीची चाचणी कशी करायची हे शिकायला मिळेल.

Model Context Protocol (MCP) हा एक खुला प्रोटोकॉल आहे जो अॅप्लिकेशन्सना LLMs ला संदर्भ प्रदान करण्याचा एकसंध मार्ग प्रदान करतो. MCP ला AI अॅप्लिकेशन्ससाठी USB-C पोर्ट म्हणून विचार करा - तो AI मॉडेल्सना विविध डेटा स्रोत आणि टूल्सशी जोडण्यासाठी एक मानकीकृत मार्ग पुरवतो.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- C#, Java, Python, TypeScript, आणि JavaScript मध्ये MCP साठी विकास वातावरण सेट करणे
- कस्टम वैशिष्ट्यांसह (संसाधने, प्रॉम्प्ट्स, आणि टूल्स) मूलभूत MCP सर्व्हर्स तयार करणे आणि तैनात करणे
- MCP सर्व्हर्सशी जोडणाऱ्या होस्ट अॅप्लिकेशन्स तयार करणे
- MCP अंमलबजावणीची चाचणी आणि डीबग करणे

## तुमचे MCP वातावरण सेट करणे

MCP सह काम सुरू करण्यापूर्वी, तुमचे विकास वातावरण तयार करणे आणि मूलभूत कार्यप्रवाह समजून घेणे महत्त्वाचे आहे. हा विभाग सुरळीत सुरुवात सुनिश्चित करण्यासाठी प्राथमिक सेटअप पायऱ्यांमध्ये तुम्हाला मार्गदर्शन करेल.

### पूर्वअट

MCP विकासात उतरायच्या आधी, खात्री करा की तुमच्याकडे आहे:

- **विकास वातावरण**: तुमच्या निवडलेल्या भाषेसाठी (C#, Java, Python, TypeScript, किंवा JavaScript)
- **IDE/एडिटर**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, किंवा कोणताही आधुनिक कोड एडिटर
- **पॅकेज मॅनेजर्स**: NuGet, Maven/Gradle, pip, किंवा npm/yarn
- **API कीज**: तुमच्या होस्ट अॅप्लिकेशन्समध्ये वापरण्यासाठी कोणत्याही AI सेवांसाठी

## मूलभूत MCP सर्व्हर रचना

एक MCP सर्व्हर सामान्यतः यांचा समावेश करतो:

- **सर्व्हर कॉन्फिगरेशन**: पोर्ट, प्रमाणीकरण, आणि इतर सेटिंग्ज सेट करणे
- **संसाधने**: LLMs साठी उपलब्ध असलेला डेटा आणि संदर्भ
- **टूल्स**: मॉडेल्स वापरू शकणारी कार्यक्षमता
- **प्रॉम्प्ट्स**: मजकूर तयार करण्यासाठी किंवा रचनेसाठी टेम्पलेट्स

TypeScript मध्ये एक सोपा उदाहरण:

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

वरील कोडमध्ये आपण:

- MCP TypeScript SDK मधून आवश्यक क्लासेस आयात केले.
- नवीन MCP सर्व्हर उदाहरण तयार आणि कॉन्फिगर केले.
- कस्टम टूल (`calculator`) एक हँडलर फंक्शनसह नोंदवले.
- येणाऱ्या MCP विनंत्यांसाठी सर्व्हर सुरू केले.

## चाचणी आणि डीबगिंग

तुमचा MCP सर्व्हर चाचणी करण्यापूर्वी, उपलब्ध टूल्स आणि डीबगिंगसाठी सर्वोत्तम पद्धती समजून घेणे महत्त्वाचे आहे. प्रभावी चाचणी तुमचा सर्व्हर अपेक्षेप्रमाणे वागतो याची खात्री करते आणि समस्या लवकर ओळखून सोडवण्यास मदत करते. पुढील विभागात तुमच्या MCP अंमलबजावणीची पडताळणी करण्यासाठी शिफारस केलेल्या पद्धती दिल्या आहेत.

MCP तुमच्या सर्व्हर्सची चाचणी आणि डीबग करण्यासाठी टूल्स पुरवते:

- **Inspector tool**, हा ग्राफिकल इंटरफेस तुम्हाला तुमच्या सर्व्हरशी जोडण्याची आणि तुमचे टूल्स, प्रॉम्प्ट्स आणि संसाधने चाचणी करण्याची परवानगी देतो.
- **curl**, तुम्ही curl सारख्या कमांड लाइन टूलचा वापर करून किंवा HTTP कमांड तयार आणि चालवू शकणाऱ्या इतर क्लायंट्सचा वापर करून तुमच्या सर्व्हरशी जोडू शकता.

### MCP Inspector वापरणे

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) हा एक दृश्यात्मक चाचणी टूल आहे जो तुम्हाला मदत करतो:

1. **सर्व्हर क्षमता शोधा**: उपलब्ध संसाधने, टूल्स, आणि प्रॉम्प्ट्स आपोआप शोधा
2. **टूल कार्यान्वयन चाचणी करा**: वेगवेगळे पॅरामीटर्स वापरून रिअल-टाइम प्रतिसाद पहा
3. **सर्व्हर मेटाडेटा पहा**: सर्व्हर माहिती, स्कीमा, आणि कॉन्फिगरेशन तपासा

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

वरील कमांड्स चालवल्यानंतर, MCP Inspector तुमच्या ब्राउझरमध्ये स्थानिक वेब इंटरफेस सुरू करेल. तुम्हाला तुमच्या नोंदणीकृत MCP सर्व्हर्सचा डॅशबोर्ड दिसेल, त्यांचे उपलब्ध टूल्स, संसाधने, आणि प्रॉम्प्ट्स. हा इंटरफेस टूल कार्यान्वयनाची चाचणी, सर्व्हर मेटाडेटा तपासणी, आणि रिअल-टाइम प्रतिसाद पाहण्याची परवानगी देतो, ज्यामुळे तुमच्या MCP सर्व्हर अंमलबजावणीची पडताळणी आणि डीबग करणे सोपे होते.

हे कसे दिसू शकते याचे स्क्रीनशॉट:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mr.png)

## सामान्य सेटअप समस्या आणि उपाय

| समस्या | शक्य तो उपाय |
|-------|-------------------|
| कनेक्शन नाकारले गेले | तपासा की सर्व्हर चालू आहे आणि पोर्ट बरोबर आहे का |
| टूल कार्यान्वयन त्रुटी | पॅरामीटर वैधता आणि त्रुटी हाताळणी तपासा |
| प्रमाणीकरण अयशस्वी | API कीज आणि परवानग्या तपासा |
| स्कीमा वैधता त्रुटी | पॅरामीटर्स परिभाषित स्कीमाशी जुळतात का ते तपासा |
| सर्व्हर सुरू होत नाही | पोर्ट संघर्ष किंवा आवश्यक अवलंबन तपासा |
| CORS त्रुटी | क्रॉस-ओरिजिन विनंत्यांसाठी योग्य CORS हेडर्स कॉन्फिगर करा |
| प्रमाणीकरण समस्या | टोकन वैधता आणि परवानग्या तपासा |

## स्थानिक विकास

स्थानिक विकास आणि चाचणीसाठी, तुम्ही तुमच्या मशीनवर थेट MCP सर्व्हर्स चालवू शकता:

1. **सर्व्हर प्रक्रिया सुरू करा**: तुमचा MCP सर्व्हर अॅप्लिकेशन चालवा
2. **नेटवर्किंग कॉन्फिगर करा**: सर्व्हर अपेक्षित पोर्टवर उपलब्ध आहे याची खात्री करा
3. **क्लायंट्स कनेक्ट करा**: `http://localhost:3000` सारख्या स्थानिक कनेक्शन URL वापरा

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## तुमचा पहिला MCP सर्व्हर तयार करणे

आम्ही [Core concepts](/01-CoreConcepts/README.md) आधीच्या धड्यात पाहिले आहेत, आता ते ज्ञान वापरण्याची वेळ आली आहे.

### सर्व्हर काय करू शकतो

कोड लिहायला सुरुवात करण्यापूर्वी, चला आठवूया की सर्व्हर काय करू शकतो:

MCP सर्व्हर उदाहरणार्थ:

- स्थानिक फाइल्स आणि डेटाबेसमध्ये प्रवेश करू शकतो
- रिमोट API शी कनेक्ट होऊ शकतो
- गणना करू शकतो
- इतर टूल्स आणि सेवांशी समाकलित होऊ शकतो
- संवादासाठी वापरकर्ता इंटरफेस पुरवू शकतो

छान, आता आपल्याला काय करता येते ते माहित आहे, तर कोडिंग सुरू करूया.

## सराव: सर्व्हर तयार करणे

सर्व्हर तयार करण्यासाठी, तुम्हाला खालील पायऱ्या पार पाडाव्या लागतील:

- MCP SDK इन्स्टॉल करा.
- प्रोजेक्ट तयार करा आणि प्रोजेक्ट रचना सेट करा.
- सर्व्हर कोड लिहा.
- सर्व्हरची चाचणी करा.

### -1- SDK इन्स्टॉल करा

तुमच्या निवडलेल्या रनटाइमनुसार हे थोडे वेगळे असते, त्यामुळे खालीलपैकी तुमच्या रनटाइमनुसार निवडा:

> [!NOTE]
> Python साठी, आम्ही प्रथम प्रोजेक्ट रचना तयार करू आणि नंतर अवलंबन इन्स्टॉल करू.

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

Java साठी, Spring Boot प्रोजेक्ट तयार करा:

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

झिप फाइल अनझिप करा:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

तुमच्या *pom.xml* फाइलमध्ये खालील पूर्ण कॉन्फिगरेशन जोडा:

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

खालील सामग्रीसह *package.json* तयार करा:

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

खालील सामग्रीसह *tsconfig.json* तयार करा:

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

*server.py* नावाची फाइल तयार करा
```sh
touch server.py
```

### .NET

आवश्यक NuGet पॅकेजेस इन्स्टॉल करा:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Java Spring Boot प्रोजेक्टसाठी, प्रोजेक्ट रचना आपोआप तयार होते.

### TypeScript

*index.ts* नावाची फाइल तयार करा आणि खालील कोड जोडा:

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

आता तुमच्याकडे सर्व्हर आहे, पण तो फार काही करत नाही, ते सुधारूया.

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

Java साठी, मुख्य सर्व्हर घटक तयार करा. प्रथम, मुख्य अॅप्लिकेशन क्लासमध्ये बदल करा:

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

कॅल्क्युलेटर सेवा तयार करा *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**उत्पादनासाठी तयार सेवेचे ऐच्छिक घटक:**

स्टार्टअप कॉन्फिगरेशन तयार करा *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

हेल्थ कंट्रोलर तयार करा *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

एक्सेप्शन हँडलर तयार करा *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

कस्टम बॅनर तयार करा *src/main/resources/banner.txt*:

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

### -5- टूल आणि संसाधन जोडणे

खालील कोड जोडून टूल आणि संसाधन जोडा:

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

तुमचा टूल `a` आणि `b` पॅरामीटर्स घेतो आणि खालील स्वरूपात प्रतिसाद तयार करणारी फंक्शन चालवतो:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

तुमचा संसाधन "greeting" स्ट्रिंगद्वारे प्रवेश केला जातो, `name` पॅरामीटर घेतो आणि टूलसारखा प्रतिसाद तयार करतो:

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

वरील कोडमध्ये आपण:

- `add` नावाचा टूल परिभाषित केला जो `a` आणि `p` (दोन्ही पूर्णांक) पॅरामीटर्स घेतो.
- `greeting` नावाचा संसाधन तयार केला जो `name` पॅरामीटर घेतो.

### .NET

हे तुमच्या Program.cs फाइलमध्ये जोडा:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

टूल्स आधीच्या टप्प्यात तयार केले गेले आहेत.

### -6 अंतिम कोड

सर्व्हर सुरू होण्यासाठी आवश्यक शेवटचा कोड जोडा:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

पूर्ण कोड येथे आहे:

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

खालील सामग्रीसह Program.cs फाइल तयार करा:

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

तुमचा पूर्ण मुख्य अॅप्लिकेशन क्लास असा दिसायला हवा:

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

### -7- सर्व्हरची चाचणी करा

खालील कमांडने सर्व्हर सुरू करा:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> MCP Inspector वापरण्यासाठी, `mcp dev server.py` वापरा जे आपोआप Inspector सुरू करते आणि आवश्यक प्रॉक्सी सेशन टोकन पुरवते. `mcp run server.py` वापरत असल्यास, तुम्हाला Inspector मॅन्युअली सुरू करावा लागेल आणि कनेक्शन कॉन्फिगर करावे लागेल.

### .NET

तुमच्या प्रोजेक्ट डायरेक्टरीत असल्याची खात्री करा:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- Inspector वापरून चालवा

Inspector हा एक उत्कृष्ट टूल आहे जो तुमचा सर्व्हर सुरू करतो आणि तुम्हाला त्याच्याशी संवाद साधण्याची परवानगी देतो, ज्यामुळे तुम्ही त्याची कार्यक्षमता तपासू शकता. चला ते सुरू करूया:

> [!NOTE]
> "command" फील्डमध्ये हे वेगळे दिसू शकते कारण त्यात तुमच्या विशिष्ट रनटाइमसाठी सर्व्हर चालवण्याचा कमांड असतो.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

किंवा तुमच्या *package.json* मध्ये `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` असा स्क्रिप्ट जोडा आणि नंतर `npm run inspect` चालवा.

Python मध्ये Node.js टूल inspector वापरले जाते. ते खालीलप्रमाणे कॉल करता येते:

```sh
mcp dev server.py
```

परंतु, ते टूलवरील सर्व पद्धती अंमलात आणत नाही, त्यामुळे Node.js टूल थेट खालीलप्रमाणे चालवण्याची शिफारस केली जाते:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```  
जर तुम्ही असे टूल किंवा IDE वापरत असाल जे स्क्रिप्ट्स चालवण्यासाठी कमांड आणि आर्ग्युमेंट्स कॉन्फिगर करण्याची परवानगी देते, तर `Command` फील्डमध्ये `python` आणि `Arguments` मध्ये `server.py` सेट करा. यामुळे स्क्रिप्ट योग्यरित्या चालेल.

### .NET

तुमच्या प्रोजेक्ट डायरेक्टरीत असल्याची खात्री करा:

```sh
cd McpCalculatorServer
npx @modelcontextprotocol/inspector dotnet run
```

### Java

तुमचा कॅल्क्युलेटर सर्व्हर चालू आहे याची खात्री करा.  
नंतर inspector चालवा:

```cmd
npx @modelcontextprotocol/inspector
```

Inspector वेब इंटरफेसमध्ये:

1. "SSE" ट्रान्सपोर्ट प्रकार निवडा  
2. URL सेट करा: `http://localhost:8080/sse`  
3. "Connect" क्लिक करा

![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.mr.png)

**तुम्ही आता सर्व्हरशी जोडलेले आहात**  
**Java सर्व्हर चाचणी विभाग आता पूर्ण झाला आहे**

पुढील विभाग सर्व्हरशी संवाद साधण्याबाबत आहे.

तुम्हाला खालील वापरकर्ता इंटरफेस दिसेल:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png)

1. Connect बटण निवडून सर्व्हरशी कनेक्ट व्हा  
  एकदा कनेक्ट झाल्यावर, तुम्हाला खालील दिसेल:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mr.png)

2. "Tools" आणि "listTools" निवडा, तुम्हाला "Add" दिसेल, "Add" निवडा आणि पॅरामीटर मूल्ये भरा.

  तुम्हाला खालील प्रतिसाद दिसेल, म्हणजे "add" टूलचा निकाल:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.mr.png)

अभिनंदन, तुम्ही तुमचा पहिला सर्व्हर तयार करून चालवला आहे!

### अधिकृत SDKs

MCP अनेक भाषांसाठी अधिकृत
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सोबत सहकार्याने देखभाल केली जाते
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## मुख्य मुद्दे

- भाषा-विशिष्ट SDK वापरून MCP विकास वातावरण सेट करणे सोपे आहे
- MCP सर्व्हर तयार करताना स्पष्ट स्कीमासह टूल तयार करणे आणि नोंदणी करणे आवश्यक आहे
- विश्वसनीय MCP अंमलबजावणीसाठी चाचणी आणि डीबगिंग महत्त्वाचे आहे

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## कार्य

तुमच्या आवडत्या टूलसह एक सोपा MCP सर्व्हर तयार करा:

1. तुमच्या पसंतीच्या भाषेत टूल अंमलात आणा (.NET, Java, Python, किंवा JavaScript).
2. इनपुट पॅरामीटर्स आणि परतावा मूल्ये निश्चित करा.
3. सर्व्हर योग्यरित्या कार्य करत असल्याची खात्री करण्यासाठी inspector टूल चालवा.
4. विविध इनपुटसह अंमलबजावणीची चाचणी करा.

## समाधान

[Solution](./solution/README.md)

## अतिरिक्त संसाधने

- [Azure वर Model Context Protocol वापरून एजंट तयार करा](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps सह Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## पुढे काय

पुढे: [MCP Clients सह सुरुवात](../02-client/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.