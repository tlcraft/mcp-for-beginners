<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:26:43+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ur"
}
-->
# سبق: ویب سرچ MCP سرور بنانا

یہ باب دکھاتا ہے کہ کس طرح ایک حقیقی دنیا کا AI ایجنٹ بنایا جائے جو بیرونی APIs کے ساتھ انضمام کرتا ہے، مختلف قسم کے ڈیٹا کو سنبھالتا ہے، غلطیوں کا انتظام کرتا ہے، اور متعدد ٹولز کو ترتیب دیتا ہے—وہ سب پروڈکشن کے قابل فارمیٹ میں۔ آپ دیکھیں گے:

- **تصدیق کی ضرورت والے بیرونی APIs کے ساتھ انضمام**
- **متعدد اینڈپوائنٹس سے مختلف قسم کے ڈیٹا کو سنبھالنا**
- **مضبوط غلطی سنبھالنے اور لاگنگ کی حکمت عملیاں**
- **ایک ہی سرور میں متعدد ٹولز کا انتظام**

آخر میں، آپ کو ایسے پیٹرنز اور بہترین طریقوں کا عملی تجربہ ہوگا جو جدید AI اور LLM سے چلنے والی ایپلیکیشنز کے لیے ضروری ہیں۔

## تعارف

اس سبق میں، آپ سیکھیں گے کہ کیسے ایک جدید MCP سرور اور کلائنٹ بنایا جائے جو SerpAPI کے ذریعے LLM کی صلاحیتوں کو حقیقی وقت کے ویب ڈیٹا کے ساتھ بڑھاتا ہے۔ یہ ایک اہم مہارت ہے جو متحرک AI ایجنٹس کی ترقی کے لیے ضروری ہے جو ویب سے تازہ ترین معلومات حاصل کر سکیں۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے کہ:

- بیرونی APIs (جیسے SerpAPI) کو MCP سرور میں محفوظ طریقے سے شامل کریں
- ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے لیے متعدد ٹولز نافذ کریں
- LLM کی کھپت کے لیے منظم شدہ ڈیٹا کو پارس اور فارمیٹ کریں
- غلطیوں کو سنبھالیں اور API کی شرح کی حد کو مؤثر طریقے سے منظم کریں
- خودکار اور انٹرایکٹو MCP کلائنٹس دونوں کو بنائیں اور ٹیسٹ کریں

## ویب سرچ MCP سرور

یہ سیکشن ویب سرچ MCP سرور کی ساخت اور خصوصیات متعارف کراتا ہے۔ آپ دیکھیں گے کہ کیسے FastMCP اور SerpAPI کو مل کر حقیقی وقت کے ویب ڈیٹا کے ساتھ LLM کی صلاحیتوں کو بڑھانے کے لیے استعمال کیا جاتا ہے۔

### جائزہ

یہ نفاذ چار ٹولز پیش کرتا ہے جو MCP کی صلاحیت کو ظاہر کرتے ہیں کہ وہ مختلف، بیرونی API سے چلنے والے کاموں کو محفوظ اور مؤثر طریقے سے سنبھال سکتا ہے:

- **general_search**: وسیع ویب نتائج کے لیے
- **news_search**: تازہ ترین سرخیاں حاصل کرنے کے لیے
- **product_search**: ای کامرس ڈیٹا کے لیے
- **qna**: سوالات اور جوابات کے اقتباسات کے لیے

### خصوصیات
- **کوڈ کی مثالیں**: زبان مخصوص کوڈ بلاکس شامل ہیں، خاص طور پر Python کے لیے (اور آسانی سے دوسری زبانوں میں توسیع پذیر) واضح بنانے کے لیے قابلِ چھپانے حصے استعمال کیے گئے ہیں

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

یہاں ایک مختصر مثال ہے کہ سرور کیسے ایک ٹول کی تعریف اور رجسٹریشن کرتا ہے:

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

