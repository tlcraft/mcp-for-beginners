<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-10T06:07:47+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "mr"
}
-->
# 🔧 Module 3: Advanced MCP Development with AI Toolkit

![Duration](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)
![AI Toolkit](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)
![Python](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)
![Inspector](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)

## 🎯 Learning Objectives

या लॅबच्या शेवटी, तुम्ही सक्षम असाल:

- ✅ AI Toolkit वापरून कस्टम MCP सर्व्हर तयार करणे
- ✅ नवीनतम MCP Python SDK (v1.9.3) कॉन्फिगर आणि वापरणे
- ✅ डिबगिंगसाठी MCP Inspector सेटअप आणि वापर करणे
- ✅ Agent Builder आणि Inspector दोन्ही वातावरणांमध्ये MCP सर्व्हर डिबग करणे
- ✅ प्रगत MCP सर्व्हर विकास कार्यप्रवाह समजून घेणे

## 📋 Prerequisites

- Lab 2 (MCP Fundamentals) पूर्ण केलेले असणे
- AI Toolkit एक्सटेंशनसह VS Code
- Python 3.10+ वातावरण
- Inspector सेटअपसाठी Node.js आणि npm

## 🏗️ तुम्ही काय तयार करणार आहात

या लॅबमध्ये, तुम्ही एक **Weather MCP Server** तयार कराल जो दाखवेल:
- कस्टम MCP सर्व्हर अंमलबजावणी
- AI Toolkit Agent Builder सह एकत्रीकरण
- व्यावसायिक डिबगिंग कार्यप्रवाह
- आधुनिक MCP SDK वापर पद्धती

---

## 🔧 Core Components Overview

### 🐍 MCP Python SDK
Model Context Protocol Python SDK कस्टम MCP सर्व्हर तयार करण्याचा पाया आहे. तुम्ही आवृत्ती 1.9.3 वापराल ज्यात सुधारित डिबगिंग क्षमता आहेत.

### 🔍 MCP Inspector
एक सामर्थ्यशाली डिबगिंग साधन जे प्रदान करते:
- रिअल-टाइम सर्व्हर निरीक्षण
- टूल अंमलबजावणीचे दृश्यांकन
- नेटवर्क विनंती/प्रतिक्रिया तपासणी
- परस्परसंवादी चाचणी वातावरण

---

## 📖 Step-by-Step Implementation

### Step 1: Agent Builder मध्ये WeatherAgent तयार करा

1. VS Code मध्ये AI Toolkit एक्सटेंशनद्वारे **Agent Builder लॉन्च करा**
2. खालील कॉन्फिगरेशनसह **नवीन एजंट तयार करा:**
   - Agent Name: `WeatherAgent`

![Agent Creation](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.mr.png)

### Step 2: MCP Server प्रोजेक्ट प्रारंभ करा

1. Agent Builder मध्ये **Tools → Add Tool** या पर्यायावर जा
2. उपलब्ध पर्यायांमधून **"MCP Server" निवडा**
3. **"Create A new MCP Server" निवडा**
4. `python-weather` टेम्पलेट निवडा
5. तुमच्या सर्व्हरचे नाव द्या: `weather_mcp`

![Python Template Selection](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.mr.png)

### Step 3: प्रोजेक्ट उघडा आणि तपासा

1. VS Code मध्ये तयार प्रोजेक्ट उघडा
2. प्रोजेक्ट स्ट्रक्चर पहा:
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

### Step 4: नवीनतम MCP SDK मध्ये अपग्रेड करा

> **🔍 का अपग्रेड करावे?** नवीनतम MCP SDK (v1.9.3) आणि Inspector सेवा (0.14.0) वापरून सुधारित वैशिष्ट्ये आणि उत्तम डिबगिंग क्षमता मिळवण्यासाठी.

#### 4a. Python Dependencies अपडेट करा

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

**Edit `.vscode/launch.json` संपादित करा:**

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

**`.vscode/tasks.json` संपादित करा:**

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

## 🚀 तुमचा MCP सर्व्हर चालवा आणि चाचणी करा

### Step 6: Dependencies इन्स्टॉल करा

कॉन्फिगरेशन बदल केल्यानंतर खालील आदेश चालवा:

**Python dependencies इन्स्टॉल करा:**
```bash
uv sync
```

**Inspector dependencies इन्स्टॉल करा:**
```bash
cd inspector
npm install
```

### Step 7: Agent Builder मध्ये डिबग करा

