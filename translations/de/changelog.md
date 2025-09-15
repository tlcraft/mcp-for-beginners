<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T21:51:10+00:00",
  "source_file": "changelog.md",
  "language_code": "de"
}
-->
# Änderungsprotokoll: MCP für Anfänger Curriculum

Dieses Dokument dient als Aufzeichnung aller wesentlichen Änderungen am Curriculum des Model Context Protocol (MCP) für Anfänger. Änderungen werden in umgekehrt chronologischer Reihenfolge dokumentiert (neueste Änderungen zuerst).

## 15. September 2025

### Erweiterung der fortgeschrittenen Themen - Benutzerdefinierte Transportsysteme & Kontext-Engineering

#### MCP Benutzerdefinierte Transportsysteme (05-AdvancedTopics/mcp-transport/) - Neuer Leitfaden für fortgeschrittene Implementierungen
- **README.md**: Vollständiger Leitfaden zur Implementierung benutzerdefinierter MCP-Transportmechanismen
  - **Azure Event Grid Transport**: Umfassende serverlose, ereignisgesteuerte Transportimplementierung
    - Beispiele in C#, TypeScript und Python mit Azure Functions-Integration
    - Architekturmustern für ereignisgesteuerte, skalierbare MCP-Lösungen
    - Webhook-Empfänger und pushbasierte Nachrichtenverarbeitung
  - **Azure Event Hubs Transport**: Implementierung für hochdurchsatzfähige Streaming-Transportsysteme
    - Echtzeit-Streaming-Funktionen für Szenarien mit geringer Latenz
    - Partitionierungsstrategien und Checkpoint-Management
    - Nachrichtenbündelung und Leistungsoptimierung
  - **Enterprise-Integrationsmuster**: Produktionsreife Architekturbeispiele
    - Verteilte MCP-Verarbeitung über mehrere Azure Functions
    - Hybride Transportarchitekturen mit Kombination verschiedener Transporttypen
    - Strategien für Nachrichtenhaltbarkeit, Zuverlässigkeit und Fehlerbehandlung
  - **Sicherheit & Überwachung**: Integration von Azure Key Vault und Überwachungsmustern
    - Authentifizierung mit verwalteten Identitäten und Zugriff mit minimalen Berechtigungen
    - Telemetrie und Leistungsüberwachung mit Application Insights
    - Schutzmechanismen und Muster für Fehlertoleranz
  - **Testframeworks**: Umfassende Teststrategien für benutzerdefinierte Transportsysteme
    - Unit-Tests mit Test-Doubles und Mocking-Frameworks
    - Integrationstests mit Azure Test Containers
    - Überlegungen zu Leistungs- und Lasttests

#### Kontext-Engineering (05-AdvancedTopics/mcp-contextengineering/) - Aufstrebende Disziplin der KI
- **README.md**: Umfassende Untersuchung des Kontext-Engineering als aufstrebendes Feld
  - **Kernprinzipien**: Vollständige Kontextfreigabe, Bewusstsein für Aktionsentscheidungen und Verwaltung des Kontextfensters
  - **MCP-Protokollabgleich**: Wie MCP-Design Herausforderungen des Kontext-Engineering adressiert
    - Begrenzungen des Kontextfensters und Strategien für progressives Laden
    - Relevanzbestimmung und dynamische Kontextabfrage
    - Multimodale Kontextverarbeitung und Sicherheitsüberlegungen
  - **Implementierungsansätze**: Single-Threaded- vs. Multi-Agent-Architekturen
    - Techniken zur Kontextaufteilung und Priorisierung
    - Progressives Laden und Komprimierungsstrategien
    - Geschichtete Kontextansätze und Optimierung der Abfrage
  - **Messrahmen**: Aufkommende Metriken zur Bewertung der Kontexteffektivität
    - Eingabeeffizienz, Leistung, Qualität und Benutzererfahrungsüberlegungen
    - Experimentelle Ansätze zur Kontextoptimierung
    - Fehleranalyse und Verbesserungsmethoden

