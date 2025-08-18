<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T11:44:25+00:00",
  "source_file": "changelog.md",
  "language_code": "de"
}
-->
# Änderungsprotokoll: MCP für Anfänger Curriculum

Dieses Dokument dient als Aufzeichnung aller wesentlichen Änderungen am Curriculum des Model Context Protocol (MCP) für Anfänger. Änderungen werden in umgekehrt chronologischer Reihenfolge dokumentiert (neueste Änderungen zuerst).

## 18. August 2025

### Umfassendes Update der Dokumentation - MCP Standards 2025-06-18

#### MCP Sicherheitsbest-Practices (02-Security/) - Vollständige Modernisierung
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Vollständige Überarbeitung gemäß MCP Spezifikation 2025-06-18
  - **Verpflichtende Anforderungen**: Hinzugefügte explizite MUSS/MUSS NICHT Anforderungen aus der offiziellen Spezifikation mit klaren visuellen Markierungen
  - **12 Kern-Sicherheitspraktiken**: Umstrukturierung von einer 15-Punkte-Liste zu umfassenden Sicherheitsdomänen
    - Token-Sicherheit & Authentifizierung mit Integration externer Identitätsanbieter
    - Sitzungsmanagement & Transportsicherheit mit kryptografischen Anforderungen
    - KI-spezifischer Bedrohungsschutz mit Microsoft Prompt Shields Integration
    - Zugriffskontrolle & Berechtigungen nach dem Prinzip der minimalen Rechte
    - Inhaltsüberwachung & Sicherheit mit Azure Content Safety Integration
    - Lieferkettensicherheit mit umfassender Komponentenüberprüfung
    - OAuth-Sicherheit & Vermeidung von Confused Deputy Angriffen mit PKCE-Implementierung
    - Vorfallreaktion & Wiederherstellung mit automatisierten Funktionen
    - Compliance & Governance mit regulatorischer Ausrichtung
    - Erweiterte Sicherheitskontrollen mit Zero-Trust-Architektur
    - Integration des Microsoft Sicherheitsökosystems mit umfassenden Lösungen
    - Kontinuierliche Sicherheitsentwicklung mit adaptiven Praktiken
  - **Microsoft Sicherheitslösungen**: Verbesserte Integrationsanleitung für Prompt Shields, Azure Content Safety, Entra ID und GitHub Advanced Security
  - **Implementierungsressourcen**: Kategorisierte umfassende Ressourcenlinks nach offizieller MCP-Dokumentation, Microsoft Sicherheitslösungen, Sicherheitsstandards und Implementierungsleitfäden

#### Erweiterte Sicherheitskontrollen (02-Security/) - Unternehmensimplementierung
- **MCP-SECURITY-CONTROLS-2025.md**: Vollständige Überarbeitung mit unternehmensgerechtem Sicherheitsrahmen
  - **9 umfassende Sicherheitsdomänen**: Erweiterung von grundlegenden Kontrollen zu detailliertem Unternehmensrahmen
    - Erweiterte Authentifizierung & Autorisierung mit Microsoft Entra ID Integration
    - Token-Sicherheit & Anti-Passthrough-Kontrollen mit umfassender Validierung
    - Sitzungs-Sicherheitskontrollen mit Schutz vor Hijacking
    - KI-spezifische Sicherheitskontrollen mit Schutz vor Prompt Injection und Tool Poisoning
    - Vermeidung von Confused Deputy Angriffen mit OAuth Proxy Sicherheit
    - Tool-Ausführungssicherheit mit Sandboxing und Isolation
    - Lieferkettensicherheitskontrollen mit Abhängigkeitsüberprüfung
    - Überwachungs- & Erkennungskontrollen mit SIEM-Integration
    - Vorfallreaktion & Wiederherstellung mit automatisierten Funktionen
  - **Implementierungsbeispiele**: Hinzugefügte detaillierte YAML-Konfigurationsblöcke und Codebeispiele
  - **Microsoft Lösungen Integration**: Umfassende Abdeckung von Azure Sicherheitsdiensten, GitHub Advanced Security und Unternehmensidentitätsmanagement

