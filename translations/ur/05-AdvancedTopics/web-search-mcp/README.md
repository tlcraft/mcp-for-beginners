<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-07-14T03:25:33+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ur"
}
-->
# سبق: ویب سرچ MCP سرور بنانا

یہ باب دکھاتا ہے کہ کیسے ایک حقیقی دنیا کا AI ایجنٹ بنایا جائے جو بیرونی APIs کے ساتھ مربوط ہو، مختلف قسم کے ڈیٹا کو سنبھالے، غلطیوں کا انتظام کرے، اور متعدد ٹولز کو ایک ساتھ چلائے—وہ بھی پروڈکشن کے لیے تیار شکل میں۔ آپ دیکھیں گے:

- **بیرونی APIs کے ساتھ توثیق کی ضرورت کے ساتھ انضمام**
- **متعدد اینڈپوائنٹس سے مختلف قسم کے ڈیٹا کو سنبھالنا**
- **مضبوط غلطی سنبھالنے اور لاگنگ کی حکمت عملی**
- **ایک ہی سرور میں متعدد ٹولز کی ہم آہنگی**

آخر تک، آپ کو ایسے نمونے اور بہترین طریقے عملی طور پر سمجھ آ جائیں گے جو جدید AI اور LLM سے چلنے والی ایپلیکیشنز کے لیے ضروری ہیں۔

## تعارف

اس سبق میں، آپ سیکھیں گے کہ کیسے ایک جدید MCP سرور اور کلائنٹ بنایا جائے جو SerpAPI کے ذریعے حقیقی وقت کے ویب ڈیٹا کے ساتھ LLM کی صلاحیتوں کو بڑھائے۔ یہ ایک اہم مہارت ہے جو متحرک AI ایجنٹس کی ترقی کے لیے ضروری ہے جو ویب سے تازہ ترین معلومات حاصل کر سکیں۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے کہ:

- بیرونی APIs (جیسے SerpAPI) کو محفوظ طریقے سے MCP سرور میں شامل کریں
- ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے لیے متعدد ٹولز نافذ کریں
- LLM کے استعمال کے لیے منظم اور فارمیٹ شدہ ڈیٹا کو پارس کریں
- غلطیوں کو سنبھالیں اور API کی ریٹ لمٹس کا مؤثر انتظام کریں
- خودکار اور انٹرایکٹو دونوں طرح کے MCP کلائنٹس بنائیں اور ٹیسٹ کریں

## ویب سرچ MCP سرور

یہ سیکشن ویب سرچ MCP سرور کی ساخت اور خصوصیات کا تعارف کراتا ہے۔ آپ دیکھیں گے کہ کیسے FastMCP اور SerpAPI کو مل کر LLM کی صلاحیتوں کو حقیقی وقت کے ویب ڈیٹا کے ساتھ بڑھانے کے لیے استعمال کیا جاتا ہے۔

### جائزہ

یہ نفاذ چار ٹولز پر مشتمل ہے جو MCP کی صلاحیت کو ظاہر کرتے ہیں کہ وہ مختلف، بیرونی API پر مبنی کاموں کو محفوظ اور مؤثر طریقے سے سنبھال سکتا ہے:

- **general_search**: وسیع ویب نتائج کے لیے
- **news_search**: تازہ ترین سرخیاں حاصل کرنے کے لیے
- **product_search**: ای کامرس ڈیٹا کے لیے
- **qna**: سوال و جواب کے اقتباسات کے لیے

### خصوصیات
- **کوڈ کی مثالیں**: زبان مخصوص کوڈ بلاکس شامل ہیں، خاص طور پر Python کے لیے (اور آسانی سے دیگر زبانوں میں بڑھانے کے لیے) جو وضاحت کے لیے قابلِ بند سیکشنز میں ہیں

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

