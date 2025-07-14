<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-07-14T03:51:27+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "my"
}
-->
# သင်ခန်းစာ - Web Search MCP Server တည်ဆောက်ခြင်း

ဤအခန်းတွင် အပြင် API များနှင့် ပေါင်းစပ်၍ အမျိုးမျိုးသောဒေတာအမျိုးအစားများကို ကိုင်တွယ်နိုင်ပြီး အမှားများကို စနစ်တကျ စီမံခန့်ခွဲနိုင်သည့်၊ မျိုးစုံသောကိရိယာများကို တစ်ခုတည်းသော server တွင် စုပေါင်းအသုံးပြုနိုင်သည့် အမှန်တကယ် အသုံးပြုနိုင်သော AI agent တစ်ခုကို ဘယ်လိုတည်ဆောက်ရမည်ကို ပြသထားသည်။ သင်မြင်ရမည့်အချက်များမှာ -

- **အတည်ပြုချက်လိုအပ်သည့် အပြင် API များနှင့် ပေါင်းစပ်ခြင်း**
- **အမျိုးမျိုးသောဒေတာအမျိုးအစားများကို မျိုးစုံသော endpoint များမှ ကိုင်တွယ်ခြင်း**
- **ခိုင်မာသော အမှားစီမံခန့်ခွဲမှုနှင့် မှတ်တမ်းတင်နည်းများ**
- **တစ်ခုတည်းသော server တွင် မျိုးစုံကိရိယာများ စုပေါင်းအသုံးပြုခြင်း**

အဆုံးသတ်သည့်အချိန်တွင် သင်သည် အဆင့်မြင့် AI နှင့် LLM အခြေပြု application များအတွက် အရေးကြီးသော ပုံစံများနှင့် အကောင်းဆုံးလေ့လာမှုများကို လက်တွေ့ကျကျ အသုံးပြုနိုင်မည်ဖြစ်သည်။

## နိဒါန်း

ဤသင်ခန်းစာတွင် SerpAPI ကို အသုံးပြု၍ အချိန်နှင့်တပြေးညီ ဝက်ဘ်ဒေတာများဖြင့် LLM ၏ စွမ်းဆောင်ရည်များကို တိုးချဲ့ပေးသည့် အဆင့်မြင့် MCP server နှင့် client တည်ဆောက်နည်းကို သင်ယူမည်ဖြစ်သည်။ ၎င်းသည် ဝက်ဘ်မှ နောက်ဆုံးရသတင်းအချက်အလက်များကို ရယူနိုင်သည့် dynamic AI agent များ ဖန်တီးရာတွင် အရေးကြီးသော ကျွမ်းကျင်မှုတစ်ခုဖြစ်သည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးတွင် သင်သည် -

- SerpAPI ကဲ့သို့သော အပြင် API များကို MCP server တွင် လုံခြုံစွာ ပေါင်းစပ်နိုင်မည်
- ဝက်ဘ်၊ သတင်း၊ ထုတ်ကုန်ရှာဖွေရေးနှင့် Q&A အတွက် မျိုးစုံကိရိယာများကို အကောင်အထည်ဖော်နိုင်မည်
- LLM အသုံးပြုမှုအတွက် ဖွဲ့စည်းထားသော ဒေတာများကို ဖော်ပြနိုင်မည်
- အမှားများကို ကိုင်တွယ်နိုင်ပြီး API rate limit များကို ထိရောက်စွာ စီမံနိုင်မည်
- အလိုအလျောက်နှင့် အပြန်အလှန် client များကို တည်ဆောက်၍ စမ်းသပ်နိုင်မည်

## Web Search MCP Server

