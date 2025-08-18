<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ee93d6093964ea579dbdc20b4d643e9b",
  "translation_date": "2025-08-18T16:12:01+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ne"
}
-->
# MCP सुरु गर्न

Model Context Protocol (MCP) सँगको तपाईंको पहिलो कदममा स्वागत छ! चाहे तपाईं MCP मा नयाँ हुनुहुन्छ वा आफ्नो ज्ञानलाई गहिरो बनाउन चाहनुहुन्छ, यो मार्गदर्शकले तपाईंलाई आवश्यक सेटअप र विकास प्रक्रियामा लैजानेछ। तपाईंले MCP कसरी AI मोडेल र एप्लिकेसनहरू बीच सहज एकीकरण सक्षम बनाउँछ भन्ने पत्ता लगाउनुहुनेछ, र MCP-संचालित समाधानहरू निर्माण र परीक्षण गर्न आफ्नो वातावरण छिटो तयार गर्ने तरिका सिक्नुहुनेछ।

> TLDR; यदि तपाईं AI एप्लिकेसनहरू निर्माण गर्नुहुन्छ भने, तपाईंले LLM (ठूलो भाषा मोडेल) लाई थप जानकार बनाउन उपकरणहरू र अन्य स्रोतहरू थप्न सक्नुहुन्छ। तर यदि तपाईं ती उपकरणहरू र स्रोतहरूलाई सर्भरमा राख्नुहुन्छ भने, एप्लिकेसन र सर्भरको क्षमता कुनै पनि क्लाइन्टले LLM सहित/बिना प्रयोग गर्न सक्दछ।

## अवलोकन

यो पाठले MCP वातावरण सेटअप गर्ने र तपाईंको पहिलो MCP एप्लिकेसनहरू निर्माण गर्ने व्यावहारिक मार्गदर्शन प्रदान गर्दछ। तपाईंले आवश्यक उपकरण र फ्रेमवर्क सेटअप गर्ने, आधारभूत MCP सर्भरहरू निर्माण गर्ने, होस्ट एप्लिकेसनहरू सिर्जना गर्ने, र तपाईंको कार्यान्वयनहरू परीक्षण गर्ने तरिका सिक्नुहुनेछ।

Model Context Protocol (MCP) एक खुला प्रोटोकल हो जसले एप्लिकेसनहरूले LLM लाई सन्दर्भ प्रदान गर्ने तरिका मानकीकरण गर्दछ। MCP लाई AI एप्लिकेसनहरूको लागि USB-C पोर्ट जस्तै सोच्नुहोस् - यसले AI मोडेललाई विभिन्न डेटा स्रोतहरू र उपकरणहरूसँग जडान गर्न मानकीकृत तरिका प्रदान गर्दछ।

## सिक्ने उद्देश्यहरू

यो पाठको अन्त्यसम्ममा, तपाईं सक्षम हुनुहुनेछ:

- C#, Java, Python, TypeScript, र Rust मा MCP को लागि विकास वातावरण सेटअप गर्न
- स्रोतहरू, प्रम्प्टहरू, र उपकरणहरू सहित अनुकूलित सुविधाहरू भएको आधारभूत MCP सर्भर निर्माण र तैनात गर्न
- MCP सर्भरहरूसँग जडान गर्ने होस्ट एप्लिकेसनहरू सिर्जना गर्न
- MCP कार्यान्वयनहरू परीक्षण र डिबग गर्न

## तपाईंको MCP वातावरण सेटअप गर्दै

MCP मा काम सुरु गर्नु अघि, तपाईंको विकास वातावरण तयार पार्नु र आधारभूत कार्यप्रवाह बुझ्नु महत्त्वपूर्ण छ। यो खण्डले MCP सँग सहज सुरुवात सुनिश्चित गर्न प्रारम्भिक सेटअप चरणहरूमा तपाईंलाई मार्गदर्शन गर्नेछ।

### पूर्वापेक्षाहरू

