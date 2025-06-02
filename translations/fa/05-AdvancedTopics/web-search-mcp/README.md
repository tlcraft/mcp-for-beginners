<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:02:31+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fa"
}
-->
# درس: ساخت یک سرور MCP جستجوی وب

این فصل نشان می‌دهد چگونه یک عامل هوش مصنوعی واقعی بسازید که با APIهای خارجی یکپارچه شود، انواع داده‌های مختلف را مدیریت کند، خطاها را کنترل کند و چندین ابزار را هماهنگ کند—همه در قالبی آماده برای تولید. شما خواهید دید:

- **یکپارچه‌سازی با APIهای خارجی که نیاز به احراز هویت دارند**
- **مدیریت انواع داده‌های مختلف از چندین نقطه پایانی**
- **استراتژی‌های قدرتمند برای مدیریت خطا و ثبت لاگ**
- **هماهنگی چندابزاره در یک سرور واحد**

در پایان، تجربه عملی با الگوها و بهترین روش‌هایی خواهید داشت که برای برنامه‌های پیشرفته هوش مصنوعی و LLM ضروری هستند.

## مقدمه

در این درس، خواهید آموخت چگونه یک سرور و کلاینت MCP پیشرفته بسازید که قابلیت‌های LLM را با داده‌های وب به‌روز و لحظه‌ای از طریق SerpAPI گسترش می‌دهد. این مهارت حیاتی برای توسعه عوامل هوش مصنوعی پویا است که می‌توانند به اطلاعات به‌روز از وب دسترسی داشته باشند.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- APIهای خارجی (مانند SerpAPI) را به‌طور امن در سرور MCP ادغام کنید  
- چندین ابزار برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ پیاده‌سازی کنید  
- داده‌های ساختاریافته را برای مصرف توسط LLM تجزیه و قالب‌بندی کنید  
- خطاها را مدیریت کرده و محدودیت‌های نرخ API را به‌طور مؤثر کنترل کنید  
- کلاینت‌های MCP خودکار و تعاملی را بسازید و تست کنید  

## سرور MCP جستجوی وب

این بخش معماری و ویژگی‌های سرور MCP جستجوی وب را معرفی می‌کند. خواهید دید چگونه FastMCP و SerpAPI با هم به‌کار گرفته می‌شوند تا قابلیت‌های LLM را با داده‌های وب لحظه‌ای گسترش دهند.

### نمای کلی

این پیاده‌سازی شامل چهار ابزار است که توانایی MCP در مدیریت امن و کارآمد وظایف مختلف مبتنی بر APIهای خارجی را نشان می‌دهند:

- **general_search**: برای نتایج گسترده وب  
- **news_search**: برای تیترهای خبری اخیر  
- **product_search**: برای داده‌های تجارت الکترونیک  
- **qna**: برای قطعات پرسش و پاسخ  

### ویژگی‌ها  
- **نمونه‌های کد**: شامل بلوک‌های کد مخصوص زبان پایتون (و به‌راحتی قابل توسعه به زبان‌های دیگر) با بخش‌های تاشو برای وضوح بیشتر

<details>  
<summary>پایتون</summary>  

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

