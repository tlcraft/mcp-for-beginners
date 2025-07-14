<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:43:19+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "my"
}
-->
# Visual Studio Code အတွက် AI Toolkit extension မှ server ကို အသုံးပြုခြင်း

AI agent တစ်ခု တည်ဆောက်တဲ့အခါမှာ၊ ဉာဏ်ကြီးတဲ့ တုံ့ပြန်ချက်တွေ ဖန်တီးပေးတာသာမက၊ agent ကို လုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်စေဖို့လည်း အရေးကြီးပါတယ်။ ဒီမှာ Model Context Protocol (MCP) က အရေးပါပါတယ်။ MCP က agent တွေကို အပြင် tools နဲ့ services တွေကို တစ်မျိုးတည်းနည်းလမ်းနဲ့ လွယ်ကူစွာ အသုံးပြုနိုင်စေပါတယ်။ agent ကို အသုံးချနိုင်တဲ့ ကိရိယာသေတ္တာတစ်ခုထဲ ထည့်သွင်းထားတာလို ထင်နိုင်ပါတယ်။

ဥပမာ Agent ကို calculator MCP server နဲ့ ချိတ်ဆက်လိုက်ရင်၊ “47 ကို 89 နဲ့မြှောက်ရင် ဘယ်လောက်လဲ?” ဆိုတဲ့ prompt တစ်ခု လက်ခံရုံနဲ့ သင့် agent က သင်္ချာတွက်ချက်မှုတွေ ပြုလုပ်နိုင်မှာဖြစ်ပြီး၊ logic ကို hardcode လုပ်ဖို့ သို့မဟုတ် custom API များ တည်ဆောက်ဖို့ မလိုတော့ပါဘူး။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ Visual Studio Code ရဲ့ [AI Toolkit](https://aka.ms/AIToolkit) extension ကို အသုံးပြုပြီး calculator MCP server ကို agent နဲ့ ချိတ်ဆက်ခြင်းနဲ့၊ agent ကို ပေါင်းခြား၊ ဖြုတ်ခြား၊ မြှောက်ခြား၊ နှုတ်ခြား စသည့် သင်္ချာလုပ်ဆောင်ချက်များကို သဘာဝဘာသာစကားဖြင့် ပြုလုပ်နိုင်အောင် လုပ်နည်းကို ဖော်ပြထားပါတယ်။

AI Toolkit က Visual Studio Code အတွက် agent ဖန်တီးမှုကို လွယ်ကူစေတဲ့ အင်အားကြီး extension တစ်ခုဖြစ်ပြီး၊ AI Engineers တွေကို local သို့မဟုတ် cloud ပေါ်မှာ generative AI မော်ဒယ်တွေ ဖန်တီး၊ စမ်းသပ်နိုင်စေပါတယ်။ ယနေ့မှာ ရရှိနိုင်တဲ့ အဓိက generative မော်ဒယ်အများစုကို ထောက်ပံ့ပေးပါတယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို လက်ရှိ ထောက်ပံ့ပေးထားပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးတဲ့အချိန်မှာ သင်မှာ အောက်ပါအရာများ ပြုလုပ်နိုင်ပါလိမ့်မယ်-

- AI Toolkit မှတဆင့် MCP server ကို အသုံးပြုနိုင်ခြင်း။
- MCP server က ပေးတဲ့ tools တွေကို ရှာဖွေ အသုံးပြုနိုင်အောင် agent configuration ကို ပြင်ဆင်နိုင်ခြင်း။
- သဘာဝဘာသာစကားဖြင့် MCP tools များကို အသုံးပြုနိုင်ခြင်း။

## လုပ်ဆောင်ရန် နည်းလမ်း

အထက်တန်းအဆင့်မှာ ဒီလို လုပ်ဆောင်ရမှာဖြစ်ပါတယ်-

- Agent တစ်ခု ဖန်တီးပြီး system prompt ကို သတ်မှတ်ပါ။
- Calculator tools ပါတဲ့ MCP server တစ်ခု ဖန်တီးပါ။
- Agent Builder ကို MCP server နဲ့ ချိတ်ဆက်ပါ။
- သဘာဝဘာသာစကားဖြင့် agent ရဲ့ tool အသုံးပြုမှုကို စမ်းသပ်ပါ။

အိုကေ၊ လမ်းကြောင်းကို နားလည်သွားပြီဆိုတော့ MCP မှတဆင့် အပြင်ကိရိယာတွေကို အသုံးပြုနိုင်အောင် AI agent ကို ပြင်ဆင်ကြရအောင်၊ agent ရဲ့ စွမ်းဆောင်ရည်တွေ တိုးတက်စေဖို့ပါ။

## လိုအပ်ချက်များ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## လေ့ကျင့်ခန်း: Server ကို အသုံးပြုခြင်း

ဒီလေ့ကျင့်ခန်းမှာ Visual Studio Code ထဲမှာ AI Toolkit ကို အသုံးပြုပြီး MCP server က tools တွေနဲ့ AI agent တစ်ခုကို ဖန်တီး၊ ပြေးဆွဲ၊ တိုးတက်အောင်လုပ်ပါမယ်။

### -0- အစပိုင်း - OpenAI GPT-4o မော်ဒယ်ကို My Models ထဲ ထည့်ပါ

ဒီလေ့ကျင့်ခန်းမှာ **GPT-4o** မော်ဒယ်ကို အသုံးပြုမှာဖြစ်ပြီး၊ agent ဖန်တီးမယ့်အရင်မှာ **My Models** ထဲ ထည့်ထားဖို့ လိုအပ်ပါတယ်။

![Visual Studio Code ရဲ့ AI Toolkit extension မှ မော်ဒယ်ရွေးချယ်မှု အင်တာဖေ့စ် screenshot။ ခေါင်းစဉ်မှာ "Find the right model for your AI Solution" လို့ရေးထားပြီး၊ subtitle မှာ AI မော်ဒယ်တွေ ရှာဖွေ၊ စမ်းသပ်၊ တပ်ဆင်ဖို့ အကြံပြုထားပါတယ်။ “Popular Models” အောက်မှာ DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), DeepSeek-R1 (Ollama-hosted) စတဲ့ မော်ဒယ်ကတ် ၆ ခု ပြထားပြီး၊ “Add” နဲ့ “Try in Playground” ခလုတ်တွေ ပါပါတယ်။](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.my.png)

