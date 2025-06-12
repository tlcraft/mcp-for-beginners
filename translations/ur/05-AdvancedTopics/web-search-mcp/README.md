<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T14:49:23+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ur"
}
-->
# سبق: ویب سرچ MCP سرور بنانا

یہ باب دکھاتا ہے کہ کیسے ایک حقیقی دنیا کا AI ایجنٹ بنایا جائے جو بیرونی APIs کے ساتھ مربوط ہو، مختلف ڈیٹا اقسام کو سنبھالے، غلطیوں کا انتظام کرے، اور متعدد ٹولز کو ایک ساتھ منظم کرے — وہ بھی پروڈکشن کے لیے تیار شکل میں۔ آپ دیکھیں گے:

- **تصدیق کی ضرورت والے بیرونی APIs کے ساتھ انضمام**
- **متعدد اینڈ پوائنٹس سے مختلف قسم کے ڈیٹا کو سنبھالنا**
- **مضبوط غلطی سنبھالنے اور لاگنگ کی حکمت عملی**
- **ایک ہی سرور میں متعدد ٹولز کا انتظام**

آخر تک، آپ کو ایسے پیٹرنز اور بہترین طریقوں کا عملی تجربہ ہوگا جو جدید AI اور LLM سے چلنے والی ایپلیکیشنز کے لیے ضروری ہیں۔

## تعارف

اس سبق میں، آپ سیکھیں گے کہ کیسے ایک جدید MCP سرور اور کلائنٹ بنایا جائے جو SerpAPI کا استعمال کرتے ہوئے LLM کی صلاحیتوں کو حقیقی وقت کے ویب ڈیٹا کے ساتھ بڑھائے۔ یہ ایک اہم مہارت ہے جو متحرک AI ایجنٹس بنانے کے لیے ضروری ہے جو ویب سے تازہ ترین معلومات حاصل کر سکیں۔

## سیکھنے کے مقاصد

اس سبق کے آخر میں، آپ کر سکیں گے:

- MCP سرور میں بیرونی APIs (جیسے SerpAPI) کو محفوظ طریقے سے شامل کرنا
- ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے لیے متعدد ٹولز نافذ کرنا
- LLM کے استعمال کے لیے منظم اور فارمیٹ شدہ ڈیٹا پارس کرنا
- غلطیوں کو سنبھالنا اور API کی ریٹ لمٹس کو مؤثر طریقے سے مینیج کرنا
- خودکار اور انٹرایکٹو دونوں طرح کے MCP کلائنٹس بنانا اور ٹیسٹ کرنا

## ویب سرچ MCP سرور

یہ سیکشن ویب سرچ MCP سرور کی آرکیٹیکچر اور خصوصیات متعارف کراتا ہے۔ آپ دیکھیں گے کہ FastMCP اور SerpAPI کو مل کر کیسے LLM صلاحیتوں کو حقیقی وقت کے ویب ڈیٹا کے ساتھ بڑھایا جاتا ہے۔

### جائزہ

یہ نفاذ چار ٹولز پر مشتمل ہے جو MCP کی صلاحیت کو ظاہر کرتے ہیں کہ وہ مختلف، بیرونی API سے چلنے والے کاموں کو محفوظ اور مؤثر طریقے سے سنبھال سکتا ہے:

- **general_search**: وسیع ویب نتائج کے لیے
- **news_search**: تازہ ترین سرخیاں حاصل کرنے کے لیے
- **product_search**: ای کامرس ڈیٹا کے لیے
- **qna**: سوال و جواب کے ٹکڑے حاصل کرنے کے لیے

### خصوصیات
- **کوڈ مثالیں**: زبان مخصوص کوڈ بلاکس شامل ہیں، خاص طور پر Python کے لیے (جسے آسانی سے دیگر زبانوں میں بڑھایا جا سکتا ہے) جو وضاحت کے لیے collapsible سیکشنز استعمال کرتے ہیں

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

