<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T19:23:07+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "my"
}
-->
# Visual Studio Code အတွက် AI Toolkit extension မှ server ကို အသုံးပြုခြင်း

AI agent တစ်ခု တည်ဆောက်တဲ့အခါမှာ၊ ဉာဏ်ကြီးတဲ့ တုံ့ပြန်ချက်တွေ ဖန်တီးပေးတာသာမက၊ agent ကို လုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်စေဖို့လည်း အရေးကြီးပါတယ်။ ဒီမှာ Model Context Protocol (MCP) က အရေးပါပါတယ်။ MCP က agent တွေကို အပြင်က ကိရိယာတွေ၊ ဝန်ဆောင်မှုတွေကို တစ်မျိုးတည်းနည်းလမ်းနဲ့ လွယ်ကူစွာ အသုံးပြုနိုင်စေပါတယ်။ agent ကို အသုံးချနိုင်တဲ့ ကိရိယာသေတ္တာတစ်ခုထဲ ထည့်သွင်းထားတာလို ထင်နိုင်ပါတယ်။

ဥပမာ Agent ကို calculator MCP server နဲ့ ချိတ်ဆက်လိုက်ရင်၊ “47 ကို 89 နဲ့မြှောက်ရင် ဘယ်လောက်လဲ?” ဆိုတဲ့ prompt တစ်ခုသာ ပေးလိုက်တာနဲ့ သင့် agent က သင်္ချာဆိုင်ရာ လုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်မှာဖြစ်ပြီး၊ logic ကို hardcode လုပ်စရာမလို၊ custom API မတည်ဆောက်စရာမလိုပါဘူး။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ Visual Studio Code ရဲ့ [AI Toolkit](https://aka.ms/AIToolkit) extension ကို အသုံးပြုပြီး calculator MCP server ကို agent နဲ့ ချိတ်ဆက်ခြင်းနဲ့၊ agent ကို ပေါင်းခြား၊ ဖြုတ်ခြား၊ မြှောက်ခြား၊ နှုတ်ခြား စသည့် သင်္ချာလုပ်ဆောင်ချက်တွေကို သဘာဝဘာသာစကားဖြင့် ပြုလုပ်နိုင်အောင် ပြုလုပ်ပုံကို ဖော်ပြထားပါတယ်။

AI Toolkit က Visual Studio Code အတွက် agent ဖန်တီးမှုကို လွယ်ကူစေတဲ့ အင်အားကြီး extension တစ်ခုဖြစ်ပြီး၊ AI Engineer တွေကို local သို့ cloud ပေါ်မှာ generative AI မော်ဒယ်တွေ ဖန်တီး၊ စမ်းသပ်၊ တိုးတက်အောင် လုပ်ဆောင်နိုင်စေပါတယ်။ ယနေ့မှာ ရရှိနိုင်တဲ့ အဓိက generative မော်ဒယ်အများစုကို ထောက်ပံ့ပေးပါတယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို လက်ရှိထောက်ပံ့ပေးထားပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးချိန်မှာ သင်မှာ အောက်ပါအရာတွေကို လုပ်နိုင်ပါလိမ့်မယ်-

- AI Toolkit မှတဆင့် MCP server ကို အသုံးပြုနိုင်ခြင်း။
- MCP server က ပေးတဲ့ ကိရိယာတွေကို ရှာဖွေ အသုံးပြုနိုင်အောင် agent configuration ကို ပြင်ဆင်နိုင်ခြင်း။
- သဘာဝဘာသာစကားဖြင့် MCP ကိရိယာတွေကို အသုံးပြုနိုင်ခြင်း။

## လုပ်ဆောင်ပုံ

အထက်တန်းမှာ အောက်ပါအတိုင်း လုပ်ဆောင်ရပါမယ်-

- Agent တစ်ခု ဖန်တီးပြီး system prompt ကို သတ်မှတ်ပါ။
- Calculator tools ပါတဲ့ MCP server တစ်ခု ဖန်တီးပါ။
- Agent Builder ကို MCP server နဲ့ ချိတ်ဆက်ပါ။
- သဘာဝဘာသာစကားဖြင့် agent ရဲ့ tool အသုံးပြုမှုကို စမ်းသပ်ပါ။

အိုကေ၊ လုပ်ဆောင်ပုံကို နားလည်သွားပြီဆိုတော့ MCP မှတဆင့် အပြင်က ကိရိယာတွေကို အသုံးပြုနိုင်အောင် AI agent ကို ပြင်ဆင်ကြရအောင်၊ agent ရဲ့ စွမ်းရည်တွေ တိုးတက်စေဖို့ပါ။

## လိုအပ်ချက်များ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## လေ့ကျင့်ခန်း: Server ကို အသုံးပြုခြင်း

ဒီလေ့ကျင့်ခန်းမှာ Visual Studio Code ထဲမှာ AI Toolkit ကို အသုံးပြုပြီး MCP server က ကိရိယာတွေနဲ့ AI agent တစ်ခုကို ဖန်တီး၊ လည်ပတ်၊ တိုးတက်အောင် ပြုလုပ်ပါမယ်။

### -0- အစပိုင်း - OpenAI GPT-4o မော်ဒယ်ကို My Models ထဲ ထည့်ခြင်း

ဒီလေ့ကျင့်ခန်းမှာ **GPT-4o** မော်ဒယ်ကို အသုံးပြုမှာဖြစ်ပြီး၊ agent ဖန်တီးမယ့်အရင်မှာ **My Models** ထဲ ထည့်ထားဖို့ လိုအပ်ပါတယ်။

![Visual Studio Code AI Toolkit extension မှ မော်ဒယ်ရွေးချယ်မှု အင်တာဖေ့စ် screenshot။ ခေါင်းစဉ်မှာ "Find the right model for your AI Solution" ဟုရေးထားပြီး၊ subtitle မှာ AI မော်ဒယ်တွေ ရှာဖွေ၊ စမ်းသပ်၊ တပ်ဆင်ဖို့ အကြံပြုထားသည်။ “Popular Models” အောက်မှာ DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), DeepSeek-R1 (Ollama-hosted) စသည့် မော်ဒယ်ကတ်များ ရှိသည်။ မော်ဒယ်တစ်ခုချင်းစီမှာ “Add” နှင့် “Try in Playground” ခလုတ်များ ပါဝင်သည်။](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.my.png)

