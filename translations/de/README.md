<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:10:01+00:00",
  "source_file": "README.md",
  "language_code": "de"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.de.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Folge diesen Schritten, um mit diesen Ressourcen zu starten:
1. **Forke das Repository**: Klicke auf [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klon das Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Tritt dem Azure AI Foundry Discord bei und triff Experten sowie andere Entwickler**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Mehrsprachige Unterstützung

#### Unterstützt durch GitHub Action (Automatisiert & immer aktuell)

# 🚀 Model Context Protocol (MCP) Curriculum für Einsteiger

## **Lerne MCP mit praxisnahen Code-Beispielen in C#, Java, JavaScript, Python und TypeScript**

## 🧠 Überblick über das Model Context Protocol Curriculum

Das **Model Context Protocol (MCP)** ist ein modernes Framework, das darauf ausgelegt ist, die Interaktionen zwischen KI-Modellen und Client-Anwendungen zu standardisieren. Dieses Open-Source-Curriculum bietet einen strukturierten Lernpfad mit praktischen Programmierbeispielen und realen Anwendungsfällen in den gängigen Programmiersprachen C#, Java, JavaScript, TypeScript und Python.

Egal, ob du KI-Entwickler, Systemarchitekt oder Softwareingenieur bist – dieser Leitfaden ist deine umfassende Ressource, um die Grundlagen und Implementierungsstrategien von MCP zu meistern.

## 🔗 Offizielle MCP-Ressourcen

- 📘 [MCP Dokumentation](https://modelcontextprotocol.io/) – Ausführliche Tutorials und Benutzerhandbücher  
- 📜 [MCP Spezifikation](https://spec.modelcontextprotocol.io/) – Protokollarchitektur und technische Referenzen  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Open-Source-SDKs, Tools und Codebeispiele  

## 🧭 Vollständige MCP Curriculum-Struktur

| Ch | Titel | Beschreibung | Link |
|--|--|--|--|
| 00 | **Einführung in MCP** | Überblick über das Model Context Protocol und seine Bedeutung in KI-Pipelines, einschließlich was das Model Context Protocol ist, warum Standardisierung wichtig ist sowie praktische Anwendungsfälle und Vorteile | [Einführung](./00-Introduction/README.md) |
| 01 | **Kernkonzepte erklärt** | Detaillierte Erläuterung der Kernkonzepte von MCP, darunter Client-Server-Architektur, wichtige Protokollkomponenten und Nachrichtenmuster | [Kernkonzepte](./01-CoreConcepts/README.md) |
| 02 | **Sicherheit in MCP** | Erkennen von Sicherheitsbedrohungen in MCP-basierten Systemen, Techniken und Best Practices zur Absicherung von Implementierungen | [Sicherheit](./02-Security/README.md) |
| 03 | **Erste Schritte mit MCP** | Einrichtung und Konfiguration der Umgebung, Erstellen einfacher MCP-Server und -Clients, Integration von MCP in bestehende Anwendungen | [Erste Schritte](./03-GettingStarted/README.md) |
| 3.1 | **Erster Server** | Aufbau eines einfachen Servers mit dem MCP-Protokoll, Verständnis der Server-Client-Interaktion und Testen des Servers | [Erster Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Erster Client** | Aufbau eines einfachen Clients mit dem MCP-Protokoll, Verständnis der Client-Server-Interaktion und Testen des Clients | [Erster Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Client mit LLM** | Aufbau eines Clients mit dem MCP-Protokoll unter Verwendung eines Large Language Models (LLM) | [Client mit LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Einen Server mit Visual Studio Code konsumieren** | Einrichtung von Visual Studio Code zur Nutzung von Servern über das MCP-Protokoll | [Einen Server mit Visual Studio Code konsumieren](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Erstellen eines Servers mit SSE** | SSE ermöglicht es uns, einen Server öffentlich zugänglich zu machen. Dieser Abschnitt hilft dir, einen Server mit SSE zu erstellen | [Erstellen eines Servers mit SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Lerne, wie man HTTP Streaming für die Echtzeit-Datenübertragung zwischen Clients und MCP-Servern implementiert | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Verwendung des AI Toolkits** | Das AI Toolkit ist ein großartiges Werkzeug, das dir hilft, deinen KI- und MCP-Workflow zu verwalten | [Verwendung des AI Toolkits](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testen deines Servers** | Testen ist ein wichtiger Teil des Entwicklungsprozesses. Dieser Abschnitt zeigt dir, wie du verschiedene Tools zum Testen einsetzen kannst | [Testen deines Servers](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Bereitstellung deines Servers** | Wie gelangst du von der lokalen Entwicklung zur Produktion? Dieser Abschnitt hilft dir beim Entwickeln und Bereitstellen deines Servers | [Bereitstellung deines Servers](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktische Umsetzung** | Nutzung von SDKs in verschiedenen Sprachen, Debugging, Testen und Validierung, Erstellung wiederverwendbarer Prompt-Vorlagen und Workflows | [Praktische Umsetzung](./04-PracticalImplementation/README.md) |
| 05 | **Fortgeschrittene Themen in MCP** | Multimodale KI-Workflows und Erweiterbarkeit, sichere Skalierungsstrategien, MCP in Unternehmensökosystemen | [Fortgeschrittene Themen](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP Integration mit Azure** | Zeigt die Integration mit Azure | [MCP Azure Integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalität** | Zeigt, wie man mit verschiedenen Modalitäten wie Bildern und mehr arbeitet | [Multimodalität](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalistische Spring Boot App, die OAuth2 mit MCP zeigt – sowohl als Autorisierungs- als auch als Ressourcenserver. Demonstriert sichere Token-Ausgabe, geschützte Endpunkte, Deployment auf Azure Container Apps und Integration mit API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Erfahre mehr über Root Contexts und wie man sie implementiert | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Lerne verschiedene Arten von Routing kennen | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Lerne, wie man mit Sampling arbeitet | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skalierung** | Erfahre, wie man MCP-Server skaliert, einschließlich horizontaler und vertikaler Skalierungsstrategien, Ressourcenoptimierung und Performance-Tuning | [Skalierung](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sicherheit** | Schütze deinen MCP-Server, einschließlich Authentifizierungs-, Autorisierungs- und Datenschutzstrategien | [Sicherheit](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP-Server und Client mit Integration von SerpAPI für Echtzeit-Web-, Nachrichten-, Produktsuche und Q&A. Demonstriert Multi-Tool-Orchestrierung, externe API-Integration und robustes Fehlerhandling | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Echtzeit-Streaming** | Echtzeit-Datenstreaming ist heute unverzichtbar, da Unternehmen und Anwendungen sofortigen Zugriff auf Informationen benötigen, um rechtzeitig Entscheidungen zu treffen | [Echtzeit-Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Echtzeit-Websuche** | Wie MCP die Echtzeit-Websuche revolutioniert, indem es einen standardisierten Ansatz für das Kontextmanagement zwischen KI-Modellen, Suchmaschinen und Anwendungen bietet | [Echtzeit-Websuche](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Community-Beiträge** | Wie man Code und Dokumentation beisteuert, Zusammenarbeit über GitHub, gemeinschaftlich getriebene Verbesserungen und Feedback | [Community-Beiträge](./06-CommunityContributions/README.md) |
| 07 | **Erkenntnisse aus der frühen Einführung** | Praxisnahe Implementierungen und was funktioniert hat, Aufbau und Bereitstellung von MCP-basierten Lösungen, Trends und zukünftiger Fahrplan | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Best Practices für MCP** | Performance-Optimierung und Feinabstimmung, Gestaltung fehlertoleranter MCP-Systeme, Test- und Resilienzstrategien | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP Fallstudien** | Tiefgehende Einblicke in MCP-Lösungsarchitekturen, Bereitstellungspläne und Integrationstipps, annotierte Diagramme und Projekt-Durchläufe | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **KI-Workflows optimieren: Aufbau eines MCP-Servers mit AI Toolkit** | Umfassender praxisorientierter Workshop, der MCP mit Microsofts AI Toolkit für VS Code kombiniert. Lernen Sie, intelligente Anwendungen zu erstellen, die KI-Modelle mit realen Werkzeugen verbinden – durch praktische Module zu Grundlagen, kundenspezifischer Serverentwicklung und Strategien für die Produktion. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Beispielprojekte

### 🧮 MCP Rechner Beispielprojekte:
<details>
  <summary><strong>Code-Implementierungen nach Sprache erkunden</strong></summary>

  - [C# MCP Server Beispiel](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Rechner](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Beispiel](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Fortgeschrittene Rechnerprojekte:
<details>
  <summary><strong>Fortgeschrittene Beispiele entdecken</strong></summary>

  - [Fortgeschrittenes C# Beispiel](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Beispiel](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Fortgeschrittenes Beispiel](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Komplexe Implementierung](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Beispiel](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Voraussetzungen für das Lernen von MCP

Um das Beste aus diesem Curriculum herauszuholen, solltest du Folgendes mitbringen:

- Grundkenntnisse in C#, Java oder Python  
- Verständnis des Client-Server-Modells und von APIs  
- (Optional) Vertrautheit mit Konzepten des maschinellen Lernens  

## 📚 Lernleitfaden

Ein umfassender [Lernleitfaden](./study_guide.md) steht zur Verfügung, um dir eine effektive Navigation durch dieses Repository zu ermöglichen. Der Leitfaden enthält:

- Eine visuelle Übersicht des Curriculums mit allen behandelten Themen  
- Detaillierte Aufschlüsselung der einzelnen Repository-Bereiche  
- Anleitungen zur Nutzung der Beispielprojekte  
- Empfohlene Lernpfade für unterschiedliche Kenntnisstufen  
- Zusätzliche Ressourcen zur Ergänzung deiner Lernreise  

## 🛠️ So nutzt du dieses Curriculum effektiv

Jede Lektion in diesem Leitfaden beinhaltet:

1. Klare Erklärungen zu MCP-Konzepten  
2. Live-Code-Beispiele in verschiedenen Programmiersprachen  
3. Übungen zum Aufbau realer MCP-Anwendungen  
4. Zusätzliche Ressourcen für Fortgeschrittene  

## 📜 Lizenzinformationen

Dieser Inhalt steht unter der **MIT-Lizenz**. Die Bedingungen findest du in der [LICENSE](../../LICENSE).

## 🤝 Beitragsrichtlinien

Dieses Projekt freut sich über Beiträge und Vorschläge. Die meisten Beiträge erfordern, dass du einer Contributor License Agreement (CLA) zustimmst, die bestätigt, dass du das Recht hast und tatsächlich die Rechte gewährst, deine Beiträge zu nutzen. Details findest du unter <https://cla.opensource.microsoft.com>.

Wenn du eine Pull-Anfrage einreichst, prüft ein CLA-Bot automatisch, ob du eine CLA bereitstellen musst und versieht die PR entsprechend (z. B. Status-Check, Kommentar). Folge einfach den Anweisungen des Bots. Dies musst du nur einmal für alle Repositories mit unserer CLA tun.

Dieses Projekt hat den [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) übernommen. Weitere Informationen findest du in den [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) oder kontaktiere [opencode@microsoft.com](mailto:opencode@microsoft.com) bei weiteren Fragen oder Anmerkungen.

## 🎒 Weitere Kurse
Unser Team bietet weitere Kurse an! Schau dir an:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot für AI Paired Programming meistern](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot für C#/.NET-Entwickler meistern](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Wähle dein eigenes Copilot-Abenteuer](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Markenzeichen-Hinweis

Dieses Projekt kann Marken oder Logos von Projekten, Produkten oder Dienstleistungen enthalten. Die autorisierte Verwendung von Microsoft-Marken oder -Logos unterliegt und muss den
[Microsoft Marken- und Markenrichtlinien](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) entsprechen.
Die Verwendung von Microsoft-Marken oder -Logos in modifizierten Versionen dieses Projekts darf nicht zu Verwechslungen führen oder eine Microsoft-Unterstützung suggerieren.
Jegliche Nutzung von Marken oder Logos Dritter unterliegt den Richtlinien dieser Dritten.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.