<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-10T06:19:56+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "sr"
}
-->
# 🔧 Modul 3: Napredni razvoj MCP-a sa AI Toolkit-om

![Duration](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)  
![AI Toolkit](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)  
![Python](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)  
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)  
![Inspector](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)  

## 🎯 Ciljevi učenja

Na kraju ovog laboratorijskog zadatka bićete u stanju da:

- ✅ Kreirate prilagođene MCP servere koristeći AI Toolkit  
- ✅ Konfigurišete i koristite najnoviji MCP Python SDK (v1.9.3)  
- ✅ Postavite i koristite MCP Inspector za otklanjanje grešaka  
- ✅ Otklanjate greške MCP servera u okruženjima Agent Builder i Inspector  
- ✅ Razumete napredne tokove rada u razvoju MCP servera  

## 📋 Preduslovi

- Završetak laboratorije 2 (MCP Osnove)  
- VS Code sa instaliranim AI Toolkit dodatkom  
- Python 3.10+ okruženje  
- Node.js i npm za podešavanje Inspectora  

## 🏗️ Šta ćete napraviti

U ovoj laboratoriji kreiraćete **Weather MCP Server** koji prikazuje:  
- Implementaciju prilagođenog MCP servera  
- Integraciju sa AI Toolkit Agent Builder-om  
- Profesionalne tokove rada za otklanjanje grešaka  
- Moderne obrasce korišćenja MCP SDK-a  

---

## 🔧 Pregled osnovnih komponenti

### 🐍 MCP Python SDK  
Model Context Protocol Python SDK pruža osnovu za pravljenje prilagođenih MCP servera. Koristićete verziju 1.9.3 sa unapređenim mogućnostima za otklanjanje grešaka.

### 🔍 MCP Inspector  
Snažan alat za otklanjanje grešaka koji nudi:  
- Praćenje servera u realnom vremenu  
- Vizualizaciju izvršavanja alata  
- Inspekciju mrežnih zahteva/odgovora  
- Interaktivno testno okruženje  

---

## 📖 Korak po korak implementacija

### Korak 1: Kreirajte WeatherAgent u Agent Builder-u

1. **Pokrenite Agent Builder** u VS Code-u preko AI Toolkit dodatka  
2. **Kreirajte novog agenta** sa sledećom konfiguracijom:  
   - Ime agenta: `WeatherAgent`  

![Agent Creation](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.sr.png)

### Korak 2: Inicijalizujte MCP Server projekat

1. **Idite na Tools** → **Add Tool** u Agent Builder-u  
2. **Izaberite "MCP Server"** iz ponuđenih opcija  
3. **Izaberite "Create A new MCP Server"**  
4. **Odaberite `python-weather` šablon**  
5. **Imenujte svoj server:** `weather_mcp`  

![Python Template Selection](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.sr.png)

### Korak 3: Otvorite i pregledajte projekat

1. **Otvorite generisani projekat** u VS Code-u  
2. **Pregledajte strukturu projekta:**  
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

### Korak 4: Nadogradnja na najnoviji MCP SDK

> **🔍 Zašto nadogradnja?** Želimo da koristimo najnoviji MCP SDK (v1.9.3) i Inspector servis (0.14.0) za dodatne funkcionalnosti i bolje mogućnosti otklanjanja grešaka.

#### 4a. Ažurirajte Python zavisnosti

**Izmenite `pyproject.toml`:** update [./code/weather_mcp/pyproject.toml](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/pyproject.toml)


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

**Izmenite `.vscode/tasks.json`:**

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

## 🚀 Pokretanje i testiranje MCP servera

### Korak 6: Instalirajte zavisnosti

Nakon što izvršite izmene u konfiguraciji, pokrenite sledeće komande:

**Instalirajte Python zavisnosti:**  
```bash
uv sync
```

**Instalirajte zavisnosti za Inspector:**  
```bash
cd inspector
npm install
```