1. **Activity Bar** မှာ **AI Toolkit** extension ကို ဖွင့်ပါ။
1. **Catalog** အပိုင်းမှာ **Models** ကို ရွေးပြီး **Model Catalog** ကို ဖွင့်ပါ။ Models ကို ရွေးလိုက်ရင် **Model Catalog** ကို editor tab အသစ်တစ်ခုမှာ ဖွင့်ပေးပါလိမ့်မယ်။
1. **Model Catalog** ရှာဖွေမှုဘားမှာ **OpenAI GPT-4o** ဟု ရိုက်ထည့်ပါ။
1. **+ Add** ကို နှိပ်ပြီး မော်ဒယ်ကို **My Models** စာရင်းထဲ ထည့်ပါ။ GitHub မှာ host လုပ်ထားတဲ့ မော်ဒယ်ကို ရွေးထားကြောင်း သေချာစေပါ။
1. **Activity Bar** မှာ **OpenAI GPT-4o** မော်ဒယ်ကို စာရင်းထဲ တွေ့ရမယ်။

### -1- Agent တစ်ခု ဖန်တီးပါ

**Agent (Prompt) Builder** က သင့်ကို ကိုယ်ပိုင် AI agent တွေ ဖန်တီး၊ စိတ်ကြိုက်ပြင်ဆင်နိုင်စေပါတယ်။ ဒီအပိုင်းမှာ agent အသစ်တစ်ခု ဖန်တီးပြီး စကားပြောမှုအတွက် မော်ဒယ်တစ်ခု သတ်မှတ်ပါမယ်။

