<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T17:36:31+00:00",
  "source_file": "changelog.md",
  "language_code": "de"
}
-->
# Änderungsprotokoll: MCP für Anfänger Curriculum

Dieses Dokument dient als Aufzeichnung aller wesentlichen Änderungen am Curriculum des Model Context Protocol (MCP) für Anfänger. Änderungen werden in umgekehrt chronologischer Reihenfolge dokumentiert (neueste Änderungen zuerst).

## 26. September 2025

### Erweiterung der Fallstudien - Integration des GitHub MCP Registry

#### Fallstudien (09-CaseStudy/) - Fokus auf Ökosystementwicklung
- **README.md**: Umfangreiche Erweiterung mit einer umfassenden Fallstudie zum GitHub MCP Registry
  - **Fallstudie GitHub MCP Registry**: Neue umfassende Fallstudie zur Einführung des GitHub MCP Registry im September 2025
    - **Problemanalyse**: Detaillierte Untersuchung der Herausforderungen bei der fragmentierten Entdeckung und Bereitstellung von MCP-Servern
    - **Lösungsarchitektur**: Zentralisierter Registry-Ansatz von GitHub mit Installation per Mausklick in VS Code
    - **Geschäftliche Auswirkungen**: Messbare Verbesserungen bei der Entwickler-Einarbeitung und Produktivität
    - **Strategischer Wert**: Fokus auf modulare Agentenbereitstellung und Interoperabilität zwischen Tools
    - **Ökosystementwicklung**: Positionierung als grundlegende Plattform für agentenbasierte Integration
  - **Verbesserte Struktur der Fallstudien**: Aktualisierung aller sieben Fallstudien mit einheitlichem Format und umfassenden Beschreibungen
    - Azure AI Travel Agents: Schwerpunkt auf Multi-Agenten-Orchestrierung
    - Azure DevOps Integration: Fokus auf Workflow-Automatisierung
    - Echtzeit-Dokumentenabruf: Implementierung eines Python-Konsolenclients
    - Interaktiver Studienplan-Generator: Chainlit-Webanwendung für Konversationen
    - Dokumentation im Editor: Integration von VS Code und GitHub Copilot
    - Azure API Management: Muster für die Integration von Unternehmens-APIs
    - GitHub MCP Registry: Ökosystementwicklung und Community-Plattform
  - **Umfassender Abschluss**: Neu geschriebener Abschnitt, der die sieben Fallstudien hervorhebt, die verschiedene Dimensionen der MCP-Implementierung abdecken
    - Kategorien: Unternehmensintegration, Multi-Agenten-Orchestrierung, Entwicklerproduktivität
    - Ökosystementwicklung, Bildungsanwendungen
    - Verbesserte Einblicke in Architektur-Muster, Implementierungsstrategien und Best Practices
    - Betonung von MCP als ausgereiftem, produktionsbereitem Protokoll

#### Aktualisierungen des Studienleitfadens (study_guide.md)
- **Visuelle Curriculum-Karte**: Aktualisierte Mindmap, die das GitHub MCP Registry im Abschnitt Fallstudien einschließt
- **Beschreibung der Fallstudien**: Von allgemeinen Beschreibungen zu detaillierten Aufschlüsselungen der sieben umfassenden Fallstudien erweitert
- **Repository-Struktur**: Aktualisierung von Abschnitt 10, um die umfassende Abdeckung der Fallstudien mit spezifischen Implementierungsdetails widerzuspiegeln
- **Integration des Änderungsprotokolls**: Hinzufügung des Eintrags vom 26. September 2025, der die Ergänzung des GitHub MCP Registry und die Verbesserungen der Fallstudien dokumentiert
- **Datumsaktualisierungen**: Aktualisierung des Fußzeilen-Zeitstempels auf die neueste Revision (26. September 2025)

### Verbesserungen der Dokumentationsqualität
- **Konsistenzverbesserung**: Standardisierung des Formats und der Struktur der Fallstudien über alle sieben Beispiele hinweg
- **Umfassende Abdeckung**: Fallstudien decken nun Szenarien in den Bereichen Unternehmen, Entwicklerproduktivität und Ökosystementwicklung ab
- **Strategische Positionierung**: Verstärkter Fokus auf MCP als grundlegende Plattform für die Bereitstellung agentenbasierter Systeme
- **Ressourcenintegration**: Aktualisierung zusätzlicher Ressourcen, um den Link zum GitHub MCP Registry einzuschließen

