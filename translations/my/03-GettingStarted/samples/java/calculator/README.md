<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-06-17T16:37:20+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "my"
}
-->
# Basic Calculator MCP Service

ဤဝန်ဆောင်မှုသည် Model Context Protocol (MCP) ကို အသုံးပြု၍ Spring Boot နှင့် WebFlux သယ်ယူပို့ဆောင်မှုဖြင့် မူလ ကိန်းဂဏန်းတွက်ချက်ရေး လုပ်ဆောင်ချက်များကို ပေးဆောင်သည်။ MCP အကောင်အထည်ဖော်မှုများကို လေ့လာနေသော စတင်သူများအတွက် ရိုးရှင်းသည့် ဥပမာတစ်ခုအဖြစ် ဒီဇိုင်းရေးဆွဲထားသည်။

အသေးစိတ်အချက်အလက်များအတွက် [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) ကို ကြည့်ရှုနိုင်ပါသည်။

## အနှစ်ချုပ်

ဝန်ဆောင်မှုတွင် အောက်ပါအချက်များပါဝင်သည်။
- SSE (Server-Sent Events) ကို ထောက်ပံ့မှု
- Spring AI ၏ `@Tool` annotation ကို အသုံးပြု၍ စက်တင်တက်စက်သည့် ကိရိယာမှတ်ပုံတင်ခြင်း
- ရိုးရှင်းသော ကိန်းဂဏန်းတွက်ချက်မှုများ
  - ညွှန်းခြင်း၊ ဖြုတ်ခြင်း၊ မျှတခြင်း၊ ညှိခြင်း
  - အခြေခံပမာဏနှင့် အတိုးအကျယ်တွက်ချက်ခြင်း၊ စတုရန်းမူလတန်း
  - ကွက်တိ (modulus) နှင့် တန်ဖိုးအပြည့်အစုံ
  - လုပ်ဆောင်ချက်ဖော်ပြချက်အတွက် အကူအညီလုပ်ဆောင်ချက်

## လက္ခဏာများ

ဤ ကိန်းဂဏန်းတွက်ချက်ရေး ဝန်ဆောင်မှုတွင် အောက်ပါ လုပ်ဆောင်ချက်များ ပါဝင်သည် -

1. **ရိုးရှင်းသော သင်္ချာလုပ်ဆောင်ချက်များ**  
   - နံပါတ်နှစ်ခုကို ပေါင်းခြင်း  
   - နံပါတ်တစ်ခုမှ နံပါတ်တစ်ခု ဖြုတ်ခြင်း  
   - နံပါတ်နှစ်ခုကို မြှောက်ခြင်း  
   - နံပါတ်တစ်ခုကို နံပါတ်တစ်ခုဖြင့် ညှိခြင်း (သုညဖြင့် ညှိမှုစစ်ဆေးမှုပါဝင်သည်)

2. **တိုးတက်သော လုပ်ဆောင်ချက်များ**  
   - အခြေစိုက်မှ တာဝန်ထမ်းဆောင်မှု (power calculation)  
   - စတုရန်းမူလတန်းတွက်ချက်ခြင်း (အနုတ်လက္ခဏာစစ်ဆေးမှုပါ)  
   - ကွက်တိ (remainder) တွက်ချက်ခြင်း  
   - တန်ဖိုးအပြည့်အစုံ တွက်ချက်ခြင်း

3. **အကူအညီစနစ်**  
   - ရနိုင်သော လုပ်ဆောင်ချက်အားလုံးကို ဖော်ပြသော အကူအညီလုပ်ဆောင်ချက် ပါဝင်သည်။

## ဝန်ဆောင်မှု အသုံးပြုခြင်း

ဝန်ဆောင်မှုသည် MCP protocol မှတဆင့် အောက်ပါ API endpoint များကို ဖော်ပြထားသည် -

- `add(a, b)`: နံပါတ်နှစ်ခု ပေါင်းခြင်း  
- `subtract(a, b)`: ဒုတိယနံပါတ်ကို ပထမနံပါတ်မှ ဖြုတ်ခြင်း  
- `multiply(a, b)`: နံပါတ်နှစ်ခုကို မြှောက်ခြင်း  
- `divide(a, b)`: ပထမနံပါတ်ကို ဒုတိယနံပါတ်ဖြင့် ညှိခြင်း (သုညစစ်ဆေးမှုပါ)  
- `power(base, exponent)`: နံပါတ်တစ်ခု၏ အခြေစိုက်မှုတွက်ချက်ခြင်း  
- `squareRoot(number)`: စတုရန်းမူလတန်းတွက်ချက်ခြင်း (အနုတ်လက္ခဏာစစ်ဆေးမှုပါ)  
- `modulus(a, b)`: ညှိခြင်းအချိန်ကွက်တိ (remainder) တွက်ချက်ခြင်း  
- `absolute(number)`: တန်ဖိုးအပြည့်အစုံ တွက်ချက်ခြင်း  
- `help()`: ရနိုင်သော လုပ်ဆောင်ချက်များအကြောင်း အချက်အလက်ရယူခြင်း

## စမ်းသပ် Client