#### Erweiterte Themen Sicherheit (05-AdvancedTopics/mcp-security/) - Produktionsreife Implementierung
- **README.md**: Vollständige Überarbeitung für Unternehmenssicherheitsimplementierung
  - **Aktuelle Spezifikationsausrichtung**: Aktualisiert auf MCP Spezifikation 2025-06-18 mit verpflichtenden Sicherheitsanforderungen
  - **Erweiterte Authentifizierung**: Microsoft Entra ID Integration mit umfassenden .NET und Java Spring Security Beispielen
  - **KI-Sicherheitsintegration**: Microsoft Prompt Shields und Azure Content Safety Implementierung mit detaillierten Python-Beispielen
  - **Erweiterte Bedrohungsminderung**: Umfassende Implementierungsbeispiele für
    - Vermeidung von Confused Deputy Angriffen mit PKCE und Benutzerzustimmungsvalidierung
    - Schutz vor Token-Passthrough mit Zielgruppenvalidierung und sicherem Token-Management
    - Schutz vor Sitzungs-Hijacking mit kryptografischer Bindung und Verhaltensanalyse
  - **Unternehmenssicherheitsintegration**: Azure Application Insights Überwachung, Bedrohungserkennungspipelines und Lieferkettensicherheit
  - **Implementierungscheckliste**: Klare Unterscheidung zwischen verpflichtenden und empfohlenen Sicherheitskontrollen mit Vorteilen des Microsoft Sicherheitsökosystems

### Dokumentationsqualität & Standardsausrichtung
- **Spezifikationsreferenzen**: Aktualisiert alle Referenzen auf aktuelle MCP Spezifikation 2025-06-18
- **Microsoft Sicherheitsökosystem**: Verbesserte Integrationsanleitung in der gesamten Sicherheitsdokumentation
- **Praktische Implementierung**: Hinzugefügte detaillierte Codebeispiele in .NET, Java und Python mit Unternehmensmustern
- **Ressourcenorganisation**: Umfassende Kategorisierung offizieller Dokumentation, Sicherheitsstandards und Implementierungsleitfäden
- **Visuelle Markierungen**: Klare Kennzeichnung von verpflichtenden Anforderungen gegenüber empfohlenen Praktiken

#### Kernkonzepte (01-CoreConcepts/) - Vollständige Modernisierung
- **Protokollversions-Update**: Aktualisiert auf aktuelle MCP Spezifikation 2025-06-18 mit datumsbasierter Versionierung (YYYY-MM-DD Format)
- **Architekturverfeinerung**: Verbesserte Beschreibungen von Hosts, Clients und Servern zur Darstellung aktueller MCP Architektur-Muster
  - Hosts jetzt klar definiert als KI-Anwendungen, die mehrere MCP-Client-Verbindungen koordinieren
  - Clients beschrieben als Protokoll-Connectoren mit Eins-zu-Eins-Server-Beziehungen
  - Server erweitert mit lokalen vs. entfernten Bereitstellungsszenarien
- **Primitive Umstrukturierung**: Vollständige Überarbeitung der Server- und Client-Primitiven
  - Server-Primitiven: Ressourcen (Datenquellen), Prompts (Vorlagen), Tools (ausführbare Funktionen) mit detaillierten Erklärungen und Beispielen
  - Client-Primitiven: Sampling (LLM-Abschlüsse), Elicitation (Benutzereingaben), Logging (Debugging/Überwachung)
  - Aktualisiert mit aktuellen Discovery (`*/list`), Retrieval (`*/get`) und Execution (`*/call`) Methodenmuster
- **Protokollarchitektur**: Einführung eines Zwei-Schichten-Architekturmodells
  - Datenebene: JSON-RPC 2.0 Grundlage mit Lebenszyklusmanagement und Primitiven
  - Transporteebene: STDIO (lokal) und Streamable HTTP mit SSE (entfernt) Transportmechanismen
