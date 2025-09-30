<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T13:25:40+00:00",
  "source_file": "changelog.md",
  "language_code": "de"
}
-->
# Änderungsprotokoll: MCP für Anfänger Curriculum

Dieses Dokument dient als Aufzeichnung aller wesentlichen Änderungen am Curriculum des Model Context Protocol (MCP) für Anfänger. Änderungen werden in umgekehrt chronologischer Reihenfolge dokumentiert (neueste Änderungen zuerst).

## 29. September 2025

### MCP Server-Datenbank-Integrations-Labs - Umfassender praktischer Lernpfad

#### 11-MCPServerHandsOnLabs - Neues vollständiges Curriculum zur Datenbankintegration
- **Vollständiger 13-Lab-Lernpfad**: Hinzugefügt wurde ein umfassendes praktisches Curriculum zum Aufbau produktionsreifer MCP-Server mit PostgreSQL-Datenbankintegration
  - **Praxisnahe Implementierung**: Zava Retail Analytics Anwendungsfall, der Unternehmensmuster demonstriert
  - **Strukturierter Lernfortschritt**:
    - **Labs 00-03: Grundlagen** - Einführung, Kernarchitektur, Sicherheit & Multi-Tenancy, Einrichtungsumgebung
    - **Labs 04-06: Aufbau des MCP-Servers** - Datenbankdesign & Schema, MCP-Server-Implementierung, Tool-Entwicklung  
    - **Labs 07-09: Erweiterte Funktionen** - Semantische Suchintegration, Testen & Debugging, VS Code-Integration
    - **Labs 10-12: Produktion & Best Practices** - Bereitstellungsstrategien, Überwachung & Beobachtbarkeit, Best Practices & Optimierung
  - **Unternehmens-Technologien**: FastMCP-Framework, PostgreSQL mit pgvector, Azure OpenAI-Embeddings, Azure Container Apps, Application Insights
  - **Erweiterte Funktionen**: Row Level Security (RLS), semantische Suche, Multi-Tenant-Datenzugriff, Vektor-Embeddings, Echtzeitüberwachung

#### Terminologie-Standardisierung - Umstellung von Modul auf Lab
- **Umfassende Dokumentationsaktualisierung**: Systematische Aktualisierung aller README-Dateien in 11-MCPServerHandsOnLabs zur Verwendung der Terminologie "Lab" anstelle von "Modul"
  - **Abschnittsüberschriften**: "Was dieses Modul behandelt" wurde zu "Was dieses Lab behandelt" in allen 13 Labs geändert
  - **Inhaltsbeschreibung**: "Dieses Modul bietet..." wurde zu "Dieses Lab bietet..." geändert
  - **Lernziele**: "Am Ende dieses Moduls..." wurde zu "Am Ende dieses Labs..." aktualisiert
  - **Navigationslinks**: Alle Verweise "Modul XX:" wurden zu "Lab XX:" in Querverweisen und Navigation umgewandelt
  - **Abschlussverfolgung**: "Nach Abschluss dieses Moduls..." wurde zu "Nach Abschluss dieses Labs..." geändert
  - **Technische Referenzen beibehalten**: Python-Modulreferenzen in Konfigurationsdateien wurden unverändert gelassen (z. B. `"module": "mcp_server.main"`)

#### Verbesserungen des Studienleitfadens (study_guide.md)
- **Visuelle Curriculum-Karte**: Neuer Abschnitt "11. Datenbank-Integrations-Labs" mit umfassender Lab-Strukturvisualisierung hinzugefügt
- **Repository-Struktur**: Aktualisiert von zehn auf elf Hauptabschnitte mit detaillierter Beschreibung von 11-MCPServerHandsOnLabs
- **Lernpfad-Anleitung**: Verbesserte Navigationsanweisungen für die Abschnitte 00-11
- **Technologieabdeckung**: Details zur Integration von FastMCP, PostgreSQL und Azure-Diensten hinzugefügt
- **Lernergebnisse**: Betonung der Entwicklung produktionsreifer Server, Datenbankintegrationsmuster und Unternehmenssicherheit

