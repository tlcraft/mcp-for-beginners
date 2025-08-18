<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ee93d6093964ea579dbdc20b4d643e9b",
  "translation_date": "2025-08-18T18:52:28+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "my"
}
-->
# MCP စတင်အသုံးပြုခြင်း

Model Context Protocol (MCP) နှင့် စတင်လေ့လာရန် ကြိုဆိုပါတယ်! MCP အသစ်စက်စက်ဖြစ်စေ၊ သင်၏ နားလည်မှုကို ပိုမိုတိုးတက်စေလိုဖြစ်စေ၊ ဤလမ်းညွှန်သည် အရေးကြီးသော စတင်တပ်ဆင်ခြင်းနှင့် ဖွံ့ဖြိုးတိုးတက်မှု လုပ်ငန်းစဉ်ကို လမ်းပြပေးပါမည်။ MCP သည် AI မော်ဒယ်များနှင့် အက်ပ်လီကေးရှင်းများအကြား အဆင်ပြေစွာ ပေါင်းစည်းမှုကို မည်သို့ အလွယ်တကူဖြစ်စေသည်ကို ရှာဖွေတွေ့ရှိပြီး MCP အခြေခံဖြေရှင်းချက်များကို တည်ဆောက်ခြင်းနှင့် စမ်းသပ်ရန် သင့်ပတ်ဝန်းကျင်ကို အဆင်သင့်ဖြစ်စေရန် မည်သို့ ပြင်ဆင်ရမည်ကို သင်လေ့လာနိုင်ပါမည်။

> TLDR; သင်သည် AI အက်ပ်များကို တည်ဆောက်နေပါက LLM (large language model) ကို ပိုမိုကျွမ်းကျင်စေရန် အထောက်အကူပေးသော ကိရိယာများနှင့် အရင်းအမြစ်များကို ထည့်သွင်းနိုင်သည်ကို သိပြီးဖြစ်မည်။ သို့သော် ထိုကိရိယာများနှင့် အရင်းအမြစ်များကို server ပေါ်တွင်ထားပါက အက်ပ်နှင့် server ၏ စွမ်းရည်များကို LLM ရှိ/မရှိ သော client မည်သူမဆို အသုံးပြုနိုင်ပါသည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာတွင် MCP ပတ်ဝန်းကျင်များကို တပ်ဆင်ခြင်းနှင့် သင့်ရဲ့ ပထမဆုံး MCP အက်ပ်လီကေးရှင်းများကို တည်ဆောက်ခြင်းအတွက် လက်တွေ့လမ်းညွှန်ချက်များကို ပေးထားသည်။ သင်သည် လိုအပ်သော ကိရိယာများနှင့် ဖရိမ်ဝေါ့များကို တပ်ဆင်ခြင်း၊ အခြေခံ MCP server များကို တည်ဆောက်ခြင်း၊ host applications များကို ဖန်တီးခြင်းနှင့် သင့်အကောင်အထည်ဖော်မှုများကို စမ်းသပ်ခြင်းတို့ကို လေ့လာနိုင်ပါမည်။

Model Context Protocol (MCP) သည် LLM များကို context ပေးရန် အက်ပ်လီကေးရှင်းများအကြား စံပြုလုပ်ပုံကို သတ်မှတ်ထားသော ဖွင့်လှစ်စံသတ်မှတ်ချက်တစ်ခုဖြစ်သည်။ MCP ကို AI အက်ပ်များအတွက် USB-C port တစ်ခုလို ထင်မြင်ပါ - ၎င်းသည် AI မော်ဒယ်များကို အမျိုးမျိုးသော ဒေတာအရင်းအမြစ်များနှင့် ကိရိယာများနှင့် ချိတ်ဆက်ရန် စံပြုနည်းလမ်းတစ်ခုကို ပေးသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးတွင် သင်သည် အောက်ပါအရာများကို ပြုလုပ်နိုင်မည်ဖြစ်သည် -