- **Sicherheitsrahmen**: Umfassende Sicherheitsprinzipien einschließlich expliziter Benutzerzustimmung, Datenschutz, Tool-Ausführungssicherheit und Transportsicherheit
- **Kommunikationsmuster**: Aktualisierte Protokollnachrichten zur Darstellung von Initialisierung, Discovery, Ausführung und Benachrichtigungsflüssen
- **Codebeispiele**: Aktualisierte mehrsprachige Beispiele (.NET, Java, Python, JavaScript) zur Darstellung aktueller MCP SDK Muster

#### Sicherheit (02-Security/) - Umfassende Sicherheitsüberarbeitung  
- **Standardsausrichtung**: Vollständige Ausrichtung an MCP Spezifikation 2025-06-18 Sicherheitsanforderungen
- **Entwicklung der Authentifizierung**: Dokumentierte Entwicklung von benutzerdefinierten OAuth-Servern zu Delegation externer Identitätsanbieter (Microsoft Entra ID)
- **KI-spezifische Bedrohungsanalyse**: Verbesserte Abdeckung moderner KI-Angriffsvektoren
  - Detaillierte Szenarien für Prompt Injection Angriffe mit realen Beispielen
  - Mechanismen für Tool Poisoning und "Rug Pull" Angriffsmuster
  - Kontextfenstervergiftung und Modellverwirrungsangriffe
- **Microsoft KI-Sicherheitslösungen**: Umfassende Abdeckung des Microsoft Sicherheitsökosystems
  - KI Prompt Shields mit fortschrittlicher Erkennung, Spotlighting und Delimiter-Techniken
  - Azure Content Safety Integrationsmuster
  - GitHub Advanced Security für Lieferkettenschutz
- **Erweiterte Bedrohungsminderung**: Detaillierte Sicherheitskontrollen für
  - Sitzungs-Hijacking mit MCP-spezifischen Angriffsszenarien und kryptografischen Sitzungs-ID-Anforderungen
  - Confused Deputy Probleme in MCP Proxy-Szenarien mit expliziten Zustimmungsanforderungen
  - Token-Passthrough-Schwachstellen mit verpflichtenden Validierungskontrollen
- **Lieferkettensicherheit**: Erweiterte Abdeckung der KI-Lieferkette einschließlich Foundation Models, Embedding-Dienste, Kontextanbieter und Drittanbieter-APIs
- **Grundlagensicherheit**: Verbesserte Integration mit Unternehmenssicherheitsmustern einschließlich Zero-Trust-Architektur und Microsoft Sicherheitsökosystem
- **Ressourcenorganisation**: Kategorisierte umfassende Ressourcenlinks nach Typ (Offizielle Dokumente, Standards, Forschung, Microsoft Lösungen, Implementierungsleitfäden)

### Verbesserungen der Dokumentationsqualität
- **Strukturierte Lernziele**: Verbesserte Lernziele mit spezifischen, umsetzbaren Ergebnissen
- **Querverweise**: Hinzugefügte Links zwischen verwandten Sicherheits- und Kernkonzept-Themen
- **Aktuelle Informationen**: Aktualisiert alle Datumsreferenzen und Spezifikationslinks auf aktuelle Standards
- **Implementierungsanleitung**: Hinzugefügte spezifische, umsetzbare Implementierungsrichtlinien in beiden Abschnitten

## 16. Juli 2025

### README und Navigationsverbesserungen
- Vollständig überarbeitetes Curriculum-Navigation in README.md
- Ersetzt `<details>` Tags durch zugänglichere tabellenbasierte Formate
- Alternative Layoutoptionen im neuen Ordner "alternative_layouts" erstellt
- Hinzugefügte Karten-basierte, Registerkarten-Stil und Akkordeon-Stil Navigationsbeispiele
- Aktualisierte Repository-Struktur-Sektion mit allen neuesten Dateien
- Verbesserte "Wie man dieses Curriculum verwendet"-Sektion mit klaren Empfehlungen
- Aktualisierte MCP-Spezifikationslinks auf korrekte URLs
- Hinzugefügte Abschnitt Kontext-Engineering (5.14) zur Curriculum-Struktur

