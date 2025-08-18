<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "67ecbca6a060477ded3e13ddbeba64f7",
  "translation_date": "2025-08-18T23:35:38+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်ရန်

ဒီနေရာမှာ Classic HTTP streaming server နဲ့ client ကို Python အသုံးပြု၍ အလုပ်လုပ်ပုံ၊ နောက်ပြီး MCP streaming server နဲ့ client ကို အလုပ်လုပ်ပုံကို ပြောပြထားပါတယ်။

### အနှစ်ချုပ်

- သင် MCP server တစ်ခုကို စတင်ပြီး၊ အရာဝတ္ထုများကို လုပ်ဆောင်နေစဉ် client ထံသို့ progress notifications များကို stream လုပ်ပေးမည်။
- Client သည် notification တစ်ခုချင်းစီကို အချိန်နှင့်တပြေးညီ ပြသမည်။
- ဒီလမ်းညွှန်စာအုပ်တွင် လိုအပ်ချက်များ၊ စတင်ခြင်း၊ အလုပ်လုပ်ပုံနှင့် ပြဿနာရှာဖွေခြင်းတို့ကို ဖော်ပြထားသည်။

### လိုအပ်ချက်များ

- Python 3.9 သို့မဟုတ် အထက်
- `mcp` Python package (`pip install mcp` ဖြင့် install လုပ်ပါ)

### Installation & Setup

1. Repository ကို clone လုပ်ပါ သို့မဟုတ် solution ဖိုင်များကို download လုပ်ပါ။

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Virtual environment တစ်ခုကို ဖန်တီးပြီး အလုပ်လုပ်အောင်လုပ်ပါ (အကြံပြုသည်):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **လိုအပ်သော dependencies များကို install လုပ်ပါ:**

   ```pwsh
   pip install "mcp[cli]" fastapi requests
   ```

### ဖိုင်များ

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Classic HTTP Streaming Server ကို အလုပ်လုပ်ရန်

1. Solution directory သို့ သွားပါ:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Classic HTTP streaming server ကို စတင်ပါ:

   ```pwsh
   python server.py
   ```

3. Server သည် စတင်ပြီး အောက်ပါအတိုင်း ပြသမည်:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Classic HTTP Streaming Client ကို အလုပ်လုပ်ရန်

1. Terminal အသစ်တစ်ခုဖွင့်ပါ (အတူတူသော virtual environment နှင့် directory ကို activate လုပ်ပါ):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Streamed messages များ sequentially ပြသမည်:

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

### MCP Streaming Server ကို အလုပ်လုပ်ရန်

1. Solution directory သို့ သွားပါ:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Streamable-http transport ဖြင့် MCP server ကို စတင်ပါ:
   ```pwsh
   python server.py mcp
   ```
3. Server သည် စတင်ပြီး အောက်ပါအတိုင်း ပြသမည်:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP Streaming Client ကို အလုပ်လုပ်ရန်

1. Terminal အသစ်တစ်ခုဖွင့်ပါ (အတူတူသော virtual environment နှင့် directory ကို activate လုပ်ပါ):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Server သည် အရာဝတ္ထုတစ်ခုချင်းစီကို လုပ်ဆောင်နေစဉ် real-time notifications များကို ပြသမည်:
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

### အဓိက အကောင်အထည်ဖော်ခြင်းအဆင့်များ

1. **FastMCP ကို အသုံးပြု၍ MCP server တစ်ခု ဖန်တီးပါ။**
2. **List တစ်ခုကို လုပ်ဆောင်ပြီး `ctx.info()` သို့မဟုတ် `ctx.log()` ဖြင့် notifications များ ပေးပို့သော tool တစ်ခုကို သတ်မှတ်ပါ။**
3. **`transport="streamable-http"` ဖြင့် server ကို အလုပ်လုပ်ပါ။**
4. **Notifications များ ရောက်လာသည်နှင့်တပြေးညီ ပြသရန် message handler ပါသော client တစ်ခုကို အကောင်အထည်ဖော်ပါ။**

### Code Walkthrough
- Server သည် async functions များနှင့် MCP context ကို အသုံးပြု၍ progress updates များ ပေးပို့သည်။
- Client သည် async message handler တစ်ခုကို အသုံးပြု၍ notifications များနှင့် နောက်ဆုံးရလဒ်ကို print လုပ်သည်။

### အကြံပြုချက်များနှင့် ပြဿနာရှာဖွေခြင်း

- Non-blocking operations များအတွက် `async/await` ကို အသုံးပြုပါ။
- Server နှင့် client နှစ်ခုစလုံးတွင် robustness အတွက် exceptions များကို အမြဲ handle လုပ်ပါ။
- Multiple clients များဖြင့် စမ်းသပ်ပြီး real-time updates များကို ကြည့်ရှုပါ။
- အမှားများကြုံတွေ့ပါက Python version ကို စစ်ဆေးပြီး လိုအပ်သော dependencies များအားလုံး install လုပ်ထားကြောင်း သေချာပါ။

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မှန်ကန်မှုမရှိသောအချက်များ ပါဝင်နိုင်ပါသည်။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာတည်သော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူသားဘာသာပြန်ကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။