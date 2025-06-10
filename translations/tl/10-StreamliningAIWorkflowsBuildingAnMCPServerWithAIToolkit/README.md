<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T05:02:19+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "tl"
}
-->
# Streamlining AI Workflows: Pagtayo ng MCP Server gamit ang AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.tl.png)

## 🎯 Pangkalahatang-ideya

Maligayang pagdating sa **Model Context Protocol (MCP) Workshop**! Ang malawak na hands-on na workshop na ito ay pinagsasama ang dalawang makabagong teknolohiya para baguhin ang pagbuo ng AI applications:

- **🔗 Model Context Protocol (MCP)**: Isang bukas na pamantayan para sa maayos na integrasyon ng AI tools
- **🛠️ AI Toolkit para sa Visual Studio Code (AITK)**: Malakas na AI development extension mula sa Microsoft

### 🎓 Ano ang Matututuhan Mo

Sa pagtatapos ng workshop na ito, magiging bihasa ka sa paggawa ng matatalinong aplikasyon na nag-uugnay ng AI models sa mga totoong gamit at serbisyo. Mula sa automated testing hanggang sa custom API integrations, magkakaroon ka ng praktikal na kasanayan para lutasin ang mahihirap na hamon sa negosyo.

## 🏗️ Teknolohiyang Ginagamit

### 🔌 Model Context Protocol (MCP)

Ang MCP ay ang **"USB-C para sa AI"** - isang unibersal na pamantayan na kumokonekta sa AI models sa mga panlabas na gamit at pinagkukunan ng data.

**✨ Pangunahing Tampok:**
- 🔄 **Standardized Integration**: Isang unibersal na interface para sa koneksyon ng AI tools
- 🏛️ **Flexible Architecture**: Lokal at remote servers gamit ang stdio/SSE transport
- 🧰 **Malawak na Ecosystem**: Kasama ang mga tools, prompts, at resources sa isang protocol
- 🔒 **Handa para sa Enterprise**: May kasamang seguridad at pagiging maaasahan

**🎯 Bakit Mahalaga ang MCP:**
Katulad ng USB-C na nagtanggal ng kalituhan sa mga kable, tinatanggal ng MCP ang komplikasyon sa AI integrations. Isang protocol, walang katapusang posibilidad.

### 🤖 AI Toolkit para sa Visual Studio Code (AITK)

Pangunahing AI development extension ng Microsoft na ginagawang powerhouse ang VS Code para sa AI.

**🚀 Pangunahing Kakayahan:**
- 📦 **Model Catalog**: Access sa mga modelo mula sa Azure AI, GitHub, Hugging Face, Ollama
- ⚡ **Local Inference**: ONNX-optimized na CPU/GPU/NPU execution
- 🏗️ **Agent Builder**: Visual AI agent development na may MCP integration
- 🎭 **Multi-Modal**: Suporta sa text, vision, at structured output

**💡 Mga Benepisyo sa Development:**
- Zero-config na deployment ng modelo
- Visual prompt engineering
- Real-time testing playground
- Seamless na integrasyon ng MCP server

## 📚 Landas ng Pagkatuto

### [🚀 Module 1: AI Toolkit Fundamentals](./lab1/README.md)
**Tagal**: 15 minuto
- 🛠️ I-install at i-configure ang AI Toolkit para sa VS Code
- 🗂️ Tuklasin ang Model Catalog (100+ modelo mula sa GitHub, ONNX, OpenAI, Anthropic, Google)
- 🎮 Masterin ang Interactive Playground para sa real-time na pagsubok ng modelo
- 🤖 Gumawa ng unang AI agent gamit ang Agent Builder
- 📊 Suriin ang performance ng modelo gamit ang built-in metrics (F1, relevance, similarity, coherence)
- ⚡ Matutunan ang batch processing at multi-modal support

**🎯 Resulta ng Pagkatuto**: Makalikha ng functional AI agent na may malawak na pag-unawa sa mga kakayahan ng AITK

### [🌐 Module 2: MCP with AI Toolkit Fundamentals](./lab2/README.md)
**Tagal**: 20 minuto
- 🧠 Masterin ang arkitektura at mga konsepto ng Model Context Protocol (MCP)
- 🌐 Tuklasin ang ecosystem ng Microsoft MCP server
- 🤖 Gumawa ng browser automation agent gamit ang Playwright MCP server
- 🔧 I-integrate ang MCP servers sa AI Toolkit Agent Builder
- 📊 I-configure at subukan ang MCP tools sa loob ng iyong mga agent
- 🚀 I-export at i-deploy ang MCP-powered agents para sa production

**🎯 Resulta ng Pagkatuto**: Makapag-deploy ng AI agent na pinalakas ng mga panlabas na tools gamit ang MCP

### [🔧 Module 3: Advanced MCP Development with AI Toolkit](./lab3/README.md)
**Tagal**: 20 minuto
- 💻 Gumawa ng custom MCP servers gamit ang AI Toolkit
- 🐍 I-configure at gamitin ang pinakabagong MCP Python SDK (v1.9.3)
- 🔍 I-setup at gamitin ang MCP Inspector para sa debugging
- 🛠️ Gumawa ng Weather MCP Server gamit ang propesyonal na debugging workflows
- 🧪 Mag-debug ng MCP servers sa parehong Agent Builder at Inspector environments

