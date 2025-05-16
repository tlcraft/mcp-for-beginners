<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:40:49+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "de"
}
-->
# Security Best Practices

Die Einführung des Model Context Protocol (MCP) bringt leistungsstarke neue Möglichkeiten für KI-gesteuerte Anwendungen mit sich, stellt aber auch besondere Sicherheitsherausforderungen dar, die über herkömmliche Software-Risiken hinausgehen. Neben bewährten Themen wie sicherer Programmierung, dem Prinzip der minimalen Rechtevergabe und der Sicherheit der Lieferkette sind MCP und KI-Workloads neuen Bedrohungen ausgesetzt, wie Prompt Injection, Tool Poisoning und dynamischer Werkzeugänderung. Diese Risiken können zu Datenabfluss, Datenschutzverletzungen und unvorhergesehenem Systemverhalten führen, wenn sie nicht richtig gehandhabt werden.

Diese Lektion behandelt die wichtigsten Sicherheitsrisiken im Zusammenhang mit MCP – darunter Authentifizierung, Autorisierung, übermäßige Berechtigungen, indirekte Prompt Injection und Schwachstellen in der Lieferkette – und zeigt umsetzbare Maßnahmen und Best Practices zur Risikominderung auf. Sie lernen außerdem, wie Sie Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security nutzen können, um Ihre MCP-Implementierung zu stärken. Durch das Verständnis und die Anwendung dieser Kontrollen können Sie die Wahrscheinlichkeit von Sicherheitsverletzungen deutlich reduzieren und sicherstellen, dass Ihre KI-Systeme robust und vertrauenswürdig bleiben.

# Learning Objectives

Am Ende dieser Lektion werden Sie in der Lage sein:

- Die spezifischen Sicherheitsrisiken des Model Context Protocol (MCP) zu erkennen und zu erklären, einschließlich Prompt Injection, Tool Poisoning, übermäßiger Berechtigungen und Schwachstellen in der Lieferkette.
- Effektive Maßnahmen zur Risikominderung bei MCP-Sicherheitsrisiken zu beschreiben und anzuwenden, wie robuste Authentifizierung, minimale Rechtevergabe, sicheres Token-Management und Überprüfung der Lieferkette.
- Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security zu verstehen und einzusetzen, um MCP und KI-Workloads zu schützen.
- Die Bedeutung der Validierung von Werkzeug-Metadaten, der Überwachung dynamischer Änderungen und der Abwehr indirekter Prompt Injection-Angriffe zu erkennen.
- Bewährte Sicherheitspraktiken wie sichere Programmierung, Server-Härtung und Zero-Trust-Architektur in Ihre MCP-Implementierung zu integrieren, um das Risiko und die Auswirkungen von Sicherheitsvorfällen zu minimieren.

# MCP security controls

Jedes System, das Zugriff auf wichtige Ressourcen hat, bringt implizite Sicherheitsherausforderungen mit sich. Sicherheitsprobleme lassen sich im Allgemeinen durch die korrekte Anwendung grundlegender Sicherheitskontrollen und -konzepte angehen. Da MCP erst neu definiert wurde, ändert sich die Spezifikation sehr schnell und entwickelt sich weiter. Mit der Zeit werden die darin enthaltenen Sicherheitskontrollen ausgereifter, was eine bessere Integration in Unternehmens- und etablierte Sicherheitsarchitekturen und Best Practices ermöglicht.

