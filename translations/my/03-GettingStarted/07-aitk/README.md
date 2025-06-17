<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-17T16:47:53+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "my"
}
-->
# Visual Studio Code အတွက် AI Toolkit extension မှာ server ကို အသုံးပြုခြင်း

AI agent တစ်ခု ဖန်တီးတဲ့အခါမှာ၊ အမြင်မကောင်းတဲ့ တုံ့ပြန်ချက်တွေ ထုတ်ဖော်ပေးတာသာမက၊ agent ကို လုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်စေဖို့လည်း အရေးကြီးပါတယ်။ ဒီမှာ Model Context Protocol (MCP) ရဲ့ အရေးပါမှု ဖြစ်ပေါ်လာပါတယ်။ MCP က agent တွေကို အပြင်က ကိရိယာနဲ့ ဝန်ဆောင်မှုတွေကို တစ်ကြောင်းတည်းနဲ့ အသုံးပြုနိုင်ဖို့ လွယ်ကူစေပါတယ်။ agent ကို တကယ့်အလုပ်လုပ်တဲ့ ကိရိယာဘူးထဲ ထည့်သွင်းထားသလို ထင်ရပါတယ်။

ဥပမာအားဖြင့် သင့် agent ကို calculator MCP server နဲ့ ချိတ်ဆက်လိုက်ပါစို့။ အဲ့ဒီအခါ agent က “47 ဆ 89 ဘယ်လောက်လဲ?” ဆိုတဲ့ မေးခွန်းတစ်ခု လက်ခံရရှိလိုက်တာနဲ့ သင့် agent က သင်္ချာ လုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်မှာဖြစ်ပြီး၊ လိုအပ်တဲ့ logic တွေကို အရင် coding လုပ်ထားစရာမလိုတော့ပဲ၊ API များ ဖန်တီးစရာမလိုတော့ပါဘူး။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ Visual Studio Code မှာ [AI Toolkit](https://aka.ms/AIToolkit) extension ကို အသုံးပြုပြီး calculator MCP server ကို agent နဲ့ ချိတ်ဆက်ခြင်း၊ agent ကို ပေါင်းခြင်း၊ ကိရိယာတွေကို သဘာဝဘာသာစကားဖြင့် အသုံးပြုနိုင်အောင် ပြုလုပ်ခြင်းတို့ကို လေ့လာပါမယ်။

AI Toolkit သည် Visual Studio Code အတွက် agent ဖန်တီးမှုကို လွယ်ကူစေတဲ့ အထောက်အကူပြု extension တစ်ခုဖြစ်ပြီး AI Engineer များအတွက် generative AI မော်ဒယ်များကို ဒေသခံ သို့မဟုတ် cloud မှာ တည်ဆောက်၊ စမ်းသပ်နိုင်စေပါတယ်။ ယနေ့မှာ ရရှိနိုင်တဲ့ generative မော်ဒယ်များအများစုကို ထောက်ပံ့ပေးပါတယ်။

*မှတ်ချက်* - AI Toolkit သည် လက်ရှိ Python နှင့် TypeScript ကို ထောက်ပံ့ပေးပါသည်။

## သင်ယူရမည့် ရည်ရွယ်ချက်များ

ဒီသင်ခန်းစာပြီးဆုံးသည့်အချိန်မှာ သင်သည် -

- AI Toolkit မှတဆင့် MCP server ကို အသုံးပြုနိုင်မည်။
- MCP server က ပေးသော ကိရိယာများကို ရှာဖွေ၊ အသုံးပြုနိုင်ရန် agent configuration ကို ပြင်ဆင်နိုင်မည်။
- သဘာဝဘာသာစကားဖြင့် MCP ကိရိယာများကို အသုံးပြုနိုင်မည်။

## နည်းလမ်း

အောက်ပါအတိုင်း အဆင့်မြင့်အဆင့်နဲ့ လုပ်ဆောင်ကြမယ် -

- Agent တစ်ခု ဖန်တီးပြီး system prompt ကို သတ်မှတ်ပါ။
- Calculator ကိရိယာပါ MCP server တစ်ခု ဖန်တီးပါ။
- Agent Builder ကို MCP server နဲ့ ချိတ်ဆက်ပါ။
- Agent ရဲ့ ကိရိယာအသုံးပြုမှုကို သဘာဝဘာသာစကားဖြင့် စမ်းသပ်ပါ။

အဆင့်တွေကို နားလည်သွားပြီဆိုရင် MCP မှတဆင့် အပြင်က ကိရိယာတွေကို အသုံးပြုနိုင်တဲ့ AI agent တစ်ခု ဖန်တီးဖို့ ပြင်ဆင်ကြပါစို့၊ agent ၏ စွမ်းဆောင်ရည်တွေ ပိုမိုကောင်းမွန်လာပါလိမ့်မယ်။

## လိုအပ်ချက်များ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## လေ့ကျင့်ခန်း - Server အသုံးပြုခြင်း

ဒီလေ့ကျင့်ခန်းမှာ Visual Studio Code အတွင်း AI Toolkit ကို အသုံးပြုပြီး MCP server ကိရိယာများဖြင့် AI agent ကို ဖန်တီး၊ ပြေးဆွဲ၊ တိုးတက်အောင် ပြုလုပ်ပါမယ်။

### -0- အစပိုင်း - My Models ထဲ OpenAI GPT-4o မော်ဒယ် ထည့်ပါ

ဒီလေ့ကျင့်ခန်းမှာ **GPT-4o** မော်ဒယ်ကို အသုံးပြုပါမယ်။ Agent ဖန်တီးမယ့်အရင်မှာ **My Models** ထဲ ထည့်ထားဖို့ လိုအပ်ပါတယ်။

![Visual Studio Code AI Toolkit extension မှ မော်ဒယ် ရွေးချယ်မှု မျက်နှာပြင်။ ခေါင်းစဉ်မှာ “Find the right model for your AI Solution” ဟု ဖော်ပြထားပြီး၊ “Popular Models” အောက်တွင် DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), DeepSeek-R1 (Ollama-hosted) စတဲ့ မော်ဒယ်များ ဖော်ပြထားသည်။](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.my.png)