**🎯 Resulta ng Pagkatuto**: Makabuo at makapag-debug ng custom MCP servers gamit ang makabagong mga tool

### [🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server](./lab4/README.md)
**Tagal**: 30 minuto
- 🏗️ Gumawa ng tunay na GitHub Clone MCP Server para sa development workflows
- 🔄 Ipatupad ang smart repository cloning na may validation at error handling
- 📁 Gumawa ng matalinong directory management at VS Code integration
- 🤖 Gamitin ang GitHub Copilot Agent Mode na may custom MCP tools
- 🛡️ Mag-apply ng production-ready reliability at cross-platform compatibility

**🎯 Resulta ng Pagkatuto**: Makapag-deploy ng production-ready MCP server na nagpapadali ng totoong development workflows


## 💡 Mga Totoong Aplikasyon at Epekto

### 🏢 Mga Gamit sa Enterprise

#### 🔄 DevOps Automation
Baguhin ang iyong development workflow gamit ang matalinong automation:
- **Smart Repository Management**: AI-driven na pagsusuri ng code at desisyon sa merge
- **Intelligent CI/CD**: Automated pipeline optimization base sa mga pagbabago sa code
- **Issue Triage**: Awtomatikong klasipikasyon at pagtatalaga ng bugs

#### 🧪 Rebolusyon sa Quality Assurance
Pataasin ang kalidad ng testing gamit ang AI-powered automation:
- **Intelligent Test Generation**: Gumawa ng komprehensibong test suites nang awtomatiko
- **Visual Regression Testing**: AI-powered na pagtuklas ng pagbabago sa UI
- **Performance Monitoring**: Proaktibong pagtukoy at paglutas ng mga isyu

#### 📊 Data Pipeline Intelligence
Gumawa ng mas matalinong data processing workflows:
- **Adaptive ETL Processes**: Self-optimizing na data transformations
- **Anomaly Detection**: Real-time na monitoring ng kalidad ng data
- **Intelligent Routing**: Matalinong pamamahala ng daloy ng data

#### 🎧 Pagpapahusay ng Customer Experience
Lumikha ng pambihirang interaksyon sa mga customer:
- **Context-Aware Support**: AI agents na may access sa kasaysayan ng customer
- **Proactive Issue Resolution**: Predictive na serbisyo sa customer
- **Multi-Channel Integration**: Pinagsamang AI experience sa iba't ibang platform


## 🛠️ Mga Kinakailangan at Setup

### 💻 Mga Kinakailangan sa Sistema

| Komponent | Kinakailangan | Tala |
|-----------|---------------|------|
| **Operating System** | Windows 10+, macOS 10.15+, Linux | Anumang modernong OS |
| **Visual Studio Code** | Pinakabagong stable na bersyon | Kailangan para sa AITK |
| **Node.js** | v18.0+ at npm | Para sa MCP server development |
| **Python** | 3.10+ | Opsyonal para sa Python MCP servers |
| **Memory** | Minimum 8GB RAM | 16GB inirerekomenda para sa local models |

### 🔧 Development Environment

#### Inirerekomendang VS Code Extensions
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - Opsyonal pero kapaki-pakinabang

#### Opsyonal na Mga Tools
- **uv**: Makabagong Python package manager
- **MCP Inspector**: Visual debugging tool para sa MCP servers
- **Playwright**: Para sa mga halimbawa ng web automation


## 🎖️ Mga Resulta ng Pagkatuto at Landas ng Sertipikasyon

### 🏆 Checklist ng Kasanayan

Sa pagtatapos ng workshop na ito, makakamit mo ang kahusayan sa:

#### 🎯 Pangunahing Kasanayan
- [ ] **MCP Protocol Mastery**: Malalim na pag-unawa sa arkitektura at mga pattern ng implementasyon
- [ ] **AITK Proficiency**: Ekspertong paggamit ng AI Toolkit para sa mabilisang development
- [ ] **Custom Server Development**: Paggawa, deployment, at pagpapanatili ng production MCP servers
- [ ] **Tool Integration Excellence**: Walang patid na pagkonekta ng AI sa kasalukuyang development workflows
- [ ] **Problem-Solving Application**: Paglalapat ng natutunang kasanayan sa totoong hamon ng negosyo

#### 🔧 Teknikal na Kasanayan
- [ ] I-setup at i-configure ang AI Toolkit sa VS Code
- [ ] Magdisenyo at magpatupad ng custom MCP servers
- [ ] I-integrate ang GitHub Models sa MCP architecture
- [ ] Gumawa ng automated testing workflows gamit ang Playwright
- [ ] Mag-deploy ng AI agents para sa production use
- [ ] Mag-debug at mag-optimize ng performance ng MCP server

#### 🚀 Advanced na Kakayahan
- [ ] Magdisenyo ng enterprise-scale AI integrations
- [ ] Magpatupad ng pinakamahusay na seguridad para sa AI applications
- [ ] Magdisenyo ng scalable MCP server architectures
- [ ] Gumawa ng custom tool chains para sa mga partikular na domain
- [ ] Magsanay at mag-mentor sa iba sa AI-native development

## 📖 Karagdagang Mga Mapagkukunan
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Handa ka na bang baguhin ang iyong AI development workflow?**

Tayo na’t bumuo ng kinabukasan ng matatalinong aplikasyon kasama ang MCP at AI Toolkit!

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami na maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.