<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:13:19+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "sk"
}
-->
# Zjednodušenie AI pracovných tokov: Vytvorenie MCP servera s AI Toolkitom

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.sk.png)

## 🎯 Prehľad

Vitajte na **Model Context Protocol (MCP) workshope**! Tento komplexný praktický workshop spája dve špičkové technológie, ktoré menia vývoj AI aplikácií:

- **🔗 Model Context Protocol (MCP)**: otvorený štandard pre bezproblémovú integráciu AI nástrojov
- **🛠️ AI Toolkit pre Visual Studio Code (AITK)**: výkonné rozšírenie od Microsoftu pre vývoj AI

### 🎓 Čo sa naučíte

Na konci tohto workshopu budete ovládať tvorbu inteligentných aplikácií, ktoré prepájajú AI modely s reálnymi nástrojmi a službami. Od automatizovaného testovania až po vlastné API integrácie získate praktické zručnosti na riešenie zložitých obchodných výziev.

## 🏗️ Technologický stack

### 🔌 Model Context Protocol (MCP)

MCP je **„USB-C pre AI“** – univerzálny štandard, ktorý spája AI modely s externými nástrojmi a dátovými zdrojmi.

**✨ Kľúčové vlastnosti:**
- 🔄 **Štandardizovaná integrácia**: univerzálne rozhranie pre pripojenie AI nástrojov
- 🏛️ **Flexibilná architektúra**: lokálne aj vzdialené servery cez stdio/SSE prenos
- 🧰 **Bohatý ekosystém**: nástroje, prompt-y a zdroje v jednom protokole
- 🔒 **Podniková pripravenosť**: zabudovaná bezpečnosť a spoľahlivosť

**🎯 Prečo je MCP dôležité:**
Rovnako ako USB-C odstránilo chaos s káblami, MCP zjednodušuje integrácie AI. Jeden protokol, nekonečné možnosti.

### 🤖 AI Toolkit pre Visual Studio Code (AITK)

Vlajková loď Microsoftu pre vývoj AI, ktorá premení VS Code na AI centrum.

**🚀 Hlavné schopnosti:**
- 📦 **Katalóg modelov**: prístup k modelom z Azure AI, GitHub, Hugging Face, Ollama
- ⚡ **Lokálne inferovanie**: ONNX optimalizované pre CPU/GPU/NPU
- 🏗️ **Agent Builder**: vizuálny vývoj AI agentov s MCP integráciou
- 🎭 **Multi-modálnosť**: podpora textu, obrazu a štruktúrovaného výstupu

**💡 Výhody pre vývoj:**
- Nasadenie modelov bez konfigurácie
- Vizuálne navrhovanie promptov
- Testovanie v reálnom čase
- Plynulá integrácia MCP serverov

## 📚 Vzdelávacia cesta

### [🚀 Modul 1: Základy AI Toolkitu](./lab1/README.md)
**Dĺžka**: 15 minút
- 🛠️ Inštalácia a konfigurácia AI Toolkitu pre VS Code
- 🗂️ Preskúmanie Katalógu modelov (100+ modelov z GitHub, ONNX, OpenAI, Anthropic, Google)
- 🎮 Ovládnutie Interaktívneho ihriska pre testovanie modelov v reálnom čase
- 🤖 Vytvorenie prvého AI agenta pomocou Agent Buildera
- 📊 Hodnotenie výkonu modelov pomocou vstavaných metrík (F1, relevantnosť, podobnosť, koherencia)
- ⚡ Naučíte sa dávkové spracovanie a podporu multi-modálnosti

**🎯 Výsledok učenia**: Vytvoriť funkčného AI agenta s komplexným pochopením možností AITK

### [🌐 Modul 2: MCP so základmi AI Toolkitu](./lab2/README.md)
**Dĺžka**: 20 minút
- 🧠 Ovládnutie architektúry a konceptov Model Context Protocol (MCP)
- 🌐 Preskúmanie ekosystému MCP serverov od Microsoftu
- 🤖 Vytvorenie agenta pre automatizáciu prehliadača pomocou Playwright MCP servera
- 🔧 Integrácia MCP serverov s AI Toolkit Agent Builderom
- 📊 Konfigurácia a testovanie MCP nástrojov vo vašich agentoch
- 🚀 Export a nasadenie agentov s podporou MCP do produkcie

**🎯 Výsledok učenia**: Nasadiť AI agenta s externými nástrojmi cez MCP

### [🔧 Modul 3: Pokročilý vývoj MCP s AI Toolkitom](./lab3/README.md)
**Dĺžka**: 20 minút
- 💻 Vytváranie vlastných MCP serverov pomocou AI Toolkitu
- 🐍 Konfigurácia a používanie najnovšieho MCP Python SDK (v1.9.3)
- 🔍 Nastavenie a využitie MCP Inspector na ladenie
- 🛠️ Vytvorenie Weather MCP Servera s profesionálnymi debugovacími postupmi
- 🧪 Ladenie MCP serverov v prostredí Agent Builder a Inspector

**🎯 Výsledok učenia**: Vyvíjať a ladiť vlastné MCP servery s modernými nástrojmi

