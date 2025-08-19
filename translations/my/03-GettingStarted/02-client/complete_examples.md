<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8358c13b5b6877e475674697cdc1a904",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:38:08+00:00",
=======
  "translation_date": "2025-08-18T18:58:43+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "my"
}
-->
# MCP Client အပြည့်အစုံ နမူနာများ

<<<<<<< HEAD
ဤဖိုင်တွင် MCP client များ၏ အပြည့်အစုံ၊ အလုပ်လုပ်နေသော နမူနာများကို အမျိုးမျိုးသော programming language များဖြင့် ပါဝင်သည်။ Client တစ်ခုစီသည် အဓိက README.md သင်ခန်းစာတွင် ဖော်ပြထားသော လုပ်ဆောင်ချက်များကို ပြသထားသည်။
=======
ဒီဖိုင်တွင် MCP client များကို အမျိုးမျိုးသော programming language များဖြင့် ရေးသားထားသော အပြည့်အစုံ၊ အလုပ်လုပ်နိုင်သော နမူနာများ ပါဝင်သည်။ Client တစ်ခုစီသည် အဓိက README.md သင်ခန်းစာတွင် ဖော်ပြထားသော လုပ်ဆောင်ချက်များအားလုံးကို ပြသထားသည်။
>>>>>>> origin/main

## ရရှိနိုင်သော Client များ

### 1. Java Client (`client_example_java.java`)

- **Transport**: SSE (Server-Sent Events) over HTTP
- **Target Server**: `http://localhost:8080`
- **Features**:
<<<<<<< HEAD
  - ချိတ်ဆက်မှု စတင်ခြင်းနှင့် ping
  - Tool စာရင်း
  - Calculator လုပ်ဆောင်ချက်များ (add, subtract, multiply, divide, help)
  - အမှားကို ကိုင်တွယ်ခြင်းနှင့် ရလဒ်ထုတ်ယူခြင်း
=======
  - Connection တည်ဆောက်ခြင်းနှင့် ping
  - Tool များစာရင်း
  - Calculator လုပ်ဆောင်ချက်များ (add, subtract, multiply, divide, help)
  - Error ကိုင်တွယ်ခြင်းနှင့် ရလဒ်ထုတ်ယူခြင်း
>>>>>>> origin/main

**အသုံးပြုရန်**:

```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)

- **Transport**: Stdio (Standard Input/Output)
- **Target Server**: Local .NET MCP server via dotnet run
- **Features**:
  - stdio transport ဖြင့် server ကို အလိုအလျောက် စတင်ခြင်း
<<<<<<< HEAD
  - Tool နှင့် resource စာရင်း
  - Calculator လုပ်ဆောင်ချက်များ
  - JSON ရလဒ်ကို parse လုပ်ခြင်း
  - အမှားကို ကျယ်ကျယ်ပြန့်ပြန့် ကိုင်တွယ်ခြင်း
=======
  - Tool နှင့် resource များစာရင်း
  - Calculator လုပ်ဆောင်ချက်များ
  - JSON ရလဒ် parsing
  - အပြည့်အစုံ error ကိုင်တွယ်မှု
>>>>>>> origin/main

**အသုံးပြုရန်**:

```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)

- **Transport**: Stdio (Standard Input/Output)
- **Target Server**: Local Node.js MCP server
- **Features**:
  - MCP protocol အပြည့်အစုံကို ပံ့ပိုးမှု
  - Tool, resource, နှင့် prompt လုပ်ဆောင်ချက်များ
  - Calculator လုပ်ဆောင်ချက်များ
  - Resource ဖတ်ခြင်းနှင့် prompt အကောင်အထည်ဖော်ခြင်း
<<<<<<< HEAD
  - အမှားကို ခိုင်မာစွာ ကိုင်တွယ်ခြင်း
=======
  - ခိုင်မာသော error ကိုင်တွယ်မှု
>>>>>>> origin/main

**အသုံးပြုရန်**:

```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)

- **Transport**: Stdio (Standard Input/Output)  
- **Target Server**: Local Python MCP server
- **Features**:
  - Async/await ပုံစံဖြင့် လုပ်ဆောင်ချက်များ
<<<<<<< HEAD
  - Tool နှင့် resource ရှာဖွေခြင်း
  - Calculator လုပ်ဆောင်ချက်များ စမ်းသပ်ခြင်း
  - Resource အကြောင်းအရာ ဖတ်ခြင်း
  - Class-based အဖွဲ့စည်းမှု
=======
  - Tool နှင့် resource ရှာဖွေမှု
  - Calculator လုပ်ဆောင်ချက်များ စမ်းသပ်ခြင်း
  - Resource အကြောင်းအရာ ဖတ်ခြင်း
  - Class-based ဖွဲ့စည်းမှု
>>>>>>> origin/main

**အသုံးပြုရန်**:

```bash
python client_example_python.py
```

<<<<<<< HEAD
## Client များအားလုံးတွင် ရှိသော အထူးအင်္ဂါရပ်များ

Client တစ်ခုစီသည် အောက်ပါအချက်များကို ပြသထားသည်-

1. **ချိတ်ဆက်မှု စီမံခန့်ခွဲမှု**
   - MCP server သို့ ချိတ်ဆက်မှု စတင်ခြင်း
   - ချိတ်ဆက်မှု အမှားကို ကိုင်တွယ်ခြင်း
   - သင့်တော်သော cleanup နှင့် resource စီမံခန့်ခွဲမှု

2. **Server ရှာဖွေမှု**
   - ရရှိနိုင်သော tool များ စာရင်း
   - ရရှိနိုင်သော resource များ စာရင်း (ပံ့ပိုးထားသောနေရာတွင်)
   - ရရှိနိုင်သော prompt များ စာရင်း (ပံ့ပိုးထားသောနေရာတွင်)

3. **Tool အသုံးပြုမှု**
   - အခြေခံ calculator လုပ်ဆောင်ချက်များ (add, subtract, multiply, divide)
   - Server အကြောင်းအရာအတွက် help command
   - သင့်တော်သော argument ပေးပို့ခြင်းနှင့် ရလဒ် ကိုင်တွယ်ခြင်း

4. **အမှားကို ကိုင်တွယ်ခြင်း**
   - ချိတ်ဆက်မှု အမှားများ
   - Tool အကောင်အထည်ဖော်မှု အမှားများ
   - အဆင်ပြေသော မအောင်မြင်မှုနှင့် အသုံးပြုသူ feedback

5. **ရလဒ်ကို ကိုင်တွယ်ခြင်း**
   - တုံ့ပြန်မှုများမှ text အကြောင်းအရာ ထုတ်ယူခြင်း
   - ဖတ်ရှုရလွယ်ကူသော output format ပြုလုပ်ခြင်း
   - response format များကို ကိုင်တွယ်ခြင်း

## လိုအပ်ချက်များ

ဤ client များကို အသုံးပြုမည်ဆိုပါက အောက်ပါအချက်များရှိရန် သေချာပါစေ-

1. **သင့် language အတွက် MCP server ကို run လုပ်ထားခြင်း** (`../01-first-server/` မှ)
2. **လိုအပ်သော dependency များကို install လုပ်ထားခြင်း**
3. **သင့် transport အတွက် သင့်တော်သော network ချိတ်ဆက်မှု**
=======
## Client များတွင် ပုံမှန်ပါဝင်သော Features

Client တစ်ခုစီတွင် အောက်ပါအချက်များကို ပြသထားသည်-

1. **Connection စီမံခန့်ခွဲမှု**
   - MCP server သို့ connection တည်ဆောက်ခြင်း
   - Connection error ကိုင်တွယ်ခြင်း
   - သင့်တော်သော cleanup နှင့် resource စီမံခန့်ခွဲမှု

2. **Server ရှာဖွေမှု**
   - ရရှိနိုင်သော tool များစာရင်း
   - ရရှိနိုင်သော resource များစာရင်း (ပံ့ပိုးထားပါက)
   - ရရှိနိုင်သော prompt များစာရင်း (ပံ့ပိုးထားပါက)

3. **Tool အသုံးပြုမှု**
   - အခြေခံ calculator လုပ်ဆောင်ချက်များ (add, subtract, multiply, divide)
   - Server အချက်အလက်များအတွက် help command
   - သင့်တော်သော argument ပေးပို့ခြင်းနှင့် ရလဒ်ကိုင်တွယ်မှု

4. **Error ကိုင်တွယ်မှု**
   - Connection error များ
   - Tool အကောင်အထည်ဖော်မှု error များ
   - အဆင်ပြေသော မအောင်မြင်မှုနှင့် အသုံးပြုသူ feedback

5. **ရလဒ်ကိုင်တွယ်မှု**
   - Response များမှ text အကြောင်းအရာ ထုတ်ယူခြင်း
   - Output ကို ဖတ်ရှုရလွယ်ကူစေရန် format ပြုလုပ်ခြင်း
   - Response format များကို ကိုင်တွယ်ခြင်း

## လိုအပ်ချက်များ

ဒီ client များကို အသုံးပြုမီ အောက်ပါအချက်များရှိရန် သေချာပါစေ-

1. **သင့် language အတွက် MCP server ကို run လုပ်ထားခြင်း** (`../01-first-server/` မှ)
2. **လိုအပ်သော dependency များကို install ပြုလုပ်ထားခြင်း**
3. **သင့်တော်သော network ချိတ်ဆက်မှု** (HTTP-based transport များအတွက်)
>>>>>>> origin/main

## Implementation များအကြား အဓိကကွာခြားချက်များ

| Language   | Transport | Server Startup | Async Model | Key Libraries       |
|------------|-----------|----------------|-------------|---------------------|
| Java       | SSE/HTTP  | External       | Sync        | WebFlux, MCP SDK    |
| C#         | Stdio     | Automatic      | Async/Await | .NET MCP SDK        |
| TypeScript | Stdio     | Automatic      | Async/Await | Node MCP SDK        |
| Python     | Stdio     | Automatic      | AsyncIO     | Python MCP SDK      |
| Rust       | Stdio     | Automatic      | Async/Await | Rust MCP SDK, Tokio |

## နောက်ထပ် လုပ်ဆောင်ရန်

<<<<<<< HEAD
ဤ client နမူနာများကို လေ့လာပြီးနောက်-

1. **Client များကို ပြင်ဆင်ပြီး feature အသစ်များ ထည့်သွင်းပါ**
2. **သင့်ကိုယ်ပိုင် server တစ်ခု ဖန်တီးပြီး client များနှင့် စမ်းသပ်ပါ**
3. **Transport များကို စမ်းသပ်ပါ** (SSE နှင့် Stdio)
=======
ဒီ client နမူနာများကို လေ့လာပြီးနောက်-

1. **Client များကို ပြင်ဆင်ပြီး feature အသစ်များ ထည့်သွင်းပါ**
2. **သင့်ကိုယ်ပိုင် server တစ်ခု ဖန်တီးပြီး ဒီ client များဖြင့် စမ်းသပ်ပါ**
3. **ကွဲပြားသော transport များကို စမ်းသပ်ပါ** (SSE နှင့် Stdio)
>>>>>>> origin/main
4. **MCP လုပ်ဆောင်ချက်များ ပေါင်းစပ်ထားသော application တစ်ခု ဖန်တီးပါ**

## ပြဿနာများကို ဖြေရှင်းခြင်း

<<<<<<< HEAD
### အများဆုံးဖြစ်နိုင်သော ပြဿနာများ

1. **Connection refused**: MCP server သည် မျှော်မှန်းထားသော port/path တွင် run လုပ်နေသည်ကို သေချာပါစေ
2. **Module not found**: သင့် language အတွက် လိုအပ်သော MCP SDK ကို install လုပ်ပါ
3. **Permission denied**: stdio transport အတွက် ဖိုင် permission များကို စစ်ဆေးပါ
4. **Tool not found**: Server သည် မျှော်မှန်းထားသော tool များကို implement လုပ်ထားသည်ကို အတည်ပြုပါ

### Debug Tips

1. **သင့် MCP SDK တွင် verbose logging ကို enable လုပ်ပါ**
2. **Server log များကို စစ်ဆေးပါ** အမှား message များအတွက်
3. **Tool name နှင့် signature များ** client နှင့် server အကြား ကိုက်ညီမှုရှိသည်ကို စစ်ဆေးပါ
4. **MCP Inspector ဖြင့် စမ်းသပ်ပါ** server လုပ်ဆောင်ချက်ကို အတည်ပြုရန်

## ဆက်စပ် Documentation
=======
### ပုံမှန်ပြဿနာများ

1. **Connection refused**: MCP server ကို မျှော်မှန်းထားသော port/path တွင် run လုပ်ထားကြောင်း သေချာပါစေ
2. **Module not found**: သင့် language အတွက် လိုအပ်သော MCP SDK ကို install ပြုလုပ်ပါ
3. **Permission denied**: stdio transport အတွက် file permission များကို စစ်ဆေးပါ
4. **Tool not found**: Server သည် မျှော်မှန်းထားသော tool များကို implement ပြုလုပ်ထားကြောင်း သေချာပါစေ

### Debug အကြံပြုချက်များ

1. **သင့် MCP SDK တွင် verbose logging ကို ဖွင့်ပါ**
2. **Server log များကို စစ်ဆေးပါ** error message များအတွက်
3. **Tool အမည်များနှင့် signature များ** client နှင့် server အကြား ကိုက်ညီကြောင်း စစ်ဆေးပါ
4. **MCP Inspector ဖြင့် စမ်းသပ်ပါ** server လုပ်ဆောင်ချက်များကို အတည်ပြုရန်

## ဆက်စပ်စာရွက်စာတမ်းများ
>>>>>>> origin/main

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**အကြောင်းကြားချက်**:  
<<<<<<< HEAD
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
=======
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရ အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွဲအချော်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
>>>>>>> origin/main