## 15. September 2025

### Erweiterung der fortgeschrittenen Themen - Benutzerdefinierte Transports & Kontext-Engineering

#### MCP Benutzerdefinierte Transports (05-AdvancedTopics/mcp-transport/) - Neuer Leitfaden für fortgeschrittene Implementierungen
- **README.md**: Vollständiger Implementierungsleitfaden für benutzerdefinierte MCP-Transportmechanismen
  - **Azure Event Grid Transport**: Umfassende serverlose, ereignisgesteuerte Transportimplementierung
    - Beispiele in C#, TypeScript und Python mit Azure Functions-Integration
    - Architektur-Muster für ereignisgesteuerte, skalierbare MCP-Lösungen
    - Webhook-Empfänger und pushbasierte Nachrichtenverarbeitung
  - **Azure Event Hubs Transport**: Implementierung eines hochdurchsatzfähigen Streaming-Transports
    - Echtzeit-Streaming-Funktionen für Szenarien mit niedriger Latenz
    - Partitionierungsstrategien und Checkpoint-Management
    - Nachrichtenbündelung und Leistungsoptimierung
  - **Muster für Unternehmensintegration**: Produktionsreife Architekturbeispiele
    - Verteilte MCP-Verarbeitung über mehrere Azure Functions
    - Hybride Transportarchitekturen, die mehrere Transporttypen kombinieren
    - Strategien für Nachrichtenhaltbarkeit, Zuverlässigkeit und Fehlerbehandlung
  - **Sicherheit & Überwachung**: Integration von Azure Key Vault und Überwachungsmustern
    - Authentifizierung mit verwalteter Identität und Zugriff mit minimalen Berechtigungen
    - Telemetrie mit Application Insights und Leistungsüberwachung
    - Circuit Breaker und Fehlertoleranz-Muster
  - **Testframeworks**: Umfassende Teststrategien für benutzerdefinierte Transports
    - Unit-Tests mit Test-Doubles und Mocking-Frameworks
    - Integrationstests mit Azure Test Containers
    - Leistungs- und Lasttestüberlegungen

#### Kontext-Engineering (05-AdvancedTopics/mcp-contextengineering/) - Aufstrebende Disziplin der KI
- **README.md**: Umfassende Erkundung des Kontext-Engineering als aufstrebendes Feld
  - **Kernprinzipien**: Vollständige Kontextfreigabe, Bewusstsein für Aktionsentscheidungen und Verwaltung des Kontextfensters
  - **Ausrichtung am MCP-Protokoll**: Wie das MCP-Design Herausforderungen des Kontext-Engineering adressiert
    - Begrenzungen des Kontextfensters und Strategien für progressives Laden
    - Relevanzbestimmung und dynamische Kontextabrufstrategien
    - Multi-modale Kontextverarbeitung und Sicherheitsüberlegungen
  - **Implementierungsansätze**: Single-Threaded- vs. Multi-Agenten-Architekturen
    - Kontext-Chunks und Priorisierungstechniken
    - Progressives Kontextladen und Komprimierungsstrategien
    - Geschichtete Kontextansätze und Optimierung des Abrufs
  - **Messrahmen**: Aufkommende Metriken zur Bewertung der Kontexteffektivität
    - Eingabeeffizienz, Leistung, Qualität und Benutzererfahrung
    - Experimentelle Ansätze zur Kontextoptimierung
    - Fehleranalyse und Verbesserungsmethoden

#### Aktualisierungen der Curriculum-Navigation (README.md)
- **Verbesserte Modulstruktur**: Aktualisierung der Curriculum-Tabelle, um neue fortgeschrittene Themen einzuschließen
  - Hinzugefügt: Kontext-Engineering (5.14) und Benutzerdefinierte Transports (5.15)
  - Einheitliches Format und Navigationslinks über alle Module hinweg
  - Aktualisierte Beschreibungen, die den aktuellen Inhalt widerspiegeln