1. **Activity Bar** မှ **AI Toolkit** extension ကို ဖွင့်ပါ။
2. **Catalog** အပိုင်းမှာ **Models** ကို ရွေးပြီး **Model Catalog** ကို ဖွင့်ပါ။ Models ကို ရွေးချယ်ခြင်းဖြင့် Model Catalog သည် editor tab အသစ်တစ်ခုတွင် ဖွင့်လှစ်ပါမည်။
3. Model Catalog ရှာဖွေမှုဘားတွင် **OpenAI GPT-4o** ဟု ရိုက်ထည့်ပါ။
4. **+ Add** ကို နှိပ်ပြီး မော်ဒယ်ကို **My Models** စာရင်းထဲ ထည့်ပါ။ GitHub မှ host လုပ်ထားတဲ့ မော်ဒယ်ကို ရွေးချယ်ထားကြောင်း သေချာစေပါ။
5. **Activity Bar** တွင် **OpenAI GPT-4o** မော်ဒယ်သည် စာရင်းထဲ တွေ့ရမည်။

### -1- Agent တစ်ခု ဖန်တီးခြင်း

**Agent (Prompt) Builder** က သင့်ကို ကိုယ်ပိုင် AI agent တွေ ဖန်တီး၊ စိတ်ကြိုက်ပြင်ဆင်နိုင်စေပါတယ်။ ဒီအပိုင်းမှာ agent အသစ်တစ်ခု ဖန်တီးပြီး စကားပြောပွဲအတွက် မော်ဒယ်တစ်ခု သတ်မှတ်ပါမယ်။