Forschungen im [Microsoft Digital Defense Report](https://aka.ms/mddr) zeigen, dass 98 % der gemeldeten Sicherheitsverletzungen durch robuste Sicherheitsvorkehrungen verhindert werden könnten. Der beste Schutz gegen jegliche Art von Sicherheitsvorfall besteht darin, eine solide Basissicherheit, sichere Programmierpraktiken und Lieferkettensicherheit umzusetzen – diese bewährten Methoden haben weiterhin den größten Einfluss auf die Reduzierung von Sicherheitsrisiken.

Sehen wir uns einige Möglichkeiten an, wie Sie Sicherheitsrisiken bei der Einführung von MCP angehen können.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Die folgenden Informationen sind Stand 26. April 2025 korrekt. Das MCP-Protokoll entwickelt sich ständig weiter, und zukünftige Implementierungen können neue Authentifizierungsmuster und -kontrollen einführen. Für die neuesten Updates und Anleitungen konsultieren Sie stets die [MCP Specification](https://spec.modelcontextprotocol.io/) und das offizielle [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problemstellung  
Die ursprüngliche MCP-Spezifikation ging davon aus, dass Entwickler ihren eigenen Authentifizierungsserver schreiben würden. Dies erforderte Kenntnisse zu OAuth und den damit verbundenen Sicherheitsanforderungen. MCP-Server fungierten als OAuth 2.0 Authorization Server und verwalteten die erforderliche Benutzer-Authentifizierung direkt, anstatt sie an einen externen Dienst wie Microsoft Entra ID zu delegieren. Ab dem 26. April 2025 erlaubt ein Update der MCP-Spezifikation, dass MCP-Server die Benutzer-Authentifizierung an einen externen Dienst auslagern können.

### Risiken  
- Fehlkonfigurierte Autorisierungslogik im MCP-Server kann zur Offenlegung sensibler Daten und falsch angewandten Zugriffskontrollen führen.
- Diebstahl von OAuth-Tokens auf dem lokalen MCP-Server. Wenn ein Token gestohlen wird, kann es verwendet werden, um den MCP-Server zu imitieren und auf Ressourcen und Daten des Dienstes zuzugreifen, für den das OAuth-Token gilt.

### Gegenmaßnahmen  
- **Autorisierungslogik überprüfen und härten:** Prüfen Sie die Implementierung der Autorisierung Ihres MCP-Servers sorgfältig, um sicherzustellen, dass nur beabsichtigte Benutzer und Clients Zugriff auf sensible Ressourcen haben. Praktische Anleitungen finden Sie unter [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) und [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Sichere Token-Verfahren durchsetzen:** Befolgen Sie die [Microsoft-Best-Practices zur Token-Validierung und Lebensdauer](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), um Missbrauch von Zugriffstoken zu verhindern und das Risiko von Token-Wiederholungen oder Diebstahl zu minimieren.
- **Token-Speicherung schützen:** Speichern Sie Tokens stets sicher und verwenden Sie Verschlüsselung, um sie im Ruhezustand und bei der Übertragung zu schützen. Tipps zur Umsetzung finden Sie unter [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problemstellung  
MCP-Server könnten übermäßige Berechtigungen für den Dienst oder die Ressource erhalten haben, auf die sie zugreifen. Beispielsweise sollte ein MCP-Server, der Teil einer KI-Verkaufsanwendung ist und auf einen Unternehmensdatenspeicher zugreift, nur Zugriff auf die Verkaufsdaten haben und nicht auf alle Dateien im Speicher zugreifen dürfen. Das Prinzip der minimalen Rechtevergabe (eines der ältesten Sicherheitsprinzipien) besagt, dass keine Ressource mehr Berechtigungen erhalten sollte, als für die Ausführung der vorgesehenen Aufgaben erforderlich sind. KI stellt in diesem Bereich eine besondere Herausforderung dar, da es schwierig sein kann, die genauen erforderlichen Berechtigungen zu definieren, um Flexibilität zu ermöglichen.

### Risiken  
- Übermäßige Berechtigungen können zu Datenabfluss oder unbefugter Änderung von Daten führen, auf die der MCP-Server keinen Zugriff haben sollte. Dies kann auch Datenschutzprobleme verursachen, wenn es sich um personenbezogene Daten (PII) handelt.

### Gegenmaßnahmen  
- **Prinzip der minimalen Rechtevergabe anwenden:** Gewähren Sie dem MCP-Server nur die minimal notwendigen Berechtigungen für seine Aufgaben. Überprüfen und aktualisieren Sie diese Berechtigungen regelmäßig, um sicherzustellen, dass sie nicht über das erforderliche Maß hinausgehen. Detaillierte Anleitungen finden Sie unter [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Rollenbasierte Zugriffskontrolle (RBAC) verwenden:** Weisen Sie dem MCP-Server Rollen zu, die eng auf bestimmte Ressourcen und Aktionen beschränkt sind, und vermeiden Sie breite oder unnötige Berechtigungen.
- **Berechtigungen überwachen und prüfen:** Überwachen Sie die Nutzung von Berechtigungen kontinuierlich und prüfen Sie Zugriffprotokolle, um übermäßige oder ungenutzte Rechte schnell zu erkennen und zu beheben.

# Indirect prompt injection attacks

### Problemstellung

Bösartige oder kompromittierte MCP-Server können erhebliche Risiken bergen, indem sie Kundendaten offenlegen oder unerwünschte Aktionen ermöglichen. Diese Risiken sind besonders relevant bei KI- und MCP-basierten Workloads, wo:

- **Prompt Injection Attacks**: Angreifer betten bösartige Anweisungen in Prompts oder externe Inhalte ein, wodurch das KI-System unerwünschte Aktionen ausführt oder sensible Daten preisgibt. Mehr dazu: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Angreifer manipulieren die Metadaten von Werkzeugen (z. B. Beschreibungen oder Parameter), um das Verhalten der KI zu beeinflussen, Sicherheitskontrollen zu umgehen oder Daten abzugreifen. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Bösartige Anweisungen werden in Dokumente, Webseiten oder E-Mails eingebettet, die dann von der KI verarbeitet werden, was zu Datenlecks oder Manipulationen führt.
- **Dynamic Tool Modification (Rug Pulls)**: Werkzeugdefinitionen können nach der Nutzerfreigabe geändert werden, wodurch neue bösartige Verhaltensweisen ohne Wissen des Nutzers eingeführt werden.

Diese Schwachstellen unterstreichen die Notwendigkeit robuster Validierung, Überwachung und Sicherheitskontrollen beim Einbinden von MCP-Servern und Werkzeugen in Ihre Umgebung. Für eine tiefere Auseinandersetzung siehe die oben verlinkten Quellen.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.de.png)

**Indirect Prompt Injection** (auch bekannt als cross-domain prompt injection oder XPIA) ist eine kritische Schwachstelle in generativen KI-Systemen, einschließlich solcher, die das Model Context Protocol (MCP) nutzen. Bei diesem Angriff werden bösartige Anweisungen in externen Inhalten – wie Dokumenten, Webseiten oder E-Mails – versteckt. Wenn das KI-System diese Inhalte verarbeitet, interpretiert es die eingebetteten Anweisungen möglicherweise als legitime Benutzerbefehle, was zu unerwünschten Aktionen wie Datenlecks, der Erzeugung schädlicher Inhalte oder der Manipulation von Benutzerinteraktionen führt. Eine ausführliche Erklärung und Beispiele aus der Praxis finden Sie unter [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Eine besonders gefährliche Form dieses Angriffs ist **Tool Poisoning**. Hierbei injizieren Angreifer bösartige Anweisungen in die Metadaten von MCP-Werkzeugen (z. B. Werkzeugbeschreibungen oder Parameter). Da große Sprachmodelle (LLMs) diese Metadaten nutzen, um zu entscheiden, welche Werkzeuge sie aufrufen, können kompromittierte Beschreibungen das Modell dazu verleiten, unautorisierte Werkzeugaufrufe auszuführen oder Sicherheitskontrollen zu umgehen. Diese Manipulationen sind für Endanwender oft unsichtbar, werden jedoch vom KI-System interpretiert und ausgeführt. Das Risiko ist in gehosteten MCP-Server-Umgebungen besonders hoch, wo Werkzeugdefinitionen nach der Nutzerfreigabe aktualisiert werden können – ein Szenario, das manchmal als "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" bezeichnet wird. In solchen Fällen kann ein zuvor sicheres Werkzeug später modifiziert werden, um bösartige Aktionen auszuführen, wie z. B. Datenabfluss oder Verhaltensänderungen im System, ohne dass der Nutzer davon erfährt. Mehr zu diesem Angriffsvektor finden Sie unter [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.de.png)

## Risiken  
Unbeabsichtigte KI-Aktionen bergen verschiedene Sicherheitsrisiken, darunter Datenabfluss und Datenschutzverletzungen.

### Gegenmaßnahmen  
### Einsatz von Prompt Shields zum Schutz vor indirekten Prompt Injection-Angriffen  
-----------------------------------------------------------------------------

**AI Prompt Shields** sind eine von Microsoft entwickelte Lösung zum Schutz vor direkten und indirekten Prompt Injection-Angriffen. Sie helfen durch:

1.  **Erkennung und Filterung:** Prompt Shields nutzen fortschrittliche Algorithmen des maschinellen Lernens und natürliche Sprachverarbeitung, um bösartige Anweisungen in externen Inhalten wie Dokumenten, Webseiten oder E-Mails zu erkennen und herauszufiltern.
    
2.  **Spotlighting:** Diese Technik unterstützt das KI-System dabei, gültige Systemanweisungen von potenziell unzuverlässigen externen Eingaben zu unterscheiden. Durch die Transformation des Eingabetexts in eine für das Modell relevantere Form stellt Spotlighting sicher, dass die KI bösartige Anweisungen besser erkennen und ignorieren kann.
    
3.  **Trennzeichen und Datamarking:** Die Verwendung von Trennzeichen in der Systemnachricht markiert explizit den Ort des Eingabetexts, was dem KI-System hilft, Benutzereingaben von potenziell schädlichen externen Inhalten zu unterscheiden. Datamarking erweitert dieses Konzept durch spezielle Marker, die die Grenzen von vertrauenswürdigen und nicht vertrauenswürdigen Daten hervorheben.
    
4.  **Kontinuierliche Überwachung und Updates:** Microsoft überwacht und aktualisiert Prompt Shields fortlaufend, um neue und sich entwickelnde Bedrohungen zu adressieren. Dieser proaktive Ansatz sorgt dafür, dass die Schutzmechanismen stets gegen die neuesten Angriffstechniken wirksam sind.
    
5. **Integration mit Azure Content Safety:** Prompt Shields sind Teil der umfassenderen Azure AI Content Safety-Suite, die zusätzliche Werkzeuge zur Erkennung von Jailbreak-Versuchen, schädlichen Inhalten und anderen Sicherheitsrisiken in KI-Anwendungen bietet.

Mehr Informationen zu AI Prompt Shields finden Sie in der [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.de.png)

### Supply chain security

Die Sicherheit der Lieferkette bleibt im KI-Zeitalter grundlegend, jedoch hat sich der Umfang dessen, was zur Lieferkette gehört, erweitert. Neben traditionellen Codepaketen müssen jetzt alle KI-bezogenen Komponenten rigoros überprüft und überwacht werden, einschließlich Foundation Models, Embedding-Services, Kontextanbieter und Drittanbieter-APIs. Jede dieser Komponenten kann Schwachstellen oder Risiken bergen, wenn sie nicht richtig verwaltet wird.

**Wichtige Praktiken für die Sicherheit der Lieferkette bei KI und MCP:**
- **Alle Komponenten vor der Integration überprüfen:** Dazu gehören nicht nur Open-Source-Bibliotheken, sondern auch KI-Modelle, Datenquellen und externe APIs. Prüfen Sie stets Herkunft, Lizenzierung und bekannte Schwachstellen.
- **Sichere Deployment-Pipelines pflegen:** Verwenden Sie automatisierte CI/CD-Pipelines mit integrierter Sicherheitsprüfung, um Probleme frühzeitig zu erkennen. Stellen Sie sicher, dass nur vertrauenswürdige Artefakte in die Produktion gelangen.
- **Kontinuierliche Überwachung und Prüfung:** Implementieren Sie eine fortlaufende Überwachung aller Abhängigkeiten, einschließlich Modelle und Datendienste, um neue Schwachstellen oder Angriffe auf die Lieferkette zu erkennen.
- **Prinzip der minimalen Rechtevergabe und Zugriffskontrollen anwenden:** Beschränken Sie den Zugriff auf Modelle, Daten und Dienste auf das notwendige Minimum, das Ihr MCP-Server benötigt.
- **Schnelles Reagieren auf Bedrohungen:** Etablieren Sie Prozesse zum Patchen oder Ersetzen kompromittierter Komponenten sowie zum Rotieren von Geheimnissen oder Zugangsdaten bei Erkennung eines Sicherheitsvorfalls.

[GitHub Advanced Security](https://github.com/security/advanced-security) bietet Funktionen wie Secret Scanning, Dependency Scanning und CodeQL-Analyse. Diese Tools integrieren sich mit [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) und [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), um Teams bei der Identifikation und Behebung von Schwachstellen in Code und KI-Lieferkettenkomponenten zu unterstützen.

Microsoft implementiert auch intern umfangreiche Sicherheitspraktiken für die Lieferkette aller Produkte. Mehr dazu finden Sie in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Jede MCP-Implementierung übernimmt die bestehende Sicherheitslage der Umgebung, auf der sie aufbaut. Daher wird empfohlen, bei der Betrachtung der Sicherheit von MCP als Teil Ihrer gesamten KI-Systeme auch die allgemeine Sicherheitslage zu verbessern. Die folgenden bewährten Sicherheitskontrollen sind dabei besonders relevant:

- Sichere Programmierpraktiken in Ihrer KI-Anwendung – Schutz vor [den OWASP Top 10](https://owasp.org/www-project-top-ten/), den [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), Verwendung sicherer Vaults für Geheimnisse und Tokens, Implementierung von durchgängiger sicherer Kommunikation zwischen allen Anwendungsbestandteilen usw.
- Server-Härtung – Einsatz von MFA, wo möglich, regelmäßige Updates und Patches, Integration des Servers mit einem Drittanbieter-Identitätsanbieter für den Zugriff usw.
- Halten Sie Geräte, Infrastruktur und Anwendungen mit aktuellen Patches auf dem neuesten Stand.
- Sicherheitsüberwachung – Implementierung von Logging und Monitoring einer KI-Anwendung (einschließlich MCP-Clients/-Servern) und Übermittlung dieser Protokolle an ein zentrales SIEM zur Erkennung anomaler Aktivitäten.
- Zero-Trust-Architektur – Isolierung von Komponenten durch Netzwerk- und Identitätskontrollen in logischer Weise, um seitliche Bewegungen bei einer Kompromittierung der KI-Anwendung zu minimieren.

# Key Takeaways

- Sicherheitsgrundlagen bleiben entscheidend: Sichere Programmierung, minimale Rechtevergabe, Überprüfung der Lieferkette und kontinuierliche Überwachung sind essenziell für MCP- und KI-Workloads.
- MCP bringt neue Risiken mit sich – wie Prompt Injection, Tool Poisoning und übermäßige Berechtigungen – die sowohl traditionelle als auch KI-spezifische Kontrollen erfordern.
- Verwenden Sie robuste Authentifizierungs-, Autorisierungs- und Token-Management-Praktiken und nutzen Sie externe Identitätsanbieter wie Microsoft Entra ID, wo möglich.
- Schützen Sie vor indirekter Prompt Injection und Tool Poisoning durch Validierung von Werkzeug-Metadaten, Überwachung dynamischer Änderungen und Einsatz von Lösungen wie Microsoft Prompt Shields.
- Behandeln Sie alle Komponenten Ihrer KI-L
- [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Die Reise zur Sicherung der Software-Lieferkette bei Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sicheren Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices für Token-Validierung und Lebensdauer](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sichere Token-Speicherung verwenden und Tokens verschlüsseln (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management als Auth-Gateway für MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID zur Authentifizierung bei MCP-Servern verwenden](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Nächste

Nächste: [Kapitel 3: Erste Schritte](/03-GettingStarted/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Originalsprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.