قبل از اجرای کلاینت، مفید است بدانید سرور چه کاری انجام می‌دهد. فایل [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

در اینجا یک مثال کوتاه از نحوه تعریف و ثبت یک ابزار در سرور آمده است:

<details>  
<summary>سرور پایتون</summary> 

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

- **یکپارچه‌سازی API خارجی**: نحوه مدیریت امن کلیدهای API و درخواست‌های خارجی را نشان می‌دهد  
- **تجزیه داده‌های ساختاریافته**: نحوه تبدیل پاسخ‌های API به قالب‌های سازگار با LLM  
- **مدیریت خطا**: کنترل قوی خطاها با ثبت لاگ مناسب  
- **کلاینت تعاملی**: شامل تست‌های خودکار و حالت تعاملی برای آزمایش  
- **مدیریت زمینه**: استفاده از MCP Context برای ثبت لاگ و پیگیری درخواست‌ها  

## پیش‌نیازها

قبل از شروع، مطمئن شوید محیط شما به‌درستی پیکربندی شده است. این اطمینان می‌دهد که همه وابستگی‌ها نصب شده و کلیدهای API به‌درستی تنظیم شده‌اند تا توسعه و تست بدون مشکل انجام شود.

- پایتون نسخه ۳.۸ یا بالاتر  
- کلید API SerpAPI (ثبت‌نام در [SerpAPI](https://serpapi.com/) - نسخه رایگان موجود است)  

## نصب

برای شروع، مراحل زیر را دنبال کنید تا محیط خود را آماده کنید:

1. وابستگی‌ها را با uv (توصیه شده) یا pip نصب کنید:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. یک فایل `.env` در ریشه پروژه بسازید و کلید SerpAPI خود را در آن قرار دهید:

```
SERPAPI_KEY=your_serpapi_key_here
```

## استفاده

سرور MCP جستجوی وب، بخش اصلی است که ابزارهای جستجوی وب، اخبار، محصولات و پرسش و پاسخ را با ادغام SerpAPI در اختیار قرار می‌دهد. این سرور درخواست‌های ورودی را مدیریت، تماس‌های API را انجام، پاسخ‌ها را تجزیه و نتایج ساختاریافته را به کلاینت برمی‌گرداند.

شما می‌توانید پیاده‌سازی کامل را در [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) مشاهده کنید.

### اجرای سرور

برای راه‌اندازی سرور MCP، از دستور زیر استفاده کنید:

```bash
python server.py
```

سرور به‌صورت MCP مبتنی بر stdio اجرا می‌شود که کلاینت می‌تواند مستقیماً به آن متصل شود.

### حالت‌های کلاینت

کلاینت (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### اجرای کلاینت

برای اجرای تست‌های خودکار (که به‌طور خودکار سرور را نیز راه‌اندازی می‌کند):

```bash
python client.py
```

یا اجرای حالت تعاملی:

```bash
python client.py --interactive
```

### تست با روش‌های مختلف

راه‌های مختلفی برای تست و تعامل با ابزارهای ارائه شده توسط سرور وجود دارد که بسته به نیاز و روند کاری شما متفاوت است.

#### نوشتن اسکریپت‌های تست سفارشی با MCP Python SDK  
شما همچنین می‌توانید اسکریپت‌های تست خود را با استفاده از MCP Python SDK بسازید:

<details>
<summary>پایتون</summary>

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

در اینجا "اسکریپت تست" به برنامه پایتون سفارشی اشاره دارد که به عنوان کلاینت برای سرور MCP عمل می‌کند. به جای اینکه یک تست واحد رسمی باشد، این اسکریپت به شما اجازه می‌دهد به صورت برنامه‌نویسی به سرور متصل شده، هر یک از ابزارهای آن را با پارامترهای دلخواه فراخوانی کنید و نتایج را بررسی کنید. این روش برای موارد زیر مفید است:  
- نمونه‌سازی و آزمایش فراخوانی ابزارها  
- اعتبارسنجی پاسخ سرور به ورودی‌های مختلف  
- خودکارسازی فراخوانی‌های مکرر ابزار  
- ساخت گردش‌های کاری یا ادغام‌های سفارشی بر پایه سرور MCP  

می‌توانید از اسکریپت‌های تست برای امتحان سریع پرس‌وجوهای جدید، اشکال‌زدایی رفتار ابزارها، یا حتی به عنوان نقطه شروع برای خودکارسازی‌های پیشرفته‌تر استفاده کنید. در ادامه نمونه‌ای از نحوه استفاده از MCP Python SDK برای ایجاد چنین اسکریپتی آمده است:

## توضیحات ابزارها

شما می‌توانید از ابزارهای زیر که توسط سرور ارائه شده‌اند برای انجام انواع مختلف جستجو و پرس‌وجو استفاده کنید. هر ابزار با پارامترها و نمونه استفاده توضیح داده شده است.

این بخش جزئیات هر ابزار موجود و پارامترهای آن‌ها را ارائه می‌دهد.

### general_search

جستجوی کلی وب را انجام داده و نتایج قالب‌بندی شده را بازمی‌گرداند.

**نحوه فراخوانی این ابزار:**

شما می‌توانید `general_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. نمونه کد زیر با استفاده از SDK است:

<details>
<summary>مثال پایتون</summary>

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

در حالت تعاملی، گزینه `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (رشته): عبارت جستجو را انتخاب کنید

**نمونه درخواست:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

جستجوی اخبار اخیر مرتبط با یک عبارت را انجام می‌دهد.

**نحوه فراخوانی این ابزار:**

شما می‌توانید `news_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. نمونه کد زیر با استفاده از SDK است:

<details>
<summary>مثال پایتون</summary>

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

در حالت تعاملی، گزینه `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (رشته): عبارت جستجو را انتخاب کنید

**نمونه درخواست:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

جستجوی محصولات مطابق با یک عبارت را انجام می‌دهد.

**نحوه فراخوانی این ابزار:**

شما می‌توانید `product_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. نمونه کد زیر با استفاده از SDK است:

<details>
<summary>مثال پایتون</summary>

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

در حالت تعاملی، گزینه `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (رشته): عبارت جستجوی محصول را انتخاب کنید

**نمونه درخواست:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

پاسخ‌های مستقیم به سوالات را از موتورهای جستجو دریافت می‌کند.

**نحوه فراخوانی این ابزار:**

شما می‌توانید `qna` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. نمونه کد زیر با استفاده از SDK است:

<details>
<summary>مثال پایتون</summary>

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

در حالت تعاملی، گزینه `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (رشته): سوالی که می‌خواهید پاسخ آن را پیدا کنید انتخاب کنید

**نمونه درخواست:**

```json
{
  "question": "what is artificial intelligence"
}
```

## جزئیات کد

این بخش قطعات کد و مراجع مربوط به پیاده‌سازی سرور و کلاینت را ارائه می‌دهد.

<details>
<summary>پایتون</summary>

برای جزئیات کامل پیاده‌سازی به [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) مراجعه کنید.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## مفاهیم پیشرفته در این درس

قبل از شروع ساخت، چند مفهوم پیشرفته مهم وجود دارد که در سراسر این فصل ظاهر خواهند شد. درک این موارد به شما کمک می‌کند بهتر همراهی کنید، حتی اگر برای اولین بار با آن‌ها مواجه می‌شوید:

- **هماهنگی چندابزاره**: یعنی اجرای چند ابزار مختلف (مانند جستجوی وب، اخبار، محصولات و پرسش و پاسخ) در یک سرور MCP واحد. این امکان را می‌دهد که سرور شما مجموعه متنوعی از وظایف را مدیریت کند، نه فقط یکی.  
- **مدیریت محدودیت نرخ API**: بسیاری از APIهای خارجی (مانند SerpAPI) تعداد درخواست‌هایی که می‌توانید در زمان مشخص ارسال کنید را محدود می‌کنند. کد خوب این محدودیت‌ها را بررسی کرده و به‌خوبی مدیریت می‌کند تا برنامه شما در صورت رسیدن به محدودیت خراب نشود.  
- **تجزیه داده‌های ساختاریافته**: پاسخ‌های API اغلب پیچیده و تو در تو هستند. این مفهوم به تبدیل آن پاسخ‌ها به قالب‌های تمیز و آسان برای استفاده توسط LLM یا برنامه‌های دیگر اشاره دارد.  
- **بازیابی از خطا**: گاهی اوقات مشکلاتی پیش می‌آید—مثلاً شبکه قطع می‌شود یا API آنچه انتظار داشتید را باز نمی‌گرداند. بازیابی از خطا یعنی کد شما بتواند این مشکلات را مدیریت کرده و بازخورد مفیدی بدهد، به جای اینکه خراب شود.  
- **اعتبارسنجی پارامترها**: یعنی بررسی اینکه همه ورودی‌های ابزارهای شما درست و ایمن باشند. این شامل تعیین مقادیر پیش‌فرض و اطمینان از نوع داده‌ها است که به جلوگیری از خطا و سردرگمی کمک می‌کند.  

این بخش به شما کمک می‌کند مشکلات رایج هنگام کار با سرور MCP جستجوی وب را تشخیص داده و حل کنید. اگر با خطا یا رفتار غیرمنتظره‌ای روبرو شدید، این بخش راه‌حل‌هایی برای رایج‌ترین مشکلات ارائه می‌دهد. قبل از درخواست کمک بیشتر، این نکات را مرور کنید—اغلب مشکلات به سرعت حل می‌شوند.

## عیب‌یابی

هنگام کار با سرور MCP جستجوی وب، ممکن است گاهی به مشکلاتی برخورد کنید—این طبیعی است هنگام توسعه با APIهای خارجی و ابزارهای جدید. این بخش راه‌حل‌های عملی برای رایج‌ترین مشکلات ارائه می‌دهد تا سریع‌تر به مسیر اصلی بازگردید. اگر خطایی رخ داد، از اینجا شروع کنید: نکات زیر به مشکلاتی که اکثر کاربران با آن مواجه می‌شوند می‌پردازد و اغلب بدون کمک اضافی مشکل شما را حل می‌کند.

### مشکلات رایج

در ادامه برخی از رایج‌ترین مشکلات کاربران به همراه توضیحات واضح و مراحل رفع آن‌ها آمده است:

1. **عدم وجود SERPAPI_KEY در فایل .env**  
   - اگر خطای `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` را دیدید، فایل `.env` را ایجاد کنید و کلید خود را اضافه کنید. اگر کلید شما صحیح است اما هنوز این خطا را مشاهده می‌کنید، بررسی کنید که سهمیه رایگان شما تمام نشده باشد.

### حالت دیباگ

به‌طور پیش‌فرض، برنامه فقط اطلاعات مهم را لاگ می‌کند. اگر می‌خواهید جزئیات بیشتری از روند کار ببینید (مثلاً برای عیب‌یابی مشکلات پیچیده)، می‌توانید حالت DEBUG را فعال کنید. این حالت جزئیات بیشتری درباره هر مرحله‌ای که برنامه انجام می‌دهد نشان می‌دهد.

**نمونه خروجی معمولی**  
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**نمونه خروجی DEBUG**  
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

توجه کنید که حالت DEBUG شامل خطوط اضافی درباره درخواست‌ها و پاسخ‌های HTTP و سایر جزئیات داخلی است. این می‌تواند برای عیب‌یابی بسیار مفید باشد.

برای فعال‌سازی حالت DEBUG، سطح لاگینگ را در بالای فایل `client.py` or `server.py` به DEBUG تغییر دهید:

<details>
<summary>پایتون</summary>

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

## گام بعدی

- [6. مشارکت‌های جامعه](../../06-CommunityContributions/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.