ဤအပိုင်းတွင် Web Search MCP Server ၏ ဖွဲ့စည်းပုံနှင့် လုပ်ဆောင်ချက်များကို မိတ်ဆက်ပေးမည်ဖြစ်သည်။ FastMCP နှင့် SerpAPI ကို ပေါင်းစပ်၍ LLM ၏ စွမ်းဆောင်ရည်များကို အချိန်နှင့်တပြေးညီ ဝက်ဘ်ဒေတာဖြင့် တိုးချဲ့ပုံကို ကြည့်ရှုနိုင်မည်ဖြစ်သည်။

### အနှစ်ချုပ်

ဤအကောင်အထည်ဖော်မှုတွင် MCP ၏ လုံခြုံပြီး ထိရောက်စွာ အပြင် API များမှ တာဝန်များကို ကိုင်တွယ်နိုင်မှုကို ပြသသည့် ကိရိယာလေးခု ပါဝင်သည် -

- **general_search**: အထွေထွေ ဝက်ဘ် ရလဒ်များအတွက်
- **news_search**: နောက်ဆုံးရ သတင်းခေါင်းစဉ်များအတွက်
- **product_search**: အီလက်ထရွန်းနစ် ကုန်ပစ္စည်းများအတွက်
- **qna**: မေးခွန်းနှင့် ဖြေကြားချက်များအတွက်

### လုပ်ဆောင်ချက်များ
- **ကုဒ်နမူနာများ**: Python အတွက် (နှင့် အခြားဘာသာစကားများသို့ လွယ်ကူစွာ တိုးချဲ့နိုင်သည်) collapsible အပိုင်းများဖြင့် ဖော်ပြထားသည်

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

client ကို run မလုပ်မီ server ၏ လုပ်ဆောင်ချက်ကို နားလည်ထားသင့်သည်။ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ဖိုင်တွင် MCP server ကို အကောင်အထည်ဖော်ထားပြီး SerpAPI နှင့် ပေါင်းစပ်၍ ဝက်ဘ်၊ သတင်း၊ ထုတ်ကုန်ရှာဖွေရေးနှင့် Q&A ကိရိယာများကို ဖော်ပြထားသည်။ ၎င်းသည် လာရောက်သော တောင်းဆိုမှုများကို ကိုင်တွယ်ပြီး API ခေါ်ဆိုမှုများကို စီမံကိန်းဆွဲ၊ တုံ့ပြန်ချက်များကို ဖော်ပြပြီး ဖောက်သည်ထံ သတ်မှတ်ထားသော ဖော်မတ်ဖြင့် ပြန်လည်ပေးပို့သည်။

[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) တွင် အပြည့်အစုံ implementation ကို ကြည့်ရှုနိုင်သည်။

server သည် ကိရိယာတစ်ခုကို ဘယ်လို သတ်မှတ်ပြီး မှတ်ပုံတင်ထားသည်ကို အနည်းငယ် ဥပမာ -

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **အပြင် API ပေါင်းစပ်ခြင်း**: API key များနှင့် အပြင်တောင်းဆိုမှုများကို လုံခြုံစွာ ကိုင်တွယ်ပုံ ပြသသည်
- **ဖွဲ့စည်းထားသော ဒေတာ ဖော်ပြခြင်း**: API တုံ့ပြန်ချက်များကို LLM အတွက် သင့်တော်သော ဖော်မတ်သို့ ပြောင်းလဲပုံ
- **အမှားစီမံခန့်ခွဲမှု**: သင့်တော်သော မှတ်တမ်းတင်မှုနှင့် အတူ ခိုင်မာသော အမှားစီမံခန့်ခွဲမှု
- **အပြန်အလှန် Client**: အလိုအလျောက် စမ်းသပ်မှုများနှင့် အပြန်အလှန် စမ်းသပ်မှု များပါဝင်သည်
- **Context စီမံခန့်ခွဲမှု**: MCP Context ကို အသုံးပြု၍ မှတ်တမ်းတင်ခြင်းနှင့် တောင်းဆိုမှုများကို လိုက်လံခြင်း

## မတိုင်မီ လိုအပ်ချက်များ

