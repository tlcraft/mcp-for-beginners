<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-17T16:53:07+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "my"
}
-->
# သင်ခန်းစာ - Web Search MCP Server တည်ဆောက်ခြင်း

ဒီအခန်းက သင်ကို ပြသပေးမှာကတော့ ပြင်ပ API တွေနဲ့ ပေါင်းစည်းပြီး၊ အမျိုးမျိုးသော ဒေတာအမျိုးအစားများကို ကိုင်တွယ်နိုင်ပြီး၊ အမှားများကို စီမံခန့်ခွဲနိုင်ကာ၊ အမျိုးမျိုးသော ကိရိယာများကို တစ်ခါတည်း စီမံခန့်ခွဲနိုင်တဲ့ စက်ရုံအဆင့် AI agent တစ်ခုကို ဘယ်လိုတည်ဆောက်ရမလဲ ဆိုတာပါ။ သင်တွေ့မြင်ရမယ့်အချက်တွေကတော့ -

- **အတည်ပြုမှုလိုအပ်တဲ့ ပြင်ပ API တွေနဲ့ ပေါင်းစည်းခြင်း**
- **အမျိုးမျိုးသော ဒေတာအမျိုးအစားများကို အချက်အလက်ရယူမှု**
- **ခိုင်မာပြီး ထိရောက်တဲ့ အမှားစီမံခန့်ခွဲမှုနဲ့ မှတ်တမ်းတင်နည်းများ**
- **တစ်ခုတည်းသော server မှာ ကိရိယာအမျိုးမျိုး စီမံခန့်ခွဲမှု**

အဆုံးသတ်မှာတော့ LLM နှင့် AI အခြေပြု application များအတွက် အရေးကြီးသော ပုံစံများနှင့် အကောင်းဆုံး လေ့လာမှုတွေကို လက်တွေ့အသုံးချနိုင်မယ်။

## နိဒါန်း

ဒီသင်ခန်းစာမှာ သင်တွေ့မြင်မှာက MCP server နဲ့ client တို့ကို LLM ၏ စွမ်းဆောင်ရည်များကို SerpAPI အသုံးပြု၍ အချိန်နဲ့တပြေးညီ အင်တာနက်ဒေတာဖြင့် တိုးချဲ့တည်ဆောက်နည်းပါ။ ဒီစွမ်းရည်ကတော့ ဝက်ဘ်မှ အချိန်နဲ့တပြေးညီ သတင်းအချက်အလက်များကို ရယူနိုင်တဲ့ dynamic AI agents တည်ဆောက်ရာမှာ အရေးကြီးပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးတဲ့အချိန်မှာ သင်အောက်ပါအရာများကို ပြုလုပ်နိုင်မှာဖြစ်ပါတယ် -

- SerpAPI ကဲ့သို့သော ပြင်ပ API များကို MCP server ထဲသို့ လုံခြုံစွာ ပေါင်းစည်းနိုင်ခြင်း
- ဝက်ဘ်၊ သတင်း၊ ကုန်ပစ္စည်းရှာဖွေရေးနဲ့ Q&A အတွက် ကိရိယာများစွာ တည်ဆောက်အသုံးပြုနိုင်ခြင်း
- LLM အတွက် အသုံးပြုနိုင်သော ပုံစံသို့ အချက်အလက်များကို ဖော်ပြနိုင်ခြင်း
- အမှားများကို စနစ်တကျ ကိုင်တွယ်နိုင်ပြီး API rate limit များကို ထိရောက်စွာ စီမံနိုင်ခြင်း
- Automated နဲ့ interactive MCP clients နှစ်မျိုးစလုံး တည်ဆောက်ပြီး စမ်းသပ်နိုင်ခြင်း

## Web Search MCP Server

ဒီပိုင်းမှာ Web Search MCP Server ၏ စနစ်တည်ဆောက်ပုံနဲ့ လုပ်ဆောင်ချက်များကို မိတ်ဆက်ပေးမှာပါ။ FastMCP နဲ့ SerpAPI တို့ကို တွဲဖက် အသုံးပြုကာ LLM ၏ စွမ်းဆောင်ရည်ကို အချိန်နဲ့တပြေးညီ ဝက်ဘ်ဒေတာဖြင့် တိုးချဲ့ပုံကို တွေ့မြင်ရပါမယ်။

### အနှစ်ချုပ်

ဒီ implementation မှာ MCP ၏ လုံခြုံပြီး ထိရောက်စွာ ပြင်ပ API အခြေပြု လုပ်ဆောင်ချက်များကို ကိုင်တွယ်နိုင်စွမ်းကို ပြသတဲ့ ကိရိယာ ၄ ခုပါဝင်ပါတယ် -