အခြေခံ စမ်းသပ် Client ကို `com.microsoft.mcp.sample.client` package တွင် ပါဝင်သည်။ `SampleCalculatorClient` class သည် ကိန်းဂဏန်းတွက်ချက်ရေး ဝန်ဆောင်မှု၏ ရနိုင်သော လုပ်ဆောင်ချက်များကို ပြသသည်။

## LangChain4j Client အသုံးပြုခြင်း

ပရောဂျက်တွင် LangChain4j ဥပမာ Client ကို `com.microsoft.mcp.sample.client.LangChain4jClient` တွင် ပါဝင်ပြီး ကိန်းဂဏန်းတွက်ချက်ရေး ဝန်ဆောင်မှုကို LangChain4j နှင့် GitHub မော်ဒယ်များနှင့် ပေါင်းစပ်အသုံးပြုမှုကို ပြသသည်။

### လိုအပ်ချက်များ

1. **GitHub Token ပြင်ဆင်ခြင်း**  
   GitHub ၏ AI မော်ဒယ်များ (phi-4 ကဲ့သို့) ကို အသုံးပြုရန် GitHub personal access token လိုအပ်သည်။

   a. သင့် GitHub အကောင့် သတ်မှတ်ချက်များသို့ သွားပါ - https://github.com/settings/tokens  
   
   b. "Generate new token" → "Generate new token (classic)" ကို နှိပ်ပါ  
   
   c. Token အတွက် ဖော်ပြချက်အမည် ပေးပါ  
   
   d. အောက်ပါ scopes များကို ရွေးချယ်ပါ -  
      - `repo` (Private repository များအတွက် အပြည့်အဝ ထိန်းချုပ်ခွင့်)  
      - `read:org` (အဖွဲ့နှင့် အဖွဲ့ဝင်အချက်အလက်များ ဖတ်ရှုခွင့်)  
      - `gist` (Gist များဖန်တီးခွင့်)  
      - `user:email` (အသုံးပြုသူ အီးမေးလ်လိပ်စာများ ဖတ်ရှုခွင့် (ဖတ်-only))  
   
   e. "Generate token" ကို နှိပ်ပြီး token ကို ကူးယူပါ  
   
   f. အောက်ပါအတိုင်း ပတ်ဝန်းကျင် အပြောင်းအလဲအဖြစ် သတ်မှတ်ပါ -  
      
      Windows တွင် -  
      ```
      set GITHUB_TOKEN=your-github-token
      ```  
      
      macOS/Linux တွင် -  
      ```bash
      export GITHUB_TOKEN=your-github-token
      ```

   g. သက်တမ်းရှည်အတွက် စနစ်မှ ပတ်ဝန်းကျင်ပြောင်းလဲမှုများထဲ ထည့်သွင်းပါ

2. LangChain4j GitHub dependency ကို ပရောဂျက်ထဲ ထည့်ပါ (pom.xml တွင် ပါပြီး)  
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. ကိန်းဂဏန်းတွက်ချက်ရေး Server ကို `localhost:8080` တွင် အလုပ်လုပ်နေပါသည်။

### LangChain4j Client ကို စတင်အသုံးပြုခြင်း

ဤဥပမာတွင် ပါဝင်သည် -  
- Calculator MCP server သို့ SSE သယ်ယူပို့ဆောင်မှုဖြင့် ချိတ်ဆက်ခြင်း  
- LangChain4j ဖြင့် calculator လုပ်ဆောင်ချက်များကို အသုံးပြုသော စကားပြော bot ဖန်တီးခြင်း  
- GitHub AI မော်ဒယ်များနှင့် ပေါင်းစပ်ခြင်း (ယခု phi-4 မော်ဒယ်ကို အသုံးပြုသည်)

Client သည် အောက်ပါ စမ်းသပ်မေးခွန်းများကို ပေးပို့ကာ လုပ်ဆောင်ချက်များကို ပြသသည် -  
1. နံပါတ်နှစ်ခု ပေါင်းခြင်း  
2. နံပါတ်တစ်ခု၏ စတုရန်းမူလတန်း ရှာဖွေခြင်း  
3. ရနိုင်သော ကိန်းဂဏန်းလုပ်ဆောင်ချက်များအကြောင်း အကူအညီ ရယူခြင်း

ဥပမာကို လည်ပတ်ပြီး ကွန်ဆိုလ်ထုတ်လွှင့်ချက်တွင် AI မော်ဒယ်သည် ကိန်းဂဏန်းကိရိယာများကို မေးခွန်းများအတွက် မည်သို့ အသုံးပြုသည်ကို ကြည့်ရှုနိုင်ပါသည်။

### GitHub Model ပြင်ဆင်ခြင်း

LangChain4j client သည် GitHub ၏ phi-4 မော်ဒယ်ဖြင့် အောက်ပါ ပြင်ဆင်ချက်များထားရှိသည် -

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

အခြား GitHub မော်ဒယ်များ အသုံးပြုလိုပါက `modelName` ကို မူလထောက်ခံထားသော မော်ဒယ်အမည်ဖြင့် (ဥပမာ - "claude-3-haiku-20240307", "llama-3-70b-8192" စသည်) ပြောင်းလဲနိုင်ပါသည်။

