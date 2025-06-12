<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-12T22:29:20+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "fa"
}
-->
# استفاده از سرور در افزونه AI Toolkit برای Visual Studio Code

وقتی در حال ساخت یک عامل هوش مصنوعی هستید، فقط مسئله تولید پاسخ‌های هوشمند نیست؛ بلکه باید به عامل خود توانایی انجام اقدامات را هم بدهید. اینجا است که Model Context Protocol (MCP) وارد می‌شود. MCP دسترسی عوامل به ابزارها و سرویس‌های خارجی را به روشی یکپارچه ساده می‌کند. می‌توان آن را مثل وصل کردن عامل به یک جعبه ابزار واقعی دانست که می‌تواند از آن استفاده کند.

فرض کنید عامل خود را به سرور MCP ماشین حساب متصل می‌کنید. ناگهان عامل شما می‌تواند عملیات ریاضی را فقط با دریافت یک پرسش مثل «۴۷ ضربدر ۸۹ چند می‌شود؟» انجام دهد — بدون نیاز به کدنویسی منطق یا ساخت API سفارشی.

## مرور کلی

این درس نحوه اتصال سرور MCP ماشین حساب به یک عامل با استفاده از افزونه [AI Toolkit](https://aka.ms/AIToolkit) در Visual Studio Code را پوشش می‌دهد، تا عامل شما بتواند عملیات ریاضی مانند جمع، تفریق، ضرب و تقسیم را از طریق زبان طبیعی انجام دهد.

AI Toolkit افزونه قدرتمندی برای Visual Studio Code است که توسعه عوامل هوش مصنوعی را ساده می‌کند. مهندسین هوش مصنوعی می‌توانند به راحتی برنامه‌های هوش مصنوعی را با توسعه و آزمایش مدل‌های مولد هوش مصنوعی — به صورت محلی یا در فضای ابری — بسازند. این افزونه از اکثر مدل‌های مولد اصلی موجود پشتیبانی می‌کند.

*توجه*: AI Toolkit در حال حاضر از Python و TypeScript پشتیبانی می‌کند.

## اهداف یادگیری

تا پایان این درس، شما قادر خواهید بود:

- استفاده از سرور MCP از طریق AI Toolkit.
- پیکربندی عامل به گونه‌ای که بتواند ابزارهای ارائه شده توسط سرور MCP را کشف و استفاده کند.
- استفاده از ابزارهای MCP از طریق زبان طبیعی.

## رویکرد

در سطح کلی، باید به این صورت پیش برویم:

- ساخت یک عامل و تعریف prompt سیستمی آن.
- ساخت سرور MCP با ابزارهای ماشین حساب.
- اتصال Agent Builder به سرور MCP.
- آزمایش فراخوانی ابزار عامل از طریق زبان طبیعی.

عالی است، حالا که جریان کار را می‌دانیم، بیایید عامل هوش مصنوعی را طوری پیکربندی کنیم که از طریق MCP از ابزارهای خارجی بهره ببرد و قابلیت‌هایش را افزایش دهیم!

## پیش‌نیازها

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit برای Visual Studio Code](https://aka.ms/AIToolkit)

## تمرین: استفاده از یک سرور

در این تمرین، شما یک عامل هوش مصنوعی با ابزارهایی از سرور MCP در داخل Visual Studio Code با استفاده از AI Toolkit می‌سازید، اجرا می‌کنید و بهبود می‌دهید.

### -0- گام مقدماتی، افزودن مدل OpenAI GPT-4o به My Models

تمرین از مدل **GPT-4o** استفاده می‌کند. قبل از ساخت عامل، باید این مدل را به **My Models** اضافه کنید.

![تصویر رابط انتخاب مدل در افزونه AI Toolkit برای Visual Studio Code. عنوان: "مدل مناسب برای راهکار هوش مصنوعی خود را پیدا کنید" با زیرعنوانی که کاربران را به کشف، تست و استقرار مدل‌های هوش مصنوعی تشویق می‌کند. زیر آن، در بخش "Popular Models"، شش کارت مدل نمایش داده شده‌اند: DeepSeek-R1 (میزبانی شده توسط GitHub)، OpenAI GPT-4o، OpenAI GPT-4.1، OpenAI o1، Phi 4 Mini (CPU - کوچک، سریع)، و DeepSeek-R1 (میزبانی شده توسط Ollama). هر کارت گزینه‌هایی برای "افزودن" مدل یا "آزمایش در Playground" دارد.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.fa.png)

1. افزونه **AI Toolkit** را از **Activity Bar** باز کنید.
2. در بخش **Catalog**، گزینه **Models** را انتخاب کنید تا **Model Catalog** باز شود. انتخاب **Models** باعث باز شدن **Model Catalog** در یک تب جدید ویرایشگر می‌شود.
3. در نوار جستجوی **Model Catalog**، عبارت **OpenAI GPT-4o** را وارد کنید.
4. روی **+ Add** کلیک کنید تا مدل به لیست **My Models** اضافه شود. مطمئن شوید مدلی که انتخاب کرده‌اید، **Hosted by GitHub** است.
5. در **Activity Bar** تأیید کنید که مدل **OpenAI GPT-4o** در لیست ظاهر شده است.

### -1- ساخت یک عامل

**Agent (Prompt) Builder** به شما امکان می‌دهد عوامل هوش مصنوعی خود را بسازید و سفارشی کنید. در این بخش، یک عامل جدید می‌سازید و یک مدل برای هدایت مکالمه به آن اختصاص می‌دهید.

![تصویر رابط "Calculator Agent" در افزونه AI Toolkit برای Visual Studio Code. در پنل سمت چپ، مدل انتخاب شده "OpenAI GPT-4o (via GitHub)" است. یک prompt سیستمی نوشته شده: "شما یک استاد دانشگاه در رشته ریاضیات هستید" و prompt کاربر می‌گوید: "معادله فوریه را به زبان ساده برایم توضیح بده." گزینه‌های اضافی شامل دکمه‌هایی برای افزودن ابزار، فعال‌سازی MCP Server و انتخاب خروجی ساختاری است. دکمه آبی رنگ "Run" در پایین دیده می‌شود. در پنل سمت راست، زیر "Get Started with Examples"، سه عامل نمونه لیست شده‌اند: توسعه‌دهنده وب (با MCP Server)، ساده‌ساز کلاس دوم و مفسر رویا، هرکدام با توضیح کوتاه عملکردشان.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.fa.png)

1. افزونه **AI Toolkit** را از **Activity Bar** باز کنید.
2. در بخش **Tools**، گزینه **Agent (Prompt) Builder** را انتخاب کنید. انتخاب این گزینه باعث باز شدن **Agent (Prompt) Builder** در یک تب جدید ویرایشگر می‌شود.
3. روی دکمه **+ New Agent** کلیک کنید. افزونه یک جادوگر راه‌اندازی از طریق **Command Palette** اجرا می‌کند.
4. نام **Calculator Agent** را وارد کرده و کلید **Enter** را فشار دهید.
5. در **Agent (Prompt) Builder**، در فیلد **Model**، مدل **OpenAI GPT-4o (via GitHub)** را انتخاب کنید.

### -2- ساخت یک prompt سیستمی برای عامل

حالا که اسکلت عامل آماده است، وقت تعریف شخصیت و هدف آن است. در این بخش، از قابلیت **Generate system prompt** استفاده می‌کنید تا رفتار مورد نظر عامل — در اینجا یک عامل ماشین حساب — را توصیف کرده و مدل برای شما prompt سیستمی را بنویسد.

![تصویر رابط "Calculator Agent" در AI Toolkit برای Visual Studio Code با پنجره مودال باز شده با عنوان "Generate a prompt". این پنجره توضیح می‌دهد که یک قالب prompt با به اشتراک گذاشتن جزئیات پایه می‌تواند ساخته شود و شامل یک جعبه متن با نمونه prompt سیستمی است: "شما یک دستیار ریاضی مفید و کارآمد هستید. وقتی مسئله‌ای شامل حساب‌های پایه داده می‌شود، پاسخ صحیح را ارائه می‌دهید." در پایین جعبه متن دکمه‌های "Close" و "Generate" قرار دارند. در پس‌زمینه، بخشی از پیکربندی عامل دیده می‌شود، از جمله مدل انتخاب شده "OpenAI GPT-4o (via GitHub)" و فیلدهای prompt سیستمی و کاربر.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.fa.png)

1. در بخش **Prompts**، روی دکمه **Generate system prompt** کلیک کنید. این دکمه در سازنده prompt باز می‌شود که از هوش مصنوعی برای تولید prompt سیستمی عامل استفاده می‌کند.
2. در پنجره **Generate a prompt**، متن زیر را وارد کنید: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. روی دکمه **Generate** کلیک کنید. یک اعلان در گوشه پایین سمت راست ظاهر می‌شود که تولید prompt سیستمی را تأیید می‌کند. پس از اتمام تولید، prompt در فیلد **System prompt** در **Agent (Prompt) Builder** ظاهر خواهد شد.
4. prompt سیستمی را مرور کرده و در صورت نیاز اصلاح کنید.

### -3- ساخت یک سرور MCP

حالا که prompt سیستمی عامل را تعریف کرده‌اید — که رفتار و پاسخ‌های آن را هدایت می‌کند — وقت آن است که به عامل قابلیت‌های عملی بدهید. در این بخش، یک سرور MCP ماشین حساب با ابزارهایی برای انجام جمع، تفریق، ضرب و تقسیم می‌سازید. این سرور به عامل شما امکان می‌دهد عملیات ریاضی را در زمان واقعی در پاسخ به پرسش‌های زبان طبیعی انجام دهد.

![تصویر بخش پایینی رابط Calculator Agent در افزونه AI Toolkit برای Visual Studio Code. منوهای قابل گسترش "Tools" و "Structure output" دیده می‌شوند، همراه با یک منوی کشویی با عنوان "Choose output format" که روی "text" تنظیم شده است. در سمت راست، دکمه‌ای با عنوان "+ MCP Server" برای افزودن سرور Model Context Protocol قرار دارد. بالای بخش Tools یک جایگاه تصویر آیکون دیده می‌شود.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.fa.png)

AI Toolkit با قالب‌هایی مجهز شده تا ساخت سرور MCP خودتان را آسان کند. ما از قالب Python برای ساخت سرور MCP ماشین حساب استفاده خواهیم کرد.

*توجه*: AI Toolkit در حال حاضر از Python و TypeScript پشتیبانی می‌کند.

1. در بخش **Tools** در **Agent (Prompt) Builder**، روی دکمه **+ MCP Server** کلیک کنید. افزونه جادوگر راه‌اندازی را از طریق **Command Palette** اجرا می‌کند.
2. گزینه **+ Add Server** را انتخاب کنید.
3. گزینه **Create a New MCP Server** را انتخاب کنید.
4. قالب **python-weather** را انتخاب کنید.
5. پوشه پیش‌فرض را برای ذخیره قالب سرور MCP انتخاب کنید.
6. نام زیر را برای سرور وارد کنید: **Calculator**
7. یک پنجره جدید Visual Studio Code باز خواهد شد. گزینه **Yes, I trust the authors** را انتخاب کنید.
8. با استفاده از ترمینال (**Terminal** > **New Terminal**)، یک محیط مجازی بسازید: `python -m venv .venv`
9. با استفاده از ترمینال، محیط مجازی را فعال کنید:
    1. ویندوز - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. با استفاده از ترمینال، وابستگی‌ها را نصب کنید: `pip install -e .[dev]`
11. در نمای **Explorer** در **Activity Bar**، پوشه **src** را باز کرده و فایل **server.py** را برای ویرایش انتخاب کنید.
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

### -4- اجرای عامل با سرور MCP ماشین حساب

حالا که عامل شما ابزار دارد، وقت استفاده از آنها است! در این بخش، شما prompt‌هایی به عامل ارسال می‌کنید تا آزمایش کنید آیا عامل از ابزار مناسب سرور MCP ماشین حساب استفاده می‌کند یا خیر.

![تصویر رابط Calculator Agent در افزونه AI Toolkit برای Visual Studio Code. در پنل سمت چپ، زیر "Tools"، سرور MCP به نام local-server-calculator_server اضافه شده و چهار ابزار موجود نمایش داده شده‌اند: add، subtract، multiply و divide. یک نشانگر تعداد چهار ابزار فعال را نشان می‌دهد. بخش "Structure output" جمع شده و دکمه آبی رنگ "Run" دیده می‌شود. در پنل سمت راست، زیر "Model Response"، عامل ابزارهای multiply و subtract را با ورودی‌های {"a": 3, "b": 25} و {"a": 75, "b": 20} فراخوانی می‌کند. پاسخ نهایی ابزار ۷۵.۰ نمایش داده شده است. در پایین دکمه "View Code" قرار دارد.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.fa.png)

شما سرور MCP ماشین حساب را به عنوان کلاینت MCP روی دستگاه توسعه محلی خود از طریق **Agent Builder** اجرا خواهید کرد.

1. کلید `F5` را فشار دهید تا عامل اجرا شود.
2. در فیلد **User prompt** عبارتی مانند زیر وارد کنید:  
   `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`  
   مقادیر ``
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` برای ابزار **subtract** اختصاص داده شده‌اند.
    - پاسخ هر ابزار در بخش **Tool Response** مربوطه ارائه می‌شود.
    - خروجی نهایی مدل در بخش **Model Response** نمایش داده می‌شود.
3. promptهای بیشتری ارسال کنید تا عامل را بیشتر آزمایش کنید. می‌توانید prompt موجود در فیلد **User prompt** را با کلیک و جایگزینی تغییر دهید.
4. پس از پایان آزمایش، می‌توانید سرور را از طریق **ترمینال** با فشردن **CTRL/CMD+C** متوقف کنید.

## تمرین

سعی کنید یک ابزار جدید به فایل **server.py** خود اضافه کنید (مثلاً: محاسبه ریشه دوم یک عدد). سپس promptهای جدیدی ارسال کنید که نیاز باشد عامل از ابزار جدید (یا ابزارهای موجود) استفاده کند. حتماً برای بارگذاری ابزارهای جدید سرور را مجدداً راه‌اندازی کنید.

## راه حل

[Solution](./solution/README.md)

## نکات کلیدی

نکات مهم این فصل به شرح زیر است:

- افزونه AI Toolkit یک کلاینت عالی است که به شما امکان استفاده از سرورهای MCP و ابزارهای آنها را می‌دهد.
- می‌توانید ابزارهای جدید به سرورهای MCP اضافه کنید و قابلیت‌های عامل را برای پاسخگویی به نیازهای متغیر گسترش دهید.
- AI Toolkit شامل قالب‌هایی (مثلاً قالب‌های سرور MCP برای Python) است که ساخت ابزارهای سفارشی را ساده می‌کند.

## منابع بیشتر

- [مستندات AI Toolkit](https://aka.ms/AIToolkit/doc)

## مرحله بعدی
- بعدی: [آزمایش و اشکال‌زدایی](/03-GettingStarted/08-testing/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نادرستی‌هایی باشند. سند اصلی به زبان مادری آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.