کلائنٹ چلانے سے پہلے، یہ سمجھنا مفید ہے کہ سرور کیا کرتا ہے۔ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) فائل MCP سرور کو نافذ کرتی ہے، جو ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے ٹولز کو SerpAPI کے ساتھ مربوط کر کے فراہم کرتی ہے۔ یہ آنے والی درخواستوں کو سنبھالتا ہے، API کالز کا انتظام کرتا ہے، جوابات کو پارس کرتا ہے، اور منظم نتائج کلائنٹ کو واپس بھیجتا ہے۔

آپ مکمل نفاذ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) میں دیکھ سکتے ہیں۔

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
- **منظم ڈیٹا پارسنگ**: API جوابات کو LLM کے موافق فارمیٹ میں تبدیل کرنے کا طریقہ
- **غلطی سنبھالنا**: مناسب لاگنگ کے ساتھ مضبوط غلطی سنبھالنے کا نظام
- **انٹرایکٹو کلائنٹ**: خودکار ٹیسٹ اور انٹرایکٹو موڈ دونوں شامل ہیں
- **سیاق و سباق کا انتظام**: MCP Context کا استعمال کرتے ہوئے لاگنگ اور درخواستوں کا ٹریک رکھنا

## ضروریات

شروع کرنے سے پہلے، یقینی بنائیں کہ آپ کا ماحول صحیح طریقے سے سیٹ اپ ہے۔ اس سے تمام انحصار انسٹال ہوں گے اور آپ کی API کیز درست طریقے سے ترتیب دی گئی ہوں گی تاکہ ترقی اور ٹیسٹنگ آسانی سے ہو سکے۔

