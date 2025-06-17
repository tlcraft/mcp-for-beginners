<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-17T16:43:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို ပြေးရန်

Python ကို အသုံးပြု၍ classic HTTP streaming server နှင့် client၊ MCP streaming server နှင့် client ကို မည်သို့ပြေးရမည်ကို ဖော်ပြထားသည်။

### အကျဉ်းချုပ်

- မိမိသည် MCP server တစ်ခုကို တည်ဆောက်မည်ဖြစ်ပြီး၊ အရာများကို 처리စဉ် client သို့ progress အသိပေးချက်များကို stream ပြသပေးမည်။
- client သည် တစ်ခုချင်းစီသော အသိပေးချက်များကို real time ဖြင့် ပြသမည်။
- ဤလမ်းညွှန်တွင် မတိုင်မီလိုအပ်ချက်များ၊ တပ်ဆင်ခြင်း၊ ပြေးခြင်းနှင့် ပြဿနာဖြေရှင်းခြင်းတို့ကို ဖော်ပြထားသည်။

### မတိုင်မီလိုအပ်ချက်များ

- Python 3.9 သို့မဟုတ် အထက်
- `mcp` Python package (`pip install mcp` ဖြင့် တပ်ဆင်ရန်)

### တပ်ဆင်ခြင်းနှင့် ပြင်ဆင်ခြင်း

1. repository ကို clone ရယူရန် သို့မဟုတ် solution ဖိုင်များကို download ဆွဲရန်။

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Virtual environment တစ်ခု ဖန်တီးပြီး အလုပ်လုပ်စေပါ (အကြံပြုသည်။):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **လိုအပ်သော dependency များကို တပ်ဆင်ပါ။**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ဖိုင်များ

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Classic HTTP Streaming Server ပြေးခြင်း

1. solution directory သို့ သွားရောက်ပါ။

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

### Classic HTTP Streaming Client ပြေးခြင်း

1. terminal အသစ်တစ်ခုဖွင့်ပါ (အထက်ပါ virtual environment နှင့် directory ကို အသုံးပြုပါ)။

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. စီးရီးလိုက် streaming message များကို စာရွက်ပေါ်တွင် မြင်ရမည်။

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

### MCP Streaming Server ပြေးခြင်း

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

### MCP Streaming Client ပြေးခြင်း

1. terminal အသစ်ဖွင့်ပါ (အထက်ပါ virtual environment နှင့် directory ကို အသုံးပြုပါ)။
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. server သည် အရာတစ်ခုချင်းစီကို 처리စဉ် real time ဖြင့် အသိပေးချက်များကို မြင်ရမည်။
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

### အဓိက ဆောင်ရွက်ချက်များ

1. **FastMCP ကို အသုံးပြု၍ MCP server ကို ဖန်တီးပါ။**
2. **စာရင်းတစ်ခုကို 처리ပြီး `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` ဖြင့် non-blocking လုပ်ဆောင်ချက်များအတွက် အသိပေးချက်များ ပို့ပေးသည့် tool ကို သတ်မှတ်ပါ။**
- server နှင့် client နှစ်ဖက်စလုံးတွင် exception များကို အမြဲ ထိန်းချုပ်ပါ။
- client များစွာဖြင့် စမ်းသပ်ပြီး real-time update များကို ကြည့်ရှုပါ။
- အမှားများကြုံတွေ့ပါက Python ဗားရှင်းနှင့် dependency များ တပ်ဆင်ထားမှုကို စစ်ဆေးပါ။

**ပယ်ချမှုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးပမ်းပေမယ့်၊ စက်ရုပ်ဘာသာပြန်ခြင်းကြောင့် အမှားများ သို့မဟုတ် တိကျမှုလွဲမှားမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုအမှားများ သို့မဟုတ် မှားယွင်းဖော်ပြချက်များအတွက် ကျွန်ုပ်တို့မှာ တာဝန်မရှိပါ။