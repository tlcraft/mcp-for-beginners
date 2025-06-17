<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-17T16:32:10+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "my"
}
-->
# Weather MCP Server

Python ဖြင့်ရေးသားထားသော Weather tools များနှင့် mock responses များပါဝင်သည့် sample MCP Server ဖြစ်သည်။ သင်၏ MCP Server ကို တည်ဆောက်ရာတွင် မူလကျသော အခြေခံအဖြစ် အသုံးပြုနိုင်ပါသည်။ အောက်ပါ လုပ်ဆောင်ချက်များ ပါဝင်သည်-

- **Weather Tool**: ပေးထားသော တည်နေရာအရ မိုးလေဝသသတင်းအချက်အလက်များကို mock ပြုလုပ်ပေးသော tool တစ်ခု။
- **Git Clone Tool**: git repository ကို သတ်မှတ်ထားသော ဖိုလ်ဒါသို့ clone လုပ်ပေးသော tool တစ်ခု။
- **VS Code Open Tool**: ဖိုလ်ဒါတစ်ခုကို VS Code သို့မဟုတ် VS Code Insiders တွင်ဖွင့်ပေးသော tool တစ်ခု။
- **Connect to Agent Builder**: MCP server ကို Agent Builder နှင့် ချိတ်ဆက်၍ စမ်းသပ်ခြင်းနှင့် debug ပြုလုပ်နိုင်ရန် လုပ်ဆောင်ချက်။
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Inspector ကို အသုံးပြုပြီး MCP Server ကို debug ပြုလုပ်နိုင်သော လုပ်ဆောင်ချက်။

## Weather MCP Server template ဖြင့် စတင်အသုံးပြုခြင်း