### Verbesserungen der Verzeichnisstruktur
- **Namensstandardisierung**: Umbenennung von "mcp transport" in "mcp-transport" für Konsistenz mit anderen Ordnern für fortgeschrittene Themen
- **Inhaltsorganisation**: Alle Ordner in 05-AdvancedTopics folgen nun einem konsistenten Namensmuster (mcp-[Thema])

### Verbesserungen der Dokumentationsqualität
- **Ausrichtung an MCP-Spezifikation**: Alle neuen Inhalte beziehen sich auf die aktuelle MCP-Spezifikation 2025-06-18
- **Mehrsprachige Beispiele**: Umfassende Codebeispiele in C#, TypeScript und Python
- **Unternehmensfokus**: Produktionsreife Muster und Azure-Cloud-Integration durchgehend
- **Visuelle Dokumentation**: Mermaid-Diagramme für Architektur- und Flussvisualisierung

## 18. August 2025

### Umfassende Aktualisierung der Dokumentation - MCP-Standards 2025-06-18

#### MCP Sicherheitsbest Practices (02-Security/) - Vollständige Modernisierung
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Vollständige Überarbeitung gemäß MCP-Spezifikation 2025-06-18
  - **Verpflichtende Anforderungen**: Hinzugefügt: Explizite MUSS/MUSS NICHT-Anforderungen aus der offiziellen Spezifikation mit klaren visuellen Indikatoren
  - **12 Kern-Sicherheitspraktiken**: Umstrukturierung von einer 15-Punkte-Liste zu umfassenden Sicherheitsdomänen
    - Token-Sicherheit & Authentifizierung mit Integration externer Identitätsanbieter
    - Sitzungsmanagement & Transportsicherheit mit kryptografischen Anforderungen
    - KI-spezifischer Bedrohungsschutz mit Microsoft Prompt Shields-Integration
    - Zugriffskontrolle & Berechtigungen mit dem Prinzip der minimalen Berechtigungen
    - Inhaltsicherheit & Überwachung mit Azure Content Safety-Integration
    - Lieferkettensicherheit mit umfassender Komponentenüberprüfung
    - OAuth-Sicherheit & Vermeidung von Confused Deputy-Angriffen mit PKCE-Implementierung
    - Vorfallreaktion & Wiederherstellung mit automatisierten Fähigkeiten
    - Compliance & Governance mit regulatorischer Ausrichtung
    - Erweiterte Sicherheitskontrollen mit Zero-Trust-Architektur
    - Integration des Microsoft-Sicherheitsökosystems mit umfassenden Lösungen
    - Kontinuierliche Sicherheitsentwicklung mit adaptiven Praktiken
  - **Microsoft Sicherheitslösungen**: Verbesserte Integrationsanleitung für Prompt Shields, Azure Content Safety, Entra ID und GitHub Advanced Security
  - **Implementierungsressourcen**: Kategorisierte umfassende Ressourcenlinks nach Offizieller MCP-Dokumentation, Microsoft Sicherheitslösungen, Sicherheitsstandards und Implementierungsleitfäden

#### Erweiterte Sicherheitskontrollen (02-Security/) - Unternehmensimplementierung
- **MCP-SECURITY-CONTROLS-2025.md**: Vollständige Überarbeitung mit einem unternehmensgerechten Sicherheitsrahmen
  - **9 umfassende Sicherheitsdomänen**: Erweiterung von grundlegenden Kontrollen zu einem detaillierten Unternehmensrahmen
    - Erweiterte Authentifizierung & Autorisierung mit Microsoft Entra ID-Integration
    - Token-Sicherheit & Anti-Passthrough-Kontrollen mit umfassender Validierung
    - Sicherheitskontrollen für Sitzungen mit Hijacking-Prävention
    - KI-spezifische Sicherheitskontrollen mit Schutz vor Prompt-Injection und Tool-Vergiftung
    - Vermeidung von Confused Deputy-Angriffen mit OAuth-Proxy-Sicherheit
    - Sicherheit bei Tool-Ausführung mit Sandboxing und Isolation
    - Sicherheitskontrollen für Lieferketten mit Abhängigkeitsüberprüfung
    - Überwachungs- & Erkennungskontrollen mit SIEM-Integration
    - Vorfallreaktion & Wiederherstellung mit automatisierten Fähigkeiten
  - **Implementierungsbeispiele**: Hinzugefügt: Detaillierte YAML-Konfigurationsblöcke und Codebeispiele
  - **Integration von Microsoft-Lösungen**: Umfassende Abdeckung von Azure-Sicherheitsdiensten, GitHub Advanced Security und Unternehmensidentitätsmanagement

