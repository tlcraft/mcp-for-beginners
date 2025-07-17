<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd0fdbbbebbef2b6b179ceba21d82ed2",
  "translation_date": "2025-07-17T12:46:50+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "my"
}
-->
# MCP ဖြင့် စတင်လေ့လာခြင်း

Model Context Protocol (MCP) နှင့် ပထမဆုံးခြေလှမ်းများသို့ ကြိုဆိုပါသည်! MCP အသစ်ဖြစ်စေ၊ နားလည်မှုကို ပိုမိုမြှင့်တင်လိုသူဖြစ်စေ၊ ဤလမ်းညွှန်သည် MCP အတွက် အရေးကြီးသော စတင်ပြင်ဆင်ခြင်းနှင့် ဖွံ့ဖြိုးတိုးတက်မှု လုပ်ငန်းစဉ်များကို လမ်းညွှန်ပေးပါမည်။ MCP သည် AI မော်ဒယ်များနှင့် အက်ပလီကေးရှင်းများအကြား ပေါင်းစည်းမှုကို အဆင်ပြေစေသည့် နည်းလမ်းကို ရှာဖွေတွေ့ရှိနိုင်ပြီး MCP အား အသုံးပြု၍ ဖြေရှင်းချက်များ တည်ဆောက်ခြင်းနှင့် စမ်းသပ်ခြင်းအတွက် သင့်ပတ်ဝန်းကျင်ကို အမြန်ပြင်ဆင်နည်းကိုလည်း သင်ယူနိုင်ပါမည်။

> TLDR; AI အက်ပလီကေးရှင်းများ တည်ဆောက်သူများအနေဖြင့် သင်သည် LLM (large language model) ကို ပိုမိုအသိပညာရှိစေရန် ကိရိယာများနှင့် အရင်းအမြစ်များ ထည့်သွင်းနိုင်ကြောင်း သိရှိကြသည်။ သို့သော် ထိုကိရိယာများနှင့် အရင်းအမြစ်များကို ဆာဗာပေါ်တွင်ထားပါက၊ အက်ပလီကေးရှင်းနှင့် ဆာဗာ၏ စွမ်းဆောင်ရည်များကို LLM ပါ/မပါသော မည်သည့် client မဆို အသုံးပြုနိုင်ပါသည်။

## အနှစ်ချုပ်

ဤသင်ခန်းစာတွင် MCP ပတ်ဝန်းကျင်များကို ပြင်ဆင်ခြင်းနှင့် ပထမဆုံး MCP အက်ပလီကေးရှင်းများ တည်ဆောက်ခြင်းအတွက် လက်တွေ့လမ်းညွှန်ချက်များ ပေးပါသည်။ လိုအပ်သော ကိရိယာများနှင့် ဖရိမ်ဝတ်များကို ပြင်ဆင်ခြင်း၊ အခြေခံ MCP ဆာဗာများ တည်ဆောက်ခြင်း၊ host အက်ပလီကေးရှင်းများ ဖန်တီးခြင်းနှင့် သင်၏ အကောင်အထည်ဖော်မှုများကို စမ်းသပ်ခြင်းတို့ကို သင်ယူနိုင်ပါမည်။

Model Context Protocol (MCP) သည် အက်ပလီကေးရှင်းများမှ LLM များအား context ပေးပို့ပုံကို စံပြုထားသည့် ဖွင့်လှစ်ထားသော protocol တစ်ခုဖြစ်သည်။ MCP ကို AI အက်ပလီကေးရှင်းများအတွက် USB-C port တစ်ခုလို ထင်မြင်နိုင်ပါသည် - AI မော်ဒယ်များကို အမျိုးမျိုးသော ဒေတာရင်းမြစ်များနှင့် ကိရိယာများနှင့် ချိတ်ဆက်ရန် စံပြုနည်းလမ်းတစ်ခု ပေးသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးသတ်သည်အထိ သင်သည် အောက်ပါအရာများကို လုပ်ဆောင်နိုင်မည်ဖြစ်သည်-

