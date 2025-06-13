<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:15:05+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ur"
}
-->
# استعمال کرنا ایک سرور AI Toolkit ایکسٹینشن سے Visual Studio Code کے لیے

جب آپ ایک AI ایجنٹ بنا رہے ہوتے ہیں، تو بات صرف ذہین جوابات پیدا کرنے کی نہیں ہوتی؛ بلکہ آپ کے ایجنٹ کو کارروائی کرنے کی صلاحیت دینا بھی ضروری ہے۔ یہی جگہ ہے جہاں Model Context Protocol (MCP) آتا ہے۔ MCP ایجنٹس کے لیے آسان بناتا ہے کہ وہ بیرونی ٹولز اور سروسز تک ایک مستقل طریقے سے رسائی حاصل کریں۔ اسے ایسے سمجھیں جیسے آپ اپنے ایجنٹ کو ایک ایسے ٹول باکس میں پلگ ان کر رہے ہوں جسے وہ واقعی استعمال کر سکتا ہے۔

فرض کریں آپ ایک ایجنٹ کو اپنے calculator MCP سرور سے جوڑتے ہیں۔ اچانک، آپ کا ایجنٹ ریاضی کے آپریشنز کر سکتا ہے صرف ایک پرامپٹ وصول کرکے جیسے "47 کو 89 سے ضرب دیں؟"—بغیر کسی ہارڈ کوڈڈ منطق یا کسٹم APIs بنانے کی ضرورت کے۔

## جائزہ

یہ سبق بتاتا ہے کہ کیسے ایک calculator MCP سرور کو AI Toolkit ایکسٹینشن کے ذریعے Visual Studio Code میں ایک ایجنٹ سے جوڑا جائے، تاکہ آپ کا ایجنٹ جمع، تفریق، ضرب، اور تقسیم جیسے ریاضی کے آپریشنز قدرتی زبان کے ذریعے انجام دے سکے۔

AI Toolkit Visual Studio Code کے لیے ایک طاقتور ایکسٹینشن ہے جو ایجنٹ کی ترقی کو آسان بناتا ہے۔ AI انجینئرز آسانی سے AI ایپلیکیشنز بنا اور ٹیسٹ کر سکتے ہیں، چاہے لوکل ہوں یا کلاؤڈ میں۔ یہ ایکسٹینشن آج دستیاب زیادہ تر اہم جنریٹو ماڈلز کو سپورٹ کرتا ہے۔

*نوٹ*: AI Toolkit اس وقت Python اور TypeScript کو سپورٹ کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے:

- AI Toolkit کے ذریعے MCP سرور کو استعمال کرنا۔
- ایک ایجنٹ کی کنفیگریشن ترتیب دینا تاکہ وہ MCP سرور کے ٹولز کو دریافت اور استعمال کر سکے۔
- MCP ٹولز کو قدرتی زبان کے ذریعے استعمال کرنا۔

## طریقہ کار

یہاں ایک اعلی سطح پر طریقہ کار دیا گیا ہے:

- ایک ایجنٹ بنائیں اور اس کا سسٹم پرامپٹ متعین کریں۔
- ایک calculator ٹولز کے ساتھ MCP سرور بنائیں۔
- Agent Builder کو MCP سرور سے جوڑیں۔
- ایجنٹ کے ٹول استعمال کو قدرتی زبان کے ذریعے ٹیسٹ کریں۔

بہت خوب، اب جب ہم فلو سمجھ گئے ہیں، آئیے ایک AI ایجنٹ کو MCP کے ذریعے بیرونی ٹولز استعمال کرنے کے لیے ترتیب دیں، تاکہ اس کی صلاحیتوں میں اضافہ ہو!

## ضروریات

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## مشق: ایک سرور کا استعمال

اس مشق میں، آپ AI Toolkit کا استعمال کرتے ہوئے Visual Studio Code کے اندر MCP سرور کے ٹولز کے ساتھ ایک AI ایجنٹ بنائیں گے، چلائیں گے، اور بہتر بنائیں گے۔

### -0- ابتدائی قدم، My Models میں OpenAI GPT-4o ماڈل شامل کریں

مشق **GPT-4o** ماڈل استعمال کرتی ہے۔ ایجنٹ بنانے سے پہلے اس ماڈل کو **My Models** میں شامل کرنا ضروری ہے۔