![Visual Studio Code AI Toolkit extension မှ "Calculator Agent" builder အင်တာဖေ့စ် screenshot။ ဘယ်ဘက် panel တွင် "OpenAI GPT-4o (via GitHub)" မော်ဒယ် ရွေးထားသည်။ System prompt တွင် "You are a professor in university teaching math" ဟုရေးထားပြီး၊ user prompt တွင် "Explain to me the Fourier equation in simple terms." ဟုရေးထားသည်။ အပိုင်းများတွင် tools ထည့်ခြင်း၊ MCP Server ဖွင့်ခြင်း၊ structured output ရွေးချယ်ခြင်း ခလုတ်များ ပါဝင်သည်။ အောက်ဘက်တွင် အပြာရောင် “Run” ခလုတ်ရှိသည်။ ညာဘက် panel တွင် "Get Started with Examples" အောက်မှာ Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter) စသည့် sample agent သုံးခု ဖော်ပြထားသည်။](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.my.png)

1. **Activity Bar** မှ **AI Toolkit** extension ကို ဖွင့်ပါ။
2. **Tools** အပိုင်းတွင် **Agent (Prompt) Builder** ကို ရွေးပါ။ Agent (Prompt) Builder သည် editor tab အသစ်တစ်ခုတွင် ဖွင့်လှစ်ပါမည်။
3. **+ New Agent** ခလုတ်ကို နှိပ်ပါ။ Extension က **Command Palette** မှ setup wizard ကို စတင်ပါမည်။
4. အမည်အဖြစ် **Calculator Agent** ဟု ရိုက်ထည့်ပြီး **Enter** နှိပ်ပါ။
5. **Agent (Prompt) Builder** တွင် **Model** အကွက်အတွက် **OpenAI GPT-4o (via GitHub)** မော်ဒယ်ကို ရွေးချယ်ပါ။

### -2- Agent အတွက် system prompt ဖန်တီးခြင်း

Agent ကို ဖန်တီးပြီးနောက်၊ ၎င်းရဲ့ ကိုယ်ရည်ကိုယ်သွေးနဲ့ ရည်ရွယ်ချက်ကို သတ်မှတ်ဖို့ အချိန်ရောက်ပါပြီ။ ဒီအပိုင်းမှာ **Generate system prompt** လုပ်ဆောင်ချက်ကို အသုံးပြုပြီး calculator agent အဖြစ် agent ရဲ့ အပြုအမူကို ဖော်ပြတဲ့ system prompt ကို မော်ဒယ်ကို ရေးပေးပါမယ်။

![Visual Studio Code AI Toolkit မှ "Calculator Agent" အင်တာဖေ့စ် screenshot။ "Generate a prompt" ခေါင်းစဉ်ဖြင့် modal ပြတင်းပေါက်တစ်ခု ဖွင့်ထားသည်။ Modal တွင် prompt template ကို အခြေခံအချက်အလက်များ ဖြင့် ဖန်တီးနိုင်ကြောင်း ရှင်းပြထားပြီး၊ စာသားအကွက်တွင် "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." ဟု နမူနာ system prompt ရေးထားသည်။ အောက်တွင် "Close" နှင့် "Generate" ခလုတ်များ ပါဝင်သည်။ နောက်ခံတွင် agent configuration ၏ အစိတ်အပိုင်းများ၊ ရွေးထားသော မော်ဒယ် "OpenAI GPT-4o (via GitHub)" နှင့် system, user prompt အကွက်များ မြင်ရသည်။](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.my.png)