- C#, Java, Python, TypeScript, နှင့် JavaScript အတွက် MCP ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်များ ပြင်ဆင်ခြင်း
- စိတ်ကြိုက် အင်္ဂါရပ်များ (အရင်းအမြစ်များ၊ prompt များ၊ ကိရိယာများ) ပါရှိသည့် အခြေခံ MCP ဆာဗာများ တည်ဆောက်ခြင်းနှင့် တင်သွင်းခြင်း
- MCP ဆာဗာများနှင့် ချိတ်ဆက်သည့် host အက်ပလီကေးရှင်းများ ဖန်တီးခြင်း
- MCP အကောင်အထည်ဖော်မှုများ စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်း

## သင့် MCP ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်း

MCP နှင့် အလုပ်လုပ်ရန် စတင်မတိုင်မီ သင့်ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်ကို ပြင်ဆင်ထားခြင်းနှင့် အခြေခံ လုပ်ငန်းစဉ်ကို နားလည်ထားခြင်းမှာ အရေးကြီးပါသည်။ ဤအပိုင်းတွင် MCP ဖြင့် စတင်လုပ်ဆောင်ရာတွင် လိုအပ်သော အဆင့်များကို လမ်းညွှန်ပေးပါမည်။

### လိုအပ်ချက်များ

MCP ဖွံ့ဖြိုးရေးကို စတင်မလုပ်မီ အောက်ပါအရာများရှိရန် သေချာပါစေ-

- **ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်** - သင်ရွေးချယ်ထားသော ဘာသာစကား (C#, Java, Python, TypeScript, သို့မဟုတ် JavaScript)
- **IDE/Editor** - Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm သို့မဟုတ် ခေတ်မီသော ကုဒ်တည်းဖြတ်ကိရိယာတစ်ခု
- **Package Managers** - NuGet, Maven/Gradle, pip, သို့မဟုတ် npm/yarn
- **API Keys** - သင့် host အက်ပလီကေးရှင်းများတွင် အသုံးပြုမည့် AI ဝန်ဆောင်မှုများအတွက်

## အခြေခံ MCP ဆာဗာ ဖွဲ့စည်းပုံ

MCP ဆာဗာတစ်ခုတွင် ပုံမှန်အားဖြင့် ပါဝင်သော အရာများမှာ-

- **ဆာဗာ ဖွဲ့စည်းမှု** - port, authentication နှင့် အခြား ဆက်တင်များ ပြင်ဆင်ခြင်း
- **အရင်းအမြစ်များ** - LLM များသို့ ရရှိနိုင်သော ဒေတာနှင့် context
- **ကိရိယာများ** - မော်ဒယ်များက ခေါ်ယူနိုင်သည့် လုပ်ဆောင်ချက်များ
- **prompt များ** - စာသား ဖန်တီးခြင်း သို့မဟုတ် ဖွဲ့စည်းခြင်းအတွက် စံနမူနာများ

TypeScript တွင် ရိုးရှင်းစွာရေးသားထားသော ဥပမာ-

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

အထက်ပါကုဒ်တွင်-

- MCP TypeScript SDK မှ လိုအပ်သော class များကို import လုပ်သည်။
- MCP ဆာဗာအသစ်တစ်ခု ဖန်တီးပြီး ပြင်ဆင်သည်။
- handler function ပါရှိသည့် custom tool (`calculator`) တစ်ခုကို မှတ်ပုံတင်သည်။
- MCP request များကို ကြားနာရန် ဆာဗာကို စတင်သည်။

## စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်း

MCP ဆာဗာကို စမ်းသပ်ရန် စတင်မလုပ်မီ၊ ရရှိနိုင်သော ကိရိယာများနှင့် အမှားရှာဖွေရာတွင် အသုံးဝင်သော အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများကို နားလည်ထားခြင်း အရေးကြီးပါသည်။ ထိရောက်သော စမ်းသပ်မှုသည် သင့်ဆာဗာသည် မျှော်မှန်းထားသည့်အတိုင်း လုပ်ဆောင်နေကြောင်း သေချာစေပြီး ပြဿနာများကို အမြန်ရှာဖွေ ဖြေရှင်းနိုင်စေပါသည်။ အောက်ပါအပိုင်းတွင် MCP အကောင်အထည်ဖော်မှုကို စစ်ဆေးရန် အကြံပြုနည်းလမ်းများ ဖော်ပြထားပါသည်။

MCP သည် သင့်ဆာဗာများကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းအတွက် ကိရိယာများကို ပံ့ပိုးပေးပါသည်-

- **Inspector tool** - ဤ graphical interface သည် သင့်ဆာဗာနှင့် ချိတ်ဆက်ပြီး ကိရိယာများ၊ prompt များနှင့် အရင်းအမြစ်များကို စမ်းသပ်နိုင်စေသည်။
- **curl** - curl ကဲ့သို့သော command line ကိရိယာများ သို့မဟုတ် HTTP command များ ဖန်တီးပြီး လည်ပတ်နိုင်သည့် client များဖြင့် ဆာဗာနှင့် ချိတ်ဆက်နိုင်သည်။

### MCP Inspector အသုံးပြုခြင်း

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) သည် သင့်အား အောက်ပါအရာများတွင် ကူညီပေးသည့် visual စမ်းသပ်ကိရိယာဖြစ်သည်-