#### Haupt-README-Strukturverbesserung
- **Lab-basierte Terminologie**: Haupt-README.md in 11-MCPServerHandsOnLabs wurde konsistent auf die "Lab"-Struktur aktualisiert
- **Lernpfad-Organisation**: Klare Progression von grundlegenden Konzepten über erweiterte Implementierung bis hin zur Produktionsbereitstellung
- **Praxisorientierung**: Betonung des praktischen, praxisnahen Lernens mit Unternehmensmustern und Technologien

### Verbesserungen der Dokumentationsqualität und Konsistenz
- **Praxisorientiertes Lernen**: Verstärkung des praktischen, Lab-basierten Ansatzes in der gesamten Dokumentation
- **Fokus auf Unternehmensmuster**: Hervorhebung produktionsreifer Implementierungen und Sicherheitsüberlegungen
- **Technologieintegration**: Umfassende Abdeckung moderner Azure-Dienste und KI-Integrationsmuster
- **Lernfortschritt**: Klarer, strukturierter Weg von grundlegenden Konzepten bis zur Produktionsbereitstellung

## 26. September 2025

### Erweiterung der Fallstudien - GitHub MCP Registry Integration

#### Fallstudien (09-CaseStudy/) - Fokus auf Ökosystementwicklung
- **README.md**: Große Erweiterung mit umfassender Fallstudie zur GitHub MCP Registry
  - **GitHub MCP Registry Fallstudie**: Neue umfassende Fallstudie zur Einführung des GitHub MCP Registry im September 2025
    - **Problemanalyse**: Detaillierte Untersuchung der Herausforderungen bei der fragmentierten Entdeckung und Bereitstellung von MCP-Servern
    - **Lösungsarchitektur**: Zentralisierter Registry-Ansatz von GitHub mit Installation per Mausklick in VS Code
    - **Geschäftliche Auswirkungen**: Messbare Verbesserungen bei der Entwickler-Einarbeitung und Produktivität
    - **Strategischer Wert**: Fokus auf modulare Agentenbereitstellung und Interoperabilität zwischen Tools
    - **Ökosystementwicklung**: Positionierung als grundlegende Plattform für agentische Integration
  - **Erweiterte Struktur der Fallstudien**: Alle sieben Fallstudien wurden mit konsistenter Formatierung und umfassenden Beschreibungen aktualisiert
    - Azure AI Travel Agents: Schwerpunkt auf Multi-Agenten-Orchestrierung
    - Azure DevOps Integration: Fokus auf Workflow-Automatisierung
    - Echtzeit-Dokumentationsabruf: Python-Konsolenclient-Implementierung
    - Interaktiver Studienplan-Generator: Chainlit-konversationale Web-App
    - In-Editor-Dokumentation: VS Code und GitHub Copilot Integration
    - Azure API Management: Unternehmens-API-Integrationsmuster
    - GitHub MCP Registry: Ökosystementwicklung und Community-Plattform
  - **Umfassender Abschluss**: Neu geschriebener Abschnitt, der sieben Fallstudien hervorhebt, die mehrere MCP-Implementierungsdimensionen abdecken
    - Unternehmensintegration, Multi-Agenten-Orchestrierung, Entwicklerproduktivität
    - Ökosystementwicklung, Bildungsanwendungen Kategorisierung
    - Verbesserte Einblicke in Architektur-Muster, Implementierungsstrategien und Best Practices
    - Betonung von MCP als ausgereiftem, produktionsbereitem Protokoll

#### Updates des Studienleitfadens (study_guide.md)
- **Visuelle Curriculum-Karte**: Mindmap aktualisiert, um GitHub MCP Registry im Abschnitt Fallstudien einzuschließen
- **Beschreibung der Fallstudien**: Von generischen Beschreibungen zu detaillierten Aufschlüsselungen von sieben umfassenden Fallstudien erweitert
- **Repository-Struktur**: Abschnitt 10 aktualisiert, um umfassende Fallstudienabdeckung mit spezifischen Implementierungsdetails widerzuspiegeln
- **Integration des Änderungsprotokolls**: Eintrag vom 26. September 2025 hinzugefügt, der die Ergänzung der GitHub MCP Registry und die Erweiterung der Fallstudien dokumentiert
- **Datumsaktualisierungen**: Fußzeilen-Zeitstempel aktualisiert, um die neueste Revision (26. September 2025) widerzuspiegeln