- **بیرونی API انضمام**: API کیز اور بیرونی درخواستوں کو محفوظ طریقے سے سنبھالنے کی مثال
- **منظم ڈیٹا پارسنگ**: API جوابات کو LLM کے موافق فارمیٹ میں تبدیل کرنا دکھاتا ہے
- **غلطی سنبھالنا**: مناسب لاگنگ کے ساتھ مضبوط غلطی سنبھالنے کی حکمت عملی
- **انٹرایکٹو کلائنٹ**: خودکار ٹیسٹ اور انٹرایکٹو موڈ دونوں شامل ہیں
- **کانٹیکسٹ مینجمنٹ**: لاگنگ اور درخواستوں کی ٹریکنگ کے لیے MCP کانٹیکسٹ کا استعمال

## ضروریات

شروع کرنے سے پہلے، یقینی بنائیں کہ آپ کا ماحول صحیح طریقے سے سیٹ اپ ہے۔ یہ یقینی بنائے گا کہ تمام dependencies انسٹال ہیں اور آپ کی API کیز صحیح طریقے سے کنفیگر کی گئی ہیں تاکہ ترقی اور ٹیسٹنگ آسانی سے ہو سکے۔

- Python 3.8 یا اس سے اوپر
- SerpAPI API کی (مفت ٹائر کے لیے [SerpAPI](https://serpapi.com/) پر سائن اپ کریں)

## انسٹالیشن

شروع کرنے کے لیے، اپنے ماحول کو سیٹ اپ کرنے کے لیے یہ اقدامات کریں:

1. uv (تجویز کردہ) یا pip کے ذریعے dependencies انسٹال کریں:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. پروجیکٹ کی روٹ میں `.env` فائل بنائیں اور اپنی SerpAPI کی درج کریں:

```
SERPAPI_KEY=your_serpapi_key_here
```

## استعمال

ویب سرچ MCP سرور مرکزی جزو ہے جو SerpAPI کے ساتھ انضمام کرکے ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے ٹولز فراہم کرتا ہے۔ یہ آنے والی درخواستوں کو سنبھالتا ہے، API کالز کا انتظام کرتا ہے، جوابات پارس کرتا ہے، اور منظم نتائج کلائنٹ کو واپس بھیجتا ہے۔

آپ مکمل نفاذ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) میں دیکھ سکتے ہیں۔

### سرور چلانا

MCP سرور شروع کرنے کے لیے، درج ذیل کمانڈ استعمال کریں:

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

خودکار ٹیسٹ چلانے کے لیے (یہ خود بخود سرور بھی شروع کرے گا):

```bash
python client.py
```

یا انٹرایکٹو موڈ میں چلائیں:

```bash
python client.py --interactive
```

### مختلف طریقوں سے ٹیسٹنگ

سرور کے فراہم کردہ ٹولز کے ساتھ ٹیسٹ اور تعامل کرنے کے کئی طریقے ہیں، جو آپ کی ضروریات اور ورک فلو پر منحصر ہیں۔

#### MCP Python SDK کے ساتھ کسٹم ٹیسٹ اسکرپٹس لکھنا
آپ MCP Python SDK استعمال کرتے ہوئے اپنے ٹیسٹ اسکرپٹس بھی بنا سکتے ہیں:

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

اس سیاق و سباق میں، "ٹیسٹ اسکرپٹ" سے مراد وہ کسٹم Python پروگرام ہے جو آپ MCP سرور کے کلائنٹ کے طور پر لکھتے ہیں۔ یہ ایک رسمی یونٹ ٹیسٹ نہیں بلکہ ایک اسکرپٹ ہے جو پروگرام کے ذریعے سرور سے جڑتا ہے، اس کے ٹولز کو منتخب پیرامیٹرز کے ساتھ کال کرتا ہے، اور نتائج کا معائنہ کرتا ہے۔ یہ طریقہ کار مفید ہے:

- ٹول کالز کے ساتھ تجربہ اور پروٹوٹائپنگ کے لیے
- سرور کے مختلف ان پٹس پر ردعمل کی تصدیق کے لیے
- بار بار ٹول کالز کو خودکار بنانے کے لیے
- اپنے ورک فلو یا انضمامات بنانے کے لیے

آپ ٹیسٹ اسکرپٹس استعمال کر کے نئے سوالات جلدی آزما سکتے ہیں، ٹول کے رویے کو ڈیبگ کر سکتے ہیں، یا مزید جدید خودکاری کے لیے آغاز کر سکتے ہیں۔ نیچے MCP Python SDK کے استعمال کی ایک مثال دی گئی ہے:

## ٹول کی تفصیلات

آپ سرور کے فراہم کردہ درج ذیل ٹولز استعمال کر کے مختلف قسم کی تلاش اور سوالات کر سکتے ہیں۔ ہر ٹول کے پیرامیٹرز اور استعمال کی مثال نیچے دی گئی ہے۔

یہ سیکشن ہر دستیاب ٹول اور اس کے پیرامیٹرز کی تفصیلات فراہم کرتا ہے۔

### general_search

ایک عمومی ویب تلاش کرتا ہے اور فارمیٹ شدہ نتائج واپس کرتا ہے۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `general_search` کو MCP Python SDK استعمال کرتے ہوئے اپنی اسکرپٹ سے کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK استعمال کرنے کی کوڈ مثال ہے:

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

**مثال درخواست:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

تلاش کرتا ہے حالیہ خبری مضامین کو جو کسی سوال سے متعلق ہوں۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `news_search` کو MCP Python SDK سے اپنی اسکرپٹ میں کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK کے ساتھ کوڈ مثال ہے:

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

**مثال درخواست:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

تلاش کرتا ہے مصنوعات کو جو سوال سے میل کھاتی ہوں۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `product_search` کو MCP Python SDK سے اپنی اسکرپٹ میں کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK کے ساتھ کوڈ مثال ہے:

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

**مثال درخواست:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

سوالات کے فوری جوابات تلاش انجنوں سے حاصل کرتا ہے۔

**اس ٹول کو کال کرنے کا طریقہ:**

آپ `qna` کو MCP Python SDK سے اپنی اسکرپٹ میں کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK کے ساتھ کوڈ مثال ہے:

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

**مثال درخواست:**

```json
{
  "question": "what is artificial intelligence"
}
```

## کوڈ کی تفصیلات

یہ سیکشن سرور اور کلائنٹ کے نفاذ کے کوڈ کے ٹکڑے اور حوالہ جات فراہم کرتا ہے۔

<details>
<summary>Python</summary>

مکمل نفاذ کے لیے [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) دیکھیں۔

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## اس سبق میں جدید تصورات

شروع کرنے سے پہلے، یہاں کچھ اہم جدید تصورات ہیں جو پورے باب میں آئیں گے۔ ان کو سمجھنا آپ کی مدد کرے گا، چاہے آپ ان سے نئے ہی کیوں نہ ہوں:

- **متعدد ٹولز کا انتظام**: اس کا مطلب ہے کہ ایک ہی MCP سرور میں کئی مختلف ٹولز (جیسے ویب سرچ، نیوز سرچ، پروڈکٹ سرچ، اور سوال و جواب) چلانا۔ یہ آپ کے سرور کو مختلف کام سنبھالنے کی صلاحیت دیتا ہے، نہ کہ صرف ایک۔
- **API ریٹ لمٹ کا انتظام**: بہت سے بیرونی APIs (جیسے SerpAPI) ایک مخصوص وقت میں آپ کی درخواستوں کی تعداد محدود کرتے ہیں۔ اچھا کوڈ ان حدود کو چیک کرتا ہے اور انہیں مؤدبانہ طریقے سے ہینڈل کرتا ہے تاکہ آپ کی ایپ خراب نہ ہو۔
- **منظم ڈیٹا پارسنگ**: API کے جوابات اکثر پیچیدہ اور nested ہوتے ہیں۔ یہ تصور ان جوابات کو صاف اور آسان استعمال فارمیٹس میں تبدیل کرنے کے بارے میں ہے جو LLMs یا دیگر پروگراموں کے لیے موزوں ہوں۔
- **غلطی سے بازیابی**: کبھی کبھار مسائل ہوتے ہیں — ہوسکتا ہے نیٹ ورک ناکام ہو جائے، یا API وہی جواب نہ دے جو آپ توقع کرتے ہیں۔ غلطی سے بازیابی کا مطلب ہے کہ آپ کا کوڈ ان مسائل کو سنبھال سکتا ہے اور مفید فیڈبیک دے سکتا ہے، بجائے اس کے کہ کریش کر جائے۔
- **پیرامیٹر کی توثیق**: یہ اس بات کی جانچ پڑتال ہے کہ آپ کے ٹولز کو دی گئی تمام ان پٹس درست اور محفوظ ہیں۔ اس میں ڈیفالٹ ویلیوز سیٹ کرنا اور قسموں کی تصدیق شامل ہے، جو بگز اور الجھن سے بچاتا ہے۔

یہ سیکشن آپ کو ویب سرچ MCP سرور کے ساتھ کام کرتے ہوئے عام مسائل کی تشخیص اور حل کرنے میں مدد دے گا۔ اگر آپ کو غلطیاں یا غیر متوقع رویہ درپیش ہو، تو یہ ٹربل شوٹنگ سیکشن عام مسائل کے حل فراہم کرتا ہے۔ ان تجاویز کا جائزہ لیں — یہ اکثر مسائل کو جلد حل کر دیتی ہیں۔

## ٹربل شوٹنگ

ویب سرچ MCP سرور کے ساتھ کام کرتے ہوئے، آپ کو کبھی کبھار مسائل کا سامنا ہو سکتا ہے — یہ بیرونی APIs اور نئے ٹولز کے ساتھ ترقی کرتے وقت معمول کی بات ہے۔ یہ سیکشن عام مسائل کے عملی حل فراہم کرتا ہے تاکہ آپ جلدی سے درست راستے پر آ سکیں۔ اگر آپ کو کوئی غلطی پیش آئے تو یہاں سے شروع کریں: نیچے دیے گئے نکات ان مسائل کو حل کرتے ہیں جن کا زیادہ تر صارفین سامنا کرتے ہیں اور اکثر آپ کا مسئلہ بغیر اضافی مدد کے حل ہو جاتا ہے۔

### عام مسائل

نیچے صارفین کو پیش آنے والے کچھ عام مسائل، واضح وضاحتوں اور انہیں حل کرنے کے اقدامات درج ہیں:

1. **.env فائل میں SERPAPI_KEY غائب ہے**
   - اگر آپ کو یہ غلطی ملتی ہے `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `` تو `.env` فائل بنائیں اگر ضرورت ہو۔ اگر آپ کی کی درست ہے مگر پھر بھی یہ غلطی آ رہی ہے تو چیک کریں کہ آپ کا مفت کوٹہ ختم تو نہیں ہو گیا۔

### ڈیبگ موڈ

بنیادی طور پر، ایپ صرف اہم معلومات لاگ کرتی ہے۔ اگر آپ زیادہ تفصیلات دیکھنا چاہتے ہیں (مثلاً پیچیدہ مسائل کی تشخیص کے لیے)، تو آپ DEBUG موڈ کو فعال کر سکتے ہیں۔ یہ آپ کو ہر قدم کی زیادہ تفصیلات دکھائے گا جو ایپ لے رہی ہے۔

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

نوٹ کریں کہ DEBUG موڈ میں HTTP درخواستوں، جوابات، اور دیگر اندرونی تفصیلات کے اضافی لائنیں شامل ہوتی ہیں۔ یہ ٹربل شوٹنگ کے لیے بہت مددگار ہو سکتا ہے۔

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

## آگے کیا ہے

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر یقینی باتیں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم قبول نہیں کرتے۔