#### Erweiterte Themen Sicherheit (05-AdvancedTopics/mcp-security/) - Produktionsreife Implementierung
- **README.md**: Vollständige Überarbeitung für die Unternehmenssicherheitsimplementierung
  - **Aktuelle Spezifikationsausrichtung**: Aktualisiert auf MCP-Spezifikation 2025-06-18 mit verpflichtenden Sicherheitsanforderungen
  - **Erweiterte Authentifizierung**: Microsoft Entra ID-Integration mit umfassenden .NET- und Java Spring Security-Beispielen
  - **KI-Sicherheitsintegration**: Implementierung von Microsoft Prompt Shields und Azure Content Safety mit detaillierten Python-Beispielen
  - **Erweiterte Bedrohungsminderung**: Umfassende Implementierungsbeispiele für
    - Vermeidung von Confused Deputy-Angriffen mit PKCE und Validierung der Benutzerzustimmung
    - Vermeidung von Token-Passthrough mit Validierung der Zielgruppe und sicherem Token-Management
    - Vermeidung von Sitzungs-Hijacking mit kryptografischer Bindung und Verhaltensanalyse
  - **Integration der Unternehmenssicherheit**: Überwachung mit Azure Application Insights, Bedrohungserkennungspipelines und Lieferkettensicherheit
  - **Implementierungscheckliste**: Klare Unterscheidung zwischen verpflichtenden und empfohlenen Sicherheitskontrollen mit Vorteilen des Microsoft-Sicherheitsökosystems

### Verbesserungen der Dokumentationsqualität & Standardsausrichtung
- **Spezifikationsreferenzen**: Aktualisierung aller Referenzen auf die aktuelle MCP-Spezifikation 2025-06-18
- **Microsoft Sicherheitsökosystem**: Verbesserte Integrationsanleitung in der gesamten Sicherheitsdokumentation
- **Praktische Implementierung**: Hinzugefügt: Detaillierte Codebeispiele in .NET, Java und Python mit Unternehmensmustern
- **Ressourcenorganisation**: Umfassende Kategorisierung offizieller Dokumentation, Sicherheitsstandards und Implementierungsleitfäden
- **Visuelle Indikatoren**: Klare Kennzeichnung von verpflichtenden Anforderungen vs. empfohlenen Praktiken

#### Kernkonzepte (01-CoreConcepts/) - Vollständige Modernisierung
- **Protokollversions-Update**: Aktualisiert auf die aktuelle MCP-Spezifikation 2025-06-18 mit datumsbasierter Versionierung (YYYY-MM-DD-Format)
- **Architekturverfeinerung**: Verbesserte Beschreibungen von Hosts, Clients und Servern, um aktuelle MCP-Architekturmuster widerzuspiegeln
  - Hosts jetzt klar definiert als KI-Anwendungen, die mehrere MCP-Client-Verbindungen koordinieren
  - Clients beschrieben als Protokoll-Connectoren mit Eins-zu-Eins-Serverbeziehungen
  - Server erweitert mit Szenarien für lokale vs. Remote-Bereitstellung
- **Primitive Umstrukturierung**: Vollständige Überarbeitung der Server- und Client-Primitiven
  - Server-Primitiven: Ressourcen (Datenquellen), Prompts (Vorlagen), Tools (ausführbare Funktionen) mit detaillierten Erklärungen und Beispielen
  - Client-Primitiven: Sampling (LLM-Vervollständigungen), Elicitation (Benutzereingaben), Logging (Debugging/Überwachung)
  - Aktualisiert mit aktuellen Methodenmustern für Entdeckung (`*/list`), Abruf (`*/get`) und Ausführung (`*/call`)