### Verbesserungen der Dokumentationsqualität
- **Konsistenzverbesserung**: Standardisierte Formatierung und Struktur der Fallstudien über alle sieben Beispiele hinweg
- **Umfassende Abdeckung**: Fallstudien decken nun Szenarien zu Unternehmen, Entwicklerproduktivität und Ökosystementwicklung ab
- **Strategische Positionierung**: Verbesserter Fokus auf MCP als grundlegende Plattform für die Bereitstellung agentischer Systeme
- **Ressourcenintegration**: Zusätzliche Ressourcen aktualisiert, um den Link zur GitHub MCP Registry einzuschließen

## 15. September 2025

### Erweiterung der fortgeschrittenen Themen - Benutzerdefinierte Transportsysteme & Kontext-Engineering

#### MCP Benutzerdefinierte Transportsysteme (05-AdvancedTopics/mcp-transport/) - Neuer Leitfaden für fortgeschrittene Implementierung
- **README.md**: Vollständiger Implementierungsleitfaden für benutzerdefinierte MCP-Transportmechanismen
  - **Azure Event Grid Transport**: Umfassende serverlose ereignisgesteuerte Transportimplementierung
    - Beispiele in C#, TypeScript und Python mit Azure Functions-Integration
    - Architektur-Muster für skalierbare MCP-Lösungen
    - Webhook-Empfänger und pushbasierte Nachrichtenverarbeitung
  - **Azure Event Hubs Transport**: Implementierung eines hochdurchsatzfähigen Streaming-Transports
    - Echtzeit-Streaming-Funktionen für Szenarien mit niedriger Latenz
    - Partitionierungsstrategien und Checkpoint-Management
    - Nachrichtenbündelung und Leistungsoptimierung
  - **Unternehmens-Integrationsmuster**: Produktionsreife Architekturbeispiele
    - Verteilte MCP-Verarbeitung über mehrere Azure Functions
    - Hybride Transportarchitekturen, die mehrere Transporttypen kombinieren
    - Nachrichtenhaltbarkeit, Zuverlässigkeit und Fehlerbehandlungsstrategien
  - **Sicherheit & Überwachung**: Azure Key Vault-Integration und Beobachtungsmuster
    - Authentifizierung mit verwalteter Identität und Zugriff nach dem Prinzip der geringsten Rechte
    - Application Insights-Telemetrie und Leistungsüberwachung
    - Circuit Breaker und Fehlertoleranzmuster
  - **Testframeworks**: Umfassende Teststrategien für benutzerdefinierte Transportsysteme
    - Unit-Tests mit Test-Doubles und Mocking-Frameworks
    - Integrationstests mit Azure Test Containers
    - Leistungs- und Lasttestüberlegungen

#### Kontext-Engineering (05-AdvancedTopics/mcp-contextengineering/) - Aufstrebende KI-Disziplin
- **README.md**: Umfassende Erkundung des Kontext-Engineering als aufstrebendes Feld
  - **Kernprinzipien**: Vollständige Kontextfreigabe, Bewusstsein für Aktionsentscheidungen und Kontextfensterverwaltung
  - **MCP-Protokoll-Ausrichtung**: Wie MCP-Design Herausforderungen des Kontext-Engineering adressiert
    - Begrenzungen des Kontextfensters und progressive Lade-Strategien
    - Relevanzbestimmung und dynamische Kontextabfrage
    - Multimodale Kontextverarbeitung und Sicherheitsüberlegungen
  - **Implementierungsansätze**: Single-Threaded vs. Multi-Agenten-Architekturen
    - Kontext-Chunking und Priorisierungstechniken
    - Progressives Kontextladen und Komprimierungsstrategien
    - Geschichtete Kontextansätze und Abrufoptimierung
  - **Messrahmen**: Aufkommende Metriken zur Bewertung der Kontexteffektivität
    - Eingabeeffizienz, Leistung, Qualität und Benutzererfahrungsüberlegungen
    - Experimentelle Ansätze zur Kontextoptimierung
    - Fehleranalyse und Verbesserungsmethoden

