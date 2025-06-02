<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:24:52+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fa"
}
-->
# درس: ساخت یک سرور MCP جستجوی وب

این فصل نحوه ساخت یک عامل هوش مصنوعی واقعی را نشان می‌دهد که با APIهای خارجی ادغام می‌شود، انواع داده‌های متنوع را مدیریت می‌کند، خطاها را کنترل می‌کند و چندین ابزار را هماهنگ می‌کند — همه در قالبی آماده برای تولید. شما خواهید دید:

- **ادغام با APIهای خارجی که نیاز به احراز هویت دارند**  
- **مدیریت انواع داده‌های مختلف از چندین نقطه پایانی**  
- **استراتژی‌های قوی برای مدیریت خطا و ثبت گزارش**  
- **هماهنگی چندابزاری در یک سرور واحد**

در پایان، تجربه عملی با الگوها و بهترین روش‌هایی خواهید داشت که برای برنامه‌های پیشرفته مبتنی بر هوش مصنوعی و LLM ضروری‌اند.

## مقدمه

در این درس، یاد می‌گیرید چگونه یک سرور و کلاینت MCP پیشرفته بسازید که قابلیت‌های LLM را با داده‌های وب به‌روزرسانی‌شده در زمان واقعی با استفاده از SerpAPI گسترش می‌دهد. این مهارتی حیاتی برای توسعه عوامل هوش مصنوعی پویا است که می‌توانند به اطلاعات به‌روز وب دسترسی داشته باشند.

## اهداف یادگیری

در پایان این درس، قادر خواهید بود:

- APIهای خارجی (مانند SerpAPI) را به صورت امن در یک سرور MCP ادغام کنید  
- چندین ابزار برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ پیاده‌سازی کنید  
- داده‌های ساختاریافته را برای مصرف LLM تجزیه و قالب‌بندی کنید  
- خطاها را مدیریت کرده و محدودیت‌های نرخ API را به‌طور مؤثر کنترل کنید  
- کلاینت‌های MCP خودکار و تعاملی را بسازید و آزمایش کنید

## سرور MCP جستجوی وب

این بخش معماری و ویژگی‌های سرور MCP جستجوی وب را معرفی می‌کند. خواهید دید چگونه FastMCP و SerpAPI با هم استفاده می‌شوند تا قابلیت‌های LLM را با داده‌های وب زمان واقعی گسترش دهند.

### نمای کلی

این پیاده‌سازی شامل چهار ابزار است که توانایی MCP در مدیریت وظایف متنوع مبتنی بر APIهای خارجی را به صورت امن و کارآمد نشان می‌دهد:

- **general_search**: برای نتایج گسترده وب  
- **news_search**: برای عناوین خبری اخیر  
- **product_search**: برای داده‌های تجارت الکترونیک  
- **qna**: برای قطعات پرسش و پاسخ

### ویژگی‌ها  
- **مثال‌های کد**: شامل بلوک‌های کد مخصوص زبان پایتون (و به آسانی قابل گسترش به زبان‌های دیگر) با بخش‌های جمع‌شونده برای وضوح بیشتر

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

