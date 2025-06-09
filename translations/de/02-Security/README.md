<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T22:58:23+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "de"
}
-->
# Security Best Practices

Die Einführung des Model Context Protocol (MCP) bringt leistungsstarke neue Möglichkeiten für KI-gesteuerte Anwendungen mit sich, stellt aber auch einzigartige Sicherheitsherausforderungen dar, die über traditionelle Softwarerisiken hinausgehen. Neben etablierten Aspekten wie sicherer Programmierung, dem Prinzip der geringsten Privilegien und der Sicherheit der Lieferkette sind MCP und KI-Workloads neuen Bedrohungen wie Prompt Injection, Tool Poisoning und dynamischer Werkzeugmodifikation ausgesetzt. Werden diese Risiken nicht richtig gehandhabt, können sie zu Datenabfluss, Datenschutzverletzungen und unerwartetem Systemverhalten führen.

Diese Lektion behandelt die wichtigsten Sicherheitsrisiken im Zusammenhang mit MCP – darunter Authentifizierung, Autorisierung, übermäßige Berechtigungen, indirekte Prompt Injection und Schwachstellen in der Lieferkette – und bietet praktische Maßnahmen und Best Practices zu deren Minderung. Außerdem lernen Sie, wie Sie Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security nutzen können, um Ihre MCP-Implementierung zu stärken. Durch das Verständnis und die Anwendung dieser Maßnahmen können Sie die Wahrscheinlichkeit eines Sicherheitsvorfalls deutlich reduzieren und sicherstellen, dass Ihre KI-Systeme robust und vertrauenswürdig bleiben.

# Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Die einzigartigen Sicherheitsrisiken, die durch das Model Context Protocol (MCP) entstehen, zu erkennen und zu erklären, einschließlich Prompt Injection, Tool Poisoning, übermäßigen Berechtigungen und Schwachstellen in der Lieferkette.
- Effektive Gegenmaßnahmen für MCP-Sicherheitsrisiken zu beschreiben und anzuwenden, wie robuste Authentifizierung, Prinzip der geringsten Privilegien, sicheres Token-Management und Überprüfung der Lieferkette.
- Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security zu verstehen und zu nutzen, um MCP- und KI-Workloads zu schützen.
- Die Bedeutung der Validierung von Tool-Metadaten, der Überwachung dynamischer Änderungen und der Abwehr indirekter Prompt Injection-Angriffe zu erkennen.
- Bewährte Sicherheitspraktiken wie sichere Programmierung, Server-Härtung und Zero-Trust-Architektur in Ihre MCP-Implementierung zu integrieren, um die Wahrscheinlichkeit und Auswirkungen von Sicherheitsverletzungen zu verringern.

# MCP-Sicherheitskontrollen

Jedes System mit Zugriff auf wichtige Ressourcen bringt implizite Sicherheitsherausforderungen mit sich. Diese Herausforderungen lassen sich in der Regel durch die korrekte Anwendung grundlegender Sicherheitskontrollen und -konzepte bewältigen. Da MCP jedoch erst neu definiert ist, verändert sich die Spezifikation sehr schnell und entwickelt sich weiter. Mit der Zeit werden die Sicherheitskontrollen reifen und eine bessere Integration mit Unternehmens- und etablierten Sicherheitsarchitekturen und Best Practices ermöglichen.

