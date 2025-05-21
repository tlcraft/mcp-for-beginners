<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:49:21+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "de"
}
-->
# Security Best Practices

Die Einführung des Model Context Protocol (MCP) bringt leistungsstarke neue Möglichkeiten für KI-gesteuerte Anwendungen mit sich, stellt aber auch einzigartige Sicherheitsherausforderungen dar, die über traditionelle Software-Risiken hinausgehen. Neben bewährten Themen wie sicherem Programmieren, dem Prinzip der minimalen Rechtevergabe und der Sicherheit der Lieferkette sehen sich MCP und KI-Workloads neuen Bedrohungen gegenüber, wie Prompt Injection, Tool Poisoning und dynamischer Werkzeugänderung. Werden diese Risiken nicht richtig gehandhabt, können sie zu Datenabfluss, Datenschutzverletzungen und unvorhergesehenem Systemverhalten führen.

Diese Lektion behandelt die relevantesten Sicherheitsrisiken im Zusammenhang mit MCP – darunter Authentifizierung, Autorisierung, übermäßige Berechtigungen, indirekte Prompt Injection und Schwachstellen in der Lieferkette – und bietet umsetzbare Maßnahmen und Best Practices zur Risikominderung. Außerdem erfahren Sie, wie Sie Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security nutzen können, um Ihre MCP-Implementierung zu stärken. Durch das Verständnis und die Anwendung dieser Kontrollen können Sie die Wahrscheinlichkeit von Sicherheitsverletzungen deutlich verringern und sicherstellen, dass Ihre KI-Systeme robust und vertrauenswürdig bleiben.

# Learning Objectives

Am Ende dieser Lektion werden Sie in der Lage sein:

- Die einzigartigen Sicherheitsrisiken des Model Context Protocol (MCP) zu erkennen und zu erklären, darunter Prompt Injection, Tool Poisoning, übermäßige Berechtigungen und Schwachstellen in der Lieferkette.
- Effektive Maßnahmen zur Minderung von MCP-Sicherheitsrisiken zu beschreiben und anzuwenden, wie robuste Authentifizierung, minimale Rechtevergabe, sicheres Token-Management und Überprüfung der Lieferkette.
- Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security zu verstehen und einzusetzen, um MCP und KI-Workloads zu schützen.
- Die Bedeutung der Validierung von Tool-Metadaten, der Überwachung dynamischer Änderungen und der Abwehr indirekter Prompt Injection-Angriffe zu erkennen.
- Bewährte Sicherheitspraktiken – wie sicheres Programmieren, Server-Härtung und Zero-Trust-Architektur – in Ihre MCP-Implementierung zu integrieren, um die Wahrscheinlichkeit und Auswirkungen von Sicherheitsverletzungen zu reduzieren.

# MCP security controls

Jedes System mit Zugriff auf wichtige Ressourcen bringt implizite Sicherheitsherausforderungen mit sich. Diese können in der Regel durch die korrekte Anwendung grundlegender Sicherheitskontrollen und -konzepte adressiert werden. Da MCP jedoch erst neu definiert wurde, ändert sich die Spezifikation sehr schnell und entwickelt sich mit dem Protokoll weiter. Mit der Zeit werden die darin enthaltenen Sicherheitskontrollen ausgereifter, was eine bessere Integration in Unternehmens- und etablierte Sicherheitsarchitekturen sowie Best Practices ermöglicht.

