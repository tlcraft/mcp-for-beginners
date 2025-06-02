<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:03:41+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ur"
}
-->
# سبق: ویب سرچ MCP سرور بنانا

یہ باب دکھاتا ہے کہ کیسے ایک حقیقی دنیا کا AI ایجنٹ بنایا جائے جو بیرونی APIs کے ساتھ مربوط ہو، مختلف قسم کے ڈیٹا کو سنبھالے، غلطیوں کا انتظام کرے، اور متعدد ٹولز کو منظم کرے—وہ بھی پروڈکشن کے قابل انداز میں۔ آپ دیکھیں گے:

- **بیرونی APIs کے ساتھ توثیق کے ساتھ انضمام**
- **متعدد اینڈپوائنٹس سے مختلف قسم کے ڈیٹا کو سنبھالنا**
- **مضبوط غلطی سنبھالنے اور لاگنگ حکمت عملی**
- **ایک ہی سرور میں متعدد ٹولز کا انتظام**

آخر میں، آپ کو عملی تجربہ حاصل ہوگا ان پیٹرنز اور بہترین طریقوں کا جو جدید AI اور LLM پر مبنی ایپلیکیشنز کے لیے ضروری ہیں۔

## تعارف

اس سبق میں، آپ سیکھیں گے کہ کیسے ایک جدید MCP سرور اور کلائنٹ بنایا جائے جو SerpAPI کے ذریعے حقیقی وقت کے ویب ڈیٹا کے ساتھ LLM صلاحیتوں کو بڑھاتا ہے۔ یہ ایک اہم مہارت ہے جو متحرک AI ایجنٹس بنانے کے لیے ضروری ہے جو ویب سے تازہ ترین معلومات حاصل کر سکیں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ کر سکیں گے:

- بیرونی APIs (جیسے SerpAPI) کو محفوظ طریقے سے MCP سرور میں ضم کرنا
- ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے لیے متعدد ٹولز کا نفاذ
- LLM کے استعمال کے لیے منظم شدہ ڈیٹا کو پارس اور فارمیٹ کرنا
- غلطیوں کا مؤثر انتظام اور API کی رفتار کی حدود کو سنبھالنا
- خودکار اور انٹرایکٹو MCP کلائنٹس کو بنانا اور ٹیسٹ کرنا

## ویب سرچ MCP سرور

یہ سیکشن ویب سرچ MCP سرور کی ساخت اور خصوصیات متعارف کراتا ہے۔ آپ دیکھیں گے کہ کیسے FastMCP اور SerpAPI کو مل کر LLM صلاحیتوں کو حقیقی وقت کے ویب ڈیٹا کے ساتھ بڑھانے کے لیے استعمال کیا جاتا ہے۔

### جائزہ

یہ نفاذ چار ٹولز پر مشتمل ہے جو MCP کی صلاحیت کو ظاہر کرتے ہیں کہ وہ متنوع، بیرونی API سے چلنے والے کاموں کو محفوظ اور مؤثر طریقے سے سنبھال سکتا ہے:

- **general_search**: وسیع ویب نتائج کے لیے
- **news_search**: تازہ ترین خبریں
- **product_search**: ای کامرس ڈیٹا کے لیے
- **qna**: سوال و جواب کے ٹکڑے

### خصوصیات
- **کوڈ کی مثالیں**: زبان مخصوص کوڈ بلاکس شامل ہیں، خاص طور پر Python کے لیے (اور آسانی سے دیگر زبانوں میں بڑھائے جا سکتے ہیں) واضح کرنے کے لیے کولپس ایبل سیکشنز کے ساتھ

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

کلائنٹ چلانے سے پہلے، یہ سمجھنا مفید ہے کہ سرور کیا کرتا ہے۔ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)۔

یہاں ایک مختصر مثال ہے کہ سرور کیسے ایک ٹول کو ڈیفائن اور رجسٹر کرتا ہے:

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