- **general_search**: အထွေထွေ ဝက်ဘ် ရလဒ်များအတွက်
- **news_search**: နောက်ဆုံးရ သတင်းခေါင်းစဉ်များအတွက်
- **product_search**: အီလက်ထရွန်းနစ် ကုန်ပစ္စည်းများအတွက်
- **qna**: မေးခွန်းနှင့် ဖြေဆိုချက်များအတွက်

### လက္ခဏာများ
- **Code Examples**: Python အတွက် အထူးသီးသန့် code blocks များပါဝင်ပြီး အခြား programming ဘာသာစကားများအတွက်လည်း လွယ်ကူစွာ ချဲ့ထွင်နိုင်ပါတယ်။ ရိုးရှင်းမှုအတွက် collapsible sections ဖြင့် ဖော်ပြထားသည်။

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

client ကို run မလုပ်ခင် server ရဲ့ လုပ်ဆောင်ချက်ကို နားလည်ထားရင် ကောင်းပါတယ်။ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ကို ကြည့်ပါ။

server မှာ tool တစ်ခုကို ဘယ်လို သတ်မှတ်ပြီး register လုပ်ထားတာလဲဆိုတာ ရိုးရှင်းစွာ ဥပမာ -

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

- **ပြင်ပ API ပေါင်းစည်းမှု**: API key များနှင့် ပြင်ပ request များကို လုံခြုံစွာ ကိုင်တွယ်ခြင်းကို ပြသသည်
- **ဖွဲ့စည်းထားသော ဒေတာ ပေါ်လာခြင်း**: API response များကို LLM အတွက် သင့်တော်သော ပုံစံသို့ ပြောင်းလဲခြင်း
- **အမှားစီမံခန့်ခွဲမှု**: ခိုင်မာပြီး သင့်တော်သော logging ဖြင့် အမှားများကို ကိုင်တွယ်ခြင်း
- **အပြန်အလှန် client**: Automated test များနှင့် interactive mode ကို ပါဝင်စေခြင်း
- **Context စီမံခန့်ခွဲမှု**: MCP Context ကို အသုံးပြု၍ logging နှင့် request tracking ပြုလုပ်ခြင်း

## မတိုင်မီလိုအပ်ချက်များ

စတင်မလုပ်ခင် သင့်ပတ်ဝန်းကျင်ကို အောက်ပါအတိုင်း ပြင်ဆင်ထားဖို့ လိုပါတယ်။ ဒါက dependencies များအားလုံး ထည့်သွင်းပြီး API key များကိုမှန်ကန်စွာ configure လုပ်ထားခြင်းဖြစ်ပါတယ်။

