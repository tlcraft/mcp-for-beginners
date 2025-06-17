<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-06-17T16:36:20+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "my"
}
-->
# အခြေခံ ကိန်းဂဏန်းတွက်စက် MCP ဝန်ဆောင်မှု

ဤဝန်ဆောင်မှုသည် Model Context Protocol (MCP) မှတဆင့် အခြေခံ ကိန်းဂဏန်းတွက်ခြင်း လုပ်ဆောင်ချက်များကို ပေးဆောင်ပါသည်။ MCP ကို လေ့လာသင်ကြားနေသူများအတွက် ရိုးရှင်းသည့် ဥပမာတစ်ခုအဖြစ် ဒီဇိုင်းပြုထားသည်။

နောက်ထပ်အချက်အလက်များအတွက် [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) ကိုကြည့်ပါ။

## လက္ခဏာများ

ဤ ကိန်းဂဏန်းတွက်စက်ဝန်ဆောင်မှုတွင် အောက်ပါ လုပ်ဆောင်ချက်များ ပါဝင်သည်-

1. **အခြေခံ သင်္ချာ လုပ်ဆောင်ချက်များ**:
   - နံပါတ်နှစ်ခု ပေါင်းခြင်း
   - နံပါတ်တစ်ခုကို နံပါတ်တစ်ခုမှ နှုတ်ခြင်း
   - နံပါတ်နှစ်ခု များခြင်း
   - နံပါတ်တစ်ခုကို နံပါတ်တစ်ခုဖြင့် ညှိခြင်း (သုညဖြင့် ညှိခြင်းကို စစ်ဆေးသည်)

## `stdio` အမျိုးအစား အသုံးပြုခြင်း

## ဆက်တင်များ

1. **MCP ဆာဗာများ ဆက်တင်ခြင်း**:
   - သင့် VS Code အလုပ်လုပ်နေရာကို ဖွင့်ပါ။
   - MCP ဆာဗာများ ဆက်တင်ရန် အလုပ်လုပ်နေရာ ဖိုလ်ဒါတွင် `.vscode/mcp.json` ဖိုင်တစ်ခု ဖန်တီးပါ။ ဥပမာ ဆက်တင်အနေဖြင့်-
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
	- လမ်းကြောင်းကို သင့် ပရောဂျက် လမ်းကြောင်းဖြင့် အစားထိုးပါ။ လမ်းကြောင်းသည် အလုံးစုံဖြစ်ရမည်၊ အလုပ်လုပ်နေရာ ဖိုလ်ဒါနှင့် ဆက်စပ်မှုမရှိသင့်ပါ။ (ဥပမာ- D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## ဝန်ဆောင်မှု အသုံးပြုခြင်း

ဝန်ဆောင်မှုသည် MCP ပရိုတိုကောမှတဆင့် အောက်ပါ API အစိတ်အပိုင်းများကို ထုတ်ပေးသည်-

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` သင့် Docker Hub အသုံးပြုသူအမည်ဖြင့်-
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. ပုံရိပ်တည်ဆောက်ပြီးနောက်၊ Docker Hub သို့ တင်ပါမည်။ အောက်ပါ command ကို လုပ်ဆောင်ပါ-
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized ဗားရှင်း အသုံးပြုခြင်း

1. `.vscode/mcp.json` ဖိုင်တွင် ဆာဗာ ဆက်တင်ကို အောက်ပါအတိုင်း အစားထိုးပါ-
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   ဆက်တင်ကိုကြည့်လိုက်ရင် `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `` ဖြစ်ပြီး၊ ယခင်ကဲ့သို့ ကိန်းဂဏန်းတွက်စက်ဝန်ဆောင်မှုကို သင့်အတွက် သင်္ချာဆောင်ရွက်ရန် တောင်းဆိုနိုင်ပါသည်။

**သတိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက်ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ ယုံကြည်စိတ်ချရသော အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်စဉ်းစားသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် သက်ဆိုင်ရာ ကျွမ်းကျင်သော လူသားဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်အသုံးပြုမှုမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။