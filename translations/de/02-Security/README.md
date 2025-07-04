<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T15:31:43+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "de"
}
-->
# Sicherheits-Best Practices

Die Einführung des Model Context Protocol (MCP) bringt leistungsstarke neue Möglichkeiten für KI-gesteuerte Anwendungen mit sich, stellt aber auch einzigartige Sicherheitsherausforderungen dar, die über traditionelle Software-Risiken hinausgehen. Neben etablierten Themen wie sicherem Programmieren, dem Prinzip der minimalen Rechtevergabe und der Sicherheit der Lieferkette sehen sich MCP und KI-Workloads neuen Bedrohungen gegenüber, wie Prompt Injection, Tool Poisoning und dynamischer Werkzeugmodifikation. Werden diese Risiken nicht richtig gehandhabt, können sie zu Datenabfluss, Datenschutzverletzungen und unerwartetem Systemverhalten führen.

Diese Lektion behandelt die relevantesten Sicherheitsrisiken im Zusammenhang mit MCP – darunter Authentifizierung, Autorisierung, übermäßige Berechtigungen, indirekte Prompt Injection und Schwachstellen in der Lieferkette – und bietet umsetzbare Maßnahmen und Best Practices zu deren Minderung. Außerdem lernen Sie, wie Sie Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security nutzen können, um Ihre MCP-Implementierung zu stärken. Durch das Verständnis und die Anwendung dieser Maßnahmen können Sie die Wahrscheinlichkeit eines Sicherheitsvorfalls deutlich reduzieren und sicherstellen, dass Ihre KI-Systeme robust und vertrauenswürdig bleiben.

# Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Die einzigartigen Sicherheitsrisiken des Model Context Protocol (MCP) zu identifizieren und zu erklären, einschließlich Prompt Injection, Tool Poisoning, übermäßiger Berechtigungen und Schwachstellen in der Lieferkette.
- Effektive Gegenmaßnahmen für MCP-Sicherheitsrisiken zu beschreiben und anzuwenden, wie robuste Authentifizierung, Prinzip der minimalen Rechtevergabe, sicheres Token-Management und Überprüfung der Lieferkette.
- Microsoft-Lösungen wie Prompt Shields, Azure Content Safety und GitHub Advanced Security zu verstehen und zu nutzen, um MCP und KI-Workloads zu schützen.
- Die Bedeutung der Validierung von Tool-Metadaten, der Überwachung dynamischer Änderungen und der Abwehr indirekter Prompt Injection-Angriffe zu erkennen.
- Etablierte Sicherheits-Best Practices – wie sicheres Programmieren, Server-Härtung und Zero-Trust-Architektur – in Ihre MCP-Implementierung zu integrieren, um die Wahrscheinlichkeit und Auswirkungen von Sicherheitsvorfällen zu verringern.

# MCP-Sicherheitskontrollen

Jedes System, das Zugriff auf wichtige Ressourcen hat, bringt implizite Sicherheitsherausforderungen mit sich. Diese Herausforderungen lassen sich in der Regel durch die korrekte Anwendung grundlegender Sicherheitskontrollen und -konzepte bewältigen. Da MCP erst neu definiert wurde, ändert sich die Spezifikation sehr schnell und entwickelt sich weiter. Mit der Zeit werden die Sicherheitskontrollen darin ausgereifter, was eine bessere Integration in Unternehmens- und etablierte Sicherheitsarchitekturen und Best Practices ermöglicht.

