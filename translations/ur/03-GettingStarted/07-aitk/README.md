<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T15:52:51+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ur"
}
-->
# Visual Studio Code کے لیے AI Toolkit ایکسٹینشن سے سرور کا استعمال

جب آپ ایک AI ایجنٹ بنا رہے ہوتے ہیں، تو صرف ذہین جوابات پیدا کرنا ہی مقصد نہیں ہوتا؛ بلکہ اپنے ایجنٹ کو عمل کرنے کی صلاحیت دینا بھی ضروری ہے۔ یہی وہ جگہ ہے جہاں Model Context Protocol (MCP) آتا ہے۔ MCP ایجنٹس کو بیرونی ٹولز اور سروسز تک آسان اور یکساں رسائی فراہم کرتا ہے۔ اسے ایسے سمجھیں جیسے آپ اپنے ایجنٹ کو ایک ایسا ٹول باکس دے رہے ہیں جسے وہ واقعی استعمال کر سکتا ہے۔

فرض کریں آپ نے اپنے ایجنٹ کو کیلکولیٹر MCP سرور سے جوڑ دیا۔ اچانک، آپ کا ایجنٹ صرف اس طرح کے پرامپٹ وصول کر کے ریاضی کے مسائل حل کر سکتا ہے جیسے "47 کو 89 سے ضرب دیں" — بغیر کسی ہارڈ کوڈڈ لاجک یا کسٹم API بنانے کی ضرورت کے۔

## جائزہ

یہ سبق بتاتا ہے کہ Visual Studio Code میں [AI Toolkit](https://aka.ms/AIToolkit) ایکسٹینشن کے ذریعے کیلکولیٹر MCP سرور کو ایجنٹ سے کیسے جوڑا جائے، تاکہ آپ کا ایجنٹ قدرتی زبان کے ذریعے جمع، تفریق، ضرب، اور تقسیم جیسے ریاضیاتی عمل انجام دے سکے۔

AI Toolkit Visual Studio Code کے لیے ایک طاقتور ایکسٹینشن ہے جو ایجنٹ کی ترقی کو آسان بناتا ہے۔ AI انجینئرز آسانی سے جنریٹو AI ماڈلز کو لوکل یا کلاؤڈ میں تیار اور ٹیسٹ کر کے AI ایپلیکیشنز بنا سکتے ہیں۔ یہ ایکسٹینشن آج دستیاب زیادہ تر بڑے جنریٹو ماڈلز کی حمایت کرتا ہے۔

*نوٹ*: AI Toolkit اس وقت Python اور TypeScript کی حمایت کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک آپ کر سکیں گے:

- AI Toolkit کے ذریعے MCP سرور کا استعمال کرنا۔
- ایجنٹ کی کنفیگریشن ترتیب دینا تاکہ وہ MCP سرور کے فراہم کردہ ٹولز کو دریافت اور استعمال کر سکے۔
- MCP ٹولز کو قدرتی زبان کے ذریعے استعمال کرنا۔

## طریقہ کار

ہمیں اس کام کو اعلیٰ سطح پر اس طرح انجام دینا ہے:

- ایک ایجنٹ بنائیں اور اس کا سسٹم پرامپٹ متعین کریں۔
- کیلکولیٹر ٹولز کے ساتھ MCP سرور بنائیں۔
- Agent Builder کو MCP سرور سے جوڑیں۔
- قدرتی زبان کے ذریعے ایجنٹ کے ٹول کال کو ٹیسٹ کریں۔

زبردست، اب جب ہم فلو سمجھ گئے ہیں، تو آئیے ایک AI ایجنٹ کو MCP کے ذریعے بیرونی ٹولز استعمال کرنے کے لیے ترتیب دیں اور اس کی صلاحیتوں کو بڑھائیں!

## ضروریات

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## مشق: سرور کا استعمال

اس مشق میں، آپ Visual Studio Code میں AI Toolkit کا استعمال کرتے ہوئے MCP سرور کے ٹولز کے ساتھ ایک AI ایجنٹ بنائیں گے، چلائیں گے، اور بہتر بنائیں گے۔

### -0- ابتدائی قدم، OpenAI GPT-4o ماڈل کو My Models میں شامل کریں

یہ مشق **GPT-4o** ماڈل پر مبنی ہے۔ ایجنٹ بنانے سے پہلے ماڈل کو **My Models** میں شامل کرنا ضروری ہے۔

![Visual Studio Code کے AI Toolkit ایکسٹینشن میں ماڈل منتخب کرنے کا انٹرفیس۔ ہیڈنگ میں لکھا ہے "Find the right model for your AI Solution" اور سب ٹائٹل میں صارفین کو AI ماڈلز دریافت، ٹیسٹ، اور تعینات کرنے کی ترغیب دی گئی ہے۔ "Popular Models" کے تحت چھ ماڈل کارڈز دکھائے گئے ہیں: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), اور DeepSeek-R1 (Ollama-hosted)۔ ہر کارڈ پر "Add" اور "Try in Playground" کے آپشنز موجود ہیں۔](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ur.png)

