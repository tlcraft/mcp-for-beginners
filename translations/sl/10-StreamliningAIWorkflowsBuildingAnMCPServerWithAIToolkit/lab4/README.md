<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:59:17+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "sl"
}
-->
# 🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ Quick Start:** Build a production-ready MCP server that automates GitHub repository cloning and VS Code integration in just 30 minutes!

## 🎯 Learning Objectives

By the end of this lab, you will be able to:

- ✅ Create a custom MCP server for real-world development workflows
- ✅ Implement GitHub repository cloning functionality via MCP
- ✅ Integrate custom MCP servers with VS Code and Agent Builder
- ✅ Use GitHub Copilot Agent Mode with custom MCP tools
- ✅ Test and deploy custom MCP servers in production environments

## 📋 Prerequisites

- Completion of Labs 1-3 (MCP fundamentals and advanced development)
- GitHub Copilot subscription ([free signup available](https://github.com/github-copilot/signup))
- VS Code with AI Toolkit and GitHub Copilot extensions
- Git CLI installed and configured

## 🏗️ Project Overview

### **Real-World Development Challenge**
As developers, we often clone GitHub repositories and open them in VS Code or VS Code Insiders. This usually means:
1. Opening a terminal or command prompt
2. Navigating to the target folder
3. Running the `git clone` command
4. Launching VS Code in the cloned directory

**Our MCP solution simplifies all these steps into a single smart command!**

### **What You'll Build**
A **GitHub Clone MCP Server** (`git_mcp_server`) that offers:

| Feature | Description | Benefit |
|---------|-------------|---------|
| 🔄 **Smart Repository Cloning** | Clone GitHub repos with validation | Automatic error checking |
| 📁 **Intelligent Directory Management** | Verify and create directories safely | Avoids accidental overwrites |
| 🚀 **Cross-Platform VS Code Integration** | Open projects in VS Code or Insiders | Smooth workflow handoff |
| 🛡️ **Robust Error Handling** | Manage network, permission, and path issues | Reliable for production use |

---

## 📖 Step-by-Step Implementation

### Step 1: Create GitHub Agent in Agent Builder

1. **Open Agent Builder** via the AI Toolkit extension
2. **Create a new agent** using this configuration:
   ```
   Agent Name: GitHubAgent
   ```

3. **Initialize your custom MCP server:**
   - Go to **Tools** → **Add Tool** → **MCP Server**
   - Choose **"Create A new MCP Server"**
   - Select the **Python template** for flexibility
   - **Server Name:** `git_mcp_server`

### Step 2: Configure GitHub Copilot Agent Mode

1. **Open GitHub Copilot** in VS Code (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. **Pick Agent Model** in the Copilot interface
3. **Select Claude 3.7 model** for better reasoning
4. **Enable MCP integration** to access your tools

> **💡 Pro Tip:** Claude 3.7 excels at understanding development workflows and handling errors gracefully.

### Step 3: Implement Core MCP Server Functionality

**Use this detailed prompt with GitHub Copilot Agent Mode:**

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

### Step 4: Test Your MCP Server

#### 4a. Test in Agent Builder

1. **Start the debug configuration** for Agent Builder
2. **Set your agent's system prompt:**

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **Run tests with realistic user commands:**

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.sl.png)

**Expected Results:**
- ✅ Cloning completes successfully with path confirmation
- ✅ VS Code opens automatically after cloning
- ✅ Clear error messages for invalid inputs
- ✅ Proper handling of edge cases

#### 4b. Test in MCP Inspector


![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.sl.png)

---

**🎉 Congratulations!** You've built a practical, production-ready MCP server that tackles real developer workflow challenges. Your custom GitHub clone server showcases how MCP can automate and boost developer productivity.

### 🏆 Achievement Unlocked:
- ✅ **MCP Developer** - Built a custom MCP server
- ✅ **Workflow Automator** - Streamlined development tasks  
- ✅ **Integration Expert** - Connected multiple dev tools
- ✅ **Production Ready** - Created deployable solutions

---

## 🎓 Workshop Completion: Your Journey with Model Context Protocol

**Dear Workshop Participant,**

Congrats on finishing all four modules of the Model Context Protocol workshop! You’ve progressed from grasping AI Toolkit basics to building production-ready MCP servers that solve real-world development needs.

### 🚀 Your Learning Path Recap:

**[Module 1](../lab1/README.md)**: Started with AI Toolkit fundamentals, model testing, and your first AI agent.

**[Module 2](../lab2/README.md)**: Learned MCP architecture, integrated Playwright MCP, and created a browser automation agent.

**[Module 3](../lab3/README.md)**: Advanced to custom MCP server development with the Weather MCP server and mastered debugging.

**[Module 4](../lab4/README.md)**: Applied all skills to build a practical GitHub repository workflow automation tool.

### 🌟 What You've Mastered:

- ✅ **AI Toolkit Ecosystem**: Models, agents, and integration patterns
- ✅ **MCP Architecture**: Client-server design, transport protocols, and security
- ✅ **Developer Tools**: From Playground to Inspector to production deployment
- ✅ **Custom Development**: Building, testing, and deploying your own MCP servers
- ✅ **Practical Applications**: Solving real-world workflow challenges with AI

### 🔮 Your Next Steps:

1. **Build Your Own MCP Server**: Automate your unique workflows
2. **Join the MCP Community**: Share your work and learn from others
3. **Explore Advanced Integration**: Connect MCP servers with enterprise systems
4. **Contribute to Open Source**: Help improve MCP tools and documentation

Remember, this workshop is just the beginning. The Model Context Protocol ecosystem is evolving fast, and now you’re ready to lead in AI-powered development tools.

**Thank you for your participation and commitment to learning!**

We hope this workshop has inspired ideas that will transform how you build and interact with AI tools in your development journey.

**Happy coding!**

---

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.