<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-16T15:33:06+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "de"
}
-->
# Praktische Umsetzung

Die praktische Umsetzung ist der Punkt, an dem die Stärke des Model Context Protocol (MCP) greifbar wird. Während das Verständnis der Theorie und Architektur hinter MCP wichtig ist, zeigt sich der wahre Wert erst, wenn Sie diese Konzepte anwenden, um Lösungen zu entwickeln, zu testen und bereitzustellen, die reale Probleme lösen. Dieses Kapitel schlägt die Brücke zwischen theoretischem Wissen und praktischer Entwicklung und führt Sie durch den Prozess, MCP-basierte Anwendungen zum Leben zu erwecken.

Egal, ob Sie intelligente Assistenten entwickeln, KI in Geschäftsabläufe integrieren oder maßgeschneiderte Werkzeuge für die Datenverarbeitung erstellen – MCP bietet eine flexible Grundlage. Das sprachunabhängige Design und die offiziellen SDKs für gängige Programmiersprachen machen es einer breiten Entwicklergemeinschaft zugänglich. Durch die Nutzung dieser SDKs können Sie schnell Prototypen erstellen, iterieren und Ihre Lösungen auf verschiedenen Plattformen und Umgebungen skalieren.

In den folgenden Abschnitten finden Sie praktische Beispiele, Beispielcode und Bereitstellungsstrategien, die zeigen, wie MCP in C#, Java, TypeScript, JavaScript und Python implementiert wird. Sie lernen außerdem, wie Sie MCP-Server debuggen und testen, APIs verwalten und Lösungen mit Azure in der Cloud bereitstellen. Diese praxisorientierten Ressourcen sollen Ihr Lernen beschleunigen und Ihnen helfen, robuste, produktionsreife MCP-Anwendungen sicher zu erstellen.

## Überblick

Diese Lektion konzentriert sich auf praktische Aspekte der MCP-Implementierung in verschiedenen Programmiersprachen. Wir zeigen, wie Sie MCP SDKs in C#, Java, TypeScript, JavaScript und Python nutzen, um robuste Anwendungen zu erstellen, MCP-Server zu debuggen und zu testen sowie wiederverwendbare Ressourcen, Prompts und Tools zu erstellen.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:
- MCP-Lösungen mit offiziellen SDKs in verschiedenen Programmiersprachen zu implementieren
- MCP-Server systematisch zu debuggen und zu testen
- Serverfunktionen (Resources, Prompts und Tools) zu erstellen und zu verwenden
- Effektive MCP-Workflows für komplexe Aufgaben zu entwerfen
- MCP-Implementierungen hinsichtlich Leistung und Zuverlässigkeit zu optimieren

## Offizielle SDK-Ressourcen

Das Model Context Protocol bietet offizielle SDKs für mehrere Sprachen:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbeiten mit MCP SDKs

Dieser Abschnitt bietet praktische Beispiele zur Implementierung von MCP in verschiedenen Programmiersprachen. Beispielcode finden Sie im Verzeichnis `samples`, das nach Sprache organisiert ist.

### Verfügbare Beispiele

Das Repository enthält Beispielimplementierungen in folgenden Sprachen:

- C#
- Java
- TypeScript
- JavaScript
- Python

Jedes Beispiel veranschaulicht zentrale MCP-Konzepte und Implementierungsmuster für die jeweilige Sprache und deren Ökosystem.

## Kernserver-Funktionen

MCP-Server können eine beliebige Kombination folgender Funktionen implementieren:

### Resources
Resources liefern Kontext und Daten, die vom Benutzer oder KI-Modell genutzt werden:
- Dokumentenarchive
- Wissensdatenbanken
- Strukturierte Datenquellen
- Dateisysteme

### Prompts
Prompts sind vorgefertigte Nachrichten und Workflows für Benutzer:
- Vorgefertigte Gesprächsvorlagen
- Geführte Interaktionsmuster
- Spezialisierte Dialogstrukturen

### Tools
Tools sind Funktionen, die das KI-Modell ausführen kann:
- Dienstprogramme zur Datenverarbeitung
- Integration externer APIs
- Rechenkapazitäten
- Suchfunktionen