- C#, Java, Python, TypeScript, နှင့် Rust အတွက် MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်များကို တပ်ဆင်ခြင်း
- အထူးစိတ်ကြိုက်အင်္ဂါရပ်များ (resources, prompts, tools) ပါဝင်သော အခြေခံ MCP server များကို တည်ဆောက်ခြင်းနှင့် deploy ပြုလုပ်ခြင်း
- MCP server များနှင့် ချိတ်ဆက်သော host applications များကို ဖန်တီးခြင်း
- MCP အကောင်အထည်ဖော်မှုများကို စမ်းသပ်ခြင်းနှင့် အမှားပြင်ခြင်း

## MCP ပတ်ဝန်းကျင်ကို တပ်ဆင်ခြင်း

MCP နှင့် အလုပ်လုပ်ရန် မစတင်မီ သင့်ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်ကို ပြင်ဆင်ရန်နှင့် အခြေခံလုပ်ငန်းစဉ်ကို နားလည်ရန် အရေးကြီးသည်။ ဤအပိုင်းတွင် MCP နှင့် အဆင်ပြေစွာ စတင်နိုင်ရန် အစပိုင်းအဆင့်များကို လမ်းညွှန်ပေးပါမည်။

### လိုအပ်ချက်များ

MCP ဖွံ့ဖြိုးတိုးတက်မှုကို စတင်မီ သင်တွင် အောက်ပါအရာများရှိရမည် -

- **ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်**: သင်ရွေးချယ်ထားသော programming language (C#, Java, Python, TypeScript, Rust) အတွက်
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, သို့မဟုတ် မည်သည့် ခေတ်မီ code editor မဆို
- **Package Managers**: NuGet, Maven/Gradle, pip, npm/yarn, Cargo
- **API Keys**: Host applications တွင် အသုံးပြုမည့် AI ဝန်ဆောင်မှုများအတွက်

## အခြေခံ MCP Server ဖွဲ့စည်းပုံ

MCP server တစ်ခုတွင် အောက်ပါအရာများ ပါဝင်လေ့ရှိသည် -

- **Server Configuration**: Port, authentication, နှင့် အခြားဆက်တင်များကို ပြင်ဆင်ခြင်း
- **Resources**: LLM များအတွက် ရရှိနိုင်သော ဒေတာနှင့် context
- **Tools**: မော်ဒယ်များက ခေါ်ယူနိုင်သော လုပ်ဆောင်ချက်များ
- **Prompts**: စာသားများကို ဖန်တီးရန် သို့မဟုတ် ဖွဲ့စည်းရန်အတွက် template များ

TypeScript ဖြင့် ရိုးရှင်းသော ဥပမာတစ်ခု -

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

အထက်ပါ code တွင် -

- MCP TypeScript SDK မှ လိုအပ်သော class များကို import ပြုလုပ်သည်။
- MCP server instance အသစ်တစ်ခုကို ဖန်တီးပြီး ပြင်ဆင်သည်။
- `calculator` ဟုခေါ်သော custom tool တစ်ခုကို handler function ဖြင့် register ပြုလုပ်သည်။
- MCP request များကို လက်ခံရန် server ကို စတင်ပြုလုပ်သည်။

## စမ်းသပ်ခြင်းနှင့် အမှားပြင်ခြင်း

MCP server ကို စမ်းသပ်ရန်မစတင်မီ စမ်းသပ်ရန်ရရှိနိုင်သော ကိရိယာများနှင့် အကောင်းဆုံး လုပ်ဆောင်နည်းများကို နားလည်ရန် အရေးကြီးသည်။ ထိရောက်သော စမ်းသပ်မှုသည် သင့် server ၏ စိတ်မျှော်မှန်းချက်အတိုင်း လုပ်ဆောင်မှုကို သေချာစေပြီး ပြဿနာများကို အလျင်အမြန် ရှာဖွေပြင်ဆင်နိုင်စေသည်။ အောက်ပါအပိုင်းတွင် MCP အကောင်အထည်ဖော်မှုကို အတည်ပြုရန် အကြံပြုထားသော လုပ်ဆောင်နည်းများကို ဖော်ပြထားသည်။

MCP သည် သင့် server များကို စမ်းသပ်ရန်နှင့် အမှားပြင်ရန် ကိရိယာများကို ပေးသည် -

- **Inspector tool**: ဤ graphical interface သည် သင့် server နှင့် ချိတ်ဆက်ပြီး tools, prompts, resources များကို စမ်းသပ်နိုင်စေသည်။
- **curl**: Command line tool တစ်ခုဖြစ်သော curl သို့မဟုတ် HTTP command များကို ဖန်တီးပြီး run ပြုလုပ်နိုင်သော အခြား client များကို အသုံးပြု၍ သင့် server နှင့် ချိတ်ဆက်နိုင်သည်။

### MCP Inspector ကို အသုံးပြုခြင်း

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) သည် သင့်အား အောက်ပါအရာများကို ကူညီပေးသည် -

