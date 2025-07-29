<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-07-29T01:01:23+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "de"
}
-->
# MCP in Aktion: Fallstudien aus der Praxis

[![MCP in Aktion: Fallstudien aus der Praxis](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.de.png)](https://youtu.be/IxshWb2Az5w)

_(Klicken Sie auf das Bild oben, um das Video zu dieser Lektion anzusehen)_

Das Model Context Protocol (MCP) revolutioniert die Art und Weise, wie KI-Anwendungen mit Daten, Tools und Diensten interagieren. In diesem Abschnitt werden Fallstudien aus der Praxis vorgestellt, die die Anwendung von MCP in verschiedenen Unternehmensszenarien demonstrieren.

## Überblick

Dieser Abschnitt zeigt konkrete Beispiele für MCP-Implementierungen und hebt hervor, wie Organisationen dieses Protokoll nutzen, um komplexe geschäftliche Herausforderungen zu lösen. Durch die Analyse dieser Fallstudien erhalten Sie Einblicke in die Vielseitigkeit, Skalierbarkeit und praktischen Vorteile von MCP in realen Szenarien.

## Wichtige Lernziele

Durch die Untersuchung dieser Fallstudien werden Sie:

- Verstehen, wie MCP zur Lösung spezifischer Geschäftsprobleme eingesetzt werden kann
- Verschiedene Integrationsmuster und architektonische Ansätze kennenlernen
- Best Practices für die Implementierung von MCP in Unternehmensumgebungen erkennen
- Einblicke in die Herausforderungen und Lösungen bei realen Implementierungen gewinnen
- Möglichkeiten identifizieren, ähnliche Muster in Ihren eigenen Projekten anzuwenden

## Vorgestellte Fallstudien

### 1. [Azure AI Reiseagenten – Referenzimplementierung](./travelagentsample.md)

Diese Fallstudie untersucht Microsofts umfassende Referenzlösung, die zeigt, wie eine Multi-Agenten-, KI-gestützte Reiseplanungsanwendung mit MCP, Azure OpenAI und Azure AI Search erstellt werden kann. Das Projekt umfasst:

- Multi-Agenten-Orchestrierung durch MCP
- Integration von Unternehmensdaten mit Azure AI Search
- Sichere, skalierbare Architektur mit Azure-Diensten
- Erweiterbare Tools mit wiederverwendbaren MCP-Komponenten
- Konversationserlebnis für Benutzer, unterstützt durch Azure OpenAI

Die Architektur- und Implementierungsdetails bieten wertvolle Einblicke in den Aufbau komplexer Multi-Agenten-Systeme mit MCP als Koordinierungsschicht.

### 2. [Aktualisierung von Azure DevOps-Elementen mit YouTube-Daten](./UpdateADOItemsFromYT.md)

Diese Fallstudie zeigt eine praktische Anwendung von MCP zur Automatisierung von Arbeitsabläufen. Sie demonstriert, wie MCP-Tools verwendet werden können, um:

- Daten von Online-Plattformen (YouTube) zu extrahieren
- Arbeitselemente in Azure DevOps-Systemen zu aktualisieren
- Wiederholbare Automatisierungsabläufe zu erstellen
- Daten über verschiedene Systeme hinweg zu integrieren

Dieses Beispiel zeigt, wie selbst relativ einfache MCP-Implementierungen erhebliche Effizienzsteigerungen durch die Automatisierung routinemäßiger Aufgaben und die Verbesserung der Datenkonsistenz zwischen Systemen bieten können.

### 3. [Echtzeit-Dokumentenabruf mit MCP](./docs-mcp/README.md)

Diese Fallstudie führt Sie durch die Verbindung eines Python-Konsolenclients mit einem Model Context Protocol (MCP)-Server, um Echtzeit-, kontextbezogene Microsoft-Dokumentation abzurufen und zu protokollieren. Sie lernen, wie man:

- Mit einem Python-Client und dem offiziellen MCP SDK eine Verbindung zu einem MCP-Server herstellt
- Streaming-HTTP-Clients für effizienten Echtzeit-Datenabruf verwendet
- Dokumentationstools auf dem Server aufruft und Antworten direkt in der Konsole protokolliert
- Aktuelle Microsoft-Dokumentation in Ihren Arbeitsablauf integriert, ohne das Terminal zu verlassen

Das Kapitel enthält eine praktische Aufgabe, ein minimal funktionierendes Codebeispiel und Links zu zusätzlichen Ressourcen für vertiefendes Lernen. Sehen Sie sich die vollständige Anleitung und den Code im verlinkten Kapitel an, um zu verstehen, wie MCP den Zugriff auf Dokumentation und die Produktivität von Entwicklern in konsolenbasierten Umgebungen transformieren kann.

### 4. [Interaktive Studienplan-Generator-Web-App mit MCP](./docs-mcp/README.md)

Diese Fallstudie zeigt, wie man eine interaktive Webanwendung mit Chainlit und dem Model Context Protocol (MCP) erstellt, um personalisierte Studienpläne für jedes Thema zu generieren. Benutzer können ein Thema (z. B. "AI-900-Zertifizierung") und eine Studiendauer (z. B. 8 Wochen) angeben, und die App liefert eine wöchentliche Übersicht über empfohlene Inhalte. Chainlit ermöglicht eine konversationelle Chat-Oberfläche, die das Erlebnis ansprechend und adaptiv macht.

- Konversationelle Web-App, unterstützt durch Chainlit
- Benutzerdefinierte Eingaben für Thema und Dauer
- Wöchentliche Inhaltsvorschläge mit MCP
- Echtzeit-, adaptive Antworten in einer Chat-Oberfläche

Das Projekt zeigt, wie konversationelle KI und MCP kombiniert werden können, um dynamische, benutzergesteuerte Bildungswerkzeuge in einer modernen Webumgebung zu schaffen.

### 5. [In-Editor-Dokumentation mit MCP-Server in VS Code](./docs-mcp/README.md)

Diese Fallstudie zeigt, wie Sie Microsoft Learn-Dokumente direkt in Ihre VS Code-Umgebung bringen können, ohne zwischen Browser-Tabs wechseln zu müssen! Sie erfahren, wie man:

- Dokumente sofort in VS Code durchsucht und liest, entweder über das MCP-Panel oder die Befehlspalette
- Dokumentationslinks direkt in README- oder Kurs-Markdown-Dateien einfügt
- GitHub Copilot und MCP zusammen für nahtlose, KI-gestützte Dokumentations- und Code-Arbeitsabläufe verwendet
- Dokumentation mit Echtzeit-Feedback und Microsoft-Quellen überprüft und verbessert
- MCP mit GitHub-Arbeitsabläufen für kontinuierliche Dokumentationsvalidierung integriert

Die Implementierung umfasst:

- Beispielkonfiguration `.vscode/mcp.json` für einfache Einrichtung
- Screenshot-basierte Anleitungen zur In-Editor-Erfahrung
- Tipps zur Kombination von Copilot und MCP für maximale Produktivität

Dieses Szenario ist ideal für Kursautoren, Dokumentationsschreiber und Entwickler, die sich auf ihre Arbeit im Editor konzentrieren möchten, während sie mit Dokumenten, Copilot und Validierungstools arbeiten – alles unterstützt durch MCP.

### 6. [Erstellung eines APIM MCP-Servers](./apimsample.md)

Diese Fallstudie bietet eine Schritt-für-Schritt-Anleitung zur Erstellung eines MCP-Servers mit Azure API Management (APIM). Sie behandelt:

- Einrichtung eines MCP-Servers in Azure API Management
- Exponierung von API-Operationen als MCP-Tools
- Konfiguration von Richtlinien für Ratenbegrenzung und Sicherheit
- Testen des MCP-Servers mit Visual Studio Code und GitHub Copilot

Dieses Beispiel zeigt, wie man die Fähigkeiten von Azure nutzt, um einen robusten MCP-Server zu erstellen, der in verschiedenen Anwendungen verwendet werden kann und die Integration von KI-Systemen mit Unternehmens-APIs verbessert.

## Fazit

Diese Fallstudien zeigen die Vielseitigkeit und praktischen Anwendungen des Model Context Protocol in realen Szenarien. Von komplexen Multi-Agenten-Systemen bis hin zu gezielten Automatisierungsabläufen bietet MCP eine standardisierte Möglichkeit, KI-Systeme mit den Tools und Daten zu verbinden, die sie benötigen, um Mehrwert zu schaffen.

Durch das Studium dieser Implementierungen können Sie Einblicke in Architektur-Muster, Implementierungsstrategien und Best Practices gewinnen, die auf Ihre eigenen MCP-Projekte angewendet werden können. Die Beispiele zeigen, dass MCP nicht nur ein theoretisches Framework ist, sondern eine praktische Lösung für reale geschäftliche Herausforderungen.

## Zusätzliche Ressourcen

- [Azure AI Reiseagenten GitHub-Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Weiter: Praktische Übung [Optimierung von KI-Arbeitsabläufen: Erstellung eines MCP-Servers mit AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die sich aus der Nutzung dieser Übersetzung ergeben.