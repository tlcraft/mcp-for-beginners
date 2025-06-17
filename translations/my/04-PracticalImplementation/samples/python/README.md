<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-06-17T17:05:42+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "my"
}
-->
# Model Context Protocol (MCP) Python အကောင်အထည်ဖော်ခြင်း

ဤ repository တွင် Model Context Protocol (MCP) ကို Python ဖြင့် အကောင်အထည်ဖော်ထားပြီး MCP စံသတ်မှတ်ချက်ကို အသုံးပြု၍ ဆာဗာနှင့် client အပလီကေးရှင်းများကို ဘယ်လိုဖန်တီးမလဲ ဆိုတာကို ပြသထားသည်။

## အနှစ်ချုပ်

MCP အကောင်အထည်ဖော်မှုတွင် အဓိကအစိတ်အပိုင်းနှစ်ခု ပါဝင်သည်-

1. **MCP Server (`server.py`)** - ဆာဗာတစ်ခုဖြစ်ပြီး အောက်ပါအရာများကို ဖော်ပြသည်-
   - **Tools**: ဝေးလံမှခေါ်ယူနိုင်သော function များ
   - **Resources**: ရယူနိုင်သော ဒေတာများ
   - **Prompts**: ဘာသာစကားမော်ဒယ်များအတွက် prompt များ ဖန်တီးရန် စာသားပုံစံများ

2. **MCP Client (`client.py`)** - ဆာဗာနှင့် ချိတ်ဆက်ပြီး ၎င်း၏ အင်္ဂါရပ်များကို အသုံးပြုသော client အပလီကေးရှင်း

## အင်္ဂါရပ်များ

ဤအကောင်အထည်ဖော်မှုသည် MCP ၏ အဓိကအင်္ဂါရပ်အချို့ကို ပြသသည်-

### Tools
- `completion` - AI မော်ဒယ်များမှ စာသားဖြည့်စွက်မှုများ ဖန်တီးသည် (သရုပ်ပြ)
- `add` - နံပါတ်နှစ်ခုကို ပေါင်းထည့်သော ရိုးရှင်းသော ကိန်းဂဏန်းတွက်စက်

### Resources
- `models://` - ရနိုင်သော AI မော်ဒယ်များအကြောင်း အချက်အလက် ပြန်ပေးသည်
- `greeting://{name}` - နာမည်တစ်ခုအတွက် ပုဂ္ဂိုလ်ရေးဂရိတ်တင်စာ ပြန်ပေးသည်

### Prompts
- `review_code` - ကုဒ်ကို သုံးသပ်ရန် prompt ဖန်တီးသည်

## ထည့်သွင်းမှု

ဤ MCP အကောင်အထည်ဖော်မှုကို အသုံးပြုရန် အောက်ပါ package များကို ထည့်သွင်းပါ-

```powershell
pip install mcp-server mcp-client
```

## ဆာဗာနှင့် Client ကို စတင်မည့်နည်းလမ်း

### ဆာဗာ စတင်ခြင်း

တစ်ခုသော terminal ပေါ်တွင် ဆာဗာကို run ပါ-

```powershell
python server.py
```

MCP CLI ကို အသုံးပြု၍ ဖွံ့ဖြိုးရေး mode ဖြင့်လည်း run နိုင်သည်-

```powershell
mcp dev server.py
```

သို့မဟုတ် Claude Desktop တွင် ထည့်သွင်းထားလျှင် run နိုင်သည်-

```powershell
mcp install server.py
```

### Client ကို run မည်

Terminal တစ်ခုတွင် client ကို run ပါ-

```powershell
python client.py
```

ဤသည်က ဆာဗာနှင့် ချိတ်ဆက်ပြီး ရနိုင်သည့် အင်္ဂါရပ်အားလုံးကို ပြသမည်။

### Client အသုံးပြုမှု

Client (`client.py`) သည် MCP ၏ စွမ်းဆောင်ရည်များအားလုံးကို ပြသသည်-

```powershell
python client.py
```

ဤသည်က ဆာဗာနှင့် ချိတ်ဆက်ပြီး tools, resources, prompts အပါအဝင် အင်္ဂါရပ်အားလုံးကို အသုံးပြုမည်။ ထွက်ရှိမှုတွင်-

1. ကိန်းဂဏန်းတွက်စက်ရလဒ် (5 + 7 = 12)
2. "What is the meaning of life?" ဆိုသော စာသားအတွက် ဖြည့်စွက်မှုတုံ့ပြန်ချက်
3. ရနိုင်သော AI မော်ဒယ်များစာရင်း
4. "MCP Explorer" အတွက် ပုဂ္ဂိုလ်ရေးဂရိတ်တင်စာ
5. ကုဒ်သုံးသပ်မှု prompt ပုံစံ

## အကောင်အထည်ဖော်မှု အသေးစိတ်

ဆာဗာကို `FastMCP` API အသုံးပြု၍ အကောင်အထည်ဖော်ထားပြီး MCP ဝန်ဆောင်မှုများ သတ်မှတ်ရန် အဆင့်မြင့် abstraction များ ပေးသည်။ Tools များ သတ်မှတ်ပုံကို ရိုးရှင်းစွာ ပြထားသည်-

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Client သည် MCP client library ကို အသုံးပြု၍ ဆာဗာနှင့် ချိတ်ဆက်ပြီး ခေါ်ယူသည်-

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## ပိုမိုသိရှိလိုပါက

MCP အကြောင်း ပိုမိုသိရှိရန် https://modelcontextprotocol.io/ သို့ သွားရောက်ကြည့်ရှုနိုင်သည်။

**ချက်ပြုတ်ချက်**:  
ဤစာရွက်ကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း အလိုအလျောက်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူလစာရွက်ကို မိခင်ဘာသာဖြင့်သာ ယုံကြည်စိတ်ချရသော အရင်းအမြစ်အဖြစ် သတ်မှတ်စဉ်းစားသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူကြီးမင်းတို့အား ပရော်ဖက်ရှင်နယ်လူသားဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာသော မျှော်လင့်ချက်မတူမှုများ သို့မဟုတ် မှားယွင်းဖော်ပြချက်များအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။