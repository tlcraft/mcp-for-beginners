<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:04:54+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "my"
}
-->
# Weather MCP Server

Python ဖြင့်ရေးသားထားသော weather tools များကို mock response များဖြင့် အကောင်အထည်ဖော်ထားသည့် MCP Server နမူနာဖြစ်သည်။ သင့်ရဲ့ MCP Server ကို တည်ဆောက်ရာတွင် အခြေခံအဖြစ် အသုံးပြုနိုင်သည်။ အောက်ပါ လုပ်ဆောင်ချက်များ ပါဝင်သည်။

- **Weather Tool**: ပေးထားသော တည်နေရာအပေါ် မူတည်၍ မော်ကွန်းထားသော ရာသီဥတု အချက်အလက်များကို ပေးသော ကိရိယာ။
- **Git Clone Tool**: git repository ကို သတ်မှတ်ထားသော ဖိုလ်ဒါသို့ ကလုန်းလုပ်ပေးသော ကိရိယာ။
- **VS Code Open Tool**: ဖိုလ်ဒါတစ်ခုကို VS Code သို့မဟုတ် VS Code Insiders တွင် ဖွင့်ပေးသော ကိရိယာ။
- **Connect to Agent Builder**: MCP server ကို Agent Builder နှင့် ချိတ်ဆက်၍ စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေရေးလုပ်ဆောင်နိုင်စေရန် လုပ်ဆောင်ချက်။
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Inspector ကို အသုံးပြု၍ MCP Server ကို debug လုပ်နိုင်စေရန် လုပ်ဆောင်ချက်။

## Weather MCP Server template ဖြင့် စတင်အသုံးပြုခြင်း

