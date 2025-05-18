<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:15:20+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "fa"
}
-->
# استفاده از یک سرور از افزونه AI Toolkit برای Visual Studio Code

وقتی در حال ساخت یک عامل هوش مصنوعی هستید، فقط تولید پاسخ‌های هوشمند نیست؛ بلکه به عامل خود توانایی اقدام دادن نیز هست. اینجا است که پروتکل Model Context (MCP) وارد عمل می‌شود. MCP دسترسی آسان به ابزارها و خدمات خارجی را برای عوامل فراهم می‌کند. تصور کنید که عامل خود را به یک جعبه ابزار وصل کرده‌اید که واقعاً می‌تواند از آن استفاده کند.

فرض کنید یک عامل را به سرور MCP ماشین حساب خود وصل کرده‌اید. ناگهان، عامل شما می‌تواند عملیات ریاضی انجام دهد فقط با دریافت یک پیام مانند "۴۷ ضرب در ۸۹ چقدر است؟" — بدون نیاز به کدنویسی سخت یا ساخت API‌های سفارشی.

## مروری کلی

این درس نحوه اتصال یک سرور MCP ماشین حساب به یک عامل با افزونه [AI Toolkit](https://aka.ms/AIToolkit) در Visual Studio Code را پوشش می‌دهد، که به عامل شما اجازه می‌دهد عملیات ریاضی مانند جمع، تفریق، ضرب و تقسیم را از طریق زبان طبیعی انجام دهد.

AI Toolkit یک افزونه قدرتمند برای Visual Studio Code است که توسعه عامل را ساده می‌کند. مهندسان هوش مصنوعی می‌توانند به راحتی برنامه‌های هوش مصنوعی را با توسعه و آزمایش مدل‌های هوش مصنوعی تولیدی — محلی یا در فضای ابری — بسازند. این افزونه از اکثر مدل‌های تولیدی موجود امروز پشتیبانی می‌کند.

*توجه*: AI Toolkit در حال حاضر از Python و TypeScript پشتیبانی می‌کند.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- مصرف یک سرور MCP از طریق AI Toolkit.
- پیکربندی یک عامل را انجام دهید تا بتواند ابزارهایی که توسط سرور MCP ارائه می‌شود را کشف و استفاده کند.
- استفاده از ابزارهای MCP از طریق زبان طبیعی.

## رویکرد

این‌گونه باید به این موضوع در سطح بالا نزدیک شویم:

- ایجاد یک عامل و تعریف پیام سیستم آن.
- ایجاد یک سرور MCP با ابزارهای ماشین حساب.
- اتصال Agent Builder به سرور MCP.
- آزمایش فراخوانی ابزار عامل از طریق زبان طبیعی.

عالی، حالا که جریان را فهمیدیم، بیایید یک عامل هوش مصنوعی را پیکربندی کنیم تا از ابزارهای خارجی از طریق MCP استفاده کند و قابلیت‌های خود را ارتقا دهد!

## پیش‌نیازها

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit برای Visual Studio Code](https://aka.ms/AIToolkit)

## تمرین: مصرف یک سرور

در این تمرین، شما یک عامل هوش مصنوعی را با ابزارهایی از یک سرور MCP داخل Visual Studio Code با استفاده از AI Toolkit می‌سازید، اجرا می‌کنید و ارتقا می‌دهید.

### -0- مرحله مقدماتی، مدل OpenAI GPT-4o را به مدل‌های من اضافه کنید

این تمرین از مدل **GPT-4o** استفاده می‌کند. مدل باید قبل از ایجاد عامل به **مدل‌های من** اضافه شود.

![اسکرین‌شات از رابط انتخاب مدل در افزونه AI Toolkit Visual Studio Code. عنوان "مدل مناسب برای راه‌حل هوش مصنوعی خود را پیدا کنید" با زیرعنوانی که کاربران را به کشف، آزمایش و پیاده‌سازی مدل‌های هوش مصنوعی تشویق می‌کند. زیر "مدل‌های محبوب"، شش کارت مدل نمایش داده می‌شود: DeepSeek-R1 (میزبان GitHub)، OpenAI GPT-4o، OpenAI GPT-4.1، OpenAI o1، Phi 4 Mini (CPU - کوچک، سریع)، و DeepSeek-R1 (میزبان Ollama). هر کارت شامل گزینه‌هایی برای "اضافه کردن" مدل یا "آزمایش در Playground](../../../../translated_images/aitk-model-catalog.143ab567942a0c88d21eb49c9f384182a688aa2ca7f44bc263a1c8ee45ee6252.fa.png)

1. افزونه **AI Toolkit** را از **Activity Bar** باز کنید.
1. در بخش **Catalog**، **Models** را انتخاب کنید تا **Model Catalog** باز شود. انتخاب **Models**، **Model Catalog** را در یک تب جدید ویرایشگر باز می‌کند.
1. در نوار جستجوی **Model Catalog**، **OpenAI GPT-4o** را وارد کنید.
1. بر روی **+ Add** کلیک کنید تا مدل به لیست **مدل‌های من** اضافه شود. مطمئن شوید که مدل **Hosted by GitHub** را انتخاب کرده‌اید.
1. در **Activity Bar**، تأیید کنید که مدل **OpenAI GPT-4o** در لیست ظاهر می‌شود.

### -1- ایجاد یک عامل

**Agent (Prompt) Builder** به شما امکان می‌دهد عوامل هوش مصنوعی خود را ایجاد و سفارشی کنید. در این بخش، شما یک عامل جدید ایجاد می‌کنید و یک مدل را برای قدرت بخشیدن به مکالمه اختصاص می‌دهید.

![اسکرین‌شات از رابط "Calculator Agent" در افزونه AI Toolkit برای Visual Studio Code. در پانل سمت چپ، مدل انتخاب شده "OpenAI GPT-4o (از طریق GitHub)" است. یک پیام سیستم می‌گوید "شما یک استاد دانشگاه هستید که ریاضی تدریس می‌کند" و پیام کاربر می‌گوید، "معادله فوریه را به زبان ساده توضیح دهید." گزینه‌های اضافی شامل دکمه‌هایی برای اضافه کردن ابزارها، فعال کردن سرور MCP و انتخاب خروجی ساختار یافته است. یک دکمه آبی "Run" در پایین قرار دارد. در پانل سمت راست، تحت "شروع با مثال‌ها"، سه عامل نمونه لیست شده‌اند: توسعه‌دهنده وب (با سرور MCP، ساده‌کننده کلاس دوم، و تعبیرگر رویا، هر کدام با توضیحات کوتاه از عملکردهایشان.](../../../../translated_images/aitk-agent-builder.df46f391ec9a2b0e8cd1ddbb1dbc968c42bb20411350a44d87c8f082ba4a45d5.fa.png)

1. افزونه **AI Toolkit** را از **Activity Bar** باز کنید.
1. در بخش **Tools**، **Agent (Prompt) Builder** را انتخاب کنید. انتخاب **Agent (Prompt) Builder**، **Agent (Prompt) Builder** را در یک تب جدید ویرایشگر باز می‌کند.
1. بر روی دکمه **+ New Builder** کلیک کنید. افزونه یک جادوگر تنظیمات را از طریق **Command Palette** راه‌اندازی می‌کند.
1. نام **Calculator Agent** را وارد کرده و **Enter** را فشار دهید.
1. در **Agent (Prompt) Builder**، برای فیلد **Model**، مدل **OpenAI GPT-4o (از طریق GitHub)** را انتخاب کنید.

### -2- ایجاد یک پیام سیستم برای عامل

با اسکلت‌بندی عامل، زمان تعریف شخصیت و هدف آن است. در این بخش، شما از ویژگی **Generate system prompt** استفاده می‌کنید تا رفتار مورد نظر عامل را توصیف کنید — در این مورد، یک عامل ماشین حساب — و مدل را به نوشتن پیام سیستم برای شما واگذار کنید.

![اسکرین‌شات از رابط "Calculator Agent" در AI Toolkit برای Visual Studio Code با یک پنجره مودال باز با عنوان "تولید یک پیام." مودال توضیح می‌دهد که یک قالب پیام می‌تواند با اشتراک جزئیات پایه تولید شود و شامل یک جعبه متن با نمونه پیام سیستم: "شما یک دستیار ریاضی مفید و کارآمد هستید. وقتی یک مسئله شامل حساب پایه داده می‌شود، با نتیجه صحیح پاسخ می‌دهید." زیر جعبه متن دکمه‌های "بستن" و "تولید" قرار دارد. در پس‌زمینه، بخشی از پیکربندی عامل قابل مشاهده است، شامل مدل انتخاب شده "OpenAI GPT-4o (از طریق GitHub)" و فیلدهای برای پیام‌های سیستم و کاربر.](../../../../translated_images/aitk-generate-prompt.fc5fdce97b37f4c22511cc2ed3cc1d85e79ccf21c339e64a9553b9e2cc4dac37.fa.png)

1. برای بخش **Prompts**، بر روی دکمه **Generate system prompt** کلیک کنید. این دکمه در سازنده پیام باز می‌شود که از هوش مصنوعی برای تولید یک پیام سیستم برای عامل استفاده می‌کند.
1. در پنجره **Generate a prompt**، موارد زیر را وارد کنید: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. بر روی دکمه **Generate** کلیک کنید. یک اعلان در گوشه پایین سمت راست ظاهر می‌شود که تأیید می‌کند پیام سیستم در حال تولید است. پس از تکمیل تولید پیام، پیام در فیلد **System prompt** در **Agent (Prompt) Builder** ظاهر می‌شود.
1. پیام **System prompt** را مرور کنید و در صورت لزوم اصلاح کنید.

### -3- ایجاد یک سرور MCP

حالا که پیام سیستم عامل خود را تعریف کرده‌اید — رفتار و پاسخ‌های آن را هدایت می‌کند — زمان تجهیز عامل با قابلیت‌های عملی است. در این بخش، شما یک سرور MCP ماشین حساب با ابزارهایی برای انجام محاسبات جمع، تفریق، ضرب و تقسیم ایجاد می‌کنید. این سرور به عامل شما اجازه می‌دهد عملیات ریاضی واقعی را در پاسخ به پیام‌های زبان طبیعی انجام دهد.

![اسکرین‌شات از بخش پایین رابط Calculator Agent در افزونه AI Toolkit برای Visual Studio Code. منوهای قابل گسترش برای "Tools" و "Structure output" نشان داده می‌شود، همراه با یک منوی کشویی با برچسب "Choose output format" تنظیم شده به "text." در سمت راست، یک دکمه با برچسب "+ MCP Server" برای اضافه کردن یک سرور پروتکل Context مدل وجود دارد. یک جای‌نما آیکون تصویر بالای بخش Tools نشان داده می‌شود.](../../../../translated_images/aitk-add-mcp-server.7696efa0c3d1774d2ba903c86c8782fbc80fcb8ac9e51d7c6089cccc47396386.fa.png)

AI Toolkit با قالب‌هایی مجهز شده است که ایجاد سرور MCP خود را آسان می‌کند. ما از قالب Python برای ایجاد سرور MCP ماشین حساب استفاده خواهیم کرد.

*توجه*: AI Toolkit در حال حاضر از Python و TypeScript پشتیبانی می‌کند.

1. در بخش **Tools** از **Agent (Prompt) Builder**، بر روی دکمه **+ MCP Server** کلیک کنید. افزونه یک جادوگر تنظیمات را از طریق **Command Palette** راه‌اندازی می‌کند.
1. **+ Add Server** را انتخاب کنید.
1. **Create a New MCP Server** را انتخاب کنید.
1. **python-weather** را به عنوان قالب انتخاب کنید.
1. **Default folder** را برای ذخیره قالب سرور MCP انتخاب کنید.
1. نام زیر را برای سرور وارد کنید: **Calculator**
1. یک پنجره جدید Visual Studio Code باز خواهد شد. **Yes, I trust the authors** را انتخاب کنید.
1. با استفاده از ترمینال (**Terminal** > **New Terminal**)، یک محیط مجازی ایجاد کنید: `python -m venv .venv`
1. با استفاده از ترمینال، محیط مجازی را فعال کنید:
    1. ویندوز - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. با استفاده از ترمینال، وابستگی‌ها را نصب کنید: `pip install -e .[dev]`
1. در نمای **Explorer** از **Activity Bar**، دایرکتوری **src** را گسترش دهید و **server.py** را انتخاب کنید تا فایل در ویرایشگر باز شود.
1. کد در فایل **server.py** را با موارد زیر جایگزین کنید و ذخیره کنید:

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

حالا که عامل شما ابزارها دارد، زمان استفاده از آنهاست! در این بخش، شما پیام‌هایی را به عامل ارسال می‌کنید تا آزمایش و اعتبارسنجی کنید که آیا عامل ابزار مناسب را از سرور MCP ماشین حساب استفاده می‌کند.

![اسکرین‌شات از رابط Calculator Agent در افزونه AI Toolkit برای Visual Studio Code. در پانل سمت چپ، تحت "Tools"، یک سرور MCP به نام local-server-calculator_server اضافه شده است که چهار ابزار موجود را نشان می‌دهد: اضافه کردن، تفریق، ضرب و تقسیم. یک نشان نشان می‌دهد که چهار ابزار فعال هستند. زیر یک بخش "Structure output" جمع شده و یک دکمه آبی "Run" قرار دارد. در پانل سمت راست، تحت "Model Response"، عامل ابزارهای ضرب و تفریق را با ورودی‌های {"a": 3, "b": 25} و {"a": 75, "b": 20} به ترتیب فراخوانی می‌کند. پاسخ نهایی "Tool Response" به عنوان 75.0 نشان داده شده است. یک دکمه "View Code" در پایین ظاهر می‌شود.](../../../../translated_images/aitk-agent-response-with-tools.64afc99ab720b2cd97d0142ba8f98aca0ddc9eba46f148adc2c35d6979ddb349.fa.png)

شما سرور MCP ماشین حساب را بر روی ماشین توسعه محلی خود از طریق **Agent Builder** به عنوان مشتری MCP اجرا خواهید کرد.

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` مقادیر برای ابزار **subtract** اختصاص داده شده‌اند.
    - پاسخ از هر ابزار در **Tool Response** مربوطه ارائه می‌شود.
    - خروجی نهایی از مدل در **Model Response** نهایی ارائه می‌شود.
1. پیام‌های اضافی ارسال کنید تا عامل را بیشتر آزمایش کنید. می‌توانید پیام موجود را در فیلد **User prompt** با کلیک کردن در فیلد و جایگزینی پیام موجود اصلاح کنید.
1. وقتی آزمایش عامل را به پایان رساندید، می‌توانید سرور را از طریق **ترمینال** با وارد کردن **CTRL/CMD+C** برای خروج متوقف کنید.

## تکلیف

سعی کنید یک ورودی ابزار اضافی به فایل **server.py** خود اضافه کنید (مثلاً بازگشت ریشه مربع یک عدد). پیام‌های اضافی ارسال کنید که نیاز به استفاده عامل از ابزار جدید شما (یا ابزارهای موجود) داشته باشد. مطمئن شوید که سرور را مجدداً راه‌اندازی کنید تا ابزارهای تازه اضافه شده بارگذاری شوند.

## راه‌حل

[راه‌حل](./solution/README.md)

## نکات کلیدی

نکات کلیدی این فصل عبارتند از:

- افزونه AI Toolkit یک مشتری عالی است که به شما اجازه می‌دهد سرورهای MCP و ابزارهای آنها را مصرف کنید.
- شما می‌توانید ابزارهای جدید به سرورهای MCP اضافه کنید، قابلیت‌های عامل را برای برآوردن نیازهای در حال تکامل گسترش دهید.
- AI Toolkit شامل قالب‌ها (مثلاً قالب‌های سرور MCP Python) برای ساده‌سازی ایجاد ابزارهای سفارشی است.

## منابع اضافی

- [مستندات AI Toolkit](https://aka.ms/AIToolkit/doc)

## مرحله بعدی

بعدی: [درس ۴ اجرای عملی](/04-PracticalImplementation/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان اصلی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، ترجمه انسانی حرفه‌ای توصیه می‌شود. ما مسئولیتی در قبال هرگونه سوء تفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه نداریم.