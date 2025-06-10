<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-10T06:08:38+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "pa"
}
-->
# 🔧 Module 3: AI Toolkit ਨਾਲ ਅਡਵਾਂਸਡ MCP ਵਿਕਾਸ

![Duration](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)
![AI Toolkit](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)
![Python](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)
![Inspector](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)

## 🎯 ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਲੈਬ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ✅ AI Toolkit ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਸਟਮ MCP ਸਰਵਰ ਬਣਾਉਣਾ
- ✅ ਨਵਾਂ MCP Python SDK (v1.9.3) ਕਨਫਿਗਰ ਅਤੇ ਵਰਤਣਾ
- ✅ ਡੀਬੱਗਿੰਗ ਲਈ MCP Inspector ਸੈੱਟਅਪ ਅਤੇ ਵਰਤਣਾ
- ✅ Agent Builder ਅਤੇ Inspector ਦੋਹਾਂ ਵਿੱਚ MCP ਸਰਵਰ ਡੀਬੱਗ ਕਰਨਾ
- ✅ ਅਡਵਾਂਸਡ MCP ਸਰਵਰ ਵਿਕਾਸ ਦੇ ਵਰਕਫਲੋਜ਼ ਸਮਝਣਾ

## 📋 ਜਰੂਰੀਆਂ

- ਲੈਬ 2 (MCP Fundamentals) ਪੂਰੀ ਹੋਣੀ ਚਾਹੀਦੀ ਹੈ
- VS Code ਵਿੱਚ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਇੰਸਟਾਲ ਹੋਇਆ ਹੋਵੇ
- Python 3.10+ ਵਾਤਾਵਰਣ
- Inspector ਸੈੱਟਅਪ ਲਈ Node.js ਅਤੇ npm

## 🏗️ ਤੁਸੀਂ ਕੀ ਬਣਾਉਂਗੇ

ਇਸ ਲੈਬ ਵਿੱਚ, ਤੁਸੀਂ ਇੱਕ **Weather MCP Server** ਬਣਾਉਗੇ ਜੋ ਇਹ ਦਿਖਾਉਂਦਾ ਹੈ:
- ਕਸਟਮ MCP ਸਰਵਰ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ
- AI Toolkit Agent Builder ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ
- ਪ੍ਰੋਫੈਸ਼ਨਲ ਡੀਬੱਗਿੰਗ ਵਰਕਫਲੋਜ਼
- ਆਧੁਨਿਕ MCP SDK ਵਰਤੋਂ ਦੇ ਪੈਟਰਨ

---

## 🔧 ਮੁੱਖ ਘਟਕਾਂ ਦਾ ਜਾਇਜ਼ਾ

### 🐍 MCP Python SDK  
Model Context Protocol Python SDK ਕਸਟਮ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਬੁਨਿਆਦ ਦਿੰਦਾ ਹੈ। ਤੁਸੀਂ ਵਰਜਨ 1.9.3 ਵਰਤੋਂਗੇ ਜਿਸ ਵਿੱਚ ਡੀਬੱਗਿੰਗ ਲਈ ਬਿਹਤਰ ਸੁਵਿਧਾਵਾਂ ਹਨ।

### 🔍 MCP Inspector  
ਇੱਕ ਸ਼ਕਤੀਸ਼ਾਲੀ ਡੀਬੱਗਿੰਗ ਟੂਲ ਜੋ ਇਹ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ:  
- ਰੀਅਲ-ਟਾਈਮ ਸਰਵਰ ਮਾਨੀਟਰਿੰਗ  
- ਟੂਲ ਐਗਜ਼ਿਕਿਊਸ਼ਨ ਵਿਜ਼ੂਅਲਾਈਜ਼ੇਸ਼ਨ  
- ਨੈੱਟਵਰਕ ਰਿਕਵੈਸਟ/ਰਿਸਪਾਂਸ ਇੰਸਪੈਕਸ਼ਨ  
- ਇੰਟਰਐਕਟਿਵ ਟੈਸਟਿੰਗ ਵਾਤਾਵਰਣ

---

## 📖 ਕਦਮ-ਦਰ-ਕਦਮ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ

### ਕਦਮ 1: Agent Builder ਵਿੱਚ WeatherAgent ਬਣਾਓ

1. VS Code ਵਿੱਚ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਰਾਹੀਂ **Agent Builder ਲਾਂਚ ਕਰੋ**  
2. ਹੇਠਾਂ ਦਿੱਤੀ ਸੈਟਿੰਗ ਨਾਲ **ਨਵਾਂ ਏਜੰਟ ਬਣਾਓ**:  
   - Agent Name: `WeatherAgent`

![Agent Creation](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.pa.png)

### ਕਦਮ 2: MCP ਸਰਵਰ ਪ੍ਰੋਜੈਕਟ ਸ਼ੁਰੂ ਕਰੋ

1. Agent Builder ਵਿੱਚ **Tools → Add Tool** 'ਤੇ ਜਾਓ  
2. ਉਪਲਬਧ ਵਿਕਲਪਾਂ ਵਿੱਚੋਂ **"MCP Server" ਚੁਣੋ**  
3. **"Create A new MCP Server" ਚੁਣੋ**  
4. `python-weather` ਟੈਮਪਲੇਟ ਚੁਣੋ  
5. ਆਪਣੇ ਸਰਵਰ ਦਾ ਨਾਮ ਦਿਓ: `weather_mcp`

![Python Template Selection](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.pa.png)

### ਕਦਮ 3: ਪ੍ਰੋਜੈਕਟ ਖੋਲ੍ਹੋ ਅਤੇ ਜਾਂਚੋ

1. VS Code ਵਿੱਚ ਬਣਾਇਆ ਗਿਆ ਪ੍ਰੋਜੈਕਟ ਖੋਲ੍ਹੋ  
2. ਪ੍ਰੋਜੈਕਟ ਦੀ ਬਣਤਰ ਨੂੰ ਸਮਝੋ:  
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

### ਕਦਮ 4: MCP SDK ਨੂੰ ਨਵਾਂ ਵਰਜਨ ਦਿਓ

> **🔍 ਅਪਗ੍ਰੇਡ ਕਿਉਂ?** ਅਸੀਂ MCP SDK (v1.9.3) ਅਤੇ Inspector ਸੇਵਾ (0.14.0) ਦੇ ਨਵੇਂ ਫੀਚਰ ਅਤੇ ਬਿਹਤਰ ਡੀਬੱਗਿੰਗ ਲਈ ਵਰਤਣਾ ਚਾਹੁੰਦੇ ਹਾਂ।

#### 4a. Python Dependencies ਅਪਡੇਟ ਕਰੋ

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

**Edit `.vscode/launch.json` ਨੂੰ ਸੰਪਾਦਿਤ ਕਰੋ:**

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

**`.vscode/tasks.json` ਨੂੰ ਸੰਪਾਦਿਤ ਕਰੋ:**

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

## 🚀 ਆਪਣੇ MCP ਸਰਵਰ ਨੂੰ ਚਲਾਉਣਾ ਅਤੇ ਟੈਸਟ ਕਰਨਾ

### ਕਦਮ 6: Dependencies ਇੰਸਟਾਲ ਕਰੋ

ਕਨਫਿਗਰੇਸ਼ਨ ਬਦਲਣ ਤੋਂ ਬਾਅਦ, ਇਹ ਕਮਾਂਡਾਂ ਚਲਾਓ:

**Python Dependencies ਇੰਸਟਾਲ ਕਰੋ:**  
```bash
uv sync
```

**Inspector Dependencies ਇੰਸਟਾਲ ਕਰੋ:**  
```bash
cd inspector
npm install
```

### ਕਦਮ 7: Agent Builder ਨਾਲ ਡੀਬੱਗ ਕਰੋ