Forschungen, veröffentlicht im [Microsoft Digital Defense Report](https://aka.ms/mddr), zeigen, dass 98 % der gemeldeten Sicherheitsverletzungen durch robuste Sicherheits-Hygiene verhindert werden könnten. Der beste Schutz vor jeglicher Art von Sicherheitsvorfällen besteht darin, die grundlegende Sicherheits-Hygiene, sichere Programmierpraktiken und die Sicherheit der Lieferkette richtig umzusetzen – diese bewährten Praktiken haben nach wie vor den größten Einfluss auf die Reduzierung von Sicherheitsrisiken.

Schauen wir uns einige Möglichkeiten an, wie Sie Sicherheitsrisiken bei der Einführung von MCP angehen können.

> **Note:** Die folgenden Informationen sind korrekt zum **29. Mai 2025**. Das MCP-Protokoll entwickelt sich ständig weiter, und zukünftige Implementierungen können neue Authentifizierungsmuster und Kontrollen einführen. Für die neuesten Updates und Anleitungen konsultieren Sie stets die [MCP-Spezifikation](https://spec.modelcontextprotocol.io/) sowie das offizielle [MCP GitHub-Repository](https://github.com/modelcontextprotocol) und die [Seite zu Sicherheits-Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstellung  
Die ursprüngliche MCP-Spezifikation ging davon aus, dass Entwickler ihren eigenen Authentifizierungsserver schreiben würden. Dies erforderte Kenntnisse über OAuth und damit verbundene Sicherheitsanforderungen. MCP-Server fungierten als OAuth 2.0 Authorization Server und verwalteten die erforderliche Benutzer-Authentifizierung direkt, anstatt sie an einen externen Dienst wie Microsoft Entra ID zu delegieren. Ab dem **26. April 2025** erlaubt ein Update der MCP-Spezifikation, dass MCP-Server die Benutzer-Authentifizierung an einen externen Dienst delegieren können.

### Risiken
- Fehlkonfigurierte Autorisierungslogik im MCP-Server kann zur Offenlegung sensibler Daten und zu falsch angewendeten Zugriffskontrollen führen.
- Diebstahl von OAuth-Tokens auf dem lokalen MCP-Server. Wenn ein Token gestohlen wird, kann es verwendet werden, um den MCP-Server zu imitieren und auf Ressourcen und Daten des Dienstes zuzugreifen, für den das OAuth-Token ausgestellt wurde.

#### Token-Passthrough
Token-Passthrough ist in der Autorisierungsspezifikation ausdrücklich verboten, da es eine Reihe von Sicherheitsrisiken mit sich bringt, darunter:

#### Umgehung von Sicherheitskontrollen
Der MCP-Server oder nachgelagerte APIs könnten wichtige Sicherheitskontrollen wie Ratenbegrenzung, Anforderungsvalidierung oder Verkehrsüberwachung implementieren, die vom Token-Audience oder anderen Credential-Beschränkungen abhängen. Wenn Clients Tokens direkt bei den nachgelagerten APIs verwenden können, ohne dass der MCP-Server diese ordnungsgemäß validiert oder sicherstellt, dass die Tokens für den richtigen Dienst ausgestellt wurden, umgehen sie diese Kontrollen.

#### Probleme mit Verantwortlichkeit und Audit-Trail
Der MCP-Server kann MCP-Clients nicht identifizieren oder unterscheiden, wenn Clients mit einem von oben ausgestellten Access Token aufrufen, das für den MCP-Server möglicherweise undurchsichtig ist.  
Die Protokolle des nachgelagerten Resource Servers könnten Anfragen zeigen, die scheinbar von einer anderen Quelle mit einer anderen Identität stammen, anstatt vom MCP-Server, der die Tokens tatsächlich weiterleitet.  
Beide Faktoren erschweren die Untersuchung von Vorfällen, Kontrollen und Audits.  
Wenn der MCP-Server Tokens weitergibt, ohne deren Claims (z. B. Rollen, Privilegien oder Audience) oder andere Metadaten zu validieren, kann ein Angreifer mit einem gestohlenen Token den Server als Proxy für Datenabfluss nutzen.

#### Vertrauensgrenzen-Probleme
Der nachgelagerte Resource Server vertraut bestimmten Entitäten. Dieses Vertrauen kann Annahmen über Herkunft oder Verhaltensmuster der Clients beinhalten. Das Brechen dieser Vertrauensgrenze kann zu unerwarteten Problemen führen.  
Wenn das Token von mehreren Diensten ohne ordnungsgemäße Validierung akzeptiert wird, kann ein Angreifer, der einen Dienst kompromittiert, das Token nutzen, um auf andere verbundene Dienste zuzugreifen.

#### Risiko der zukünftigen Kompatibilität
Auch wenn ein MCP-Server heute als „reiner Proxy“ startet, könnte er später Sicherheitskontrollen hinzufügen müssen. Ein korrekter Token-Audience-Schutz erleichtert die Weiterentwicklung des Sicherheitsmodells.

### Gegenmaßnahmen

**MCP-Server DÜRFEN KEINE Tokens akzeptieren, die nicht explizit für den MCP-Server ausgestellt wurden**

- **Autorisierungslogik überprüfen und härten:** Prüfen Sie sorgfältig die Autorisierungsimplementierung Ihres MCP-Servers, um sicherzustellen, dass nur beabsichtigte Benutzer und Clients Zugriff auf sensible Ressourcen haben. Praktische Anleitungen finden Sie unter [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) und [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Sichere Token-Praktiken durchsetzen:** Befolgen Sie [Microsofts Best Practices für Token-Validierung und Lebensdauer](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), um Missbrauch von Access Tokens zu verhindern und das Risiko von Token-Wiederholungen oder Diebstahl zu reduzieren.
- **Token-Speicherung schützen:** Speichern Sie Tokens stets sicher und verwenden Sie Verschlüsselung, um sie im Ruhezustand und während der Übertragung zu schützen. Tipps zur Umsetzung finden Sie unter [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Übermäßige Berechtigungen für MCP-Server

### Problemstellung  
MCP-Server könnten mit zu umfangreichen Berechtigungen für den Dienst oder die Ressource ausgestattet sein, auf die sie zugreifen. Zum Beispiel sollte ein MCP-Server, der Teil einer KI-Verkaufsanwendung ist und auf einen Unternehmensdatenspeicher zugreift, nur Zugriff auf Verkaufsdaten haben und nicht auf alle Dateien im Speicher. Zurück zum Prinzip der minimalen Rechtevergabe (eines der ältesten Sicherheitsprinzipien): Keine Ressource sollte Berechtigungen haben, die über das hinausgehen, was für die Ausführung der vorgesehenen Aufgaben erforderlich ist. KI stellt in diesem Bereich eine besondere Herausforderung dar, da es schwierig sein kann, die genauen erforderlichen Berechtigungen zu definieren, um Flexibilität zu gewährleisten.

### Risiken  
- Übermäßige Berechtigungen können Datenabfluss oder Änderungen an Daten ermöglichen, auf die der MCP-Server eigentlich keinen Zugriff haben sollte. Dies kann auch ein Datenschutzproblem darstellen, wenn es sich um personenbezogene Daten (PII) handelt.

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

**Indirekte Prompt Injection** (auch bekannt als Cross-Domain Prompt Injection oder XPIA) ist eine kritische Schwachstelle in generativen KI-Systemen, einschließlich solcher, die das Model Context Protocol (MCP) verwenden. Bei diesem Angriff werden bösartige Anweisungen in externen Inhalten – wie Dokumenten, Webseiten oder E-Mails – versteckt. Wenn das KI-System diese Inhalte verarbeitet, interpretiert es die eingebetteten Anweisungen möglicherweise als legitime Benutzerbefehle, was zu unbeabsichtigten Aktionen wie Datenlecks, der Erzeugung schädlicher Inhalte oder der Manipulation von Benutzerinteraktionen führt. Für eine ausführliche Erklärung und Praxisbeispiele siehe [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Eine besonders gefährliche Form dieses Angriffs ist **Tool Poisoning**. Hierbei injizieren Angreifer bösartige Anweisungen in die Metadaten von MCP-Tools (wie Tool-Beschreibungen oder Parameter). Da große Sprachmodelle (LLMs) diese Metadaten nutzen, um zu entscheiden, welche Tools sie aufrufen, können kompromittierte Beschreibungen das Modell dazu verleiten, unautorisierte Tool-Aufrufe auszuführen oder Sicherheitskontrollen zu umgehen. Diese Manipulationen sind für Endnutzer oft unsichtbar, können aber vom KI-System interpretiert und ausgeführt werden. Dieses Risiko ist in gehosteten MCP-Server-Umgebungen besonders hoch, wo Tool-Definitionen nach Benutzerfreigabe aktualisiert werden können – ein Szenario, das manchmal als "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" bezeichnet wird. In solchen Fällen kann ein zuvor sicheres Tool später so modifiziert werden, dass es bösartige Aktionen ausführt, wie Datenabfluss oder Systemveränderungen, ohne dass der Nutzer davon erfährt. Mehr zu diesem Angriffsvektor unter [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.de.png)

## Risiken  
Unbeabsichtigte KI-Aktionen bergen verschiedene Sicherheitsrisiken, darunter Datenabfluss und Datenschutzverletzungen.

### Gegenmaßnahmen  
### Einsatz von Prompt Shields zum Schutz vor indirekten Prompt Injection-Angriffen
-----------------------------------------------------------------------------

**AI Prompt Shields** sind eine von Microsoft entwickelte Lösung, um sowohl direkte als auch indirekte Prompt Injection-Angriffe abzuwehren. Sie helfen durch:

1.  **Erkennung und Filterung:** Prompt Shields nutzen fortschrittliche Machine-Learning-Algorithmen und natürliche Sprachverarbeitung, um bösartige Anweisungen in externen Inhalten wie Dokumenten, Webseiten oder E-Mails zu erkennen und herauszufiltern.
    
2.  **Spotlighting:** Diese Technik hilft dem KI-System, zwischen gültigen Systemanweisungen und potenziell unzuverlässigen externen Eingaben zu unterscheiden. Durch die Transformation des Eingabetexts in eine für das Modell relevantere Form stellt Spotlighting sicher, dass die KI bösartige Anweisungen besser erkennt und ignoriert.
    
3.  **Begrenzer und Datenmarkierung:** Das Einfügen von Begrenzerzeichen in die Systemnachricht macht die Position des Eingabetexts explizit sichtbar und hilft dem KI-System, Benutzereingaben von potenziell schädlichen externen Inhalten zu trennen. Datenmarkierung erweitert dieses Konzept durch spezielle Marker, die die Grenzen von vertrauenswürdigen und nicht vertrauenswürdigen Daten hervorheben.
    
4.  **Kontinuierliche Überwachung und Updates:** Microsoft überwacht und aktualisiert Prompt Shields kontinuierlich, um neue und sich entwickelnde Bedrohungen zu adressieren. Dieser proaktive Ansatz stellt sicher, dass die Schutzmaßnahmen gegen die neuesten Angriffstechniken wirksam bleiben.
    
5. **Integration mit Azure Content Safety:** Prompt Shields sind Teil der umfassenderen Azure AI Content Safety-Suite, die zusätzliche Werkzeuge zur Erkennung von Jailbreak-Versuchen, schädlichen Inhalten und anderen Sicherheitsrisiken in KI-Anwendungen bietet.

Mehr Informationen zu AI Prompt Shields finden Sie in der [Prompt Shields-Dokumentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.de.png)

### Sicherheit der Lieferkette
Die Sicherheit der Lieferkette bleibt im KI-Zeitalter von grundlegender Bedeutung, doch der Umfang dessen, was als Ihre Lieferkette gilt, hat sich erweitert. Neben traditionellen Codepaketen müssen Sie nun alle KI-bezogenen Komponenten sorgfältig überprüfen und überwachen, einschließlich Foundation-Modelle, Embeddings-Dienste, Kontextanbieter und Drittanbieter-APIs. Jede dieser Komponenten kann Schwachstellen oder Risiken einführen, wenn sie nicht richtig verwaltet wird.

**Wichtige Sicherheitspraktiken für die Lieferkette bei KI und MCP:**
- **Alle Komponenten vor der Integration verifizieren:** Dies umfasst nicht nur Open-Source-Bibliotheken, sondern auch KI-Modelle, Datenquellen und externe APIs. Prüfen Sie stets Herkunft, Lizenzierung und bekannte Schwachstellen.
- **Sichere Deployment-Pipelines aufrechterhalten:** Verwenden Sie automatisierte CI/CD-Pipelines mit integrierter Sicherheitsprüfung, um Probleme frühzeitig zu erkennen. Stellen Sie sicher, dass nur vertrauenswürdige Artefakte in die Produktion gelangen.
- **Kontinuierlich überwachen und auditieren:** Implementieren Sie eine fortlaufende Überwachung aller Abhängigkeiten, einschließlich Modelle und Datendienste, um neue Schwachstellen oder Angriffe auf die Lieferkette zu erkennen.
- **Prinzip der geringsten Rechte und Zugriffskontrollen anwenden:** Beschränken Sie den Zugriff auf Modelle, Daten und Dienste auf das notwendige Minimum, damit Ihr MCP-Server funktioniert.
- **Schnell auf Bedrohungen reagieren:** Haben Sie einen Prozess für das Patchen oder Ersetzen kompromittierter Komponenten sowie für das Rotieren von Geheimnissen oder Zugangsdaten, falls ein Sicherheitsvorfall festgestellt wird.

[GitHub Advanced Security](https://github.com/security/advanced-security) bietet Funktionen wie Secret Scanning, Dependency Scanning und CodeQL-Analyse. Diese Tools integrieren sich mit [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) und [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), um Teams dabei zu unterstützen, Schwachstellen sowohl im Code als auch in KI-Lieferkettenkomponenten zu identifizieren und zu beheben.

Microsoft setzt intern ebenfalls umfangreiche Sicherheitspraktiken für die Lieferkette bei allen Produkten um. Mehr dazu erfahren Sie in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Bewährte Sicherheitspraktiken, die die Sicherheitslage Ihrer MCP-Implementierung verbessern

Jede MCP-Implementierung übernimmt die bestehende Sicherheitslage der Umgebung Ihrer Organisation, auf der sie aufbaut. Daher wird empfohlen, beim Betrachten der Sicherheit von MCP als Teil Ihrer gesamten KI-Systeme auch Ihre bestehende Sicherheitslage insgesamt zu verbessern. Die folgenden bewährten Sicherheitskontrollen sind dabei besonders relevant:

-   Sichere Programmierpraktiken in Ihrer KI-Anwendung – Schutz vor [den OWASP Top 10](https://owasp.org/www-project-top-ten/), den [OWASP Top 10 für LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), Verwendung sicherer Tresore für Geheimnisse und Tokens, Implementierung von durchgehend sicheren Kommunikationswegen zwischen allen Anwendungskomponenten usw.
-   Server-Härtung – wo möglich MFA einsetzen, Patches aktuell halten, Integration des Servers mit einem Drittanbieter-Identitätsanbieter für den Zugriff usw.
-   Geräte, Infrastruktur und Anwendungen stets mit aktuellen Patches versorgen
-   Sicherheitsüberwachung – Implementierung von Logging und Monitoring einer KI-Anwendung (einschließlich MCP-Client/Server) und Weiterleitung dieser Logs an ein zentrales SIEM zur Erkennung anomaler Aktivitäten
-   Zero-Trust-Architektur – logische Isolierung von Komponenten durch Netzwerk- und Identitätskontrollen, um seitliche Bewegungen zu minimieren, falls eine KI-Anwendung kompromittiert wird.

# Wichtige Erkenntnisse

- Sicherheitsgrundlagen bleiben entscheidend: Sichere Programmierung, Prinzip der geringsten Rechte, Lieferkettenverifizierung und kontinuierliche Überwachung sind für MCP und KI-Workloads unerlässlich.
- MCP bringt neue Risiken mit sich – wie Prompt Injection, Tool Poisoning und übermäßige Berechtigungen – die sowohl traditionelle als auch KI-spezifische Kontrollen erfordern.
- Verwenden Sie robuste Authentifizierungs-, Autorisierungs- und Token-Management-Praktiken und nutzen Sie nach Möglichkeit externe Identitätsanbieter wie Microsoft Entra ID.
- Schützen Sie sich vor indirekter Prompt Injection und Tool Poisoning, indem Sie Tool-Metadaten validieren, dynamische Änderungen überwachen und Lösungen wie Microsoft Prompt Shields einsetzen.
- Behandeln Sie alle Komponenten Ihrer KI-Lieferkette – einschließlich Modelle, Embeddings und Kontextanbieter – mit derselben Sorgfalt wie Code-Abhängigkeiten.
- Bleiben Sie auf dem neuesten Stand der sich entwickelnden MCP-Spezifikationen und tragen Sie zur Community bei, um sichere Standards mitzugestalten.

# Zusätzliche Ressourcen

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
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
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Weiter

Weiter: [Kapitel 3: Erste Schritte](../03-GettingStarted/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.