#### Aktualisierungen der Curriculum-Navigation (README.md)
- **Verbesserte Modulstruktur**: Aktualisierte Curriculum-Tabelle mit neuen fortgeschrittenen Themen
  - Hinzugefügt: Kontext-Engineering (5.14) und Benutzerdefinierte Transportsysteme (5.15)
  - Einheitliche Formatierung und Navigationslinks in allen Modulen
  - Aktualisierte Beschreibungen, die den aktuellen Inhalt widerspiegeln

### Verbesserungen der Verzeichnisstruktur
- **Namensstandardisierung**: Umbenennung von "mcp transport" in "mcp-transport" für Konsistenz mit anderen Ordnern für fortgeschrittene Themen
- **Inhaltsorganisation**: Alle Ordner in 05-AdvancedTopics folgen nun einem konsistenten Namensmuster (mcp-[Thema])

### Verbesserungen der Dokumentationsqualität
- **MCP-Spezifikationsabgleich**: Alle neuen Inhalte beziehen sich auf die aktuelle MCP-Spezifikation 2025-06-18
- **Mehrsprachige Beispiele**: Umfassende Codebeispiele in C#, TypeScript und Python
- **Unternehmensfokus**: Produktionsreife Muster und Azure-Cloud-Integration durchgehend
- **Visuelle Dokumentation**: Mermaid-Diagramme zur Architektur- und Ablaufvisualisierung

## 18. August 2025

### Umfassendes Update der Dokumentation - MCP-Standards 2025-06-18

#### MCP Sicherheitsbest Practices (02-Security/) - Vollständige Modernisierung
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Vollständige Überarbeitung gemäß MCP-Spezifikation 2025-06-18
  - **Verpflichtende Anforderungen**: Hinzugefügt: Explizite MUSS/MUSS NICHT-Anforderungen aus der offiziellen Spezifikation mit klaren visuellen Indikatoren
  - **12 Kern-Sicherheitspraktiken**: Umstrukturiert von einer 15-Punkte-Liste zu umfassenden Sicherheitsdomänen
    - Token-Sicherheit & Authentifizierung mit Integration externer Identitätsanbieter
    - Sitzungsmanagement & Transportsicherheit mit kryptografischen Anforderungen
    - KI-spezifischer Bedrohungsschutz mit Microsoft Prompt Shields-Integration
    - Zugriffskontrolle & Berechtigungen mit dem Prinzip der minimalen Berechtigungen
    - Inhaltsicherheit & Überwachung mit Azure Content Safety-Integration
    - Lieferkettensicherheit mit umfassender Komponentenüberprüfung
    - OAuth-Sicherheit & Verhinderung von Confused Deputy-Angriffen mit PKCE-Implementierung
    - Vorfallreaktion & Wiederherstellung mit automatisierten Fähigkeiten
    - Compliance & Governance mit regulatorischer Ausrichtung
    - Erweiterte Sicherheitskontrollen mit Zero-Trust-Architektur
    - Integration des Microsoft-Sicherheitsökosystems mit umfassenden Lösungen
    - Kontinuierliche Sicherheitsentwicklung mit adaptiven Praktiken
  - **Microsoft Sicherheitslösungen**: Verbesserte Integrationsanleitung für Prompt Shields, Azure Content Safety, Entra ID und GitHub Advanced Security
  - **Implementierungsressourcen**: Kategorisierte umfassende Ressourcenlinks nach Offizieller MCP-Dokumentation, Microsoft Sicherheitslösungen, Sicherheitsstandards und Implementierungsleitfäden

