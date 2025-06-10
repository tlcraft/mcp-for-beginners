<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:54:36+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "tl"
}
-->
# 🐙 Module 4: Praktikal na Pag-develop ng MCP - Custom GitHub Clone Server

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ Mabilisang Simula:** Gumawa ng production-ready na MCP server na awtomatikong nagko-clone ng GitHub repository at nag-iintegrate sa VS Code sa loob lamang ng 30 minuto!

## 🎯 Mga Layunin sa Pagkatuto

Pagkatapos ng lab na ito, magagawa mong:

- ✅ Gumawa ng custom MCP server para sa totoong workflow ng pag-develop
- ✅ Ipatupad ang pag-clone ng GitHub repository gamit ang MCP
- ✅ Iintegrate ang custom MCP servers sa VS Code at Agent Builder
- ✅ Gamitin ang GitHub Copilot Agent Mode kasama ang custom MCP tools
- ✅ Subukan at i-deploy ang custom MCP servers sa production environment

## 📋 Mga Kinakailangan

- Natapos ang Labs 1-3 (mga pundasyon at advanced na pag-develop ng MCP)
- Subscription sa GitHub Copilot ([may libreng signup](https://github.com/github-copilot/signup))
- VS Code na may AI Toolkit at GitHub Copilot extensions
- Nakainstall at nakaayos ang Git CLI

## 🏗️ Pangkalahatang Ideya ng Proyekto

### **Tunay na Hamon sa Pag-develop**
Bilang mga developer, madalas nating ginagamit ang GitHub para i-clone ang mga repository at buksan ito sa VS Code o VS Code Insiders. Ang manwal na proseso ay kinabibilangan ng:
1. Pagbukas ng terminal/command prompt
2. Pagpunta sa nais na directory
3. Pagpatakbo ng `git clone` command
4. Pagbukas ng VS Code sa na-clone na directory

**Pinapasimple ng aming MCP solusyon ito sa isang matalinong command lang!**

### **Ano ang Iyong Gagawa**
Isang **GitHub Clone MCP Server** (`git_mcp_server`) na nagbibigay ng:

| Tampok | Paglalarawan | Benepisyo |
|---------|-------------|---------|
| 🔄 **Matalinong Pag-clone ng Repository** | I-clone ang GitHub repos na may validation | Awtomatikong pag-check ng error |
| 📁 **Matalinong Pamamahala ng Directory** | Suriin at ligtas na gumawa ng mga folder | Naiiwasan ang pagsulat-over |
| 🚀 **Cross-Platform na Integrasyon sa VS Code** | Buksan ang mga proyekto sa VS Code/Insiders | Walang putol na daloy ng trabaho |
| 🛡️ **Matatag na Pag-handle ng Error** | Asikasuhin ang network, permiso, at path issues | Ready na para sa production |

---

## 📖 Hakbang-hakbang na Implementasyon

### Hakbang 1: Gumawa ng GitHub Agent sa Agent Builder

1. **Buksan ang Agent Builder** gamit ang AI Toolkit extension
2. **Gumawa ng bagong agent** gamit ang sumusunod na configuration:
   ```
   Agent Name: GitHubAgent
   ```

3. **I-initialize ang custom MCP server:**
   - Pumunta sa **Tools** → **Add Tool** → **MCP Server**
   - Piliin ang **"Create A new MCP Server"**
   - Piliin ang **Python template** para sa maximum na flexibility
   - **Pangalan ng Server:** `git_mcp_server`

### Hakbang 2: I-configure ang GitHub Copilot Agent Mode

1. **Buksan ang GitHub Copilot** sa VS Code (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. **Piliin ang Agent Model** sa Copilot interface
3. **Piliin ang Claude 3.7 model** para sa mas mahusay na pag-intindi
4. **I-enable ang MCP integration** para sa access sa tools

> **💡 Tip:** Ang Claude 3.7 ay may mas mataas na kakayahan sa pag-unawa sa mga workflow ng pag-develop at mga pattern ng pag-handle ng error.

### Hakbang 3: Ipatupad ang Pangunahing Functionality ng MCP Server

**Gamitin ang sumusunod na detalyadong prompt sa GitHub Copilot Agent Mode:**

```
Create two MCP tools with the following comprehensive requirements:

🔧 TOOL A: clone_repository
Requirements:
- Clone any GitHub repository to a specified local folder
- Return the absolute path of the successfully cloned project
- Implement comprehensive validation:
  ✓ Check if target directory already exists (return error if exists)
  ✓ Validate GitHub URL format (https://github.com/user/repo)
  ✓ Verify git command availability (prompt installation if missing)
  ✓ Handle network connectivity issues
  ✓ Provide clear error messages for all failure scenarios

🚀 TOOL B: open_in_vscode
Requirements:
- Open specified folder in VS Code or VS Code Insiders
- Cross-platform compatibility (Windows/Linux/macOS)
- Use direct application launch (not terminal commands)
- Auto-detect available VS Code installations
- Handle cases where VS Code is not installed
- Provide user-friendly error messages

Additional Requirements:
- Follow MCP 1.9.3 best practices
- Include proper type hints and documentation
- Implement logging for debugging purposes
- Add input validation for all parameters
- Include comprehensive error handling
```

### Hakbang 4: Subukan ang Iyong MCP Server

#### 4a. Subukan sa Agent Builder

1. **Patakbuhin ang debug configuration** para sa Agent Builder
2. **I-configure ang iyong agent gamit ang system prompt na ito:**

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **Subukan gamit ang mga realistic na user scenario:**

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.tl.png)

**Inaasahang Resulta:**
- ✅ Matagumpay na pag-clone na may kumpirmasyon ng path
- ✅ Awtomatikong pagbukas ng VS Code
- ✅ Malinaw na mga mensahe ng error para sa mga invalid na sitwasyon
- ✅ Tamang pag-handle ng mga edge cases

#### 4b. Subukan sa MCP Inspector


![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.tl.png)

---



**🎉 Congrats!** Matagumpay mong nagawa ang isang praktikal at production-ready na MCP server na sumosolusyon sa mga totoong workflow ng pag-develop. Ipinapakita ng iyong custom GitHub clone server ang lakas ng MCP sa pag-automate at pagpapahusay ng productivity ng developer.

### 🏆 Mga Nakamit:
- ✅ **MCP Developer** - Nakagawa ng custom MCP server
- ✅ **Workflow Automator** - Pinadali ang proseso ng pag-develop  
- ✅ **Integration Expert** - Naka-connect ng iba't ibang development tools
- ✅ **Production Ready** - Nakagawa ng mga solusyong pwedeng i-deploy

---

## 🎓 Pagtatapos ng Workshop: Ang Iyong Paglalakbay sa Model Context Protocol

**Mahal na Kalahok sa Workshop,**

Binabati kita sa pagtatapos ng apat na modules ng Model Context Protocol workshop! Malayo na ang iyong narating mula sa pag-unawa sa mga pundasyon ng AI Toolkit hanggang sa paggawa ng production-ready MCP servers na sumosolusyon sa totoong problema sa pag-develop.

### 🚀 Balik-aral ng Iyong Pagkatuto:

**[Module 1](../lab1/README.md)**: Nagsimula ka sa pag-explore ng AI Toolkit fundamentals, pag-test ng mga modelo, at paggawa ng iyong unang AI agent.

**[Module 2](../lab2/README.md)**: Natutunan mo ang arkitektura ng MCP, integrasyon ng Playwright MCP, at gumawa ng unang browser automation agent.

**[Module 3](../lab3/README.md)**: Umangat ka sa pag-develop ng custom MCP server gamit ang Weather MCP server at na-master ang debugging tools.

**[Module 4](../lab4/README.md)**: Ngayon, naipamalas mo ang lahat sa paggawa ng praktikal na automation tool para sa GitHub repository workflow.

### 🌟 Mga Natutunan Mo:

- ✅ **AI Toolkit Ecosystem**: Mga modelo, agent, at pattern ng integrasyon
- ✅ **MCP Architecture**: Client-server design, transport protocols, at seguridad
- ✅ **Developer Tools**: Mula Playground hanggang Inspector at production deployment
- ✅ **Custom Development**: Pagbuo, pagsubok, at pag-deploy ng sariling MCP servers
- ✅ **Praktikal na Aplikasyon**: Pagsosolusyon sa totoong workflow challenges gamit ang AI

### 🔮 Mga Susunod Mong Hakbang:

1. **Gumawa ng Sariling MCP Server**: I-apply ang mga natutunan para i-automate ang sarili mong workflow
2. **Sumali sa MCP Community**: Ibahagi ang iyong mga gawa at matuto mula sa iba
3. **Siyasatin ang Advanced Integration**: I-connect ang MCP servers sa enterprise systems
4. **Mag-ambag sa Open Source**: Tumulong sa pagpapabuti ng MCP tools at dokumentasyon

Tandaan, simula pa lang ito ng iyong paglalakbay. Patuloy na umuunlad ang Model Context Protocol ecosystem, at ngayon ay handa ka nang maging nangunguna sa AI-powered development tools.

**Salamat sa iyong partisipasyon at dedikasyon sa pagkatuto!**

Sana ang workshop na ito ay nagbigay ng mga ideya na magpapabago kung paano ka gagawa at makikipag-ugnayan sa AI tools sa iyong pag-develop.

**Maligayang pag-coding!**

---

**Pagtatanggal ng Pananagutan**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.