![Visual Studio Code အတွက် AI Toolkit extension မှ "Calculator Agent" builder အင်တာဖေ့စ် screenshot။ ဘယ်ဘက် panel မှာ "OpenAI GPT-4o (via GitHub)" မော်ဒယ် ရွေးထားပြီး၊ system prompt မှာ "You are a professor in university teaching math" လို့ရေးထားပါတယ်။ user prompt မှာ "Explain to me the Fourier equation in simple terms." လို့ရေးထားပြီး၊ tools ထည့်ခြင်း၊ MCP Server ဖွင့်ခြင်း၊ structured output ရွေးချယ်ခြင်း ခလုတ်တွေ ပါပါတယ်။ အောက်ဘက်မှာ အပြာရောင် “Run” ခလုတ်ရှိပါတယ်။ ညာဘက် panel မှာ "Get Started with Examples" အောက်မှာ Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter) စတဲ့ sample agents ၃ ခု ဖော်ပြထားပါတယ်။](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.my.png)

1. **Activity Bar** မှာ **AI Toolkit** extension ကို ဖွင့်ပါ။
1. **Tools** အပိုင်းမှာ **Agent (Prompt) Builder** ကို ရွေးပါ။ Agent (Prompt) Builder ကို editor tab အသစ်တစ်ခုမှာ ဖွင့်ပေးပါလိမ့်မယ်။
1. **+ New Agent** ခလုတ်ကို နှိပ်ပါ။ extension က **Command Palette** မှတဆင့် setup wizard ကို စတင်ပါလိမ့်မယ်။
1. အမည်အဖြစ် **Calculator Agent** ဟု ရိုက်ထည့်ပြီး **Enter** နှိပ်ပါ။
1. **Agent (Prompt) Builder** မှာ **Model** အကွက်တွင် **OpenAI GPT-4o (via GitHub)** မော်ဒယ်ကို ရွေးပါ။

### -2- Agent အတွက် system prompt တစ်ခု ဖန်တီးပါ

Agent ကို ဖန်တီးပြီးနောက်၊ ၎င်းရဲ့ ကိုယ်ရည်ကိုယ်သွေးနဲ့ ရည်ရွယ်ချက်ကို သတ်မှတ်ဖို့ အချိန်ရောက်ပါပြီ။ ဒီအပိုင်းမှာ **Generate system prompt** လုပ်ဆောင်ချက်ကို အသုံးပြုပြီး calculator agent အဖြစ် agent ရဲ့ အပြုအမူကို ဖော်ပြတဲ့ system prompt ကို မော်ဒယ်ကို ရေးပေးပါမယ်။

![Visual Studio Code အတွက် AI Toolkit မှ "Calculator Agent" အင်တာဖေ့စ် screenshot။ "Generate a prompt" ခေါင်းစဉ်နဲ့ modal ပြတင်းပေါက်တစ်ခု ဖွင့်ထားပြီး၊ prompt template ကို အခြေခံအချက်အလက်များ ဖြင့် ဖန်တီးနိုင်ကြောင်း ရှင်းပြထားပါတယ်။ စာသားအကွက်ထဲမှာ "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." ဆိုတဲ့ စနစ် prompt နမူနာ ရေးထားပါတယ်။ အောက်မှာ "Close" နဲ့ "Generate" ခလုတ်တွေ ပါပါတယ်။ နောက်ခံမှာ agent configuration အချို့၊ ရွေးထားတဲ့ မော်ဒယ် "OpenAI GPT-4o (via GitHub)" နဲ့ system, user prompt အကွက်တွေ မြင်ရပါတယ်။](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.my.png)

