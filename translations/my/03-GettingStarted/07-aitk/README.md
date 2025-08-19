<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98bcd044860716da5819e31c152813b7",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:33:21+00:00",
=======
  "translation_date": "2025-08-18T18:55:11+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "my"
}
-->
# Visual Studio Code အတွက် AI Toolkit Extension မှ Server ကို အသုံးပြုခြင်း

<<<<<<< HEAD
AI Agent တစ်ခုကို တည်ဆောက်တဲ့အခါမှာ၊ ရှင်းလင်းတဲ့ အဖြေတွေကို ဖန်တီးပေးရုံသာမက၊ Agent ကို လုပ်ဆောင်နိုင်စွမ်းပေးဖို့လည်း အရေးကြီးပါတယ်။ Model Context Protocol (MCP) က ဒီအပိုင်းမှာ အရေးပါပါတယ်။ MCP က Agent တွေကို အပြင်ဘက် Tools နဲ့ Services တွေကို တစ်စည်းတစ်လုံးနဲ့ အဆင်ပြေပြေ အသုံးပြုနိုင်အောင် လုပ်ပေးပါတယ်။ ဒါကို Agent ကို တကယ်အသုံးပြုနိုင်တဲ့ Toolbox တစ်ခုနဲ့ ချိတ်ဆက်ပေးတာလိုမျိုး စဉ်းစားနိုင်ပါတယ်။

ဥပမာအားဖြင့် Calculator MCP Server ကို Agent နဲ့ ချိတ်ဆက်လိုက်မယ်ဆိုရင်၊ Agent က “47 ကို 89 နဲ့ မကြိမ်ဘူးလား?” ဆိုတဲ့ Prompt ရရှိတာနဲ့ တန်း Math Operations တွေကို လုပ်ဆောင်နိုင်ပါပြီ။ Logic တွေကို Hardcode လုပ်ရတာမလိုတော့ဘဲ၊ Custom APIs တွေကို တည်ဆောက်ရတာလည်း မလိုတော့ပါဘူး။

## အကျဉ်းချုပ်