စတင်မလုပ်မီ သင့်ပတ်ဝန်းကျင်ကို အောက်ပါအတိုင်း ပြင်ဆင်ထားရန် လိုအပ်သည်။ ၎င်းသည် လိုအပ်သော dependency များအားလုံး ထည့်သွင်းပြီး API key များကို မှန်ကန်စွာ ပြင်ဆင်ထားရန် အထောက်အကူပြုမည်ဖြစ်သည်။

- Python 3.8 သို့မဟုတ် အထက်
- SerpAPI API Key (အခမဲ့ tier ရရှိနိုင်သည့် [SerpAPI](https://serpapi.com/) တွင် စာရင်းသွင်းရန်)

## တပ်ဆင်ခြင်း

စတင်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ -

1. uv (အကြံပြု) သို့မဟုတ် pip ဖြင့် dependency များ တပ်ဆင်ပါ -

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. project root တွင် `.env` ဖိုင်တစ်ခု ဖန်တီးပြီး သင့် SerpAPI key ကို ထည့်သွင်းပါ -

```
SERPAPI_KEY=your_serpapi_key_here
```

## အသုံးပြုနည်း

Web Search MCP Server သည် SerpAPI နှင့် ပေါင်းစပ်၍ ဝက်ဘ်၊ သတင်း၊ ထုတ်ကုန်ရှာဖွေရေးနှင့် Q&A ကိရိယာများကို ဖော်ပြသည့် အဓိက component ဖြစ်သည်။ ၎င်းသည် လာရောက်သော တောင်းဆိုမှုများကို ကိုင်တွယ်ပြီး API ခေါ်ဆိုမှုများကို စီမံကိန်းဆွဲ၊ တုံ့ပြန်ချက်များကို ဖော်ပြပြီး ဖောက်သည်ထံ သတ်မှတ်ထားသော ဖော်မတ်ဖြင့် ပြန်လည်ပေးပို့သည်။

[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) တွင် အပြည့်အစုံ implementation ကို ကြည့်ရှုနိုင်သည်။

### Server ကို စတင်ခြင်း

MCP server ကို စတင်ရန် အောက်ပါ command ကို အသုံးပြုပါ -

```bash
python server.py
```

server သည် stdio-based MCP server အဖြစ် run ဖြစ်ပြီး client သည် တိုက်ရိုက် ချိတ်ဆက်နိုင်မည်ဖြစ်သည်။

### Client Mode များ

client (`client.py`) သည် MCP server နှင့် ဆက်သွယ်ရန် mode နှစ်မျိုးကို ထောက်ပံ့သည် -

- **Normal mode**: ကိရိယာအားလုံးကို စမ်းသပ်ပြီး တုံ့ပြန်ချက်များကို စစ်ဆေးသည့် အလိုအလျောက် စမ်းသပ်မှုများ run လုပ်သည်။ server နှင့် ကိရိယာများမှန်ကန်စွာ လုပ်ဆောင်နေကြောင်း အမြန်စစ်ဆေးရန် အသုံးဝင်သည်။
- **Interactive mode**: မီနူးအခြေပြု အင်တာဖေ့စ်ကို စတင်ပြီး သင်ကိုယ်တိုင် ကိရိယာများကို ရွေးချယ်ခေါ်ယူနိုင်ပြီး မိမိစိတ်ကြိုက် မေးခွန်းများ ထည့်သွင်း၍ ရလဒ်များကို အချိန်နှင့်တပြေးညီ ကြည့်ရှုနိုင်သည်။ server ၏ စွမ်းဆောင်ရည်များကို စူးစမ်းရန်နှင့် input များကို စမ်းသပ်ရန် အထူးသင့်တော်သည်။

[`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) တွင် အပြည့်အစုံ implementation ကို ကြည့်ရှုနိုင်သည်။

### Client ကို run လုပ်ခြင်း

အလိုအလျောက် စမ်းသပ်မှုများ run လုပ်ရန် (server ကို အလိုအလျောက် စတင်မည်) -

```bash
python client.py
```

သို့မဟုတ် interactive mode ဖြင့် run လုပ်ရန် -

```bash
python client.py --interactive
```

### မတူညီသော နည်းလမ်းများဖြင့် စမ်းသပ်ခြင်း

server မှ ပေးသော ကိရိယာများကို သင့်လိုအပ်ချက်နှင့် workflow အပေါ် မူတည်၍ စမ်းသပ်ရန် နည်းလမ်းများ များစွာ ရှိသည်။

#### MCP Python SDK ဖြင့် ကိုယ်ပိုင် စမ်းသပ် script များရေးသားခြင်း

MCP Python SDK ကို အသုံးပြု၍ ကိုယ်ပိုင် စမ်းသပ် script များ ဖန်တီးနိုင်သည် -

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

ဤအခြေအနေတွင် "စမ်းသပ် script" ဆိုသည်မှာ MCP server အတွက် client အဖြစ် သင်ရေးသားသည့် ကိုယ်ပိုင် Python program ဖြစ်သည်။ ၎င်းသည် တရားဝင် unit test မဟုတ်ပေမယ့် server နှင့် ချိတ်ဆက်၍ သင့်လိုအပ်သည့် parameter များဖြင့် ကိရိယာများကို ခေါ်ယူနိုင်ပြီး ရလဒ်များကို စစ်ဆေးနိုင်သည်။ ဤနည်းလမ်းသည် -

- ကိရိယာခေါ်ယူမှုများကို စမ်းသပ်ရန်နှင့် စမ်းသပ်မှုများ ပြုလုပ်ရန်
- server ၏ တုံ့ပြန်မှုများကို အတိအကျ စစ်ဆေးရန်
- ကိရိယာများကို အလိုအလျောက် ခေါ်ယူမှုများ ပြုလုပ်ရန်
- MCP server အပေါ် ကိုယ်ပိုင် workflow များ သို့မဟုတ် ပေါင်းစပ်မှုများ တည်ဆောက်ရန်

သင်သည် စမ်းသပ် script များကို အသုံးပြု၍ မေးခွန်းအသစ်များကို အမြန်စမ်းသပ်နိုင်ပြီး ကိရိယာများ၏ အပြုအမူကို ပြန်လည်စစ်ဆေးနိုင်သည်။ အောက်တွင် MCP Python SDK ကို အသုံးပြု၍ စမ်းသပ် script တစ်ခု ဖန်တီးနည်း ဥပမာကို ဖော်ပြထားသည်။

## ကိရိယာ ဖော်ပြချက်များ

server မှ ပေးသော ကိရိယာများကို အသုံးပြု၍ မတူညီသော ရှာဖွေရေးနှင့် မေးခွန်းဖြေဆိုမှုများ ပြုလုပ်နိုင်သည်။ ကိရိယာတိုင်းကို ၎င်း၏ parameter များနှင့် အသုံးပြုနည်း ဥပမာများနှင့်အတူ ဖော်ပြထားသည်။

ဤအပိုင်းတွင် ရရှိနိုင်သည့် ကိရိယာများနှင့် ၎င်းတို့၏ parameter များအကြောင်း အသေးစိတ် ဖော်ပြထားသည်။

### general_search

အထွေထွေ ဝက်ဘ်ရှာဖွေရေး ပြုလုပ်ပြီး ဖော်မတ်ပြုထားသော ရလဒ်များ ပြန်ပေးသည်။

**ဤကိရိယာကို ဘယ်လိုခေါ်မလဲ**

MCP Python SDK ကို အသုံးပြု၍ သင့်ကိုယ်ပိုင် script မှ `general_search` ကို ခေါ်ယူနိုင်သည်၊ သို့မဟုတ် Inspector သို့မဟုတ် interactive client mode မှတစ်ဆင့် လည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုနည်း ဥပမာ -

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

သို့မဟုတ် interactive mode တွင် မီနူးမှ `general_search` ကို ရွေးချယ်ပြီး မေးခွန်းကို ထည့်သွင်းနိုင်သည်။

**Parameter များ:**
- `query` (string): ရှာဖွေရေး မေးခွန်း

**ဥပမာ တောင်းဆိုမှု:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

မေးခွန်းနှင့် သက်ဆိုင်သော နောက်ဆုံးရ သတင်းဆောင်းပါးများကို ရှာဖွေသည်။

**ဤကိရိယာကို ဘယ်လိုခေါ်မလဲ**

MCP Python SDK ကို အသုံးပြု၍ သင့်ကိုယ်ပိုင် script မှ `news_search` ကို ခေါ်ယူနိုင်သည်၊ သို့မဟုတ် Inspector သို့မဟုတ် interactive client mode မှတစ်ဆင့် လည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုနည်း ဥပမာ -

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

သို့မဟုတ် interactive mode တွင် မီနူးမှ `news_search` ကို ရွေးချယ်ပြီး မေးခွန်းကို ထည့်သွင်းနိုင်သည်။

**Parameter များ:**
- `query` (string): ရှာဖွေရေး မေးခွန်း

**ဥပမာ တောင်းဆိုမှု:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

မေးခွန်းနှင့် ကိုက်ညီသည့် ထုတ်ကုန်များကို ရှာဖွေသည်။

**ဤကိရိယာကို ဘယ်လိုခေါ်မလဲ**

MCP Python SDK ကို အသုံးပြု၍ သင့်ကိုယ်ပိုင် script မှ `product_search` ကို ခေါ်ယူနိုင်သည်၊ သို့မဟုတ် Inspector သို့မဟုတ် interactive client mode မှတစ်ဆင့် လည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုနည်း ဥပမာ -

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

သို့မဟုတ် interactive mode တွင် မီနူးမှ `product_search` ကို ရွေးချယ်ပြီး မေးခွန်းကို ထည့်သွင်းနိုင်သည်။

**Parameter များ:**
- `query` (string): ထုတ်ကုန်ရှာဖွေရေး မေးခွန်း

**ဥပမာ တောင်းဆိုမှု:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

ရှာဖွေရေးအင်ဂျင်များမှ မေးခွန်းများအတွက် တိုက်ရိုက်ဖြေကြားချက်များ ရယူသည်။

**ဤကိရိယာကို ဘယ်လိုခေါ်မလဲ**

MCP Python SDK ကို အသုံးပြု၍ သင့်ကိုယ်ပိုင် script မှ `qna` ကို ခေါ်ယူနိုင်သည်၊ သို့မဟုတ် Inspector သို့မဟုတ် interactive client mode မှတစ်ဆင့် လည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုနည်း ဥပမာ -

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

သို့မဟုတ် interactive mode တွင် မီနူးမှ `qna` ကို ရွေးချယ်ပြီး မေးခွန်းကို ထည့်သွင်းနိုင်သည်။

**Parameter များ:**
- `question` (string): ဖြေကြားချက် ရှာဖွေရန် မေးခွန်း

**ဥပမာ တောင်းဆိုမှု:**

```json
{
  "question": "what is artificial intelligence"
}
```

## ကုဒ်အသေးစိတ်

ဤအပိုင်းတွင် server နှင့် client implementation များအတွက် ကုဒ်နမူနာများနှင့် ကိုးကားချက်များ ပါဝင်သည်။

<details>
<summary>Python</summary>

အပြ

<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## နောက်တစ်ဆင့်

- [5.10 အချိန်နှင့်တပြေးညီ စီးဆင်းမှု](../mcp-realtimestreaming/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများ သို့မဟုတ် မှားဖတ်ရှုမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။