1. **Prompts** အပိုင်းမှာ **Generate system prompt** ခလုတ်ကို နှိပ်ပါ။ ဒီခလုတ်က AI ကို အသုံးပြုပြီး system prompt ကို ဖန်တီးပေးမယ့် prompt builder ကို ဖွင့်ပေးပါလိမ့်မယ်။
1. **Generate a prompt** ပြတင်းပေါက်ထဲမှာ အောက်ပါစာသားကို ရိုက်ထည့်ပါ-  
   `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** ခလုတ်ကို နှိပ်ပါ။ စနစ် prompt ဖန်တီးနေကြောင်း အောက်ညာဘက်မှာ အသိပေးချက် တက်လာပါလိမ့်မယ်။ ဖန်တီးမှု ပြီးဆုံးသွားရင် **Agent (Prompt) Builder** ရဲ့ **System prompt** အကွက်ထဲမှာ prompt ကို မြင်ရပါလိမ့်မယ်။
1. **System prompt** ကို ပြန်လည်သုံးသပ်ပြီး လိုအပ်သလို ပြင်ဆင်ပါ။

### -3- MCP server တစ်ခု ဖန်တီးပါ

Agent ရဲ့ system prompt ကို သတ်မှတ်ပြီးနောက်၊ agent ကို လက်တွေ့ အသုံးချနိုင်စေဖို့ စွမ်းရည်တွေ ထည့်သွင်းဖို့ အချိန်ရောက်ပါပြီ။ ဒီအပိုင်းမှာ ပေါင်းခြား၊ ဖြုတ်ခြား၊ မြှောက်ခြား၊ နှုတ်ခြား စသည့် သင်္ချာလုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်တဲ့ calculator MCP server တစ်ခု ဖန်တီးပါမယ်။ ဒီ server က agent ကို သဘာဝဘာသာစကား prompt တွေကို တုံ့ပြန်ပြီး သင်္ချာတွက်ချက်မှုတွေ ပြုလုပ်နိုင်စေပါလိမ့်မယ်။

![Visual Studio Code အတွက် AI Toolkit extension မှ Calculator Agent interface ၏ အောက်ပိုင်း screenshot။ “Tools” နဲ့ “Structure output” အတွက် ဖွင့်လှစ်နိုင်တဲ့ မီနူးများ၊ “Choose output format” dropdown မှာ “text” ရွေးထားပြီး၊ “+ MCP Server” ခလုတ်တစ်ခု ရှိပါတယ်။ Tools အပိုင်းအပေါ်မှာ ပုံတစ်ပုံ icon placeholder ပါရှိသည်။](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.my.png)

AI Toolkit မှာ MCP server ကို လွယ်ကူစွာ ဖန်တီးနိုင်ဖို့ template များ ပါဝင်ပါတယ်။ ဒီမှာ Python template ကို အသုံးပြုပြီး calculator MCP server ကို ဖန်တီးပါမယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို လက်ရှိ ထောက်ပံ့ပေးထားပါတယ်။

1. **Agent (Prompt) Builder** ရဲ့ **Tools** အပိုင်းမှာ **+ MCP Server** ခလုတ်ကို နှိပ်ပါ။ extension က **Command Palette** မှတဆင့် setup wizard ကို စတင်ပါလိမ့်မယ်။
1. **+ Add Server** ကို ရွေးပါ။
1. **Create a New MCP Server** ကို ရွေးပါ။
1. **python-weather** template ကို ရွေးပါ။
1. MCP server template ကို သိမ်းမယ့် **Default folder** ကို ရွေးပါ။
1. Server အမည်အဖြစ် **Calculator** ဟု ရိုက်ထည့်ပါ။
1. Visual Studio Code မှာ ပြီးတော့ window အသစ်တစ်ခု ဖွင့်ပါလိမ့်မယ်။ **Yes, I trust the authors** ကို ရွေးပါ။
1. Terminal မှာ virtual environment တစ်ခု ဖန်တီးပါ- `python -m venv .venv`
1. Terminal မှာ virtual environment ကို ဖွင့်ပါ-  
    - Windows - `.venv\Scripts\activate`  
    - macOS/Linux - `source venv/bin/activate`
1. Terminal မှာ လိုအပ်တဲ့ dependencies များကို ထည့်သွင်းပါ- `pip install -e .[dev]`
1. **Activity Bar** ရဲ့ **Explorer** မှာ **src** ဖိုလ်ဒါကို ဖွင့်ပြီး **server.py** ဖိုင်ကို ရွေးပါ။
1. **server.py** ဖိုင်ထဲက code ကို အောက်ပါအတိုင်း ပြောင်းပြီး သိမ်းပါ-

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

### -4- Calculator MCP server နဲ့ agent ကို ပြေးပါ

Agent ရဲ့ tools တွေ ပြီးသွားပြီဆိုတော့ အခု tools တွေကို အသုံးပြုကြည့်ရအောင်! ဒီအပိုင်းမှာ agent ကို prompt တွေ ပေးပြီး calculator MCP server က tool ကို သုံးပြီး တုံ့ပြန်မှုကို စမ်းသပ်ပါမယ်။

![Visual Studio Code အတွက် AI Toolkit extension မှ Calculator Agent interface screenshot။ ဘယ်ဘက် panel မှာ “Tools” အောက်မှာ local-server-calculator_server MCP server တစ်ခု ထည့်ထားပြီး၊ add, subtract, multiply, divide ဆိုတဲ့ tools ၄ ခု ရှိပါတယ်။ ၄ tools လုံး active ဖြစ်နေကြောင်း badge တစ်ခု ပြထားပါတယ်။ “Structure output” အပိုင်း collapsed ဖြစ်ပြီး အပြာရောင် “Run” ခလုတ်ရှိပါတယ်။ ညာဘက် panel မှာ “Model Response” အောက်မှာ agent က multiply နဲ့ subtract tools ကို input {"a": 3, "b": 25} နဲ့ {"a": 75, "b": 20} ဖြင့် ခေါ်ယူထားပြီး၊ နောက်ဆုံး “Tool Response” မှာ 75.0 ပြထားပါတယ်။ အောက်မှာ “View Code” ခလုတ်ပါရှိသည်။](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.my.png)

Agent Builder ကို MCP client အဖြစ် အသုံးပြုပြီး သင့် local development machine ပေါ်မှာ calculator MCP server ကို ပြေးပါ။

1. `F5` ကို နှိပ်ပြီး MCP server ကို debugging mode ဖြင့် စတင်ပါ။ **Agent (Prompt) Builder** ကို editor tab အသစ်တစ်ခုမှာ ဖွင့်ပေးပါလိမ့်မယ်။ Terminal မှာ server အခြေအနေကို ကြည့်ရှုနိုင်ပါသည်။
1. **Agent (Prompt) Builder** ရဲ့ **User prompt** အကွက်ထဲမှာ အောက်ပါ prompt ကို ရိုက်ထည့်ပါ-  
   `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. **Run** ခလုတ်ကို နှိပ်ပြီး agent ရဲ့ တုံ့ပြန်ချက်ကို ဖန်တီးပါ။
