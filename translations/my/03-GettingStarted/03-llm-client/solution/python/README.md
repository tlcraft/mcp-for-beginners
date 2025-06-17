<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-06-17T16:49:54+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạy လုပ်ခြင်း

`uv` ကို 설치 လုပ်ဖို့ အကြံပြုပါတယ်၊ ဒါပေမယ့် မဖြစ်မနေ မလိုအပ်ပါ၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -0- အကြောင်း virtual environment တစ်ခု ဖန်တီးပါ

```bash
python -m venv venv
```

## -1- virtual environment ကို ဖွင့်ပါ

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော dependency များကို 설치 လုပ်ပါ

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- နမူနာကို chạy လုပ်ပါ

```bash
python client.py
```

အောက်ပါအတိုင်း အထွက်ကို တွေ့ရပါမယ် -

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
Tool {'a': {'title': 'A', 'type': 'integer'}, 'b': {'title': 'B', 'type': 'integer'}}
CALLING LLM
TOOL:  {'function': {'arguments': '{"a":2,"b":20}', 'name': 'add'}, 'id': 'call_BCbyoCcMgq0jDwR8AuAF9QY3', 'type': 'function'}
[05/08/25 21:04:55] INFO     Processing request of type CallToolRequest                                                                                server.py:534
TOOLS result:  [TextContent(type='text', text='22', annotations=None)]
```

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မိခင်ဘာသာဖြင့်သာ ယုံကြည်စိတ်ချရသော အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ လက်တွေ့ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက် အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုအမှားများ သို့မဟုတ် မှားယွင်းသဘောထားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မရှိပါ။