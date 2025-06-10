<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-10T06:12:13+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "th"
}
-->
# 🔧 Module 3: การพัฒนา MCP ขั้นสูงด้วย AI Toolkit

![Duration](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)  
![AI Toolkit](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)  
![Python](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)  
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)  
![Inspector](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)  

## 🎯 วัตถุประสงค์การเรียนรู้

เมื่อจบแลปนี้ คุณจะสามารถ:

- ✅ สร้างเซิร์ฟเวอร์ MCP แบบกำหนดเองโดยใช้ AI Toolkit  
- ✅ ตั้งค่าและใช้งาน MCP Python SDK เวอร์ชันล่าสุด (v1.9.3)  
- ✅ ติดตั้งและใช้งาน MCP Inspector สำหรับการดีบัก  
- ✅ ดีบักเซิร์ฟเวอร์ MCP ทั้งในสภาพแวดล้อม Agent Builder และ Inspector  
- ✅ เข้าใจกระบวนการพัฒนาเซิร์ฟเวอร์ MCP ขั้นสูง  

## 📋 สิ่งที่ต้องมีเบื้องต้น

- ผ่านแลป 2 (MCP Fundamentals) มาแล้ว  
- ติดตั้ง VS Code พร้อมส่วนขยาย AI Toolkit  
- สภาพแวดล้อม Python 3.10+  
- ติดตั้ง Node.js และ npm สำหรับการตั้งค่า Inspector  

## 🏗️ สิ่งที่คุณจะสร้าง

ในแลปนี้ คุณจะสร้าง **Weather MCP Server** ที่แสดงถึง:  
- การสร้างเซิร์ฟเวอร์ MCP แบบกำหนดเอง  
- การเชื่อมต่อกับ AI Toolkit Agent Builder  
- กระบวนการดีบักแบบมืออาชีพ  
- รูปแบบการใช้งาน MCP SDK สมัยใหม่  

---

## 🔧 ภาพรวมส่วนประกอบหลัก

### 🐍 MCP Python SDK  
Model Context Protocol Python SDK คือฐานสำหรับการสร้างเซิร์ฟเวอร์ MCP แบบกำหนดเอง คุณจะใช้เวอร์ชัน 1.9.3 ที่มีฟีเจอร์ดีบักขั้นสูง  

### 🔍 MCP Inspector  
เครื่องมือดีบักทรงพลังที่มีคุณสมบัติ:  
- ตรวจสอบเซิร์ฟเวอร์แบบเรียลไทม์  
- แสดงผลการทำงานของเครื่องมือ  
- ตรวจสอบคำขอและการตอบสนองของเครือข่าย  
- สภาพแวดล้อมทดสอบแบบโต้ตอบ  

---

## 📖 การดำเนินการทีละขั้นตอน

### ขั้นตอนที่ 1: สร้าง WeatherAgent ใน Agent Builder

1. **เปิด Agent Builder** ใน VS Code ผ่านส่วนขยาย AI Toolkit  
2. **สร้างเอเย่นต์ใหม่** โดยใช้การตั้งค่าดังนี้:  
   - Agent Name: `WeatherAgent`  

![Agent Creation](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.th.png)  

### ขั้นตอนที่ 2: เริ่มโปรเจกต์ MCP Server

1. **ไปที่ Tools** → **Add Tool** ใน Agent Builder  
2. **เลือก "MCP Server"** จากตัวเลือกที่มี  
3. **เลือก "Create A new MCP Server"**  
4. **เลือกเทมเพลต `python-weather`**  
5. **ตั้งชื่อเซิร์ฟเวอร์ของคุณ:** `weather_mcp`  

![Python Template Selection](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.th.png)  

### ขั้นตอนที่ 3: เปิดและตรวจสอบโปรเจกต์

1. **เปิดโปรเจกต์ที่สร้างขึ้น** ใน VS Code  
2. **ตรวจสอบโครงสร้างโปรเจกต์:**  
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

### ขั้นตอนที่ 4: อัปเกรดเป็น MCP SDK เวอร์ชันล่าสุด

> **🔍 ทำไมต้องอัปเกรด?** เราต้องการใช้ MCP SDK เวอร์ชันล่าสุด (v1.9.3) และบริการ Inspector (0.14.0) เพื่อฟีเจอร์ที่ดีขึ้นและความสามารถในการดีบักที่ดีกว่า  

#### 4a. อัปเดต dependencies ของ Python

**แก้ไข `pyproject.toml`:** update [./code/weather_mcp/pyproject.toml](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/pyproject.toml)


#### 4b. Update Inspector Configuration

**Edit `inspector/package.json`:** update [./code/weather_mcp/inspector/package.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package.json)

#### 4c. Update Inspector Dependencies

**Edit `inspector/package-lock.json`:** update [./code/weather_mcp/inspector/package-lock.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package-lock.json)

> **📝 Note:** This file contains extensive dependency definitions. Below is the essential structure - the full content ensures proper dependency resolution.


> **⚡ Full Package Lock:** The complete package-lock.json contains ~3000 lines of dependency definitions. The above shows the key structure - use the provided file for complete dependency resolution.

### Step 5: Configure VS Code Debugging

*Note: Please copy the file in the specified path to replace the corresponding local file*

#### 5a. Update Launch Configuration

**Edit `.vscode/launch.json`:**  

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

**แก้ไข `.vscode/tasks.json`:**  

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

## 🚀 การรันและทดสอบ MCP Server ของคุณ