#### Erweiterte Sicherheitskontrollen (02-Security/) - Unternehmensimplementierung
- **MCP-SECURITY-CONTROLS-2025.md**: Vollständige Überarbeitung mit unternehmensgerechtem Sicherheitsrahmen
  - **9 umfassende Sicherheitsdomänen**: Erweiterung von grundlegenden Kontrollen zu detailliertem Unternehmensrahmen
    - Erweiterte Authentifizierung & Autorisierung mit Microsoft Entra ID-Integration
    - Token-Sicherheit & Anti-Passthrough-Kontrollen mit umfassender Validierung
    - Sicherheitskontrollen für Sitzungen mit Hijacking-Prävention
    - KI-spezifische Sicherheitskontrollen mit Schutz vor Prompt-Injection und Tool-Poisoning
    - Verhinderung von Confused Deputy-Angriffen mit OAuth-Proxy-Sicherheit
    - Sicherheit bei Tool-Ausführung mit Sandboxing und Isolation
    - Sicherheitskontrollen für Lieferketten mit Abhängigkeitsüberprüfung
    - Überwachungs- & Erkennungskontrollen mit SIEM-Integration
    - Vorfallreaktion & Wiederherstellung mit automatisierten Fähigkeiten
  - **Implementierungsbeispiele**: Hinzugefügt: Detaillierte YAML-Konfigurationsblöcke und Codebeispiele
  - **Microsoft-Lösungsintegration**: Umfassende Abdeckung von Azure-Sicherheitsdiensten, GitHub Advanced Security und Unternehmensidentitätsmanagement

#### Fortgeschrittene Themen Sicherheit (05-AdvancedTopics/mcp-security/) - Produktionsreife Implementierung
- **README.md**: Vollständige Überarbeitung für Unternehmenssicherheitsimplementierung
  - **Aktuelle Spezifikationsausrichtung**: Aktualisiert auf MCP-Spezifikation 2025-06-18 mit verpflichtenden Sicherheitsanforderungen
  - **Erweiterte Authentifizierung**: Microsoft Entra ID-Integration mit umfassenden Beispielen in .NET und Java Spring Security
  - **KI-Sicherheitsintegration**: Implementierung von Microsoft Prompt Shields und Azure Content Safety mit detaillierten Python-Beispielen
  - **Erweiterte Bedrohungsminderung**: Umfassende Implementierungsbeispiele für
    - Verhinderung von Confused Deputy-Angriffen mit PKCE und Validierung der Benutzerzustimmung
    - Verhinderung von Token-Passthrough mit Zielgruppenvalidierung und sicherem Token-Management
    - Verhinderung von Sitzungs-Hijacking mit kryptografischer Bindung und Verhaltensanalyse
  - **Unternehmenssicherheitsintegration**: Überwachung mit Azure Application Insights, Bedrohungserkennungspipelines und Lieferkettensicherheit
  - **Implementierungscheckliste**: Klare Unterscheidung zwischen verpflichtenden und empfohlenen Sicherheitskontrollen mit Vorteilen des Microsoft-Sicherheitsökosystems

### Verbesserungen der Dokumentationsqualität & Standardsausrichtung
- **Spezifikationsreferenzen**: Aktualisiert alle Verweise auf die aktuelle MCP-Spezifikation 2025-06-18
- **Microsoft-Sicherheitsökosystem**: Verbesserte Integrationsanleitung in der gesamten Sicherheitsdokumentation
- **Praktische Implementierung**: Hinzugefügt: Detaillierte Codebeispiele in .NET, Java und Python mit Unternehmensmustern
- **Ressourcenorganisation**: Umfassende Kategorisierung offizieller Dokumentation, Sicherheitsstandards und Implementierungsleitfäden
- **Visuelle Indikatoren**: Klare Kennzeichnung von verpflichtenden Anforderungen vs. empfohlenen Praktiken

#### Kernkonzepte (01-CoreConcepts/) - Vollständige Modernisierung
- **Protokollversions-Update**: Aktualisiert auf die aktuelle MCP-Spezifikation 2025-06-18 mit datumsbasierter Versionierung (YYYY-MM-DD-Format)
- **Architekturverfeinerung**: Verbesserte Beschreibungen von Hosts, Clients und Servern zur Darstellung aktueller MCP-Architekturmuster
  - Hosts jetzt klar definiert als KI-Anwendungen, die mehrere MCP-Client-Verbindungen koordinieren
  - Clients beschrieben als Protokoll-Connectoren mit Eins-zu-Eins-Serverbeziehungen
  - Server erweitert mit Szenarien für lokale vs. Remote-Bereitstellung
