<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "14830e7df8352430ce7654b70ad969e1",
  "translation_date": "2025-07-29T01:02:01+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "de"
}
-->
# Sicherheits-Best-Practices

[![MCP Sicherheits-Best-Practices](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.de.png)](https://youtu.be/88No8pw706o)

_(Klicken Sie auf das Bild oben, um das Video zu dieser Lektion anzusehen)_

Die Einführung des Model Context Protocol (MCP) bringt leistungsstarke neue Möglichkeiten für KI-gesteuerte Anwendungen, stellt jedoch auch einzigartige Sicherheitsherausforderungen dar, die über die traditionellen Software-Risiken hinausgehen. Neben etablierten Themen wie sicherem Programmieren, dem Prinzip der minimalen Rechte und der Sicherheit in der Lieferkette stehen MCP und KI-Workloads vor neuen Bedrohungen wie Prompt Injection, Tool Poisoning, dynamischer Tool-Modifikation, Sitzungsübernahme, Confused Deputy-Angriffen und Token-Passthrough-Schwachstellen. Diese Risiken können zu Datenverlust, Datenschutzverletzungen und unbeabsichtigtem Systemverhalten führen, wenn sie nicht ordnungsgemäß verwaltet werden.

Diese Lektion untersucht die relevantesten Sicherheitsrisiken im Zusammenhang mit MCP—einschließlich Authentifizierung, Autorisierung, übermäßiger Berechtigungen, indirekter Prompt Injection, Sitzungs-Sicherheit, Confused Deputy-Problemen, Token-Passthrough-Schwachstellen und Schwachstellen in der Lieferkette—und bietet umsetzbare Kontrollen und Best-Practices, um diese zu mindern. Sie lernen außerdem, wie Sie Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security nutzen können, um Ihre MCP-Implementierung zu stärken. Durch das Verständnis und die Anwendung dieser Kontrollen können Sie die Wahrscheinlichkeit eines Sicherheitsvorfalls erheblich reduzieren und sicherstellen, dass Ihre KI-Systeme robust und vertrauenswürdig bleiben.

# Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Die einzigartigen Sicherheitsrisiken, die durch das Model Context Protocol (MCP) eingeführt werden, zu identifizieren und zu erklären, einschließlich Prompt Injection, Tool Poisoning, übermäßiger Berechtigungen, Sitzungsübernahme, Confused Deputy-Problemen, Token-Passthrough-Schwachstellen und Schwachstellen in der Lieferkette.
- Effektive Maßnahmen zur Minderung von MCP-Sicherheitsrisiken zu beschreiben und anzuwenden, wie robuste Authentifizierung, das Prinzip der minimalen Rechte, sicheres Token-Management, Sitzungs-Sicherheitskontrollen und Überprüfung der Lieferkette.
- Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security zu verstehen und zu nutzen, um MCP- und KI-Workloads zu schützen.
- Die Bedeutung der Validierung von Tool-Metadaten, der Überwachung dynamischer Änderungen, der Verteidigung gegen indirekte Prompt Injection-Angriffe und der Verhinderung von Sitzungsübernahmen zu erkennen.
- Etablierte Sicherheits-Best-Practices—wie sicheres Programmieren, Server-Härtung und Zero-Trust-Architektur—in Ihre MCP-Implementierung zu integrieren, um die Wahrscheinlichkeit und Auswirkungen von Sicherheitsvorfällen zu reduzieren.

# MCP-Sicherheitskontrollen

Jedes System, das Zugriff auf wichtige Ressourcen hat, bringt implizite Sicherheitsherausforderungen mit sich. Diese Herausforderungen können im Allgemeinen durch die korrekte Anwendung grundlegender Sicherheitskontrollen und -konzepte adressiert werden. Da MCP erst kürzlich definiert wurde, ändert sich die Spezifikation sehr schnell, und das Protokoll entwickelt sich weiter. Mit der Zeit werden die Sicherheitskontrollen innerhalb von MCP reifen und eine bessere Integration in Unternehmens- und etablierte Sicherheitsarchitekturen sowie Best-Practices ermöglichen.

Forschungen, die im [Microsoft Digital Defense Report](https://aka.ms/mddr) veröffentlicht wurden, zeigen, dass 98 % der gemeldeten Sicherheitsvorfälle durch robuste Sicherheitsmaßnahmen verhindert werden könnten. Der beste Schutz gegen jegliche Art von Sicherheitsvorfällen besteht darin, die grundlegenden Sicherheitsmaßnahmen, Best-Practices für sicheres Programmieren und die Sicherheit in der Lieferkette richtig umzusetzen—diese bewährten Praktiken, die wir bereits kennen, haben nach wie vor den größten Einfluss auf die Reduzierung von Sicherheitsrisiken.

Schauen wir uns einige Möglichkeiten an, wie Sie Sicherheitsrisiken bei der Einführung von MCP angehen können.

> **Hinweis:** Die folgenden Informationen sind korrekt ab dem **29. Mai 2025**. Das MCP-Protokoll entwickelt sich ständig weiter, und zukünftige Implementierungen können neue Authentifizierungsmuster und -kontrollen einführen. Für die neuesten Updates und Anleitungen konsultieren Sie stets die [MCP-Spezifikation](https://spec.modelcontextprotocol.io/), das offizielle [MCP GitHub-Repository](https://github.com/modelcontextprotocol) und die [Seite zu Sicherheits-Best-Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstellung
Die ursprüngliche MCP-Spezifikation ging davon aus, dass Entwickler ihren eigenen Authentifizierungsserver schreiben würden. Dies erforderte Kenntnisse über OAuth und verwandte Sicherheitsanforderungen. MCP-Server fungierten als OAuth 2.0-Authorisierungsserver und verwalteten die erforderliche Benutzer-Authentifizierung direkt, anstatt sie an einen externen Dienst wie Microsoft Entra ID zu delegieren. Seit dem **26. April 2025** erlaubt ein Update der MCP-Spezifikation, dass MCP-Server die Benutzer-Authentifizierung an einen externen Dienst delegieren können.

### Risiken
- Fehlkonfigurierte Autorisierungslogik im MCP-Server kann zur Offenlegung sensibler Daten und zu falsch angewendeten Zugriffskontrollen führen.
- Diebstahl von OAuth-Tokens auf dem lokalen MCP-Server. Wenn gestohlen, kann das Token verwendet werden, um den MCP-Server zu imitieren und auf Ressourcen und Daten des Dienstes zuzugreifen, für den das OAuth-Token bestimmt ist.

#### Token-Passthrough
Token-Passthrough ist in der Autorisierungsspezifikation ausdrücklich verboten, da es eine Reihe von Sicherheitsrisiken mit sich bringt, darunter:

#### Umgehung von Sicherheitskontrollen
Der MCP-Server oder nachgelagerte APIs könnten wichtige Sicherheitskontrollen wie Ratenbegrenzung, Anforderungsvalidierung oder Verkehrsüberwachung implementieren, die von der Token-Audience oder anderen Anmeldeinformationen abhängen. Wenn Clients Tokens direkt mit den nachgelagerten APIs verwenden können, ohne dass der MCP-Server sie ordnungsgemäß validiert oder sicherstellt, dass die Tokens für den richtigen Dienst ausgestellt wurden, umgehen sie diese Kontrollen.

#### Probleme mit Verantwortlichkeit und Audit-Trails
Der MCP-Server kann MCP-Clients nicht identifizieren oder unterscheiden, wenn Clients mit einem von einer anderen Quelle ausgestellten Zugriffstoken anrufen, das für den MCP-Server möglicherweise undurchsichtig ist.  
Die Protokolle des nachgelagerten Ressourcenservers könnten Anfragen zeigen, die von einer anderen Quelle mit einer anderen Identität zu kommen scheinen, anstatt vom MCP-Server, der die Tokens tatsächlich weiterleitet.  
Beide Faktoren erschweren die Untersuchung von Vorfällen, Kontrollen und Audits.  
Wenn der MCP-Server Tokens weiterleitet, ohne deren Ansprüche (z. B. Rollen, Berechtigungen oder Audience) oder andere Metadaten zu validieren, kann ein böswilliger Akteur mit einem gestohlenen Token den Server als Proxy für Datenexfiltration nutzen.

#### Vertrauensgrenzen-Probleme
Der nachgelagerte Ressourcenserver gewährt bestimmten Entitäten Vertrauen. Dieses Vertrauen könnte Annahmen über die Herkunft oder das Verhalten des Clients beinhalten. Das Brechen dieser Vertrauensgrenze könnte zu unerwarteten Problemen führen.  
Wenn das Token von mehreren Diensten ohne ordnungsgemäße Validierung akzeptiert wird, kann ein Angreifer, der einen Dienst kompromittiert, das Token verwenden, um auf andere verbundene Dienste zuzugreifen.

#### Risiko zukünftiger Kompatibilität
Selbst wenn ein MCP-Server heute als "reiner Proxy" startet, könnte er später Sicherheitskontrollen hinzufügen müssen. Der Beginn mit einer ordnungsgemäßen Trennung der Token-Audience erleichtert die Weiterentwicklung des Sicherheitsmodells.

### Mildernde Maßnahmen

**MCP-Server DÜRFEN KEINE Tokens akzeptieren, die nicht ausdrücklich für den MCP-Server ausgestellt wurden**

- **Überprüfen und Härten der Autorisierungslogik:** Überprüfen Sie sorgfältig die Autorisierungsimplementierung Ihres MCP-Servers, um sicherzustellen, dass nur beabsichtigte Benutzer und Clients auf sensible Ressourcen zugreifen können. Praktische Anleitungen finden Sie unter [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) und [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Sichere Token-Praktiken durchsetzen:** Befolgen Sie [Microsofts Best-Practices für Token-Validierung und -Lebensdauer](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), um den Missbrauch von Zugriffstokens zu verhindern und das Risiko von Token-Wiederholungen oder -Diebstahl zu reduzieren.
- **Token-Speicherung schützen:** Speichern Sie Tokens immer sicher und verwenden Sie Verschlüsselung, um sie im Ruhezustand und während der Übertragung zu schützen. Implementierungstipps finden Sie unter [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Übermäßige Berechtigungen für MCP-Server

### Problemstellung
MCP-Server könnten übermäßige Berechtigungen für den Dienst/die Ressource erhalten haben, auf die sie zugreifen. Beispielsweise sollte ein MCP-Server, der Teil einer KI-Verkaufsanwendung ist und auf einen Unternehmensdatenspeicher zugreift, nur Zugriff auf die Verkaufsdaten haben und nicht auf alle Dateien im Speicher. In Anlehnung an das Prinzip der minimalen Rechte (eines der ältesten Sicherheitsprinzipien) sollte keine Ressource über Berechtigungen verfügen, die über das hinausgehen, was für die Ausführung der vorgesehenen Aufgaben erforderlich ist. KI stellt in diesem Bereich eine erhöhte Herausforderung dar, da es schwierig sein kann, die genauen erforderlichen Berechtigungen zu definieren, um Flexibilität zu ermöglichen.

### Risiken 
- Übermäßige Berechtigungen können es ermöglichen, Daten zu exfiltrieren oder zu ändern, auf die der MCP-Server nicht zugreifen sollte. Dies könnte auch ein Datenschutzproblem darstellen, wenn es sich bei den Daten um personenbezogene Informationen (PII) handelt.

### Mildernde Maßnahmen
- **Prinzip der minimalen Rechte anwenden:** Gewähren Sie dem MCP-Server nur die minimalen Berechtigungen, die erforderlich sind, um seine Aufgaben auszuführen. Überprüfen und aktualisieren Sie diese Berechtigungen regelmäßig, um sicherzustellen, dass sie nicht über das Notwendige hinausgehen. Detaillierte Anleitungen finden Sie unter [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Rollenbasierte Zugriffskontrolle (RBAC) verwenden:** Weisen Sie dem MCP-Server Rollen zu, die eng auf bestimmte Ressourcen und Aktionen abgestimmt sind, und vermeiden Sie breite oder unnötige Berechtigungen.
- **Berechtigungen überwachen und prüfen:** Überwachen Sie kontinuierlich die Nutzung von Berechtigungen und prüfen Sie Zugriffsprotokolle, um übermäßige oder ungenutzte Berechtigungen schnell zu erkennen und zu beheben.

# Indirekte Prompt Injection-Angriffe

### Problemstellung

Böswillige oder kompromittierte MCP-Server können erhebliche Risiken darstellen, indem sie Kundendaten offenlegen oder unbeabsichtigte Aktionen ermöglichen. Diese Risiken sind besonders relevant in KI- und MCP-basierten Workloads, bei denen:

- **Prompt Injection-Angriffe**: Angreifer betten böswillige Anweisungen in Prompts oder externe Inhalte ein, wodurch das KI-System unbeabsichtigte Aktionen ausführt oder sensible Daten preisgibt. Mehr erfahren: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Angreifer manipulieren Tool-Metadaten (wie Beschreibungen oder Parameter), um das Verhalten der KI zu beeinflussen, Sicherheitskontrollen zu umgehen oder Daten zu exfiltrieren. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Böswillige Anweisungen werden in Dokumente, Webseiten oder E-Mails eingebettet, die dann von der KI verarbeitet werden, was zu Datenlecks oder Manipulationen führt.
- **Dynamische Tool-Modifikation (Rug Pulls)**: Tool-Definitionen können nach der Benutzerfreigabe geändert werden, wodurch neue böswillige Verhaltensweisen eingeführt werden, ohne dass der Benutzer davon Kenntnis hat.

Diese Schwachstellen verdeutlichen die Notwendigkeit robuster Validierungs-, Überwachungs- und Sicherheitskontrollen bei der Integration von MCP-Servern und -Tools in Ihre Umgebung. Für eine tiefere Analyse siehe die oben verlinkten Referenzen.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.de.png)

**Indirekte Prompt Injection** (auch bekannt als Cross-Domain Prompt Injection oder XPIA) ist eine kritische Schwachstelle in generativen KI-Systemen, einschließlich solcher, die das Model Context Protocol (MCP) verwenden. Bei diesem Angriff werden böswillige Anweisungen in externe Inhalte—wie Dokumente, Webseiten oder E-Mails—eingebettet. Wenn das KI-System diese Inhalte verarbeitet, interpretiert es die eingebetteten Anweisungen möglicherweise als legitime Benutzerbefehle, was zu unbeabsichtigten Aktionen wie Datenlecks, der Generierung schädlicher Inhalte oder der Manipulation von Benutzerinteraktionen führt. Für eine detaillierte Erklärung und Beispiele aus der Praxis siehe [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Eine besonders gefährliche Form dieses Angriffs ist **Tool Poisoning**. Hierbei injizieren Angreifer böswillige Anweisungen in die Metadaten von MCP-Tools (wie Tool-Beschreibungen oder Parameter). Da große Sprachmodelle (LLMs) auf diese Metadaten angewiesen sind, um zu entscheiden, welche Tools aufgerufen werden sollen, können kompromittierte Beschreibungen das Modell dazu verleiten, unautorisierte Tool-Aufrufe auszuführen oder Sicherheitskontrollen zu umgehen. Diese Manipulationen sind für Endbenutzer oft unsichtbar, können jedoch vom KI-System interpretiert und ausgeführt werden. Dieses Risiko ist in gehosteten MCP-Server-Umgebungen besonders hoch, in denen Tool-Definitionen nach der Benutzerfreigabe aktualisiert werden können—ein Szenario, das manchmal als "[Rug Pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" bezeichnet wird. In solchen Fällen kann ein zuvor sicheres Tool später so modifiziert werden, dass es böswillige Aktionen wie Datenexfiltration oder die Änderung des Systemverhaltens ausführt, ohne dass der Benutzer davon Kenntnis hat. Weitere Informationen zu diesem Angriffsvektor finden Sie unter [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.de.png)

## Risiken
Unbeabsichtigte KI-Aktionen stellen eine Vielzahl von Sicherheitsrisiken dar, darunter Datenexfiltration und Datenschutzverletzungen.

### Mildernde Maßnahmen
### Verwendung von Prompt Shields zum Schutz vor indirekten Prompt Injection-Angriffen
-----------------------------------------------------------------------------

**AI Prompt Shields** sind eine von Microsoft entwickelte Lösung, um sowohl direkte als auch indirekte Prompt Injection-Angriffe abzuwehren. Sie helfen durch:

1.  **Erkennung und Filterung**: Prompt Shields verwenden fortschrittliche maschinelle Lernalgorithmen und natürliche Sprachverarbeitung, um böswillige Anweisungen zu erkennen und herauszufiltern, die in externe Inhalte wie Dokumente, Webseiten oder E-Mails eingebettet sind.
    
2.  **Spotlighting**: Diese Technik hilft dem KI-System, zwischen gültigen Systemanweisungen und potenziell unzuverlässigen externen Eingaben zu unterscheiden. Durch die Transformation des Eingabetextes in eine für das Modell relevantere Form stellt Spotlighting sicher, dass die KI böswillige Anweisungen besser erkennen und ignorieren kann.
    
3.  **Trennzeichen und Datamarking**: Durch die Einbeziehung von Trennzeichen in die Systemnachricht werden die Positionen des Eingabetextes explizit umrissen, was dem KI-System hilft, Benutzer-Eingaben von potenziell schädlichen externen Inhalten zu trennen. Datamarking erweitert dieses Konzept, indem spezielle Markierungen verwendet werden, um die Grenzen zwischen vertrauenswürdigen und nicht vertrauenswürdigen Daten hervorzuheben.
    
4.  **Kontinuierliche Überwachung und Updates**: Microsoft überwacht und aktualisiert Prompt Shields kontinuierlich, um neuen und sich entwickelnden Bedrohungen zu begegnen. Dieser proaktive Ansatz stellt sicher, dass die Abwehrmaßnahmen gegen die neuesten Angriffstechniken wirksam bleiben.
    
5. **Integration mit Azure Content Safety:** Prompt Shields sind Teil der umfassenderen Azure AI Content Safety Suite, die zusätzliche Tools zur Erkennung von Jailbreak-Versuchen, schädlichen Inhalten und anderen Sicherheitsrisiken in KI-Anwendungen bietet.

Weitere Informationen zu AI Prompt Shields finden Sie in der [Prompt Shields-Dokumentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).
![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.de.png)

# Problem des verwirrten Stellvertreters

### Problemstellung

Das Problem des verwirrten Stellvertreters ist eine Sicherheitslücke, die auftritt, wenn ein MCP-Server als Proxy zwischen MCP-Clients und Drittanbieter-APIs fungiert. Diese Schwachstelle kann ausgenutzt werden, wenn der MCP-Server eine statische Client-ID verwendet, um sich bei einem Drittanbieter-Autorisierungsserver zu authentifizieren, der keine Unterstützung für die dynamische Client-Registrierung bietet.

### Risiken

- **Umgehung der Cookie-basierten Zustimmung**: Wenn ein Benutzer zuvor über den MCP-Proxy-Server authentifiziert wurde, kann ein Drittanbieter-Autorisierungsserver ein Zustimmungs-Cookie im Browser des Benutzers setzen. Ein Angreifer kann dies später ausnutzen, indem er dem Benutzer einen bösartigen Link mit einer manipulierten Autorisierungsanfrage und einer schädlichen Redirect-URI sendet.
- **Diebstahl von Autorisierungscodes**: Wenn der Benutzer auf den bösartigen Link klickt, kann der Drittanbieter-Autorisierungsserver aufgrund des vorhandenen Cookies den Zustimmungsbildschirm überspringen, und der Autorisierungscode könnte an den Server des Angreifers weitergeleitet werden.
- **Unbefugter API-Zugriff**: Der Angreifer kann den gestohlenen Autorisierungscode gegen Zugriffstoken eintauschen und den Benutzer imitieren, um ohne ausdrückliche Zustimmung auf die Drittanbieter-API zuzugreifen.

### Gegenmaßnahmen

- **Erforderliche ausdrückliche Zustimmung**: MCP-Proxy-Server, die statische Client-IDs verwenden, **MÜSSEN** die Zustimmung des Benutzers für jeden dynamisch registrierten Client einholen, bevor sie Anfragen an Drittanbieter-Autorisierungsserver weiterleiten.
- **Korrekte OAuth-Implementierung**: Befolgen Sie die Sicherheitsbest-Practices von OAuth 2.1, einschließlich der Verwendung von Code-Challenges (PKCE) für Autorisierungsanfragen, um Abfangangriffe zu verhindern.
- **Client-Validierung**: Implementieren Sie eine strikte Validierung von Redirect-URIs und Client-Identifikatoren, um eine Ausnutzung durch böswillige Akteure zu verhindern.

# Schwachstellen bei der Token-Durchleitung

### Problemstellung

"Token-Durchleitung" ist ein Anti-Pattern, bei dem ein MCP-Server Tokens von einem MCP-Client akzeptiert, ohne zu überprüfen, ob die Tokens ordnungsgemäß für den MCP-Server selbst ausgestellt wurden, und diese dann an nachgelagerte APIs "durchleitet". Diese Praxis verstößt ausdrücklich gegen die MCP-Autorisierungsspezifikation und birgt erhebliche Sicherheitsrisiken.

### Risiken

- **Umgehung von Sicherheitskontrollen**: Clients könnten wichtige Sicherheitskontrollen wie Ratenbegrenzung, Anfragenvalidierung oder Verkehrsüberwachung umgehen, wenn sie Tokens direkt mit nachgelagerten APIs verwenden können, ohne ordnungsgemäße Validierung.
- **Probleme bei Verantwortlichkeit und Audit-Trails**: Der MCP-Server kann MCP-Clients nicht identifizieren oder unterscheiden, wenn Clients Tokens verwenden, die von einer übergeordneten Stelle ausgestellt wurden, was die Untersuchung von Vorfällen und Audits erschwert.
- **Datenexfiltration**: Wenn Tokens ohne ordnungsgemäße Validierung der Claims weitergeleitet werden, könnte ein böswilliger Akteur mit einem gestohlenen Token den Server als Proxy für Datenexfiltration nutzen.
- **Verletzung von Vertrauensgrenzen**: Nachgelagerte Ressourcenserver könnten bestimmten Entitäten Vertrauen entgegenbringen, basierend auf Annahmen über Herkunft oder Verhaltensmuster. Das Brechen dieser Vertrauensgrenzen könnte zu unerwarteten Sicherheitsproblemen führen.
- **Missbrauch von Multi-Service-Tokens**: Wenn Tokens von mehreren Diensten ohne ordnungsgemäße Validierung akzeptiert werden, könnte ein Angreifer, der einen Dienst kompromittiert, das Token nutzen, um auf andere verbundene Dienste zuzugreifen.

### Gegenmaßnahmen

- **Token-Validierung**: MCP-Server **DÜRFEN KEINE** Tokens akzeptieren, die nicht ausdrücklich für den MCP-Server selbst ausgestellt wurden.
- **Überprüfung der Zielgruppe**: Überprüfen Sie immer, dass Tokens den richtigen Audience-Claim haben, der mit der Identität des MCP-Servers übereinstimmt.
- **Korrektes Token-Lebenszyklusmanagement**: Implementieren Sie kurzlebige Zugriffstokens und geeignete Token-Rotationspraktiken, um das Risiko von Token-Diebstahl und -Missbrauch zu minimieren.

# Sitzungsübernahme

### Problemstellung

Sitzungsübernahme ist ein Angriffsvektor, bei dem ein Client eine Sitzungs-ID vom Server erhält und eine unbefugte Partei dieselbe Sitzungs-ID erlangt und verwendet, um den ursprünglichen Client zu imitieren und unbefugte Aktionen in dessen Namen auszuführen. Dies ist besonders besorgniserregend bei zustandsbehafteten HTTP-Servern, die MCP-Anfragen verarbeiten.

### Risiken

- **Sitzungsübernahme durch Prompt-Injection**: Ein Angreifer, der eine Sitzungs-ID erlangt, könnte bösartige Ereignisse an einen Server senden, der Sitzungszustände mit dem Server teilt, mit dem der Client verbunden ist, und möglicherweise schädliche Aktionen auslösen oder auf sensible Daten zugreifen.
- **Sitzungsübernahme durch Imitation**: Ein Angreifer mit einer gestohlenen Sitzungs-ID könnte direkt Anfragen an den MCP-Server stellen, die Authentifizierung umgehen und als legitimer Benutzer behandelt werden.
- **Kompromittierte wiederaufnehmbare Streams**: Wenn ein Server die erneute Übertragung/wiederaufnehmbare Streams unterstützt, könnte ein Angreifer eine Anfrage vorzeitig beenden, was dazu führt, dass sie später vom ursprünglichen Client mit potenziell bösartigem Inhalt wieder aufgenommen wird.

### Gegenmaßnahmen

- **Autorisierungsüberprüfung**: MCP-Server, die Autorisierung implementieren, **MÜSSEN** alle eingehenden Anfragen überprüfen und **DÜRFEN KEINE** Sitzungen für die Authentifizierung verwenden.
- **Sichere Sitzungs-IDs**: MCP-Server **MÜSSEN** sichere, nicht-deterministische Sitzungs-IDs verwenden, die mit sicheren Zufallszahlengeneratoren erstellt werden. Vermeiden Sie vorhersehbare oder sequenzielle Identifikatoren.
- **Benutzerspezifische Sitzungsbindung**: MCP-Server **SOLLTEN** Sitzungs-IDs an benutzerspezifische Informationen binden, indem sie die Sitzungs-ID mit Informationen kombinieren, die für den autorisierten Benutzer einzigartig sind (z. B. deren interne Benutzer-ID) in einem Format wie `<user_id>:<session_id>`.
- **Sitzungsexpiration**: Implementieren Sie eine ordnungsgemäße Sitzungsexpiration und -rotation, um das Zeitfenster der Verwundbarkeit zu begrenzen, falls eine Sitzungs-ID kompromittiert wird.
- **Transportsicherheit**: Verwenden Sie immer HTTPS für alle Kommunikationen, um das Abfangen von Sitzungs-IDs zu verhindern.

# Sicherheit in der Lieferkette

Die Sicherheit in der Lieferkette bleibt im KI-Zeitalter von grundlegender Bedeutung, aber der Umfang dessen, was Ihre Lieferkette ausmacht, hat sich erweitert. Neben traditionellen Codepaketen müssen Sie nun alle KI-bezogenen Komponenten, einschließlich Basis-Modellen, Embedding-Diensten, Kontextanbietern und Drittanbieter-APIs, rigoros überprüfen und überwachen. Jede dieser Komponenten kann Schwachstellen oder Risiken einführen, wenn sie nicht ordnungsgemäß verwaltet werden.

**Wichtige Sicherheitspraktiken für die Lieferkette in KI und MCP:**
- **Überprüfen Sie alle Komponenten vor der Integration:** Dazu gehören nicht nur Open-Source-Bibliotheken, sondern auch KI-Modelle, Datenquellen und externe APIs. Überprüfen Sie immer Herkunft, Lizenzierung und bekannte Schwachstellen.
- **Sichere Bereitstellungspipelines aufrechterhalten:** Verwenden Sie automatisierte CI/CD-Pipelines mit integrierten Sicherheitsüberprüfungen, um Probleme frühzeitig zu erkennen. Stellen Sie sicher, dass nur vertrauenswürdige Artefakte in die Produktion gelangen.
- **Kontinuierliche Überwachung und Audits:** Implementieren Sie eine laufende Überwachung aller Abhängigkeiten, einschließlich Modelle und Datendienste, um neue Schwachstellen oder Angriffe auf die Lieferkette zu erkennen.
- **Prinzip der minimalen Rechte und Zugriffskontrollen anwenden:** Beschränken Sie den Zugriff auf Modelle, Daten und Dienste auf das, was für die Funktion Ihres MCP-Servers unbedingt erforderlich ist.
- **Schnelle Reaktion auf Bedrohungen:** Haben Sie einen Prozess für das Patchen oder Ersetzen kompromittierter Komponenten sowie für das Rotieren von Geheimnissen oder Anmeldeinformationen, falls ein Verstoß festgestellt wird.

[GitHub Advanced Security](https://github.com/security/advanced-security) bietet Funktionen wie Geheimnis-Scanning, Abhängigkeits-Scanning und CodeQL-Analyse. Diese Tools integrieren sich mit [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) und [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), um Teams dabei zu helfen, Schwachstellen sowohl im Code als auch in KI-Lieferkettenkomponenten zu identifizieren und zu beheben.

Microsoft implementiert auch intern umfangreiche Sicherheitspraktiken für die Lieferkette in allen Produkten. Erfahren Sie mehr in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Etablierte Sicherheits-Best-Practices zur Verbesserung der Sicherheit Ihrer MCP-Implementierung

Jede MCP-Implementierung übernimmt die bestehende Sicherheitslage der Umgebung, auf der sie basiert. Daher wird empfohlen, die allgemeine Sicherheitslage Ihrer Organisation zu verbessern, wenn Sie die Sicherheit von MCP als Bestandteil Ihrer KI-Systeme betrachten. Die folgenden etablierten Sicherheitskontrollen sind besonders relevant:

-   Sichere Codierungspraktiken in Ihrer KI-Anwendung – Schutz vor [den OWASP Top 10](https://owasp.org/www-project-top-ten/), den [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), Verwendung sicherer Tresore für Geheimnisse und Tokens, Implementierung von End-to-End-sicheren Kommunikationen zwischen allen Anwendungskomponenten usw.
-   Server-Härtung – Verwenden Sie MFA, halten Sie Patches aktuell, integrieren Sie den Server mit einem Drittanbieter-Identitätsanbieter für den Zugriff usw.
-   Halten Sie Geräte, Infrastruktur und Anwendungen mit Patches auf dem neuesten Stand.
-   Sicherheitsüberwachung – Implementieren Sie Logging und Überwachung einer KI-Anwendung (einschließlich MCP-Clients/Server) und senden Sie diese Logs an ein zentrales SIEM, um anomale Aktivitäten zu erkennen.
-   Zero-Trust-Architektur – Isolieren Sie Komponenten durch Netzwerk- und Identitätskontrollen auf logische Weise, um die seitliche Bewegung zu minimieren, falls eine KI-Anwendung kompromittiert wird.

# Wichtige Erkenntnisse

- Sicherheitsgrundlagen bleiben entscheidend: Sichere Codierung, minimaler Zugriff, Lieferkettenüberprüfung und kontinuierliche Überwachung sind für MCP- und KI-Workloads unerlässlich.
- MCP bringt neue Risiken mit sich – wie Prompt-Injection, Tool-Poisoning, Sitzungsübernahme, Probleme des verwirrten Stellvertreters, Schwachstellen bei der Token-Durchleitung und übermäßige Berechtigungen –, die sowohl traditionelle als auch KI-spezifische Kontrollen erfordern.
- Verwenden Sie robuste Authentifizierungs-, Autorisierungs- und Token-Management-Praktiken und nutzen Sie externe Identitätsanbieter wie Microsoft Entra ID, wo möglich.
- Schützen Sie sich vor indirekter Prompt-Injection und Tool-Poisoning, indem Sie Tool-Metadaten validieren, dynamische Änderungen überwachen und Lösungen wie Microsoft Prompt Shields verwenden.
- Implementieren Sie sicheres Sitzungsmanagement durch die Verwendung nicht-deterministischer Sitzungs-IDs, die Bindung von Sitzungen an Benutzeridentitäten und die Vermeidung der Verwendung von Sitzungen für die Authentifizierung.
- Verhindern Sie Angriffe des verwirrten Stellvertreters, indem Sie für jeden dynamisch registrierten Client die ausdrückliche Zustimmung des Benutzers verlangen und die Sicherheitspraktiken von OAuth korrekt umsetzen.
- Vermeiden Sie Schwachstellen bei der Token-Durchleitung, indem Sie sicherstellen, dass MCP-Server nur Tokens akzeptieren, die ausdrücklich für sie ausgestellt wurden, und Token-Claims ordnungsgemäß validieren.
- Behandeln Sie alle Komponenten in Ihrer KI-Lieferkette – einschließlich Modelle, Embeddings und Kontextanbieter – mit der gleichen Sorgfalt wie Code-Abhängigkeiten.
- Bleiben Sie auf dem neuesten Stand der sich entwickelnden MCP-Spezifikationen und tragen Sie zur Community bei, um sichere Standards zu fördern.

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
- [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
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

Für detailliertere Sicherheitsrichtlinien lesen Sie bitte diese Dokumente:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Umfassende Liste der Sicherheits-Best-Practices für MCP-Implementierungen
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Implementierungsbeispiele für die Integration von Azure Content Safety mit MCP-Servern
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Neueste Sicherheitskontrollen und Techniken zur Sicherung von MCP-Bereitstellungen
- [MCP Best Practices](./mcp-best-practices.md) - Schnellreferenz für MCP-Sicherheitsrichtlinien

### Weiter

Weiter: [Kapitel 3: Erste Schritte](../03-GettingStarted/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die sich aus der Nutzung dieser Übersetzung ergeben.