<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:09:49+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "nl"
}
-->
# Stroomlijnen van AI-workflows: Een MCP-server bouwen met AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)  
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)  
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.nl.png)

## 🎯 Overzicht

Welkom bij de **Model Context Protocol (MCP) Workshop**! Deze uitgebreide hands-on workshop combineert twee baanbrekende technologieën om AI-applicatieontwikkeling te transformeren:

- **🔗 Model Context Protocol (MCP)**: Een open standaard voor naadloze integratie van AI-tools  
- **🛠️ AI Toolkit voor Visual Studio Code (AITK)**: Microsofts krachtige AI-ontwikkelextensie

### 🎓 Wat je zult leren

Aan het einde van deze workshop beheers je het bouwen van intelligente applicaties die AI-modellen koppelen aan echte tools en diensten. Van geautomatiseerd testen tot aangepaste API-integraties, je krijgt praktische vaardigheden om complexe zakelijke uitdagingen op te lossen.

## 🏗️ Technologie Stack

### 🔌 Model Context Protocol (MCP)

MCP is de **"USB-C voor AI"** – een universele standaard die AI-modellen verbindt met externe tools en databronnen.

**✨ Belangrijkste kenmerken:**  
- 🔄 **Gestandaardiseerde integratie**: Universele interface voor AI-toolverbindingen  
- 🏛️ **Flexibele architectuur**: Lokale en externe servers via stdio/SSE transport  
- 🧰 **Rijk ecosysteem**: Tools, prompts en bronnen in één protocol  
- 🔒 **Klaar voor ondernemingen**: Ingebouwde beveiliging en betrouwbaarheid

**🎯 Waarom MCP belangrijk is:**  
Net zoals USB-C de wirwar aan kabels heeft opgelost, vereenvoudigt MCP de complexiteit van AI-integraties. Eén protocol, oneindige mogelijkheden.

### 🤖 AI Toolkit voor Visual Studio Code (AITK)

Microsofts toonaangevende AI-ontwikkelextensie die VS Code verandert in een AI-krachtpatser.

**🚀 Kernmogelijkheden:**  
- 📦 **Modelcatalogus**: Toegang tot modellen van Azure AI, GitHub, Hugging Face, Ollama  
- ⚡ **Lokale inferentie**: ONNX-geoptimaliseerde CPU/GPU/NPU uitvoering  
- 🏗️ **Agent Builder**: Visuele ontwikkeling van AI-agenten met MCP-integratie  
- 🎭 **Multi-modale ondersteuning**: Tekst, beeld en gestructureerde output

**💡 Voordelen voor ontwikkeling:**  
- Zero-config modelimplementatie  
- Visuele prompt-engineering  
- Real-time testomgeving  
- Naadloze integratie met MCP-servers

## 📚 Leertraject

### [🚀 Module 1: AI Toolkit Basisprincipes](./lab1/README.md)  
**Duur**: 15 minuten  
- 🛠️ Installeer en configureer AI Toolkit voor VS Code  
- 🗂️ Verken de Modelcatalogus (100+ modellen van GitHub, ONNX, OpenAI, Anthropic, Google)  
- 🎮 Beheers de interactieve testomgeving voor real-time modeltesten  
- 🤖 Bouw je eerste AI-agent met Agent Builder  
- 📊 Evalueer modelprestaties met ingebouwde metrics (F1, relevantie, gelijkenis, coherentie)  
- ⚡ Leer batchverwerking en multi-modale ondersteuning

**🎯 Leerresultaat**: Maak een functionele AI-agent met een grondig begrip van AITK-mogelijkheden

### [🌐 Module 2: MCP met AI Toolkit Basisprincipes](./lab2/README.md)  
**Duur**: 20 minuten  
- 🧠 Beheers de architectuur en concepten van Model Context Protocol (MCP)  
- 🌐 Verken het MCP-server ecosysteem van Microsoft  
- 🤖 Bouw een browserautomatiseringsagent met Playwright MCP-server  
- 🔧 Integreer MCP-servers met AI Toolkit Agent Builder  
- 📊 Configureer en test MCP-tools binnen je agenten  
- 🚀 Exporteer en implementeer MCP-gestuurde agenten voor productie

**🎯 Leerresultaat**: Zet een AI-agent in die extern gereedschap benut via MCP

### [🔧 Module 3: Geavanceerde MCP-ontwikkeling met AI Toolkit](./lab3/README.md)  
**Duur**: 20 minuten  
- 💻 Maak aangepaste MCP-servers met AI Toolkit  
- 🐍 Configureer en gebruik de nieuwste MCP Python SDK (v1.9.3)  
- 🔍 Stel MCP Inspector in voor debugging  
- 🛠️ Bouw een Weather MCP Server met professionele debug-workflows  
- 🧪 Debug MCP-servers in zowel Agent Builder als Inspector omgevingen

**🎯 Leerresultaat**: Ontwikkel en debug aangepaste MCP-servers met moderne tools