1. **Activity Bar** မှ **AI Toolkit** extension ကို ဖွင့်ပါ။
2. **Catalog** အပိုင်းမှာ **Models** ကို ရွေးချယ်ပါ။ **Models** ကို ရွေးချယ်ခြင်းဖြင့် **Model Catalog** ကို အသစ်သော editor tab မှာ ဖွင့်ပါလိမ့်မယ်။
3. **Model Catalog** ရှာဖွေရေးဘားမှာ **OpenAI GPT-4o** ကို ရိုက်ထည့်ပါ။
4. **+ Add** ကိုနှိပ်ပြီး မော်ဒယ်ကို **My Models** ထဲ ထည့်ပါ။ GitHub မှ တင်ထားတဲ့ မော်ဒယ်ဖြစ်တာကို သေချာစစ်ဆေးပါ။
5. **Activity Bar** မှာ **OpenAI GPT-4o** မော်ဒယ်ကို စာရင်းထဲ တွေ့ရပါမယ်။

### -1- Agent ဖန်တီးခြင်း

**Agent (Prompt) Builder** သည် သင့်ကို AI စွမ်းရည်မြင့် agent များကို ဖန်တီး ပြင်ဆင်နိုင်စေသည်။ ဒီအပိုင်းမှာ agent အသစ်တစ်ခု ဖန်တီးပြီး စကားပြောဆိုမှုအတွက် မော်ဒယ် တစ်ခု ချိတ်ဆက်ပေးပါမယ်။