Forschungen im [Microsoft Digital Defense Report](https://aka.ms/mddr) zeigen, dass 98 % der gemeldeten Sicherheitsverletzungen durch robuste Sicherheits-Hygiene verhindert werden könnten. Der beste Schutz vor jeglicher Art von Sicherheitsvorfall ist, die Basis-Sicherheits-Hygiene, sichere Programmierpraktiken und Lieferkettensicherheit richtig umzusetzen – bewährte Praktiken, die nach wie vor den größten Einfluss auf die Reduzierung von Sicherheitsrisiken haben.

Schauen wir uns einige Möglichkeiten an, wie Sie Sicherheitsrisiken bei der Einführung von MCP angehen können.

> **Note:** Die folgenden Informationen sind korrekt zum **29. Mai 2025**. Das MCP-Protokoll entwickelt sich ständig weiter, und zukünftige Implementierungen können neue Authentifizierungsmuster und Kontrollen einführen. Für die neuesten Updates und Anleitungen konsultieren Sie stets die [MCP Specification](https://spec.modelcontextprotocol.io/) sowie das offizielle [MCP GitHub repository](https://github.com/modelcontextprotocol) und die [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstellung  
Die ursprüngliche MCP-Spezifikation ging davon aus, dass Entwickler ihren eigenen Authentifizierungsserver schreiben würden. Dies erforderte Kenntnisse über OAuth und damit verbundene Sicherheitsanforderungen. MCP-Server fungierten als OAuth 2.0 Authorization Server, die die erforderliche Benutzer-Authentifizierung direkt verwalteten, anstatt diese an einen externen Dienst wie Microsoft Entra ID zu delegieren. Ab dem **26. April 2025** erlaubt ein Update der MCP-Spezifikation, dass MCP-Server die Benutzer-Authentifizierung an einen externen Dienst delegieren können.

### Risiken
- Falsch konfigurierte Autorisierungslogik im MCP-Server kann zu einer Offenlegung sensibler Daten und falsch angewendeten Zugriffskontrollen führen.
- Diebstahl von OAuth-Tokens auf dem lokalen MCP-Server. Wenn ein Token gestohlen wird, kann es verwendet werden, um den MCP-Server zu imitieren und auf Ressourcen und Daten des Dienstes zuzugreifen, für den das OAuth-Token gilt.

#### Token Passthrough
Token Passthrough ist in der Autorisierungsspezifikation ausdrücklich verboten, da es eine Reihe von Sicherheitsrisiken mit sich bringt, darunter:

#### Umgehung von Sicherheitskontrollen
Der MCP-Server oder nachgelagerte APIs könnten wichtige Sicherheitskontrollen wie Ratenbegrenzung, Anforderungsvalidierung oder Verkehrsüberwachung implementieren, die vom Token-Publikum oder anderen Credential-Beschränkungen abhängen. Wenn Clients Tokens direkt bei den nachgelagerten APIs verwenden können, ohne dass der MCP-Server diese ordnungsgemäß validiert oder sicherstellt, dass die Tokens für den richtigen Dienst ausgestellt wurden, umgehen sie diese Kontrollen.

#### Probleme bei Verantwortlichkeit und Audit-Trails
Der MCP-Server kann MCP-Clients nicht identifizieren oder unterscheiden, wenn Clients mit einem vom Upstream ausgestellten Zugriffstoken anrufen, das für den MCP-Server möglicherweise undurchsichtig ist.
Die Protokolle des nachgelagerten Resource Servers können Anfragen zeigen, die scheinbar von einer anderen Quelle mit einer anderen Identität stammen, anstatt vom MCP-Server, der die Tokens tatsächlich weiterleitet.
Beide Faktoren erschweren die Untersuchung von Vorfällen, die Kontrolle und das Auditieren.
Wenn der MCP-Server Tokens weitergibt, ohne deren Claims (z. B. Rollen, Berechtigungen oder Publikum) oder andere Metadaten zu validieren, kann ein Angreifer mit einem gestohlenen Token den Server als Proxy für Datenabfluss nutzen.

#### Vertrauensgrenzen-Probleme
Der nachgelagerte Resource Server gewährt Vertrauen zu bestimmten Entitäten. Dieses Vertrauen kann Annahmen über Herkunft oder Verhaltensmuster des Clients beinhalten. Das Brechen dieser Vertrauensgrenze kann zu unerwarteten Problemen führen.
Wenn das Token von mehreren Diensten ohne ordnungsgemäße Validierung akzeptiert wird, kann ein Angreifer, der einen Dienst kompromittiert, das Token verwenden, um auf andere verbundene Dienste zuzugreifen.

#### Risiko der zukünftigen Kompatibilität
Auch wenn ein MCP-Server heute als „reiner Proxy“ startet, muss er möglicherweise später Sicherheitskontrollen hinzufügen. Die Trennung des Token-Publikums von Anfang an erleichtert die Weiterentwicklung des Sicherheitsmodells.

### Gegenmaßnahmen

**MCP-Server DÜRFEN KEINE Tokens akzeptieren, die nicht ausdrücklich für den MCP-Server ausgestellt wurden**

- **Autorisierungslogik überprüfen und härten:** Prüfen Sie sorgfältig die Autorisierungsimplementierung Ihres MCP-Servers, um sicherzustellen, dass nur die vorgesehenen Benutzer und Clients Zugriff auf sensible Ressourcen haben. Praktische Anleitungen finden Sie unter [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) und [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Sichere Token-Praktiken durchsetzen:** Befolgen Sie [Microsofts Best Practices zur Token-Validierung und Lebensdauer](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), um Missbrauch von Zugriffstokens zu verhindern und das Risiko von Token-Wiederholungen oder Diebstahl zu reduzieren.
- **Token-Speicherung schützen:** Speichern Sie Tokens immer sicher und verwenden Sie Verschlüsselung, um sie im Ruhezustand und bei der Übertragung zu schützen. Tipps zur Umsetzung finden Sie unter [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Übermäßige Berechtigungen für MCP-Server

### Problemstellung
MCP-Server könnten übermäßige Berechtigungen für den Dienst oder die Ressource erhalten haben, auf die sie zugreifen. Beispielsweise sollte ein MCP-Server, der Teil einer KI-Verkaufsanwendung ist und auf einen Unternehmensdatenspeicher zugreift, nur Zugriff auf Verkaufsdaten haben und nicht auf alle Dateien im Speicher. Das Prinzip der geringsten Privilegien (eine der ältesten Sicherheitsgrundsätze) besagt, dass keine Ressource Berechtigungen über das hinaus haben sollte, was für die Ausführung der vorgesehenen Aufgaben notwendig ist. KI stellt hier eine besondere Herausforderung dar, da ihre Flexibilität es erschwert, die exakt erforderlichen Berechtigungen zu definieren.

### Risiken  
- Die Gewährung übermäßiger Berechtigungen kann zu Datenabfluss oder Änderungen an Daten führen, auf die der MCP-Server eigentlich keinen Zugriff haben sollte. Dies kann auch ein Datenschutzproblem sein, wenn es sich um personenbezogene Daten (PII) handelt.

### Gegenmaßnahmen
- **Prinzip der geringsten Privilegien anwenden:** Gewähren Sie dem MCP-Server nur die minimal notwendigen Berechtigungen, um seine Aufgaben auszuführen. Überprüfen und aktualisieren Sie diese Berechtigungen regelmäßig, um sicherzustellen, dass sie nicht über das erforderliche Maß hinausgehen. Ausführliche Anleitungen finden Sie unter [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Rollenbasierte Zugriffskontrolle (RBAC) nutzen:** Weisen Sie dem MCP-Server Rollen zu, die eng auf bestimmte Ressourcen und Aktionen beschränkt sind, und vermeiden Sie breite oder unnötige Berechtigungen.
- **Berechtigungen überwachen und auditieren:** Überwachen Sie kontinuierlich die Nutzung von Berechtigungen und prüfen Sie Zugriffprotokolle, um übermäßige oder ungenutzte Privilegien schnell zu erkennen und zu beheben.

# Indirekte Prompt Injection-Angriffe

### Problemstellung

Bösartige oder kompromittierte MCP-Server können erhebliche Risiken bergen, indem sie Kundendaten preisgeben oder unbeabsichtigte Aktionen ermöglichen. Diese Risiken sind besonders relevant bei KI- und MCP-basierten Workloads, wo:

- **Prompt Injection Angriffe**: Angreifer betten bösartige Anweisungen in Prompts oder externe Inhalte ein, wodurch das KI-System unbeabsichtigte Aktionen ausführt oder sensible Daten preisgibt. Mehr dazu: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Angreifer manipulieren Tool-Metadaten (wie Beschreibungen oder Parameter), um das Verhalten der KI zu beeinflussen, Sicherheitskontrollen zu umgehen oder Daten abzuziehen. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Bösartige Anweisungen werden in Dokumente, Webseiten oder E-Mails eingebettet, die dann von der KI verarbeitet werden, was zu Datenlecks oder Manipulationen führt.
- **Dynamische Werkzeugmodifikation (Rug Pulls)**: Tool-Definitionen können nach der Benutzerfreigabe geändert werden, wodurch neue bösartige Verhaltensweisen ohne Wissen des Benutzers eingeführt werden.

Diese Schwachstellen unterstreichen die Notwendigkeit robuster Validierung, Überwachung und Sicherheitskontrollen beim Einbinden von MCP-Servern und Tools in Ihre Umgebung. Für eine vertiefte Betrachtung siehe die oben verlinkten Quellen.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.de.png)

**Indirekte Prompt Injection** (auch bekannt als Cross-Domain Prompt Injection oder XPIA) ist eine kritische Schwachstelle in generativen KI-Systemen, einschließlich solcher, die das Model Context Protocol (MCP) verwenden. Bei diesem Angriff werden bösartige Anweisungen in externen Inhalten – wie Dokumenten, Webseiten oder E-Mails – versteckt. Wenn das KI-System diese Inhalte verarbeitet, interpretiert es die eingebetteten Anweisungen möglicherweise als legitime Benutzerbefehle, was zu unbeabsichtigten Aktionen wie Datenlecks, der Erzeugung schädlicher Inhalte oder der Manipulation von Benutzerinteraktionen führt. Eine ausführliche Erklärung und Beispiele finden Sie unter [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Eine besonders gefährliche Form dieses Angriffs ist das **Tool Poisoning**. Hierbei injizieren Angreifer bösartige Anweisungen in die Metadaten von MCP-Tools (wie Tool-Beschreibungen oder Parameter). Da große Sprachmodelle (LLMs) diese Metadaten nutzen, um zu entscheiden, welche Tools sie aufrufen, können kompromittierte Beschreibungen das Modell dazu verleiten, unautorisierte Tool-Aufrufe auszuführen oder Sicherheitskontrollen zu umgehen. Diese Manipulationen sind für Endbenutzer oft unsichtbar, werden jedoch vom KI-System interpretiert und ausgeführt. Dieses Risiko ist besonders hoch in gehosteten MCP-Server-Umgebungen, in denen Tool-Definitionen nach Benutzerfreigabe geändert werden können – ein Szenario, das manchmal als "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" bezeichnet wird. In solchen Fällen kann ein zuvor sicheres Tool später modifiziert werden, um bösartige Aktionen wie Datenabfluss oder Verhaltensänderungen des Systems ohne Wissen des Benutzers auszuführen. Weitere Informationen zu diesem Angriffsvektor finden Sie unter [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.de.png)

## Risiken
Unbeabsichtigte KI-Aktionen bergen verschiedene Sicherheitsrisiken, darunter Datenabfluss und Datenschutzverletzungen.

### Gegenmaßnahmen
### Einsatz von Prompt Shields zum Schutz vor indirekten Prompt Injection-Angriffen
-----------------------------------------------------------------------------

**AI Prompt Shields** sind eine von Microsoft entwickelte Lösung, um sowohl direkte als auch indirekte Prompt Injection-Angriffe abzuwehren. Sie unterstützen durch:

1.  **Erkennung und Filterung:** Prompt Shields nutzen fortschrittliche Machine-Learning-Algorithmen und natürliche Sprachverarbeitung, um bösartige Anweisungen in externen Inhalten wie Dokumenten, Webseiten oder E-Mails zu erkennen und herauszufiltern.
    
2.  **Spotlighting:** Diese Technik hilft dem KI-System, zwischen gültigen Systemanweisungen und potenziell unzuverlässigen externen Eingaben zu unterscheiden. Durch die Transformation des Eingabetextes, sodass er für das Modell relevanter wird, sorgt Spotlighting dafür, dass die KI bösartige Anweisungen besser identifizieren und ignorieren kann.
    
3.  **Begrenzer und Datamarking:** Das Einfügen von Begrenzerzeichen in die Systemnachricht zeigt explizit die Position des Eingabetextes an und hilft der KI, Benutzereingaben von potenziell schädlichen externen Inhalten zu trennen. Datamarking erweitert dieses Konzept durch spezielle Marker, die die Grenzen zwischen vertrauenswürdigen und nicht vertrauenswürdigen Daten hervorheben.
    
4.  **Kontinuierliche Überwachung und Updates:** Microsoft überwacht und aktualisiert Prompt Shields kontinuierlich, um neuen und sich entwickelnden Bedrohungen zu begegnen. Dieser proaktive Ansatz stellt sicher, dass der Schutz gegen die neuesten Angriffstechniken wirksam bleibt.
    
5. **Integration mit Azure Content Safety:** Prompt Shields sind Teil der umfassenderen Azure AI Content Safety Suite, die zusätzliche Werkzeuge zur Erkennung von Jailbreak-Versuchen, schädlichen Inhalten und anderen Sicherheitsrisiken in KI-Anwendungen bietet.

Mehr Informationen zu AI Prompt Shields finden Sie in der [Prompt Shields Dokumentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.de.png)

### Sicherheit der Lieferkette

Die Sicherheit der Lieferkette bleibt im KI-Zeitalter grundlegend, aber der Umfang dessen, was als Lieferkette gilt, hat sich erweitert. Neben traditionellen Codepaketen müssen Sie nun alle KI-bezogenen Komponenten rigoros überprüfen und überwachen, einschließlich Foundation Models, Embeddings-Services, Kontextanbieter und Drittanbieter-APIs. Jede dieser Komponenten kann Schwachstellen oder Risiken einführen, wenn sie nicht ordnungsgemäß verwaltet werden.

**Wichtige Praktiken zur Lieferkettensicherheit für KI und MCP:**
- **Alle Komponenten vor der Integration überprüfen:** Dazu gehören nicht nur Open-Source-Bibliotheken, sondern auch KI-Modelle, Datenquellen und externe APIs. Prüfen Sie stets Herkunft, Lizenzierung und bekannte Schwachstellen.
- **Sichere Deployment-Pipelines aufrechterhalten:** Nutzen Sie automatisierte CI/CD-Pipelines mit integrierten Sicherheitsscans, um Probleme frühzeitig zu erkennen. Stellen Sie sicher, dass nur vertrauenswürdige Artefakte in die Produktion gelangen.
- **Kontinuierliche Überwachung und Auditierung:** Implementieren Sie eine fortlaufende Überwachung aller Abhängigkeiten, einschließlich Modelle und Datenservices, um neue Schwachstellen oder Lieferkettenangriffe zu entdecken.
- **Prinzip der geringsten Privilegien und Zugriffskontrollen anwenden:** Beschränken Sie den Zugriff auf Modelle, Daten und Dienste auf das notwendige Minimum für den Betrieb Ihres MCP-Servers.
- **Schnelles Reagieren auf Bedrohungen:** Etablieren Sie Prozesse zum Patchen oder Ersetzen kompromittierter Komponenten sowie zur Rotation von Geheimnissen oder Zugangsdaten bei einem Sicherheitsvorfall.

[GitHub Advanced Security](https://github.com/security/advanced-security) bietet Funktionen wie Secret Scanning, Dependency Scanning und CodeQL-Analyse. Diese Tools integrieren sich mit [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) und [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), um Teams dabei zu unterstützen, Schwachstellen sowohl im Code als auch in KI-Lieferkettenkomponenten zu erkennen und zu beheben.

Microsoft setzt intern ebenfalls umfangreiche Praktiken zur Lieferkettensicherheit für alle Produkte um. Weitere Informationen finden Sie in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-sec
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Die Reise zur Sicherung der Software-Lieferkette bei Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sicherer Zugriff mit geringsten Rechten (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices für Token-Validierung und Lebensdauer](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sichere Token-Speicherung verwenden und Tokens verschlüsseln (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management als Auth-Gateway für MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Microsoft Entra ID zur Authentifizierung bei MCP-Servern verwenden](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Weiter

Weiter: [Kapitel 3: Erste Schritte](/03-GettingStarted/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.