1. **ဆာဗာ စွမ်းဆောင်ရည်များ ရှာဖွေခြင်း** - ရရှိနိုင်သော အရင်းအမြစ်များ၊ ကိရိယာများနှင့် prompt များကို အလိုအလျောက် ရှာဖွေသည်။
2. **ကိရိယာ လုပ်ဆောင်မှု စမ်းသပ်ခြင်း** - မတူညီသော ပါရာမီတာများကို စမ်းသပ်ပြီး တုံ့ပြန်ချက်များကို တိုက်ရိုက် ကြည့်ရှုနိုင်သည်။
3. **ဆာဗာ Metadata ကြည့်ရှုခြင်း** - ဆာဗာအချက်အလက်များ၊ schema များနှင့် ဖွဲ့စည်းမှုများကို စစ်ဆေးနိုင်သည်။

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

အထက်ပါ command များကို လည်ပတ်စဉ် MCP Inspector သည် သင့် browser တွင် ဒေသခံ web interface တစ်ခုကို ဖွင့်လှစ်ပါမည်။ သင့်မှတ်ပုံတင်ထားသော MCP ဆာဗာများ၊ ၎င်းတို့၏ ရရှိနိုင်သော ကိရိယာများ၊ အရင်းအမြစ်များနှင့် prompt များကို ပြသသည့် dashboard ကို တွေ့မြင်နိုင်ပါမည်။ ဤ interface သည် ကိရိယာ လုပ်ဆောင်မှုကို အပြန်အလှန် စမ်းသပ်ခြင်း၊ ဆာဗာ metadata ကို စစ်ဆေးခြင်းနှင့် တုံ့ပြန်ချက်များကို တိုက်ရိုက် ကြည့်ရှုခြင်းတို့ကို လွယ်ကူစေပြီး MCP ဆာဗာ အကောင်အထည်ဖော်မှုများကို အတိအကျ စစ်ဆေးနှင့် အမှားရှာဖွေရာတွင် အထောက်အကူပြုပါသည်။

ဤသည်မှာ ၎င်း၏ မျက်နှာပြင်ပုံရိပ်တစ်ခုဖြစ်သည်-

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.my.png)

## ပုံမှန် ပြင်ဆင်မှု ပြဿနာများနှင့် ဖြေရှင်းနည်းများ

| ပြဿနာ | ဖြစ်နိုင်သော ဖြေရှင်းနည်း |
|-------|-------------------------|
| ချိတ်ဆက်မှု ပယ်ချခြင်း | ဆာဗာ လည်ပတ်နေမှုနှင့် port မှန်ကန်မှု စစ်ဆေးပါ |
| ကိရိယာ လုပ်ဆောင်မှု အမှားများ | ပါရာမီတာ စစ်ဆေးမှုနှင့် အမှားကိုင်တွယ်မှု ပြန်လည်သုံးသပ်ပါ |
| အတည်ပြုမှု မအောင်မြင်ခြင်း | API key များနှင့် ခွင့်ပြုချက်များ စစ်ဆေးပါ |
| Schema စစ်ဆေးမှု အမှားများ | ပါရာမီတာများသည် သတ်မှတ်ထားသော schema နှင့် ကိုက်ညီမှုရှိစေရန် သေချာပါစေ |
| ဆာဗာ မစတင်နိုင်ခြင်း | port တူညီမှုများ သို့မဟုတ် လိုအပ်သော dependency များ မရှိမှု စစ်ဆေးပါ |
| CORS အမှားများ | cross-origin request များအတွက် သင့်တော်သော CORS header များ ပြင်ဆင်ပါ |
| အတည်ပြုမှု ပြဿနာများ | token တရားဝင်မှုနှင့် ခွင့်ပြုချက်များ စစ်ဆေးပါ |

