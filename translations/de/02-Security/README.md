<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-16T22:19:06+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "de"
}
-->
# Sicherheits-Best Practices

Die Einführung des Model Context Protocol (MCP) bringt leistungsstarke neue Möglichkeiten für KI-gesteuerte Anwendungen mit sich, stellt aber auch einzigartige Sicherheitsherausforderungen dar, die über traditionelle Software-Risiken hinausgehen. Neben etablierten Themen wie sicherem Programmieren, dem Prinzip der minimalen Rechtevergabe und der Sicherheit der Lieferkette sehen sich MCP und KI-Workloads neuen Bedrohungen gegenüber, wie Prompt Injection, Tool Poisoning, dynamischer Werkzeugmodifikation, Session Hijacking, Confused Deputy-Angriffen und Token-Passthrough-Schwachstellen. Werden diese Risiken nicht richtig gehandhabt, können sie zu Datenabfluss, Datenschutzverletzungen und unerwünschtem Systemverhalten führen.

Diese Lektion behandelt die relevantesten Sicherheitsrisiken im Zusammenhang mit MCP – darunter Authentifizierung, Autorisierung, übermäßige Berechtigungen, indirekte Prompt Injection, Sitzungs-Sicherheit, Confused Deputy-Probleme, Token-Passthrough-Schwachstellen und Schwachstellen in der Lieferkette – und bietet umsetzbare Maßnahmen und Best Practices zu deren Minderung. Außerdem lernen Sie, wie Sie Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security nutzen können, um Ihre MCP-Implementierung zu stärken. Durch das Verständnis und die Anwendung dieser Maßnahmen können Sie die Wahrscheinlichkeit eines Sicherheitsvorfalls erheblich reduzieren und sicherstellen, dass Ihre KI-Systeme robust und vertrauenswürdig bleiben.

# Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Die einzigartigen Sicherheitsrisiken des Model Context Protocol (MCP) zu identifizieren und zu erklären, einschließlich Prompt Injection, Tool Poisoning, übermäßiger Berechtigungen, Session Hijacking, Confused Deputy-Problemen, Token-Passthrough-Schwachstellen und Schwachstellen in der Lieferkette.
- Effektive Gegenmaßnahmen für MCP-Sicherheitsrisiken zu beschreiben und anzuwenden, wie robuste Authentifizierung, Prinzip der minimalen Rechtevergabe, sicheres Token-Management, Sitzungs-Sicherheitskontrollen und Überprüfung der Lieferkette.
- Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security zu verstehen und zu nutzen, um MCP und KI-Workloads zu schützen.
- Die Bedeutung der Validierung von Tool-Metadaten, der Überwachung dynamischer Änderungen, der Abwehr indirekter Prompt Injection-Angriffe und der Verhinderung von Session Hijacking zu erkennen.
- Etablierte Sicherheits-Best Practices – wie sicheres Programmieren, Server-Härtung und Zero-Trust-Architektur – in Ihre MCP-Implementierung zu integrieren, um die Wahrscheinlichkeit und Auswirkungen von Sicherheitsvorfällen zu verringern.

# MCP-Sicherheitskontrollen

Jedes System, das Zugriff auf wichtige Ressourcen hat, bringt implizite Sicherheitsherausforderungen mit sich. Sicherheitsprobleme lassen sich im Allgemeinen durch die korrekte Anwendung grundlegender Sicherheitskontrollen und -konzepte bewältigen. Da MCP erst neu definiert wurde, ändert sich die Spezifikation sehr schnell und entwickelt sich weiter. Mit der Zeit werden die Sicherheitskontrollen darin ausgereifter, was eine bessere Integration in Unternehmens- und etablierte Sicherheitsarchitekturen und Best Practices ermöglicht.

