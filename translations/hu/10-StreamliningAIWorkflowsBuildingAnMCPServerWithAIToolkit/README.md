<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T05:03:17+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "hu"
}
-->
# Streamlining AI Workflows: Building an MCP Server with AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.hu.png)

## 🎯 Áttekintés

Üdvözlünk a **Model Context Protocol (MCP) Workshopon**! Ez a gyakorlati workshop két élvonalbeli technológiát ötvöz, hogy forradalmasítsa az AI-alkalmazások fejlesztését:

- **🔗 Model Context Protocol (MCP)**: Nyílt szabvány az AI-eszközök zökkenőmentes integrációjához
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: A Microsoft erőteljes AI fejlesztői bővítménye

### 🎓 Mit tanulhatsz meg

A workshop végére elsajátítod az intelligens alkalmazások építését, amelyek összekapcsolják az AI modelleket a valós eszközökkel és szolgáltatásokkal. Az automatizált teszteléstől a testreszabott API integrációkig gyakorlati készségeket szerzel a komplex üzleti kihívások megoldásához.

## 🏗️ Technológiai környezet

### 🔌 Model Context Protocol (MCP)

Az MCP az **"USB-C az AI-nek"** – egy univerzális szabvány, amely összeköti az AI modelleket külső eszközökkel és adatforrásokkal.

**✨ Főbb jellemzők:**
- 🔄 **Szabványos integráció**: Egységes felület az AI-eszközök csatlakoztatásához
- 🏛️ **Rugalmas architektúra**: Helyi és távoli szerverek stdio/SSE kapcsolaton keresztül
- 🧰 **Gazdag ökoszisztéma**: Eszközök, promptok és erőforrások egy protokollban
- 🔒 **Vállalati szintű biztonság**: Beépített megbízhatóság és védelem

**🎯 Miért fontos az MCP:**
Ahogy az USB-C véget vetett a kábelrengetegnek, úgy az MCP egyszerűsíti az AI integrációk bonyolultságát. Egy protokoll, végtelen lehetőségek.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

A Microsoft zászlóshajó AI fejlesztői bővítménye, amely a VS Code-ot AI erőművé alakítja.

**🚀 Fő képességek:**
- 📦 **Modellkatalógus**: Hozzáférés Azure AI, GitHub, Hugging Face, Ollama modellekhez
- ⚡ **Helyi inferencia**: ONNX-optimalizált CPU/GPU/NPU futtatás
- 🏗️ **Agent Builder**: Vizualizált AI ügynök fejlesztés MCP integrációval
- 🎭 **Többmodalitás**: Szöveg, kép és strukturált kimenet támogatás

**💡 Fejlesztési előnyök:**
- Konfiguráció nélküli modelltelepítés
- Vizualizált prompt tervezés
- Valós idejű tesztelési környezet
- Zökkenőmentes MCP szerver integráció

## 📚 Tanulási út

### [🚀 Modul 1: AI Toolkit alapok](./lab1/README.md)
**Időtartam**: 15 perc
- 🛠️ AI Toolkit telepítése és beállítása VS Code-ban
- 🗂️ Modellkatalógus felfedezése (100+ modell GitHubról, ONNX, OpenAI, Anthropic, Google)
- 🎮 Interaktív játszótér használata valós idejű modelltesztekhez
- 🤖 Első AI ügynök építése az Agent Builderrel
- 📊 Modell teljesítményének értékelése beépített metrikákkal (F1, relevancia, hasonlóság, koherencia)
- ⚡ Batch feldolgozás és többmodalitás támogatás elsajátítása

**🎯 Tanulási eredmény**: Működő AI ügynök létrehozása az AITK képességeinek alapos ismeretével

### [🌐 Modul 2: MCP az AI Toolkit alapjaival](./lab2/README.md)
**Időtartam**: 20 perc
- 🧠 Model Context Protocol (MCP) architektúra és fogalmak elsajátítása
- 🌐 Microsoft MCP szerver ökoszisztéma felfedezése
- 🤖 Böngésző automatizációs ügynök építése Playwright MCP szerverrel
- 🔧 MCP szerverek integrálása az AI Toolkit Agent Builderrel
- 📊 MCP eszközök konfigurálása és tesztelése az ügynökökben
- 🚀 MCP-alapú ügynökök exportálása és éles környezetbe telepítése

**🎯 Tanulási eredmény**: Külső eszközökkel felturbózott AI ügynök telepítése MCP segítségével

### [🔧 Modul 3: Haladó MCP fejlesztés AI Toolkit segítségével](./lab3/README.md)
**Időtartam**: 20 perc
- 💻 Egyedi MCP szerverek létrehozása AI Toolkit használatával
- 🐍 Legújabb MCP Python SDK (v1.9.3) konfigurálása és használata
- 🔍 MCP Inspector beállítása és használata hibakereséshez
- 🛠️ Időjárás MCP szerver építése professzionális hibakeresési folyamatokkal
- 🧪 MCP szerverek hibakeresése Agent Builder és Inspector környezetben

**🎯 Tanulási eredmény**: Egyedi MCP szerverek fejlesztése és hibakeresése modern eszközökkel