1. **F5 ਦਬਾਓ** ਜਾਂ **"Debug in Agent Builder"** ਕਨਫਿਗਰੇਸ਼ਨ ਵਰਤੋ  
2. ਡੀਬੱਗ ਪੈਨਲ ਵਿੱਚੋਂ ਕੰਪਾਊਂਡ ਕਨਫਿਗਰੇਸ਼ਨ ਚੁਣੋ  
3. ਸਰਵਰ ਸ਼ੁਰੂ ਹੋਣ ਅਤੇ Agent Builder ਖੁਲਣ ਦੀ ਉਡੀਕ ਕਰੋ  
4. ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਪ੍ਰਸ਼ਨਾਂ ਨਾਲ ਆਪਣੇ weather MCP ਸਰਵਰ ਨੂੰ ਟੈਸਟ ਕਰੋ

ਇਸ ਤਰ੍ਹਾਂ ਇਨਪੁੱਟ ਦਿਓ

SYSTEM_PROMPT

```
You are my weather assistant
```

USER_PROMPT

```
How's the weather like in Seattle
```

![Agent Builder Debug Result](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.pa.png)

### ਕਦਮ 8: MCP Inspector ਨਾਲ ਡੀਬੱਗ ਕਰੋ

1. **"Debug in Inspector"** ਕਨਫਿਗਰੇਸ਼ਨ (Edge ਜਾਂ Chrome) ਵਰਤੋ  
2. `http://localhost:6274` 'ਤੇ Inspector ਇੰਟਰਫੇਸ ਖੋਲ੍ਹੋ  
3. ਇੰਟਰਐਕਟਿਵ ਟੈਸਟਿੰਗ ਵਾਤਾਵਰਣ ਨੂੰ ਐਕਸਪਲੋਰ ਕਰੋ:  
   - ਉਪਲਬਧ ਟੂਲ ਵੇਖੋ  
   - ਟੂਲ ਐਗਜ਼ਿਕਿਊਸ਼ਨ ਟੈਸਟ ਕਰੋ  
   - ਨੈੱਟਵਰਕ ਰਿਕਵੈਸਟ ਮਾਨੀਟਰ ਕਰੋ  
   - ਸਰਵਰ ਰਿਸਪਾਂਸ ਡੀਬੱਗ ਕਰੋ

![MCP Inspector Interface](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.pa.png)

---

## 🎯 ਮੁੱਖ ਸਿੱਖਣ ਦੇ ਨਤੀਜੇ

ਇਸ ਲੈਬ ਨੂੰ ਪੂਰਾ ਕਰਕੇ, ਤੁਸੀਂ:

- [x] AI Toolkit ਟੈਮਪਲੇਟਾਂ ਨਾਲ **ਕਸਟਮ MCP ਸਰਵਰ ਬਣਾਇਆ**  
- [x] ਨਵੇਂ MCP SDK (v1.9.3) 'ਤੇ **ਅਪਗ੍ਰੇਡ ਕੀਤਾ**  
- [x] Agent Builder ਅਤੇ Inspector ਲਈ **ਪ੍ਰੋਫੈਸ਼ਨਲ ਡੀਬੱਗਿੰਗ ਵਰਕਫਲੋਜ਼ ਕਨਫਿਗਰ ਕੀਤੇ**  
- [x] MCP Inspector ਨੂੰ **ਇੰਟਰਐਕਟਿਵ ਸਰਵਰ ਟੈਸਟਿੰਗ ਲਈ ਸੈੱਟਅਪ ਕੀਤਾ**  
- [x] MCP ਵਿਕਾਸ ਲਈ VS Code ਡੀਬੱਗਿੰਗ ਕਨਫਿਗਰੇਸ਼ਨ ਵਿੱਚ **ਮਾਹਿਰਤਾ ਹਾਸਲ ਕੀਤੀ**

## 🔧 ਅਡਵਾਂਸਡ ਫੀਚਰਾਂ ਦੀ ਜਾਣਕਾਰੀ