1. **F5 दाबा** किंवा **"Debug in Agent Builder"** कॉन्फिगरेशन वापरा
2. डिबग पॅनेलमधून **compound configuration निवडा**
3. सर्व्हर सुरू होईपर्यंत आणि Agent Builder उघडण्याची वाट पाहा
4. नैसर्गिक भाषेतील प्रश्नांसह तुमचा weather MCP server चाचणी करा

खालीलप्रमाणे इनपुट द्या

SYSTEM_PROMPT

```
You are my weather assistant
```

USER_PROMPT

```
How's the weather like in Seattle
```

![Agent Builder Debug Result](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.mr.png)

### Step 8: MCP Inspector सह डिबग करा

1. **"Debug in Inspector"** कॉन्फिगरेशन वापरा (Edge किंवा Chrome)
2. `http://localhost:6274` येथे Inspector इंटरफेस उघडा
3. परस्परसंवादी चाचणी वातावरण एक्सप्लोर करा:
   - उपलब्ध टूल्स पहा
   - टूल अंमलबजावणी तपासा
   - नेटवर्क विनंत्या मॉनिटर करा
   - सर्व्हर प्रतिसाद डिबग करा

![MCP Inspector Interface](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.mr.png)

---

## 🎯 मुख्य शिकण्याचे परिणाम

ही लॅब पूर्ण केल्यावर, तुम्ही:

- [x] AI Toolkit टेम्पलेट्स वापरून कस्टम MCP सर्व्हर तयार केला आहे
- [x] नवीनतम MCP SDK (v1.9.3) मध्ये अपग्रेड केला आहे ज्यामुळे कार्यक्षमता सुधारली आहे
- [x] Agent Builder आणि Inspector साठी व्यावसायिक डिबगिंग कार्यप्रवाह कॉन्फिगर केले आहेत
- [x] MCP Inspector सेटअप केला आहे जेणेकरून सर्व्हरची परस्परसंवादी चाचणी करता येईल
- [x] MCP विकासासाठी VS Code डिबगिंग कॉन्फिगरेशनमध्ये पारंगत झाला आहे

## 🔧 प्रगत वैशिष्ट्ये एक्सप्लोर केली

| वैशिष्ट्य | वर्णन | वापर प्रकरण |
|---------|-------------|----------|
| **MCP Python SDK v1.9.3** | नवीनतम प्रोटोकॉल अंमलबजावणी | आधुनिक सर्व्हर विकास |
| **MCP Inspector 0.14.0** | परस्परसंवादी डिबगिंग साधन | रिअल-टाइम सर्व्हर चाचणी |
| **VS Code Debugging** | एकत्रित विकास वातावरण | व्यावसायिक डिबगिंग कार्यप्रवाह |
| **Agent Builder Integration** | थेट AI Toolkit कनेक्शन | एजंटची पूर्ण चाचणी |

## 📚 अतिरिक्त संसाधने

- [MCP Python SDK Documentation](https://modelcontextprotocol.io/docs/sdk/python)
- [AI Toolkit Extension Guide](https://code.visualstudio.com/docs/ai/ai-toolkit)
- [VS Code Debugging Documentation](https://code.visualstudio.com/docs/editor/debugging)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/docs/concepts/architecture)

---

**🎉 अभिनंदन!** तुम्ही यशस्वीरित्या Lab 3 पूर्ण केला आहे आणि आता व्यावसायिक विकास कार्यप्रवाह वापरून कस्टम MCP सर्व्हर तयार, डिबग आणि तैनात करू शकता.

### 🔜 पुढील मॉड्यूलकडे जा

तुमचे MCP कौशल्य वास्तविक विकास कार्यप्रवाहात लागू करण्यास तयार आहात का? पुढे जा **[Module 4: Practical MCP Development - Custom GitHub Clone Server](../lab4/README.md)** जिथे तुम्ही:
- GitHub रेपॉजिटरी ऑपरेशन्स स्वयंचलित करणारा उत्पादन-तयार MCP सर्व्हर तयार कराल
- MCP द्वारे GitHub रेपॉजिटरी क्लोनिंग कार्यक्षमता अंमलात आणाल
- VS Code आणि GitHub Copilot Agent Mode सह कस्टम MCP सर्व्हर एकत्रित कराल
- उत्पादन वातावरणात कस्टम MCP सर्व्हर चाचणी आणि तैनात कराल
- विकासकांसाठी व्यावहारिक कार्यप्रवाह स्वयंचलन शिकाल

**डिस्क्लेमर**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, पण कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेत फरक असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीकरिता व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराचा वापर करून उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागीसाठी आम्ही जबाबदार नाही.