- **بیرونی API انضمام**: API کیز اور بیرونی درخواستوں کو محفوظ طریقے سے سنبھالنے کا مظاہرہ
- **منظم شدہ ڈیٹا پارسنگ**: API جوابات کو LLM کے موافق فارمیٹس میں تبدیل کرنا دکھاتا ہے
- **غلطی سنبھالنا**: مناسب لاگنگ کے ساتھ مضبوط غلطی سنبھالنا
- **انٹرایکٹو کلائنٹ**: خودکار ٹیسٹ اور انٹرایکٹو موڈ دونوں شامل ہیں
- **سیاق و سباق کا انتظام**: MCP Context کا استعمال کرتے ہوئے لاگنگ اور درخواستوں کا سراغ لگانا

## ضروریات

شروع کرنے سے پہلے، یقینی بنائیں کہ آپ کا ماحول صحیح طریقے سے ترتیب دیا گیا ہے۔ یہ یقینی بنائے گا کہ تمام انحصار انسٹال ہیں اور آپ کی API کیز صحیح طریقے سے ترتیب دی گئی ہیں تاکہ ترقی اور ٹیسٹنگ میں کوئی رکاوٹ نہ آئے۔

- Python 3.8 یا اس سے اوپر
- SerpAPI API Key (سائن اپ کریں [SerpAPI](https://serpapi.com/) پر — مفت سطح دستیاب ہے)

## انسٹالیشن

شروع کرنے کے لیے، اپنے ماحول کو ترتیب دینے کے لیے یہ اقدامات کریں:

1. انحصارات انسٹال کریں uv (تجویز کردہ) یا pip استعمال کرتے ہوئے:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. پروجیکٹ کے روٹ میں `.env` فائل بنائیں اور اپنی SerpAPI کی شامل کریں:

```
SERPAPI_KEY=your_serpapi_key_here
```

## استعمال

ویب سرچ MCP سرور وہ مرکزی جزو ہے جو ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے ٹولز کو SerpAPI کے ساتھ انضمام کے ذریعے فراہم کرتا ہے۔ یہ آنے والی درخواستوں کو سنبھالتا ہے، API کالز کا انتظام کرتا ہے، جوابات کو پارس کرتا ہے، اور منظم شدہ نتائج کلائنٹ کو واپس بھیجتا ہے۔

آپ مکمل نفاذ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) میں دیکھ سکتے ہیں۔

### سرور چلانا

MCP سرور شروع کرنے کے لیے، درج ذیل کمانڈ استعمال کریں:

```bash
python server.py
```

سرور stdio پر مبنی MCP سرور کے طور پر چلے گا جس سے کلائنٹ براہ راست جڑ سکتا ہے۔

### کلائنٹ کے موڈز

کلائنٹ (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)۔

### کلائنٹ چلانا

خودکار ٹیسٹ چلانے کے لیے (یہ خود بخود سرور بھی شروع کر دے گا):

```bash
python client.py
```

یا انٹرایکٹو موڈ میں چلائیں:

```bash
python client.py --interactive
```

### مختلف طریقوں سے ٹیسٹنگ

سرور کی طرف سے فراہم کردہ ٹولز کے ساتھ ٹیسٹ اور انٹرایکٹ کرنے کے کئی طریقے ہیں، آپ کی ضروریات اور ورک فلو کے مطابق۔

#### MCP Python SDK کے ساتھ اپنی مرضی کے ٹیسٹ اسکرپٹس لکھنا
آپ MCP Python SDK استعمال کرتے ہوئے اپنی مرضی کے ٹیسٹ اسکرپٹس بھی بنا سکتے ہیں:

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

اس سیاق و سباق میں، "ٹیسٹ اسکرپٹ" کا مطلب ہے ایک حسب ضرورت Python پروگرام جو آپ کلائنٹ کے طور پر MCP سرور سے جڑنے کے لیے لکھتے ہیں۔ یہ رسمی یونٹ ٹیسٹ نہیں بلکہ ایک ایسا اسکرپٹ ہے جو آپ کو پروگرام کے ذریعے سرور سے جڑنے، اس کے کسی بھی ٹول کو منتخب کردہ پیرامیٹرز کے ساتھ کال کرنے، اور نتائج کا معائنہ کرنے دیتا ہے۔ یہ طریقہ کار مفید ہے:

- ٹول کالز کے لیے پروٹوٹائپ اور تجربہ کرنے کے لیے
- مختلف ان پٹس پر سرور کے ردعمل کی تصدیق کے لیے
- بار بار ٹول کالز کو خودکار بنانے کے لیے
- MCP سرور کے اوپر اپنی ورک فلو یا انضمامات بنانے کے لیے

آپ ٹیسٹ اسکرپٹس کا استعمال نئے سوالات جلدی آزمانے، ٹول کے رویے کو ڈیبگ کرنے، یا مزید جدید خودکاری کے لیے نقطہ آغاز کے طور پر کر سکتے ہیں۔ نیچے MCP Python SDK کے استعمال کی مثال دی گئی ہے:

## ٹول کی تفصیلات

سرور کی طرف سے فراہم کردہ درج ذیل ٹولز مختلف قسم کی تلاش اور سوالات کے لیے استعمال کیے جا سکتے ہیں۔ ہر ٹول کی وضاحت اس کے پیرامیٹرز اور مثال کے استعمال کے ساتھ نیچے دی گئی ہے۔

یہ سیکشن ہر دستیاب ٹول اور ان کے پیرامیٹرز کی تفصیلات فراہم کرتا ہے۔

### general_search

ایک عام ویب سرچ انجام دیتا ہے اور فارمیٹ شدہ نتائج واپس کرتا ہے۔

**اس ٹول کو کیسے کال کریں:**

آپ `general_search` کو MCP Python SDK استعمال کرتے ہوئے اپنی اسکرپٹ سے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طریقے سے استعمال کر سکتے ہیں۔ یہاں SDK کے استعمال کی ایک کوڈ مثال ہے:

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

تلاش کرتا ہے حالیہ خبروں کے مضامین کو جو کسی سوال سے متعلق ہوں۔

**اس ٹول کو کیسے کال کریں:**

آپ `news_search` کو MCP Python SDK کے ذریعے اپنی اسکرپٹ سے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طریقے سے استعمال کر سکتے ہیں۔ یہاں SDK کے استعمال کی ایک کوڈ مثال ہے:

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

تلاش کرتا ہے مصنوعات کو جو کسی سوال سے میل کھاتی ہوں۔

**اس ٹول کو کیسے کال کریں:**

آپ `product_search` کو MCP Python SDK کے ذریعے اپنی اسکرپٹ سے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طریقے سے استعمال کر سکتے ہیں۔ یہاں SDK کے استعمال کی ایک کوڈ مثال ہے:

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

تلاش انجنوں سے سوالات کے براہ راست جواب حاصل کرتا ہے۔

**اس ٹول کو کیسے کال کریں:**

آپ `qna` کو MCP Python SDK کے ذریعے اپنی اسکرپٹ سے کال کر سکتے ہیں، یا انسپکٹر یا انٹرایکٹو کلائنٹ موڈ میں انٹرایکٹو طریقے سے استعمال کر سکتے ہیں۔ یہاں SDK کے استعمال کی ایک کوڈ مثال ہے:

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

یہ سیکشن سرور اور کلائنٹ کے نفاذ کے کوڈ ٹکڑے اور حوالہ جات فراہم کرتا ہے۔

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

## اس سبق کے جدید تصورات

بناتے وقت، یہاں کچھ اہم جدید تصورات ہیں جو اس باب میں بار بار آئیں گے۔ ان کو سمجھنا آپ کی مدد کرے گا کہ آپ آسانی سے ساتھ چل سکیں، چاہے آپ ان سے نئے ہوں:

- **متعدد ٹولز کا انتظام**: اس کا مطلب ہے کہ ایک ہی MCP سرور میں کئی مختلف ٹولز (جیسے ویب سرچ، نیوز سرچ، پراڈکٹ سرچ، اور سوال و جواب) چلائے جائیں۔ یہ آپ کے سرور کو مختلف قسم کے کام سنبھالنے کی اجازت دیتا ہے، نہ کہ صرف ایک۔
- **API کی شرح کی حد کا انتظام**: بہت سے بیرونی APIs (جیسے SerpAPI) ایک مقررہ وقت میں آپ کی درخواستوں کی تعداد کو محدود کرتے ہیں۔ اچھا کوڈ ان حدود کو چیک کرتا ہے اور انہیں مہذب طریقے سے سنبھالتا ہے، تاکہ اگر آپ حد کو پہنچ جائیں تو آپ کی ایپ خراب نہ ہو۔
- **منظم شدہ ڈیٹا پارسنگ**: API کے جوابات اکثر پیچیدہ اور نیسٹڈ ہوتے ہیں۔ یہ تصور ان جوابات کو صاف، آسان استعمال کے فارمیٹس میں تبدیل کرنے کے بارے میں ہے جو LLMs یا دیگر پروگراموں کے لیے دوستانہ ہوں۔
- **غلطی کی بازیابی**: کبھی کبھی چیزیں غلط ہو جاتی ہیں—مثلاً نیٹ ورک ناکام ہو جاتا ہے، یا API وہ نہیں دیتا جو آپ توقع کرتے ہیں۔ غلطی کی بازیابی کا مطلب ہے کہ آپ کا کوڈ ان مسائل کو سنبھال سکتا ہے اور مفید فیڈبیک دے سکتا ہے، بجائے اس کے کہ کریش ہو جائے۔
- **پیرامیٹر کی توثیق**: یہ اس بارے میں ہے کہ آپ کے ٹولز کو دیے جانے والے تمام ان پٹس درست اور محفوظ ہیں۔ اس میں ڈیفالٹ ویلیوز سیٹ کرنا اور اقسام کی درستگی چیک کرنا شامل ہے، جو بگز اور الجھن سے بچاتا ہے۔

یہ سیکشن آپ کو ویب سرچ MCP سرور کے ساتھ کام کرتے وقت پیش آنے والے عام مسائل کی تشخیص اور حل کرنے میں مدد دے گا۔ اگر آپ کو ویب سرچ MCP سرور کے ساتھ کام کرتے ہوئے غلطیاں یا غیر متوقع رویہ ملے، تو یہ ٹربل شوٹنگ سیکشن عام مسائل کے حل فراہم کرتا ہے۔ مزید مدد لینے سے پہلے ان تجاویز کا جائزہ لیں—یہ اکثر مسائل کو جلد حل کر دیتی ہیں۔

## مسئلہ حل کرنا

ویب سرچ MCP سرور کے ساتھ کام کرتے وقت، آپ کو کبھی کبھار مسائل کا سامنا ہو سکتا ہے—یہ عام بات ہے جب آپ بیرونی APIs اور نئے ٹولز کے ساتھ ترقی کر رہے ہوں۔ یہ سیکشن سب سے عام مسائل کے عملی حل فراہم کرتا ہے تاکہ آپ جلدی سے کام پر واپس آ سکیں۔ اگر آپ کو کوئی غلطی ملے، تو یہاں سے شروع کریں: نیچے دیے گئے نکات عام صارفین کے مسائل کو حل کرتے ہیں اور اکثر آپ کے مسئلے کو بغیر اضافی مدد کے ٹھیک کر دیتے ہیں۔

### عام مسائل

نیچے کچھ سب سے زیادہ بار بار پیش آنے والے مسائل اور ان کے واضح وضاحتیں اور حل کے اقدامات دیے گئے ہیں:

1. **.env فائل میں SERPAPI_KEY غائب ہے**
   - اگر آپ کو یہ غلطی نظر آئے `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` فائل بنائیں اگر ضرورت ہو۔ اگر آپ کی کی صحیح ہے لیکن پھر بھی یہ غلطی آ رہی ہے، تو چیک کریں کہ آیا آپ کی مفت سطح کی کوٹا ختم تو نہیں ہو گئی۔

### ڈیبگ موڈ

عام طور پر، ایپ صرف اہم معلومات لاگ کرتی ہے۔ اگر آپ مزید تفصیلات دیکھنا چاہتے ہیں کہ کیا ہو رہا ہے (مثلاً پیچیدہ مسائل کی تشخیص کے لیے)، تو آپ DEBUG موڈ کو فعال کر سکتے ہیں۔ یہ آپ کو ہر قدم کے بارے میں بہت زیادہ معلومات دکھائے گا جو ایپ لے رہی ہے۔

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

نوٹ کریں کہ DEBUG موڈ HTTP درخواستوں، جوابات، اور دیگر داخلی تفصیلات کے اضافی لائنیں شامل کرتا ہے۔ یہ مسئلہ حل کرنے میں بہت مددگار ہو سکتا ہے۔

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

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**دستخطی:**
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