![Visual Studio Code کے AI Toolkit ایکسٹینشن میں ماڈل منتخب کرنے کا اسکرین شاٹ۔ ہیڈنگ ہے "Find the right model for your AI Solution" اور سب ٹائٹل میں AI ماڈلز دریافت، ٹیسٹ، اور تعینات کرنے کی ترغیب دی گئی ہے۔ نیچے "Popular Models" کے تحت چھ ماڈل کارڈز دکھائے گئے ہیں: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), اور DeepSeek-R1 (Ollama-hosted)۔ ہر کارڈ میں "Add" اور "Try in Playground" کے آپشنز موجود ہیں۔](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ur.png)

1. **Activity Bar** سے **AI Toolkit** ایکسٹینشن کھولیں۔
1. **Catalog** سیکشن میں، **Models** منتخب کریں تاکہ **Model Catalog** کھلے۔ **Models** منتخب کرنے سے **Model Catalog** ایک نئے ایڈیٹر ٹیب میں کھلتا ہے۔
1. **Model Catalog** کی سرچ بار میں **OpenAI GPT-4o** لکھیں۔
1. **+ Add** پر کلک کریں تاکہ ماڈل آپ کی **My Models** فہرست میں شامل ہو جائے۔ یقینی بنائیں کہ آپ نے وہ ماڈل منتخب کیا ہے جو **Hosted by GitHub** ہے۔
1. **Activity Bar** میں تصدیق کریں کہ **OpenAI GPT-4o** ماڈل فہرست میں نظر آ رہا ہے۔

### -1- ایک ایجنٹ بنائیں

**Agent (Prompt) Builder** آپ کو اپنے AI سے چلنے والے ایجنٹس بنانے اور حسب ضرورت بنانے کی سہولت دیتا ہے۔ اس سیکشن میں، آپ ایک نیا ایجنٹ بنائیں گے اور گفتگو کے لیے ماڈل منتخب کریں گے۔