1. **Server ၏ စွမ်းရည်များကို ရှာဖွေခြင်း**: ရရှိနိုင်သော resources, tools, prompts များကို အလိုအလျောက် ရှာဖွေသည်။
2. **Tool လုပ်ဆောင်မှုကို စမ်းသပ်ခြင်း**: အမျိုးမျိုးသော parameters များကို စမ်းသပ်ပြီး တုံ့ပြန်မှုများကို အချိန်နှင့်တပြေးညီ ကြည့်ရှုနိုင်သည်။
3. **Server Metadata ကို ကြည့်ရှုခြင်း**: Server အချက်အလက်များ, schemas, configurations များကို စစ်ဆေးနိုင်သည်။

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

အထက်ပါ command များကို run ပြုလုပ်သောအခါ MCP Inspector သည် သင့် browser တွင် ဒေသတွင်း web interface တစ်ခုကို ဖွင့်လှစ်မည်ဖြစ်သည်။ Dashboard တွင် MCP server များ, ရရှိနိုင်သော tools, resources, prompts များကို ပြသမည်ဖြစ်သည်။ Interface သည် tool execution ကို interactively စမ်းသပ်ရန်, server metadata ကို စစ်ဆေးရန်, real-time တုံ့ပြန်မှုများကို ကြည့်ရှုရန် အဆင်ပြေစေသည်။ ၎င်းသည် သင့် MCP server အကောင်အထည်ဖော်မှုများကို အတည်ပြုရန်နှင့် အမှားပြင်ရန် ပိုမိုလွယ်ကူစေသည်။

ဤအတိုင်းဖြစ်နိုင်သော interface ၏ screenshot တစ်ခု -

![MCP Inspector server connection](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.my.png)

## အများဆုံးတွေ့ရသော Setup ပြဿနာများနှင့် ဖြေရှင်းနည်းများ

| ပြဿနာ | ဖြစ်နိုင်သော ဖြေရှင်းနည်း |
|-------|-------------------|
| Connection refused | Server run နေမနေကြောင်းနှင့် port မှန်ကန်ကြောင်း စစ်ဆေးပါ |
| Tool execution errors | Parameter validation နှင့် error handling ကို ပြန်လည်စစ်ဆေးပါ |
| Authentication failures | API keys နှင့် permissions ကို အတည်ပြုပါ |
| Schema validation errors | Parameters များသည် သတ်မှတ်ထားသော schema နှင့် ကိုက်ညီကြောင်း သေချာပါ |
| Server not starting | Port conflicts သို့မဟုတ် လိုအပ်သော dependencies မရှိခြင်းကို စစ်ဆေးပါ |
| CORS errors | Cross-origin requests အတွက် CORS headers ကို configure ပြုလုပ်ပါ |
| Authentication issues | Token သက်တမ်းနှင့် permissions ကို အတည်ပြုပါ |

