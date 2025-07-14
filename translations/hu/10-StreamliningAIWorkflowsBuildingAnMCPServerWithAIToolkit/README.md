<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:12:27+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "hu"
}
-->
# AI Munkafolyamatok Egyszerűsítése: MCP Szerver Építése AI Toolkit-kel

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.hu.png)

## 🎯 Áttekintés

Üdvözlünk a **Model Context Protocol (MCP) Workshopon**! Ez a gyakorlati, átfogó workshop két élvonalbeli technológiát ötvöz, hogy forradalmasítsa az AI alkalmazásfejlesztést:

- **🔗 Model Context Protocol (MCP)**: Nyílt szabvány az AI-eszközök zökkenőmentes integrációjához
- **🛠️ AI Toolkit a Visual Studio Code-hoz (AITK)**: A Microsoft erőteljes AI fejlesztői bővítménye

### 🎓 Mit fogsz megtanulni

A workshop végére elsajátítod az intelligens alkalmazások építésének művészetét, amelyek összekapcsolják az AI modelleket a valós eszközökkel és szolgáltatásokkal. Az automatizált teszteléstől a testreszabott API integrációkig gyakorlati tudást szerzel összetett üzleti kihívások megoldásához.

## 🏗️ Technológiai Stack

### 🔌 Model Context Protocol (MCP)

Az MCP az **„AI USB-C-je”** – egy univerzális szabvány, amely összeköti az AI modelleket külső eszközökkel és adatforrásokkal.

**✨ Főbb jellemzők:**
- 🔄 **Szabványosított integráció**: Egységes felület az AI-eszközök csatlakoztatásához
- 🏛️ **Rugalmas architektúra**: Helyi és távoli szerverek stdio/SSE kapcsolaton keresztül
- 🧰 **Gazdag ökoszisztéma**: Eszközök, promptok és erőforrások egy protokollban
- 🔒 **Vállalati szintű biztonság**: Beépített biztonság és megbízhatóság

**🎯 Miért fontos az MCP:**
Ahogy az USB-C véget vetett a kábelrengetegnek, az MCP egyszerűsíti az AI integrációk bonyolultságát. Egy protokoll, végtelen lehetőség.

### 🤖 AI Toolkit a Visual Studio Code-hoz (AITK)

A Microsoft zászlóshajó AI fejlesztői bővítménye, amely a VS Code-ot AI erőművé alakítja.

**🚀 Fő képességek:**
- 📦 **Modell katalógus**: Hozzáférés Azure AI, GitHub, Hugging Face, Ollama modellekhez
- ⚡ **Helyi inferencia**: ONNX-optimalizált CPU/GPU/NPU futtatás
- 🏗️ **Agent Builder**: Vizualizált AI ügynök fejlesztés MCP integrációval
- 🎭 **Többmodalitás**: Szöveg, látás és strukturált kimenet támogatás

**💡 Fejlesztési előnyök:**
- Konfiguráció nélküli modell telepítés
- Vizualizált prompt tervezés
- Valós idejű tesztelési környezet
- Zökkenőmentes MCP szerver integráció

## 📚 Tanulási Út

### [🚀 1. modul: AI Toolkit Alapok](./lab1/README.md)
**Időtartam**: 15 perc
- 🛠️ AI Toolkit telepítése és beállítása VS Code-ban
- 🗂️ Modell katalógus felfedezése (100+ modell GitHubról, ONNX-ről, OpenAI-ról, Anthropicról, Google-ről)
- 🎮 Interaktív játszótér elsajátítása valós idejű modell teszteléshez
- 🤖 Első AI ügynök építése Agent Builderrel
- 📊 Modell teljesítményének értékelése beépített metrikákkal (F1, relevancia, hasonlóság, koherencia)
- ⚡ Batch feldolgozás és többmodalitás támogatásának megismerése

**🎯 Tanulási eredmény**: Működő AI ügynök létrehozása az AITK képességeinek átfogó ismeretével

### [🌐 2. modul: MCP az AI Toolkit Alapjaival](./lab2/README.md)
**Időtartam**: 20 perc
- 🧠 Model Context Protocol (MCP) architektúra és alapfogalmak elsajátítása
- 🌐 Microsoft MCP szerver ökoszisztéma felfedezése
- 🤖 Böngésző automatizációs ügynök építése Playwright MCP szerverrel
- 🔧 MCP szerverek integrálása AI Toolkit Agent Builderrel
- 📊 MCP eszközök konfigurálása és tesztelése az ügynökökben
- 🚀 MCP-alapú ügynökök exportálása és éles környezetbe telepítése

**🎯 Tanulási eredmény**: Külső eszközökkel felturbózott AI ügynök telepítése MCP-n keresztül

### [🔧 3. modul: Haladó MCP Fejlesztés AI Toolkit-kel](./lab3/README.md)
**Időtartam**: 20 perc
- 💻 Egyedi MCP szerverek létrehozása AI Toolkit segítségével
- 🐍 Legújabb MCP Python SDK (v1.9.3) konfigurálása és használata
- 🔍 MCP Inspector beállítása és használata hibakereséshez
- 🛠️ Időjárás MCP szerver építése professzionális hibakeresési munkafolyamatokkal
- 🧪 MCP szerverek hibakeresése Agent Builder és Inspector környezetben

**🎯 Tanulási eredmény**: Egyedi MCP szerverek fejlesztése és hibakeresése modern eszközökkel