## Beispielimplementierungen: C#

Das offizielle C# SDK-Repository enthält mehrere Beispielimplementierungen, die verschiedene Aspekte von MCP demonstrieren:

- **Basic MCP Client**: Einfaches Beispiel, das zeigt, wie man einen MCP-Client erstellt und Tools aufruft
- **Basic MCP Server**: Minimale Serverimplementierung mit grundlegender Tool-Registrierung
- **Advanced MCP Server**: Voll ausgestatteter Server mit Tool-Registrierung, Authentifizierung und Fehlerbehandlung
- **ASP.NET Integration**: Beispiele zur Integration mit ASP.NET Core
- **Tool Implementation Patterns**: Verschiedene Muster zur Implementierung von Tools mit unterschiedlicher Komplexität

Das MCP C# SDK befindet sich in der Vorschauphase, APIs können sich noch ändern. Wir werden diesen Blog kontinuierlich aktualisieren, während sich das SDK weiterentwickelt.

### Wichtige Funktionen
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Anleitung zum [Erstellen Ihres ersten MCP Servers](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Für vollständige C# Implementierungsbeispiele besuchen Sie das [offizielle C# SDK-Beispiel-Repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Beispielimplementierung: Java Implementation

Das Java SDK bietet robuste MCP-Implementierungsoptionen mit Enterprise-Features.

### Wichtige Funktionen

- Integration mit Spring Framework
- Starke Typensicherheit
- Unterstützung für reaktive Programmierung
- Umfassende Fehlerbehandlung

Für ein vollständiges Java-Implementierungsbeispiel siehe [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) im Beispielverzeichnis.

## Beispielimplementierung: JavaScript Implementation

Das JavaScript SDK bietet einen leichten und flexiblen Ansatz zur MCP-Implementierung.

### Wichtige Funktionen

- Unterstützung für Node.js und Browser
- Promise-basierte API
- Einfache Integration mit Express und anderen Frameworks
- WebSocket-Unterstützung für Streaming

Für ein vollständiges JavaScript-Implementierungsbeispiel siehe [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) im Beispielverzeichnis.

## Beispielimplementierung: Python Implementation

Das Python SDK bietet einen pythonischen Ansatz zur MCP-Implementierung mit exzellenten Integrationen zu ML-Frameworks.

### Wichtige Funktionen

- Async/await-Unterstützung mit asyncio
- Integration mit Flask und FastAPI
- Einfache Tool-Registrierung
- Native Integration mit beliebten ML-Bibliotheken

Für ein vollständiges Python-Implementierungsbeispiel siehe [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) im Beispielverzeichnis.

## API-Management

Azure API Management ist eine hervorragende Lösung, um MCP-Server abzusichern. Die Idee ist, eine Azure API Management-Instanz vor Ihren MCP-Server zu setzen und Funktionen zu übernehmen, die Sie wahrscheinlich benötigen, wie:

- Ratenbegrenzung
- Tokenverwaltung
- Überwachung
- Lastverteilung
- Sicherheit

### Azure-Beispiel

Hier ein Azure-Beispiel, das genau dies tut, also [einen MCP Server erstellt und mit Azure API Management absichert](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

So funktioniert der Autorisierungsablauf im folgenden Bild:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Im gezeigten Bild passiert Folgendes:

- Authentifizierung/Autorisierung erfolgt über Microsoft Entra.
- Azure API Management fungiert als Gateway und nutzt Richtlinien, um den Datenverkehr zu steuern und zu verwalten.
- Azure Monitor protokolliert alle Anfragen für eine weitere Analyse.

#### Autorisierungsablauf

Werfen wir einen genaueren Blick auf den Autorisierungsablauf:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-Autorisierungsspezifikation

Erfahren Sie mehr über die [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Remote MCP Server auf Azure bereitstellen

Sehen wir uns an, wie wir das zuvor erwähnte Beispiel bereitstellen können:

1. Repository klonen

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App` registrieren  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `  
   Nach einiger Zeit den Status mit `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` prüfen, ob die Registrierung abgeschlossen ist.

2. Führen Sie diesen [azd](https://aka.ms/azd)-Befehl aus, um den API Management Service, die Function App (mit Code) und alle weiteren erforderlichen Azure-Ressourcen bereitzustellen:

    ```shell
    azd up
    ```

    Dieser Befehl sollte alle Cloud-Ressourcen auf Azure bereitstellen.

### Testen Ihres Servers mit MCP Inspector

1. Öffnen Sie ein **neues Terminalfenster**, installieren und starten Sie MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Sie sollten eine Oberfläche sehen, die folgendermaßen aussieht:

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.de.png)

1. CTRL-Klick, um die MCP Inspector Web-App über die von der App angezeigte URL zu laden (z.B. http://127.0.0.1:6274/#resources)
1. Stellen Sie den Transporttyp auf `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` und **Verbinden**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Tools auflisten**. Klicken Sie auf ein Tool und **Tool ausführen**.  

Wenn alle Schritte erfolgreich waren, sind Sie jetzt mit dem MCP-Server verbunden und konnten ein Tool aufrufen.

## MCP-Server für Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Dieses Set an Repositories bietet eine Schnellstartvorlage zum Erstellen und Bereitstellen benutzerdefinierter Remote-MCP (Model Context Protocol) Server mit Azure Functions in Python, C# .NET oder Node/TypeScript.

Die Beispiele bieten eine vollständige Lösung, die Entwicklern ermöglicht:

- Lokal zu entwickeln und auszuführen: Entwicklung und Debugging eines MCP-Servers auf dem lokalen Rechner
- Bereitstellung auf Azure: Einfache Cloud-Bereitstellung mit einem einfachen azd up Befehl
- Verbindung von Clients: Verbindung zum MCP-Server von verschiedenen Clients, einschließlich des Copilot-Agentenmodus von VS Code und dem MCP Inspector Tool

### Wichtige Funktionen:

- Sicherheit durch Design: Der MCP-Server ist mit Schlüsseln und HTTPS abgesichert
- Authentifizierungsoptionen: Unterstützt OAuth mit eingebauter Authentifizierung und/oder API Management
- Netzwerktrennung: Ermöglicht Netzwerktrennung mit Azure Virtual Networks (VNET)
- Serverlose Architektur: Nutzt Azure Functions für skalierbare, ereignisgesteuerte Ausführung
- Lokale Entwicklung: Umfassende Unterstützung für lokale Entwicklung und Debugging
- Einfache Bereitstellung: Vereinfachter Bereitstellungsprozess für Azure

Das Repository enthält alle notwendigen Konfigurationsdateien, Quellcode und Infrastrukturdefinitionen, um schnell mit einer produktionsreifen MCP-Serverimplementierung zu starten.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Beispielimplementierung von MCP mit Azure Functions in Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Beispielimplementierung von MCP mit Azure Functions in C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Beispielimplementierung von MCP mit Azure Functions in Node/TypeScript.

## Wichtige Erkenntnisse

- MCP SDKs bieten sprachspezifische Werkzeuge zur Implementierung robuster MCP-Lösungen
- Der Debugging- und Testprozess ist entscheidend für zuverlässige MCP-Anwendungen
- Wiederverwendbare Prompt-Vorlagen ermöglichen konsistente KI-Interaktionen
- Gut gestaltete Workflows können komplexe Aufgaben mit mehreren Tools orchestrieren
- Die Implementierung von MCP-Lösungen erfordert Berücksichtigung von Sicherheit, Leistung und Fehlerbehandlung

## Übung

Entwerfen Sie einen praktischen MCP-Workflow, der ein reales Problem in Ihrem Fachbereich löst:

1. Identifizieren Sie 3-4 Tools, die bei der Lösung dieses Problems hilfreich wären
2. Erstellen Sie ein Workflow-Diagramm, das zeigt, wie diese Tools zusammenarbeiten
3. Implementieren Sie eine einfache Version eines der Tools in Ihrer bevorzugten Sprache
4. Erstellen Sie eine Prompt-Vorlage, die dem Modell hilft, Ihr Tool effektiv zu nutzen

## Zusätzliche Ressourcen


---

Weiter: [Advanced Topics](../05-AdvancedTopics/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.