- **بیرونی API انضمام**: API keys اور بیرونی درخواستوں کو محفوظ طریقے سے سنبھالنے کی مثال
- **منظم شدہ ڈیٹا پارسنگ**: API جوابات کو LLM کے لیے موزوں فارمیٹ میں تبدیل کرنا
- **غلطی سنبھالنا**: مناسب لاگنگ کے ساتھ مضبوط غلطی سنبھالنے کا طریقہ
- **انٹرایکٹو کلائنٹ**: خودکار ٹیسٹ اور انٹرایکٹو موڈ دونوں شامل ہیں
- **سیاق و سباق کا انتظام**: MCP Context کا استعمال کرتے ہوئے لاگنگ اور درخواستوں کا سراغ لگانا

## ضروریات

شروع کرنے سے پہلے، یقینی بنائیں کہ آپ کا ماحول درست طریقے سے سیٹ اپ ہے۔ یہ یقینی بنائے گا کہ تمام dependencies انسٹال ہیں اور آپ کی API keys صحیح طریقے سے ترتیب دی گئی ہیں تاکہ ترقی اور ٹیسٹنگ میں آسانی ہو۔

- Python 3.8 یا اس سے اوپر
- SerpAPI API Key (سائن اپ کریں [SerpAPI](https://serpapi.com/) پر - مفت ٹائر دستیاب ہے)

## تنصیب

شروع کرنے کے لیے، اپنے ماحول کو سیٹ اپ کرنے کے لیے یہ مراحل کریں:

1. dependencies انسٹال کریں uv (تجویز کردہ) یا pip کے ذریعے:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. پروجیکٹ کے روٹ میں `.env` فائل بنائیں اور اپنی SerpAPI key شامل کریں:

```
SERPAPI_KEY=your_serpapi_key_here
```

## استعمال

ویب سرچ MCP سرور وہ مرکزی جزو ہے جو ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے ٹولز کو SerpAPI کے ساتھ مربوط کر کے فراہم کرتا ہے۔ یہ آنے والی درخواستوں کو سنبھالتا ہے، API کالز کا انتظام کرتا ہے، جوابات کو پارس کرتا ہے، اور منظم نتائج کلائنٹ کو واپس بھیجتا ہے۔

آپ مکمل نفاذ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) میں دیکھ سکتے ہیں۔

### سرور چلانا

MCP سرور شروع کرنے کے لیے یہ کمانڈ استعمال کریں:

```bash
python server.py
```

سرور stdio پر مبنی MCP سرور کے طور پر چلے گا جس سے کلائنٹ براہ راست کنیکٹ ہو سکتا ہے۔

### کلائنٹ موڈز

کلائنٹ (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)۔

### کلائنٹ چلانا

خودکار ٹیسٹ چلانے کے لیے (یہ خود بخود سرور شروع کر دے گا):

```bash
python client.py
```

یا انٹرایکٹو موڈ میں چلائیں:

```bash
python client.py --interactive
```

### مختلف طریقوں سے ٹیسٹنگ

سرور کے فراہم کردہ ٹولز کے ساتھ ٹیسٹ کرنے اور تعامل کرنے کے کئی طریقے ہیں، آپ کی ضرورت اور ورک فلو کے مطابق۔

#### MCP Python SDK کے ساتھ کسٹم ٹیسٹ اسکرپٹس لکھنا
آپ MCP Python SDK استعمال کرتے ہوئے اپنے خود کے ٹیسٹ اسکرپٹس بھی بنا سکتے ہیں:

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

اس سیاق میں، "ٹیسٹ اسکرپٹ" کا مطلب ہے ایک کسٹم Python پروگرام جو آپ MCP سرور کے کلائنٹ کے طور پر لکھتے ہیں۔ یہ رسمی یونٹ ٹیسٹ نہیں بلکہ ایک ایسا اسکرپٹ ہے جو آپ کو پروگراماتی طور پر سرور سے جڑنے، اس کے کسی بھی ٹول کو منتخب پیرامیٹرز کے ساتھ کال کرنے، اور نتائج کا معائنہ کرنے دیتا ہے۔ یہ طریقہ کار درج ذیل کے لیے مفید ہے:
- ٹول کالز کے ساتھ تجربہ کرنا اور پروٹوٹائپ بنانا
- مختلف ان پٹ پر سرور کے ردعمل کی تصدیق کرنا
- بار بار ٹول کالز کو خودکار بنانا
- اپنے ورک فلو یا انضمام MCP سرور کے اوپر بنانا

آپ ٹیسٹ اسکرپٹس استعمال کر کے جلدی سے نئے سوالات آزما سکتے ہیں، ٹول کے رویے کی خرابی تلاش کر سکتے ہیں، یا یہاں تک کہ مزید جدید خودکار کاری کے لیے نقطہ آغاز بنا سکتے ہیں۔ نیچے MCP Python SDK استعمال کرنے کی مثال دی گئی ہے:

## ٹول کی تفصیلات

آپ سرور کے فراہم کردہ درج ذیل ٹولز استعمال کر کے مختلف قسم کی تلاش اور سوالات کر سکتے ہیں۔ ہر ٹول کی تفصیل اس کے پیرامیٹرز اور مثال کے استعمال کے ساتھ دی گئی ہے۔

یہ سیکشن ہر دستیاب ٹول اور اس کے پیرامیٹرز کی تفصیل فراہم کرتا ہے۔

### general_search

ایک عمومی ویب سرچ کرتا ہے اور فارمیٹ شدہ نتائج واپس دیتا ہے۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `general_search` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طور پر۔ یہاں SDK کے استعمال کی مثال ہے:

<details>
<summary>Python مثال</summary>

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

متبادل طور پر، انٹرایکٹو موڈ میں، `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): تلاش کا سوال منتخب کریں

**مثال کی درخواست:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

کسی سوال سے متعلق تازہ ترین خبریں تلاش کرتا ہے۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `news_search` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طور پر۔ یہاں SDK کے استعمال کی مثال ہے:

<details>
<summary>Python مثال</summary>

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

متبادل طور پر، انٹرایکٹو موڈ میں، `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): تلاش کا سوال منتخب کریں

