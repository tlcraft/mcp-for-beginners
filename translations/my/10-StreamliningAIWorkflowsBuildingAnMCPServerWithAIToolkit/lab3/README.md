<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-17T16:34:21+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "my"
}
-->
# 🔧 Module 3: AI Toolkit ဖြင့် အဆင့်မြင့် MCP ဖွံ့ဖြိုးမှု

![Duration](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)
![AI Toolkit](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)
![Python](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)
![Inspector](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)

## 🎯 သင်ယူရမည့် ရည်မှန်းချက်များ

ဤ lab အဆုံးသတ်ချိန်တွင် သင်သည် -

- ✅ AI Toolkit အသုံးပြု၍ စိတ်ကြိုက် MCP server များ ဖန်တီးနိုင်မည်
- ✅ နောက်ဆုံးထွက် MCP Python SDK (v1.9.3) ကို သတ်မှတ်ပြီး အသုံးပြုနိုင်မည်
- ✅ MCP Inspector ကို စတင်တပ်ဆင်ပြီး Debug ပြုလုပ်နိုင်မည်
- ✅ Agent Builder နှင့် Inspector ပတ်ဝန်းကျင်များတွင် MCP server များကို Debug ပြုလုပ်နိုင်မည်
- ✅ အဆင့်မြင့် MCP server ဖွံ့ဖြိုးမှု လုပ်ငန်းစဉ်များကို နားလည်နိုင်မည်

## 📋 ကြိုတင်လိုအပ်ချက်များ

- Lab 2 (MCP အခြေခံ) ကို ပြီးမြောက်ထားရမည်
- VS Code တွင် AI Toolkit extension ထည့်သွင်းထားရမည်
- Python 3.10+ ပတ်ဝန်းကျင်ရှိရမည်
- Inspector တပ်ဆင်ရန် Node.js နှင့် npm လိုအပ်သည်

## 🏗️ သင်တည်ဆောက်မည့် အရာ

ဤ lab တွင် သင်သည် **ရာသီဥတု MCP Server** တစ်ခု ဖန်တီးမည်ဖြစ်ပြီး အောက်ပါအချက်များကို ပြသပေးမည်ဖြစ်သည် -

- စိတ်ကြိုက် MCP server တည်ဆောက်ခြင်း
- AI Toolkit Agent Builder နှင့် ပေါင်းစည်းခြင်း
- ပရော်ဖက်ရှင်နယ် Debugging လုပ်ငန်းစဉ်များ
- ခေတ်မှီ MCP SDK အသုံးပြုမှု နမူနာများ

---

## 🔧 အဓိကအစိတ်အပိုင်းများ အနှစ်ချုပ်

### 🐍 MCP Python SDK  
Model Context Protocol Python SDK သည် စိတ်ကြိုက် MCP server များ တည်ဆောက်ရာတွင် အခြေခံဖြစ်သည်။ ဗားရှင်း 1.9.3 ကို အသုံးပြုမည်ဖြစ်ပြီး Debugging လုပ်ဆောင်ချက်များ တိုးမြှင့်ထားသည်။

### 🔍 MCP Inspector  
စွမ်းအားပြင်းထန်သော Debugging ကိရိယာဖြစ်ပြီး အောက်ပါအချက်များကို ပံ့ပိုးပေးသည် -  
- တိုက်ရိုက် server စောင့်ကြည့်ခြင်း  
- ကိရိယာများ အလုပ်လုပ်ပုံ မြင်ကွင်း  
- ကွန်ယက်တောင်းဆိုမှု/တုံ့ပြန်မှု စစ်ဆေးခြင်း  
- အပြန်အလှန် စမ်းသပ်မှု ပတ်ဝန်းကျင်  

---

## 📖 အဆင့်လိုက် ဆောင်ရွက်မှု

### အဆင့် 1: Agent Builder တွင် WeatherAgent တည်ဆောက်ခြင်း

1. **VS Code တွင် AI Toolkit extension မှတဆင့် Agent Builder ကို ဖွင့်ပါ**  
2. **အောက်ပါ ဖော်ပြချက်ဖြင့် အေးဂျင့်အသစ် တည်ဆောက်ပါ** -  
   - အေးဂျင့်အမည်: `WeatherAgent`

![Agent Creation](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.my.png)

### အဆင့် 2: MCP Server Project စတင်ဖန်တီးခြင်း

1. **Agent Builder တွင် Tools → Add Tool သို့ သွားပါ**  
2. **"MCP Server" ကို ရွေးချယ်ပါ**  
3. **"Create A new MCP Server" ကို ရွေးချယ်ပါ**  
4. **`python-weather` template ကို ရွေးချယ်ပါ**  
5. **Server အမည် ထည့်ပါ:** `weather_mcp`