### Korak 7: Otklanjanje grešaka sa Agent Builder-om

1. **Pritisnite F5** ili koristite konfiguraciju **"Debug in Agent Builder"**  
2. **Izaberite compound konfiguraciju** u debug panelu  
3. **Sačekajte da server startuje** i da se otvori Agent Builder  
4. **Testirajte svoj weather MCP server** koristeći upite na prirodnom jeziku  

Unesite upit kao u primeru:

SYSTEM_PROMPT

```
You are my weather assistant
```

USER_PROMPT

```
How's the weather like in Seattle
```

![Agent Builder Debug Result](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.sr.png)

### Korak 8: Otklanjanje grešaka sa MCP Inspector-om

1. **Koristite konfiguraciju "Debug in Inspector"** (Edge ili Chrome)  
2. **Otvorite Inspector interfejs** na adresi `http://localhost:6274`  
3. **Istražite interaktivno testno okruženje:**  
   - Pregled dostupnih alata  
   - Testiranje izvršenja alata  
   - Praćenje mrežnih zahteva  
   - Otklanjanje grešaka odgovora servera  

![MCP Inspector Interface](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.sr.png)

---

## 🎯 Ključni ishodi učenja

Završetkom ove laboratorije ste:

- [x] **Kreirali prilagođeni MCP server** koristeći AI Toolkit šablone  
- [x] **Nadogradili na najnoviji MCP SDK** (v1.9.3) za unapređenu funkcionalnost  
- [x] **Konfigurisali profesionalne tokove za otklanjanje grešaka** za Agent Builder i Inspector  
- [x] **Postavili MCP Inspector** za interaktivno testiranje servera  
- [x] **Savladali VS Code konfiguracije za otklanjanje grešaka** u razvoju MCP-a  

## 🔧 Istražene napredne funkcije

| Funkcija               | Opis                             | Primer upotrebe               |
|-----------------------|---------------------------------|------------------------------|
| **MCP Python SDK v1.9.3** | Najnovija implementacija protokola | Savremeni razvoj servera      |
| **MCP Inspector 0.14.0**   | Interaktivni alat za otklanjanje grešaka | Testiranje servera u realnom vremenu |
| **VS Code Debugging**      | Integrisano razvojno okruženje   | Profesionalni tok otklanjanja grešaka |
| **Agent Builder Integration** | Direktna veza sa AI Toolkit-om | End-to-end testiranje agenta  |

## 📚 Dodatni resursi

- [MCP Python SDK Dokumentacija](https://modelcontextprotocol.io/docs/sdk/python)  
- [AI Toolkit Uputstvo za dodatak](https://code.visualstudio.com/docs/ai/ai-toolkit)  
- [VS Code Dokumentacija za otklanjanje grešaka](https://code.visualstudio.com/docs/editor/debugging)  
- [Model Context Protocol Specifikacija](https://modelcontextprotocol.io/docs/concepts/architecture)  

---

**🎉 Čestitamo!** Uspešno ste završili laboratoriju 3 i sada možete kreirati, otklanjati greške i implementirati prilagođene MCP servere koristeći profesionalne tokove rada.

### 🔜 Nastavite na sledeći modul

Spremni da primenite svoje MCP veštine u realnom razvojnom okruženju? Nastavite na **[Modul 4: Praktični MCP razvoj - Prilagođeni GitHub Clone Server](../lab4/README.md)** gde ćete:  
- Izgraditi MCP server spreman za produkciju koji automatizuje operacije sa GitHub repozitorijumima  
- Implementirati funkcionalnost kloniranja GitHub repozitorijuma preko MCP-a  
- Integrisati prilagođene MCP servere sa VS Code i GitHub Copilot Agent modom  
- Testirati i implementirati prilagođene MCP servere u produkcionim okruženjima  
- Naučiti praktičnu automatizaciju tokova rada za programere

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да превод буде прецизан, молимо вас да имате у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне интерпретације настале употребом овог превода.