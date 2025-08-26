<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ee93d6093964ea579dbdc20b4d643e9b",
  "translation_date": "2025-08-19T18:50:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "my"
}
-->
# MCP စတင်အသုံးပြုခြင်း

Model Context Protocol (MCP) နှင့် ပထမဆုံးအဆင့်များကို ကြိုဆိုပါတယ်! MCP ကို အသစ်စတင်လေ့လာနေသူဖြစ်စေ၊ နက်နက်ရှိုင်းရှိုင်းနားလည်လိုသူဖြစ်စေ၊ ဒီလမ်းညွှန်စာအုပ်က အရေးကြီးသော စနစ်တပ်ဆင်ခြင်းနှင့် ဖွံ့ဖြိုးတိုးတက်မှု လုပ်ငန်းစဉ်ကို လမ်းပြပေးပါမယ်။ MCP က AI မော်ဒယ်များနှင့် အက်ပလီကေးရှင်းများအကြား အဆင်ပြေစွာ ပေါင်းစည်းမှုကို ဘယ်လိုဖြစ်စေမလဲဆိုတာကို ရှာဖွေတွေ့ရှိနိုင်ပြီး MCP-powered ဖြေရှင်းချက်များကို တည်ဆောက်ခြင်းနှင့် စမ်းသပ်ခြင်းအတွက် သင့်ပတ်ဝန်းကျင်ကို အလျင်အမြန် ပြင်ဆင်နိုင်မယ့်နည်းလမ်းကိုလည်း သင်ယူနိုင်ပါမယ်။

> TLDR; AI အက်ပလီကေးရှင်းများကို တည်ဆောက်တဲ့သူဆိုရင် LLM (large language model) ကို ပိုမိုကျွမ်းကျင်စေဖို့ tools နဲ့ အခြားအရင်းအမြစ်များကို ထည့်သွင်းနိုင်တယ်ဆိုတာ သိပြီးသားဖြစ်မယ်။ ဒါပေမယ့် အဲဒီ tools နဲ့ အရင်းအမြစ်တွေကို server ပေါ်မှာထားလိုက်ရင် အက်ပလီကေးရှင်းနဲ့ server ရဲ့ စွမ်းရည်တွေကို LLM ရှိ/မရှိ client မည်သူမဆို အသုံးပြုနိုင်ပါတယ်။

## အကျဉ်းချုပ်

ဒီသင်ခန်းစာက MCP ပတ်ဝန်းကျင်များကို စနစ်တကျတပ်ဆင်ခြင်းနှင့် MCP အက်ပလီကေးရှင်းများကို ပထမဆုံးတည်ဆောက်ခြင်းအတွက် လက်တွေ့လမ်းညွှန်ချက်များပေးပါမယ်။ သင်လိုအပ်တဲ့ tools နဲ့ frameworks တွေကို စနစ်တကျတပ်ဆင်ခြင်း၊ အခြေခံ MCP servers တည်ဆောက်ခြင်း၊ host applications ဖန်တီးခြင်း၊ နဲ့ သင့် implementation များကို စမ်းသပ်ခြင်းတို့ကို သင်ယူနိုင်ပါမယ်။

Model Context Protocol (MCP) က LLM များကို context ပေးတဲ့ နည်းလမ်းကို စံပြအဖြစ် သတ်မှတ်ပေးတဲ့ open protocol တစ်ခုဖြစ်ပါတယ်။ MCP ကို AI အက်ပလီကေးရှင်းများအတွက် USB-C port တစ်ခုလို ထင်မြင်နိုင်ပါတယ် - ဒါက AI မော်ဒယ်များကို အမျိုးမျိုးသော ဒေတာအရင်းအမြစ်များနှင့် tools များကို ချိတ်ဆက်ဖို့ စံပြနည်းလမ်းပေးပါတယ်။

## သင်ယူရမယ့်ရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးမှာ သင်တတ်မြောက်ထားမယ့်အရာများမှာ:

- C#, Java, Python, TypeScript, နဲ့ Rust တွင် MCP အတွက် ဖွံ့ဖြိုးတိုးတက်မှု ပတ်ဝန်းကျင်များကို တပ်ဆင်ခြင်း
- အထူးစွမ်းဆောင်ရည်များ (resources, prompts, tools) ပါဝင်တဲ့ အခြေခံ MCP servers တည်ဆောက်ခြင်းနှင့် deploy လုပ်ခြင်း
- MCP servers တွေကို ချိတ်ဆက်တဲ့ host applications ဖန်တီးခြင်း
- MCP implementations များကို စမ်းသပ်ခြင်းနှင့် debugging လုပ်ခြင်း

