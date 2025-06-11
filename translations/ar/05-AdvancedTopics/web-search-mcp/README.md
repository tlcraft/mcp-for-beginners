<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T14:43:06+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ar"
}
-->
# الدرس: بناء خادم MCP للبحث على الويب

يعرض هذا الفصل كيفية بناء وكيل ذكاء اصطناعي عملي يتكامل مع واجهات برمجة التطبيقات الخارجية، يتعامل مع أنواع بيانات متنوعة، يدير الأخطاء، وينسق بين عدة أدوات—كل ذلك بصيغة جاهزة للإنتاج. سترى:

- **التكامل مع واجهات برمجة التطبيقات الخارجية التي تتطلب المصادقة**
- **التعامل مع أنواع بيانات متنوعة من عدة نقاط نهاية**
- **استراتيجيات قوية لمعالجة الأخطاء وتسجيلها**
- **تنسيق عدة أدوات في خادم واحد**

بحلول النهاية، ستمتلك خبرة عملية في الأنماط وأفضل الممارسات الضرورية لتطبيقات الذكاء الاصطناعي المتقدمة والمدعومة بـ LLM.

## المقدمة

في هذا الدرس، ستتعلم كيفية بناء خادم وعميل MCP متقدم يوسع قدرات LLM باستخدام بيانات ويب في الوقت الفعلي عبر SerpAPI. هذه مهارة حاسمة لتطوير وكلاء ذكاء اصطناعي ديناميكيين يمكنهم الوصول إلى معلومات محدثة من الويب.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- دمج واجهات برمجة التطبيقات الخارجية (مثل SerpAPI) بأمان في خادم MCP
- تنفيذ أدوات متعددة للبحث على الويب، الأخبار، المنتجات، والأسئلة والأجوبة
- تحليل وتنسيق البيانات المنظمة لاستهلاكها بواسطة LLM
- التعامل مع الأخطاء وإدارة حدود معدل واجهات برمجة التطبيقات بفعالية
- بناء واختبار عملاء MCP تلقائيين وتفاعليين

## خادم MCP للبحث على الويب

يقدم هذا القسم هيكل وميزات خادم MCP للبحث على الويب. سترى كيف يُستخدم FastMCP وSerpAPI معًا لتوسيع قدرات LLM باستخدام بيانات ويب في الوقت الفعلي.

### نظرة عامة

يتضمن هذا التنفيذ أربع أدوات تعرض قدرة MCP على التعامل مع مهام متنوعة مدفوعة بواجهات برمجة التطبيقات الخارجية بأمان وكفاءة:

- **general_search**: للنتائج العامة على الويب
- **news_search**: للعناوين الأخيرة
- **product_search**: لبيانات التجارة الإلكترونية
- **qna**: لقصاصات الأسئلة والأجوبة

### الميزات
- **أمثلة على الكود**: تتضمن كتل كود خاصة بلغات محددة مثل Python (وقابلة للتوسيع بسهولة إلى لغات أخرى) باستخدام أقسام قابلة للطي لزيادة الوضوح

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