## ဒေသတွင်းဖွံ့ဖြိုးတိုးတက်မှု

ဒေသတွင်းဖွံ့ဖြိုးတိုးတက်မှုနှင့် စမ်းသပ်မှုအတွက် MCP server များကို သင့်စက်ပေါ်တွင် တိုက်ရိုက် run ပြုလုပ်နိုင်သည် -

1. **Server process ကို စတင်ပါ**: သင့် MCP server application ကို run ပြုလုပ်ပါ
2. **Networking ကို configure ပြုလုပ်ပါ**: Server သည် မျှော်မှန်းထားသော port တွင် ရရှိနိုင်ကြောင်း သေချာပါ
3. **Clients များကို ချိတ်ဆက်ပါ**: `http://localhost:3000` ကဲ့သို့သော ဒေသတွင်း connection URLs များကို အသုံးပြုပါ

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## သင့်ပထမဆုံး MCP Server ကို တည်ဆောက်ခြင်း

[Core concepts](/01-CoreConcepts/README.md) ကို ယခင်သင်ခန်းစာတွင် ဖော်ပြခဲ့ပြီးဖြစ်သည်။ ယခု၌ ဤအတန်းများကို လက်တွေ့အသုံးချပါမည်။

### Server တစ်ခုက ဘာလုပ်နိုင်သလဲ

Code ရေးမစတင်မီ Server တစ်ခုက ဘာလုပ်နိုင်သလဲကို သတိရပါစို့ -

MCP server တစ်ခုသည် ဥပမာအားဖြင့် -

- ဒေသတွင်း ဖိုင်များနှင့် ဒေတာဘေ့စ်များကို ရယူနိုင်သည်
- အဝေးမှ APIs များနှင့် ချိတ်ဆက်နိုင်သည်
- တွက်ချက်မှုများကို ဆောင်ရွက်နိုင်သည်
- အခြားကိရိယာများနှင့် ဝန်ဆောင်မှုများနှင့် ပေါင်းစည်းနိုင်သည်
- အသုံးပြုသူနှင့် အပြန်အလှန်ဆက်သွယ်ရန် user interface ကို ပေးနိုင်သည်

ကောင်းပြီ၊ ယခု၌ ဤအရာများကို လုပ်ဆောင်နိုင်ရန် Code ရေးစတင်ကြပါစို့။

## လေ့ကျင့်ခန်း: Server တစ်ခု ဖန်တီးခြင်း

Server တစ်ခု ဖန်တီးရန် အောက်ပါအဆင့်များကို လိုက်နာရမည် -

- MCP SDK ကို တပ်ဆင်ပါ။
- Project တစ်ခု ဖန်တီးပြီး Project ဖွဲ့စည်းပုံကို ပြင်ဆင်ပါ။
- Server Code ကို ရေးပါ။
- Server ကို စမ်းသပ်ပါ။

### -1- Project ဖန်တီးခြင်း

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

Java အတွက် Spring Boot project တစ်ခု ဖန်တီးပါ -

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

Zip ဖိုင်ကို ဖြုတ်ပါ -

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

pom.xml ဖိုင်တွင် အောက်ပါ configuration အပြည့်အစုံကို ထည့်ပါ -

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

### -2- Dependencies ထည့်သွင်းခြင်း

Project ဖန်တီးပြီးပါက Dependencies များကို ထည့်သွင်းပါ -

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

### -3- Project ဖိုင်များ ဖန်တီးခြင်း

#### TypeScript

*package.json* ဖိုင်ကို ဖွင့်ပြီး Server ကို build နှင့် run ပြုလုပ်နိုင်ရန် အောက်ပါအတိုင်း အကြောင်းအရာကို အစားထိုးပါ -

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

