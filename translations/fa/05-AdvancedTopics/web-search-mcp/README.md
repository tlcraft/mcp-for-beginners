<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-07-14T03:24:56+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fa"
}
-->
# درس: ساخت یک سرور MCP جستجوی وب

این فصل نشان می‌دهد چگونه یک عامل هوش مصنوعی واقعی بسازید که با APIهای خارجی یکپارچه شده، انواع داده‌های مختلف را مدیریت می‌کند، خطاها را کنترل می‌کند و چندین ابزار را هماهنگ می‌سازد — همه در قالبی آماده برای تولید. شما خواهید دید:

- **یکپارچه‌سازی با APIهای خارجی که نیاز به احراز هویت دارند**
- **مدیریت انواع داده‌های متنوع از چندین نقطه پایانی**
- **استراتژی‌های قوی برای مدیریت خطا و ثبت لاگ**
- **هماهنگی چند ابزار در یک سرور واحد**

در پایان، تجربه عملی با الگوها و بهترین روش‌هایی خواهید داشت که برای برنامه‌های پیشرفته هوش مصنوعی و مبتنی بر LLM ضروری هستند.

## مقدمه

در این درس، یاد می‌گیرید چگونه یک سرور و کلاینت MCP پیشرفته بسازید که قابلیت‌های LLM را با داده‌های وب در زمان واقعی از طریق SerpAPI گسترش می‌دهد. این مهارت حیاتی برای توسعه عوامل هوش مصنوعی پویا است که می‌توانند به اطلاعات به‌روز وب دسترسی داشته باشند.

## اهداف یادگیری

در پایان این درس، قادر خواهید بود:

- APIهای خارجی (مانند SerpAPI) را به صورت امن در یک سرور MCP ادغام کنید
- چندین ابزار برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ پیاده‌سازی کنید
- داده‌های ساختاریافته را برای مصرف LLM تجزیه و قالب‌بندی کنید
- خطاها را مدیریت کرده و محدودیت‌های نرخ API را به طور مؤثر کنترل کنید
- هر دو کلاینت خودکار و تعاملی MCP را بسازید و تست کنید

## سرور MCP جستجوی وب

این بخش معماری و ویژگی‌های سرور MCP جستجوی وب را معرفی می‌کند. خواهید دید چگونه FastMCP و SerpAPI با هم استفاده می‌شوند تا قابلیت‌های LLM را با داده‌های وب در زمان واقعی گسترش دهند.

### مرور کلی

این پیاده‌سازی شامل چهار ابزار است که توانایی MCP در مدیریت وظایف متنوع و مبتنی بر APIهای خارجی را به صورت امن و کارآمد نشان می‌دهد:

- **general_search**: برای نتایج گسترده وب
- **news_search**: برای عناوین خبری اخیر
- **product_search**: برای داده‌های تجارت الکترونیک
- **qna**: برای قطعات پرسش و پاسخ

### ویژگی‌ها
- **نمونه‌های کد**: شامل بلوک‌های کد مخصوص زبان پایتون (و به راحتی قابل توسعه به زبان‌های دیگر) با بخش‌های قابل جمع شدن برای وضوح بیشتر

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

قبل از اجرای کلاینت، مفید است بدانید سرور چه کاری انجام می‌دهد. فایل [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) سرور MCP را پیاده‌سازی می‌کند که ابزارهایی برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ را با ادغام SerpAPI ارائه می‌دهد. این سرور درخواست‌های ورودی را مدیریت می‌کند، تماس‌های API را انجام می‌دهد، پاسخ‌ها را تجزیه می‌کند و نتایج ساختاریافته را به کلاینت بازمی‌گرداند.

می‌توانید پیاده‌سازی کامل را در [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) بررسی کنید.

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
- **تجزیه داده‌های ساختاریافته**: نحوه تبدیل پاسخ‌های API به فرمت‌های مناسب برای LLM را نمایش می‌دهد
- **مدیریت خطا**: مدیریت قوی خطاها با ثبت لاگ مناسب
- **کلاینت تعاملی**: شامل تست‌های خودکار و حالت تعاملی برای آزمایش
- **مدیریت زمینه**: استفاده از MCP Context برای ثبت لاگ و پیگیری درخواست‌ها

## پیش‌نیازها

قبل از شروع، مطمئن شوید محیط شما به درستی تنظیم شده است با دنبال کردن این مراحل. این کار تضمین می‌کند که تمام وابستگی‌ها نصب شده و کلیدهای API شما به درستی پیکربندی شده‌اند تا توسعه و تست بدون مشکل انجام شود.

