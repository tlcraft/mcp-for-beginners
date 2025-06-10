<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-10T06:03:39+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "fa"
}
-->
# 🔧 ماژول ۳: توسعه پیشرفته MCP با مجموعه ابزار هوش مصنوعی

![مدت زمان](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)
![مجموعه ابزار هوش مصنوعی](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)
![پایتون](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)
![بازرس](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)

## 🎯 اهداف یادگیری

در پایان این آزمایشگاه، قادر خواهید بود:

- ✅ سرورهای سفارشی MCP را با استفاده از مجموعه ابزار هوش مصنوعی بسازید
- ✅ SDK پایتون MCP نسخه ۱.۹.۳ را پیکربندی و استفاده کنید
- ✅ بازرس MCP را برای اشکال‌زدایی راه‌اندازی و به کار ببرید
- ✅ سرورهای MCP را در محیط‌های Agent Builder و Inspector اشکال‌زدایی کنید
- ✅ جریان‌های کاری توسعه پیشرفته سرور MCP را درک کنید

## 📋 پیش‌نیازها

- تکمیل آزمایشگاه ۲ (مبانی MCP)
- نصب افزونه AI Toolkit در VS Code
- محیط پایتون نسخه ۳.۱۰ یا بالاتر
- نصب Node.js و npm برای راه‌اندازی Inspector

## 🏗️ آنچه خواهید ساخت

در این آزمایشگاه، یک **سرور MCP هواشناسی** ایجاد خواهید کرد که موارد زیر را نشان می‌دهد:
- پیاده‌سازی سرور سفارشی MCP
- ادغام با Agent Builder مجموعه ابزار هوش مصنوعی
- جریان‌های کاری حرفه‌ای اشکال‌زدایی
- الگوهای استفاده مدرن از SDK MCP

---

## 🔧 مرور اجزای اصلی

### 🐍 SDK پایتون MCP
SDK پایتون پروتکل مدل کانتکست پایه‌ای برای ساخت سرورهای سفارشی MCP فراهم می‌کند. شما از نسخه ۱.۹.۳ با قابلیت‌های پیشرفته اشکال‌زدایی استفاده خواهید کرد.

### 🔍 بازرس MCP
ابزار قدرتمند اشکال‌زدایی که امکانات زیر را ارائه می‌دهد:
- نظارت زنده سرور
- نمایش اجرای ابزارها
- بررسی درخواست‌ها و پاسخ‌های شبکه
- محیط تست تعاملی

---

## 📖 پیاده‌سازی گام‌به‌گام

### گام ۱: ایجاد WeatherAgent در Agent Builder

1. **Agent Builder را در VS Code از طریق افزونه AI Toolkit باز کنید**
2. **یک Agent جدید با پیکربندی زیر بسازید:**
   - نام Agent: `WeatherAgent`

![ایجاد Agent](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.fa.png)

### گام ۲: راه‌اندازی پروژه سرور MCP

1. **در Agent Builder به Tools → Add Tool بروید**
2. **گزینه "MCP Server" را انتخاب کنید**
3. **گزینه "Create A new MCP Server" را انتخاب کنید**
4. **قالب `python-weather` را انتخاب کنید**
5. **نام سرور خود را وارد کنید:** `weather_mcp`

![انتخاب قالب پایتون](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.fa.png)

### گام ۳: باز کردن و بررسی پروژه

1. **پروژه ایجاد شده را در VS Code باز کنید**
2. **ساختار پروژه را مرور کنید:**
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

### گام ۴: ارتقا به آخرین نسخه MCP SDK

> **🔍 چرا ارتقا؟** می‌خواهیم از آخرین نسخه MCP SDK (v1.9.3) و سرویس Inspector (0.14.0) برای امکانات بیشتر و اشکال‌زدایی بهتر استفاده کنیم.

#### ۴a. به‌روزرسانی وابستگی‌های پایتون

**فایل‌های `pyproject.toml`:** update [./code/weather_mcp/pyproject.toml](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/pyproject.toml)


#### 4b. Update Inspector Configuration

**Edit `inspector/package.json`:** update [./code/weather_mcp/inspector/package.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package.json)

#### 4c. Update Inspector Dependencies

**Edit `inspector/package-lock.json`:** update [./code/weather_mcp/inspector/package-lock.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package-lock.json)

> **📝 Note:** This file contains extensive dependency definitions. Below is the essential structure - the full content ensures proper dependency resolution.


> **⚡ Full Package Lock:** The complete package-lock.json contains ~3000 lines of dependency definitions. The above shows the key structure - use the provided file for complete dependency resolution.

### Step 5: Configure VS Code Debugging

*Note: Please copy the file in the specified path to replace the corresponding local file*

#### 5a. Update Launch Configuration

**Edit `.vscode/launch.json` را ویرایش کنید:**

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