![AI Toolkit extension မှ Calculator Agent builder မျက်နှာပြင်။ ဘယ် panel မှာ OpenAI GPT-4o (via GitHub) မော်ဒယ်ရွေးထားပြီး၊ system prompt တွင် "You are a professor in university teaching math" ဟု ဖော်ပြထားသည်။ User prompt တွင် "Explain to me the Fourier equation in simple terms" ဟု ရေးထားသည်။ Tools ထည့်ရန်၊ MCP Server ဖွင့်ရန် နှင့် structured output ရွေးချယ်ရန် ခလုတ်များပါရှိသည်။ Run ခလုတ်ပြာတစ်ခု ရှိသည်။ ညာဘက် panel တွင် ဥပမာ agent သုံးခုဖော်ပြထားသည်။](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.my.png)

1. **Activity Bar** မှ **AI Toolkit** extension ကို ဖွင့်ပါ။
2. **Tools** အပိုင်းမှာ **Agent (Prompt) Builder** ကို ရွေးချယ်ပါ။ **Agent (Prompt) Builder** ကို ရွေးခြင်းဖြင့် အသစ်သော editor tab တစ်ခု ဖွင့်ပါလိမ့်မယ်။
3. **+ New Agent** ခလုတ်ကို နှိပ်ပါ။ Extension က **Command Palette** မှ setup wizard တစ်ခု ဖွင့်ပေးပါလိမ့်မယ်။
4. အမည်အဖြစ် **Calculator Agent** ဟု ရိုက်ထည့်ပြီး **Enter** နှိပ်ပါ။
5. **Agent (Prompt) Builder** မှာ **Model** ကွက်တွင် **OpenAI GPT-4o (via GitHub)** မော်ဒယ်ကို ရွေးချယ်ပါ။

### -2- Agent အတွက် system prompt ဖန်တီးခြင်း

Agent ကို ဖန်တီးပြီးနောက်၊ အဲ့ဒီ agent ရဲ့ သဘောထားနဲ့ ရည်ရွယ်ချက်ကို သတ်မှတ်ဖို့ အချိန်ရောက်ပါပြီ။ ဒီအပိုင်းမှာ **Generate system prompt** လုပ်ဆောင်ချက်ကို အသုံးပြုပြီး calculator agent အဖြစ် ရည်ရွယ်ချက်ဖော်ပြတဲ့ system prompt ကို မော်ဒယ်ကိုရေးပေးပါမယ်။

![AI Toolkit မှ Calculator Agent မျက်နှာပြင်၊ "Generate a prompt" စာမျက်နှာဖွင့်ထားသည်။ prompt template ကို အခြေခံအချက်အလက် များ ဖြည့်သွင်းခြင်းဖြင့် ဖန်တီးနိုင်ကြောင်း ဖော်ပြထားပြီး၊ စာသားတွင် "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." ဟု ရေးထားသည်။ "Close" နှင့် "Generate" ခလုတ်များ ပါရှိသည်။ background တွင် agent configuration အချို့မြင်ရသည်။](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.my.png)