![Python Template Selection](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.my.png)

### အဆင့် 3: Project ကို ဖွင့်ပြီး စစ်ဆေးခြင်း

1. **ဖန်တီးပြီးသော project ကို VS Code တွင် ဖွင့်ပါ**  
2. **Project ဖွဲ့စည်းမှုကို ပြန်လည်သုံးသပ်ပါ** -  
   ```
   weather_mcp/
   ├── src/
   │   ├── __init__.py
   │   └── server.py
   ├── inspector/
   │   ├── package.json
   │   └── package-lock.json
   ├── .vscode/
   │   ├── launch.json
   │   └── tasks.json
   ├── pyproject.toml
   └── README.md
   ```

### အဆင့် 4: MCP SDK နောက်ဆုံးဗားရှင်းသို့ အဆင့်မြှင့်တင်ခြင်း

> **🔍 အဆင့်မြှင့်တင်ရခြင်းအကြောင်း**  
> နောက်ဆုံး MCP SDK (v1.9.3) နှင့် Inspector ဝန်ဆောင်မှု (0.14.0) ကို အသုံးပြုခြင်းဖြင့် ပိုမိုကောင်းမွန်သော လုပ်ဆောင်ချက်များနှင့် Debugging အရည်အသွေး မြှင့်တင်နိုင်သည်။

#### 4a. Python Dependencies များ ပြင်ဆင်ခြင်း

**`pyproject.toml`:** update [./code/weather_mcp/pyproject.toml](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/pyproject.toml)


#### 4b. Update Inspector Configuration

**Edit `inspector/package.json`:** update [./code/weather_mcp/inspector/package.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package.json)

#### 4c. Update Inspector Dependencies

**Edit `inspector/package-lock.json`:** update [./code/weather_mcp/inspector/package-lock.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package-lock.json)

> **📝 Note:** This file contains extensive dependency definitions. Below is the essential structure - the full content ensures proper dependency resolution.


> **⚡ Full Package Lock:** The complete package-lock.json contains ~3000 lines of dependency definitions. The above shows the key structure - use the provided file for complete dependency resolution.

### Step 5: Configure VS Code Debugging

*Note: Please copy the file in the specified path to replace the corresponding local file*

#### 5a. Update Launch Configuration

