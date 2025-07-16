<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-16T23:11:47+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "de"
}
-->
# MCP Sicherheits-Best Practices – Juli 2025 Update

## Umfassende Sicherheits-Best Practices für MCP-Implementierungen

Wenn Sie mit MCP-Servern arbeiten, befolgen Sie diese Sicherheits-Best Practices, um Ihre Daten, Infrastruktur und Nutzer zu schützen:

1. **Eingabevalidierung**: Validieren und bereinigen Sie Eingaben stets, um Injection-Angriffe und Confused-Deputy-Probleme zu vermeiden.
   - Implementieren Sie strenge Validierung für alle Tool-Parameter
   - Verwenden Sie Schema-Validierung, um sicherzustellen, dass Anfragen den erwarteten Formaten entsprechen
   - Filtern Sie potenziell schädliche Inhalte vor der Verarbeitung

2. **Zugriffskontrolle**: Implementieren Sie eine ordnungsgemäße Authentifizierung und Autorisierung für Ihren MCP-Server mit fein abgestuften Berechtigungen.
   - Nutzen Sie OAuth 2.0 mit etablierten Identitätsanbietern wie Microsoft Entra ID
   - Implementieren Sie rollenbasierte Zugriffskontrolle (RBAC) für MCP-Tools
   - Vermeiden Sie eigene Authentifizierungslösungen, wenn etablierte vorhanden sind

3. **Sichere Kommunikation**: Verwenden Sie HTTPS/TLS für alle Kommunikationen mit Ihrem MCP-Server und erwägen Sie zusätzliche Verschlüsselung für sensible Daten.
   - Konfigurieren Sie TLS 1.3, wo möglich
   - Implementieren Sie Certificate Pinning für kritische Verbindungen
   - Rotieren Sie Zertifikate regelmäßig und überprüfen Sie deren Gültigkeit

4. **Rate Limiting**: Implementieren Sie Rate Limiting, um Missbrauch, DoS-Angriffe und Ressourcenüberlastung zu verhindern.
   - Legen Sie angemessene Anfragelimits basierend auf erwarteten Nutzungsmustern fest
   - Implementieren Sie abgestufte Reaktionen auf übermäßige Anfragen
   - Berücksichtigen Sie benutzerspezifische Limits basierend auf dem Authentifizierungsstatus

5. **Protokollierung und Überwachung**: Überwachen Sie Ihren MCP-Server auf verdächtige Aktivitäten und implementieren Sie umfassende Audit-Trails.
   - Protokollieren Sie alle Authentifizierungsversuche und Tool-Aufrufe
   - Implementieren Sie Echtzeit-Benachrichtigungen bei verdächtigen Mustern
   - Stellen Sie sicher, dass Protokolle sicher gespeichert und nicht manipulierbar sind

6. **Sichere Speicherung**: Schützen Sie sensible Daten und Zugangsdaten mit geeigneter Verschlüsselung im Ruhezustand.
   - Verwenden Sie Key Vaults oder sichere Credential Stores für alle Geheimnisse
   - Implementieren Sie feldbasierte Verschlüsselung für sensible Daten
   - Rotieren Sie Verschlüsselungsschlüssel und Zugangsdaten regelmäßig

7. **Token-Management**: Verhindern Sie Token-Passthrough-Schwachstellen durch Validierung und Bereinigung aller Modell-Ein- und Ausgaben.
   - Validieren Sie Tokens basierend auf Audience-Claims
   - Akzeptieren Sie niemals Tokens, die nicht explizit für Ihren MCP-Server ausgestellt wurden
   - Implementieren Sie ein angemessenes Token-Lebenszyklus-Management und Rotation

8. **Sitzungsmanagement**: Implementieren Sie sicheres Sitzungsmanagement, um Session Hijacking und Fixation zu verhindern.
   - Verwenden Sie sichere, nicht vorhersagbare Session-IDs
   - Binden Sie Sessions an benutzerspezifische Informationen
   - Sorgen Sie für angemessene Sitzungsablaufzeiten und Rotation

9. **Sandboxing der Tool-Ausführung**: Führen Sie Tool-Ausführungen in isolierten Umgebungen aus, um laterale Bewegungen bei Kompromittierung zu verhindern.
   - Implementieren Sie Container-Isolation für die Tool-Ausführung
   - Setzen Sie Ressourcenlimits, um Ressourcenerschöpfungsangriffe zu verhindern
   - Verwenden Sie separate Ausführungskontexte für unterschiedliche Sicherheitsdomänen

10. **Regelmäßige Sicherheitsüberprüfungen**: Führen Sie regelmäßige Sicherheitsreviews Ihrer MCP-Implementierungen und Abhängigkeiten durch.
    - Planen Sie regelmäßige Penetrationstests
    - Nutzen Sie automatisierte Scanning-Tools zur Erkennung von Schwachstellen
    - Halten Sie Abhängigkeiten aktuell, um bekannte Sicherheitsprobleme zu beheben

11. **Content Safety Filtering**: Implementieren Sie Content-Sicherheitsfilter für Eingaben und Ausgaben.
    - Verwenden Sie Azure Content Safety oder ähnliche Dienste zur Erkennung schädlicher Inhalte
    - Setzen Sie Prompt-Shield-Techniken ein, um Prompt Injection zu verhindern
    - Scannen Sie generierte Inhalte auf potenzielle sensible Datenlecks

12. **Supply Chain Security**: Überprüfen Sie die Integrität und Authentizität aller Komponenten in Ihrer KI-Lieferkette.
    - Verwenden Sie signierte Pakete und überprüfen Sie Signaturen
    - Implementieren Sie Software Bill of Materials (SBOM)-Analysen
    - Überwachen Sie auf bösartige Updates von Abhängigkeiten

13. **Schutz der Tool-Definitionen**: Verhindern Sie Tool-Poisoning durch Absicherung von Tool-Definitionen und Metadaten.
    - Validieren Sie Tool-Definitionen vor der Nutzung
    - Überwachen Sie unerwartete Änderungen an Tool-Metadaten
    - Implementieren Sie Integritätsprüfungen für Tool-Definitionen

14. **Dynamische Ausführungsüberwachung**: Überwachen Sie das Laufzeitverhalten von MCP-Servern und Tools.
    - Implementieren Sie Verhaltensanalysen zur Erkennung von Anomalien
    - Richten Sie Benachrichtigungen für unerwartete Ausführungsmuster ein
    - Nutzen Sie Runtime Application Self-Protection (RASP)-Techniken

15. **Prinzip der minimalen Rechte**: Stellen Sie sicher, dass MCP-Server und Tools nur mit den minimal erforderlichen Berechtigungen arbeiten.
    - Gewähren Sie nur die spezifischen Berechtigungen, die für jede Operation nötig sind
    - Überprüfen und auditieren Sie Berechtigungen regelmäßig
    - Implementieren Sie Just-in-Time-Zugriff für administrative Funktionen

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.