**مثال کی درخواست:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

کسی سوال سے میل کھانے والی مصنوعات تلاش کرتا ہے۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `product_search` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طور پر۔ یہاں SDK کے استعمال کی مثال ہے:

<details>
<summary>Python مثال</summary>

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

متبادل طور پر، انٹرایکٹو موڈ میں، `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): مصنوعات کی تلاش کا سوال منتخب کریں

**مثال کی درخواست:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

تلاش انجنوں سے سوالات کے براہ راست جوابات حاصل کرتا ہے۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `qna` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طور پر۔ یہاں SDK کے استعمال کی مثال ہے:

<details>
<summary>Python مثال</summary>

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

متبادل طور پر، انٹرایکٹو موڈ میں، `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): جواب تلاش کرنے کے لیے سوال منتخب کریں

**مثال کی درخواست:**

```json
{
  "question": "what is artificial intelligence"
}
```

## کوڈ کی تفصیلات

یہ سیکشن سرور اور کلائنٹ کے نفاذ کے لیے کوڈ کے ٹکڑے اور حوالہ جات فراہم کرتا ہے۔

<details>
<summary>Python</summary>

مکمل نفاذ کے لیے دیکھیں [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)۔

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## اس سبق میں جدید تصورات

تعمیر شروع کرنے سے پہلے، یہاں کچھ اہم جدید تصورات ہیں جو اس باب میں بار بار آئیں گے۔ ان کو سمجھنا آپ کی مدد کرے گا، چاہے آپ ان میں نئے ہوں:

- **کئی ٹولز کا انتظام**: اس کا مطلب ہے کہ ایک ہی MCP سرور میں مختلف ٹولز (جیسے ویب سرچ، نیوز سرچ، پروڈکٹ سرچ، اور سوال و جواب) چلانا۔ یہ آپ کے سرور کو مختلف کام سنبھالنے کی صلاحیت دیتا ہے، صرف ایک نہیں۔
- **API کی رفتار کی حد کا انتظام**: بہت سے بیرونی APIs (جیسے SerpAPI) ایک مخصوص وقت میں کی جانے والی درخواستوں کی تعداد کو محدود کرتے ہیں۔ اچھا کوڈ ان حدود کو چیک کرتا ہے اور انہیں مہذب طریقے سے سنبھالتا ہے، تاکہ آپ کی ایپ کریش نہ ہو اگر آپ حد تک پہنچ جائیں۔
- **منظم شدہ ڈیٹا پارسنگ**: API کے جوابات اکثر پیچیدہ اور گھنے ہوتے ہیں۔ یہ تصور ان جوابات کو صاف، آسان استعمال ہونے والے فارمیٹس میں تبدیل کرنے کے بارے میں ہے جو LLMs یا دیگر پروگراموں کے لیے موزوں ہوں۔
- **غلطی کی بحالی**: کبھی کبھی چیزیں غلط ہو جاتی ہیں—مثلاً نیٹ ورک فیل ہو جانا، یا API وہ نہیں دیتا جو آپ توقع کرتے ہیں۔ غلطی کی بحالی کا مطلب ہے کہ آپ کا کوڈ ان مسائل کو سنبھال سکتا ہے اور مفید فیڈبیک دے سکتا ہے، بجائے اس کے کہ کریش ہو جائے۔
- **پیرامیٹر کی توثیق**: یہ اس بات کی جانچ پڑتال ہے کہ آپ کے ٹولز میں دیے گئے تمام ان پٹ درست اور محفوظ ہیں۔ اس میں ڈیفالٹ ویلیوز کا تعین اور اقسام کی درستگی شامل ہے، جو بگز اور الجھن کو روکنے میں مدد دیتی ہے۔