1. Agent ရဲ့ output ကို ပြန်လည်သုံးသပ်ပါ။ မော်ဒယ်က သင် $55 ပေးချေခဲ့တယ်လို့ သတ်မှတ်သင့်ပါတယ်။
1. ဖြစ်ပေါ်သင့်တဲ့ အဆင့်ဆင့်ကို အောက်ပါအတိုင်း ရှင်းပြပါမယ်-  
    - Agent က **multiply** နဲ့ **subtract** tools ကို သင်္ချာတွက်ချက်မှုအတွက် ရွေးချယ်သည်။  
    - **multiply** tool အတွက် `a` နဲ့ `b` တန်ဖိုးများ သတ်မှတ်သည်။  
    - **subtract** tool အတွက် `a` နဲ့ `b` တန်ဖိုးများ သတ်မှတ်သည်။  
    - တစ်ခုချင်း tool response များကို **Tool Response** အကွက်ထဲမှာ ပြန်လည်ပေးသည်။  
    - မော်ဒယ်ရဲ့ နောက်ဆုံး output ကို **Model Response** အကွက်ထဲမှာ ပြသသည်။
1. Agent ကို ပိုမိုစမ်းသပ်ဖို့ prompt အသစ်များ ထပ်ပေးနိုင်သည်။ **User prompt** အကွက်ကို နှိပ်ပြီး ရှိပြီးသား prompt ကို ပြောင်းလဲနိုင်သည်။
1. စမ်းသပ်မှု ပြီးဆုံးသွားရင် terminal မှာ **CTRL/CMD+C** ကို နှိပ်ပြီး server ကို ရပ်တန့်နိုင်သည်။

## အလုပ်အပ်

**server.py** ဖိုင်ထဲမှာ tool အသစ်တစ်ခု ထပ်ထည့်ကြည့်ပါ (ဥပမာ- နံပါတ်တစ်ခုရဲ့ စတုရန်းမြစ်ကို ပြန်ပေးတဲ့ tool)။ Agent ကို အသုံးပြုဖို့ prompt အသစ်များ ပေးပြီး စမ်းသပ်ပါ။ အသစ်ထည့်ထားတဲ့ tool တွေကို အသုံးပြုဖို့ server ကို ပြန်စ

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းသည် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။