> **လိုအပ်ချက်များ**
>
> သင့်ရဲ့ ဒေသတွင်း ဖွံ့ဖြိုးရေးစက်တွင် MCP Server ကို လည်ပတ်ရန် အောက်ပါအရာများ လိုအပ်ပါသည်။
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo tool အတွက် လိုအပ်သည်)
> - [VS Code](https://code.visualstudio.com/) သို့မဟုတ် [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode tool အတွက် လိုအပ်သည်)
> - (*Optional - uv ကို သဘောကျပါက*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်း

ဒီ project အတွက် ပတ်ဝန်းကျင် ပြင်ဆင်ရာတွင် နည်းလမ်း နှစ်မျိုး ရှိသည်။ သင့်စိတ်ကြိုက် တစ်ခုကို ရွေးချယ်နိုင်ပါသည်။

> မှတ်ချက် - virtual environment ဖန်တီးပြီးနောက် VSCode သို့မဟုတ် terminal ကို ပြန်လည်ဖွင့်၍ virtual environment ထဲမှ python ကို အသုံးပြုနေကြောင်း သေချာစေရန်။

| နည်းလမ်း | အဆင့်များ |
| -------- | ---------- |
| `uv` အသုံးပြုခြင်း | 1. virtual environment ဖန်တီးရန်: `uv venv` <br>2. VSCode Command "***Python: Select Interpreter***" ကို လည်ပတ်ပြီး ဖန်တီးထားသော virtual environment ထဲမှ python ကို ရွေးချယ်ပါ <br>3. လိုအပ်သော dependencies (dev dependencies ပါဝင်သည်) ကို ထည့်သွင်းရန်: `uv pip install -r pyproject.toml --extra dev` |
| `pip` အသုံးပြုခြင်း | 1. virtual environment ဖန်တီးရန်: `python -m venv .venv` <br>2. VSCode Command "***Python: Select Interpreter***" ကို လည်ပတ်ပြီး ဖန်တီးထားသော virtual environment ထဲမှ python ကို ရွေးချယ်ပါ <br>3. လိုအပ်သော dependencies (dev dependencies ပါဝင်သည်) ကို ထည့်သွင်းရန်: `pip install -e .[dev]` |

ပတ်ဝန်းကျင် ပြင်ဆင်ပြီးနောက်၊ သင့်ဒေသတွင်း ဖွံ့ဖြိုးရေးစက်တွင် Agent Builder ကို MCP Client အဖြစ် အသုံးပြု၍ server ကို လည်ပတ်နိုင်ပါသည်။
1. VS Code Debug panel ကို ဖွင့်ပါ။ `Debug in Agent Builder` ကို ရွေးချယ်ပြီး `F5` ကို နှိပ်၍ MCP server ကို debug စတင်ပါ။
2. AI Toolkit Agent Builder ကို အသုံးပြု၍ [ဒီ prompt](../../../../../../../../../../open_prompt_builder) ဖြင့် server ကို စမ်းသပ်ပါ။ Server သည် Agent Builder နှင့် အလိုအလျောက် ချိတ်ဆက်ထားပါလိမ့်မည်။
3. `Run` ကို နှိပ်၍ prompt ဖြင့် server ကို စမ်းသပ်ပါ။

**ဂုဏ်ယူပါတယ်**! သင့်ဒေသတွင်း ဖွံ့ဖြိုးရေးစက်တွင် Agent Builder ကို MCP Client အဖြစ် အသုံးပြု၍ Weather MCP Server ကို အောင်မြင်စွာ လည်ပတ်နိုင်ပါပြီ။
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Template တွင် ပါဝင်သော အရာများ

| ဖိုလ်ဒါ / ဖိုင် | အကြောင်းအရာ |
| -------------- | ------------- |
| `.vscode`      | Debugging အတွက် VSCode ဖိုင်များ |
| `.aitk`        | AI Toolkit အတွက် ဖွဲ့စည်းမှုများ |
| `src`          | weather mcp server အတွက် source code |

## Weather MCP Server ကို ဘယ်လို debug လုပ်မလဲ

> မှတ်ချက်များ:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) သည် MCP servers များကို စမ်းသပ်ခြင်းနှင့် debug လုပ်ရာတွင် အသုံးပြုသော visual developer ကိရိယာဖြစ်သည်။
> - Debugging mode အားလုံးတွင် breakpoints ထည့်သွင်းနိုင်ပြီး tool implementation code တွင် breakpoints ထည့်နိုင်ပါသည်။

## ရနိုင်သော Tools များ

### Weather Tool
`get_weather` tool သည် သတ်မှတ်ထားသော တည်နေရာအတွက် မော်ကွန်းထားသော ရာသီဥတု အချက်အလက်များကို ပေးသည်။

| Parameter | Type | ဖော်ပြချက် |
| --------- | ---- | --------- |
| `location` | string | ရာသီဥတု သိလိုသော တည်နေရာ (ဥပမာ - မြို့နာမည်၊ ပြည်နယ်၊ သို့မဟုတ် ဂဏန်းညွှန်း) |

### Git Clone Tool
`git_clone_repo` tool သည် git repository ကို သတ်မှတ်ထားသော ဖိုလ်ဒါသို့ ကလုန်းလုပ်ပေးသည်။

| Parameter | Type | ဖော်ပြချက် |
| --------- | ---- | --------- |
| `repo_url` | string | ကလုန်းလုပ်မည့် git repository ၏ URL |
| `target_folder` | string | repository ကို ကလုန်းမည့် ဖိုလ်ဒါလမ်းကြောင်း |

Tool သည် JSON object တစ်ခုကို ပြန်ပေးသည်။
- `success`: လုပ်ဆောင်မှု အောင်မြင်မှုကို ပြသသော Boolean
- `target_folder` သို့မဟုတ် `error`: ကလုန်းထားသော ဖိုလ်ဒါလမ်းကြောင်း သို့မဟုတ် အမှားစာသား

### VS Code Open Tool
`open_in_vscode` tool သည် ဖိုလ်ဒါတစ်ခုကို VS Code သို့မဟုတ် VS Code Insiders application တွင် ဖွင့်ပေးသည်။

| Parameter | Type | ဖော်ပြချက် |
| --------- | ---- | --------- |
| `folder_path` | string | ဖွင့်မည့် ဖိုလ်ဒါလမ်းကြောင်း |
| `use_insiders` | boolean (optional) | ပုံမှန် VS Code အစား VS Code Insiders ကို အသုံးပြုမည်ဟုတ်မဟုတ် |

Tool သည် JSON object တစ်ခုကို ပြန်ပေးသည်။
- `success`: လုပ်ဆောင်မှု အောင်မြင်မှုကို ပြသသော Boolean
- `message` သို့မဟုတ် `error`: အတည်ပြုစာသား သို့မဟုတ် အမှားစာသား

## Debug Mode | ဖော်ပြချက် | Debug လုပ်ရန် အဆင့်များ
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit မှတဆင့် Agent Builder တွင် MCP server ကို debug လုပ်ခြင်း။ | 1. VS Code Debug panel ကို ဖွင့်ပါ။ `Debug in Agent Builder` ကို ရွေးချယ်ပြီး `F5` ကို နှိပ်၍ MCP server ကို debug စတင်ပါ။<br>2. AI Toolkit Agent Builder ကို အသုံးပြု၍ [ဒီ prompt](../../../../../../../../../../open_prompt_builder) ဖြင့် server ကို စမ်းသပ်ပါ။ Server သည် Agent Builder နှင့် အလိုအလျောက် ချိတ်ဆက်ထားပါလိမ့်မည်။<br>3. `Run` ကို နှိပ်၍ prompt ဖြင့် server ကို စမ်းသပ်ပါ။ |
| MCP Inspector | MCP Inspector ကို အသုံးပြု၍ MCP server ကို debug လုပ်ခြင်း။ | 1. [Node.js](https://nodejs.org/) ကို ထည့်သွင်းပါ<br>2. Inspector ကို ပြင်ဆင်ရန်: `cd inspector` && `npm install` <br>3. VS Code Debug panel ကို ဖွင့်ပါ။ `Debug SSE in Inspector (Edge)` သို့မဟုတ် `Debug SSE in Inspector (Chrome)` ကို ရွေးချယ်ပြီး `F5` ကို နှိပ်၍ debug စတင်ပါ။<br>4. MCP Inspector browser တွင် ဖွင့်လာသောအခါ `Connect` ခလုတ်ကို နှိပ်၍ MCP server ကို ချိတ်ဆက်ပါ။<br>5. ထို့နောက် `List Tools` ကို နှိပ်၍ tool ကို ရွေးချယ်၊ parameter များ ထည့်သွင်းပြီး `Run Tool` ဖြင့် server code ကို debug လုပ်နိုင်ပါသည်။<br> |

## Default Ports နှင့် စိတ်ကြိုက်ပြင်ဆင်မှုများ

| Debug Mode | Ports | ဖော်ပြချက်များ | စိတ်ကြိုက်ပြင်ဆင်မှုများ | မှတ်ချက် |
| ---------- | ----- | -------------- | ------------------------- | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) တွင် အထက်ဖော်ပြပါ ports များ ပြင်ဆင်နိုင်သည်။ | N/A |
| MCP Inspector | 3001 (Server); 5173 နှင့် 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) တွင် အထက်ဖော်ပြပါ ports များ ပြင်ဆင်နိုင်သည်။ | N/A |

## တုံ့ပြန်ချက်

ဒီ template အတွက် တုံ့ပြန်ချက်များ သို့မဟုတ် အကြံပြုချက်များ ရှိပါက [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) တွင် issue တစ်ခု ဖွင့်ပေးပါ။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။