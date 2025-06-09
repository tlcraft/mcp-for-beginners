<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:23:37+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "fa"
}
-->
# استفاده از یک سرور در افزونه AI Toolkit برای Visual Studio Code

وقتی در حال ساخت یک عامل هوش مصنوعی هستید، فقط مسئله تولید پاسخ‌های هوشمند نیست؛ بلکه باید به عامل خود توانایی انجام کارهای عملی را هم بدهید. اینجا است که پروتکل مدل کانتکست (MCP) وارد می‌شود. MCP دسترسی عوامل به ابزارها و سرویس‌های خارجی را به روشی یکنواخت آسان می‌کند. می‌توانید آن را مثل وصل کردن عامل خود به یک جعبه ابزار واقعی که می‌تواند از آن استفاده کند، در نظر بگیرید.

فرض کنید عاملی را به سرور MCP ماشین‌حساب خود متصل می‌کنید. ناگهان عامل شما می‌تواند عملیات ریاضی را فقط با دریافت یک درخواست مثل «47 ضربدر 89 چند می‌شود؟» انجام دهد — بدون نیاز به کدنویسی منطق یا ساخت API سفارشی.

## مرور کلی

این درس نحوه اتصال یک سرور MCP ماشین‌حساب به یک عامل با استفاده از افزونه [AI Toolkit](https://aka.ms/AIToolkit) در Visual Studio Code را پوشش می‌دهد، به طوری که عامل شما بتواند عملیات ریاضی مانند جمع، تفریق، ضرب و تقسیم را از طریق زبان طبیعی انجام دهد.

AI Toolkit یک افزونه قدرتمند برای Visual Studio Code است که توسعه عوامل را ساده می‌کند. مهندسان هوش مصنوعی می‌توانند به راحتی برنامه‌های هوش مصنوعی را با توسعه و آزمایش مدل‌های مولد هوش مصنوعی — به صورت محلی یا ابری — بسازند. این افزونه از اکثر مدل‌های مولد اصلی موجود امروز پشتیبانی می‌کند.

*نکته*: AI Toolkit در حال حاضر از Python و TypeScript پشتیبانی می‌کند.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- استفاده از یک سرور MCP از طریق AI Toolkit.
- پیکربندی یک عامل برای کشف و استفاده از ابزارهای ارائه شده توسط سرور MCP.
- استفاده از ابزارهای MCP از طریق زبان طبیعی.

## رویکرد

در اینجا رویکرد کلی که باید دنبال کنیم آمده است:

- ساخت یک عامل و تعریف پرامپت سیستم آن.
- ایجاد یک سرور MCP با ابزارهای ماشین‌حساب.
- اتصال Agent Builder به سرور MCP.
- آزمایش فراخوانی ابزار عامل از طریق زبان طبیعی.

عالی است، حالا که روند کار را فهمیدیم، بیایید عامل هوش مصنوعی را طوری پیکربندی کنیم که از طریق MCP از ابزارهای خارجی بهره ببرد و قابلیت‌هایش را افزایش دهد!

## پیش‌نیازها

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit برای Visual Studio Code](https://aka.ms/AIToolkit)

## تمرین: استفاده از یک سرور

در این تمرین، شما یک عامل هوش مصنوعی با ابزارهای یک سرور MCP را داخل Visual Studio Code با استفاده از AI Toolkit می‌سازید، اجرا می‌کنید و بهبود می‌دهید.

### -0- گام مقدماتی، افزودن مدل OpenAI GPT-4o به My Models

تمرین از مدل **GPT-4o** استفاده می‌کند. قبل از ایجاد عامل، باید این مدل را به **My Models** اضافه کنید.

![تصویری از رابط انتخاب مدل در افزونه AI Toolkit برای Visual Studio Code. عنوان: "مدل مناسب برای راه‌حل هوش مصنوعی خود را پیدا کنید" و زیرعنوانی که کاربران را به کشف، آزمایش و استقرار مدل‌های هوش مصنوعی تشویق می‌کند. زیر عنوان "Popular Models" شش کارت مدل نمایش داده شده‌اند: DeepSeek-R1 (میزبانی شده توسط GitHub)، OpenAI GPT-4o، OpenAI GPT-4.1، OpenAI o1، Phi 4 Mini (CPU - کوچک، سریع)، و DeepSeek-R1 (میزبانی شده توسط Ollama). هر کارت گزینه‌هایی برای "افزودن" مدل یا "آزمایش در Playground" دارد.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.fa.png)

1. افزونه **AI Toolkit** را از **Activity Bar** باز کنید.
2. در بخش **Catalog**، گزینه **Models** را انتخاب کنید تا **Model Catalog** باز شود. انتخاب **Models** باعث باز شدن **Model Catalog** در یک تب ویرایشگر جدید می‌شود.
3. در نوار جستجوی **Model Catalog**، عبارت **OpenAI GPT-4o** را وارد کنید.
4. روی **+ Add** کلیک کنید تا مدل به فهرست **My Models** شما اضافه شود. مطمئن شوید مدلی که انتخاب کرده‌اید **Hosted by GitHub** باشد.
5. در **Activity Bar** تأیید کنید که مدل **OpenAI GPT-4o** در لیست ظاهر شده است.

### -1- ایجاد یک عامل

**Agent (Prompt) Builder** به شما امکان می‌دهد عوامل هوش مصنوعی خود را بسازید و سفارشی کنید. در این بخش، یک عامل جدید ایجاد کرده و یک مدل برای قدرت‌بخشی به گفتگو انتخاب می‌کنید.

![تصویری از رابط "Calculator Agent" در افزونه AI Toolkit برای Visual Studio Code. در پنل سمت چپ، مدل انتخاب شده "OpenAI GPT-4o (via GitHub)" است. پرامپت سیستم می‌گوید: "شما استاد دانشگاه در حال تدریس ریاضی هستید" و پرامپت کاربر: "معادله فوریه را به زبان ساده برایم توضیح بده." گزینه‌های اضافی شامل دکمه‌هایی برای افزودن ابزارها، فعال‌سازی MCP Server و انتخاب خروجی ساختاریافته است. دکمه آبی رنگ "Run" در پایین قرار دارد. در پنل سمت راست، زیر "Get Started with Examples"، سه عامل نمونه فهرست شده‌اند: توسعه‌دهنده وب (با MCP Server)، ساده‌ساز کلاس دوم و مفسر رویا، هر کدام با توضیحات کوتاهی از عملکردشان.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.fa.png)

1. افزونه **AI Toolkit** را از **Activity Bar** باز کنید.
2. در بخش **Tools**، گزینه **Agent (Prompt) Builder** را انتخاب کنید. انتخاب این گزینه باعث باز شدن **Agent (Prompt) Builder** در یک تب جدید می‌شود.
3. روی دکمه **+ New Agent** کلیک کنید. افزونه یک جادوگر راه‌اندازی از طریق **Command Palette** اجرا می‌کند.
4. نام **Calculator Agent** را وارد کرده و کلید **Enter** را فشار دهید.
5. در **Agent (Prompt) Builder**، برای فیلد **Model**، مدل **OpenAI GPT-4o (via GitHub)** را انتخاب کنید.

### -2- ایجاد یک پرامپت سیستم برای عامل

حالا که عامل ساخته شده، وقت آن است که شخصیت و هدف آن را تعریف کنیم. در این بخش، از قابلیت **Generate system prompt** استفاده می‌کنید تا رفتار مورد نظر عامل — در اینجا یک عامل ماشین‌حساب — را توصیف کنید و مدل پرامپت سیستم را برای شما بنویسد.

![تصویری از رابط "Calculator Agent" در AI Toolkit برای Visual Studio Code با یک پنجره مودال باز با عنوان "Generate a prompt". این پنجره توضیح می‌دهد که قالب پرامپت با به اشتراک گذاشتن جزئیات پایه‌ای قابل تولید است و یک کادر متنی با نمونه پرامپت سیستم: "شما یک دستیار ریاضی مفید و کارآمد هستید. هنگام دریافت مسئله‌ای شامل حساب پایه، پاسخ درست را می‌دهید." دکمه‌های "Close" و "Generate" در پایین کادر قرار دارند. در پس‌زمینه، بخشی از پیکربندی عامل قابل مشاهده است، شامل مدل انتخاب شده "OpenAI GPT-4o (via GitHub)" و فیلدهای پرامپت سیستم و کاربر.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.fa.png)

1. در بخش **Prompts**، روی دکمه **Generate system prompt** کلیک کنید. این دکمه سازنده پرامپت را باز می‌کند که از AI برای تولید پرامپت سیستم برای عامل استفاده می‌کند.
2. در پنجره **Generate a prompt**، متن زیر را وارد کنید: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. روی دکمه **Generate** کلیک کنید. اطلاعیه‌ای در گوشه پایین سمت راست ظاهر می‌شود که تأیید می‌کند پرامپت سیستم در حال تولید است. پس از تکمیل، پرامپت در فیلد **System prompt** در **Agent (Prompt) Builder** ظاهر خواهد شد.
4. پرامپت سیستم را مرور کرده و در صورت نیاز ویرایش کنید.

### -3- ایجاد یک سرور MCP

حالا که پرامپت سیستم عامل را تعریف کرده‌اید — که رفتار و پاسخ‌های آن را هدایت می‌کند — وقت آن است که عامل را به قابلیت‌های عملی مجهز کنید. در این بخش، یک سرور MCP ماشین‌حساب با ابزارهایی برای انجام عملیات جمع، تفریق، ضرب و تقسیم ایجاد می‌کنید. این سرور به عامل شما امکان می‌دهد عملیات ریاضی را به صورت زنده در پاسخ به درخواست‌های زبان طبیعی انجام دهد.

![تصویری از بخش پایین رابط Calculator Agent در افزونه AI Toolkit برای Visual Studio Code. منوهای قابل گسترش “Tools” و “Structure output” نمایش داده شده‌اند، همراه با یک منوی کشویی با برچسب “Choose output format” که روی “text” تنظیم شده است. در سمت راست، دکمه‌ای با عنوان “+ MCP Server” برای افزودن سرور Model Context Protocol قرار دارد. بالای بخش Tools یک آیکون تصویر قرار دارد.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.fa.png)

AI Toolkit قالب‌هایی برای آسان‌تر کردن ایجاد سرور MCP ارائه می‌دهد. ما از قالب Python برای ساخت سرور MCP ماشین‌حساب استفاده می‌کنیم.

*نکته*: AI Toolkit در حال حاضر از Python و TypeScript پشتیبانی می‌کند.

1. در بخش **Tools** از **Agent (Prompt) Builder**، روی دکمه **+ MCP Server** کلیک کنید. افزونه جادوگر راه‌اندازی را از طریق **Command Palette** اجرا می‌کند.
2. گزینه **+ Add Server** را انتخاب کنید.
3. گزینه **Create a New MCP Server** را انتخاب کنید.
4. قالب **python-weather** را انتخاب کنید.
5. پوشه پیش‌فرض را برای ذخیره قالب سرور MCP انتخاب کنید.
6. نام سرور را اینگونه وارد کنید: **Calculator**
7. یک پنجره جدید Visual Studio Code باز می‌شود. گزینه **Yes, I trust the authors** را انتخاب کنید.
8. با استفاده از ترمینال (**Terminal** > **New Terminal**)، یک محیط مجازی ایجاد کنید: `python -m venv .venv`
9. با استفاده از ترمینال، محیط مجازی را فعال کنید:
    1. ویندوز - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. با استفاده از ترمینال، وابستگی‌ها را نصب کنید: `pip install -e .[dev]`
11. در نمای **Explorer** از **Activity Bar**، پوشه **src** را باز کرده و فایل **server.py** را برای ویرایش انتخاب کنید.
12. کد داخل فایل **server.py** را با کد زیر جایگزین کرده و ذخیره کنید:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- اجرای عامل با سرور MCP ماشین‌حساب

حالا که عامل شما ابزار دارد، وقت استفاده از آن‌هاست! در این بخش، پرامپت‌هایی را به عامل ارسال می‌کنید تا تست و ارزیابی کنید که آیا عامل از ابزار مناسب سرور MCP ماشین‌حساب استفاده می‌کند یا خیر.

![تصویری از رابط Calculator Agent در افزونه AI Toolkit برای Visual Studio Code. در پنل سمت چپ، زیر “Tools”، یک سرور MCP به نام local-server-calculator_server اضافه شده است که چهار ابزار در دسترس دارد: add، subtract، multiply و divide. یک نشانگر نشان می‌دهد که چهار ابزار فعال هستند. در پایین، بخش “Structure output” جمع شده و یک دکمه آبی “Run” دیده می‌شود. در پنل سمت راست، زیر “Model Response”، عامل ابزارهای multiply و subtract را با ورودی‌های {"a": 3, "b": 25} و {"a": 75, "b": 20} به ترتیب فراخوانی می‌کند. پاسخ نهایی ابزار 75.0 نمایش داده شده است. یک دکمه “View Code” در پایین دیده می‌شود.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.fa.png)

شما سرور MCP ماشین‌حساب را به عنوان کلاینت MCP از طریق **Agent Builder** روی دستگاه توسعه محلی خود اجرا خواهید کرد.

1. کلید `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` را فشار دهید تا مقادیر برای ابزار **subtract** اختصاص داده شوند.
    - پاسخ هر ابزار در بخش مربوط به **Tool Response** ارائه می‌شود.
    - خروجی نهایی مدل در بخش **Model Response** نمایش داده می‌شود.
2. پرامپت‌های بیشتری ارسال کنید تا عامل را بیشتر آزمایش کنید. می‌توانید پرامپت موجود در فیلد **User prompt** را با کلیک و جایگزینی متن تغییر دهید.
3. پس از پایان آزمایش عامل، می‌توانید سرور را از طریق **ترمینال** با فشار دادن **CTRL/CMD+C** متوقف کنید.

## تمرین

سعی کنید یک ابزار جدید به فایل **server.py** خود اضافه کنید (مثلاً بازگرداندن جذر یک عدد). پرامپت‌های بیشتری ارسال کنید که عامل مجبور باشد از ابزار جدید (یا ابزارهای موجود) استفاده کند. حتماً سرور را برای بارگذاری ابزارهای جدید ریستارت کنید.

## راه‌حل

[Solution](./solution/README.md)

## نکات کلیدی

نکات مهم این فصل عبارتند از:

- افزونه AI Toolkit یک کلاینت عالی است که به شما امکان استفاده از سرورهای MCP و ابزارهای آن‌ها را می‌دهد.
- می‌توانید ابزارهای جدید به سرورهای MCP اضافه کنید و قابلیت‌های عامل را برای پاسخگویی به نیازهای در حال تغییر گسترش دهید.
- AI Toolkit قالب‌هایی (مثل قالب سرور MCP پایتون) دارد که ایجاد ابزارهای سفارشی را ساده‌تر می‌کند.

## منابع بیشتر

- [مستندات AI Toolkit](https://aka.ms/AIToolkit/doc)

## مرحله بعد

بعدی: [درس ۴ پیاده‌سازی عملی](/04-PracticalImplementation/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل اشتباهات یا نواقصی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نمی‌باشیم.