**Edit `.vscode/launch.json` ကို တည်းဖြတ်ပါ။**

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Attach to Local MCP",
      "type": "debugpy",
      "request": "attach",
      "connect": {
        "host": "localhost",
        "port": 5678
      },
      "presentation": {
        "hidden": true
      },
      "internalConsoleOptions": "neverOpen",
      "postDebugTask": "Terminate All Tasks"
    },
    {
      "name": "Launch Inspector (Edge)",
      "type": "msedge",
      "request": "launch",
      "url": "http://localhost:6274?timeout=60000&serverUrl=http://localhost:3001/sse#tools",
      "cascadeTerminateToConfigurations": [
        "Attach to Local MCP"
      ],
      "presentation": {
        "hidden": true
      },
      "internalConsoleOptions": "neverOpen"
    },
    {
      "name": "Launch Inspector (Chrome)",
      "type": "chrome",
      "request": "launch",
      "url": "http://localhost:6274?timeout=60000&serverUrl=http://localhost:3001/sse#tools",
      "cascadeTerminateToConfigurations": [
        "Attach to Local MCP"
      ],
      "presentation": {
        "hidden": true
      },
      "internalConsoleOptions": "neverOpen"
    }
  ],
  "compounds": [
    {
      "name": "Debug in Agent Builder",
      "configurations": [
        "Attach to Local MCP"
      ],
      "preLaunchTask": "Open Agent Builder",
    },
    {
      "name": "Debug in Inspector (Edge)",
      "configurations": [
        "Launch Inspector (Edge)",
        "Attach to Local MCP"
      ],
      "preLaunchTask": "Start MCP Inspector",
      "stopAll": true
    },
    {
      "name": "Debug in Inspector (Chrome)",
      "configurations": [
        "Launch Inspector (Chrome)",
        "Attach to Local MCP"
      ],
      "preLaunchTask": "Start MCP Inspector",
      "stopAll": true
    }
  ]
}
```

**`.vscode/tasks.json` ကို တည်းဖြတ်ပါ။**

```
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "Start MCP Server",
      "type": "shell",
      "command": "python -m debugpy --listen 127.0.0.1:5678 src/__init__.py sse",
      "isBackground": true,
      "options": {
        "cwd": "${workspaceFolder}",
        "env": {
          "PORT": "3001"
        }
      },
      "problemMatcher": {
        "pattern": [
          {
            "regexp": "^.*$",
            "file": 0,
            "location": 1,
            "message": 2
          }
        ],
        "background": {
          "activeOnStart": true,
          "beginsPattern": ".*",
          "endsPattern": "Application startup complete|running"
        }
      }
    },
    {
      "label": "Start MCP Inspector",
      "type": "shell",
      "command": "npm run dev:inspector",
      "isBackground": true,
      "options": {
        "cwd": "${workspaceFolder}/inspector",
        "env": {
          "CLIENT_PORT": "6274",
          "SERVER_PORT": "6277",
        }
      },
      "problemMatcher": {
        "pattern": [
          {
            "regexp": "^.*$",
            "file": 0,
            "location": 1,
            "message": 2
          }
        ],
        "background": {
          "activeOnStart": true,
          "beginsPattern": "Starting MCP inspector",
          "endsPattern": "Proxy server listening on port"
        }
      },
      "dependsOn": [
        "Start MCP Server"
      ]
    },
    {
      "label": "Open Agent Builder",
      "type": "shell",
      "command": "echo ${input:openAgentBuilder}",
      "presentation": {
        "reveal": "never"
      },
      "dependsOn": [
        "Start MCP Server"
      ],
    },
    {
      "label": "Terminate All Tasks",
      "command": "echo ${input:terminate}",
      "type": "shell",
      "problemMatcher": []
    }
  ],
  "inputs": [
    {
      "id": "openAgentBuilder",
      "type": "command",
      "command": "ai-mlstudio.agentBuilder",
      "args": {
        "initialMCPs": [ "local-server-weather_mcp" ],
        "triggeredFrom": "vsc-tasks"
      }
    },
    {
      "id": "terminate",
      "type": "command",
      "command": "workbench.action.tasks.terminate",
      "args": "terminateAll"
    }
  ]
}
```

---

## 🚀 MCP Server ကို စတင် လည်ပတ်စစ်ဆေးခြင်း

### အဆင့် 6: Dependencies များ ထည့်သွင်းခြင်း

ပြင်ဆင်မှုများ ပြီးဆုံးသည့်နောက် အောက်ပါ command များကို ရိုက်ထည့်ပါ -

**Python dependencies ထည့်သွင်းခြင်း**  
```bash
uv sync
```

**Inspector dependencies ထည့်သွင်းခြင်း**  
```bash
cd inspector
npm install
```

### အဆင့် 7: Agent Builder ဖြင့် Debug ပြုလုပ်ခြင်း

1. **F5 ကို နှိပ်ပါ သို့မဟုတ် "Debug in Agent Builder" configuration ကို အသုံးပြုပါ**  
2. **Debug panel မှ compound configuration ကို ရွေးချယ်ပါ**  
3. **Server စတင်ခြင်းနှင့် Agent Builder ဖွင့်ခြင်းအတွက် စောင့်ဆိုင်းပါ**  
4. **ရာသီဥတု MCP server ကို သဘာဝဘာသာစကား မေးခွန်းများဖြင့် စမ်းသပ်ပါ**

အောက်ပါ input prompt ကဲ့သို့ ထည့်သွင်းပါ

SYSTEM_PROMPT

```
You are my weather assistant
```

USER_PROMPT

```
How's the weather like in Seattle
```

![Agent Builder Debug Result](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.my.png)

### အဆင့် 8: MCP Inspector ဖြင့် Debug ပြုလုပ်ခြင်း

1. **"Debug in Inspector" configuration ကို အသုံးပြုပါ (Edge သို့မဟုတ် Chrome)**  
2. **`http://localhost:6274` တွင် Inspector အင်တာဖေ့စ်ကို ဖွင့်ပါ**  
3. **အပြန်အလှန် စမ်းသပ်မှု ပတ်ဝန်းကျင်ကို စူးစမ်းလေ့လာပါ**  
   - ရရှိနိုင်သော ကိရိယာများ ကြည့်ရှုခြင်း  
   - ကိရိယာ လုပ်ဆောင်မှု စမ်းသပ်ခြင်း  
   - ကွန်ယက်တောင်းဆိုမှုများ စောင့်ကြည့်ခြင်း  
   - Server တုံ့ပြန်မှုများကို Debug ပြုလုပ်ခြင်း  

![MCP Inspector Interface](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.my.png)

---

## 🎯 အဓိက သင်ယူရလဒ်များ

ဤ lab ကို ပြီးမြောက်ခြင်းဖြင့် သင်သည် -