1. **Activity Bar** سے **AI Toolkit** ایکسٹینشن کھولیں۔
2. **Catalog** سیکشن میں **Models** منتخب کریں تاکہ **Model Catalog** کھلے۔ **Models** منتخب کرنے سے **Model Catalog** ایک نئے ایڈیٹر ٹیب میں کھل جائے گا۔
3. **Model Catalog** کے سرچ بار میں **OpenAI GPT-4o** لکھیں۔
4. **+ Add** پر کلک کریں تاکہ ماڈل آپ کی **My Models** فہرست میں شامل ہو جائے۔ یقینی بنائیں کہ آپ نے وہ ماڈل منتخب کیا ہے جو **GitHub-hosted** ہے۔
5. **Activity Bar** میں تصدیق کریں کہ **OpenAI GPT-4o** ماڈل فہرست میں ظاہر ہو رہا ہے۔

### -1- ایک ایجنٹ بنائیں

**Agent (Prompt) Builder** آپ کو اپنا AI ایجنٹ بنانے اور حسب ضرورت بنانے کی سہولت دیتا ہے۔ اس حصے میں، آپ ایک نیا ایجنٹ بنائیں گے اور گفتگو کے لیے ایک ماڈل تفویض کریں گے۔

![Visual Studio Code کے AI Toolkit ایکسٹینشن میں "Calculator Agent" بلڈر انٹرفیس کا اسکرین شاٹ۔ بائیں پینل میں منتخب ماڈل "OpenAI GPT-4o (via GitHub)" ہے۔ سسٹم پرامپٹ میں لکھا ہے "You are a professor in university teaching math," اور یوزر پرامپٹ میں "Explain to me the Fourier equation in simple terms." اضافی آپشنز میں ٹولز شامل کرنے، MCP Server فعال کرنے، اور ساختی آؤٹ پٹ منتخب کرنے کے بٹن شامل ہیں۔ نیچے نیلا "Run" بٹن موجود ہے۔ دائیں پینل میں "Get Started with Examples" کے تحت تین نمونہ ایجنٹس کی فہرست ہے: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter کے ساتھ، ہر ایک کے مختصر فنکشن کی وضاحت کے ساتھ)](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ur.png)

1. **Activity Bar** سے **AI Toolkit** ایکسٹینشن کھولیں۔
2. **Tools** سیکشن میں **Agent (Prompt) Builder** منتخب کریں۔ منتخب کرنے سے **Agent (Prompt) Builder** ایک نئے ایڈیٹر ٹیب میں کھل جائے گا۔
3. **+ New Agent** بٹن پر کلک کریں۔ ایکسٹینشن **Command Palette** کے ذریعے سیٹ اپ وزرڈ شروع کرے گا۔
4. نام کے طور پر **Calculator Agent** درج کریں اور **Enter** دبائیں۔
5. **Agent (Prompt) Builder** میں **Model** فیلڈ کے لیے **OpenAI GPT-4o (via GitHub)** ماڈل منتخب کریں۔

### -2- ایجنٹ کے لیے سسٹم پرامپٹ بنائیں

اب جب ایجنٹ کا ڈھانچہ تیار ہو گیا ہے، تو اس کی شخصیت اور مقصد متعین کرنے کا وقت ہے۔ اس حصے میں، آپ **Generate system prompt** فیچر استعمال کریں گے تاکہ ایجنٹ کے متوقع رویے کی وضاحت کریں — اس صورت میں، ایک کیلکولیٹر ایجنٹ — اور ماڈل سے سسٹم پرامپٹ لکھوائیں گے۔