![AI Toolkit ایکسٹینشن میں "Calculator Agent" بلڈر انٹرفیس کا اسکرین شاٹ۔ بائیں پینل میں منتخب ماڈل "OpenAI GPT-4o (via GitHub)" ہے۔ سسٹم پرامپٹ میں لکھا ہے "You are a professor in university teaching math," اور یوزر پرامپٹ کہتا ہے، "Explain to me the Fourier equation in simple terms." اضافی آپشنز میں ٹولز شامل کرنے، MCP Server فعال کرنے، اور structured output منتخب کرنے کے بٹن شامل ہیں۔ نیچے نیلا "Run" بٹن ہے۔ دائیں پینل میں "Get Started with Examples" کے تحت تین نمونہ ایجنٹس کی فہرست ہے: Web Developer (MCP Server، Second-Grade Simplifier، اور Dream Interpreter کے ساتھ، ہر ایک کا مختصر تعارف موجود ہے۔](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ur.png)

1. **Activity Bar** سے **AI Toolkit** ایکسٹینشن کھولیں۔
1. **Tools** سیکشن میں، **Agent (Prompt) Builder** منتخب کریں۔ منتخب کرنے سے یہ ایک نئے ایڈیٹر ٹیب میں کھل جائے گا۔
1. **+ New Agent** بٹن پر کلک کریں۔ ایکسٹینشن **Command Palette** کے ذریعے سیٹ اپ وزرڈ شروع کرے گا۔
1. نام **Calculator Agent** درج کریں اور **Enter** دبائیں۔
1. **Agent (Prompt) Builder** میں، **Model** فیلڈ کے لیے، **OpenAI GPT-4o (via GitHub)** ماڈل منتخب کریں۔

### -2- ایجنٹ کے لیے سسٹم پرامپٹ بنائیں

اب جب ایجنٹ کی بنیاد رکھی جا چکی ہے، وقت ہے اس کی شخصیت اور مقصد متعین کرنے کا۔ اس سیکشن میں، آپ **Generate system prompt** فیچر استعمال کریں گے تاکہ ایجنٹ کے متوقع رویے کی وضاحت کریں—اس کیس میں ایک calculator ایجنٹ—اور ماڈل سے سسٹم پرامپٹ لکھوائیں گے۔

![AI Toolkit میں "Calculator Agent" انٹرفیس کا اسکرین شاٹ جس میں "Generate a prompt" عنوان والا موڈل ونڈو کھلا ہے۔ موڈل وضاحت کرتا ہے کہ پرامپٹ ٹیمپلیٹ بنیادی تفصیلات شیئر کر کے بنایا جا سکتا ہے اور ایک ٹیکسٹ باکس میں نمونہ سسٹم پرامپٹ ہے: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." نیچے "Close" اور "Generate" بٹن ہیں۔ پس منظر میں ایجنٹ کی کنفیگریشن نظر آ رہی ہے، جس میں منتخب ماڈل "OpenAI GPT-4o (via GitHub)" اور سسٹم و یوزر پرامپٹس شامل ہیں۔](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ur.png)

1. **Prompts** سیکشن میں، **Generate system prompt** بٹن پر کلک کریں۔ یہ بٹن پرامپٹ بلڈر کھولتا ہے جو AI کا استعمال کر کے ایجنٹ کے لیے سسٹم پرامپٹ بناتا ہے۔
1. **Generate a prompt** ونڈو میں، درج کریں: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** بٹن پر کلک کریں۔ دائیں نیچے نوٹیفیکیشن آئے گا کہ سسٹم پرامپٹ بنایا جا رہا ہے۔ مکمل ہونے پر پرامپٹ **Agent (Prompt) Builder** کے **System prompt** فیلڈ میں ظاہر ہو جائے گا۔
1. **System prompt** کا جائزہ لیں اور ضرورت ہو تو ترمیم کریں۔

### -3- ایک MCP سرور بنائیں

اب جب آپ نے ایجنٹ کا سسٹم پرامپٹ متعین کر دیا ہے جو اس کے رویے اور جوابات کی رہنمائی کرتا ہے، وقت ہے کہ ایجنٹ کو عملی صلاحیتوں سے لیس کریں۔ اس سیکشن میں، آپ calculator MCP سرور بنائیں گے جس میں جمع، تفریق، ضرب، اور تقسیم کے ٹولز ہوں گے۔ یہ سرور آپ کے ایجنٹ کو قدرتی زبان کے پرامپٹس کے جواب میں ریئل ٹائم ریاضی کے آپریشنز کرنے کے قابل بنائے گا۔

!["Calculator Agent" انٹرفیس کے نیچے والے حصے کا اسکرین شاٹ AI Toolkit ایکسٹینشن میں۔ یہاں "Tools" اور "Structure output" کے لیے قابل توسیع مینو ہیں، اور ایک ڈراپ ڈاؤن ہے جس میں "Choose output format" منتخب ہے "text"۔ دائیں جانب "+ MCP Server" بٹن ہے جو Model Context Protocol سرور شامل کرنے کے لیے ہے۔ Tools سیکشن کے اوپر ایک امیج آئیکن پلیس ہولڈر بھی دکھائی دے رہا ہے۔](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ur.png)

AI Toolkit میں آپ کے اپنے MCP سرور بنانے کے لیے ٹیمپلیٹس موجود ہیں۔ ہم calculator MCP سرور بنانے کے لیے Python ٹیمپلیٹ استعمال کریں گے۔

*نوٹ*: AI Toolkit اس وقت Python اور TypeScript کو سپورٹ کرتا ہے۔

1. **Agent (Prompt) Builder** کے **Tools** سیکشن میں، **+ MCP Server** بٹن پر کلک کریں۔ ایکسٹینشن **Command Palette** کے ذریعے سیٹ اپ وزرڈ شروع کرے گا۔
1. **+ Add Server** منتخب کریں۔
1. **Create a New MCP Server** منتخب کریں۔
1. **python-weather** ٹیمپلیٹ منتخب کریں۔
1. MCP سرور ٹیمپلیٹ محفوظ کرنے کے لیے **Default folder** منتخب کریں۔
1. سرور کے لیے نام درج کریں: **Calculator**
1. Visual Studio Code کی ایک نئی ونڈو کھلے گی۔ **Yes, I trust the authors** منتخب کریں۔
1. ٹرمینل استعمال کرتے ہوئے (Terminal > New Terminal)، ایک ورچوئل انوائرنمنٹ بنائیں: `python -m venv .venv`
1. ٹرمینل میں ورچوئل انوائرنمنٹ کو فعال کریں:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ٹرمینل میں dependencies انسٹال کریں: `pip install -e .[dev]`
1. **Activity Bar** کے **Explorer** ویو میں، **src** ڈائریکٹری کو وسعت دیں اور **server.py** فائل کھولیں۔
1. **server.py** کی موجودہ کوڈ کو درج ذیل سے بدلیں اور محفوظ کریں:

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

### -4- calculator MCP سرور کے ساتھ ایجنٹ چلائیں

اب جب آپ کے ایجنٹ کے پاس ٹولز موجود ہیں، وقت ہے ان کا استعمال کرنے کا! اس سیکشن میں، آپ ایجنٹ کو پرامپٹس بھیجیں گے تاکہ جانچ سکیں کہ آیا ایجنٹ calculator MCP سرور کے مناسب ٹول کو استعمال کر رہا ہے یا نہیں۔

![Calculator Agent انٹرفیس کا اسکرین شاٹ AI Toolkit ایکسٹینشن میں۔ بائیں پینل میں، "Tools" کے تحت، ایک MCP سرور local-server-calculator_server شامل ہے جس میں چار دستیاب ٹولز دکھائے گئے ہیں: add، subtract، multiply، اور divide۔ ایک بیج دکھا رہا ہے کہ چار ٹولز فعال ہیں۔ نیچے "Structure output" سیکشن بند ہے اور نیلا "Run" بٹن موجود ہے۔ دائیں پینل میں، "Model Response" کے تحت، ایجنٹ نے multiply اور subtract ٹولز کو ان پٹ کے ساتھ بلایا {"a": 3, "b": 25} اور {"a": 75, "b": 20}۔ آخری "Tool Response" 75.0 ہے۔ نیچے "View Code" بٹن بھی ہے۔](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ur.png)

آپ calculator MCP سرور کو اپنے لوکل ڈویلپمنٹ مشین پر **Agent Builder** کے ذریعے MCP کلائنٹ کے طور پر چلائیں گے۔

1. `F5` دبائیں` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `میں نے 3 آئٹمز خریدے جن کی قیمت ہر ایک $25 تھی، اور پھر $20 کی چھوٹ استعمال کی۔ میں نے کتنا ادا کیا؟`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` اقدار **subtract** ٹول کے لیے تفویض کی گئی ہیں۔
    - ہر ٹول کا جواب متعلقہ **Tool Response** میں دیا جاتا ہے۔
    - ماڈل کا حتمی نتیجہ **Model Response** میں دیا جاتا ہے۔
1. مزید پرامپٹس بھیج کر ایجنٹ کو مزید ٹیسٹ کریں۔ آپ موجودہ پرامپٹ کو **User prompt** فیلڈ میں کلک کر کے اور موجودہ متن کو تبدیل کر کے ایڈجسٹ کر سکتے ہیں۔
1. جب آپ ٹیسٹنگ مکمل کر لیں، تو **terminal** میں **CTRL/CMD+C** دبا کر سرور کو بند کر سکتے ہیں۔

## اسائنمنٹ

اپنی **server.py** فائل میں ایک اضافی ٹول انٹری شامل کرنے کی کوشش کریں (مثلاً: کسی عدد کا مربع جذر واپس کریں)۔ اضافی پرامپٹس بھیجیں جو ایجنٹ کو آپ کے نئے ٹول (یا موجودہ ٹولز) استعمال کرنے کی ضرورت ہو۔ نئے ٹولز لوڈ کرنے کے لیے سرور کو دوبارہ شروع کرنا نہ بھولیں۔

## حل

[Solution](./solution/README.md)

## اہم نکات

اس باب سے حاصل کردہ اہم نکات درج ذیل ہیں:

- AI Toolkit ایک بہترین کلائنٹ ہے جو آپ کو MCP Servers اور ان کے ٹولز استعمال کرنے دیتا ہے۔
- آپ MCP سرورز میں نئے ٹولز شامل کر کے ایجنٹ کی صلاحیتوں کو بڑھا سکتے ہیں تاکہ بدلتی ضروریات کو پورا کیا جا سکے۔
- AI Toolkit میں ٹیمپلیٹس شامل ہیں (جیسے Python MCP سرور ٹیمپلیٹس) جو کسٹم ٹولز بنانے کو آسان بناتے ہیں۔

## اضافی وسائل

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## آگے کیا ہے
- اگلا: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم نوٹ کریں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کی ذمہ داری ہم پر عائد نہیں ہوگی۔