1. **Prompts** အပိုင်းတွင် **Generate system prompt** ခလုတ်ကို နှိပ်ပါ။ ၎င်းသည် AI ကို အသုံးပြုပြီး system prompt ကို ဖန်တီးပေးမည့် prompt builder ကို ဖွင့်ပါမည်။
2. **Generate a prompt** ပြတင်းပေါက်တွင် အောက်ပါစာသားကို ရိုက်ထည့်ပါ- `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** ခလုတ်ကို နှိပ်ပါ။ စနစ် prompt ဖန်တီးနေသည်ကို အောက်ညာထောင့်တွင် အသိပေးချက်တစ်ခု ပြပါမည်။ ဖန်တီးမှုပြီးဆုံးလျှင် system prompt သည် **Agent (Prompt) Builder** ၏ **System prompt** အကွက်တွင် ပြသပါမည်။
4. **System prompt** ကို ပြန်လည်သုံးသပ်ပြီး လိုအပ်သလို ပြင်ဆင်ပါ။

### -3- MCP server တစ်ခု ဖန်တီးခြင်း

Agent ရဲ့ system prompt ကို သတ်မှတ်ပြီးနောက်၊ agent ကို လက်တွေ့အသုံးချနိုင်စေဖို့ စွမ်းရည်တွေနဲ့ ပြည့်စုံအောင် ပြုလုပ်ရမယ်။ ဒီအပိုင်းမှာ ပေါင်းခြား၊ ဖြုတ်ခြား၊ မြှောက်ခြား၊ နှုတ်ခြား စသည့် သင်္ချာလုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်တဲ့ calculator MCP server တစ်ခု ဖန်တီးပါမယ်။ ဒီ server က agent ကို သဘာဝဘာသာစကား prompt တွေကို အချိန်နဲ့တပြေးညီ သင်္ချာလုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်စေပါလိမ့်မယ်။

![Visual Studio Code AI Toolkit extension မှ Calculator Agent interface ၏ အောက်ပိုင်း screenshot။ “Tools” နှင့် “Structure output” အတွက် ဖွင့်လို့ရတဲ့ မီနူးများ၊ “Choose output format” dropdown ကို “text” အဖြစ် သတ်မှတ်ထားသည်။ ညာဘက်တွင် “+ MCP Server” ခလုတ်ရှိပြီး Model Context Protocol server တစ်ခု ထည့်ရန် အသုံးပြုသည်။ Tools အပိုင်းအပေါ်တွင် ပုံတစ်ပုံ placeholder ပါရှိသည်။](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.my.png)

AI Toolkit မှ MCP server ကို လွယ်ကူစွာ ဖန်တီးနိုင်ရန် template များ ပါဝင်သည်။ ဒီမှာ Python template ကို အသုံးပြုပြီး calculator MCP server ကို ဖန်တီးပါမယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို လက်ရှိထောက်ပံ့ပေးထားသည်။

1. **Agent (Prompt) Builder** ၏ **Tools** အပိုင်းတွင် **+ MCP Server** ခလုတ်ကို နှိပ်ပါ။ Extension က **Command Palette** မှ setup wizard ကို စတင်ပါမည်။
2. **+ Add Server** ကို ရွေးချယ်ပါ။
3. **Create a New MCP Server** ကို ရွေးပါ။
4. **python-weather** template ကို ရွေးချယ်ပါ။
5. MCP server template ကို သိမ်းမည့် **Default folder** ကို ရွေးပါ။
6. Server အမည်အဖြစ် **Calculator** ဟု ရိုက်ထည့်ပါ။
7. Visual Studio Code ပြတင်းပေါက်အသစ် တစ်ခု ဖွင့်လိမ့်မည်။ **Yes, I trust the authors** ကို ရွေးပါ။
8. Terminal မှတဆင့် virtual environment တစ်ခု ဖန်တီးပါ- `python -m venv .venv`
9. Terminal မှ virtual environment ကို ဖွင့်ပါ-
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source venv/bin/activate`
10. Terminal မှ dependency များကို ထည့်သွင်းပါ- `pip install -e .[dev]`
11. **Activity Bar** ၏ **Explorer** မှ **src** ဖိုလ်ဒါကို ဖွင့်ပြီး **server.py** ဖိုင်ကို ရွေးပါ။
12. **server.py** ဖိုင်အတွင်းရှိ ကုဒ်ကို အောက်ပါအတိုင်း အစားထိုးပြီး သိမ်းပါ-

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

### -4- Calculator MCP server ဖြင့် agent ကို လည်ပတ်ခြင်း