## MCP ပတ်ဝန်းကျင်ကို တပ်ဆင်ခြင်း

MCP ကို စတင်လုပ်ဆောင်မီ သင့်ဖွံ့ဖြိုးတိုးတက်မှု ပတ်ဝန်းကျင်ကို ပြင်ဆင်ပြီး workflow အခြေခံကို နားလည်ထားဖို့ အရေးကြီးပါတယ်။ ဒီအပိုင်းက MCP ကို စတင်အသုံးပြုဖို့ smooth ဖြစ်စေမယ့် အစပျိုးအဆင့်များကို လမ်းပြပေးပါမယ်။

### လိုအပ်ချက်များ

MCP ဖွံ့ဖြိုးတိုးတက်မှုကို စတင်မီ သင့်မှာ အောက်ပါအရာများရှိရပါမယ်:

- **ဖွံ့ဖြိုးတိုးတက်မှု ပတ်ဝန်းကျင်**: သင့်ရွေးချယ်ထားတဲ့ programming language (C#, Java, Python, TypeScript, Rust) အတွက်
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, ဒါမှမဟုတ် မည်သည့် modern code editor မဆို
- **Package Managers**: NuGet, Maven/Gradle, pip, npm/yarn, ဒါမှမဟုတ် Cargo
- **API Keys**: Host applications တွေမှာ အသုံးပြုမယ့် AI services အတွက်

## အခြေခံ MCP Server ဖွဲ့စည်းပုံ

MCP server တစ်ခုမှာ အောက်ပါအရာများပါဝင်တတ်ပါတယ်:

- **Server Configuration**: Port, authentication, နဲ့ အခြား settings များကို setup လုပ်ခြင်း
- **Resources**: LLM များအတွက် ရရှိနိုင်တဲ့ ဒေတာနဲ့ context
- **Tools**: မော်ဒယ်များက invoke လုပ်နိုင်တဲ့ စွမ်းဆောင်ရည်များ
- **Prompts**: Text ကို ဖန်တီးခြင်း ဒါမှမဟုတ် ဖွဲ့စည်းခြင်းအတွက် templates

TypeScript မှာ ရိုးရှင်းတဲ့ ဥပမာတစ်ခုက:

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

အထက်ပါ code မှာ:

- MCP TypeScript SDK မှ လိုအပ်တဲ့ classes တွေကို import လုပ်ထားပါတယ်။
- MCP server instance အသစ်တစ်ခုကို ဖန်တီးပြီး configure လုပ်ထားပါတယ်။
- Custom tool (`calculator`) ကို handler function နဲ့ register လုပ်ထားပါတယ်။
- MCP requests များကို လက်ခံဖို့ server ကို start လုပ်ထားပါတယ်။

## စမ်းသပ်ခြင်းနှင့် Debugging

MCP server ကို စမ်းသပ်မတိုင်မီ သင့် server ရဲ့ စွမ်းဆောင်ရည်ကို စမ်းသပ်ဖို့ tools နဲ့ best practices များကို နားလည်ထားဖို့ အရေးကြီးပါတယ်။ ထိရောက်တဲ့ စမ်းသပ်မှုက server ရဲ့ အပြုအမူကို မျှော်မှန်းထားသလိုဖြစ်စေပြီး ပြဿနာများကို အလျင်အမြန် ရှာဖွေပြီး ဖြေရှင်းနိုင်စေပါတယ်။ အောက်ပါအပိုင်းက MCP implementation ကို validate လုပ်ဖို့ အကြံပေးနည်းလမ်းများကို ဖော်ပြထားပါတယ်။

MCP က server များကို စမ်းသပ်ခြင်းနှင့် debugging လုပ်ဖို့ tools များပေးထားပါတယ်:

- **Inspector tool**: ဒီ graphical interface က သင့် server ကို ချိတ်ဆက်ပြီး tools, prompts, နဲ့ resources များကို စမ်းသပ်နိုင်ပါတယ်။
- **curl**: Command line tool တစ်ခုဖြစ်တဲ့ curl ဒါမှမဟုတ် HTTP commands များကို run လုပ်နိုင်တဲ့ အခြား clients များကို အသုံးပြုနိုင်ပါတယ်။

### MCP Inspector ကို အသုံးပြုခြင်း

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) က visual testing tool တစ်ခုဖြစ်ပြီး အောက်ပါအရာများကို ကူညီပေးပါတယ်:

1. **Server Capabilities ရှာဖွေခြင်း**: ရရှိနိုင်တဲ့ resources, tools, နဲ့ prompts များကို အလိုအလျောက် detect လုပ်ခြင်း
2. **Tool Execution စမ်းသပ်ခြင်း**: အမျိုးမျိုးသော parameters တွေကို စမ်းသပ်ပြီး real-time response တွေကို ကြည့်ရှုခြင်း
3. **Server Metadata ကြည့်ရှုခြင်း**: Server info, schemas, နဲ့ configurations များကို စစ်ဆေးခြင်း

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

အထက်ပါ commands များကို run လုပ်တဲ့အခါ MCP Inspector က သင့် browser မှာ local web interface တစ်ခုကို launch လုပ်ပါမယ်။ Dashboard မှာ MCP servers, tools, resources, နဲ့ prompts များကို ပြသထားတာကို တွေ့ရပါမယ်။ Interface က interactive testing, server metadata inspection, နဲ့ real-time responses တွေကို ကြည့်ရှုနိုင်စေပြီး MCP server implementations များကို validate လုပ်ဖို့ လွယ်ကူစေပါတယ်။

## အများဆုံးတွေ့ရတဲ့ Setup ပြဿနာများနှင့် ဖြေရှင်းနည်းများ

| ပြဿနာ | ဖြစ်နိုင်တဲ့ ဖြေရှင်းနည်း |
|-------|-------------------|
| Connection refused | Server run နေမလား၊ port မှန်မမှန် စစ်ဆေးပါ |
| Tool execution errors | Parameter validation နဲ့ error handling ကို ပြန်လည်သုံးသပ်ပါ |
| Authentication failures | API keys နဲ့ permissions ကို စစ်ဆေးပါ |
| Schema validation errors | Parameters တွေက သတ်မှတ်ထားတဲ့ schema နဲ့ ကိုက်ညီမညီ စစ်ဆေးပါ |
| Server not starting | Port conflicts ဒါမှမဟုတ် လိုအပ်တဲ့ dependencies မရှိတာကို စစ်ဆေးပါ |
| CORS errors | Cross-origin requests အတွက် CORS headers ကို configure လုပ်ပါ |
| Authentication issues | Token validity နဲ့ permissions ကို စစ်ဆေးပါ |

## ဒေသတွင်း ဖွံ့ဖြိုးတိုးတက်မှု

ဒေသတွင်း ဖွံ့ဖြိုးတိုးတက်မှုနဲ့ စမ်းသပ်မှုအတွက် MCP servers တွေကို သင့်စက်ပေါ်မှာ တိုက်ရိုက် run လုပ်နိုင်ပါတယ်:

1. **Server process ကို စတင်ပါ**: MCP server application ကို run လုပ်ပါ
2. **Networking ကို configure လုပ်ပါ**: Server ကို မျှော်မှန်းထားတဲ့ port မှာ access လုပ်နိုင်အောင် စစ်ဆေးပါ
3. **Clients တွေကို ချိတ်ဆက်ပါ**: `http://localhost:3000` လို local connection URLs တွေကို အသုံးပြုပါ

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## MCP Server တစ်ခုကို တည်ဆောက်ခြင်း

[Core concepts](/01-CoreConcepts/README.md) ကို ယခင်သင်ခန်းစာမှာ ဖော်ပြပြီးသားဖြစ်ပါတယ်၊ အခုတော့ အဲဒီအရာတွေကို လက်တွေ့အသုံးချဖို့ အချိန်ရောက်ပါပြီ။

### Server တစ်ခုက ဘာလုပ်နိုင်မလဲ

Code ရေးမတိုင်မီ Server တစ်ခုက ဘာလုပ်နိုင်မလဲဆိုတာကို ပြန်လည်သတိရကြည့်ရအောင်:

ဥပမာ MCP server တစ်ခုက:

- ဒေသတွင်း ဖိုင်များနဲ့ databases တွေကို access လုပ်နိုင်တယ်
- Remote APIs တွေကို ချိတ်ဆက်နိုင်တယ်
- Computations တွေကို ဆောင်ရွက်နိုင်တယ်
- အခြား tools နဲ့ services တွေကို ပေါင်းစည်းနိုင်တယ်
- အသုံးပြုသူ interface ကို ပေးနိုင်တယ်

အိုကေ၊ အခုတော့ ဘာလုပ်နိုင်မလဲ သိပြီးသားဖြစ်တော့ Code ရေးဖို့ စတင်ကြရအောင်!

## လေ့ကျင့်ခန်း: Server တစ်ခု ဖန်တီးခြင်း