- Python 3.8 သို့မဟုတ် အထက်
- SerpAPI API Key (အခမဲ့ tier ရရှိနိုင်တဲ့ [SerpAPI](https://serpapi.com/) တွင် စာရင်းသွင်းပါ)

## 설치방법

စတင်ဖို့အတွက် အောက်ပါအဆင့်များအတိုင်း သင့်ပတ်ဝန်းကျင်ကို ပြင်ဆင်ပါ။

1. uv (အကြံပြု) သို့မဟုတ် pip ဖြင့် dependencies များ install လုပ်ပါ။

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Project root မှာ `.env` ဖိုင်တစ်ခု ဖန်တီးပြီး SerpAPI key ထည့်ပါ။

```
SERPAPI_KEY=your_serpapi_key_here
```

## အသုံးပြုနည်း

Web Search MCP Server သည် SerpAPI ဖြင့် ဝက်ဘ်၊ သတင်း၊ ကုန်ပစ္စည်းရှာဖွေရေးနဲ့ Q&A ကိရိယာများကို ဖော်ပြပေးသော အဓိက component ဖြစ်သည်။ request များကို လက်ခံပြီး API call များကို စီမံခန့်ခွဲ၊ response များကို parse လုပ်ကာ client သို့ အစီအစဉ်တကျ ပြန်လည်ပေးပို့သည်။

အပြည့်အစုံ implementation ကို [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) တွင် ကြည့်ရှုနိုင်ပါသည်။

### Server ကို run ချခြင်း

MCP server ကို စတင်ရန် အောက်ပါ command ကို အသုံးပြုပါ။

```bash
python server.py
```

server သည် stdio-based MCP server အဖြစ် run ပါမည်၊ client သည် တိုက်ရိုက် ချိတ်ဆက်နိုင်ပါသည်။

### Client Mode များ

client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)။

### Client ကို run ချခြင်း

Automated test များ run ချရန် (server ကို အလိုအလျောက် စတင်ပါမည်) -

```bash
python client.py
```

သို့မဟုတ် interactive mode ဖြင့် -

```bash
python client.py --interactive
```

### မတူညီသော နည်းလမ်းများဖြင့် စမ်းသပ်ခြင်း

server မှ ပေးသော ကိရိယာများကို သင့်လိုအပ်ချက်နှင့် workflow အရ စမ်းသပ်ဖို့ နည်းလမ်းအမျိုးမျိုး ရှိပါတယ်။

#### MCP Python SDK ဖြင့် ကိုယ်ပိုင် စမ်းသပ်ရေး Script များရေးခြင်း

MCP Python SDK ကို အသုံးပြုပြီး ကိုယ်ပိုင် စမ်းသပ်ရေး script များလည်း ရေးနိုင်ပါသည်။

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

ဒီ context မှာ "test script" ဆိုတာ MCP server အတွက် client အဖြစ် တာဝန်ယူဖို့ သင်ရေးသားတဲ့ ကိုယ်ပိုင် Python program ကို ဆိုလိုပါတယ်။ Formal unit test မဟုတ်ပေမယ့် server ကို programmatically ချိတ်ဆက်ကာ parameter များဖြင့် ကိရိယာများကို ခေါ်ပြီး ရလဒ်များကို စစ်ဆေးနိုင်ပါတယ်။ ဒီနည်းလမ်းက -

- ကိရိယာခေါ်ဆိုမှုများကို prototype ပြုလုပ်ခြင်းနှင့် စမ်းသပ်ခြင်း
- server ၏ input များအပေါ် ပြန်လည်တုံ့ပြန်မှုကို အတည်ပြုခြင်း
- ကိရိယာများကို ဆက်တိုက်ခေါ်ဆိုခြင်းကို အလိုအလျောက် ပြုလုပ်ခြင်း
- MCP server အပေါ် ကိုယ်ပိုင် workflow များ သို့မဟုတ် ပေါင်းစည်းမှုများ တည်ဆောက်ခြင်း

သင့်စမ်းသပ်ရေး script များကို အသုံးပြုပြီး မေးခွန်းအသစ်များကို အမြန်စမ်းသပ်၊ ကိရိယာအပြုအမူများကို ပြန်လည်စစ်ဆေး၊ သို့မဟုတ် အဆင့်မြင့် automation များအတွက် အစအနစ်အဖြစ် အသုံးချနိုင်ပါသည်။ အောက်တွင် MCP Python SDK အသုံးပြုပြီး စမ်းသပ်ရေး script တစ်ခု ဖန်တီးနည်း ဥပမာပါရှိသည်။

## ကိရိယာ ဖော်ပြချက်များ

server မှ ပေးသော ကိရိယာများကို အသုံးပြုပြီး မတူညီသော ရှာဖွေရေးနဲ့ မေးမြန်းမှုများ ပြုလုပ်နိုင်သည်။ တစ်ခုချင်းစီကို parameter များနဲ့ အသုံးပြုနည်းကို ဖော်ပြထားသည်။

### general_search

အထွေထွေ ဝက်ဘ်ရှာဖွေရေး ပြုလုပ်ပြီး ဖော်ပြထားသော ရလဒ်များ ပြန်ပေးသည်။

**ကိရိယာကို ဘယ်လိုခေါ်မလဲ:**

MCP Python SDK ကို သုံးပြီး ကိုယ်ပိုင် script မှာ `general_search` ကို ခေါ်နိုင်ပြီး၊ Inspector သို့မဟုတ် interactive client mode မှာလည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုမှု ဥပမာ -

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

သို့မဟုတ် interactive mode မှာ `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ရှာဖွေမည့် စကားလုံး

**ဥပမာ Request:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

မကြာသေးမီ သတင်းဆောင်းပါးများကို ရှာဖွေသည်။

**ကိရိယာကို ဘယ်လိုခေါ်မလဲ:**

MCP Python SDK ကို သုံးပြီး ကိုယ်ပိုင် script မှာ `news_search` ကို ခေါ်နိုင်ပြီး၊ Inspector သို့မဟုတ် interactive client mode မှာလည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုမှု ဥပမာ -

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

သို့မဟုတ် interactive mode မှာ `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ရှာဖွေမည့် စကားလုံး

**ဥပမာ Request:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

မေးခွန်းနှင့် ကိုက်ညီသော ကုန်ပစ္စည်းများကို ရှာဖွေသည်။

**ကိရိယာကို ဘယ်လိုခေါ်မလဲ:**

MCP Python SDK ကို သုံးပြီး ကိုယ်ပိုင် script မှာ `product_search` ကို ခေါ်နိုင်ပြီး၊ Inspector သို့မဟုတ် interactive client mode မှာလည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုမှု ဥပမာ -

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

သို့မဟုတ် interactive mode မှာ `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ကုန်ပစ္စည်းရှာဖွေရေး စကားလုံး

**ဥပမာ Request:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

ရှာဖွေမှုစက်များမှ မေးခွန်းများအတွက် တိုက်ရိုက်ဖြေချက်များ ရယူသည်။

**ကိရိယာကို ဘယ်လိုခေါ်မလဲ:**

MCP Python SDK ကို သုံးပြီး ကိုယ်ပိုင် script မှာ `qna` ကို ခေါ်နိုင်ပြီး၊ Inspector သို့မဟုတ် interactive client mode မှာလည်း အသုံးပြုနိုင်သည်။ SDK အသုံးပြုမှု ဥပမာ -

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

သို့မဟုတ် interactive mode မှာ `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): ဖြေဆိုချက် ရယူလိုသော မေးခွန်း

