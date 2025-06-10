<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T05:04:15+00:00",
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
- **🛠️ AI Toolkit pre Visual Studio Code (AITK)**: výkonné rozšírenie od Microsoftu pre AI vývoj

### 🎓 Čo sa naučíte

Na konci tohto workshopu budete ovládať tvorbu inteligentných aplikácií, ktoré prepájajú AI modely s reálnymi nástrojmi a službami. Od automatizovaného testovania po vlastné API integrácie získate praktické zručnosti na riešenie zložitých obchodných výziev.

## 🏗️ Technologický stack

### 🔌 Model Context Protocol (MCP)

MCP je **„USB-C pre AI“** – univerzálny štandard, ktorý prepája AI modely s externými nástrojmi a dátovými zdrojmi.

**✨ Kľúčové vlastnosti:**
- 🔄 **Štandardizovaná integrácia**: univerzálne rozhranie pre pripojenie AI nástrojov
- 🏛️ **Flexibilná architektúra**: lokálne a vzdialené servery cez stdio/SSE prenos
- 🧰 **Bohatý ekosystém**: nástroje, výzvy a zdroje v jednom protokole
- 🔒 **Pripravené pre podniky**: zabudované zabezpečenie a spoľahlivosť

**🎯 Prečo je MCP dôležité:**
Rovnako ako USB-C odstránilo chaos s káblami, MCP zjednodušuje komplexnosť AI integrácií. Jeden protokol, nekonečné možnosti.

### 🤖 AI Toolkit pre Visual Studio Code (AITK)

Vlajkový AI vývojový doplnok od Microsoftu, ktorý premení VS Code na AI siláka.

**🚀 Hlavné schopnosti:**
- 📦 **Katalóg modelov**: prístup k modelom z Azure AI, GitHub, Hugging Face, Ollama
- ⚡ **Lokálne inferovanie**: ONNX optimalizované CPU/GPU/NPU vykonávanie
- 🏗️ **Agent Builder**: vizuálny vývoj AI agentov s MCP integráciou
- 🎭 **Multimodálne**: podpora textu, obrazu a štruktúrovaných výstupov

**💡 Výhody vývoja:**
- Nasadenie modelov bez konfigurácie
- Vizuálne tvorenie výziev
- Testovanie v reálnom čase
- Plynulá integrácia s MCP serverom

## 📚 Vzdelávacia cesta

### [🚀 Modul 1: Základy AI Toolkitu](./lab1/README.md)
**Dĺžka**: 15 minút
- 🛠️ Inštalácia a konfigurácia AI Toolkitu pre VS Code
- 🗂️ Preskúmanie Katalógu modelov (100+ modelov z GitHub, ONNX, OpenAI, Anthropic, Google)
- 🎮 Ovládnutie Interaktívneho ihriska pre testovanie modelov v reálnom čase
- 🤖 Vytvorenie prvého AI agenta pomocou Agent Buildera
- 📊 Hodnotenie výkonu modelov s metrikami (F1, relevantnosť, podobnosť, koherencia)
- ⚡ Naučíte sa dávkové spracovanie a multimodálnu podporu

**🎯 Výsledok učenia**: Vytvoriť funkčného AI agenta s komplexným porozumením možností AITK

### [🌐 Modul 2: MCP so základmi AI Toolkitu](./lab2/README.md)
**Dĺžka**: 20 minút
- 🧠 Ovládnutie architektúry a konceptov Model Context Protocol (MCP)
- 🌐 Preskúmanie ekosystému MCP serverov od Microsoftu
- 🤖 Vytvorenie agenta pre automatizáciu prehliadača pomocou Playwright MCP servera
- 🔧 Integrácia MCP serverov s AI Toolkit Agent Builderom
- 📊 Konfigurácia a testovanie MCP nástrojov vo vašich agentoch
- 🚀 Export a nasadenie MCP agentov do produkcie

**🎯 Výsledok učenia**: Nasadiť AI agenta s podporou externých nástrojov cez MCP

### [🔧 Modul 3: Pokročilý vývoj MCP s AI Toolkitom](./lab3/README.md)
**Dĺžka**: 20 minút
- 💻 Vytvorenie vlastných MCP serverov pomocou AI Toolkitu
- 🐍 Konfigurácia a použitie najnovšieho MCP Python SDK (v1.9.3)
- 🔍 Nastavenie a využitie MCP Inspectora na ladenie
- 🛠️ Vývoj Weather MCP Servera s profesionálnymi debugovacími postupmi
- 🧪 Ladenie MCP serverov v Agent Builderi aj Inspector prostrediach

**🎯 Výsledok učenia**: Vyvíjať a ladiť vlastné MCP servery s modernými nástrojmi

### [🐙 Modul 4: Praktický vývoj MCP – vlastný GitHub Clone Server](./lab4/README.md)
**Dĺžka**: 30 minút
- 🏗️ Vytvorenie reálneho GitHub Clone MCP Servera pre vývojové pracovné toky
- 🔄 Implementácia inteligentného klonovania repozitárov s validáciou a spracovaním chýb
- 📁 Vytvorenie inteligentného manažmentu adresárov a integrácia do VS Code
- 🤖 Použitie GitHub Copilot Agent Mode s vlastnými MCP nástrojmi
- 🛡️ Aplikácia spoľahlivosti pripravené na produkciu a multiplatformovú kompatibilitu