Server တစ်ခုကို ဖန်တီးဖို့ အောက်ပါအဆင့်များကို လိုက်နာရပါမယ်:

- MCP SDK ကို install လုပ်ပါ။
- Project တစ်ခုကို ဖန်တီးပြီး project structure ကို setup လုပ်ပါ။
- Server code ကို ရေးပါ။
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

Spring Boot project တစ်ခုကို ဖန်တီးပါ:

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

Zip ဖိုင်ကို extract လုပ်ပါ:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

pom.xml ဖိုင်မှာ အောက်ပါ configuration အပြည့်အစုံကို ထည့်ပါ:

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

Project ဖန်တီးပြီးသားဖြစ်တော့ Dependencies တွေကို ထည့်သွင်းရအောင်:

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

### -3- Project Files ဖန်တီးခြင်း

#### TypeScript

*package.json* ဖိုင်ကို ဖွင့်ပြီး အောက်ပါ content ကို ထည့်ပါ:

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

*tsconfig.json* ဖိုင်ကို ဖန်တီးပြီး အောက်ပါ content ကို ထည့်ပါ:

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

Source code အတွက် directory တစ်ခု ဖန်တီးပါ:

```sh
mkdir src
touch src/index.ts
```

#### Python

*server.py* ဖိုင်တစ်ခု ဖန်တီးပါ:

```sh
touch server.py
```

#### .NET

လိုအပ်တဲ့ NuGet packages တွေကို install လုပ်ပါ:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

#### Java

Java Spring Boot projects တွေမှာ project structure ကို အလိုအလျောက် ဖန်တီးထားပါတယ်။

#### Rust

Rust မှာ `cargo init` run လုပ်တဲ့အခါ *src/main.rs* ဖိုင်ကို default အနေနဲ့ ဖန်တီးထားပါတယ်။ Default code ကို ဖျက်ပါ။

### -4- Server Code ရေးခြင်း

#### TypeScript

*index.ts* ဖိုင်တစ်ခု ဖန်တီးပြီး အောက်ပါ code ကို ထည့်ပါ:

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

Server ရှိပြီးသားဖြစ်ပေမယ့် အခုတော့ အလုပ်မလုပ်သေးဘူး၊ အဲဒါကို ပြင်ရအောင်။

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

Java အတွက် core server components များကို ဖန်တီးပါ။ Main application class ကို အောက်ပါအတိုင်း ပြင်ဆင်ပါ:

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

Calculator service ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**Production-ready service အတွက် optional components:**

Startup configuration ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

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

Health controller ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

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

Exception handler ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

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

Custom banner ကို ဖန်တီးပါ *src/main/resources/banner.txt*:

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

*src/main.rs* ဖိုင်ရဲ့ အပေါ်ပိုင်းမှာ အောက်ပါ code ကို ထည့်ပါ။ MCP server အတွက် လိုအပ်တဲ့ libraries နဲ့ modules တွေကို import လုပ်ထားပါတယ်။

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

Calculator server က ရိုးရှင်းတဲ့ တစ်ခုဖြစ်ပြီး နံပါတ်နှစ်ခုကို ပေါင်းစပ်နိုင်ပါတယ်။ Calculator request ကို ကိုယ်စားပြုတဲ့ struct တစ်ခုကို ဖန်တီးပါ။

```rust
#[derive(Debug, serde::Deserialize, schemars::JsonSchema)]
pub struct CalculatorRequest {
    pub a: f64,
    pub b: f64,
}
```

Calculator server ကို ကိုယ်စားပြုတဲ့ struct တစ်ခုကို ဖန်တီးပါ။ ဒီ struct က tool router ကို ထည့်သွင်းထားပြီး tools များကို register လုပ်ဖို့ အသုံးပြုပါတယ်။

```rust
#[derive(Debug, Clone)]
pub struct Calculator {
    tool_router: ToolRouter<Self>,
}
```

Calculator struct ကို implement လုပ်ပြီး server handler ကို MCP server information ပေးနိုင်အောင် ဖန်တီးပါ။

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

နောက်ဆုံးမှာ server ကို start လုပ်ဖို့ main function ကို implement လုပ်ပါ။ ဒီ function က Calculator struct ရဲ့ instance ကို ဖန်တီးပြီး standard input/output မှာ serve လုပ်ပါမယ်။

```rust
#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let service = Calculator::new().serve(stdio()).await?;
    service.waiting().await?;
    Ok(())
}
```