Forschungen, veröffentlicht im [Microsoft Digital Defense Report](https://aka.ms/mddr), zeigen, dass 98 % der gemeldeten Sicherheitsverletzungen durch robuste Sicherheits-Hygiene verhindert werden könnten. Der beste Schutz vor jeglicher Art von Sicherheitsvorfall besteht darin, die grundlegende Sicherheits-Hygiene, sichere Programmierpraktiken und die Sicherheit der Lieferkette richtig umzusetzen – diese bewährten Praktiken haben nach wie vor den größten Einfluss auf die Reduzierung von Sicherheitsrisiken.

Schauen wir uns einige Möglichkeiten an, wie Sie Sicherheitsrisiken bei der Einführung von MCP angehen können.

> **Note:** Die folgenden Informationen sind korrekt zum **29. Mai 2025**. Das MCP-Protokoll entwickelt sich ständig weiter, und zukünftige Implementierungen können neue Authentifizierungsmuster und Kontrollen einführen. Für die neuesten Updates und Anleitungen konsultieren Sie bitte stets die [MCP-Spezifikation](https://spec.modelcontextprotocol.io/) sowie das offizielle [MCP GitHub-Repository](https://github.com/modelcontextprotocol) und die [Seite zu Sicherheits-Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstellung  
Die ursprüngliche MCP-Spezifikation ging davon aus, dass Entwickler ihren eigenen Authentifizierungsserver schreiben würden. Dies erforderte Kenntnisse über OAuth und verwandte Sicherheitsanforderungen. MCP-Server fungierten als OAuth 2.0 Authorization Server und verwalteten die erforderliche Benutzer-Authentifizierung direkt, anstatt sie an einen externen Dienst wie Microsoft Entra ID zu delegieren. Ab dem **26. April 2025** erlaubt ein Update der MCP-Spezifikation, dass MCP-Server die Benutzer-Authentifizierung an einen externen Dienst delegieren können.

### Risiken
- Fehlkonfigurierte Autorisierungslogik im MCP-Server kann zu einer Offenlegung sensibler Daten und falsch angewandten Zugriffskontrollen führen.
- Diebstahl von OAuth-Tokens auf dem lokalen MCP-Server. Wenn ein Token gestohlen wird, kann es verwendet werden, um den MCP-Server zu imitieren und auf Ressourcen und Daten des Dienstes zuzugreifen, für den das OAuth-Token ausgestellt wurde.

#### Token Passthrough  
Token Passthrough ist in der Autorisierungsspezifikation ausdrücklich verboten, da es eine Reihe von Sicherheitsrisiken mit sich bringt, darunter:

#### Umgehung von Sicherheitskontrollen  
Der MCP-Server oder nachgelagerte APIs könnten wichtige Sicherheitskontrollen wie Ratenbegrenzung, Anforderungsvalidierung oder Verkehrsüberwachung implementieren, die vom Token-Audience oder anderen Credential-Beschränkungen abhängen. Wenn Clients Tokens direkt bei den nachgelagerten APIs verwenden können, ohne dass der MCP-Server diese ordnungsgemäß validiert oder sicherstellt, dass die Tokens für den richtigen Dienst ausgestellt wurden, umgehen sie diese Kontrollen.

#### Probleme mit Verantwortlichkeit und Audit-Trail  
Der MCP-Server kann MCP-Clients nicht identifizieren oder unterscheiden, wenn Clients mit einem von oben ausgestellten Access Token aufrufen, das für den MCP-Server möglicherweise undurchsichtig ist.  
Die Protokolle des nachgelagerten Resource Servers könnten Anfragen zeigen, die scheinbar von einer anderen Quelle mit einer anderen Identität stammen, anstatt vom MCP-Server, der die Tokens tatsächlich weiterleitet.  
Beide Faktoren erschweren die Untersuchung von Vorfällen, Kontrollen und Audits.  
Wenn der MCP-Server Tokens weitergibt, ohne deren Claims (z. B. Rollen, Privilegien oder Audience) oder andere Metadaten zu validieren, kann ein Angreifer mit einem gestohlenen Token den Server als Proxy für Datenabfluss nutzen.

#### Vertrauensgrenzen-Probleme  
Der nachgelagerte Resource Server gewährt Vertrauen an bestimmte Entitäten. Dieses Vertrauen kann Annahmen über Herkunft oder Verhaltensmuster der Clients beinhalten. Das Brechen dieser Vertrauensgrenze kann zu unerwarteten Problemen führen.  
Wenn das Token von mehreren Diensten ohne ordnungsgemäße Validierung akzeptiert wird, kann ein Angreifer, der einen Dienst kompromittiert, das Token verwenden, um auf andere verbundene Dienste zuzugreifen.

#### Risiko der zukünftigen Kompatibilität  
Auch wenn ein MCP-Server heute als „reiner Proxy“ startet, könnte er später Sicherheitskontrollen hinzufügen müssen. Ein korrekter Start mit der Trennung der Token-Audience erleichtert die Weiterentwicklung des Sicherheitsmodells.

### Gegenmaßnahmen

**MCP-Server DÜRFEN KEINE Tokens akzeptieren, die nicht explizit für den MCP-Server ausgestellt wurden**

- **Autorisierungslogik überprüfen und härten:** Prüfen Sie sorgfältig die Autorisierungsimplementierung Ihres MCP-Servers, um sicherzustellen, dass nur beabsichtigte Benutzer und Clients Zugriff auf sensible Ressourcen haben. Praktische Anleitungen finden Sie unter [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) und [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Sichere Token-Praktiken durchsetzen:** Befolgen Sie [Microsofts Best Practices für Token-Validierung und Lebensdauer](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), um Missbrauch von Access Tokens zu verhindern und das Risiko von Token-Wiederholungen oder Diebstahl zu reduzieren.
- **Token-Speicherung schützen:** Speichern Sie Tokens stets sicher und verwenden Sie Verschlüsselung, um sie im Ruhezustand und während der Übertragung zu schützen. Tipps zur Umsetzung finden Sie unter [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Übermäßige Berechtigungen für MCP-Server

### Problemstellung  
MCP-Server könnten mit zu umfangreichen Berechtigungen für den Dienst oder die Ressource ausgestattet sein, auf die sie zugreifen. Beispielsweise sollte ein MCP-Server, der Teil einer KI-Verkaufsanwendung ist und auf einen Unternehmensdatenspeicher zugreift, nur Zugriff auf Verkaufsdaten haben und nicht auf alle Dateien im Speicher. Zurück zum Prinzip der minimalen Rechtevergabe (eines der ältesten Sicherheitsprinzipien): Keine Ressource sollte mehr Berechtigungen haben, als für die Ausführung der vorgesehenen Aufgaben erforderlich sind. KI stellt in diesem Bereich eine besondere Herausforderung dar, da sie flexibel sein soll und es schwierig sein kann, die genauen erforderlichen Berechtigungen zu definieren.

### Risiken  
- Übermäßige Berechtigungen können es ermöglichen, Daten abzufließen oder zu verändern, auf die der MCP-Server eigentlich keinen Zugriff haben sollte. Dies kann auch ein Datenschutzproblem darstellen, wenn es sich um personenbezogene Daten (PII) handelt.

### Gegenmaßnahmen  
- **Prinzip der minimalen Rechtevergabe anwenden:** Gewähren Sie dem MCP-Server nur die minimal notwendigen Berechtigungen, um seine Aufgaben auszuführen. Überprüfen und aktualisieren Sie diese Berechtigungen regelmäßig, um sicherzustellen, dass sie nicht über das erforderliche Maß hinausgehen. Detaillierte Anleitungen finden Sie unter [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Rollenbasierte Zugriffskontrolle (RBAC) verwenden:** Weisen Sie dem MCP-Server Rollen zu, die eng auf bestimmte Ressourcen und Aktionen beschränkt sind, und vermeiden Sie breite oder unnötige Berechtigungen.
- **Berechtigungen überwachen und auditieren:** Überwachen Sie kontinuierlich die Nutzung von Berechtigungen und prüfen Sie Zugriffsprotokolle, um übermäßige oder ungenutzte Rechte schnell zu erkennen und zu beheben.

# Indirekte Prompt Injection-Angriffe

### Problemstellung

Bösartige oder kompromittierte MCP-Server können erhebliche Risiken bergen, indem sie Kundendaten offenlegen oder unbeabsichtigte Aktionen ermöglichen. Diese Risiken sind besonders relevant bei KI- und MCP-basierten Workloads, bei denen:

- **Prompt Injection-Angriffe:** Angreifer binden bösartige Anweisungen in Prompts oder externe Inhalte ein, wodurch das KI-System unbeabsichtigte Aktionen ausführt oder sensible Daten preisgibt. Mehr dazu: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Angreifer manipulieren Tool-Metadaten (wie Beschreibungen oder Parameter), um das Verhalten der KI zu beeinflussen, Sicherheitskontrollen zu umgehen oder Daten abzufließen. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Bösartige Anweisungen werden in Dokumente, Webseiten oder E-Mails eingebettet, die dann von der KI verarbeitet werden, was zu Datenlecks oder Manipulationen führt.
- **Dynamische Werkzeugmodifikation (Rug Pulls):** Tool-Definitionen können nach der Benutzerfreigabe geändert werden, wodurch neue bösartige Verhaltensweisen ohne Wissen des Nutzers eingeführt werden.

Diese Schwachstellen unterstreichen die Notwendigkeit robuster Validierung, Überwachung und Sicherheitskontrollen bei der Integration von MCP-Servern und Tools in Ihre Umgebung. Für eine vertiefte Betrachtung siehe die oben verlinkten Quellen.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.de.png)

**Indirekte Prompt Injection** (auch bekannt als Cross-Domain Prompt Injection oder XPIA) ist eine kritische Schwachstelle in generativen KI-Systemen, einschließlich solcher, die das Model Context Protocol (MCP) verwenden. Bei diesem Angriff werden bösartige Anweisungen in externen Inhalten – wie Dokumenten, Webseiten oder E-Mails – versteckt. Wenn das KI-System diese Inhalte verarbeitet, interpretiert es die eingebetteten Anweisungen möglicherweise als legitime Benutzerbefehle, was zu unbeabsichtigten Aktionen wie Datenlecks, der Erzeugung schädlicher Inhalte oder der Manipulation von Benutzerinteraktionen führt. Für eine ausführliche Erklärung und Beispiele aus der Praxis siehe [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Eine besonders gefährliche Form dieses Angriffs ist **Tool Poisoning**. Hierbei injizieren Angreifer bösartige Anweisungen in die Metadaten von MCP-Tools (wie Tool-Beschreibungen oder Parameter). Da große Sprachmodelle (LLMs) diese Metadaten nutzen, um zu entscheiden, welche Tools sie aufrufen, können kompromittierte Beschreibungen das Modell dazu verleiten, unautorisierte Tool-Aufrufe auszuführen oder Sicherheitskontrollen zu umgehen. Diese Manipulationen sind für Endnutzer oft unsichtbar, können aber vom KI-System interpretiert und ausgeführt werden. Dieses Risiko ist in gehosteten MCP-Server-Umgebungen besonders hoch, wo Tool-Definitionen nach der Benutzerfreigabe aktualisiert werden können – ein Szenario, das manchmal als "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" bezeichnet wird. In solchen Fällen kann ein zuvor sicheres Tool später so modifiziert werden, dass es bösartige Aktionen ausführt, wie Datenabfluss oder Verhaltensänderungen im System, ohne dass der Nutzer davon erfährt. Mehr zu diesem Angriffsvektor unter [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.de.png)

## Risiken  
Unbeabsichtigte KI-Aktionen bergen verschiedene Sicherheitsrisiken, darunter Datenabfluss und Datenschutzverletzungen.

### Gegenmaßnahmen  
### Einsatz von Prompt Shields zum Schutz vor indirekten Prompt Injection-Angriffen  
-----------------------------------------------------------------------------

**AI Prompt Shields** sind eine von Microsoft entwickelte Lösung, um sowohl direkte als auch indirekte Prompt Injection-Angriffe abzuwehren. Sie helfen durch:

1.  **Erkennung und Filterung:** Prompt Shields nutzen fortschrittliche Machine-Learning-Algorithmen und natürliche Sprachverarbeitung, um bösartige Anweisungen in externen Inhalten wie Dokumenten, Webseiten oder E-Mails zu erkennen und herauszufiltern.
    
2.  **Spotlighting:** Diese Technik hilft dem KI-System, zwischen gültigen Systemanweisungen und potenziell unzuverlässigen externen Eingaben zu unterscheiden. Durch die Transformation des Eingabetexts in eine für das Modell relevantere Form stellt Spotlighting sicher, dass die KI bösartige Anweisungen besser identifizieren und ignorieren kann.
    
3.  **Begrenzer und Datamarking:** Das Einfügen von Begrenzerzeichen in die Systemnachricht legt explizit den Ort des Eingabetexts fest und hilft dem KI-System, Benutzereingaben von potenziell schädlichen externen Inhalten zu trennen. Datamarking erweitert dieses Konzept durch spezielle Markierungen, die die Grenzen von vertrauenswürdigen und nicht vertrauenswürdigen Daten hervorheben.
    
4.  **Kontinuierliche Überwachung und Updates:** Microsoft überwacht und aktualisiert Prompt Shields kontinuierlich, um neuen und sich entwickelnden Bedrohungen zu begegnen. Dieser proaktive Ansatz stellt sicher, dass die Schutzmaßnahmen gegen die neuesten Angriffstechniken wirksam bleiben.
    
5. **Integration mit Azure Content Safety:** Prompt Shields sind Teil der umfassenderen Azure AI Content Safety-Suite, die zusätzliche Werkzeuge zur Erkennung von Jailbreak-Versuchen, schädlichen Inhalten und anderen Sicherheitsrisiken in KI-Anwendungen bietet.

Mehr Informationen zu AI Prompt Shields finden Sie in der [Prompt Shields-Dokumentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.de.png)

# Confused Deputy Problem

### Problemstellung
Das Confused Deputy-Problem ist eine Sicherheitslücke, die auftritt, wenn ein MCP-Server als Proxy zwischen MCP-Clients und Drittanbieter-APIs fungiert. Diese Schwachstelle kann ausgenutzt werden, wenn der MCP-Server eine statische Client-ID verwendet, um sich bei einem Drittanbieter-Autorisierungsserver zu authentifizieren, der keine Unterstützung für dynamische Client-Registrierung bietet.

### Risiken

- **Umgehung der Cookie-basierten Zustimmung**: Wenn ein Benutzer sich zuvor über den MCP-Proxy-Server authentifiziert hat, kann ein Drittanbieter-Autorisierungsserver ein Zustimmungscookie im Browser des Benutzers setzen. Ein Angreifer kann dies später ausnutzen, indem er dem Benutzer einen bösartigen Link mit einer manipulierten Autorisierungsanfrage und einer schädlichen Redirect-URI sendet.
- **Diebstahl des Autorisierungscodes**: Wenn der Benutzer auf den bösartigen Link klickt, kann der Drittanbieter-Autorisierungsserver aufgrund des vorhandenen Cookies den Zustimmungsbildschirm überspringen, und der Autorisierungscode könnte an den Server des Angreifers weitergeleitet werden.
- **Unbefugter API-Zugriff**: Der Angreifer kann den gestohlenen Autorisierungscode gegen Zugriffstoken eintauschen und sich als Benutzer ausgeben, um ohne ausdrückliche Genehmigung auf die Drittanbieter-API zuzugreifen.

### Gegenmaßnahmen

- **Explizite Zustimmung erforderlich**: MCP-Proxy-Server, die statische Client-IDs verwenden, **MÜSSEN** vor der Weiterleitung an Drittanbieter-Autorisierungsserver die Zustimmung des Benutzers für jeden dynamisch registrierten Client einholen.
- **Korrekte OAuth-Implementierung**: Befolgen Sie die Sicherheitsbest Practices von OAuth 2.1, einschließlich der Verwendung von Code-Challenges (PKCE) bei Autorisierungsanfragen, um Abfangangriffe zu verhindern.
- **Client-Validierung**: Implementieren Sie eine strenge Validierung von Redirect-URIs und Client-IDs, um Ausnutzung durch böswillige Akteure zu verhindern.


# Token-Passthrough-Schwachstellen

### Problemstellung

„Token Passthrough“ ist ein Anti-Pattern, bei dem ein MCP-Server Tokens von einem MCP-Client akzeptiert, ohne zu überprüfen, ob die Tokens ordnungsgemäß für den MCP-Server selbst ausgestellt wurden, und diese dann an nachgelagerte APIs „weiterreicht“. Dieses Vorgehen verstößt ausdrücklich gegen die MCP-Autorisierungsspezifikation und birgt erhebliche Sicherheitsrisiken.

### Risiken

- **Umgehung von Sicherheitskontrollen**: Clients könnten wichtige Sicherheitskontrollen wie Ratenbegrenzung, Anforderungsvalidierung oder Verkehrsüberwachung umgehen, wenn sie Tokens direkt mit nachgelagerten APIs ohne ordnungsgemäße Validierung verwenden können.
- **Probleme bei Verantwortlichkeit und Audit-Trail**: Der MCP-Server kann MCP-Clients nicht identifizieren oder unterscheiden, wenn Clients Zugriffstoken verwenden, die upstream ausgestellt wurden, was die Untersuchung von Vorfällen und Audits erschwert.
- **Datenexfiltration**: Wenn Tokens ohne ordnungsgemäße Anspruchsvalidierung weitergereicht werden, könnte ein böswilliger Akteur mit einem gestohlenen Token den Server als Proxy für Datenexfiltration nutzen.
- **Verletzung von Vertrauensgrenzen**: Nachgelagerte Ressourcensysteme gewähren bestimmten Entitäten Vertrauen basierend auf Annahmen über Herkunft oder Verhaltensmuster. Das Brechen dieser Vertrauensgrenze kann zu unerwarteten Sicherheitsproblemen führen.
- **Missbrauch von Multi-Service-Tokens**: Wenn Tokens von mehreren Diensten ohne ordnungsgemäße Validierung akzeptiert werden, könnte ein Angreifer, der einen Dienst kompromittiert, das Token verwenden, um auf andere verbundene Dienste zuzugreifen.

### Gegenmaßnahmen

- **Token-Validierung**: MCP-Server **DÜRFEN KEINE** Tokens akzeptieren, die nicht ausdrücklich für den MCP-Server selbst ausgestellt wurden.
- **Audience-Überprüfung**: Stellen Sie stets sicher, dass Tokens den korrekten Audience-Claim enthalten, der mit der Identität des MCP-Servers übereinstimmt.
- **Korrektes Token-Lifecycle-Management**: Implementieren Sie kurzlebige Zugriffstoken und ordnungsgemäße Token-Rotationspraktiken, um das Risiko von Token-Diebstahl und Missbrauch zu verringern.


# Session Hijacking

### Problemstellung

Session Hijacking ist ein Angriffsvektor, bei dem einem Client vom Server eine Session-ID zugewiesen wird und eine unbefugte Partei diese Session-ID erlangt und verwendet, um sich als der ursprüngliche Client auszugeben und unautorisierte Aktionen in dessen Namen durchzuführen. Dies ist besonders problematisch bei zustandsbehafteten HTTP-Servern, die MCP-Anfragen verarbeiten.

### Risiken

- **Session Hijack Prompt Injection**: Ein Angreifer, der eine Session-ID erlangt, könnte bösartige Ereignisse an einen Server senden, der den Session-Zustand mit dem Server teilt, mit dem der Client verbunden ist, und dadurch schädliche Aktionen auslösen oder auf sensible Daten zugreifen.
- **Session Hijack-Impersonation**: Ein Angreifer mit einer gestohlenen Session-ID könnte direkt Anfragen an den MCP-Server stellen, die Authentifizierung umgehen und als legitimer Benutzer behandelt werden.
- **Kompromittierte wiederaufnehmbare Streams**: Wenn ein Server Redelivery- oder wiederaufnehmbare Streams unterstützt, könnte ein Angreifer eine Anfrage vorzeitig beenden, sodass sie später vom ursprünglichen Client mit potenziell bösartigem Inhalt fortgesetzt wird.

### Gegenmaßnahmen

- **Autorisierungsprüfung**: MCP-Server, die Autorisierung implementieren, **MÜSSEN** alle eingehenden Anfragen überprüfen und **DÜRFEN KEINE** Sessions für die Authentifizierung verwenden.
- **Sichere Session-IDs**: MCP-Server **MÜSSEN** sichere, nicht-deterministische Session-IDs verwenden, die mit sicheren Zufallszahlengeneratoren erzeugt werden. Vermeiden Sie vorhersehbare oder sequenzielle Bezeichner.
- **Benutzerspezifische Session-Bindung**: MCP-Server **SOLLEN** Session-IDs an benutzerspezifische Informationen binden, indem sie die Session-ID mit Informationen kombinieren, die für den autorisierten Benutzer eindeutig sind (z. B. deren interne Benutzer-ID) in einem Format wie `<user_id>:<session_id>`.
- **Session-Ablauf**: Implementieren Sie einen ordnungsgemäßen Session-Ablauf und Rotation, um das Zeitfenster für Angriffe bei Kompromittierung einer Session-ID zu begrenzen.
- **Transportsicherheit**: Verwenden Sie stets HTTPS für alle Kommunikationen, um das Abfangen von Session-IDs zu verhindern.


# Sicherheit der Lieferkette

Die Sicherheit der Lieferkette bleibt im KI-Zeitalter grundlegend, aber der Umfang dessen, was als Lieferkette gilt, hat sich erweitert. Neben traditionellen Code-Paketen müssen Sie nun alle KI-bezogenen Komponenten rigoros überprüfen und überwachen, einschließlich Foundation Models, Embeddings-Services, Kontextanbieter und Drittanbieter-APIs. Jede dieser Komponenten kann Schwachstellen oder Risiken einführen, wenn sie nicht richtig verwaltet wird.

**Wichtige Praktiken zur Sicherheit der Lieferkette für KI und MCP:**
- **Alle Komponenten vor der Integration überprüfen:** Dies umfasst nicht nur Open-Source-Bibliotheken, sondern auch KI-Modelle, Datenquellen und externe APIs. Prüfen Sie stets Herkunft, Lizenzierung und bekannte Schwachstellen.
- **Sichere Deployment-Pipelines aufrechterhalten:** Verwenden Sie automatisierte CI/CD-Pipelines mit integrierter Sicherheitsprüfung, um Probleme frühzeitig zu erkennen. Stellen Sie sicher, dass nur vertrauenswürdige Artefakte in die Produktion gelangen.
- **Kontinuierliche Überwachung und Auditierung:** Implementieren Sie eine fortlaufende Überwachung aller Abhängigkeiten, einschließlich Modelle und Datenservices, um neue Schwachstellen oder Angriffe auf die Lieferkette zu erkennen.
- **Prinzip der geringsten Rechte und Zugriffskontrollen anwenden:** Beschränken Sie den Zugriff auf Modelle, Daten und Services auf das notwendige Minimum, damit Ihr MCP-Server funktioniert.
- **Schnelle Reaktion auf Bedrohungen:** Haben Sie Prozesse für das Patchen oder Ersetzen kompromittierter Komponenten sowie für das Rotieren von Geheimnissen oder Zugangsdaten, falls ein Sicherheitsvorfall erkannt wird.

[GitHub Advanced Security](https://github.com/security/advanced-security) bietet Funktionen wie Secret Scanning, Dependency Scanning und CodeQL-Analyse. Diese Tools integrieren sich mit [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) und [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), um Teams dabei zu unterstützen, Schwachstellen sowohl im Code als auch in KI-Lieferkettenkomponenten zu identifizieren und zu beheben.

Microsoft implementiert auch intern umfangreiche Sicherheitspraktiken für die Lieferkette aller Produkte. Mehr dazu erfahren Sie in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Etablierte Sicherheitsbest Practices zur Verbesserung der Sicherheitslage Ihrer MCP-Implementierung

Jede MCP-Implementierung übernimmt die bestehende Sicherheitslage der Umgebung Ihrer Organisation, auf der sie aufbaut. Daher wird empfohlen, bei der Betrachtung der Sicherheit von MCP als Bestandteil Ihrer gesamten KI-Systeme die bestehende Sicherheitslage insgesamt zu verbessern. Die folgenden etablierten Sicherheitskontrollen sind besonders relevant:

- Sichere Programmierpraktiken in Ihrer KI-Anwendung – Schutz gegen [die OWASP Top 10](https://owasp.org/www-project-top-ten/), die [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), Verwendung sicherer Tresore für Geheimnisse und Tokens, Implementierung von durchgängiger sicherer Kommunikation zwischen allen Anwendungskomponenten usw.
- Server-Härtung – Einsatz von MFA wo möglich, regelmäßiges Patchen, Integration des Servers mit einem Drittanbieter-Identitätsanbieter für den Zugriff usw.
- Halten Sie Geräte, Infrastruktur und Anwendungen mit Patches auf dem neuesten Stand
- Sicherheitsüberwachung – Implementierung von Logging und Monitoring einer KI-Anwendung (einschließlich MCP-Client/Server) und Weiterleitung dieser Logs an ein zentrales SIEM zur Erkennung anomaler Aktivitäten
- Zero-Trust-Architektur – Isolierung von Komponenten durch Netzwerk- und Identitätskontrollen auf logische Weise, um laterale Bewegungen zu minimieren, falls eine KI-Anwendung kompromittiert wird.

# Wichtige Erkenntnisse

- Sicherheitsgrundlagen bleiben entscheidend: Sichere Programmierung, Prinzip der geringsten Rechte, Überprüfung der Lieferkette und kontinuierliche Überwachung sind essenziell für MCP- und KI-Workloads.
- MCP bringt neue Risiken mit sich – wie Prompt Injection, Tool Poisoning, Session Hijacking, Confused Deputy-Probleme, Token-Passthrough-Schwachstellen und übermäßige Berechtigungen –, die sowohl traditionelle als auch KI-spezifische Kontrollen erfordern.
- Verwenden Sie robuste Authentifizierungs-, Autorisierungs- und Token-Management-Praktiken und nutzen Sie nach Möglichkeit externe Identitätsanbieter wie Microsoft Entra ID.
- Schützen Sie vor indirekter Prompt Injection und Tool Poisoning, indem Sie Tool-Metadaten validieren, dynamische Änderungen überwachen und Lösungen wie Microsoft Prompt Shields einsetzen.
- Implementieren Sie sicheres Sitzungsmanagement durch Verwendung nicht-deterministischer Session-IDs, Bindung von Sessions an Benutzeridentitäten und niemals Sessions für die Authentifizierung verwenden.
- Verhindern Sie Confused Deputy-Angriffe, indem Sie für jeden dynamisch registrierten Client eine explizite Benutzerzustimmung verlangen und ordnungsgemäße OAuth-Sicherheitspraktiken umsetzen.
- Vermeiden Sie Token-Passthrough-Schwachstellen, indem Sie sicherstellen, dass MCP-Server nur Tokens akzeptieren, die ausdrücklich für sie ausgestellt wurden, und Token-Claims angemessen validieren.
- Behandeln Sie alle Komponenten Ihrer KI-Lieferkette – einschließlich Modelle, Embeddings und Kontextanbieter – mit derselben Sorgfalt wie Code-Abhängigkeiten.
- Bleiben Sie auf dem neuesten Stand der sich entwickelnden MCP-Spezifikationen und tragen Sie zur Community bei, um sichere Standards mitzugestalten.

# Zusätzliche Ressourcen

## Externe Ressourcen
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Zusätzliche Sicherheitsdokumente

Für detailliertere Sicherheitshinweise konsultieren Sie bitte diese Dokumente:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) – Umfassende Liste von Sicherheitsbest Practices für MCP-Implementierungen
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) – Implementierungsbeispiele zur Integration von Azure Content Safety mit MCP-Servern
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) – Neueste Sicherheitskontrollen und Techniken zur Absicherung von MCP-Deployments
- [MCP Best Practices](./mcp-best-practices.md) – Schnellreferenz für MCP-Sicherheit

### Weiter

Weiter: [Kapitel 3: Erste Schritte](../03-GettingStarted/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.