**🎯 Výsledok učenia**: Nasadiť produkčne pripravený MCP server, ktorý zefektívni skutočné vývojové procesy

## 💡 Reálne aplikácie a dopad

### 🏢 Použitie v podnikoch

#### 🔄 Automatizácia DevOps
Transformujte svoj vývojový proces inteligentnou automatizáciou:
- **Inteligentné riadenie repozitárov**: AI riadené recenzie kódu a rozhodnutia o zlúčení
- **Inteligentné CI/CD**: automatická optimalizácia pipeline na základe zmien v kóde
- **Triedenie problémov**: automatická klasifikácia a priraďovanie chýb

#### 🧪 Revolúcia v zabezpečení kvality
Posuňte testovanie na vyššiu úroveň s AI automatizáciou:
- **Inteligentná tvorba testov**: automatické generovanie komplexných testovacích sád
- **Vizualizácia regresného testovania**: detekcia zmien v UI pomocou AI
- **Monitorovanie výkonu**: proaktívne identifikovanie a riešenie problémov

#### 📊 Inteligentné dátové pipeline
Vytvorte inteligentnejšie pracovné toky spracovania dát:
- **Adaptívne ETL procesy**: samonastavujúce sa transformácie dát
- **Detekcia anomálií**: monitorovanie kvality dát v reálnom čase
- **Inteligentné smerovanie**: riadenie toku dát s rozumom

#### 🎧 Zlepšenie zákazníckej skúsenosti
Vytvorte výnimočné zákaznícke interakcie:
- **Podpora s kontextom**: AI agenti s prístupom k histórii zákazníka
- **Proaktívne riešenie problémov**: prediktívny zákaznícky servis
- **Multikanálová integrácia**: jednotný AI zážitok na rôznych platformách

## 🛠️ Požiadavky a nastavenie

### 💻 Systémové požiadavky

| Komponent | Požiadavka | Poznámky |
|-----------|------------|----------|
| **Operačný systém** | Windows 10+, macOS 10.15+, Linux | Akýkoľvek moderný OS |
| **Visual Studio Code** | Najnovšia stabilná verzia | Potrebné pre AITK |
| **Node.js** | v18.0+ a npm | Pre vývoj MCP servera |
| **Python** | 3.10+ | Voliteľné pre MCP servery v Pythone |
| **Pamäť** | minimálne 8GB RAM | Odporúča sa 16GB pre lokálne modely |

### 🔧 Vývojové prostredie

#### Odporúčané VS Code rozšírenia
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - voliteľné, ale užitočné

#### Voliteľné nástroje
- **uv**: moderný správca balíčkov pre Python
- **MCP Inspector**: vizuálny nástroj na ladenie MCP serverov
- **Playwright**: pre príklady webovej automatizácie

## 🎖️ Výsledky učenia a certifikačná cesta

### 🏆 Kontrolný zoznam zvládnutých zručností

Úspešným absolvovaním tohto workshopu získate majstrovstvo v:

#### 🎯 Kľúčové kompetencie
- [ ] **Majstrovstvo MCP protokolu**: hlboké porozumenie architektúry a implementačných vzorov
- [ ] **Ovládnutie AITK**: expert na AI Toolkit pre rýchly vývoj
- [ ] **Vývoj vlastných serverov**: vytváranie, nasadzovanie a údržba produkčných MCP serverov
- [ ] **Excelentná integrácia nástrojov**: bezproblémové prepájanie AI s existujúcimi pracovnými tokmi
- [ ] **Aplikácia riešení**: využitie naučených zručností na reálne obchodné výzvy

#### 🔧 Technické zručnosti
- [ ] Nastavenie a konfigurácia AI Toolkitu vo VS Code
- [ ] Návrh a vývoj vlastných MCP serverov
- [ ] Integrácia GitHub modelov do MCP architektúry
- [ ] Vytváranie automatizovaných testovacích pracovných tokov s Playwrightom
- [ ] Nasadenie AI agentov do produkcie
- [ ] Ladenie a optimalizácia výkonu MCP serverov

#### 🚀 Pokročilé schopnosti
- [ ] Návrh AI integrácií na úrovni podnikov
- [ ] Implementácia bezpečnostných najlepších praktík pre AI aplikácie
- [ ] Návrh škálovateľnej architektúry MCP serverov
- [ ] Vytváranie vlastných nástrojových reťazcov pre špecifické oblasti
- [ ] Mentorovanie iných v AI-native vývoji

## 📖 Ďalšie zdroje
- [MCP špecifikácia](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub repozitár](https://github.com/microsoft/vscode-ai-toolkit)
- [Kolekcia ukážkových MCP serverov](https://github.com/modelcontextprotocol/servers)
- [Sprievodca najlepšími praktikami](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Ste pripravení zmeniť svoj AI vývojový workflow?**

Poďme spoločne vytvoriť budúcnosť inteligentných aplikácií s MCP a AI Toolkitom!

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.