قبل تشغيل العميل، من المفيد فهم ما يفعله الخادم. الملف [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

إليك مثالًا موجزًا لكيفية تعريف الخادم لأداة وتسجيلها:

<details>  
<summary>خادم Python</summary> 

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

- **تكامل واجهة برمجة التطبيقات الخارجية**: يوضح التعامل الآمن مع مفاتيح API والطلبات الخارجية
- **تحليل البيانات المنظمة**: يوضح كيفية تحويل استجابات API إلى تنسيقات مناسبة لـ LLM
- **معالجة الأخطاء**: معالجة أخطاء قوية مع تسجيل مناسب
- **عميل تفاعلي**: يتضمن اختبارات آلية ووضع تفاعلي للاختبار
- **إدارة السياق**: يستفيد من MCP Context لتسجيل وتتبع الطلبات

## المتطلبات الأساسية

قبل أن تبدأ، تأكد من إعداد بيئتك بشكل صحيح باتباع هذه الخطوات. هذا سيضمن تثبيت كل التبعيات وتكوين مفاتيح API بشكل صحيح لتطوير واختبار سلس.

- Python 3.8 أو أحدث
- مفتاح SerpAPI (سجل في [SerpAPI](https://serpapi.com/) - هناك طبقة مجانية متاحة)

## التثبيت

لبدء العمل، اتبع هذه الخطوات لإعداد بيئتك:

1. تثبيت التبعيات باستخدام uv (مستحسن) أو pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. إنشاء ملف `.env` في جذر المشروع بمفتاح SerpAPI الخاص بك:

```
SERPAPI_KEY=your_serpapi_key_here
```

## الاستخدام

يُعد خادم MCP للبحث على الويب المكون الأساسي الذي يعرض أدوات للبحث على الويب، الأخبار، المنتجات، والأسئلة والأجوبة من خلال التكامل مع SerpAPI. يدير الطلبات الواردة، يدير استدعاءات API، يحلل الاستجابات، ويرجع النتائج المنظمة إلى العميل.

يمكنك مراجعة التنفيذ الكامل في [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### تشغيل الخادم

لتشغيل خادم MCP، استخدم الأمر التالي:

```bash
python server.py
```

سيعمل الخادم كخادم MCP قائم على stdio يمكن للعميل الاتصال به مباشرة.

### أوضاع العميل

العميل (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### تشغيل العميل

لتشغيل الاختبارات الآلية (سيبدأ الخادم تلقائيًا):

```bash
python client.py
```

أو التشغيل في الوضع التفاعلي:

```bash
python client.py --interactive
```

### الاختبار بطرق مختلفة

هناك عدة طرق لاختبار والتفاعل مع الأدوات التي يوفرها الخادم، حسب احتياجاتك وسير عملك.

#### كتابة سكربتات اختبار مخصصة باستخدام MCP Python SDK
يمكنك أيضًا بناء سكربتات اختبار خاصة بك باستخدام MCP Python SDK:

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

في هذا السياق، يعني "سكريبت اختبار" برنامج Python مخصص تكتبه ليعمل كعميل لخادم MCP. بدلاً من أن يكون اختبار وحدة رسمي، يتيح لك هذا السكربت الاتصال برمجيًا بالخادم، استدعاء أي من أدواته مع المعلمات التي تختارها، وفحص النتائج. هذه الطريقة مفيدة لـ:
- النمذجة والتجربة مع استدعاءات الأدوات
- التحقق من كيفية استجابة الخادم لمداخل مختلفة
- أتمتة استدعاءات الأدوات المتكررة
- بناء سير عمل أو تكاملات خاصة بك فوق خادم MCP

يمكنك استخدام سكربتات الاختبار لتجربة استعلامات جديدة بسرعة، تصحيح سلوك الأدوات، أو حتى كنقطة انطلاق لأتمتة أكثر تقدمًا. أدناه مثال على كيفية استخدام MCP Python SDK لإنشاء مثل هذا السكربت:

## وصف الأدوات

يمكنك استخدام الأدوات التالية التي يوفرها الخادم لأداء أنواع مختلفة من البحث والاستعلامات. كل أداة موصوفة أدناه مع معلماتها وطريقة استخدامها كمثال.

يوفر هذا القسم تفاصيل عن كل أداة متاحة ومعلماتها.

### general_search

ينفذ بحثًا عامًا على الويب ويرجع النتائج منسقة.

**كيفية استدعاء هذه الأداة:**

يمكنك استدعاء `general_search` من سكربتك الخاص باستخدام MCP Python SDK، أو تفاعليًا باستخدام Inspector أو وضع العميل التفاعلي. إليك مثال كود باستخدام SDK:

<details>
<summary>مثال Python</summary>

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

بدلاً من ذلك، في الوضع التفاعلي، اختر `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (نص): استعلام البحث

**مثال على الطلب:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

يبحث عن مقالات إخبارية حديثة مرتبطة باستعلام.

**كيفية استدعاء هذه الأداة:**

يمكنك استدعاء `news_search` من سكربتك الخاص باستخدام MCP Python SDK، أو تفاعليًا باستخدام Inspector أو وضع العميل التفاعلي. إليك مثال كود باستخدام SDK:

<details>
<summary>مثال Python</summary>

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

بدلاً من ذلك، في الوضع التفاعلي، اختر `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (نص): استعلام البحث

**مثال على الطلب:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

يبحث عن منتجات تطابق استعلامًا.

**كيفية استدعاء هذه الأداة:**

يمكنك استدعاء `product_search` من سكربتك الخاص باستخدام MCP Python SDK، أو تفاعليًا باستخدام Inspector أو وضع العميل التفاعلي. إليك مثال كود باستخدام SDK:

<details>
<summary>مثال Python</summary>

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

بدلاً من ذلك، في الوضع التفاعلي، اختر `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (نص): استعلام البحث عن المنتج

**مثال على الطلب:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

يحصل على إجابات مباشرة للأسئلة من محركات البحث.

**كيفية استدعاء هذه الأداة:**

يمكنك استدعاء `qna` من سكربتك الخاص باستخدام MCP Python SDK، أو تفاعليًا باستخدام Inspector أو وضع العميل التفاعلي. إليك مثال كود باستخدام SDK:

<details>
<summary>مثال Python</summary>

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

بدلاً من ذلك، في الوضع التفاعلي، اختر `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (نص): السؤال لإيجاد إجابة له

**مثال على الطلب:**

```json
{
  "question": "what is artificial intelligence"
}
```

## تفاصيل الكود

يوفر هذا القسم مقتطفات كود ومراجع لتنفيذات الخادم والعميل.

<details>
<summary>Python</summary>

راجع [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) للتفاصيل الكاملة للتنفيذ.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## مفاهيم متقدمة في هذا الدرس

قبل أن تبدأ في البناء، هنا بعض المفاهيم المتقدمة المهمة التي ستظهر طوال هذا الفصل. فهمها سيساعدك على المتابعة، حتى لو كنت جديدًا عليها:

- **تنسيق عدة أدوات**: يعني تشغيل عدة أدوات مختلفة (مثل البحث على الويب، البحث في الأخبار، البحث عن المنتجات، والأسئلة والأجوبة) ضمن خادم MCP واحد. يسمح لخادمك بالتعامل مع مهام متنوعة، وليس واحدة فقط.
- **إدارة حدود معدل API**: العديد من واجهات برمجة التطبيقات الخارجية (مثل SerpAPI) تحدد عدد الطلبات التي يمكنك إرسالها خلال فترة زمنية معينة. الكود الجيد يتحقق من هذه الحدود ويتعامل معها بسلاسة، حتى لا يتعطل تطبيقك إذا تجاوزت الحد.
- **تحليل البيانات المنظمة**: غالبًا ما تكون استجابات API معقدة ومتداخلة. هذا المفهوم يتعلق بتحويل تلك الاستجابات إلى تنسيقات نظيفة وسهلة الاستخدام تناسب LLM أو برامج أخرى.
- **استرداد الأخطاء**: أحيانًا تحدث مشاكل—ربما فشل الشبكة، أو لم ترجع API ما تتوقعه. استرداد الأخطاء يعني أن كودك يمكنه التعامل مع هذه المشاكل ويعطي ملاحظات مفيدة بدلًا من التعطل.
- **التحقق من المعلمات**: يتعلق هذا بالتأكد من أن كل المدخلات لأدواتك صحيحة وآمنة للاستخدام. يشمل تعيين القيم الافتراضية والتأكد من صحة الأنواع، مما يساعد على منع الأخطاء والارتباك.

## استكشاف الأخطاء وإصلاحها

عند العمل مع خادم MCP للبحث على الويب، قد تواجه أحيانًا مشكلات—وهذا أمر طبيعي عند التطوير مع واجهات برمجة التطبيقات الخارجية وأدوات جديدة. يوفر هذا القسم حلولًا عملية لأكثر المشاكل شيوعًا، حتى تعود إلى المسار بسرعة. إذا واجهت خطأً، ابدأ من هنا: النصائح أدناه تعالج المشكلات التي يواجهها معظم المستخدمين وغالبًا ما تحل مشكلتك دون الحاجة لمساعدة إضافية.

### المشاكل الشائعة

فيما يلي بعض أكثر المشاكل تكرارًا التي يواجهها المستخدمون، مع شرح واضح وخطوات لحلها:

1. **غياب SERPAPI_KEY في ملف .env**
   - إذا رأيت الخطأ `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `` تأكد من وجود ملف `.env` إذا لزم الأمر. إذا كان مفتاحك صحيحًا لكن الخطأ مستمر، تحقق مما إذا كانت الحصة المجانية الخاصة بك قد انتهت.

### وضع التصحيح (Debug Mode)

بشكل افتراضي، يسجل التطبيق المعلومات المهمة فقط. إذا أردت رؤية تفاصيل أكثر عما يحدث (مثل تشخيص مشاكل معقدة)، يمكنك تفعيل وضع DEBUG. سيعرض هذا مزيدًا من التفاصيل عن كل خطوة يتخذها التطبيق.

**مثال: المخرجات العادية**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**مثال: مخرجات DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

لاحظ كيف يتضمن وضع DEBUG خطوطًا إضافية حول طلبات HTTP، الاستجابات، وتفاصيل داخلية أخرى. هذا يمكن أن يكون مفيدًا جدًا لاستكشاف الأخطاء.

لتفعيل وضع DEBUG، اضبط مستوى التسجيل على DEBUG في أعلى ملف `client.py` or `server.py`:

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

## ما التالي

- [5.10 البث المباشر في الوقت الحقيقي](../mcp-realtimestreaming/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الحساسة أو الهامة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.