<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a22b7dd11cd7690f99f9195877cafdc3",
  "translation_date": "2025-06-10T05:35:20+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab2/README.md",
  "language_code": "de"
}
-->
# 🌐 Modul 2: MCP mit AI Toolkit Grundlagen

[![Dauer](https://img.shields.io/badge/Duration-20%20minutes-blue.svg)]()
[![Schwierigkeitsgrad](https://img.shields.io/badge/Difficulty-Intermediate-yellow.svg)]()
[![Voraussetzungen](https://img.shields.io/badge/Prerequisites-Module%201%20Complete-orange.svg)]()

## 📋 Lernziele

Am Ende dieses Moduls wirst du in der Lage sein:
- ✅ Die Architektur und Vorteile des Model Context Protocol (MCP) zu verstehen
- ✅ Das MCP-Server-Ökosystem von Microsoft zu erkunden
- ✅ MCP-Server mit dem AI Toolkit Agent Builder zu integrieren
- ✅ Einen funktionalen Browser-Automatisierungsagenten mit Playwright MCP zu erstellen
- ✅ MCP-Tools innerhalb deiner Agenten zu konfigurieren und zu testen
- ✅ MCP-basierte Agenten für den Produktionseinsatz zu exportieren und bereitzustellen

## 🎯 Aufbauend auf Modul 1

In Modul 1 haben wir die Grundlagen des AI Toolkits gemeistert und unseren ersten Python-Agenten erstellt. Jetzt werden wir deine Agenten **superstärken**, indem wir sie über das revolutionäre **Model Context Protocol (MCP)** mit externen Tools und Diensten verbinden.

Stell dir das vor wie ein Upgrade von einem einfachen Taschenrechner zu einem vollwertigen Computer – deine KI-Agenten erhalten die Fähigkeit:
- 🌐 Websites zu durchsuchen und mit ihnen zu interagieren
- 📁 Dateien zu öffnen und zu bearbeiten
- 🔧 Sich in Unternehmenssysteme zu integrieren
- 📊 Echtzeitdaten von APIs zu verarbeiten

## 🧠 Das Model Context Protocol (MCP) verstehen

### 🔍 Was ist MCP?

Model Context Protocol (MCP) ist der **„USB-C für KI-Anwendungen“** – ein revolutionärer offener Standard, der Large Language Models (LLMs) mit externen Tools, Datenquellen und Diensten verbindet. So wie USB-C das Kabelchaos mit einem universellen Anschluss beseitigt hat, vereinfacht MCP die KI-Integration mit einem einheitlichen Protokoll.

### 🎯 Das Problem, das MCP löst

**Vor MCP:**
- 🔧 Individuelle Integrationen für jedes Tool
- 🔄 Vendor-Lock-in durch proprietäre Lösungen  
- 🔒 Sicherheitslücken durch Ad-hoc-Verbindungen
- ⏱️ Monate Entwicklungszeit für einfache Integrationen

**Mit MCP:**
- ⚡ Plug-and-Play-Tool-Integration
- 🔄 Vendor-agnostische Architektur
- 🛡️ Eingebaute Sicherheitsstandards
- 🚀 Neue Funktionen in Minuten hinzufügen

### 🏗️ MCP Architektur im Detail

MCP folgt einer **Client-Server-Architektur**, die ein sicheres, skalierbares Ökosystem schafft:

```mermaid
graph TB
    A[AI Application/Agent] --> B[MCP Client]
    B --> C[MCP Server 1: Files]
    B --> D[MCP Server 2: Web APIs]
    B --> E[MCP Server 3: Database]
    B --> F[MCP Server N: Custom Tools]
    
    C --> G[Local File System]
    D --> H[External APIs]
    E --> I[Database Systems]
    F --> J[Enterprise Systems]
```

**🔧 Kernkomponenten:**

| Komponente | Rolle | Beispiele |
|------------|-------|-----------|
| **MCP Hosts** | Anwendungen, die MCP-Dienste nutzen | Claude Desktop, VS Code, AI Toolkit |
| **MCP Clients** | Protokoll-Handler (1:1 zu Servern) | In Host-Anwendungen integriert |
| **MCP Servers** | Stellen Funktionen über Standardprotokoll bereit | Playwright, Files, Azure, GitHub |
| **Transportschicht** | Kommunikationsmethoden | stdio, HTTP, WebSockets |


## 🏢 Microsofts MCP Server-Ökosystem

Microsoft führt das MCP-Ökosystem mit einer umfassenden Suite an Enterprise-Servern, die reale Geschäftsanforderungen abdecken.

### 🌟 Ausgewählte Microsoft MCP Server

#### 1. ☁️ Azure MCP Server
**🔗 Repository**: [azure/azure-mcp](https://github.com/azure/azure-mcp)  
**🎯 Zweck**: Umfassendes Azure-Ressourcenmanagement mit KI-Integration

**✨ Hauptfunktionen:**
- Deklarative Infrastruktur-Bereitstellung
- Echtzeit-Überwachung von Ressourcen
- Empfehlungen zur Kostenoptimierung
- Prüfung der Sicherheitskonformität

**🚀 Anwendungsfälle:**
- Infrastructure-as-Code mit KI-Unterstützung
- Automatische Skalierung von Ressourcen
- Optimierung der Cloud-Kosten
- Automatisierung von DevOps-Workflows

#### 2. 📊 Microsoft Dataverse MCP
**📚 Dokumentation**: [Microsoft Dataverse Integration](https://go.microsoft.com/fwlink/?linkid=2320176)  
**🎯 Zweck**: Natürliche Sprachschnittstelle für Geschäftsdaten

**✨ Hauptfunktionen:**
- Datenbankabfragen in natürlicher Sprache
- Verständnis des Geschäftskontexts
- Anpassbare Prompt-Vorlagen
- Unternehmensweite Datenverwaltung

**🚀 Anwendungsfälle:**
- Business-Intelligence-Berichte
- Kundenanalysen
- Einblicke in Vertriebspipelines
- Abfragen zur Einhaltung von Vorschriften

#### 3. 🌐 Playwright MCP Server
**🔗 Repository**: [microsoft/playwright-mcp](https://github.com/microsoft/playwright-mcp)  
**🎯 Zweck**: Browser-Automatisierung und Web-Interaktionsfunktionen

**✨ Hauptfunktionen:**
- Browserübergreifende Automatisierung (Chrome, Firefox, Safari)
- Intelligente Elementerkennung
- Erstellung von Screenshots und PDFs
- Überwachung des Netzwerkverkehrs

**🚀 Anwendungsfälle:**
- Automatisierte Testabläufe
- Web-Scraping und Datenerfassung
- UI/UX-Überwachung
- Automatisierung der Wettbewerbsanalyse

#### 4. 📁 Files MCP Server
**🔗 Repository**: [microsoft/files-mcp-server](https://github.com/microsoft/files-mcp-server)  
**🎯 Zweck**: Intelligente Dateisystemoperationen

**✨ Hauptfunktionen:**
- Deklaratives Dateimanagement
- Inhaltssynchronisation
- Integration von Versionskontrolle
- Metadatenextraktion

**🚀 Anwendungsfälle:**
- Dokumentenverwaltung
- Organisation von Code-Repositories
- Workflows zur Inhaltsveröffentlichung
- Datei-Handling in Datenpipelines

#### 5. 📝 MarkItDown MCP Server
**🔗 Repository**: [microsoft/markitdown](https://github.com/microsoft/markitdown)  
**🎯 Zweck**: Erweiterte Markdown-Verarbeitung und -Manipulation

**✨ Hauptfunktionen:**
- Umfangreiche Markdown-Analyse
- Formatkonvertierung (MD ↔ HTML ↔ PDF)
- Inhaltsstruktur-Analyse
- Template-Verarbeitung

**🚀 Anwendungsfälle:**
- Technische Dokumentations-Workflows
- Content-Management-Systeme
- Berichtserstellung
- Automatisierung von Wissensdatenbanken

#### 6. 📈 Clarity MCP Server
**📦 Paket**: [@microsoft/clarity-mcp-server](https://www.npmjs.com/package/@microsoft/clarity-mcp-server)  
**🎯 Zweck**: Web-Analyse und Einblicke ins Nutzerverhalten

**✨ Hauptfunktionen:**
- Heatmap-Datenanalyse
- Aufzeichnung von Nutzer-Sitzungen
- Leistungskennzahlen
- Analyse von Conversion-Funnels

**🚀 Anwendungsfälle:**
- Website-Optimierung
- Nutzererfahrungsforschung
- A/B-Test-Auswertung
- Business-Intelligence-Dashboards

### 🌍 Community-Ökosystem

Neben Microsofts Servern umfasst das MCP-Ökosystem:
- **🐙 GitHub MCP**: Repository-Verwaltung und Code-Analyse
- **🗄️ Datenbank-MCPs**: PostgreSQL, MySQL, MongoDB-Integrationen
- **☁️ Cloud-Provider-MCPs**: AWS, GCP, Digital Ocean Tools
- **📧 Kommunikations-MCPs**: Slack, Teams, E-Mail-Integrationen

## 🛠️ Praxis-Lab: Einen Browser-Automatisierungsagenten bauen

**🎯 Projektziel**: Einen intelligenten Browser-Automatisierungsagenten mit dem Playwright MCP Server erstellen, der Websites navigieren, Informationen extrahieren und komplexe Web-Interaktionen durchführen kann.

### 🚀 Phase 1: Agentengrundlage einrichten

#### Schritt 1: Deinen Agenten initialisieren
1. **Öffne AI Toolkit Agent Builder**  
2. **Erstelle neuen Agenten** mit folgender Konfiguration:  
   - **Name**: `BrowserAgent`
   - **Model**: Choose GPT-4o 

![BrowserAgent](../../../../translated_images/BrowserAgent.09c1adde5e136573b64ab1baecd830049830e295eac66cb18bebb85fb386e00a.de.png)


### 🔧 Phase 2: MCP Integration Workflow

#### Step 3: Add MCP Server Integration
1. **Navigate to Tools Section** in Agent Builder
2. **Click "Add Tool"** to open the integration menu
3. **Select "MCP Server"** from available options

![AddMCP](../../../../translated_images/AddMCP.afe3308ac20aa94469a5717b632d77b2197b9838a438b05d39aeb2db3ec47ef1.de.png)

**🔍 Understanding Tool Types:**
- **Built-in Tools**: Pre-configured AI Toolkit functions
- **MCP Servers**: External service integrations
- **Custom APIs**: Your own service endpoints
- **Function Calling**: Direct model function access

#### Step 4: MCP Server Selection
1. **Choose "MCP Server"** option to proceed
![AddMCPServer](../../../../translated_images/AddMCPServer.69b911ccef872cbd0d0c0c2e6a00806916e1673e543b902a23dee23e6ff54b4c.de.png)

2. **Browse MCP Catalog** to explore available integrations
![MCPCatalog](../../../../translated_images/MCPCatalog.a817d053145699006264f5a475f2b48fbd744e43633f656b6453c15a09ba5130.de.png)


### 🎮 Phase 3: Playwright MCP Configuration

#### Step 5: Select and Configure Playwright
1. **Click "Use Featured MCP Servers"** to access Microsoft's verified servers
2. **Select "Playwright"** from the featured list
3. **Accept Default MCP ID** or customize for your environment

![MCPID](../../../../translated_images/MCPID.67d446052979e819c945ff7b6430196ef587f5217daadd3ca52fa9659c1245c9.de.png)

#### Step 6: Enable Playwright Capabilities
**🔑 Critical Step**: Select **ALL** available Playwright methods for maximum functionality

![Tools](../../../../translated_images/Tools.3ea23c447b4d9feccbd7101e6dcf9e27cb0e5273f351995fde62c5abf9a78b4c.de.png)

**🛠️ Essential Playwright Tools:**
- **Navigation**: `goto`, `goBack`, `goForward`, `reload`
- **Interaction**: `click`, `fill`, `press`, `hover`, `drag`
- **Extraction**: `textContent`, `innerHTML`, `getAttribute`
- **Validation**: `isVisible`, `isEnabled`, `waitForSelector`
- **Capture**: `screenshot`, `pdf`, `video`
- **Network**: `setExtraHTTPHeaders`, `route`, `waitForResponse`

#### Schritt 7: Integrationserfolg überprüfen
**✅ Erfolgskriterien:**
- Alle Tools erscheinen in der Agent Builder-Oberfläche
- Keine Fehlermeldungen im Integrationsbereich
- Playwright Server-Status zeigt „Connected“

![AgentTools](../../../../translated_images/AgentTools.053cfb96a17e02199dcc6563010d2b324d4fc3ebdd24889657a6950647a52f63.de.png)

**🔧 Häufige Probleme und Lösungen:**
- **Verbindung fehlgeschlagen**: Prüfe Internetverbindung und Firewall-Einstellungen  
- **Tools fehlen**: Stelle sicher, dass alle Funktionen bei der Einrichtung ausgewählt wurden  
- **Berechtigungsfehler**: Überprüfe, ob VS Code die notwendigen Systemrechte hat  

### 🎯 Phase 4: Fortgeschrittenes Prompt-Engineering

#### Schritt 8: Intelligente System-Prompts entwerfen  
Erstelle ausgefeilte Prompts, die Playwrights volle Fähigkeiten nutzen:

```markdown
# Web Automation Expert System Prompt

## Core Identity
You are an advanced web automation specialist with deep expertise in browser automation, web scraping, and user experience analysis. You have access to Playwright tools for comprehensive browser control.

## Capabilities & Approach
### Navigation Strategy
- Always start with screenshots to understand page layout
- Use semantic selectors (text content, labels) when possible
- Implement wait strategies for dynamic content
- Handle single-page applications (SPAs) effectively

### Error Handling
- Retry failed operations with exponential backoff
- Provide clear error descriptions and solutions
- Suggest alternative approaches when primary methods fail
- Always capture diagnostic screenshots on errors

### Data Extraction
- Extract structured data in JSON format when possible
- Provide confidence scores for extracted information
- Validate data completeness and accuracy
- Handle pagination and infinite scroll scenarios

### Reporting
- Include step-by-step execution logs
- Provide before/after screenshots for verification
- Suggest optimizations and alternative approaches
- Document any limitations or edge cases encountered

## Ethical Guidelines
- Respect robots.txt and rate limiting
- Avoid overloading target servers
- Only extract publicly available information
- Follow website terms of service
```

#### Schritt 9: Dynamische Benutzer-Prompts erstellen  
Gestalte Prompts, die verschiedene Funktionen demonstrieren:

**🌐 Beispiel Web-Analyse:**  
```markdown
Navigate to github.com/kinfey and provide a comprehensive analysis including:
1. Repository structure and organization
2. Recent activity and contribution patterns  
3. Documentation quality assessment
4. Technology stack identification
5. Community engagement metrics
6. Notable projects and their purposes

Include screenshots at key steps and provide actionable insights.
```

![Prompt](../../../../translated_images/Prompt.bfc846605db4999f4d9c1b09c710ef63cae7b3057444e68bf07240fb142d9f8f.de.png)

### 🚀 Phase 5: Ausführung und Test

#### Schritt 10: Deine erste Automatisierung ausführen
1. **Klicke auf „Run“**, um die Automatisierungssequenz zu starten  
2. **Beobachte die Echtzeit-Ausführung**:  
   - Chrome-Browser startet automatisch  
   - Agent navigiert zur Zielwebsite  
   - Screenshots dokumentieren jeden wichtigen Schritt  
   - Analyseergebnisse werden in Echtzeit angezeigt  

![Browser](../../../../translated_images/Browser.ec011d0bd64d0d112c8a29bd8cc44c76d0bbfd0b019cb2983ef679328435ce5d.de.png)

#### Schritt 11: Ergebnisse und Erkenntnisse analysieren  
Überprüfe die umfassende Analyse in der Agent Builder-Oberfläche:

![Result](../../../../translated_images/Result.8638f2b6703e9ea6d58d4e4475e39456b6a51d4c787f9bf481bae694d370a69a.de.png)

### 🌟 Phase 6: Erweiterte Funktionen und Bereitstellung

#### Schritt 12: Export und Produktionseinführung  
Agent Builder unterstützt verschiedene Bereitstellungsoptionen:

![Code](../../../../translated_images/Code.d9eeeead0b96db0ca19c5b10ad64cfea8c1d0d1736584262970a4d43e1403d13.de.png)

## 🎓 Modul 2 Zusammenfassung & nächste Schritte

### 🏆 Erfolg freigeschaltet: MCP-Integrationsmeister

**✅ Beherrschte Fähigkeiten:**
- [ ] MCP-Architektur und Vorteile verstehen  
- [ ] Das MCP-Server-Ökosystem von Microsoft navigieren  
- [ ] Playwright MCP mit AI Toolkit integrieren  
- [ ] Komplexe Browser-Automatisierungsagenten bauen  
- [ ] Fortgeschrittenes Prompt-Engineering für Web-Automatisierung  

### 📚 Zusätzliche Ressourcen

- **🔗 MCP-Spezifikation**: [Offizielle Protokolldokumentation](https://modelcontextprotocol.io/)  
- **🛠️ Playwright API**: [Vollständige Methodenreferenz](https://playwright.dev/docs/api/class-playwright)  
- **🏢 Microsoft MCP Server**: [Enterprise-Integrationsleitfaden](https://github.com/microsoft/mcp-servers)  
- **🌍 Community-Beispiele**: [MCP Server Galerie](https://github.com/modelcontextprotocol/servers)

**🎉 Herzlichen Glückwunsch!** Du hast die MCP-Integration erfolgreich gemeistert und kannst jetzt produktionsreife KI-Agenten mit externen Tool-Fähigkeiten erstellen!

### 🔜 Weiter zum nächsten Modul

Bereit, deine MCP-Kenntnisse auf die nächste Stufe zu heben? Fahre fort mit **[Modul 3: Fortgeschrittene MCP-Entwicklung mit AI Toolkit](../lab3/README.md)**, wo du lernst:
- Eigene benutzerdefinierte MCP-Server zu erstellen  
- Das neueste MCP Python SDK zu konfigurieren und zu nutzen  
- Den MCP Inspector für Debugging einzurichten  
- Fortgeschrittene Workflows für MCP-Serverentwicklung zu meistern  
- Einen Weather MCP Server von Grund auf zu bauen

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Verwendung dieser Übersetzung entstehen.