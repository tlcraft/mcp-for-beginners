<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-16T23:06:20+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "de"
}
-->
# Neueste MCP-Sicherheitskontrollen – Juli 2025 Update

Da sich das Model Context Protocol (MCP) weiterentwickelt, bleibt Sicherheit ein entscheidender Aspekt. Dieses Dokument beschreibt die neuesten Sicherheitskontrollen und bewährten Verfahren für eine sichere Implementierung von MCP ab Juli 2025.

## Authentifizierung und Autorisierung

### Unterstützung der OAuth 2.0-Delegation

Aktuelle Updates der MCP-Spezifikation erlauben es MCP-Servern nun, die Benutzer-Authentifizierung an externe Dienste wie Microsoft Entra ID zu delegieren. Dies verbessert die Sicherheitslage erheblich durch:

1. **Vermeidung eigener Authentifizierungsimplementierungen**: Verringert das Risiko von Sicherheitslücken im eigenen Authentifizierungscode  
2. **Nutzung etablierter Identitätsanbieter**: Profitieren von Sicherheitsfunktionen auf Unternehmensniveau  
3. **Zentralisiertes Identitätsmanagement**: Erleichtert das Benutzerlebenszyklus-Management und die Zugriffskontrolle  

## Verhinderung von Token-Passthrough

Die MCP-Authorisierungs-Spezifikation verbietet ausdrücklich das Durchreichen von Tokens, um Umgehungen von Sicherheitskontrollen und Verantwortlichkeitsprobleme zu verhindern.

### Wichtige Anforderungen

1. **MCP-Server dürfen keine Tokens akzeptieren, die nicht für sie ausgestellt wurden**: Überprüfen, dass alle Tokens den korrekten Audience-Claim enthalten  
2. **Sorgfältige Token-Validierung implementieren**: Prüfen von Aussteller, Audience, Ablaufdatum und Signatur  
3. **Separate Token-Ausgabe verwenden**: Neue Tokens für nachgelagerte Dienste ausstellen, anstatt bestehende Tokens weiterzureichen  

## Sicheres Sitzungsmanagement

Um Session Hijacking und Fixation-Angriffe zu verhindern, sollten folgende Maßnahmen umgesetzt werden:

1. **Sichere, nicht-deterministische Session-IDs verwenden**: Generiert mit kryptographisch sicheren Zufallszahlengeneratoren  
2. **Sitzungen an Benutzeridentität binden**: Session-IDs mit benutzerspezifischen Informationen kombinieren  
3. **Session-Rotation korrekt umsetzen**: Nach Authentifizierungsänderungen oder Privilegienerhöhungen  
4. **Angemessene Session-Timeouts setzen**: Sicherheit und Benutzerfreundlichkeit ausbalancieren  

## Sandboxing der Tool-Ausführung

Um laterale Bewegungen zu verhindern und mögliche Kompromittierungen einzudämmen:

1. **Ausführungsumgebungen für Tools isolieren**: Container oder separate Prozesse verwenden  
2. **Ressourcenlimits anwenden**: Schutz vor Ressourcenerschöpfungsangriffen  
3. **Prinzip der minimalen Rechte umsetzen**: Nur notwendige Berechtigungen vergeben  
4. **Ausführungsmuster überwachen**: Anomales Verhalten erkennen  

## Schutz der Tool-Definitionen

Um Tool-Poisoning zu verhindern:

1. **Tool-Definitionen vor der Nutzung validieren**: Auf schädliche Anweisungen oder unangemessene Muster prüfen  
2. **Integritätsprüfung verwenden**: Tool-Definitionen hashen oder signieren, um unautorisierte Änderungen zu erkennen  
3. **Änderungsüberwachung implementieren**: Bei unerwarteten Modifikationen der Tool-Metadaten Alarm schlagen  
4. **Versionierung der Tool-Definitionen**: Änderungen nachverfolgen und bei Bedarf zurücksetzen  

Diese Kontrollen arbeiten zusammen, um eine robuste Sicherheitsbasis für MCP-Implementierungen zu schaffen, die den besonderen Herausforderungen KI-gesteuerter Systeme gerecht wird und gleichzeitig bewährte traditionelle Sicherheitspraktiken beibehält.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.