![Visual Studio Code کے AI Toolkit میں "Calculator Agent" انٹرفیس کا اسکرین شاٹ جس میں "Generate a prompt" کے عنوان سے ایک موڈل ونڈو کھلی ہے۔ موڈل میں بتایا گیا ہے کہ بنیادی تفصیلات فراہم کر کے پرامپٹ ٹیمپلیٹ تیار کیا جا سکتا ہے۔ ایک ٹیکسٹ باکس میں نمونہ سسٹم پرامپٹ ہے: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." نیچے "Close" اور "Generate" بٹن موجود ہیں۔ پس منظر میں ایجنٹ کی کنفیگریشن دکھائی دے رہی ہے، جس میں منتخب ماڈل "OpenAI GPT-4o (via GitHub)" اور سسٹم و یوزر پرامپٹس کے فیلڈز شامل ہیں۔](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ur.png)

1. **Prompts** سیکشن میں **Generate system prompt** بٹن پر کلک کریں۔ یہ بٹن پرامپٹ بلڈر کھولے گا جو AI کی مدد سے ایجنٹ کے لیے سسٹم پرامپٹ تیار کرتا ہے۔
2. **Generate a prompt** ونڈو میں درج کریں: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** بٹن پر کلک کریں۔ نیچے دائیں کونے میں ایک نوٹیفیکیشن ظاہر ہوگا جو بتائے گا کہ سسٹم پرامپٹ تیار ہو رہا ہے۔ جب پرامپٹ تیار ہو جائے گا، تو یہ **Agent (Prompt) Builder** کے **System prompt** فیلڈ میں ظاہر ہو جائے گا۔
4. **System prompt** کا جائزہ لیں اور ضرورت ہو تو ترمیم کریں۔

### -3- MCP سرور بنائیں

اب جب آپ نے ایجنٹ کا سسٹم پرامپٹ متعین کر دیا ہے — جو اس کے رویے اور جوابات کی رہنمائی کرتا ہے — تو وقت ہے کہ ایجنٹ کو عملی صلاحیتیں دیں۔ اس حصے میں، آپ ایک کیلکولیٹر MCP سرور بنائیں گے جس میں جمع، تفریق، ضرب، اور تقسیم کے ٹولز شامل ہوں گے۔ یہ سرور آپ کے ایجنٹ کو قدرتی زبان کے پرامپٹس کے جواب میں حقیقی وقت میں ریاضیاتی عمل انجام دینے کے قابل بنائے گا۔

![Visual Studio Code کے AI Toolkit ایکسٹینشن میں Calculator Agent انٹرفیس کے نچلے حصے کا اسکرین شاٹ۔ اس میں "Tools" اور "Structure output" کے لیے قابل توسیع مینو دکھائے گئے ہیں، اور "Choose output format" ڈراپ ڈاؤن مینو "text" پر سیٹ ہے۔ دائیں جانب "+ MCP Server" بٹن موجود ہے جو Model Context Protocol سرور شامل کرنے کے لیے ہے۔ Tools سیکشن کے اوپر ایک تصویر آئیکن پلیس ہولڈر بھی دکھائی دے رہا ہے۔](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ur.png)

AI Toolkit آپ کے لیے MCP سرور بنانے کے لیے ٹیمپلیٹس فراہم کرتا ہے۔ ہم کیلکولیٹر MCP سرور بنانے کے لیے Python ٹیمپلیٹ استعمال کریں گے۔

*نوٹ*: AI Toolkit اس وقت Python اور TypeScript کی حمایت کرتا ہے۔

1. **Agent (Prompt) Builder** کے **Tools** سیکشن میں **+ MCP Server** بٹن پر کلک کریں۔ ایکسٹینشن **Command Palette** کے ذریعے سیٹ اپ وزرڈ شروع کرے گا۔
2. **+ Add Server** منتخب کریں۔
3. **Create a New MCP Server** منتخب کریں۔
4. ٹیمپلیٹ کے طور پر **python-weather** منتخب کریں۔
5. MCP سرور ٹیمپلیٹ کو محفوظ کرنے کے لیے **Default folder** منتخب کریں۔
6. سرور کے لیے نام درج کریں: **Calculator**
7. ایک نیا Visual Studio Code ونڈو کھلے گا۔ **Yes, I trust the authors** منتخب کریں۔
8. ٹرمینل میں جا کر ورچوئل انوائرمنٹ بنائیں: `python -m venv .venv`
9. ٹرمینل میں ورچوئل انوائرمنٹ کو فعال کریں:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. ٹرمینل میں dependencies انسٹال کریں: `pip install -e .[dev]`
11. **Activity Bar** کے **Explorer** ویو میں **src** ڈائریکٹری کو کھولیں اور **server.py** فائل کو ایڈیٹر میں کھولیں۔
12. **server.py** کی موجودہ کوڈ کو درج ذیل سے تبدیل کریں اور محفوظ کریں:

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

### -4- کیلکولیٹر MCP سرور کے ساتھ ایجنٹ چلائیں

اب جب آپ کے ایجنٹ کے پاس ٹولز موجود ہیں، تو وقت ہے انہیں استعمال کرنے کا! اس حصے میں، آپ ایجنٹ کو پرامپٹس بھیج کر ٹیسٹ کریں گے کہ آیا ایجنٹ کیلکولیٹر MCP سرور کے مناسب ٹول کا استعمال کر رہا ہے یا نہیں۔

![Visual Studio Code کے AI Toolkit ایکسٹینشن میں Calculator Agent انٹرفیس کا اسکرین شاٹ۔ بائیں پینل میں "Tools" کے تحت ایک MCP سرور "local-server-calculator_server" شامل ہے، جس میں چار دستیاب ٹولز ہیں: add, subtract, multiply, اور divide۔ ایک بیج دکھا رہا ہے کہ چار ٹولز فعال ہیں۔ نیچے "Structure output" سیکشن بند ہے اور نیلا "Run" بٹن موجود ہے۔ دائیں پینل میں "Model Response" کے تحت ایجنٹ نے multiply اور subtract ٹولز کو بالترتیب ان پٹ {"a": 3, "b": 25} اور {"a": 75, "b": 20} کے ساتھ کال کیا ہے۔ آخری "Tool Response" 75.0 دکھا رہا ہے۔ نیچے "View Code" بٹن بھی موجود ہے۔](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ur.png)

آپ اپنے لوکل ڈویلپمنٹ مشین پر **Agent Builder** کے ذریعے MCP کلائنٹ کے طور پر کیلکولیٹر MCP سرور چلائیں گے۔

1. `F5` دبائیں تاکہ MCP سرور کی ڈیبگنگ شروع ہو۔ **Agent (Prompt) Builder** ایک نئے ایڈیٹر ٹیب میں کھلے گا۔ سرور کی حالت ٹرمینل میں نظر آئے گی۔
2. **Agent (Prompt) Builder** کے **User prompt** فیلڈ میں درج کریں: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. **Run** بٹن پر کلک کریں تاکہ ایجنٹ کا جواب تیار ہو۔
4. ایجنٹ کے آؤٹ پٹ کا جائزہ لیں۔ ماڈل کو نتیجہ نکالنا چاہیے کہ آپ نے **$55** ادا کیے۔
5. یہاں وہ عمل ہے جو ہونا چاہیے:
    - ایجنٹ حساب کے لیے **multiply** اور **subtract** ٹولز منتخب کرتا ہے۔
    - **multiply** ٹول کے لیے `a` اور `b` کی متعلقہ قدریں تفویض کی جاتی ہیں۔
    - **subtract** ٹول کے لیے `a` اور `b` کی متعلقہ قدریں تفویض کی جاتی ہیں۔
    - ہر ٹول سے حاصل شدہ جواب متعلقہ **Tool Response** میں دیا جاتا ہے۔
    - ماڈل کا حتمی جواب **Model Response** میں فراہم کیا جاتا ہے۔
6. مزید پرامپٹس بھیج کر ایجنٹ کو مزید ٹیسٹ کریں۔ آپ موجودہ پرامپٹ کو **User prompt** فیلڈ میں کلک کر کے تبدیل کر سکتے ہیں۔
7. جب آپ ٹیسٹنگ مکمل کر لیں، تو ٹرمینل میں **CTRL/CMD+C** دبا کر سرور بند کر سکتے ہیں۔

## اسائنمنٹ

اپنی **server.py** فائل میں ایک اضافی ٹول شامل کرنے کی کوشش کریں (مثلاً: کسی نمبر کا مربع جذر واپس کریں)۔ ایسے اضافی پرامپٹس بھیجیں جن کے لیے ایجنٹ کو آپ کے نئے یا موجودہ ٹولز استعمال کرنے کی ضرورت ہو۔ نئے ٹولز لوڈ کرنے کے لیے سرور کو دوبارہ شروع کرنا نہ بھولیں۔

## حل

[Solution](./solution/README.md)

## اہم نکات

اس باب سے حاصل کردہ اہم باتیں درج ذیل ہیں:

- AI Toolkit ایکسٹینشن ایک بہترین کلائنٹ ہے جو آپ کو MCP سرورز اور ان کے ٹولز استعمال کرنے دیتا ہے۔
- آپ MCP سرورز میں نئے ٹولز شامل کر کے ایجنٹ کی صلاحیتوں کو بڑھا سکتے ہیں تاکہ بدلتی ضروریات کو پورا کیا جا سکے۔
- AI Toolkit ٹیمپلیٹس (جیسے Python MCP سرور ٹیمپلیٹس) فراہم کرتا ہے جو کسٹم ٹولز بنانے کو آسان بناتے ہیں۔

## اضافی وسائل

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## آگے کیا ہے
- اگلا: [Testing & Debugging](../08-testing/README.md)

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