## ဒေသခံ ဖွံ့ဖြိုးရေး

ဒေသခံ ဖွံ့ဖြိုးရေးနှင့် စမ်းသပ်မှုအတွက် MCP ဆာဗာများကို သင့်ကွန်ပျူတာပေါ်တွင် တိုက်ရိုက် လည်ပတ်နိုင်ပါသည်-

1. **ဆာဗာ လုပ်ငန်းစဉ် စတင်ပါ** - သင့် MCP ဆာဗာ အက်ပလီကေးရှင်းကို လည်ပတ်ပါ
2. **ကွန်ယက် ပြင်ဆင်မှု** - ဆာဗာသည် မျှော်မှန်းထားသော port တွင် ရရှိနိုင်မှုရှိစေရန် သေချာပါစေ
3. **client များ ချိတ်ဆက်ပါ** - `http://localhost:3000` ကဲ့သို့သော ဒေသခံ ချိတ်ဆက် URL များကို အသုံးပြုပါ

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## ပထမဆုံး MCP ဆာဗာ တည်ဆောက်ခြင်း

[Core concepts](/01-CoreConcepts/README.md) ကို ယခင်သင်ခန်းစာတွင် လေ့လာပြီးဖြစ်ပါသည်၊ ယခု သင်ယူထားသော သိမြင်မှုများကို လက်တွေ့အသုံးချရန် အချိန်ရောက်ပါပြီ။

### ဆာဗာတစ်ခုက ဘာလုပ်နိုင်သလဲ

ကုဒ်ရေးသားခြင်း စတင်မပြုမီ ဆာဗာတစ်ခုက ဘာလုပ်နိုင်သလဲဆိုတာ ပြန်လည် သတိပေးလိုပါတယ်-

MCP ဆာဗာသည် ဥပမာအားဖြင့်-

- ဒေသခံ ဖိုင်များနှင့် ဒေတာဘေ့စ်များကို ဝင်ရောက်ကြည့်ရှုနိုင်သည်
- ဝေးလံသော API များနှင့် ချိတ်ဆက်နိုင်သည်
- တွက်ချက်မှုများ ပြုလုပ်နိုင်သည်
- အခြားကိရိယာများနှင့် ဝန်ဆောင်မှုများနှင့် ပေါင်းစည်းနိုင်သည်
- အသုံးပြုသူနှင့် ဆက်သွယ်ရန် user interface ပေးနိုင်သည်

အဆင်ပြေပါပြီ၊ ယခု ကျွန်ုပ်တို့ ဘာလုပ်နိုင်ကြောင်း သိရှိသဖြင့် ကုဒ်ရေးသားခြင်း စတင်ကြရအောင်။

## လေ့ကျင့်ခန်း - ဆာဗာ ဖန်တီးခြင်း

ဆာဗာတစ်ခု ဖန်တီးရန် အောက်ပါအဆင့်များကို လိုက်နာရမည်-

- MCP SDK ကို တပ်ဆင်ပါ။
- ပရောဂျက်တစ်ခု ဖန်တီးပြီး ပရောဂျက် ဖွဲ့စည်းမှုကို ပြင်ဆင်ပါ။
- ဆာဗာကုဒ်ကို ရေးသားပါ။
- ဆာဗာကို စမ်းသပ်ပါ။

### -1- SDK တပ်ဆင်ခြင်း