### Updates des Studienleitfadens
- Vollständig überarbeiteter Studienleitfaden zur Ausrichtung an aktueller Repository-Struktur
- Hinzugefügte neue Abschnitte für MCP Clients und Tools sowie beliebte MCP Server
- Aktualisierte visuelle Curriculum-Karte zur genauen Darstellung aller Themen
- Verbesserte Beschreibungen der erweiterten Themen zur Abdeckung aller spezialisierten Bereiche
- Aktualisierte Fallstudien-Sektion zur Darstellung tatsächlicher Beispiele
- Hinzugefügtes umfassendes Änderungsprotokoll

### Community-Beiträge (06-CommunityContributions/)
- Hinzugefügte detaillierte Informationen über MCP Server für Bildgenerierung
- Hinzugefügte umfassende Sektion zur Nutzung von Claude in VSCode
- Hinzugefügte Cline Terminal-Client Einrichtung und Nutzungsanweisungen
- Aktualisierte MCP Client-Sektion zur Einbeziehung aller beliebten Client-Optionen
- Verbesserte Beitragsbeispiele mit genaueren Codebeispielen

### Erweiterte Themen (05-AdvancedTopics/)
- Organisiert alle spezialisierten Themenordner mit konsistenter Benennung
- Hinzugefügte Materialien und Beispiele für Kontext-Engineering
- Hinzugefügte Dokumentation zur Foundry-Agent-Integration
- Verbesserte Dokumentation zur Entra ID Sicherheitsintegration

## 11. Juni 2025

### Erstmalige Erstellung
- Veröffentlichung der ersten Version des MCP für Anfänger Curriculum
- Grundstruktur für alle 10 Hauptabschnitte erstellt
- Implementierte visuelle Curriculum-Karte zur Navigation
- Hinzugefügte erste Beispielprojekte in mehreren Programmiersprachen

### Erste Schritte (03-GettingStarted/)
- Erstmalige Server-Implementierungsbeispiele erstellt
- Hinzugefügte Anleitung zur Client-Entwicklung
- Einbezogene LLM-Client-Integrationsanweisungen
- Hinzugefügte Dokumentation zur VS Code Integration
- Implementierte Server-Sent Events (SSE) Server-Beispiele

### Kernkonzepte (01-CoreConcepts/)
- Hinzugefügte detaillierte Erklärung der Client-Server-Architektur
- Erstmalige Dokumentation zu Schlüsselprotokollkomponenten erstellt
- Dokumentierte Nachrichtenmuster in MCP

## 23. Mai 2025

### Repository-Struktur
- Initialisierte das Repository mit grundlegender Ordnerstruktur
- Erstmalige README-Dateien für jeden Hauptabschnitt erstellt
- Übersetzungsinfrastruktur eingerichtet
- Hinzugefügte Bildressourcen und Diagramme

### Dokumentation
- Erstmalige Erstellung von README.md mit Curriculum-Übersicht
- Hinzugefügte CODE_OF_CONDUCT.md und SECURITY.md
- SUPPORT.md mit Hilfsanweisungen eingerichtet
- Vorläufige Struktur des Studienleitfadens erstellt

## 15. April 2025

### Planung und Rahmenwerk
- Erste Planung für MCP für Anfänger Curriculum
- Lernziele und Zielgruppe definiert
- 10-Abschnitt-Struktur des Curriculums skizziert
- Konzeptuelles Rahmenwerk für Beispiele und Fallstudien entwickelt
- Erste Prototyp-Beispiele für Schlüsselkonzepte erstellt

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, weisen wir darauf hin, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.