Server ရဲ့ အခြေခံအချက်အလက်များကို ပေးနိုင်ဖို့ အဆင့်တစ်ခုရောက်ပြီးသားဖြစ်ပါတယ်။ အခုတော့ addition လုပ်ဖို့ tool တစ်ခုကို ထည့်သွင်းရအောင်။

### -5- Tool နဲ့ Resource ထည့်သွင်းခြင်း

Tool နဲ့ Resource ကို အောက်ပါ code ထည့်သွင်းခြင်းဖြင့် ဖန်တီးပါ:

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

Tool က `a` နဲ့ `b` parameters တွေကို ယူပြီး response ကို အောက်ပါပုံစံဖြင့် ထုတ်ပေးပါမယ်:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

Resource ကို "greeting" string မှတစ်ဆင့် access လုပ်ပြီး `name` parameter ကို ယူပြီး Tool response နဲ့ ဆင်တူတဲ့ output ကို ထုတ်ပေးပါမယ်:

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

အထက်ပါ code မှာ:

- `add` tool ကို ဖန်တီးထားပြီး `a` နဲ့ `p` parameters (integer) ကို ယူပါတယ်။
- `greeting` resource ကို ဖန်တီးထားပြီး `name` parameter ကို ယူပါတယ်။

#### .NET

Program.cs ဖိုင်မှာ အောက်ပါ code ကို ထည့်ပါ:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

#### Java

Tools တွေကို ယခင်အဆင့်မှာ ဖန်တီးပြီးသားဖြစ်ပါတယ်။

#### Rust

`impl Calculator` block အတွင်း tool အသစ်တစ်ခုကို ထည့်ပါ:

```rust
#[tool(description = "Adds a and b")]
async fn add(
    &self,
    Parameters(CalculatorRequest { a, b }): Parameters<CalculatorRequest>,
) -> String {
    (a + b).to_string()
}
```

### -6- နောက်ဆုံး Code

Server ကို start လုပ်နိုင်ဖို့ နောက်ဆုံး code ကို ထည့်ပါ:

#### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

အပြည့်အစုံ code:

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

Program.cs ဖိုင်တစ်ခုကို ဖန်
![Connect](../../../../translated_images/tool.163d33e3ee307e209ef146d8f85060d2f7e83e9f59b3b1699a77204ae0454ad2.my.png)

**သင်သည် server နှင့် ချိတ်ဆက်ပြီးဖြစ်ပါပြီ**  
**Java server စမ်းသပ်မှုအပိုင်းကို အခုပြီးဆုံးခဲ့ပါပြီ**

နောက်အပိုင်းမှာတော့ server နှင့် အပြန်အလှန်လုပ်ဆောင်မှုအကြောင်းဖြစ်ပါမည်။

သင်သည် အောက်ပါ user interface ကိုတွေ့ရမည်ဖြစ်သည်။

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.my.png)

1. **Connect** ခလုတ်ကိုနှိပ်၍ server နှင့် ချိတ်ဆက်ပါ  
   Server နှင့် ချိတ်ဆက်ပြီးပါက အောက်ပါအတိုင်း မြင်ရမည်ဖြစ်သည်။

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.my.png)

2. **"Tools"** နှင့် **"listTools"** ကိုရွေးချယ်ပါ၊ **"Add"** ပေါ်လာသင့်ပြီး၊ **"Add"** ကိုရွေးချယ်ပြီး parameter အချက်အလက်များကို ဖြည့်ပါ။

   သင်သည် အောက်ပါအဖြေကို မြင်ရမည်၊ အဆိုပါအဖြေမှာ **"add" tool** မှရရှိသော ရလဒ်ဖြစ်သည်။

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.my.png)

အောင်မြင်ပါတယ်၊ သင်သည် သင့်ရဲ့ ပထမဆုံး server ကို ဖန်တီးပြီး အောင်မြင်စွာ လည်ပတ်စေခဲ့ပါပြီ!

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

## အဓိကအချက်များ

- MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်ကို ဘာသာစကားအလိုက် SDK များဖြင့် လွယ်ကူစွာ တပ်ဆင်နိုင်သည်  
- MCP server များကို ဖန်တီးရာတွင် tool များကို ရှင်းလင်းသော schema များဖြင့် ဖန်တီးပြီး မှတ်ပုံတင်ရမည်  
- MCP ကို ယုံကြည်စိတ်ချရစေရန် စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းများ အရေးကြီးသည်  

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
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် လူပညာရှင်များမှ ပြုလုပ်သည့် လူ့ဘာသာပြန်ဆိုမှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ဆိုမှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသည့် နားလည်မှုမှားမှုများ သို့မဟုတ် အဓိပ္ပာယ်မှားမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။