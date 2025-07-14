<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:23:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို ပြေးဆွဲခြင်း

Python ကို အသုံးပြု၍ classic HTTP streaming server နှင့် client ကို run ပြီး MCP streaming server နှင့် client ကို run ပြုလုပ်နည်းကို ဖော်ပြထားသည်။

### အနှစ်ချုပ်

- MCP server တစ်ခုကို စတင်တည်ဆောက်ပြီး အရာဝတ္ထုများကို ပြုလုပ်စဉ် client သို့ progress notifications များကို stream ပေးမည်။
- client သည် အဲဒီ notification များကို real time ဖြင့် ပြသမည်။
- ဤလမ်းညွှန်တွင် လိုအပ်ချက်များ၊ တပ်ဆင်ခြင်း၊ run ပြုလုပ်ခြင်းနှင့် ပြဿနာဖြေရှင်းနည်းများ ပါဝင်သည်။

### လိုအပ်ချက်များ

- Python 3.9 သို့မဟုတ် အထက်
- `mcp` Python package (`pip install mcp` ဖြင့် တပ်ဆင်ရန်)

### တပ်ဆင်ခြင်းနှင့် ပြင်ဆင်ခြင်း

1. repository ကို clone ရယူရန် သို့မဟုတ် solution ဖိုင်များကို download ရယူရန်။

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Virtual environment တစ်ခု ဖန်တီးပြီး ဖွင့်ပါ (အကြံပြုသည်):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **လိုအပ်သော dependencies များကို တပ်ဆင်ပါ:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ဖိုင်များ

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Classic HTTP Streaming Server ကို run ပြုလုပ်ခြင်း

1. solution directory သို့ သွားပါ။

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. classic HTTP streaming server ကို စတင်ပါ။

   ```pwsh
   python server.py
   ```

3. server သည် စတင်ပြီး အောက်ပါအတိုင်း ပြသမည်။

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Classic HTTP Streaming Client ကို run ပြုလုပ်ခြင်း

1. terminal အသစ် ဖွင့်ပြီး (တူညီသော virtual environment နှင့် directory ကို ဖွင့်ထားပါ)။

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. streamed message များကို အဆက်မပြတ် ပုံနှိပ်ပြသမည်။

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCP Streaming Server ကို run ပြုလုပ်ခြင်း

1. solution directory သို့ သွားပါ။
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http transport ဖြင့် MCP server ကို စတင်ပါ။
   ```pwsh
   python server.py mcp
   ```
3. server သည် စတင်ပြီး အောက်ပါအတိုင်း ပြသမည်။
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP Streaming Client ကို run ပြုလုပ်ခြင်း

1. terminal အသစ် ဖွင့်ပြီး (တူညီသော virtual environment နှင့် directory ကို ဖွင့်ထားပါ)။
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. server သည် အရာဝတ္ထုတစ်ခုချင်းစီကို ပြုလုပ်စဉ် notification များကို real time ဖြင့် ပြသမည်။
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### အဓိက အကောင်အထည်ဖော်ခြင်း အဆင့်များ

1. **FastMCP ကို အသုံးပြု၍ MCP server ကို ဖန်တီးပါ။**
2. **စာရင်းတစ်ခုကို ပြုလုပ်ပြီး `ctx.info()` သို့မဟုတ် `ctx.log()` ဖြင့် notification များ ပို့ပေးသော tool တစ်ခု သတ်မှတ်ပါ။**
3. **`transport="streamable-http"` ဖြင့် server ကို run ပါ။**
4. **notification များ ရောက်ရှိလာသလို ပြသရန် message handler ပါရှိသော client ကို အကောင်အထည်ဖော်ပါ။**

### ကုဒ် လမ်းညွှန်ချက်

- server သည် async function များနှင့် MCP context ကို အသုံးပြု၍ progress update များ ပို့ပေးသည်။
- client သည် async message handler ကို အသုံးပြု၍ notification များနှင့် နောက်ဆုံးရလဒ်ကို ပုံနှိပ်ပြသသည်။

### အကြံပြုချက်များနှင့် ပြဿနာဖြေရှင်းနည်းများ

- non-blocking operation များအတွက် `async/await` ကို အသုံးပြုပါ။
- server နှင့် client နှစ်ဖက်စလုံးတွင် exception များကို အမြဲတမ်း ကိုင်တွယ်ပါ။
- client များစွာဖြင့် စမ်းသပ်၍ real-time update များကို ကြည့်ရှုပါ။
- အမှားများ ဖြစ်ပေါ်ပါက Python version ကို စစ်ဆေးပြီး လိုအပ်သော dependencies များ တပ်ဆင်ထားမှုရှိမရှိ စစ်ဆေးပါ။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။