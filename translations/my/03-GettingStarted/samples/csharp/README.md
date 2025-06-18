<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:10:45+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "my"
}
-->
# Basic Calculator MCP Service

ဤဝန်ဆောင်မှုသည် Model Context Protocol (MCP) မှတဆင့် မူလတွက်ချက်စက်လုပ်ဆောင်ချက်များကို ပံ့ပိုးပေးသည်။ MCP ကိုသင်ယူနေသော စတင်လေ့လာသူများအတွက် ရိုးရှင်းသော ဥပမာအဖြစ် ဒီဇိုင်းရေးဆွဲထားသည်။

အသေးစိတ်အချက်အလက်များအတွက် [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) ကိုကြည့်ပါ။

## Features

ဤတွက်ချက်စက်ဝန်ဆောင်မှုတွင် အောက်ပါ လုပ်ဆောင်ချက်များပါဝင်သည်-

1. **အခြေခံ သင်္ချာ လုပ်ဆောင်ချက်များ**  
   - နံပါတ်နှစ်ခုကို ပေါင်းခြင်း  
   - နံပါတ်တစ်ခုကို နောက်တစ်ခုမှ လျော့ခြင်း  
   - နံပါတ်နှစ်ခုကို မြှောက်ခြင်း  
   - နံပါတ်တစ်ခုကို နောက်တစ်ခုဖြင့် 나누ခြင်း (သုညဖြင့် 나누မှု စစ်ဆေးမှုပါရှိသည်)  

## `stdio` Type အသုံးပြုခြင်း
  
## ပြင်ဆင်ခြင်း

1. **MCP ဆာဗာများကို ပြင်ဆင်ခြင်း**  
   - သင့် VS Code တွင် workspace ကိုဖွင့်ပါ။  
   - workspace ဖိုလ်ဒါထဲတွင် `.vscode/mcp.json` ဖိုင်တစ်ခု ဖန်တီးပြီး MCP ဆာဗာများကို ပြင်ဆင်ပါ။ ဥပမာ ပြင်ဆင်မှု-

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - GitHub repository ရဲ့ root ကို ထည့်သွင်းရန် မေးမြန်းမည်ဖြစ်ပြီး၊ `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` သို့ သင့် Docker Hub username ဖြင့် ပြောင်းလဲ၍ ရယူနိုင်သည်။  
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ```  

1. Image ကို တည်ဆောက်ပြီးပါက Docker Hub သို့ တင်ပေးပါ။ အောက်ပါ command ကို အသုံးပြုပါ-  
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized ဗားရှင်းကို အသုံးပြုခြင်း

1. `.vscode/mcp.json` ဖိုင်တွင် ဆာဗာ ပြင်ဆင်မှုကို အောက်ပါအတိုင်း ပြောင်းလဲပါ-  
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
   ပြင်ဆင်မှုကို ကြည့်လျှင် command သည် `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` ဖြစ်ပြီး၊ ယခင်ကဲ့သို့ပင် သင်သည် ဒီတွက်ချက်စက်ဝန်ဆောင်မှုကို သင်လိုသလို သင်္ချာတွက်ချက်ပေးရန် တောင်းနိုင်ပါသည်။

**ကြိုတင်သတိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့်၊ အလိုအလျောက် ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်ရန် လိုအပ်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် မိမိလက်တွေ့ကျွမ်းကျင်သော လူသား ဘာသာပြန်သူမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းဖော်ပြမှုများအတွက် ကျွန်ုပ်တို့မှာ တာဝန်မရှိပါ။