- **Primitive Umstrukturierung**: Vollständige Überarbeitung der Server- und Client-Primitiven
  - Server-Primitiven: Ressourcen (Datenquellen), Prompts (Vorlagen), Tools (ausführbare Funktionen) mit detaillierten Erklärungen und Beispielen
  - Client-Primitiven: Sampling (LLM-Vervollständigungen), Elicitation (Benutzereingaben), Logging (Debugging/Überwachung)
  - Aktualisiert mit aktuellen Discovery- (`*/list`), Retrieval- (`*/get`) und Execution- (`*/call`) Methodenmuster
- **Protokollarchitektur**: Einführung eines Zwei-Schichten-Architekturmodells
  - Datenebene: JSON-RPC 2.0 Grundlage mit Lebenszyklusmanagement und Primitiven
  - Transporteebene: STDIO (lokal) und Streamable HTTP mit SSE (remote) Transportmechanismen
- **Sicherheitsrahmen**: Umfassende Sicherheitsprinzipien einschließlich expliziter Benutzerzustimmung, Datenschutz, Sicherheit bei Tool-Ausführung und Transportsicherheit
- **Kommunikationsmuster**: Aktualisierte Protokollnachrichten zur Darstellung von Initialisierung, Discovery, Ausführung und Benachrichtigungsabläufen
- **Codebeispiele**: Aktualisierte mehrsprachige Beispiele (.NET, Java, Python, JavaScript) zur Darstellung aktueller MCP-SDK-Muster

#### Sicherheit (02-Security/) - Umfassende Sicherheitsüberarbeitung  
- **Standardsausrichtung**: Vollständige Ausrichtung an den Sicherheitsanforderungen der MCP-Spezifikation 2025-06-18
- **Entwicklung der Authentifizierung**: Dokumentierte Entwicklung von benutzerdefinierten OAuth-Servern zu Delegation durch externe Identitätsanbieter (Microsoft Entra ID)
- **KI-spezifische Bedrohungsanalyse**: Verbesserte Abdeckung moderner KI-Angriffsvektoren
  - Detaillierte Szenarien für Prompt-Injection-Angriffe mit realen Beispielen
  - Mechanismen für Tool-Poisoning und "Rug Pull"-Angriffsmuster
  - Kontextfenstervergiftung und Modellverwirrungsangriffe
- **Microsoft KI-Sicherheitslösungen**: Umfassende Abdeckung des Microsoft-Sicherheitsökosystems
  - AI Prompt Shields mit fortschrittlicher Erkennung, Spotlighting und Delimiter-Techniken
  - Azure Content Safety-Integrationsmuster
  - GitHub Advanced Security für Lieferkettenschutz
- **Erweiterte Bedrohungsminderung**: Detaillierte Sicherheitskontrollen für
  - Sitzungs-Hijacking mit MCP-spezifischen Angriffsszenarien und kryptografischen Sitzungs-ID-Anforderungen
  - Confused Deputy-Probleme in MCP-Proxy-Szenarien mit expliziten Zustimmungsanforderungen
  - Token-Passthrough-Schwachstellen mit verpflichtenden Validierungskontrollen
- **Lieferkettensicherheit**: Erweiterte Abdeckung der KI-Lieferkette einschließlich Foundation-Modelle, Embedding-Dienste, Kontextanbieter und Drittanbieter-APIs
- **Grundlegende Sicherheit**: Verbesserte Integration mit Unternehmenssicherheitsmustern einschließlich Zero-Trust-Architektur und Microsoft-Sicherheitsökosystem
- **Ressourcenorganisation**: Kategorisierte umfassende Ressourcenlinks nach Typ (Offizielle Dokumente, Standards, Forschung, Microsoft-Lösungen, Implementierungsleitfäden)

### Verbesserungen der Dokumentationsqualität
- **Strukturierte Lernziele**: Verbesserte Lernziele mit spezifischen, umsetzbaren Ergebnissen 
- **Querverweise**: Hinzugefügt: Links zwischen verwandten Sicherheits- und Kernkonzeptthemen
- **Aktuelle Informationen**: Aktualisiert alle Datumsreferenzen und Spezifikationslinks auf aktuelle Standards
- **Implementierungsleitfäden**: Hinzugefügt: Spezifische, umsetzbare Implementierungsrichtlinien in beiden Abschnitten