*tsconfig.json* ဖိုင်တစ်ခု ဖန်တီးပြီး အောက်ပါအကြောင်းအရာကို ထည့်ပါ -

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

သင့် source code အတွက် directory တစ်ခု ဖန်တီးပါ -

```sh
mkdir src
touch src/index.ts
```

#### Python

*server.py* ဖိုင်တစ်ခု ဖန်တီးပါ -

```sh
touch server.py
```

#### .NET

လိုအပ်သော NuGet packages များကို တပ်ဆင်ပါ -

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

#### Java

Java Spring Boot projects အတွက် Project ဖွဲ့စည်းပုံကို အလိုအလျောက် ဖန်တီးထားသည်။

#### Rust

Rust အတွက် `cargo init` ကို run ပြုလုပ်သောအခါ *src/main.rs* ဖိုင်တစ်ခုကို အလိုအလျောက် ဖန်တီးထားသည်။ ဖိုင်ကို ဖွင့်ပြီး default code ကို ဖျက်ပါ။

### -4- Server Code ရေးခြင်း

#### TypeScript

*index.ts* ဖိုင်တစ်ခု ဖန်တီးပြီး အောက်ပါ code ကို ထည့်ပါ -

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

ယခု သင့်တွင် Server တစ်ခု ရှိပြီးဖြစ်သည်၊ သို့သော် ၎င်းသည် အများကြီး မလုပ်ဆောင်နိုင်သေးပါ၊ ၎င်းကို ပြင်ဆင်ကြစို့။

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

Java အတွက် Main Application Class ကို ပြင်ဆင်ပါ -

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

Calculator Service ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**Production-ready Service အတွက် အပို Components:**

Startup Configuration ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

Health Controller ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

Exception Handler ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

Custom Banner ကို ဖန်တီးပါ *src/main/resources/banner.txt*:

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

*src/main.rs* ဖိုင်၏ အပေါ်ပိုင်းတွင် အောက်ပါ code ကို ထည့်ပါ။ ၎င်းသည် MCP server အတွက် လိုအပ်သော libraries နှင့် modules များကို import ပြုလုပ်သည်။

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

Calculator Request ကို ကိုယ်စားပြုသော struct တစ်ခု ဖန်တီးပါ။

```rust
#[derive(Debug, serde::Deserialize, schemars::JsonSchema)]
pub struct CalculatorRequest {
    pub a: f64,
    pub b: f64,
}
```

Calculator Server ကို ကိုယ်စားပြု struct တစ်ခု ဖန်တီးပါ။ ၎င်းသည် tool router ကို ထိန်းသိမ်းထားပြီး tools များကို register ပြုလုပ်ရန် အသုံးပြုသည်။

```rust
#[derive(Debug, Clone)]
pub struct Calculator {
    tool_router: ToolRouter<Self>,
}
```

`Calculator` struct ကို အသစ်တစ်ခု ဖန်တီးရန်နှင့် Server ၏ အချက်အလက်များကို ပေးရန် Server Handler ကို အကောင်အထည်ဖော်ပါ။

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

နောက်ဆုံးတွင် Server ကို စတင်ရန် Main Function ကို အကောင်အထည်ဖော်ပါ။ ၎င်းသည် `Calculator` struct ၏ instance တစ်ခုကို ဖန်တီးပြီး standard input/output မှတစ်ဆင့် ၎င်းကို serve ပြုလုပ်သည်။

```rust
#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let service = Calculator::new().serve(stdio()).await?;
    service.waiting().await?;
    Ok(())
}
```

ယခု Server သည် ၎င်း၏ အခြေခံအချက်အလက်များကို ပေးနိုင်ရန် ပြင်ဆင်ပြီးဖြစ်သည်။ ယခု၌ Addition ပြ
![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.my.png)

**သင်သည် server နှင့် ချိတ်ဆက်ပြီးဖြစ်ပါပြီ**  
**Java server စမ်းသပ်မှုအပိုင်းကို အပြီးသတ်လိုက်ပါပြီ**