### [🐙 Modul 4: Gyakorlati MCP fejlesztés - Egyedi GitHub Clone szerver](./lab4/README.md)
**Időtartam**: 30 perc
- 🏗️ Valós GitHub Clone MCP szerver építése fejlesztési munkafolyamatokhoz
- 🔄 Okos repozitórium klónozás megvalósítása validálással és hibakezeléssel
- 📁 Intelligens könyvtárkezelés és VS Code integráció létrehozása
- 🤖 GitHub Copilot Agent Mode használata egyedi MCP eszközökkel
- 🛡️ Éles környezetbe alkalmas megbízhatóság és platformfüggetlenség alkalmazása

**🎯 Tanulási eredmény**: Éles környezetbe telepíthető MCP szerver létrehozása, amely egyszerűsíti a valódi fejlesztési munkafolyamatokat


## 💡 Valós alkalmazások és hatás

### 🏢 Vállalati felhasználási esetek

#### 🔄 DevOps automatizáció
Fejlessze fejlesztési folyamatait intelligens automatizálással:
- **Okos repozitórium-kezelés**: AI-alapú kódáttekintés és merge döntések
- **Intelligens CI/CD**: Automatikus pipeline optimalizálás kódváltozások alapján
- **Hibák osztályozása**: Automatikus hibabesorolás és feladatkiosztás

#### 🧪 Minőségbiztosítás forradalma
Emelje új szintre a tesztelést AI-alapú automatizálással:
- **Intelligens tesztgenerálás**: Teljes tesztcsomagok automatikus létrehozása
- **Vizualis regressziós tesztelés**: AI-alapú UI változásészlelés
- **Teljesítményfigyelés**: Proaktív problémafelismerés és megoldás

#### 📊 Adatfeldolgozási intelligencia
Okosabb adatfeldolgozási munkafolyamatok építése:
- **Adaptív ETL folyamatok**: Önoptimalizáló adattranszformációk
- **Anomáliaészlelés**: Valós idejű adatminőség-ellenőrzés
- **Intelligens adatirányítás**: Okos adatáramlás kezelése

#### 🎧 Ügyfélélmény javítása
Kivételes ügyfélkapcsolatok létrehozása:
- **Kontextusérzékeny támogatás**: AI ügynökök ügyféltörténethez való hozzáféréssel
- **Proaktív problémamegoldás**: Előrejelző ügyfélszolgálat
- **Többcsatornás integráció**: Egységes AI élmény különböző platformokon


## 🛠️ Előfeltételek és beállítás

### 💻 Rendszerkövetelmények

| Komponens | Követelmény | Megjegyzés |
|-----------|-------------|------------|
| **Operációs rendszer** | Windows 10+, macOS 10.15+, Linux | Bármely modern rendszer |
| **Visual Studio Code** | Legfrissebb stabil verzió | Szükséges az AITK-hoz |
| **Node.js** | v18.0+ és npm | MCP szerver fejlesztéshez |
| **Python** | 3.10+ | Opcionális Python MCP szerverekhez |
| **Memória** | Minimum 8GB RAM | 16GB ajánlott helyi modellekhez |

### 🔧 Fejlesztői környezet

#### Ajánlott VS Code bővítmények
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) – opcionális, de hasznos

#### Opcionális eszközök
- **uv**: Modern Python csomagkezelő
- **MCP Inspector**: Vizualis hibakereső eszköz MCP szerverekhez
- **Playwright**: Web automatizációs példákhoz


## 🎖️ Tanulási eredmények és tanúsítvány

### 🏆 Készségfejlesztési ellenőrzőlista

A workshop elvégzésével elsajátítod:

#### 🎯 Alapkészségek
- [ ] **MCP protokoll mélyismeret**: Architektúra és megvalósítási minták alapos ismerete
- [ ] **AITK jártasság**: AI Toolkit szakértői szintű használata gyors fejlesztéshez
- [ ] **Egyedi szerverfejlesztés**: MCP szerverek építése, telepítése és karbantartása
- [ ] **Eszközintegráció**: AI zökkenőmentes összekapcsolása meglévő fejlesztési munkafolyamatokkal
- [ ] **Problémamegoldás alkalmazása**: Tanult képességek alkalmazása valós üzleti kihívásokra

#### 🔧 Technikai képességek
- [ ] AI Toolkit beállítása és konfigurálása VS Code-ban
- [ ] Egyedi MCP szerverek tervezése és fejlesztése
- [ ] GitHub modellek integrálása MCP architektúrába
- [ ] Automatizált tesztelési munkafolyamatok építése Playwrighttal
- [ ] AI ügynökök éles környezetbe való telepítése
- [ ] MCP szerverek hibakeresése és optimalizálása

#### 🚀 Haladó képességek
- [ ] Vállalati szintű AI integrációk tervezése
- [ ] Biztonsági legjobb gyakorlatok megvalósítása AI alkalmazásokban
- [ ] Skálázható MCP szerver architektúrák kialakítása
- [ ] Egyedi eszközláncok létrehozása speciális területekre
- [ ] Mások mentorálása AI natív fejlesztésben

## 📖 További források
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Készen állsz, hogy forradalmasítsd AI fejlesztési munkafolyamataidat?**

Építsük együtt az intelligens alkalmazások jövőjét MCP-vel és AI Toolkittel!

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy félreértelmezésekért.