- [x] **AI Toolkit templates အသုံးပြု၍ စိတ်ကြိုက် MCP server တည်ဆောက်နိုင်ခဲ့သည်**  
- [x] **နောက်ဆုံး MCP SDK (v1.9.3) သို့ အဆင့်မြှင့်တင်နိုင်ခဲ့သည်**  
- [x] **Agent Builder နှင့် Inspector အတွက် ပရော်ဖက်ရှင်နယ် Debugging လုပ်ငန်းစဉ်များ သတ်မှတ်နိုင်ခဲ့သည်**  
- [x] **MCP Inspector ကို အပြန်အလှန် စမ်းသပ်မှုအတွက် စတင်တပ်ဆင်နိုင်ခဲ့သည်**  
- [x] **MCP ဖွံ့ဖြိုးမှုအတွက် VS Code Debugging configuration များ ကျွမ်းကျင်စွာ အသုံးပြုနိုင်ခဲ့သည်**

## 🔧 ရှာဖွေတွေ့ရှိထားသော အဆင့်မြင့် လုပ်ဆောင်ချက်များ

| လုပ်ဆောင်ချက် | ဖော်ပြချက် | အသုံးချမှု |
|---------|-------------|----------|
| **MCP Python SDK v1.9.3** | နောက်ဆုံး protocol အကောင်အထည်ဖော်မှု | ခေတ်မှီ server ဖွံ့ဖြိုးမှု |
| **MCP Inspector 0.14.0** | အပြန်အလှန် Debugging ကိရိယာ | တိုက်ရိုက် server စမ်းသပ်မှု |
| **VS Code Debugging** | ပေါင်းစပ်ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင် | ပရော်ဖက်ရှင်နယ် Debugging လုပ်ငန်းစဉ် |
| **Agent Builder ပေါင်းစည်းမှု** | AI Toolkit နှင့် တိုက်ရိုက်ချိတ်ဆက်မှု | အေးဂျင့် စမ်းသပ်မှု စုစုပေါင်း |

## 📚 ထပ်မံ ရရှိနိုင်သော အရင်းအမြစ်များ

- [MCP Python SDK Documentation](https://modelcontextprotocol.io/docs/sdk/python)  
- [AI Toolkit Extension Guide](https://code.visualstudio.com/docs/ai/ai-toolkit)  
- [VS Code Debugging Documentation](https://code.visualstudio.com/docs/editor/debugging)  
- [Model Context Protocol Specification](https://modelcontextprotocol.io/docs/concepts/architecture)  

---

**🎉 ဂုဏ်ပြုပါတယ်!** Lab 3 ကို အောင်မြင်စွာ ပြီးမြောက်ခဲ့ပြီး ပရော်ဖက်ရှင်နယ် ဖွံ့ဖြိုးမှု လုပ်ငန်းစဉ်များဖြင့် စိတ်ကြိုက် MCP server များ ဖန်တီး၊ Debug နှင့် တပ်ဆင်နိုင်ပါပြီ။

### 🔜 နောက် Module သို့ ဆက်လက်သွားရန်

သင်၏ MCP ကျွမ်းကျင်မှုများကို တကယ့်လုပ်ငန်းတွင် အသုံးချရန် ပြင်ဆင်ပြီးဖြစ်ပါသလား? **[Module 4: Practical MCP Development - Custom GitHub Clone Server](../lab4/README.md)** သို့ ဆက်လက်သွားပြီး -

- GitHub repository လုပ်ငန်းစဉ်များကို အလိုအလျောက် ပြုလုပ်ပေးမည့် ထုတ်လုပ်မှုအဆင့် MCP server တည်ဆောက်မည်  
- MCP မှတဆင့် GitHub repository ကို Clone လုပ်ခြင်း လုပ်ဆောင်ချက် ထည့်သွင်းမည်  
- VS Code နှင့် GitHub Copilot Agent Mode တို့နှင့် စိတ်ကြိုက် MCP server များ ပေါင်းစည်းမည်  
- ထုတ်လုပ်မှု ပတ်ဝန်းကျင်များတွင် စိတ်ကြိုက် MCP server များ စမ်းသပ်ပြီး တပ်ဆင်မည်  
- Developer များအတွက် လက်တွေ့ Workflow Automation များ သင်ယူမည်

**အသိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားထားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူလစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်စဉ်းစားသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်သူ ပရော်ဖက်ရှင်နယ် ဝန်ဆောင်မှု အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားယွင်းမှုများ သို့မဟုတ် အဓိပ္ပာယ်မှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။