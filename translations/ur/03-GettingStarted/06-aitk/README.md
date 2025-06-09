<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:24:29+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ur"
}
-->
# استعمال کرنا ایک سرور کو AI Toolkit ایکسٹینشن سے Visual Studio Code کے لیے

جب آپ ایک AI ایجنٹ بنا رہے ہوتے ہیں، تو صرف ذہین جوابات پیدا کرنا مقصد نہیں ہوتا؛ بلکہ آپ کے ایجنٹ کو عمل کرنے کی صلاحیت دینا بھی ضروری ہے۔ یہی وہ جگہ ہے جہاں Model Context Protocol (MCP) آتا ہے۔ MCP ایجنٹس کے لیے آسانی پیدا کرتا ہے کہ وہ بیرونی ٹولز اور خدمات تک ایک مستقل انداز میں رسائی حاصل کریں۔ اسے ایسے سمجھیں جیسے آپ اپنے ایجنٹ کو ایک ایسا ٹول باکس دے رہے ہوں جسے وہ واقعی استعمال کر سکتا ہے۔

فرض کریں آپ ایک ایجنٹ کو اپنے calculator MCP سرور سے جوڑتے ہیں۔ اچانک، آپ کا ایجنٹ ریاضی کے آپریشنز کر سکتا ہے صرف اس طرح کہ اسے ایک پرامپٹ ملے جیسے "47 کو 89 سے ضرب دو؟"—کوڈنگ یا کسٹم APIs بنانے کی ضرورت نہیں۔

## جائزہ

یہ سبق سکھاتا ہے کہ کیسے ایک calculator MCP سرور کو AI Toolkit کے ذریعے Visual Studio Code میں ایک ایجنٹ سے جوڑا جائے، تاکہ آپ کا ایجنٹ جمع، تفریق، ضرب، اور تقسیم جیسے ریاضیاتی آپریشنز قدرتی زبان کے ذریعے کر سکے۔

AI Toolkit ایک طاقتور ایکسٹینشن ہے Visual Studio Code کے لیے جو ایجنٹ کی ترقی کو آسان بناتا ہے۔ AI انجینئرز آسانی سے AI ایپلیکیشنز بنا اور ٹیسٹ کر سکتے ہیں، چاہے لوکل ہوں یا کلاؤڈ میں۔ یہ ایکسٹینشن آج دستیاب زیادہ تر جنریٹو ماڈلز کو سپورٹ کرتا ہے۔

*نوٹ*: AI Toolkit فی الحال Python اور TypeScript کو سپورٹ کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام پر، آپ کر سکیں گے:

- AI Toolkit کے ذریعے MCP سرور استعمال کرنا۔
- ایجنٹ کی کنفیگریشن کرنا تاکہ وہ MCP سرور کے فراہم کردہ ٹولز کو دریافت اور استعمال کر سکے۔
- MCP ٹولز کو قدرتی زبان کے ذریعے استعمال کرنا۔

## طریقہ کار

یہاں ایک اعلی سطح پر طریقہ کار ہے:

- ایک ایجنٹ بنائیں اور اس کا سسٹم پرامپٹ متعین کریں۔
- calculator ٹولز کے ساتھ ایک MCP سرور بنائیں۔
- Agent Builder کو MCP سرور سے جوڑیں۔
- قدرتی زبان کے ذریعے ایجنٹ کے ٹول کال کرنے کی جانچ کریں۔

بہت خوب، اب جب ہمیں فلو سمجھ آ گیا ہے، تو آئیے ایک AI ایجنٹ کو MCP کے ذریعے بیرونی ٹولز استعمال کرنے کے لیے کنفیگر کریں اور اس کی صلاحیتوں کو بڑھائیں!

## ضروریات

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## مشق: ایک سرور کا استعمال

اس مشق میں، آپ AI Toolkit استعمال کرتے ہوئے Visual Studio Code میں MCP سرور کے ٹولز کے ساتھ ایک AI ایجنٹ بنائیں گے، چلائیں گے، اور بہتر بنائیں گے۔

### -0- پری اسٹیپ، OpenAI GPT-4o ماڈل کو My Models میں شامل کریں