#### Updates zur Curriculum-Navigation (README.md)
- **Verbesserte Modulstruktur**: Curriculum-Tabelle aktualisiert, um neue fortgeschrittene Themen einzuschließen
  - Kontext-Engineering (5.14) und Benutzerdefinierte Transportsysteme (5.15) hinzugefügt
  - Konsistente Formatierung und Navigationslinks über alle Module hinweg
  - Beschreibungen aktualisiert, um den aktuellen Inhalt abzudecken

### Verbesserungen der Verzeichnisstruktur
- **Namensstandardisierung**: "mcp transport" in "mcp-transport" umbenannt für Konsistenz mit anderen Ordnern zu fortgeschrittenen Themen
- **Inhaltsorganisation**: Alle 05-AdvancedTopics-Ordner folgen nun einem konsistenten Namensmuster (mcp-[Thema])

### Verbesserungen der Dokumentationsqualität
- **MCP-Spezifikationsausrichtung**: Alle neuen Inhalte beziehen sich auf die aktuelle MCP-Spezifikation 2025-06-18
- **Mehrsprachige Beispiele**: Umfassende Codebeispiele in C#, TypeScript und Python
- **Unternehmensfokus**: Produktionsreife Muster und Azure-Cloud-Integration durchgehend
- **Visuelle Dokumentation**: Mermaid-Diagramme zur Architektur- und Ablaufvisualisierung

## 18. August 2025

### Umfassendes Dokumentationsupdate - MCP 2025-06-18 Standards

#### MCP Sicherheits-Best Practices (02-Security/) - Vollständige Modernisierung
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Vollständige Überarbeitung gemäß MCP-Spezifikation 2025-06-18
  - **Verpflichtende Anforderungen**: Hinzugefügt wurden explizite MUST/MUST NOT-Anforderungen aus der offiziellen Spezifikation mit klaren visuellen Indikatoren
  - **12 Kern-Sicherheitspraktiken**: Umstrukturiert von einer 15-Punkte-Liste zu umfassenden Sicherheitsdomänen
    - Token-Sicherheit & Authentifizierung mit Integration externer Identitätsanbieter
    - Sitzungsmanagement & Transportsicherheit mit kryptografischen Anforderungen
    - KI-spezifischer Bedrohungsschutz mit Microsoft Prompt Shields-Integration
    - Zugriffskontrolle & Berechtigungen nach dem Prinzip der geringsten Rechte
    - Inhaltsicherheit & Überwachung mit Azure Content Safety-Integration
    - Lieferkettensicherheit mit umfassender Komponentenüberprüfung
    - OAuth-Sicherheit & Verwirrte-Stellvertreter-Prävention mit PKCE-Implementierung
    - Vorfallreaktion & Wiederherstellung mit automatisierten Fähigkeiten
    - Compliance & Governance mit regulatorischer Ausrichtung
    - Erweiterte Sicherheitskontrollen mit Zero-Trust-Architektur
    - Integration des Microsoft-Sicherheitsökosystems mit umfassenden Lösungen
    - Kontinuierliche Sicherheitsentwicklung mit adaptiven Praktiken
  - **Microsoft-Sicherheitslösungen**: Verbesserte Integrationsanleitung für Prompt Shields, Azure Content Safety, Entra ID und GitHub Advanced Security
  - **Implementierungsressourcen**: Umfassende Ressourcenkategorisierung nach Offizieller MCP-Dokumentation, Microsoft-Sicherheitslösungen, Sicherheitsstandards und Implementierungsleitfäden