> **လိုအပ်ချက်များ**
>
> သင်၏ local development machine တွင် MCP Server ကို run ပြုလုပ်ရန်အတွက် လိုအပ်သော software များမှာ-
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo tool အတွက်လိုအပ်သည်)
> - [VS Code](https://code.visualstudio.com/) သို့မဟုတ် [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode tool အတွက်လိုအပ်သည်)
> - (*Optional - uv ကို preferr လုပ်လျှင်*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်း

ဤ project အတွက် ပတ်ဝန်းကျင်ပြင်ဆင်ရန် နည်းလမ်း နှစ်မျိုးရှိပြီး သင်၏ စိတ်ကြိုက် တစ်ခုကို ရွေးချယ်နိုင်ပါသည်။

> မှတ်ချက်- Virtual environment ဖန်တီးပြီးနောက် VSCode သို့မဟုတ် terminal ကို ပြန်လည်စတင်ပေးရန် virtual environment ၏ python ကို သုံးနေကြောင်း သေချာစေရန်။

| နည်းလမ်း | အဆင့်များ |
| -------- | ---------- |
| `uv` ကို အသုံးပြုခြင်း | 1. Virtual environment ဖန်တီးပါ: `uv venv` <br>2. VSCode ၌ "***Python: Select Interpreter***" command ကို run ပြီး ဖန်တီးထားသော virtual environment ၏ python ကို ရွေးချယ်ပါ <br>3. dependency များ (dev dependencies အပါအဝင်) ကို install ပြုလုပ်ပါ: `uv pip install -r pyproject.toml --extra dev` |
| `pip` ကို အသုံးပြုခြင်း | 1. Virtual environment ဖန်တီးပါ: `python -m venv .venv` <br>2. VSCode ၌ "***Python: Select Interpreter***" command ကို run ပြီး ဖန်တီးထားသော virtual environment ၏ python ကို ရွေးချယ်ပါ <br>3. dependency များ (dev dependencies အပါအဝင်) ကို install ပြုလုပ်ပါ: `pip install -e .[dev]` |

ပတ်ဝန်းကျင်ပြင်ဆင်ပြီးပါက Agent Builder ကို MCP Client အဖြစ် အသုံးပြု၍ သင်၏ local development machine တွင် server ကို run ပြုလုပ်နိုင်ပါသည်-
1. VS Code Debug panel ကိုဖွင့်ပါ။ `Debug in Agent Builder` ကိုရွေးချယ်ပြီး `F5` ကိုနှိပ်ကာ MCP server ကို debug စတင်ပါ။
2. AI Toolkit Agent Builder ကို အသုံးပြုပြီး [ဒီ prompt](../../../../../../../../../../../open_prompt_builder) ဖြင့် server ကို စမ်းသပ်နိုင်သည်။ Server သည် Agent Builder နှင့် အလိုအလျောက် ချိတ်ဆက်ထားပါသည်။
3. `Run` ကိုနှိပ်ကာ prompt ဖြင့် server ကို စမ်းသပ်ပါ။

**ဂုဏ်ယူပါသည်**! သင်သည် Agent Builder ကို MCP Client အဖြစ် အသုံးပြုပြီး သင်၏ local development machine တွင် Weather MCP Server ကို အောင်မြင်စွာ run ပြုလုပ်နိုင်ပါပြီ။
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Template တွင် ပါဝင်သော အရာများ

| ဖိုလ်ဒါ / ဖိုင် | အကြောင်းအရာ                            |
| -------------- | ------------------------------------- |
| `.vscode`    | Debugging အတွက် VSCode ဖိုင်များ        |
| `.aitk`   | AI Toolkit အတွက် configuration များ   |
| `src`   | Weather MCP Server အတွက် source code   |

## Weather MCP Server ကို debug ပြုလုပ်နည်း

> မှတ်ချက်များ-
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) သည် MCP servers များကို စမ်းသပ်ခြင်းနှင့် debug ပြုလုပ်ရန် ရည်ရွယ်ထားသော visual developer tool ဖြစ်သည်။
> - Debugging mode များအားလုံးတွင် breakpoints ကို ထည့်သွင်းနိုင်ပြီး tool implementation code တွင် breakpoints ထည့်နိုင်ပါသည်။

## အသုံးပြုနိုင်သော Tools များ

### Weather Tool  
`get_weather` tool သည် သတ်မှတ်ထားသော တည်နေရာအတွက် mock လုပ်ထားသော မိုးလေဝသသတင်းအချက်အလက်များကို ပေးစွမ်းသည်။

| Parameter | Type   | ဖော်ပြချက်                              |
| --------- | ------ | ------------------------------------- |
| `location` | string | မိုးလေဝသရယူလိုသော တည်နေရာ (ဥပမာ- မြို့နာမည်၊ ပြည်နယ်၊ ဒေသဆိုင်ရာ ဂဏန်းတည်နေရာ) |

### Git Clone Tool  
`git_clone_repo` tool သည် git repository ကို သတ်မှတ်ထားသော ဖိုလ်ဒါသို့ clone လုပ်ပေးသည်။

| Parameter | Type   | ဖော်ပြချက်                           |
| --------- | ------ | ---------------------------------- |
| `repo_url` | string | Clone လုပ်လိုသော git repository ၏ URL |
| `target_folder` | string | Repository ကို clone လုပ်မည့် ဖိုလ်ဒါလမ်းကြောင်း |

Tool သည် JSON object တစ်ခု return ပြန်ပြီး အောက်ပါအချက်များ ပါဝင်သည်-
- `success`: လုပ်ငန်းစဉ်အောင်မြင်မှုရှိ/မရှိကို boolean ဖြင့်ပြသည်
- `target_folder` သို့မဟုတ် `error`: clone လုပ်ထားသော repository ၏ လမ်းကြောင်း သို့မဟုတ် error message

### VS Code Open Tool  
`open_in_vscode` tool သည် ဖိုလ်ဒါတစ်ခုကို VS Code သို့မဟုတ် VS Code Insiders application တွင် ဖွင့်ပေးသည်။

| Parameter | Type       | ဖော်ပြချက်                            |
| --------- | ---------- | ----------------------------------- |
| `folder_path` | string     | ဖွင့်လိုသော ဖိုလ်ဒါလမ်းကြောင်း        |
| `use_insiders` | boolean (optional) | regular VS Code အစား VS Code Insiders ကို အသုံးပြုမည်/မဟုတ် |

Tool သည် JSON object တစ်ခု return ပြန်ပြီး အောက်ပါအချက်များ ပါဝင်သည်-
- `success`: လုပ်ငန်းစဉ်အောင်မြင်မှုရှိ/မရှိကို boolean ဖြင့်ပြသည်
- `message` သို့မဟုတ် `error`: အတည်ပြုချက် သို့မဟုတ် error message

## Debug Mode | ဖော်ပြချက် | Debug ပြုလုပ်ရန်အဆင့်များ
| ---------- | ---------- | ---------------------------- |
| Agent Builder | AI Toolkit မှတဆင့် Agent Builder တွင် MCP server ကို debug ပြုလုပ်ခြင်း။ | 1. VS Code Debug panel ကိုဖွင့်ပါ။ `Debug in Agent Builder` ကိုရွေးချယ်ပြီး `F5` ကိုနှိပ်ကာ MCP server ကို debug စတင်ပါ။<br>2. AI Toolkit Agent Builder ကို အသုံးပြုပြီး [ဒီ prompt](../../../../../../../../../../../open_prompt_builder) ဖြင့် server ကို စမ်းသပ်နိုင်သည်။ Server သည် Agent Builder နှင့် အလိုအလျောက် ချိတ်ဆက်ထားပါသည်။<br>3. `Run` ကိုနှိပ်ကာ prompt ဖြင့် server ကို စမ်းသပ်ပါ။ |
| MCP Inspector | MCP Inspector ကို အသုံးပြုပြီး MCP server ကို debug ပြုလုပ်ခြင်း။ | 1. [Node.js](https://nodejs.org/) ကို install လုပ်ပါ<br> 2. Inspector ကို setup ပြုလုပ်ပါ: `cd inspector` && `npm install` <br> 3. VS Code Debug panel ကိုဖွင့်ပါ။ `Debug SSE in Inspector (Edge)` သို့မဟုတ် `Debug SSE in Inspector (Chrome)` ကိုရွေးချယ်ပြီး F5 ကိုနှိပ်ကာ debug စတင်ပါ။<br> 4. MCP Inspector ကို browser တွင် ဖွင့်သောအခါ `Connect` ခလုတ်ကိုနှိပ်ကာ MCP server ကို ချိတ်ဆက်ပါ။<br> 5. ထို့နောက် `List Tools`, tool ကိုရွေးချယ်၍ parameters ထည့်သွင်းကာ `Run Tool` နှိပ်ကာ server code ကို debug ပြုလုပ်နိုင်ပါသည်။<br> |

## Default Ports နှင့် customizations

| Debug Mode    | Ports                         | ဖော်ပြချက်               | ပြင်ဆင်နိုင်မှုများ                                | မှတ်ချက် |
| ------------- | ----------------------------- | ------------------------ | ----------------------------------------------- | -------- |
| Agent Builder | 3001                          | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) တွင် ပို့(Port) များ ပြင်ဆင်နိုင်သည်။ | N/A      |
| MCP Inspector | 3001 (Server); 5173 နှင့် 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) တွင် ပို့(Port) များ ပြင်ဆင်နိုင်သည်။ | N/A      |

## တုံ့ပြန်ချက်

ဤ template အတွက် တုံ့ပြန်ချက်များ သို့မဟုတ် အကြံပြုချက်များရှိပါက [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) တွင် issue တင်ပေးပါရန်။

**အချက်ပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် မှန်ကန်မှုအတွက် ကြိုးပမ်းသည်မှာမှန်ပါသည်၊ သို့သော် အလိုအလျောက်ဘာသာပြန်ခြင်းအတွက် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ အတည်ပြုနိုင်သော အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များ၏ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက် အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားခြင်းများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။