### [🐙 Module 4: Praktische MCP-ontwikkeling - Aangepaste GitHub Clone Server](./lab4/README.md)  
**Duur**: 30 minuten  
- 🏗️ Bouw een realistische GitHub Clone MCP Server voor ontwikkelworkflows  
- 🔄 Implementeer slimme repository cloning met validatie en foutafhandeling  
- 📁 Creëer intelligente directorybeheer en VS Code-integratie  
- 🤖 Gebruik GitHub Copilot Agent Mode met aangepaste MCP-tools  
- 🛡️ Pas productieklare betrouwbaarheid en cross-platform compatibiliteit toe

**🎯 Leerresultaat**: Zet een productieklare MCP-server in die echte ontwikkelworkflows vereenvoudigt

## 💡 Praktische toepassingen & impact

### 🏢 Enterprise use cases

#### 🔄 DevOps-automatisering  
Transformeer je ontwikkelworkflow met intelligente automatisering:  
- **Slim repositorybeheer**: AI-gestuurde code review en merge-beslissingen  
- **Intelligente CI/CD**: Geautomatiseerde pijplijnoptimalisatie op basis van codewijzigingen  
- **Issue triage**: Automatische bugclassificatie en toewijzing

#### 🧪 Kwaliteitsborging revolutie  
Verhoog testen met AI-gedreven automatisering:  
- **Intelligente testgeneratie**: Automatisch uitgebreide testsuites maken  
- **Visuele regressietests**: AI-gestuurde detectie van UI-wijzigingen  
- **Prestatiemonitoring**: Proactieve probleemidentificatie en -oplossing

#### 📊 Data pipeline intelligentie  
Bouw slimmere dataverwerkingsworkflows:  
- **Adaptieve ETL-processen**: Zelfoptimaliserende datatransformaties  
- **Anomaliedetectie**: Real-time monitoring van datakwaliteit  
- **Intelligente routering**: Slim beheer van datastromen

#### 🎧 Verbetering van klantervaring  
Creëer uitzonderlijke klantinteracties:  
- **Contextbewuste ondersteuning**: AI-agenten met toegang tot klantgeschiedenis  
- **Proactieve probleemoplossing**: Voorspellende klantenservice  
- **Multi-channel integratie**: Geünificeerde AI-ervaring over platforms heen

## 🛠️ Vereisten & installatie

### 💻 Systeemvereisten

| Component            | Vereiste               | Opmerkingen               |
|----------------------|-----------------------|---------------------------|
| **Besturingssysteem** | Windows 10+, macOS 10.15+, Linux | Elk modern OS             |
| **Visual Studio Code**| Laatste stabiele versie| Vereist voor AITK         |
| **Node.js**          | v18.0+ en npm          | Voor MCP-serverontwikkeling|
| **Python**           | 3.10+                  | Optioneel voor Python MCP-servers |
| **Geheugen**         | Minimaal 8GB RAM       | 16GB aanbevolen voor lokale modellen |

### 🔧 Ontwikkelomgeving

#### Aanbevolen VS Code-extensies  
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)  
- **Python** (ms-python.python)  
- **Python Debugger** (ms-python.debugpy)  
- **GitHub Copilot** (GitHub.copilot) - Optioneel maar handig

#### Optionele tools  
- **uv**: Moderne Python package manager  
- **MCP Inspector**: Visuele debugtool voor MCP-servers  
- **Playwright**: Voor webautomatiseringsvoorbeelden

## 🎖️ Leerresultaten & certificeringspad

### 🏆 Checklist vaardigheden

Door deze workshop te voltooien, beheers je:

#### 🎯 Kerncompetenties  
- [ ] **MCP Protocol beheersing**: Diepgaand begrip van architectuur en implementatiepatronen  
- [ ] **AITK vaardigheid**: Expertgebruik van AI Toolkit voor snelle ontwikkeling  
- [ ] **Aangepaste serverontwikkeling**: Bouwen, implementeren en onderhouden van productie-MCP-servers  
- [ ] **Toolintegratie-excellentie**: Naadloze koppeling van AI met bestaande ontwikkelworkflows  
- [ ] **Probleemoplossing toepassen**: Toepassen van geleerde vaardigheden op echte zakelijke uitdagingen

#### 🔧 Technische vaardigheden  
- [ ] AI Toolkit opzetten en configureren in VS Code  
- [ ] Aangepaste MCP-servers ontwerpen en implementeren  
- [ ] GitHub-modellen integreren met MCP-architectuur  
- [ ] Geautomatiseerde testworkflows bouwen met Playwright  
- [ ] AI-agenten inzetten voor productie  
- [ ] MCP-serverprestaties debuggen en optimaliseren

#### 🚀 Geavanceerde mogelijkheden  
- [ ] Architectuur van AI-integraties op ondernemingsniveau ontwerpen  
- [ ] Beveiligingsbest practices voor AI-toepassingen implementeren  
- [ ] Schaalbare MCP-serverarchitecturen ontwerpen  
- [ ] Aangepaste toolchains creëren voor specifieke domeinen  
- [ ] Anderen begeleiden in AI-native ontwikkeling

## 📖 Aanvullende bronnen  
- [MCP Specificatie](https://modelcontextprotocol.io/docs)  
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)  
- [Voorbeeld MCP-servers collectie](https://github.com/modelcontextprotocol/servers)  
- [Handleiding beste praktijken](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Klaar om je AI-ontwikkelworkflow te revolutioneren?**  

Laten we samen de toekomst van intelligente applicaties bouwen met MCP en AI Toolkit!

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.