- **Protokollarchitektur**: Einführung eines Zwei-Schichten-Architekturmodells
  - Datenschicht: JSON-RPC 2.0-Grundlage mit Lebenszyklusmanagement und Primitiven
  - Transportschicht: STDIO (lokal) und Streamable HTTP mit SSE (remote) Transportmechanismen
- **Sicherheitsrahmen**: Umfassende Sicherheitsprinzipien einschließlich expliziter Benutzerzustimmung, Datenschutz, Sicherheit bei Tool-Ausführung und Transportsicherheit
- **Kommunikationsmuster**: Aktualisierte Protokollnachrichten, die Initialisierung, Entdeckung, Ausführung und Benachrichtigungsflüsse zeigen
- **Codebeispiele**: Aktualisierte mehrsprachige Beispiele (.NET, Java, Python, JavaScript), die aktuelle MCP-SDK-Muster widerspiegeln

#### Sicherheit (02-Security/) - Umfassende Sicherheitsüberarbeitung  
- **Standardsausrichtung**: Vollständige Ausrichtung an den Sicherheitsanforderungen der MCP-Spezifikation 2025-06-18
- **Entwicklung der Authentifizierung**: Dokumentierte Entwicklung von benutzerdefinierten OAuth-Servern zu Delegation durch externe Identitätsanbieter (Microsoft Entra ID)
- **KI-spezifische Bedrohungsanalyse**: Erweiterte Abdeckung moderner KI-Angriffsvektoren
  - Detaillierte Szenarien für Prompt-Injection-Angriffe mit realen Beispielen
  - Mechanismen der Tool-Vergiftung und "Rug Pull"-Angriffsmuster
  - Kontextfenster-Vergiftung und Modellverwirrungsangriffe
- **Microsoft KI-Sicherheitslösungen**: Umfassende Abdeckung des Microsoft-Sicherheitsökosystems
  - AI Prompt Shields mit fortschrittlicher Erkennung, Spotlighting und Delimiter-Techniken
  - Azure Content Safety-Integrationsmuster
  - GitHub Advanced Security für Schutz der Lieferkette
- **Erweiterte Bedrohungsminderung**: Detaillierte Sicherheitskontrollen für
  - Sitzungs-Hijacking mit MCP-spezifischen Angriffsszenarien und kryptografischen Sitzungs-ID-Anforderungen
  - Confused Deputy-Probleme in MCP-Proxy-Szenarien mit expliziten Zustimmungsanforderungen
  - Token-Passthrough-Schwachstellen mit verpflichtenden Validierungskontrollen
- **Lieferkettensicherheit**: Erweiterte Abdeckung der KI-Lieferkette einschließlich Foundation-Modelle, Embedding-Dienste, Kontextanbieter und Drittanbieter-APIs
- **Grundlegende Sicherheit**: Verbesserte Integration mit Unternehmenssicherheitsmustern einschließlich Zero-Trust-Architektur und Microsoft-Sicherheitsökosystem
- **Ressourcenorganisation**: Kategorisierte umfassende Ressourcenlinks nach Typ (Offizielle Dokumente, Standards, Forschung, Microsoft-Lösungen, Implementierungsleitfäden)

### Verbesserungen der Dokumentationsqualität
- **Strukturierte Lernziele**: Verbesserte Lernziele mit spezifischen, umsetzbaren Ergebnissen 
- **Querverweise**: Hinzugefügt: Links zwischen verwandten Sicherheits- und Kernkonzept-Themen
- **Aktuelle Informationen**: Aktualisierung aller Datumsreferenzen und Spezifikationslinks auf aktuelle Standards
- **Implementierungsanleitung**: Hinzugefügt: Spezifische, umsetzbare Implementierungsrichtlinien in beiden Abschnitten

## 16. Juli 2025

