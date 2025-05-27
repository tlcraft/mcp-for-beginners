<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-27T16:18:28+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "cs"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) ist eine umfassende Referenzlösung von Microsoft, die zeigt, wie man eine multi-agentenbasierte, KI-gestützte Reiseplanungsanwendung mit dem Model Context Protocol (MCP), Azure OpenAI und Azure AI Search entwickelt. Dieses Projekt demonstriert Best Practices für die Orchestrierung mehrerer KI-Agenten, die Integration von Unternehmensdaten und die Bereitstellung einer sicheren, erweiterbaren Plattform für reale Anwendungsfälle.

## Key Features
- **Multi-Agent Orchestrierung:** Nutzt MCP zur Koordination spezialisierter Agenten (z. B. Flug-, Hotel- und Reiseplanungsagenten), die zusammenarbeiten, um komplexe Reiseplanungsaufgaben zu erfüllen.
- **Integration von Unternehmensdaten:** Verbindet Azure AI Search und andere Unternehmensdatenquellen, um aktuelle und relevante Informationen für Reiseempfehlungen bereitzustellen.
- **Sichere, skalierbare Architektur:** Verwendet Azure-Dienste für Authentifizierung, Autorisierung und skalierbare Bereitstellung und folgt dabei den Sicherheitsbestimmungen für Unternehmen.
- **Erweiterbare Werkzeuge:** Implementiert wiederverwendbare MCP-Tools und Prompt-Vorlagen, die eine schnelle Anpassung an neue Domänen oder Geschäftsanforderungen ermöglichen.
- **Benutzererlebnis:** Bietet eine konversationelle Schnittstelle, über die Nutzer mit den Reiseagenten interagieren können, angetrieben von Azure OpenAI und MCP.

## Architektur
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beschreibung des Architekturdiagramms

Die Azure AI Travel Agents Lösung ist modular, skalierbar und für eine sichere Integration mehrerer KI-Agenten und Unternehmensdatenquellen ausgelegt. Die Hauptkomponenten und der Datenfluss sind wie folgt:

- **Benutzeroberfläche:** Nutzer interagieren über eine konversationelle UI (z. B. Web-Chat oder Teams-Bot), die Anfragen sendet und Reiseempfehlungen empfängt.
- **MCP Server:** Dient als zentrale Orchestrierungseinheit, empfängt Nutzereingaben, verwaltet den Kontext und koordiniert die Aktionen spezialisierter Agenten (z. B. FlightAgent, HotelAgent, ItineraryAgent) über das Model Context Protocol.
- **KI-Agenten:** Jeder Agent ist für einen bestimmten Bereich zuständig (Flüge, Hotels, Reisepläne) und als MCP-Tool implementiert. Agenten verwenden Prompt-Vorlagen und Logik, um Anfragen zu verarbeiten und Antworten zu generieren.
- **Azure OpenAI Service:** Bietet fortschrittliches natürliches Sprachverständnis und -generierung, damit Agenten Nutzerintentionen interpretieren und konversationelle Antworten erzeugen können.
- **Azure AI Search & Unternehmensdaten:** Agenten durchsuchen Azure AI Search und andere Unternehmensdatenquellen, um aktuelle Informationen zu Flügen, Hotels und Reiseoptionen abzurufen.
- **Authentifizierung & Sicherheit:** Integriert Microsoft Entra ID für sichere Authentifizierung und setzt das Prinzip der geringsten Rechte für den Zugriff auf alle Ressourcen durch.
- **Bereitstellung:** Für die Bereitstellung auf Azure Container Apps konzipiert, was Skalierbarkeit, Monitoring und Betriebseffizienz gewährleistet.

Diese Architektur ermöglicht eine nahtlose Orchestrierung mehrerer KI-Agenten, sichere Integration von Unternehmensdaten und eine robuste, erweiterbare Plattform für domänenspezifische KI-Lösungen.

## Schritt-für-Schritt-Erklärung des Architekturdiagramms
Stellen Sie sich vor, Sie planen eine große Reise und haben ein Team von Experten, die Ihnen bei jedem Detail helfen. Das Azure AI Travel Agents System funktioniert ähnlich, indem es verschiedene Teile (wie Teammitglieder) nutzt, die jeweils eine spezielle Aufgabe haben. So funktioniert das Zusammenspiel:

### Benutzeroberfläche (UI):
Man kann sich das wie den Empfang Ihres Reisebüros vorstellen. Hier stellen Sie (der Nutzer) Fragen oder machen Anfragen, z. B. „Finde mir einen Flug nach Paris.“ Das kann ein Chatfenster auf einer Website oder eine Messaging-App sein.

### MCP Server (Der Koordinator):
Der MCP Server ist wie der Manager, der Ihre Anfrage am Empfang entgegennimmt und entscheidet, welcher Spezialist sich um welchen Teil kümmert. Er verfolgt das Gespräch und sorgt dafür, dass alles reibungslos abläuft.

### KI-Agenten (Fachliche Assistenten):
Jeder Agent ist Experte in einem bestimmten Bereich – einer kennt sich mit Flügen aus, ein anderer mit Hotels, ein weiterer mit der Reiseplanung. Wenn Sie eine Anfrage stellen, leitet der MCP Server diese an den passenden Agenten weiter. Diese nutzen ihr Wissen und ihre Werkzeuge, um die besten Optionen für Sie zu finden.

### Azure OpenAI Service (Sprachspezialist):
Das ist wie ein Sprachprofi, der genau versteht, was Sie fragen, egal wie Sie es formulieren. Er hilft den Agenten, Ihre Anfragen zu verstehen und in natürlicher Sprache zu antworten.

### Azure AI Search & Unternehmensdaten (Informationsbibliothek):
Stellen Sie sich eine riesige, stets aktuelle Bibliothek vor mit allen neuesten Reiseinformationen – Flugpläne, Hotelverfügbarkeiten und mehr. Die Agenten durchsuchen diese Bibliothek, um die genauesten Antworten zu liefern.

### Authentifizierung & Sicherheit (Sicherheitsdienst):
Wie ein Wachmann, der kontrolliert, wer welche Bereiche betreten darf, sorgt dieser Teil dafür, dass nur autorisierte Personen und Agenten Zugang zu sensiblen Informationen haben. Er schützt Ihre Daten sicher und vertraulich.

### Bereitstellung auf Azure Container Apps (Das Gebäude):
Alle diese Assistenten und Werkzeuge arbeiten zusammen in einem sicheren, skalierbaren Gebäude (der Cloud). So kann das System viele Nutzer gleichzeitig bedienen und ist jederzeit verfügbar, wenn Sie es brauchen.

## Wie alles zusammenwirkt:

Sie stellen eine Frage am Empfang (UI).
Der Manager (MCP Server) entscheidet, welcher Spezialist (Agent) Ihnen hilft.
Der Spezialist nutzt den Sprachprofi (OpenAI), um Ihre Anfrage zu verstehen, und die Bibliothek (AI Search), um die beste Antwort zu finden.
Der Sicherheitsdienst (Authentifizierung) stellt sicher, dass alles sicher abläuft.
Das alles geschieht in einem zuverlässigen, skalierbaren Gebäude (Azure Container Apps), damit Ihr Erlebnis reibungslos und sicher ist.
Dieses Zusammenspiel ermöglicht es dem System, Ihnen schnell und sicher bei der Reiseplanung zu helfen – wie ein Team von erfahrenen Reiseagenten in einem modernen Büro!

## Technische Umsetzung
- **MCP Server:** Beherbergt die Kernlogik der Orchestrierung, stellt Agenten-Tools bereit und verwaltet den Kontext für mehrstufige Reiseplanungs-Workflows.
- **Agenten:** Jeder Agent (z. B. FlightAgent, HotelAgent) ist als MCP-Tool mit eigenen Prompt-Vorlagen und Logik implementiert.
- **Azure-Integration:** Nutzt Azure OpenAI für natürliches Sprachverständnis und Azure AI Search für die Datenabfrage.
- **Sicherheit:** Integriert Microsoft Entra ID für Authentifizierung und setzt das Prinzip der geringsten Rechte für den Zugriff auf alle Ressourcen durch.
- **Bereitstellung:** Unterstützt die Bereitstellung auf Azure Container Apps für Skalierbarkeit und Betriebseffizienz.

## Ergebnisse und Auswirkungen
- Zeigt, wie MCP genutzt werden kann, um mehrere KI-Agenten in einem produktionsreifen, realen Szenario zu orchestrieren.
- Beschleunigt die Lösungsentwicklung durch wiederverwendbare Muster für Agentenkoordination, Datenintegration und sichere Bereitstellung.
- Dient als Vorlage zum Aufbau domänenspezifischer, KI-gestützter Anwendungen mit MCP und Azure-Diensten.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vzniklé použitím tohoto překladu.