یہ سیکشن آپ کو عام مسائل کی تشخیص اور ان کے حل میں مدد دے گا جو آپ ویب سرچ MCP سرور کے ساتھ کام کرتے ہوئے پیش آ سکتے ہیں۔ اگر آپ کو کوئی غلطی یا غیر متوقع رویہ نظر آئے، تو یہ ٹربل شوٹنگ سیکشن آپ کو اکثر مسائل کے حل فراہم کرتا ہے۔ مزید مدد لینے سے پہلے ان نکات کو دیکھیں—یہ اکثر مسائل کو جلد حل کر دیتے ہیں۔

## مسئلہ حل کرنا

ویب سرچ MCP سرور کے ساتھ کام کرتے ہوئے، آپ کو کبھی کبھار مسائل کا سامنا ہو سکتا ہے—یہ بیرونی APIs اور نئے ٹولز کے ساتھ ترقی کرتے وقت معمول کی بات ہے۔ یہ سیکشن عام مسائل کے عملی حل فراہم کرتا ہے تاکہ آپ جلدی سے راستے پر واپس آ سکیں۔ اگر آپ کو کوئی غلطی پیش آئے، تو یہاں سے شروع کریں: نیچے دیے گئے نکات عام صارفین کے مسائل کو حل کرتے ہیں اور اکثر آپ کا مسئلہ بغیر اضافی مدد کے ٹھیک کر دیتے ہیں۔

### عام مسائل

نیچے صارفین کے سامنے آنے والے سب سے عام مسائل، واضح وضاحتوں اور حل کے اقدامات کے ساتھ درج ہیں:

1. **.env فائل میں SERPAPI_KEY غائب ہے**
   - اگر آپ کو یہ غلطی ملے `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` فائل بنائیں اگر ضروری ہو۔ اگر آپ کی key درست ہے لیکن پھر بھی یہ غلطی آ رہی ہے، تو چیک کریں کہ کیا آپ کا مفت ٹائر کوٹا ختم تو نہیں ہو گیا۔

### ڈیبگ موڈ

ڈیفالٹ کے طور پر، ایپ صرف اہم معلومات لاگ کرتی ہے۔ اگر آپ یہ دیکھنا چاہتے ہیں کہ کیا ہو رہا ہے (مثلاً پیچیدہ مسائل کی تشخیص کے لیے)، تو آپ DEBUG موڈ کو فعال کر سکتے ہیں۔ یہ آپ کو ایپ کے ہر قدم کے بارے میں بہت زیادہ تفصیل دکھائے گا۔

**مثال: معمول کا آؤٹ پٹ**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**مثال: DEBUG آؤٹ پٹ**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

نوٹ کریں کہ DEBUG موڈ میں HTTP درخواستوں، جوابات، اور دیگر اندرونی تفصیلات کے اضافی لائنز شامل ہوتے ہیں۔ یہ مسئلہ حل کرنے میں بہت مددگار ہو سکتا ہے۔

DEBUG موڈ کو فعال کرنے کے لیے، `client.py` or `server.py` کے اوپر لاگنگ لیول کو DEBUG پر سیٹ کریں:

<details>
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

## اگلا کیا ہے

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**دستخطی بیان**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