သင့်ရွေးချယ်ထားသော runtime အပေါ် မူတည်၍ ကွာခြားမှုရှိနိုင်သဖြင့် အောက်ပါ runtime များမှ တစ်ခုကို ရွေးချယ်ပါ-

> [!NOTE]
> Python အတွက် ပရောဂျက် ဖွဲ့စည်းမှုကို ပထမဦးစွာ ဖန်တီးပြီးနောက် dependency များကို တပ်ဆင်ပါမည်။

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

Java အတွက် Spring Boot ပရောဂျက် တစ်ခု ဖန်တီးပါ-

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

zip ဖိုင်ကို ဖြုတ်ပါ-

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

*pom.xml* ဖိုင်တွင် အောက်ပါ ပြည့်စုံသော ဖွဲ့စည်းမှုကို ထည့်သွင်းပါ-

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

အောက်ပါ အကြောင်းအရာပါ *package.json* ဖိုင်ကို ဖန်တီးပါ-

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

အောက်ပါ အကြောင်းအရာပါ *tsconfig.json* ဖိုင်ကို ဖန်တီးပါ-

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

*server.py* ဖိုင်ကို ဖန်တီးပါ-

```sh
touch server.py
```

### .NET

လိုအပ်သော NuGet package များကို တပ်ဆင်ပါ-

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Java Spring Boot ပရောဂျက်များအတွက် ပရောဂျက် ဖွဲ့စည်းမှုကို အလိုအလျောက် ဖန်တီးပေးပါသည်။

### TypeScript

*index.ts* ဖိုင်ကို ဖန်တီးပြီး အောက်ပါကုဒ်ကို ထည့်သွင်းပါ-

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

ယခု သင့်ဆာဗာရှိသော်လည်း လုပ်ဆောင်ချက် မများသေးပါ၊ အခု ပြင်ဆင်ကြရအောင်။

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

Java အတွက် core ဆာဗာ အစိတ်အပိုင်းများကို ဖန်တီးပါ။ ပထမဦးစွာ main application class ကို ပြင်ဆင်ပါ-

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

calculator service ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

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

**ထုတ်လုပ်မှုအဆင်သင့် ဝန်ဆောင်မှုအတွက် ရွေးချယ်စရာ အစိတ်အပိုင်းများ-**

startup configuration ကို ဖန်တီးပါ *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

@@CODE
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust အကောင်အထည်ဖော်မှု

## အဓိက သင်ခန်းစာများ

- MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်ကို ဘာသာစကားအလိုက် SDK များဖြင့် လွယ်ကူစွာ တပ်ဆင်နိုင်သည်
- MCP ဆာဗာများကို တိကျသေချာသော schema များဖြင့် ကိရိယာများ ဖန်တီးပြီး မှတ်ပုံတင်ခြင်းဖြင့် တည်ဆောက်သည်
- စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းသည် MCP အကောင်အထည်ဖော်မှုများအတွက် အရေးကြီးသည်

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## လုပ်ငန်းတာဝန်

သင်နှစ်သက်ရာ ကိရိယာတစ်ခုဖြင့် ရိုးရှင်းသော MCP ဆာဗာတစ်ခု ဖန်တီးပါ။

1. သင်နှစ်သက်သော ဘာသာစကား (.NET, Java, Python, သို့မဟုတ် JavaScript) ဖြင့် ကိရိယာကို အကောင်အထည်ဖော်ပါ။
2. အဝင် ပါရာမီတာများနှင့် ပြန်လည်ထုတ်ပေးမည့် တန်ဖိုးများကို သတ်မှတ်ပါ။
3. ဆာဗာသည် ရည်ရွယ်သည့်အတိုင်း လည်ပတ်နေကြောင်း သေချာစေရန် inspector ကိရိယာကို ပြေးပါ။
4. အမျိုးမျိုးသော အဝင်များဖြင့် အကောင်အထည်ဖော်မှုကို စမ်းသပ်ပါ။

## ဖြေရှင်းချက်

[Solution](./solution/README.md)

## အပိုဆောင်း အရင်းအမြစ်များ

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ဆင့်

နောက်တစ်ဆင့်: [Getting Started with MCP Clients](../02-client/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။