- پایتون نسخه ۳.۸ یا بالاتر
- کلید API SerpAPI (ثبت‌نام در [SerpAPI](https://serpapi.com/) - نسخه رایگان موجود است)

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

سرور MCP جستجوی وب، بخش اصلی است که ابزارهایی برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ را با ادغام SerpAPI ارائه می‌دهد. این سرور درخواست‌های ورودی را مدیریت می‌کند، تماس‌های API را انجام می‌دهد، پاسخ‌ها را تجزیه می‌کند و نتایج ساختاریافته را به کلاینت بازمی‌گرداند.

می‌توانید پیاده‌سازی کامل را در [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) بررسی کنید.

### اجرای سرور

برای راه‌اندازی سرور MCP، از دستور زیر استفاده کنید:

```bash
python server.py
```

سرور به صورت یک سرور MCP مبتنی بر stdio اجرا می‌شود که کلاینت می‌تواند مستقیماً به آن متصل شود.

### حالت‌های کلاینت

کلاینت (`client.py`) دو حالت برای تعامل با سرور MCP پشتیبانی می‌کند:

- **حالت عادی**: تست‌های خودکاری را اجرا می‌کند که همه ابزارها را به کار می‌گیرند و پاسخ‌های آن‌ها را بررسی می‌کنند. این حالت برای بررسی سریع عملکرد سرور و ابزارها مفید است.
- **حالت تعاملی**: یک رابط منو محور راه‌اندازی می‌کند که می‌توانید به صورت دستی ابزارها را انتخاب و فراخوانی کنید، پرسش‌های سفارشی وارد کنید و نتایج را در زمان واقعی ببینید. این حالت برای کاوش قابلیت‌های سرور و آزمایش ورودی‌های مختلف ایده‌آل است.

می‌توانید پیاده‌سازی کامل را در [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) بررسی کنید.

### اجرای کلاینت

برای اجرای تست‌های خودکار (که به طور خودکار سرور را نیز راه‌اندازی می‌کند):

```bash
python client.py
```

یا در حالت تعاملی اجرا کنید:

```bash
python client.py --interactive
```

### تست با روش‌های مختلف

راه‌های متعددی برای تست و تعامل با ابزارهای ارائه شده توسط سرور وجود دارد، بسته به نیازها و روند کاری شما.

#### نوشتن اسکریپت‌های تست سفارشی با MCP Python SDK
همچنین می‌توانید اسکریپت‌های تست خود را با استفاده از MCP Python SDK بسازید:

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

در این زمینه، "اسکریپت تست" به معنای برنامه پایتون سفارشی است که شما می‌نویسید تا به عنوان کلاینت برای سرور MCP عمل کند. این اسکریپت به جای اینکه یک تست واحد رسمی باشد، به شما اجازه می‌دهد به صورت برنامه‌نویسی به سرور متصل شوید، هر یک از ابزارهای آن را با پارامترهای دلخواه فراخوانی کنید و نتایج را بررسی کنید. این روش برای موارد زیر مفید است:
- نمونه‌سازی و آزمایش فراخوانی ابزارها
- اعتبارسنجی نحوه پاسخ سرور به ورودی‌های مختلف
- خودکارسازی فراخوانی‌های مکرر ابزارها
- ساخت روندهای کاری یا یکپارچه‌سازی‌های خود بر پایه سرور MCP

می‌توانید از اسکریپت‌های تست برای امتحان سریع پرسش‌های جدید، اشکال‌زدایی رفتار ابزارها یا حتی به عنوان نقطه شروعی برای اتوماسیون پیشرفته‌تر استفاده کنید. در ادامه نمونه‌ای از نحوه استفاده از MCP Python SDK برای ساخت چنین اسکریپتی آمده است:

## توضیحات ابزارها

می‌توانید از ابزارهای زیر که توسط سرور ارائه شده‌اند برای انجام انواع مختلف جستجو و پرسش استفاده کنید. هر ابزار با پارامترها و نمونه استفاده آن در ادامه توضیح داده شده است.

این بخش جزئیات هر ابزار موجود و پارامترهای آن‌ها را ارائه می‌دهد.

### general_search

یک جستجوی کلی وب انجام می‌دهد و نتایج قالب‌بندی شده را بازمی‌گرداند.

**نحوه فراخوانی این ابزار:**

می‌توانید `general_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا نمونه کدی با استفاده از SDK آمده است:

<details>
<summary>نمونه پایتون</summary>

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

همچنین در حالت تعاملی، از منو `general_search` را انتخاب کرده و هنگام درخواست، پرسش خود را وارد کنید.

**پارامترها:**
- `query` (رشته): پرسش جستجو

**نمونه درخواست:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

برای جستجوی اخبار اخیر مرتبط با یک پرسش استفاده می‌شود.

**نحوه فراخوانی این ابزار:**

می‌توانید `news_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا نمونه کدی با استفاده از SDK آمده است:

<details>
<summary>نمونه پایتون</summary>

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

همچنین در حالت تعاملی، از منو `news_search` را انتخاب کرده و هنگام درخواست، پرسش خود را وارد کنید.

**پارامترها:**
- `query` (رشته): پرسش جستجو

**نمونه درخواست:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

برای جستجوی محصولاتی که با پرسش مطابقت دارند استفاده می‌شود.

**نحوه فراخوانی این ابزار:**

می‌توانید `product_search` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا نمونه کدی با استفاده از SDK آمده است:

<details>
<summary>نمونه پایتون</summary>

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

همچنین در حالت تعاملی، از منو `product_search` را انتخاب کرده و هنگام درخواست، پرسش خود را وارد کنید.

**پارامترها:**
- `query` (رشته): پرسش جستجوی محصول

**نمونه درخواست:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

پاسخ‌های مستقیم به سوالات را از موتورهای جستجو دریافت می‌کند.

**نحوه فراخوانی این ابزار:**

می‌توانید `qna` را از اسکریپت خود با استفاده از MCP Python SDK فراخوانی کنید، یا به صورت تعاملی با Inspector یا حالت تعاملی کلاینت. در اینجا نمونه کدی با استفاده از SDK آمده است:

<details>
<summary>نمونه پایتون</summary>

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

همچنین در حالت تعاملی، از منو `qna` را انتخاب کرده و هنگام درخواست، سوال خود را وارد کنید.

**پارامترها:**
- `question` (رشته): سوالی که می‌خواهید پاسخ آن را بیابید

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

برای جزئیات کامل پیاده‌سازی به [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) و [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) مراجعه کنید.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## مفاهیم پیشرفته در این درس

قبل از شروع ساخت، در اینجا چند مفهوم پیشرفته مهم آورده شده است که در سراسر این فصل ظاهر خواهند شد. درک این مفاهیم به شما کمک می‌کند بهتر همراهی کنید، حتی اگر با آن‌ها آشنا نباشید:

- **هماهنگی چند ابزار**: یعنی اجرای چندین ابزار مختلف (مانند جستجوی وب، جستجوی اخبار، جستجوی محصول و پرسش و پاسخ) در یک سرور MCP واحد. این امکان را می‌دهد که سرور شما وظایف متنوعی را انجام دهد، نه فقط یک کار.
- **مدیریت محدودیت نرخ API**: بسیاری از APIهای خارجی (مانند SerpAPI) تعداد درخواست‌هایی که می‌توانید در یک بازه زمانی مشخص ارسال کنید را محدود می‌کنند. کد خوب این محدودیت‌ها را بررسی کرده و به طور مناسب مدیریت می‌کند تا برنامه شما در صورت رسیدن به حد مجاز خراب نشود.
- **تجزیه داده‌های ساختاریافته**: پاسخ‌های API اغلب پیچیده و تو در تو هستند. این مفهوم به تبدیل آن پاسخ‌ها به فرمت‌های تمیز و قابل استفاده برای LLMها یا برنامه‌های دیگر اشاره دارد.
- **بازیابی از خطا**: گاهی اوقات مشکلاتی پیش می‌آید — ممکن است شبکه قطع شود یا API پاسخ مورد انتظار را ندهد. بازیابی از خطا یعنی کد شما بتواند این مشکلات را مدیریت کند و بازخورد مفید ارائه دهد، به جای اینکه کرش کند.
- **اعتبارسنجی پارامترها**: این به بررسی صحت و ایمنی ورودی‌های ابزارهای شما اشاره دارد. شامل تعیین مقادیر پیش‌فرض و اطمینان از نوع داده‌ها است که به جلوگیری از خطا و سردرگمی کمک می‌کند.

این بخش به شما کمک می‌کند مشکلات رایجی که ممکن است هنگام کار با سرور MCP جستجوی وب با آن‌ها مواجه شوید را تشخیص داده و حل کنید. اگر هنگام کار با سرور MCP جستجوی وب به خطا یا رفتار غیرمنتظره برخوردید، این بخش عیب‌یابی راه‌حل‌هایی برای رایج‌ترین مشکلات ارائه می‌دهد. قبل از درخواست کمک بیشتر، این نکات را مرور کنید — اغلب مشکلات را سریع حل می‌کنند.

## عیب‌یابی

هنگام کار با سرور MCP جستجوی وب، ممکن است گاهی با مشکلاتی مواجه شوید — این طبیعی است هنگام توسعه با APIهای خارجی و ابزارهای جدید. این بخش راه‌حل‌های عملی برای رایج‌ترین مشکلات ارائه می‌دهد تا سریع‌تر به مسیر خود بازگردید. اگر با خطا مواجه شدید، از اینجا شروع کنید: نکات زیر به مشکلاتی که اکثر کاربران با آن‌ها روبرو می‌شوند می‌پردازد و اغلب بدون نیاز به کمک اضافی مشکل شما را حل می‌کند.

### مشکلات رایج

در ادامه برخی از رایج‌ترین مشکلات کاربران به همراه توضیحات واضح و مراحل حل آن‌ها آمده است:

1. **عدم وجود SERPAPI_KEY در فایل .env**
   - اگر خطای `SERPAPI_KEY environment variable not found` را دیدید، یعنی برنامه شما کلید API لازم برای دسترسی به SerpAPI را پیدا نمی‌کند. برای رفع این مشکل، فایلی به نام `.env` در ریشه پروژه خود ایجاد کنید (اگر قبلاً وجود ندارد) و خطی مانند `SERPAPI_KEY=your_serpapi_key_here` اضافه کنید. مطمئن شوید `your_serpapi_key_here` را با کلید واقعی خود از وب‌سایت SerpAPI جایگزین کرده‌اید.

2. **خطاهای ماژول پیدا نشد**
   - خطاهایی مانند `ModuleNotFoundError: No module named 'httpx'` نشان می‌دهد که یک بسته پایتون مورد نیاز نصب نشده است. معمولاً این اتفاق زمانی می‌افتد که تمام وابستگی‌ها را نصب نکرده باشید. برای رفع این مشکل، دستور `pip install -r requirements.txt` را در ترمینال خود اجرا کنید تا همه نیازمندی‌های پروژه نصب شود.

3. **مشکلات اتصال**
   - اگر خطایی مانند `Error during client execution` دریافت کردید، معمولاً به این معنی است که کلاینت نمی‌تواند به سرور متصل شود یا سرور به درستی اجرا نمی‌شود. مطمئن شوید که کلاینت و سرور نسخه‌های سازگار دارند و فایل `server.py` در دایرکتوری درست وجود دارد و اجرا می‌شود. راه‌اندازی مجدد سرور و کلاینت نیز می‌تواند کمک کند.

4. **خطاهای SerpAPI**
   - مشاهده خطای `Search API returned error status: 401` به این معنی است که کلید SerpAPI شما گم شده، نادرست یا منقضی شده است. به داشبورد SerpAPI خود بروید، کلید را بررسی کنید و در صورت نیاز فایل `.env` را به‌روزرسانی کنید. اگر کلید درست است اما هنوز این خطا را می‌بینید، بررسی کنید که آیا سهمیه رایگان شما تمام شده است یا خیر.

### حالت اشکال‌زدایی (Debug Mode)

به طور پیش‌فرض، برنامه فقط اطلاعات مهم را ثبت می‌کند. اگر می‌خواهید جزئیات بیشتری درباره اتفاقات ببینید (مثلاً برای تشخیص مشکلات پیچیده)، می‌توانید حالت DEBUG را فعال کنید. این حالت جزئیات بیشتری درباره هر مرحله‌ای که برنامه انجام می‌دهد نشان می‌دهد.

**نمونه: خروجی عادی**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**نمونه: خروجی DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

توجه کنید که حالت DEBUG خطوط اضافی درباره درخواست‌ها و پاسخ‌های HTTP و جزئیات داخلی دیگر را شامل می‌شود. این می‌تواند برای عیب‌یابی بسیار مفید باشد.

برای فعال کردن حالت DEBUG، سطح لاگ‌گیری را در بالای فایل `client.py` یا `server.py` به DEBUG تنظیم کنید:

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

## مرحله بعدی

- [5.10 پخش زنده](../mcp-realtimestreaming/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.