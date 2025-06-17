<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-17T16:35:01+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "my"
}
-->
# Weather MCP Server

Python ဖြင့်ရေးထားသော weather tools များအတွက် mock response များပါဝင်သော sample MCP Server ဖြစ်သည်။ သင့်ကိုယ်ပိုင် MCP Server တည်ဆောက်ရာတွင် အခြေခံတည်ဆောက်ပုံအဖြစ် အသုံးပြုနိုင်သည်။ အောက်ပါ feature များ ပါဝင်သည်။

- **Weather Tool**: ပေးထားသော တည်နေရာအရ weather အချက်အလက်များကို mock လုပ်ပေးသော tool ဖြစ်သည်။
- **Connect to Agent Builder**: MCP server ကို Agent Builder နှင့် ချိတ်ဆက်၍ စမ်းသပ်ခြင်းနှင့် debugging ပြုလုပ်နိုင်သော feature ဖြစ်သည်။
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Server ကို MCP Inspector ဖြင့် debugging ပြုလုပ်နိုင်သော feature ဖြစ်သည်။

## Weather MCP Server template ဖြင့် စတင်အသုံးပြုခြင်း

> **လိုအပ်ချက်များ**
>
> သင့် local dev machine တွင် MCP Server ကို run ပြုလုပ်ရန်အတွက် အောက်ပါအရာများ လိုအပ်ပါသည်။
>
> - [Python](https://www.python.org/)
> - (*optional - uv ကို preferr လုပ်ပါက*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်း

ဤ project အတွက် ပတ်ဝန်းကျင်ကို ပြင်ဆင်ရာတွင် နည်းလမ်းနှစ်မျိုးရှိသည်။ သင့်စိတ်ကြိုက် နည်းလမ်းတစ်ခုကို ရွေးချယ်နိုင်ပါသည်။

> မှတ်ချက် - virtual environment ဖန်တီးပြီးနောက် VSCode သို့မဟုတ် terminal ကို ပြန်လည်ဖွင့်ပြီး virtual environment ရဲ့ python ကို အသုံးပြုနေကြောင်း သေချာစေရန်။

| နည်းလမ်း | အဆင့်များ |
| -------- | ---------- |
| `uv` အသုံးပြုခြင်း | 1. virtual environment ဖန်တီးပါ: `uv venv` <br>2. VSCode Command "***Python: Select Interpreter***" ကို run ပြီး ဖန်တီးထားသော virtual environment ရဲ့ python ကို ရွေးချယ်ပါ <br>3. dependency များ (dev dependency များပါဝင်သည်) ကို install ပြုလုပ်ပါ: `uv pip install -r pyproject.toml --extra dev` |
| `pip` အသုံးပြုခြင်း | 1. virtual environment ဖန်တီးပါ: `python -m venv .venv` <br>2. VSCode Command "***Python: Select Interpreter***" ကို run ပြီး ဖန်တီးထားသော virtual environment ရဲ့ python ကို ရွေးချယ်ပါ <br>3. dependency များ (dev dependency များပါဝင်သည်) ကို install ပြုလုပ်ပါ: `pip install -e .[dev]` |

ပတ်ဝန်းကျင် ပြင်ဆင်ပြီးပါက MCP Client အဖြစ် Agent Builder မှတဆင့် သင့် local dev machine တွင် server ကို run ပြုလုပ်နိုင်ပါသည်။
1. VS Code Debug panel ကို ဖွင့်ပါ။ `Debug in Agent Builder` ကို ရွေးချယ်ပြီး `F5` ကိုနှိပ်၍ MCP server debugging ကို စတင်ပါ။
2. AI Toolkit Agent Builder ကို အသုံးပြု၍ [ဤ prompt](../../../../../../../../../../../open_prompt_builder) ဖြင့် server ကို စမ်းသပ်နိုင်သည်။ Server သည် Agent Builder နှင့် အလိုအလျောက် ချိတ်ဆက်ထားမည်။
3. `Run` ကို နှိပ်၍ prompt ဖြင့် server ကို စမ်းသပ်ပါ။

**ဂုဏ်ယူပါတယ်**! သင်သည် AI Toolkit Agent Builder မှတဆင့် MCP Client အဖြစ် သင့် local dev machine တွင် Weather MCP Server ကို အောင်မြင်စွာ run ပြုလုပ်နိုင်ပါပြီ။
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Template တွင် ပါဝင်သော အရာများ

| ဖိုလ်ဒါ / ဖိုင် | အကြောင်းအရာ |
| -------------- | -------------- |
| `.vscode` | VSCode debugging အတွက် ဖိုင်များ |
| `.aitk` | AI Toolkit အတွက် configuration များ |
| `src` | weather mcp server အတွက် source code |

## Weather MCP Server ကို debugging ပြုလုပ်နည်း

> မှတ်ချက်များ:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) သည် MCP server များကို စမ်းသပ်ခြင်းနှင့် debugging ပြုလုပ်ရန် အသုံးပြုသော visual developer tool ဖြစ်သည်။
> - debugging mode များအားလုံးတွင် breakpoint များထည့်နိုင်သည့်အတွက် tool implementation code တွင် breakpoint ထည့်နိုင်ပါသည်။

| Debug Mode | ဖော်ပြချက် | Debug ပြုလုပ်ရန် အဆင့်များ |
| ---------- | ---------- | -------------------------- |
| Agent Builder | AI Toolkit မှတဆင့် Agent Builder တွင် MCP server ကို debugging ပြုလုပ်ခြင်း | 1. VS Code Debug panel ကို ဖွင့်ပါ။ `Debug in Agent Builder` ကို ရွေးပြီး `F5` ကိုနှိပ်၍ MCP server debugging စတင်ပါ။<br>2. AI Toolkit Agent Builder ကို အသုံးပြု၍ [ဤ prompt](../../../../../../../../../../../open_prompt_builder) ဖြင့် server ကို စမ်းသပ်ပါ။ Server သည် Agent Builder နှင့် အလိုအလျောက် ချိတ်ဆက်ထားမည်။<br>3. `Run` ကို နှိပ်၍ prompt ဖြင့် server ကို စမ်းသပ်ပါ။ |
| MCP Inspector | MCP Inspector ကို အသုံးပြု၍ MCP server ကို debugging ပြုလုပ်ခြင်း | 1. [Node.js](https://nodejs.org/) ကို install ပြုလုပ်ပါ။<br>2. Inspector ကို စတင်ပြင်ဆင်ပါ: `cd inspector` && `npm install` <br>3. VS Code Debug panel ကို ဖွင့်ပါ။ `Debug SSE in Inspector (Edge)` သို့မဟုတ် `Debug SSE in Inspector (Chrome)` ကို ရွေးချယ်ပြီး F5 ကိုနှိပ်၍ debugging စတင်ပါ။<br>4. MCP Inspector browser တွင် ဖွင့်လာသည်နှင့် `Connect` ခလုတ်ကို နှိပ်၍ MCP server နှင့် ချိတ်ဆက်ပါ။<br>5. ထို့နောက် `List Tools`, tool ရွေးချယ်ခြင်း, parameter များ ထည့်သွင်းခြင်းနှင့် `Run Tool` ဖြင့် server code ကို debugging ပြုလုပ်နိုင်ပါသည်။<br> |

## Default Ports နှင့် ပြင်ဆင်မှုများ

| Debug Mode | Ports | ဖော်ပြချက် | ပြင်ဆင်နိုင်မှုများ | မှတ်ချက် |
| ---------- | ----- | --------- | ----------------- | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) တွင် အထက်ဖော်ပြသော port များ ပြောင်းလဲနိုင်သည်။ | မရှိပါ |
| MCP Inspector | 3001 (Server); 5173 နှင့် 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) တွင် အထက်ဖော်ပြသော port များ ပြောင်းလဲနိုင်သည်။ | မရှိပါ |

## တုံ့ပြန်ချက်

ဤ template အတွက် တုံ့ပြန်ချက် သို့မဟုတ် အကြံပြုချက်များ ရှိပါက [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) တွင် issue ဖွင့်ပေးပါ။

**သတိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် တိကျမှုမရှိမှုများ ဖြစ်ပေါ်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူသားဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သည့် အမှားနားလည်မှုများ သို့မဟုတ် မှားယွင်းဖော်ပြမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မခံပါ။