နောက်အပိုင်းမှာတော့ server နှင့် အပြန်အလှန်လုပ်ဆောင်မှုအကြောင်းဖြစ်ပါမည်။

သင်သည် အောက်ပါ user interface ကိုတွေ့ရမည်ဖြစ်သည်။

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.my.png)

1. **Connect** ခလုတ်ကိုနှိပ်၍ server နှင့် ချိတ်ဆက်ပါ  
   Server နှင့် ချိတ်ဆက်ပြီးပါက အောက်ပါအတိုင်း တွေ့ရမည်ဖြစ်သည်။

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.my.png)

2. **"Tools"** နှင့် **"listTools"** ကိုရွေးချယ်ပါ၊ **"Add"** ပေါ်လာသင့်ပြီး၊ **"Add"** ကိုရွေးချယ်ပြီး parameter အတန်များကို ဖြည့်ပါ။

   သင်သည် အောက်ပါအဖြေကို တွေ့ရမည်၊ အတိအကျဆိုပါက **"add"** tool မှရရှိသော ရလဒ်ဖြစ်သည်။

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.my.png)

အောင်မြင်ပါတယ်၊ သင်သည် သင့်ရဲ့ ပထမဆုံး server ကို ဖန်တီးပြီး အောင်မြင်စွာ လည်ပတ်စေလိုက်ပါပြီ!

#### Rust

MCP Inspector CLI ဖြင့် Rust server ကို လည်ပတ်စေလိုပါက အောက်ပါ command ကို အသုံးပြုပါ-

```sh
npx @modelcontextprotocol/inspector cargo run --cli --method tools/call --tool-name add --tool-arg a=1 b=2
```

### တရားဝင် SDK များ

MCP သည် ဘာသာစကားအမျိုးမျိုးအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးထားပါသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript အကောင်အထည်  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python အကောင်အထည်  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin အကောင်အထည်  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust အကောင်အထည်  

## အဓိက အချက်များ

- MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်ကို ဘာသာစကားအလိုက် SDK များဖြင့် လွယ်ကူစွာ တပ်ဆင်နိုင်သည်  
- MCP server များကို ဖန်တီးရန် tool များကို ရှင်းလင်းသော schema များဖြင့် ဖန်တီးပြီး မှတ်ပုံတင်ရမည်  
- MCP အကောင်အထည်များကို ယုံကြည်စိတ်ချစေရန် စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းများ အရေးကြီးသည်  

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)  

## လုပ်ငန်းတာဝန်

သင့်စိတ်ကြိုက် tool တစ်ခုဖြင့် ရိုးရှင်းသော MCP server တစ်ခု ဖန်တီးပါ-

1. သင့်နှစ်သက်သော ဘာသာစကား (.NET, Java, Python, TypeScript, သို့မဟုတ် Rust) ဖြင့် tool ကို အကောင်အထည်ဖော်ပါ။  
2. Input parameter များနှင့် return value များကို သတ်မှတ်ပါ။  
3. Inspector tool ကို အသုံးပြု၍ server သည် သတ်မှတ်ထားသည့်အတိုင်း လည်ပတ်နေကြောင်း သေချာပါစေ။  
4. အမျိုးမျိုးသော input များဖြင့် စမ်းသပ်ပါ။  

## ဖြေရှင်းချက်

[Solution](./solution/README.md)

## ထပ်မံလေ့လာရန် အရင်းအမြစ်များ

- [Azure ပေါ်တွင် Model Context Protocol အသုံးပြု၍ Agent များ ဖန်တီးခြင်း](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps (Node.js/TypeScript/JavaScript) ဖြင့် Remote MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## နောက်တစ်ဆင့်

နောက်တစ်ဆင့်: [MCP Clients ဖြင့် စတင်ခြင်း](../02-client/README.md)  

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်ပါ။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ်ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။