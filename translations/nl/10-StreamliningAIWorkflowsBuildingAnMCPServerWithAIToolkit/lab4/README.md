<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:52:39+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "nl"
}
-->
# 🐙 Module 4: Praktische MCP-ontwikkeling - Aangepaste GitHub Clone Server

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ Snel aan de slag:** Bouw in slechts 30 minuten een productieklare MCP-server die het klonen van GitHub-repositories en de integratie met VS Code automatiseert!

## 🎯 Leerdoelen

Aan het einde van deze lab kun je:

- ✅ Een aangepaste MCP-server maken voor realistische ontwikkelworkflows
- ✅ Functionaliteit voor het klonen van GitHub-repositories via MCP implementeren
- ✅ Aangepaste MCP-servers integreren met VS Code en Agent Builder
- ✅ GitHub Copilot Agent Mode gebruiken met aangepaste MCP-tools
- ✅ Aangepaste MCP-servers testen en uitrollen in productieomgevingen

## 📋 Vereisten

- Voltooiing van Labs 1-3 (MCP basisprincipes en gevorderde ontwikkeling)
- GitHub Copilot abonnement ([gratis aanmelding beschikbaar](https://github.com/github-copilot/signup))
- VS Code met AI Toolkit en GitHub Copilot extensies
- Git CLI geïnstalleerd en geconfigureerd

## 🏗️ Projectoverzicht

### **Realistische Ontwikkeluitdaging**
Als ontwikkelaars gebruiken we vaak GitHub om repositories te klonen en deze te openen in VS Code of VS Code Insiders. Dit handmatige proces bestaat uit:
1. Terminal/command prompt openen
2. Naar de gewenste map navigeren
3. Het `git clone` commando uitvoeren
4. VS Code openen in de gekloonde map

**Onze MCP-oplossing stroomlijnt dit tot één slimme opdracht!**

### **Wat je gaat bouwen**
Een **GitHub Clone MCP Server** (`git_mcp_server`) die het volgende biedt:

| Functie | Beschrijving | Voordeel |
|---------|-------------|----------|
| 🔄 **Slim repository klonen** | GitHub repos klonen met validatie | Geautomatiseerde foutcontrole |
| 📁 **Intelligent mapbeheer** | Veilig controleren en aanmaken van mappen | Voorkomt overschrijven |
| 🚀 **Cross-platform VS Code integratie** | Projecten openen in VS Code/Insiders | Naadloze workflowovergang |
| 🛡️ **Robuuste foutafhandeling** | Omgaan met netwerk-, permissie- en padproblemen | Betrouwbaar voor productie |

---

## 📖 Stapsgewijze Implementatie

### Stap 1: Maak een GitHub Agent in Agent Builder

1. **Start Agent Builder** via de AI Toolkit extensie
2. **Maak een nieuwe agent aan** met de volgende configuratie:
   ```
   Agent Name: GitHubAgent
   ```

3. **Initialiseer de aangepaste MCP-server:**
   - Ga naar **Tools** → **Add Tool** → **MCP Server**
   - Kies **"Create A new MCP Server"**
   - Selecteer de **Python template** voor maximale flexibiliteit
   - **Servernaam:** `git_mcp_server`

### Stap 2: Configureer GitHub Copilot Agent Mode

1. **Open GitHub Copilot** in VS Code (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. **Selecteer Agent Model** in de Copilot interface
3. **Kies het Claude 3.7 model** voor verbeterde redeneercapaciteiten
4. **Schakel MCP-integratie in** voor toegang tot tools

> **💡 Pro Tip:** Claude 3.7 biedt een beter begrip van ontwikkelworkflows en foutafhandelingspatronen.

### Stap 3: Implementeer de kernfunctionaliteit van de MCP-server

**Gebruik de volgende gedetailleerde prompt met GitHub Copilot Agent Mode:**

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

### Stap 4: Test je MCP-server

#### 4a. Test in Agent Builder

1. **Start de debugconfiguratie** voor Agent Builder
2. **Configureer je agent met deze system prompt:**

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **Test met realistische gebruikersscenario’s:**

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.nl.png)

**Verwachte resultaten:**
- ✅ Succesvol klonen met padbevestiging
- ✅ Automatisch starten van VS Code
- ✅ Duidelijke foutmeldingen bij ongeldige situaties
- ✅ Correcte afhandeling van randgevallen

#### 4b. Test in MCP Inspector

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.nl.png)

---

**🎉 Gefeliciteerd!** Je hebt met succes een praktische, productieklare MCP-server gemaakt die echte ontwikkelworkflow-uitdagingen oplost. Je aangepaste GitHub clone server laat zien hoe krachtig MCP is voor het automatiseren en verbeteren van de productiviteit van ontwikkelaars.

### 🏆 Behaalde prestaties:
- ✅ **MCP Developer** - Aangepaste MCP-server gemaakt
- ✅ **Workflow Automator** - Ontwikkelprocessen gestroomlijnd  
- ✅ **Integration Expert** - Meerdere ontwikkeltools verbonden
- ✅ **Production Ready** - Oplossingen klaar voor uitrol

---

## 🎓 Workshop voltooid: Je reis met Model Context Protocol

**Beste workshopdeelnemer,**

Gefeliciteerd met het afronden van alle vier modules van de Model Context Protocol workshop! Je bent van de basisprincipes van AI Toolkit naar het bouwen van productieklare MCP-servers gegaan die echte ontwikkeluitdagingen oplossen.

### 🚀 Samenvatting van je leerpad:

**[Module 1](../lab1/README.md)**: Je begon met het verkennen van AI Toolkit basisprincipes, modeltesten en het maken van je eerste AI-agent.

**[Module 2](../lab2/README.md)**: Je leerde de MCP-architectuur, integreerde Playwright MCP en bouwde je eerste browserautomatiseringsagent.

**[Module 3](../lab3/README.md)**: Je ging verder met aangepaste MCP-serverontwikkeling met de Weather MCP-server en beheerde debuggingtools.

**[Module 4](../lab4/README.md)**: Nu heb je alles toegepast om een praktische automatiseringstool voor GitHub-repository workflows te maken.

### 🌟 Wat je hebt beheerst:

- ✅ **AI Toolkit Ecosysteem**: Modellen, agents en integratiepatronen
- ✅ **MCP Architectuur**: Client-server ontwerp, transportprotocollen en beveiliging
- ✅ **Ontwikkeltools**: Van Playground tot Inspector en productie-uitrol
- ✅ **Aangepaste ontwikkeling**: Bouwen, testen en uitrollen van eigen MCP-servers
- ✅ **Praktische toepassingen**: Oplossen van echte workflow-uitdagingen met AI

### 🔮 Je volgende stappen:

1. **Bouw je eigen MCP-server**: Pas deze vaardigheden toe om je eigen workflows te automatiseren
2. **Sluit je aan bij de MCP-community**: Deel je creaties en leer van anderen
3. **Verken geavanceerde integraties**: Verbind MCP-servers met enterprise-systemen
4. **Draag bij aan open source**: Help MCP-tools en documentatie te verbeteren

Onthoud dat deze workshop slechts het begin is. Het Model Context Protocol ecosysteem ontwikkelt zich snel en jij bent nu klaar om voorop te lopen in AI-gedreven ontwikkeltools.

**Bedankt voor je deelname en je inzet om te leren!**

We hopen dat deze workshop ideeën heeft aangewakkerd die je manier van bouwen en samenwerken met AI-tools in je ontwikkeltraject zullen transformeren.

**Veel programmeerplezier!**

---

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.