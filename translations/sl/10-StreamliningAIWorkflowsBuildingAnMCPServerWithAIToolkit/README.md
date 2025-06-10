<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T05:06:48+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "sl"
}
-->
# Streamlining AI Workflows: Building an MCP Server with AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.sl.png)

## 🎯 Overview

Welcome to the **Model Context Protocol (MCP) Workshop**! This hands-on workshop combines two cutting-edge technologies to transform AI app development:

- **🔗 Model Context Protocol (MCP)**: An open standard for smooth AI-tool integration
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: Microsoft’s powerful AI development extension

### 🎓 What You'll Learn

By the end, you'll know how to build smart apps that connect AI models with real-world tools and services. From automated testing to custom API integrations, you’ll gain practical skills to tackle complex business problems.

## 🏗️ Technology Stack

### 🔌 Model Context Protocol (MCP)

MCP is the **“USB-C for AI”** — a universal standard linking AI models to external tools and data sources.

**✨ Key Features:**
- 🔄 **Standardized Integration**: Universal interface for AI-tool connections
- 🏛️ **Flexible Architecture**: Local & remote servers via stdio/SSE transport
- 🧰 **Rich Ecosystem**: Tools, prompts, and resources all in one protocol
- 🔒 **Enterprise-Ready**: Built-in security and reliability

**🎯 Why MCP Matters:**
Just like USB-C simplified cables, MCP simplifies AI integrations. One protocol, endless possibilities.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Microsoft’s flagship AI extension that turns VS Code into an AI powerhouse.

**🚀 Core Capabilities:**
- 📦 **Model Catalog**: Access models from Azure AI, GitHub, Hugging Face, Ollama
- ⚡ **Local Inference**: ONNX-optimized CPU/GPU/NPU execution
- 🏗️ **Agent Builder**: Visual AI agent creation with MCP integration
- 🎭 **Multi-Modal**: Support for text, vision, and structured outputs

**💡 Development Benefits:**
- Zero-config model deployment
- Visual prompt engineering
- Real-time testing playground
- Seamless MCP server integration

## 📚 Learning Journey

### [🚀 Module 1: AI Toolkit Fundamentals](./lab1/README.md)
**Duration**: 15 minutes
- 🛠️ Install and set up AI Toolkit for VS Code
- 🗂️ Explore the Model Catalog (100+ models from GitHub, ONNX, OpenAI, Anthropic, Google)
- 🎮 Master the Interactive Playground for real-time model testing
- 🤖 Build your first AI agent with Agent Builder
- 📊 Evaluate model performance with built-in metrics (F1, relevance, similarity, coherence)
- ⚡ Learn batch processing and multi-modal support

**🎯 Learning Outcome**: Build a working AI agent with solid understanding of AITK features

### [🌐 Module 2: MCP with AI Toolkit Fundamentals](./lab2/README.md)
**Duration**: 20 minutes
- 🧠 Understand Model Context Protocol (MCP) architecture and concepts
- 🌐 Explore Microsoft’s MCP server ecosystem
- 🤖 Build a browser automation agent using Playwright MCP server
- 🔧 Connect MCP servers with AI Toolkit Agent Builder
- 📊 Configure and test MCP tools within your agents
- 🚀 Export and deploy MCP-powered agents for production

**🎯 Learning Outcome**: Deploy an AI agent enhanced with external tools via MCP

### [🔧 Module 3: Advanced MCP Development with AI Toolkit](./lab3/README.md)
**Duration**: 20 minutes
- 💻 Create custom MCP servers using AI Toolkit
- 🐍 Set up and use the latest MCP Python SDK (v1.9.3)
- 🔍 Use MCP Inspector for debugging
- 🛠️ Build a Weather MCP Server with professional debugging workflows
- 🧪 Debug MCP servers in Agent Builder and Inspector environments

**🎯 Learning Outcome**: Develop and debug custom MCP servers using modern tools

### [🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server](./lab4/README.md)
**Duration**: 30 minutes
- 🏗️ Build a real-world GitHub Clone MCP Server for dev workflows
- 🔄 Implement smart repo cloning with validation and error handling
- 📁 Create intelligent directory management and VS Code integration
- 🤖 Use GitHub Copilot Agent Mode with custom MCP tools
- 🛡️ Ensure production-ready reliability and cross-platform support

**🎯 Learning Outcome**: Deploy a production-grade MCP server that streamlines real development workflows

## 💡 Real-World Applications & Impact

### 🏢 Enterprise Use Cases

#### 🔄 DevOps Automation
Enhance your development workflow with smart automation:
- **Smart Repository Management**: AI-driven code review and merge decisions
- **Intelligent CI/CD**: Automated pipeline optimization based on code changes
- **Issue Triage**: Auto bug classification and assignment

#### 🧪 Quality Assurance Revolution
Boost testing with AI-powered automation:
- **Intelligent Test Generation**: Auto-create comprehensive test suites
- **Visual Regression Testing**: AI-driven UI change detection
- **Performance Monitoring**: Early issue detection and resolution

#### 📊 Data Pipeline Intelligence
Build smarter data workflows:
- **Adaptive ETL Processes**: Self-optimizing data transformations
- **Anomaly Detection**: Real-time data quality monitoring
- **Intelligent Routing**: Smart data flow management

#### 🎧 Customer Experience Enhancement
Deliver outstanding customer interactions:
- **Context-Aware Support**: AI agents with access to customer history
- **Proactive Issue Resolution**: Predictive customer service
- **Multi-Channel Integration**: Unified AI experience across platforms

## 🛠️ Prerequisites & Setup

### 💻 System Requirements

| Component | Requirement | Notes |
|-----------|-------------|-------|
| **Operating System** | Windows 10+, macOS 10.15+, Linux | Any modern OS |
| **Visual Studio Code** | Latest stable version | Needed for AITK |
| **Node.js** | v18.0+ and npm | For MCP server development |
| **Python** | 3.10+ | Optional for Python MCP servers |
| **Memory** | 8GB RAM minimum | 16GB recommended for local models |

### 🔧 Development Environment

#### Recommended VS Code Extensions
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - Optional but useful

#### Optional Tools
- **uv**: Modern Python package manager
- **MCP Inspector**: Visual debugging for MCP servers
- **Playwright**: For web automation demos

## 🎖️ Learning Outcomes & Certification Path

### 🏆 Skill Mastery Checklist

By finishing this workshop, you’ll master:

#### 🎯 Core Competencies
- [ ] **MCP Protocol Mastery**: Deep knowledge of architecture and implementation
- [ ] **AITK Proficiency**: Expert use of AI Toolkit for fast development
- [ ] **Custom Server Development**: Build, deploy, and maintain MCP servers
- [ ] **Tool Integration Excellence**: Smoothly connect AI with dev workflows
- [ ] **Problem-Solving Application**: Apply skills to real business challenges

#### 🔧 Technical Skills
- [ ] Set up and configure AI Toolkit in VS Code
- [ ] Design and build custom MCP servers
- [ ] Integrate GitHub Models with MCP architecture
- [ ] Build automated testing workflows with Playwright
- [ ] Deploy AI agents for production
- [ ] Debug and optimize MCP server performance

#### 🚀 Advanced Capabilities
- [ ] Architect enterprise-scale AI integrations
- [ ] Apply security best practices for AI apps
- [ ] Design scalable MCP server architectures
- [ ] Create custom toolchains for specific domains
- [ ] Mentor others in AI-native development

## 📖 Additional Resources
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Ready to revolutionize your AI development workflow?**

Let’s build the future of intelligent apps together with MCP and AI Toolkit!

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.