### ขั้นตอนที่ 6: ติดตั้ง dependencies

หลังจากแก้ไขการตั้งค่าแล้ว ให้รันคำสั่งดังนี้:  

**ติดตั้ง dependencies ของ Python:**  
```bash
uv sync
```  

**ติดตั้ง dependencies ของ Inspector:**  
```bash
cd inspector
npm install
```  

### ขั้นตอนที่ 7: ดีบักด้วย Agent Builder

1. **กด F5** หรือใช้การตั้งค่า **"Debug in Agent Builder"**  
2. **เลือก compound configuration** จากแผงดีบัก  
3. **รอให้เซิร์ฟเวอร์เริ่มทำงาน** และ Agent Builder เปิดขึ้น  
4. **ทดสอบเซิร์ฟเวอร์ weather MCP ของคุณ** ด้วยคำสั่งภาษาธรรมชาติ  

ใส่คำสั่งแบบนี้  

SYSTEM_PROMPT  

```
You are my weather assistant
```  

USER_PROMPT  

```
How's the weather like in Seattle
```  

![Agent Builder Debug Result](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.th.png)  

### ขั้นตอนที่ 8: ดีบักด้วย MCP Inspector

1. **ใช้การตั้งค่า "Debug in Inspector"** (Edge หรือ Chrome)  
2. **เปิดอินเทอร์เฟซ Inspector** ที่ `http://localhost:6274`  
3. **สำรวจสภาพแวดล้อมทดสอบแบบโต้ตอบ:**  
   - ดูเครื่องมือที่มี  
   - ทดสอบการทำงานของเครื่องมือ  
   - ตรวจสอบคำขอเครือข่าย  
   - ดีบักการตอบสนองของเซิร์ฟเวอร์  

![MCP Inspector Interface](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.th.png)  

---

## 🎯 ผลลัพธ์การเรียนรู้หลัก

เมื่อทำแลปนี้เสร็จ คุณได้:

- [x] **สร้างเซิร์ฟเวอร์ MCP แบบกำหนดเอง** โดยใช้เทมเพลต AI Toolkit  
- [x] **อัปเกรดเป็น MCP SDK เวอร์ชันล่าสุด** (v1.9.3) เพื่อฟังก์ชันที่ดีขึ้น  
- [x] **ตั้งค่ากระบวนการดีบักแบบมืออาชีพ** ทั้งใน Agent Builder และ Inspector  
- [x] **ติดตั้ง MCP Inspector** สำหรับทดสอบเซิร์ฟเวอร์แบบโต้ตอบ  
- [x] **เชี่ยวชาญการตั้งค่าดีบักใน VS Code** สำหรับการพัฒนา MCP  

## 🔧 ฟีเจอร์ขั้นสูงที่สำรวจ

| ฟีเจอร์ | คำอธิบาย | กรณีการใช้งาน |  
|---------|-------------|----------|  
| **MCP Python SDK v1.9.3** | การใช้งานโปรโตคอลเวอร์ชันล่าสุด | การพัฒนาเซิร์ฟเวอร์สมัยใหม่ |  
| **MCP Inspector 0.14.0** | เครื่องมือดีบักแบบโต้ตอบ | การทดสอบเซิร์ฟเวอร์แบบเรียลไทม์ |  
| **VS Code Debugging** | สภาพแวดล้อมพัฒนาแบบครบวงจร | กระบวนการดีบักแบบมืออาชีพ |  
| **Agent Builder Integration** | การเชื่อมต่อ AI Toolkit โดยตรง | การทดสอบเอเย่นต์ครบวงจร |  

## 📚 แหล่งข้อมูลเพิ่มเติม

- [MCP Python SDK Documentation](https://modelcontextprotocol.io/docs/sdk/python)  
- [AI Toolkit Extension Guide](https://code.visualstudio.com/docs/ai/ai-toolkit)  
- [VS Code Debugging Documentation](https://code.visualstudio.com/docs/editor/debugging)  
- [Model Context Protocol Specification](https://modelcontextprotocol.io/docs/concepts/architecture)  

---

**🎉 ขอแสดงความยินดี!** คุณได้ผ่านแลป 3 อย่างสมบูรณ์และพร้อมที่จะสร้าง ดีบัก และปรับใช้เซิร์ฟเวอร์ MCP แบบกำหนดเองด้วยกระบวนการพัฒนาระดับมืออาชีพ  

### 🔜 ไปยังโมดูลถัดไป

พร้อมที่จะนำทักษะ MCP ไปใช้ในกระบวนการพัฒนาจริงหรือยัง? ไปต่อที่ **[Module 4: Practical MCP Development - Custom GitHub Clone Server](../lab4/README.md)** ซึ่งคุณจะ:  
- สร้างเซิร์ฟเวอร์ MCP ที่พร้อมใช้งานจริงสำหรับการจัดการรีโพซิทอรี GitHub  
- นำฟังก์ชันโคลนรีโพซิทอรี GitHub ผ่าน MCP มาใช้  
- เชื่อมต่อเซิร์ฟเวอร์ MCP แบบกำหนดเองกับ VS Code และ GitHub Copilot Agent Mode  
- ทดสอบและปรับใช้เซิร์ฟเวอร์ MCP แบบกำหนดเองในสภาพแวดล้อมจริง  
- เรียนรู้การอัตโนมัติกระบวนการทำงานสำหรับนักพัฒนาอย่างมีประสิทธิภาพ

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยมืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดขึ้นจากการใช้การแปลนี้