قبل از اجرای کلاینت، بهتر است بفهمید سرور چه کاری انجام می‌دهد. فایل [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

در اینجا یک مثال کوتاه از نحوه تعریف و ثبت یک ابزار در سرور آورده شده است:

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

- **ادغام API خارجی**: نشان می‌دهد چگونه کلیدهای API و درخواست‌های خارجی به صورت امن مدیریت می‌شوند  
- **تجزیه داده‌های ساختاریافته**: نحوه تبدیل پاسخ‌های API به فرمت‌های مناسب برای LLM را نمایش می‌دهد  
- **مدیریت خطا**: کنترل قوی خطاها با ثبت مناسب گزارش‌ها  
- **کلاینت تعاملی**: شامل تست‌های خودکار و حالت تعاملی برای آزمایش  
- **مدیریت زمینه**: استفاده از MCP Context برای ثبت گزارش و پیگیری درخواست‌ها

## پیش‌نیازها

قبل از شروع، مطمئن شوید محیط شما به درستی تنظیم شده است با دنبال کردن این مراحل. این کار تضمین می‌کند که همه وابستگی‌ها نصب شده‌اند و کلیدهای API شما به درستی برای توسعه و تست بدون مشکل پیکربندی شده‌اند.

- پایتون نسخه ۳.۸ یا بالاتر  
- کلید API SerpAPI (ثبت نام در [SerpAPI](https://serpapi.com/) - پلن رایگان موجود است)

## نصب

برای شروع، مراحل زیر را برای راه‌اندازی محیط خود دنبال کنید:

1. نصب وابستگی‌ها با استفاده از uv (توصیه شده) یا pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. ایجاد فایل `.env` در ریشه پروژه با کلید SerpAPI خود:

```
SERPAPI_KEY=your_serpapi_key_here
```

## استفاده

سرور MCP جستجوی وب، بخش اصلی است که ابزارهایی برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ را با ادغام SerpAPI در اختیار قرار می‌دهد. این سرور درخواست‌های ورودی را مدیریت می‌کند، تماس‌های API را کنترل می‌کند، پاسخ‌ها را تجزیه می‌کند و نتایج ساختاریافته را به کلاینت بازمی‌گرداند.

می‌توانید پیاده‌سازی کامل را در [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) بررسی کنید.

### اجرای سرور

برای راه‌اندازی سرور MCP، از دستور زیر استفاده کنید:

```bash
python server.py
```

سرور به صورت یک MCP مبتنی بر stdio اجرا خواهد شد که کلاینت می‌تواند مستقیماً به آن متصل شود.

### حالت‌های کلاینت

کلاینت (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### اجرای کلاینت

برای اجرای تست‌های خودکار (که به صورت خودکار سرور را هم راه‌اندازی می‌کند):

```bash
python client.py
```

یا اجرای حالت تعاملی:

```bash
python client.py --interactive
```

### تست با روش‌های مختلف

بسته به نیازها و روند کاری خود، راه‌های مختلفی برای تست و تعامل با ابزارهای ارائه‌شده توسط سرور وجود دارد.

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

در این زمینه، «اسکریپت تست» به معنای یک برنامه پایتون سفارشی است که شما می‌نویسید تا به عنوان کلاینت برای سرور MCP عمل کند. این اسکریپت به جای اینکه یک تست واحد رسمی باشد، به شما اجازه می‌دهد به صورت برنامه‌نویسی به سرور متصل شوید، هر یک از ابزارهای آن را با پارامترهای دلخواه فراخوانی کنید و نتایج را بررسی کنید. این روش برای موارد زیر مفید است:  
- نمونه‌سازی و آزمایش فراخوانی ابزارها  
- اعتبارسنجی پاسخ سرور به ورودی‌های مختلف  
- خودکارسازی فراخوانی‌های مکرر ابزار  
- ساخت روندهای کاری یا ادغام‌های سفارشی بر پایه سرور MCP

می‌توانید از اسکریپت‌های تست برای آزمایش سریع کوئری‌های جدید، رفع اشکال رفتار ابزار یا حتی به عنوان نقطه شروعی برای اتوماسیون پیشرفته‌تر استفاده کنید. در ادامه مثالی از نحوه استفاده از MCP Python SDK برای ساخت چنین اسکریپتی آمده است:

## توضیحات ابزارها

می‌توانید از ابزارهای زیر که توسط سرور ارائه شده‌اند برای انجام انواع مختلف جستجوها و پرسش‌ها استفاده کنید. هر ابزار همراه با پارامترها و نمونه استفاده شرح داده شده است.

این بخش جزئیات هر ابزار موجود و پارامترهای آن‌ها را ارائه می‌دهد.

### general_search

یک جستجوی کلی وب انجام می‌دهد و نتایج قالب‌بندی‌شده را بازمی‌گرداند.

**نحوه فراخوانی این ابزار:**

می‌توانید `general_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا یک مثال کد با استفاده از SDK آمده است:

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

همچنین، در حالت تعاملی، `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (رشته): عبارت جستجو را انتخاب کنید

**درخواست نمونه:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

جستجو برای مقالات خبری اخیر مرتبط با یک عبارت.

**نحوه فراخوانی این ابزار:**

می‌توانید `news_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا یک مثال کد با استفاده از SDK آمده است:

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

همچنین، در حالت تعاملی، `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (رشته): عبارت جستجو را انتخاب کنید

**درخواست نمونه:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

جستجو برای محصولاتی که با یک عبارت مطابقت دارند.

**نحوه فراخوانی این ابزار:**

می‌توانید `product_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا یک مثال کد با استفاده از SDK آمده است:

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

همچنین، در حالت تعاملی، `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (رشته): عبارت جستجوی محصول را انتخاب کنید

**درخواست نمونه:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

پاسخ‌های مستقیم به سوالات از موتورهای جستجو دریافت می‌کند.

**نحوه فراخوانی این ابزار:**

می‌توانید `qna` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا یک مثال کد با استفاده از SDK آمده است:

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

همچنین، در حالت تعاملی، `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (رشته): سوالی که می‌خواهید پاسخ آن را پیدا کنید انتخاب کنید

**درخواست نمونه:**

```json
{
  "question": "what is artificial intelligence"
}
```

## جزئیات کد

این بخش قطعات کد و مراجع مربوط به پیاده‌سازی‌های سرور و کلاینت را ارائه می‌دهد.

<details>
<summary>پایتون</summary>

جزئیات کامل پیاده‌سازی را در [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) ببینید.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## مفاهیم پیشرفته در این درس

قبل از شروع به ساخت، در اینجا چند مفهوم پیشرفته مهم آورده شده که در طول این فصل ظاهر می‌شوند. درک این‌ها به شما کمک می‌کند بهتر همراه باشید، حتی اگر تازه‌کار باشید:

- **هماهنگی چندابزاری**: یعنی اجرای چندین ابزار مختلف (مانند جستجوی وب، جستجوی اخبار، جستجوی محصول و پرسش و پاسخ) در یک سرور MCP واحد. این امکان را می‌دهد که سرور شما وظایف متنوعی را مدیریت کند، نه فقط یکی.  
- **مدیریت محدودیت نرخ API**: بسیاری از APIهای خارجی (مانند SerpAPI) محدودیت‌هایی روی تعداد درخواست‌ها در بازه زمانی مشخص دارند. کد خوب این محدودیت‌ها را چک می‌کند و به صورت مناسب آن‌ها را مدیریت می‌کند تا برنامه شما در صورت رسیدن به محدودیت خراب نشود.  
- **تجزیه داده‌های ساختاریافته**: پاسخ‌های API اغلب پیچیده و تو در تو هستند. این مفهوم مربوط به تبدیل آن پاسخ‌ها به فرمت‌های تمیز و آسان برای استفاده است که برای LLMها یا برنامه‌های دیگر مناسب باشد.  
- **بازیابی خطا**: گاهی اوقات مشکلاتی پیش می‌آید — شاید شبکه قطع شود یا API آنچه انتظار دارید را برنگرداند. بازیابی خطا یعنی کد شما بتواند این مشکلات را مدیریت کند و همچنان بازخورد مفید بدهد، به جای اینکه کرش کند.  
- **اعتبارسنجی پارامترها**: این مربوط به بررسی این است که همه ورودی‌های ابزارهای شما صحیح و ایمن برای استفاده باشند. شامل تنظیم مقادیر پیش‌فرض و اطمینان از درست بودن نوع داده‌ها می‌شود که به جلوگیری از خطا و سردرگمی کمک می‌کند.

این بخش به شما کمک می‌کند مشکلات رایجی که ممکن است هنگام کار با سرور MCP جستجوی وب با آن‌ها مواجه شوید را تشخیص داده و حل کنید. اگر به خطا یا رفتار غیرمنتظره برخوردید، این بخش عیب‌یابی راه‌حل‌هایی برای مشکلات متداول ارائه می‌دهد. قبل از درخواست کمک بیشتر، این نکات را بررسی کنید — اغلب مشکلات را سریع حل می‌کنند.

## عیب‌یابی

هنگام کار با سرور MCP جستجوی وب، ممکن است گاهی با مشکلاتی مواجه شوید — این طبیعی است وقتی با APIهای خارجی و ابزارهای جدید توسعه می‌دهید. این بخش راه‌حل‌های عملی برای رایج‌ترین مشکلات ارائه می‌دهد تا بتوانید سریع به مسیر درست برگردید. اگر با خطایی مواجه شدید، از اینجا شروع کنید: نکات زیر به مشکلاتی می‌پردازند که اکثر کاربران با آن‌ها روبرو می‌شوند و اغلب بدون کمک اضافی مشکل شما را حل می‌کنند.

### مشکلات رایج

در ادامه برخی از مشکلات متداول کاربران به همراه توضیحات واضح و مراحل رفع آن‌ها آمده است:

1. **کلید SERPAPI_KEY در فایل .env وجود ندارد**  
   - اگر خطای `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` را دیدید، فایل `.env` را ایجاد کنید و کلید خود را وارد کنید. اگر کلید شما صحیح است اما هنوز این خطا را می‌بینید، بررسی کنید که آیا پلن رایگان شما تمام نشده باشد.

### حالت اشکال‌زدایی

به طور پیش‌فرض، برنامه فقط اطلاعات مهم را ثبت می‌کند. اگر می‌خواهید جزئیات بیشتری درباره اتفاقات ببینید (مثلاً برای تشخیص مشکلات پیچیده)، می‌توانید حالت DEBUG را فعال کنید. این حالت اطلاعات بیشتری درباره هر مرحله که برنامه انجام می‌دهد نشان می‌دهد.

**مثال: خروجی معمولی**  
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**مثال: خروجی DEBUG**  
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

توجه کنید که حالت DEBUG شامل خطوط اضافی درباره درخواست‌ها و پاسخ‌های HTTP و جزئیات داخلی دیگر است. این برای عیب‌یابی بسیار مفید است.

برای فعال کردن حالت DEBUG، سطح ثبت گزارش را در بالای فایل `client.py` or `server.py` به DEBUG تغییر دهید:

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
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما در قبال هرگونه سوءتفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه مسئولیتی نداریم.