### [🐙 Modul 4: Praktický vývoj MCP – vlastný GitHub Clone Server](./lab4/README.md)
**Dĺžka**: 30 minút
- 🏗️ Vytvorenie reálneho GitHub Clone MCP Servera pre vývojové pracovné toky
- 🔄 Implementácia inteligentného klonovania repozitárov s validáciou a spracovaním chýb
- 📁 Vytvorenie inteligentného spravovania adresárov a integrácia s VS Code
- 🤖 Použitie GitHub Copilot Agent Mode s vlastnými MCP nástrojmi
- 🛡️ Aplikácia spoľahlivosti pripravené na produkciu a multiplatformovej kompatibility

**🎯 Výsledok učenia**: Nasadiť produkčný MCP server, ktorý zjednodušuje reálne vývojové procesy

## 💡 Reálne aplikácie a dopad

### 🏢 Použitie v podnikoch

#### 🔄 Automatizácia DevOps
Transformujte svoj vývojový proces inteligentnou automatizáciou:
- **Inteligentné spravovanie repozitárov**: AI riadené revízie kódu a rozhodnutia o zlúčení
- **Inteligentné CI/CD**: automatická optimalizácia pipeline na základe zmien v kóde
- **Triedenie problémov**: automatická klasifikácia a priraďovanie chýb

#### 🧪 Revolúcia v zabezpečení kvality
Zvýšte efektivitu testovania pomocou AI automatizácie:
- **Inteligentná generácia testov**: automatické vytváranie komplexných testovacích sád
- **Vizualizácia regresných testov**: AI detekcia zmien v UI
- **Monitorovanie výkonu**: proaktívne identifikovanie a riešenie problémov

#### 📊 Inteligentné dátové toky
Budujte inteligentnejšie dátové pracovné toky:
- **Adaptívne ETL procesy**: samonastavujúce sa dátové transformácie
- **Detekcia anomálií**: monitorovanie kvality dát v reálnom čase
- **Inteligentné smerovanie**: riadenie toku dát s rozumom

#### 🎧 Zlepšenie zákazníckej skúsenosti
Vytvorte výnimočné interakcie so zákazníkmi:
- **Podpora s kontextom**: AI agenti s prístupom k histórii zákazníka
- **Proaktívne riešenie problémov**: prediktívny zákaznícky servis
- **Multikanálová integrácia**: jednotný AI zážitok naprieč platformami

## 🛠️ Požiadavky a nastavenie

### 💻 Systémové požiadavky

| Komponent | Požiadavka | Poznámky |
|-----------|------------|----------|
| **Operačný systém** | Windows 10+, macOS 10.15+, Linux | Akýkoľvek moderný OS |
| **Visual Studio Code** | Najnovšia stabilná verzia | Potrebné pre AITK |
| **Node.js** | v18.0+ a npm | Pre vývoj MCP serverov |
| **Python** | 3.10+ | Voliteľné pre Python MCP servery |
| **Pamäť** | Minimálne 8GB RAM | Odporúča sa 16GB pre lokálne modely |

### 🔧 Vývojové prostredie

#### Odporúčané rozšírenia pre VS Code
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) – voliteľné, ale užitočné

#### Voliteľné nástroje
- **uv**: moderný správca balíčkov pre Python
- **MCP Inspector**: vizuálny nástroj na ladenie MCP serverov
- **Playwright**: pre príklady webovej automatizácie

## 🎖️ Výsledky učenia a certifikačná cesta

### 🏆 Kontrolný zoznam zručností

Účasťou na tomto workshope dosiahnete majstrovstvo v:

#### 🎯 Kľúčové kompetencie
- [ ] **Ovládnutie MCP protokolu**: hlboké pochopenie architektúry a implementačných vzorov
- [ ] **Znalosť AITK**: expertné používanie AI Toolkitu pre rýchly vývoj
- [ ] **Vývoj vlastných serverov**: tvorba, nasadenie a údržba produkčných MCP serverov
- [ ] **Excelentná integrácia nástrojov**: bezproblémové prepojenie AI s existujúcimi vývojovými tokmi
- [ ] **Aplikácia riešenia problémov**: využitie naučených zručností na reálne obchodné výzvy

#### 🔧 Technické zručnosti
- [ ] Nastavenie a konfigurácia AI Toolkitu vo VS Code
- [ ] Návrh a implementácia vlastných MCP serverov
- [ ] Integrácia GitHub modelov s MCP architektúrou
- [ ] Vytváranie automatizovaných testovacích tokov s Playwright
- [ ] Nasadenie AI agentov do produkcie
- [ ] Ladenie a optimalizácia výkonu MCP serverov

#### 🚀 Pokročilé schopnosti
- [ ] Architektúra AI integrácií na podnikovej úrovni
- [ ] Implementácia bezpečnostných najlepších praktík pre AI aplikácie
- [ ] Návrh škálovateľných MCP serverových architektúr
- [ ] Vytváranie vlastných nástrojových reťazcov pre špecifické oblasti
- [ ] Mentorovanie ostatných vo vývoji natívnom pre AI

## 📖 Ďalšie zdroje
- [MCP Špecifikácia](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub repozitár](https://github.com/microsoft/vscode-ai-toolkit)
- [Kolekcia vzorových MCP serverov](https://github.com/modelcontextprotocol/servers)
- [Príručka najlepších praktík](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Ste pripravení zmeniť svoj AI vývojový workflow?**

Poďme spoločne budovať budúcnosť inteligentných aplikácií s MCP a AI Toolkitom!

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.