### [🐙 4. modul: Gyakorlati MCP Fejlesztés – Egyedi GitHub Clone Szerver](./lab4/README.md)
**Időtartam**: 30 perc
- 🏗️ Valós GitHub Clone MCP szerver építése fejlesztési munkafolyamatokhoz
- 🔄 Intelligens repository klónozás megvalósítása validációval és hibakezeléssel
- 📁 Intelligens könyvtárkezelés és VS Code integráció létrehozása
- 🤖 GitHub Copilot Agent Mode használata egyedi MCP eszközökkel
- 🛡️ Éles környezetre alkalmas megbízhatóság és platformfüggetlenség alkalmazása

**🎯 Tanulási eredmény**: Éles környezetbe telepíthető MCP szerver, amely egyszerűsíti a valódi fejlesztési munkafolyamatokat

## 💡 Valós Alkalmazások és Hatás

### 🏢 Vállalati Felhasználási Esetek

#### 🔄 DevOps Automatizálás
Fejlesztési munkafolyamatod intelligens automatizálással alakítsd át:
- **Okos repository kezelés**: AI-alapú kódáttekintés és összeolvasztási döntések
- **Intelligens CI/CD**: Automatikus pipeline optimalizálás kódváltozások alapján
- **Hibakezelés**: Automatikus hibakategorizálás és hozzárendelés

#### 🧪 Minőségbiztosítás Forradalma
Emeld a tesztelést AI-alapú automatizálással:
- **Intelligens tesztgenerálás**: Teljes körű tesztsorozatok automatikus létrehozása
- **Vizuális regressziós tesztelés**: AI-alapú UI változásérzékelés
- **Teljesítményfigyelés**: Proaktív problémafelismerés és megoldás

#### 📊 Adatfolyam Intelligencia
Okosabb adatfeldolgozási munkafolyamatok építése:
- **Adaptív ETL folyamatok**: Önoptimalizáló adattranszformációk
- **Anomália felismerés**: Valós idejű adatminőség-ellenőrzés
- **Intelligens irányítás**: Okos adatáramlás menedzsment

#### 🎧 Ügyfélélmény Javítása
Kivételes ügyfélkapcsolatok létrehozása:
- **Kontextusérzékeny támogatás**: AI ügynökök hozzáféréssel az ügyfél előzményekhez
- **Proaktív problémamegoldás**: Előrejelző ügyfélszolgálat
- **Többcsatornás integráció**: Egységes AI élmény platformokon átívelően

## 🛠️ Előfeltételek és Beállítás

### 💻 Rendszerkövetelmények

| Összetevő | Követelmény | Megjegyzés |
|-----------|-------------|------------|
| **Operációs rendszer** | Windows 10+, macOS 10.15+, Linux | Bármely modern OS |
| **Visual Studio Code** | Legfrissebb stabil verzió | Szükséges az AITK-hoz |
| **Node.js** | v18.0+ és npm | MCP szerver fejlesztéshez |
| **Python** | 3.10+ | Opcionális Python MCP szerverekhez |
| **Memória** | Minimum 8GB RAM | 16GB ajánlott helyi modellekhez |

### 🔧 Fejlesztői Környezet

#### Ajánlott VS Code Bővítmények
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) – opcionális, de hasznos

#### Opcionális Eszközök
- **uv**: Modern Python csomagkezelő
- **MCP Inspector**: Vizualizált hibakereső eszköz MCP szerverekhez
- **Playwright**: Web automatizációs példákhoz

## 🎖️ Tanulási Eredmények és Tanúsítási Út

### 🏆 Készségfejlesztési Ellenőrzőlista

A workshop elvégzése után mesteri szintre jutsz:

#### 🎯 Alapkészségek
- [ ] **MCP Protokoll Mélyismeret**: Architektúra és megvalósítási minták alapos ismerete
- [ ] **AITK Jártasság**: AI Toolkit szakértői használata gyors fejlesztéshez
- [ ] **Egyedi Szerverfejlesztés**: MCP szerverek építése, telepítése és karbantartása
- [ ] **Eszközintegráció Kiválóság**: AI zökkenőmentes összekapcsolása meglévő fejlesztési folyamatokkal
- [ ] **Problémamegoldó Alkalmazás**: Megtanult készségek alkalmazása valós üzleti kihívásokra

#### 🔧 Technikai Készségek
- [ ] AI Toolkit beállítása és konfigurálása VS Code-ban
- [ ] Egyedi MCP szerverek tervezése és megvalósítása
- [ ] GitHub modellek integrálása MCP architektúrába
- [ ] Automatizált tesztelési munkafolyamatok építése Playwright-tal
- [ ] AI ügynökök éles környezetbe telepítése
- [ ] MCP szerverek hibakeresése és optimalizálása

#### 🚀 Haladó Képességek
- [ ] Vállalati szintű AI integrációk tervezése
- [ ] Biztonsági legjobb gyakorlatok megvalósítása AI alkalmazásokban
- [ ] Skálázható MCP szerver architektúrák tervezése
- [ ] Egyedi eszközláncok létrehozása speciális területekre
- [ ] Mások mentorálása AI-natív fejlesztésben

## 📖 További Források
- [MCP Specifikáció](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Tároló](https://github.com/microsoft/vscode-ai-toolkit)
- [MCP Szerverek Minta Gyűjteménye](https://github.com/modelcontextprotocol/servers)
- [Legjobb Gyakorlatok Útmutató](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Készen állsz, hogy forradalmasítsd AI fejlesztési munkafolyamatodat?**

Építsük együtt az intelligens alkalmazások jövőjét MCP-vel és AI Toolkit-kel!

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.