<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:50:51+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "my"
}
-->
# Calculator HTTP Streaming Demo

ဒီပရောဂျက်က Spring Boot WebFlux နဲ့ Server-Sent Events (SSE) ကို အသုံးပြုပြီး HTTP streaming ကို ပြသပေးပါတယ်။ အဲဒီမှာ အပလီကေးရှင်းနှစ်ခု ပါဝင်ပါတယ်-

- **Calculator Server**: လုပ်ဆောင်ချက်တွေကို ပြုလုပ်ပြီး SSE နဲ့ ရလဒ်တွေကို streaming ပြသပေးတဲ့ reactive web service
- **Calculator Client**: Streaming endpoint ကို အသုံးပြုတဲ့ client application

## လိုအပ်ချက်များ

- Java 17 သို့မဟုတ် အထက်
- Maven 3.6 သို့မဟုတ် အထက်

## ပရောဂျက်ဖွဲ့စည်းပုံ

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## အလုပ်လုပ်ပုံ

1. **Calculator Server** က `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` ကို ဖော်ပြပါတယ်
   - Streaming response ကို စားသုံးပါတယ်
   - တစ်ခုချင်း event တစ်ခုကို console ပေါ်မှာ ပြသပါတယ်

## အပလီကေးရှင်းများကို ပြေးစေခြင်း

### ရွေးချယ်စရာ ၁: Maven အသုံးပြုခြင်း (အကြံပြု)

#### ၁။ Calculator Server ကို စတင်ပါ

Terminal တစ်ခု ဖွင့်ပြီး server directory ကို သွားပါ-

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Server က `http://localhost:8080` ပေါ်မှာ စတင်လည်ပတ်ပါလိမ့်မယ်

အောက်ပါအတိုင်း output ကို မြင်ရပါလိမ့်မယ်-
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### ၂။ Calculator Client ကို ပြေးပါ

Terminal အသစ်တစ်ခု ဖွင့်ပြီး client directory ကို သွားပါ-

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Client က server နဲ့ ချိတ်ဆက်ပြီးတွက်ချက်မှုလုပ်ပြီး streaming ရလဒ်တွေကို ပြသပါလိမ့်မယ်။

### ရွေးချယ်စရာ ၂: Java ကို တိုက်ရိုက် အသုံးပြုခြင်း

#### ၁။ Server ကို compile ပြီး run လုပ်ပါ-

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### ၂။ Client ကို compile ပြီး run လုပ်ပါ-

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Server ကို လက်တွေ့စမ်းသပ်ခြင်း

Web browser သို့မဟုတ် curl ကို အသုံးပြုပြီး server ကို စမ်းသပ်နိုင်ပါတယ်-

### Web browser အသုံးပြုခြင်း
`http://localhost:8080/calculate?a=10&b=5&op=add` ကို သွားရောက်ကြည့်ပါ

### curl အသုံးပြုခြင်း
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## မျှော်မှန်းထားသော output

Client ကို run လုပ်တဲ့အခါ streaming output ကို အောက်ပါအတိုင်း မြင်ရပါလိမ့်မယ်-

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## ထောက်ခံတဲ့ လုပ်ဆောင်ချက်များ

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Server-Sent Events နဲ့ တွက်ချက်မှု တိုးတက်မှုနဲ့ ရလဒ်ကို ပြန်ပေးပါသည်

**ဥပမာ Request:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**ဥပမာ Response:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## ပြဿနာဖြေရှင်းခြင်း

### ပုံမှန်ကြုံတွေ့ရသော ပြဿနာများ

1. **Port 8080 ကို အခြား app က အသုံးပြုနေခြင်း**
   - Port 8080 ကို အသုံးပြုနေတဲ့ အခြား app တွေကို ရပ်တန့်ပါ
   - ဒါမှမဟုတ် `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` မှာ server port ကို ပြောင်းပါ (background process အဖြစ် run နေပါက)

## နည်းပညာ stack

- **Spring Boot 3.3.1** - Application framework
- **Spring WebFlux** - Reactive web framework
- **Project Reactor** - Reactive streams library
- **Netty** - Non-blocking I/O server
- **Maven** - Build tool
- **Java 17+** - Programming language

## နောက်တစ်ဆင့်

ကုဒ်ကို ပြင်ဆင်ကြည့်ပါ-
- သင်္ချာဆိုင်ရာ လုပ်ဆောင်ချက်များ ပိုထည့်ပါ
- မမှန်ကန်တဲ့ လုပ်ဆောင်ချက်များအတွက် error handling ထည့်ပါ
- Request/response logging ထည့်ပါ
- Authentication ကို အကောင်အထည်ဖော်ပါ
- Unit test များ ထည့်သွင်းပါ

**စာရွက်ချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ တိကျမှုအတွက် ကြိုးစားပေမယ့် စက်ရုပ်ဘာသာပြန်မှုတွင် အမှားများ သို့မဟုတ် တိကျမှုနည်းပါးမှုများ ဖြစ်ပေါ်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ ယုံကြည်စိတ်ချရသော အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်ရမည်ဖြစ်သည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များ၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သော နားလည်မှားယွင်းမှုများ သို့မဟုတ် မှားယွင်းသဘောထားများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။