#### Erweiterte Sicherheitskontrollen (02-Security/) - Unternehmensimplementierung
- **MCP-SECURITY-CONTROLS-2025.md**: Vollständige Überarbeitung mit unternehmensgerechtem Sicherheitsrahmen
  - **9 umfassende Sicherheitsdomänen**: Von grundlegenden Kontrollen zu detailliertem Unternehmensrahmen erweitert
    - Erweiterte Authentifizierung & Autorisierung mit Microsoft Entra ID-Integration
    - Token-Sicherheit & Anti-Passthrough-Kontrollen mit umfassender Validierung
    - Sitzungs-Sicherheitskontrollen mit Hijacking-Prävention
    - KI-spezifische Sicherheitskontrollen mit Schutz vor Prompt-Injection und Tool-Vergiftung
    - Verwirrte-Stellvertreter-Angriff-Prävention mit OAuth-Proxy-Sicherheit
    - Tool-Ausführungssicherheit mit Sandboxing und Isolation
    - Lieferkettensicherheitskontrollen mit Abhängigkeitsüberprüfung
    - Überwachungs- & Erkennungs-Kontrollen mit SIEM-Integration
    - Vorfallreaktion & Wiederherstellung mit automatisierten Fähigkeiten
  - **Implementierungsbeispiele**: Detaillierte YAML-Konfigurationsblöcke und Codebeispiele hinzugefügt
  - **Microsoft-Lösungsintegration**: Umfassende Abdeckung von Azure-Sicherheitsdiensten, GitHub Advanced Security und Unternehmensidentitätsmanagement

#### Erweiterte Themen Sicherheit (05-AdvancedTopics/mcp-security/) - Produktionsreife Implementierung
- **README.md**: Vollständige Überarbeitung für Unternehmenssicherheitsimplementierung
  - **Aktuelle Spezifikationsausrichtung**: Aktualisiert auf MCP-Spezifikation 2025-06-18 mit verpflichtenden Sicherheitsanforderungen
  - **Erweiterte Authentifizierung**: Microsoft Entra ID-Integration mit umfassenden .NET- und Java Spring Security-Beispielen
  - **KI-Sicherheitsintegration**: Microsoft Prompt Shields und Azure Content Safety-Implementierung mit detaillierten Python-Beispielen
  - **Erweiterte Bedrohungsminderung**: Umfassende Implementierungsbeispiele für
    - Verwirrte-Stellvertreter-Angriff-Prävention mit PKCE und Benutzerzustimmungsvalidierung
    - Token-Passthrough-Prävention mit Zielgruppenvalidierung und sicherem Token-Management
    - Sitzungs-Hijacking-Prävention mit kryptografischer Bindung und Verhaltensanalyse
  - **Unternehmenssicherheitsintegration**: Azure Application Insights-Überwachung, Bedrohungserkennungspipelines und Lieferkettensicherheit
  - **Implementierungs-Checkliste**: Klare verpflichtende vs. empfohlene Sicherheitskontrollen mit Vorteilen des Microsoft-Sicherheitsökosystems

### Verbesserungen der Dokumentationsqualität & Standardausrichtung
- **Spezifikationsreferenzen**: Alle Referenzen auf aktuelle MCP-Spezifikation 2025-06-18 aktualisiert
- **Microsoft-Sicherheitsökosystem**: Verbesserte Integrationsanleitung in der gesamten Sicherheitsdokumentation
- **Praktische Implementierung**: Detaillierte Codebeispiele in .NET, Java und Python mit Unternehmensmustern hinzugefügt
- **Ressourcenorganisation**: Umfassende Kategorisierung offizieller Dokumentation, Sicherheitsstandards und Implementierungsleitfäden
- **Visuelle Indikatoren**: Klare Kennzeichnung von verpflichtenden Anforderungen gegenüber empfohlenen Praktiken

#### Kernkonzepte (01-CoreConcepts/) - Vollständige Modernisierung
- **Protokollversions-Update**: Aktualisiert auf die aktuelle MCP-Spezifikation 2025-06-18 mit datumsbasierter Versionierung (Format YYYY-MM-DD)
- **Architekturverfeinerung**: Verbesserte Beschreibungen von Hosts, Clients und Servern, die aktuelle MCP-Architektur-Muster widerspiegeln
  - Hosts sind jetzt klar als KI-Anwendungen definiert, die mehrere MCP-Client-Verbindungen koordinieren
  - Clients werden als Protokoll-Connectoren beschrieben, die Eins-zu-Eins-Beziehungen zu Servern aufrechterhalten
  - Server wurden mit Szenarien für lokale und entfernte Bereitstellungen erweitert