یہ مشق **GPT-4o** ماڈل کا استعمال کرتی ہے۔ ایجنٹ بنانے سے پہلے یہ ماڈل **My Models** میں شامل ہونا چاہیے۔

![Visual Studio Code کے AI Toolkit ایکسٹینشن میں ماڈل سلیکشن انٹرفیس کا اسکرین شاٹ۔ ہیڈنگ ہے "Find the right model for your AI Solution" اور سب ٹائٹل میں صارفین کو AI ماڈلز دریافت، ٹیسٹ، اور ڈپلائے کرنے کی ترغیب دی گئی ہے۔ "Popular Models" کے تحت چھ ماڈل کارڈز ہیں: DeepSeek-R1 (GitHub-hosted)، OpenAI GPT-4o، OpenAI GPT-4.1، OpenAI o1، Phi 4 Mini (CPU - Small, Fast)، اور DeepSeek-R1 (Ollama-hosted)۔ ہر کارڈ میں "Add" یا "Try in Playground" کے آپشنز ہیں۔](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.ur.png)

1. **Activity Bar** سے **AI Toolkit** ایکسٹینشن کھولیں۔
1. **Catalog** سیکشن میں، **Models** منتخب کریں تاکہ **Model Catalog** کھلے۔ یہ ایک نئے ایڈیٹر ٹیب میں کھلے گا۔
1. **Model Catalog** کے سرچ بار میں **OpenAI GPT-4o** لکھیں۔
1. **+ Add** پر کلک کریں تاکہ ماڈل آپ کی **My Models** فہرست میں شامل ہو جائے۔ یقینی بنائیں کہ آپ نے **Hosted by GitHub** ماڈل منتخب کیا ہے۔
1. **Activity Bar** میں چیک کریں کہ **OpenAI GPT-4o** ماڈل فہرست میں نظر آ رہا ہے۔

### -1- ایک ایجنٹ بنائیں

**Agent (Prompt) Builder** آپ کو اپنے AI ایجنٹس بنانے اور حسب ضرورت بنانے کی سہولت دیتا ہے۔ اس سیکشن میں، آپ ایک نیا ایجنٹ بنائیں گے اور گفتگو کے لیے ماڈل تفویض کریں گے۔

![AI Toolkit ایکسٹینشن میں "Calculator Agent" بلڈر انٹرفیس کا اسکرین شاٹ۔ بائیں پینل میں منتخب ماڈل "OpenAI GPT-4o (via GitHub)" ہے۔ سسٹم پرامپٹ میں لکھا ہے "You are a professor in university teaching math," اور یوزر پرامپٹ میں "Explain to me the Fourier equation in simple terms." اضافی آپشنز میں ٹولز شامل کرنے، MCP Server کو فعال کرنے، اور ساختی آؤٹ پٹ منتخب کرنے کے بٹن ہیں۔ نیچے نیلا "Run" بٹن ہے۔ دائیں پینل میں "Get Started with Examples" کے تحت تین سیمپل ایجنٹس کی فہرست ہے: Web Developer (MCP Server، Second-Grade Simplifier، اور Dream Interpreter کے ساتھ، ہر ایک کے فنکشن کی مختصر وضاحت کے ساتھ)۔](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.ur.png)

1. **Activity Bar** سے **AI Toolkit** ایکسٹینشن کھولیں۔
1. **Tools** سیکشن میں **Agent (Prompt) Builder** منتخب کریں۔ یہ ایک نئے ایڈیٹر ٹیب میں کھلے گا۔
1. **+ New Agent** بٹن پر کلک کریں۔ ایکسٹینشن **Command Palette** کے ذریعے سیٹ اپ وزرڈ لانچ کرے گا۔
1. نام **Calculator Agent** درج کریں اور **Enter** دبائیں۔
1. **Agent (Prompt) Builder** میں، **Model** فیلڈ کے لیے **OpenAI GPT-4o (via GitHub)** ماڈل منتخب کریں۔

### -2- ایجنٹ کے لیے سسٹم پرامپٹ بنائیں

اب جب ایجنٹ کا ڈھانچہ تیار ہو گیا ہے، وقت ہے اس کی شخصیت اور مقصد متعین کرنے کا۔ اس سیکشن میں، آپ **Generate system prompt** فیچر استعمال کریں گے تاکہ ایجنٹ کے متوقع رویے کی وضاحت کریں—اس کیس میں ایک calculator ایجنٹ—اور ماڈل سے سسٹم پرامپٹ لکھوائیں گے۔