**ဥပမာ Request:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Code အသေးစိတ်

ဒီပိုင်းမှာ server နဲ့ client implementation များအတွက် code snippet များနဲ့ အညွှန်းများ ပါဝင်သည်။

<details>
<summary>Python</summary>

ပြည့်စုံသော implementation ကို [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) တွင် ကြည့်ရှုနိုင်ပါသည်။

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## ဒီသင်ခန်းစာ၏ အဆင့်မြင့်အယူအဆများ

တည်ဆောက်မှု စတင်မလုပ်ခင် ဒီအချက်အချာများကို နားလည်ထားပါ။ ဒီအယူအဆများကို သိရှိထားခြင်းက သင်အနေနဲ့ သင်ခန်းစာကို လိုက်နာနားလည်ဖို့ အထောက်အကူဖြစ်စေပါလိမ့်မယ် -

- **Multi-tool Orchestration**: Web search, news search, product search, Q&A ကိရိယာ အမျိုးမျိုးကို တစ်ခုတည်း MCP server ထဲမှာ run လုပ်ခြင်းဖြစ်ပြီး၊ server သည် တစ်ခုထက် များစွာသော လုပ်ဆောင်ချက်များကို တစ်ပြိုင်နက်တည်း ဆောင်ရွက်နိုင်သည်။
- **API Rate Limit Handling**: SerpAPI ကဲ့သို့ ပြင်ပ API များမှာ တစ်ချိန်တည်း တောင်းဆိုမှု အရေအတွက်ကို ကန့်သတ်ထားသည်။ ကောင်းမွန်သော code များသည် ဒီကန့်သတ်ချက်များကို စစ်ဆေးပြီး သင့် app မပျက်စီးအောင် ထိရောက်စွာ ကိုင်တွယ်နိုင်သည်။
- **Structured Data Parsing**: API response များသည် မကြာခဏ ရှုပ်ထွေးပြီး nested ဖြစ်တတ်သည်။ ဒီအယူအဆကတော့ အဲဒီ response များကို LLM သို့မဟုတ် အခြား program များအတွက် သင့်တော်ပြီး သန့်ရှင်းသော ပုံစံသို့ ပြောင်းလဲခြင်း ဖြစ်သည်။
- **Error Recovery**: တစ်ခါတစ်ရံ network ပြဿနာ ဖြစ်ပေါ်ခြင်း၊ API မှ မမျှော်လင့်သော အချက်အလက် ပြန်လာခြင်း စသည့် ပြဿနာများ ဖြစ်ပေါ်နိုင်သည်။ Error recovery ဆိုတာ သင့် code က ဒီပြဿနာများကို ကိုင်တွယ်ပြီး app ပျက်မသွားစေရန် အကျိုးရှိသော feedback ပေးနိုင်ခြင်း ဖြစ်သည်။
- **Parameter Validation**: ကိရိယာများသို့ ဝင်ရောက်သည့် input များကို မှန်ကန်ပြီး လုံခြုံစိတ်ချရမှုရှိစေရန် စစ်ဆေးခြင်းဖြစ်သည်။ ဒီမှာ default value များသတ်မှတ်ခြင်းနဲ့ data type များကို စစ်ဆေးခြင်း ပါဝင်ပြီး bug မဖြစ်စေရန် ကူညီသည်။

ဒီပိုင်းက Web Search MCP Server တွင် ဖြစ်တတ်သော ပြဿနာများကို ရှာဖွေတွေ့ရှိပြီး ဖြေရှင်းနိုင်ရန် အကူအညီပေးပါမယ်။ ပြဿနာများ ရှိလာပါက ဒီ troubleshooting အပိုင်းကို စတင်ကြည့်ရှုပါ - အောက်ပါ အကြံပြုချက်များက အများဆုံး တွေ့ရသော ပြဿနာများကို ဖြေရှင်းပေးနိုင်ပါတယ်။

## ပြဿနာရှာဖွေရေး

Web Search MCP Server နှင့် အလုပ်လုပ်ရာတွင် အချို့အခါ ပြဿနာများ ကြုံတွေ့ရနိုင်သည်။ ဒီကဏ္ဍက အများ

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်စနစ်ဖြစ်သည့် [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် မှန်ကန်မှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိခင်ဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် သက်ဆိုင်ရာ ပညာရှင်လူသား ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှု အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းဖော်ပြချက်များအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။