**فایل `.vscode/tasks.json` را ویرایش کنید:**

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

## 🚀 اجرای سرور MCP و تست آن

### گام ۶: نصب وابستگی‌ها

پس از اعمال تغییرات پیکربندی، دستورات زیر را اجرا کنید:

**نصب وابستگی‌های پایتون:**
```bash
uv sync
```

**نصب وابستگی‌های Inspector:**
```bash
cd inspector
npm install
```

### گام ۷: اشکال‌زدایی با Agent Builder

1. **کلید F5 را فشار دهید یا از پیکربندی "Debug in Agent Builder" استفاده کنید**
2. **پیکربندی ترکیبی را از پنل اشکال‌زدایی انتخاب کنید**
3. **منتظر بمانید تا سرور شروع به کار کند و Agent Builder باز شود**
4. **سرور MCP هواشناسی خود را با پرسش‌های زبان طبیعی تست کنید**

ورودی به شکل زیر است

SYSTEM_PROMPT

```
You are my weather assistant
```

USER_PROMPT

```
How's the weather like in Seattle
```

![نتیجه اشکال‌زدایی Agent Builder](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.fa.png)

### گام ۸: اشکال‌زدایی با MCP Inspector

1. **از پیکربندی "Debug in Inspector" استفاده کنید (Edge یا Chrome)**
2. **رابط Inspector را در آدرس `http://localhost:6274` باز کنید**
3. **محیط تست تعاملی را کاوش کنید:**
   - مشاهده ابزارهای موجود
   - تست اجرای ابزارها
   - نظارت بر درخواست‌های شبکه
   - اشکال‌زدایی پاسخ‌های سرور

![رابط MCP Inspector](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.fa.png)

---

## 🎯 نتایج کلیدی یادگیری

با اتمام این آزمایشگاه، شما:

- [x] **سرور MCP سفارشی** با استفاده از قالب‌های AI Toolkit ساخته‌اید
- [x] **به آخرین نسخه MCP SDK** (v1.9.3) برای قابلیت‌های پیشرفته ارتقا داده‌اید
- [x] **جریان‌های کاری اشکال‌زدایی حرفه‌ای** را برای Agent Builder و Inspector پیکربندی کرده‌اید
- [x] **بازرس MCP را برای تست تعاملی سرور راه‌اندازی کرده‌اید**
- [x] **پیکربندی‌های اشکال‌زدایی VS Code را برای توسعه MCP تسلط یافته‌اید**

## 🔧 ویژگی‌های پیشرفته بررسی شده

| ویژگی | توضیحات | کاربرد |
|---------|-------------|----------|
| **SDK پایتون MCP نسخه ۱.۹.۳** | پیاده‌سازی آخرین پروتکل | توسعه سرور مدرن |
| **بازرس MCP نسخه ۰.۱۴.۰** | ابزار اشکال‌زدایی تعاملی | تست زنده سرور |
| **اشکال‌زدایی VS Code** | محیط توسعه یکپارچه | جریان کاری اشکال‌زدایی حرفه‌ای |
| **ادغام Agent Builder** | اتصال مستقیم به AI Toolkit | تست کامل Agent |

## 📚 منابع بیشتر

- [مستندات SDK پایتون MCP](https://modelcontextprotocol.io/docs/sdk/python)
- [راهنمای افزونه AI Toolkit](https://code.visualstudio.com/docs/ai/ai-toolkit)
- [مستندات اشکال‌زدایی VS Code](https://code.visualstudio.com/docs/editor/debugging)
- [مشخصات پروتکل مدل کانتکست](https://modelcontextprotocol.io/docs/concepts/architecture)

---

**🎉 تبریک!** شما با موفقیت آزمایشگاه ۳ را به پایان رسانده‌اید و اکنون می‌توانید سرورهای سفارشی MCP را با جریان‌های کاری حرفه‌ای توسعه، اشکال‌زدایی و مستقر کنید.

### 🔜 ادامه به ماژول بعدی

آماده‌اید مهارت‌های MCP خود را در جریان توسعه دنیای واقعی به کار ببرید؟ به **[ماژول ۴: توسعه عملی MCP - سرور کلون سفارشی GitHub](../lab4/README.md)** بروید، جایی که شما:
- سرور MCP آماده تولید می‌سازید که عملیات مخزن GitHub را خودکار می‌کند
- قابلیت کلون کردن مخزن GitHub را از طریق MCP پیاده‌سازی می‌کنید
- سرورهای سفارشی MCP را با VS Code و حالت Agent GitHub Copilot ادغام می‌کنید
- سرورهای سفارشی MCP را در محیط‌های تولید تست و مستقر می‌کنید
- جریان کاری اتوماسیون عملی برای توسعه‌دهندگان را می‌آموزید

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان مادری خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوء تفاهم یا تفسیر نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.