Agent ကို ကိရိယာတွေနဲ့ ပြည့်စုံသွားပြီဆိုတော့၊ အခုကိရိယာတွေကို အသုံးပြုကြည့်ရအောင်! ဒီအပိုင်းမှာ agent ကို prompt ပေးပြီး calculator MCP server မှ ကိရိယာကို သုံးနိုင်မလား စမ်းသပ်ပါမယ်။

![Visual Studio Code AI Toolkit extension မှ Calculator Agent interface screenshot။ ဘယ်ဘက် panel ၏ “Tools” အောက်တွင် local-server-calculator_server MCP server တစ်ခု ထည့်ထားပြီး add, subtract, multiply, divide ကိရိယာလေးခု ပါဝင်သည်။ ကိရိယာလေးခုလုံး active ဖြစ်ကြောင်း badge ဖြင့် ပြထားသည်။ “Structure output” အပိုင်း collapsed ဖြစ်ပြီး အောက်တွင် အပြာရောင် “Run” ခလုတ်ရှိသည်။ ညာဘက် panel ၏ “Model Response” တွင် agent က multiply နှင့် subtract ကိရိယာများကို input {"a": 3, "b": 25} နှင့် {"a": 75, "b": 20} ဖြင့် ခေါ်ယူထားသည်။ နောက်ဆုံး “Tool Response” သည် 75.0 ဖြစ်သည်။ အောက်တွင် “View Code” ခလုတ်ပါရှိသည်။](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.my.png)

Agent Builder ကို MCP client အဖြစ် အသုံးပြုပြီး calculator MCP server ကို သင့် local development machine ပေါ်တွင် လည်ပတ်ပါမယ်။

1. `F5` ကို နှိပ်ပြီး MCP server ကို debugging mode ဖြင့် စတင်ပါ။ **Agent (Prompt) Builder** သည် editor tab အသစ်တစ်ခုတွင် ဖွင့်လှစ်မည်။ Server အခြေအနေကို terminal တွင် ကြည့်ရှုနိုင်ပါသည်။
2. **Agent (Prompt) Builder** ၏ **User prompt** အကွက်တွင် အောက်ပါ prompt ကို ရိုက်ထည့်ပါ- `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. **Run** ခလုတ်ကို နှိပ်ပြီး agent ၏ တုံ့ပြန်ချက်ကို ဖန်တီးပါ။
4. Agent ၏ output ကို ပြန်လည်သုံးသပ်ပါ။ မော်ဒယ်က သင် $55 ပေးချေခဲ့တယ်လို့ သတ်မှတ်သင့်ပါတယ်။
5. ဖြစ်ပေါ်သင့်တဲ့ လုပ်ဆောင်ချက်များကို အောက်ပါအတိုင်း ခွဲခြမ်းကြည့်ပါ-
    - Agent က **multiply** နဲ့ **subtract** ကိရိယာတွေကို သင်္ချာတွက်ချက်မှုအတွက် ရွေးချယ်သည်။
    - **multiply** ကိရိယာအတွက် `a` နဲ့ `b` တန်ဖိုးများ သတ်မှတ်သည်။
    - **subtract** ကိရိယာအတွက် `a` နဲ့ `b` တန်ဖိုးများ သတ်မှတ်သည်။
    - ကိရိယာတိုင်းမှ တုံ့ပြန်ချက်ကို **Tool Response** တွင် ပြသသည်။
    - မော်ဒယ်၏ နောက်ဆုံး output ကို **Model Response** တွင် ပြသသည်။
6. Agent ကို ပိုမိုစမ်းသပ်ရန် prompt အသစ်များ ထပ်ပေးနိုင်သည်။ **User prompt** အကွက်ကို နှိပ်ပြီး ရှိပြီးသား prompt ကို ပြောင်းလဲနိုင်သည်။
7. စမ်းသပ်မှု ပြီးဆုံးလျှင် terminal မှ **CTRL/CMD+C** ဖြင့် server ကို ရပ်တန့်နိုင်သည်။

## လုပ်ငန်းတာဝန်

**server.py** ဖိုင်ထဲတွင် ကိရိယာအသစ်

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။