- **Primitive Umstrukturierung**: Vollständige Überarbeitung der Server- und Client-Primitiven
  - Server-Primitiven: Ressourcen (Datenquellen), Prompts (Vorlagen), Tools (ausführbare Funktionen) mit detaillierten Erklärungen und Beispielen
  - Client-Primitiven: Sampling (LLM-Vervollständigungen), Elicitation (Benutzereingaben), Logging (Debugging/Monitoring)
  - Aktualisiert mit aktuellen Methodenmustern für Entdeckung (`*/list`), Abruf (`*/get`) und Ausführung (`*/call`)
- **Protokollarchitektur**: Einführung eines zweischichtigen Architekturmodells
  - Datenebene: JSON-RPC 2.0 als Grundlage mit Lebenszyklusmanagement und Primitiven
  - Transporteebene: STDIO (lokal) und Streambares HTTP mit SSE (entfernt) als Transportmechanismen
- **Sicherheitsrahmenwerk**: Umfassende Sicherheitsprinzipien, einschließlich expliziter Benutzerzustimmung, Datenschutz, Sicherheit bei der Tool-Ausführung und Sicherheit der Transporteebene
- **Kommunikationsmuster**: Aktualisierte Protokollnachrichten, die Initialisierung, Entdeckung, Ausführung und Benachrichtigungsflüsse zeigen
- **Code-Beispiele**: Erneuerte mehrsprachige Beispiele (.NET, Java, Python, JavaScript), die aktuelle MCP-SDK-Muster widerspiegeln

#### Sicherheit (02-Security/) - Umfassende Sicherheitsüberarbeitung  
- **Standardsausrichtung**: Vollständige Ausrichtung an den Sicherheitsanforderungen der MCP-Spezifikation 2025-06-18
- **Authentifizierungsentwicklung**: Dokumentierte Entwicklung von benutzerdefinierten OAuth-Servern hin zu Delegation durch externe Identitätsanbieter (Microsoft Entra ID)
- **KI-spezifische Bedrohungsanalyse**: Erweiterte Abdeckung moderner KI-Angriffsvektoren
  - Detaillierte Szenarien für Prompt Injection-Angriffe mit realen Beispielen
  - Mechanismen zur Tool-Vergiftung und "Rug Pull"-Angriffsmuster
  - Kontextfenster-Vergiftung und Modellverwirrungsangriffe
- **Microsoft KI-Sicherheitslösungen**: Umfassende Abdeckung des Microsoft-Sicherheitsökosystems
  - KI-Prompt Shields mit fortschrittlicher Erkennung, Hervorhebung und Trenntechniken
  - Azure Content Safety-Integrationsmuster
  - GitHub Advanced Security für Schutz der Lieferkette
- **Erweiterte Bedrohungsminderung**: Detaillierte Sicherheitskontrollen für
  - Sitzungsentführung mit MCP-spezifischen Angriffsszenarien und kryptografischen Sitzungs-ID-Anforderungen
  - Probleme mit verwirrten Stellvertretern in MCP-Proxy-Szenarien mit expliziten Zustimmungsanforderungen
  - Token-Durchleitungsschwachstellen mit obligatorischen Validierungskontrollen
- **Sicherheit der Lieferkette**: Erweiterte Abdeckung der KI-Lieferkette, einschließlich Basis-Modellen, Einbettungsdiensten, Kontextanbietern und Drittanbieter-APIs
- **Grundlegende Sicherheit**: Verbesserte Integration mit Unternehmenssicherheitsmustern, einschließlich Zero-Trust-Architektur und Microsoft-Sicherheitsökosystem
- **Ressourcenorganisation**: Kategorisierte umfassende Ressourcenlinks nach Typ (Offizielle Dokumente, Standards, Forschung, Microsoft-Lösungen, Implementierungsleitfäden)