![AI Toolkit میں "Calculator Agent" انٹرفیس کا اسکرین شاٹ جس میں "Generate a prompt" عنوان والی موڈل ونڈو کھلی ہوئی ہے۔ موڈل بتاتی ہے کہ پرامپٹ ٹیمپلیٹ بنیادی تفصیلات شیئر کر کے تیار کیا جا سکتا ہے۔ ایک ٹیکسٹ باکس میں سیمپل سسٹم پرامپٹ ہے: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." نیچے "Close" اور "Generate" بٹن ہیں۔ پس منظر میں ایجنٹ کنفیگریشن کا حصہ دکھائی دے رہا ہے، جس میں منتخب ماڈل "OpenAI GPT-4o (via GitHub)" اور سسٹم و یوزر پرامپٹس کے فیلڈز ہیں۔](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.ur.png)

1. **Prompts** سیکشن میں، **Generate system prompt** بٹن پر کلک کریں۔ یہ بٹن پرامپٹ بلڈر کھولے گا جو AI استعمال کرتے ہوئے سسٹم پرامپٹ تیار کرتا ہے۔
1. **Generate a prompt** ونڈو میں، درج کریں: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** بٹن پر کلک کریں۔ دائیں نیچے نوٹیفیکیشن آئے گا کہ سسٹم پرامپٹ تیار ہو رہا ہے۔ جب پرامپٹ مکمل ہو جائے گا، وہ **Agent (Prompt) Builder** کے **System prompt** فیلڈ میں ظاہر ہو جائے گا۔
1. **System prompt** کا جائزہ لیں اور ضرورت ہو تو ترمیم کریں۔

### -3- MCP سرور بنائیں

اب جب آپ نے ایجنٹ کا سسٹم پرامپٹ متعین کر دیا ہے—جو اس کے رویے اور جوابات کی رہنمائی کرتا ہے—وقت ہے کہ ایجنٹ کو عملی صلاحیتوں سے لیس کریں۔ اس سیکشن میں، آپ calculator MCP سرور بنائیں گے جس میں جمع، تفریق، ضرب، اور تقسیم کے ٹولز ہوں گے۔ یہ سرور آپ کے ایجنٹ کو قدرتی زبان کے پرامپٹس کے جواب میں ریئل ٹائم ریاضیاتی آپریشنز کرنے کے قابل بنائے گا۔

![Calculator Agent انٹرفیس کا نچلا حصہ دکھانے والا اسکرین شاٹ جس میں "Tools" اور "Structure output" کے ایکسپینڈ ایبل مینو ہیں، اور "Choose output format" ڈراپ ڈاؤن "text" پر سیٹ ہے۔ دائیں طرف "+ MCP Server" بٹن ہے جو Model Context Protocol سرور شامل کرنے کے لیے ہے۔ Tools سیکشن کے اوپر ایک امیج آئیکن پلیس ہولڈر بھی ہے۔](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.ur.png)

AI Toolkit آپ کے لیے MCP سرور بنانے کے لیے ٹیمپلیٹس فراہم کرتا ہے۔ ہم calculator MCP سرور بنانے کے لیے Python ٹیمپلیٹ استعمال کریں گے۔

*نوٹ*: AI Toolkit فی الحال Python اور TypeScript کو سپورٹ کرتا ہے۔

1. **Agent (Prompt) Builder** کے **Tools** سیکشن میں، **+ MCP Server** بٹن پر کلک کریں۔ ایکسٹینشن **Command Palette** کے ذریعے سیٹ اپ وزرڈ لانچ کرے گا۔
1. **+ Add Server** منتخب کریں۔
1. **Create a New MCP Server** منتخب کریں۔
1. ٹیمپلیٹ کے طور پر **python-weather** منتخب کریں۔
1. MCP سرور ٹیمپلیٹ محفوظ کرنے کے لیے **Default folder** منتخب کریں۔
1. سرور کے لیے نام درج کریں: **Calculator**
1. Visual Studio Code کی ایک نئی ونڈو کھلے گی۔ **Yes, I trust the authors** منتخب کریں۔
1. ٹرمینل میں جا کر ایک ورچوئل انوائرمنٹ بنائیں: `python -m venv .venv`
1. ٹرمینل میں ورچوئل انوائرمنٹ کو فعال کریں:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ٹرمینل میں dependencies انسٹال کریں: `pip install -e .[dev]`
1. **Activity Bar** کے **Explorer** ویو میں **src** ڈائریکٹری کو کھولیں اور **server.py** فائل ایڈیٹر میں کھولیں۔
1. **server.py** کی موجودہ کوڈ کو مندرجہ ذیل سے تبدیل کریں اور محفوظ کریں:

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

اب جب آپ کے ایجنٹ کے پاس ٹولز ہیں، وقت ہے ان کا استعمال کرنے کا! اس سیکشن میں، آپ ایجنٹ کو پرامپٹس بھیج کر ٹیسٹ کریں گے کہ آیا ایجنٹ calculator MCP سرور کے مناسب ٹول کا استعمال کر رہا ہے یا نہیں۔

![Calculator Agent انٹرفیس کا اسکرین شاٹ جس میں بائیں پینل کے "Tools" کے تحت local-server-calculator_server نام کا MCP سرور شامل ہے، جس میں چار ٹولز ہیں: add، subtract، multiply، اور divide۔ ایک بیج دکھا رہا ہے کہ چار ٹولز فعال ہیں۔ نیچے "Structure output" سیکشن بند ہے اور نیلا "Run" بٹن ہے۔ دائیں پینل میں "Model Response" کے تحت ایجنٹ multiply اور subtract ٹولز کو ان پٹ کے ساتھ کال کر رہا ہے: {"a": 3, "b": 25} اور {"a": 75, "b": 20}۔ حتمی "Tool Response" 75.0 دکھائی دے رہا ہے۔ نیچے "View Code" بٹن موجود ہے۔](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.ur.png)

آپ calculator MCP سرور اپنے لوکل ڈویلپمنٹ مشین پر **Agent Builder** کے ذریعے MCP کلائنٹ کے طور پر چلائیں گے۔

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` کی قدریں **subtract** ٹول کے لیے دی گئی ہیں۔
    - ہر ٹول کی طرف سے جواب متعلقہ **Tool Response** میں دیا جاتا ہے۔
    - ماڈل کا حتمی آؤٹ پٹ آخری **Model Response** میں دیا جاتا ہے۔
1. مزید پرامپٹس بھیج کر ایجنٹ کو مزید ٹیسٹ کریں۔ آپ موجودہ پرامپٹ کو **User prompt** فیلڈ میں کلک کر کے تبدیل کر سکتے ہیں۔
1. جب آپ ٹیسٹنگ ختم کر لیں، تو سرور کو بند کرنے کے لیے ٹرمینل میں **CTRL/CMD+C** دبائیں۔

## اسائنمنٹ

اپنی **server.py** فائل میں ایک اضافی ٹول شامل کرنے کی کوشش کریں (مثلاً: کسی نمبر کا مربع جذر واپس کریں)۔ مزید پرامپٹس بھیجیں جن میں ایجنٹ کو آپ کے نئے یا موجودہ ٹولز استعمال کرنے کی ضرورت ہو۔ نئے ٹولز لوڈ کرنے کے لیے سرور کو ری اسٹارٹ کرنا مت بھولیں۔

## حل

[Solution](./solution/README.md)

## اہم نکات

اس باب سے حاصل ہونے والے نکات درج ذیل ہیں:

- AI Toolkit ایک بہترین کلائنٹ ہے جو آپ کو MCP Servers اور ان کے ٹولز استعمال کرنے دیتا ہے۔
- آپ MCP سرورز میں نئے ٹولز شامل کر سکتے ہیں، تاکہ ایجنٹ کی صلاحیتوں کو بدلتے تقاضوں کے مطابق بڑھایا جا سکے۔
- AI Toolkit ٹیمپلیٹس فراہم کرتا ہے (مثلاً Python MCP سرور ٹیمپلیٹس) تاکہ کسٹم ٹولز بنانے کو آسان بنایا جا سکے۔

## اضافی وسائل

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## آگے کیا ہے

اگلا: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**دستخطی:**
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