ဒီသင်ခန်းစာမှာ Calculator MCP Server ကို Visual Studio Code ရဲ့ [AI Toolkit](https://aka.ms/AIToolkit) Extension နဲ့ Agent တစ်ခုနဲ့ ချိတ်ဆက်ပေးပြီး၊ Natural Language ကို အသုံးပြုကာ အပေါင်း၊ အနုတ်၊ အကြိမ်၊ အခွဲ စတဲ့ Math Operations တွေကို လုပ်ဆောင်နိုင်အောင် လုပ်ပေးမယ့် နည်းလမ်းကို လေ့လာပါမယ်။

AI Toolkit က Agent Development ကို အလွယ်ကူဆုံးလုပ်ဆောင်ပေးတဲ့ Visual Studio Code Extension တစ်ခုဖြစ်ပြီး၊ Generative AI Models တွေကို Local မှာဖြစ်စေ၊ Cloud မှာဖြစ်စေ တည်ဆောက်ပြီး စမ်းသပ်နိုင်ပါတယ်။ ဒီ Extension က ယနေ့မှာ ရရှိနိုင်တဲ့ Generative Models အများစုကို Support လုပ်ပေးပါတယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို လက်ရှိ Support လုပ်ပေးပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးမှာ သင်တတ်မြောက်ထားမည့်အရာများမှာ:
=======
AI Agent တစ်ခုကို တည်ဆောက်တဲ့အခါမှာ၊ ရှင်းလင်းတဲ့ အဖြေတွေကို ဖန်တီးပေးရုံသာမက၊ Agent ကို လုပ်ဆောင်နိုင်စွမ်းပေးဖို့လည်း အရေးကြီးပါတယ်။ Model Context Protocol (MCP) က ဒီအပိုင်းမှာ အရေးပါပါတယ်။ MCP က Agent တွေကို အပြင်ဘက် Tools နဲ့ Services တွေကို တစ်စည်းတစ်လုံးနဲ့ အဆင်ပြေပြေ အသုံးပြုနိုင်အောင် လုပ်ပေးပါတယ်။ ဒါကို Agent ကို အသုံးပြုနိုင်တဲ့ Toolbox တစ်ခုနဲ့ ချိတ်ဆက်ပေးတာလိုပဲ စဉ်းစားနိုင်ပါတယ်။

ဥပမာအားဖြင့် Calculator MCP Server ကို Agent နဲ့ ချိတ်ဆက်လိုက်မယ်ဆိုရင်၊ Agent က “47 ကို 89 နဲ့ မကြိမ်ဘူးလား?” ဆိုတဲ့ Prompt ရရှိတာနဲ့ တန်း Math Operations တွေကို လုပ်ဆောင်နိုင်ပါပြီ။ Logic တွေကို Hardcode လုပ်ရတာမလိုတော့ဘဲ၊ Custom APIs တွေ တည်ဆောက်ရတာလည်း မလိုတော့ပါဘူး။

## အကျဉ်းချုပ်

ဒီသင်ခန်းစာမှာ Calculator MCP Server ကို Visual Studio Code ရဲ့ [AI Toolkit](https://aka.ms/AIToolkit) Extension နဲ့ Agent နဲ့ ချိတ်ဆက်ပေးပြီး၊ Natural Language ကို အသုံးပြုကာ အပေါင်း၊ အနုတ်၊ အမြှောက်၊ အခွဲ စတဲ့ Math Operations တွေကို လုပ်ဆောင်နိုင်အောင် လေ့လာပါမယ်။

AI Toolkit က Visual Studio Code အတွက် အင်အားကြီးတဲ့ Extension တစ်ခုဖြစ်ပြီး Agent Development ကို အလွယ်ကူဆုံးဖြစ်အောင် လုပ်ဆောင်ပေးပါတယ်။ AI Engineers တွေက Generative AI Models တွေကို Cloud မှာဖြစ်စေ၊ Local မှာဖြစ်စေ တည်ဆောက်ပြီး စမ်းသပ်နိုင်ပါတယ်။ ဒီ Extension က ယနေ့မှာ ရရှိနိုင်တဲ့ Generative Models အများစုကို ပံ့ပိုးပေးပါတယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို ပံ့ပိုးပေးပါတယ်။

## သင်ယူရမည့် ရည်ရွယ်ချက်များ

ဒီသင်ခန်းစာအဆုံးမှာ သင်တတ်မြောက်မည့်အရာများမှာ:
>>>>>>> origin/main

- AI Toolkit ကို အသုံးပြုကာ MCP Server ကို အသုံးချနိုင်ခြင်း။
- MCP Server မှ Tools တွေကို ရှာဖွေပြီး အသုံးပြုနိုင်အောင် Agent Configuration ကို ပြင်ဆင်နိုင်ခြင်း။
- Natural Language ကို အသုံးပြုကာ MCP Tools တွေကို အသုံးချနိုင်ခြင်း။

## လုပ်ဆောင်ရန် နည်းလမ်း

အထွေထွေ အဆင့်မြင့်နည်းလမ်းအနေနဲ့ အောက်ပါအတိုင်း လုပ်ဆောင်ရပါမယ်:

- Agent တစ်ခုကို ဖန်တီးပြီး System Prompt ကို သတ်မှတ်ပါ။
- Calculator Tools တွေပါဝင်တဲ့ MCP Server တစ်ခုကို ဖန်တီးပါ။
- Agent Builder ကို MCP Server နဲ့ ချိတ်ဆက်ပါ။
- Natural Language ကို အသုံးပြုကာ Agent ရဲ့ Tool Invocation ကို စမ်းသပ်ပါ။

<<<<<<< HEAD
အဆင့်တွေကို နားလည်ပြီးရင်၊ MCP ကို အသုံးပြုကာ Agent ရဲ့ လုပ်ဆောင်နိုင်စွမ်းတွေကို တိုးမြှင့်ပေးဖို့ Configuration လုပ်ဆောင်ရအောင်!
=======
အဆင့်တွေကို နားလည်ပြီးရင်၊ MCP ကို အသုံးပြုကာ Agent ရဲ့ စွမ်းရည်တွေကို တိုးမြှင့်ပေးနိုင်အောင် Configure လုပ်ရအောင်!
>>>>>>> origin/main

## ကြိုတင်လိုအပ်ချက်များ

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code အတွက် AI Toolkit](https://aka.ms/AIToolkit)

## လေ့ကျင့်ခန်း: Server ကို အသုံးပြုခြင်း

> [!WARNING]
<<<<<<< HEAD
> macOS အသုံးပြုသူများအတွက် သတိပေးချက်။ Dependency Installation ကို ထိခိုက်စေတဲ့ ပြဿနာတစ်ခုကို လက်ရှိ စုံစမ်းနေပါတယ်။ ဒီအကြောင်းကြောင့် macOS အသုံးပြုသူများသည် ဒီ Tutorial ကို လက်ရှိအချိန်မှာ ပြီးမြောက်စွာ လုပ်ဆောင်နိုင်မှာ မဟုတ်ပါဘူး။ ပြဿနာကို ဖြေရှင်းပြီး Instruction တွေကို Update လုပ်ပေးပါမယ်။ သင့်ရဲ့ သည်းခံမှုနဲ့ နားလည်မှုအတွက် ကျေးဇူးတင်ပါတယ်။
=======
> macOS အသုံးပြုသူများအတွက် မှတ်ချက်။ Dependency Installation ကို ထိခိုက်စေတဲ့ ပြဿနာတစ်ခုကို လေ့လာနေဆဲဖြစ်ပါတယ်။ အဲ့ဒီအကြောင်းကြောင့် macOS အသုံးပြုသူများ ဒီ Tutorial ကို လက်ရှိအချိန်မှာ ပြီးမြောက်စွာ လုပ်ဆောင်နိုင်မှာ မဟုတ်ပါဘူး။ ပြဿနာကို ဖြေရှင်းပြီး Instruction တွေကို Update လုပ်ပေးပါမယ်။ သင့်ရဲ့ သည်းခံမှုနဲ့ နားလည်မှုအတွက် ကျေးဇူးတင်ပါတယ်။
>>>>>>> origin/main

ဒီလေ့ကျင့်ခန်းမှာ သင် AI Agent တစ်ခုကို MCP Server မှ Tools တွေကို အသုံးပြုကာ Visual Studio Code ရဲ့ AI Toolkit မှာ Build, Run, နဲ့ Enhance လုပ်ပါမယ်။

### -0- Prestep, OpenAI GPT-4o Model ကို My Models မှာ ထည့်ပါ

ဒီလေ့ကျင့်ခန်းမှာ **GPT-4o** Model ကို အသုံးပြုပါမယ်။ Agent ကို ဖန်တီးမီ Model ကို **My Models** မှာ ထည့်ထားရပါမယ်။

1. **AI Toolkit** Extension ကို **Activity Bar** မှာ ဖွင့်ပါ။
1. **Catalog** အပိုင်းမှာ **Models** ကို ရွေးပြီး **Model Catalog** ကို ဖွင့်ပါ။
1. **Model Catalog** ရဲ့ Search Bar မှာ **OpenAI GPT-4o** ကို ရိုက်ထည့်ပါ။
1. **+ Add** ကို နှိပ်ပြီး Model ကို **My Models** List မှာ ထည့်ပါ။ **Hosted by GitHub** Model ကို ရွေးထားတာကို သေချာပါစေ။
1. **Activity Bar** မှာ **OpenAI GPT-4o** Model ရှိနေတဲ့အရာကို အတည်ပြုပါ။

### -1- Agent တစ်ခုကို ဖန်တီးပါ

<<<<<<< HEAD
**Agent (Prompt) Builder** က သင့်ကို AI-powered Agent ကို ဖန်တီးပြီး Customize လုပ်နိုင်စေပါတယ်။ ဒီအပိုင်းမှာ သင် Agent တစ်ခုကို ဖန်တီးပြီး Model ကို Conversation ကို အားပေးဖို့ Assign လုပ်ပါမယ်။
=======
**Agent (Prompt) Builder** က သင့်ကို AI-powered Agent တွေကို ဖန်တီးပြီး Customize လုပ်နိုင်အောင် လုပ်ပေးပါတယ်။ ဒီအပိုင်းမှာ သင် Agent တစ်ခုကို ဖန်တီးပြီး Model ကို Conversation ကို အားပေးဖို့ Assign လုပ်ပါမယ်။
>>>>>>> origin/main

1. **AI Toolkit** Extension ကို **Activity Bar** မှာ ဖွင့်ပါ။
1. **Tools** အပိုင်းမှာ **Agent (Prompt) Builder** ကို ရွေးပါ။
1. **+ New Agent** Button ကို နှိပ်ပါ။ Extension က **Command Palette** မှာ Setup Wizard ကို ဖွင့်ပေးပါမယ်။
1. **Calculator Agent** ဆိုတဲ့ နာမည်ကို ရိုက်ထည့်ပြီး **Enter** ကို နှိပ်ပါ။
1. **Agent (Prompt) Builder** မှာ **Model** Field အတွက် **OpenAI GPT-4o (via GitHub)** Model ကို ရွေးပါ။

### -2- Agent အတွက် System Prompt တစ်ခုကို ဖန်တီးပါ

<<<<<<< HEAD
Agent ကို Scaffold လုပ်ပြီးရင်၊ Agent ရဲ့ Personality နဲ့ ရည်ရွယ်ချက်ကို သတ်မှတ်ရပါမယ်။ ဒီအပိုင်းမှာ **Generate system prompt** Feature ကို အသုံးပြုကာ Calculator Agent ရဲ့ အပြုအမူကို ဖော်ပြတဲ့ System Prompt ကို Model ကို အသုံးပြုပြီး Generate လုပ်ပါမယ်။

1. **Prompts** အပိုင်းမှာ **Generate system prompt** Button ကို နှိပ်ပါ။
1. **Generate a prompt** Window မှာ အောက်ပါကို ရိုက်ထည့်ပါ: `သင်သည် အကူအညီပေးနိုင်ပြီး ထိရောက်သော သင်္ချာအကူအညီပေးသူဖြစ်သည်။ အခြေခံ သင်္ချာပြဿနာတစ်ခုရရှိပါက၊ သင်သည် မှန်ကန်သော အဖြေကို ပြန်လည်ပေးပါသည်။`
=======
Agent ကို Scaffold လုပ်ပြီးရင်၊ Personality နဲ့ ရည်ရွယ်ချက်ကို သတ်မှတ်ရမယ်။ ဒီအပိုင်းမှာ **Generate system prompt** Feature ကို အသုံးပြုကာ Agent ရဲ့ အပြုအမူကို ဖော်ပြတဲ့ Prompt ကို ဖန်တီးပါမယ်။

1. **Prompts** အပိုင်းမှာ **Generate system prompt** Button ကို နှိပ်ပါ။
1. **Generate a prompt** Window မှာ အောက်ပါကို ရိုက်ထည့်ပါ: `သင်သည် အကူအညီပေးနိုင်ပြီး ထိရောက်သော သင်္ချာအကူအညီပေးသူတစ်ဦးဖြစ်သည်။ အခြေခံ သင်္ချာပြဿနာတစ်ခုရရှိပါက၊ သင်သည် မှန်ကန်သော အဖြေကို ပြန်လည်ပေးပါသည်။`
>>>>>>> origin/main
1. **Generate** Button ကို နှိပ်ပါ။ Prompt Generation ပြီးဆုံးပြီး **System prompt** Field မှာ Prompt ကို ပြသပါမယ်။
1. **System prompt** ကို ပြန်လည်ကြည့်ရှုပြီး လိုအပ်ပါက ပြင်ဆင်ပါ။

### -3- MCP Server တစ်ခုကို ဖန်တီးပါ

<<<<<<< HEAD
Agent ရဲ့ System Prompt ကို သတ်မှတ်ပြီးရင်၊ Agent ကို လက်တွေ့အသုံးပြုနိုင်စွမ်းပေးဖို့ Practical Capabilities တွေကို ထည့်သွင်းရပါမယ်။ ဒီအပိုင်းမှာ Calculator MCP Server တစ်ခုကို ဖန်တီးပြီး Addition, Subtraction, Multiplication, နဲ့ Division Calculations တွေကို လုပ်ဆောင်နိုင်စေပါမယ်။

AI Toolkit မှာ MCP Server ကို ဖန်တီးဖို့ Templates တွေပါဝင်ပါတယ်။ Python Template ကို အသုံးပြုကာ Calculator MCP Server ကို ဖန်တီးပါမယ်။

*မှတ်ချက်*: AI Toolkit က Python နဲ့ TypeScript ကို လက်ရှိ Support လုပ်ပေးပါတယ်။
=======
Agent ရဲ့ System Prompt ကို သတ်မှတ်ပြီးရင်၊ Agent ကို လက်တွေ့အသုံးချနိုင်စွမ်းပေးဖို့ MCP Server တစ်ခုကို ဖန်တီးရပါမယ်။ ဒီအပိုင်းမှာ Addition, Subtraction, Multiplication, Division Calculations တွေကို လုပ်ဆောင်နိုင်တဲ့ Calculator MCP Server တစ်ခုကို ဖန်တီးပါမယ်။

AI Toolkit မှာ MCP Server ကို ဖန်တီးဖို့ Templates တွေ ပါဝင်ပါတယ်။ Python Template ကို အသုံးပြုကာ Calculator MCP Server ကို ဖန်တီးပါမယ်။
>>>>>>> origin/main

1. **Agent (Prompt) Builder** ရဲ့ **Tools** အပိုင်းမှာ **+ MCP Server** Button ကို နှိပ်ပါ။
1. **+ Add Server** ကို ရွေးပါ။
1. **Create a New MCP Server** ကို ရွေးပါ။
1. **python-weather** Template ကို ရွေးပါ။
<<<<<<< HEAD
1. **Default folder** ကို MCP Server Template ကို Save လုပ်ရန် ရွေးပါ။
1. Server အတွက် အောက်ပါနာမည်ကို ရိုက်ထည့်ပါ: **Calculator**
1. Visual Studio Code Window အသစ်တစ်ခု ဖွင့်ပါမယ်။ **Yes, I trust the authors** ကို ရွေးပါ။
1. **Terminal** မှာ Virtual Environment တစ်ခုကို ဖန်တီးပါ: `python -m venv .venv`
1. **Terminal** မှာ Virtual Environment ကို Activate လုပ်ပါ:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source .venv/bin/activate`
1. **Terminal** မှာ Dependencies တွေကို Install လုပ်ပါ: `pip install -e .[dev]`
1. **Activity Bar** ရဲ့ **Explorer** View မှာ **src** Directory ကို Expand လုပ်ပြီး **server.py** File ကို Editor မှာ ဖွင့်ပါ။
1. **server.py** File ရဲ့ Code ကို အောက်ပါ Code နဲ့ Replace လုပ်ပြီး Save လုပ်ပါ:
=======
1. **Default folder** ကို MCP Server Template ကို Save လုပ်ဖို့ ရွေးပါ။
1. Server အတွက် နာမည်ကို **Calculator** လို့ ရိုက်ထည့်ပါ။
1. MCP Server Template ကို ဖွင့်ပြီး **Yes, I trust the authors** ကို ရွေးပါ။
1. Terminal မှာ Virtual Environment တစ်ခုကို ဖန်တီးပါ: `python -m venv .venv`
1. Virtual Environment ကို Activate လုပ်ပါ:
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source .venv/bin/activate`
1. Dependencies တွေကို Install လုပ်ပါ: `pip install -e .[dev]`
1. **Activity Bar** ရဲ့ **Explorer** View မှာ **src** Directory ကို ဖွင့်ပြီး **server.py** File ကို ရွေးပါ။
1. **server.py** File ရဲ့ Code ကို အောက်ပါ Code နဲ့ အစားထိုးပြီး Save လုပ်ပါ:
>>>>>>> origin/main

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

### -4- Calculator MCP Server နဲ့ Agent ကို Run လုပ်ပါ

<<<<<<< HEAD
Agent ရဲ့ Tools တွေကို အသုံးပြုဖို့ အချိန်ရောက်ပါပြီ! ဒီအပိုင်းမှာ Prompt တွေကို Agent ကို Submit လုပ်ပြီး Calculator MCP Server မှ Tools တွေကို အသုံးပြုနိုင်မှုကို စမ်းသပ်ပါမယ်။

1. `F5` ကို နှိပ်ပြီး MCP Server ကို Debugging စတင်ပါ။ **Agent (Prompt) Builder** ကို Editor Tab အသစ်မှာ ဖွင့်ပါမယ်။
1. **Agent (Prompt) Builder** ရဲ့ **User prompt** Field မှာ အောက်ပါ Prompt ကို ရိုက်ထည့်ပါ: `ငါ $25 တန်ပစ္စည်း 3 ခုဝယ်ပြီး $20 Discount သုံးခဲ့တယ်။ ငါဘယ်လောက်ပေးခဲ့ရလဲ?`
1. **Run** Button ကို နှိပ်ပြီး Agent ရဲ့ Response ကို Generate လုပ်ပါ။
1. Agent Output ကို ပြန်လည်ကြည့်ရှုပါ။ Model က **$55** ကို အဖြေထုတ်ပေးသင့်ပါတယ်။
1. အောက်ပါအတိုင်း ဖြစ်ပေါ်ရပါမယ်:
    - Agent က Calculation အတွက် **multiply** နဲ့ **subtract** Tools တွေကို ရွေးချယ်ပါမယ်။
    - **multiply** Tool အတွက် `a` နဲ့ `b` Values တွေကို Assign လုပ်ပါမယ်။
    - **subtract** Tool အတွက် `a` နဲ့ `b` Values တွေကို Assign လုပ်ပါမယ်။
    - Tools တစ်ခုချင်းစီရဲ့ **Tool Response** ကို ပြသပါမယ်။
    - Model ရဲ့ **Model Response** ကို အဆုံးမှာ ပြသပါမယ်။
1. Prompt အသစ်တွေကို Submit လုပ်ပြီး Agent ကို ထပ်မံစမ်းသပ်ပါ။ **User prompt** Field မှာ Prompt ကို ပြောင်းလဲနိုင်ပါတယ်။
1. Agent ကို စမ်းသပ်ပြီးရင် Server ကို **Terminal** မှာ **CTRL/CMD+C** ကို ရိုက်ထည့်ကာ Quit လုပ်ပါ။

## လုပ်ဆောင်ရန်

**server.py** File မှာ Tool အသစ်တစ်ခု (ဥပမာ - နံပါတ်တစ်ခုရဲ့ Square Root ကို ပြန်ပေးမယ့် Tool) ထည့်ပါ။ Agent ကို သင့် Tool အသစ် (သို့မဟုတ် ရှိပြီးသား Tools) ကို အသုံးပြုဖို့ လိုအပ်တဲ့ Prompt တွေကို Submit လုပ်ပါ။ Tools အသစ်တွေကို Load လုပ်ဖို့ Server ကို Restart လုပ်ပါ။
=======
Agent ရဲ့ Tools တွေကို အသုံးပြုဖို့ အချိန်ရောက်ပါပြီ! ဒီအပိုင်းမှာ Prompt တွေကို Agent ကို ပေးပြီး Calculator MCP Server မှ Tools တွေကို အသုံးပြုနိုင်မလား စမ်းသပ်ပါမယ်။

1. MCP Server ကို Debugging စတင်ဖို့ `F5` ကို နှိပ်ပါ။
1. **Agent (Prompt) Builder** ရဲ့ **User prompt** Field မှာ အောက်ပါ Prompt ကို ရိုက်ထည့်ပါ: `ငါ $25 တန်ပစ္စည်း 3 ခုဝယ်ပြီး $20 Discount ကို သုံးခဲ့တယ်။ ငါဘယ်လောက်ပေးခဲ့ရလဲ?`
1. **Run** Button ကို နှိပ်ပြီး Agent ရဲ့ Response ကို ဖန်တီးပါ။
1. Agent Output ကို ပြန်လည်ကြည့်ရှုပါ။ Model က **$55** ကို အဖြေထုတ်ပေးသင့်ပါတယ်။
1. အောက်ပါအတိုင်း ဖြစ်ရမယ်:
    - Agent က Calculation အတွက် **multiply** နဲ့ **subtract** Tools ကို ရွေးချယ်ပါမယ်။
    - **multiply** Tool အတွက် `a` နဲ့ `b` Values တွေကို Assign လုပ်ပါမယ်။
    - **subtract** Tool အတွက် `a` နဲ့ `b` Values တွေကို Assign လုပ်ပါမယ်။
    - Tools တွေက Response ကို **Tool Response** အနေနဲ့ ပြန်ပေးပါမယ်။
    - Model က Final Output ကို **Model Response** အနေနဲ့ ပြန်ပေးပါမယ်။
1. Prompt တွေကို ပြောင်းပြီး Agent ကို ထပ်စမ်းသပ်ပါ။
1. MCP Server ကို Terminal မှာ **CTRL/CMD+C** ကို နှိပ်ပြီး ရပ်ပါ။

## လုပ်ဆောင်ရန်

**server.py** File မှာ Tool တစ်ခုထပ်ထည့်ပါ (ဥပမာ: နံပါတ်တစ်ခုရဲ့ Square Root ကို ပြန်ပေးပါ။) Agent ကို Tool အသစ် (သို့) ရှိပြီးသား Tools တွေကို အသုံးပြုဖို့လိုအပ်တဲ့ Prompt တွေကို ပေးပါ။ Tools အသစ်တွေကို Load လုပ်ဖို့ Server ကို ပြန်စတင်ပါ။
>>>>>>> origin/main

## ဖြေရှင်းချက်

[Solution](./solution/README.md)

## အဓိက Takeaways

ဒီအခန်းရဲ့ အဓိက Takeaways တွေမှာ:

- AI Toolkit Extension က MCP Servers နဲ့ Tools တွေကို အသုံးပြုနိုင်တဲ့ Client အလွန်ကောင်းတစ်ခုဖြစ်ပါတယ်။
<<<<<<< HEAD
- MCP Servers မှ Tools အသစ်တွေကို ထည့်သွင်းပြီး Agent ရဲ့ လုပ်ဆောင်နိုင်စွမ်းတွေကို တိုးမြှင့်နိုင်ပါတယ်။
- AI Toolkit မှာ Custom Tools တွေကို ဖန်တီးဖို့ Templates (ဥပမာ - Python MCP Server Templates) ပါဝင်ပါတယ်။

## အပိုဆောင်း ရင်းမြစ်များ
=======
- MCP Servers မှ Tools အသစ်တွေကို ထည့်သွင်းပြီး Agent ရဲ့ စွမ်းရည်တွေကို တိုးမြှင့်နိုင်ပါတယ်။
- AI Toolkit မှာ Python MCP Server Templates စတဲ့ Templates တွေပါဝင်ပြီး Custom Tools တွေကို ဖန်တီးဖို့ လွယ်ကူစေပါတယ်။

## ထပ်ဆောင်းရင်းမြစ်များ
>>>>>>> origin/main

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## နောက်တစ်ခု
- နောက်တစ်ခု: [Testing & Debugging](../08-testing/README.md)

**အကြောင်းကြားချက်**:  
<<<<<<< HEAD
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် ရှုလေ့လာသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
=======
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါရှိနိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
>>>>>>> origin/main
