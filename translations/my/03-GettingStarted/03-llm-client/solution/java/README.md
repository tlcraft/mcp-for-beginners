<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-17T16:50:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "my"
}
-->
# Calculator LLM Client

LangChain4j ကို အသုံးပြုပြီး MCP (Model Context Protocol) ကိန်းဂဏန်းဝန်ဆောင်မှုနှင့် GitHub Models ပေါင်းစပ် အသုံးပြုနည်းကို ပြသထားသည့် Java အပလီကေးရှင်းတစ်ခု ဖြစ်သည်။

## မလိုအပ်သော အချက်များ

- Java 21 သို့မဟုတ် အထက်
- Maven 3.6+ (သို့မဟုတ် ပါဝင်သော Maven wrapper ကို အသုံးပြုနိုင်သည်)
- GitHub Models ကို အသုံးပြုခွင့်ရှိသည့် GitHub အကောင့်
- `http://localhost:8080` တွင် လည်ပတ်နေသော MCP ကိန်းဂဏန်းဝန်ဆောင်မှု

## GitHub Token ရယူနည်း

ဤအပလီကေးရှင်းသည် GitHub Models ကို အသုံးပြုသည့်အတွက် GitHub personal access token လိုအပ်သည်။ token ရယူရန် အောက်ပါအဆင့်များကို လိုက်နာပါ-

### 1. GitHub Models သို့ ဝင်ရောက်ခြင်း
1. [GitHub Models](https://github.com/marketplace/models) သို့ သွားပါ
2. GitHub အကောင့်ဖြင့် ဝင်ရောက် စာရင်းသွင်းပါ
3. GitHub Models အသုံးပြုခွင့် မရှိသေးလျှင် လျှောက်ထားပါ

### 2. Personal Access Token ဖန်တီးခြင်း
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) သို့ သွားပါ
2. "Generate new token" → "Generate new token (classic)" ကို နှိပ်ပါ
3. token အတွက် ဖော်ပြချက်ရှိသော အမည်တစ်ခု ပေးပါ (ဥပမာ- "MCP Calculator Client")
4. သတ်မှတ်ချိန်ကာလကို လိုအပ်သလို သတ်မှတ်ပါ
5. အောက်ပါ scopes များကို ရွေးချယ်ပါ-
   - `repo` (ပုဂ္ဂလိက repository များသို့ ဝင်ရောက်ပါက)
   - `user:email`
6. "Generate token" ကို နှိပ်ပါ
7. **အရေးကြီးချက်**: token ကို ချက်ချင်း ကူးယူထားပါ - ထပ်မကြည့်နိုင်ပါ!

### 3. ပတ်ဝန်းကျင်အပြောင်းအလဲ Variable သတ်မှတ်ခြင်း

#### Windows (Command Prompt) တွင်-
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) တွင်-
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux တွင်-
```bash
export GITHUB_TOKEN=your_github_token_here
```

## တပ်ဆင်ခြင်းနှင့် ပြင်ဆင်ခြင်း

1. **Project ဖိုလ်ဒါကို Clone သို့မဟုတ် ဝင်ရောက်ပါ**

2. **လိုအပ်သော dependencies များ ထည့်သွင်းပါ**:
   ```cmd
   mvnw clean install
   ```
   သို့မဟုတ် Maven ကို တပ်ဆင်ပြီးသားဖြစ်လျှင်-
   ```cmd
   mvn clean install
   ```

3. **ပတ်ဝန်းကျင်အပြောင်းအလဲ Variable ကို သတ်မှတ်ပါ** (အထက်တွင် ဖော်ပြထားသည့် "GitHub Token ရယူနည်း" ကို ကြည့်ပါ)

4. **MCP Calculator Service ကို စတင်ပါ**:
   chapter 1 တွင် ဖော်ပြထားသည့် MCP calculator service ကို `http://localhost:8080/sse` တွင် လည်ပတ်နေစေရန် သေချာပါစေ။ Client ကို စတင်မည်မတိုင်မှီ ဤဝန်ဆောင်မှု လည်ပတ်နေသင့်သည်။

## အပလီကေးရှင်းကို ပြေးဆွဲခြင်း

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## အပလီကေးရှင်း၏ လုပ်ဆောင်ချက်များ

ဤအပလီကေးရှင်းသည် ကိန်းဂဏန်းဝန်ဆောင်မှုနှင့် အောက်ပါ အဓိက အပြန်အလှန် ဆက်သွယ်မှု ၃ မျိုးကို ပြသသည်-

1. **ပေါင်းခြင်း**: 24.5 နှင့် 17.3 ကို ပေါင်းတွက်ချက်ခြင်း
2. **အမြစ်မူလတန်းတွက်ချက်ခြင်း**: 144 ၏ အမြစ်မူလတန်းတွက်ချက်ခြင်း
3. **အကူအညီ**: အသုံးပြုနိုင်သော ကိန်းဂဏန်းလုပ်ဆောင်ချက်များ ပြသခြင်း

## မျှော်မှန်းထားသော ထွက်ရှိမှု

အောင်မြင်စွာ ပြေးဆွဲပါက အောက်ပါအတိုင်း ထွက်ရှိမှုကို မြင်ရမည်-

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## ပြဿနာဖြေရှင်းခြင်း

### လူကြုံတွေ့လေ့ရှိသော ပြဿနာများ

1. **"GITHUB_TOKEN environment variable not set"**
   - `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` ကို သေချာ ပြုလုပ်ထားပါ

### အမှားရှာဖွေရန်

debug logging ကို ဖွင့်ရန်အတွက် အောက်ပါ JVM argument ကို ပြေးဆွဲချိန်တွင် ထည့်သွင်းပါ-
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## ဖွဲ့စည်းမှု

အပလီကေးရှင်းကို အောက်ပါအတိုင်း ပြင်ဆင်ထားသည်-
- GitHub Models ကို `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` ဖြင့် အသုံးပြုသည်
- တောင်းဆိုမှုများအတွက် ၆၀ စက္ကန့် အချိန်ကန့်သတ်ထားသည်
- debug အတွက် တောင်းဆိုမှုနှင့် တုံ့ပြန်မှုများကို မှတ်တမ်းတင်ထားသည်

## လိုအပ်သော အထောက်အပံ့များ

ဤ project တွင် အသုံးပြုသော အဓိက dependencies များ-
- **LangChain4j**: AI ပေါင်းစပ်မှုနှင့် ကိရိယာ စီမံခန့်ခွဲမှုအတွက်
- **LangChain4j MCP**: Model Context Protocol ကို ပံ့ပိုးရန်
- **LangChain4j GitHub Models**: GitHub Models ပေါင်းစပ်မှုအတွက်
- **Spring Boot**: အပလီကေးရှင်း ဖွဲ့စည်းမှုနှင့် dependency injection အတွက်

## အခွင့်အရေး

ဤ project သည် Apache License 2.0 အောက်တွင် လိုင်စင်ရရှိထားသည် - အသေးစိတ်အချက်အလက်များအတွက် [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) ဖိုင်ကို ကြည့်ပါ။

**အချက်ပြချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးပမ်းသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် တိကျမှုလျော့နည်းမှုများ ရှိနိုင်ပါကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်စဉ်းစားသင့်ပါသည်။ အရေးကြီးသော သတင်းအချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူ့ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်နိုင်သော မမှန်ကန်မှုများ သို့မဟုတ် အနားလွတ်ချက်များအတွက် ကျွန်ုပ်တို့ တာဝန်မခံပါ။