## 16. Juli 2025

### Verbesserungen von README und Navigation
- Vollständig überarbeitete Curriculum-Navigation in README.md
- Ersetzt `<details>`-Tags durch zugänglichere tabellenbasierte Formatierung
- Alternative Layoutoptionen im neuen Ordner "alternative_layouts" erstellt
- Hinzugefügt: Kartenbasierte, tabbed-style und accordion-style Navigationsbeispiele
- Aktualisierte Abschnittsstruktur des Repositorys, um alle neuesten Dateien einzuschließen
- Verbesserte "Wie man dieses Curriculum verwendet"-Sektion mit klaren Empfehlungen
- Aktualisierte MCP-Spezifikationslinks, um auf die richtigen URLs zu verweisen
- Hinzugefügt: Kontext-Engineering-Sektion (5.14) zur Curriculum-Struktur

### Aktualisierungen des Studienleitfadens
- Studienleitfaden vollständig überarbeitet, um mit der aktuellen Repository-Struktur übereinzustimmen
- Neue Abschnitte hinzugefügt: MCP-Clients und Tools sowie Beliebte MCP-Server
- Aktualisierte visuelle Curriculum-Karte, um alle Themen genau darzustellen
- Verbesserte Beschreibungen der fortgeschrittenen Themen, um alle spezialisierten Bereiche abzudecken
- Aktualisierte Fallstudien-Sektion, um tatsächliche Beispiele widerzuspiegeln
- Hinzugefügt: Dieses umfassende Änderungsprotokoll

### Community-Beiträge (06-CommunityContributions/)
- Detaillierte Informationen zu MCP-Servern für die Bildgenerierung hinzugefügt
- Umfassender Abschnitt zur Nutzung von Claude in VSCode hinzugefügt
- Setup- und Nutzungsanweisungen für Cline-Terminal-Client hinzugefügt
- MCP-Client-Sektion aktualisiert, um alle beliebten Client-Optionen einzuschließen
- Verbesserte Beitragsbeispiele mit genaueren Codebeispielen

### Fortgeschrittene Themen (05-AdvancedTopics/)
- Alle spezialisierten Themenordner mit konsistenter Namensgebung organisiert
- Kontext-Engineering-Materialien und Beispiele hinzugefügt
- Dokumentation zur Foundry-Agent-Integration hinzugefügt
- Verbesserte Dokumentation zur Entra ID-Sicherheitsintegration

## 11. Juni 2025

### Erstmalige Erstellung
- Erste Version des MCP für Anfänger Curriculum veröffentlicht
- Grundstruktur für alle 10 Hauptabschnitte erstellt
- Visuelle Curriculum-Karte für Navigation implementiert
- Erste Beispielprojekte in mehreren Programmiersprachen hinzugefügt

### Erste Schritte (03-GettingStarted/)
- Erste Server-Implementierungsbeispiele erstellt
- Anleitung zur Client-Entwicklung hinzugefügt
- Integration von LLM-Clients dokumentiert
- Dokumentation zur VS Code-Integration hinzugefügt
- Server-Sent Events (SSE)-Serverbeispiele implementiert

### Kernkonzepte (01-CoreConcepts/)
- Detaillierte Erklärung der Client-Server-Architektur hinzugefügt
- Dokumentation zu Schlüsselprotokollkomponenten erstellt
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
- SUPPORT.md mit Hilfsanweisungen erstellt
- Vorläufige Struktur des Studienleitfadens erstellt

## 15. April 2025

### Planung und Rahmenwerk
- Erste Planung für MCP für Anfänger Curriculum
- Lernziele und Zielgruppe definiert
- 10-Abschnitt-Struktur des Curriculums skizziert
- Konzeptuelles Rahmenwerk für Beispiele und Fallstudien entwickelt
- Erste Prototypbeispiele für Schlüsselkonzepte erstellt

---

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die sich aus der Nutzung dieser Übersetzung ergeben.