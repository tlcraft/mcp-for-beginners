<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-17T16:39:24+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "my"
}
-->
# MCP Java Client - Calculator Demo

ဒီပရောဂျက်က MCP (Model Context Protocol) ဆာဗာနဲ့ ချိတ်ဆက်ပြီး အပြန်အလှန်ဆက်ဆံမှုလုပ်နိုင်တဲ့ Java client ကို ဘယ်လိုဖန်တီးရမယ်ဆိုတာ ပြသပေးထားပါတယ်။ ဥပမာအနေနဲ့ Chapter 01 မှ calculator ဆာဗာကို ချိတ်ဆက်ပြီး သင်္ချာဆိုင်ရာ လုပ်ဆောင်ချက်မျိုးစုံကို လုပ်ဆောင်ပါမယ်။

## လိုအပ်ချက်များ

ဒီ client ကို run မလုပ်ခင်မှာ အောက်ပါအချက်တွေ လုပ်ထားဖို့ လိုပါတယ်။

1. Chapter 01 မှ Calculator Server ကို စတင်ပါ:
   - calculator server directory ကို သွားပါ: `03-GettingStarted/01-first-server/solution/java/`
   - calculator server ကို build ပြီး run လုပ်ပါ:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - ဆာဗာကို `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `` မှာ run နေသင့်ပါတယ်။

SDKClient ဟာ Java application တစ်ခုဖြစ်ပြီး အောက်ပါအတိုင်းလုပ်ဆောင်ပေးပါတယ် -
- Server-Sent Events (SSE) transport အသုံးပြုပြီး MCP ဆာဗာနဲ့ ချိတ်ဆက်ခြင်း
- ဆာဗာကနေ ရနိုင်တဲ့ tools များကို စာရင်းပြုစုခြင်း
- calculator function များကို remote မှာ ခေါ်ယူခြင်း
- ပြန်လာတဲ့ response များကို ကိုင်တွယ်ပြီး ရလဒ်များကို ပြသခြင်း

## အလုပ်လုပ်ပုံ

Client က Spring AI MCP framework ကို အသုံးပြုပြီး -

1. **ချိတ်ဆက်ခြင်း** - calculator server နဲ့ ချိတ်ဆက်ဖို့ WebFlux SSE client transport တစ်ခု ဖန်တီးခြင်း
2. **Client စတင်ခြင်း** - MCP client ကို initialize ပြီး ချိတ်ဆက်ခြင်း
3. **Tools ရှာဖွေခြင်း** - ရနိုင်တဲ့ calculator operations အားလုံးကို စာရင်းပြုစုခြင်း
4. **လုပ်ဆောင်ချက်များ ဆောင်ရွက်ခြင်း** - သင်္ချာ function များကို sample data တွေနဲ့ ခေါ်ယူခြင်း
5. **ရလဒ် ပြသခြင်း** - တစ်ခုချင်းစီရဲ့ ရလဒ်ကို ပြသခြင်း

## ပရောဂျက် ဖွဲ့စည်းပုံ

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

## အဓိကလိုအပ်ချက်များ

ပရောဂျက်မှာ အောက်ပါ အဓိကလိုအပ်ချက်များကို အသုံးပြုထားပါတယ်။

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

ဒီလိုလိုအပ်ချက်က -
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - web-based ဆက်သွယ်မှုအတွက် SSE transport
- MCP protocol schemas နဲ့ request/response အမျိုးအစားများ

## ပရောဂျက်ကို Build လုပ်ခြင်း

Maven wrapper ကို အသုံးပြုပြီး ပရောဂျက်ကို build လုပ်ပါ။

```cmd
.\mvnw clean install
```

## Client ကို run လုပ်ခြင်း

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: calculator server ကို `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080` မှာ run နေကြောင်း သေချာစေပါ။

2. **Tools စာရင်းပြုစုခြင်း** - ရနိုင်တဲ့ calculator operations အားလုံးကို ပြသပါမယ်
3. **တွက်ချက်မှုများ ဆောင်ရွက်ခြင်း** -
   - ပေါင်းခြင်း: 5 + 3 = 8
   - နှုတ်ခြင်း: 10 - 4 = 6
   - မြှောက်ခြင်း: 6 × 7 = 42
   - ခွဲခြင်း: 20 ÷ 4 = 5
   - အဆင့်မြှောက်ခြင်း: 2^8 = 256
   - စတုရန်းအမြစ်: √16 = 4
   - တန်ဖိုးတစ်ခုတည်း: |-5.5| = 5.5
   - အကူအညီ: ရနိုင်တဲ့ operations များကို ပြသခြင်း

## မျှော်မှန်းထားသော အထွက်

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

**Note**: Maven warnings တွေမှာ threads မပျက်သေးဘူးဆိုတာ ပြသနာမဟုတ်ပါဘူး၊ reactive application တွေအတွက် သာမာန်ဖြစ်ပါတယ်။

## ကုဒ်ကို နားလည်ခြင်း

### 1. Transport စတင်ခြင်း
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
ဒီမှာ calculator server နဲ့ ချိတ်ဆက်ဖို့ SSE (Server-Sent Events) transport တစ်ခု ဖန်တီးထားပါတယ်။

### 2. Client ဖန်တီးခြင်း
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Synchronous MCP client တစ်ခု ဖန်တီးပြီး ချိတ်ဆက်မှုကို initialize လုပ်ပါတယ်။

### 3. Tools ခေါ်ယူခြင်း
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
a=5.0 နဲ့ b=3.0 ဆိုတဲ့ parameters တွေနဲ့ "add" tool ကို ခေါ်ယူပါတယ်။

## ပြဿနာဖြေရှင်းခြင်း

### ဆာဗာ မရောက်ရှိခြင်း
ချိတ်ဆက်မှု error ဖြစ်ရင် Chapter 01 မှ calculator server run နေကြောင်း သေချာစေပါ။
```
Error: Connection refused
```
**ဖြေရှင်းချက်**: calculator server ကို အရင်ဆုံး စတင်ပါ။

### Port ကို အသုံးပြုပြီးသားဖြစ်ခြင်း
Port 8080 ကို အသုံးပြုပြီးသားဖြစ်ရင် -
```
Error: Address already in use
```
**ဖြေရှင်းချက်**: Port 8080 ကို အသုံးပြုနေတဲ့ အခြား application တွေကို ပိတ်ပါ၊ ဒါမှမဟုတ် ဆာဗာကို အခြား port အသုံးပြုစေပါ။

### Build error ဖြစ်ခြင်း
Build error တွေကြုံရင် -
```cmd
.\mvnw clean install -DskipTests
```

## ပိုပြီး လေ့လာလိုပါက

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**အာမခံချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားထားသော်လည်း အလိုအလျောက်ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။