MCP विकासमा डुब्नु अघि, सुनिश्चित गर्नुहोस् कि तपाईंले:

- **विकास वातावरण**: तपाईंले रोजेको भाषा (C#, Java, Python, TypeScript, वा Rust) को लागि
- **IDE/सम्पादक**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, वा कुनै पनि आधुनिक कोड सम्पादक
- **प्याकेज प्रबन्धकहरू**: NuGet, Maven/Gradle, pip, npm/yarn, वा Cargo
- **API कुञ्जीहरू**: तपाईंको होस्ट एप्लिकेसनहरूमा प्रयोग गर्न चाहनु भएको कुनै पनि AI सेवाहरूको लागि

## आधारभूत MCP सर्भर संरचना

MCP सर्भर सामान्यतया समावेश गर्दछ:

- **सर्भर कन्फिगरेसन**: पोर्ट, प्रमाणीकरण, र अन्य सेटिङहरू सेटअप गर्नुहोस्
- **स्रोतहरू**: LLM लाई उपलब्ध गराइएको डेटा र सन्दर्भ
- **उपकरणहरू**: मोडेलहरूले आह्वान गर्न सक्ने कार्यक्षमता
- **प्रम्प्टहरू**: पाठ उत्पन्न वा संरचना गर्न टेम्प्लेटहरू

TypeScript मा एक सरलीकृत उदाहरण यहाँ छ:

```typescript
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
  "file",
  // The 'list' parameter controls how the resource lists available files. Setting it to undefined disables listing for this resource.
  new ResourceTemplate("file://{path}", { list: undefined }),
  async (uri, { path }) => ({
    contents: [{
      uri: uri.href,
      text: `File, ${path}!`
    }]
// Add a file resource that reads the file contents
server.resource(
  "file",
  new ResourceTemplate("file://{path}", { list: undefined }),
  async (uri, { path }) => {
    let text;
    try {
      text = await fs.readFile(path, "utf8");
    } catch (err) {
      text = `Error reading file: ${err.message}`;
    }
    return {
      contents: [{
        uri: uri.href,
        text
      }]
    };
  }
);

server.prompt(
  "review-code",
  { code: z.string() },
  ({ code }) => ({
    messages: [{
      role: "user",
      content: {
        type: "text",
        text: `Please review this code:\n\n${code}`
      }
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

माथिको कोडमा हामीले:

- MCP TypeScript SDK बाट आवश्यक कक्षाहरू आयात गरेका छौं।
- नयाँ MCP सर्भर उदाहरण सिर्जना र कन्फिगर गरेका छौं।
- कस्टम उपकरण (`calculator`) दर्ता गरेका छौं जसमा ह्यान्डलर फङ्क्शन छ।
- MCP अनुरोधहरूको लागि सर्भरलाई सुन्न सुरु गरेका छौं।

## परीक्षण र डिबग गर्दै

तपाईंको MCP सर्भर परीक्षण सुरु गर्नु अघि, उपलब्ध उपकरणहरू र डिबगका लागि उत्तम अभ्यासहरू बुझ्नु महत्त्वपूर्ण छ। प्रभावकारी परीक्षणले तपाईंको सर्भर अपेक्षित रूपमा व्यवहार गर्छ भन्ने सुनिश्चित गर्दछ र समस्याहरू चाँडै पहिचान र समाधान गर्न मद्दत गर्दछ। निम्न खण्डले तपाईंको MCP कार्यान्वयनलाई मान्य गर्न सिफारिस गरिएका दृष्टिकोणहरू outlines गर्दछ।

MCP ले तपाईंलाई सर्भर परीक्षण र डिबग गर्न मद्दत गर्ने उपकरणहरू प्रदान गर्दछ:

- **Inspector tool**, यो ग्राफिकल इन्टरफेसले तपाईंलाई सर्भरसँग जडान गर्न र उपकरणहरू, प्रम्प्टहरू, र स्रोतहरू परीक्षण गर्न अनुमति दिन्छ।
- **curl**, तपाईं कमाण्ड लाइन उपकरण जस्तै curl वा HTTP कमाण्डहरू चलाउन सक्ने अन्य क्लाइन्ट प्रयोग गरेर पनि सर्भरसँग जडान गर्न सक्नुहुन्छ।

### MCP Inspector प्रयोग गर्दै

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) एक दृश्य परीक्षण उपकरण हो जसले तपाईंलाई मद्दत गर्दछ:

1. **सर्भर क्षमताहरू पत्ता लगाउनुहोस्**: उपलब्ध स्रोतहरू, उपकरणहरू, र प्रम्प्टहरू स्वचालित रूपमा पत्ता लगाउनुहोस्
2. **उपकरण कार्यान्वयन परीक्षण गर्नुहोस्**: विभिन्न प्यारामिटरहरू प्रयास गर्नुहोस् र वास्तविक समयमा प्रतिक्रियाहरू हेर्नुहोस्
3. **सर्भर मेटाडेटा हेर्नुहोस्**: सर्भर जानकारी, स्कीमाहरू, र कन्फिगरेसनहरू जाँच गर्नुहोस्

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

माथिका कमाण्डहरू चलाउँदा, MCP Inspector ले तपाईंको ब्राउजरमा स्थानीय वेब इन्टरफेस सुरु गर्नेछ। तपाईंले आफ्नो दर्ता गरिएका MCP सर्भरहरू, तिनीहरूको उपलब्ध उपकरणहरू, स्रोतहरू, र प्रम्प्टहरू प्रदर्शन गर्ने ड्यासबोर्ड देख्न सक्नुहुन्छ। इन्टरफेसले तपाईंलाई अन्तरक्रियात्मक रूपमा उपकरण कार्यान्वयन परीक्षण गर्न, सर्भर मेटाडेटा निरीक्षण गर्न, र वास्तविक समय प्रतिक्रियाहरू हेर्न अनुमति दिन्छ, जसले तपाईंको MCP सर्भर कार्यान्वयनहरू मान्य र डिबग गर्न सजिलो बनाउँछ।

यो कस्तो देखिन सक्छ भन्ने स्क्रीनशट यहाँ छ:

![MCP Inspector सर्भर जडान](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ne.png)

## सामान्य सेटअप समस्याहरू र समाधानहरू

| समस्या | सम्भावित समाधान |
|-------|-------------------|
| जडान अस्वीकृत | सर्भर चलिरहेको छ र पोर्ट सही छ कि छैन जाँच गर्नुहोस् |
| उपकरण कार्यान्वयन त्रुटिहरू | प्यारामिटर मान्यकरण र त्रुटि ह्यान्डलिङ समीक्षा गर्नुहोस् |
| प्रमाणीकरण असफलता | API कुञ्जीहरू र अनुमतिहरू प्रमाणित गर्नुहोस् |
| स्कीमा मान्यकरण त्रुटिहरू | प्यारामिटरहरू परिभाषित स्कीमासँग मेल खान सुनिश्चित गर्नुहोस् |
| सर्भर सुरु नभएको | पोर्ट द्वन्द्व वा हराइरहेको निर्भरता जाँच गर्नुहोस् |
| CORS त्रुटिहरू | क्रस-ओरिजिन अनुरोधहरूको लागि उचित CORS हेडरहरू कन्फिगर गर्नुहोस् |
| प्रमाणीकरण समस्याहरू | टोकनको वैधता र अनुमतिहरू प्रमाणित गर्नुहोस् |

## स्थानीय विकास

स्थानीय विकास र परीक्षणको लागि, तपाईं आफ्नो मेसिनमा MCP सर्भरहरू चलाउन सक्नुहुन्छ:

1. **सर्भर प्रक्रिया सुरु गर्नुहोस्**: आफ्नो MCP सर्भर एप्लिकेसन चलाउनुहोस्
2. **नेटवर्किङ कन्फिगर गर्नुहोस्**: सर्भर अपेक्षित पोर्टमा पहुँचयोग्य छ सुनिश्चित गर्नुहोस्
3. **क्लाइन्टहरू जडान गर्नुहोस्**: `http://localhost:3000` जस्ता स्थानीय जडान URL हरू प्रयोग गर्नुहोस्

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## तपाईंको पहिलो MCP सर्भर निर्माण गर्दै

हामीले [मुख्य अवधारणाहरू](/01-CoreConcepts/README.md) अघिल्लो पाठमा कभर गरेका छौं, अब त्यो ज्ञानलाई काममा लगाउने समय हो।

### सर्भरले के गर्न सक्छ

कोड लेख्न सुरु गर्नु अघि, सर्भरले के गर्न सक्छ भन्ने कुरा सम्झौं:

MCP सर्भरले उदाहरणका लागि:

- स्थानीय फाइलहरू र डेटाबेसहरू पहुँच गर्न सक्छ
- रिमोट API हरूसँग जडान गर्न सक्छ
- गणनाहरू गर्न सक्छ
- अन्य उपकरणहरू र सेवाहरूको साथ एकीकृत गर्न सक्छ
- अन्तरक्रियाको लागि प्रयोगकर्ता इन्टरफेस प्रदान गर्न सक्छ

ठीक छ, अब हामीलाई थाहा छ कि यसले के गर्न सक्छ, कोडिङ सुरु गरौं।

## अभ्यास: सर्भर सिर्जना गर्दै

सर्भर सिर्जना गर्न, तपाईंले यी चरणहरू पालना गर्नुपर्छ:

- MCP SDK स्थापना गर्नुहोस्।
- परियोजना सिर्जना गर्नुहोस् र परियोजना संरचना सेटअप गर्नुहोस्।
- सर्भर कोड लेख्नुहोस्।
- सर्भर परीक्षण गर्नुहोस्।

### -1- परियोजना सिर्जना गर्नुहोस्

#### TypeScript

```sh
# Create project directory and initialize npm project
mkdir calculator-server
cd calculator-server
npm init -y
```

#### Python

```sh
# Create project dir
mkdir calculator-server
cd calculator-server
# Open the folder in Visual Studio Code - Skip this if you are using a different IDE
code .
```

#### .NET

```sh
dotnet new console -n McpCalculatorServer
cd McpCalculatorServer
```

#### Java

Java को लागि, Spring Boot परियोजना सिर्जना गर्नुहोस्:

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

Zip फाइल निकाल्नुहोस्:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

तपाईंको *pom.xml* फाइलमा निम्न पूर्ण कन्फिगरेसन थप्नुहोस्:

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

#### Rust

```sh
mkdir calculator-server
cd calculator-server
cargo init
```

### -2- निर्भरता थप्नुहोस्

अब तपाईंको परियोजना सिर्जना भएको छ, अब निर्भरता थप्ने समय हो:

#### TypeScript

```sh
# If not already installed, install TypeScript globally
npm install typescript -g

# Install the MCP SDK and Zod for schema validation
npm install @modelcontextprotocol/sdk zod
npm install -D @types/node typescript
```

#### Python

```sh
# Create a virtual env and install dependencies
python -m venv venv
venv\Scripts\activate
pip install "mcp[cli]"
```

#### Java

```bash
cd calculator-server
./mvnw clean install -DskipTests
```

#### Rust

```sh
cargo add rmcp --features server,transport-io
cargo add serde
cargo add tokio --features rt-multi-thread
```

### -3- परियोजना फाइलहरू सिर्जना गर्नुहोस्

#### TypeScript

*package.json* फाइल खोल्नुहोस् र निम्न सामग्रीसँग प्रतिस्थापन गर्नुहोस् ताकि तपाईं सर्भर निर्माण र चलाउन सक्नुहुन्छ:

```json
{
  "name": "calculator-server",
  "version": "1.0.0",
  "main": "index.js",
  "type": "module",
  "scripts": {
    "start": "tsc && node ./build/index.js",
    "build": "tsc && node ./build/index.js"
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "description": "A simple calculator server using Model Context Protocol",
  "dependencies": {
    "@modelcontextprotocol/sdk": "^1.16.0",
    "zod": "^3.25.76"
  },
  "devDependencies": {
    "@types/node": "^24.0.14",
    "typescript": "^5.8.3"
  }
}
```

*tsconfig.json* फाइल निम्न सामग्रीसँग सिर्जना गर्नुहोस्:

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

तपाईंको स्रोत कोडको लागि एक डाइरेक्टरी सिर्जना गर्नुहोस्:

```sh
mkdir src
touch src/index.ts
```

#### Python

*server.py* फाइल सिर्जना गर्नुहोस्

```sh
touch server.py
```

#### .NET

आवश्यक NuGet प्याकेजहरू स्थापना गर्नुहोस्:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

#### Java

Java Spring Boot परियोजनाहरूको लागि, परियोजना संरचना स्वचालित रूपमा सिर्जना हुन्छ।

#### Rust

Rust को लागि, *src/main.rs* फाइल `cargo init` चलाउँदा स्वतः सिर्जना हुन्छ। फाइल खोल्नुहोस् र डिफल्ट कोड मेटाउनुहोस्।

### -4- सर्भर कोड सिर्जना गर्नुहोस्

#### TypeScript

*index.ts* फाइल सिर्जना गर्नुहोस् र निम्न कोड थप्नुहोस्:

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
 
// Create an MCP server
const server = new McpServer({
  name: "Calculator MCP Server",
  version: "1.0.0"
});
```

अब तपाईंको सर्भर छ, तर यसले धेरै काम गर्दैन, यसलाई सुधारौं।

#### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")
```

#### .NET

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

#### Java

Java को लागि, मुख्य सर्भर कम्पोनेन्टहरू सिर्जना गर्नुहोस्। पहिलो, मुख्य एप्लिकेसन कक्षामा संशोधन गर्नुहोस्:

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

क्यालकुलेटर सेवा सिर्जना गर्नुहोस् *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**उत्पादन-तयार सेवाको लागि वैकल्पिक कम्पोनेन्टहरू:**

स्टार्टअप कन्फिगरेसन सिर्जना गर्नुहोस् *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

स्वास्थ्य नियन्त्रणकर्ता सिर्जना गर्नुहोस् *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

अपवाद ह्यान्डलर सिर्जना गर्नुहोस् *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

कस्टम ब्यानर सिर्जना गर्नुहोस् *src/main/resources/banner.txt*:

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

#### Rust

*src/main.rs* फाइलको शीर्षमा निम्न कोड थप्नुहोस्। यसले तपाईंको MCP सर्भरका लागि आवश्यक पुस्तकालयहरू र मोड्युलहरू आयात गर्दछ।

```rust
use rmcp::{
    handler::server::{router::tool::ToolRouter, tool::Parameters},
    model::{ServerCapabilities, ServerInfo},
    schemars, tool, tool_handler, tool_router,
    transport::stdio,
    ServerHandler, ServiceExt,
};
use std::error::Error;
```

क्यालकुलेटर अनुरोध प्रतिनिधित्व गर्न एक struct सिर्जना गरौं।

```rust
#[derive(Debug, serde::Deserialize, schemars::JsonSchema)]
pub struct CalculatorRequest {
    pub a: f64,
    pub b: f64,
}
```

अब, क्यालकुलेटर सर्भर प्रतिनिधित्व गर्न एक struct सिर्जना गरौं। यो struct ले उपकरण राउटर समावेश गर्दछ, जुन उपकरणहरू दर्ता गर्न प्रयोग गरिन्छ।

```rust
#[derive(Debug, Clone)]
pub struct Calculator {
    tool_router: ToolRouter<Self>,
}
```

अब, हामी `Calculator` struct कार्यान्वयन गर्न सक्छौं ताकि नयाँ सर्भर उदाहरण सिर्जना गर्न र सर्भर जानकारी प्रदान गर्न सर्भर ह्यान्डलर कार्यान्वयन गर्न सकिन्छ।

```rust
#[tool_router]
impl Calculator {
    pub fn new() -> Self {
        Self {
            tool_router: Self::tool_router(),
        }
    }
}

#[tool_handler]
impl ServerHandler for Calculator {
    fn get_info(&self) -> ServerInfo {
        ServerInfo {
            instructions: Some("A simple calculator tool".into()),
            capabilities: ServerCapabilities::builder().enable_tools().build(),
            ..Default::default()
        }
    }
}
```

अन्ततः, हामीले सर्भर सुरु गर्न मुख्य कार्यान्वयन गर्न आवश्यक छ। यो कार्यले `Calculator` struct को एक उदाहरण सिर्जना गर्नेछ र यसलाई मानक इनपुट/आउटपुटमा सेवा दिनेछ।

```rust
#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let service = Calculator::new().serve(stdio()).await?;
    service.waiting().await?;
    Ok(())
}
```

अब सर्भर आधारभूत जानकारी प्रदान गर्न सेटअप गरिएको छ। अब, हामीले थप उपकरण थप्नुपर्छ।

### -5- उपकरण र स्रोत थप्दै

उपकरण र स्रोत थप्न निम्न कोड थप्नुहोस्:

#### TypeScript

```typescript
server.tool(
  "add",
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

तपाईंको उपकरणले `a` र `b` प्यारामिटरहरू लिन्छ र एउटा फङ्क्शन चलाउँछ जसले निम्न प्रकारको प्रतिक्रिया उत्पादन गर्दछ:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

तपाईंको स्रोत `greeting` स्ट्रिङ मार्फत पहुँच गरिन्छ र `name` प्यारामिटर लिन्छ र उपकरणसँग मिल्दोजुल्दो प्रतिक्रिया उत्पादन गर्दछ:

```typescript
{
  uri: "<href>",
  text: "a text"
}
```

#### Python

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

माथिको कोडमा हामीले:

- `add` नामक उपकरण परिभाषित गरेका छौं जसले `a` र `p` प्यारामिटरहरू लिन्छ, दुवै पूर्णांक।
- `greeting` नामक स्रोत सिर्जना गरेका छौं जसले `name` प्यारामिटर लिन्छ।

#### .NET

तपाईंको Program.cs फाइलमा यो थप्नुहोस्:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

#### Java

उपकरणहरू पहिले नै अघिल्लो चरणमा सिर्जना गरिएको छ।

#### Rust

`impl Calculator` ब्लक भित्र नयाँ उपकरण थप्नुहोस्:

```rust
#[tool(description = "Adds a and b")]
async fn add(
    &self,
    Parameters(CalculatorRequest { a, b }): Parameters<CalculatorRequest>,
) -> String {
    (a + b).to_string()
}
```

### -6- अन्तिम कोड

अब सर्भर सुरु गर्न आवश्यक अन्तिम कोड थपौं:

#### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

पूरा कोड यहाँ छ:

```typescript
// index.ts
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Calculator MCP Server",
  version: "1.0.0"
});