### Verbesserungen von README und Navigation
- Vollständige Neugestaltung der Curriculum-Navigation in README.md
- Ersetzte `<details>`-Tags durch ein zugänglicheres tabellenbasiertes Format
- Erstellte alternative Layout-Optionen im neuen Ordner "alternative_layouts"
- Hinzugefügt: Beispiele für kartenbasierte, registerkartenbasierte und accordion-basierte Navigation
- Aktualisierte den Abschnitt zur Repository-Struktur, um alle neuesten Dateien einzubeziehen
- Verbesserte den Abschnitt "Wie man dieses Curriculum verwendet" mit klaren Empfehlungen
- Aktualisierte MCP-Spezifikationslinks, um auf die richtigen URLs zu verweisen
- Hinzugefügt: Abschnitt Kontext-Engineering (5.14) zur Curriculum-Struktur

### Aktualisierungen des Studienleitfadens
- Studienleitfaden vollständig überarbeitet, um mit der aktuellen Repository-Struktur übereinzustimmen
- Neue Abschnitte hinzugefügt: MCP-Clients und -Tools sowie beliebte MCP-Server
- Aktualisierte die visuelle Curriculum-Karte, um alle Themen korrekt darzustellen
- Verbesserte Beschreibungen der fortgeschrittenen Themen, um alle spezialisierten Bereiche abzudecken
- Aktualisierte den Abschnitt Fallstudien, um reale Beispiele widerzuspiegeln
- Hinzugefügt: Dieser umfassende Änderungsprotokoll

### Beiträge der Community (06-CommunityContributions/)
- Detaillierte Informationen zu MCP-Servern für die Bildgenerierung hinzugefügt
- Umfassender Abschnitt zur Nutzung von Claude in VSCode hinzugefügt
- Setup- und Nutzungsanweisungen für den Cline-Terminal-Client hinzugefügt
- Aktualisierte den MCP-Client-Abschnitt, um alle beliebten Client-Optionen einzubeziehen
- Verbesserte Beitragsbeispiele mit genaueren Codebeispielen

### Fortgeschrittene Themen (05-AdvancedTopics/)
- Alle spezialisierten Themenordner mit konsistenter Benennung organisiert
- Materialien und Beispiele zum Kontext-Engineering hinzugefügt
- Dokumentation zur Integration des Foundry-Agenten hinzugefügt
- Verbesserte Dokumentation zur Sicherheitsintegration von Entra ID

## 11. Juni 2025

### Erstveröffentlichung
- Erste Version des MCP für Anfänger-Curriculums veröffentlicht
- Grundstruktur für alle 10 Hauptabschnitte erstellt
- Visuelle Curriculum-Karte für die Navigation implementiert
- Erste Beispielprojekte in mehreren Programmiersprachen hinzugefügt

### Erste Schritte (03-GettingStarted/)
- Erste Server-Implementierungsbeispiele erstellt
- Anleitung zur Client-Entwicklung hinzugefügt
- Anweisungen zur Integration von LLM-Clients hinzugefügt
- Dokumentation zur Integration von VS Code hinzugefügt
- Beispiele für Server-Sent Events (SSE) Server implementiert

### Kernkonzepte (01-CoreConcepts/)
- Detaillierte Erklärung der Client-Server-Architektur hinzugefügt
- Dokumentation zu den wichtigsten Protokollkomponenten erstellt
- Messaging-Muster in MCP dokumentiert

## 23. Mai 2025

### Repository-Struktur
- Repository mit grundlegender Ordnerstruktur initialisiert
- README-Dateien für jeden Hauptabschnitt erstellt
- Übersetzungsinfrastruktur eingerichtet
- Bildressourcen und Diagramme hinzugefügt

### Dokumentation
- Erste README.md mit Curriculum-Übersicht erstellt
- CODE_OF_CONDUCT.md und SECURITY.md hinzugefügt
- SUPPORT.md mit Hilfsanweisungen eingerichtet
- Vorläufige Struktur des Studienleitfadens erstellt

## 15. April 2025

### Planung und Rahmenwerk
- Erste Planung für das MCP für Anfänger-Curriculum
- Lernziele und Zielgruppe definiert
- 10-Abschnitt-Struktur des Curriculums skizziert
- Konzeptuelles Rahmenwerk für Beispiele und Fallstudien entwickelt
- Erste Prototyp-Beispiele für Schlüsselkonzepte erstellt

---