## မူလအချက်အလက်များ

ပရောဂျက်တွင် လိုအပ်သော အဓိက dependency များမှာ -

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
</dependency>
```

## ပရောဂျက်ကို တည်ဆောက်ခြင်း

Maven ဖြင့် ပရောဂျက်ကို တည်ဆောက်ပါ -  
```bash
./mvnw clean install -DskipTests
```

## Server ကို လည်ပတ်ခြင်း

### Java အသုံးပြုခြင်း

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### MCP Inspector အသုံးပြုခြင်း

MCP Inspector သည် MCP ဝန်ဆောင်မှုများနှင့် အဆက်အသွယ်ပြုလုပ်ရာတွင် အထောက်အကူပြု ကိရိယာတစ်ခုဖြစ်သည်။ ဤ calculator ဝန်ဆောင်မှုနှင့် အသုံးပြုရန် -

1. **MCP Inspector ကို ထည့်သွင်း၍ အလုပ်လုပ်စေပါ** - terminal အသစ်တွင်  
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Web UI သို့ ဝင်ရောက်ရန်** - app မှ ပြသသော URL ကို နှိပ်ပါ (ပုံမှန်အားဖြင့် http://localhost:6274)

3. **ချိတ်ဆက်မှု ပြင်ဆင်ခြင်း**  
   - သယ်ယူပို့ဆောင်မှု အမျိုးအစားကို "SSE" သတ်မှတ်ပါ  
   - သင့် Server ၏ SSE endpoint URL ကို `http://localhost:8080/sse` အဖြစ် ထည့်ပါ  
   - "Connect" ကို နှိပ်ပါ

4. **ကိရိယာများ အသုံးပြုခြင်း**  
   - "List Tools" ကို နှိပ်၍ ရနိုင်သော calculator လုပ်ဆောင်ချက်များ ကြည့်ရှုပါ  
   - လုပ်ဆောင်ချက်တစ်ခု ရွေးပြီး "Run Tool" ကို နှိပ်၍ လုပ်ဆောင်ချက်ကို အကောင်အထည်ဖော်ပါ

![MCP Inspector Screenshot](../../../../../../translated_images/tool.c75a0b2380efcf1a47a8478f54380a36ddcca7943b98f56dabbac8b07e15c3bb.my.png)

### Docker အသုံးပြုခြင်း

ပရောဂျက်တွင် container များဖြင့် ထုတ်လုပ်ရန် Dockerfile ပါဝင်သည် -

1. **Docker image ကို တည်ဆောက်ပါ**  
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **Docker container ကို လည်ပတ်ပါ**  
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

ဤအတိုင်း -  
- Maven 3.9.9 နှင့် Eclipse Temurin 24 JDK ကို အသုံးပြု၍ multi-stage Docker image တည်ဆောက်မည်  
- အဆင့်မြှင့် container image ဖန်တီးမည်  
- ဝန်ဆောင်မှုကို port 8080 တွင် ဖော်ပြမည်  
- MCP calculator ဝန်ဆောင်မှုကို container အတွင်း စတင်မည်

Container လည်ပတ်သည့်အခါ `http://localhost:8080` မှ ဝန်ဆောင်မှုကို ဝင်ရောက် အသုံးပြုနိုင်ပါသည်။

## ပြဿနာဖြေရှင်းခြင်း

### GitHub Token နှင့် ပတ်သက်သော ပုံမှန်ပြဿနာများ

1. **Token ခွင့်ပြုချက် ပြဿနာများ** - 403 Forbidden error ဖြစ်ပါက၊ token ၏ ခွင့်ပြုချက်များကို prerequisites အတိုင်း စစ်ဆေးပါ။

2. **Token မတွေ့ရှိခြင်း** - "No API key found" error ဖြစ်ပါက GITHUB_TOKEN ပတ်ဝန်းကျင်ပြောင်းလဲမှုကို မှန်ကန်စွာ သတ်မှတ်ထားမှုရှိကြောင်း သေချာစစ်ဆေးပါ။

3. **Rate Limiting** - GitHub API တွင် rate limit ရှိသည်။ 429 status code error ကြုံပါက မိနစ်အနည်းငယ် စောင့်ပါ၊ ပြန်ကြိုးစားပါ။

4. **Token သက်တမ်းကုန်ဆုံးခြင်း** - Token မတော်တဆ သက်တမ်းကုန်ပါက အသစ်ဖန်တီး၍ ပတ်ဝန်းကျင်ပြောင်းလဲမှုကို ပြန်ထည့်သွင်းပါ။

ထပ်မံအကူအညီလိုပါက [LangChain4j documentation](https://github.com/langchain4j/langchain4j) သို့မဟုတ် [GitHub API documentation](https://docs.github.com/en/rest) ကို ကြည့်ရှုနိုင်ပါသည်။

**တားမြစ်ချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်မှုဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော သတင်းအချက်အလက်များအတွက် လူ့ဘာသာပြန်သူ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုရာမှ ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားခြင်းများ သို့မဟုတ် အဓိပ္ပါယ်မှားခြင်းများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။