| ਫੀਚਰ | ਵਰਣਨ | ਵਰਤੋਂ ਦਾ ਕੇਸ |
|---------|-------------|----------|
| **MCP Python SDK v1.9.3** | ਨਵੀਂ ਪ੍ਰੋਟੋਕੋਲ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ | ਆਧੁਨਿਕ ਸਰਵਰ ਵਿਕਾਸ |
| **MCP Inspector 0.14.0** | ਇੰਟਰਐਕਟਿਵ ਡੀਬੱਗਿੰਗ ਟੂਲ | ਰੀਅਲ-ਟਾਈਮ ਸਰਵਰ ਟੈਸਟਿੰਗ |
| **VS Code Debugging** | ਇੰਟੀਗ੍ਰੇਟਡ ਵਿਕਾਸ ਵਾਤਾਵਰਣ | ਪ੍ਰੋਫੈਸ਼ਨਲ ਡੀਬੱਗਿੰਗ ਵਰਕਫਲੋਜ਼ |
| **Agent Builder Integration** | ਸਿੱਧਾ AI Toolkit ਕਨੈਕਸ਼ਨ | ਏਜੰਟ ਟੈਸਟਿੰਗ ਦਾ ਅੰਤ-ਤੱਕ ਪ੍ਰਕਿਰਿਆ |

## 📚 ਵਾਧੂ ਸਰੋਤ

- [MCP Python SDK Documentation](https://modelcontextprotocol.io/docs/sdk/python)  
- [AI Toolkit Extension Guide](https://code.visualstudio.com/docs/ai/ai-toolkit)  
- [VS Code Debugging Documentation](https://code.visualstudio.com/docs/editor/debugging)  
- [Model Context Protocol Specification](https://modelcontextprotocol.io/docs/concepts/architecture)

---

**🎉 ਵਧਾਈਆਂ!** ਤੁਸੀਂ ਲੈਬ 3 ਸਫਲਤਾਪੂਰਵਕ ਪੂਰਾ ਕਰ ਲਿਆ ਹੈ ਅਤੇ ਹੁਣ ਕਸਟਮ MCP ਸਰਵਰ ਬਣਾਉਣ, ਡੀਬੱਗ ਕਰਨ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਪ੍ਰੋਫੈਸ਼ਨਲ ਵਿਕਾਸ ਵਰਕਫਲੋਜ਼ ਵਰਤ ਸਕਦੇ ਹੋ।

### 🔜 ਅਗਲੇ ਮੋਡੀਊਲ ਵੱਲ ਵਧੋ

ਆਪਣੀਆਂ MCP ਕੌਸ਼ਲਾਂ ਨੂੰ ਹਕੀਕਤੀ ਵਿਕਾਸ ਵਰਕਫਲੋ ਵਿੱਚ ਲਾਗੂ ਕਰਨ ਲਈ ਤਿਆਰ ਹੋ? ਜਾਰੀ ਰੱਖੋ **[Module 4: Practical MCP Development - Custom GitHub Clone Server](../lab4/README.md)** ਜਿੱਥੇ ਤੁਸੀਂ:  
- GitHub ਰਿਪੋਜ਼ਟਰੀ ਆਪਰੇਸ਼ਨਾਂ ਨੂੰ ਆਟੋਮੇਟ ਕਰਨ ਵਾਲਾ ਪ੍ਰੋਡਕਸ਼ਨ-ਰੇਡੀ MCP ਸਰਵਰ ਬਣਾਉਂਦੇ ਹੋ  
- MCP ਰਾਹੀਂ GitHub ਰਿਪੋਜ਼ਟਰੀ ਕਲੋਨਿੰਗ ਫੰਕਸ਼ਨਾਲਿਟੀ ਇੰਪਲੀਮੈਂਟ ਕਰਦੇ ਹੋ  
- VS Code ਅਤੇ GitHub Copilot Agent Mode ਨਾਲ ਕਸਟਮ MCP ਸਰਵਰ ਇੰਟੀਗ੍ਰੇਟ ਕਰਦੇ ਹੋ  
- ਪ੍ਰੋਡਕਸ਼ਨ ਵਾਤਾਵਰਣ ਵਿੱਚ ਕਸਟਮ MCP ਸਰਵਰ ਟੈਸਟ ਅਤੇ ਡਿਪਲੋਇ ਕਰਦੇ ਹੋ  
- ਡਿਵੈਲਪਰਾਂ ਲਈ ਪ੍ਰੈਕਟਿਕਲ ਵਰਕਫਲੋ ਆਟੋਮੇਸ਼ਨ ਸਿੱਖਦੇ ਹੋ

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਵਜੋਂ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭੁੱਲਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।