1. **Prompts** အပိုင်းတွင် **Generate system prompt** ခလုတ်ကို နှိပ်ပါ။ AI ကို အသုံးပြု၍ system prompt ဖန်တီးပေးမည့် prompt builder ကို ဖွင့်ပါလိမ့်မယ်။
2. **Generate a prompt** ပြတင်းပေါ်တွင် အောက်ပါအတိုင်း ရိုက်ထည့်ပါ။ `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** ခလုတ်ကို နှိပ်ပါ။ အောက်ညာထောင့်မှာ system prompt ဖန်တီးနေကြောင်း အသိပေးချက် ပြပါလိမ့်မယ်။ ဖန်တီးပြီးနောက် **Agent (Prompt) Builder** ၏ **System prompt** ကွက်တွင် ပြသပါလိမ့်မယ်။
4. **System prompt** ကို ပြန်လည်ကြည့်ရှုပြီး လိုအပ်ပါက ပြင်ဆင်ပါ။

### -3- MCP server ဖန်တီးခြင်း

Agent ရဲ့ system prompt ကို သတ်မှတ်ပြီးနောက်၊ agent ကို အလုပ်လုပ်နိုင်စေရန် ကိရိယာတွေ ထည့်သွင်းဖို့ အချိန်ရောက်ပါပြီ။ ဒီအပိုင်းမှာ calculator MCP server တစ်ခု ဖန်တီးပြီး ပေါင်းခြင်း၊ ဖြုတ်ခြင်း၊ မြှောက်ခြင်း၊ နှိုင်းခြင်း လုပ်ဆောင်ချက်များ ပါရှိသည့် ကိရိယာများ ထည့်သွင်းပါမယ်။ ဒီ server က သဘာဝဘာသာစကား prompt များအတွက် အချိန်နောက်ကျမှုမရှိပဲ သင်္ချာ လုပ်ဆောင်ချက်တွေ ပြုလုပ်နိုင်စေပါလိမ့်မယ်။

![Calculator Agent interface ၏ အောက်ပိုင်း၊ Tools နှင့် Structure output အတွက် ချဲ့နိုင်သော မီနူးများ၊ "Choose output format" ဆိုတဲ့ dropdown menu တွင် "text" ရွေးထားသည်။ ညာဘက်တွင် "+ MCP Server" ခလုတ်ရှိပြီး Model Context Protocol server တစ်ခု ထည့်ရန်။ Tools အပိုင်းအပေါ်တွင် ပုံရိပ် အိုင်ကွန် ရှိသည်။](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.my.png)

AI Toolkit တွင် MCP server ကို လွယ်ကူစွာ ဖန်တီးနိုင်ရန် template များ ပါရှိသည်။ ဒီမှာ Python template ကို အသုံးပြုပြီး calculator MCP server ကို ဖန်တီးပါမယ်။

*မှတ်ချက်* - AI Toolkit သည် လက်ရှိ Python နှင့် TypeScript ကို ထောက်ပံ့ပေးသည်။

1. **Agent (Prompt) Builder** ၏ **Tools** အပိုင်းမှာ **+ MCP Server** ခလုတ်ကို နှိပ်ပါ။ Extension က **Command Palette** မှ setup wizard ဖွင့်ပေးပါလိမ့်မယ်။
2. **+ Add Server** ကို ရွေးချယ်ပါ။
3. **Create a New MCP Server** ကို ရွေးချယ်ပါ။
4. **python-weather** template ကို ရွေးချယ်ပါ။
5. MCP server template ကို သိမ်းမည့် **Default folder** ကို ရွေးချယ်ပါ။
6. Server အမည်အဖြစ် **Calculator** ဟု ရိုက်ထည့်ပါ။
7. Visual Studio Code ရဲ့ အသစ်သော ပြတင်းပေါ် တစ်ခု ဖွင့်ပါလိမ့်မယ်။ **Yes, I trust the authors** ကို ရွေးပါ။
8. Terminal မှာ virtual environment တစ်ခု ဖန်တီးပါ။ `python -m venv .venv`
9. Terminal မှာ virtual environment ကို ဖွင့်ပါ။
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Terminal မှာ လိုအပ်သော dependencies များ install လုပ်ပါ။ `pip install -e .[dev]`
11. **Activity Bar** မှ **Explorer** ကို ဖွင့်ပြီး **src** ဖိုလ်ဒါကို ချဲ့ပြီး **server.py** ဖိုင်ကို ရွေးပြီး editor မှာ ဖွင့်ပါ။
12. **server.py** ဖိုင် အတွင်းရှိ ကုဒ်ကို အောက်ပါအတိုင်း ပြောင်းလဲပြီး သိမ်းပါ။

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

### -4- calculator MCP server ဖြင့် agent ကို ပြေးဆွဲခြင်း

Agent ရဲ့ ကိရိယာတွေ ပြင်ဆင်ပြီးနောက်၊ အဲ့ဒီကိရိယာတွေကို အသုံးပြုကြည့်ဖို့ အချိန်ရောက်ပါပြီ။ ဒီအပိုင်းမှာ သင် agent ကို prompt တွေ ပေးပို့ပြီး calculator MCP server ကိရိယာကို သုံးပြီး စမ်းသပ်ပါမယ်။

![Calculator Agent interface ၏ ဘယ် panel မှာ “Tools” အောက်တွင် local-server-calculator_server MCP server ပါဝင်ပြီး add, subtract, multiply, divide ကိရိယာ ၄ ခုရှိသည်။ ကိရိယာ ၄ ခုလုံး လုပ်ဆောင်နေသည်။ “Structure output” အပိုင်းကို ဖွင့်ထားပြီး Run ခလုတ်ပြာတစ်ခု ရှိသည်။ ညာ panel မှာ “Model Response” တွင် multiply နှင့် subtract ကိရိယာများကို input {"a": 3, "b": 25} နှင့် {"a": 75, "b": 20} ဖြင့် ခေါ်ယူထားသည်။ နောက်ဆုံး “Tool Response” သည် 75.0 ဖြစ်သည်။ “View Code” ခလုတ် ရှိသည်။](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.my.png)

Agent Builder ကို MCP client အဖြစ် အသုံးပြု၍ calculator MCP server ကို သင့် local development machine ပေါ်တွင် ပြေးဆွဲပါမယ်။

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ဆိုတဲ့ တန်ဖိုးများကို **subtract** tool အတွက် သတ်မှတ်ပါ။
    - ကိရိယာတစ်ခုချင်းစီက ထုတ်ပေးတဲ့ တုံ့ပြန်ချက်ကို **Tool Response** မှာ မြင်ရပါမယ်။
    - မော်ဒယ်ရဲ့ နောက်ဆုံး ထုတ်လွှင့်ချက်ကို **Model Response** မှာ မြင်ရပါမယ်။
2. Agent ကို ပိုမိုစမ်းသပ်ရန် အပို prompt များ ပေးပို့နိုင်ပါသည်။ **User prompt** ကွက်ထဲမှာ ရှိပြီးသား prompt ကို ပြောင်းလဲနိုင်သည်။
3. စမ်းသပ်ပြီးဆုံးပါက **terminal** မှာ **CTRL/CMD+C** ကို နှိပ်၍ server ကို ရပ်တန့်နိုင်ပါသည်။

## တာဝန်ပေးခြင်း

သင့် **server.py** ဖိုင်ထဲတွင် ကိရိယာအသစ်တစ်ခု ထည့်သွင်းကြည့်ပါ (ဥပမာ - အရေအတွက်၏ square root ကို return ပြန်ပေးခြင်း)။ Agent ကို အသစ်ထည့်ထားသော tool ကို သုံးစွဲရန် လိုအပ်သော prompt များ ပေးပို့ပြီး စမ်းသပ်ပါ။ အသစ်ထည့်သော tool များကို ဖတ်ရန် server ကို ပြန်စတင်ရန် မမေ့ပါနှင့်။

## ဖြေရှင်းချက်

[Solution](./solution/README.md)

## အဓိက သင်ခန်းစာမှတ်ချက်များ

ဒီအခန်းမှ သင်ယူရမယ့် အချက်များမှာ -

- AI Toolkit extension သည် MCP Servers နှင့် ၎င်းတို့ရဲ့ ကိရိယာများကို အသုံးပြုနိုင်သော client အကောင်းဆုံးဖြစ်သည်။
- MCP servers တွင် ကိရိယာအသစ်များ ထပ်မံ ထည့်သွင်းနိုင်ပြီး agent ၏ စွမ်းရည်များကို တိုးချဲ့နိုင်သည်။
- AI Toolkit တွင် (ဥပမာ - Python MCP server templates) ကိရိယာအသစ် ဖန်တီးရာတွင် အကူအညီဖြစ်စေသော template များ ပါဝင်သည်။

## အပိုဆောင်း အရင်းအမြစ်များ

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့် - [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**အကြောင်းကြားချက်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ခြင်းဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက်ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာရွက်စာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် အတတ်ပညာရှင် လူသားဘာသာပြန်သူများမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှားယွင်းမှုများ သို့မဟုတ် အဓိပ္ပါယ်မှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မရှိပါ။