### Verbesserungen der Dokumentationsqualität
- **Strukturierte Lernziele**: Verbesserte Lernziele mit spezifischen, umsetzbaren Ergebnissen
- **Querverweise**: Hinzugefügte Links zwischen verwandten Sicherheits- und Kernkonzeptthemen
- **Aktuelle Informationen**: Aktualisierte alle Datumsreferenzen und Spezifikationslinks auf aktuelle Standards
- **Implementierungsleitfäden**: Hinzugefügte spezifische, umsetzbare Implementierungsrichtlinien in beiden Abschnitten

## 16. Juli 2025

### README- und Navigationsverbesserungen
- Das Curriculum-Navigationssystem in README.md komplett neu gestaltet
- `<details>`-Tags durch ein zugänglicheres tabellenbasiertes Format ersetzt
- Alternative Layout-Optionen im neuen Ordner "alternative_layouts" erstellt
- Kartenbasierte, registerkartenbasierte und akkordeonbasierte Navigationsbeispiele hinzugefügt
- Abschnitt zur Repository-Struktur aktualisiert, um alle neuesten Dateien einzuschließen
- Abschnitt "Wie man dieses Curriculum verwendet" mit klaren Empfehlungen verbessert
- MCP-Spezifikationslinks aktualisiert, um auf die richtigen URLs zu verweisen
- Abschnitt Kontext-Engineering (5.14) zur Curriculum-Struktur hinzugefügt

### Aktualisierungen des Studienleitfadens
- Studienleitfaden vollständig überarbeitet, um mit der aktuellen Repository-Struktur übereinzustimmen
- Neue Abschnitte für MCP-Clients und Tools sowie beliebte MCP-Server hinzugefügt
- Visuelle Curriculum-Karte aktualisiert, um alle Themen genau widerzuspiegeln
- Beschreibungen der erweiterten Themen verbessert, um alle spezialisierten Bereiche abzudecken
- Abschnitt Fallstudien aktualisiert, um reale Beispiele widerzuspiegeln
- Diesen umfassenden Änderungsprotokoll hinzugefügt

### Community-Beiträge (06-CommunityContributions/)
- Detaillierte Informationen zu MCP-Servern für die Bildgenerierung hinzugefügt
- Umfassender Abschnitt zur Verwendung von Claude in VSCode hinzugefügt
- Anweisungen zur Einrichtung und Nutzung des Cline-Terminal-Clients hinzugefügt
- MCP-Client-Abschnitt aktualisiert, um alle beliebten Client-Optionen einzuschließen
- Beitragsbeispiele mit genaueren Code-Beispielen verbessert

### Erweiterte Themen (05-AdvancedTopics/)
- Alle spezialisierten Themenordner mit konsistenter Benennung organisiert
- Materialien und Beispiele zum Kontext-Engineering hinzugefügt
- Dokumentation zur Integration von Foundry-Agenten hinzugefügt
- Dokumentation zur Sicherheitsintegration von Entra ID verbessert

## 11. Juni 2025

### Erstmalige Erstellung
- Erste Version des MCP für Anfänger-Curriculums veröffentlicht
- Grundstruktur für alle 10 Hauptabschnitte erstellt
- Visuelle Curriculum-Karte für die Navigation implementiert
- Erste Beispielprojekte in mehreren Programmiersprachen hinzugefügt

### Erste Schritte (03-GettingStarted/)
- Erste Server-Implementierungsbeispiele erstellt
- Anleitung zur Client-Entwicklung hinzugefügt
- Anweisungen zur Integration von LLM-Clients hinzugefügt
- Dokumentation zur Integration in VS Code hinzugefügt
- Server-Beispiele mit Server-Sent Events (SSE) implementiert

### Kernkonzepte (01-CoreConcepts/)
- Detaillierte Erklärung der Client-Server-Architektur hinzugefügt
- Dokumentation zu den wichtigsten Protokollkomponenten erstellt
- Nachrichtenmuster im MCP dokumentiert

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
- Zehn-Abschnitt-Struktur des Curriculums skizziert
- Konzeptuelles Rahmenwerk für Beispiele und Fallstudien entwickelt
- Erste Prototyp-Beispiele für Schlüsselkonzepte erstellt

---

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, weisen wir darauf hin, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.