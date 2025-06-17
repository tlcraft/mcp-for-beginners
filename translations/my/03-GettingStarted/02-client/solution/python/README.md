<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-06-17T16:39:04+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạy လုပ်ခြင်း

`uv` ကို 설치 လုပ်ဖို့ အကြံပြုထားပေမယ့် မဖြစ်မနေ မလိုအပ်ပါ၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -0- အတုပတ်ဝန်းကျင် တည်ဆောက်ခြင်း

```bash
python -m venv venv
```

## -1- အတုပတ်ဝန်းကျင်ကို ဖွင့်ခြင်း

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော အပေါ်မူများ 설치 လုပ်ခြင်း

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို chạy လုပ်ခြင်း

```bash
python client.py
```

အောက်ပါအတိုင်း အထွက်ရလဒ်ကို တွေ့ရပါမည်။

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူရင်းစာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုနိုင်သော အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် အကျွမ်းတဝင် လူသား ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။