// Add an addition tool
server.tool(
  "add",
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
server.connect(transport);
```

#### Python

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

#### .NET

Program.cs फाइल निम्न सामग्रीसँग सिर्जना गर्नुहोस्:

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

#### Java

तपाईंको मुख्य एप्लिकेसन कक्षा पूर्ण रूपमा यस प्रकार देखिनुपर्छ:

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

#### Rust

Rust सर्भरको अन्तिम कोड यस प्रकार देखिनुपर्छ:

```rust
use rmcp::{
    ServerHandler, ServiceExt,
    handler::server::{router::tool::ToolRouter, tool::Parameters},
    model::{ServerCapabilities, ServerInfo},
    schemars, tool, tool_handler, tool_router,
    transport::stdio,
};
use std::error::Error;

#[derive(Debug, serde::Deserialize, schemars::JsonSchema)]
pub struct CalculatorRequest {
    pub a: f64,
    pub b: f64,
}

#[derive(Debug, Clone)]
pub struct Calculator {
    tool_router: ToolRouter<Self>,
}

#[tool_router]
impl Calculator {
    pub fn new() -> Self {
        Self {
            tool_router: Self::tool_router(),
        }
    }
    
    #[tool(description = "Adds a and b")]
    async fn add(
        &self,
        Parameters(CalculatorRequest { a, b }): Parameters<CalculatorRequest>,
    ) -> String {
        (a + b).to_string()
    }
}

#[tool_handler]
impl ServerHandler for Calculator {
    fn get_info(&self) -> ServerInfo {
        ServerInfo {
            instructions: Some("A simple calculator tool".into()),
            capabilities: ServerCapabilities::builder().enable_tools().build(),
            ..Default::default()
        }
    }
}

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let service = Calculator::new().serve(stdio()).await?;
    service.waiting().await?;
    Ok(())
}
```

### -7- सर्भर परीक्षण गर्नुहोस्

सर्भर निम्न कमाण्ड प्रयोग गरेर सुरु गर्नुहोस्:

#### TypeScript

```sh
npm run build
```

#### Python

```sh
mcp run server.py
```

> MCP Inspector प्रयोग गर्न, `mcp dev server.py` प्रयोग गर्नुहोस् जसले स्वचालित रूपमा Inspector सुरु गर्छ र आवश्यक प्रोक्सी सेसन टोकन प्रदान गर्दछ। यदि `mcp run server.py` प्रयोग गर्दै हुनुहुन्छ भने, तपाईंले Inspector म्यानुअली सुरु गर्न र जडान कन्फिगर गर्न आवश्यक छ।

#### .NET

तपाईंको परियोजना डाइरेक्टरीमा सुनिश्चित गर्नुहोस्:

```sh
cd McpCalculatorServer
dotnet run
```

#### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### Rust

सर्भरलाई फर्म्याट र चलाउन निम्न कमाण्डहरू चलाउनुहोस्:

```sh
cargo fmt
cargo run
```

### -8- Inspector प्रयोग गरेर चलाउनुहोस्

Inspector एक उत्कृष्ट उपकरण हो जसले तपाईंको सर्भर सुरु गर्न सक्छ र तपाईंलाई यससँग अन्तरक्रिया गर्न अनुमति दिन्छ ताकि तपाईं परीक्षण गर्न सक्नुहुन्छ कि यो काम गर्छ। यसलाई सुरु गरौं:

> [!NOTE]
> "कमाण्ड" क्षेत्रमा यो फरक देखिन सक्छ किनकि यसमा तपाईंको विशिष्ट रनटाइमको साथ सर्भर चलाउनको लागि कमाण्ड समावेश छ।

#### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

वा यसलाई तपाईंको *package.json* मा यस प्रकार थप्नुहोस्: `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` र त्यसपछि `npm run inspector` चलाउनुहोस्।

Python ले Node.js उपकरणलाई "inspector" नामक उपकरणमा र्याप गर्दछ। यो उपकरण यस प्रकार कल गर्न सम्भव छ:

```sh
mcp dev server.py
```

तर, यसले उपकरणमा उपलब्ध सबै विधिहरू कार्यान्वयन गर्दैन त्यसैले तपाईंलाई तलको Node.js उपकरण सिधै चलाउन सिफारिस गरिन्छ:

```sh
npx @modelcontextprotocol/inspector mcp run server.py
```

यदि तपाईं उपकरण वा IDE प्रयोग गर्दै हुनुहुन्छ जसले स्क्रिप्टहरू चलाउनका लागि कमाण्ड र तर्कहरू कन्फिगर गर्न अनुमति दिन्छ, 
`python` लाई `Command` क्षेत्रमा सेट गर्नुहोस् र `server.py` लाई `Arguments` को रूपमा। यसले स्क्रिप्ट सही रूपमा चल्छ भन्ने सुनिश्चित गर्दछ।

#### .NET

तपाईंको परियोजना डाइरेक्टरीमा सुनिश्चित गर्नुहोस्:

@@
![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.ne.png)

**तपाईं अब सर्भरमा जडान हुनुभयो**  
**जाभा सर्भर परीक्षण खण्ड अब पूरा भयो**

अर्को खण्ड सर्भरसँग अन्तरक्रिया गर्ने बारेमा छ।

तपाईंले निम्न प्रयोगकर्ता इन्टरफेस देख्नु पर्नेछ:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ne.png)

1. "Connect" बटन चयन गरेर सर्भरमा जडान गर्नुहोस्।  
   सर्भरमा जडान भएपछि, तपाईंले अब निम्न देख्नु पर्नेछ:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ne.png)

2. "Tools" र "listTools" चयन गर्नुहोस्। तपाईंले "Add" देख्नु पर्नेछ। "Add" चयन गर्नुहोस् र प्यारामिटर मानहरू भर्नुहोस्।  

   तपाईंले निम्न प्रतिक्रिया देख्नु पर्नेछ, अर्थात् "add" उपकरणको परिणाम:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ne.png)

बधाई छ, तपाईंले आफ्नो पहिलो सर्भर सिर्जना र चलाउन सफल हुनुभयो!

#### Rust

MCP Inspector CLI प्रयोग गरेर Rust सर्भर चलाउन, निम्न आदेश प्रयोग गर्नुहोस्:

```sh
npx @modelcontextprotocol/inspector cargo run --cli --method tools/call --tool-name add --tool-arg a=1 b=2
```

### आधिकारिक SDKs

MCP ले विभिन्न भाषाहरूका लागि आधिकारिक SDKs प्रदान गर्दछ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - माइक्रोसफ्टसँगको सहकार्यमा व्यवस्थापन गरिएको
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सँगको सहकार्यमा व्यवस्थापन गरिएको
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript कार्यान्वयन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python कार्यान्वयन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin कार्यान्वयन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सँगको सहकार्यमा व्यवस्थापन गरिएको
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust कार्यान्वयन

## मुख्य बुँदाहरू

- MCP विकास वातावरण सेटअप गर्नु भाषासँग सम्बन्धित SDKs को साथमा सजिलो छ।  
- MCP सर्भरहरू निर्माण गर्दा स्पष्ट स्किमासहित उपकरणहरू सिर्जना र दर्ता गर्नुपर्छ।  
- परीक्षण र डिबगिङ विश्वसनीय MCP कार्यान्वयनहरूको लागि अत्यावश्यक छ।  

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)  

## कार्य

आफ्नो रोजाइको उपकरणको साथमा एउटा साधारण MCP सर्भर सिर्जना गर्नुहोस्:

1. आफ्नो मनपर्ने भाषामा (जस्तै .NET, Java, Python, TypeScript, वा Rust) उपकरण कार्यान्वयन गर्नुहोस्।  
2. इनपुट प्यारामिटरहरू र रिटर्न मानहरू परिभाषित गर्नुहोस्।  
3. सर्भरले अपेक्षित रूपमा काम गरिरहेको सुनिश्चित गर्न इन्स्पेक्टर उपकरण चलाउनुहोस्।  
4. विभिन्न इनपुटहरूसँग कार्यान्वयन परीक्षण गर्नुहोस्।  

## समाधान

[Solution](./solution/README.md)

## थप स्रोतहरू

- [Azure मा Model Context Protocol प्रयोग गरेर एजेन्टहरू निर्माण गर्नुहोस्](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps (Node.js/TypeScript/JavaScript) सँग रिमोट MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## अब के गर्ने

अर्को: [MCP Clients सँग सुरु गर्नुहोस्](../02-client/README.md)  

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छ। यसको मूल भाषा मा रहेको मूल दस्तावेज़लाई आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुने छैनौं।