Die im [Microsoft Digital Defense Report](https://aka.ms/mddr) veröffentlichte Forschung zeigt, dass 98 % der gemeldeten Sicherheitsverletzungen durch robuste Sicherheits-Hygiene verhindert werden könnten. Der beste Schutz vor jeglicher Art von Sicherheitsvorfall ist es, die grundlegende Sicherheits-Hygiene, sichere Programmierpraktiken und Lieferkettensicherheit richtig umzusetzen – diese bewährten Praktiken haben nach wie vor den größten Einfluss auf die Reduzierung von Sicherheitsrisiken.

Schauen wir uns einige Möglichkeiten an, wie Sie Sicherheitsrisiken bei der Einführung von MCP angehen können.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Die folgenden Informationen sind Stand 26. April 2025 korrekt. Das MCP-Protokoll entwickelt sich ständig weiter, und zukünftige Implementierungen können neue Authentifizierungsmuster und Kontrollen einführen. Für die neuesten Updates und Anleitungen konsultieren Sie stets die [MCP Specification](https://spec.modelcontextprotocol.io/) und das offizielle [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problemstellung  
Die ursprüngliche MCP-Spezifikation ging davon aus, dass Entwickler ihren eigenen Authentifizierungsserver schreiben würden. Dies erforderte Kenntnisse zu OAuth und damit verbundenen Sicherheitsanforderungen. MCP-Server fungierten als OAuth 2.0 Authorization Server und verwalteten die erforderliche Benutzerauthentifizierung direkt, anstatt sie an einen externen Dienst wie Microsoft Entra ID zu delegieren. Ab dem 26. April 2025 erlaubt ein Update der MCP-Spezifikation, dass MCP-Server die Benutzerauthentifizierung an einen externen Dienst auslagern können.

### Risiken  
- Falsch konfigurierte Autorisierungslogik im MCP-Server kann zur Offenlegung sensibler Daten und falsch angewandten Zugriffskontrollen führen.  
- Diebstahl von OAuth-Tokens auf dem lokalen MCP-Server. Wenn ein Token gestohlen wird, kann es verwendet werden, um den MCP-Server zu imitieren und auf Ressourcen und Daten des Dienstes zuzugreifen, für den das OAuth-Token gilt.

### Maßnahmen zur Risikominderung  
- **Autorisierungslogik überprüfen und härten:** Prüfen Sie sorgfältig die Implementierung der Autorisierung Ihres MCP-Servers, um sicherzustellen, dass nur beabsichtigte Benutzer und Clients Zugriff auf sensible Ressourcen haben. Für praktische Anleitungen siehe [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) und [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).  
- **Sichere Token-Praktiken durchsetzen:** Befolgen Sie [Microsofts Best Practices für Token-Validierung und Lebensdauer](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), um Missbrauch von Zugriffstoken zu verhindern und das Risiko von Token-Wiederholungen oder Diebstahl zu reduzieren.  
- **Token-Speicherung schützen:** Speichern Sie Tokens stets sicher und verwenden Sie Verschlüsselung zum Schutz während der Speicherung und Übertragung. Tipps zur Umsetzung finden Sie unter [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problemstellung  
MCP-Server könnten mit zu umfangreichen Berechtigungen für den Dienst oder die Ressource ausgestattet sein, auf die sie zugreifen. Beispielsweise sollte ein MCP-Server, der Teil einer KI-Verkaufsanwendung ist und auf einen Unternehmensdatenspeicher zugreift, nur Zugriff auf Verkaufsdaten haben und nicht auf alle Dateien im Speicher. Das Prinzip der minimalen Rechtevergabe (eines der ältesten Sicherheitsprinzipien) besagt, dass keine Ressource mehr Berechtigungen erhalten sollte, als für die Ausführung der vorgesehenen Aufgaben notwendig sind. KI stellt in diesem Bereich eine besondere Herausforderung dar, da ihre Flexibilität es erschwert, die genauen benötigten Berechtigungen festzulegen.

### Risiken  
- Übermäßige Berechtigungen können es ermöglichen, Daten abzuziehen oder zu verändern, auf die der MCP-Server eigentlich keinen Zugriff haben sollte. Dies kann auch ein Datenschutzproblem darstellen, insbesondere wenn es sich um personenbezogene Daten (PII) handelt.

### Maßnahmen zur Risikominderung  
- **Prinzip der minimalen Rechtevergabe anwenden:** Gewähren Sie dem MCP-Server nur die minimal notwendigen Berechtigungen, um seine Aufgaben auszuführen. Überprüfen und aktualisieren Sie diese Berechtigungen regelmäßig, um sicherzustellen, dass sie nicht über das erforderliche Maß hinausgehen. Für detaillierte Anleitungen siehe [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).  
- **Rollenbasierte Zugriffskontrolle (RBAC) nutzen:** Weisen Sie dem MCP-Server Rollen zu, die eng auf spezifische Ressourcen und Aktionen beschränkt sind, und vermeiden Sie weitreichende oder unnötige Berechtigungen.  
- **Berechtigungen überwachen und prüfen:** Überwachen Sie kontinuierlich die Nutzung von Berechtigungen und führen Sie Zugriffsprotokollprüfungen durch, um übermäßige oder ungenutzte Rechte schnell zu erkennen und zu beheben.

# Indirect prompt injection attacks

### Problemstellung

Böswillige oder kompromittierte MCP-Server können erhebliche Risiken bergen, indem sie Kundendaten offenlegen oder unbeabsichtigte Aktionen ermöglichen. Diese Risiken sind besonders relevant bei KI- und MCP-basierten Workloads, wo:

- **Prompt Injection Angriffe:** Angreifer betten bösartige Anweisungen in Prompts oder externe Inhalte ein, die das KI-System dazu bringen, unbeabsichtigte Aktionen auszuführen oder sensible Daten preiszugeben. Mehr dazu: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Tool Poisoning:** Angreifer manipulieren Tool-Metadaten (wie Beschreibungen oder Parameter), um das Verhalten der KI zu beeinflussen, Sicherheitskontrollen zu umgehen oder Daten abzufließen. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Cross-Domain Prompt Injection:** Bösartige Anweisungen werden in Dokumenten, Webseiten oder E-Mails versteckt, die dann von der KI verarbeitet werden, was zu Datenlecks oder Manipulation führt.  
- **Dynamische Werkzeugänderung (Rug Pulls):** Tool-Definitionen können nach Nutzerfreigabe verändert werden, wodurch neue bösartige Verhaltensweisen eingeführt werden, ohne dass der Nutzer es bemerkt.

Diese Schwachstellen machen eine robuste Validierung, Überwachung und Sicherheitskontrollen bei der Integration von MCP-Servern und Tools in Ihre Umgebung notwendig. Für eine tiefere Auseinandersetzung siehe die oben verlinkten Quellen.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.de.png)

**Indirect Prompt Injection** (auch bekannt als Cross-Domain Prompt Injection oder XPIA) ist eine kritische Schwachstelle in generativen KI-Systemen, einschließlich solcher, die das Model Context Protocol (MCP) verwenden. Bei diesem Angriff werden bösartige Anweisungen in externen Inhalten – wie Dokumenten, Webseiten oder E-Mails – versteckt. Wenn das KI-System diese Inhalte verarbeitet, interpretiert es die eingebetteten Anweisungen als legitime Benutzerbefehle, was zu unbeabsichtigten Aktionen wie Datenlecks, Erzeugung schädlicher Inhalte oder Manipulation von Benutzerinteraktionen führt. Für eine ausführliche Erklärung und Praxisbeispiele siehe [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Eine besonders gefährliche Form dieses Angriffs ist **Tool Poisoning**. Dabei injizieren Angreifer bösartige Anweisungen in die Metadaten von MCP-Tools (z. B. Tool-Beschreibungen oder Parameter). Da große Sprachmodelle (LLMs) diese Metadaten nutzen, um zu entscheiden, welche Tools aufgerufen werden, können manipulierte Beschreibungen das Modell dazu verleiten, unautorisierte Tool-Aufrufe auszuführen oder Sicherheitskontrollen zu umgehen. Diese Manipulationen sind für Endnutzer oft unsichtbar, können aber vom KI-System interpretiert und ausgeführt werden. Dieses Risiko ist in gehosteten MCP-Server-Umgebungen besonders hoch, wo Tool-Definitionen nach Nutzerfreigabe geändert werden können – ein Szenario, das manchmal als "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" bezeichnet wird. In solchen Fällen kann ein zuvor sicheres Tool später so verändert werden, dass es bösartige Aktionen ausführt, wie Datenabfluss oder Verhaltensänderungen im System, ohne dass der Nutzer davon Kenntnis hat. Mehr zu diesem Angriffsvektor unter [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.de.png)

## Risiken  
Unbeabsichtigte KI-Aktionen bergen vielfältige Sicherheitsrisiken, darunter Datenabfluss und Datenschutzverletzungen.

### Maßnahmen zur Risikominderung  
### Einsatz von Prompt Shields zum Schutz vor indirekten Prompt Injection-Angriffen
-----------------------------------------------------------------------------

**AI Prompt Shields** sind eine von Microsoft entwickelte Lösung, um sowohl direkte als auch indirekte Prompt Injection-Angriffe abzuwehren. Sie unterstützen durch:

1.  **Erkennung und Filterung:** Prompt Shields verwenden fortgeschrittene Machine-Learning-Algorithmen und natürliche Sprachverarbeitung, um bösartige Anweisungen in externen Inhalten wie Dokumenten, Webseiten oder E-Mails zu erkennen und herauszufiltern.  
2.  **Spotlighting:** Diese Technik hilft dem KI-System, zwischen gültigen Systemanweisungen und potenziell unzuverlässigen externen Eingaben zu unterscheiden. Durch die Transformation des Eingabetexts wird dessen Relevanz für das Modell erhöht, sodass das KI-System bösartige Anweisungen besser identifizieren und ignorieren kann.  
3.  **Begrenzer und Datenmarkierung:** Die Verwendung von Begrenzerzeichen in der Systemnachricht macht explizit die Position des Eingabetexts kenntlich, wodurch das KI-System Benutzerinputs von potenziell schädlichen externen Inhalten unterscheiden kann. Datamarking erweitert dieses Konzept durch spezielle Marker, die die Grenzen von vertrauenswürdigen und nicht vertrauenswürdigen Daten hervorheben.  
4.  **Kontinuierliche Überwachung und Updates:** Microsoft überwacht und aktualisiert Prompt Shields fortlaufend, um auf neue und sich entwickelnde Bedrohungen zu reagieren. Dieser proaktive Ansatz sorgt dafür, dass der Schutz gegen die neuesten Angriffstechniken wirksam bleibt.  
5. **Integration mit Azure Content Safety:** Prompt Shields sind Teil der umfassenderen Azure AI Content Safety Suite, die zusätzliche Werkzeuge zur Erkennung von Jailbreak-Versuchen, schädlichen Inhalten und anderen Sicherheitsrisiken in KI-Anwendungen bereitstellt.

Weitere Informationen zu AI Prompt Shields finden Sie in der [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.de.png)

### Supply chain security

Die Sicherheit der Lieferkette bleibt im KI-Zeitalter grundlegend, aber der Umfang dessen, was als Lieferkette gilt, hat sich erweitert. Neben traditionellen Code-Paketen müssen Sie jetzt alle KI-bezogenen Komponenten rigoros prüfen und überwachen, einschließlich Foundation Models, Embeddings-Dienste, Kontextanbieter und Drittanbieter-APIs. Jede dieser Komponenten kann Schwachstellen oder Risiken einführen, wenn sie nicht richtig verwaltet wird.

**Wichtige Praktiken für die Sicherheit der KI- und MCP-Lieferkette:**  
- **Alle Komponenten vor der Integration überprüfen:** Dazu gehören nicht nur Open-Source-Bibliotheken, sondern auch KI-Modelle, Datenquellen und externe APIs. Prüfen Sie stets Herkunft, Lizenzierung und bekannte Schwachstellen.  
- **Sichere Bereitstellungspipelines aufrechterhalten:** Nutzen Sie automatisierte CI/CD-Pipelines mit integrierter Sicherheitsüberprüfung, um Probleme frühzeitig zu erkennen. Stellen Sie sicher, dass nur vertrauenswürdige Artefakte in die Produktion gelangen.  
- **Kontinuierlich überwachen und prüfen:** Implementieren Sie eine fortlaufende Überwachung aller Abhängigkeiten, einschließlich Modelle und Datenservices, um neue Schwachstellen oder Angriffe auf die Lieferkette zu erkennen.  
- **Prinzip der minimalen Rechtevergabe und Zugriffskontrollen anwenden:** Beschränken Sie den Zugriff auf Modelle, Daten und Dienste auf das unbedingt notwendige Maß für den Betrieb Ihres MCP-Servers.  
- **Schnell auf Bedrohungen reagieren:** Etablieren Sie Prozesse zum Patchen oder Ersetzen kompromittierter Komponenten und zum Rotieren von Geheimnissen oder Zugangsdaten, falls eine Sicherheitsverletzung festgestellt wird.

[GitHub Advanced Security](https://github.com/security/advanced-security) bietet Funktionen wie Secret Scanning, Dependency Scanning und CodeQL-Analyse. Diese Tools integrieren sich mit [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) und [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), um Teams bei der Identifizierung und Minderung von Schwachstellen sowohl im Code als auch in KI-Lieferkettenkomponenten zu unterstützen.

Microsoft setzt auch intern umfassende Sicherheitspraktiken für die Lieferkette aller Produkte um. Mehr dazu unter [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Jede MCP-Implementierung übernimmt die bestehende Sicherheitslage der Umgebung Ihrer Organisation, auf der sie aufbaut. Daher wird empfohlen, beim Betrachten der Sicherheit von MCP als Bestandteil Ihrer gesamten KI-Systeme Ihre gesamte bestehende Sicherheitslage zu verbessern. Die folgenden etablierten Sicherheitskontrollen sind dabei besonders relevant:

- Sichere Programmierpraktiken in Ihrer KI-Anwendung – Schutz gegen [die OWASP Top 10](https://owasp.org/www-project-top-ten/), die [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), Verwendung sicherer Tresore für Geheimnisse und Tokens, Implementierung durchgängiger sicherer Kommunikation zwischen allen Anwendungskomponenten usw.  
- Server-Härtung – Einsatz von MFA, wo möglich, regelmäßiges Patchen, Integration des Servers mit einem Drittanbieter-Identitätsanbieter für den Zugriff usw.  
- Geräte, Infrastruktur und Anwendungen stets mit aktuellen Patches versorgen  
- Sicherheitsüberwachung – Implementierung von Logging und Monitoring einer KI-Anwendung (einschließlich MCP-Client/Server) und Weiterleitung der Protokolle an ein zentrales SIEM zur Erkennung anomaler Aktivitäten  
- Zero-Trust-Architektur – logische Isolierung von Komponenten durch Netzwerk- und Identitätskontrollen, um laterale Bewegungen im Falle einer Kompromittierung der KI-Anwendung zu minimieren.

# Key Takeaways

- Sicherheitsgrundlagen bleiben entscheidend: Sicheres Programmieren, minimale Rechtevergabe, Überprüfung der Lieferkette und kontinuierliche Überwachung sind essenziell für MCP und KI-Workloads.  
- MCP bringt neue Risiken mit sich – wie Prompt Injection, Tool Poisoning und übermäßige Berechtigungen –, die sowohl traditionelle als auch KI-spezifische Kontrollen erfordern.  
- Nutzen Sie robuste Authentifizierungs-, Autorisierungs- und Token-Management-Praktiken und setzen Sie, wo möglich, externe Identitätsanbieter wie Microsoft Entra ID ein.  
- Schützen Sie vor indirekter Prompt Injection und Tool Poisoning, indem Sie Tool-Metadaten validieren, dynamische Änderungen überwachen und Lösungen wie Microsoft Prompt Shields verwenden.  
- Behandeln Sie alle Komponenten Ihrer KI-Lieferkette –
- [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Die Reise zur Sicherung der Software-Lieferkette bei Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sicheren Least-Privileged Access verwenden (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices für Token-Validierung und Lebensdauer](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sichere Token-Speicherung verwenden und Tokens verschlüsseln (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management als Auth-Gateway für MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID zur Authentifizierung mit MCP-Servern verwenden](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Nächstes

Nächstes: [Kapitel 3: Erste Schritte](/03-GettingStarted/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.