- Python 3.8 یا اس سے اوپر
- SerpAPI API Key (سائن اپ کریں [SerpAPI](https://serpapi.com/) پر - مفت ٹئیر دستیاب ہے)

## تنصیب

شروع کرنے کے لیے، اپنے ماحول کو سیٹ اپ کرنے کے لیے یہ اقدامات کریں:

1. uv (تجویز کردہ) یا pip کے ذریعے انحصار انسٹال کریں:

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

ویب سرچ MCP سرور وہ بنیادی جزو ہے جو ویب، خبریں، مصنوعات کی تلاش، اور سوال و جواب کے ٹولز کو SerpAPI کے ساتھ مربوط کر کے فراہم کرتا ہے۔ یہ آنے والی درخواستوں کو سنبھالتا ہے، API کالز کا انتظام کرتا ہے، جوابات کو پارس کرتا ہے، اور منظم نتائج کلائنٹ کو واپس بھیجتا ہے۔

آپ مکمل نفاذ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) میں دیکھ سکتے ہیں۔

### سرور چلانا

MCP سرور شروع کرنے کے لیے، درج ذیل کمانڈ استعمال کریں:

```bash
python server.py
```

سرور stdio پر مبنی MCP سرور کے طور پر چلے گا جس سے کلائنٹ براہ راست جڑ سکتا ہے۔

### کلائنٹ کے موڈز

کلائنٹ (`client.py`) MCP سرور کے ساتھ بات چیت کے لیے دو موڈز کو سپورٹ کرتا ہے:

- **نارمل موڈ**: خودکار ٹیسٹ چلائے گا جو تمام ٹولز کو چیک کرتے ہیں اور ان کے جوابات کی تصدیق کرتے ہیں۔ یہ جلدی سے یہ جانچنے کے لیے مفید ہے کہ سرور اور ٹولز توقع کے مطابق کام کر رہے ہیں۔
- **انٹرایکٹو موڈ**: ایک مینو پر مبنی انٹرفیس شروع کرتا ہے جہاں آپ دستی طور پر ٹولز منتخب کر کے کال کر سکتے ہیں، اپنی مرضی کے سوالات داخل کر سکتے ہیں، اور نتائج حقیقی وقت میں دیکھ سکتے ہیں۔ یہ سرور کی صلاحیتوں کو دریافت کرنے اور مختلف ان پٹس کے ساتھ تجربہ کرنے کے لیے بہترین ہے۔

آپ مکمل نفاذ [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) میں دیکھ سکتے ہیں۔

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

اس سیاق میں، "ٹیسٹ اسکرپٹ" سے مراد ایک کسٹم Python پروگرام ہے جو آپ MCP سرور کے کلائنٹ کے طور پر لکھتے ہیں۔ یہ رسمی یونٹ ٹیسٹ نہیں بلکہ ایک ایسا اسکرپٹ ہے جو پروگرام کے ذریعے سرور سے جڑتا ہے، اس کے کسی بھی ٹول کو منتخب کردہ پیرامیٹرز کے ساتھ کال کرتا ہے، اور نتائج کا معائنہ کرتا ہے۔ یہ طریقہ کار درج ذیل کے لیے مفید ہے:
- ٹول کالز کے ساتھ تجربہ اور پروٹوٹائپنگ
- مختلف ان پٹس پر سرور کے ردعمل کی تصدیق
- بار بار ٹول کالز کو خودکار بنانا
- MCP سرور کے اوپر اپنی ورک فلو یا انضمام بنانا

آپ ٹیسٹ اسکرپٹس کا استعمال کر کے نئے سوالات جلدی آزما سکتے ہیں، ٹول کے رویے کو ڈیبگ کر سکتے ہیں، یا مزید پیچیدہ خودکاری کے لیے نقطہ آغاز بنا سکتے ہیں۔ نیچے MCP Python SDK کے استعمال کی ایک مثال دی گئی ہے:

## ٹول کی تفصیلات

سرور کے فراہم کردہ درج ذیل ٹولز مختلف قسم کی تلاش اور سوالات کے لیے استعمال کیے جا سکتے ہیں۔ ہر ٹول کی تفصیل، اس کے پیرامیٹرز، اور استعمال کی مثال نیچے دی گئی ہے۔

یہ سیکشن ہر دستیاب ٹول اور ان کے پیرامیٹرز کی تفصیلات فراہم کرتا ہے۔

### general_search

ایک عمومی ویب سرچ کرتا ہے اور فارمیٹ شدہ نتائج واپس کرتا ہے۔

**اس ٹول کو کیسے کال کریں:**

آپ `general_search` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK استعمال کرنے کی ایک کوڈ مثال ہے:

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

متبادل طور پر، انٹرایکٹو موڈ میں مینو سے `general_search` منتخب کریں اور جب پوچھا جائے تو اپنا سوال درج کریں۔

**پیرامیٹرز:**
- `query` (string): تلاش کا سوال

**مثال درخواست:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

تلاش کرتا ہے حالیہ خبری مضامین جو کسی سوال سے متعلق ہوں۔

**اس ٹول کو کیسے کال کریں:**

آپ `news_search` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK استعمال کرنے کی ایک کوڈ مثال ہے:

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

متبادل طور پر، انٹرایکٹو موڈ میں مینو سے `news_search` منتخب کریں اور جب پوچھا جائے تو اپنا سوال درج کریں۔

**پیرامیٹرز:**
- `query` (string): تلاش کا سوال

**مثال درخواست:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

تلاش کرتا ہے مصنوعات جو کسی سوال سے میل کھاتی ہوں۔

**اس ٹول کو کیسے کال کریں:**

آپ `product_search` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK استعمال کرنے کی ایک کوڈ مثال ہے:

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

متبادل طور پر، انٹرایکٹو موڈ میں مینو سے `product_search` منتخب کریں اور جب پوچھا جائے تو اپنا سوال درج کریں۔

**پیرامیٹرز:**
- `query` (string): مصنوعات کی تلاش کا سوال

**مثال درخواست:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

تلاش انجنوں سے سوالات کے براہ راست جوابات حاصل کرتا ہے۔

**اس ٹول کو کیسے کال کریں:**

آپ `qna` کو اپنے اسکرپٹ سے MCP Python SDK کے ذریعے کال کر سکتے ہیں، یا انسپیکٹر یا انٹرایکٹو کلائنٹ موڈ کے ذریعے۔ یہاں SDK استعمال کرنے کی ایک کوڈ مثال ہے:

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

متبادل طور پر، انٹرایکٹو موڈ میں مینو سے `qna` منتخب کریں اور جب پوچھا جائے تو اپنا سوال درج کریں۔

**پیرامیٹرز:**
- `question` (string): سوال جس کا جواب تلاش کرنا ہے

**مثال درخواست:**

```json
{
  "question": "what is artificial intelligence"
}
```

## کوڈ کی تفصیلات

یہ سیکشن سرور اور کلائنٹ کے نفاذ کے لیے کوڈ کے ٹکڑے اور حوالہ جات فراہم کرتا ہے۔

<details>
<summary>Python</summary>

مکمل نفاذ کے لیے [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) اور [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) دیکھیں۔

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## اس سبق میں جدید تصورات

شروع کرنے سے پہلے، یہاں کچھ اہم جدید تصورات ہیں جو اس باب میں بار بار آئیں گے۔ ان کو سمجھنا آپ کی مدد کرے گا، چاہے آپ ان سے نئے ہی کیوں نہ ہوں:

- **متعدد ٹولز کی ہم آہنگی**: اس کا مطلب ہے کہ ایک ہی MCP سرور میں کئی مختلف ٹولز (جیسے ویب سرچ، نیوز سرچ، پروڈکٹ سرچ، اور سوال و جواب) چلانا۔ یہ آپ کے سرور کو مختلف قسم کے کام سنبھالنے کے قابل بناتا ہے، صرف ایک کام کے بجائے۔
- **API ریٹ لمٹ کا انتظام**: بہت سے بیرونی APIs (جیسے SerpAPI) محدود کرتے ہیں کہ آپ کتنی درخواستیں ایک مخصوص وقت میں کر سکتے ہیں۔ اچھا کوڈ ان حدود کو چیک کرتا ہے اور انہیں مؤثر طریقے سے سنبھالتا ہے تاکہ آپ کی ایپ خراب نہ ہو اگر آپ حد تک پہنچ جائیں۔
- **منظم ڈیٹا پارسنگ**: API کے جوابات اکثر پیچیدہ اور گھنے ہوتے ہیں۔ یہ تصور ان جوابات کو صاف اور آسان استعمال کے قابل فارمیٹس میں تبدیل کرنے کے بارے میں ہے جو LLMs یا دیگر پروگراموں کے لیے موزوں ہوں۔
- **غلطی سے بازیابی**: کبھی کبھار مسائل پیش آتے ہیں—مثلاً نیٹ ورک فیل ہو جانا، یا API وہ جواب نہ دینا جو آپ توقع کرتے ہیں۔ غلطی سے بازیابی کا مطلب ہے کہ آپ کا کوڈ ان مسائل کو سنبھال سکتا ہے اور مفید فیڈبیک دے سکتا ہے، بجائے اس کے کہ کریش ہو جائے۔
- **پیرامیٹر کی تصدیق**: یہ اس بات کی جانچ پڑتال ہے کہ آپ کے ٹولز کو دیے جانے والے تمام ان پٹس درست اور محفوظ ہیں۔ اس میں ڈیفالٹ ویلیوز کا تعین اور اقسام کی جانچ شامل ہے، جو بگز اور الجھن سے بچاتا ہے۔

## مسئلہ حل کرنا

ویب سرچ MCP سرور کے ساتھ کام کرتے ہوئے، آپ کو کبھی کبھار مسائل کا سامنا ہو سکتا ہے—یہ بیرونی APIs اور نئے ٹولز کے ساتھ ترقی کرتے وقت معمول کی بات ہے۔ یہ سیکشن عام مسائل کے عملی حل فراہم کرتا ہے تاکہ آپ جلدی سے کام پر واپس آ سکیں۔ اگر آپ کو کوئی غلطی ملے، تو یہاں سے شروع کریں: نیچے دیے گئے نکات ان مسائل کو حل کرتے ہیں جن کا زیادہ تر صارفین کو سامنا ہوتا ہے اور اکثر آپ کا مسئلہ بغیر اضافی مدد کے حل ہو جاتا ہے۔

### عام مسائل

نیچے کچھ عام مسائل اور ان کے حل کے واضح مراحل دیے گئے ہیں:

1. **.env فائل میں SERPAPI_KEY غائب ہے**
   - اگر آپ کو یہ غلطی ملے `SERPAPI_KEY environment variable not found`، تو اس کا مطلب ہے کہ آپ کی ایپلیکیشن SerpAPI تک رسائی کے لیے API کی نہیں پا رہی۔ اسے ٹھیک کرنے کے لیے، اپنے پروجیکٹ کے روٹ میں `.env` نامی فائل بنائیں (اگر پہلے سے موجود نہیں) اور اس میں یہ لائن شامل کریں: `SERPAPI_KEY=your_serpapi_key_here`۔ `your_serpapi_key_here` کو اپنی اصل SerpAPI کی سے بدلیں جو آپ نے SerpAPI کی ویب سائٹ سے حاصل کی ہے۔

2. **ماڈیول نہ ملنے کی غلطیاں**
   - ایسی غلطیاں جیسے `ModuleNotFoundError: No module named 'httpx'` ظاہر کرتی ہیں کہ کوئی ضروری Python پیکیج انسٹال نہیں ہے۔ یہ عام طور پر اس وقت ہوتا ہے جب آپ نے تمام انحصار انسٹال نہیں کیے۔ اسے حل کرنے کے لیے، ٹرمینل میں `pip install -r requirements.txt` چلائیں تاکہ آپ کے پروجیکٹ کی تمام ضروریات انسٹال ہو جائیں۔

3. **کنکشن کے مسائل**
   - اگر آپ کو یہ غلطی ملے `Error during client execution`، تو اس کا مطلب اکثر یہ ہوتا ہے کہ کلائنٹ سرور سے جڑ نہیں پا رہا، یا سرور توقع کے مطابق نہیں چل رہا۔ یقینی بنائیں کہ کلائنٹ اور سرور دونوں مطابقت رکھتے ہیں، اور `server.py` صحیح ڈائریکٹری میں موجود ہے اور چل رہا ہے۔ سرور اور کلائنٹ دونوں کو دوبارہ شروع کرنا بھی مددگار ہو سکتا ہے۔

4. **SerpAPI کی غلطیاں**
   - اگر آپ کو یہ پیغام ملے `Search API returned error status: 401`، تو اس کا مطلب ہے کہ آپ کی SerpAPI کی غائب، غلط، یا ختم ہو چکی ہے۔ اپنے SerpAPI ڈیش بورڈ پر جائیں، اپنی کی کی تصدیق کریں، اور اگر ضرورت ہو تو `.env` فائل کو اپ ڈیٹ کریں۔ اگر آپ کی کی درست ہے لیکن پھر بھی یہ غلطی آ رہی ہے، تو چیک کریں کہ آپ کا مفت کوٹہ ختم تو نہیں ہو گیا۔

### ڈیبگ موڈ

عام طور پر، ایپ صرف اہم معلومات لاگ کرتی ہے۔ اگر آپ کو یہ دیکھنا ہو کہ ایپ کیا کر رہی ہے (مثلاً پیچیدہ مسائل کی تشخیص کے لیے)، تو آپ DEBUG موڈ فعال کر سکتے ہیں۔ اس سے آپ کو ہر قدم کی مزید تفصیلات ملیں گی۔

**مثال: عام آؤٹ پٹ**
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

نوٹ کریں کہ DEBUG موڈ میں HTTP درخواستوں، جوابات، اور دیگر اندرونی تفصیلات کے اضافی خطوط شامل ہوتے ہیں۔ یہ مسئلہ حل کرنے میں بہت مددگار ہو سکتا ہے۔

DEBUG موڈ فعال کرنے کے لیے، `client.py` یا `server.py` کے اوپر لاگنگ کی سطح کو DEBUG پر سیٹ کریں:

<summary>پائتھون</summary>

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

- [5.10 ریئل ٹائم اسٹریمنگ](../mcp-realtimestreaming/README.md)

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